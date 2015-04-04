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

public partial class transaction_wfrmNewPatientReegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";

        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "31";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtPRnO.Focus();
                    if (!txtName.Text.Trim().Equals(""))
                    {
                        ContentPlaceHolder cp = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
                        TextBox tb = (TextBox)cp.FindControl("txtName");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "TitleCase", string.Format(@"function TitleCase()
{{document.getElementById('{0}').value;}}", tb.ClientID), true);
                    }


                    lblStatus.Text = "i";
                    FillPanel_DDL();

                    rdbCash.Checked = true;
                    pnlPanel.Visible = false;
                    //chkTitleENB.Visible = false;
                    FillDoctor_DDL();
                    this.Title = Session["personname"].ToString() + " : Patient Registration";
                    lblRela_hd.Visible = false;
                    ddlRelation.Visible = false;
                    lblName_Panel.Visible = false;

                    lbtnSaveDependent.Visible = false;
                    pnl_panelInfo.Visible = false;
                    txtAuthorize.Enabled = false;
                    ddlTitle.Enabled = false;


                    if (Request.QueryString["plabid"] != null)
                    {
                        string str_LabID = Request.QueryString["plabid"].Trim();
                        string str_recno = Request.QueryString["recno"].Trim();

                        //  ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Note Lab ID:" + str_LabID + "');</script>", false);
                        clsBLMain mn = new clsBLMain();
                        mn.ReceiveNo = str_recno;
                        DataView dv = mn.GetAll(30);
                        Session["testtable"] = dv.Table;
                        Session["reportname"] = "cashReceipt";
                        Session["selectionformula"] = "";
                        Session["selectionformula"] = "{command.receiveno}='" + str_recno + "'";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Cash Closing", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);

                    }
                    //if(Request.QueryString["nlabid"] !=null)
                    //    Response.Write("<script language='javascript'>alert('Please Note Lab ID:" + Request.QueryString["nlabid"] + "')</script>");
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
        Clear_Form();
    }

    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Validate_Form())
            return;

        if (lblStatus.Text == "i")
            Insert();
        else
            Update();
    }
    protected void imgPRno_Click(object sender, ImageClickEventArgs e)
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        lblError.Text = "";
        if (txtPRnO.Text.Trim().Replace("___-__-________", "").Equals(""))
        {
            lblError.Text = "Please enter PR No";
            return;
        }
        else
        {
            clsBLPatientReg_Inv pr = new clsBLPatientReg_Inv();

            pr.PRNO = this.txtPRnO.Text.Trim();
            pr.Branch_ID = Session["BranchID"].ToString().Trim();
            DataView dv = pr.GetAll(9);

            if (dv.Count > 0)
            {
                try
                {
                    ddlTitle.SelectedItem.Selected = false;
                    ddlTitle.Items.FindByValue(dv[0]["title"].ToString()).Selected = true;
                }
                catch { }

                txtName.Text = dv[0]["name"].ToString();

                rdbMale.Checked = dv[0]["gender"].ToString().Equals("Male") ? true : false;
                rdbFemle.Checked = dv[0]["gender"].ToString().Equals("Female") ? true : false;

                txtDOB.Text = dv[0]["dob"].ToString();
                txtHPHone.Text = dv[0]["hphone"].ToString();
                txtCellNo.Text = dv[0]["cellno"].ToString();

                txtFax.Text = dv[0]["fax"].ToString();
                txtEmail.Text = dv[0]["email"].ToString();

                txtCNIC.Text = dv[0]["cnic"].ToString();
                txtAddress.Text = dv[0]["address"].ToString();

                lblID.Text = dv[0]["prid"].ToString();
                txtSErviceNO.Text = dv[0]["serviceno"].ToString();

                try
                {
                    ddlMarital.SelectedItem.Selected = false;
                    ddlMarital.Items.FindByText(dv[0]["maritalstatus"].ToString()).Selected = true;
                }
                catch { }

                try
                {
                    ddlPanel.SelectedItem.Selected = false;
                    ddlPanel.Items.FindByValue(dv[0]["panelid"].ToString()).Selected = true;
                    rdbPanel.Checked = true;
                    rdbCash.Checked = false;

                    pnlPanel.Visible = true;
                }
                catch
                {
                    rdbCash.Checked = true;
                    rdbPanel.Checked = false;
                    lbtnSaveDependent.Visible = false;
                    lblRela_hd.Visible = false;
                    ddlRelation.Visible = false;
                    pnlPanel.Visible = false;
                }

                if (rdbPanel.Checked == true)
                {

                    //lblF_parent.Text = dv[0]["f_parent"].ToString();
                    //Fill_Dependent(lblF_parent.Text);                    
                    //Show_Parent_Info();
                    rdbCash.Enabled = false;
                    rdbPanel.Enabled = false;
                    //try
                    //{
                    //    ddlRelation.SelectedItem.Selected = false;
                    //    ddlRelation.Items.FindByText(dv[0]["relation"].ToString()).Selected = true;

                    //}
                    //catch 
                    //{                       
                    //}
                    //if (ddlRelation.SelectedItem.Text.ToString().Trim().Equals("Self"))
                    //{
                    //    lbtnSaveDependent.Visible = true;
                    //    lblRela_hd.Visible = true;
                    //    ddlRelation.Visible = true;
                    //    lblName_Panel.Visible = true;
                    //    lblName_Panel.Text = dv[0]["panelpatient"].ToString();

                    //    ddlPanel.Enabled = true;
                    //    txtSErviceNO.Enabled = true;
                    //    ddlTitle.Enabled = true;
                    //    rdbFemle.Enabled = true;
                    //    rdbMale.Enabled = true;
                    //    ddlMarital.Enabled = true;
                    //}
                    //else
                    //{
                    //    lbtnSaveDependent.Visible = true;
                    //    lblRela_hd.Visible = true;
                    //    ddlRelation.Visible = true;
                    //    //ddlRelation.SelectedIndex = -1;
                    //    lblName_Panel.Visible = true;
                    //    lblName_Panel.Text = dv[0]["panelpatient"].ToString();

                    //    ddlPanel.Enabled = false;
                    //    txtSErviceNO.Enabled = false;
                    //    ddlTitle.Enabled = false;
                    //    rdbFemle.Enabled = false;
                    //    rdbMale.Enabled = false;
                    //    ddlMarital.Enabled = false;
                    //}
                }

                //FillCLass_DDL();

                //try
                //{
                //    ddlClass.SelectedItem.Selected = false;
                //    ddlClass.Items.FindByValue(dv[0]["classid"].ToString()).Selected = true;
                //}
                //catch { }
                FillDoctor_DDL();

                lblStatus.Text = "u";
                txtPRnO.Enabled = false;
            }
            else
            {
                lblError.Text = "No Record Found.";
                txtPRnO.Enabled = true;

            }
        }
    }

    private void Insert()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
        if (chkTitleENB.Checked == false)
            reg.Title = this.ddlTitle.SelectedItem.Value.ToString();
        reg.Name = this.txtName.Text.Trim().Replace("'", "''");
        //string strnam =  System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
        if (rdbMale.Checked)
            reg.Gender = "M";
        else
            reg.Gender = "F";

        reg.DOB = GetDOB();
        reg.MaritalStatus = this.ddlMarital.SelectedItem.Value.ToString();
        reg.HPhone = this.txtHPHone.Text.Trim();
        reg.CellNo = this.txtCellNo.Text.Trim();
        reg.Password = this.txtName.Text.Trim().Split(' ').GetValue(0).ToString();
        reg.Branch_ID = Session["BranchID"].ToString().Trim();
        reg.Fax = this.txtFax.Text.Trim();
        reg.Email = this.txtEmail.Text.Trim();

        reg.ServiceNo = this.txtSErviceNO.Text.Trim();
        reg.ReferenceNo = this.txtReferenceNo.Text.Trim();

        reg.CNIC = this.txtCNIC.Text.Trim().Replace("_____-_______-_", "");
        reg.Address = this.txtAddress.Text.Trim();
        reg.BranchID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //Session["branchid"].ToString();

        if (rdbPanel.Checked)
        {
            //1 reg.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
            //1  reg.Relation = this.ddlRelation.SelectedItem.Value.ToString();
            //1  reg.F_Parent = this.lblF_parent.Text.Trim().Equals("") ? "null" : lblF_parent.Text.Trim();
            //1 reg.ServiceNo = this.txtSErviceNO.Text.Trim().Replace("'","''");

            reg.AuthorizeNo = this.txtAuthorize.Text.Trim().Replace("'", "''");
            //reg.ClassID = this.ddlClass.SelectedItem.Value.ToString();

        }
        reg.EnteredBy = Session["personid"].ToString();
        reg.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        reg.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //Session["orgid"].ToString(); // org

        if (reg.Patient_Insert())
        {
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";

            string str_rdb = rdbPnl_Cash.Checked ? "P" : rdbPanel.Checked ? "A" : "C";
            //(rdbCash.Checked || chbOnCash.Checked) ? "C" : "A";
            string str_panelID = "";
            string str_panelName = "";
            string str_Authorize = "";

            if (ddlPanel.SelectedIndex > 0)
            {
                str_Authorize = txtAuthorize.Text.Trim().Equals("") ? "~!@" : txtAuthorize.Text.Trim();
            }
            else
            {
                str_Authorize = "";
            }
            //string str_classID = "";
            //string str_className = "";
            try
            {
                str_panelID = this.ddlPanel.SelectedItem.Value.ToString();
                str_panelName = this.ddlPanel.SelectedItem.Text.Trim().Replace("&", ">>").Replace("#", "%%");
            }
            catch { }
            //try
            //{
            //    str_classID = this.ddlClass.SelectedItem.Value.ToString();
            //    str_className = this.ddlClass.SelectedItem.Text.ToString();
            //}
            //catch { }

            Response.Redirect("wfrmNewInvestigaionBooking.aspx?prid=" + reg.PRID + " &prno=" + reg.PRNO + " &doctorid=" + this.ddlDoctor.SelectedItem.Value.ToString() + " &referredby=" + this.txtReferredBy.Text.Trim() + " &panelid=" + str_panelID + " &patienttype=" + str_rdb + " &deliveryby=" + ddlDeliveryMode.SelectedItem.Value.ToString() + " &age=" + GetAge(reg.DOB) + " &patient=" + ddlTitle.SelectedItem.Text.Trim().Replace("Select", "") + " " + this.txtName.Text.Trim() + " &gender=" + reg.Gender + " &marital=" + ddlMarital.SelectedItem.Text.Trim() + " &authorizeno=" + str_Authorize + " &panelname=" + str_panelName + " &referenceno=" + txtReferenceNo.Text.Trim().Replace("#", "%%").Replace("&", ">>") + " &remarks=" + txtRemark.Text.Trim() + "");
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = reg.Error;
        }
    }
    private void Update()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();

        reg.PRID = this.lblID.Text.Trim();
        reg.PRNO = this.txtPRnO.Text.Trim();

        if (chkTitleENB.Checked == false)
            reg.Title = this.ddlTitle.SelectedItem.Value.ToString();
        reg.Name = this.txtName.Text.Trim().Replace("'", "''");
        if (rdbMale.Checked)
            reg.Gender = "M";
        else
            reg.Gender = "F";

        reg.DOB = GetDOB();
        reg.MaritalStatus = this.ddlMarital.SelectedItem.Value.ToString();
        reg.HPhone = this.txtHPHone.Text.Trim();
        reg.CellNo = this.txtCellNo.Text.Trim();

        reg.Fax = this.txtFax.Text.Trim();
        reg.Email = this.txtEmail.Text.Trim();

        reg.CNIC = this.txtCNIC.Text.Trim().Replace("_____-_______-_", "");
        reg.Address = this.txtAddress.Text.Trim();
        reg.BranchID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        reg.Branch_ID = Session["BranchID"].ToString().Trim();

        reg.ServiceNo = this.txtSErviceNO.Text.Trim();
        reg.ReferenceNo = this.txtReferenceNo.Text.Trim();

        if (rdbPanel.Checked)
        {
            //1 reg.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
            //1 reg.Relation = this.ddlRelation.SelectedItem.Value.ToString();
            //1 reg.F_Parent = this.lblF_parent.Text.Trim().Equals("") ? "null" : lblF_parent.Text.Trim();
            //1 reg.ServiceNo = this.txtSErviceNO.Text.Trim().Replace("'", "''");

            reg.AuthorizeNo = this.txtAuthorize.Text.Trim().Replace("'", "''");
            // reg.ClassID = this.ddlClass.SelectedItem.Value.ToString();

        }
        reg.EnteredBy = Session["personid"].ToString();
        reg.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        reg.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        //Session["orgid"].ToString(); // org

        if (reg.Patient_Update())
        {
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";

            string str_rdb = rdbPnl_Cash.Checked ? "P" : rdbPanel.Checked ? "A" : "C";
            string str_panelID = "";
            string str_panelName = "";
            string str_Authorize = "";
            if (ddlPanel.SelectedIndex > 0)
            {
                str_Authorize = txtAuthorize.Text.Trim().Equals("") ? "~!@" : txtAuthorize.Text.Trim();
            }
            else
            {
                str_Authorize = "~!@";
            }
            //string str_classID = "";
            //string str_className = "";
            try
            {
                str_panelID = this.ddlPanel.SelectedItem.Value.ToString();
                str_panelName = this.ddlPanel.SelectedItem.Text.Trim().Replace("&", ">>").Replace("#", "%%");
            }
            catch { }
            //try
            //{
            //    str_classID = this.ddlClass.SelectedItem.Value.ToString();
            //    str_className = this.ddlClass.SelectedItem.Text.ToString();
            //}
            //catch { }

            Response.Redirect("wfrmNewInvestigaionBooking.aspx?prid=" + reg.PRID + " &prno=" + reg.PRNO + " &doctorid=" + this.ddlDoctor.SelectedItem.Value.ToString() + " &referredby=" + this.txtReferredBy.Text.Trim() + " &panelid=" + str_panelID + "  &patienttype=" + str_rdb + " &deliveryby=" + ddlDeliveryMode.SelectedItem.Value.ToString() + " &age=" + GetAge(reg.DOB) + "  &patient=" + ddlTitle.SelectedItem.Text.Trim().Replace("Select", "") + " " + this.txtName.Text.Trim() + " &gender=" + reg.Gender + " &marital=" + ddlMarital.SelectedItem.Text.Trim() + " &authorizeno=" + str_Authorize + " &panelname=" + str_panelName + " &referenceno=" + txtReferenceNo.Text.Trim().Replace("#", "%%").Replace("&", ">>") + " &remarks=" + txtRemark.Text.Trim() + "");
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = reg.Error;
        }
    }

    private void Dependent_Insert()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();

        reg.Title = this.ddlTitle.SelectedItem.Value.ToString();
        reg.Name = this.txtName.Text.Trim().Replace("'", "''");
        if (rdbMale.Checked)
            reg.Gender = "M";
        else
            reg.Gender = "F";

        reg.DOB = GetDOB();
        reg.MaritalStatus = this.ddlMarital.SelectedItem.Value.ToString();
        reg.HPhone = this.txtHPHone.Text.Trim();
        reg.CellNo = this.txtCellNo.Text.Trim();

        reg.Fax = this.txtFax.Text.Trim();
        reg.Email = this.txtEmail.Text.Trim();

        reg.CNIC = this.txtCNIC.Text.Trim().Replace("_____-_______-_", "");
        reg.Address = this.txtAddress.Text.Trim();
        reg.BranchID = Session["branchid"].ToString();

        if (rdbPanel.Checked)
        {
            reg.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
            reg.Relation = this.ddlRelation.SelectedItem.Value.ToString();
            reg.F_Parent = this.lblF_parent.Text.Trim().Equals("") ? "null" : lblF_parent.Text.Trim();
            reg.ServiceNo = this.txtSErviceNO.Text.Trim().Replace("'", "''");

            // reg.AuthorizeNo = this.txtAuthorize.Text.Trim().Replace("'","''");
            //reg.ClassID = this.ddlClass.SelectedItem.Value.ToString();

        }
        reg.EnteredBy = Session["personid"].ToString();
        reg.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        reg.ClientID = Session["orgid"].ToString(); // org

        if (reg.Patient_Insert())
        {
            Clear_Dependent();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully and PRNO is <b>" + reg.PRNO + "</b>";
            lblF_parent.Text = reg.F_Parent;
            Fill_Dependent(lblF_parent.Text);

        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = reg.Error;
        }
    }
    private void Dependent_Update()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();

        reg.PRID = this.lblID.Text.Trim();
        reg.PRNO = this.txtPRnO.Text.Trim();

        reg.Title = this.ddlTitle.SelectedItem.Value.ToString();
        reg.Name = this.txtName.Text.Trim().Replace("'", "''");
        if (rdbMale.Checked)
            reg.Gender = "M";
        else
            reg.Gender = "F";

        reg.DOB = GetDOB();
        reg.MaritalStatus = this.ddlMarital.SelectedItem.Value.ToString();
        reg.HPhone = this.txtHPHone.Text.Trim();
        reg.CellNo = this.txtCellNo.Text.Trim();

        reg.Fax = this.txtFax.Text.Trim();
        reg.Email = this.txtEmail.Text.Trim();

        reg.CNIC = this.txtCNIC.Text.Trim().Replace("_____-_______-_", "");
        reg.Address = this.txtAddress.Text.Trim();
        reg.BranchID = Session["branchid"].ToString();

        if (rdbPanel.Checked)
        {
            reg.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
            reg.Relation = this.ddlRelation.SelectedItem.Value.ToString();
            reg.F_Parent = this.lblF_parent.Text.Trim().Equals("") ? "null" : lblF_parent.Text.Trim();
            reg.ServiceNo = this.txtSErviceNO.Text.Trim().Replace("'", "''");

            //  reg.AuthorizeNo = this.txtAuthorize.Text.Trim().Replace("'", "''");
            // reg.ClassID = this.ddlClass.SelectedItem.Value.ToString();

        }
        reg.EnteredBy = Session["personid"].ToString();
        reg.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        reg.ClientID = Session["orgid"].ToString(); // org

        if (reg.Patient_Update())
        {
            Clear_Dependent();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";
            lblF_parent.Text = reg.F_Parent;
            Fill_Dependent(lblF_parent.Text);
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = reg.Error;
        }
    }
    private string GetDOB()
    {
        //
        //
        string str = null;
        if (this.txtDOB.Text.Trim() != null && !this.txtDOB.Text.Trim().ToString().Replace("__/__/____", "").Equals(""))
        {
            str = txtDOB.Text.ToString().Trim();
        }
        else if (this.txtAge.Text.Trim() != null && this.txtAge.Text.Trim() != "")
        {
            int age = int.Parse(this.txtAge.Text.Trim());

            if (ddlAge_Opt.SelectedItem.Value.ToString().Equals("Y"))
                str = System.DateTime.Now.Date.AddYears(-age).ToString("dd/MM/yyyy");
            else if (ddlAge_Opt.SelectedItem.Value.ToString().Equals("M"))
                str = System.DateTime.Now.Date.AddMonths(-age).ToString("dd/MM/yyyy");
            else if (ddlAge_Opt.SelectedItem.Value.ToString().Equals("D"))
                str = System.DateTime.Now.Date.AddDays(-age).ToString("dd/MM/yyyy");
        }
        else
        {
            str = "";
        }
        return str;
    }
    private string GetAge(string strDate)
    {
        string strPres = strDate.Substring(3, 2) + "/" + strDate.Substring(0, 2) + "/" + strDate.Substring(6, 4);
        DateTime dtPres = DateTime.Parse(strPres);
        DateTime dtNow = DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy"));
        TimeSpan ts = dtNow.Subtract(dtPres);

        double days = ts.TotalDays;
        double month = days / 30;
        double year = (days / 30) / 12;

        if (days > 0 && days < 30)
            strDate = days.ToString() + "-Days";
        else if (days < 1440 && month <= 12)
            strDate = Convert.ToString(Math.Truncate(month)) + "-Month";
        else
            strDate = Convert.ToString(Math.Truncate(year)) + "-Year";
        return strDate;
    }

    private string GetAge_edit(string strDate)
    {
        ddlAge_Opt.ClearSelection();
        string strPres = strDate.Substring(3, 2) + "/" + strDate.Substring(0, 2) + "/" + strDate.Substring(6, 4);
        DateTime dtPres = DateTime.Parse(strPres);
        DateTime dtNow = DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy"));
        TimeSpan ts = dtNow.Subtract(dtPres);

        double days = ts.TotalDays;
        double month = days / 30;
        double year = (days / 30) / 12;

        if (days > 0 && days < 30)
        {
            strDate = days.ToString();
            ddlAge_Opt.Items.FindByValue("D").Selected = true;
        }
        else if (days < 1440 && month <= 12)
        {
            strDate = Convert.ToString(Math.Truncate(month));
            ddlAge_Opt.Items.FindByValue("M").Selected = true;
        }

        else
        {
            strDate = Convert.ToString(Math.Truncate(year));
            ddlAge_Opt.Items.FindByValue("Y").Selected = true;
        }
        return strDate;
    }

    private void Fill_Dependent(string strPRID)
    {
        clsBLPatientReg_Inv rec = new clsBLPatientReg_Inv();
        rec.F_Parent = strPRID;

        DataView dv = rec.GetAll(18);
        gvDependent.DataSource = dv;
        gvDependent.DataBind();
    }
    private void Show_Parent_Info()
    {
        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
        iv.ServiceNo = this.txtSErviceNO.Text.Trim();
        iv.PRID = lblF_parent.Text.Trim();
        DataView dv = iv.GetAll(20);

        pnl_panelInfo.Visible = true;
        lblPR_Parent_Panel.Text = dv[0]["prno"].ToString();
        lblParent_Panel.Text = dv[0]["parent"].ToString();
        lblServ_Panel.Text = dv[0]["serviceno"].ToString();
        lblMarit_Panel.Text = dv[0]["maritalstatus"].ToString();
        lblCmp_panel.Text = dv[0]["panelname"].ToString();
    }

    private void Clear_Form()
    {
        lblStatus.Text = "i";
        lblID.Text = "";
        lblError.Text = "";

        lblName_Panel.Text = "";
        lblPR_Panel.Text = "";

        txtAddress.Text = "";
        txtAge.Text = "";
        txtCellNo.Text = "";


        txtCNIC.Text = "";
        txtDOB.Text = "";
        txtEmail.Text = "";
        txtFax.Text = "";

        txtHPHone.Text = "";
        txtName.Text = "";
        txtPRnO.Text = "";
        txtPRnO.Enabled = true;

        txtReferredBy.Text = "";
        txtSErviceNO.Text = "";
        txtSErviceNO.Enabled = true;
        txtAuthorize.Text = "";
        txtAuthorize.Enabled = false;

        rdbCash.Checked = true;
        rdbPanel.Checked = false;
        rdbPanel.Enabled = true;
        rdbCash.Enabled = true;
        chkTitleENB.Checked = true;


        rdbMale.Enabled = true;
        rdbFemle.Enabled = true;
        ddlMarital.Enabled = true;

        ddlPanel.SelectedIndex = -1;
        ddlPanel.Enabled = true;
        ddlTitle.SelectedIndex = -1;
        ddlMarital.SelectedIndex = -1;

        ddlTitle.Enabled = false;
        lblRela_hd.Visible = false;
        ddlRelation.Visible = false;
        lblName_Panel.Visible = false;
        lbtnSaveDependent.Visible = false;

        pnlPanel.Visible = false;
        pnl_panelInfo.Visible = false;
        //for (int i = ddlClass.Items.Count - 1; i >= 1; i--)
        //{
        //    ddlClass.Items.RemoveAt(i);

        //}
        gvPatient.DataSource = null;
        gvPatient.DataBind();

        gvDependent.DataSource = null;
        gvDependent.DataBind();
    }
    private void Clear_Dependent()
    {
        lblStatus.Text = "i";
        lblID.Text = "";
        lblError.Text = "";

        txtAddress.Text = "";
        txtAge.Text = "";
        txtCellNo.Text = "";

        txtCNIC.Text = "";
        txtDOB.Text = "";
        txtEmail.Text = "";
        txtFax.Text = "";

        txtHPHone.Text = "";
        txtName.Text = "";
        txtPRnO.Text = "";
        txtPRnO.Enabled = true;

        txtReferredBy.Text = "";
        txtSErviceNO.Enabled = false;

        ddlPanel.Enabled = false;
        ddlTitle.SelectedIndex = -1;
        ddlMarital.SelectedIndex = -1;
        ddlRelation.Enabled = true;
        lbtnSaveDependent.Visible = true;

        rdbMale.Enabled = true;
        rdbFemle.Enabled = true;
        ddlMarital.Enabled = true;
        ddlTitle.Enabled = true;
        //for (int i = ddlClass.Items.Count - 1; i >= 1; i--)
        //{
        //    ddlClass.Items.RemoveAt(i);

        //}
        gvPatient.DataSource = null;
        gvPatient.DataBind();
    }

    private bool Validate_Form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        lblError.Text = "";

        if (ddlTitle.SelectedIndex <= 0 && chkTitleENB.Checked == false)
        {
            lblError.Text = "Please select Salutation.";
            ddlTitle.Focus();
            return false;
        }
        if (txtName.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter patient name.(empty is not allowed)";
            txtName.Focus();
            return false;
        }
        if (rdbMale.Checked == false && rdbFemle.Checked == false)
        {
            lblError.Text = "Please select Gender Male or Female";
            rdbMale.Focus();
            return false;
        }
        if (txtDOB.Text.Trim().Replace("__/__/____", "").Equals("") && txtAge.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter Patient Date of Birth or Age";
            txtDOB.Focus();
            return false;
        }
        if (!txtDOB.Text.Trim().Replace("__/__/____", "").Equals(""))
        {
            System.Globalization.CultureInfo cult = new System.Globalization.CultureInfo("ur-PK");
            DateTime dt = Convert.ToDateTime(txtDOB.Text.Trim(), cult);
            DateTime dtTodate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"), cult);
            int cmp_date = DateTime.Compare(dt, dtTodate);
            if (cmp_date > 0)
            {
                lblError.Text = " Patient Date of Birth is greater than today. ";
                txtDOB.Focus();
                return false;
            }
        }
        if (ddlMarital.SelectedIndex <= 0)
        {
            lblError.Text = "Please select marital status";
            ddlMarital.Focus();
            return false;
        }
        if (ddlDoctor.SelectedIndex <= 0 && txtReferredBy.Text.Trim().Equals(""))
        {
            lblError.Text = "Select or enter referral information ";
            ddlDoctor.Focus();
            return false;
        }
        //if (txtReferenceNo.Text.Trim().Equals(""))
        //{
        //    lblError.Text = "Please enter reference no.";
        //    txtReferenceNo.Focus();
        //    return false;
        //}
        clsValidation vd = new clsValidation();
        if (!txtEmail.Text.Trim().Equals(""))
        {
            if (!vd.IsEmail(txtEmail.Text.Trim()))
            {
                lblError.Text = "Please enter correct email address.";
                txtEmail.Focus();
                return false;
            }
        }
        if (ddlDeliveryMode.SelectedItem.Value.ToString().Equals("E") && !vd.IsEmail(txtEmail.Text.Trim()))
        {
            lblError.Text = "Please enter correct email address in case of email Delivery mode";
            txtEmail.Focus();
            return false;
        }

        if ((ddlTitle.SelectedItem.Text.Equals("Master") || ddlTitle.SelectedItem.Text.Equals("Baby")) && ddlMarital.SelectedItem.Value.ToString().Equals("M"))
        {
            lblError.Text = "Please select marital status single.";
            ddlMarital.Focus();
            return false;
        }

        if (rdbPanel.Checked == true || rdbPnl_Cash.Checked == true)
        {
            //if (ddlRelation.SelectedIndex <= 0)
            //{
            //    lblError.Text = "Please select relation";
            //    ddlRelation.Focus();
            //    return false;
            //}
            string strTitle = ddlRelation.SelectedItem.Value.ToString();

            //if ((strTitle.Equals("S/O") || strTitle.Equals("F/O") || strTitle.Equals("H/O")) && rdbMale.Checked == false)
            //{
            //    lblError.Text = "Please check male gender";
            //    rdbMale.Focus();
            //    return false;
            //}
            //if ((strTitle.Equals("M/O") || strTitle.Equals("W/O") || strTitle.Equals("D/O")) && rdbFemle.Checked == false)
            //{
            //    lblError.Text = "Please check female gender";
            //    rdbFemle.Focus();
            //    return false;
            //}
            //if (ddlTitle.SelectedItem.Value.ToString().Equals("Mr") && !strTitle.Equals("S/O") && !strTitle.Equals("F/O") && !strTitle.Equals("H/O") && !strTitle.Equals("Self"))
            //{
            //    lblError.Text = "Please select correct relation.";
            //    ddlRelation.Focus();
            //    return false; 
            //}
            //if (ddlTitle.SelectedItem.Value.ToString().Equals("Master") && !strTitle.Equals("S/O") && !strTitle.Equals("D/O")) 
            //{
            //    lblError.Text = "Please select correct relation.You can select only S/O or D/O relation";
            //    ddlRelation.Focus();
            //    return false;
            //}
            //if (ddlTitle.SelectedItem.Value.ToString().Equals("Baby") && !strTitle.Equals("S/O") && !strTitle.Equals("D/O"))
            //{
            //    lblError.Text = "Please select correct relation.You can select only S/O or D/O relation";
            //    ddlRelation.Focus();
            //    return false;
            //}
            //if (strTitle.Equals("S/O") && (ddlTitle.SelectedItem.Text.Equals("Miss") || ddlTitle.SelectedItem.Text.ToString().Equals("Mrs")))
            //{
            //    lblError.Text = "Please select correct salutation.You can select only Mr or Baby or Master salutation";
            //    ddlRelation.Focus();
            //    return false;
            //}
            //if (strTitle.Equals("D/O") && (ddlTitle.SelectedItem.Text.ToString().Equals("Mr") || ddlTitle.SelectedItem.Text.ToString().Equals("Mrs")))
            //{
            //    lblError.Text = "Please select correct salutation.You can select only Miss or Baby or Master salutation";
            //    ddlRelation.Focus();
            //    return false;
            //}
            //if (!ddlTitle.SelectedItem.Value.ToString().Equals("Mr") && !strTitle.Equals("M/O") && !strTitle.Equals("W/O") && !strTitle.Equals("D/O") && !strTitle.Equals("Self"))
            //{
            //    lblError.Text = "Please select correct relation.";
            //    ddlRelation.Focus();
            //    return false;
            //}
            //if (lblMarit_Panel.Text.Trim().Equals("S") && !ddlRelation.SelectedItem.Text.Trim().Equals("F/O") && !ddlRelation.SelectedItem.Text.Trim().Equals("M/O") && !ddlRelation.SelectedItem.Text.Trim().Equals("Self"))
            //{
            //    lblError.Text = "This employee marital status is single and his dependent would be only Father and Mother.";
            //    ddlRelation.Focus();
            //    return false;
            //}
            //if ((ddlRelation.SelectedItem.Text.Trim().Equals("S/O") || ddlRelation.SelectedItem.Text.Trim().Equals("D/O")) && !ddlMarital.SelectedItem.Value.Trim().Equals("S"))
            //{
            //    lblError.Text = "Please select marital status Single.";
            //    ddlMarital.Focus();
            //    return false;
            //}

            if (ddlPanel.SelectedIndex <= 0)
            {
                lblError.Text = "Please select Panel Company";
                ddlPanel.Focus();
                return false;
            }
            //if (ddlClass.SelectedIndex <= 0)
            //{
            //    lblError.Text = "Please select Panel Class";
            //    ddlClass.Focus();
            //    return false;
            //}
            //if (txtAuthorize.Text.Trim().Equals(""))
            //{
            //    lblError.Text = "Please enter authorization number.(empty is not allowed)";
            //    txtAuthorize.Focus();
            //    return false;
            //}
            //if (txtSErviceNO.Text.Trim().Equals(""))
            //{
            //    lblError.Text = "Please enter patient service number.(empty is not allowed)";
            //    txtSErviceNO.Focus();
            //    return false;
            //}
        }
        return true;

    }
    private bool Validate_Dependent()
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        lblError.Text = "";

        if (ddlTitle.SelectedIndex <= 0)
        {
            lblError.Text = "Please select Salutation.";
            ddlTitle.Focus();
            return false;
        }
        if (txtName.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter patient name.(empty is not allowed)";
            txtName.Focus();
            return false;
        }
        if (rdbMale.Checked == false && rdbFemle.Checked == false)
        {
            lblError.Text = "Please select Gender Male or Female";
            rdbMale.Focus();
            return false;
        }
        if (txtDOB.Text.Trim().Replace("__/__/____", "").Equals("") && txtAge.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter Patient Date of Birth or Age";
            txtDOB.Focus();
            return false;
        }
        if (ddlMarital.SelectedIndex <= 0)
        {
            lblError.Text = "Please select marital status";
            ddlMarital.Focus();
            return false;
        }

        clsValidation vd = new clsValidation();
        if (!txtEmail.Text.Trim().Equals(""))
        {
            if (!vd.IsEmail(txtEmail.Text.Trim()))
            {
                lblError.Text = "Please enter correct email address.";
                txtEmail.Focus();
                return false;
            }
        }
        if (ddlDeliveryMode.SelectedItem.Value.ToString().Equals("E") && !vd.IsEmail(txtEmail.Text.Trim()))
        {
            lblError.Text = "Please enter correct email address in case of email Delivery mode";
            txtEmail.Focus();
            return false;
        }
        if (rdbPanel.Checked == true)
        {
            if (ddlRelation.SelectedIndex <= 0)
            {
                lblError.Text = "Please select relation";
                ddlRelation.Focus();
                return false;
            }
            string strTitle = ddlRelation.SelectedItem.Value.ToString();
            if ((strTitle.Equals("S/O") || strTitle.Equals("F/O") || strTitle.Equals("H/O")) && rdbMale.Checked == false)
            {
                lblError.Text = "Please check male gender";
                rdbMale.Focus();
                return false;
            }
            if ((strTitle.Equals("M/O") || strTitle.Equals("W/O") || strTitle.Equals("D/O")) && rdbFemle.Checked == false)
            {
                lblError.Text = "Please check female gender";
                rdbFemle.Focus();
                return false;
            }
            if (ddlTitle.SelectedItem.Value.ToString().Equals("Mr") && !strTitle.Equals("S/O") && !strTitle.Equals("F/O") && !strTitle.Equals("H/O") && !strTitle.Equals("Self"))
            {
                lblError.Text = "Please select correct relation.";
                ddlRelation.Focus();
                return false;
            }
            if ((ddlTitle.SelectedItem.Value.ToString().Equals("Mrs") || ddlTitle.SelectedItem.Value.ToString().Equals("Mrs")) && !strTitle.Equals("M/O") && !strTitle.Equals("W/O") && !strTitle.Equals("D/O") && !strTitle.Equals("Self"))
            {
                lblError.Text = "Please select correct relation.";
                ddlRelation.Focus();
                return false;
            }
            if (lblMarit_Panel.Text.Trim().Equals("S") && !ddlRelation.SelectedItem.Text.Trim().Equals("F/O") && !ddlRelation.SelectedItem.Text.Trim().Equals("M/O") && !ddlRelation.SelectedItem.Text.Trim().Equals("Self"))
            {
                lblError.Text = "This employee marital status is single and his dependent would be only Father and Mother.";
                ddlRelation.Focus();
                return false;
            }
            if ((ddlRelation.SelectedItem.Text.Trim().Equals("S/O") || ddlRelation.SelectedItem.Text.Trim().Equals("D/O")) && !ddlMarital.SelectedItem.Value.Trim().Equals("S"))
            {
                lblError.Text = "Please select marital status Single.";
                ddlMarital.Focus();
                return false;
            }
            if (ddlTitle.SelectedItem.Value.ToString().Equals("Master") && !strTitle.Equals("S/O") && !strTitle.Equals("D/O"))
            {
                lblError.Text = "Please select correct relation.You can select only S/O or D/O relation";
                ddlRelation.Focus();
                return false;
            }
            if (ddlTitle.SelectedItem.Value.ToString().Equals("Baby") && !strTitle.Equals("S/O") && !strTitle.Equals("D/O"))
            {
                lblError.Text = "Please select correct relation.You can select only S/O or D/O relation";
                ddlRelation.Focus();
                return false;
            }
            if (strTitle.Equals("S/O") && (ddlTitle.SelectedItem.Text.ToString().Equals("Miss") || ddlTitle.SelectedItem.Text.ToString().Equals("Mrs")))
            {
                lblError.Text = "Please select correct salutation.You can select only Mr or Baby or Master relation";
                ddlRelation.Focus();
                return false;
            }
            if (strTitle.Equals("D/O") && (ddlTitle.SelectedItem.Text.ToString().Equals("Mr") || ddlTitle.SelectedItem.Text.ToString().Equals("Mrs")))
            {
                lblError.Text = "Please select correct salutation.You can select only Miss or Baby or Master relation";
                ddlRelation.Focus();
                return false;
            }
            if (ddlPanel.SelectedIndex <= 0)
            {
                lblError.Text = "Please select Panel Company";
                ddlPanel.Focus();
                return false;
            }
            //if (ddlClass.SelectedIndex <= 0)
            //{
            //    lblError.Text = "Please select Panel Class";
            //    ddlClass.Focus();
            //    return false;
            //}
            //if (txtAuthorize.Text.Trim().Equals(""))
            //{
            //    lblError.Text = "Please enter authorization number.(empty is not allowed)";
            //    txtAuthorize.Focus();
            //    return false;
            //}
            if (txtSErviceNO.Text.Trim().Equals(""))
            {
                lblError.Text = "Please enter patient service number.(empty is not allowed)";
                txtSErviceNO.Focus();
                return false;
            }
        }
        return true;

    }

    private void FillDoctor_DDL()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
        SComponents com = new SComponents();

        if (rdbCash.Checked == true)
            reg.OrgID = "Yes";
        else if (rdbPanel.Checked == true)
            reg.PanelID = "Yes";

        DataView dv = reg.GetAll(15);

        com.FillDropDownList(ddlDoctor, dv, "name", "doctorid");
    }
    private void FillPanel_DDL()
    {
        clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
        SComponents com = new SComponents();

        reg.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        reg.Branch_ID = Session["BranchID"].ToString().Trim();
        //Session["default_route"].ToString();

        DataView dv = reg.GetAll(6);
        com.FillDropDownList(ddlPanel, dv, "name", "panelid");
    }
    private void FillCLass_DDL()
    {
        //clsBLPatientReg_Inv reg = new clsBLPatientReg_Inv();
        //SComponents com = new SComponents();

        //reg.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        //DataView dv = reg.GetAll(7);
        //com.FillDropDownList(ddlClass, dv, "name", "classid");
    }

    protected void ddlPanel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPanel.SelectedIndex >= 0)
        {
            FillCLass_DDL();
        }
        else
        {
            for (int i = ddlClass.Items.Count - 1; i >= 1; i--)
            {
                ddlClass.Items.RemoveAt(i);
            }
        }
    }
    protected void rdbCash_CheckedChanged(object sender, EventArgs e)
    {
        pnlPanel.Visible = false;
        lblRela_hd.Visible = false;
        ddlPanel.SelectedIndex = -1;
        ddlTitle.Enabled = true;

        ddlRelation.Visible = false;
        lblName_Panel.Visible = false;
        lbtnSaveDependent.Visible = false;
        txtAuthorize.Enabled = false;
        chkTitleENB.Checked = false;
        chkTitleENB.Visible = true;

        lblName_Panel.Text = "";
        lblPR_Panel.Text = "";
        txtAuthorize.Text = "";
        FillDoctor_DDL();


        gvDependent.DataSource = null;
        gvDependent.DataBind();
    }
    protected void rdbPanel_CheckedChanged(object sender, EventArgs e)
    {
        if (!pnlPanel.Visible)
        {
            pnlPanel.Visible = true;
            txtAuthorize.Enabled = true;
            FillDoctor_DDL();
        }
        //chkTitleENB.Visible = true;
        // ddlTitle.Enabled = true;


        //if (lblStatus.Text == "u")
        //{
        //    lbtnSaveDependent.Visible = true;
        //    ddlRelation.SelectedIndex = -1;
        //    ddlRelation.Enabled = true;
        //    lblRela_hd.Visible = true;

        //    ddlRelation.Visible = true;
        //    lblName_Panel.Visible = true;            
        //}
        //else
        //{
        //    lbtnSaveDependent.Visible = true;

        //    ddlRelation.SelectedItem.Selected = false;
        //    ddlRelation.Items.FindByText("Self").Selected = true;
        //    ddlRelation.Enabled = false;
        //    lblRela_hd.Visible = true;
        //    ddlRelation.Visible = true;
        //    lblName_Panel.Visible = true;

        //}

    }

    //protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlTitle.SelectedIndex > 0)
    //    {
    //        if (ddlTitle.SelectedItem.Text.Equals("Mr"))
    //        {
    //            rdbFemle.Checked = false;
    //            rdbMale.Checked = true;                
    //            ddlMarital.SelectedIndex = -1;
    //        }
    //        else if (ddlTitle.SelectedItem.Text.Equals("Miss"))
    //        {
    //            rdbFemle.Checked = true;
    //            rdbMale.Checked = false;
    //            ddlMarital.SelectedIndex = 1;
    //        }
    //        else if (ddlTitle.SelectedItem.Text.Equals("Mrs"))
    //        {
    //            rdbFemle.Checked = true;
    //            rdbMale.Checked = false;
    //            ddlMarital.SelectedIndex = 2;
    //        }
    //        else
    //        {
    //            rdbFemle.Checked = false;
    //            rdbMale.Checked = false;
    //            ddlMarital.SelectedIndex = 0;
    //        }
    //    }
    //    else
    //    {
    //        rdbFemle.Checked = false;
    //        rdbMale.Checked = false;
    //        ddlMarital.SelectedIndex = 0;
    //    }
    //}
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        lblError.ForeColor = System.Drawing.Color.Red;
        lblError.Text = "";
        int count = 0;
        clsBLPatientReg_Inv pr = new clsBLPatientReg_Inv();
        pr.Branch_ID = Session["BranchID"].ToString().Trim();
        if (!txtPRnO.Text.Trim().Replace("___-__-________", "").Equals(""))
        {
            pr.PRNO = this.txtPRnO.Text.Trim();
            count++;
        }
        if (ddlTitle.SelectedIndex > 0)
        {
            pr.Title = this.ddlTitle.SelectedItem.Value.ToString();
            count++;
        }
        if (!txtName.Text.Trim().Equals(""))
        {
            pr.Name = this.txtName.Text.Trim();
            count++;
        }
        if (rdbMale.Checked || rdbFemle.Checked)
        {
            pr.Gender = rdbFemle.Checked ? "F" : "M";
            count++;
        }
        if (!txtDOB.Text.Trim().Replace("__/__/____", "").Equals(""))
        {
            pr.DOB = this.txtDOB.Text.Trim();
            count++;
        }
        if (ddlMarital.SelectedIndex > 0)
        {
            pr.MaritalStatus = this.ddlMarital.SelectedItem.Value.ToString();
            count++;
        }
        if (!txtCellNo.Text.Trim().Equals(""))
        {
            pr.CellNo = this.txtCellNo.Text.Trim();
            count++;
        }
        if (!txtHPHone.Text.Trim().Equals(""))
        {
            pr.HPhone = this.txtHPHone.Text.Trim();
            count++;
        }
        if (!txtFax.Text.Trim().Equals(""))
        {
            pr.Fax = this.txtFax.Text.Trim();
            count++;
        }
        if (!txtEmail.Text.Trim().Equals(""))
        {
            pr.Email = this.txtEmail.Text.Trim();
            count++;
        }
        //if (rdbCash.Checked == true)
        //{
        //    pr.PanelID = "~!@";
        //    count++;
        //}
        //if(rdbPanel.Checked==true)
        //{
        //    pr.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        //    pr.ServiceNo = this.txtSErviceNO.Text.Trim().Equals("") ? "~!@" : txtSErviceNO.Text.Trim();
        //    count++;
        //}
        if (ddlPanel.SelectedIndex > 0)
        {
            pr.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
            count++;
        }
        if (!txtSErviceNO.Text.Trim().Equals(""))
        {
            pr.ServiceNo = this.txtSErviceNO.Text.Trim().Equals("") ? "~!@" : txtSErviceNO.Text.Trim();
            count++;
        }

        if (count > 0)
        {

            DataView dv = pr.GetAll(9);

            if (dv.Count > 0)
            {
                //if (rdbCash.Checked == true)
                //{
                //    gvPatient.Columns[8].Visible = true; // email show
                //    gvPatient.Columns[9].Visible = false; // panel hide                        
                //}
                //else
                //{
                //    gvPatient.Columns[8].Visible = false; // email hide
                //    gvPatient.Columns[9].Visible = true; // panel company show
                //}

                gvPatient.DataSource = dv;
                gvPatient.DataBind();

                lblError.ForeColor = System.Drawing.Color.DarkBlue;
                lblError.Text = "Total Records Found( <b>" + dv.Count + " </b>)";
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.DarkBlue;
                lblError.Text = "Total Records Found( <b>" + dv.Count + " </b>)";
                txtPRnO.Enabled = true;

                gvPatient.DataSource = null;
                gvPatient.DataBind();
            }
        }
    }
    protected void gvPatient_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            try
            {
                ddlTitle.SelectedItem.Selected = false;
                ddlTitle.Items.FindByValue(gvPatient.DataKeys[index].Values[1].ToString()).Selected = true;
                chkTitleENB.Checked = false;
                ddlTitle.Enabled = true;
            }
            catch
            {
                chkTitleENB.Checked = true;
                ddlTitle.Enabled = false;
            }

            txtPRnO.Text = gvPatient.Rows[index].Cells[1].Text.Trim();
            txtName.Text = gvPatient.DataKeys[index].Values[2].ToString();

            rdbMale.Checked = gvPatient.Rows[index].Cells[3].Text.Trim().Equals("Male") ? true : false;
            rdbFemle.Checked = gvPatient.Rows[index].Cells[3].Text.Trim().Equals("Female") ? true : false;

            txtDOB.Text = gvPatient.DataKeys[index].Values[12].ToString();
            txtHPHone.Text = gvPatient.Rows[index].Cells[7].Text.Trim().ToString().Replace("&nbsp;", ""); ;
            txtCellNo.Text = gvPatient.Rows[index].Cells[6].Text.Trim().ToString().Replace("&nbsp;", ""); ;

            txtFax.Text = gvPatient.DataKeys[index].Values[7].ToString().Replace("&nbsp;", ""); ;
            txtEmail.Text = gvPatient.DataKeys[index].Values[11].ToString().Replace("&nbsp;", "");
            //gvPatient.Rows[index].Cells[8].Text.Trim().Replace("&nbsp;", ""); ;

            txtCNIC.Text = gvPatient.DataKeys[index].Values[3].ToString().Replace("&nbsp;", ""); ;
            txtAddress.Text = gvPatient.DataKeys[index].Values[4].ToString().Replace("&nbsp;", ""); ;

            lblID.Text = gvPatient.DataKeys[index].Value.ToString();
            txtSErviceNO.Text = gvPatient.DataKeys[index].Values[6].ToString();
            txtAge.Text = GetAge_edit(txtDOB.Text.Trim());

            try
            {
                ddlMarital.SelectedItem.Selected = false;
                ddlMarital.Items.FindByValue(gvPatient.Rows[index].Cells[5].Text.Trim().Substring(0, 1)).Selected = true;
            }
            catch { }

            try
            {

                ddlPanel.SelectedItem.Selected = false;

                ddlPanel.Items.FindByValue(gvPatient.DataKeys[index].Values[5].ToString()).Selected = true;

                if (rdbCash.Checked)
                    rdbPanel.Checked = true;


                rdbCash.Checked = false;

                pnlPanel.Visible = true;

            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
                //  ddlPanel.ClearSelection();
                ddlPanel.Items.FindByValue("-1").Selected = true;
                rdbCash.Checked = true;
                rdbPanel.Checked = false;
                rdbPnl_Cash.Checked = false;
                lbtnSaveDependent.Visible = false;
                lblRela_hd.Visible = false;
                ddlRelation.Visible = false;
                pnlPanel.Visible = false;
            }


            if (rdbPanel.Checked == true || rdbPnl_Cash.Checked == true)
            {
                //lblF_parent.Text = gvPatient.DataKeys[index].Values[10].ToString();
                //Fill_Dependent(lblF_parent.Text);                
                //Show_Parent_Info();
                rdbCash.Enabled = false;
                rdbPanel.Enabled = true;
                //try
                //{
                //    ddlRelation.SelectedItem.Selected = false;
                //    ddlRelation.Items.FindByText(gvPatient.DataKeys[index].Values[8].ToString()).Selected = true; 
                //    ddlRelation.Enabled = true;
                //}
                //catch 
                //{
                //    //lblF_parent.Text = "null";
                //}
                //if (ddlRelation.SelectedItem.Text.ToString().Trim().Equals("Self"))
                //{
                //    lbtnSaveDependent.Visible = true;
                //    lblRela_hd.Visible = true;
                //    ddlRelation.Visible = true;
                //    lblName_Panel.Visible = true;
                //    lblName_Panel.Text = gvPatient.DataKeys[index].Values[9].ToString();

                //    ddlPanel.Enabled = true;
                //    txtSErviceNO.Enabled = true;
                //    ddlTitle.Enabled = true;
                //    rdbFemle.Enabled = true;
                //    rdbMale.Enabled = true;
                //    ddlMarital.Enabled = true;
                //}
                //else
                //{
                //    lbtnSaveDependent.Visible = true;
                //    lblRela_hd.Visible = true;
                //    ddlRelation.Visible = true;
                //    //ddlRelation.SelectedIndex = -1;
                //    lblName_Panel.Visible = true;
                //    lblName_Panel.Text = gvPatient.DataKeys[index].Values[9].ToString();

                //    ddlPanel.Enabled = false;
                //    txtSErviceNO.Enabled = false;
                //    ddlTitle.Enabled = false;
                //    rdbFemle.Enabled = false;
                //    rdbMale.Enabled = false;
                //    ddlMarital.Enabled = false;
                //}
            }
            //FillCLass_DDL();

            //try
            //{
            //    ddlClass.SelectedItem.Selected = false;
            //    ddlClass.Items.FindByValue(dv[0]["classid"].ToString()).Selected = true;
            //}
            //catch { }

            FillDoctor_DDL();
            lblStatus.Text = "u";
            txtPRnO.Enabled = false;

            gvPatient.DataSource = null;
            gvPatient.DataBind();
        }
    }

    protected void lbtnDependent_Click(object sender, EventArgs e)
    {
        lblPR_Panel.Text = this.lblID.Text.Trim();
        lblF_parent.Text = this.lblID.Text.Trim();
        lblName_Panel.Text = ddlTitle.SelectedItem.Text.ToString() + " " + this.txtName.Text.Trim();
        Show_Parent_Info();

        ddlTitle.SelectedIndex = -1;
        ddlMarital.SelectedIndex = -1;
        rdbFemle.Checked = false;
        rdbMale.Checked = false;

        lblRela_hd.Visible = true;
        ddlRelation.Visible = true;
        ddlRelation.Enabled = true;
        lblName_Panel.Visible = true;

        ddlRelation.SelectedIndex = -1;
        ddlPanel.Enabled = false;
        txtSErviceNO.Enabled = false;

        txtName.Text = "";
        txtDOB.Text = "";
        txtAge.Text = "";

        txtCellNo.Text = "";
        txtFax.Text = "";
        txtHPHone.Text = "";

        txtCNIC.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        txtPRnO.Text = "";

        lblStatus.Text = "i";
    }
    protected void gvDependent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            try
            {
                ddlTitle.SelectedItem.Selected = false;
                ddlTitle.Items.FindByValue(gvDependent.DataKeys[index].Values[2].ToString()).Selected = true;
            }
            catch { }

            txtPRnO.Text = gvDependent.Rows[index].Cells[1].Text.Trim();
            txtName.Text = gvDependent.DataKeys[index].Values[3].ToString();

            rdbMale.Checked = gvDependent.DataKeys[index].Values[13].ToString().Trim().Equals("Male") ? true : false;
            rdbFemle.Checked = gvDependent.DataKeys[index].Values[13].ToString().Trim().Equals("Female") ? true : false;

            txtDOB.Text = gvDependent.DataKeys[index].Values[14].ToString().Trim().ToString().Replace("&nbsp;", "");
            txtHPHone.Text = gvDependent.DataKeys[index].Values[12].ToString().Trim().ToString().Replace("&nbsp;", ""); ;
            txtCellNo.Text = gvDependent.DataKeys[index].Values[11].ToString().Trim().ToString().Replace("&nbsp;", ""); ;

            txtFax.Text = gvDependent.DataKeys[index].Values[8].ToString().Replace("&nbsp;", ""); ;
            txtEmail.Text = gvDependent.DataKeys[index].Values[15].ToString().Trim().Replace("&nbsp;", ""); ;

            txtCNIC.Text = gvDependent.DataKeys[index].Values[4].ToString().Replace("&nbsp;", ""); ;
            txtAddress.Text = gvDependent.DataKeys[index].Values[5].ToString().Replace("&nbsp;", ""); ;

            lblID.Text = gvDependent.DataKeys[index].Value.ToString();
            txtSErviceNO.Text = gvDependent.DataKeys[index].Values[7].ToString();

            try
            {
                ddlMarital.SelectedItem.Selected = false;
                ddlMarital.Items.FindByValue(gvDependent.DataKeys[index].Values[16].ToString().Trim().Substring(0, 1)).Selected = true;
            }
            catch { }

            try
            {
                ddlPanel.SelectedItem.Selected = false;
                ddlPanel.Items.FindByValue(gvDependent.DataKeys[index].Values[6].ToString()).Selected = true;
                rdbPanel.Checked = true;
                rdbCash.Checked = false;

                pnlPanel.Visible = true;
            }
            catch
            {
                rdbCash.Checked = true;
                rdbPanel.Checked = false;
                lbtnSaveDependent.Visible = false;
                lblRela_hd.Visible = false;
                ddlRelation.Visible = false;
                pnlPanel.Visible = false;
                pnl_panelInfo.Visible = false;
            }

            if (rdbPanel.Checked == true)
            {
                //Fill_Dependent(lblID.Text);
                lblF_parent.Text = gvDependent.DataKeys[index].Values[1].ToString();
                Show_Parent_Info();
                rdbCash.Enabled = false;
                rdbPanel.Enabled = false;
                try
                {
                    ddlRelation.SelectedItem.Selected = false;
                    ddlRelation.Items.FindByText(gvDependent.DataKeys[index].Values[9].ToString()).Selected = true;
                    ddlRelation.Enabled = true;
                }
                catch
                {
                    //lblF_parent.Text = "null";
                }
                if (ddlRelation.SelectedItem.Text.ToString().Trim().Equals("Self"))
                {
                    lbtnSaveDependent.Visible = true;
                    lblRela_hd.Visible = true;
                    ddlRelation.Visible = true;
                    lblName_Panel.Visible = true;
                    lblName_Panel.Text = gvDependent.DataKeys[index].Values[10].ToString();

                    ddlPanel.Enabled = true;
                    txtSErviceNO.Enabled = true;
                    ddlTitle.Enabled = true;
                    rdbFemle.Enabled = true;
                    rdbMale.Enabled = true;
                    ddlMarital.Enabled = true;
                }
                else
                {
                    lbtnSaveDependent.Visible = true;
                    lblRela_hd.Visible = true;
                    ddlRelation.Visible = true;
                    //ddlRelation.SelectedIndex = -1;
                    lblName_Panel.Visible = true;
                    ddlPanel.Enabled = false;
                    txtSErviceNO.Enabled = false;

                    ddlTitle.Enabled = false;
                    rdbFemle.Enabled = false;
                    rdbMale.Enabled = false;
                    ddlMarital.Enabled = false;
                    lblName_Panel.Text = gvDependent.DataKeys[index].Values[10].ToString();
                }
            }
            //FillCLass_DDL();

            //try
            //{
            //    ddlClass.SelectedItem.Selected = false;
            //    ddlClass.Items.FindByValue(dv[0]["classid"].ToString()).Selected = true;
            //}
            //catch { }

            FillDoctor_DDL();
            lblStatus.Text = "u";
            txtPRnO.Enabled = false;

        }
    }
    protected void ddlRelation_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtName.Focus();
        if (ddlRelation.SelectedIndex > 0)
        {
            switch (ddlRelation.SelectedItem.Text.Trim())
            {
                case "Self":
                    break;
                case "W/O":
                    ddlTitle.SelectedItem.Selected = false;
                    ddlTitle.Items.FindByText("Mrs").Selected = true;

                    rdbMale.Checked = false;
                    rdbFemle.Checked = true;

                    rdbMale.Enabled = false;
                    rdbFemle.Enabled = false;
                    ddlMarital.Enabled = false;
                    ddlTitle.Enabled = false;

                    ddlMarital.SelectedItem.Selected = false;
                    ddlMarital.Items.FindByValue("M").Selected = true;
                    break;
                case "M/O":
                    ddlTitle.SelectedItem.Selected = false;
                    ddlTitle.Items.FindByText("Mrs").Selected = true;

                    rdbMale.Checked = false;
                    rdbFemle.Checked = true;

                    rdbMale.Enabled = false;
                    rdbFemle.Enabled = false;
                    ddlMarital.Enabled = false;
                    ddlTitle.Enabled = false;

                    ddlMarital.SelectedItem.Selected = false;
                    ddlMarital.Items.FindByValue("M").Selected = true;
                    break;
                case "D/O":
                    ddlTitle.SelectedItem.Selected = false;
                    ddlTitle.Items.FindByText("Select").Selected = true; //miss

                    rdbMale.Checked = false;
                    rdbFemle.Checked = true;

                    rdbMale.Enabled = false;
                    rdbFemle.Enabled = false;
                    ddlMarital.Enabled = false;
                    ddlTitle.Enabled = true; // false

                    ddlMarital.SelectedItem.Selected = false;
                    ddlMarital.Items.FindByValue("S").Selected = true;
                    break;
                case "F/O":
                    ddlTitle.SelectedItem.Selected = false;
                    ddlTitle.Items.FindByText("Mr").Selected = true;

                    rdbMale.Checked = true;
                    rdbFemle.Checked = false;

                    rdbMale.Enabled = false;
                    rdbFemle.Enabled = false;
                    ddlMarital.Enabled = false;
                    ddlTitle.Enabled = false;

                    ddlMarital.SelectedItem.Selected = false;
                    ddlMarital.Items.FindByValue("M").Selected = true;
                    break;
                case "H/O":
                    ddlTitle.SelectedItem.Selected = false;
                    ddlTitle.Items.FindByText("Mr").Selected = true;

                    rdbMale.Checked = true;
                    rdbFemle.Checked = false;

                    rdbMale.Enabled = false;
                    rdbFemle.Enabled = false;
                    ddlMarital.Enabled = false;
                    ddlTitle.Enabled = false;

                    ddlMarital.SelectedItem.Selected = false;
                    ddlMarital.Items.FindByValue("M").Selected = true;
                    break;
                case "S/O":
                    ddlTitle.SelectedItem.Selected = false;
                    ddlTitle.Items.FindByText("Select").Selected = true; //mr

                    rdbMale.Checked = true;
                    rdbFemle.Checked = false;

                    rdbMale.Enabled = false;
                    rdbFemle.Enabled = false;
                    ddlMarital.Enabled = false;
                    ddlTitle.Enabled = true; // false

                    ddlMarital.SelectedItem.Selected = false;
                    ddlMarital.Items.FindByValue("S").Selected = true;
                    break;
            }
        }
        else
        {
            ddlTitle.SelectedIndex = -1;
            rdbFemle.Checked = false;
            rdbMale.Checked = false;
            ddlMarital.SelectedIndex = -1;

            rdbMale.Enabled = true;
            rdbFemle.Enabled = true;
            ddlMarital.Enabled = true;
            ddlTitle.Enabled = true;
        }
    }

    protected void imgService_Click(object sender, ImageClickEventArgs e)
    {
        lblError.Text = "";
        if (txtSErviceNO.Text.Trim().Equals(""))
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please enter Service number.";
            return;
        }
        clsBLPatientReg_Inv rec = new clsBLPatientReg_Inv();
        if (ddlPanel.SelectedIndex > 0)
            rec.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        rec.ServiceNo = this.txtSErviceNO.Text.Trim().Replace("'", "''");

        DataView dv = rec.GetAll(9); // 18

        if (dv.Count > 0)
        {
            //gvDependent.DataSource = dv;
            //gvDependent.DataBind();

            gvPatient.DataSource = dv;
            gvPatient.DataBind();

            gvPatient.Visible = true;

            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Total Records (<b> " + dv.Count.ToString() + " </b>) Found";

            //gvPatient.Columns[8].Visible = false; // email hide
            //gvPatient.Columns[9].Visible = true; // panel company show
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Sorry! No employee found....";
        }
    }
    protected void lbtnSaveDependent_Click(object sender, EventArgs e)
    {
        if (!Validate_Dependent())
            return;

        if (lblStatus.Text == "i")
            Dependent_Insert();
        else
            Dependent_Update();

        Show_Parent_Info();
    }

    protected void chkTitleENB_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTitleENB.Checked == true)
        {
            ddlTitle.SelectedIndex = 0;
            ddlTitle.Enabled = false;
        }
        else
            ddlTitle.Enabled = true;
    }
    protected void lbtnPatientTrack_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('wfrmTrack.aspx');</script>", false);
        //wfrmTrack.aspx
    }
    protected void rdbPnl_Cash_CheckedChanged(object sender, EventArgs e)
    {
        if (!pnlPanel.Visible)
        {
            pnlPanel.Visible = true;
            txtAuthorize.Enabled = true;
            FillDoctor_DDL();
        }
    }

    protected void lbtnAdd_Rmk_Click(object sender, EventArgs e)
    {
        if (txtRemark.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script></script>", false);
            lblError.Text = "Please enter remark first";
            return;
        }

        string myXMLfile = Server.MapPath(@"../Remark.xml");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt.TableName = "Remark";
        if (System.IO.File.Exists(myXMLfile))
        {
            System.IO.FileStream fsReadXml = new System.IO.FileStream
                            (myXMLfile, System.IO.FileMode.Open);
            ds.ReadXml(fsReadXml);
            dt = ds.Tables[0];
            fsReadXml.Close();
        }
        else
        {
            dt.Columns.Add("description");
            dt.Columns.Add("default");
        }
        DataRow dr = dt.NewRow();
        dr["description"] = txtRemark.Text.Trim();

        dt.Rows.Add(dr);
        dt.AcceptChanges();
        dt.WriteXml(myXMLfile);
    }
    protected void lbTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strText = lbTemplate.SelectedItem.Text.Trim();
        //if (strText.StartsWith("("))
        //{
        //    int eIndex = strText.IndexOf(')', 1);
        //    strText = strText.Remove(0, eIndex + 1);
        //}

        //if (!txtRemark.Text.Contains(strText))
        //{
        //    if (!txtRemark.Text.Trim().Equals(""))       //For more than template
        //        txtRemark.Text += " " + strText;
        //    else
        //        txtRemark.Text = strText.Trim();
        //}
        //else if (txtRemark.Text.Trim().Equals(""))
        txtRemark.Text = strText.Trim();
        //else
        //    txtRemark.Text += " " + strText.Trim();

        lbTemplate.Visible = false;
    }
    protected void imgOpn_Rmk_Click(object sender, ImageClickEventArgs e)
    {
        if (imgOpn_Rmk.ImageUrl.Contains("collapsew.jpg"))
            imgOpn_Rmk.ImageUrl = "../images/expandw.jpg";
        else
            imgOpn_Rmk.ImageUrl = "../images/collapsew.jpg";
        if (lbTemplate.Visible)
        {
            lbTemplate.Visible = false;
        }
        else
        {

            string myXMLfile = Server.MapPath(@"../Remark.xml");
            DataSet ds = new DataSet();
            // DataTable dt = new DataTable();

            if (System.IO.File.Exists(myXMLfile))
            {
                System.IO.FileStream fsReadXml = new System.IO.FileStream
                                (myXMLfile, System.IO.FileMode.Open);
                ds.ReadXml(fsReadXml);
                // dt = ds.Tables[0];
                lbTemplate.DataTextField = ds.Tables["Remark"].Columns["description"].ToString();
                lbTemplate.DataValueField = ds.Tables["Remark"].Columns["description"].ToString();

                lbTemplate.DataSource = ds.Tables["Remark"];
                lbTemplate.DataBind();
                fsReadXml.Close();
            }

            lbTemplate.Visible = (lbTemplate.Items.Count > 0);
            lbTemplate.ClearSelection();
        }
    }
}