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

public partial class Dispatch : System.Web.UI.Page
{
    private static string DGSort = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            //if (!Session["ReportDoc"].Equals(""))
            //{
            //    ReportDocument doc = (ReportDocument)Session["ReportDoc"];
            //    doc.Close();
            //    doc.Dispose();
            //    GC.Collect();
            //    Session["ReportDoc"] = "";
            //}
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "43";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Status_Fill();
                    Panel_Fill();
                    Dept_Fill();

                    SubDept_Fill();
                    Group_Fill();
                    Test_Fill();
                    Ward_Fill();

                    rdbPatientOption.Items.FindByValue("C").Selected = true;
                    pnl_Pnl_info.Visible = false;

                    txtFromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    GV_Fill();
                    FillGV_External();

                }
                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowedCashier.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../NewLogin.aspx");
        }
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../NewLogin.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_Form();
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {        
        int count = 0;
        string StrPRID = "";
        string StrBookingID = "";
        string StrTestID = "";
        string StrBooking_DID = "";

        for (int i = 0; i < gvResult.Rows.Count; i++)
        {
            if (((CheckBox)(gvResult.Rows[i].Cells[0].FindControl("chkGVSelect"))).Checked)
            {
                if (gvResult.DataKeys[i].Values[6].ToString().Equals("C") &&  Convert.ToInt32(gvResult.Rows[i].Cells[7].Text.Trim().Replace("-", "0")) > 0)
                {  
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                    return;
                }
                if (count == 0)
                {
                    StrPRID = gvResult.DataKeys[i].Value.ToString();
                    StrBookingID = gvResult.DataKeys[i].Values[1].ToString();                    
                }
                if (count>0 && StrPRID != gvResult.DataKeys[i].Value.ToString() && StrBookingID != gvResult.DataKeys[i].Values[1].ToString())
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('Please select same lab id.');</script>", false);
                    return;
                }
                else
                {
                    count++;
                }
            }
        }
        if (count == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('Please select patient first');</script>", false);
        }
        else
        {
            clsBLDispatch ds = new clsBLDispatch();

            ds.EnteredBy = Session["personid"].ToString();
            ds.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            ds.ClientID = Session["clientid"].ToString().Trim(); //Session["orgid"].ToString();

            string[,] str = new string[count, 6];
            count = 0;
            for (int i = 0; i < gvResult.Rows.Count; i++)
            {
                if (((CheckBox)(gvResult.Rows[i].Cells[0].FindControl("chkGVSelect"))).Checked)
                {
                    str[count, 0] = gvResult.DataKeys[i].Value.ToString();//prid
                    str[count, 1] = gvResult.DataKeys[i].Values[1].ToString(); //bookingid
                    str[count, 2] = gvResult.DataKeys[i].Values[2].ToString(); // testid
                    str[count, 3] = gvResult.Rows[i].Cells[2].Text.Trim(); //labid
                    str[count, 4] = gvResult.DataKeys[i].Values[3].ToString(); //processid
                    str[count, 5] = gvResult.DataKeys[i].Values[5].ToString(); //bookingDID

                    if (count == 0)
                    {
                        StrPRID = gvResult.DataKeys[i].Value.ToString();
                        StrBookingID = gvResult.DataKeys[i].Values[1].ToString();
                        StrTestID = gvResult.DataKeys[i].Values[2].ToString();
                        StrBooking_DID = gvResult.DataKeys[i].Values[5].ToString(); //bookingDID
                    }
                    else
                    {
                        StrPRID = StrPRID + "," + gvResult.DataKeys[i].Value.ToString();
                        StrBookingID = StrBookingID + "," + gvResult.DataKeys[i].Values[1].ToString();
                        StrTestID = StrTestID + "," + gvResult.DataKeys[i].Values[2].ToString();
                        StrBooking_DID = StrBooking_DID + "," + gvResult.DataKeys[i].Values[5].ToString(); //bookingDID
                    }

                    count++;
                }
            }
            if (ds.Dispatch(str))
            {
                DataView dv = new DataView();

                ds.PRID = StrPRID;//prid
                ds.TestID = StrTestID; // testid
                ds.BookingID = StrBookingID; //bookingid

                dv = ds.GetAll(9);
                Session["testtable"] = dv.Table;

                dv = ds.GetAll(10);
                Session["testsubtable"] = dv.Table;
                Session.Add("SubRptName", "one_column_1");

                string sSelectionFormula = "";
                sSelectionFormula = "{general_result_main.prid} in [" + StrPRID + "] and {general_result_main.testid} in [" + StrTestID + "] and {general_result_main.bookingid} in [" + StrBookingID + "] and {general_result_main.bookingdid} in [" + StrBooking_DID + "]";


                Session["reportname"] = "result";
                Session["selectionformula"] = "";
                Session["selectionformula"] = sSelectionFormula;

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
                             
                GV_Fill();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('"+ds.Error+"')</script>", false);
            }

        }
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        GV_Fill();
        FillGV_External();
    }
    protected void imgLab_Click(object sender, ImageClickEventArgs e)
    {
        if (txtLabID.Text.Trim().Replace("__-___-________", "").Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('Please enter lab ID');</script>", false);
            return;
        }
        clsBLDispatch ds = new clsBLDispatch();
        ds.LabID = this.txtLabID.Text.Trim();
        ds.Type = this.rdbPatientOption.SelectedItem.Value.ToString();
        ds.BranchID = Session["BranchID"].ToString().Trim();
        ds.Internal = "Y";
        DataView dv = ds.GetAll(7);

        gvResult.DataSource = dv;
        gvResult.DataBind();
        FillGV_External();
    }
    protected void imgPRNo_Click(object sender, ImageClickEventArgs e)
    {
        if (txtPRNO.Text.Trim().Replace("___-__-________", "").Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('Please enter pr number');</script>", false);
            return;
        }
        clsBLDispatch ds = new clsBLDispatch();
        ds.PRNO = this.txtPRNO.Text.Trim();
        ds.Type = this.rdbPatientOption.SelectedItem.Value.ToString();
        ds.BranchID = Session["BranchID"].ToString().Trim();
        ds.Internal="Y";
        DataView dv = ds.GetAll(7);

        gvResult.DataSource = dv;
        gvResult.DataBind();
        FillGV_External();
    }

    private void Status_Fill()
    {
        SComponents com = new SComponents();
        clsBLDispatch ds = new clsBLDispatch();

        DataView dv = ds.GetAll(1);
        chkProcess.DataSource = dv;
        chkProcess.DataTextField = "name";
        chkProcess.DataValueField = "processid";
        chkProcess.DataBind();
        getColour_CheckBox();
    }
    private void Panel_Fill()
    {
        SComponents com = new SComponents();
        clsBLDispatch ds = new clsBLDispatch();
        DataView dv = ds.GetAll(2);
        com.FillDropDownList(ddlPanel, dv, "name", "panelid");
    }

    private void Dept_Fill()
    {
        SComponents com = new SComponents();
        clsBLDispatch ds = new clsBLDispatch();
        DataView dv = ds.GetAll(3);
        com.FillDropDownList(ddlDepartment, dv, "name", "departmentid");
    }
    private void SubDept_Fill()
    {
        SComponents com = new SComponents();
        clsBLDispatch ds = new clsBLDispatch();
        if (ddlDepartment.SelectedIndex > 0)
            ds.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
        DataView dv = ds.GetAll(4);
        com.FillDropDownList(ddlSubdepartment, dv, "name", "subdepartmentid");
    }
    private void Ward_Fill()
    {
        clsBLDispatch ds = new clsBLDispatch();
        SComponents com = new SComponents();
        DataView dv = ds.GetAll(11);
        com.FillDropDownList(ddlWard,dv,"name","wardid");
    }

    private void Group_Fill()
    {
        SComponents com = new SComponents();
        clsBLDispatch ds = new clsBLDispatch();

        DataView dv = ds.GetAll(5);
        com.FillDropDownList(ddlGroup, dv, "name", "groupid");
    }
    private void Test_Fill()
    {
        SComponents com = new SComponents();
        clsBLDispatch ds = new clsBLDispatch();

        if (ddlDepartment.SelectedIndex > 0)
            ds.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
        if (ddlSubdepartment.SelectedIndex > 0)
            ds.SubDepartmentID = this.ddlSubdepartment.SelectedItem.Value.ToString();

        DataView dv = ds.GetAll(6);
        com.FillDropDownList(ddlTest, dv, "test_name", "testid");
        

    }
    private void GV_Fill()
    {
        try
        {
            clsBLDispatch ds = new clsBLDispatch();
            string processID = "";

            if (!txtLabID.Text.Trim().Replace("__-___-________", "").Equals(""))
                ds.LabID = this.txtLabID.Text.Trim();
            if (!txtPRNO.Text.Trim().Replace("___-__-________", "").Equals(""))
                ds.PRNO = this.txtPRNO.Text.Trim();
            if (!txtPatientName.Text.Trim().Equals(""))
                ds.PatientName = this.txtPatientName.Text.Trim();

            if (ddlPanel.SelectedIndex > 0 && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
                ds.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
            if (!txtEmployeeName.Text.Trim().Equals("") && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
                ds.PatientName = this.txtEmployeeName.Text.Trim();
            if (!txtEmployeeNo.Text.Trim().Equals("") && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
                ds.EmployeeNumber = this.txtEmployeeNo.Text.Trim();

            if (ddlDepartment.SelectedIndex > 0)
                ds.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
            if (ddlSubdepartment.SelectedIndex > 0)
                ds.SubDepartmentID = this.ddlSubdepartment.SelectedItem.Value.ToString();

            if (ddlGroup.SelectedIndex > 0)
                ds.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
            if (ddlTest.SelectedIndex > 0)
                ds.TestID = this.ddlTest.SelectedItem.Value.ToString();
            if (!txtPhoneNo.Text.Trim().Equals(""))
                ds.PhoneNo = this.txtPhoneNo.Text.Trim();
            if (!txtCellNo.Text.Trim().Equals(""))
                ds.CellNo = this.txtCellNo.Text.Trim();
            if (!txtRefernce.Text.Trim().Equals(""))
                ds.ReferenceNo = this.txtRefernce.Text.Trim();
            ds.Ind_Out = this.ddlType.SelectedItem.Value.ToString().Replace("A", "~!@");
            if (ddlType.SelectedItem.Value.ToString().Equals("I"))
            {
                ds.WardID = this.ddlWard.SelectedItem.Value.ToString().Replace("-1", "~!@");
                ds.AdmNo = this.txtAdmno.Text.Trim();
            }

            for (int i = 0; i < chkProcess.Items.Count; i++)
            {
                if (chkProcess.Items[i].Selected && processID == "")
                    processID = chkProcess.Items[i].Value.ToString();
                else if (chkProcess.Items[i].Selected && processID != "")
                    processID = processID + "," + chkProcess.Items[i].Value.ToString();
            }
            ds.ProcessID = processID;
            try
            {
                ds.Gender = this.rdbGender.SelectedItem.Value.ToString();
            }
            catch { }
            ds.Type = this.rdbPatientOption.SelectedItem.Value.ToString();

            if (!txtFromDate.Text.Trim().Equals(""))
                ds.FromDate = this.txtFromDate.Text.Trim().Substring(6, 4) + "/" + txtFromDate.Text.Trim().Substring(3, 2) + "/" + txtFromDate.Text.Trim().Substring(0, 2);
            if (!txtToDate.Text.Trim().Equals(""))
                ds.ToDate = this.txtToDate.Text.Trim().Substring(6, 4) + "/" + txtToDate.Text.Trim().Substring(3, 2) + "/" + txtToDate.Text.Trim().Substring(0, 2);

            //ds.BranchID = Session["BranchId"].ToString().Trim();
            //ds.Internal = "Y";
            DataView dv = ds.GetAll(7);
            dv.Sort = DGSort;
            gvResult.DataSource = dv;
            gvResult.DataBind();
            //txtLabID.Focus();
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    private void Clear_Form()
    {
        txtLabID.Text = "";
        txtPRNO.Text = "";
        txtPatientName.Text = "";

        txtAge.Text = "";
        txtCellNo.Text = "";
        txtPhoneNo.Text = "";

        ddlPanel.SelectedIndex = 0;
        txtEmployeeNo.Text = "";
        txtEmployeeName.Text = "";
        txtRefernce.Text = "";
        txtAdmno.Text = "";

        ddlWard.SelectedIndex = -1;
        ddlDepartment.SelectedIndex = 0;
        ddlSubdepartment.SelectedIndex = 0;
        ddlGroup.SelectedIndex = 0;
        ddlTest.SelectedIndex = 0;

        txtFromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    private void getColour_CheckBox()
    {
        for (int i = 0; i < chkProcess.Items.Count; i++)
        {
            if (chkProcess.Items[i].Value.ToString() == "2")
            {
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "IndianRed");
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "white");
            }
            if (chkProcess.Items[i].Value.ToString() == "3")
            {
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "MediumPurple");
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "white");
            }
            if (chkProcess.Items[i].Value.ToString() == "4")
            {
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "CadetBlue");
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "white");
            }
            if (chkProcess.Items[i].Value.ToString() == "5")
            {
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "Thistle");
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Black");
            }
            if (chkProcess.Items[i].Value.ToString() == "6")
            {
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "Violet");
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Black");
            }
            if (chkProcess.Items[i].Value.ToString() == "7")
            {
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "CornflowerBlue");
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "white");
            }
            if (chkProcess.Items[i].Value.ToString() == "8")
            {
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "LightSeaGreen");
                chkProcess.Items[i].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "white");
            }
        }
    }

    protected void rdbPatientOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbPatientOption.Items.FindByValue("C").Selected == true)
        {
            ddlPanel.SelectedIndex = 0;
            txtEmployeeName.Text = "";
            txtEmployeeNo.Text = "";
            pnl_Pnl_info.Visible = false;

            gvResult.DataSource = null;
            gvResult.DataBind();
        }
        else
        {
            pnl_Pnl_info.Visible = true;
            gvResult.DataSource = null;
            gvResult.DataBind();
        }
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        SubDept_Fill();
        Test_Fill();
    }
    protected void ddlSubdepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        Test_Fill();
    }
    
    protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        e.Row.Cells[10].ToolTip = "Click here to see all test result of this patient";
            if (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "8")
            {
                e.Row.BackColor = System.Drawing.Color.LightSeaGreen;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "7")
            {
                e.Row.BackColor = System.Drawing.Color.CornflowerBlue;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "6")
            {
                e.Row.BackColor = System.Drawing.Color.Violet;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            if (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "5")
            {
                e.Row.BackColor = System.Drawing.Color.Thistle;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            if (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "4")
            {
                e.Row.BackColor = System.Drawing.Color.CadetBlue;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "3")
            {
                e.Row.BackColor = System.Drawing.Color.MediumPurple;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "2")
            {
                e.Row.BackColor = System.Drawing.Color.IndianRed;
                e.Row.ForeColor = System.Drawing.Color.White;
            }

            if (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "7" || gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "8" || (gvResult.DataKeys[e.Row.RowIndex].Values[3].ToString() == "6" && gvResult.DataKeys[e.Row.RowIndex].Values[4].ToString() == "Y"))
            {
                if (gvResult.DataKeys[e.Row.RowIndex].Values[6].ToString().Equals("C") && Convert.ToInt32(e.Row.Cells[7].Text.Trim().Replace("-", "0")) > 0)
                {
                    //Img_cprint
                    (e.Row.Cells[14].FindControl("Img_cprint") as Image).Visible = true;
                    (e.Row.Cells[13].FindControl("Img_print") as Image).Visible = false;

                    (e.Row.Cells[14].FindControl("Img_cprintAll") as Image).Visible = true;
                    (e.Row.Cells[13].FindControl("Img_printAll") as Image).Visible = false;

                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                    //return;
                }
                else
                {
                    HyperLink hyperLink_Payment = e.Row.FindControl("Hyper_Pay") as HyperLink;
                    hyperLink_Payment.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem,"subdepartmentId") + "&print=print";
                    hyperLink_Payment.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print";
                    (e.Row.Cells[14].FindControl("Img_cprint") as Image).Visible = false;
                    (e.Row.Cells[13].FindControl("Img_print") as Image).Visible = true;

                    HyperLink hyperLink_PaymentAll = e.Row.FindControl("Hyper_PayAll") as HyperLink;
                    hyperLink_PaymentAll.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=printAll";
                    hyperLink_PaymentAll.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=printAll";
                    (e.Row.Cells[14].FindControl("Img_cprintAll") as Image).Visible = false;
                    (e.Row.Cells[13].FindControl("Img_printAll") as Image).Visible = true;
                }
            }
            else
            {

                (e.Row.Cells[14].FindControl("Img_cprint") as Image).Visible = true;
                (e.Row.Cells[13].FindControl("Img_print") as Image).Visible = false;

                (e.Row.Cells[14].FindControl("Img_cprintAll") as Image).Visible = true;
                (e.Row.Cells[13].FindControl("Img_printAll") as Image).Visible = false;

                //ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Report is not ready yet');</script>", false);
                //return;
            }

         
        }
    }

    protected void lbtnReporting_Click(object sender, EventArgs e)
    {
       // Clear_Form();
        txtFromDate.Text = System.DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
        txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        for (int i = 0; i < chkProcess.Items.Count; i++)
        {
            if (chkProcess.Items[i].Value.ToString() == "7")
                chkProcess.Items[i].Selected = true;
            else
                chkProcess.Items[i].Selected = false;
        }
        GV_Fill();
        FillGV_External();
        getColour_CheckBox();
    }
    protected void chkGVSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.Parent.Parent;
        int idx = row.RowIndex;

        if (gvResult.DataKeys[idx].Values[3].ToString() != "7" && gvResult.DataKeys[idx].Values[3].ToString() != "8" && (gvResult.DataKeys[idx].Values[3].ToString() == "6" && gvResult.DataKeys[idx].Values[4].ToString() == "N"))
        {
            ((CheckBox)(gvResult.Rows[idx].Cells[0].FindControl("chkGVSelect"))).Checked = false;
        }
        else
        {
            if (Convert.ToInt32(gvResult.Rows[idx].Cells[7].Text.Trim().Replace("-", "0")) > 0)
            {
                ((CheckBox)(gvResult.Rows[idx].Cells[0].FindControl("chkGVSelect"))).Checked = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                return;
            }
        }
    }
       
    protected void lbtnWeek_Click(object sender, EventArgs e)
    {
       // Clear_Form();
        txtFromDate.Text = System.DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
        txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
       
        GV_Fill();
        FillGV_External();
        getColour_CheckBox();
    }
    protected void lbtnMonth_Click(object sender, EventArgs e)
    {
       // Clear_Form();
        txtFromDate.Text = System.DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
        txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        
        GV_Fill();
        FillGV_External();
        getColour_CheckBox();
    }
    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        string StrPRID = "";
        string StrBookingID = "";
        string StrTestID = "";
        string StrBooking_DID = "";

        string StrPRID_Prt = "";
        string StrBookingID_Prt = "";
        string StrTestID_Prt = "";
        string StrBooking_DID_Prt = "";

        if (e.CommandName == "Print")
        {
            #region Depricated
            int index = Convert.ToInt32(e.CommandArgument);
            if (gvResult.DataKeys[index].Values[3].ToString() == "7" || gvResult.DataKeys[index].Values[3].ToString() == "8" || (gvResult.DataKeys[index].Values[3].ToString() == "6" && gvResult.DataKeys[index].Values[4].ToString() == "Y"))
            {
                if (gvResult.DataKeys[index].Values[6].ToString().Equals("C") && Convert.ToInt32(gvResult.Rows[index].Cells[7].Text.Trim().Replace("-", "0")) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                    return;
                }
                clsBLDispatch ds = new clsBLDispatch();

                ds.EnteredBy = Session["personid"].ToString();
                ds.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                ds.ClientID = Session["clientid"].ToString().Trim(); //Session["orgid"].ToString();

                string[,] str = new string[1, 6];
                int count = 0;

                str[count, 0] = gvResult.DataKeys[index].Value.ToString();//prid
                str[count, 1] = gvResult.DataKeys[index].Values[1].ToString(); //bookingid
                str[count, 2] = gvResult.DataKeys[index].Values[2].ToString(); // testid
                str[count, 3] = gvResult.Rows[index].Cells[2].Text.Trim(); //labid
                str[count, 4] = gvResult.DataKeys[index].Values[3].ToString(); //processid
                str[count, 5] = gvResult.DataKeys[index].Values[5].ToString(); //bookingDID

                StrPRID = gvResult.DataKeys[index].Value.ToString();
                StrBookingID = gvResult.DataKeys[index].Values[1].ToString();
                StrTestID = gvResult.DataKeys[index].Values[2].ToString();
                StrBooking_DID = gvResult.DataKeys[index].Values[5].ToString(); //bookingDID

                clsBLDispatch objDis = new clsBLDispatch();
                DataView dv = new DataView();
                objDis.PRID = gvResult.DataKeys[index].Value.ToString();//prid
                objDis.TestID = gvResult.DataKeys[index].Values[2].ToString(); // testid
                objDis.BookingID = gvResult.DataKeys[index].Values[1].ToString(); //bookingid
                objDis.BookingDID = gvResult.DataKeys[index].Values[5].ToString(); //BookingDid


                if (ds.Dispatch(str))
                {


                    dv = objDis.GetAll(9);
                    Session["testtable"] = dv.Table;

                    dv = objDis.GetAll(10);
                    Session["testsubtable"] = dv.Table;
                    Session.Add("SubRptName", "one_column_1");

                    string sSelectionFormula = "";
                    sSelectionFormula = "{general_result_main.prid} in [" + StrPRID + "] and {general_result_main.testid} in [" + StrTestID + "] and {general_result_main.bookingid} in [" + StrBookingID + "] and {general_result_main.bookingdid} in [" + StrBooking_DID + "]";


                    Session["reportname"] = "result";
                    Session["selectionformula"] = "";
                    Session["selectionformula"] = sSelectionFormula;

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);

                    GV_Fill();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('" + ds.Error + "')</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('No preview available');</script>", false);
            }
        }
            #endregion
        if (e.CommandName == "Print All")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StrPRID = gvResult.DataKeys[index].Value.ToString();
            StrBookingID = gvResult.DataKeys[index].Values[1].ToString();
            int count = 0;
            for (int i = 0; i < gvResult.Rows.Count; i++)
            {
                if (StrPRID == gvResult.DataKeys[i].Value.ToString() && StrBookingID == gvResult.DataKeys[i].Values[1].ToString() && (gvResult.DataKeys[i].Values[3].ToString() == "7" || gvResult.DataKeys[i].Values[3].ToString() == "8" || (gvResult.DataKeys[i].Values[3].ToString() == "6" && gvResult.DataKeys[i].Values[4].ToString() == "Y")))
                {
                    if (gvResult.DataKeys[index].Values[6].ToString().Equals("C") &&  Convert.ToInt32(gvResult.Rows[i].Cells[7].Text.Trim().Replace("-", "0")) > 0)
                    {  
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                        return;
                    }
                    else
                        count++;
                }
            }

            if (count == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('No Preview Available')</script>", false);
                return;
            }

            clsBLDispatch ds = new clsBLDispatch();

            ds.EnteredBy = Session["personid"].ToString();
            ds.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            ds.ClientID = Session["clientid"].ToString().Trim(); //Session["orgid"].ToString();

            string[,] str = new string[count, 6];
             count = 0;

             for (int i = 0; i < gvResult.Rows.Count; i++)
             {
                 if (StrPRID == gvResult.DataKeys[i].Value.ToString() && StrBookingID == gvResult.DataKeys[i].Values[1].ToString() && (gvResult.DataKeys[i].Values[3].ToString() == "7" || gvResult.DataKeys[i].Values[3].ToString() == "8" || (gvResult.DataKeys[i].Values[3].ToString() == "6" && gvResult.DataKeys[i].Values[4].ToString() == "Y")))
                 {
                     str[count, 0] = gvResult.DataKeys[i].Value.ToString();//prid
                     str[count, 1] = gvResult.DataKeys[i].Values[1].ToString(); //bookingid
                     str[count, 2] = gvResult.DataKeys[i].Values[2].ToString(); // testid
                     str[count, 3] = gvResult.Rows[i].Cells[2].Text.Trim(); //labid
                     str[count, 4] = gvResult.DataKeys[i].Values[3].ToString(); //processID
                     str[count, 5] = gvResult.DataKeys[i].Values[5].ToString(); //bookingDID


                     if (count == 0)
                     {
                         StrPRID_Prt = gvResult.DataKeys[i].Value.ToString();
                         StrBookingID_Prt = gvResult.DataKeys[i].Values[1].ToString();
                         StrTestID_Prt = gvResult.DataKeys[i].Values[2].ToString();
                         StrBooking_DID_Prt = gvResult.DataKeys[i].Values[5].ToString(); //bookingDID
                     }
                     else
                     {
                         StrPRID_Prt = StrPRID_Prt + "," + gvResult.DataKeys[i].Value.ToString();
                         StrBookingID_Prt = StrBookingID_Prt + "," + gvResult.DataKeys[i].Values[1].ToString();
                         StrTestID_Prt = StrTestID_Prt + "," + gvResult.DataKeys[i].Values[2].ToString();
                         StrBooking_DID_Prt = StrBooking_DID_Prt + "," + gvResult.DataKeys[i].Values[5].ToString();//bookingDID
                     }
                     count++;
                 }
             }

            if (ds.Dispatch(str))
            {
                DataView dv = new DataView();

                ds.PRID = StrPRID_Prt;//prid
                ds.TestID = StrTestID_Prt; // testid
                ds.BookingID = StrBookingID_Prt; //bookingid

                dv = ds.GetAll(9);
                Session["testtable"] = dv.Table;

                dv = ds.GetAll(10);
                Session["testsubtable"] = dv.Table;
                Session.Add("SubRptName", "one_column_1");

                string sSelectionFormula = "";
                sSelectionFormula = "{general_result_main.prid} in [" + StrPRID_Prt + "] and {general_result_main.testid} in [" + StrTestID_Prt + "] and {general_result_main.bookingid} in [" + StrBookingID_Prt + "] and {general_result_main.bookingdid} in [" + StrBooking_DID_Prt + "]";

                Session["reportname"] = "result";
                Session["selectionformula"] = "";
                Session["selectionformula"] = sSelectionFormula;

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
                GV_Fill();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('" + ds.Error + "')</script>", false);
            }


        }
        if (e.CommandName.Equals("Select"))
        {

            int index = Convert.ToInt32(e.CommandArgument);
            lblTest_intCmt.Text = "Investigation: " + gvResult.Rows[index].Cells[5].Text.Trim();
            lblInt_Index.Text = index.ToString();
            lblInt_BookingID.Text = gvResult.DataKeys[index].Values[1].ToString();
            lblInt_testID.Text = gvResult.DataKeys[index].Values[2].ToString();

            txtInt_Comnt.Text = "";


            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
            SComponents com = new SComponents();
            iv.TestID = gvResult.DataKeys[index].Values[2].ToString();
            iv.BookingID = gvResult.DataKeys[index].Values[1].ToString();
            iv.For_Process = "7";
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
    protected void lbtnThreeDay_Click(object sender, EventArgs e)
    {
        //Clear_Form();
        txtFromDate.Text = System.DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
        txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        GV_Fill();
        FillGV_External();
        getColour_CheckBox();
    }
    protected void gvResult_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("labid"))
        {
            if (DGSort.Equals("labid asc"))
                DGSort = "labid desc";
            else
                DGSort = "labid asc";
        }
        else if (e.SortExpression.Equals("patientname"))
        {
            if (DGSort.Equals("patientname asc"))
                DGSort = "patientname desc";
            else
                DGSort = "patientname asc";
        }
        else if (e.SortExpression.Equals("test_name"))
        {
            if (DGSort.Equals("test_name asc"))
                DGSort = "test_name desc";
            else
                DGSort = "test_name asc";
        }

        else if (e.SortExpression.Equals("balance"))
        {
            if (DGSort.Equals("balance asc"))
                DGSort = "balance desc";
            else
                DGSort = "balance asc";
        }
        else if (e.SortExpression.Equals("bookedon"))
        {
            if (DGSort.Equals("bookedon asc"))
                DGSort = "bookedon desc";
            else
                DGSort = "bookedon asc";
        }
        else if (e.SortExpression.Equals("deliveryon"))
        {
            if (DGSort.Equals("deliveryon asc"))
                DGSort = "deliveryon desc";
            else
                DGSort = "deliveryon asc";
        }
        else if (e.SortExpression.Equals("dispatchon"))
        {
            if (DGSort.Equals("dispatchon asc"))
                DGSort = "dispatchon desc";
            else
                DGSort = "dispatchon asc";
        }
        else if (e.SortExpression.Equals("referenceno"))
        {
            if (DGSort.Equals("referenceno asc"))
                DGSort = "referenceno desc";
            else
                DGSort = "referenceno asc";
        }
        else if (e.SortExpression.Equals("ind_out"))
        {
            if (DGSort == "ind_out asc")
                DGSort = "ind_out desc";
            else
                DGSort = "ind_out asc";
        }
        GV_Fill();
    }
    protected void imgcmt_save_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.remove_load(blinkGridViewRows);", true);

        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

        iv.TestID = lblInt_testID.Text.Trim();
        iv.BookingID = this.lblInt_BookingID.Text.Trim();
        iv.Int_Comment = txtInt_Comnt.Text.Trim();
        iv.For_Process = ddlFor_Process.SelectedItem.Value.ToString().Replace("-1", "null");

        iv.ProcessID = "7";
        iv.EnteredBy = Session["personid"].ToString();
        iv.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        iv.ClientID = Session["clientid"].ToString().Trim(); //Session["orgid"].ToString();

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

    #region External Grid Functions

    ///////////////////////External Grid Functions//////////////////////
    private void FillGV_External()
    {
        clsBLDispatch ds = new clsBLDispatch();
        string processID = "";

        if (!txtLabID.Text.Trim().Replace("__-___-________", "").Equals(""))
            ds.LabID = this.txtLabID.Text.Trim();
        if (!txtPRNO.Text.Trim().Replace("___-__-________", "").Equals(""))
            ds.PRNO = this.txtPRNO.Text.Trim();
        if (!txtPatientName.Text.Trim().Equals(""))
            ds.PatientName = this.txtPatientName.Text.Trim();

        if (ddlPanel.SelectedIndex > 0 && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
            ds.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        if (!txtEmployeeName.Text.Trim().Equals("") && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
            ds.PatientName = this.txtEmployeeName.Text.Trim();
        if (!txtEmployeeNo.Text.Trim().Equals("") && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
            ds.EmployeeNumber = this.txtEmployeeNo.Text.Trim();

        if (ddlDepartment.SelectedIndex > 0)
            ds.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
        if (ddlSubdepartment.SelectedIndex > 0)
            ds.SubDepartmentID = this.ddlSubdepartment.SelectedItem.Value.ToString();

        if (ddlGroup.SelectedIndex > 0)
            ds.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
        if (ddlTest.SelectedIndex > 0)
            ds.TestID = this.ddlTest.SelectedItem.Value.ToString();
        if (!txtPhoneNo.Text.Trim().Equals(""))
            ds.PhoneNo = this.txtPhoneNo.Text.Trim();
        if (!txtCellNo.Text.Trim().Equals(""))
            ds.CellNo = this.txtCellNo.Text.Trim();
        if (!txtRefernce.Text.Trim().Equals(""))
            ds.ReferenceNo = this.txtRefernce.Text.Trim();
        ds.Ind_Out = this.ddlType.SelectedItem.Value.ToString().Replace("A", "~!@");
        if (ddlType.SelectedItem.Value.ToString().Equals("I"))
        {
            ds.WardID = this.ddlWard.SelectedItem.Value.ToString().Replace("-1", "~!@");
            ds.AdmNo = this.txtAdmno.Text.Trim();
        }

        for (int i = 0; i < chkProcess.Items.Count; i++)
        {
            if (chkProcess.Items[i].Selected && processID == "")
                processID = chkProcess.Items[i].Value.ToString();
            else if (chkProcess.Items[i].Selected && processID != "")
                processID = processID + "," + chkProcess.Items[i].Value.ToString();
        }
        ds.ProcessID = processID;
        try
        {
            ds.Gender = this.rdbGender.SelectedItem.Value.ToString();
        }
        catch { }
        ds.Type = this.rdbPatientOption.SelectedItem.Value.ToString();

        if (!txtFromDate.Text.Trim().Equals(""))
            ds.FromDate = this.txtFromDate.Text.Trim().Substring(6, 4) + "/" + txtFromDate.Text.Trim().Substring(3, 2) + "/" + txtFromDate.Text.Trim().Substring(0, 2);
        if (!txtToDate.Text.Trim().Equals(""))
            ds.ToDate = this.txtToDate.Text.Trim().Substring(6, 4) + "/" + txtToDate.Text.Trim().Substring(3, 2) + "/" + txtToDate.Text.Trim().Substring(0, 2);

        ds.BranchID = Session["BranchId"].ToString().Trim();
        ds.Internal = "N";
        DataView dv = ds.GetAll(7);
        dv.Sort = DGSort;
        gvExternal.DataSource = dv;
        gvExternal.DataBind();
        txtLabID.Focus();
    }

    protected void gvExternal_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("labid"))
        {
            if (DGSort.Equals("labid asc"))
                DGSort = "labid desc";
            else
                DGSort = "labid asc";
        }
        else if (e.SortExpression.Equals("patientname"))
        {
            if (DGSort.Equals("patientname asc"))
                DGSort = "patientname desc";
            else
                DGSort = "patientname asc";
        }
        else if (e.SortExpression.Equals("test_name"))
        {
            if (DGSort.Equals("test_name asc"))
                DGSort = "test_name desc";
            else
                DGSort = "test_name asc";
        }

        else if (e.SortExpression.Equals("balance"))
        {
            if (DGSort.Equals("balance asc"))
                DGSort = "balance desc";
            else
                DGSort = "balance asc";
        }
        else if (e.SortExpression.Equals("bookedon"))
        {
            if (DGSort.Equals("bookedon asc"))
                DGSort = "bookedon desc";
            else
                DGSort = "bookedon asc";
        }
        else if (e.SortExpression.Equals("deliveryon"))
        {
            if (DGSort.Equals("deliveryon asc"))
                DGSort = "deliveryon desc";
            else
                DGSort = "deliveryon asc";
        }
        else if (e.SortExpression.Equals("dispatchon"))
        {
            if (DGSort.Equals("dispatchon asc"))
                DGSort = "dispatchon desc";
            else
                DGSort = "dispatchon asc";
        }
        else if (e.SortExpression.Equals("referenceno"))
        {
            if (DGSort.Equals("referenceno asc"))
                DGSort = "referenceno desc";
            else
                DGSort = "referenceno asc";
        }
        else if (e.SortExpression.Equals("ind_out"))
        {
            if (DGSort == "ind_out asc")
                DGSort = "ind_out desc";
            else
                DGSort = "ind_out asc";
        }
        FillGV_External();
    }

    protected void gvExternal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string StrPRID = "";
        string StrBookingID = "";
        string StrTestID = "";
        string StrBooking_DID = "";

        string StrPRID_Prt = "";
        string StrBookingID_Prt = "";
        string StrTestID_Prt = "";
        string StrBooking_DID_Prt = "";

        if (e.CommandName == "Print")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (gvExternal.DataKeys[index].Values[3].ToString() == "7" || gvExternal.DataKeys[index].Values[3].ToString() == "8" || (gvExternal.DataKeys[index].Values[3].ToString() == "6" && gvExternal.DataKeys[index].Values[4].ToString() == "Y"))
            {
                if (gvExternal.DataKeys[index].Values[6].ToString().Equals("C") && Convert.ToInt32(gvExternal.Rows[index].Cells[7].Text.Trim().Replace("-", "0")) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                    return;
                }
                clsBLDispatch ds = new clsBLDispatch();

                ds.EnteredBy = Session["personid"].ToString();
                ds.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                ds.ClientID = Session["clientid"].ToString().Trim(); //Session["orgid"].ToString();

                string[,] str = new string[1, 6];
                int count = 0;

                str[count, 0] = gvExternal.DataKeys[index].Value.ToString();//prid
                str[count, 1] = gvExternal.DataKeys[index].Values[1].ToString(); //bookingid
                str[count, 2] = gvExternal.DataKeys[index].Values[2].ToString(); // testid
                str[count, 3] = gvExternal.Rows[index].Cells[2].Text.Trim(); //labid
                str[count, 4] = gvExternal.DataKeys[index].Values[3].ToString(); //processid
                str[count, 5] = gvExternal.DataKeys[index].Values[5].ToString(); //bookingDID

                StrPRID = gvExternal.DataKeys[index].Value.ToString();
                StrBookingID = gvExternal.DataKeys[index].Values[1].ToString();
                StrTestID = gvExternal.DataKeys[index].Values[2].ToString();
                StrBooking_DID = gvExternal.DataKeys[index].Values[5].ToString(); //bookingDID

                clsBLDispatch objDis = new clsBLDispatch();
                DataView dv = new DataView();
                objDis.PRID = gvExternal.DataKeys[index].Value.ToString();//prid
                objDis.TestID = gvExternal.DataKeys[index].Values[2].ToString(); // testid
                objDis.BookingID = gvExternal.DataKeys[index].Values[1].ToString(); //bookingid
                objDis.BookingDID = gvExternal.DataKeys[index].Values[5].ToString(); //BookingDid


                if (ds.Dispatch(str))
                {


                    dv = objDis.GetAll(9);
                    Session["testtable"] = dv.Table;

                    dv = objDis.GetAll(10);
                    Session["testsubtable"] = dv.Table;
                    Session.Add("SubRptName", "one_column_1");

                    string sSelectionFormula = "";
                    sSelectionFormula = "{general_result_main.prid} in [" + StrPRID + "] and {general_result_main.testid} in [" + StrTestID + "] and {general_result_main.bookingid} in [" + StrBookingID + "] and {general_result_main.bookingdid} in [" + StrBooking_DID + "]";


                    Session["reportname"] = "result";
                    Session["selectionformula"] = "";
                    Session["selectionformula"] = sSelectionFormula;

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);

                    GV_Fill();
                    FillGV_External();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('" + ds.Error + "')</script>", false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('No preview available');</script>", false);
            }
        }
        if (e.CommandName == "Print All")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StrPRID = gvExternal.DataKeys[index].Value.ToString();
            StrBookingID = gvExternal.DataKeys[index].Values[1].ToString();
            int count = 0;
            for (int i = 0; i < gvResult.Rows.Count; i++)
            {
                if (StrPRID == gvExternal.DataKeys[i].Value.ToString() && StrBookingID == gvExternal.DataKeys[i].Values[1].ToString() && (gvExternal.DataKeys[i].Values[3].ToString() == "7" || gvExternal.DataKeys[i].Values[3].ToString() == "8" || (gvExternal.DataKeys[i].Values[3].ToString() == "6" && gvExternal.DataKeys[i].Values[4].ToString() == "Y")))
                {
                    if (gvExternal.DataKeys[index].Values[6].ToString().Equals("C") && Convert.ToInt32(gvExternal.Rows[i].Cells[7].Text.Trim().Replace("-", "0")) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                        return;
                    }
                    else
                        count++;
                }
            }

            if (count == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('No Preview Available')</script>", false);
                return;
            }

            clsBLDispatch ds = new clsBLDispatch();

            ds.EnteredBy = Session["personid"].ToString();
            ds.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            ds.ClientID = Session["orgid"].ToString();

            string[,] str = new string[count, 6];
            count = 0;

            for (int i = 0; i < gvExternal.Rows.Count; i++)
            {
                if (StrPRID == gvExternal.DataKeys[i].Value.ToString() && StrBookingID == gvExternal.DataKeys[i].Values[1].ToString() && (gvExternal.DataKeys[i].Values[3].ToString() == "7" || gvExternal.DataKeys[i].Values[3].ToString() == "8" || (gvExternal.DataKeys[i].Values[3].ToString() == "6" && gvExternal.DataKeys[i].Values[4].ToString() == "Y")))
                {
                    str[count, 0] = gvExternal.DataKeys[i].Value.ToString();//prid
                    str[count, 1] = gvExternal.DataKeys[i].Values[1].ToString(); //bookingid
                    str[count, 2] = gvExternal.DataKeys[i].Values[2].ToString(); // testid
                    str[count, 3] = gvExternal.Rows[i].Cells[2].Text.Trim(); //labid
                    str[count, 4] = gvExternal.DataKeys[i].Values[3].ToString(); //processID
                    str[count, 5] = gvExternal.DataKeys[i].Values[5].ToString(); //bookingDID


                    if (count == 0)
                    {
                        StrPRID_Prt = gvExternal.DataKeys[i].Value.ToString();
                        StrBookingID_Prt = gvExternal.DataKeys[i].Values[1].ToString();
                        StrTestID_Prt = gvExternal.DataKeys[i].Values[2].ToString();
                        StrBooking_DID_Prt = gvExternal.DataKeys[i].Values[5].ToString(); //bookingDID
                    }
                    else
                    {
                        StrPRID_Prt = StrPRID_Prt + "," + gvExternal.DataKeys[i].Value.ToString();
                        StrBookingID_Prt = StrBookingID_Prt + "," + gvExternal.DataKeys[i].Values[1].ToString();
                        StrTestID_Prt = StrTestID_Prt + "," + gvExternal.DataKeys[i].Values[2].ToString();
                        StrBooking_DID_Prt = StrBooking_DID_Prt + "," + gvExternal.DataKeys[i].Values[5].ToString();//bookingDID
                    }
                    count++;
                }
            }

            if (ds.Dispatch(str))
            {
                DataView dv = new DataView();

                ds.PRID = StrPRID_Prt;//prid
                ds.TestID = StrTestID_Prt; // testid
                ds.BookingID = StrBookingID_Prt; //bookingid

                dv = ds.GetAll(9);
                Session["testtable"] = dv.Table;

                dv = ds.GetAll(10);
                Session["testsubtable"] = dv.Table;
                Session.Add("SubRptName", "one_column_1");

                string sSelectionFormula = "";
                sSelectionFormula = "{general_result_main.prid} in [" + StrPRID_Prt + "] and {general_result_main.testid} in [" + StrTestID_Prt + "] and {general_result_main.bookingid} in [" + StrBookingID_Prt + "] and {general_result_main.bookingdid} in [" + StrBooking_DID_Prt + "]";

                Session["reportname"] = "result";
                Session["selectionformula"] = "";
                Session["selectionformula"] = sSelectionFormula;

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
                GV_Fill();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('" + ds.Error + "')</script>", false);
            }


        }
        if (e.CommandName.Equals("Select"))
        {

            int index = Convert.ToInt32(e.CommandArgument);
            lblTest_intCmt.Text = "Investigation: " + gvExternal.Rows[index].Cells[5].Text.Trim();
            lblInt_Index.Text = index.ToString();
            lblInt_BookingID.Text = gvExternal.DataKeys[index].Values[1].ToString();
            lblInt_testID.Text = gvExternal.DataKeys[index].Values[2].ToString();

            txtInt_Comnt.Text = "";


            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
            SComponents com = new SComponents();
            iv.TestID = gvExternal.DataKeys[index].Values[2].ToString();
            iv.BookingID = gvExternal.DataKeys[index].Values[1].ToString();
            iv.For_Process = "7";
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

    protected void gvExternal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Cells[10].ToolTip = "Click here to see all test result of this patient";
            if (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "8")
            {
                e.Row.BackColor = System.Drawing.Color.LightSeaGreen;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "7")
            {
                e.Row.BackColor = System.Drawing.Color.CornflowerBlue;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "6")
            {
                e.Row.BackColor = System.Drawing.Color.Violet;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            if (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "5")
            {
                e.Row.BackColor = System.Drawing.Color.Thistle;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            if (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "4")
            {
                e.Row.BackColor = System.Drawing.Color.CadetBlue;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "3")
            {
                e.Row.BackColor = System.Drawing.Color.MediumPurple;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "2")
            {
                e.Row.BackColor = System.Drawing.Color.IndianRed;
                e.Row.ForeColor = System.Drawing.Color.White;
            }

            if (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "7" || gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "8" || (gvExternal.DataKeys[e.Row.RowIndex].Values[3].ToString() == "6" && gvExternal.DataKeys[e.Row.RowIndex].Values[4].ToString() == "Y"))
            {
                if (gvExternal.DataKeys[e.Row.RowIndex].Values[6].ToString().Equals("C") && Convert.ToInt32(e.Row.Cells[7].Text.Trim().Replace("-", "0")) > 0)
                {
                    //Img_cprint2
                    (e.Row.Cells[14].FindControl("Img_cprint2") as Image).Visible = true;
                    (e.Row.Cells[13].FindControl("Img_print2") as Image).Visible = false;

                    (e.Row.Cells[14].FindControl("Img_printAll2") as Image).Visible = false;
                    (e.Row.Cells[13].FindControl("Img_cprintAll2") as Image).Visible = true;
                }
                else
                {
                    HyperLink hyperLink_Print = e.Row.FindControl("Hyper_Pay2") as HyperLink;
                    hyperLink_Print.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print";
                    hyperLink_Print.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print";
 
                    (e.Row.Cells[14].FindControl("Img_cprint2") as Image).Visible = false;
                    (e.Row.Cells[13].FindControl("Img_print2") as Image).Visible = true;

                    HyperLink hyperLink_Print2 = e.Row.FindControl("Hyper_PayAll2") as HyperLink;
                    hyperLink_Print2.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=printAll";
                    hyperLink_Print2.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=printAll";

                    (e.Row.Cells[14].FindControl("Img_printAll2") as Image).Visible = true;
                    (e.Row.Cells[13].FindControl("Img_cprintAll2") as Image).Visible = false;

                    /////////////////////////////////////////////////////Amman
                }
            }
            else
            {

                (e.Row.Cells[14].FindControl("Img_cprint2") as Image).Visible = true;
                (e.Row.Cells[13].FindControl("Img_print2") as Image).Visible = false;

                (e.Row.Cells[14].FindControl("Img_printAll2") as Image).Visible = false;
                (e.Row.Cells[13].FindControl("Img_cprintAll2") as Image).Visible = true;
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Report is not ready yet');</script>", false);
                //return;
            }
        }
    }

    protected void chkGVExSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.Parent.Parent;
        int idx = row.RowIndex;

        if (gvExternal.DataKeys[idx].Values[3].ToString() != "7" && gvExternal.DataKeys[idx].Values[3].ToString() != "8" && (gvExternal.DataKeys[idx].Values[3].ToString() == "6" && gvExternal.DataKeys[idx].Values[4].ToString() == "N"))
        {
            ((CheckBox)(gvExternal.Rows[idx].Cells[0].FindControl("chkGVExSelect"))).Checked = false;
        }
        else
        {
            if (Convert.ToInt32(gvExternal.Rows[idx].Cells[7].Text.Trim().Replace("-", "0")) > 0)
            {
                ((CheckBox)(gvExternal.Rows[idx].Cells[0].FindControl("chkGVExSelect"))).Checked = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                return;
            }
        }
    }

    #endregion
}
