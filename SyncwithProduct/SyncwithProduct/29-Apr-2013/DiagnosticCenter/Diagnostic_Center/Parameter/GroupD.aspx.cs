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

public partial class GroupD : System.Web.UI.Page
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
                log.OptionId = "9";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblGroupDetailId.Text = "";
                    FillDeptDDL();
                    if (!Session["SubDepartmentId"].Equals(""))
                    {
                        clsSubDepartment objSub = new clsSubDepartment();
                        objSub.SubdepartmentId = Session["SubDepartmentId"].ToString();
                        DataView dv = objSub.GetAll(7);
                        if (dv.Count > 0 && !dv[0]["DepartmentId"].ToString().Equals(""))
                        {
                            this.ddlDepartment.SelectedValue = dv[0]["DepartmentId"].ToString();
                        }
                    }
                    FillGroupDDL();
                    if (!Session["GroupId"].Equals(""))
                    {
                        this.ddlGroup.SelectedValue = Session["GroupId"].ToString();
                    }

                    if (!Session["GroupDetailId"].Equals(""))
                    {
                        this.ddlDepartment.SelectedValue = "-1";
                        this.ddlGroup.SelectedValue = "-1";
                        lblErrMsg.Text = "";
                        lblstatus.Text = "u";
                        clsGroupD objDC = new clsGroupD();
                        lblGroupDetailId.Text = objDC.GroupDetailId = Session["GroupDetailId"].ToString();
                        DataView dv = objDC.GetAll(3);
                        if (dv.Count > 0)
                        {
                            this.txtDOrder.Text = dv[0]["DOrder"].ToString();
                            if (!dv[0]["DepartmentId"].ToString().Equals(""))
                            {
                                this.ddlDepartment.SelectedValue = dv[0]["DepartmentId"].ToString();
                            }

                            if (!dv[0]["GroupId"].ToString().Equals(""))
                            {
                                this.ddlGroup.SelectedValue = dv[0]["GroupId"].ToString();
                            }

                            FillTestDDL();

                            if (!dv[0]["TestId"].ToString().Equals("") && !dv[0]["TestId"].ToString().Equals("0"))
                            {
                                this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
                            }
                        }
                    }
                    else
                    {
                        Session["GroupDetailId"] = "";
                        FillTestDDL();
                        if (!Session["TestId"].Equals(""))
                        {
                            this.ddlTest.SelectedValue = Session["TestId"].ToString();
                        }
                    }
                   // Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlDepartment.Focus();
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

    private void FillDeptDDL()
    {
        clsDepartment objDept = new clsDepartment();
        SComponents objScom = new SComponents();
        DataView dv = objDept.GetAll(4);
        objScom.FillDropDownList(ddlDepartment, dv, "Name", "DepartmentId", true, false, true);
        this.ddlDepartment.SelectedValue = "-1";
    }
    private void FillGroupDDL()
    {
        clsGroupM objGroup = new clsGroupM();
        SComponents objScom = new SComponents();
        DataView dv = objGroup.GetAll(4);
        objScom.FillDropDownList(ddlGroup, dv, "Name", "GroupId", true, false, true);
        this.ddlGroup.SelectedValue = "-1";
    }
    private void FillTestDDL()
    {
        clsTest objTest = new clsTest();
        SComponents objScom = new SComponents();

        if (ddlDepartment.SelectedIndex > 0)
            objTest.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
        DataView dv = objTest.GetAll(4);
        objScom.FillDropDownList(ddlTest, dv, "Test_Name", "TestId", true, false, true);
        this.ddlTest.SelectedValue = "-1";
    }

    private void Fillgv()
    {
        clsGroupD objDC = new clsGroupD();
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
        }
       
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvGroupDetail.DataSource = dv;
            gvGroupDetail.DataBind();
            gvGroupDetail.Visible = true;
            if (ddlGroup.SelectedIndex > 0)
                lblGroupTotal.Text ="Group Total:"+ dv[0]["grouptotal"].ToString();
            else
                lblGroupTotal.Text = "";
        }
        else
        {
            gvGroupDetail.Visible = false;
        }
    }

    private void Insert()
    {
        clsGroupD objDC = new clsGroupD();

        objDC.DOrder = txtDOrder.Text.Trim().Equals("") ? "~!@" : txtDOrder.Text.Trim();        
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
        }

        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
            objDC.Test_Name = this.ddlTest.SelectedItem.Text.Trim();
        }
        objDC.Charges = this.txtRate.Text.Trim().Equals("") ? "0" : txtRate.Text.Trim();
        objDC.Active = this.chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Insert())
        {
            lblGroupDetailId.Text = objDC.GroupDetailId.ToString();
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record save successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objDC.ErrorMessage;
        }
    }
    private void Update()
    {        
        clsGroupD objDC = new clsGroupD();
        objDC.GroupDetailId = lblGroupDetailId.Text.Trim();

        objDC.DOrder = txtDOrder.Text.Trim().Equals("") ? "~!@" : txtDOrder.Text.Trim();   
        if (!this.ddlDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.DepartmentId = this.ddlDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
        }

        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
            objDC.Test_Name = this.ddlTest.SelectedItem.Text.Trim();
        }
        else
        {
            objDC.TestId = "0";
        }
        objDC.Charges = this.txtRate.Text.Trim().Equals("") ? "0" : txtRate.Text.Trim();
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.Active = this.chkActive.Checked ? "Y" : "N";
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Update())
        {
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Update successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objDC.ErrorMessage;
        }
    }

    private void Clear()
    {
        lblErrMsg.Text = "";     
        txtDOrder.Text = "";
        txtRate.Text = "";
            
        lblstatus.Text = "i";
        chkActive.Checked = true;

    }
    private bool Form_Validate()
    {
        lblErrMsg.ForeColor = System.Drawing.Color.Red;
        if (ddlDepartment.SelectedIndex <= 0)
        {
            lblErrMsg.Text = "Please select department";
            ddlDepartment.Focus();
            return false;
        }
        if (ddlGroup.SelectedIndex <= 0)
        {
            lblErrMsg.Text = "Please select group";
            ddlGroup.Focus();
            return false;
        }
        if (ddlTest.SelectedIndex <= 0)
        {
            lblErrMsg.Text = "Please select test";
            ddlTest.Focus();
            return false;
        }
        if (txtRate.Text.Trim().Equals(""))
        {
            lblErrMsg.Text = "Please enter test rate";
            txtRate.Focus();
            return false;
        }
        //if (Convert.ToInt32(txtRate.Text.Trim()) > Convert.ToInt32(txtCharges.Text.Trim()))
        //{
        //    lblErrMsg.Text = "Please enter test rate less than or equal to test charges";
        //    txtRate.Focus();
        //    return false;
        //}
        return true;
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
        FillTestDDL();
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTestDDL();
        Fillgv();
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Fillgv();
        if (ddlTest.SelectedIndex > 0)
        {
            clsGroupD gd = new clsGroupD();
            gd.TestId = this.ddlTest.SelectedItem.Value.ToString();
            DataView dv = gd.GetAll(8);
            if (dv.Count > 0)
                txtCharges.Text = dv[0]["charges"].ToString();
            else
                txtCharges.Text = "0";
        }
        else
        {
            txtCharges.Text = "0";
            txtRate.Text = "0";
        }
    }

    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Form_Validate())
            return;
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.ddlDepartment.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblGroupDetailId.Text = "";
        this.ddlDepartment.SelectedValue = "-1";
        this.ddlGroup.SelectedValue = "-1";
        this.ddlTest.SelectedIndex = -1;

        txtCharges.Text = "0";
        txtRate.Text = "0";
        lblGroupTotal.Text = "";

        gvGroupDetail.DataSource = null;
        gvGroupDetail.DataBind();

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["TestId"].Equals(""))
        {
            Response.Redirect("Test.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }

    protected void gvGroupDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGroupDetail.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvGroupDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlDepartment.SelectedValue = "-1";
        this.ddlGroup.SelectedValue = "-1";        
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsGroupD objDC = new clsGroupD();
        lblGroupDetailId.Text = objDC.GroupDetailId = gvGroupDetail.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {            
            this.txtDOrder.Text = dv[0]["DOrder"].ToString();            
           
                try
                {
                    ddlDepartment.SelectedItem.Selected = false;
                    this.ddlDepartment.Items.FindByValue(dv[0]["DepartmentId"].ToString()).Selected = true;
                }
                catch { }
          
                try
                {
                    ddlGroup.SelectedItem.Selected = false;
                    this.ddlGroup.Items.FindByValue(dv[0]["GroupId"].ToString()).Selected = true;
                }
                catch { }
           
                try
                {
                    ddlTest.SelectedItem.Selected = false;
                    this.ddlTest.Items.FindByValue(dv[0]["TestId"].ToString()).Selected = true;
                }
                catch { }
                txtRate.Text = dv[0]["charges"].ToString();
                txtCharges.Text = dv[0]["testcharges"].ToString();
                lblGroupTotal.Text ="Group Total: "+ dv[0]["grouptotal"].ToString();
        }
    }
    protected void gvGroupDetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("NAME"))
        {
            if (DGSort == "Test_Name ASC")
                DGSort = "Test_Name DESC";
            else
                DGSort = "Test_Name ASC";

        }

        Fillgv();
    }
    protected void lbtnSaveNext_Click(object sender, EventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();

        if (lblErrMsg.ForeColor.Equals(System.Drawing.Color.Green))
        {
            Session["GroupDetailId"] = lblGroupDetailId.Text.Trim();
            Response.Redirect("Attribute.aspx");
        }
    }

    protected void gvGroupDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            this.ddlDepartment.SelectedValue = "-1";
            this.ddlGroup.SelectedValue = "-1";
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsGroupD objDC = new clsGroupD();
            lblGroupDetailId.Text = objDC.GroupDetailId = gvGroupDetail.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtDOrder.Text = dv[0]["DOrder"].ToString();

                try
                {
                    ddlDepartment.SelectedItem.Selected = false;
                    this.ddlDepartment.Items.FindByValue(dv[0]["DepartmentId"].ToString()).Selected = true;
                }
                catch { }

                try
                {
                    ddlGroup.SelectedItem.Selected = false;
                    this.ddlGroup.Items.FindByValue(dv[0]["GroupId"].ToString()).Selected = true;
                }
                catch { }

                try
                {
                    ddlTest.SelectedItem.Selected = false;
                    this.ddlTest.Items.FindByValue(dv[0]["TestId"].ToString()).Selected = true;
                }
                catch { }
                txtRate.Text = dv[0]["charges"].ToString();
                txtCharges.Text = dv[0]["testcharges"].ToString();
                lblGroupTotal.Text = "Group Total: " + dv[0]["grouptotal"].ToString();
            }
        }
    }
}
