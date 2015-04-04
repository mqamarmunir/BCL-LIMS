using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_dailysalesrpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { }

    }
    protected void imgReport_Click(object sender, ImageClickEventArgs e)
    {
        #region HTMlreport call
        ScriptManager.RegisterStartupScript(this, typeof(Page), "CashSummary", "<script>window.open('wfrmdailysalesrpt.aspx?datefrom=" + txtFrom.Text.Trim() + "&dateto=" + txtFrom.Text.Trim() + "');</script>", false);

        #endregion
        
    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
}