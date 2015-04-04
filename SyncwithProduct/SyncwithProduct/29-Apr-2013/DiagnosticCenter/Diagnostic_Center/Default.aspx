<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <asp:DropDownList ID="ddl_Dept" runat="server">
    <asp:ListItem Value="1" Text="Main">Main</asp:ListItem>
    <asp:ListItem Value="2" Text="Main">IT</asp:ListItem>
    </asp:DropDownList>


From: <asp:TextBox ID="TxBx_From" runat="server"></asp:TextBox>

&nbsp;&nbsp;

To:<asp:TextBox ID="TxBx_To" runat="server"></asp:TextBox>

    <br />

    <asp:RadioButton ID="RadioButton1" Text="A" GroupName="1" runat="server" />
    <asp:RadioButton ID="RadioButton2" Text="B" GroupName="1" runat="server" />
    <asp:RadioButton ID="RadioButton3" Text="C" GroupName="1" runat="server" />
    <table width="100%">
        <tr>
            <td style="width:80%;">    
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" 
                        Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#D1EED6" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Access Rights">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk_Me"  runat="server" />
                                        <%--<asp:CheckBox ID="Chk_froms"  runat="server" Enabled="true"  Checked ='<%# (DataBinder.Eval(Container.DataItem, "GroupAccess").ToString() == "t") %>'/>
                                    --%></ItemTemplate>
                                    <ItemStyle Width="12%" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="prno" HeaderText="PR#" SortExpression="prno" />
                            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />

                        </Columns>
                    </asp:GridView>
            </td>
            <td style="width:20%;">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            onrowcommand="GridView2_RowCommand" onrowdatabound="GridView2_RowDataBound" 
                            Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TreeView ID="TreeView1" ShowCheckBoxes="Root" runat="server">
                                    </asp:TreeView>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
            </td>
        </tr>
    </table>

  

    <br />
    <asp:Button ID="Button1" runat="server" Text="Save &amp; Next" />


</asp:Content>

