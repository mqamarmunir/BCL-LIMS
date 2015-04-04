<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/GroupD.aspx.cs" Inherits="GroupD" Title="Groups Detail Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
  <!--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate> -->
           
            
            <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                <tr>
                    <td align="center" colspan="8">
                        <strong><span style="font-size: 13pt">Groups Detail Information</span></strong></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="100%" TabIndex="32"></asp:Label></td>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="lbtnSaveNext" runat="server" BackColor="SkyBlue" Font-Bold="True"
                            ForeColor="Navy" OnClick="lbtnSaveNext_Click" Text="Save & Next" Height="28px" Width="30%" Visible="False" />
                                    <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="6" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="7" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" TabIndex="8" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <strong><span style="font-size: 13pt"></span></strong></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        Department:</td>
                    <td>
                        <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                            Width="100%" TabIndex="1" ToolTip="Select Department">
                        </asp:DropDownList></td>
                    <td align="right">
                        Group:</td>
                    <td>
                        <asp:DropDownList ID="ddlGroup" runat="server" Width="100%" TabIndex="2" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" ToolTip="Select Group">
                        </asp:DropDownList></td>
                    <td>
                        D-order:</td>
                    <td>
                        <asp:TextBox ID="txtDOrder" runat="server" MaxLength="15" TabIndex="5" ToolTip="Please Enter Display Order"
                            Width="40%" CssClass="field"></asp:TextBox>
                        <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        Test:</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTest" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged"
                            Width="99%" TabIndex="3" ToolTip="Select Test">
                        </asp:DropDownList></td>
                    <td>
                        Charges:<asp:TextBox ID="txtCharges" runat="server" CssClass="field" ReadOnly="True"
                            Width="30%"></asp:TextBox></td>
                    <td>
                        Rate:</td>
                    <td>
                        <asp:TextBox ID="txtRate" runat="server" CssClass="mandatoryField" MaxLength="5"
                            Width="30%"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="flt_rate" runat="server" TargetControlID="txtRate" FilterType="numbers"></cc1:FilteredTextBoxExtender>
                            </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblGroupTotal" runat="server" Font-Bold="True" ForeColor="Navy"></asp:Label></td>
                    <td><asp:Label ID="lblDepartmentId" runat="server" TabIndex="32" Visible="False"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblstatus" runat="server" Visible="False" TabIndex="30"></asp:Label><asp:Label ID="lblGroupDetailId" runat="server" Visible="False" TabIndex="31"></asp:Label></td>
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
                    <td></td>
                    <td colspan="6">
                        <asp:GridView ID="gvGroupDetail" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="GroupDetailId" TabIndex="50"
                            ToolTip="View Groups Detail Info" Width="80%" OnPageIndexChanging="gvGroupDetail_PageIndexChanging" 
                            OnRowEditing="gvGroupDetail_RowEditing" OnSorting="gvGroupDetail_Sorting" OnRowCommand="gvGroupDetail_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="Test_Name" HeaderText="Test Name" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>                               
                                <asp:BoundField DataField="charges" HeaderText="Charges">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeptName" HeaderText="Department">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="GroupName" HeaderText="Group Name">
                                    <ControlStyle Width="30%" />
                                    <ItemStyle Width="15%" />
                                </asp:BoundField>                           
                                <asp:TemplateField HeaderText="Active">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
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
                    <td style="width:5%"></td>
                    <td style="width:10%"></td>
                    <td style="width:20%"></td>
                    <td style="width:10%"></td>
                    <td style="width:20%"></td>
                    <td style="width:10%"></td>
                    <td style="width:20%"></td>
                    <td style="width:5%"></td>                    
                </tr>
            </table>
            
     <!--       </ContentTemplate>
                        </asp:UpdatePanel>   -->     
</asp:Content>




