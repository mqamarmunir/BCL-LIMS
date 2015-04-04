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
using System.Xml;

public partial class smsPage : System.Web.UI.Page
{
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    protected void Page_Load(object sender, EventArgs e)
    {
        string cellno = Request.QueryString["cellno"].ToString();
        txtrecipient.Text = Request.QueryString["cellno"].ToString();
        if (cellno != "")
        {
            SMS();
        }
    }
    public void SMS()
    {
        string labid = Request.QueryString["labid"].ToString();
        string deliverydatetime = Request.QueryString["deliverydatetime"].ToString();
        
        //var datetime = DateTime.Parse(deliverydatetime);
        DateTime date1 = DateTime.Parse(deliverydatetime,new System.Globalization.CultureInfo("ur-PK",false));
        string Mydate =date1.ToString("dd MMM, yyyy HHmm");


        string patient1 = Request.QueryString["patient1"].ToString();
        txtmessagetext.Text = "Mr/Ms:" + patient1 + "\n We thankyou for visiting BCL \n Your Visit# is " + labid + "\n , results will be ready by " + Mydate + "hrs \n BioCareLabs \n www.biocarelabs.org \n 92-51-8350225 ";


        if ((txtrecipient.Text == "") || (txtmessagetext.Text == ""))
        {
            Response.Write("<font color='red'>Recipient And Message field mustn't be empty!</font>");
        }


        else
        {

            string createdURL;
            createdURL = "";
            string SURL;
            SURL = "http://websms.maaliksoft.com"; //'enter provided domain here';
            string SPort;
            SPort = "80";
            string User;

            User = Server.UrlEncode("03412138418");// enter username here
            string Passw;
            Passw = Server.UrlEncode("30ad0443bcc5a15b42dac85b41283a06"); //' enter secret key here
            string ozRecipients = HttpUtility.UrlEncode(txtrecipient.Text); //who will get the message
            string ozMessageData = HttpUtility.UrlEncode(txtmessagetext.Text); //body of message
            //string Recipient;
            //Recipient = Server.UrlEncode(Request.Form[txtrecipient.Text]); //'Recipient of the message if multiple seperate them with ;
            //string MessageData;
            //MessageData = Server.UrlEncode(Request.Form[txtmessagetext.Text]);// 'Message text we want to send

            createdURL = SURL + ":" + SPort + "/api/sendsms.php?username=" + User + "&secret=" + Passw + "&to=" + ozRecipients + "&text=" + ozMessageData;
            //  createdURL = SURL + ":" + SPort + "/api/sendsms.php?username="+ User + "&secrets=" + Passw   + "&to = " +txtrecipient.Text + "&text="txtmessagetext.Text;
            Response.Write("<iframe src=" + createdURL + " width='500'>");

        }
    
    }
    protected void SendBTn_Click(object sender, EventArgs e)
    {
      
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        txtrecipient.Text = "1";
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        txtrecipient.Text += "2";
    }
}