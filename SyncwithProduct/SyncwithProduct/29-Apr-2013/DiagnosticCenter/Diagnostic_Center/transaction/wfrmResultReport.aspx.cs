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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using BusinessLayer;



public partial class wfrmResultReport : System.Web.UI.Page
{
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    private static string sample_Internal = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            patientPrimaryInformation();
            patientBranchInfo();
            string getDate = System.DateTime.Now.ToString("MMM dd,yyyy hh:mm:ss tt");
            //Lb_TodayDate.Text = "Print On : " + getDate.ToString();
            //if (sample_Internal == "E")
            //{
            //    lblnoresponsibility.Visible = true;
            //    lblnoresponsibility.Text = "Sample Received From Outside " + System.Configuration.ConfigurationManager.AppSettings["ClientName"].ToString() + " bears no responsibility regarding correct identity and quality of sample.";
            //}
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
        sample_Internal = dv[0]["specimen_Internal"].ToString().Trim();
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        report.Prno = Request.QueryString["prno"].ToString();
        report.Labid = Request.QueryString["labid"].ToString();
        report.TestId = Request.QueryString["testid"].ToString();
        report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
        dv = report.GetAll(19);

        Gv_GroupTest.DataSource = dv;
        Gv_GroupTest.DataBind();


        //string test_range = Gv_GroupTest.DataKeys[index].Values[1].ToString();
        //string test_auto = Gv_GroupTest.DataKeys[index].Values[3].ToString();
        // for (int l = 0; l < dv.Count; l++)
        //  {
        string test_auto = dv[0]["automatedtext"].ToString();
        if (test_auto != "")
        {
            report.TestId = Request.QueryString["testid"].ToString();
            //DataView dvSee = new DataView();
            //dvSee = report.GetAll(22);
            //Gv_SeeBelow.DataSource = dvSee;
            //Gv_SeeBelow.DataBind();
        }
        // }
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

                string dates1 = "";
                dv1 = report.GetAll(15);
                if (dv1.Count > 0)
                {
                    for (int k = 0; k < dv1.Count; k++)
                    {
                        string date = "MAX(IF(date_format(t.enteredon,'%Y-%m-%d %r') = '" + dv1[k]["enteredon"].ToString() + "', result, NULL)) AS '" + dv1[k]["headerName"].ToString() + "'";
                        // string result = dv1[k]["result"].ToString();
                        //dates1 += "MAX(IF(date_format(t1.enteredon,'%Y-%m-%d %r') = '" + dv1[k]["enteredon"].ToString() + "', result, NULL)) AS '" + dv1[k]["headerName"].ToString() + "'" + ",";
                        Lb_dateAll.Text += date + ",";
                        // Lb_ResultAll.Text += result;
                    }
                    string getDates = Lb_dateAll.Text;
                    report.ObjectDate = getDates.Remove(getDates.Length - 1);
                    //report.ObjectDate1 = dates1.Remove(dates1.Length - 1);

                    dv1 = report.GetAll(14);
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);
        Gv_GroupTest.AllowPaging = false;
        Gv_GroupTest.DataBind();
        Gv_GroupTest.RenderControl(hw);
        Gv_GroupTest.HeaderRow.Style.Add("width", "15%");
        Gv_GroupTest.HeaderRow.Style.Add("font-size", "10px");
        Gv_GroupTest.Style.Add("text-decoration", "none");
        Gv_GroupTest.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        Gv_GroupTest.Style.Add("font-size", "8px");

      

        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
       // pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Width = Unit.Percentage(25);
        e.Row.Cells[0].Font.Size = 8;

        e.Row.Cells[1].Width = Unit.Percentage(10);
        e.Row.Cells[1].Font.Size = 8;

        e.Row.Cells[2].Width = Unit.Percentage(8);
        e.Row.Cells[2].Font.Size = 8;
        try
        {
            e.Row.Cells[3].BackColor = System.Drawing.Color.FromName("#EEEEEE");
            e.Row.Cells[3].BorderColor = System.Drawing.Color.White;
            e.Row.Cells[3].BorderStyle = BorderStyle.Solid;
            e.Row.Cells[3].Font.Size = 8;
        }
        catch { }

       // e.Row.Cells[e.Row.Cells.Count-1].Visible = false;
        //e.Row.Cells[4].Font.Size = 0;
        string encoded = e.Row.Cells[2].Text;
        e.Row.Cells[2].Text = Context.Server.HtmlDecode(encoded);

        string encoded2 = e.Row.Cells[1].Text;
        e.Row.Cells[1].Text = Context.Server.HtmlDecode(encoded2);

        //e.Row.Cells[1].Width = 100;
    }

    protected void Gv_GroupTest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
                int index = e.Row.RowIndex;
                if (index != -1 && e.Row.RowType == DataControlRowType.DataRow)
                {
                    string test_range = Gv_GroupTest.DataKeys[index].Values[1].ToString();
                    string test_auto = Gv_GroupTest.DataKeys[index].Values[3].ToString();
                    //  for (int l = 0; l < dv.Count; l++)
                    // {
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