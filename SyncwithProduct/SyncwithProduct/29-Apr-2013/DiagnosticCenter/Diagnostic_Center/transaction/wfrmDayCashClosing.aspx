<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmDayCashClosing.aspx.cs" Inherits="Report_wfrmDayCashClosing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<asp:ScriptManager ID="ScriptManager2" runat="server">
                                </asp:ScriptManager> 
    <cc1:TabContainer ID="TabContainer1" Width="100%"   runat="server" 
        ActiveTabIndex="0" >
    <cc1:TabPanel ID="tab1" Width="100%"  runat="server" HeaderText="Day Cash Close" style="font-size:10px; font-family:Tahoma;">
       <ContentTemplate>
            <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="4">
                Cash Closing</td>
        </tr>
       
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label></td>
            <td align="right">
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" Visible="False" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td></td>
        </tr>
        </table>
            <table width="80%">
        
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Total Cash :"></asp:Label>
&nbsp;</td>
            <td><asp:TextBox ID="TxBx_DayCash" runat="server" 
                    Width="150px"></asp:TextBox>
                &nbsp;
                <asp:CheckBox ID="Chk_Active" runat="server" Text="Check In" Checked="True" 
                    Enabled="False" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                Description :<br /> </td>
            <td>
                <asp:TextBox ID="TxBx_Desc" runat="server" Columns="60" Rows="4" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
</table>
            <asp:GridView ID="Gv_DayCashOn"  runat="server" AutoGenerateColumns="False" 
                Width="100%" GridLines="Horizontal" CellPadding="0" ForeColor="#333333" 
                >
                <AlternatingRowStyle HorizontalAlign="Left" BackColor="White" />
                <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                        <asp:Label ID="Lb_CheckInID" runat="server" Text='<%# Eval("CashChkin_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial">
                            <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="cashierName" HeaderText="Cashier Name" 
                            SortExpression="cashierName" />
                        <asp:BoundField DataField="cashOpening_Amount" HeaderText="Opening Amount" 
                            SortExpression="cashOpening_Amount" />
                        <asp:BoundField DataField="enteredon" HeaderText="Check In" 
                            SortExpression="enteredon" />

                            <asp:TemplateField HeaderText="Closing Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxBx_CashClosing" CssClass="mandatoryField" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cash Close">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk_closed" Checked="true" Enabled="false" ToolTip="Cash Status" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        <asp:BoundField DataField="Name" HeaderText="Branch" 
                            SortExpression="branchid" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                   <asp:Image ID="Img_online" Width="14px" Height="14px" ImageUrl="~/transaction/headerfooter/online.png" ToolTip="Cash status is open" runat="server" />
                                  <%--<asp:Image ID="Img_offline" Width="13px" Height="11px" ImageUrl="~/transaction/headerfooter/offline.png" ToolTip="Cash status has been closed" runat="server" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                   <asp:ImageButton ID="Img_Printing" Width="14px" OnClick="Button1_Click" Height="14px" ImageUrl="~/transaction/headerfooter/cancel.png" ToolTip="Close cashed now" runat="server" />
                                  <%-- <asp:Image ID="Img_offline" Width="13px" Height="11px" ImageUrl="~/transaction/headerfooter/offline.png" ToolTip="Cash status has been closed" runat="server" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        

                </Columns>
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
            <br />
        <table id="Table1" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td></td>
            <td></td>
            <td>
                 <cc1:CollapsiblePanelExtender ID="cpe_REC" runat="server"
             TargetControlID = "pnl_REC" ExpandControlID = "pnl_REC_ce" CollapseControlID = "pnl_REC_ce"
              Collapsed="True"  ExpandedImage ="../images/collapse_REC.jpg" CollapsedImage="../images/expand_REC.jpg"
             ImageControlID = "imgW" ExpandedText = "Hide cash receipt Details..." CollapsedText = "Show cash receipt details..."
             SuppressPostBack="True" Enabled="True"  >           
             </cc1:CollapsiblePanelExtender>    
             <cc1:CollapsiblePanelExtender ID="cpe_REF" runat="server"
             TargetControlID = "pnl_REF" ExpandControlID = "pnl_REF_ce" CollapseControlID = "pnl_REF_ce"
              Collapsed="True"  ExpandedImage ="../images/collapse_REF.jpg" CollapsedImage="../images/expand_REF.jpg"
             ImageControlID = "img_REF_CE" ExpandedText = "Hide cash refund Details..." CollapsedText = "Show cash refund details..."
             SuppressPostBack="True" Enabled="True"  >           
             </cc1:CollapsiblePanelExtender>  
              <cc1:CollapsiblePanelExtender ID="cpe_HIS" runat="server"
             TargetControlID = "pnl_HIS" ExpandControlID = "pnl_HIS_ce" CollapseControlID = "pnl_HIS_ce"
              Collapsed="True"  ExpandedImage ="../images/collapse_HIS.jpg" CollapsedImage="../images/expand_HIS.jpg"
             ImageControlID = "img_HIS_CE" ExpandedText = "Hide cash report Details..." CollapsedText = "Show cash report details..."
             SuppressPostBack="True" Enabled="True"  >           
             </cc1:CollapsiblePanelExtender>                                                                                                    
                
                </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr style="display: block;">
            <td></td>
            <td colspan="4">
                <asp:Label ID="Label2" runat="server"></asp:Label></td>
            <td colspan="2">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" Visible="False" /><asp:ImageButton
                    ID="ImageButton2" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" Visible="False" /><asp:ImageButton
                        ID="ImageButton3" runat="server" ImageUrl="~/images/ClosePack.gif" 
                    OnClick="imgClose_Click" Visible="False" /></td>
            <td></td>
        </tr>
        
        <tr>
            <td></td>
            <td></td>
            <td colspan="3" align="left">
                <asp:Panel ID="pnlSumary" runat="server" GroupingText="Cash Summary" Height="50px"
                    Width="99%" Visible ="False">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblBalance" runat="server" ForeColor="DarkBlue"></asp:Label></asp:Panel>
            </td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" style="font-weight: bold">
                &nbsp;</td>
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
            <td>
            </td>
            <td colspan="2">
            <asp:Panel ID="pnl_REC_ce" runat="server" Height="22px" Width="99%">
                    <asp:Image ID="imgW" runat="server" ImageUrl="~/images/expand_REC.jpg" />&nbsp; Cash 
                    Receipts <asp:Label ID="lblCash" runat="server" ForeColor="DarkBlue" 
                        Visible="False"></asp:Label>
            </asp:Panel>
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
            <td>
            </td>
            <td colspan="6">
            <asp:Panel ID="pnl_REC" runat="server" Width="100%">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
                <asp:GridView ID="gvWaiting" runat="server" AutoGenerateColumns="False" CssClass="datagrid">
                    <RowStyle CssClass="gridItem" />
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                :
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
               </contenttemplate>
              </asp:UpdatePanel>
             </asp:Panel>   
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2">
            <asp:Panel ID="pnl_REF_ce" runat="server" Height="22px" Width="99%">
                    <asp:Image ID="img_REF_ce" runat="server" ImageUrl="~/images/expand_REF.jpg" />&nbsp; 
                    Refunds <asp:Label ID="lblrefAmt" runat="server" ForeColor="DarkBlue" 
                        Visible="False"></asp:Label></asp:Panel>
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
            <td>
            </td>
            <td colspan="6">
            <asp:Panel ID="pnl_REF" runat="server" Height="50px" Width="100%">                
                <asp:UpdatePanel id="UP_REf" runat="server">
                    <contenttemplate>
                <asp:GridView ID="gvRefund" runat="server" AutoGenerateColumns="False" CssClass="datagrid">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                :
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
               </contenttemplate>
              </asp:UpdatePanel>
             </asp:Panel>   
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
            <td></td>
            <td style="font-weight: bold" colspan="2">
                </td>
            <td></td>
            <td></td>
            <td colspan="2">
                </td>
            <td></td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2">
             <asp:Panel ID="pnl_HIS_ce" runat="server" Height="22px" Width="99%">
                    <asp:Image ID="img_HIS_ce" runat="server" ImageUrl="~/images/expand_HIS.jpg" />&nbsp; Closed Cash Reports
            </asp:Panel>
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
            <td></td>
            <td colspan="6">
             <asp:Panel ID="pnl_HIS" runat="server"  Width="100%">                
                <asp:UpdatePanel id="UP_HIS" runat="server">
                    <contenttemplate>
               <asp:GridView ID="gvCLosing" runat="server" AutoGenerateColumns="False" CssClass="datagrid" OnRowCommand="gvCLosing_RowCommand" AllowPaging="True" OnPageIndexChanging="gvCLosing_PageIndexChanging" PageSize="5">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="reportno" HeaderText="Report No">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="printon" HeaderText="Compilation Date">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="collectedcash" HeaderText="Collected Cash">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="refundedamount" HeaderText="Refund">
                            <HeaderStyle HorizontalAlign="Right" Width="15%" />
                            <ItemStyle HorizontalAlign="Right" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="netamount" HeaderText="Net Amount">
                            <HeaderStyle HorizontalAlign="Right" Width="15%" />
                            <ItemStyle HorizontalAlign="Right" Width="15%" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Preview" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
               </contenttemplate>
              </asp:UpdatePanel>
             </asp:Panel>   
            </td>
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
       </ContentTemplate>
    </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" style="font-size:10px; font-family:Tahoma;">
            <HeaderTemplate>
                Cash List
            </HeaderTemplate>
            <ContentTemplate>
                    <table width="100%">
                             <tr>
            <td>
                &nbsp;</td>
            <td>
               <asp:GridView ID="Gv_DayCashList"  runat="server" AutoGenerateColumns="False" 
                Width="100%" GridLines="Horizontal" CellPadding="0" ForeColor="#333333" 
                    onrowdatabound="Gv_DayCashList_RowDataBound" DataKeyNames="reportno">
                <Columns>
                        <asp:TemplateField HeaderText="Serial">
                            <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="cashierName" HeaderText="Cashier Name" 
                            SortExpression="cashierName" />
                        <asp:BoundField DataField="cashOpening_Amount" HeaderText="Opening Amount" 
                            SortExpression="cashOpening_Amount" />
                        <asp:BoundField DataField="enteredon" HeaderText="Check In" 
                            SortExpression="enteredon" />
                        <asp:BoundField DataField="cashClosing_Amount" HeaderText="Closing Amount" 
                            SortExpression="cashClosing_Amount" />
                        <asp:BoundField DataField="enteredoff" HeaderText="Check Out" 
                            SortExpression="enteredoff" />
                        <asp:TemplateField HeaderText="Net Sale">
                            <ItemTemplate>
                                <asp:Label ID="Lb_NetSales" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Branch" 
                            SortExpression="branchid" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                   <asp:Image ID="Img_online" ImageUrl="~/transaction/headerfooter/online.png" ToolTip="Cash status is open" runat="server" />
                                   <asp:Image ID="Img_offline" ImageUrl="~/transaction/headerfooter/offline.png" ToolTip="Cash status has been closed" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField>
                            <ItemTemplate>
                                  <asp:HyperLink runat="server" Target="~/transaction/rptCashClose.aspx" ID="HYp_CashClose">
                                   <asp:Image ID="Img_Print" ImageUrl="~/transaction/headerfooter/pdf.png" ToolTip="Print Report" runat="server" />
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
            
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>

</asp:Content>

