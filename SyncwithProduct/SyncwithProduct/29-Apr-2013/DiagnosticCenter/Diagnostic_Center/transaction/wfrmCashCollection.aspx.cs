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

public partial class wfrmCashCollection : System.Web.UI.Page
{
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsCashPaid paid = new clsCashPaid();
    clsCashCollection collect = new clsCashCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            patientPrimaryInformation();
        }
    }

    public void patientPrimaryInformation()
    {
        DataView dv = new DataView();
        patient.PRNO = Session["prno"].ToString();
        patient.LabID = Session["labid"].ToString();
        dv = patient.GetAll(34);
        if (dv.Count > 0)
        {
            Gv_PatientPrimaryInfo.DataSource = dv;
            Gv_PatientPrimaryInfo.DataBind();

            TxBx_Prno.Text = dv[0]["prno"].ToString();
            TxBx_Visit.Text = dv[0]["labid"].ToString();

            patient.PRNO = Session["prno"].ToString();
            patient.LabID = Session["labid"].ToString();
        }

        dv = patient.GetAll(35);
        if (dv.Count > 0)
        {
            Gv_PatientReceipt.DataSource = dv;
            Gv_PatientReceipt.DataBind();
            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    (Gv_PatientReceipt.Rows[i].FindControl("Lbl_Serial") as Label).Text = i.ToString();
                }
            }
            patient.PRNO = Session["prno"].ToString();
            patient.LabID = Session["labid"].ToString();
        }

        dv = patient.GetAll(36);
        if (dv.Count > 0)
        {
            Gv_paymentModule.DataSource = dv;
            Gv_paymentModule.DataBind();

            int totalamount = Convert.ToInt32(dv[0]["totalamount"]);
            int totalpaid = Convert.ToInt32(dv[0]["totalpaid"]);
            int discount = Convert.ToInt32(dv[0]["discount_amt"]);

            int mybalance = totalamount - totalpaid - discount;

            if (mybalance == 0)
            {
                TxBx_PaidAmount.Enabled = false;
                Lb_AmoutOver.Text = "No remaining balance has been left.";
            }
            (Gv_paymentModule.Rows[0].FindControl("Lb_bal") as Label).Text = mybalance.ToString();


        }
    }


    protected void Btn_Paid_Click(object sender, ImageClickEventArgs e)
    {
        int totalamount = Convert.ToInt32((Gv_paymentModule.Rows[0].FindControl("Lb_totalAmount") as Label).Text);

        int totalpaid = Convert.ToInt32((Gv_paymentModule.Rows[0].FindControl("Lb_totalpaid") as Label).Text);
        int paidNow = Convert.ToInt32(TxBx_PaidAmount.Text);
        int totalNow = totalpaid + paidNow;
        int balanceNow = totalamount - totalNow;

        paid.Labid = TxBx_Visit.Text;
        paid.Paidamount = totalNow.ToString();
        paid.Balance = balanceNow.ToString();
        paid.Enteredby = "1";
        paid.Enteredon = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        if (paid.Update() == true)
        {
            paid.Labid = TxBx_Visit.Text;
            DataView dv = new DataView();
            dv = paid.GetAll(1);
            string bookingid = dv[0]["bookingid"].ToString();
            string prid = dv[0]["prid"].ToString();
            string paymentmode = dv[0]["payment_mode"].ToString();
            string panelid = dv[0]["panelid"].ToString();
            string clientid = dv[0]["clientid"].ToString();
            string discount = dv[0]["discount_amt"].ToString();
            //string totalAmount = dv[0]["totalamount"].ToString();

            //string reciveno=;
            collect.BookingID = bookingid;
            collect.PRID = prid;
            collect.PaymentMode = paymentmode;
            collect.ClientID = clientid;
            collect.Discount = discount;
            collect.LabID = TxBx_Visit.Text;
            collect.TotalAmount = totalamount.ToString();
            collect.PaidAmount = paidNow.ToString();
            collect.EnteredBy = "1";
            collect.EnteredOn = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            collect.Insert();
            Lb_Saved.Text = "Left amount has been paid successfully";
            patientPrimaryInformation();
        }
    }
}
