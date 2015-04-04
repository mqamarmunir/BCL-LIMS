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

public partial class panelclass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "23";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillOrd_ddl();
                    lblStatus.Text = "i";
                   // FillDDL();
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
        ddlPanel.SelectedIndex = -1;

        gvClass.DataSource = null;
        gvClass.DataBind();
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Valid_Form())
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

        txtDescription.Text = "";
        txtname.Text = "";
    }
    private bool Valid_Form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;

        if (ddlOrganization.SelectedIndex <= 0)
        {
            lblError.Text = "Please select organization first";
            ddlOrganization.Focus();
            return false;
        }

        if (ddlPanel.SelectedIndex <= 0)
        {
            lblError.Text = "Please select panel first";
            ddlPanel.Focus();
            return false;
        }
        if (txtname.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter class name.(empty is not allowed)";
            txtname.Focus();
            return false;
        }
        return true;
    }

    private void Insert()
    {
        clsBLPanelClass pc = new clsBLPanelClass();

        pc.Name = this.txtname.Text.Trim().Replace("'","''");
        pc.Description = this.txtDescription.Text.Trim().Replace("'", "''");
        pc.Active = this.chkActive.Checked ? "Y" : "N";

        pc.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        pc.EnteredBy = Session["personid"].ToString();

        pc.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pc.ClientID = this.ddlOrganization.SelectedItem.Value.ToString();

        if (pc.Insert())
        {
            Clear_Form();

            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";
            FillGv();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = pc.Error;
        }

    }
    private void Update()
    {
        clsBLPanelClass pc = new clsBLPanelClass();

        pc.ClassID = this.lblID.Text.Trim();
        pc.Name = this.txtname.Text.Trim().Replace("'", "''");
        pc.Description = this.txtDescription.Text.Trim().Replace("'", "''");
        pc.Active = this.chkActive.Checked ? "Y" : "N";

        pc.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        pc.EnteredBy = Session["personid"].ToString();

        pc.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pc.ClientID = this.ddlOrganization.SelectedItem.Value.ToString();

        if (pc.Update())
        {
            Clear_Form();

            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";
            FillGv();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = pc.Error;
        }

    }

    private void FillGv()
    {
        clsBLPanelClass pc = new clsBLPanelClass();

        pc.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        DataView dv = pc.GetAll(1);
        if (dv.Count > 0)
        {
            gvClass.DataSource = dv;
            gvClass.DataBind();
        }
        else
        {
            gvClass.DataSource = null;
            gvClass.DataBind();
        }
    }
    private void FillDDL()
    {
        clsBLPanelClass pc = new clsBLPanelClass();
        SComponents com = new SComponents();
        pc.ClientID = this.ddlOrganization.SelectedItem.Value.ToString();
        DataView dv = pc.GetAll(2);
        com.FillDropDownList(ddlPanel, dv, "name", "panelid");
    }
    private void FillOrd_ddl()
    {
        SComponents com = new SComponents();
        clsBLPanelClass pn = new clsBLPanelClass();
        DataView dv = pn.GetAll(17);

        com.FillDropDownList(ddlOrganization, dv, "name", "orgid");
    }

    protected void ddlPanel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPanel.SelectedIndex > 0)
            FillGv();
        else
        {
            gvClass.DataSource = null;
            gvClass.DataBind();
        }
    }
    protected void gvClass_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvClass.DataKeys[index].Value.ToString();
            txtname.Text = gvClass.Rows[index].Cells[1].Text.Trim().Replace("&nbsp;","");
            txtDescription.Text = gvClass.DataKeys[index].Values[2].ToString();

            chkActive.Checked = ((CheckBox)(gvClass.Rows[index].Cells[2].FindControl("chkGVActive"))).Checked;
            try
            {
                ddlPanel.SelectedItem.Selected = false;
                ddlPanel.Items.FindByValue(gvClass.DataKeys[index].Values[1].ToString()).Selected = true;
            }
            catch { }

            lblStatus.Text = "u";
       
        }
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL();
        gvClass.DataSource = null;
        gvClass.DataBind();
    }
}
