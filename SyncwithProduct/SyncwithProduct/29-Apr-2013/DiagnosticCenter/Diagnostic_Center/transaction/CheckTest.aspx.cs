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



public partial class transaction_CheckTest : System.Web.UI.Page
{
    //DataView dv_ReportPrferences = new DataView();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            CheckTesting();
           
        }
    }


    public void CheckTesting()
    {
        string prid = Request.QueryString["prid"];
        string prno = Request.QueryString["prno"];
        string bookingdid1 = Request.QueryString["bookingdid"];
        string bookingdid = Request.QueryString["bookingid"];
        string testtype = Request.QueryString["testtype"];
        string labid = Request.QueryString["labid"];
        string testid = Request.QueryString["testid"];
        string subdepartmentid = Request.QueryString["subdepartmentId"].ToString();
        //Response.Write(prid+prno+bookingdid+testtype+labid);

        //if (subdepartmentid == "3")
        //{
        //    Response.Redirect("wfrmHistopathologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid +"&subdepartmentid="+ subdepartmentid);

        //}
        //else if (subdepartmentid == "13")
        //{
        //    Response.Redirect("wfrmMicrobiologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
        //}
        //else
        //{
        if (Request.QueryString["print"].ToString() == "print")
        {
            try
            {
                clsBLPatientReg_Inv objpatient_reg = new clsBLPatientReg_Inv();
                objpatient_reg.BookingDID = Request.QueryString["bookingdid"].ToString().Trim();
                objpatient_reg.ProcessID = "8";
                if (!objpatient_reg.Bookingd_Update())
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('There was a problem updating the status');", true);
                }
            }
            catch { }
            if (System.Configuration.ConfigurationManager.AppSettings["clientid"].Trim() == "006")
            {
                if (subdepartmentid == "3")
                {
                    clsReporting obj_report = new clsReporting();
                    obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    obj_report.Reporttype = "4";//Hard coded for Histo Report
                    DataView rpt_preference = obj_report.GetAll(40);
                    
                    if (rpt_preference.Count > 0)
                    {
                        Response.Redirect(rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                    else
                    {
                        Response.Redirect("wfrmHistopathologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }

                }
                else if (subdepartmentid == "13")
                {
                    clsReporting obj_report = new clsReporting();
                    obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    obj_report.Reporttype = "5";//Hard coded for Micro Report
                    DataView rpt_preference = obj_report.GetAll(40);

                    if (rpt_preference.Count > 0)
                    {
                        Response.Redirect(rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                    else
                    {
                        Response.Redirect("wfrmMicrobiologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                }
                else
                {
                    clsReporting obj_report = new clsReporting();
                    obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    obj_report.Reporttype = "3";//Hard coded for General Report
                    DataView rpt_preference = obj_report.GetAll(40);
                    if (rpt_preference.Count > 0)
                    {
                        Response.Redirect("wfrmResultReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                    else
                    {
                        Response.Redirect("wfrmResultReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                }
            }
            else
            {
                if (testtype == "H")
                {
                    clsReporting obj_report = new clsReporting();
                    obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    obj_report.Reporttype = "4";//Hard coded for Histo Report
                    DataView rpt_preference = obj_report.GetAll(40);

                    if (rpt_preference.Count > 0)
                    {
                        Response.Redirect(rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                    else
                    {
                        Response.Redirect("wfrmHistopathologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                }
                else if (testtype == "M")
                {
                    clsReporting obj_report = new clsReporting();
                    obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    obj_report.Reporttype = "5";//Hard coded for Histo Report
                    DataView rpt_preference = obj_report.GetAll(40);

                    if (rpt_preference.Count > 0)
                    {
                        Response.Redirect(rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid1 + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                    else
                    {
                        Response.Redirect("wfrmMicrobiologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                    }
                }
                else if (testtype == "O")
                {
                    clsReporting obj_report = new clsReporting();
                    obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    obj_report.Reporttype = "6";//Hard coded for General Report1
                    DataView rpt_preference = obj_report.GetAll(40);

                    if (rpt_preference.Count > 0)
                    {
                        Response.Redirect(rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                    else
                    {
                        /*For Sindh Lab*/
                        Response.Redirect("Default.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        /*For Sindh Lab*/
                        // Response.Redirect("wfrmResultReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                }
                else
                {
                    clsReporting obj_report = new clsReporting();
                    obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    obj_report.Reporttype = "3";//Hard coded for General Report1
                    DataView rpt_preference = obj_report.GetAll(40);

                    if (rpt_preference.Count > 0)
                    {
                        Response.Redirect(rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid1 + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                    else
                    {
                        /*For Sindh Lab*/
                        Response.Redirect("Default.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        /*For Sindh Lab*/
                        // Response.Redirect("wfrmResultReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                        rpt_preference.Dispose();
                    }
                }
            }
        }
        else
        {
            if (System.Configuration.ConfigurationManager.AppSettings["clientid"].Trim() == "006")
            {
                clsReporting report = new clsReporting();
                DataView dv = new DataView();

                report.Prno = Request.QueryString["prno"].ToString();
                report.Labid = Request.QueryString["labid"].ToString();
                report.TestId = Request.QueryString["testid"].ToString();
                report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
                dv = report.GetAll(23);

                report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                DataView dv_repPreferencesgeneral = report.GetAll(40);
                DataView dv_preferenceshisto = dv_repPreferencesgeneral;
                DataView dv_preferencesmicro = dv_repPreferencesgeneral;
                for (int i = 0; i < dv.Count; i++)
                {
                    testid = dv[i]["testid"].ToString();
                    try
                    {
                        clsBLPatientReg_Inv objpatient_reg = new clsBLPatientReg_Inv();
                        objpatient_reg.BookingID = dv[i]["bookingid"].ToString().Trim();
                        objpatient_reg.ProcessID = "8";
                        if (!objpatient_reg.Update_status_onprint())
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('There was a problem updating the status');", true);
                        }
                    }
                    catch { }
                    if (dv[i]["subdepartmentid"].ToString() == "3")
                    {
                        dv_preferenceshisto.RowFilter = "ReportTypeid=4";
                        if (dv_preferenceshisto.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('" + dv_preferenceshisto[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                           // dv_preferenceshisto.Dispose();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('wfrmHistopathologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                        }
                    }
                    else if (dv[i]["subdepartmentid"].ToString() == "13")
                    {
                        dv_preferencesmicro.RowFilter = "ReportTypeid=5";
                        if (dv_preferencesmicro.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('" + dv_preferencesmicro[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                            // dv_preferenceshisto.Dispose();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('wfrmMicrobiologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                        }
                    }
                    else
                    {
                        dv_repPreferencesgeneral.RowFilter = "ReportTypeid=3";
                        if (dv_repPreferencesgeneral.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('" + dv_repPreferencesgeneral[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                            // dv_preferenceshisto.Dispose();
                        }
                        else
                        {
                            // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                        }
                    }
                    //else if (dv[i]["subdepartmentid"].ToString() == "2")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}

                    //else if (dv[i]["subdepartmentid"].ToString() == "4")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "5")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "6")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "7")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "8")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "9")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "10")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "11")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "12")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}

                    //else if (dv[i]["subdepartmentid"].ToString() == "14")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "15")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "16")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "17")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "18")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "19")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "20")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "21")
                    //{

                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "22")
                    //{
                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else if (dv[i]["subdepartmentid"].ToString() == "23")
                    //{
                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                    //else
                    //{
                    //    // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                    //}
                }
            }
            else
            {
                clsReporting report = new clsReporting();
                DataView dv = new DataView();

                report.Prno = Request.QueryString["prno"].ToString();
                report.Labid = Request.QueryString["labid"].ToString();
                report.TestId = Request.QueryString["testid"].ToString();
                report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
                dv = report.GetAll(23);

                report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                DataView dv_repPreferencesgeneral = report.GetAll(40);
                DataView dv_preferenceshisto = dv_repPreferencesgeneral;
                DataView dv_preferencesmicro = dv_repPreferencesgeneral;
                for (int i = 0; i < dv.Count; i++)
                {
                    testid = dv[i]["testid"].ToString();
                    if (testtype == "H")
                    {
                        dv_preferenceshisto.RowFilter = "ReportTypeid=4";
                        if (dv_preferenceshisto.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('" + dv_preferenceshisto[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                            // dv_preferenceshisto.Dispose();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('wfrmHistopathologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                        }
                    }
                    else if (testtype == "M")
                    {
                        dv_preferencesmicro.RowFilter = "ReportTypeid=5";
                        if (dv_preferencesmicro.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('" + dv_preferencesmicro[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                            // dv_preferenceshisto.Dispose();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('wfrmMicrobiologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                        }
                    }
                    else if (testtype == "O")
                    {
                        clsReporting obj_report = new clsReporting();
                        obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                        obj_report.Reporttype = "6";//Hard coded for General Report1
                        DataView rpt_preference = obj_report.GetAll(40);

                        if (rpt_preference.Count > 0)
                        {
                            Response.Redirect(rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                            rpt_preference.Dispose();
                        }
                        else
                        {
                            /*For Sindh Lab*/
                            Response.Redirect("Default.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                            /*For Sindh Lab*/
                            // Response.Redirect("wfrmResultReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                            rpt_preference.Dispose();
                        }
                    }
                    else
                    {
                        dv_repPreferencesgeneral.RowFilter = "ReportTypeid=3";
                        if (dv_repPreferencesgeneral.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('" + dv_repPreferencesgeneral[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false); //&bookingdid=" + bookingdid + 
                            // dv_preferenceshisto.Dispose();
                        }
                        else
                        {
                            // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('Default.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                        }
                    }
                }
            }
            // Response.Redirect("RptGeneralReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
            PrintOn.Text = "All reports has been generated successfully.";
            Image_Print.Visible = true;
        }
    }
        


    //}
}