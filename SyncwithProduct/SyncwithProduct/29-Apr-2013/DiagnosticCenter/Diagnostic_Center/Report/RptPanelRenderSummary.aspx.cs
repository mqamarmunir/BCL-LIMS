using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

public partial class Report_RptPanelRenderSummary : System.Web.UI.Page
{
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();

    protected void Page_Load(object sender, EventArgs e)
    {
        patientBranchInfo();
        Fillgvmaster();
    }

    public void patientBranchInfo()
    {
        patient.Branch_ID = Session["branchid"].ToString();
        DataView dv = new DataView();
        dv = patient.GetAll(43);
        Lb_BranchNames.Text = dv[0]["branchName"].ToString();
        //Lb_branchAddress.Text = dv[0]["address"].ToString();
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

    private void Fillgvmaster()
    {
        clsReporting obj_reporting = new clsReporting();
        if (Request.QueryString["branchid"] != "-1")
        {
            obj_reporting.BranchID = Request.QueryString["BranchID"].ToString().Trim();

        }
        if (Request.QueryString["PanelId"] != "-1")
        {
            obj_reporting.PanelID = Request.QueryString["PanelId"].ToString().Trim();
        }
        //if (Request.QueryString["Consultant"] != "-1")
        //{
        //    obj_reporting.ConsultantID = Request.QueryString["Consultant"].ToString().Trim();
        //}
        obj_reporting.Datefrom = Request.QueryString["datefrom"].ToString().Trim();
        obj_reporting.Dateto = Request.QueryString["dateto"].ToString().Trim();
        DataView dv = obj_reporting.GetAll(30);
        if (dv.Count > 0)
        {
            gvMain.DataSource = dv;
            gvMain.DataBind();
        }
        else
        {
            gvMain.DataSource = "";
            gvMain.DataBind();
        }
    }

}