<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptIndoorDueBalance.aspx.cs" Inherits="transaction_RptIndoorDueBalance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
            <asp:Image ID="Img_headerMain" Visible="false" Height="50px" Width="100%"  runat="server" />
            <asp:Image ID="Img_empty"  Visible="true" ImageUrl="headerfooter/empty.jpg" Height="10px" runat="server" />
           <table width="100%">
           <tr>
           <td align="left" style="width:15%;">
                    <asp:Image ID="Img_header" Visible="false" Height="50px" Width="200px"  runat="server" />
           </td>
           <td align="center" style="width:70%;"><h2>Indoor Summary Report</h2>
          <%-- <asp:Label runat="server" ID="lb_fiscalyear" Text="1 jul,2012 - 30 jun,2013"></asp:Label>--%>
           </td>
           <td style="width:15%;">
               <asp:Image ID="Image2" Width="160px" Height="20px" ImageUrl="~/transaction/barcode.jpg" runat="server" />
               </td>
           </tr>
           </table>

           <table width="100%">
            <tr>



                <td align="right">
          
                <asp:LinkButton  ID="LinkButton3" 
                runat="server" onclick="CurrentReceivable_Click">30 Days</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton  ID="LinkButton2" 
                runat="server" onclick="btn60Dyas_Click" >60 Days</asp:LinkButton>
                &nbsp;&nbsp;
                 <asp:LinkButton  ID="btn90Dyas" 
                runat="server" onclick="btn90Dyas_Click" >90 Days</asp:LinkButton>
         &nbsp;&nbsp;
         &nbsp;&nbsp; <asp:LinkButton ID="AllReceivable" runat="server" 
                onclick="AllReceivable_Click">View All </asp:LinkButton>
                  <div style="margin:auto; height:20px; background:#eeeeee; width:180px; float:left;">
      
     </div>

           <div style="clear:both;"></div>
          
 
                </td>
            </tr>
           </table>

             <fieldset style="border-radius:12px;">
               <legend>Cash Balance</legend>
               <asp:GridView ID="Gv_DueBalance" runat="server" AutoGenerateColumns="False" 
                   Font-Size="9px" HorizontalAlign="Left" Width="100%" CellPadding="2" 
                     ForeColor="#333333" GridLines="None" 
                     onrowcommand="Gv_DueBalance_RowCommand" 
                     onrowdatabound="Gv_DueBalance_RowDataBound">
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
                       <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                       </asp:TemplateField>
                        <asp:BoundField DataField="labid" HeaderText="Visit #" SortExpression="labid" />
                      
                       <asp:BoundField DataField="enteredon" HeaderText="Date" 
                           SortExpression="enteredon" />
                       <asp:BoundField DataField="prno" HeaderText="Pr #" SortExpression="Prno" />
                       <asp:BoundField DataField="patient" HeaderText="Patient" SortExpression="patient" />
                      <%-- <asp:BoundField DataField="pname" HeaderText="Location" 
                           SortExpression="pname" />--%>
                       <asp:BoundField DataField="M_Bmode" HeaderText="Type" 
                            />
                       <asp:BoundField DataField="ward" HeaderText="Ward" 
                            />
                       <asp:BoundField DataField="adm_ref" HeaderText="Ref. Adm No" 
                            />
                       <asp:BoundField DataField="totalamount" HeaderText="Total" 
                           SortExpression="totalamount" />
                       <asp:BoundField DataField="paidamount" HeaderText="Paid" 
                           SortExpression="paidamount" />
                       <asp:BoundField DataField="discount_amt" HeaderText="Discount" 
                           SortExpression="discount_amt" />
                       <asp:BoundField DataField="Balance" HeaderText="Balance" />
                       <asp:CommandField SelectText="Pay Now" Visible="false" ShowSelectButton="True" />
                     
                       <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Hyp_Balance" runat="server">
                                          <asp:Image ID="Img_Payed" Width="16px" Height="16px" ToolTip="Pay Now" Visible="true" ImageUrl="~/img/Money1.png"
                                            runat="server" />
                                    </asp:HyperLink>
                                </ItemTemplate>
                           <ItemStyle Width="6%" />
                       </asp:TemplateField>
                            

                   </Columns>
                   <EditRowStyle BackColor="#2461BF" />
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" Font-Bold="True" 
                       ForeColor="White" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <RowStyle HorizontalAlign="Left" BackColor="#D1EED6" />
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <SortedAscendingCellStyle BackColor="#F5F7FB" />
                   <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                   <SortedDescendingCellStyle BackColor="#E9EBEF" />
                   <SortedDescendingHeaderStyle BackColor="#4870BE" />
               </asp:GridView>
              
              <table width="88%">
               <tr>
               <td align="right">
                            <asp:Label ID="Label_Bal" runat="server" Font-Size="10px" Text="" 
                                style="font-weight: 700"></asp:Label>
                            <asp:Label ID="Lb_CashBalance"  Font-Size="10px" Text="" runat="server" 
                                style="font-weight: 700"></asp:Label>
               </td>
               </tr>
               </table>
           </fieldset>






         <fieldset style="border-radius:12px; visibility:hidden;" >
           <legend>Panel Balance</legend>
               <asp:GridView ID="Gv_PanelBalance" runat="server" AutoGenerateColumns="False" 
                   Font-Size="9px" HorizontalAlign="Left" Width="100%" CellPadding="4" 
                 ForeColor="#333333" GridLines="None">
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
                    <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="enteredon" HeaderText="Date" 
                           SortExpression="enteredon" />
                       <asp:BoundField DataField="Prno" HeaderText="Pr #" SortExpression="Prno" />
                       <asp:BoundField DataField="labid" HeaderText="Visit #" SortExpression="labid" />
                       <asp:BoundField DataField="name" HeaderText="Patient" SortExpression="name" />
                       <asp:BoundField DataField="pname" HeaderText="Location" 
                           SortExpression="pname" />
                       <asp:BoundField DataField="enteredby" HeaderText="Entered By" 
                           SortExpression="enteredby" />
                       <asp:BoundField DataField="totalamount" HeaderText="Total" 
                           SortExpression="totalamount" />
                       <asp:BoundField DataField="paidamount" HeaderText="Paid" 
                           SortExpression="paidamount" />
                       <asp:BoundField DataField="discount_amt" HeaderText="Discount" 
                           SortExpression="discount_amt" />
                       <asp:BoundField DataField="bal" HeaderText="Balance" />
                   </Columns>
                   <EditRowStyle BackColor="#2461BF" />
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" Font-Bold="True" 
                       ForeColor="White" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <RowStyle HorizontalAlign="Left" BackColor="#D1EED6" />
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <SortedAscendingCellStyle BackColor="#F5F7FB" />
                   <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                   <SortedDescendingCellStyle BackColor="#E9EBEF" />
                   <SortedDescendingHeaderStyle BackColor="#4870BE" />
               </asp:GridView>
               <hr />
               <table width="97%">
               <tr>
               <td align="right">
                   <asp:Label ID="Label1"  runat="server" Font-Bold="true" Font-Size="15px" Text=""></asp:Label>
                   <asp:Label ID="Lb_PanelBalance"  Text="" Font-Bold="true" Font-Size="152px" runat="server"></asp:Label>
                   
               </td>
               </tr>
               </table>
               
           </fieldset>

    </div>
    </form>
</body>
</html>
