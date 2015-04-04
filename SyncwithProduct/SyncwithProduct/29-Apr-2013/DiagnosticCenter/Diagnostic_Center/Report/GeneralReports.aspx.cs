using System;
using System.Configuration;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

public partial class WebForms_GeneralReports : System.Web.UI.Page
{
	private string _FromDate = "";
	private string _ToDate = "";
	private string _SelectionFormula = "";
	private string _ReportName = "";
	private DataTable  dt =null;
    private DataTable dtSub = null;

	private string _SubReportName = "";
	private string _SubSelectionFormula = "";

	private string _FromdateTime = "";
	private string _TodateTime = "";

	private string _Message = "";
	
	# region "Properties"
	public string ReportName
	{
		get
		{
			return _ReportName;
		}

		set
		{
			_ReportName = value;
		}
	}

	public string FromDate
	{
		get
		{
			return _FromDate;
		}
		set
		{
			_FromDate = value;
		}
	}


	public string ToDate
	{
		get
		{
			return _ToDate;
		}
		set
		{
			_ToDate = value;
		}
	}

	public string SelectionFormula
	{
		get
		{
			return _SelectionFormula;
		}
		set
		{
			_SelectionFormula = value;
		}
	}

	public string Message
	{
		get
		{
			return _Message;
		}
		set
		{
			//
		}
	}
	public string FromDateTime
	{
		get { return _FromdateTime; }
		set { _FromdateTime = value; }
	}
	public string TodateTime
	{
		get { return _TodateTime; }
		set { _TodateTime = value; }
	}

	# endregion

	private ReportDocument doc = new ReportDocument();

	private void Page_Load ( object sender , System.EventArgs e )
	{


		if (!IsPostBack)
		{
			//            
            
			_SelectionFormula = Session["selectionformula"].ToString();
			_ReportName = Session["reportname"].ToString();
            if (Session["TestTable"] != null)
            {
                dt = (DataTable)Session["TestTable"];
                Session.Remove("TestTable");
            }
            if (Session["testsubtable"] != null)
            {
                dtSub = (DataTable)Session["testsubtable"];
                Session.Remove("testsubtable");
            }
            if (Session["SubRptName"] != null)
            {
                _SubReportName = Session["SubRptName"].ToString();
                Session.Remove("SubRptName");
            }


			//_FromDate = clsBLReport.FromDate;
			//_ToDate = clsBLReport.ToDate;
			//_SubReportName = clsBLReport.SubReportName;
			//_SubSelectionFormula = clsBLReport.sSubSelectionFormula;
			//_FromdateTime = clsBLReport.FromDateTime;
			//_TodateTime = clsBLReport.ToDateTime;
			//

			//else if (Request.QueryString["reporttype"].Trim().Equals("worklist"))
			//{
			//    _SelectionFormula = "{vworklist.worklistno} = '" + Request.QueryString["worklistno"].Trim() + "'";
			//}
			if (Session["ReportDoc"] != null)
			{
				Session.Remove("ReportDoc");
			}
			//			doc = new ReportDocument();


			try
			{
				// Put user code to initialize the page here
				string strRUrl = Server.MapPath(@"../Report/" + _ReportName + ".rpt");
				Session["ReportUrl"] = strRUrl;

				//CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
				int i;
				int j;
				doc.Load(strRUrl);
				j = doc.Database.Tables.Count - 1;
                string userName = "bc_lims";//bc_lims
                string pwd = "UVE02Do8ze";//UVE02Do8ze
                string serverName = "bc_lims";//bc_lims

				//string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
				//string[] info = strConn.Split(';');
				//userName = ((info[1].Split('='))[1]).Trim();
				//pwd = ((info[3].Split('='))[1]).Trim();
				//serverName = ((info[2].Split('='))[1]).Trim();

				for (i = 0 ; i <= j ; i++)
				{
					TableLogOnInfo logOnInfo = new TableLogOnInfo();
					logOnInfo = doc.Database.Tables[i].LogOnInfo;
					ConnectionInfo connectionInfo = new ConnectionInfo();
					connectionInfo = logOnInfo.ConnectionInfo;
					connectionInfo.ServerName = serverName;
					connectionInfo.Password = pwd;
					connectionInfo.UserID = userName;
					doc.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
				}

				if (_SelectionFormula != "")
					doc.RecordSelectionFormula = _SelectionFormula;

				_SelectionFormula = doc.RecordSelectionFormula;
                if (dt != null)
                {
                    doc.SetDataSource(dt);
                }
                if (doc.Subreports.Count > 0 && dtSub != null && !_SubReportName.Equals(""))
                {
                    doc.Subreports[_SubReportName].SetDataSource(dtSub);
                }
				//if (!_SubReportName.Equals(""))
				//{

				//    Subreports sr = doc.Subreports; // for subreport
				//    sr[0].RecordSelectionFormula = _SubSelectionFormula;

				//}
                try
                {
                    doc.SetParameterValue("sclientid", System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString());
                }
                catch { }
				try
				{
					doc.SetParameterValue("SDate" , _FromDate);
				}
				catch { }


				try
				{
					doc.SetParameterValue("EDate" , _ToDate);
				}
				catch { }
                try
                {
                    doc.SetParameterValue("Chargesvisible", Session["Chargesvisible"].ToString().Trim());
                }
                catch { }
                //try
                //{
                //    //if(_ReportName.Equals("mastertest"))
                //    //doc.SetParameterValue("origin", "N");

                //}
                //catch { }

                CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
                string szFileName = Server.MapPath(@"../Report/pdf/"+_ReportName+Session["personid"].ToString().Trim()+System.DateTime.Now.ToString("ddMMyyyyhhmmsstt")+".pdf");
                dfdoCustomers.DiskFileName = szFileName;
                doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
                doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                doc.ExportOptions.DestinationOptions = dfdoCustomers;
                doc.Export();
                if (Request.QueryString[Rot13.Transform("Email")] == "Y")
                {
                    Response.Redirect("~/transaction/SentEmail.aspx?bookingid=" + Request.QueryString["bookingid"].ToString().Trim() + "&bookingdid=" + Request.QueryString["bookingdid"].ToString().Trim() + "&" + Rot13.Transform("FileName") + "=" + szFileName.Substring(szFileName.LastIndexOf("\\")+1));
                }
                else
                {
                    Response.Redirect(@"../Report/pdf/" + _ReportName + Session["personid"].ToString().Trim() + System.DateTime.Now.ToString("ddMMyyyyhhmmsstt")  +".pdf");
                }
				Session.Add("ReportDoc" , doc);
                //crvGeneral.ReportSource = doc;
                //crvGeneral.RefreshReport();

			}
			catch (Exception ex)
			{
				_Message = ex.Message + " " + _ReportName + " " + _SelectionFormula;
                Response.Write(_Message);
			}
		}
        //else
        //{
        //    doc = (ReportDocument)Session["ReportDoc"];

        //    crvGeneral.ReportSource = doc;
        //    crvGeneral.RefreshReport();

        //}
	}

	private void Page_UnLoad ( object sender , EventArgs e )
	{
		//if (IsPostBack)
		//{
        if (doc != null)
        {
            doc.Close();
            doc.Dispose();
            doc = null;
            GC.Collect();
        }

		//}
	}

	protected void btnPrint_Click ( object sender , EventArgs e )
	{
		try
		{
			doc.PrintToPrinter(1 , false , 0 , 0);                       
		}
		catch (Exception ex)
		{
			ScriptManager.RegisterStartupScript(this , typeof(Page) , "alert" , "<script>alert('" + ex.Message + "');</script>" , false);
		}
	}
}