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

public partial class print2 : System.Web.UI.Page
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
        rec.ReceiveNo = Request.QueryString["recno"].ToString().Trim();
        rec.LabID = Request.QueryString["labid"].ToString().Trim();

        DataView dv = rec.GetAll(4);
        DataView dvCash = rec.GetAll(11);

        gvTest.DataSource = dv;
        gvTest.DataBind();


        lblLabID.Text = dv[0]["labid"].ToString();
        lblPaid.Text = dv[0]["paidamount"].ToString().Trim();
        lblPatient.Text = dv[0]["patient"].ToString();

        lblPRNo.Text = dv[0]["prno"].ToString();
        lblReceipt.Text = dv[0]["receiveno"].ToString();
        lblReceivdBy.Text = dv[0]["receivedby"].ToString();

        lblReceivdOn.Text = dv[0]["receivedon"].ToString();
        lblTotal.Text = dv[0]["totalamount"].ToString();


        lblTel.Text = dv[0]["phoneno"].ToString();
        lblAddress.Text = dv[0]["orgaddress"].ToString();

        lblAGe.Text = GetAge(dv[0]["dob"].ToString());
        lblGender.Text = dv[0]["gender"].ToString();
       


        //lblBal.Text = dv[0]["balance"].ToString();

        lblword.Text = ToWord(Convert.ToInt32(lblPaid.Text.Trim())) + " Only";

        if (dvCash.Count > 0)
        {
            lblBal.Text = Convert.ToString(Convert.ToInt32(dvCash[0]["totalamount"].ToString()) - (Convert.ToInt32( dvCash[0]["paidamount"].ToString())+ Convert.ToInt32(dvCash[0]["discount_amt"].ToString())));
            lblTotalPaid.Text = dvCash[0]["paidamount"].ToString();
            lblDiscount.Text = dvCash[0]["discount_amt"].ToString();
        }
        if (dv[0]["paymentmode"].ToString().Trim().Equals("A"))
        {
            pnl_AMount.Visible = false;
            if (!dv[0]["panelid"].ToString().Equals("7040") && !dv[0]["panelid"].ToString().Equals("7041"))
            {
                lblCmp_head.Text = "Company:";
                lblCompany.Text = dv[0]["panelname"].ToString();
            }

            if (dv[0]["authorizeno"].ToString().Trim().Equals(""))
            {
                lblAuth_head.Text = "";
                lblAuthorizeno.Text = "";
            }
            else
            {
                lblAuth_head.Text = "Authorization No:";
                lblAuthorizeno.Text = dv[0]["authorizeno"].ToString();
            }

            lblServ_head.Text = "Service No:";
            lblServiceNo.Text = dv[0]["serviceno"].ToString();
        }
        else if (dv[0]["authorizeno"].ToString().Trim().Equals("") && !dv[0]["serviceno"].ToString().Trim().Equals(""))
        {
            pnl_AMount.Visible = true;
            if (!dv[0]["panelid"].ToString().Equals("7040") && !dv[0]["panelid"].ToString().Equals("7041"))
            {
                lblCmp_head.Text = "Company:";
                lblCompany.Text = dv[0]["panelname"].ToString();
            }
            
            lblServ_head.Text = "Service No:";
            lblServiceNo.Text = dv[0]["serviceno"].ToString();

            lblAuth_head.Text = "";
            lblAuthorizeno.Text = "";
        }
        else
        {
            pnl_AMount.Visible = true;
            lblCmp_head.Text = "";
            lblCompany.Text = "";

            lblAuth_head.Text = "";
            lblAuthorizeno.Text = "";

            lblServ_head.Text = "";
            lblServiceNo.Text = "";
        }

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
