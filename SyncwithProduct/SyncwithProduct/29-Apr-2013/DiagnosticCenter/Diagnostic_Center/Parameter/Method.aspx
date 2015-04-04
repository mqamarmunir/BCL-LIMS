<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/Method.aspx.cs" Inherits="Method_Reg" Title="Method Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

			<TABLE id="Table1" cellSpacing="1"
				cellPadding="1" width="100%" border="0" class="label">
				
				
				<TR>
					<TD colSpan="8" align="center" class="tdheading">
                        Method Registration</TD>
				</TR>
				<TR>
					<TD colSpan="8" class="screenid">
                        &nbsp;</TD>
				</TR>
                <tr>
                    <td class="screenid" colspan="8">
                    </td>
                </tr>
				<TR>
					<TD></TD>
                    <td colspan="4">
						<asp:Label id="lblErrMSg" runat="server" ForeColor="Red"></asp:Label></td>
					<TD colspan="2">
                        <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                            ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                                ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="screenid" colspan="8">
                        &nbsp;</TD>
				</TR>
               
				
				<TR>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD colspan="3">
						<asp:dropdownlist id="ddlSUBDept" runat="server" Width="100%" tabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddlSUBDept_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right">
						<asp:checkbox id="chkActive" runat="server" tabIndex="2" Checked="True" Text="Active"></asp:checkbox>&nbsp;</TD>
					<TD>
						<asp:checkbox id="chkDefault" runat="server" tabIndex="3" Text="Default"></asp:checkbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Method:</TD>
					<TD colSpan="3">
						<asp:textbox id="txtMethod" runat="server" Width="98%" tabIndex="4" CssClass="mandatoryField" MaxLength="100"></asp:textbox></TD>
					<TD align="right">Acronym:&nbsp;&nbsp;</TD>
					<TD>
						<asp:textbox id="txtAcronym" runat="server" Width="50%" tabIndex="5" CssClass="mandatoryField" MaxLength="6"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
                        Time Type:</TD>
					<TD colspan="3">
						<asp:dropdownlist id="ddlTimeType" runat="server" Width="20%" tabIndex="6">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="M">Minute(s)</asp:ListItem>
							<asp:ListItem Value="H">Hour(s)</asp:ListItem>
							<asp:ListItem Value="D">Day(s)</asp:ListItem>
						</asp:dropdownlist>
                        &nbsp;
                        Min:&nbsp;&nbsp;<asp:textbox id="txtMinTime" runat="server" Width="20%" tabIndex="7" CssClass="mandatoryField" MaxLength="3"></asp:textbox>
                        &nbsp; &nbsp;
                        Max:&nbsp;
						<asp:textbox id="txtMaxTime" runat="server" Width="20%" tabIndex="8" CssClass="mandatoryField" MaxLength="3"></asp:textbox></TD>
					<TD align="right" >
                        D-Order:
                        &nbsp;
                    </TD>
					<TD >
                        <asp:TextBox ID="txtDorder" runat="server" CssClass="field" MaxLength="3" Width="50%"></asp:TextBox></TD>
					<TD ></TD>
				</TR>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td colspan="3">
                    </td>
                    <td align="right">
                    </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="screenid" colspan="8">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="screenid" colspan="8">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="6">
                        <asp:GridView ID="gvMethod" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="methodid,subdepartmentid,dfault,mintimevalue,maxtimevalue,timetype" OnRowCommand="gvMethod_RowCommand">
                            <Columns>
                            <asp:TemplateField HeaderText="S#">
                                <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                                <HeaderStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                                <asp:BoundField DataField="name" HeaderText="Method">
                                    <ItemStyle HorizontalAlign="Left" Width="50%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="acronym" HeaderText="Acronym">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="mintime" HeaderText="Min Time">
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="maxtime" HeaderText="Max Time">
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dorder" HeaderText="Dorder">
                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Active">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle Width="5%" />
                                </asp:CommandField>
                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                        </asp:GridView>
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
                    <td align="right">
                    </td>
                    <td>
                    </td>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                
		        <tr>
                    <td width="3%">
                    </td>
                    <td width="12%">
                    </td>
                    <td width="20%">
                    </td>
                    <td width="10%">
                    </td>
                    <td width="20%">
                    </td>
                    <td width="10%">
                    </td>
                    <td width="20%">
                    </td>
                    <td width="5%">
                    </td>
                </tr>
			</TABLE>
			
</asp:Content>

