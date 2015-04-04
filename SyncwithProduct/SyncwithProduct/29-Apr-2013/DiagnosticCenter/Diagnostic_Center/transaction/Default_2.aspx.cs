using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.IO;
using BusinessLayer;
using AjaxControlToolkit;
using System.Text;
using System.Collections.Generic;
using Shared.WebControls;


public partial class transaction_Default : System.Web.UI.Page
{
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    ReportGridView r = new ReportGridView();
   
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            report.Delete_RecordResultView();
            report.Prid = Request.QueryString["prid"].ToString();
            report.Insert_RecordResultView();
            patientPrimaryInformation();
            patientBranchInfo();

            
           
            /////
            for (int i = 0; i < Gv_GroupTest.Rows.Count; i++)
            {
                int countemptyrows = 0;
                int countemptyresult = 0;
                try
                {
                    GridView gv_attributes = (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView);
                    gv_attributes.HeaderRow.Cells[0].Text = "";
                    gv_attributes.HeaderRow.Cells[1].Text = "Result";

                    //int columncount = gv_attributes.Columns.Count;
                    gv_attributes.HeaderRow.Cells[1].Font.Underline = true;
                    gv_attributes.HeaderRow.Cells[7].Visible = false;
                    foreach (GridViewRow gr in gv_attributes.Rows)
                    {
                        gr.Cells[7].Visible = false;
                        if (gr.Cells[5].Text.Trim().Replace("&nbsp;", "").Equals("") || gr.Cells[5].Text.Trim().Replace("&nbsp;", "").Equals("-"))
                        {
                            countemptyrows++;
                        }
                        if (gr.Cells[2].Text.Trim().Replace("&nbsp;", "").Equals("") || gr.Cells[2].Text.Trim().Replace("&nbsp;", "").Equals("-"))
                        {
                            countemptyresult++;
                        }


                    }
                    if (countemptyrows == gv_attributes.Rows.Count)
                    {
                        gv_attributes.HeaderRow.Cells[6].Visible = false;
                        gv_attributes.HeaderRow.Cells[5].Visible = false;
                        gv_attributes.HeaderRow.Cells[4].Visible = false;
                        foreach (GridViewRow gr in gv_attributes.Rows)
                        {
                            gr.Cells[6].Visible = false;
                            gr.Cells[5].Visible = false;
                            gr.Cells[4].Visible = false;
                            // if (gr.Cells[7].Text.Equals("") || gr.Cells[7].Text.Equals("-"))
                            //{
                            //  countemptyrows++;
                            // }


                        }
                    }
                    if (countemptyresult == gv_attributes.Rows.Count)
                    {
                        gv_attributes.HeaderRow.Cells[2].Text = "Last Result";
                    }
                }
                catch
                {
                }
                //gv_attributes.Columns.RemoveAt(7);
                //gv_attributes.Columns[0].HeaderStyle.Font.Underline = true;
                //gv_attributes.Columns[0].ShowHeader = false;
            }
            ////
        }
    }



    public void patientPrimaryInformation()
    {
        DataView dv = new DataView();
        dv = prefSetting.GetALL(1);
        if (dv.Count > 0)
        {
            if (dv[0]["Path_location"].ToString() != null)
            {
                Img_header.Visible = true;
                Img_header.ImageUrl = dv[0]["Path_location"].ToString();
            }
            else
            {
                Img_header.ImageUrl = "#";
            }
            if (Session["footer"] != null)
            {
               // Img_footer.ImageUrl = Session["footer"].ToString();
            }
            else
            {
                // Img_footer.ImageUrl = "#";
            }
        }

        dv = new DataView();
        report.Prno = Request.QueryString["prno"];
        report.Labid = Request.QueryString["labid"];
        dv = report.GetAll(2);
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        report.Prno = Request.QueryString["prno"].ToString();
        report.Labid = Request.QueryString["labid"].ToString();
        report.TestId = Request.QueryString["testid"].ToString();
        report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
        if (Request.QueryString["bookingdid"] != null)
        { report.Bookingdid = Request.QueryString["bookingdid"].ToString().Trim(); }
        dv = report.GetAll(13);
        int counting = dv.Count;
        //Lb_PrintCount.Text = "Total Prints: " + counting.ToString();


        Gv_GroupTest.DataSource = dv;
        Gv_GroupTest.DataBind();

        //for (int a = 0; a < dv.Count; a++)
        //{
        //    DataView dvrange = new DataView();
        //    report.TestId = dv[0]["testid"].ToString();
        //    dvrange = report.GetAll(26);
        //    if (dvrange.Count > 0)
        //    {
        //        for (int b = 0; b < dvrange.Count; b++)
        //        {
        //            (Gv_GroupTest.Rows[a].FindControl("Label2") as Label).Text += dvrange[b]["description"].ToString();
        //        }
        //    }
        //}
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            e.Row.Cells[0].Width = Unit.Percentage(25);
            e.Row.Cells[0].Font.Size = 8;
            e.Row.Cells[0].Text = HttpUtility.HtmlDecode(e.Row.Cells[0].Text);

            e.Row.Cells[1].Width = Unit.Percentage(15);
            e.Row.Cells[1].Font.Size = 8;
            e.Row.Cells[1].Font.Bold = true;
            DataRowView rowview = (DataRowView)e.Row.DataItem;
            if (rowview["AbNormal"].ToString() == "Y")
            {
                e.Row.Cells[1].Font.Underline = true;
            }
           


            e.Row.Cells[2].Width = Unit.Percentage(15);
            e.Row.Cells[2].Font.Size = 8;
            

            e.Row.Cells[3].Width = Unit.Percentage(10);
            e.Row.Cells[4].Width = Unit.Percentage(10);
            e.Row.Cells[5].Width = Unit.Percentage(10);
            e.Row.Cells[6].Width = Unit.Percentage(10);

            e.Row.Cells[1].BackColor = Color.FromName("#EEEEEE");
            e.Row.Cells[1].BorderColor = Color.White;
            e.Row.Cells[1].BorderStyle = BorderStyle.Solid;
            e.Row.Cells[1].Font.Size = 8;
            e.Row.VerticalAlign = VerticalAlign.Top;

            e.Row.Cells[3].Font.Size = 8;
            e.Row.Cells[4].Font.Size = 8;
            e.Row.Cells[5].Font.Size = 8;

            string encoded = e.Row.Cells[2].Text;
            e.Row.Cells[2].Text = Context.Server.HtmlDecode(encoded);

            string encoded2 = e.Row.Cells[1].Text;
            e.Row.Cells[1].Text = Context.Server.HtmlDecode(encoded2);

            try
            {
                e.Row.Cells[5].Text = (Convert.ToDouble(e.Row.Cells[1].Text.Trim()) * Convert.ToDouble(e.Row.Cells[4].Text.Replace("x","").Trim())).ToString().Trim();
            }
            catch
            {
                e.Row.Cells[5].Text = "-";
            }
            
            
        }
        //else if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    (e.Row.FindControl("lblnoresponsibility") as Label).Text = "Sample Received From Outside " + System.Configuration.ConfigurationManager.AppSettings["ClientName"].ToString() + " bears no responsibility regarding correct identity and quality of sample.";
        //}
        else
        {
            string encoded = e.Row.Cells[2].Text;
            e.Row.Cells[2].Text = Context.Server.HtmlDecode(encoded);

            string encoded2 = e.Row.Cells[1].Text;
            e.Row.Cells[1].Text = Context.Server.HtmlDecode(encoded2);

        }

        //e.Row.Cells[1].Width = 100;
    }

    protected void Gv_GroupTest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gv_GroupTest.PageIndex = e.NewPageIndex;
        patientPrimaryInformation();  
    }

    protected void Gv_GroupTest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        int index = e.Row.RowIndex;
        if (index != -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            string bookingdid = Gv_GroupTest.DataKeys[index].Values[0].ToString();
            Lb_dateAll.Text = "";

            DataView dv1 = new DataView();
            report.Bookingdid = bookingdid;
            report.TestId = Gv_GroupTest.DataKeys[index].Values[1].ToString();
            report.Prid = Gv_GroupTest.DataKeys[index].Values[2].ToString();
            report.OrganizationName = "SL";
            dv1 = report.GetAll(15);
            if (dv1.Count > 0)
            {
                for (int k = 0; k < dv1.Count; k++)
                {
                    string date = "MAX(IF(date_format(t.enteredon,'%d-%m-%y') = '" + dv1[k]["headerName"].ToString() + "', result, NULL)) AS '" + dv1[k]["headerName"].ToString() + "'";
                    if (k == 0)//getting latest value of abnormal
                    {
                        sb.Append("MAX(IF(date_format(t.enteredon,'%d-%m-%y') = '" + dv1[k]["headerName"].ToString() + "', Abnormal, NULL)) AS '" + "Abnormal" + "'");
                    }
                    Lb_dateAll.Text += date + ",";
                    
                }
                if (dv1.Count == 1)
                {
                    Lb_dateAll.Text += "'-'as '&nbsp;',"; 
                }
                string getDates = Lb_dateAll.Text;
                report.ObjectDate = getDates.Remove(getDates.Length - 1);
                report.AbnormalObject = sb.ToString();
                report.OrganizationName = "SL";
                dv1 = report.GetAll(14);
                GridView gr;
                gr = (e.Row.FindControl("Gv_Attributes") as GridView);
                gr.DataSource = dv1;
                gr.DataBind();
                
                //gr.Columns[1].HeaderText = "Result";
                //gr.Columns[0].ShowHeader = false;
            }

            DataView dv3 = new DataView();
            report.Bookingdid = bookingdid;
            dv3 = report.GetAll(12);

            GridView gr3;
            gr3 = (e.Row.FindControl("Gv_OpionionComments") as GridView);
            if (dv3.Count > 0 && (dv3[0]["opinion"].ToString().Trim().Length>1 || dv3[0]["comment"].ToString().Trim().Length>1))
            {
                gr3.DataSource = dv3;
                gr3.DataBind();
            }

            else
            {
                gr3.Visible = false;
            }
            string test_range = Gv_GroupTest.DataKeys[index].Values[1].ToString();
            string test_auto = Gv_GroupTest.DataKeys[index].Values[3].ToString();
            //  for (int l = 0; l < dv.Count; l++)
            //  {
            if (test_auto != "")
            {
                report.TestId = test_range;
                DataView dvSee = new DataView();
                dvSee = report.GetAll(22);
                // GridView gr4;
                // gr4 = (e.Row.FindControl("Gv_SeeBelow") as GridView);
                // gr4.DataSource = dvSee;
                // gr4.DataBind();

                string autoText = dvSee[0]["autotext"].ToString();
                (e.Row.FindControl("Label1") as Label).Text = "<b><u>Interpretation:</u></b><br />" + autoText;
            }

            DataView dvrange = new DataView();
            report.TestId = Gv_GroupTest.DataKeys[index].Values[1].ToString();
            dvrange = report.GetAll(29);
            if (dvrange.Count > 0)
            {
                //(e.Row.FindControl("Label2") as Label).Text = "a";
                //(e.Row.FindControl("Gv_Attributes") as GridView).Row.F;
                //for (int x = 0; x < dvrange.Count; x++)
                //{
                //    ((e.Row.FindControl("Gv_Attributes") as GridView).Rows[x].FindControl("Label2") as Label).Text = dvrange[0]["description"].ToString();
                //}
                ListView gr4;
                gr4 = (e.Row.FindControl("ListView1") as ListView);
                gr4.DataSource = dvrange;
                gr4.DataBind();
                
            }


            // }
            //e.Row.Attributes["style"] = "page-break-after:always;";
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {

           // (e.Row.FindControl("lblnoresponsibility") as Label).Text = "Sample Received From Outside " + System.Configuration.ConfigurationManager.AppSettings["ClientName"].ToString() + " bears no responsibility regarding correct identity and quality of sample.";
       
        }
    }


    protected void Gv_GroupTest_DataBound(object sender, EventArgs e)
    {

       
    }



    public void patientBranchInfo()
    {
        if (Session["branchid"] != "")
        {
            patient.Branch_ID = Session["branchid"].ToString();
        }
        else
        {
            patient.Branch_ID = Request.QueryString["branchid"].ToString();
        }
        DataView dv = new DataView();
        dv = patient.GetAll(43);
        Lb_BranchNames.Text = dv[0]["branchName"].ToString();
        // Lb_branchAddress.Text = dv[0]["address"].ToString();
        string _24hrs = dv[0]["24HrsService"].ToString();

        if (_24hrs == "Y")
        {
            Lb_starttime.Text = "24 Hrs";
            Lb_endtime.Visible = false;
            lb_phonebranchmain.Text = dv[0]["phone"].ToString();
        }
        else
        {
            Lb_starttime.Text = dv[0]["starttimes"].ToString();
            Lb_endtime.Text = dv[0]["endtimes"].ToString();
            lb_phonebranchmain.Text = dv[0]["phone"].ToString();
            Lb_Extension.Text = dv[0]["Ext"].ToString();
        }

    }
}