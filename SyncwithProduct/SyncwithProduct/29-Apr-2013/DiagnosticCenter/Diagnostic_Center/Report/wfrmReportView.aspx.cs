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

public partial class Report_wfrm : System.Web.UI.Page
{
    string PreviousSub = "";
    int firstRow = -1; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            lblOrgName.Text = System.Configuration.ConfigurationManager.AppSettings["clientName"].ToString().Trim();
            if (Request.QueryString["type"].ToString().Trim() == "R")
                FillGV();
            else if (Request.QueryString["type"].ToString().Trim() == "CM")
                FillGV_AllTest();
            else if (Request.QueryString["type"].ToString().Trim() == "P")
                Show_PanelTest();
            else if (Request.QueryString["type"].Trim() == "wl")
                Show_WorkList();
            else if (Request.QueryString["type"].Trim() == "mc")
                Branch_Sumary();
            else
                Show_CashClose();
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }

    private void FillGV()
    {
        clsBLMain mn = new clsBLMain();

        if (!Request.QueryString["deptid"].Trim().Equals("-1"))
            mn.DepartmentID = Request.QueryString["Deptid"].ToString();
        if (!Request.QueryString["subid"].Trim().Equals("-1"))
            mn.SubDepartmentID = Request.QueryString["subid"].ToString();
        if (!Request.QueryString["groupid"].Trim().Equals("-1"))
            mn.GroupID = Request.QueryString["groupid"].ToString();
        mn.Active = "Y";
        mn.External = Request.QueryString["external"].ToString().Replace("A","N");
        if (!Request.QueryString["external"].ToString().Equals("Y"))
        {
            DataView dv = mn.GetAll(1);
            gvTestList.DataSource = dv;
            gvTestList.DataBind();
            lblCount.Text = "Total Test (<b> " + dv.Count + "</b> )";

        }
        DataView dvMain = mn.GetAll(9);
        DataView dvExt = mn.GetAll(10);

        
        if (!Request.QueryString["external"].ToString().Equals("N"))
        {
            gvExternal.DataSource = dvExt;
            gvExternal.DataBind();
            lblExternal.Text = "External Test ( <b>" +dvExt.Count.ToString()+"</b> ) ";
        }
        if (dvMain.Count > 0)
        {
            lblAddress.Text = dvMain[0]["name"].ToString();
            lblTel.Text = "Phone No: " + dvMain[0]["phoneno"].ToString();
        }

       
        lblPrintOn.Text = "Print On: " + System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");

        pnlSumary.Visible = false;
        lblMas_Test_H.Text = "Master Test List";
    }
    private void FillGV_AllTest()
    {
        clsBLMain mn = new clsBLMain();

        mn.Active = "Y";

        DataView dv = mn.GetAll(1);
        gvTestList.DataSource = dv;
        gvTestList.DataBind();
        lblCount.Text = "Total Tests (<b> " + dv.Count + "</b> )";


        DataView dvMain = mn.GetAll(9);

        if (dvMain.Count > 0)
        {
            lblAddress.Text = dvMain[0]["name"].ToString();
            lblTel.Text = "Phone No: " + dvMain[0]["phoneno"].ToString();
        }

        lblPrintOn.Text = "Print On: " + System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");

        pnlSumary.Visible = false;

    }
    private void Show_CashClose()
    {
        clsBLMain mn = new clsBLMain();

        mn.ReportNo = Request.QueryString["reportno"].ToString();

        DataView dv = mn.GetAll(5);
        DataView dvRef = mn.GetAll(6);

        gvCashClose.DataSource = dv;
        gvCashClose.DataBind();

        gvRefund.DataSource = dvRef;
        gvRefund.DataBind();

        lblCount.Text = "Report #: (<b> " + mn.ReportNo + "</b> )";
        if (dv.Count > 0)
            lblCash.Text = dv[0]["totalcash"].ToString();
        else
            lblCash.Text = "0";
        if (dvRef.Count > 0)
            lblrefAmt.Text = dvRef[0]["totalrefund"].ToString();
        else
            lblrefAmt.Text = "0";

        lblBalance.Text = Convert.ToString(Convert.ToInt32(lblCash.Text.Trim()) - Convert.ToInt32(lblrefAmt.Text.Trim()));

        lblrefAmt.Text = "Total Refund: " + lblrefAmt.Text.Trim();
        lblCash.Text = "Total Received: " + lblCash.Text.Trim();

        lblBalance.Text = "Balance: " + lblBalance.Text.Trim();
        lblAddress.Text = dv[0]["orgname"].ToString();
        lblTel.Text = "Phone No: " + dv[0]["phoneno"].ToString();

        lblPrintOn.Text ="Print On: "+ System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");
        lblGenratedOn.Text ="Generated On: "+ dv[0]["generatedon"].ToString();
        pnlSumary.Visible = true;
        lblMas_Test_H.Text =Session["personname"].ToString() +" :Cash Report";
    }

    private void Show_PanelTest()
    {
        clsBLMain mn = new clsBLMain();
        mn.PanelID = Request.QueryString["panelid"].ToString();

        DataView dv = mn.GetAll(12);

        gvPanelTest.DataSource = dv;
        gvPanelTest.DataBind();

        
            lblAddress.Text = "<b>" + dv[0]["name"].ToString() + "</b>";
            lblAddress.Text += " <br>" + dv[0]["address"].ToString();
            lblMas_Test_H.Text = "Panel Test List";
            lblCount.Text = "";
      

        pnlSumary.Visible = false;

    }
    private void Show_WorkList()
    {
        clsBLWorkList wl = new clsBLWorkList();

        wl.WorkListNo = Request.QueryString["worklistno"].Trim();

        DataView dv = wl.GetAll(4);
        gvWorkList.DataSource = dv;
        gvWorkList.DataBind();

        lblMas_Test_H.Text = "Work List No: "+dv[0]["worklistno"].ToString();
        lblPrintOn.Text = "<b>Printed On: </b>"+System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");
        lblGenratedOn.Text ="<b>Genrated On: </b>"+ dv[0]["enteredon"].ToString();

        lblCount.Text = "Total Record Found(<b> "+dv.Count.ToString()+" </b>)";
        pnlSumary.Visible = false;
    }
    private void Branch_Sumary()
    {
        clsBLMain mn = new clsBLMain();
        mn.BranchID = Request.QueryString["orgid"].Trim();
        mn.FromDate = Request.QueryString["date"].Trim();
        DataView dv = mn.GetAll(13);

        DataView dvRef = mn.GetAll(14);

        DataView dvTotalser = mn.GetAll(18);

        gv_MC_rec.DataSource = dv;
        gv_MC_rec.DataBind();

        gv_MC_ref.DataSource = dvRef;
        gv_MC_ref.DataBind();

        lblrefAmt.Text = "Total Refund: " + Request.QueryString["refund"].Trim();
        lblCash.Text = "Total Received: " + Request.QueryString["rec"].Trim();

        lblBalance.Text = "Balance: " + Request.QueryString["bal"].Trim();
        pnlSumary.Visible = true;
        lblCount.Text = "";
        lblMas_Test_H.Text = "Detail: ";
        lblPrintOn.Text = "Print On: " + System.DateTime.Now.ToString("dd/MM/yy hh:mm tt");

        if (dvTotalser.Count > 0)
        {
            lblTotalSales.Text ="Total Sales: "+ dvTotalser[0]["totalservices"].ToString();
            lblCashDue.Text ="Cash Due: "+ dvTotalser[0]["cashdue"].ToString();
            lblPanelDue.Text ="Panel Due: "+ dvTotalser[0]["paneldue"].ToString();
        }
    }

    protected void gv_MC_rec_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gv = (GridView)e.Row.FindControl("gvModels");

            //AccessDataSource asd = new AccessDataSource(@"App_Data\SkinSample.mdb", "SELECT carmodel_name,carmodel_engine,carmodel_color FROM carmodel WHERE carmaker_id=" + ((DataRowView)e.Row.DataItem)["carmaker_id"].ToString());
            clsBLMain mn = new clsBLMain();
            mn.BookingID = ((DataRowView)e.Row.DataItem)["bookingid"].ToString();
            DataView dv = mn.GetAll(15);

            gv.DataSource = dv;//asd
            gv.AutoGenerateColumns = false;
            BoundField bfModelName = new BoundField();
            bfModelName.DataField = "test_name";        
            
            BoundField bfEngine = new BoundField();
            bfEngine.DataField = "testamount";           
            
            
            gv.Columns.Add(bfModelName);
            gv.Columns.Add(bfEngine);
           

            gv.DataBind();
            gv.Columns[0].ItemStyle.Width = Unit.Percentage(70);
            gv.Columns[1].ItemStyle.Width = Unit.Percentage(10);
           
                        
        }
    }
    protected void gv_MC_ref_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gv = (GridView)e.Row.FindControl("gvTest");

            //AccessDataSource asd = new AccessDataSource(@"App_Data\SkinSample.mdb", "SELECT carmodel_name,carmodel_engine,carmodel_color FROM carmodel WHERE carmaker_id=" + ((DataRowView)e.Row.DataItem)["carmaker_id"].ToString());
            clsBLMain mn = new clsBLMain();
            mn.BookingID = ((DataRowView)e.Row.DataItem)["bookingid"].ToString();
            mn.RefundNo = e.Row.Cells[1].Text.Trim();
            DataView dv = mn.GetAll(16);

            gv.DataSource = dv;//asd
            gv.AutoGenerateColumns = false;
            BoundField bfModelName = new BoundField();
            bfModelName.DataField = "test_name";

            BoundField bfEngine = new BoundField();
            bfEngine.DataField = "testamount";

           
            gv.Columns.Add(bfModelName);
            gv.Columns.Add(bfEngine);
            

            gv.DataBind();
            gv.Columns[0].ItemStyle.Width = Unit.Percentage(70);
            gv.Columns[1].ItemStyle.Width = Unit.Percentage(10);          

        }
    }
    protected void gvTestList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drV = ((DataRowView)e.Row.DataItem);

            clsBLMain mn = new clsBLMain();
            mn.TestID = gvTestList.DataKeys[e.Row.RowIndex].Value.ToString();
            DataView dv = mn.GetAll(17);

            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["type"].ToString().Trim() == "Daily")
                    e.Row.Cells[8].Text = "Daily";
                else
                {
                    if (i == 0)
                        e.Row.Cells[8].Text = dv[i]["value"].ToString().Replace("1","Ist").Replace("2","2nd").Replace("3","3rd").Replace("4","4th");
                    else
                        e.Row.Cells[8].Text += "," + dv[i]["value"].ToString().Replace("1", "Ist").Replace("2", "2nd").Replace("3", "3rd").Replace("4", "4th");
                }
            }

                if (PreviousSub == drV["subdepartment"].ToString())
                {
                    if (gvTestList.Rows[firstRow].Cells[1].RowSpan == 0)

                        gvTestList.Rows[firstRow].Cells[1].RowSpan = 2;

                    else
                        gvTestList.Rows[firstRow].Cells[1].RowSpan += 1;

                    //Remove the cell
                    e.Row.Cells.RemoveAt(1);

                }
                else //It's a new category
                {

                    //Set the vertical alignment to top
                    e.Row.VerticalAlign = VerticalAlign.Top;

                    //Maintain the category in memory
                    PreviousSub = drV["subdepartment"].ToString();

                    firstRow = e.Row.RowIndex;

                }
        }
    }
    protected void gvExternal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drV = ((DataRowView)e.Row.DataItem);

            clsBLMain mn = new clsBLMain();
            mn.TestID = gvExternal.DataKeys[e.Row.RowIndex].Value.ToString();
            DataView dv = mn.GetAll(17);

            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["type"].ToString().Trim() == "Daily")
                    e.Row.Cells[9].Text = "Daily";
                else
                {
                    if (i == 0)
                        e.Row.Cells[9].Text = dv[i]["value"].ToString().Replace("1", "Ist").Replace("2", "2nd").Replace("3", "3rd").Replace("4", "4th");
                    else
                        e.Row.Cells[9].Text += "," + dv[i]["value"].ToString().Replace("1", "Ist").Replace("2", "2nd").Replace("3", "3rd").Replace("4", "4th");
                }
            }

            if (PreviousSub == drV["subdepartment"].ToString())
            {
                if (gvExternal.Rows[firstRow].Cells[1].RowSpan == 0)

                    gvExternal.Rows[firstRow].Cells[1].RowSpan = 2;

                else
                    gvExternal.Rows[firstRow].Cells[1].RowSpan += 1;

                //Remove the cell
                e.Row.Cells.RemoveAt(1);

            }
            else //It's a new category
            {

                //Set the vertical alignment to top
                e.Row.VerticalAlign = VerticalAlign.Top;

                //Maintain the category in memory
                PreviousSub = drV["subdepartment"].ToString();

                firstRow = e.Row.RowIndex;

            }
        }
    }

    protected void gvWorkList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (!System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Equals("006"))
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string TestId = gvWorkList.DataKeys[e.Row.RowIndex].Values[0].ToString();
                clsBLWorkList WorkList = new clsBLWorkList();
                WorkList.TestID = TestId;
                DataView dv = WorkList.GetAll(6);
                GridView gv = (GridView)e.Row.FindControl("gv_test_attributes");

                gv.DataSource = dv;

                gv.DataBind();
            }
        }
    }


    protected void gvWorkList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
