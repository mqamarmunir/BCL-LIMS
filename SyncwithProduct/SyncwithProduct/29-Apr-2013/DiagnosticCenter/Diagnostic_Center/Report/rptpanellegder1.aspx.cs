using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Globalization;
using  ServiceReference2;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Drawing;
public partial class Report_rptpanellegder1 : System.Web.UI.Page
{
    
        clsReporting report = new clsReporting();
        clsBLPatientReg_Inv patient = new clsBLPatientReg_Inv();
        clsPreferenceSettings prefSetting = new clsPreferenceSettings();
        string filename = null;
         int srno = 1;
         string total = null;
         int rowcount = 0;
         int tsrno=1;
         DataView paneldata = null;
         string dependentno = null;
         string empno = null;
         string doccode = null;
         string srnoref = null;
         string Patientname = null;
         string letterdate = null;
         string relation = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        FillGV();
        //patientPrimaryInformation();
        patientBranchInfo();
       
       // calctotalcharges();
    }

    public void patientBranchInfo()
    {
        patient.Branch_ID = Session["branchid"].ToString();
        DataView dv = new DataView();
        dv = patient.GetAll(43);
        Lb_BranchNames.Text = dv[0]["branchName"].ToString();
        //Lb_branchAddress.Text = dv[0]["address"].ToString();
        string _24hrs = dv[0]["24HrsService"].ToString();

        if (_24hrs == "Y")
        {
            Lb_starttime.Text = "24 Hrs";
            Lb_endtime.Visible = false;
            lb_phonebranchmain.Text = dv[0]["phone"].ToString();
        }
        else
        {
            Lb_starttime.Text = dv[0]["starttimes"].ToString();
            Lb_endtime.Text = dv[0]["endtimes"].ToString();
            lb_phonebranchmain.Text = dv[0]["phone"].ToString();
            Lb_Extension.Text = dv[0]["Ext"].ToString();
        }

    }

    //public void patientPrimaryInformation()
    //{

    //    DataView dv = new DataView();
    //    dv = prefSetting.GetALL(1);
    //    if (dv.Count > 0)
    //    {
    //        if (dv[0]["Path_location"].ToString() != null)
    //        {
    //            Img_header.Visible = true;
    //            Img_header.ImageUrl = dv[0]["Path_location"].ToString();
    //        }
    //        else
    //        {
    //            Img_header.ImageUrl = "#";
    //        }
    //        if (Session["footer"] != null)
    //        {
    //            // Img_footer.ImageUrl = Session["footer"].ToString();
    //        }
    //        else
    //        {
    //            // Img_footer.ImageUrl = "#";
    //        }
    //    }

    //    dv = new DataView();
    //    if (!Request.QueryString["admno"].ToString().Equals(""))
    //    {
    //        report.ReferenceNo = Request.QueryString["admno"].ToString();
    //    }
    //    if (!Request.QueryString["prno"].ToString().Replace("___-__-________", "").Equals(""))
    //    {
    //        report.Prno = Request.QueryString["prno"].ToString();

    //    }
    //    // report.Labid = "10-006-00000002";
    //    dv = report.GetAll(2);
    //    if (dv.Count > 0)
    //    {
    //        Gv_PatientPrimaryInfo.DataSource = dv;
    //        Gv_PatientPrimaryInfo.DataBind();
    //        Lb_PRNO.Text = dv[0]["prno"].ToString();
    //        Lb_Visit.Text = dv[0]["labid"].ToString();
    //    }
    //    else
    //    {
    //        Gv_PatientPrimaryInfo.DataSource = null;
    //        Gv_PatientPrimaryInfo.DataBind();
    //        Lb_PRNO.Text = "";
    //        Lb_Visit.Text = "";
    //    }
    //}




    private void FillGV()
    {
       // clsBLPatientReg_Inv obj_reginv = new clsBLPatientReg_Inv();
        
        if (!Request.QueryString["panelid"].ToString().Equals(""))
        {
            lblPanelName.Text = Request.QueryString["PanelName"].ToString().Trim();
            report.PanelID= Request.QueryString["panelid"].ToString();
        }
        else if (!Request.QueryString["branchid"].ToString().Trim().Equals("-1") && !Request.QueryString["branchid"].ToString().Trim().Equals(""))
        {
            report.BranchID= Request.QueryString["branchid"].ToString().Trim();

        }
        report.Datefrom = DateTime.Parse(Request.QueryString["datefrom"], new CultureInfo("ur-Pk", false)).ToString("dd/MM/yyyy");
        report.Dateto = DateTime.Parse(Request.QueryString["dateto"], new CultureInfo("ur-Pk", false)).AddDays(1).ToString("dd/MM/yyyy");
        
        DataView dv_pr = report.GetAll(46);
        clsBLPanel obj_panel = new clsBLPanel();
        obj_panel.PanelID = report.PanelID;
        DataSet ds = new DataSet();
        ServiceReference2.OliveService olive = new ServiceReference2.OliveService();
        try
        {
            ds = olive.GetPanellegderData(report.Datefrom, report.Dateto, obj_panel.GetAll(9)[0]["panel_cliq_id"].ToString().Trim());
        }

        catch
        {
            Response.Write("Some Error Occured while getting data from Remote server. Please try again in few minutes.");
        }
         int t=ds.Tables.Count;
         int row = ds.Tables[0].Rows.Count;
         if (row > 0)
         {
             paneldata = new DataView(ds.Tables[0]);
             //filename = WriteXml(paneldata);
             ds.Dispose();

         //   LoadDataIntemp(dt);
         }

        if (dv_pr.Count > 0)
        {
            rowcount = dv_pr.Table.Rows.Count;
            gvMain.DataSource = dv_pr;
            gvMain.DataBind();
            
            //DataTable dt = dv_pr.Table.Copy();
            //int i=0;
            //foreach (GridViewRow row in gvMain.Rows)
            // {
            //        Label lbldates = row.FindControl("lbldate") as Label;
            //        string lblvalue = lbldates.Text.ToString();
            //        lbldates.Text =  dv_pr.Table.Rows[i]["entereddate"].ToString();;
            //        i++;
           
            // }
            
        }
        else
        {
            gvMain.DataSource = "";
            gvMain.DataBind();
        }
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
            {
                Label lbltotalamt = e.Row.FindControl("lbltotal") as Label;
                total = lbltotalamt.Text.ToString();
                Label lbltserial = e.Row.FindControl("lbltsrno") as Label;
                lbltserial.Text = tsrno.ToString();

                Label empid = e.Row.FindControl("lblempid") as Label;


                Label depid = e.Row.FindControl("lbldepid") as Label;

                Label date = e.Row.FindControl("lblenteredon") as Label;

                Label refcode = e.Row.FindControl("lblrefcode") as Label;

                Label patientname = e.Row.FindControl("lblpatientname") as Label;

                Label ralation = e.Row.FindControl("lblrelation") as Label;

                Label refsrno = e.Row.FindControl("lblrefnsrno") as Label;


                if (paneldata != null)
                {
                    //paneldata.RowFilter = "depno=" + gvMain.DataKeys[e.Row.RowIndex]["cliq_dependent_id"].ToString();
                    foreach (DataRowView r in paneldata)
                    {
                        if (r["depid"].ToString() == gvMain.DataKeys[e.Row.RowIndex]["cliq_dependent_id"].ToString())
                        {
                            dependentno = r["depno"].ToString();
                            doccode = r["doctorid"].ToString();
                            empno = r["empno"].ToString();
                            //refcode = null;
                            srnoref = r["refsrno"].ToString();
                            Patientname = r["dependentname"].ToString();
                            relation = r["relation"].ToString();
                            letterdate = r["letterdate"].ToString();
                            break;
                        }
                    }


                }
                empid.Text = empno;
                depid.Text = dependentno;
                date.Text = letterdate;
                refcode.Text = doccode;
                patientname.Text = Patientname;
                ralation.Text = relation;
                refsrno.Text = srnoref;
                if (rowcount > 1)
                {
                    lbltotalamt.Text = "";
                }
            }

            if (e.Row.RowIndex != 0)
            {
                // Label lbldates = e.Row.FindControl("lbldate") as Label;
                if (int.Parse(gvMain.DataKeys[e.Row.RowIndex]["bookingid"].ToString()) != int.Parse(gvMain.DataKeys[e.Row.RowIndex - 1]["bookingid"].ToString()))
                {
                    //TextBox txtQtyval1 = (TextBox)gvExcParts.Rows[i].Cells[1].FindControl("txtRMAPartQuantity");
                    Label lbltotalamt1 = (Label)gvMain.Rows[e.Row.RowIndex - 1].FindControl("lbltotal");
                    lbltotalamt1.Text = total;
                    Label lbltotalamt = e.Row.FindControl("lbltotal") as Label;
                    total = lbltotalamt.Text.ToString();
                    lbltotalamt.Text = "";
                    if (paneldata != null)
                    {
                        //try
                        //{
                        //    paneldata.RowFilter = "depno=" + gvMain.DataKeys[e.Row.RowIndex]["cliq_dependent_id"].ToString();
                        //}
                        //catch
                        //{ }
                        Label empid = e.Row.FindControl("lblempid") as Label;


                        Label depid = e.Row.FindControl("lbldepid") as Label;

                        Label date = e.Row.FindControl("lblenteredon") as Label;

                        Label refcode = e.Row.FindControl("lblrefcode") as Label;

                        Label patientname = e.Row.FindControl("lblpatientname") as Label;

                        Label ralation = e.Row.FindControl("lblrelation") as Label;

                        Label refsrno = e.Row.FindControl("lblrefnsrno") as Label;

                        if (paneldata != null)
                        {
                            //paneldata.RowFilter = "depno=" + gvMain.DataKeys[e.Row.RowIndex]["cliq_dependent_id"].ToString();
                            foreach (DataRowView r in paneldata)
                            {
                                if (r["depid"].ToString() == gvMain.DataKeys[e.Row.RowIndex]["cliq_dependent_id"].ToString())
                                {
                                    dependentno = r["depno"].ToString();
                                    doccode = r["doctorid"].ToString();
                                    empno = r["empno"].ToString();
                                    //refcode = null;
                                    srnoref = r["refsrno"].ToString();
                                    Patientname = r["dependentname"].ToString();
                                    relation = r["relation"].ToString();
                                    letterdate = r["letterdate"].ToString();
                                    break;
                                }
                            }


                        }
                        try
                        {
                            empid.Text = empno.ToString();
                            depid.Text = dependentno.ToString();
                            date.Text = letterdate.ToString();
                            refcode.Text = doccode.ToString();
                            patientname.Text = Patientname.ToString();
                            ralation.Text = relation.ToString();
                            refsrno.Text = srnoref.ToString();
                        }
                        catch (NullReferenceException ee)
                        {
 
                        }
                    }


                    //Label lbltotal = e.Row.FindControl("lbltotal") as Label;
                    //lbltotal.Text = "";
                    Label lbltestserial = e.Row.FindControl("lbltsrno") as Label;
                    tsrno = 1;
                    lbltestserial.Text = tsrno.ToString();
                    Label lblsrno = e.Row.FindControl("lblsrno") as Label;
                    int lblvalue = int.Parse(lblsrno.Text.ToString());
                    if (lblvalue == 1)
                    {
                        srno++;
                        lblsrno.Text = srno.ToString();
                    }

                    else
                    {
                        srno++;
                        lblsrno.Text = srno.ToString();
                    }


                }
                else
                {
                    Label lbltsrno = e.Row.FindControl("lbltsrno") as Label;
                    // int tsrno = int.Parse(lbltsrno.Text.ToString());
                    tsrno++;
                    lbltsrno.Text = tsrno.ToString();
                    Label lblsrno = e.Row.FindControl("lblsrno") as Label;
                    lblsrno.Text = "";

                    Label lbltotal = e.Row.FindControl("lbltotal") as Label;
                    lbltotal.Text = "";
                    Label empid = e.Row.FindControl("lblempid") as Label;


                    Label depid = e.Row.FindControl("lbldepid") as Label;

                    Label date = e.Row.FindControl("lblenteredon") as Label;

                    Label refcode = e.Row.FindControl("lblrefcode") as Label;

                    Label patientname = e.Row.FindControl("lblpatientname") as Label;

                    Label ralation = e.Row.FindControl("lblrelation") as Label;

                    Label refsrno = e.Row.FindControl("lblrefnsrno") as Label;
                    empid.Text = empno;
                    depid.Text = dependentno;
                    date.Text = letterdate;
                    refcode.Text = doccode;
                    patientname.Text = Patientname;
                    ralation.Text = relation;
                    refsrno.Text = srnoref;
                    if ((rowcount - 1) == e.Row.RowIndex)
                    {
                        Label lbltotalamount = e.Row.FindControl("lbltotal") as Label;
                        lbltotalamount.Text = total;
                    }

                }




            }
        }
    }
    
        

    private void calctotalcharges()
    {
        int totalcharges = 0;
        int totalpaid = 0;
        int totaldisc = 0;
        //int totalbal = 0;
        int totbalance = 0;
        for (int i = 0; i < gvMain.Rows.Count; i++)
        {
            try
            {
                totalcharges += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblTotal") as Label).Text);
                totalpaid += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblpaid") as Label).Text);
                totaldisc += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lbldis") as Label).Text);
                //totalpaid += Convert.ToInt32((gvMain.Rows[i].Cells[0].FindControl("lblbal") as Label).Text);
            }
            catch { }
        }

        //totbalance = totalcharges - totalpaid - totaldisc;
        //lbltotcharges.Text = totalcharges.ToString();
        //lbltotpaid.Text = totalpaid.ToString();
        //lbltotdisc.Text = totaldisc.ToString();
        //lbltotbal.Text = totbalance.ToString();
    }

    protected void ExportToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvMain.AllowPaging = false;
           // gvMain.BindGrid();

            gvMain.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvMain.HeaderRow.Cells)
            {
                cell.BackColor = gvMain.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvMain.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvMain.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvMain.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvMain .RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();

    Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");


    Response.ContentType = "application/vnd.xls";

    System.IO.StringWriter stringWrite = new System.IO.StringWriter();

    System.Web.UI.HtmlTextWriter htmlWrite =
    new HtmlTextWriter(stringWrite);

    gvMain.RenderControl(htmlWrite);

    Response.Write(stringWrite.ToString());

    Response.End();

    }
}