﻿using System;
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
       string bookingdid =  Request.QueryString["bookingid"];
       string testtype =  Request.QueryString["testtype"];
       string labid = Request.QueryString["labid"];
       string testid = Request.QueryString["testid"];
       string subdepartmentid = Request.QueryString["subdepartmentId"].ToString();
       //Response.Write(prid+prno+bookingdid+testtype+labid);

       if (subdepartmentid == "3")
       {
           Response.Redirect("wfrmHistopathologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid +"&subdepartmentid="+ subdepartmentid);

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
               clsReporting report = new clsReporting();
               DataView dv = new DataView();

               report.Prno = Request.QueryString["prno"].ToString();
               report.Labid = Request.QueryString["labid"].ToString();
               report.TestId = Request.QueryString["testid"].ToString();
               report.SubdepartmentId = Request.QueryString["subdepartmentid"].ToString();
               dv = report.GetAll(23);
               for (int i = 0; i < dv.Count; i++)
               {
                   testid = dv[i]["testid"].ToString();
                   if (dv[i]["subdepartmentid"].ToString() == "3")
                   {
                       ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('wfrmHistopathologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString()+"');</script>", false);
                  
                   }
                   else if (dv[i]["subdepartmentid"].ToString() == "13")
                   {
                       ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('wfrmMicrobiologyReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString()+"');</script>", false);
                   }
                   else
                   {
                       
                       // ClientScript.RegisterStartupScript(this, typeof(Page), "Patient Report", "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "');</script>", false);
                       ScriptManager.RegisterStartupScript(this, typeof(Page), "Patient Report" + i.ToString(), "<script>window.open('wfrmResultReport.aspx?prid=" + prid + "&prno=" + prno + "&bookingdid=" + bookingdid + "&testtype=" + testtype + "&labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + dv[i]["subdepartmentid"].ToString() + "');</script>", false);
                   }
               }
              // Response.Redirect("RptGeneralReport.aspx?prid=" + prid + " &prno=" + prno + " &bookingdid=" + bookingdid + " &testtype=" + testtype + " &labid=" + labid + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid);
               PrintOn.Text = "All reports has been generated successfully.";
               Image_Print.Visible = true;
           }
       }
        


    }
}