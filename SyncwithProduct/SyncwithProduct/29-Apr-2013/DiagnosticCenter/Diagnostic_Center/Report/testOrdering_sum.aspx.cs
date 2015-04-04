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

public partial class testcode: System.Web.UI.Page
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
                log.OptionId = "49";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Fill_Depart();
                    Fill_Test();
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
        txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");

        ddlDepartment.SelectedIndex = -1;
        Fill_Test();
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
       
        string[] FDate = txtFrom.Text.Split('/');
        string[] TDate = txtTo.Text.Split('/');

        clsBLMain mn = new clsBLMain();
        mn.FromDate = FDate[2] + "-" + FDate[1] + "-" + FDate[0];
        mn.ToDate = TDate[2] + "-" + TDate[1] + "-" + TDate[0];

        
        
        string _SelectionFormula = "{command.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";
        _SelectionFormula += " and {command.clientid}='" + this.rdbLab.SelectedItem.Value.ToString() + "'";
        if (ddlTest.SelectedIndex > 0)
        {
            _SelectionFormula += " and {command.testid} = " + ddlTest.SelectedItem.Value.ToString() + "";
            mn.TestID = this.ddlTest.SelectedItem.Value.ToString();
            mn.BranchID = this.rdbLab.SelectedItem.Value.ToString();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerT", "<script>alert('Please select test first')</script>", false);
            return;
        }
        
        try
        {
            // Put user code to initialize the page here
            string strRUrl = Server.MapPath(@"../Report/testordering_sum.rpt");
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
            DataView dt = mn.GetAll(28);
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
            string szFileName = Server.MapPath(@"pdf/testordering_sum.pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Ordering Summary", @"<script>window.open('pdf/testordering_sum.pdf');</script>", false); 

           

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this,typeof(Page),"alert","<script>alert('"+ex.Message+"')</script>",false);
        }
    }

    private void Fill_Depart()
    {
        clsBLMain mn = new clsBLMain();
        SComponents com = new SComponents();

        DataView dv = mn.GetAll(20);
        com.FillDropDownList(ddlDepartment, dv, "name", "subdepartmentid");
    }
    private void Fill_Test()
    {
        clsBLMain mn = new clsBLMain();
        SComponents com = new SComponents();

        if (ddlDepartment.SelectedIndex > 0)
            mn.SubDepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
        DataView dv = mn.GetAll(21);
        com.FillDropDownList(ddlTest, dv, "name", "testid");
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Test();
    }
    private void Page_UnLoad(object sender, EventArgs e)
    {
        //if (IsPostBack)
        //{
        if (doc != null)
        {
            doc.Close();
            doc.Dispose();
            doc = null;
            GC.Collect();
        }

        //}
    }

}
