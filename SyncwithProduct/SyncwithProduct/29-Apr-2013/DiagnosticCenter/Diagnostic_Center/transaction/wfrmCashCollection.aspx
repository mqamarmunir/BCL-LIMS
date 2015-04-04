<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCashCollection.aspx.cs" Inherits="wfrmCashCollection" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Cash Collection</h2>
                
         <asp:Label ID="Lb_Saved" runat="server" Font-Size="11px" ForeColor="#0066FF"></asp:Label>
                    <br />
<fieldset style="border-radius:10px;">
      <asp:GridView Width="100%" Font-Size="11px" style="font-family:Tahoma;" 
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
                                                <asp:Label ID="Lb_patientNameValue" runat="server" Text='<%# Eval("patient")  %>'></asp:Label>
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
                                            <asp:Label ID="Lb_txPassword" runat="server" Font-Bold="true" Text="Password:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Password" runat="server" Text='<%# Eval("Pasword")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                            <td>
                                                <asp:Label ID="Lb_txPhone" runat="server" Font-Bold="true" Text="Phone:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("cellno")  %>'></asp:Label>
                                            </td>
                                    </tr>
                                </table>
                        </td>
                        <td align="right">
                                 <table cellpadding="2" cellspacing="2">
                                  <tr>
                                        <td>
                                            <asp:Label ID="Lb_txRegDate" runat="server" Font-Bold="true" Text="Booking Order:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_RegDate" runat="server" Text='<%# Eval("enteredon")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txCollectAt" runat="server" Font-Bold="true" Text="Report Delivery:"></asp:Label>
                                            <asp:Label ID="Lbl_info" runat="server" Font-Size="6px" ForeColor="Red" Font-Bold="true" Text="1"></asp:Label>
                                        
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_CollectAt" runat="server" Text='<%# Eval("deliverytime") %>'></asp:Label>
                                       
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txConsultant" runat="server" Font-Bold="true" Text="Referred By:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Consultant" runat="server"  Text='<%# Eval("consultant") %>'></asp:Label>
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
<fieldset style="border-radius:10px;">        
        <asp:GridView GridLines="None" Font-Size="11px" 
            style="font-family:Tahoma;"  ID="Gv_PatientReceipt" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="2" ForeColor="#333333">
           
            <RowStyle BackColor="#D1EED6" />
           
        <Columns>
            <asp:TemplateField HeaderText="Sr No#">
                <ItemTemplate>
                              <asp:Label ID="Lbl_Serial" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="testname" HeaderText="Investigation" />
            <asp:BoundField DataField="speedkey" Visible="false" HeaderText="Test Code" />
            <asp:BoundField DataField="deliverytime" HeaderText="Reporting Date/Time" />
            <asp:BoundField DataField="charges" HeaderText="Charges" />
            
        </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>        
</fieldset>


<table width="100%" border="0">
<tr>
    <td style="width:50%;">
    <table border="0" style="font-size:12px; font-family:Tahoma;">
                      <tr>
                        <td>
                             <asp:Label ID="Lb_txPRNo" runat="server" Text="Pr No:"></asp:Label>
                       </td>
                       <td>
                            <%-- <asp:Label ID="Lb_PRNO" runat="server" Text=""></asp:Label>
                             --%><asp:TextBox CssClass="input_text" ID="TxBx_Prno" runat="server" 
                                ReadOnly="True"></asp:TextBox>
                       </td>
                      </tr>
                      <tr>
                         <td >
                             <asp:Label ID="LB_txVisit" runat="server"  Text="Visit No:"></asp:Label>
                         </td>
                         <td>
                             <%--<asp:Label ID="Lb_Visit" runat="server" Text=""></asp:Label>
                             --%><asp:TextBox CssClass="input_text" ID="TxBx_Visit" runat="server" 
                                 ReadOnly="True"></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                       <td>
                           <asp:Label ID="Label7" runat="server" Text="Enter Paid Amount:"></asp:Label>
                          </td>
                       <td><asp:TextBox ID="TxBx_PaidAmount" CssClass="input_text" runat="server"></asp:TextBox></td>
                       <td><asp:ImageButton ID="Btn_Paid" ToolTip="Pay Now" 
                               ImageUrl="images/payment.jpeg" Width="25px" Height="20px" runat="server" 
                               onclick="Btn_Paid_Click" /></td>
                      </tr>
                      <tr>
                       <td colspan="2">
                           <asp:Label ID="Lb_AmoutOver" runat="server" Font-Size="9px" ForeColor="Red"></asp:Label>
                          </td>
                       <td>&nbsp;</td>
                      </tr>
                      </table>
    
    </td>
    
    <td style="width:50%;">
               <asp:GridView Font-Size="11px" style="font-family:Tahoma;"   Width="100%" ID="Gv_paymentModule" runat="server" 
            AutoGenerateColumns="False" GridLines="None" >
        <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <table width="76%">
           <tr>
                <td align="right">
                    <asp:Label ID="Lb_Total" Font-Bold="true" runat="server"  Text="Total Amount:"></asp:Label>
                    <asp:Label ID="Lb_totalAmount" runat="server"  Text='<%# Eval("totalamount") %>'></asp:Label>
                </td>
            </tr>
            <tr>
               <td align="right">
               <br />
                 <asp:Label  Font-Bold="true" ID="Lb_thisPayment" runat="server" Text="Discount Amount:"></asp:Label>
                 <asp:Label  ID="Label6"  runat="server"  Text='<%# Eval("discount_amt") %>'></asp:Label>
               </td>
            </tr>
            <tr>
               <td align="right">
                 <asp:Label Font-Bold="true" ID="Lb_totalPayment" runat="server" Text="Paid Amount:"></asp:Label>
                 <asp:Label ID="lb_totalpaid"  runat="server"  Text='<%# Eval("totalpaid") %>'></asp:Label>
               </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label Font-Bold="true" ID="Lb_Balance" runat="server" Text="Balance:"></asp:Label>
                    <asp:Label  ID="Lb_bal" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </table>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
    </td>
</tr>
</table>
       <%-- <table style="font-size:10px; font-family:Tahoma; color:Red;">
                <tr>
                    <td align="center">
                    <fieldset>
                        <ol><li>On delivery date all the reports will ready for delivery.</li></ol>
                        </fieldset>
                    </td>
                </tr>
         </table>--%>

</asp:Content>

