using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.Configuration;

namespace Shared.WebControls 
{
	public class ReportGridView : GridView, INamingContainer
	{
		#region Private Members
		private bool _allowPrintPaging;
		private int _printPageSize;

		private int _currentPageRow;
		private int _currentPrintPage;
        private int _printPageCount;
        

        private string branchid =  "";

        public string Branchid
        {
            get { return branchid; }
            set { branchid = value; }
        }
		#endregion

		#region Public Properties
		public int PrintPageSize
		{
			get { return _printPageSize; }
			set { _printPageSize = value; }
		}

		public bool AllowPrintPaging
		{
			get { return _allowPrintPaging; }
			set { _allowPrintPaging = value; }
		}

		public int CurrentPrintPage
		{
			get { return _currentPrintPage; }			
		}

        public int PrintPageCount
        {
            get { return _printPageCount; }
        }
		#endregion

		#region Templates
		private ITemplate _pageHeaderTemplate = null;

		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(ReportGridViewPageBreak))]
		public ITemplate PageHeaderTemplate
		{
			get
			{
				return _pageHeaderTemplate;
			}
			set
			{
				_pageHeaderTemplate = value;
			}
		}

        private ITemplate _pageFooterTemplate = null;
	   

	    [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TemplateContainer(typeof(ReportGridViewPageBreak))]
        public ITemplate PageFooterTemplate
        {
            get
            {
                return _pageFooterTemplate;
            }
            set
            {
                _pageFooterTemplate = value;
            }
        }
	    #endregion

		#region Control State Management

		protected override object SaveControlState()
		{
			object[] state = new object[3];
			state[0] = base.SaveControlState();
			state[1] = this._allowPrintPaging;
			state[2] = this._printPageSize;
			
			return state;
		}

		protected override void LoadControlState(object savedState)
		{
			object[] state = (object[])savedState;
			base.LoadControlState(state[0]);
			this._allowPrintPaging = Convert.ToBoolean(state[1]);
			this._printPageSize = Convert.ToInt32(state[2]);
		}
		#endregion

		#region Initialization
		public ReportGridView()
		{
			_allowPrintPaging = false;
			_printPageSize = Int32.MaxValue;
			_currentPageRow = 0;
			_currentPrintPage = 1;
		}

       

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (_allowPrintPaging)
			{
				this.RowDataBound += new GridViewRowEventHandler(ReportGridView_RowDataBound);
                this.DataBound += new EventHandler(ReportGridView_DataBound);

			}
		}

        void ReportGridView_DataBound(object sender, EventArgs e)
        {
            this._printPageCount = Convert.ToInt32(Math.Ceiling(Rows.Count/Convert.ToDouble(PrintPageSize)));
        }
		#endregion

		#region PageBreak
		void ReportGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
			{
				_currentPageRow++;
				if (_currentPageRow == this._printPageSize)
				{
					_currentPageRow = 0;
					e.Row.SetRenderMethodDelegate(PageBreakRender);
				}

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    string getDate = System.DateTime.Now.ToString("MMM dd,yyyy hh:mm:ss tt");
                    (e.Row.FindControl("Lb_TodayDate") as Label).Text = "Print On : " + getDate.ToString();
                    try
                    {
                        (e.Row.FindControl("lblnoresponsibility") as Label).Visible = true;// "Sample Received From Outside " + System.Configuration.ConfigurationManager.AppSettings["ClientName"].ToString() + " bears no responsibility regarding correct identity and quality of sample.";
       
                        (e.Row.FindControl("lblnoresponsibility") as Label).Text = "Sample Received From Outside " + WebConfigurationManager.AppSettings["ClientName"].ToString() + " bears no responsibility regarding correct identity and quality of sample.";

                    }
                    catch { }
                }
			}

		}

		protected void PageBreakRender(HtmlTextWriter output, Control container)
		{
            HtmlTextWriter cellsWriter = new HtmlTextWriter(new StringWriter());
			foreach (Control c in container.Controls)
			{
				TableCell cell = (TableCell)c;
				cell.RenderControl(cellsWriter);
			}
			
			output.Write("<tr>");
            output.Write(cellsWriter.InnerWriter.ToString());
            output.Write("</tr></table>");
            output.Write(GetPageFooterHtml());
            
            //If it is the last row, don't show the next header
            if (_currentPrintPage ==  PrintPageCount && Rows.Count % (_currentPrintPage) == 0)
                return;

            output.Write("<div style=\"page-break-after:always;\"></div>");    
			output.Write(GetHeaderHtml());
			_currentPrintPage++;
		}

		private string GetHeaderHtml()
		{
			HtmlTextWriter headerWriter = new HtmlTextWriter(new StringWriter());

            if (this._pageHeaderTemplate != null)
            {
                ReportGridViewPageBreak pageheader = new ReportGridViewPageBreak(_currentPrintPage);
                this._pageHeaderTemplate.InstantiateIn(pageheader);

                pageheader.DataBind();
                pageheader.RenderControl(headerWriter);

                // (pageheader.FindControl("lab_header") as Label).Text = "Amman";

                //clsPreferenceSettings prefSetting = new clsPreferenceSettings();
                //DataView dv = new DataView();
                //dv = prefSetting.GetALL(1);
                //if (dv.Count > 0)
                //{
                //    if (dv[0]["Path_location"].ToString() != null)
                //    {
                //        Img_header.Visible = true;
                //        Img_header.ImageUrl = dv[0]["Path_location"].ToString();
                //    }
                //    else
                //    {
                //        Img_header.ImageUrl = "#";
                //    }
                //}
                //for (int i = 0; i < _currentPrintPage; i++)
                //{

                (pageheader.FindControl("lab_br") as Label).Text = "Saloo";
                   // (pageheader.FindControl("lab_br") as Label).Text = System.Web.HttpContext.Current.Session["branchid"].ToString();
                //}
            }
			this.RenderBeginTag(headerWriter);											
			
			this.HeaderRow.RenderControl(headerWriter);

            //removes the extra </tr>
            return headerWriter.InnerWriter.ToString().Substring(0, headerWriter.InnerWriter.ToString().Length - 5); ;
		}

        private string GetPageFooterHtml()
        {
            HtmlTextWriter footerWriter = new HtmlTextWriter(new StringWriter());

            if (this._pageFooterTemplate != null)
            {
                ReportGridViewPageBreak pagefooter = new ReportGridViewPageBreak(_currentPrintPage);
                this._pageFooterTemplate.InstantiateIn(pagefooter);

                pagefooter.DataBind();
                pagefooter.RenderControl(footerWriter);

                //string getDate = System.DateTime.Now.ToString("MMM dd,yyyy hh:mm:ss tt");
                //(pagefooter.FindControl("Lb_TodayDate") as Label).Text  = "Print On : " + getDate.ToString();
            }
            return footerWriter.InnerWriter.ToString();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            //Renders the last page footer
            writer.Write(GetPageFooterHtml());
        }
		#endregion
	}
}