﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "66";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {


                    txtfrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtTO.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    // Fill_GV_Pending();
                    Fill_GV_Pending();
                    Fill_GV_Recieved();
                    Fill_GV_Forwarding();
                }

                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowedCashier.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }

    }

    private void Fill_GV_Pending()
    {
        if (Session["BranchID"].ToString().Trim() != "")
        {
            clsBLbookedTests obj_bTests = new clsBLbookedTests();
            obj_bTests.BranchID = Session["BranchID"].ToString().Trim();
            obj_bTests.From = txtfrom.Text.Trim().Substring(6, 4) + "/" + txtfrom.Text.Trim().Substring(3, 2) + "/" + txtfrom.Text.Trim().Substring(0, 2);
            obj_bTests.To = txtTO.Text.Trim().Substring(6, 4) + "/" + txtTO.Text.Trim().Substring(3, 2) + "/" + txtTO.Text.Trim().Substring(0, 2);
            obj_bTests.Status = "S";
            DataView dv_branches = obj_bTests.GetAll(3);
            obj_bTests = null;
            if (dv_branches.Count > 0)
            {
                gvpending.DataSource = dv_branches;
                gvpending.DataBind();
                dv_branches.Dispose();
            }
            else
            {
                dv_branches.Dispose();
                gvpending.DataSource = "";
                gvpending.DataBind();
            }
        }
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        Fill_GV_Pending();
        Fill_GV_Recieved();
        Fill_GV_Forwarding();
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void gvpending_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string _TestID="";
        string _BatchID="";
        string _LabID="";
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            _TestID = gvpending.DataKeys[index].Values[1].ToString().Trim();
            _BatchID = gvpending.DataKeys[index].Values[0].ToString().Trim();
            _LabID = gvpending.Rows[index].Cells[2].Text.Trim();
            clsBLCourierbatches obj_batch = new clsBLCourierbatches();
            obj_batch.BatchID = _BatchID;
            obj_batch.Status = "R";
            obj_batch.Sendstatus = "R";
            obj_batch.labid = _LabID;
            obj_batch.TestID = _TestID;
            obj_batch.RecievedBy = Session["PersonID"].ToString().Trim();
            obj_batch.RecievedAt = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            if (obj_batch.Update() && obj_batch.updatebookingstatus())
            {
                lblchech.Text = "Status Changed to 'Recieved' for the requested Test.";
                Fill_GV_Pending();
                Fill_GV_Recieved();
                Fill_GV_Forwarding();
            }


        }
    }

    protected void gvpending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // loop all data rows
            foreach (DataControlFieldCell cell in e.Row.Cells)
            {
                // check all cells in one row
                foreach (Control control in cell.Controls)
                {
                    // Must use LinkButton here instead of ImageButton
                    // if you are having Links (not images) as the command button.
                    LinkButton button = control as LinkButton;
                    if (button != null && button.CommandName == "Select")
                        // Add delete confirmation
                        button.OnClientClick = "if (!confirm('Are you sure?Caution: Process is Irreversible.')) return false;";
                } 
            }
        }
    }

    private void Fill_GV_Recieved()
    {
        if (Session["BranchID"].ToString().Trim() != "")
        {
            clsBLbookedTests obj_bTests = new clsBLbookedTests();
            obj_bTests.BranchID = Session["BranchID"].ToString().Trim();
            obj_bTests.From = txtfrom.Text.Trim().Substring(6, 4) + "/" + txtfrom.Text.Trim().Substring(3, 2) + "/" + txtfrom.Text.Trim().Substring(0, 2);
            obj_bTests.To = txtTO.Text.Trim().Substring(6, 4) + "/" + txtTO.Text.Trim().Substring(3, 2) + "/" + txtTO.Text.Trim().Substring(0, 2);
            obj_bTests.Status = "R";
            DataView dv_branches = obj_bTests.GetAll(5);
            obj_bTests = null;
            if (dv_branches.Count > 0)
            {
                gvRecieved.DataSource = dv_branches;
                gvRecieved.DataBind();
                dv_branches.Dispose();
            }
            else
            {
                dv_branches.Dispose();
                gvRecieved.DataSource = "";
                gvRecieved.DataBind();
            }
        }
    }
    private void Fill_GV_Forwarding()
    {

        if (Session["BranchID"].ToString().Trim() != "")
        {
            clsBLbookedTests obj_bTests = new clsBLbookedTests();
            obj_bTests.BranchID = Session["BranchID"].ToString().Trim();
            obj_bTests.From = txtfrom.Text.Trim().Substring(6, 4) + "/" + txtfrom.Text.Trim().Substring(3, 2) + "/" + txtfrom.Text.Trim().Substring(0, 2);
            obj_bTests.To = txtTO.Text.Trim().Substring(6, 4) + "/" + txtTO.Text.Trim().Substring(3, 2) + "/" + txtTO.Text.Trim().Substring(0, 2);
            obj_bTests.Status = "R";
            DataView dv_branches = obj_bTests.GetAll(6);
            obj_bTests = null;
            if (dv_branches.Count > 0)
            {
                gvForwarding.DataSource = dv_branches;
                gvForwarding.DataBind();
                dv_branches.Dispose();
            }
            else
            {
                dv_branches.Dispose();
                gvForwarding.DataSource = "";
                gvForwarding.DataBind();
            }
        }
    }
    protected void lnkRecieveSelected_Click(object sender, EventArgs e)
    {
        string _TestID = "";
        string _BatchID = "";
        string _LabID = "";
        for (int i = 0; i < gvpending.Rows.Count; i++)
        {
            if ((gvpending.Rows[i].Cells[0].FindControl("gvchkupcoming") as CheckBox).Checked)
            {
                int index = i;
                _TestID = gvpending.DataKeys[index].Values[1].ToString().Trim();
                _BatchID = gvpending.DataKeys[index].Values[0].ToString().Trim();
                _LabID = gvpending.Rows[index].Cells[2].Text.Trim();
                clsBLCourierbatches obj_batch = new clsBLCourierbatches();
                obj_batch.BatchID = _BatchID;
                obj_batch.Status = "R";
                obj_batch.Sendstatus = "R";
                obj_batch.labid = _LabID;
                obj_batch.TestID = _TestID;
                obj_batch.RecievedBy = Session["PersonID"].ToString().Trim();
                obj_batch.RecievedAt = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                if (obj_batch.Update() && obj_batch.updatebookingstatus())
                {

                }
                else
                {
 
                }
            }

        }
        lblchech.Text = "Status Changed to 'Recieved' for the requested Tests.";
        Fill_GV_Pending();
        Fill_GV_Recieved();
        Fill_GV_Forwarding();
    }
}