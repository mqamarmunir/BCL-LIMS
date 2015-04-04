<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCourierbranchRegistration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
 <asp:UpdatePanel ID="up" runat="server"><ContentTemplate>
<table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
    <tr>
        <td align="center" class="tdheading" colspan="8">
           
            Courier Branch Registration</td>
    </tr>
     <tr>
        <td class="screenid" colspan="8">
            <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
         </td>
    </tr>
     <tr>
        <td></td>
        <td colspan="3">
            &nbsp;</td>
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
            Name:</td>
        <td>
           <asp:TextBox ID="txtName" CssClass="mandatoryField" runat="server" Width="99%"></asp:TextBox></td>
        <td>
            City:</td>
         <td colspan="3">
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="dropdown" Width="50%">
              
            </asp:DropDownList>&nbsp;&nbsp;
             <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" />
         </td>
        <td></td>
    </tr>
     <tr>
        <td></td>
        <td>
            Address:</td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="field" TextMode="MultiLine" Width="99%"></asp:TextBox>
         </td>
        <td></td>
        <td>
            &nbsp;</td>
        <td>
            </td>
        <td></td>
        <td></td>
    </tr>
     <tr>
        <td></td>
        <td>
            Phone(s):</td>
         <td>
             <asp:TextBox ID="txtPhone1" runat="server" CssClass="field" Width="45%"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="txtPhone2" runat="server" CssClass="field" Width="45%"></asp:TextBox>
             </td>
        <td>Fax:</td>
        <td>
            <asp:TextBox ID="txtFax" runat="server" CssClass="field" Width="50%"></asp:TextBox>
         </td>
    </tr>
     <tr>
        <td></td>
        <td>E-Mail:</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="field" Width="99%"></asp:TextBox>
         </td>
         <td>
         Mobile:
         </td>
         <td>
             <asp:TextBox ID="txtMobi" runat="server" CssClass="field" Width="99%"></asp:TextBox>
         </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            &nbsp;</td>
        <td ></td>
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
            <asp:GridView ID="gvCourierBranches" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="CourierServiceID" OnRowCommand="gvCourierBranches_RowCommand">
                <RowStyle CssClass="gridItem" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>:
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Service Name">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="City" HeaderText="City">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Phone" HeaderText="Phone Number">
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

