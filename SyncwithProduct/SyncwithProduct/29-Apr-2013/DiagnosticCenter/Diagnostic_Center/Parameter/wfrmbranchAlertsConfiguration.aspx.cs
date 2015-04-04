using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

public partial class Parameter_wfrmbranchAlertsConfiguration : System.Web.UI.Page
{
    private static string mode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["PersonId"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "61";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillDDlBranch();
                    FillDDlAlerts();
                    FillGV();
                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
            }

        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }
    private void FillDDlAlerts()
    {
        clsBLAlerts obj_Alerts = new clsBLAlerts();
        obj_Alerts.Active = "Y";
        DataView dv = obj_Alerts.GetAll(1);
        if (dv.Count > 0)
        {
            SComponents obj_com = new SComponents();
            obj_com.FillDropDownList(ddlAlerts, dv, "DetailedName", "AlerttypeID", true, false, true);
            obj_com = null;
        }
        else
        {
            ddlAlerts.DataSource = "";
            ddlAlerts.DataBind();
        }
        dv.Dispose();
        
    }

    private void FillDDlBranch()
    {
        clsBLBranch obj_br = new clsBLBranch();
        DataView dv = obj_br.GetAll(3);
        obj_br = null;
        if (dv.Count > 0)
        {
            SComponents obj_com = new SComponents();
            obj_com.FillDropDownList(ddlBranch, dv, "Name", "BranchID", true, false, true);
            obj_com = null;
        }
        else
        {
            ddlBranch.DataSource = "";
            ddlBranch.DataBind();
        }
        dv.Dispose();

    }
    private void FillGV()
    {
        clsBLbranchAlerts ob_Alerts = new clsBLbranchAlerts();

        if (ddlBranch.SelectedValue.ToString().Trim() != "-1")
        {
            ob_Alerts.BranchID = ddlBranch.SelectedValue.ToString().Trim();
        }
        DataView dv = ob_Alerts.GetAll(1);
        if (dv.Count > 0)
        {
            gvAlerts.DataSource = dv;
            gvAlerts.DataBind();
        }
        else
        {
            gvAlerts.DataSource = "";
            gvAlerts.DataBind();
        }
        dv.Dispose();
    }
    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "update")
        {
            Update();
        }
        else
        {
            Insert();
        }
    }
    private void Insert()
    {
        clsBLbranchAlerts obj_alert = new clsBLbranchAlerts();


        obj_alert.AlertID = ddlAlerts.SelectedValue.ToString().Trim();

        obj_alert.Active = chkActive.Checked == true ? "Y" : "N";
        obj_alert.BranchID = ddlBranch.SelectedValue.ToString().Trim();

        obj_alert.Rate = txtRate.Text.Trim();
        if (!txtExpiry.Text.Replace("__/__/____", "").Trim().Equals(""))
        {
            obj_alert.ExpiryDate = txtExpiry.Text.Trim();
        }



        obj_alert.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_alert.Enteredby = Session["PersonId"].ToString();
        obj_alert.ClientId = Session["orgid"].ToString();
        if (obj_alert.Insert())
        {
            FillGV();
            RefreshForm();
            lblErrMsg.Text = "<font color='green'>New Alert Type Added.</font>";
        }
        else
        {
            RefreshForm();
            lblErrMsg.Text = obj_alert.ErrorMessage;
        }
    }
    private void Update()
    {
        clsBLbranchAlerts obj_alert = new clsBLbranchAlerts();

        obj_alert.BranchAlertID = hdAlertTypeID.Value.ToString().Trim() ;
        obj_alert.AlertID = ddlAlerts.SelectedValue.ToString().Trim();

        obj_alert.Active = chkActive.Checked == true ? "Y" : "N";
        obj_alert.BranchID = ddlBranch.SelectedValue.ToString().Trim();

        obj_alert.Rate = txtRate.Text.Trim();
        if (!txtExpiry.Text.Replace("__/__/____", "").Trim().Equals(""))
        {
            obj_alert.ExpiryDate = txtExpiry.Text.Trim();
        }



        obj_alert.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_alert.Enteredby = Session["PersonId"].ToString();
        obj_alert.ClientId = Session["orgid"].ToString();
        if (obj_alert.Update())
        {
            FillGV();
            RefreshForm();
            lblErrMsg.Text = "<font color='green'>Branch Alert successfully altered.</font>";
        }
        else
        {
            RefreshForm();
            lblErrMsg.Text = obj_alert.ErrorMessage;
        }
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        lblErrMsg.Text = "";
        RefreshForm();
    }
    private void RefreshForm()
    {
        mode = "insert";
        txtExpiry.Text = "";

        txtRate.Text = "";

        ddlBranch.ClearSelection();
        ddlAlerts.ClearSelection();
        chkActive.Checked = true;
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void ddlBranch_SelectedindexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedValue.ToString() != "-1")
        {
            clsBLbranchAlerts obj_Alerts = new clsBLbranchAlerts();
            obj_Alerts.BranchID = ddlBranch.SelectedValue.ToString().Trim();
            FillGV();
        }
    }
    protected void gvAlerts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            hdAlertTypeID.Value = gvAlerts.DataKeys[index].Values[0].ToString();
            mode = "update";
            FillForm();
        }
    }

    private void FillForm()
    {
        clsBLbranchAlerts obj_Alerts = new clsBLbranchAlerts();
        obj_Alerts.BranchAlertID = hdAlertTypeID.Value.ToString();
        DataView dv = obj_Alerts.GetAll(1);
        if (dv.Count > 0)
        {
            ddlBranch.ClearSelection();
            try
            {
                ddlBranch.Items.FindByValue(dv[0]["BranchID"].ToString().Trim()).Selected = true;
            }
            catch
            {
            }
            ddlAlerts.ClearSelection();

            try
            {
                ddlAlerts.Items.FindByValue(dv[0]["AlertID"].ToString().Trim()).Selected = true;

            }
            catch { }
            chkActive.Checked = dv[0]["Active"].ToString().Trim() == "Y" ? true : false;
            txtRate.Text = dv[0]["Rate"].ToString().Trim();
            txtExpiry.Text = dv[0]["ExpiryDate"].ToString().Trim();


        }
        dv.Dispose();
    }
    protected void gvAlerts_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvAlerts_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}