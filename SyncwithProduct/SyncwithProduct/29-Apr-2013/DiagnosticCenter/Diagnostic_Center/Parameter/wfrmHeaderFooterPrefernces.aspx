<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmHeaderFooterPrefernces.aspx.cs" Inherits="Parameter_wfrmHeaderFooterPrefernces" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager> 
<table class="style1" width="100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lb_error" runat="server"></asp:Label>
                <asp:Label ID="Lb_Saved" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:ImageButton ID="Img_Button_Save" runat="server" ToolTip="Save Data" 
                    ImageUrl="~/images/buttons/save.png" onclick="Img_Button_Save_Click" />
                &nbsp;<asp:ImageButton ID="Img_Button_search" runat="server" 
                    ToolTip="Search Data" ImageUrl="~/images/buttons/search.png" />
                &nbsp;<asp:ImageButton ID="Img_Button_Clear" runat="server" 
                    ToolTip="Clear Data" ImageUrl="~/images/buttons/clear.png" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:CheckBox ID="Chk_Active" Text="Active" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lb_PreferenecName" runat="server" Text="Preference Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxBx_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lb_PrefernceType" runat="server" Text="Preference Type"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Txbx_Type" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxBx_Desc" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Upload File :"></asp:Label>
            </td>
            <td>
                <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />
                <asp:Label ID="Lb_UploadFiles" runat="server" Font-Size="10px" Text="(Please upload Image header width is 900px and height is 100px.)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="Gv_PreferenceSetting" runat="server" 
                    AutoGenerateColumns="False" Width="100%" CellPadding="2" 
                    ForeColor="#333333" GridLines="None" 
                    onpageindexchanging="Gv_PreferenceSetting_PageIndexChanging" DataKeyNames="PreferenceID" 
                    onrowcommand="Gv_PreferenceSetting_RowCommand">
                    <RowStyle BackColor="#D1EED6" />
                    <Columns>
                    <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="Lb_prefID" runat="server" Text='<%# Eval("PreferenceID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PreferenceName" HeaderText="File Name" />
                        <asp:BoundField DataField="PreferenceType" HeaderText="Type" />
                        <asp:BoundField DataField="Description" HeaderText="Header Description" />
                        <asp:ImageField ControlStyle-Width="500px" HeaderStyle-HorizontalAlign="Left" ControlStyle-Height="80px" DataImageUrlField="path_location">
                        </asp:ImageField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="Chk_Active" Enabled="true"  Checked ='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "1") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle HorizontalAlign="Left" BackColor="#c4e1ff" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>

            </td>
        </tr>
        <tr>
        <td colspan="2" align="right">
                <asp:ImageButton ID="UpdateNow" ImageUrl="../images/update.jpeg" runat="server" 
                    onclick="UpdateNow_Click" />
        </td>
            
        </tr>
    </table>

</asp:Content>

