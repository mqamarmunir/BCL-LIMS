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

public partial class MainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
       
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Pasword"] != null)
                {
                    pnlPassword.Visible = true;
                    clsLogin log = new clsLogin();
                    log.PersonId = Session["personid"].ToString();
                    DataView dv = log.GetLogin(4);
                    lblPassword.Text = dv[0]["pasword"].ToString();
                }
                else
                {
                    pnlPassword.Visible = false;
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
        pnlPassword.Visible = false;
        txtCnFrmPas.Text = "";
        txtNewPass.Text = "";
        txtOldPass.Text = "";
        lblError.Text = "";
        lblPassword.Text = "";
    }
    private bool Valid()
    {
        if (txtOldPass.Text.Trim().Equals(""))
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please enter old password";
            return false;
        }
        if (txtNewPass.Text.Trim().Equals(""))
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please enter new password";
            return false;
        }
        if (txtCnFrmPas.Text.Trim().Equals(""))
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please enter confirm password";
            return false;
        }
        if (txtOldPass.Text.Trim() != lblPassword.Text.Trim())
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please enter valid old password";
            return false;

        }
        else if (txtCnFrmPas.Text.Trim() != txtNewPass.Text.Trim())
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Your new password does not match with confirm password";
            return false;
        }
        return true;
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Valid())
            return;
        clsLogin log = new clsLogin();
        log.Password = this.txtNewPass.Text.Trim();
        log.PersonId = this.Session["personid"].ToString();
        if (log.Update_Password())
        {
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Password has been changed successfully";
            lblPassword.Text = this.txtNewPass.Text.Trim();

        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = log.ErrorMessage;
        }

    }
}
