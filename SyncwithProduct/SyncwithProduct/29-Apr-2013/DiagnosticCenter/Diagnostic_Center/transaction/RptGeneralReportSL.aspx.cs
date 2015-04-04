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

public partial class transaction_RptGeneralReportSL : System.Web.UI.Page
{
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            patientPrimaryInformation();
            // patientBranchInfo();
            BranchName();
        }
    }

    //public void patientBranchInfo()
    //{
    //    patient.Branch_ID = Session["branchid"].ToString();
    //    DataView dv = new DataView();
    //    dv = patient.GetAll(43);
    //    Lb_BranchNames.Text = dv[0]["branchName"].ToString();
    //    // Lb_branchAddress.Text = dv[0]["address"].ToString();
    //    string _24hrs = dv[0]["24HrsService"].ToString();


    //    if (_24hrs == "Y")
    //    {
    //        Lb_starttime.Text = "24 Hrs";
    //        Lb_endtime.Visible = false;
    //        lb_phonebranchmain.Text = dv[0]["phone"].ToString();
    //    }
    //    else
    //    {
    //        Lb_starttime.Text = dv[0]["starttimes"].ToString();
    //        Lb_endtime.Text = dv[0]["endtimes"].ToString();
    //        lb_phonebranchmain.Text = dv[0]["phone"].ToString();
    //        Lb_Extension.Text = dv[0]["Ext"].ToString();
    //    }

    //}

  

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
           // Gv_BranchNames.DataSource =  dv;
          //  Gv_BranchNames.DataBind();

            ListView1.DataSource = dv;
            ListView1.DataBind();
           
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


    public void patientPrimaryInformation()
    {
        report.Delete_RecordResultView();

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

        Gv_GroupTest.DataSource = dv;
        Gv_GroupTest.DataBind();



        for (int l = 0; l < dv.Count; l++)
        {
            string test_range = dv[l]["testid"].ToString();
            string test_auto = dv[l]["automatedtext"].ToString();

            if (test_auto != "")
            {
                report.TestId = test_range;
                DataView dvSee = new DataView();
                dvSee = report.GetAll(22);

                string autoText = dvSee[0]["autotext"].ToString();
                (Gv_GroupTest.Rows[l].FindControl("Label1") as Label).Text = "<b><u>Reference Ranges</u> :</b><br/>" + autoText;
               
            }
        }

        //report.TestId = dv[i]["testid"].ToString();
        //report.Prid = dv[0]["prid"].ToString();
        report.Prid = Request.QueryString["prid"].ToString();
        report.Insert_RecordResultView();


        if (dv.Count > 0)
        {
            for (int i = 0; i < dv.Count; i++)
            {
                string bookingdid = dv[i]["bookingdid"].ToString();

                Lb_dateAll.Text = "";

                DataView dv1 = new DataView();
                report.Bookingdid = bookingdid;
                report.TestId = dv[i]["testid"].ToString();
                report.Prid = dv[i]["prid"].ToString();
                dv1 = report.GetAll(24);
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

                    dv1 = report.GetAll(18);
                    GridView gr;
                    gr = (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView);
                    gr.DataSource = dv1;
                    gr.DataBind();
                }

                //string date1 = "0";
                //for (int j = 0; j < dv1.Count; j++)
                //{
                //    string date = ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_enteredOn") as Label).Text;
                //    if (date == date1)
                //    {
                //        ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_enteredOn") as Label).Text = "";
                //    }
                //    else
                //    {
                //        date1 = ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_enteredOn") as Label).Text;
                //    }
                //}

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



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Width = Unit.Percentage(35);
        e.Row.Cells[0].Font.Size = 8;

        e.Row.Cells[1].BackColor = Color.FromName("#EEEEEE");
        e.Row.Cells[1].BorderColor = Color.White;
        e.Row.Cells[1].BorderStyle = BorderStyle.Solid;
        e.Row.Cells[1].Font.Size = 8;

        e.Row.Cells[2].Width = Unit.Percentage(6);
        e.Row.Cells[2].Font.Size = 8;

        e.Row.Cells[3].Width = Unit.Percentage(10);
        e.Row.Cells[3].Font.Size = 8;

        e.Row.Cells[4].Width = Unit.Percentage(8);
        e.Row.Cells[4].Font.Size = 8;

        e.Row.Cells[5].Width = Unit.Percentage(6);
        e.Row.Cells[5].Font.Size = 8;

        // e.Row.Cells[6].Width = Unit.Percentage(8);
        // e.Row.Cells[6].Font.Size = 7;
        // e.Row.Cells[1].Width = 100;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();

        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //Gv_GroupTest.AllowPaging = false;
        //Gv_GroupTest.DataBind();
        //Gv_GroupTest.RenderControl(hw);
        //Gv_GroupTest.HeaderRow.Style.Add("width", "15%");
        //Gv_GroupTest.HeaderRow.Style.Add("font-size", "10px");
        //Gv_GroupTest.Style.Add("text-decoration", "none");
        //Gv_GroupTest.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        //Gv_GroupTest.Style.Add("font-size", "8px");



        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //// pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}