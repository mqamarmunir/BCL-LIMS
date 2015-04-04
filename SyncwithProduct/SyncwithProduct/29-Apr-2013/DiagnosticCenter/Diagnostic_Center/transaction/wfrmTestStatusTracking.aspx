<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmTestStatusTracking.aspx.cs" Inherits="wfrmTestStatusTracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <asp:Panel ID="pnlDetails" runat="server" Width="100%" Style="display: block;">
                
               
                    <fieldset>
                        <legend><b style=" font-size:12px;font-family: Garamond, serif;
line-height: 1em;
color: #fff9d6;
font-weight:bold;

text-shadow:0px 0px 0 rgb(231,231,231),0px 0px 0 rgb(216,216,216),1px 1px 0 rgb(202,202,202),1px 1px 0 rgb(187,187,187),2px 2px 0 rgb(173,173,173),2px 2px 0 rgb(158,158,158), 3px 3px 0 rgb(144,144,144),3px 3px 3px rgba(0,0,0,0.6),3px 3px 1px rgba(0,0,0,0.5),0px 0px 6px rgba(0,0,0,.2);">Test Details:</b> </legend>
                        <div style="float: right">
                            <%--<asp:Button ID="btnBack" runat="server" Text="Close" CausesValidation="False" CssClass="btn"
                                OnClick="btnBack_Click" TabIndex="6" />--%>
                        </div>
                        <table width="100%">
                            <tr>
                                <td colspan="3" align="right">
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Patient Name:
                                </td>
                                <td >
                                    <asp:Label ID="lblPatientName"  ForeColor="Blue" runat="server" Font-Bold="true" ></asp:Label>
                                </td>
                                <td >
                                    DOB:
                                </td>
                                <td >
                                    <asp:Label ID="lblDOB" runat="server"  ForeColor="Blue" Font-Bold="true"></asp:Label>
                                </td>
                                <td >
                                    CellNo:
                                </td>
                                <td >
                                    <asp:Label ID="lblCellNo" runat="server"  ForeColor="Blue" Font-Bold="true" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Lab Id
                                </td>
                                <td>
                                    <asp:Label ID="lblLabid"  ForeColor="Blue"  runat="server" Font-Bold="true" ></asp:Label>
                                </td>
                                <td>
                                    PR_No:
                                </td>
                                <td>
                                    <asp:Label ID="lblprno"  ForeColor="Blue" runat="server" Font-Bold="true" ></asp:Label>
                                </td>
               
                            </tr>
                            <tr>
                                <td colspan="8" align="center" >
                                    <asp:GridView ID="gvTestDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                        GridLines="Horizontal" CellPadding="0" CssClass="listing" >
                                        <RowStyle CssClass="Row" BackColor="#F3EFE0" Font-Size="10px" />
                                        <AlternatingRowStyle HorizontalAlign="Left" CssClass="AltRow" BackColor="#F5F5F5" Font-Size="10px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Test Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" Text='<%# Eval("Test_Name")%>' runat="server" class="label"
                                                        Font-Bold="true"  Font-Names="Arial" ItemStyle-Width="35%" Font-Size="10px"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="left" />
                                                <ItemStyle HorizontalAlign="left" Width="25%" />
                                            </asp:TemplateField>
                                           <%-- <asp:TemplateField HeaderText="Process Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" Text='<%# Eval("process")%>' runat="server" class="label"
                                                        Font-Bold="False" Font-Names="Arial" Font-Size="8pt"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="left" />
                                                <ItemStyle HorizontalAlign="left" Width="25%" />
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="EnteredBy"  HeaderText="Tracking Status" SortExpression="EnteredBy" />
                                         <%--   <asp:BoundField DataField="Enteredon"  HeaderText="Process By" SortExpression="Enteredon" />--%>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                
                </asp:Panel>
</asp:Content>

