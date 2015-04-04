using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    private static string mode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["PersonId"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "63";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {

                    //lblstatus.Text = "i";

                    FillDDLSubDepartment();
                    //FillDDLBranches();
                    //FillGv();

                    FillGV();

                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
            }

        }
    }

    private void FillDDLSubDepartment()
    {
        clsSubDepartment obj_SubDep = new clsSubDepartment();
        DataView dv_SubDep = obj_SubDep.GetAll(8);
        obj_SubDep = null;
        if (dv_SubDep.Count > 0)
        {
            SComponents objScom = new SComponents();
            objScom.FillDropDownList(ddlSubDepartment, dv_SubDep, "Name", "SubDepartmentID", true, false, true);
            objScom = null;
            this.ddlSubDepartment.SelectedValue = "-1";
        }
        dv_SubDep.Dispose();
    }

    protected void gvPrices_RowEditing(object sender, GridViewEditEventArgs e)
    {
        FillForm(e.NewEditIndex);
    }
    private void FillForm(int index)
    {
        ddlSubDepartment.ClearSelection();
        ddlSubDepartment.Items.FindByValue(gvPrices.DataKeys[index].Values[2].ToString()).Selected = true;

        FillDDLTests();

        ddlTest.ClearSelection();
        ddlTest.Items.FindByValue(gvPrices.DataKeys[index].Values[0].ToString()).Selected = true;

        txtvendpr.Text = gvPrices.Rows[index].Cells[2].Text.Trim();
        txtoffpr.Text = gvPrices.Rows[index].Cells[3].Text.Trim();

 
    }

    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBLBranchTestD obj_brTests = new clsBLBranchTestD();
        obj_brTests.Offeredprice = txtoffpr.Text.Trim();
        obj_brTests.BranchID = Session["BranchID"].ToString();
        obj_brTests.TestID = ddlTest.SelectedValue.ToString().Trim();
        if (obj_brTests.updateofferedprice())
        {
            this.lblErrMsg.Text = "<font color='green'>Record Updated Successfully.</font>";
        }
        else
        {
            this.lblErrMsg.Text = obj_brTests.ErrorMessage;
        }
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubDepartment.SelectedValue.ToString() != "-1")
        {

            FillDDLTests();
            FillGV();
        }
        else
        {
          
        }
    }

    private void FillDDLTests()
    {
        clsBLBranchTestD obj_brTests = new clsBLBranchTestD();
        obj_brTests.SubDepartmentID = ddlSubDepartment.SelectedValue.ToString().Trim();
        obj_brTests.BranchID = Session["BranchID"].ToString();
        DataView br_tests = obj_brTests.GetAll(2);
        if (br_tests.Count > 0)
        {
            SComponents obj_comp = new SComponents();
            obj_comp.FillDropDownList(ddlTest, br_tests, "Name", "TestID", true, false, true);
            br_tests.Dispose();
            obj_comp = null;
            ddlTest.SelectedValue= "-1";
        }
        else
        {
            br_tests.Dispose();
            lblErrMsg.Text = "No Test Found.";
        }

        
    }

    private void FillGV()
    {
        clsBLBranchTestD obj_BrTests = new clsBLBranchTestD();
        obj_BrTests.BranchID = Session["BranchID"].ToString();
        DataView dv_Tests = obj_BrTests.GetAll(1);
        if (dv_Tests.Count > 0)
        {
            gvPrices.DataSource = dv_Tests;
            gvPrices.DataBind();
        }
 
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTest.SelectedValue.ToString() != "-1")
        {
            FillPrices();

        }
    }

    private void FillPrices()
    {
        clsBLBranchTestD obj_brtests = new clsBLBranchTestD();
        obj_brtests.TestID = ddlTest.SelectedValue.ToString();
        obj_brtests.BranchID = Session["BranchID"].ToString();
        DataView dv_price = obj_brtests.GetAll(3);
        if (dv_price.Count > 0)
        {
            txtvendpr.Text = dv_price[0]["TestPriceVend"].ToString().Trim();
            txtoffpr.Text = dv_price[0]["TestPriceOff"].ToString().Trim();
        }
        else
        { 
            txtvendpr.Text = "";
            txtoffpr.Text = "";

        }

        
    }

}