<%@ Page Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="~/transaction/wfrmDispatch.aspx.cs" Inherits="Dispatch" Title="Result Dispatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">

 function filtertext(term, _id, cellNr) {
          //  alert("I am called");
     var suche = term.value.toLowerCase();
    // alert(suche.toString());
       // var x = document.getElementById(_id);
      //  alert(x);
        var table = document.getElementById(_id);
       //alert(_id);
        var ele;
        for (var r = 1; r < table.rows.length; r++) {
            ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
            
            if (ele.toLowerCase().indexOf(suche) >= 0)
                table.rows[r].style.display = '';
            else table.rows[r].style.display = 'none';

            //      alert(table.rows[1].cells[1].innerHTML.toString());
        }
    }
    </script>
    <div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;"> Report Delivery And Tracking</div>
<table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">

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
                OnClick="imgSearch_Click" /><asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                OnClick="imgReport_Click" Visible=false /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif"
                    OnClick="imgClear_Click" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" /></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td colspan="6">
            <asp:UpdatePanel id="up_pinfo" runat="Server"><ContentTemplate>
<asp:Panel id="pnl_P_info" runat="Server" GroupingText="Patient Info" Width="99%"><TABLE id="tb_p_info" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Lab ID:</TD><TD><asp:TextBox id="txtLabID" runat="server" Width="50%" CssClass="fieldheading"></asp:TextBox> <asp:ImageButton id="imgLab" onclick="imgLab_Click" runat="server" ImageUrl="~/images/btn_Blank.GIF"></asp:ImageButton></TD><TD align=center>PR No:</TD><TD><asp:TextBox id="txtPRNO" runat="server" Width="50%" CssClass="fieldheading"></asp:TextBox> <asp:ImageButton id="imgPRNo" onclick="imgPRNo_Click" runat="server" ImageUrl="~/images/btn_Blank.GIF"></asp:ImageButton></TD><TD>Name:</TD><TD><asp:TextBox id="txtPatientName" runat="server" Width="98%" CssClass="field"></asp:TextBox></TD></TR><TR><TD>Gender:</TD><TD><asp:RadioButtonList id="rdbGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="M">Male</asp:ListItem>
                                <asp:ListItem Value="F">Female</asp:ListItem>
                            </asp:RadioButtonList> &nbsp; Age:<asp:TextBox id="txtAge" runat="server" Width="30%" CssClass="field"></asp:TextBox></TD><TD align=center>Cell No:</TD><TD><asp:TextBox id="txtCellNo" runat="server" CssClass="field"></asp:TextBox></TD><TD>Phone #:</TD><TD><asp:TextBox id="txtPhoneNo" runat="server" CssClass="field"></asp:TextBox></TD></TR><TR><TD>Ref. No:</TD><TD><asp:TextBox id="txtRefernce" runat="server" Width="98%" CssClass="field" __designer:wfdid="w1" MaxLength="25"></asp:TextBox></TD><TD align=center>Type:</TD><TD>
                            <asp:DropDownList id="ddlType" runat="server" designer:wfdid="w5"><asp:ListItem Value="A">All</asp:ListItem>
<asp:ListItem Value="O">OutDoor</asp:ListItem>
<asp:ListItem Value="I">Indoor</asp:ListItem>
</asp:DropDownList></TD><TD></TD><TD><asp:RadioButtonList id="rdbPatientOption" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rdbPatientOption_SelectedIndexChanged">
                <asp:ListItem Value="C">Cash</asp:ListItem>
                <asp:ListItem Value="P">Panel</asp:ListItem>
            </asp:RadioButtonList></TD></TR><TR><TD>Ward:</TD><TD><asp:DropDownList id="ddlWard" runat="server" Width="99%" __designer:wfdid="w1" CssClass="dropdown"></asp:DropDownList></TD><TD align=center>Adm #:</TD><TD><asp:TextBox id="txtAdmno" runat="server" Width="90%" CssClass="field" __designer:wfdid="w2"></asp:TextBox></TD><TD></TD><TD></TD></TR><TR><TD>From:</TD><TD><asp:TextBox id="txtFromDate" runat="server" Width="40%" CssClass="field"></asp:TextBox>&nbsp;To:<asp:TextBox id="txtToDate" runat="server" Width="40%" CssClass="field"></asp:TextBox></TD><TD align=center></TD><TD colSpan=3><asp:LinkButton id="lbtnThreeDay" onclick="lbtnThreeDay_Click" runat="server" __designer:wfdid="w1">Three Days</asp:LinkButton> <asp:LinkButton id="lbtnWeek" onclick="lbtnWeek_Click" runat="server" __designer:wfdid="w2">One Week</asp:LinkButton> <asp:LinkButton id="lbtnMonth" onclick="lbtnMonth_Click" runat="server" __designer:wfdid="w3">One Month</asp:LinkButton> <asp:LinkButton id="lbtnReporting" onclick="lbtnReporting_Click" runat="server" ForeColor="Blue" __designer:wfdid="w4">Ready For Dispatch</asp:LinkButton></TD></TR><TR><TD></TD><TD><cc1:CalendarExtender id="cal_frm" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate"></cc1:CalendarExtender><cc1:CalendarExtender id="cal_To" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></cc1:CalendarExtender><cc1:MaskedEditExtender id="mask_ToDate" runat="server" TargetControlID="txtToDate" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99/99/9999"></cc1:MaskedEditExtender><cc1:MaskedEditExtender id="mask_FrmDate" runat="server" TargetControlID="txtFromDate" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99/99/9999"></cc1:MaskedEditExtender><cc1:MaskedEditExtender id="mask_prno" runat="server" TargetControlID="txtPRNO" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="999-99-99999999"></cc1:MaskedEditExtender><cc1:MaskedEditExtender id="mask_Labid" runat="server" TargetControlID="txtLabID" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99-999-99999999"></cc1:MaskedEditExtender></TD><TD></TD><TD></TD><TD></TD><TD></TD></TR><TR><TD width="10%"></TD><TD width="20%"></TD><TD width="10%"></TD><TD width="20%"></TD><TD width="10%"></TD><TD width="20%"></TD></TR></TBODY></TABLE></asp:Panel> 
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
<asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:wfdid="w1" DisplayAfter="0"><ProgressTemplate>
<DIV class="UpdateProgress"><asp:Image id="Image1" runat="server" ImageUrl="../images/loading.gif" __designer:wfdid="w2"></asp:Image> ........Loading! Please Wait </DIV>
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
<asp:AsyncPostBackTrigger ControlID="imgReport" EventName="Click"></asp:AsyncPostBackTrigger>
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
<asp:CheckBoxList id="chkProcess" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" __designer:wfdid="w1">
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
<asp:LinkButton id="lbtntest" runat="server" __designer:wfdid="w19"></asp:LinkButton><cc1:ModalPopupExtender id="mde_intcmt" runat="server" __designer:wfdid="w20" TargetControlID="lbtntest" CancelControlID="imgCmt_Close" BackgroundCssClass="TransparentGrayBackground" DropShadow="true" PopupControlID="pnlInt_cmmnt" X="300" Y="100">
               </cc1:ModalPopupExtender> <asp:Panel id="pnlInt_cmmnt" runat="server" Width="500px" CssClass="mPopup" __designer:wfdid="w31" ScrollBars="Vertical" Height="420px"><TABLE id="tb_cpy" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD align=center colSpan=4><STRONG>Internal Comment</STRONG></TD></TR><TR><TD align=center colSpan=4><asp:Label id="lblTest_intCmt" runat="server" Font-Bold="True" __designer:wfdid="w32"></asp:Label></TD></TR><TR><TD align=right><asp:Label id="lblInt_testID" runat="server" Visible="False" __designer:wfdid="w33"></asp:Label>&nbsp; </TD><TD align=right colSpan=3><asp:Label id="lblInt_BookingID" runat="server" Visible="False" __designer:wfdid="w34"></asp:Label> <asp:Label id="lblInt_Index" runat="server" Visible="False" __designer:wfdid="w35"></asp:Label> <asp:ImageButton id="imgcmt_save" onclick="imgcmt_save_Click" runat="server" ImageUrl="~/images/SavePack_2.gif" __designer:wfdid="w36"></asp:ImageButton><asp:ImageButton id="imgCmt_Close" runat="server" ImageUrl="~/images/ClosePack.gif" __designer:wfdid="w37"></asp:ImageButton>&nbsp;</TD></TR><TR><TD align=left colSpan=4><asp:Panel id="pnlW2" runat="server" Font-Bold="True" Width="30%" __designer:wfdid="w38" Height="22px" ToolTip="Click here to add comment"><asp:Image id="imgW" runat="server" ImageUrl="~/images/expandw.jpg" __designer:wfdid="w39"></asp:Image>&nbsp; Add comment</asp:Panel> </TD></TR><TR><TD colSpan=4><asp:UpdatePanel id="up_ur" runat="server" __designer:wfdid="w40"><ContentTemplate>
<asp:Panel id="pnl_ad_Cmt" runat="server" Width="99%" __designer:wfdid="w41"><TABLE id="tb_ad" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Stage:<cc1:CollapsiblePanelExtender id="cpeWaiting" runat="server" __designer:wfdid="w42" TargetControlID="pnl_ad_Cmt" SuppressPostBack="true" ImageControlID="imgW" ExpandedText="Hide Details..." ExpandedImage="../images/collapsew.jpg" ExpandControlID="pnlW2" CollapsedText="Show details..." CollapsedImage="../images/expandw.jpg" CollapseControlID="pnlW2" AutoCollapse="false">
                </cc1:CollapsiblePanelExtender> </TD><TD><asp:DropDownList id="ddlFor_Process" runat="server" Width="98%" CssClass="dropdown" __designer:wfdid="w43">
                                </asp:DropDownList></TD></TR><TR><TD vAlign=top>Comment:</TD><TD><asp:TextBox id="txtInt_Comnt" runat="server" Width="98%" CssClass="field" MaxLength="500" __designer:wfdid="w44" Height="87px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20%"></TD><TD style="WIDTH: 80%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR><TD colSpan=4><asp:GridView id="gvIntComment" runat="server" CssClass="datagrid" __designer:wfdid="w45" AutoGenerateColumns="False">
                                    <RowStyle CssClass="gridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                                :
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="description" HeaderText="Comment">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="55%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="enteredby" HeaderText="Entered By">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="enteredon" HeaderText="Entered On">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="gridheader" />
                                    <AlternatingRowStyle CssClass="gridAlternate" />
                                </asp:GridView> </TD></TR><TR><TD colSpan=4></TD></TR><TR><TD width="25%"></TD><TD width="25%"></TD><TD width="25%"></TD><TD width="25%"></TD></TR></TBODY></TABLE></asp:Panel><BR />
<asp:GridView id="gvResult" runat="server" Width="98%" CssClass="datagrid" OnSorting="gvResult_Sorting" AllowSorting="True" OnRowCommand="gvResult_RowCommand" AutoGenerateColumns="False" DataKeyNames="prid,bookingid,testid,processid,provisionrpt,bookingdid,payment_mode,TestType,labid,prno,subdepartmentId" OnRowDataBound="gvResult_RowDataBound">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sel"><ItemTemplate>
                            <asp:CheckBox ID="chkGVSelect" runat="server" AutoPostBack="True" OnCheckedChanged="chkGVSelect_CheckedChanged" />
                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
</asp:TemplateField>
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
<asp:BoundField DataField="ind_out" HeaderText="Type" SortExpression="ind_out">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
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
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
</asp:BoundField>
<asp:ButtonField CommandName="Print" Text="Print" Visible="false" HeaderText="Print">
<ItemStyle HorizontalAlign="Left" Width="2%"></ItemStyle>
</asp:ButtonField>

<asp:TemplateField>
    <ItemTemplate>
        <asp:HyperLink  ID="Hyper_Pay" runat="server">
            <asp:Image ID="Img_print" ToolTip="Report is ready" Visible="true" ImageUrl="headerfooter/pdf.png" runat="server" />
        </asp:HyperLink>
        <asp:Image ID="Img_cprint" ToolTip="Report is not ready yet" Visible="false" ImageUrl="headerfooter/cpdf.png" runat="server" />
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField>
    <ItemTemplate>
        <asp:HyperLink  ID="Hyper_PayAll" runat="server">
            <asp:Image ID="Img_printAll" ToolTip="Report is ready print all test" Visible="true" ImageUrl="../images/PrintAll.gif" runat="server" />
        </asp:HyperLink>
        <asp:Image ID="Img_cprintAll" ToolTip="Report is not ready yet" Visible="false" ImageUrl="headerfooter/cpdf.png" runat="server" />
    </ItemTemplate>
</asp:TemplateField>

<asp:ButtonField CommandName="Print All" Text="Print All" Visible="false" HeaderText="Print All">
<ItemStyle HorizontalAlign="Left" Width="6%"></ItemStyle>
</asp:ButtonField>
<asp:CommandField SelectText="&lt;img src='../images/comment_add.png' border='0' /&gt;" Visible="false" ShowSelectButton="True">
<ItemStyle Width="3%"></ItemStyle>
</asp:CommandField>
</Columns>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> 
</ContentTemplate>
             <triggers>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgLab" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgPRNo" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgReport" EventName="Click"></asp:AsyncPostBackTrigger>
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
        <td colspan="8">
       
        
        <div id="divExternal" runat="server">
        <fieldset>
        <legend>Others</legend>
        Filter:<input id="fill" type="text" class="field" onkeyup="filtertext(this,'<%=gvExternal.ClientID%>',2)" />
         <asp:UpdatePanel ID="updteExternal" runat="server">
        <ContentTemplate>
        <asp:Panel ID="pnlExternal1" Height="300px" ScrollBars="Auto" runat="server">
        <asp:GridView ID="gvExternal" runat="server" Width="99%"
        CssClass="datagrid" AllowSorting="True" OnSorting="gvExternal_Sorting"
         OnRowCommand="gvExternal_RowCommand" AutoGenerateColumns="False" 
         DataKeyNames="prid,bookingid,testid,processid,provisionrpt,bookingdid,payment_mode,TestType,labid,prno,subdepartmentId" 
         OnRowDataBound="gvExternal_RowDataBound">
        <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
        <RowStyle CssClass="gridItem" />
        <AlternatingRowStyle CssClass="gridAlternate" /> 
      <Columns>
<asp:TemplateField HeaderText="Sel"><ItemTemplate>
                            <asp:CheckBox ID="chkGVExSelect" runat="server" AutoPostBack="True" OnCheckedChanged="chkGVExSelect_CheckedChanged" />
                        
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
</asp:TemplateField>
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
<asp:BoundField DataField="ind_out" HeaderText="Type" SortExpression="ind_out">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
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
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
</asp:BoundField>
<asp:ButtonField CommandName="Print" Text="Print" HeaderText="Print">
<ItemStyle HorizontalAlign="Left" Width="2%"></ItemStyle>
</asp:ButtonField>


<asp:TemplateField>
    <ItemTemplate>
        <asp:HyperLink  ID="Hyper_Pay2" runat="server">
            <asp:Image ID="Img_print2" ToolTip="Report is ready" Visible="true" ImageUrl="headerfooter/pdf.png" runat="server" />
        </asp:HyperLink>
        <asp:Image ID="Img_cprint2" ToolTip="Report is not ready yet" Visible="false" ImageUrl="headerfooter/cpdf.png" runat="server" />        
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField>
    <ItemTemplate>
        <asp:HyperLink  ID="Hyper_PayAll2" runat="server">
            <asp:Image ID="Img_printAll2" ToolTip="Report is ready print all test" Visible="true" ImageUrl="../images/PrintAll.gif" runat="server" />
        </asp:HyperLink>
        <asp:Image ID="Img_cprintAll2" ToolTip="Report is not ready yet" Visible="false" ImageUrl="headerfooter/cpdf.png" runat="server" />
    </ItemTemplate>
</asp:TemplateField>


<asp:ButtonField CommandName="Print All" Text="Print All" HeaderText="Print All">
<ItemStyle HorizontalAlign="Left" Width="6%"></ItemStyle>
</asp:ButtonField>
<asp:CommandField SelectText="&lt;img src='../images/comment_add.png' border='0' /&gt;" ShowSelectButton="True">
<ItemStyle Width="3%"></ItemStyle>
</asp:CommandField>
</Columns>
        </asp:GridView>
        </asp:Panel>
                </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgLab" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgPRNo" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgReport" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnMonth" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnReporting" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="lbtnWeek" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbPatientOption" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
        </Triggers>
        </asp:UpdatePanel>
        </fieldset>
        </div>

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

</asp:Content>

