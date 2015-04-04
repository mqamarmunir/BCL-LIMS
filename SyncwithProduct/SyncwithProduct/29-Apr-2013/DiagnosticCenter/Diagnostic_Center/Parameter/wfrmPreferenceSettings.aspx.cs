using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;


public partial class Parameter_wfrmPreferenceSettings : System.Web.UI.Page
{

    private static string mode = "insert";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGV();
            clsBLPreferenceSettings obj_Preferences = new clsBLPreferenceSettings();
            DataView dv_Settings = obj_Preferences.GetAll(1);
            if (dv_Settings.Count > 0)
            {
                mode = "update";
                hdPreferenceID.Value = dv_Settings[0]["PreferenceID"].ToString().Trim();
                ((CheckBox)gvPreferences.Rows[0].FindControl("gvchkfield")).Checked=dv_Settings[0]["PrintBranches"].ToString().Trim()=="Y"?true:false;
                ((CheckBox)gvPreferences.Rows[1].FindControl("gvchkfield")).Checked = dv_Settings[0]["PrintTestComents"].ToString().Trim() == "Y" ? true : false;
                ((CheckBox)gvPreferences.Rows[2].FindControl("gvchkfield")).Checked = dv_Settings[0]["PrintPanelText"].ToString().Trim() == "Y" ? true : false;
                ((CheckBox)gvPreferences.Rows[3].FindControl("gvchkfield")).Checked = dv_Settings[0]["PrintGeneralComments"].ToString().Trim() == "Y" ? true : false;
                ((CheckBox)gvPreferences.Rows[4].FindControl("gvchkfield")).Checked = dv_Settings[0]["PrintPathologists"].ToString().Trim() == "Y" ? true : false;
                ((CheckBox)gvPreferences.Rows[5].FindControl("gvchkfield")).Checked = dv_Settings[0]["Printrecieptonspecimen"].ToString().Trim() == "Y" ? true : false;
                txtDescription.Text = dv_Settings[0]["GeneralComments"].ToString().Trim();
                txtrecordsperpage.Text = dv_Settings[0]["Recordsperpage_cashrec"].ToString().Trim();
                tbminimumcashpercentage.Text = dv_Settings[0]["Onbookingcashcollection"].ToString().Trim();
                txtRoundingoff.Text = dv_Settings[0]["RoundOfffactor"].ToString().Trim();
                txtloginInstructions.Text = dv_Settings[0]["loginInstructions"].ToString().Trim();
            }
            
        }
    }

    private void FillGV()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Fieldname");

        dt.Rows.Add("Print Branches");
        dt.Rows.Add("Print Test Comments On Report");
        dt.Rows.Add("Print Panel Text On Report");
        dt.Rows.Add("Print Generalized Comments");
        dt.Rows.Add("Print Pathologists");
        dt.Rows.Add("Print Patient Reciept on Specimen Collection");

        gvPreferences.DataSource = dt;
        gvPreferences.DataBind();


    }

    


    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "update")
        {
            Update();

        }
        else
        {
            Insert();
        }
    }

    private void Insert()
    {
        clsBLPreferenceSettings obj_preferences = new clsBLPreferenceSettings();
        obj_preferences.PrintBranches = ((CheckBox)gvPreferences.Rows[0].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.BranchText = ((CheckBox)gvPreferences.Rows[1].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.PrintPanelText = ((CheckBox)gvPreferences.Rows[2].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.PrintGeneralComments = ((CheckBox)gvPreferences.Rows[3].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.PrintPathologists = ((CheckBox)gvPreferences.Rows[4].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.GeneralComments = txtDescription.Text;
        obj_preferences.Printrecieptonspecimen = ((CheckBox)gvPreferences.Rows[5].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.Recordsperpage_cashrec = txtrecordsperpage.Text.Trim();
        obj_preferences.Enteredby = Session["PersonID"].ToString().Trim();
        obj_preferences.ClientId = Session["orgid"].ToString();
        obj_preferences.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_preferences.Onbookingcashcollection = tbminimumcashpercentage.Text.Trim();
        obj_preferences.Roundingofffactor = txtRoundingoff.Text.Trim();
        obj_preferences.LoginInstructions = txtloginInstructions.Text.Trim();

        if (obj_preferences.Insert())
        {
           
            this.lblErrMsg.Text = "<font color='green'>Settings Added Successfully.</font>";
        }
        else
        {
            lblErrMsg.Text = obj_preferences.ErrorMessage;
        }
    }

    private void Update()
    {
        clsBLPreferenceSettings obj_preferences = new clsBLPreferenceSettings();
        obj_preferences.PreferenceID = hdPreferenceID.Value.ToString().Trim();
        obj_preferences.PrintBranches = ((CheckBox)gvPreferences.Rows[0].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.BranchText = ((CheckBox)gvPreferences.Rows[1].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.PrintPanelText = ((CheckBox)gvPreferences.Rows[2].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.PrintGeneralComments = ((CheckBox)gvPreferences.Rows[3].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.PrintPathologists = ((CheckBox)gvPreferences.Rows[4].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.GeneralComments = txtDescription.Text;
        obj_preferences.Printrecieptonspecimen = ((CheckBox)gvPreferences.Rows[5].Cells[2].FindControl("gvchkfield")).Checked == true ? "Y" : "N";
        obj_preferences.Recordsperpage_cashrec = txtrecordsperpage.Text.Trim();
        obj_preferences.Enteredby = Session["PersonID"].ToString().Trim();
        obj_preferences.ClientId = Session["orgid"].ToString();
        obj_preferences.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_preferences.Onbookingcashcollection = tbminimumcashpercentage.Text.Trim();
        obj_preferences.Roundingofffactor = txtRoundingoff.Text.Trim();
        obj_preferences.LoginInstructions = txtloginInstructions.Text.Trim();
        if (obj_preferences.Update())
        {

            this.lblErrMsg.Text = "<font color='green'>Settings Successfully Altered.</font>";
        }
        else
        {
            lblErrMsg.Text = obj_preferences.ErrorMessage;
        }
    }

    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>self.close();</script>");
    }
}