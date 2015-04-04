<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmbrtestrpt.aspx.cs" Inherits="Report_wfrmbrtestrpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">
        Branch wiseTest booking Report</div>

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
        <cc1:CalendarExtender ID="cal_to" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtto" TargetControlID="txtto"></cc1:CalendarExtender> 
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
                OnClick="imgReport_Click" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" /></td>
        <td>
        
    </tr>
    </table>

    <table width="99%">
   
  
    <tr>
        <td></td>
        <td>From Date:</td>
        <td>
            
            <asp:TextBox ID="txtFrom" runat="server" CssClass="field" Width="30%"></asp:TextBox>
            </td>
        <td>
        To Date:
            
           
        </td>
        <td><asp:TextBox ID="txtto" runat="server" CssClass="field" Width="30%"></asp:TextBox></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td>Branch:</td>
        <td> 
                
            <asp:DropDownList ID="ddlBranch" Font-Size="12px" Height="30px" runat="server" Width="100%">
            </asp:DropDownList>
            
        
        </td>
        <td>Sub-department</td>
        <td> 
                
            <asp:DropDownList ID="ddlsubdep" Font-Size="12px" Height="30px" runat="server" Width="100%">
            </asp:DropDownList>
            
        
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

