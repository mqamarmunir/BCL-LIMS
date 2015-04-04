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

public partial class vitalsign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "41";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    lblStatus.Text = "i";
                    FillGV();
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
        Response.Redirect("MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear_Form();
        FillGV();
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtUnit.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please enter unit');</script>", false);

            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please enter unit";
            return;
        }
        clsBLVitalSign vs = new clsBLVitalSign();

        vs.VitalID = this.lblID.Text.Trim();
        vs.Name = this.txtVitalSign.Text.Trim().Replace("'", "''");
        vs.Unit = this.txtUnit.Text.Trim().Replace("'","''");
        vs.Active = this.chkActive.Checked ? "Y" : "N";

        vs.EnteredBy = Session["personid"].ToString();
        vs.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        vs.ClientID = Session["orgid"].ToString();

        if (lblStatus.Text == "i")
        {
            if (vs.Insert())
            {
                Clear_Form();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Vital sign has been saved successfully');</script>", false);
                
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Vital sign has been saved successfully";
                
                FillGV();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + vs.Error + "');</script>", false);
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = vs.Error;

            }
        }
        else
        {
            if (vs.Update())
            {
                Clear_Form();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Vital sign has been updated successfully');</script>", false);

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Vital sign has been saved successfully";
                
                FillGV();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + vs.Error + "');</script>", false);
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = vs.Error;

            }
        }
    }

    private void Clear_Form()
    {
        txtVitalSign.Text = "";
        txtUnit.Text = "";
        lblStatus.Text = "i";

        lblID.Text = "";
        chkActive.Checked = true;
        lblError.Text = "";
    }
    private void FillGV()
    {
        clsBLVitalSign vs = new clsBLVitalSign();
        DataView dv = vs.GetAll(1);

        gvVital.DataSource = dv;
        gvVital.DataBind();
    }

    protected void gvVital_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvVital.DataKeys[index].Value.ToString();
            txtVitalSign.Text = gvVital.Rows[index].Cells[1].Text.Trim().Replace("&nbsp;","");
            txtUnit.Text = gvVital.Rows[index].Cells[2].Text.Trim().Replace("&nbsp;","");
            chkActive.Checked = ((CheckBox)(gvVital.Rows[index].Cells[2].FindControl("chkgvActive"))).Checked;

            lblStatus.Text = "u";
        }
    }
}
