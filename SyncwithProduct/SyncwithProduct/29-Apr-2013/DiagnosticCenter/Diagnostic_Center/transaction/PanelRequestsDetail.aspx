<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="PanelRequestsDetail.aspx.cs" Inherits="transaction_PanelRequestsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Image runat="server" Width="" style="z-index:999999; position:absolute; margin:auto; margin-left:-60px; margin-top:-300px;" Height="" ImageUrl="../images/mywait.gif" ID="Img_Load" />
                                            <div style="position: fixed; top: 0px; bottom: 0px; left: 0px; right: 0px; overflow: hidden; padding: 0; margin: 0; background-color: #F0F0F0; filter: alpha(opacity=60); opacity: 0.6; z-index: 100000;"></div>
                                        </td>
                                    </tr>
                                </table>
                            </ProgressTemplate>
                 </asp:UpdateProgress>
    <table width="99%">
<tr>
<td style="text-align:center" colspan="7">
<h2>
Panel Requests
</h2>
</td>
</tr>
<tr>
<td colspan="3">
<asp:UpdatePanel ID="UPDTEeRROR" runat="server">
<ContentTemplate>
<asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
</ContentTemplate>
</asp:UpdatePanel>
</td>

<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr >
<td align="right" valign="bottom"></td>
<td colspan="2">
<div style="width:100%">
<cc1:ComboBox ID="cmbPanel" runat="server" DropDownStyle="DropDownList" 
        AutoPostBack="true" Visible="false"  AutoCompleteMode="SuggestAppend"  
        ItemInsertLocation="Append" onselectedindexchanged="cmbPanel_SelectedIndexChanged"
></cc1:ComboBox>
</div>
</td>

<td></td>
<td></td>
<td></td>
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
</tr>
<tr>
<td colspan="7">
 <asp:UpdatePanel ID="updtepnl1" runat="server">
<ContentTemplate>
<asp:GridView ID="gvRequestsmaster" Width="99%"
 CssClass="listing" 
 OnPageIndexChanging="gvRequestsmaster_pageindexchanged" OnRowCreated="gvRequestsmaster_RowCreated" 
 AutoGenerateColumns="False"  AllowPaging="true" PageSize="20"  DataKeyNames="masterid,cliq_dependent_id,gender,marital_status,dob,totalamount,referredby" GridLines="None" runat="server">
<Columns>
<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="5%">
                            <ItemTemplate>
                            <asp:Panel ID="pnlmaster" runat="server">
                             <asp:Image ID="imgCollapsible"
                                Style="margin-right: 5px;" runat="server" />
                                </asp:Panel>
                               <%-- <asp:ImageButton ID="gvimgexpand" runat="server" ImageUrl="~/images/button_plus_red.png"
                                    CommandArgument="<%#Container.DataItemIndex%>" OnCommand="gvimgexpand_Click" />
                                <asp:ImageButton ID="gvimgcollapse" runat="server" ImageUrl="~/images/button_minus_red.png"
                                    Visible="false" CommandArgument="<%#Container.DataItemIndex%>" OnCommand="gvimgcollapse_Click" />--%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
<asp:TemplateField ItemStyle-Width="45%" HeaderText="Visit Info">
                        <ItemTemplate>
                        <asp:Label ID="lblAuthorizationNo" ToolTip="Authorization No" runat="server"  Font-Bold="true" Font-Size="Small" Text='<%#DataBinder.Eval(Container.DataItem, "AuthorizationNo")%>'></asp:Label>
                        <br />

                        <asp:Label ID="lblBookedon" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "EnteredOn")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
<asp:TemplateField ItemStyle-Width="35%" HeaderText="Patient Info">
                        <ItemTemplate>
                        <asp:Label ID="lblPatientName" runat="server" ToolTip="Patient/Dependent Name" Font-Bold="true" Font-Size="Small" Text='<%#DataBinder.Eval(Container.DataItem, "PatientName") %>'></asp:Label>
                                <br />
                                <asp:Label ID="EmployeeName" ToolTip="Employee" runat="server" Font-Size="x-Small" Text='<%#DataBinder.Eval(Container.DataItem, "EmployeeName") %>'></asp:Label>
                                <br />
                                <b>Relation:</b>&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="x-Small" Text='<%#DataBinder.Eval(Container.DataItem, "Relation") %>'></asp:Label>
                               
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="15%">
                        <ItemTemplate>
                        <asp:ImageButton ID="ibtnApprove" runat="server" ImageUrl="~/img/Images1.jpg" 
                                Height="20px" Width="20px" ToolTip="Approve" onclick="ibtnApprove_Click" />
                                <asp:ImageButton ID="ibtnReject" runat="server" ImageUrl="~/images2/Cancel.png" 
                                Height="12px" Width="12px" Visible="false" OnClientClick="return confirm('Are you sure?');" OnClick="ibtnReject_Click" />
                        </ItemTemplate>
</asp:TemplateField>
<asp:TemplateField>
<itemTemplate>
    <%-- <asp:ImageButton ID="gvimgexpand" runat="server" ImageUrl="~/images/button_plus_red.png"
                                    CommandArgument="<%#Container.DataItemIndex%>" OnCommand="gvimgexpand_Click" />
                                <asp:ImageButton ID="gvimgcollapse" runat="server" ImageUrl="~/images/button_minus_red.png"
                                    Visible="false" CommandArgument="<%#Container.DataItemIndex%>" OnCommand="gvimgcollapse_Click" />--%>
                                    </tr>
                                    <tr>
    <td>
    </td>
    <td colspan="4" style="height: auto">
        <asp:Panel ID="pnldetails" runat="server" Width="100%">
            <asp:GridView ID="gvtestdetail" runat="server" AutoGenerateColumns="false" 
                DataKeyNames="testid,charges" GridLines="None" ShowHeader="false" Width="70%">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                          <p><%# Container.DataItemIndex+1 %></p>  
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TestName" HeaderText="Name" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <cc1:CollapsiblePanelExtender ID="ctlCollapsiblePanel" runat="Server" 
            AutoCollapse="false" AutoExpand="False" CollapseControlID="pnlmaster" 
            Collapsed="True" CollapsedImage="~/images/expandw.jpg" CollapsedSize="0" 
            ExpandControlID="pnlmaster" ExpandDirection="Vertical" 
            ExpandedImage="~/images/collapsew.jpg" ImageControlID="imgCollapsible" 
            ScrollContents="false" TargetControlID="pnldetails" />
    </td>
    </tr>
</itemTemplate>
</asp:TemplateField>
</Columns>
<RowStyle CssClass="Row"/>
<HeaderStyle CssClass="gridheader" />
<AlternatingRowStyle CssClass="gridAlternate" />
<SelectedRowStyle CssClass="gridSelectedItem" />

</asp:GridView>
</ContentTemplate>
</asp:UpdatePanel>
 </td>
</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td width="10%"></td>
<td width="15%"></td>
<td width="10%"></td>
<td width="15%"></td>
<td width="10%"></td>
<td width="15%"></td>
<td width="10%"></td>
</tr>
</table>
</asp:Content>

