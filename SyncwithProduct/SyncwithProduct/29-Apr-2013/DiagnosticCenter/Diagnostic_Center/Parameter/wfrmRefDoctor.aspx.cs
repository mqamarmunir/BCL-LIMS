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

public partial class refdoctor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "25";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillDept();
                    FillOrg();
                    FillPanel();
                    FillSpeciality();
                    FillCity();
                    lblStatus.Text = "i";
                    //FillGV();
                    txtregdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
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

    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_Form();
        ddlDepart.SelectedIndex = -1;
        ddlOrg.SelectedIndex = -1;
        ddlPanel.SelectedIndex = -1;

        gvDoctor.DataSource = null;
        gvDoctor.DataBind();
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Validate_Form())
            return;
        if (lblStatus.Text == "i")
            Insert();
        else
            Update();

    }

    private void Clear_Form()
    {
        lblerror.Text = "";
        lblID.Text = "";
        lblStatus.Text = "i";

        txtName.Text = "";
        txtregdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtShare.Text = "";

        txtAddress.Text = "";
        txtCell.Text = "";
        txtEmail.Text = "";
        txtCode.Text = "";

        txtFax.Text = "";
        ddlSpeciality.SelectedIndex = -1;
        ddlCity.SelectedIndex = -1;
        ddlTitle.SelectedIndex = 0;
        
        chkActive.Checked = true;
        lblPasword.Text = "";
        txtPasword.Text = "";
        txtLogin.Text = "";
    }
    private void FillGV()
    {
        clsBLRefDoctor rd = new clsBLRefDoctor();
        if (ddlOrg.SelectedIndex > 0)
            rd.OrgID = this.ddlOrg.SelectedItem.Value.ToString();
        if (ddlPanel.SelectedIndex > 0)
            rd.PanelID = this.ddlPanel.SelectedItem.Value.ToString();

        if (ddlDepart.SelectedIndex > 0)
            rd.DeptID = this.ddlDepart.SelectedItem.Value.ToString();

        DataView dv = rd.GetAll(1);
        if (dv.Count > 0)
        {
            gvDoctor.DataSource = dv;
            gvDoctor.DataBind();
        }
        else
        {
            gvDoctor.DataSource = null;
            gvDoctor.DataBind();
        }
    }
    private void FillDept()
    {
        clsBLRefDoctor rd = new clsBLRefDoctor();
        SComponents com = new SComponents();
        DataView dv = rd.GetAll(3);
        com.FillDropDownList(ddlDepart, dv, "name", "departmentid");
    }

    private void FillOrg()
    {
        clsBLRefDoctor re = new clsBLRefDoctor();
        SComponents com = new SComponents();

        DataView dv = re.GetAll(4);
        com.FillDropDownList(ddlOrg, dv, "name", "orgid");
    }
    private void FillPanel()
    {
        clsBLRefDoctor re = new clsBLRefDoctor();
        SComponents com = new SComponents();
        DataView dv = re.GetAll(5);
        com.FillDropDownList(ddlPanel, dv, "name", "panelid");
    }
    private void FillSpeciality()
    {
        clsBLRefDoctor re = new clsBLRefDoctor();
        SComponents com = new SComponents();
        DataView dv = re.GetAll(6);

        com.FillDropDownList(ddlSpeciality, dv, "name", "specialityid");

    }
    private void FillCity()
    {
        clsBLRefDoctor re = new clsBLRefDoctor();
        SComponents com = new SComponents();
        DataView dv = re.GetAll(7);

        com.FillDropDownList(ddlCity, dv, "name", "cityid");
    }

    private void Insert()
    {
        clsBLRefDoctor rd = new clsBLRefDoctor();

        rd.DeptID = this.ddlDepart.SelectedItem.Value.ToString();
        rd.Title = this.ddlTitle.SelectedItem.Value.ToString();
        rd.Name = this.txtName.Text.Trim().Replace("'","''");
        rd.Code = this.txtCode.Text.Trim();
        rd.Share = this.txtShare.Text.Trim().Equals("") ? "0" : txtShare.Text.Trim();
        rd.Reg_date = this.txtregdate.Text.Trim();

        rd.PanelID = this.ddlPanel.SelectedItem.Value.ToString().Equals("-1") ? "null" : this.ddlPanel.SelectedItem.Value.ToString();
        rd.OrgID = this.ddlOrg.SelectedItem.Value.ToString().Equals("-1") ? "~!@" : this.ddlOrg.SelectedItem.Value.ToString();

        rd.CellNo = this.txtCell.Text.Trim().Replace("'","''");
        rd.Fax = this.txtFax.Text.Trim().Replace("'","''");
        rd.Email = this.txtEmail.Text.Trim().Replace("'","''");

        rd.Speciality = this.ddlSpeciality.SelectedItem.Value.ToString().Equals("-1") ? "null" : ddlSpeciality.SelectedItem.Value.ToString();
        rd.Address = this.txtAddress.Text.Trim().Replace("'","''");
        rd.CityID = this.ddlCity.SelectedItem.Value.ToString().Replace("-1","~!@");

        rd.LoginID = this.txtLogin.Text.Trim();
        rd.Pasword = this.txtPasword.Text.Trim();

        rd.Active = chkActive.Checked ? "Y" : "N";
        rd.EnteredBy = Session["personid"].ToString();
        rd.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        rd.ClientID = Session["orgid"].ToString();
        

        if (rd.Insert())
        {
            Clear_Form();

            lblerror.ForeColor = System.Drawing.Color.Green;
            lblerror.Text = "Record has been saved successfully";
            FillGV();
        }
        else
        {
            lblerror.ForeColor = System.Drawing.Color.Red;
            lblerror.Text = rd.Error;
        }

    }
    private void Update()
    {
        clsBLRefDoctor rd = new clsBLRefDoctor();

        rd.DeptID = this.ddlDepart.SelectedItem.Value.ToString();
        rd.DoctorID = this.lblID.Text.Trim();
        rd.Title = this.ddlTitle.SelectedItem.Value.ToString();
        rd.Name = this.txtName.Text.Trim().Replace("'", "''");
        rd.Code = this.txtCode.Text.Trim();

        rd.Share = this.txtShare.Text.Trim().Equals("") ? "0" : txtShare.Text.Trim();
        rd.Reg_date = this.txtregdate.Text.Trim();

        rd.PanelID = this.ddlPanel.SelectedItem.Value.ToString().Equals("-1") ? "null" : this.ddlPanel.SelectedItem.Value.ToString();
        rd.OrgID = this.ddlOrg.SelectedItem.Value.ToString().Equals("-1") ? "~!@" : this.ddlOrg.SelectedItem.Value.ToString();

        rd.CellNo = this.txtCell.Text.Trim().Replace("'", "''");
        rd.Fax = this.txtFax.Text.Trim().Replace("'", "''");
        rd.Email = this.txtEmail.Text.Trim().Replace("'", "''");

        rd.Speciality = this.ddlSpeciality.SelectedItem.Value.ToString().Equals("-1") ? "null" : ddlSpeciality.SelectedItem.Value.ToString();
        rd.Address = this.txtAddress.Text.Trim().Replace("'", "''");
        rd.CityID = this.ddlCity.SelectedItem.Value.ToString().Replace("-1", "~!@");

        rd.LoginID = this.txtLogin.Text.Trim();
        if (!txtPasword.Text.Trim().Equals(""))
            rd.Pasword = this.txtPasword.Text.Trim();
        else
            rd.Pasword = lblPasword.Text.Trim();

        rd.Active = chkActive.Checked ? "Y" : "N";
        rd.EnteredBy = Session["personid"].ToString();
        rd.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        rd.ClientID = Session["orgid"].ToString();
        

        if (rd.Update())
        {
            Clear_Form();

            lblerror.ForeColor = System.Drawing.Color.Green;
            lblerror.Text = "Record has been updated successfully"; 
            FillGV();
        }
        else
        {
            lblerror.ForeColor = System.Drawing.Color.Red;
            lblerror.Text = rd.Error;
        }

    }

    private bool Validate_Form()
    {
        lblerror.Text = "";
        lblerror.ForeColor = System.Drawing.Color.Red;

        if (ddlOrg.SelectedIndex <= 0 && ddlPanel.SelectedIndex <= 0)
        {
            lblerror.Text = "Please select Organization OR Panel Company";
            return false;
        }
        if (ddlOrg.SelectedIndex > 0 && ddlPanel.SelectedIndex > 0)
        {
            lblerror.Text = "Please select Organization OR Panel Company";
            return false;
        }
        if (ddlDepart.SelectedIndex <= 0)
        {
            lblerror.Text = "Please select Department first";
            ddlDepart.Focus();
            return false;
        }

        if (txtName.Text.Trim().Equals(""))
        {
            lblerror.Text = "Please enter doctor name.(empty is not allowed)";
            txtName.Focus();
            return false;
        }
        clsValidation vd = new clsValidation();
        if (!txtEmail.Text.Trim().Equals(""))
        {
            if (!vd.IsEmail(txtEmail.Text.Trim()))
            {
                lblerror.Text = "Please enter correct email address";
                txtEmail.Focus();
                return false;
            }
        }
        if (!txtLogin.Text.Trim().Equals("") && txtPasword.Text.Trim().Equals("") && lblPasword.Text.Trim().Equals(""))
        {
            lblerror.Text = "Please enter pasword";
            txtPasword.Focus();
            return false;
        }

        return true;
    }
    protected void gvDoctor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblerror.Text = "";

        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvDoctor.DataKeys[index].Value.ToString();
            txtName.Text = gvDoctor.DataKeys[index].Values[9].ToString().Trim();
            txtShare.Text = gvDoctor.Rows[index].Cells[2].Text.Trim();
            txtCode.Text = gvDoctor.DataKeys[index].Values[11].ToString().Trim().Replace("&nbsp;","");

            txtregdate.Text = gvDoctor.Rows[index].Cells[3].Text.Trim();
            chkActive.Checked = ((CheckBox)(gvDoctor.Rows[index].Cells[9].FindControl("chkGVActive"))).Checked;

            txtCell.Text = gvDoctor.Rows[index].Cells[6].Text.Trim().Replace("&nbsp;", "");
            txtFax.Text = gvDoctor.DataKeys[index].Values[4].ToString();
            txtEmail.Text = gvDoctor.DataKeys[index].Values[5].ToString();

            txtAddress.Text = gvDoctor.DataKeys[index].Values[6].ToString();
            lblPasword.Text = gvDoctor.DataKeys[index].Values[12].ToString().Replace("&nbsp;","");
            txtLogin.Text = gvDoctor.Rows[index].Cells[8].Text.Trim().Replace("&nbsp;", "");

            try
            {
                ddlTitle.SelectedItem.Selected = false;
                ddlTitle.Items.FindByValue(gvDoctor.DataKeys[index].Values[10].ToString()).Selected = true;
            }
            catch { }
            try
            {
                ddlCity.SelectedItem.Selected = false;
                ddlCity.Items.FindByValue(gvDoctor.DataKeys[index].Values[8].ToString()).Selected = true;
            }
            catch { }
            try
            {
                ddlSpeciality.SelectedItem.Selected = false;
                ddlSpeciality.Items.FindByValue(gvDoctor.DataKeys[index].Values[7].ToString()).Selected = true;
            }
            catch { }


            try
            {
                ddlDepart.SelectedItem.Selected = false;
                ddlDepart.Items.FindByValue(gvDoctor.DataKeys[index].Values[1].ToString()).Selected = true;
            }
            catch { }

            try
            {
                ddlOrg.SelectedItem.Selected = false;
                ddlOrg.Items.FindByValue(gvDoctor.DataKeys[index].Values[2].ToString()).Selected = true;
            }
            catch { }
            try
            {
                ddlPanel.SelectedItem.Selected = false;
                ddlPanel.Items.FindByValue(gvDoctor.DataKeys[index].Values[3].ToString()).Selected = true;
            }
            catch { }
            lblStatus.Text = "u";
        }
    }
    protected void ddlDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblerror.Text = "";
        if (ddlDepart.SelectedIndex > 0)
        {
            FillGV();
        }
        
    }

    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblerror.Text = "";
        if (ddlOrg.SelectedIndex > 0)
        {
            FillGV();
        }
       
    }
    protected void ddlPanel_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblerror.Text = "";
        if (ddlPanel.SelectedIndex > 0)
        {
            FillGV();
        }
    }
}
