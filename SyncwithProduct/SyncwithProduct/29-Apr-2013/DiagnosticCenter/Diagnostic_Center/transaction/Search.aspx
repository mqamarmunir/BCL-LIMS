<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="transaction_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 219px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Search</div>

    <table width="100%">
 <tr> <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <td colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="ValidationSummary"
                        ValidationGroup="save" ForeColor="Red" />
                </td>
              
            </tr>
            <tr> <td colspan="7" align="right">
                
                <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" Visible="true" TabIndex="5" />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Search.gif" OnClick="btnSearch_Click" Visible="true" TabIndex="5" />
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" TabIndex="6" /></td></tr>
 </table>
 <fieldset>
 <table>
 <tr>
            <td>
                From Date:
            </td>
            <td >
                <asp:TextBox ID="tbfromdate" CssClass="txtareaMandatory"  TabIndex="1" runat="server"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbfromdate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbfromdate"
                                                 Font-Bold="True" Font-Size="8pt" CssClass="error" ForeColor="Red" ErrorMessage="Error! Please,Select From Date To Proceed"
                                                ValidationGroup="save">*</asp:RequiredFieldValidator>
                                                 <cc1:MaskedEditExtender TargetControlID="tbfromdate" ID="MaskedEditExtender2" 
                runat="server" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
             
            </td>
            <td >
                To Date:
            </td>
            <td >
                <asp:TextBox ID="tbtodate" runat="server" CssClass="txtareaMandatory" TabIndex="2"></asp:TextBox>
                <cc1:CalendarExtender ID="CE2" runat="server" TargetControlID="tbtodate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbtodate"
                                                Font-Bold="True" Font-Size="8pt"    CssClass="error" ForeColor="Red"  ErrorMessage="Error! Please,Select TO Date To Proceed"
                                                ValidationGroup="save" >*</asp:RequiredFieldValidator>
                                                 <cc1:MaskedEditExtender TargetControlID="tbtodate" ID="MaskedEditExtender1" 
                runat="server" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
            </td>
            <td>Cashier Name</td>
            <td><asp:TextBox ID="txtCashierName" runat="server" CssClass="txtareaStyle" TabIndex="3"></asp:TextBox>
              </td>
          
            <td >
<%--                <asp:Button ID="btnSearch" runat="server" Text="Search"  ValidationGroup="save" Width="20%" TabIndex="3" CssClass="button" OnClick="btnSearch_Click" />--%>
       <%-- <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/img/search.png" ToolTip="Search "
                    OnClick="btnSearch_Click" CausesValidation="true"   ValidationGroup="save" TabIndex="4" Height="17px" Width="17px"/>
           --%> </td>
            
            </tr>
            
          
            </table>
           
              <table width="100%"><tr>
              <td>
              <asp:GridView ID="Gv_DayCashList"  runat="server" AutoGenerateColumns="False" 
                Width="100%" GridLines="Horizontal" CellPadding="0" ForeColor="#333333"  
                      OnSorting="Gv_DayCashList_Sorting" AllowSorting="true"  CssClass="listing"
                      onrowdatabound="Gv_DayCashList_RowDataBound" DataKeyNames="reportno">
                       <RowStyle CssClass="Row" />
                         <AlternatingRowStyle HorizontalAlign="Left"   CssClass="AltRow"/>
                <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                
                            </ItemTemplate>
                            </asp:TemplateField>
                       <asp:BoundField DataField="cashierName" HeaderText="Cashier Name" 

                            SortExpression="cashierName" />
                        <asp:BoundField DataField="cashOpening_Amount" HeaderText="Opening Amount" 
                            SortExpression="cashOpening_Amount" />
                        
                        <asp:BoundField DataField="cashClosing_Amount" HeaderText="Closing Amount" 
                            SortExpression="cashClosing_Amount" />
                        <asp:BoundField DataField="enteredoff" HeaderText="Check Out" 
                            SortExpression="enteredoff" />
                        <asp:TemplateField HeaderText="Net Sale">
                            <ItemTemplate>
                                <asp:Label ID="Lb_NetSales" Text='<%# Eval("netcash") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                       </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Branch" 
                            SortExpression="branchid" />
                       
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
            </asp:GridView></td></tr>
            </table>
             </fieldset>
</asp:Content>

