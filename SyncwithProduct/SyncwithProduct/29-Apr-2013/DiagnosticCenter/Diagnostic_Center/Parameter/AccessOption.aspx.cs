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

public partial class AccessOption : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!IsPostBack)
        {
            if (!Session["personid"].ToString().Equals(""))
            {
                clsLogin log = new clsLogin();
                log.OptionId = "27";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {

                    this.ddlType.SelectedValue = "-1";
                    FillDG();
                    this.txtOptionName.Focus();
                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }

               
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        this.ddlType.SelectedValue = "-1";
        RefreshForm();                
    }

    private void RefreshForm()
    {
        try
        {
            this.lblSapsId.Text = "";
            this.txtOptionName.Text = "";
            this.txtDescription.Text = "";      
            this.chkActive.Checked = true;
            this.chkEventActive.Checked = false;
            this.lblSave.Text = "i";
            this.lblErrMsg.Text = "";
            FillDG();
            this.txtOptionName.Focus();
        }
        catch { }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!this.ddlType.SelectedItem.Value.Equals("-1") && !this.txtOptionName.Text.ToString().Equals(""))
        {
            if (lblSave.Text.Equals("i"))
                Insert();
            else
                Update();
        }
        else
        {
            lblErrMsg.Text = "Empty not allowed, Please Enter Option Name and Select Type of Option.";
        }
    }

    private void Insert()
    {
        clsAccessOption objSAPS = new clsAccessOption();
        objSAPS.OptionName = txtOptionName.Text.Trim();
        objSAPS.Description = txtDescription.Text.Trim();
        objSAPS.Type = this.ddlType.SelectedItem.Value.ToString();
        objSAPS.Active = this.chkActive.Checked ? "Y" : "N";
        objSAPS.EventActive = this.chkEventActive.Checked ? "Y" : "N";
        objSAPS.Enteredby = Session["personid"].ToString();
        objSAPS.Enteredon = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        if (objSAPS.Insert())
        {
            RefreshForm();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Saved Successfully.";
        }

        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objSAPS.ErrorMessage;
        }

    }

    private void Update()
    {
        clsAccessOption objSAPS = new clsAccessOption();
        objSAPS.OptionId = lblSapsId.Text;
        objSAPS.OptionName = txtOptionName.Text.Trim();
        objSAPS.Description = txtDescription.Text.Trim();
        objSAPS.Type = this.ddlType.SelectedItem.Value.ToString();
        objSAPS.Active = this.chkActive.Checked ? "Y" : "N";
        objSAPS.EventActive = this.chkEventActive.Checked ? "Y" : "N";
        objSAPS.Enteredby = Session["personid"].ToString();
        objSAPS.Enteredon = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        if (objSAPS.Update())
        {
            RefreshForm();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Updated Successfully.";
        }

        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objSAPS.ErrorMessage;
        }
    }

    private void FillDG()
    {
        clsAccessOption objSAPS = new clsAccessOption();
        if (!this.ddlType.SelectedItem.Value.ToString().Equals("-1"))
        {
            objSAPS.Type = this.ddlType.SelectedItem.Value.ToString();
        }
        this.dg.DataSource = objSAPS.GetAll(1);
        this.dg.DataBind();

    }
    protected void dg_RowEditing(object sender, GridViewEditEventArgs e)
    {

        lblSave.Text = "u";
        this.txtOptionName.Focus();
        clsAccessOption objSAPS = new clsAccessOption();
        lblSapsId.Text = objSAPS.OptionId = this.dg.DataKeys[e.NewEditIndex][0].ToString();

        DataView dv = objSAPS.GetAll(3);

        if (dv.Count > 0)
        {
            this.txtOptionName.Text = dv[0]["OptionName"].ToString();
            this.txtDescription.Text = dv[0]["Description"].ToString();
            this.ddlType.SelectedValue = dv[0]["Type"].ToString();
            this.chkActive.Checked = dv[0]["Active"].ToString().Equals("Y") ? true : false;
            this.chkEventActive.Checked = dv[0]["EventActive"].ToString().Equals("Y") ? true : false;
        }

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDG();
    }

    protected void dg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblSave.Text = "u";
            this.txtOptionName.Focus();
            clsAccessOption objSAPS = new clsAccessOption();
            lblSapsId.Text = objSAPS.OptionId = this.dg.DataKeys[index][0].ToString();

            DataView dv = objSAPS.GetAll(3);

            if (dv.Count > 0)
            {
                this.txtOptionName.Text = dv[0]["OptionName"].ToString();
                this.txtDescription.Text = dv[0]["Description"].ToString();
                this.ddlType.SelectedValue = dv[0]["Type"].ToString();
                this.chkActive.Checked = dv[0]["Active"].ToString().Equals("Y") ? true : false;
                this.chkEventActive.Checked = dv[0]["EventActive"].ToString().Equals("Y") ? true : false;
            }
        }
    }
}
