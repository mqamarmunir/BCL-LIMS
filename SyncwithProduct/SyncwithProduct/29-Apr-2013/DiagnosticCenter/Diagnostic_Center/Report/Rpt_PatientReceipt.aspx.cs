using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

public partial class Report_Rpt_PatientReceipt : System.Web.UI.Page
{
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillImage();
            FillPatientInfo();
            FillMainGrid();
            setTotals();
            patientBranchInfo();
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

    public DataView GetInfo()
    {
        DataView dv=null;
        if (Session["selectionformula"] != null && !Session["selectionformula"].Equals(""))
        {
            clsBLMain mn = new clsBLMain();
            mn.ReceiveNo = Session["selectionformula"].ToString().Trim();
            dv = mn.GetAll(32);
            
        }
        return dv;
    }
    public void FillPatientInfo()
    {
        DataView dv = GetInfo();
        if (dv.Count > 0)
        {
            lblReferenceNo.Text = (dv[0]["referenceno"].ToString() != null && !dv[0]["referenceno"].ToString().Equals("")) ? dv[0]["referenceno"].ToString() : "Nil";
            lblPatientName.Text = dv[0]["patient"].ToString();
            lblAgeSex.Text = dv[0]["age"].ToString() + "/" + dv[0]["gender"].ToString();
            lblPasswordtext.Text = dv[0]["pasword"].ToString();
            lblPhoneNo.Text = (dv[0]["cellno"].ToString() != null && !dv[0]["cellno"].ToString().Equals(""))?  dv[0]["cellno"].ToString(): "Nil" ;
            lblwardname.Text = (dv[0]["ward"].ToString() != null && !dv[0]["ward"].ToString().Equals(""))? dv[0]["ward"].ToString():"Nil";
            lblRegistrationDate.Text = dv[0]["enteredon"].ToString();
            lblCollectedOn.Text = dv[0]["receivedon"].ToString();
            lblConsultantName.Text = (dv[0]["consultant"].ToString() != null && !dv[0]["consultant"].ToString().Equals(""))? dv[0]["consultant"].ToString(): "Nil";
            lblPanelname.Text = (dv[0]["panelname"].ToString() != null && !dv[0]["panelname"].ToString().Equals(""))? dv[0]["panelname"].ToString() :"Nil";

        }
    }
    public void FillMainGrid()
    {
        DataView dv = GetInfo();
        if (dv.Count > 0)
        {
            gvMain.DataSource = dv;
            gvMain.DataBind();

        }

    }

    public void setTotals()
    {
        DataView dv = GetInfo();
        if (dv.Count > 0)
        {
            #region "Set Calculating Properties"
            lbltotcharges.Text = dv[0]["totalamount"].ToString();
            lbltotpaid.Text = dv[0]["paidamount"].ToString();
            lbltotalpaid.Text = dv[0]["totalpaid"].ToString();
           
            int discountamt = (dv[0]["discount_amt"].ToString() != null) ? int.Parse(dv[0]["discount_amt"].ToString()) : 0;
            //int discountpage = discountamt * 100 / int.Parse(dv[0]["totalamount"].ToString());
            lbldiscount.Text = discountamt.ToString();
            int balance = int.Parse(dv[0]["totalamount"].ToString()) - (int.Parse(dv[0]["totalpaid"].ToString())+discountamt);
            lbltotbal.Text = balance.ToString();


            #endregion

            #region "Set Other Properties"
            Lb_PRNO.Visible = true;
            Lb_PRNO.Text = dv[0]["prno"].ToString();
            Lb_Visit.Visible = true;
            Lb_Visit.Text = dv[0]["labid"].ToString();
            Enteredby.Text = dv[0]["receivedby"].ToString();

            #endregion
        }
    }
    //public void setProperties()
    //{

    //}

}