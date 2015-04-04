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



public partial class api : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  Fillddl_Patients();
        }
       
    }
    private void Fillddl_Patients()
    {
        //SComponents com = new SComponents();
        //clsBLLogin log = new clsBLLogin();
        //DataView dv = log.GetAll(3);

        //com.FillDropDownList(ddlpersons, dv, "personname", "PersonId");
    }

    protected void btnButton_Click(object sender, EventArgs e)
    {
        if((txtrecipient.Text == "") || (txtmessagetext.Text ==""))
        {
            Response.Write("<font color='red'>Recipient And Message field mustn't be empty!</font>");
        }


        else
        {
            
            string createdURL;
            createdURL = "";
            string SURL;
            SURL = "http://websms.maaliksoft.com";// ' enter provided domain here';
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
    //protected void ddlpersons_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    clsBLLogin log = new clsBLLogin();
    //    log.StrPersonid1 = ddlpersons.SelectedValue.Trim();
    //    DataView dv = log.GetAll(4);
    //    if (dv.Count > 0)
    //    {
    //        txtrecipient.Text = dv[0]["CPhoneNo"].ToString();
    //        txtmessagetext.Text = dv[0]["CurrentAddress"].ToString();
    //    }
    //    else
    //    {
    //    }
    //}
}
