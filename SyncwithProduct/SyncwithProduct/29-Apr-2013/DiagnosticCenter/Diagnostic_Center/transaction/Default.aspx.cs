﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.IO;
using BusinessLayer;
using AjaxControlToolkit;
using System.Text;
using System.Collections.Generic;
using Shared.WebControls;


public partial class transaction_Default : System.Web.UI.Page
{
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    ReportGridView r = new ReportGridView();
   
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            report.Delete_RecordResultView();
            report.Prid = Request.QueryString["prid"].ToString();
            report.Insert_RecordResultView();
            patientPrimaryInformation();
            patientBranchInfo();
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

        dv = new DataView();
        //clsBLPatientReg_Inv objPatient = new clsBLPatientReg_Inv();
        //objPatient.PRNO = Request.QueryString["prno"];
        //objPatient.LabID = Request.QueryString["labid"];
        report.Prno = Request.QueryString["prno"];
        report.Labid = Request.QueryString["labid"];
        dv = report.GetAll(2);
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        //if (dv[0]["type"].ToString().Trim() == "O")
        //{
        //    (Gv_PatientPrimaryInfo.Rows[0].Cells[1].FindControl("lblWardtxt") as Label).Visible = false;
        //    (Gv_PatientPrimaryInfo.Rows[0].Cells[1].FindControl("lblWard") as Label).Visible = false;
        //    (Gv_PatientPrimaryInfo.Rows[0].Cells[1].FindControl("lblBedtxt") as Label).Visible = false;
        //    (Gv_PatientPrimaryInfo.Rows[0].Cells[1].FindControl("lblBed") as Label).Visible = false;
        //}
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        report.Prno = Request.QueryString["prno"].ToString();
        report.Labid = Request.QueryString["labid"].ToString();
        report.TestId = Request.QueryString["testid"].ToString();
        report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
        dv = report.GetAll(13);
        int counting = dv.Count;
        //Lb_PrintCount.Text = "Total Prints: " + counting.ToString();


        Gv_GroupTest.DataSource = dv;
        Gv_GroupTest.DataBind();

        //for (int a = 0; a < dv.Count; a++)
        //{
        //    DataView dvrange = new DataView();
        //    report.TestId = dv[0]["testid"].ToString();
        //    dvrange = report.GetAll(26);
        //    if (dvrange.Count > 0)
        //    {
        //        for (int b = 0; b < dvrange.Count; b++)
        //        {
        //            (Gv_GroupTest.Rows[a].FindControl("Label2") as Label).Text += dvrange[b]["description"].ToString();
        //        }
        //    }
        //}
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Width = Unit.Percentage(25);
        e.Row.Cells[0].Font.Size = 8;

        e.Row.Cells[1].Width = Unit.Percentage(12);
        e.Row.Cells[1].Font.Size = 8;

        e.Row.Cells[2].Width = Unit.Percentage(8);
        e.Row.Cells[2].Font.Size = 8;

        try
        {
            e.Row.Cells[3].BackColor = Color.FromName("#EEEEEE");
            e.Row.Cells[3].BorderColor = Color.White;
            e.Row.Cells[3].BorderStyle = BorderStyle.Solid;
            e.Row.Cells[3].Font.Size = 8;
        }
        catch { }
        //e.Row.Cells[e.Row.Cells.Count-1].Visible = false;
       // e.Row.Cells[2].Font.Size = 8;
        string encoded = e.Row.Cells[2].Text;
        e.Row.Cells[2].Text = Context.Server.HtmlDecode(encoded);

        string encoded2 = e.Row.Cells[1].Text;
        e.Row.Cells[1].Text = Context.Server.HtmlDecode(encoded2);
        //e.Row.Cells[1].Width = 100;
    }

    protected void Gv_GroupTest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gv_GroupTest.PageIndex = e.NewPageIndex;
        patientPrimaryInformation();  
    }

    protected void Gv_GroupTest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int index = e.Row.RowIndex;
        if (index != -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            string bookingdid = Gv_GroupTest.DataKeys[index].Values[0].ToString();
            Lb_dateAll.Text = "";

            DataView dv1 = new DataView();
            report.Bookingdid = bookingdid;
            report.TestId = Gv_GroupTest.DataKeys[index].Values[1].ToString();
            report.Prid = Gv_GroupTest.DataKeys[index].Values[2].ToString();
            string dates1 = "";
            dv1 = report.GetAll(15);
            if (dv1.Count > 0)
            {
                for (int k = 0; k < dv1.Count; k++)
                {
                    string date = "MAX(IF(date_format(t.enteredon,'%Y-%m-%d %r') = '" + dv1[k]["enteredon"].ToString() + "', result, NULL)) AS '" + dv1[k]["headerName"].ToString() + "'";
                    //dates1 += "MAX(IF(date_format(t1.enteredon,'%Y-%m-%d %r') = '" + dv1[k]["enteredon"].ToString() + "', result, NULL)) AS '" + dv1[k]["headerName"].ToString() + "'"+",";
                    Lb_dateAll.Text += date + ",";
                }
                string getDates = Lb_dateAll.Text;
                report.ObjectDate = getDates.Remove(getDates.Length - 1);
                //report.ObjectDate1 = dates1.Remove(dates1.Length - 1);
                dv1 = report.GetAll(14);
                GridView gr;
                gr = (e.Row.FindControl("Gv_Attributes") as GridView);
                gr.DataSource = dv1;
                gr.DataBind();
            }

            DataView dv3 = new DataView();
            report.Bookingdid = bookingdid;
            dv3 = report.GetAll(12);

            GridView gr3;
            gr3 = (e.Row.FindControl("Gv_OpionionComments") as GridView);
            gr3.DataSource = dv3;
            gr3.DataBind();

            string test_range = Gv_GroupTest.DataKeys[index].Values[1].ToString();
            string test_auto = Gv_GroupTest.DataKeys[index].Values[3].ToString();
            //  for (int l = 0; l < dv.Count; l++)
            //  {
            if (test_auto != "")
            {
                report.TestId = test_range;
                DataView dvSee = new DataView();
                dvSee = report.GetAll(22);
                // GridView gr4;
                // gr4 = (e.Row.FindControl("Gv_SeeBelow") as GridView);
                // gr4.DataSource = dvSee;
                // gr4.DataBind();

                string autoText = dvSee[0]["autotext"].ToString();
                (e.Row.FindControl("Label1") as Label).Text = "<b><u>Interpretation:</u></b><br />" + autoText;
            }

            DataView dvrange = new DataView();
            report.TestId = Gv_GroupTest.DataKeys[index].Values[1].ToString();
            dvrange = report.GetAll(29);
            if (dvrange.Count > 0)
            {
                //(e.Row.FindControl("Label2") as Label).Text = "a";
                //(e.Row.FindControl("Gv_Attributes") as GridView).Row.F;
                //for (int x = 0; x < dvrange.Count; x++)
                //{
                //    ((e.Row.FindControl("Gv_Attributes") as GridView).Rows[x].FindControl("Label2") as Label).Text = dvrange[0]["description"].ToString();
                //}
                ListView gr4;
                gr4 = (e.Row.FindControl("ListView1") as ListView);
                gr4.DataSource = dvrange;
                gr4.DataBind();
            }
            // }
            //e.Row.Attributes["style"] = "page-break-after:always;";
        }
    }


    protected void Gv_GroupTest_DataBound(object sender, EventArgs e)
    {

       
    }



    public void patientBranchInfo()
    {
        if (Session["branchid"] != "")
        {
            patient.Branch_ID = Session["branchid"].ToString();
        }
        else
        {
            patient.Branch_ID = Request.QueryString["branchid"].ToString();
        }
        DataView dv = new DataView();
        dv = patient.GetAll(43);
        Lb_BranchNames.Text = dv[0]["branchName"].ToString();
        // Lb_branchAddress.Text = dv[0]["address"].ToString();
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
    protected void gv_PatientPrimaryInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.Cells[0].FindControl("lblWard") as Label).Text.Replace("-", "").Equals(""))
            {
                (e.Row.Cells[0].FindControl("lblWardtxt") as Label).Visible = false;
                (e.Row.Cells[0].FindControl("lblWard") as Label).Visible = false;
                (e.Row.Cells[0].FindControl("lblBedtxt") as Label).Visible = false;
                (e.Row.Cells[0].FindControl("lblBed") as Label).Visible = false;
            }
        }
    }
}