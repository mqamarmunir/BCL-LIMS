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

public partial class Method_Reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "16";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    lblStatus.Text = "i";
                    FillDDlSub();
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
        ddlSUBDept.SelectedIndex = -1;
        Clear_Form();

    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (!Form_Validate())
            return;

        if (lblStatus.Text.Trim().Equals("i"))
            Insert();
        else
            Update();
    }

    private void Clear_Form()
    {
        lblErrMSg.Text = "";
        lblID.Text = "";
        lblStatus.Text = "i";

        txtMethod.Text = "";
        txtAcronym.Text = "";

        txtDorder.Text = "";
        txtMaxTime.Text = "";
        txtMinTime.Text = "";

        chkActive.Checked = true;
        chkDefault.Checked = false;
    }
    private void Insert()
    {
        clsMethod mt = new clsMethod();

        mt.Method = this.txtMethod.Text.Trim().Replace("'","''");
        mt.SubDeptID = this.ddlSUBDept.SelectedItem.Value.ToString().Replace("-1","");

        mt.Acronym = this.txtAcronym.Text.Trim().Replace("'","''");
        mt.Active = this.chkActive.Checked ? "Y" : "N";
        mt.Default_value = this.chkDefault.Checked ? "Y" : "N";

        switch (ddlTimeType.SelectedItem.Value)
        {
            case "H":
                mt.MinTime = Convert.ToString(Convert.ToInt32(txtMinTime.Text.Trim()) * 60);
                mt.MaxTime = Convert.ToString(Convert.ToInt32(txtMaxTime.Text.Trim()) * 60);
                break;
            case "M":
                mt.MinTime = txtMinTime.Text.Trim();
                mt.MaxTime = txtMaxTime.Text.Trim();
                break;
            case "D":
                mt.MinTime = Convert.ToString(Convert.ToInt32(txtMinTime.Text.Trim()) * 1440);
                mt.MaxTime = Convert.ToString(Convert.ToInt32(txtMaxTime.Text.Trim()) * 1440);
                break;
            default:            
                mt.MinTime = "0";
                mt.MaxTime = "0";
                break;
        }

        if (!txtDorder.Text.Trim().Equals(""))
            mt.Dorder = this.txtDorder.Text.Trim();
        else
            mt.Dorder = "0";
        mt.EnteredBy = Session["personid"].ToString();
        mt.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        mt.ClientID = Session["orgid"].ToString(); // org

        if (mt.Insert())
        {
            Clear_Form();
            FillDG();

            lblErrMSg.ForeColor = System.Drawing.Color.Green;
            lblErrMSg.Text = "Record has been saved successfully";
        }
        else
        {
            lblErrMSg.ForeColor = System.Drawing.Color.Red;
            lblErrMSg.Text = mt.Error;
        }
    }
    private void Update()
    {
        clsMethod mt = new clsMethod();

        mt.MethodID = this.lblID.Text.Trim();
        mt.Method = this.txtMethod.Text.Trim().Replace("'", "''");
        mt.SubDeptID = this.ddlSUBDept.SelectedItem.Value.ToString().Replace("-1", "");

        mt.Acronym = this.txtAcronym.Text.Trim().Replace("'", "''");
        mt.Active = this.chkActive.Checked ? "Y" : "N";
        mt.Default_value = this.chkDefault.Checked ? "Y" : "N";

        switch (ddlTimeType.SelectedItem.Value)
        {
            case "H":
                mt.MinTime = Convert.ToString(Convert.ToInt32(txtMinTime.Text.Trim()) * 60);
                mt.MaxTime = Convert.ToString(Convert.ToInt32(txtMaxTime.Text.Trim()) * 60);
                break;
            case "M":
                mt.MinTime = txtMinTime.Text.Trim();
                mt.MaxTime = txtMaxTime.Text.Trim();
                break;
            case "D":
                mt.MinTime = Convert.ToString(Convert.ToInt32(txtMinTime.Text.Trim()) * 1440);
                mt.MaxTime = Convert.ToString(Convert.ToInt32(txtMaxTime.Text.Trim()) * 1440);
                break;
            default:
                mt.MinTime = "0";
                mt.MaxTime = "0";
                break;
        }

        if (!txtDorder.Text.Trim().Equals(""))
            mt.Dorder = this.txtDorder.Text.Trim();
        else
            mt.Dorder = "0";
        mt.EnteredBy = Session["personid"].ToString();
        mt.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        mt.ClientID = Session["orgid"].ToString(); // org

        if (mt.Update())
        {
            Clear_Form();
            FillDG();

            lblErrMSg.ForeColor = System.Drawing.Color.Green;
            lblErrMSg.Text = "Record has been updated successfully";
        }
        else
        {
            lblErrMSg.ForeColor = System.Drawing.Color.Red;
            lblErrMSg.Text = mt.Error;
        }
    }

    private void FillDG()
    {
        clsMethod mt = new clsMethod();

        mt.SubDeptID = this.ddlSUBDept.SelectedItem.Value.ToString();
        DataView dv = mt.GetAll(1);

        if (dv.Count > 0)
        {
            gvMethod.DataSource = dv;
            gvMethod.DataBind();
        }
        else
        {
            gvMethod.DataSource = null;
            gvMethod.DataBind();
        }
    }
    private void FillDDlSub()
    {
        clsMethod mt = new clsMethod();        
        SComponents com = new SComponents();

        DataView dv = mt.GetAll(4);
        com.FillDropDownList(ddlSUBDept, dv, "name", "subdepartmentid");
    }
    private bool Form_Validate()
    {
        lblErrMSg.ForeColor = System.Drawing.Color.Red;

        if (ddlSUBDept.SelectedIndex <= 0)
        {
            lblErrMSg.Text = "Please select Sub-Department.";
            ddlSUBDept.Focus();
            return false;
        }
        if (txtMethod.Text.Trim().Equals(""))
        {
            lblErrMSg.Text = "Please enter method name.(empty is not allowed)";
            txtMethod.Focus();
            return false;
        }
        if (txtAcronym.Text.Trim().Equals(""))
        {
            lblErrMSg.Text = "Please enter acronym.(empty is not allowed)";
            txtAcronym.Focus();
            return false;
        }
        if (ddlTimeType.SelectedIndex <= 0)
        {
            lblErrMSg.Text = "Please select Time Type";
            ddlTimeType.Focus();
            return false;
        }
        if (txtMinTime.Text.Trim().Equals(""))
        {
            lblErrMSg.Text = "Please enter minimum time.(empty is not allowed)";
            txtMinTime.Focus();
            return false;
        }
        if (txtMaxTime.Text.Trim().Equals(""))
        {
            lblErrMSg.Text = "Please enter maximum time.(empty is not allowed)";
            return false;
        }
        if (ddlTimeType.SelectedItem.Value.ToString().Equals("M") && Convert.ToInt32(txtMinTime.Text.Trim()) > 59)
        {
            lblErrMSg.Text = "Please enter minimum time less than or equal to 59 minutes";
            txtMinTime.Focus();
            return false;
        }
        if (ddlTimeType.SelectedItem.Value.ToString().Equals("M") && Convert.ToInt32(txtMaxTime.Text.Trim()) > 59)
        {
            lblErrMSg.Text = "Please enter maximum time less than or equal to 59 minutes";
            txtMinTime.Focus();
            return false;
        }

        if (ddlTimeType.SelectedItem.Value.ToString().Equals("H") && Convert.ToInt32(txtMinTime.Text.Trim()) > 23)
        {
            lblErrMSg.Text = "Please enter minimum time less than or equal to 23 hours";
            txtMinTime.Focus();
            return false;
        }
        if (ddlTimeType.SelectedItem.Value.ToString().Equals("H") && Convert.ToInt32(txtMaxTime.Text.Trim()) > 23)
        {
            lblErrMSg.Text = "Please enter maximum time less than or equal to 23 hours";
            txtMinTime.Focus();
            return false;
        }

        return true;
    }

    protected void ddlSUBDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblErrMSg.Text = "";
        if (ddlSUBDept.SelectedIndex > 0)
        {
            FillDG();
        }
        else
        {
            gvMethod.DataSource = null;
            gvMethod.DataBind();
        }
    }
    protected void gvMethod_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblErrMSg.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            lblID.Text = gvMethod.DataKeys[index].Value.ToString();

            txtMethod.Text = gvMethod.Rows[index].Cells[1].Text.Trim();
            txtAcronym.Text = gvMethod.Rows[index].Cells[2].Text.Trim();
            txtDorder.Text = gvMethod.Rows[index].Cells[5].Text.Trim();

            chkActive.Checked = ((CheckBox)(gvMethod.Rows[index].Cells[6].FindControl("chkGVActive"))).Checked;
            chkDefault.Checked = gvMethod.DataKeys[index].Values[2].ToString().Equals("Y") ? true : false;
            try
            {
                ddlSUBDept.SelectedItem.Selected = false;
                ddlSUBDept.Items.FindByValue(gvMethod.DataKeys[index].Values[1].ToString()).Selected = true;
            }
            catch
            { }

            txtMinTime.Text = gvMethod.DataKeys[index].Values[3].ToString();
            txtMaxTime.Text = gvMethod.DataKeys[index].Values[4].ToString();
            try
            {
                ddlTimeType.SelectedItem.Selected = false;
                ddlTimeType.Items.FindByValue(gvMethod.DataKeys[index].Values[5].ToString()).Selected = true;
            }
            catch { }

            lblStatus.Text = "u";
        }
    }
}
