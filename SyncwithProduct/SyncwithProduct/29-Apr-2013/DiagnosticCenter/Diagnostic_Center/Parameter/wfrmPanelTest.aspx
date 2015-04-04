<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmPanelTest.aspx.cs" Inherits="paneltest" Title="Panel Test Reg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<asp:ScriptManager ID="scrp" runat="server" ></asp:ScriptManager>--%>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
 <script type="text/javascript">
     function SetPanelTage(textbox) {
         var headerval = textbox.value;
         $('#<%=gvPanelTest.ClientID%> tr').each(function () {

             $(this).find('input[type=text][id*=IndtxtPanelPage]').val(headerval);

         });


     }
 
 </script>

    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="6">
                <asp:ScriptManager id="ScriptManager1" runat="server" AsyncPostBackTimeout="90">
                </asp:ScriptManager>
                Panel Test Registration</td>
        </tr>
         <tr>
            <td class="screenid" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
            <asp:UpdatePanel id="up_er" runat="server"><ContentTemplate>
<asp:Label id="lblError" runat="server" __designer:wfdid="w7"></asp:Label> 
</ContentTemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="imgSave" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubDept" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlPanel" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
             </asp:UpdatePanel>   
                </td>
            <td>
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;
                <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif"
                    OnClick="imgReport_Click" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td class="screenid" colspan="6">&nbsp;</td>
        </tr>
        <tr>
            <td class="screenid" colspan="6">
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                Organization:</td>
            <td>
                <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged"
                    Width="50%">
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label><asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Visible="False">
                </asp:DropDownList></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                Panel:</td>
            <td class="mandatoryField">
                <asp:DropDownList ID="ddlPanel" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlPanel_SelectedIndexChanged">
                </asp:DropDownList>
                <cc1:ListSearchExtender ID="lsepanel" runat="server" TargetControlID="ddlPanel"></cc1:ListSearchExtender>
                </td>
            <td align="right">
                Department:&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                    Width="100%">
                </asp:DropDownList></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                Sub-Department:</td>
            <td>
                <asp:UpdatePanel id="up_sub" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
<asp:DropDownList id="ddlSubDept" runat="server" OnSelectedIndexChanged="ddlSubDept_SelectedIndexChanged" AutoPostBack="True" Width="100%" __designer:wfdid="w8">
                </asp:DropDownList> 
</ContentTemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                </td>
            <td align="right">
                Group:&nbsp;
            </td>
            <td><asp:UpdatePanel id="up_grp" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
<asp:DropDownList id="ddlGroup" runat="server" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" AutoPostBack="True" Width="100%" __designer:wfdid="w1">
                </asp:DropDownList> 
</ContentTemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubDept" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                </td>
            <td></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Discount:</td>
            <td>
                <asp:TextBox ID="txtDiscount" runat="server" CssClass="field" MaxLength="3" Width="15%"></asp:TextBox>
                <cc1:FilteredTextBoxExtender id="flt_rate_dic" runat="server" FilterType="numbers" TargetControlID="txtDiscount"></cc1:FilteredTextBoxExtender>
                <asp:Button ID="btnProgress" runat="server" BackColor="SkyBlue" Font-Bold="True"
                    ForeColor="Navy" OnClick="btnProgress_Click" Text="Process" Width="69px" /></td>
            <td align="left"> <asp:UpdatePanel id="pnl_sel" runat="server"><ContentTemplate>
                <asp:RadioButton ID="rdbTest" runat="server" AutoPostBack="True" OnCheckedChanged="rdbTest_CheckedChanged"
                    Text="Investigation" GroupName="sel" />
                <asp:RadioButton ID="rdbGroup" runat="server" AutoPostBack="True" OnCheckedChanged="rdbGroup_CheckedChanged"
                    Text="Group" GroupName="sel" />
                    </ContentTemplate></asp:UpdatePanel>
                    </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td class="tdheading" align="left">
            <asp:UpdatePanel id="up_prg" runat="server"><ContentTemplate>
<asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:wfdid="w5"><ProgressTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="../images/loading.gif" __designer:wfdid="w6"></asp:Image> ........Loading! Please Wait 
</ProgressTemplate>
</asp:UpdateProgress> 
</ContentTemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlSubDept" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgSave" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnProgress" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbGroup" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbTest" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</triggers>
            </asp:UpdatePanel>
            
                </td>
            <td></td>
            <td>
                <asp:DropDownList ID="ddlTest" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged" Visible="False">
                </asp:DropDownList></td>
            <td>
            </td>
        </tr>
         <tr>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <asp:Label ID="lblPrice" runat="server" ForeColor="DarkBlue" Visible="False"></asp:Label></td>
            <td>&nbsp; &nbsp;</td>
            <td></td>
        </tr>
         <tr>
            <td class="screenid" colspan="6">&nbsp;</td>
       
        </tr>
         <tr>
            <td colspan="6" >
            <asp:UpdatePanel ID="up_grid" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:GridView id="gvPanelTest" runat="server" Width="98%" CssClass="datagrid" 
                    DataKeyNames="panelid,testid" AutoGenerateColumns="False" designer:wfdid="w6" 
                    OnRowDataBound="gvPanelTest_RowDataBound" 
                    onselectedindexchanged="gvPanelTest_SelectedIndexChanged">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="S#"><ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                            
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="department" HeaderText="Department">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="subdepartment" HeaderText="SubDeparmtent">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
    <asp:TemplateField HeaderText="Test Info">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" ToolTip="Name" Text='<%# Bind("test_name") %>'></asp:Label>
            <br />
            <asp:Label ID="lblSpeedkey" runat="server" ToolTip="Speed Key" Text='<%# Bind("speedkey")%>'></asp:Label>
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Left" Width="25%" />
    </asp:TemplateField>
<asp:BoundField DataField="testcharges" HeaderText="Normal Charges">
<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="9%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="testurgentcharges" HeaderText="Urgent Charges" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="Panel Charges"><ItemTemplate>
<asp:TextBox id="txtRate" runat="server" Width="88%" __designer:wfdid="w1" CssClass="field" MaxLength="6"></asp:TextBox> <cc1:FilteredTextBoxExtender id="flt_rate" runat="server" __designer:wfdid="w2" TargetControlID="txtRate" FilterType="Numbers"></cc1:FilteredTextBoxExtender> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Urgent Charges" Visible="False"><ItemTemplate>
                <asp:TextBox ID="txturgent" runat="server" CssClass="field" Width="88%"></asp:TextBox>
                            
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Discount %age" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate>
    <asp:TextBox ID="txtdiscpercent" runat="server" CssClass="field"></asp:TextBox>
</ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle Width="10%" />
</asp:TemplateField> 
<asp:TemplateField HeaderText="Panel Test Code" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left">
<ItemTemplate>
    <asp:TextBox ID="txtPanelTestCode" runat="server" CssClass="field"></asp:TextBox>
</ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle Width="10%" />
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width="10%" HeaderText="Test %age" HeaderStyle-HorizontalAlign="Left">
<HeaderTemplate>
 <asp:TextBox ID="txtPanelPage" runat="server" onkeyup="javascript:SetPanelTage(this);" CssClass="field"></asp:TextBox>
 <cc1:FilteredTextBoxExtender ID="FF2" TargetControlID="txtPanelPage" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
 <cc1:TextBoxWatermarkExtender id="wt_cel" watermarkText="Panel Share %age" runat="Server" 
                   TargetControlID="txtPanelPage" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender>
</HeaderTemplate>
<ItemTemplate>
    <asp:TextBox ID="IndtxtPanelPage" runat="server" Text='<%# Eval("PanelSharePercent") %>' CssClass="field"></asp:TextBox>
<cc1:FilteredTextBoxExtender ID="FF1" TargetControlID="IndtxtPanelPage" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>

</ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle Width="10%" />
</asp:TemplateField>

</Columns>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> 
</ContentTemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubDept" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlPanel" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnProgress" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbGroup" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbTest" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="6">
            <asp:UpdatePanel id="up_gp" runat="server" UpdateMode="Conditional"><ContentTemplate>
<asp:GridView id="gvPanelGroup" runat="server" Width="98%" CssClass="datagrid" DataKeyNames="groupid,testid" AutoGenerateColumns="False" __designer:wfdid="w7">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="groupname" HeaderText="Group">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="test_name" HeaderText="Investigation">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="test_charges" HeaderText="Normal Charges">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="group_charges" HeaderText="Group Charges">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="12%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Panel Charges">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="12%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtPnlCharges" runat="server" CssClass="field" Width="50%" MaxLength="6"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="flt_pnlG" FilterType="numbers" runat="server" TargetControlID="txtPnlCharges"></cc1:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView> 
</ContentTemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlGroup" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlPanel" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btnProgress" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbGroup" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbTest" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
               </asp:UpdatePanel> 
            </td>
        </tr>
        <tr>
            <td class="screenid" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="screenid" colspan="6">
                &nbsp;</td>
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
            <td width="5%"></td>
            <td width="12%"></td>
            <td width="33%"></td>
            <td width="13%"></td>            
            <td width="32%"></td>
            <td width="5%"></td>
        </tr>
    </table>                      
</asp:Content>

