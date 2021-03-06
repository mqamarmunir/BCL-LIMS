﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="panelservices(outstanding).aspx.cs" Inherits="Report_HTMLReporting_panelservices_outstanding_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shared.WebControls" Namespace="Shared.WebControls" TagPrefix="wc" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table width="100%">
            <tr>
                <td colspan="3">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size: 12px;
                        font-family: Tahoma;">
                        <tr>
                            
                            <td colspan="4" align="left">
                                <h3>
                                    Panel Services Statement</h3>
                                <p style="font-weight: bold">
                                    From(<asp:Label ID="lblBranchname" runat="server" Font-Bold="true"></asp:Label>)</p>
                                <p style="font-weight: bold">
                                    Period:(<asp:Label ID="lbldaterange" runat="server"></asp:Label>)</p>
                            </td>
                            
                        </tr>
                        </table>
                </td>
                <td colspan="3">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="font-size: 12px;
                        font-family: Tahoma;">
                        <tr>
                            
                            <td colspan="4"  align="left">
                                <h3>
                                    <%--BIOCARE Labs (Private) Ltd.--%><asp:Label ID="lblOrgName" runat="server"></asp:Label></h3>
                                
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>  
                                <br />                             
                                <asp:Label ID="lblPhonenum" runat="server"></asp:Label>
                               
                            </td>
                            
                        </tr>
                      
                        </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    
                </td>
            </tr>
            <tr style="display:none">
            <td width="20%"></td>
            <td width="20%"></td>
            <td width="15%"></td>
            <td width="15%"></td>
            <td width="15%"></td>
            <td width="15%"></td>
            </tr>
        </table>


        <table id="tblxxx" width="99%">
<tr>
<td colspan="7">

        <wc:ReportGridView ID="gvMain" runat="server" Width="99%" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="20" AllowPrintPaging="true"
            Font-Size="11px"  
            GridLines="None">
            <AlternatingRowStyle BorderStyle="None" BackColor="Silver"></AlternatingRowStyle>
            <HeaderStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate>
                        <table id="gvtblheader" width="100%">
                            <tr style="background-color: #DDDDDD">
                                <td style="font-weight: bold;" width="80%">
                                    Panel
                                </td>
                                
                                <td style="font-weight: bold;" width="20%">
                                    Net Amount
                                </td>
                                <%--<td style="font-weight:bold;" width="10%">Charges</td>
         <td style="font-weight:bold;" width="8%">Discount</td>
         <td style="font-weight:bold;" width="10%">Balance</td>--%>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="100%" cellpadding="1">
                            <tr>
                                <td>
                                    
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("PanelName")%>'></asp:Label>
                                </td>
                               
                                <td>
                                    <asp:Label ID="lblAmount" Text='<%#Eval("rate")%>' runat="server" ></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td width="80%">
                                </td>
                                
                                <td width="20%">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>

</td>
</tr>
    
    </div>
    </form>
</body>
</html>
