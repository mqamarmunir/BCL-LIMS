<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Report/wfrmBal_Dis_sumry.aspx.cs" Inherits="bal_dis" Title="Due balance and discount Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
    <tr>
        <td align="center" class="tdheading" colspan="8">
           Balance and Discount Summary</td>
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
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
            <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                OnClick="imgReport_Click" /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif"
                    OnClick="imgClear_Click" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" /></td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="8">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td align="left">
            <asp:RadioButtonList ID="rdbLab" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="A">All</asp:ListItem>
                <asp:ListItem Value="008">AMC</asp:ListItem>
                <asp:ListItem Value="006">BCL</asp:ListItem>
            </asp:RadioButtonList></td>
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
        </td>
        <td align="left">
            <asp:RadioButtonList ID="rdbOption" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Value="B">Due Balance</asp:ListItem>
                <asp:ListItem Value="D">Discount</asp:ListItem>
            </asp:RadioButtonList></td>
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
        </td>
        <td align="left">
            <asp:RadioButtonList ID="rdbType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rdbType_SelectedIndexChanged">
                <asp:ListItem Value="A">All</asp:ListItem>
                <asp:ListItem Value="C">Cash</asp:ListItem>
                <asp:ListItem Value="P">Panel</asp:ListItem>
            </asp:RadioButtonList></td>
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
            <asp:Label ID="lblPanel" runat="server" Text="Panel:"></asp:Label></td>
        <td align="left">
            <asp:DropDownList ID="ddlPanel" runat="server" Width="99%">
            </asp:DropDownList></td>
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
        <td></td>
        <td></td>
        <td>
            From:
            <asp:TextBox ID="txtFrom" runat="server" CssClass="field" Width="25%"></asp:TextBox>
            To:
            <asp:TextBox ID="txtTo" runat="server" CssClass="field" Width="25%"></asp:TextBox></td>
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
        <td style="width:30%"></td>
        <td style="width:5%"></td>
        <td style="width:5%"></td>
        <td style="width:5%"></td>
    </tr>
</table>
</asp:Content>

