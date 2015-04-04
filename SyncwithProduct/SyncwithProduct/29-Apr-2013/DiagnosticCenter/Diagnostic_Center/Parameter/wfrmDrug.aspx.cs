using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessLayer;

public partial class Parameter_wfrmDrug : System.Web.UI.Page
{
  private static string DGSort = "";

  protected void Page_Load(object sender, EventArgs e)
  {
    Response.CacheControl = "no-cache";
    if (!Session["personid"].Equals(""))
    {
      if (!IsPostBack)
      {


        clsLogin log = new clsLogin();
        log.OptionId = "45";
        log.PersonId = Session["personid"].ToString();
        DataView dvLog = log.GetLogin(2);
        if (dvLog.Count > 0)
        {
          DGSort = "";
          //FillGV();
          FillGV();
          FillOrganismTV();

          lblStatus.Text = "i";
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

  protected void imgSave_Click(object sender, ImageClickEventArgs e)
  {
    if (lblStatus.Text == "i")
    {
      Insert();
    }
    else
    {
      Update();
    }
  }

  protected void imgClear_Click(object sender, ImageClickEventArgs e)
  {
    ClearField();
  }

  protected void imgClose_Click(object sender, ImageClickEventArgs e)
  {
    Response.Redirect("Mainpage.aspx");
  }

  private void ClearField()
  {
    txtName.Text = "";
    chbActive.Checked = true;
    txtAcronym.Text = "";
    txtDescription.Text = "";

    lblStatus.Text = "i";
    lblDrugID.Text = "";
    lblError.Text = "";
    FillOrganismTV();
  }

  private void Insert()
  {
    clsBLDrug objDrug= new clsBLDrug();
    string OrganismList = "";

    objDrug.Drug= this.txtName.Text.Trim();
    objDrug.Acronym = this.txtAcronym.Text.Trim();
    objDrug.Active = this.chbActive.Checked ? "Y" : "N";
    objDrug.Description = this.txtDescription.Text.Trim();
    objDrug.EnteredBy = Session["personid"].ToString();
    objDrug.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
    objDrug.ClientID = Session["orgid"].ToString();

    for (int i = 0; i < tvOrganism.Nodes[0].ChildNodes.Count; i++)
    {
      if (tvOrganism.Nodes[0].ChildNodes[i].Checked)
      {
        OrganismList += tvOrganism.Nodes[0].ChildNodes[i].Value + " , ";
        ;
      }
    }

    if (objDrug.Insert(OrganismList))
    {
      ClearField();
      lblError.ForeColor = System.Drawing.Color.Green;
      lblError.Text = "Record has been saved successfully";
      FillGV();
    }
    else
    {
      lblError.ForeColor = System.Drawing.Color.Red;
      lblError.Text = objDrug.ErrorMessage;
    }

  }

  private void Update()
  {
    clsBLDrug objDrug = new clsBLDrug();
    string OrganismList = "";

    objDrug.DrugID = lblDrugID.Text;
    objDrug.Drug= this.txtName.Text.Trim();
    objDrug.Acronym = this.txtAcronym.Text.Trim();
    objDrug.Active = this.chbActive.Checked ? "Y" : "N";
    objDrug.Description = this.txtDescription.Text.Trim();
    objDrug.EnteredBy = Session["personid"].ToString();
    objDrug.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
    objDrug.ClientID = Session["orgid"].ToString();

    for (int i = 0; i < tvOrganism.Nodes[0].ChildNodes.Count; i++)
    {
      if (tvOrganism.Nodes[0].ChildNodes[i].Checked)
      {
        OrganismList += tvOrganism.Nodes[0].ChildNodes[i].Value + " , ";
        ;
      }
    }

    if (objDrug.Update(OrganismList))
    {
      ClearField();
      lblError.ForeColor = System.Drawing.Color.Green;
      lblError.Text = "Record has been updated successfully";
      FillGV();
    }
    else
    {
      lblError.ForeColor = System.Drawing.Color.Red;
      lblError.Text = objDrug.ErrorMessage;
    }

  }

  private void FillGV()
  {
    clsBLDrug objDrug = new clsBLDrug();

    DataView dv = objDrug.GetAll(1);
    if (dv.Count > 0)
    {
      dv.Sort = DGSort;
      gvDrug.DataSource = dv;
      gvDrug.DataBind();
    }
    else
    {
      gvDrug.DataSource = null;
      gvDrug.DataBind();
    }
  }

  protected void gvDrug_Sorting(object sender, GridViewSortEventArgs e)
  {
    this.lblError.Text = "";

    if (e.SortExpression.Equals("Drug"))
    {
      if (DGSort == "Drug ASC")
        DGSort = "Drug DESC";
      else
        DGSort = "Drug ASC";
    }
    else if (e.SortExpression.Equals("Acronym"))
    {
      if (DGSort == "Acronym ASC")
        DGSort = "Acronym DESC";
      else
        DGSort = "Acronym ASC";
    }
    else if (e.SortExpression.Equals("Description"))
    {
      if (DGSort == "Description ASC")
        DGSort = "Description DESC";
      else
        DGSort = "Description ASC";
    }

    FillGV();
  }
  
  protected void gvDrug_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    lblError.Text = "";

    if (e.CommandName.Equals("Select"))
    {
      int index = Convert.ToInt32(e.CommandArgument);

      lblDrugID.Text = gvDrug.DataKeys[index].Values[0].ToString().Replace("&nbsp;", "");
      txtName.Text = gvDrug.Rows[index].Cells[1].Text.Trim().Replace("&nbsp;", "");
      txtAcronym.Text = gvDrug.Rows[index].Cells[2].Text.Trim().Replace("&nbsp;", "");
      txtDescription.Text = gvDrug.Rows[index].Cells[3].Text.Trim().Replace("&nbsp;", "");
      chbActive.Checked = ((CheckBox)(gvDrug.Rows[index].Cells[4].FindControl("chkGVActive"))).Checked;
      getOrganism();

      lblStatus.Text = "u";
    }
  }

  private void FillOrganismTV()
  {
    clsBLOrganism objOrgan= new clsBLOrganism();

    tvOrganism.Nodes.Clear();

    DataView dv = objOrgan.GetAll(4);
    TreeNode tn = new TreeNode();
    tn.Text = "Select";
    tn.Value = "0";
    tvOrganism.Nodes.Add(tn);
    tvOrganism.Nodes[0].SelectAction = TreeNodeSelectAction.None;

    for (int i = 0; i < dv.Table.Rows.Count; i++)
    {
      tn = new TreeNode();
      tn.Text = dv.Table.Rows[i]["Organism"].ToString();
      tn.Value = dv.Table.Rows[i]["OrganismID"].ToString();
      tvOrganism.Nodes[0].ChildNodes.Add(tn);
      tvOrganism.Nodes[0].ChildNodes[i].SelectAction = TreeNodeSelectAction.None;
    }

    tvOrganism.ExpandAll();
  }

  private void getOrganism()
  {
    if (!lblDrugID.Equals(""))
    {
      clsBLDrugOrganism objDrugOrgan = new clsBLDrugOrganism();

      objDrugOrgan.DrugID= lblDrugID.Text;
      objDrugOrgan.Type = "D";

      DataView dv = objDrugOrgan.GetAll(4);
      for (int j = 0; j < tvOrganism.Nodes[0].ChildNodes.Count; j++)
      {
        tvOrganism.Nodes[0].ChildNodes[j].Checked = false;
      }

      for (int i = 0; i < dv.Table.Rows.Count; i++)
      {
        for (int j = 0; j < tvOrganism.Nodes[0].ChildNodes.Count; j++)
        {
          if (tvOrganism.Nodes[0].ChildNodes[j].Value.Equals(dv.Table.Rows[i]["OrganismID"].ToString()))
          {
            tvOrganism.Nodes[0].ChildNodes[j].Checked = true;
            break;
          }
        }
      }
    }
  }
}
