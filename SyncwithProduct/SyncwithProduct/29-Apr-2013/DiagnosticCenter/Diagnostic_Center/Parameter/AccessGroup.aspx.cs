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

public partial class AccessGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!IsPostBack)
        {
            if (!Session["personid"].ToString().Equals(""))
            {
               clsLogin log = new clsLogin();
                log.OptionId = "26";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    this.rbListType.Visible = false;
                    this.btnAdd.Visible = false;
                    this.btnSave2.Visible = false;
                    this.btnClose2.Visible = false;
                    this.dgAccessOptions.Visible = false;
                    this.dgAllAccessOptions.Visible = false;
                    FillDG();
                    this.txtGroupName.Focus();
                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
                
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        RefreshForm();
    }

    private void RefreshForm()
    {
        try
        {
            this.lblSapsId.Text = "";
            this.txtGroupName.Text = "";
            this.txtDescription.Text = "";
            this.chkActive.Checked = true;
            this.lblSave.Text = "i";
            this.lblAccessMode.Text = "Access";
            this.lblErrMsg.Text = "";
            this.rbListType.Visible = false;
            this.btnAdd.Visible = false;
            this.btnSave2.Visible = false;
            this.btnClose2.Visible = false;
            this.dgAccessOptions.Visible = false;
            this.dgAllAccessOptions.Visible = false;
            FillDG();
            this.txtGroupName.Focus();
        }
        catch { }
    }

    private void FilldgAllAccessOptions()
    {
        this.lblAccessMode.Text = "AllAccess";
        this.dgAccessOptions.Visible = false;
        this.dgAllAccessOptions.Visible = true;
        clsGroupOption objSAPS = new clsGroupOption();
        objSAPS.GroupId = this.lblSapsId.Text.ToString();
        objSAPS.Type = this.rbListType.SelectedItem.Value.ToString();
        DataView dv = objSAPS.GetAll(4);
        if (dv.Count > 0)
        {
            this.lblSave.Text = "UpdateOpp";
            FilldgEditOptions();
        }
        else
        {
            this.lblSave.Text = "AddOpp";
            FilldgAddOptions();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        FilldgAllAccessOptions();
    }

    protected void btnSave2_Click(object sender, EventArgs e)
    {
        SaveOptions();
        FillAccessOptions();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lblSave.Text.Equals("i"))
            Insert();
        else
            Update();
    }

    private void Insert()
    {

        clsAccessGroup objSAPS = new clsAccessGroup();

        objSAPS.GroupName = txtGroupName.Text.Trim();
        objSAPS.Description = txtDescription.Text.Trim();
        objSAPS.Active = this.chkActive.Checked ? "Y" : "N";
        objSAPS.Enteredby = Session["personid"].ToString();
        objSAPS.Enteredon = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        if (objSAPS.Insert())
        {
            RefreshForm();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Saved Successfully.";
        }

        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objSAPS.ErrorMessage;
        }

    }

    private void Update()
    {
        clsAccessGroup objSAPS = new clsAccessGroup();
        objSAPS.GroupId = lblSapsId.Text;

        objSAPS.GroupName = txtGroupName.Text.Trim();
        objSAPS.Description = txtDescription.Text.Trim();
        objSAPS.Active = this.chkActive.Checked ? "Y" : "N";
        objSAPS.Enteredby = Session["personid"].ToString();
        objSAPS.Enteredon = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        if (objSAPS.Update())
        {
            RefreshForm();
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Record Updated Successfully.";
        }

        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = objSAPS.ErrorMessage;
        }
    }

    private void FillDG()
    {
        clsAccessGroup objSAPS = new clsAccessGroup();
        this.dg.DataSource = objSAPS.GetAll(1);
        this.dg.DataBind();

    }
    protected void dg_RowEditing(object sender, GridViewEditEventArgs e)
    {

        lblSave.Text = "u";
        this.txtGroupName.Focus();
        clsAccessGroup objSAPS = new clsAccessGroup();
        lblSapsId.Text = objSAPS.GroupId = this.dg.DataKeys[e.NewEditIndex][0].ToString();

        DataView dv = objSAPS.GetAll(3);

        if (dv.Count > 0)
        {
            this.txtGroupName.Text = dv[0]["GroupName"].ToString();
            this.txtDescription.Text = dv[0]["Description"].ToString();
            this.chkActive.Checked = dv[0]["Active"].ToString().Equals("Y") ? true : false;
        }

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
   //     Session["MemberId"] = this.lblMemberId.Text.ToString();
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void btnClose2_Click(object sender, EventArgs e)
    {
        this.rbListType.Visible = false;
        this.btnAdd.Visible = false;
        this.btnSave2.Visible = false;
        this.btnClose2.Visible = false;
        this.dgAccessOptions.Visible = false;
        this.dgAllAccessOptions.Visible = false;
    }
    protected void dg_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSave.Text = "u";
        this.btnAdd.Focus();
        clsAccessGroup objSAPS = new clsAccessGroup();
        lblSapsId.Text = objSAPS.GroupId = this.dg.SelectedDataKey[0].ToString();
        DataView dv = objSAPS.GetAll(3);

        if (dv.Count > 0)
        {
            this.txtGroupName.Text = dv[0]["GroupName"].ToString();
            this.txtDescription.Text = dv[0]["Description"].ToString();
            this.chkActive.Checked = dv[0]["Active"].ToString().Equals("Y") ? true : false;
        }
        FillAccessOptions();
    }

    private void FillAccessOptions()
    {
        this.rbListType.Visible = true;
        this.btnAdd.Visible = true;
        this.btnSave2.Visible = true;
        this.btnClose2.Visible = true;
        this.dgAccessOptions.Visible = true;
        this.dgAllAccessOptions.Visible = false;
        this.lblAccessMode.Text = "Access";
        FilldgAccessOptions();
    }

    private void FilldgAccessOptions()
    {
        clsGroupOption objSAPS = new clsGroupOption();
        objSAPS.GroupId = this.lblSapsId.Text.ToString();
        objSAPS.Type = this.rbListType.SelectedItem.Value.ToString();
        this.dgAccessOptions.DataSource = objSAPS.GetAll(1);
        this.dgAccessOptions.DataBind();
        //DataView dv = objSAPS.GetAll(1);
        //if (dv.Count > 0)
        //{
        //    this.dgAccessOptions.DataSource = dv;
        //    this.dgAccessOptions.DataBind();
        //}
        //else
        //{
        //    this.dgAccessOptions.Visible = false;
        //}
    }

    private void FilldgAddOptions()
    {
        clsGroupOption objSAPS = new clsGroupOption();
        objSAPS.Type = this.rbListType.SelectedItem.Value.ToString();
        this.dgAllAccessOptions.DataSource = objSAPS.GetAll(3);
        this.dgAllAccessOptions.DataBind();
        //DataView dv = objSAPS.GetAll(3);
        //if (dv.Count > 0)
        //{
        //    this.dgAllAccessOptions.DataSource = dv;
        //    this.dgAllAccessOptions.DataBind();
        //}
        //else
        //{
        //    this.dgAllAccessOptions.Visible = false;
        //}
    }

    private void FilldgEditOptions()
    {
        clsGroupOption objSAPS = new clsGroupOption();
        objSAPS.GroupId = this.lblSapsId.Text.ToString();
        objSAPS.Type = this.rbListType.SelectedItem.Value.ToString();
        DataView dv = objSAPS.GetAll(3);
        if (dv.Count > 0)
        {
            this.dgAllAccessOptions.DataSource = dv;
            this.dgAllAccessOptions.DataBind();
            DataView dv2 = objSAPS.GetAll(1);
            if (dv2.Count > 0)
            {
                string Opp_Id1 = "";
                string Opp_Id2 = "";
                for (int i = 0; i < dgAllAccessOptions.Rows.Count; i++)
                {
                    Opp_Id1 = this.dgAllAccessOptions.DataKeys[i].Value.ToString();
                    for (int j = 0; j < dv2.Count; j++)
                    {
                        Opp_Id2 = dv2.Table.Rows[j]["OptionId"].ToString();
                        if (Opp_Id1 == Opp_Id2)
                        {
                            ((CheckBox)this.dgAllAccessOptions.Rows[i].Cells[1].FindControl("chkActive")).Checked = true;
                        }
                    }

                }
            }
        }
        else
        {
            this.dgAllAccessOptions.DataSource = dv;
            this.dgAllAccessOptions.DataBind();
        }
    }

    private void SaveOptions()
    {
        bool isSuccessful = true;
        string OppActive = "";
        clsGroupOption objSAPS = new clsGroupOption();
        objSAPS.GroupId = this.lblSapsId.Text.ToString();
        objSAPS.Type = this.rbListType.SelectedItem.Value.ToString();
        objSAPS.Enteredby = Session["personid"].ToString();
        objSAPS.Enteredon = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        if (dgAllAccessOptions.Rows.Count > 0)
        {
            if (this.lblSave.Text.ToString().Equals("AddOpp"))
            {
                for (int i = 0; i < dgAllAccessOptions.Rows.Count; i++)
                {
                    OppActive = (((CheckBox)this.dgAllAccessOptions.Rows[i].Cells[1].FindControl("chkActive")).Checked == true) ? "Y" : "N";
                    if (OppActive == "Y")
                    {
                        objSAPS.OptionId = this.dgAllAccessOptions.DataKeys[i].Value.ToString();

                        isSuccessful = objSAPS.Insert();
                    }
                }

                if (!isSuccessful)
                {
                    this.lblErrMsg.Text = "<br>" + objSAPS.ErrorMessage + "<br><br>";
                }
                else
                {
                    this.lblErrMsg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";

                }
            }
            else
            {
                isSuccessful = objSAPS.Delete();
                for (int i = 0; i < dgAllAccessOptions.Rows.Count; i++)
                {
                    OppActive = (((CheckBox)this.dgAllAccessOptions.Rows[i].Cells[1].FindControl("chkActive")).Checked == true) ? "Y" : "N";
                    if (OppActive == "Y")
                    {
                        objSAPS.OptionId = this.dgAllAccessOptions.DataKeys[i].Value.ToString();

                        isSuccessful = objSAPS.Insert();
                    }
                }

                if (!isSuccessful)
                {
                    this.lblErrMsg.Text = "<br>" + objSAPS.ErrorMessage + "<br><br>";
                }
                else
                {
                    this.lblErrMsg.Text = "<br><font color='Green'>Record has been Updates successfully.</font><br><br>";

                }

            }
        }
        else
        {
            this.lblErrMsg.Text = "<br><font color='Red'>No Records to Add or Update</font><br><br>";
        }
    }

    protected void rbListType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.lblAccessMode.Text.ToString().Equals("Access"))
        {
            FilldgAccessOptions();
        }
        else if (this.lblAccessMode.Text.ToString().Equals("AllAccess"))
        {
            FilldgAllAccessOptions();
        }
        else
        {
            FilldgAccessOptions();
        }
    }
       
}
