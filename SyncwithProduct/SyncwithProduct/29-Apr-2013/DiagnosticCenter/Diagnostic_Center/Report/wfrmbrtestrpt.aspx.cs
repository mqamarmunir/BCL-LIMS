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

public partial class Report_wfrmbrtestrpt : System.Web.UI.Page
{
    private ReportDocument doc = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillBranchddl();
            FillSubdepartmentddl();
        }

    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        string[] FDate = txtFrom.Text.Split('/');
        string[] TDate = txtto.Text.Split('/');
        string _SelectionFormula = "";
        string _Sub_Formula = "";

        _SelectionFormula = "date({command.enteredon}) in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";
       if(ddlBranch.SelectedValue.ToString()!="-1")
       {
           _SelectionFormula += " and {command.branchid}=" + ddlBranch.SelectedValue.ToString();
       }

       if (ddlsubdep.SelectedValue.ToString() != "-1")
       {
           _SelectionFormula += " and {command.subdepartmentid}=" + ddlsubdep.SelectedValue.ToString();
       }
        // _Sub_Formula = "date({dc_vref_cc.refDate}) in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";

        try
        {
            // Put user code to initialize the page here
            string strRUrl = Server.MapPath(@"../Report/rptTestSummary.rpt");
            Session["ReportUrl"] = strRUrl;

            int i;
            int j;
            doc.Load(strRUrl);
            j = doc.Database.Tables.Count - 1;
            string userName = "bc_lims";//bc_lims
            string pwd = "UVE02Do8ze";//UVE02Do8ze
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

            //doc.Subreports[0].RecordSelectionFormula = _Sub_Formula;
            //doc.SetDataSource(dt.Table);

            try
            {
                doc.SetParameterValue("fromdate", txtFrom.Text.Trim());
            }
            catch { }


            try
            {
                doc.SetParameterValue("todate", txtto.Text.Trim());
            }
            catch { }

            CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            string szFileName = Server.MapPath(@"pdf/rptTestSummary.pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Branchwise test Summary", @"<script>window.open('pdf/rptTestSummary.pdf');</script>", false);



        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
        }
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {

    }
    private void FillBranchddl()
    {
        clsBLBranch objbranch = new clsBLBranch();
        DataView dv_branch = objbranch.GetAll(3);
        if (dv_branch.Count > 0)
        {
            SComponents obj_com = new SComponents();
            obj_com.FillDropDownList(ddlBranch, dv_branch, "Name", "BranchID", true, true, true);
        }

    }
    private void FillSubdepartmentddl()
    {
        clsBLBranch objbranch = new clsBLBranch();
        DataView dv_branch = objbranch.GetAll(9);
        if (dv_branch.Count > 0)
        {
            SComponents obj_com = new SComponents();
            obj_com.FillDropDownList(ddlsubdep, dv_branch, "name", "subdepartmentid", true, true, true);
        }
    }
}