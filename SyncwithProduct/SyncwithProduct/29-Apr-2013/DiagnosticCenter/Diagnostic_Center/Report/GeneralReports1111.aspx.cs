using System;
using System.Configuration;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;


public partial class WebForms_GeneralReports : System.Web.UI.Page
{
    private string _FromDate = "";
    private string _ToDate = "";
    private string _SelectionFormula = "";
    private string _ReportName = "";

    private string _SubReportName = "";
    private string _SubSelectionFormula = "";

    private string _FromdateTime = "";
    private string _TodateTime = "";

    //protected CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
    private  string _Message = "";
    ReportDocument doc = null;

    # region "Properties"
    public string ReportName
    {
        get
        {
            return _ReportName;
        }

        set
        {
            _ReportName = value;
        }
    }

    public string FromDate
    {
        get
        {
            return _FromDate;
        }
        set
        {
            _FromDate = value;
        }
    }


    public string ToDate
    {
        get
        {
            return _ToDate;
        }
        set
        {
            _ToDate = value;
        }
    }

    public string SelectionFormula
    {
        get
        {
            return _SelectionFormula;
        }
        set
        {
            _SelectionFormula = value;
        }
    }

    public string Message
    {
        get
        {
            return _Message;
        }
        set
        {
            //
        }
    }
    public string FromDateTime
    {
        get { return _FromdateTime; }
        set { _FromdateTime = value; }
    }
    public string TodateTime
    {
        get { return _TodateTime; }
        set { _TodateTime = value; }
    }

    # endregion

    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            //            
            _SelectionFormula = Session["selectionformula"].ToString();
            _ReportName = Session["reportname"].ToString();
            //_FromDate = clsBLReport.FromDate;
            //_ToDate = clsBLReport.ToDate;
            //_SubReportName = clsBLReport.SubReportName;
            //_SubSelectionFormula = clsBLReport.sSubSelectionFormula;
            //_FromdateTime = clsBLReport.FromDateTime;
            //_TodateTime = clsBLReport.ToDateTime;
            //
                                   
            //else if (Request.QueryString["reporttype"].Trim().Equals("worklist"))
            //{
            //    _SelectionFormula = "{vworklist.worklistno} = '" + Request.QueryString["worklistno"].Trim() + "'";
            //}
         
           
        }
        try
        {
            // Put user code to initialize the page here
            string strRUrl = Server.MapPath(@"../Report/" + _ReportName + ".rpt");
            Session["ReportUrl"] = strRUrl;
            doc = new ReportDocument();
          
                doc.Load(strRUrl);

                doc.SetDatabaseLogon("afh_lims", "56nN9CRIjd", "afh_lims", "afh_lims");
                if (_SelectionFormula != "")
                    doc.RecordSelectionFormula = _SelectionFormula;

                _SelectionFormula = doc.RecordSelectionFormula;

                //if (!_SubReportName.Equals(""))
                //{

                //    Subreports sr = doc.Subreports; // for subreport
                //    sr[0].RecordSelectionFormula = _SubSelectionFormula;

                //}           
                try
                {
                    doc.SetParameterValue("SDate", _FromDate);
                }
                catch { }

                try
                {
                    doc.SetParameterValue("EDate", _ToDate);
                }
                catch { }

                crvGeneral.ReportSource = doc;
                Session["reportdoc"] = doc;
                // crvGeneral.RefreshReport();
           

        }
        catch (Exception ex)
        {
            _Message = ex.Message + " " + _ReportName + " " + _SelectionFormula;
        }
        
    }
    private void Page_UnLoad(object sender, EventArgs e)
    {
        //doc.Close();
        //doc.Dispose();
        //doc = null;
        //GC.Collect();
       
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
    //    try
    //    {
    //        _SelectionFormula = Session["selectionformula"].ToString();
    //        _ReportName = Session["reportname"].ToString();
    //        // Put user code to initialize the page here
    //        string strRUrl = Server.MapPath(@"../Report/" + _ReportName + ".rpt");
    //        Session["ReportUrl"] = strRUrl;
    //        doc = new ReportDocument();

    //        doc.Load(strRUrl);

    //        doc.SetDatabaseLogon("afh_lims", "56nN9CRIjd", "afh_lims", "afh_lims");
    //        if (_SelectionFormula != "")
    //            doc.RecordSelectionFormula = _SelectionFormula;

    //        _SelectionFormula = doc.RecordSelectionFormula;

    //        //if (!_SubReportName.Equals(""))
    //        //{

    //        //    Subreports sr = doc.Subreports; // for subreport
    //        //    sr[0].RecordSelectionFormula = _SubSelectionFormula;

    //        //}           
    //        try
    //        {
    //            doc.SetParameterValue("SDate", _FromDate);
    //        }
    //        catch { }

    //        try
    //        {
    //            doc.SetParameterValue("EDate", _ToDate);
    //        }
    //        catch { }

    //        crvGeneral.ReportSource = doc;
    //        // crvGeneral.RefreshReport();
    //       if(doc.IsLoaded==true)
    //        doc.PrintToPrinter(1, false, 0, 0);
    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('"+ex.Message+"');</script>", false);
    //    }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

    //    _SelectionFormula = Session["selectionformula"].ToString();
    //    _ReportName = Session["reportname"].ToString();
    //    // Put user code to initialize the page here
    //    string strRUrl = Server.MapPath(@"../Report/" + _ReportName + ".rpt");
    //    Session["ReportUrl"] = strRUrl;
    //    doc = new ReportDocument();

    //    doc.Load(strRUrl);

    //    doc.SetDatabaseLogon("afh_lims", "56nN9CRIjd", "afh_lims", "afh_lims");
    //    if (_SelectionFormula != "")
    //        doc.RecordSelectionFormula = _SelectionFormula;

    //    _SelectionFormula = doc.RecordSelectionFormula;

    //    //if (!_SubReportName.Equals(""))
    //    //{

    //    //    Subreports sr = doc.Subreports; // for subreport
    //    //    sr[0].RecordSelectionFormula = _SubSelectionFormula;

    //    //}           
    //    try
    //    {
    //        doc.SetParameterValue("SDate", _FromDate);
    //    }
    //    catch { }

    //    try
    //    {
    //        doc.SetParameterValue("EDate", _ToDate);
    //    }
    //    catch { }

    //    crvGeneral.ReportSource = doc;
    //    // crvGeneral.RefreshReport();

    //    MemoryStream oStream; // using System.IO
    //    oStream = (MemoryStream)
    //    doc.ExportToStream(
    //    CrystalDecisions.Shared.ExportFormatType.WordForWindows);
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.ContentType = "application/msword";
    //    Response.BinaryWrite(oStream.ToArray());
    //    Response.End();
    }
}
