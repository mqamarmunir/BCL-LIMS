using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
public partial class transaction_wfrmpatientreceipttemp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (Request.QueryString["RequestCancelled"] == "N")
            {
                clsBLPatientReg_Inv obpatient = new clsBLPatientReg_Inv();
                obpatient.BookingID = Request.QueryString["bookingid"].ToString();
                DataView dv = obpatient.GetAll(52);
                double discountedamount = 0;
                if (dv.Count > 0)
                {
                    lbltotamount.Text = dv[0]["totalamount"].ToString().Trim();
                    for (int i = 0; i < dv.Count; i++)
                    {
                        discountedamount += Convert.ToDouble(dv[i]["testdiscountedprice"]);
                    }
                    lblDiscountedAmount.Text = discountedamount.ToString().Trim();
                    lblBalance.Text = discountedamount.ToString().Trim();
                    txtpaidamount.Text = "0";

                }
            }
            else
            {
                div1.Visible = false;
                div2.Visible = true;
            }

        }
    }
    protected void btngenerateReceipt_Click(object sender, EventArgs e)
    {
        clsBLPatientReg_Inv obpatient = new clsBLPatientReg_Inv();
        obpatient.BookingID = Request.QueryString["bookingid"].ToString();
        DataView dv =new DataView();
        dv= obpatient.GetAll(52);



        

        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

        iv.PRNO = dv[0]["prno"].ToString().Trim();
        iv.PRID = dv[0]["prid"].ToString();
        iv.SpecimenInternal = dv[0]["Specimen_Internal"].ToString();

        //iv.TotalAmount = this.lblcharges.Text.Trim();




        // string filename = Path.GetFileName(upldprescription.FileName);

       // iv.PanelID = Request.QueryString["panelid"].ToString().Trim().Replace("-1", "").Equals("") ? "~!@" : Request.QueryString["panelid"].ToString().Trim();

        if (dv[0]["doctorid"].ToString().Trim() != "")
            iv.DoctorID = dv[0]["doctorid"].ToString().Trim();
        else
            iv.ReferredBy = dv[0]["ReferredBY"].ToString().Trim();

        iv.Type = dv[0]["type"].ToString();
        //if (ddlPatientType.SelectedItem.Value.ToString().Equals("I"))
        //{
        //    iv.WardID = this.ddlWard.SelectedItem.Value.ToString();
        //    iv.Bed = this.txtBed.Text.Trim().Replace("'", "''");
        //    iv.Adm_Ref = this.txtAdm_Reference.Text.Trim().Replace("'", "''");
        //}
        //if (Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
        //{
        //    iv.Status = "P";
        //}
        //else
        //{
        //    iv.Status = "C";
        //}
        iv.Status = dv[0]["Status"].ToString().Trim();
        iv.DeliveryBy = dv[0]["deliveryby"].ToString();
        iv.ReferenceNo = dv[0]["referenceno"].ToString();//Request.QueryString["referenceno"].ToString().Replace(">>", "&").Replace("%%", "#");
        //if (txtDiscount.Text != "")
        //{
        //    iv.DiscountAll = txtDiscount.Text;
        //}
        //else
        //{
        //    iv.DiscountAll = "0";
        //}

        iv.DiscountAll = dv[0]["percentdiscountcash"].ToString().Trim();
        iv.OrgID = Session["orgid"].ToString().Trim();
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
        iv.Remarks = dv[0]["Remarks"].ToString().Trim();
        //Session["orgid"].ToString(); // org        


        string[,] str = new string[dv.Count, 12];
        int count = 0;
        int totalamount = 0;
        double cal_dis = 0;

        for (int i = 0; i < dv.Count; i++)
        {
            str[count, 0] = dv[i]["testid"].ToString(); // testid

            str[count, 1] = dv[i]["Classificationid"].ToString(); // classificationID
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

            str[count, 2] = dv[i]["testprice"].ToString().Trim(); // test amount  
            str[count, 3] = "0"; // discount as per test
            // }
            str[count, 4] = dv[i]["Priority"].ToString(); // priority

            iv.TestID = dv[i]["testid"].ToString(); // testid
            DataView dv_process = iv.GetAll(25);
            if (dv_process.Count == 0)
                str[count, 5] = "~!@";
            else
            {
                for (int m = 0; m < dv_process.Count; m++)
                {
                    if (!dv_process[m]["processid"].Equals("1") && !dv_process[m]["processid"].Equals("2"))
                    {
                        if (dv_process[m]["processid"].ToString().Trim().Equals("3") || dv_process[m]["processid"].ToString().Trim().Equals("4") || dv_process[m]["processid"].ToString().Trim().Equals("5") || dv_process[m]["processid"].ToString().Trim().Equals("6") || dv_process[m]["processid"].ToString().Trim().Equals("7"))
                        {
                            str[count, 5] = dv_process[m]["processid"].ToString().Trim();
                            break;
                        }
                    }
                }
            }
            str[count, 6] = ""; // comment internal
            str[count, 7] = "";// gvTestPick.DataKeys[i].Values[4].ToString().Trim().Equals("") ? "null" : gvTestPick.DataKeys[i].Values[4].ToString().Trim().Equals("-1") ? "null" : gvTestPick.DataKeys[i].Values[4].ToString(); // for process _ internal comment


            //if (gvTestPick.Columns[2].Visible == true)
            //{
            //    totalamount += Convert.ToInt32(gvTestPick.Rows[i].Cells[2].Text.Trim().ToString()); // test amount  
            //    str[count, 9] = "null";//when cash patient, put null into panel discount field
            //}
            //else
            //{
            //    totalamount += Convert.ToInt32(gvTestPick.DataKeys[i].Values[5].ToString());// test amount
            //    str[count, 9] = gvTestPick.DataKeys[i].Values["percentdiscountpanel"].ToString().Trim();//Further Discount Percentage to Panel patients
            //} 
            totalamount += Convert.ToInt32(dv[i]["testprice"]);
            //totalamount += Convert.ToInt32(gvTestPick.Rows[i].Cells[2].Text.Trim()); // calculating Total Amt
            str[count, 8] = dv[i]["DestinationBranchid"].ToString();//Destination Branchid
            //if (Request.QueryString["panelid"].ToString().Trim().Equals("-1") || chkOnCASH.Checked == true)
            //{
            //    str[count, 10] = ((TextBox)gvTestPick.Rows[i].Cells[4].FindControl("gvtxtdisc")).Text;//discount percentage agaisnt single test
            //    str[count, 11] = ((TextBox)gvTestPick.Rows[i].Cells[4].FindControl("gvtxtdiscamount")).Text;//discount adjusted amount
            //}
            //else
            //{
            //    str[count, 10] = "";//discount percentage agaisnt single test
            //    str[count, 11] = "";//discount adjusted amount
            //}
            str[count, 9] = "";
            str[count, 10] = dv[i]["percentdiscountcash"].ToString();
            str[count, 11] = dv[i]["testdiscountedprice"].ToString();
            count++;
        }


        iv.TotalAmount = totalamount.ToString();
        //!Request.QueryString["authorizeno"].ToString().Trim().Equals("~!@")
        //if (!Request.QueryString["panelid"].ToString().Trim().Equals("-1") && chkOnCASH.Checked == false && Request.QueryString["patienttype"].ToString().Trim().Equals("A"))
        //{
        //    iv.PaidAmount = "null";
        //    //txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim();
        //    //"null";
        //    iv.PaymentMode = "A";
        //    iv.AuthorizeNo = Request.QueryString["authorizeno"].ToString().Trim();
        //    iv.Patient_Type = Request.QueryString["patienttype"].ToString().Trim();
        //}
        //else
        //{
        //    //if (txtDiscount.Text.Trim().Equals(""))
        //    iv.PaidAmount = txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim();
        //    //else
        //    //    iv.PaidAmount =Convert.ToString(Convert.ToInt32(lblcharges.Text.Trim())- (Convert.ToInt32(lblcharges.Text.Trim()) * Convert.ToInt32(txtDiscount.Text.Trim()) / 100));
        //    //this.txtCash.Text.Trim().Equals("") ? "0" : txtCash.Text.Trim();
        //    iv.Patient_Type = Request.QueryString["patienttype"].ToString().Trim().Replace("A", "C");
        //    iv.PaymentMode = this.rdbMode.SelectedItem.Value.ToString();
        //    iv.Card_ReferenceNo = rdbMode.Items.FindByValue("C").Selected ? "~!@" : txtReferenceNo.Text.Trim();
        //    if (Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 0)
        //    {
        //        iv.Discount = CalCulateTotalDiscount();
        //        //iv.Discount = Convert.ToString((Convert.ToInt32(lblcharges.Text.Trim()) * Convert.ToInt32(txtDiscount.Text)) / 100);
        //        iv.RefundType = "D";
        //    }
        //    else
        //    {
        //        iv.Discount = "0";
        //    }
        //}

        iv.PaidAmount = txtpaidamount.Text.Trim();
        iv.Patient_Type = "C";
        iv.PaymentMode = dv[0]["payment_mode"].ToString().Trim();

        iv.Branch_ID = Session["BranchID"].ToString().Trim();
        iv.Sendstatus = "P";
        iv.Discount = (Convert.ToInt32(lbltotamount.Text.Trim()) - Convert.ToInt32(lblDiscountedAmount.Text.Trim())).ToString().Trim();
        iv.RefundType = "D";
        //iv.History_antobiotics = txtantihistory.Text.Trim();
        //if (!_uploadpath.Equals(""))
        //{
        //    iv.Prescription_document_path = _uploadpath.Replace("\\", @"\\\");
        //}

        //else
        //{
        //    iv.Prescription_document_path = hddocumentpath.Value.ToString();
        //}
        //iv.BookingID = Request.QueryString["bookingid"].ToString().Trim();
        //iv.Tempbookingstatus = "X";
        if (iv.Booking_Cash_Insert(str))
        {
            iv.BookingID = Request.QueryString["Bookingid"].ToString().Trim();
            if (iv.updatebookingtemp())
            {
                string labid = iv.LabID.ToString();
                string prno = dv[0]["prno"].ToString();
                string reference = "";// Request.QueryString["referenceno"].ToString();
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = true;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('wfrmCashReportLab.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + reference + "&cash=Y');</script>", false);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + reference + "&watermark=" + "&cash=Y');</script>", false);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirect", "<script>location.href = 'wfrmNewPatientReegistration.aspx';</script>", false);
              
            }
            //Response.Write("<script language='javascript'>window.open('wfrmCashReport.aspx');</script>");
        }
        else
        {

            string xyz = "";
            xyz = iv.Error;

            string abc = "";//xyz;
            //lblError.ForeColor = System.Drawing.Color.Red;
            //lblError.Text = iv.Error;
        }




    }

    protected void lnkgobacktopatreg_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmNewPatientReegistration.aspx");
    }
}