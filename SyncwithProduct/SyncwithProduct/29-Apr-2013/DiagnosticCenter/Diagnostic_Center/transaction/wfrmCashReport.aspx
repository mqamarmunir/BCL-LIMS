<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmCashReport.aspx.cs" Inherits="transaction_wfrmCashReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Cash Report</title>
 <style type="text/css">
#watermark {
  color: #DDDDDD;
  font-size: 70px;
  -webkit-transform: rotate(-45deg);
  -moz-transform: rotate(-45deg);
  position: absolute;
  width: 80%;
  height: 80%;
  margin: 0;
  z-index: -1;
  left:200px;
  top:120px;
}
</style>

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
            <%--<asp:Image ID="Image3" Visible="true" ImageUrl="~/transaction/headerfooter/BCL LOGO.jpg" Height="50px" Width="200px"  runat="server" />
--%>   </td>
   <td align="center" style="width:70%;">
   <p style="font-size:9px; font-weight:bold; text-align:center;">
       <asp:Label ID="Lb_BranchNames" Font-Size="18px" runat="server"></asp:Label>
       <br />
    <asp:Label ID="Label6" Font-Size="9px" Font-Bold="true" runat="server" Text="Timings:"></asp:Label> <asp:Label ID="Lb_starttime" Font-Size="10px" runat="server" Text="txbx_starttime"></asp:Label>-<asp:Label ID="Lb_endtime" Font-Size="10px" runat="server" Text="txbx_endtime"></asp:Label>
  &nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" Font-Size="9px" Font-Bold="true" runat="server" Text="Ph No:"></asp:Label> <asp:Label ID="lb_phonebranchmain" Font-Size="9px" runat="server" Text=""></asp:Label> &nbsp;<asp:Label ID="LB_Ext" Font-Size="9px" Font-Bold="true" runat="server" Text="Ext:" /> <asp:Label ID="Lb_Extension" Font-Size="9px" runat="server" Text=""></asp:Label>
  </p> 
   </td>
   <td style="width:15%;">
       <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
           Visible="False" />
       </td>
   </tr>
   </table>


            <%--(<asp:Label ID="Lb_starttime" Font-Size="7px" runat="server" Text="txbx_starttime"></asp:Label>
                                               -<asp:Label ID="Lb_endtime" Font-Size="7px" runat="server" Text="txbx_endtime"></asp:Label>)--%>
                <table width="100%" border="0" style="font-size:12px; font-family:Tahoma;">
                       <tr>
                        <td>
                            
                             &nbsp;<asp:Label ID="Lb_txPRNo" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                       
                             <asp:Label ID="Lb_PRNO" runat="server" Text=""></asp:Label>
                        </td>
                        <td rowspan="2" align="center">
                           <h3>Receipt</h3>
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

<div id="watermark" runat="server" visible="false">
    <p>&copy; Duplicate Receipt.</p>
</div>

<fieldset style="border-radius:10px; padding-bottom:-10px">
      <asp:GridView Width="100%" Font-Size="9px" style="font-family:Tahoma;" 
                ID="Gv_PatientPrimaryInfo" runat="server" 
            AutoGenerateColumns="False" ShowHeader="False" OnRowDataBound="Gv_PatientPrimaryInfo_RowDataBound" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                      <table width="100%" style="margin-top:-10px;">
                      <tr>
                        <td>
                                <table cellpadding="2" cellspacing="2">
                                    <tr>
                                            <td>
                                                <asp:Label ID="Lb_txPatientName"  runat="server" Font-Bold="true" Text="Patient Name:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lb_patientNameValue" style="text-transform:capitalize;" runat="server" Text='<%# Eval("patient")  %>'></asp:Label>
                                               <%-- &nbsp;-&nbsp;  (<asp:Label ID="Lb_AgeSex" Font-Size="8px" runat="server" Text='<%# Eval("gender")  %>'></asp:Label>
                                                   / <asp:Label ID="Lb_DOB" runat="server" Font-Size="8px" Text='<%# Eval("age")  %>'></asp:Label>)--%>
                                                
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
                                                <asp:Label ID="Lb_txPhone" runat="server" Font-Bold="true" Text="Phone:"></asp:Label>
                                                / <asp:Label ID="lb_txemails" runat="server" Font-Bold="true" Text="Email:"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:Label ID="lb_cells" runat="server" Text='<%# Eval("cellno")  %>'></asp:Label>
                                                 / <asp:Label ID="lb_email" runat="server" Text='<%# Eval("email")  %>'></asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txPassword" runat="server" Font-Bold="true" Text="Panel:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Password" runat="server" Text='<%# Eval("panelname")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_employeeno" runat="server" Font-Bold="true" Text="Employee #:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_serviceno" runat="server"  Text='<%# Eval("serviceno") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    
                                </table>
                        </td>
                        <td align="right">
                                 <table cellpadding="2" cellspacing="2">
                                  <tr>
                                        <td>
                                            <asp:Label ID="Lb_txRegDate" runat="server" Font-Bold="true" Text="Booking At:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_RegDate" runat="server" Text='<%# Eval("receivedon")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txCollectAt" runat="server" Font-Bold="true" Text="Report Delivery:"></asp:Label>
                                        
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_CollectAt" runat="server" Text='<%# Eval("deliverydatetime") %>'></asp:Label>
                                       
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
                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txreferences" runat="server" Font-Bold="true" Text="Reference:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_refernces" runat="server"  Text='<%# Eval("referenceno") %>'></asp:Label>
                                        </td>
                                    </tr>
                                 </table>
                        </td>
                      </tr>
                      </table>
                      <hr />
                      <table>
                            <tr>
                                <th colspan="2" align="left">
                              <%-- <asp:Label ID="lb_urlpath" runat="server" Font-Size="9px" Text="Visit : http://www.biocarelabs.org"></asp:Label>
                                &nbsp;&nbsp;--%>(<asp:Label ID="lb_instructions" Font-Size="8px" Font-Bold="true" Text="Login Instructions : " runat="server" ></asp:Label>
                                &nbsp;<asp:Label ID="Label7" runat="server" Font-Size="8px" Text=""></asp:Label>
                                )
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
                               <%-- <td align="right">
                                </td>--%>
                            </tr>
                            
                      </table>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
          <HeaderStyle Wrap="True" />
        </asp:GridView>
</fieldset>
<br />
<fieldset style="border-radius:10px;">     
<asp:Label ID="lblGroupName" Text="" runat="server"></asp:Label>   
        <asp:GridView BorderColor="#DDDDDD"  GridLines="Horizontal" Font-Size="9px" 
            style="font-family:Tahoma;border:1px solid #EEEEEE;"  ID="Gv_PatientReceipt" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="0" ForeColor="#333333">
           <RowStyle BorderColor="#EEEEEE" />
        <Columns>
            <asp:TemplateField HeaderText="Sr #">
                <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                              <asp:Label ID="Lbl_Serial" runat="server" Visible="false" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="testname" HeaderText="Investigation" />
            <asp:BoundField DataField="speedkey" HeaderText="Test Code" />
            <asp:BoundField DataField="deliverydatetime" HeaderText="Reporting Date" />
            <asp:BoundField DataField="charges"  />
            <asp:BoundField DataField="discount" HeaderText="Discount" />
            <%--<asp:TemplateField HeaderText="Charges">
                <ItemTemplate>
                    <asp:Label ID="Lb_testCharges" runat="server" Text='<%# Eval("chargess") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BorderColor="#EEEEEE" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BorderColor="#EEEEEE" BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" BorderColor="#EEEEEE" />
            <AlternatingRowStyle  BorderColor="#DDDDDD" />
        </asp:GridView>       

        <table width="100%" style="margin-bottom:-10px;">
            <tr>
                <td align="right">
                        <asp:Label ID="Lb_SpecimenInternal" runat="server" Font-Size="10px"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Lb_Entered" Font-Size="11px" Font-Bold="true" Text="Entered :" runat="server" ></asp:Label>
                        <asp:Label ID="Lb_EnteredBy" Font-Size="10px" runat="server" ></asp:Label>
                </td>
            </tr>
        </table>
         
</fieldset>
  
    <asp:GridView Font-Size="9px" style="font-family:Tahoma;"   Width="100%" ID="Gv_paymentModule" runat="server" 
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
  
        <table width="100%" border="0" style="font-size:10px; font-family:Tahoma;">
                <tr>
                    <td style="width:30%;" valign="top">
                        <fieldset style="border-radius:10px;">
                            <%-- <tr>
                                                 <td>
                                                    <asp:Label ID="Lb_txAgeSex" runat="server" Font-Bold="true" Text="Age / Gender:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Lb_AgeSex" runat="server" Text='<%# Eval("gender")  %>'></asp:Label>
                                                   / <asp:Label ID="Lb_DOB" runat="server" Text='<%# Eval("age")  %>'></asp:Label>
                                                </td>
                                    </tr>--%>
                        <table width="100%">
                            <tr>
                                <td>
                                    <fieldset style="border-radius:4px;" runat="server" id="field_test">
                                    <legend>
                                    Test Instructions:
                                    </legend>
                                        <asp:GridView ID="Gv_TestComent" Width="100%" GridLines="None"  runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="30%" DataField="Test_Name" HeaderText="Test"  />
                                        <asp:BoundField ItemStyle-Width="35%" DataField="Instructions_Before" HeaderText="Instruction Before"  />
                                        <asp:BoundField ItemStyle-Width="35%" DataField="Instructions_After" HeaderText="Instruction After"  />
                                       <%--<asp:TemplateField>
                                        <ItemTemplate>
                                                 <asp:Label ID="Lb_testingName"  runat="server" ></asp:Label>
                                        </ItemTemplate>
                                       </asp:TemplateField>

                                       <asp:TemplateField>
                                        <ItemTemplate>
                                                 <asp:Label ID="Lb_instructionBef"  runat="server" ></asp:Label>
                                        </ItemTemplate>
                                       </asp:TemplateField>

                                       <asp:TemplateField>
                                        <ItemTemplate>
                                                 <asp:Label ID="Lb_instructionAft"  runat="server" ></asp:Label>
                                        </ItemTemplate>
                                       </asp:TemplateField>--%>

                                    </Columns>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:GridView>   
                                    </fieldset> 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label Font-Size="9px" runat="server" ID="lb_remarks" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                
                                     <asp:GridView ID="Gv_BranchComent" GridLines="None" runat="server" AutoGenerateColumns="false">
                                     <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="Lb_branchDesc" Text='<%# Eval("branchName") %>' runat="server"></asp:Label>
                                                :
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Report_Text" HeaderText="" />
                                     </Columns>
                                         <HeaderStyle HorizontalAlign="Left" />
                                     </asp:GridView>  
                                      
                                </td>
                            </tr>
                            <tr>
                                <td style="border-top:1px solid black;">
                                    <asp:GridView ID="Gv_GeneralComent" Font-Size="9px" runat="server" Width="100%" 
                                        AutoGenerateColumns="false" GridLines="None">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                       <asp:Label ID="Lb_General" Text='<%# Eval("coments") %>' runat="server"></asp:Label>
                                                 </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>    
                                </td>
                            </tr>
                        </table>
                            
                        </fieldset>
                        
                        <%--<tr>
                                        <td align="left">
                                        </td>
                                        <td align="left">
                                        </td>
                            </tr>--%>                    </td>
                    <td style="width:40%;" valign="top" >
                        <fieldset style="border-radius:10px;" runat="server" id="field_branchList">
                            <asp:Label ID="Lb_BranchHeading" Font-Bold="true" runat="server" Text="Branches"></asp:Label>
                            <asp:Label ID="Lb_addressBranchDesc" runat="server" Font-Size="7px" Text="(Over the counter reports can be collected from these addresses)"></asp:Label>
                            <hr />
                            <asp:GridView ID="Gv_BranchNames" Width="100%" runat="server" Font-Size="7px" style="font-family:Tahoma;" AutoGenerateColumns="False" ShowHeader="False" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lb_BName" runat="server" Text='<%# Eval("branchName") %>'></asp:Label>
                                            : <asp:Label ID="lb_Baddress" Font-Size="8px" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                                              ,<asp:Label ID="lb_city" Font-Size="8px" runat="server" Text='<%# Eval("city") %>'></asp:Label>
                                              <asp:Label ID="lb_phone" Font-Size="7px" runat="server" Text='<%# Eval("phone") %>'></asp:Label>
                                               (<asp:Label ID="Lb_starttime" Font-Size="7px" runat="server" Text='<%# Eval("starttime") %>'></asp:Label>-<asp:Label ID="Lb_endtime" Font-Size="7px" runat="server" Text='<%# Eval("endtime") %>'></asp:Label>)
                                            <br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </fieldset>
                    </td>
                </tr>
            </table>

        <asp:Image ID="Img_footer" Visible="false" Width="100%" runat="server" />
        
    </div>
    </form>
</body>
</html>
