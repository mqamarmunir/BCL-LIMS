<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_2.aspx.cs" Inherits="transaction_Default" %>
<%@ Register Assembly="Shared.WebControls" Namespace="Shared.WebControls"  TagPrefix="wc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function HideLabel() {
            document.getElementById('<%= tb1.ClientID %>').style.display = "none";
            document.getElementById("tb2").style.visibility = "visible";
        }
        setTimeout("HideLabel();", 3000);
    </script> 

     <style type="text/css">
        .header
        {
            clear: both;
            width: 100%;
            border-collapse:0px;
        }
        .item
        {
            border-style:ridge;
           border-width:medium;
           border-color:Silver;
            
            float:left;
            font-size:8px;
            
            width: 99%;
        }
        .AlternateItem
        {
            
            float:left;
            font-size:8px;
            border-collapse:0px;
            width: 99%;
       
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
                        border-collapse:0px;
                        width: 100%;
        }
        .mainLayout
        {
            width: 80%;
            padding: 0px;
            float:left;
            border-collapse:0px;
            border-bottom:1px solid #EEEEEE;
            /*background-color: #EEEEEE;*/
        }
    </style>

    <style type="text/css">
    table {
            border-collapse: collapse;
            border-spacing: 0;
        }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
  
   
    <table id="tb1" width="100%" runat="server">
    <tr><td align="center">
    <br /><br />
    <asp:Image ID="Img_bar" runat="server" ImageUrl="../img/PleaseWait.gif" />
    </td></tr>
    </table>
    <div id="tb2" ><%--style="visibility:hidden;"--%>
            <%-- <img src="images/logos.jpg" width="100%" height="80px" alt="" /> --%>    
            <asp:Image ID="Img_headerMain" Visible="false" Height="50px" Width="100%"  runat="server" />
            <asp:Image ID="Img_empty"  Visible="true" ImageUrl="headerfooter/empty.jpg" Height="10px" runat="server" />
            <asp:Label ID="Lb_dateAll" Visible="false" runat="server" Text=""></asp:Label>
            <asp:Label ID="Lb_ResultAll" runat="server" Visible="False"></asp:Label>

   <table width="99%" border="0" style="height:20px; top:0; position:fixed;">
   <tr>
   <td align="left" style="width:15%;">
            <asp:Image ID="Img_header" Visible="false" Height="50px" Width="200px"  runat="server" />
   </td>
   <td align="center" style="width:70%;">
   <p style="font-size:9px; font-weight:bold; text-align:center;">
       <asp:Label ID="Lb_BranchNames" Font-Size="18px" runat="server" 
           Font-Names="Verdana"></asp:Label>
       <br />
    <asp:Label ID="Label6" Font-Size="9px"  runat="server" Font-Names="Verdana" Text="Timings:"></asp:Label> 
    <asp:Label ID="Lb_starttime" Font-Size="9px" runat="server" Font-Names="Verdana" Text="txbx_starttime"></asp:Label>-<asp:Label ID="Lb_endtime" Font-Size="9px" runat="server" Font-Names="Verdana" Text="txbx_endtime"></asp:Label>
  &nbsp;&nbsp;&nbsp; 
  <asp:Label ID="Label2" Font-Size="9px"  Font-Names="Verdana" runat="server" Text="Ph No:"></asp:Label> 
  <asp:Label ID="lb_phonebranchmain" Font-Size="9px" Font-Names="Verdana" runat="server" Text=""></asp:Label> &nbsp;
  <asp:Label ID="LB_Ext" Font-Size="9px" Font-Names="Verdana"  runat="server" Text="Ext:" /> 
  <asp:Label ID="Lb_Extension" Font-Size="9px" Font-Names="Verdana" runat="server" Text=""></asp:Label>
  </p> 
   </td>
   <td style="width:15%;">
       
       </td>
   </tr>
                    
                <%--<table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size:12px; font-family:Tahoma;">--%>
                       <tr style="font-size:12px; font-family:Tahoma;">
                        <td>
                            
                             &nbsp;<asp:Label ID="Lb_txPRNo" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                       
                             <asp:Label ID="Lb_PRNO" runat="server" Text=""></asp:Label>
                        </td>
                        <td rowspan="2" style="font-family:Verdana" align="center">
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
                     
              <tr> <td colspan="3"  >       
                       <fieldset style=" border:gray 2px solid;" >
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
                                                    <asp:Label style="text-transform:capitalize;" ID="Lb_patientNameValue" runat="server" Text='<%# Eval("name")  %>'></asp:Label>
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
                                       <tr>
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
                                     <table cellpadding="0" cellspacing="0">
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
               </td>
               </tr>
                 </table>        
                
                <wc:ReportGridView GridLines="None" Font-Size="11px" FooterStyle-Font-Names="Verdana" style="top:165px; position:relative;" runat="server"   ID="Gv_GroupTest" 
             AutoGenerateColumns="false" PrintPageSize="4" AllowPrintPaging="true" 
                Width="100%" datakeyNames="bookingdid,testid,prid,automatedtext"    
          onpageindexchanging="Gv_GroupTest_PageIndexChanging" 
                                onrowdatabound="Gv_GroupTest_RowDataBound" 
             ondatabound="Gv_GroupTest_DataBound">
            <Columns>
            <asp:TemplateField>
                <ItemTemplate>
              
                        <table width="100%" id="tb_group" runat="server" style="border-radius:5px; border:1px solid #EEEEEE;"   cellpadding="0" cellspacing="0" >
                        <tr>
                            <td align="center" valign="top">
                            <div style=" border-radius:10px;">
                                <asp:Label Font-Size="14px" Font-Bold="true" ID="lb_Group" runat="server" Text='<%# Eval("groupname") %>'>
                            
                            </asp:Label>
                            </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                            <div style="box-shadow:3px 3px 4px #CCCCCC; background-color:#EEEEEE;-webkit-box-shadow: 4px 4px 2px rgba(50, 50, 50, 0.75);
-moz-box-shadow:    4px 4px 2px Rgba(50, 50, 50, 0.75);
box-shadow:         4px 4px 2px rgba(50, 50, 50, 0.75); border-radius:10px;">
                            <asp:Label Font-Size="12px" Font-Names="Verdana"  ID="lb_Test" runat="server" Text='<%# Eval("test_name") %>'></asp:Label>
                            </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                   <table width="100%" border="0" style="margin-top:5px;">
                                               <%-- <tr style="font-size:12px; font-weight:bold; font-family:Tahoma;">
                                                   
                                                </tr>
                                                <tr><td style="width:45%" colspan="2"></td> 
                                                    <td colspan="3" align="center" style="background-color:#EEEEEE; font-weight:bold;">Result(s)</td>
                                                </tr>--%>
                                                <tr>
                                                <td style="" >
                                    <asp:GridView ID="Gv_Attributes" DataKeyNames="Abnormal" OnRowDataBound="GridView1_RowDataBound" GridLines="None" Font-Size="9px" style="font-family:Tahoma;" runat="server" AutoGenerateColumns="true" Width="100%" CellPadding="0" ForeColor="#333333">
                                    <HeaderStyle BackColor="White" />
                                    <RowStyle BackColor="#EEEEEE" />
                                    <AlternatingRowStyle BackColor="White" />
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
                                           <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label Font-Size="9px"  ID="Label2" runat="server" Text=""></asp:Label>
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
                                                
                                                

                                                </td>
                                                </tr>
                                    </table>
                                </td>
                        </tr>
                        <tr>
                        <td>
                              <asp:GridView Visible="false" ID="Gv_SeeBelow" runat="server" AutoGenerateColumns="False" 
                                Font-Size="10px" Width="100%" ShowHeader="false">
                                <HeaderStyle HorizontalAlign="Left" />
                                <Columns>
                                    
                                    <%--<asp:BoundField DataField="Test_Name" HeaderText="Attribute" 
                                        SortExpression="attribute_name" />--%>
                                    <asp:BoundField DataField="autotext" HeaderText="Interpretation" 
                                        SortExpression="automated_text" />
                                </Columns>
                            </asp:GridView>
                            <br />
              <asp:ListView ID="ListView1" GroupItemCount="2"  runat="server">
                             <LayoutTemplate>
                <div runat="server" id="Products" class="mainLayout" style="width:99.5%;">
                    <div id="Tr1" runat="server" class="header">
                         <asp:Label ID="Lb_BranchHeading" Font-Size="10px" Font-Bold="true" style="font-family:Tahoma;" runat="server" Text="Reference Ranges:"></asp:Label>
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
                                <div id="Td1" align="left" runat="server" style="margin-left:10px;" class='<%# Container.DisplayIndex % 2==0?"item":"AlternateItem" %>'>                                                
                                <asp:Label ID="lb_BName" Font-Bold="true" style="font-family:Tahoma;" runat="server" Text='<%# Eval("Attribute_Name") %>'></asp:Label>
                                                <hr />
                                                <asp:Label ID="lb_Baddress" Font-Size="10px" style="font-family:Tahoma;" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <ItemSeparatorTemplate>
                              <br />
                            </ItemSeparatorTemplate>
                            
                            </asp:ListView>

                            <asp:Label Font-Size="9px"  ID="Label1" runat="server" Text=""></asp:Label>

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
            </Columns>
             <PageHeaderTemplate>
            
                <%--PAGE HEADER TEMPLATE HERE--%>
                 <asp:Label Font-Bold="true" Font-Size="14px" ID="lab_br" runat="server" ></asp:Label>
            </PageHeaderTemplate>
            
            <PageFooterTemplate>
               <table class="style2" width="98.5%" style="border-radius:8px; bottom:0; position:fixed; font-size: 6px; display:none">
               <tr style="border-bottom:1px solid #DDDDDD;">
                    
                    <td align="center" colspan="8">
            <asp:Label ID="lblnoresponsibility" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr style="border-bottom:1px solid #DDDDDD;">
                    <td align="left">
                        <asp:Label Font-Bold="true" Font-Size="6px" ID="Lb_TodayDate" runat="server" Text=""></asp:Label>
                    </td>
                    <td align="center" colspan="7">
                         <asp:Label Font-Bold="true" Font-Size="8px" ID="Label_Signature" runat="server" Text="Electronically verified report. Signatures not required."></asp:Label>
                    </td>
                </tr>
                <tr>
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
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Dr. Usman Ansari"></asp:Label>
                </td>
                 <td width="12.5%" valign="top">
                    <asp:Label ID="Label33" runat="server" Font-Bold="true" Text="Dr. Mehmood ul Hasan"></asp:Label>
                </td>
                <td width="12%" valign="top">
                    <asp:Label ID="Label25" runat="server" Font-Bold="true" Text="Dr. Zeeshan Ahmed"></asp:Label>
                </td>
                <td width="12%" valign="top">
                    <asp:Label Font-Bold="true" ID="Label22" runat="server" Text="Dr. Huma Jawad"></asp:Label>
                </td>
                <td width="12%" valign="top">
                    <asp:Label ID="Label26" runat="server" Font-Bold="true" Text="Dr. Maha Anis"></asp:Label>
                </td>
               
                
            </tr>
            <tr>
                <td>
                    Chief Executive Officer</td>
               <td>
                    Lab Dir. /Cnst. Microbiologist</td>
                <td>
                    Consultant Histopathologist</td>
                 <td>
                    Consultant Hematologist</td>
                <td>
                    Assistant Pathologist</td>
                <td>
                    Assistant Pathologist</td>
                <td>
                    Assistant Pathologist</td>
                <td>
                    Assistant Pathologist</td>
              
               
            </tr>
            <tr>
                <td>
                    B.SC (Hons) M.S M.B.A</td>
               <td>
                    M.B.B.S; F.C.P.S</td>
               
                <td>
                    M.B.B.S. M.Phil</td>

                 <td>
                    M.B.B.S F.C.P.S (Hematology)</td>
                 <td>
                     M.B.B.S F.C.P.S (Hematology)</td> 
                
                <td>
                    M.B.B.S; MPhil </td>

                <td>
                    M.B.B.S</td>
                <td>
                    M.B.B.S</td>
            </tr>
            <tr>
                <td>
                    PGD (MGT) M (A.A.C.C) (USA)</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                    <td>
                    &nbsp;
                    </td>
            </tr>
            <tr>
            <td align="right" colspan="8" style="display:none">
             Page <%#  Gv_GroupTest.CurrentPrintPage.ToString() %> / <%#  Gv_GroupTest.PrintPageCount%>
            </td>
            </tr>
        </table>

            </PageFooterTemplate>

<FooterStyle Font-Names="Verdana"></FooterStyle>
    </wc:ReportGridView>
    

    </div>
  
  
    </form>
</body>
</html>
