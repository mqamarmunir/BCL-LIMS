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
//using CrystalDecisions.CrystalReports.Engine;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["personid"] = "";
        Session["branchID"] = "";
        Session["ClientID"] = "";
      
        //try
        //{
        //    //System.IO.File.Delete(Session["menu_xml"].ToString());
        //    //if (Session["ReportDoc"] != null)
        //    //{
        //    //    ReportDocument rptDoc = (ReportDocument)Session["ReportDoc"];
        //    //    rptDoc.Close();
        //    //    rptDoc.Dispose();
        //    //    GC.Collect();
        //    //}
        //}
        //catch { }
        //Session["menu_xml"] = "";
        Session.Clear();
        Session.Abandon();
        GC.Collect();
        Response.Redirect("Newlogin.aspx", true);
       
       
    }
}
