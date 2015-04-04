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
//using CrystalDecisions.CrystalReports.Engine;

public partial class verificationqueue : System.Web.UI.Page
{
    private static string DGSort = "";
    private static DataTable dtMicro = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "40";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    Fill_Branch();
                    Fill_Subdept();
                    Fill_Group();
                    Fill_GV();
                    dtMicro.Clear();
                    CreateDatatable();
                    //FillOrganismDDL();
                    pnlPatient.Visible = false;
                    pnlComent.Visible = false;
                    lblLess.Text = "<b> < " + System.Configuration.ConfigurationManager.AppSettings["hour"].ToString() + " Hour </b>";
                    lblGreater.Text = "<b> > " + System.Configuration.ConfigurationManager.AppSettings["hour"].ToString() + " Hour </b>";
                    lblOverdue.Text = "<b>Over due</b>";

                }
                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowed.aspx");
                }

            }
        }
        else
        {
            Response.Redirect("../Parameter/MainPage.aspx");
        }

    }

    protected void imgCLose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    public System.Web.UI.WebControls.TextBoxMode GetTextmode(string sFlag)
    {
        if (sFlag.Equals("1"))
        {
            return System.Web.UI.WebControls.TextBoxMode.SingleLine;
        }
        else
        {
            return System.Web.UI.WebControls.TextBoxMode.MultiLine;
        }
    }

    private void Fill_Subdept()
    {
        clsBLSpecimen sp = new clsBLSpecimen();
        SComponents com = new SComponents();

        DataView dv = sp.GetAll(2);
        com.FillDropDownList(ddlSubdept, dv, "name", "subdepartmentid");

        try
        {
            ddlSubdept.SelectedItem.Selected = false;
            ddlSubdept.Items.FindByValue(Session["u_subdeptid"].ToString()).Selected = true;
        }
        catch { }
        if (Session["crossdept"].Equals("N"))
            ddlSubdept.Enabled = false;
        else
            ddlSubdept.Enabled = true;
    }
    private void Fill_Branch()
    {
        clsBLResultEntry re = new clsBLResultEntry();
        SComponents com = new SComponents();
        DataView dv = re.GetAll(18);
        com.FillDropDownList(ddlBranch, dv, "name", "orgid");
        ddlBranch.ClearSelection();
        ddlBranch.Items.FindByValue(System.Configuration.ConfigurationManager.AppSettings["Clientid"].ToString().Trim()).Selected = true;
    }

    private void Fill_Group()
    {
        clsBLResultEntry sp = new clsBLResultEntry();
        SComponents com = new SComponents();

        if (Session["crossdept"].Equals("N"))
            sp.DepartmentID = Session["u_deptid"].ToString();
        else
           sp.DepartmentID = "";

        DataView dv = sp.GetAll(10);
        com.FillDropDownList(ddlTestGroup, dv, "name", "groupid");
    }
    private void Fill_GV()
    {
        if (ddlBranch.SelectedIndex <= 0)
            return;
        clsBLResultEntry re = new clsBLResultEntry();
        if (ddlSubdept.SelectedIndex > 0)
            re.SubDeptID = this.ddlSubdept.SelectedItem.Value.Replace("-1", "~!@");
        else
            re.SubDeptID = Session["u_subdeptid"].ToString();

        re.GroupID = this.ddlTestGroup.SelectedItem.Value.Replace("-1", "~!@");
        re.Type = this.ddlType.SelectedItem.Value.Trim().Replace("A", "~!@");
        re.ClientID = this.ddlBranch.SelectedItem.Value.ToString();
        re.BranchID = Session["BranchID"].ToString().Trim();

        if (!txtFrom.Text.Trim().Equals(""))
            re.FromDate = this.txtFrom.Text.Trim().Substring(6, 4) + "/" + txtFrom.Text.Trim().Substring(3, 2) + "/" + txtFrom.Text.Trim().Substring(0, 2);
        if (!txtTo.Text.Trim().Equals(""))
            re.ToDate = this.txtTo.Text.Trim().Substring(6, 4) + "/" + txtTo.Text.Trim().Substring(3, 2) + "/" + txtTo.Text.Trim().Substring(0, 2);

        re.ProcessID = "6";

        DataView dv = re.GetAll(1);
        dv.Sort = DGSort;
        gvQueue.DataSource = dv;
        gvQueue.DataBind();
        Urgent_Count();
    }
    
    public void Fill_Forward(DropDownList ddlForward, string strTestID)
    {
        clsBLResultEntry re = new clsBLResultEntry();
        SComponents com = new SComponents();
        re.TestID = strTestID;
        DataView dv = re.GetAll(12);
        com.FillDropDownList(ddlForward, dv, "name", "processid");
        for (int i = 0; i < dv.Count; i++)
        {
            if (Convert.ToInt32(dv[i]["processid"]) > 6)
            {
                ddlForward.SelectedItem.Selected = false;
                ddlForward.Items.FindByValue(dv[i]["processid"].ToString()).Selected = true;
            }
        }
    }

    protected void ddlDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Subdept();
        Fill_GV();
    }
    protected void ddlSubdept_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_GV();
        
    }
    protected void ddlTestGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_GV();
    }

    protected void gvQueue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            lblGreater.Visible = false;
            lblLess.Visible = false;
            lblOverdue.Visible = false;

            lblSelMode.Text = lblMode.Text;
            lblMode.Visible = false;

            int index = Convert.ToInt32(e.CommandArgument);

            lblPRno.Text = gvQueue.DataKeys[index].Value.ToString();
            lblTest.Text = gvQueue.Rows[index].Cells[4].Text.Trim();
            lblPatient.Text = ((LinkButton)(gvQueue.Rows[index].Cells[1].FindControl("lbtnGvPatient"))).Text.Trim();
            lblLabID.Text = ((LinkButton)(gvQueue.Rows[index].Cells[1].FindControl("lbtnGvLabID"))).Text.Trim();
            lblDespatchTime.Text = gvQueue.Rows[index].Cells[5].Text.Trim();
            lblBookingID.Text = gvQueue.DataKeys[index].Values[6].ToString();

            lblPRID.Text = gvQueue.DataKeys[index].Values[7].ToString();
            lblTestID.Text = gvQueue.DataKeys[index].Values[3].ToString();
            
            clsBLResultEntry re = new clsBLResultEntry();
            Session.Add("PAge", Convert.ToString(Convert.ToInt32(gvQueue.DataKeys[index].Values[5].ToString())));//+ 364
            Session.Add("PGender", gvQueue.DataKeys[index].Values[10].ToString());

            re.PRID = this.lblPRID.Text.Trim();
            re.BookingID = lblBookingID.Text.Trim();
            re.BookingDID = gvQueue.DataKeys[index].Values[11].ToString();
            //gvQueue.Rows[index].Cells[3].Text.Trim().Substring(0, 1);
            re.ProcessID = "6";
            re.SubDeptID = ddlSubdept.SelectedValue;

            re.BranchID = Session["BranchID"].ToString().Trim();
			DataView dv1 = re.GetAll(16);

            gvAllTestDetail.DataSource = dv1;
            gvAllTestDetail.DataBind();

            DataView dv = re.GetAll(17);

            gvMain.DataSource = dv;
            gvMain.DataBind();

            pnlPatient.Visible = true;
            pnl_sel.Visible = false;
            gvQueue.Visible = false;
        }
    }

    protected void btnToday_Click(object sender, EventArgs e)
    {
        txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        Fill_GV();

    }

    protected void btnlastDays_Click(object sender, EventArgs e)
    {
        txtFrom.Text = System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");

        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        Fill_GV();
    }
    protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        Fill_GV();
    }

    protected void imgClose_pnl_Click(object sender, ImageClickEventArgs e)
    {
        this.pnlPatient.Visible = false;
        this.pnl_sel.Visible = true;
        this.gvQueue.Visible = true;

        lblMode.Visible = true;
        lblGreater.Visible = true;

        lblLess.Visible = true;
        lblOverdue.Visible = true;
        Fill_GV();
        dtMicro.Clear();
        if (Session["PAge"] != null)
        {
            Session.Remove("PAge");
        }
        if (Session["PGender"] != null)
        {
            Session.Remove("PGender");
        }

        for (int i = 0; i < gvQueue.Rows.Count; i++)
        {
            double con_hour = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["hour"].ToString());
            System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo("ur-PK");

            DateTime nowTime = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yy hh:mm tt"), cult);
            DateTime dt_ = Convert.ToDateTime(gvQueue.Rows[i].Cells[5].Text.Trim(), cult);
            TimeSpan total = dt_.Subtract(nowTime);

            if (total.TotalHours >= con_hour)
            {
                gvQueue.Rows[i].BackColor = System.Drawing.Color.WhiteSmoke;
                gvQueue.Rows[i].ForeColor = System.Drawing.Color.Indigo;
            }
            else if (total.TotalHours > 0 && total.TotalHours <= con_hour)
            {
                gvQueue.Rows[i].BackColor = System.Drawing.Color.FromName("#66cc99");
                gvQueue.Rows[i].ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                gvQueue.Rows[i].BackColor = System.Drawing.Color.FromName("#99ccff");
                gvQueue.Rows[i].ForeColor = System.Drawing.Color.Black;
            }
        }
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            Update(i, false, false);
        }
        pnlPatient.Visible = false;
        pnl_sel.Visible = true;
        Fill_GV();
        gvQueue.Visible = true;
        lblPRID.Text = "";
        lblBookingID.Text = "";
        lblTestID.Text = "";
        if (Session["PAge"] != null)
        {
            Session.Remove("PAge");
        }
        if (Session["PGender"] != null)
        {
            Session.Remove("PGender");
        }
    }
    protected void gvQueue_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double con_hour = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["hour"].ToString());
            System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo("ur-PK");

            DateTime nowTime = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yy hh:mm tt"), cult);
            DateTime dt_ = Convert.ToDateTime(e.Row.Cells[5].Text.Trim(), cult);
            TimeSpan total = dt_.Subtract(nowTime);

            if (total.TotalHours >= con_hour)
            {
                e.Row.BackColor = System.Drawing.Color.WhiteSmoke;
                e.Row.ForeColor = System.Drawing.Color.Indigo;
            }
            else if (total.TotalHours > 0 && total.TotalHours <= con_hour)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#66cc99");
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#99ccff");
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            //e.Row.ID = "Row_" + e.Row.RowIndex.ToString();
            //int index = Convert.ToInt32(gvQueue.DataKeys[e.Row.RowIndex].Values[11].ToString());
            //// Here I'm just determining the blinking rows by every other row...
            ////(e.Row.RowIndex % 2) ==
            //if (index > 0)
            //{
            //    e.Row.Attributes.Add("blinkingRow", "Y");
            //    e.Row.Font.Bold = true;
            //}
            //else
            //    e.Row.Attributes.Add("blinkingRow", "N");

            //e.Row.Attributes.Add("blinkCounter", "0");

        }
    }

    protected void lbTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        TableCell tbc = ((TableCell)((ListBox)sender).Parent);
        ListBox lbTemplate = ((ListBox)tbc.FindControl("lbTemplate"));
        TextBox dgAttributeResult = ((TextBox)tbc.FindControl("txtResult"));

        string strText = lbTemplate.SelectedValue.ToString();
        if (strText.StartsWith("("))
        {
            int eIndex = strText.IndexOf(')', 1);
            strText = strText.Remove(0, eIndex + 1);
        }

        //if (!dgAttributeResult.Text.Contains(strText))
        //{
        //    if (!dgAttributeResult.Text.Trim().Equals(""))       //For more than template
        //        dgAttributeResult.Text += "\n";//"<br>";

        //    dgAttributeResult.Text += " " + strText;
        //}
        dgAttributeResult.Text = strText.Trim();

        lbTemplate.Visible = false;
    }
    protected void imgAtt_Temp_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow dgItem = ((GridViewRow)((ImageButton)sender).Parent.Parent);
        GridView gvAttribute = ((GridView)((ImageButton)sender).Parent.Parent.Parent.Parent);

        TableCell tbc = ((TableCell)((ImageButton)sender).Parent);
        ListBox lbTemplate = ((ListBox)tbc.FindControl("lbTemplate"));

        if (lbTemplate.Visible)
        {
            lbTemplate.Visible = false;
        }
        else
        {
            if (lbTemplate.Items.Count == 0)
            {
                String AttributeID = String.Empty;
                AttributeID = gvAttribute.DataKeys[dgItem.RowIndex].Value.ToString();
                if (null != lbTemplate)
                {
                    clsBLResultEntry objTemp = new clsBLResultEntry();
                    SComponents objComp = new SComponents();

                    objTemp.AttributeID = AttributeID;
                    //objTemp.PersonId = Session["PersonId"].ToString(); //PersonId                    

                    DataView dvSection = objTemp.GetAll(6);
                    objComp.FillListBox(lbTemplate, dvSection, "DESCRIPTION", "description", false);
                }
            }
            lbTemplate.Visible = (lbTemplate.Items.Count > 0);
            lbTemplate.ClearSelection();
        }
    }
    protected void gvQueue_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("labid"))
        {
            if (DGSort == "labid asc")
                DGSort = "labid desc";
            else
                DGSort = "labid asc";
            lblMode.Text = "Mode : Lab ID";
        }
        else if (e.SortExpression.Equals("patientname"))
        {
            if (DGSort == "patientname asc")
                DGSort = "patientname desc";
            else
                DGSort = "patientname asc";
            lblMode.Text = "Mode : Patient Name";
        }
        else if (e.SortExpression.Equals("gender"))
        {
            if (DGSort == "gender asc")
                DGSort = "gender desc";
            else
                DGSort = "gender asc";
            lblMode.Text = "Mode : Gender";
        }
        else if (e.SortExpression.Equals("age"))
        {
            if (DGSort == "age asc")
                DGSort = "age desc";
            else
                DGSort = "age asc";
            lblMode.Text = "Mode : Age";
        }
        else if (e.SortExpression.Equals("testname"))
        {
            if (DGSort == "testname asc")
                DGSort = "testname desc";
            else
                DGSort = "testname asc";
            lblMode.Text = "Mode : Test";
        }
        else if (e.SortExpression.Equals("deliverytime"))
        {
            if (DGSort == "deliverytime asc")
                DGSort = "deliverytime desc";
            else
                DGSort = "deliverytime asc";
            lblMode.Text = "Mode : Despatch Time";
        }
        else if (e.SortExpression.Equals("referenceno"))
        {
            if (DGSort == "referenceno asc")
                DGSort = "referenceno desc";
            else
                DGSort = "referenceno asc";

            lblMode.Text = "Mode : Reference No.";
        }
        else if (e.SortExpression.Equals("bookedon"))
        {
            if (DGSort == "bookedon asc")
                DGSort = "bookedon desc";
            else
                DGSort = "bookedon asc";

            lblMode.Text = "Mode : Booked On";
        }
        else if (e.SortExpression.Equals("type"))
        {
            if (DGSort == "type asc")
                DGSort = "type desc";
            else
                DGSort = "type asc";
            lblMode.Text = "Mode : Type";
        }
        Fill_GV();
    }

    protected void img_Add_Cmt_Click(object sender, ImageClickEventArgs e)
    {
        clsBLResultEntry re = new clsBLResultEntry();

        GridViewRow dgItem = ((GridViewRow)((ImageButton)sender).Parent.Parent);

        re.TestID = gvMain.DataKeys[dgItem.RowIndex].Values[2].ToString();

        gvMain.SelectedIndex = dgItem.RowIndex;

        re.Comment = "Comment";
        DataView dv = re.GetAll(7);
        if (dv.Count > 0)
        {
            gvTest_Template.DataSource = dv;
            gvTest_Template.Columns[1].HeaderText = "Comment";
            gvTest_Template.DataBind();

            pnlComent.Visible = true;
            pnlComent.GroupingText = "<b>Add Comment</b>";
            pnlComent.CssClass = "TemplatePanel";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No test comment found');</script>", false);
        }
    }
    protected void img_add_Opn_Click(object sender, ImageClickEventArgs e)
    {
        clsBLResultEntry re = new clsBLResultEntry();
        GridViewRow dgItem = ((GridViewRow)((ImageButton)sender).Parent.Parent);

        re.TestID = gvMain.DataKeys[dgItem.RowIndex].Values[2].ToString();
        gvMain.SelectedIndex = dgItem.RowIndex;

        re.Comment = "Opinion";
        DataView dv = re.GetAll(7);

        if (dv.Count > 0)
        {
            gvTest_Template.DataSource = dv;
            gvTest_Template.Columns[1].HeaderText = "Opinion";
            gvTest_Template.DataBind();

            pnlComent.Visible = true;
            pnlComent.GroupingText = "<b>Add Opinion</b>";
            pnlComent.CssClass = "TemplatePanel";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No test opinion found')</script>", false);
        }
    }
    protected void gvTest_Template_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            TextBox txtComment = (TextBox)gvMain.SelectedRow.Cells[3].FindControl("txtComment");
            TextBox txtOpinion = (TextBox)gvMain.SelectedRow.Cells[3].FindControl("txtOpinion");

            if (pnlComent.GroupingText.Equals("<b>Add Comment</b>"))
            {
                if (txtComment.Text.Trim().Contains(gvTest_Template.Rows[index].Cells[1].Text.Trim()))
                {
                    this.pnlComent.Visible = false;
                }
                else
                {
                    txtComment.Text += gvTest_Template.Rows[index].Cells[1].Text.Trim();
                    this.pnlComent.Visible = false;
                }
            }
            else if (pnlComent.GroupingText.Equals("<b>Add Opinion</b>"))
            {
                if (txtOpinion.Text.Trim().Contains(gvTest_Template.Rows[index].Cells[1].Text.Trim()))
                {
                    this.pnlComent.Visible = false;
                }
                else
                {
                    txtOpinion.Text += gvTest_Template.Rows[index].Cells[1].Text.Trim();
                    this.pnlComent.Visible = false;
                }
            }
        }
    }

    protected void lbtnAdd_Attrib_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Parameter/Attribute.aspx?testid=" + lblTestID.Text.Trim() + "");
    }
    protected void imgTem_Close_Click(object sender, ImageClickEventArgs e)
    {
        pnlComent.Visible = false;
    }
    protected void lbtnViewHistory_Click(object sender, EventArgs e)
    {
        clsBLResultEntry re = new clsBLResultEntry();
        re.PRID = lblPRID.Text.Trim();
        DataView dv = re.GetAll(14);

        string N_testID = "";
        string T_testID = "";

        dv.RowFilter = "attribute_type='T'";

        for (int i = 0; i < dv.Count; i++)
        {
            if (i == 0)
                T_testID = dv[i]["testid"].ToString();
            else
                T_testID += "," + dv[i]["Testid"].ToString();
        }

        if (dv.Count > 0)
        {
            string script_T = "<script>window.open('wfrmPatientHistory.aspx?testid=" + T_testID + " &prid=" + lblPRID.Text.Trim() + " &bookingid=" + lblBookingID.Text.Trim() + " &prno=" + lblPRno.Text.Trim() + " &name=" + lblPatient.Text.Trim() + " &type=T &report=patientHistory_T ')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "History_T", script_T, false);
        }

        dv.RowFilter = "attribute_type='N'";

        for (int i = 0; i < dv.Count; i++)
        {
            if (T_testID.Contains(dv[i]["testid"].ToString()))
            {
            }
            else
            {
                if (N_testID.Equals(""))
                    N_testID = dv[i]["testid"].ToString();
                else
                    N_testID += "," + dv[i]["testid"].ToString();
            }
        }

        if (!N_testID.Equals(""))
        {
            string script = "<script>window.open('wfrmPatientHistory.aspx?testid=" + N_testID + " &prid=" + lblPRID.Text.Trim() + " &bookingid=" + lblBookingID.Text.Trim() + " &prno=" + lblPRno.Text.Trim() + " &name=" + lblPatient.Text.Trim() + " &type=N &report=patientHistory_N ')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "History_N", script, false);
        }
    }
    protected void btnSavePrint_Click(object sender, EventArgs e)
    {
        string TestID = "";
        string BookingDID = "";
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if (Update(i, false, false))
            {
                TestID += gvMain.DataKeys[i].Values[2].ToString() + ",";
                BookingDID += gvMain.DataKeys[i].Values[1].ToString() + ",";
            }
        }

        TestID = TestID.Substring(0, TestID.Length - 1);
        BookingDID = BookingDID.Substring(0, BookingDID.Length - 1);

        string sSelectionFormula = "";
        sSelectionFormula = "{general_result_main.prid} in [" + lblPRID.Text.Trim() + "] and {general_result_main.testid} in [" + TestID.Trim() + "] and {general_result_main.bookingid} in [" + lblBookingID.Text.Trim() + "] and {general_result_main.bookingdid} in [" + BookingDID + "]";

        clsBLDispatch objDis = new clsBLDispatch();
        DataView dv = new DataView();

        objDis.PRID = lblPRID.Text.Trim();//prid
        objDis.TestID = TestID;// testid
        objDis.BookingID = lblBookingID.Text.Trim();//bookingid

        Session["reportname"] = "result";
        Session["selectionformula"] = "";
        Session["selectionformula"] = sSelectionFormula;

        dv = objDis.GetAll(9);
        Session["testtable"] = dv.Table;

        dv = objDis.GetAll(10);
        Session["testsubtable"] = dv.Table;
        Session.Add("SubRptName", "one_column_1");

        //if (!Session["ReportDoc"].Equals(""))
        //{
        //    ReportDocument doc = (ReportDocument)Session["ReportDoc"];
        //    doc.Close();
        //    doc.Dispose();
        //    GC.Collect();
        //    Session["ReportDoc"] = "";
        //}

        ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);

        pnlPatient.Visible = false;
        pnl_sel.Visible = true;
        Fill_GV();
        gvQueue.Visible = true;
        lblPRID.Text = "";
        lblBookingID.Text = "";
        lblTestID.Text = "";
        if (Session["PAge"] != null)
        {
            Session.Remove("PAge");
        }
        if (Session["PGender"] != null)
        {
            Session.Remove("PGender");
        }
    }

    private void CreateDatatable()
    {
        if (dtMicro.Columns.Count == 0)
        {
            dtMicro.Columns.Add("SNo");
            dtMicro.Columns.Add("OrganismID");
            dtMicro.Columns.Add("Organism");
            dtMicro.Columns.Add("DrugID");
            dtMicro.Columns.Add("Drug");
            dtMicro.Columns.Add("Senstivity");
        }
    }
    
    private void FillOrganismDDL(DropDownList ddl)
    {
        clsBLOrganism objOrganism = new clsBLOrganism();
        SComponents objScom = new SComponents();
        DataView dv = objOrganism.GetAll(4);
        objScom.FillDropDownList(ddl, dv, "Organism", "OrganismID", true, false, true);
        ddl.SelectedValue = "-1";
    }

    protected void ddlOrganism_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        lblError.Text = "";

        DropDownList ddl = (DropDownList)sender;
        GridView gvMicro = (GridView)(((DataControlFieldCell)ddl.Parent.Parent).FindControl("gvMicro"));
        clsBLDrugOrganism objDrugOrgan = new clsBLDrugOrganism();
        SComponents objScom = new SComponents();

        gvMicro.Visible = true;
        
        objDrugOrgan.OrganismID = ddl.SelectedValue.ToString();
        objDrugOrgan.Type = "O";
        DataView dv = objDrugOrgan.GetAll(2);

        gvMicro.DataSource = dv;
        gvMicro.DataBind();

        gvMicro.Enabled = true;
    }
    protected void gvSelectedMicro_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            GridView gvSelectedMicro = (GridView)sender;

            dtMicro = GetTblFromGridview(gvSelectedMicro);

            dtMicro.Rows.RemoveAt(Convert.ToInt16(e.CommandArgument));

            for (int i = 0; i < dtMicro.Rows.Count; i++)
            {
                dtMicro.Rows[i]["SNo"] = Convert.ToString(i + 1);
            }

            gvSelectedMicro.DataSource = dtMicro;
            gvSelectedMicro.DataBind();
        }
    }
    protected void btnRes_Click(object sender, EventArgs e)
    {
        int MainIndex = ((GridViewRow)((Button)sender).Parent.Parent.Parent.Parent.Parent.Parent.Parent).RowIndex;
        GridViewRow gvr = (GridViewRow)((Button)sender).Parent.Parent;

        lblError.ForeColor = System.Drawing.Color.Red;
        lblError.Text = "";

        DropDownList ddlOrganism = (DropDownList)gvMain.Rows[MainIndex].Cells[3].FindControl("ddlOrganism");
        GridView gvSelectedMicro = (GridView)gvMain.Rows[MainIndex].Cells[3].FindControl("gvSelectedMicro");
        GridView gvMicro = (GridView)gvMain.Rows[MainIndex].Cells[3].FindControl("gvMicro");

        dtMicro = GetTblFromGridview(gvSelectedMicro);

        if (ddlOrganism.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Information", "<script>alert('Select Organism');</script>", false);

            return;
        }

        for (int i = 0; i < dtMicro.Rows.Count; i++)
        {
            if (dtMicro.Rows[i]["OrganismID"].ToString().Equals(ddlOrganism.SelectedValue) && dtMicro.Rows[i]["DrugID"].ToString().Equals(gvMicro.DataKeys[gvr.DataItemIndex].Value.ToString()))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Information", "<script>alert('Drug for selected Organism already Add');</script>", false);
                return;
            }
        }

        DataRow dr = dtMicro.NewRow();
        dr["SNo"] = Convert.ToString(dtMicro.Rows.Count + 1);
        dr["OrganismId"] = ddlOrganism.SelectedValue;
        dr["Organism"] = ddlOrganism.SelectedItem.Text;
        dr["DrugID"] = gvMicro.DataKeys[gvr.DataItemIndex].Value.ToString();
        dr["Drug"] = gvr.Cells[0].Text;
        dr["Senstivity"] = ((Button)sender).Text;

        dtMicro.Rows.Add(dr);

        gvSelectedMicro.DataSource = dtMicro;
        gvSelectedMicro.DataBind();
    }

    protected void gvAttribute_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView gvAttribute = (GridView)sender;
        TextBox box = (TextBox)e.Row.Cells[2].FindControl("txtResult");
        
        if (box != null)
        {
            if (gvAttribute.DataKeys[e.Row.RowIndex].Values[3].ToString().Equals("N") && !gvAttribute.DataKeys[e.Row.RowIndex].Values[4].ToString().Equals("") && !gvAttribute.DataKeys[e.Row.RowIndex].Values[5].ToString().Equals(""))
            {
                box.Attributes.Add("onblur", "javascript:Calculate('" + gvAttribute.DataKeys[e.Row.RowIndex].Values[4].ToString() + "','" + gvAttribute.DataKeys[e.Row.RowIndex].Values[5].ToString() +

"',this);");
            }
        }
        if (e.Row.RowIndex != -1 && gvAttribute.DataKeys[e.Row.RowIndex].Values[8].ToString().Equals("Y"))
		{
			e.Row.Cells[2].Visible = false;
			e.Row.Cells[3].Visible = false;
			e.Row.Cells[4].Visible = false;
			e.Row.Cells[5].Visible = false;

			e.Row.Cells[1].Font.Bold = true;
			e.Row.Cells[1].ColumnSpan = 5;
		}
		else if (e.Row.RowIndex != -1)
		{
			e.Row.Cells[2].Visible = true;
			e.Row.Cells[3].Visible = true;
			e.Row.Cells[4].Visible = true;
			e.Row.Cells[5].Visible = true;
		}
    }
    protected void btnSaveNext_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            Update(i, false, false);
        }

        pnlPatient.Visible = false;
        pnl_sel.Visible = true;
        Fill_GV();
        gvQueue.Visible = true;
        lblPRID.Text = "";
        lblBookingID.Text = "";
        lblTestID.Text = "";
        if (Session["PAge"] != null)
        {
            Session.Remove("PAge");
        }
        if (Session["PGender"] != null)
        {
            Session.Remove("PGender");
        }

        if (gvQueue.Rows.Count > 0)
        {
            pnlPatient.Visible = true;
            pnl_sel.Visible = false;
            gvQueue.Visible = false;
            CommandEventArgs ce = new CommandEventArgs("Select", "0");
            GridViewCommandEventArgs ev = new GridViewCommandEventArgs(gvQueue.Rows[0], null, ce);
            gvQueue_RowCommand(gvQueue, ev);
        }
    }
    protected void lbtnPatientTrack_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('wfrmTrack.aspx');</script>", false);
    }
    
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int index = e.Row.RowIndex;
        if (index != -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)e.Row.Cells[2].FindControl("lbtnClinicalUse")).ToolTip = gvMain.DataKeys[index].Values[4].ToString().Equals("") ? "No clinical information found" : gvMain.DataKeys[index].Values[4].ToString();
            ((LinkButton)e.Row.Cells[3].FindControl("lbtnInterpretation")).ToolTip = gvMain.DataKeys[index].Values[5].ToString().Equals("") ? "No clinical information found" : gvMain.DataKeys[index].Values[5].ToString();

            GridView gvAttribute = new GridView();
            TextBox txtComment = new TextBox();
            TextBox txtOpin = new TextBox();

            DropDownList ddlForward = (DropDownList)e.Row.Cells[3].FindControl("ddlForward");
            gvAttribute = (GridView)e.Row.Cells[3].FindControl("gvAttribute");
            txtComment = (TextBox)e.Row.Cells[3].FindControl("txtComment");
            txtOpin = (TextBox)e.Row.Cells[3].FindControl("txtOpinion");

            Fill_Forward(ddlForward, gvMain.DataKeys[index].Values["testid"].ToString());

            clsBLResultEntry re = new clsBLResultEntry();
            re.TestID = gvMain.DataKeys[index].Values[2].ToString();

            re.Age = Session["PAge"].ToString();
            re.Gender = Session["PGender"].ToString();

            re.PRID = this.lblPRID.Text.Trim();
            re.BookingID = lblBookingID.Text.Trim();
            re.BookingDID = gvMain.DataKeys[index].Values[1].ToString();
            re.ClientID = this.ddlBranch.SelectedItem.Value.ToString();

            gvAttribute.Columns[4].Visible = true;
            gvAttribute.Columns[5].Visible = true;
            gvAttribute.Columns[4].ItemStyle.Width = Unit.Percentage(15);
            gvAttribute.Columns[5].ItemStyle.Width = Unit.Percentage(11);
            gvAttribute.Columns[2].ItemStyle.Width = Unit.Percentage(25);


            DataView dv = re.GetAll(11);

            gvAttribute.DataSource = dv;
            gvAttribute.DataBind();

            if (dv.Count == 0)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Attribute are not available.Please enter attribute.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert\n", "<script>alert('" + lblError.Text + "');</script>", false);
                ((LinkButton)e.Row.Cells[2].FindControl("lbtnAdd_Attrib")).Visible = true;

                txtComment.Text = "";
                txtOpin.Text = "";

            }
            else
            {
                ((LinkButton)e.Row.Cells[2].FindControl("lbtnAdd_Attrib")).Visible = false;
                txtComment.Text = dv[0]["comment"].ToString();
                txtOpin.Text = dv[0]["opinion"].ToString();
            }

            //int count = 0;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["heading"].Equals("N") && !dv[i]["TotalText"].Equals("0"))
                {
                    gvAttribute.Columns[4].Visible = false;
                    gvAttribute.Columns[5].Visible = false;
                    gvAttribute.Columns[2].ItemStyle.Width = Unit.Percentage(50);
                    break;
                }
            }

            pnlPatient.Visible = true;

            pnl_sel.Visible = false;
            gvQueue.Visible = false;

            if (ddlSubdept.SelectedValue.Equals("13"))
            {
                clsBLMicroSenstivity objMicroSenstivity = new clsBLMicroSenstivity();
                Panel pnlMicro = (Panel)e.Row.Cells[3].FindControl("pnlMicro");

                pnlMicro.Visible = true;

                DropDownList ddl = new DropDownList();
                ddl = (DropDownList)e.Row.Cells[3].FindControl("ddlOrganism");
                FillOrganismDDL(ddl);

                //GridView gvMicro = (GridView)e.Row.Cells[3].FindControl("gvMicro");
                GridView gvSelectedMicro = (GridView)e.Row.Cells[3].FindControl("gvSelectedMicro");

                objMicroSenstivity.LabID = lblLabID.Text;
                objMicroSenstivity.TestID = gvMain.DataKeys[index].Values[2].ToString();

                dtMicro = objMicroSenstivity.GetAll(1).Table;

                for (int i = 0; i < dtMicro.Rows.Count; i++)
                {
                    dtMicro.Rows[i]["SNo"] = Convert.ToString(i + 1);
                }
                gvSelectedMicro.DataSource = dtMicro;
                gvSelectedMicro.DataBind();
            }
            else
            {
                Panel pnlMicro = (Panel)e.Row.Cells[3].FindControl("pnlMicro");
                pnlMicro.Visible = false;
                dtMicro.Rows.Clear();
            }
        }
    }
    private DataTable GetTblFromGridview(GridView gv)
    {
        DataTable dt = dtMicro;
        dt.Rows.Clear();

        for (int i = 0; i < gv.Rows.Count; i++)
        {
            DataRow dr;
            dr = dt.NewRow();

            dr["SNo"] = gv.Rows[i].Cells[0].Text;
            dr["OrganismID"] = gv.DataKeys[i].Values[0].ToString();
            dr["Organism"] = gv.Rows[i].Cells[1].Text;
            dr["DrugID"] = gv.DataKeys[i].Values[1].ToString();
            dr["Drug"] = gv.Rows[i].Cells[2].Text; ;
            dr["Senstivity"] = gv.Rows[i].Cells[3].Text; ;

            dt.Rows.Add(dr);
        }
        return dt;
    }

    private void FillGVMain()
    {
        clsBLResultEntry re = new clsBLResultEntry();
        re.BookingID = lblBookingID.Text.Trim();
        re.ProcessID = "6";
        re.SubDeptID = ddlSubdept.SelectedValue;

        re.BranchID = Session["BranchID"].ToString().Trim();
        DataView dv = re.GetAll(17);

        gvMain.DataSource = dv;
        gvMain.DataBind();
    }
    protected void lbtnOrderByLabID_Click(object sender, EventArgs e)
    {
        if (DGSort.Contains("asc"))
        {
            DGSort = "labid desc";
        }
        else
        {
            DGSort = "labid asc";
        }
        Fill_GV();
        lblSelMode.Text = "Mode : LabBID";
        lblMode.Text = "Mode : LabBID";
    }
    protected void lbtnOtherTest_Click(object sender, EventArgs e)
    {
        try
        {
            ibtnCloseOtherTest.Visible = true;
            pnlOtherTest.Visible = true;
            gvAllTestDetail.Visible = true;
        }
        catch (Exception exc)
        {
            lblError.Visible = true;
            lblError.Text = exc.Message;
        }
    }
    protected void ibtnCloseOtherTest_Click(object sender, ImageClickEventArgs e)
    {
        //OtherTest.Visible = false;
        pnlOtherTest.Visible = false;
        gvAllTestDetail.Visible = false;
        ibtnCloseOtherTest.Visible = false;
    }

    protected void gvAllTestDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            string sSelectionFormula = "{general_result_main.testid} in [" + gvAllTestDetail.DataKeys[index].Values[2].ToString() + "] and {general_result_main.bookingid} in [" + gvAllTestDetail.DataKeys[index].Values[0].ToString() + "]";

            Session["reportname"] = "result";
            Session["selectionformula"] = "";
            Session["selectionformula"] = sSelectionFormula;

            DataView dv = new DataView();
            DataView dvSub = new DataView();
            clsBLDispatch objDis = new clsBLDispatch();

            objDis.TestID = gvAllTestDetail.DataKeys[index].Values[2].ToString(); // testid
            objDis.BookingID = gvAllTestDetail.DataKeys[index].Values[0].ToString(); //bookingid

            dv = objDis.GetAll(9);
            dvSub = objDis.GetAll(10);


            Session.Add("TestTable", dv.Table);
            Session.Add("SubTable", dvSub.Table);
            Session.Add("SubRptName", "one_column_1");

            //if (!Session["ReportDoc"].Equals(""))
            //{
            //    ReportDocument doc = (ReportDocument)Session["ReportDoc"];
            //    doc.Close();
            //    doc.Dispose();
            //    GC.Collect();
            //    Session["ReportDoc"] = "";
            //}

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
        }
    }
    protected void gvAllTestDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int index = e.Row.RowIndex;
        string str = "6,7,8";
        if (index != -1)
        {
            if (!str.Contains(gvAllTestDetail.DataKeys[index].Values[3].ToString()))
            {
                e.Row.Cells[2].Visible = false;
            }
        }
    }

    protected void lbtnGvLabID_Click(object sender, EventArgs e)
    {
        GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);
        
        lblGreater.Visible = false;
        lblLess.Visible = false;
        lblOverdue.Visible = false;

        lblSelMode.Text = lblMode.Text;
        lblMode.Visible = false;

        int index = gridItem.DataItemIndex;

        lblPRno.Text = gvQueue.DataKeys[index].Value.ToString();
        lblTest.Text = gvQueue.Rows[index].Cells[4].Text.Trim();
        lblPatient.Text = ((LinkButton)(gvQueue.Rows[index].Cells[1].FindControl("lbtnGvPatient"))).Text.Trim();

        lblLabID.Text = ((LinkButton)(gvQueue.Rows[index].Cells[1].FindControl("lbtnGvLabID"))).Text.Trim();
        lblDespatchTime.Text = gvQueue.Rows[index].Cells[5].Text.Trim();
        lblBookingID.Text = gvQueue.DataKeys[index].Values[6].ToString();

        lblPRID.Text = gvQueue.DataKeys[index].Values[7].ToString();
        lblTestID.Text = gvQueue.DataKeys[index].Values[3].ToString();

        clsBLResultEntry re = new clsBLResultEntry();
        Session.Add("PAge", Convert.ToString(Convert.ToInt32(gvQueue.DataKeys[index].Values[5].ToString())));//+ 364
        Session.Add("PGender", gvQueue.DataKeys[index].Values[10].ToString());

        re.PRID = this.lblPRID.Text.Trim();
        re.BookingID = lblBookingID.Text.Trim();
        gvQueue.Rows[index].Cells[3].Text.Trim().Substring(0, 1);
        re.ProcessID = "6";
        re.SubDeptID = ddlSubdept.SelectedValue;
        re.ClientID = this.ddlBranch.SelectedItem.Value.ToString();

        re.BranchID = Session["BranchID"].ToString().Trim();
        DataView dv1 = re.GetAll(16);

        gvAllTestDetail.DataSource = dv1;
        gvAllTestDetail.DataBind();

        DataView dv = re.GetAll(17);

        gvMain.DataSource = dv;
        gvMain.DataBind();

        pnlPatient.Visible = true;

        pnl_sel.Visible = false;
        gvQueue.Visible = false;
    }
    protected void lbtnGvPatient_Click(object sender, EventArgs e)
    {
        GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);
        lblGreater.Visible = false;
        lblLess.Visible = false;
        lblOverdue.Visible = false;

        lblSelMode.Text = lblMode.Text;
        lblMode.Visible = false;

        int index = gridItem.DataItemIndex;

        lblPRno.Text = gvQueue.DataKeys[index].Value.ToString();
        lblTest.Text = gvQueue.Rows[index].Cells[4].Text.Trim();
        lblPatient.Text = ((LinkButton)(gvQueue.Rows[index].Cells[1].FindControl("lbtnGvPatient"))).Text.Trim();
        lblLabID.Text = ((LinkButton)(gvQueue.Rows[index].Cells[1].FindControl("lbtnGvLabID"))).Text.Trim();
        lblDespatchTime.Text = gvQueue.Rows[index].Cells[5].Text.Trim();
        lblBookingID.Text = gvQueue.DataKeys[index].Values[6].ToString();

        lblPRID.Text = gvQueue.DataKeys[index].Values[7].ToString();
        lblTestID.Text = gvQueue.DataKeys[index].Values[3].ToString();

        clsBLResultEntry re = new clsBLResultEntry();
        Session.Add("PAge", Convert.ToString(Convert.ToInt32(gvQueue.DataKeys[index].Values[5].ToString())));//+ 364
        Session.Add("PGender", gvQueue.DataKeys[index].Values[10].ToString());

        re.PRID = this.lblPRID.Text.Trim();
        re.BookingID = lblBookingID.Text.Trim();
        gvQueue.Rows[index].Cells[3].Text.Trim().Substring(0, 1);
        re.ProcessID = "6";
        re.SubDeptID = ddlSubdept.SelectedValue;
        re.ClientID = this.ddlBranch.SelectedItem.Value.ToString();

        re.BranchID = Session["BranchID"].ToString().Trim();
        DataView dv1 = re.GetAll(16);

        gvAllTestDetail.DataSource = dv1;
        gvAllTestDetail.DataBind();

        DataView dv = re.GetAll(17);

        gvMain.DataSource = dv;
        gvMain.DataBind();

        pnlPatient.Visible = true;

        pnl_sel.Visible = false;
        gvQueue.Visible = false;
    }

    protected void imgSaveTest_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgSaveTest = (ImageButton)sender;
        int index = ((GridViewRow)imgSaveTest.Parent.Parent).RowIndex;

        Update(index, false, true);
    }

    protected void btnTestSavePrint_Click(object sender, EventArgs e)
    {
        Button btnTestSavePrint = (Button)sender;
        int index = ((GridViewRow)btnTestSavePrint.Parent.Parent).RowIndex;

        Update(index, true, true);
    }

    private bool Update(int index, bool Print, bool clear)
    {
        lblError.ForeColor = System.Drawing.Color.Red;

        DropDownList ddlForward = (DropDownList)gvMain.Rows[index].Cells[3].FindControl("ddlForward");
        TextBox txtComment = (TextBox)gvMain.Rows[index].Cells[3].FindControl("txtComment");
        TextBox txtOpinion = (TextBox)gvMain.Rows[index].Cells[3].FindControl("txtOpinion");
        GridView gvSelectedMicro = (GridView)gvMain.Rows[index].Cells[3].FindControl("gvSelectedMicro");
        GridView gvAttribute = (GridView)gvMain.Rows[index].Cells[3].FindControl("gvAttribute");

        string[,] strMicro = new string[gvSelectedMicro.Rows.Count, 3];

        if (ddlForward.SelectedIndex <= 0)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please select forward to from the list";
            ddlForward.Focus();
            return false ;
        }
        if (txtComment.Text.Length > 1024)
        {
            lblError.Text = "Comment text length is greater than 1024.Please enter less than or equal to 1024 character";
            txtComment.Focus();
            return false;
        }
        if (txtOpinion.Text.Length > 1024)
        {
            lblError.Text = "Opinion text length is greater than 1024.Please enter less than or equal to 1024 character";
            txtOpinion.Focus();
            return false;
        }
        clsBLResultEntry re = new clsBLResultEntry();
        clsValidation valid = new clsValidation();
        re.LabID = lblLabID.Text.Trim();
        re.BookingID = lblBookingID.Text.Trim();
        re.PRID = lblPRID.Text.Trim();
        re.TestID = gvMain.DataKeys[index].Values[2].ToString();

        re.BookingDID = gvMain.DataKeys[index].Values[1].ToString();
        re.ProcessID = ddlForward.SelectedItem.Value.ToString();
        re.Comment = txtComment.Text.Trim().Replace("'", "''");
        re.Opinion = txtOpinion.Text.Trim().Replace("'", "''");
              
        re.PersonID = Session["personid"].ToString();
        re.EnteredBy = Session["personid"].ToString();
        re.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        re.ClientID = Session["orgid"].ToString();
        
        //In case of microbiology
        if (ddlSubdept.SelectedValue.Equals("13"))
        {
            dtMicro = GetTblFromGridview(gvSelectedMicro);

            for (int k = 0; k < dtMicro.Rows.Count; k++)
            {
                strMicro[k, 0] = dtMicro.Rows[k]["OrganismID"].ToString();
                strMicro[k, 1] = dtMicro.Rows[k]["DrugID"].ToString();
                strMicro[k, 2] = dtMicro.Rows[k]["Senstivity"].ToString();
            }
        }

        if (Convert.ToInt32(ddlForward.SelectedItem.Value.ToString()) > 5)
        {
            string[,] str = new string[gvAttribute.Rows.Count, 11];
            int chk = 0;
            for (int i = 0; i < gvAttribute.Rows.Count; i++)
            {
                if (((TextBox)(gvAttribute.Rows[i].Cells[2].FindControl("txtResult"))).Text.Trim() != "")
                {
                    chk++;
                    break;
                }
            }
            if (chk == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please enter test result ');</script>", false);
                return false;
            }
            int count = 0;
            for (int i = 0; i < gvAttribute.Rows.Count; i++)
            {
                str[count, 0] = gvAttribute.DataKeys[i].Value.ToString(); //attribute id
                str[count, 1] = ((CheckBox)(gvAttribute.Rows[i].Cells[0].FindControl("chkRPrint"))).Checked ? "Y" : "N";
                str[count, 2] = ((TextBox)(gvAttribute.Rows[i].Cells[2].FindControl("txtResult"))).Text.Trim().Equals("") ? "-" : ((TextBox)(gvAttribute.Rows[i].Cells[2].FindControl("txtResult"))).Text.Trim().Replace("'","''");

                if (gvAttribute.DataKeys[i].Values[3].ToString().Equals("N") && str[count, 2] != "-" && valid.IsNumber(str[count, 2]) && valid.IsNumber(gvAttribute.DataKeys[i].Values[4].ToString()) && valid.IsNumber(gvAttribute.DataKeys[i].Values[5].ToString()) && Convert.ToDouble(str[count, 2]) >= Convert.ToDouble(gvAttribute.DataKeys[i].Values[4].ToString()) && Convert.ToDouble(str[count, 2]) <= Convert.ToDouble(gvAttribute.DataKeys[i].Values[5].ToString()))
                {
                    str[count, 3] = "N";
                }
                else if (gvAttribute.DataKeys[i].Values[3].ToString().Equals("T"))
                {
                    str[count, 3] = "N";
                }
                else
                {
                    str[count, 3] = "Y"; // abnormal
                }
                if (gvAttribute.DataKeys[i].Values[8].ToString().Equals("N"))
                {
                    str[count, 4] = gvAttribute.DataKeys[i].Values[2].ToString(); // range id
                }
                else
                {
                    str[count, 4] = "0"; // range id
                }
                if (!gvAttribute.Rows[i].Cells[4].Text.Trim().Replace("-", "").Equals("") || !gvAttribute.Rows[i].Cells[5].Text.Trim().Replace("-", "").Equals(""))
                {
                    str[count, 5] = "(" + gvAttribute.Rows[i].Cells[4].Text.Trim() + ")";
                    if (!gvAttribute.Rows[i].Cells[5].Text.Trim().Replace("-", "").Equals(""))
                    {
                        str[count, 5] += gvAttribute.Rows[i].Cells[5].Text.Trim();
                    }
                }
                else
                    str[count, 5] = "~!@";
                str[count, 6] = gvAttribute.DataKeys[i].Values[6].ToString(); // result id
                // str[count, 5] = gvAttribute.Rows[i].Cells[4].Text.Trim() + " U-" + gvAttribute.Rows[i].Cells[5].Text.Trim(); // range text
                str[count, 7] = gvAttribute.DataKeys[i].Values[8].ToString();//heading
                str[count, 8] = gvAttribute.DataKeys[i].Values[9].ToString(); // dorder
                str[count, 9] = gvAttribute.DataKeys[i].Values[10].ToString(); // attribute name
                str[count, 10] = gvAttribute.DataKeys[i].Values[3].ToString(); // type
                count++;
            }
            if (count == 0)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Attribute are not available.Please enter attribute.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + lblError.Text + "');</script>", false);
                return false;
            }

            if (re.Update_Verifiy(str, strMicro))
            {
                if (Print)
                {
                    string sSelectionFormula = "";
                    sSelectionFormula = "{general_result_main.prid} in [" + lblPRID.Text.Trim() + "] and {general_result_main.testid} in [" + gvMain.DataKeys[index].Values[2].ToString() + "] and {general_result_main.bookingid} in [" + lblBookingID.Text.Trim() + "] and {general_result_main.bookingdid} in [" + gvMain.DataKeys[index].Values[1].ToString() + "]";

                    clsBLDispatch objDis = new clsBLDispatch();
                    DataView dv = new DataView();

                    objDis.PRID = lblPRID.Text.Trim();//prid
                    objDis.TestID = gvMain.DataKeys[index].Values[2].ToString();// testid
                    objDis.BookingID = lblBookingID.Text.Trim();//bookingid

                    Session["reportname"] = "result";
                    Session["selectionformula"] = "";
                    Session["selectionformula"] = sSelectionFormula;

                    dv = objDis.GetAll(9);
                    Session["testtable"] = dv.Table;

                    dv = objDis.GetAll(10);
                    Session["testsubtable"] = dv.Table;
                    Session.Add("SubRptName", "one_column_1");

                    //if (!Session["ReportDoc"].Equals(""))
                    //{
                    //    ReportDocument doc = (ReportDocument)Session["ReportDoc"];
                    //    doc.Close();
                    //    doc.Dispose();
                    //    GC.Collect();
                    //    Session["ReportDoc"] = "";
                    //}
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
                }
                else if (clear)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Successfull", "<script>alert('Result has been entered successfully');</script>", false);
                }
                if (clear)
                {
                    FillGVMain();
                    if (gvMain.Rows.Count == 0)
                    {
                        pnlPatient.Visible = false;
                        pnl_sel.Visible = true;
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.add_load(blinkGridViewRows);", true);
                        Fill_GV();
                        gvQueue.Visible = true;
                        //lblPRID.Text = "";
                        lblBookingID.Text = "";
                        //lblTestID.Text = "";
                        lblError.Text = "";

                        dtMicro.Clear();

                        if (Session["PAge"] != null)
                        {
                            Session.Remove("PAge");
                        }
                        if (Session["PGender"] != null)
                        {
                            Session.Remove("PGender");
                        }
                    }
                }
                return true ;
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = re.Error;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + re.Error + "');</script>", false);
                return false;
            }
        }
        else
        {
            if (re.sentBack())
            {
               if (Print)
				{
					string sSelectionFormula = "";
					sSelectionFormula = "{general_result_main.prid} in [" + lblPRID.Text.Trim() + "] and {general_result_main.testid} in [" + gvMain.DataKeys[index].Values[2].ToString() + "] and {general_result_main.bookingid} in [" + lblBookingID.Text.Trim() + "]";

					Session["reportname"] = "result";
					Session["selectionformula"] = "";
					Session["selectionformula"] = sSelectionFormula;

                    //if (!Session["ReportDoc"].Equals(""))
                    //{
                    //    ReportDocument doc = (ReportDocument)Session["ReportDoc"];
                    //    doc.Close();
                    //    doc.Dispose();
                    //    GC.Collect();
                    //    Session["ReportDoc"] = "";
                    //}
					ScriptManager.RegisterStartupScript(this , typeof(Page) , "Result" , "<script>window.open('../Report/GeneralReports.aspx');</script>" , false); 
				}
                if (clear)
                {
                    FillGVMain();
                    if (gvMain.Rows.Count == 0)
                    {
                        pnlPatient.Visible = false;
                        pnl_sel.Visible = true;
                        Fill_GV();
                        gvQueue.Visible = true;
                        lblPRID.Text = "";
                        lblBookingID.Text = "";
                        lblTestID.Text = "";
                        if (Session["PAge"] != null)
                        {
                            Session.Remove("PAge");
                        }
                        if (Session["PGender"] != null)
                        {
                            Session.Remove("PGender");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Successfull", "<script>alert('Test has been sent back successfully');</script>", false);
                    }
                }
                return true;
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = re.Error;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + re.Error + "');</script>", false);
                return false;
            }
        }    
    }

    private void Urgent_Count()
    {
        //int ct = 0;
        //for (int i = 0; i < gvQueue.Rows.Count; i++)
        //{
        //    if (Convert.ToInt32(gvQueue.DataKeys[i].Values[11].ToString()) > 0)
        //        ct++;
        //}
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Urgent test:"+ct+" ');</script>", false);
    }

    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblTest_intCmt.Text = "Investigation: " + gvMain.Rows[index].Cells[1].Text.Trim();
            lblInt_Index.Text = index.ToString();
            lblInt_BookingID.Text = gvMain.DataKeys[index].Value.ToString();
            lblInt_testID.Text = gvMain.DataKeys[index].Values[2].ToString();

            txtInt_Comnt.Text = "";


            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
            SComponents com = new SComponents();
            iv.TestID = gvMain.DataKeys[index].Values[2].ToString();
            iv.BookingID = gvMain.DataKeys[index].Value.ToString();
            iv.For_Process = "6";
            DataView dv = iv.GetAll(29);
            com.FillDropDownList(ddlFor_Process, dv, "name", "processid");

            DataView dvCmt = iv.GetAll(30);
            gvIntComment.DataSource = dvCmt;
            gvIntComment.DataBind();
            //pnlInt_cmmnt.Visible = true;
            cpeWaiting.Collapsed = true;
            mde_intcmt.Show();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.remove_load(blinkGridViewRows);", true);

        }
    }
    protected void imgcmt_save_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.remove_load(blinkGridViewRows);", true);

        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

        iv.TestID = lblInt_testID.Text.Trim();
        iv.BookingID = this.lblInt_BookingID.Text.Trim();
        iv.Int_Comment = txtInt_Comnt.Text.Trim();
        iv.For_Process = ddlFor_Process.SelectedItem.Value.ToString().Replace("-1", "null");

        iv.ProcessID = "6";
        iv.EnteredBy = Session["personid"].ToString();
        iv.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        iv.ClientID = Session["orgid"].ToString();

        if (txtInt_Comnt.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please enter comment');</script>", false);
            return;
        }
        else
        {
            if (iv.Insert_IntComent())
            {
                mde_intcmt.Hide();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + iv.Error + "');</script>", false);
            }
        }


    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {       
            Fill_GV();
       
    }
}
