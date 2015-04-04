<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmProcess.aspx.cs" Inherits="wprocess" Title="Process Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="main" cellpadding="1" cellspacing="1" border="0" class="label" width="100%">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Process Registration</td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
         <tr>
            <td colspan="5">
                <asp:Label ID="lblError" runat="server"></asp:Label></td>
            <td colspan="2">
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td></td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
         <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td align="right">
                <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" /></td>
            <td>
                <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label></td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td>
                Name:</td>
             <td colspan="3">
                 <asp:TextBox ID="txtProcess" runat="server" CssClass="mandatoryField" Width="99%"></asp:TextBox></td>
            <td align="right">
                Acronym:</td>
            <td>
                <asp:TextBox ID="txtAcronym" runat="server" CssClass="mandatoryField" MaxLength="10"></asp:TextBox></td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
         <tr>
            <td></td>
            <td></td>
            <td colspan="4">
                <asp:GridView ID="gvProcess" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="processid" OnRowCommand="gvProcess_RowCommand">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="Process">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="80%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="acronym" HeaderText="Acronym">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Active">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True">
                            <ItemStyle Width="5%" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
         <tr>
            <td width="5%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="5%"></td>            
        </tr>
    </table>
</asp:Content>

