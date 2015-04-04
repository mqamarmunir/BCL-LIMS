<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/transaction/wfrmCashCLose.aspx.cs" Inherits="cashclose" Title="Cash Closing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Cash Closing</td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
                 <cc1:CollapsiblePanelExtender ID="cpe_REC" runat="server"
             TargetControlID = "pnl_REC" ExpandControlID = "pnl_REC_ce" CollapseControlID = "pnl_REC_ce"
              Collapsed="True"  ExpandedImage ="../images/collapse_REC.jpg" CollapsedImage="../images/expand_REC.jpg"
             ImageControlID = "imgW" ExpandedText = "Hide cash receipt Details..." CollapsedText = "Show cash receipt details..."
             SuppressPostBack="true"  >           
             </cc1:CollapsiblePanelExtender>    
             <cc1:CollapsiblePanelExtender ID="cpe_REF" runat="server"
             TargetControlID = "pnl_REF" ExpandControlID = "pnl_REF_ce" CollapseControlID = "pnl_REF_ce"
              Collapsed="True"  ExpandedImage ="../images/collapse_REF.jpg" CollapsedImage="../images/expand_REF.jpg"
             ImageControlID = "img_REF_CE" ExpandedText = "Hide cash refund Details..." CollapsedText = "Show cash refund details..."
             SuppressPostBack="true"  >           
             </cc1:CollapsiblePanelExtender>  
              <cc1:CollapsiblePanelExtender ID="cpe_HIS" runat="server"
             TargetControlID = "pnl_HIS" ExpandControlID = "pnl_HIS_ce" CollapseControlID = "pnl_HIS_ce"
              Collapsed="True"  ExpandedImage ="../images/collapse_HIS.jpg" CollapsedImage="../images/expand_HIS.jpg"
             ImageControlID = "img_HIS_CE" ExpandedText = "Hide cash report Details..." CollapsedText = "Show cash report details..."
             SuppressPostBack="true"  >           
             </cc1:CollapsiblePanelExtender>                                                                                                    
                
                </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                <asp:Label ID="lblError" runat="server"></asp:Label></td>
            <td colspan="2">
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" Visible="False" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td></td>
        </tr>
        
        <tr>
            <td></td>
            <td></td>
            <td colspan="3" align="left">
                <asp:Panel ID="pnlSumary" runat="server" GroupingText="Cash Summary" Height="50px"
                    Width="99%" Visible ="false">
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
                    <asp:Image ID="imgW" runat="server" ImageUrl="~/images/expand_REC.jpg" />&nbsp; Cash Receipts (<asp:Label ID="lblCash" runat="server" ForeColor="DarkBlue"></asp:Label>)
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
                    <asp:Image ID="img_REF_ce" runat="server" ImageUrl="~/images/expand_REF.jpg" />&nbsp; Refunds (<asp:Label ID="lblrefAmt" runat="server" ForeColor="DarkBlue"></asp:Label>)&nbsp;</asp:Panel>
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
            <td>
            </td>
            <td>
            </td>
            <td align="center" colspan="4">
                &nbsp;</td>
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

