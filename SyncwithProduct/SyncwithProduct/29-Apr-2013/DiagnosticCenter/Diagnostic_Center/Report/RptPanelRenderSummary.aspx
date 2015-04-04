<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptPanelRenderSummary.aspx.cs" Inherits="Report_RptPanelRenderSummary" %>
<%@ Register Assembly="Shared.WebControls" Namespace="Shared.WebControls" TagPrefix="wc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Image ID="Img_headerMain" Visible="false" Height="50px" Width="100%" runat="server" />
        <asp:Image ID="Img_empty" Visible="true" ImageUrl="../transaction/headerfooter/empty.jpg" Height="10px"
            runat="server" />
        <table width="100%" style="height:15px; top:0; position:fixed;">
            <tr>
                <td align="left" style="width: 15%;">
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
                                &nbsp;<asp:Label ID="Lb_txPRNo" Visible="false" runat="server" Font-Bold="true" Text="PR No:"></asp:Label>
                                <asp:Label ID="Lb_PRNO" runat="server" Visible="false" Text=""></asp:Label>
                            </td>
                            <td rowspan="2" align="center">
                                <h3>
                                   Panel Services Rendered Summary</h3>
                            </td>
                            <td align="right">
                                <asp:Label ID="LB_txVisit" runat="server"  Font-Bold="true" Visible="false" Text="Visit No:"></asp:Label>
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
            
            <tr>
                <td colspan="3">
                    <fieldset style="border-radius: 10px; visibility:hidden;">
                        <asp:GridView Width="100%" Font-Size="11px" Style="font-family: Tahoma; color: Black;"
                            ID="Gv_PatientPrimaryInfo" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                            GridLines="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <table cellpadding="2" cellspacing="2">
                                                    <tr>
                                                            <td>
                                                                <asp:Label ID="lblBranch" runat="server" Font-Bold="true" Text="Branch"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblPanelName" runat="server" Font-Bold="true" Text="Panel"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblpanelNameValue" runat="server" Text='<%# Eval("PanelName")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblConsultant" runat="server" Font-Bold="true" Text="Consultant"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblConsultantVal" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblReportDate" runat="server" Font-Bold="true" Text="Report Date:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("DateRange")  %>'></asp:Label>
                                                                
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="right">
                                                    <table cellpadding="2" cellspacing="2">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="PrintedOn" runat="server" Font-Bold="true" Text="Printed On:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPrintedOn" runat="server" Text='<%# Eval("PrintedOn")  %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
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
        <wc:ReportGridView style="top:120px; position:relative;" ID="gvMain" runat="server" Width="99%" ShowHeader="true" AutoGenerateColumns="false"
            AlternatingRowStyle-BorderStyle="None" PrintPageSize="30" AllowPrintPaging="true"
            Font-Size="11px" GridLines="None">
            <HeaderStyle BackColor="#CCCCCC" />
            <RowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD" />
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                <table id="gvtbl" width="99%">
                            <tr style="background-color: #CCCCCC; font-size:11px; font-weight:bold;">
                                <td style="font-weight: bold;" width="85%">
                                    Client
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                   Amount
                                </td>
                            </tr>
                            </table>
                </HeaderTemplate>
                    <ItemTemplate>
                        <table id="gvtbl" width="99%">
                            <tr style="background-color: #EEEEEE;">
                                <td style="font-weight: bold;" width="85%">
                                    <asp:Label ID="Lb_Client" runat="server" Text='<%# Eval("panelname") %>'></asp:Label>
                                </td>
                                <td style="font-weight: bold;" width="15%">
                                    <asp:Label ID="Lb_Rate" runat="server" Text='<%# Eval("rate") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </wc:ReportGridView>

     

    
    </div>
    </form>
</body>
</html>
