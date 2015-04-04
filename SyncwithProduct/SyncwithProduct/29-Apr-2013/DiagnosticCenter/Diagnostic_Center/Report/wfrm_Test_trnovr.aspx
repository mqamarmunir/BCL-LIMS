<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Report/wfrm_Test_trnovr.aspx.cs" Inherits="test_turnover" Title="Test Turnover Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
    <tr>
        <td align="center" class="tdheading" colspan="8">
            Investigation Turnover
            Summary</td>
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
         <td>
             <asp:RadioButtonList ID="rdbLab" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
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
        <td></td>
        <td>
            Department:</td>
        <td>
            <asp:DropDownList ID="ddlDepartment" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" CssClass="dropdown">
            </asp:DropDownList></td>
        <td>
            Subdepartment:</td>
        <td>
            <asp:DropDownList ID="ddlSubDept" runat="server" AutoPostBack="True" CssClass="dropdown"
                OnSelectedIndexChanged="ddlSubDept_SelectedIndexChanged" Width="100%">
            </asp:DropDownList></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td>
            Group:</td>
        <td>
            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="dropdown" Width="100%">
            </asp:DropDownList></td>
        <td>
            Test:</td>
        <td>
            <asp:DropDownList ID="ddlTest" runat="server" Width="100%" CssClass="dropdown">
            </asp:DropDownList></td>
        <td></td>
        <td></td>
        <td></td>
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

