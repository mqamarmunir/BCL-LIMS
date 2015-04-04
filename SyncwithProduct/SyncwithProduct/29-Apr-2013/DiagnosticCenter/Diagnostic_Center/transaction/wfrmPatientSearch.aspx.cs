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
using System.Text;

public partial class transaction_wfrmPatientSearch : System.Web.UI.Page
{
    private static string DGSort = "";
    private static string DGSort1 = "";
    clsDayCashCollection dayCash = new clsDayCashCollection();
    private static string processidglobal = "All";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                dayCash.Type = "O";
                //filldg(processidglobal);
                FilldllBranch();
                FillPanel_DDL();

                Dept_Fill();
                Group_Fill();
                Test_Fill();
                SubDept_Fill();
                tbfromdate.Text = System.DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
                tbtodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtItemName.Focus();
                
            }
        }
        else
        {
            Response.Redirect("../NewLogin.aspx");
        }
    }
    public void filldg(string processid)
     {
        dayCash.ToDate1 = System.DateTime.Now.ToString("yyyy/MM/dd");
        dayCash.FromDate1 = System.DateTime.Now.ToString("yyyy/MM/dd");
        if (!processid.ToLower().Equals("all"))
        {
            dayCash.ProcessID = processid;
        }
        DataView dv = dayCash.GetAll(25);

        dv.Sort = DGSort1;
        if (dv.Count > 0)
        {
            gvPatients.Visible = false;
            Gvonload.Visible = true;
            Gvonload.DataSource = dv;
            Gvonload.DataBind();
            gridRepeat1();
        }
        else
        {
            Gvonload.DataSource = "";
            Gvonload.AllowPaging = false;
            Gvonload.DataBind();
        }

    }
    private void FillPanel_DDL()
    {
        clsDayCashCollection dayCash = new clsDayCashCollection();
        SComponents com = new SComponents();

        DataView dv = dayCash.GetAll(18);
        com.FillDropDownList(ddlPanel, dv, "name", "panelid");
    }
    private void FilldllBranch()
    {
        SComponents com = new SComponents();

        clsBLBranch objbranch = new clsBLBranch();
        DataView dv_branch = objbranch.GetAll(3);
        com.FillDropDownList(ddlBranch, dv_branch, "Name", "BranchID");
    }

    public void gridRepeat()
    {

        for (int j = 0; j < gvPatients.Rows.Count; j++)
        {
            string Panelname = gvPatients.DataKeys[j].Values["Panel"].ToString();
            if (Panelname == "" || Panelname == null)
            {


                (gvPatients.Rows[j].Cells[3].FindControl("lbl_action") as Label).ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                (gvPatients.Rows[j].Cells[3].FindControl("lbl_action") as Label).ForeColor = System.Drawing.Color.Blue;
            }
            //if (!gvPatients.DataKeys[j].Values["panelid"].ToString().Equals("0") && !gvPatients.DataKeys[j].Values["cashpanel"].ToString().Equals("N"))
            //{
            //    (gvPatients.Rows[j].FindControl("Hyp_Balance") as HyperLink).Visible = false;
            //}
            //else
            //{
            //    (gvPatients.Rows[j].FindControl("Hyp_Balance") as HyperLink).Visible = true;
            //}
        }
        string initialnamevalue = (gvPatients.Rows[0].FindControl("lbl_labid") as Label).Text;
        for (int i = 1; i < gvPatients.Rows.Count; i++)
        {
            if ((gvPatients.Rows[i].FindControl("lbl_labid") as Label).Text == initialnamevalue)
            {
                (gvPatients.Rows[i].FindControl("lbl_labid") as Label).Text = string.Empty;
                (gvPatients.Rows[i].FindControl("lbl_labid") as Label).Text = "-";

                gvPatients.Rows[i].Cells[0].Text = "-";

                gvPatients.Rows[i].Cells[1].Text = "-";
                //gvPatients.Rows[i].Cells[2].Text = "-";
                (gvPatients.Rows[i].Cells[2].FindControl("Img_printReceipt") as Image).Visible = false;
                gvPatients.Rows[i].Cells[3].Text = "-";
                //gvPatients.Rows[i].Cells[6].Text = "-";
                //gvPatients.Rows[i].Cells[7].Text = "-";
                gvPatients.Rows[i].Cells[8].Text = "-";
                gvPatients.Rows[i].Cells[9].Text = "-";
                gvPatients.Rows[i].Cells[10].Text = "-";
                // gvPatients.Rows[i].Cells[11].Text = "-";


                // (gvPatients.Rows[i].Cells[10].FindControl("ViewTrack") as ImageButton).Visible = false;
                (gvPatients.Rows[i].Cells[10].FindControl("Img_Email") as Image).Visible = false;
                (gvPatients.Rows[i].Cells[10].FindControl("Img_cprintAll") as Image).Visible = false;
                (gvPatients.Rows[i].Cells[10].FindControl("Img_printAll") as Image).Visible = false;
                (gvPatients.Rows[i].Cells[10].FindControl("cImg_Email") as Image).Visible = false;
                //Gv_Past_activity.Rows[i].Cells[4].Text = string.Empty;
                //Gv_Past_activity.Rows[i].Cells[5].Text = string.Empty;
                //Gv_Appoint.Rows[i].Cells[0].Text = string.Empty;
            }
            else
            {

                initialnamevalue = (gvPatients.Rows[i].FindControl("lbl_labid") as Label).Text;
                //Response.Write(initialnamevalue);

            }
        }

    }
    
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
      //_doPostBack('<%= ImageButton1.ClientID %>', 'OnClick');
      //  System.Threading.Thread.Sleep(2000);
        Gvonload.Visible = false;
        gvPatients.Visible = true;
        //gvPatients.DataSource = null;
        //gvPatients.DataBind();
        // clear();
        fill_gvPanel();

    }
    private void fill_gvPanel()
    {

        if (tbfromdate.Text != "")
        {
            dayCash.FromDate1 = tbfromdate.Text.Trim().Substring(6, 4) + "/" + tbfromdate.Text.Trim().Substring(3, 2) + "/" + tbfromdate.Text.Trim().Substring(0, 2);

        }
        if (tbtodate.Text != "")
        {
            dayCash.ToDate1 = tbtodate.Text.Trim().Substring(6, 4) + "/" + tbtodate.Text.Trim().Substring(3, 2) + "/" + tbtodate.Text.Trim().Substring(0, 2);
        }

        if (!txtLabelId.Text.Trim().Equals("") && !txtLabelId.Text.Trim().Equals("__-___-________"))
        {
            dayCash.LableId1 = this.txtLabelId.Text.Trim();
        }
        else
        {
            dayCash.LableId1 = "";
        }


        if (!txtPrNo.Text.Trim().Equals("") && !txtPrNo.Text.Trim().Equals("___-__-________"))
        {
            dayCash.PR_NO1 = this.txtPrNo.Text.Trim();
        }
        else
        {
            dayCash.PR_NO1 = "";
        }

        dayCash.Panel1 = ddlPanel.SelectedValue;
        dayCash.Branchid = ddlBranch.SelectedValue;
        dayCash.CellNo1 = txtCellNo.Text;
        dayCash.PatientName1 = txtItemName.Text;

        if (rdIndoor.Checked == true)
        {
            dayCash.Type = "I";
        }
        else if(rdOutDoor.Checked)
        {
            dayCash.Type = "O";
        }
        if (ddlDepartment.SelectedIndex > 0)
            dayCash.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
        if (ddlSubdepartment.SelectedIndex > 0)
            dayCash.SubDepartmentID = this.ddlSubdepartment.SelectedItem.Value.ToString();

        if (ddlGroup.SelectedIndex > 0)
            dayCash.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
        if (ddlTest.SelectedIndex > 0)
            dayCash.TestID = this.ddlTest.SelectedItem.Value.ToString();

        StringBuilder sb_processids = new StringBuilder();
        //sb_processids.Append("abcd,");
        if (lnkspecmen.Checked)
        {
            sb_processids.Append("3,");
        }
        if (lnkwlist.Checked)
        {
            sb_processids.Append("4,");
        }
        if (lnkREntry.Checked)
        {
            sb_processids.Append("5,");
        }
        if (lnkRVerif.Checked)
        {
            sb_processids.Append("6,");
        }
        if (lnkReady.Checked)
        {
            sb_processids.Append("7,");
        }
        if (lnkArchived.Checked)
        {
            sb_processids.Append("8,");
        }
        if (lnkRefund.Checked)
        {
            sb_processids.Append("9,");
        }

        if (sb_processids.ToString().Length > 0)
        {
            dayCash.ProcessID = sb_processids.ToString().Substring(0, sb_processids.ToString().LastIndexOf(','));
        }
        DataView dv = dayCash.GetAll(17);

        dv.Sort = DGSort;
        if (dv.Count > 0)
        {
            gvPatients.DataSource = dv;
            gvPatients.DataBind();
            gridRepeat();
        }
    }

    public void clear()
    {
        txtLabelId.Text = "";
        txtPrNo.Text = "";
        txtItemName.Text = "";
        txtCellNo.Text = "";
        tbfromdate.Text = "";
        tbtodate.Text = "";
        ddlPanel.SelectedIndex = -1;
        gvPatients.DataSource = null;
        gvPatients.DataBind();
        //Gvonload.DataSource = null;
        //Gvonload.DataBind();
   
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();

    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../NewLogin.aspx");
    }
    protected void gvPatients_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("Patient_Name"))
        {
            if (DGSort == "Patient_Name ASC")
                DGSort = "Patient_Name DESC";
            else
                DGSort = "Patient_Name ASC";

        }
        else if (e.SortExpression.Equals("dob"))
        {
            if (DGSort == "dob ASC")
                DGSort = "dob DESC";
            else
                DGSort = "dob ASC";

        }
        else if (e.SortExpression.Equals("prno"))
        {
            if (DGSort == "prno ASC")
                DGSort = "prno DESC";
            else
                DGSort = "prno ASC";
        }
        else if (e.SortExpression.Equals("Status"))
        {
            if (DGSort == "Status ASC")
                DGSort = "Status DESC";
            else
                DGSort = "Status ASC";
        }
        else if (e.SortExpression.Equals("Test_Name"))
        {
            if (DGSort == "Test_Name ASC")
                DGSort = "Test_Name DESC";
            else
                DGSort = "Test_Name ASC";
        }
        else if (e.SortExpression.Equals("Test_Charges"))
        {
            if (DGSort == "Test_Charges ASC")
                DGSort = "Test_Charges DESC";
            else
                DGSort = "Test_Charges ASC";
        }
        else if (e.SortExpression.Equals("labid"))
        {
            if (DGSort == "labid ASC")
                DGSort = "labid DESC";
            else
                DGSort = "labid ASC";
        }
        else if (e.SortExpression.Equals("StatusDate"))
        {
            if (DGSort == "StatusDate ASC")
                DGSort = "StatusDate DESC";
            else
                DGSort = "StatusDate ASC";
        }
        fill_gvPanel();
    }


    protected void gvPatients_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "detail2")
        {
            // lblError.Text = "";
            // pnlDetails.Style.Add("display", "block");
            // pnlMain.Style.Add("display", "none");

            clsDayCashCollection dayCash = new clsDayCashCollection();
            int rowindex = int.Parse(e.CommandArgument.ToString());

            hdfield.Value = gvPatients.DataKeys[rowindex].Values[0].ToString();
            dayCash.Prid = hdfield.Value;
            dayCash.LableId1 = gvPatients.DataKeys[rowindex].Values[2].ToString();

            // Session["prid"] = hdfield.Value;
            // Session["Labid"] = gvPatients.DataKeys[rowindex].Values[2].ToString();

            string prid = hdfield.Value;
            string labid = gvPatients.DataKeys[rowindex].Values[2].ToString();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Status Track", "<script>window.open('trackingRpt.aspx?prid=" + prid + "&labid=" + labid + "');</script>", false);

            //DataView dv = dayCash.GetAll(16);
            //dayCash.Email = dv[0]["email"].ToString();
            //hdmail.Value = dayCash.Email;

            //lblPatientName.Text = dv[0]["Patient_Name"].ToString();
            //lblDOB.Text = dv[0]["dob"].ToString();
            //lblCellNo.Text = dv[0]["cellno"].ToString();
            //lblprno.Text = dv[0]["prno"].ToString();

            //lblLabid.Text = dv[0]["labid"].ToString();
            //dayCash.LableId1 = lblLabid.Text;
            //DataView dv2 = dayCash.GetAll(21);

            //gvTestDetails.DataSource = dv2;
            //gvTestDetails.DataBind();


            //this.ModalPopupExtender1.Show();
            gridRepeat();

            // gridRepeatDetails();
        }
        //if (e.CommandName == "print")
        //{ }

        if (e.CommandName == "email")
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            hdfield.Value = gvPatients.DataKeys[rowindex].Values[0].ToString();
            dayCash.Prid = hdfield.Value;
            DataView dv3 = dayCash.GetAll(16);
            dayCash.Email = dv3[0]["email"].ToString();
            Session["email"] = dayCash.Email;
            Response.Redirect("wfrmCashierEmail.aspx?");
        }
    }

    protected void gvPatients_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            try
            {

                HyperLink hyperLink_Balance = e.Row.FindControl("Hyp_Balance") as HyperLink;
                hyperLink_Balance.NavigateUrl = "wfrmCash.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&pname=" + DataBinder.Eval(e.Row.DataItem, "Patient_Name") + "&totalAmt=" + DataBinder.Eval(e.Row.DataItem, "totalamount") + "&amount=" + DataBinder.Eval(e.Row.DataItem, "paidamount");
                hyperLink_Balance.Target = "wfrmCash.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&pname=" + DataBinder.Eval(e.Row.DataItem, "Patient_Name") + "&totalAmt=" + DataBinder.Eval(e.Row.DataItem, "totalamount") + "&amount=" + DataBinder.Eval(e.Row.DataItem, "paidamount");
                //if (!gvPatients.DataKeys[e.Row.RowIndex].Values[10].ToString().Equals('0') && !gvPatients.DataKeys[e.Row.RowIndex].Values[11].ToString().Equals('N'))
                //{
                //    hyperLink_Balance.Enabled = false;

                //}
                clsReporting obj_reportpreference = new clsReporting();
                obj_reportpreference.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                DataView dv_cashreport = obj_reportpreference.GetAll(40);
                DataView dv_labreport = dv_cashreport;


                HyperLink hyperLink_Receipt = e.Row.FindControl("Hyper_Receipt") as HyperLink;
                
                dv_cashreport.RowFilter = "ReportTypeID=1";
                if (dv_cashreport.Count > 0)
                {
                    hyperLink_Receipt.NavigateUrl = dv_cashreport[0]["Reportformat_path"].ToString().Trim() + "?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                    hyperLink_Receipt.Target = dv_cashreport[0]["Reportformat_path"].ToString().Trim() + "?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";

                }
                else
                {
                    hyperLink_Receipt.NavigateUrl = "wfrmCashReport.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                    hyperLink_Receipt.Target = "wfrmCashReport.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                }
                HyperLink hyperLink_Payment = e.Row.FindControl("Hyper_Pay") as HyperLink;
                hyperLink_Payment.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingid")+"&bookingdid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print";
                hyperLink_Payment.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingid") + "&bookingdid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print";

                HyperLink hyperLink_PaymentAll = e.Row.FindControl("Hyper_PayAll") as HyperLink;
                hyperLink_PaymentAll.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=printAll";
                hyperLink_PaymentAll.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=printAll";
                if ((e.Row.FindControl("lblStatus") as Label).Text.Contains("REF"))
                {
                    HyperLink hyperRefund = e.Row.FindControl("hyperRefund") as HyperLink;
                    hyperRefund.Visible = true;
                    hyperRefund.NavigateUrl = "wfrmCashRefundReport.aspx?refundno=" + DataBinder.Eval(e.Row.DataItem, "refundno") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&discount=";
                    hyperRefund.Target = "wfrmCashRefundReport.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "refundno") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&discount=";
                }

                dv_labreport.RowFilter = "ReportTypeID=2";
                HyperLink hyperLink_labcopy = e.Row.FindControl("Hyper_lab") as HyperLink;
                if (dv_labreport.Count > 0)
                {
                    hyperLink_labcopy.NavigateUrl = dv_labreport[0]["Reportformat_path"].ToString().Trim() + "?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                    hyperLink_labcopy.Target = dv_labreport[0]["Reportformat_path"].ToString().Trim() + "?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";

                }
                else
                {
                    hyperLink_labcopy.NavigateUrl = "wfrmCashReportLab.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                    hyperLink_labcopy.Target = "wfrmCashReportLab.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";

                }
                if (gvPatients.DataKeys[e.Row.RowIndex].Values[3].ToString() == "7" || gvPatients.DataKeys[e.Row.RowIndex].Values[3].ToString() == "8" || (gvPatients.DataKeys[e.Row.RowIndex].Values[3].ToString() == "6" && gvPatients.DataKeys[e.Row.RowIndex].Values[4].ToString() == "Y"))
                {
                    string test = gvPatients.DataKeys[e.Row.RowIndex].Values[7].ToString();
                    if (gvPatients.DataKeys[e.Row.RowIndex].Values[6].ToString().Equals("C") && Convert.ToInt32(gvPatients.DataKeys[e.Row.RowIndex].Values[7].ToString().Replace("-", "-")) > 0)
                    {
                        (e.Row.FindControl("Img_cprint") as Image).Visible = true;
                        (e.Row.FindControl("Img_print") as Image).Visible = false;
                        (e.Row.FindControl("Img_cprintAll") as Image).Visible = true;
                        (e.Row.FindControl("Img_printAll") as Image).Visible = false;
                        (e.Row.FindControl("Img_Email") as Image).Visible = false;
                        (e.Row.FindControl("cImg_Email") as Image).Visible = true;
                       // (e.Row.FindControl("Image1") as Image).Visible = true;
                    }
                    else
                    {
                        (e.Row.FindControl("Img_cprint") as Image).Visible = false;
                        (e.Row.FindControl("Img_print") as Image).Visible = true;
                        (e.Row.FindControl("Img_cprintAll") as Image).Visible = false;
                        (e.Row.FindControl("Img_printAll") as Image).Visible = true;
                        (e.Row.FindControl("Img_Email") as Image).Visible = true;
                        (e.Row.FindControl("cImg_Email") as Image).Visible = false;

                    }

                }
                else
                {
                    (e.Row.FindControl("Img_cprint") as Image).Visible = true;
                    (e.Row.FindControl("Img_print") as Image).Visible = false;

                    (e.Row.FindControl("Img_cprintAll") as Image).Visible = true;
                    (e.Row.FindControl("Img_printAll") as Image).Visible = false;
                    (e.Row.FindControl("imgEmail") as ImageButton).Visible = false;
                    (e.Row.FindControl("cImg_Email") as Image).Visible = true;
                }

                //    HyperLink hyperLink_Email = e.Row.FindControl("Hyper_email") as HyperLink;
                //    //hyperLink_Email.NavigateUrl = "SentEmail.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID");
                //    //hyperLink_Email.Target = "SentEmail.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "";
                //    hyperLink_Email.NavigateUrl = "SentEmail.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID") + "&email=" + DataBinder.Eval(e.Row.DataItem, "email");
                //    hyperLink_Email.Target = "SentEmail.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID") + "&email=" + DataBinder.Eval(e.Row.DataItem, "email");
                HyperLink hyperLink_Email = e.Row.FindControl("Hyper_email") as HyperLink;
                hyperLink_Email.NavigateUrl = "SentEmail.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print" + "&email=" + DataBinder.Eval(e.Row.DataItem, "email") + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID");
                hyperLink_Email.Target = "SentEmail.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print" + "&email=" + DataBinder.Eval(e.Row.DataItem, "email") + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID");



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
      //  this.ModalPopupExtender1.Hide();
    }


    protected void lnkAdvance_Click(object sender, EventArgs e)
    {
        // pnlAdvance.Style.Add("display","block");
    }
    protected void gvTestDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvPatients_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvPatients_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvPatients_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void Gvonload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "detail")
        {
            //  lblError.Text = "";
            //  pnlDetails.Style.Add("display", "block");
            //  pnlMain.Style.Add("display", "none");

            clsDayCashCollection dayCash = new clsDayCashCollection();
            int rowindex = int.Parse(e.CommandArgument.ToString());

            hdfield.Value = Gvonload.DataKeys[rowindex].Values[0].ToString();
            dayCash.Prid = hdfield.Value;


            dayCash.LableId1 = Gvonload.DataKeys[rowindex].Values[2].ToString();


            string prid = hdfield.Value;
            string labid = Gvonload.DataKeys[rowindex].Values[2].ToString();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Status Track", "<script>window.open('trackingRpt.aspx?prid=" + prid + "&labid=" + labid +"');</script>", false);


            //DataView dv = dayCash.GetAll(16);
            //dayCash.Email = dv[0]["email"].ToString();
            //hdmail.Value = dayCash.Email;

            //lblPatientName.Text = dv[0]["Patient_Name"].ToString();
            //lblDOB.Text = dv[0]["dob"].ToString();
            //lblCellNo.Text = dv[0]["cellno"].ToString();
            //lblprno.Text = dv[0]["prno"].ToString();

            //lblLabid.Text = dv[0]["labid"].ToString();
            //dayCash.LableId1 = lblLabid.Text;

            
            //DataView dv2 = dayCash.GetAll(21);

            //gvTestDetails.DataSource = dv2;
            //gvTestDetails.DataBind();


            //this.ModalPopupExtender1.Show();
            gridRepeat1();

        }
        //if (e.CommandName == "print")
        //{ }

        if (e.CommandName == "email")
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            hdfield.Value = Gvonload.DataKeys[rowindex].Values[0].ToString();
            dayCash.Prid = hdfield.Value;
            DataView dv3 = dayCash.GetAll(16);
            dayCash.Email = dv3[0]["email"].ToString();
            Session["email"] = dayCash.Email;
            Response.Redirect("wfrmCashierEmail.aspx?");
        }

    }
    protected void Gvonload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            try
            {

                HyperLink hyperLink_Balance = e.Row.FindControl("Hyp_Balance") as HyperLink;
                hyperLink_Balance.NavigateUrl = "wfrmCash.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&pname=" + DataBinder.Eval(e.Row.DataItem, "Patient_Name") + "&totalAmt=" + DataBinder.Eval(e.Row.DataItem, "totalamount") + "&amount=" + DataBinder.Eval(e.Row.DataItem, "paidamount");
                hyperLink_Balance.Target = "wfrmCash.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&pname=" + DataBinder.Eval(e.Row.DataItem, "Patient_Name") + "&totalAmt=" + DataBinder.Eval(e.Row.DataItem, "totalamount") + "&amount=" + DataBinder.Eval(e.Row.DataItem, "paidamount");

                //if (!Gvonload.DataKeys[e.Row.RowIndex].Values[10].ToString().Equals('0') &&  !Gvonload.DataKeys[e.Row.RowIndex].Values[11].ToString().Equals('N'))
                //{
                //    hyperLink_Balance.Enabled = false;
                    
                //}
                clsReporting obj_reportpreference = new clsReporting();
                obj_reportpreference.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                DataView dv_cashreport = obj_reportpreference.GetAll(40);
                DataView dv_labreport = dv_cashreport;


                HyperLink hyperLink_Receipt = e.Row.FindControl("Hyper_Receipt") as HyperLink;
                dv_cashreport.RowFilter = "ReportTypeID=1";
                if (dv_cashreport.Count > 0)
                {
                    hyperLink_Receipt.NavigateUrl = dv_cashreport[0]["Reportformat_path"].ToString().Trim() + "?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                    hyperLink_Receipt.Target = dv_cashreport[0]["Reportformat_path"].ToString().Trim() + "?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";

                }
                else
                {
                    hyperLink_Receipt.NavigateUrl = "wfrmCashReport.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                    hyperLink_Receipt.Target = "wfrmCashReport.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                }
                HyperLink hyperLink_Payment = e.Row.FindControl("Hyper_Pay") as HyperLink;
                hyperLink_Payment.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print";
                hyperLink_Payment.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print";

                HyperLink hyperLink_PaymentAll = e.Row.FindControl("Hyper_PayAll") as HyperLink;
                hyperLink_PaymentAll.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=printAll"; // "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") +
                hyperLink_PaymentAll.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=printAll";

                if ((e.Row.FindControl("lblStatus") as Label).Text.Contains("REF"))
                {
                    HyperLink hyperRefund = e.Row.FindControl("hyperRefund") as HyperLink;
                    hyperRefund.Visible = true;
                    hyperRefund.NavigateUrl = "wfrmCashRefundReport.aspx?refundno=" + DataBinder.Eval(e.Row.DataItem, "refundno") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&discount=";
                    hyperRefund.Target = "wfrmCashRefundReport.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "refundno") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&discount=";
                }

                dv_labreport.RowFilter = "ReportTypeID=2";
                HyperLink hyperLink_labcopy = e.Row.FindControl("Hyper_lab") as HyperLink;
                if (dv_labreport.Count > 0)
                {
                    hyperLink_labcopy.NavigateUrl = dv_labreport[0]["Reportformat_path"].ToString().Trim() + "?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                    hyperLink_labcopy.Target = dv_labreport[0]["Reportformat_path"].ToString().Trim() + "?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";

                }
                else
                {
                    hyperLink_labcopy.NavigateUrl = "wfrmCashReportLab.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";
                    hyperLink_labcopy.Target = "wfrmCashReportLab.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&watermark=watermark";

                }
                if (Gvonload.DataKeys[e.Row.RowIndex].Values[3].ToString() == "7" || Gvonload.DataKeys[e.Row.RowIndex].Values[3].ToString() == "8" || (Gvonload.DataKeys[e.Row.RowIndex].Values[3].ToString() == "6" && Gvonload.DataKeys[e.Row.RowIndex].Values[4].ToString() == "Y"))
                {


                    string test = Gvonload.DataKeys[e.Row.RowIndex].Values[7].ToString();
                    if (Gvonload.DataKeys[e.Row.RowIndex].Values[6].ToString().Equals("C") &&Convert.ToInt32(Gvonload.DataKeys[e.Row.RowIndex].Values[7].ToString().Replace("-","-")) > 0)
                    {
                        (e.Row.FindControl("Img_cprint") as Image).Visible = true;
                        (e.Row.FindControl("Img_print") as Image).Visible = false;
                        (e.Row.FindControl("Img_cprintAll") as Image).Visible = true;
                        (e.Row.FindControl("Img_printAll") as Image).Visible = false;
                        (e.Row.FindControl("Img_Email") as Image).Visible = false;
                        (e.Row.FindControl("cImg_Email") as Image).Visible = true;
                    }
                    else
                    {
                        (e.Row.FindControl("Img_cprint") as Image).Visible = false;
                        (e.Row.FindControl("Img_print") as Image).Visible = true;
                        (e.Row.FindControl("Img_cprintAll") as Image).Visible = false;
                        (e.Row.FindControl("Img_printAll") as Image).Visible = true;
                        (e.Row.FindControl("Img_Email") as Image).Visible = true;
                        (e.Row.FindControl("cImg_Email") as Image).Visible = false;

                    }

                }
                else
                {
                    (e.Row.FindControl("Img_cprint") as Image).Visible = true;
                    (e.Row.FindControl("Img_print") as Image).Visible = false;

                    (e.Row.FindControl("Img_cprintAll") as Image).Visible = true;
                    (e.Row.FindControl("Img_printAll") as Image).Visible = false;
                    (e.Row.FindControl("Img_Email") as Image).Visible = false;
                    (e.Row.FindControl("cImg_Email") as Image).Visible = true;
                    (e.Row.FindControl("imgEmail") as ImageButton).Visible = false;
                }

            //    HyperLink hyperLink_Email = e.Row.FindControl("Hyper_email") as HyperLink;
            //    //hyperLink_Email.NavigateUrl = "SentEmail.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID");
            //    //hyperLink_Email.Target = "SentEmail.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "";
            //    hyperLink_Email.NavigateUrl = "SentEmail.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID") + "&email=" + DataBinder.Eval(e.Row.DataItem, "email");
            //    hyperLink_Email.Target = "SentEmail.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&referenceno=" + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID") + "&email=" + DataBinder.Eval(e.Row.DataItem, "email");
                HyperLink hyperLink_Email = e.Row.FindControl("Hyper_email") as HyperLink;
                hyperLink_Email.NavigateUrl = "SentEmail.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print" + "&email=" + DataBinder.Eval(e.Row.DataItem, "email") + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID");
                hyperLink_Email.Target = "SentEmail.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId") + "&print=print" + "&email=" + DataBinder.Eval(e.Row.DataItem, "email") + "&branchid=" + DataBinder.Eval(e.Row.DataItem, "BranchID");

            
            
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    protected void Gvonload_Sorting(object sender, GridViewSortEventArgs e)
    {
        {
            if (e.SortExpression.Equals("Patient_Name"))
            {
                if (DGSort1 == "Patient_Name ASC")
                    DGSort1 = "Patient_Name DESC";
                else
                    DGSort1 = "Patient_Name ASC";

            }
            else if (e.SortExpression.Equals("dob"))
            {
                if (DGSort1 == "dob ASC")
                    DGSort1 = "dob DESC";
                else
                    DGSort1 = "dob ASC";

            }
            else if (e.SortExpression.Equals("prno"))
            {
                if (DGSort1 == "prno ASC")
                    DGSort1 = "prno DESC";
                else
                    DGSort1 = "prno ASC";
            }
            else if (e.SortExpression.Equals("Status"))
            {
                if (DGSort1 == "Status ASC")
                    DGSort1 = "Status DESC";
                else
                    DGSort1 = "Status ASC";
            }
            else if (e.SortExpression.Equals("Test_Name"))
            {
                if (DGSort1 == "Test_Name ASC")
                    DGSort1 = "Test_Name DESC";
                else
                    DGSort1 = "Test_Name ASC";
            }
            else if (e.SortExpression.Equals("Test_Charges"))
            {
                if (DGSort1 == "Test_Charges ASC")
                    DGSort1 = "Test_Charges DESC";
                else
                    DGSort1 = "Test_Charges ASC";
            }
            else if (e.SortExpression.Equals("labid"))
            {
                if (DGSort1 == "labid ASC")
                    DGSort1 = "labid DESC";
                else
                    DGSort1 = "labid ASC";
            }
            else if (e.SortExpression.Equals("StatusDate"))
            {
                if (DGSort1 == "StatusDate ASC")
                    DGSort1 = "StatusDate DESC";
                else
                    DGSort1 = "StatusDate ASC";
            }
            filldg(processidglobal);
        }

    }

    public void gridRepeat1()
    {

        for (int j = 0; j < Gvonload.Rows.Count; j++)
        {
            string Panelname = Gvonload.DataKeys[j].Values["Panel"].ToString();
            if (Panelname == "" || Panelname == null)
            {


                (Gvonload.Rows[j].Cells[3].FindControl("lbl_action") as Label).ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                (Gvonload.Rows[j].Cells[3].FindControl("lbl_action") as Label).ForeColor = System.Drawing.Color.Blue;
            }
            //if (!Gvonload.DataKeys[j].Values["panelid"].ToString().Equals("0") && !Gvonload.DataKeys[j].Values["cashpanel"].ToString().Equals("N"))
            //{
            //    (Gvonload.Rows[j].FindControl("Hyp_Balance") as HyperLink).Visible =false;
            //}
            //else
            //{
            //    (Gvonload.Rows[j].FindControl("Hyp_Balance") as HyperLink).Visible = true;
            //}
        }
        string initialnamevalue = (Gvonload.Rows[0].FindControl("lbl_labid") as Label).Text;
        for (int i = 1; i < Gvonload.Rows.Count; i++)
        {
            if ((Gvonload.Rows[i].FindControl("lbl_labid") as Label).Text == initialnamevalue)
            {
                (Gvonload.Rows[i].FindControl("lbl_labid") as Label).Text = string.Empty;
                (Gvonload.Rows[i].FindControl("lbl_labid") as Label).Text = "-";

                Gvonload.Rows[i].Cells[0].Text = "-";

                Gvonload.Rows[i].Cells[1].Text = "-";
                //gvPatients.Rows[i].Cells[2].Text = "-";
                (Gvonload.Rows[i].Cells[2].FindControl("Img_printReceipt") as Image).Visible = false;



                Gvonload.Rows[i].Cells[3].Text = "-";
                //gvPatients.Rows[i].Cells[6].Text = "-";
                //gvPatients.Rows[i].Cells[7].Text = "-";
                Gvonload.Rows[i].Cells[8].Text = "-";
                Gvonload.Rows[i].Cells[9].Text = "-";
                Gvonload.Rows[i].Cells[10].Text = "-";
                // gvPatients.Rows[i].Cells[11].Text = "-";


                // (gvPatients.Rows[i].Cells[10].FindControl("ViewTrack") as ImageButton).Visible = false;
                (Gvonload.Rows[i].Cells[10].FindControl("Img_Email") as Image).Visible = false;
                (Gvonload.Rows[i].Cells[10].FindControl("Img_cprintAll") as Image).Visible = false;
                (Gvonload.Rows[i].Cells[10].FindControl("Img_printAll") as Image).Visible = false;
                (Gvonload.Rows[i].Cells[10].FindControl("cImg_Email") as Image).Visible = false;
                
                //Gv_Past_activity.Rows[i].Cells[4].Text = string.Empty;
                //Gv_Past_activity.Rows[i].Cells[5].Text = string.Empty;
                //Gv_Appoint.Rows[i].Cells[0].Text = string.Empty;
            }
            else
            {

                initialnamevalue = (Gvonload.Rows[i].FindControl("lbl_labid") as Label).Text;
                //Response.Write(initialnamevalue);

            }
        }

    }


    //protected void Gvonload_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    Gvonload.PageIndex = e.NewPageIndex;
    //    filldg();
    //}

    //protected void gvPatients_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{

    //    gvPatients.PageIndex = e.NewPageIndex;
    //    fill_gvPanel();
    //}
    protected void Gvonload_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gvonload.PageIndex = e.NewPageIndex;
        filldg(processidglobal);
    }
    protected void gvPatients_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatients.PageIndex = e.NewPageIndex;
        fill_gvPanel();
    }
   
    protected void rdIndoor_CheckedChanged(object sender, EventArgs e)
    {
        rdOutDoor.Checked = false;
        dayCash.Type = "I";
        filldg(processidglobal);
    }
    protected void rdOutDoor_CheckedChanged(object sender, EventArgs e)
    {
        rdIndoor.Checked = false;
        dayCash.Type = "O";
        filldg(processidglobal);
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        SubDept_Fill();
        Test_Fill();
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

    private void Group_Fill()
    {
        SComponents com = new SComponents();
        clsBLDispatch ds = new clsBLDispatch();

        DataView dv = ds.GetAll(5);
        com.FillDropDownList(ddlGroup, dv, "name", "groupid");
    }

    private void Dept_Fill()
    {
        SComponents com = new SComponents();
        clsBLDispatch ds = new clsBLDispatch();
        DataView dv = ds.GetAll(3);
        com.FillDropDownList(ddlDepartment, dv, "name", "departmentid");
    }
    protected void lnkprocess_Click(object sender, CommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "scol")
        {
            filldg("3");
            processidglobal = "3";
        }
        else if (e.CommandName.ToLower() == "wlist")
        {
            filldg("4");
            processidglobal = "4";
        }
        else if (e.CommandName.ToLower() == "rent")
        {
            filldg("5");
            processidglobal = "5";
        }
        else if (e.CommandName.ToLower() == "verf")
        {
            filldg("6");
            processidglobal = "6";
        }
        else if (e.CommandName.ToLower() == "rdy")
        {
            filldg("7");
            processidglobal = "7";
        }
        else if (e.CommandName.ToLower() == "ref")
        {
            filldg("9");
            processidglobal = "9";
        }
        else if (e.CommandName.ToLower() == "arv")
        {
            filldg("8");
            processidglobal = "8";
        }
    }
    protected void imgbtnEmail_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow gv_Row = (sender as ImageButton).Parent.Parent as GridViewRow;
        int index = gv_Row.RowIndex;
        string StrPRID = "";
        string StrBookingID = "";
        string StrTestID = "";
        string StrBooking_DID = "";

        string StrPRID_Prt = "";
        string StrBookingID_Prt = "";
        string StrTestID_Prt = "";
        string StrBooking_DID_Prt = "";


        //int index = Convert.ToInt32(e.CommandArgument);
        if (Gvonload.DataKeys[index].Values[3].ToString() == "7" || Gvonload.DataKeys[index].Values[3].ToString() == "8" || (Gvonload.DataKeys[index].Values[3].ToString() == "6" && Gvonload.DataKeys[index].Values[4].ToString() == "Y"))
        {
            if (Gvonload.DataKeys[index].Values[6].ToString().Equals("C") && Convert.ToInt32(Gvonload.DataKeys[index].Values[7].ToString().Trim().Replace("-", "0")) > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                return;
            }
            //clsBLDispatch ds = new clsBLDispatch();

            //ds.EnteredBy = Session["personid"].ToString();
            //ds.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            //ds.ClientID = Session["orgid"].ToString();

            //string[,] str = new string[1, 6];
            //int count = 0;

            //str[count, 0] = gvResult.DataKeys[index].Value.ToString();//prid
            //str[count, 1] = gvResult.DataKeys[index].Values[1].ToString(); //bookingid
            //str[count, 2] = gvResult.DataKeys[index].Values[2].ToString(); // testid
            //str[count, 3] = gvResult.Rows[index].Cells[2].Text.Trim(); //labid
            //str[count, 4] = gvResult.DataKeys[index].Values[3].ToString(); //processid
            //str[count, 5] = gvResult.DataKeys[index].Values[5].ToString(); //bookingDID

            // StrPRID = gvPatients.DataKeys[index].Value.ToString();
            StrBookingID = Gvonload.DataKeys[index].Values["bookingid"].ToString();
            // StrTestID = gvPatients.DataKeys[index].Values[2].ToString();
            StrBooking_DID = Gvonload.DataKeys[index].Values["bookingdid"].ToString(); //bookingDID




            //dv = objDis.GetAll(9);
            //Session["testtable"] = dv.Table;

            //dv = objDis.GetAll(10);
            //Session["testsubtable"] = dv.Table;
            Session.Add("SubRptName", "one_column_1");

            string sSelectionFormula = "";
            sSelectionFormula = " {general_result_main.bookingid} in [" + StrBookingID + "]";


            Session["reportname"] = "result";
           // Session["selectionformula"] = "";
            Session["selectionformula"] = sSelectionFormula;

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx?bookingid=" + StrBookingID + "&bookingdid=" + StrBooking_DID + "&" + Rot13.Transform("Email") + "=Y');</script>", false);

            //GV_Fill();
        }
        else
        {
            //  ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('" + ds.Error + "')</script>", false);
        }
    }

    protected void imgbtnEmailsearch_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow gv_Row = (sender as ImageButton).Parent.Parent as GridViewRow;
        int index = gv_Row.RowIndex;



        string StrPRID = "";
        string StrBookingID = "";
        string StrTestID = "";
        string StrBooking_DID = "";

        string StrPRID_Prt = "";
        string StrBookingID_Prt = "";
        string StrTestID_Prt = "";
        string StrBooking_DID_Prt = "";


        //int index = Convert.ToInt32(e.CommandArgument);
        if (gvPatients.DataKeys[index].Values[3].ToString() == "7" || gvPatients.DataKeys[index].Values[3].ToString() == "8" || (gvPatients.DataKeys[index].Values[3].ToString() == "6" && gvPatients.DataKeys[index].Values[4].ToString() == "Y"))
        {
            if (gvPatients.DataKeys[index].Values[6].ToString().Equals("C") && Convert.ToInt32(gvPatients.DataKeys[index].Values[7].ToString().Trim().Replace("-", "0")) > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
                return;
            }
            clsBLDispatch objDis = new clsBLDispatch();

            //ds.EnteredBy = Session["personid"].ToString();
            //ds.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            //ds.ClientID = Session["orgid"].ToString();

            //string[,] str = new string[1, 6];
            //int count = 0;

            //str[count, 0] = gvResult.DataKeys[index].Value.ToString();//prid
            //str[count, 1] = gvResult.DataKeys[index].Values[1].ToString(); //bookingid
            //str[count, 2] = gvResult.DataKeys[index].Values[2].ToString(); // testid
            //str[count, 3] = gvResult.Rows[index].Cells[2].Text.Trim(); //labid
            //str[count, 4] = gvResult.DataKeys[index].Values[3].ToString(); //processid
            //str[count, 5] = gvResult.DataKeys[index].Values[5].ToString(); //bookingDID

           // StrPRID = gvPatients.DataKeys[index].Value.ToString();
            StrBookingID = gvPatients.DataKeys[index].Values["bookingid"].ToString();
           // StrTestID = gvPatients.DataKeys[index].Values[2].ToString();
            StrBooking_DID = gvPatients.DataKeys[index].Values["bookingdid"].ToString(); //bookingDID




            //dv = objDis.GetAll(9);
            //Session["testtable"] = dv.Table;

            //dv = objDis.GetAll(10);
            //Session["testsubtable"] = dv.Table;
            Session.Add("SubRptName", "one_column_1");

            string sSelectionFormula = "";
            sSelectionFormula = " {general_result_main.bookingid} in [" + StrBookingID + "]";


            Session["reportname"] = "result";
            // Session["selectionformula"] = "";
            Session["selectionformula"] = sSelectionFormula;

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx?bookingid=" + StrBookingID + "&bookingdid=" + StrBooking_DID + "&" + Rot13.Transform("Email") + "=Y');</script>", false);

            //GV_Fill();
        }
        else
        {
          //  ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('" + ds.Error + "')</script>", false);
        }
    }
        

    
}