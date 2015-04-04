using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

public partial class Report_HTMLReporting_spPanelServices : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillddlBranch();
            
        }
    }
    private void FillddlBranch()
    {
        clsBLBranch objbr = new clsBLBranch();
        DataView dv_branches = objbr.GetAll(3);
        if (dv_branches.Count > 0)
        {
            SComponents objcom = new SComponents();
            objcom.FillDropDownList(ddlBranch, dv_branches, "Name", "BRanchID", true, true, true);
        }
        else
        {
            ///Add Code if no branch found
        }
    }
    protected void lbtnReport_Click(object sender, ImageClickEventArgs e)
    {
       
            
        string branchname = "";
        string branchid = "";
        string PanelName = "";
        string PanelID = "";
        if (ddlBranch.SelectedValue.ToString().Equals("-1"))
        {
            branchname = "All Branches";
            branchid = "";
        }
        else
        {
            branchname = ddlBranch.SelectedItem.Text.Trim();
            branchid = ddlBranch.SelectedValue.ToString().Trim();
        }
        if (ddlPanel.SelectedValue.ToString().Equals("-1") || ddlPanel.Items.Count==0)
        {
            PanelName = "All Panels";
            PanelID= "";
        }
        else
        {
            PanelName = ddlPanel.SelectedItem.Text.Trim();
            PanelID = ddlPanel.SelectedValue.ToString().Trim();
        }
        if (rdocompletesummary.Checked == true)
        {
            Response.Write("<script language='javascript'>window.open('panelservices(outstanding).aspx?datefrom=" + txtdateFrom.Text.Trim() + "&dateto=" + txtdateTo.Text.Trim() + "&branchname=" + branchname + "&branchid=" + branchid + "&panelName=" + PanelName + "&panelid=" + PanelID + "');</script>");
        }
        else
        {
            if (ddlPanel.SelectedValue.ToString().Trim().Equals("-1"))
            {
                Response.Write("<script language='javascript'>alert('Please Select Panel');</script>");
                return;
            }
            clsReporting obj_report = new clsReporting();
            obj_report.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
            obj_report.Reporttype = "7";//Hard coded for panel Ledger Report
            DataView rpt_preference = obj_report.GetAll(40);

            if (rpt_preference.Count > 0)
            {
                //Response.Redirect(rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
                Response.Write("<script language='javascript'>window.open('"+rpt_preference[0]["Reportformat_path"].ToString().Trim() + "?datefrom="+txtdateFrom.Text.Trim() + "&dateto=" + txtdateTo.Text.Trim() + "&branchname=" + branchname + "&branchid=" + branchid + "&panelName=" + PanelName + "&panelid=" + PanelID + "');</script>");
               
                rpt_preference.Dispose();
            }
            else
            {
                Response.Write("<script language='javascript'>window.open('rptpanelLedger.aspx?datefrom=" + txtdateFrom.Text.Trim() + "&dateto=" + txtdateTo.Text.Trim() + "&branchname=" + branchname + "&branchid=" + branchid + "&panelName=" + PanelName + "&panelid=" + PanelID + "');</script>");
                rpt_preference.Dispose();
            }
            //Response.Write("<script language='javascript'>window.open('rptpanelLedger.aspx?datefrom=" + txtdateFrom.Text.Trim() + "&dateto=" + txtdateTo.Text.Trim() + "&branchname=" + branchname + "&branchid=" + branchid + "&panelName=" + PanelName + "&panelid=" + PanelID + "');</script>");
        }
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedValue.ToString().Trim() != "-1")
        {
            FillddlPanel();
        }
        else
        {
            ddlPanel.DataSource = "";
            ddlPanel.DataBind();
        }
    }
    private void FillddlPanel()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
        SComponents com = new SComponents();
        reg.ClientID = Session["ClientID"].ToString().Trim();
       // reg.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        if (!rdocompletesummary.Checked)
        {
            reg.Branch_ID = Session["BranchID"].ToString().Trim();
        }
        else
        {
            reg.Branch_ID = ddlBranch.SelectedValue.ToString().Trim();
        }
        if (edopaneldetails.Checked)
        {
            reg.Branch_ID = ddlBranch.SelectedValue.ToString().Trim();
        }
            //Session["default_route"].ToString();

        DataView dv = reg.GetAll(6);
        com.FillDropDownList(ddlPanel, dv, "name", "panelid",true,true,true);
    }
    protected void edopaneldetails_CheckedChanged(object sender, EventArgs e)
    {
        if (edopaneldetails.Checked)
        {
            FillddlPanel();
        }
    }
    protected void rdocompletesummary_CheckedChanged(object sender, EventArgs e)
    {
        if (rdocompletesummary.Checked)
        {
            FillddlPanel();
        }
    }
}