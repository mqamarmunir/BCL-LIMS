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

public partial class AttributeRange : System.Web.UI.Page
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
                log.OptionId = "12";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblAttributeRange.Text = "";
                    FillSubDeptDDL();
                    FillGroupDDL();
                    //FillMethod();
                    //   FillTestDDL();
                    //     FillAttributeDDL();

                    if (Request.QueryString["attribid"] != null)//Session["AttributeId"].Equals("")
                    {
                        clsAttribute objAtt = new clsAttribute();
                        objAtt.AttributeId = Request.QueryString["attribid"].ToString();
                        //Session["AttributeId"].ToString();
                        DataView dv = objAtt.GetAll(7);
                        if (dv.Count > 0)
                        {
                            if (!dv[0]["SubDepartmentId"].ToString().Equals(""))
                            {
                                this.ddlSubDepartment.SelectedValue = dv[0]["SubDepartmentId"].ToString();
                            }
                            //if (!dv[0]["GroupId"].ToString().Equals(""))
                            //{
                            //    this.ddlGroup.SelectedValue = dv[0]["GroupId"].ToString();
                            //}091221
                            FillTestDDL();
                            if (!dv[0]["TestId"].ToString().Equals(""))
                            {
                                this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
                            }
                        }
                        else
                        {
                            FillTestDDL();
                        }

                        FillAttributeDDL();
                        if (Request.QueryString["attribid"].ToString() != null)
                        {
                            this.ddlAttribute.SelectedValue = Request.QueryString["attribid"].ToString();
                            //Session["AttributeId"].ToString().ToString();
                        }
                        Fillgv();
                    }
                    else
                    {
                        FillTestDDL();
                        FillAttributeDDL();
                    }
                    Session["RangeId"] = "";
                    // Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlSubDepartment.Focus();
                    FillMethod();
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

    private void FillSubDeptDDL()
    {
        clsSubDepartment objDept = new clsSubDepartment();
        SComponents objScom = new SComponents();
        DataView dv = objDept.GetAll(4);
        objScom.FillDropDownList(ddlSubDepartment, dv, "Name", "SubdepartmentId", true, false, true);
        this.ddlSubDepartment.SelectedValue = "-1";
    }
    private void FillGroupDDL()
    {
        clsARange objGroup = new clsARange();
        SComponents objScom = new SComponents();

        objGroup.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        DataView dv = objGroup.GetAll(7);
        objScom.FillDropDownList(ddlGroup, dv, "Name", "GroupId");        
    }

    private void FillTestDDL()
    {
        clsARange objTest = new clsARange();
        SComponents objScom = new SComponents();
        DataView dv;
        objTest.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        if (ddlGroup.SelectedIndex > 0)
        {
            objTest.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
            dv = objTest.GetAll(11);
        }
        else
            dv = objTest.GetAll(8);
        objScom.FillDropDownList(ddlTest, dv, "Test_Name", "TestId");
        
    }

    private void FillAttributeDDL()
    {
        clsARange objAtt = new clsARange();
        SComponents objScom = new SComponents();
        
        objAtt.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        if(ddlGroup.SelectedIndex>0)
            objAtt.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
        
        objAtt.TestId = this.ddlTest.SelectedItem.Value.ToString();
        
        DataView dv = objAtt.GetAll(9);
        objScom.FillDropDownList(ddlAttribute, dv, "Attribute_Name", "AttributeId");        
    }
    private void FillMethod()
    {
        clsARange rd = new clsARange();
        SComponents com = new SComponents();

        rd.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        DataView dv = rd.GetAll(5);
        com.FillDropDownList(ddlMethod, dv, "name", "methodid");
    }

    private void Fillgv()
    {
        clsARange objDC = new clsARange();
        if (!this.ddlSubDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
        }
        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
        }
        if (!this.ddlAttribute.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.AttributeId = this.ddlAttribute.SelectedItem.Value.ToString();
        }
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvAttributeRange.DataSource = dv;
            gvAttributeRange.DataBind();
            gvAttributeRange.Visible = true;
        }
        else
        {
            gvAttributeRange.Visible = false;
        }
    }
    private void Clear()
    {
        txtAUnit.Text = "";
        txtAge_Min.Text = "";
        txtAge_Max.Text = "";

        txtMin_Value.Text = "";
        txtMax_Value.Text = "";

        txtMin_Panic.Text = "";
        txtMax_Panic.Text = "";
        txtDescription.Text = "";
        // txtDescription.Text = "";
        txtSIunit.Text = "";
        txtconversionfactor.Text = "";
        
        lblErrMsg.Text = "";        
        lblstatus.Text = "i";
        chkActive.Checked = true;
    }

    private void Insert()
    {
        clsARange objDC = new clsARange();        
       
            objDC.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();  
            if(ddlGroup.SelectedIndex>0)
                objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
        
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
        
            objDC.AttributeId = this.ddlAttribute.SelectedItem.Value.ToString();        
            objDC.Sex = this.ddlSex.SelectedItem.Value.ToString();        
            objDC.MethodID = this.ddlMethod.SelectedItem.Value.ToString();

            objDC.AUnit = txtAUnit.Text.Trim();
            objDC.Active = this.chkActive.Checked ? "Y" : "N";
            objDC.Age_Min =GetAge(txtAge_Min.Text.Trim());        
            objDC.Age_Max =GetAge(txtAge_Max.Text.Trim());
        
            objDC.Max_Value = txtMax_Value.Text.Trim();
            objDC.Min_Value = txtMin_Value.Text.Trim();
            objDC.Min_Panic_Value = txtMin_Panic.Text.Trim().Equals("") ? "0" : txtMin_Panic.Text.Trim();
            objDC.Max_Panic_Value = txtMax_Panic.Text.Trim().Equals("") ? "0" : txtMax_Panic.Text.Trim();
            objDC.Description = this.txtDescription.Text.Replace("\n","").Replace("\r","").Trim();
            objDC.ASIUnit = txtSIunit.Text.Trim();
            objDC.Conversionfactor = txtconversionfactor.Text.Trim();

            objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objDC.Enteredby = Session["PersonId"].ToString();
            objDC.ClientId = Session["orgid"].ToString(); // org
            if (objDC.Insert())
            {
                lblAttributeRange.Text = objDC.RangeId.ToString();
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
        clsARange objDC = new clsARange();  

        objDC.RangeId = lblAttributeRange.Text.Trim();       
        objDC.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        if (ddlGroup.SelectedIndex > 0)
            objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
       
        objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();             
        objDC.AttributeId = this.ddlAttribute.SelectedItem.Value.ToString();              
        objDC.Sex = this.ddlSex.SelectedItem.Value.ToString();
        
       
        objDC.MethodID = this.ddlMethod.SelectedItem.Value.ToString();    
        objDC.AUnit = txtAUnit.Text.Trim();
        objDC.Active = this.chkActive.Checked ? "Y" : "N";

        objDC.Age_Min = GetAge(txtAge_Min.Text.Trim());
        objDC.Age_Max = GetAge(txtAge_Max.Text.Trim());        

        objDC.Max_Value = txtMax_Value.Text.Trim();
        objDC.Min_Value = txtMin_Value.Text.Trim();
        objDC.Min_Panic_Value = txtMin_Panic.Text.Trim().Equals("") ? "0" : txtMin_Panic.Text.Trim();
        objDC.Max_Panic_Value = txtMax_Panic.Text.Trim().Equals("") ? "0" : txtMax_Panic.Text.Trim();
        objDC.Description = this.txtDescription.Text.Trim().Replace("'","''").Replace("\n","").Replace("\r","");
        objDC.ASIUnit = txtSIunit.Text.Trim();
        objDC.Conversionfactor = txtconversionfactor.Text.Trim();

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
    private bool Validate_Form()
    {
        lblErrMsg.Text = "";
        lblErrMsg.ForeColor = System.Drawing.Color.Red;

        if (ddlSubDepartment.SelectedIndex <= 0)
        {
            lblErrMsg.Text = "Please select subdepartment first.";
            ddlSubDepartment.Focus();
            return false;
        }
        //if (ddlGroup.SelectedIndex <= 0)
        //{
        //    lblErrMsg.Text = "Please select group first";
        //    ddlGroup.Focus();
        //    return false;
        //}
        if (ddlTest.SelectedIndex <= 0)
        {
            lblErrMsg.Text = "Please select test first";
            ddlTest.Focus();
            return false;
        }
        if (ddlAttribute.SelectedIndex <= 0)
        {
            lblErrMsg.Text = "Please select attribute first";
            ddlAttribute.Focus();
            return false;
        }
        if (ddlMethod.SelectedIndex <= 0)
        {
            lblErrMsg.Text = "Please select mehtod first";
            ddlMethod.Focus();
            return false;
        }
        if (ddlSex.SelectedIndex <= 0)
        {
            lblErrMsg.Text = "Please select gender first";
            ddlSex.Focus();
            return false;
        }
        if (txtAge_Min.Text.Trim().Equals(""))
        {
            lblErrMsg.Text = "Please enter Minimum age.(empty is not allowed)";
            txtAge_Min.Focus();
            return false;
        }
        if (txtAge_Max.Text.Trim().Equals(""))
        {
            lblErrMsg.Text = "Please enter maximum age.(empty is not allowed)";
            txtAge_Max.Focus();
            return false;
        }
        //if (txtMin_Value.Text.Trim().Equals(""))
        //{
        //    lblErrMsg.Text = "Please enter minimum value.(empty is not allowed)";
        //    txtMin_Value.Focus();
        //    return false;
        //}
        //if (txtMax_Value.Text.Trim().Equals(""))
        //{
        //    lblErrMsg.Text = "Please enter maximum value.(empty is not allowed)";
        //    txtMax_Value.Focus();
        //    return false;
        //}
        if (Convert.ToInt32(txtAge_Min.Text.Trim()) > Convert.ToInt32(txtAge_Max.Text))
        {
            lblErrMsg.Text = "Minimum age is greater than maximum age.Please correct minimum age";
            txtAge_Min.Focus();
            return false;
        }
        clsValidation vald = new clsValidation();
        if (vald.IsNumber(txtMin_Value.Text.Trim().Replace("-","")) && vald.IsNumber(txtMax_Value.Text.Trim().Replace("-","")))
        {
            if (Convert.ToDouble(txtMin_Value.Text.Trim()) > Convert.ToDouble(txtMax_Value.Text))
            {
                lblErrMsg.Text = "Minimum value is greater than maximum value.Please correct minimum value";
                txtMin_Value.Focus();
                return false;
            }
        }
        if (!txtMin_Panic.Text.Trim().Equals("") && !txtMax_Panic.Text.Trim().Equals(""))
        {
            if (Convert.ToDouble(txtMin_Panic.Text.Trim()) > Convert.ToDouble(txtMax_Panic.Text))
            {
                lblErrMsg.Text = "Minimum panic value is greater than maximum panic value.Please correct minimum panic value";
                txtMin_Panic.Focus();
                return false;
            }
        }
        if (txtDescription.Text.Length > 5000)
        {
            lblErrMsg.Text = "Please enter description character less than 5000. Entered: "+txtDescription.Text.Length+"";
            return false;
        }
        return true;
    }
    private string GetAge(string strDate)
    {
        if (ddlAge.SelectedItem.Value.ToString().Equals("M"))
            strDate = Convert.ToString(Convert.ToInt32(strDate) * 30);
        else if (ddlAge.SelectedItem.Value.ToString().Equals("Y"))
            strDate = Convert.ToString(Convert.ToInt32(strDate) * 365);
        else
           return strDate;
        
        return strDate;
    }
       
    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Validate_Form())
            return;
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.ddlSubDepartment.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblAttributeRange.Text = "";

        this.ddlSubDepartment.SelectedValue = "-1";
        this.ddlGroup.SelectedValue = "-1";
        this.ddlSex.SelectedValue = "-1";

        this.ddlMethod.SelectedIndex = -1;
        this.ddlTest.SelectedIndex = -1;
        this.ddlAttribute.SelectedIndex = -1;

        gvAttributeRange.DataSource = null;
        gvAttributeRange.DataBind();
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["AttributeId"].Equals(""))
        {
            Response.Redirect("Attribute.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }
    protected void gvAttributeRange_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttributeRange.PageIndex = e.NewPageIndex;
        Fillgv();
    }

    protected void gvAttributeRange_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlSubDepartment.SelectedValue = "-1";
        this.ddlGroup.SelectedValue = "-1";
        this.ddlSex.SelectedValue = "-1";
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsARange objDC = new clsARange();
        lblAttributeRange.Text = objDC.RangeId = gvAttributeRange.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {
            if (!dv[0]["SubdepartmentId"].ToString().Equals(""))
            {
                this.ddlSubDepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();
            }

            if (!dv[0]["GroupId"].ToString().Equals(""))
            {
                this.ddlGroup.SelectedValue = dv[0]["GroupId"].ToString();
            }

            FillTestDDL();
            try
            {
                if (!dv[0]["TestId"].ToString().Equals("") && !dv[0]["TestId"].ToString().Equals("0"))
                {
                    this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
                }
            }
            catch { }

            FillAttributeDDL();

            try
            {
                if (!dv[0]["AttributeId"].ToString().Equals("") && !dv[0]["AttributeId"].ToString().Equals("0"))
                {
                    this.ddlAttribute.SelectedValue = dv[0]["AttributeId"].ToString();
                }
            }
            catch { }

            if (!dv[0]["Sex"].ToString().Equals(""))
            {
                this.ddlSex.SelectedValue = dv[0]["Sex"].ToString();
            }
            try
            {
                ddlMethod.SelectedItem.Selected = false;
                ddlMethod.Items.FindByValue(dv[0]["methodid"].ToString()).Selected = true;
            }
            catch { }

            this.txtAUnit.Text = dv[0]["AUnit"].ToString().Replace("&nbsp;","");
            this.txtAge_Min.Text = dv[0]["Age_Min"].ToString().Replace("&nbsp;", "");
            this.txtAge_Max.Text = dv[0]["Age_Max"].ToString().Replace("&nbsp;", "");

            this.txtMin_Value.Text = dv[0]["Min_Value"].ToString().Replace("&nbsp;", "");
            this.txtMax_Value.Text = dv[0]["Max_Value"].ToString().Replace("&nbsp;", "");

            this.txtMin_Panic.Text = dv[0]["Min_Panic_Value"].ToString().Replace("&nbsp;", "");
            this.txtMax_Panic.Text = dv[0]["Max_Panic_Value"].ToString().Replace("&nbsp;", "");
            chkActive.Checked = dv[0]["active"].ToString().Equals("Y") ? true : false;
            this.txtDescription.Text = dv[0]["description"].ToString().Trim();
            
            if (Convert.ToInt32(txtAge_Min.Text) %365 == 0 && Convert.ToInt32(txtAge_Max.Text) % 365 == 0)
            {
                try 
                {
                    ddlAge.SelectedItem.Selected = false;
                    ddlAge.Items.FindByValue("Y").Selected = true;

                    txtAge_Max.Text = Convert.ToString(Convert.ToInt32(txtAge_Max.Text) / 365);
                    txtAge_Min.Text = Convert.ToString(Convert.ToInt32(txtAge_Min.Text) / 365);
                }
                catch { }
            }
            else if (Convert.ToInt32(txtAge_Min.Text) % 30 == 0  && Convert.ToInt32(txtAge_Max.Text) % 30 == 0)
            {
                try
                {
                    ddlAge.SelectedItem.Selected = false;
                    ddlAge.Items.FindByValue("M").Selected = true;
                    
                    txtAge_Max.Text = Convert.ToString(Convert.ToInt32(txtAge_Max.Text) / 30);
                    txtAge_Min.Text = Convert.ToString(Convert.ToInt32(txtAge_Min.Text) / 30);
                }
                catch { }
            }
            else
            {
                try
                {
                    ddlAge.SelectedItem.Selected = false;
                    ddlAge.Items.FindByValue("D").Selected = true;
                }
                catch { }
            }
        }
    }
    protected void gvAttributeRange_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubDepartment.SelectedIndex > 0)
        {
            FillGroupDDL();
            FillMethod();
            FillTestDDL();
            
        }
        else
        {
            gvAttributeRange.DataSource = null;
            gvAttributeRange.DataBind();

            for (int i = ddlMethod.Items.Count - 1; i >= 1; i--)
            {
                ddlMethod.Items.RemoveAt(i);
            }
            for (int i = ddlGroup.Items.Count - 1; i >= 1; i--)
            {
                ddlGroup.Items.RemoveAt(i);
            }
            for (int i = ddlTest.Items.Count - 1; i >= 1; i--)
            {
                ddlTest.Items.RemoveAt(i);
            }
            for (int i = ddlAttribute.Items.Count - 1; i >= 1; i--)
            {
                ddlAttribute.Items.RemoveAt(i);
            }
        }
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroup.SelectedIndex > 0)
        {
            FillTestDDL();
            Fillgv();
        }
        else
        {
            FillTestDDL();
            gvAttributeRange.DataSource = null;
            gvAttributeRange.DataBind();           
                       
            for (int i = ddlAttribute.Items.Count - 1; i >= 1; i--)
            {
                ddlAttribute.Items.RemoveAt(i);
            }
        }    
        
        
    }

    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTest.SelectedIndex > 0)
        {
            FillAttributeDDL();
            Fillgv();
        }
        else
        {
            gvAttributeRange.DataSource = null;
            gvAttributeRange.DataBind();
                        
            for (int i = ddlAttribute.Items.Count - 1; i >= 1; i--)
            {
                ddlAttribute.Items.RemoveAt(i);
            }
        }   
        
    }
    protected void ddlAttribute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAttribute.SelectedIndex > 0)
        {
            Fillgv();
        }
        else
        {
            gvAttributeRange.DataSource = null;
            gvAttributeRange.DataBind();
        }
    }
    protected void lbtnSaveNext_Click(object sender, EventArgs e)
    {
        if (!Validate_Form())
            return;
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();

        if (lblErrMsg.ForeColor.Equals(System.Drawing.Color.Green))
        {
            //Session["RangeId"] = lblAttributeRange.Text.Trim();
            Response.Redirect("AttributeTemplate.aspx?rangeid="+lblAttributeRange.Text.Trim()+"");
        }   
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        string _selectionForm = "1=1";
        if (ddlSubDepartment.SelectedIndex > 0)
            _selectionForm += " and {command.subdepartmentid}="+ddlSubDepartment.SelectedItem.Value.ToString();
        if (ddlTest.SelectedIndex > 0)
            _selectionForm += " and {command.testid}="+ddlTest.SelectedItem.Value.ToString();
        if (ddlAttribute.SelectedIndex > 0)
            _selectionForm += " and {command.attributeid}="+ddlAttribute.SelectedItem.Value.ToString();

        Session["reportname"] = "test_ranges";
        Session["selectionformula"] = _selectionForm;

        Response.Write("<script language='javascript'>window.open('../Report/GeneralReports.aspx')</script>");
    }

    protected void gvAttributeRange_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            this.ddlSubDepartment.SelectedValue = "-1";
            this.ddlGroup.SelectedValue = "-1";
            this.ddlSex.SelectedValue = "-1";
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsARange objDC = new clsARange();
            lblAttributeRange.Text = objDC.RangeId = gvAttributeRange.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                if (!dv[0]["SubdepartmentId"].ToString().Equals(""))
                {
                    this.ddlSubDepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();
                }

                if (!dv[0]["GroupId"].ToString().Equals(""))
                {
                    this.ddlGroup.SelectedValue = dv[0]["GroupId"].ToString();
                }

                FillTestDDL();
                try
                {
                    if (!dv[0]["TestId"].ToString().Equals("") && !dv[0]["TestId"].ToString().Equals("0"))
                    {
                        this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
                    }
                }
                catch { }

                FillAttributeDDL();

                try
                {
                    if (!dv[0]["AttributeId"].ToString().Equals("") && !dv[0]["AttributeId"].ToString().Equals("0"))
                    {
                        this.ddlAttribute.SelectedValue = dv[0]["AttributeId"].ToString();
                    }
                }
                catch { }

                if (!dv[0]["Sex"].ToString().Equals(""))
                {
                    this.ddlSex.SelectedValue = dv[0]["Sex"].ToString();
                }
                try
                {
                    ddlMethod.SelectedItem.Selected = false;
                    ddlMethod.Items.FindByValue(dv[0]["methodid"].ToString()).Selected = true;
                }
                catch { }

                this.txtAUnit.Text = dv[0]["AUnit"].ToString().Replace("&nbsp;", "");
                this.txtAge_Min.Text = dv[0]["Age_Min"].ToString().Replace("&nbsp;", "");
                this.txtAge_Max.Text = dv[0]["Age_Max"].ToString().Replace("&nbsp;", "");

                this.txtMin_Value.Text = dv[0]["Min_Value"].ToString().Replace("&nbsp;", "");
                this.txtMax_Value.Text = dv[0]["Max_Value"].ToString().Replace("&nbsp;", "");

                this.txtMin_Panic.Text = dv[0]["Min_Panic_Value"].ToString().Replace("&nbsp;", "");
                this.txtMax_Panic.Text = dv[0]["Max_Panic_Value"].ToString().Replace("&nbsp;", "");
                chkActive.Checked = dv[0]["active"].ToString().Equals("Y") ? true : false;
                this.txtDescription.Text = dv[0]["description"].ToString().Trim();
                this.txtconversionfactor.Text = dv[0]["conversionfactor"].ToString().Trim();
                this.txtSIunit.Text = dv[0]["ASIUnit"].ToString().Trim();

                if (Convert.ToInt32(txtAge_Min.Text) % 365 == 0 && Convert.ToInt32(txtAge_Max.Text) % 365 == 0)
                {
                    try
                    {
                        ddlAge.SelectedItem.Selected = false;
                        ddlAge.Items.FindByValue("Y").Selected = true;

                        txtAge_Max.Text = Convert.ToString(Convert.ToInt32(txtAge_Max.Text) / 365);
                        txtAge_Min.Text = Convert.ToString(Convert.ToInt32(txtAge_Min.Text) / 365);
                    }
                    catch { }
                }
                else if (Convert.ToInt32(txtAge_Min.Text) % 30 == 0 && Convert.ToInt32(txtAge_Max.Text) % 30 == 0)
                {
                    try
                    {
                        ddlAge.SelectedItem.Selected = false;
                        ddlAge.Items.FindByValue("M").Selected = true;

                        txtAge_Max.Text = Convert.ToString(Convert.ToInt32(txtAge_Max.Text) / 30);
                        txtAge_Min.Text = Convert.ToString(Convert.ToInt32(txtAge_Min.Text) / 30);
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        ddlAge.SelectedItem.Selected = false;
                        ddlAge.Items.FindByValue("D").Selected = true;
                    }
                    catch { }
                }
            }

        }
    }
}
