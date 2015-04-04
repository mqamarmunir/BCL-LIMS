<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/transaction/wfrmCashRefund_1.aspx.cs" Inherits="cashrefund"  Title="Refund/Discount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript">

<!--

function GetValue()
        {

             var label = document.getElementById("<%=lblBalance.ClientID%>");
             var textbox = document.getElementById("<%=txtDiscount.ClientID%>");             
             var z;
             var total;
             if(parseInt(textbox.value) > 100)
             {
                alert('Please enter discount percentage less than or equal to 100');               
             }
                else if(textbox.value!="")
                 {      
              z = (parseInt(textbox.value) * parseInt(label.innerText)) / (100);
              total =  z;             
              document.getElementById("<%=lblRefunded.ClientID%>").innerText="Refund:"+ Math.round(total);              
              }
              else
                document.getElementById("<%=lblRefunded.ClientID%>").innerText="Refund:"+ label.innerText;  

}

//-->

</script>


<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Cash Refund Queue</td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <cc1:MaskedEditExtender ID="mas_paid" runat="server" AutoComplete="false" ClearMaskOnLostFocus="false"
                 Mask="R999-99-9999999" TargetControlID="txtPaid"></cc1:MaskedEditExtender>
                 <cc1:MaskedEditExtender ID="mas_labid" runat="server" AutoComplete="false" ClearMaskOnLostFocus="false"
                 Mask="99-999-99999999" TargetControlID="txtLab"></cc1:MaskedEditExtender>
                 <cc1:MaskedEditExtender ID="mas_prno" runat="server" AutoComplete="false" ClearMaskOnLostFocus="false"
                 Mask="999-99-99999999" TargetControlID="txtPRno"></cc1:MaskedEditExtender>
                <asp:Label ID="lblTotal" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label></td>
            <td colspan="2">
                &nbsp;<cc1:CalendarExtender ID="cal_from" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgCal_From"
                     TargetControlID="txtCal_From"></cc1:CalendarExtender>
                     <cc1:CalendarExtender ID="cal_To" runat="Server" Format="dd/MM/yyyy" PopupButtonID="imgCal_To"
                     TargetControlID="txtCal_To"></cc1:CalendarExtender>
                     <cc1:MaskedEditExtender ID="mas_from" runat="server" AutoComplete="False" ClearMaskOnLostFocus="false"
                      Mask="99/99/9999" TargetControlID="txtCal_From" ></cc1:MaskedEditExtender>
                      <cc1:MaskedEditExtender runat="server" ID="mas_to" AutoComplete="false" ClearMaskOnLostFocus="false"
                      Mask="99/99/9999" TargetControlID="txtCal_To"></cc1:MaskedEditExtender>                    
                </td>
            <td>
            </td>
        </tr>
         <tr>
            <td></td>
            <td colspan="2">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label></td>
            <td></td>
            <td></td>
            <td colspan="2">
                <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif" OnClick="imgSearch_Click" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
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
                <asp:Panel ID="pnl_search" runat="server" BorderWidth="1px" Width="99%">
                    <table id="tb_search" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                        <tr>
                            <td>
                Paid No:</td>
                            <td>
                <asp:TextBox ID="txtPaid" runat="server" CssClass="field" Width="55%"></asp:TextBox></td>
                            <td>
                Lab ID:</td>
                            <td>
                <asp:TextBox ID="txtLab" runat="server" CssClass="field" Width="55%"></asp:TextBox></td>
                            <td>
                From Date:</td>
                            <td>
                <asp:TextBox ID="txtCal_From" runat="server" CssClass="field" Width="50%"></asp:TextBox>
                <asp:ImageButton ID="imgCal_From" runat="server" ImageUrl="~/images/btn_Blank.GIF" /></td>
                        </tr>
                         <tr>
                            <td>
                PR No:</td>
                            <td>
                <asp:TextBox ID="txtPRno" runat="server" CssClass="field" Width="55%"></asp:TextBox></td>
                            <td>
                Name:</td>
                            <td>
                <asp:TextBox ID="txtName" runat="server" CssClass="field" Width="98%"></asp:TextBox></td>
                            <td>
                To Date:</td>
                            <td>
                <asp:TextBox ID="txtCal_To" runat="server" CssClass="field" Width="50%"></asp:TextBox>
                <asp:ImageButton ID="imgCal_To" runat="server" ImageUrl="~/images/btn_Blank.GIF" /></td>
                        </tr>
                        <tr>
                            <td>
                                Branch:</td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" CssClass="dropdown"
                                    OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="99%">
                                </asp:DropDownList></td>
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
                            <td width="10%"></td>
                            <td width="25%"></td>
                            <td width="10%"></td>
                            <td width="25%"></td>
                            <td width="10%"></td>
                            <td width="20%"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td></td>
        </tr>
        
         <tr>
            <td></td>
            <td colspan="6">
                <asp:Panel ID="pnl_Save" runat="server" BorderWidth="1px" Width="99%">
                    <table id="tb_save" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblError" runat="server"></asp:Label></td>
                            <td colspan="2">
                                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                                    ID="imgPnl_Close" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgPnl_Close_Click" /></td>
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
                                <asp:Label ID="lblPaidno" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                            <td>
                                Lab ID:</td>
                            <td>
                                <asp:Label ID="lblLabID" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblBal_Head" runat="server"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPaid" runat="server" ForeColor="DarkBlue"></asp:Label>
                                <asp:Label ID="lblBalance" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                        </tr>
                         <tr>
                            <td>
                                PR No:</td>
                            <td>
                                <asp:Label ID="lblPRno" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                            <td>
                                Patient:</td>
                            <td>
                                <asp:Label ID="lblPatient" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                            <td>
                                Refund Type:</td>
                            <td>
                                <asp:DropDownList ID="ddlRefundType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRefundType_SelectedIndexChanged" >
                                    <asp:ListItem Value="C">Booking Cancel</asp:ListItem>
                                    <asp:ListItem Value="D">Discount</asp:ListItem>
                                    <asp:ListItem Value="K">BCL Staff</asp:ListItem>
                                    <asp:ListItem Value="R">Poor Patient</asp:ListItem>
                                    <asp:ListItem Value="P">Panel Patient</asp:ListItem>
                                    <asp:ListItem Value="W">Wrong Entry</asp:ListItem>
                                </asp:DropDownList></td>
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
                                <asp:Label ID="lblDiscount" runat="server"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDiscount" runat="server" CssClass="field" MaxLength="3" Width="30%" ToolTip="Please enter discount percentage" onkeyup="GetValue()"></asp:TextBox>
                                <%if (this.ddlRefundType.SelectedItem.Value.ToString().Equals("D"))  { %> % 
                                <asp:Label ID="lblRefunded" runat="server" ForeColor="DarkBlue"></asp:Label><%} %></td>
                        </tr>
                        <tr>
                            <td>
                                Authorized:</td>
                            <td class="mandatoryField">
                                <asp:DropDownList ID="ddlAuthorized" runat="server"  Width="100%">
                                </asp:DropDownList></td>
                            <td>
                                Reason:</td>
                            <td colspan="3" rowspan="2" valign="top">
                                <asp:TextBox ID="txtComment" runat="server" CssClass="mandatoryField" Width="99%" TextMode="MultiLine"></asp:TextBox></td>
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
                            <td colspan="5">
                                <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="bookingid,prid,testid,classificationid,bookingdid">
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
                                        <asp:BoundField DataField="charges" HeaderText="Charges">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" Width="25%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Refund Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtGVRefund" runat="server" CssClass="field"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="flt_amt" runat="server" FilterType="numbers" TargetControlID="txtGVRefund"></cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gridheader" />
                                    <AlternatingRowStyle CssClass="gridAlternate" />
                                </asp:GridView>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                Previous Refunds: &nbsp; &nbsp; &nbsp; &nbsp; Total Refund Amount:&nbsp;
                                <asp:Label ID="lblRefundAmt" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                    Width="76%">
                                    <RowStyle CssClass="gridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>:
                                            </ItemTemplate>
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
                                    <AlternatingRowStyle CssClass="gridAlternate" />
                                </asp:GridView>
                            </td>
                        </tr>
                         <tr>
                            <td width="10%"></td>
                            <td width="25%"></td>
                            <td width="8%"></td>
                            <td width="25%"></td>
                            <td width="12%"></td>
                            <td width="20%"></td>
                        </tr>
                    </table>
                </asp:Panel>
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
                <asp:GridView ID="gvRefund" runat="server" AutoGenerateColumns="False" CssClass="datagrid" Width="99%" DataKeyNames="bookingid,prid,totalamount,discount" OnRowCommand="gvRefund_RowCommand" >
                    <RowStyle CssClass="gridItem" />
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle Height="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="receiveno" HeaderText="Paid No">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="labid" HeaderText="LAB ID">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="prno" HeaderText="PR No">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="patientname" HeaderText="Patient">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="22%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="paidamount" HeaderText="Paid Amount">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="14%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="receiveon" HeaderText="Received On">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="19%" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
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
    
    </ContentTemplate>
        <Triggers>
                 <asp:PostBackTrigger ControlID="imgSave" />
            <asp:AsyncPostBackTrigger ControlID="txtName" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

