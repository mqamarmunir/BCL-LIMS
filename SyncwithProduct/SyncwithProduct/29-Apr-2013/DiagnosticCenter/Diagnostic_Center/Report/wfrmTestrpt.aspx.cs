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
using CrystalDecisions.CrystalReports.Engine;

public partial class testrpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";      
        
        if (!Session.Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "32";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Fill_ddlDept();
                    Fill_Group();
                    if (Session["BranchID"].ToString().Trim() == "1")
                    {
                        FillgvBranch();
                    }
                    rdbOption.Items.FindByText("All").Selected = true;
                    rdbReport.Items.FindByText("Selective Report").Selected = true;
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
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void imgClear_Click(object sender, ImageClickEventArgs e)
    {
        ddlDept.SelectedIndex = -1;

        for (int i = ddlSub.Items.Count - 1; i >= 1; i--)
        {
            ddlSub.Items.RemoveAt(i);
        }
        ddlGroup.SelectedIndex = -1;
    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        //if (!Session["ReportDoc"].Equals(""))
        //{
        //    ReportDocument doc = (ReportDocument)Session["ReportDoc"];
        //    doc.Close();
        //    doc.Dispose();
        //    GC.Collect();
        //    Session["ReportDoc"] = "";
        //} 

        if (Session["BranchID"].ToString().Trim() != "1")
        {
            string sSelectionFormula = "1=1";
            if (rdbReport.SelectedItem.Value.ToString().Equals("Selective Report"))
            {
                string strSub = "";
                if (ddlSub.SelectedIndex > 0)
                    strSub = ddlSub.SelectedItem.Value.ToString();
                else
                    strSub = "-1";
                string subdepartmentids = "";
                foreach (GridViewRow row in gvSubDepartments.Rows)
                {
                    if (((CheckBox)gvSubDepartments.Rows[row.RowIndex].Cells[1].FindControl("gvchksub")).Checked == true)
                    {
                        subdepartmentids += gvSubDepartments.DataKeys[row.RowIndex].Value.ToString().Trim() + ",";
                    }
                }
                subdepartmentids += "15000";

                if (ddlDept.SelectedIndex > 0)
                    sSelectionFormula += " and {Command.departmentid}=" + ddlDept.SelectedItem.Value.ToString();
                //sSelectionFormula += " and {dc_tp_departments.departmentid}=" + ddlDept.SelectedItem.Value.ToString();
                if (/*ddlSub.SelectedIndex > 0 ||*/ subdepartmentids != "15000")
                    sSelectionFormula += " and {Command.subdepartmentid} in[" + subdepartmentids + "]"; 
                // sSelectionFormula += " and {dc_tp_subdepartments.subdepartmentid}=" + ddlSub.SelectedValue.ToString().Trim();
                //  sSelectionFormula += " and {dc_tp_subdepartments.subdepartmentid}=" + ddlSub.SelectedItem.Value.ToString();
                if (ddlGroup.SelectedIndex > 0)
                    sSelectionFormula += " and {Command.groupid}=" + ddlGroup.SelectedItem.Value.ToString();
                //sSelectionFormula += " and {dc_tp_test.groupid}=" + ddlGroup.SelectedItem.Value.ToString();
                if (!rdbOption.SelectedItem.Value.ToString().Equals("A"))
                    sSelectionFormula += " and {Command.external}='" + rdbOption.SelectedItem.Value.ToString() + "'";
                // sSelectionFormula += " and {dc_tp_test.external}='" + rdbOption.SelectedItem.Value.ToString() + "'";
                sSelectionFormula += " and {Command.BranchID}=" + Session["BranchID"].ToString().Trim();
                sSelectionFormula += " and {Command.active}='Y'";
                // sSelectionFormula += " and {dc_tp_test.active}='Y'";

                Session["reportname"] = "mastertest";
                Session["selectionformula"] = "";
                Session["selectionformula"] = sSelectionFormula;
                Session["Chargesvisible"] = "";
                Session["Chargesvisible"] = chkcharges.Checked == true ? "Y" : "N";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Report", "<script>window.open('GeneralReports.aspx');</script>", false);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Report", "<script>window.open('wfrmReportView.aspx?deptid=" + this.ddlDept.SelectedItem.Value.ToString() + " &subid=" + strSub + " &groupid=" + this.ddlGroup.SelectedItem.Value.ToString() + " &type=R &external=" + rdbOption.SelectedItem.Value.ToString() + " &reporttype=mastertest &report=masterTest');</script>", false);   
            }
            else
            {

                Session["reportname"] = "mastertest";
                Session["selectionformula"] = "";
                Session["selectionformula"] = sSelectionFormula;
                Session["Chargesvisible"] = "";
                Session["Chargesvisible"] = chkcharges.Checked == true ? "Y" : "N";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Report", "<script>window.open('GeneralReports.aspx');</script>", false);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Report", "<script>window.open('wfrmReportView.aspx?type=CM &reporttype=mastertest &report=masterTest');</script>", false); 
            }
        }
        else
        {
            string sSelectionFormula = "1=1";
            if (rdbReport.SelectedItem.Value.ToString().Equals("Selective Report"))
            {
                string strSub = "";
                if (ddlSub.SelectedIndex > 0)
                    strSub = ddlSub.SelectedItem.Value.ToString();
                else
                    strSub = "-1";

                string branchids = "";
                string subdepartmentids = "";
                foreach (GridViewRow row in gvbranches.Rows)
                {
                    if (((CheckBox)gvbranches.Rows[row.RowIndex].Cells[1].FindControl("gvchkbranch")).Checked == true)
                    {
                        branchids += gvbranches.DataKeys[row.RowIndex].Value.ToString().Trim() + ",";
                    }
                }
                branchids += "15000";

                foreach (GridViewRow row in gvSubDepartments.Rows)
                {
                    if (((CheckBox)gvSubDepartments.Rows[row.RowIndex].Cells[1].FindControl("gvchksub")).Checked == true)
                    {
                        subdepartmentids += gvSubDepartments.DataKeys[row.RowIndex].Value.ToString().Trim() + ",";
                    }
                }
                subdepartmentids += "15000";

                if (ddlDept.SelectedIndex > 0)
                    sSelectionFormula += " and {Command.departmentid}=" + ddlDept.SelectedItem.Value.ToString();
                //sSelectionFormula += " and {dc_tp_departments.departmentid}=" + ddlDept.SelectedItem.Value.ToString();
                if (/*ddlSub.SelectedIndex > 0 ||*/ subdepartmentids!="15000")
                    sSelectionFormula += " and {Command.subdepartmentid} in[" + subdepartmentids + "]"; 
                // sSelectionFormula += " and {dc_tp_subdepartments.subdepartmentid}=" + ddlSub.SelectedValue.ToString().Trim();
                //  sSelectionFormula += " and {dc_tp_subdepartments.subdepartmentid}=" + ddlSub.SelectedItem.Value.ToString();
                if (ddlGroup.SelectedIndex > 0)
                    sSelectionFormula += " and {Command.groupid}=" + ddlGroup.SelectedItem.Value.ToString();
                //sSelectionFormula += " and {dc_tp_test.groupid}=" + ddlGroup.SelectedItem.Value.ToString();
                if (!rdbOption.SelectedItem.Value.ToString().Equals("A"))
                    sSelectionFormula += " and {Command.external}='" + rdbOption.SelectedItem.Value.ToString() + "'";
                // sSelectionFormula += " and {dc_tp_test.external}='" + rdbOption.SelectedItem.Value.ToString() + "'";
                if (branchids != "15000")
                {
                    sSelectionFormula += " and {Command.branchid} in[" + branchids + "]";
                }
                sSelectionFormula += " and {Command.active}='Y'";
                // sSelectionFormula += " and {dc_tp_test.active}='Y'";

                Session["reportname"] = "mastertest";
                Session["selectionformula"] = "";
                Session["selectionformula"] = sSelectionFormula;
                Session["Chargesvisible"] = "";
                Session["Chargesvisible"] = chkcharges.Checked == true ? "Y" : "N";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Report", "<script>window.open('GeneralReports.aspx');</script>", false);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Report", "<script>window.open('wfrmReportView.aspx?deptid=" + this.ddlDept.SelectedItem.Value.ToString() + " &subid=" + strSub + " &groupid=" + this.ddlGroup.SelectedItem.Value.ToString() + " &type=R &external=" + rdbOption.SelectedItem.Value.ToString() + " &reporttype=mastertest &report=masterTest');</script>", false);   
            }
            else
            {

                Session["reportname"] = "mastertest";
                Session["selectionformula"] = "";
                Session["selectionformula"] = sSelectionFormula;
                Session["Chargesvisible"] = "";
                Session["Chargesvisible"] = chkcharges.Checked == true ? "Y" : "N";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Report", "<script>window.open('GeneralReports.aspx');</script>", false);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Test Report", "<script>window.open('wfrmReportView.aspx?type=CM &reporttype=mastertest &report=masterTest');</script>", false); 
            }
        }
        
    }

    private void Fill_ddlDept()
    {
        clsBLMain mn = new clsBLMain();
        SComponents com = new SComponents();

        DataView dv = mn.GetAll(2);
        com.FillDropDownList(ddlDept, dv, "name", "departmentid");
    }
    private void Fill_Subdepartment()
    {
        clsBLMain mn = new clsBLMain();
        SComponents com = new SComponents();

        mn.DepartmentID = this.ddlDept.SelectedItem.Value.ToString();
        
        DataView dv = mn.GetAll(3);
        if (dv.Count > 0)
        {
            com.FillDropDownList(ddlSub, dv, "name", "subdepartmentid");


            /////GridView///////////////
            divSubDepartments.Visible = true;
            gvSubDepartments.DataSource = dv;
            gvSubDepartments.DataBind();
        }
        else
        {
            divSubDepartments.Visible = false;
            gvSubDepartments.DataSource = "";
            gvSubDepartments.DataBind();
        }
        //////////////////////////
    }
    private void Fill_Group()
    {
        clsBLMain mn = new clsBLMain();
        SComponents com = new SComponents();

        DataView dv = mn.GetAll(4);
        com.FillDropDownList(ddlGroup, dv, "name", "groupid");
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedIndex > 0)
        {
            Fill_Subdepartment();
        }
        else
        {
            for (int i = ddlSub.Items.Count - 1; i >= 1; i--)
            {
                ddlSub.Items.RemoveAt(i);
            }
            divSubDepartments.Visible = false;
            gvSubDepartments.DataSource = "";
            gvSubDepartments.DataBind();
        }
    }
    protected void rdbReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbReport.SelectedItem.Value.ToString().Equals("Selective Report"))
        {
            ddlDept.Enabled = true;
            ddlSub.Enabled = true;
            ddlGroup.Enabled = true;
            if (Session["BranchID"].ToString().Trim() == "1")
            {
                FillgvBranch();
                divbranch.Visible = true;
            }
            else
            {
                divbranch.Visible = false;
            }
            rdbOption.Enabled = true;

           // divSubDepartments.Visible = true;
        }
        else
        {
            ddlDept.Enabled = false;
            ddlSub.Enabled = false;
            ddlGroup.Enabled = false;
            divbranch.Visible = false;
            rdbOption.Enabled = false;
            divSubDepartments.Visible = false;

            foreach (GridViewRow ro in gvbranches.Rows)
            {
                ((CheckBox)gvbranches.Rows[ro.RowIndex].Cells[1].FindControl("gvchkbranch")).Checked = false;
            }
            foreach (GridViewRow ro in gvSubDepartments.Rows)
            {
                ((CheckBox)gvSubDepartments.Rows[ro.RowIndex].Cells[1].FindControl("gvchksub")).Checked = false;
            }
        }
    }

    private void FillgvBranch()
    {
        clsBLBranch obj_br = new clsBLBranch();
        DataView dv_branches = obj_br.GetAll(3);
        if (dv_branches.Count > 0)
        {
            divbranch.Visible = true;
            gvbranches.DataSource = dv_branches;
            gvbranches.DataBind();
        }
        else
        {
            divbranch.Visible = false;
        }
    }

}
