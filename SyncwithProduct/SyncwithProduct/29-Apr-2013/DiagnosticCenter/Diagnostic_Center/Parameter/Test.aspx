<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/Test.aspx.cs" Inherits="Test" Title="Test Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>                 
            
            <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr>
                    <td align="center" colspan="8" class="tdheading">
                        Test Information</td>
                </tr>
                <tr>
                    <td align="left" class="tdheading" colspan="8">
                       
                        <cc1:CollapsiblePanelExtender AutoCollapse="false" ID="cpeWaiting" runat="server" CollapseControlID="pnlW2"
                             CollapsedImage="../images/expandw.jpg" CollapsedText="Show details..."
                            ExpandControlID="pnlW2" ExpandedImage="../images/collapsew.jpg" ExpandedText="Hide Details..."
                            ImageControlID="imgW" SuppressPostBack="true" TargetControlID="pnl_chg_gen">
                        </cc1:CollapsiblePanelExtender>
                          <asp:UpdatePanel id="up_prg" runat="server">
                   <ContentTemplate>
<asp:UpdateProgress id="upgress" runat="server" __designer:wfdid="w5" DisplayAfter="0"><ProgressTemplate>
<DIV class="UpdateProgress"><asp:Image id="Image1" runat="server" ImageUrl="../images/loading.gif" __designer:wfdid="w6"></asp:Image> ........Loading! Please Wait </DIV>
</ProgressTemplate>
</asp:UpdateProgress> 
</ContentTemplate>
          </asp:UpdatePanel> 
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="100%" TabIndex="32"></asp:Label></td>
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
                    <td align="right">
                        </td>
                    <td colspan="2">
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
                    <td align="right">
                        <asp:Button ID="lbtnSaveNext" runat="server" BackColor="SkyBlue" Font-Bold="True"
                            ForeColor="Navy" OnClick="lbtnSaveNext_Click" Text="Save & Next" Height="28px" Width="60%" TabIndex="18" Visible="False" />
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                            OnClick="imgReport_Click" /></td>
                    <td>
                                    <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="19" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" /><asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="20" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" /><asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" TabIndex="21" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" /></td>
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
                    <td>
                    </td>
                    <td colspan="6">
                       <asp:UpdatePanel id="Up_pnl_test" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:Panel id="pnlTestInfo" runat="server" Font-Bold="True" Width="99%" GroupingText="Test Info"><TABLE id="tb_testInfo" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD>Sub Department:</TD><TD class="mandatoryField"><asp:DropDownList id="ddlSubdepartment" tabIndex=1 runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlSubdepartment_SelectedIndexChanged" CssClass="dropdown">
                        </asp:DropDownList></TD><TD colSpan=4>&nbsp; <asp:CheckBox id="chkActive" runat="server" Text="Active" ToolTip="Check for remain Active throughout the application" Checked="True" TextAlign="Left"></asp:CheckBox><asp:CheckBox id="chkPrintGroup" runat="server" Text="Print Group" ToolTip="Check for remain Active throughout the application" TextAlign="Left"></asp:CheckBox><asp:CheckBox id="chkPrintTest" runat="server" Text="Print Test" ToolTip="Check for remain Activethroughout the application" TextAlign="Left"></asp:CheckBox><asp:CheckBox id="chkUrgent" runat="server" Text="Urgent" ToolTip="Check for remain Activethroughout the application" TextAlign="Left"></asp:CheckBox><asp:CheckBox id="chkSepReport" runat="server" Text="Sep Report" ToolTip="Check for remain Activethroughout the application" TextAlign="Left"></asp:CheckBox><asp:CheckBox id="chkExternal" runat="server" Text="External" AutoPostBack="True" TextAlign="Left" OnCheckedChanged="chkExternal_CheckedChanged"></asp:CheckBox> <asp:CheckBox id="chkProvisionRPT" runat="server" Text="Provision Report" TextAlign="Left"></asp:CheckBox></TD></TR><TR><TD>Group:</TD><TD><asp:DropDownList id="ddlGroup" tabIndex=2 runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" CssClass="dropdown">
                        </asp:DropDownList></TD><TD>Test Name:</TD><TD colSpan=3><asp:TextBox id="txtTest_Name" tabIndex=3 runat="server" Width="97%" ToolTip="Enter Test Name" CssClass="mandatoryField" MaxLength="200"></asp:TextBox></TD></TR><TR><TD>Acronym:</TD><TD><asp:TextBox id="txtAcronym" tabIndex=4 runat="server" Width="96%" ToolTip="Please Enter Acronym" CssClass="mandatoryField" MaxLength="10"></asp:TextBox></TD><TD>Procedure:</TD><TD class="mandatoryField"><asp:DropDownList id="ddlProcedure" tabIndex=6 runat="server" Width="100%" CssClass="dropdown">
                        </asp:DropDownList></TD><TD></TD><TD><asp:DropDownList id="ddlMethod" tabIndex=5 runat="server" Visible="False" Width="100%" CssClass="dropdown"></asp:DropDownList></TD></TR><TR><TD>Test Type:</TD><TD><asp:DropDownList id="ddlTestType" tabIndex=7 runat="server" Width="100%" CssClass="dropdown">
                            <asp:ListItem Selected="True" Value="G">General</asp:ListItem>
                            <asp:ListItem Value="H">Histopathalogy</asp:ListItem>
                            <asp:ListItem Value="M">Micro</asp:ListItem>
                            <asp:ListItem Value="R">Radialogy</asp:ListItem>
                        </asp:DropDownList></TD><TD>Speed Key:</TD><TD><asp:TextBox id="txtSpeedKey" tabIndex=8 runat="server" Width="38%" ToolTip="Enter Speed Key" CssClass="field" MaxLength="10"></asp:TextBox> </TD><TD>Dorder:</TD><TD><asp:TextBox id="txtDOrder" tabIndex=9 runat="server" Width="46%" ToolTip="Please Enter DOrder" CssClass="field" MaxLength="15"></asp:TextBox></TD></TR><TR><TD>Performing Location:</TD><TD class="mandatoryField"><asp:DropDownList id="ddlExternalOrg" runat="server" Width="100%" CssClass="dropdown">
                                        </asp:DropDownList></TD><TD>Report Format:</TD><TD><asp:DropDownList id="ddlRptFormat" runat="server" Width="65%" CssClass="dropdown">
                                            <asp:ListItem Value="1">One Column</asp:ListItem>
                                            <asp:ListItem Value="2">Two Column</asp:ListItem>
                                            <asp:ListItem Value="3">Three Column</asp:ListItem>
                                        </asp:DropDownList></TD><TD>Perform:</TD><TD><asp:DropDownList id="ddlPerform" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPerform_SelectedIndexChanged" CssClass="dropdown">
                                            <asp:ListItem Value="Daily">Daily</asp:ListItem>
                                            <asp:ListItem Value="Days">Days Wise</asp:ListItem>
                                            <asp:ListItem>Weekly</asp:ListItem>
                                        </asp:DropDownList></TD></TR><TR><TD></TD><TD></TD><TD></TD><TD colSpan=3><asp:GridView id="gvPerformOn" runat="server" CssClass="datagrid" AutoGenerateColumns="False">
                                            <RowStyle CssClass="gridItem" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="#">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>:
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mon">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk1" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tue">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk2" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Wed">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk3" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Thurs">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk4" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fri">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk5" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sat">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk6" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sun">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk7" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridheader" />
                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                        </asp:GridView> 
                                        </TD>

                                        </TR>
                                        <tr>
                                        <td>Instructions:</td>
                                        <td colspan="5">Before:
                                                                <asp:TextBox ID="txtinstructions_b" runat="server" CssClass="field" Width="45%" TextMode="MultiLine" ToolTip="Enter the Instructions to be followed by the patient before going through this test"></asp:TextBox>
                                                        After:
                                                                <asp:TextBox ID="txtinstructions_A" runat="server" CssClass="field" Width="45%" TextMode="MultiLine" ToolTip="Enter the Instructions to be followed by the patient After going through this test"></asp:TextBox>
                                        
                                            </td>
                                     
                                        </tr>
                                        <tr>
                                        <td>Time Type:</td>
                                        <td colspan="5">
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
						<asp:textbox id="txtMaxTime" runat="server" Width="20%" tabIndex="8" CssClass="mandatoryField" MaxLength="3"></asp:textbox>
				
                                        </td>
                                       
                                       </tr>
                                      
                                        <TR><TD width="11%"></TD>
                                        <TD width="23%"></TD>
                                        <TD width="12%"></TD>
                                        <TD width="23%"></TD>
                                        <TD width="7%"></TD>
                                        <TD width="24%"></TD>
                                        </TR>
                                        </TBODY>
                                        </TABLE></asp:Panel> 
</ContentTemplate>
                       <triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                       </triggers>
                      </asp:UpdatePanel>  
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="6">
                     <asp:UpdatePanel id="up_speci" runat="server" UpdateMode="Conditional"><ContentTemplate>
                        <asp:Panel ID="pnl_speci" runat="server" Width="99%" GroupingText="Specimen Info" Height="50px" Font-Bold="True">
                            <table id="tb_speci" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                                <tr>
                                    <td>
                                        Specimen/Film:</td>
                                    <td>
                        <asp:DropDownList ID="ddlSpecimen" runat="server"
                            Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecimen_SelectedIndexChanged" TabIndex="10" CssClass="dropdown">
                    </asp:DropDownList></td>
                                    <td>
                                        Container/Type:</td>
                                    <td>
                        <asp:DropDownList ID="ddlContainer" runat="server"
                            Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlContainer_SelectedIndexChanged" TabIndex="11" CssClass="dropdown">
                    </asp:DropDownList></td>
                                    <td>Quantity:</td>
                                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server" MaxLength="20" TabIndex="12" ToolTip="Please Enter Quantity"
                            Width="96%" CssClass="field"></asp:TextBox></td>
                            <td>
                                Unit:</td>
                            <td>
                                <asp:TextBox ID="txtUnit" runat="server" CssClass="field" MaxLength="10" Width="98%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td width="11%"></td>
                                    <td width="20%"></td>
                                    <td width="12%"></td>
                                    <td width="20%"></td>
                                    <td width="6%"></td>
                                    <td width="14%"></td>
                                    <td width="6%"></td>
                                    <td width="10%"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                       </ContentTemplate>
                        <triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                      </asp:UpdatePanel>  
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        </td>
                    <td></td>
                    <td>
                        </td>
                    <td></td>
                    <td>
                        </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        &nbsp;<asp:Panel ID="pnlW2" runat="server" Height="22px" Width="40%" ToolTip="Click here to see or hide General Information" >
                            <asp:Image ID="imgW" runat="server" ImageUrl="~/images/expandw.jpg" />&nbsp;
                            General Information:
                        </asp:Panel>
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
                    <td colspan="4" rowspan="2">
                        <asp:Panel ID="pnl_chg_gen" runat="server" Height="50px" Width="99%" GroupingText="Charges & General">
                            <asp:UpdatePanel id="pnlu" runat="server" UpdateMode="Conditional"><ContentTemplate>
                            <table id="tb_chrg_gen" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                                <tr>
                                    <td>
                                        Charges:</td>
                                    <td colspan="3">
                        <asp:TextBox ID="txtCharges" runat="server" MaxLength="6"
                            TabIndex="13" ToolTip="Enter Charges" Width="12%" CssClass="mandatoryField"></asp:TextBox>
                                        &nbsp;
                                        Urgent Charges:<asp:TextBox ID="txtChargesUrgent" runat="server" MaxLength="6" TabIndex="14" ToolTip="Please Enter Charges Urgent"
                            Width="12%" CssClass="field"></asp:TextBox>
                                        &nbsp; Charity Rate:<asp:TextBox ID="txtCharity" runat="server" CssClass="field"
                                            MaxLength="6" Width="12%"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>
                        Clinical Information:</td>
                                    <td colspan="3">
                        <asp:TextBox ID="txtClinicalUse" runat="server" CssClass="field" MaxLength="255" TabIndex="15"
                            Width="98%" ToolTip="Enter Clinical Use" TextMode="MultiLine" Height="43px"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>
                        Interpretation Text:</td>
                                    <td colspan="3">
                        <asp:TextBox ID="txtAutomatedText" runat="server" CssClass="field" MaxLength="1500" TabIndex="16"
                            Width="98%" ToolTip="Enter Automated Text" TextMode="MultiLine" Height="43px"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>
                        Age Applicable:</td>
                                    <td colspan="3">
                        <asp:GridView ID="gvAgeApp" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                            Width="60%" TabIndex="17">
                            <RowStyle CssClass="gridItem" />
                            <Columns>
                                <asp:BoundField DataField="gender" HeaderText="Gender">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Min Age">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMinAge" runat="server" CssClass="field" MaxLength="3" Width="60%"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Max Age">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMaxAge" runat="server" CssClass="field" MaxLength="3" Width="60%"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                </asp:TemplateField>                                
                            </Columns>
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                        </asp:GridView>
                    </td>
                                </tr>
                                 <tr>
                                    <td width="25%"></td>
                                    <td width="25%"></td>
                                    <td width="25%"></td>
                                    <td width="25%"></td>
                                </tr>
                            </table>
                             </ContentTemplate>
                              <triggers>
                                <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                              </triggers>
                             </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                    <td colspan="2" valign="top">
                     <asp:UpdatePanel id="up_meth" runat="server" UpdateMode="Conditional"><ContentTemplate>
                        <asp:Panel ID="pnlMehd" runat="server" Width="97%" Height="82px" ScrollBars="Auto" GroupingText="Method" >
                            <table id="tbMthd" width="100%" cellpadding="1" cellspacing="1" border="0" class="label">
                                <tr>                                   
                                    <td>
                                        </td>
                                </tr>
                                 <tr>                                    
                                    <td>
                                        <asp:GridView ID="gvMethod" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                            ShowHeader="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>:
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="name" HeaderText="Method Name" ShowHeader="False">
                                                    <ItemStyle HorizontalAlign="Left" Width="90%" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="gridItem" />
                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                 <tr>
                                    
                                    <td width="100%"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                       </ContentTemplate>
                        <triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                      </asp:UpdatePanel>  
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" valign="top">
                      <asp:UpdatePanel id ="up_gb" runat="Server" UpdateMode="Conditional"><ContentTemplate>
                        <asp:Panel ID="pnlGB" runat="server" Width="97%" Height="82px" ScrollBars="Auto" GroupingText="Group">
                            <table id="tbGB" border="0" cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    
                                    <td>
                                        </td>
                                </tr>
                                <tr>
                                    
                                    <td>
                                        <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                            ShowHeader="False">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>:
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="name" HeaderText="Group Name" ShowHeader="False">
                                                    <ItemStyle HorizontalAlign="Left" Width="90%" />
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="gridItem" />
                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td width="100%">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                       </ContentTemplate>
                        <triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                            <asp:AsyncPostBackTrigger ControlID="gvTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                      </asp:UpdatePanel>  
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
                    <td colspan="8" align="center" valign="top">
                      <asp:UpdatePanel id="up_grid" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:GridView id="gvTest" tabIndex=50 runat="server" Width="95%" 
ToolTip="View Test Information" OnSorting="gvTest_Sorting"
 OnRowEditing="gvTest_RowEditing" OnPageIndexChanging="gvTest_PageIndexChanging" OnRowCommand="gvTest_RowCommand" 
 DataKeyNames="TestId" CssClass="datagrid" AutoGenerateColumns="False" AllowSorting="True" >
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="subname" HeaderText="Sub-Dept" ReadOnly="True" SortExpression="subname">
                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Test_Name" HeaderText="Test Name" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="defaultmethod" HeaderText="Method">
                                    <ControlStyle Width="30%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GroupName" HeaderText="Group">
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Specimen_Name" HeaderText="Specimen">
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="charges" HeaderText="Charges">
                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="charityrate" HeaderText="Charity">
                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dorder" HeaderText="Dorder">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Active">
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                    <ControlStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <ControlStyle Width="10%" />
                                </asp:CommandField>
                                <asp:CommandField ShowSelectButton="true" SelectText="Edit" />
                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <SelectedRowStyle CssClass="gridSelectedItem" />
                            <PagerStyle HorizontalAlign="Left" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                        </asp:GridView> 
</ContentTemplate>
                          <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlSubdepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                       
                      </asp:UpdatePanel>  
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="8">
                        <asp:Label ID="lblstatus" runat="server" Visible="False" TabIndex="30"></asp:Label>&nbsp;
                        <asp:Label ID="lblTestId" runat="server" TabIndex="31" Visible="False"></asp:Label>
                        <asp:Label ID="lblGroupId" runat="server" TabIndex="31" Visible="False"></asp:Label>
                        <asp:Label ID="lblSubDepartmentId" runat="server" TabIndex="31" Visible="False"></asp:Label>
                        <asp:Label ID="lblPrev_SubID" runat="server"></asp:Label></td>
                </tr> 
                <tr>
                    <td width="3%"></td>
                    <td width="13%"></td>
                    <td width="20%"></td>
                    <td width="12%"></td>
                    <td width="17%"></td>
                    <td width="13%"></td>
                    <td width="20%"></td>
                    <td width="2%"></td>
                </tr>              
            </table>
           
       
</asp:Content>




