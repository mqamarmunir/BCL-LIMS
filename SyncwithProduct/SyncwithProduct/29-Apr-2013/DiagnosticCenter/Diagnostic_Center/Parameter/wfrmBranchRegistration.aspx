<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBranchRegistration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager> 
<asp:UpdatePanel ID="uodteform" runat="server">
<ContentTemplate>


<table id="tblbody" class="label" cellpadding="1" cellspacing="1" width="100%">
<tr>
<td colspan="7" align="center"> <font size="4"><strong>Branch Registration</strong></font>
<asp:HiddenField ID="hdBranchID" runat="server" />
</td>

</tr>
<tr>
<td colspan="7" align="right">
 <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="12" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" />
 <asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="13" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" />
<asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                                        TabIndex="14" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" />

</td>

</tr>
<tr>
<td colspan="7"><asp:Label ID="lblErrMsg" ForeColor="Red" runat="server" Font-Size="X-Small"></asp:Label></td>

</tr>
<tr>
<td align="right">Organization:</td>
<td><asp:DropDownList ID="ddlOrganiztions" runat="server" Width="100%" 
        CssClass="dropdown" AutoPostBack="True" 
        onselectedindexchanged="ddlOrganiztions_SelectedIndexChanged"></asp:DropDownList> </td>
<td align="right"><asp:CheckBox ID="chkActive" Text="Active" Checked="true" runat="server" TextAlign="Left" /></td>
<td colspan="4">
    <asp:CheckBox ID="chkPrintText" Text="Print Report Text" Checked="true" runat="server" TextAlign="left" />
    <asp:CheckBox ID="chkDplan" Text="Daily Plan on Internal Tests" Checked="true" runat="server" TextAlign="left" />
    <asp:CheckBox ID="chkIndoor" Text="Indoor Facility" runat="server" Checked="false" TextAlign="left" />
</td>

</tr>
<tr>
<td align="right">Name:</td>
<td><asp:TextBox ID="txtName" CssClass="mandatoryField" runat="server" Width="100%"></asp:TextBox></td>
<td align="right">Acronym:</td>
<td><asp:TextBox ID="txtAcronym" CssClass="mandatoryField" runat="server" Width="100%"></asp:TextBox></td>
<td align="right">Branch Code:

</td>
<td>
<asp:TextBox ID="txtBrCode" runat="server" Width="25%"></asp:TextBox>
<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
        TargetControlID="txtBrCode" Mask="999" ClearMaskOnLostFocus="false">
    </cc1:MaskedEditExtender>
</td>
<td></td>
</tr>
<tr>
<td align="right">Phone Number:</td>
<td><asp:TextBox ID="txtPhone" CssClass="mandatoryField" runat="server" Width="50%"></asp:TextBox>
    &nbsp; Ext:<asp:TextBox ID="txtExtension" runat="server" CssClass="mandatoryField" 
        Width="25%"></asp:TextBox>
    </td>
<td align="right">Fax Number:</td>
<td><asp:TextBox ID="txtFax" CssClass="field" runat="server" Width="100%"></asp:TextBox></td>
<td>Minimum Cash Collection(Booking)</td>
<td>
    <asp:TextBox ID="txtCashCollection" runat="server" Width="25%"></asp:TextBox>
   <%-- <cc1:MaskedEditExtender ID="txtBrCode0_MaskedEditExtender" runat="server" 
        ClearMaskOnLostFocus="false" CultureAMPMPlaceholder="" 
        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
        Mask="999" TargetControlID="txtCashCollection">--%>
    </cc1:MaskedEditExtender>
    </td>
<td></td>
</tr>
<tr>
<td align="right">Street Address:</td>
<td><asp:TextBox ID="txtAddress" CssClass="mandatoryField" TextMode="MultiLine" Width="100%" runat="server"></asp:TextBox></td>
<td align="right">City:</td>
<td><asp:DropDownList ID="ddlCity" runat="server" Width="100%" 
        CssClass="dropdown">
  
    
  
    
 
    </asp:DropDownList> </td>
<td></td>
<td></td>
<td></td>
</tr>

<tr>
<td align="right">
<asp:CheckBox ID="chk24Hrs" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="chk24Hrs_CheckedChanged" Text="24 Hrs Services" />
</td>
<td colspan="6">
<asp:UpdatePanel ID="updtebranchTimings" Visible="false" runat="server">
<ContentTemplate>
<table id="tblbranchTimings" runat="server" width="99%" class="label">
<tr>
<td align="right">Branch Timings:(From)</td>
<td colspan="3">
<asp:TextBox ID="txtstartTiming" runat="server" CssClass="mandatoryField" Width="7%"></asp:TextBox>
    <cc1:MaskedEditExtender ID="txtstartTiming_MaskedEditExtender" runat="server" 
        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
        TargetControlID="txtstartTiming" Mask="99:99" ClearMaskOnLostFocus="false">
    </cc1:MaskedEditExtender>
(To)<asp:TextBox ID="txtEndTiming" runat="server" CssClass="mandatoryField" Width="7%"></asp:TextBox> 
    <cc1:MaskedEditExtender ID="txtEndTiming_MaskedEditExtender" runat="server" 
        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
        TargetControlID="txtEndTiming" Mask="99:99" ClearMaskOnLostFocus="false"> 
    </cc1:MaskedEditExtender>
</td>
<td></td>
<td></td>
<td></td>
</tr>

<tr>
<td width="20%"></td>
<td width="20%"></td>
<td width="15%"></td>
<td width="15%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>
</table>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="chk24Hrs" EventName="CheckedChanged" />
</Triggers>
</asp:UpdatePanel>

</td>



</tr>
<tr>
<td align="right">Report Text:</td>
<td colspan="3">
<asp:TextBox ID="txtReportText" CssClass="field" Width="99%" TextMode="MultiLine" runat="server" ToolTip="Enter the Text you want to display on Patient Report"></asp:TextBox>
</td>
<td></td>
<td></td>
<td></td>

</tr>
<tr>
<td align="right">Type:</td>
<td><asp:DropDownList ID="ddlType" runat="server" Width="100%" 
        CssClass="dropdown" AutoPostBack="True" 
        onselectedindexchanged="ddlType_SelectedIndexChanged">
    <asp:ListItem Value="-1">Select</asp:ListItem>
    <asp:ListItem Value="F">Franchise</asp:ListItem>
    <%--<asp:ListItem Value="R">Rental Business</asp:ListItem>--%>
    <asp:ListItem Value="S">Self Operated</asp:ListItem>
    </asp:DropDownList> </td>
<td colspan="3">
<asp:UpdatePanel ID="updtepercent" runat="server">
<ContentTemplate>
<asp:Panel ID="pnlpercent" BackColor="Aqua" Visible="false" runat="server" Width="100%">
<table width="100%">
<tr>
<td width="32%" align="right">Business Policy:</td>
<td width="32%">

    <asp:DropDownList ID="ddlbpolicy" runat="server" CssClass="mandatorySelect" 
        Width="100%" AutoPostBack="True" 
        onselectedindexchanged="ddlbpolicy_SelectedIndexChanged">
        <asp:ListItem Value="-1">Select</asp:ListItem>
        <asp:ListItem Value="G">Gross</asp:ListItem>
        <asp:ListItem Value="N">Net</asp:ListItem>
    </asp:DropDownList>
   
    </td>
    <td width="36%">
    <asp:UpdatePanel ID="pnlbpolicy" Visible="false" runat="server">
    <ContentTemplate>
    %age:
    <asp:TextBox ID="txtPercentage" runat="server" CssClass="mandatoryField" Width="50%"></asp:TextBox>
    %</ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="ddlbpolicy" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </td>

</tr>
</table>
</asp:Panel>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
</Triggers>
</asp:UpdatePanel>

</td>
<td></td>
<td></td>

</tr>
<tr>
<td></td>
<td colspan="6"><asp:Label ID="lblCount" runat="server"></asp:Label></td>

</tr>
<tr>
<td></td>
<td colspan="6">
<asp:UpdatePanel ID="updtegrid" runat="server">
<ContentTemplate>

<asp:GridView ID="gvBranches" runat="server" Width="75%" DataKeyNames="BranchID" CssClass="datagrid" 
OnRowEditing="gvBranches_RowEditing" OnRowCommand="gvBranches_RowCommand" AutoGenerateColumns="false">
<RowStyle CssClass="gridItem" />
<AlternatingRowStyle CssClass="gridAlternate" />
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<Columns>
<asp:TemplateField HeaderText="S#">
<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Name" HeaderText="Branch Name" />
<asp:BoundField DataField="Organization" HeaderText="Organization" />
<asp:BoundField DataField="Type" HeaderText="Type" />
<asp:TemplateField HeaderText="Active">
    <ItemStyle HorizontalAlign="Center" Width="8%" />
    <ItemTemplate>
        <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
            Enabled="False" />
    </ItemTemplate>
                                  
</asp:TemplateField>
<asp:BoundField DataField="logininfo" HeaderText="Login Info" />

<asp:CommandField ShowEditButton="true" Visible="false" />
<asp:CommandField ShowSelectButton="true" SelectText="Edit" />
</Columns>
</asp:GridView>
</ContentTemplate>
<Triggers> 
<asp:AsyncPostBackTrigger ControlID="ddlOrganiztions" EventName="SelectedIndexChanged" />
</Triggers>
    </asp:UpdatePanel>
</td>

</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
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
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

