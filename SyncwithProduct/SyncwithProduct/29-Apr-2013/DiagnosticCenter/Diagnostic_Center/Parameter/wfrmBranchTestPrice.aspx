<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBranchTestPrice.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager> 

<table id="tblbody" class="label" cellpadding="1" cellspacing="1" width="100%">
<tr>
<td colspan="7" align="center"> <font size="4"><strong>Branch Test Prices Configuraiton</strong></font>
<asp:HiddenField ID="hdBranchTestID" runat="server" />
</td>

</tr>

<tr>
<td colspan="7" align="right">
 <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="12" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" />
 <asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="13" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" />
<asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                                        TabIndex="14" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" />

</td>

</tr>
<tr>
<td colspan="7"><asp:UpdatePanel ID="updteerror" runat="server">
<ContentTemplate><asp:Label ID="lblErrMsg" ForeColor="Red" runat="server" Font-Size="X-Small"></asp:Label>

</ContentTemplate>
</asp:UpdatePanel></td>

</tr>
<tr>
<td>Sub-Department</td>
<td><asp:DropDownList ID="ddlSubDepartment" runat="server" CssClass="dropdown" 
        Width="99%" AutoPostBack="true" 
        onselectedindexchanged="ddlSubDepartment_SelectedIndexChanged"></asp:DropDownList></td>
<td>Test Name</td>
<td><asp:DropDownList ID="ddlTest" runat="server" CssClass="dropdown" 
        Width="99%" AutoPostBack="true" 
        onselectedindexchanged="ddlTest_SelectedIndexChanged"></asp:DropDownList></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td>Vendor Price</td>
<td>
            <asp:TextBox ID="txtvendpr" CssClass="mandatoryField" runat="server" 
        Width="98%"></asp:TextBox>
            </td>
<td>Offered price</td>
<td>
            <asp:TextBox ID="txtoffpr" CssClass="mandatoryField" runat="server" 
        Width="98%"></asp:TextBox>
            </td>
<td></td>
<td></td>
<td></td>
</tr>


<tr>
<td colspan="7"><asp:Label Id="lblCount" runat="server" Font-Size="X-Small"></asp:Label></td>

</tr>
<tr>
<td colspan="7">
<asp:GridView ID="gvPrices" runat="server" CssClass="datagrid"
 OnRowEditing="gvPrices_RowEditing" DataKeyNames="TestID,BranchId,SubDepartmentId" AutoGenerateColumns="false">
<HeaderStyle CssClass="gridheader" HorizontalAlign="left" />
<AlternatingRowStyle CssClass="gridAlternate" />
<RowStyle CssClass="gridItem" />
<Columns>
<asp:TemplateField HeaderText="S#">
<HeaderStyle HorizontalAlign="Center" Width="5%" />
<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="TestName" HeaderText="Test Name" />
<asp:BoundField DataField="Price" HeaderText="Vendor Price" />
<asp:BoundField DataField="Offeredprice" HeaderText="Offered Price" />
<asp:CommandField EditText="Edit" ShowEditButton="true" />

</Columns>

</asp:GridView>
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
<td width="15%"></td>
<td width="20%"></td>
<td width="15%"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>
</asp:Content>

