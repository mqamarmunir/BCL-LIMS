﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmPanelSummary.aspx.cs" Inherits="Report_wfrmPanelSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Cash Summary</div>

<table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
   
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc1:CalendarExtender ID="cal_from" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFrom" TargetControlID="txtFrom"></cc1:CalendarExtender> 
            <cc1:CalendarExtender ID="cal_to" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtTo" TargetControlID="txtTo"></cc1:CalendarExtender>
        </td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    </table>

    <table>
    <tr>
        
        <td style="width:100%;" align="right">
            <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                OnClick="imgReport_Click" /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif"
                    OnClick="imgClear_Click" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" /></td>
        <td>
        
    </tr>
    </table>

    <table>
    <tr>
        <td colspan="8">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            Branch:</td>
        <td>
            
            <asp:DropDownList ID="ddlBranch" Font-Size="11px" runat="server" Width="100%">
            </asp:DropDownList>
            
        <td>
        <asp:RadioButtonList ID="rdbLab" Visible="false" Font-Size="11px" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="A">All</asp:ListItem>
                <asp:ListItem Value="008">AMC</asp:ListItem>
                <asp:ListItem Value="006">BCL</asp:ListItem>
                <asp:ListItem Value="020">CC</asp:ListItem>
            </asp:RadioButtonList>
        </td>
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
        <td></td>
        <td>
            Panel:</td>
        <td>
            <asp:DropDownList ID="ddlPanel" Font-Size="11px" runat="server" Width="100%">
            </asp:DropDownList></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td>
            Report Option:</td>
        <td>
            <%--<asp:DropDownList ID="ddlConsultant" Font-Size="11px" runat="server" Width="100%">
            </asp:DropDownList>--%>
            
            <asp:RadioButton ID="Rdb_DetailStatement" Text="Detail Statement Of Services" runat="server" />
            <asp:RadioButton ID="Service_Summary" Checked="true" Text="Services Summary" runat="server" />
           
         </td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>
            From:
            <asp:TextBox ID="txtFrom" runat="server" CssClass="field" Width="30%"></asp:TextBox>
            To:
            <asp:TextBox ID="txtTo" runat="server" CssClass="field" Width="30%"></asp:TextBox></td>
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
        <td style="width:30%"></td>
        <td style="width:10%"></td>
        <td style="width:20%"></td>
        <td style="width:10%"></td>
        <td style="width:10%"></td>
        <td style="width:5%"></td>
    </tr>
</table>

</asp:Content>

