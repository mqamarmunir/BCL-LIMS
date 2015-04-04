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

public partial class SContainer : System.Web.UI.Page
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
                log.OptionId = "7";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    DGSort = "";
                    lblstatus.Text = "i";
                    lblSContainerId.Text = "";
                    FillSpecimenDDL();
                    if (!Session["SpecimenId"].Equals(""))
                    {
                        this.ddlSpecimen.SelectedValue = Session["SpecimenId"].ToString();
                    }
                    Fillgv();
                    this.Title = this.Session["PersonName"].ToString();
                    this.ddlSpecimen.Focus();
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

    private void FillSpecimenDDL()
    {
        clsSpecimenType objSpec = new clsSpecimenType();
        SComponents objScom = new SComponents();
        DataView dv = objSpec.GetAll(4);
        objScom.FillDropDownList(ddlSpecimen, dv, "Specimen_Name", "SpecimenId", true, false, true);
        this.ddlSpecimen.SelectedValue = "-1";
    } 

    private void Fillgv()
    {
        clsSContainer objSCont = new clsSContainer();
        if (!this.ddlSpecimen.SelectedItem.Value.ToString().Equals("-1"))
        {
            objSCont.SpecimenId = this.ddlSpecimen.SelectedItem.Value.ToString();
        }
        DataView dv = objSCont.GetAll(1);
        if (dv.Count > 0)
        {
            dv.Sort = DGSort;
            gvSContainer.DataSource = dv;
            gvSContainer.DataBind();
            gvSContainer.Visible = true;
        }
        else
        {
            gvSContainer.Visible = false;
        }
    }
    private void Insert()
    {
        clsSContainer objSCont = new clsSContainer();
        objSCont.Container_Name = txtContainer_Name.Text.Trim();
        objSCont.Acronym = txtAcronym.Text.Trim();
        objSCont.Description = txtDescription.Text.Trim();
        objSCont.Qty = txtQty.Text.Trim();        
        if (!this.ddlSpecimen.SelectedItem.Value.ToString().Equals("-1"))
        {
            objSCont.SpecimenId = this.ddlSpecimen.SelectedItem.Value.ToString();
        }

        objSCont.Active = chkActive.Checked ? "Y" : "N";
        objSCont.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objSCont.Enteredby = Session["PersonId"].ToString();
        objSCont.ClientId = Session["orgid"].ToString(); // org
        if (objSCont.Insert())
        {
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record save successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objSCont.ErrorMessage;
        }
    }

    private void Update()
    {       
        clsSContainer objSCont = new clsSContainer();
        objSCont.SContainerId = lblSContainerId.Text.Trim();
        objSCont.Container_Name = txtContainer_Name.Text.Trim();
        objSCont.Acronym = txtAcronym.Text.Trim();
        objSCont.Description = txtDescription.Text.Trim();
        objSCont.Qty = txtQty.Text.Trim();
        if (!this.ddlSpecimen.SelectedItem.Value.ToString().Equals("-1"))
        {
            objSCont.SpecimenId = this.ddlSpecimen.SelectedItem.Value.ToString();
        }

        objSCont.Active = chkActive.Checked ? "Y" : "N";
        objSCont.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objSCont.Enteredby = Session["PersonId"].ToString();
        objSCont.ClientId = Session["orgid"].ToString(); // org
        if (objSCont.Update())
        {
            Clear();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Update successfully";
            Fillgv();
        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objSCont.ErrorMessage;
        }
    }

    private void Clear()
    {
        txtContainer_Name.Text = "";
        txtAcronym.Text = "";
        txtDescription.Text = "";
        txtQty.Text = "";        
        this.ddlSpecimen.SelectedValue = "-1";        
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
        this.txtContainer_Name.Focus();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        lblSContainerId.Text = "";
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        if (!Session["SpecimenId"].Equals(""))
        {
            Response.Redirect("SpecimenType.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
    }
    protected void gvSContainer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSContainer.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvSContainer_RowEditing(object sender, GridViewEditEventArgs e)
    {        
        lblErrMsg.Text = "";
        lblstatus.Text = "u";
        clsSContainer objScont = new clsSContainer();
        lblSContainerId.Text = objScont.SContainerId = gvSContainer.DataKeys[e.NewEditIndex].Value.ToString();
        DataView dv = objScont.GetAll(3);
        if (dv.Count > 0)
        {
            this.txtContainer_Name.Text = dv[0]["Container_Name"].ToString();
            this.txtAcronym.Text = dv[0]["Acronym"].ToString();
            this.txtDescription.Text = dv[0]["Description"].ToString();
            this.txtQty.Text = dv[0]["Qty"].ToString();
            if (!dv[0]["SpecimenId"].ToString().Equals(""))
            {
                this.ddlSpecimen.SelectedValue = dv[0]["SpecimenId"].ToString();
            }

            this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
        }
    }
    protected void gvSContainer_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.Equals("NAME"))
        {
            if (DGSort == "Container_Name ASC")
                DGSort = "Container_Name DESC";
            else
                DGSort = "Container_Name ASC";

        }

        Fillgv();
    }
    protected void ddlSpecimen_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillgv();
    }

    protected void gvSContainer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblErrMsg.Text = "";
            lblstatus.Text = "u";
            clsSContainer objScont = new clsSContainer();
            lblSContainerId.Text = objScont.SContainerId = gvSContainer.DataKeys[index].Value.ToString();
            DataView dv = objScont.GetAll(3);
            if (dv.Count > 0)
            {
                this.txtContainer_Name.Text = dv[0]["Container_Name"].ToString();
                this.txtAcronym.Text = dv[0]["Acronym"].ToString();
                this.txtDescription.Text = dv[0]["Description"].ToString();
                this.txtQty.Text = dv[0]["Qty"].ToString();
                if (!dv[0]["SpecimenId"].ToString().Equals(""))
                {
                    this.ddlSpecimen.SelectedValue = dv[0]["SpecimenId"].ToString();
                }

                this.chkActive.Checked = (dv[0]["Active"].ToString().Equals("Y")) ? true : false;
            }
        }
    }
}
