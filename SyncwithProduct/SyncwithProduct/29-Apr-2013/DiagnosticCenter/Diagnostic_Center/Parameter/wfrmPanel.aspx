<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/wfrmPanel.aspx.cs" Inherits="panelc" Title="Panel Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
            <cc1:CollapsiblePanelExtender AutoCollapse="false" ID="cpeWaiting" runat="server" CollapseControlID="pnlW2"
                             CollapsedImage="../images/expandw.jpg" CollapsedText="Click here to view report format"
                            ExpandControlID="pnlW2" ExpandedImage="../images/collapsew.jpg" ExpandedText="Click here to close report format viewer"
                            ImageControlID="imgW" SuppressPostBack="true" TargetControlID="pnl_img" >
                        </cc1:CollapsiblePanelExtender>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                Panel Registration</td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblError" runat="server"></asp:Label></td>
            <td colspan="2">
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td></td>
            </tr>
            <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Organization:</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlOrganization" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged"
                    Width="50%">
                </asp:DropDownList></td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" /></td>
            <td colspan="2">
                <asp:CheckBox ID="chkAuthorize" runat="server" Text="Authorization Required" />&nbsp;<asp:CheckBox
                    ID="chkPrintAmt" runat="server" Text="Print Amount" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                Name:</td>
            <td colspan="3">
                <asp:TextBox ID="txtName" runat="server" CssClass="mandatoryField" MaxLength="100"
                    Width="98%"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="wt_name" runat="server" TargetControlID="txtName" WatermarkCssClass="waterlabel" WatermarkText="Trees Technologies"></cc1:TextBoxWatermarkExtender>
                    </td>
            <td>
                Aconym:</td>
            <td>
                <asp:TextBox ID="txtAcronym" runat="server" CssClass="field" MaxLength="10" Width="62%"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="wt_acro" runat="Server" TargetControlID="txtAcronym" WatermarkCssClass="waterlabel" WatermarkText="Trs"></cc1:TextBoxWatermarkExtender>
                <asp:CheckBox ID="chkCash" runat="server" Checked="false" Text="Cash"/>
                </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                Phone #:</td>
            <td>
                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="mandatoryField"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="wt_Phno" runat="server" WatermarkCssClass="waterlabel" TargetControlID="txtPhoneNo" WatermarkText="0515....."></cc1:TextBoxWatermarkExtender>
                </td>
            <td>
                Fax:</td>
            <td>
                <asp:TextBox ID="txtFax" runat="server" CssClass="field"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="wt_Fax" runat="server" TargetControlID="txtFax" WatermarkCssClass="waterlabel" WatermarkText="05154...."></cc1:TextBoxWatermarkExtender>
                </td>
            <td>
                Address:</td>
            <td colspan="2" rowspan="3">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="field" Height="66px" TextMode="MultiLine"
                    Width="96%"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="wt_Address" runat="server" TargetControlID="txtAddress" WatermarkCssClass="waterlabel" WatermarkText="Office # 45,clifton ..."></cc1:TextBoxWatermarkExtender>
                    </td>
        </tr>
        <tr>
            <td></td>
            <td>
                Discount:</td>
            <td>
                <asp:TextBox ID="txtDiscount" runat="server" CssClass="field"></asp:TextBox>
                (%)<cc1:TextBoxWatermarkExtender id="wt_Disc" runat="server" TargetControlID="txtDiscount" WatermarkCssClass="waterlabel" WatermarkText="5"></cc1:TextBoxWatermarkExtender>
                </td>
            <td>
                Reg Date:</td>
            <td colspan="2">
                <asp:TextBox ID="txtRegDate" runat="server" CssClass="field" Width="25%"></asp:TextBox>&nbsp;
                <asp:ImageButton ID="imgCal" runat="server" ImageUrl="~/images/btn_Blank.GIF" />
                Expiry Date:
                <asp:TextBox ID="txtExpiry" runat="server" CssClass="field" Width="23%"></asp:TextBox>&nbsp;
                <asp:ImageButton ID="imgExp" runat="server" ImageUrl="~/images/btn_Blank.GIF" />
                <cc1:CalendarExtender ID="ce_exp" runat="server" TargetControlID="txtExpiry" Format="dd/MM/yyyy" PopupButtonID="imgExp"></cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="msl_exp" runat="server" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99/99/9999" MaskType="date" TargetControlID="txtExpiry"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="msk_cal" runat="server" AutoComplete="false" ClearMaskOnLostFocus="false" Mask="99/99/9999" MaskType="date" TargetControlID="txtRegDate"></cc1:MaskedEditExtender>
                <cc1:CalendarExtender ID="ce_reg" runat="server" TargetControlID="txtRegDate" Format="dd/MM/yyyy" PopupButtonID="imgCal"></cc1:CalendarExtender>
                </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                Email:</td>
            <td colspan="2">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="field" MaxLength="30" Width="98%"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="wt_email" runat="Server" TargetControlID="txtEmail" WatermarkCssClass="waterlabel" WatermarkText="getToTrees@treesvalley.com"></cc1:TextBoxWatermarkExtender>
                </td>
            <td>
                <asp:DropDownList ID="ddlRptFmt" runat="server" AutoPostBack="True"
                    CssClass="dropdown" OnSelectedIndexChanged="ddlRptFmt_SelectedIndexChanged" Width="40%" Visible="False">
                    <asp:ListItem Value="-1">Select</asp:ListItem>
                    <asp:ListItem Value="1">Format 1</asp:ListItem>
                    <asp:ListItem Value="2">Format 2</asp:ListItem>
                    <asp:ListItem Value="3">Format 3</asp:ListItem>
                    <asp:ListItem Value="4">Format 4</asp:ListItem>
                    <asp:ListItem Value="5">Format 5</asp:ListItem>
                    <asp:ListItem Value="6">Format 6</asp:ListItem>
                    <asp:ListItem Value="7">Format 7</asp:ListItem>
                    <asp:ListItem Value="8">Format 8</asp:ListItem>
                </asp:DropDownList></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5"><asp:Panel ID="pnlW2" runat="server" Height="22px" Width="15%" ToolTip="Click here to view or hide report format" Visible="False" >
                            <asp:Image ID="imgW" runat="server" ImageUrl="~/images/expandw.jpg" />&nbsp;
                           Report Format:
                        </asp:Panel>
            <asp:Panel ID="pnl_img" runat="server"  Width="85%">
            <asp:UpdatePanel id="up_img" runat="server"><ContentTemplate>
<asp:Image id="imgFormat" runat="server" Visible="False" __designer:wfdid="w7"></asp:Image> 
</ContentTemplate></asp:UpdatePanel></asp:Panel>
            </td>
            <td colspan="2" rowspan="1">
                <asp:Label ID="lblPasword" runat="server" Visible="False"></asp:Label><asp:Label ID="lblID" runat="server" Visible="False"></asp:Label><asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td colspan="7">
                <asp:Panel ID="pnlCP" runat="server" GroupingText="Contact Person" Width="99%">
                    <table id="tb_CP" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
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
                            <td>
                                Name:</td>
                            <td>
                                <asp:TextBox ID="txtCP_Name" runat="server" CssClass="mandatoryField" MaxLength="50"
                                    Width="98%"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="wt_cpname" TargetControlID="txtCP_Name" runat="server" WatermarkCssClass="waterlabel" WatermarkText="Mr.ABC.."></cc1:TextBoxWatermarkExtender>
                                    </td>
                            <td>
                                Designation:</td>
                            <td>
                                <asp:TextBox ID="txtCP_Desig" runat="server" CssClass="field" MaxLength="25" Width="98%"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="wt_CPDEsig" runat="server" TargetControlID="txtCP_Desig" WatermarkCssClass="waterlabel" WatermarkText="PRO"></cc1:TextBoxWatermarkExtender>
                                </td>
                            <td>
                                Contact #:</td>
                            <td>
                                <asp:TextBox ID="txtCP_Contact" runat="server" CssClass="field" MaxLength="20" Width="98%"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="wt_CPContact" runat="server" TargetControlID="txtCP_Contact" WatermarkCssClass="waterlabel" WatermarkText="05154...."></cc1:TextBoxWatermarkExtender>
                                </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                Email:</td>
                            <td>
                                <asp:TextBox ID="txtCP_Email" runat="server" CssClass="field" MaxLength="30" Width="98%"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="wt_CPEmail" runat="server" TargetControlID="txtCP_Email" WatermarkCssClass="waterlabel" WatermarkText="abc@xyz.com"></cc1:TextBoxWatermarkExtender>
                                </td>
                            <td>
                                Login:</td>
                            <td>
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="mandatoryField" MaxLength="10"
                                    Width="50%"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="wt_log" runat="server" TargetControlID="txtLogin" WatermarkCssClass="waterlabel" WatermarkText="trees_"></cc1:TextBoxWatermarkExtender>
                                    </td>
                            <td>
                                Pasword:</td>
                            <td>
                                <asp:TextBox ID="txtPasword" runat="server" CssClass="mandatoryField" MaxLength="10"
                                    TextMode="Password" Width="50%"></asp:TextBox></td>
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
                            <td width="1%"></td>
                            <td width="5%"></td>
                            <td width="30%"></td>
                            <td width="8%"></td>
                            <td width="25%"></td>
                            <td width="8%"></td>
                            <td width="22%"></td>
                            <td width="1%"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
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
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="6">
                <asp:GridView ID="gvPanel" runat="server" Width="98%" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="panelid,address,email,fax,reg_date,cp_designation,cp_contactno,cp_email,login,pasword,authorization_required,rpt_format,clientid,print_amount,cashPanel" OnRowCommand="gvPanel_RowCommand">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="Name" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="acronym" HeaderText="Acronym" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="phoneno" HeaderText="Phone #" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="discount" HeaderText="Discount" >
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="reg_date" HeaderText="Reg Date" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="exp_date" HeaderText="Exp Date">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="contact_person" HeaderText="Contact Person" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGVActive" runat="server" Enabled="False" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" >
                            <ItemStyle Width="5%" />
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
            <td>
            </td>
            <td>
            </td>
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

