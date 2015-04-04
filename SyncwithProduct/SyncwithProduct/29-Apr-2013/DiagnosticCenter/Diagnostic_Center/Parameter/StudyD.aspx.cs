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

public partial class StudyD : System.Web.UI.Page
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
                log.OptionId = "15";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    this.ddlStudy.Focus();
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblSudyDId.Text = "";
                    FillStudyDDL();
                    if (!Session["StudyId"].Equals(""))
                    {
                        this.ddlStudy.SelectedValue = Session["StudyId"].ToString();
                    }
                    FillTestDDL();
                    Fillgv();
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
            Response.Redirect("../Login.aspx");
        }
    }

    private void FillStudyDDL()
    {
        clsStudyM objDept = new clsStudyM();
        SComponents objScom = new SComponents();
        DataView dv = objDept.GetAll(4);
        objScom.FillDropDownList(ddlStudy, dv, "Study_Name", "StudyId", true, false, true);
        this.ddlStudy.SelectedValue = "-1";
    }   

    private void FillTestDDL()
    {
        clsTest objTest = new clsTest();
        SComponents objScom = new SComponents();       
        DataView dv = objTest.GetAll(4);
        objScom.FillDropDownList(ddlTest, dv, "Test_Name", "TestId", true, false, true);
        this.ddlTest.SelectedValue = "-1";
    }

    private void Fillgv()
    {
        clsStudyD objDC = new clsStudyD();
        if (!this.ddlStudy.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.StudyId = this.ddlStudy.SelectedItem.Value.ToString();
        }        
        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
        }
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvStudyDetail.DataSource = dv;
            gvStudyDetail.DataBind();
            gvStudyDetail.Visible = true;
        }
        else
        {
            gvStudyDetail.Visible = false;
        }
    }

    private void Insert()
    {
        clsStudyD objDC = new clsStudyD(); 
       
        if (!this.ddlStudy.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.StudyId = this.ddlStudy.SelectedItem.Value.ToString();
        }       

        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
        }

        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Insert())
        {
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
        clsStudyD objDC = new clsStudyD(); 
        objDC.StudyDId = lblSudyDId.Text.Trim();
        if (!this.ddlStudy.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.StudyId = this.ddlStudy.SelectedItem.Value.ToString();
        }

        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
        }

        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
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
        this.ddlStudy.SelectedValue = "-1";
        this.ddlTest.SelectedValue = "-1";
        lblErrMsg.Text = "";        
        Fillgv();
        lblstatus.Text = "i";
    }

    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.ddlStudy.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblSudyDId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["StudyId"].Equals(""))
        {
            Response.Redirect("StudyM.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }
    protected void ddlStudy_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
    }
    protected void gvStudyDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudyDetail.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvStudyDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlStudy.SelectedValue = "-1";
        this.ddlTest.SelectedValue = "-1";
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsStudyD objDC = new clsStudyD();
        lblSudyDId.Text = objDC.StudyDId = gvStudyDetail.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {            
            if (!dv[0]["StudyId"].ToString().Equals(""))
            {
                this.ddlStudy.SelectedValue = dv[0]["StudyId"].ToString();
            }                     

            if (!dv[0]["TestId"].ToString().Equals("") && !dv[0]["TestId"].ToString().Equals("0"))
            {
                this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
            }

            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
        }
    }
    protected void gvStudyDetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("NAME"))
        {
            if (DGSort == "Study_Name ASC")
                DGSort = "Study_Name DESC";
            else
                DGSort = "Study_Name ASC";

        }

        Fillgv();
    }

    protected void gvStudyDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index= Convert.ToInt32(e.CommandArgument);
            this.ddlStudy.SelectedValue = "-1";
            this.ddlTest.SelectedValue = "-1";
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsStudyD objDC = new clsStudyD();
            lblSudyDId.Text = objDC.StudyDId = gvStudyDetail.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                if (!dv[0]["StudyId"].ToString().Equals(""))
                {
                    this.ddlStudy.SelectedValue = dv[0]["StudyId"].ToString();
                }

                if (!dv[0]["TestId"].ToString().Equals("") && !dv[0]["TestId"].ToString().Equals("0"))
                {
                    this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
                }

                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            }
        }
    }
}
