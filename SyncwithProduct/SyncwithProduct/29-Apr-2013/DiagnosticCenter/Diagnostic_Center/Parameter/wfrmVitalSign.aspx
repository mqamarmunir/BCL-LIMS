<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmVitalSign.aspx.cs" Inherits="vitalsign" Title="Vital Sign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table id="main" cellpadding="1" cellspacing="1" border="0" class="label" width="100%">
    <tr>
        <td align="center" class="tdheading" colspan="8">
            Vital Sign Registration</td>
    </tr>
    <tr>
        <td class="screenid" colspan="8">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Label ID="lblError" runat="server"></asp:Label></td>
        <td>
        </td>
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
        <td>
        </td>
        <td>
            Sign Name:</td>
        <td>
            <asp:TextBox ID="txtVitalSign" runat="server" CssClass="mandatoryField" MaxLength="20"
                Width="98%"></asp:TextBox></td>
        <td>
            Unit:</td>
        <td>
            <asp:TextBox ID="txtUnit" runat="server" CssClass="mandatoryField" MaxLength="20" Width="98%"></asp:TextBox></td>
        <td>
            &nbsp;
            <asp:CheckBox ID="chkActive" Text="Active" runat="server" Checked="True" TextAlign="Left" /></td>
        <td>
            <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label><asp:Label ID="lblID" runat="server" Visible="False"></asp:Label></td>
        <td>
        </td>
    </tr>
    <tr>
        <td class="screenid" colspan="8">
            &nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td></td>
        <td colspan="4">
            <asp:GridView ID="gvVital" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="vitalid" OnRowCommand="gvVital_RowCommand">
                <RowStyle CssClass="gridItem" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>:
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="Sign Name">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="unit" HeaderText="Unit">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Active">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkgvActive" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' runat="server" Enabled="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
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
        <td width="10%"></td>
        <td width="10%"></td>
        <td width="20%"></td>
        <td width="10%"></td>
        <td width="20%"></td>
        <td width="10%"></td>
        <td width="15%"></td>
        <td width="5%"></td>
    </tr>
</table>

</asp:Content>

