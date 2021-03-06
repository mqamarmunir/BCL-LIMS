﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="wfrmPreferenceSettings.aspx.cs" Inherits="Parameter_wfrmPreferenceSettings" %>

<asp:Content ID="Content1"  ContentPlaceHolderID="ContentPlaceholder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 

<table id="tblbody" class="label" cellpadding="1" cellspacing="1" width="100%">
<tr>
<td colspan="7" align="center"> <font size="4"><strong>PREFERENCE SETTINGS</strong></font>
<asp:HiddenField ID="hdPreferenceID" runat="server" />
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
<td align="right">
Records per Page(Cash Receipt):
</td>
<td>
<asp:TextBox ID="txtrecordsperpage" runat="server" CssClass="field"></asp:TextBox>
</td>
<td>Minimum Bill Collection Enforcement(%)</td>
<td>
<asp:TextBox ID="tbminimumcashpercentage" runat="server" CssClass="field"></asp:TextBox>
</td>
<td></td>

<td></td>
</tr>
<tr>
<td align="right">Rounding Off Factor:</td>
<td>
<asp:TextBox ID="txtRoundingoff" runat="server" CssClass="field"></asp:TextBox>
<cc1:FilteredTextBoxExtender FilterMode="InvalidChars" FilterType="Numbers" TargetControlID="txtRoundingoff" runat="server"></cc1:FilteredTextBoxExtender>
</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td align="right">
General Description:
</td>
<td colspan="2">
    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="field" Width="99%"></asp:TextBox>
    </td>

<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td align="right">
Login Instructions Text:
</td>
<td colspan="2">
    <asp:TextBox ID="txtloginInstructions" TextMode="MultiLine" runat="server" CssClass="field" Width="99%"></asp:TextBox>
    </td>

<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td colspan="7" align="center">
<asp:GridView ID="gvPreferences" runat="server" CssClass="datagrid" Width="50%" AutoGenerateColumns="false">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="gridItem" HorizontalAlign="Left" />
<AlternatingRowStyle CssClass="gridAlternate" />
<Columns>
<asp:TemplateField ItemStyle-Width="5%" HeaderText="S#">
<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="fieldName" HeaderText="Field" />
<asp:TemplateField ItemStyle-Width="5%">
<ItemTemplate>
<asp:CheckBox ID="gvchkfield" runat="server" />
</ItemTemplate>
</asp:TemplateField>
</Columns>

</asp:GridView>
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
</asp:Content>
