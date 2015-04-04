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
public partial class transaction_wfrmCashierEmail : System.Web.UI.Page
{
    clsEmailConfiguration config = new clsEmailConfiguration();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["email"] != null)
            {
                TxBx_To.Text = Session["email"].ToString();
            }
            else
            {
            }
            getValue();
        }
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
            TxBx_Message.Text = "Dear Sir/Madam, \n\r" + signature + "\n\r NOTES: \n - The contents of this e-mail and the attached file are for your exclusive use and should not be shared with others. \n";
        }
        //dv = list.GetAll(18);

        //string name = dv[0]["Name"].ToString();
        //string Title = dv[0]["Title"].ToString();
        //string Addressing = dv[0]["Addressing"].ToString();
        //string From = dv[0]["From"].ToString();
        //TxBx_Subject.Text = name;
        //TxBx_Message.Text = "THIS IS AN AUTO-GENERATED MESSAGE - PLEASE DO NOT REPLY TO THIS MESSAGE \n\r NOTES: \n - The contents of this e-mail and the attached file are for your exclusive use and should not be shared with others. \n";
    }



    public void Email()
    {
        string emailid = TxBx_To.Text;
        string emailcc = TxBx_Cc.Text;
        string fileName = "LetterInviting.pdf";
        String fullFileName = Path.Combine(Server.MapPath("~\\AppLetter_Inviting\\"), fileName);

        DataView dv = new DataView();
        dv = config.GetAll(1);
        string from = dv[0]["SendFrom"].ToString();
        string user = dv[0]["Username"].ToString();
        string pass = dv[0]["Password"].ToString();
        string host = dv[0]["HostName"].ToString();
        string signature = dv[0]["signature"].ToString();
        string enableStatus = dv[0]["EnableSsl"].ToString();

        MailMessage message = new MailMessage();
        message.From = new MailAddress(from,"BioCareLab");
        //message.To.Add(new MailAddress("ammanzaheer@yahoo.com"));
        message.To.Add(new MailAddress(emailid));
        //message.To.Add(new MailAddress("tauqeer84@gmail.com"));
        if (emailcc != "")
        {
            message.CC.Add(new MailAddress(emailcc));
        }
        message.Subject = TxBx_Subject.Text;
        message.Body = TxBx_Message.Text;
      //  Attachment attach = new Attachment(fullFileName, System.Net.Mime.MediaTypeNames.Application.Pdf);
      //  message.Attachments.Add(attach);
        SmtpClient smtp = new SmtpClient();
        smtp.Host = host;
        if (enableStatus == "f")
        {
            smtp.EnableSsl = false;
        }
        else
        {
            smtp.EnableSsl = true;
        }
        smtp.Credentials = new System.Net.NetworkCredential(user, pass);
        smtp.Send(message);
        Lbl_Email.Text = "Successfully Mail Sent";
    }

    protected void Btn_ok_Click(object sender, ImageClickEventArgs e)
    {
        Email();
        tb2.Visible = true;
        tb3.Visible = false;
    }
}