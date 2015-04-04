<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmPatientHistory.aspx.cs" Inherits="transaction_wfrmPatientHistory" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Patient History</title>
    <link href="../LIMS.css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript">
 function fullscreen(){
     window.moveTo(0,0); 
window.resizeTo(screen.availWidth,screen.availHeight); 
       } </script>

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body onload="fullscreen()">
    <form id="form1" runat="server">
         <table id="main" cellpadding="1" align="center" cellspacing="1" border="0" width="100%" class="label" style="BORDER-RIGHT: teal thin solid; BORDER-TOP: teal thin solid; BORDER-LEFT: teal thin solid; BORDER-BOTTOM: teal thin solid">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Patient History</td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td></td>
            <td>
            </td>
        </tr>
         <tr>
            <td></td>
            <td>
                PR No:</td>
            <td>
                <asp:Label ID="lblPRno" runat="server" ForeColor="DarkBlue"></asp:Label></td>
            <td>
                Name:</td>
             <td colspan="2">
                 <asp:Label ID="lblName" runat="server" ForeColor="DarkBlue"></asp:Label></td>
            <td>
                <asp:Label ID="lblTest" runat="server" ForeColor="DarkBlue"></asp:Label></td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td>
                Test:</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlTest" runat="server" AutoPostBack="True" CssClass="dropdown"
                    OnSelectedIndexChanged="ddlTest_SelectedIndexChanged" Width="60%">
                </asp:DropDownList></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
         <tr>
            <td></td>
            <td colspan="6">
                <asp:GridView id="gvAttrib" runat="server" DataKeyNames="attributeid,testid" Width="70%" CssClass="datagrid" AutoGenerateColumns="False" OnRowDataBound="gvAttrib_RowDataBound">
                    <RowStyle CssClass="gridItem" />
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                    <Columns>
                        <asp:BoundField DataField="attrib_name" HeaderText="Attribute">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="50%" />
                        </asp:BoundField>                        
                        <asp:TemplateField>
									<ItemTemplate>
									    <TR>
											<TD colspan="6">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="left">
															<DIV id="divOrders" style="display:inline" runat="server">
                                                                <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" CssClass="datagrid"  Width="100%">
                                                                    <RowStyle CssClass="gridItem" />
                                                                    <HeaderStyle CssClass="gridheader" />
                                                                    <AlternatingRowStyle CssClass="gridAlternate" />
                                                                    <Columns>																																				
																		<asp:BoundField DataField="result" ReadOnly="True" HeaderText="Result">
																			<HeaderStyle HorizontalAlign="left"></HeaderStyle>
																			<ItemStyle HorizontalAlign="left" Width="30%" />
																		</asp:BoundField>																																																																																																																			
																			<asp:BoundField DataField="range" ReadOnly="True" HeaderText="Range">
																			<HeaderStyle HorizontalAlign="left"></HeaderStyle>
																			<ItemStyle HorizontalAlign="left" Width="30%" />
																		</asp:BoundField>
																		<asp:BoundField DataField="enteredon" ReadOnly="True" HeaderText="Date">
																			<HeaderStyle HorizontalAlign="left"></HeaderStyle>
																			<ItemStyle HorizontalAlign="left" Width="30%" />
																		</asp:BoundField>																	
																	</Columns>	
                                                                </asp:GridView>
                                                               
															</DIV>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</ItemTemplate>
                            
								</asp:TemplateField>
                    </Columns>
                </asp:GridView> 
            </td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td colspan="6">
                <%--<cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
                     enabletheming="False" hascrystallogo="False" hasdrillupbutton="False"
                    hasexportbutton="False" hasgotopagebutton="False" hasprintbutton="False"
                    hassearchbutton="False" hastogglegrouptreebutton="False" 
                    haszoomfactorlist="False" height="50px" reuseparametervaluesonrefresh="True"
                    width="99" DisplayToolbar="False" HasPageNavigationButtons="False"></cr:crystalreportviewer>--%><%--displaygrouptree="False  hasviewlist="False"--%>
            </td>
            <td></td>
        </tr>
         <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
         <tr>
            <td width="5%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="5%"></td>
        </tr>
    </table>
    </form>
</body>
</html>
