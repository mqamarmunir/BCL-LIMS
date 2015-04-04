<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="~/Parameter/AttributeRange.aspx.cs" Inherits="AttributeRange" Title="Attribute Range Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
    <%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .ajax__htmleditor_editor_default
        {
            height: 500px;
        }
    </style>
    <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">
        <tr>
            <td align="center" colspan="6" class="tdheading">
                Attribute Ranges Information
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:UpdatePanel ID="up_er" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red" TabIndex="32"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="5%">
            </td>
            <td align="left" width="13%">
            </td>
            <td width="33%">
            </td>
            <td align="left" width="12%">
                <asp:Button ID="lbtnSaveNext" runat="server" BackColor="SkyBlue" Font-Bold="True"
                    ForeColor="Navy" OnClick="lbtnSaveNext_Click" Text="Save & Next" Width="90%" />
            </td>
            <td align="left" width="32%">
                &nbsp;
                <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                    OnClick="imgReport_Click" />
                <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                    TabIndex="14" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s"
                    OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                        TabIndex="15" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x"
                        OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                            TabIndex="16" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c"
                            OnClick="btnClose_Click" />
            </td>
            <td width="5%">
            </td>
        </tr>
        <tr>
            <td class="screenid" colspan="6">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="5%">
            </td>
            <td align="left" width="13%">
            </td>
            <td width="33%">
            </td>
            <td align="left" width="12%">
            </td>
            <td align="left" width="32%">
                <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" />
            </td>
            <td width="5%">
            </td>
        </tr>
        <tr>
            <td width="5%">
            </td>
            <td align="left" colspan="4">
                <asp:UpdatePanel ID="up_ddl" runat="server">
                    <ContentTemplate>
                        <table id="tb_ddl" cellspacing="1" cellpadding="1" width="100%" border="0" class="label">
                            <tbody>
                                <tr>
                                    <td>
                                        Sub Department:
                                    </td>
                                    <td class="mandatoryField">
                                        <asp:DropDownList ID="ddlSubDepartment" TabIndex="1" runat="server" Width="100%"
                                            ToolTip="Select Sub Department" AutoPostBack="True" OnSelectedIndexChanged="ddlSubDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;Group:
                                    </td>
                                    <td class="mandatoryField">
                                        <asp:DropDownList ID="ddlGroup" TabIndex="2" runat="server" Width="100%" ToolTip="Select Group"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Test:
                                    </td>
                                    <td class="mandatoryField">
                                        <asp:DropDownList ID="ddlTest" TabIndex="3" runat="server" Width="100%" ToolTip="Select Test"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;Attribute:
                                    </td>
                                    <td class="mandatoryField">
                                        <asp:DropDownList ID="ddlAttribute" TabIndex="4" runat="server" Width="100%" ToolTip="Select Attribute"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlAttribute_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Method:
                                    </td>
                                    <td class="mandatoryField">
                                        <asp:DropDownList ID="ddlMethod" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;Attribute Unit:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAUnit" TabIndex="7" runat="server" Width="12%" ToolTip="Please Enter Attribute Unit"
                                            MaxLength="30" CssClass="field"></asp:TextBox>
                                            &nbsp;&nbsp;
                                           
                                            SI Unit:
                                             <asp:TextBox ID="txtSIunit" TabIndex="8" runat="server" Width="12%" ToolTip="Please Enter Attribute Unit"
                                            MaxLength="30" CssClass="field"></asp:TextBox>
                                            &nbsp;&nbsp;
                                            Conversion Factor:
                                            <asp:TextBox ID="txtconversionfactor" TabIndex="9" runat="server" Width="12%" ToolTip="Please Enter Attribute Unit"
                                            MaxLength="30" CssClass="field"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Gender:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSex" TabIndex="5" runat="server" Width="100%" ToolTip="Please Select Gender">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                            <asp:ListItem Value="M">Male</asp:ListItem>
                                            <asp:ListItem Value="F">Female</asp:ListItem>
                                            <asp:ListItem Value="A">All</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp; Min Age:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAge_Min" TabIndex="8" runat="server" Width="20%" ToolTip="Please Enter Minimum Age"
                                            MaxLength="30" CssClass="mandatoryField"></asp:TextBox>
                                        &nbsp; &nbsp;Max Age:<asp:TextBox ID="txtAge_Max" TabIndex="9" runat="server" Width="20%"
                                            ToolTip="Please Enter Maximum Age" MaxLength="30" CssClass="mandatoryField"></asp:TextBox>&nbsp;
                                        <asp:DropDownList ID="ddlAge" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Y">Year(s)</asp:ListItem>
                                            <asp:ListItem Value="M">Month(s)</asp:ListItem>
                                            <asp:ListItem Value="D">Day(s)</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Min Value:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMin_Value" TabIndex="10" runat="server" Width="30%" ToolTip="Please Enter Minimum Value"
                                            MaxLength="30" CssClass="mandatoryField"></asp:TextBox>
                                        &nbsp; &nbsp; Max Value:
                                        <asp:TextBox ID="txtMax_Value" TabIndex="11" runat="server" Width="30%" ToolTip="Please Enter Maximum Value"
                                            MaxLength="30" CssClass="mandatoryField"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp; Min Panic Value:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMin_Panic" TabIndex="12" runat="server" Width="30%" ToolTip="Please Enter Minimum Panic Value"
                                            MaxLength="30" CssClass="field"></asp:TextBox>
                                        Max Panic Value:<asp:TextBox ID="txtMax_Panic" TabIndex="13" runat="server" Width="30%"
                                            ToolTip="Please Enter Maximum Panic Value" MaxLength="30" CssClass="field"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Description:
                                    </td>
                                    <td colspan="3" >
                                   <CKEditor:CKEditorControl ID="txtDescription" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="50" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="true" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="50px" Enabled="True" ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table"  MaxLength="1000" Visible="true"></CKEditor:CKEditorControl>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="14%">
                                    </td>
                                    <td width="36%">
                                    </td>
                                    <td width="14%">
                                    </td>
                                    <td width="36%">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvAttributeRange" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td width="5%">
            </td>
        </tr>
        <tr>
            <td class="screenid" colspan="6" style="height: 12px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="screenid" colspan="6">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
            </td>
            <td width="30%">
            </td>
            <td align="left" width="10%">
            </td>
            <td width="30%">
            </td>
            <td width="5%">
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center" valign="top">
                <asp:UpdatePanel ID="up_grid" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvAttributeRange" TabIndex="50" runat="server" Width="97%" ToolTip="View Groups Detail Info"
                            CssClass="datagrid" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="RangeId"
                            OnPageIndexChanging="gvAttributeRange_PageIndexChanging" OnRowEditing="gvAttributeRange_RowEditing"
                            OnSorting="gvAttributeRange_Sorting" OnRowCommand="gvAttributeRange_RowCommand">
                            <RowStyle CssClass="gridItem"></RowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="test_name" HeaderText="Test">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="17%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="attribute_name" HeaderText="Attribute">
                                    <ControlStyle Width="30%"></ControlStyle>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Sex" HeaderText="Sex">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="9%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="referencerange" HeaderText="Reference Range">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="total_min" HeaderText="Min Age">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="9%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="total_max" HeaderText="Max Age">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="totaldays" HeaderText="Total Days">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="9%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="methodname" HeaderText="Method">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Active">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" Visible="false">
                                    <ControlStyle Width="10%"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                                </asp:CommandField>
                                <asp:CommandField ShowSelectButton="true" SelectText="Edit" />
                            </Columns>
                            <PagerStyle HorizontalAlign="Left"></PagerStyle>
                            <SelectedRowStyle CssClass="gridSelectedItem"></SelectedRowStyle>
                            <HeaderStyle CssClass="gridheader"></HeaderStyle>
                            <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlAttribute" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="ddlSubDepartment" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="ddlTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="6">
                <asp:Label ID="lblstatus" runat="server" Visible="False" TabIndex="30"></asp:Label>
                <asp:Label ID="lblAttributeRange" runat="server" Visible="False" TabIndex="31"></asp:Label>
                <asp:Label ID="lblSubDepartmentId" runat="server" TabIndex="32" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
