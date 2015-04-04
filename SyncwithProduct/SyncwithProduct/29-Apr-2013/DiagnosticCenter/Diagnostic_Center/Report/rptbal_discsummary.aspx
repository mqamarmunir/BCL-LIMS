<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptbal_discsummary.aspx.cs" Inherits="Report_rptbal_discsummary" %>
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
   <td align="center" style="width:70%;">
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
                           <h3>Balance and Discount Summary</h3>
                        </td>
                        <td  width="33%" align="right">
                       
                            <asp:Label ID="Lb_Visit" Visible="false" runat="server" Text=""></asp:Label>
                        </td>
                       </tr>
                       <tr>
                            <td>
                       
                             <asp:Label ID="lblCashPatients" Font-Bold="true" Text="Cash Patients" BackColor="Silver" Font-Size="Medium" runat="server" ></asp:Label>
                            </td>
                           
                            <td align="right" >
                             <asp:Label ID="lblBranch" runat="server" Font-Bold="true" BackColor="Silver" Visible="true"></asp:Label>
                       
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

</td>
</tr>
</table>
   <%-- <fieldset style="border-radius:10px;">--%>
  <%--  <table id="tblxxx" width="99%">
<tr>
<td colspan="10">--%>

        <wc:ReportGridView ID="gvMain"   runat="server"  Width="99%" ShowHeader="true" AutoGenerateColumns="false" 
        AlternatingRowStyle-BorderStyle="None" PrintPageSize="20" AllowPrintPaging="true" Font-Size="11px" OnRowDataBound="gvMain_RowDataBound" GridLines="None">
        <HeaderStyle BackColor="#CCCCCC" HorizontalAlign="Left" />
        <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
        <Columns>
        
         <asp:TemplateField>
         <HeaderTemplate>
         
         <table id="gvtbl" width="99%">
         <tr style="background-color:#DDDDDD">
         <td style="font-weight:bold;" width="5%">S#</td>
         <td style="font-weight:bold;" width="10%">Entry Date Time</td>
         
         <td style="font-weight:bold;" width="8%">PR No.</td>
         <td style="font-weight:bold;" width="10%">Visit No</td>
         <td style="font-weight:bold;" width="10%">Patient Name</td>
         <td style="font-weight:bold;" width="10%">Location</td>
         <td style="font-weight:bold;" width="10%">Entered By</td>
         <td style="font-weight:bold;" width="10%">Total</td>
         <td style="font-weight:bold;" width="7%">Paid</td>
         <td style="font-weight:bold;" width="10%">Discount</td>
         <td style="font-weight:bold;" width="10%">Balance</td>
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
            <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("enteredon")%>' ></asp:Label>
         </td>
        <td>
            <asp:Label ID="lblType" runat="server" Text='<%#Eval("PRNO")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblWard" runat="server" Text='<%#Eval("Labid")%>' ></asp:Label>
         </td>
         <td>
           
            <asp:Label ID="Label1" Visible="true" runat="server" Text='<%#Eval("PatientName")%>' ></asp:Label>
         </td>
        <td>
           
            <asp:Label ID="lb_Bed" Visible="true" runat="server" Text='<%#Eval("BranchName")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblentryper" runat="server" Text='<%#Eval("enteredby")%>'  ></asp:Label>
         </td>
       <td>
            <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("totalamount")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblPaid" runat="server" Text='<%#Eval("paidamount")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lbldis" runat="server" Text='<%#Eval("discount_amt")%>' ></asp:Label>
         </td>
        <td>
            <asp:Label ID="lblbal" runat="server" Text='<%#Eval("balance")%>' ></asp:Label>
         </td>
         </tr>
         
        
         
         <tr>
         <td width="5%"></td>
         <td width="10%"></td>
         <td width="8%"></td>
         <td width="10%"></td>
         <td width="10%"></td>
         <td width="10%"></td>
         <td width="10%"></td>
         <td width="10%"></td>
         <td width="7%"></td>
         <td width="10%"></td>
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