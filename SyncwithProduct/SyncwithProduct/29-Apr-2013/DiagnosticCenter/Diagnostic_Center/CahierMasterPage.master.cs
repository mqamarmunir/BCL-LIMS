using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
//using ServiceReference2;
using System.Timers;

public partial class CahierMasterPage : System.Web.UI.MasterPage
{
    public System.Web.UI.Timer timer2;
    clsBLUserRight obj_rights = new clsBLUserRight();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
         {


            obj_rights.PersonID = Session["personId"].ToString().Trim();
            lblPerson.Text = "Welcome " + Session["personname"].ToString();
            DataView dv = obj_rights.GetALL(7);
            lblloginedfrom.Text = Session["logintime"].ToString();
           // DataView dv1 = obj_rights.GetALL(8);

            if (dv.Count > 0)
            {
                //if (dv1.Count>0)
                //{
                //    string enteredon = dv1[0]["enteredon"].ToString();
                //    string enteredoff = dv1[0]["enteredoff"].ToString();
                //    int days = 0;
                //    DateTime d = DateTime.Parse(dv1[0]["enteredon"].ToString());
                //    DateTime d1 = DateTime.Now;
                //    if (enteredon != null && enteredoff == "")
                //    {
                //        d = DateTime.Parse(dv1[0]["enteredon"].ToString());

                //        d1 = DateTime.Now;
                //        // TimeSpan s = d1.Date - d.Date;
                //        days = Convert.ToInt32(d1.Subtract(d).TotalDays);
                //    }
                //    if (days <= 0 && (d.Date == d1.Date && d.Month == d1.Month && d.Year == d1.Year))
                //    {
                        for (int i = 0; i < dv.Count; i++)
                        {
                            try
                            {
                                (Page.Master.FindControl(dv[i]["optionname"].ToString().Trim()) as HyperLink).Visible = true;
                            }
                            catch { }
                        }
                    //}
                    //else
                    //{

                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('Please Close the Cash Session!!!')</script>", false);
                    //    // Response.Redirect("~/transaction/wfrmCashierEntry.aspx");
                    //}
                    //DateTime ddd = DateTime.Now;

                    //string dd1 = DateTime.Now.ToShortDateString() + " 23:50:00";
                    //if (ddd < DateTime.Parse(dd1))
                    //{
                    //    DateTime dp = DateTime.Parse(dd1);
                    //    TimeSpan sp = dp - ddd;
                    //    double timediff = Convert.ToInt32(sp.TotalMilliseconds);
                    //    CashierTimer.Interval = Convert.ToInt32(timediff);
                    //    CashierTimer.Enabled = true;
                    //}
                   }
                    else
                    {
                        // (Page.Master.FindControl("Hyp_CashEntry") as HyperLink).Visible = false;
                    }

                    //dv.Dispose();
                    //Repeater1.DataSource = dv;ti
                    //Repeater1.DataBind();

                }
                //lblnoofnotifications.Text = dv.Count.ToString() ;
                //FillNotifications();
                lblClientName.Text = System.Configuration.ConfigurationManager.AppSettings["ClientName"].ToString().Trim();
                clientimgthumb.ImageUrl = System.Configuration.ConfigurationManager.AppSettings["clientimgthumb"].ToString().Trim();
                // clsBLPatientReg_Inv obj_patient = new clsBLPatientReg_Inv();
                // DataView dv_notifications = obj_patient.GetAll(51);
                // gvacceptedrequests.DataSource = dv_notifications;
                //gvacceptedrequests.DataBind();
            }
            // (Page.Master.FindControl("Hyp_CashEntry") as HyperLink).Visible = false;
            // Control ctrl=Fin
            // Hyp_CashEntry.Visible = false;
            // imgcashierentry.Visible = false;
            // imgcashierEntry.Visible = false;
      //  }
    //}
    private void FillNotifications()
    {
//        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OliveCliq"].ConnectionString;


//        MySqlConnection con = new MySqlConnection(connectionString);
//        con.Open();
//        string cmd = @"Select 
//From ";

//        MySqlDataAdapter da = new MySqlDataAdapter(cmd, con);

//        DataTable ds = new DataTable();

//        da.Fill(ds);
//        DataView dv = new DataView(ds);
//        return dv;
        //OliveService
        //try
        //{
        //    OliveService obj_service = new OliveService();
        //    DataSet ds = obj_service.GetPanelTestRequests(System.Configuration.ConfigurationManager.AppSettings["orgcliqid"].ToString().Trim());
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        lblnoofnotifications.Text = ds.Tables[0].Rows.Count.ToString();
        //        Repeater1.DataSource = ds;
        //        Repeater1.DataBind();
        //    }
        //}
        //catch
        //{
        //    Response.Write("Unable to connect to Remote Server");
        //}
    
    }

    protected void lbtnChange_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Parameter/wfrmPasswordChanged.aspx?pasword=Y");
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Session["personid"] = "";
        //Session["branchID"]="";
        //Session["ClientID"] = "";
        
        Session.Abandon();

        Response.Redirect("~/logout.aspx");
    }
    protected void CashierTimer_Tick(object sender, EventArgs e)
    {
        //obj_rights.PersonID = Session["personId"].ToString().Trim();
          //  DataView dv = obj_rights.GetALL(7);
        //    if (dv.Count > 0)
        //    {
        //        for (int i = 0; i < dv.Count; i++)
        //        {
        //            (Page.Master.FindControl(dv[i]["optionname"].ToString().Trim()) as HyperLink).Visible = false;
        //        }
        //    }
       
       
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('Please Close the Cash Session!!!')</script>", false);
        //Response.Redirect("~/transaction/wfrmCashierEntry.aspx");
        //CashierTimer.Enabled = false;

        //DoubleCheck.Interval = 60000;
        //DoubleCheck.Enabled = true;
       
    }
   
    protected void DoubleCheck_Tick(object sender, EventArgs e)
    {
        //if (GetSessionStatus()==0)
        //{
        //    DoubleCheck.Enabled = false;
        //}
        //else
        //{

        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script language='javascript'>alert('Please Close the Cash Session!!!')</script>", false);
        //    DoubleCheck.Interval = 60000;
        //    DoubleCheck.Enabled = true;
        //}

    }
    public int GetSessionStatus()
    {
        clsDayCashCollection c = new clsDayCashCollection();
        c.Cashierid = Session["personid"].ToString();
        c.FromDate1 = DateTime.Now.ToString();
        c.ToDate1 = DateTime.Now.ToShortDateString() + " 23:59:59";
        DataView dv = c.GetAll(29);
        return dv.Table.Rows.Count;
    }
}
