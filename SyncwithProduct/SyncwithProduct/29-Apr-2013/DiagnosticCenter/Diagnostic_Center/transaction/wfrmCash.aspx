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
            if (parseInt(textbox.value) > 50) {
               // alert('Please enter discount amount less than or equal to 50');
                if (textbox.value != "") {
                    z = parseInt(textbox.value);
                    total = parseInt(label.innerText) - z;
                    document.getElementById("<%=txtPaid.ClientID%>").value = Math.round(total);
                }
                else {
                    document.getElementById("<%=txtPaid.ClientID%>").value = label.innerText;
                }
               // alert(document.getElementById("<%=txtPaid.ClientID%>").value.toString());
               // document.getElementById("<%=txtPaid.ClientID%>").value = parseInt(document.getElementById("<%=txtPaid.ClientID%>").value) - 50;
            }
            else if (textbox.value != "") {
                z = parseInt(textbox.value);
                total = parseInt(label.innerText) - z;
                document.getElementById("<%=txtPaid.ClientID%>").value = Math.round(total);
            }
            else
                document.getElementById("<%=txtPaid.ClientID%>").value = label.innerText;

        }
        function ReturnDiscountAmount() {


            var totalbamount = document.getElementById('<%=lblRem.ClientID%>').innerText;

            var discpage = document.getElementById("<%=txtDiscount.ClientID%>").value;


            if (paseInt(discpage) > 50) {
                document.getElementById("<%=lbldiscountamt.ClientID%>").innerText = "Maximum Discount Offered Could be Rs 50 /-";
                //var receiveamt = Math.round((parseInt(totalbamount) - parseInt(discamt)));
                //  document.getElementById("<%=txtPaid.ClientID%>").value = receiveamt.toString();
            } else {
                var receiveamt = Math.round((parseInt(totalbamount) - parseInt(discpage)));
                document.getElementById("<%=txtPaid.ClientID%>").value = receiveamt.toString();
            }
        }


          


//-->

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <div style="min-height:40px; margin:auto; margin-bottom:10px; ">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table id="main" class="label" cellspacing="1" cellpadding="1" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td class="tdheading" align="center" colspan="8">
                            Cashier Queue
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="4">
                            <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Visible="false" ForeColor="DarkBlue"></asp:Label>
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
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="6">
                            <asp:Panel ID="pnl_search" runat="Server" Width="99%">
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
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="6">
                            <asp:Panel ID="pnl_info" runat="server" Width="99%" BorderWidth="1px">
                                <table id="tb_info" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblError_pnl" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
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
                                        <td>
                                            Discount:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDiscount" runat="server" onkeyup="GetValue()" CssClass="field"
                                                MaxLength="3" Width="35%"></asp:TextBox>
                                            &nbsp;<asp:Label ID="lbldiscountamt" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            Received:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaid" runat="server" ClientIDMode="Static" CssClass="field" Width="50%"></asp:TextBox>
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
                                    <tr>
                                        <td colspan="6">
                                            <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                                DataKeyNames="prid,bookingid,panelid,testid">
                                                <RowStyle CssClass="gridItem" />
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
                                                <AlternatingRowStyle CssClass="gridAlternate" />
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
                        <td>
                        </td>
                        <td colspan="6">
                            <asp:GridView ID="gvWaitQueue" runat="server" Width="99%" OnRowCommand="gvWaitQueue_RowCommand"
                                DataKeyNames="prid,bookingid,amount,authorizeno" CssClass="datagrid" AutoGenerateColumns="False">
                                <RowStyle CssClass="gridItem"></RowStyle>
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
                                <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
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
                        <td width="5%">
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgSave" />
        </Triggers>
    </asp:UpdatePanel>

    </div>
</asp:Content>
