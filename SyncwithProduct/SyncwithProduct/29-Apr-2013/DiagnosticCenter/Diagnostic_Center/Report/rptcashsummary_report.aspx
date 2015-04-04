<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptcashsummary_report.aspx.cs"
    Inherits="Report_rptcashsummary_report" %>

<%@ Register Assembly="Shared.WebControls" Namespace="Shared.WebControls" TagPrefix="wc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td colspan="3">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size: 12px;
                        font-family: Tahoma;">
                        <tr>
                            
                            <td colspan="4" align="center">
                                <h3>
                                    Cash Summary</h3>
                                <p style="font-weight: bold">
                                    From(<asp:Label ID="lblBranchname" runat="server" Font-Bold="true"></asp:Label>)</p>
                                <p style="font-weight: bold">
                                    Period:(<asp:Label ID="lbldaterange" runat="server"></asp:Label>)</p>
                            </td>
                            
                        </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    
                </td>
            </tr>
        </table>
        <%-- <fieldset style="border-radius:10px;">--%>
        <%--  <table id="tblxxx" width="99%">
<tr>
<td colspan="10">--%>
<table id="tblxxx" width="99%">
<tr>
<td colspan="7">
<fieldset style="border-radius: 10px;">
                       <legend>Cash Sales:</legend> 
        <wc:ReportGridView ID="gvMain" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="15" AllowPrintPaging="true"
            Font-Size="11px"  OnRowDataBound="gvMain_RowDataBound"
            GridLines="None">
            <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate>
                        <table id="gvtblheader" width="100%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="20%">
                                    Branch
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Standard Charges
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Discounts
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Refunds
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Payments
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Balances
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Branch Share
                                </td>
                                <td style="font-weight: bold;" width="20%">
                                    Net Cash Recieved
                                </td>
                                <%--<td style="font-weight:bold;" width="10%">Charges</td>
         <td style="font-weight:bold;" width="8%">Discount</td>
         <td style="font-weight:bold;" width="10%">Balance</td>--%>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="100%" cellpadding="1">
                            <tr>
                                <td>
                                    
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Branch")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("TotalAmount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("DiscAmount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblWard" runat="server" Text='<%#Eval("Refundamount")%>'></asp:Label>
                                </td>
                                <td>
                                    <%-- <asp:Label ID="lblAdmNo" Visible="true" runat="server" Text='<%#Eval("adm_ref")%>' ></asp:Label>--%>
                                    <asp:Label ID="lb_Bed" Visible="true" runat="server" Text='<%#Eval("paidAmount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("balance")%>'></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="lblBrShare" runat="server" Text='<%#Eval("branchshare")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblpaid" runat="server" ></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td width="20%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="20%">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>
</fieldset>
</td>
</tr>
<tr>
<td colspan="7">
<fieldset style="border-radius:10px">
<legend>Panel On Cash</legend>
<wc:ReportGridView ID="gvPanelOnCash" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="15" AllowPrintPaging="true"
            Font-Size="11px"  OnRowDataBound="gvPanelOnCash_RowDataBound"
            GridLines="None">
            <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate>
                        <table id="gvtblheader" width="100%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="20%">
                                    Branch
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Standard Charges
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Discounts
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Refunds
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Payments
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Balances
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Branch Share
                                </td>
                                <td style="font-weight: bold;" width="20%">
                                    Net Cash Recieved
                                </td>
                                <%--<td style="font-weight:bold;" width="10%">Charges</td>
         <td style="font-weight:bold;" width="8%">Discount</td>
         <td style="font-weight:bold;" width="10%">Balance</td>--%>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="100%" cellpadding="1">
                            <tr>
                                <td>
                                    
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Branch")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("TotalAmount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("DiscAmount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblWard" runat="server" Text='<%#Eval("Refundamount")%>'></asp:Label>
                                </td>
                                <td>
                                    <%-- <asp:Label ID="lblAdmNo" Visible="true" runat="server" Text='<%#Eval("adm_ref")%>' ></asp:Label>--%>
                                    <asp:Label ID="lb_Bed" Visible="true" runat="server" Text='<%#Eval("paidAmount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("balance")%>'></asp:Label>
                                </td>
                                <td>
                                <asp:Label ID="lblBrShare" runat="server" Text='<%#Eval("branchshare")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblpaid" runat="server" ></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td width="20%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="20%">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>
</fieldset>
</td>
</tr>
<tr>

<td colspan="4">
<fieldset  style="border-radius: 10px;">
<legend>Refunds(this period) on Previous Bookings</legend>
<asp:Label ID="lblzerorecord" runat="server"></asp:Label>
<wc:ReportGridView ID="gvRefunds" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="15" AllowPrintPaging="true"
            Font-Size="11px"  
            GridLines="None">
            <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="branch" ItemStyle-Width="20%" HeaderText="Branch" />
                <asp:BoundField DataField="test_name" ItemStyle-Width="25%" HeaderText="Test" />
                <asp:TemplateField HeaderText="Visit Info" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("labId")%>' Font-Size="X-Small"></asp:Label>
                    <br />
                    <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("name")%>' Font-Size="X-Small"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="bookingdate" ItemStyle-Width="10%" HeaderText="Booked On" />
                <asp:BoundField DataField="Refunddate" ItemStyle-Width="10%" HeaderText="Refunded On" />
                <asp:BoundField DataField="REfundedby" ItemStyle-Width="10%" HeaderText="Refunded By" />
                <asp:BoundField DataField="BranchShare" ItemStyle-Width="10%" HeaderText="Branch Share" />
            </Columns>
        </wc:ReportGridView>
</fieldset>
</td>
<td colspan="3"></td>
</tr>

<tr style="display:none">
<td colspan="4">

<fieldset style="border-radius:10px; display:none">
<legend>Cash OutStanding</legend>
<asp:Label ID="lblzerobalance" runat="server"></asp:Label>
<table id="tbloutbalance" runat="server" width="99%">
<tr>
<td>30 Days</td>
<td>60 Days</td>
<td>90 Days</td>
<td></td>
</tr>
<tr>
<td width="25%"> <asp:Label ID="lbloutcash30" runat="server"></asp:Label> </td>
<td width="25%"> <asp:Label ID="lbloutcash60" runat="server"></asp:Label> </td>
<td width="25%"><asp:Label ID="lbloutcash90" runat="server"></asp:Label></td>
<td width="25%"></td>
</tr>

</table>

</fieldset>
</td>
</tr>
<tr>
<td colspan="7">
<fieldset style="border-radius:10px">
<legend>Panel Patients </legend>
<wc:ReportGridView ID="gvPanel" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="15" AllowPrintPaging="true"
            Font-Size="11px"  
            GridLines="None" OnRowDataBound="gvPanel_RowDataBound">
            <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate>
                        <table id="gvtblheader" width="100%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="70%">
                                    Branch
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Charges
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Tr. Discounts
                                </td>
                                
                               
                                
                                <td style="font-weight: bold;" width="10%">
                                    Branch Share
                                </td>
                                
                                <%--<td style="font-weight:bold;" width="10%">Charges</td>
         <td style="font-weight:bold;" width="8%">Discount</td>
         <td style="font-weight:bold;" width="10%">Balance</td>--%>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="100%" cellpadding="1">
                            <tr>
                                <td>
                                    
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Branch")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("TotalAmount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("TradeDiscount")%>'></asp:Label>
                                </td>
                                
                               
                                
                                <td>
                                <asp:Label ID="lblBrShare" runat="server" Text='<%#Eval("branchshare")%>'></asp:Label>
                                </td>
                                
                                
                            </tr>
                            <tr>
                                <td width="70%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                
                                                                
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>





</fieldset>
</td>
</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td colspan="4">
<fieldset style="border-radius:10px">
<legend>Summary</legend>
<table width="99%" style="border:1px; border-radius:10px" border=1>
<tr>
<td align="right" width="50%">
Cash Sales:
</td>
<td align="right" width="50%">
<asp:Label ID="lblCashsales" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="50%">
Panel On Cash Sales:
</td>
<td align="right" width="50%">
<asp:Label ID="lblPanelOnCash" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="50%">
Panel Sales/Trade Discounts:
</td>
<td align="right" width="50%">
<asp:Label ID="lblPanelsales" runat="server"></asp:Label>/<asp:Label ID="lblTrdisc" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="50%">
Refunds/Cash Discounts: 
</td>
<td align="right" width="50%">
<asp:Label ID="lblRefunds" runat="server"></asp:Label>/<asp:Label ID="lblCashDisc" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="50%">
Balance(Cash): 
</td>
<td align="right" width="50%">
<asp:Label ID="lblbalance" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td align="right" width="50%">&nbsp;</td>
<td align="right" width="50%">
<asp:Label ID="lblNetSales" runat="server" Visible="false"></asp:Label>
</td>
</tr>

</table>
</fieldset>
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
</tr>
<tr>
<td width="20%"></td>
<td width="15%"></td>
<td width="15%"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>
</table>



    </div>
    </form>
</body>
</html>
