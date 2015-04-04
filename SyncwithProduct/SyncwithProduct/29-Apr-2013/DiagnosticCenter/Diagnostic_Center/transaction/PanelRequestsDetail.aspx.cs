using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using ServiceReference2;
public partial class transaction_PanelRequestsDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillPanels();
            cmbPanel.ClearSelection();
            try
            {
                cmbPanel.Items.FindByValue(Request.QueryString["panel"].ToString().Trim()).Selected = true;
            }
            catch
            {
                Response.Write("You are not allowed to access this page");
               // Response.Redirect("wfrmCashierEntry.aspx");
            }

            FillGV();
            
               // Request.QueryString["panel"].ToString().Trim()
        }
    }
    private void FillPanels()
    {
        SComponents objcom = new SComponents();
        clsBLPanel obj_panel = new clsBLPanel();
        //obj_panel.ClientID = Session["ClientID"].ToString().Trim();
        DataView dv_panels = obj_panel.GetAll(5);
//       objcom.FillComboBox(cmbPanel, dv_panels, "Name", "Panel_Cliq_ID");
    }
    private void FillGV()
    {
        OliveService objolive = new OliveService();
        DataSet ds = objolive.GetPanelRequestsDetail(cmbPanel.SelectedValue.ToString().Trim(), Session["cliqbranchid"].ToString().Trim());//System.Configuration.ConfigurationManager.AppSettings["orgcliqid"].ToString().Trim()
        gvRequestsmaster.DataSource = ds;
        gvRequestsmaster.DataBind();
    }
    protected void gvRequestsmaster_pageindexchanged(object sender, GridViewPageEventArgs e)
    {
        gvRequestsmaster.PageIndex = e.NewPageIndex;
        FillGV();
    }
    protected void gvRequestsmaster_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            OliveService objolive = new OliveService();
            DataSet ds = objolive.GetRequestDetails(gvRequestsmaster.DataKeys[e.Row.RowIndex].Value.ToString().Trim());
            GridView testgrid = e.Row.FindControl("gvtestdetail") as GridView;
            testgrid.DataSource = ds;
            testgrid.DataBind();
        }
    }
    protected void ibtnReject_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow row = ((sender as ImageButton).Parent.Parent)as GridViewRow;
        int index = row.RowIndex;
        OliveService objolive = new OliveService();
        string masterid = gvRequestsmaster.DataKeys[row.RowIndex].Value.ToString().Trim();
        //objolive.UpdateRequest(
        if (objolive.UpdateRequest("reject", masterid,Session["personID"].ToString().Trim()).Equals("true"))
        {
            lblError.Text = "<font color='green'>Request Successfully Rejected</font>";
            FillGV();
        }
        else
        {
            lblError.Text = "Some Error Occured while Updating";
        }
    }
    protected void ibtnApprove_Click(object sender, ImageClickEventArgs e)
    {
        clsBLPatientReg_Inv obj_patient = new clsBLPatientReg_Inv();
       
        GridViewRow row = ((sender as ImageButton).Parent.Parent) as GridViewRow;
        int index = row.RowIndex;
        obj_patient.Dependent_cliq_id= gvRequestsmaster.DataKeys[row.RowIndex].Values["cliq_dependent_id"].ToString().Trim();
        obj_patient.DOB = gvRequestsmaster.DataKeys[row.RowIndex].Values["dob"].ToString().Trim();
        obj_patient.Gender = gvRequestsmaster.DataKeys[row.RowIndex].Values["gender"].ToString().Trim().ToLower() == "male" ? "M" : "F";
        obj_patient.MaritalStatus = gvRequestsmaster.DataKeys[row.RowIndex].Values["marital_status"].ToString().Trim().ToLower() == "married" ? "M" : "S";
        obj_patient.Name = (gvRequestsmaster.Rows[row.RowIndex].FindControl("lblPatientName") as Label).Text.Trim();
        obj_patient.EnteredBy = Session["personid"].ToString().Trim();
        obj_patient.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_patient.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
        obj_patient.Branch_ID = Session["Branchid"].ToString().Trim();
        obj_patient.BranchID = Session["clientid"].ToString().Trim();
        obj_patient.OrgID = Session["orgid"].ToString().Trim();
        obj_patient.Orgin_Place = Session["clientid"].ToString().Trim();
        DataView dv_checkpatient = obj_patient.GetAll(53);//Check wheteher the patient already exists in the table
        if (dv_checkpatient.Count > 0)
        {
            obj_patient.PRNO = dv_checkpatient[0]["Prno"].ToString().Trim();
            obj_patient.PRID = dv_checkpatient[0]["prid"].ToString().Trim();
            if (obj_patient.Patient_Update())
            {
                obj_patient.Type = "O";//Outdoor Patient just for testing, after indoor catering we will set it accordingly
                obj_patient.PaymentMode = "A";//Before catering indoor scenario need to be changed
                obj_patient.Patient_Type = "A";
                obj_patient.TotalAmount = gvRequestsmaster.DataKeys[row.RowIndex].Values["totalamount"].ToString().Trim();
                obj_patient.DeliveryBy = "S";
                obj_patient.AuthorizeNo = (gvRequestsmaster.Rows[row.RowIndex].FindControl("lblAuthorizationNo") as Label).Text.Trim();
                clsBLPanel obj_panel = new clsBLPanel();
                obj_panel.Panel_cliq_id = cmbPanel.SelectedValue.ToString().Trim();//cmbPanel.SelectedValue.ToString().Trim()
                try
                {
                    obj_patient.PanelID = obj_panel.GetAll(10)[0]["panelid"].ToString().Trim();
                }
                catch
                {
                    lblError.Text = "No mapped panel found!!! Please contact administrator";
                    return;
                }
                //obj_panel = null;
                obj_patient.SpecimenInternal = "Y";
                obj_patient.Status = "P";//For Panel Patients
                if (System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString() == "006" || Convert.ToInt16(System.DateTime.Now.ToString("yyyy")) < 2014)
                {
                    obj_patient.BranchID = Session["ClientiD"].ToString().Trim();//System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
                }
                else
                {
                    obj_patient.BranchID = Session["BranchCode"].ToString().Trim();
                }
                try
                {
                    obj_patient.PathCliqueId = Convert.ToInt32(gvRequestsmaster.DataKeys[row.RowIndex].Values["referredby"].ToString().Trim()).ToString().Trim();
                }
                catch
                {
                    obj_patient.ReferredBy = gvRequestsmaster.DataKeys[row.RowIndex].Values["referredby"].ToString().Trim();
                }

                obj_patient.ReferenceNo = "";
                ///////////////////////////////////////making a 2d array for tests(dc_tpatient_bookingd)/////////////////////////////////////////
                GridView gvtestdetail = gvRequestsmaster.Rows[row.RowIndex].FindControl("gvtestdetail") as GridView;
                int count = 0;
                string[,] str = new string[gvtestdetail.Rows.Count, 12];
                for (int i = 0; i < gvtestdetail.Rows.Count; i++)
                {
                    str[count, 0] = gvtestdetail.DataKeys[i].Value.ToString(); // testid
                    str[count, 1] = "";//Classificationid
                    str[count, 2] = gvtestdetail.DataKeys[i].Values["charges"].ToString();
                    str[count, 3] = "0"; // discount as per test
                    str[count, 4] = "N"; // priority
                    obj_patient.TestID = gvtestdetail.DataKeys[i].Value.ToString(); // testid
                    DataView dv = obj_patient.GetAll(25);
                    if (dv.Count == 0)
                        str[count, 5] = "~!@";
                    else
                    {
                        for (int m = 0; m < dv.Count; m++)
                        {
                            if (!dv[m]["processid"].Equals("1") && !dv[m]["processid"].Equals("2"))
                            {
                                if (dv[m]["processid"].ToString().Trim().Equals("3") || dv[m]["processid"].ToString().Trim().Equals("4") || dv[m]["processid"].ToString().Trim().Equals("5") || dv[m]["processid"].ToString().Trim().Equals("6") || dv[m]["processid"].ToString().Trim().Equals("7"))
                                {
                                    str[count, 5] = dv[m]["processid"].ToString().Trim();
                                    break;
                                }
                            }
                        }
                    }
                    str[count, 6] = ""; // comment internal
                    str[count, 7] = "3"; // for process//hardcoded for specimen collection
                    DataView dv_destinationbr = obj_patient.GetAll(54);
                    str[count, 8] = dv_destinationbr[0]["External"].ToString().Trim()=="Y"?dv_destinationbr[0]["DestinationBranchiD"].ToString().Trim():"0";//if test is external then set destination branchid otherwise set destinationbranchid =0
                    str[count, 9] = "0";
                    str[count, 10] = "";//discount percentage agaisnt single test
                    str[count, 11] = "";//discount adjusted amount
                    count++;
                   
                }
                obj_patient.Sendstatus = "P";
                if (obj_patient.Booking_Cash_Insert(str))
                {
                    OliveService objolive = new OliveService();
                    string masterid = gvRequestsmaster.DataKeys[row.RowIndex].Value.ToString().Trim();
                    if (objolive.UpdateRequest("approve", masterid, Session["personID"].ToString().Trim()).Equals("true"))
                    {
                        lblError.Text = "<font color='green'>Request Successfully added.</font>";
                        FillGV();
                    }
                    else
                    {
                        lblError.Text = "Some Error Occured while Updating Panel Database.";
                    }
                    clsReporting obj_reportpreference = new clsReporting();
                    obj_reportpreference.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    DataView dv_cashreport = obj_reportpreference.GetAll(40);
                    DataView dv_labreport = dv_cashreport;


                    dv_labreport.RowFilter = "ReportTypeID=2";
                    if (dv_labreport.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('" + dv_labreport[0]["Reportformat_path"].ToString().Trim() + "?prno=" + obj_patient.PRNO + "&labid=" + obj_patient.LabID + "&referenceno=" + "&watermark=" + "&cash=" + "');</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('wfrmCashReportlab.aspx?prno=" + obj_patient.PRNO + "&labid=" + obj_patient.LabID + "&referenceno=" + "&watermark=" + "&cash=" + "');</script>", false);

                    }
                    dv_cashreport.RowFilter = "ReportTypeID=1";
                    if (dv_cashreport.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('" + dv_cashreport[0]["Reportformat_path"].ToString().Trim() + "?prno=" + obj_patient.PRNO + "&labid=" + obj_patient.LabID + "&referenceno=" + "&watermark=" + "&cash=" + "');</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx?prno=" + obj_patient.PRNO + "&labid=" + obj_patient.LabID + "&referenceno=" + "&watermark=" + "&cash=" + "');</script>", false);
                    }
                }
                else
                {
                    lblError.Text = "Failure due to :" + obj_patient.Error;
 
                }
                /////////////////////////////////////////////////------------------//////////////////////////////////////////////////////////////

            }
            else
            {
                lblError.Text = "Update Failure due to :" + obj_patient.Error;
            }
        }
        else
        {
            if (obj_patient.Patient_Insert())
            {
                obj_patient.Type = "O";//Outdoor Patient just for testing, after indoor catering we will set it accordingly
                obj_patient.PaymentMode = "A";//Before catering indoor scenario need to be changed
                obj_patient.Patient_Type = "A";
                obj_patient.TotalAmount = gvRequestsmaster.DataKeys[row.RowIndex].Values["totalamount"].ToString().Trim();
                obj_patient.DeliveryBy = "S";
                obj_patient.AuthorizeNo = (gvRequestsmaster.Rows[row.RowIndex].FindControl("lblAuthorizationNo") as Label).Text.Trim();
                clsBLPanel obj_panel = new clsBLPanel();
                obj_panel.Panel_cliq_id = cmbPanel.SelectedValue.ToString().Trim();//cmbPanel.SelectedValue.ToString().Trim()
                try
                {
                    obj_patient.PanelID = obj_panel.GetAll(10)[0]["panelid"].ToString().Trim();
                }
                catch
                {
                    lblError.Text = "No mapped panel found!!! Please contact administrator";
                    return;
                }
                //obj_panel = null;
                obj_patient.SpecimenInternal = "Y";
                obj_patient.Status = "P";//For Panel Patients
                if (System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString() == "006" || Convert.ToInt16(System.DateTime.Now.ToString("yyyy")) < 2014)
                {
                    obj_patient.BranchID = Session["ClientiD"].ToString().Trim();//System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString();
                }
                else
                {
                    obj_patient.BranchID = Session["BranchCode"].ToString().Trim();
                }
                try
                {
                    obj_patient.PathCliqueId = Convert.ToInt32(gvRequestsmaster.DataKeys[row.RowIndex].Values["referredby"].ToString().Trim()).ToString().Trim();
                }
                catch
                {
                    obj_patient.ReferredBy = gvRequestsmaster.DataKeys[row.RowIndex].Values["referredby"].ToString().Trim();
                }

                obj_patient.ReferenceNo = "";
                ///////////////////////////////////////making a 2d array for tests(dc_tpatient_bookingd)/////////////////////////////////////////
                GridView gvtestdetail = gvRequestsmaster.Rows[row.RowIndex].FindControl("gvtestdetail") as GridView;
                int count = 0;
                string[,] str = new string[gvtestdetail.Rows.Count, 12];
                for (int i = 0; i < gvtestdetail.Rows.Count; i++)
                {
                    str[count, 0] = gvtestdetail.DataKeys[i].Value.ToString(); // testid
                    str[count, 1] = "";//Classificationid
                    str[count, 2] = gvtestdetail.DataKeys[i].Values["charges"].ToString();
                    str[count, 3] = "0"; // discount as per test
                    str[count, 4] = "N"; // priority
                    obj_patient.TestID = gvtestdetail.DataKeys[i].Value.ToString(); // testid
                    DataView dv = obj_patient.GetAll(25);
                    if (dv.Count == 0)
                        str[count, 5] = "~!@";
                    else
                    {
                        for (int m = 0; m < dv.Count; m++)
                        {
                            if (!dv[m]["processid"].Equals("1") && !dv[m]["processid"].Equals("2"))
                            {
                                if (dv[m]["processid"].ToString().Trim().Equals("3") || dv[m]["processid"].ToString().Trim().Equals("4") || dv[m]["processid"].ToString().Trim().Equals("5") || dv[m]["processid"].ToString().Trim().Equals("6") || dv[m]["processid"].ToString().Trim().Equals("7"))
                                {
                                    str[count, 5] = dv[m]["processid"].ToString().Trim();
                                    break;
                                }
                            }
                        }
                    }
                    str[count, 6] = ""; // comment internal
                    str[count, 7] = "3"; // for process//hardcoded for specimen collection
                    DataView dv_destinationbr = obj_patient.GetAll(54);
                    str[count, 8] = dv_destinationbr[0]["External"].ToString().Trim()=="Y"?dv_destinationbr[0]["DestinationBranchiD"].ToString().Trim():"0";//if test is external then set destination branchid otherwise set destinationbranchid =0
                    str[count, 9] = "0";
                    str[count, 10] = "";//discount percentage agaisnt single test
                    str[count, 11] = "";//discount adjusted amount
                    count++;
                   
                }
                obj_patient.Sendstatus = "P";
                if (obj_patient.Booking_Cash_Insert(str))
                {
                    OliveService objolive = new OliveService();
                    string masterid = gvRequestsmaster.DataKeys[row.RowIndex].Value.ToString().Trim();
                    if (objolive.UpdateRequest("approve", masterid, Session["personID"].ToString().Trim()).Equals("true"))
                    {
                        lblError.Text = "<font color='green'>Request Successfully added.</font>";
                        FillGV();
                    }
                    else
                    {
                        lblError.Text = "Some Error Occured while Updating Panel Database.";
                    }
                    clsReporting obj_reportpreference = new clsReporting();
                    obj_reportpreference.ClientId = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
                    DataView dv_cashreport = obj_reportpreference.GetAll(40);
                    DataView dv_labreport = dv_cashreport;


                    dv_labreport.RowFilter = "ReportTypeID=2";
                    if (dv_labreport.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('" + dv_labreport[0]["Reportformat_path"].ToString().Trim() + "?prno=" + obj_patient.PRNO + "&labid=" + obj_patient.LabID + "&referenceno=" + "&watermark=" + "&cash=" + "');</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Lab Receipt ", "<script>window.open('wfrmCashReportlab.aspx?prno=" + obj_patient.PRNO + "&labid=" + obj_patient.LabID + "&referenceno=" + "&watermark=" + "&cash=" + "');</script>", false);

                    }
                    dv_cashreport.RowFilter = "ReportTypeID=1";
                    if (dv_cashreport.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('" + dv_cashreport[0]["Reportformat_path"].ToString().Trim() + "?prno=" + obj_patient.PRNO + "&labid=" + obj_patient.LabID + "&referenceno=" + "&watermark=" + "&cash=" + "');</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Receipt", "<script>window.open('wfrmCashReport.aspx?prno=" + obj_patient.PRNO + "&labid=" + obj_patient.LabID + "&referenceno=" + "&watermark=" + "&cash=" + "');</script>", false);
                    }
                }
                else
                {
                    lblError.Text = "Failure due to :" + obj_patient.Error;
 
                }
                /////////////////////////////////////////////////------------------//////////////////////////////////////////////////////////////

            }
            else
            {
                lblError.Text = "Insert Failure due to :" + obj_patient.Error;
            }
        }


        //OliveServiceClient objolive = new OliveServiceClient();
        //string masterid = gvRequestsmaster.DataKeys[row.RowIndex].Value.ToString().Trim();
    }
    protected void cmbPanel_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGV();
    }
}