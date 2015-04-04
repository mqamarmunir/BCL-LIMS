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

public partial class Report_wfrmPanelRpt : System.Web.UI.Page
{
  private static string _FromDate = "";
  private static string _ToDate = "";
  private static string _SelectionFormula = "";
  private static string _ReportName = "";

  //private static string _SubReportName = "";
  //private static string _SubSelectionFormula = "";

  //private static string _FromdateTime = "";
  //private static string _TodateTime = "";

  private string _Heading1 = "";
  private string _Heading2 = "";

  private string _NTN = "";
  private string _TelNo = "";
  private string _Footer = "";

  protected CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
  private static string _Message = "";
  ReportDocument doc = null;

  protected void Page_Load(object sender, EventArgs e)
  {
    Response.CacheControl = "no-cache";

    if (!Session.Equals(""))
    {
        if (!IsPostBack)
        {
            clsLogin log = new clsLogin();
            log.OptionId = "47";
            log.PersonId = Session["personid"].ToString();
            DataView dvLog = log.GetLogin(2);
            if (dvLog.Count > 0)
            {
                Fill_Panel();
                Fill_Year();
                txtDF.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
                txtDT.Text = DateTime.Now.ToString("dd/MM/yyyy");

                rdbOption.Items.FindByValue("B").Selected = true;
                rdbSelection.Items.FindByValue("S").Selected = true;

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
    ddlPanel.SelectedIndex = -1;

    lblErrorMsg.Visible = false;
    lblErrorMsg.Text = "";
    rbDay.Checked = true;
 

    pnlBilling.Visible = true;
    pnlAnalysis.Visible = false;

    txtDF.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
    txtDT.Text = DateTime.Now.ToString("dd/MM/yyyy");

    txtDiscount.Text = "0";

    //for (int i = ddlPanel.Items.Count - 1; i >= 1; i--)
    //{
    //  ddlPanel.Items.RemoveAt(i);
    //}
    ddlPanel.SelectedIndex = -1;
  }

  protected void imgReport_Click(object sender, ImageClickEventArgs e)
  {
    lblErrorMsg.Visible = false; 
    lblErrorMsg.Text = "";

    if (rdbOption.Items.FindByValue("B").Selected==true)
    {
      if (!txtDiscount.Text.Trim().Equals("") && Convert.ToInt16(txtDiscount.Text.Trim()) > 100)
      {
        lblErrorMsg.Visible = true;
        lblErrorMsg.Text = "Discount is less then 100%";
        return;
      }
      if (rdbSelection.Items.FindByValue("S").Selected ==true && ddlPanel.SelectedItem.Text.Equals("Select"))
      {
        lblErrorMsg.Visible = true;
        lblErrorMsg.Text = "Please Select Panel";
        return;
      }
      lblErrorMsg.Visible = false;
      lblErrorMsg.Text = "";

      
        ExportRpt(1);
        return;
    }
    if (rdbOption.Items.FindByValue("O").Selected == true)
    {        
        if (rdbSelection.Items.FindByValue("S").Selected == true && ddlPanel.SelectedItem.Text.Equals("Select"))
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = "Please Select Panel";
            return;
        }
        lblErrorMsg.Visible = false;
        lblErrorMsg.Text = "";


        ExportRpt(2);

    }
    //else if (rbAnalysis.Checked)
    //{
    //  if (!ddlAnaPanel.SelectedItem.Text.Equals("Select"))
    //  {
    //    if (rbDay.Checked)
    //    {
    //      ExportRpt(4);
    //    }
    //    else if (rbWeek.Checked)
    //    {
    //      ExportRpt(5);
    //    }
    //    else if (rbMonth.Checked)
    //    {
    //      ExportRpt(6);
    //    }
    //    else if (rbQuarter.Checked)
    //    {
    //      ExportRpt(7);
    //    }
    //    else if (rbYear.Checked)
    //    {
    //      ExportRpt(8);
    //    }
    //  }
      else
      {
        lblErrorMsg.Visible = true;
        lblErrorMsg.Text = "Please select Panel";
      }
    
  }

  private void Fill_Panel()
  {
    clsBLPanel objPanel = new clsBLPanel();
    SComponents objComp = new SComponents();

    DataView dv = objPanel.GetAll(5);
    objComp.FillDropDownList(ddlPanel, dv, "name", "PanelID");
    objComp.FillDropDownList(ddlAnaPanel, dv, "name", "PanelID");
  }

  private void Fill_Year()
  {
    clsBLPanel objPanel = new clsBLPanel();
    
    DataView dv = objPanel.GetAll(6);
    ddlYear.DataTextField = "Year";
    ddlYear.DataSource = dv;
    ddlYear.DataBind();
  }

  private void ExportRpt(int flag)
  {
    _ReportName = "Panel Report";
    string Days = "";
    string[] FDate = txtDF.Text.Split('/');
    string[] TDate = txtDT.Text.Split('/');

    Days = DateTime.DaysInMonth(Convert.ToInt16(ddlYear.SelectedItem.Text), Convert.ToInt16(ddlMonth.SelectedValue)).ToString();
    switch (flag)
    {
        case 1://dc_tpatient_bookingm
            _SelectionFormula = "{command.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";

            if (!rdbLab.SelectedItem.Value.ToString().Equals("A"))
                _SelectionFormula += " and {command.clientid}='" + this.rdbLab.SelectedItem.Value.ToString() + "'";
        if (ddlPanel.SelectedIndex > 0)
            _SelectionFormula += " and {command.panelid} =" + ddlPanel.SelectedValue;
        _ReportName = "Panel_statement_new";

        break;
      case 2:
          _SelectionFormula = "{command.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") ";
          if (!rdbLab.SelectedItem.Value.ToString().Equals("A"))
              _SelectionFormula += " and {command.clientid}='" + this.rdbLab.SelectedItem.Value.ToString() + "'";
          if (ddlPanel.SelectedIndex > 0)
              _SelectionFormula += " and {command.panelid} =" + ddlPanel.SelectedValue;
        _ReportName = "Panel_outstanding";

        break;
      case 3:
        _SelectionFormula = "{dc_tpatient_bookingm.enteredon} in date(" + FDate[2] + "," + FDate[1] + "," + FDate[0] + ") to date(" + TDate[2] + "," + TDate[1] + "," + TDate[0] + ") and {dc_tpanel.panelid} =" + ddlPanel.SelectedValue;
        //_SelectionFormula = "{dc_tpanel.panelid} =" + ddlPanel.SelectedValue;
        _ReportName = "Panel2";

        break;
      case 4:
        _SelectionFormula = "{dc_tpatient_bookingm.enteredon} in date("+ ddlYear.SelectedItem.Text + "," + ddlMonth.SelectedValue + ",01) to date(" + ddlYear.SelectedItem.Text + "," + ddlMonth.SelectedValue + "," + Days + ") and {dc_tpatient.panelid} =" + ddlAnaPanel.SelectedValue;
        _ReportName = "Graph1";

        break;

      case 5:
        _SelectionFormula = "{dc_tpatient_bookingm.enteredon} in date(" + ddlYear.SelectedItem.Text + "," + ddlMonth.SelectedValue + ",01) to date(" + ddlYear.SelectedItem.Text + "," + ddlMonth.SelectedValue + "," + Days + ") and {dc_tpatient.panelid} =" + ddlAnaPanel.SelectedValue;
        _ReportName = "Graph2";

        break;

      case 6:
        _SelectionFormula = "{dc_tpatient_bookingm.enteredon} in date(" + ddlYear.SelectedItem.Text + ",01,01) to date(" + ddlYear.SelectedItem.Text + ",12,31) and {dc_tpatient.panelid} =" + ddlAnaPanel.SelectedValue;
        _ReportName = "Graph3";

        break;
      
      case 7:
        _SelectionFormula = "{dc_tpatient_bookingm.enteredon} in date(" + ddlYear.SelectedItem.Text + ",01,01) to date(" + ddlYear.SelectedItem.Text + ",12,31) and {dc_tpatient.panelid} =" + ddlAnaPanel.SelectedValue;
        _ReportName = "Graph4";

        break;
      case 8:
        _SelectionFormula = "{dc_tpatient.panelid} =" + ddlAnaPanel.SelectedValue;
        _ReportName = "Graph5";

        break;

    }


    try
    {
      // Put user code to initialize the page here
      string strRUrl = Server.MapPath(@"../Report/" + _ReportName + ".rpt");
      Session["ReportUrl"] = strRUrl;
      doc = new ReportDocument();
      int i;
      int j;
      doc.Load(strRUrl);
      j = doc.Database.Tables.Count - 1;
      string userName = "bc_lims";
      string pwd = "UVE02Do8ze";
      string serverName = "bc_lims";

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

      _Heading1 = "BIOCARE Labs (Private) Ltd.";
      _Heading2 = "Office No. 3, 4 Mezannine Floor, Asif Plaza Fazal e Haq Road, Blue Area Islamabad" +
"\nPhone: 051-8350225       Fax:051-8440225" +
"\nhttp://biocarelabs.org";

      _NTN = "";
      _TelNo = "";
      _Footer="All Cheque payable in the name of \"BIOCARE Labs (Private) Ltd\".";

      //if (rbBi.Checked)
      //{
        try
        {
          doc.SetParameterValue("Discount", txtDiscount.Text.Trim().Replace("___","").Equals("")?"0": txtDiscount.Text.Trim());
        }
        catch{}
        try
        {
          doc.SetParameterValue("From", txtDF.Text.Trim());
        }
        catch{}

        try
        {
          doc.SetParameterValue("To", txtDT.Text.Trim());
        }
        catch{}
        try
        {
          doc.SetParameterValue("CompName", ddlPanel.SelectedItem.Text);
        }
        catch{}

        try
        {
          doc.SetParameterValue("Footer1", _Footer);
        }
        catch{}
        doc.SetParameterValue("origin", rdbLab.SelectedItem.Text);
     // }
      //if (rbAnalysis.Checked)
      //{
      //  try
      //  {
      //    doc.SetParameterValue("CompName", ddlAnaPanel.SelectedItem.Text);
      //  }
      //  catch{}
      //  try
      //  {
      //    doc.SetParameterValue("From", ddlYear.SelectedItem.Text);
      //  }
      //  catch{}

      //  try
      //  {
      //    doc.SetParameterValue("To", ddlMonth.SelectedItem.Text);
      //  }
      //  catch{}
      //  try
      //  {
      //    doc.SetParameterValue("Footer1", "Footer");
      //  }
      //  catch{}
      //}

      try
      {
        doc.SetParameterValue("Heading1", _Heading1);
      }
      catch { }

      try
      {
        doc.SetParameterValue("Heading2", _Heading2);
      }
      catch { }
      try
      {
        doc.SetParameterValue("NTN", _NTN);
      }
      catch { }

      try
      {
        doc.SetParameterValue("TelNo", _TelNo);
      }
      catch { }

      CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
      string szFileName = Server.MapPath(@"pdf/Panel.pdf");
      dfdoCustomers.DiskFileName = szFileName;
      doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
      doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
      doc.ExportOptions.DestinationOptions = dfdoCustomers;
      doc.Export();

      ScriptManager.RegisterStartupScript(this, typeof(Page), "Panel Report", @"<script>window.open('pdf/Panel.pdf');</script>", false); 
      //Response.Redirect(@"../Report/pdf/Panel.pdf");
    }
    catch (Exception ex)
    {
      _Message = ex.Message + " " + _ReportName + " " + _SelectionFormula;
    }
  }


 
  protected void rbDay_CheckedChanged(object sender, EventArgs e)
  {
    if (rbDay.Checked || rbWeek.Checked)
    {
      lblMonth.Visible = true;
      lblYear.Visible = true;
      ddlYear.Visible = true;
      ddlMonth.Visible=true;
    }
    else if (rbMonth.Checked || rbQuarter.Checked)
    {
      lblMonth.Visible = false ;
      lblYear.Visible = true;
      ddlYear.Visible = true;
      ddlMonth.Visible = false ;   
    }
    else if (rbYear.Checked)
    {
      lblMonth.Visible = false ;
      lblYear.Visible = false ;
      ddlYear.Visible = false ;
      ddlMonth.Visible = false ;
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
    protected void rdbSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbSelection.Items.FindByValue("A").Selected == true)
            ddlPanel.SelectedIndex = 0;
    }
}
