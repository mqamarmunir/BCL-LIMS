<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/transaction/wfrmResultCallBack.aspx.cs" Inherits="transaction_wfrmResultCallBack" Title="Result Call Back" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
    <tr>
        <td align="center" class="tdheading" colspan="8">
            Result Call Back</td>
    </tr>
    <tr>
        
        <td colspan="8">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
			<asp:Label ID="lblError" runat="server" Width="90%">
			</asp:Label>
        </td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td>
			</td>
        <td></td>
        <td align="center" colspan="2">
            <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif" OnClick="imgSearch_Click" />
			<asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" />
			<asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
        <td></td>
    </tr>
    <tr>
        <td>
		</td>
        <td colspan="6">
            <asp:UpdatePanel id="up_pinfo" runat="Server">
				<ContentTemplate>
<asp:Panel id="pnl_P_info" runat="Server" GroupingText="Patient Info" Width="99%"><TABLE id="tb_p_info" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Lab ID:</TD><TD><asp:TextBox id="txtLabID" runat="server" Width="50%" CssClass="fieldheading"></asp:TextBox> <asp:ImageButton id="imgLab" runat="server" ImageUrl="~/images/btn_Blank.GIF" OnClick="imgLab_Click"></asp:ImageButton> </TD><TD align=center>PR No:</TD><TD><asp:TextBox id="txtPRNO" runat="server" Width="50%" CssClass="fieldheading"></asp:TextBox> <asp:ImageButton id="imgPRNo" runat="server" ImageUrl="~/images/btn_Blank.GIF" OnClick="imgPRNo_Click"></asp:ImageButton> </TD><TD>Name:</TD><TD><asp:TextBox id="txtPatientName" runat="server" Width="98%" CssClass="field"></asp:TextBox> </TD></TR><TR><TD>Gender:</TD><TD><asp:RadioButtonList id="rdbGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
<asp:ListItem Value="F">Female</asp:ListItem>
</asp:RadioButtonList> </TD><TD align=center>Age:</TD><TD><asp:TextBox id="txtAge" runat="server" Width="40%" CssClass="field"></asp:TextBox> <asp:RadioButtonList id="rdbPatientOption" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rdbPatientOption_SelectedIndexChanged"><asp:ListItem Selected="True" Value="C">Cash</asp:ListItem>
<asp:ListItem Value="P">Panel</asp:ListItem>
</asp:RadioButtonList> </TD><TD></TD><TD></TD></TR><TR><TD>From:</TD><TD><asp:TextBox id="txtFromDate" runat="server" Width="40%" CssClass="field">	
										</asp:TextBox> To:<asp:TextBox id="txtToDate" runat="server" Width="40%" CssClass="field">
										</asp:TextBox> </TD><TD align=center></TD><TD colSpan=2></TD><TD></TD></TR><TR><TD></TD><TD><cc1:CalendarExtender id="cal_frm" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
										</cc1:CalendarExtender> <cc1:CalendarExtender id="cal_To" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate">
										</cc1:CalendarExtender> <cc1:MaskedEditExtender id="mask_ToDate" runat="server" TargetControlID="txtToDate" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99/99/9999">
										</cc1:MaskedEditExtender> <cc1:MaskedEditExtender id="mask_FrmDate" runat="server" TargetControlID="txtFromDate" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99/99/9999">
										</cc1:MaskedEditExtender> <cc1:MaskedEditExtender id="mask_prno" runat="server" TargetControlID="txtPRNO" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="999-99-99999999">
										</cc1:MaskedEditExtender> <cc1:MaskedEditExtender id="mask_Labid" runat="server" TargetControlID="txtLabID" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99-999-99999999">
										</cc1:MaskedEditExtender> </TD><TD></TD><TD></TD><TD></TD><TD></TD></TR><TR><TD width="10%"></TD><TD width="20%"></TD><TD width="10%"></TD><TD width="20%"></TD><TD width="10%"></TD><TD width="20%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
			</asp:UpdatePanel>  
        </td>
        <td>
		</td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
			<asp:UpdatePanel id="up_prg" runat="server">
				<contenttemplate>
					<asp:UpdateProgress id="UpdateProgress1" runat="server" DisplayAfter="0">
						<ProgressTemplate>
							<DIV class="UpdateProgress">
								<asp:Image id="Image1" runat="server" ImageUrl="../images/loading.gif">
								</asp:Image> ........Loading! Please Wait 
							</DIV>
						</ProgressTemplate>
					</asp:UpdateProgress> 
				</contenttemplate>
				<triggers>
					<%--<asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="ddlSubdepartment" EventName="SelectedIndexChanged">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="gvResult" EventName="RowCommand">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="imgClose" EventName="Click">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="imgLab" EventName="Click">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="imgPRNo" EventName="Click">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click">
					</asp:AsyncPostBackTrigger>
					<asp:AsyncPostBackTrigger ControlID="rdbPatientOption" EventName="SelectedIndexChanged">
					</asp:AsyncPostBackTrigger>--%>
				</triggers>
			</asp:UpdatePanel>  
		</td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td colspan="6">
			<asp:UpdatePanel ID="up_panel" runat="Server">
				<ContentTemplate>
					<asp:Panel ID="pnl_Pnl_info" runat="Server" GroupingText="Panel Info" Width="99%">
						<table id="tb_pnl_info" border="0" cellpadding="1" cellspacing="1" class="label"
							width="100%">
							<tbody>
								<tr>
									<td>
										Panel:</td>
									<td>
										<asp:DropDownList ID="ddlPanel" runat="server" CssClass="dropdown" Width="99%">
										</asp:DropDownList></td>
									<td>
										Employee:</td>
									<td>
										<asp:TextBox ID="txtEmployeeName" runat="server" CssClass="field" Width="98%">
										</asp:TextBox>
									</td>
									<td>
										Employee No:</td>
									<td>
										<asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="field" Width="99%">
										</asp:TextBox>
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
								</tr>
								<tr>
									<td width="10%">
									</td>
									<td width="35%">
									</td>
									<td width="10%">
									</td>
									<td width="20%">
									</td>
									<td width="10%">
									</td>
									<td width="15%">
									</td>
								</tr>
							</tbody>
						</table>
					</asp:Panel>
				</ContentTemplate>
				<Triggers>
					<%--<asp:AsyncPostBackTrigger ControlID="rdbPatientOption" EventName="SelectedIndexChanged" />
					<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click" />--%>
				</Triggers>
			</asp:UpdatePanel>
		</td>
        <td></td>
    </tr>
    <tr>
        <td></td>
		<td colspan="6">
			<asp:UpdatePanel id="up_testInfo" runat="Server">
				<ContentTemplate>
<asp:Panel id="pnl_Test" runat="Server" Width="99%" GroupingText="Test Info:"><TABLE id="tb_test" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Department:</TD><TD style="WIDTH: 7px"><asp:DropDownList id="ddlDepartment" runat="server" Width="90%" CssClass="dropdown" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True">
										</asp:DropDownList> </TD><TD>Sub-Department:</TD><TD><asp:DropDownList id="ddlSubdepartment" runat="server" Width="90%" CssClass="dropdown" OnSelectedIndexChanged="ddlSubdepartment_SelectedIndexChanged" AutoPostBack="True">
										</asp:DropDownList> </TD></TR><TR><TD>Group:</TD><TD style="WIDTH: 7px"><asp:DropDownList id="ddlGroup" runat="server" Width="90%" CssClass="dropdown">
										</asp:DropDownList> </TD><TD>Test:</TD><TD><asp:DropDownList id="ddlTest" runat="server" Width="90%" CssClass="dropdown">
										</asp:DropDownList> </TD></TR><TR><TD width="15%"></TD><TD style="WIDTH: 7px"></TD><TD width="15%"></TD><TD width="35%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate> 
			</asp:UpdatePanel> 
        </td>
        <td>
		</td>
	</tr>
	<tr>
        <td class="screenid" colspan="8">
        </td>
    </tr>
    <tr>
		<td>
		</td>
        <td colspan="6">
			<asp:UpdatePanel id="up_gv" runat="server">
				<ContentTemplate>
<asp:LinkButton id="lbtntest" runat="server" __designer:wfdid="w7"></asp:LinkButton><cc1:ModalPopupExtender id="mde_intcmt" runat="server" TargetControlID="lbtntest" __designer:wfdid="w8" CancelControlID="imgCmt_Close" BackgroundCssClass="TransparentGrayBackground" DropShadow="true" PopupControlID="pnlInt_cmmnt" X="300" Y="100">
               </cc1:ModalPopupExtender> <asp:Panel id="pnlInt_cmmnt" runat="server" Width="500px" CssClass="mPopup" __designer:wfdid="w46" ScrollBars="Vertical" Height="420px"><TABLE id="tb_cpy" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD align=center colSpan=4><STRONG>Internal Comment</STRONG></TD></TR><TR><TD align=center colSpan=4><asp:Label id="lblTest_intCmt" runat="server" Font-Bold="True" __designer:wfdid="w47"></asp:Label></TD></TR><TR><TD align=right><asp:Label id="lblInt_testID" runat="server" Visible="False" __designer:wfdid="w48"></asp:Label>&nbsp; </TD><TD align=right colSpan=3><asp:Label id="lblInt_BookingID" runat="server" Visible="False" __designer:wfdid="w49"></asp:Label> <asp:Label id="lblInt_Index" runat="server" Visible="False" __designer:wfdid="w50"></asp:Label> <asp:ImageButton id="imgcmt_save" onclick="imgcmt_save_Click" runat="server" ImageUrl="~/images/SavePack_2.gif" __designer:wfdid="w51"></asp:ImageButton><asp:ImageButton id="imgCmt_Close" runat="server" ImageUrl="~/images/ClosePack.gif" __designer:wfdid="w52"></asp:ImageButton>&nbsp;</TD></TR><TR><TD align=left colSpan=4><asp:Panel id="pnlW2" runat="server" Font-Bold="True" Width="30%" __designer:wfdid="w53" Height="22px" ToolTip="Click here to add comment"><asp:Image id="imgW" runat="server" ImageUrl="~/images/expandw.jpg" __designer:wfdid="w54"></asp:Image>&nbsp; Add comment</asp:Panel> </TD></TR><TR><TD colSpan=4><asp:UpdatePanel id="up_ur" runat="server" __designer:wfdid="w55"><ContentTemplate>
<asp:Panel id="pnl_ad_Cmt" runat="server" Width="99%" __designer:wfdid="w56"><TABLE id="tb_ad" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Stage:<cc1:CollapsiblePanelExtender id="cpeWaiting" runat="server" TargetControlID="pnl_ad_Cmt" __designer:wfdid="w57" SuppressPostBack="true" ImageControlID="imgW" ExpandedText="Hide Details..." ExpandedImage="../images/collapsew.jpg" ExpandControlID="pnlW2" CollapsedText="Show details..." CollapsedImage="../images/expandw.jpg" CollapseControlID="pnlW2" AutoCollapse="false">
                </cc1:CollapsiblePanelExtender> </TD><TD><asp:DropDownList id="ddlFor_Process" runat="server" Width="98%" CssClass="dropdown" __designer:wfdid="w58">
                                </asp:DropDownList></TD></TR><TR><TD vAlign=top>Comment:</TD><TD><asp:TextBox id="txtInt_Comnt" runat="server" Width="98%" CssClass="field" __designer:wfdid="w59" Height="87px" MaxLength="500" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 20%"></TD><TD style="WIDTH: 80%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
</asp:UpdatePanel> </TD></TR><TR><TD colSpan=4><asp:GridView id="gvIntComment" runat="server" CssClass="datagrid" __designer:wfdid="w60" AutoGenerateColumns="False">
                                    <RowStyle CssClass="gridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                                :
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="description" HeaderText="Comment">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="55%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="enteredby" HeaderText="Entered By">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="enteredon" HeaderText="Entered On">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="gridheader" />
                                    <AlternatingRowStyle CssClass="gridAlternate" />
                                </asp:GridView> </TD></TR><TR><TD colSpan=4></TD></TR><TR><TD width="25%"></TD><TD width="25%"></TD><TD width="25%"></TD><TD width="25%"></TD></TR></TBODY></TABLE></asp:Panel><BR />
<asp:GridView id="gvResult" runat="server" Width="98%" CssClass="datagrid" OnRowDataBound="gvResult_RowDataBound" OnSorting="gvResult_Sorting" DataKeyNames="prid,bookingid,testid,processid,procedureid,bookingdid" AutoGenerateColumns="False" AllowSorting="True" OnRowCommand="gvResult_RowCommand">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="S#"><ItemTemplate>
									<%#Container.DataItemIndex+1 %>:
								
</ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="labid" HeaderText="Lab ID" SortExpression="labid">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="patientname" HeaderText="Patient Name" SortExpression="patientname">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="test_name" HeaderText="Investigation" SortExpression="test_name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="bookedon" HeaderText="Booked On" SortExpression="bookedon">
<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="adm_info" HeaderText="Adm Info">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="origin" HeaderText="Origin">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
</asp:BoundField>
<asp:ButtonField CommandName="RE" Text="Result Entry">
<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
</asp:ButtonField>
<asp:ButtonField CommandName="RV" Text="Result Verification">
<ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
</asp:ButtonField>
<asp:CommandField SelectText="&lt;img src='../images/comment_add.png' border='0' /&gt;" ShowSelectButton="True">
<ItemStyle Width="3%"></ItemStyle>
</asp:CommandField>
</Columns>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> 
</ContentTemplate>
          </asp:UpdatePanel>
        </td>
        <td></td>
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
        <td width="10%"></td>
        <td width="20%"></td>
        <td width="10%"></td>
        <td width="20%"></td>
        <td width="10%"></td>
        <td width="20%"></td>
        <td width="5%"></td>
    </tr>
</table>

</asp:Content>
