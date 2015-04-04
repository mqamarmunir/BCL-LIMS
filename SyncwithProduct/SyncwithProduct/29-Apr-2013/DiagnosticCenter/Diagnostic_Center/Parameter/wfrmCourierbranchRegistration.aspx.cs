using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

public partial class _Default : System.Web.UI.Page
{
    protected static string mode = "";
    protected static string ID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "65";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillGV();
                    FillDDLCity();
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

    private void FillDDLCity()
    {
        clsBLBranch obj_br = new clsBLBranch();
        DataView dv_cities = obj_br.GetAll(6);
        if (dv_cities.Count > 0)
        {
            SComponents obj_Com = new SComponents();
            obj_Com.FillDropDownList(ddlCity, dv_cities, "Name", "CityID", true, false, true);
            obj_Com = null;
            dv_cities.Dispose();
        }
    }
    private void FillGV()
    {
        clsBLCourierbranch obj_CService = new clsBLCourierbranch();
        obj_CService.BranchID = Session["BranchID"].ToString().Trim();
        DataView dv_cs = obj_CService.GetAll(1);
        if (dv_cs.Count > 0)
        {
            gvCourierBranches.DataSource = dv_cs;
            gvCourierBranches.DataBind();
        }
        else
        {
            gvCourierBranches.DataSource = "";
            gvCourierBranches.DataBind();
        }


    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "Update")
        {
            Update();
        }
        else
        {
            Insert();
        }
    }

    private void Insert()
    {
        clsBLCourierbranch obj_CService = new clsBLCourierbranch();
        obj_CService.Name = txtName.Text.Trim();
        obj_CService.City = ddlCity.SelectedItem.Text.Trim();
        obj_CService.Address = txtAddress.Text;
        obj_CService.Active = chkActive.Checked == true ? "Y" : "N";
        obj_CService.Phone = txtPhone1.Text;
        obj_CService.Phone2 = txtPhone2.Text;
        obj_CService.Mobile = txtMobi.Text;
        obj_CService.Fax = txtFax.Text;
        obj_CService.Email = txtEmail.Text;

        obj_CService.Enteredby = Session["PersonId"].ToString().Trim();
        obj_CService.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_CService.BranchID = Session["BranchID"].ToString().Trim();
        obj_CService.ClientId = Session["orgid"].ToString().Trim();
        if (obj_CService.Insert())
        {
            obj_CService = null;
            FillGV();
            RefreshForm();
            lblError.Text = "<font color='green'>Record inserted Successfully.<font>";
        }
        else
        {
            obj_CService = null;
            RefreshForm();
            lblError.Text = obj_CService.ErrorMessage;
        }



    }

    private void Update()
    {
        clsBLCourierbranch obj_CService = new clsBLCourierbranch();
        obj_CService.CourierServiceId = ID;
        obj_CService.Name = txtName.Text.Trim();
        obj_CService.City = ddlCity.SelectedItem.Text.Trim();
        obj_CService.Address = txtAddress.Text;
        obj_CService.Active = chkActive.Checked == true ? "Y" : "N";
        obj_CService.Phone = txtPhone1.Text;
        obj_CService.Phone2 = txtPhone2.Text;
        obj_CService.Mobile = txtMobi.Text;
        obj_CService.Fax = txtFax.Text;
        obj_CService.Email = txtEmail.Text;

        obj_CService.Enteredby = Session["PersonId"].ToString().Trim();
        obj_CService.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_CService.BranchID = Session["BranchID"].ToString().Trim();
        obj_CService.ClientId = Session["orgid"].ToString().Trim();
        if (obj_CService.Update())
        {
            obj_CService = null;
            FillGV();
            RefreshForm();
            lblError.Text = "<font color='green'>Record Updated Successfully.<font>";
        }
        else
        {
            obj_CService = null;
            RefreshForm();
            lblError.Text = obj_CService.ErrorMessage;
        }

    }
    private void RefreshForm()
    {
        mode = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtFax.Text = "";
        txtMobi.Text = "";
        txtName.Text = "";
        txtPhone1.Text = "";
        txtPhone2.Text = "";
        ddlCity.ClearSelection();
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        RefreshForm();
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MainPage.aspx");
    }

    protected void gvCourierBranches_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ID = gvCourierBranches.DataKeys[index].Value.ToString();
            mode = "Update";
            FillForm();


        }
    }
    private void FillForm()
    {
        clsBLCourierbranch obj_CService = new clsBLCourierbranch();
        obj_CService.BranchID = Session["BranchID"].ToString().Trim();
        obj_CService.CourierServiceId = ID;
        DataView dv_cs = obj_CService.GetAll(3);
        if(dv_cs.Count>0)
        {
            txtName.Text = dv_cs[0]["Name"].ToString().Trim();
            txtAddress.Text = dv_cs[0]["Address"].ToString().Trim();
            txtPhone1.Text = dv_cs[0]["Phone"].ToString().Trim();
            txtPhone2.Text = dv_cs[0]["Phone2"].ToString().Trim();
            txtFax.Text = dv_cs[0]["Fax"].ToString().Trim();
            txtMobi.Text = dv_cs[0]["mobile"].ToString().Trim();
            txtEmail.Text = dv_cs[0]["Email"].ToString().Trim();
            chkActive.Checked = dv_cs[0]["Active"].ToString().Trim() == "Y" ? true : false;

            ddlCity.ClearSelection();
            try
            {
                ddlCity.Items.FindByText(dv_cs[0]["City"].ToString().Trim()).Selected = true;
            }
            catch { }

 
        }
    }
}