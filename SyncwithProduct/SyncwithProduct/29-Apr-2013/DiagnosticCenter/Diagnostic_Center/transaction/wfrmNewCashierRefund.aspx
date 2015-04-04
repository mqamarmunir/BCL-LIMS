<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmNewCashierRefund.aspx.cs" Inherits="transaction_wfrmNewCashierRefund" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="javascript" type="text/javascript">

<!--

     function GetValue() {

         var label = document.getElementById("<%=lblPaid.ClientID%>");
         var textbox = document.getElementById("<%=txtDiscount.ClientID%>");
         var z;
         var total;
         if (parseInt(textbox.value) > 100) {
             alert('Please enter discount percentage less than or equal to 100');
         }
         else if (textbox.value != "") {
             z = (parseInt(textbox.value) * parseInt(label.innerText)) / (100);
             total = z;
             document.getElementById("<%=lblRefunded.ClientID%>").innerText = "Refund:" + Math.round(total);
         }
         else
             document.getElementById("<%=lblRefunded.ClientID%>").innerText = "Refund:" + label.innerText;

     }

//-->

</script>


<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">

      
                            <ContentTemplate>
                             <div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;"> Cash Refund Queue</div>
<TABLE id="main" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0>

     <tbody>
         <%--<tr>
             <td align="center" class="tdheading" colspan="8">
                 Cash Refund Queue</td>
         </tr>--%>
         <tr>
             <td>
             </td>
             <td colspan="4">
                 <cc1:MaskedEditExtender ID="mas_paid" runat="server" AutoComplete="false" 
                     ClearMaskOnLostFocus="false" Mask="R999-99-9999999" TargetControlID="txtPaid">
                 </cc1:MaskedEditExtender>
                 <cc1:MaskedEditExtender ID="mas_labid" runat="server" AutoComplete="false" 
                     ClearMaskOnLostFocus="false" Mask="99-999-99999999" TargetControlID="txtLab">
                 </cc1:MaskedEditExtender>
                 <cc1:MaskedEditExtender ID="mas_prno" runat="server" AutoComplete="false" 
                     ClearMaskOnLostFocus="false" Mask="999-99-99999999" TargetControlID="txtPRno">
                 </cc1:MaskedEditExtender>
                 <asp:Label ID="lblTotal" runat="server" Visible="false" Font-Bold="True" ForeColor="DarkBlue"></asp:Label>
             </td>
             <td colspan="2">
                 &nbsp;<cc1:CalendarExtender ID="cal_from" runat="server" Format="dd/MM/yyyy" 
                     PopupButtonID="imgCal_From" TargetControlID="txtCal_From">
                 </cc1:CalendarExtender>
                 <cc1:CalendarExtender ID="cal_To" runat="Server" Format="dd/MM/yyyy" 
                     PopupButtonID="imgCal_To" TargetControlID="txtCal_To">
                 </cc1:CalendarExtender>
                 <cc1:MaskedEditExtender ID="mas_from" runat="server" AutoComplete="False" 
                     ClearMaskOnLostFocus="false" Mask="99/99/9999" TargetControlID="txtCal_From">
                 </cc1:MaskedEditExtender>
                 <cc1:MaskedEditExtender ID="mas_to" runat="server" AutoComplete="false" 
                     ClearMaskOnLostFocus="false" Mask="99/99/9999" TargetControlID="txtCal_To">
                 </cc1:MaskedEditExtender>
             </td>
             <td>
             </td>
         </tr>
         <tr>
             <td>
             </td>
             <td colspan="2">
                 <asp:Label ID="lblCount" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label>
             </td>
             <td>
             </td>
             <td>
             </td>
             <td colspan="2">
                 <asp:ImageButton ID="imgSearch" runat="server" 
                     ImageUrl="~/images/Search_OT.gif" onclick="imgSearch_Click" />
                 <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" 
                     onclick="imgClear_Click" />
                 <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" 
                     onclick="imgClose_Click" />
                 &nbsp;
                 <%--<asp:ImageButton ID="ImageButton1" runat="server" 
                     ImageUrl="~/transaction/headerfooter/attachment.png" 
                     onclick="ImageButton1_Click" />--%>
             </td>
             <td>
             </td>
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
             </td>
             <td>
             </td>
         </tr>
         <tr>
             <td>
             </td>
             <td colspan="6">
                 <asp:Panel ID="pnl_search" runat="server" BorderWidth="1px" Width="99%">
                     <table id="tb_search" border="0" cellpadding="1" cellspacing="1" class="label" 
                         width="100%">
                         <tbody>
                             <tr>
                                 <td>
                                     Paid No:</td>
                                 <td>
                                     <asp:TextBox ID="txtPaid" runat="server" CssClass="txtareaStyle" Width="55%"></asp:TextBox>
                                 </td>
                                 <td>
                                     Lab ID:</td>
                                 <td>
                                     <asp:TextBox ID="txtLab" runat="server" CssClass="txtareaStyle" Width="55%"></asp:TextBox>
                                 </td>
                                 <td>
                                     From Date:</td>
                                 <td>
                                     <asp:TextBox ID="txtCal_From" runat="server" CssClass="txtareaStyle" 
                                         Width="50%"></asp:TextBox>
                                     <asp:ImageButton ID="imgCal_From" runat="server" 
                                         ImageUrl="~/images/btn_Blank.GIF" />
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     PR No:</td>
                                 <td>
                                     <asp:TextBox ID="txtPRno" runat="server" CssClass="txtareaStyle" Width="55%"></asp:TextBox>
                                 </td>
                                 <td>
                                     Name:</td>
                                 <td>
                                     <asp:TextBox ID="txtName" runat="server" CssClass="txtareaStyle" Width="98%"></asp:TextBox>
                                 </td>
                                 <td>
                                     To Date:</td>
                                 <td>
                                     <asp:TextBox ID="txtCal_To" runat="server" CssClass="txtareaStyle" Width="50%"></asp:TextBox>
                                     <asp:ImageButton ID="imgCal_To" runat="server" 
                                         ImageUrl="~/images/btn_Blank.GIF" />
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                 </td>
                                 <td>
                                     <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" 
                                         CssClass="dropdown" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" 
                                         Visible="False" Width="99%">
                                     </asp:DropDownList>
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
                                 <td width="10%">
                                 </td>
                                 <td width="25%">
                                 </td>
                                 <td width="10%">
                                 </td>
                                 <td width="25%">
                                 </td>
                                 <td width="10%">
                                 </td>
                                 <td width="20%">
                                 </td>
                             </tr>
                         </tbody>
                     </table>
                 </asp:Panel>
             </td>
             <td>
             </td>
         </tr>
         <tr>
             <td>
             </td>
             <td colspan="6">
                 <asp:Panel ID="pnl_Save" runat="server" BorderWidth="1px" Width="99%">
                     <table id="tb_save" border="0" cellpadding="1" cellspacing="1" class="label" 
                         width="100%">
                         <tbody>
                             <tr>
                                 <td colspan="4">
                                     <asp:Label ID="lblError" runat="server"></asp:Label>
                                 </td>
                                 <td colspan="2">
                                     <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" 
                                         onclick="imgSave_Click" />
                                     <asp:ImageButton ID="imgPnl_Close" runat="server" 
                                         ImageUrl="~/images/ClosePack.gif" onclick="imgPnl_Close_Click" />
                                 </td>
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
                             </tr>
                             <tr>
                                 <td>
                                     Paid No:</td>
                                 <td>
                                     <asp:Label ID="lblPaidno" runat="server" ForeColor="DarkBlue"></asp:Label>
                                 </td>
                                 <td>
                                     Lab ID:</td>
                                 <td>
                                     <asp:Label ID="lblLabID" runat="server" ForeColor="DarkBlue"></asp:Label>
                                 </td>
                                 <td>
                                     <asp:Label ID="lblBal_Head" runat="server"></asp:Label>
                                 </td>
                                 <td>
                                     <asp:Label ID="lblPaid" runat="server" ForeColor="DarkBlue"></asp:Label>
                                     <asp:Label ID="lblBalance" runat="server" ForeColor="DarkBlue"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     PR No:</td>
                                 <td>
                                     <asp:Label ID="lblPRno" runat="server" ForeColor="DarkBlue"></asp:Label>
                                 </td>
                                 <td>
                                     Patient:</td>
                                 <td>
                                     <asp:Label ID="lblPatient" runat="server" ForeColor="DarkBlue"></asp:Label>
                                 </td>
                                 <td>
                                     Refund Type:</td>
                                 <td>
                                     <asp:DropDownList ID="ddlRefundType" runat="server" CssClass="dropdown" 
                                         OnSelectedIndexChanged="ddlRefundType_SelectedIndexChanged">
                                         <asp:ListItem Value="C">Booking Cancel</asp:ListItem>
                                         <%--<asp:ListItem Value="D">Discount</asp:ListItem>
                                         <asp:ListItem Value="B">Business</asp:ListItem>--%>
                                     </asp:DropDownList>
                                 </td>
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
                                     <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="txtDiscount" runat="server" CssClass="txtareaStyle" 
                                         MaxLength="3" onkeyup="GetValue()" ToolTip="Please enter discount percentage" 
                                         Width="30%"></asp:TextBox>
                                     <asp:Label ID="lblRefunded" runat="server" ForeColor="DarkBlue"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     Authorized:</td>
                                 <td class="mandatoryField">
                                     <asp:DropDownList ID="ddlAuthorized" runat="server" CssClass="dropdown" 
                                         Width="100%">
                                     </asp:DropDownList>
                                 </td>
                                 <td>
                                     Reason:</td>
                                 <td colspan="3" rowspan="2" valign="top">
                                     <asp:TextBox ID="txtComment" runat="server" CssClass="txtareaStyle" 
                                         TextMode="MultiLine" Width="99%"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                 </td>
                                 <td>
                                 </td>
                                 <td>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="6">
                                     <asp:GridView ID="gvTest" Width="100%" runat="server" AutoGenerateColumns="False" 
                                         CssClass="listing" 
                                         DataKeyNames="bookingid,prid,testid,classificationid,bookingdid,payment_mode">
                                         <RowStyle CssClass="gridItem" />
                                         <Columns>
                                             <asp:TemplateField HeaderText="S.No">
                                                 <HeaderStyle HorizontalAlign="Right" />
                                                 <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>:
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:BoundField DataField="testname" HeaderText="Test">
                                                 <HeaderStyle HorizontalAlign="Left" />
                                                 <ItemStyle HorizontalAlign="Left" Width="50%" />
                                             </asp:BoundField>
                                         <asp:BoundField DataField="charges2" HeaderText="Actual Charges">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="charges" HeaderText="Discounted Charges">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" Width="20%" />
                                        </asp:BoundField>
                                             <asp:TemplateField HeaderText="Refund Amount">
                                                 <ItemTemplate>
                                                     <asp:TextBox ID="txtGVRefund" runat="server" CssClass="field"></asp:TextBox>
                                                     <cc1:FilteredTextBoxExtender ID="flt_amt" runat="server" FilterType="numbers" 
                                                         TargetControlID="txtGVRefund">
                                                     </cc1:FilteredTextBoxExtender>
                                                 </ItemTemplate>
                                                 <ItemStyle Width="20%" />
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Select">
                                                 <ItemTemplate>
                                                     <asp:CheckBox ID="chkTestSel" runat="server" AutoPostBack="True" 
                                                         OnCheckedChanged="chkTestSel_CheckedChanged" />
                                                 </ItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" Width="5%" />
                                             </asp:TemplateField>
                                         </Columns>
                                         <HeaderStyle CssClass="gridheader" />
                                         <AlternatingRowStyle CssClass="AltRow" />
                                     </asp:GridView>
                                 </td>
                                 <td>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="6">
                                     <strong><span style="FONT-SIZE: 11pt">Payment Summary:<BR /></span>Total:</strong>
                                     <asp:Label ID="lblTotalCharges" runat="server" __designer:wfdid="w1" 
                                         ForeColor="DarkBlue"></asp:Label>
                                     <strong>Paid:</strong>
                                     <asp:Label ID="lblTotalPaid" runat="server" __designer:wfdid="w1" 
                                         ForeColor="DarkBlue"></asp:Label>
                                     <strong>Discount:</strong>
                                     <asp:Label ID="lblTotalDiscount" runat="server" __designer:wfdid="w2" 
                                         ForeColor="DarkBlue"></asp:Label>
                                     <strong>Refund:</strong>&nbsp;
                                     <asp:Label ID="lblRefundAmt" runat="server" ForeColor="DarkBlue"></asp:Label>
                                     &nbsp;<strong>Balance:</strong>
                                     <asp:Label ID="lblBal" runat="server" __designer:wfdid="w1" 
                                         ForeColor="DarkBlue"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="6">
                                     <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" 
                                         CssClass="listing" Width="76%">
                                         <RowStyle CssClass="gridItem" />
                                         <Columns>
                                             <asp:TemplateField HeaderText="S.No">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>:
                                                 </ItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Right" />
                                                 <ItemStyle HorizontalAlign="Right" Width="5%" />
                                             </asp:TemplateField>
                                             <asp:BoundField DataField="refundno" HeaderText="Refund No">
                                                 <HeaderStyle HorizontalAlign="Left" />
                                                 <ItemStyle HorizontalAlign="Left" Width="25%" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="test_name" HeaderText="Test">
                                                 <HeaderStyle HorizontalAlign="Left" />
                                                 <ItemStyle HorizontalAlign="Left" Width="40%" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="Totalamount" HeaderText="Total Amt">
                                                 <HeaderStyle HorizontalAlign="Right" />
                                                 <ItemStyle HorizontalAlign="Right" Width="15%" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="paidamount" HeaderText="Refund Amt">
                                                 <HeaderStyle HorizontalAlign="Right" />
                                                 <ItemStyle HorizontalAlign="Right" Width="15%" />
                                             </asp:BoundField>
                                         </Columns>
                                         <HeaderStyle CssClass="gridheader" />
                                         <AlternatingRowStyle CssClass="AltRow" />
                                     </asp:GridView>
                                 </td>
                             </tr>
                             <tr>
                                 <td width="10%">
                                 </td>
                                 <td width="25%">
                                 </td>
                                 <td width="8%">
                                 </td>
                                 <td width="25%">
                                 </td>
                                 <td width="12%">
                                 </td>
                                 <td width="20%">
                                 </td>
                             </tr>
                         </tbody>
                     </table>
                 </asp:Panel>
             </td>
             <td>
             </td>
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
             </td>
             <td>
             </td>
         </tr>
         <tr>
             <td>
             </td>
             <td colspan="6">
                 <asp:GridView ID="gvRefund" runat="server" AutoGenerateColumns="False" 
                     CssClass="listing" 
                     DataKeyNames="bookingid,prid,totalamount,totaldiscount,balance,totalrefund" 
                     OnRowCommand="gvRefund_RowCommand" onrowdatabound="gvRefund_RowDataBound" 
                     Width="99%">
                     <RowStyle CssClass="gridItem" />
                     <Columns>
                         <asp:TemplateField HeaderText="S.No">
                             <ItemTemplate>
                                 <%#Container.DataItemIndex+1 %>:
                             </ItemTemplate>
                             <HeaderStyle HorizontalAlign="Right" />
                             <ItemStyle Height="5%" HorizontalAlign="Right" />
                         </asp:TemplateField>
                         <asp:BoundField DataField="receiveno" HeaderText="Paid No">
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" Width="12%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="labid" HeaderText="LAB ID">
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" Width="12%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="prno" HeaderText="PR No">
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" Width="12%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="patientname" HeaderText="Patient">
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" Width="20%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="paidamount" HeaderText="Paid Amount">
                             <HeaderStyle HorizontalAlign="Right" />
                             <ItemStyle HorizontalAlign="Right" Width="10%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="receiveon" HeaderText="Received On">
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" Width="19%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="adm_info" HeaderText="Adm Info">
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" Width="15%" />
                         </asp:BoundField>
                         <asp:BoundField DataField="origin" HeaderText="Origin">
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" Width="5%" />
                         </asp:BoundField>
                         <asp:CommandField ShowSelectButton="True">
                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                         </asp:CommandField>
                     </Columns>
                     <HeaderStyle CssClass="gridheader" />
                     <AlternatingRowStyle CssClass="AltRow" />
                 </asp:GridView>
             </td>
             <td>
             </td>
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
             </td>
             <td>
             </td>
         </tr>
         <tr>
             <td width="5%">
             </td>
             <td width="10%">
             </td>
             <td width="20%">
             </td>
             <td width="10%">
             </td>
             <td width="20%">
             </td>
             <td width="10%">
             </td>
             <td width="20%">
             </td>
             <td width="5%">
             </td>
         </tr>
     </tbody>
    </div></TABLE>
</ContentTemplate>
        <Triggers>
                 <asp:PostBackTrigger ControlID="imgSave" />
                  <asp:AsyncPostBackTrigger ControlID="txtName" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

