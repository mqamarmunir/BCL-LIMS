<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptPanelLedger.aspx.cs" Inherits="Report_rptPanelLedger" %>
<%@ Register Assembly="Shared.WebControls" Namespace="Shared.WebControls"  TagPrefix="wc" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
   <td align="left" style="width:15%;">
            <asp:Image ID="Img_header" Visible="false" Height="50px" Width="200px"  runat="server" />
   </td>
   <td align="center" style="width:70%;padding-top:10px;">
   <p style="font-size:9px; font-weight:bold; text-align:center;">
       <asp:Label ID="Lb_BranchNames" Font-Size="18px" runat="server"></asp:Label>
       <br />
    <asp:Label ID="Label6" Font-Size="9px" Font-Bold="true" runat="server" Text="Timings:"></asp:Label> 
    <asp:Label ID="Lb_starttime" Font-Size="10px" runat="server" Text="txbx_starttime"></asp:Label>-<asp:Label ID="Lb_endtime" Font-Size="10px" runat="server" Text="txbx_endtime"></asp:Label>
  &nbsp;&nbsp;&nbsp; 
  <asp:Label ID="Label2" Font-Size="9px" Font-Bold="true" runat="server" Text="Ph No:"></asp:Label> 
  <asp:Label ID="lb_phonebranchmain" Font-Size="9px" runat="server" Text=""></asp:Label> &nbsp;
  <asp:Label ID="LB_Ext" Font-Size="9px" Font-Bold="true" runat="server" Text="Ext:" /> 
  <asp:Label ID="Lb_Extension" Font-Size="9px" runat="server" Text=""></asp:Label>
  </p> 
   </td>
   <td style="width:15%;">
     
       </td>
   </tr>
   <tr>
   <td colspan="3">
      <table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size:12px; font-family:Tahoma;">
                       <tr>
                        <td width="33%">
                            
                             &nbsp;<asp:Image ID="Image1" Width="160px" Height="20px" Visible="false" ImageUrl="barcode.jpg" runat="server" />
                        </td>
                        <td  width="33%" rowspan="2" align="center">
                           <h3>Panel Ledger</h3>
                        </td>
                        <td  width="33%" align="right">
                             <asp:Label ID="LB_txVisit" runat="server" Font-Bold="true" Visible="false" Text="Visit No:"></asp:Label>
                       
                            <asp:Label ID="Lb_Visit" Visible="false" runat="server" Text=""></asp:Label>
                        </td>
                       </tr>
                       <tr style="
    background-color: rgb(138, 135, 135);
">
                            <td><asp:Label ID="lblPanelNametext" Font-Size="Medium" runat="server" Font-Bold="true" Text="Client"></asp:Label>
                       
                                :&nbsp;&nbsp;&nbsp;
                       
                             <asp:Label ID="lblPanelName" Font-Bold="true" Font-Size="Medium" runat="server" ></asp:Label>
                            </td>
                           
                            <td align="right" style="visibility:hidden;"><asp:Image ID="Image2" Width="160px" Height="20px" ImageUrl="~/transaction/barcode.jpg" runat="server" /></td>
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

</td>
</tr>
</table>
   <%-- <fieldset style="border-radius:10px;">--%>
  <%--  <table id="tblxxx" width="99%">
<tr>
<td colspan="10">--%>

        <wc:ReportGridView ID="gvMain"   runat="server"  Width="99%" ShowHeader="true" AutoGenerateColumns="false" 
        AlternatingRowStyle-BorderStyle="None" PrintPageSize="16" AllowPrintPaging="true" Font-Size="11px" DataKeyNames="bookingid,LabShare" OnRowDataBound="gvMain_RowDataBound" GridLines="None">
        <HeaderStyle BackColor="#CCCCCC" HorizontalAlign="Left" />
        <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
        <Columns>
        
         <asp:TemplateField>
         <HeaderTemplate>
         
         <table id="gvtbl" width="100%">
         <tr style="background-color:#DDDDDD">
         <td style="font-weight:bold;" width="2%">S#</td>
         <td style="font-weight:bold;" width="10%">Lab ID</td>
         <td style="font-weight:bold;" width="13%">Booked On</td>
          <td style="font-weight:bold;" width="10%">Patient Name</td>
         <%--<td style="font-weight:bold;" width="8%">Type</td>
         <td style="font-weight:bold;" width="10%">Ward</td>
         <td style="font-weight:bold;" width="9%">Bed</td>--%>
         <td style="font-weight:bold;" width="5%">Total</td>
         <td style="font-weight:bold;" width="5%">Paid</td>
         <td style="font-weight:bold;" width="20%">Test</td>
         <td style="font-weight:bold;" width="5%">Charges</td>
         <td style="font-weight:bold;" width="5%">Discount</td>
         <td style="font-weight:bold;" width="5%">Balance</td>
         <td style="font-weight:bold;" width="10%">Entered By</td>
         </tr>
         </table>
         
         </HeaderTemplate>
         <ItemTemplate>
         <table width="100%">
         <tr>
         <td>
            <asp:Label ID="lbldate" runat="server" Text='<%#Container.DataItemIndex+1 %>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("labid")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblBookedOn" runat="server" Text='<%#Eval("enteredon")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblpatName" runat="server" Text='<%#Eval("patientName")%>' ></asp:Label>
         </td>
        
         <td>
            <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("totalamount")%>'  ></asp:Label>
         </td>
       <td>
            <asp:Label ID="lblpaid" runat="server" Text='<%#Eval("paidamount")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblTestName" runat="server" Text='<%#Eval("testname")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblCharges" runat="server" Text='<%#Eval("testcharges")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lbldis" runat="server" Text='<%#Eval("discount_amt")%>' ></asp:Label>
         </td>
        <td>
            <asp:Label ID="lblbal" runat="server" Text='<%#Eval("balance")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="Label1" runat="server" Text='<%#Eval("EnteredBy")%>' ></asp:Label>
         </td>
         </tr>
         
        
         <tr>
         <td></td>
         <td colspan="6">
            <asp:GridView GridLines="None" Visible="false" style="border:1px dotted #BBBBBB;" ID="gvInvestigations" DataKeyNames="LabShare" Width="100%" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField HeaderText="Investigation Detail:" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="85%" DataField="Test_Name" />
                <asp:BoundField HeaderText="" DataField="Charges" HeaderStyle-Width="15%" />
                

            </Columns>
            </asp:GridView>
         </td>
         </tr>
         <tr>
         <td width="2%"></td>
         <td width="10%"></td>
         <td width="13%"></td>
         <td width="10%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="20%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="5%"></td>
         <td width="10%"></td>
         </tr>
         
         </table>
                
            </ItemTemplate>
            </asp:TemplateField>
            
            
        </Columns>
        </wc:ReportGridView>
     <%--   </td>
</tr>
<tr>
<td colspan="5"></td>
<td colspan="5">--%>
<table id="ttltable"  style="background-color:#DDDDDD; font-size:12px;" cellpadding="0" cellspacing="0" border="0" width="99%">
    <tr>
    <td style="width:70%;"></td>
    <td style="font-weight:bold;">Total</td>
    <td style="font-weight:bold;">Paid</td>
    <td style="font-weight:bold;">Discount</td>
    <td style="font-weight:bold;">Balance</td>
    <td style="font-weight:bold;">&nbsp;</td>
    </tr>
    <tr>
    <td></td>
    <td>
            <asp:Label ID="lbltotcharges" runat="server"></asp:Label>
    </td>
    <td>
            <asp:Label ID="lbltotpaid" runat="server"></asp:Label>
    </td>
    <td>
            <asp:Label ID="lbltotdisc" runat="server"></asp:Label>
            </td>
    <td>
            <asp:Label ID="lbltotbal" runat="server"></asp:Label>
    </td>
    <td>
            &nbsp;</td>
    </tr>


    <tr>
    <td colspan="5">
    <h2>Total Payable Amount:</h2>
    <hr />
    <h2>
    <asp:Label ID="lblTotAmountPayable" runat="server"></asp:Label>
        
    </h2>
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

</table>--%>
    <%--</fieldset>--%>
    </div>
    </form>
</body>
</html>
