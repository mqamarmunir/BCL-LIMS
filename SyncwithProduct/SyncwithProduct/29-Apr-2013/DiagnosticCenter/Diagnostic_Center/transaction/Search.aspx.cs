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
public partial class transaction_Search : System.Web.UI.Page
{
    private static string DGSort = "";
    clsDayCashCollection dayCash = new clsDayCashCollection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //clsLogin log = new clsLogin();
            //log.OptionId = "33";
            //log.PersonId = Session["personid"].ToString();
            //DataView dvLog = log.GetLogin(2);
            //if (dvLog.Count > 0)
            //{
            //  gv_Waiting();
            // GvCashFunction();
            // GvCashList();
            ////            }
            ////            else
            ////            {
            ////                Response.Redirect("../Parameter/wfrmNotAllowed.aspx");
            ////            }
            //}

            //    else
            //    {
            //        Response.Redirect("../NewLogin.aspx");
            //    }
        }
        
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //Gv_DayCashList.DataSource = null;
        //Gv_DayCashList.DataBind();
        GvCashList();
       
    }
    #region Function of Day Cash List
    public void GvCashList()
    {
        DataView dv = new DataView();
       
        dayCash.CashierName = txtCashierName.Text;
        dayCash.Enteredon = tbfromdate.Text.Trim().Substring(6, 4) + "/" + tbfromdate.Text.Trim().Substring(3, 2) + "/" + tbfromdate.Text.Trim().Substring(0, 2);
        dayCash._EnteredonTo = tbtodate.Text.Trim().Substring(6, 4) + "/" + tbtodate.Text.Trim().Substring(3, 2) + "/" + tbtodate.Text.Trim().Substring(0, 2);
        if (dayCash.Enteredon == dayCash._EnteredonTo && txtCashierName.Text == "")
        {
            dv = dayCash.GetAll(9);
        }
        else
        {
            dv = dayCash.GetAll(10);
        }

        if (dayCash.Enteredon != dayCash._EnteredonTo && txtCashierName.Text == "")
        {
            dv = dayCash.GetAll(8);
            dv.Sort = DGSort;
        }
        if (dayCash.Enteredon != dayCash._EnteredonTo && txtCashierName.Text != "")
        {
            dv = dayCash.GetAll(7);
            dv.Sort = DGSort;
        }
        Gv_DayCashList.DataSource = dv;
        Gv_DayCashList.DataBind();

       
    }
    #endregion
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        txtCashierName.Text = "";
        tbfromdate.Text = "";
        tbtodate.Text = "";
        Gv_DayCashList.DataSource = null;
        Gv_DayCashList.DataBind();

       
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../transaction/wfrmCashierEntry.aspx");
    }
   
   
    protected void Gv_DayCashList_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("cashierName"))
        {
            if (DGSort == "cashierName ASC")
                DGSort = "cashierName DESC";
            else
                DGSort = "cashierName ASC";

        }
        else if (e.SortExpression.Equals("cashOpening_Amount"))
        {
            if (DGSort == "cashOpening_Amount ASC")
                DGSort = "cashOpening_Amount DESC";
            else
                DGSort = "cashOpening_Amount ASC";

        }
        else if (e.SortExpression.Equals("cashClosing_Amount"))
        {
            if (DGSort == "cashClosing_Amount ASC")
                DGSort = "cashClosing_Amount DESC";
            else
                DGSort = "cashClosing_Amount ASC";
        }
        else if (e.SortExpression.Equals("enteredoff"))
        {
            if (DGSort == "enteredoff ASC")
                DGSort = "enteredoff DESC";
            else
                DGSort = "enteredoff ASC";
        }
        else if (e.SortExpression.Equals("Lb_NetSales"))
        {
            if (DGSort == "Lb_NetSales ASC")
                DGSort = "Lb_NetSales DESC";
            else
                DGSort = "Lb_NetSales ASC";
        }
        else if (e.SortExpression.Equals("Name"))
        {
            if (DGSort == "Name ASC")
                DGSort = "Name DESC";
            else
                DGSort = "Name ASC";
        }



        GvCashList();
      


    }
    protected void Gv_DayCashList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hyperLink_Payment = e.Row.FindControl("HYp_CashClose") as HyperLink;
            hyperLink_Payment.NavigateUrl = "rptCashClose.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
            hyperLink_Payment.Target = "rptCashClose.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
        }
    }
}