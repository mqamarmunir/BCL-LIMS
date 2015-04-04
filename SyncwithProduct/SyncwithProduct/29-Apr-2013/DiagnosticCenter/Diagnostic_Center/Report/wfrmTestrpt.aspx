<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Report/wfrmTestrpt.aspx.cs" Inherits="testrpt" Title="Test Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Test Master Report</td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
         <tr>
            <td></td>
            <td></td>
             <td colspan="2">
                 <asp:RadioButtonList ID="rdbReport" runat="server" AutoPostBack="True" CssClass="radioField"
                     OnSelectedIndexChanged="rdbReport_SelectedIndexChanged" RepeatDirection="Horizontal">
                     <asp:ListItem>Complete Report</asp:ListItem>
                     <asp:ListItem>Selective Report</asp:ListItem>
                 </asp:RadioButtonList></td>
            <td></td>
            <td colspan="2">
                <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                    OnClick="imgReport_Click" /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif"
                        OnClick="imgClear_Click" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                            OnClick="imgClose_Click" /></td>
            <td></td>
        </tr>
         <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
         <tr>
            <td></td>
            <td>
                Department:</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlDept" runat="server" CssClass="dropdown" Width="98%" AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td colspan="2">
                <asp:RadioButtonList ID="rdbOption" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="A">All</asp:ListItem>
                    <asp:ListItem Value="N">Internal</asp:ListItem>
                    <asp:ListItem Value="Y">External</asp:ListItem>
                </asp:RadioButtonList></td>
            <td></td>
            <td></td>
        </tr>
         <tr>
            
            <td>
                &nbsp;</td>
             <td colspan="3">
                 <asp:DropDownList ID="ddlSub" runat="server" Visible="false" CssClass="dropdown" Width="98%">
                 </asp:DropDownList>
                  <div id="divSubDepartments" runat="server" visible="false">
            <fieldset>
            <legend>SubDepartments</legend>
            <table id="tblSubDepartments" class="label" width="99%">
            <tr>
            <td width="99%">
            <asp:Panel ID="pnlSubDepartments" runat="server" Height="60px" ScrollBars="Auto">
            <asp:GridView ID="gvSubDepartments" runat="server" Width="99%" ShowHeader="false" AutoGenerateColumns="false" DataKeyNames="SubDepartmentid">
            <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
            <RowStyle CssClass="gridItem" />
            <AlternatingRowStyle CssClass="gridAlternate" />
            <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:TemplateField>
            <ItemStyle Width="5%" HorizontalAlign="Center" />
            <ItemTemplate>
            <asp:CheckBox ID="gvchksub" runat="server" />
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView>
            </asp:Panel>
            </td>
            </tr>
            </table>
            
            </fieldset>
            </div>
                 
                 </td>
            <td rowspan="1">
                <asp:CheckBox ID ="chkcharges" runat="server" Checked="true" Text="With Chargess" />
             </td>
            <td>
                </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Group:</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="dropdown" Width="98%">
                </asp:DropDownList></td>
            <td>
                &nbsp;</td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
            <div id="divbranch" runat="server" visible="false">
            <fieldset>
            <legend>Branches</legend>
            <table id="tblbranch" class="label" width="99%">
            <tr>
            <td width="99%">
            <asp:Panel ID="pnlbranch" runat="server" Height="300px" ScrollBars="Auto">
            
            <asp:GridView ID="gvbranches" runat="server" Width="99%" AutoGenerateColumns="false" DataKeyNames="BranchID">
            <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
            <RowStyle CssClass="gridItem" />
            <AlternatingRowStyle CssClass="gridAlternate" />
            <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:TemplateField>
            <ItemStyle Width="5%" HorizontalAlign="Center" />
            <ItemTemplate>
            <asp:CheckBox ID="gvchkbranch" runat="server" />
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView>
            </asp:Panel>
            </td>
            </tr>
            </table>
            
            </fieldset>
            </div>
            </td>
            
            <td colspan="4">
            <%-- <div id="divSubDepartments" runat="server">
            <fieldset>
            <legend>SubDepartments</legend>
            <table id="tblSubDepartments" class="label" width="99%">
            <tr>
            <td width="99%">
            <asp:Panel ID="pnlSubDepartments" runat="server" Height="300px" ScrollBars="Auto">
            <asp:GridView ID="gvSubDepartments" runat="server" Width="99%" AutoGenerateColumns="false" DataKeyNames="SubDepartmentid">
            <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
            <RowStyle CssClass="gridItem" />
            <AlternatingRowStyle CssClass="gridAlternate" />
            <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:TemplateField>
            <ItemStyle Width="5%" HorizontalAlign="Center" />
            <ItemTemplate>
            <asp:CheckBox ID="gvchksub" runat="server" />
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView>
            </asp:Panel>
            </td>
            </tr>
            </table>
            
            </fieldset>
            </div>--%>
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
            <td class="screenid" colspan="8">
                &nbsp;</td>
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
            <td width="15%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="15%"></td>
            <td width="5%"></td>
            
        </tr>
    </table>

</asp:Content>

