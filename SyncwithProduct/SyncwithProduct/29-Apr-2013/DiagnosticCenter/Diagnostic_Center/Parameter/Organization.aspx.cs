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

public partial class Organization : System.Web.UI.Page
{
    private static string DGSort = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["Personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "1";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtFee.Text = "0";
                    txtFee.Enabled = false;

                    DGSort = "";
                    lblstatus.Text = "i";
                    lblOrgId.Text = "";
                    FillMainofDDL();
                    FillRoute_DDL();
                    if (!Session["OrgId2"].Equals(""))
                    {
                        lblErrMsg.Text = "";
                        lblstatus.Text = "u";
                        Session["org_timing"] = "";
                        clsOrganization objDC = new clsOrganization();
                        lblOrgId.Text = objDC.OrgId = Session["OrgId2"].ToString();
                        DataView dv = objDC.GetAll(3);
                        if (dv.Count > 0)
                        {
                            this.txtName.Text = dv[0]["Name"].ToString();
                            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                            this.txtPhoneNo.Text = dv[0]["PhoneNo"].ToString();
                            this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
                            this.txtEmail.Text = dv[0]["Email"].ToString();
                            this.txtWebAddress.Text = dv[0]["Web_Address"].ToString();
                            this.txtAddress.Text = dv[0]["Address"].ToString();
                            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                            this.chkMain.Checked = (dv[0]["Main"].ToString().Equals("Y")) ? true : false;
                            if (!dv[0]["Main_of"].ToString().Equals("") && !dv[0]["Main_of"].ToString().Equals("0"))
                            {
                                this.ddlMainof.SelectedValue = dv[0]["Main_of"].ToString();
                            }
                        }
                    }
                    Session["OrgId2"] = "";
                    Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    txtName.Focus();
                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }

    private void FillMainofDDL()
    {
        clsOrganization objOrg = new clsOrganization();
        SComponents objScom = new SComponents();
        objOrg.Main = "Y";
        DataView dv = objOrg.GetAll(4);
        objScom.FillDropDownList(ddlMainof, dv, "Name", "OrgId", true, false, true);
        this.ddlMainof.SelectedValue = "-1";
    }
    private void FillRoute_DDL()
    {
        clsOrganization objOrg = new clsOrganization();
        SComponents objScom = new SComponents();

        objOrg.External = "N";
        DataView dv = objOrg.GetAll(4);
        objScom.FillDropDownList(ddlDefaultRouting, dv, "Name", "OrgId");
    }

    private void Fillgv()
    {
        clsOrganization objDC = new clsOrganization();        
        DataView dv = objDC.GetAll(1);
        if (!this.ddlMainof.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.Main_of = this.ddlMainof.SelectedItem.Value.ToString();
        }    
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvOrganization.DataSource = dv;
            gvOrganization.DataBind();
            gvOrganization.Visible = true;
        }
        else
        {
            gvOrganization.Visible = false;
        }
    }

    private void Insert()
    {
        clsOrganization objDC = new clsOrganization();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.PhoneNo = txtPhoneNo.Text.Trim();

        objDC.FaxNo = txtFaxNo.Text.Trim();
        objDC.Email = txtEmail.Text.Trim();
        objDC.Web_Address = txtWebAddress.Text.Trim();
        objDC.Process_Fee = this.txtFee.Text.Trim().Equals("") ? "0" : txtFee.Text.Trim();

        objDC.Address = txtAddress.Text.Trim();
        if (!this.ddlMainof.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.Main_of = this.ddlMainof.SelectedItem.Value.ToString();
        }

        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Main = chkMain.Checked ? "Y" : "N";
        objDC.External = this.chkExterna.Checked ? "Y" : "N";
        objDC.Indoor_Service = this.chkIndoor.Checked ? "Y" : "N";
        objDC.CollectionCenter = this.chkCollection.Checked ? "Y" : "N";
        objDC.DefaultRoute = this.ddlDefaultRouting.SelectedItem.Value.ToString();

        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org

        string[,] str = new string[gvTiming.Rows.Count, 3];
        for (int i = 0; i < gvTiming.Rows.Count; i++)
        {
            str[i, 0] = gvTiming.Rows[i].Cells[0].Text.Trim(); // start time
            str[i, 1] = gvTiming.Rows[i].Cells[1].Text.Trim(); // close time
            str[i, 2] = gvTiming.Rows[i].Cells[2].Text.Trim(); // day
        }

            if (objDC.Insert(str))
            {
                lblOrgId.Text = objDC.OrgId.ToString();
                Clear();
                lblErrMsg.ForeColor = System.Drawing.Color.Green;
                lblErrMsg.Text = "Record save successfully";
                Fillgv();
            }
            else
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Text = objDC.ErrorMessage;
            }
    }
    private void Update()
    {        
        clsOrganization objDC = new clsOrganization();
        objDC.OrgId = lblOrgId.Text.Trim();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();

        objDC.PhoneNo = txtPhoneNo.Text.Trim();
        objDC.FaxNo = txtFaxNo.Text.Trim();
        objDC.Email = txtEmail.Text.Trim();

        objDC.Web_Address = txtWebAddress.Text.Trim();
        objDC.Address = txtAddress.Text.Trim();
        objDC.Process_Fee = this.txtFee.Text.Trim().Equals("") ? "0" : txtFee.Text.Trim();

        if (!this.ddlMainof.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.Main_of = this.ddlMainof.SelectedItem.Value.ToString();
        }
        else
        {
            objDC.Main_of = "~!@";
        }
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Main = chkMain.Checked ? "Y" : "N";
        objDC.External = this.chkExterna.Checked ? "Y" : "N";
        objDC.Indoor_Service = this.chkIndoor.Checked ? "Y" : "N";
        objDC.CollectionCenter = this.chkCollection.Checked ? "Y" : "N";
        objDC.DefaultRoute = this.ddlDefaultRouting.SelectedItem.Value.ToString();

        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        string[,] str = new string[gvTiming.Rows.Count, 3];
        for (int i = 0; i < gvTiming.Rows.Count; i++)
        {
            str[i, 0] = gvTiming.Rows[i].Cells[0].Text.Trim(); // start time
            str[i, 1] = gvTiming.Rows[i].Cells[1].Text.Trim(); // close time
            str[i, 2] = gvTiming.Rows[i].Cells[2].Text.Trim(); // day
        }
        if (objDC.Update(str))
        {
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Update successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objDC.ErrorMessage;
        }
    }

    private void Clear()
    {
        txtName.Text = "";
        txtAcronym.Text = "";

        txtPhoneNo.Text = "";
        txtFaxNo.Text = "";

        txtEmail.Text = "";
        txtWebAddress.Text = "";
        txtAddress.Text = "";

        txtFee.Enabled = false;
        txtFee.Text = "0";

        txtStartTime.Text = "";
        txtCloseTime.Text = "";
        ddlDay.SelectedIndex = -1;

        this.ddlMainof.SelectedValue = "-1";
        this.ddlDefaultRouting.SelectedIndex = -1;

        chkActive.Checked = true;
        chkMain.Checked = false;
        chkMain.Enabled = true;
        chkExterna.Checked = false;
        chkIndoor.Checked = false;
        chkCollection.Checked = false;

        lblErrMsg.Text = "";
        Fillgv();
        lblstatus.Text = "i";
        Session["org_timing"] = "";
        gvTiming.DataSource = null;
        gvTiming.DataBind();
    }

    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();
        this.txtName.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblOrgId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void gvOrganization_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlMainof.SelectedValue = "-1";
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsOrganization objDC = new clsOrganization();
        lblOrgId.Text = objDC.OrgId = gvOrganization.DataKeys[e.NewEditIndex].Value.ToString();        
        DataView dv = objDC.GetAll(3);
        DataView dvTim = objDC.GetAll(8);
        if (dv.Count > 0)
        {
            this.txtName.Text = dv[0]["Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtPhoneNo.Text = dv[0]["PhoneNo"].ToString();

            this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
            this.txtEmail.Text = dv[0]["Email"].ToString();

            this.txtWebAddress.Text = dv[0]["Web_Address"].ToString();
            this.txtAddress.Text = dv[0]["Address"].ToString();
            txtFee.Text = dv[0]["process_fee"].ToString();

            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            this.chkMain.Checked = (dv[0]["Main"].ToString().Equals("Y")) ? true : false;
            this.chkExterna.Checked = (dv[0]["external"].ToString().Equals("Y")) ? true : false;
            this.chkIndoor.Checked = (dv[0]["indoor_services"].ToString().Equals("Y")) ? true : false;
            this.chkCollection.Checked = (dv[0]["collection_center"].ToString().Equals("Y")) ? true : false;
            if (chkExterna.Checked == true)
            {
                txtFee.Enabled = true;
                chkMain.Enabled = false;
                chkMain.Checked = false;
            }
            else
            {
                txtFee.Enabled = false;
                chkMain.Enabled = true;
            }
            

            //if (!dv[0]["Main_of"].ToString().Equals("") && !dv[0]["Main_of"].ToString().Equals("0"))
            //{
            //    this.ddlMainof.SelectedValue = dv[0]["Main_of"].ToString();
            //}
            try
            {
                ddlMainof.SelectedItem.Selected = false;
                ddlMainof.Items.FindByValue(dv[0]["main_of"].ToString()).Selected = true;
            }
            catch { }
            try
            {
                ddlDefaultRouting.ClearSelection();
                ddlDefaultRouting.Items.FindByValue(dv[0]["default_route"].ToString()).Selected=true;
            }
            catch { }

            gvTiming.DataSource = dvTim;
            gvTiming.DataBind();
            Session["org_timing"] = dvTim.Table;
        }
    }

    protected void gvOrganization_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("NAME"))
        {
            if (DGSort == "NAME ASC")
                DGSort = "NAME DESC";
            else
                DGSort = "NAME ASC";

        }       

        Fillgv();
    }
    protected void gvOrganization_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrganization.PageIndex = e.NewPageIndex;
        Fillgv();
    }

    protected void lbtnSaveNext_Click(object sender, EventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();

        if (lblErrMsg.ForeColor.Equals(System.Drawing.Color.Green))
        {
            Session["OrgId2"] = lblOrgId.Text.Trim();
            Response.Redirect("Department.aspx");
        }
    }
    protected void chkExterna_CheckedChanged(object sender, EventArgs e)
    {
        if (chkExterna.Checked == true)
        {
            txtFee.Enabled = true;
            chkMain.Checked = false;
            chkMain.Enabled = false;
        }
        else
        {
            chkMain.Enabled = true;
            txtFee.Enabled = false;
        }

        txtFee.Text = "0";
    }
    protected void imgAdd_Click(object sender, ImageClickEventArgs e)
    {
        lblErrMsg.Text = "";
        lblErrMsg.ForeColor = System.Drawing.Color.Red;
        DataTable dt = new DataTable();
        clsValidation vd = new clsValidation();

        if (!vd.IsTime_24(txtStartTime.Text.Trim()))
        {
            lblErrMsg.Text = "Please enter valid start time";
            txtStartTime.Focus();
            return;
        }
        if (!vd.IsTime_24(txtCloseTime.Text.Trim()))
        {
            lblErrMsg.Text = "Please enter valid close time";
            txtCloseTime.Focus();
            return;
        }

        if (DateTime.Compare(DateTime.Parse(txtStartTime.Text.Trim()),DateTime.Parse(txtCloseTime.Text.Trim())) > 0)
        {
            lblErrMsg.Text = "Start time is greater than close time. Please correct start and close time";
            return;
        }

        dt.Columns.Add("start_time");
        dt.Columns.Add("close_time");
        dt.Columns.Add("day");

        if (Session["org_timing"].Equals(""))
            Session["org_timing"] = dt;
        else
            dt = (DataTable)Session["org_timing"];

        foreach (DataRow drw in dt.Rows)
        {
            if (ddlDay.SelectedItem.Value.ToString().Trim().Equals("All Days"))
            {
                lblErrMsg.Text = "Day already added.";
                return;
            }

            if (ddlDay.SelectedItem.Value.ToString().Trim().Equals(drw["day"].ToString()))
            {
                lblErrMsg.Text = "Day already added.";
                return;
            }
            if (drw["day"].ToString().Equals("All Days"))
            {
                lblErrMsg.Text = "All Days option already added.";
                return;
            }
        }

        DataRow dr = dt.NewRow();

        dr["start_time"] = this.txtStartTime.Text.Trim();
        dr["close_time"] = this.txtCloseTime.Text.Trim();
        dr["day"] = this.ddlDay.SelectedItem.Value.ToString();

        dt.Rows.Add(dr);

        gvTiming.DataSource = dt;
        gvTiming.DataBind();
        Session["org_timing"] = dt;
    }
    protected void gvTiming_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)Session["org_timing"];
            
        dt.Rows[e.RowIndex].Delete();
        dt.AcceptChanges();
        this.gvTiming.DataSource = dt;
        this.gvTiming.DataBind();
        Session["org_timing"] = dt;
    }

    protected void gvOrganization_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            this.ddlMainof.SelectedValue = "-1";
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsOrganization objDC = new clsOrganization();
            lblOrgId.Text = objDC.OrgId = gvOrganization.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            DataView dvTim = objDC.GetAll(8);
            if (dv.Count > 0)
            {
                this.txtName.Text = dv[0]["Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtPhoneNo.Text = dv[0]["PhoneNo"].ToString();

                this.txtFaxNo.Text = dv[0]["FaxNo"].ToString();
                this.txtEmail.Text = dv[0]["Email"].ToString();

                this.txtWebAddress.Text = dv[0]["Web_Address"].ToString();
                this.txtAddress.Text = dv[0]["Address"].ToString();
                txtFee.Text = dv[0]["process_fee"].ToString();

                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                this.chkMain.Checked = (dv[0]["Main"].ToString().Equals("Y")) ? true : false;
                this.chkExterna.Checked = (dv[0]["external"].ToString().Equals("Y")) ? true : false;
                this.chkIndoor.Checked = (dv[0]["indoor_services"].ToString().Equals("Y")) ? true : false;
                this.chkCollection.Checked = (dv[0]["collection_center"].ToString().Equals("Y")) ? true : false;
                if (chkExterna.Checked == true)
                {
                    txtFee.Enabled = true;
                    chkMain.Enabled = false;
                    chkMain.Checked = false;
                }
                else
                {
                    txtFee.Enabled = false;
                    chkMain.Enabled = true;
                }


                //if (!dv[0]["Main_of"].ToString().Equals("") && !dv[0]["Main_of"].ToString().Equals("0"))
                //{
                //    this.ddlMainof.SelectedValue = dv[0]["Main_of"].ToString();
                //}
                try
                {
                    ddlMainof.SelectedItem.Selected = false;
                    ddlMainof.Items.FindByValue(dv[0]["main_of"].ToString()).Selected = true;
                }
                catch { }
                try
                {
                    ddlDefaultRouting.ClearSelection();
                    ddlDefaultRouting.Items.FindByValue(dv[0]["default_route"].ToString()).Selected = true;
                }
                catch { }

                gvTiming.DataSource = dvTim;
                gvTiming.DataBind();
                Session["org_timing"] = dvTim.Table;
            }
        }
    }
}
