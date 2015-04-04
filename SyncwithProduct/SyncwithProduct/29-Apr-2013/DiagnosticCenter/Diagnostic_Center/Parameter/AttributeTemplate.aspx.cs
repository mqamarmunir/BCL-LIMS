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

public partial class AttributeTemplate : System.Web.UI.Page
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
                log.OptionId = "13";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblTemplateId.Text = "";

                    Fill_SubDept();
                    Fill_Test();
                    FillPersonDDL();

                    if (Request.QueryString["rangeid"] !=null)
                    {
                        FillAttributeDDL();
                        clsARange objAR = new clsARange();
                        objAR.RangeId = Request.QueryString["rangeid"].ToString();
                        DataView dv = objAR.GetAll(4);
                        if (dv.Count > 0 && !dv[0]["AttributeId"].ToString().Equals(""))
                        {
                            if (!dv[0]["AttributeId"].ToString().Equals(""))
                            {
                                this.ddlAttribute.SelectedValue = dv[0]["AttributeId"].ToString();
                                Fillgv();
                            }
                        }
                    }

                   // Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlSubDept.Focus();
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

    private void FillAttributeDDL()
    {
        clsAttribute objAtt = new clsAttribute();
        SComponents objScom = new SComponents();
        if (ddlTest.SelectedIndex > 0)
            objAtt.TestId = this.ddlTest.SelectedItem.Value.ToString();

        DataView dv = objAtt.GetAll(4);
        objScom.FillDropDownList(ddlAttribute, dv, "Attribute_Name", "AttributeId", true, false, true);
        this.ddlAttribute.SelectedValue = "-1";
    }
    private void FillPersonDDL()
    {
        clsPersonnel objPer = new clsPersonnel();
        SComponents objScom = new SComponents();        
        DataView dv = objPer.GetAll(4);
        objScom.FillDropDownList(ddlPerson, dv, "Name", "PersonId", true, false, true);
        this.ddlPerson.SelectedValue = "-1";
    }

    private void Fillgv()
    {
        clsATemplate objDC = new clsATemplate();
        if (!this.ddlAttribute.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.AttributeId = this.ddlAttribute.SelectedItem.Value.ToString();
        }
        if (!this.ddlPerson.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.PersonId = this.ddlPerson.SelectedItem.Value.ToString();
        }
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvATemplate.DataSource = dv;
            gvATemplate.DataBind();
            gvATemplate.Visible = true;
        }
        else
        {
            gvATemplate.Visible = false;
        }
    }
    private void Fill_SubDept()
    {
        clsATemplate tem = new clsATemplate();
        SComponents com = new SComponents();

        DataView dv = tem.GetAll(4);

        com.FillDropDownList(ddlSubDept, dv, "name", "subdepartmentid");
    }
    private void Fill_Test()
    {
        clsATemplate tem = new clsATemplate();
        SComponents com = new SComponents();

        if (ddlSubDept.SelectedIndex > 0)
            tem.SubDepartmentID = ddlSubDept.SelectedItem.Value.ToString();
        DataView dv = tem.GetAll(5);
        com.FillDropDownList(ddlTest, dv, "name", "testid");
    }

    private void Insert()
    {
        clsATemplate objDC = new clsATemplate();
        objDC.Description = txtDescription.Text.Trim();       
        if (this.ddlAttribute.SelectedIndex>0 && !this.ddlAttribute.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.AttributeId = this.ddlAttribute.SelectedItem.Value.ToString();
        }
        if (!this.ddlPerson.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.PersonId = this.ddlPerson.SelectedItem.Value.ToString();
        }

        objDC.Defaultt = chkDefault.Checked ? "Y" : "N";
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
        clsATemplate objDC = new clsATemplate();
        objDC.TemplateId = lblTemplateId.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        if (!this.ddlAttribute.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.AttributeId = this.ddlAttribute.SelectedItem.Value.ToString();
        }
        if (!this.ddlPerson.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.PersonId = this.ddlPerson.SelectedItem.Value.ToString();
        }

        objDC.Defaultt = chkDefault.Checked ? "Y" : "N";
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
        txtDescription.Text = "";        
        //this.ddlAttribute.SelectedValue = "-1";
        //this.ddlPerson.SelectedValue = "-1";   
        chkActive.Checked = true;
        chkDefault.Checked = false;
        lblErrMsg.Text = "";              
        lblstatus.Text = "i";
    }
    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.ddlAttribute.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();       
        lblTemplateId.Text = "";

        Fill_SubDept();
        Fill_Test();
        ddlPerson.SelectedIndex = -1;

        gvATemplate.DataSource = null;
        gvATemplate.DataBind();

        for (int i = ddlAttribute.Items.Count - 1; i >= 1; i--)
        {
            ddlAttribute.Items.RemoveAt(i);
        }
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["RangeId"].Equals(""))
        {
            Response.Redirect("AttributeRange.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }
    protected void gvATemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvATemplate.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvATemplate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlAttribute.SelectedValue = "-1";
        this.ddlPerson.SelectedValue = "-1";
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsATemplate objDC = new clsATemplate();
        lblTemplateId.Text = objDC.TemplateId = gvATemplate.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtDescription.Text = dv[0]["Description"].ToString();
            if (!dv[0]["AttributeId"].ToString().Equals(""))
            {
                this.ddlAttribute.SelectedValue = dv[0]["AttributeId"].ToString();
            }

            if (!dv[0]["PersonId"].ToString().Equals(""))
            {
                this.ddlPerson.SelectedValue = dv[0]["PersonId"].ToString();
            }

            this.chkDefault.Checked = (dv[0]["Defaultt"].ToString().Equals("Y")) ? true : false;
            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
        }
    }
    protected void gvATemplate_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("Attribute"))
        {
            if (DGSort == "Attribute_Name ASC")
                DGSort = "Attribute_Name DESC";
            else
                DGSort = "Attribute_Name ASC";

        }

        Fillgv();
    }

    protected void ddlSubDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Test();
        gvATemplate.DataSource = null;
        gvATemplate.DataBind();

        for (int i = ddlAttribute.Items.Count - 1; i >= 1; i--)
        {
            ddlAttribute.Items.RemoveAt(i);
        }
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvATemplate.DataSource = null;
        gvATemplate.DataBind();

        if (ddlTest.SelectedIndex > 0)
            FillAttributeDDL();
        else
            for (int i = ddlAttribute.Items.Count - 1; i >= 1; i--)
            {
                ddlAttribute.Items.RemoveAt(i);
            }
    }
    protected void ddlAttribute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAttribute.SelectedIndex > 0)
            Fillgv();
        else
        {
            gvATemplate.DataSource = null;
            gvATemplate.DataBind();
        }
    }

    protected void gvATemplate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            this.ddlAttribute.SelectedValue = "-1";
            this.ddlPerson.SelectedValue = "-1";
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsATemplate objDC = new clsATemplate();
            lblTemplateId.Text = objDC.TemplateId = gvATemplate.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtDescription.Text = dv[0]["Description"].ToString();
                if (!dv[0]["AttributeId"].ToString().Equals(""))
                {
                    this.ddlAttribute.SelectedValue = dv[0]["AttributeId"].ToString();
                }

                if (!dv[0]["PersonId"].ToString().Equals(""))
                {
                    this.ddlPerson.SelectedValue = dv[0]["PersonId"].ToString();
                }

                this.chkDefault.Checked = (dv[0]["Defaultt"].ToString().Equals("Y")) ? true : false;
                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            }
        }
    }
}
