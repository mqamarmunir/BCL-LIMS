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

public partial class Parameter_wfrmOrganism : System.Web.UI.Page
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
        log.OptionId = "44";
        log.PersonId = Session["personid"].ToString();
        DataView dvLog = log.GetLogin(2);
        if (dvLog.Count > 0)
        {
          DGSort = "";
          FillGV();
          FillDrugTV();
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
    lblOrganismID.Text = "";
    lblError.Text = "";
    FillDrugTV();
  }

  private void Insert()
  {
    clsBLOrganism objOrganism = new clsBLOrganism();
    string OrganismList = "";

    objOrganism.Organism = this.txtName.Text.Trim();
    objOrganism.Acronym = this.txtAcronym.Text.Trim();
    objOrganism.Active = this.chbActive.Checked ? "Y" : "N";
    objOrganism.Description = this.txtDescription.Text.Trim();
    objOrganism.EnteredBy = Session["personid"].ToString();
    objOrganism.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
    objOrganism.ClientID = Session["orgid"].ToString();

    for (int i = 0; i < tvDrug.Nodes[0].ChildNodes.Count; i++)
    {
      if (tvDrug.Nodes[0].ChildNodes[i].Checked)
      {
        OrganismList += tvDrug.Nodes[0].ChildNodes[i].Value + " , ";
        ;
      }
    }

    if (objOrganism.Insert(OrganismList))
    {
      ClearField();
      lblError.ForeColor = System.Drawing.Color.Green;
      lblError.Text = "Record has been saved successfully";
      FillGV();
    }
    else
    {
      lblError.ForeColor = System.Drawing.Color.Red;
      lblError.Text = objOrganism.ErrorMessage;
    }

  }

  private void Update()
  {
    clsBLOrganism objOrganism = new clsBLOrganism();
    string OrganismList = "";

    objOrganism.OrganismID = lblOrganismID.Text;
    objOrganism.Organism = this.txtName.Text.Trim();
    objOrganism.Acronym = this.txtAcronym.Text.Trim();
    objOrganism.Active = this.chbActive.Checked ? "Y" : "N";
    objOrganism.Description = this.txtDescription.Text.Trim();
    objOrganism.EnteredBy = Session["personid"].ToString();
    objOrganism.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
    objOrganism.ClientID = Session["orgid"].ToString();

    for (int i = 0; i < tvDrug.Nodes[0].ChildNodes.Count; i++)
    {
      if (tvDrug.Nodes[0].ChildNodes[i].Checked)
      {
        OrganismList += tvDrug.Nodes[0].ChildNodes[i].Value + " , ";
        ;
      }
    }

    if (objOrganism.Update(OrganismList))
    {
      ClearField();
      lblError.ForeColor = System.Drawing.Color.Green;
      lblError.Text = "Record has been updated successfully";
      FillGV();
    }
    else
    {
      lblError.ForeColor = System.Drawing.Color.Red;
      lblError.Text = objOrganism.ErrorMessage;
    }

  }

  private void FillGV()
  {
    clsBLOrganism objOrganism = new clsBLOrganism();
    DataView dv = objOrganism.GetAll(1);
    if (dv.Count > 0)
    {
      dv.Sort = DGSort;
      gvOrganism.DataSource = dv;
      gvOrganism.DataBind();
    }
    else
    {
      gvOrganism.DataSource = null;
      gvOrganism.DataBind();
    }
  }

  protected void gvOrganism_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    lblError.Text = "";

    if (e.CommandName.Equals("Select"))
    {
      int index = Convert.ToInt32(e.CommandArgument);

      lblOrganismID.Text = gvOrganism.DataKeys[index].Value.ToString().Replace("&nbsp;", "");

      txtName.Text = gvOrganism.Rows[index].Cells[1].Text.Trim().Replace("&nbsp;", "");
      txtAcronym.Text = gvOrganism.Rows[index].Cells[2].Text.Trim().Replace("&nbsp;", "");
      txtDescription.Text = gvOrganism.Rows[index].Cells[3].Text.Trim().Replace("&nbsp;", "");

      chbActive.Checked = ((CheckBox)(gvOrganism.Rows[index].Cells[4].FindControl("chkGVActive"))).Checked;

      getDrug();

      lblStatus.Text = "u";

    }
  }

  protected void gvOrganism_Sorting(object sender, GridViewSortEventArgs e)
  {
    this.lblError.Text = "";

    if (e.SortExpression.Equals("Organism"))
    {
      if (DGSort == "Organism ASC")
        DGSort = "Organism DESC";
      else
        DGSort = "Organism ASC";
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
  
  private void FillDrugTV()
  {
    clsBLDrug objDrug = new clsBLDrug();

    tvDrug.Nodes.Clear();

    DataView dv = objDrug.GetAll(4);
    TreeNode tn = new TreeNode();
    tn.Text = "Select";
    tn.Value = "0";
    tvDrug.Nodes.Add(tn);
    tvDrug.Nodes[0].SelectAction=TreeNodeSelectAction.None  ;

    for (int i = 0; i < dv.Table.Rows.Count; i++)
    {
      tn= new TreeNode();
      tn.Text = dv.Table.Rows[i]["Drug"].ToString();
      tn.Value = dv.Table.Rows[i]["DrugID"].ToString();
      tvDrug.Nodes[0].ChildNodes.Add(tn);
      tvDrug.Nodes[0].ChildNodes[i].SelectAction = TreeNodeSelectAction.None;
    }

    tvDrug.ExpandAll();
  }

  private void getDrug()
  {
    if (!lblOrganismID.Equals(""))
    {
      clsBLDrugOrganism objDrugOrgan = new clsBLDrugOrganism();

      objDrugOrgan.OrganismID = lblOrganismID.Text;
      objDrugOrgan.Type = "O";

      DataView dv = objDrugOrgan.GetAll(2);
      for (int j = 0; j < tvDrug.Nodes[0].ChildNodes.Count; j++)
      {
        tvDrug.Nodes[0].ChildNodes[j].Checked = false;
      }

      for (int i = 0; i < dv.Table.Rows.Count; i++)
      {
        for (int j = 0; j < tvDrug.Nodes[0].ChildNodes.Count; j++)
        {
          if (tvDrug.Nodes[0].ChildNodes[j].Value.Equals(dv.Table.Rows[i]["DrugID"].ToString()))
          {
            tvDrug.Nodes[0].ChildNodes[j].Checked = true;
            break;
          }
        }
      }
    }
  }

}