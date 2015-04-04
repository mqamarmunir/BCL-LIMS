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

public partial class procedure_d : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "19";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillDDL();
                    lblStatus.Text = "i";
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

    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_Form();

        ddlProcess.SelectedIndex = -1;
        ddlProcedure.SelectedIndex = -1;

        gvProcedureD.DataSource = null;
        gvProcedureD.DataBind();
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Validate_form())
            return;
        if (lblStatus.Text == "i")
            Insert();
        else
            Update();
    }

    private void Clear_Form()
    {
        lblError.Text = "";
        lblID.Text = "";
        lblStatus.Text = "i";
        lblProcessID.Text = "";
        chkActive.Checked = true;
               
    }
    private bool Validate_form()
    {
        lblError.Text ="";
        lblError.ForeColor = System.Drawing.Color.Red;

        if(ddlProcedure.SelectedIndex<=0)
        {
            lblError.Text = "Please select procedure first";
            return false;
        }
        if (ddlProcess.SelectedIndex <= 0)
        {
            lblError.Text = "Please select process first";
            return false;
        }
        return true;
    }

    private void FillDDL()
    {
        clsBLProcedure pr = new clsBLProcedure();
        SComponents com = new SComponents();

        DataView dv = pr.GetAll(4); // procedure Dropdown
        DataView dvProce = pr.GetAll(5); // process Dropdown

        com.FillDropDownList(ddlProcedure, dv, "name", "procedureid");
        com.FillDropDownList(ddlProcess,dvProce,"name","processid");
    }
    private void FillGV()
    {
        clsBLProcedure pr = new clsBLProcedure();
        pr.ProcedureID = this.ddlProcedure.SelectedItem.Value.ToString();
        DataView dv = pr.GetAll(6);
        if (dv.Count > 0)
        {
            gvProcedureD.DataSource = dv;
            gvProcedureD.DataBind();
        }
        else
        {
            gvProcedureD.DataSource = null;
            gvProcedureD.DataBind();
        }
    }

    private void Insert()
    {
        clsBLProcedure pr = new clsBLProcedure();

        pr.ProcedureID = this.ddlProcedure.SelectedItem.Value.ToString();
        pr.ProcessID = this.ddlProcess.SelectedItem.Value.ToString();
       
        pr.D_Active = this.chkActive.Checked ? "Y" : "N";
        pr.EnteredBy = Session["personid"].ToString();
        pr.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pr.ClientID = Session["orgid"].ToString(); // org
        if (pr.InsertProcedureD())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";
            FillGV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = pr.Error;
        }
    }
    private void Update()
    {
        clsBLProcedure pr = new clsBLProcedure();

        pr.Old_ProcedureID = this.lblID.Text.Trim();
        pr.Old_ProcessID = this.lblProcessID.Text.Trim();

        pr.D_Active = this.chkActive.Checked ? "Y" : "N";
        pr.ProcedureID = this.ddlProcedure.SelectedItem.Value.ToString();
        pr.ProcessID = this.ddlProcess.SelectedItem.Value.ToString();
        pr.ClientID = Session["orgid"].ToString(); // org

        pr.EnteredBy = Session["personid"].ToString();
        pr.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        if (pr.InsertProcedureD())
        {
            Clear_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been updated successfully";
            FillGV();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = pr.Error;
        }
    }
    protected void gvProcedureD_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";

        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvProcedureD.DataKeys[index].Value.ToString();
            lblProcessID.Text = gvProcedureD.DataKeys[index].Values[1].ToString();

            try
            {
                ddlProcedure.SelectedItem.Selected = false;
                ddlProcedure.Items.FindByValue(gvProcedureD.DataKeys[index].Value.ToString()).Selected = true;
            }
            catch { }

            try
            {
                ddlProcess.SelectedItem.Selected = false;
                ddlProcess.Items.FindByValue(gvProcedureD.DataKeys[index].Values[1].ToString()).Selected = true;
            }
            catch { }
            chkActive.Checked = ((CheckBox)(gvProcedureD.Rows[index].Cells[3].FindControl("chkGVActive"))).Checked;
            lblStatus.Text = "u";
        }
    }
    protected void ddlProcedure_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (ddlProcedure.SelectedIndex > 0)
        {
            FillGV();
        }
        else
        {
            gvProcedureD.DataSource = null;
            gvProcedureD.DataBind();
        }
    }
}
