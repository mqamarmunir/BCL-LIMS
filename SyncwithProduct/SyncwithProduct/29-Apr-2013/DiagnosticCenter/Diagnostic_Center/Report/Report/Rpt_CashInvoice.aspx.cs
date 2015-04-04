using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Globalization;

public partial class transaction_Rpt_CashInvoice : System.Web.UI.Page
{
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillImage();
            FIllPanelInformation();
            Fillgvmaster();
            FIllgvpreviousbookings();
            FIllgvRefunds_Master();
            patientBranchInfo();
            Calculatetotals();
            //FillPanelDetails();
        }
    }

    public void FillImage()
    {
        

        DataView dv = new DataView();
        dv = prefSetting.GetALL(1);
        if (dv.Count > 0)
        {
            if (dv[0]["Path_location"].ToString() != null)
            {
                Img_header.Visible = true;
                Img_header.ImageUrl = dv[0]["Path_location"].ToString();
            }
            else
            {
                Img_header.ImageUrl = "#";
            }
           
        }
    }
    private void FIllgvpreviousbookings()
    {
        clsReporting obj_reporting = new clsReporting();
        if (Request.QueryString["branchid"] != "-1")
        {
            obj_reporting.BranchID = Request.QueryString["BranchID"].ToString().Trim();

        }
        if (Request.QueryString["PanelId"] != "-1")
        {
            obj_reporting.PanelID = Request.QueryString["PanelId"].ToString().Trim();
        }
        if (Request.QueryString["Consultant"] != "-1")
        {
            obj_reporting.ConsultantID = Request.QueryString["Consultant"].ToString().Trim();
        }
        if (Request.QueryString["type"] != "A")
        {
            obj_reporting.Type = Request.QueryString["Type"].ToString().Trim();
        }
        obj_reporting.Datefrom = Request.QueryString["datefrom"].ToString().Trim();
        obj_reporting.Dateto = DateTime.Parse(Request.QueryString["dateto"].ToString().Trim(), new CultureInfo("ur-pk", false)).AddDays(1).ToString("dd/MM/yyyy");
        DataView dv = obj_reporting.GetAll(41);
        if (dv.Count > 0)
        {
            gvMain_2.DataSource = dv;
            gvMain_2.DataBind();
        }
        else
        {
            gvMain_2.DataSource = "";
            gvMain_2.DataBind();
        }
    }

    public void patientBranchInfo()
    {
        patient.Branch_ID = Session["branchid"].ToString();
        DataView dv = new DataView();
        dv = patient.GetAll(43);
        Lb_BranchNames.Text = dv[0]["branchName"].ToString();
        //Lb_branchAddress.Text = dv[0]["address"].ToString();
        string _24hrs = dv[0]["24HrsService"].ToString();

        if (_24hrs == "Y")
        {
            Lb_starttime.Text = "24 Hrs";
            Lb_endtime.Visible = false;
            lb_phonebranchmain.Text = dv[0]["phone"].ToString();
        }
        else
        {
            Lb_starttime.Text = dv[0]["starttimes"].ToString();
            Lb_endtime.Text = dv[0]["endtimes"].ToString();
            lb_phonebranchmain.Text = dv[0]["phone"].ToString();
            Lb_Extension.Text = dv[0]["Ext"].ToString();
        }

    }

    private void FIllPanelInformation()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PanelName");
        dt.Columns.Add("Consultant");
        dt.Columns.Add("DateRange");
        dt.Columns.Add("PrintedOn");
        dt.Columns.Add("BranchName");

        DataRow dr = dt.NewRow();

        if (Request.QueryString["panelid"] == "-1")
        {
            dr["PanelName"] = "All";
        }
        else
        {
            clsBLPanel obj_Panel = new clsBLPanel();
            obj_Panel.PanelID = Request.QueryString["panelid"].ToString().Trim();
            DataView dv_panel = obj_Panel.GetAll(9);
            dr["PanelName"] = dv_panel[0]["Name"].ToString().Trim();
            dv_panel.Dispose();
            obj_Panel = null;
        }
        if (Request.QueryString["consultant"] == "-1")
        {
            dr["Consultant"] = "All";
        }
        else
        {
            clsBLRefDoctor obj_con = new clsBLRefDoctor();
            obj_con.DoctorID = Request.QueryString["Consultant"].ToString().Trim();
            DataView dv_consultant = obj_con.GetAll(10);
            dr["Consultant"] = dv_consultant[0]["Name"].ToString().Trim();
            dv_consultant.Dispose();
            obj_con = null;
        }
        if (Request.QueryString["branchid"] == "-1")
        {
            dr["BranchName"] = "All";
        }
        else
        {
            clsBLBranch obj_Branch= new clsBLBranch();
            obj_Branch.BranchID = Request.QueryString["BranchID"].ToString().Trim();
            DataView dv_branch = obj_Branch.GetAll(2);
            dr["branchname"] = dv_branch[0]["Name"].ToString().Trim();
            dv_branch.Dispose();
            obj_Branch = null;
        }
        dr["DateRange"] = Request.QueryString["datefrom"]+"--"+Request.QueryString["dateto"];
        dr["PrintedOn"] = System.DateTime.Now.ToString("dd-MM-yyyy").ToString();
        //dr["BranchName"] = "All";
        dt.Rows.Add(dr);
        
        Gv_PatientPrimaryInfo.DataSource = dt;
        Gv_PatientPrimaryInfo.DataBind();
        dt.Dispose();


    }
    private void Fillgvmaster()
    {
        clsReporting obj_reporting = new clsReporting();
        if (Request.QueryString["branchid"] != "-1")
        {
            obj_reporting.BranchID = Request.QueryString["BranchID"].ToString().Trim();

        }
        if (Request.QueryString["PanelId"] != "-1")
        {
            obj_reporting.PanelID = Request.QueryString["PanelId"].ToString().Trim();
        }
        if (Request.QueryString["Consultant"] != "-1")
        {
            obj_reporting.ConsultantID = Request.QueryString["Consultant"].ToString().Trim();
        }
        if (Request.QueryString["type"] != "A")
        {
            obj_reporting.Type = Request.QueryString["Type"].ToString().Trim();
        }
        obj_reporting.Datefrom = Request.QueryString["datefrom"].ToString().Trim();
        obj_reporting.Dateto = DateTime.Parse(Request.QueryString["dateto"].ToString().Trim(),new CultureInfo("ur-pk",false)).AddDays(1).ToString("dd/MM/yyyy");
        DataView dv = obj_reporting.GetAll(26);
        if (dv.Count > 0)
        {
            gvMain.DataSource = dv;
            gvMain.DataBind();
        }
        else
        {
            gvMain.DataSource = "";
            gvMain.DataBind();
        }
    }
    private void FIllgvRefunds_Master()
    {
        clsReporting obj_reporting = new clsReporting();
        if (Request.QueryString["branchid"] != "-1")
        {
            obj_reporting.BranchID = Request.QueryString["BranchID"].ToString().Trim();

        }
        if (Request.QueryString["PanelId"] != "-1")
        {
            obj_reporting.PanelID = Request.QueryString["PanelId"].ToString().Trim();
        }
        if (Request.QueryString["Consultant"] != "-1")
        {
            obj_reporting.ConsultantID = Request.QueryString["Consultant"].ToString().Trim();
        }

        if (Request.QueryString["type"] != "A")
        {
            obj_reporting.Type = Request.QueryString["Type"].ToString().Trim();
        }
        obj_reporting.Datefrom = Request.QueryString["datefrom"].ToString().Trim();
        obj_reporting.Dateto = DateTime.Parse(Request.QueryString["dateto"].ToString().Trim(), new CultureInfo("ur-pk", false)).AddDays(1).ToString("dd/MM/yyyy");

        DataView dv = obj_reporting.GetAll(27);
        if (dv.Count > 0)
        {
            ReportGridView1.DataSource = dv;
            ReportGridView1.DataBind();
        }
        else
        {
            ReportGridView1.DataSource = "";
            ReportGridView1.DataBind();
        } 
    }
    protected void ReportGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvRefundDetail = (GridView)e.Row.Cells[0].FindControl("gvrefunddetail");
            gvRefundDetail.DataSource = FillgvRefundDetail(ReportGridView1.DataKeys[e.Row.RowIndex].Value.ToString().Trim());
            gvRefundDetail.DataBind();
        }
    }
    private DataView FillgvRefundDetail(string bookingid)
    {
        clsReporting obj_reporting = new clsReporting();
        obj_reporting.Bookingdid = bookingid;
        DataView dv = obj_reporting.GetAll(28);
        return dv;

    }

    private void Calculatetotals()
    {
        double total = 0;
        double totalcash = 0;
        double paid = 0;
        double paidcash = 0;
        double discount = 0;
        double discountcash = 0;
        double refund = 0;
        double refundcash = 0;
        double totalbalancecash = 0;
        double totalbalancepanel = 0;
        double totalcashpanel = 0;

        double paidcashPanel = 0;
        double discountcashPanel = 0;
        double balancecashPanel = 0;
        double refundcashpanel = 0;
        double prebalcash = 0;
        double prebalcashpanel = 0;
        double prebalpanel = 0;

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if ((gvMain.Rows[i].Cells[0].FindControl("lblPanel") as Label).Text.Trim().Length > 3)
            {
                if (gvMain.DataKeys[i].Values["PanelCash"].ToString().Trim() == "Y")
                {
                    totalcashpanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text.Trim());
                }
                else
                {
                    total += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text.Trim());
                }
            }
            else
            {
                totalcash += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text.Trim());
            }
            if ((gvMain.Rows[i].Cells[0].FindControl("lblPanel") as Label).Text.Trim().Length > 3)
            {
                if (gvMain.DataKeys[i].Values["PanelCash"].ToString().Trim() == "Y")
                {
                    paidcashPanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text.Trim());
                }
                else
                {
                    paid += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text.Trim());
                }
            }
            else
            {
                paidcash += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text.Trim());
            }
            if ((gvMain.Rows[i].Cells[0].FindControl("lblPanel") as Label).Text.Trim().Length > 3)
            {
                if (gvMain.DataKeys[i].Values["PanelCash"].ToString().Trim() == "Y")
                {
                    discountcashPanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text.Trim());
                }
                else
                {
                    discount += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text.Trim());
                }
            }
            else
            {
                discountcash += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text.Trim());
            }
            //total += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text.Trim());
            //paid += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text.Trim());
            //discount += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text.Trim());
            if ((gvMain.Rows[i].Cells[0].FindControl("lblPanel") as Label).Text.Trim().Length > 3)
            {
                if (gvMain.DataKeys[i].Values["PanelCash"].ToString().Trim() == "Y")
                {
                    balancecashPanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text.Trim());
                }
                else
                {
                    totalbalancepanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text.Trim());
                }
            }
            else
            {
                totalbalancecash += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text.Trim());
            }
        }

        for(int i=0; i<ReportGridView1.Rows.Count;i++)
        {
            GridView gvdetailrefund=ReportGridView1.Rows[i].Cells[0].FindControl("gvrefunddetail") as GridView;
            for (int j = 0; j < gvdetailrefund.Rows.Count; j++)
            {
                if (gvdetailrefund.DataKeys[j].Values[0].ToString().Trim() != "0")
                {
                    if (gvdetailrefund.DataKeys[j].Values["panelcash"].ToString().Trim() == "Y")
                    {
                        refundcashpanel += Convert.ToDouble(gvdetailrefund.Rows[j].Cells[2].Text.Trim());
                    }
                    else
                    {
                        refund += Convert.ToDouble(gvdetailrefund.Rows[j].Cells[2].Text.Trim());
                    }
                }
                else
                {
                    refundcash += Convert.ToDouble(gvdetailrefund.Rows[j].Cells[2].Text.Trim());
                }

            }
            gvdetailrefund.Dispose();
        }
        for (int i = 0; i < gvMain_2.Rows.Count; i++)
        {
            if ((gvMain_2.Rows[i].Cells[0].FindControl("lblPanel") as Label).Text.Trim().Length > 3)
            {
                if (gvMain_2.DataKeys[i].Values["panelcash"].ToString().Trim() == "Y")
                {
                    prebalcashpanel += Convert.ToDouble((gvMain_2.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text.Trim());
                }
                else
                {
                    prebalpanel += Convert.ToDouble((gvMain_2.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text.Trim());
                }
            }
            else
            {
                prebalcash += Convert.ToDouble((gvMain_2.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text.Trim());
            }
           // paid += Convert.ToDouble((gvMain_2.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text.Trim());
        }
        #region oldstructure summary
        lbltotpaid.Text = paid.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotpaidcash.Text = paidcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotdisc.Text = discount.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotdisccash.Text = discountcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotcharges.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTotalchargescash.Text = totalcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTotalRefunds.Text = refund.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTotalRefundscash.Text = refundcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotbalcash.Text = (totalbalancecash - refund).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotbalpnl.Text = totalbalancepanel.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");


        lblNetTotal.Text = (total + totalcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        #endregion
        #region New Table Structure for Totals
        lbltotpaid0.Text = paid.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotpaidcash0.Text = paidcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotdisc0.Text = discount.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotdisccash0.Text = discountcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotcharges0.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTotalchargescash0.Text = totalcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTotalRefunds0.Text = refund.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTotalRefundscash0.Text = refundcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotbalcash0.Text = (totalbalancecash - refund).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lbltotbalpnl0.Text = totalbalancepanel.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblNetTotal0.Text = (total + totalcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblDiscTot.Text = (discount + discountcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblRefundsTot.Text = (refund + refundcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblPaidTot.Text = (paid + paidcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblBalTotal.Text = (totalbalancecash + totalbalancepanel).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        #endregion

        #region newest

        lblGrossCash.Text = totalcash.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblGrossPanelCash.Text = totalcashpanel.ToString();//;"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblGrossPanel.Text = total.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblDisCash.Text = discountcash.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblDisPanCash.Text = discountcashPanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblDisPanel.Text = discount.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblCanCash.Text = refundcash.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblCanPanCash.Text = refundcashpanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblCanPanel.Text = refund.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblbalCash.Text = (totalbalancecash).ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblBalPanCash.Text = balancecashPanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblBalPanel.Text = (Convert.ToDouble(lblGrossPanel.Text) - Convert.ToDouble(lblCanPanel.Text)).ToString();     // totalbalancepanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblTotTodCash.Text = (Convert.ToDouble(lblGrossCash.Text) - Convert.ToDouble(lblDisCash.Text) - Convert.ToDouble(lblCanCash.Text) - Convert.ToDouble(lblbalCash.Text)).ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTotTodPanCash.Text = (Convert.ToDouble(lblGrossPanelCash.Text) - Convert.ToDouble(lblDisPanCash.Text) - Convert.ToDouble(lblCanPanCash.Text) - Convert.ToDouble(lblBalPanCash.Text)).ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTotTodPanel.Text = "0"; //(Convert.ToDouble(lblGrossPanel.Text) - Convert.ToDouble(lblDisPanel.Text) - Convert.ToDouble(lblCanPanel.Text) - Convert.ToDouble(lblBalPanel.Text)).ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblPreBalCash.Text = prebalcash.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblPreBalPanCash.Text = prebalcashpanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblPreBalPanel.Text = "0";

        lblNetCash.Text = (Convert.ToDouble(lblTotTodCash.Text) + Convert.ToDouble(lblPreBalCash.Text)).ToString();
        lblNetPanCash.Text = (Convert.ToDouble(lblTotTodPanCash.Text) + Convert.ToDouble(lblPreBalPanCash.Text)).ToString();
        lblNetPanel.Text = "0";//(Convert.ToDouble(lblTotTodPanel.Text) + Convert.ToDouble(lblPreBalPanel.Text)).ToString();
        #endregion


    }
    private void FillPanelDetails()
    {
        clsReporting objReport = new clsReporting();
        if (Request.QueryString["branchid"] != "-1")
        {
            objReport.BranchID = Request.QueryString["BranchID"].ToString().Trim();

        }
        if (Request.QueryString["PanelId"] != "-1")
        {
            objReport.PanelID = Request.QueryString["PanelId"].ToString().Trim();
        }
        objReport.Datefrom = Request.QueryString["datefrom"].ToString().Trim();
        objReport.Dateto = DateTime.Parse(Request.QueryString["dateto"].ToString().Trim(), new CultureInfo("ur-pk", false)).AddDays(1).ToString("dd/MM/yyyy");
        DataView dv = objReport.GetAll(37);
        DataView dvA = dv;
        
        DataView dvB = dv;
        dvA.RowFilter = "PanelCash='Y'";
        
        CashPanelDetails.DataSource = dvA;
        CashPanelDetails.DataBind();
        dvB.RowFilter = "PanelCash='N'";
        gvCreditPanelDetails.DataSource = dvB;
        gvCreditPanelDetails.DataBind();

    }
    protected void CashPanelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblBalance = e.Row.FindControl("lblbalance") as Label;
            Label lblPATB = e.Row.FindControl("lblPaidAmountTB") as Label;
            lblPATB.Text = (Convert.ToDouble((e.Row.FindControl("lblPaidAmountTB") as Label).Text) - Convert.ToDouble((e.Row.FindControl("lblRefund") as Label).Text)).ToString();
            lblBalance.Text = (Convert.ToDouble((e.Row.FindControl("lblAmount") as Label).Text) - Convert.ToDouble((e.Row.FindControl("lblDiscount") as Label).Text) - Convert.ToDouble((e.Row.FindControl("lblPaidAmountTB") as Label).Text) - Convert.ToDouble((e.Row.FindControl("lblRefund") as Label).Text)).ToString();
        }
    }

    protected void gvCreditPanelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblBalance = e.Row.FindControl("lblNetSale") as Label;
            lblBalance.Text = (Convert.ToDouble((e.Row.FindControl("lblAmount") as Label).Text) - Convert.ToDouble((e.Row.FindControl("lblRefund") as Label).Text) ).ToString();
        }
    }
}