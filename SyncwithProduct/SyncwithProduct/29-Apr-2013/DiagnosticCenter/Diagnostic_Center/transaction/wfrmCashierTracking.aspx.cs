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

public partial class transaction_wfrmCashierTracking : System.Web.UI.Page
{
    clsPreferenceSettings prefSetting = new clsPreferenceSettings();
    clsDayCashCollection dayCash = new clsDayCashCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                CashPrimaryInformation();
                //clsLogin log = new clsLogin();
                //log.OptionId = "33";
                //log.PersonId = Session["personid"].ToString();
                //DataView dvLog = log.GetLogin(2);
                //if (dvLog.Count > 0)
                //{
                 GvCashList();
                //}
                //else
                //{
                //    Response.Redirect("../Parameter/wfrmNotAllowed.aspx");
                //}
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
       // CashPrimaryInformation();
    }

    #region Function of Day Cash List
    public void GvCashList()
    {
        DataView dv = new DataView();
        dv = dayCash.GetAll(12);
        Gv_DayCashList.DataSource = dv;
        Gv_DayCashList.DataBind();

        for (int i = 0; i < dv.Count; i++)
        {
            string ImgChecker = dv[i]["cashStatus"].ToString();
            if (ImgChecker == "Online")
            {
                (Gv_DayCashList.Rows[i].FindControl("Img_offline") as Image).Visible = false;
            }
            else
            {
                (Gv_DayCashList.Rows[i].FindControl("Img_online") as Image).Visible = false;
                int netsale = Convert.ToInt32(dv[i]["cashClosing_Amount"]) - Convert.ToInt32(dv[i]["cashOpening_Amount"]);
                (Gv_DayCashList.Rows[i].FindControl("Lb_NetSales") as Label).Text = netsale.ToString();
            }
        }
    }
    #endregion

    protected void Gv_DayCashList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    HyperLink hyperLink_Payment = e.Row.FindControl("HYp_CashClose") as HyperLink;
        //    hyperLink_Payment.NavigateUrl = "rptCashClose.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
        //    hyperLink_Payment.Target = "rptCashClose.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
        //}
    }




    public void CashPrimaryInformation()
    {
        DataView dv = new DataView();
        dv = prefSetting.GetALL(1);
        if (dv.Count > 0)
        {
            if (dv[0]["Path_location"].ToString() != null)
            {
                Img_header.Visible = false;
                Img_header.ImageUrl = dv[0]["Path_location"].ToString();
            }
            else
            {
                Img_header.ImageUrl = "#";
            }
            if (Session["footer"] != null)
            {
                //Img_footer.ImageUrl = Session["footer"].ToString();
            }
            else
            {
                //Img_footer.ImageUrl = "#";
            }
        }

        dayCash.Reportno = Request.QueryString["reportno"].ToString();
        dv = dayCash.GetAll(3);
        Gv_CashPrimaryInfo.DataSource = dv;
        Gv_CashPrimaryInfo.DataBind();

        dayCash.Reportno = Request.QueryString["reportno"].ToString();

        dv = dayCash.GetAll(4);
        if (dv.Count > 0)
        {
            //Lb_totalCash.Text = dv[0]["totalcash"].ToString();
            Gv_PatientReceipt.DataSource = dv;
            Gv_PatientReceipt.DataBind();
        }
        else
        {
            Lb_totalCash.Text = "0";
        }


        dayCash.Reportno = Request.QueryString["reportno"].ToString();

        dv = dayCash.GetAll(5);
        if (dv.Count > 0)
        {
            Lb_panelReceived.Text = dv[0]["totalcash"].ToString();
            Gv_PanelPatient.DataSource = dv;
            Gv_PanelPatient.DataBind();
        }
        else
        {
            Lb_panelReceived.Text = "0";
        }

        dayCash.Reportno = Request.QueryString["reportno"].ToString();
        dv = dayCash.GetAll(6);
        if (dv.Count > 0)
        {
            Lb_refundReceived.Text = dv[0]["totalrefund"].ToString();
            Gv_RefundPatient.DataSource = dv;
            Gv_RefundPatient.DataBind();
        }
        else
        {
            Lb_refundReceived.Text = "0";
        }
        try
        {


            int netCash = Convert.ToInt32(Lb_totalCash.Text) + Convert.ToInt32(Lb_panelReceived.Text);
            Lb_CashNetRecieved.Text = netCash.ToString();
            Lb_OnNetRefund.Text = Lb_refundReceived.Text;

            int nettotal = Convert.ToInt32(Lb_CashNetRecieved.Text) - Convert.ToInt32(Lb_OnNetRefund.Text);
            Lb_NetAmount.Text = nettotal.ToString();
            if (Request.QueryString["cashOpen"] != null && Request.QueryString["cashClose"] != null)
            {
               
                string cashOpen = Request.QueryString["cashOpen"].ToString();
                string cashClose = Request.QueryString["cashClose"].ToString();
                int cashNet = Convert.ToInt32(cashClose) - nettotal - Convert.ToInt32(cashOpen);

                Lb_netdiff.Text = cashNet.ToString();
            }
        }
        catch (Exception e)
        {
            Response.Write(e.Message);
        }

        

    }
}