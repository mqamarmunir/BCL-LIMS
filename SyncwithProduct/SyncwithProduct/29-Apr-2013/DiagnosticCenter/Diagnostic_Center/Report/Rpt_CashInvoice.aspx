<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_CashInvoice.aspx.cs"
    Inherits="transaction_Rpt_CashInvoice" %>

<%@ Register Assembly="Shared.WebControls" Namespace="Shared.WebControls" TagPrefix="wc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%-- <img src="images/logos.jpg" width="100%" height="80px" alt="" /> --%>
        <asp:Image ID="Img_headerMain" Visible="false" Height="50px" Width="100%" runat="server" />
        <asp:Image ID="Img_empty" Visible="true" ImageUrl="../transaction/headerfooter/empty.jpg" Height="10px"
            runat="server" />
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
                                    Sales 
                                    Detail Summary</h3>
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
                                               -<asp:Label ID="Lb_endtime" Font-Size="7px" runat="server" Text="txbx_endtime"></asp:Label>)--%>
            <%--<table width="100%"><tr><td align="center"><h3>Receipt</h3></td></tr></table>
            --%>
            <tr>
                <td colspan="3">
                    <fieldset style="border-radius: 10px;">
                        <asp:GridView Width="100%" Font-Size="11px" Style="font-family: Tahoma; color: Black;"
                            ID="Gv_PatientPrimaryInfo" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                            GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <table cellpadding="2" cellspacing="2">
                                                    <tr>
                                                            <td>
                                                                <asp:Label ID="lblBranch" runat="server" Font-Bold="true" Text="Branch"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPanelName" runat="server" Font-Bold="true" Text="Panel"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblpanelNameValue" runat="server" Text='<%# Eval("PanelName")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblConsultant" runat="server" Font-Bold="true" Text="Consultant"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblConsultantVal" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%--                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txPassword" runat="server" Font-Bold="true" Text="Password:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Password" runat="server" Text='<%# Eval("Pasword")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                                        --%>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblReportDate" runat="server" Font-Bold="true" Text="Report Date:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("DateRange")  %>'></asp:Label>
                                                                
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="right">
                                                    <table cellpadding="2" cellspacing="2">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="PrintedOn" runat="server" Font-Bold="true" Text="Printed On:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPrintedOn" runat="server" Text='<%# Eval("PrintedOn")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
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
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Wrap="True" />
                        </asp:GridView>
                    </fieldset>
                </td>
            </tr>
        </table>
        <%-- <fieldset style="border-radius:10px;">--%>
        <%--  <table id="tblxxx" width="99%">
<tr>
<td colspan="10">--%>
        <wc:ReportGridView ID="gvMain" runat="server" Width="99%" ShowHeader="true" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="17" AllowPrintPaging="true"
            Font-Size="11px" DataKeyNames="bookingid,panelid,PanelCash" 
            GridLines="None" onrowdatabound="gvMain_RowDataBound">
            <HeaderStyle BackColor="#CCCCCC" />
            <RowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD" />
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                <table id="gvtbl" width="99%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="7%">
                                    Date
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Lab ID
                                </td>
                                <td style="font-weight: bold;" width="13%">
                                    Patient
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Branch
                                </td>
                                <td style="font-weight: bold;" width="12%">
                                    Panel
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Consultant
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Entered By
                                </td>
                                <td style="font-weight: bold;" width="7%">
                                    Total
                                </td>
                                <td style="font-weight: bold;" width="7%">
                                    Paid
                                </td>
                                <td style="font-weight: bold;" width="7%">
                                    Discount
                                </td>
                                <td style="font-weight: bold;" width="7%">
                                    Balance
                                </td>
                            </tr>
                            </table>
                </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="99%">
                            <%--<tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="10%">
                                    Date
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                    Lab ID
                                </td>
                                <td style="font-weight: bold;" width="8%">
                                    Patient
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Panel
                                </td>
                                <td style="font-weight: bold;" width="9%">
                                    Consultant
                                </td>
                                <td style="font-weight: bold;" width="9%">
                                    Entered By
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Total
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Paid
                                </td>
                                <td style="font-weight: bold;" width="8%">
                                    Discount
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Balance
                                </td>
                            </tr>--%>
                            <tr>
                                <td width="7%">
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("bookedon")%>'></asp:Label>
                                </td>
                                <td width="10%">
                                    <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("labid")%>'></asp:Label>
                                </td>
                                <td width="13%">
                                    <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Patientname")%>'></asp:Label>
                                </td>
                                  <td width="10%">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Branch")%>'></asp:Label>
                                </td>
                                <td width="12%">
                                    <asp:Label ID="lblPanel" runat="server" Text='<%#Eval("Panel")%>'></asp:Label>
                                </td>
                                <td width="10%">
                                    <%-- <asp:Label ID="lblAdmNo" Visible="true" runat="server" Text='<%#Eval("adm_ref")%>' ></asp:Label>--%>
                                    <asp:Label ID="lblConsultant" Visible="true" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
                                </td>
                                <td width="10%">
                                    <asp:Label ID="lblEnteredBy" Visible="true" runat="server" Text='<%#Eval("EnteredBy")%>'></asp:Label>
                                </td>
                                <td width="7%">
                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("charges")%>'></asp:Label>
                                </td>
                                <td width="7%">
                                    <asp:Label ID="lblpaid" runat="server" Text='<%#Eval("paidamount")%>'></asp:Label>
                                </td>
                                <td width="7%">
                                    <asp:Label ID="lbldis" runat="server" Text='<%#Eval("discount_amt")%>'></asp:Label>
                                </td>
                                <td width="7%">
                                    <asp:Label ID="lblbal" runat="server" Text='<%#Eval("balance")%>'></asp:Label>
                                </td>
                            </tr>
                             <tr>
         <td></td>
         <td colspan="6">
            <asp:GridView GridLines="None" style="border:1px dotted #BBBBBB;" ID="gvInvestigations" Width="99%" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField HeaderText="Investigation Detail:" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="78%" DataField="Test_Name" />
                
                <asp:BoundField HeaderText="" DataField="Charges" HeaderStyle-Width="12%" />

            </Columns>
            </asp:GridView>
         </td>
         </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>

       


        Refund/Cancellation:
        
        <wc:ReportGridView ID="ReportGridView1" runat="server" Width="99%" AutoGenerateColumns="False"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="10" AllowPrintPaging="True"
            Font-Size="11px" DataKeyNames="bookingid" 
            GridLines="Horizontal" Branchid="" 
            onrowdatabound="ReportGridView1_RowDataBound">
            <HeaderStyle BackColor="#CCCCCC" />
            <RowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD" />
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                <table id="gvtbl" width="99%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="15%">
                                    Date
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                    Lab ID
                                </td>
                                <td style="font-weight: bold;" width="20%">
                                    Patient
                                </td>
                                <td style="font-weight: bold;" width="20%">
                                    Tests
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                    Type
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                    Amount
                                </td>
                                
                                
                                
                                
                            </tr>
                            </table>
                </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="99%">
                            
                            <tr>
                                <td width="15%">
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("enteredon")%>'></asp:Label>
                                </td>
                                <td width="15%">
                                    <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("labid")%>'></asp:Label>
                                </td>
                                <td width="20%">
                                    <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Patientname")%>'></asp:Label>
                                </td>
                                <td width="20%"></td>
                                <td width="15%"></td>
                                <td width="15%"></td>
                            </tr>
                            <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td colspan="3">
                                <asp:GridView ID="gvrefunddetail" runat="server" DataKeyNames="panelid,panelcash" GridLines="None" Width="99%" ShowHeader="false" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" Font-Size="11px">
            <Columns>
            <asp:BoundField ItemStyle-Width="40%" DataField="Test_name" HeaderText="Test"/>
            <asp:BoundField ItemStyle-Width="30%" DataField="refundtype" HeaderText="Type" />
            <asp:BoundField ItemStyle-Width="30%" DataField="paidamount" HeaderText="Amount" />
            </Columns>
                                
                                </asp:GridView>
                            </td>
                            
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>
         Cash Recieved against Previous Bookings
        <wc:ReportGridView ID="gvMain_2" runat="server" Width="99%" ShowHeader="true" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="17" AllowPrintPaging="true"
            Font-Size="11px" DataKeyNames="bookingid,panelcash" 
            GridLines="None">
            <HeaderStyle BackColor="#CCCCCC" />
            <RowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD" />
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                <table id="gvtbl" width="99%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="8%">
                                    Paid On
                                </td>
                                <td style="font-weight: bold;" width="8%">
                                    Booked On
                                </td>
                                <td style="font-weight: bold;" width="12%">
                                    Lab ID
                                </td>
                                <td style="font-weight: bold;" width="13%">
                                    Patient
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                    Panel
                                </td>
                                <td style="font-weight: bold;" width="13%">
                                    Consultant
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Entered By
                                </td>
                                <td style="font-weight: bold;" width="7%">
                                    Total
                                </td>
                                <td style="font-weight: bold;" width="7%">
                                    Paid
                                </td>
                                <%--<td style="font-weight: bold;" width="7%">
                                    Discount
                                </td>
                                <td style="font-weight: bold;" width="7%">
                                    Balance
                                </td>--%>
                            </tr>
                            </table>
                </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="99%">
                            <%--<tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="10%">
                                    Date
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                    Lab ID
                                </td>
                                <td style="font-weight: bold;" width="8%">
                                    Patient
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Panel
                                </td>
                                <td style="font-weight: bold;" width="9%">
                                    Consultant
                                </td>
                                <td style="font-weight: bold;" width="9%">
                                    Entered By
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Total
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Paid
                                </td>
                                <td style="font-weight: bold;" width="8%">
                                    Discount
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Balance
                                </td>
                            </tr>--%>
                            <tr>
                                <td width="8%">
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("enteredon")%>'></asp:Label>
                                </td>
                                <td width="8%">
                                <asp:Label ID="lblbookedon" runat="server" Text='<%#Eval("bookedon")%>'></asp:Label>
                                </td>
                                <td width="12%">
                                    <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("labid")%>'></asp:Label>
                                </td>
                                <td width="13%">
                                    <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Patientname")%>'></asp:Label>
                                </td>
                                <td width="15%">
                                    <asp:Label ID="lblPanel" runat="server" Text='<%#Eval("Panel")%>'></asp:Label>
                                </td>
                                <td width="13%">
                                    <%-- <asp:Label ID="lblAdmNo" Visible="true" runat="server" Text='<%#Eval("adm_ref")%>' ></asp:Label>--%>
                                   <asp:Label ID="lblConsultant" Visible="true" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
                                </td>
                                <td width="10%">
                                    <asp:Label ID="lblEnteredBy" Visible="true" runat="server" Text='<%#Eval("EnteredBy")%>'></asp:Label>
                                </td>
                                <td width="7%">
                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("charges")%>'></asp:Label>
                                </td>
                                <td width="7%">
                                    <asp:Label ID="lblpaid" runat="server" Text='<%#Eval("paidamount")%>'></asp:Label>
                                </td>
                               <%-- <td width="7%">
                                    <asp:Label ID="lbldis" runat="server" Text='<%#Eval("discount_amt")%>'></asp:Label>
                                </td>
                                <td width="7%">
                                    <asp:Label ID="lblbal" runat="server" Text='<%#Eval("balance")%>'></asp:Label>
                                </td>--%>
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>



        <%--   </td>
</tr>
<tr>
<td colspan="5"></td>
<td colspan="5">--%>
        <table id="ttltable" style="background-color: #DDDDDD; display:none; font-size: 12px;" cellpadding="0"
            cellspacing="0" border="0" width="99%">
            <tr>

                <td style="width: 60%;">
                </td>
                <td style="font-weight: bold;" align="center">
                Net Total
                </td>
                <td style="font-weight: bold;" align="center">
                    Total
                </td>
                
                <td style="font-weight: bold;" align="center">
                    Paid
                </td>
                <td style="font-weight: bold;" align="center">
                    Discount
                </td>
                <td style="font-weight: bold;" align="center">
                    Refunds
                </td>
                <td style="font-weight: bold;" align="center">
                    Balance
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                <table width="100%" border="1px">
                <tr>
                <td width="100%" align="right" style="font-weight:bold"></td>
                
                </tr>
                 <tr>
                <td width="100%" align="right"> <asp:Label ID="lblNetTotal" runat="server"></asp:Label></td>
                
                </tr>
                </table>
                
                   
                </td>
                <td>
                <table width="100%" border="1px">
                <tr>
                <td width="50%" align="right" style="font-weight:bold">Panel</td>
                <td width="50%" style="font-weight:bold">Cash</td>
                </tr>
                 <tr>
                <td width="50%" align="right"> <asp:Label ID="lbltotcharges" runat="server"></asp:Label></td>
                <td width="50%"> <asp:Label ID="lblTotalchargescash" runat="server"></asp:Label></td>
                </tr>
                </table>
                
                   
                </td>
                <td>
                <table width="100%" border="1px">
                <tr>
                <td width="50%" align="right" style="font-weight:bold">Panel</td>
                <td width="50%" style="font-weight:bold">Cash</td>
                </tr>
                 <tr>
                <td width="50%" align="right"> <asp:Label ID="lbltotpaid" runat="server"></asp:Label></td>
                <td width="50%"> <asp:Label ID="lbltotpaidcash" runat="server"></asp:Label></td>
                </tr>
                </table>
                   
                </td>
                
                <td>
                <table width="100%" border="1px">
                <tr>
                <td width="50%" align="right" style="font-weight:bold">Panel</td>
                <td width="50%" style="font-weight:bold">Cash</td>
                </tr>
                 <tr>
                <td width="50%" align="right"> <asp:Label ID="lbltotdisc" runat="server"></asp:Label></td>
                <td width="50%"> <asp:Label ID="lbltotdisccash" runat="server"></asp:Label></td>
                </tr>
                </table>
                   
                </td>
                
                <td>
                <table width="100%" border="1px">
                <tr>
                <td width="50%" align="right" style="font-weight:bold">Panel</td>
                <td width="50%" style="font-weight:bold">Cash</td>
                </tr>
                 <tr>
                <td width="50%" align="right"> <asp:Label ID="lblTotalRefunds" runat="server"></asp:Label></td>
                <td width="50%"> <asp:Label ID="lblTotalRefundscash" runat="server"></asp:Label></td>
                </tr>
                </table>
                   
                </td>
               
                <td>
                <table width="100%" border="1px">
                <tr>
                <td width="50%" align="right" style="font-weight:bold">Panel</td>
                <td width="50%" style="font-weight:bold">Cash</td>
                </tr>
                 <tr>
                <td width="50%" align="right"> <asp:Label ID="lbltotbalpnl" runat="server"></asp:Label></td>
                <td width="50%"> <asp:Label ID="lbltotbalcash" runat="server"></asp:Label></td>
                </tr>
                </table>
                   
                </td>
            </tr>
        </table>
       
     
        <fieldset width="50%">
        <legend style="text-align:center">Summary</legend>
        <table width="100%" border="1px">
        <tr style="background-color:Silver">
        <td><strong>Particulars</strong></td>
        <td><strong>Cash</strong></td>
        <td><strong>Cash Panel</strong></td>
        <td><strong>Panel</strong></td>
        </tr>
        <tr>
        <td style="font-weight:bold">Gross Sale</td>
        <td>
        <asp:Label ID="lblGrossCash" runat="server"></asp:Label>
        </td>
        <td><asp:Label ID="lblGrossPanelCash" runat="server"></asp:Label></td>
        <td><asp:Label ID="lblGrossPanel" runat="server"></asp:Label></td>
        
        </tr>
        <tr>
        <td style="font-weight:bold">Discount</td>
        <td>
        <asp:Label ID="lblDisCash" runat="server"></asp:Label>
            </td>
        <td >
        <asp:Label ID="lblDisPanCash" runat="server"></asp:Label>
            </td>
        <td >
        <asp:Label ID="lblDisPanel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="font-weight:bold">Refund/ Cancelled</td>
        <td>
        <asp:Label ID="lblCanCash" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblCanPanCash" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblCanPanel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="font-weight:bold">Balance</td>
        <td>
        <asp:Label ID="lblbalCash" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblBalPanCash" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblBalPanel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="font-weight:bold">Today Amount</td>
        <td>
        <asp:Label ID="lblTotTodCash" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblTotTodPanCash" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblTotTodPanel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="font-weight:bold">Previous Balance Recieved</td>
        <td>
        <asp:Label ID="lblPreBalCash" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblPreBalPanCash" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblPreBalPanel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="40%" style="font-weight:bold">Net Recieved</td>
        <td width="20%">
        <asp:Label ID="lblNetCash" runat="server"></asp:Label>
            </td>
        <td width="20%">
        <asp:Label ID="lblNetPanCash" runat="server"></asp:Label>
            </td>
        <td width="20%">
        <asp:Label ID="lblNetPanel" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        </fieldset>
       

        <fieldset style="display:none">
        <legend>Totals:</legend>
        
        <table width="99%">
        <tr style="background-color:Silver">
        <td>S#</td>
        <td style="text-align: center">Total Sales</td>
        <td style="text-align: center">Amount </td>
        <td style="text-align: center">Discount</td>
        <td style="text-align: center">Refund</td>
        <td style="text-align: center">Paid</td>
        <td style="text-align: center">Balance</td>
        </tr>
        <tr style="background-color:Aqua">
        <td>1</td>
        <td>Panel</td>
        <td> <asp:Label ID="lbltotcharges0" runat="server"></asp:Label></td>
        <td> <asp:Label ID="lbltotdisc0" runat="server"></asp:Label></td>
        <td> <asp:Label ID="lblTotalRefunds0" runat="server"></asp:Label></td>
        <td> <asp:Label ID="lbltotpaid0" runat="server"></asp:Label></td>
        <td> <asp:Label ID="lbltotbalpnl0" runat="server"></asp:Label></td>
        </tr>
        <tr style="background-color:Lime">
        <td width="5%">2</td>
        <td width="19%">Cash</td>
        <td width="19%"> <asp:Label ID="lblTotalchargescash0" runat="server"></asp:Label></td>
        <td width="19%"> <asp:Label ID="lbltotdisccash0" runat="server"></asp:Label></td>
        <td width="19%"> <asp:Label ID="lblTotalRefundscash0" runat="server"></asp:Label></td>
        <td width="19%"> <asp:Label ID="lbltotpaidcash0" runat="server"></asp:Label></td>
        <td width="19%"> <asp:Label ID="lbltotbalcash0" runat="server"></asp:Label></td>
        </tr>
        <tr style="border:1px solid Black; background-color:ThreeDFace">
        <td width="5%">&nbsp;</td>
        <td width="19%" style="border-top:1px; border-top-color:Black">Total</td>
        <td width="19%"> <asp:Label ID="lblNetTotal0" runat="server"></asp:Label></td>
        <td width="19%"> <asp:Label ID="lblDiscTot" runat="server"></asp:Label></td>
        <td width="19%"> <asp:Label ID="lblRefundsTot" runat="server"></asp:Label></td>
        <td width="19%"> <asp:Label ID="lblPaidTot" runat="server"></asp:Label></td>
        <td width="19%"> <asp:Label ID="lblBalTotal" runat="server"></asp:Label></td>
        </tr>
        
        </table>
        </fieldset>

        <fieldset style="background-color:Aqua; display:none;">
        <legend>Panel Break Down</legend>
        <table width="99%" style=" border:0px;" >
        <tr style="background-color:Silver;">
        <td colspan="2" style="text-align: center">Panel Sales</td>
        <td style="text-align: center">Amount</td>
        <td style="text-align: center">Discount</td>
        <td style="text-align: center">Refund</td>
        <td style="text-align: center">Paid</td>
        
        </tr>
        <tr>
        <td>1.1</td>
        <td>Credit Panels</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
        <tr>
        <td>1.2</td>
        <td>Cash Panels</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
        <tr>
        <td width="5%"></td>
        <td width="19%">Total</td>
        <td width="19%"></td>
        <td width="19%"></td>
        <td width="19%"></td>
        <td width="19%"></td>
        </tr>
        </table>
        </fieldset>

        <fieldset style="background-color:Lime; display:none;">
        <legend>Cash Break Down</legend>
        <table width="99%" style=" border:0px;" >
        <tr style="background-color:Silver;">
        <td colspan="2" style="text-align: center">Panel Sales</td>
        <td style="text-align: center">Amount</td>
        <td style="text-align: center">Discount</td>
        <td style="text-align: center">Refund</td>
        <td style="text-align: center">Paid</td>
        
        </tr>
        <tr>
        <td>2.1</td>
        <td>Credit Panels</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
        <tr>
        <td>2.2</td>
        <td>Cash Panels</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
        <tr>
        <td width="5%"></td>
        <td width="19%">Total</td>
        <td width="19%"></td>
        <td width="19%"></td>
        <td width="19%"></td>
        <td width="19%"></td>
        </tr>
        </table>
        </fieldset>

        <table width="100%">
        <tr>
        <td colspan="7">
        <fieldset>
        <legend>
        Cash Panels
        </legend>
        
        <wc:ReportGridView ID="CashPanelDetails" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" OnRowDataBound="CashPanelDetails_RowDataBound" PrintPageSize="20" AllowPrintPaging="true"
            Font-Size="11px"  
            GridLines="None">
            <AlternatingRowStyle BorderStyle="None" ></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate>
                        <table id="gvtblheader" width="100%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="30%">
                                    Panel
                                </td>
                                
                                <td style="font-weight: bold;" width="10%">
                                    Gross Sale
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Discount
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Refund/Cancelled
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Balance
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                   Today's Recieved
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                   Previous Recieved
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
                                    
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("PanelName")%>'></asp:Label>
                                </td>
                               
                                <td>
                                    <asp:Label ID="lblAmount" Text='<%#Eval("rate")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDiscount" Text='<%#Eval("Discountamt")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRefund" Text='<%#Eval("refund")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblbalance"  runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaidAmountTB" Text='<%#Eval("PaidamountTB")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaidAmountPB" Text='<%#Eval("PaidamountPB")%>' runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="30%">
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
        <fieldset>
        <legend>
        Credit Panels
        </legend>

        <wc:ReportGridView ID="gvCreditPanelDetails" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" OnRowDataBound="gvCreditPanelDetails_RowDataBound" PrintPageSize="20" AllowPrintPaging="true"
            Font-Size="11px"  
            GridLines="None">
            <AlternatingRowStyle BorderStyle="None" ></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate>
                        <table id="gvtblheader" width="100%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="70%">
                                    Panel
                                </td>
                                
                                <td style="font-weight: bold;" width="10%">
                                    Gross Sale
                                </td>
                                
                                <td style="font-weight: bold;" width="10%">
                                    Refund/Cancelled
                                </td>
                                
                                <td style="font-weight: bold;" width="10%">
                                    Net Sale
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
                                    
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("PanelName")%>'></asp:Label>
                                </td>
                               
                                <td>
                                    <asp:Label ID="lblAmount" Text='<%#Eval("rate")%>' runat="server" ></asp:Label>
                                </td>
                               
                                <td>
                                    <asp:Label ID="lblRefund" Text='<%#Eval("refund")%>' runat="server" ></asp:Label>
                                </td>
                                
                                <td>
                                    <asp:Label ID="lblNetSale"  runat="server" ></asp:Label>
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
        <td colspan="7">
          <fieldset>
        <legend>
            Closed
            Cashier List
        </legend>
        
        <wc:ReportGridView ID="gvcashierlist" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="20" AllowPrintPaging="true"
            Font-Size="11px"  
            GridLines="None">
            <AlternatingRowStyle BorderStyle="None" ></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate>
                        <table id="gvtblheader" width="100%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="15%">
                                    Cashier
                                </td>
                                
                                <td style="font-weight: bold;" width="10%">
                                    Date
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Cash Received
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Balance
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Cash Refund
                                </td>
                                 <td style="font-weight: bold;" width="10%">
                                    On Account
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                   Debit Card 
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                   Credit Card 
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                   Report #
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
                                    
                                    <asp:Label ID="lblcashier" runat="server" Text='<%#Eval("cashiername")%>'></asp:Label>
                                </td>
                               <td>
                                    <asp:Label ID="lblcdate" Text='<%#Eval("enteredon")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblnetrec" Text='<%#Eval("cashClosing_Amount")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblcbalance" Text='<%#Eval("balance")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRefund" Text='<%#Eval("refund")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblonaccount" Text='<%#Eval("onaccount")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaidAmountTB" Text='<%#Eval("DebitCardAmt")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaidAmountPB" Text='<%#Eval("CreditCardAmt")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblreportno" Text='<%#Eval("reportno")%>' runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%">
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
        <tr>  <td colspan="7">
          <fieldset>
        <legend>
            Running
            Cashier List
        </legend>
        
        <wc:ReportGridView ID="GVrunningcashier" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="20" AllowPrintPaging="true"
            Font-Size="11px"  
            GridLines="None">
            <AlternatingRowStyle BorderStyle="None" ></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate>
                        <table id="gvtblheader" width="100%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="15%">
                                    Cashier
                                </td>
                                
                                <td style="font-weight: bold;" width="10%">
                                    Date
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Cash Received
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Balance
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Cash Refund
                                </td>
                                 <td style="font-weight: bold;" width="10%">
                                    On Account
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                   Debit Card 
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                   Credit Card 
                                </td>
                                <td style="font-weight: bold; display:none" width="10%">
                                   Report #
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
                                    
                                    <asp:Label ID="lblcashier" runat="server" Text='<%#Eval("cashiername")%>'></asp:Label>
                                </td>
                               <td>
                                    <asp:Label ID="lblcdate" Text='<%#Eval("enteredon")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblnetrec" Text='<%#Eval("cashClosing_Amount")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblcbalance" Text='<%#Eval("balance")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRefund" Text='<%#Eval("refund")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblonaccount" Text='<%#Eval("onaccount")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaidAmountTB" Text='<%#Eval("DebitCardAmt")%>' runat="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPaidAmountPB" Text='<%#Eval("CreditCardAmt")%>' runat="server" ></asp:Label>
                                </td>
                                <td style=" display:none ">
                                    <asp:Label ID="lblreportno" Text='<%#Eval("reportno")%>' runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%">
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
                                <td width="10%">
                                </td>
                                <td width="10%" style=" display:none; ">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>
        </fieldset>
        </td></tr>
        <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
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

</table>--%>
        <%--</fieldset>--%>
    </div>
    </form>
</body>
</html>
