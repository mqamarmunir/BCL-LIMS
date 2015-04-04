<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBranchGroups.aspx.cs" Inherits="Parameter_wfrmBranchGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">

     function filtertext(term, _id, cellNr) {
         // alert("I am called");
         var suche = term.value.toLowerCase();
         // var x = document.getElementById(_id);
         //  alert(x);
         var table = document.getElementById(_id);
         //alert(_id);
         var ele;
         for (var r = 1; r < table.rows.length; r++) {
             ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
             if (ele.toLowerCase().indexOf(suche) >= 0)
                 table.rows[r].style.display = '';
             else table.rows[r].style.display = 'none';

             //      alert(table.rows[1].cells[1].innerHTML.toString());
         }
     }
    </script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 

<table id="tblbody" class="label" cellpadding="1" cellspacing="1" width="100%">
<tr>
<td colspan="7" align="center"> <font size="4"><strong>Branch Groups/Packages</strong></font>

</td>

</tr>
<tr>
<td colspan="7" align="right">
 <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="12" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" Visible="false" AccessKey="s" OnClick="lbtnSave_Click" />
 <asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="13" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" />
<asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                                        TabIndex="14" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" />

</td>

</tr>
<tr>
<td colspan="7"><asp:UpdatePanel ID="updteerr" runat="server">
<ContentTemplate>
<asp:Label ID="lblErrMsg" ForeColor="Red" runat="server" Font-Size="X-Small"></asp:Label>

</ContentTemplate>
</asp:UpdatePanel></td>

</tr>
<tr>
<td align="right">Branch:</td>
<td><asp:DropDownList ID="ddlOrganiztions" runat="server" Width="10%" 
        CssClass="dropdown" AutoPostBack="True" 
        onselectedindexchanged="ddlOrganiztions_SelectedIndexChanged" Visible="false"></asp:DropDownList> 


<asp:DropDownList ID="ddlBranch" runat="server" Width="90%" 
        CssClass="dropdown" AutoPostBack="True" 
        onselectedindexchanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList> 
    </td>
<td align="center">&nbsp;</td>
<td>
    &nbsp;</td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td></td>
<td></td>
<td>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
           <DIV class="UpdateProgress"><asp:Image id="Image1" runat="server" ImageUrl="../images/loading.gif" __designer:wfdid="w6"></asp:Image> ........Loading! Please Wait </DIV>
        </ProgressTemplate>
    </asp:UpdateProgress></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td colspan="3">
<asp:UpdatePanel ID="updtpanel" runat="server">
<ContentTemplate>

  <div runat="server" visible="false" id="divpanels">
    <fieldset>
    <legend>Organization Groups/Packages</legend>
        <table id="tblpanels" width="99%" class="label">
            <tr>
            <td colspan="2">Filter:<input type="text" class="field" id="Filtertest" onkeyup="filtertext(this,'<%=gvGroups.ClientID %>',1)" /></td>
            <td colspan="2" align="right">
                <asp:LinkButton 
                ID="lnkAddSelected" runat="server" Text="Add Selected" 
                OnClick="lnkAddSelected_Click"></asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkAddAll" runat="server" Text="Add All" 
                OnClick="lnkAddAll_Click"></asp:LinkButton>
            
            
                </td>
          
            </tr>
            <tr>
            <td colspan="4">
            
             <asp:Panel ID="pnlTests" runat="server" Height="300" ScrollBars="Auto">
             <asp:GridView ID="gvGroups" Width="99%" runat="server" CssClass="label" AutoGenerateColumns="false"
              DataKeyNames="GroupID">
             <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
             <RowStyle CssClass="gridItem" />
             <AlternatingRowStyle CssClass="gridAlternate" />
             <Columns>
             <asp:TemplateField HeaderText="S#">
             <HeaderStyle HorizontalAlign="Center" Width="5%" />
             <ItemStyle HorizontalAlign="Center" Width="5%" />
             <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
             </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField HeaderText="Name" DataField="Name" />
             <asp:BoundField Visible="false" />
             <asp:TemplateField>
                          <HeaderStyle HorizontalAlign="Center" Width="5%" />
             <ItemStyle HorizontalAlign="Center" Width="5%" />
             <ItemTemplate>
             <asp:CheckBox ID="gvchkselect" runat="server" />
             </ItemTemplate>
             </asp:TemplateField>
             </Columns>
             </asp:GridView>

             </asp:Panel>
             </td>
            
            </tr>
            <tr>
            <td width="25%"></td>
            <td width="25%"></td>
            <td width="25%"></td>
            <td width="25%"></td>
            </tr>
        </table>
    </fieldset>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="ddlOrganiztions" EventName="SelectedIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</td>
<td colspan="4">
<asp:UpdatePanel ID="updteselected" runat="server">
<ContentTemplate>


  <div runat="server" visible="false" id="divSelected">
    <fieldset>
    <legend>Branch Groups</legend>
        <table id="tblSelected" width="99%" class="label">
            <tr>
            <td colspan="2">Filter:<input type="text" class="field" id="txtfilter1" onkeyup="filtertext(this,'<%=gvSelected.ClientID %>',1)" /></td>
            <td colspan="2" align="right">
                
            &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkRemoveAll" runat="server" Text="Remove All" 
                OnClick="lnkRemoveAll_Click"></asp:LinkButton>
            
            
                </td>
          
            </tr>
            <tr>
            <td colspan="4">
            
             <asp:Panel ID="pnlselected" runat="server" Height="300" ScrollBars="Auto">
             <asp:GridView ID="gvSelected" Width="99%" runat="server" CssClass="label" AutoGenerateColumns="false"
             OnRowDeleting="gvSelected_RowDeletingClick" DataKeyNames="branchgroupid,groupid,branchid">
             <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
             <RowStyle CssClass="gridItem" />
             <AlternatingRowStyle CssClass="gridAlternate" />
             <Columns>
             <asp:TemplateField HeaderText="S#">
             <HeaderStyle HorizontalAlign="Center" Width="5%" />
             <ItemStyle HorizontalAlign="Center" Width="5%" />
             <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
             </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField HeaderText="Panel Name" DataField="PanelName" />
             <asp:BoundField Visible="false" />
             <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/images/Delete.gif">
             <HeaderStyle Width="5%" />
             <ItemStyle Width="5%" />
             </asp:CommandField>
             </Columns>
             </asp:GridView>

             </asp:Panel>
             </td>
            
            </tr>
            <tr>
            <td width="25%"></td>
            <td width="25%"></td>
            <td width="25%"></td>
            <td width="25%"></td>
            </tr>
        </table>
    </fieldset>
  </div>
  </ContentTemplate>
  <Triggers>
  <asp:AsyncPostBackTrigger ControlID="ddlbranch" EventName="SelectedIndexChanged" />
  <asp:AsyncPostBackTrigger ControlID="lnkAddSelected" EventName="Click" />
  <asp:AsyncPostBackTrigger ControlID="lnkAddAll" EventName="Click" />
  </Triggers>
</asp:UpdatePanel>
</td>


</tr>
<tr>
<td width="15%"></td>
<td width="20%"></td>
<td width="15%"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>

<tr>
<td width="15%"></td>
<td width="20%"></td>
<td width="15%"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>
</table>
        </table>
</asp:Content>