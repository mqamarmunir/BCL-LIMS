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

public partial class panelc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "22";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillOrd_ddl();
                    //FillGV();
                    lblStatus.Text = "i";
                    txtRegDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtExpiry.Text = System.DateTime.Now.AddDays(20).ToString("dd/MM/yyyy");
                    imgFormat.ImageUrl = "../rpt_formats/format_-1.JPG";
                    cpeWaiting.Collapsed = true;
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
        this.ddlOrganization.SelectedIndex = -1;
        FillGV();
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
        lblStatus.Text = "i";
        lblID.Text = "";
        lblError.Text = "";
        lblPasword.Text = "";

        txtAcronym.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";

        txtCP_Contact.Text = "";
        txtCP_Desig.Text = "";
        txtCP_Email.Text = "";
        txtCP_Name.Text = "";

        txtDiscount.Text = "";
        txtFax.Text = "";
        txtLogin.Text = "";

        txtName.Text = "";
        txtPasword.Text = "";
        txtPhoneNo.Text = "";

        txtRegDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtExpiry.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        chkActive.Checked = true;
        chkAuthorize.Checked = false;
        chkPrintAmt.Checked = false;
        ddlRptFmt.SelectedIndex = -1;
        imgFormat.ImageUrl = "";
        chkCash.Checked = false;
    }
    private bool Validate_Form()
    {
        lblError.Text = "";
        lblError.ForeColor = System.Drawing.Color.Red;

        if (ddlOrganization.SelectedIndex<0)
        {
            lblError.Text = "Please select organization first";
            ddlOrganization.Focus();
            return false;
        }
        if (txtName.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter panel name.(empty is not allowed)";
            txtName.Focus();
            return false;
        }
        if (txtPhoneNo.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter company phone number.(empty is not allowed)";
            txtPhoneNo.Focus();
            return false;
        }
        if (txtCP_Name.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter contact person name.(empty is not allowed)";
            txtCP_Name.Focus();
            return false;
        }
        if (txtCP_Email.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter contact person email address.(empty is not allowed)";
            txtCP_Email.Focus();
            return false;
        }
        if (txtLogin.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter login.(empty is not allowed)";
            txtLogin.Focus();
            return false;
        }
        if (txtPasword.Text.Trim().Equals("") && lblPasword.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter pasword.(empty is not allowed)";
            txtPasword.Focus();
            return false;
        }
        if (txtExpiry.Text.Trim() == txtRegDate.Text.Trim())
        {
            lblError.Text = "Registration date and expiry date should be different";
            return false;
        }
        clsValidation vd = new clsValidation();

        if(!vd.IsDate(txtRegDate.Text.Trim()))
        {
            lblError.Text = "Please select or enter correct registration date";
            txtRegDate.Focus();
            return false;
        }
        if (!vd.IsDate(txtExpiry.Text.Trim()))
        {
            lblError.Text = "Please select or enter correct expiry date";
            txtExpiry.Focus();
            return false;
        }
        return true;
    }

    private void Insert()
    {
        clsBLPanel pn = new clsBLPanel();

        pn.Name = this.txtName.Text.Trim().Replace("'","''");
        pn.Active = this.chkActive.Checked ? "Y" : "N";
        pn.Acronym = this.txtAcronym.Text.Trim().Replace("'","''");

        pn.Address = this.txtAddress.Text.Trim().Replace("'","''");
        pn.PhoneNO = this.txtPhoneNo.Text.Trim();
        pn.Email = this.txtEmail.Text.Trim().Replace("'","''");
        pn.Fax = this.txtFax.Text.Trim().Replace("'","''");

        pn.Discount = this.txtDiscount.Text.Trim().Replace("%","").Equals("") ? "0" : txtDiscount.Text.Trim();
        pn.Reg_Date = this.txtRegDate.Text.Trim();
        pn.Exp_Date = this.txtExpiry.Text.Trim();
        pn.Contact_person = this.txtCP_Name.Text.Trim().Replace("'","''");

        pn.CP_Designation = this.txtCP_Desig.Text.Trim().Replace("'","''");
        pn.CP_ContactNo = this.txtCP_Contact.Text.Trim();
        pn.CP_Email = this.txtCP_Email.Text.Trim().Replace("'","''");

        pn.Authorization_Required = this.chkAuthorize.Checked ? "Y" : "N";
        pn.Print_Amt = this.chkPrintAmt.Checked ? "Y" : "N";
        pn.CashPanel = this.chkCash.Checked ? "Y" : "N";
        pn.Login = this.txtLogin.Text.Trim().Replace("'","''");
        pn.Pasword = this.txtPasword.Text.Trim().Replace("'","''");
        //pn.Rpt_Format = this.ddlRptFmt.SelectedItem.Value.ToString();
      
        
        pn.EnteredBy = Session["personid"].ToString();
        pn.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pn.ClientID = this.ddlOrganization.SelectedItem.Value.ToString(); // org

        if (pn.Insert())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";

            FillGV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = pn.Error;
        }
    }
    private void Update()
    {
        clsBLPanel pn = new clsBLPanel();

        pn.PanelID = this.lblID.Text.Trim();
        pn.Name = this.txtName.Text.Trim().Replace("'", "''");
        pn.Active = this.chkActive.Checked ? "Y" : "N";
        pn.Acronym = this.txtAcronym.Text.Trim().Replace("'", "''");

        pn.Address = this.txtAddress.Text.Trim().Replace("'", "''");
        pn.PhoneNO = this.txtPhoneNo.Text.Trim();
        pn.Email = this.txtEmail.Text.Trim().Replace("'", "''");
        pn.Fax = this.txtFax.Text.Trim().Replace("'", "''");

        pn.Discount = this.txtDiscount.Text.Trim().Replace("%","").Equals("") ? "0" : txtDiscount.Text.Trim();
        pn.Reg_Date = this.txtRegDate.Text.Trim();
        pn.Exp_Date = this.txtExpiry.Text.Trim();
        pn.Contact_person = this.txtCP_Name.Text.Trim().Replace("'", "''");

        pn.CP_Designation = this.txtCP_Desig.Text.Trim().Replace("'", "''");
        pn.CP_ContactNo = this.txtCP_Contact.Text.Trim();
        pn.CP_Email = this.txtCP_Email.Text.Trim().Replace("'", "''");

        pn.Authorization_Required = this.chkAuthorize.Checked ? "Y" : "N";
        pn.CashPanel = this.chkCash.Checked ? "Y" : "N";
        pn.Print_Amt = this.chkPrintAmt.Checked ? "Y" : "N";
        pn.Login = this.txtLogin.Text.Trim().Replace("'", "''");
        //pn.Rpt_Format = this.ddlRptFmt.SelectedItem.Value.ToString();
        if(txtPasword.Text.Trim().Equals(""))
            pn.Pasword = this.lblPasword.Text.Trim().Replace("'", "''");
        else
            pn.Pasword = this.txtPasword.Text.Trim().Replace("'", "''");


        pn.EnteredBy = Session["personid"].ToString();
        pn.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pn.ClientID = this.ddlOrganization.SelectedItem.Value.ToString(); // org
        if (pn.Update())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";
            FillGV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = pn.Error;
        }
    }
    private void FillGV()
    {
        clsBLPanel pn = new clsBLPanel();
        pn.ClientID = this.ddlOrganization.SelectedItem.Value.ToString();
        DataView dv = pn.GetAll(1);

        if (dv.Count > 0)
        {
            gvPanel.DataSource = dv;
            gvPanel.DataBind();
        }
        else
        {
            gvPanel.DataSource = null;
            gvPanel.DataBind();
        }
    }
    private void FillOrd_ddl()
    {
        SComponents com = new SComponents();
        clsBLPanel pn = new clsBLPanel();
        DataView dv = pn.GetAll(7);

        com.FillDropDownList(ddlOrganization, dv, "name", "orgid");
    }

    protected void gvPanel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvPanel.DataKeys[index].Value.ToString();
            txtName.Text = gvPanel.Rows[index].Cells[1].Text.Trim();
            txtAcronym.Text = gvPanel.Rows[index].Cells[2].Text.Trim();

            txtPhoneNo.Text = gvPanel.Rows[index].Cells[3].Text.Trim();
            txtDiscount.Text = gvPanel.Rows[index].Cells[4].Text.Trim().Replace("&nbsp;","0");
            txtCP_Name.Text = gvPanel.Rows[index].Cells[7].Text.Trim();

            chkActive.Checked = ((CheckBox)(gvPanel.Rows[index].Cells[8].FindControl("chkGVActive"))).Checked;
            txtAddress.Text = gvPanel.DataKeys[index].Values[1].ToString();
            txtEmail.Text = gvPanel.DataKeys[index].Values[2].ToString();

            txtFax.Text = gvPanel.DataKeys[index].Values[3].ToString();
            txtRegDate.Text = gvPanel.DataKeys[index].Values[4].ToString().Replace("00/00/0000","");
            txtExpiry.Text = gvPanel.Rows[index].Cells[6].Text.Trim().Replace("00/00/0000","");
            txtCP_Desig.Text = gvPanel.DataKeys[index].Values[5].ToString();

            txtCP_Contact.Text = gvPanel.DataKeys[index].Values[6].ToString();
            txtCP_Email.Text = gvPanel.DataKeys[index].Values[7].ToString();
            txtLogin.Text = gvPanel.DataKeys[index].Values[8].ToString();

            txtPasword.Text = gvPanel.DataKeys[index].Values[9].ToString();
            lblPasword.Text = gvPanel.DataKeys[index].Values[9].ToString();
            chkAuthorize.Checked = gvPanel.DataKeys[index].Values[10].ToString().Equals("Y") ? true : false;
            chkPrintAmt.Checked = gvPanel.DataKeys[index].Values[13].ToString().Equals("Y") ? true : false;
            chkCash.Checked = gvPanel.DataKeys[index].Values["cashPanel"].ToString().Equals("Y") ? true : false;
            try
            {
                ddlOrganization.ClearSelection();
                ddlOrganization.Items.FindByValue(gvPanel.DataKeys[index].Values[12].ToString()).Selected =true;
            }
            catch { }

            try
            {
                ddlRptFmt.ClearSelection();
                ddlRptFmt.Items.FindByValue(gvPanel.DataKeys[index].Values[11].ToString()).Selected = true;
                imgFormat.ImageUrl = "../rpt_formats/format_" + ddlRptFmt.SelectedItem.Value.ToString() + ".JPG";
            }
            catch
            { imgFormat.ImageUrl = "../rpt_formats/format_" + ddlRptFmt.SelectedItem.Value.ToString() + ".JPG"; }

            lblStatus.Text = "u";
        }
    }
    protected void ddlRptFmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        imgFormat.ImageUrl = "../rpt_formats/format_"+ddlRptFmt.SelectedItem.Value.ToString()+".JPG";
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGV();
    }
}
