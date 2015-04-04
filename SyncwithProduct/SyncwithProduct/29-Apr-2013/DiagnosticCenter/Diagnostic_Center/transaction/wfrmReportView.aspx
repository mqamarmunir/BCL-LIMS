<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmReportView.aspx.cs" Inherits="Report_wfrm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Report</title>
    <link href="../LIMS.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
    function fullscreen(){
     window.moveTo(0,0); 
window.resizeTo(screen.availWidth,screen.availHeight); 
       } 
</script>
</head>
<body onload="fullscreen()">
    <form id="form1" runat="server">
      <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
          <tr>
              <td align="center" class="tdheading" colspan="4">
                  BIO CARE LABS</td>
          </tr>
          <tr>
              <td class="screenid" colspan="4">
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
              </td>
              <td align="center" colspan="2">
                  <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
              <td>
                  <asp:Label ID="lblTel" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td>
              </td>
              <td>
              </td>
              <td>
              </td>
              <td>
                  <asp:Label ID="lblGenratedOn" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td style="font-size:medium" colspan="2"><b>
                  <asp:Label ID="lblMas_Test_H" runat="server"></asp:Label></b></td>
              <td>
              </td>
              <td>
                  <asp:Label ID="lblPrintOn" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td colspan="4" align="center">
              ---------------------------------------------------------------------------------------------------------------------------------------</td>
          </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblCount" runat="server" ForeColor="DarkBlue" Text="Label" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvTestList" runat="server" AutoGenerateColumns="False" DataKeyNames="testid"
                    Width="99%" CellPadding="3" Font-Size="X-Small" OnRowDataBound="gvTestList_RowDataBound" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" GridLines="None">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <RowStyle ForeColor="Black" BackColor="#DEDFDE" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                :
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="4%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Subdepartment" HeaderText="Department">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="13%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="test_name" HeaderText="Test Name">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="26%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="charges" HeaderText="Private_Rate">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="charityrate" HeaderText="Charity_Rate">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="specimen_name" HeaderText="Specimen">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tat" HeaderText="TAT">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Active" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Performing Days">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
          <tr>
              <td colspan="4">
                  <asp:Label ID="lblExternal" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label></td>
          </tr>
          <tr>
              <td colspan="4">
                  <asp:GridView ID="gvExternal" runat="server" AutoGenerateColumns="False" DataKeyNames="testid"
                    Width="99%" CellPadding="3" Font-Size="X-Small" GridLines="None" OnRowDataBound="gvExternal_RowDataBound" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1">
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <Columns>
                          <asp:TemplateField HeaderText="S.No">
                              <ItemTemplate>
                                  <%#Container.DataItemIndex+1 %>
                                  :
                              </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="4%" />
                          </asp:TemplateField>
                          <asp:BoundField DataField="Subdepartment" HeaderText="Department">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="13%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="test_name" HeaderText="Test Name">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="17%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="charges" HeaderText="Private_Rate">
                              <HeaderStyle HorizontalAlign="Right" />
                              <ItemStyle HorizontalAlign="Right" Width="8%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="charityrate" HeaderText="Charity_Rate">
                              <HeaderStyle HorizontalAlign="Right" />
                              <ItemStyle HorizontalAlign="Right" Width="8%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="specimen_name" HeaderText="Specimen">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="10%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="tat" HeaderText="TAT">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="8%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="active" HeaderText="Active" Visible="False">
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="3%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="extorg" HeaderText="LAB">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:TemplateField HeaderText="Performing Days">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="14%" />
                          </asp:TemplateField>
                      </Columns>
                      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                      <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td colspan="4">
                  <asp:GridView ID="gvCashClose" runat="server" AutoGenerateColumns="False" CssClass="datagrid">
                      <RowStyle CssClass="gridItem" />
                      <HeaderStyle CssClass="gridheader" />
                      <AlternatingRowStyle CssClass="gridAlternate" />
                      <Columns>
                          <asp:TemplateField HeaderText="S.No">
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="5%" />
                              <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="receiveno" HeaderText="Paid No">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="prno" HeaderText="PR No">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="patientname" HeaderText="Patient Name">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="25%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="paymentmode" HeaderText="Mode">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="10%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="paidamount" HeaderText="Amount">
                              <HeaderStyle HorizontalAlign="Right" />
                              <ItemStyle HorizontalAlign="Right" Width="10%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="receiveon" HeaderText="Date Time">
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="25%" />
                          </asp:BoundField>
                      </Columns>
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td colspan="4">
                  &nbsp;<asp:Label ID="lblRefund" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label></td>
          </tr>
          <tr>
              <td colspan="4">
                  <asp:GridView ID="gvRefund" runat="server" AutoGenerateColumns="False" CssClass="datagrid">
                      <RowStyle CssClass="gridItem" />
                      <Columns>
                          <asp:TemplateField HeaderText="S.No">
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="5%" />
                              <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="refundno" HeaderText="Refund No">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="prno" HeaderText="PR No">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="patientname" HeaderText="Patient Name">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="25%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="refundtype" HeaderText="Type">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="10%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="paidamount" HeaderText="Amount">
                              <HeaderStyle HorizontalAlign="Right" />
                              <ItemStyle HorizontalAlign="Right" Width="10%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="refundon" HeaderText="Date Time">
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="25%" />
                          </asp:BoundField>
                      </Columns>
                      <HeaderStyle CssClass="gridheader" />
                      <AlternatingRowStyle CssClass="gridAlternate" />
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td colspan="4">
                  <asp:GridView ID="gv_MC_rec" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="bookingid" OnRowDataBound="gv_MC_rec_RowDataBound">
                      <RowStyle CssClass="gridItem" />
                      <Columns>
                          <asp:TemplateField HeaderText="S.No">
                              <ItemTemplate>
                                  <%#Container.DataItemIndex+1 %>
                                  :
                              </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="3%" />
                          </asp:TemplateField>
                          <asp:BoundField DataField="receiveno" HeaderText="Paid No">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="13%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="labid" HeaderText="Visit No">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="13%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="patientname" HeaderText="Patient Name">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="paidamount" HeaderText="Paid Amt">
                              <HeaderStyle HorizontalAlign="Right" />
                              <ItemStyle HorizontalAlign="Right" Width="8%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="paymentmode" HeaderText="Mode">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="5%" />
                          </asp:BoundField>                          
                          <asp:BoundField DataField="panelname" HeaderText="Panel">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="receivedon" HeaderText="Received On">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="12%" />
                          </asp:BoundField>
                           <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:GridView ID="gvModels" runat="server" ShowHeader="False">                      
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                           </asp:TemplateField>
                      </Columns>
                      <HeaderStyle CssClass="gridheader" />
                      <AlternatingRowStyle CssClass="gridAlternate" />
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td colspan="4">
                  <asp:GridView ID="gv_MC_ref" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="bookingid" OnRowDataBound="gv_MC_ref_RowDataBound">
                      <RowStyle CssClass="gridItem" />
                      <Columns>
                          <asp:TemplateField HeaderText="S.No">
                              <ItemTemplate>
                                  <%#Container.DataItemIndex+1 %>
                                  :
                              </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="5%" />
                          </asp:TemplateField>
                          <asp:BoundField DataField="refundno" HeaderText="Refund No">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="labid" HeaderText="Visit No">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="13%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="patientname" HeaderText="Patient Name">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="20%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="refundtype" HeaderText="Type">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="5%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="refundon" HeaderText="Refund On">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="12%" />
                          </asp:BoundField>
                          <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:GridView ID="gvTest" runat="server" ShowHeader="False">                      
                                    </asp:GridView>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="35%" />
                           </asp:TemplateField>
                      </Columns>
                      <HeaderStyle CssClass="gridheader" />
                      <AlternatingRowStyle CssClass="gridAlternate" />
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td>
              </td>
              <td colspan="3">
                  <asp:Panel ID="pnlSumary" runat="server" GroupingText="Cash Summary" Height="50px"
                      Width="99%">
                      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                      <asp:Label ID="lblTotalSales" runat="server" ForeColor="DarkBlue"></asp:Label>
                      &nbsp; &nbsp; &nbsp;&nbsp;
                      <asp:Label ID="lblPanelDue" runat="server" ForeColor="DarkBlue"></asp:Label>
                      &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblCashDue" runat="server" ForeColor="DarkBlue"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                  <asp:Label ID="lblCash" runat="server" ForeColor="DarkBlue"></asp:Label>&nbsp;&nbsp;
                      &nbsp;&nbsp;
                  <asp:Label ID="lblrefAmt" runat="server" ForeColor="DarkBlue"></asp:Label>
                      &nbsp; &nbsp;&nbsp;
                  <asp:Label ID="lblBalance" runat="server" ForeColor="DarkBlue"></asp:Label></asp:Panel>
              </td>
          </tr>
          <tr>
              <td colspan="4">
                  <asp:GridView ID="gvPanelTest" runat="server" AutoGenerateColumns="False" CssClass="datagrid">
                      <RowStyle CssClass="gridItem" />
                      <Columns>
                          <asp:TemplateField HeaderText="S.No">
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="5%" />
                              <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="groupname" HeaderText="Group">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="25%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="test_name" HeaderText="Test">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="40%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="acronym" HeaderText="Acronym">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="charges" HeaderText="Charges">
                              <HeaderStyle HorizontalAlign="Right" />
                              <ItemStyle HorizontalAlign="Right" Width="15%" />
                          </asp:BoundField>
                      </Columns>
                      <HeaderStyle CssClass="gridheader" />
                      <AlternatingRowStyle CssClass="gridAlternate" />
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td colspan="4">
                  <asp:GridView ID="gvWorkList" runat="server" AutoGenerateColumns="False" CssClass="datagrid" Width="100%">
                      <RowStyle CssClass="gridItem" />
                      <Columns>
                          <asp:TemplateField HeaderText="S#">
                              <HeaderStyle HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" Width="3%" />
                              <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="labid" HeaderText="Lab ID">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="12%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="patientname" HeaderText="Patient Name">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="18%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="gender" HeaderText="Gender">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="5%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="age" HeaderText="Age">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="10%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="testname" HeaderText="Test">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="25%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="bookedon" HeaderText="Booked On" SortExpression="bookedon">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="Deliverytime" HeaderText="Delivery Time">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="15%" />
                          </asp:BoundField>
                          <asp:BoundField DataField="origin" HeaderText="Origin">
                              <HeaderStyle HorizontalAlign="Left" />
                              <ItemStyle HorizontalAlign="Left" Width="5%" />
                          </asp:BoundField>
                      </Columns>
                      <HeaderStyle CssClass="gridheader" />
                      <AlternatingRowStyle CssClass="gridAlternate" />
                  </asp:GridView>
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
          </tr>
         <tr>
            <td width="20%"></td>
            <td width="25%"></td>
            <td width="25%"></td>
            <td width="30%"></td>
        </tr>
    </table>
    </form>
</body>
</html>
