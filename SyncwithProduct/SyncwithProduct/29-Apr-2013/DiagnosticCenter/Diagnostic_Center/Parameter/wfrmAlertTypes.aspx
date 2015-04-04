<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="wfrmAlertTypes.aspx.cs" Inherits="Parameter_wfrmAlertTypes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>

<asp:HiddenField ID="hdAlertTypeID" runat="server" /> 

            <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr style="font-size: 12pt">
                    <td align="center" colspan="7">
                        <font size="4"><strong>Alerts Information</strong></font></td>
                </tr>
                <tr>
                    <td align="right" colspan="7" style="height: 3px">
                        <table id="Table2" align="right" border="0" cellpadding="1" cellspacing="1" width="24%" class="label">
                            <tr>
                                <td align="right" style="width: 62.28%">
                                    <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                    ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                   ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" TabIndex="14" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" /></td>
                                <td align="center" style="width: 8%">
                                </td>
                            </tr>
                        </table>
             
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="100%" TabIndex="32"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        Process:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProcess" runat="server" CssClass="mandatorySelect" Width="99%"></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                <td align="right">
                    Name:
                </td>
                <td>
                    <asp:TextBox ID="txtName" CssClass="mandatoryField" Width="99%" runat="server"></asp:TextBox>
                    </td>
                <td align="right">
                    Type:
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" Width="99%" CssClass="dropdown" runat="server">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                        <asp:ListItem Value="E">Email</asp:ListItem>
                        <asp:ListItem Value="S">SMS</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td>
                    <asp:CheckBox ID="chkActive" runat="server" TextAlign="Left" Checked="true" Text="Active" />
                </td>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td align="right">
                    Description:
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDescription" CssClass="field" Width="99%" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>

                <tr>
                <td colspan="7"></td>
                </tr>
                <tr>
                <td colspan="7" align="center">
                
                        <asp:GridView ID="gvAlerts" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="AlertTypeId"
                            ToolTip="View Alerts Information" Width="80%" OnRowEditing="gvAlerts_RowEditing"
                              OnSorting="gvAlerts_Sorting" OnRowCommand="gvAlerts_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="Name" HeaderText="Alert" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TypeDetail" HeaderText="Type">
                                    <ControlStyle Width="40%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="40%" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Process" HeaderText="Process" />
                                
                                <asp:TemplateField HeaderText="Active">
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                    <ControlStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <ControlStyle Width="10%" />
                                </asp:CommandField>
                                <asp:CommandField ShowSelectButton="true" SelectText="Edit" >
                                <HeaderStyle Width="5%" />
                                <ItemStyle Width="5%" />
                                </asp:CommandField>
                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <SelectedRowStyle CssClass="gridSelectedItem" />
                            <PagerStyle HorizontalAlign="Left" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                        </asp:GridView>
                
                </td>
                </tr>

                <tr>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                </tr>


        </table>
</asp:Content>

