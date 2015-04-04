<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Report/wfrmIndoor_Sheet.aspx.cs" Inherits="indoor" Title="Indoor Patient Charges Sheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
    <tr>
        <td align="center" class="tdheading" colspan="8">
            Patient Statement</td>
    </tr>
    
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
            <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                OnClick="imgReport_Click" /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif"
                    OnClick="imgClear_Click" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" /></td>
        <td>
        </td>
    </tr>
    <tr>

        <td colspan="8">
            &nbsp;</td>
    </tr>
    <tr>
    <td></td>
    <td align="right">Admission No.</td>
    <td>
        <asp:TextBox ID="txtadmno" CssClass="field" runat="server" width="80%"></asp:TextBox>
    </td>
    </tr>
    <tr>
        <td></td>
        <td align="right">
            PR NO:</td>
        <td>
            <asp:TextBox ID="txtPrNo" runat="server" CssClass="field" Width="65%"></asp:TextBox></td>
        <td align="right">
            From:</td>
        <td>
            &nbsp;<asp:TextBox ID="txtFrom" runat="server" CssClass="field" Width="25%"></asp:TextBox>
            To:
            <asp:TextBox ID="txtTo" runat="server" CssClass="field" Width="25%"></asp:TextBox></td>
        <td colspan="2">
            <asp:RadioButtonList ID="rdbType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="A">All</asp:ListItem>
                <asp:ListItem Value="I">Indoor</asp:ListItem>
                <asp:ListItem Value="O">Outdoor</asp:ListItem>
            </asp:RadioButtonList></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>
            <cc1:MaskedEditExtender ID="mask_prno" runat="server" AutoComplete="false" ClearMaskOnLostFocus="false"
                Mask="999-99-99999999" TargetControlID="txtPrno">
            </cc1:MaskedEditExtender>
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
        <td style="width:15%"></td>
        <td style="width:10%"></td>
        <td style="width:30%"></td>
        <td style="width:10%"></td>
        <td style="width:15%"></td>
        <td style="width:5%"></td>
    </tr>
</table>
</asp:Content>

