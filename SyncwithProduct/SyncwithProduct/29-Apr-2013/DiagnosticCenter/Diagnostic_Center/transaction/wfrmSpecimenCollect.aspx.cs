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
using System.Collections.Generic;

public partial class specimen : System.Web.UI.Page
{
    private static string _printonspecimencollectsettings = "";
     private static List<String> list = new List<String>();
    private static String code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                clsLogin log = new clsLogin();
                log.OptionId = "35";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    Get_GeneralSettings();
                    txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    Fill_Depart();
                    Fill_Group();
                    Fill_Subdept();
                    Fill_GV();
                    
                    //fill_PatientInfo(0);
                    cpeWaiting.Collapsed = true;
                   // Urgent_Count();
                    Get_Nature();
                    //pnl_info.Visible = false;
                    mde_intcmt.Hide();
                    if (Session["spec_grid"] != null && !Session["spec_grid"].Equals(""))
                    {
                        DataTable dt = (DataTable)Session["spec_grid"];
                        Session["spec_grid"] = dt;
                    }
                    
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
    
        code = "";
       
            list.Clear();
    }
    private void Get_GeneralSettings()
    {
        clsBLPreferenceSettings obj_Preferences = new clsBLPreferenceSettings();
        DataView dv = obj_Preferences.GetAll(1);
        if (dv.Count > 0)
        {
            _printonspecimencollectsettings = dv[0]["Printrecieptonspecimen"].ToString().Trim();
        }
        dv.Dispose();
    }
    protected void imgCLose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("NewLogin.aspx");
    }

    private void Fill_Depart()
    {
        clsBLSpecimen sp = new clsBLSpecimen();
        SComponents com = new SComponents();

        DataView dv = sp.GetAll(1);
        com.FillDropDownList(ddlDepart,dv,"name","departmentid");
    }
    private void Fill_Subdept()
    {
        clsBLSpecimen sp = new clsBLSpecimen();
        SComponents com = new SComponents();

        sp.DepartmentID = this.ddlDepart.SelectedItem.Value.ToString();
        DataView dv = sp.GetAll(2);
        com.FillDropDownList(ddlSubdept,dv,"name","subdepartmentid");
    }
    private void Fill_Group()
    {
        clsBLSpecimen sp = new clsBLSpecimen();
        SComponents com = new SComponents();
        DataView dv = sp.GetAll(3);
        com.FillDropDownList(ddlTestGroup,dv,"name","groupid");
    }
    private void Fill_GV()
    {
        clsBLSpecimen sc = new clsBLSpecimen();
        sc.DepartmentID = this.ddlDepart.SelectedItem.Value.Replace("-1","~!@");
        sc.SubDept = this.ddlSubdept.SelectedItem.Value.Replace("-1","~!@");
        sc.GroupID = this.ddlTestGroup.SelectedItem.Value.Replace("-1","~!@");
        sc.Type = this.ddlType.SelectedItem.Value.Trim().Replace("A","~!@");
        sc.ClientID = Session["ClientiD"].ToString().Trim();// System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        sc.BranchID = Session["BranchID"].ToString().Trim();
        if (!txtFrom.Text.Trim().Equals(""))
            sc.FromDate = this.txtFrom.Text.Trim().Substring(6, 4) + "/" + txtFrom.Text.Trim().Substring(3, 2) + "/" + txtFrom.Text.Trim().Substring(0, 2);
        if (!txtTo.Text.Trim().Equals(""))
            sc.ToDate = this.txtTo.Text.Trim().Substring(6, 4) + "/" + txtTo.Text.Trim().Substring(3, 2) + "/" + txtTo.Text.Trim().Substring(0, 2);

        DataView dv = sc.GetAll(4);
        gvSpecimen.DataSource = dv;
        gvSpecimen.DataBind();

        for (int i = 0; i < dv.Count; i++)
        {
            if (dv[i]["repeaty"].ToString() =="Y")
            {
                gvSpecimen.Rows[i].BackColor = System.Drawing.Color.LightCoral;
            }            
        }

            lblNoRecord.Text = "Total Record Found ( <b>" + dv.Count + "</b> )";
            //
    }
    private void Get_Nature()
    {
        clsBLSpecimen sp = new clsBLSpecimen();
        DataView dv = sp.GetAll(6);

        Session["spec_nature"] = dv;
    }
    
    protected void ddlDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Subdept();
        Fill_GV();
    }
    protected void ddlSubdept_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_GV();
        Urgent_Count();
    }
    protected void ddlTestGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_GV();
    }
    private void MakeTableSession()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("testid");
        dt.Columns.Add("bookingid");
        dt.Columns.Add("bookingdid");
        dt.Columns.Add("sub_type");

        dt.Columns.Add("subdept");
        dt.Columns.Add("groupname");
        dt.Columns.Add("testname");
        dt.Columns.Add("specimenqty");

        dt.Columns.Add("notes");
        dt.Columns.Add("spec_no");

        dt.Columns.Add("qty");
        dt.Columns.Add("scontainerid");
        dt.Columns.Add("unit");

              
        Session["spec_grid"] = dt;
    }
    private void fill_PatientInfo(int index)
    {
        pnl_info.Visible = true;
        imgCLose.Visible = false;
        imgRefresh.Visible = false;
        
        clsBLSpecimen sc = new clsBLSpecimen();

        lblPRno.Text = gvSpecimen.DataKeys[index].Value.ToString();
        lblLabID.Text = gvSpecimen.Rows[index].Cells[1].Text.Trim();
        lblPatient.Text = gvSpecimen.Rows[index].Cells[2].Text.Trim();

        lblGender.Text = gvSpecimen.Rows[index].Cells[3].Text.Trim();
        lblAge.Text = gvSpecimen.Rows[index].Cells[4].Text.Trim();

        if (gvSpecimen.DataKeys[index].Values[2].ToString().Trim() != "")
        {
            lblPan_Head.Text = "Panel:";
            lblPanel.Text = gvSpecimen.DataKeys[index].Values[1].ToString().Trim();
        }
        else
        {
            lblPan_Head.Text = "";
            lblPanel.Text = "";
        }

        if (gvSpecimen.DataKeys[index].Values[3].ToString().Equals(""))
        {
            lblCmt_HEad.Text = "";
            lblComment.Text = "";
        }
        else
        {
            lblCmt_HEad.Text = "Comment:";
            lblComment.Text = gvSpecimen.DataKeys[index].Values[3].ToString();
        }
        sc.LabID = this.lblLabID.Text.Trim();
        sc.ClientID = Session["ClientiD"].ToString().Trim();// System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
        DataView dv = sc.GetAll(5);
        DataView dvSpec = sc.GetAll(7);
        
        gvCollect.DataSource = dv;
        gvCollect.DataBind();

        MakeTableSession();
        Session["spec_grid"] = dv.Table;

        int p_zero = 0;
        string histo = "";
        string micro = "";
        string pad = "";
        string gen = "";

        for (int i = 0; i < gvCollect.Rows.Count; i++)
        {
            ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Visible = false;

            Session["spec_no"] = dvSpec[0]["histo"].ToString() + ";" + dvSpec[0]["Micro"].ToString() + ";" + dvSpec[0]["Gen"].ToString();

            if (dv[i]["external"].ToString().Equals("Y"))
                gvCollect.Rows[i].BackColor = System.Drawing.Color.Tomato;
            if (dv[i]["origin"].ToString().Equals("BCL"))
            {
                gvCollect.Rows[i].BackColor = System.Drawing.Color.Blue;
                gvCollect.Rows[i].ForeColor = System.Drawing.Color.White;
            }
            if (dv[i]["origin"].ToString().Equals("AMC"))
                gvCollect.Rows[i].BackColor = System.Drawing.Color.White;

            if (dv[i]["sub_type"].Equals("H"))
            {
                if (histo == "")
                {
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dvSpec[0]["histo"].ToString();
                    histo = dvSpec[0]["histo"].ToString();
                }
                else
                {                                                            
                    double max = Convert.ToDouble(histo.Substring(5, 5));
                    max = max + 1;
                    p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                    histo = histo.Substring(0,5) + pad.PadLeft(p_zero, '0') + max.ToString();
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = histo;
                }
            }
            else if (dv[i]["sub_type"].Equals("M"))
            {
                if (micro == "")
                {
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dvSpec[0]["Micro"].ToString();
                    micro = dvSpec[0]["Micro"].ToString(); 
                }
                else
                {
                    double max = Convert.ToDouble(micro.Substring(5, 5));
                    max = max + 1;
                    p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                    micro = micro.Substring(0, 5) + pad.PadLeft(p_zero, '0') + max.ToString();
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = micro;
                }
            }
            else if (dv[i]["sub_type"].Equals("G"))
            {
                if (gen == "")
                {
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dvSpec[0]["Gen"].ToString();
                    gen = dvSpec[0]["Gen"].ToString();
                    String department_Name = ddlSubdept.SelectedItem.Text.Trim();
                }
                else
                {
                    double max = Convert.ToDouble(gen.Substring(5, 5));
                    max = max + 1;
                    p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                    gen = gen.Substring(0, 5) + pad.PadLeft(p_zero, '0') + max.ToString();
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = gen;
                }
            }
        }
       
        pnl_sel.Visible = false;
        gvSpecimen.Visible = false;
    
    }

    protected void gvSpecimen_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
           // fill_PatientInfo(index);
            #region fillpatientinfo
            pnl_info.Visible = true;
            imgCLose.Visible = false;
            imgRefresh.Visible = false;

            clsBLSpecimen sc = new clsBLSpecimen();

            lblPRno.Text = gvSpecimen.DataKeys[index].Value.ToString();
            lblLabID.Text = gvSpecimen.Rows[index].Cells[1].Text.Trim();
            lblPatient.Text = gvSpecimen.Rows[index].Cells[2].Text.Trim();

            lblGender.Text = gvSpecimen.Rows[index].Cells[3].Text.Trim();
            lblAge.Text = gvSpecimen.Rows[index].Cells[4].Text.Trim();

            if (gvSpecimen.DataKeys[index].Values[2].ToString().Trim() != "")
            {
                lblPan_Head.Text = "Panel:";
                lblPanel.Text = gvSpecimen.DataKeys[index].Values[1].ToString().Trim();
            }
            else
            {
                lblPan_Head.Text = "";
                lblPanel.Text = "";
            }

            if (gvSpecimen.DataKeys[index].Values[3].ToString().Equals(""))
            {
                lblCmt_HEad.Text = "";
                lblComment.Text = "";
            }
            else
            {
                lblCmt_HEad.Text = "Comment:";
                lblComment.Text = gvSpecimen.DataKeys[index].Values[3].ToString();
            }
            sc.LabID = this.lblLabID.Text.Trim();
            sc.ClientID = Session["ClientiD"].ToString().Trim();// System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
            DataView dv = sc.GetAll(5);
            DataView dvSpec = sc.GetAll(7);

            gvCollect.DataSource = dv;
            gvCollect.DataBind();
            if ( gvCollect.Rows.Count == 1 && _printonspecimencollectsettings=="Y")
            {
                (gvCollect.Rows[0].Cells[9].Controls[0] as LinkButton).Text = "Collect & Print";
                (gvCollect.Rows[0].Cells[9].Controls[0] as LinkButton).CommandName = "Collect & Print";
            }



            MakeTableSession();
            Session["spec_grid"] = dv.Table;

            int p_zero = 0;
            string histo = "";
            string micro = "";
            string pad = "";
            string gen = "";

            for (int i = 0; i < gvCollect.Rows.Count; i++)
            {
                ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Visible = false;

                Session["spec_no"] = dvSpec[0]["histo"].ToString() + ";" + dvSpec[0]["Micro"].ToString() + ";" + dvSpec[0]["Gen"].ToString();

                if (dv[i]["external"].ToString().Equals("Y"))
                    gvCollect.Rows[i].BackColor = System.Drawing.Color.Tomato;
                if (dv[i]["origin"].ToString().Equals("BCL"))
                {
                    gvCollect.Rows[i].BackColor = System.Drawing.Color.Blue;
                    gvCollect.Rows[i].ForeColor = System.Drawing.Color.White;
                }
                if (dv[i]["origin"].ToString().Equals("AMC"))
                    gvCollect.Rows[i].BackColor = System.Drawing.Color.White;

                if (dv[i]["sub_type"].Equals("H"))
                {
                    if (histo == "")
                    {
                      //  ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dvSpec[0]["histo"].ToString();
                        histo = dvSpec[0]["histo"].ToString();
                    }
                    else
                    {
                        double max = Convert.ToDouble(histo.Substring(5, 5));
                        max = max + 1;
                        p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                        histo = histo.Substring(0, 5) + pad.PadLeft(p_zero, '0') + max.ToString();
                    //    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = histo;
                    }
                }
                else if (dv[i]["sub_type"].Equals("M"))
                {
                    if (micro == "")
                    {
                    //    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dvSpec[0]["Micro"].ToString();
                        micro = dvSpec[0]["Micro"].ToString();
                    }
                    else
                    {
                        double max = Convert.ToDouble(micro.Substring(5, 5));
                        max = max + 1;
                        p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                        micro = micro.Substring(0, 5) + pad.PadLeft(p_zero, '0') + max.ToString();
                    //    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = micro;
                    }
                }
                else if (dv[i]["sub_type"].Equals("G"))
                {
                    if (gen == "")
                    {
                    //    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dvSpec[0]["Gen"].ToString();
                        gen = dvSpec[0]["Gen"].ToString();
                    }
                    else
                    {
                        double max = Convert.ToDouble(gen.Substring(5, 5));
                        max = max + 1;
                        p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                        gen = gen.Substring(0, 5) + pad.PadLeft(p_zero, '0') + max.ToString();
                      //  ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = gen;
                    }
                }
            }

            pnl_sel.Visible = false;
            gvSpecimen.Visible = false;
            #endregion
            //Response.Redirect("wfrmSpecimenCollect.aspx");
            pnl_info.Style.Add("display","block");
        }
    }
    protected void gvCollect_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblError.Text = "";
        if (e.CommandName.Equals("Comment"))
        {
            txtInt_Comnt.Text = "";
            ddlFor_Process.SelectedIndex = 0;

            int index = Convert.ToInt32(e.CommandArgument);
            lblTest_intCmt.Text = "Investigation: " + gvCollect.Rows[index].Cells[3].Text.Trim();
            lblInt_Index.Text = index.ToString();
            lblInt_BookingID.Text = gvCollect.DataKeys[index].Values[1].ToString();
            lblInt_testID.Text = gvCollect.DataKeys[index].Value.ToString();
           
            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
            SComponents com = new SComponents();
            iv.TestID = gvCollect.DataKeys[index].Value.ToString();
            iv.BookingID = gvCollect.DataKeys[index].Values[1].ToString();
            iv.For_Process = "3";
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
        if (e.CommandName.Equals("Collect"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            clsBLSpecimen sc = new clsBLSpecimen();

            sc.LabID = this.lblLabID.Text.Trim();
            sc.TestID = gvCollect.DataKeys[index].Value.ToString();
            sc.Specimen_Notes = ((TextBox)(gvCollect.Rows[index].Cells[7].FindControl("txtNotes"))).Text.Trim();
            sc.Spec_number = ((TextBox)(gvCollect.Rows[index].Cells[6].FindControl("txtSpecNo"))).Text.Trim();

            sc.Battery_No = sc.Spec_number;
            if (((DropDownList)(gvCollect.Rows[index].Cells[5].FindControl("ddlNature"))).Visible == true)
            {
                sc.Spec_Nature = ((DropDownList)(gvCollect.Rows[index].Cells[5].FindControl("ddlNature"))).SelectedItem.Value.ToString();
            }

            sc.BookingID = gvCollect.DataKeys[index].Values[1].ToString();
            sc.BookingDID = gvCollect.DataKeys[index].Values[2].ToString();
            sc.Container = gvCollect.DataKeys[index].Values[6].ToString().Equals("0") ? "~!@" : gvCollect.DataKeys[index].Values[6].ToString();
            sc.Unit = gvCollect.DataKeys[index].Values[7].ToString().Equals("-") ? "~!@" : gvCollect.DataKeys[index].Values[7].ToString();
            sc.Qty = gvCollect.DataKeys[index].Values[5].ToString().Equals("0") ? "~!@" : gvCollect.DataKeys[index].Values[5].ToString();

            
            sc.EnteredBy = Session["personid"].ToString();
            sc.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            sc.ClientID = Session["ClientiD"].ToString().Trim();// System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
                //Session["orgid"].ToString();

            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
            iv.TestID = sc.TestID;
            DataView dv = iv.GetAll(25);
            if (dv.Count == 0)
                sc.ProcessID = null;
            else
            {
                for (int m = 0; m < dv.Count; m++)
                {
                    if (dv[m]["processid"].ToString().Trim().Equals("4") || dv[m]["processid"].ToString().Trim().Equals("5"))
                    {
                        sc.ProcessID = dv[m]["processid"].ToString().Trim();
                        break;
                    }
                }
            }

            if (sc.GetSpecimen())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Specimen has been collected successfully";
                int count = 0;
                DataTable dt = (DataTable)Session["spec_grid"];
                foreach (DataRow drOld in dt.Rows)
                {
                    drOld["testid"] = gvCollect.DataKeys[count].Value.ToString();
                    drOld["bookingid"] = gvCollect.DataKeys[count].Values[1].ToString();
                    drOld["bookingdid"] = gvCollect.DataKeys[count].Values[2].ToString();
                    drOld["sub_type"] = gvCollect.DataKeys[count].Values[3].ToString();

                    drOld["subdept"] = gvCollect.Rows[count].Cells[2].Text.Trim();
                    drOld["testname"] = gvCollect.Rows[count].Cells[3].Text.Trim();
                    drOld["specimenqty"] = gvCollect.Rows[count].Cells[4].Text.Trim().Replace("&nbsp;", "");

                    drOld["notes"] = ((TextBox)(gvCollect.Rows[count].Cells[7].FindControl("txtNotes"))).Text.Trim();
                    drOld["spec_no"] = ((TextBox)(gvCollect.Rows[count].Cells[6].FindControl("txtSpecNo"))).Text.Trim();
                   
                    count++;
                }
                Session["spec_grid"] = dt;

                dt.Rows.RemoveAt(index);
                dt.AcceptChanges();

                gvCollect.DataSource = dt;
                gvCollect.DataBind();
                Session["spec_grid"] = dt;

                //sc.LabID = this.lblLabID.Text.Trim();
                //DataView dvC = sc.GetAll(5);
                //gvCollect.DataSource = dvC;
                //gvCollect.DataBind();


                if (gvCollect.Rows.Count == 0)//dvC.Count == 0
                {
                    pnl_info.Visible = false;
                    pnl_sel.Visible = true;
                    gvSpecimen.Visible = true;

                    imgCLose.Visible = true;
                    imgRefresh.Visible = true;

                    Fill_GV();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.add_load(blinkGridViewRows);", true);
                }
                    
                else
                {
                    if (gvCollect.Rows.Count == 1 && _printonspecimencollectsettings=="Y")
                    { 
                        (gvCollect.Rows[0].Cells[9].Controls[0] as LinkButton).Text = "Collect & Print";
                        (gvCollect.Rows[0].Cells[9].Controls[0] as LinkButton).CommandName = "Collect & Print";
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["notes"].ToString().Equals(""))
                        {
                            ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Visible = false;
                        }
                        else
                        {
                            ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Text = dt.Rows[i]["notes"].ToString();
                            ((LinkButton)(gvCollect.Rows[i].Cells[7].FindControl("lbtnAddNotes"))).Visible = false;
                        }
                        ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dt.Rows[i]["spec_no"].ToString();
                    }
                }
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = sc.Error;
            }

        }

        else if (e.CommandName == "Collect & Print")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            clsBLSpecimen sc = new clsBLSpecimen();

            sc.LabID = this.lblLabID.Text.Trim();
            sc.TestID = gvCollect.DataKeys[index].Value.ToString();
            sc.Specimen_Notes = ((TextBox)(gvCollect.Rows[index].Cells[7].FindControl("txtNotes"))).Text.Trim();
            sc.Spec_number = ((TextBox)(gvCollect.Rows[index].Cells[6].FindControl("txtSpecNo"))).Text.Trim();

            sc.Battery_No = sc.Spec_number;
            if (((DropDownList)(gvCollect.Rows[index].Cells[5].FindControl("ddlNature"))).Visible == true)
            {
                sc.Spec_Nature = ((DropDownList)(gvCollect.Rows[index].Cells[5].FindControl("ddlNature"))).SelectedItem.Value.ToString();
            }

            sc.BookingID = gvCollect.DataKeys[index].Values[1].ToString();
            sc.BookingDID = gvCollect.DataKeys[index].Values[2].ToString();
            sc.Container = gvCollect.DataKeys[index].Values[6].ToString().Equals("0") ? "~!@" : gvCollect.DataKeys[index].Values[6].ToString();
            sc.Unit = gvCollect.DataKeys[index].Values[7].ToString().Equals("-") ? "~!@" : gvCollect.DataKeys[index].Values[7].ToString();
            sc.Qty = gvCollect.DataKeys[index].Values[5].ToString().Equals("0") ? "~!@" : gvCollect.DataKeys[index].Values[5].ToString();


            sc.EnteredBy = Session["personid"].ToString();
            sc.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            sc.ClientID = Session["ClientiD"].ToString().Trim();// System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
            //Session["orgid"].ToString();

            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();
            iv.TestID = sc.TestID;
            DataView dv = iv.GetAll(25);
            if (dv.Count == 0)
                sc.ProcessID = null;
            else
            {
                for (int m = 0; m < dv.Count; m++)
                {
                    if (dv[m]["processid"].ToString().Trim().Equals("4") || dv[m]["processid"].ToString().Trim().Equals("5"))
                    {
                        sc.ProcessID = dv[m]["processid"].ToString().Trim();
                        break;
                    }
                }
            }

            if (sc.GetSpecimen())
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Specimen has been collected successfully";
                int count = 0;
                DataTable dt = (DataTable)Session["spec_grid"];
                foreach (DataRow drOld in dt.Rows)
                {
                    drOld["testid"] = gvCollect.DataKeys[count].Value.ToString();
                    drOld["bookingid"] = gvCollect.DataKeys[count].Values[1].ToString();
                    drOld["bookingdid"] = gvCollect.DataKeys[count].Values[2].ToString();
                    drOld["sub_type"] = gvCollect.DataKeys[count].Values[3].ToString();

                    drOld["subdept"] = gvCollect.Rows[count].Cells[2].Text.Trim();
                    drOld["testname"] = gvCollect.Rows[count].Cells[3].Text.Trim();
                    drOld["specimenqty"] = gvCollect.Rows[count].Cells[4].Text.Trim().Replace("&nbsp;", "");

                    drOld["notes"] = ((TextBox)(gvCollect.Rows[count].Cells[7].FindControl("txtNotes"))).Text.Trim();
                    drOld["spec_no"] = ((TextBox)(gvCollect.Rows[count].Cells[6].FindControl("txtSpecNo"))).Text.Trim();

                    count++;
                }
                Session["spec_grid"] = dt;

                dt.Rows.RemoveAt(index);
                dt.AcceptChanges();

                gvCollect.DataSource = dt;
                gvCollect.DataBind();
                Session["spec_grid"] = dt;

                //sc.LabID = this.lblLabID.Text.Trim();
                //DataView dvC = sc.GetAll(5);
                //gvCollect.DataSource = dvC;
                //gvCollect.DataBind();


                if (gvCollect.Rows.Count == 0)//dvC.Count == 0
                {
                    pnl_info.Visible = false;
                    pnl_sel.Visible = true;
                    gvSpecimen.Visible = true;

                    imgCLose.Visible = true;
                    imgRefresh.Visible = true;

                    Fill_GV();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.add_load(blinkGridViewRows);", true);

                    string labid = lblLabID.Text.Trim();
                    string prno = lblPRno.Text.Trim();
                    if (_printonspecimencollectsettings == "Y")
                    {
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('wfrmCashReportLab.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + reference + "&cash=" + OnCashed + "');</script>", false);
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + reference + "&watermark=" + "&cash=" + OnCashed + "');</script>", false);

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('wfrmCashReportLab.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + "-" + "&cash=" + "Y" + "');</script>", false);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + "-" + "&watermark=" + "&cash=" + "Y" + "');</script>", false);
                    }
                }

                else
                {
                    if (gvCollect.Rows.Count == 1 && _printonspecimencollectsettings=="Y")
                    {
                        (gvCollect.Rows[0].Cells[9].Controls[0] as LinkButton).Text = "Collect & Print";
                        (gvCollect.Rows[0].Cells[9].Controls[0] as LinkButton).CommandName = "Collect & Print";
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["notes"].ToString().Equals(""))
                        {
                            ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Visible = false;
                        }
                        else
                        {
                            ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Text = dt.Rows[i]["notes"].ToString();
                            ((LinkButton)(gvCollect.Rows[i].Cells[7].FindControl("lbtnAddNotes"))).Visible = false;
                        }
                        ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dt.Rows[i]["spec_no"].ToString();
                    }
                }
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = sc.Error;
            }

        }
        
    }
    protected void lbtnAddNotes_Click(object sender, EventArgs e)
    {
        GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);
        ((TextBox)(gvCollect.Rows[gridItem.DataItemIndex].Cells[5].FindControl("txtNotes"))).Visible = true;
        ((LinkButton)(gvCollect.Rows[gridItem.DataItemIndex].Cells[5].FindControl("lbtnAddNotes"))).Visible = false;
        
    }

    protected void imgPnl_CLose_Click(object sender, ImageClickEventArgs e)
    {
        pnl_info.Visible = false;
        imgCLose.Visible = true;
        imgRefresh.Visible = true;

        lblAge.Text = "";
        lblGender.Text = "";
        lblLabID.Text = "";

        lblPan_Head.Text = "";
        lblPanel.Text = "";
        lblPatient.Text = "";
        lblPRno.Text = "";

        gvCollect.DataSource = null;
        gvCollect.DataBind();

        pnl_sel.Visible = true;
        gvSpecimen.Visible = true;
        Fill_GV();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.add_load(blinkGridViewRows);", true);
    }
    protected void btnToday_Click(object sender, EventArgs e)
    {
        txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        Fill_GV();
    }

    protected void btnlastDays_Click(object sender, EventArgs e)
    {
        txtFrom.Text = System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
        
        txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        Fill_GV();
    }
    protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        Fill_GV();
       
    }
    protected void lbtnCollectAll_Click(object sender, EventArgs e)
    {
        if (gvCollect.Rows.Count > 0)
        {           
            clsBLSpecimen sc = new clsBLSpecimen();
              
            sc.LabID = this.lblLabID.Text.Trim();
           // sc.TestID = gvCollect.DataKeys[index].Value.ToString();
          //  sc.Specimen_Notes = ((TextBox)(gvCollect.Rows[index].Cells[5].FindControl("txtNotes"))).Text.Trim();
           // sc.BookingID = gvCollect.DataKeys[index].Values[1].ToString();
           // sc.BookingDID = gvCollect.DataKeys[index].Values[2].ToString();

            sc.EnteredBy = Session["personid"].ToString();
            sc.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            sc.ClientID = Session["ClientiD"].ToString().Trim(); //System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
                //Session["orgid"].ToString();

            clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

            string[,] str = new string[gvCollect.Rows.Count, 11];
            int count = 0;
            for (int i = 0; i < gvCollect.Rows.Count; i++)
            {
                str[count, 0] = gvCollect.DataKeys[i].Value.ToString(); // testid
                str[count, 1] = ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Text.Trim(); // notes
                str[count, 2] = gvCollect.DataKeys[i].Values[1].ToString(); // bookingid
                str[count, 3] = gvCollect.DataKeys[i].Values[2].ToString(); // bookingDID
                                
                str[count,4] = ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text.Trim();
                if (((DropDownList)(gvCollect.Rows[i].Cells[5].FindControl("ddlNature"))).Visible == true)
                    str[count, 5] = ((DropDownList)(gvCollect.Rows[i].Cells[5].FindControl("ddlNature"))).SelectedItem.Value.ToString();
                else
                    str[count, 5] = "";
                str[count, 6] = ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text.Trim();
                str[count, 7] = gvCollect.DataKeys[i].Values[5].ToString().Equals("0") ? "~!@" : gvCollect.DataKeys[i].Values[5].ToString(); // qty
                str[count, 8] = gvCollect.DataKeys[i].Values[6].ToString().Equals("0") ? "~!@" : gvCollect.DataKeys[i].Values[6].ToString(); // container
                str[count, 9] = gvCollect.DataKeys[i].Values[7].ToString().Equals("-") ? "~!@" : gvCollect.DataKeys[i].Values[7].ToString(); // unit

                iv.TestID = str[count, 0];
                DataView dv = iv.GetAll(25);
                if (dv.Count == 0)
                    str[count,10] = null; // processID
                else
                {
                    for (int m = 0; m < dv.Count; m++)
                    {
                        if (dv[m]["processid"].ToString().Trim().Equals("4") || dv[m]["processid"].ToString().Trim().Equals("5"))
                        {
                            str[count,10] = dv[m]["processid"].ToString().Trim(); // processID
                            break;
                        }
                    }
                }

               
                count++;
            }

            if (sc.GetSpecimen_All(str))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Successfull", "<script>alert('All specimen has been collected successfully');</script>", false);

                pnl_info.Visible = false;
                pnl_sel.Visible = true;
                gvSpecimen.Visible = true;

                imgCLose.Visible = true;
                imgRefresh.Visible = true;

                Fill_GV();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.add_load(blinkGridViewRows);", true);

                string labid = lblLabID.Text.Trim();
                string prno = lblPRno.Text.Trim();
                if (_printonspecimencollectsettings == "Y")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('wfrmCashReportLab.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + "-" + "&cash=" + "Y" + "');</script>", false);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx?prno=" + prno + "&labid=" + labid + "&referenceno=" + "-" + "&cash=" + "Y" + "');</script>", false);
                }
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = sc.Error;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>alert('" + lblError.Text + "');</script>", false);
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>alert('No specimen found');</script>", false);
        }
    }

    protected void gvCollect_RowDataBound(object sender, GridViewRowEventArgs e)
    {
   
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataView dv = (DataView)Session["spec_nature"];
            string Scode = "";
            clsBLSpecimen clsSpecimen = new clsBLSpecimen();
            clsSpecimen.Specimen_code = gvCollect.DataKeys[e.Row.RowIndex].Values[8].ToString();
            DataView dvSC = clsSpecimen.GetAll(9);
            DataTable dt;
            dt = dvSC.ToTable();
            string Pcode = "";
            Scode = clsSpecimen.Specimen_code;
            list.Add(Scode);
            code = dt.Rows[0][0].ToString().Trim();
            Pcode = code;
            if (Scode.Equals(""))
            {
                code = dt.Rows[0][0].ToString().Trim();
                Pcode = code;
            }
            for (int i = 0; i <= list.Count; i++)
            {
                try{
                    
                 // if (!list[i-1].ToString().Equals(list[i].ToString()))
               // {
                 //   code = dt.Rows[0][0].ToString().Trim();
                   // Pcode = code;
                //}
                    
                if (list[i].Contains(clsSpecimen.Specimen_code))
                {
                   long temp = Convert.ToInt64(code);
                        temp = temp + 1;
                        code = temp.ToString().PadLeft(5, '0');
                        Pcode = code;
                }
              }
                catch(Exception exe)
                {
                }

            }


            

                DateTime moment = DateTime.Now;
                int year = moment.Year;

                string getYear = moment.ToString("yy");
                if (!e.Row.Cells[4].ToString().Equals(""))
                {
                    ((TextBox)(e.Row.Cells[6].FindControl("txtSpecNo"))).Text = Scode + "-" + getYear + "-" + Pcode;
                }
                //  Response.Write(Scode + "-"+getYear+"-"+code);
                dv.RowFilter = "type='" + gvCollect.DataKeys[e.Row.RowIndex].Values[3].ToString() + "'";
                if (gvCollect.DataKeys[e.Row.RowIndex].Values[3].ToString() != "G")
                {
                    SComponents com = new SComponents();

                    DropDownList dd = (DropDownList)e.Row.FindControl("ddlNature");

                    com.FillDropDownListWithoutSelect(dd, dv, "name", "specimennatureid", true, false);
                }
                else
                {
                    DropDownList dd = (DropDownList)e.Row.FindControl("ddlNature");
                    dd.Visible = false;
                }

               
            
        }
    }
   
    protected void gvCollect_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dt = (DataTable)Session["spec_grid"];
       

        DataRow dr = dt.NewRow();

        dr["testid"] = gvCollect.DataKeys[e.NewEditIndex].Value.ToString();
        dr["bookingid"] = gvCollect.DataKeys[e.NewEditIndex].Values[1].ToString();
        dr["bookingdid"] = gvCollect.DataKeys[e.NewEditIndex].Values[2].ToString();
        dr["sub_type"] = gvCollect.DataKeys[e.NewEditIndex].Values[3].ToString();

        dr["subdept"] = gvCollect.Rows[e.NewEditIndex].Cells[1].Text.Trim();       
        dr["testname"] = gvCollect.Rows[e.NewEditIndex].Cells[2].Text.Trim();
        dr["specimenqty"] = gvCollect.Rows[e.NewEditIndex].Cells[3].Text.Trim().Replace("&nbsp;","");

        dt.Rows.InsertAt(dr, e.NewEditIndex + 1);
        dt.AcceptChanges();

        gvCollect.DataSource = dt;
        gvCollect.DataBind();

        string[] str = Session["spec_no"].ToString().Split(';');

        for (int i = 0; i < gvCollect.Rows.Count; i++)
        {
            if (((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtNotes"))).Text.Replace("&nbsp;", "").Equals(""))
            {
                ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtNotes"))).Visible = false;
                if(gvCollect.DataKeys[i].Values[3].ToString().Equals("H"))
                    ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text = str.GetValue(0).ToString();
                if (gvCollect.DataKeys[i].Values[3].ToString().Equals("M"))
                    ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text = str.GetValue(1).ToString();
                if (gvCollect.DataKeys[i].Values[3].ToString().Equals("G"))
                    ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text = str.GetValue(2).ToString();
            }
        }

        Session["spec_grid"] = dt;
    }
    protected void gvCollect_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
        int count = 0;
        DataTable dt = (DataTable)Session["spec_grid"];
        foreach (DataRow drOld in dt.Rows)
        {
            drOld["testid"] = gvCollect.DataKeys[count].Value.ToString();
            drOld["bookingid"] = gvCollect.DataKeys[count].Values[1].ToString();
            drOld["bookingdid"] = gvCollect.DataKeys[count].Values[2].ToString();
            drOld["sub_type"] = gvCollect.DataKeys[count].Values[3].ToString();

            drOld["subdept"] = gvCollect.Rows[count].Cells[2].Text.Trim();
            drOld["testname"] = gvCollect.Rows[count].Cells[3].Text.Trim();
            drOld["specimenqty"] = gvCollect.Rows[count].Cells[4].Text.Trim().Replace("&nbsp;", "");

            drOld["notes"] = ((TextBox)(gvCollect.Rows[count].Cells[7].FindControl("txtNotes"))).Text.Trim();
            drOld["spec_no"] = ((TextBox)(gvCollect.Rows[count].Cells[6].FindControl("txtSpecNo"))).Text.Trim();
            drOld["qty"] = gvCollect.DataKeys[count].Values[5].ToString();
            drOld["scontainerid"] = gvCollect.DataKeys[count].Values[6].ToString();
            drOld["unit"] = gvCollect.DataKeys[count].Values[7].ToString();
    
            count++;
        }
        Session["spec_grid"] = dt;

        dt.Rows.RemoveAt(e.RowIndex);
        dt.AcceptChanges();

        gvCollect.DataSource = dt;
        gvCollect.DataBind();

        Session["spec_grid"] = dt;


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["notes"].ToString().Equals(""))
            {
                ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Visible = false;
            }
            else
            {
                ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Text = dt.Rows[i]["notes"].ToString();
                ((LinkButton)(gvCollect.Rows[i].Cells[7].FindControl("lbtnAddNotes"))).Visible = false;
            }
            ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = dt.Rows[i]["spec_no"].ToString();
        }
        //////////
        //string[] str = Session["spec_no"].ToString().Split(';');

        //for (int i = 0; i < gvCollect.Rows.Count; i++)
        //{
        //    if (((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtNotes"))).Text.Replace("&nbsp;", "").Equals(""))
        //    {
        //        ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtNotes"))).Visible = false;
        //        if (gvCollect.DataKeys[i].Values[3].ToString().Equals("H"))
        //            ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text = str.GetValue(0).ToString();
        //        if (gvCollect.DataKeys[i].Values[3].ToString().Equals("M"))
        //            ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text = str.GetValue(1).ToString();
        //        if (gvCollect.DataKeys[i].Values[3].ToString().Equals("G"))
        //            ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text = str.GetValue(2).ToString();
        //    }
        //}
    }
    protected void ddlNature_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.Parent.Parent;
        int idx = row.RowIndex;
        string pad = "";
        string Code = "";
        int p_zero =0;
        
        for (int i = 0; i < gvCollect.Rows.Count; i++)
        {
            if (gvCollect.DataKeys[i].Values[3].ToString() == gvCollect.DataKeys[idx].Values[3].ToString())
            {
                if (((DropDownList)(gvCollect.Rows[i].Cells[6].FindControl("ddlNature"))).SelectedItem.Value.ToString() == ((DropDownList)(gvCollect.Rows[idx].Cells[6].FindControl("ddlNature"))).SelectedItem.Value.ToString())
                {
                    ((TextBox)(gvCollect.Rows[idx].Cells[5].FindControl("txtSpecNo"))).Text = ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text;
                    break;
                }
                else
                {
                    double max = Convert.ToDouble(((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text.Substring(5,5));
                    Code = ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text.Substring(0, 5);

                    max = max + 1;
                    p_zero = 5 - Convert.ToInt32(max.ToString().Length);

                    Code =Code+ pad.PadLeft(p_zero, '0') + max.ToString();
                    ((TextBox)(gvCollect.Rows[idx].Cells[5].FindControl("txtSpecNo"))).Text = Code;
                }
            }
        }
    }

    protected void btnSingle_Click(object sender, EventArgs e)
    {
        //string previousDept = "";
      
        string micro = "";
        string Code = "";
        string histo = "";
        string gen = "";

        for (int j = 0; j < gvCollect.Rows.Count; j++)
        {
            if (((CheckBox)(gvCollect.Rows[j].Cells[0].FindControl("chkSpec"))).Checked && gvCollect.DataKeys[j].Values[3].ToString().Equals("H"))
            {
                histo = ((TextBox)(gvCollect.Rows[j].Cells[6].FindControl("txtSpecNo"))).Text;
                break;
            }
           else if (((CheckBox)(gvCollect.Rows[j].Cells[0].FindControl("chkSpec"))).Checked && gvCollect.DataKeys[j].Values[3].ToString().Equals("M") && micro=="")
            {
                micro = ((TextBox)(gvCollect.Rows[j].Cells[6].FindControl("txtSpecNo"))).Text;               
            }
            else if (((CheckBox)(gvCollect.Rows[j].Cells[0].FindControl("chkSpec"))).Checked && gvCollect.DataKeys[j].Values[3].ToString().Equals("G") && gen=="")
            {
                gen = ((TextBox)(gvCollect.Rows[j].Cells[6].FindControl("txtSpecNo"))).Text;
            }
        }

        for (int i = 0; i < gvCollect.Rows.Count; i++)
        {
            if (((CheckBox)(gvCollect.Rows[i].Cells[0].FindControl("chkSpec"))).Checked)
            {
                if (micro=="" && histo=="")
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = gen;
                if (histo != "")
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = histo;
                else if(micro !="" && histo=="")
                    ((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text = micro;               
            }
            
        }

        # region "Old Type wise"
        //for (int i = 0; i < gvCollect.Rows.Count; i++)
        //    {
        //        if (previousDept == "" && ((CheckBox)(gvCollect.Rows[i].Cells[0].FindControl("chkSpec"))).Checked)
        //        {
        //            Code = ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text;
        //            previousDept = gvCollect.DataKeys[i].Values[4].ToString();
        //        }
        //        else if (gvCollect.DataKeys[i].Values[4].ToString() == previousDept && ((CheckBox)(gvCollect.Rows[i].Cells[0].FindControl("chkSpec"))).Checked)
        //        {
        //            Code = ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text = Code;
        //            previousDept = gvCollect.DataKeys[i].Values[4].ToString();
        //        }
        //        else if (gvCollect.DataKeys[i].Values[4].ToString() != previousDept && ((CheckBox)(gvCollect.Rows[i].Cells[0].FindControl("chkSpec"))).Checked)
        //        {
        //            Code = ((TextBox)(gvCollect.Rows[i].Cells[5].FindControl("txtSpecNo"))).Text;
        //            previousDept = gvCollect.DataKeys[i].Values[4].ToString();
        //        }
        //    }
        #endregion
        }
    protected void btnMultiple_Click(object sender, EventArgs e)
    {
        int count = 0;        
        DataTable dt = (DataTable)Session["spec_grid"];

        foreach (DataRow drOld in dt.Rows)
        {
            drOld["testid"] = gvCollect.DataKeys[count].Value.ToString();
            drOld["bookingid"] = gvCollect.DataKeys[count].Values[1].ToString();
            drOld["bookingdid"] = gvCollect.DataKeys[count].Values[2].ToString();
            drOld["sub_type"] = gvCollect.DataKeys[count].Values[3].ToString();

            drOld["subdept"] = gvCollect.Rows[count].Cells[2].Text.Trim();
            drOld["testname"] = gvCollect.Rows[count].Cells[3].Text.Trim();
            drOld["specimenqty"] = gvCollect.Rows[count].Cells[4].Text.Trim().Replace("&nbsp;", "");

            drOld["notes"] = ((TextBox)(gvCollect.Rows[count].Cells[7].FindControl("txtNotes"))).Text.Trim();
            drOld["spec_no"] = ((TextBox)(gvCollect.Rows[count].Cells[6].FindControl("txtSpecNo"))).Text.Trim();

            drOld["qty"] = gvCollect.DataKeys[count].Values[5].ToString();
            drOld["scontainerid"] = gvCollect.DataKeys[count].Values[6].ToString();
            drOld["unit"] = gvCollect.DataKeys[count].Values[7].ToString();
       
            count++;
        }
        Session["spec_grid"] = dt;
        for (int i = 0; i < gvCollect.Rows.Count; i++)
        {
            if (((CheckBox)(gvCollect.Rows[i].Cells[0].FindControl("chkSpec"))).Checked)
            {
                DataRow dr = dt.NewRow();

                dr["testid"] = gvCollect.DataKeys[i].Value.ToString();
                dr["bookingid"] = gvCollect.DataKeys[i].Values[1].ToString();
                dr["bookingdid"] = gvCollect.DataKeys[i].Values[2].ToString();
                dr["sub_type"] = gvCollect.DataKeys[i].Values[3].ToString();

                dr["subdept"] = gvCollect.Rows[i].Cells[2].Text.Trim();
                dr["testname"] = gvCollect.Rows[i].Cells[3].Text.Trim();
                dr["specimenqty"] = gvCollect.Rows[i].Cells[4].Text.Trim().Replace("&nbsp;", "");
                dr["notes"] = ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Text.Trim();
                dr["qty"] = gvCollect.DataKeys[i].Values[5].ToString();
                dr["scontainerid"] = gvCollect.DataKeys[i].Values[6].ToString();
                dr["unit"] = gvCollect.DataKeys[i].Values[7].ToString();

                string pad = "";
                string Code = "";
                int p_zero = 0;
                int no_count = 0;
                double previous_Code = 0;
                string[] str = Session["spec_no"].ToString().Split(';');

                for (int m = 0; m < dt.Rows.Count; m++)
                {
                    if (dt.Rows[m]["sub_type"].ToString() == dr["sub_type"].ToString())
                    {
                        Code = dt.Rows[m]["spec_no"].ToString().Substring(0, 5);
                        if (Code.Substring(0, 1) == dr["sub_type"].ToString())
                        {                            
                            if (no_count == 0 && previous_Code==0)
                            {
                                double max = Convert.ToDouble(dt.Rows[m]["spec_no"].ToString().Substring(5, 5));
                                max = max + 1;
                                p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                                Code = Code + pad.PadLeft(p_zero, '0') + max.ToString();
                                previous_Code = max;
                            }
                            else
                            {
                                if (Convert.ToDouble(dt.Rows[m]["spec_no"].ToString().Substring(5, 5)) >= previous_Code)
                                {
                                    Code = dt.Rows[m]["spec_no"].ToString().Substring(0, 5);
                                    double max = Convert.ToDouble(dt.Rows[m]["spec_no"].ToString().Substring(5, 5));
                                    max = max + 1;
                                    p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                                    Code = Code + pad.PadLeft(p_zero, '0') + max.ToString();
                                    previous_Code = max;
                                }
                                else
                                {
                                    Code = dt.Rows[m]["spec_no"].ToString().Substring(0, 5);
                                    double max = Convert.ToDouble(dt.Rows[m]["spec_no"].ToString().Substring(5, 5));
                                    //max = max + 1;
                                    max = previous_Code;
                                    p_zero = 5 - Convert.ToInt32(max.ToString().Length);
                                    Code = Code + pad.PadLeft(p_zero, '0') + max.ToString();
                                    previous_Code = max;
                                }
                            }
                            no_count++;
                        }
                        else
                        {
                            if (dr["sub_type"].ToString() == "H")
                                Code = str.GetValue(0).ToString();
                            else if (dr["sub_type"].ToString() == "M")
                                Code = str.GetValue(1).ToString();
                            else
                                Code = str.GetValue(2).ToString();
                        }

                    }
                }

                dr["spec_no"] = Code;                
                //((TextBox)(gvCollect.Rows[i].Cells[6].FindControl("txtSpecNo"))).Text.Trim();                
                dt.Rows.InsertAt(dr, i + 1);
                dt.AcceptChanges();
            }

        }
        gvCollect.DataSource = dt;
        gvCollect.DataBind();

        Session["spec_grid"] = dt;



        for (int j = 0; j < dt.Rows.Count; j++)
        {
            if (dt.Rows[j]["notes"].ToString().Equals(""))
            {
                ((TextBox)(gvCollect.Rows[j].Cells[7].FindControl("txtNotes"))).Visible = false;
            }
            else
            {
                ((TextBox)(gvCollect.Rows[j].Cells[7].FindControl("txtNotes"))).Text = dt.Rows[j]["notes"].ToString();
                ((LinkButton)(gvCollect.Rows[j].Cells[7].FindControl("lbtnAddNotes"))).Visible = false;
            }
            ((TextBox)(gvCollect.Rows[j].Cells[6].FindControl("txtSpecNo"))).Text = dt.Rows[j]["spec_no"].ToString();
        }

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    if (((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Text.Replace("&nbsp;", "").Equals(""))
        //    {
        //        ((TextBox)(gvCollect.Rows[i].Cells[7].FindControl("txtNotes"))).Visible = false;                
        //    }
        //}
    }
    protected void btnIndoorRpt_Click(object sender, EventArgs e)
    {
        clsBLSpecimen sp = new clsBLSpecimen();
        DataView dv = sp.GetAll(8);
        if (dv.Count > 0)
        {
            Session["reportname"] = "Indoor_Spec";
            Session["selectionformula"] = "1=1";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('../Report/GeneralReports.aspx');</script>", false);
        }
        else
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('No record found');</script>", false);
    }
    protected void lbtnPatientTrack_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Result", "<script>window.open('wfrmTrack.aspx');</script>", false);
    }
    protected void gvSpecimen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.ID = "Row_" + e.Row.RowIndex.ToString();
            //int index = Convert.ToInt32(gvSpecimen.DataKeys[e.Row.RowIndex].Values[4].ToString());
            //// Here I'm just determining the blinking rows by every other row...
            ////(e.Row.RowIndex % 2) ==
            //if (index > 0)
            //{
            //    e.Row.Attributes.Add("blinkingRow", "Y");
            //    e.Row.Font.Bold = true;
            //   // e.Row.BackColor = System.Drawing.Color.Aqua;
            //}
            //else
            //    e.Row.Attributes.Add("blinkingRow", "N");

            //e.Row.Attributes.Add("blinkCounter", "0");
            

        }
    }
    private void Urgent_Count()
    {
        //int ct = 0;
        //for (int i = 0; i < gvSpecimen.Rows.Count; i++)
        //{
        //    if (Convert.ToInt32(gvSpecimen.DataKeys[i].Values[4].ToString()) > 0)
        //        ct++;
        //}
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Urgent test:" + ct + " ');</script>", false);
    }

    protected void imgCmt_Close_Click(object sender, ImageClickEventArgs e)
    {
        this.txtInt_Comnt.Text = "";

        mde_intcmt.Hide();
    }
    protected void imgcmt_save_Click(object sender, ImageClickEventArgs e)
    {    
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "addunload1", "Sys.Application.remove_load(blinkGridViewRows);", true);
       
        clsBLPatientReg_Inv iv = new clsBLPatientReg_Inv();

        iv.TestID = lblInt_testID.Text.Trim();
        iv.BookingID = this.lblInt_BookingID.Text.Trim();
        iv.Int_Comment = txtInt_Comnt.Text.Trim();
        iv.For_Process = ddlFor_Process.SelectedItem.Value.ToString().Replace("-1", "null");

        iv.ProcessID = "3";
        iv.EnteredBy = Session["personid"].ToString();
        iv.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        iv.ClientID = Session["clientid"].ToString().Trim();// System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
            //Session["orgid"].ToString();

        if (txtInt_Comnt.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('Please enter comment');</script>", false);
            return;
        }
        else
        {
            if (iv.Insert_IntComent())
            {                               
                //mde_intcmt.Hide();     
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('"+iv.Error+"');</script>", false);
            }
        }       
         

    }

   
}
