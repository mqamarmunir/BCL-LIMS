<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/AccessGroup.aspx.cs" Inherits="AccessGroup" Title="Access Groups Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>   
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>   
<table style="width:100%" class="label">
        <tr>
            <td style="width: 5%; height: 2px;">            
            </td>
            <td align="center" class="tdheading" colspan="5" style="height: 2px">
                Access Groups Information</td>
            <td style="width: 5%; height: 2px;">
            </td>
        </tr>
        <tr>
            <td style="width:5%; height: 26px;">
            </td>
            <td style="width:15%; height: 26px;">
                &nbsp;
                <asp:Label ID="lblSave" runat="server" Text="i" Visible="False" TabIndex="30"></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblSapsId" runat="server" Visible="False" TabIndex="10"></asp:Label></td>
            <td style="width:25%; height: 26px;">
                &nbsp;
                <asp:Label ID="lblMemberId" runat="server" TabIndex="20" Visible="False"></asp:Label>
                &nbsp;&nbsp;
                <asp:Label ID="lblAccessMode" runat="server" TabIndex="20" Visible="False"></asp:Label></td>
            <td style="width:10%; height: 26px;">
            </td>
            <td style="width:15%; height: 26px;" align="right"></td>
            <td style="width:25%; height: 26px;">
                <asp:Button ID="btnSave" runat="server" CssClass="buttonStyle" Text="Save" ToolTip="Click to Save Access Group Data" OnClick="btnSave_Click" TabIndex="4" />&nbsp;
                &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="buttonStyle" Text="Clear" ToolTip="Click to Clear Screen contents" OnClick="btnClear_Click" TabIndex="5" />
                &nbsp;
                <asp:Button ID="btnClose" runat="server" CssClass="buttonStyle" Text="Close" ToolTip="Click to Close Screen contents" OnClick="btnClose_Click" TabIndex="6" /></td>
            <td style="width:5%; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td colspan="4">
                <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" TabIndex="40"></asp:Label></td>
            <td style="width: 25%">
            </td>
            <td style="width: 5%">
            </td>
        </tr>
        <tr>
            <td style="width: 5%; height: 26px;">
            </td>
            <td align="right" style="width: 15%; height: 26px;">
                Group Name: &nbsp;
            </td>
            <td class="mandatoryField" style="width: 25%; height: 26px;">
                <asp:TextBox ID="txtGroupName" runat="server" TabIndex="1" Width="97%" MaxLength="50" ToolTip="Enter Group Name For Access Rights"></asp:TextBox></td>
            <td style="width: 10%; height: 26px;">
                &nbsp; &nbsp;&nbsp;
                <asp:CheckBox ID="chkActive" runat="server" Text="Active" Checked="True" TabIndex="2" ToolTip="Check To Active This Group" /></td>
            <td align="right" style="width: 15%; height: 26px;">
                &nbsp;
            </td>
            <td style="width: 25%; height: 26px;">
                </td>
            <td style="width: 5%; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 15%" align="right">
                Description: &nbsp;
            </td>
            <td style="width: 75%" colspan="4">
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="255" TabIndex="3" ToolTip="Enter Group Description"
                    Width="99%"></asp:TextBox></td>            
            <td style="width: 5%">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 15%">
            </td>
            <td style="width: 25%">
            </td>
            <td style="width: 10%">
            </td>
            <td style="width: 15%">
            </td>
            <td style="width: 25%">
            </td>
            <td style="width: 5%">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 15%">
            </td>
            <td style="width: 75%" colspan="4" align="left">
                <asp:GridView ID="dg" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="datagrid" DataKeyNames="GroupId" OnRowEditing="dg_RowEditing" TabIndex="7" OnSelectedIndexChanged="dg_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="GroupName" HeaderText="Group Name" >
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description">
                            <ItemStyle HorizontalAlign="Left" Width="55%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkActive" runat="server" Enabled="False" Checked ='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="6%" ForeColor="Blue" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                        <asp:CommandField SelectText="Access Options" ShowSelectButton="True">
                            <ItemStyle Width="12%" ForeColor="Blue" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <RowStyle CssClass="gridItem" />
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
            </td>
            <td style="width: 5%">
            </td>
        </tr>
      <tr>
            <td style="width:5%; height: 9px;">
            </td>
            <td style="width:15%; height: 9px;" align="right">
            </td>
            <td style="width:25%; height: 9px;" align="left">
                &nbsp;&nbsp;
                <asp:RadioButtonList ID="rbListType" runat="server" RepeatDirection="Horizontal" BackColor="#CBD7E4" BorderStyle="Solid" BorderWidth="1px" ForeColor="ControlText" OnSelectedIndexChanged="rbListType_SelectedIndexChanged" AutoPostBack="True" ToolTip="Access Options Selection for Selected Group">
                    <asp:ListItem Selected="True" Value="Form">Forms</asp:ListItem>
                    <asp:ListItem Value="Report">Reports</asp:ListItem>
                    <asp:ListItem Value="Link">Links</asp:ListItem>
                </asp:RadioButtonList>
                &nbsp;
            </td>
            <td style="width:10%; height: 9px;" align="right">
            </td>
            <td style="width:15%; height: 9px;" align="right"></td>
            <td style="width:25%; height: 9px;" align="right">
                <asp:Button ID="btnAdd" runat="server" style="width:20%;" CssClass="buttonStyle" Text="Add" ToolTip="Click to Add Access Options" OnClick="btnAdd_Click" TabIndex="3" />&nbsp;
                &nbsp;<asp:Button ID="btnSave2" runat="server" CssClass="buttonStyle" Text="Save" ToolTip="Click to Save Selected Access Options" OnClick="btnSave2_Click" TabIndex="4" />
                &nbsp;
                <asp:Button ID="btnClose2" runat="server" CssClass="buttonStyle" Text="Close" ToolTip="Click to Close Access Options" OnClick="btnClose2_Click" TabIndex="5" /></td>
            <td style="width:5%; height: 9px;">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 15%">
            </td>
            <td style="width: 75%" colspan="4" align="left">
                <asp:GridView ID="dgAccessOptions" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="datagrid" DataKeyNames="OptionId" OnRowEditing="dg_RowEditing" TabIndex="7" OnSelectedIndexChanged="dg_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="OptionName" HeaderText="Access Option Name" >
                            <ItemStyle HorizontalAlign="Left" Width="27%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description">
                            <ItemStyle HorizontalAlign="Left" Width="73%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle CssClass="gridItem" />
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
            </td>
            <td style="width: 5%">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 15%">
            </td>
            <td style="width: 75%" colspan="4" align="left">
                <asp:GridView ID="dgAllAccessOptions" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="datagrid" DataKeyNames="OptionId" OnRowEditing="dg_RowEditing" TabIndex="7" OnSelectedIndexChanged="dg_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="OptionName" HeaderText="Access Option Name" >
                            <ItemStyle HorizontalAlign="Left" Width="27%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description">
                            <ItemStyle HorizontalAlign="Left" Width="65%" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkActive" runat="server" Enabled="True"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="gridItem" />
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
            </td>
            <td style="width: 5%">
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers><asp:PostBackTrigger ControlID="dg"></asp:PostBackTrigger></Triggers>
                        </asp:UpdatePanel> 
    </asp:Content>   


