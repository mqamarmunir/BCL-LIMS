<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/SContainer.aspx.cs" Inherits="SContainer" Title="Specimen Container Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
  <!--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate> -->
            <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr style="font-size: 12pt">
                    <td align="center" colspan="7">
                        <font size="4"><strong>Specimen Container / Type</strong></font></td>
                </tr>
                <tr>
                    <td align="right" colspan="7" style="height: 3px">
                        <table id="Table2" align="right" border="0" cellpadding="1" cellspacing="1" width="24%" class="label">
                            <tr>
                                <td align="left" style="width: 62.28%">
                                    <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="7" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="8" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" TabIndex="9" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" />
                                </td>
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
                    <td width="10%">
                    </td>
                    <td width="15%" align="right">
                    </td>
                    <td width="249">
                    </td>
                    <td width="144" align="right">
                    </td>
                    <td align="left" width="13%">
                    </td> 
                     <td width="14%">
                        <asp:CheckBox ID="chkActive" runat="server" Checked="True" ToolTip="Check for remain Activethroughout the application" Text="Active" TextAlign="Left" TabIndex="4" /></td>                  
                    <td width="10%">
                    </td>
                </tr>
                <tr>
                    <td width="10%">
                    </td>
                    <td width="15%" align="right">
                        Specimen Type:</td>
                    <td width="249" class="mandatoryField">
                        <asp:DropDownList ID="ddlSpecimen" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecimen_SelectedIndexChanged"
                            Width="100%" TabIndex="1">
                        </asp:DropDownList></td>
                    <td width="144" align="right">
                        Container Name:</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtContainer_Name" runat="server" MaxLength="100"
                            TabIndex="2" ToolTip="Enter Specimen Container Name" Width="96%" CssClass="mandatoryField"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        Description:</td>
                    <td rowspan="2">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="field" MaxLength="250" TabIndex="5"
                            Width="98%" ToolTip="Enter Description for Specimen Container" TextMode="MultiLine"></asp:TextBox></td>
                    <td align="right">
                        Acronym:</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtAcronym" runat="server" MaxLength="10" TabIndex="3" ToolTip="Please Enter Acronym"
                            Width="40%" CssClass="mandatoryField"></asp:TextBox>&nbsp;
                        Quantity:<asp:TextBox ID="txtQty" runat="server" MaxLength="10" TabIndex="6" ToolTip="Please Enter Quantity"
                            Width="36%" CssClass="field"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        </td>
                    <td align="right">
                        </td>
                    <td>
                        </td>
                    <td align="center">
                        </td>
                    <td>
                    </td>
                </tr>                                                                         
                <tr>
                    <td class="screenid" colspan="7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="screenid" colspan="7">
                    </td>
                </tr>
                <tr>
                    <td colspan="7" align="center" valign="top">
                        <asp:GridView ID="gvSContainer" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="SContainerId,SpecimenId" TabIndex="50"
                            ToolTip="View Specimen Container" Width="80%" 
                            OnPageIndexChanging="gvSContainer_PageIndexChanging"
                             OnRowEditing="gvSContainer_RowEditing" OnSorting="gvSContainer_Sorting" OnRowCommand="gvSContainer_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="Container_Name" HeaderText="Specimen Container" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Acronym" HeaderText="Acronym">
                                    <ControlStyle Width="30%" />
                                    <ItemStyle Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Specimen_Name" HeaderText="Specimen Type">
                                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
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
                                <asp:CommandField ShowSelectButton="true" SelectText="Edit" />
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
                    <td align="left" colspan="7">
                        <asp:Label ID="lblstatus" runat="server" Visible="False" TabIndex="30"></asp:Label>
                        <asp:Label ID="lblSpecimenId" runat="server" Visible="False" TabIndex="31"></asp:Label>
                        <asp:Label ID="lblSContainerId" runat="server" TabIndex="31" Visible="False"></asp:Label></td>
                </tr>               
            </table>
     <!--       </ContentTemplate>
                        </asp:UpdatePanel>   -->     
</asp:Content>



