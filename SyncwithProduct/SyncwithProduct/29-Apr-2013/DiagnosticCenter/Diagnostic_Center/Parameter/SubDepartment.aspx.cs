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

public partial class SubDepartment : System.Web.UI.Page
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
                log.OptionId = "4";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtName.Focus();
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblSubDepartmentId.Text = "";
                    FillDeptDDL();
                    if (!Session["DepartmentId"].Equals(""))
                    {
                        this.ddlDepartment.SelectedValue = Session["DepartmentId"].ToString();
                    }
                    FillPersonDDL();
                    Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlDepartment.Focus();
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

    private void FillDeptDDL()
    {
        clsDepartment objOrg = new clsDepartment();
        SComponents objScom = new SComponents();
        DataView dv = objOrg.GetAll(4);
        objScom.FillDropDownList(ddlDepartment, dv, "Name", "DepartmentId", true, false, true);
        this.ddlDepartment.SelectedValue = "-1";
    }

    private void FillPersonDDL()
    {
        clsPersonnel objPer = new clsPersonnel();
        SComponents objScom = new SComponents();
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objPer.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        DataView dv = objPer.GetAll(4);
        objScom.FillDropDownList(ddlPerson, dv, "Name", "PersonId", true, false, true);
        this.ddlPerson.SelectedValue = "-1";
    }

    private void Fillgv()
    {
        clsSubDepartment objDC = new clsSubDepartment();
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvSubDepartment.DataSource = dv;
            gvSubDepartment.DataBind();
            gvSubDepartment.Visible = true;
        }
        else
        {
            gvSubDepartment.Visible = false;
        }
    }
    private void Insert()
    {
        clsSubDepartment objDC = new clsSubDepartment();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.PhoneNo = txtPhoneNo.Text.Trim();
        objDC.FaxNo = txtFaxNo.Text.Trim();
        objDC.Email = txtEmail.Text.Trim();
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
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
        objDC.Dorder = this.txtDorder.Text.Trim().Equals("") ? "~!@" : txtDorder.Text.Trim();
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org

        if (objDC.Insert())
        {
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
        clsSubDepartment objDC = new clsSubDepartment();
        objDC.SubdepartmentId = lblSubDepartmentId.Text.Trim();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.PhoneNo = txtPhoneNo.Text.Trim();
        objDC.FaxNo = txtFaxNo.Text.Trim();
        objDC.Email = txtEmail.Text.Trim();
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
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
        objDC.Dorder = this.txtDorder.Text.Trim().Equals("") ? "~!@" : txtDorder.Text.Trim();
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
        txtDorder.Text = "";
        this.ddlDepartment.SelectedValue = "-1";
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
        lblSubDepartmentId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["DepartmentId"].Equals(""))
        {
            Response.Redirect("Department.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }

    protected void gvSubDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSubDepartment.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvSubDepartment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlDepartment.SelectedValue = "-1";   
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsSubDepartment objDC = new clsSubDepartment();
        lblSubDepartmentId.Text = objDC.SubdepartmentId = gvSubDepartment.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtName.Text = dv[0]["Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtPhoneNo.Text = dv[0]["PhoneNo"].ToString();
            this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
            this.txtEmail.Text = dv[0]["Email"].ToString();
            this.txtDorder.Text = dv[0]["dorder"].ToString();
            try
            {
                this.ddlDepartment.SelectedItem.Selected = false;
                this.ddlDepartment.Items.FindByValue(dv[0]["DepartmentId"].ToString()).Selected = true;
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
    protected void gvSubDepartment_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPersonDDL();
        Fillgv();
    }

    protected void gvSubDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            this.ddlDepartment.SelectedValue = "-1";
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsSubDepartment objDC = new clsSubDepartment();
            lblSubDepartmentId.Text = objDC.SubdepartmentId = gvSubDepartment.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtName.Text = dv[0]["Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtPhoneNo.Text = dv[0]["PhoneNo"].ToString();
                this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
                this.txtEmail.Text = dv[0]["Email"].ToString();
                this.txtDorder.Text = dv[0]["dorder"].ToString();
                try
                {
                    this.ddlDepartment.SelectedItem.Selected = false;
                    this.ddlDepartment.Items.FindByValue(dv[0]["DepartmentId"].ToString()).Selected = true;
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
    }
}
