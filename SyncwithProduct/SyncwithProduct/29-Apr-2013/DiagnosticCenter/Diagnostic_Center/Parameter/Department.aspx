<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/Department.aspx.cs" Inherits="Department" Title="Departments Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
  <!--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate> -->
            <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr style="font-size: 12pt">
                    <td align="center" colspan="7">
                        <font size="4"><strong>Departments Information</strong></font></td>
                </tr>
                <tr>
                    <td align="right" colspan="7" style="height: 3px">
                        <table id="Table2" align="right" border="0" cellpadding="1" cellspacing="1" width="24%" class="label">
                            <tr>
                                <td align="right" style="width: 62.28%">
                                    <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="12" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="13" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" TabIndex="14" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" /></td>
                                <td align="center" style="width: 8%">
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="lbtnSaveNext" runat="server" BackColor="SkyBlue" Font-Bold="True"
                            ForeColor="Navy" OnClick="lbtnSaveNext_Click" Text="Save & Next" Height="28px" Width="10%" />&nbsp;
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
                    <td width="10%">
                    </td>
                    <td width="15%" align="right">
                        Organization:</td>
                    <td width="249" class="mandatoryField">
                        <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged"
                            Width="100%" TabIndex="1" ToolTip="Select Organization">
                        </asp:DropDownList></td>
                    <td width="144" align="right">
                        HOD:</td>
                    <td align="left" width="27%" colspan="2"><asp:DropDownList ID="ddlPerson" runat="server"
                            Width="100%" TabIndex="2" ToolTip="Select Head of Department">
                    </asp:DropDownList></td>                    
                    <td width="10%">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        Department Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"
                            TabIndex="3" ToolTip="Enter Department Name" Width="97%" CssClass="mandatoryField"></asp:TextBox></td>
                    <td align="right">
                        Acronym:</td>
                    <td>
                        <asp:TextBox ID="txtAcronym" runat="server" MaxLength="10" TabIndex="4" ToolTip="Please Enter Acronym"
                            Width="96%" CssClass="mandatoryField"></asp:TextBox></td>
                    <td align="center">
                        <asp:CheckBox ID="chkActive" runat="server" Checked="True" ToolTip="Check for remain Activethroughout the application" Text="Active" TextAlign="Left" TabIndex="5" /></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        Phone No.:</td>
                    <td>
                        <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="field" MaxLength="15" TabIndex="6"
                            Width="99%" ToolTip="Enter Phone No."></asp:TextBox></td>
                    <td align="right">
                        Fax No.:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFaxNo" runat="server" CssClass="field" MaxLength="15" TabIndex="7"
                            Width="99%" ToolTip="Enter Fax No."></asp:TextBox>                            
                        </td>
                    <td>
                    </td>
                </tr>     
                   <tr>
                    <td>
                    </td>
                    <td align="right">
                        Email.:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="field" MaxLength="50" TabIndex="8"
                            Width="99%" ToolTip="Enter Email"></asp:TextBox></td>
                    <td align="right">
                        </td>
                    <td colspan="2">
                    <asp:RadioButton ID="rbtnAdmin" runat="server" Text="Administrative" Checked="True" GroupName="rdType" TabIndex="9" />
                        &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rbtnService" runat="server" Text="Service" GroupName="rdType" TabIndex="10" /></td>
                    <td>
                    </td>
                </tr>           
                   <tr>
                    <td>
                    </td>
                    <td align="right" style="height: 26px">
                        Address:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="field" MaxLength="250" TabIndex="11"
                            Width="99.3%" ToolTip="Enter Address"></asp:TextBox></td>                                     
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
                        <asp:GridView ID="gvDepartment" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="DepartmentId,OrgId" TabIndex="50"
                            ToolTip="View Departments Information" Width="80%"
                             OnPageIndexChanging="gvDepartment_PageIndexChanging" OnRowEditing="gvDepartment_RowEditing"
                              OnSorting="gvDepartment_Sorting" OnRowCommand="gvDepartment_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="Name" HeaderText="Department" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Acronym" HeaderText="Acronym">
                                    <ControlStyle Width="30%" />
                                    <ItemStyle Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrgName" HeaderText="Organization">
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
                        <asp:Label ID="lblOrgId" runat="server" Visible="False" TabIndex="31"></asp:Label>
                        <asp:Label ID="lblDepartmentId" runat="server" TabIndex="32" Visible="False"></asp:Label></td>
                </tr>               
            </table>
     <!--       </ContentTemplate>
                        </asp:UpdatePanel>   -->     
</asp:Content>


