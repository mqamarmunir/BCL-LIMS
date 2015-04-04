<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmRefDoctor.aspx.cs" Inherits="refdoctor" Title="Doctor Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
<TABLE id="main" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD class="tdheading" align=center colSpan=8>Doctor Registration</TD></TR><TR><TD class="screenid" colSpan=8>&nbsp;</TD></TR><TR><TD colSpan=5><asp:Label id="lblerror" runat="server"></asp:Label></TD><TD align=right colSpan=2><asp:ImageButton id="imgSave" onclick="imgSave_Click" runat="server" ImageUrl="~/images/SavePack_2.gif"></asp:ImageButton><asp:ImageButton id="imgClear" onclick="imgClear_Click" runat="server" ImageUrl="~/images/ClearPack.gif"></asp:ImageButton><asp:ImageButton id="imgClose" onclick="imgClose_Click" runat="server" ImageUrl="~/images/ClosePack.gif"></asp:ImageButton></TD><TD></TD></TR><TR><TD class="screenid" colSpan=8>&nbsp;</TD></TR><TR><TD></TD><TD>Organization:</TD><TD colSpan=2><asp:DropDownList id="ddlOrg" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlOrg_SelectedIndexChanged">
                </asp:DropDownList></TD><TD align=center>Panel:</TD><TD colSpan=2><asp:DropDownList id="ddlPanel" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlPanel_SelectedIndexChanged">
                </asp:DropDownList></TD><TD></TD></TR><TR><TD></TD><TD>Department:</TD><TD colSpan=2><asp:DropDownList id="ddlDepart" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlDepart_SelectedIndexChanged">
                </asp:DropDownList></TD><TD></TD><TD colSpan=2><asp:CheckBox id="chkActive" runat="server" Checked="True" Text="Active"></asp:CheckBox></TD><TD></TD></TR><TR><TD></TD><TD colSpan=6>&nbsp;<TABLE id="sub1" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Title:</TD><TD colSpan=3><asp:DropDownList id="ddlTitle" runat="server" Width="15%"><asp:ListItem Value="Dr">Dr</asp:ListItem>
<asp:ListItem Value="Prof">Prof</asp:ListItem>
</asp:DropDownList> Name: <asp:TextBox id="txtName" runat="server" Width="62%" CssClass="mandatoryField"></asp:TextBox></TD><TD>Code:</TD><TD><asp:TextBox id="txtCode" runat="server" CssClass="field" MaxLength="10"></asp:TextBox></TD><TD>Share:</TD><TD><asp:TextBox id="txtShare" runat="server" Width="40%" CssClass="field" MaxLength="3"></asp:TextBox> (%)</TD></TR><TR><TD>Cell #:</TD><TD><asp:TextBox id="txtCell" runat="server" Width="98%" CssClass="field" MaxLength="20"></asp:TextBox></TD><TD>Fax #:</TD><TD><asp:TextBox id="txtFax" runat="server" Width="98%" CssClass="field" MaxLength="20"></asp:TextBox></TD><TD>Speciality:</TD><TD><asp:DropDownList id="ddlSpeciality" runat="server" Width="99%" CssClass="dropdown">
                            </asp:DropDownList></TD><TD>Reg Date:</TD><TD><asp:TextBox id="txtregdate" runat="server" Width="60%" CssClass="field"></asp:TextBox> <asp:ImageButton id="imgCal" runat="server" ImageUrl="~/images/btn_Blank.GIF"></asp:ImageButton></TD></TR><TR><TD>City:</TD><TD><asp:DropDownList id="ddlCity" runat="server" Width="99%">
                            </asp:DropDownList></TD><TD>Email:</TD><TD colSpan=2><asp:TextBox id="txtEmail" runat="server" Width="98%" CssClass="field" MaxLength="30"></asp:TextBox></TD><TD colSpan=3>Address:<asp:TextBox id="txtAddress" runat="server" Width="85%" CssClass="field"></asp:TextBox></TD></TR><TR><TD>Login ID:</TD><TD><asp:TextBox id="txtLogin" runat="server" Width="60%" CssClass="field" MaxLength="15" __designer:wfdid="w1"></asp:TextBox></TD><TD>Pasword:</TD><TD colSpan=2><asp:TextBox id="txtPasword" runat="server" Width="60%" CssClass="field" MaxLength="15" __designer:wfdid="w2" TextMode="Password"></asp:TextBox></TD><TD colSpan=3><asp:Label id="lblPasword" runat="server" Visible="False" __designer:wfdid="w3"></asp:Label></TD></TR><TR><TD width="6%"></TD><TD width="20%"></TD><TD width="6%"></TD><TD width="20%"></TD><TD width="5%"></TD><TD width="20%"></TD><TD width="9%"></TD><TD width="14%"></TD></TR></TBODY></TABLE></TD><TD></TD></TR><TR><TD></TD><TD></TD><TD><asp:Label id="lblID" runat="server" Visible="False"></asp:Label> <asp:Label id="lblStatus" runat="server" Visible="False"></asp:Label></TD><TD></TD><TD></TD><TD>&nbsp;</TD><TD>&nbsp; <cc1:MaskedEditExtender id="msk_txt" runat="server" TargetControlID="txtregdate" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99/99/9999" MaskType="date"></cc1:MaskedEditExtender> <cc1:CalendarExtender id="cal_td" runat="server" TargetControlID="txtregdate" Format="dd/MM/yyyy" PopupButtonID="imgCal"></cc1:CalendarExtender><cc1:FilteredTextBoxExtender id="flt_login" runat="server" TargetControlID="txtLogin" Enabled="True" ValidChars="_" FilterType="Custom,UppercaseLetters,LowercaseLetters,numbers"></cc1:FilteredTextBoxExtender> </TD><TD></TD></TR><TR><TD class="screenid" colSpan=8>&nbsp;</TD></TR><TR><TD colSpan=8><asp:GridView id="gvDoctor" runat="server" Width="98%" CssClass="datagrid" AutoGenerateColumns="False" DataKeyNames="doctorid,departmentid,orgid,panelid,faxno,email,address,specialityid,cityid,name,title,code,pasword" OnRowCommand="gvDoctor_RowCommand">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="S#"><ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="doctorname" HeaderText="Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="17%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="share" HeaderText="Share">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="reg_date" HeaderText="Reg Date">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="orgname" HeaderText="Organization">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="panelname" HeaderText="Panel">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cellno" HeaderText="Cell #">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cityname" HeaderText="City">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="loginid" HeaderText="Login ID">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Active"><ItemTemplate>
                                <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                            
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle Width="5%"></ItemStyle>
</asp:CommandField>
</Columns>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD></TR><TR><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD></TR><TR><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD></TR><TR><TD width="5%"></TD><TD width="10%"></TD><TD width="25%"></TD><TD width="10%"></TD><TD width="10%"></TD><TD width="15%"></TD><TD width="17%"></TD><TD width="8%"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                        </asp:UpdatePanel>   
</asp:Content>

