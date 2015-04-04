using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessLayer;

public partial class transaction_wfrmCashierEntry : System.Web.UI.Page
{
    private static string DGSort = "";
    private static string DGSort1 = "";
    private static string DGSort2 = "";
    private static string DGSort3 = "";

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
                    dayCashCheckinout();
                    if (Gv_DayCashOn.Rows.Count > 0)
                    {
                        tblpreviousreports.Visible = false;
                        lblpreviousrec.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowed.aspx");
                }
            }
            
        }
        else
        {
            Response.Redirect("../NewLogin.aspx");
        }
    }

    public void dayCashCheckinout()
    {
        DataView dv = new DataView();
        dayCash.Branchid = Session["branchid"].ToString();
        dv = dayCash.GetAll(20);
        if(dv.Count>0)
        {
            if (dv[0]["cashStatus"].ToString().ToLower() == "online")
            {
                imgSave.Visible = false;
                imgClose.Visible = false;
                Label4.Visible = true;
            }
            else
            {
                imgSave.Visible = true;
                imgClose.Visible = true;
                Label4.Visible = false;
            }
        }
        else
        {
            imgSave.Visible = true;
            imgClose.Visible = true;
            Label4.Visible = false;
        }
    }

    #region Function of DayCash Gridview
    public void GvCashFunction()
    {
        DataView dv = new DataView();
        dayCash.Cashierid = Session["personid"].ToString();
        dv = dayCash.GetAll(1);
        dv.Sort = DGSort1;

        Gv_DayCashOn.DataSource = dv;
        Gv_DayCashOn.DataBind();
    }
    #endregion

    void clear()
    {
        lblError.Text = "";
        TxBx_DayCash.Text = "";
        TxBx_DayCash.Text = "";
    }

    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../transaction/wfrmCashierEntry.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        // dayCash.CashChkin_id = "";
        dayCash.Cashierid = Session["personid"].ToString();
        dayCash.CashierName = Session["PersonName"].ToString();
        dayCash.CashOpening_Amount = TxBx_DayCash.Text.Trim().ToString();
        dayCash.CashStatus = "Online";
        dayCash.Enteredon = System.DateTime.Now.ToString();
        dayCash.Branchid = Session["branchid"].ToString();
        if (dayCash.Insert() == true)
        {
            lblError.Text = "Cash Entry has been entered successfully";
            GvCashFunction();
            clear();
            dayCashCheckinout();
            tblpreviousreports.Visible = false;
            lblpreviousrec.Visible = true;
        }
        else
        {
            lblError.Text = dayCash.ErrorMessage;
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
        dv.Sort = DGSort3;
        gvCLosing.DataSource = dv;
        gvCLosing.DataBind();
        
        foreach (GridViewRow row in gvCLosing.Rows)
        {
           
            float a = float.Parse( gvCLosing.DataKeys[row.RowIndex][0].ToString());
            float b = float.Parse(gvCLosing.DataKeys[row.RowIndex][1].ToString());

            //float c = a - b;
            Label lblcash = (Label)row.FindControl("lblcash");
           // lblcash.Text = c.ToString();
            Label lblStatus = (Label)row.FindControl("lblStatus");
            if(a==b)
            {
                
                 lblStatus.Text = "Balanced";
               
                  lblStatus.ForeColor= Color.Green;
            }

            if (a > b)
            {
                float netamount = a - b;
                lblcash.Text = netamount.ToString();
                lblStatus.Text = "Excess";
                lblStatus.ForeColor = Color.Blue;
            }
            if (a < b)
            {
                float castclosingamont = b - a;
                lblcash.Text = castclosingamont.ToString();
                lblStatus.Text = "Short";
                lblStatus.ForeColor = Color.Red;
            }
          }
    

       
    }
    private void gv_Waiting()
    {
        clsBLMain rec = new clsBLMain();
        rec.CashierID = this.Session["personid"].ToString();

        DataView dv = rec.GetAll(7);
        DataView dvRef = rec.GetAll(8);
        dv.Sort = DGSort;
        dvRef.Sort = DGSort2;

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
        ImageButton img = sender as ImageButton;
        DataControlFieldCell cell = img.Parent as DataControlFieldCell;
        GridViewRow row = cell.Parent as GridViewRow;
        int index = row.RowIndex;
        dayCash.CashClosing_Amount = (Gv_DayCashOn.Rows[index].FindControl("TxBx_CashClosing") as TextBox).Text;
        if (dayCash.CashClosing_Amount == "")
        {
            lblError.Text = "Please enter closing amount of cash.";
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        else
        {

            //if (gvAttribute.Rows.Count == 0)
            //{
          //  }

            rec.EnteredBy = Session["personid"].ToString();
            DataView dv = rec.GetAll(2);
            if (Convert.ToInt32(dv[0]["totalentries"].ToString()) > 0)
            {
                rec.EnteredBy = Session["personid"].ToString();
                rec.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                rec.ClientID = Session["ClientID"].ToString();
                if (rec.Cash_Close())
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Report has been generated successfully";
                  
                    string check_ID = (Gv_DayCashOn.Rows[index].FindControl("Lb_CheckInID") as Label).Text;
                    dayCash.CashChkin_id = check_ID;
                    dayCash.CashStatus = "Offline";
                    dayCash.CashClosing_Amount = (Gv_DayCashOn.Rows[index].FindControl("TxBx_CashClosing") as TextBox).Text;
                    dayCash.Enteredoff = System.DateTime.Now.ToString();
                    dayCash.Enteredby = Session["personid"].ToString();
                    dayCash.Reportno = rec.ReportNo;
                    if (dayCash.Update() == true)
                    {
                        lblError.Text = "Cash Entries has been closed successfully.";
                        GvCashFunction();
                        imgSave.Visible = true;
                        imgClose.Visible = true;
                        Label4.Visible = false;
                        tblpreviousreports.Visible = true;
                        lblpreviousrec.Visible = false;
                    }


                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Closing", "<script>window.open('rptCashClose.aspx');</script>", false);
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('rptCashClose.aspx?reportno=" + rec.ReportNo + "');</script>", false); old cash report link
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmdaycashstatement.aspx?reportno=" + rec.ReportNo + "');</script>", false);
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
                //lblError.Text = ".....No new record found";

                string check_ID = (Gv_DayCashOn.Rows[index].FindControl("Lb_CheckInID") as Label).Text;
                dayCash.CashChkin_id = check_ID;
                dayCash.CashStatus = "Offline";
                dayCash.CashClosing_Amount = (Gv_DayCashOn.Rows[index].FindControl("TxBx_CashClosing") as TextBox).Text;
                dayCash.Enteredoff = System.DateTime.Now.ToString();
                dayCash.Enteredby = Session["personid"].ToString();
                dayCash.Reportno = "00-000000";
                if (dayCash.Update() == true)
                {
                    lblError.Text = "Cash Entries has been closed successfully.";
                    GvCashFunction();
                    imgSave.Visible = true;
                    imgClose.Visible = true;
                    Label4.Visible = false;
                    tblpreviousreports.Visible = true;
                    lblpreviousrec.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script language='javascript'>alert('Cash has been Closed  without any booking. Report is not available')</script>", false);
                return;

            }
        }

    }


    protected void Gv_DayCashList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hyperLink_Payment = e.Row.FindControl("HYp_CashClose") as HyperLink;
            hyperLink_Payment.NavigateUrl = "wfrmdaycashstatement.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
            hyperLink_Payment.Target = "wfrmdaycashstatement.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
        }
    }
    
    protected void gvWaiting_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("receiveno"))
            {
                if (DGSort == "receiveno ASC")
                    DGSort = "receiveno DESC";
                else
                    DGSort = "receiveno ASC";

            }
        else if (e.SortExpression.Equals("prno"))
            {
                if (DGSort == "prno ASC")
                    DGSort = "prno DESC";
                else
                    DGSort = "prno ASC";

            }
        else if (e.SortExpression.Equals("patientname"))
            {
                if (DGSort == "patientname ASC")
                    DGSort = "patientname DESC";
                else
                    DGSort = "patientname ASC";
            }
        else if (e.SortExpression.Equals("paymentmode"))
            {
                if (DGSort == "paymentmode ASC")
                    DGSort = "paymentmode DESC";
                else
                    DGSort = "paymentmode ASC";
            }
        else if (e.SortExpression.Equals("paidamount"))
            {
                if (DGSort == "paidamount ASC")
                    DGSort = "paidamount DESC";
                else
                    DGSort = "paidamount ASC";
            }
        else if (e.SortExpression.Equals("receiveon"))
            {
                if (DGSort == "receiveon ASC")
                    DGSort = "receiveon DESC";
                else
                    DGSort = "receiveon ASC";
            }



        gv_Waiting();



        }

    protected void Gv_DayCashOn_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("cashierName"))
        {
            if (DGSort1 == "cashierName ASC")
                DGSort1 = "cashierName DESC";
            else
                DGSort1 = "cashierName ASC";

        }
        else if (e.SortExpression.Equals("cashOpening_Amount"))
        {
            if (DGSort1 == "cashOpening_Amount ASC")
                DGSort1 = "cashOpening_Amount DESC";
            else
                DGSort1 = "cashOpening_Amount ASC";

        }
        else if (e.SortExpression.Equals("enteredon"))
        {
            if (DGSort1 == "enteredon ASC")
                DGSort1 = "enteredon DESC";
            else
                DGSort1 = "enteredon ASC";
        }
        else if (e.SortExpression.Equals("Name"))
        {
            if (DGSort1 == "Name ASC")
                DGSort1 = "Name DESC";
            else
                DGSort1 = "Name ASC";
        }


        GvCashFunction();



    }
    protected void gvRefund_Sorting(object sender, GridViewSortEventArgs e)
    {
            if (e.SortExpression.Equals("refundno"))
            {
                if (DGSort2 == "refundno ASC")
                    DGSort2 = "refundno DESC";
                else
                    DGSort2 = "refundno ASC";

            }
            else if (e.SortExpression.Equals("prno"))
            {
                if (DGSort2 == "prno ASC")
                    DGSort2 = "prno DESC";
                else
                    DGSort2 = "prno ASC";

            }
            else if (e.SortExpression.Equals("patientname"))
            {
                if (DGSort2 == "patientname ASC")
                    DGSort2 = "patientname DESC";
                else
                    DGSort2 = "patientname ASC";
            }
            else if (e.SortExpression.Equals("refundtype"))
            {
                if (DGSort2 == "refundtype ASC")
                    DGSort2 = "refundtype DESC";
                else
                    DGSort2 = "refundtype ASC";
            }
            else if (e.SortExpression.Equals("paidamount"))
            {
                if (DGSort2 == "paidamount ASC")
                    DGSort2 = "paidamount DESC";
                else
                    DGSort2 = "paidamount ASC";
            }
            else if (e.SortExpression.Equals("refundon"))
            {
                if (DGSort2 == "refundon ASC")
                    DGSort2 = "pairefundondamount DESC";
                else
                    DGSort2 = "refundon ASC";
            




        }
    }
    protected void gvCLosing_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("reportno"))
            {
                if (DGSort3 == "reportno ASC")
                    DGSort3 = "reportno DESC";
                else
                    DGSort3 = "reportno ASC";

            }
        else if (e.SortExpression.Equals("printon"))
            {
                if (DGSort3 == "printon ASC")
                    DGSort3 = "printon DESC";
                else
                    DGSort3 = "printon ASC";

            }
        else if (e.SortExpression.Equals("collectedcash"))
            {
                if (DGSort3 == "collectedcash ASC")
                    DGSort3 = "collectedcash DESC";
                else
                    DGSort3 = "collectedcash ASC";
            }
        else if (e.SortExpression.Equals("refundedamount"))
            {
                if (DGSort3 == "refundedamount ASC")
                    DGSort3 = "refundedamount DESC";
                else
                    DGSort3 = "refundedamount ASC";
            }
        else if (e.SortExpression.Equals("netamount"))
            {
                if (DGSort3 == "netamount ASC")
                    DGSort3 = "netamount DESC";
                else
                    DGSort3 = "netamount ASC";
            }
        else if (e.SortExpression.Equals("cashOpening_Amount"))
        {
            if (DGSort3 == "cashOpening_Amount ASC")
                DGSort3 = "cashOpening_Amount DESC";
            else
                DGSort3 = "cashOpening_Amount ASC";

        }

        fill_gv();

    
    }
    protected void gvCLosing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hyperLink_Payment = e.Row.FindControl("HYp_CashClose") as HyperLink;
           // hyperLink_Payment.NavigateUrl = "rptCashClose.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno"); old cash report link
           // hyperLink_Payment.Target = "rptCashClose.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
            hyperLink_Payment.NavigateUrl = "wfrmdaycashstatement.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");
            hyperLink_Payment.Target = "wfrmdaycashstatement.aspx?reportno=" + DataBinder.Eval(e.Row.DataItem, "reportno");

        }
    }
}