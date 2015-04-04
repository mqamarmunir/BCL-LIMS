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

public partial class general_trans : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {      
                clsLogin log = new clsLogin();
                log.OptionId = "37";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    rdbPanelOption.Visible = false;
                    rdbCashoption.Visible = false;
                    pnlPanel.Visible = false;
                    pnlSearch.Visible = false;

                    txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    Fill_DDL_Panel();
                    GetConsultant();
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

    protected void rdbOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlSearch.Visible = false;
        lblComp_head.Text = "";
        ddlPanel.Visible = false;
        
        if (rdbOption.SelectedItem.Value.Equals("P"))
        {
            try
            { rdbCashoption.SelectedItem.Selected = false; }
            catch { }
            try
            {
                rdbPanelOption.SelectedItem.Selected = false;
            }
            catch { }
            
            rdbPanelOption.Visible = true;
            rdbCashoption.Visible = false;
            gvAuthorize.DataSource = null;
            gvAuthorize.DataBind();
            lblCount.Text = "";

            gvCash.DataSource = null;
            gvCash.DataBind();

            gvConsult.DataSource = null;
            gvConsult.DataBind();
            
        } 
        else if (rdbOption.SelectedItem.Value.Equals("C"))
        {
            try
            {
                rdbPanelOption.SelectedItem.Selected = false;
            }
            catch { }
            rdbPanelOption.Visible = false;
            pnlPanel.Visible = false;

            gvAuthorize.DataSource = null;
            gvAuthorize.DataBind();
            lblCount.Text = "";

            rdbCashoption.Visible = true;
            try
            { rdbCashoption.SelectedItem.Selected = false; }
            catch { }

            gvCash.DataSource = null;
            gvCash.DataBind();

            gvConsult.DataSource = null;
            gvConsult.DataBind();

          
        }
        else if (rdbOption.SelectedItem.Value.Equals("D"))
        {
            try
            {
                rdbPanelOption.SelectedItem.Selected = false;
            }
            catch { }
            rdbPanelOption.Visible = false;
            pnlPanel.Visible = false;
            gvAuthorize.DataSource = null;
            gvAuthorize.DataBind();
            lblCount.Text = "";

            rdbCashoption.Visible = false;
            try
            { rdbCashoption.SelectedItem.Selected = false; }
            catch { }

            gvCash.DataSource = null;
            gvCash.DataBind();

            pnlSearch.Visible = true;
            lblComp_head.Text = "";
            ddlPanel.Visible = false;

        }
    }
    protected void imgp_Close_Click(object sender, ImageClickEventArgs e)
    {
        this.pnlPanel.Visible = false;
        lblp_Date.Text = "";
        lblP_LabID.Text = "";
        lblP_Patient.Text = "";
        lblP_prno.Text = "";
        txtp_Auth.Text = "";
    }

    protected void rdbPanelOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlSearch.Visible = true;
        lblComp_head.Text = "Panel";
        ddlPanel.Visible = true;
        if (rdbPanelOption.SelectedItem.Value.Equals("Authorize No"))
        {
            Fill_GV_Auth();
        }
    }
    protected void imgp_save_Click(object sender, ImageClickEventArgs e)
    {
        if (txtp_Auth.Text.Trim().Equals(""))
        {
            lblP_Error.ForeColor = System.Drawing.Color.Red;
            lblP_Error.Text = "Please enter authorize number";
            return;
        }

        clsBLGeneral gn = new clsBLGeneral();
        gn.BookingID = lblp_bookingID.Text.Trim();
        gn.AuthorizeNo = this.txtp_Auth.Text.Trim().Replace("'","''");

        if (gn.Update_Authorize())
        {
            lblP_Error.ForeColor = System.Drawing.Color.Green;
            lblP_Error.Text = "";
            Fill_GV_Auth();
            pnlPanel.Visible = false;

            txtPrNo.Text = "";
            txtName.Text = "";
            ddlPanel.SelectedIndex = -1;
        }
        else
        {
            lblP_Error.ForeColor = System.Drawing.Color.Red;
            lblP_Error.Text = gn.Error;
        }

    }
    protected void gvAuthorize_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        txtp_Auth.Text = "";
        lblP_Error.Text = "";
        lblp_bookingID.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblp_bookingID.Text = gvAuthorize.DataKeys[index].Value.ToString();
            lblp_Date.Text = gvAuthorize.Rows[index].Cells[4].Text.Trim();
            lblP_LabID.Text = gvAuthorize.Rows[index].Cells[1].Text.Trim();

            lblP_prno.Text = gvAuthorize.Rows[index].Cells[2].Text.Trim();
            lblP_Patient.Text = gvAuthorize.Rows[index].Cells[3].Text.Trim();
            lblp_Company.Text = gvAuthorize.Rows[index].Cells[5].Text.Trim();

            pnlPanel.Visible = true;
        }
    }

    private void Fill_GV_Auth()
    {
        clsBLGeneral gn = new clsBLGeneral();
        gn.FromDate = txtFrom.Text.Substring(6,4) + "-" + txtFrom.Text.Substring(3,2) + "-" + txtFrom.Text.Substring(0,2);
        gn.ToDate = txtTo.Text.Substring(6, 4) + "-" + txtTo.Text.Substring(3, 2) + "-" + txtTo.Text.Substring(0, 2);
        gn.PRNo = this.txtPrNo.Text.Trim();
        gn.PatientName = this.txtName.Text.Trim();
        gn.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        gn.BranchID = Session["BranchID"].ToString().Trim();


        DataView dv = gn.GetAll(1); // fill authorize
        gvAuthorize.DataSource = dv;
        gvAuthorize.DataBind();
        lblCount.Text = "Total Record Found (<b> " + dv.Count + "</b> )";
    }
    private void Fill_GV_Receipt()
    {
        clsBLGeneral gn = new clsBLGeneral();

        gn.FromDate = txtFrom.Text.Substring(6, 4) + "-" + txtFrom.Text.Substring(3, 2) + "-" + txtFrom.Text.Substring(0, 2);
        gn.ToDate = txtTo.Text.Substring(6, 4) + "-" + txtTo.Text.Substring(3, 2) + "-" + txtTo.Text.Substring(0, 2);
        gn.PRNo = this.txtPrNo.Text.Trim();
        gn.PatientName = this.txtName.Text.Trim();
        gn.BranchID = Session["BranchID"].ToString().Trim();
       



        DataView dv;
        if (rdbCashoption.SelectedItem.Value.Trim().Equals("C"))
            dv = gn.GetAll(2);
        else
            dv = gn.GetAll(3);

        gvCash.DataSource = dv;
        gvCash.DataBind();

        lblCount.Text = "Total Record Found (<b> " + dv.Count + "</b> )";
    }
    private void Fill_DDL_Panel()
    {
        clsBLGeneral gn = new clsBLGeneral();
        SComponents com = new SComponents();
        DataView dv = gn.GetAll(4);

        com.FillDropDownList(ddlPanel, dv, "name", "panelid");
    }
    private void Fill_Consult_Chng_queue()
    {
        clsBLGeneral gn = new clsBLGeneral();

        gn.FromDate = txtFrom.Text.Substring(6, 4) + "-" + txtFrom.Text.Substring(3, 2) + "-" + txtFrom.Text.Substring(0, 2);
        gn.ToDate = txtTo.Text.Substring(6, 4) + "-" + txtTo.Text.Substring(3, 2) + "-" + txtTo.Text.Substring(0, 2);
        gn.PRNo = this.txtPrNo.Text.Trim();
        gn.PatientName = this.txtName.Text.Trim();

        DataView dv = gn.GetAll(5);

        gvConsult.DataSource = dv;
        gvConsult.DataBind();
        
    }

    private void GetConsultant()
    {
        clsBLGeneral gen = new clsBLGeneral();
        DataView dv = gen.GetAll(6);
        Session["consultfill"] = dv;
    }

    protected void rdbCashoption_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlSearch.Visible = true;
        lblComp_head.Text = "";
        ddlPanel.Visible = false;

        Fill_GV_Receipt();
    }
    protected void gvCash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        txtPrNo.Text = "";
        txtName.Text = "";
        ddlPanel.SelectedIndex = -1;
        clsBLMain mn = new clsBLMain();
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (gvCash.DataKeys[index].Value.Equals("C"))
            {
                mn.ReceiveNo = gvCash.Rows[index].Cells[1].Text.Trim();
                DataView dv = mn.GetAll(30);
                Session["testtable"] = dv.Table;
                Session["reportname"] = "cashReceipt";
                Session["selectionformula"] = "";
                Session["selectionformula"] = "{command.receiveno}='" + gvCash.Rows[index].Cells[1].Text.Trim() + "'";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Closing", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);

               
                 //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx');</script>", false);

            
            }
            else if (gvCash.DataKeys[index].Value.Equals("R"))
            {
                mn.RefundNo = gvCash.Rows[index].Cells[1].Text.Trim();
                DataView dv = mn.GetAll(31);
                Session["testtable"] = dv.Table;
                Session["reportname"] = "cashRefund";
                Session["selectionformula"] = "";
                Session["selectionformula"] = "{command.refundno}='" + gvCash.Rows[index].Cells[1].Text.Trim() + "'";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Closing", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);  
              //  Response.Write("<script language='javascript'>window.open('../Refund.aspx?refundno=" + gvCash.Rows[index].Cells[1].Text.Trim() + "')</script>");
            }
        }
    }

    protected void imgCLose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (rdbOption.SelectedItem.Value.Trim().Equals("P") && rdbPanelOption.SelectedItem.Value.Trim().Equals("Authorize No"))
            Fill_GV_Auth();
        else if (rdbOption.SelectedItem.Value.Trim().Equals("C"))
            Fill_GV_Receipt();
        else if (rdbOption.SelectedItem.Value.Trim().Equals("D"))
            Fill_Consult_Chng_queue();
    }
    protected void gvConsult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string doctorid = ((DropDownList)(gvConsult.Rows[index].Cells[7].FindControl("ddlConslt"))).SelectedItem.Value.ToString();
            TextBox txtRef = (TextBox)(gvConsult.Rows[index].Cells[8].FindControl("txtRefDoctor"));

            if (doctorid.Equals("-1") && txtRef.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please select referred doctor in list or enter referred doctor name in next column');</script>", false);
                return;
            }
            //if (!doctorid.Equals("-1") && !txtRef.Text.Trim().Equals(""))
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please select referred doctor in list or enter referred doctor in next column');</script>", false);
            //    return;
            //}
          

            clsBLGeneral gn = new clsBLGeneral();
            gn.BookingID = gvConsult.DataKeys[index].Value.ToString();

            if (!doctorid.Equals("-1"))           
                gn.ConsultantID = doctorid.ToString();
            
            else
                gn.Consult_Name = txtRef.Text.Trim().Replace("'", "''");

            if (gn.Update_ConsultName())
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Consultant name has been changed successfully');</script>", false);
                Fill_Consult_Chng_queue();
            }
            else
            {
                lblP_Error.ForeColor = System.Drawing.Color.Red;
                lblP_Error.Text = gn.Error;
            }

        }
    }
    protected void gvConsult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int index = e.Row.RowIndex;
        if (index != -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlForward = (DropDownList)e.Row.Cells[7].FindControl("ddlConslt");
            SComponents com = new SComponents();
            DataView dv = (DataView)Session["consultfill"];
            com.FillDropDownList(ddlForward, dv, "name", "doctorid");

            try
            {
                ddlForward.ClearSelection();
                ddlForward.Items.FindByValue(gvConsult.DataKeys[e.Row.RowIndex].Values[1].ToString()).Selected = true;
            }
            catch { }
        }
    }
    protected void gvCash_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hyperLink_Payment = e.Row.FindControl("Hyper_Pay") as HyperLink;
            hyperLink_Payment.NavigateUrl = "wfrmCashReport.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno");
            hyperLink_Payment.Target = "wfrmCashReport.aspx?labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno");
        }
       

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    if (gvCash.DataKeys[e.Row.RowIndex].Values[3].ToString() == "7" || gvCash.DataKeys[e.Row.RowIndex].Values[3].ToString() == "8" || (gvCash.DataKeys[e.Row.RowIndex].Values[3].ToString() == "6" && gvCash.DataKeys[e.Row.RowIndex].Values[4].ToString() == "Y"))
        //    {
        //        if (gvCash.DataKeys[e.Row.RowIndex].Values[6].ToString().Equals("C") && Convert.ToInt32(e.Row.Cells[7].Text.Trim().Replace("-", "0")) > 0)
        //        {
        //            //Img_cprint
        //            (e.Row.Cells[14].FindControl("Img_cprint") as Image).Visible = true;
        //            (e.Row.Cells[13].FindControl("Img_print") as Image).Visible = false;

        //            //ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Please clear dues first');</script>", false);
        //            //return;
        //        }
        //        else
        //        {
        //            HyperLink hyperLink_Payment = e.Row.FindControl("Hyper_Pay") as HyperLink;
        //            hyperLink_Payment.NavigateUrl = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId");
        //            hyperLink_Payment.Target = "CheckTest.aspx?prid=" + DataBinder.Eval(e.Row.DataItem, "prid") + "&bookingid=" + DataBinder.Eval(e.Row.DataItem, "bookingdid") + "&testtype=" + DataBinder.Eval(e.Row.DataItem, "TestType") + "&labid=" + DataBinder.Eval(e.Row.DataItem, "labid") + "&prno=" + DataBinder.Eval(e.Row.DataItem, "prno") + "&testid=" + DataBinder.Eval(e.Row.DataItem, "testid") + "&subdepartmentId=" + DataBinder.Eval(e.Row.DataItem, "subdepartmentId");
        //            (e.Row.Cells[14].FindControl("Img_cprint") as Image).Visible = false;
        //            (e.Row.Cells[13].FindControl("Img_print") as Image).Visible = true;
        //        }
        //    }
        //    else
        //    {

        //        (e.Row.Cells[14].FindControl("Img_cprint") as Image).Visible = true;
        //        (e.Row.Cells[13].FindControl("Img_print") as Image).Visible = false;
        //        //ScriptManager.RegisterStartupScript(this, typeof(Page), "warning", "<script language='javascript'>alert('Report is not ready yet');</script>", false);
        //        //return;
        //    }


    }
}
