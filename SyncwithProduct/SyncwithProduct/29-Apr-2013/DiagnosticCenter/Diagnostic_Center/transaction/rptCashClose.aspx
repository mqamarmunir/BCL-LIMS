<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptCashClose.aspx.cs" Inherits="transaction_rptCashClose" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <%--<table width="100%">
   <tr>
   <td align="left" style="width:15%;">
     <asp:Image ID="Img_header" Visible="false" Height="50px" Width="200px"  runat="server" />
   </td>
   <td align="center" style="width:70%;">
   <p style="font-size:9px; font-weight:bold; text-align:center;">
       <asp:Label ID="Lb_BranchNames" Font-Size="18px" runat="server"></asp:Label>
       <br />
    <asp:Label ID="Label6" Font-Size="9px" Font-Bold="true" runat="server" Text="Timings:"></asp:Label> (<asp:Label ID="Lb_starttime" Font-Size="10px" runat="server" Text="txbx_starttime"></asp:Label>-<asp:Label ID="Lb_endtime" Font-Size="10px" runat="server" Text="txbx_endtime"></asp:Label>)
  / <asp:Label ID="Label2" Font-Size="9px" Font-Bold="true" runat="server" Text="Ph#:"></asp:Label> <asp:Label ID="lb_phonebranchmain" Font-Size="9px" runat="server" Text=""></asp:Label> &nbsp;<asp:Label ID="LB_Ext" Font-Size="9px" Font-Bold="true" runat="server" Text="Ext:" /> (<asp:Label ID="Lb_Extension" Font-Size="9px" runat="server" Text=""></asp:Label>)
  </p> 
   </td>
   <td style="width:15%;"></td>
   </tr>
   </table>--%>
            <%--(<asp:Label ID="Lb_starttime" Font-Size="7px" runat="server" Text="txbx_starttime"></asp:Label>
                                               -<asp:Label ID="Lb_endtime" Font-Size="7px" runat="server" Text="txbx_endtime"></asp:Label>)--%>
  <table width="100%" border="0" style="font-size:12px; font-family:Tahoma;">
                       <tr>
                        <td>
                            <asp:Image ID="Img_header" Visible="false" Height="50px" Width="160px"  runat="server" />
                            <%--<asp:Label ID="Lb_txPRNo" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                       
                             <asp:Label ID="Lb_PRNO" runat="server" Text=""></asp:Label>--%>
                        </td>
                        <td rowspan="2" align="center">
                           <h3>Cash Closing Report</h3>
                        </td>
                        <td align="right">
                            <%-- <asp:Label ID="LB_txVisit" runat="server" Font-Bold="true" Text="Visit No:"></asp:Label>
                       
                            <asp:Label ID="Lb_Visit" runat="server" Text=""></asp:Label>--%>
                        </td>
                       </tr>
                       <tr>
                            <td><asp:Image ID="Image1" Width="160px" Height="20px" ImageUrl="barcode.jpg" runat="server" /></td>
                           
                            <td align="right"><asp:Image ID="Image2" Width="160px" Height="20px" ImageUrl="~/transaction/barcode.jpg" runat="server" /></td>
                       </tr>
                    </table>
            
<fieldset style="border-radius:10px;">
      <asp:GridView Width="100%" Font-Size="11px" style="font-family:Tahoma;" 
                ID="Gv_CashPrimaryInfo" runat="server" 
            AutoGenerateColumns="False" ShowHeader="False" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                      <table width="100%" style="margin-top:-10px;">
                      <tr>
                        <td>
                                <table cellpadding="2" cellspacing="2">
                                    <tr>
                                            <td>
                                                <asp:Label ID="Lb_txCashierName" runat="server" Font-Bold="true" Text="Cashier:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lb_CashValue" runat="server" Text='<%# Eval("cashier")  %>'></asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                            <td>
                                                <asp:Label ID="Lb_ReportNo" runat="server" Font-Bold="true" Text="Report No:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lb_ReportNoValue" runat="server" Text='<%# Eval("reportno")  %>'></asp:Label>
                                                 
                                            </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                                 <td>
                                                    <asp:Label ID="Lb_txBranch" runat="server" Font-Bold="true" Text="Branch:"></asp:Label>
                                                </td>
                                                <td>
                                                   <%-- <asp:Label ID="Lb_Branch" runat="server" Text='<%# Eval("")  %>'></asp:Label>--%>
                                                </td>
                                    </tr>                                    
                                </table>
                        </td>
                        <td align="right">
                                 <table cellpadding="2" cellspacing="2">
                                  <tr>
                                        <td>
                                            <asp:Label ID="Lb_GeneratedOn" runat="server" Font-Bold="true" Text="Generated On:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_GeneratedText" runat="server" Text='<%# Eval("enteredon")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txPrint" runat="server" Font-Bold="true" Text="Print On:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Print" runat="server"  Text='<%# Eval("datetoday") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <asp:Label ID="Lb_txreferences" runat="server" Font-Bold="true" Text=":"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_refernces" runat="server"  Text=""></asp:Label>
                                        </td>
                                    </tr>--%>
                                 </table>
                        </td>
                      </tr>
                      </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
          <HeaderStyle Wrap="True" />
        </asp:GridView>
        
      <asp:GridView ID="Gv_DayCashList"  runat="server" Font-Size="8px" AutoGenerateColumns="False" 
                Width="100%" GridLines="Horizontal" HorizontalAlign="Left" CellPadding="0" ForeColor="#333333" 
                     DataKeyNames="reportno">
                <Columns>
                        <asp:BoundField DataField="cashOpening_Amount" HeaderText="Opening Amount" 
                            SortExpression="cashOpening_Amount" />
                        <%--<asp:BoundField DataField="enteredon" HeaderText="Check In" 
                            SortExpression="enteredon" />--%>
                           <asp:TemplateField HeaderText="Check In" >
                            <ItemTemplate>
                                    <asp:Label ID="Lb_EnteredON" runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                        <asp:BoundField DataField="cashClosing_Amount" HeaderText="Closing Amount" 
                            SortExpression="cashClosing_Amount" />
                        <%--<asp:BoundField DataField="enteredoff" HeaderText="Check Out" 
                            SortExpression="enteredoff" />--%>
                            <asp:TemplateField HeaderText="Check Out" >
                            <ItemTemplate>
                                    <asp:Label ID="Lb_EnteredOFF" runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>


                        <asp:TemplateField HeaderText="Cash in hand">
                            <ItemTemplate>
                                <asp:Label ID="Lb_NetSales" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Branch" 
                            SortExpression="branchid" />
                        <asp:TemplateField HeaderText="Status" Visible="false">
                            <ItemTemplate>
                                   <asp:Image ID="Img_online" ImageUrl="~/transaction/headerfooter/online.png" ToolTip="Cash status is open" runat="server" />
                                   <asp:Image ID="Img_offline" ImageUrl="~/transaction/headerfooter/offline.png" ToolTip="Cash status has been closed" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
                <HeaderStyle HorizontalAlign="Left"  Font-Bold="True" 
                    ForeColor="Black" />
                <RowStyle HorizontalAlign="Left"  />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
</fieldset>

<fieldset style="border-radius:10px;">        
<legend style="font-size:9px;">Cash Receipt</legend>
        <asp:GridView GridLines="None" Font-Size="9px" 
            style="font-family:Tahoma;"  ID="Gv_PatientReceipt" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="2" ForeColor="#333333">
            <RowStyle BackColor="#D1EED6" />
        <Columns>
            <asp:TemplateField HeaderText="Sr#">
                <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                <ControlStyle Width="1%" />
            </asp:TemplateField>
            <asp:BoundField ControlStyle-Width="5%" DataField="receiveno" HeaderText="Receive No" />
            <asp:BoundField ControlStyle-Width="5%" DataField="labid" HeaderText="Lab No" />
            <asp:BoundField ControlStyle-Width="54%" DataField="patientname" HeaderText="Patient" />
            <asp:BoundField ControlStyle-Width="5%" DataField="totalamount" HeaderText="Total" />
            <asp:BoundField ControlStyle-Width="5%" DataField="paidamount" HeaderText="Paid" />
            <asp:BoundField ControlStyle-Width="5%" DataField="discount" HeaderText="Discount" />
            <asp:BoundField ControlStyle-Width="3%" HeaderText="Balance"  DataField="balance" />
            <%--<asp:TemplateField HeaderText="Balance" ControlStyle-Width="3%">    
            <ItemTemplate>
            <asp:Literal 
       ID="Literal4" 
       runat="server" 
       Text='<%# (Decimal.Parse(Eval("totalamount").ToString())-Decimal.Parse(Eval("paidamount").ToString())-Decimal.Parse(Eval("discount").ToString())) %>'>
    </asp:Literal> 
            </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:BoundField ControlStyle-Width="5%" DataField="patientType" HeaderText="Type" />
            <asp:BoundField ControlStyle-Width="5%" DataField="receiveon" HeaderText="Received  On" />
            <%--<asp:BoundField ControlStyle-Width="13%" DataField="referenceno" HeaderText="Ref. No" />--%>
            <asp:BoundField ControlStyle-Width="5%" DataField="paymentmode" HeaderText="Payment Mode" />
        </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>       

        <asp:Label ID="Lb_DuesReceived" Font-Size="10px" Font-Bold="true" Text="Received Against Previous Date Booking" runat="server"></asp:Label> 
        
    <asp:GridView ID="Gv_OldReceiving" GridLines="None" EmptyDataText="No received against previous date."  Font-Size="10px" runat="server" AutoGenerateColumns="false" Width="100%">
    <Columns>
          <asp:BoundField ControlStyle-Width="5%" DataField="receiveno" HeaderText="Receive No" />
            <asp:BoundField ControlStyle-Width="5%" DataField="labid" HeaderText="Visit No" />
            <asp:BoundField ControlStyle-Width="54%" DataField="patientname" HeaderText="Patient" />
           <%-- <asp:BoundField ControlStyle-Width="5%" DataField="totalamount" HeaderText="Total" />--%>
            <asp:BoundField ControlStyle-Width="5%" DataField="paidamount" HeaderText="Paid" />
           <%-- <asp:BoundField ControlStyle-Width="5%" DataField="discount" HeaderText="Discount" />--%>
            <asp:BoundField ControlStyle-Width="5%" DataField="type" HeaderText="Type" />
            <%--<asp:BoundField ControlStyle-Width="13%" DataField="referenceno" HeaderText="Ref. No" />--%>
            <asp:BoundField ControlStyle-Width="15%" DataField="receiveon" HeaderText="Received On" />
            <asp:BoundField ControlStyle-Width="5%" DataField="paymentmode" HeaderText="Payment Mode" />
    </Columns>
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
    </asp:GridView>

        <table width="100%">
            <tr>
                <td align="right">
                         <asp:Label ID="Lb_total" Font-Size="11px" Font-Bold="true" Text="Total Cash Received ==" runat="server" ></asp:Label>
                         <asp:Label ID="Lb_totalCash" Font-Bold="true" Font-Size="11px" runat="server" ></asp:Label>
                         &nbsp;&nbsp;
                         <asp:Label ID="Label3" Font-Size="11px" Font-Bold="true" Text="Debit Card Receivings ==" runat="server" ></asp:Label>
                         <asp:Label ID="lbl_totalDebit" Font-Bold="true" Font-Size="11px" runat="server" ></asp:Label>
                         &nbsp;&nbsp;
                         <asp:Label ID="Label5" Font-Size="11px" Font-Bold="true" Text="Credit Card Receivings ==" runat="server" ></asp:Label>
                         <asp:Label ID="lbl_totalCredit" Font-Bold="true" Font-Size="11px" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
              
        <%--<asp:GridView Font-Size="11px" style="font-family:Tahoma;"   Width="100%" ID="Gv_paymentModule" runat="server" 
            AutoGenerateColumns="False" GridLines="None" >
        <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table width="90%">
           <tr>
                <td align="right">
                    <asp:Label ID="Lb_Total" Font-Bold="true" runat="server"  Text="Total Amount: Rs."></asp:Label>
                    <asp:Label ID="Label1" runat="server"  Text='<%# Eval("totalamount") %>'></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="tr_discount">
               <td align="right" >
               <br />
                 <asp:Label  Font-Bold="true" ID="Lb_disc" runat="server" Text="Discount Amount: Rs."></asp:Label>
                 <asp:Label  ID="lb_discValue"  runat="server"  Text='<%# Eval("discount_amt") %>'></asp:Label>
               </td>
            </tr>
            <tr>
               <td align="right">
                 <asp:Label Font-Bold="true" ID="Lb_totalPayment" runat="server" Text="Paid Amount: Rs."></asp:Label>
                 <asp:Label ID="Label3"  runat="server"  Text='<%# Eval("totalpaid") %>'></asp:Label>
               </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label Font-Bold="true" ID="Lb_Balance" runat="server" Text="Balance: Rs."></asp:Label>
                    <asp:Label  ID="Lb_bal" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </table>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
--%>

</fieldset>

<fieldset  style="border-radius:10px;">
        <legend style="font-size:9px;">Cash Panel Receipt</legend>
        <asp:GridView GridLines="None" Font-Size="9px" 
            style="font-family:Tahoma;"  ID="Gv_PanelPatient" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="2" ForeColor="#333333">
            <RowStyle BackColor="#D1EED6" />
        <Columns>
            <asp:TemplateField HeaderText="Sr #">
                <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField  DataField="receiveno" HeaderText="Receive No" />
            <asp:BoundField DataField="labid" HeaderText="Visit No" />
            <asp:BoundField DataField="patientname" HeaderText="Patient" />
            <asp:BoundField DataField="totalamount" HeaderText="Total" />
            <asp:BoundField DataField="paidamount" HeaderText="Paid" />
            <asp:BoundField DataField="discount" HeaderText="Discount" />
            <asp:BoundField DataField="patientType" HeaderText="Type" />
            <asp:BoundField DataField="panel" HeaderText="Panel" />
            
           <asp:BoundField DataField="receiveon" HeaderText="Received On" />
           <asp:BoundField DataField="paymentmode" HeaderText="Payment Mode" />
        </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <table width="100%">
            <tr>
                <td align="right">
                         <asp:Label ID="Lb_panel" Font-Size="11px" Font-Bold="true" Text="Total Cash Received ==" runat="server" ></asp:Label>
                         <asp:Label ID="Lb_panelReceived" Font-Bold="true" Font-Size="11px" runat="server" ></asp:Label>
                         &nbsp;&nbsp;
                         <asp:Label ID="Label6" Font-Size="11px" Font-Bold="true" 
                             Text="Debit Card Receivings ==" runat="server" ></asp:Label>
                         <asp:Label ID="lbl_totalDebitPanel" Font-Bold="true" Font-Size="11px" 
                             runat="server" ></asp:Label>
                             &nbsp;&nbsp;
                         <asp:Label ID="Label7" Font-Size="11px" Font-Bold="true" 
                             Text="Credit Card Receivings ==" runat="server" ></asp:Label>
                         <asp:Label ID="lbl_totalCreditPanel" Font-Bold="true" Font-Size="11px" 
                             runat="server" ></asp:Label>
                
                </td>
               
            </tr>
        </table>
</fieldset>

<fieldset  style="border-radius:10px;">
        <legend style="font-size:9px;">Cash Refund Receipt</legend>
         <asp:GridView GridLines="None" Font-Size="9px" 
            style="font-family:Tahoma;"  ID="Gv_RefundPatient" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="2" ForeColor="#333333">
            <RowStyle BackColor="#D1EED6" />
        <Columns>
            <asp:TemplateField HeaderText="Sr #">
                <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="refundno" HeaderText="Refund No" />
            <asp:BoundField DataField="labid" HeaderText="Visit No" />
            <asp:BoundField DataField="patientname" HeaderText="Patient" />
            <asp:BoundField DataField="totalamount" HeaderText="Total" />
            <asp:BoundField DataField="paidamount" HeaderText="Paid" />
            <asp:BoundField DataField="refundtype" HeaderText="Mode" />
            <asp:BoundField DataField="refundon" HeaderText="Refund On" />
        </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
         <table width="100%">
            <tr>
                <td align="right">
                         <asp:Label ID="Lb_refund" Font-Size="11px" Font-Bold="true" Text="Total Cash Refund =" runat="server" ></asp:Label>
                         <asp:Label ID="Lb_refundReceived" Font-Bold="true" Font-Size="11px" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
</fieldset>

<asp:Label ID="Label1" Font-Size="14px" Font-Bold="true" Text="Summary Total:" runat="server" ></asp:Label>
            <table style="font-size:11px; font-weight:bold;" width="100%" cellspacing="0">
    <tr>
        <td style="border-left:1px solid black; border-top:1px solid black; border-bottom:1px solid black;"> Cash Received</td>
        <td style="border-left:1px solid black; border-top:1px solid black; border-bottom:1px solid black;"> Balance(Cash Patients)</td>
        <td style="border-top:1px solid black; border-bottom:1px solid black;"> Cash Refund</td>
        <td style="border-top:1px solid black; border-bottom:1px solid black;"> On Account</td>
        <td style="border-top:1px solid black; border-bottom:1px solid black;"> Credit Card</td>
        <td style="border-right:1px solid black; border-top:1px solid black; border-bottom:1px solid black;"> Debit Card</td>        
    </tr>
    <tr>
        <td>
            <asp:Label ID="Lb_CashNetRecieved" runat="server"></asp:Label>
        </td>
         <td>
            <asp:Label ID="lblTotbalance" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Lb_OnNetRefund" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Lb_PanelNetRecieved" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Lb_OnCredit" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Lb_Debit" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
    <td colspan="5" align="right">
            <asp:Label ID="Label2" Font-Size="14px" Text="Net Amount :" runat="server"></asp:Label>
            <asp:Label ID="Lb_NetAmount" Font-Size="14px" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
    <td colspan="5" align="right">
    <asp:Label ID="lblExcessorshort" Font-Size="14px" runat="server"></asp:Label>
    </td>
    </tr>
</table>
    </div>
    </form>
</body>
</html>
