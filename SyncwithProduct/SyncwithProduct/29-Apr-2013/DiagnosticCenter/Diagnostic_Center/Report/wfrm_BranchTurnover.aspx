<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="wfrm_BranchTurnover.aspx.cs" Inherits="Report_wfrm_BranchTurnover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>

<table id="tblheader" class="label" width="99%" runat="server">
<tr>
<td colspan="7" align="center" class="tdheading">

            Branch Turn Over</td>
</tr>
<tr>
<td colspan="7"><asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager></td>

</tr>
<tr>
<td colspan="7" align="right">
<asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                OnClick="imgReport_Click" />
                <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif"
                    OnClick="imgClear_Click" />
                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                        OnClick="imgClose_Click" />
                
                 </td>

</tr>

<tr>
<td width="20%"></td>
<td width="20%"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>

</table>

<table id="tblbody" runat="server" class="label" width="99%">
<tr>

<td colspan="7">

<asp:RadioButton ID="rdbFranc" Text="Franchise" Value="F" GroupName="brtype" AutoPostBack="true" 
        runat="server" oncheckedchanged="rdbFranc_CheckedChanged" />
<asp:RadioButton ID="rdbGross" Text="Gross" Value="G" GroupName="brtype"  AutoPostBack="true" 
        runat="server" oncheckedchanged="rdbGross_CheckedChanged" />
<asp:RadioButton ID="rdbNet" Text="Net" Value="N" GroupName="brtype" runat="server"  AutoPostBack="true" 
        oncheckedchanged="rdbNet_CheckedChanged" /> 

</td>


</tr>
<tr>

<td colspan="2" rowspan="8">
<asp:Panel ID="pnlgrid" runat="server" ScrollBars="Auto" Height="150px">

<asp:GridView ID="gvBranches" runat="server" ShowHeader="false" CssClass="datagrid" Width="99%" 
 DataKeyNames="BranchID" AutoGenerateColumns="false">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="gridItem" />
<AlternatingRowStyle CssClass="gridAlternate" />
<Columns>
<asp:TemplateField HeaderText="S#">
<HeaderStyle HorizontalAlign="Center" Width="5%" />
<ItemStyle HorizontalAlign="Center" Width="5%" />
<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Name" HeaderText="Branch Name"/>
<asp:TemplateField>
<HeaderStyle Width="5%" />
<ItemStyle Width="5%" />
<ItemTemplate>
<asp:CheckBox ID="gvchkbranch" runat="server" />
</ItemTemplate>
</asp:TemplateField>
</Columns>

</asp:GridView>
</asp:Panel>
</td>

<td colspan="2">From:
<asp:TextBox ID="txtFrom" CssClass="mandatoryField" runat="server"></asp:TextBox>
To:
<asp:TextBox ID="txtTo" CssClass="mandatoryField" runat="server"></asp:TextBox>
<cc1:CalendarExtender ID="cal_from" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFrom" TargetControlID="txtFrom"></cc1:CalendarExtender> 
            <cc1:CalendarExtender ID="cal_to" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtTo" TargetControlID="txtTo"></cc1:CalendarExtender>
</td>

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

</tr>
<tr>
<td></td>
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

</tr>
<tr>
<td></td>
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

</tr>
<tr>
<td></td>
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

</tr>
<tr>
<td width="15%"></td>
<td width="20%"></td>
<td width="20%"></td>
<td width="15%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>
</table>

</div>
</asp:Content>