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
using System.Text;
using BusinessLayer;
using System.Xml;
//using CrystalDecisions.CrystalReports.Engine;

public partial class MasterPage : System.Web.UI.MasterPage
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblPerson.Text = "Welcome " + Session["personname"].ToString();
                //if (Session["menu"].Equals(""))
                //{
                Populate();
            }
            catch (Exception ee)
            {
                Response.Write(ee.ToString());
            }
           //if (!Session["ReportDoc"].Equals(""))
           //{
           //    ReportDocument doc = (ReportDocument)Session["ReportDoc"];
           //    doc.Close();
           //    doc.Dispose();
           //    GC.Collect();
           //    Session["ReportDoc"] = "";
           //}

            //    Session["menu"] = "P";
            //}
                     
            //if(!Session["personid"].Equals("1") && MainMenu.Items[0].Text=="Parameter")      
            //   MainMenu.Items.Remove(MainMenu.Items[0]);
          
            
            //StringBuilder FullScreenScript = new StringBuilder();
            ////Check the name of the opened window in order to avoid of window re-open over and over again...
            //FullScreenScript.Append("if(this.name != 'InFullScreen')");
            //if (Session["f11"].Equals(""))
            //{
            //    System.Windows.Forms.SendKeys.SendWait("{F11}");
            //    Session["f11"] = "full";
            //}
            //FullScreenScript.Append("{" + Environment.NewLine);
            //FullScreenScript.Append("window.open(window.location.href,'InFullScreen','fullscreen=yes,menubar=no,toolbar=no,status=yes,scrollbars=auto');" + Environment.NewLine);
            //FullScreenScript.Append("}");

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "InFullScreen", FullScreenScript.ToString(), true);
            //Response.Write("<script language='javascript'>window.close()</script>"); 
        }
    }
    

    protected void lbtnLofOff_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");        
    }
    protected void lbtnF11_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.SendKeys.Send("{F11}");
        if (lbtnF11.Text == "Full Screen")
        {
            lbtnF11.Text = "Normal View";
            return;
        }
        if (lbtnF11.Text == "Normal View")
            lbtnF11.Text = "Full Screen";
    }

    private void Populate()
    {
        string path = Session["menu_xml"].ToString();
        DataSet ds = new DataSet();
        System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
        ds.ReadXml(fs);
                                
        for (int i = 0; i < ds.Tables.Count; i++)
        {
            MenuItem mn = new MenuItem(ds.Tables[i].TableName);
            mn.Selectable = false;
            DBMenu.Items.Add(mn);  
 
            for (int c = 0; c < ds.Tables[i].Rows.Count; c++)
            {
                string[] strAddress = GetAddress(Convert.ToInt32(ds.Tables[i].Rows[c]["id"].ToString())).Split(',');
                try
                {
                    MenuItem mnCh = new MenuItem(strAddress.GetValue(0).ToString(), strAddress.GetValue(1).ToString(), null, strAddress.GetValue(2).ToString());
                    DBMenu.Items[i].ChildItems.Add(mnCh);
                }
                catch { }                                 
            }
        }
        fs.Close();       
    }
    public static string GetAddress(int id)
    {
        string strAddress = "";
        switch (id)
        {
            case 1:
                strAddress = "Organization";
                strAddress += "," + "org";
                strAddress += ","+"~/Parameter/Organization.aspx";
                break;
            case 2:
                strAddress = "Designation";
                strAddress += "," + "des";
                strAddress += "," + "~/Parameter/Designation.aspx";
                break;
            case 3:
                strAddress = "Department";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/Department.aspx";
                break;
            case 4:
                strAddress = "Sub-Department";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/SubDepartment.aspx";
                break;
            case 5:
                strAddress = "Personnel";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/Personnel.aspx";
                break;
            case 6:
                strAddress = "Specimen Type";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/SpecimenType.aspx";
                break;
            case 7:
                strAddress = "Specimen Container";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/SContainer.aspx";
                break;
            case 8:
                strAddress = "Group Registration";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/GroupM.aspx";
                break;
            case 9:
                strAddress = "Group Detail";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/GroupD.aspx";
                break;
            case 10:
                strAddress = "Test Registration";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmTest.aspx";
                break;
            case 11:
                strAddress = "Attribute Registration";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/Attribute.aspx";
                break;
            case 12:
                strAddress = "Attribute Range";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/AttributeRange.aspx";
                break;
            case 13:
                strAddress = "Attribute Template";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/AttributeTemplate.aspx";
                break;
            case 14:
                strAddress = "Study Registration";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/StudyM.aspx";
                break;
            case 15:
                strAddress = "Study Detail";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/StudyD.aspx";
                break;
            case 16:
                strAddress = "Method Registration";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/Method.aspx";
                break;
            case 17:
                strAddress = "Method Test Config";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/MethodTest.aspx";
                break;
            case 18:
                strAddress = "Procedure Registration";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmProcedureM.aspx";
                break;
            case 19:
                strAddress = "Procedure Detail";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmProcedureD.aspx";
                break;
            case 20:
                strAddress = "Process";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmProcess.aspx";
                break;
            case 21:
                strAddress = "Classification";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmClassification.aspx";
                break;
            case 22:
                strAddress = "Panel Registration";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmPanel.aspx";
                break;
            case 23:
                strAddress = "Panel Class Reg";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmPanelClass.aspx";
                break;
            case 24:
                strAddress = "Panel Test Reg";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmPanelTest.aspx";
                break;
            case 25:
                strAddress = "Doctor Reg";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmRefDoctor.aspx";
                break;
            case 26:
                strAddress = "Group Matrix";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/AccessGroup.aspx";
                break;
            case 27:
                strAddress = "Access Option";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/AccessOption.aspx";
                break;
            case 28:
                strAddress = "User Right";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/UserRight.aspx";
                break;
            case 29:
                strAddress = "Cash Queue";
                strAddress += "," + "dept";
                strAddress += "," + "~/transaction/wfrmCash.aspx";
                break;
            case 30:
                strAddress = "Cash Refund";
                strAddress += "," + "dept";
                strAddress += "," + "~/transaction/wfrmCashRefund.aspx";
                break;
            case 31:
                strAddress = "Investigation Booking";
                strAddress += "," + "dept";
                strAddress += "," + "~/transaction/wfrmPatient.aspx";
                break;
            case 32:
                strAddress = "Test Master Report";
                strAddress += "," + "dept";
                strAddress += "," + "~/Report/wfrmTestrpt.aspx";
                break;
            case 33:
                strAddress = "Cash Closing";
                strAddress += "," + "dept";
                strAddress += "," + "~/transaction/wfrmCashClose.aspx";
                break;
            case 34:
                strAddress = "Management Console";
                strAddress += "," + "dept";
                strAddress += "," + "~/Manag_Info/wfrmMang_Console.aspx";
                break;
            case 35:
                strAddress = "Specimen Collection";
                strAddress += "," + "dept";
                strAddress += "," + "~/transaction/wfrmSpecimenCollect.aspx";
                break;
            case 36:
                strAddress = "Work List";
                strAddress += "," + "dept";
                strAddress += "," + "~/transaction/wfrmWorkList.aspx";
                break;
            case 37:
                strAddress = "General";
                strAddress += "," + "dept";
                strAddress += "," + "~/transaction/wfrmGeneral.aspx";
                break;
            case 38:
                strAddress = "Result Entry";
                strAddress += "," + "dept";
                strAddress += "," + "~/transaction/wfrmEntryQueue.aspx";
                break;
            case 39:
                strAddress = "Test Template";
                strAddress += "," + "dept";
                strAddress += "," + "~/Parameter/wfrmComent_Opinion.aspx";
                break;
            case 40:
                strAddress = "Result Verification";
                strAddress += "," + "very";
                strAddress += "," + "~/Transaction/wfrmVerification.aspx";
                break;
            case 41:
                strAddress = "Vital Sign";
                strAddress += "," + "vital";
                strAddress += "," + "~/Parameter/wfrmVitalSign.aspx";
                break;
            case 42:
                strAddress = "Specimen Nature";
                strAddress += "," + "specimennature";
                strAddress += "," + "~/Parameter/wfrmSpecimen_Nature.aspx";
                break;
            case 43:
                strAddress = "Result Dispatch";
                strAddress += "," + "resultdispatch";
                strAddress += "," + "~/Transaction/wfrmDispatch.aspx";
                break;
            case 44:
                strAddress = "Organism";
                strAddress += "," + "organism";
                strAddress += "," + "~/Parameter/wfrmOrganism.aspx";
                break;
            case 45:
                strAddress = "Drug";
                strAddress += "," + "drug";
                strAddress += "," + "~/Parameter/wfrmDrug.aspx";
                break;
            case 46:
                strAddress = "Result Call Back";
                strAddress += "," + "clb";
                strAddress += "," + "~/Transaction/wfrmResultCallBack.aspx";
                break;
            case 47:
                strAddress = "Panel Services Statement";
                strAddress += "," + "panelbooking";
                strAddress += "," + "~/Report/wfrmPanelRpt.aspx";
                break;
            case 48:
                strAddress = "Cash Summary";
                strAddress += "," + "casesummary";
                strAddress += "," + "~/Report/wfrmCashSummary.aspx";
                break;
            case 49:
                strAddress = "Test Ordering Summary";
                strAddress += "," + "testOrderingSumm";
                strAddress += "," + "~/Report/testOrdering_sum.aspx";
                break;
            case 50:
                strAddress = "Test Turnover Summary";
                strAddress += "," + "testturnovrSumm";
                strAddress += "," + "~/Report/wfrm_Test_trnovr.aspx";
                break;
            case 51:
                strAddress = "Balance and Discount Summary";
                strAddress += "," + "balanddisc";
                strAddress += "," + "~/Report/wfrmBal_Dis_sumry.aspx";
                break;
            case 52:
                strAddress = "Panel Ledger";
                strAddress += "," + "panelledger";
                strAddress += "," + "~/Report/wfrmPanelLedger.aspx";
                break;
            case 53:
                strAddress = "Ward Registration";
                strAddress += "," + "ward";
                strAddress += "," + "~/Parameter/wfrmWard.aspx";
                break;
            case 54:
                strAddress = "External Test Track";
                strAddress += "," + "externaltrack";
                strAddress += "," + "~/transaction/wfrmExternal_Track.aspx";
                break;
            case 55:
                strAddress = "Pending Work Load";
                strAddress += "," + "workload";
                strAddress += "," + "~/Report/wfrmWorkLoad.aspx";
                break;
            case 56:
                strAddress = "External Track Report";
                strAddress += "," + "externaltrackreport";
                strAddress += "," + "~/Report/wfrmExternal_Track_Rpt.aspx";
                break;
            case 57:
                strAddress = "Patient Statement";
                strAddress += "," + "patientchargesheet";
                strAddress += "," + "~/Report/wfrmIndoor_Sheet.aspx";
                break;
            case 58:
                strAddress = "Indoor Summary";
                strAddress += "," + "indsummar";
                strAddress += "," + "~/Report/wfrmInd_summary.aspx";
                break;
            case 59:
                strAddress = "Consultant Ordering Summary";
                strAddress += "," + "consultord";
                strAddress += "," + "~/Report/wfrmConsult_ordered.aspx";
                break;
            case 60:
                strAddress = "Collection Centre Summary";
                strAddress += "," + "cs";
                strAddress += "," + "~/Report/wfrmCollectionSummary.aspx";
                break;
            //case 61:
            //    strAddress = "Panel Bill";
            //    strAddress += "," + "panelBill";
            //    strAddress += "," + "~/transaction/wfrmPanel_Bill.aspx";
            //    break;
            case 61:
                strAddress = "Branch Registration";
                strAddress += "," + "branch";
                strAddress += "," + "~/Parameter/wfrmBranchRegistration.aspx";
                break;
            case 62:
                strAddress = "Branch Test Configuration";
                strAddress += "," + "BrTest";
                strAddress += "," + "~/Parameter/wfrmBranchTests.aspx";
                break;
            case 63:
                strAddress = "Branch Test Prices Config";
                strAddress += "," + "BrTestpr";
                strAddress += "," + "~/Parameter/wfrmBranchTestPrice.aspx";
                break;
            case 64:
                strAddress = "Branch Bookings";
                strAddress += "," + "Brbooks";
                strAddress += "," + "~/transaction/wfrmBranchBookedTests.aspx";
                break;
            case 65:
                strAddress = "Courier Branch Registration";
                strAddress += "," + "CBRReg";
                strAddress += "," + "~/parameter/wfrmCourierBranchRegistration.aspx";
                break;
            case 66:
                strAddress = "Test Arrivals";
                strAddress += "," + "Tarr";
                strAddress += "," + "~/transaction/wfrmupcomingtests.aspx";
                break;
            case 67:
                strAddress = "Branch panel Registration";
                strAddress += "," + "brpanel";
                strAddress += "," + "~/parameter/wfrmbranchPanels.aspx";
                break;
            case 68:
                strAddress = "Discount package Registration";
                strAddress += "," + "discPackage";
                strAddress += "," + "~/parameter/wfrmDiscountPackage.aspx";
                break;
            case 69:
                strAddress = "Preference Settings";
                strAddress += "," + "prefSett";
                strAddress += "," + "~/parameter/wfrmPreferenceSettings.aspx";
                break;
            case 81:
                strAddress = "Gazzeted Holidays";
                strAddress += "," + "gazzeted";
                strAddress += "," + "~/parameter/wfrmGazzetedHolidays.aspx";
                break;
            case 93:
                strAddress = "Branch Groups and Packages";
                strAddress += "," + "Packages";
                strAddress += "," + "~/parameter/wfrmBranchgroups.aspx";
                break;
        }
        return strAddress;
    }
    protected void lbtnChange_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx?pasword=Y");
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Session["personid"] = "";
        //Session["branchID"]="";
        //Session["ClientID"] = "";
        Session.Abandon();

        Response.Redirect("~/Login.aspx");
    }
}
