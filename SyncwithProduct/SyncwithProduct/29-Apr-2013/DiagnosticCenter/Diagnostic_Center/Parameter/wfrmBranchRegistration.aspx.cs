using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

public partial class _Default : System.Web.UI.Page
{
    private static string DGSort = "";
    private static string mode = "save";
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
                    DGSort = "";
                    //lblstatus.Text = "i";

                    FillOrgDDL();
                    FillCityDDL();
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
    private void FillOrgDDL()
    {
        clsOrganization objOrg = new clsOrganization();
        SComponents objScom = new SComponents();
        objOrg.External = "N";
        objOrg.Main = "Y";
        DataView dv = objOrg.GetAll(4);
        objScom.FillDropDownListWithoutSelect(ddlOrganiztions, dv, "Name", "OrgId", true, false);
        //this.ddlOrganiztions.SelectedValue = "-1";
    }
    private void FillCityDDL()
    {
        clsBLBranch obj_Branchcities = new clsBLBranch();
        DataView dv_brcities = obj_Branchcities.GetAll(6);
        if (dv_brcities.Count > 0)
        {
            SComponents objScom = new SComponents();
            objScom.FillDropDownList(ddlCity, dv_brcities, "Name", "CityID", true, false, true);
            dv_brcities.Dispose();
            objScom = null;
            this.ddlCity.SelectedValue = "-1";
        }
    }
    private void FillGV()
    {
        clsBLBranch obj_Branch = new clsBLBranch();
        obj_Branch.OrgId = ddlOrganiztions.SelectedValue.ToString();
        DataView dv_Branches = obj_Branch.GetAll(1);
        if (dv_Branches.Count > 0)
        {
            gvBranches.DataSource = dv_Branches;
            gvBranches.DataBind();
        }
        else
        {
            gvBranches.DataSource = "";
            gvBranches.DataBind();
        }
        dv_Branches.Dispose();
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
        clsBLBranch obj_Br = new clsBLBranch();
        if (ddlOrganiztions.SelectedValue.ToString().Trim() != "-1")
        {
            obj_Br.OrgId = Session["orgid"].ToString().Trim();
        }
        obj_Br.OrgId = ddlOrganiztions.SelectedValue.ToString().Trim();

        obj_Br.Name = txtName.Text.Trim();
        obj_Br.Acronym = txtAcronym.Text.Trim();
        obj_Br.Active = chkActive.Checked == true ? "Y" : "N";
        obj_Br.PhoneNo = txtPhone.Text.Trim();
        obj_Br.FaxNo = txtFax.Text.Trim();
        obj_Br.Address = txtAddress.Text.Trim();
        obj_Br.City = ddlCity.SelectedValue.ToString().Trim();
        obj_Br.Type = ddlType.SelectedValue.ToString().Trim();
        obj_Br.ReportText = txtReportText.Text.Trim();
        obj_Br.Extension = txtExtension.Text.Trim();
        obj_Br.PrintReportText = chkPrintText.Checked == true ? "Y" : "N";
        obj_Br.IndoorFacility = chkIndoor.Checked == true ? "Y" : "N";
        if (txtBrCode.Text.Trim().Replace("_", "").Length == 3)
        {

            obj_Br.BranchCode = txtBrCode.Text.Trim();
        }
        else
        {
            lblErrMsg.Text = "Please Correct Branch code";

            return;
        }
        obj_Br.Minimumcashcollection_booking = txtCashCollection.Text.Trim();
        if (chk24Hrs.Checked == false)
        {
            obj_Br.__24HrsService = "N";
            if (!txtstartTiming.Text.Replace("__:__", "").Trim().Equals("") && !txtstartTiming.Text.Replace("__:__", "").Trim().Equals("&nbsp;"))
            {
                obj_Br.StartTime = txtstartTiming.Text.Trim();
            }
            if (!txtEndTiming.Text.Replace("__:__", "").Trim().Equals("") && !txtEndTiming.Text.Replace("__:__", "").Trim().Equals("&nbsp;"))
            {
                obj_Br.EndTime = txtEndTiming.Text.Trim();
            }
        }
        else
        {
            obj_Br.__24HrsService = "Y";
        }

        if (obj_Br.Type == "S")
        {
            obj_Br.BusinessPolicy = ddlbpolicy.SelectedValue.ToString().Trim();
            if (ddlbpolicy.SelectedValue.ToString().Trim() == "N")
            {
                obj_Br.Percentage = txtPercentage.Text.Trim();
            }
        }
        obj_Br.Dplan_InternalTests = chkDplan.Checked == true ? "Y" : "N";

        obj_Br.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_Br.Enteredby = Session["PersonId"].ToString();
        obj_Br.ClientId = Session["orgid"].ToString();
        if (obj_Br.Insert())
        {
            //////////////////------Creating user ID for this branch------//////////////
            clsPersonnel obj_personnel = new clsPersonnel();
            obj_personnel.Acronym = "br" + txtName.Text.Substring(0, 3) + obj_Br.GetAll(5)[0]["MaxID"].ToString();
            obj_personnel.Active = "Y";
            obj_personnel.BranchID = obj_Br.GetAll(5)[0]["MaxID"].ToString();
            obj_personnel.ClientId = Session["orgid"].ToString();
            obj_personnel.ConfirmPasword = "br" + ddlCity.SelectedItem.Text.Trim();
            obj_personnel.CrossDept = "Y";
            obj_personnel.CrossLab = "Y";
            obj_personnel.DepartmentId = "3";
            obj_personnel.DesignationId = "1";
            obj_personnel.DOB = System.DateTime.Now.ToString("dd/MM/yyyy");
            obj_personnel.Enteredby = Session["personid"].ToString();
            obj_personnel.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_personnel.FName = txtName.Text;
            obj_personnel.LoginId = "br" + txtAcronym.Text + ddlType.SelectedValue.ToString() ;
            obj_personnel.Pasword = "br" + ddlCity.SelectedItem.Text.Trim();
            obj_personnel.Salutation = "Mr.";
            obj_personnel.SubdepartmentId = "13";
            obj_personnel.FHName = "Branch";
            obj_personnel.Sex = "M";
            obj_personnel.MS = "S";
            obj_personnel.Nature = "P";
            obj_personnel.Email = "dummy@email.com";
            //obj_personnel.ContractExpiry = "N";
            obj_personnel.OrgId = Session["orgid"].ToString();
          
            if (obj_personnel.Insert())
            {
                clsBLUserRight u_right = new clsBLUserRight();
                u_right.Active = "Y";
                u_right.ClientID = Session["orgid"].ToString();
                u_right.DefaultPage = "5";
                u_right.EnteredBy = Session["personid"].ToString().Trim();
                u_right.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                u_right.GroupID = "18";
                u_right.PersonID = obj_personnel.GetAll(7)[0]["MaxID"].ToString().Trim();
                if (u_right.Insert())
                {

                    FillGV();
                    
                    lblErrMsg.Text = "<font color='green'>Record Inserted Successfully.</font><br />LoginID:" + "br" + txtAcronym.Text + ddlType.SelectedValue.ToString() + "<br />Password:" + "br" + ddlCity.SelectedItem.Text + "<br />BranchID:" + obj_Br.GetAll(5)[0]["MaxID"].ToString();
                    RefreshForm();
                }
            }



            //////////////////////////////-----------------////////////////////////////


        }
        else
        {
            lblErrMsg.Text = obj_Br.ErrorMessage;
        }
    }
    private void Update()
    {
        clsBLBranch obj_Br = new clsBLBranch();
        obj_Br.BranchID = hdBranchID.Value.ToString();
        if (ddlOrganiztions.SelectedValue.ToString().Trim() == "-1")
        {
            obj_Br.OrgId = Session["orgid"].ToString().Trim();
        }
        else
        {
            obj_Br.OrgId = ddlOrganiztions.SelectedValue.ToString().Trim();
        }
        obj_Br.Name = txtName.Text.Trim();
        obj_Br.Acronym = txtAcronym.Text.Trim();
        obj_Br.Active = chkActive.Checked == true ? "Y" : "N";
        obj_Br.PhoneNo = txtPhone.Text.Trim();
        obj_Br.FaxNo = txtFax.Text.Trim();
        obj_Br.Address = txtAddress.Text.Trim();
        obj_Br.City = ddlCity.SelectedValue.ToString().Trim();
        obj_Br.Type = ddlType.SelectedValue.ToString().Trim();
        obj_Br.ReportText = txtReportText.Text.Trim();
        obj_Br.Extension = txtExtension.Text.Trim();

        obj_Br.PrintReportText = chkPrintText.Checked == true ? "Y" : "N";
        obj_Br.IndoorFacility = chkIndoor.Checked == true ? "Y" : "N";
        if (txtBrCode.Text.Trim().Replace("_", "").Length == 3)
        {

            obj_Br.BranchCode = txtBrCode.Text.Trim();
        }
        else
        {
            lblErrMsg.Text="Please Correct Branch code";

            return;
        }
        obj_Br.Minimumcashcollection_booking = txtCashCollection.Text.Trim();
        if (chk24Hrs.Checked == false)
        {
            obj_Br.__24HrsService = "N";
            if (!txtstartTiming.Text.Replace("__:__", "").Trim().Equals("") && !txtstartTiming.Text.Replace("__:__", "").Trim().Equals("&nbsp;"))
            {
                obj_Br.StartTime = txtstartTiming.Text.Trim();
            }
            if (!txtEndTiming.Text.Replace("__:__", "").Trim().Equals("") && !txtEndTiming.Text.Replace("__:__", "").Trim().Equals("&nbsp;"))
            {
                obj_Br.EndTime = txtEndTiming.Text.Trim();
            }
        }
        else
        {
            obj_Br.__24HrsService = "Y";
        }
        if (obj_Br.Type == "S")
        {
            obj_Br.BusinessPolicy = ddlbpolicy.SelectedValue.ToString().Trim();
            if (ddlbpolicy.SelectedValue.ToString().Trim() == "N")
            {
                obj_Br.Percentage = txtPercentage.Text.Trim();
            }
        }
        obj_Br.Dplan_InternalTests = chkDplan.Checked == true ? "Y" : "N";
        
        obj_Br.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_Br.Enteredby = Session["PersonId"].ToString();
        obj_Br.ClientId = Session["orgid"].ToString();
        if (obj_Br.Update())
        {
            FillGV();
            RefreshForm();
            lblErrMsg.Text = "<font color='green'>Record Updated Successfully.</font>";
        }
        else
        {
            RefreshForm();
            lblErrMsg.Text = obj_Br.ErrorMessage;
        }
    }


    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        lblErrMsg.Text = "";
        RefreshForm();
    }

    private void RefreshForm()
    {
        mode = "save";
        txtAcronym.Text = "";
        txtAddress.Text = "";
        txtFax.Text = "";
        txtName.Text = "";
        txtPercentage.Text = "";
        txtPhone.Text = "";
        ddlCity.ClearSelection();
        ddlType.ClearSelection();
        ddlbpolicy.ClearSelection();
        pnlpercent.Visible = false;
        txtReportText.Text = "";
        updtebranchTimings.Visible = false;
        txtstartTiming.Text = "";
        txtEndTiming.Text = "";
        txtExtension.Text = "";
        chk24Hrs.Checked = true;
        chkIndoor.Checked = false;
        txtBrCode.Text = "";
        txtCashCollection.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["OrgId2"].Equals(""))
        {
            Response.Redirect("Organization.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }

    protected void gvBranches_RowEditing(object sender, GridViewEditEventArgs e)//reference Department.aspx.cs
    {
        hdBranchID.Value = gvBranches.DataKeys[e.NewEditIndex].Values[0].ToString();
        mode = "update";
        FillForm();

    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedValue.ToString().Trim() == "S")
        {
            pnlpercent.Visible = true;
        }
        else
        {
            pnlpercent.Visible = false;
        }
    }

    protected void ddlOrganiztions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOrganiztions.SelectedValue.ToString() != "-1")
        {
            FillGV();
        }
    }

    private void FillForm()
    {
        clsBLBranch obj_branch = new clsBLBranch();
        obj_branch.BranchID = hdBranchID.Value.ToString();
        DataView dv_Branchdetails = obj_branch.GetAll(2);
        if (dv_Branchdetails.Count > 0)
        {
            ddlOrganiztions.ClearSelection();
            ddlOrganiztions.Items.FindByValue(dv_Branchdetails[0]["ParentID"].ToString()).Selected = true;

            txtName.Text = dv_Branchdetails[0]["Name"].ToString();
            txtAcronym.Text = dv_Branchdetails[0]["Acronym"].ToString();
            txtPhone.Text = dv_Branchdetails[0]["PhoneNo"].ToString();
            txtFax.Text = dv_Branchdetails[0]["FaxNo"].ToString();
            txtAddress.Text = dv_Branchdetails[0]["StreetAddress"].ToString();
            txtReportText.Text = dv_Branchdetails[0]["Report_Text"].ToString().Trim();
            txtBrCode.Text = dv_Branchdetails[0]["BranchCode"].ToString().Trim();
            txtExtension.Text = dv_Branchdetails[0]["Extension"].ToString().Trim();
            chkPrintText.Checked = dv_Branchdetails[0]["PrintReportText"].ToString().Trim() == "Y" ? true : false;
            chk24Hrs.Checked = dv_Branchdetails[0]["24HrsService"].ToString().Trim() == "Y" ? true : false;
            chkDplan.Checked = dv_Branchdetails[0]["Dplan_InternalTests"].ToString().Trim() == "Y" ? true : false;
            chkIndoor.Checked = dv_Branchdetails[0]["Indoor_facility"].ToString().Trim() == "Y" ? true : false;
            txtCashCollection.Text = dv_Branchdetails[0]["minimumcashcollection_booking"].ToString().Trim();
            if (dv_Branchdetails[0]["24HrsService"].ToString().Trim() == "N")
            {
                updtebranchTimings.Visible = true;
                txtstartTiming.Text = dv_Branchdetails[0]["StartTime"].ToString().Trim();
                txtEndTiming.Text = dv_Branchdetails[0]["EndTime"].ToString().Trim();
            }
            else
            {
                updtebranchTimings.Visible = false;
            }
            ddlCity.ClearSelection();
            try
            {
                ddlCity.Items.FindByValue(dv_Branchdetails[0]["City"].ToString()).Selected = true;
            }
            catch
            { }
            ddlType.ClearSelection();
            ddlType.Items.FindByValue(dv_Branchdetails[0]["Type"].ToString()).Selected = true;
            if (ddlType.SelectedValue.ToString() == "S")
            {
                pnlpercent.Visible = true;
                ddlbpolicy.ClearSelection();
                try
                {
                    ddlbpolicy.Items.FindByValue(dv_Branchdetails[0]["BusinessPolicy"].ToString().Trim()).Selected = true;
                }
                catch { }
                if (ddlbpolicy.SelectedValue.ToString().Trim() == "N")
                {
                    pnlbpolicy.Visible = true;
                    txtPercentage.Text = dv_Branchdetails[0]["Percentage_Share"].ToString().Trim();
                }
//                txtPercentage.Text = dv_Branchdetails[0]["Percentage_Share"].ToString();
            }
            else
            {
                pnlpercent.Visible = false;
            }
            chkActive.Checked = dv_Branchdetails[0]["Active"].ToString() == "Y" ? true : false;

        }
    }
    protected void ddlbpolicy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlbpolicy.SelectedValue.ToString().Trim() == "N")
        {
            pnlbpolicy.Visible = true;
        }
        else
        {
            pnlbpolicy.Visible = false;
        }

    }

    protected void gvBranches_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            hdBranchID.Value = gvBranches.DataKeys[index].Values[0].ToString();
            mode = "update";
            FillForm();
        }
    }

    protected void chk24Hrs_CheckedChanged(object sender, EventArgs e)
    {
        if (chk24Hrs.Checked == false)
        {
            updtebranchTimings.Visible = true;

        }
        else
        {
            updtebranchTimings.Visible = false;
        }
    }
}