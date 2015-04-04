<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTrack.aspx.cs" Inherits="track" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BCL:Patient Investigation Tracking</title>
    <link href="../LIMS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
    <tr>
        <td align="center" class="tdheading" colspan="8">
            Patient Investigation Tracking</td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
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
        <td align="center" colspan="2">
            <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif"
                OnClick="imgSearch_Click" /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif"
                    OnClick="imgClear_Click" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" /></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td colspan="6">
            <asp:UpdatePanel id="up_pinfo" runat="Server"><ContentTemplate>
<asp:Panel id="pnl_P_info" runat="Server" Width="99%" GroupingText="Patient Info"><TABLE id="tb_p_info" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Lab ID:</TD><TD><asp:TextBox id="txtLabID" runat="server" Width="50%" CssClass="fieldheading"></asp:TextBox> <asp:ImageButton id="imgLab" onclick="imgLab_Click" runat="server" ImageUrl="~/images/btn_Blank.GIF"></asp:ImageButton></TD><TD align=center>PR No:</TD><TD><asp:TextBox id="txtPRNO" runat="server" Width="50%" CssClass="fieldheading"></asp:TextBox> <asp:ImageButton id="imgPRNo" onclick="imgPRNo_Click" runat="server" ImageUrl="~/images/btn_Blank.GIF"></asp:ImageButton></TD><TD>Name:</TD><TD><asp:TextBox id="txtPatientName" runat="server" Width="98%" CssClass="field"></asp:TextBox></TD></TR><TR><TD>Gender:</TD><TD><asp:RadioButtonList id="rdbGender" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Value="M">Male</asp:ListItem>
                                <asp:ListItem Value="F">Female</asp:ListItem>
                            </asp:RadioButtonList> &nbsp; Age:<asp:TextBox id="txtAge" runat="server" Width="30%" CssClass="field"></asp:TextBox></TD><TD align=center>Cell No:</TD><TD><asp:TextBox id="txtCellNo" runat="server" CssClass="field"></asp:TextBox></TD><TD>Phone #:</TD><TD><asp:TextBox id="txtPhoneNo" runat="server" CssClass="field"></asp:TextBox></TD></TR><TR><TD>From:</TD><TD><asp:TextBox id="txtFromDate" runat="server" Width="40%" CssClass="field"></asp:TextBox>&nbsp;To:<asp:TextBox id="txtToDate" runat="server" Width="40%" CssClass="field"></asp:TextBox></TD><TD align=center><asp:RadioButtonList id="rdbPatientOption" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbPatientOption_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="C">Cash</asp:ListItem>
                <asp:ListItem Value="P">Panel</asp:ListItem>
            </asp:RadioButtonList></TD><TD colSpan=2><asp:LinkButton id="lbtnThreeDay" onclick="lbtnThreeDay_Click" runat="server">Three Days</asp:LinkButton> <asp:LinkButton id="lbtnWeek" onclick="lbtnWeek_Click" runat="server">One Week</asp:LinkButton> <asp:LinkButton id="lbtnMonth" onclick="lbtnMonth_Click" runat="server">One Month</asp:LinkButton> <asp:LinkButton id="lbtnReporting" onclick="lbtnReporting_Click" runat="server" ForeColor="Blue">Ready For Dispatch</asp:LinkButton>&nbsp; Ref:</TD><TD><asp:TextBox id="txtRefernce" runat="server" Width="98%" CssClass="field" MaxLength="25"></asp:TextBox></TD></TR><TR><TD></TD><TD><cc1:CalendarExtender id="cal_frm" runat="Server" TargetControlID="txtFromDate" PopupButtonID="txtFromDate" Format="dd/MM/yyyy"></cc1:CalendarExtender><cc1:CalendarExtender id="cal_To" runat="Server" TargetControlID="txtToDate" PopupButtonID="txtToDate" Format="dd/MM/yyyy"></cc1:CalendarExtender><cc1:MaskedEditExtender id="mask_ToDate" runat="server" TargetControlID="txtToDate" Mask="99/99/9999" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender><cc1:MaskedEditExtender id="mask_FrmDate" runat="server" TargetControlID="txtFromDate" Mask="99/99/9999" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender><cc1:MaskedEditExtender id="mask_prno" runat="server" TargetControlID="txtPRNO" Mask="999-99-99999999" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender><cc1:MaskedEditExtender id="mask_Labid" runat="server" TargetControlID="txtLabID" Mask="99-999-99999999" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender></TD><TD></TD><TD></TD><TD></TD><TD></TD></TR><TR><TD width="10%"></TD><TD width="20%"></TD><TD width="10%"></TD><TD width="20%"></TD><TD width="10%"></TD><TD width="20%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
          </asp:UpdatePanel>  
        </td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
        <asp:UpdatePanel id="up_prg" runat="server">
                   <contenttemplate>
<asp:UpdateProgress id="UpdateProgress1" runat="server" DisplayAfter="0"><ProgressTemplate>
<DIV class="UpdateProgress"><asp:Image id="Image1" runat="server" ImageUrl="../images/loading.gif"></asp:Image> ........Loading! Please Wait </DIV>
</ProgressTemplate>
</asp:UpdateProgress> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubdepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="gvResult" EventName="RowCommand"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgClose" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgLab" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgPRNo" EventName="Click"></asp:AsyncPostBackTrigger>

<asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnMonth" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnReporting" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnWeek" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbPatientOption" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
          </asp:UpdatePanel>  
            </td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td colspan="6">
           <asp:UpdatePanel id="up_panel" runat="Server"><ContentTemplate>
<asp:Panel id="pnl_Pnl_info" runat="Server" Width="99%" GroupingText="Panel Info"><TABLE id="tb_pnl_info" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Panel:</TD><TD><asp:DropDownList id="ddlPanel" runat="server" Width="99%" CssClass="dropdown">
                            </asp:DropDownList></TD><TD>Employee:</TD><TD><asp:TextBox id="txtEmployeeName" runat="server" Width="98%" CssClass="field"></asp:TextBox></TD><TD>Employee No:</TD><TD><asp:TextBox id="txtEmployeeNo" runat="server" Width="99%" CssClass="field"></asp:TextBox></TD></TR><TR><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD></TR><TR><TD width="10%"></TD><TD width="35%"></TD><TD width="10%"></TD><TD width="20%"></TD><TD width="10%"></TD><TD width="15%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
               <triggers>
<asp:AsyncPostBackTrigger ControlID="rdbPatientOption" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
          </asp:UpdatePanel>  
        </td>
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
        <td colspan="6">
          <asp:UpdatePanel id="up_testInfo" runat="Server"><ContentTemplate>
<asp:Panel id="pnl_Test" runat="Server" Width="99%" GroupingText="Test Info:"><TABLE id="tb_test" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Department:</TD><TD><asp:DropDownList id="ddlDepartment" runat="server" Width="90%" CssClass="dropdown" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList></TD><TD>Sub-Department:</TD><TD><asp:DropDownList id="ddlSubdepartment" runat="server" Width="90%" CssClass="dropdown" OnSelectedIndexChanged="ddlSubdepartment_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList></TD></TR><TR><TD>Group:</TD><TD><asp:DropDownList id="ddlGroup" runat="server" Width="90%" CssClass="dropdown">
                            </asp:DropDownList></TD><TD>Test:</TD><TD><asp:DropDownList id="ddlTest" runat="server" Width="90%" CssClass="dropdown">
                            </asp:DropDownList></TD></TR><TR><TD width="15%"></TD><TD width="35%"></TD><TD width="15%"></TD><TD width="35%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate> 
              <triggers>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
         </asp:UpdatePanel> 
        </td>
        <td></td>
    </tr>
    <tr>
        <td class="screenid" colspan="8">
            &nbsp;</td>
    </tr>
    <tr>
        <td></td>
        <td colspan="6"><asp:UpdatePanel id="up_chkLIst" runat="Server" UpdateMode="Conditional"><ContentTemplate>
<asp:CheckBoxList id="chkProcess" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
            </asp:CheckBoxList> 
</ContentTemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="lbtnReporting" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
            </asp:UpdatePanel>
            </td>
        <td></td>
    </tr>
    <tr>
        
        <td colspan="8" align="center">
         <asp:UpdatePanel id="up_gv" runat="server"><ContentTemplate>
<asp:GridView id="gvResult" runat="server" Width="98%" CssClass="datagrid" OnRowDataBound="gvResult_RowDataBound" DataKeyNames="prid,bookingid,testid,processid,provisionrpt" AutoGenerateColumns="False" OnRowCommand="gvResult_RowCommand" AllowSorting="True" OnSorting="gvResult_Sorting">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="S#"><ItemTemplate>
                            <%#Container.DataItemIndex+1 %>:
                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="2%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="labid" HeaderText="Lab ID" SortExpression="labid">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="patientname" HeaderText="Patient Name" SortExpression="patientname">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="16%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="test_name" HeaderText="Investigation" SortExpression="test_name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="referenceno" HeaderText="Reference No" SortExpression="referenceno">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="9%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="balance" HeaderText="Balance" SortExpression="balance">
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bookedon" HeaderText="Booked On" SortExpression="bookedon">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="deliveryon" HeaderText="Delivery On" SortExpression="deliveryon">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dispatchon" HeaderText="Dispatched On" SortExpression="dispatchon">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:BoundField>
    <asp:BoundField DataField="origin" HeaderText="Origin">
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Left" Width="5%" />
    </asp:BoundField>
</Columns>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> 
</ContentTemplate>
             <triggers>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgLab" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgPRNo" EventName="Click"></asp:AsyncPostBackTrigger>

<asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnMonth" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnReporting" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnWeek" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbPatientOption" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
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
        <td width="5%"></td>
        <td width="10%"></td>
        <td width="20%"></td>
        <td width="10%"></td>
        <td width="20%"></td>
        <td width="10%"></td>
        <td width="20%"></td>
        <td width="5%"></td>
    </tr>
</table>
    </form>
</body>
</html>
