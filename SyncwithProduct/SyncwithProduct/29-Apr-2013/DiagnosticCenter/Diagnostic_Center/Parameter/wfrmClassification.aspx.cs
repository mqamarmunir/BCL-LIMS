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

public partial class classification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "21";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillTestDDL();
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

        txtDorder.Text = "";
        txtName.Text = "";

        lblError.Text = "";
        chkActive.Checked = true;
       
    }
    private bool Validate_Form()
    {
        lblError.Text = "";
        lblError.ForeColor = System.Drawing.Color.Red;

        if (ddlTest.SelectedIndex <= 0)
        {
            lblError.Text = "Please select Test first";
            return false;
        }
        if (txtName.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter classification Name.(empty is not allowed)";
            return false;
        }
        return true;
    }
    private void FillTestDDL()
    {
        clsBLClassification cl = new clsBLClassification();
        SComponents com = new SComponents();
        DataView dv = cl.GetAll(2);

        com.FillDropDownList(ddlTest, dv, "name", "testid");
    }

    private void Insert()
    {
        clsBLClassification cl = new clsBLClassification();

        cl.TestID = this.ddlTest.SelectedItem.Value.ToString();
        cl.Name = this.txtName.Text.Trim().Replace("'","''");
        cl.DOrder = this.txtDorder.Text.Trim().Replace("'","''");

        cl.Active = this.chkActive.Checked ? "Y" : "N";
        cl.EnteredBy = Session["personid"].ToString();
        cl.EnteredoN = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        cl.ClientID = Session["orgid"].ToString(); // org

        if (cl.Insert())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";
            FillGv();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = cl.Error;
        }
    }
    private void Update()
    {
        clsBLClassification cl = new clsBLClassification();

        cl.ClassID = this.lblID.Text.Trim();
        cl.TestID = this.ddlTest.SelectedItem.Value.ToString();
        cl.Name = this.txtName.Text.Trim().Replace("'", "''");
        cl.DOrder = this.txtDorder.Text.Trim().Replace("'", "''");

        cl.Active = this.chkActive.Checked ? "Y" : "N";
        cl.EnteredBy = Session["personid"].ToString();
        cl.EnteredoN = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        cl.ClientID = Session["orgid"].ToString(); // org

        if (cl.update())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";
            FillGv();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = cl.Error;
        }
    }
    private void FillGv()
    {
        clsBLClassification cl = new clsBLClassification();

        cl.TestID = this.ddlTest.SelectedItem.Value.ToString();
        DataView dv = cl.GetAll(1);

        if (dv.Count > 0)
        {
            gvTestClass.DataSource = dv;
            gvTestClass.DataBind();
        }
        else
        {
            gvTestClass.DataSource = null;
            gvTestClass.DataBind();
        }
    }


    protected void gvTestClass_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";

        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvTestClass.DataKeys[index].Value.ToString();
            txtName.Text = gvTestClass.Rows[index].Cells[2].Text.Trim();

            txtDorder.Text = gvTestClass.Rows[index].Cells[3].Text.Trim().Replace("&nbsp;","");
            chkActive.Checked = ((CheckBox)(gvTestClass.Rows[index].Cells[4].FindControl("chkGVActive"))).Checked;

            try
            {
                ddlTest.SelectedItem.Selected = false;
                ddlTest.Items.FindByValue(gvTestClass.DataKeys[index].Values[1].ToString()).Selected = true;
            }
            catch { }

            lblStatus.Text = "u";
        }
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTest.SelectedIndex > 0)
            FillGv();
        else
        {
            gvTestClass.DataSource = null;
            gvTestClass.DataBind();
        }
    }
}
