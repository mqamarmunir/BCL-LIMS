using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;


public partial class _Default : System.Web.UI.Page
{
 
    
    private static string mode="";
    private static string branchtype = "";
    private static string businesspolicy = "";
    private static DataTable dtable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        if (!Session["PersonId"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "62";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {

                    //lblstatus.Text = "i";

                    FillDDLSubDepartment();
                    FillDDLBranches();
                    //FillGv();

                    //FillGV();

                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
            }

        }

    }
    private void FillDDLSubDepartment()
    {
        clsSubDepartment obj_SubDep = new clsSubDepartment();
        DataView dv_SubDep = obj_SubDep.GetAll(8);
        obj_SubDep = null;
        if (dv_SubDep.Count > 0)
        {
            SComponents objScom = new SComponents();
            objScom.FillDropDownList(ddlSubDepartment, dv_SubDep, "Name", "SubDepartmentID", true, false, true);
            objScom = null;
            this.ddlSubDepartment.SelectedValue = "-1";
        }
        dv_SubDep.Dispose();
    }

    private void FillDDLBranches()
    {
        clsBLBranch obj_br = new clsBLBranch();
        DataView dv_brs = obj_br.GetAll(3);
        obj_br = null;
        if (dv_brs.Count > 0)
        {
            SComponents objScom = new SComponents();
            objScom.FillDropDownList(ddlBranch, dv_brs, "Name", "BranchID", true, false, true);
            objScom = null;
            this.ddlSubDepartment.SelectedValue = "-1";
        }
        dv_brs.Dispose();


    }
    private void FillGv()
    {
        clsBLBranchTestD obj_tb = new clsBLBranchTestD();
        obj_tb.BranchID = ddlBranch.SelectedValue.ToString();
        obj_tb.External = chkExternal.Checked == true ? "Y" : "N";
        DataView dv_br_Tests = obj_tb.GetAll(1);
        obj_tb = null;
        if (dv_br_Tests.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = dv_br_Tests.ToTable();
            dv_br_Tests.Dispose();
            Session["dt"] = dt;
            gvSelectedTests.DataSource = dt;
            gvSelectedTests.DataBind();
            divselected.Visible = true;
            mode = "Update";
        }
        else
        {
            Session["dt"] = "";
            gvSelectedTests.DataSource = "";
            gvSelectedTests.DataBind();
            mode = "";
        }
    }

    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubDepartment.SelectedValue.ToString() != "-1")
        {
            divAllTests.Visible = true;

            FillGVTests();

        }
        else
        {
            gvAllTests.DataSource = "";
            gvAllTests.DataBind();
            divAllTests.Visible = false;
        }

    }
    private void FillGVTests()
    {
        clsTest obj_Test=new clsTest();
        obj_Test.SubdepartmentId=ddlSubDepartment.SelectedValue.ToString();
        if (ddlforward.SelectedValue.ToString() != "-1")
        {
            obj_Test.BranchID = ddlforward.SelectedValue.ToString().Trim();
        }
        DataView dv_Tests=obj_Test.GetAll(15);
        obj_Test = null;
        if (dv_Tests.Count > 0)
        {
            divAllTests.Visible = true;
            gvAllTests.DataSource = dv_Tests;
            gvAllTests.DataBind();

        }
        else
        {
            divAllTests.Visible = false;
            gvAllTests.DataSource = "";
            gvAllTests.DataBind();
        }
        dv_Tests.Dispose();
    }

    protected void chkExternal_CheckedChanged(object sender, EventArgs e)
    {
        if (chkExternal.Checked == true)
        {
            tblExternal.Visible = true;
            clsBLBranch obj_branch = new clsBLBranch();
            obj_branch.BranchID = ddlBranch.SelectedValue.ToString().Trim();
            DataView dv_Branches = obj_branch.GetAll(4);
            SComponents obj_com = new SComponents();
            obj_com.FillDropDownList(ddlforward, dv_Branches, "Name", "BranchID", true, false, true);
            FillGv();
            FillGVTests();
            Fillgvsupdepartmentsper();
        }
        else
        {
            tblExternal.Visible = false;
            FillGv();
            FillGVTests();
            Fillgvsupdepartmentsper();
        }
    }

   
    protected void lnkAddSelected_Click(object sender, EventArgs e)
    {
        int count = 0;
        DataTable dt = new DataTable();
        createTable(dt);
       
        
        if (Session["dt"].Equals(""))
            Session["dt"] = dt;
        else
            dt = (DataTable)Session["dt"];

        if (dt.Columns.Count == 0)
        {
            createTable(dt);
            Session["dt"] = dt;
        }
        foreach (GridViewRow row in gvAllTests.Rows)
        {
            count = 0;
            if (((CheckBox)gvAllTests.Rows[row.RowIndex].Cells[3].FindControl("gvchkTest")).Checked == true)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["TestID"].ToString().Equals(gvAllTests.DataKeys[row.RowIndex].Value.ToString()))
                        {
                            break;

                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                if (count != dt.Rows.Count)
                {
                    
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["TestID"] = gvAllTests.DataKeys[row.RowIndex].Value.ToString();
                    dr["TestName"] = gvAllTests.Rows[row.RowIndex].Cells[1].Text;
                    dr["External"] = chkExternal.Checked == true ? "Y" : "N";
                    dr["SubDepartmentID"] = ddlSubDepartment.SelectedValue.ToString().Trim();
                    dr["VendorPrice"] = gvAllTests.Rows[row.RowIndex].Cells[2].Text.Trim();
                    if (businesspolicy == "N")
                    {
                        dr["Price"] = Convert.ToInt32(gvAllTests.Rows[row.RowIndex].Cells[2].Text.Trim());
                    }
                    else
                    {
                        dr["Price"] = Convert.ToInt32("0");
                    }
                    dr["SubDepartment"] = ddlSubDepartment.SelectedItem.Text.Trim();
                    dr["Percentage"] = "0";
                    dr["FranchiseDiscount"] = "0";
                    if (chkExternal.Checked == true)
                    {
                        
                        dr["Branch"] = ddlforward.SelectedItem.Text;
                        dr["DestinationBranchID"] = ddlforward.SelectedValue.ToString();
                        dr["TATtype"] = ddlTat.SelectedValue.ToString();
                        dr["TATvalue"] = txtTat.Text;
                    }
                    else
                    {
                        dr["Branch"] = "";
                        dr["DestinationBranchID"] = "0";
                        dr["TATtype"] = "";
                        dr["TATvalue"] = 0;
                    }
                    
//                    if (txtPercent.Text != "" && txtPercent.Text != null)
//                    {
//                        dr["Price"] = RoundOff(Convert.ToInt32((Convert.ToDouble(gvAllTests.Rows[row.RowIndex].Cells[2].Text) - (Convert.ToDouble(txtPercent.Text) * Convert.ToDouble(gvAllTests.Rows[row.RowIndex].Cells[2].Text) / 100))));
//                        lblErrMsg.Text = "";
//                    }
//                    else
//                    {
//                        lblErrMsg.Text = @"Process failed to initalize as percentage field left empty.<br/>
//                                        please enter percentage and then try again";
//                        break;

//                    }
                    dt.Rows.Add(dr);
                }
            }
        }
        divselected.Visible = true;
        //dt.DefaultView.Sort = "SubDepartment ASC";
        gvSelectedTests.DataSource = dt;
        gvSelectedTests.DataBind();
        Fillgvsupdepartmentsper();
        FillGVTests();


    }
    private void Fillgvsupdepartmentsper()
    {
        string[] subdepartmentids = new string[gvSelectedTests.Rows.Count];
        if (gvSelectedTests.Rows.Count > 0)
        {
        #region Getting SubDepartmentids of the Selected Tests
       
        ////////////////////////Getting SubDepartmentids of the Selected Tests////////////////
        
            int index = 1;
            int count = 0;
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();

            for (int i = 0; i < subdepartmentids.Length; i++)
            {
                subdepartmentids[i] = "";
            }

            subdepartmentids[0] = gvSelectedTests.DataKeys[0].Values[4].ToString();
            for (int i = 1; i < gvSelectedTests.Rows.Count; i++)
            {
                count = 0;
                for (int j = 0; j < subdepartmentids.Length; j++)
                {
                    if (gvSelectedTests.DataKeys[i].Values[4].ToString().Trim() != subdepartmentids[j].Trim())
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == subdepartmentids.Length)
                {
                    subdepartmentids[index] = gvSelectedTests.DataKeys[i].Values[4].ToString().Trim();
                    index++;

                }
            }
            for (int i = 0; i < subdepartmentids.Length; i++)
            {
                if (subdepartmentids[i] != "")
                {
                    list.Add(subdepartmentids[i]);
                }
            }
            subdepartmentids = list.ToArray();


            //////////////////////////////////////////-------------------------------////////////////////
        #endregion
            clsBLBranchTestD obj_brtests = new clsBLBranchTestD();
            obj_brtests.Subdepartmentids = subdepartmentids;
            DataView dv1 = obj_brtests.GetAll(4);
            // ListItem item = new ListItem("All Groups", "-1");

            if (dv1.Count > 0)
            {
                //   ddlSubDepartmentper.Items.Insert(0,item);
                SComponents obj_Com = new SComponents();
                //obj_Com.FillDropDownListWithoutSelect(ddlSubDepartmentper, dv1, "Name", "SubDepartmentID");
                obj_Com.FillDropDownListWithoutSelectmy(ddlSubDepartmentper, dv1, "Name", "SubDepartmentID", true, true);
                ddlSubDepartmentper.SelectedValue = "-1";
            }
        }
        else
        {
            ddlSubDepartmentper.DataSource = "";
            ddlSubDepartmentper.DataBind();
        }
    }
    private void createTable2(DataTable dtable)
    {
        dtable.Columns.Add("TestID");
        dtable.Columns.Add("External");
    }
    private void createTable(DataTable dt)
    {
        dt.Columns.Add("TestID");
        dt.Columns.Add("Testname");
        dt.Columns.Add("External");
        dt.Columns.Add("Branch");
        dt.Columns.Add("DestinationBranchID");
        dt.Columns.Add("Price");
        dt.Columns.Add("TATtype");
        dt.Columns.Add("TATvalue");
        dt.Columns.Add("SubDepartmentId");
        dt.Columns.Add("VendorPrice");
        dt.Columns.Add("SubDepartment");
        dt.Columns.Add("Percentage");
        dt.Columns.Add("FranchiseDiscount");
       
    }
    protected void lnkAddAll_Click(object sender, EventArgs e)
    {
        
        int count = 0;
        DataTable dt = new DataTable();
        createTable(dt);

        if (Session["dt"].Equals(""))
            Session["dt"] = dt;
        else
            dt = (DataTable)Session["dt"];

        if (dt.Columns.Count == 0)
        {
            createTable(dt);
            Session["dt"] = dt;
        }

        foreach (GridViewRow row in gvAllTests.Rows)
        {
            if (gvAllTests.Rows[row.RowIndex].Enabled == true)
            {
                count = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["TestID"].ToString().Equals(gvAllTests.DataKeys[row.RowIndex].Value.ToString()))
                        {
                            break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                if (count != dt.Rows.Count)
                {

                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["TestID"] = gvAllTests.DataKeys[row.RowIndex].Value.ToString();
                    dr["TestName"] = gvAllTests.Rows[row.RowIndex].Cells[1].Text;
                    dr["External"] = chkExternal.Checked == true ? "Y" : "N";
                    dr["SubDepartmentID"] = ddlSubDepartment.SelectedValue.ToString().Trim();
                    dr["VendorPrice"] = gvAllTests.Rows[row.RowIndex].Cells[2].Text.Trim();
                    if (businesspolicy == "N")
                    {
                        dr["Price"] = Convert.ToInt32(gvAllTests.Rows[row.RowIndex].Cells[2].Text.Trim());
                    }
                    else
                    {
                        dr["Price"] = Convert.ToInt32("0");
                    }
                    dr["SubDepartment"] = ddlSubDepartment.SelectedItem.Text.Trim();
                    dr["Percentage"] = "0";
                    dr["FranchiseDiscount"] = "0";
                    if (chkExternal.Checked == true)
                    {
                        dr["Branch"] = ddlforward.SelectedItem.Text;
                        dr["DestinationBranchID"] = ddlforward.SelectedValue.ToString();
                        dr["TATtype"] = ddlTat.SelectedValue.ToString();
                        dr["TATvalue"] = txtTat.Text;
                    }
                    else
                    {
                        dr["Branch"] = "";
                        dr["DestinationBranchID"] = "0";
                        dr["TATtype"] = "";
                        dr["TATvalue"] = 0;
                    }
                    //                if (txtPercent.Text != "" && txtPercent.Text != null)
                    //                {
                    //                    dr["Price"] =RoundOff(Convert.ToInt32((Convert.ToDouble(gvAllTests.Rows[row.RowIndex].Cells[2].Text) - (Convert.ToDouble(txtPercent.Text) * Convert.ToDouble(gvAllTests.Rows[row.RowIndex].Cells[2].Text) / 100))));
                    //                    lblErrMsg.Text = "";
                    //                }
                    //                else
                    //                {
                    //                    lblErrMsg.Text = @"Process failed to initalize as percentage field left empty.<br/>
                    //                                            please enter percentage and then try again";
                    //                    break;

                    //                }

                    dt.Rows.Add(dr);
                }
            }
        }
        divselected.Visible = true;
        //dt.DefaultView.Sort = "SubDepartment ASC";
        gvSelectedTests.DataSource = dt;
        gvSelectedTests.DataBind();
        Fillgvsupdepartmentsper();
        FillGVTests();


    }
    protected void lnkRemoveSelected_Click(object sender, EventArgs e)
    {

    }
    protected void lnkRemoveAll_Click(object sender, EventArgs e)
    {
        clsBLBranchTestD obj_br = new clsBLBranchTestD();
        obj_br.BranchID = ddlBranch.SelectedValue.ToString().Trim();
        obj_br.External = chkExternal.Checked ? "Y" : "N";
        if (obj_br.delete())
        {
            lblErrMsg.Text = "All Records Deleted";
            Session["dt"] = "";
            gvSelectedTests.DataSource = "";
            gvSelectedTests.DataBind();
            divselected.Visible = false;
            FillGVTests();
        }
        else
        {
            lblErrMsg.Text = obj_br.ErrorMessage;
        }
    }

    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
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
        if (gvSelectedTests.Rows.Count < 1)
        {
            int count = 0;
            lblErrMsg.Text = "";
            clsBLBranchTestD obj_br_Tests = new clsBLBranchTestD();
            foreach (GridViewRow row in gvSelectedTests.Rows)
            {
                obj_br_Tests.BranchID = ddlBranch.SelectedValue.ToString();
                obj_br_Tests.TestID = gvSelectedTests.DataKeys[row.RowIndex].Values[0].ToString();
                // if (businesspolicy != "N")
                //{
                obj_br_Tests.Percentage = ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[7].FindControl("gvpercentage")).Text.Trim();
                //}
                if (((CheckBox)gvSelectedTests.Rows[row.RowIndex].Cells[3].FindControl("gvchkExternal")).Checked == true)
                {
                    obj_br_Tests.External = "Y";
                    obj_br_Tests.DestBranchID = gvSelectedTests.DataKeys[row.RowIndex].Values["DestinationBranchID"].ToString();
                    obj_br_Tests.TATtype = gvSelectedTests.DataKeys[row.RowIndex].Values["TATtype"].ToString();
                    obj_br_Tests.TATvalue = gvSelectedTests.DataKeys[row.RowIndex].Values["TATvalue"].ToString();

                }
                else
                {
                    obj_br_Tests.External = "N";
                    obj_br_Tests.DestBranchID = gvSelectedTests.DataKeys[row.RowIndex].Values["DestinationBranchID"].ToString();
                    obj_br_Tests.TATtype = gvSelectedTests.DataKeys[row.RowIndex].Values["TATtype"].ToString();
                    obj_br_Tests.TATvalue = gvSelectedTests.DataKeys[row.RowIndex].Values["TATvalue"].ToString();
                }
                obj_br_Tests.TestPrice = ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[6].FindControl("gvTxtPrice")).Text;
                obj_br_Tests.Offeredprice = gvSelectedTests.Rows[row.RowIndex].Cells[5].Text.Trim();
                obj_br_Tests.Active = "Y";
                obj_br_Tests.FranchiseDiscount = (gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("gvtxtfrandisc") as TextBox).Text.Trim();

                obj_br_Tests.SubDepartmentID = gvSelectedTests.DataKeys[row.RowIndex].Values[4].ToString().Trim();
                obj_br_Tests.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_br_Tests.Enteredby = Session["PersonId"].ToString();
                obj_br_Tests.ClientId = Session["orgid"].ToString();

                if (obj_br_Tests.Insert())
                {
                    count++;
                }
                else
                {
                    lblErrMsg.Text += obj_br_Tests.ErrorMessage + "<br />";
                }

            }
            if (count == gvSelectedTests.Rows.Count)
            {
                RefreshForm();
                lblErrMsg.Text = "<font color='green'>All Records Inserted Successfully.</font>";
            }

        }
        else
        {
            #region inserting using Bulkloader class
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < gvSelectedTests.Rows.Count; i++)
            {
                //sb.Append("10101");//BranchTestID
                //sb.Append("\t");

                sb.Append(ddlBranch.SelectedValue.ToString());//BranchID
                sb.Append("\t");
                sb.Append(gvSelectedTests.DataKeys[i].Values[0].ToString());// TestID
                sb.Append("\t");
                if (chkExternal.Checked)
                {
                    //obj_br_Tests.External = "Y";
                    sb.Append("Y");
                    sb.Append("\t");
                    sb.Append(gvSelectedTests.DataKeys[i].Values["DestinationBranchID"].ToString());
                    sb.Append("\t");
                }
                else
                {
                    //obj_br_Tests.External = "Y";
                    sb.Append("N");//External
                    sb.Append("\t");
                    sb.Append("0");//Destination BranchID
                    sb.Append("\t");
                }
                sb.Append(((TextBox)gvSelectedTests.Rows[i].Cells[6].FindControl("gvTxtPrice")).Text);//Test PRice
                sb.Append("\t");
                sb.Append(Session["personid"].ToString().Trim());//EnteredBy
                sb.Append("\t");
                sb.Append(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//EnteredOn
                sb.Append("\t");
                sb.Append(System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim());
                sb.Append("\t");
                if (chkExternal.Checked)
                {
                    //obj_br_Tests.External = "Y";
                    sb.Append(gvSelectedTests.DataKeys[i].Values["TATtype"].ToString());
                    sb.Append("\t");
                    sb.Append(gvSelectedTests.DataKeys[i].Values["TATvalue"].ToString());
                    sb.Append("\t");
                }
                else
                {
                    //obj_br_Tests.External = "Y";
                    sb.Append("X");//Tat Type
                    sb.Append("\t");
                    sb.Append("0");//Tat time
                    sb.Append("\t");
                }
                sb.Append("Y");//Active
                sb.Append("\t");
                sb.Append(gvSelectedTests.DataKeys[i].Values[4].ToString().Trim());//SubDepartmentID
                sb.Append("\t");
                sb.Append(gvSelectedTests.Rows[i].Cells[5].Text.Trim());//Offered Price
                sb.Append("\t");
                sb.Append(((TextBox)gvSelectedTests.Rows[i].Cells[7].FindControl("gvpercentage")).Text.Trim());// Percentage Discount
                sb.Append("\t");
                sb.Append((gvSelectedTests.Rows[i].Cells[8].FindControl("gvtxtfrandisc") as TextBox).Text.Trim());// Franchise Discount
                sb.Append("\r\n");
            }


            StreamWriter sw=new StreamWriter(Server.MapPath("~/mynewfile.txt"),false);
            sw.Write(sb.ToString());
            sw.Dispose();
            sb = null;

            string StrConnection = null;
            System.Configuration.AppSettingsReader con = new System.Configuration.AppSettingsReader();
            //         string connectionString = ConfigurationSettings.AppSettings.Get("ConnectionString");
            StrConnection = "User Id=" + con.GetValue("susername", "".GetType()).ToString() + "; PWD =" + con.GetValue("spassword", "".GetType()).ToString() + "; Server=" + con.GetValue("sserver", "".GetType()).ToString() + ";Port=3306;Database=" + con.GetValue("sdb", "".GetType()).ToString() + ";respect binary flags = false";
            //  StrConnection = "dsn=saps";
            MySqlConnection Conn = null ;
            try
            {
                Conn = new MySqlConnection(StrConnection);
               // Conn.Open();
                //return Conn;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                //return null;
            }
            string filepath = Server.MapPath("~/mynewfile.txt");
            MySqlCommand command=new MySqlCommand(@"LOAD DATA INFILE '"+filepath.Replace(@"\","/")+@"'
INTO TABLE dc_tp_branchtestd
FIELDS TERMINATED BY '\t'
lines terminated by '\r\n'
(branchid,testid,External,DestinationBranchID,TestPrice,EnteredBy,EnteredOn,ClientID,TatType,Tatvalue,Active,Subdepartmentid,OfferedPrice,Percentagediscount,FranchiseDiscount)",Conn);
            Conn.Open();
            command.CommandTimeout = 120000;
            int count=command.ExecuteNonQuery();
            Conn.Close();
            if (count == gvSelectedTests.Rows.Count)
            {
                RefreshForm();
                lblErrMsg.Text = "<font color='green'>All Records Inserted Successfully.</font>";
            }
            //MySqlBulkLoader bl = new MySqlBulkLoader(Conn);
            //bl.TableName = "dc_tp_branchtestd";
            //bl.FieldTerminator = "\t";
            //bl.LineTerminator = "\r\n";
            //bl.FileName = @"c:/mynewfile.txt";
            //bl.NumberOfLinesToSkip = 1;
            //bl.Timeout = 120;
            //bl.Columns.Add("Branchid");

            //bl.Columns.Add("TestId");
            //bl.Columns.Add("Branchid");
            //bl.Columns.Add("External");
            //bl.Columns.Add("DestinationBranchID");
            //bl.Columns.Add("TestPrice");
            //bl.Columns.Add("EnteredBy");
            //bl.Columns.Add("EnteredOn");
            //bl.Columns.Add("ClientId");
            //bl.Columns.Add("TatType");
            //bl.Columns.Add("Active");
            //bl.Columns.Add("SubDepartmentiD");
            //bl.Columns.Add("OfferedPrice");
            //bl.Columns.Add("PercentageDiscount");
            //bl.Columns.Add("FranchiseDiscount");
           
            
            ////bl.
            ////bl.Columns = "(branchid,testid,External,DestinationBranchID,TestPrice,EnteredBy,EnteredOn,ClientID,TatType,Tatvalue,Active,Subdepartmentid,OfferedPrice,Percentagediscount,FranchiseDiscount)";
            
            //try
            //{
            //    //Console.WriteLine("Connecting to MySQL...");
            //    //conn.Open();

            //    // Upload data from file
            //    int count = bl.Load();
            //    lblErrMsg.Text = count.ToString() + " lines uploaded";
                
            //    //Console.WriteLine(count + " lines uploaded.");

            //    //string sql = "SELECT Name, Age, Profession FROM Career";
            //    //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //    //MySqlDataReader rdr = cmd.ExecuteReader();

            //    //while (rdr.Read())
            //    //{
            //    //    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
            //    //}

            //    //rdr.Close();

            //   // Conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            #endregion
        }
    }

    private void Update()
    {
        
        if (Deleteprevious())
        {
            Insert();
        }
    }

    private bool Deleteprevious()
    {
        clsBLBranchTestD obj_br = new clsBLBranchTestD();
        obj_br.BranchID = ddlBranch.SelectedValue.ToString();
        obj_br.External = chkExternal.Checked == true ? "Y" : "N";
        if (obj_br.delete())
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }

    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        RefreshForm();
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
         Session["dt"] = "";
        if (!Session["OrgId2"].Equals(""))
        {
            Response.Redirect("Organization.aspx");
        }
        else
        {
            Response.Redirect("MainPage.aspx");
        }
       
       
    }
    protected void gvSelectedTests_RowDeletingClick(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)Session["dt"];
        dt.Rows[e.RowIndex].Delete();
        dt.AcceptChanges();
        gvSelectedTests.DataSource = dt;
        gvSelectedTests.DataBind();
        FillGVTests();
        
 
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedValue.ToString() != "-1")
        {
            Session["dt"] = "";
            clsBLBranch obj_branch = new clsBLBranch();
            obj_branch.BranchID = ddlBranch.SelectedValue.ToString().Trim();
            DataView dv_branchtype = obj_branch.GetAll(2);
            if (dv_branchtype.Count > 0)
            {
                branchtype = dv_branchtype[0]["Type"].ToString().Trim();
                if (branchtype == "S")
                {
                    businesspolicy = dv_branchtype[0]["BusinessPolicy"].ToString().Trim();
                    if (businesspolicy == "N")
                    {
                        lblBranchType.Text = "Self Operated:Net";
                       // txtpercentper.Visible = false;
                       // gvSelectedTests.Columns[7].Visible = false;
                    }
                    else
                    {
                        lblBranchType.Text = "Self Operated:Gross";
                        txtpercentper.Visible = true;
                        gvSelectedTests.Columns[7].Visible = true;
                    }

                }
                else
                {
                    lblBranchType.Text="Franchise";
                    businesspolicy = "";
                    txtpercentper.Visible = true;
                    gvSelectedTests.Columns[7].Visible = true;
                }
            }
           // lblErrMsg.Text = businesspolicy;
            FillGv();
            BranchAllocatedinvestigations();
            Fillgvsupdepartmentsper();
        }
    }

    private void BranchAllocatedinvestigations()
    {
        clsBLBranchTestD objTestD = new clsBLBranchTestD();
      //  objTestD.SubDepartmentID = ddlSubDepartment.SelectedValue.ToString().Trim();
        objTestD.BranchID = ddlBranch.SelectedValue.ToString().Trim();
        DataView dv_allocated_all = objTestD.GetAll(5);
        if (dv_allocated_all.Count > 0)
        {
            dtable = dv_allocated_all.ToTable();
            dv_allocated_all.Dispose();
        }
        else
        {
            dv_allocated_all.Dispose();
            dtable.Clear();


        }
    }
    private void RefreshForm()
    {
        lblErrMsg.Text = "";
        foreach (GridViewRow ro in gvAllTests.Rows)
        {
            CheckBox chk = (CheckBox)gvAllTests.Rows[ro.RowIndex].Cells[3].FindControl("gvchkTest");
            chk.Checked = false;
        }
        mode = "";
        chkExternal.Checked = false;
        txtPercent.Text = "";
        txtTat.Text = "";
        ddlforward.ClearSelection();
        ddlSubDepartment.ClearSelection();
        gvAllTests.DataSource = "";
        gvAllTests.DataBind();
        Session["dt"] = "";
        gvSelectedTests.DataSource = "";
        gvSelectedTests.DataBind();
        ddlBranch.ClearSelection();
        divAllTests.Visible = false;
        divselected.Visible = false;
        tblExternal.Visible = false;
        txtFranper.Text = "";
        txtpercentper.Text = "";
        ddlSubDepartmentper.ClearSelection();
        ddlTat.ClearSelection();
        businesspolicy = "";
        branchtype = "";
       
     
    }

    public int RoundOff(int x)
    {
        return Convert.ToInt32(Math.Round(x / 10.0) * 10);
    }
    protected void lnkProcess_Click(object sender, EventArgs e)
    {
        if (ddlSubDepartmentper.SelectedValue.ToString().Trim() == "-1")
        {
            if (businesspolicy != "N")
            {
                if (txtpercentper.Text != "" && txtpercentper.Text != "&nbsp;")
                {
                    foreach (GridViewRow row in gvSelectedTests.Rows)
                    {
                        if (((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[6].FindControl("gvTxtPrice")).Text.Trim() == "0")
                        {
                            ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[6].FindControl("gvTxtPrice")).Text = RoundOff(Convert.ToInt32((Convert.ToDouble(gvSelectedTests.Rows[row.RowIndex].Cells[5].Text.Trim()) - (Convert.ToDouble(txtpercentper.Text) * Convert.ToDouble(gvSelectedTests.Rows[row.RowIndex].Cells[5].Text) / 100)))).ToString();
                            ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[7].FindControl("gvpercentage")).Text = txtpercentper.Text.Trim();
                            // ((HiddenField)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("hdpercentage")).Value = txtpercentper.Text.Trim();
                        }
                        if (((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("gvtxtfrandisc")).Text.Trim() == "0")
                        {
                            ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("gvtxtfrandisc")).Text = txtFranper.Text.Trim();
                        }
                    }
                }
            }
            else
            {
                foreach (GridViewRow row in gvSelectedTests.Rows)
                {
                    if (((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[6].FindControl("gvTxtPrice")).Text.Trim() == "0")
                    {
                        ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[6].FindControl("gvTxtPrice")).Text = RoundOff(Convert.ToInt32((Convert.ToDouble(gvSelectedTests.Rows[row.RowIndex].Cells[5].Text.Trim()) - (Convert.ToDouble(txtpercentper.Text) * Convert.ToDouble(gvSelectedTests.Rows[row.RowIndex].Cells[5].Text) / 100)))).ToString();
                        ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[7].FindControl("gvpercentage")).Text = txtpercentper.Text.Trim();
                        // ((HiddenField)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("hdpercentage")).Value = txtpercentper.Text.Trim();
                    }
                    if (((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("gvtxtfrandisc")).Text.Trim() == "0")
                    {
                        ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("gvtxtfrandisc")).Text = txtFranper.Text.Trim();
                    }
                }
            }
            //lblErrMsg.Text = ((HiddenField)gvSelectedTests.Rows[5].Cells[8].FindControl("hdpercentage")).Value.ToString();
        }
        else
        {
            if (businesspolicy != "N")
            {
                if (txtpercentper.Text != "" && txtpercentper.Text != "&nbsp;")
                {
                    foreach (GridViewRow row in gvSelectedTests.Rows)
                    {
                        if ((gvSelectedTests.DataKeys[row.RowIndex].Values[4].ToString().Trim() == ddlSubDepartmentper.SelectedValue.ToString().Trim()))
                        {
                            ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[6].FindControl("gvTxtPrice")).Text = RoundOff(Convert.ToInt32((Convert.ToDouble(gvSelectedTests.Rows[row.RowIndex].Cells[5].Text.Trim()) - (Convert.ToDouble(txtpercentper.Text) * Convert.ToDouble(gvSelectedTests.Rows[row.RowIndex].Cells[5].Text) / 100)))).ToString();
                            //gvSelectedTests.DataKeys[row.RowIndex].Values[5] = txtpercentper.Text.Trim();
                            ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[7].FindControl("gvpercentage")).Text = txtpercentper.Text.Trim();
                            //((HiddenField)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("hdpercentage")).Value = txtpercentper.Text.Trim();
                            ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("gvtxtfrandisc")).Text = txtFranper.Text.Trim();
                        }
                    }
                }
            }

            else
            {
                foreach (GridViewRow row in gvSelectedTests.Rows)
                {
                    if ((gvSelectedTests.DataKeys[row.RowIndex].Values[4].ToString().Trim() == ddlSubDepartmentper.SelectedValue.ToString().Trim()))
                    {
                         //((HiddenField)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("hdpercentage")).Value = txtpercentper.Text.Trim();
                        ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[6].FindControl("gvTxtPrice")).Text = RoundOff(Convert.ToInt32((Convert.ToDouble(gvSelectedTests.Rows[row.RowIndex].Cells[5].Text.Trim()) - (Convert.ToDouble(txtpercentper.Text) * Convert.ToDouble(gvSelectedTests.Rows[row.RowIndex].Cells[5].Text) / 100)))).ToString();
                        //gvSelectedTests.DataKeys[row.RowIndex].Values[5] = txtpercentper.Text.Trim();
                        ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[7].FindControl("gvpercentage")).Text = txtpercentper.Text.Trim();
                        //((HiddenField)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("hdpercentage")).Value = txtpercentper.Text.Trim();
                        ((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("gvtxtfrandisc")).Text = txtFranper.Text.Trim();
                        //((TextBox)gvSelectedTests.Rows[row.RowIndex].Cells[8].FindControl("gvtxtfrandisc")).Text = txtFranper.Text.Trim();
                    }
                }
            }
 
        }
    }

    protected void gvAllTests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Control container = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < gvSelectedTests.Rows.Count; i++)
            {
                if (gvAllTests.DataKeys[e.Row.RowIndex].Value.ToString().Trim() == gvSelectedTests.DataKeys[i].Values[0].ToString().Trim() )
                {
                    e.Row.BackColor = System.Drawing.Color.Silver;
                    e.Row.Enabled = false;
                }
            }

            for (int j = 0; j < dtable.Rows.Count; j++)
            {
                if (gvAllTests.DataKeys[e.Row.RowIndex].Value.ToString().Trim() == dtable.Rows[j]["TestID"].ToString().Trim())
                {
                    if (e.Row.Enabled == false)
                    {
                        e.Row.BackColor = System.Drawing.Color.Silver;
                        e.Row.Enabled = false;
                    }
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.Brown;
                        e.Row.Enabled = false;
                    }
                }
            }
        }
    }


    protected void ddlForward_SelectedIndexChanged(object sender, EventArgs e)
    {
   
        FillGVTests();
    }
}