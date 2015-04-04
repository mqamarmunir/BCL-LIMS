<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmCashRefundReport.aspx.cs" Inherits="transaction_wfrmCashRefundReport" %>

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
   <p style="font-size:18px; font-weight:bold; text-align:center;">
       <asp:Label ID="Lb_BranchNames" runat="server"></asp:Label>
       <br />
    <asp:Label ID="Label6" Font-Size="9px" Font-Bold="true" runat="server" Text="Timings:"></asp:Label> <asp:Label ID="Lb_starttime" Font-Size="10px" runat="server" Text="txbx_starttime"></asp:Label>-<asp:Label ID="Lb_endtime" Font-Size="10px" runat="server" Text="txbx_endtime"></asp:Label>&nbsp; <asp:Label ID="Label2" Font-Size="9px" Font-Bold="True" runat="server" 
               Text="Ph No:"></asp:Label> <asp:Label ID="lb_phonebranchmain" Font-Size="9px" runat="server" Text=""></asp:Label> &nbsp;<asp:Label ID="LB_Ext" Font-Size="9px" Font-Bold="true" runat="server" Text="Ext:" /> <asp:Label ID="Lb_Extension" Font-Size="9px" runat="server" Text=""></asp:Label>&nbsp;</p>
   </td>
   <td style="width:15%;"></td>
   </tr>
   </table>
   
                <table width="100%" border="0" style="font-size:14px; font-family:Tahoma;">
                       <tr>
                        <td>
                             &nbsp;<asp:Label ID="Lb_txPRNo" runat="server" Font-Bold="true" Text="Pr No:"></asp:Label>
                       
                             <asp:Label ID="Lb_PRNO" runat="server" Text=""></asp:Label>
                        </td>
                        <td rowspan="2" align="center">
                           <h3>Refund Slip</h3>
                        </td>
                        <td align="right">
                             <asp:Label ID="LB_txVisit" runat="server" Font-Bold="true" Text="Visit No:"></asp:Label>
                       
                            <asp:Label ID="Lb_Visit" runat="server" Text=""></asp:Label>
                        </td>
                       </tr>
                       <tr>
                            <td><asp:Image ID="Image1" Width="160px" Height="20px" ImageUrl="barcode.jpg" runat="server" /></td>
                           
                            <td align="right"><asp:Image ID="Image2" Width="160px" Height="20px" ImageUrl="~/transaction/barcode.jpg" runat="server" /></td>
                       </tr>
                    </table>
<%--<table width="100%"><tr><td align="center"><h3>Receipt</h3></td></tr></table>
--%>
<fieldset style="border-radius:10px;">
      <asp:GridView Width="100%" Font-Size="12px" style="font-family:Tahoma;" 
                ID="Gv_PatientPrimaryInfo" runat="server" 
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
                                                <asp:Label ID="Lb_txPatientName" runat="server" Font-Bold="true" Text="Patient Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lb_patientNameValue" runat="server" Text='<%# Eval("patient")  %>'></asp:Label>
                                                <%--&nbsp;-&nbsp;   <asp:Label ID="Lb_AgeSex" runat="server" Text='<%# Eval("gender")  %>'></asp:Label>
                                                   / <asp:Label ID="Lb_DOB" runat="server" Text='<%# Eval("age")  %>'></asp:Label>--%>
                                            </td>
                                    </tr>
                                    <tr>
                                                <td>
                                                    <asp:Label ID="Lb_txAgeSex" runat="server" Font-Bold="true" Text="Age / Gender:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Lb_AgeSex" runat="server" Text='<%# Eval("gender")  %>'></asp:Label>
                                                   / <asp:Label ID="Lb_DOB" runat="server" Text='<%# Eval("age")  %>'></asp:Label>
                                                </td>
                                    </tr>
                                    <tr>
                                            <td>
                                                <asp:Label ID="Lb_txPhone" runat="server" Font-Bold="true" Text="Phone"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:Label ID="lb_cells" runat="server" Text='<%# Eval("cellno")  %>'></asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                                 <td>
                                                   <asp:Label ID="lb_txemails" runat="server" Font-Bold="true" Text="Email:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lb_email" runat="server" Text='<%# Eval("email")  %>'></asp:Label>
                                                </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txPassword" runat="server" Font-Bold="true" Text="Address:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Password" runat="server" Text='<%# Eval("address")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    
                                </table>
                        </td>
                        <td align="right">
                                 <table cellpadding="2" cellspacing="2">
                                  <tr>
                                        <td>
                                            <asp:Label ID="Lb_txRegDate" runat="server" Font-Bold="true" Text="Registration Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_RegDate" runat="server" Text='<%# Eval("registering")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Discount Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("refundtype")  %>'></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txCollectAt" runat="server" Font-Bold="true" Text="Refund No:"></asp:Label>
                                            <%--<asp:Label ID="Lbl_info" runat="server" Font-Size="6px" ForeColor="Red" Font-Bold="true" Text="1"></asp:Label>
                                        --%>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_CollectAt" runat="server" Text='<%# Eval("refundno") %>'></asp:Label>
                                       
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txConsultant" runat="server" Font-Bold="true" Text="Refund On:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Consultant" runat="server"  Text='<%# Eval("receivedon") %>'></asp:Label>
                                        </td>
                                    </tr>
                                 </table>
                        </td>
                      </tr>
                      </table>
                    
                      <table style="display:none;">
                            <tr>
                                <th colspan="2" align="left">Online Access : &nbsp;  <asp:Label ID="Lb_url" runat="server" Font-Size="10px" Font-Bold="true" Text="Url:"></asp:Label><asp:Label ID="lb_urlpath" runat="server" Font-Size="10px" Text="www.BioCareLabs.org"></asp:Label>
                                 </th>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Lb_txPRNoGv" runat="server" Font-Size="10px" Font-Bold="true" Text="Username:"></asp:Label>
                                        <asp:Label ID="Lb_PRNOGv" runat="server" Font-Size="10px" Text='<%# Eval("prno")  %>'></asp:Label>   
                                        &nbsp;&nbsp;
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" Font-Size="10px" Font-Bold="true" Text="Password:"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Font-Size="10px" Text='<%# Eval("Pasword")  %>'></asp:Label>
                                        
                                </td>
                                <td align="right" style="font-size:9px; font-weight:bold;">
                               &nbsp;&nbsp;&nbsp;(Login Instructions:&nbsp;
                                <asp:Label ID="Label7" runat="server" Font-Size="9px" Text=" Visit website www.biocarelab.org and enter your username and password to view your report."></asp:Label>
                                )    
                                </td>
                            </tr>
                      </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
          <HeaderStyle Wrap="True" />
        </asp:GridView>
</fieldset>
<br />

<fieldset style="border-radius:12px;">        
        <asp:GridView GridLines="None" Font-Size="11px" 
            style="font-family:Tahoma;"  ID="Gv_PatientReceipt" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="2" ForeColor="#333333">
           
            <RowStyle BackColor="#D1EED6" />
           
        <Columns>
            <asp:TemplateField HeaderText="Serial">
                <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="30%" DataField="testname" HeaderText="Investigation" />
            <asp:BoundField ItemStyle-Width="25%" DataField="totalamount" HeaderText="Rate" />
            <asp:BoundField ItemStyle-Width="25%" DataField="paidamount" HeaderText="Refund Amount" />
        </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>       
        <table width="100%" border="0">
           <tr>
                <td align="left" width="67%">
                       
                </td>
                <td >
                <div style="border-top: thin solid black; border-bottom: thin solid black;  height:5px; width:160px;">
                
                </div>
                      
                </td>
            </tr>
            <tr>
                <td align="left" width="67%">
                        <asp:Label ID="Lb_Entered" Font-Size="11px" Font-Bold="true" Text="Entered :" runat="server" ></asp:Label>
                        <asp:Label ID="Lb_EnteredBy" Font-Size="10px" runat="server" ></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="Lb_auth" Font-Size="11px" Font-Bold="true" Text="Authorized :" runat="server" ></asp:Label>
                        <asp:Label ID="Lb_Authorized" Font-Size="10px" runat="server" ></asp:Label>
                </td>
                <td width="33%">
                        <asp:Label ID="lb_TX_totalDiscount" Font-Size="16px" Font-Bold="true" Text="Amount :" runat="server" ></asp:Label>
                        <asp:Label ID="Lb_TotalDiscount" Font-Size="16px" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label ID="lb_booked" runat="server" Text="Booked Test"></asp:Label>
         <asp:GridView GridLines="None" Font-Size="10px" 
            style="font-family:Tahoma;"  ID="Gv_Receipt" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="2" ForeColor="#333333">
            <RowStyle BackColor="#D1EED6" />
        <Columns>
            <asp:TemplateField HeaderText="Serial">
                <ItemTemplate>
                              <%# Container.DataItemIndex+1 %>
                              <asp:Label ID="Lbl_Serial2" runat="server" Visible="false" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="testname" HeaderText="Investigation" />
            <asp:BoundField DataField="deliverytime" HeaderText="Reporting Date/Time" />
            <asp:BoundField DataField="charges" HeaderText="Actual Charges" />
             <asp:BoundField DataField="discount" HeaderText="Discounted Charges" />
            
        </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>   


</fieldset>

 <asp:Image ID="Img_footer" Visible="false" Width="100%" runat="server" />
    </div>
    </form>
</body>
</html>
