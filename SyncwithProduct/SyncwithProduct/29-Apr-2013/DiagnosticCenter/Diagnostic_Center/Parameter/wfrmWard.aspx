<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmWard.aspx.cs" Inherits="ward" Title="Ward Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table id="tb_main" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">
    <tr>
        <td align="center" class="tdheading" colspan="8">
            Ward Registration</td>
    </tr>
    <tr>
        <td></td>
        <td colspan="3">
            <asp:Label ID="lblError" runat="server"></asp:Label></td>
        <td>
            <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label></td>
        <td></td>
        <td align="right">
            <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
        <td></td>
    </tr>
    <tr>
    <td></td>
    <td>Branch</td>
    <td>
    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="mandatorySelect" 
            Width="95%" onselectedindexchanged="ddlBranch_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    <tr>
        <td></td>
        <td>
            Name:</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" CssClass="mandatoryField" MaxLength="45"
                Width="99%"></asp:TextBox></td>
        <td align="right">
            Acronym:</td>
        <td>
            <asp:TextBox ID="txtAcronym" runat="server" CssClass="field" MaxLength="10" Width="59%"></asp:TextBox></td>
        <td>
            <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" /></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td>
            Description:</td>
        <td colspan="3">
            <asp:TextBox ID="txtDescription" runat="server" MaxLength="100" TextMode="MultiLine"
                Width="99%" CssClass="field"></asp:TextBox></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td class="screenid" colspan="8">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td colspan="3">
            <asp:GridView ID="gvWard" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                DataKeyNames="wardid,description" OnRowCommand="gvWard_RowCommand">
                <RowStyle CssClass="gridItem" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>:
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="Ward">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="acronym" HeaderText="Acronym">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Active">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkGvActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle CssClass="gridheader" />
                <AlternatingRowStyle CssClass="gridAlternate" />
            </asp:GridView>
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
        <td style="width:5%"></td>
        <td style="width:10%"></td>
        <td style="width:30%"></td>
        <td style="width:10%"></td>
        <td style="width:20%"></td>
        <td style="width:10%"></td>
        <td style="width:10%"></td>
        <td style="width:5%"></td>
    </tr>
</table>

</asp:Content>

