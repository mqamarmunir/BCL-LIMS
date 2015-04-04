using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Report_rptcashsummary_report : System.Web.UI.Page
{
    double cashsales = 0;
    double paneloncashsales = 0;
    double panelsales = 0;
    double cashdiscounts = 0;
    double refunds = 0;
    double tradediscount = 0;
    double netsales = 0;
    double balance = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        fillheadinfo();
        fillGVcash();
        fillGVpaneloncash();
        fillGVPanel();
        fillpreviousrefunds();
       // fillbalanceinfo();
        fillsummary();

    }

    
    private void fillheadinfo()
    {
        
        lblBranchname.Text = Request.QueryString["branchname"];
        lbldaterange.Text =  DateTime.Parse(Request.QueryString["datefrom"],new CultureInfo("ur-Pk",false)).ToString("MMM dd, yyyy")+"  To: "+DateTime.Parse(Request.QueryString["dateto"],new CultureInfo("ur-Pk",false)).ToString("MMM dd, yyyy");
    }

    private void fillbalanceinfo()
    {
        int count = 0;
        clsReporting objReporting = new clsReporting();
        DataView dv = objReporting.GetAll(33);
        if (Convert.ToInt32(dv[0][0].ToString()) > 0)
        {
            count++;
        }
        lbloutcash30.Text = dv[0][0].ToString();
        dv = objReporting.GetAll(34);
        if (Convert.ToInt32(dv[0][0].ToString()) > 0)
        {
            count++;
        }
        lbloutcash60.Text = dv[0][0].ToString();
        dv = objReporting.GetAll(35);
        if (Convert.ToInt32(dv[0][0].ToString()) > 0)
        {
            count++;
        }
        lbloutcash90.Text = dv[0][0].ToString();
        dv.Dispose();
        if (count == 0)
        {
            tbloutbalance.Visible = false;
            lblzerobalance.Text = "No outstanding balances during last 90 days.";
        }
        
    }

    private void fillGVcash()
    {
        clsReporting report = new clsReporting();
        report.Datefrom =  DateTime.Parse(Request.QueryString["datefrom"],new CultureInfo("ur-Pk",false)).ToString("yyyy/MM/dd");
        report.Dateto = DateTime.Parse(Request.QueryString["dateto"], new CultureInfo("ur-Pk", false)).ToString("yyyy/MM/dd");
        report.BranchID = Request.QueryString["branchid"].ToString().Trim();
        report.Payment_mode = "C";
        DataView dv = report.GetAll(31);
        if (dv.Count > 0)
        {
            gvMain.DataSource = dv;
            gvMain.DataBind();
        }
        else
        {
            gvMain.DataSource = "";
            gvMain.DataBind();
        }

    }

    private void fillGVpaneloncash()
    {
        clsReporting report = new clsReporting();
        report.Datefrom = DateTime.Parse(Request.QueryString["datefrom"], new CultureInfo("ur-Pk", false)).ToString("yyyy/MM/dd");
        report.Dateto = DateTime.Parse(Request.QueryString["dateto"], new CultureInfo("ur-Pk", false)).ToString("yyyy/MM/dd");
        report.BranchID = Request.QueryString["branchid"].ToString().Trim();
        report.Payment_mode = "P";
        DataView dv = report.GetAll(31);
        if (dv.Count > 0)
        {
            gvPanelOnCash.DataSource = dv;
            gvPanelOnCash.DataBind();
        }
        else
        {
            gvPanelOnCash.DataSource = "";
            gvPanelOnCash.DataBind();
        }

    }
    private void fillGVPanel()
    {
        clsReporting report = new clsReporting();
        report.Datefrom = DateTime.Parse(Request.QueryString["datefrom"], new CultureInfo("ur-Pk", false)).ToString("yyyy/MM/dd");
        report.Dateto = DateTime.Parse(Request.QueryString["dateto"], new CultureInfo("ur-Pk", false)).ToString("yyyy/MM/dd");
        report.BranchID = Request.QueryString["branchid"].ToString().Trim();
       // report.Payment_mode = "P";
        DataView dv = report.GetAll(36);
        if (dv.Count > 0)
        {
            gvPanel.DataSource = dv;
            gvPanel.DataBind();
        }
        else
        {
            gvPanel.DataSource = "";
            gvPanel.DataBind();
        }
    }
    private void fillpreviousrefunds()
    {
         clsReporting report = new clsReporting();
        report.Datefrom =  DateTime.Parse(Request.QueryString["datefrom"],new CultureInfo("ur-Pk",false)).ToString("yyyy/MM/dd");
        report.Dateto = DateTime.Parse(Request.QueryString["dateto"], new CultureInfo("ur-Pk", false)).ToString("yyyy/MM/dd");
        report.BranchID = Request.QueryString["branchid"].ToString().Trim();
        DataView dv = report.GetAll(32);
        if (dv.Count > 0)
        {
            gvRefunds.DataSource = dv;
            gvRefunds.DataBind();
        }
        else
        {
            lblzerorecord.Text = "No Such record found.";
            //fsrefund.Visible = false;
            gvRefunds.DataSource = "";
            gvRefunds.DataBind();
        }
 
    }
    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            cashsales += Convert.ToDouble((e.Row.Cells[0].FindControl("lbllabid") as Label).Text);
            cashdiscounts += Convert.ToDouble((e.Row.Cells[0].FindControl("lblType") as Label).Text);
            refunds += Convert.ToDouble((e.Row.Cells[0].FindControl("lblWard") as Label).Text);
            balance += Convert.ToDouble((e.Row.Cells[0].FindControl("lblTotal") as Label).Text);
            (e.Row.Cells[0].FindControl("lblPaid") as Label).Text = (Convert.ToDouble((e.Row.Cells[0].FindControl("lb_Bed") as Label).Text) - Convert.ToDouble((e.Row.Cells[0].FindControl("lblWard") as Label).Text)).ToString("C",CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00","");//payments - Refunds

            (e.Row.Cells[0].FindControl("lb_Bed") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lb_Bed") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
            (e.Row.Cells[0].FindControl("lblward") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lblward") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
            (e.Row.Cells[0].FindControl("lbllabid") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbllabid") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

            (e.Row.Cells[0].FindControl("lbltotal") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbltotal") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
            //(e.Row.Cells[0].FindControl("lblbrshare") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lblbrshare") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));
            (e.Row.Cells[0].FindControl("lblbrshare") as Label).Text = (Convert.ToDouble((e.Row.Cells[0].FindControl("lblbrshare") as Label).Text) - Convert.ToDouble((e.Row.Cells[0].FindControl("lbltype") as Label).Text)).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
            (e.Row.Cells[0].FindControl("lbltype") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbltype") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        
        }

    }

    protected void gvPanelOnCash_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            paneloncashsales += Convert.ToDouble((e.Row.Cells[0].FindControl("lbllabid") as Label).Text);
            cashdiscounts += Convert.ToDouble((e.Row.Cells[0].FindControl("lblType") as Label).Text);
            refunds += Convert.ToDouble((e.Row.Cells[0].FindControl("lblWard") as Label).Text);
            balance += Convert.ToDouble((e.Row.Cells[0].FindControl("lblTotal") as Label).Text);
            (e.Row.Cells[0].FindControl("lblPaid") as Label).Text = (Convert.ToDouble((e.Row.Cells[0].FindControl("lb_Bed") as Label).Text) - Convert.ToDouble((e.Row.Cells[0].FindControl("lblWard") as Label).Text)).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00","");//payments - Refunds

            (e.Row.Cells[0].FindControl("lb_Bed") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lb_Bed") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
            (e.Row.Cells[0].FindControl("lblward") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lblward") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
            (e.Row.Cells[0].FindControl("lbllabid") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbllabid") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

            (e.Row.Cells[0].FindControl("lbltotal") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbltotal") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
            //(e.Row.Cells[0].FindControl("lblbrshare") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lblbrshare") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));
            (e.Row.Cells[0].FindControl("lblbrshare") as Label).Text = (Convert.ToDouble((e.Row.Cells[0].FindControl("lblbrshare") as Label).Text) - Convert.ToDouble((e.Row.Cells[0].FindControl("lbltype") as Label).Text)).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
            (e.Row.Cells[0].FindControl("lbltype") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbltype") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");

        }
    }

    protected void gvPanel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            panelsales += Convert.ToDouble((e.Row.Cells[0].FindControl("lbllabid") as Label).Text);
            try
            {
                tradediscount += Convert.ToDouble((e.Row.Cells[0].FindControl("lblType") as Label).Text);
            }
            catch
            { }
            //cashsales += Convert.ToDouble((e.Row.Cells[0].FindControl("lbllabid") as Label).Text);
            //cashdiscounts += Convert.ToDouble((e.Row.Cells[0].FindControl("lblType") as Label).Text);
            //refunds += Convert.ToDouble((e.Row.Cells[0].FindControl("lblWard") as Label).Text);
            //balance += Convert.ToDouble((e.Row.Cells[0].FindControl("lblTotal") as Label).Text);
            //(e.Row.Cells[0].FindControl("lblPaid") as Label).Text = (Convert.ToDouble((e.Row.Cells[0].FindControl("lb_Bed") as Label).Text) - Convert.ToDouble((e.Row.Cells[0].FindControl("lblWard") as Label).Text)).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));//payments - Refunds

            //(e.Row.Cells[0].FindControl("lb_Bed") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lb_Bed") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));
            //(e.Row.Cells[0].FindControl("lblward") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lblward") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));
            //(e.Row.Cells[0].FindControl("lbllabid") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbllabid") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));

            //(e.Row.Cells[0].FindControl("lbltotal") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbltotal") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));
            ////(e.Row.Cells[0].FindControl("lblbrshare") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lblbrshare") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));
            //(e.Row.Cells[0].FindControl("lblbrshare") as Label).Text = (Convert.ToDouble((e.Row.Cells[0].FindControl("lblbrshare") as Label).Text) - Convert.ToDouble((e.Row.Cells[0].FindControl("lbltype") as Label).Text)).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));
            //(e.Row.Cells[0].FindControl("lbltype") as Label).Text = Convert.ToDouble((e.Row.Cells[0].FindControl("lbltype") as Label).Text).ToString("C", CultureInfo.CreateSpecificCulture("ur-pk"));

        }   
    }

    private void fillsummary()
    {
        lblCashsales.Text = cashsales.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblPanelOnCash.Text = paneloncashsales.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblPanelsales.Text = panelsales.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblTrdisc.Text=tradediscount.ToString();
        lblRefunds.Text = refunds.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblCashDisc.Text = cashdiscounts.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
        lblbalance.Text = balance.ToString("C", CultureInfo.CreateSpecificCulture("ur-pk")).Replace(".00", "");
    }
}