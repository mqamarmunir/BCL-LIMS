using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

public partial class Parameter_wfrmAlertTypes : System.Web.UI.Page
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
                    FillDDlProcess();

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

    private void FillDDlProcess()
    {
        clsBLProcess ob_pr = new clsBLProcess();
        ob_pr.Active = "Y";
        DataView dv = ob_pr.GetAll(1);
        ob_pr = null;
        if (dv.Count > 0)
        {
            SComponents obcom = new SComponents();
            obcom.FillDropDownList(ddlProcess, dv, "Name", "ProcessID", true, false, true);
            obcom = null;
        }
        else
        {
            ddlProcess.DataSource = "";
            ddlProcess.DataBind();

        }
        dv.Dispose();
    }
    private void FillGV()
    {
        clsBLAlerts ob_Alerts = new clsBLAlerts();

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
        clsBLAlerts obj_alert = new clsBLAlerts();
       
        
        obj_alert.Name = txtName.Text.Trim();

        obj_alert.Active = chkActive.Checked == true ? "Y" : "N";
        obj_alert.Description = txtDescription.Text.Trim();

        obj_alert.Type = ddlType.SelectedValue.ToString().Trim();
        obj_alert.ProcessID = ddlProcess.SelectedValue.ToString().Trim();

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
        clsBLAlerts obj_alert = new clsBLAlerts();
        obj_alert.AlertTypeID = hdAlertTypeID.Value.ToString();

        obj_alert.Name = txtName.Text.Trim();

        obj_alert.Active = chkActive.Checked == true ? "Y" : "N";
        obj_alert.Description = txtDescription.Text.Trim();
       
        obj_alert.Type = ddlType.SelectedValue.ToString().Trim();
        obj_alert.ProcessID = ddlProcess.SelectedValue.ToString().Trim();

        obj_alert.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_alert.Enteredby = Session["PersonId"].ToString();
        obj_alert.ClientId = Session["orgid"].ToString();
        if (obj_alert.Update())
        {
            FillGV();
            RefreshForm();
            lblErrMsg.Text = "<font color='green'>Alert Successfully Altered.</font>";
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
        txtDescription.Text = "";
        
        txtName.Text = "";
     
        ddlType.ClearSelection();
        chkActive.Checked = true;
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }


    protected void gvAlerts_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void gvAlerts_RowEditing(object sender, GridViewEditEventArgs e)
    {

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
        clsBLAlerts obj_Alerts = new clsBLAlerts();
        obj_Alerts.AlertTypeID = hdAlertTypeID.Value.ToString();
        DataView dv = obj_Alerts.GetAll(1);
        if (dv.Count > 0)
        {
            txtName.Text = dv[0]["Name"].ToString();
            txtDescription.Text = dv[0]["Description"].ToString().Trim();
            ddlType.ClearSelection();
            ddlType.Items.FindByValue(dv[0]["Type"].ToString()).Selected = true;

            ddlProcess.ClearSelection();
            try
            {
                ddlProcess.Items.FindByValue(dv[0]["ProcessID"].ToString().Trim());
            }
            catch
            { }
           
            chkActive.Checked = dv[0]["Active"].ToString() == "Y" ? true : false;

        }
        dv.Dispose();
    }
}