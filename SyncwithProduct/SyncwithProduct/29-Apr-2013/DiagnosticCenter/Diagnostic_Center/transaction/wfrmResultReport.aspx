<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmResultReport.aspx.cs" Inherits="wfrmResultReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
     <style type="text/css">
    #Print {
       /* height: 842px; width: 595px; 
        /* to centre page on screen */
    }
    </style>
      <style type="text/css">
        .header
        {
            clear: both;
            /*width: 100%;*/
            border-collapse:0px;
        }
        .item
        {
            float:left;
            font-size:8px;
            border-collapse:0;
        }
        .group
        {
            /* i used 200px ,because the main layout width is 600px , and the width for each group is 200px.*/
            /*width: 300px;*/
            border-right:1px solid #CCCCCC;
            border-top:1px solid #CCCCCC;
            float: left;
            margin: 2px;
            padding: 0px;
            border-collapse:0;
        }
        .mainLayout
        {
            /*width: 100%;*/
            padding: 0px;
            float:left;
            border-collapse:0;
            border-bottom:1px solid #EEEEEE;
            background-color: #EEEEEE;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">
     <div id="Print" runat="server">
                    <%-- <img src="images/logos.jpg" width="100%" height="80px" alt="" /> --%>    
            <asp:Image ID="Img_headerMain" Visible="false" style="display:none;" Height="50px" Width="100%"  runat="server" />
            <asp:Image ID="Img_empty"  Visible="true" ImageUrl="headerfooter/empty.jpg" Height="10px" runat="server" />
   
   <table width="100%">
   <tr>
   <td align="left" style="width:15%;display:none;">
            <asp:Image ID="Img_header" Visible="false" Height="50px" Width="100%"  runat="server" />
   </td>
   <td align="center" style="width:100%;padding-top:10px;">
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
   <td style="width:15%;display:none;">
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
            AutoGenerateColumns="False" ShowHeader="False" GridLines="None"  OnRowDataBound="gv_PatientPrimaryInfo_RowDataBound">
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
                                                <asp:Label ID="Lb_patientNameValue" style="text-transform:capitalize;" runat="server" Text='<%# Eval("name")  %>'></asp:Label>
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
                                     <tr>
                                                <td>
                                                    <asp:Label ID="lblWardtxt" runat="server" Font-Bold="true" Text="Ward:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWard" runat="server" Text='<%# Eval("Ward")  %>'></asp:Label>
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
                                    <tr>
                                                <td>
                                                    <asp:Label ID="lblbedtxt" runat="server" Font-Bold="true" Text="Bed:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBed" runat="server" Text='<%# Eval("Bed")  %>'></asp:Label>
                                                </td>
                                        </tr>
                                         <tr>
                                                <td>
                                                    <asp:Label ID="lblReferenceNotext" runat="server" Font-Bold="true" Text="Reference No:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblReferenceNo" runat="server" Text='<%# Eval("referenceno")  %>'></asp:Label>
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
<fieldset style="border-radius:12px; min-height:550px;">    
        <asp:GridView ID="Gv_GroupTest"  GridLines="None" Font-Size="12px" 
            style="font-family:Tahoma;" runat="server" 
            AutoGenerateColumns="False" datakeyNames="bookingdid,testid,prid,automatedtext" Width="100%" CellPadding="0" 
            ForeColor="#333333" onrowdatabound="Gv_GroupTest_RowDataBound">
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
                                                <tr>
                                                <td>

                                                               
              <asp:ListView ID="ListView1" GroupItemCount="1"  runat="server">
                             <LayoutTemplate>
                <div runat="server" id="Products" class="mainLayout">
                    <div id="Tr1" runat="server" class="header">
                         <asp:Label ID="Lb_BranchHeading" Font-Size="10px" Font-Bold="true" runat="server" Text="Attributes Ranges:"></asp:Label>
                         <asp:Label ID="Lb_addressBranchDesc" runat="server" Font-Size="7px" Text=""></asp:Label>
                            
                            </div>
                            <div runat="server" id="groupPlaceholder">
                            </div>
                        </div>
                    </LayoutTemplate>
                            <GroupTemplate>
                                <div runat="server" id="ProductsGroup" class="group">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </div>
                            </GroupTemplate>
                            <GroupSeparatorTemplate>
                            </GroupSeparatorTemplate>
                            <ItemTemplate>
                                <div id="Td1" align="center" runat="server" class="item">
                                                <asp:Label ID="lb_BName" Font-Bold="true" runat="server" Text='<%# Eval("Attribute_Name") %>'></asp:Label>
                                                <hr />
                                                <asp:Label ID="lb_Baddress" Font-Size="8px" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemSeparatorTemplate>
                                <br />
                            </ItemSeparatorTemplate>
                            </asp:ListView>

             

                                                       <asp:Label Font-Size="9px"  ID="Label1" runat="server" Text=""></asp:Label>
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
        
          <asp:GridView ID="Gv_SeeBelow" Visible="false" runat="server" AutoGenerateColumns="False" 
                                Font-Size="10px" Width="100%">
                                <HeaderStyle HorizontalAlign="Left" />
                                <Columns>
                                    <%--<asp:BoundField DataField="Test_Name" HeaderText="Attribute" 
                                        SortExpression="attribute_name" />--%>
                                    <asp:BoundField DataField="AutomatedText" HeaderText="Interpretation" 
                                        SortExpression="automated_text" />
                                </Columns>
                            </asp:GridView>

             
</fieldset>
      
      <asp:Image ID="Img_footer" style="display:none;" Width="100%" runat="server" />
      
      <%--<asp:Label Font-Bold="true" style="float:left;" Font-Size="6px" ID="Lb_Signature" runat="server" Text="Electronically verified report. Signatures not required."></asp:Label>
--%>
      <%-- <asp:Label Font-Bold="true" style="float:right;" Font-Size="6px" ID="Lb_TodayDate" runat="server" Text=""></asp:Label>--%>
    
       <table width="98.5%" style="border-radius:8px; bottom:0; position:fixed; font-size: 8px;">
                <tr style="border-bottom:1px solid #DDDDDD;">
                    
                    <td align="center" colspan="8">
                    <asp:Label ID="lblnoresponsibility" Font-Size="11px" runat="server" Visible="false"></asp:Label>
                         </td>
                </tr>
               <tr style="border-bottom:1px solid #DDDDDD;">
                    <td align="left" colspan="2">
                         <asp:Label Font-Bold="true"  Font-Size="6px" ID="Lb_TodayDate" runat="server" Text=""></asp:Label>
                    </td>
                    <td align="center" colspan="4">
                         <asp:Label Font-Bold="true" Font-Size="8px" ID="Label_Signature" runat="server" Text="Electronically verified report. Signatures not required."></asp:Label>
                    </td>
                    <td colspan="2"></td>
                </tr>
           <tr style="padding-top=2px;">
                <td width="12%" valign="top">
                    <asp:Label Font-Bold="true" ID="Label21" runat="server" Text="Anis Alam"></asp:Label>
                </td>
                <td width="13.5%" valign="top">
                    <asp:Label ID="Label24" Font-Bold="true" runat="server" Text="Dr. Shahid Rafi"></asp:Label>
                </td>
                <td width="12.5%" valign="top">
                    <asp:Label ID="Label23" Font-Bold="true" runat="server" Text="Prof. Dr. Saeed Alam"></asp:Label>
                </td>
                 <td width="12.5%" valign="top">
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Dr. R.N. Ahmad"></asp:Label>
                </td>
                <%-- <td width="12.5%" valign="top">
                    <asp:Label ID="Label33" runat="server" Font-Bold="true" Text="Dr. Nasir Rafi"></asp:Label>
                </td>--%>
                <td width="12%" valign="top">
                    <asp:Label ID="Label25" runat="server" Font-Bold="true" Text="Dr. Masooma Raza"></asp:Label>
                </td>
                <%--<td width="13.5%" valign="top">
                    <asp:Label Font-Bold="true" ID="Label22" runat="server" Text="Dr. Huma Jawad"></asp:Label>
                </td>--%>
                <td width="12%" valign="top">
                    <asp:Label ID="Label26" runat="server" Font-Bold="true" Text="Dr. Maha Anis"></asp:Label>
                </td>
               
                
            </tr>
            <tr>
                <td valign="top">
                    Chief Executive Officer</td>
               <td valign="top">
                    Lab Dir. /Cnst. Microbiologist</td>
                <td valign="top">
                    Consultant Histopathologist</td>
                 <td valign="top">
                    Consultant Microbiologist</td>
                <%--<td valign="top">
                    Consultant Microbiologist</td>--%>
                <td valign="top">
                    Consultant Haematologist</td>
                <%--<td valign="top">
                    Assistant<br />  Pathologist</td>--%>
                <td valign="top">
                    Pathologist Hematologist</td>
              
               
            </tr>
            <tr>
                <td valign="top">
                    B.SC (Hons) M.S M.B.A,PGD(MGT) M (A.A.C.C)(USA)</td>
               <td valign="top">
                    M.B.B.S; FCPS.</td>
               
                <td valign="top">
                    M.B.B.S.<br /> M.Phil</td>

                 <td valign="top">
                    M.B.B.S F.C.P.S</td>
                 <%--<td valign="top">
                     MBBS,FCPS (Pak),<br />ARC Path(UK)</td> 
                --%>
                <td valign="top">
                    MBBS,FCPS </td>

                <%--<td valign="top">
                    MBBS,MCPS</td>--%>
                <td valign="top">
                    M.B.B.S,M.Phill</td>
            </tr>
            <tr>
                <td>
                    </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <%--<td>
                    &nbsp;</td>
                <td>
                    </td>--%>
                <td>
                    &nbsp;</td>
               <%-- <td>
                    &nbsp;</td>--%>
                    <td>
                    &nbsp;
                    </td>
            </tr>
            <tr>
            <td align="right" colspan="8" style="display:none">
            <%-- Page <%#  Gv_GroupTest.CurrentPrintPage.ToString() %> / <%#  Gv_GroupTest.PrintPageCount%>--%>
            </td>
            </tr>
        </table>
       

    
           
    </div>
    </form>
</body>
</html>
