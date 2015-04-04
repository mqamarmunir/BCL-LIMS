<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmbranchAlertsConfiguration.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Parameter_wfrmbranchAlertsConfiguration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>

<asp:HiddenField ID="hdAlertTypeID" runat="server" /> 

            <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr style="font-size: 12pt">
                    <td align="center" colspan="7">
                        <font size="4"><strong>Branch Alerts Configuration</strong></font></td>
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
                    Branch:
                </td>
                <td>
                   <asp:DropDownList ID="ddlBranch" runat="server" CssClass="mandatorySelect" Width="99%" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedindexChanged"></asp:DropDownList>
                    </td>
                <td align="right">
                    Alerts:
                </td>
                <td>
                    <asp:DropDownList ID="ddlAlerts"  Width="99%" CssClass="mandatorySelect" runat="server">
                        
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
                    Rate:
                </td>
                <td>
                    <asp:TextBox ID="txtRate" CssClass="mandatoryField" Width="20%" TextMode="SingleLine" runat="server"></asp:TextBox>
                    <%--<cc1:MaskedEditExtender ID="mskrate" runat="server" Mask="99.99" ClearMaskOnLostFocus="false" TargetControlID="txtRate"></cc1:MaskedEditExtender>--%>
                    in Rupees(pk)</td>
                    <td align="right">
                        Expiry Date:
                        </td>
                <td>
                    <asp:TextBox ID="txtExpiry" CssClass="mandatoryField" Width="50%" 
                        TextMode="SingleLine" runat="server"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="txtRate0_MaskedEditExtender" runat="server" 
                        Mask="99/99/9999" ClearMaskOnLostFocus="false" TargetControlID="txtExpiry"></cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="excale" runat="server" Format="dd/MM/yyyy" TargetControlID="txtExpiry"></cc1:CalendarExtender>
                    </td>
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
                            AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="BranchAlertID"
                            ToolTip="View Alerts Information" Width="80%" OnRowEditing="gvAlerts_RowEditing"
                              OnSorting="gvAlerts_Sorting" OnRowCommand="gvAlerts_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="Name" HeaderText="Branch" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Alert_Name" HeaderText="Alert">
                                    <ControlStyle Width="45%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="45%" HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="TypeDetail" HeaderText="Type" />
                                <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                
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