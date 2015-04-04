<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/transaction/wfrmGeneral.aspx.cs" Inherits="general_trans" Title="General" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table id="main" cellpadding="1" cellspacing="1" border="0" class="label" width="100%">
    <tr>
        <td align="center" class="tdheading" colspan="8">
            General Info</td>
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
        <td colspan="2">
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
        <td></td>
        <td></td>
         <td colspan="2">
             <asp:RadioButtonList ID="rdbOption" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdbOption_SelectedIndexChanged"
                 RepeatDirection="Horizontal" RepeatLayout="Flow">
                 <asp:ListItem Value="P">Panel Section</asp:ListItem>
                 <asp:ListItem Value="C">Cash Section</asp:ListItem>
                 <asp:ListItem Value="D">Change Consultant</asp:ListItem>
             </asp:RadioButtonList></td>
        <td>
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager></td>
        <td></td>
        <td>
            <cc1:MaskedEditExtender id="msk_prno" runat="server" TargetControlID="txtPRnO" Mask="999-99-99999999" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender> 
        <cc1:FilteredTextBoxExtender ID="flt_name" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txtName"></cc1:FilteredTextBoxExtender>
            &nbsp;
            <cc1:CalendarExtender ID="cal_frm" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFrom"
                TargetControlID="txtFrom">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="cal_to" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtTo"
                TargetControlID="txtTo">
            </cc1:CalendarExtender>
            <cc1:MaskedEditExtender ID="msk_Frmcal" runat="server" Mask="99/99/9999" MaskType="date"
                TargetControlID="txtFrom">
            </cc1:MaskedEditExtender>
            <cc1:MaskedEditExtender ID="msk_Tocal" runat="server" Mask="99/99/9999" MaskType="date"
                TargetControlID="txtTo">
            </cc1:MaskedEditExtender>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td colspan="3">
                            <asp:RadioButtonList ID="rdbPanelOption" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rdbPanelOption_SelectedIndexChanged">
                                <asp:ListItem>Authorize No</asp:ListItem>
                            </asp:RadioButtonList>&nbsp;<asp:RadioButtonList ID="rdbCashoption" runat="server"
                                RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rdbCashoption_SelectedIndexChanged">
                                <asp:ListItem Value="C">Received</asp:ListItem>
                                <asp:ListItem Value="R">Refund</asp:ListItem>
                            </asp:RadioButtonList></td>
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
            <asp:Panel ID="pnlSearch" runat="server" GroupingText="Search" Height="100px" Width="99%">
                <table id="tb_search" runat="server" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                         <td></td>
                        <td></td>
                        <td colspan="2">
                            <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search.gif" OnClick="imgSearch_Click" /><asp:ImageButton
                                ID="imgCLose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgCLose_Click" /></td>
                        <td align="center">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            PR No:</td>
                        <td>
                            <asp:TextBox ID="txtPrNo" runat="server" CssClass="field" Width="80%"></asp:TextBox></td>
                        <td>
                            Name:</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtName" runat="server" CssClass="field" Width="89%"></asp:TextBox></td>
                        <td>
                            From Date:</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtFrom" runat="server" CssClass="field" Width="55%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblComp_head" runat="server"></asp:Label></td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlPanel" runat="server" CssClass="dropdown" Width="80%">
                            </asp:DropDownList></td>
                        <td></td>
                        <td>
                            To Date:</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtTo" runat="server" CssClass="field" Width="55%"></asp:TextBox></td>
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
                        <td width="10%"></td>
                        <td width="20%"></td>
                        <td width="10%"></td>
                        <td width="20%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                         
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td colspan="6">
            <asp:Panel ID="pnlPanel" runat="server" GroupingText="Panel" Height="130px" Width="99%">
                <table id="tb_panel" cellpadding="1" cellspacing="1" border="0" class="label" width="100%">
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblP_Error" runat="server"></asp:Label></td>
                        <td colspan="2">
                            <asp:ImageButton ID="imgp_save" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgp_save_Click" /><asp:ImageButton
                                ID="imgp_Close" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgp_Close_Click" /></td>
                    </tr>
                    <tr>
                        <td>
                            PR No:</td>
                        <td>
                            <asp:Label ID="lblP_prno" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                        <td>
                            Patient:</td>
                        <td>
                            <asp:Label ID="lblP_Patient" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                        <td>
                            Lab ID:</td>
                        <td>
                            <asp:Label ID="lblP_LabID" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            Date:</td>
                        <td>
                            <asp:Label ID="lblp_Date" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                        <td>
                            Panel:</td>
                        <td colspan="2">
                            <asp:Label ID="lblp_Company" runat="server" ForeColor="DarkBlue"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblp_bookingID" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            Authorize No:</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtp_Auth" runat="server" CssClass="mandatoryField" Width="98%"></asp:TextBox></td>
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
                        <td width="10%"></td>
                        <td width="15%"></td>
                        <td width="10%"></td>
                        <td width="25%"></td>
                        <td width="10%"></td>
                        <td width="20%"></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td colspan="6">
            <asp:Label ID="lblCount" runat="server" ForeColor="DarkBlue"></asp:Label></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td colspan="6">
            <asp:GridView ID="gvAuthorize" runat="server" AutoGenerateColumns="False" CssClass="datagrid" Width="100%" OnRowCommand="gvAuthorize_RowCommand" DataKeyNames="bookingid">
                <RowStyle CssClass="gridItem" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>:
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Labid" HeaderText="Lab ID" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="prno" HeaderText="PR No" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="patientname" HeaderText="Patient" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="bookingdate" HeaderText="Date" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="panelname" HeaderText="Company" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="origin" HeaderText="Origin">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="adm_info" HeaderText="Adm Info">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <HeaderStyle CssClass="gridheader" />
                <AlternatingRowStyle CssClass="gridAlternate" />
            </asp:GridView>
        </td>
        <td>
        </td>
    </tr>
     <tr>
        <td></td>
        <td colspan="6">
            <asp:GridView ID="gvCash" runat="server" AutoGenerateColumns="False" 
                CssClass="datagrid" DataKeyNames="type,labid,prno" 
                OnRowCommand="gvCash_RowCommand" onrowdatabound="gvCash_RowDataBound">
                <RowStyle CssClass="gridItem" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        <ItemTemplate>
                           <%#Container.DataItemIndex+1 %>:
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="receiptno" HeaderText="Receipt #">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="prno" HeaderText="PR No">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="patientname" HeaderText="Patient">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="paidamount" HeaderText="Amount">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="receiptdate" HeaderText="Date">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="adm_info" HeaderText="Adm Info">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="origin" HeaderText="Origin">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </asp:BoundField>
                    <asp:CommandField NewText="Print" SelectText="Print" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:CommandField>

 <asp:TemplateField>
    <ItemTemplate>
        <asp:HyperLink  ID="Hyper_Pay"  runat="server">
            <asp:Image ID="Img_print" ToolTip="Report is ready" Visible="true" ImageUrl="headerfooter/pdf.png" runat="server" />
        </asp:HyperLink>

        <asp:Image ID="Img_cprint" ToolTip="Report is not ready yet" Visible="false" ImageUrl="headerfooter/cpdf.png" runat="server" />
        
    </ItemTemplate>
</asp:TemplateField>

                </Columns>
                <HeaderStyle CssClass="gridheader" />
                <AlternatingRowStyle CssClass="gridAlternate" />
            </asp:GridView>
        </td>
        <td></td>
    </tr>
    <tr>
        <td>
        </td>
        <td colspan="6"><asp:GridView ID="gvConsult" runat="server" AutoGenerateColumns="False" CssClass="datagrid" Width="100%" OnRowCommand="gvConsult_RowCommand" DataKeyNames="bookingid,doctorid" OnRowDataBound="gvConsult_RowDataBound">
            <RowStyle CssClass="gridItem" />
            <Columns>
                <asp:TemplateField HeaderText="S#">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                        :
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
                <asp:BoundField DataField="Labid" HeaderText="Lab ID" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="11%" />
                </asp:BoundField>
                <asp:BoundField DataField="prno" HeaderText="PR No" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="11%" />
                </asp:BoundField>
                <asp:BoundField DataField="patientname" HeaderText="Patient" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="bookingdate" HeaderText="Date" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="8%" />
                </asp:BoundField>
              
                <asp:BoundField DataField="origin" HeaderText="Origin">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                </asp:BoundField>
                <asp:BoundField DataField="adm_info" HeaderText="Adm Info">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ref.Doctor">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlConslt" runat="server" Width="99%" >
                        </asp:DropDownList>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ref.Doctor">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRefDoctor" Font-Size="Small" runat="server"  Width="99%" Text='<%# DataBinder.Eval(Container.DataItem,"referredby").ToString() %>'></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="14%" />
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" SelectText="Update" >
                    <ItemStyle Width="3%" />
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

