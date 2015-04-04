<%@ Page Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true"
    CodeFile="~/transaction/wfrmCash.aspx.cs" Inherits="lab_cash" Title="Cashier Queue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">

<!--

        function GetValue() {

            var label = document.getElementById("<%=lblRem.ClientID%>");
            var textbox = document.getElementById("<%=txtDiscount.ClientID%>");
            var z;
            var total;
            if (label.innerText == null) {
                label.innerText = "0";
            }
            if (parseInt(textbox.value) > 100) {
                alert('Please enter discount percentage less than or equal to 100');
            }
            else if (textbox.value != "") {
                z = (parseInt(textbox.value) * parseInt(label.innerText)) / (100);
                total = parseInt(label.innerText) - z;
                document.getElementById("<%=txtPaid.ClientID%>").innerText = Math.round(total);
            }
            else
                document.getElementById("<%=txtPaid.ClientID%>").innerText = label.innerText;

        }

//-->

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="tboxhead" style="text-align: center; width: 100%; padding-top: 10px;">
                Cashier Queue</div>
            <table id="main" class="label" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td>
                        </td>
                        <td colspan="4">
                            <asp:Label ID="lblTotal" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                            <cc1:CalendarExtender ID="cal_date" runat="server" TargetControlID="txtCal" PopupButtonID="imgCal"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <cc1:MaskedEditExtender ID="mask_cal" runat="server" TargetControlID="txtCal" Mask="99/99/9999"
                                ClearMaskOnLostFocus="false" AutoComplete="false">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditExtender ID="mask_prno" runat="server" TargetControlID="txtPrno" Mask="999-99-99999999"
                                ClearMaskOnLostFocus="false" AutoComplete="false">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="cal_date2" runat="Server" TargetControlID="txtCal_To" PopupButtonID="imgCal_To"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <cc1:MaskedEditExtender ID="mask_cal_To" runat="server" TargetControlID="txtCal_To"
                                Mask="99/99/9999" ClearMaskOnLostFocus="false" AutoComplete="false">
                            </cc1:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="6">
                            <asp:Panel ID="pnl_search" Visible="false" runat="Server" Width="99%">
                                <table id="tb_search" class="label" cellspacing="1" cellpadding="1" width="100%"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblCount" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:ImageButton ID="imgSearch" OnClick="imgSearch_Click" runat="server" ImageUrl="~/images/Search_OT.gif">
                                                </asp:ImageButton><asp:ImageButton ID="imgClear" OnClick="imgClear_Click" runat="server"
                                                    ImageUrl="~/images/ClearPack.gif"></asp:ImageButton><asp:ImageButton ID="imgClose"
                                                        OnClick="imgClose_Click" runat="server" ImageUrl="~/images/ClosePack.gif">
                                                </asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                PR No:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPrNo" runat="server" Width="55%" CssClass="field"></asp:TextBox>
                                            </td>
                                            <td>
                                                Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName" runat="server" Width="97%" CssClass="field"></asp:TextBox>
                                            </td>
                                            <td>
                                                From Date:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCal" runat="server" Width="55%" CssClass="field"></asp:TextBox>
                                                <asp:ImageButton ID="imgCal" runat="server" ImageUrl="~/images/btn_Blank.GIF"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBranch" runat="server" Visible="False" Width="99%" CssClass="dropdown"
                                                    OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rdbPay_Mode" runat="server" OnSelectedIndexChanged="rdbPay_Mode_SelectedIndexChanged"
                                                    __designer:wfdid="w1" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                    <asp:ListItem Value="C">Cash</asp:ListItem>
                                                    <asp:ListItem Value="P">Panel</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                To Date:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCal_To" runat="server" Width="55%" CssClass="field"></asp:TextBox>&nbsp;<asp:ImageButton
                                                    ID="imgCal_To" runat="server" ImageUrl="~/images/btn_Blank.GIF"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                            </td>
                                            <td width="23%">
                                            </td>
                                            <td width="10%">
                                            </td>
                                            <td width="23%">
                                            </td>
                                            <td width="10%">
                                            </td>
                                            <td width="23%">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="6">
                            <asp:Panel ID="pnl_info" runat="server" Width="99%" >
                                <table id="tb_info" cellpadding="1" cellspacing="1" style="border-radius:5px; border:1px solid #CCCCCC;" width="100%" class="label">
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblError_pnl" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="imgSave_Click" /><asp:ImageButton
                                                ID="imgClosePnl" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClosePnl_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            PR No:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPRno" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                        <td>
                                            Name:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                        <td>
                                            LabID:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLabID" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Total:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTOtalAmt" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                        <td style=" display:none;">
                                            Discount:
                                        </td>
                                        <td style=" display:none;">
                                            <asp:TextBox ID="txtDiscount" runat="server" onkeyup="GetValue()" CssClass="field"
                                                MaxLength="3" Width="35%"></asp:TextBox>
                                        </td>
                                        <td>
                                            Received:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaid" runat="server" CssClass="field" Width="50%"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="flt_pad" runat="server" FilterType="Numbers" TargetControlID="txtPaid">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Balance:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRem" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdbMode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                <asp:ListItem Value="C">Cash</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                   </table>
                                   <br />
                                  <table width="100%" style="border-radius:5px; border:1px solid #CCCCCC;">
                                   <tr>
                                        <td align="right">Cheque No:</td>
                                        <td><asp:TextBox ID="TxBx_Chk_No" runat="server" Text=""></asp:TextBox></td>
                                        <td align="right">Cheque Date:</td>
                                        <td>
                                            <asp:TextBox ID="TxBx_ChQDate" runat="server" Text=""></asp:TextBox>
                                        </td>
                                        <td align="right">Bank:</td>
                                        <td><asp:TextBox ID="TxBx_Bank" runat="server" Text=""></asp:TextBox></td>
                                   </tr>
                                   </table>
                                   <br />
                                  <table width="100%" style="border-radius:5px; border:1px solid #CCCCCC;">
                                   <tr style="border-top:1px; border-top-color:#BBBBBB;">
                                        <td align="right">Card No:</td>
                                        <td><asp:TextBox ID="TxBx_Debit" runat="server" Text=""></asp:TextBox></td>
                                      
                                        <td align="right">Receipt No:</td>
                                        <td>
                                            <asp:TextBox ID="TxBx_ReceiptNo" runat="server" Text=""></asp:TextBox>
                                        </td>
                                   </tr>
                                   </table>
                                   <br />
                                   <table width="100%" style="border-radius:5px; border:1px solid #CCCCCC;">
                                    <tr>
                                        <td colspan="6">
                                            <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" CssClass="listing"
                                                DataKeyNames="prid,bookingid,panelid,testid">
                                                <RowStyle CssClass="Row" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="testname" HeaderText="Test">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="totalamount" HeaderText="Amount">
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" Width="25%" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <HeaderStyle CssClass="gridheader" />
                                                <AlternatingRowStyle CssClass="AltRow" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                        </td>
                                        <td width="23%">
                                        </td>
                                        <td width="10%">
                                        </td>
                                        <td width="23%">
                                        </td>
                                        <td width="10%">
                                        </td>
                                        <td width="23%">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
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
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="6">
                            <asp:GridView ID="gvWaitQueue" runat="server" Width="99%" OnRowCommand="gvWaitQueue_RowCommand"
                                DataKeyNames="prid,bookingid,amount,authorizeno" CssClass="listing" AutoGenerateColumns="False">
                                <RowStyle CssClass="Row"></RowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="labid" HeaderText="LAB ID">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="prno" HeaderText="PR No">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="name" HeaderText="Patient">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="totalamount" HeaderText="Total Amount">
                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="bookingdate" HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="adm_info" HeaderText="Adm Info">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="origin" HeaderText="Origin">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle Width="5%"></ItemStyle>
                                    </asp:CommandField>
                                </Columns>
                                <HeaderStyle CssClass="gridheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="AltRow"></AlternatingRowStyle>
                            </asp:GridView>
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
                    </tr>
                    <tr>
                        <td width="5%">
                        </td>
                        <td width="10%">
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
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
