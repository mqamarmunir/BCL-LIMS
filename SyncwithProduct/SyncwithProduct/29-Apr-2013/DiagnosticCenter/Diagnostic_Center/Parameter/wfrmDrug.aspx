<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmDrug.aspx.cs" Inherits="Parameter_wfrmDrug" Title="Drug"  %>
 
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content" runat="server">
    <table border="0" cellpadding="1" cellspacing="1" class="label" runat="server" style="width:100%;height:100%;">
        
        <tr>
            <td style="width:5%" >
            </td>
            <td style="width:10%" >
            </td>
            <td style="width:50%" >
            </td>
            <td style="width:10%" >
            </td>
            <td style="width:20%" >
            </td>
            <td style="width:5%" >
            </td>
        </tr>
        
        <tr>
            <td align="center" class="tdheading" colspan="6">
                Drug
            </td>
        </tr>
        
        <tr>
            <td colspan="6">
                <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblDrugID" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblError" runat ="server" Width="100%" ForeColor="Red"></asp:Label>
             </td>
             <td colspan="2" align="left">
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" TabIndex="6" /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" TabIndex="7" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" TabIndex="8" />
             </td>
        </tr>
        <tr>
            <td colspan="6">
            </td>
        </tr>
        
        <tr>
            <td>
            </td>
            <td>
                Name :</td>
            <td >
                <asp:TextBox ID="txtName" runat="server" CssClass="mandatoryField" Width="99%" MaxLength="50" TabIndex="1" ToolTip="Drug Name">
                </asp:TextBox>
            </td>
             <td colspan="2" valign="top" align="left" rowspan ="5" >
                <div style="vertical-align:top; height:250px;width:250px;position:fixed;overflow:auto;" >
                    <%--<asp:Panel ID="pnlTv" runat="server" ScrollBars="vertical" Width="100%" Height="100%">--%>
                    Organism<asp:TreeView ID="tvOrganism" runat="server" ForeColor="Black" ShowCheckBoxes="Leaf" ShowLines="True" TabIndex="6"
                         Width="98%"  >
                        </asp:TreeView>
                    <%--</asp:Panel>--%>
                 </div>
             </td>
             <td >
            </td>
        </tr>
        <tr>
            <td >
            </td>
            <td >
                Acronym :</td>
            <td >
                <asp:TextBox ID="txtAcronym" runat="server" Width="20%" MaxLength="10" CssClass="field" TabIndex="2" ToolTip="Drug Acronym">
                </asp:TextBox>
                &nbsp;
                 <asp:CheckBox ID="chbActive" Checked="true"  runat="server" Text="Active : " TextAlign="Left" TabIndex="3" ToolTip="Drug Active"  />
            </td>
            <td >
            </td>
        </tr>
        
        <tr>
            <td>
            </td>
            <td valign="top">
                Description :
            </td>
            <td >
                <asp:TextBox ID="txtDescription" runat ="server" Width="99%" TextMode="MultiLine"  MaxLength="250" CssClass="field" TabIndex="4" ToolTip="Drug Description"></asp:TextBox>
            </td>
            <td >
            </td>
        </tr>
        
        <tr>
            <td colspan="3">
            </td>
            <td >
            </td>
        </tr>
        
        <tr>
            <td >
            </td>
            <td colspan="2" style="width:99%;" >
                <asp:GridView ID="gvDrug" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="DrugID" Width="100%" OnRowCommand="gvDrug_RowCommand" AllowSorting="True" OnSorting="gvDrug_Sorting" >
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
                        <asp:BoundField DataField="Drug" HeaderText="Name" SortExpression="Drug">
                            <ItemStyle Width="40%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Acronym" HeaderText="Acronym" SortExpression="Acronym">
                            <ItemStyle Width="10%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                            <ItemStyle Width="35%" />
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
            <td >
            </td>
        </tr>
    </table> 
</asp:Content>