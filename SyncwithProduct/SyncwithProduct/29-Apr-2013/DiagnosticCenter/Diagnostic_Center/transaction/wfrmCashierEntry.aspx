<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmCashierEntry.aspx.cs" Inherits="transaction_wfrmCashierEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="tboxhead" style="text-align:center; width:98%; padding-top:8px;">Cashier Panel</div>
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
       <%-- <tr>
            <td align="center" class="tdheading" colspan="4">
                Cashier Panel</td>
        </tr>--%>
       
        <tr>
            <td><asp:ScriptManager ID="ScriptManager2" runat="server">
                                </asp:ScriptManager><asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="ValidationSummary"
                        ValidationGroup="save" ForeColor="Red" /> </td>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label></td>
            <td align="right">
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click"  ValidationGroup="save"/><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" Visible="False" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td></td>
        </tr>
        </table>
        <fieldset>
            <table width="100%">
        
        <tr>
            <td width="15%" align="right" colspan="2">
                <asp:Label ID="Label4" runat="server" 
                    Text="Cashier status has  started. Click on closed icon for daily cash closing report." 
                    ForeColor="#0000CC"></asp:Label>
</td>
        </tr>
        
        <tr>
            <td width="15%">
                <asp:Label ID="Label1" runat="server" Text="Opening Amount"></asp:Label>
                <asp:Label ID="Label3" Font-Size="8px" runat="server" Text="(Rs):"></asp:Label>
</td>
            <td><asp:TextBox ID="TxBx_DayCash" runat="server" CssClass="txtareaMandatory" 
                    Width="150px"></asp:TextBox>
                    
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxBx_DayCash"
                                                 Font-Bold="True" Font-Size="8pt" CssClass="error" ForeColor="Red" ErrorMessage="Error! Please,Select Name To Proceed"
                                                ValidationGroup="save">*</asp:RequiredFieldValidator>
                                                <cc1:FilteredTextBoxExtender ID="TxBx_DayCash_FilteredTextBoxExtender"
                                        runat="server" TargetControlID="TxBx_DayCash" 
                ValidChars="0,1,2,3,4,5,6,7,8,9,10,." Enabled="True"></cc1:FilteredTextBoxExtender>
                &nbsp;
                <asp:CheckBox ID="Chk_Active" runat="server" Text="Check In" Checked="True" 
                    Enabled="False" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                Description :<br /> </td>
            <td>
                <asp:TextBox ID="TxBx_Desc" runat="server" Columns="60" Rows="4" CssClass="txtareaStyle" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
</table>

            <asp:GridView ID="Gv_DayCashOn"  runat="server" AutoGenerateColumns="False"  CssClass="listing" style="font-size: 12px !important;" AllowSorting="true"
                Width="100%" GridLines="Both" CellPadding="0" ForeColor="#333333"  
        Font-Size="9px" onsorting="Gv_DayCashOn_Sorting">
                
                <AlternatingRowStyle HorizontalAlign="Left"   CssClass="AltRow" ForeColor="black"/>
                <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                        <asp:Label ID="Lb_CheckInID" runat="server" Text='<%# Eval("CashChkin_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Sr#">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField="cashierName" HeaderText="Cashier Name"  ControlStyle-Width="59%"
                            SortExpression="cashierName" ItemStyle-Width="15%" />

                        <asp:BoundField DataField="cashOpening_Amount" HeaderText="Opening Amount" ControlStyle-Width="2%" 
                            SortExpression="cashOpening_Amount" ItemStyle-HorizontalAlign="left" ItemStyle-Width="10%"  />
                        <asp:BoundField DataField="enteredon" HeaderText="Check In" 
                            SortExpression="enteredon" ControlStyle-Width="12%" ItemStyle-Width="10%"/>

                            <asp:TemplateField HeaderText="Closing Amount">
                             <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    Rs.
                                    <asp:TextBox ID="TxBx_CashClosing" Width="80px" Height="10px" MaxLength="8" CssClass="txtareaMandatory" runat="server"></asp:TextBox>
                               
                            <cc1:FilteredTextBoxExtender ID="TxBx_CashClosing_FilteredTextBoxExtender"
                                        runat="server" TargetControlID="TxBx_CashClosing" 
                ValidChars="0,1,2,3,4,5,6,7,8,9,10,." Enabled="True"></cc1:FilteredTextBoxExtender>
                               
                                </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cash Close">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk_closed" Checked="true" Enabled="false" ToolTip="Cash Status" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>

                      
                        <asp:TemplateField HeaderText="Status">
                         <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                   <asp:Image ID="Img_online" Width="15px" Height="14px" ImageUrl="~/transaction/headerfooter/online.png" ToolTip="Cash status is open" runat="server" />
                                 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                         <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                   <asp:ImageButton ID="Img_Printing" Width="15px" OnClick="Button1_Click" Height="14px" ImageUrl="~/transaction/headerfooter/cancel.png" ToolTip="Close cashed now" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        

                </Columns>
                <EditRowStyle HorizontalAlign="Left" BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" Font-Bold="True" 
                    ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Left" CssClass="Row"/>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            </fieldset>
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
            <td width="5%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="5%"></td>
        </tr>
        

        <tr>
            <td>
            </td>
            <td colspan="4" style="font-weight: bold; background-color:Silver">
            <asp:Label ID="lblpreviousrec" runat="server" Text="Session must be closed, prior to viewing cash information." Visible="false"></asp:Label>
                </td>
           
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        </table>
        <table width="99%" id="tblpreviousreports" runat="server">
        <tr>
            <td>
            </td>
            <td colspan="2">
            <asp:Panel ID="pnl_REC_ce" runat="server" Height="22px" Width="99%" ForeColor="black" style="text-align:left;">
                    <asp:Image ID="imgW" runat="server" ImageUrl="~/images/expand_REC.jpg"  />&nbsp; Cash 
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
            <td colspan="8" align="left">
            <asp:Panel ID="pnl_REC" runat="server" Width="100%">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
                <asp:GridView ID="gvWaiting" runat="server" AutoGenerateColumns="False" AllowSorting="true"
                            CssClass="listing" onsorting="gvWaiting_Sorting">
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="AltRow"  ForeColor="black"/>
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
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="paidamount" HeaderText="Amount">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="receiveon" HeaderText="Date Time">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="25%" />
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
            <asp:Panel ID="pnl_REF_ce" runat="server" Height="22px" Width="99%" ForeColor="black" style="text-align:left;">
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
            <td colspan="8" align="left">
            <asp:Panel ID="pnl_REF" runat="server" Height="50px" Width="100%">                
                <asp:UpdatePanel id="UP_REf" runat="server">
                    <contenttemplate>
                <asp:GridView ID="gvRefund" runat="server" AutoGenerateColumns="False" 
                            CssClass="listing" onsorting="gvRefund_Sorting" AllowSorting="true">
                    <RowStyle CssClass="Row" />
                       <AlternatingRowStyle HorizontalAlign="Left"   CssClass="AltRow" ForeColor="black"/>
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
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="refundon" HeaderText="Date Time">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="25%" />
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
             <asp:Panel ID="pnl_HIS_ce" runat="server" Height="22px" Width="99%"  ForeColor="black" style="text-align:left;">
                    <asp:Image ID="img_HIS_ce" runat="server" ImageUrl="~/images/expand_HIS.jpg" /> Previuos Closing Records:
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
            <td colspan="8" align="left">
             <asp:Panel ID="pnl_HIS" runat="server"  Width="100%">                
                <asp:UpdatePanel id="UP_HIS" runat="server">
                    <contenttemplate>
			<asp:GridView ID="gvCLosing" runat="server" AutoGenerateColumns="False" 
                            CssClass="listing" OnRowCommand="gvCLosing_RowCommand" AllowPaging="True" 
                            OnPageIndexChanging="gvCLosing_PageIndexChanging" PageSize="5"  AllowSorting="true"
                            DataKeyNames="netamount,netcash" onsorting="gvCLosing_Sorting" 
                            ForeColor="#333333" onrowdatabound="gvCLosing_RowDataBound">
                    <RowStyle HorizontalAlign="Left"  CssClass="Row" />
                       <AlternatingRowStyle HorizontalAlign="Left"   CssClass="AltRow" ForeColor="black"/>
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="reportno" HeaderText="Report No" SortExpression="reportno">
                            <HeaderStyle HorizontalAlign="Left" Width="8%" />
                            <ItemStyle HorizontalAlign="Left" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="printon" HeaderText="Compilation Date" SortExpression="printon">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="collectedcash" HeaderText="Collected Cash" SortExpression="collectedcash">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="refundedamount" HeaderText="Refund" SortExpression="refundedamount">
                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                            <ItemStyle HorizontalAlign="left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="netamount" HeaderText="Total" SortExpression="netamount">
                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                            <ItemStyle HorizontalAlign="left" Width="15%" />
                        </asp:BoundField>
                         <asp:BoundField DataField="netcash" HeaderText="Cashier Entry">
                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                        </asp:BoundField>
                     
                                     <asp:TemplateField HeaderText="Net Cash" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcash" runat="server" class="label" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="8pt"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" class="label" Font-Bold="False" Font-Names="Arial"
                                                Font-Size="8pt"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                      
                      <asp:TemplateField>
                            <ItemTemplate>
                                  <asp:HyperLink runat="server" Target="~/transaction/rptCashClose.aspx" ID="HYp_CashClose">
                                        <asp:Image ID="Img_Print" ImageUrl="~/transaction/headerfooter/pdf.png" ToolTip="Print Report" runat="server" />
                                   </asp:HyperLink>
                         </ItemTemplate>
                     </asp:TemplateField>
                        
                        <asp:CommandField Visible="false" SelectText="Print" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:CommandField>



                    </Columns>
                     <EditRowStyle HorizontalAlign="Left" BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" Font-Bold="True" 
                    ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Left" CssClass="Row"/>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
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
</asp:Content>

