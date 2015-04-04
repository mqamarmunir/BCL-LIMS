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

public partial class lab_cash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        Response.CacheControl = "no-cache";
        
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {               
               // 
                clsLogin log = new clsLogin();
                log.OptionId = "29";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    rdbPay_Mode.Items.FindByValue("C").Selected = true;
                    txtCal.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtCal_To.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                   // FillBranch();
                    gv_FillWait();
                    
                    Get_Summary();
                    pnl_info.Visible = true;
                    rdbMode.Items.FindByValue("C").Selected = true;
                    PaidAmount();
                }

                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowedCashier.aspx");
                }

            }
        }
        else
        {
            Response.Redirect("../NewLogin.aspx");
        }
    }


    public void PaidAmount()
    {
        lblPRno.Text = Request.QueryString["prno"].ToString();
        lblName.Text = Request.QueryString["pname"].ToString();
        lblLabID.Text = Request.QueryString["labid"].ToString();
        lblTOtalAmt.Text = Request.QueryString["totalAmt"].ToString();
        //lblRem.Text = Request.QueryString["amount"].ToString();

        double amountLeft = Convert.ToDouble(Request.QueryString["totalAmt"].ToString()) - Convert.ToDouble(Request.QueryString["amount"].ToString());
        lblRem.Text = amountLeft.ToString();
        txtPaid.Text = lblRem.Text.Trim();

        clsBLCashRec rec = new clsBLCashRec();
        rec.LabID = lblLabID.Text.Trim();
        DataView dv = rec.GetAll(3);

        gvTest.DataSource = dv;
        gvTest.DataBind();
        pnl_info.Visible = true;

        //txtPaid.Text = "";
    }

    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("NewLogin.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_Form();
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        gv_FillWait();
    }

    private void Clear_Form()
    {
        txtPrNo.Text = "";
        txtName.Text = "";
        txtCal.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtCal_To.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        lblCount.Text = "";

       // ddlBranch.SelectedItem.Selected = false;
        //ddlBranch.Items.FindByValue(Session["branchid"].ToString()).Selected = true;
    }
    private void gv_FillWait()
    {
        clsBLCashRec rec = new clsBLCashRec();

        if (!txtName.Text.Trim().Equals(""))
            rec.Patient = this.txtName.Text.Trim();
        if (!txtPrNo.Text.Trim().Equals("") && !txtPrNo.Text.Trim().Equals("___-__-________"))
            rec.PRNO = this.txtPrNo.Text.Trim();
        if (!txtCal.Text.Trim().Equals("") && !txtCal.Text.Trim().Equals("__/__/____"))
            rec.Date = this.txtCal.Text.Trim().Substring(6, 4) + "/" + txtCal.Text.Trim().Substring(3, 2) + "/" + txtCal.Text.Trim().Substring(0, 2);

        if (!txtCal_To.Text.Trim().Equals("") && !txtCal_To.Text.Trim().Equals("__/__/____"))
            rec.ToDate = this.txtCal_To.Text.Trim().Substring(6, 4) + "/" + txtCal_To.Text.Trim().Substring(3, 2) + "/" + txtCal_To.Text.Trim().Substring(0, 2);
        rec.BranchID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
            //this.ddlBranch.SelectedItem.Value.ToString();
            //Session["branchid"].ToString();
        rec.PaymentMode = rdbPay_Mode.SelectedItem.Value.ToString().Equals("C") ? "'C','P'" : "'A'";

        rec.Branch_ID = Session["BranchID"].ToString().Trim();
        DataView dv = rec.GetAll(1);
        
        if (dv.Count > 0)
        {
            gvWaitQueue.DataSource = dv;
            gvWaitQueue.DataBind();
            lblCount.Text =" Total Records Found ( <b>"+ dv.Count+"</b> )";
        }
        else
        {
            gvWaitQueue.DataSource = null;
            gvWaitQueue.DataBind();
            lblCount.Text = " Total Records Found ( <b>" + dv.Count + "</b> )";
        }
    }

    private void Get_Summary()
    {
        clsBLCashRec rec = new clsBLCashRec();
        rec.EnteredBy = Session["personid"].ToString();

        DataView dv = rec.GetAll(2);

        //lblTotal.Text = "Total Entries :" + dv[0]["Totalentries"] + "    Cash Received: " + dv[0]["paidamount"].ToString()+"    Cash Refund: "+dv[0]["refundamount"].ToString()+"   Balance: "+dv[0]["balance"].ToString()+"";
    }
    private void FillBranch()
    {
        clsBLPatientReg_Inv rec = new clsBLPatientReg_Inv();
        DataView dv = rec.GetAll(19);
        SComponents com = new SComponents();
        com.FillDropDownListWithoutSelect(ddlBranch, dv, "name", "orgid",true,false);
        try
        {
            ddlBranch.SelectedItem.Selected = false;
            ddlBranch.Items.FindByValue(Session["branchid"].ToString()).Selected = true;
        }
        catch { }
    }


    private void Clear_Infor()
    {
        lblTOtalAmt.Text = "";
        lblPRno.Text = "";
        lblName.Text = "";

        lblLabID.Text = "";
        txtPaid.Text = "";
        pnl_info.Visible = true;
        rdbMode.Items.FindByValue("C").Selected = true;

        gvTest.DataSource = null;
        gvTest.DataBind();
        lblCount.Text = "";
    }
    private bool Validate_Form()
    {
        lblError_pnl.ForeColor = System.Drawing.Color.Red;
        if (txtPaid.Text.Trim().Equals(""))
        {
            lblError_pnl.Text = "Please enter receive amount.(empty is not allowed)";
            txtPaid.Focus();
            return false;
        }
        if (Convert.ToInt32(lblRem.Text.Trim()) != 0 && Convert.ToInt32(txtPaid.Text.Trim()) == 0 && gvTest.DataKeys[0].Values[2].ToString() == "" && ( txtDiscount.Text.Trim().Equals("") || txtDiscount.Text.Trim().Equals("0")))
        {
            lblError_pnl.Text = "Please enter correct receive amount .";
            txtPaid.Focus();
            return false;
        }
        if (Convert.ToInt32(txtPaid.Text.Trim()) > Convert.ToInt32(lblRem.Text.Trim()))
        {
            lblError_pnl.Text = "Please enter receive amount equal or less than balance amount .";
            txtPaid.Focus();
            return false;
        }
        if (Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 100)
        {
            lblError_pnl.Text = "Please enter discount percentage less than or equal to 100 ";
            txtDiscount.Focus();
            return false;
        }
        return true;
    }
   
    protected void gvWaitQueue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError_pnl.Text = "";
        txtDiscount.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblPRno.Text = gvWaitQueue.Rows[index].Cells[2].Text.Trim();
            lblName.Text = gvWaitQueue.Rows[index].Cells[3].Text.Trim();

            lblLabID.Text = gvWaitQueue.Rows[index].Cells[1].Text.Trim();
            lblTOtalAmt.Text = gvWaitQueue.Rows[index].Cells[4].Text.Trim();
            // txtPaid.Text = gvWaitQueue.Rows[index].Cells[4].Text.Trim();
            lblRem.Text = gvWaitQueue.DataKeys[index].Values[2].ToString().Trim();
            txtPaid.Text = lblRem.Text.Trim();

            clsBLCashRec rec = new clsBLCashRec();
            rec.LabID = lblLabID.Text.Trim();
            DataView dv = rec.GetAll(3);

            gvTest.DataSource = dv;
            gvTest.DataBind();
            pnl_info.Visible = true;
        }
    }
    protected void imgClosePnl_Click(object sender, ImageClickEventArgs e)
    {
        Clear_Infor();
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Validate_Form())
            return;

        clsBLCashRec rec = new clsBLCashRec();

        rec.PRID = gvTest.DataKeys[0].Value.ToString();
        rec.BookingID = gvTest.DataKeys[0].Values[1].ToString();
        rec.PanelID = gvTest.DataKeys[0].Values[2].ToString().Equals("") ? "~!@" : gvTest.DataKeys[0].Values[2].ToString();

        rec.LabID = this.lblLabID.Text.Trim();
        rec.TotalAmount = this.lblTOtalAmt.Text.Trim();
        rec.PaidAmount = this.txtPaid.Text.Trim().Equals("") ? "0" : txtPaid.Text.Trim();
        rec.PaymentMode = this.rdbMode.SelectedItem.Value.ToString();

        rec.BranchID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
            //this.ddlBranch.SelectedItem.Value.ToString();
            //Session["branchid"].ToString();
        rec.EnteredBy = Session["personid"].ToString();
        rec.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        rec.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
            //this.ddlBranch.SelectedItem.Value.ToString();
            //Session["orgid"].ToString(); // org
        if (Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 0)
        {
            rec.Discount_Amt_Test = Convert.ToString(Convert.ToInt32(lblRem.Text.Trim()) * Convert.ToInt32(txtDiscount.Text.Trim()) / 100);
            rec.PaidAmount = this.txtPaid.Text.Trim();
           // rec.PaidAmount  =Convert.ToString( Convert.ToInt32(lblRem.Text.Trim()) - (Convert.ToInt32(lblRem.Text.Trim()) * Convert.ToInt32(txtDiscount.Text.Trim()) / 100)); 
        }
        else
        {
            rec.Discount_Amt_Test = "0";
        }

        string[,] str = new string[gvTest.Rows.Count, 2];
        int count = 0;
        
        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
        for (int i = 0; i < gvTest.Rows.Count; i++)
        {
            str[count, 0] = gvTest.DataKeys[i].Values[3].ToString(); // testid
            //rec.PaidAmount = this.txtPaid.Text.Trim().Equals("") ? "0" : txtPaid.Text.Trim();
           // str[count, 1] = "0"; // discount as per test            

            iv.TestID = gvTest.DataKeys[i].Values[3].ToString(); // testid
            iv.BookingID = gvTest.DataKeys[0].Values[1].ToString(); // bookingid
            DataView dv = iv.GetAll(25);

                if (dv.Count == 0)
                    str[count, 1] = "~!@";
                else if (Convert.ToInt32(dv[0]["current_status"]) == 2 || dv[0]["current_status"] == "N")
                {
                    for (int m = 0; m < dv.Count; m++)
                    {
                        if (!dv[m]["processid"].Equals("1") && !dv[m]["processid"].Equals("2"))
                        {
                            if (dv[m]["processid"].ToString().Trim().Equals("3") || dv[m]["processid"].ToString().Trim().Equals("4") || dv[m]["processid"].ToString().Trim().Equals("5"))
                            {
                                str[count, 1] = dv[m]["processid"].ToString().Trim();
                                break;
                            }
                        }
                    }
                }

                else
                    str[count, 1] = dv[0]["current_status"].ToString();
            count++;
        }

        if (rec.Cash_Receive(str))
        {
            Clear_Infor();
            gv_FillWait();

            clsBLMain mn = new clsBLMain();
            mn.ReceiveNo = rec.ReceiveNo;
            DataView dv = mn.GetAll(30);
            Session["testtable"] = dv.Table;
            Session["reportname"] = "cashReceipt";
            Session["selectionformula"] = "";
            Session["selectionformula"] = "{command.receiveno}='" + rec.ReceiveNo + "'";

            Response.Write("<script language='javascript'>alert('Cash has been received successfully')</script>");

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Closing", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);  

           // ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Refund Receipt", "<script>window.open('../print.aspx?labid=" + rec.LabID + " &recno=" + rec.ReceiveNo + "');</script>", false); 
           
        }
        else
        {
            lblError_pnl.ForeColor = System.Drawing.Color.Red;
            lblError_pnl.Text = rec.Error;
        }

    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv_FillWait();
        Clear_Infor();
    }
    protected void rdbPay_Mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv_FillWait();
    }
}
