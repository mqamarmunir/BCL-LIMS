<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/MainPage.aspx.cs" Inherits="MainPage" Title="BCL: Main Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="90%" height="380">                              
                <tr>
                    <td></td>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td align="center" colspan="4">
                        <asp:UpdatePanel ID="up" runat="Server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlPassword" runat="server" BackColor="Linen" BorderColor="Tan" BorderStyle="Groove"
                                    Height="150px" Width="325px">
                                    <table id="pass" border="0" cellpadding="1" cellspacing="1" width="100%">
                                        <tr>
                                            <td align="center" colspan="4">
                                                <strong>Change Password</strong></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="4">
                                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="98%"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Old Password:</td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtOldPass" runat="server" CssClass="field" MaxLength="15" TextMode="Password"
                                                    Width="98%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                New Password:</td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtNewPass" runat="server" CssClass="field" MaxLength="15" TextMode="Password"
                                                    Width="98%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Confirm Password:</td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtCnFrmPas" runat="server" CssClass="field" MaxLength="15" TextMode="Password"
                                                    Width="98%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                            </td>
                                            <td width="35%">
                                            </td>
                                            <td colspan="2">
                                                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                                                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:Label ID="lblPassword" runat="server" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                            </td>
                                            <td width="35%">
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="imgSave" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="imgClose" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                 <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td style="width:25%"></td>
                    <td style="width:25%"></td>
                    <td style="width:25%"></td>
                    <td style="width:25%"></td>
                </tr>
  </table>
</asp:Content>

