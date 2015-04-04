using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessLayer;

public partial class Department : System.Web.UI.Page
{
    private static string DGSort = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["PersonId"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "3";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblDepartmentId.Text = "";
                    FillOrgDDL();
                    if (!Session["OrgId2"].Equals(""))
                    {
                        this.ddlOrganization.SelectedValue = Session["OrgId2"].ToString();
                    }
                    //         FillPersonDDL();

                    if (!Session["DepartmentId"].Equals(""))
                    {
                        lblErrMsg.Text = "";
                        lblstatus.Text = "u";
                        clsDepartment objDC = new clsDepartment();
                        lblDepartmentId.Text = objDC.DepartmentId = Session["DepartmentId"].ToString();
                        DataView dv = objDC.GetAll(3);
                        if (dv.Count > 0)
                        {
                            this.txtName.Text = dv[0]["Name"].ToString();
                            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                            this.txtPhoneNo.Text = dv[0]["PhoneNo"].ToString();
                            this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
                            this.txtEmail.Text = dv[0]["Email"].ToString();
                            if (!dv[0]["OrgId"].ToString().Equals(""))
                            {
                                this.ddlOrganization.SelectedValue = dv[0]["OrgId"].ToString();
                            }

                            FillPersonDDL();

                            if (!dv[0]["HOD"].ToString().Equals("") && !dv[0]["HOD"].ToString().Equals("0"))
                            {
                                this.ddlPerson.SelectedValue = dv[0]["HOD"].ToString();
                            }
                            if (dv[0]["Type"].ToString().Equals("A"))
                            {
                                this.rbtnAdmin.Checked = true;
                            }
                            else
                            {
                                if (dv[0]["Type"].ToString().Equals("S"))
                                {
                                    this.rbtnService.Checked = true;
                                }
                            }
                            this.txtAddress.Text = dv[0]["Address"].ToString();
                            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                        }
                    }
                    else
                    {
                        FillPersonDDL();
                    }
                    Session["DepartmentId"] = "";
                    Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlOrganization.Focus();
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
        DataView dv = objOrg.GetAll(4);
        objScom.FillDropDownList(ddlOrganization, dv, "Name", "OrgId", true, false, true);
        this.ddlOrganization.SelectedValue = "-1";
    }
    private void FillPersonDDL()
    {
        clsPersonnel objPer = new clsPersonnel();
        SComponents objScom = new SComponents();
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        DataView dv = objPer.GetAll(4);
        objScom.FillDropDownList(ddlPerson, dv, "Name", "PersonId", true, false, true);
        this.ddlPerson.SelectedValue = "-1";
    }

    private void Fillgv()
    {
        clsDepartment objDC = new clsDepartment();        
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }        
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvDepartment.DataSource = dv;
            gvDepartment.DataBind();
            gvDepartment.Visible = true;
        }
        else
        {
            gvDepartment.Visible = false;
        }
    }
    private void Insert()
    {
        clsDepartment objDC = new clsDepartment();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.PhoneNo = txtPhoneNo.Text.Trim();
        objDC.FaxNo = txtFaxNo.Text.Trim();
        objDC.Email = txtEmail.Text.Trim();
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        if (!this.ddlPerson.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.HOD = this.ddlPerson.SelectedItem.Value.ToString();
        }

        if (this.rbtnAdmin.Checked)
        {
            objDC.Type = "A";
        }
        else if (this.rbtnService.Checked)
        {
            objDC.Type = "S";            
        }
        objDC.Address = txtAddress.Text.Trim();
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Insert())
        {
            lblDepartmentId.Text = objDC.DepartmentId.ToString();
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record save successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objDC.ErrorMessage;
        }
    }

    private void Update()
    {
        clsDepartment objDC = new clsDepartment();
        objDC.DepartmentId = lblDepartmentId.Text.Trim();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.PhoneNo = txtPhoneNo.Text.Trim();
        objDC.FaxNo = txtFaxNo.Text.Trim();
        objDC.Email = txtEmail.Text.Trim();
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        if (!this.ddlPerson.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.HOD = this.ddlPerson.SelectedItem.Value.ToString();
        }
        else
        {
            objDC.HOD = "0";
        }

        if (this.rbtnAdmin.Checked)
        {
            objDC.Type = "A";
        }
        else if (this.rbtnService.Checked)
        {
            objDC.Type = "S";
        }
        objDC.Address = txtAddress.Text.Trim();
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Update())
        {
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Update successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objDC.ErrorMessage;
        }
    }

    private void Clear()
    {
        txtName.Text = "";
        txtAcronym.Text = "";
        txtPhoneNo.Text = "";
        txtFaxNo.Text = "";
        txtEmail.Text = "";
        this.ddlOrganization.SelectedValue = "-1";
        this.rbtnAdmin.Checked = true;
        this.rbtnService.Checked = false;
        txtAddress.Text = "";
        chkActive.Checked = true;
        lblErrMsg.Text = "";
        FillPersonDDL();
        Fillgv();
        lblstatus.Text = "i";
    }

    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.txtName.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblDepartmentId.Text = "";
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
    protected void gvDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDepartment.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvDepartment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlOrganization.SelectedValue = "-1";   
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsDepartment objDC = new clsDepartment();
        lblDepartmentId.Text = objDC.DepartmentId = gvDepartment.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtName.Text = dv[0]["Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtPhoneNo.Text = dv[0]["PhoneNo"].ToString();
            this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
            this.txtEmail.Text = dv[0]["Email"].ToString();
            try
            {
                this.ddlOrganization.SelectedItem.Selected = false;
                this.ddlOrganization.Items.FindByValue(dv[0]["OrgId"].ToString()).Selected = true;
            }
            catch { }
            FillPersonDDL();

            if (!dv[0]["HOD"].ToString().Equals("") && !dv[0]["HOD"].ToString().Equals("0"))           
            {
                this.ddlPerson.SelectedValue = dv[0]["HOD"].ToString();
            }
            if (dv[0]["Type"].ToString().Equals("A"))
            {
                this.rbtnAdmin.Checked = true;
            }
            else
            {
                if (dv[0]["Type"].ToString().Equals("S"))
                {
                    this.rbtnService.Checked = true;
                }
            }
            this.txtAddress.Text = dv[0]["Address"].ToString();
            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
        }
    }

    protected void gvDepartment_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("NAME"))
        {
            if (DGSort == "NAME ASC")
                DGSort = "NAME DESC";
            else
                DGSort = "NAME ASC";

        }

        Fillgv();
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPersonDDL();
        Fillgv();
    }
    protected void lbtnSaveNext_Click(object sender, EventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();

        if (lblErrMsg.ForeColor.Equals(System.Drawing.Color.Green))
        {
            Session["DepartmentId"] = lblDepartmentId.Text.Trim();
            Response.Redirect("SubDepartment.aspx");
        }
    }

    protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            this.ddlOrganization.SelectedValue = "-1";
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsDepartment objDC = new clsDepartment();
            lblDepartmentId.Text = objDC.DepartmentId = gvDepartment.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtName.Text = dv[0]["Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtPhoneNo.Text = dv[0]["PhoneNo"].ToString();
                this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
                this.txtEmail.Text = dv[0]["Email"].ToString();
                try
                {
                    this.ddlOrganization.SelectedItem.Selected = false;
                    this.ddlOrganization.Items.FindByValue(dv[0]["OrgId"].ToString()).Selected = true;
                }
                catch { }
                FillPersonDDL();
                try
                {
                    if (!dv[0]["HOD"].ToString().Equals("") && !dv[0]["HOD"].ToString().Equals("0"))
                    {
                        this.ddlPerson.SelectedValue = dv[0]["HOD"].ToString();
                    }
                }
                catch { }
                if (dv[0]["Type"].ToString().Equals("A"))
                {
                    this.rbtnAdmin.Checked = true;
                }
                else
                {
                    if (dv[0]["Type"].ToString().Equals("S"))
                    {
                        this.rbtnService.Checked = true;
                    }
                }
                this.txtAddress.Text = dv[0]["Address"].ToString();
                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            }
        }
    }
}
