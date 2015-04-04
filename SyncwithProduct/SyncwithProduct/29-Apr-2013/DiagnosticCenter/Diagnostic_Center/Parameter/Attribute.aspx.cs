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

public partial class Attribute_m : System.Web.UI.Page
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
                log.OptionId = "11";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblAttributeId.Text = "";
                    FillSubDeptDDL();
                    pnlSel_Attrib.Visible = false;
                    try
                    {
                        if (!Session["AttributeId"].Equals(""))
                        {
                            this.ddlSubDepartment.SelectedValue = "-1";
                            this.ddlAttributeType.SelectedIndex = 0;
                            lblErrMsg.Text = "";
                            lblstatus.Text = "u";
                            clsAttribute objDC = new clsAttribute();
                            lblAttributeId.Text = objDC.AttributeId = Session["AttributeId"].ToString();
                            DataView dv = objDC.GetAll(3);
                            if (dv.Count > 0)
                            {
                                this.txtAttribute_Name.Text = dv[0]["Attribute_Name"].ToString();
                                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                                this.txtDescription.Text = dv[0]["Description"].ToString();
                                this.txtDOrder.Text = dv[0]["DOrder"].ToString();
                                this.txtD_A_Formula.Text = dv[0]["D_A_Formula"].ToString();
                                this.txtD_A_Formula_Desc.Text = dv[0]["D_A_Formula_Desc"].ToString();
                                this.txtLines.Text = dv[0]["LinesNo"].ToString();
                                this.txtDefaultValue.Text = dv[0]["DefaultValue"].ToString();
                                if (!dv[0]["SubdepartmentId"].ToString().Equals(""))
                                {
                                    this.ddlSubDepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();
                                }

                                FillTestDDL();

                                if (!dv[0]["TestId"].ToString().Equals("") && !dv[0]["TestId"].ToString().Equals("0"))
                                {
                                    this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
                                }

                                if (!dv[0]["Attribute_Type"].ToString().Equals("") && !dv[0]["Attribute_Type"].ToString().Equals("0"))
                                {
                                    this.ddlAttributeType.SelectedValue = dv[0]["Attribute_Type"].ToString();
                                }

                                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                                this.chkInterfaced.Checked = (dv[0]["Interfaced"].ToString().Equals("Y")) ? true : false;
                            }
                            else
                            {
                                FillTestDDL();
                            }
                        }
                        else
                        {
                            if (!Session["GroupDetailId"].Equals(""))
                            {
                                clsGroupD objGr = new clsGroupD();
                                objGr.GroupDetailId = Session["GroupDetailId"].ToString();
                                DataView dv = objGr.GetAll(7);
                                if (dv.Count > 0)
                                {
                                    if (!dv[0]["SubDepartmentId"].ToString().Equals(""))
                                    {
                                        this.ddlSubDepartment.SelectedValue = dv[0]["SubDepartmentId"].ToString();
                                    }
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
                            }
                            else
                            {
                                FillTestDDL();
                            }
                        }
                    }
                    catch
                    { }
                    Session["AttributeId"] = "";
                    //Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlSubDepartment.Focus();

                    if (Request.QueryString["testid"] != null)
                    {
                        ddlTest.SelectedItem.Selected = false;
                        ddlTest.Items.FindByValue(Request.QueryString["testid"].ToString()).Selected = true;
                        Fillgv();
                    }
                    
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
        clsSubDepartment objSubDept = new clsSubDepartment();
        SComponents objScom = new SComponents();
        DataView dv = objSubDept.GetAll(4);
        objScom.FillDropDownList(ddlSubDepartment, dv, "Name", "SubdepartmentId", true, false, true);
        this.ddlSubDepartment.SelectedValue = "-1";
    }

    private void FillTestDDL()
    {
        clsTest objTest = new clsTest();
        SComponents objScom = new SComponents();
        if (!this.ddlSubDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objTest.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        }
        DataView dv = objTest.GetAll(4);
        objScom.FillDropDownList(ddlTest, dv, "Test_Name", "TestId", true, false, true);
        this.ddlTest.SelectedValue = "-1";
    }

    private void Fillgv()
    {
        clsAttribute objDC = new clsAttribute();
        if (!this.ddlSubDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
        }
        //if (!this.ddlAttributeType.SelectedItem.Value.ToString().Equals("-1"))
        //{
        //    objDC.Attribute_Type = this.ddlAttributeType.SelectedItem.Value.ToString();
        //}
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvAttribute.DataSource = dv;
            gvAttribute.DataBind();
            gvAttribute.Visible = true;
        }
        else
        {
            gvAttribute.Visible = false;
        }
    }

    private void Clear()
    {
        txtAttribute_Name.Text = "";
        txtAcronym.Text = "";
        txtDescription.Text = "";

        txtDOrder.Text = "";
        txtLines.Text = "";        
        txtD_A_Formula.Text = "";

        txtD_A_Formula_Desc.Text = "";
        txtDefaultValue.Text = "";   
       
        this.ddlAttributeType.SelectedIndex = 0;

        chkActive.Checked = true;
        chkInterfaced.Checked = true;
        chkDrived.Checked = false;
		chkHeading.Checked=false ;
        chkPrint.Checked = true;

        lblErrMsg.Text = "";               
        lblstatus.Text = "i";
        lblParentID.Text = "";

    }

    private void Insert()
    {
        clsAttribute objDC = new clsAttribute();
        objDC.Attribute_Name = txtAttribute_Name.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        if (!txtDOrder.Text.Trim().Equals(""))
        {
            objDC.DOrder = txtDOrder.Text.Trim();
        }
        if (!txtLines.Text.Trim().Equals(""))
        {
            objDC.LinesNo = txtLines.Text.Trim();
        }
        objDC.D_A_Formula = txtD_A_Formula.Text.Trim();
        objDC.D_A_Formula_Desc = txtD_A_Formula_Desc.Text.Trim();
        objDC.DefaultValue = txtDefaultValue.Text.Trim();
        if (!this.ddlSubDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
        }       
            
        objDC.Attribute_Type = this.ddlAttributeType.SelectedItem.Value.ToString();
        objDC.ParentID = this.lblParentID.Text.Trim();
        
        objDC.Drived = this.chkDrived.Checked ? "Y" : "N";
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Interfaced = chkInterfaced.Checked ? "Y" : "N";
		objDC.Heading = chkHeading.Checked ? "Y" : "N";
        objDC.Print = chkPrint.Checked ? "Y" : "N";

        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Insert())
        {
            if (this.chkDrived.Checked == true)
            {
                clsBLDerivedAttributes obj_DerivedAttributes = new clsBLDerivedAttributes();
                DataView dv_AttributeID = objDC.GetAll(10);
                obj_DerivedAttributes.AttributeID = dv_AttributeID[0]["AttributeID"].ToString();
                // dv_AttributeID.Dispose();
                obj_DerivedAttributes.AttributeName = txtAttribute_Name.Text;
                obj_DerivedAttributes.Formula = txtFormula.Text;
                obj_DerivedAttributes.Description = txtformulaedesc.Text;
                if (txtMlValue.Text != "" && txtFmlValue.Text != "")
                {
                    obj_DerivedAttributes.MlValue = txtMlValue.Text;
                    obj_DerivedAttributes.FmlValue = txtFmlValue.Text;
                }
                obj_DerivedAttributes.TestID = ddlTest.SelectedValue.ToString();
                obj_DerivedAttributes.EnteredBy = Session["personid"].ToString();
                obj_DerivedAttributes.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_DerivedAttributes.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                if (obj_DerivedAttributes.insert())
                {
                    DataView dv_DerivedID = obj_DerivedAttributes.GetAll(2);
                    clsBLDerivedAttributesD obj_DerivedAttributesD = new clsBLDerivedAttributesD();
                    obj_DerivedAttributesD.TestID = ddlTest.SelectedValue.ToString();
                    obj_DerivedAttributesD.DerivedID = dv_DerivedID[0]["derivedid"].ToString();
                    obj_DerivedAttributesD.AttributeID = dv_AttributeID[0]["AttributeID"].ToString();
                    dv_AttributeID.Dispose();
                    dv_DerivedID.Dispose();
                    obj_DerivedAttributesD.EnteredBy = Session["personid"].ToString();
                    obj_DerivedAttributesD.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_DerivedAttributesD.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientID"].ToString().Trim();
                    obj_DerivedAttributesD.Status = "A";
                    string[] variable_names = hdVariableNames.Value.ToString().Split(',');
                    string[] variable_locations = hdlocations.Value.ToString().Split(',');
                    string[] variable_types = hdVariableTypes.Value.ToString().Split(',');
                    int count_inserts = 0;
                    for (int i = 0; i < variable_locations.Length; i++)
                    {
                        obj_DerivedAttributesD.VariableName = variable_names[i].ToString();
                        obj_DerivedAttributesD.Location = variable_locations[i].ToString();
                        obj_DerivedAttributesD.Type = variable_types[i].ToString();
                        if (obj_DerivedAttributesD.insert())
                        {
                            count_inserts++;
                        }

                    }
                    if (count_inserts == variable_types.Length)
                    {

                        this.lblErrMsg.Text = "<font color='Green'>Record has been inserted successfully</font>";
                        Clear();
                        Fillgv();
                    }
                    else
                    {
                        this.lblErrMsg.Text = "<font color='Green'>Test Attribute and Attribute Formula inserted successfully but the Following Error occured in Formula Variable Entry</font><br /><font color='Red'>" + obj_DerivedAttributes.ErrorMessage + "</font>";
                        Clear();
                        Fillgv();
                    }

                }
                else
                {
                    this.lblErrMsg.Text = "<font color='Green'>Only TestAttribute successfully inserted, the following error occured while inserting Derived Attribute Formula</font> <br /><font color='Red'>" + obj_DerivedAttributes.ErrorMessage + "</font>";
                    Clear();
                    Fillgv();
                }

            }



            else
            {
                lblAttributeId.Text = objDC.AttributeId.ToString();
                Clear();
                lblErrMsg.ForeColor = System.Drawing.Color.Green;
                lblErrMsg.Text = "Record save successfully";
                Fillgv();
            }
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objDC.ErrorMessage;
        }
    }

    private void Update()
    {
        clsAttribute objDC = new clsAttribute();
        objDC.AttributeId = lblAttributeId.Text.Trim();
        objDC.Attribute_Name = txtAttribute_Name.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        if (!txtDOrder.Text.Trim().Equals(""))
        {
            objDC.DOrder = txtDOrder.Text.Trim();
        }
        if (!txtLines.Text.Trim().Equals(""))
        {
            objDC.LinesNo = txtLines.Text.Trim();
        }
        objDC.D_A_Formula = txtD_A_Formula.Text.Trim();
        objDC.D_A_Formula_Desc = txtD_A_Formula_Desc.Text.Trim();
        objDC.DefaultValue = txtDefaultValue.Text.Trim();
        if (!this.ddlSubDepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SubdepartmentId = this.ddlSubDepartment.SelectedItem.Value.ToString();
        }
        if (!this.ddlTest.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestId = this.ddlTest.SelectedItem.Value.ToString();
        }
        else
        {
            objDC.TestId = "0";
        }

        objDC.Attribute_Type = this.ddlAttributeType.SelectedItem.Value.ToString();
        objDC.ParentID = this.lblParentID.Text.Trim();

        objDC.Drived = this.chkDrived.Checked ? "Y" : "N";
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Interfaced = chkInterfaced.Checked ? "Y" : "N";
        objDC.Heading = chkHeading.Checked ? "Y" : "N";
        objDC.Print = chkPrint.Checked ? "Y" : "N";

        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Update())
        {
            if (this.chkDrived.Checked == true)
            {
                clsBLDerivedAttributes obj_DerivedAttributes = new clsBLDerivedAttributes();
                DataView dv_AttributeID = objDC.GetAll(10);
                obj_DerivedAttributes.AttributeID = lblAttributeId.Text.Trim();
                // dv_AttributeID.Dispose();
                obj_DerivedAttributes.AttributeName = txtAttribute_Name.Text;
                obj_DerivedAttributes.Formula = txtFormula.Text;
                obj_DerivedAttributes.Description = txtformulaedesc.Text;
                if (txtMlValue.Text != "" && txtFmlValue.Text != "")
                {
                    obj_DerivedAttributes.MlValue = txtMlValue.Text;
                    obj_DerivedAttributes.FmlValue = txtFmlValue.Text;
                }
                obj_DerivedAttributes.TestID = ddlTest.SelectedValue.ToString();
                obj_DerivedAttributes.EnteredBy = Session["personid"].ToString();
                obj_DerivedAttributes.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_DerivedAttributes.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                if (obj_DerivedAttributes.insert())
                {
                    DataView dv_DerivedID = obj_DerivedAttributes.GetAll(2);
                    clsBLDerivedAttributesD obj_DerivedAttributesD = new clsBLDerivedAttributesD();
                    obj_DerivedAttributesD.TestID = ddlTest.SelectedValue.ToString();
                    obj_DerivedAttributesD.DerivedID = dv_DerivedID[0]["derivedid"].ToString();
                    obj_DerivedAttributesD.AttributeID = dv_AttributeID[0]["AttributeID"].ToString();
                    dv_AttributeID.Dispose();
                    dv_DerivedID.Dispose();
                    obj_DerivedAttributesD.EnteredBy = Session["personid"].ToString();
                    obj_DerivedAttributesD.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_DerivedAttributesD.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim(); ;
                    obj_DerivedAttributesD.Status = "A";
                    string[] variable_names = hdVariableNames.Value.ToString().Split(',');
                    string[] variable_locations = hdlocations.Value.ToString().Split(',');
                    string[] variable_types = hdVariableTypes.Value.ToString().Split(',');
                    int count_inserts = 0;
                    for (int i = 0; i < variable_locations.Length; i++)
                    {
                        obj_DerivedAttributesD.VariableName = variable_names[i].ToString();
                        obj_DerivedAttributesD.Location = variable_locations[i].ToString();
                        obj_DerivedAttributesD.Type = variable_types[i].ToString();
                        if (obj_DerivedAttributesD.insert())
                        {
                            count_inserts++;
                        }

                    }
                    if (count_inserts == variable_types.Length)
                    {

                        this.lblErrMsg.Text = "<font color='Green'>Record has been inserted successfully</font>";
                        Clear();
                        Fillgv();
                    }
                    else
                    {
                        this.lblErrMsg.Text = "<font color='Green'>Test Attribute and Attribute Formula inserted successfully but the Following Error occured in Formula Variable Entry</font><br /><font color='Red'>" + obj_DerivedAttributes.ErrorMessage + "</font>";
                        Clear();
                        Fillgv();
                    }

                }
                else
                {
                    this.lblErrMsg.Text = "<font color='Green'>Only TestAttribute successfully inserted, the following error occured while inserting Derived Attribute Formula</font> <br /><font color='Red'>" + obj_DerivedAttributes.ErrorMessage + "</font>";
                    Clear();
                    Fillgv();
                }
            }
            else
            {
                this.lblErrMsg.Text = "<font color='Green'>Record Updated!!!</font>";
                Clear();
                Fillgv();
                //lblErrMsg.ForeColor = System.Drawing.Color.Red;
               // lblErrMsg.Text = objDC.ErrorMessage;
            }
        }
    }


    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.txtAttribute_Name.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        ddlSubDepartment.SelectedIndex = -1;
        lblAttributeId.Text = "";
    }

    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["GroupDetailId"].Equals(""))
        {
            Response.Redirect("GroupD.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }
    protected void gvAttribute_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAttribute.PageIndex = e.NewPageIndex;
        Fillgv();
    }

    protected void gvAttribute_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlSubDepartment.SelectedValue = "-1";
        this.ddlAttributeType.SelectedIndex=0;
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsAttribute objDC = new clsAttribute();
        lblAttributeId.Text = objDC.AttributeId = gvAttribute.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtAttribute_Name.Text = dv[0]["Attribute_Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtDescription.Text = dv[0]["Description"].ToString();
            this.txtDOrder.Text = dv[0]["DOrder"].ToString();
            this.txtD_A_Formula.Text = dv[0]["D_A_Formula"].ToString();
            this.txtD_A_Formula_Desc.Text = dv[0]["D_A_Formula_Desc"].ToString();
            this.txtLines.Text = dv[0]["LinesNo"].ToString();
            this.txtDefaultValue.Text = dv[0]["DefaultValue"].ToString();
            this.lblParentID.Text = dv[0]["parentid"].ToString().Trim();
            if (!dv[0]["SubdepartmentId"].ToString().Equals(""))
            {
                this.ddlSubDepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();
            }

            FillTestDDL();

            if (!dv[0]["TestId"].ToString().Equals("") && !dv[0]["TestId"].ToString().Equals("0"))
            {
                this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
            }

            try
            {
                this.ddlAttributeType.SelectedItem.Selected = false;
                this.ddlAttributeType.Items.FindByValue(dv[0]["Attribute_Type"].ToString()).Selected=true;
            }
            catch { }
           
            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
			this.chkHeading.Checked = (dv[0]["Heading"].ToString().Equals("Y")) ? true : false;
            this.chkInterfaced.Checked = (dv[0]["Interfaced"].ToString().Equals("Y")) ? true : false;
            this.chkDrived.Checked = (dv[0]["drived"].ToString().Equals("Y")) ? true : false;
            this.chkPrint.Checked = (dv[0]["print"].ToString().Equals("Y")) ? true : false;
        }
    }
    protected void gvAttribute_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("Attribute_Name"))
        {
            if (DGSort == "Attribute_Name ASC")
                DGSort = "Attribute_Name DESC";
            else
                DGSort = "Attribute_Name ASC";
        }
        else if (e.SortExpression.Equals("Acronym"))
        {
            if (DGSort == "Acronym ASC")
                DGSort = "Acronym DESC";
            else
                DGSort = "Acronym ASC";
        }
        else if (e.SortExpression.Equals("SubDeptName"))
        {
            if (DGSort == "SubDeptName ASC")
                DGSort = "SubDeptName DESC";
            else
                DGSort = "SubDeptName ASC";
        }
        else if (e.SortExpression.Equals("Test_Name"))
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
        FillTestDDL();
      //  Fillgv();
    }

    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
    }
    protected void ddlAttributeType_SelectedIndexChanged(object sender, EventArgs e)
    {
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
            Session["AttributeId"] = "";
                //lblAttributeId.Text.Trim();
            Response.Redirect("AttributeRange.aspx?attribID="+lblAttributeId.Text.Trim()+"");
        }   
    }
    protected void lbtnCpyAtt_Click(object sender, EventArgs e)
    {
        btnClose.Enabled = false;
        lbtnClearAll.Enabled = false;
        lbtnSave.Enabled = false;
        lbtnSaveNext.Enabled = false;

        pnlSel_Attrib.Visible = true;
        lbtnCpyAtt.Visible = false;

        clsAttribute att = new clsAttribute();
        DataView dv = att.GetAll(8);
        gvsl_attrib.DataSource = dv;
        gvsl_attrib.DataBind();

    }
    protected void lbtnSL_Attrib_Click(object sender, EventArgs e)
    {

        GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);

        txtAttribute_Name.Text = ((LinkButton)(gvsl_attrib.Rows[gridItem.DataItemIndex].Cells[1].FindControl("lbtnSL_Attrib"))).Text.Trim();
        lblParentID.Text = gvsl_attrib.DataKeys[gridItem.DataItemIndex].Value.ToString();     


        btnClose.Enabled = true;
        lbtnClearAll.Enabled = true;
        lbtnSave.Enabled = true;
        lbtnSaveNext.Enabled = true;
        lbtnCpyAtt.Visible = true;
        pnlSel_Attrib.Visible = false;
    }

    protected void btnUpdateDOrder_Click(object sender, EventArgs e)
    {
        if (gvAttribute.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script language='javascript'>alert('No record found')</script>", false);
            return;
        }
        clsAttribute objDC = new clsAttribute();

        string[,] arr = new string[gvAttribute.Rows.Count, 6];

        for (int i = 0; i < gvAttribute.Rows.Count; i++)
        {
            arr[i, 0] = gvAttribute.DataKeys[i].Value.ToString();

            arr[i, 1] = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            arr[i, 2] = Session["PersonId"].ToString();
            arr[i, 3] = Session["orgid"].ToString(); // org
            arr[i, 4] = ((TextBox)gvAttribute.Rows[i].Cells[8].Controls[1]).Text.Trim();
            arr[i, 5] = gvAttribute.DataKeys[i].Values[1].ToString();
        }
        if (objDC.UpdateDOrder(arr))
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
    protected void imgCpyClose_Click(object sender, ImageClickEventArgs e)
    {
        btnClose.Enabled = true;
        lbtnClearAll.Enabled = true;
        lbtnSave.Enabled = true;
        lbtnSaveNext.Enabled = true;
        lbtnCpyAtt.Visible = true;
        pnlSel_Attrib.Visible = false;
    }
    protected void imgcpySearch_Click(object sender, ImageClickEventArgs e)
    {       
        clsAttribute att = new clsAttribute();
        att.Attribute_Name = this.txtCpySearch.Text.Trim().Replace("'","''");
        DataView dv = att.GetAll(8);
        gvsl_attrib.DataSource = dv;
        gvsl_attrib.DataBind();
    }

    protected void gvAttribute_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            this.ddlSubDepartment.SelectedValue = "-1";
            this.ddlAttributeType.SelectedIndex = 0;
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsAttribute objDC = new clsAttribute();
            lblAttributeId.Text = objDC.AttributeId = gvAttribute.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtAttribute_Name.Text = dv[0]["Attribute_Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtDescription.Text = dv[0]["Description"].ToString();
                this.txtDOrder.Text = dv[0]["DOrder"].ToString();
                this.txtD_A_Formula.Text = dv[0]["D_A_Formula"].ToString();
                this.txtD_A_Formula_Desc.Text = dv[0]["D_A_Formula_Desc"].ToString();
                this.txtLines.Text = dv[0]["LinesNo"].ToString();
                this.txtDefaultValue.Text = dv[0]["DefaultValue"].ToString();
                this.lblParentID.Text = dv[0]["parentid"].ToString().Trim();
                if (!dv[0]["SubdepartmentId"].ToString().Equals(""))
                {
                    this.ddlSubDepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();
                }

                FillTestDDL();

                if (!dv[0]["TestId"].ToString().Equals("") && !dv[0]["TestId"].ToString().Equals("0"))
                {
                    this.ddlTest.SelectedValue = dv[0]["TestId"].ToString();
                }

                try
                {
                    this.ddlAttributeType.SelectedItem.Selected = false;
                    this.ddlAttributeType.Items.FindByValue(dv[0]["Attribute_Type"].ToString()).Selected = true;
                }
                catch { }

                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                this.chkHeading.Checked = (dv[0]["Heading"].ToString().Equals("Y")) ? true : false;
                this.chkInterfaced.Checked = (dv[0]["Interfaced"].ToString().Equals("Y")) ? true : false;
                this.chkDrived.Checked = (dv[0]["drived"].ToString().Equals("Y")) ? true : false;
                this.chkPrint.Checked = (dv[0]["print"].ToString().Equals("Y")) ? true : false;


                if (dv[0]["drived"].ToString().Equals("Y"))
                {
                    tblderivedfield.Visible = true;
                    clsBLDerivedAttributes da = new clsBLDerivedAttributes();
                    da.AttributeID = gvAttribute.DataKeys[index].Value.ToString();
                    DataView dv_formulae = da.GetAll(1);
                    if (dv_formulae.Count > 0)
                    {
                        txtFormula.Text = dv_formulae[0]["formula"].ToString();
                        txtformulaedesc.Text = dv_formulae[0]["description"].ToString().Trim();
                        if (dv_formulae[0]["formula"].ToString().ToLower().Contains("gender"))
                        {
                            txtMlValue.Text = dv_formulae[0]["gendervalue_m"].ToString();
                            txtFmlValue.Text = dv_formulae[0]["gendervalue_f"].ToString();
                        }
                    }
                    else
                    {
                        txtFormula.Text = "";
                        txtformulaedesc.Text = "";
                    }
                }
                else
                {
                    tblderivedfield.Visible = false;
                }
            }
        }
    }
    protected void chkDerived_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDrived.Checked)
        {
            tblderivedfield.Visible = true;


        }
        else
        {
            tblderivedfield.Visible = false;
            //lblFormula.Visible = false;
            //txtFormula.Visible = false;
        }
    }
}
