using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
public partial class transaction_testtextsharp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsBLTest_C_P objtest = new clsBLTest_C_P();
        DataView dv = objtest.GetAll(2);
        gvdetails.DataSource = dv;
        gvdetails.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvdetails.AllowPaging = false;
        //gvdetails.DataBind();

        gvdetails.RenderControl(hw);
        gvdetails.HeaderRow.Style.Add("width", "15%");
        gvdetails.HeaderRow.Style.Add("font-size", "10px");
        gvdetails.Style.Add("text-decoration", "none");
        gvdetails.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        gvdetails.Style.Add("font-size", "8px");



        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
}