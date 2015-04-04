using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

public partial class transaction_wfrmbankentry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { }
    }

    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBlBankEntry b = new clsBlBankEntry();
        b.BankAmount = txtbank.Text.ToString();
        b.Cashier = txtcashier.Text.ToString();
        b.Date = txtdate.Text.ToString();
        b.Comments = txtcomments.Text.ToString();
        b.ReportAmount = txtramt.Text.ToString();
        b.Reportno = txtreportno.Text.ToString();
        b.Location = txtlocation.Text.ToString();
        b.Enteredby = Session["personid"].ToString();
        b.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        if (b.Insert())
        {
            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Record has been saved successfully";
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text =b.ErrorMessage;
        }

    }
    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {

    }
}