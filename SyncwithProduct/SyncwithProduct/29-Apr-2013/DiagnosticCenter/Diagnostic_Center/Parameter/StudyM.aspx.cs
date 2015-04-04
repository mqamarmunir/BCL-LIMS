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

public partial class StudyM : System.Web.UI.Page
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
                log.OptionId = "14";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtStudy_Name.Focus();
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblStudyId.Text = "";
                    if (!Session["StudyId"].Equals(""))
                    {
                        lblErrMsg.Text = "";
                        lblstatus.Text = "u";
                        clsStudyM objDC = new clsStudyM();
                        lblStudyId.Text = objDC.StudyId = Session["StudyId"].ToString();
                        DataView dv = objDC.GetAll(3);
                        if (dv.Count > 0)
                        {
                            this.txtStudy_Name.Text = dv[0]["Study_Name"].ToString();
                            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                            this.txtDescription.Text = dv[0]["Description"].ToString();
                            this.txtTotal_Charges.Text = dv[0]["Total_Charges"].ToString();
                            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                        }
                    }
                    Session["StudyId"] = "";
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

    private void Fillgv()
    {
        clsStudyM objDC = new clsStudyM();
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvStudy.DataSource = dv;
            gvStudy.DataBind();
            gvStudy.Visible = true;
        }
        else
        {
            gvStudy.Visible = false;
        }
    }

    private void Insert()
    {
        clsStudyM objDC = new clsStudyM();
        objDC.Study_Name = txtStudy_Name.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        objDC.Total_Charges = txtTotal_Charges.Text.Trim();
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Insert())
        {
            lblStudyId.Text = objDC.StudyId.ToString();
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
        clsStudyM objDC = new clsStudyM();
        objDC.StudyId = lblStudyId.Text.Trim();
        objDC.Study_Name = txtStudy_Name.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        objDC.Total_Charges = txtTotal_Charges.Text.Trim();
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
        txtStudy_Name.Text = "";
        txtAcronym.Text = "";
        txtTotal_Charges.Text = "";
        txtDescription.Text = "";
        chkActive.Checked = true;
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
        this.txtStudy_Name.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblStudyId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void gvStudy_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStudy.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvStudy_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsStudyM objDC = new clsStudyM();
        lblStudyId.Text = objDC.StudyId = gvStudy.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtStudy_Name.Text = dv[0]["Study_Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtDescription.Text = dv[0]["Description"].ToString();
            this.txtTotal_Charges.Text = dv[0]["Total_Charges"].ToString();
            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
        }
    }
    protected void gvStudy_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void lbtnSaveNext_Click(object sender, EventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();

        if (lblErrMsg.ForeColor.Equals(System.Drawing.Color.Green))
        {
            Session["StudyId"] = lblStudyId.Text.Trim();
            Response.Redirect("StudyD.aspx");
        }
    }

    protected void gvStudy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsStudyM objDC = new clsStudyM();
            lblStudyId.Text = objDC.StudyId = gvStudy.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtStudy_Name.Text = dv[0]["Study_Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtDescription.Text = dv[0]["Description"].ToString();
                this.txtTotal_Charges.Text = dv[0]["Total_Charges"].ToString();
                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            }
        }
    }
}
