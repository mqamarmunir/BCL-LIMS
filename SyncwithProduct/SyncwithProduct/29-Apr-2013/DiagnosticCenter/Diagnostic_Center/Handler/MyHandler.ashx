<%@ WebHandler Language="C#" Class="MyHandler" %>

using System;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using BusinessLayer;
using ServiceReference2;
using System.Data;
using System.Text;

public class MyHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        //System.Threading.Thread t = new System.Threading.Thread();
        //t.Start();
        var employee = FillNotifications(context);

        //Do the operation as required
        //context.Response.ContentType = "text/html";
        //context.Response.Write(employee);
        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        string serEmployee = javaScriptSerializer.Serialize(employee);
        context.Response.ContentType = "text/html";
        context.Response.Write(serEmployee);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    private string GetData()
    {
     //   string returnresult=FillNotifications();
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
      //  sb.Append("ID:" + Id);
      ////  sb.Append("<br />");
      //  sb.Append("Name:Brij");
      // // sb.Append("<br />");
      //  sb.Append("Age:27");
      // // sb.Append("<br />");
      //  sb.Append("Department:Research And Development");


       // var employee = new clsBLAlerts();
       // employee.AlertTypeID = Id.ToString();
       // employee.Name = "Brij";
       //// employee.Age = 27;
        //employee.Department = "ResearchandDevelopment";

        //Write your logic here
        return "";
       // return returnresult;
    }
    private string FillNotifications(HttpContext context)
    {
        try
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();
            clsBLPatientReg_Inv obj_patient = new clsBLPatientReg_Inv();
            DataView dv_notifications = obj_patient.GetAll(51);//Includes those requests that have been sent for discount approval to management and has been approved or disapproved by management
            if (dv_notifications.Count > 0)
            {
                count++;
                for (int i = 0; i < dv_notifications.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        sb.Append("<li class='notify'>");
                        sb.Append("<a href='../transaction/wfrmpatientreceipttemp.aspx?bookingid=" + dv_notifications[i]["bookingid"].ToString() + "&cancelled=" + dv_notifications[i]["Cancelled"].ToString() + "'>");
                        //  sb.Append("<p>");
                        sb.Append(dv_notifications[i]["status"].ToString().Trim());// + " new Visit Requests from " + ds.Tables[0].Rows[i]["organization"].ToString().Trim());
                        //sb.Append("</p>");
                        sb.Append("</a>");
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("<li class='notify'>");
                        sb.Append("<a href='../transaction/wfrmpatientreceipttemp.aspx?bookingid=" + dv_notifications[i]["bookingid"].ToString() + "&Cancelled=" + dv_notifications[i]["Cancelled"].ToString() + "'>");
                        //  sb.Append("<p>");
                        sb.Append(dv_notifications[i]["status"].ToString().Trim());// + " new Visit Requests from " + ds.Tables[0].Rows[i]["organization"].ToString().Trim());
                        //sb.Append("</p>");
                        sb.Append("</a>");
                        sb.Append("</li>");
                    }
                }
            }
            try
            {
                OliveService obj_service = new OliveService();

                DataSet ds = obj_service.GetPanelTestRequests(context.Session["cliqbranchid"].ToString().Trim());// Includes those requests that are sent from Health Access
                if (ds.Tables[0].Rows.Count > 0)
                {
                    count++;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            sb.Append("<li class='notify'>");
                            sb.Append("<a href='../transaction/PanelREquestsDetail.aspx?panel=" + ds.Tables[0].Rows[i]["cliq_panel_id"].ToString() + "'>");
                            //  sb.Append("<p>");
                            sb.Append(ds.Tables[0].Rows[i]["requests"].ToString().Trim() + " new Visit Requests from " + ds.Tables[0].Rows[i]["organization"].ToString().Trim());
                            //sb.Append("</p>");
                            sb.Append("</a>");
                            sb.Append("</li>");
                        }
                        else
                        {
                            sb.Append("<li class='notify'>");
                            sb.Append("<a href='../transaction/PanelREquestsDetail.aspx?panel=" + ds.Tables[0].Rows[i]["cliq_panel_id"].ToString() + "'>");
                            sb.Append("<p>");
                            sb.Append(ds.Tables[0].Rows[i]["requests"].ToString().Trim() + " new Visit Requests from " + ds.Tables[0].Rows[i]["organization"].ToString().Trim());
                            sb.Append("</p>");
                            sb.Append("</a>");
                            sb.Append("</li>");
                        }

                    }

                    // return sb.ToString();
                    //lblnoofnotifications.Text = ds.Tables[0].Rows.Count.ToString();

                }
            }
            catch(Exception ee)
            {
                sb.Append("<li class='notify'>"+ee.ToString().Trim().Substring(0,100)+"</li>");
            }
            
            if (count == 0)
            {
                return "No new notifications";
            }
            else
            {
                return sb.ToString(); 
            }
        }
        catch(Exception ee)
        {
            return ee.ToString();
        } 
    }
        

}