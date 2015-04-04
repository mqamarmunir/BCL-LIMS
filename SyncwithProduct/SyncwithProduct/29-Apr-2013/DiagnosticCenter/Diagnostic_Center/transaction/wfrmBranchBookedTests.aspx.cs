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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                hdrun.Value = "200";
                clsLogin log = new clsLogin();
                log.OptionId = "64";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                   
                   
                    txtfrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtTO.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                   // Fill_GV_Pending();
                    Fill_GV_Branches();
                    Fill_GV_Sent();
                    Fill_GV_Courierinfo();
                }

                else
                {
                    Response.Redirect("../Parameter/wfrmNotAllowedCashier.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("NewLogin.aspx");
        }
    }

    private void Fill_GV_Branches()
    {
        if (Session["BranchID"].ToString().Trim() != "")
        {
            clsBLbookedTests obj_bTests = new clsBLbookedTests();
            obj_bTests.BranchID = Session["BranchID"].ToString().Trim();
            obj_bTests.From = txtfrom.Text.Trim().Substring(6, 4) + "/" + txtfrom.Text.Trim().Substring(3, 2) + "/" + txtfrom.Text.Trim().Substring(0, 2);
            obj_bTests.To = txtTO.Text.Trim().Substring(6, 4) + "/" + txtTO.Text.Trim().Substring(3, 2) + "/" + txtTO.Text.Trim().Substring(0, 2);

            DataView dv_branches = obj_bTests.GetAll(2);
            obj_bTests = null;
            if (dv_branches.Count > 0)
            {
                gvBranches.DataSource = dv_branches;
                gvBranches.DataBind();
                dv_branches.Dispose();
            }
            else
            {
                dv_branches.Dispose();
                gvBranches.DataSource = "";
                gvBranches.DataBind();
                //t.Visible = false;
            }
        }
    }

    protected void Fill_GV_Sent()
    {
        if (Session["BranchID"].ToString().Trim() != "")
        {
            clsBLbookedTests obj_bTests = new clsBLbookedTests();
            obj_bTests.BranchID = Session["BranchID"].ToString().Trim();
            obj_bTests.From = txtfrom.Text.Trim().Substring(6, 4) + "/" + txtfrom.Text.Trim().Substring(3, 2) + "/" + txtfrom.Text.Trim().Substring(0, 2);
            obj_bTests.To = txtTO.Text.Trim().Substring(6, 4) + "/" + txtTO.Text.Trim().Substring(3, 2) + "/" + txtTO.Text.Trim().Substring(0, 2);

            DataView dv_branches = obj_bTests.GetAll(4);
            obj_bTests = null;
            if (dv_branches.Count > 0)
            {
                gvSent.DataSource = dv_branches;
                gvSent.DataBind();
                dv_branches.Dispose();
            }
            else
            {
                dv_branches.Dispose();
                gvSent.DataSource = "";
                gvSent.DataBind();
            }
        }
    }
    private void Fill_GV_Pending(int index,string brid)
    {
        if (Session["BranchID"].ToString().Trim() != "")
        {
            GridView gv_Tests = (GridView)gvBranches.Rows[index].Cells[2].FindControl("gvTests");
            
            clsBLbookedTests obj_bTests = new clsBLbookedTests();
            
            obj_bTests.BranchID = Session["BranchID"].ToString().Trim();
            obj_bTests.From = txtfrom.Text.Trim().Substring(6, 4) + "/" + txtfrom.Text.Trim().Substring(3, 2) + "/" + txtfrom.Text.Trim().Substring(0, 2);
            obj_bTests.To = txtTO.Text.Trim().Substring(6, 4) + "/" + txtTO.Text.Trim().Substring(3, 2) + "/" + txtTO.Text.Trim().Substring(0, 2);

            DataView dv_brTests = obj_bTests.GetAll(1);
            obj_bTests = null;
            
            if (dv_brTests.Count > 0)
            {
                gv_Tests.DataSource = dv_brTests;
                gv_Tests.DataBind();
                dv_brTests.Dispose();
            }
            else
            {
                dv_brTests.Dispose();
                gv_Tests.DataSource = "";
                gv_Tests.DataBind();
            }
        }
    }

    private void Fill_GV_Courierinfo()
    {
        clsBLbookedTests obj_btests = new clsBLbookedTests();
        obj_btests.BranchID = Session["BranchID"].ToString().Trim();
        obj_btests.From = txtfrom.Text.Trim().Substring(6, 4) + "/" + txtfrom.Text.Trim().Substring(3, 2) + "/" + txtfrom.Text.Trim().Substring(0, 2);
        obj_btests.To = txtTO.Text.Trim().Substring(6, 4) + "/" + txtTO.Text.Trim().Substring(3, 2) + "/" + txtTO.Text.Trim().Substring(0, 2);

        
        DataView dv_courierinfo = obj_btests.GetAll(7);
        if (dv_courierinfo.Count > 0)
        {
            gvCourierinfo.DataSource = dv_courierinfo;
            gvCourierinfo.DataBind();
        }
        else
        {
            gvCourierinfo.DataSource = "";
            gvCourierinfo.DataBind();
        }
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        //Fill_GV_Pending();
        Fill_GV_Branches();
        Fill_GV_Sent();
    }
    
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("NewLogin.aspx");
    }
    protected void gvBranches_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        Control container = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gvTests = (GridView)container.FindControl("gvTests");
            clsBLbookedTests obj_bTests = new clsBLbookedTests();
            obj_bTests.DestinationBranchid = gvBranches.DataKeys[e.Row.RowIndex].Value.ToString().Trim();
            obj_bTests.BranchID = Session["BranchID"].ToString().Trim();
            DataView dv_tests = obj_bTests.GetAll(1);
            obj_bTests = null;
            if (dv_tests.Count > 0)
            {
                
                gvTests.DataSource = dv_tests;
                gvTests.DataBind();
                dv_tests.Dispose();
            }

            DropDownList ddlcourier = (DropDownList)container.FindControl("ddlCourierServices");
            clsBLCourierbranch objcourier = new clsBLCourierbranch();
            objcourier.BranchID = Session["BranchID"].ToString().Trim();
            DataView dv_courier = objcourier.GetAll(2);
            objcourier = null;
            if (dv_courier.Count > 0)
            {
                SComponents objcomp = new SComponents();
                objcomp.FillDropDownList(ddlcourier, dv_courier, "Name", "CourierServiceID", true, false, true);
                objcomp = null;
                dv_courier.Dispose();
                ddlcourier.SelectedValue = "-1";
            }
           
            //string DestbranchId = gvBranches.DataKeys[e.Row.RowIndex].Value.ToString();
            //Fill_GV_Pending(e.Row.RowIndex, DestbranchId);
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        GridView gvTests=null;
        int count = 0;
        int count_checked = 0;
        string batch_no="";
        //string find = ((Button)sender).Parent.Parent.Parent.Parent.Parent.Parent.Parent.UniqueID.ToString();
        clsBLCourierbatches obj_batches = new clsBLCourierbatches();


        GridViewRow gvRow = ((Button)sender).Parent.Parent.Parent.Parent.Parent as GridViewRow;
        obj_batches.BranchID = Session["BranchID"].ToString().Trim();
        obj_batches.DestinationBranchID = gvBranches.DataKeys[gvRow.RowIndex].Value.ToString();
        DataView dv_batchnocount = obj_batches.GetAll(1);
        string batch_count = dv_batchnocount[0]["MaxID"].ToString();
        batch_no=Session["BranchID"].ToString().Trim() + "-" + batch_count + "-" + gvBranches.DataKeys[gvRow.RowIndex].Value.ToString().Trim() + "-" + System.DateTime.Now.ToString("MM/yy");
        obj_batches.Batchno = Session["BranchID"].ToString().Trim() + "-" + batch_count + "-" + gvBranches.DataKeys[gvRow.RowIndex].Value.ToString().Trim() + "-" + System.DateTime.Now.ToString("MM/yy");

        gvTests = gvBranches.Rows[gvRow.RowIndex].Cells[1].FindControl("gvtests") as GridView;
        if (dv_batchnocount.Count > 0)
        {
            foreach (GridViewRow row in gvTests.Rows)
            {
                if (((CheckBox)gvTests.Rows[row.RowIndex].Cells[7].FindControl("gvChkSelect")).Checked == true)
                {
                    count_checked++;

                    obj_batches.labid = gvTests.Rows[row.RowIndex].Cells[1].Text.Trim();
                    obj_batches.TestID = gvTests.DataKeys[row.RowIndex].Values[0].ToString();
                    obj_batches.PRID = gvTests.DataKeys[row.RowIndex].Values[1].ToString().Trim();
                    obj_batches.Status = "Q";

                    // obj_batches.CourierServiceID = (gvBranches.Rows[gvRow.RowIndex].Cells[1].FindControl("ddlCourierServices") as DropDownList).SelectedValue.ToString().Trim();
                    //obj_batches.Recieptnumber = (gvBranches.Rows[gvRow.RowIndex].Cells[1].FindControl("txtreciept") as TextBox).Text.Trim();
                    obj_batches.Enteredby = Session["personid"].ToString().Trim();
                    obj_batches.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_batches.ClientId = Session["clientid"].ToString().Trim();// Session["orgid"].ToString().Trim();
                    obj_batches.BranchID = Session["BranchID"].ToString().Trim();
                    obj_batches.DestinationBranchID = gvBranches.DataKeys[gvRow.RowIndex].Value.ToString();

                    //   if (dv_batchnocount.Count > 0)
                    //    {
                    
                    if (obj_batches.Insert())
                    {
                        obj_batches.Sendstatus = "S";
                        if (obj_batches.updatebookingstatus())
                        {
                            count++;
                        }
                        else
                        {
                            lblchech.Text += obj_batches.ErrorMessage + "<br />";
                        }
                    }
                    //   }
                }

            }
        }
        if (count == count_checked)
        {
            Fill_GV_Branches();
            Fill_GV_Sent();
            Fill_GV_Courierinfo();
            lblchech.Text = count.ToString() + " Tests sent and status changed";
            Response.Write("<script language='javascript'>window.open('wfrmBatchprint.aspx?batchno="+batch_no+"','channelmode');</script>");
            //Response.Write("<script language='javascript'>window.open('~/transaction/wfrmBatchprint.aspx?batchno=" + batch_no + ",'scrollmode');</script>");
        }// lblchech.Text = gvRow.RowIndex.ToString();
    }
    protected void gvSent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (gvSent.DataKeys[e.Row.RowIndex].Values[1].ToString().Trim()=="R")
            {
                e.Row.BackColor = System.Drawing.Color.Green ;
 
            }
            else if (gvSent.DataKeys[e.Row.RowIndex].Values[1].ToString().Trim() == "S")
            {
                e.Row.BackColor = System.Drawing.Color.BurlyWood;
            }

            if (gvSent.DataKeys[e.Row.RowIndex].Values[2].ToString().Trim() == "5" && gvSent.DataKeys[e.Row.RowIndex].Values[1].ToString().Trim() == "R")
            {
                e.Row.BackColor = System.Drawing.Color.AntiqueWhite;

            }
            else if (gvSent.DataKeys[e.Row.RowIndex].Values[2].ToString().Trim() == "6")
            {
                e.Row.BackColor = System.Drawing.Color.Aqua;

            }
            else if (gvSent.DataKeys[e.Row.RowIndex].Values[2].ToString().Trim() == "7")
            {
                e.Row.BackColor = System.Drawing.Color.Aquamarine;

            }
            else if (gvSent.DataKeys[e.Row.RowIndex].Values[2].ToString().Trim() == "8")
            {
                e.Row.BackColor = System.Drawing.Color.BlueViolet;

            }


        }
    }

    protected void gvCourierinfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            clsBLCourierbatches obj_batch = new clsBLCourierbatches();
            obj_batch.Batchno = gvCourierinfo.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.Trim();
            obj_batch.Status = "S";
            if (((DropDownList)gvCourierinfo.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].FindControl("ddlCourierServices")).SelectedValue.ToString().Trim() != "-1" && (((TextBox)gvCourierinfo.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].FindControl("gvtxtreciept")).Text.Trim() != "" && ((TextBox)gvCourierinfo.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].FindControl("gvtxtreciept")).Text.Trim() != "&nbsp;"))
            {
                obj_batch.CourierServiceID = ((DropDownList)gvCourierinfo.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].FindControl("ddlCourierServices")).SelectedValue.ToString().Trim();
                obj_batch.Recieptnumber = ((TextBox)gvCourierinfo.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].FindControl("gvtxtreciept")).Text.Trim();
                if (obj_batch.updaterecieptinfo())
                {
                    Fill_GV_Courierinfo();
                    Fill_GV_Sent();
                    lblchech.Text = "<font color='green'>Reciept number saved Successfully.</font>";
                }
                else
                {
                    lblchech.Text = obj_batch.ErrorMessage;
                }
            }
            else
            {
                lblchech.Text = "<font color='red'>Select Service and Enter Valid Reciept number.</font>";
            }
        }
    }
    protected void gvCourierinfo_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        Control container = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlCourierServices = (DropDownList)container.FindControl("ddlCourierServices");
            clsBLCourierbranch objcourier = new clsBLCourierbranch();
            objcourier.BranchID = Session["BranchID"].ToString().Trim();
            DataView dv_courier = objcourier.GetAll(2);
            objcourier = null;
            if (dv_courier.Count > 0)
            {
                SComponents objcomp = new SComponents();
                objcomp.FillDropDownList(ddlCourierServices, dv_courier, "Name", "CourierServiceID", true, false, true);
                objcomp = null;
                dv_courier.Dispose();
                ddlCourierServices.SelectedValue = "-1";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Write("<script language='javascript'>window.open('wfrmBatchprint.aspx?batchno=3-1-2-09/12','channelmode');</script>");
    }
}