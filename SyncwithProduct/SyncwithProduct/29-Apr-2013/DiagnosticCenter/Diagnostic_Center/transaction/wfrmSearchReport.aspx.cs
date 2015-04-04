using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BusinessLayer;

public partial class transaction_wfrmSearchReport : System.Web.UI.Page
{
    clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
    clsPreferenceSettings preferences = new clsPreferenceSettings();
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadHeadList();
            loadFooterList();
        }
    }



    public void loadHeadList()
    {
        DataView dv = new DataView();
        dv = preferences.GetALL(1);
        if (dv.Count > 0)
        {
            string header = dv[0]["path_location"].ToString();
            Session["header"] = header;
            headerImg.Src = header;
        }
    }

    public void loadFooterList()
    {
        DataView dv = new DataView();
        dv = preferences.GetALL(2);
        if (dv.Count > 0)
        {
            string footer = dv[0]["path_location"].ToString();
            Session["footer"] = footer;
            footerImg.Src = footer;
        }
    }

    protected void Btn_Search_Click(object sender, ImageClickEventArgs e)
    {
        Session.RemoveAll();

        string labid = TxBx_labid.Text;
        string prno = TxBx_Prno.Text;

        Session["prno"] = prno;
        Session["labid"] = labid;

        loadHeadList();
        loadFooterList();

        Response.Write("<script language='javascript'>window.open('wfrmCashReport.aspx');</script>");
    }


    protected void Btn_Paid_Click(object sender, ImageClickEventArgs e)
    {
        Session.RemoveAll();

        string labid = TxBx_labid.Text;
        string prno = TxBx_Prno.Text;

        Session["prno"] = prno;
        Session["labid"] = labid;

        loadHeadList();
        loadFooterList();

        Response.Write("<script language='javascript'>window.open('wfrmCashCollection.aspx');</script>");
    }

    protected void Btn_Print_Click(object sender, ImageClickEventArgs e)
    {
        Session.RemoveAll();

        string labid = TxBx_labid.Text;
        string prno = TxBx_Prno.Text;

        Session["prno"] = prno;
        Session["labid"] = labid;

        loadHeadList();
        loadFooterList();

        Response.Write("<script language='javascript'>window.open('wfrmCashReport.aspx');</script>");
    }
}
