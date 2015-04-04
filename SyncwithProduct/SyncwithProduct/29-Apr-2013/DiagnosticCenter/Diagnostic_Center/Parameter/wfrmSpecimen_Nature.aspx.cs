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

public partial class spec_nature : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "42";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillGV();
                    lblStatus.Text = "i";                    
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
        Clear();
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

    private void Clear()
    {
        txtDescription.Text = "";
        txtName.Text = "";
        lblStatus.Text = "i";

        lblID.Text = "";
        lblError.Text = "";
        chkActive.Checked = true;
    }
    private bool Validate_Form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;

        if (txtName.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter name.(empty not allowed)";
            return false;
        }
        if (txtDescription.Text.Length>500)
        {
            lblError.Text = "Please enter description words less than 500";
            return false;
        }
        return true;

        
    }
    private void FillGV()
    {
        clsBLSpecimenNature sn = new clsBLSpecimenNature();
        DataView dv = sn.GetAll(1);
        gvNature.DataSource = dv;
        gvNature.DataBind();
    }

    private void Insert()
    {
        clsBLSpecimenNature sn = new clsBLSpecimenNature();

        sn.Name = this.txtName.Text.Trim().Replace("'","''");
        sn.Description = this.txtDescription.Text.Trim().Replace("'","''");
        sn.Active = chkActive.Checked ? "Y" : "N";
        sn.Type = this.ddlType.SelectedItem.Value.ToString();

        sn.EnteredBy = Session["personid"].ToString();
        sn.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        sn.ClientID = Session["orgid"].ToString();

        if (sn.Insert())
        {
            Clear();
            FillGV();

            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = sn.Error;
        }
    }
    private void Update()
    {
        clsBLSpecimenNature sn = new clsBLSpecimenNature();

        sn.SpecimenNatureID = this.lblID.Text.Trim();
        sn.Name = this.txtName.Text.Trim().Replace("'", "''");
        sn.Description = this.txtDescription.Text.Trim().Replace("'", "''");
        sn.Active = chkActive.Checked ? "Y" : "N";
        sn.Type = this.ddlType.SelectedItem.Value.ToString();

        sn.EnteredBy = Session["personid"].ToString();
        sn.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        sn.ClientID = Session["orgid"].ToString();

        if (sn.Update())
        {
            Clear();
            FillGV();

            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = sn.Error;
        }
    }

    protected void gvNature_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvNature.DataKeys[index].Value.ToString();
            txtName.Text = gvNature.Rows[index].Cells[1].Text.Trim();
            txtDescription.Text = gvNature.DataKeys[index].Values[1].ToString();

            chkActive.Checked = ((CheckBox)(gvNature.Rows[index].Cells[2].FindControl("chkGVActive"))).Checked;

            try
            {
                ddlType.SelectedItem.Selected = false;
                ddlType.Items.FindByValue(gvNature.DataKeys[index].Values[2].ToString()).Selected = true;
            }
            catch { }

            lblStatus.Text = "u";
        }
    }
}
