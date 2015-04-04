﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="spDisc_balsummary.aspx.cs" Inherits="Report_spDisc_balsummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="smanager1" runat="server"></asp:ScriptManager>
<table id="tblhead" width="100%">
<tr>
<td colspan="5" align="center" 
        style="font-family: Verdana; font-size: large; font-weight: bold; font-style: normal; font-variant: normal; text-transform: capitalize">
    Balance and Discount summary</td>

</tr>
<tr>
<td colspan="3">
<asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</td>

<td colspan="2" align="right">
     <asp:ImageButton ID="ibtnReport" runat="server" ImageUrl="~/images/ReportPack.gif"  OnClick="lbtnReport_Click" />
     <asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="lbtnClearAll_Click" />
     <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="btnClose_Click"></asp:ImageButton>
</td>

</tr>

<tr>
<td width="20%"></td>
<td width="20%"></td>
<td width="20%"></td>
<td width="20%"></td>
<td width="20%"></td>
</tr>
</table>

<table id="tblbody" width="100%">
<tr>
<td></td>
<td colspan="2">
<asp:RadioButton ID="rdoBalanceSummary" runat="server" Text="Due Balance Summary" 
        Checked="true" GroupName="report" />
<asp:RadioButton ID="rdoDiscountSummary" runat="server" Text="Discount Summary" 
        GroupName="report" />
</td>
<td></td>
<td></td>
<td></td>
<td></td>

</tr>

<tr>
<td align="right">Branch:</td>
<td>
<asp:DropDownList ID="ddlBranch" runat="server" CssClass="dropdown" Width="98%" ></asp:DropDownList>
<cc1:ListSearchExtender ID="lsebranch" runat="server" TargetControlID="ddlBranch"></cc1:ListSearchExtender>
</td>
<td align="right">Date Range:</td>
<td>
<asp:TextBox ID="txtdateFrom" runat="server" Width="45%" CssClass="txtareaStyle"></asp:TextBox>
<asp:TextBox ID="txtdateTo" runat="server" Width="45%" CssClass="txtareaStyle"></asp:TextBox>
 <cc1:CalendarExtender ID="cetxtdateFrom" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFrom" TargetControlID="txtdateFrom"></cc1:CalendarExtender> 
 <cc1:CalendarExtender ID="cetxtdateTo" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtTo" TargetControlID="txtdateTo"></cc1:CalendarExtender>
</td>
<td></td>
<td></td>
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
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
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



