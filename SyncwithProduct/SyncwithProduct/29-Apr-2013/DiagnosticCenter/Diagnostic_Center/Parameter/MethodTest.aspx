<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/MethodTest.aspx.cs" Inherits="MethodTest" Title="Method & Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Method Configuration</td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
          <tr>
            <td colspan="4">
                <asp:Label ID="lblError" runat="server"></asp:Label></td>
            <td></td>
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
                Client:</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"
                    Width="99%">
                </asp:DropDownList></td>
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
                Sub-Department:</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlSubDept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubDept_SelectedIndexChanged"
                    Width="99%">
                </asp:DropDownList></td>
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
            <td>
                Method:</td>
              <td colspan="3">
                  <asp:DropDownList ID="ddlMethod" runat="server" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="ddlMethod_SelectedIndexChanged">
                  </asp:DropDownList></td>
            <td>
                <asp:CheckBox ID="chkDefault" runat="server" Text="Default" /></td>
            <td></td>
            <td></td>
        </tr>
          <tr>
            <td></td>
            <td>
                Test:</td>
              <td colspan="3">
                  <asp:DropDownList ID="ddlTest" runat="server" Width="80%">
                  </asp:DropDownList></td>
            <td>
                Dorder:</td>
            <td>
                <asp:TextBox ID="txtDorder" runat="server" CssClass="field" Width="50%"></asp:TextBox></td>
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
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:GridView ID="gvMethodTest" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                    DataKeyNames="methodid,testid" OnRowCommand="gvMethodTest_RowCommand">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="test_name" HeaderText="Test" SortExpression="name">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="80%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dorder" HeaderText="Dorder">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Default">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGvDefault" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"m_Default").ToString()=="Y" %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;<asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblOldMethodID" runat="server" Visible="False"></asp:Label></td>
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

