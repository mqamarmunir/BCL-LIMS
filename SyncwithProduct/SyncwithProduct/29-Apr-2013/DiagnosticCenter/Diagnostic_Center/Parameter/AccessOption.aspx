<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/AccessOption.aspx.cs" Inherits="AccessOption" Title="Access Options Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>   
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
<TABLE style="WIDTH: 100%" class="label"><TBODY><TR><TD style="WIDTH: 5%; HEIGHT: 21px"></TD><TD style="HEIGHT: 21px" class="tdheading" align=center colSpan=5>Access Options Information</TD><TD style="WIDTH: 5%; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 5%; HEIGHT: 26px"></TD><TD style="WIDTH: 15%; HEIGHT: 26px">&nbsp; <asp:Label id="lblSave" tabIndex=40 runat="server" Text="i" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblSapsId" tabIndex=30 runat="server" Visible="False"></asp:Label></TD><TD style="WIDTH: 25%; HEIGHT: 26px">&nbsp; <asp:Label id="lblMemberId" tabIndex=20 runat="server" Visible="False"></asp:Label></TD><TD style="WIDTH: 15%; HEIGHT: 26px" align=right></TD><TD style="WIDTH: 25%; HEIGHT: 26px"><asp:Button id="btnSave" tabIndex=5 onclick="btnSave_Click" runat="server" Text="Save" CssClass="buttonStyle" ToolTip="Click to Save Access Options Data"></asp:Button>&nbsp; &nbsp;<asp:Button id="btnClear" tabIndex=6 onclick="btnClear_Click" runat="server" Text="Clear" CssClass="buttonStyle" ToolTip="Click to Save Screen Contents"></asp:Button> &nbsp; <asp:Button id="btnClose" tabIndex=7 onclick="btnClose_Click" runat="server" Text="Close" CssClass="buttonStyle" ToolTip="Click to Save Screen contents"></asp:Button></TD><TD style="WIDTH: 10%; HEIGHT: 26px"></TD><TD style="WIDTH: 5%; HEIGHT: 26px"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD colSpan=4><asp:Label id="lblErrMsg" tabIndex=40 runat="server" Font-Bold="True"></asp:Label></TD><TD style="WIDTH: 25%"></TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%; HEIGHT: 26px"></TD><TD style="WIDTH: 15%; HEIGHT: 26px" align=right>Option Name:&nbsp; </TD><TD style="WIDTH: 25%; HEIGHT: 26px" class="mandatoryField"><asp:TextBox id="txtOptionName" tabIndex=1 runat="server" ToolTip="Enter Access Option Name" Width="97%" MaxLength="50"></asp:TextBox></TD><TD style="WIDTH: 15%; HEIGHT: 26px" align=right>Type: &nbsp; </TD><TD style="WIDTH: 25%; HEIGHT: 26px"><asp:DropDownList id="ddlType" tabIndex=2 runat="server" ToolTip="Select Option Type as Form,Report,Link etc." Width="80%" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"><asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
<asp:ListItem>Form</asp:ListItem>
<asp:ListItem>Report</asp:ListItem>
<asp:ListItem>Link</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 10%; HEIGHT: 26px"><asp:CheckBox id="chkActive" tabIndex=3 runat="server" Text="Active" ToolTip="Check to Active this Access Option" Checked="True"></asp:CheckBox></TD><TD style="WIDTH: 5%; HEIGHT: 26px"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 15%" align=right>Description:&nbsp; </TD><TD style="WIDTH: 65%" colSpan=3><asp:TextBox id="txtDescription" tabIndex=1 runat="server" ToolTip="Enter Description for Option" Width="97%" MaxLength="50"></asp:TextBox></TD><TD style="WIDTH: 10%"><asp:CheckBox id="chkEventActive" tabIndex=4 runat="server" Text="Event Active" ToolTip="Check to Active this Access Option for Events Config."></asp:CheckBox></TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 90%" align=center colSpan=5>
<asp:GridView id="dg" tabIndex=10 runat="server" CssClass="datagrid" Width="100%" AutoGenerateColumns="False" 
    DataKeyNames="OptionId" OnRowEditing="dg_RowEditing" OnRowCommand="dg_RowCommand">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:BoundField DataField="OptionName" HeaderText="Option Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Description" HeaderText="Description">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="56%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Type" HeaderText="Type">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="6%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Active"><ItemTemplate>
                                <asp:CheckBox ID="chkActive" runat="server" Enabled="False" Checked ='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'/>
                            
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Event Active"><ItemTemplate>
                                <asp:CheckBox ID="chkEventActive" runat="server" Enabled="False" Checked ='<%# (DataBinder.Eval(Container.DataItem, "EventActive").ToString() == "Y") %>'/>
                            
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="6%"></ItemStyle>
</asp:TemplateField>
<asp:CommandField ShowEditButton="True" Visible="false">
<ItemStyle HorizontalAlign="Center" ForeColor="Blue" Width="5%"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowSelectButton="true" SelectText="Edit" />
</Columns>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> </TD><TD style="WIDTH: 5%"></TD></TR><TR><TD style="WIDTH: 5%"></TD><TD style="WIDTH: 15%"></TD><TD style="WIDTH: 25%"></TD><TD style="WIDTH: 15%"></TD><TD style="WIDTH: 25%" align=right><SPAN style="FONT-SIZE: 7pt"></SPAN></TD><TD style="WIDTH: 10%"></TD><TD style="WIDTH: 5%"></TD></TR></TBODY></TABLE>
</ContentTemplate>
    <Triggers><asp:PostBackTrigger ControlID="dg"></asp:PostBackTrigger></Triggers>
                        </asp:UpdatePanel> 
</asp:Content>

