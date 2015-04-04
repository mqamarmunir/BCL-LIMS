<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmPanelClass.aspx.cs" Inherits="panelclass" Title="Panel Class Reg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table id="Main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Panel Class Registration</td>
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
                Organization:</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged"
                    Width="50%">
                </asp:DropDownList></td>
            <td align="right">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
          <tr>
            <td></td>
            <td>
                Panel:</td>
            <td class="mandatoryField" colspan="3">
                <asp:DropDownList ID="ddlPanel" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlPanel_SelectedIndexChanged">
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
                Name:</td>
            <td colspan="3">
                <asp:TextBox ID="txtname" runat="server" CssClass="mandatoryField" MaxLength="50"
                    Width="99%"></asp:TextBox></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
          <tr>
            <td></td>
            <td>
                Description:</td>
              <td colspan="3" rowspan="3">
                  <asp:TextBox ID="txtDescription" runat="server" CssClass="field" Height="41px" MaxLength="255"
                      TextMode="MultiLine" Width="99%"></asp:TextBox></td>
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
        </tr>
          <tr>
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
            <td>
            </td>
            <td>
            </td>
            <td colspan="3">
                <asp:GridView ID="gvClass" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                    DataKeyNames="classid,panelid,description" OnRowCommand="gvClass_RowCommand">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="Class">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="80%" />
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

