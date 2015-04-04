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

public partial class bal_dis : System.Web.UI.Page
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
                log.OptionId = "51";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Fill_Panel();
                    txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    rdbOption.Items.FindByValue("B").Selected = true;
                    rdbType.Items.FindByValue("A").Selected = true;
                    ddlPanel.Visible = false;
                    lblPanel.Visible = false;

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
 

        txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        clsBLMain mn = new clsBLMain();

        string[] FDate = txtFrom.Text.Split('/');
        string[] TDate = txtTo.Text.Split('/');
       
        mn.FromDate = FDate[2] + "-" + FDate[1] + "-" + FDate[0];
        mn.ToDate = TDate[2] + "-" + TDate[1] + "-" + TDate[0];

        string _SelectionFormula = "";
        _SelectionFormula = "{dc_tpatient_bookingm.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";

        if (!rdbLab.SelectedItem.Value.ToString().Equals("A"))
        {
            _SelectionFormula += " and {dc_tpatient_bookingm.clientid}='" + this.rdbLab.SelectedItem.Value.ToString() + "'";
            mn.BranchID = this.rdbLab.SelectedItem.Value.ToString();
        }

        if (ddlPanel.SelectedIndex > 0)
        {
            _SelectionFormula += " and {dc_tpatient_bookingm.Panelid} = " + ddlPanel.SelectedItem.Value.ToString() + "";
            mn.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        }
        if (rdbType.SelectedItem.Value.ToString().Equals("P"))
        {
            _SelectionFormula += " and not isnull({dc_tpatient_bookingm.Panelid})";
            mn.Type = "P";
        }
        //{dc_tpatient_bookingm.Payment_mode}='A' ";
        //
        if (rdbType.SelectedItem.Value.ToString().Equals("C"))
        {
            _SelectionFormula += " and  isnull({dc_tpatient_bookingm.Panelid})";
            mn.Type = "C";
        }
        string reportName = "";

        try
        {
            // Put user code to initialize the page here
            DataView dt  = mn.GetAll(29);
            if (rdbOption.Items.FindByValue("B").Selected)
                reportName = "due_balance";
            else
                reportName = "Discount_sumary"; 
          
            string strRUrl = Server.MapPath(@"../Report/"+reportName+".rpt");
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
            
            doc.SetDataSource(dt.Table);

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
    protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbType.SelectedItem.Value.ToString().Equals("P"))
        {
            lblPanel.Visible = true;
            ddlPanel.Visible = true;
        }
        else
        {
            lblPanel.Visible = false;
            ddlPanel.Visible = false;

            ddlPanel.SelectedIndex = -1;
        }
    }
    private void Fill_Panel()
    {
        clsBLPanel objPanel = new clsBLPanel();
        SComponents objComp = new SComponents();

        DataView dv = objPanel.GetAll(5);
        objComp.FillDropDownList(ddlPanel, dv, "name", "PanelID");        
    }
}
