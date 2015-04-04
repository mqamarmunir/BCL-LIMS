using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

public partial class transaction_wfrmBatchprint : System.Web.UI.Page
{
    private static string batchno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillinformation();
        }
    }

    private void Fillinformation()
    {
        batchno = Request.QueryString["BatchNo"].ToString().Trim();
        clsBLCourierbatches obj_batches = new clsBLCourierbatches();
        obj_batches.Batchno = batchno;
        obj_batches.BranchID = Session["BranchID"].ToString().Trim();
        DataView dv_batchinfo = obj_batches.GetAll(2);
        obj_batches = null;
        if (dv_batchinfo.Count > 0)
        {
            lblBatchNo.Text = dv_batchinfo[0]["batch_no"].ToString().Trim();
            lblDispatchDate.Text = (Convert.ToDateTime(dv_batchinfo[0]["EnteredOn"])).ToString("dd/MM/yyyy hh:mm:ss tt");
            lblSpecimenCount.Text = dv_batchinfo[0]["Count"].ToString().Trim();
            lblBatchDest.Text = dv_batchinfo[0]["BName"].ToString();

            lblsender.Text = dv_batchinfo[0]["Entryperson"].ToString()+",<br />"+dv_batchinfo[0]["origin"].ToString()+",<br />"+dv_batchinfo[0]["branchAddress"].ToString();
            gvTests.DataSource = dv_batchinfo;
            
            gvTests.DataBind();
            dv_batchinfo.Dispose();

        }
    }
}