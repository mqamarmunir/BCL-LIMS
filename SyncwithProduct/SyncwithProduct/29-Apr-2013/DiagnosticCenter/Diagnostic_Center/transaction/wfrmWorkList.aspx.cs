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

public partial class worklist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "36";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Session["dtsearch"] = "";
                    Fill_NewList();
                    Fill_PreviousList();
                    Fill_SubDept();                                      
                }
                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowed.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../Parameter/MainPage.aspx");
        }
    }

    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }     

    protected void gvPreviousList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Work List", "<script>window.open('../Report/wfrmReportView.aspx?type=wl &worklistno=" + gvPreviousList.Rows[index].Cells[1].Text.Trim() + "');</script>", false); 
           // Response.Write("<script language='javascript'>window.open('../Report/wfrmReportView.aspx?type=wl &worklistno="+gvPreviousList.Rows[index].Cells[1].Text.Trim()+"')</script>");
        }
    }

    private void Fill_NewList()
    {
        clsBLWorkList wl = new clsBLWorkList();
        //wl.SubDeptID = this.ddlSubdept.SelectedItem.Value.Trim();
        wl.PlaceID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();

        wl.BranchID = Session["BranchID"].ToString().Trim();
            //Session["default_route"].ToString();
            
        DataView dv = wl.GetAll(5); //2
        gvQueueList.DataSource = dv;
        gvQueueList.DataBind();

        //lblNoFRec.Text = "New Work List Record Found (<b> "+dv.Count+"</b> )";
    }
    private void Fill_PreviousList()
    {
        clsBLWorkList wl = new clsBLWorkList();
        wl.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        wl.BranchID = Session["BranchID"].ToString().Trim();
       DataView dv = wl.GetAll(3);
       gvPreviousList.DataSource = dv;
       gvPreviousList.DataBind();
       Session["dtsearch"] = dv.Table;
       
    }
    private void Fill_SubDept()
    {
        clsBLWorkList wl = new clsBLWorkList();
        SComponents com = new SComponents();
        DataView dv = wl.GetAll(1);

        com.FillDropDownList(ddlSubDept, dv, "name", "subdepartmentid");
    }
      
    protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        Fill_NewList();
        Fill_PreviousList();
    }
    protected void gvQueueList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);

            clsBLWorkList wl = new clsBLWorkList();
            wl.SubDeptID = gvQueueList.DataKeys[index].Value.ToString();
            wl.PlaceID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
            wl.BranchID = Session["BranchID"].ToString().Trim();
            DataView dvNew = wl.GetAll(2);// before branch catering it was 2
            gvNewList.DataSource = dvNew;
            gvNewList.DataBind();

            gvNewList.Visible = false;

            wl.EnteredBY = Session["personid"].ToString();
            wl.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            wl.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
            wl.BranchID = Session["BranchID"].ToString().Trim();

            string[,] str = new string[gvNewList.Rows.Count, 5];
            int count = 0;

            for (int i = 0; i < gvNewList.Rows.Count; i++)
            {
                str[count, 0] = gvNewList.DataKeys[i].Value.ToString();//test id
                str[count, 1] = gvNewList.DataKeys[i].Values[1].ToString();//bookingid
                str[count, 2] = gvNewList.DataKeys[i].Values[2].ToString(); // bookingDID
                str[count, 3] = gvNewList.Rows[i].Cells[1].Text.Trim();//labid

                clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
                iv.TestID = gvNewList.DataKeys[i].Value.ToString();
                DataView dv = iv.GetAll(25);
                if (dv.Count == 0)
                    str[count, 4] = null;
                else
                {
                    for (int m = 0; m < dv.Count; m++)
                    {
                        if (dv[m]["processid"].ToString().Trim().Equals("5") || dv[m]["processid"].ToString().Trim().Equals("6"))
                        {
                            str[count, 4] = dv[m]["processid"].ToString().Trim();
                            break;
                        }
                    }
                }
                count++;
            }


            if (wl.Insert(str))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Work list generated successfully');</script>", false);

                Fill_NewList();
                Fill_PreviousList();
                gvNewList.DataSource = null;
                gvNewList.DataBind();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Worklist", "<script>window.open('../Report/wfrmReportView.aspx?type=wl &worklistno=" + wl.WorkListNo + "');</script>", false);
                //  Response.Write("<script language='javascript'>window.open('../Report/wfrmReportView.aspx?type=wl &worklistno=" + wl.WorkListNo + "')</script>");
            }
            else
            {                
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Worklist", wl.Error, false);
            }
        }
    }

    protected void gvPreviousList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPreviousList.PageIndex = e.NewPageIndex;
        Fill_PreviousList();
    }
    protected void ddlSubDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        dt = (DataTable)Session["dtsearch"];

        DataView dv = new DataView(dt);
        if (ddlSubDept.SelectedIndex > 0)
            dv.RowFilter = "subdeptid=" + ddlSubDept.SelectedItem.Value.ToString();

        gvPreviousList.DataSource = dv;
        gvPreviousList.DataBind();
    }
}
