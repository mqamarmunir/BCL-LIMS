<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="wfrmOrganism.aspx.cs" Inherits="Parameter_wfrmOrganism" Title="Oranism"%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
    
    <table border="0"  cellpadding="1" cellspacing="1" class="label" runat="server" style="width:100%;height:auto">
    
        <tr>
            <td style="width:5%;">
            </td>
            
            <td style="width:15%">
            </td>
            
            <td style="width:30%">
            </td>
            
            <td style="width:15%">
            </td>
            
            <td style="width:30%">
            </td>
            
            <td style="width:5%">
            </td>
            
        </tr>
        
        <tr>
            <td align="center" class="tdheading" colspan="6">
                Organism
            </td>
        </tr>
    
        <tr>
            <td class="screenid" colspan="6">
                <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label><asp:Label ID="lblOrganismID"
                    runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    
       <tr>
            <td colspan="4">
                <asp:Label ID="lblError" runat="server" Width="100%">
                </asp:Label>
            </td>
            <td align="left" >
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" TabIndex="5" /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" TabIndex="6" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" TabIndex="7" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="6">
            </td>
        </tr>
        
        <tr>
            <td >
            </td>
            <td >
                Name :</td>
            <td colspan="2" >
                <asp:TextBox ID="txtName" runat="server" CssClass="mandatoryField" Width="90%" MaxLength="50" TabIndex="1" ToolTip="Organism Name"></asp:TextBox>
             </td>
             <td  valign="top" align="left" rowspan="4">
                <div style="vertical-align:top; height:250px;width:250px;position:fixed;overflow:auto;" >
                     Drug : <asp:TreeView ID="tvDrug" runat="server" ShowCheckBoxes="Leaf" ForeColor="Black" Width="98%" ShowLines="true" TabIndex="5" AutoGenerateDataBindings="False" >
                     </asp:TreeView>
                 </div>             
             </td>
             <td>
             </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Acronym :</td>
            <td>
                 
                <asp:TextBox ID="txtAcronym" runat="server" Width="20%" MaxLength="10" CssClass="field" TabIndex="2" ToolTip="Organism Acronym">
                </asp:TextBox>
                 <asp:CheckBox ID="chbActive" Checked="true"  runat="server" Text="Active : " TextAlign="Left" TabIndex="3" ToolTip="Active" />
             </td>
             <td>
             </td>
             <td>
             </td>
             <td>
             </td>
        </tr>
        <tr>
            <td>
            </td>
            <td valign="top">
                Description :</td>
            <td colspan="2">
                <asp:TextBox ID="txtDescription" runat ="server" Width="90%" TextMode="MultiLine"  MaxLength="250" CssClass="field" TabIndex="4" ToolTip="Description">
                </asp:TextBox>
            </td>
            <td >
            </td>
            <td>
             </td>
        </tr>
        
        <tr>
            <td >
            </td>
            <td colspan="3" style="width:100%">
                <asp:GridView ID="gvOrganism" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="OrganismID" Width="100%" OnRowCommand="gvOrganism_RowCommand" AllowSorting="True" OnSorting="gvOrganism_Sorting" >
                    <RowStyle  CssClass="gridItem" />      
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />          
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Organism" HeaderText="Name" SortExpression="Organism">
                            <ItemStyle Width="35%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Acronym" HeaderText="Acronym" SortExpression="Acronym">
                            <ItemStyle Width="10%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                            <ItemStyle Width="40%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Active">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True">
                            <ItemStyle Width="5%"  HorizontalAlign="Center"/>
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            
            </td>
            <td>
            </td>
            <td >
            </td>
        </tr>
    
    </table>  
    
</asp:Content>
