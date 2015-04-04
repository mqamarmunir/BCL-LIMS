<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="wfrmTest.aspx.cs" Inherits="Parameter_wfrmTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <cc1:TabContainer ID="TabContainer1" Width="99%" runat="server" 
        ActiveTabIndex="0">
        <cc1:TabPanel ID="tabTest" Width="99%" runat="server" HeaderText="Test Registration">
            <ContentTemplate>
                <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">
                    <tr>
                        <td align="center" colspan="8" class="tdheading">
                            Test Information
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="tdheading" colspan="8">
                            <cc1:CollapsiblePanelExtender ID="cpeWaiting" runat="server" CollapseControlID="pnlW2"
                                CollapsedImage="../images/expandw.jpg" CollapsedText="Show details..." ExpandControlID="pnlW2"
                                ExpandedImage="../images/collapsew.jpg" ExpandedText="Hide Details..." ImageControlID="imgW"
                                SuppressPostBack="True" TargetControlID="pnl_chg_gen" Enabled="True">
                            </cc1:CollapsiblePanelExtender>
                            <asp:UpdatePanel ID="up_prg" runat="server">
                                <ContentTemplate>
                                    <asp:UpdateProgress ID="upgress" runat="server" __designer:wfdid="w5" DisplayAfter="0">
                                        <ProgressTemplate>
                                            <div class="UpdateProgress">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="../images/loading.gif" __designer:wfdid="w6">
                                                </asp:Image>
                                                ........Loading! Please Wait
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="100%"
                                TabIndex="32"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
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
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <asp:Button ID="lbtnSaveNext" runat="server" BackColor="SkyBlue" Font-Bold="True"
                                ForeColor="Navy" OnClick="lbtnSaveNext_Click" Text="Save & Next" Height="28px"
                                Width="60%" TabIndex="18" Visible="False" />
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="imgReport" runat="server" Visible="False" ImageUrl="~/images/ReportPack.gif"
                                OnClick="imgReport_Click" />
                        </td>
                        <td>
                            <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                TabIndex="19" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s"
                                OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                    TabIndex="20" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x"
                                    OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                                        TabIndex="21" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c"
                                        OnClick="btnClose_Click" />
                        </td>
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
                        <td>
                        </td>
                        <td>
                        </td>
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
                        <td colspan="6">
                            <asp:UpdatePanel ID="Up_pnl_test" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlTestInfo" runat="server" Font-Bold="True" Width="99%" GroupingText="Test Info">
                                        <table id="tb_testInfo" class="label" cellspacing="1" cellpadding="1" width="100%"
                                            border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        Test(Search):
                                                    </td>
                                                    <td colspan="7">
                                                        <asp:Panel ID="searchpanel" runat="server" DefaultButton="imbtnsearch">
                                                            <asp:TextBox ID="txtsearchtest" runat="server" CssClass="field" Width="20%"></asp:TextBox>
                                                            <asp:ImageButton ID="imbtnsearch" runat="server" ImageUrl="~/images/btn_Blank.gif"
                                                                OnClick="imbtnsearch_Click" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Sub Department:
                                                    </td>
                                                    <td class="mandatoryField">
                                                        <asp:DropDownList ID="ddlSubdepartment" TabIndex="1" runat="server" Width="100%"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlSubdepartment_SelectedIndexChanged"
                                                            CssClass="dropdown">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="4">
                                                        &nbsp;
                                                        <asp:CheckBox ID="chkActive" runat="server" Text="Active" ToolTip="Check for remain Active throughout the application"
                                                            Checked="True" TextAlign="Left"></asp:CheckBox>
                                                        <asp:CheckBox ID="chkPrintGroup" runat="server" Text="Print Group" ToolTip="Check for remain Active throughout the application"
                                                            TextAlign="Left"></asp:CheckBox>
                                                        <asp:CheckBox ID="chkPrintTest" runat="server" Text="Print Test" ToolTip="Check for remain Activethroughout the application"
                                                            TextAlign="Left"></asp:CheckBox>
                                                        <asp:CheckBox ID="chkUrgent" runat="server" Text="Urgent" ToolTip="Check for remain Activethroughout the application"
                                                            TextAlign="Left"></asp:CheckBox>
                                                        <asp:CheckBox ID="chkSepReport" runat="server" Text="Sep Report" ToolTip="Check for remain Activethroughout the application"
                                                            TextAlign="Left"></asp:CheckBox>
                                                        <asp:CheckBox ID="chkExternal" runat="server" Text="External" AutoPostBack="True"
                                                            TextAlign="Left" OnCheckedChanged="chkExternal_CheckedChanged"></asp:CheckBox>
                                                        <asp:CheckBox ID="chkProvisionRPT" runat="server" Text="Provision Report" TextAlign="Left">
                                                        </asp:CheckBox>
                                                        <asp:CheckBox ID="chkDiscountApplic" runat="server" Text="Discount Applicable" TextAlign="Left"
                                                            Checked="true" />
                                                        <asp:CheckBox ID="chkDplan" Text="Delivery(Day Plan)" runat="server" TextAlign="Left"
                                                            Checked="false" AutoPostBack="true" OnCheckedChanged="chkDPlan_CheckedChanged" />
                                                            <asp:CheckBox ID="CheckSpecial" Text="Special Test" runat="server" TextAlign="Left"
                                                            Checked="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Group:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGroup" TabIndex="2" runat="server" Width="100%" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" CssClass="dropdown">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Test Name:
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtTest_Name" TabIndex="3" runat="server" Width="97%" ToolTip="Enter Test Name"
                                                            CssClass="mandatoryField" MaxLength="200"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Acronym:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAcronym" TabIndex="4" runat="server" Width="96%" ToolTip="Please Enter Acronym"
                                                            CssClass="mandatoryField" MaxLength="10"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        Procedure:
                                                    </td>
                                                    <td class="mandatoryField">
                                                        <asp:DropDownList ID="ddlProcedure" TabIndex="6" runat="server" Width="100%" CssClass="dropdown">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlMethod" TabIndex="5" runat="server" Visible="False" Width="100%"
                                                            CssClass="dropdown">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Test Type:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTestType" TabIndex="7" runat="server" Width="100%" CssClass="dropdown">
                                                            <asp:ListItem Selected="True" Value="G">General</asp:ListItem>
                                                            <asp:ListItem Value="H">Histopathalogy</asp:ListItem>
                                                            <asp:ListItem Value="M">Micro</asp:ListItem>
                                                            <asp:ListItem Value="R">Radialogy</asp:ListItem>
                                                            <asp:ListItem Value="O">General Format2</asp:ListItem>                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Speed Key:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSpeedKey" TabIndex="8" runat="server" Width="38%" ToolTip="Enter Speed Key"
                                                            CssClass="field" MaxLength="10"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        Dorder:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOrder" TabIndex="9" runat="server" Width="46%" ToolTip="Please Enter DOrder"
                                                            CssClass="field" MaxLength="15"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Performing Location:
                                                    </td>
                                                    <td class="mandatoryField">
                                                        <asp:DropDownList ID="ddlExternalOrg" runat="server" Width="100%" CssClass="dropdown">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Report Format:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRptFormat" runat="server" Width="65%" CssClass="dropdown">
                                                            <asp:ListItem Value="1">One Column</asp:ListItem>
                                                            <asp:ListItem Value="2">Two Column</asp:ListItem>
                                                            <asp:ListItem Value="3">Three Column</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Perform:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPerform" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPerform_SelectedIndexChanged"
                                                            CssClass="dropdown">
                                                            <asp:ListItem Value="Daily">Daily</asp:ListItem>
                                                            <asp:ListItem Value="Days">Days Wise</asp:ListItem>
                                                            <asp:ListItem>Weekly</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:GridView ID="gvPerformOn" runat="server" CssClass="datagrid" AutoGenerateColumns="False">
                                                            <RowStyle CssClass="gridItem" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="#">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex+1 %>:
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mon">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk1" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tue">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk2" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Wed">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk3" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Thurs">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk4" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fri">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk5" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sat">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk6" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sun">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk7" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="gridheader" />
                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        Test Message:
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="txtTestinfoReport" CssClass="field" TextMode="MultiLine" Width="60%"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Instructions:
                                                    </td>
                                                    <td colspan="5">
                                                        Before:
                                                        <asp:TextBox ID="txtinstructions_b" runat="server" CssClass="field" Width="40%" TextMode="MultiLine"
                                                            ToolTip="Enter the Instructions to be followed by the patient before going through this test"></asp:TextBox>
                                                        After:
                                                        <asp:TextBox ID="txtinstructions_A" runat="server" CssClass="field" Width="40%" TextMode="MultiLine"
                                                            ToolTip="Enter the Instructions to be followed by the patient After going through this test"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Time Type:
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:DropDownList ID="ddlTimeType" runat="server" Width="20%" TabIndex="6">
                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                            <asp:ListItem Value="M">Minute(s)</asp:ListItem>
                                                            <asp:ListItem Value="H">Hour(s)</asp:ListItem>
                                                            <asp:ListItem Value="D">Day(s)</asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp; Min:&nbsp;&nbsp;<asp:TextBox ID="txtMinTime" runat="server" Width="20%" TabIndex="7"
                                                            CssClass="mandatoryField" MaxLength="3"></asp:TextBox>
                                                        &nbsp; &nbsp; Max:&nbsp;
                                                        <asp:TextBox ID="txtMaxTime" runat="server" Width="20%" TabIndex="8" CssClass="mandatoryField"
                                                            MaxLength="3"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="7">
                                                        <fieldset id="fsdplan" visible="true" runat="server">
                                                            <legend>Daily Plan</legend>
                                                            <table id="tblDplan" cellpadding="0" cellspacing="0" border="1" class="label" width="99%">
                                                                <tr>
                                                                    <td align="center">
                                                                        Time 1
                                                                    </td>
                                                                    <td align="center">
                                                                        Dispatch Time 1
                                                                    </td>
                                                                    <td align="center">
                                                                        Time 2
                                                                    </td>
                                                                    <td align="center">
                                                                        Dispatch Time 2
                                                                    </td>
                                                                    <td align="center">
                                                                        Time 3
                                                                    </td>
                                                                    <td align="center">
                                                                        Dispatch Time 3
                                                                    </td>
                                                                    <td align="center">
                                                                        Time 4
                                                                    </td>
                                                                    <td align="center">
                                                                        Dispatch Time 4
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="12%">
                                                                        <asp:TextBox ID="txtTime1" Style="text-align: center;" runat="server" Width="98%"
                                                                            CssClass="mandatoryField"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="msk1" runat="server" ClearMaskOnLostFocus="false" TargetControlID="txtTime1"
                                                                            Mask="99:99">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td width="12%">
                                                                        <asp:TextBox ID="txtDispatchtime1" runat="server" Width="98%" Style="text-align: center;"
                                                                            CssClass="mandatoryField"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="false"
                                                                            TargetControlID="txtDispatchtime1" Mask="99:99">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td width="12%">
                                                                        <asp:TextBox ID="txtTime2" Style="text-align: center;" runat="server" Width="98%"
                                                                            CssClass="mandatoryField"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ClearMaskOnLostFocus="false"
                                                                            TargetControlID="txtTime2" Mask="99:99">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td width="12%">
                                                                        <asp:TextBox ID="txtDispatchtime2" runat="server" Style="text-align: center;" Width="98%"
                                                                            CssClass="mandatoryField"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" ClearMaskOnLostFocus="false"
                                                                            TargetControlID="txtDispatchtime2" Mask="99:99">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td width="12%">
                                                                        <asp:TextBox ID="txtTime3" runat="server" Width="98%" Style="text-align: center;"
                                                                            CssClass="mandatoryField"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" ClearMaskOnLostFocus="false"
                                                                            TargetControlID="txtTime3" Mask="99:99">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td width="12%">
                                                                        <asp:TextBox ID="txtDispatchtime3" runat="server" Width="98%" Style="text-align: center;"
                                                                            CssClass="mandatoryField"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" ClearMaskOnLostFocus="false"
                                                                            TargetControlID="txtDispatchtime3" Mask="99:99">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td width="10%">
                                                                        <asp:TextBox ID="txtTime4" runat="server" Width="98%" Style="text-align: center;"
                                                                            CssClass="mandatoryField"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" ClearMaskOnLostFocus="false"
                                                                            TargetControlID="txtTime4" Mask="99:99">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td width="10%">
                                                                        <asp:TextBox ID="txtDispatchtime4" runat="server" Width="98%" Style="text-align: center;"
                                                                            CssClass="mandatoryField"></asp:TextBox>
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" ClearMaskOnLostFocus="false"
                                                                            TargetControlID="txtDispatchtime4" Mask="99:99">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="11%">
                                                    </td>
                                                    <td width="23%">
                                                    </td>
                                                    <td width="12%">
                                                    </td>
                                                    <td width="23%">
                                                    </td>
                                                    <td width="7%">
                                                    </td>
                                                    <td width="24%">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="6">
                            <asp:UpdatePanel ID="up_speci" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnl_speci" runat="server" Width="99%" GroupingText="Specimen Info"
                                        Height="50px" Font-Bold="True">
                                        <table id="tb_speci" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                                            <tr>
                                                <td>
                                                    Specimen/Film:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSpecimen" runat="server" Width="100%" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlSpecimen_SelectedIndexChanged" TabIndex="10" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Container/Type:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlContainer" runat="server" Width="100%" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlContainer_SelectedIndexChanged" TabIndex="11" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Quantity:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuantity" runat="server" MaxLength="20" TabIndex="12" ToolTip="Please Enter Quantity"
                                                        Width="96%" CssClass="field"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Unit:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUnit" runat="server" CssClass="field" MaxLength="10" Width="98%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="11%">
                                                </td>
                                                <td width="20%">
                                                </td>
                                                <td width="12%">
                                                </td>
                                                <td width="20%">
                                                </td>
                                                <td width="6%">
                                                </td>
                                                <td width="14%">
                                                </td>
                                                <td width="6%">
                                                </td>
                                                <td width="10%">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
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
                        <td>
                        </td>
                        <td>
                        </td>
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
                        <td colspan="3">
                            &nbsp;<asp:Panel ID="pnlW2" runat="server" Height="22px" Width="40%" ToolTip="Click here to see or hide General Information">
                                <asp:Image ID="imgW" runat="server" ImageUrl="~/images/expandw.jpg" />&nbsp; General
                                Information:
                            </asp:Panel>
                        </td>
                        <td>
                        </td>
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
                        <td colspan="4" rowspan="2">
                            <asp:Panel ID="pnl_chg_gen" runat="server" Height="50px" Width="99%" GroupingText="Charges & General">
                                <asp:UpdatePanel ID="pnlu" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table id="tb_chrg_gen" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                                            <tr>
                                                <td>
                                                    Charges:
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtCharges" runat="server" MaxLength="6" TabIndex="13" ToolTip="Enter Charges"
                                                        Width="12%" CssClass="mandatoryField"></asp:TextBox>
                                                    &nbsp; Urgent Charges:<asp:TextBox ID="txtChargesUrgent" runat="server" MaxLength="6"
                                                        TabIndex="14" ToolTip="Please Enter Charges Urgent" Width="12%" CssClass="field"></asp:TextBox>
                                                    &nbsp; Charity Rate:<asp:TextBox ID="txtCharity" runat="server" CssClass="field"
                                                        MaxLength="6" Width="12%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Clinical Information:
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtClinicalUse" runat="server" CssClass="field" MaxLength="255"
                                                        TabIndex="15" Width="98%" ToolTip="Enter Clinical Use" TextMode="MultiLine" Height="43px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Interpretation Text:
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtAutomatedText" runat="server" CssClass="field" MaxLength="1500"
                                                        TabIndex="16" Width="98%" ToolTip="Enter Automated Text" TextMode="MultiLine"
                                                        Height="43px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Age Applicable:
                                                </td>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvAgeApp" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                                        Width="60%" TabIndex="17">
                                                        <RowStyle CssClass="gridItem" />
                                                        <Columns>
                                                            <asp:BoundField DataField="gender" HeaderText="Gender">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Min Age">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtMinAge" runat="server" CssClass="field" MaxLength="3" Width="60%"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Max Age">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtMaxAge" runat="server" CssClass="field" MaxLength="3" Width="60%"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="gridheader" />
                                                        <AlternatingRowStyle CssClass="gridAlternate" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%">
                                                </td>
                                                <td width="25%">
                                                </td>
                                                <td width="25%">
                                                </td>
                                                <td width="25%">
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                        <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </td>
                        <td colspan="2" valign="top">
                            <asp:UpdatePanel ID="up_meth" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlMehd" runat="server" Width="97%" Height="82px" ScrollBars="Auto"
                                        GroupingText="Method">
                                        <table id="tbMthd" width="100%" cellpadding="1" cellspacing="1" border="0" class="label">
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvMethod" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                                        ShowHeader="False">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>:
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="name" HeaderText="Method Name" ShowHeader="False">
                                                                <ItemStyle HorizontalAlign="Left" Width="90%" />
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <RowStyle CssClass="gridItem" />
                                                        <AlternatingRowStyle CssClass="gridAlternate" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2" valign="top">
                            <asp:UpdatePanel ID="up_gb" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlGB" runat="server" Width="97%" Height="82px" ScrollBars="Auto"
                                        GroupingText="Group">
                                        <table id="tbGB" border="0" cellpadding="1" cellspacing="1" width="100%">
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                                        ShowHeader="False">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>:
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="name" HeaderText="Group Name" ShowHeader="False">
                                                                <ItemStyle HorizontalAlign="Left" Width="90%" />
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <RowStyle CssClass="gridItem" />
                                                        <AlternatingRowStyle CssClass="gridAlternate" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="screenid" colspan="8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center" valign="top">
                            <asp:UpdatePanel ID="up_grid" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="gvTest" TabIndex="50" runat="server" Width="95%" ToolTip="View Test Information"
                                        OnSorting="gvTest_Sorting" OnRowEditing="gvTest_RowEditing" OnPageIndexChanging="gvTest_PageIndexChanging"
                                        OnRowCommand="gvTest_RowCommand" DataKeyNames="TestId" CssClass="datagrid" AutoGenerateColumns="False"
                                        AllowSorting="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S#">
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="subname" HeaderText="Sub-Dept" ReadOnly="True" SortExpression="subname">
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Test_Name" HeaderText="Test Name" ReadOnly="True" SortExpression="NAME">
                                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="defaultmethod" HeaderText="Method">
                                                <ControlStyle Width="30%" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="GroupName" HeaderText="Group">
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Specimen_Name" HeaderText="Specimen">
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="charges" HeaderText="Charges">
                                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="charityrate" HeaderText="Charity">
                                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="dorder" HeaderText="Dorder">
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" Width="5%" />
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
                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSubdepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="imbtnsearch" EventName="Click" />
                                    
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="8">
                            <asp:Label ID="lblstatus" runat="server" Visible="False" TabIndex="30"></asp:Label>&nbsp;
                            <asp:Label ID="lblTestId" runat="server" TabIndex="31" Visible="False"></asp:Label>
                            <asp:Label ID="lblGroupId" runat="server" TabIndex="31" Visible="False"></asp:Label>
                            <asp:Label ID="lblSubDepartmentId" runat="server" TabIndex="31" Visible="False"></asp:Label>
                            <asp:Label ID="lblPrev_SubID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="3%">
                        </td>
                        <td width="13%">
                        </td>
                        <td width="20%">
                        </td>
                        <td width="12%">
                        </td>
                        <td width="17%">
                        </td>
                        <td width="13%">
                        </td>
                        <td width="20%">
                        </td>
                        <td width="2%">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <%-- method Test Tab Design--%>
        <cc1:TabPanel ID="tabmethodtests" Width="99%" HeaderText="Test Method" runat="server">
            <ContentTemplate>
                <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                    <tr>
                        <td align="center" class="tdheading" colspan="8">
                            Method Configuration
                        </td>
                    </tr>
                    <tr>
                        <td class="screenid" colspan="8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                                ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="screenid" colspan="8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
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
                            Client:
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"
                                Width="99%">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
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
                            Sub-Department:
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlSubDept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubDept_SelectedIndexChanged"
                                Width="99%">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
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
                            Method:
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlMethodmethod" runat="server" Width="80%" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlMethodmethod_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkDefault" runat="server" Text="Default" />
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
                            Test:
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlTest" runat="server" Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Dorder:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOrdermethod" runat="server" CssClass="field" Width="50%"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="screenid" colspan="8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
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
                        <td colspan="5">
                            <asp:GridView ID="gvMethodTest" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                DataKeyNames="methodid,testid" OnRowCommand="gvMethodTest_RowCommand">
                                <RowStyle CssClass="gridItem" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="test_name" HeaderText="Test" SortExpression="name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="80%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dorder" HeaderText="Dorder">
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Default">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkGvDefault" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"m_Default").ToString()=="Y" %>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:CommandField>
                                </Columns>
                                <HeaderStyle CssClass="gridheader" />
                                <AlternatingRowStyle CssClass="gridAlternate" />
                            </asp:GridView>
                        </td>
                        <td>
                            &nbsp;<asp:Label ID="lblStatusmethod" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblOldMethodID" runat="server" Visible="False"></asp:Label>
                        </td>
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
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td width="5%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="20%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="20%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="20%">
                        </td>
                        <td width="5%">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </cc1:TabPanel>
        <%--Test Attribute Registration tab --%>
        <cc1:TabPanel ID="tabTestAttributeRegistration" HeaderText="Test Attributes" runat="server">
            <ContentTemplate>
                <asp:UpdatePanel ID="updtepage" runat="server">
                    <ContentTemplate>
                        <table id="Table2" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">
                            <tr>
                                <td align="center" colspan="8" class="tdheading">
                                    Attributes Information
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td align="">
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
                                <td>
                                    <asp:LinkButton ID="lbtnCpyAtt" runat="server" ForeColor="Blue" OnClick="lbtnCpyAtt_Click">Copy Attribute</asp:LinkButton>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
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
                                <td colspan="7">
                                    <asp:UpdatePanel ID="up_at" runat="server">
                                        <ContentTemplate>
                                            <table id="tb_at" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <asp:Label ID="lblErrMsgattribute" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                        </td>
                                                        <td align="center" colspan="2">
                                                            <asp:Button ID="ibtnsavenextattribute" OnClick="lbtnSaveNextAttribute_Click" runat="server"
                                                                Font-Bold="True" ForeColor="Navy" Text="Save & Next" BackColor="SkyBlue"></asp:Button>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton AccessKey="s" ID="ibtnsaveattribute" TabIndex="14" OnClick="lbtnSaveattribute_Click"
                                                                runat="server" ImageUrl="~/images/SavePack_2.gif" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)">
                                                            </asp:ImageButton><asp:ImageButton AccessKey="x" ID="ibtnclearattribute" TabIndex="15"
                                                                OnClick="lbtnClearAllattribute_Click" runat="server" ImageUrl="~/images/ClearPack.gif"
                                                                ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)"></asp:ImageButton><asp:ImageButton
                                                                    AccessKey="c" ID="ibtncloseattribute" TabIndex="16" OnClick="btnCloseattribute_Click"
                                                                    runat="server" ImageUrl="~/images/ClosePack.gif" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)">
                                                                </asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="screenid" colspan="6">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Sub Department:
                                                        </td>
                                                        <td class="mandatoryField">
                                                            <asp:DropDownList ID="ddlSubDepartmentattribute" TabIndex="1" runat="server" ToolTip="Select Sub Department the Attribute"
                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlSubDepartmentattribute_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right">
                                                            Test:&nbsp;
                                                        </td>
                                                        <td class="mandatoryField" colspan="2">
                                                            <asp:DropDownList ID="ddlTestattribute" TabIndex="2" runat="server" ToolTip="Select Test for the Attribute"
                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlTestattribute_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkActiveattribute" TabIndex="3" runat="server" Text="Active" ToolTip="Check for remain Activethroughout the application"
                                                                Checked="True"></asp:CheckBox>
                                                            <asp:CheckBox ID="chkInterfaced" TabIndex="4" runat="server" Text="Interfaced" ToolTip="Check for remain Activethroughout the application"
                                                                Checked="True"></asp:CheckBox>
                                                            <asp:CheckBox ID="chkDrived" runat="server" Text="Drived"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Attribute:
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtAttribute_Name" TabIndex="5" runat="server" ToolTip="Enter Attribute Name/Title"
                                                                Width="97%" MaxLength="100" CssClass="mandatoryField"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            Acronym:<asp:TextBox ID="txtAcronymattribute" TabIndex="6" runat="server" ToolTip="Please Enter Acronym for the Attribute"
                                                                Width="52%" MaxLength="10" CssClass="field"></asp:TextBox>
                                                        </td>
                                                        <td align="right">
                                                            D-Order:&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDOrderattribute" TabIndex="7" runat="server" ToolTip="Enter Display Order for the Attribute"
                                                                Width="39%" MaxLength="15" CssClass="field"></asp:TextBox>
                                                            <asp:Label ID="lblParentID" runat="server" Visible="False"></asp:Label>&nbsp;<asp:CheckBox
                                                                ID="chkHeading" runat="server" Text="Heading"></asp:CheckBox>
                                                            <asp:CheckBox ID="chkPrint" runat="server" Text="Print" Checked="True" __designer:wfdid="w12">
                                                            </asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            D A Formula:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtD_A_Formula" TabIndex="8" runat="server" ToolTip="Enter Formula for the Derived Attribute"
                                                                Width="99%" MaxLength="50" CssClass="field"></asp:TextBox>
                                                        </td>
                                                        <td align="right">
                                                            Attribute Type:&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlAttributeType" TabIndex="9" runat="server" ToolTip="Select Attribute Type"
                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlAttributeType_SelectedIndexChanged"
                                                                Width="100%">
                                                                <asp:ListItem Value="N">Number</asp:ListItem>
                                                                <asp:ListItem Value="T">Text</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right">
                                                            Lines:&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLines" TabIndex="10" runat="server" ToolTip="Enter No. of Lines for the Text Box Input on Transaction Screens"
                                                                Width="39%" MaxLength="15" CssClass="field"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            Da Formula Desc:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtD_A_Formula_Desc" TabIndex="11" runat="server" ToolTip="Enter Description and Reference of Formula for Verification on Transaction and Reference for the Formula"
                                                                Width="98%" MaxLength="1024" CssClass="field" Height="55px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                        <td valign="top" align="right">
                                                            Default Value:&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDefaultValue" TabIndex="12" runat="server" ToolTip="Enter Default Value"
                                                                Width="98%" MaxLength="1024" CssClass="field" Height="55px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                        <td valign="top" align="right">
                                                            Description:&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDescription" TabIndex="13" runat="server" ToolTip="Enter Description for the Attribute"
                                                                Width="58%" MaxLength="250" CssClass="field" Height="55px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="13%">
                                                        </td>
                                                        <td width="20%">
                                                        </td>
                                                        <td width="13%">
                                                        </td>
                                                        <td width="17%">
                                                        </td>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="27%">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:UpdatePanel ID="pnl_att_sel" runat="server">
                                        <ContentTemplate>
                                            <div style="left: 90px; position: relative; top: 90px">
                                                <asp:Panel ID="pnlSel_Attrib" runat="server" BorderColor="#004000" BorderStyle="Double"
                                                    Height="320px" BackColor="#C0FFFF" Width="99%" ScrollBars="Vertical">
                                                    <table id="tb_cpy" width="100%" cellpadding="1" cellspacing="1" border="0" class="label">
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <strong>Select Attribute</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                Search:&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtCpySearch" runat="server" CssClass="field"></asp:TextBox>
                                                            </td>
                                                            <td align="right" colspan="2">
                                                                <asp:ImageButton ID="imgcpySearch" runat="server" ImageUrl="~/images/Search_OT.gif"
                                                                    OnClick="imgcpySearch_Click" /><asp:ImageButton ID="imgCpyClose" OnClick="imgCpyClose_Click"
                                                                        runat="server" ImageUrl="~/images/ClosePack.gif"></asp:ImageButton>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="gvsl_attrib" runat="server" Width="100%" CssClass="datagrid" AutoGenerateColumns="False"
                                                                    DataKeyNames="attributeid">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="test_name" HeaderText="Test">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Attribute">
                                                                            <ItemTemplate>
                                                                                &nbsp;<asp:LinkButton ID="lbtnSL_Attrib" Text='<%#DataBinder.Eval(Container.DataItem,"att_Name") %>'
                                                                                    runat="server" OnClick="lbtnSL_Attrib_Click"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="gridItem"></RowStyle>
                                                                    <HeaderStyle CssClass="gridheader"></HeaderStyle>
                                                                    <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="25%">
                                                            </td>
                                                            <td width="25%">
                                                            </td>
                                                            <td width="25%">
                                                            </td>
                                                            <td width="25%">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="lbtnCpyAtt" EventName="Click"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                </td>
                                <td rowspan="1">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td rowspan="1">
                                </td>
                                <td>
                                </td>
                                <td rowspan="1">
                                </td>
                                <td>
                                </td>
                                <td rowspan="1">
                                    <asp:LinkButton ID="btnUpdateDOrder" runat="server" ForeColor="Blue" OnClick="btnUpdateDOrder_Click"
                                        Text="Update Dorder"></asp:LinkButton>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="screenid" colspan="8">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="screenid" colspan="8">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="center" colspan="7">
                                    <asp:UpdatePanel ID="up_gd" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvAttribute" runat="server" ToolTip="View Attributes Info" Width="90%"
                                                CssClass="datagrid" DataKeyNames="AttributeId,testid" AutoGenerateColumns="False"
                                                AllowSorting="True" OnPageIndexChanging="gvAttribute_PageIndexChanging" OnRowEditing="gvAttribute_RowEditing"
                                                OnSorting="gvAttribute_Sorting" OnRowCommad="gvAttribute_RowCommand">
                                                <RowStyle CssClass="gridItem"></RowStyle>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Attribute_Name" HeaderText="Name" ReadOnly="True" SortExpression="Attribute_Name">
                                                        <HeaderStyle HorizontalAlign="Left" ForeColor="Blue"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Acronym" HeaderText="Acronym" SortExpression="Acronym">
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SubDeptName" HeaderText="SubDepartment" SortExpression="SubDeptName">
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Test_Name" HeaderText="Test Name" SortExpression="Test_Name">
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Active">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
                                                                Enabled="False" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Heading">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkgvHeading" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Heading").ToString() == "Y") %>'
                                                                Enabled="False" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkGVPrint" runat="server" Enabled="False" __designer:wfdid="w13"
                                                                Checked='<%# DataBinder.Eval(Container.DataItem,"Print").ToString()=="Y" %>'>
                                                            </asp:CheckBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Dorder">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvtxtDorder" Text='<%# (DataBinder.Eval(Container.DataItem, "DOrder").ToString()) %>'
                                                                Width="98%" MaxLength="4" runat="server" CssClass="field"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="flt_gvdorder" runat="Server" FilterType="Numbers"
                                                                TargetControlID="gvtxtDorder">
                                                            </cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowEditButton="True" Visible="true">
                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                    </asp:CommandField>
                                                    <asp:CommandField ShowSelectButton="true" Visible="false" SelectText="Edit" />
                                                </Columns>
                                                <PagerStyle HorizontalAlign="Left"></PagerStyle>
                                                <SelectedRowStyle CssClass="gridSelectedItem"></SelectedRowStyle>
                                                <HeaderStyle CssClass="gridheader"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlSubDepartmentattribute" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="ddlTestattribute" EventName="SelectedIndexChanged">
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="8">
                                    <asp:Label ID="lblstatusattribute" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblAttributeId" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblSubDepartmentIdattribute" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td width="13%">
                                </td>
                                <td width="20%">
                                </td>
                                <td width="12%">
                                </td>
                                <td width="20%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="20%">
                                </td>
                                <td width="2%">
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvAttribute" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTestattribute" EventName="SelectedindexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
