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

public partial class Test : System.Web.UI.Page
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
                    txtTest_Name.Focus();
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblTestId.Text = "";
                    FillGroupDDL();
                    FillExter_Org("N");
                   
                    FillSpecimenDDL();
                    FillSubDeptDDL();
                    FillProcedureDDL();
                    //FillMethodDDL();

                    pnlGB.Visible = false;
                    pnlMehd.Visible = false;                                     
                    
                    Session["TestId"] = "";
                    Fillgv();
                    FillGV_AGe();
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

    private void FillGroupDDL()
    {
        clsGroupM objGroup = new clsGroupM();
        SComponents objScom = new SComponents();
        DataView dv = objGroup.GetAll(4);
        objScom.FillDropDownList(ddlGroup, dv, "Name", "GroupId", true, false, true);
        this.ddlGroup.SelectedValue = "-1";
    }
    private void FillSpecimenDDL()
    {
        clsSpecimenType objSpec = new clsSpecimenType();
        SComponents objScom = new SComponents();
        DataView dv = objSpec.GetAll(4);
        objScom.FillDropDownList(ddlSpecimen, dv, "Specimen_Name", "SpecimenId", true, false, true);
        this.ddlSpecimen.SelectedValue = "-1";
    }
    private void FillSContainerDDL()
    {
        clsSContainer objSpec = new clsSContainer();
        SComponents objScom = new SComponents();
        if (!this.ddlSpecimen.SelectedItem.Value.ToString().Equals("-1"))
        {
            objSpec.SpecimenId = this.ddlSpecimen.SelectedItem.Value.ToString();
        }
        DataView dv = objSpec.GetAll(4);
        objScom.FillDropDownList(ddlContainer, dv, "Container_Name", "SContainerId", true, false, true);
        this.ddlContainer.SelectedValue = "-1";
    }

    private void FillSubDeptDDL()
    {
        clsSubDepartment objSubDept = new clsSubDepartment();
        SComponents objScom = new SComponents();
        DataView dv = objSubDept.GetAll(4);
        objScom.FillDropDownList(ddlSubdepartment, dv, "Name", "SubdepartmentId", true, false, true);
        this.ddlSubdepartment.SelectedValue = "-1";
    }
    private void FillExter_Org(string exter)
    {
        clsTest te = new clsTest();
        SComponents com = new SComponents();

        te.External = exter;
        DataView dv = te.GetAll(13);
        if (exter.Trim().Equals("Y"))
            com.FillDropDownList(ddlExternalOrg, dv, "name", "orgid");
        else
            com.FillDropDownList_Local(ddlExternalOrg, dv, "name", "orgid");
        
        //try
        //{
        //    ddlExternalOrg.SelectedItem.Selected = false;
        //    for (int i = 0; i < dv.Count; i++)
        //    {
        //        if (dv[i]["main"].Equals("Y"))
        //        {
        //            ddlExternalOrg.Items.FindByValue(dv[i]["orgid"].ToString()).Selected = true;
        //        }
        //    }
        //}
        //catch { }
    }

    private void FillMethodDDL()
    {
        clsTest te = new clsTest();
        SComponents com = new SComponents();

        te.SubdepartmentId = this.ddlSubdepartment.SelectedItem.Value.ToString().Replace("-1","");
        DataView dv = te.GetAll(7);
        com.FillDropDownList(ddlMethod, dv, "name", "methodid");
    }
    private void FillProcedureDDL()
    {
        clsTest te = new clsTest();
        SComponents com = new SComponents();

        DataView dv = te.GetAll(8);
        com.FillDropDownList(ddlProcedure, dv, "name", "procedureid");
    }

    private void Fillgv()
    {
        clsTest objDC = new clsTest();
        if (!this.ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
        }
        if (!this.ddlSpecimen.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SpecimenId = this.ddlSpecimen.SelectedItem.Value.ToString();
        }
        if (this.ddlContainer.SelectedIndex>0)
        {
            objDC.SContainerId = this.ddlContainer.SelectedItem.Value.ToString();
        }
        if (!this.ddlSubdepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SubdepartmentId = this.ddlSubdepartment.SelectedItem.Value.ToString();
        }
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
            gvTest.Visible = false;
        }
    }
    private void FillGV_AGe()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("gender");

        for (int i = 0; i < 3; i++)
        {
            DataRow dr = dt.NewRow();
            if (i == 0)
            {
                dr["gender"] = "Male";
            }
            else if (i == 1)
            {
                dr["gender"] = "Female";
            }
            else
            {
                dr["gender"] = "All";
            }
            dt.Rows.Add(dr);
        }
        gvAgeApp.DataSource = dt;
        gvAgeApp.DataBind();

        for (int i = 0; i < gvAgeApp.Rows.Count; i++)
        {
            ((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text = "0";
            ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text = "0";
        }
    }

    private void Insert()
    {
        clsTest objDC = new clsTest();
        objDC.Test_Name = txtTest_Name.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();

        switch (ddlTimeType.SelectedItem.Value)
        {
            case "H":
                objDC.Mintime = Convert.ToString(Convert.ToInt32(txtMinTime.Text.Trim()) * 60);
                objDC.Maxtime = Convert.ToString(Convert.ToInt32(txtMaxTime.Text.Trim()) * 60);
                break;
            case "M":
                objDC.Mintime = txtMinTime.Text.Trim();
                objDC.Maxtime = txtMaxTime.Text.Trim();
                break;
            case "D":
                objDC.Mintime = Convert.ToString(Convert.ToInt32(txtMinTime.Text.Trim()) * 1440);
                objDC.Maxtime = Convert.ToString(Convert.ToInt32(txtMaxTime.Text.Trim()) * 1440);
                break;
            default:
                objDC.Mintime = "0";
                objDC.Maxtime = "0";
                break;
        }
        if (!this.ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
            lblGroupId.Text = this.ddlGroup.SelectedItem.Value.ToString();
        }
        else
        {
            lblGroupId.Text = "~!@";
        }
        if (!this.ddlSubdepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SubdepartmentId = this.ddlSubdepartment.SelectedItem.Value.ToString();
            lblSubDepartmentId.Text = this.ddlSubdepartment.SelectedItem.Value.ToString();
        }
        else
        {
            lblSubDepartmentId.Text = "";
        }
        if (!this.ddlSpecimen.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SpecimenId = this.ddlSpecimen.SelectedItem.Value.ToString();
        }
        try
        {
            if (!this.ddlContainer.SelectedItem.Value.ToString().Equals("-1"))
            {
                objDC.SContainerId = this.ddlContainer.SelectedItem.Value.ToString();
            }
        }
        catch { }
        if (!this.ddlTestType.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestType = this.ddlTestType.SelectedItem.Value.ToString();
        }

        //objDC.MethodID = this.ddlMethod.SelectedItem.Value.ToString();
        objDC.ProcedureID = this.ddlProcedure.SelectedItem.Value.ToString();
        objDC.Qty = txtQuantity.Text.Trim();
   
        if (!txtCharges.Text.Trim().Equals(""))
        {
            objDC.Charges = txtCharges.Text.Trim();
        }
        if (!txtChargesUrgent.Text.Trim().Equals(""))
        {
            objDC.ChargesUrgent = txtChargesUrgent.Text.Trim();
        }

        objDC.Charity = this.txtCharity.Text.Trim().Equals("") ? "0" : txtCharity.Text.Trim();
        objDC.SpeedKey = txtSpeedKey.Text.Trim();
        if (!txtDOrder.Text.Trim().Equals(""))
        {
            objDC.DOrder = txtDOrder.Text.Trim();
        }
        objDC.ClinicalUse = txtClinicalUse.Text.Trim();
        objDC.AutomatedText = txtAutomatedText.Text.Trim();
        
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.PrintGroup = chkPrintGroup.Checked ? "Y" : "N";
        objDC.PrintTest = chkPrintTest.Checked ? "Y" : "N";

        objDC.External = chkExternal.Checked ? "Y" : "N";
        objDC.Urgent = chkUrgent.Checked ? "Y" : "N";
        objDC.SepReport = chkSepReport.Checked ? "Y" : "N";
        objDC.ProvisionRpt = chkProvisionRPT.Checked ? "Y" : "N";

        objDC.External_ORG = ddlExternalOrg.SelectedItem.Value.ToString().Replace("-1","~!@");
        objDC.Unit = this.txtUnit.Text.Trim();
        objDC.ReportFormat = this.ddlRptFormat.SelectedItem.Value.ToString();
        
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        objDC.PerformType = this.ddlPerform.SelectedItem.Value.ToString();

        int count = 0;
        for (int j = 0; j < gvAgeApp.Rows.Count; j++)
        {
            if (gvAgeApp.Rows[j].Cells[0].Text.Trim().Equals("All") && ((TextBox)(gvAgeApp.Rows[j].Cells[2].FindControl("txtMaxAge"))).Text !="0")
            {
                count++;
            }
        }


        string[,] str = new string[gvAgeApp.Rows.Count,3];
        for (int i = 0; i < gvAgeApp.Rows.Count; i++)
        {
            if (count > 0 && ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text != "0" && gvAgeApp.Rows[i].Cells[0].Text.Trim().Equals("All"))
            {
                str[i, 0] = ((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text;
                str[i, 1] = ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text;
                str[i, 2] = gvAgeApp.Rows[i].Cells[0].Text.Trim().Substring(0, 1);
            }
            else if (count == 0 && ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text != "0")
            {
                str[i, 0] = ((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text;
                str[i, 1] = ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text;
                str[i, 2] = gvAgeApp.Rows[i].Cells[0].Text.Trim().Substring(0, 1);
            }
        }

        string[,] str_sch = new string[28, 1];
        int count_sch = 0;
        string colName = "";

        for (int j = 0; j < gvPerformOn.Rows.Count; j++)
        {
            for (int m = 1; m <= 7; m++)
            {
                colName = "chk" + m;
                if (((CheckBox)(gvPerformOn.Rows[j].Cells[m].FindControl(colName))).Checked)
                {
                    if (ddlPerform.SelectedItem.Value.ToString().Equals("Days"))
                    {
                        str_sch[count_sch, 0] = gvPerformOn.Columns[m].HeaderText.ToString();
                        count_sch++;
                    }
                    if (ddlPerform.SelectedItem.Value.ToString().Equals("Weekly"))
                    {
                        str_sch[count_sch, 0] = j + 1 + "-" + gvPerformOn.Columns[m].HeaderText.ToString();
                        count_sch++;
                    }
                }
            }
        }


        if (objDC.Insert(str,str_sch))
        {
            lblTestId.Text = objDC.TestId.ToString();
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
        clsTest objDC = new clsTest();
        objDC.TestId = lblTestId.Text.Trim();
        objDC.Test_Name = txtTest_Name.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();

        switch (ddlTimeType.SelectedItem.Value)
        {
            case "H":
                objDC.Mintime = Convert.ToString(Convert.ToInt32(txtMinTime.Text.Trim()) * 60);
                objDC.Maxtime = Convert.ToString(Convert.ToInt32(txtMaxTime.Text.Trim()) * 60);
                break;
            case "M":
                objDC.Mintime = txtMinTime.Text.Trim();
                objDC.Maxtime = txtMaxTime.Text.Trim();
                break;
            case "D":
                objDC.Mintime = Convert.ToString(Convert.ToInt32(txtMinTime.Text.Trim()) * 1440);
                objDC.Maxtime = Convert.ToString(Convert.ToInt32(txtMaxTime.Text.Trim()) * 1440);
                break;
            default:
                objDC.Mintime = "0";
                objDC.Maxtime = "0";
                break;
        }


        if (!this.ddlGroup.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.GroupId = this.ddlGroup.SelectedItem.Value.ToString();
            lblGroupId.Text = this.ddlGroup.SelectedItem.Value.ToString();
        }
        else
        {
            lblGroupId.Text = "~!@";
        }
        if (!this.ddlSubdepartment.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SubdepartmentId = this.ddlSubdepartment.SelectedItem.Value.ToString();
            lblSubDepartmentId.Text = this.ddlSubdepartment.SelectedItem.Value.ToString();
        }
        else
        {
            lblSubDepartmentId.Text = "";
        }
        if (!this.ddlSpecimen.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SpecimenId = this.ddlSpecimen.SelectedItem.Value.ToString();
        }
        if (!this.ddlContainer.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.SContainerId = this.ddlContainer.SelectedItem.Value.ToString();
        }
        else
        {
            objDC.SContainerId = "~!@";
        }
        if (!this.ddlTestType.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.TestType = this.ddlTestType.SelectedItem.Value.ToString();
        }

       // objDC.MethodID = this.ddlMethod.SelectedItem.Value.ToString();
        objDC.ProcedureID = this.ddlProcedure.SelectedItem.Value.ToString();
        objDC.Qty = txtQuantity.Text.Trim();
        
     
        if (!txtCharges.Text.Trim().Equals(""))
        {
            objDC.Charges = txtCharges.Text.Trim();
        }
        else
        {
            objDC.Charges = "0";
        }
        if (!txtChargesUrgent.Text.Trim().Equals(""))
        {
            objDC.ChargesUrgent = txtChargesUrgent.Text.Trim();
        }
        else
        {
            objDC.ChargesUrgent = "0";
        }
        objDC.Charity = this.txtCharity.Text.Trim().Equals("") ? "0" : txtCharity.Text.Trim();
        objDC.SpeedKey = txtSpeedKey.Text.Trim();
        if (!txtDOrder.Text.Trim().Equals(""))
        {
            objDC.DOrder = txtDOrder.Text.Trim();
        }
        else
        {
            objDC.DOrder = "0";
        }
        objDC.ClinicalUse = txtClinicalUse.Text.Trim();
        objDC.AutomatedText = txtAutomatedText.Text.Trim();

        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.PrintGroup = chkPrintGroup.Checked ? "Y" : "N";
        objDC.PrintTest = chkPrintTest.Checked ? "Y" : "N";

        objDC.External = chkExternal.Checked ? "Y" : "N";
        objDC.Urgent = chkUrgent.Checked ? "Y" : "N";
        objDC.SepReport = chkSepReport.Checked ? "Y" : "N";
        objDC.ProvisionRpt = chkProvisionRPT.Checked ? "Y" : "N";


        objDC.External_ORG = ddlExternalOrg.SelectedItem.Value.ToString().Replace("-1", "~!@");
        objDC.Unit = this.txtUnit.Text.Trim();
        objDC.ReportFormat = this.ddlRptFormat.SelectedItem.Value.ToString();

        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        objDC.PerformType = this.ddlPerform.SelectedItem.Value.ToString();
        

        int count = 0;
        for (int j = 0; j < gvAgeApp.Rows.Count; j++)
        {
            if (gvAgeApp.Rows[j].Cells[0].Text.Trim().Equals("All") && ((TextBox)(gvAgeApp.Rows[j].Cells[2].FindControl("txtMaxAge"))).Text != "0")
            {
                count++;
            }
        }


        string[,] str = new string[gvAgeApp.Rows.Count, 3];
        for (int i = 0; i < gvAgeApp.Rows.Count; i++)
        {
            if (count > 0 && ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text != "0" && gvAgeApp.Rows[i].Cells[0].Text.Trim().Equals("All"))
            {
                str[i, 0] = ((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text;
                str[i, 1] = ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text;
                str[i, 2] = gvAgeApp.Rows[i].Cells[0].Text.Trim().Substring(0, 1);
            }
            else if (count==0 && ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text != "0")
            {
                str[i, 0] = ((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text;
                str[i, 1] = ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text;
                str[i, 2] = gvAgeApp.Rows[i].Cells[0].Text.Trim().Substring(0, 1);
            }
        }


        string[,] str_sch = new string[28, 1];
        int count_sch = 0;
        string colName = "";

        for (int j = 0; j < gvPerformOn.Rows.Count; j++)
        {
            for (int m = 1; m <= 7; m++)
            {
                colName = "chk" + m;
                if (((CheckBox)(gvPerformOn.Rows[j].Cells[m].FindControl(colName))).Checked)
                {
                    if (ddlPerform.SelectedItem.Value.ToString().Equals("Days"))
                    {
                        str_sch[count_sch, 0] = gvPerformOn.Columns[m].HeaderText.ToString();
                        count_sch++;
                    }
                    if (ddlPerform.SelectedItem.Value.ToString().Equals("Weekly"))
                    {
                        str_sch[count_sch, 0] = j+1 + "-" + gvPerformOn.Columns[m].HeaderText.ToString();
                        count_sch++;
                    }
                }
            }
        }

        if (objDC.Update(str,str_sch))
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
        txtTest_Name.Text = "";
        txtAcronym.Text = "";       
        txtQuantity.Text = "";
       
        this.ddlGroup.SelectedValue = "-1";
        this.ddlSpecimen.SelectedValue = "-1";        
       // this.ddlSubdepartment.SelectedValue = "-1";
        this.ddlMethod.SelectedIndex = -1;
        this.ddlProcedure.SelectedIndex = -1;
        this.ddlExternalOrg.SelectedIndex = -1;
        this.ddlRptFormat.SelectedIndex = 0;
        this.ddlPerform.SelectedIndex = 0;
        FillExter_Org("N");
       
        txtCharges.Text = "";
        txtChargesUrgent.Text = "0";
        txtCharity.Text = "";
        txtSpeedKey.Text = "";
        txtDOrder.Text = "";
        txtClinicalUse.Text = "";
        txtAutomatedText.Text = "";
        txtUnit.Text = "";

        chkActive.Checked = true;
        chkPrintGroup.Checked = false;
        chkPrintTest.Checked = false;

        chkExternal.Checked = false;
        chkUrgent.Checked = false;
        chkSepReport.Checked = false;
        chkProvisionRPT.Checked = false;
      
        lblErrMsg.Text = "";
        FillSContainerDDL();
        Fillgv();
        lblstatus.Text = "i";

        pnlGB.Visible = false;
        pnlMehd.Visible = false;

        gvGroup.DataSource = null;
        gvGroup.DataBind();

        gvMethod.DataSource = null;
        gvMethod.DataBind();

        gvPerformOn.DataSource = null;
        gvPerformOn.DataBind();

        for (int i = 0; i < gvAgeApp.Rows.Count;i++ )
        {
            ((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text = "0";
            ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text = "0";
        }
    }
    private bool VD_Age_Value()
    {
        lblErrMsg.ForeColor = System.Drawing.Color.Red;
        int minage = 0;
        int maxage = 0;

        int count = 0;

        for (int i = 0; i < gvAgeApp.Rows.Count; i++)
        {
            if (((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text == "")
            {
                ((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text = "0";
                
            }
            if (((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text == "")
            {
                ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text = "0";
               
            }

            minage = Convert.ToInt32(((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text);
            maxage = Convert.ToInt32(((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text);

            if (minage == 0 && maxage == 0)
            {
                count++;
            }
            else
            {
                count = 10;
            }
            if (minage > maxage)
            {
                lblErrMsg.Text = "Minimum age is greater than maximum age.Please Correct Minimum and Maximum Age";
                return false;
            }      
        }
        if (count > 0 && count < 10)
        {
            lblErrMsg.Text = "please enter minimum age and maximum age";
            return false;
        }
        return true;
        
    }

    private void FillGV_Mehtod(string MID)
    {
        clsTest te = new clsTest();
        te.TestId = MID;

        DataView dv = te.GetAll(9);
        if (dv.Count > 0)
        {
            gvMethod.DataSource = dv;
            gvMethod.DataBind();
            pnlMehd.Visible = true;
        }
        else
        {
            gvMethod.DataSource = null;
            gvMethod.DataBind();
            pnlMehd.Visible = true;
        }
    }
    private void FillGV_Group(string GID)
    {
        clsTest te = new clsTest();
        te.TestId = GID;

        DataView dv = te.GetAll(10);
        if (dv.Count > 0)
        {
            gvGroup.DataSource = dv;
            gvGroup.DataBind();
            pnlGB.Visible = true;
        }
        else
        {
            gvGroup.DataSource = null;
            gvGroup.DataBind();
            pnlGB.Visible = true;
        }
    }

    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!VD_Age_Value())
            return;

        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.txtTest_Name.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblTestId.Text = "";
        ddlSubdepartment.SelectedIndex = -1;
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["GroupId"].Equals(""))
        {
            Response.Redirect("GroupM.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }
    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
    }

    protected void ddlSpecimen_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSContainerDDL();
       // Fillgv();
    }
    protected void ddlSubdepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubdepartment.SelectedIndex > 0)
        {
            Fillgv();
            FillMethodDDL();
        }
        else
        {
            for (int i = ddlMethod.Items.Count - 1; i >= 1; i--)
            {
                ddlMethod.Items.RemoveAt(i);
            }
            gvTest.DataSource = null;
            gvTest.DataBind();
        }
    }
    protected void gvTest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTest.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvTest_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlGroup.SelectedValue = "-1";
        this.ddlSpecimen.SelectedValue = "-1";
        this.ddlSubdepartment.SelectedValue = "-1";

        lblErrMsg.Text = "";
        lblstatus.Text = "u";

        clsTest objDC = new clsTest();
        lblTestId.Text = objDC.TestId = gvTest.DataKeys[e.NewEditIndex].Value.ToString();

        DataView dv = objDC.GetAll(3);           

        if (dv.Count > 0)
        {
            this.txtTest_Name.Text = dv[0]["Test_Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtCharges.Text = dv[0]["Charges"].ToString();
            this.txtCharity.Text = dv[0]["charityrate"].ToString();

            this.txtAutomatedText.Text = dv[0]["AutomatedText"].ToString();
            this.txtClinicalUse.Text = dv[0]["ClinicalUse"].ToString();

            FillGV_Group(lblTestId.Text.Trim());
            FillGV_Mehtod(lblTestId.Text.Trim());

            if (!dv[0]["GroupId"].ToString().Equals(""))
            {
                this.ddlGroup.SelectedValue = dv[0]["GroupId"].ToString();
            }

            if (!dv[0]["SubdepartmentId"].ToString().Equals(""))
            {
                this.ddlSubdepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();
                
            }

            if (!dv[0]["SpecimenId"].ToString().Equals(""))
            {
                this.ddlSpecimen.SelectedValue = dv[0]["SpecimenId"].ToString();
            }

            FillSContainerDDL();

            if (!dv[0]["SContainerId"].ToString().Equals("") && !dv[0]["SContainerId"].ToString().Equals("0"))
            {
                this.ddlContainer.SelectedValue = dv[0]["SContainerId"].ToString();
            }

            if (!dv[0]["TestType"].ToString().Equals(""))
            {
                this.ddlTestType.SelectedValue = dv[0]["TestType"].ToString();
            }
            FillMethodDDL();
            try
            {
                ddlMethod.SelectedItem.Selected = false;
                ddlMethod.Items.FindByValue(dv[0]["d_methodid"].ToString()).Selected = true;
            }
            catch { }

            try
            {
                ddlProcedure.SelectedItem.Selected = false;
                ddlProcedure.Items.FindByValue(dv[0]["procedureid"].ToString()).Selected = true;
            }
            catch { }
            try
            {
                ddlRptFormat.SelectedItem.Selected = false;
                ddlRptFormat.Items.FindByValue(dv[0]["reportformat"].ToString()).Selected = true;
            }
            catch { }

            this.txtDOrder.Text = dv[0]["DOrder"].ToString();            
            this.txtSpeedKey.Text = dv[0]["SpeedKey"].ToString();
            this.txtChargesUrgent.Text = dv[0]["ChargesUrgent"].ToString();
            this.txtQuantity.Text = dv[0]["Qty"].ToString();
            this.txtUnit.Text = dv[0]["unit"].ToString();

            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            this.chkPrintGroup.Checked = (dv[0]["PrintGroup"].ToString().Equals("Y")) ? true : false;
            this.chkPrintTest.Checked = (dv[0]["PrintTest"].ToString().Equals("Y")) ? true : false;

            this.chkExternal.Checked = dv[0]["external"].ToString().Equals("Y") ? true : false;
            this.chkUrgent.Checked = (dv[0]["Urgent"].ToString().Equals("Y")) ? true : false;
            this.chkSepReport.Checked = (dv[0]["SepReport"].ToString().Equals("Y")) ? true : false;
            this.chkProvisionRPT.Checked = (dv[0]["provisionRpt"].ToString().Equals("Y")) ? true : false;

            if (dv[0]["external"].ToString().Equals("Y"))
            {
                FillExter_Org("Y");
                //try
                //{
                //    ddlExternalOrg.SelectedItem.Selected = false;
                //    ddlExternalOrg.Items.FindByValue(dv[0]["external_org"].ToString()).Selected = true;
                //    ddlExternalOrg.Enabled = true;
                //}
                //catch { }
            }
            else
            {
                FillExter_Org("N");
                //ddlExternalOrg.Enabled = false;
            }

            try
            {
                ddlExternalOrg.SelectedItem.Selected = false;
                ddlExternalOrg.Items.FindByValue(dv[0]["external_org"].ToString()).Selected = true;
            }
            catch { }
            GetApp_Age(lblTestId.Text.Trim());
            GetSchedule(lblTestId.Text.Trim());
        }
    }

    private void GetApp_Age(string test_id)
    {
        clsTest te = new clsTest();
        te.TestId = test_id;

        DataView dvA = te.GetAll(12);
        if (dvA.Count > 0)
        {
            for (int i = 0; i < dvA.Count; i++)
            {
                for (int j = 0; j < gvAgeApp.Rows.Count; j++)
                {
                    if (dvA[i]["gender"].ToString().Substring(0, 1).Equals("M") && gvAgeApp.Rows[j].Cells[0].Text.Trim().Equals("Male"))
                    {
                        ((TextBox)(gvAgeApp.Rows[j].Cells[1].FindControl("txtMinAge"))).Text = dvA[i]["minage"].ToString();
                        ((TextBox)(gvAgeApp.Rows[j].Cells[2].FindControl("txtMaxAge"))).Text = dvA[i]["maxage"].ToString();
                    }
                    else if (dvA[i]["gender"].ToString().Substring(0, 1).Equals("F") && gvAgeApp.Rows[j].Cells[0].Text.Trim().Equals("Female"))
                    {
                        ((TextBox)(gvAgeApp.Rows[j].Cells[1].FindControl("txtMinAge"))).Text = dvA[i]["minage"].ToString();
                        ((TextBox)(gvAgeApp.Rows[j].Cells[2].FindControl("txtMaxAge"))).Text = dvA[i]["maxage"].ToString();
                    }
                    else if (dvA[i]["gender"].ToString().Substring(0, 1).Equals("A") && gvAgeApp.Rows[j].Cells[0].Text.Trim().Equals("All"))
                    {
                        ((TextBox)(gvAgeApp.Rows[j].Cells[1].FindControl("txtMinAge"))).Text = dvA[i]["minage"].ToString();
                        ((TextBox)(gvAgeApp.Rows[j].Cells[2].FindControl("txtMaxAge"))).Text = dvA[i]["maxage"].ToString();
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < gvAgeApp.Rows.Count; i++)
            {
                ((TextBox)(gvAgeApp.Rows[i].Cells[1].FindControl("txtMinAge"))).Text = "0";
                ((TextBox)(gvAgeApp.Rows[i].Cells[2].FindControl("txtMaxAge"))).Text = "0";
            }
        }
    }
    private void GetSchedule(string test_id)
    {
        clsTest te = new clsTest();
        te.TestId = test_id;
        DataView dvSched = te.GetAll(14);
        if (dvSched.Count > 0)
        {
            if (dvSched[0]["type"].Equals("Daily"))
            {
                ddlPerform.SelectedIndex = 0;
                gvPerformOn.DataSource = null;
                gvPerformOn.DataBind();
            }
            else if (dvSched[0]["type"].Equals("Days"))
            {
                ddlPerform.SelectedIndex = 1;
                DataTable dt = new DataTable();
                dt.Columns.Add("Mon");
                dt.Columns.Add("Tue");
                dt.Columns.Add("Wed");

                dt.Columns.Add("Thurs");
                dt.Columns.Add("Fri");
                dt.Columns.Add("Sat");
                dt.Columns.Add("Sun");

                DataRow dr = dt.NewRow();
                dr["Mon"] = "";
                dr["Tue"] = "";
                dr["Wed"] = "";

                dr["Thurs"] = "";
                dr["Fri"] = "";
                dr["Sat"] = "";
                dr["Sun"] = "";

                dt.Rows.Add(dr);
                gvPerformOn.DataSource = dt;
                gvPerformOn.DataBind();

                for (int i = 0; i < dvSched.Count; i++)
                {
                    if (dvSched[i]["value"].ToString().Equals("Mon"))
                        ((CheckBox)(gvPerformOn.Rows[0].Cells[1].FindControl("chk1"))).Checked = true;
                    if (dvSched[i]["value"].ToString().Equals("Tue"))
                        ((CheckBox)(gvPerformOn.Rows[0].Cells[1].FindControl("chk2"))).Checked = true;
                    if (dvSched[i]["value"].ToString().Equals("Wed"))
                        ((CheckBox)(gvPerformOn.Rows[0].Cells[1].FindControl("chk3"))).Checked = true;

                    if (dvSched[i]["value"].ToString().Equals("Thurs"))
                        ((CheckBox)(gvPerformOn.Rows[0].Cells[1].FindControl("chk4"))).Checked = true;
                    if (dvSched[i]["value"].ToString().Equals("Fri"))
                        ((CheckBox)(gvPerformOn.Rows[0].Cells[1].FindControl("chk5"))).Checked = true;
                    if (dvSched[i]["value"].ToString().Equals("Sat"))
                        ((CheckBox)(gvPerformOn.Rows[0].Cells[1].FindControl("chk6"))).Checked = true;
                    if (dvSched[i]["value"].ToString().Equals("Sun"))
                        ((CheckBox)(gvPerformOn.Rows[0].Cells[1].FindControl("chk7"))).Checked = true;
                }
            }
            else if (dvSched[0]["type"].Equals("Weekly"))
            {
                ddlPerform.SelectedIndex = 2;
                gvPerformOn.DataSource = null;
                gvPerformOn.DataBind();

                DataTable dt = new DataTable();
                dt.Columns.Add("Mon");
                dt.Columns.Add("Tue");
                dt.Columns.Add("Wed");

                dt.Columns.Add("Thurs");
                dt.Columns.Add("Fri");
                dt.Columns.Add("Sat");
                dt.Columns.Add("Sun");

                for (int i = 0; i < 4; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Mon"] = "";
                    dr["Tue"] = "";
                    dr["Wed"] = "";

                    dr["Thurs"] = "";
                    dr["Fri"] = "";
                    dr["Sat"] = "";
                    dr["Sun"] = "";

                    dt.Rows.Add(dr);
                }
                gvPerformOn.DataSource = dt;
                gvPerformOn.DataBind();

                for (int i = 0; i < dvSched.Count; i++)
                {
                    string[] str = dvSched[i]["value"].ToString().Split('-');
                    int index = Convert.ToInt32(str.GetValue(0)) - 1;

                    if (str.GetValue(1).Equals("Mon"))
                        ((CheckBox)(gvPerformOn.Rows[index].Cells[1].FindControl("chk1"))).Checked = true;
                    if (str.GetValue(1).Equals("Tue"))
                        ((CheckBox)(gvPerformOn.Rows[index].Cells[1].FindControl("chk2"))).Checked = true;
                    if (str.GetValue(1).Equals("Wed"))
                        ((CheckBox)(gvPerformOn.Rows[index].Cells[1].FindControl("chk3"))).Checked = true;

                    if (str.GetValue(1).Equals("Thurs"))
                        ((CheckBox)(gvPerformOn.Rows[index].Cells[1].FindControl("chk4"))).Checked = true;
                    if (str.GetValue(1).Equals("Fri"))
                        ((CheckBox)(gvPerformOn.Rows[index].Cells[1].FindControl("chk5"))).Checked = true;
                    if (str.GetValue(1).Equals("Sat"))
                        ((CheckBox)(gvPerformOn.Rows[index].Cells[1].FindControl("chk6"))).Checked = true;
                    if (str.GetValue(1).Equals("Sun"))
                        ((CheckBox)(gvPerformOn.Rows[index].Cells[1].FindControl("chk7"))).Checked = true;
                }
            }
        }
        else
        {
            ddlPerform.SelectedIndex = 0;
            gvPerformOn.DataSource = null;
            gvPerformOn.DataBind();
        }
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

        Fillgv();
    }
    protected void ddlContainer_SelectedIndexChanged(object sender, EventArgs e)
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
            Session["TestId"] = lblTestId.Text.Trim();
            if (!lblGroupId.Text.Trim().Equals(""))
            {
                Session["GroupId"] = lblGroupId.Text.Trim();
            }
            else
            {
                Session["GroupId"] = "";
            }
            if (!lblSubDepartmentId.Text.Trim().Equals(""))
            {
                Session["SubDepartmentId"] = lblSubDepartmentId.Text.Trim();
            }
            else
            {
                Session["SubDepartmentId"] = "";
            }
            Response.Redirect("GroupD.aspx?testid="+lblTestId.Text.Trim()+"");
        }
    }
    protected void chkExternal_CheckedChanged(object sender, EventArgs e)
    {
        lblErrMsg.Text = "";
        if (chkExternal.Checked == true)
        {
            FillExter_Org("Y");
            //ddlExternalOrg.Enabled = true;
        }
        else
        {
            FillExter_Org("N");
            //ddlExternalOrg.Enabled = false;
        }
    }
    protected void ddlPerform_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPerform.SelectedItem.Value.ToString().Equals("Daily"))
        {
            gvPerformOn.DataSource = null;
            gvPerformOn.DataBind();
        }
        else if (ddlPerform.SelectedItem.Value.ToString().Equals("Days"))
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mon");
            dt.Columns.Add("Tue");
            dt.Columns.Add("Wed");

            dt.Columns.Add("Thurs");
            dt.Columns.Add("Fri");
            dt.Columns.Add("Sat");
            dt.Columns.Add("Sun");

            DataRow dr = dt.NewRow();
            dr["Mon"] = "";
            dr["Tue"] = "";
            dr["Wed"] = "";

            dr["Thurs"] = "";
            dr["Fri"] = "";
            dr["Sat"] = "";
            dr["Sun"] = "";

            dt.Rows.Add(dr);
            gvPerformOn.DataSource = dt;
            gvPerformOn.DataBind();
        }
        else if (ddlPerform.SelectedItem.Value.ToString().Equals("Weekly"))
        {
            gvPerformOn.DataSource = null;
            gvPerformOn.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mon");
            dt.Columns.Add("Tue");
            dt.Columns.Add("Wed");

            dt.Columns.Add("Thurs");
            dt.Columns.Add("Fri");
            dt.Columns.Add("Sat");
            dt.Columns.Add("Sun");

            for (int i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Mon"] = "";
                dr["Tue"] = "";
                dr["Wed"] = "";

                dr["Thurs"] = "";
                dr["Fri"] = "";
                dr["Sat"] = "";
                dr["Sun"] = "";

                dt.Rows.Add(dr);
            }
            gvPerformOn.DataSource = dt;
            gvPerformOn.DataBind();
        }
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        Session["reportname"] = "masterTest_origin";
        Session["selectionformula"] = "{dc_tp_test.active}='Y'";

        Response.Write("<script language='javascript'>window.open('../Report/GeneralReports.aspx')</script>");
    }

    protected void gvTest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            this.ddlGroup.SelectedValue = "-1";
            this.ddlSpecimen.SelectedValue = "-1";
            this.ddlSubdepartment.SelectedValue = "-1";

            lblErrMsg.Text = "";
            lblstatus.Text = "u";

            clsTest objDC = new clsTest();
            lblTestId.Text = objDC.TestId = gvTest.DataKeys[index].Value.ToString();

            DataView dv = objDC.GetAll(3);

            if (dv.Count > 0)
            {
                this.txtTest_Name.Text = dv[0]["Test_Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtCharges.Text = dv[0]["Charges"].ToString();
                this.txtCharity.Text = dv[0]["charityrate"].ToString();

                this.txtAutomatedText.Text = dv[0]["AutomatedText"].ToString();
                this.txtClinicalUse.Text = dv[0]["ClinicalUse"].ToString();
                this.txtMaxTime.Text = dv[0]["MaxTimeValue"].ToString().Trim();
                this.txtMinTime.Text = dv[0]["MinTimeValue"].ToString().Trim();
                try
                {
                    this.ddlTimeType.ClearSelection();
                    this.ddlTimeType.Items.FindByValue(dv[0]["timetype"].ToString().Trim()).Selected=true;
                }
                catch 
                {
                    this.ddlTimeType.ClearSelection();
                }
                FillGV_Group(lblTestId.Text.Trim());
                FillGV_Mehtod(lblTestId.Text.Trim());

                if (!dv[0]["GroupId"].ToString().Equals(""))
                {
                    this.ddlGroup.SelectedValue = dv[0]["GroupId"].ToString();
                }

                if (!dv[0]["SubdepartmentId"].ToString().Equals(""))
                {
                    this.ddlSubdepartment.SelectedValue = dv[0]["SubdepartmentId"].ToString();

                }

                if (!dv[0]["SpecimenId"].ToString().Equals(""))
                {
                    this.ddlSpecimen.SelectedValue = dv[0]["SpecimenId"].ToString();
                }

                FillSContainerDDL();

                if (!dv[0]["SContainerId"].ToString().Equals("") && !dv[0]["SContainerId"].ToString().Equals("0"))
                {
                    this.ddlContainer.SelectedValue = dv[0]["SContainerId"].ToString();
                }

                if (!dv[0]["TestType"].ToString().Equals(""))
                {
                    this.ddlTestType.SelectedValue = dv[0]["TestType"].ToString();
                }
                FillMethodDDL();
                try
                {
                    ddlMethod.SelectedItem.Selected = false;
                    ddlMethod.Items.FindByValue(dv[0]["d_methodid"].ToString()).Selected = true;
                }
                catch { }

                try
                {
                    ddlProcedure.SelectedItem.Selected = false;
                    ddlProcedure.Items.FindByValue(dv[0]["procedureid"].ToString()).Selected = true;
                }
                catch { }
                try
                {
                    ddlRptFormat.SelectedItem.Selected = false;
                    ddlRptFormat.Items.FindByValue(dv[0]["reportformat"].ToString()).Selected = true;
                }
                catch { }

                this.txtDOrder.Text = dv[0]["DOrder"].ToString();
                this.txtSpeedKey.Text = dv[0]["SpeedKey"].ToString();
                this.txtChargesUrgent.Text = dv[0]["ChargesUrgent"].ToString();
                this.txtQuantity.Text = dv[0]["Qty"].ToString();
                this.txtUnit.Text = dv[0]["unit"].ToString();

                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                this.chkPrintGroup.Checked = (dv[0]["PrintGroup"].ToString().Equals("Y")) ? true : false;
                this.chkPrintTest.Checked = (dv[0]["PrintTest"].ToString().Equals("Y")) ? true : false;

                this.chkExternal.Checked = dv[0]["external"].ToString().Equals("Y") ? true : false;
                this.chkUrgent.Checked = (dv[0]["Urgent"].ToString().Equals("Y")) ? true : false;
                this.chkSepReport.Checked = (dv[0]["SepReport"].ToString().Equals("Y")) ? true : false;
                this.chkProvisionRPT.Checked = (dv[0]["provisionRpt"].ToString().Equals("Y")) ? true : false;

                if (dv[0]["external"].ToString().Equals("Y"))
                {
                    FillExter_Org("Y");
                    //try
                    //{
                    //    ddlExternalOrg.SelectedItem.Selected = false;
                    //    ddlExternalOrg.Items.FindByValue(dv[0]["external_org"].ToString()).Selected = true;
                    //    ddlExternalOrg.Enabled = true;
                    //}
                    //catch { }
                }
                else
                {
                    FillExter_Org("N");
                    //ddlExternalOrg.Enabled = false;
                }

                try
                {
                    ddlExternalOrg.SelectedItem.Selected = false;
                    ddlExternalOrg.Items.FindByValue(dv[0]["external_org"].ToString()).Selected = true;
                }
                catch { }
                GetApp_Age(lblTestId.Text.Trim());
                GetSchedule(lblTestId.Text.Trim());
            }
        }
    }
}
