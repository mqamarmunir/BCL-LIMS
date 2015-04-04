using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Globalization;

public partial class Parameter_wfrmGazzetedHolidays : System.Web.UI.Page
{
    private static string mode = "insert";
    private static string holidays = "";
    private static int firsttime = 0;
    private static string holiday_desc="";
    private static string[] _arrayholidays = null;
    private static string[] _arraydescription = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        calholidays.UseAccessibleHeader = false;
        Response.CacheControl = "no-cache";
        if (!Session["personid"].Equals(""))
        {
            if (!IsPostBack)
            {
                firsttime = 0; 
                clsLogin log = new clsLogin();
                log.OptionId = "81";
                log.PersonId = Session["personid"].ToString();
                DataView dvLog = log.GetLogin(2);
                if (dvLog.Count > 0)
                {
                    txtdateFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    FillGV();
                    BindCalender(System.DateTime.Now.Year.ToString());


                }
                else
                {
                    Response.Redirect("wfrmNotAllowed.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }
        
    

    private void BindCalender(string _currentyear)
    {
        clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
        obj_holidays.Active = "Y";
        DataView dv = obj_holidays.GetAll(1);
        if (dv.Count > 0)
        {
            _arraydescription = null;
            _arrayholidays = null;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["Type"].ToString().Trim() == "P")
                {
                    DateTime dt = DateTime.Parse(dv[i]["Date_From"].ToString().Substring(0,5)+"/"+_currentyear, new CultureInfo("en-GB", false));
                    calholidays.SelectedDates.Add(dt);
                    holidays += dt.ToString("dd/MM/yyyy") + ",";
                    holiday_desc += dv[i]["Description"].ToString().Trim() + ":";
                }
                else if (dv[i]["Type"].ToString().Trim() == "S")
                {
                    int noofholidays =Convert.ToInt16((DateTime.Parse(dv[i]["Date_To"].ToString().Trim(), new CultureInfo("en-GB", false)) - DateTime.Parse(dv[i]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false))).TotalDays);
                    for (int j = 0; j <= noofholidays; j++)
                    {
                        DateTime dt = DateTime.Parse(dv[i]["Date_From"].ToString().Trim(), new CultureInfo("en-GB", false));
                        dt=dt.AddDays(j);
                        calholidays.SelectedDates.Add(dt);
                        if (firsttime == 0)
                        {
                            holidays += dt.ToString("dd/MM/yyyy") + ",";
                            holiday_desc += dv[i]["Description"].ToString().Trim() + ":";
                            
                        }
                    }
                    firsttime++;
                }
            }
            
            _arrayholidays = holidays.Split(',');
            _arraydescription = holiday_desc.Split(':');
           
        }
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
        clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
        obj_holidays.Active = chkActive.Checked == true ? "Y" : "N";
        obj_holidays.BranchID = Session["BranchID"].ToString().Trim();
        obj_holidays.ClientId = Session["OrgID"].ToString().Trim();
        obj_holidays.Date_From = txtdateFrom.Text.Trim();
        if (rdoSeasonal.Checked == true)
        {
            obj_holidays.Date_To = txtToDate.Text.Trim();
            obj_holidays.Type = "S";
        }
        else
        {
            obj_holidays.Type = "P";
        }
        obj_holidays.Description = txtDescription.Text.Trim();
        obj_holidays.Enteredby = Session["personid"].ToString().Trim();
        obj_holidays.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        if (obj_holidays.Insert())
        {
            this.lblError.Text = "<font color='green'>Record Inserted Successfully.</font>";
            FillGV();
            BindCalender(System.DateTime.Now.Year.ToString());
            RefreshForm();
        }
        else
        {
            this.lblError.Text = obj_holidays.ErrorMessage;
            RefreshForm();
        }
      
        
    }

    private void Update()
    {
        clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
        obj_holidays.HolidayID = hdholidayid.Value.ToString().Trim();
        obj_holidays.Active = chkActive.Checked == true ? "Y" : "N";
        obj_holidays.BranchID = Session["BranchID"].ToString().Trim();
        obj_holidays.ClientId = Session["OrgID"].ToString().Trim();
        obj_holidays.Date_From = txtdateFrom.Text.Trim();
        if (rdoSeasonal.Checked == true)
        {
            obj_holidays.Date_To = txtToDate.Text.Trim();
            obj_holidays.Type = "S";
        }
        else
        {
            obj_holidays.Type = "P";
        }
        obj_holidays.Description = txtDescription.Text.Trim();
        obj_holidays.Enteredby = Session["personid"].ToString().Trim();
        obj_holidays.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        if (obj_holidays.Update())
        {
            this.lblError.Text = "<font color='green'>Record Updated Successfully.</font>";
            FillGV();
            BindCalender(System.DateTime.Now.Year.ToString());
            RefreshForm();
        }
        else
        {
            this.lblError.Text = obj_holidays.ErrorMessage;
            RefreshForm();
        }
    }

    private void FillGV()
    {
        clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
        DataView dv = obj_holidays.GetAll(1);
        if (dv.Count > 0)
        {
            gvholidays.DataSource = dv;
            gvholidays.DataBind();
        }
        else
        {
            gvholidays.DataSource = "";
            gvholidays.DataBind();
        }
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        this.rdoPermanent.Checked = true;
        this.rdoSeasonal.Checked = false;
        mode = "";
        txtdateFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        this.rdoPermanent_CheckedChanged(sender, e);
        this.lblError.Text = "";
    }

    private void RefreshForm()
    {
        rdoPermanent.Checked = true;
        rdoSeasonal.Checked = false;
        if (rdoPermanent.Checked == true)
        {
            lblFrom.Visible = false;
            lblTo.Visible = false;
            txtToDate.Visible = false;
        }
        mode = "";
        txtdateFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtToDate.Text = "";
        txtDescription.Text = "";

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Parameter/MainPage.aspx");
    }
    protected void rdoSeasonal_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoSeasonal.Checked == true)
        {
            lblFrom.Visible = true;
            lblTo.Visible = true;
            txtToDate.Visible = true;
        }
    }
    protected void rdoPermanent_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoPermanent.Checked == true)
        {
            lblFrom.Visible = false;
            lblTo.Visible = false;
            txtToDate.Visible = false;
        }
    }

    protected void gvholidays_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            hdholidayid.Value = gvholidays.DataKeys[index].Values[0].ToString();
            mode = "update";
            FillForm();
        }
    }

    private void FillForm()
    {
        clsBLGazzetedHolidays obj_holidays = new clsBLGazzetedHolidays();
        obj_holidays.HolidayID = hdholidayid.Value.ToString();
        DataView dv_holiday = obj_holidays.GetAll(1);
        if (dv_holiday.Count > 0)
        {
            if (dv_holiday[0]["Type"].ToString().Trim() == "S")
            {
                lblFrom.Visible = true;
                lblTo.Visible = true;
                txtToDate.Visible = true;
                txtToDate.Text = dv_holiday[0]["Date_To"].ToString().Replace(" 00:00:00", ""); ;
                rdoSeasonal.Checked=true;

            }
            else if(dv_holiday[0]["Type"].ToString().Trim() == "P")
            {
                rdoPermanent.Checked=true;
                lblFrom.Visible = false;
                lblTo.Visible = false;
                txtToDate.Visible = false;
            }
            txtdateFrom.Text = dv_holiday[0]["Date_From"].ToString().Replace(" 00:00:00", ""); 
            chkActive.Checked = dv_holiday[0]["Active"].ToString().Trim()=="Y"?true:false;
            txtDescription.Text=dv_holiday[0]["Description"].ToString().Trim();



        }
    }

    protected void calholidays_monthChanged(object sender, MonthChangedEventArgs e)
    {
        string _currentyear = e.NewDate.Year.ToString();
        if (_currentyear != System.DateTime.Now.Year.ToString())
        {
            BindCalender(_currentyear);
        }
    }

    protected void calholidays_DayRender(object sender, DayRenderEventArgs e)
    {
        //if (holidays.Length > 0 && holidays.Trim().Substring(holidays.Length-1,1).Equals(","))
        //{
        //    holidays = holidays.Substring(0, holidays.Length - 1);

        //}
        for (int i = 0; i < _arrayholidays.Length - 1; i++)
        {
            if (e.Day.Date.ToString("dd/MM/yyyy") == _arrayholidays[i])
            {

                e.Cell.ToolTip = _arraydescription[i];

            }
        }
    }
}