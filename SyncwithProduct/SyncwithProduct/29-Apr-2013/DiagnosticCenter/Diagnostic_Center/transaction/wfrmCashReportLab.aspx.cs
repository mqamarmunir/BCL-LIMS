﻿using System;
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

public partial class transaction_wfrmCashReportLab : System.Web.UI.Page
{
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        BranchName();
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        patientPrimaryInformation();
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

        // patient.PRNO = Session["prno"].ToString();
        // patient.LabID = Session["labid"].ToString();

        patient.PRNO = Request.QueryString["prno"].ToString();
        patient.LabID = Request.QueryString["labid"].ToString();


        try
        {
            if (Request.QueryString["watermark"].ToString() == "watermark")
            {
                watermark.Visible = true;
            }
        }
        catch
        {
            watermark.Visible = false;
        }

        dv = patient.GetAll(34);
        lb_remarks.Text = "Remarks : " + dv[0]["remarks"].ToString();


        string panelName = dv[0]["panelname"].ToString();
        Lb_EnteredBy.Text = dv[0]["receivedby"].ToString();
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        //patient.PRNO = Session["prno"].ToString();
        // patient.LabID = Session["labid"].ToString();
        patient.PRNO = Request.QueryString["prno"].ToString();
        patient.LabID = Request.QueryString["labid"].ToString();



        dv = patient.GetAll(35);
        string testID = "";
        Gv_PatientReceipt.DataSource = dv;
        Gv_PatientReceipt.DataBind();
        DataView dv_Coment = new DataView();
        if (dv.Count > 0)
        {
            for (int i = 0; i < dv.Count; i++)
            {
                (Gv_PatientReceipt.Rows[i].FindControl("Lbl_Serial") as Label).Text = i.ToString();
                testID += dv[i]["testid"].ToString() + ",";
                // patient.TestID = testID;      
                //for (int j = 1; j < dv_Coment.Count; j++)
                //{
                //    (Gv_TestComent.Rows[j].FindControl("Lb_testingName") as Label).Text = dv_Coment[i]["Test_Name"].ToString();
                //    (Gv_TestComent.Rows[j].FindControl("Lb_instructionBef") as Label).Text = dv_Coment[i]["Instructions_Before"].ToString();
                //    (Gv_TestComent.Rows[j].FindControl("Lb_instructionAft") as Label).Text = dv_Coment[i]["Instructions_After"].ToString();
                //}
            }



        }
        testID += "237460";
        patient.TestID = testID;
        dv_Coment = patient.GetAll(44);
        Gv_TestComent.DataSource = dv_Coment;
        Gv_TestComent.DataBind();

        patient.PRNO = Request.QueryString["prno"].ToString();
        patient.LabID = Request.QueryString["labid"].ToString();


        dv = patient.GetAll(36);
        Gv_paymentModule.DataSource = dv;
        Gv_paymentModule.DataBind();

        int totalamount = Convert.ToInt32(dv[0]["totalamount"]);
        int totalpaid = Convert.ToInt32(dv[0]["totalpaid"]);
        int discount = 0;
        try
        {
            discount = Convert.ToInt32(dv[0]["discount_amt"]);
        }
        catch
        {
            discount = 0;
        }
        int mybalance = totalamount - totalpaid - discount;
        (Gv_paymentModule.Rows[0].FindControl("Lb_bal") as Label).Text = mybalance.ToString();
        //Response.Write(mybalance);
        //Session.RemoveAll();

        if (discount == 0)
        {
            (Gv_paymentModule.Rows[0].FindControl("Lb_disc") as Label).Visible = false;
            (Gv_paymentModule.Rows[0].FindControl("lb_discValue") as Label).Visible = false;
        }


        if (panelName != "" && panelName != null)
        {
            if (Request.QueryString["cash"] == "N")
            {
                Gv_paymentModule.Visible = false;
                Gv_PatientReceipt.Columns[4].Visible = false;
            }
            else
            {
               
            }

            if (Request.QueryString["referenceno"] != null && Request.QueryString["referenceno"].ToString().Trim()!= "")
            {
                (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_refernces") as Label).Text = Request.QueryString["referenceno"].ToString();
            }
        }

        else
        {
            (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_employeeno") as Label).Visible = false;
            (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_serviceno") as Label).Visible = false;
           // (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_txreferences") as Label).Visible = false;
           // (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_refernces") as Label).Visible = false;
        }
    }


    public void BranchName()
    {

        DataView dv = new DataView();

        dv = patient.GetAll(45);
        string checkbranchOn = dv[0]["PrintBranches"].ToString();
        string checktestOn = dv[0]["PrintTestComents"].ToString();
        Gv_GeneralComent.DataSource = dv;
        Gv_GeneralComent.DataBind();

        if (checktestOn == "N")
        {
            field_test.Visible = false;
        }
        else
        {
            field_test.Visible = true;
        }


        if (checkbranchOn == "N")
        {
            field_branchList.Visible = false;
        }
        else
        {
            dv = patient.GetAll(42);
            Gv_BranchNames.DataSource = dv;
            Gv_BranchNames.DataBind();
        }
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
        Gv_BranchComent.DataSource = dv;
        Gv_BranchComent.DataBind();
    }
}