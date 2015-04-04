<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmSpecimen_Nature.aspx.cs" Inherits="spec_nature" Title="Specimen Nature" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Specimen Nature</td>
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
                Name:</td>
            <td colspan="3">
                <asp:TextBox ID="txtName" runat="server" CssClass="mandatoryField" Width="98%" MaxLength="30"></asp:TextBox></td>
            <td>
                &nbsp;Type:</td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" CssClass="dropdown" Width="70%">
                    <asp:ListItem Value="G">General</asp:ListItem>
                    <asp:ListItem Value="H">Histopathology</asp:ListItem>
                    <asp:ListItem Value="M">Microbiology</asp:ListItem>
                </asp:DropDownList></td>
            <td></td>        
        </tr>
      <tr>
          <td>
          </td>
          <td>
              Description:</td>
          <td colspan="3" rowspan="2">
              <asp:TextBox ID="txtDescription" runat="server" CssClass="field" TextMode="MultiLine"
                  Width="99%"></asp:TextBox></td>
          <td>
                <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" /></td>
          <td>
                <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label><asp:Label ID="lblID" runat="server" Visible="False"></asp:Label></td>
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
            <td colspan="5">
                <asp:GridView ID="gvNature" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="specimennatureid,description,type" OnRowCommand="gvNature_RowCommand">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="Name">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="35%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="typename" HeaderText="Type">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Active">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString() =="Y" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle HorizontalAlign="Center" />
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

