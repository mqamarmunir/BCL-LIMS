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
using System.Net.Mail;
using System.IO;
using System.Windows.Forms;
using BusinessLayer;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Threading;

public partial class transaction_SentEmail : System.Web.UI.Page
{
    clsEmailConfiguration config = new clsEmailConfiguration();
    private static string prid = "";
    private static string labid = "";
    // clsDocumentList list = new clsDocumentList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetEmailIdandattachement();
            //getValue();
        }
    }

    private void GetEmailIdandattachement()
    {
        string bookingid = Request.QueryString["bookingid"].ToString().Trim();
        clsBLPatientReg_Inv objbokking = new clsBLPatientReg_Inv();
        objbokking.BookingID = bookingid;
        DataView dv_Email = objbokking.GetAll(55);
        string email = dv_Email[0]["Email"].ToString().Trim();
        labid = dv_Email[0]["labid"].ToString().Trim();
        prid = dv_Email[0]["prid"].ToString().Trim();
        TxBx_To.Text = email;
        Hyp_Email.Text = Request.QueryString[Rot13.Transform("FileName").ToString()];//.Substring(Request.QueryString[Rot13.Transform("FileName").ToString()].LastIndexOf('\\')+1);
      
            TxBx_Subject.Text = "Laboratory Report for visit no : " + labid;

    }
    public void getValue()
    {

        //    string caseno = Request.QueryString["a"];
        //    string date = Request.QueryString["a1"];
        //    string reference = Request.QueryString["b"];
        //    string suitNo = Request.QueryString["c"];
        //    string suittitle = Request.QueryString["d"];
        //    string casevalue = Request.QueryString["e"];
        DataView dv = new DataView();
        dv = config.GetAll(1);
        string signature = dv[0]["signature"].ToString();
        if (signature != "")
        {

            string prid = Request.QueryString["prid"];
            string prno = Request.QueryString["prno"];
            string bookingdid = Request.QueryString["bookingid"];
            string testtype = Request.QueryString["testtype"];
            string labid = Request.QueryString["labid"];
            string testid = Request.QueryString["testid"];
            string subdepartmentid = Request.QueryString["subdepartmentId"].ToString();
            string branchid = Request.QueryString["branchid"].ToString();
            branchid = Session["branchid"].ToString();
            string email = Request.QueryString["email"].ToString();
            string print = "print";
            TxBx_To.Text = email.ToString();


            //TxBx_Message.Text = "Reply Address:  setting for Cleint as Reply Address"; 
            TxBx_Subject.Text += "Laboratory Report for visit no : " + labid;
            TxBx_Message.Text += "\n\r\r Dear Sir/Madam, \n\r ";
            TxBx_Message.Text += "You can access your laboratory reports from the following link. \n\r\r";
            TxBx_Message.Text += @"http://115.186.173.228/frontoffice/transaction/CheckTest.aspx?prno=" + prno + "&labid=" + labid + "&bookingdid=" + bookingdid + "&print=" + print + "&testtype=" + testtype + "&testid=" + testid + "&subdepartmentid=" + subdepartmentid + "&branchid=" + branchid ;
            TxBx_Message.Text += "\n\r Branch Name : " + "BCL (Main Branch) \n\r";
            TxBx_Message.Text += "Address: BioCareLabs, Blue Area Islamabad.";



            //StreamReader reader = new StreamReader(Server.MapPath("wfrmCashReport.aspx"));
            // //string readFile = reader.BaseStream.Seek(0, SeekOrigin.End).ToString();
            //string readFile = reader.ReadToEnd();
            //string myString = "";
            //myString = readFile;
            //TxBx_Message.Text = myString.ToString();
        }
    }

    public void Email()
    {
        string EMailId = "";
        string _cellno = "";
        string subject = "";
        string headertext = "";
        string footertext = "";

        clsBLPatientReg_Inv obj_patient = new clsBLPatientReg_Inv();

        DataView dvpass = new DataView();
        obj_patient.PRID = prid;// Request.QueryString["prid"];
        dvpass = obj_patient.GetAll(33);

        string prno = dvpass[0]["prno"].ToString();// Request.QueryString["PRNo"].ToString().Trim();
        string _labid = labid;// Request.QueryString["labid"].ToString().Trim();
        string branchid = Session["BranchID"].ToString().Trim();
        string pasword = dvpass[0]["Pasword"].ToString();

        obj_patient.PRNO = prno.ToString();
        DataView dv = obj_patient.GetAll(47);
        obj_patient = null;
        if (dv.Count > 0)
        {
            if (dv[0]["email"].ToString().Trim() != null)
            {
                EMailId = TxBx_To.Text.ToString();
                // EMailId = "Ammanzaheer@gmail.com";
                //EMailId = "asifalikkhan@gmail.com";
            }
            else
            {
                //EMailId = "Ammanzaheer@gmail.com";
            }
            _cellno = dv[0]["cellno"].ToString().Trim();
        }
        //string emailid = TxBx_To.Text;
        //string emailcc = TxBx_Cc.Text;
        //string fileName = "LetterInviting.pdf";
        clsBLBranchAlertsD obj_alert = new clsBLBranchAlertsD();
        obj_alert.BranchID = Session["BranchID"].ToString().Trim();
        obj_alert.Type = "E";
        // obj_alert.ProcessID = Request.QueryString["ProcessID"].ToString().Trim();
        obj_alert.Active = "Y";
        DataView dv_messagedata = obj_alert.GetAll(1);
        obj_alert = null;
        if (dv_messagedata.Count > 0)
        {
            subject = dv_messagedata[0]["Subject"].ToString().Trim();
            headertext = dv_messagedata[0]["header"].ToString().Trim().Replace("\n", "<br/>");
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
           // int port = Convert.ToInt32(dv_email[0]["port"]);

            MailMessage message = new MailMessage();
            ////////////////
            //message.From = new MailAddress("qamar.nust@gmail.com");
            //message.To.Add(new MailAddress("qamar.munir@seecs.edu.pk"));
            //message.Body += "Hi am new Email";
            //message.Body += "<br/><br/><br/>" + footertext;
            
        //    Attachment _report = new Attachment(Request.QueryString[Rot13.Transform("FileName")].ToString().Trim());
          //  message.Attachments.Add(_report);
            //SmtpClient smtp = new SmtpClient();
            //smtp.EnableSsl = true;
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 465;
            //smtp.

            ////////////////
            message.From = new MailAddress(from, "BioCareLab");


            message.To.Add(new MailAddress(EMailId));
            message.ReplyToList.Add(new MailAddress(dv_email[0]["ReplyAddress"].ToString().Trim()));


            string[] spllitted = headertext.Split(new string[] { "[PRNO]" }, StringSplitOptions.RemoveEmptyEntries);
            string headerPR = spllitted[0].Trim() + "<b>" + prno + "</b>" + spllitted[1].Trim();

            string[] spllitted2 = headerPR.Split(new string[] { "[Password]" }, StringSplitOptions.RemoveEmptyEntries);
            string headerPass = spllitted2[0].Trim() + "<b>" + pasword + "</b>" + spllitted2[1].Trim();

            message.Body += headerPass;
            message.Body += "<br/><br/><br/>" + footertext;

            Attachment _report = new Attachment(Server.MapPath("~/Report/pdf/" + Request.QueryString[Rot13.Transform("FileName")].ToString().Trim()));
            message.Attachments.Add(_report);

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
            //smtp.Send(message);
            smtp.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            try
            {
                smtp.Send(message);
                Thread t = new Thread(new ThreadStart(delegate
        {
            smtp.Send(message);
        }));
                t.IsBackground = true;
                t.Start();
                /////////adil's updare///////
           //  smtp.SendAsync(message,null);
                ////////////////////////////
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
                   // Thread.Sleep(5000);
                   Response.Write("<script type=\"text/javascript\">alert('Email Sent');</script>");
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
            finally
            {


                // Thread.Sleep(5000);
                Response.Write("<script language = 'javascript'>window.close()</script>");
            }
        }
        else
        {
            lblsent.Visible = true;
            lblsent.Text = "This branch is not configued for getting this alert";
            // Response.Write("<script language = 'javascript'>window.close()</script>");
        }
    }

 


    protected void Btn_ok_Click(object sender, ImageClickEventArgs e)
    {
        
        
       Email();
       


        tb2.Visible = true;
        tb3.Visible = false;
    }
    void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        MailMessage mail = e.UserState as MailMessage;
        if (!e.Cancelled && e.Error != null)
        {

            //message.Text = "Mail sent successfully";       
        }
    }
    protected void HypEmail_Click(object sender, EventArgs e)
    {
        LinkButton lnkPath3 = (LinkButton)sender;
        string filepath = Server.MapPath("~/Report/pdf/"+lnkPath3.Text.Trim());// @"D:\negno25462.jpg";
        // Create New instance of FileInfo class to get the properties of the file being downloaded
        FileInfo myfile = new FileInfo(filepath);

        // Checking if file exists
        if (myfile.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", myfile.Length.ToString());

            // Set the ContentType
            Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(myfile.FullName);

            // End the response
            Response.End();
        }
    }
    private string ReturnExtension(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";

            case ".docx":
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }
}