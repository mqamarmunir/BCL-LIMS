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

public partial class transaction_wfrmBranchTestSearch : System.Web.UI.Page
{
    private static string DGSort = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["PersonId"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "10";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                  //  FillBranchDDL();
                    FillSubDepartmentDDL();
                    FillGroupsDDL();
                   DGSort = "";
                  
                    this.Title = this.Session["PersonName"].ToString();
                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../NewLogin.aspx");
        }
    }
    private void fillGVTestSearch()
    {
        clsTest objDC = new clsTest();
        //if (!this.ddlBranch.SelectedItem.Value.ToString().Equals("-1"))
        //{
        //    objDC.ClientId = this.ddlBranch.SelectedItem.Value.ToString();
        //}
        if (!this.ddlsubDept.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SubdepartmentId = this.ddlsubDept.SelectedItem.Value.ToString();
        }
        if (this.ddltestgroup.SelectedIndex > 0)
        {
            objDC.GroupId= this.ddltestgroup.SelectedItem.Value.ToString();
        }
        if (!this.txtItemName.Text.ToString().Equals(""))
        {
            objDC.Test_Name = this.txtItemName.Text.ToString();
        }
       
       

       // clsTest objDC = new clsTest();
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvTest.DataSource = dv;
            gvTest.DataBind();
            gvTest.Visible = true;
        }
        else
        {
            gvTest.DataSource = null;
            gvTest.DataBind();
            gvTest.Visible = true;
        }
    }
    //private void FillBranchDDL()
    //{
    //    clsTest te = new clsTest();
    //    SComponents com = new SComponents();

    //   // te.SubdepartmentId = this.ddlBranch.SelectedItem.Value.ToString().Replace("-1", "");
    //    DataView dv = te.GetAll(16);
      
    //    com.FillDropDownList(ddlBranch, dv, "name", "parentid");
       
    //}
    private void FillSubDepartmentDDL()
    {
        clsTest te = new clsTest();
        SComponents com = new SComponents();

       // te.ClientId = this.ddlBranch.SelectedItem.Value.ToString().Replace("-1", "");
        DataView dv = te.GetAll(17);

        com.FillDropDownList(ddlsubDept, dv, "name", "subdepartmentid");
    }
    private void FillGroupsDDL()
    {
        clsTest te = new clsTest();
        SComponents com = new SComponents();

        //te.ClientId = this.ddlBranch.SelectedItem.Value.ToString().Replace("-1", "");
        DataView dv = te.GetAll(18);

        com.FillDropDownList(ddltestgroup, dv, "name", "groupid");
    }
    
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        fillGVTestSearch();
    }
   
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        //ddlBranch.SelectedIndex = -1;
        ddlsubDept.SelectedIndex = -1;
        ddltestgroup.SelectedIndex = -1;
        txtItemName.Text = "";
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../transaction/wfrmCashierEntry.aspx");
    }
    protected void gvTest_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("NAME"))
        {
            if (DGSort == "Test_Name ASC")
                DGSort = "Test_Name DESC";
            else
                DGSort = "Test_Name ASC";

        }
        //NAME
        if (e.SortExpression.Equals("subname"))
        {
            if (DGSort == "subname ASC")
                DGSort = "subname DESC";
            else
                DGSort = "subname ASC";

        }
        fillGVTestSearch();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        fillGVTestSearch();
    }
}