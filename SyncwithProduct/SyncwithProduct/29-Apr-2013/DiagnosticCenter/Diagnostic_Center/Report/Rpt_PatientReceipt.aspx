<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_PatientReceipt.aspx.cs" Inherits="Report_Rpt_PatientReceipt" %>
<%@ Register Assembly="Shared.WebControls" Namespace="Shared.WebControls" TagPrefix="wc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%-- <img src="images/logos.jpg" width="100%" height="80px" alt="" /> --%>
        <asp:Image ID="Img_headerMain" Visible="false" Height="50px" Width="100%" runat="server" />
        <asp:Image ID="Img_empty" Visible="true" ImageUrl="../transaction/headerfooter/empty.jpg" Height="10px"
            runat="server" />
        <table width="100%">
            <tr>
                <td align="left" style="width: 15%;">
                <asp:Image ID="Image1" Visible="false" Height="50px" Width="200px"  runat="server" />
                    <asp:Image ID="Img_header" ImageUrl="../transaction/headerfooter/BCL LOGO.jpg" Visible="true" Height="50px" Width="200px" runat="server" />
                </td>
                <td align="center" style="width: 70%;">
                    <p style="font-size: 9px; font-weight: bold; text-align: center;">
                        <asp:Label ID="Lb_BranchNames" Font-Size="18px" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label6" Font-Size="9px" Font-Bold="true" runat="server" Text="Timings:"></asp:Label>
                        <asp:Label ID="Lb_starttime" Font-Size="10px" runat="server" Text="txbx_starttime"></asp:Label>-<asp:Label
                            ID="Lb_endtime" Font-Size="10px" runat="server" Text="txbx_endtime"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" Font-Size="9px" Font-Bold="true" runat="server" Text="Ph No:"></asp:Label>
                        <asp:Label ID="lb_phonebranchmain" Font-Size="9px" runat="server" Text=""></asp:Label>
                        &nbsp;
                        <asp:Label ID="LB_Ext" Font-Size="9px" Font-Bold="true" runat="server" Text="Ext:" />
                        <asp:Label ID="Lb_Extension" Font-Size="9px" runat="server" Text=""></asp:Label>
                    </p>
                </td>
                <td style="width: 15%;">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size: 12px;
                        font-family: Tahoma;">
                        <tr>
                            <td>
                                &nbsp;<asp:Label ID="Lb_txPRNo" Visible="true" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                                <asp:Label ID="Lb_PRNO" runat="server" Visible="false" Text=""></asp:Label>
                            </td>
                            
                            <td align="right">
                                <asp:Label ID="LB_txVisit" runat="server"  Font-Bold="true" Visible="true" Text="Visit No:"></asp:Label>
                                <asp:Label ID="Lb_Visit" Visible="false" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td align="right" style="visibility: hidden;">
                               
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
                    <fieldset style="border-radius: 10px;">
                        <%--<asp:GridView Width="100%" Font-Size="11px" Style="font-family: Tahoma; color: Black;"
                            ID="Gv_PatientPrimaryInfo" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                            GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>--%>
                                        <table width="100%" style="font-size: 11px;">
                                            <tr>
                                                <td>
                                                    <table cellpadding="2" cellspacing="2">
                                                     <tr>
                                                            <td>
                                                                <asp:Label ID="lblrefno" runat="server" Font-Bold="true" Text="Reference No:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblReferenceNo" runat="server" Text='<%# Eval("referenceno")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    
                                                    <tr>
                                                            <td>
                                                                <asp:Label ID="lblPatient" runat="server" Font-Bold="True" Text="Patient Name:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPatientName" runat="server" Text='<%# Eval("patient")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblAge" runat="server" Font-Bold="True" Text="Age/Sex:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAgeSex" runat="server" Text='<%# Eval("age")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPassword" runat="server" Font-Bold="True" Text="Password:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPasswordtext" runat="server" Text='<%#Eval("pasword")%>'></asp:Label>
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
                                                        --%>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPhone" runat="server" Font-Bold="true" Text="Phone:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("cellno")  %>'></asp:Label>
                                                                
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="right">
                                                    <table cellpadding="2" cellspacing="2">
                                                        <tr>
                                                            <td class="style1">
                                                                <asp:Label ID="lblward" runat="server" Font-Bold="true" Text="Ward:"></asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:Label ID="lblwardname" runat="server" Text='<%# Eval("ward")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                                <asp:Label ID="lblRegDate" runat="server" Font-Bold="true" Text="Registration On:"></asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:Label ID="lblRegistrationDate" runat="server" Text='<%# Eval("enteredon")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                            <asp:Label ID="lblCollect" runat="server" Font-Bold="true" Text="Collect Report At:"></asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                            <asp:Label ID="lblCollectedOn" runat="server" Visible="true" Text='<%# Eval("receivedon")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                            <asp:Label ID="lblConsultant" runat="server" Font-Bold="true" Text="Consultant:"></asp:Label>
                                                            </td>
                                                           <td class="style1">
                                                             <asp:Label ID="lblConsultantName" runat="server" Text='<%# Eval("Consultant")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                                <asp:Label ID="lblpanel" runat="server" Font-Bold="true" Text="Panel:"></asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:Label ID="lblPanelname" runat="server" Text='<%# Eval("panelname")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    <%--</ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Wrap="True" />
                        </asp:GridView>--%>
                    </fieldset>
                </td>
            </tr>
           <tr>
                <td colspan="3">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size: 12px;
                        font-family: Tahoma;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td rowspan="2" align="center">
                                <h3>
                                    Patient Receipt</h3>
                            </td>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td align="right" style="visibility: hidden;">
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr> 
        </table>
        <%-- <fieldset style="border-radius:10px;">--%>
        <%--  <table id="tblxxx" width="99%">
<tr>
<td colspan="10">--%>

        <wc:ReportGridView ID="gvMain" runat="server" Width="99%" ShowHeader="true" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="17" AllowPrintPaging="true"
            Font-Size="11px" DataKeyNames="bookingid" 
            GridLines="None">
            <HeaderStyle BackColor="#CCCCCC" />
            <RowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD" />
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                <table id="gvtbl" width="99%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="10%">
                                    Sr#
                                </td>
                                <td style="font-weight: bold;" width="18%">
                                    Test Name
                                </td>
                                <td style="font-weight: bold;" width="18%">
                                    Test Code
                                </td>
                                <td style="font-weight: bold;" width="18%">
                                    Reporting Date Time
                                </td>
                                <%--<td style="font-weight: bold;" width="18%">
                                    Time
                                </td>--%>
                                <td style="font-weight: bold;" width="18%">
                                    Rate
                                </td>
                                
                            </tr>
                            </table>
                </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="99%">
                            <%--<tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="10%">
                                    Date
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                    Lab ID
                                </td>
                                <td style="font-weight: bold;" width="8%">
                                    Patient
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Panel
                                </td>
                                <td style="font-weight: bold;" width="9%">
                                    Consultant
                                </td>
                                <td style="font-weight: bold;" width="9%">
                                    Entered By
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Total
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Paid
                                </td>
                                <td style="font-weight: bold;" width="8%">
                                    Discount
                                </td>
                                <td style="font-weight: bold;" width="10%">
                                    Balance
                                </td>
                            </tr>--%>
                            <tr>
                                <td width="10%">
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                </td>
                                <td width="18%">
                                    <asp:Label ID="lbllabid" runat="server" Text='<%#Eval("testname")%>'></asp:Label>
                                </td>
                                <td width="18%">
                                    <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("speedkey")%>'></asp:Label>
                                </td>
                                <%--<td width="18%">
                                    <asp:Label ID="lblPanel" runat="server" Text='<%#Eval("Panel")%>'></asp:Label>
                                </td>--%>
                                <td width="18%">
                                    <%-- <asp:Label ID="lblAdmNo" Visible="true" runat="server" Text='<%#Eval("adm_ref")%>' ></asp:Label>--%>
                                    <asp:Label ID="lblConsultant" Visible="true" runat="server" Text='<%#Eval("deliverytime")%>'></asp:Label>
                                </td>
                                <td width="18%">
                                    <asp:Label ID="lblrate" Visible="true" runat="server" Text='<%#Eval("charges")%>'></asp:Label>
                                </td>
                                
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>
<p style="font-size:10px;">
        Entered By:&nbsp; <asp:Label ID="Enteredby" runat="server" Visible="true" Text=""></asp:Label>
        </p>
                            &nbsp;<%--   </td>
</tr>
<tr>
<td colspan="5"></td>
<td colspan="5">--%><table id="ttltable" style="background-color: #DDDDDD; font-size: 12px;" cellpadding="0"
            cellspacing="0" border="0" width="99%">
            <tr>
                <td style="width: 60%;">
                </td>
                <td style="font-weight: bold;  width:10%"">
                    Total:</td>
                <td style="font-weight: bold;  width:10%"">
                 <asp:Label ID="lbltotcharges" runat="server"></asp:Label>
                 </td>
                 </tr>
                 <tr>
                 <td style="width: 60%;">
                </td>
                  <td style="font-weight: bold;  width:10%"">
                    Paid
                      (Now):</td>
                <td style="font-weight: bold;  width:10%"">
                <asp:Label ID="lbltotpaid" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                 <td style="width: 60%;">
                </td>
                  <td style="font-weight: bold;  width:10%"">
                      Discount:</td>
                <td style="font-weight: bold;  width:10%"">
                <asp:Label ID="lbldiscount" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td style="width: 60%;">
                    &nbsp;</td>
                 <td style="font-weight: bold; width:10%">
                     Total Paid:</td>
                <td style="font-weight: bold; width:10%">
                 <asp:Label ID="lbltotalpaid" runat="server"></asp:Label>
                    &nbsp;</td>
                    </tr>
                    <tr>
                    <td style="width: 60%;">
                </td>
                <td style="font-weight: bold;  width:10%">
                    Balance:</td>
                <td  style="font-weight: bold; width:10%">
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
