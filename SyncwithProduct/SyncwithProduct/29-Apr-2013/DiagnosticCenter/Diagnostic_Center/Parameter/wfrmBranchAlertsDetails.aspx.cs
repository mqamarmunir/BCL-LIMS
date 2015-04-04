using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

public partial class Parameter_wfrmBranchAlertsDetails : System.Web.UI.Page
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
                    FillDDlBranchAlerts();
                    //FillDDlAlerts();
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

    private void FillDDlBranchAlerts()
    {
        clsBLbranchAlerts obj_alerts = new clsBLbranchAlerts();
        obj_alerts.BranchID = Session["BranchID"].ToString().Trim();
        obj_alerts.Active="Y";
        DataView dv = obj_alerts.GetAll(1);
        obj_alerts = null;
        if (dv.Count > 0)
        {
            SComponents obcom = new SComponents();
            obcom.FillDropDownList(ddlBranchAlert, dv, "DetailedName", "BranchAlertID", true, false, true);
            obcom = null;
        }
        else
        {
            ddlBranchAlert.DataSource = "";
            ddlBranchAlert.DataBind();
        }
        dv.Dispose();
    }
    private void FillGV()
    {
        clsBLBranchAlertsD ob_Alerts = new clsBLBranchAlertsD();

        ob_Alerts.BranchID = Session["BranchID"].ToString().Trim();
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
        clsBLBranchAlertsD obj_alert = new clsBLBranchAlertsD();




        obj_alert.BranchAlertID = ddlBranchAlert.SelectedValue.ToString().Trim();
        obj_alert.Active = chkActive.Checked == true ? "Y" : "N";
        if (ddlBranchAlert.SelectedItem.Text.Contains("SMS"))
        {
            obj_alert.header = txtheadersms.Text;
            obj_alert.footer = txtfootersms.Text;
            obj_alert.Type = "S";
        }
        else
        {
            obj_alert.Subject = txtSubjectE.Text;
            obj_alert.header = txtheaderE.Text;
            obj_alert.footer = txtfooterE.Text;
            obj_alert.Type = "E";
        }
        obj_alert.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_alert.Enteredby = Session["PersonId"].ToString();
        obj_alert.ClientId = Session["orgid"].ToString();
        if (obj_alert.Insert())
        {
            FillGV();
            RefreshForm();
            lblErrMsg.Text = "<font color='green'>Alert Configured Successfully.</font>";
        }
        else
        {
            RefreshForm();
            lblErrMsg.Text = obj_alert.ErrorMessage;
        }
    }
    private void Update()
    {
        clsBLBranchAlertsD obj_alert = new clsBLBranchAlertsD();



        obj_alert.branchAlertDid = hdAlertTypeID.Value.ToString().Trim();
        obj_alert.BranchAlertID = ddlBranchAlert.SelectedValue.ToString().Trim();
        obj_alert.Active = chkActive.Checked == true ? "Y" : "N";
        if (ddlBranchAlert.SelectedItem.Text.Contains("SMS"))
        {
            obj_alert.header = txtheadersms.Text;
            obj_alert.footer = txtfootersms.Text;
            obj_alert.Type = "S";

        }
        else
        {
            obj_alert.Subject = txtSubjectE.Text;
            obj_alert.header = txtheaderE.Text;
            obj_alert.footer = txtfooterE.Text;
            obj_alert.Type = "E";
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
        txtheaderE.Text = "";

        txtheadersms.Text = "";
        txtfooterE.Text = "";
        txtfootersms.Text = "";
        txtSubjectE.Text = "";

        fssms.Visible = false;
        fsEmail.Visible = false;

        ddlBranchAlert.ClearSelection();
       // ddlAlerts.ClearSelection();
        chkActive.Checked = true;
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
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
        clsBLBranchAlertsD obj_Alerts = new clsBLBranchAlertsD();
        obj_Alerts.branchAlertDid = hdAlertTypeID.Value.ToString();
        DataView dv = obj_Alerts.GetAll(1);
        if (dv.Count > 0)
        {
            ddlBranchAlert.ClearSelection();
            try
            {
                ddlBranchAlert.Items.FindByValue(dv[0]["BranchAlertID"].ToString().Trim()).Selected = true;
            }
            catch
            { }
            
            
            chkActive.Checked = dv[0]["Active"].ToString().Trim() == "Y" ? true : false;
            if (dv[0]["Type"].ToString().Trim() == "E")
            {
                fsEmail.Visible = true;
                fssms.Visible = false;
                txtSubjectE.Text = dv[0]["Subject"].ToString().Trim();
                txtheaderE.Text = dv[0]["Header"].ToString().Trim();
                txtfooterE.Text = dv[0]["footer"].ToString().Trim();
            }
            else if (dv[0]["Type"].ToString().Trim() == "S")
            {
                fsEmail.Visible = false;
                fssms.Visible = true;
                //txtSubjectE.Text = dv[0]["Subject"].ToString().Trim();
                txtheadersms.Text = dv[0]["Header"].ToString().Trim();
                txtfootersms.Text = dv[0]["footer"].ToString().Trim();
 
            }

            //txtRate.Text = dv[0]["Rate"].ToString().Trim();
            //txtExpiry.Text = dv[0]["ExpiryDate"].ToString().Trim();


        }
        dv.Dispose();
    }
    protected void gvAlerts_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvAlerts_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void ddlBranchAlert_SelectedindexChanged(object sender, EventArgs e)
    {
        if (ddlBranchAlert.SelectedItem.Text.Contains("SMS"))
        {
            fssms.Visible = true;
            fsEmail.Visible = false;

        }
        else
        {
            fssms.Visible = false;
            fsEmail.Visible = true;
        }
    }
}