<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/transaction/wfrmWorkList.aspx.cs" Inherits="worklist" Title="Work List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Work List Generation<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager></td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td colspan="2">
                </td>
            <td></td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="4">
                &nbsp;</td>
            <td colspan="2">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="6">
           <asp:UpdatePanel id="up_t" runat="server"><ContentTemplate>
<asp:Panel id="pnl_new" runat="server" Width="99%"><TABLE id="tb_new" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD colSpan=3><asp:Label id="lblError" runat="server"></asp:Label></TD><TD align=right><asp:ImageButton id="imgRefresh" onclick="imgRefresh_Click" runat="server" ImageUrl="~/images/Refresh.gif"></asp:ImageButton><asp:ImageButton id="imgClose" onclick="imgClose_Click" runat="server" ImageUrl="~/images/ClosePack.gif"></asp:ImageButton></TD></TR><TR><TD align=right></TD><TD colSpan=2></TD><TD></TD></TR><TR><TD><IMG src="../images/bullet.gif" /><STRONG>&nbsp;Pending:</STRONG></TD><TD colSpan=2></TD><TD></TD></TR><TR><TD colSpan=4>
<asp:GridView id="gvQueueList" runat="server" Width="80%" AutoGenerateColumns="False" CssClass="datagrid" OnRowCommand="gvQueueList_RowCommand" DataKeyNames="subdeptid">
                    <RowStyle  CssClass="gridItem"  />
                    <Columns >
                        <asp:TemplateField HeaderText="S#">
                            <HeaderStyle  HorizontalAlign="Center"  />
                            <ItemStyle  HorizontalAlign="Center" Width="5%"  />
                            <ItemTemplate >
                                <%#Container.DataItemIndex+1 %>:
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField  DataField="subdept" HeaderText="Sub-Department">
                            <HeaderStyle  HorizontalAlign="Left"  />
                            <ItemStyle  HorizontalAlign="Left" Width="50%"  />
                        </asp:BoundField>
                        <asp:BoundField  DataField="records" HeaderText="Inv.Qty">
                            <HeaderStyle  HorizontalAlign="Right"  />
                            <ItemStyle  HorizontalAlign="Right" Width="10%"  />
                        </asp:BoundField>
                        <asp:CommandField  ShowSelectButton="True" SelectText="Save &amp; Print">
                            <HeaderStyle  HorizontalAlign="Center"  />
                            <ItemStyle  HorizontalAlign="Center" Width="15%"  />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle  CssClass="gridheader"  />
                    <AlternatingRowStyle  CssClass="gridAlternate"  />
                </asp:GridView></TD></TR><TR><TD colSpan=4><asp:GridView id="gvNewList" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="testid,bookingid,bookingdid">
                                    <RowStyle CssClass="gridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>:
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="labid" HeaderText="Lab ID">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="patientname" HeaderText="Patient Name">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="age" HeaderText="Age">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="testname" HeaderText="Test">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="gridheader" />
                                    <AlternatingRowStyle CssClass="gridAlternate" />
                                </asp:GridView> </TD></TR><TR><TD colSpan=4><IMG src="../images/bullet.gif" /> <STRONG>Previous:</STRONG></TD></TR><TR><TD colSpan=4>&nbsp; &nbsp; Department: <asp:DropDownList id="ddlSubDept" runat="server" Width="25%" CssClass="dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlSubDept_SelectedIndexChanged">
            </asp:DropDownList></TD></TR><TR><TD colSpan=4>
            <asp:GridView id="gvPreviousList" runat="server" Width="90%" AutoGenerateColumns="False" CssClass="datagrid" OnRowCommand="gvPreviousList_RowCommand" OnPageIndexChanging="gvPreviousList_PageIndexChanging" AllowPaging="True" PageSize="5">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="S#"><ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>:
                                            
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="worklistno" HeaderText="List No">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="enteredon" HeaderText="Generated">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:BoundField>
    <asp:BoundField DataField="subdept" HeaderText="Department">
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Left" Width="25%" />
    </asp:BoundField>
<asp:BoundField DataField="totaltest" HeaderText="Inv.Qty">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectText="Preview" ShowSelectButton="True">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
</asp:CommandField>
</Columns>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD width="25%"></TD><TD width="25%"></TD><TD width="15%"></TD><TD width="35%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel>
                </td>
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
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="6"></td>
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
            <td></td>
        </tr>
        <tr>
            <td width="5%"></td>
            <td width="13%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="17%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="5%"></td>
        </tr>
    </table>
</asp:Content>

