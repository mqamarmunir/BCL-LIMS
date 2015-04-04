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
using System.Globalization;
using BusinessLayer;

public partial class transaction_wfrmCaslList : System.Web.UI.Page
{
    clsDayCashCollection dayCash = new clsDayCashCollection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
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
    }

    #region Function of Day Cash List
    public void GvCashList()
    {
        DataView dv = new DataView();
        dayCash.Branchid = Session["branchid"].ToString();
        dv = dayCash.GetAll(2);
        Gv_DayCashList.DataSource = dv;
        Gv_DayCashList.DataBind();

        for (int i = 0; i < dv.Count; i++)
        {
            string ImgChecker = dv[i]["cashStatus"].ToString();
            if (ImgChecker == "Online")
            {
                (Gv_DayCashList.Rows[i].FindControl("Img_offline") as Image).Visible = false;

                (Gv_DayCashList.Rows[i].FindControl("Img_Print") as Image).Visible = false;

                (Gv_DayCashList.Rows[i].FindControl("Image1") as Image).Visible = false;

            }
            else
            {
                (Gv_DayCashList.Rows[i].FindControl("Img_online") as Image).Visible = false;
                int netsale = Convert.ToInt32(dv[i]["cashClosing_Amount"]) - Convert.ToInt32(dv[i]["cashOpening_Amount"]);
                (Gv_DayCashList.Rows[i].FindControl("Lb_NetSales") as Label).Text = netsale.ToString();
            }
        }
    }
    public void GvCashListSearchable()
    {
        DataView dv = new DataView();
        dayCash.Branchid = Session["branchid"].ToString();
        dayCash.FromDate1 = txtfrom.Text.ToString();
        if (txttodate.Text != null && txttodate.Text!="")
        {
            DateTime d = DateTime.ParseExact(txttodate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1);
            d = d.AddDays(1);
            dayCash.ToDate1 = d.ToString("dd/MM/yyyy");//.ToString("dd/MM/yyyy");
        }
        dayCash.Reportno = txtreportno.Text.ToString();
        dv = dayCash.GetAll(32);
        Gv_DayCashList.DataSource = dv;
        Gv_DayCashList.DataBind();

        for (int i = 0; i < dv.Count; i++)
        {
            string ImgChecker = dv[i]["cashStatus"].ToString();
            if (ImgChecker == "Online")
            {
                (Gv_DayCashList.Rows[i].FindControl("Img_offline") as Image).Visible = false;

                (Gv_DayCashList.Rows[i].FindControl("Img_Print") as Image).Visible = false;

                (Gv_DayCashList.Rows[i].FindControl("Image1") as Image).Visible = false;

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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hyperLink_Payment = e.Row.FindControl("HYp_CashClose") as HyperLink;
            hyperLink_Payment.NavigateUrl = "wfrmdaycashstatement.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
            hyperLink_Payment.Target = "wfrmdaycashstatement.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
            //rptCashClose.aspx
        }
    }

    
    protected void Gv_DayCashList_PageIndexChanged(object sender, GridViewPageEventArgs e)
    {
     //   Gv_DayCashList.PageIndex = e.NewPageIndex;
      //  GvCashList();  
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        GvCashListSearchable();

    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {

    }
}