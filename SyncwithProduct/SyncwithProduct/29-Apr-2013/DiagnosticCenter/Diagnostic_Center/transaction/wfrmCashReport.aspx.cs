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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;

public partial class transaction_wfrmCashReport : System.Web.UI.Page
{
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();

    string cellno = "";
    string deliverydatetime = "";
    string patient1 = "";
    string pass = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        patientPrimaryInformation();
        BranchName();
        string labid = Request.QueryString["labid"].ToString();

        int cellvaluecounter = 0;
        for (int i = 0; i < Gv_PatientReceipt.Rows.Count; i++)
        {
            if (Gv_PatientReceipt.Rows[i].Cells[5].Text.ToLower().Equals("none"))
            {
                Gv_PatientReceipt.Rows[i].Cells[5].Visible = false;
                cellvaluecounter++;
            }
        }
        if (cellvaluecounter == Gv_PatientReceipt.Rows.Count)
        {
            Gv_PatientReceipt.HeaderRow.Cells[5].Visible = false;
        }

            //if (Request.QueryString["watermark"].ToString() != "watermark")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt ", "<script>window.open('wfrmsendNotifications.aspx?prno=" + Lb_PRNO.Text.Trim() + "&labid=" + labid + "&pass=" + pass + "&ProcessID=10');</script>", false);
            //}
        if (cellno != "")
        {
            //  ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('smsPage.aspx?cellno=" + cellno.Trim() + "&labid=" + labid + "&deliverydatetime=" + deliverydatetime.Trim() + " &patient1= " + patient1.Trim() + "');</script>", false);
        }
        // loadPDFGrid();
            string _bookingtime = (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_RegDate") as Label).Text.Trim();


            if (Request.QueryString["watermark"].ToString() == "watermark" && (System.DateTime.Now-DateTime.Parse(_bookingtime,new CultureInfo("ur-pk",false))).TotalMinutes>15)
            {
                watermark.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt ", "<script>window.open('wfrmsendNotifications.aspx?prno=" + Lb_PRNO.Text.Trim() + "&labid=" + labid + "&pass=" + pass + "&ProcessID=10');</script>", false);

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
                Img_header.ImageUrl = dv[0]["Path_location"].ToString() ;
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

       // DataView dv = new DataView();
       // patient.PRNO = Session["prno"].ToString();
       // patient.LabID = Session["labid"].ToString();

        patient.PRNO = Request.QueryString["prno"].ToString();
        patient.LabID = Request.QueryString["labid"].ToString();
        
        dv = patient.GetAll(34);

        string panelName = dv[0]["panelname"].ToString();
        string specimen = dv[0]["specimen"].ToString();

        lb_remarks.Text = "Remarks : " + dv[0]["remarks"].ToString();

        if (specimen == "E")
        {
            Lb_SpecimenInternal.Text = "Sample received from outside";
        }
        else
        {
            Lb_SpecimenInternal.Text = "";
        }

        Lb_EnteredBy.Text = dv[0]["receivedby"].ToString();

         cellno = dv[0]["cellno"].ToString();
         patient1 = dv[0]["patient"].ToString();
         deliverydatetime = dv[0]["deliverydatetime"].ToString();

        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        //patient.PRNO = Session["prno"].ToString();
       // patient.LabID = Session["labid"].ToString();
        patient.PRNO = Request.QueryString["prno"].ToString();
        patient.LabID = Request.QueryString["labid"].ToString();

        dv = patient.GetAll(35);
        if (!dv[0]["groupname"].ToString().Trim().Equals(""))
        {
            lblGroupName.Text = "<b>Group Name:</b>" + dv[0]["groupname"].ToString().Trim();
        }
        string testID = "";
        if (panelName != "")
        {
            Gv_PatientReceipt.Columns[4].HeaderText = "Panel Charges";
        }
        else
        {
            Gv_PatientReceipt.Columns[4].HeaderText = "Charges";
        }

        pass = dv[0]["pasword"].ToString();

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
        testID += "237460";//dummy value
        patient.TestID = testID;
        dv_Coment = patient.GetAll(44);
        Gv_TestComent.DataSource = dv_Coment;
        Gv_TestComent.DataBind();

       // patient.PRNO = Session["prno"].ToString();
       // patient.LabID = Session["labid"].ToString();

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
                //if (Request.QueryString["referenceno"].ToString() != "")
                //{
                //    (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_refernces") as Label).Text = Request.QueryString["referenceno"].ToString();
                //}
            }
            if (Request.QueryString["referenceno"].ToString() != "")
            {
                (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_refernces") as Label).Text = Request.QueryString["referenceno"].ToString();
            }
        }

        else
        {
            (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_employeeno") as Label).Visible = false;
            (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_serviceno") as Label).Visible = false;
            (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_txreferences") as Label).Visible = true;
            (Gv_PatientPrimaryInfo.Rows[0].FindControl("Lb_refernces") as Label).Visible = true;
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

    protected void Gv_PatientPrimaryInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            clsBLPreferenceSettings objPrefernceSettings = new clsBLPreferenceSettings();
            DataView dv_preferences = objPrefernceSettings.GetAll(1);
            if (dv_preferences.Count > 0)
            {
                (e.Row.FindControl("Label7") as Label).Text = dv_preferences[0]["logininstructions"].ToString().Trim();
            }
            else
            {
                (e.Row.FindControl("Label7") as Label).Text = "";
            }
            objPrefernceSettings = null;
            dv_preferences.Dispose();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();


        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //Gv_PatientPrimaryInfo.AllowPaging = false;
        //Gv_PatientPrimaryInfo.DataBind();
        //Gv_PatientPrimaryInfo.RenderControl(hw);
        //Gv_PatientPrimaryInfo.HeaderRow.Style.Add("width", "15%");
        //Gv_PatientPrimaryInfo.HeaderRow.Style.Add("font-size", "10px");
        //Gv_PatientPrimaryInfo.Style.Add("text-decoration", "none");
        //Gv_PatientPrimaryInfo.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        //Gv_PatientPrimaryInfo.Style.Add("font-size", "8px");


        HtmlTextWriter hw2 = new HtmlTextWriter(sw);
        Gv_PatientReceipt.AllowPaging = false;
        Gv_PatientReceipt.DataBind();
        Gv_PatientReceipt.RenderControl(hw2);
        Gv_PatientReceipt.HeaderRow.Style.Add("width", "15%");
        Gv_PatientReceipt.HeaderRow.Style.Add("font-size", "10px");
        Gv_PatientReceipt.Style.Add("text-decoration", "none");
        Gv_PatientReceipt.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        Gv_PatientReceipt.Style.Add("font-size", "8px");

        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }

   
}
