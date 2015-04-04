<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Refund.aspx.cs" Inherits="Refund" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Refund Receipt</title>
    <link href="LIMS.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
    function fullscreen(){
     window.moveTo(0,0); 
window.resizeTo(screen.availWidth,screen.availHeight); 
       } 
</script>
</head>
<body onload="fullscreen()">
    <form id="form1" runat="server">
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label" unselectable="on">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                BIO CARE LABS</td>
        </tr>
     <tr>
         <td align="center" class="screenid" colspan="8">
             &nbsp;</td>
     </tr>
     <tr>
         <td>
         </td>
         <td>
         </td>
         <td align="center" colspan="4">
             <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
         <td>
             <asp:Label ID="lblTel" runat="server"></asp:Label></td>
         <td>
         </td>
     </tr>
        <tr>
            <td></td>
            <td>
                </td>
            <td></td>
            <td align="center" colspan="2">
                Cash Refund Slip</td>
            <td></td>
            <td>
                24 Hours Service</td>
            <td></td>
        </tr>
     <tr>
         <td class="screenid" colspan="8">
             &nbsp;</td>
     </tr>
        
        <tr>
            <td></td>
            <td colspan="2">            
                
                              </td>
                
                
                
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                &nbsp;</td>
            <td></td>
        </tr>
     <tr>
         <td colspan="8">
             <asp:Panel ID="pnlInfo" runat="server" Height="100px" Width="99%" BorderWidth="1px">
                <table id="tb_info" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                    <tr>
                        <td>
                            Refund #:</td>
                        <td>
                <asp:Label ID="lblReceipt" runat="server"></asp:Label></td>
                        <td>
                LAB ID:</td>
                        <td>
                <asp:Label ID="lblLabID" runat="server"></asp:Label></td>
                        <td>
                            Refund By:</td>
                        <td><asp:Label ID="lblReceivdBy" runat="server"></asp:Label></td>
                        
                    </tr>
                    <tr>
                        <td>
                PR No:</td>
                        <td>
                <asp:Label ID="lblPRNo" runat="server"></asp:Label></td>
                        <td>
                Name:</td>
                        <td>
                <asp:Label ID="lblPatient" runat="server"></asp:Label></td>
                        <td>
                            Refund On:</td>
                        <td><asp:Label ID="lblReceivdOn" runat="server"></asp:Label></td>
                        
                    </tr>
                    <tr>
                        <td>
                            Age:</td>
                        <td>
                            <asp:Label ID="lblAGe" runat="server"></asp:Label>
                            (s)</td>
                        <td>
                            Gender:</td>
                        <td>
                            <asp:Label ID="lblGender" runat="server"></asp:Label></td>
                        <td>
                            Authorized By:</td>
                        <td>
                            <asp:Label ID="lblAuthorized" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            Type:</td>
                        <td>
                            <asp:Label ID="lblType" runat="server"></asp:Label></td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td width="11%"></td>
                        <td width="17%"></td>
                        <td width="8%"></td>
                        <td width="25%"></td>
                        <td width="14%"></td>
                        <td width="25%"></td>
                        
                    </tr>
                </table>
             </asp:Panel>
         </td>
     </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
     <tr>
         <td>
         </td>
         <td colspan="6">
             <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" CssClass="datagrid" Width="99%">
                 <RowStyle CssClass="gridItem" />
                 <Columns>
                     <asp:TemplateField HeaderText="S.No">
                         <HeaderStyle HorizontalAlign="Right" />
                         <ItemStyle HorizontalAlign="Right" Width="5%" /> 
                        
                         <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="testname" HeaderText="Test">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle HorizontalAlign="Left" Width="50%" />
                     </asp:BoundField>
                     <asp:BoundField DataField="totalamount" HeaderText="Total Amount">
                         <HeaderStyle HorizontalAlign="Right" />
                         <ItemStyle HorizontalAlign="Right" Width="15%" />
                     </asp:BoundField>
                     <asp:BoundField DataField="PaidAmount" HeaderText="Refund Amount">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle HorizontalAlign="Left" Width="30%" />
                     </asp:BoundField>
                 </Columns>
                 <HeaderStyle CssClass="gridheader" />
                 <AlternatingRowStyle CssClass="gridAlternate" />
             </asp:GridView>
         </td>
         <td>
         </td>
     </tr>
        <tr>
            <td></td>
            <td colspan="4"></td>
            <td>
                </td>
            <td></td>
            <td></td>
        </tr>
     <tr>
         <td>
         </td>
         <td colspan="5">
            <table id="tb_amt" cellpadding="1" cellspacing="1" border="0" class="label" width="100%">
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        </td>
                    <td>
             </td>
                </tr>
                <tr>
                <td>
             Amount:</td>
                    <td rowspan="2" valign="top">
                <asp:Label ID="lblword" runat="server"></asp:Label></td>
                    <td>
                        Total Refund:</td>
                    <td><asp:Label ID="lblPaid" runat="server"></asp:Label></td>
                </tr>
                <tr>
                <td></td>
                    <td>
             </td>
                    <td></td>
                </tr>
                <tr>
                <td width="10%"></td>
                    <td width="50%"></td>
                    <td width="15%"></td>
                    <td width="25%"></td>
                </tr>
            </table>
         </td>
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
         <td>
         </td>
         <td>
         </td>
         <td align="left">
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
         <td>
         </td>
         <td>
         </td>
         <td>
         </td>
     </tr>
     <tr>
         <td class="screenid" colspan="8">
             &nbsp;</td>
     </tr>
     <tr>
         <td>
         </td>
         <td colspan="6">
             NOTE: -</td>
         <td>
         </td>
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
         <td>
         </td>
         <td>
         </td>
     </tr>
        <tr>
            <td width="2%"></td>
            <td width="10%"></td>
            <td width="18%"></td>
            <td width="12%"></td>
            <td width="25%"></td>
            <td width="11%"></td>
            <td width="20%"></td>
            <td width="4%"></td>
        </tr>
    </table>
    </form>
</body>
</html>
