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

public partial class wfrmMicrobiologyReport : System.Web.UI.Page
{
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            patientPrimaryInformation();
            patientBranchInfo();
            // Gv_GroupTest.AllowPaging = false; 
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

        dv = report.GetAll(5);
        Gv_PatientPrimaryInfo.DataSource = dv;
        Gv_PatientPrimaryInfo.DataBind();
        Lb_PRNO.Text = dv[0]["prno"].ToString();
        Lb_Visit.Text = dv[0]["labid"].ToString();

        report.Prno= Request.QueryString["prno"].ToString();
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
                report.Bookingdid = bookingdid;
                dv1 = report.GetAll(10);
                GridView gr;
                gr = (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView);

                

                gr.DataSource = dv1;
                gr.DataBind();

                for (int j = 0; j < dv1.Count; j++)
                {
                    ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lbl_Serial") as Label).Text = j.ToString();
                    string attrib = ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_attribname") as Label).Text.ToString();

                    if (attrib == "Physical Examination" || attrib == "Microscopic Examination" || attrib == "Chemical Examination")
                    {
                        ((Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("Lb_attribname") as Label).Font.Bold = true;
                    }

                }

                DataView dv2 = new DataView();
                report.Bookingdid = bookingdid;
                dv2 = report.GetAll(11);

                if (dv2.Count > 0)
                {
                    GridView gr2;
                    gr2 = (Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView);
                    gr2.DataSource = dv2;
                    gr2.DataBind();
                }
                else
                {
                   (Gv_GroupTest.Rows[i].FindControl("Lb_HeadingMicro") as Label).Visible = false;
                   (Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Visible = false;
                   (Gv_GroupTest.Rows[i].FindControl("Lb_Abbreviation") as Label).Visible = false;
                }
                for (int k = 0; k < dv2.Count; k++)
                {
                    string Organism = ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
              
                    if (Organism == Organism1)
                    {
                        ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text = "";
                        // (Gv_GroupTest.Rows[i].FindControl("Gv_Attributes") as GridView).Rows[j].FindControl("tr_date").Visible = false;
                    }
                    else
                    {
                        Organism1 = ((Gv_GroupTest.Rows[i].FindControl("Gv_MicoSensitvity") as GridView).Rows[k].FindControl("Lb_Organisms") as Label).Text;
                    }
                }

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
}