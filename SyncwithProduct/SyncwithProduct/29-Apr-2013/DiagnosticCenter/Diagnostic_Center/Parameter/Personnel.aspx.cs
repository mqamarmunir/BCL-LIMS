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

public partial class Personnel : System.Web.UI.Page
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
                log.OptionId = "5";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblPersonId.Text = "";
                    FillOrgDDL();
                    FillDeptDDL();
                   // FillSubDeptDDL();
                    FillDesigDDL();
                    Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlSalutation.Focus();
                    ddlOrganization.ClearSelection();
                    try
                    {
                        ddlOrganization.Items.FindByValue(System.Configuration.ConfigurationManager.AppSettings["ClientiD"].ToString().Trim()).Selected = true;
                    }
                    catch { }
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
    private void FillDeptDDL()
    {
        clsDepartment objDept = new clsDepartment();
        SComponents objScom = new SComponents();
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDept.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        DataView dv = objDept.GetAll(4);
        objScom.FillDropDownList(ddlDepartment, dv, "Name", "DepartmentId", true, false, true);
        this.ddlDepartment.SelectedValue = "-1";
    }

    private void FillSubDeptDDL()
    {
        clsSubDepartment objDept = new clsSubDepartment();
        SComponents objScom = new SComponents();
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDept.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        DataView dv = objDept.GetAll(4);
        objScom.FillDropDownList(ddlSubDepartment, dv, "Name", "SubDepartmentId", true, false, true);
        this.ddlSubDepartment.SelectedValue = "-1";
    }
    private void FillDesigDDL()
    {
        clsDesignation objDes = new clsDesignation();
        SComponents objScom = new SComponents();
        DataView dv = objDes.GetAll(4);
        objScom.FillDropDownList(ddlDesignation, dv, "Name", "DesignationId", true, false, true);
        this.ddlDesignation.SelectedValue = "-1";
    }

    private void Fillgv()
    {
        clsPersonnel objPer = new clsPersonnel();
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlSubDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlDesignation.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.DesignationId = this.ddlDesignation.SelectedItem.Value.ToString();
        }

        objPer.BranchID = Session["BranchID"].ToString();
        DataView dv = objPer.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvPersonnel.DataSource = dv;
            gvPersonnel.DataBind();
            gvPersonnel.Visible = true;
        }
        else
        {
            gvPersonnel.Visible = false;
        }
    }
    private void Insert()
    {
        clsPersonnel objPer = new clsPersonnel();
        objPer.FName = txtFName.Text.Trim();
        objPer.MName = txtMName.Text.Trim();
        objPer.LName = txtLName.Text.Trim();
        objPer.Acronym = txtAcronym.Text.Trim();
        objPer.FHName = txtFHName.Text.Trim();
        if (txtDOB.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtDOB.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.DOB = txtDOB.Text.Trim();
        }
        objPer.NIC = txtNICNo.Text.Trim();
        if (txtNICValidUpto.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtNICValidUpto.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.NICValidUpto = txtNICValidUpto.Text.Trim();
        }
        objPer.Passport = txtPassport.Text.Trim();
        if (txtPassportValidUpto.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtPassportValidUpto.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.PassportValidUpto = txtPassportValidUpto.Text.Trim();
        }
        objPer.ServiceNo = txtServiceNo.Text.Trim();
        objPer.ReferenceCode = txtReferenceCode.Text.Trim();
        if (txtJoiningDate.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtJoiningDate.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.JoiningDate = txtJoiningDate.Text.Trim();
        }
        if (txtRetiringDate.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtRetiringDate.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.LeavingDate = txtRetiringDate.Text.Trim();
        }
        objPer.Education = txtEducation.Text.Trim();
        if (this.rdPermanent.Checked)
        {
            objPer.Nature = "P";
        }
        else if (this.rdContract.Checked)
        {
            objPer.Nature = "C";
            if (txtContractExpiry.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtContractExpiry.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
            {
                objPer.ContractExpiry = this.txtContractExpiry.Text.Trim();
            }
        }

        if (!this.txtSalary.Text.Trim().ToString().Equals(""))
        {
            objPer.Salary = txtSalary.Text.Trim();
        }
        else
        {
            objPer.Salary = "0";
        }

        objPer.HPhoneNo1 = txtHPhone1.Text.Trim();
        objPer.HPhoneNo2 = txtHPhone2.Text.Trim();
        objPer.OPhoneNo1 = txtOPhone1.Text.Trim();
        objPer.OPhoneNo2 = txtOPhone2.Text.Trim();
        objPer.CPhoneNo = txtCPhone.Text.Trim();
        objPer.FaxNo = txtFaxNo.Text.Trim();
        objPer.Email = txtEmail.Text.Trim();
        objPer.CurrentAddress = txtCurrentAddress.Text.Trim();
        objPer.PermanentAddress = txtPermanentddress.Text.Trim();
        objPer.LoginId = txtLoginID.Text.Trim();
        objPer.Pasword = txtPassword.Text.Trim();
        objPer.ConfirmPasword = this.txtConfirmPassword.Text.Trim();

        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlSubDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlDesignation.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.DesignationId = this.ddlDesignation.SelectedItem.Value.ToString();
        }
        if (!this.ddlSalutation.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.Salutation = this.ddlSalutation.SelectedItem.Value.ToString();
        }
        if (!this.ddlSex.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.Sex = this.ddlSex.SelectedItem.Value.ToString();
        }
        if (!this.ddlBloodGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.BloodGroup = this.ddlBloodGroup.SelectedItem.Value.ToString();
        }

        if (!this.ddlMaritalStatus.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.MS = this.ddlMaritalStatus.SelectedItem.Value.ToString();
        }

        objPer.Active = chkActive.Checked ? "Y" : "N";
        objPer.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objPer.Enteredby = Session["PersonId"].ToString();
        objPer.ClientId = System.Configuration.ConfigurationManager.AppSettings["ClientID"].ToString().Trim(); // org
        objPer.CrossDept = this.chkcros_Dept.Checked ? "Y" : "N";
        objPer.CrossLab = this.chkCrossLab.Checked ? "Y" : "N";
        objPer.BranchID = Session["BranchID"].ToString().Trim();

        if (objPer.Insert())
        {
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record save successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objPer.ErrorMessage;
        }
    }
    private void Update()
    {
        clsPersonnel objPer = new clsPersonnel();
        objPer.PersonId = lblPersonId.Text.Trim();

        objPer.FName = txtFName.Text.Trim();
        objPer.MName = txtMName.Text.Trim();
        objPer.LName = txtLName.Text.Trim();
        objPer.Acronym = txtAcronym.Text.Trim();
        objPer.FHName = txtFHName.Text.Trim();
        if (txtDOB.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtDOB.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.DOB = txtDOB.Text.Trim();
        }
        objPer.NIC = txtNICNo.Text.Trim();
        if (txtNICValidUpto.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtNICValidUpto.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.NICValidUpto = txtNICValidUpto.Text.Trim();
        }
        objPer.Passport = txtPassport.Text.Trim();
        if (txtPassportValidUpto.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtPassportValidUpto.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.PassportValidUpto = txtPassportValidUpto.Text.Trim();
        }
        objPer.ServiceNo = txtServiceNo.Text.Trim();
        objPer.ReferenceCode = txtReferenceCode.Text.Trim();
        if (txtJoiningDate.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtJoiningDate.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.JoiningDate = txtJoiningDate.Text.Trim();
        }
        if (txtRetiringDate.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtRetiringDate.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
        {
            objPer.LeavingDate = txtRetiringDate.Text.Trim();
        }
        objPer.Education = txtEducation.Text.Trim();

        if (this.rdPermanent.Checked)
        {
            objPer.Nature = "P";
        }
        else if (this.rdContract.Checked)
        {
            objPer.Nature = "C";
            if (txtContractExpiry.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length > 0 && txtContractExpiry.Text.Replace("/", "").Replace("_", "").Replace(" ", "").Length == 8)
            {
                objPer.ContractExpiry = this.txtContractExpiry.Text.Trim();
            }
        }

        if (!this.txtSalary.Text.Trim().ToString().Equals(""))
        {
            objPer.Salary = txtSalary.Text.Trim();
        }
        else
        {
            objPer.Salary = "0";
        }
        objPer.HPhoneNo1 = txtHPhone1.Text.Trim();
        objPer.HPhoneNo2 = txtHPhone2.Text.Trim();
        objPer.OPhoneNo1 = txtOPhone1.Text.Trim();
        objPer.OPhoneNo2 = txtOPhone2.Text.Trim();
        objPer.CPhoneNo = txtCPhone.Text.Trim();
        objPer.FaxNo = txtFaxNo.Text.Trim();
        objPer.Email = txtEmail.Text.Trim();
        objPer.CurrentAddress = txtCurrentAddress.Text.Trim();
        objPer.PermanentAddress = txtPermanentddress.Text.Trim();
        objPer.LoginId = txtLoginID.Text.Trim();
        objPer.Pasword = txtPassword.Text.Trim();

        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlSubDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlDesignation.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.DesignationId = this.ddlDesignation.SelectedItem.Value.ToString();
        }
        if (!this.ddlSalutation.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.Salutation = this.ddlSalutation.SelectedItem.Value.ToString();
        }
        if (!this.ddlSex.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.Sex = this.ddlSex.SelectedItem.Value.ToString();
        }
        if (!this.ddlBloodGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.BloodGroup = this.ddlBloodGroup.SelectedItem.Value.ToString();
        }

        if (!this.ddlMaritalStatus.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.MS = this.ddlMaritalStatus.SelectedItem.Value.ToString();
        }

        if (this.chkCHange.Checked)
        {

            if ((lblpass.Text) != (txtPassword.Text))
            {
                if (txtCurPas.Text.Trim().Equals(""))
                {
                    lblErrMsg.Text = "Please Enter Old Password";
                    return;
                }
                else if ((txtCurPas.Text) == (lblpass.Text))
                {
                    objPer.Pasword = this.txtPassword.Text.Trim();
                    objPer.ConfirmPasword = this.txtConfirmPassword.Text.Trim();
                }
                else
                {
                    lblErrMsg.Text = "Please enter correct old password.";
                    return;
                }
            }
        }
        else
        {
            objPer.Pasword = this.lblpass.Text;
            objPer.ConfirmPasword = this.lblCnfPas.Text;
        }

        objPer.Active = chkActive.Checked ? "Y" : "N";
        objPer.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objPer.Enteredby = Session["PersonId"].ToString();
        objPer.ClientId = System.Configuration.ConfigurationManager.AppSettings["ClientID"].ToString().Trim();
        objPer.CrossDept = this.chkcros_Dept.Checked ? "Y" : "N";
        objPer.CrossLab = this.chkCrossLab.Checked ? "Y" : "N";
        objPer.BranchID = Session["BranchID"].ToString().Trim();

        if (objPer.Update())
        {
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Update successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objPer.ErrorMessage;
        }
    }

    private void Clear()
    {
        this.ddlSalutation.SelectedValue = "-1";
        this.txtConfirmPassword.ReadOnly = false;
        
        this.txtPassword.ReadOnly = false;
        this.txtLoginID.ReadOnly = false;
        this.chkCHange.Checked = false;
        
        this.txtFName.Text = "";
        this.txtMName.Text = "";
        this.txtLName.Text = "";
        
        this.txtAcronym.Text = "";
        this.txtFHName.Text = "";
        this.txtDOB.Text = "";
        this.txtNICNo.Text = "";
        
        this.txtNICValidUpto.Text = "";
        this.txtPassport.Text = "";
        this.txtPassportValidUpto.Text = "";

        this.ddlOrganization.SelectedValue = "-1";
        this.ddlDepartment.SelectedValue = "-1";
        
        this.ddlSubDepartment.SelectedValue = "-1";
        this.ddlDesignation.SelectedValue = "-1";
        this.ddlMaritalStatus.SelectedValue = "-1";

        this.txtServiceNo.Text = "";
        this.txtReferenceCode.Text = "";
       
        this.txtJoiningDate.Text = "";
        this.txtRetiringDate.Text = "";
        this.txtEducation.Text = "";

        this.rdPermanent.Checked = true;
        this.rdContract.Checked = false;

        this.txtSalary.Text = "";
        this.txtContractExpiry.Text = "";
        this.txtHPhone1.Text = "";
        this.txtHPhone2.Text = "";
        
        this.txtOPhone1.Text = "";
        this.txtOPhone2.Text = "";
        this.txtCPhone.Text = "";
        
        this.txtFaxNo.Text = "";
        this.txtEmail.Text = "";
        this.txtCurrentAddress.Text = "";
        this.txtPermanentddress.Text = "";

        this.txtLoginID.Text = "";
        this.txtPassword.Text = "";
        this.txtConfirmPassword.Text = "";
        lblpass.Text = "";
        lblCnfPas.Text = "";
        
        chkActive.Checked = true;
        chkcros_Dept.Checked = false;
        chkCrossLab.Checked = false;
        lblErrMsg.Text = "";
        Fillgv();
        lblstatus.Text = "i";
    }

    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.txtFName.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblPersonId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    
   
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSubDeptDDL();
        Fillgv();
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
    }

    protected void gvPersonnel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersonnel.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvPersonnel_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsPersonnel objPer = new clsPersonnel();
        lblPersonId.Text = objPer.PersonId = gvPersonnel.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objPer.GetAll(3);
        if (dv.Count > 0)
        {
            if (!dv[0]["Salutation"].ToString().Equals(""))
            {
                this.ddlSalutation.SelectedValue = dv[0]["Salutation"].ToString();
            }
            this.txtFName.Text = dv[0]["FName"].ToString();
            this.txtMName.Text = dv[0]["MName"].ToString();
            this.txtLName.Text = dv[0]["LName"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtFHName.Text = dv[0]["FHName"].ToString();
            this.txtDOB.Text = dv[0]["DOB"].ToString();
            this.txtNICNo.Text = dv[0]["NIC"].ToString();
            this.txtNICValidUpto.Text = dv[0]["NICValidUpto"].ToString();
            this.txtPassport.Text = dv[0]["Passport"].ToString();
            this.txtPassportValidUpto.Text = dv[0]["PassportValidUpto"].ToString();

            if (!dv[0]["Sex"].ToString().Equals(""))
            {
                this.ddlSex.SelectedValue = dv[0]["Sex"].ToString();
            }

            if (!dv[0]["BloodGroup"].ToString().Equals(""))
            {
                this.ddlBloodGroup.SelectedValue = dv[0]["BloodGroup"].ToString();
            }

            if (!dv[0]["MS"].ToString().Equals(""))
            {
                this.ddlMaritalStatus.SelectedValue = dv[0]["MS"].ToString();
            }

            try
            {
                this.ddlOrganization.SelectedItem.Selected = false;
                this.ddlOrganization.Items.FindByValue(dv[0]["OrgId"].ToString()).Selected = true;
            }
            catch { }
            try
            {
                this.ddlDepartment.SelectedItem.Selected = false;
                this.ddlDepartment.Items.FindByValue(dv[0]["DepartmentId"].ToString()).Selected = true;
            }
            catch { }
            FillSubDeptDDL();
            try
            {
                this.ddlSubDepartment.SelectedItem.Selected = false;
                this.ddlSubDepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();
            }
            catch { }
            try
            {
                this.ddlDesignation.SelectedItem.Selected = false;
                this.ddlDesignation.Items.FindByValue(dv[0]["DesignationId"].ToString()).Selected = true;
            }
            catch { }

            this.txtServiceNo.Text = dv[0]["ServiceNo"].ToString();
            this.txtReferenceCode.Text = dv[0]["ReferenceCode"].ToString();
            this.txtJoiningDate.Text = dv[0]["JoiningDate"].ToString();
            this.txtRetiringDate.Text = dv[0]["LeavingDate"].ToString();
            this.txtEducation.Text = dv[0]["Education"].ToString();            

            if (dv[0]["Nature"].ToString().Equals("P"))
            {
                this.rdPermanent.Checked = true;
            }

            if (dv[0]["Nature"].ToString().Equals("C"))
            {
                this.rdContract.Checked = true;
            }

            this.txtSalary.Text = dv[0]["Salary"].ToString();
            this.txtContractExpiry.Text = dv[0]["ContractExpiry"].ToString();
            this.txtHPhone1.Text = dv[0]["HPhoneNo1"].ToString();
            this.txtHPhone2.Text = dv[0]["HPhoneNo2"].ToString();

            this.txtOPhone1.Text = dv[0]["OPhoneNo1"].ToString();
            this.txtOPhone2.Text = dv[0]["OPhoneNo2"].ToString();
            this.txtCPhone.Text = dv[0]["CPhoneNo"].ToString();

            this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
            this.txtEmail.Text = dv[0]["Email"].ToString();

            this.txtCurrentAddress.Text = dv[0]["CurrentAddress"].ToString();
            this.txtPermanentddress.Text = dv[0]["PermanentAddress"].ToString();
            this.txtLoginID.Text = dv[0]["LoginId"].ToString();
            this.txtPassword.Text = dv[0]["Pasword"].ToString();     
       
            this.lblpass.Text = dv[0]["Pasword"].ToString();
            this.lblCnfPas.Text = dv[0]["Pasword"].ToString(); 

            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            this.chkcros_Dept.Checked = (dv[0]["crossdept"].ToString().Equals("Y")) ? true : false;
            this.chkCrossLab.Checked = (dv[0]["crosslab"].ToString().Equals("Y")) ? true : false;

            this.txtConfirmPassword.ReadOnly = true;
            this.txtPassword.ReadOnly = true;
            this.txtCurPas.ReadOnly = true;
            this.txtLoginID.ReadOnly = true;
        }
    }
    protected void gvPersonnel_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("PersonName"))
        {
            if (DGSort == "PersonName ASC")
                DGSort = "PersonName DESC";
            else
                DGSort = "PersonName ASC";
        }

        Fillgv();
    }
    protected void chkCHange_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCHange.Checked == true)
        {
            txtPassword.ReadOnly = false;
            txtCurPas.ReadOnly = false;
            txtConfirmPassword.ReadOnly = false;
        }
        else
        {
            txtPassword.ReadOnly = true;
            txtCurPas.ReadOnly = true;
            txtConfirmPassword.ReadOnly = true;
        }
    }

    protected void gvPersonnel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsPersonnel objPer = new clsPersonnel();
            lblPersonId.Text = objPer.PersonId = gvPersonnel.DataKeys[index].Value.ToString();
            DataView dv = objPer.GetAll(3);
            if (dv.Count > 0)
            {
                if (!dv[0]["Salutation"].ToString().Equals(""))
                {
                    this.ddlSalutation.SelectedValue = dv[0]["Salutation"].ToString();
                }
                this.txtFName.Text = dv[0]["FName"].ToString();
                this.txtMName.Text = dv[0]["MName"].ToString();
                this.txtLName.Text = dv[0]["LName"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtFHName.Text = dv[0]["FHName"].ToString();
                this.txtDOB.Text = dv[0]["DOB"].ToString();
                this.txtNICNo.Text = dv[0]["NIC"].ToString();
                this.txtNICValidUpto.Text = dv[0]["NICValidUpto"].ToString();
                this.txtPassport.Text = dv[0]["Passport"].ToString();
                this.txtPassportValidUpto.Text = dv[0]["PassportValidUpto"].ToString();

                if (!dv[0]["Sex"].ToString().Equals(""))
                {
                    this.ddlSex.SelectedValue = dv[0]["Sex"].ToString();
                }

                if (!dv[0]["BloodGroup"].ToString().Equals(""))
                {
                    this.ddlBloodGroup.SelectedValue = dv[0]["BloodGroup"].ToString();
                }

                if (!dv[0]["MS"].ToString().Equals(""))
                {
                    this.ddlMaritalStatus.SelectedValue = dv[0]["MS"].ToString();
                }

                try
                {
                    this.ddlOrganization.SelectedItem.Selected = false;
                    this.ddlOrganization.Items.FindByValue(dv[0]["OrgId"].ToString()).Selected = true;
                }
                catch { }
                try
                {
                    this.ddlDepartment.SelectedItem.Selected = false;
                    this.ddlDepartment.Items.FindByValue(dv[0]["DepartmentId"].ToString()).Selected = true;
                }
                catch { }
                FillSubDeptDDL();
                try
                {
                    this.ddlSubDepartment.SelectedItem.Selected = false;
                    this.ddlSubDepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();
                }
                catch { }
                try
                {
                    this.ddlDesignation.SelectedItem.Selected = false;
                    this.ddlDesignation.Items.FindByValue(dv[0]["DesignationId"].ToString()).Selected = true;
                }
                catch { }

                this.txtServiceNo.Text = dv[0]["ServiceNo"].ToString();
                this.txtReferenceCode.Text = dv[0]["ReferenceCode"].ToString();
                this.txtJoiningDate.Text = dv[0]["JoiningDate"].ToString();
                this.txtRetiringDate.Text = dv[0]["LeavingDate"].ToString();
                this.txtEducation.Text = dv[0]["Education"].ToString();

                if (dv[0]["Nature"].ToString().Equals("P"))
                {
                    this.rdPermanent.Checked = true;
                }

                if (dv[0]["Nature"].ToString().Equals("C"))
                {
                    this.rdContract.Checked = true;
                }

                this.txtSalary.Text = dv[0]["Salary"].ToString();
                this.txtContractExpiry.Text = dv[0]["ContractExpiry"].ToString();
                this.txtHPhone1.Text = dv[0]["HPhoneNo1"].ToString();
                this.txtHPhone2.Text = dv[0]["HPhoneNo2"].ToString();

                this.txtOPhone1.Text = dv[0]["OPhoneNo1"].ToString();
                this.txtOPhone2.Text = dv[0]["OPhoneNo2"].ToString();
                this.txtCPhone.Text = dv[0]["CPhoneNo"].ToString();

                this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
                this.txtEmail.Text = dv[0]["Email"].ToString();

                this.txtCurrentAddress.Text = dv[0]["CurrentAddress"].ToString();
                this.txtPermanentddress.Text = dv[0]["PermanentAddress"].ToString();
                this.txtLoginID.Text = dv[0]["LoginId"].ToString();
                this.txtPassword.Text = dv[0]["Pasword"].ToString();

                this.lblpass.Text = dv[0]["Pasword"].ToString();
                this.lblCnfPas.Text = dv[0]["Pasword"].ToString();

                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                this.chkcros_Dept.Checked = (dv[0]["crossdept"].ToString().Equals("Y")) ? true : false;
                this.chkCrossLab.Checked = (dv[0]["crosslab"].ToString().Equals("Y")) ? true : false;

                this.txtConfirmPassword.ReadOnly = true;
                this.txtPassword.ReadOnly = true;
                this.txtCurPas.ReadOnly = true;
                this.txtLoginID.ReadOnly = true;
            }
        }
    }
}
