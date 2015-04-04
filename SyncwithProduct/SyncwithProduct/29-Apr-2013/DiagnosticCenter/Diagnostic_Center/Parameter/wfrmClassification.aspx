<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmClassification.aspx.cs" Inherits="classification" Title="Classification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Test Classification</td>
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
                Test:</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlTest" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td>
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
            <td colspan="2">
                <asp:TextBox ID="txtName" runat="server" CssClass="mandatoryField" Width="98%" MaxLength="50"></asp:TextBox></td>
            <td align="left">
                &nbsp;&nbsp;
                Dorder:<asp:TextBox ID="txtDorder" runat="server" Width="30%" CssClass="field" MaxLength="3"></asp:TextBox></td>
            <td>
                </td>
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
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>        
        </tr>
        <tr>
            <td></td>
            <td colspan="5">
                <asp:GridView ID="gvTestClass" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="classificationid,testid" OnRowCommand="gvTestClass_RowCommand">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="testname" HeaderText="Test">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="35%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="classname" HeaderText="Classification Name">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="35%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dorder" HeaderText="Dorder">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="15%" />
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

