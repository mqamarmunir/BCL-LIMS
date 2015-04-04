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

public partial class MethodTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "17";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillDDlSub();
                   //s FillMethodDDL();
                    FillTestDDL();
                    FillClient();
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
        Clear_Form();
        ddlMethod.SelectedIndex = -1;
        ddlTest.SelectedIndex = -1;

    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!validate_form())
            return;
        if (lblStatus.Text == "i")
            Insert();
        else
            Update();
    }

    private void Clear_Form()
    {
        lblError.Text = "";
        lblID.Text = "";
        lblOldMethodID.Text = "";
        lblStatus.Text = "i";
        txtDorder.Text = "";                  
    }
    private void Insert()
    {
        clsMethodTest mt = new clsMethodTest();

        mt.MethodID = this.ddlMethod.SelectedItem.Value.ToString();
        mt.TestID = this.ddlTest.SelectedItem.Value.ToString();
        mt.Default_Mth = this.chkDefault.Checked ? "Y" : "N";

        mt.Dorder = this.txtDorder.Text.Trim();
        mt.EnteredBy = Session["personid"].ToString();
        mt.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        mt.ClientID = this.ddlClient.SelectedItem.Value.ToString();
            //Session["orgid"].ToString(); // org

        if (mt.Insert())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";
            FillGV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = mt.Error;
        }
    }
    private void Update()
    {
        clsMethodTest mt = new clsMethodTest();

        mt.MethodID = this.ddlMethod.SelectedItem.Value.ToString();
        mt.TestID = this.ddlTest.SelectedItem.Value.ToString();

        mt.Old_TestID = this.lblID.Text.Trim();
        mt.Old_MethodID = this.lblOldMethodID.Text.Trim();
        
        mt.Default_Mth = this.chkDefault.Checked ? "Y" : "N";
        mt.Dorder = this.txtDorder.Text.Trim();

        mt.EnteredBy = Session["personid"].ToString();
        mt.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        mt.ClientID = this.ddlClient.SelectedItem.Value.ToString();
            //Session["orgid"].ToString(); // org

        if (mt.Update())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";
            FillGV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = mt.Error;
        }
    }

    private void FillGV()
    {
        clsMethodTest mt = new clsMethodTest();

        mt.ClientID = this.ddlClient.SelectedItem.Value.ToString();
        mt.MethodID = this.ddlMethod.SelectedItem.Value.ToString();
        DataView dv = mt.GetAll(1);

        if (dv.Count > 0)
        {
            gvMethodTest.DataSource = dv;
            gvMethodTest.DataBind();
        }
        else
        {
            gvMethodTest.DataSource = null;
            gvMethodTest.DataBind();
        }
    }
    private void FillMethodDDL()
    {
        clsMethodTest mt = new clsMethodTest();
        SComponents com = new SComponents();
        mt.SubDeptID = this.ddlSubDept.SelectedItem.Value.ToString();
        DataView dv = mt.GetAll(2);

        com.FillDropDownList(ddlMethod, dv, "name", "methodid");
    }
    private void FillTestDDL()
    {
        clsMethodTest mt = new clsMethodTest();
        SComponents com = new SComponents();

        mt.SubDeptID = ddlSubDept.SelectedValue.ToString().Trim();
        //mt.MethodID = this.ddlMethod.SelectedItem.Value.ToString();
        DataView dv = mt.GetAll(3);

        com.FillDropDownList(ddlTest, dv, "name", "testid");
    }
    private void FillClient()
    {
        clsMethodTest mt = new clsMethodTest();
        SComponents com = new SComponents();

        DataView dv = mt.GetAll(8);
        com.FillDropDownList(ddlClient, dv, "name", "orgid");
    }
    private void FillDDlSub()
    {
        clsMethodTest mt = new clsMethodTest();
        SComponents com = new SComponents();

        DataView dv = mt.GetAll(9);
        com.FillDropDownList(ddlSubDept, dv, "name", "subdepartmentid");
    }

    private bool validate_form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        lblError.Text = "";
        if (ddlMethod.SelectedIndex <= 0)
        {
            lblError.Text = "Please select method first.";
            return false;
        }
        if (ddlTest.SelectedIndex <= 0)
        {
            lblError.Text = "Please select test first.";
            return false;
        }
        if (chkDefault.Checked == true)
        {
            clsMethodTest mt = new clsMethodTest();
            mt.TestID = this.ddlTest.SelectedItem.Value.ToString();
            mt.MethodID = this.ddlMethod.SelectedItem.Value.ToString();
            mt.ClientID = this.ddlClient.SelectedItem.Value.ToString();

            DataView dv = mt.GetAll(7);
            if (!lblOldMethodID.Text.Trim().Equals(""))
                dv.RowFilter = "methodid <> " + lblOldMethodID.Text.Trim();
            if (dv.Count > 0)
            {
                lblError.Text = "Default method already exist against this test";
                return false;
            }
        }
        return true;
    }

    protected void gvMethodTest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";

        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            try
            {
                ddlMethod.SelectedItem.Selected = false;
                ddlMethod.Items.FindByValue(gvMethodTest.DataKeys[index].Value.ToString()).Selected = true;
                lblOldMethodID.Text = gvMethodTest.DataKeys[index].Value.ToString();
            }
            catch { }

            try
            {
                ddlTest.SelectedItem.Selected = false;
                ddlTest.Items.FindByValue(gvMethodTest.DataKeys[index].Values[1].ToString()).Selected = true;
            }
            catch { }
            txtDorder.Text = gvMethodTest.Rows[index].Cells[2].Text.Trim().Replace("&nbsp;","");
            chkDefault.Checked = ((CheckBox)(gvMethodTest.Rows[index].Cells[3].FindControl("chkGvDefault"))).Checked;

            lblID.Text = gvMethodTest.DataKeys[index].Values[1].ToString();
            lblStatus.Text = "u";
        }
    }
    protected void ddlMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (ddlMethod.SelectedIndex > 0)
        {
            FillGV();
        }
        else
        {
            gvMethodTest.DataSource = null; 
            gvMethodTest.DataBind();
        }
    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMethod.SelectedIndex > 0)
            FillGV();
        else
        {
            gvMethodTest.DataSource = null;
            gvMethodTest.DataBind();
        }

    }
    protected void ddlSubDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillMethodDDL();
        FillTestDDL();
    }
}
