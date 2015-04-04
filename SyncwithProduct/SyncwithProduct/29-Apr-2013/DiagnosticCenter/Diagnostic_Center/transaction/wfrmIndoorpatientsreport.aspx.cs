using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Globalization;

public partial class Report_wfrmIndoorpatientsreport : System.Web.UI.Page
{
    clsReporting report = new clsReporting();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();

    protected void Page_Load(object sender, EventArgs e)
    {
          FillGV();
          patientPrimaryInformation();
          patientBranchInfo();
          calctotalcharges();
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
        if (!Request.QueryString["admno"].ToString().Equals(""))
        {
            report.ReferenceNo = Request.QueryString["admno"].ToString();
        }
        if (!Request.QueryString["prno"].ToString().Replace("___-__-________", "").Equals(""))
        {
            report.Prno = Request.QueryString["prno"].ToString();

        }
        // report.Labid = "10-006-00000002";
        dv = report.GetAll(2);
        if (dv.Count > 0)
        {
            Gv_PatientPrimaryInfo.DataSource = dv;
            Gv_PatientPrimaryInfo.DataBind();
            Lb_PRNO.Text = dv[0]["prno"].ToString();
            Lb_Visit.Text = dv[0]["labid"].ToString();
        }
        else
        {
            Gv_PatientPrimaryInfo.DataSource = null;
            Gv_PatientPrimaryInfo.DataBind();
            Lb_PRNO.Text = "";
            Lb_Visit.Text = "";
        }
    }




    private void FillGV()
    {
        clsBLPatientReg_Inv obj_reginv = new clsBLPatientReg_Inv();
        if (!Request.QueryString["admno"].ToString().Equals(""))
        {
            obj_reginv.ReferenceNo = Request.QueryString["admno"].ToString();
        }
        else if (!Request.QueryString["prno"].ToString().Replace("___-__-________", "").Equals(""))
        {
            obj_reginv.PRNO = Request.QueryString["prno"].ToString();
            obj_reginv.DateFrom = Request.QueryString["datefrom"].ToString().Trim();
            obj_reginv.DateTo = DateTime.Parse(Request.QueryString["dateto"].ToString().Trim(), new CultureInfo("ur-Pk", false)).AddDays(1).ToString("dd/MM/yyyy");
            
        }
       // obj_reginv.Type = "I";
        DataView dv_pr = obj_reginv.GetAll(48);
        if (dv_pr.Count > 0)
        {
            gvMain.DataSource = dv_pr;
            gvMain.DataBind();
        }
        else
        {
            gvMain.DataSource = "";
            gvMain.DataBind();
        }
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvInvestigations = (GridView)e.Row.Cells[0].FindControl("gvInvestigations");
            clsBLPatientReg_Inv obj_reg = new clsBLPatientReg_Inv();
            obj_reg.BookingID = gvMain.DataKeys[e.Row.RowIndex].Values[0].ToString().Trim();
            DataView dv_investigations = obj_reg.GetAll(49);
            if (dv_investigations.Count > 0)
            {
                gvInvestigations.DataSource = dv_investigations;
                gvInvestigations.DataBind();
            }
            else
            {
                gvInvestigations.DataSource = "";
                gvInvestigations.DataBind();
            }
        }
    }

    private void calctotalcharges()
    {
        int totalcharges=0;
        int totalpaid = 0;
        int totaldisc = 0;
//int totalbal = 0;
        int totbalance = 0;
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            try
            {
                totalcharges += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text);
                //totalpaid += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text);
                //totaldisc += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text);
                //totbalance += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text);
            }
            catch { }
            try
            {
                //totalcharges += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text);
                totalpaid += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text);
               // totaldisc += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text);
                //totbalance += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text);
            }
            catch { }
            try
            {
                //totalcharges += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text);
                //totalpaid += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text);
                totaldisc += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text);
                //totbalance += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text);
            }
            catch { }
            try
            {
                //totalcharges += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text);
                //totalpaid += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text);
                //totaldisc += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text);
                totbalance += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text);
            }
            catch { }
        }

        //totbalance = totalcharges - totalpaid - totaldisc;
        lbltotcharges.Text = totalcharges.ToString();
        lbltotpaid.Text = totalpaid.ToString();
        lbltotdisc.Text = totaldisc.ToString();
        lbltotbal.Text = totbalance.ToString();
    }
}