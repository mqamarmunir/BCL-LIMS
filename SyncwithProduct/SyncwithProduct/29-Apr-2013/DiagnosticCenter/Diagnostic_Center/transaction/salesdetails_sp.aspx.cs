using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

public partial class transaction_salesdetails_sp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";

        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "57";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillBranchddl();
                    ddlBranch.ClearSelection();
                    ddlBranch.Items.FindByValue(Session["Branchid"].ToString().Trim()).Selected = true;
                    Fill_Panel();

                   // txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                  //  txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    rdbType.Items.FindByValue("A").Selected = true;
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
        objComp.FillDropDownList(ddlPanel, dv, "name", "PanelID", true, true, true);
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtPrNo.Text = "";
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        #region HTML report code
        //if (txtPrNo.Text.Trim().Replace("___-__-________", "").Equals("") && txtadmno.Text.Trim().Equals(""))
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerT", "<script>alert('Please enter pr no or Admission no')</script>", false);
        //    return;
        //} ---------------------------------link for old sales detail Report
       // ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('salesdetails_report.aspx?branchid="+ddlBranch.SelectedValue.ToString().Trim()+"&Panelid="+ddlPanel.SelectedValue.ToString().Trim()+"&prno="+ txtPrNo.Text + "&labid=" + txtlabid.Text.Trim() + "&datefrom=" + txtFrom.Text.Trim() + "&dateto=" + txtTo.Text.Trim() + "');</script>", false);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "CashSummary", "<script>window.open('../report/Report/Rpt_CashInvoice.aspx?branchID=" + ddlBranch.SelectedValue.ToString() + "&panelid=" + ddlPanel.SelectedValue.ToString() + "&Consultant=-1&datefrom=" + txtFrom.Text.Trim() + "&dateto=" + txtTo.Text.Trim() + "&type=A');</script>", false);

        #endregion

        #region Crystal report code
        //if (txtPrNo.Text.Trim().Replace("___-__-________", "").Equals(""))
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerT", "<script>alert('Please enter pr no')</script>", false);
        //    return;
        //}
        //clsBLMain mn = new clsBLMain();
        //mn.PRNO = this.txtPrNo.Text.Trim();
        //DataView dv = mn.GetAll(26);
        //if (dv.Count > 0)
        //{ }
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerT", "<script>alert('PR No not found')</script>", false);
        //    return;
        //}

        //string[] FDate = txtFrom.Text.Split('/');
        //string[] TDate = txtTo.Text.Split('/');


        //string _SelectionFormula = "{command.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";

        //if (!txtPrNo.Text.Trim().Replace("___-__-________", "").Equals(""))
        //    _SelectionFormula += " and {command.prno} = '" + txtPrNo.Text.Trim() + "'";
        //if (!rdbType.SelectedItem.Value.ToString().Equals("A"))
        //    _SelectionFormula += " and {command.ind_outdoor}='" + rdbType.SelectedItem.Value.ToString() + "'";


        //try
        //{
        //    // Put user code to initialize the page here
        //    string strRUrl = Server.MapPath(@"../Report/Indoor_PatientSheet.rpt");
        //    Session["ReportUrl"] = strRUrl;

        //    //CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //    int i;
        //    int j;
        //    doc.Load(strRUrl);
        //    j = doc.Database.Tables.Count - 1;
        //    string userName = "bc_lims";
        //    string pwd = "UVE02Do8ze";
        //    string serverName = "bc_lims";

        //    //string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
        //    //string[] info = strConn.Split(';');
        //    //userName = ((info[1].Split('='))[1]).Trim();
        //    //pwd = ((info[3].Split('='))[1]).Trim();
        //    //serverName = ((info[2].Split('='))[1]).Trim();

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
        //        doc.SetParameterValue("sdate", txtFrom.Text.Trim());
        //    }
        //    catch { }


        //    try
        //    {
        //        doc.SetParameterValue("tdate", txtTo.Text.Trim());
        //    }
        //    catch { }


        //    CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
        //    string szFileName = Server.MapPath(@"pdf/Indoor_PatientSheet.pdf");
        //    dfdoCustomers.DiskFileName = szFileName;
        //    doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
        //    doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
        //    doc.ExportOptions.DestinationOptions = dfdoCustomers;
        //    doc.Export();

        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Ordering Summary", @"<script>window.open('pdf/Indoor_PatientSheet.pdf');</script>", false);



        //}
        //catch (Exception ex)
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
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