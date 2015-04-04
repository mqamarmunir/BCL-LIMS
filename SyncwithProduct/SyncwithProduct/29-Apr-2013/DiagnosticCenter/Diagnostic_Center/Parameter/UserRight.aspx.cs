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

public partial class userright : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "28";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    lblStatus.Text = "i";
                    Fill_DDlGroup();
                    Fill_DDlUser();
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
        lblError.Text = "";
        lblStatus.Text = "";
        lblID.Text = "";

        ddlGroup.SelectedIndex = -1;
     
        for (int i = ddlPage.Items.Count - 1; i >= 1; i--)
        {
            ddlPage.Items.RemoveAt(i);
        }       

        chkActive.Checked = true;
        gvuser.DataSource = null;
        gvuser.DataBind();
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

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (ddlGroup.SelectedIndex > 0)
        {
            Fill_GvUser();
            Fill_DDl_page();
        }
        else
        {
            gvuser.DataSource = null;
            gvuser.DataBind();

            for (int i = ddlPage.Items.Count - 1; i >= 1; i--)
            {
                ddlPage.Items.RemoveAt(i);
            }          
            
        }

    }
    protected void gvuser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvuser.DataKeys[index].Value.ToString();

            try
            {
                ddlGroup.SelectedItem.Selected = false;
                ddlGroup.Items.FindByValue(gvuser.DataKeys[index].Values[1].ToString()).Selected = true;
            }
            catch{}
            try
            {
                ddlUser.SelectedItem.Selected = false;
                ddlUser.Items.FindByValue(gvuser.DataKeys[index].Values[2].ToString()).Selected = true;
            }
            catch { }
            try
            {
                ddlPage.SelectedItem.Selected = false;
                ddlPage.Items.FindByValue(gvuser.DataKeys[index].Values[3].ToString()).Selected = true;
            }
            catch { }

            chkActive.Checked = ((CheckBox)(gvuser.Rows[index].Cells[3].FindControl("chkGVActive"))).Checked;

            lblStatus.Text = "u";
        }
    }

    private void Fill_DDlGroup()
    {
        clsBLUserRight ur = new clsBLUserRight();
        SComponents com = new SComponents();

        DataView dv = ur.GetALL(1);
        com.FillDropDownList(ddlGroup, dv, "groupname", "groupid");
    }
    private void Fill_DDlUser()
    {
        clsBLUserRight ur = new clsBLUserRight();
        SComponents com = new SComponents();

        DataView dv = ur.GetALL(2);
        com.FillDropDownList(ddlUser, dv, "personname", "personid");
    }
    private void Fill_GvUser()
    {
        clsBLUserRight ur = new clsBLUserRight();
        ur.GroupID = this.ddlGroup.SelectedItem.Value.ToString();

        DataView dv = ur.GetALL(3);
        gvuser.DataSource = dv;
        gvuser.DataBind();
    }
    private void Fill_DDl_page()
    {
        clsBLUserRight ur = new clsBLUserRight();
        SComponents com = new SComponents();
        ur.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
        DataView dv = ur.GetALL(6);
        com.FillDropDownList(ddlPage, dv, "pagename", "pageid");
    }

    private void Insert()
    {
        clsBLUserRight ur = new clsBLUserRight();
        ur.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
        ur.PersonID = this.ddlUser.SelectedItem.Value.ToString();

        ur.Active = this.chkActive.Checked ? "Y" : "N";
        ur.EnteredBy = Session["personid"].ToString();
        ur.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        ur.ClientID = Session["orgid"].ToString();
        ur.DefaultPage = this.ddlPage.SelectedItem.Value.ToString().Equals("-1") ? null : this.ddlPage.SelectedItem.Value.ToString();

        if (ur.Insert())
        {
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";

            chkActive.Checked = true;
            lblStatus.Text = "i";
            lblID.Text = "";

            Fill_GvUser();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = ur.Error;
        }
    }
    private void Update()
    {
        clsBLUserRight ur = new clsBLUserRight();

        ur.RighTID = lblID.Text.Trim();
        ur.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
        ur.PersonID = this.ddlUser.SelectedItem.Value.ToString();

        ur.Active = this.chkActive.Checked ? "Y" : "N";
        ur.EnteredBy = Session["personid"].ToString();
        ur.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        ur.ClientID = Session["orgid"].ToString();
        ur.DefaultPage = this.ddlPage.SelectedItem.Value.ToString().Equals("-1") ? null : this.ddlPage.SelectedItem.Value.ToString();

        if (ur.Update())
        {
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";

            chkActive.Checked = true;
            lblStatus.Text = "i";
            lblID.Text = "";

            Fill_GvUser();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = ur.Error;
        }
    }
    private bool Validate_Form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;

        if (ddlGroup.SelectedIndex <= 0)
        {
            lblError.Text = "Please select group";
            ddlGroup.Focus();
            return false;
        }
        if (ddlUser.SelectedIndex <= 0)
        {
            lblError.Text = "Please select user";
            ddlUser.Focus();
            return false;
        }
        return true;
    }
}
