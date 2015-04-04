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

public partial class paneltest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
           
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "24";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    FillOrd_ddl();
                    lblStatus.Text = "i";
                    FillDepartment();
                    //FillPanelDDL();
                    FillGroupDDL();

                    rdbTest.Checked = true;
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
       
        CLear();
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {        
        if (!Validate_Form())
            return;
        if (rdbTest.Checked)
            Insert();
        else
            Insert_group();
    }

    private void CLear()
    {
        lblStatus.Text = "i";
        lblID.Text = "";
        //txtRate.Text = "";
        //txturgent.Text = "";

        gvPanelTest.DataSource = null;
        gvPanelTest.DataBind();

        gvPanelGroup.DataSource = null;
        gvPanelGroup.DataBind();

        ddlPanel.SelectedIndex = -1;

        for (int i = ddlClass.Items.Count - 1; i >= 1; i--)
        {
            ddlClass.Items.RemoveAt(i);
        }

        ddlDepartment.SelectedIndex = -1;

        for (int m = ddlSubDept.Items.Count - 1; m >= 1; m--)
        {
            ddlSubDept.Items.RemoveAt(m);
        }

        for (int j = ddlGroup.Items.Count - 1; j >= 1; j--)
        {
            ddlGroup.Items.RemoveAt(j);
        }

        for (int k = ddlTest.Items.Count - 1; k >= 1; k--)
        {
            ddlTest.Items.RemoveAt(k);
        }
    }
    private void Refresh_Form()
    {
        lblStatus.Text = "i";
        lblID.Text = "";
        //txtRate.Text = "";
        //txturgent.Text = "";
    }
    private bool Validate_Form()
    {
        lblError.ForeColor = System.Drawing.Color.Red;

        if (ddlOrganization.SelectedIndex <= 0)
        {
            lblError.Text = "Please select organization first";
            ddlOrganization.Focus();
            return false;
        }
        if (ddlPanel.SelectedIndex <= 0)
        {
            lblError.Text = "Please Select Panel first";
            ddlPanel.Focus();
            return false;
        }
        //if (ddlClass.SelectedIndex <= 0)
        //{
        //    lblError.Text = "Please Select Class first";
        //    ddlClass.Focus();
        //    return false;
        //}
        //if (ddlDepartment.SelectedIndex <= 0)
        //{
        //    lblError.Text = "Please Select Department first";
        //    ddlDepartment.Focus();
        //    return false;
        //}
        //if (ddlSubDept.SelectedIndex <= 0)
        //{
        //    lblError.Text = "Please select subdepartment first";
        //    ddlSubDept.Focus();
        //    return false;
        //}
        //if (ddlGroup.SelectedIndex <= 0)
        //{
        //    lblError.Text = "Please Select Group first";
        //    ddlGroup.Focus();
        //    return false;
        //}
        //if (ddlTest.SelectedIndex <= 0)
        //{
        //    lblError.Text = "Please Select Test first";
        //    ddlTest.Focus();
        //    return false;
        //}
        
       
        return true;
    }

    private void FillDepartment()
    {
        clsBLPanelClass pc = new clsBLPanelClass();
        SComponents com = new SComponents();
        
        DataView dv = pc.GetAll(13);
        com.FillDropDownList(ddlDepartment, dv, "name", "departmentid");

    }
    private void FillSubDepartDDL()
    {
        clsBLPanelClass pc = new clsBLPanelClass();
        SComponents com = new SComponents();

        pc.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
        DataView dv = pc.GetAll(4);
        com.FillDropDownList(ddlSubDept, dv, "name", "subdepartmentid");
    }

    private void FillGroupDDL()
    {
        clsBLPanelClass pc = new clsBLPanelClass();
        SComponents com = new SComponents();

       // pc.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
      //  pc.SubDepartID = this.ddlSubDept.SelectedItem.Value.ToString().Replace("-1","");
        DataView dv = pc.GetAll(5);
        com.FillDropDownList(ddlGroup,dv,"name","groupid");
    }
    private void FillTestDDL()
    {
        clsBLPanelClass pc = new clsBLPanelClass();
        SComponents com = new SComponents();

        pc.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
        pc.SubDepartID = this.ddlSubDept.SelectedItem.Value.ToString().Replace("-1","");
        pc.GroupID = this.ddlGroup.SelectedItem.Value.ToString().Replace("-1","");

        DataView dv = pc.GetAll(6);
        com.FillDropDownList(ddlTest, dv, "test_name", "testid");
    }

    private void FillOrd_ddl()
    {
        SComponents com = new SComponents();
        clsBLPanelClass pn = new clsBLPanelClass();
        DataView dv = pn.GetAll(17);

        com.FillDropDownList(ddlOrganization, dv, "name", "orgid");
    }
    private void FillPanelDDL()
    {
        clsBLPanelClass pc = new clsBLPanelClass();
        SComponents com = new SComponents();
        pc.ClientID = this.ddlOrganization.SelectedItem.Value.ToString();
        DataView dv = pc.GetAll(2);
        com.FillDropDownList(ddlPanel, dv, "name", "panelid");
    }
    private void FillCLassDDL()
    {
        clsBLPanelClass pc = new clsBLPanelClass();
        SComponents com = new SComponents();

        pc.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        DataView dv = pc.GetAll(8);
        com.FillDropDownList(ddlClass, dv, "name", "classid");
    }

    private void Insert()
    {
        clsBLPanelClass pc = new clsBLPanelClass();

        pc.OldTestID = this.lblID.Text.Trim().Replace("&nbsp;","");

        pc.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        //pc.ClassID = this.ddlClass.SelectedItem.Value.ToString();

       //pc.TestID = this.ddlTest.SelectedItem.Value.ToString();       

        pc.EnteredBy = this.Session["personid"].ToString();
        pc.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pc.ClientID = this.ddlOrganization.SelectedItem.Value.ToString();

        int count = 0;
        int delCount = 0;

        for (int i = 0; i < gvPanelTest.Rows.Count; i++)
        {
            string rate = ((TextBox)(gvPanelTest.Rows[i].Cells[5].FindControl("txtRate"))).Text.Trim();
            string urg_rate = ((TextBox)(gvPanelTest.Rows[i].Cells[7].FindControl("txturgent"))).Text.Trim();

            if (rate != "")
            {
                count++;
            }
            else
            {
                delCount++;
            }
        }

        string[,] str = new string[count, 6];
        string[,] str_Del = new string[delCount, 1];
        count=0;
        delCount = 0;

        for (int i = 0; i < gvPanelTest.Rows.Count; i++)
        {
            string rate = ((TextBox)(gvPanelTest.Rows[i].Cells[5].FindControl("txtRate"))).Text.Trim();
            string urg_rate = ((TextBox)(gvPanelTest.Rows[i].Cells[7].FindControl("txturgent"))).Text.Trim();

            if (rate != "")
            {
                str[count, 0] = gvPanelTest.DataKeys[i].Values[1].ToString();
                str[count, 1] = rate.Equals("") ? "0" : rate;
                str[count, 2] = urg_rate.Equals("") ? "0" : urg_rate;
                str[count, 3] = (gvPanelTest.Rows[i].Cells[8].FindControl("txtdiscpercent") as TextBox).Text.Trim().Equals("") ? "0" : (gvPanelTest.Rows[i].Cells[8].FindControl("txtdiscpercent") as TextBox).Text.Trim();
                str[count, 4] = (gvPanelTest.Rows[i].Cells[9].FindControl("txtPanelTestCode") as TextBox).Text.Trim().Equals("") ? "~!@" : (gvPanelTest.Rows[i].Cells[9].FindControl("txtPanelTestCode") as TextBox).Text.Trim();
                str[count, 5] = (gvPanelTest.Rows[i].Cells[10].FindControl("IndtxtPanelPage") as TextBox).Text.Trim().Equals("") ? "~!@" : (gvPanelTest.Rows[i].Cells[10].FindControl("IndtxtPanelPage") as TextBox).Text.Trim();
                count++;
            }
            else
            {
                str_Del[delCount, 0] = gvPanelTest.DataKeys[i].Values[1].ToString();
                delCount++;
            }
        }

        //if (count <= 0)
        
        //{
        //    lblError.ForeColor = System.Drawing.Color.Red;
        //    lblError.Text = "No test charges found.please enter test charges";
        //    return;
        //}

            if (pc.Insert_PanelTest(str,str_Del))
            {
                Refresh_Form();
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Record has been saved successfully";

                FillGV_Test();
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = pc.Error;
            }
    }
    private void Insert_group()
    {
        clsBLPanelClass pc = new clsBLPanelClass();

        pc.OldTestID = this.lblID.Text.Trim().Replace("&nbsp;", "");

        pc.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        //pc.ClassID = this.ddlClass.SelectedItem.Value.ToString();

        //pc.TestID = this.ddlTest.SelectedItem.Value.ToString();       

        pc.EnteredBy = this.Session["personid"].ToString();
        pc.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        pc.ClientID = this.ddlOrganization.SelectedItem.Value.ToString();

        int count = 0;
        int delCount = 0;

        for (int i = 0; i < gvPanelGroup.Rows.Count; i++)
        {
            string rate = ((TextBox)(gvPanelGroup.Rows[i].Cells[5].FindControl("txtPnlCharges"))).Text.Trim();
           
            if (rate != "")
            {
                count++;
            }
            else
            {
                delCount++;
            }
        }

        string[,] str = new string[count, 3];
        string[,] str_Del = new string[delCount, 2];
        count = 0;
        delCount = 0;

        for (int i = 0; i < gvPanelGroup.Rows.Count; i++)
        {
            string rate = ((TextBox)(gvPanelGroup.Rows[i].Cells[5].FindControl("txtPnlCharges"))).Text.Trim();
           

            if (rate != "")
            {
                str[count, 0] = gvPanelGroup.DataKeys[i].Values[1].ToString();
                str[count, 1] = rate.Equals("") ? "0" : rate;
                str[count, 2] = gvPanelGroup.DataKeys[i].Value.ToString();
                count++;
            }
            else
            {
                str_Del[delCount, 0] = gvPanelGroup.DataKeys[i].Values[1].ToString();
                str_Del[delCount, 1] = gvPanelGroup.DataKeys[i].Value.ToString();
                delCount++;
            }
        }

        //if (count <= 0)

        //{
        //    lblError.ForeColor = System.Drawing.Color.Red;
        //    lblError.Text = "No test charges found.please enter test charges";
        //    return;
        //}

        if (pc.Insert_PanelGroup(str, str_Del))
        {
            Refresh_Form();
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";

            FillGV_Group();
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = pc.Error;
        }
    }
    private void FillGV_Test()
    {
        clsBLPanelClass pc = new clsBLPanelClass();

        pc.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        if(ddlDepartment.SelectedIndex>0)
            pc.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();

        if (ddlSubDept.SelectedIndex > 0)
            pc.SubDepartID = this.ddlSubDept.SelectedItem.Value.ToString();
        if (ddlGroup.SelectedIndex > 0)
            pc.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
       // pc.ClassID = this.ddlClass.SelectedItem.Value.ToString();

        DataView dv = pc.GetAll(10); // with panelID
        DataView dvTest = new DataView();


        //if (dv.Count > 0)
        //{
            gvPanelTest.DataSource = dv;
            gvPanelTest.DataBind();
        //}       
            //if (ddlDepartment.SelectedIndex > 0)
            //{

            //dvTest = pc.GetAll(14); // without panelID
            //if (dvTest.Count > 0)
            //{
            //    gvPanelTest.DataSource = dvTest;
            //    gvPanelTest.DataBind();
            //}

            for (int i = 0; i < dv.Count; i++)
            {
                for (int j = 0; j < gvPanelTest.Rows.Count; j++)
                {
                    if (gvPanelTest.DataKeys[j].Values[1].ToString() == dv[i]["testid"].ToString())
                    {
                        ((TextBox)(gvPanelTest.Rows[j].Cells[5].FindControl("txtRate"))).Text = dv[i]["rate"].ToString();
                        ((TextBox)(gvPanelTest.Rows[j].Cells[7].FindControl("txturgent"))).Text = dv[i]["urgentrate"].ToString();
                        ((TextBox)(gvPanelTest.Rows[j].Cells[7].FindControl("txtdiscpercent"))).Text = dv[i]["percentdiscount"].ToString();
                        ((TextBox)(gvPanelTest.Rows[j].Cells[7].FindControl("txtPanelTestCode"))).Text = dv[i]["PanelTestCode"].ToString();
                    }
                }
            }            
    }
    private void FillGV_Group()
    {
        clsBLPanelClass pc = new clsBLPanelClass();
        if (ddlGroup.SelectedIndex > 0)
            pc.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
        pc.PanelID = this.ddlPanel.SelectedItem.Value.ToString();

        DataView dv = pc.GetAll(15); // with panelid
        DataView dvGrp = pc.GetAll(16);

        gvPanelGroup.DataSource = dvGrp;
        gvPanelGroup.DataBind();

        for (int i = 0; i < dv.Count; i++)
        {
            for (int j = 0; j < gvPanelGroup.Rows.Count; j++)
            {
                if (gvPanelGroup.DataKeys[j].Values[1].ToString() == dv[i]["testid"].ToString() && gvPanelGroup.DataKeys[j].Value.ToString() == dv[i]["groupid"].ToString())
                {
                    ((TextBox)(gvPanelGroup.Rows[j].Cells[5].FindControl("txtPnlCharges"))).Text = dv[i]["panel_charges"].ToString();                    
                }
            }
        }  
    }

    protected void ddlPanel_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        lblError.Text = "";

        if (ddlPanel.SelectedIndex > 0)
        {
            if (rdbTest.Checked)
                FillGV_Test();
            else
                FillGV_Group();
        }
        else
        {
            gvPanelTest.DataSource = null;
            gvPanelTest.DataBind();

            gvPanelGroup.DataSource = null;
            gvPanelGroup.DataBind();
        }

        //else
        //{
        //    for (int i = ddlClass.Items.Count - 1; i >= 1; i--)
        //    {
        //        ddlClass.Items.RemoveAt(i);
        //    }
        //}
    }
    protected void ddlSubDept_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        lblError.Text = "";
        if (rdbTest.Checked)
        {
            if (ddlSubDept.SelectedIndex > 0)
            {
                FillGroupDDL();
                lblPrice.Text = "";
                FillGV_Test();
            }
            else
                FillGV_Test();
        }
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        lblError.Text = "";
        if (rdbTest.Checked)
        {
            if (ddlGroup.SelectedIndex > 0)
            {
                //  FillTestDDL();
                lblPrice.Text = "";
                FillGV_Test();
            }
            else
                FillGV_Test();
        }
        else
            FillGV_Group();
        
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTest.SelectedIndex > 0)
        {
            clsBLPanelClass pc = new clsBLPanelClass();
                      
            pc.TestID = this.ddlTest.SelectedItem.Value.ToString();
            DataView dv = pc.GetAll(9);

            if (dv.Count > 0)
                lblPrice.Text = "Test Charges = " + dv[0]["charges"].ToString();
            else
                lblPrice.Text = "Test Charges = 0";
        }
        else
        {
            lblPrice.Text = "";
        }
             
    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedIndex > 0)
            FillGV_Test();
        else
        {
            gvPanelTest.DataSource = null;
            gvPanelTest.DataBind();
        }
    }
   
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (ddlDepartment.SelectedIndex > 0)
        {
            FillSubDepartDDL();
            FillGroupDDL();
            //FillTestDDL();
            FillGV_Test();
            lblPrice.Text = "";
        }
        else
        {
            for (int i = ddlSubDept.Items.Count - 1; i >= 1; i--)
            {
                ddlSubDept.Items.RemoveAt(i);
            }
            for (int i = ddlGroup.Items.Count - 1; i >= 1; i--)
            {
                ddlGroup.Items.RemoveAt(i);
            }
            for (int i = ddlTest.Items.Count - 1; i >= 1; i--)
            {
                ddlTest.Items.RemoveAt(i);
            }
            lblPrice.Text = "";
            FillGV_Test();
        }
    }
    protected void gvPanelTest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
             e.Row.Attributes.Add("onclick", "this.style.backgroundColor  = 'pink';");
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlPanel.SelectedIndex <= 0)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please select panel first";
            return;
        }
        clsBLMain mn = new clsBLMain();
        mn.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
        DataView dv = mn.GetAll(12);
        if (dv.Count > 0)
        {
                       
            string sSelectionFormula = "{dc_tpanel_test.panelid} = " + ddlPanel.SelectedItem.Value.ToString() + " and {dc_tp_test.active}='Y'";
            Session["selectionformula"] = sSelectionFormula;
            Session["reportname"] = "paneltest";

            Response.Write("<script language='javascript'>window.open('../Report/GeneralReports.aspx')</script>");
            //Response.Write("<script language='javascript'>window.open('../Report/wfrmReportView.aspx?panelid=" + ddlPanel.SelectedItem.Value.ToString() + " &type=P &reporttype=paneltest &report=Paneltest')</script>");
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "No Record Found....";
        }
    }

    protected void btnProgress_Click(object sender, EventArgs e)
    {
        if (txtDiscount.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please enter discount percentage');</script>", false);
            return;
        }
        if (Convert.ToInt32(txtDiscount.Text.Trim()) > 100)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please enter discount percentage less than 100');</script>", false);
            return;
        }
        int price = 0;
        if (rdbTest.Checked)
        {
            for (int i = 0; i < gvPanelTest.Rows.Count; i++)
            {
                price = Convert.ToInt32(gvPanelTest.Rows[i].Cells[4].Text.Trim());
                price = price - (price * Convert.ToInt32(txtDiscount.Text.Trim()) / 100);

                ((TextBox)(gvPanelTest.Rows[i].Cells[5].FindControl("txtRate"))).Text = price.ToString();
            }
        }
        if (rdbGroup.Checked)
        {
            for (int i = 0; i < gvPanelGroup.Rows.Count; i++)
            {
                price = Convert.ToInt32(gvPanelGroup.Rows[i].Cells[3].Text.Trim());
                price = price - (price * Convert.ToInt32(txtDiscount.Text.Trim()) / 100);

                ((TextBox)(gvPanelGroup.Rows[i].Cells[5].FindControl("txtPnlCharges"))).Text = price.ToString();
            }
        }
    }
    protected void rdbTest_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlPanel.SelectedIndex > 0)
        {           
                FillGV_Test();
                gvPanelGroup.DataSource = null;
                gvPanelGroup.DataBind();           
        }
        else
        {
            gvPanelGroup.DataSource = null;
            gvPanelGroup.DataBind();

            gvPanelTest.DataSource = null;
            gvPanelTest.DataBind();

        }
    }
    protected void rdbGroup_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlPanel.SelectedIndex > 0)
        {
            FillGV_Group();
            gvPanelTest.DataSource = null;
            gvPanelTest.DataBind();

        }
        else
        {
            gvPanelGroup.DataSource = null;
            gvPanelGroup.DataBind();

            gvPanelTest.DataSource = null;
            gvPanelTest.DataBind();

        }
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPanelDDL();
        gvPanelGroup.DataSource = null;
        gvPanelGroup.DataBind();

        gvPanelTest.DataSource = null;
        gvPanelTest.DataBind();
    }
    protected void gvPanelTest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
