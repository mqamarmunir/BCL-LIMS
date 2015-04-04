using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using BusinessLayer;
using System.Data;
public partial class transaction_TestGridPDF : System.Web.UI.Page
{

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        clsBLTest_C_P objtest = new clsBLTest_C_P();
        DataView dv = objtest.GetAll(5);
       // gvdetails.DataSource = dv;
        //gvdetails.DataBind();

        GridView1.DataSource = dv;
        GridView1.DataBind();
        //for (int i = 0; i < dv.Count; i++)
        //{
        //    (GridView1.Rows[0].FindControl("TreeView1") as TreeView).CheckedNodes[0].Checked = true;
        //}
    }

    public void treenode()
    {
       
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Response.ContentType = "application/pdf";
    //    Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    StringWriter sw = new StringWriter();
       
    //    HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    gvdetails.AllowPaging = false;
    //    gvdetails.DataBind();
    //    gvdetails.RenderControl(hw);
    //    gvdetails.HeaderRow.Style.Add("width", "15%");
    //    gvdetails.HeaderRow.Style.Add("font-size", "10px");
    //    gvdetails.Style.Add("text-decoration", "none");
    //    gvdetails.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
    //    gvdetails.Style.Add("font-size", "8px");

    //    HtmlTextWriter hw2 = new HtmlTextWriter(sw);
    //    GridView1.AllowPaging = false;
    //    GridView1.DataBind();
    //    GridView1.RenderControl(hw2);
    //    GridView1.HeaderRow.Style.Add("width", "15%");
    //    GridView1.HeaderRow.Style.Add("font-size", "10px");
    //    GridView1.Style.Add("text-decoration", "none");
    //    GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
    //    GridView1.Style.Add("font-size", "8px");

        

    //    StringReader sr = new StringReader(sw.ToString());
    //    Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
    //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //    pdfDoc.Open();
    //    htmlparser.Parse(sr);
    //    pdfDoc.Close();
    //    Response.Write(pdfDoc);
    //    Response.End();
    //}
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
}