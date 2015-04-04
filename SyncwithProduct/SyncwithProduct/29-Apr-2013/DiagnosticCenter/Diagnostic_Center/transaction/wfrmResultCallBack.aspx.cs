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

public partial class transaction_wfrmResultCallBack : System.Web.UI.Page
{
	private static string DGSort = "";

	protected void Page_Load ( object sender , EventArgs e )
	{
		if (!Session["personid"].Equals(""))
		{
			if (!IsPostBack)
			{
				clsLogin log = new clsLogin();
				log.OptionId = "46";
				log.PersonId = Session["personid"].ToString();
				DataView dvLog = log.GetLogin(2);
				if (dvLog.Count > 0)
				{
					Panel_Fill();
					Dept_Fill();

					SubDept_Fill();
					Group_Fill();
					Test_Fill();

					rdbPatientOption.Items.FindByValue("C").Selected = true;
					pnl_Pnl_info.Visible = false;

					txtFromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
					txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
					GV_Fill();
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

	private void Panel_Fill()
	{
		SComponents com = new SComponents();
		clsBLDispatch ds = new clsBLDispatch();
		DataView dv = ds.GetAll(2);
		com.FillDropDownList(ddlPanel , dv , "name" , "panelid");
	}

	private void Dept_Fill()
	{
		SComponents com = new SComponents();
		clsBLDispatch ds = new clsBLDispatch();

		DataView dv = ds.GetAll(3);
		com.FillDropDownList(ddlDepartment , dv , "name" , "departmentid");
	}
	private void SubDept_Fill()
	{
		SComponents com = new SComponents();
		clsBLDispatch ds = new clsBLDispatch();

		if (ddlDepartment.SelectedIndex > 0)
			ds.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
		DataView dv = ds.GetAll(4);
		com.FillDropDownList(ddlSubdepartment , dv , "name" , "subdepartmentid");

	}

	private void Group_Fill ( )
	{
		SComponents com = new SComponents();
		clsBLDispatch ds = new clsBLDispatch();

		DataView dv = ds.GetAll(5);
		com.FillDropDownList(ddlGroup , dv , "name" , "groupid");
	}
	private void Test_Fill ( )
	{
		SComponents com = new SComponents();
		clsBLDispatch ds = new clsBLDispatch();

		if (ddlDepartment.SelectedIndex > 0)
			ds.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
		if (ddlSubdepartment.SelectedIndex > 0)
			ds.SubDepartmentID = this.ddlSubdepartment.SelectedItem.Value.ToString();

		DataView dv = ds.GetAll(6);
		com.FillDropDownList(ddlTest , dv , "test_name" , "testid");


	}
	private void GV_Fill ( )
	{
		clsBLDispatch ds = new clsBLDispatch();

		if (!txtLabID.Text.Trim().Replace("__-___-________" , "").Equals(""))
		{
			ds.LabID = this.txtLabID.Text.Trim();
		}
		if (!txtPRNO.Text.Trim().Replace("___-__-________" , "").Equals(""))
		{
			ds.PRNO = this.txtPRNO.Text.Trim();
		}
		if (!txtPatientName.Text.Trim().Equals(""))
		{
			ds.PatientName = this.txtPatientName.Text.Trim();
		}

		if (ddlPanel.SelectedIndex > 0 && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
		{
			ds.PanelID = this.ddlPanel.SelectedItem.Value.ToString();
		}
		if (!txtEmployeeName.Text.Trim().Equals("") && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
		{
			ds.PatientName = this.txtEmployeeName.Text.Trim();
		}
		if (!txtEmployeeNo.Text.Trim().Equals("") && rdbPatientOption.SelectedItem.Value.ToString().Equals("P"))
		{
			ds.EmployeeNumber = this.txtEmployeeNo.Text.Trim();
		}

		if (ddlDepartment.SelectedIndex > 0)
		{
			ds.DepartmentID = this.ddlDepartment.SelectedItem.Value.ToString();
		}
		if (ddlSubdepartment.SelectedIndex > 0)
		{
			ds.SubDepartmentID = this.ddlSubdepartment.SelectedItem.Value.ToString();
		}

		if (ddlGroup.SelectedIndex > 0)
		{
			ds.GroupID = this.ddlGroup.SelectedItem.Value.ToString();
		}
		if (ddlTest.SelectedIndex > 0)
		{
			ds.TestID = this.ddlTest.SelectedItem.Value.ToString();
		}

		//for (int i = 0 ; i < chkProcess.Items.Count ; i++)
		//{
		//    if (chkProcess.Items[i].Selected && processID == "")
		//        processID = chkProcess.Items[i].Value.ToString();
		//    else if (chkProcess.Items[i].Selected && processID != "")
		//        processID = processID + "," + chkProcess.Items[i].Value.ToString();
		//}
		//ds.ProcessID = processID;
		try
		{
			ds.Gender = this.rdbGender.SelectedItem.Value.ToString();
		}
		catch { }
		ds.Type = this.rdbPatientOption.SelectedItem.Value.ToString();

		if (!txtFromDate.Text.Trim().Equals(""))
			ds.FromDate = this.txtFromDate.Text.Trim().Substring(6 , 4) + "/" + txtFromDate.Text.Trim().Substring(3 , 2) + "/" + txtFromDate.Text.Trim().Substring(0 , 2);
		if (!txtToDate.Text.Trim().Equals(""))
			ds.ToDate = this.txtToDate.Text.Trim().Substring(6 , 4) + "/" + txtToDate.Text.Trim().Substring(3 , 2) + "/" + txtToDate.Text.Trim().Substring(0 , 2);
        ds.BranchID = Session["BranchID"].ToString().Trim();
		DataView dv = ds.GetAll(8);
		dv.Sort = DGSort;
		gvResult.DataSource = dv;
		gvResult.DataBind();
	}

	protected void imgClose_Click ( object sender , ImageClickEventArgs e )
	{
		Response.Redirect("../Parameter/MainPage.aspx");
	}
	protected void imgSearch_Click ( object sender , ImageClickEventArgs e )
	{
		GV_Fill();
	}
	protected void imgLab_Click ( object sender , ImageClickEventArgs e )
	{
		if (txtLabID.Text.Trim().Replace("__-___-________" , "").Equals(""))
		{
			ScriptManager.RegisterStartupScript(this , typeof(Page) , "Warning" , "<script language='javascript'>alert('Please enter lab ID');</script>" , false);
			return;
		}
		clsBLDispatch ds = new clsBLDispatch();
		ds.LabID = this.txtLabID.Text.Trim();
		ds.Type = this.rdbPatientOption.SelectedItem.Value.ToString();
        ds.BranchID = Session["BranchID"].ToString().Trim();
		DataView dv = ds.GetAll(8);

		gvResult.DataSource = dv;
		gvResult.DataBind();
	}
	protected void imgPRNo_Click ( object sender , ImageClickEventArgs e )
	{
		if (txtPRNO.Text.Trim().Replace("___-__-________" , "").Equals(""))
		{
			ScriptManager.RegisterStartupScript(this , typeof(Page) , "Warning" , "<script language='javascript'>alert('Please enter pr number');</script>" , false);
			return;
		}
		clsBLDispatch ds = new clsBLDispatch();
		ds.PRNO = this.txtPRNO.Text.Trim();
		ds.Type = this.rdbPatientOption.SelectedItem.Value.ToString();
        ds.BranchID = Session["BranchID"].ToString().Trim();
		DataView dv = ds.GetAll(8);

		gvResult.DataSource = dv;
		gvResult.DataBind();
	}

	private void Clear_Form ( )
	{
		txtLabID.Text = "";
		txtPRNO.Text = "";
		txtPatientName.Text = "";

		txtAge.Text = "";

		ddlPanel.SelectedIndex = 0;
		txtEmployeeNo.Text = "";
		txtEmployeeName.Text = "";

		ddlDepartment.SelectedIndex = 0;
		ddlSubdepartment.SelectedIndex = 0;
		ddlGroup.SelectedIndex = 0;
		ddlTest.SelectedIndex = 0;

		txtFromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
		txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
	}
	protected void imgClear_Click ( object sender , ImageClickEventArgs e )
	{
		Clear_Form();
	}
	protected void rdbPatientOption_SelectedIndexChanged ( object sender , EventArgs e )
	{
		if (rdbPatientOption.Items.FindByValue("C").Selected == true)
		{
			ddlPanel.SelectedIndex = 0;
			txtEmployeeName.Text = "";
			txtEmployeeNo.Text = "";
			pnl_Pnl_info.Visible = false;

			gvResult.DataSource = null;
			gvResult.DataBind();
		}
		else
		{
			pnl_Pnl_info.Visible = true;
			gvResult.DataSource = null;
			gvResult.DataBind();
		}
	}
	protected void ddlDepartment_SelectedIndexChanged ( object sender , EventArgs e )
	{
		SubDept_Fill();
		Test_Fill();
	}
	protected void ddlSubdepartment_SelectedIndexChanged ( object sender , EventArgs e )
	{
		Test_Fill();
	}

	protected void gvResult_Sorting ( object sender , GridViewSortEventArgs e )
	{
		if (e.SortExpression.Equals("labid"))
		{
			if (DGSort.Equals("labid asc"))
				DGSort = "labid desc";
			else
				DGSort = "labid asc";
		}
		else if (e.SortExpression.Equals("patientname"))
		{
			if (DGSort.Equals("patientname asc"))
				DGSort = "patientname desc";
			else
				DGSort = "patientname asc";
		}
		else if (e.SortExpression.Equals("test_name"))
		{
			if (DGSort.Equals("test_name asc"))
				DGSort = "test_name desc";
			else
				DGSort = "test_name asc";
		}

		else if (e.SortExpression.Equals("balance"))
		{
			if (DGSort.Equals("balance asc"))
				DGSort = "balance desc";
			else
				DGSort = "balance asc";
		}
		else if (e.SortExpression.Equals("bookedon"))
		{
			if (DGSort.Equals("bookedon asc"))
				DGSort = "bookedon desc";
			else
				DGSort = "bookedon asc";
		}
		else if (e.SortExpression.Equals("deliveryon"))
		{
			if (DGSort.Equals("deliveryon asc"))
				DGSort = "deliveryon desc";
			else
				DGSort = "deliveryon asc";
		}
		else if (e.SortExpression.Equals("dispatchon"))
		{
			if (DGSort.Equals("dispatchon asc"))
				DGSort = "dispatchon desc";
			else
				DGSort = "dispatchon asc";
		}
		GV_Fill();
	}
	protected void gvResult_RowCommand ( object sender , GridViewCommandEventArgs e )
	{
		lblError.ForeColor = System.Drawing.Color.Red;
		clsBLResultEntry re = new clsBLResultEntry();
        if (!e.CommandName.Equals("Select"))
        {
            if (e.CommandName == "RE")
            {
                re.ProcessID = "5";
            }
            else if (e.CommandName == "RV")
            {
                re.ProcessID = "6";
            }
            else
            {
                return;
            }
            int index = Convert.ToInt32(e.CommandArgument);

            re.BookingID = gvResult.DataKeys[index].Values[1].ToString();
            re.TestID = gvResult.DataKeys[index].Values[2].ToString();
            re.LabID = gvResult.Rows[index].Cells[1].Text;

            re.BookingDID = gvResult.DataKeys[index].Values[5].ToString();
            re.EnteredBy = Session["personid"].ToString();
            re.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            re.ClientID = Session["orgid"].ToString();


            if (re.Result_Call_Back())
            {
                Clear_Form();
                GV_Fill();
                lblError.Text = "";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Successfull", "<script>alert('Result call Back has been entered successfully');</script>", false);
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = re.Error;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('" + re.Error + "');</script>", false);
            }
        }
        else
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblTest_intCmt.Text = "Investigation: " + gvResult.Rows[index].Cells[3].Text.Trim();
            lblInt_Index.Text = index.ToString();
            lblInt_BookingID.Text = gvResult.DataKeys[index].Values[1].ToString();
            lblInt_testID.Text = gvResult.DataKeys[index].Values[2].ToString();

            txtInt_Comnt.Text = "";


            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
            SComponents com = new SComponents();
            iv.TestID = gvResult.DataKeys[index].Values[2].ToString();
            iv.BookingID = gvResult.DataKeys[index].Values[1].ToString();
            iv.For_Process = "11";
            DataView dv = iv.GetAll(29);
            com.FillDropDownList(ddlFor_Process, dv, "name", "processid");

            DataView dvCmt = iv.GetAll(30);
            gvIntComment.DataSource = dvCmt;
            gvIntComment.DataBind();
            //pnlInt_cmmnt.Visible = true;
            cpeWaiting.Collapsed = true;
            mde_intcmt.Show();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.remove_load(blinkGridViewRows);", true);
        }
	}
	protected void gvResult_RowDataBound ( object sender , GridViewRowEventArgs e )
	{
		if (e.Row.RowIndex != -1)
		{
			if (!gvResult.DataKeys[e.Row.RowIndex].Values[4].ToString().Contains("5"))
			{
				e.Row.Cells[5].Visible = false;
			}
			if (!gvResult.DataKeys[e.Row.RowIndex].Values[4].ToString().Contains("6"))
			{
				e.Row.Cells[6].Visible = false;
			}
		}
	}
    protected void imgcmt_save_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.remove_load(blinkGridViewRows);", true);

        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

        iv.TestID = lblInt_testID.Text.Trim();
        iv.BookingID = this.lblInt_BookingID.Text.Trim();
        iv.Int_Comment = txtInt_Comnt.Text.Trim();
        iv.For_Process = ddlFor_Process.SelectedItem.Value.ToString().Replace("-1", "null");

        iv.ProcessID = "11";
        iv.EnteredBy = Session["personid"].ToString();
        iv.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        iv.ClientID = Session["orgid"].ToString();

        if (txtInt_Comnt.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please enter comment');</script>", false);
            return;
        }
        else
        {
            if (iv.Insert_IntComent())
            {
                mde_intcmt.Hide();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + iv.Error + "');</script>", false);
            }
        }


    }
}