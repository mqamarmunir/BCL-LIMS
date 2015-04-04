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

public partial class ward : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "53";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Clear_Form();
                    FillBranch();
                    //Fill_GV();
                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
            }
        }
        else
            Response.Redirect("../Login.aspx");
    }

    private void FillBranch()
    {
        clsBLBranch objBr = new clsBLBranch();
        objBr.IndoorFacility = "Y";
        DataView _IndoorBr = objBr.GetAll(3);
        if (_IndoorBr.Count > 0)
        {
            SComponents objCom = new SComponents();
            objCom.FillDropDownList(ddlBranch, _IndoorBr, "Name", "BranchID");
        }

    }

    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Validate_Form())
            return;
        if (lblStatus.Text.Trim().Equals("i"))
            Insert();
        else
            Update();

    }

    private void Clear_Form()
    {
        lblStatus.Text = "i";
        lblID.Text = "";
        lblError.Text = "";

        txtName.Text = "";
        txtAcronym.Text = "";
        txtDescription.Text = "";
        chkActive.Checked = true;
    }
    private bool Validate_Form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;

        if (txtName.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter ward name.(empty is not allowed)";
            txtName.Focus();
            return false;
        }
        if (txtAcronym.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter acronym.(empty is not allowed)";
            txtAcronym.Focus();
            return false;
        }
        else
            return true;
    }

    private void Fill_GV()
    {
        clsBLWard wd = new clsBLWard();
        wd.BranchID = ddlBranch.SelectedValue.ToString().Trim();
        DataView dv = wd.GetAll(1);

        gvWard.DataSource = dv;
        gvWard.DataBind();
    }
    private void Insert()
    {
        clsBLWard wd = new clsBLWard();

        wd.Name = this.txtName.Text.Trim();
        wd.Acronym = this.txtAcronym.Text.Trim();
        wd.Description = this.txtDescription.Text.Trim();
        wd.BranchID = this.ddlBranch.SelectedValue.ToString().Trim();
        wd.Active = this.chkActive.Checked ? "Y" : "N";
        wd.EnteredBy = Session["personid"].ToString();
        wd.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        wd.ClientID = Session["orgid"].ToString();

        if (wd.Insert())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";
            Fill_GV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = wd.Error;
        }

    }
    private void Update()
    {
        clsBLWard wd = new clsBLWard();

        wd.WardID = this.lblID.Text.Trim();
        wd.Name = this.txtName.Text.Trim();
        wd.Acronym = this.txtAcronym.Text.Trim();
        wd.Description = this.txtDescription.Text.Trim();
        wd.BranchID = this.ddlBranch.SelectedValue.ToString().Trim();
        wd.Active = this.chkActive.Checked ? "Y" : "N";
        wd.EnteredBy = Session["personid"].ToString();
        wd.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        wd.ClientID = Session["orgid"].ToString();

        if (wd.Update())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";
            Fill_GV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = wd.Error;
        }

    }

    protected void gvWard_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvWard.DataKeys[index].Value.ToString();
            txtName.Text = gvWard.Rows[index].Cells[1].Text.Trim();
            txtAcronym.Text = gvWard.Rows[index].Cells[2].Text.Trim().Replace("&nbsp;","");
            txtDescription.Text = gvWard.DataKeys[index].Values[1].ToString().Replace("&nbsp;","");

            chkActive.Checked = ((CheckBox)(gvWard.Rows[index].Cells[3].FindControl("chkGvActive"))).Checked;
            lblStatus.Text = "u";
        }
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_GV();

    }
}
