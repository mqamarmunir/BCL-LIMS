using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for SComponents
/// </summary>
public class SComponents
{
    public SComponents()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void FillDropDownList(DropDownList ddl, DataView dv, string strTextField, string strValueField)
    {
        ddl.DataTextField = strTextField;
        ddl.DataValueField = strValueField;
        dv.Sort = strTextField;
        ddl.DataSource = dv;
        ddl.DataBind();

        ListItem li = new ListItem("Select", "-1");
        ddl.Items.Insert(0, li);

        ddl.SelectedItem.Selected = false;
        ddl.Items[0].Selected = true;

    }
    //public void FillComboBox(AjaxControlToolkit.ComboBox ddl, DataView dv, string strTextField, string strValueField)
    //{
    //    ddl.DataTextField = strTextField;
    //    ddl.DataValueField = strValueField;
    //    dv.Sort = strTextField;
    //    ddl.DataSource = dv;
    //    ddl.DataBind();

    //    ListItem li = new ListItem("Select", "-1");
    //    ddl.Items.Insert(0, li);

    //    ddl.SelectedItem.Selected = false;
    //    ddl.Items[0].Selected = true;

    //}
    public void FillDropDownList_Local(DropDownList ddl, DataView dv, string strTextField, string strValueField)
    {
        ddl.DataTextField = strTextField;
        ddl.DataValueField = strValueField;
        dv.Sort = strTextField;
        ddl.DataSource = dv;
        ddl.DataBind();

        ListItem li = new ListItem("Local", "-1");
        ddl.Items.Insert(0, li);

        ddl.SelectedItem.Selected = false;
        ddl.Items[0].Selected = true;

    }
    public void FillDropDownList(DropDownList ddl, DataView dv, string strTextField, string strValueField, bool sort)
    {
        ddl.DataTextField = strTextField;
        ddl.DataValueField = strValueField;

        if (sort)
            dv.Sort = strTextField;

        ddl.DataSource = dv;
        ddl.DataBind();

        ListItem li = new ListItem("Select", "-1");
        ddl.Items.Insert(0, li);

        ddl.SelectedItem.Selected = false;
        ddl.Items[0].Selected = true;
    }

    public void FillDropDownList(DropDownList ddl, DataView dv, string strTextField, string strValueField, bool sort, bool isAll)
    {
        ddl.DataTextField = strTextField;
        ddl.DataValueField = strValueField;

        if (sort)
            dv.Sort = strTextField;

        ddl.DataSource = dv;
        ddl.DataBind();
        ListItem li;
        if (!isAll)
        {
            li = new ListItem("Select", "-1");
        }
        else
        {
            li = new ListItem("All", "");
        }
        ddl.Items.Insert(0, li);
        ddl.SelectedItem.Selected = false;
        ddl.Items[0].Selected = true;
    }

    public void FillDropDownList(DropDownList ddl, DataView dv, string strTextField, string strValueField, bool sort, bool isAll, bool isSelect)
    {
        ddl.DataTextField = strTextField;
        ddl.DataValueField = strValueField;

        if (sort)
            dv.Sort = strTextField;

        ddl.DataSource = dv;
        ddl.DataBind();
        ListItem li;
        if (!isAll)
        {
            if (isSelect)
            {
                li = new ListItem("Select", "-1");

                ddl.Items.Insert(0, li);
            }

        }
        else
        {
            li = new ListItem("Select All", "-1");
            ddl.Items.Insert(0, li);
        }

        if (dv.Count > 0)
        {
            ddl.SelectedItem.Selected = false;
            ddl.Items[0].Selected = true;
        }
    }

    public void FillDropDownList(RadioButtonList ddl, DataView dv, string strTextField, string strValueField, bool sort)
    {
        ddl.DataTextField = strTextField;
        ddl.DataValueField = strValueField;

        if (sort)
            dv.Sort = strTextField;

        ddl.DataSource = dv;
        ddl.DataBind();

    }




    public void FillDropDownListWithoutSelect(DropDownList ddl, DataView dv, string strTextField, string strValueField, bool sort, bool isAll)
    {
        ddl.DataTextField = strTextField;
        ddl.DataValueField = strValueField;

        if (sort)
            dv.Sort = strTextField;

        ddl.DataSource = dv;
        ddl.DataBind();
        ListItem li;
        if (isAll)
        {
            li = new ListItem("All", "");
            ddl.Items.Insert(0, li);
        }
    }

    public void FillDropDownListWithoutSelectmy(DropDownList ddl, DataView dv, string strTextField, string strValueField, bool sort, bool isAll)
    {
        ddl.DataTextField = strTextField;
        ddl.DataValueField = strValueField;

        if (sort)
            dv.Sort = strTextField;

        ddl.DataSource = dv;
        ddl.DataBind();
        ListItem li;
        if (isAll)
        {
            li = new ListItem("All Groups", "-1");
            ddl.Items.Insert(0, li);
        }
    }
    public void FillListBox(ListBox lb, DataView dv, string strTextField, string strValueField, bool strSort)
    {
        lb.DataTextField = strTextField;
        lb.DataValueField = strValueField;

        if (strSort)
            dv.Sort = strTextField;

        lb.DataSource = dv;
        lb.DataBind();
    }
}
