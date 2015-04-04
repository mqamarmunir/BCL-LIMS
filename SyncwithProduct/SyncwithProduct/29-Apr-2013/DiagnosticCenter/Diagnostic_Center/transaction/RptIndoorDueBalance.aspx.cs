using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BusinessLayer;
using System.IO;

public partial class transaction_RptIndoorDueBalance : System.Web.UI.Page
{
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    clsCashPaid paid = new clsCashPaid();
    protected void Page_Load(object sender, EventArgs e)
    {
        RptHeaders();
        CashGridBind();
     //   PanelGridBind();
    }
    public void RptHeaders()
    {
        DataView dv = new DataView();
        dv = prefSetting.GetALL(1);
        if (dv.Count > 0)
        {
            if (dv[0]["Path_location"].ToString() != null)
            {
                Img_header.Visible = true;
                Img_header.ImageUrl = dv[0]["Path_location"].ToString();
            }
            else
            {
                Img_header.ImageUrl = "#";
            }
            // if (Session["footer"] != null)
            // {
            //    Img_footer.ImageUrl = Session["footer"].ToString();
            // }
            // else
            // {
            //    Img_footer.ImageUrl = "#";
            // }
        }
    }

    public void CashGridBind()
    {
        DataView dv = new DataView();
        dv = paid.GetAll(7);
        Gv_DueBalance.DataSource = dv;
        Gv_DueBalance.DataBind();
        double totbalance = 0;
        Label_Bal.Text = "Balance:";
        for (int i = 0; i < dv.Count; i++)
        {
            double balance = Convert.ToDouble(dv[i]["Balance"]);
            totbalance = totbalance + balance;
            Lb_CashBalance.Text = totbalance.ToString();
        }
    }
    public void CashGridBind12()
    {
        DataView dv = new DataView();
        dv = paid.GetAll(8);
        Gv_DueBalance.DataSource = dv;
        Gv_DueBalance.DataBind();
        double totbalance = 0;
        Label_Bal.Text = "Balance:";
        for (int i = 0; i < dv.Count; i++)
        {
            double balance = Convert.ToDouble(dv[i]["Balance"]);
            totbalance = totbalance + balance;
            Lb_CashBalance.Text = totbalance.ToString();
        }
    }
    public void CashGridBind13()
    {
        DataView dv = new DataView();
        dv = paid.GetAll(9);
        Gv_DueBalance.DataSource = dv;
        Gv_DueBalance.DataBind();
        double totbalance = 0;
        Label_Bal.Text = "Balance:";
        for (int i = 0; i < dv.Count; i++)
        {
            double balance = Convert.ToDouble(dv[i]["Balance"]);
            totbalance = totbalance + balance;
            Lb_CashBalance.Text = totbalance.ToString();
        }
    }

    public void PanelGridBind()
    {
        DataView dv = new DataView();
        dv = paid.GetAll(3);
        Gv_PanelBalance.DataSource = dv;
        Gv_PanelBalance.DataBind();
        double totbalance = 0;
        Label1.Text = "Balance:";
        for (int i = 0; i < dv.Count; i++)
        {
            double balance = Convert.ToDouble(dv[i]["Balance"]);
            totbalance = totbalance + balance;
            Lb_PanelBalance.Text = totbalance.ToString();
        }
    }
    protected void AllReceivable_Click(object sender, EventArgs e)
    {
        DataView dv = new DataView();
        dv = paid.GetAll(10);
        Gv_DueBalance.DataSource = dv;
        Gv_DueBalance.DataBind();
        double totbalance = 0;
        Label_Bal.Text = "Balance:";
        for (int i = 0; i < dv.Count; i++)
        {
            double balance = Convert.ToDouble(dv[i]["Balance"]);
            totbalance = totbalance + balance;
            Lb_CashBalance.Text = totbalance.ToString();
        }
    }
    protected void CurrentReceivable_Click(object sender, EventArgs e)
    {
        CashGridBind();
    }
    protected void Gv_DueBalance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Response.Redirect("wfrmCash.aspx", false);

        }
    }


    protected void Gv_DueBalance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                HyperLink hyperLink_Balance = e.Row.FindControl("Hyp_Balance") as HyperLink;
                hyperLink_Balance.NavigateUrl = "wfrmCash.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&pname=" + DataBinder.Eval(e.Row.DataItem, "patient") + "&totalAmt=" + DataBinder.Eval(e.Row.DataItem, "totalamount") + "&amount=" + DataBinder.Eval(e.Row.DataItem, "paidamount");
                hyperLink_Balance.Target = "wfrmCash.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&pname=" + DataBinder.Eval(e.Row.DataItem, "patient") + "&totalAmt=" + DataBinder.Eval(e.Row.DataItem, "totalamount") + "&amount=" + DataBinder.Eval(e.Row.DataItem, "paidamount");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    protected void btn60Dyas_Click(object sender, EventArgs e)
    {
        CashGridBind12();

    }
    protected void btn90Dyas_Click(object sender, EventArgs e)
    {
        CashGridBind13();
    }
}