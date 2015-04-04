using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Globalization;

public partial class transaction_salesdetails_report : System.Web.UI.Page
{
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();

    protected void Page_Load(object sender, EventArgs e)
    {
        FillGV();
        patientPrimaryInformation();
        patientBranchInfo();
        calctotalcharges();
        Calculatetotals();
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

    public void patientPrimaryInformation()
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
            if (Session["footer"] != null)
            {
                // Img_footer.ImageUrl = Session["footer"].ToString();
            }
            else
            {
                // Img_footer.ImageUrl = "#";
            }
        }

        //dv = new DataView();
        //if (!Request.QueryString["admno"].ToString().Equals(""))
        //{
        //    report.ReferenceNo = Request.QueryString["admno"].ToString();
        //}
        //if (!Request.QueryString["prno"].ToString().Replace("___-__-________", "").Equals(""))
        //{
        //    report.Prno = Request.QueryString["prno"].ToString();

        //}
        // report.Labid = "10-006-00000002";
        //dv = report.GetAll(2);
        //if (dv.Count > 0)
        //{
        //    Gv_PatientPrimaryInfo.DataSource = dv;
        //    Gv_PatientPrimaryInfo.DataBind();
        //    Lb_PRNO.Text = dv[0]["prno"].ToString();
        //    Lb_Visit.Text = dv[0]["labid"].ToString();
        //}
        //else
        //{
        //    Gv_PatientPrimaryInfo.DataSource = null;
        //    Gv_PatientPrimaryInfo.DataBind();
        //    Lb_PRNO.Text = "";
        //    Lb_Visit.Text = "";
        //}
    }




    private void FillGV()
    {
        clsBLPatientReg_Inv obj_reginv = new clsBLPatientReg_Inv();
        if (!Request.QueryString["labid"].ToString().Equals(""))
        {
            obj_reginv.LabID = Request.QueryString["labid"].ToString();
        }
        else if (!Request.QueryString["prno"].ToString().Replace("___-__-________", "").Equals(""))
        {
            obj_reginv.PRNO = Request.QueryString["prno"].ToString();

        }
        else if (!Request.QueryString["branchid"].ToString().Replace("-1", "").Equals(""))
        {
            obj_reginv.Branch_ID = Request.QueryString["branchid"].ToString();

        }
        else if (!Request.QueryString["panelid"].ToString().Replace("-1", "").Equals(""))
        {
            obj_reginv.PanelID = Request.QueryString["panelid"].ToString();

        }
        obj_reginv.DateFrom = Request.QueryString["datefrom"].ToString().Trim();
        obj_reginv.DateTo = DateTime.Parse(Request.QueryString["dateto"].ToString().Trim(), new CultureInfo("ur-Pk", false)).AddDays(1).ToString("dd/MM/yyyy");
        DataView dv_pr = obj_reginv.GetAll(48);
        if (dv_pr.Count > 0)
        {
            gvMain.DataSource = dv_pr;
            gvMain.DataBind();
        }
        else
        {
            gvMain.DataSource = "";
            gvMain.DataBind();
        }
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvInvestigations = (GridView)e.Row.Cells[0].FindControl("gvInvestigations");
            clsBLPatientReg_Inv obj_reg = new clsBLPatientReg_Inv();
            obj_reg.BookingID = gvMain.DataKeys[e.Row.RowIndex].Values[0].ToString().Trim();
            DataView dv_investigations = obj_reg.GetAll(56);
            if (dv_investigations.Count > 0)
            {
                double branchshare = 0;
                gvInvestigations.DataSource = dv_investigations;
                gvInvestigations.DataBind();
                foreach (DataRow r in dv_investigations.Table.Rows)
                {
                    branchshare += Convert.ToDouble(r["BranchShare"].ToString());
                }
                Label lbl = e.Row.FindControl("lblbshare") as Label;
                lbl.Text = branchshare.ToString();
            }
          
            else
            {
                gvInvestigations.DataSource = "";
                gvInvestigations.DataBind();
            }
            clsReporting rep = new clsReporting();
            rep.Bookingdid = gvMain.DataKeys[e.Row.RowIndex].Values[0].ToString().Trim();
            DataView refund = rep.GetAll(28);
            double refundamt = 0;
            if (refund.Count > 0)
            {
                foreach (DataRow r in refund.Table.Rows)
                {
                    refundamt += Convert.ToDouble(r["paidamount"].ToString());
                }
                Label lbl = e.Row.FindControl("lblrefund") as Label;
                lbl.Text = refundamt.ToString();
            }
        }
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
        double refundpanel = 0;
        double totalbalancecash = 0;
        double totalbalancepanel = 0;
        double totalcashpanel = 0;

        double paidcashPanel = 0;
        double discountcashPanel = 0;
        double balancecashPanel = 0;
        double balancepanel = 0;
        double balancecash = 0;
        double refundcashpanel = 0;
        double prebalcash = 0;
        double prebalcashpanel = 0;
        double prebalpanel = 0;
        double bcashshare = 0;
        double bpcashshare = 0;
        double bpccashshare = 0;
        double cnetsales = 0;
        double cpnetsales = 0;
        double pnetsales = 0;
       

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            if ((gvMain.Rows[i].Cells[0].FindControl("lblPanel") as Label).Text.Trim().Length > 3)
            {
                if (gvMain.DataKeys[i].Values["cashpanel"].ToString().Trim() == "Y")
                {
                    totalcashpanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text.Trim());
                    try { discount += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text.Trim()); }
                    catch { discount += 0; }
                    try { bpccashshare += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbshare") as Label).Text.Trim()); }
                    catch { bpccashshare += 0; }
                         try { refundcashpanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblrefund") as Label).Text.Trim()); }
                    catch { refundcashpanel += 0; }
                         try { balancecashPanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text.Trim()); }
                         catch { balancecashPanel += 0; }
                }
                else
                {
                    total += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text.Trim());
                    try { bpcashshare += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbshare") as Label).Text.Trim()); }
                    catch { bpcashshare += 0; }
                    try { refundpanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblrefund") as Label).Text.Trim()); }
                    catch { refundpanel += 0; }
                    try { balancepanel += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text.Trim()); }
                    catch { balancepanel += 0; }

                }
            }
            else
            {
                totalcash += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text.Trim());
                try { discountcash += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text.Trim()); }
                catch { discountcash += 0; }
                try { bcashshare += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbshare") as Label).Text.Trim()); }
                catch { bcashshare += 0; }
                try { refundcash += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblrefund") as Label).Text.Trim()); }
                catch { refundcash += 0; }
                try { balancecash += Convert.ToDouble((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text.Trim()); }
                catch { balancecash += 0; }
                
            }
            
        }

       
        #region oldstructure summary
       // lbltotpaid.Text = paid.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotpaidcash.Text = paidcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotdisc.Text = discount.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotdisccash.Text = discountcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotcharges.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
      //  lblTotalchargescash.Text = totalcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        //lblTotalRefunds.Text = refund.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        //lblTotalRefundscash.Text = refundcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotbalcash.Text = (totalbalancecash - refund).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotbalpnl.Text = totalbalancepanel.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");


       // lblNetTotal.Text = (total + totalcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        #endregion
        #region New Table Structure for Totals
       // lbltotpaid0.Text = paid.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotpaidcash0.Text = paidcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotdisc0.Text = discount.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       //// lbltotdisccash0.Text = discountcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotcharges0.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lblTotalchargescash0.Text = totalcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lblTotalRefunds0.Text = refund.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lblTotalRefundscash0.Text = refundcash.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotbalcash0.Text = (totalbalancecash - refund).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lbltotbalpnl0.Text = totalbalancepanel.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

       // lblNetTotal0.Text = (total + totalcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lblDiscTot.Text = (discount + discountcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lblRefundsTot.Text = (refund + refundcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lblPaidTot.Text = (paid + paidcash).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
       // lblBalTotal.Text = (totalbalancecash + totalbalancepanel).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        #endregion

        #region "Calculate net Sales"

       // cash net sales
        cnetsales = totalcash - discountcash - refundcash - balancecash;
        // cash panel net sales
        cpnetsales = totalcashpanel - discount - refundcashpanel - balancecashPanel;
        // net sales for panel
        pnetsales = total - (refundpanel + balancepanel);
        bcashshare = Math.Round(bcashshare);
        bpcashshare = Math.Round(bpcashshare);
        bpccashshare = Math.Round(bpccashshare);

        #endregion

        #region newest

        lblGrossCash.Text = totalcash.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblGrossPanelCash.Text = totalcashpanel.ToString();//;"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblGrossPanel.Text = total.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblDisCash.Text = discountcash.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblDisPanCash.Text = discount.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblDisPanel.Text = "0";//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblCanCash.Text = refundcash.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblCanPanCash.Text = refundcashpanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblCanPanel.Text = refundpanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        //lblbalCash.Text = (totalbalancecash).ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        //lblBalPanCash.Text = balancecashPanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        //lblBalPanel.Text = totalbalancepanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        lblBShare.Text = bcashshare.ToString();
        lblBPShare.Text = bpcashshare.ToString();
        lblBPCShare.Text = bpccashshare.ToString();
        lblbalCash.Text = cnetsales.ToString();
        lblBalPanCash.Text = cpnetsales.ToString();
        lblBalPanel.Text = pnetsales.ToString();
       // lblCanCash.TabIndex = refundcash.ToString();

        //lblPreBalCash.Text = prebalcash.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        //lblPreBalPanCash.Text = prebalcashpanel.ToString();//"C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        //lblPreBalPanel.Text = "0";

        //lblNetCash.Text = (Convert.ToDouble(lblTotTodCash.Text) + Convert.ToDouble(lblPreBalCash.Text)).ToString();
        //lblNetPanCash.Text = (Convert.ToDouble(lblTotTodPanCash.Text) + Convert.ToDouble(lblPreBalPanCash.Text)).ToString();
        //lblNetPanel.Text = (Convert.ToDouble(lblTotTodPanel.Text) + Convert.ToDouble(lblPreBalPanel.Text)).ToString();
        #endregion


    }
    private void calctotalcharges()
    {
        int totalcharges = 0;
        int totalpaid = 0;
        int totaldisc = 0;
        //int totalbal = 0;
        int totbalance = 0;
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            try
            {
                totalcharges += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text);
                totalpaid += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text);
                totaldisc += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text);
                //totalpaid += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text);
            }
            catch { }
        }

        totbalance = totalcharges - totalpaid - totaldisc;
        lbltotcharges.Text = totalcharges.ToString();
        lbltotpaid.Text = totalpaid.ToString();
        lbltotdisc.Text = totaldisc.ToString();
        lbltotbal.Text = totbalance.ToString();
    }
}