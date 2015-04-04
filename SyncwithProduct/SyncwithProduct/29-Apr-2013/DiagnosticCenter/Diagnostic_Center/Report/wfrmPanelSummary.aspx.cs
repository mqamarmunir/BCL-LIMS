using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

public partial class Report_wfrmPanelSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "48";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillBranchddl();
                    ddlBranch.ClearSelection();
                    ddlBranch.Items.FindByValue(Session["Branchid"].ToString().Trim()).Selected = true;
                    //  Fill_Consultant();
                    Fill_Panel();

                    txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

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
            Response.Redirect("../NewLogin.aspx");
        }
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

    private void Fill_Panel()
    {
        clsBLPanel objPanel = new clsBLPanel();
        SComponents objComp = new SComponents();

        DataView dv = objPanel.GetAll(5);
        objComp.FillDropDownList(ddlPanel, dv, "name", "PanelID",true,true,true);       
    }
    //private void Fill_Consultant()
    //{
    //    clsBLMain mn = new clsBLMain();
    //    SComponents com = new SComponents();

    //    DataView dv = mn.GetAll(19);
    //    com.FillDropDownList(ddlConsultant, dv, "consultant", "doctorid",true,true,true);
    //}



    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        //ddlConsultant.SelectedIndex = -1;
        ddlPanel.SelectedIndex = -1;

        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        #region HTMlreport call
        ScriptManager.RegisterStartupScript(this, typeof(Page), "CashSummary", "<script>window.open('RptPanelRenderSummary.aspx?branchID=" + ddlBranch.SelectedValue.ToString() + "&panelid=" + ddlPanel.SelectedValue.ToString() + "&datefrom=" + txtFrom.Text.Trim() + "&dateto=" + txtTo.Text.Trim() + "');</script>", false);
         
        #endregion
        #region Crystal Reports Code
        //string[] FDate = txtFrom.Text.Split('/');
        //string[] TDate = txtTo.Text.Split('/');

        //_SelectionFormula = " {dc_tpatient_bookingm.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";
        //if (!rdbLab.SelectedItem.Value.ToString().Equals("A"))
        //    _SelectionFormula += " and {dc_tpatient_bookingm.clientid}='" + this.rdbLab.SelectedItem.Value.ToString() + "'";

        //if (ddlPanel.SelectedIndex > 0)
        //    _SelectionFormula += " and {dc_tpanel.panelid} =" + ddlPanel.SelectedItem.Value;
        //if (ddlConsultant.SelectedIndex > 0)
        //    _SelectionFormula += " and {dc_tp_refdoctors.doctorid} =" + ddlConsultant.SelectedItem.Value ;
        //_ReportName = "cashsummary";
        //try
        //{
        //    // Put user code to initialize the page here
        //    string strRUrl = Server.MapPath(@"../Report/" + _ReportName + ".rpt");
        //    Session["ReportUrl"] = strRUrl;
        //    doc = new ReportDocument();
        //    int i;
        //    int j;
        //    doc.Load(strRUrl);
        //    j = doc.Database.Tables.Count - 1;
        //    string userName = "bc_lims";
        //    string pwd = "UVE02Do8ze";
        //    string serverName = "bc_lims";

        //    for (i = 0; i <= j; i++)
        //    {
        //        TableLogOnInfo logOnInfo = new TableLogOnInfo();
        //        logOnInfo = doc.Database.Tables[i].LogOnInfo;
        //        ConnectionInfo connectionInfo = new ConnectionInfo();
        //        connectionInfo = logOnInfo.ConnectionInfo;
        //        connectionInfo.ServerName = serverName;
        //        connectionInfo.Password = pwd;
        //        connectionInfo.UserID = userName;
        //        doc.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
        //    }

        //    if (_SelectionFormula != "")
        //        doc.RecordSelectionFormula = _SelectionFormula;

        //    _SelectionFormula = doc.RecordSelectionFormula;

           
           
        //    try
        //    {
        //        doc.SetParameterValue("date","From: " +txtFrom.Text.Trim()+"  To:"+txtTo.Text.Trim());
        //    }
        //    catch { }

        //    try
        //    {
        //        if (ddlPanel.SelectedIndex > 0)
        //            doc.SetParameterValue("panel", ddlPanel.SelectedItem.Text.Trim());
        //        else
        //            doc.SetParameterValue("panel", "ALL");
        //    }
        //    catch { }
        //    try
        //    {
        //        if (ddlConsultant.SelectedIndex > 0)
        //            doc.SetParameterValue("consultant", ddlConsultant.SelectedItem.Text.Trim());
        //        else
        //            doc.SetParameterValue("consultant", "ALL");
        //    }
        //    catch { }
        //    doc.SetParameterValue("origin", rdbLab.SelectedItem.Text);

        //    string _SubFormula = "1=1 ";
        //    if (!rdbLab.SelectedItem.Value.ToString().Equals("A"))
        //        _SubFormula += " and {command.clientid}='" + rdbLab.SelectedItem.Value.ToString().Replace("A", "1=1") + "'";
        //    _SubFormula += " and {command.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + " )";

        //    doc.Subreports[0].RecordSelectionFormula = _SubFormula;
        //        //" {command.clientid}='" + rdbLab.SelectedItem.Value.ToString().Replace("A", "1=1") + "'  and {command.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + " ) ";
        //    CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
        //    string szFileName = Server.MapPath(@"pdf/Cash_Summary.pdf");
        //    dfdoCustomers.DiskFileName = szFileName;
        //    doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
        //    doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
        //    doc.ExportOptions.DestinationOptions = dfdoCustomers;
        //    doc.Export();

        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Panel Report", @"<script>window.open('pdf/Cash_Summary.pdf');</script>", false);
        //    //Response.Redirect(@"../Report/pdf/Panel.pdf");
        //}
        //catch (Exception ex)
        //{
        //    _Message = ex.Message + " " + _ReportName + " " + _SelectionFormula;
        //}
        #endregion
    }
    private void Page_UnLoad(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //    doc = null;
        //    GC.Collect();
        //}

    }

}