using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

public partial class pnl_ledger : System.Web.UI.Page
{
    private ReportDocument doc = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";

        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "52";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Fill_Panel();
                    txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    try
                    {
                        rdbLab.ClearSelection();
                        rdbLab.Items.FindByValue(System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString()).Selected = true;
                    }
                    catch { }
                }

                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowed.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }

    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        lblError.Text = "";
        ddlPanel.SelectedIndex = -1;

        txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlPanel.SelectedIndex <= 0)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please select panel";
            return;
        }
        else
            lblError.Text = "";

        string[] FDate = txtFrom.Text.Split('/');
        string[] TDate = txtTo.Text.Split('/');
        string _SelectionFormula = "";

        _SelectionFormula = "{command.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";

        if (!rdbLab.SelectedItem.Value.ToString().Equals("A"))
            _SelectionFormula += " and {command.clientid}='" + this.rdbLab.SelectedItem.Value.ToString() + "'";

        if (ddlPanel.SelectedIndex > 0)
            _SelectionFormula += " and {command.panelid}=" + ddlPanel.SelectedItem.Value.ToString() + "";
        string reportName = "";

        try
        {
            // Put user code to initialize the page here
            
                reportName = "PanelLedger";
            string strRUrl = Server.MapPath(@"../Report/"+reportName+".rpt");
            Session["ReportUrl"] = strRUrl;

            //CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            int i;
            int j;
            doc.Load(strRUrl);
            j = doc.Database.Tables.Count - 1;
            string userName = "bc_lims";//bc_lims
            string pwd = "UVE02Do8ze";//UVE02Do8ze
            string serverName = "bc_lims";//bc_lims

            //string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            //string[] info = strConn.Split(';');
            //userName = ((info[1].Split('='))[1]).Trim();
            //pwd = ((info[3].Split('='))[1]).Trim();
            //serverName = ((info[2].Split('='))[1]).Trim();

            for (i = 0; i <= j; i++)
            {
                TableLogOnInfo logOnInfo = new TableLogOnInfo();
                logOnInfo = doc.Database.Tables[i].LogOnInfo;
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo = logOnInfo.ConnectionInfo;
                connectionInfo.ServerName = serverName;
                connectionInfo.Password = pwd;
                connectionInfo.UserID = userName;
                doc.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
            }

            if (_SelectionFormula != "")
                doc.RecordSelectionFormula = _SelectionFormula;

            _SelectionFormula = doc.RecordSelectionFormula;


            try
            {
                doc.SetParameterValue("from", txtFrom.Text.Trim());
            }
            catch { }


            try
            {
                doc.SetParameterValue("to", txtTo.Text.Trim());
            }
            catch { }
            doc.SetParameterValue("origin", rdbLab.SelectedItem.Text);
            CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            string szFileName = Server.MapPath(@"pdf/"+reportName+".pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Ordering Summary", @"<script>window.open('pdf/"+reportName+".pdf');</script>", false);



        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
        }
    }
    private void Fill_Panel()
    {
        clsBLPanel objPanel = new clsBLPanel();
        SComponents objComp = new SComponents();

        DataView dv = objPanel.GetAll(5);
        objComp.FillDropDownList(ddlPanel, dv, "name", "PanelID");
    }

    private void Page_UnLoad(object sender, EventArgs e)
    {
        if (doc != null)
        {
            doc.Close();
            doc.Dispose();
            doc = null;
            GC.Collect();
        }
    }
}
