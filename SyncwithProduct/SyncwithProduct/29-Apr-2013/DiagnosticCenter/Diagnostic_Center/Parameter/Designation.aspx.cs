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

public partial class Designation : System.Web.UI.Page
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
                log.OptionId = "2";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblDesignationId.Text = "";
                    FillOrgDDL();
                    Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlOrganization.Focus();
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

    private void FillOrgDDL()
    {
        clsOrganization objOrg = new clsOrganization();
        SComponents objScom = new SComponents();
        DataView dv = objOrg.GetAll(4);
        objScom.FillDropDownList(ddlOrganization, dv, "Name", "OrgId", true, false, true);
        this.ddlOrganization.SelectedValue = "-1";
    }

    private void Fillgv()
    {
        clsDesignation objDC = new clsDesignation();
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }    
        DataView dv = objDC.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvDesignation.DataSource = dv;
            gvDesignation.DataBind();
            gvDesignation.Visible = true;
        }
        else
        {
            gvDesignation.Visible = false;
        }
    }
    private void Insert()
    {
        clsDesignation objDC = new clsDesignation();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        objDC.DOrder = txtDOrder.Text.Trim().Equals("") ? "~!@" : txtDOrder.Text.Trim();
        objDC.DLevel = txtDLevel.Text.Trim().Equals("") ? "~!@" : txtDLevel.Text.Trim();        
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
        if (objDC.Insert())
        {
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
        clsDesignation objDC = new clsDesignation();
        objDC.DesignationId = lblDesignationId.Text.Trim();
        objDC.Name = txtName.Text.Trim();
        objDC.Acronym = txtAcronym.Text.Trim();
        objDC.Description = txtDescription.Text.Trim();
        if (!this.ddlOrganization.SelectedItem.Value.ToString().Equals("-1"))
        {
            objDC.OrgId = this.ddlOrganization.SelectedItem.Value.ToString();
        }
        objDC.DOrder = txtDOrder.Text.Trim().Equals("") ? "~!@" : txtDOrder.Text.Trim();
        objDC.DLevel = txtDLevel.Text.Trim().Equals("") ? "~!@" : txtDLevel.Text.Trim();       
        objDC.Active = chkActive.Checked ? "Y" : "N";
        objDC.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objDC.Enteredby = Session["PersonId"].ToString();
        objDC.ClientId = Session["orgid"].ToString(); // org
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
        txtDescription.Text = "";
        this.ddlOrganization.SelectedValue = "-1";
        txtDOrder.Text = "";
        txtDLevel.Text = "";       
        chkActive.Checked = true;
        lblErrMsg.Text = "";
        Fillgv();
        lblstatus.Text = "i";
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
        lblDesignationId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void gvDesignation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsDesignation objDC = new clsDesignation();
        lblDesignationId.Text = objDC.DesignationId = gvDesignation.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objDC.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtName.Text = dv[0]["Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtDescription.Text = dv[0]["Description"].ToString();
            try
            {
                this.ddlOrganization.SelectedItem.Selected = false;
                this.ddlOrganization.Items.FindByValue(dv[0]["OrgId"].ToString()).Selected = true;
            }
            catch { }
            this.txtDOrder.Text = dv[0]["DOrder"].ToString();
            this.txtDLevel.Text = dv[0]["DLevel"].ToString();            
            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
        }
    }

    protected void gvDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDesignation.PageIndex = e.NewPageIndex;
        Fillgv();        
    }
    protected void gvDesignation_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
    }
    protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsDesignation objDC = new clsDesignation();
            lblDesignationId.Text = objDC.DesignationId = gvDesignation.DataKeys[index].Value.ToString();
            DataView dv = objDC.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtName.Text = dv[0]["Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtDescription.Text = dv[0]["Description"].ToString();
                try
                {
                    this.ddlOrganization.SelectedItem.Selected = false;
                    this.ddlOrganization.Items.FindByValue(dv[0]["OrgId"].ToString()).Selected = true;
                }
                catch { }
                this.txtDOrder.Text = dv[0]["DOrder"].ToString();
                this.txtDLevel.Text = dv[0]["DLevel"].ToString();
                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            }
        }
    }
}
