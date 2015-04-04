<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmProcedureD.aspx.cs" Inherits="procedure_d" Title="Procedure Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Procedure Detail</td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblError" runat="server"></asp:Label></td>
            <td colspan="2">
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
         <tr>
            <td></td>
            <td>
                Procedure:</td>
            <td class="mandatoryField" colspan="3">
                <asp:DropDownList ID="ddlProcedure" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlProcedure_SelectedIndexChanged">
                </asp:DropDownList></td>
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
                Process:</td>
            <td class="mandatoryField" colspan="3">
                <asp:DropDownList ID="ddlProcess" runat="server" Width="100%">
                </asp:DropDownList></td>
            <td></td>
            <td>
                <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label></td>
            <td></td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
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
            <td></td>
            <td></td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td colspan="4">
                <asp:GridView ID="gvProcedureD" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="procedureid,processid" OnRowCommand="gvProcedureD_RowCommand">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="procedurename" HeaderText="Procedure">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="45%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="processname" HeaderText="Process">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="45%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
            </td>
            <td></td>
            <td></td>
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

