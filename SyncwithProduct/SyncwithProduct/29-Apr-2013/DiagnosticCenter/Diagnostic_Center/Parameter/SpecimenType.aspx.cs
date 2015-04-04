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

public partial class SpecimenType : System.Web.UI.Page
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
                log.OptionId = "6";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtSpecimen_Name.Focus();
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblSpecimenId.Text = "";
                    if (!Session["SpecimenId"].Equals(""))
                    {
                        this.ddlType.SelectedValue = "-1";
                        lblErrMsg.Text = "";
                        lblstatus.Text = "u";
                        clsSpecimenType objSpec = new clsSpecimenType();
                        lblSpecimenId.Text = objSpec.SpecimenId = Session["SpecimenId"].ToString();
                        DataView dv = objSpec.GetAll(3);
                        if (dv.Count > 0)
                        {
                            this.txtSpecimen_Name.Text = dv[0]["Specimen_Name"].ToString();
                            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                            if (!dv[0]["Type"].ToString().Equals(""))
                            {
                                this.ddlType.SelectedValue = dv[0]["Type"].ToString();
                            }
                            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
                        }
                    }
                    Session["SpecimenId"] = "";
                    Fillgv();
                    this.Title = this.Session["PersonName"].ToString();

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
        clsSpecimenType objSpec = new clsSpecimenType();
        if (!this.ddlType.SelectedItem.Value.ToString().Equals("-1"))
        {
            objSpec.Type = this.ddlType.SelectedItem.Value.ToString();
        }
        DataView dv = objSpec.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvSpecimenType.DataSource = dv;
            gvSpecimenType.DataBind();
            gvSpecimenType.Visible = true;
        }
        else
        {
            gvSpecimenType.Visible = false;
        }
    }

    private void Insert()
    {
        clsSpecimenType objSpec = new clsSpecimenType();
        objSpec.Specimen_Name = txtSpecimen_Name.Text.Trim();
        objSpec.Acronym = txtAcronym.Text.Trim();
        if (!this.ddlType.SelectedItem.Value.ToString().Equals("-1"))
        {
            objSpec.Type = this.ddlType.SelectedItem.Value.ToString();
        }
        objSpec.Active = chkActive.Checked ? "Y" : "N";
        objSpec.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objSpec.Enteredby = Session["PersonId"].ToString();
        objSpec.ClientId = Session["orgid"].ToString(); // org

        if (objSpec.Insert())
        {
            lblSpecimenId.Text = objSpec.SpecimenId.ToString();
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record save successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objSpec.ErrorMessage;
        }
    }

    private void Update()
    {        
        clsSpecimenType objSpec = new clsSpecimenType();
        objSpec.SpecimenId = lblSpecimenId.Text.Trim();
        objSpec.Specimen_Name = txtSpecimen_Name.Text.Trim();
        objSpec.Acronym = txtAcronym.Text.Trim();
        if (!this.ddlType.SelectedItem.Value.ToString().Equals("-1"))
        {
            objSpec.Type = this.ddlType.SelectedItem.Value.ToString();
        }
        else
        {
            objSpec.Type = "";
        }
        objSpec.Active = chkActive.Checked ? "Y" : "N";
        objSpec.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objSpec.Enteredby = Session["PersonId"].ToString();
        objSpec.ClientId = Session["orgid"].ToString(); // org
        if (objSpec.Update())
        {
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Update successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objSpec.ErrorMessage;
        }
    }

    private void Clear()
    {
        txtSpecimen_Name.Text = "";
        txtAcronym.Text = "";
        this.ddlType.SelectedValue = "-1";
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
        this.txtSpecimen_Name.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblSpecimenId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }
    protected void gvSpecimenType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSpecimenType.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvSpecimenType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddlType.SelectedValue = "-1";
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsSpecimenType objSpec = new clsSpecimenType();
        lblSpecimenId.Text = objSpec.SpecimenId = gvSpecimenType.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objSpec.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtSpecimen_Name.Text = dv[0]["Specimen_Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            if (!dv[0]["Type"].ToString().Equals(""))
            {
                this.ddlType.SelectedValue = dv[0]["Type"].ToString();
            }
            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
        }
    }
    protected void gvSpecimenType_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("NAME"))
        {
            if (DGSort == "Specimen_Name ASC")
                DGSort = "Specimen_Name DESC";
            else
                DGSort = "Specimen_Name ASC";

        }

        Fillgv();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
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
            Session["SpecimenId"] = lblSpecimenId.Text.Trim();
            Response.Redirect("SContainer.aspx");
        }
    }

    protected void gvSpecimenType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            this.ddlType.SelectedValue = "-1";
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsSpecimenType objSpec = new clsSpecimenType();
            lblSpecimenId.Text = objSpec.SpecimenId = gvSpecimenType.DataKeys[index].Value.ToString();
            DataView dv = objSpec.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtSpecimen_Name.Text = dv[0]["Specimen_Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                if (!dv[0]["Type"].ToString().Equals(""))
                {
                    this.ddlType.SelectedValue = dv[0]["Type"].ToString();
                }
                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            }
        }
    }
}
