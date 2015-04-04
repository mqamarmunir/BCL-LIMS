using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.IO;
using BusinessLayer;
using AjaxControlToolkit;


public partial class transaction_CheckTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckTesting();
        }
    }


    public void CheckTesting()
    {
        string prid = Request.QueryString["prid"];
        string prno = Request.QueryString["prno"];
        string bookingdid = Request.QueryString["bookingid"];
        string testtype = Request.QueryString["testtype"];
        string labid = Request.QueryString["labid"];
        string testid = Request.QueryString["testid"];
        string subdepartmentid = Request.QueryString["subdepartmentId"].ToString();
        //Response.Write(prid+prno+bookingdid+testtype+labid);

        if (subdepartmentid == "3")
        {
            Response.Redirect("wfrmHistopathologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
        }
        else if (subdepartmentid == "13")
        {
            Response.Redirect("wfrmMicrobiologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
        }
        else
        {
            if (Request.QueryString["print"].ToString() == "print")
            {
                Response.Redirect("wfrmResultReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
            }
            else
            {
                Response.Redirect("Default.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
            }
        }
    }
}