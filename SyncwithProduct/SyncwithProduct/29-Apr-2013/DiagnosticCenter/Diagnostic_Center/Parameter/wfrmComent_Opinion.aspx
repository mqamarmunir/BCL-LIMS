<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmComent_Opinion.aspx.cs" Inherits="test_c_p" Title="Test Template Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
 <asp:UpdatePanel ID="up" runat="server"><ContentTemplate>
<table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
    <tr>
        <td align="center" class="tdheading" colspan="8">
           
            Test Template Registration</td>
    </tr>
     <tr>
        <td class="screenid" colspan="8">
            &nbsp;</td>
    </tr>
     <tr>
        <td></td>
        <td colspan="3">
            <asp:Label ID="lblError" runat="server"></asp:Label></td>
        <td align="right" colspan="2">
            <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" AccessKey="s" ToolTip="Click or press Al+s to save test template" /><asp:ImageButton
                ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" AccessKey="x" ToolTip="Click or press Alt+x to clear  information" /><asp:ImageButton
                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" AccessKey="c" ToolTip="Click or press Alt+c to close this screen" /></td>
        <td></td>
        <td></td>
    </tr>
     <tr>
        <td></td>
        <td>
            Subdepartment:</td>
        <td>
            <asp:DropDownList ID="ddlSubdept" runat="server" CssClass="dropdown" Width="99%" AutoPostBack="True" OnSelectedIndexChanged="ddlSubdept_SelectedIndexChanged" ToolTip="Please select subdepartment ">
            </asp:DropDownList></td>
        <td>
            Test:</td>
         <td colspan="3">
            <asp:DropDownList ID="ddlTest" runat="server" CssClass="dropdown" Width="99%" AutoPostBack="True" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged" ToolTip="Please select Test">
            </asp:DropDownList></td>
        <td></td>
    </tr>
     <tr>
        <td></td>
        <td>
            Person:</td>
        <td>
            <asp:DropDownList ID="ddlPerson" runat="server" CssClass="dropdown" Width="99%" ToolTip="Please select person">
            </asp:DropDownList></td>
        <td></td>
        <td>
            <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" />
            <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label></td>
        <td></td>
        <td></td>
    </tr>
     <tr>
        <td></td>
        <td>
            Comment:</td>
         <td colspan="5" rowspan="2">
            <asp:TextBox ID="txtComment" runat="server" CssClass="field" TextMode="MultiLine"
                Width="99%" ToolTip="Please enter test comments"></asp:TextBox></td>
        <td></td>
    </tr>
     <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            Opinion:</td>
        <td colspan="5" rowspan="2">
            <asp:TextBox ID="txtOpinion" runat="server" CssClass="field" TextMode="MultiLine"
                Width="99%" ToolTip="Please enter test opinion"></asp:TextBox></td>
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
    </tr>
    <tr>
        <td>
        </td>
        <td colspan="6">
            <asp:GridView ID="gvTemplate" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="cpid,personid,testid" OnRowCommand="gvTemplate_RowCommand">
                <RowStyle CssClass="gridItem" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>:
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="personname" HeaderText="Person">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="comment" HeaderText="Comment">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="opinion" HeaderText="Opinion">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Active">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkgvActive" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' runat="server" Enabled="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle CssClass="gridheader" />
                <AlternatingRowStyle CssClass="gridAlternate" />
            </asp:GridView>
        </td>
        <td>
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
        <td></td>
    </tr>
     <tr>
        <td width="5%"></td>
        <td width="15%"></td>
        <td width="30%"></td>
        <td width="5%"></td>
        <td width="25%"></td>
        <td width="10%"></td>
        <td width="5%"></td>
        <td width="5%"></td>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

