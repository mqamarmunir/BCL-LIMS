<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/Organization.aspx.cs" Inherits="Organization" Title="Organization Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%> 
            <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr style="font-size: 12pt">
                    <td align="center" colspan="7">
                        <font size="4"><strong>Organization</strong></font></td>
                </tr>
                <tr>
                    <td align="right" colspan="7" style="height: 3px">
                        <table id="Table2" align="right" border="0" cellpadding="1" cellspacing="1" width="24%" class="label">
                            <tr>
                                <td align="left" style="width: 62.28%">
                                    <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="11" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="12" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" TabIndex="13" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" />
                                </td>
                                <td align="center" style="width: 8%">
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="lbtnSaveNext" runat="server" BackColor="SkyBlue" Font-Bold="True"
                            ForeColor="Navy" OnClick="lbtnSaveNext_Click" Text="Save & Next" Height="28px" Width="10%" />&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="100%" TabIndex="32"></asp:Label></td>
                </tr>
                <tr>
                    <td width="10%">
                    </td>
                    <td width="15%" align="center">
                        </td>
                    <td width="249">
                        </td>
                    <td width="144" align="right">
                        </td>
                    <td align="right" width="13%">
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
                        Organization
                        Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="100"
                            TabIndex="1" ToolTip="Enter Organization Name" Width="97%" CssClass="mandatoryField"></asp:TextBox></td>
                    <td align="right">
                        Acronym:</td>
                    <td>
                        <asp:TextBox ID="txtAcronym" runat="server" MaxLength="10" TabIndex="2" ToolTip="Please Enter Acronym"
                            Width="96%" CssClass="mandatoryField"></asp:TextBox></td>
                    <td align="left" colspan="2">
                        <asp:CheckBox ID="chkActive" runat="server" Checked="True" ToolTip="Check for remain Activethroughout the application" Text="Active" TabIndex="3" />
                        <asp:CheckBox ID="chkMain" runat="server" ToolTip="Check for remain Activethroughout the application" Text="Main" TabIndex="4" />&nbsp;<asp:CheckBox
                            ID="chkExterna" runat="server" TabIndex="5" Text="External" AutoPostBack="True" OnCheckedChanged="chkExterna_CheckedChanged" />&nbsp;<asp:CheckBox
                                ID="chkIndoor" runat="server" Text="Indoor Services" />&nbsp;<asp:CheckBox ID="chkCollection"
                                    runat="server" Text="Collection Center" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        Phone #:</td>
                    <td>
                        <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="field" MaxLength="15" TabIndex="5"
                            Width="99%" ToolTip="Enter Phone of Organization"></asp:TextBox></td>
                    <td align="right">
                        Fax #:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFaxNo" runat="server" CssClass="field" MaxLength="15" TabIndex="6"
                            Width="99%" ToolTip="Enter Fax No."></asp:TextBox>                            
                        </td>
                    <td>
                    </td>
                </tr>     
                   <tr>
                    <td>
                    </td>
                    <td align="right">
                        Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="field" MaxLength="50" TabIndex="7"
                            Width="99%" ToolTip="Enter Email for Organization"></asp:TextBox></td>
                    <td align="right">
                        Web Address:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtWebAddress" runat="server" CssClass="field" MaxLength="50" TabIndex="8"
                            Width="99%" ToolTip="Enter Web Address of Organization"></asp:TextBox>                            
                        </td>
                    <td>
                    </td>
                </tr>           
                   <tr>
                    <td>
                    </td>
                    <td align="right" style="height: 26px">
                        Address:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="field" MaxLength="250" TabIndex="9"
                            Width="99.3%" ToolTip="Enter Address of Organization"></asp:TextBox></td>                                     
                    <td>
                    </td>
                </tr>    
                  <tr>
                    <td>
                    </td>
                    <td align="right">
                        Main of:</td>
                    <td>
                        <asp:DropDownList ID="ddlMainof" runat="server" Width="100%" TabIndex="10" ToolTip="Select Main Organization of this Organization">
                        </asp:DropDownList></td>
                    <td align="right">
                        Processing Fee:</td>
                    <td colspan="2">
                        &nbsp;<asp:TextBox ID="txtFee" runat="server" CssClass="mandatoryField"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="flt_fee" runat="server" TargetControlID="txtFee"
                         FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                        </td>
                    <td>
                    </td>
                </tr>                                                        
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        Default Routing Location:</td>
                    <td>
                        <asp:DropDownList ID="ddlDefaultRouting" runat="server" Width="100%" TabIndex="10" ToolTip="Select Default Routing Location">
                        </asp:DropDownList></td>
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
                    <td align="right">
                        <span style="text-decoration: underline">Lab Timing</span></td>
                    <td>
                    </td>
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
                    <td align="right">
                    </td>
                    <td colspan="4">
                        <table id="tb_tim" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">
                            <tr>
                                <td>
                                    Start Time:</td>
                                <td>
                        <asp:TextBox ID="txtStartTime" runat="server" CssClass="field" Width="45%"></asp:TextBox>
                                    (24 hr)</td>
                                <td align="center">
                                    Close TIme:</td>
                                <td><asp:TextBox
                            ID="txtCloseTime" runat="server" CssClass="field" Width="45%"></asp:TextBox>
                                    (24 hr)</td>
                                <td align="center">
                                    Day:</td>
                                <td>
                                    <asp:DropDownList ID="ddlDay" runat="server" Width="25%">
                                        <asp:ListItem Value="All Days">All Days</asp:ListItem>
                                        <asp:ListItem>Sunday</asp:ListItem>
                                        <asp:ListItem>Monday</asp:ListItem>
                                        <asp:ListItem>Tuesday</asp:ListItem>
                                        <asp:ListItem>Wednesday</asp:ListItem>
                                        <asp:ListItem>Thursday</asp:ListItem>
                                        <asp:ListItem>Friday</asp:ListItem>
                                        <asp:ListItem>Saturday</asp:ListItem>
                                    </asp:DropDownList>&nbsp;
                                    <asp:ImageButton ID="imgAdd" runat="server" ImageUrl="~/images/AddPack.gif" OnClick="imgAdd_Click" /></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5">
                                    <asp:GridView ID="gvTiming" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                        OnRowDeleting="gvTiming_RowDeleting">
                                        <RowStyle CssClass="gridItem" />
                                        <Columns>
                                            <asp:BoundField DataField="start_time" HeaderText="Start Time">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="close_time" HeaderText="Close Time">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="day" HeaderText="Day">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                            </asp:BoundField>
                                            <asp:CommandField ShowDeleteButton="True">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:CommandField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridheader" />
                                        <AlternatingRowStyle CssClass="gridAlternate" />
                                    </asp:GridView>
                                </td>
                                <td>
                                    <cc1:MaskedEditExtender ID="msk_strt" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtStartTime">
                                    </cc1:MaskedEditExtender>
                                    <cc1:MaskedEditExtender ID="msk_clsTime" runat="server" Mask="99:99" MaskType="Time" TargetControlID="txtCloseTime">
                                    </cc1:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:13%"></td>
                                <td style="width:13%"></td>
                                <td style="width:13%"></td>
                                <td style="width:13%"></td>
                                <td style="width:8%"></td>
                                <td style="width:40%"></td>                                
                            </tr>
                        </table>
                    </td>
                    <td>
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
                    <td colspan="2">
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
                        <asp:GridView ID="gvOrganization" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="OrgId" TabIndex="50"
                            ToolTip="View Organizations Information" Width="85%" 
                            OnPageIndexChanging="gvOrganization_PageIndexChanging"
                             OnRowEditing="gvOrganization_RowEditing" OnSorting="gvOrganization_Sorting" OnRowCommand="gvOrganization_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="Name" HeaderText="Organization" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Acronym" HeaderText="Acronym">
                                    <ControlStyle Width="15%" />
                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="process_fee" HeaderText="Process Fee">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Width="17%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Active">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                    <ControlStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="External">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGVExternal" runat="server" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem,"External").ToString()=="Y" %>' />
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
                </tr>
                <tr>
                    <td align="left" colspan="7">
                        <asp:Label ID="lblstatus" runat="server" Visible="False" TabIndex="30"></asp:Label>
                        <asp:Label ID="lblOrgId" runat="server" Visible="False" TabIndex="31"></asp:Label></td>
                </tr>               
            </table>
            <%--</ContentTemplate>
                        </asp:UpdatePanel> --%>       
</asp:Content>

