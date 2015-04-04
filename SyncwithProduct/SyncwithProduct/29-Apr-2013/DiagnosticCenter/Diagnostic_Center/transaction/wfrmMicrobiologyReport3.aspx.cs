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
using BusinessLayer;


public partial class wfrmMicrobiologyReport : System.Web.UI.Page
{
  

    static int rowCount;
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    string bid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            patientPrimaryInformation();
            patientBranchInfo();
            // Gv_GroupTest.AllowPaging = false; 
            string getDate = System.DateTime.Now.ToString("MMM dd,yyyy hh:mm:ss tt");

            Lb_TodayDate.Text = "Print On : " + getDate.ToString();

            checkranges();
            checkUnit();
          //  fillNewGrid();
        }
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
                //Img_footer.ImageUrl = "#";
            }
        }
        DataView fdv1 = new DataView();
        fdv1 = prefSetting.GetALL(2);
        if (fdv1.Count > 0)
        {
            if (fdv1[0]["Path_location"] != null)
            {
                Img_footer.ImageUrl = fdv1[0]["Path_location"].ToString();
            }
            else
            {
                Img_footer.Visible = false;
                Img_footer.ImageUrl = "#";
            }
        
        }
        dv = new DataView();
        report.Prno = Request.QueryString["prno"].ToString();
        report.Labid = Request.QueryString["labid"].ToString();

        dv = report.GetAll(5);
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        report.Prno = Request.QueryString["prno"].ToString();
        report.Labid = Request.QueryString["labid"].ToString();
        report.TestId = Request.QueryString["testid"].ToString();
        report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
        dv = report.GetAll(9);

        Gv_GroupTest.DataSource = dv;
        Gv_GroupTest.DataBind();

        if (dv.Count > 0)
        {
            string Organism1 = "";

            for (int i = 0; i < dv.Count; i++)
            {
                string bookingdid = dv[i]["bookingdid"].ToString();
                DataView dv1 = new DataView();
                //report.Bookingdid = bookingdid;
                //dv1 = report.GetAll(10);
                //GridView gr;
                //gr = (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView);
                //gr.DataSource = dv1;
                //gr.DataBind();
                report.Bookingdid = bookingdid;
                report.TestId = dv[i]["testid"].ToString();
                report.Prid = dv[i]["prid"].ToString();
                dv1 = report.GetAll(25);
                if (dv1.Count > 0)
                {
                    for (int k = 0; k < dv1.Count; k++)
                    {
                        string date = "MAX(IF(date_format(t.enteredon,'%Y-%m-%d %r') = '" + dv1[k]["enteredon"].ToString() + "', result, NULL)) AS '" + dv1[k]["headerName"].ToString() + "'";
                        // string result = dv1[k]["result"].ToString();
                        Lb_dateAll.Text += date + ",";
                        // Lb_ResultAll.Text += result;
                    }
                    string getDates = Lb_dateAll.Text;
                    //string resultAll = Lb_ResultAll.Text;

                    report.ObjectDate = getDates.Remove(getDates.Length - 1);

                    dv1 = report.GetAll(10);
                    GridView gr;
                    gr = (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView);
                    gr.DataSource = dv1;
                    gr.DataBind();

                    //int columnscount = gr.Columns.Count;
                    //if (dv1[0]["Unit"].ToString().Trim().Length == 0)

                    //{

                    //    (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Columns[2].Visible = false;
                    //}


                }


                //for (int j = 0; j < dv1.Count; j++)
                //{
                //    ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lbl_Serial") as Label).Text = j.ToString();
                //    string attrib = ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_attribname") as Label).Text.ToString();

                //    if (attrib == "Physical Examination" || attrib == "Microscopic Examination" || attrib == "Chemical Examination")
                //    {
                //        ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_attribname") as Label).Font.Bold = true;
                //    }

                //}
                #region depricated
                //DataView dv2 = new DataView();
                //report.Bookingdid = bookingdid;
                //dv2 = report.GetAll(11);
                //DataView dv_micro_sen = dv2;
                //DataView dv_micro_inter = dv2;
                //#region Sensitive Drugs
                //dv2.RowFilter = "Senstivity='R'";
                //if (dv2.Count > 0)
                //{
                //    if (dv2.Count > 25)
                //    {
                //        DataTable dt_s1 = SelectTopDataRow(dv2.ToTable(), 0, 25);
                //        DataTable dt_s2 = SelectTopDataRow(dv2.ToTable(), 25, dv2.Count <= 50 ? dv2.Count : 50);
                //        GridView grs1;
                //        grs1 = (Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView);
                //        grs1.DataSource = dt_s1;
                //        grs1.DataBind();
                //        GridView grs2;
                //        grs2 = (Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView);
                //        grs2.Visible = true;
                //        grs2.DataSource = dt_s2;
                //        grs2.DataBind();
                //        for (int k = 0; k < grs1.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }
                //        for (int k = 0; k < grs2.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("GridView_micro_resis2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("GridView_micro_resis2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("GridView_micro_resis2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }

                //    }
                //    else
                //    {
                //        //HtmlTableCell 
                //        HtmlTableCell tbcell = Gv_GroupTest.Rows[i].FindControl("td_mic_res") as HtmlTableCell;
                //        tbcell.Attributes.Add("style", "display:none");
                //        HtmlTableCell tbcell1 = Gv_GroupTest.Rows[i].FindControl("td_mic_res1") as HtmlTableCell;
                //        tbcell1.Attributes.Add("colspan", "2");
                //        GridView gr2;
                //        gr2 = (Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView);
                //        gr2.Width = new Unit("100%");
                //        gr2.DataSource = dv2;
                //        gr2.DataBind();
                //        for (int k = 0; k < gr2.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //   // (Gv_GroupTest.Rows[i].FindControl("Lb_HeadingMicro") as Label).Visible = false;
                //    (Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Visible = false;
                //    //(Gv_GroupTest.Rows[i].FindControl("Lb_Abbreviation") as Label).Visible = false;
                //}
                ////for (int k = 0; k < dv2.Count; k++)
                ////{
                ////    string Organism = ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                ////    if (Organism == Organism1)
                ////    {
                ////        ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                ////        // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                ////    }
                ////    else
                ////    {
                ////        Organism1 = ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                ////    }
                ////}
                //#endregion

                //#region Resistive
                //dv_micro_sen.RowFilter = "Senstivity='S'";

                ////dv_micro_sen.RowFilter = "RowNum<2";
                ////DataTable dt_x = new DataTable();
                ////dt_x = dv_micro_sen.Table.AsEnumerable().Take(1).CopyToDataTable<datarow>(dt_x,LoadOptions.None);
                //if (dv_micro_sen.Count > 0)
                //{
                //    //dv_micro_sen.Table = dv_micro_sen.Table.Rows.Cast<System.Data.DataRow>().Take(1).CopyToDataTable();
                //    if (dv_micro_sen.Count > 25)
                //    {
                //        DataTable dt_s1 = SelectTopDataRow(dv_micro_sen.ToTable(), 0, 25);
                //        DataTable dt_s2 = SelectTopDataRow(dv_micro_sen.ToTable(), 25, dv_micro_sen.Count <= 50 ? dv2.Count : 50);
                //        GridView grs1;
                //        grs1 = (Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen") as GridView);
                //        grs1.DataSource = dt_s1;
                //        grs1.DataBind();
                //        GridView grs2;
                //        grs2 = (Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen2") as GridView);
                //        grs2.Visible = true;
                //        grs2.DataSource = dt_s2;
                //        grs2.DataBind();
                //        for (int k = 0; k < grs1.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }
                //        for (int k = 0; k < grs2.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }

                //    }
                //    else
                //    {
                //        //HtmlTableCell 
                //        HtmlTableCell tbcell = Gv_GroupTest.Rows[i].FindControl("td_mic_sen") as HtmlTableCell;
                //        tbcell.Attributes.Add("style", "display:none");
                //        HtmlTableCell tbcell1 = Gv_GroupTest.Rows[i].FindControl("td_mic_sen1") as HtmlTableCell;
                //        tbcell1.Attributes.Add("colspan", "2");
                //        GridView gr2;
                //        gr2 = (Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen") as GridView);
                //        gr2.Width = new Unit("100%");
                //        gr2.DataSource = dv2;
                //        gr2.DataBind();
                //        for (int k = 0; k < gr2.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Sen") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //   // (Gv_GroupTest.Rows[i].FindControl("Lb_HeadingMicro") as Label).Visible = false;
                //    (Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Visible = false;
                //    //(Gv_GroupTest.Rows[i].FindControl("Lb_Abbreviation") as Label).Visible = false;

                //}

                //#endregion

                //#region Intermediate
                //dv_micro_inter.RowFilter = "Senstivity='I'";
                //if (dv_micro_inter.Count > 0)
                //{
                //    if (dv_micro_inter.Count > 25)
                //    {
                //        DataTable dt_s1 = SelectTopDataRow(dv_micro_inter.ToTable(), 0, 25);
                //        DataTable dt_s2 = SelectTopDataRow(dv_micro_inter.ToTable(), 25, dv_micro_inter.Count <= 50 ? dv2.Count : 50);
                //        GridView grs1;
                //        grs1 = (Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Inter") as GridView);
                //        grs1.DataSource = dt_s1;
                //        grs1.DataBind();
                //        GridView grs2;
                //        grs2 = (Gv_GroupTest.Rows[i].FindControl("GridView_Micro_Inter2") as GridView);
                //        grs2.Visible = true;
                //        grs2.DataSource = dt_s2;
                //        grs2.DataBind();
                //        for (int k = 0; k < grs1.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }
                //        for (int k = 0; k < grs2.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter2") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }

                //    }
                //    else
                //    {
                //        //HtmlTableCell 
                //        HtmlTableCell tbcell = Gv_GroupTest.Rows[i].FindControl("td_mic_int") as HtmlTableCell;
                //        tbcell.Attributes.Add("style", "display:none");
                //        HtmlTableCell tbcell1 = Gv_GroupTest.Rows[i].FindControl("td_mic_int1") as HtmlTableCell;
                //        tbcell1.Attributes.Add("colspan", "2");
                //        GridView gr2;
                //        gr2 = (Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView);
                //        gr2.Width = new Unit("100%");
                //        gr2.DataSource = dv2;
                //        gr2.DataBind();
                //        for (int k = 0; k < gr2.Rows.Count; k++)
                //        {
                //            string Organism = ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //            if (Organism == Organism1)
                //            {
                //                ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //                // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //            }
                //            else
                //            {
                //                Organism1 = ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    (Gv_GroupTest.Rows[i].FindControl("Lb_HeadingMicro") as Label).Visible = false;
                //    (Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Visible = false;
                //    //(Gv_GroupTest.Rows[i].FindControl("Lb_Abbreviation") as Label).Visible = false;
                //}
                //for (int k = 0; k < dv_micro_inter.Count; k++)
                //{
                //    string Organism = ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;

                //    if (Organism == Organism1)
                //    {
                //        ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                //        // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                //    }
                //    else
                //    {
                //        Organism1 = ((Gv_GroupTest.Rows[i].FindControl("GridViewmicro_Inter") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                //    }
                //}
                //#endregion
#endregion

                #region Aadil's code

                GridView organisums, Drugs;
                //Label lblantimicrobial = (Gv_GroupTest.Rows[i].FindControl("Label1") as Label);
                

                organisums = (Gv_GroupTest.Rows[i].FindControl("New_Grid") as GridView);
        report.Bookingdid = Request.QueryString["bookingdid"].ToString();
        DataView dvA = new DataView();
        dvA = report.GetAll(45);
        if (dvA.Count > 0)
        {
            organisums.DataSource = dvA;
            organisums.DataBind();
            Drugs = (Gv_GroupTest.Rows[i].FindControl("New_Grid2") as GridView);
            dvA = report.GetAll(42);
           
            DataTable DT = new DataTable();
            if (dvA.Table.Rows.Count > 0)
            {
                if (dvA.Table.Rows[0]["Drug"].ToString() != null && !dvA.Table.Rows[0]["Drug"].ToString().Equals(string.Empty))
                {
                    Drugs.DataSource = dvA;
                    DT = dvA.ToTable();
                    Drugs.Visible = true; }
            }
            else
            {
              
                Drugs.Visible = false;
            }
            rowCount = DT.Rows.Count;
            Drugs.DataBind();
            report.Organism = organisums.Rows[0].Cells[1].Text;
            organisums.Rows[0].Cells[0].Text = "A: &nbsp&nbsp ";

            try
            {
                organisums.Rows[1].Cells[0].Text = "B: &nbsp;&nbsp; ";
            }
            catch (Exception ee) { }

            try
            {
                organisums.Rows[2].Cells[0].Text = "C: &nbsp&nbsp ";
            }
            catch (Exception eee) { }



            GridView senstivity_grid;
            //  GridView tempGrid;
            //    tempGrid = (Gv_GroupTest.Rows[i].FindControl("TempGridView") as GridView);
            senstivity_grid = (Gv_GroupTest.Rows[0].FindControl("testGrid") as GridView);


            /////////Bindin Senstivity Grid///////////

            DataTable sensitivity_table = new DataTable();

            DataView view;
            DataRow row;

            ////// 1st column /////////

            sensitivity_table.Columns.Add("A");
            sensitivity_table.Columns.Add("B");
            sensitivity_table.Columns.Add("C");
            string drug;
            DataView dvT = new DataView();
            for (int a = 0; a < Drugs.Rows.Count; a++)
            {
                drug = Drugs.Rows[a].Cells[0].Text.ToString().Trim();

                row = sensitivity_table.NewRow();
                sensitivity_table.Rows.Add(row);
                report.Organism = organisums.Rows[0].Cells[1].Text;
                report.Drug = drug;
                try
                {


                    dvT = report.GetAll(44);
                    //if (dvT.Count == 0)
                    //    senstivity_grid.Visible = false;
                    //else
                    //    senstivity_grid.Visible = true;
                    TempGridView.DataSource = dvT;
                    TempGridView.DataBind();
                    row["A"] = TempGridView.Rows[0].Cells[0].Text.ToString().Trim();
                    // row["A"] = ",";
                }
                catch
                {
                    row["A"] = "-";
                }


                try
                {
                    ////// 2nd column /////////




                    report.Organism = organisums.Rows[1].Cells[1].Text;
                    report.Drug = drug;
                    dvT = report.GetAll(44);
                    TempGridView.DataSource = dvT;
                    TempGridView.DataBind();
                    row["B"] = TempGridView.Rows[0].Cells[0].Text.ToString().Trim();
                    //     row["B"] = "/";
                }
                catch (Exception exe)
                {
                    row["B"] = "-";
                }

                try
                {
                    ////// 3rd column /////////




                    report.Organism = organisums.Rows[2].Cells[1].Text;

                    report.Drug = drug;
                    dvT = report.GetAll(44);
                    TempGridView.DataSource = dvT;
                    TempGridView.DataBind();
                    row["C"] = TempGridView.Rows[0].Cells[0].Text.ToString().Trim();
                    //    row["C"] = "-";
                }
                catch (Exception exe)
                {
                    if (row.Table.Columns.Contains("C"))
                    {
                        row["C"] = "-";
                    }
                }

                // sensitivity_table.Rows.Add(row);
            }
            view = new DataView(sensitivity_table);

            //  senstivity_grid = new GridView();
            senstivity_grid.DataSource = view;
            senstivity_grid.DataBind();
            //  tempGrid.Visible = false;


        }
        else
        {
            organisums.Visible = false;
            Label1.Visible = false;
        }


       
      
       
             


                #endregion





        DataView dv3 = new DataView();
        report.Bookingdid = bookingdid;
        dv3 = report.GetAll(12);

        GridView gr3;
        gr3 = (Gv_GroupTest.Rows[i].FindControl("Gv_OpionionComments") as GridView);
        gr3.DataSource = dv3;
        gr3.DataBind();
}
}
}
    

    public DataTable SelectTopDataRow(DataTable dt, int start, int end)
    {
        DataTable dtn = dt.Clone();
        for (int i = start; i < end; i++)
        {
            dtn.ImportRow(dt.Rows[i]);
        }

        return dtn;
    }

    private void checkUnit()
    {
        try
        {
            GridView gv_atributes = (Gv_GroupTest.Rows[0].FindControl("Gv_Attributes") as GridView);
            int columnscount = (Gv_GroupTest.Rows[0].FindControl("Gv_Attributes") as GridView).HeaderRow.Cells.Count;

            int count = 0;
            for (int j = 0; j < gv_atributes.Rows.Count; j++)
            {
                if (gv_atributes.Rows[j].Cells[2].Text.Trim().Replace("-", "").Length > 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                gv_atributes.HeaderRow.Cells[2].Visible = false;
                for (int i = 0; i < gv_atributes.Rows.Count; i++)
                {
                    gv_atributes.Rows[i].Cells[2].Visible = false;
                }
            }
        }
        catch
        {
        }
    }


    private void checkranges()
    {
        try
        {
            GridView gv_atributes = (Gv_GroupTest.Rows[0].FindControl("Gv_Attributes") as GridView);
            int columnscount = (Gv_GroupTest.Rows[0].FindControl("Gv_Attributes") as GridView).HeaderRow.Cells.Count;

            int count = 0;
            for (int j = 0; j < gv_atributes.Rows.Count; j++)
            {
                if (gv_atributes.Rows[j].Cells[1].Text.Trim().Replace("-", "").Length > 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                gv_atributes.HeaderRow.Cells[1].Visible = false;
                for (int i = 0; i < gv_atributes.Rows.Count; i++)
                {
                    gv_atributes.Rows[i].Cells[1].Visible = false;
                }
            }
        }catch
        {
        }

    }

    protected void Gv_Attributes_DataBound(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[0].Text != "")
        {
            e.Row.Cells[0].Width = Unit.Percentage(25);
            e.Row.Cells[0].Font.Size = 8;

            string attrib = e.Row.Cells[0].Text;

            //if (attrib == "Physical Examination" || attrib == "Microscopic Examination" || attrib == "Chemical Examination")
            //{
            //    e.Row.Cells[0].Font.Bold = true;
            //}
            

        }
        e.Row.Cells[1].Width = Unit.Percentage(10);
        e.Row.Cells[1].Font.Size = 8;
        // e.Row.Cells[1].Text.ToString().Replace("(","").Replace(")","");



        e.Row.Cells[2].Width = Unit.Percentage(8);
        e.Row.Cells[2].Font.Size = 8;

        e.Row.Cells[3].BackColor = System.Drawing.Color.FromName("#EEEEEE");
        e.Row.Cells[3].BorderColor = System.Drawing.Color.White;
        e.Row.Cells[3].BorderStyle = BorderStyle.Solid;
        e.Row.Cells[3].Font.Size = 8;

        string me = e.Row.Cells[0].Text.ToString();


        // if (e.Row.RowType == DataControlRowType.DataRow)
        // {
        //  for (int j = 0; j < e.Row.Cells.Count; j++)
        //   {
        string encoded = e.Row.Cells[2].Text;
        e.Row.Cells[2].Text = Context.Server.HtmlDecode(encoded);
        e.Row.Cells[0].Text = Context.Server.HtmlDecode(e.Row.Cells[0].Text);
        //}
        // }


        // for (int j = 0; j < dv1.Count; j++)
        // {
        //   ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lbl_Serial") as Label).Text = j.ToString();
        //    string attrib = ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_attribname") as Label).Text.ToString();

        //    if (attrib == "Physical Examination" || attrib == "Microscopic Examination" || attrib == "Chemical Examination")
        //    {
        //        ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_attribname") as Label).Font.Bold = true;
        //    }

        // }
    }

   
   

    //private void Bind_Senstivity() {
    //    DataTable sensitivity_table = new DataTable();

    //    DataView view;
    //    DataRow row;
       
    //    ////// 1st column /////////
    
    //    sensitivity_table.Columns.Add("A");
    //    sensitivity_table.Columns.Add("B");
    //    sensitivity_table.Columns.Add("C");
    //    string drug;
    //    DataView dv = new DataView();
    //    for (int a = 0; a < New_Grid2.Rows.Count; a++)
    //    {
    //        drug = New_Grid2.Rows[a].Cells[0].Text.ToString().Trim();
   
    //        row = sensitivity_table.NewRow();
    //        sensitivity_table.Rows.Add(row);
    //        report.Organism = New_Grid.Rows[0].Cells[0].Text;
    //        report.Drug = drug;
    //        try
    //        {
                
    //            dv = report.GetAll(44);
    //            GridView1.DataSource = dv;
    //            GridView1.DataBind();
    //           row["A"] = GridView1.Rows[0].Cells[0].Text.ToString().Trim();
    //           // row["A"] = ",";
    //        }
    //        catch {
    //            row["A"] = "-";
    //        }


    //        try
    //        {
    //            ////// 2nd column /////////
               
               


    //            report.Organism = New_Grid.Rows[1].Cells[0].Text;
    //            report.Drug = drug;
    //            dv = report.GetAll(44);
    //            GridView1.DataSource = dv;
    //            GridView1.DataBind();
    //            row["B"] = GridView1.Rows[0].Cells[0].Text.ToString().Trim();
    //            //     row["B"] = "/";
    //        }
    //        catch (Exception exe)
    //        {
    //            row["B"] = "-";
    //        }

    //        try
    //        {
    //            ////// 3rd column /////////

              


    //            report.Organism = New_Grid.Rows[2].Cells[0].Text;
              
    //            report.Drug = drug;
    //            dv = report.GetAll(44);
    //            GridView1.DataSource = dv;
    //            GridView1.DataBind();
    //            row["C"] = GridView1.Rows[0].Cells[0].Text.ToString().Trim();
    //            //    row["C"] = "-";
    //        }
    //        catch (Exception exe)
    //        {
    //            if (row.Table.Columns.Contains("C"))
    //            {
    //                row["C"] = "-";
    //            }
    //        }

    //       // sensitivity_table.Rows.Add(row);
    //    }
    //    view = new DataView(sensitivity_table);
     
    //  //  senstivity_grid = new GridView();
    // //   senstivity_grid.DataSource = view;
    //  //  senstivity_grid.DataBind();
    // GridView1.Visible = false;
    //}

   
}
