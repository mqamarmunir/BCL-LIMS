using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

public partial class Parameter_wfrmBranchGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["PersonId"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "93";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {

                    //lblstatus.Text = "i";

                    //  FillDDLSubDepartment();
                    try
                    {
                        FillOrgDDL();
                        //FillGv();

                        FillGV();
                        Fillddlbranches();
                    }

                    catch(Exception ee)
                    {
                        Response.Write(ee.ToString());
                    }
                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
            }

        }
    }
    private void FillOrgDDL()
    {
        clsOrganization objOrg = new clsOrganization();
        SComponents objScom = new SComponents();
        objOrg.External = "N";
        objOrg.Main = "Y";
        DataView dv = objOrg.GetAll(4);
        objScom.FillDropDownList(ddlOrganiztions, dv, "Name", "OrgId", true, false, true);
        this.ddlOrganiztions.SelectedValue = "-1";
    }

    private void FillGV()
    {
        clsGroupM pn = new clsGroupM();
        //pn.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
        DataView dv = pn.GetAll(7);

        if (dv.Count > 0)
        {
            divpanels.Visible = true;
            gvGroups.DataSource = dv;
            gvGroups.DataBind();
        }
        else
        {
            divpanels.Visible = false;
            gvGroups.DataSource = null;
            gvGroups.DataBind();
        }
    }
    private void Fillddlbranches()
    {
        clsBLBranch obj_branch = new clsBLBranch();
        DataView dv_branches = obj_branch.GetAll(3);
        obj_branch = null;
        if (dv_branches.Count > 0)
        {
            SComponents obj_Com = new SComponents();
            obj_Com.FillDropDownList(ddlBranch, dv_branches, "Name", "BranchID", true, false, true);
            dv_branches.Dispose();
            ddlBranch.SelectedValue = "-1";
            obj_Com = null;
        }
        else
        {
            dv_branches.Dispose();
            lblErrMsg.Text = "No Branch Found";
        }
    }

    private void FillGv_Selected()
    {
        clsBLBranchGroups obj_brpanels = new clsBLBranchGroups();
        obj_brpanels.BranchID = ddlBranch.SelectedValue.ToString().Trim();
        DataView dv_panels = obj_brpanels.GetAll(1);
        if (dv_panels.Count > 0)
        {
            divSelected.Visible = true;
            gvSelected.DataSource = dv_panels;
            gvSelected.DataBind();
        }
        else
        {
            divSelected.Visible = false;
            gvSelected.DataSource = "";
            gvSelected.DataBind();
        }

    }
    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        RefreshForm();
        lblErrMsg.Text = "";



    }
    private void RefreshForm()
    {
        gvGroups.DataSource = "";
        gvGroups.DataBind();
        gvSelected.DataSource = "";
        gvSelected.DataBind();
        divpanels.Visible = false;
        divSelected.Visible = false;
        ddlBranch.ClearSelection();
        ddlOrganiztions.ClearSelection();
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void ddlOrganiztions_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGV();
        Fillddlbranches();
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGv_Selected();
    }
    protected void lnkAddSelected_Click(object sender, EventArgs e)
    {
        Insert("S");
    }

    private void Insert(string type)
    {
        clsBLBranchGroups obj_brpanels = new clsBLBranchGroups();
        obj_brpanels.BranchID = ddlBranch.SelectedValue.ToString().Trim();
        int count = 0;
        int countchecked = 0;
        if (type == "S")
        {
            foreach (GridViewRow row in gvGroups.Rows)
            {
                if (((CheckBox)gvGroups.Rows[row.RowIndex].Cells[3].FindControl("gvchkselect")).Checked == true)
                {
                    countchecked++;
                    obj_brpanels.GroupID = gvGroups.DataKeys[row.RowIndex].Value.ToString().Trim();
                    obj_brpanels.Active = "Y";
                    obj_brpanels.Enteredby = Session["PersonID"].ToString().Trim();

                    obj_brpanels.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_brpanels.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    // obj_brpanels.ClientId = ddlOrganiztions.SelectedItem.Value.ToString().Trim();
                    if (obj_brpanels.Insert())
                    {
                        count++;
                    }
                    else
                    {
                        lblErrMsg.Text += obj_brpanels.ErrorMessage + "<br />";
                    }
                }
            }
            if (count == countchecked && count != 0)
            {
                lblErrMsg.Text = "<font color='green'>All Records inserted Successfully.</font>";
                FillGv_Selected();
            }
            if (countchecked == 0)
            {
                lblErrMsg.Text = "No Panel Selected";
            }
        }
        else if (type == "A")
        {
            foreach (GridViewRow row in gvGroups.Rows)
            {


                obj_brpanels.GroupID = gvGroups.DataKeys[row.RowIndex].Value.ToString().Trim();
                obj_brpanels.Active = "Y";
                obj_brpanels.Enteredby = Session["PersonID"].ToString().Trim();
                obj_brpanels.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_brpanels.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                if (obj_brpanels.Insert())
                {
                    count++;
                }
                else
                {
                    lblErrMsg.Text += obj_brpanels.ErrorMessage + "<br />";
                }

            }
            if (count == gvGroups.Rows.Count)
            {
                lblErrMsg.Text = "<font color='green'>All Records inserted Successfully.</font>";
                FillGv_Selected();
            }

        }

    }
    protected void lnkAddAll_Click(object sender, EventArgs e)
    {
        Insert("A");
    }
    protected void lnkRemoveAll_Click(object sender, EventArgs e)
    {
        clsBLBranchGroups obj_brpanels = new clsBLBranchGroups();
        int count = 0;
        foreach (GridViewRow row in gvSelected.Rows)
        {

            obj_brpanels.BranchGroupID = gvSelected.DataKeys[row.RowIndex].Values[0].ToString().Trim();
            // obj_brpanels.PanelID = gvPanels.DataKeys[row.RowIndex].Value.ToString().Trim();
            obj_brpanels.BranchID = ddlBranch.SelectedValue.ToString().Trim();
            obj_brpanels.Active = "N";

            obj_brpanels.Enteredby = Session["PersonID"].ToString().Trim();
            obj_brpanels.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_brpanels.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
            //obj_brpanels.ClientId = ddlOrganiztions.SelectedItem.Value.ToString().Trim();
            if (obj_brpanels.Update())
            {
                count++;
            }
            else
            {
                lblErrMsg.Text += obj_brpanels.ErrorMessage + "<br />";
            }

        }
        if (count == gvGroups.Rows.Count)
        {
            lblErrMsg.Text = "<font color='green'>All Records inserted Successfully.</font>";
            FillGv_Selected();
        }
        else
        {
            FillGv_Selected();
        }
    }

    protected void gvSelected_RowDeletingClick(object sender, GridViewDeleteEventArgs e)
    {
        clsBLBranchGroups obj_brpanels = new clsBLBranchGroups();
        obj_brpanels.BranchGroupID = gvSelected.DataKeys[e.RowIndex].Values[0].ToString().Trim();
        obj_brpanels.BranchID = ddlBranch.SelectedValue.ToString().Trim();
        obj_brpanels.Active = "N";
        // obj_brpanels.ClientId = ddlOrganiztions.SelectedItem.Value.ToString().Trim();
        obj_brpanels.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
        obj_brpanels.Enteredby = Session["PersonID"].ToString().Trim();
        obj_brpanels.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        if (obj_brpanels.Update())
        {
            lblErrMsg.Text = "<font color='green'>Record Deleted.</font>";
            FillGv_Selected();
        }
        else
        {
            lblErrMsg.Text = obj_brpanels.ErrorMessage;
        }

    }
}