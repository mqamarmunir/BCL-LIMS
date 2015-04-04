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

public partial class Report_wfrmDayCashClosing : System.Web.UI.Page
{
    clsDayCashCollection dayCash = new clsDayCashCollection();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "33";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    fill_gv();
                    gv_Waiting();
                    GvCashFunction();
                    GvCashList();
                }
                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowed.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }

    }

    #region Function of DayCash Gridview
        public void GvCashFunction()
        {
            DataView dv = new DataView();
            dv = dayCash.GetAll(1);
            Gv_DayCashOn.DataSource = dv;
            Gv_DayCashOn.DataBind();
        }
    #endregion

    #region Function of Day Cash List
            public void GvCashList()
            {
                DataView dv = new DataView();
                dv = dayCash.GetAll(2);
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

    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        lblError.Text = "";
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        // dayCash.CashChkin_id = "";
        dayCash.Cashierid = Session["personid"].ToString();
        dayCash.CashierName = Session["PersonName"].ToString();
        dayCash.CashOpening_Amount = TxBx_DayCash.Text.Trim().ToString();
        dayCash.CashStatus = "Online";
        dayCash.Enteredon = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        dayCash.Branchid = Session["branchid"].ToString();
        if (dayCash.Insert() == true)
        {
            lblError.Text = "Cash Entry has been entered successfully";
            GvCashFunction();
            GvCashList();
        }
    }


    

    protected void gvCLosing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            Session["reportname"] = "CashClosing";
            Session["selectionformula"] = "";
            Session["selectionformula"] = "{command.reportno}='" + gvCLosing.Rows[index].Cells[1].Text.Trim() + "'";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Closing", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
            // ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Close", "<script>window.open('../Report/wfrmReportView.aspx?ReportNo=" + gvCLosing.Rows[index].Cells[1].Text.Trim() + " &type=C');</script>", false);           
        }
    }

    private void fill_gv()
    {
        clsBLCashRec rec = new clsBLCashRec();
        rec.EnteredBy = Session["personid"].ToString();

        DataView dv = rec.GetAll(12);

        gvCLosing.DataSource = dv;
        gvCLosing.DataBind();
    }
    private void gv_Waiting()
    {
        clsBLMain rec = new clsBLMain();
        rec.CashierID = this.Session["personid"].ToString();

        DataView dv = rec.GetAll(7);
        DataView dvRef = rec.GetAll(8);

        gvWaiting.DataSource = dv;
        gvWaiting.DataBind();

        gvRefund.DataSource = dvRef;
        gvRefund.DataBind();


        if (dv.Count > 0)
        {
            lblCash.Text = dv[0]["totalcash"].ToString();
        }
        else
            lblCash.Text = "0";
        if (dvRef.Count > 0)
            lblrefAmt.Text = dvRef[0]["totalrefund"].ToString();
        else
            lblrefAmt.Text = "0";

        lblBalance.Text = Convert.ToString(Convert.ToInt32(lblCash.Text.Trim()) - Convert.ToInt32(lblrefAmt.Text.Trim()));

        lblrefAmt.Text = "Total Refund: " + lblrefAmt.Text.Trim();
        lblCash.Text = "Total Received: " + lblCash.Text.Trim();

        lblBalance.Text = "Balance: " + lblBalance.Text.Trim();
    }

    protected void gvCLosing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCLosing.PageIndex = e.NewPageIndex;
        fill_gv();
    }



    protected void Gv_DayCashOn_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        clsBLCashRec rec = new clsBLCashRec();

        rec.EnteredBy = Session["personid"].ToString();
        DataView dv = rec.GetAll(2);
        if (Convert.ToInt32(dv[0]["totalentries"].ToString()) > 0)
        {
            rec.EnteredBy = Session["personid"].ToString();
            rec.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            rec.ClientID = Session["orgid"].ToString();
            if (rec.Cash_Close())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Report has been generated successfully";
                //Session["reportname"] = "CashClosing";
                //Session["selectionformula"] = "";
                //Session["selectionformula"] = "{command.reportno}='" + rec.ReportNo + "'";

                ImageButton img = sender as ImageButton;
                DataControlFieldCell cell = img.Parent as DataControlFieldCell;
                GridViewRow row = cell.Parent as GridViewRow;
                int index = row.RowIndex;
                string check_ID = (Gv_DayCashOn.Rows[index].FindControl("Lb_CheckInID") as Label).Text;
                dayCash.CashChkin_id = check_ID;
                dayCash.CashStatus = "Offline";
                dayCash.CashClosing_Amount = (Gv_DayCashOn.Rows[index].FindControl("TxBx_CashClosing") as TextBox).Text;
                dayCash.Enteredoff = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                dayCash.Enteredby = Session["personid"].ToString();
                dayCash.Reportno = rec.ReportNo;
                if (dayCash.Update() == true)
                {
                    lblError.Text = "Cash Entries has been closed successfully.";
                    GvCashFunction();
                    GvCashList();
                }
                
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Closing", "<script>window.open('rptCashClose.aspx');</script>", false);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('rptCashClose.aspx?reportno=" + rec.ReportNo + "');</script>", false);
          
                fill_gv();
                gv_Waiting();
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = rec.Error;
            }
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = ".....No new record found";
        }

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