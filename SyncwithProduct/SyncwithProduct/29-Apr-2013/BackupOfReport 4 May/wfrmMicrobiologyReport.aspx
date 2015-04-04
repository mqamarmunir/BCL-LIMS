<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmMicrobiologyReport.aspx.cs" Inherits="wfrmMicrobiologyReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    fieldset, td { 
                    padding-top: 0;
                }
   table {
          border-collapse: collapse;
         }
    fieldset, legend, label, input{ margin: 0; padding: 0;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
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
   </tr>
   </table>


            <%--(<asp:Label ID="Lb_starttime" Font-Size="7px" runat="server" Text="txbx_starttime"></asp:Label>
                                               -<asp:Label ID="Lb_endtime" Font-Size="7px" runat="server" Text="txbx_endtime"></asp:Label>)--%>
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
<fieldset style="border-radius:10px; min-height:580px;">    
    <asp:GridView ID="Gv_GroupTest"  GridLines="None" Font-Size="10px" 
            style="font-family:Tahoma;" runat="server" 
            AutoGenerateColumns="False" Width="100%" CellPadding="0" ForeColor="#333333">
              <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                        <table width="100%" id="tb_group" runat="server" cellpadding="2" cellspacing="2" >
                        <tr >
                            <td align="center">
                            <div style="border-radius:5px;box-shadow:3px 3px 4px #000; border:thin solid;">
                                <asp:Label Font-Size="14px" Font-Bold="true" ID="lb_Group" runat="server" Text='<%# Eval("groupname") %>'>
                            
                            </asp:Label>
                            </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                            <div style="border-radius:5px;box-shadow:3px 3px 4px #000; border:thin solid;">
                            <asp:Label Font-Size="12px"  ID="lb_Test" runat="server" Text='<%# Eval("test_name") %>'></asp:Label>
                            </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                   <table width="100%">
                                            <tr style="background-color:#EEEEEE; font-size:12px; font-weight:bold;">
                                                <td style="width:2%; text-align:left;"></td>
                                                    <td style="width:22%;text-align:left;">Test</td>
                                                    <td style="width:12%;text-align:left;">Normal Values</td>
                                                    <td style="width:12%;text-align:left;">Unit</td>
                                                    <td style="width:50%;">Result(s)</td>
                                                </tr>
                                                <tr>
                                                <td colspan="5">
                                   <asp:GridView ID="Gv_Attributes" GridLines="None" Font-Size="11px" style="font-family:Tahoma;" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="0" ForeColor="#333333">
                                                <Columns>
                                                <asp:TemplateField>
                                                <ItemTemplate>
                                               <table cellpadding="0" border="0" width="100%" cellspacing="0">
                                                <tr>
                                                    <td style="width:2%; text-align:left;"><asp:Label Visible="false" ID="Lbl_Serial" runat="server" Text=""></asp:Label></td>
                                                    <td style="width:22%;text-align:left;"><asp:Label ID="Lb_attribname" runat="server" Text='<%# Eval("attribute_name") %>'></asp:Label></td>
                                                    <td style="width:12%;text-align:left;"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Normal Ranges") %>'></asp:Label></td>
                                                    <td style="width:12%;text-align:left;"><asp:Label ID="Label3" runat="server" Text='<%# Eval("Unit") %>'></asp:Label></td>
                                                    <td style="width:50%;"><asp:Label ID="Lb_result" runat="server" Text='<%# Eval("result") %>'></asp:Label></td> </tr>
                                              
                                               </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                   <table width="100%">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:Label ID="Lb_HeadingMicro" Font-Bold="true" Font-Underline="true" Text="ANTIMICROBIAL SENSITIVITY" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td colspan="5">
                                   <asp:GridView ID="Gv_MicoSensitvity" GridLines="None" Font-Size="11px" style="font-family:Tahoma;" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="0" ForeColor="#333333">
                                                <Columns>
                                                <asp:TemplateField>
                                                <ItemTemplate>
                                                       <table style="border:1px solid black;" border="0" width="50%" >
                                                        <tr>
                                                            <th colspan="2" align="left" style="border:1px solid #BBBBBB; background-color:#EEEEEE;">
                                                                     <asp:Label Font-Bold="true" style="float:left;" Font-Size="10px"  ID="Lb_Organisms" runat="server" Text='<%# Eval("Organism") %>'></asp:Label>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:40%;text-align:left;"><asp:Label ID="Lb_drug" runat="server" Text='<%# Eval("DRUG") %>'></asp:Label></td>
                                                            <td style="width:10%;text-align:center;border-left:1px solid black;"><asp:Label ID="Lb_sensativity" runat="server" Text='<%# Eval("Senstivity") %>'></asp:Label></td> 
                                                        </tr>
                                                       </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           </Columns>
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <AlternatingRowStyle BackColor="White" />
                                     </asp:GridView><br />
                                               <asp:Label ID="Lb_Abbreviation" Font-Bold="true" Text="R = Resistant  &nbsp;&nbsp; S = Sensitive &nbsp;&nbsp;  I = Intermediate" runat="server" ></asp:Label>
                                              
                                                
                                                </td>
                                                </tr>
                                                
                                                <tr>
                                                <td style="border-radius:5px; border:1px solid #CCCCCC;">

                                                
                                       <asp:GridView ID="Gv_OpionionComments" GridLines="None" Width="100%" AutoGenerateColumns="false" runat="server">
                                            <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                        <div style="width:80%;">
                                                         <asp:Label Font-Size="11px" Font-Bold="true" ID="Lb_Opinion" runat="server" Text="Opinion :">
                                                         </asp:Label>
                                                         <asp:Label Font-Size="10px"  ID="Lb_TxOpinion" runat="server" Text='<%# Eval("opinion") %>'>
                                                         </asp:Label>
                                                         </div>
                                                   
                                                         <div style="width:80%">
                                                         <asp:Label Font-Size="11px" Font-Bold="true" ID="Lb_Coment" runat="server" Text="Comment :">
                                                         </asp:Label>
                                                         <asp:Label Font-Size="10px"  ID="Lb_TxComent" runat="server" Text='<%# Eval("comment") %>'>
                                                         </asp:Label>
                                                          </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            </Columns>
                                       </asp:GridView>

                                                </td>
                                                </tr>
                                    </table>
                                </td>
                        </tr>
                        </table>
                </ItemTemplate>            
            </asp:TemplateField>

            
            </Columns>
          
            
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle HorizontalAlign="Left" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</fieldset>
       
       
        <div style="margin-bottom:0px;">
            <table style="font-size:9px; display:none; font-family:Tahoma; color:Red;">
                <tr>
                    <td align="center">
                        <fieldset>
                                All rights are reserved by Trees Technology
                        </fieldset>
                    </td>
                </tr>
            </table>
            </div>
        <asp:Image ID="Img_footer" Width="100%" runat="server" />
        <%-- <asp:Label Font-Bold="true" style="float:left;" Font-Size="6px" ID="Lb_Signature" runat="server" Text="Electronically verified report. Signatures not required."></asp:Label>
--%>
     <table class="style2" width="98.5%" style="border-radius:8px; bottom:0; position:fixed; font-size: 6px;">
           <tr style="border-bottom:1px solid #DDDDDD;">
                    <td align="left" colspan="2">
                        <asp:Label Font-Bold="true" style="float:right;" Font-Size="6px" ID="Lb_TodayDate" runat="server" Text=""></asp:Label>
               <%-- <asp:Label Font-Bold="true" Font-Size="6px" ID="Label4" runat="server" Text=""></asp:Label>--%>
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
        </table>
       

    
     


    </div>

    </form>
</body>
</html>
