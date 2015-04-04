<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmCaslList.aspx.cs" Inherits="transaction_wfrmCaslList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager2" runat="server">
                                </asp:ScriptManager>
<div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Cashier List</div>
<div>
<table width="100%">
<tr>
<td colspan="4" align="right">
    <asp:ImageButton ID="imgReport" runat="server" 
        ImageUrl="~/images/Search_OT.gif" OnClick="imgReport_Click" />
        <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" />
    </td>
</tr>
<tr>
<td align="center">From Date:</td>
<td>
    <asp:TextBox ID="txtfrom" runat="server"></asp:TextBox>
    <cc1:CalendarExtender ID="calextdob" runat="server" TargetControlID="txtfrom" Format="dd/MM/yyyy"></cc1:CalendarExtender>
    </td>
<td align="center">To Date:</td>
<td>
    <asp:TextBox ID="txttodate" runat="server"></asp:TextBox>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
    </td>
    <td>Report No:</td>
    <td><asp:TextBox ID="txtreportno" runat="server"></asp:TextBox></td>
</tr>
</table>


</div>

<div style="height:500px; overflow:scroll;">
    <table width="100%" >
  <tr><td></td></tr>
                             <tr>
            <td>
               </td>
            <td>
     
               <asp:GridView ID="Gv_DayCashList" EmptyDataText="Sorry! No record found on this branch"  runat="server" AutoGenerateColumns="False" 
                Width="100%" GridLines="Horizontal" CellPadding="0" ForeColor="#333333" 
                    onrowdatabound="Gv_DayCashList_RowDataBound" DataKeyNames="reportno" CssClass="listing">
                       <AlternatingRowStyle HorizontalAlign="Left"   CssClass="AltRow"/>
                <Columns>
                        <asp:TemplateField HeaderText="Sr#" ItemStyle-Width="2%">
                            <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="cashierName" HeaderText="Cashier Name" 
                            SortExpression="cashierName" ItemStyle-Width="20%" />
                        <asp:BoundField DataField="cashOpening_Amount" HeaderText="Opening Amt" 
                            SortExpression="cashOpening_Amount" ItemStyle-Width="10%" />
                        <asp:BoundField DataField="enteredon" HeaderText="Check In" 
                            SortExpression="enteredon" ItemStyle-Width="13%"/>
                        <asp:BoundField DataField="cashClosing_Amount" HeaderText="Closing Amt" 
                            SortExpression="cashClosing_Amount" ItemStyle-Width="10%" />
                        <asp:BoundField DataField="enteredoff" HeaderText="Check Out" 
                            SortExpression="enteredoff" ItemStyle-Width="15%" />
                        <asp:TemplateField HeaderText="Net Sale" ItemStyle-Width="10%" >
                            <ItemTemplate>
                                <asp:Label ID="Lb_NetSales" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Branch" 
                            SortExpression="branchid" ItemStyle-Width="10%"/>
                        <asp:TemplateField HeaderText="Status" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                           
                                   <asp:Image ID="Img_online" ImageUrl="~/transaction/headerfooter/online.png" ToolTip="Cash status is open" runat="server" />
                                   <asp:Image ID="Img_offline" ImageUrl="~/transaction/headerfooter/offline.png" ToolTip="Cash status has been closed" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-Width="6%">
                            <ItemTemplate >
                                  <asp:HyperLink runat="server" Width="10%" Target="~/transaction/rptCashClose.aspx" ID="HYp_CashClose">
                                        <asp:Image ID="Img_Print" ImageUrl="~/transaction/headerfooter/pdf.png" ToolTip="Print Report" runat="server" />
                                   </asp:HyperLink>
                                   &nbsp;&nbsp; &nbsp;

                                   <asp:HyperLink style="display:none;" Width="10%" runat="server" Target="~/transaction/wfrmCashierTracking.aspx" NavigateUrl='<%# "wfrmCashierTracking.aspx?reportno=" + Eval("reportno") + "&cashOpen=" + Eval("cashOpening_Amount") + "&cashClose=" + Eval("cashClosing_Amount") %>' ID="HyperLink1">
                                        <asp:Image ID="Image1" ImageUrl="~/img/trackin.png" Height="16px" Width="16px" ToolTip="Tracking Report" runat="server" />
                                   </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                </Columns>
                <AlternatingRowStyle HorizontalAlign="Left" BackColor="White" />
                <EditRowStyle HorizontalAlign="Left" BackColor="#2461BF" />
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
               
               
               </td>
            <td>
                &nbsp;</td>
        </tr>
                         
               
                    </table>
</div>

</asp:Content>

