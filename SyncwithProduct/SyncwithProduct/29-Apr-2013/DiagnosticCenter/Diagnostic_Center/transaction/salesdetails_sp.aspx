<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="salesdetails_sp.aspx.cs" Inherits="transaction_salesdetails_sp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellpadding="1" cellspacing="1" border="0" width="100%" >
    <tr>
        <td>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc1:CalendarExtender ID="cal_from" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFrom" TargetControlID="txtFrom"></cc1:CalendarExtender> 
            <cc1:CalendarExtender ID="cal_to" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtTo" TargetControlID="txtTo"></cc1:CalendarExtender>
        </td>
    </tr>
</table>

<br /><br />
<fieldset style="border-radius:12px; border:2px solid #CCCCCC;">
<legend style="font-size:10px;">Selection Parameters</legend>
        <table width="100%">
        <tr>
        <td align="right"> <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                OnClick="imgReport_Click" />
                <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif"
                    OnClick="imgClear_Click" />
                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" /></td>
        
        </tr>
        </table>
        
    <table id="main" class="label" width="100%" style="font-size:10px;">
    
    <tr>
       <td colspan="8">&nbsp;</td>
    </tr>
    <tr>
    <td>
    </td>
    <td align="right">
    Branch:
    </td>
    <td colspan="2"> 
                
            <asp:DropDownList ID="ddlBranch" Font-Size="11px" runat="server" Width="100%">
            </asp:DropDownList>
            
        
    </td>
    <td>
    <asp:RadioButtonList Visible="false" ID="rdbType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="A">All</asp:ListItem>
                <asp:ListItem Value="I">Indoor</asp:ListItem>
                <asp:ListItem Value="O">Outdoor</asp:ListItem>
            </asp:RadioButtonList>
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
        <td align="right">
            Panel:</td>
        <td colspan="2">
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

    <td align="right" colspan="2">
    <table width="100%" style="display:none" id="tblIndoor" runat="server">
    <tr>
    <td width="50%" align="right"> Lab ID.</td>
    <td width="50%" align="left"><asp:TextBox ID="txtlabid" Font-Size="10px" CssClass="field" runat="server" width="80%"></asp:TextBox></td>
    </tr>
    </table>
   </td>
    <td>
        
    </td>
    </tr>
    <tr>
        <td></td>
        <td align="right">
            <%--PR NO:--%></td>
        <td>
            <asp:TextBox ID="txtPrNo" Font-Size="10px" Visible="false" runat="server" CssClass="field" Width="65%"></asp:TextBox></td>
        <td align="right">
            From:</td>
        <td>
            &nbsp;<asp:TextBox Font-Size="10px" ID="txtFrom" runat="server" CssClass="field" Width="40%"></asp:TextBox>
            To:
            <asp:TextBox ID="txtTo" Font-Size="10px" runat="server" CssClass="field" Width="40%"></asp:TextBox></td>
        <td colspan="2">
            </td>
        <td></td>
    </tr>
    <tr>
    <td width="5%"></td>
    <td width="15%"></td>
    <td width="15%"></td>
    <td width="15%"></td>
    <td width="20%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    </tr>
    </table>
    </fieldset>
</asp:Content>