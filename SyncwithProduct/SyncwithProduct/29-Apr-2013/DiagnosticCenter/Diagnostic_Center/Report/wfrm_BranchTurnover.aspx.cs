using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

public partial class Report_wfrm_BranchTurnover : System.Web.UI.Page
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
                log.OptionId = "50";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
              

                    txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    //try
                    //{
                    //   // rdbFranc.ClearSelection();
                    //   // rdbLab.Items.FindByValue(System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString()).Selected = true;
                    //}
                    //catch { }

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
    protected void rdbNet_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbNet.Checked == true)
        {
            FillgvBranch();
        }
    }
    protected void rdbGross_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbGross.Checked == true)
        {
            FillgvBranch();
        }
    }
    protected void rdbFranc_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbFranc.Checked == true)
        {
            FillgvBranch();
        }

    }

    private void FillgvBranch()
    {
        clsBLBranch objbranch = new clsBLBranch();
        if (rdbNet.Checked == true)
        {
            objbranch.Type = "S";
            objbranch.BusinessPolicy = "N";
        }
        else if (rdbGross.Checked == true)
        {
            objbranch.Type = "S";
            objbranch.BusinessPolicy = "G";
        }
        else if (rdbFranc.Checked == true)
        {
            objbranch.Type = "F";
        }

        DataView dv_Branches = objbranch.GetAll(7);
        if (dv_Branches.Count > 0)
        {
            gvBranches.DataSource = dv_Branches;
            gvBranches.DataBind();
        }
        else
        {
            gvBranches.DataSource = "";
            gvBranches.DataBind();
        }
        
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        rdbFranc.Checked = false;
        rdbNet.Checked = false;
        rdbGross.Checked = false;
        txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
        
        gvBranches.DataSource = "";
        gvBranches.DataBind();
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");

    }
    protected void  imgReport_Click(object sender,ImageClickEventArgs e)
    {
        string[] FDate = txtFrom.Text.Split('/');
        string[] TDate = txtTo.Text.Split('/');
        string _SelectionFormula = "1=1";
        string branchids = "";
        int count=0;
        _SelectionFormula += " and {Command.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";
        foreach (GridViewRow row in gvBranches.Rows)
        {
            if (((CheckBox)gvBranches.Rows[row.RowIndex].Cells[2].FindControl("gvchkbranch")).Checked == true)
            {
                branchids += gvBranches.DataKeys[row.RowIndex].Value.ToString().Trim() + "," ;
                count++;
            }
        }

        
        if (count > 0)
        {
            branchids += "15000";
            _SelectionFormula += " and {Command.BranchID} in [" + branchids + "]";
        }
        //if (rdbFranc.Checked == true)
        //{
        //    _SelectionFormula += " and {Command.brtype}=Franchise";
        //}
        //else if (rdbGross.Checked == true)
        //{
        //    _SelectionFormula += " and {Command.brtype}=Gross";
        //}
        //else if (rdbNet.Checked == true)
        //{
        //    _SelectionFormula += " and {Command.brtype}=Net Amount";
        //}

        try
        {
            string strRUrl = "";
            // Put user code to initialize the page here
            if (rdbFranc.Checked == true)
            {
               strRUrl = Server.MapPath(@"../Report/Branch_Franchise.rpt");
            }
            else if (rdbGross.Checked == true)
            {
                strRUrl = Server.MapPath(@"../Report/Branch_Gross.rpt");
            }
            else if (rdbNet.Checked == true)
            {
                strRUrl = Server.MapPath(@"../Report/Branch_Net.rpt");
            }
                Session["ReportUrl"] = strRUrl;

            //CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            int i;
            int j;
            doc.Load(strRUrl);
            j = doc.Database.Tables.Count - 1;
            string userName = "bc_lims";//
            string pwd = "UVE02Do8ze";//
            string serverName = "bc_lims";//

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
                doc.SetParameterValue("SDate", txtFrom.Text.Trim());
            }
            catch { }


            try
            {
                doc.SetParameterValue("EDate", txtTo.Text.Trim());
            }
            catch { }
            
            CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
           
            string szFileName = Server.MapPath(@"pdf/branchtest_turnovr.pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();
      
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Franchis Test Ordering Summary", @"<script>window.open('pdf/branchtest_turnovr.pdf');</script>", false);
            
          
        }

        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
       
        }
    }

}