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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack) 
            {
                clsLogin log = new clsLogin();
                log.OptionId = "18";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillGV();
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
        Response.Redirect("Mainpage.aspx");
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

    private void Clear_Form()
    {
        lblStatus.Text = "i";
        lblID.Text = "";

        txtAcronym.Text = "";
        txtProcedure.Text = "";

        lblError.Text = "";
        chkActive.Checked = true;
    }
    private void FillGV()
    {
        clsBLProcedure pr = new clsBLProcedure();
        DataView dv = pr.GetAll(1);
        if (dv.Count > 0)
        {
            gvProcedure.DataSource = dv;
            gvProcedure.DataBind();
        }
        else
        {
            gvProcedure.DataSource = null;
            gvProcedure.DataBind();
        }
    }

    private void Insert()
    {
        clsBLProcedure pr = new clsBLProcedure();

        pr.Name = this.txtProcedure.Text.Trim();
        pr.Acronym = this.txtAcronym.Text.Trim();
        pr.Active = this.chkActive.Checked ? "Y" : "N";

        pr.EnteredBy = Session["personid"].ToString();
        pr.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pr.ClientID = Session["orgid"].ToString();
       

        if (pr.Insert())
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

        pr.ProcedureID = this.lblID.Text.Trim();
        pr.Name = this.txtProcedure.Text.Trim();
        pr.Acronym = this.txtAcronym.Text.Trim();
        pr.Active = this.chkActive.Checked ? "Y" : "N";

        pr.EnteredBy = Session["personid"].ToString();
        pr.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pr.ClientID = Session["orgid"].ToString();
       
        if (pr.Update())
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

    private bool Validate_Form()
    {
        lblError.Text = "";
        lblError.ForeColor = System.Drawing.Color.Red;

        if (txtProcedure.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter procedure name.(empty is not allowed)";
            return false;
        }
        if (txtAcronym.Text.Trim().Equals(""))
        {
            lblError.Text = "Please enter acronym.(empty is not allowed)";
            return false;
        }
        return true;
    }


    protected void gvProcedure_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";

        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvProcedure.DataKeys[index].Value.ToString();

            txtProcedure.Text = gvProcedure.Rows[index].Cells[1].Text.Trim().Replace("&nbsp;","");
            txtAcronym.Text = gvProcedure.Rows[index].Cells[2].Text.Trim().Replace("&nbsp;","");

            chkActive.Checked = ((CheckBox)(gvProcedure.Rows[index].Cells[3].FindControl("chkGVActive"))).Checked;
            lblStatus.Text = "u";

        }
    }
}
