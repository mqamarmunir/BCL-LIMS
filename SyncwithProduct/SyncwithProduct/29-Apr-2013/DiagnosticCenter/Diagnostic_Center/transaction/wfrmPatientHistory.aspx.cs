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
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
//using CrystalDecisions.Web;
using System.IO;

public partial class transaction_wfrmPatientHistory : System.Web.UI.Page
{
    DataView dv;
   // protected CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
    //ReportDocument doc = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                Fill_GV(); 
                Fill_Test();
                SHow_Report();
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }

    private void Fill_GV()
    {
        clsBLResultEntry re = new clsBLResultEntry();
        re.TestID = Request.QueryString["testid"].ToString();
       // re.BookingID = Request.QueryString["bookingid"].ToString();
        re.PRID = Request.QueryString["prid"].ToString();

       // lblGenderAge.Text = Request.QueryString["genderage"].ToString();
        lblName.Text = Request.QueryString["name"].ToString();
        lblPRno.Text = Request.QueryString["prno"].ToString();
      //  lblTest.Text = Request.QueryString["testname"].ToString();

       //DataView dvAttr = re.GetAll(8);
       //dv = re.GetAll(9);

       // gvAttrib.DataSource = dvAttr;
       // gvAttrib.DataBind();
    }
    private void Fill_Test()
    {
        clsBLResultEntry mn = new clsBLResultEntry();
        SComponents com = new SComponents();

        mn.PRID = Request.QueryString["prid"].ToString();
        DataView dv = mn.GetAll(13);
        com.FillDropDownList(ddlTest, dv, "test_name", "testid");
        
    }

    protected void gvAttrib_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string str_attrib = gvAttrib.DataKeys[e.Row.DataItemIndex].Value.ToString();

            GridView gv = (GridView)e.Row.FindControl("gvResult");

            dv.RowFilter = "attributeid=" + str_attrib;
            gv.DataSource = dv;
            gv.DataBind();
        }
    }

    private void SHow_Report()
    {
        try
        {           

            // Put user code to initialize the page here
          //  string strRUrl = Server.MapPath(@"../Report/"+Request.QueryString["report"].ToString()+".rpt");
          //  //Response.Write("<script language ='javascript'>alert("+strRUrl+");</script>");
          //  //Session["ReportUrl"] = strRUrl;

          //doc = new ReportDocument();
          //  //CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
          //  int i;
          //  int j;

          //  doc.Load(strRUrl);
          // j = doc.Database.Tables.Count - 1;
          //  ////
            
          //  string dbName = "";
          // // string strConn = System.Configuration.ConfigurationManager.AppSettings["sapsConnectionString"].ToString();
          //  string StrConnection = null;
          //  string userName = "bc_lims";
          //  string pwd = "UVE02Do8ze";
          //  string serverName = "bc_lims";

          //  //string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
          //  //string[] info = strConn.Split(';');
          //  //userName = ((info[1].Split('='))[1]).Trim();
          //  //pwd = ((info[3].Split('='))[1]).Trim();
          //  //serverName = ((info[2].Split('='))[1]).Trim();

          //  //for (i = 0; i <= j; i++)
          //  //{
          //  //    TableLogOnInfo logOnInfo = new TableLogOnInfo();-----------
          //  //    logOnInfo = doc.Database.Tables[i].LogOnInfo;
          //  //    ConnectionInfo connectionInfo = new ConnectionInfo();
          //  //    connectionInfo = logOnInfo.ConnectionInfo;
          //  //    connectionInfo.ServerName = serverName;
          //  //    connectionInfo.Password = pwd;
          //  //    connectionInfo.UserID = userName;
          //  //    doc.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
          //  //}


          //  string StrSelectionForm = "";
          //  StrSelectionForm = "{command.prid} = " + Request.QueryString["prid"].ToString();

          //  StrSelectionForm += " and {command.testid} in ["+Request.QueryString["testid"].ToString()+"]";

          //  //if(ddlTest.SelectedIndex>0)
          //  //    StrSelectionForm += " And {command.testid} = " + ddlTest.SelectedItem.Value.ToString() + "  ";

          //  doc.RecordSelectionFormula = StrSelectionForm;

          // //CrystalReportViewer1.ReportSource = doc;
          // //CrystalReportViewer1.RefreshReport();

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this,typeof(Page),"warning","<script>alert('"+ex.Message+"');</script>",false);
        }
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        SHow_Report();

    }

    private void Page_UnLoad(object sender, EventArgs e)
    {
        //doc.Close();
        //doc.Dispose();
        //doc = null;
        GC.Collect();
    }
   
}
