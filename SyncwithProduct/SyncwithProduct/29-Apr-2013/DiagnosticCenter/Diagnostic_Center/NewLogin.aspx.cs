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
using System.Xml;
using System.Management;

public partial class NewLogin : System.Web.UI.Page
{
    protected static string focusElement = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblErrMsg.Text = "";
            if (Request.QueryString["errmsg"] != null)
            {
                this.lblErrMsg.Text = Request.QueryString["errmsg"].ToString();
            }
            if (!IsPostBack)
            {
                Session["Personid"] = "";
                Session["PersonName"] = "";
                fillddlbranch();
                focusElement = this.txtName.ID.ToString();
               
            }
        }
        catch (NullReferenceException e1) { }
    }

    public void fillddlbranch()
    {
        clsBLBranch objbranch = new clsBLBranch();
        DataView dv_branch = objbranch.GetAll(3);
        if (dv_branch.Count > 0)
        {
            SComponents obj_com = new SComponents();
            obj_com.FillDropDownList(ddlBranch, dv_branch, "Name", "BranchID", true, false, true);
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        {
            lblErrMsg.Text = "";
            if (this.txtName.Value.ToString() == "" || this.txtName.Value.ToString().Length > 14)
            {
                lblErrMsg.Text = "Login ID must be entered. or Login ID not more than 14 characters";
            }
            else if (this.txtPassword.Value.ToString() == "" || this.txtPassword.Value.ToString().Length > 14)
            {
                lblErrMsg.Text = "User Password must be entered. or Password not more than 14 characters";
            }
            else if (ddlBranch.SelectedIndex==0)
            {
                lblErrMsg.Text = "Select Branch";
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Font.Bold = true;
            }
            else
            {
                clsLogin objLogin = new clsLogin();
                objLogin.Loginid = this.txtName.Value.ToString().Trim();
                objLogin.Password = this.txtPassword.Value.ToString().Trim();
                objLogin.BranchID = ddlBranch.SelectedValue.ToString().Trim();
                if (System.Configuration.ConfigurationManager.AppSettings["clientid"] == "006")
                {
                    if (ddlBranch.SelectedValue.ToString().Trim().ToString() == "4")
                    {
                        objLogin.ClientID = "008";
                    }
                    else if (ddlBranch.SelectedValue.ToString().Trim().ToString() == "3")
                    {
                        objLogin.ClientID = "020";
                    }
                    else if (ddlBranch.SelectedValue.ToString().Trim().ToString() == "2")
                    {
                        objLogin.ClientID = "007";
                    }
                    else
                    {
                        objLogin.ClientID = "006";
                    }
                }
                else
                {
                    objLogin.ClientID=System.Configuration.ConfigurationManager.AppSettings["clientid"].Trim();
                }
                DataView dvLogin = objLogin.GetLogin(1);
                if (dvLogin.Count > 0)
                {
                   // if (dvLogin[0]["crosslab"].ToString().Trim().Equals("N") && dvLogin[0]["orgid"].ToString() != System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString())
                    //if (dvLogin[0]["crosslab"].ToString().Trim().Equals("N"))
                    
                    //{
                    //    lblErrMsg.Text = "You do not belong to this organization";
                    //    return;
                    //}
                    //if (!V_Control())
                    //    return;

                    Session.Timeout = 120;
                    Session["Personid"] = dvLogin[0].Row["PersonId"].ToString();
                    Session["PersonName"] = dvLogin[0].Row["PersonName"].ToString() + "  ( " + dvLogin[0].Row["BRName"].ToString() + " )";//orgname
                    //+ Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Equals("006") ? "BCL" : "AMC") + " )";//
                    if (System.Configuration.ConfigurationManager.AppSettings["clientid"].Trim() == "006")
                    {
                        if (dvLogin[0]["BranchID"].ToString() == "4")
                        {
                            Session["Clientid"] = "008";
                        }
                        else if (dvLogin[0]["BranchID"].ToString() == "3")
                        {
                            Session["Clientid"] = "020";
                        }
                        else if (dvLogin[0]["BranchID"].ToString() == "2")//BCL Aziz Fatimah hospital
                        {
                            Session["Clientid"] = "007";
                        }
                        else
                        {
                            Session["Clientid"] = "006";

                        }
                    }
                    else
                    {
                        Session["Clientid"] = System.Configuration.ConfigurationManager.AppSettings["clientid"].Trim();
 
                    }
                    Session["OrgId"] = dvLogin[0].Row["OrgId"].ToString();

                    Session["designationid"] = dvLogin[0].Row["designationid"].ToString();
                    Session["branchid"] = dvLogin[0]["BranchID"].ToString();
                    Session["BranchCode"]=dvLogin[0]["BranchCode"].ToString().Trim();
                    Session["BranchType"] = dvLogin[0]["BrType"].ToString().Trim();
                    Session["f11"] = "";

                    Session["u_deptid"] = dvLogin[0]["departmentid"].ToString();
                    Session["u_subdeptid"] = dvLogin[0]["subdepartmentid"].ToString();
                    Session["crossDept"] = dvLogin[0]["crossdept"].ToString();
                    Session["indoor_services"] = dvLogin[0]["indoor_services"].ToString();
                    Session["default_route"] = dvLogin[0]["default_route"].ToString();
                    Session["groupid"] = dvLogin[0]["groupid"].ToString().Trim();
                    Session["cliqbranchid"] = dvLogin[0]["cliqbranchid"].ToString().Trim();
                    Session["logintime"] = System.DateTime.Now.ToString("HH:mm");
                    //Generate_XML();
                    StoreSessionInfo();

                    
                    Response.Redirect("~/transaction/wfrmCashierEntry.aspx");
                    //if (dvLogin[0]["defaultpage"].ToString() != "")
                    //{
                    //    Response.Redirect("~/transaction/wfrmCashierEntry.aspx");
                    //   // string str = MasterPage.GetAddress(Convert.ToInt32(dvLogin[0]["defaultpage"].ToString()));
                    //   // Response.Redirect(str.Split(',')[2]);
                    //}
                    //else
                    //    Response.Redirect("~/transaction/wfrmCashierEntry.aspx");
                }
                else
                {
                    lblErrMsg.Text = "Login ID or Password is Incorrect";
                }
            }
        }
    }

    private void StoreSessionInfo()
    {
        clsLogin objlogin = new clsLogin();
        objlogin.BranchID = Session["Branchid"].ToString().Trim();
        objlogin.PersonId = Session["personid"].ToString().Trim();
        objlogin.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objlogin.Ipaddress = Page.Request.UserHostAddress.ToString();
        try
        {
            string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
            objlogin.hostname = computer_name[0];
        }
        catch 
        {
            objlogin.hostname = System.Environment.MachineName;
        }// String ecn = System.Environment.MachineName;
        objlogin.macaddress = GetMACAddress();
        if (objlogin.insert())
        {

        }
        else
        {
            Response.Write(objlogin.ErrorMessage);
        }

        //objlogin.en
        //throw new NotImplementedException();
    }

    public string GetMACAddress()
    {
        
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        string MACAddress = String.Empty;
        foreach (ManagementObject mo in moc)
        {
            if (MACAddress == String.Empty)  // only return MAC Address from first card
            {
                if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
            }
            mo.Dispose();
        }

        MACAddress = MACAddress.Replace(":", "");
        return MACAddress;
    }
        
    private void Generate_XML()
    {
        clsLogin objLogin = new clsLogin();
        objLogin.PersonId = Session["personid"].ToString();

        DataView dvAll = objLogin.GetLogin(3);
        DataView dvTran = new DataView();
        DataView dvP = new DataView();
        DataView dvRpt = new DataView();

        dvTran.Table = dvAll.ToTable();
        dvP.Table = dvAll.ToTable();
        dvRpt.Table = dvAll.ToTable();

        DataSet ds = new DataSet();

        DataTable dt = new DataTable("Parameter");
        dt.Columns.Add("id");
        DataTable dtTrans = new DataTable("Transaction");
        dtTrans.Columns.Add("id");
        DataTable dtRpt = new DataTable("Report");
        dtRpt.Columns.Add("id");

        try
        {
            string strFilePath = Server.MapPath(@"~/XML/" + Session["personid"].ToString() + "_" + System.DateTime.Now.ToString("dd_MM_yy_hh_mm_tt") + ".xml");
            dvP.RowFilter = "optionid in (1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,53,26,27,28,39,41,42,44,45,61,62,63,65,67,68,69,93,81)";
            for (int i = 0; i < dvP.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = dvP[i]["optionid"].ToString();
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);

            dvTran.RowFilter = "optionid in (29,30,31,34,35,36,37,38,40,43,46,54,64,66)";
            for (int i = 0; i < dvTran.Count; i++)
            {
                DataRow dr = dtTrans.NewRow();
                dr["id"] = dvTran[i]["optionid"].ToString();
                dtTrans.Rows.Add(dr);
            }
            ds.Tables.Add(dtTrans);

            dvRpt.RowFilter = "optionid in (32,33,47,48,49,50,51,52,55,56,57,58,59,60)";

            for (int i = 0; i < dvRpt.Count; i++)
            {
                DataRow dr = dtRpt.NewRow();
                dr["id"] = dvRpt[i]["optionid"].ToString();
                dtRpt.Rows.Add(dr);
            }
            ds.Tables.Add(dtRpt);
            ds.WriteXml(strFilePath);
            Session["menu_xml"] = strFilePath;
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "');</script>", false);
        }
    }

    private bool V_Control()
    {
        string version = "1.1.100";
        string current_ver = "";
        string exp_date = "";
        string StrGet_date = "";
        string strGet_Ver = "";
        string PRID = "";

        string dtNow =System.DateTime.Now.ToString("yyyy-MM-dd");
        
        clsLogin log = new clsLogin();
        DataView dv = log.GetLogin(5);
        if (dv.Count > 0)
        {            
            current_ver = dv[0]["version"].ToString();
            exp_date = dv[0]["exp_date"].ToString();
            
            for (int i = current_ver.Length - 1; i >= 0; i--)
            {
                strGet_Ver = strGet_Ver + (char)(current_ver[i] + 10);
            }
            for (int i = exp_date.Length - 1; i >= 0; i--)
            {
                StrGet_date = StrGet_date + (char)(exp_date[i] + 10);
            }
            for (int i = dv[0]["prid"].ToString().Length - 1; i >= 0; i--)
            {
                PRID = PRID + (char)((char)(dv[0]["prid"].ToString()[i]) + 10);
            }
            if (version != strGet_Ver)
            {
                lblErrMsg.Text = "Application is corrupt.Please contact application provider.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Application is corrupt.Please contact application provider.');</script>", false);
                return false;
            }
          else  if (DateTime.Parse(dtNow) > DateTime.Parse(StrGet_date))
            {
                lblErrMsg.Text = "Application is corrupt.Please contact application provider.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Application is corrupt.Please contact application provider.');</script>", false);
                return false;
            }
            else if (Convert.ToInt32(dv[0]["maxPRID"]) > Convert.ToInt32(PRID))
            {
                lblErrMsg.Text = "Application is corrupt.Please contact application provider.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Application is corrupt.Please contact application provider.');</script>", false);
                return false;
            }
            else
                return true;
        }
        else
        {
            lblErrMsg.Text = "You are using old version.Please contact your administrator";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('You are using old version.Please contact your administrator');</script>", false);
            return false;
        }
    }
}
