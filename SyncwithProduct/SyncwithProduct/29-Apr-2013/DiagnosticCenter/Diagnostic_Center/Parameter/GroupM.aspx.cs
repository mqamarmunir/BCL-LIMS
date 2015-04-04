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

public partial class GroupM : System.Web.UI.Page
{
    private static string DGSort = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["PersonId"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "8";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblGroupId.Text = "";
                    if (!Session["GroupId"].Equals(""))
                    {
                        lblErrMsg.Text = "";
                        lblstatus.Text = "u";
                        clsGroupM objDC = new clsGroupM();
                        lblGroupId.Text = objDC.GroupId = Session["GroupId"].ToString();
                        DataView dv = objDC.GetAll(3);
                        if (dv.Count > 0)
                        {
                            this.txtName.Text = dv[0]["Name"].ToString();
                            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                            this.txtDescription.Text = dv[0]["Description"].ToString();
                            this.txtDOrder.Text = dv[0]["DOrder"].ToString();
                            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                        }
                    }
                    Session["GroupId"] = "";
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


    private void Fillgv()
    {
        clsGroupM objDC = new clsGroupM();       
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvGroup.DataSource = dv;
            gvGroup.DataBind();
            gvGroup.Visible = true;
        }
        else
        {
            gvGroup.Visible = false;
        }
    }
    private void Insert()
    {
        clsGroupM objDC = new clsGroupM();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        objDC.DOrder = txtDOrder.Text.Trim().Equals("") ? "~!@" : txtDOrder.Text.Trim();
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();

        objDC.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim(); // org
        objDC.Package = chkPackage.Checked == true ? "Y" : "N";
        if (chkPackage.Checked)
        {
            objDC.packageDateFrom = txtpackageFrom.Text.Trim();
            objDC.packagedateto = txtpackageto.Text.Trim();
        }
        if (objDC.Insert())
        {
            lblGroupId.Text = objDC.GroupId.ToString();
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
        clsGroupM objDC = new clsGroupM();
        objDC.GroupId = lblGroupId.Text.Trim();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        objDC.DOrder = txtDOrder.Text.Trim().Equals("") ? "~!@" : txtDOrder.Text.Trim();
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim(); // org
        objDC.Package = chkPackage.Checked == true ? "Y" : "N";
        if (chkPackage.Checked)
        {
            objDC.packageDateFrom = txtpackageFrom.Text.Trim();
            objDC.packagedateto = txtpackageto.Text.Trim();
        }
        if (objDC.Update())
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
        txtDOrder.Text = "";
        txtDescription.Text = "";        
        chkActive.Checked = true;
        lblErrMsg.Text = "";
        Fillgv();        
        lblstatus.Text = "i";
        chkPackage.Checked = false;
        fsapplicablefrom.Visible = false;
        txtpackageFrom.Text = "";
        txtpackageto.Text = "";
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
        lblGroupId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void gvGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGroup.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvGroup_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsGroupM objDC = new clsGroupM();
        lblGroupId.Text = objDC.GroupId = gvGroup.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtName.Text = dv[0]["Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtDescription.Text = dv[0]["Description"].ToString();
            this.txtDOrder.Text = dv[0]["DOrder"].ToString();                       
            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
        }
    }
    protected void gvGroup_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void lbtnSaveNext_Click(object sender, EventArgs e)
    {
        if (lblstatus.Text == "i")
            Insert();
        else
            Update();

        if (lblErrMsg.ForeColor.Equals(System.Drawing.Color.Green))
        {
            Session["GroupId"] = lblGroupId.Text.Trim();
            Response.Redirect("Test.aspx");
        }        
    }

    protected void gvGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsGroupM objDC = new clsGroupM();
            lblGroupId.Text = objDC.GroupId = gvGroup.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtName.Text = dv[0]["Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtDescription.Text = dv[0]["Description"].ToString();
                this.txtDOrder.Text = dv[0]["DOrder"].ToString();
                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                this.chkPackage.Checked = (dv[0]["Package"].ToString().Equals("Y")) ? true : false;
                if (chkPackage.Checked)
                {
                    fsapplicablefrom.Visible = true;
                    txtpackageFrom.Text = dv[0]["packagedatefrom"].ToString();
                    txtpackageto.Text = dv[0]["packagedateto"].ToString();
                }
                else
                {
                    fsapplicablefrom.Visible = false;
                    txtpackageFrom.Text = "";
                    txtpackageto.Text = "";
                }
            }
        }
    }
    protected void chkPackage_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPackage.Checked)
        {
            fsapplicablefrom.Visible = true;
        }
        else
        {
            fsapplicablefrom.Visible = false;
        }
    }
}
