<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptGeneralReport.aspx.cs" Inherits="transaction_RptGeneralReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function HideLabel() {
            document.getElementById('<%= tb1.ClientID %>').style.display = "none";
            document.getElementById('<%= tb2.ClientID %>').style.visibility = "visible";
        }
        setTimeout("HideLabel();", 15000);
    </script>
</head>
<body>
     <form id="form1" runat="server">

    <table id="tb1" width="100%" runat="server">
    <tr><td align="center">
    <br /><br />
    <asp:Image ID="Img_bar" runat="server" ImageUrl="../images/please_wait.gif" />
    </td></tr>
    </table>

    <table id="tb2" width="100%" runat="server" style="visibility:hidden;" >
    <tr>
    <td>
        <div id="Print" runat="server">
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
       <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
           Visible="False" />
       </td>
   </tr>
   </table>

   <asp:Label ID="Lb_dateAll" Visible="false" runat="server" Text=""></asp:Label>
                    <%--(<asp:Label ID="Lb_starttime" Font-Size="7px" runat="server" Text="txbx_starttime"></asp:Label>
                                               -<asp:Label ID="Lb_endtime" Font-Size="7px" runat="server" Text="txbx_endtime"></asp:Label>)--%>&nbsp;
                    <asp:Label ID="Lb_ResultAll" runat="server" Visible="False"></asp:Label>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size:12px; font-family:Tahoma;">
                       <tr>
                        <td>
                            
                             &nbsp;<asp:Label ID="Lb_txPRNo" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                       
                             <asp:Label ID="Lb_PRNO" runat="server" Text=""></asp:Label>
                        </td>
                        <td rowspan="2" align="center">
                           <h3>Result Report</h3>
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
                    <%--<table width="100%"><tr><td align="center"><h3>Receipt</h3></td></tr></table>--%>
   
  
       
                        <fieldset style="border-radius:10px;">
      <asp:GridView Width="100%" Font-Size="12px" style="font-family:Tahoma; color:Black;" 
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
                                    </tr>--%>                                    <tr>
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

                        <fieldset style="border-radius:10px; min-height:380px;">    
        <asp:GridView ID="Gv_GroupTest"  GridLines="None" Font-Size="12px" 
            style="font-family:Tahoma;" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="0" ForeColor="#333333">
            <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                        <table width="100%" id="tb_group" runat="server" cellpadding="0" cellspacing="0" >
                        <tr >
                            <td align="center">
                            <div style="border:1px solid #BBBBBB; border-radius:10px;">
                                <asp:Label Font-Size="14px" Font-Bold="true" ID="lb_Group" runat="server" Text='<%# Eval("groupname") %>'>
                            
                            </asp:Label>
                            </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                            <div style="box-shadow:3px 3px 4px #CCCCCC; background-color:#EEEEEE; border:2px solid #BBBBBB; border-radius:10px;">
                            <asp:Label Font-Size="12px"  ID="lb_Test" runat="server" Text='<%# Eval("test_name") %>'></asp:Label>
                            </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                   <table width="100%" border="0">
                                                <tr style="font-size:12px; font-weight:bold; font-family:Tahoma;">
                                                    <%--<td style="width:40%">Test</td>
                                                    <td style="width:15%">Normal Value</td>
                                                    <td style="width:15%">Unit</td>
                                                    <td style="width:15%; background-color:#DDDDDD; border-radius:5px;">&nbsp; Result</td>
                                                    <td style="width:15%"></td>--%>
                                                </tr>
                                                <tr>
                                                <td colspan="5" style="" >
                                  <asp:GridView ID="Gv_Attributes" OnRowDataBound="GridView1_RowDataBound" GridLines="None" Font-Size="9px" style="font-family:Tahoma;" runat="server" AutoGenerateColumns="true" Width="100%" CellPadding="0" ForeColor="#333333">
                                    <Columns>
                                           <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                 <asp:Label Font-Bold="true" Font-Size="10px" style="margin-right:18%; float:right;"  ID="Lb_enteredOn" runat="server" Text='<%# Eval("enteredon") %>'></asp:Label>
                                               <table width="100%" style="" border="0">
                                                <tr>
                                                    <td style="width:40%;"><asp:Label ID="Lbl_AttribName" runat="server" Text='<%# Eval("attribute_name") %>'></asp:Label></td>
                                                    <td style="width:15%;"><asp:Label ID="Lb_Normal" runat="server" Text='<%# Eval("Normal") %>'></asp:Label></td>
                                                    <td style="width:16%;"><asp:Label ID="Lb_Unit" runat="server" Text='<%# Eval("Unit") %>'></asp:Label></td>
                                                    <td style="width:14%; background-color:#EEEEEE;" ><asp:Label ID="Lb_result" runat="server" Text='<%# Eval("result") %>'></asp:Label></td>
                                                    <td style="width:15%;"></td>
                                                </tr>
                                               </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%--<asp:BoundField DataField="attribute_name" HeaderText="Test" ItemStyle-Width="25%" />
                                            <asp:BoundField DataField="Normal" HeaderText="Normal Value" ItemStyle-Width="15%" />
                                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="15%" />
                                            <asp:BoundField DataField="enteredon" HeaderText="Date & Time" ItemStyle-Width="20%" />
                                            <asp:BoundField DataField="result" HeaderText="Result" ItemStyle-Width="15%" />--%>
                                    </Columns>
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <AlternatingRowStyle BackColor="White" />
                                     </asp:GridView>
                                                
                                                </td>
                                                </tr>

                                    
                                    </table>
                                </td>
                        </tr>
                         <tr>
                                                <td>
                                                    <asp:GridView ID="Gv_OpionionComments" GridLines="None" Width="100%" AutoGenerateColumns="false" runat="server">
                                                        <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                           
                                                            <asp:Label Font-Size="10px" Font-Bold="true" ID="Lb_Opinion" runat="server" Text="Opinion :">
                                                             </asp:Label>
                                                             <asp:Label Font-Size="10px"  ID="Lb_TxOpinion" runat="server" Text='<%# Eval("opinion") %>'>
                                                             </asp:Label>
                                                            
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                        <td>
                                                             <asp:Label Font-Size="10px" Font-Bold="true" ID="Lb_Coment" runat="server" Text="Comment :">
                                                             </asp:Label>
                                                             <asp:Label Font-Size="10px"  ID="Lb_TxComent" runat="server" Text='<%# Eval("comment") %>'>
                                                             </asp:Label>
                                                             
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        </Columns>
                                                   </asp:GridView>
                                                
                                                </td>
                                                </tr>
                        </table>
                </ItemTemplate>            
            </asp:TemplateField>
            <%-- <asp:TemplateField>
                    <ItemTemplate>
                    </ItemTemplate>
              </asp:TemplateField>--%>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        
        <asp:GridView GridLines="None" Font-Size="11px" 
            style="font-family:Tahoma;"  ID="Gv_PatientReceipt" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="0" ForeColor="#333333">
           
            <RowStyle BackColor="#EFF3FB" />
           
        <Columns>
         <%--   <asp:TemplateField HeaderText="Sr No#">
                <ItemTemplate>
                              <asp:Label ID="Lbl_Serial" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="testname" HeaderText="Investigation" />
            <asp:BoundField DataField="speedkey" Visible="false" HeaderText="Test Code" />
            <asp:BoundField DataField="deliverytime" HeaderText="Reporting Date/Time" />
            <asp:BoundField DataField="charges" HeaderText="Charges" />--%>
        </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>        
</fieldset>
     
                        <asp:GridView Font-Size="11px" style="font-family:Tahoma;"   Width="100%" ID="Gv_paymentModule" runat="server" 
            AutoGenerateColumns="False" GridLines="None" >
        <Columns>
            <%--<asp:TemplateField>
            <ItemTemplate>
            <table width="90%">
           <tr>
                <td align="right">
                    <asp:Label ID="Lb_Total" Font-Bold="true" runat="server"  Text="Total Amount:"></asp:Label>
                    <asp:Label ID="Label1" runat="server"  Text='<%# Eval("totalamount") %>'></asp:Label>
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
                 <asp:Label ID="Label3"  runat="server"  Text='<%# Eval("totalpaid") %>'></asp:Label>
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
            </asp:TemplateField>--%>
        </Columns>
        </asp:GridView>
    
                        <%--                                    <tr>
                                        <td>
                                            <asp:Label ID="Lb_txPassword" runat="server" Font-Bold="true" Text="Password:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Lb_Password" runat="server" Text='<%# Eval("Pasword")  %>'></asp:Label>
                                        </td>
                                    </tr>--%>
<%--
                       <div visible="true"><asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button1_Click" /></div>
--%>         
        <asp:Image ID="Img_footer" style="display:none;" Width="100%" runat="server" />
        <asp:Image ID="Image3" ImageUrl="../images/Dr.png" Width="100%" runat="server" />

    </div>

   </td>
    </tr>
    </table>
    </form>
</body>
</html>
