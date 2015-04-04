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

public partial class track : System.Web.UI.Page
{
    private static string DGSort = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                Status_Fill();
                Panel_Fill();
                Dept_Fill();

                SubDept_Fill();
                Group_Fill();
                Test_Fill();

                rdbPatientOption.Items.FindByValue("C").Selected = true;
                pnl_Pnl_info.Visible = false;

                txtFromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                GV_Fill();

            }
        }
        else
        {
            Response.Redirect("../Parameter/MainPage.aspx");
        }
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.close();</script>", false);
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

        for (int i = 0; i < gvResult.Rows.Count; i++)
        {
            if (((CheckBox)(gvResult.Rows[i].Cells[0].FindControl("chkGVSelect"))).Checked)
            {
                if (Convert.ToInt32(gvResult.Rows[i].Cells[6].Text.Trim().Replace("-", "0")) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                    return;
                }
                if (count == 0)
                {
                    StrPRID = gvResult.DataKeys[i].Value.ToString();
                    StrBookingID = gvResult.DataKeys[i].Values[1].ToString();
                }
                if (count > 0 && StrPRID != gvResult.DataKeys[i].Value.ToString() && StrBookingID != gvResult.DataKeys[i].Values[1].ToString())
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
            ds.ClientID = Session["orgid"].ToString();

            string[,] str = new string[count, 5];
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

                    if (count == 0)
                    {
                        StrPRID = gvResult.DataKeys[i].Value.ToString();
                        StrBookingID = gvResult.DataKeys[i].Values[1].ToString();
                        StrTestID = gvResult.DataKeys[i].Values[2].ToString();
                    }
                    else
                    {
                        StrPRID = StrPRID + "," + gvResult.DataKeys[i].Value.ToString();
                        StrBookingID = StrBookingID + "," + gvResult.DataKeys[i].Values[1].ToString();
                        StrTestID = StrTestID + "," + gvResult.DataKeys[i].Values[2].ToString();
                    }

                    count++;
                }
            }
            if (ds.Dispatch(str))
            {
                string sSelectionFormula = "";
                sSelectionFormula = "{general_result_main.prid} in [" + StrPRID + "] and {general_result_main.testid} in [" + StrTestID + "] and {general_result_main.bookingid} in [" + StrBookingID + "]";


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
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        GV_Fill();
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
        DataView dv = ds.GetAll(7);

        gvResult.DataSource = dv;
        gvResult.DataBind();
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
        DataView dv = ds.GetAll(7);

        gvResult.DataSource = dv;
        gvResult.DataBind();
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

        DataView dv = ds.GetAll(7);
        dv.Sort = DGSort;
        gvResult.DataSource = dv;
        gvResult.DataBind();
        txtLabID.Focus();
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
            if (Convert.ToInt32(gvResult.Rows[idx].Cells[5].Text.Trim().Replace("-", "0")) > 0)
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
        getColour_CheckBox();
    }
    protected void lbtnMonth_Click(object sender, EventArgs e)
    {
        // Clear_Form();
        txtFromDate.Text = System.DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
        txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        GV_Fill();
        getColour_CheckBox();
    }
    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string StrPRID = "";
        string StrBookingID = "";
        string StrTestID = "";

        string StrPRID_Prt = "";
        string StrBookingID_Prt = "";
        string StrTestID_Prt = "";

        if (e.CommandName == "Print")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (gvResult.DataKeys[index].Values[3].ToString() == "7" || gvResult.DataKeys[index].Values[3].ToString() == "8" || (gvResult.DataKeys[index].Values[3].ToString() == "6" && gvResult.DataKeys[index].Values[4].ToString() == "Y"))
            {
                if (Convert.ToInt32(gvResult.Rows[index].Cells[6].Text.Trim().Replace("-", "0")) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                    return;
                }
                clsBLDispatch ds = new clsBLDispatch();

                ds.EnteredBy = Session["personid"].ToString();
                ds.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                ds.ClientID = Session["orgid"].ToString();

                string[,] str = new string[1, 5];
                int count = 0;

                str[count, 0] = gvResult.DataKeys[index].Value.ToString();//prid
                str[count, 1] = gvResult.DataKeys[index].Values[1].ToString(); //bookingid
                str[count, 2] = gvResult.DataKeys[index].Values[2].ToString(); // testid
                str[count, 3] = gvResult.Rows[index].Cells[2].Text.Trim(); //labid
                str[count, 4] = gvResult.DataKeys[index].Values[3].ToString(); //processid

                StrPRID = gvResult.DataKeys[index].Value.ToString();
                StrBookingID = gvResult.DataKeys[index].Values[1].ToString();
                StrTestID = gvResult.DataKeys[index].Values[2].ToString();



                if (ds.Dispatch(str))
                {
                    string sSelectionFormula = "";
                    sSelectionFormula = "{general_result_main.prid} in [" + StrPRID + "] and {general_result_main.testid} in [" + StrTestID + "] and {general_result_main.bookingid} in [" + StrBookingID + "]";

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
                    if (Convert.ToInt32(gvResult.Rows[i].Cells[6].Text.Trim().Replace("-", "0")) > 0)
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

            string[,] str = new string[count, 5];
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

                    if (count == 0)
                    {
                        StrPRID_Prt = gvResult.DataKeys[i].Value.ToString();
                        StrBookingID_Prt = gvResult.DataKeys[i].Values[1].ToString();
                        StrTestID_Prt = gvResult.DataKeys[i].Values[2].ToString();
                    }
                    else
                    {
                        StrPRID_Prt = StrPRID_Prt + "," + gvResult.DataKeys[i].Value.ToString();
                        StrBookingID_Prt = StrBookingID_Prt + "," + gvResult.DataKeys[i].Values[1].ToString();
                        StrTestID_Prt = StrTestID_Prt + "," + gvResult.DataKeys[i].Values[2].ToString();
                    }
                    count++;
                }
            }

            if (ds.Dispatch(str))
            {
                string sSelectionFormula = "";
                sSelectionFormula = "{general_result_main.prid} in [" + StrPRID_Prt + "] and {general_result_main.testid} in [" + StrTestID_Prt + "] and {general_result_main.bookingid} in [" + StrBookingID_Prt + "]";

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
    }
    protected void lbtnThreeDay_Click(object sender, EventArgs e)
    {
        //Clear_Form();
        txtFromDate.Text = System.DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
        txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        GV_Fill();
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
        GV_Fill();
    }
}
