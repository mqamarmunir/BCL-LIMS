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

public partial class workload : System.Web.UI.Page
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
                log.OptionId = "55";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Fill_SubDept();

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

    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {

        string[] FDate = txtFrom.Text.Split('/');
        string[] TDate = txtTo.Text.Split('/');
        string _SelectionFormula = "";

        _SelectionFormula = "{dc_tpatient_bookingm.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";
       
        
        if (ddlSubDept.SelectedIndex > 0)
            _SelectionFormula += " and {dc_tp_subdepartments.subdepartmentid}=" + ddlSubDept.SelectedItem.Value.ToString();

        if (System.Configuration.ConfigurationManager.AppSettings["clientid"].Equals("008"))
            _SelectionFormula += "   and (( if isnull({dc_tp_test.external_org}) then {dc_tpatient_bookingd.clientid}='008') or {dc_tp_test.external_org} in ['008','-1'])";
        else if (System.Configuration.ConfigurationManager.AppSettings["clientid"].Equals("006"))
            _SelectionFormula += "  and ({dc_tp_test.external_org}<>'008' or (if isnull({dc_tp_test.external_org}) then {dc_tpatient_bookingd.clientid}='006'))";

        _SelectionFormula += " and {dc_tpatient_bookingd.processid} in [3,4,5,6]";
        

        //clsBLMain mn = new clsBLMain();
        //mn.FromDate = FDate[2] + "-" + FDate[1] + "-" + FDate[0];
        //mn.ToDate = TDate[2] + "-" + TDate[1] + "-" + TDate[0];

        //DataView dt = mn.GetAll(24);


        try
        {
            // Put user code to initialize the page here
            string strRUrl = Server.MapPath(@"../Report/workload.rpt");
            Session["ReportUrl"] = strRUrl;

            //CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
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
            string szFileName = Server.MapPath(@"pdf/workload.pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Ordering Summary", @"<script>window.open('pdf/workload.pdf');</script>", false);



        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
        }
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        this.ddlSubDept.SelectedIndex = -1;
        txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }

    private void Fill_SubDept()
    {
        clsBLMain mn = new clsBLMain();
        SComponents com = new SComponents();
        
        DataView dv = mn.GetAll(20);

        com.FillDropDownList(ddlSubDept, dv, "name", "subdepartmentid");
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
