<%@ Page Language="C#" AutoEventWireup="true" CodeFile="salesdetails_report.aspx.cs" Inherits="transaction_salesdetails_report" %>
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
                        <td>
                            
                             &nbsp;<asp:Label ID="Lb_txPRNo" Visible="false" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                       
                             <asp:Label ID="Lb_PRNO" Visible="false" runat="server" Text=""></asp:Label>
                        </td>
                        <td rowspan="2" align="center">
                           <h3>Sales Details</h3>
                        </td>
                        <td align="right">
                             <asp:Label ID="LB_txVisit" runat="server" Font-Bold="true" Visible="false" Text="Visit No:"></asp:Label>
                       
                            <asp:Label ID="Lb_Visit" Visible="false" runat="server" Text=""></asp:Label>
                        </td>
                       </tr>
                       <tr>
                            <td><asp:Image ID="Image1" Width="160px" Height="20px" ImageUrl="barcode.jpg" runat="server" /></td>
                           
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
        AlternatingRowStyle-BorderStyle="None" PrintPageSize="5" AllowPrintPaging="true" Font-Size="11px" DataKeyNames="bookingid,panelid,cashpanel" OnRowDataBound="gvMain_RowDataBound" GridLines="None">
        <HeaderStyle BackColor="#CCCCCC" />
        <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
        <Columns>
         <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
         <HeaderTemplate>
         <table width="100%">
         <tr style="background-color:#DDDDDD">
         <td style="font-weight:bold;" width="10%">Date</td>
         <td style="font-weight:bold;" width="20%">Patient Info</td>
         <td style="font-weight:bold;" width="15%">Lab ID</td>
         
         <td style="font-weight:bold;" width="8%">Type</td>
         <%--<td style="font-weight:bold;" width="10%">Ward</td>
         <td style="font-weight:bold;" width="9%">Bed</td>--%>
         <td style="font-weight:bold;" width="10%">Total</td>
         <td style="font-weight:bold;" width="10%">Paid</td>
         <td style="font-weight:bold;" width="10%">Charges</td>
         <td style="font-weight:bold;" width="8%">Discount</td>
         <td style="font-weight:bold;" width="10%">Balance</td>
         </tr>
         </table>
         </HeaderTemplate>
         <ItemTemplate>
         <table id="gvtbl" width="100%">
        

         <tr>
         <td>
            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("bookedon")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="Label1" runat="server" Text='<%#Eval("PatientInfo")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("labid")%>' ></asp:Label>
         </td>
        <td>
            <asp:Label ID="lblType" runat="server" Text='<%#Eval("ind_outdoor")%>' ></asp:Label>
         </td>
         <%--<td>
            <asp:Label ID="lblWard" runat="server" Text='<%#Eval("ward")%>' ></asp:Label>
         </td>--%>
      <%-- <td>
           <asp:Label ID="lblAdmNo" Visible="true" runat="server" Text='<%#Eval("adm_ref")%>' ></asp:Label>
            <asp:Label ID="lb_Bed" Visible="true" runat="server" Text='<%#Eval("bed")%>' ></asp:Label>
         </td>--%>
         <td>
            <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("charges")%>' ></asp:Label>
         </td>
       <td>
            <asp:Label ID="lblpaid" runat="server" Text='<%#Eval("paidamount")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblCharges" runat="server" Text="" ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lbldis" runat="server" Text='<%#Eval("discount_amt")%>' ></asp:Label>
         </td>
        <td>
            <asp:Label ID="lblbal" runat="server" Text='<%#Eval("balance")%>' ></asp:Label>
            <br />
            <asp:Label ID="lblbshare" Visible="false" runat="server"  ></asp:Label>
            <asp:Label ID="lblpanel" runat="server" Visible="false" Text='<%#Eval("panelname")%>' ></asp:Label>
             <asp:Label ID="lblrefund" Visible="false" runat="server"  ></asp:Label>
         </td>
         </tr>
        
         <tr>
         <td></td>
         <td colspan="6">
            <asp:GridView GridLines="None" style="border:1px dotted #BBBBBB;" ID="gvInvestigations" Width="99%" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField HeaderText="Investigation Detail:" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="78%" DataField="Test_Name" />
                <asp:BoundField HeaderText="BranchShare" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" DataField="BranchShare" />
                <asp:BoundField HeaderText="" DataField="Charges" HeaderStyle-Width="12%" />

            </Columns>
            </asp:GridView>
         </td>
         </tr>
         
          <tr style="background-color:#DDDDDD">
         <td style="font-weight:bold;" width="10%"></td>
         <td style="font-weight:bold;" width="20%"></td>
         <td style="font-weight:bold;" width="15%"></td>
         
         <td style="font-weight:bold;" width="8%"></td>
         <%--<td style="font-weight:bold;" width="10%">Ward</td>
         <td style="font-weight:bold;" width="9%">Bed</td>--%>
         <td style="font-weight:bold;" width="10%"></td>
         <td style="font-weight:bold;" width="10%"></td>
         <td style="font-weight:bold;" width="10%"></td>
         <td style="font-weight:bold;" width="8%"></td>
         <td style="font-weight:bold;" width="10%"></td>
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
    <fieldset width="50%" style="display:block">
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
        <td style="font-weight:bold">Net Sale</td>
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
        <td style="font-weight:bold">Branch share</td>
        <td>
        <asp:Label ID="lblBShare" runat="server"></asp:Label>
            </td>
        <td>
        <asp:Label ID="lblBPCShare" runat="server"></asp:Label>
            </td>

        <td>
        <asp:Label ID="lblBPShare" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        </fieldset>


<table id="ttltable"  style="background-color:#DDDDDD; font-size:12px;" cellpadding="0";  cellspacing="0" border="0" width="99%">
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
