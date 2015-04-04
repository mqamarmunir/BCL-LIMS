using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Net.Mail;
using System.Threading;
using System.Web.UI.WebControls.WebParts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;

public partial class transaction_wfrmsendNotifications : System.Web.UI.Page
{
    clsEmailConfiguration config = new clsEmailConfiguration();
    protected void Page_Load(object sender, EventArgs e)
    {
        Email();
       // CallMe();
        
    }
    public void Email()
    {

        string EMailId = "";
        string _cellno = "";
        string subject="";
        string headertext="";
        string footertext="";

        clsBLPatientReg_Inv obj_patient = new clsBLPatientReg_Inv();

        string prno = Request.QueryString["PRNo"].ToString().Trim();
        string labid = Request.QueryString["labid"].ToString().Trim();
        string branchid = Session["BranchID"].ToString().Trim();
        string pasword = Request.QueryString["pass"].ToString().Trim();

        obj_patient.PRNO = prno.ToString();
        DataView dv = obj_patient.GetAll(47);
        obj_patient = null;
        if (dv.Count > 0)
        {
            string emailID = dv[0]["email"].ToString().Trim();
            if (emailID != "")
            {
                EMailId = dv[0]["email"].ToString().Trim();
              // EMailId = "Ammanzaheer@gmail.com";
               //EMailId = "asifalikkhan@gmail.com";
            }
            else
            {
               // EMailId = "Ammanzaheer@gmail.com";
            }
            _cellno = dv[0]["cellno"].ToString().Trim();
        }
        //string emailid = TxBx_To.Text;
        //string emailcc = TxBx_Cc.Text;
        //string fileName = "LetterInviting.pdf";
        clsBLBranchAlertsD obj_alert = new clsBLBranchAlertsD();
        obj_alert.BranchID = Session["BranchID"].ToString().Trim();
        obj_alert.Type = "E";
        obj_alert.ProcessID = Request.QueryString["ProcessID"].ToString().Trim() ;
        obj_alert.Active="Y";
        DataView dv_messagedata = obj_alert.GetAll(1);
        obj_alert=null;
        if (dv_messagedata.Count > 0)
        {
            subject = dv_messagedata[0]["Subject"].ToString().Trim();
            headertext = dv_messagedata[0]["header"].ToString().Trim().Replace("\n","<br/>");
            footertext = dv_messagedata[0]["footer"].ToString().Trim().Replace("\n", "<br/>");

           // dv_messagedata.Dispose();


            DataView dv_email = new DataView();
            dv_email = config.GetAll(1);
            string from = dv_email[0]["SendFrom"].ToString();
            string user = dv_email[0]["Username"].ToString();
            string pass = dv_email[0]["Password"].ToString();
            string host = dv_email[0]["HostName"].ToString();
            string signature = dv_email[0]["signature"].ToString();
            string enableStatus = dv_email[0]["EnableSsl"].ToString();
            

            MailMessage message = new MailMessage();
            message.From = new MailAddress(from,"BioCareLab");
           // message.To.Add(new MailAddress("acc_for_demo_lims@gmail.com"));
            try
            {
                message.To.Add(new MailAddress(EMailId));
            }
            catch { }
            //message.To.Add(new MailAddress("tauqeer84@gmail.com"));
            //if (emailcc != "")
            //{
            //    message.CC.Add(new MailAddress(emailcc));
            //}
            message.Subject = subject;
            //message.Body = headertext + " " + @"Dear patient,
            //                          Thanks for using our services. For receipt report please click on below link " + @"15.186.173.228/frontoffice/transaction/wfrmCashReport.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + "" + "&cash=N+&branchid=" + branchid + "\n\r\n\r\n\r\n\r " + footertext;


            string[] spllitted = headertext.Split(new string[] { "[PRNO]" }, StringSplitOptions.RemoveEmptyEntries);
            string headerPR = spllitted[0].Trim() + " <b>" + prno + "</b> " + spllitted[1].Trim();

            string[] spllitted2 = headerPR.Split(new string[] { "[Password]" }, StringSplitOptions.RemoveEmptyEntries);
            string headerPass = spllitted2[0].Trim() + " <b>" + pasword + "</b> " + spllitted2[1].Trim();


            message.Body += headerPass;
            message.Body += "<br/><br/><br/>" + footertext;
            
            //   Attachment attach = new Attachment(fullFileName, System.Net.Mime.MediaTypeNames.Application.Pdf);
            //   message.Attachments.Add(attach);
            //   message.Body += "115.186.173.228/frontoffice/transaction/wfrmCashReport.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + "" + "&cash=N+&branchid=" + branchid + "\n\r " + signature ;
            message.ReplyToList.Add(new MailAddress(dv_email[0]["ReplyAddress"].ToString().Trim()));
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = host;
            smtp.Port = 25;
            if (enableStatus == "f")
            {
                smtp.EnableSsl = false;
            }
            else
            {
                smtp.EnableSsl = true;
            }

            smtp.Credentials = new System.Net.NetworkCredential(user, pass);
          //  smtp.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            try
            {
               
                    smtp.Send(message);
                
                //t.IsBackground = true;
                //t.Start();


                lblsent.Visible = true;
                lblsent.Text = "Mail Successfully Sent";
                clsBLAlertsAudit obj_audit = new clsBLAlertsAudit();
                obj_audit.AlertType = "E";
                obj_audit.BranchID = Session["BranchID"].ToString().Trim();
                obj_audit.ClientId = Session["orgid"].ToString().Trim();
                obj_audit.SentBy = Session["PersonID"].ToString();
                obj_audit.Senton = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_audit.SentTo = EMailId;
                obj_audit.AlertID = dv_messagedata[0]["AlertTypeID"].ToString().Trim();
                if (obj_audit.Insert())
                {
                    lblsent.Text += " and alert audit record saved...";
                    Thread.Sleep(5000);
                    Response.Write("<script type=\"text/javascript\">alert('Email Sent');</script>");
                   // Response.Write("<script language = 'javascript'>window.close()</script>");
                    Response.Write("<script language = 'javascript'>window.close()</script>");
                }
                else
                {
                    lblsent.Text += " but the following error occured while saving the record." + "<br />" + obj_audit.ErrorMessage;
                }
            }
            catch (Exception ee)
            {
                lblsent.Visible = true;
                lblsent.Text = ee.Message.ToString();
            }
        }
        else
        {
            lblsent.Visible = true;
            lblsent.Text = "This branch is not configued for getting this alert";
           // Response.Write("<script language = 'javascript'>window.close()</script>");
        }
    }


    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    private void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        MailMessage mail = e.UserState as MailMessage;
        if (!e.Cancelled && e.Error != null)
        {
            GC.Collect();
            //message.Text = "Mail sent successfully";       
        }
    }


    
}