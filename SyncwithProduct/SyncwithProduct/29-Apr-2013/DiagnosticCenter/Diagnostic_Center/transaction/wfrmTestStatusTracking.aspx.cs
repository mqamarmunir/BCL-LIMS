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

public partial class wfrmTestStatusTracking : System.Web.UI.Page
{
    private static string DGSort = "";
    clsDayCashCollection dayCash = new clsDayCashCollection();
    protected void Page_Load(object sender, EventArgs e)
    {
    
        dayCash.Prid = Session["prid"].ToString();
        dayCash.LableId1 = Session["Labid"].ToString();
        DataView dv = dayCash.GetAll(16);
      

        lblPatientName.Text = dv[0]["Patient_Name"].ToString();
        lblDOB.Text = dv[0]["dob"].ToString();
        lblCellNo.Text = dv[0]["cellno"].ToString();
        lblprno.Text = dv[0]["prno"].ToString();

        lblLabid.Text = dv[0]["labid"].ToString();
        dayCash.LableId1 = lblLabid.Text;
        DataView dv2 = dayCash.GetAll(21);

        gvTestDetails.DataSource = dv2;
        gvTestDetails.DataBind();
   
    }


   
    public void gridRepeatDetails()
    {
        string initialnamevalue = (gvTestDetails.Rows[0].FindControl("lblname") as Label).Text;

        for (int i = 1; i < gvTestDetails.Rows.Count; i++)
        {
            if ((gvTestDetails.Rows[i].FindControl("lblname") as Label).Text == initialnamevalue)
            {
                (gvTestDetails.Rows[i].FindControl("lblname") as Label).Text = string.Empty;
                (gvTestDetails.Rows[i].FindControl("lblname") as Label).Text = "-";
            }
            else
            {
                initialnamevalue = (gvTestDetails.Rows[i].FindControl("lblname") as Label).Text;
                // Response.Write(initialnamevalue);
            }
        }

    }
}