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
using BusinessLayer;

public partial class wfrmHistopathologyReport : System.Web.UI.Page
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
            // Gv_GroupTest.AllowPaging = false; 
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
        report.Prno = Request.QueryString["prno"].ToString();
        report.Labid = Request.QueryString["labid"].ToString();

        dv = report.GetAll(2);//Previously It was 5
        sample_Internal = dv[0]["specimen_Internal"].ToString().Trim();
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        //report.PRNO = Session["prno"].ToString();
        //report.LabID = Session["labid"].ToString();
        report.Prno = Request.QueryString["prno"].ToString();
        report.Labid = Request.QueryString["labid"].ToString();
        report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
        report.TestId = Request.QueryString["testid"].ToString();
        dv = report.GetAll(6);

        Gv_GroupTest.DataSource = dv;
        Gv_GroupTest.DataBind();

        if (dv.Count > 0)
        {
            for (int i = 0; i < dv.Count; i++)
            {
                string bookingdid = dv[i]["bookingdid"].ToString();
                DataView dv1 = new DataView();
                report.Bookingdid = bookingdid;
                dv1 = report.GetAll(7);
                GridView gr;
                gr = (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView);

                gr.DataSource = dv1;
                gr.DataBind();

                for (int j = 1; j < dv1.Count; j++)
                {
                    ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lbl_Serial") as Label).Text = j.ToString();
                }

                DataView dv3 = new DataView();
                report.Bookingdid = bookingdid;
                dv3 = report.GetAll(12);

                //GridView gr3;
                //gr3 = (Gv_GroupTest.Rows[i].FindControl("Gv_OpionionComments") as GridView);
                //gr3.DataSource = dv3;
                //gr3.DataBind();

                Gv_OpionionComments.DataSource = dv3;
                Gv_OpionionComments.DataBind();

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