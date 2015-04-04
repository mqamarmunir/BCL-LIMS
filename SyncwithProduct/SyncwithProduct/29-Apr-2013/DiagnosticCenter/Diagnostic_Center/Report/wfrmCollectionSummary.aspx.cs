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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using BusinessLayer;

public partial class collectionsummary : System.Web.UI.Page
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
                log.OptionId = "60";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                  
                    txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");                   
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
        txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {

        string[] FDate = txtFrom.Text.Split('/');
        string[] TDate = txtTo.Text.Split('/');
        string _SelectionFormula = "";
        string _Sub_Formula = "";

        _SelectionFormula = "date({dc_vrec_cc.recDate}) in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";
        _Sub_Formula = "date({dc_vref_cc.refDate}) in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";
     
        try
        {
            // Put user code to initialize the page here
            string strRUrl = Server.MapPath(@"../Report/collection_summary.rpt");
            Session["ReportUrl"] = strRUrl;
           
            int i;
            int j;
            doc.Load(strRUrl);
            j = doc.Database.Tables.Count - 1;
            string userName = "bc_lims";
            string pwd = "UVE02Do8ze";
            string serverName = "bc_lims";

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

            doc.Subreports[0].RecordSelectionFormula = _Sub_Formula;
            //doc.SetDataSource(dt.Table);

            try
            {
                doc.SetParameterValue("sdate", txtFrom.Text.Trim());
            }
            catch { }


            try
            {
                doc.SetParameterValue("tdate", txtTo.Text.Trim());
            }
            catch { }

            CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            string szFileName = Server.MapPath(@"pdf/Collection_Summary.pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Collection Summary", @"<script>window.open('pdf/Collection_Summary.pdf');</script>", false);



        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
        }
    }
}
