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

public partial class test_c_p : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "39";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    lblStatus.Text = "i";

                    fill_Person();
                    fill_SubDept();
                    fill_Test();
                }
                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowed.aspx");
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
        clear_form();
        ddlSubdept.SelectedIndex = -1;
        fill_Test();
        gvTemplate.DataSource = null;
        gvTemplate.DataBind();
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

    private void Insert()
    {
        clsBLTest_C_P cp = new clsBLTest_C_P();

        cp.TestID = this.ddlTest.SelectedItem.Value.ToString();
        cp.PersonID = this.ddlPerson.SelectedItem.Value.ToString().Replace("-1","~!@");
        cp.Active = chkActive.Checked ? "Y" : "N";

        cp.Coment = this.txtComment.Text.Trim().Replace("'","''");
        cp.Opinion = this.txtOpinion.Text.Trim().Replace("'","''");

        cp.EnteredBy = Session["personid"].ToString();
        cp.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        cp.ClientID = Session["orgid"].ToString();

        if (cp.Insert())
        {
            clear_form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Test template has been saved successfully";
            Fill_GV();          
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = cp.Error;
        }
    }
    private void Update()
    {
        clsBLTest_C_P cp = new clsBLTest_C_P();

        cp.CPID = this.lblID.Text.Trim();
        cp.TestID = this.ddlTest.SelectedItem.Value.ToString();
        cp.PersonID = this.ddlPerson.SelectedItem.Value.ToString().Replace("-1", "~!@"); 
        cp.Active = chkActive.Checked ? "Y" : "N";

        cp.Coment = this.txtComment.Text.Trim().Replace("'", "''");
        cp.Opinion = this.txtOpinion.Text.Trim().Replace("'", "''");

        cp.EnteredBy = Session["personid"].ToString();
        cp.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        cp.ClientID = Session["orgid"].ToString();

        if (cp.Update())
        {
            clear_form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Test template has been updated successfully";
            Fill_GV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = cp.Error;
        }
    }

    private bool Validate_Form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        if (ddlTest.SelectedIndex <= 0)
        {
            lblError.Text = "Please select test";
            ddlTest.Focus();
            return false;
        }
        if (txtComment.Text.Trim().Equals("") && txtOpinion.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter comment or opinion.both empty are not allowed";
            txtComment.Focus();
            return false;
        }
        return true;
    }
    private void clear_form()
    {
        lblID.Text = "";
        lblStatus.Text = "i";
        lblError.Text = "";

        ddlPerson.SelectedIndex = -1;
        txtComment.Text = "";
        txtOpinion.Text = "";
        chkActive.Checked = true;
    }
    private void Fill_GV()
    {
        clsBLTest_C_P cp = new clsBLTest_C_P();
        cp.TestID = this.ddlTest.SelectedItem.Value.ToString();
        DataView dv = cp.GetAll(1);

        gvTemplate.DataSource = dv;
        gvTemplate.DataBind();
    }

    private void fill_Test()
    {
        clsBLTest_C_P cp = new clsBLTest_C_P();
        SComponents com = new SComponents();

        if (ddlSubdept.SelectedIndex > 0)
            cp.SubDeptID = this.ddlSubdept.SelectedItem.Value.ToString();
        DataView dv = cp.GetAll(2);
        com.FillDropDownList(ddlTest, dv, "test_name", "testid");        
    }
    private void fill_Person()
    {
        clsBLTest_C_P cp = new clsBLTest_C_P();
        SComponents com = new SComponents();
               
        DataView dv = cp.GetAll(4);
        com.FillDropDownList(ddlPerson, dv, "name", "personid");
    }
    private void fill_SubDept()
    {
        clsBLTest_C_P cp = new clsBLTest_C_P();
        SComponents com = new SComponents();

        DataView dv = cp.GetAll(3);
        com.FillDropDownList(ddlSubdept, dv, "name", "subdepartmentid");
    }


    protected void ddlSubdept_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_Test();
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTest.SelectedIndex > 0)
            Fill_GV();
        else
        {
            gvTemplate.DataSource = null;
            gvTemplate.DataBind();
        }
    }
    protected void gvTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblID.Text = gvTemplate.DataKeys[index].Value.ToString();
            try
            {
                ddlPerson.SelectedItem.Selected = false;
                ddlPerson.Items.FindByValue(gvTemplate.DataKeys[index].Values[1].ToString()).Selected = true;
            }
            catch { }
            try
            {
                ddlTest.SelectedItem.Selected = false;
                ddlTest.Items.FindByValue(gvTemplate.DataKeys[index].Values[2].ToString()).Selected = true;
            }
            catch { }

            txtComment.Text = gvTemplate.Rows[index].Cells[2].Text.Trim().Replace("&nbsp;","");
            txtOpinion.Text = gvTemplate.Rows[index].Cells[3].Text.Trim().Replace("&nbsp;", "");
            chkActive.Checked = ((CheckBox)(gvTemplate.Rows[index].Cells[4].FindControl("chkgvActive"))).Checked;

            lblStatus.Text = "u";

        }
    }
}
