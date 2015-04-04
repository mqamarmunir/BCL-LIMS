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
using CustomUIControls;

public partial class invest_reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    //    lblsalesdisc.Text = "";
       // lblxc.Text = "";
       Response.CacheControl = "no-cache";

        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                Session["dt"] = "";
                FillDept_GV();
                FillGroup_GV();
                PatientInfo();

                FillGvTest();
                // FillBranch();
                Cash_Auth();
                FillWard();
                //pnlInt_cmmnt.Visible = false;

                pnl_ward.Visible = false;
                mde_intcmt.Hide();

                ListItem l = new ListItem("Outdoor", "O", true);
                l.Selected = false;
                ddlPatientType.Items.Add(l);
                if (Session["indoor_services"].ToString().Trim().Equals("Y"))
                {
                    ListItem ind = new ListItem("Indoor", "I", true);
                    ind.Selected = false;
                    ddlPatientType.Items.Add(ind);
                }



                if (!Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
                {
                    chkOnCASH.Visible = false;
                    txtDiscount.Enabled = true;
                }
                else
                {
                    txtDiscount.Enabled = false;
                    chkOnCASH.Visible = true;
                }

                lblcharges.Text = "0";
                txtList_search.Attributes.Add("onKeyUp", "__doPostBack('ctl00_ContentPlaceHolder1_txtList_search','')");

                
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }

    protected void imgCLose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        Refresh_Form();
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        if (ddlPatientType.SelectedItem.Value.ToString().Equals("I") && ddlWard.SelectedIndex <= 0)
        {
            lblError.Text = "Please select ward.";
            ddlWard.Focus();
            return;
        }
        if (gvTestPick.Rows.Count <= 0)
        {
            lblError.Text = "Please select test list";
            return;
        }
        if (Convert.ToInt32(txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim()) > Convert.ToInt32(lblcharges.Text.Trim().Equals("") ? "0" : lblcharges.Text.Trim()))
        {
            lblError.Text = "Please enter cash amount less than or equal to Total Charges.";
            txtCash.Focus();
            return;
        }
        if (Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 100)
        {
            lblError.Text = "Please enter discount percentage less than or equal to 100 ";
            txtDiscount.Focus();
            return;
        }
        if (Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 0 && Convert.ToInt32(txtCash.Text.Trim()) > Convert.ToInt32(lblcharges.Text.Trim()) - (Convert.ToInt32(lblcharges.Text.Trim()) * Convert.ToInt32(txtDiscount.Text) / 100))
        {
            lblError.Text = "Please correct receive amount.You can receive maximum  " + (Convert.ToInt32(lblcharges.Text) - ((Convert.ToInt32(lblcharges.Text.Trim()) * Convert.ToInt32(txtDiscount.Text)) / 100)) + " rupees";
            txtCash.Focus();
            return;
        }
        if (Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) == 0 && Convert.ToInt32(txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim()) == 0 && (Request.QueryString["panelid"].ToString().Trim() == "-1" || Request.QueryString["patienttype"].ToString().Trim().Equals("C")))
        {
            lblError.Text = "Please enter cash amount greather than 0 ";
            txtCash.Focus();
            return;
        }
        if (rdbMode.SelectedIndex > 0 && !rdbMode.Items.FindByValue("C").Selected && txtReferenceNo.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter credit or debit card reference number.";
            txtReferenceNo.Focus();
            return;
        }
        else if (txtCash.Visible == true && Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 0 && Request.QueryString["panelid"].ToString().Trim() == "-1")
        {
            Booking_Cash();
        }
        else if (txtCash.Visible == true && Convert.ToInt32(txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim()) > 0 && Request.QueryString["panelid"].ToString().Trim() == "-1")
        {
            Booking_Cash();
        }
        else if (txtCash.Visible == true && Request.QueryString["panelid"].ToString().Trim() != "-1")
        {
            Booking_Cash();
        }
        else if (Request.QueryString["panelid"].ToString().Trim() != "-1")//Request.QueryString["authorizeno"].ToString().Trim() !="~!@" &&
        {
            Booking_Cash();
        }
        else
        {
            Insert();
        }



    }

    private void FillDept_GV()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();

        DataView dv = reg.GetAll(2);
        if (dv.Count > 0)
        {
            gvDepartment.DataSource = dv;
            gvDepartment.DataBind();
        }
        else
        {
            gvDepartment.DataSource = null;
            gvDepartment.DataBind();
        }
    }
    private void FillGroup_GV()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
        SComponents com = new SComponents();
        DataView dv;
        if (Request.QueryString["panelid"].ToString().Trim() == "-1" || !Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
            dv = reg.GetAll(4);
        else
        {
            reg.PanelID = Request.QueryString["panelid"].ToString();
            dv = reg.GetAll(27);
        }
        if (dv.Count > 0)
        {
            gvGroup.DataSource = dv;
            gvGroup.DataBind();
        }
        else
        {
            gvGroup.DataSource = null;
            gvGroup.DataBind();
        }
    }
    private void FillBranch()
    {
        clsBLPatientReg_Inv rec = new clsBLPatientReg_Inv();
        DataView dv = rec.GetAll(19);
        SComponents com = new SComponents();
        com.FillDropDownListWithoutSelect(ddlBranch, dv, "name", "orgid", true, false);
        try
        {
            ddlBranch.SelectedItem.Selected = false;
            ddlBranch.Items.FindByValue(Session["branchid"].ToString()).Selected = true;
        }
        catch { }
    }
    private void FillWard()
    {
        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
        SComponents com = new SComponents();
        DataView dv = iv.GetAll(31);

        com.FillDropDownList(ddlWard, dv, "name", "wardid");
    }

    private void MakeTable()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("testid");
        dt.Columns.Add("testname");
        dt.Columns.Add("charges");
        dt.Columns.Add("groupid");
        dt.Columns.Add("classificationid");
        dt.Columns.Add("priority");
        dt.Columns.Add("deliveredon");

        if (Session["dt"].Equals(""))
            Session["dt"] = dt;
        else
            dt = (DataTable)Session["dt"];

    }

    private void Insert()
    {
        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

        iv.PRNO = this.lblPRno.Text.Trim();
        iv.PRID = Request.QueryString["prid"].ToString();
        iv.SpecimenInternal = rdbSpecimen.SelectedValue.ToString().Trim();
        if (Request.QueryString.Get("doctorid").ToString().Trim() != "-1")
            iv.DoctorID = Request.QueryString.Get("doctorid").ToString();
        else
            iv.ReferredBy = Request.QueryString.Get("referredby").ToString();

        iv.Type = ddlPatientType.SelectedItem.Value.ToString();
        if (ddlPatientType.SelectedItem.Value.ToString().Equals("I"))
        {
            iv.WardID = this.ddlWard.SelectedItem.Value.ToString();
            iv.Bed = this.txtBed.Text.Trim().Replace("'", "''");
            iv.Adm_Ref = this.txtAdm_Reference.Text.Trim().Replace("'", "''");
        }
        iv.Status = "C";
        iv.DeliveryBy = Request.QueryString.Get("deliveryby").ToString();
        iv.AuthorizeNo = Request.QueryString["authorizeno"].ToString().Trim();


        //iv.Orgin_Place = Session["branchid"].ToString();
        iv.Orgin_Place = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //this.ddlBranch.SelectedItem.Value.ToString();
        iv.BranchID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //this.ddlBranch.SelectedItem.Value.ToString();
        //Session["branchid"].ToString();

        iv.EnteredBy = this.Session["personid"].ToString();
        iv.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        iv.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //this.ddlBranch.SelectedItem.Value.ToString();
        //Session["orgid"].ToString(); // org
        iv.ProcessID = "002"; // route to cash collection
        iv.ReferenceNo = Request.QueryString["referenceno"].ToString().Replace(">>", "&").Replace("%%", "#");
        iv.Remarks = Request.QueryString["remarks"].ToString().Trim().Equals("") ? "~!@" : Request.QueryString["remarks"].ToString().Trim();


        string[,] str = new string[gvTestPick.Rows.Count, 7];
        int count = 0;
        int totalamount = 0;

        for (int i = 0; i < gvTestPick.Rows.Count; i++)
        {
            str[count, 0] = gvTestPick.DataKeys[i].Value.ToString(); // testid
            str[count, 1] = gvTestPick.DataKeys[i].Values[1].ToString(); // classificationID

            str[count, 2] = gvTestPick.Rows[i].Cells[2].Text.Trim().ToString(); // test amount
            str[count, 3] = gvTestPick.DataKeys[i].Values[2].ToString(); // priority
            str[count, 4] = "2";
            str[count, 5] = gvTestPick.DataKeys[i].Values[3].ToString(); // comment internal
            str[count, 6] = gvTestPick.DataKeys[i].Values[4].ToString().Trim().Equals("") ? "null" : gvTestPick.DataKeys[i].Values[4].ToString().Trim().Equals("-1") ? "null" : gvTestPick.DataKeys[i].Values[4].ToString(); // for process _ internal comment
            if (gvTestPick.Columns[2].Visible == true)
                totalamount += Convert.ToInt32(gvTestPick.Rows[i].Cells[2].Text.Trim().ToString()); // test amount  
            else
                totalamount += Convert.ToInt32(gvTestPick.DataKeys[i].Values[5].ToString()); // test amount  
            //totalamount += Convert.ToInt32(gvTestPick.Rows[i].Cells[2].Text.Trim()); // calculating Total Amt
            count++;
        }


        iv.TotalAmount = totalamount.ToString();
        iv.Branch_ID = Session["BranchID"].ToString().Trim();
        if (iv.Booking_Insert(str))
        {
            Session["dt"] = "";
            Session["dtsearch"] = "";
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Lab Investigation has been booked.Lab ID=" + iv.LabID;
            // if(txtCash.Visible==true && Convert.ToInt32(txtCash.Text.Trim()) >0)
            // Response.Redirect("wfrmPatient.aspx?plabid="+iv.LabID+" ");
            // else
            //     Response.Redirect("wfrmPatient.aspx?nlabid=" + iv.LabID + "");
            // Refresh_Form();
            //TaskbarNotifier tt = new TaskbarNotifier();
            //tt.Show("Hello Dear", "This is first popup", 1000, 3000, 1000);

        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = iv.Error;
        }



    }
    private void Booking_Cash()
    {
        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

        iv.PRNO = this.lblPRno.Text.Trim();
        iv.PRID = Request.QueryString["prid"].ToString();
        iv.SpecimenInternal = rdbSpecimen.SelectedValue.ToString();

        //iv.TotalAmount = this.lblcharges.Text.Trim();

        iv.PanelID = Request.QueryString["panelid"].ToString().Trim().Replace("-1", "").Equals("") ? "~!@" : Request.QueryString["panelid"].ToString().Trim();

        if (Request.QueryString.Get("doctorid").ToString().Trim() != "-1")
            iv.DoctorID = Request.QueryString.Get("doctorid").ToString();
        else
            iv.ReferredBy = Request.QueryString.Get("referredby").ToString();

        iv.Type = ddlPatientType.SelectedItem.Value.ToString();
        if (ddlPatientType.SelectedItem.Value.ToString().Equals("I"))
        {
            iv.WardID = this.ddlWard.SelectedItem.Value.ToString();
            iv.Bed = this.txtBed.Text.Trim().Replace("'", "''");
            iv.Adm_Ref = this.txtAdm_Reference.Text.Trim().Replace("'", "''");
        }
        if (Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
        {
            iv.Status = "P";
        }
        else
        {
            iv.Status = "C";
        }

        iv.DeliveryBy = Request.QueryString.Get("deliveryby").ToString();
        iv.ReferenceNo = Request.QueryString["referenceno"].ToString().Replace(">>", "&").Replace("%%", "#");


        // iv.Orgin_Place = Session["branchid"].ToString();
        iv.Orgin_Place = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //this.ddlBranch.SelectedItem.Value.ToString();
        iv.BranchID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //this.ddlBranch.SelectedItem.Value.ToString();
        //Session["branchid"].ToString();

        iv.EnteredBy = this.Session["personid"].ToString();
        iv.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        iv.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //this.ddlBranch.SelectedItem.Value.ToString();
        iv.Remarks = Request.QueryString["remarks"].ToString().Trim().Equals("") ? "~!@" : Request.QueryString["remarks"].ToString().Trim();
        //Session["orgid"].ToString(); // org        


        string[,] str = new string[gvTestPick.Rows.Count, 9];
        int count = 0;
        int totalamount = 0;
        double cal_dis = 0;

        for (int i = 0; i < gvTestPick.Rows.Count; i++)
        {
            str[count, 0] = gvTestPick.DataKeys[i].Value.ToString(); // testid

            str[count, 1] = gvTestPick.DataKeys[i].Values[1].ToString(); // classificationID
            //if (Convert.ToInt32(this.txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 0)
            //{
            //   cal_dis =Math.Round(Convert.ToDouble(gvTestPick.Rows[i].Cells[2].Text.Trim()) * Convert.ToDouble(txtDiscount.Text.Trim()) / 100);
            //   //cal_dis =Convert.ToInt32(gvTestPick.Rows[i].Cells[2].Text.Trim()) - cal_dis;
            //   str[count, 2] = gvTestPick.Rows[i].Cells[2].Text.Trim();
            //   str[count, 3] = cal_dis.ToString(); // discount as per test
            //   cal_dis = 0;
            //}
            //else
            //{
            if (gvTestPick.Columns[2].Visible == true)
                str[count, 2] = gvTestPick.Rows[i].Cells[2].Text.Trim().ToString(); // test amount  
            else
                str[count, 2] = gvTestPick.DataKeys[i].Values[5].ToString(); // test amount  
            str[count, 3] = "0"; // discount as per test
            // }
            str[count, 4] = gvTestPick.DataKeys[i].Values[2].ToString(); // priority

            iv.TestID = gvTestPick.DataKeys[i].Value.ToString(); // testid
            DataView dv = iv.GetAll(25);
            if (dv.Count == 0)
                str[count, 5] = "~!@";
            else
            {
                for (int m = 0; m < dv.Count; m++)
                {
                    if (!dv[m]["processid"].Equals("1") && !dv[m]["processid"].Equals("2"))
                    {
                        if (dv[m]["processid"].ToString().Trim().Equals("3") || dv[m]["processid"].ToString().Trim().Equals("4") || dv[m]["processid"].ToString().Trim().Equals("5") || dv[m]["processid"].ToString().Trim().Equals("6") || dv[m]["processid"].ToString().Trim().Equals("7"))
                        {
                            str[count, 5] = dv[m]["processid"].ToString().Trim();
                            break;
                        }
                    }
                }
            }
            str[count, 6] = gvTestPick.DataKeys[i].Values[3].ToString(); // comment internal
            str[count, 7] = gvTestPick.DataKeys[i].Values[4].ToString().Trim().Equals("") ? "null" : gvTestPick.DataKeys[i].Values[4].ToString().Trim().Equals("-1") ? "null" : gvTestPick.DataKeys[i].Values[4].ToString(); // for process _ internal comment
           

            if (gvTestPick.Columns[2].Visible == true)
                totalamount += Convert.ToInt32(gvTestPick.Rows[i].Cells[2].Text.Trim().ToString()); // test amount  
            else
                totalamount += Convert.ToInt32(gvTestPick.DataKeys[i].Values[5].ToString()); // test amount  
            //totalamount += Convert.ToInt32(gvTestPick.Rows[i].Cells[2].Text.Trim()); // calculating Total Amt
            str[count, 8] = gvTestPick.DataKeys[i].Values[6].ToString();
            count++;
        }


        iv.TotalAmount = totalamount.ToString();
        //!Request.QueryString["authorizeno"].ToString().Trim().Equals("~!@")
        if (!Request.QueryString["panelid"].ToString().Trim().Equals("-1") && chkOnCASH.Checked == false && Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
        {
            iv.PaidAmount = "null";
            //txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim();
            //"null";
            iv.PaymentMode = "A";
            iv.AuthorizeNo = Request.QueryString["authorizeno"].ToString().Trim();
            iv.Patient_Type = Request.QueryString["patienttype"].ToString().Trim();
        }
        else
        {
            //if (txtDiscount.Text.Trim().Equals(""))
            iv.PaidAmount = txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim();
            //else
            //    iv.PaidAmount =Convert.ToString(Convert.ToInt32(lblcharges.Text.Trim())- (Convert.ToInt32(lblcharges.Text.Trim()) * Convert.ToInt32(txtDiscount.Text.Trim()) / 100));
            //this.txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim();
            iv.Patient_Type = Request.QueryString["patienttype"].ToString().Trim().Replace("A", "C");
            iv.PaymentMode = this.rdbMode.SelectedItem.Value.ToString();
            iv.Card_ReferenceNo = rdbMode.Items.FindByValue("C").Selected ? "~!@" : txtReferenceNo.Text.Trim();
            if (Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 0)
            {
                iv.Discount = Convert.ToString((Convert.ToInt32(lblcharges.Text.Trim()) * Convert.ToInt32(txtDiscount.Text)) / 100);
                iv.RefundType = "D";
            }
            else
            {
                iv.Discount = "0";
            }
        }
        iv.Branch_ID = Session["BranchID"].ToString().Trim();
        iv.Sendstatus = "P";
        if (iv.Booking_Cash_Insert(str))
        {
            Session["dt"] = "";
            Session["dtsearch"] = "";
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Lab Investigation has been booked.Lab ID=" + iv.LabID;
            //if (txtCash.Visible == true && Convert.ToInt32(txtCash.Text.Trim()) > 0)
            //Response.Redirect("wfrmPatient.aspx?plabid=" + iv.LabID + " &recno=" + iv.Receive_NO + "");
            // else
            //Response.Redirect("wfrmPatient.aspx?nlabid=" + iv.LabID + "");
            // Refresh_Form();
            //TaskbarNotifier tt = new TaskbarNotifier();
            //tt.Show("Hello Dear", "This is first popup", 1000, 3000, 1000);
            ////////////////////////****************************************************//////////////////////


            string labid = iv.LabID.ToString();
            string prno = lblPRno.Text.ToString();
            string reference = Request.QueryString["referenceno"].ToString();
            string OnCashed = "";

            if (chkOnCASH.Checked == true)
            {
                 OnCashed = "Y";
            }
            else if (chkOnCASH.Checked == false)
            {
                OnCashed = "N";
            }
            else
            {
                OnCashed = "Y";
            }


           // Session["prno"] = lblPRno.Text.ToString();
           // Session["labid"] = iv.LabID.ToString();
            //loadHeadList();
            //loadFooterList();
            //Response.Redirect("wfrmCashReport.aspx");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('wfrmCashReportLab.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + reference + "&cash=" + OnCashed + "');</script>", false);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + reference + "&cash=" + OnCashed + "');</script>", false);
           
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx');</script>", false);
            //Response.Write("<script language='javascript'>window.open('wfrmCashReport.aspx');</script>");
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = iv.Error;
        }






    }
    private void Refresh_Form()
    {
        Session["dt"] = "";
        gvTestPick.DataSource = null;
        gvTestPick.DataBind();
        lblcharges.Text = "0";
        lblError.Text = "";
        txtSearch_test.Text = "";
        txtCash.Text = "0";
        //ddlBranch.SelectedItem.Selected = false;
        //ddlBranch.Items.FindByValue(Session["branchid"].ToString()).Selected = true;
    }

    protected void lbtnDepart_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
        GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);

        reg.DepartmentID = gvDepartment.DataKeys[gridItem.DataItemIndex].Value.ToString();
        DataView dv = reg.GetAll(3);

        if (dv.Count > 0)
        {
            gvSubdept.DataSource = dv;
            gvSubdept.DataBind();
        }
        else
        {
            gvSubdept.DataSource = null;
            gvSubdept.DataBind();
        }

    }
    protected void lbtnSubDept_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (Session["BranchID"].ToString().Trim() != "")
        {
            clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
            GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);
            reg.Gender = lblGender.Text.Trim().Substring(0, 1);
            reg.Priority = rdbPriority.SelectedItem.Value.ToString().Replace("U", "N");
            reg.Rate = "P";
            reg.Branch_ID = Session["BranchID"].ToString();
            reg.SubDepartmentID = gvSubdept.DataKeys[gridItem.DataItemIndex].Value.ToString();
            //Request.QueryString["rate"].Trim().ToString();

            string[] str = lblAge.Text.Trim().Split('-');
            if (str.GetValue(1).Equals("Year"))
                reg.DOB = str.GetValue(0).ToString();
            else
                reg.DOB = "1";
            if (!txtSearch_test.Text.Trim().Equals(""))
                reg.Name = this.txtSearch_test.Text.Trim();

            if (!txtSpeed.Text.Trim().Equals(""))
                reg.SpeedKey = this.txtSpeed.Text.Trim();
            DataView dv = new DataView() ;
            if (Request.QueryString["panelid"].ToString().Trim() == "-1" || !Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
            {
                dv = reg.GetAll(40);

            }
            else
            {
                reg.PanelID = Request.QueryString["panelid"].ToString().Trim();
                dv = reg.GetAll(41);
            }
            if (dv.Count > 0)
            {
                gvTestList.DataSource = dv;
                gvTestList.DataBind();
                if (dv[0]["print_amount"].ToString().Trim().Equals("N") && Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
                    gvTestList.Columns[2].Visible = false;
            }
            else
            {
                gvTestList.DataSource = "";
                gvTestList.DataBind();

            }
        }
        else
        {
            clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
            GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);

            reg.DepartmentID = gvSubdept.DataKeys[gridItem.DataItemIndex].Values[1].ToString();
            reg.SubDepartmentID = gvSubdept.DataKeys[gridItem.DataItemIndex].Value.ToString();

            reg.Gender = lblGender.Text.Trim().Substring(0, 1);
            reg.Priority = rdbPriority.SelectedItem.Value.ToString();
            reg.Rate = "P";

            string[] str = lblAge.Text.Trim().Split('-');
            if (str.GetValue(1).Equals("Year"))
                reg.DOB = str.GetValue(0).ToString();
            else
                reg.DOB = "1";

            DataView dv;
            if (Request.QueryString["panelid"].ToString().Trim() == "-1" || !Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
            {
                dv = reg.GetAll(5);
            }
            else
            {
                reg.PanelID = Request.QueryString["panelid"].ToString();
                dv = reg.GetAll(22);
            }
            if (dv.Count > 0)
            {
                gvTestList.DataSource = dv;
                gvTestList.DataBind();
                Session["dtsearch"] = dv.Table;
                //PanelCharges();
            }
            else
            {
                gvTestList.DataSource = null;
                gvTestList.DataBind();
                Session["dtsearch"] = "";
            }
        }
    }
    #region "Old Selection"
    //protected void lbtnTestList_Click(object sender, EventArgs e)
    //{
    //    lblError.Text = "";
    //    GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);

    //    DataTable dt = new DataTable();

    //    dt.Columns.Add("testid");
    //    dt.Columns.Add("testname");
    //    dt.Columns.Add("charges");
    //    dt.Columns.Add("groupid");
    //    dt.Columns.Add("classificationid");
    //    dt.Columns.Add("priority");

    //    if (Session["dt"].Equals(""))
    //        Session["dt"] = dt;
    //    else
    //        dt = (DataTable)Session["dt"];

    //    string str_testid = gvTestList.DataKeys[gridItem.DataItemIndex].Value.ToString();
    //    string str_classID = gvTestList.DataKeys[gridItem.DataItemIndex].Values[1].ToString();
    //    int t_charges =Convert.ToInt32(gvTestList.Rows[gridItem.DataItemIndex].Cells[2].Text.Trim());

    //    foreach (DataRow dr2 in dt.Rows)
    //    {
    //        if (str_testid.Equals(dr2["testid"].ToString()) && str_classID.Equals(dr2["classificationid"].ToString()))
    //        {
    //            lblError.ForeColor = System.Drawing.Color.Red;
    //            lblError.Text = "This test is already added.";
    //            return;
    //        }
    //    }

    //    DataRow dr = dt.NewRow();

    //    dr["testid"] = str_testid;
    //    dr["testname"] = ((LinkButton)(gvTestList.Rows[gridItem.DataItemIndex].Cells[1].FindControl("lbtnTestList"))).Text.Trim();
    //    dr["charges"] = t_charges.ToString();
    //    dr["classificationid"] = str_classID;
    //    dr["priority"] = gvTestList.DataKeys[gridItem.DataItemIndex].Values[2].ToString();
    //    dt.Rows.Add(dr);

    //    gvTestPick.DataSource = dt;
    //    gvTestPick.DataBind();

    //    lblcharges.Text =Convert.ToString(Convert.ToInt32(lblcharges.Text.Trim().Equals("")?"0":lblcharges.Text.Trim()) + t_charges);
    //}
    #endregion
    protected void lbtnGroup_Click(object sender, EventArgs e)
    {
        if (Session["BranchID"].ToString().Trim() == "")
        {
            lblError.Text = "";
            GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);
            clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();

            reg.GroupID = gvGroup.DataKeys[gridItem.DataItemIndex].Value.ToString();
            reg.Priority = rdbPriority.SelectedItem.Value.ToString();
            reg.Gender = lblGender.Text.Trim().Substring(0, 1);
            reg.Rate = "P";

            string[] str = lblAge.Text.Trim().Split('-');
            if (str.GetValue(1).Equals("Year"))
                reg.DOB = str.GetValue(0).ToString();
            else
                reg.DOB = "1";

            DataView dv;
            //if (Request.QueryString["panelid"].ToString().Trim() == "-1")
            //    dv = reg.GetAll(11);
            //else
            //{
            //    reg.PanelID = Request.QueryString["panelid"].ToString().Trim();
            //    dv = reg.GetAll(23);
            //}

            if (Request.QueryString["panelid"].ToString().Trim() == "-1" || !Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
                dv = reg.GetAll(11);
            else
            {
                reg.PanelID = Request.QueryString["panelid"].ToString().Trim();
                dv = reg.GetAll(28);
            }


            if (dv.Count > 0)
            {
                gvTestList.DataSource = dv;
                gvTestList.DataBind();
                Session["dtsearch"] = dv.Table;
                //PanelCharges();
            }
            else
            {
                gvTestList.DataSource = null;
                gvTestList.DataBind();
                Session["dtsearch"] = "";
            }
        }
        

    }
    protected void gvTestPick_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)Session["dt"];

        int t_Charges = Convert.ToInt32(gvTestPick.Rows[e.RowIndex].Cells[2].Text.Trim());
        lblcharges.Text = Convert.ToString(Convert.ToInt32(lblcharges.Text.Trim().Equals("") ? "0" : lblcharges.Text.Trim()) - t_Charges);
        txtCash.Text = lblcharges.Text.Trim();

        dt.Rows[e.RowIndex].Delete();
        dt.AcceptChanges();
        this.gvTestPick.DataSource = dt;
        this.gvTestPick.DataBind();
        Session["dt"] = dt;
    }

    private void PanelCharges()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();

        string strpanel = Request.QueryString["panelid"].ToString();
        //  string strclass = Request.QueryString["classid"].ToString();


        if (strpanel.Trim() != "-1" && Request.QueryString["patienttype"].ToString().Trim().Equals("A"))//&& strclass.Trim() !="-1"
        {
            reg.PanelID = strpanel;
            // reg.ClassID = strclass;
            reg.Priority = rdbPriority.SelectedItem.Value.ToString().Replace("U", "N");

            DataView dv = reg.GetAll(13);

            int rowIndex = 0;

            foreach (DataRow drtest in dv.Table.Rows)
            {
                foreach (GridViewRow gvro in gvTestList.Rows)
                {
                    if (this.gvTestList.DataKeys[rowIndex].Value.ToString().Equals(drtest["testid"].ToString()))
                    {
                        gvTestList.Rows[rowIndex].Cells[2].Text = drtest["charges"].ToString();
                    }
                    rowIndex++;
                }

                rowIndex = 0;
            }
        }

    }
    private void PatientInfo()
    {
        lblPRno.Text = Request.QueryString["prno"].ToString();
        lblAge.Text = Request.QueryString["age"].ToString();
        lblPatient.Text = Request.QueryString["patient"].ToString();

        lblGender.Text = Request.QueryString["gender"].ToString().Trim().Equals("M") ? "Male" : "Female";
        lblMarital.Text = Request.QueryString["marital"].ToString();

        lblPanel.Text = Request.QueryString["panelname"].ToString().Replace("Select", "").Replace(">>", "&").Replace("%%", "#");
        if (lblPanel.Text.Trim().Equals(""))
        {
            lblPanelHead.Visible = false;
            lblClassHead.Visible = false;
        }

        //try
        //{
        //    lblClass.Text = Request.QueryString["classname"].ToString().Replace("Select", "");
        //}
        //catch { }
        //if (lblClass.Text.Trim().Equals(""))
        //    lblClassHead.Visible = false;

        rdbPriority.Items.FindByValue("N").Selected = true;

    }
    private void FillGvTest()
    {
        if (Session["BranchID"].ToString().Trim() != "")
        {
            clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
            reg.Gender = lblGender.Text.Trim().Substring(0, 1);
            reg.Priority = rdbPriority.SelectedItem.Value.ToString().Replace("U", "N");
            reg.Rate = "P";
            reg.Branch_ID = Session["BranchID"].ToString();
            //Request.QueryString["rate"].Trim().ToString();

            string[] str = lblAge.Text.Trim().Split('-');
            if (str.GetValue(1).Equals("Year"))
                reg.DOB = str.GetValue(0).ToString();
            else
                reg.DOB = "1";
            if (!txtSearch_test.Text.Trim().Equals(""))
                reg.Name = this.txtSearch_test.Text.Trim();

            if (!txtSpeed.Text.Trim().Equals(""))
                reg.SpeedKey = this.txtSpeed.Text.Trim();
            DataView dv=new DataView();
            if (Request.QueryString["panelid"].ToString().Trim() == "-1" || !Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
            {
               
                dv = reg.GetAll(40);
            }
            else
            {
                reg.PanelID = Request.QueryString["panelid"].ToString().Trim();
                dv = reg.GetAll(41);
            }

            if (dv.Count > 0)
            {
                gvTestList.DataSource = dv;
                gvTestList.DataBind();
                if (dv[0]["print_amount"].ToString().Trim().Equals("N") && Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
                    gvTestList.Columns[2].Visible = false;
            }
            else
            {
                gvTestList.DataSource = "";
                gvTestList.DataBind();
            }
        }
        else
        {
            clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
            reg.Gender = lblGender.Text.Trim().Substring(0, 1);
            reg.Priority = rdbPriority.SelectedItem.Value.ToString().Replace("U", "N");
            reg.Rate = "P";
            //Request.QueryString["rate"].Trim().ToString();

            string[] str = lblAge.Text.Trim().Split('-');
            if (str.GetValue(1).Equals("Year"))
                reg.DOB = str.GetValue(0).ToString();
            else
                reg.DOB = "1";
            if (!txtSearch_test.Text.Trim().Equals(""))
                reg.Name = this.txtSearch_test.Text.Trim();

            if (!txtSpeed.Text.Trim().Equals(""))
                reg.SpeedKey = this.txtSpeed.Text.Trim();
            DataView dv;
            if (Request.QueryString["panelid"].ToString().Trim() == "-1" || !Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
                dv = reg.GetAll(5);
            else
            {
                reg.PanelID = Request.QueryString["panelid"].ToString();
                dv = reg.GetAll(22);
            }

            if (dv.Count > 0)
            {
                gvTestList.DataSource = dv;
                gvTestList.DataBind();
                if (dv[0]["print_amount"].ToString().Trim().Equals("N") && Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
                    gvTestList.Columns[2].Visible = false;
                Session["dtsearch"] = dv.Table;

                //PanelCharges();
            }
            else
            {
                gvTestList.DataSource = null;
                gvTestList.DataBind();
                Session["dtsearch"] = "";
            }
        }
    }
    private void Cash_Auth()
    {
        //if (Request.QueryString["authorizeno"].ToString().Trim().Replace("~!@","").Equals(""))
        //{
        clsLogin log = new clsLogin();
        log.OptionId = "29";
        log.PersonId = Session["personid"].ToString();
        DataView dvLog = log.GetLogin(2);
        if (dvLog.Count > 0)
        {

            if (Request.QueryString["panelid"].ToString().Trim() == "-1" || !Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
            {
                rdbMode.Visible = true;
                rdbMode.Items.FindByValue("C").Selected = true;

                txtCash.Text = "0";
                lblCash.Text = "Cash Received:";
            }
            else
            {
                rdbMode.Visible = false;
                txtCash.Visible = false;
                lblCash.Text = "";
            }
        }
        else
        {
            lblCash.Visible = false;
            txtCash.Visible = false;
            rdbMode.Visible = false;
        }


        lblReferenceNo.Visible = false;
        txtReferenceNo.Visible = false;
        //}
        //else
        //{
        //    lblCash.Visible = false;
        //    txtCash.Visible = false;
        //    rdbMode.Visible = false;
        //}
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        lblError.Text = "";

        DataTable dt = new DataTable();

        dt.Columns.Add("testid");
        dt.Columns.Add("testname");
        dt.Columns.Add("charges");
        dt.Columns.Add("groupid");
        dt.Columns.Add("classificationid");
        dt.Columns.Add("priority");
        dt.Columns.Add("deliveredon");
        dt.Columns.Add("comment");
        dt.Columns.Add("for_process");
        dt.Columns.Add("DestinationBranchID");
        dt.Columns.Add("FranchiseDiscount");

        if (Session["dt"].Equals(""))
            Session["dt"] = dt;
        else
            dt = (DataTable)Session["dt"];
        int count = 0;
        for (int i = 0; i < gvTestList.Rows.Count; i++)
        {

            if ((((CheckBox)gvTestList.Rows[i].Cells[3].FindControl("chkSelect"))).Checked)
            {
                string str_testid = gvTestList.DataKeys[i].Value.ToString();
                string str_classID = gvTestList.DataKeys[i].Values[1].ToString();
                int t_charges = 0;
                if (gvTestList.Columns[2].Visible == true)
                    t_charges = Convert.ToInt32(gvTestList.Rows[i].Cells[2].Text.Trim());
                else
                    t_charges = Convert.ToInt32(gvTestList.DataKeys[i].Values[4].ToString());

                foreach (DataRow dr2 in dt.Rows)
                {
                    if (str_testid.Equals(dr2["testid"].ToString()) && str_classID.Equals(dr2["classificationid"].ToString()))
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "This test " + dr2["testname"] + " is already added.";
                        return;
                    }
                }

                clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
                iv.TestID = str_testid;
                DataView dvMt = iv.GetAll(32);
                if (dvMt.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Method not found against " + gvTestList.Rows[i].Cells[1].Text.Trim() + "');</script>", false);
                    return;
                }


                DataRow dr = dt.NewRow();

                dr["testid"] = str_testid;
                dr["testname"] = gvTestList.Rows[i].Cells[1].Text.Trim().Replace("&quot;", "\"");
                dr["charges"] = t_charges.ToString();
                dr["classificationid"] = str_classID;
                dr["priority"] = rdbPriority.SelectedItem.Value.ToString();
                dr["comment"] = "";
                //gvTestList.DataKeys[i].Values[2].ToString();

                if (Convert.ToInt32(gvTestList.DataKeys[i].Values[3].ToString()) > 0)
                {
                    double dtMtd = Convert.ToDouble(gvTestList.DataKeys[i].Values[3].ToString());
                    DateTime dtNow = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
                    DateTime ts = dtNow.AddMinutes(dtMtd);
                    if (Session["BranchID"].ToString().Trim() != "")
                    {
                        if (gvTestList.DataKeys[i].Values[6].ToString().Trim() == "Y")
                        {
                            if (gvTestList.DataKeys[i].Values[8].ToString().Trim() == "H")
                            {
                                ts=ts.AddHours(Convert.ToInt32(gvTestList.DataKeys[i].Values[9].ToString()));
                            }
                            else if (gvTestList.DataKeys[i].Values[8].ToString().Trim() == "D")
                            {
                                ts=ts.AddDays(Convert.ToInt32(gvTestList.DataKeys[i].Values[9].ToString()));
                            }
                            else if (gvTestList.DataKeys[i].Values[8].ToString().Trim() == "W")
                            {
                                ts=ts.AddDays(7 * Convert.ToInt32(gvTestList.DataKeys[i].Values[9].ToString()));
                            }
                        }
                    }
                    dr["deliveredon"] = ts.ToString("dd/MM/yyyy HH:mm ");
                }
                else
                    dr["deliveredon"] = "~!@";

                dr["DestinationBranchID"] = gvTestList.DataKeys[i].Values[7].ToString();
                dr["FranchiseDiscount"] = gvTestList.DataKeys[i].Values[10].ToString().Trim();

                dt.Rows.Add(dr);


                lblcharges.Text = Convert.ToString(Convert.ToInt32(lblcharges.Text.Trim().Equals("") ? "0" : lblcharges.Text.Trim()) + t_charges);
                //txtCash.Text = lblcharges.Text.Trim();
                txtDiscount.Text = "";
                count++;
            }
        }
        if (count == 0)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "<b>No test selected</b>";
        }
        else
        {
            gvTestPick.DataSource = dt;
            gvTestPick.DataBind();
            Session["dt"] = dt;
            if (gvTestList.Columns[2].Visible == false)
                gvTestPick.Columns[2].Visible = false;
        }


        for (int j = 0; j < gvTestList.Rows.Count; j++)
        {
            if ((((CheckBox)gvTestList.Rows[j].Cells[3].FindControl("chkSelect"))).Checked)
            {
                (((CheckBox)gvTestList.Rows[j].Cells[3].FindControl("chkSelect"))).Checked = false;
            }
        }
    }
    protected void lbtnRemoveALL_Click(object sender, EventArgs e)
    {
        if (gvTestPick.Rows.Count > 0)
        {
            DataTable dt = (DataTable)Session["dt"];

            dt.Clear();
            Session["dt"] = "";
            gvTestPick.DataSource = dt;
            gvTestPick.DataBind();
            lblcharges.Text = "0";
            txtCash.Text = "0";
        }
    }
    protected void imgSearch_test_Click(object sender, ImageClickEventArgs e)
    {
        txtSpeed.Text = "";
        FillGvTest();
    }

    protected void lbtnAddALL_Click(object sender, EventArgs e)
    {
        for (int j = 0; j < gvTestList.Rows.Count; j++)
        {

            (((CheckBox)gvTestList.Rows[j].Cells[3].FindControl("chkSelect"))).Checked = true;
        }

        lbtnAdd_Click(sender, e);
    }
    protected void imgSpdKey_Click(object sender, ImageClickEventArgs e)
    {
        if (!txtSpeed.Text.Trim().Equals(""))
        {
            txtSearch_test.Text = "";
            FillGvTest();
        }
    }

    protected void gvGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

            if (Request.QueryString["panelid"].ToString().Trim() != "-1" || Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
                iv.PanelID = Request.QueryString["panelid"].ToString();

            iv.GroupID = gvGroup.DataKeys[e.Row.RowIndex].Value.ToString();
            DataView dv = iv.GetAll(24);

            string str = "";
            int count = 1;
            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    if (i == 0)
                        str = count + ":" + dv[i]["test_name"].ToString();
                    else
                        str += "{0}" + count + ":" + dv[i]["test_name"].ToString();
                    count++;
                }
            }
            else
            {
                str = "No Test Found";
            }

            //str = string.Format(str, Environment.NewLine);
            e.Row.Cells[1].ToolTip = string.Format(str, Environment.NewLine);

        }
    }
    protected void txtList_search_TextChanged(object sender, EventArgs e)
    {
        if (!Session["dtsearch"].Equals(""))
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("speedkey");
            dtt.Columns.Add("testname");
            dtt.Columns.Add("charges");


            if (Session["dtsearch"].Equals(""))
                Session["dtsearch"] = dtt;
            else
                dtt = (DataTable)Session["dtsearch"];

            DataView dv = new DataView(dtt);
            string SearchExpression = null;
            if (!String.IsNullOrEmpty(txtList_search.Text.Trim()))
            {
                SearchExpression = string.Format("{0} '%{1}%'",
                gvTestList.SortExpression, txtList_search.Text.Trim());


                dv.RowFilter = "testname like" + SearchExpression;
                if (dv.Count > 0)
                {
                    gvTestList.DataSource = dv;
                    gvTestList.DataBind();
                }
                else
                {
                    gvTestList.DataSource = null;
                    gvTestList.DataBind();
                }
            }
            else
            {
                gvTestList.DataSource = dv;
                gvTestList.DataBind();
            }

            ScriptManager1.SetFocus(txtList_search.ClientID);

            // txtName.Attributes.Add("onkeyup", "if(this.value != prevText) {" + Page.ClientScript.GetPostBackEventReference(txtName, "") + ";}");
            // txtName.Attributes.Add("onkeyup", "prevText = this.value");
        }
    }

    protected void chkOnCASH_CheckedChanged(object sender, EventArgs e)
    {
        if (chkOnCASH.Checked == true)
        {
            rdbMode.Visible = true;
            rdbMode.Items.FindByValue("C").Selected = true;
            txtDiscount.Enabled = true;
            txtDiscount.Text = "";
            txtCash.Visible = true;
            lblCash.Text = "Cash Received:";

        }
        else
        {
            rdbMode.Visible = false;
            chkOnCASH.Checked = false;
            txtDiscount.Enabled = false;
            txtDiscount.Text = "";
            txtCash.Visible = false;
            lblCash.Text = "";
        }
    }
    protected void rdbMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbMode.Items.FindByValue("C").Selected == true)
        {
            lblReferenceNo.Visible = false;
            txtReferenceNo.Visible = false;
            txtReferenceNo.Text = "";
        }
        else
        {
            lblReferenceNo.Visible = true;
            txtReferenceNo.Visible = true;
        }
    }
    protected void imgCmt_Close_Click(object sender, ImageClickEventArgs e)
    {
        this.txtInt_Comnt.Text = "";

        mde_intcmt.Hide();
    }
    protected void gvTestPick_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblTest_intCmt.Text = "Investigation: " + gvTestPick.Rows[index].Cells[1].Text.Trim();
            lblInt_Index.Text = index.ToString();
            txtInt_Comnt.Text = gvTestPick.DataKeys[index].Values[3].ToString();

            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
            SComponents com = new SComponents();
            iv.TestID = gvTestPick.DataKeys[index].Value.ToString();
            DataView dv = iv.GetAll(29);
            com.FillDropDownList(ddlFor_Process, dv, "name", "processid");

            ddlFor_Process.ClearSelection();

            try
            {

                ddlFor_Process.Items.FindByValue(gvTestPick.DataKeys[index].Values[4].ToString()).Selected = true;
            }
            catch { }
            //pnlInt_cmmnt.Visible = true;
            mde_intcmt.Show();
        }
    }

    protected void imgcmt_save_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = (DataTable)Session["dt"];

        int index = Convert.ToInt32(lblInt_Index.Text);

        DataRow dr = dt.Rows[Convert.ToInt32(lblInt_Index.Text)];
        dr["comment"] = txtInt_Comnt.Text.Trim();
        dr["for_process"] = ddlFor_Process.SelectedItem.Value.ToString();

        dt.AcceptChanges();
        gvTestPick.DataSource = dt;
        gvTestPick.DataBind();
        Session["dt"] = dt;

        txtInt_Comnt.Text = "";
        mde_intcmt.Hide();

    }
    protected void ddlPatientType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPatientType.SelectedItem.Value.ToString().Equals("O"))
            pnl_ward.Visible = false;
        else
        {
            if (Session["indoor_services"].ToString().Trim().Equals("Y"))
                pnl_ward.Visible = true;
            else
                pnl_ward.Visible = false;
        }
    }

    protected void gvTestPick_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     //   int index = Convert.ToInt32(e.Row.RowIndex);
       // Control container = e.Row;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            if (Convert.ToInt32((gvTestPick.DataKeys[e.Row.RowIndex].Values[7])) < Convert.ToInt32(hdsalesdiscount.Value))
            {
                hdsalesdiscount.Value = gvTestPick.DataKeys[e.Row.RowIndex].Values[7].ToString();
            }

            

        }

    }


    protected void gvTestList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Control container = e.Row;
        int index = e.Row.RowIndex;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (gvTestList.DataKeys[e.Row.RowIndex].Values[6].ToString().Trim() == "Y")
            {
                e.Row.BackColor = System.Drawing.Color.Aquamarine;
               // gvTestList.Rows[13].BackColor = System.Drawing.Color.Aquamarine;
                
            }

            if (Request.QueryString["panelid"].ToString().Trim() != "-1" && Session["BranchType"].ToString().Trim()=="F")
            {
                if (Convert.ToInt32(gvTestList.DataKeys[e.Row.RowIndex].Values[5]) - Convert.ToInt32(gvTestList.DataKeys[e.Row.RowIndex].Values[11]) <= 0)
                {
                    e.Row.Enabled = false;
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                }
            }
        }
    }



}
