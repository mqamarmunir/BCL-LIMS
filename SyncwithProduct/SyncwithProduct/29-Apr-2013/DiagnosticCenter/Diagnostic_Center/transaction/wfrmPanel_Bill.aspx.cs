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

public partial class panelbill : System.Web.UI.Page
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
                log.OptionId = "61";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    FillDDL_Panel();
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
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        Frm_Clear();
        ddlPanel.SelectedIndex = -1;
        txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtBillNo.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please enter bill number');</script>", false);
            return;
        }
        if (lblBillID.Text.Trim().Equals(""))
            Insert();
        else
            Update();
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlPanel.SelectedIndex <= 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please select panel first');</script>", false);
            return;
        }
        Fill_GVPending();
    }

    private void FillDDL_Panel()
    {
        SComponents com = new SComponents();
        clsBLPanel_Bill pb = new clsBLPanel_Bill();

        DataView dv = pb.GetAll(1);
        com.FillDropDownList(ddlPanel, dv, "name", "panelid");
    }
    private void Fill_GVPending()
    {
        clsBLPanel_Bill pb = new clsBLPanel_Bill();
        pb.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        pb.From_Date = this.txtFrom.Text.Trim().Substring(6, 4) + "-" + this.txtFrom.Text.Trim().Substring(3, 2) + "-" + this.txtFrom.Text.Trim().Substring(0,2);
        pb.To_Date = this.txtTo.Text.Trim().Substring(6, 4) + "-" + this.txtTo.Text.Trim().Substring(3, 2) + "-" + this.txtTo.Text.Trim().Substring(0, 2);

        DataView dv = pb.GetAll(2);
        gvPending.DataSource = dv;
        gvPending.DataBind();

        int total = 0;
        for (int i = 0; i < gvPending.Rows.Count; i++)
        {
           total += Convert.ToInt32(gvPending.DataKeys[i].Values[2].ToString());
        }

        gvPending.Columns[2].FooterText = "Total Booking";
        gvPending.Columns[3].FooterText = gvPending.Rows.Count.ToString();
        gvPending.Columns[4].FooterText = "Total Amount";
        gvPending.Columns[5].FooterText = total.ToString();

        gvPending.DataBind();

    }
    private void Fill_GvBill()
    {
        clsBLPanel_Bill pb = new clsBLPanel_Bill();
        pb.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        DataView dv = pb.GetAll(3);
        gvPreious.DataSource = dv;
        gvPreious.DataBind();
    }

    private void Insert()
    {
        clsBLPanel_Bill pb = new clsBLPanel_Bill();
        string[,] str = new string[gvPending.Rows.Count, 8];
        for (int i = 0; i < gvPending.Rows.Count; i++)
        {
            str[i, 0] = gvPending.DataKeys[i].Value.ToString(); // prid
            str[i, 1] = gvPending.DataKeys[i].Values[1].ToString(); // bookingid
            str[i, 2] = ((TextBox)(gvPending.Rows[i].Cells[4].FindControl("txtGvRef_1"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[5].FindControl("txtGvRef_1"))).Text.Trim(); // ref 1

            str[i, 3] = ((TextBox)(gvPending.Rows[i].Cells[5].FindControl("txtGvRef_2"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[6].FindControl("txtGvRef_2"))).Text.Trim(); // ref 2
            str[i, 4] = ((TextBox)(gvPending.Rows[i].Cells[6].FindControl("txtGvServiceNo"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[7].FindControl("txtGvServiceNo"))).Text.Trim(); // service no

            str[i, 5] = ((TextBox)(gvPending.Rows[i].Cells[7].FindControl("txtGvAuthorizeNo"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[8].FindControl("txtGvAuthorizeNo"))).Text.Trim(); // authorize no
            str[i, 6] = ((TextBox)(gvPending.Rows[i].Cells[8].FindControl("txtGvAuthroize_Date"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[9].FindControl("txtGvAuthroize_Date"))).Text.Trim(); // authorize date
            str[i, 7] = ((CheckBox)(gvPending.Rows[i].Cells[9].FindControl("chkGvAddBill"))).Checked ? "Y" : "N"; // add bill
        }

        pb.Bill_No = this.txtBillNo.Text.Trim();
        pb.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        pb.From_Date = this.txtFrom.Text.Trim();
        pb.To_Date =this.txtTo.Text.Trim();

        pb.Billing_Month = this.txtBill_Month.Text.Trim();
        pb.Bill_Ref1 = this.txtRef_1.Text.Trim();
        pb.Bill_Ref2 = this.txtRef_2.Text.Trim();

        pb.Show_Ref1 = this.chkRef1.Checked ? "Y" : "N";
        pb.Show_Ref2 = this.chkRef2.Checked ? "Y" : "N";
        pb.Discount = this.txtDiscount.Text.Trim().Equals("") ? "0" : this.txtDiscount.Text.Trim();

        pb.Authorization_No = this.txtAuthorize_No.Text.Trim();
        pb.Authorization_Date = this.txtAuthorize_Date.Text.Trim();
        pb.ServiceNo = this.txtServiceNo.Text.Trim();

        pb.Display_Date = this.chkDis_Date.Checked ? "Y" : "N";
        pb.Bill_Date = this.txtBill_Date.Text.Trim();
        pb.TotalCharges = gvPending.Columns[5].FooterText.ToString();

        pb.EnteredBy = Session["personid"].ToString();
        pb.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pb.ClientID = Session["orgid"].ToString();

        if (pb.Insert(str))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Record has been saved successfully');</script>", false);
            Fill_GVPending();
            Fill_GvBill();
            Frm_Clear();

            string sSelectionFormula = "";
            sSelectionFormula = "{dc_vpn_bill.billid}=" + pb.BillID + " and {dc_vpn_bill.panelid}=" + pb.PanelID + "";
            Session["reportname"] = "pnl_bill";
            Session["selectionformula"] = "";
            Session["selectionformula"] = sSelectionFormula;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('"+pb.Error+"');</script>", false);
 
        }
       
    }
    private void Update()
    {
        clsBLPanel_Bill pb = new clsBLPanel_Bill();
        string[,] str = new string[gvPending.Rows.Count, 8];
        for (int i = 0; i < gvPending.Rows.Count; i++)
        {
            str[i, 0] = gvPending.DataKeys[i].Value.ToString(); // prid
            str[i, 1] = gvPending.DataKeys[i].Values[1].ToString(); // bookingid
            str[i, 2] = ((TextBox)(gvPending.Rows[i].Cells[4].FindControl("txtGvRef_1"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[5].FindControl("txtGvRef_1"))).Text.Trim(); // ref 1

            str[i, 3] = ((TextBox)(gvPending.Rows[i].Cells[5].FindControl("txtGvRef_2"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[6].FindControl("txtGvRef_2"))).Text.Trim(); // ref 2
            str[i, 4] = ((TextBox)(gvPending.Rows[i].Cells[6].FindControl("txtGvServiceNo"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[7].FindControl("txtGvServiceNo"))).Text.Trim(); // service no

            str[i, 5] = ((TextBox)(gvPending.Rows[i].Cells[7].FindControl("txtGvAuthorizeNo"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[8].FindControl("txtGvAuthorizeNo"))).Text.Trim(); // authorize no
            str[i, 6] = ((TextBox)(gvPending.Rows[i].Cells[8].FindControl("txtGvAuthroize_Date"))).Text.Trim().Equals("") ? "~!@" : ((TextBox)(gvPending.Rows[i].Cells[9].FindControl("txtGvAuthroize_Date"))).Text.Trim(); // authorize date
            str[i, 7] = ((CheckBox)(gvPending.Rows[i].Cells[9].FindControl("chkGvAddBill"))).Checked ? "Y" : "N"; // add bill
        }

        pb.BillID = this.lblBillID.Text.Trim();
        pb.Bill_No = this.txtBillNo.Text.Trim();
        pb.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        pb.From_Date = this.txtFrom.Text.Trim();
        pb.To_Date = this.txtTo.Text.Trim();

        pb.Billing_Month = this.txtBill_Month.Text.Trim();
        pb.Bill_Ref1 = this.txtRef_1.Text.Trim();
        pb.Bill_Ref2 = this.txtRef_2.Text.Trim();

        pb.Show_Ref1 = this.chkRef1.Checked ? "Y" : "N";
        pb.Show_Ref2 = this.chkRef2.Checked ? "Y" : "N";
        pb.Discount = this.txtDiscount.Text.Trim().Equals("") ? "0" : this.txtDiscount.Text.Trim();

        pb.Authorization_No = this.txtAuthorize_No.Text.Trim();
        pb.Authorization_Date = this.txtAuthorize_Date.Text.Trim();
        pb.ServiceNo = this.txtServiceNo.Text.Trim();

        pb.Display_Date = this.chkDis_Date.Checked ? "Y" : "N";
        pb.Bill_Date = this.txtBill_Date.Text.Trim();
        pb.TotalCharges = gvPending.Columns[5].FooterText.ToString();

        pb.EnteredBy = Session["personid"].ToString();
        pb.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pb.ClientID = Session["orgid"].ToString();

        if (pb.Update(str))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Record has been saved successfully');</script>", false);
            Fill_GVPending();
            Frm_Clear();
            Fill_GvBill();

            string sSelectionFormula = "";
            sSelectionFormula = "{dc_vpn_bill.billid}=" + pb.BillID + " and {dc_vpn_bill.panelid}=" + pb.PanelID + "";
            Session["reportname"] = "pnl_bill";
            Session["selectionformula"] = "";
            Session["selectionformula"] = sSelectionFormula;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + pb.Error + "');</script>", false);

        }

    }
    private void Frm_Clear()
    {
        txtAuthorize_Date.Text = "";
        txtAuthorize_No.Text = "";
        txtBill_Date.Text = "";

        txtBill_Month.Text = "";
        txtBillNo.Text = "";
        txtRef_1.Text = "";

        txtRef_2.Text = "";
        txtServiceNo.Text = "";
        lblBillID.Text = "";
    }

    protected void ddlPanel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_GVPending();
        Fill_GvBill();
    }

    protected void gvPreious_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Print"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            string sSelectionFormula = "";
            sSelectionFormula = "{dc_vpn_bill.billid}=" + gvPreious.DataKeys[index].Value.ToString() + " ";
            Session["reportname"] = "pnl_bill";
            Session["selectionformula"] = "";
            Session["selectionformula"] = sSelectionFormula;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
        }
    }
    protected void gvlbtnExpend_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        GridViewRow gvr = (GridViewRow)lbtn.Parent.Parent;
        int index = gvr.RowIndex;

        GridView gv = (GridView)gvPending.Rows[index].Cells[10].FindControl("gvTestDetail");

        if (lbtn.Text.Equals("+"))
        {
            lbtn.Text = "-";
            gv.Visible = true;
            clsBLPanel_Bill pb = new clsBLPanel_Bill();
            pb.BookingID = gvPending.DataKeys[index].Values[1].ToString();
            DataView dv = pb.GetAll(5);
            gv.DataSource = dv;
            gv.DataBind();
            
        }
        else
        {
            lbtn.Text = "+";
            gv.Visible = false;
            gv.DataSource = null;
            gv.DataBind();
        }

    }
    protected void gvPreious_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = Convert.ToInt32(e.NewEditIndex);
        clsBLPanel_Bill pb = new clsBLPanel_Bill();
        pb.BillID = gvPreious.DataKeys[index].Value.ToString();
        lblBillID.Text = gvPreious.DataKeys[index].Value.ToString();
        DataView dv = pb.GetAll(4);

        gvPending.DataSource = dv;
        gvPending.DataBind();

        gvPending.Columns[2].FooterText = "Total Booking";
        gvPending.Columns[3].FooterText = gvPending.Rows.Count.ToString();
        gvPending.Columns[4].FooterText = "Total Amount";
        gvPending.Columns[5].FooterText = dv[0]["totalcharges"].ToString();
        gvPending.DataBind();

        txtAuthorize_Date.Text = dv[0]["b_authorize_date"].ToString();
        txtAuthorize_No.Text = dv[0]["b_authorize_no"].ToString();
        txtBill_Date.Text = dv[0]["bill_date"].ToString();
        txtBill_Month.Text = dv[0]["billing_month"].ToString();

        txtBillNo.Text = dv[0]["billno"].ToString();
        txtFrom.Text = dv[0]["fromdate"].ToString();
        txtTo.Text = dv[0]["todate"].ToString();

        txtRef_1.Text = dv[0]["ref1"].ToString();
        txtRef_2.Text = dv[0]["ref2"].ToString();
        txtServiceNo.Text = dv[0]["service_no"].ToString();
        chkDis_Date.Checked = dv[0]["display_date"].ToString().Equals("Y") ? true : false;
        chkRef1.Checked = dv[0]["show_ref1"].ToString().Equals("Y") ? true : false;
        chkRef2.Checked = dv[0]["show_ref2"].ToString().Equals("Y") ? true : false;
       txtDiscount.Text = dv[0]["discount"].ToString().Equals("") ? "0" : dv[0]["discount"].ToString();
        
    }
}
