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

public partial class cashrefund : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
   
      //  Response.CacheControl = "no-cache";
       
        if (!Session.Equals(""))
        {
            if (!IsPostBack)
            {               
                clsLogin log = new clsLogin();
                log.OptionId = "30";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtCal_From.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtCal_To.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    FillBranch();
                    Search_Patient();
                    Fill_DDlAuth();
                    pnl_Save.Visible = false;
                    lblRefundAmt.Text = "0";
                    Get_Summary();

                    lblDiscount.Text = "";
                    txtDiscount.Visible = false;
                   
                    //System.Web.UI.ScriptManager.GetCurrent(this).SetFocus(this.txtName);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "selectAndFocus", "$get('" + txtName.ClientID + "').focus();$get('" + txtName.ClientID + "').select();", true);
                   // txtName.Attributes.Add("onkeyup", "if(this.value != prevText) {" + Page.ClientScript.GetPostBackEventReference(txtName, "") + ";}");
                   // txtName.Attributes.Add("onkeyup", "prevText = this.value");
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
    
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        Search_Patient();
    }

    private void Search_Patient()
    {
        clsBLCashRec rec = new clsBLCashRec();

        if (!txtCal_From.Text.Trim().Equals("") && !txtCal_From.Text.Trim().Equals("__/__/____"))
            rec.Date = txtCal_From.Text.Trim().Substring(6, 4) + "/" + txtCal_From.Text.Trim().Substring(3, 2) + "/" + txtCal_From.Text.Trim().Substring(0, 2);

        if (!txtCal_To.Text.Trim().Equals("") && !txtCal_To.Text.Trim().Equals("__/__/____"))
            rec.ToDate = txtCal_To.Text.Trim().Substring(6, 4) + "/" + txtCal_To.Text.Trim().Substring(3, 2) + "/" + txtCal_To.Text.Trim().Substring(0, 2);

        if (!txtLab.Text.Trim().Equals(""))
            rec.LabID = this.txtLab.Text.Trim();
        if (!txtName.Text.Trim().Equals(""))
            rec.Patient = this.txtName.Text.Trim();
        if (!txtPaid.Text.Trim().Equals(""))
            rec.ReceiveNo = this.txtPaid.Text.Trim();
        if (!txtPRno.Text.Trim().Equals(""))
            rec.PRNO = this.txtPRno.Text.Trim();
        rec.BranchID = this.ddlBranch.SelectedItem.Value.ToString();
            //Session["orgid"].ToString();

        DataView dv = rec.GetAll(5);

        gvRefund.DataSource = dv;
        gvRefund.DataBind();
       
        lblCount.Text = " Total Records Found ( <b>" + dv.Count + "</b> )";

    }
    private bool Validate_form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        int count = 0;
        int ref_amt = 0;

        if (ddlAuthorized.SelectedIndex <= 0)
        {
            lblError.Text = "Please select refund authorized by";
            ddlAuthorized.Focus();
            return false;
        }
        if (txtComment.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter refund reason.";
            txtComment.Focus();
            return false;
        }
        if (ddlRefundType.SelectedItem.Value.Trim().Equals("D") && Convert.ToInt32(txtDiscount.Text.Trim().Equals("") ? "0" : txtDiscount.Text.Trim()) > 100)
        {
            lblError.Text = "Please enter discount percentage less than or equal to 100 ";
            txtDiscount.Focus();
            return false;
        }
        if (ddlRefundType.SelectedItem.Value.Trim().Equals("D") && Convert.ToInt32(lblBalance.Text.Trim().Equals("") ? "0" : lblBalance.Text.Trim()) == 0)
        {
            lblError.Text = "Discount could not be made due to zero balance. ";
            txtDiscount.Focus();
            return false;
        }

        for (int i = 0; i < gvTest.Rows.Count; i++)
        {
            if (((TextBox)(gvTest.Rows[i].Cells[3].FindControl("txtGVRefund"))).Text.Equals(""))
            {
                continue;
            }
            else if (Convert.ToInt32(((TextBox)(gvTest.Rows[i].Cells[3].FindControl("txtGVRefund"))).Text.Trim()) > Convert.ToInt32(gvTest.Rows[i].Cells[2].Text.Trim())) 
            {
                lblError.Text = "Your refund amount is greater than test amount.Please correct amount";

                return false;
            }
            //else if (Convert.ToInt32(((TextBox)(gvTest.Rows[i].Cells[3].FindControl("txtGVRefund"))).Text.Trim()) < Convert.ToInt32(gvTest.Rows[i].Cells[2].Text.Trim()) && ddlRefundType.SelectedItem.Value.ToString().Equals("C"))
            //{
            //    lblError.Text = "You are going to cancel this test and refund amount should be same as test amount.Please correct amount";

            //    return false;
            //}
            else
            {
                ref_amt += Convert.ToInt32(((TextBox)(gvTest.Rows[i].Cells[3].FindControl("txtGVRefund"))).Text.Trim().Equals("") ? "0" : ((TextBox)(gvTest.Rows[i].Cells[3].FindControl("txtGVRefund"))).Text);
                count++;
            }
        }

        if (count == 0)
        {
            if (!ddlRefundType.SelectedItem.Value.Trim().Equals("D"))
            {
                lblError.Text = "Please enter refund amount.";
                return false;
            }
            else if (txtDiscount.Text.Trim().Equals("") && ddlRefundType.SelectedItem.Value.Trim().Equals("D"))
            {
                lblError.Text = "Please enter discount";
                return false;
            }
        }
        if (ref_amt > (Convert.ToInt32(lblPaid.Text.Trim()) - Convert.ToInt32(lblRefundAmt.Text.Trim())))
        {
            lblError.Text = "Your refund amount (<b>"+ref_amt.ToString()+"</b>) is greater than paid amount (<b>"+Convert.ToString(Convert.ToInt32(lblPaid.Text.Trim())-Convert.ToInt32(lblRefundAmt.Text.Trim()))+" </b>)";
            return false;
        }
                return true;
    }

    private void FillBranch()
    {
        clsBLPatientReg_Inv rec = new clsBLPatientReg_Inv();
        DataView dv = rec.GetAll(19);
        SComponents com = new SComponents();
        com.FillDropDownListWithoutSelect(ddlBranch, dv, "name", "orgid", true, false);

        try
        {
            ddlBranch.SelectedItem.Selected = false;
            ddlBranch.Items.FindByValue(Session["branchid"].ToString()).Selected = true;
        }
        catch { }
    }
    private void Get_Summary()
    {
        clsBLCashRec rec = new clsBLCashRec();
        rec.EnteredBy = Session["personid"].ToString();

        DataView dv = rec.GetAll(2);

        lblTotal.Text = "Total Entries :" + dv[0]["Totalentries"] + "    Cash Received: " + dv[0]["paidamount"].ToString() + "    Cash Refund: " + dv[0]["refundamount"].ToString() + "   Balance: " + dv[0]["balance"].ToString() + "";
    }
    private void Fill_DDlAuth()
    {
        clsBLCashRec rec = new clsBLCashRec();
        SComponents com = new SComponents();

        DataView dv = rec.GetAll(6);
        com.FillDropDownList(ddlAuthorized, dv, "personname", "personid");
    }

    private void Fill_GVPre(string labid)
    {
        clsBLCashRec rec = new clsBLCashRec();
        rec.LabID = labid;

        DataView dv = rec.GetAll(8);

        gvHistory.DataSource = dv;
        gvHistory.DataBind();
    }

    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        txtCal_From.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtCal_To.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        txtLab.Text = "";
        txtName.Text = "";

        txtPaid.Text = "";
        txtPRno.Text = "";
        ddlBranch.SelectedItem.Selected = false;
        ddlBranch.Items.FindByValue(Session["branchid"].ToString()).Selected = true;

        Search_Patient();
       
    }
    protected void gvRefund_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ddlAuthorized.SelectedIndex = -1;
        txtComment.Text = "";

        lblRefundAmt.Text = "0";
        lblBalance.Text = "0";
        lblBalance.Visible = false;

        ddlRefundType.SelectedIndex = 0;
        gvTest.Columns[3].Visible = true;

        lblDiscount.Text = "";
        lblPaid.Visible = true;
        txtDiscount.Visible = false;

        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblLabID.Text = gvRefund.Rows[index].Cells[2].Text.Trim();
            lblPaid.Text = gvRefund.Rows[index].Cells[5].Text.Trim();
            lblPaidno.Text = gvRefund.Rows[index].Cells[1].Text.Trim();

            lblPatient.Text = gvRefund.Rows[index].Cells[4].Text.Trim();
            lblPRno.Text = gvRefund.Rows[index].Cells[3].Text.Trim();
            lblBal_Head.Text = "Total Paid:";
            lblBalance.Text = Convert.ToString(Convert.ToInt32(gvRefund.DataKeys[index].Values[2].ToString()) -(Convert.ToInt32(lblPaid.Text.Trim()) + Convert.ToInt32(gvRefund.DataKeys[index].Values[3].ToString())));

            clsBLCashRec rec = new clsBLCashRec();
            rec.LabID = this.lblLabID.Text.Trim();
            //rec.ReceiveNo = this.lblPaidno.Text.Trim();
            DataView dv = rec.GetAll(10);
            DataView dvRem = rec.GetAll(9);

            gvTest.DataSource = dv;
            gvTest.DataBind();

            if (dvRem.Count > 0)
            {
                for (int i = 0; i < dvRem.Count; i++)
                {
                    lblRefundAmt.Text =Convert.ToString( Convert.ToInt32(lblRefundAmt.Text.Trim())+Convert.ToInt32(dvRem[i]["paidamount"].ToString()));
                    for (int m = 0; m < gvTest.Rows.Count; m++)
                    {
                        if (gvTest.DataKeys[m].Values[2].ToString().Trim() == dvRem[i]["testid"].ToString())
                        {
                            gvTest.Rows[m].Cells[2].Text = Convert.ToString(Convert.ToInt32(gvTest.Rows[m].Cells[2].Text.Trim()) - Convert.ToInt32(dvRem[i]["paidamount"].ToString()));
                        }
                    }
                }
            }
            else
            {
                lblRefundAmt.Text = "0";
            }

                Fill_GVPre(lblLabID.Text.Trim());

            pnl_Save.Visible = true;
            pnl_search.Visible = false;
            gvRefund.Visible = false;

            imgClose.Visible = false;
            imgClear.Visible = false;
            imgSearch.Visible = false;
        }
    }

    protected void imgPnl_Close_Click(object sender, ImageClickEventArgs e)
    {
        pnl_Save.Visible = false;
        pnl_search.Visible = true;
        gvRefund.Visible = true;

        imgClose.Visible = true;
        imgClear.Visible = true;
        imgSearch.Visible = true;
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Validate_form())
            return;

        clsBLCashRec rec = new clsBLCashRec();

        rec.AuthorizedBy = this.ddlAuthorized.SelectedItem.Value.ToString();
        rec.BookingID = gvTest.DataKeys[0].Value.ToString();
        rec.PRID = gvTest.DataKeys[0].Values[1].ToString();

        rec.ReceiveNo = this.lblPaidno.Text.Trim();
        rec.LabID = this.lblLabID.Text.Trim();
        rec.RefundType = this.ddlRefundType.SelectedItem.Value.ToString();
        rec.BranchID = this.ddlBranch.SelectedItem.Value.ToString();
            //Session["branchid"].ToString();

        rec.EnteredBy = Session["personid"].ToString();
        rec.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        rec.ClientID = this.ddlBranch.SelectedItem.Value.ToString();
            //Session["orgid"].ToString();
        rec.Comment = this.txtComment.Text.Trim().Replace("'","''");

        if (ddlRefundType.SelectedItem.Value.ToString().Equals("D"))
        {
            rec.TotalAmount = lblBalance.Text.Trim();
            rec.Discount_Amt_Test = Convert.ToString(Convert.ToInt32(lblBalance.Text.Trim()) * Convert.ToInt32(txtDiscount.Text.Trim()) / 100);
            rec.PaidAmount = rec.Discount_Amt_Test;
        }

       
            int count = 0;
            if (txtDiscount.Text.Trim().Equals(""))
            {
                for (int i = 0; i < gvTest.Rows.Count; i++)
                {
                    string strVal = ((TextBox)(gvTest.Rows[i].Cells[3].FindControl("txtGVRefund"))).Text.Trim();
                    if (strVal != "")//&& strVal != "0"
                    {
                        count++;
                    }
                }
            }
            else
                count = gvTest.Rows.Count;

            string[,] str = new string[count, 5];
            count = 0;
            int cal_dis = 0;
            for (int i = 0; i < gvTest.Rows.Count; i++)
            {
                string strVal = ((TextBox)(gvTest.Rows[i].Cells[3].FindControl("txtGVRefund"))).Text.Trim();
                if ((strVal != "") || ddlRefundType.SelectedItem.Value.Trim().Equals("D")) //&& strVal != "0"
                {
                    str[count, 0] = gvTest.DataKeys[i].Values[2].ToString(); // test ID
                    str[count, 1] = gvTest.DataKeys[i].Values[4].ToString(); // bookingdid change(classification ID 3)                    
                    str[count, 2] = ((TextBox)(gvTest.Rows[i].Cells[3].FindControl("txtGVRefund"))).Text.Trim();
                    str[count, 3] = "0";
                    cal_dis = 0;                   
                    
                    str[count, 4] = gvTest.Rows[i].Cells[2].Text.Trim();//total amount
                    count++;
                }
            }
        

            if (rec.Cash_Refund(str))
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Refund has been generated successfully";

                pnl_Save.Visible = false;
                pnl_search.Visible = true;
                gvRefund.Visible = true;

                imgClose.Visible = true;
                imgClear.Visible = true;
                imgSearch.Visible = true;

                Session["reportname"] = "cashRefund";
                Session["selectionformula"] = "";
                Session["selectionformula"] = "{command.refundno}='" + rec.RefundNo + "'";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Closing", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);  

               // ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Refund Receipt", "<script>window.open('../Refund.aspx?refundno=" + rec.RefundNo + "');</script>", false);

                Search_Patient();

            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = rec.Error;
            }
       


        
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Search_Patient();
        pnl_Save.Visible = false;
        pnl_search.Visible = true;
        gvRefund.Visible = true;

        imgClose.Visible = true;
        imgClear.Visible = true;
        imgSearch.Visible = true;
    }
    
    protected void ddlRefundType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRefundType.SelectedItem.Value.Trim().Equals("D"))
        {
            lblDiscount.Text = "Discount:";
            txtDiscount.Visible = true;
            gvTest.Columns[3].Visible = false;

            lblBal_Head.Text = "Balance:";
            lblBalance.Visible = true;
            lblPaid.Visible = false;
            txtDiscount.Text = "";
        }
        else
        {
            lblDiscount.Text = "";
            txtDiscount.Visible = false;
            gvTest.Columns[3].Visible = true;

            lblBal_Head.Text = "Total Paid:";
            lblBalance.Visible = false;
            lblPaid.Visible = true;
            txtDiscount.Text = "";
        }
    }
}
