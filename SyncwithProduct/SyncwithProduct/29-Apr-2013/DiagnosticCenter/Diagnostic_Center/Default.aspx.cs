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
using CustomUIControls;

public partial class _Default : System.Web.UI.Page
{
    clsDayCashCollection day = new clsDayCashCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gv1();
           // Gv2();
        }
    }

    public void Gv1()
    {
        DataView dv = new DataView();
        dv = day.GetAll(23);
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }

    public void Gv2()
    {
        DataView dv = new DataView();
        dv = day.GetAll(24);
        foreach (DataRowView dr in dv)
        {
            TreeNode ParentNode = new TreeNode();
            ParentNode.Text = dr["Name"].ToString();
            ParentNode.Value = dr["BranchID"].ToString();
            ParentNode.PopulateOnDemand = true;
            ParentNode.SelectAction = TreeNodeSelectAction.SelectExpand;
            ParentNode.Expand();
            ParentNode.Selected = true;
            (GridView2.Rows[1].FindControl("TreeView1") as TreeView).Nodes.Add(ParentNode);
            
            //this.TreeView1.Nodes.Add(tnParent);
        }
        //GridView2.DataSource = dv;
        //GridView2.DataBind();
    }

 //   protected void PopulateNode(Object sender, TreeNodeEventArgs e)
 //{
 //    string topicId = e.Node.Value;
 //    //select from topic where parentId = topicId.
 //    foreach (DataRow row in topics.Rows)
 //    {
 //        TreeNode node = new TreeNode(dr["name"], dr["topicId"])
 //        node.PopulateOnDemand = true;

 //        e.Node.ChildNodes.Add(node);
 //    }

 //}


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TreeView tv = (TreeView)(e.Row.FindControl("TreeView1"));

            DataView dv = new DataView();
            dv = day.GetAll(24);
            foreach (DataRowView dr in dv)
            {
                TreeNode ParentNode = new TreeNode();
                ParentNode.Text = dr["Name"].ToString();
                ParentNode.Value = dr["BranchID"].ToString();
                ParentNode.PopulateOnDemand = true;
                ParentNode.SelectAction = TreeNodeSelectAction.SelectExpand;
                ParentNode.Expand();
                ParentNode.Selected = true;
               
                tv.Nodes.Add(ParentNode);
                tv.DataBind();
            }
        }
    }
}