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

public partial class Parameter_wfrmHeaderFooterPrefernces : System.Web.UI.Page
{
    clsPreferenceSettings preference = new clsPreferenceSettings();

    public static string prefID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadGridData();
        }
    }

    public void loadGridData()
    {
        DataView dv = new DataView();
        dv = preference.GetALL(3);
        Gv_PreferenceSetting.DataSource = dv;
        Gv_PreferenceSetting.DataBind();
    }

    protected void Img_Button_Save_Click(object sender, ImageClickEventArgs e)
    {
        preference.PreferenceName = TxBx_Name.Text;
        preference.PreferenceType = Txbx_Type.Text;
        preference.Description = TxBx_Desc.Text;
        if (AsyncFileUpload1.HasFile)
        {
            string nstrPath = @"../transaction/headerfooter/" + AsyncFileUpload1.FileName;
            string pathDoc = Server.MapPath("..\\transaction\\headerfooter\\");
            preference.Path_location = nstrPath;
            AsyncFileUpload1.SaveAs(pathDoc + AsyncFileUpload1.FileName);
        }
        preference.EnteredBy = "Amman";
        preference.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"); 
        if (Chk_Active.Checked == true)
        {
            preference.Active = "1";
        }
        else
        {
            preference.Active = "0";
        }
        preference.Insert();
        Lb_Saved.Text = "New Record has been saved successfully.";
    }
    protected void Gv_PreferenceSetting_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = Gv_PreferenceSetting.Rows[Convert.ToInt16(e.CommandArgument)];
        CheckBox ch = row.FindControl("Chk_Active") as CheckBox;
        if (ch != null)
        {
            if (ch.Checked)
            {
                preference.Active = "1";
            }
            else
            {
                preference.Active = "0";
            }
        }
    }
    protected void Gv_PreferenceSetting_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void UpdateNow_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < Gv_PreferenceSetting.Rows.Count; i++)
        {
            prefID = Gv_PreferenceSetting.DataKeys[i].Values[0].ToString();
            preference.PreferenceID = prefID;
            // preference.PreferenceName = Gv_PreferenceSetting.Rows[i].Cells[1].ToString();
            // preference.PreferenceType = Gv_PreferenceSetting.Rows[i].Cells[2].ToString();
            // preference.Description = Gv_PreferenceSetting.Rows[i].Cells[3].ToString();
            if (((CheckBox)(Gv_PreferenceSetting.Rows[i].FindControl("Chk_Active"))).Checked == true)
            {
                preference.Active = "1";
            }
            else
            {
                preference.Active = "0";
            }
            preference.Update();
            //Label1.Text = "Update Successfully";
            //preferenceID = "";
            //loadValues();
            //loadGridData();
        }
        Lb_Saved.Text = "Record has been Updated Successfully.";
    }
}