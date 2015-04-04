<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmdailysalesrpt.aspx.cs" Inherits="Report_wfrmdailysalesrpt" %>
<%@ Register Assembly="Shared.WebControls" Namespace="Shared.WebControls"  TagPrefix="wc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
              <%-- <img src="images/logos.jpg" width="100%" height="80px" alt="" /> --%>    
            <asp:Image ID="Img_headerMain" Visible="false" Height="50px" Width="100%"  runat="server" />
            <asp:Image ID="Img_empty"  Visible="true" ImageUrl="headerfooter/empty.jpg" Height="10px" runat="server" />
   
   <table width="100%">
            <tr>
                <td align="left" style="width: 15%;">
                <asp:Image ID="Image1" Visible="false" Height="50px" Width="200px"  runat="server" />
                    <asp:Image ID="Img_header" ImageUrl="../transaction/headerfooter/BCL LOGO.jpg" Visible="false" Height="50px" Width="200px" runat="server" />
                </td>
                <td align="center" style="width: 70%;">
                    <p style="font-size: 9px; font-weight: bold; text-align: center;">
                        <asp:Label ID="Lb_BranchNames" Font-Size="18px" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label6" Font-Size="9px" Font-Bold="true" runat="server" Text="Timings:"></asp:Label>
                        <asp:Label ID="Lb_starttime" Font-Size="10px" runat="server" Text="txbx_starttime"></asp:Label>-<asp:Label
                            ID="Lb_endtime" Font-Size="10px" runat="server" Text="txbx_endtime"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" Font-Size="9px" Font-Bold="true" runat="server" Text="Ph No:"></asp:Label>
                        <asp:Label ID="lb_phonebranchmain" Font-Size="9px" runat="server" Text=""></asp:Label>
                        &nbsp;
                        <asp:Label ID="LB_Ext" Font-Size="9px" Font-Bold="true" runat="server" Text="Ext:" />
                        <asp:Label ID="Lb_Extension" Font-Size="9px" runat="server" Text=""></asp:Label>
                    </p>
                </td>
                <td style="width: 15%;">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size: 12px;
                        font-family: Tahoma;">
                        <tr>
                            <td>
                                &nbsp;<asp:Label ID="Lb_txPRNo" Visible="false" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                                <asp:Label ID="Lb_PRNO" runat="server" Visible="false" Text=""></asp:Label>
                            </td>
                            <td rowspan="2" align="center">
                                <h3>
                                    Cashier
                                    Sales&nbsp; Report</h3>
                                <p>
                                    Sales of
                                <asp:Label ID="fromdate" runat="server"></asp:Label>
                                    &nbsp;</p>
                            </td>
                            <td align="right">
                                <asp:Label ID="LB_txVisit" runat="server"  Font-Bold="true" Visible="false" Text="Visit No:"></asp:Label>
                                <asp:Label ID="Lb_Visit" Visible="false" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td align="right" style="visibility: hidden;">
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%--(<asp:Label ID="Lb_starttime" Font-Size="7px" runat="server" Text="txbx_starttime"></asp:Label>
                                               -<asp:Label ID="Lb_endtime" Font-Size="7px" runat="server" Text="txbx_endtime"></asp:Label>)--%>            <%--<table width="100%"><tr><td align="center"><h3>Receipt</h3></td></tr></table>
            --%>
            <tr>
                <td colspan="3">
                    <fieldset style="border-radius: 10px; display:none">
                    </fieldset>
                </td>
            </tr>
        </table>
              <%-- <fieldset style="border-radius:10px;">--%>  <%--  <table id="tblxxx" width="99%">
<tr>
<td colspan="10">--%>
<%--<fieldset><legend>Closed Cashier</legend>--%>
        <wc:reportgridview ID="gvMain"   runat="server"  Width="100%" ShowHeader="true" AutoGenerateColumns="false" 
        AlternatingRowStyle-BorderStyle="None" PrintPageSize="16" AllowPrintPaging="true" 
                  Font-Size="11px" 
                  DataKeyNames="totalamountcash,cashClosing_Amountcash,discountcash,refundcash,totalamountcashpanel,cashClosing_Amountcashpanel,discountcashpanel,refundcashpanel,Creditpanel,previouscash,closingamount,netcash" 
                  GridLines="None" onrowdatabound="gvMain_RowDataBound">
        <HeaderStyle BackColor="#CCCCCC" HorizontalAlign="Left" />
        <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
        <Columns>
        
         <asp:TemplateField>
         <HeaderTemplate>
         
         <table id="gvtbl" width="100%">
                  <tr style="background-color:#DDDDDD">
         <td colspan="3"></td>
         <td colspan="4" align="center">Cash Receipt Summary</td>
         <td colspan="4" align="center">Cash Panel Summary</td>
         <td  colspan="6"></td>
         
         </tr>
         <tr style="background-color:#DDDDDD">
         <td style="font-weight:bold;" width="10%">Revenue Center</td>
         <td style="font-weight:bold;" width="10%">Cashier</td>
         <td style="font-weight:bold;" width="6%">Date</td>
        
         <td style="font-weight:bold;" width="5%">Total</td>
         <td style="font-weight:bold;" width="4%">Paid</td>
         <td style="font-weight:bold;" width="5%">Discount</td>
         <td style="font-weight:bold;" width="5%">Refund</td>
         <td style="font-weight:bold;" width="5%">Total</td>
         <td style="font-weight:bold;" width="5%">Paid</td>
         <td style="font-weight:bold;" width="5%">Discount</td>
         <td style="font-weight:bold;" width="5%">Refund</td>
         <td style="font-weight:bold;" width="5%">Cr Panel</td>
         <td style="font-weight:bold;" width="7%">Previous Cash Receive</td>
         <td style="font-weight:bold;" width="5%">Cash</td>
         <td style="font-weight:bold;" width="6%">Net Amount</td>
         <td style="font-weight:bold;" width="5%">Difference</td>
         <td style="font-weight:bold;" width="6%">Report #</td>
         
         </tr>
         </table>
         
         </HeaderTemplate>
         <ItemTemplate>
         <table width="100%">
         <tr>
         <td width="10%">
            <asp:Label ID="lblrevenuecenter" runat="server" Text='<%#Eval("branchname")%>' ></asp:Label>
         </td>
         <td width="10%">
            <asp:Label ID="lblcashier" runat="server" Text='<%#Eval("cashiername")%>' ></asp:Label>
         </td>
         <td width="6%">
            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("enteredon")%>' ></asp:Label>
         </td>
        
         <td width="5%">
            <asp:Label ID="lbltotalcash" runat="server" Text='<%#Eval("totalamountcash")%>'  ></asp:Label>
         </td>
         <td width="4%">
            <asp:Label ID="lblpaidcash" runat="server" Text='<%#Eval("cashClosing_Amountcash")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lbldiscountcash" runat="server" Text='<%#Eval("discountcash")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblrefundcash" runat="server" Text='<%#Eval("refundcash")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lbltotalcpanel" runat="server" Text='<%#Eval("totalamountcashpanel")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblpaidcpanel" runat="server" Text='<%#Eval("cashClosing_Amountcashpanel")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lbldiscountcpanel" runat="server" Text='<%#Eval("discountcashpanel")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblrefundcpanel" runat="server" Text='<%#Eval("refundcashpanel")%>'  ></asp:Label>
         </td>
          <td width="5%">
            <asp:Label ID="lblcreditpanel" runat="server" Text='<%#Eval("Creditpanel")%>' ></asp:Label>
         </td>
         <td width="7%">
            <asp:Label ID="lblcollect" runat="server" Text='<%#Eval("previouscash")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblcpsumm" runat="server" Text='<%#Eval("closingamount")%>' ></asp:Label>
         </td>
         <td width="6%">
            <asp:Label ID="lblrecvamt" runat="server" Text='<%#Eval("netcash")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lbldiff" runat="server" Text='<%#Eval("difference")%>' ></asp:Label>
         </td>
        <td width="6%">
            <asp:Label ID="Label1" runat="server" Text='<%#Eval("reportno")%>' ></asp:Label>
         </td>
         </tr>
       
         <tr>
         <td width="10%"></td>
         <td width="10%"></td>
         <td width="6%"></td>
         
         <td width="5%"></td>
         <td width="4%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="7%"></td>
         <td width="5%"></td>
         <td width="6%"></td>
         <td width="5%"></td>
         <td width="6%"></td>
         
         </tr>
         
         </table>
                
            </ItemTemplate>
            </asp:TemplateField>
            
            
        </Columns>
        </wc:reportgridview>
       <%-- </fieldset>--%>
        
       <%-- <fieldset><legend>Running Cashier</legend>
        <wc:reportgridview ID="GVrunning"   runat="server"  Width="100%" ShowHeader="true" AutoGenerateColumns="false" 
        AlternatingRowStyle-BorderStyle="None" PrintPageSize="16" AllowPrintPaging="true" 
                  Font-Size="11px" DataKeyNames="totalamountcash,cashClosing_Amountcash,discountcash,refundcash,totalamountcashpanel,cashClosing_Amountcashpanel,discountcashpanel,refundcashpanel,Creditpanel,closingamount,difference" GridLines="None">
        <HeaderStyle BackColor="#CCCCCC" HorizontalAlign="Left" />
        <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
        <Columns>
        
         <asp:TemplateField>
         <HeaderTemplate>
         
         <table id="gvtbl" width="100%">
                  <tr style="background-color:#DDDDDD">
         <td colspan="3"></td>
         <td colspan="4" align="center">Cash Receipt Summary</td>
         <td colspan="4" align="center">Cash Panel Summary</td>
         <td  colspan="6"></td>
         
         </tr>
         <tr style="background-color:#DDDDDD">
         <td style="font-weight:bold;" width="10%">Revenue Center</td>
         <td style="font-weight:bold;" width="10%">Cashier</td>
         <td style="font-weight:bold;" width="6%">Date</td>
        
         <td style="font-weight:bold;" width="5%">Total</td>
         <td style="font-weight:bold;" width="4%">Paid</td>
         <td style="font-weight:bold;" width="5%">Discount</td>
         <td style="font-weight:bold;" width="5%">Refund</td>
         <td style="font-weight:bold;" width="5%">Total</td>
         <td style="font-weight:bold;" width="5%">Paid</td>
         <td style="font-weight:bold;" width="5%">Discount</td>
         <td style="font-weight:bold;" width="5%">Refund</td>
         <td style="font-weight:bold;" width="5%">Cr Panel</td>
         <td style="font-weight:bold;" width="7%">Previous Cash Receive</td>
         <td style="font-weight:bold;" width="5%">Cash</td>
         <td style="font-weight:bold;" width="6%">Net Amount</td>
         <td style="font-weight:bold;" width="5%">Difference</td>
         <td style="font-weight:bold;" width="6%">Report #</td>
         
         </tr>
         </table>
         
         </HeaderTemplate>
         <ItemTemplate>
         <table width="100%">
         <tr>
         <td width="10%">
            <asp:Label ID="lblrevenuecenter" runat="server" Text='<%#Eval("branchname")%>' ></asp:Label>
         </td>
         <td width="10%">
            <asp:Label ID="lblcashier" runat="server" Text='<%#Eval("cashiername")%>' ></asp:Label>
         </td>
         <td width="6%">
            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("enteredon")%>' ></asp:Label>
         </td>
        
         <td width="5%">
            <asp:Label ID="lbltotalcash" runat="server" Text='<%#Eval("totalamountcash")%>'  ></asp:Label>
         </td>
         <td width="4%">
            <asp:Label ID="lblpaidcash" runat="server" Text='<%#Eval("cashClosing_Amountcash")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lbldiscountcash" runat="server" Text='<%#Eval("discountcash")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblrefundcash" runat="server" Text='<%#Eval("refundcash")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lbltotalcpanel" runat="server" Text='<%#Eval("totalamountcashpanel")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblpaidcpanel" runat="server" Text='<%#Eval("cashClosing_Amountcashpanel")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lbldiscountcpanel" runat="server" Text='<%#Eval("discountcashpanel")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblrefundcpanel" runat="server" Text='<%#Eval("refundcashpanel")%>'  ></asp:Label>
         </td>
          <td width="5%">
            <asp:Label ID="lblcreditpanel" runat="server" Text='<%#Eval("Creditpanel")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblcollect" runat="server" Text="" ></asp:Label>
         </td>
         <td width="7%">
            <asp:Label ID="lblcpsumm" runat="server" Text='<%#Eval("closingamount")%>' ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lblrecvamt" runat="server" Text="" ></asp:Label>
         </td>
         <td width="5%">
            <asp:Label ID="lbldiff" runat="server" Text='<%#Eval("difference")%>' ></asp:Label>
         </td>
        <td width="6%">
            <asp:Label ID="Label1" runat="server" Text='<%#Eval("reportno")%>' ></asp:Label>
         </td>
         </tr>
       
         <tr>
         <td width="10%"></td>
         <td width="10%"></td>
         <td width="6%"></td>
         
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="4%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="7%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="6%"></td>
         
         </tr>
         
         </table>
                
            </ItemTemplate>
            </asp:TemplateField>
            
            
        </Columns>
        </wc:reportgridview>
        </fieldset>--%>
              <%--   </td>
</tr>
<tr>
<td colspan="5"></td>
<td colspan="5">--%>
<table id="ttltable"  style="background-color:#DDDDDD; display:block; font-size:12px;" cellpadding="0" cellspacing="3" border="1" width="100%">
          <tr style="background-color:#DDDDDD">
         <td colspan="3"></td>
         <td colspan="4" align="center">Cash Receipt Summary</td>
         <td colspan="4" align="center">Cash Panel Summary</td>
         <td  colspan="6"></td>
         
         </tr>
      <tr style="background-color:#DDDDDD">
         <td style="font-weight:bold;" width="10%">&nbsp;</td>
         <td style="font-weight:bold;" width="10%">&nbsp;</td>
         <td style="font-weight:bold;" width="6%">&nbsp;</td>
        
         <td style="font-weight:bold;" width="5%">Total</td>
         <td style="font-weight:bold;" width="4%">Paid</td>
         <td style="font-weight:bold;" width="5%">Discount</td>
         <td style="font-weight:bold;" width="5%">Refund</td>
         <td style="font-weight:bold;" width="5%">Total</td>
         <td style="font-weight:bold;" width="5%">Paid</td>
         <td style="font-weight:bold;" width="5%">Discount</td>
         <td style="font-weight:bold;" width="5%">Refund</td>
         <td style="font-weight:bold;" width="5%">Cr Panel</td>
         <td style="font-weight:bold;" width="5%">Previous Cash Recv </td>
         <td style="font-weight:bold;" width="5%">Cash</td>
         <td style="font-weight:bold;" width="5%">Net Amount</td>
         <td style="font-weight:bold;" width="5%">Difference</td>
         <td style="font-weight:bold;" width="7%">&nbsp;</td>
         </tr>
    
     <tr>
         <td  width="10%"> Total
         </td>
            <td  width="10%">
            </td>
         <td  width="6%">
        
         </td>
         <td width="10%">
             <asp:Label ID="lblcashtotal" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblcashpaid" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="4%">
             <asp:Label ID="lblcashdiscount" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblcashrefund" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblcptotal" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblcppaid" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblcpdiscount" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblcprefund" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblcreditpanel" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblcollection" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblnetreceipt" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lblbank" runat="server" Width="100%"></asp:Label>
         </td>
         <td width="5%">
             <asp:Label ID="lbldifference" runat="server" Width="100%"></asp:Label>
         </td>
         
         </tr>


    
</table>
              <%--</td>
</tr>
<tr>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>

</table>--%>    <%--</fieldset>--%>
    </div>
    </form>
</body>
</html>
