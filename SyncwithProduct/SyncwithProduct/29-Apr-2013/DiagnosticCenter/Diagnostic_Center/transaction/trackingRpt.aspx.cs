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


public partial class transaction_trackingRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TrackWindow();
        }
    }


    public void TrackWindow()
    {
        clsDayCashCollection dayCash = new clsDayCashCollection();
        
        dayCash.Prid = Request.QueryString["prid"].ToString();
        dayCash.LableId1 = Request.QueryString["labid"].ToString();

        
        DataView dv = dayCash.GetAll(16);
        dayCash.Email = dv[0]["email"].ToString();
        //hdmail.Value = dayCash.Email;

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
}