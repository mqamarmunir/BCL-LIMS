using System;
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

public partial class transaction_RptGeneralReport : System.Web.UI.Page
{
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {

            report.Delete_RecordResultView();
            report.Prid = Request.QueryString["prid"].ToString();
            report.Insert_RecordResultView();

            patientPrimaryInformation();
            patientBranchInfo();
            string getDate = System.DateTime.Now.ToString("MMM dd,yyyy hh:mm:ss tt");
            Lb_TodayDate.Text = "Print On : " + getDate.ToString();
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

        dv = new DataView();
        report.Prno = Request.QueryString["prno"];
        report.Labid = Request.QueryString["labid"];
        dv = report.GetAll(2);
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        report.Prno = Request.QueryString["prno"].ToString();
        report.Labid = Request.QueryString["labid"].ToString();
        report.TestId = Request.QueryString["testid"].ToString();
        report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
        dv = report.GetAll(13);
        int counting = dv.Count;
        Lb_PrintCount.Text = "Total Prints: " + counting.ToString();
        // Label pageLabel = (Label)pagerRow.Cells[0].FindControl("Lb_PrintCount");
        //if (dv.Count > 0)
        //{
        //    for (int i = 0; i < dv.Count; i++)
        //    {                       
        //    }
        //}

        Gv_GroupTest.DataSource = dv;
        Gv_GroupTest.DataBind();

      


        ////report.TestId = dv[i]["testid"].ToString();
        ////report.Prid = dv[0]["prid"].ToString();


        //if (dv.Count > 0)
        //{
        //    for (int i = 0; i < dv.Count; i++)
        //    {
        //        string bookingdid = dv[i]["bookingdid"].ToString();

        //        Lb_dateAll.Text = "";

        //        DataView dv1 = new DataView();



        //        report.Bookingdid = bookingdid;
        //        report.TestId = dv[i]["testid"].ToString();
        //        report.Prid = dv[i]["prid"].ToString();
        //        dv1 = report.GetAll(15);
        //        if (dv1.Count > 0)
        //        {
        //            for (int k = 0; k < dv1.Count; k++)
        //            {
        //                string date = "MAX(IF(date_format(t.enteredon,'%Y-%m-%d %r') = '" + dv1[k]["enteredon"].ToString() + "', result, NULL)) AS '" + dv1[k]["headerName"].ToString() + "'";
        //                // string result = dv1[k]["result"].ToString();
        //                Lb_dateAll.Text += date + ",";
        //                // Lb_ResultAll.Text += result;
        //            }
        //            string getDates = Lb_dateAll.Text;
        //            //string resultAll = Lb_ResultAll.Text;

        //            report.ObjectDate = getDates.Remove(getDates.Length - 1);

        //            dv1 = report.GetAll(14);
        //            GridView gr;
        //            gr = (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView);
        //            gr.DataSource = dv1;
        //            gr.DataBind();
        //        }

        //        //string date1 = "0";
        //        //for (int j = 0; j < dv1.Count; j++)
        //        //{
        //        //    string date = ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_enteredOn") as Label).Text;
        //        //    if (date == date1)
        //        //    {
        //        //        ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_enteredOn") as Label).Text = "";
        //        //    }
        //        //    else
        //        //    {
        //        //        date1 = ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_enteredOn") as Label).Text;
        //        //    }
        //        //}

        //        DataView dv3 = new DataView();
        //        report.Bookingdid = bookingdid;
        //        dv3 = report.GetAll(12);

        //        GridView gr3;
        //        gr3 = (Gv_GroupTest.Rows[i].FindControl("Gv_OpionionComments") as GridView);
        //        gr3.DataSource = dv3;
        //        gr3.DataBind();

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

        e.Row.Cells[3].BackColor = Color.FromName("#EEEEEE");
        e.Row.Cells[3].BorderColor = Color.White;
        e.Row.Cells[3].BorderStyle =  BorderStyle.Solid;
        e.Row.Cells[3].Font.Size = 8;

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
             
             dv1 = report.GetAll(15);
             if (dv1.Count > 0)
             {
                for (int k = 0; k < dv1.Count; k++)
                 {
                     string date = "MAX(IF(date_format(t.enteredon,'%Y-%m-%d %r') = '" + dv1[k]["enteredon"].ToString() + "', result, NULL)) AS '" + dv1[k]["headerName"].ToString() + "'";
                     Lb_dateAll.Text += date + ",";
                 }
                 string getDates = Lb_dateAll.Text;
                 report.ObjectDate = getDates.Remove(getDates.Length - 1);

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
                     GridView gr4;
                     gr4 = (e.Row.FindControl("Gv_SeeBelow") as GridView);
                     gr4.DataSource = dvSee;
                     gr4.DataBind();
                 }
            // }

         }
    }
}