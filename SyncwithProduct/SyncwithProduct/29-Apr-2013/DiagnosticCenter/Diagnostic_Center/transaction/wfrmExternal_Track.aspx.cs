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

public partial class external_track : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "54";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    mde_intcmt.Hide();
                    rdbLab.Items.FindByValue("All").Selected = true;
                    txtfromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    Fill_GV_Pending();
                    Fill_GV_Processed();
                    Fill_DDLORG();
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
        Fill_GV_Pending();
        Fill_GV_Processed();
    }
    private void Fill_GV_Pending()
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        clsBLExternalTrack et = new clsBLExternalTrack();
        clsValidation vd = new clsValidation();

        if(!vd.IsDate(txtfromDate.Text.Trim()))
        {
            lblError.Text = "Please enter valid from date";
            return ;
        }
        if (!vd.IsDate(txtToDate.Text.Trim()))
        {
            lblError.Text = "Please enter valid to date";
            return;
        }

        et.OrgID = this.rdbLab.SelectedItem.Value.ToString().Equals("All") ? "~!@" : rdbLab.SelectedItem.Value.ToString().Replace("BCL", "006").Replace("AMC", "008");

        et.FromDate = txtfromDate.Text.Trim().Substring(6, 4) + "/" + txtfromDate.Text.Trim().Substring(3, 2) + "/" + txtfromDate.Text.Trim().Substring(0, 2);
        et.ToDate = txtToDate.Text.Trim().Substring(6, 4) + "/" + txtToDate.Text.Trim().Substring(3, 2) + "/" + txtToDate.Text.Trim().Substring(0, 2);
        et.BranchID = Session["BranchID"].ToString().Trim();
        DataView dv = et.GetAll(1);
        lblPend_Count.Text = "(<b>" + dv.Count + "</b>)";
        gvPending.DataSource = dv;
        gvPending.DataBind();
    }
    private void Fill_GV_Processed()
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        clsBLExternalTrack et = new clsBLExternalTrack();
        clsValidation vd = new clsValidation();

        if (!vd.IsDate(txtfromDate.Text.Trim()))
        {
            lblError.Text = "Please enter valid from date";
            return;
        }
        if (!vd.IsDate(txtToDate.Text.Trim()))
        {
            lblError.Text = "Please enter valid to date";
            return;
        }

        et.OrgID = this.rdbLab.SelectedItem.Value.ToString().Equals("All") ? "~!@" : rdbLab.SelectedItem.Value.ToString().Replace("BCL", "006").Replace("AMC", "008");

        et.FromDate = txtfromDate.Text.Trim().Substring(6, 4) + "/" + txtfromDate.Text.Trim().Substring(3, 2) + "/" + txtfromDate.Text.Trim().Substring(0, 2);
        et.ToDate = txtToDate.Text.Trim().Substring(6, 4) + "/" + txtToDate.Text.Trim().Substring(3, 2) + "/" + txtToDate.Text.Trim().Substring(0, 2);
        et.BranchID = Session["BranchID"].ToString().Trim();
       
        DataView dv = et.GetAll(2);
        lblProce_Count.Text =" (<b>"+ dv.Count + "</b>)";
        gvProcessed.DataSource = dv;
        gvProcessed.DataBind();
    }
    private void Fill_DDLORG()
    {
        SComponents com = new SComponents();
        clsBLExternalTrack et = new clsBLExternalTrack();
        DataView dv = et.GetAll(3);
        com.FillDropDownList(ddlOrg_Pnl, dv, "name", "orgid");
    }
    
    public void Send_Inv()
    {
        clsBLExternalTrack et = new clsBLExternalTrack();
        et.LabID = this.lbLabID.Text.Trim();
        et.TestID = this.lbltestID.Text.Trim();

        et.OrgID = this.ddlOrg_Pnl.SelectedItem.Value.ToString();
        et.Send_Time = this.txtSend_Date.Text.Trim() + " " + this.txtSend_Time.Text.Trim();
        et.Rec_Time = this.txtRec_Date.Text.Trim() + " " + this.txtRec_Time.Text.Trim();
        et.Original_Org = this.lblOriginal_org.Text.Trim();
        et.Comment = this.txtComment.Text.Trim().Replace("'","''");

        et.EnteredBy = Session["personid"].ToString();
        et.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        et.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();

        if (et.Send_Inv())
        {
            //lblError.ForeColor = System.Drawing.Color.Green;
            //lblError.Text = "Investigation send successfully";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Investigation send successfully');</script>", false);
            Fill_GV_Pending();
            Fill_GV_Processed();
            mde_intcmt.Hide();

            DataView dv = et.GetAll(4);
            Session["testtable"] = dv.Table;
            string sSelectionFormula = "";
            sSelectionFormula = "{command.testid} = [" + this.lbltestID.Text.Trim() + "] and {command.labid} in ['" +this.lbLabID.Text.Trim() + "'] ";

            Session["reportname"] = "OutSide_Receipt";
            Session["selectionformula"] = "";
            Session["selectionformula"] = sSelectionFormula;

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
            
        }
        else
        {
            lblErr_Pnl.ForeColor = System.Drawing.Color.Red;
            lblErr_Pnl.Text = et.Error;
            mde_intcmt.Show();
        }
    }
    public void Rece_Inv()
    {
        clsBLExternalTrack et = new clsBLExternalTrack();
        et.OutID = this.lblOutID.Text.Trim();
        et.LabID = this.lbLabID.Text.Trim();
        et.TestID = this.lbltestID.Text.Trim();

        et.OrgID = this.ddlOrg_Pnl.SelectedItem.Value.ToString();
        et.Send_Time = this.txtSend_Date.Text.Trim() + " " + this.txtSend_Time.Text.Trim();
        et.Rec_Time = this.txtRec_Date.Text.Trim() + " " + this.txtRec_Time.Text.Trim();
        //et.Original_Org = this.lblOriginal_org.Text.Trim();

        et.EnteredBy = Session["personid"].ToString();
        et.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        et.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();

        if (et.Rec_Inv())
        {
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Investigation send successfully";
            Fill_GV_Pending();
            Fill_GV_Processed();
            mde_intcmt.Hide();

            DataView dv = et.GetAll(4);
            Session["testtable"] = dv.Table;
            string sSelectionFormula = "";
            sSelectionFormula = "{command.testid} = [" + this.lbltestID.Text.Trim() + "] and {command.labid} in ['" + this.lbLabID.Text.Trim() + "'] ";

            Session["reportname"] = "OutSide_Receipt";
            Session["selectionformula"] = "";
            Session["selectionformula"] = sSelectionFormula;

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
        }
        else
        {
            lblErr_Pnl.ForeColor = System.Drawing.Color.Red;
            lblErr_Pnl.Text = et.Error;
            mde_intcmt.Show();
        }
    }
   

    protected void gvPending_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            mde_intcmt.Show();
            txtRec_Date.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtRec_Time.Text = System.DateTime.Now.ToString("HH:mm");

            txtSend_Date.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtSend_Time.Text = System.DateTime.Now.ToString("HH:mm");

            lblErr_Pnl.Text = "";
            ddlOrg_Pnl.SelectedIndex = -1;
            lblHead.Text = "Investigation Send";
            lblStatus.Text = "i";

            lblOriginal_org.Text = gvPending.DataKeys[index].Value.ToString();
            lbltestID.Text = gvPending.DataKeys[index].Values[1].ToString();
            lbLabID.Text = gvPending.Rows[index].Cells[1].Text.Trim();

            lblVisitNo.Text = gvPending.Rows[index].Cells[1].Text.ToString();
            lblPatient.Text = gvPending.Rows[index].Cells[2].Text.ToString();
            lblTestName.Text = gvPending.Rows[index].Cells[3].Text.ToString();
            lblReportingTime.Text = gvPending.Rows[index].Cells[6].Text.ToString();

            for (int i = 0; i < gvProcessed.Rows.Count; i++)
            {
                System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo("ur-PK");

                DateTime nowTime = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yy hh:mm tt"), cult);
                DateTime dt_ = Convert.ToDateTime(gvProcessed.Rows[i].Cells[7].Text.Trim(), cult);
                //TimeSpan total = dt_.Subtract(nowTime);

                if (DateTime.Compare(nowTime, dt_) > 0)
                {
                    gvProcessed.Rows[i].BackColor = System.Drawing.Color.FromName("#cc3366");
                    gvProcessed.Rows[i].ForeColor = System.Drawing.Color.WhiteSmoke;
                }
            }

            try {
                ddlOrg_Pnl.ClearSelection();
                ddlOrg_Pnl.Items.FindByValue(gvPending.DataKeys[index].Values[2].ToString()).Selected=true;
            }
            catch { }
        }
    }
    protected void imgCmt_Close_Click(object sender, ImageClickEventArgs e)
    {
        mde_intcmt.Hide();       
    }
    protected void imgcmt_save_Click(object sender, ImageClickEventArgs e)
    {
        clsValidation vd = new clsValidation();
        if (ddlOrg_Pnl.SelectedIndex <= 0)
        {
            lblErr_Pnl.Text = "Please select organization";
            ddlOrg_Pnl.Focus();
            mde_intcmt.Show();
            return;
        }
        if (!vd.IsDate(txtSend_Date.Text.Trim()))
        {
            lblErr_Pnl.Text = "Please select or enter valid send date";
            txtSend_Date.Focus();
            mde_intcmt.Show();
            return;
        }
        if (!vd.IsTime_24(txtSend_Time.Text.Trim()))
        {
            lblErr_Pnl.Text = "Please select or enter valid send time";
            txtSend_Time.Focus();
            mde_intcmt.Show();
            return;
        }

        if (!vd.IsDate(txtRec_Date.Text.Trim()))
        {
            lblErr_Pnl.Text = "Please select or enter valid estimated receive date";
            txtRec_Date.Focus();
            mde_intcmt.Show();
            return;
        }
        if (!vd.IsTime_24(txtRec_Time.Text.Trim()))
        {
            lblErr_Pnl.Text = "Please select or enter valid estimated receive time";
            txtRec_Time.Focus();
            mde_intcmt.Show();
            return;
        }
        if (DateTime.Compare(DateTime.Parse(txtSend_Date.Text.Trim() + " " + txtSend_Time.Text.Trim()), DateTime.Parse(txtRec_Date.Text.Trim() + " " + txtRec_Time.Text.Trim())) >= 0)
        {
            lblErr_Pnl.Text = "Please enter send time is less than receive time";
            txtSend_Date.Focus();
            mde_intcmt.Show();
            return;
        }

        if (lblStatus.Text.Trim().Equals("i"))
            Send_Inv();
        else if (lblStatus.Text.Trim().Equals("u"))
            Rece_Inv();
    }
    protected void gvProcessed_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            mde_intcmt.Show();

            txtRec_Date.Text = gvProcessed.DataKeys[index].Values[6].ToString();
            txtRec_Time.Text = gvProcessed.DataKeys[index].Values[7].ToString();

            txtSend_Date.Text = gvProcessed.DataKeys[index].Values[1].ToString();
            txtSend_Time.Text = gvProcessed.DataKeys[index].Values[2].ToString();

            //txtSend_Date.Enabled = false;
            //txtSend_Time.Enabled = false;

            lblHead.Text = "Investigation Receive";
            lblStatus.Text = "u";
            
            //lblOriginal_org.Text = gvProcessed.DataKeys[index].Value.ToString();
            lbltestID.Text = gvProcessed.DataKeys[index].Values[0].ToString();
            lbLabID.Text = gvProcessed.Rows[index].Cells[1].Text.Trim();
            lblOutID.Text = gvProcessed.DataKeys[index].Values[4].ToString();

            lblVisitNo.Text = gvProcessed.Rows[index].Cells[1].Text.ToString();
            lblPatient.Text = gvProcessed.Rows[index].Cells[2].Text.ToString();
            lblTestName.Text = gvProcessed.Rows[index].Cells[3].Text.ToString();
            lblReportingTime.Text = gvProcessed.Rows[index].Cells[5].Text.ToString();

            for (int i = 0; i < gvProcessed.Rows.Count; i++)
            {
                System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo("ur-PK");

                DateTime nowTime = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yy hh:mm tt"), cult);
                DateTime dt_ = Convert.ToDateTime(gvProcessed.Rows[i].Cells[7].Text.Trim(), cult);
                //TimeSpan total = dt_.Subtract(nowTime);

                if (DateTime.Compare(nowTime, dt_) > 0)
                {
                    gvProcessed.Rows[i].BackColor = System.Drawing.Color.FromName("#cc3366");
                    gvProcessed.Rows[i].ForeColor = System.Drawing.Color.WhiteSmoke;
                }
            }
            try
            {
                ddlOrg_Pnl.ClearSelection();
                ddlOrg_Pnl.Items.FindByValue(gvProcessed.DataKeys[index].Values[5].ToString()).Selected = true;
                //ddlOrg_Pnl.Enabled = false;
            }
            catch { }
        }
    }
    protected void gvProcessed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo("ur-PK");

            DateTime nowTime = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yy hh:mm tt"), cult);
            DateTime dt_ = Convert.ToDateTime(e.Row.Cells[7].Text.Trim(), cult);
            //TimeSpan total = dt_.Subtract(nowTime);

            if (DateTime.Compare(nowTime,dt_) > 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#cc3366");
                e.Row.ForeColor = System.Drawing.Color.WhiteSmoke;
            }

            if (gvProcessed.DataKeys[e.Row.RowIndex].Values[8].ToString() == "8")
            {
                e.Row.BackColor = System.Drawing.Color.LightSeaGreen;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvProcessed.DataKeys[e.Row.RowIndex].Values[8].ToString() == "7")
            {
                e.Row.BackColor = System.Drawing.Color.CornflowerBlue;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (gvProcessed.DataKeys[e.Row.RowIndex].Values[8].ToString() == "6")
            {
                e.Row.BackColor = System.Drawing.Color.Violet;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            if (gvProcessed.DataKeys[e.Row.RowIndex].Values[8].ToString() == "5")
            {
                e.Row.BackColor = System.Drawing.Color.Thistle;
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            if (gvProcessed.DataKeys[e.Row.RowIndex].Values[8].ToString() == "4")
            {
                e.Row.BackColor = System.Drawing.Color.CadetBlue;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
           

        }

    }
}
