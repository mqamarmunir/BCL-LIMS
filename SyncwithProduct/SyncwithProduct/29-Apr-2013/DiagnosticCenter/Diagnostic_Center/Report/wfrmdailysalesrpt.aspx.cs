using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Globalization;
using System.Data;
public partial class Report_wfrmdailysalesrpt : System.Web.UI.Page
{
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsDayCashCollection dayCash = new clsDayCashCollection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            fillGrid();
            FillImage();
            patientBranchInfo();
            Calculatetotal();
        }

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
    public void FillImage()
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

        }
    }
    private void Calculatetotal()
    {
        int totalcash = 0;
        int totalcashpaid = 0;
        int totalcashdiscount = 0;
        int totalcashrefund = 0;
        int totalcashpanel = 0;
        int totalcppaid = 0;
        int totalcpdiscount = 0;
        int totalcprefund = 0;
        int totalcreditpanel = 0;
        int totalcollection= 0;
        int totalnetreceipt = 0;
        int totalbank = 0;
        int totaldifference = 0;
        #region calculatetotal

        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            try
            {
                Label cash = (Label)gvMain.Rows[i].FindControl("lbltotalcash");
                //totaldifference += Convert.ToInt16(diff.Text.ToString().Trim());
                totalcash += Convert.ToInt16(cash.Text.ToString().Trim());
               
                
                
           }
            catch
            {
                totalcash += 0;
            }
            try
            {
                totalcashpaid += Convert.ToInt16(gvMain.DataKeys[i].Values[1].ToString().Trim());



            }
            catch
            {
                totalcashpaid += 0;
            }
            try
            {

                totalcashdiscount += Convert.ToInt16(gvMain.DataKeys[i].Values[2].ToString().Trim());
               

            }
            catch
            {
                totalcashdiscount += 0;

            }
            try
            {

                totalcashrefund += Convert.ToInt16(gvMain.DataKeys[i].Values[3].ToString().Trim());
               

            }
            catch
            {
                totalcashrefund += 0;
            }
            try
            {

                totalcashpanel += Convert.ToInt16(gvMain.DataKeys[i].Values[4].ToString().Trim());
               


            }
            catch
            {
                totalcashpanel += 0;
            }
            try
            {

                totalcppaid += Convert.ToInt16(gvMain.DataKeys[i].Values[5].ToString().Trim());
               


            }
            catch
            {
                totalcppaid += 0;
            }
            try
            {

                totalcpdiscount += Convert.ToInt16(gvMain.DataKeys[i].Values[6].ToString().Trim());
               


            }
            catch
            {
                totalcpdiscount += 0;
            }
            try
            {

                totalcprefund += Convert.ToInt16(gvMain.DataKeys[i].Values[7].ToString().Trim());
                
            }
            catch
            {
                totalcprefund += 0;

            }
            try
            {

                totalcreditpanel += Convert.ToInt16(gvMain.DataKeys[i].Values[8].ToString().Trim());
               
            }
            catch
            {
                totalcreditpanel += 0;
            }
            try
            {

                totalcollection += Convert.ToInt16(gvMain.DataKeys[i].Values[9].ToString().Trim());
 
            }
            catch
            {
                totalcollection += 0;
            }
            try
            {
                totalnetreceipt += Convert.ToInt16(gvMain.DataKeys[i].Values[10].ToString().Trim());
            
            }
            catch
            {
                totalnetreceipt += 0;
            }
            try
            {
                totalbank += Convert.ToInt16(gvMain.DataKeys[i].Values[11].ToString().Trim());

            }
            catch
            {
                totalbank += 0;
            }
            try
            {
                Label diff = (Label)gvMain.Rows[i].FindControl("lbldiff");
                totaldifference += Convert.ToInt16(diff.Text.ToString().Trim());
             
            }
            catch
            {
                totaldifference += 0;
            }

        }
        #endregion
        lblcashtotal.Text = totalcash.ToString();
        lblcashpaid.Text = totalcashpaid.ToString();
        lblcashdiscount.Text = totalcashdiscount.ToString();
        lblcashrefund.Text = totalcashrefund.ToString();
        lblcptotal.Text = totalcashpanel.ToString();
        lblcpdiscount.Text = totalcpdiscount.ToString();
        lblcppaid.Text = totalcppaid.ToString();
        lblcprefund.Text = totalcprefund.ToString();
        lblcreditpanel.Text = totalcreditpanel.ToString();
        lblcollection.Text = totalcollection.ToString();
        lblnetreceipt.Text = totalnetreceipt.ToString();
        lblbank.Text = totalbank.ToString();
        lbldifference.Text = totaldifference.ToString();
        //return totalbalance;
    }
    public void fillGrid()
    {
        fromdate.Text = DateTime.Parse(Request.QueryString["datefrom"].ToString().Trim(), new CultureInfo("ur-pk", false)).ToString("dd,MMM,yyyy");
       // todate.Text = Request.QueryString["dateto"].ToString().Trim();
        dayCash.FromDate1 = Request.QueryString["datefrom"].ToString().Trim();
        dayCash.ToDate1 = DateTime.Parse(Request.QueryString["dateto"].ToString().Trim(), new CultureInfo("ur-pk", false)).AddDays(1).ToString("dd/MM/yyyy");
        //dayCash.FromDate1 = "16/09/2014";
        //dayCash.ToDate1 = "17/09/2014";
            //Request.QueryString["todate"].ToString();
        DataView dv = dayCash.GetAll(31);
        gvMain.DataSource = dv;
        gvMain.DataBind();
        //DataView dv2 = dayCash.GetAll(32);
        //GVrunning.DataSource = dv;
        //GVrunning.DataBind();
    }
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {//lblrecvamt
            double netcash = 0;
            double cash = 0;
            Label lblrefundcash = (Label)e.Row.FindControl("lblrefundcash");
            Label lblnetcash = (Label)e.Row.FindControl("lblrecvamt");

            Label lblrefundpanelcash = (Label)e.Row.FindControl("lblrefundcpanel");
            try
            {
                netcash = Convert.ToDouble(lblnetcash.Text.ToString());
                lblnetcash.Text=(netcash-(Convert.ToDouble(lblrefundcash.Text.ToString())+Convert.ToDouble(lblrefundpanelcash.Text.ToString()))).ToString();
            }catch{}
            //Label lblnetcash = (Label)e.Row.FindControl("lblrecvamt");
            Label lblcash = (Label)e.Row.FindControl("lblcpsumm");
            Label lbldiff = (Label)e.Row.FindControl("lbldiff");
            try { netcash = Convert.ToDouble(lblnetcash.Text.ToString()); }
            catch
            {
                netcash = 0;
            }
            try { cash = Convert.ToDouble(lblcash.Text.ToString()); }
            catch { cash = 0; }
            lbldiff.Text = (netcash - cash).ToString();
        }
    }
}