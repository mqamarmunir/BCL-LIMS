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


public partial class transaction_wfrmCashRefundReport : System.Web.UI.Page
{
    clsCashRefund refund = new clsCashRefund();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            patientPrimaryInformation();
            BranchName();
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
                Img_footer.ImageUrl = Session["footer"].ToString();
            }
            else
            {
                Img_footer.ImageUrl = "#";
            }
        }

        string refunding = Request.QueryString["refundno"].ToString();
       // Response.Write(refunding);

        // patient.PRNO = Session["prno"].ToString();
        // patient.LabID = Session["labid"].ToString();

        //patient.PRNO = Request.QueryString["prno"].ToString();
        //patient.LabID = Request.QueryString["labid"].ToString();
        refund.RefundNo = refunding;
        dv = refund.GetAll(1);

       // string panelName = dv[0]["panelname"].ToString();
        Lb_EnteredBy.Text = dv[0]["receivedby"].ToString();
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        Lb_EnteredBy.Text = dv[0]["receivedby"].ToString();
        Lb_Authorized.Text = dv[0]["Authorizedby"].ToString();

        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        // patient.PRNO = Session["prno"].ToString();
        // patient.LabID = Session["labid"].ToString();
        // refund.PRNO = Request.QueryString["prno"].ToString();
        // refund.LabID = Request.QueryString["labid"].ToString();
        refund.RefundNo = refunding;

        dv = refund.GetAll(2);
        //string testID = "";
        Gv_PatientReceipt.DataSource = dv;
        Gv_PatientReceipt.DataBind();

        
        
        refund.RefundNo = refunding;
        dv = refund.GetAll(3);
        Lb_TotalDiscount.Text = dv[0]["refunded"].ToString();


        refund.PRNO = Request.QueryString["prno"].ToString();
        refund.LabID = Request.QueryString["labid"].ToString();
        //refund.RefundNo = refunding;
        dv = refund.GetAll(4);
        Gv_Receipt.DataSource = dv;
        Gv_Receipt.DataBind();

        if (Request.QueryString["discount"].ToString() == "0")
        {
            Gv_Receipt.Columns[4].Visible = false;
        }

    }


    public void BranchName()
    {

        DataView dv = new DataView();

        dv = patient.GetAll(45);
        string checkbranchOn = dv[0]["PrintBranches"].ToString();
        string checktestOn = dv[0]["PrintTestComents"].ToString();
       
        patient.Branch_ID = Session["branchid"].ToString();
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
}