<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/StudyM.aspx.cs" Inherits="StudyM" Title="Study Master Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
  <!--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate> -->
            <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr style="font-size: 12pt">
                    <td align="center" colspan="7">
                        <font size="4"><strong>Study Information</strong></font></td>
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
                    <td>
                    </td>
                    <td align="right">
                        Study Name:</td>
                    <td>
                        <asp:TextBox ID="txtStudy_Name" runat="server" MaxLength="100"
                            TabIndex="1" ToolTip="Enter Study Name" Width="97%" CssClass="mandatoryField"></asp:TextBox></td>
                    <td align="right">
                        Acronym:</td>
                    <td>
                        <asp:TextBox ID="txtAcronym" runat="server" MaxLength="10" TabIndex="2" ToolTip="Please Enter Acronym"
                            Width="96%" CssClass="mandatoryField"></asp:TextBox></td>
                    <td align="center">
                        <asp:CheckBox ID="chkActive" runat="server" Checked="True" ToolTip="Check for remain Activethroughout the application" Text="Active" TextAlign="Left" TabIndex="3" /></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        Total Charges:</td>
                    <td>
                        <asp:TextBox ID="txtTotal_Charges" runat="server" CssClass="field" MaxLength="15" TabIndex="4"
                            Width="40%" ToolTip="Enter Total Charges"></asp:TextBox></td>
                    <td align="right">
                    </td>
                    <td colspan="2">                                                 
                        </td>
                    <td>
                    </td>
                </tr>                    
                   <tr>
                    <td>
                    </td>
                    <td align="right" style="height: 26px">
                        Description:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="field" MaxLength="255" TabIndex="5"
                            Width="99.3%" ToolTip="Enter Description"></asp:TextBox></td>                                     
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
                        <asp:GridView ID="gvStudy" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="StudyId" TabIndex="50"
                            ToolTip="View Study Information" Width="80%" 
                            OnPageIndexChanging="gvStudy_PageIndexChanging" 
                            OnRowEditing="gvStudy_RowEditing" OnSorting="gvStudy_Sorting" OnRowCommand="gvStudy_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="Study_Name" HeaderText="Study" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="55%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Acronym" HeaderText="Acronym">
                                    <ControlStyle Width="30%" />
                                    <ItemStyle Width="20%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Active">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                    <ControlStyle Width="10%" />
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
                </tr>
                <tr>
                    <td align="left" colspan="7">
                        <asp:Label ID="lblstatus" runat="server" Visible="False" TabIndex="30"></asp:Label>&nbsp;
                        <asp:Label ID="lblStudyId" runat="server" TabIndex="31" Visible="False"></asp:Label></td>
                </tr>               
            </table>
     <!--       </ContentTemplate>
                        </asp:UpdatePanel>   -->     
</asp:Content>




