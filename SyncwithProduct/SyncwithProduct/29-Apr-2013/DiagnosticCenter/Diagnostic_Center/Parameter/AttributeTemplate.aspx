<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/AttributeTemplate.aspx.cs" Inherits="AttributeTemplate" Title="Attribute Templates Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
  <!--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate> -->
            <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr style="font-size: 12pt">
                    <td align="center" colspan="7">
                        <font size="4"><strong>Attribute Templates Information</strong></font></td>
                </tr>
                <tr>
                    <td align="right" colspan="7" style="height: 3px">
                        <table id="Table2" align="right" border="0" cellpadding="1" cellspacing="1" width="24%" class="label">
                            <tr>
                                <td align="left" style="width: 62.28%">
                                    <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="6" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="7" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" TabIndex="8" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" />
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
                    </td>                  
                    <td width="10%">
                    </td>
                </tr>
                   <tr>
                    <td>
                    </td>
                    <td align="right">
                        </td>
                    <td>
                        </td>
                    <td align="right">
                        </td>
                    <td align="right"><asp:CheckBox ID="chkDefault" runat="server" ToolTip="Check for remain Activethroughout the application" Text="Default" TextAlign="Left" TabIndex="4" /></td>
                    <td align="right">
                        <asp:CheckBox ID="chkActive" runat="server" Checked="True" ToolTip="Check for remain Activethroughout the application" Text="Active" TextAlign="Left" TabIndex="5" /></td>
                    <td>
                    </td>
                </tr>    
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        Sub-Department:</td>
                    <td>
                        <asp:DropDownList ID="ddlSubDept" runat="server" AutoPostBack="True" CssClass="dropdown"
                            OnSelectedIndexChanged="ddlSubDept_SelectedIndexChanged" Width="99%">
                        </asp:DropDownList></td>
                    <td align="right">
                        Test:</td>
                    <td align="left" colspan="2">
                        <asp:DropDownList ID="ddlTest" runat="server" AutoPostBack="True" CssClass="dropdown"
                            OnSelectedIndexChanged="ddlTest_SelectedIndexChanged" Width="99%">
                        </asp:DropDownList></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="10%">
                    </td>
                    <td width="15%" align="left">
                        Attribute:</td>
                    <td width="249" class="mandatoryField">
                        <asp:DropDownList ID="ddlAttribute" runat="server"
                            Width="100%" TabIndex="1" ToolTip="Select Attribute" AutoPostBack="True" CssClass="dropdown" OnSelectedIndexChanged="ddlAttribute_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td width="144" align="right">
                        Person:</td>
                    <td align="left" width="27%" colspan="2"><asp:DropDownList ID="ddlPerson" runat="server"
                            Width="100%" TabIndex="2" ToolTip="Select Person" CssClass="dropdown">
                    </asp:DropDownList></td>                    
                    <td width="10%">
                    </td>
                </tr>                              
                   <tr>
                    <td>
                    </td>
                    <td align="left" style="height: 26px">
                        Description:</td>
                       <td colspan="4" rowspan="2" valign="top">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="field" MaxLength="250" TabIndex="3"
                            Width="99.3%" ToolTip="Select Description" TextMode="MultiLine"></asp:TextBox></td>
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
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td colspan="3">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" align="center" valign="top">
                        <asp:GridView ID="gvATemplate" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="TemplateId" TabIndex="50"
                            ToolTip="View Attribute Templates Information" Width="80%" OnPageIndexChanging="gvATemplate_PageIndexChanging"
                             OnRowEditing="gvATemplate_RowEditing" OnSorting="gvATemplate_Sorting" OnRowCommand="gvATemplate_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="Attribute_Name" HeaderText="Attribute" ReadOnly="True" SortExpression="Attribute">
                                    <ControlStyle Width="30%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    <HeaderStyle ForeColor="Blue" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PersonName" HeaderText="Person">
                                    <ItemStyle HorizontalAlign="Left" Width="22%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Description">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
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
                                <asp:TemplateField HeaderText="Default">
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkgvDefault" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Defaultt").ToString() == "Y") %>'
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
                        <asp:Label ID="lblTemplateId" runat="server" Visible="False" TabIndex="31"></asp:Label>
                        <asp:Label ID="lblPersonId" runat="server" TabIndex="32" Visible="False"></asp:Label></td>
                </tr>               
            </table>
     <!--       </ContentTemplate>
                        </asp:UpdatePanel>   -->     
</asp:Content>



