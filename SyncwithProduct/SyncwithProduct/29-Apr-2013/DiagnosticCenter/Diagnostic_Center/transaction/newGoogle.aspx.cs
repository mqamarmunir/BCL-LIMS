using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Xml.Linq;
using System.Text;
using System.Web.Services;

public partial class transaction_newGoogle : System.Web.UI.Page
{
    string ClientName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
            // clsTest objDC = new clsTest();
            ClientName = Request["search"].ToString();
        //    Getresult();
        

    }
    private void Getresult()
    {
        clsDayCashCollection dayCash = new clsDayCashCollection();

        //clsCaseRegister cases = new clsCaseRegister();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        dayCash.PatientName1 = ClientName;
        dv = dayCash.GetAll(15);
        dt = dv.ToTable();

        StringBuilder sb = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append(dt.Rows[i].ItemArray[0].ToString() + "~");   //Create Con
            }
        }
        Response.Write(sb.ToString());
    }

    
}