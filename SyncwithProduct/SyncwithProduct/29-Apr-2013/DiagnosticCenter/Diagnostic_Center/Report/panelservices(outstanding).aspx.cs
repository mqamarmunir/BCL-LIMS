﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Globalization;
using System.Data;


public partial class Report_HTMLReporting_panelservices_outstanding_ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillOrgInfo();
            FillGv();
        }
    }

    private void FillOrgInfo()
    {
        lblBranchname.Text = Request.QueryString["BranchName"].ToString().Trim();
        lbldaterange.Text = DateTime.Parse(Request.QueryString["datefrom"], new CultureInfo("ur-Pk", false)).ToString("MMM dd, yyyy") + "  To: " + DateTime.Parse(Request.QueryString["dateto"], new CultureInfo("ur-Pk", false)).ToString("MMM dd, yyyy");
        clsBLBranch objBranch = new clsBLBranch();
        objBranch.BranchID = "1";
        DataView dv_brinfo = objBranch.GetAll(8);
        if (dv_brinfo.Count > 0)
        {
            lblOrgName.Text=dv_brinfo[0]["Name"].ToString().Trim();
            lblAddress.Text = dv_brinfo[0]["StreetAddress"].ToString().Trim() + ", " + dv_brinfo[0]["CityName"].ToString().Trim();
            lblPhonenum.Text = dv_brinfo[0]["PhoneNo"].ToString().Trim() + "     Fax No:" + dv_brinfo[0]["FaxNo"].ToString().Trim();

        }

    }
    private void FillGv()
    {
        clsReporting report = new clsReporting();
        report.Datefrom = DateTime.Parse(Request.QueryString["datefrom"], new CultureInfo("ur-Pk", false)).ToString("dd/MM/yyyy");
        report.Dateto = DateTime.Parse(Request.QueryString["dateto"], new CultureInfo("ur-Pk", false)).AddDays(1).ToString("dd/MM/yyyy");
        if (Request.QueryString["branchid"].ToString().Trim() != "-1" && Request.QueryString["branchid"].ToString().Trim() != "")
        {
            report.BranchID = Request.QueryString["branchid"].ToString().Trim();
        }
        if (Request.QueryString["panelid"].ToString().Trim() != "-1" && Request.QueryString["panelid"].ToString().Trim() != "")
        {
            report.PanelID = Request.QueryString["panelid"].ToString().Trim();
        }
        DataView dv = report.GetAll(37);
        if (dv.Count > 0)
        {
            gvMain.DataSource = dv;
            gvMain.DataBind();
        }
        else
        {
 ///Display no record found here...
        }


    }
}