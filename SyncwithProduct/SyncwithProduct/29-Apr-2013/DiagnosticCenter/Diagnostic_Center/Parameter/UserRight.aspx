<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/UserRight.aspx.cs" Inherits="userright" Title="User Right" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <asp:updatePanel id="up_grd" runat="server" UpdateMode="Conditional"><ContentTemplate>
        <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                User Right</td>
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
            <td></td>
            <td>
                Group Matrix:</td>
              <td colspan="3">
                  <asp:DropDownList ID="ddlGroup" runat="server" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                  </asp:DropDownList></td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" /></td>
            <td></td>
            <td></td>
        </tr>
            <tr>
                <td>
                </td>
                <td>
                    Default Page:</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlPage" runat="server" Width="80%">
                    </asp:DropDownList></td>
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
                User:</td>
              <td colspan="3">
                  <asp:DropDownList ID="ddlUser" runat="server" Width="80%">
                  </asp:DropDownList></td>
            <td>
                </td>
            <td>
                </td>
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
              
<asp:GridView id="gvuser" runat="server" OnRowCommand="gvuser_RowCommand" DataKeyNames="rightid,groupid,personid,defaultpage" CssClass="datagrid" AutoGenerateColumns="False">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="personname" HeaderText="User" SortExpression="personname">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="50%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pagename" HeaderText="Default Page">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
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
                <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label></td>
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
    </ContentTemplate>
                     
               </asp:updatePanel> 
</asp:Content>

