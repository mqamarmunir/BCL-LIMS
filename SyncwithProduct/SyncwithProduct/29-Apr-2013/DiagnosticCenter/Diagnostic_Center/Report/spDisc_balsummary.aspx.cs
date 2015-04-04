using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Globalization;

public partial class Report_spDisc_balsummary : System.Web.UI.Page
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
       
        if (rdoBalanceSummary.Checked == true)
        {
            Response.Write("<script language='javascript'>window.open('rptbal_discsummary.aspx?datefrom=" + txtdateFrom.Text.Trim() + "&dateto=" + txtdateTo.Text.Trim() + "&branchname=" + branchname + "&branchid=" + branchid + "');</script>");
        }
        else
        {

            Response.Write("<script language='javascript'>window.open('rptbal_discsummary.aspx?datefrom=" + txtdateFrom.Text.Trim() + "&dateto=" + txtdateTo.Text.Trim() + "&branchname=" + branchname + "&branchid=" + branchid + "');</script>");
        }
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {

    }
}