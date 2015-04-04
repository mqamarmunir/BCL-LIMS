<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmIndoorpatientsreport.aspx.cs" Inherits="Report_wfrmIndoorpatientsreport" %>
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
                            
                             &nbsp;<asp:Label ID="Lb_txPRNo" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                       
                             <asp:Label ID="Lb_PRNO" runat="server" Text=""></asp:Label>
                        </td>
                        <td rowspan="2" align="center">
                           <h3>Patient Indoor Summary</h3>
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
<fieldset style="border-radius:10px;">

      <asp:GridView Width="100%" Font-Size="11px" style="font-family:Tahoma; color:Black;" 
                ID="Gv_PatientPrimaryInfo" runat="server" 
            AutoGenerateColumns="False" ShowHeader="False" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                      <table width="100%">
                      <tr>
                        <td>
                                <table cellpadding="2" cellspacing="2">
                                    <tr>
                                            <td>
                                                <asp:Label ID="Lb_txPatientName" runat="server" Font-Bold="true" Text="Patient Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lb_patientNameValue" runat="server" Text='<%# Eval("name")  %>'></asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                                 <td>
                                                    <asp:Label ID="Lb_txAgeSex" runat="server" Font-Bold="true" Text="Age / Gender:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Lb_DOB" runat="server" Text='<%# Eval("age")  %>'></asp:Label>
                                                   / <asp:Label ID="Lb_AgeSex" runat="server" Text='<%# Eval("gender")  %>'></asp:Label>
                                                   
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
--%>                                    <tr>
                                            <td>
                                                <asp:Label ID="Lb_txPhone" runat="server" Font-Bold="true" Text="Phone No:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("phoneNo")  %>'></asp:Label>
                                            </td>
                                    </tr>
                                </table>
                        </td>
                        <td align="right">
                                 <table cellpadding="2" cellspacing="2">
                                  <tr>
                                        <td>
                                            <asp:Label ID="Lb_txRegDate" runat="server" Font-Bold="true" Text="Reg. Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_RegDate" runat="server" Text='<%# Eval("registrationDate")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txCollectAt" runat="server" Font-Bold="true" Text="Panel:"></asp:Label>
                                           <%-- 
                                           <asp:Label ID="Lbl_info" runat="server" Font-Size="6px" ForeColor="Red" Font-Bold="true" Text="1"></asp:Label>
                                        --%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_CollectAt" runat="server" Text='<%# Eval("panel") %>'></asp:Label>
                                       
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txConsultant" runat="server" Visible="false" Font-Bold="true" Text="Referred By:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Consultant" runat="server" Visible="false"  Text='<%# Eval("consultant") %>'></asp:Label>
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

        <wc:ReportGridView ID="gvMain"   runat="server"  Width="99%" ShowHeader="false" AutoGenerateColumns="false" 
        AlternatingRowStyle-BorderStyle="None" PrintPageSize="2" AllowPrintPaging="true" Font-Size="11px" DataKeyNames="bookingid" OnRowDataBound="gvMain_RowDataBound" GridLines="None">
        <HeaderStyle BackColor="#CCCCCC" />
        <AlternatingRowStyle BorderStyle="None"></AlternatingRowStyle>
        <Columns>
         <asp:TemplateField>
         <ItemTemplate>
         <table id="gvtbl" width="99%">
         <tr style="background-color:#DDDDDD">
         <td style="font-weight:bold;" width="10%">Date</td>
         <td style="font-weight:bold;" width="15%">Lab ID</td>
         
         <td style="font-weight:bold;" width="8%">Type</td>
         <td style="font-weight:bold;" width="10%">Ward</td>
         <td style="font-weight:bold;" width="9%">Bed</td>
         <td style="font-weight:bold;" width="10%">Total</td>
         <td style="font-weight:bold;" width="10%">Paid</td>
         <td style="font-weight:bold;" width="10%">Charges</td>
         <td style="font-weight:bold;" width="8%">Discount</td>
         <td style="font-weight:bold;" width="10%">Balance</td>
         </tr>

         <tr>
         <td>
            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("bookedon")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("labid")%>' ></asp:Label>
         </td>
        <td>
            <asp:Label ID="lblType" runat="server" Text='<%#Eval("ind_outdoor")%>' ></asp:Label>
         </td>
         <td>
            <asp:Label ID="lblWard" runat="server" Text='<%#Eval("ward")%>' ></asp:Label>
         </td>
        <td>
           <%-- <asp:Label ID="lblAdmNo" Visible="true" runat="server" Text='<%#Eval("adm_ref")%>' ></asp:Label>--%>
            <asp:Label ID="lb_Bed" Visible="true" runat="server" Text='<%#Eval("bed")%>' ></asp:Label>
         </td>
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
         </td>
         </tr>
        
         <tr>
         <td></td>
         <td colspan="7">
            <asp:GridView GridLines="None" style="border:1px dotted #BBBBBB;" ID="gvInvestigations" Width="99%" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField HeaderText="Investigation Detail:" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="88%" DataField="Test_Name" />
                <asp:BoundField HeaderText="" DataField="Charges" HeaderStyle-Width="12%" />

            </Columns>
            </asp:GridView>
         </td>
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
