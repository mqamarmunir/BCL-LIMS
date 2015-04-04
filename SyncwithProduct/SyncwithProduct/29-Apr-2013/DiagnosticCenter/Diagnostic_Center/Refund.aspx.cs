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

public partial class Refund : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                SHow_record();
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    private void SHow_record()
    {
        clsBLCashRec rec = new clsBLCashRec();
        rec.RefundNo = Request.QueryString["refundno"].ToString();


        DataView dv = rec.GetAll(7);

        gvTest.DataSource = dv;
        gvTest.DataBind();

        lblLabID.Text = dv[0]["labid"].ToString();
        lblPatient.Text = dv[0]["patient"].ToString();

        lblPRNo.Text = dv[0]["prno"].ToString();
        lblReceipt.Text = dv[0]["refundno"].ToString();
        lblReceivdBy.Text = dv[0]["receivedby"].ToString();

        lblReceivdOn.Text = dv[0]["receivedon"].ToString();

        lblTel.Text = dv[0]["phoneno"].ToString();
        lblAddress.Text = dv[0]["orgaddress"].ToString();

        lblAGe.Text = GetAge(dv[0]["dob"].ToString());
        lblGender.Text = dv[0]["gender"].ToString();
        lblAuthorized.Text = dv[0]["authorizedby"].ToString();
        lblType.Text = dv[0]["refundtype"].ToString();

        int count = 0;
        for (int i = 0; i < dv.Count; i++)
        {
            count += Convert.ToInt32(dv[i]["paidamount"].ToString());
        }
        lblPaid.Text = count.ToString();
        lblword.Text = "Refund  " + ToWord(Convert.ToInt32(lblPaid.Text.Trim())) + " Only";

    }
    string ToWord(Int64 n)
    {
        string[] st ={"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven"
            , "Twelve", "Thirteen", "Forteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        string[] st1 = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        if (n < 20) return st[n];
        if (n < 100)
            return st1[n / 10] + " " + ((n % 10 == 0) ? "" : st[n % 10]);
        if (n < 1000)
            return ToWord(n / 100) + " Hundred " + ((n % 100 > 0) ? " and " + ToWord(n % 100) : "");
        if (n < 100000)
            return ToWord(n / 1000) + " Thousand " + ((n % 1000) > 0 ? ToWord(n % 1000) : "");
        if (n < 10000000)
            return ToWord(n / 100000) + " Lakhs " + ((n % 100000) > 0 ? ToWord(n % 100000) : "");
        return ToWord(n / 10000000) + " Crore " + ((n % 10000000) > 0 ? ToWord(n % 10000000) : "");
    }
    private string GetAge(string strDate)
    {
        string strPres = strDate.Substring(3, 2) + "/" + strDate.Substring(0, 2) + "/" + strDate.Substring(6, 4);
        DateTime dtPres = DateTime.Parse(strPres);
        DateTime dtNow = DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy"));
        TimeSpan ts = dtNow.Subtract(dtPres);

        double days = ts.TotalDays;
        double month = days / 30;
        double year = (days / 30) / 12;

        if (days > 0 && days < 30)
            strDate = days.ToString() + "-Days";
        else if (days < 1440 && month <= 12)
            strDate = Convert.ToString(Convert.ToInt32(month)) + "-Month";
        else
            strDate = Convert.ToString(Convert.ToInt32(year)) + "-Year";
        return strDate;
    }
}
