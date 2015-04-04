using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BusinessLayer;

public partial class transaction_rptCashClose : System.Web.UI.Page
{
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    clsDayCashCollection dayCash = new clsDayCashCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        CashPrimaryInformation();
        GvCashList();
        Lb_totalCash.Text = Calculatetotalcash("Cash").ToString();
        lbl_totalDebit.Text = Calculatetotalcash("Debit Card").ToString();
        lbl_totalCredit.Text = Calculatetotalcash("Credit Card").ToString();
        Lb_panelReceived.Text = CalculatetotalPanelCash("Cash").ToString();
        lbl_totalDebitPanel.Text = CalculatetotalPanelCash("Debit Card").ToString();
        lbl_totalCreditPanel.Text = CalculatetotalPanelCash("Credit Card").ToString();
        
        try
        {
            int netCash = Convert.ToInt32(Lb_totalCash.Text) + Convert.ToInt32(Lb_panelReceived.Text);
            Lb_CashNetRecieved.Text = netCash.ToString();
            Lb_OnCredit.Text = (Convert.ToInt32(lbl_totalCredit.Text.Trim()) + Convert.ToInt32(lbl_totalCreditPanel.Text.Trim())).ToString();
            Lb_Debit.Text = (Convert.ToInt32(lbl_totalDebit.Text.Trim()) + Convert.ToInt32(lbl_totalDebitPanel.Text.Trim())).ToString();
            Lb_OnNetRefund.Text = Lb_refundReceived.Text;
            int nettotal = Convert.ToInt32(Lb_CashNetRecieved.Text) + Convert.ToInt32(Lb_OnCredit.Text) + Convert.ToInt32(Lb_Debit.Text) - Convert.ToInt32(Lb_OnNetRefund.Text);
            Lb_NetAmount.Text = nettotal.ToString();
        }
        catch (Exception ee)
        {
            Response.Write(ee.Message);
        }
        lblTotbalance.Text = Calculatetotalbalance().ToString();
        GetCashClosingStatus();

    }

    #region Function of Day Cash List
    public void GvCashList()
    {
        DataView dv = new DataView();
        dv = dayCash.GetAll(12);

        Gv_DayCashList.DataSource = dv;
        Gv_DayCashList.DataBind();


        if (dv[0]["enteredon"] != "")
        {
            string EnteredOn = dv[0]["enteredon"].ToString();
            DateTime myEnteredOn = DateTime.Parse(EnteredOn);
            (Gv_DayCashList.Rows[0].FindControl("Lb_EnteredON") as Label).Text = myEnteredOn.ToString("MM-dd-yyyy hh:mm:ss tt");
        }
        if (dv[0]["enteredoff"] != "")
        {
            string EnteredOff = dv[0]["enteredoff"].ToString();
            DateTime myEnteredOff = DateTime.Parse(EnteredOff);
            (Gv_DayCashList.Rows[0].FindControl("Lb_EnteredOFF") as Label).Text = myEnteredOff.ToString("MM-dd-yyyy hh:mm:ss tt");
        }

        for (int i = 0; i < dv.Count; i++)
        {
            string ImgChecker = dv[i]["cashStatus"].ToString();
            if (ImgChecker == "Online")
            {
                (Gv_DayCashList.Rows[i].FindControl("Img_offline") as Image).Visible = false;
            }
            else
            {
                (Gv_DayCashList.Rows[i].FindControl("Img_online") as Image).Visible = false;
                int netsale = Convert.ToInt32(dv[i]["cashClosing_Amount"]) - Convert.ToInt32(dv[i]["cashOpening_Amount"]);
                (Gv_DayCashList.Rows[i].FindControl("Lb_NetSales") as Label).Text = netsale.ToString();
            }
        }


        DataView dv1 = new DataView();
        dayCash.Reportno = Request.QueryString["reportno"].ToString();
        dv1 = dayCash.GetAll(26);
        if (dv1.Count > 0)
        {
            Gv_OldReceiving.DataSource = dv1;
            Gv_OldReceiving.DataBind();
        }
        else
        {
            Lb_DuesReceived.Visible = false;
        }

    }
    #endregion


    public void CashPrimaryInformation()
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
                //Img_footer.ImageUrl = Session["footer"].ToString();
            }
            else
            {
                //Img_footer.ImageUrl = "#";
            }
        }

        dayCash.Reportno = Request.QueryString["reportno"].ToString();
        dv = dayCash.GetAll(3);
        Gv_CashPrimaryInfo.DataSource = dv;
        Gv_CashPrimaryInfo.DataBind();

        dayCash.Reportno = Request.QueryString["reportno"].ToString();

        dv = dayCash.GetAll(4);
        if (dv.Count > 0)
        {
           // Lb_totalCash.Text = dv[0]["totalcash"].ToString();
            Gv_PatientReceipt.DataSource = dv;
            Gv_PatientReceipt.DataBind();
            
        }
        else
        {
            Lb_totalCash.Text = "0";
        }

        dayCash.Reportno = Request.QueryString["reportno"].ToString();

        dv = dayCash.GetAll(5);
        if (dv.Count > 0)
        {
            //
            Gv_PanelPatient.DataSource = dv;
            Gv_PanelPatient.DataBind();
        }
        else
        {
            Lb_panelReceived.Text = "0";
        }
        dayCash.Reportno = Request.QueryString["reportno"].ToString();
        dv = dayCash.GetAll(6);
        if (dv.Count > 0)
        {
            Lb_refundReceived.Text = dv[0]["totalrefund"].ToString();
            Gv_RefundPatient.DataSource = dv;
            Gv_RefundPatient.DataBind();
        }
        else 
        {
            Lb_refundReceived.Text = "0";
        }
       
    }

    private int Calculatetotalcash(string cashtype)
    {
        int totalcash = 0;
        for (int i = 0; i < Gv_PatientReceipt.Rows.Count; i++)
        {
            if (Gv_PatientReceipt.Rows[i].Cells[10].Text.Trim().Contains(cashtype))
            {
                totalcash += Convert.ToInt32(Gv_PatientReceipt.Rows[i].Cells[5].Text.Trim());
            }
        }
        for (int j = 0; j < Gv_OldReceiving.Rows.Count; j++)
        {
            if (Gv_OldReceiving.Rows[j].Cells[6].Text.Trim().Contains(cashtype))
            {
                totalcash += Convert.ToInt32(Gv_OldReceiving.Rows[j].Cells[3].Text.Trim());
            }
        }
            return totalcash;
    }
    private int CalculatetotalPanelCash(string cashtype)
    {
        int totalcash = 0;
        for (int i = 0; i < Gv_PanelPatient.Rows.Count; i++)
        {
            if (Gv_PanelPatient.Rows[i].Cells[10].Text.Trim().Contains(cashtype))
            {
                totalcash += Convert.ToInt32(Gv_PanelPatient.Rows[i].Cells[5].Text.Trim());
            }
        }
        //for (int j = 0; j < Gv_OldReceiving.Rows.Count; j++)
        //{
        //    if (Gv_OldReceiving.Rows[j].Cells[6].Text.Trim().Contains(cashtype))
        //    {
        //        totalcash += Convert.ToInt32(Gv_OldReceiving.Rows[j].Cells[3].Text.Trim());
        //    }
        //}
        return totalcash;
    }
    private int Calculatetotalbalance()
    {
        int totalbalance = 0;
        for (int i = 0; i < Gv_PatientReceipt.Rows.Count; i++)
        {
            try
            {
                if (i > 0 && Gv_PatientReceipt.Rows[i].Cells[2].Text.Trim() != Gv_PatientReceipt.Rows[i - 1].Cells[2].Text.Trim())
                {
                    totalbalance += Convert.ToInt16(Gv_PatientReceipt.Rows[i].Cells[7].Text.Trim());
                }
                else if (i == 0)
                {
                    totalbalance += Convert.ToInt16(Gv_PatientReceipt.Rows[i].Cells[7].Text.Trim());
                }
                //totalbalance += Convert.ToInt32(Gv_PatientReceipt.Rows[i].Cells[4].Text.Trim()) - Convert.ToInt32(Gv_PatientReceipt.Rows[i].Cells[5].Text.Trim()) - Convert.ToInt32(Gv_PatientReceipt.Rows[i].Cells[6].Text.Trim());
            }
            catch
            {
                totalbalance += 0;
            }
        }

        return totalbalance;
    }
    private void GetCashClosingStatus()
    {
        if (Convert.ToInt32(Lb_NetAmount.Text.Trim()) - (Convert.ToInt32(Gv_DayCashList.Rows[0].Cells[2].Text.Trim()) - Convert.ToInt32(Gv_DayCashList.Rows[0].Cells[0].Text.Trim()))== 0)
        {
            lblExcessorshort.Text = "Balanced";
            lblExcessorshort.BackColor = System.Drawing.Color.Silver;
            lblExcessorshort.ForeColor = System.Drawing.Color.Green;
        }
        else if (Convert.ToInt32(Lb_NetAmount.Text.Trim()) - (Convert.ToInt32(Gv_DayCashList.Rows[0].Cells[2].Text.Trim()) - Convert.ToInt32(Gv_DayCashList.Rows[0].Cells[0].Text.Trim())) < 0)
        {
            lblExcessorshort.Text = "Short";
            lblExcessorshort.BackColor = System.Drawing.Color.Silver;
            lblExcessorshort.ForeColor = System.Drawing.Color.Red;
            
        }
        else if (Convert.ToInt32(Lb_NetAmount.Text.Trim()) - (Convert.ToInt32(Gv_DayCashList.Rows[0].Cells[2].Text.Trim()) - Convert.ToInt32(Gv_DayCashList.Rows[0].Cells[0].Text.Trim())) > 0)
        {
            lblExcessorshort.Text = "Excess";
            lblExcessorshort.BackColor = System.Drawing.Color.Silver;
            lblExcessorshort.ForeColor = System.Drawing.Color.Blue;
           
        }

    }
}