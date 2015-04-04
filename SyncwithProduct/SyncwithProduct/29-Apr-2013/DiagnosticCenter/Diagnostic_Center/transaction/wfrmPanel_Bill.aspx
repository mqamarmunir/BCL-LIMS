<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/transaction/wfrmPanel_Bill.aspx.cs" Inherits="panelbill" Title="Panel Bill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript">
function onCalendarShown() {
    var cal = $find("cal_month");     //Setting the default mode to month    
    cal._switchMode("months", true);          //Iterate every month Item and attach click event to it    
    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
            }
        }
    }
}

function onCalendarHidden() {
    var cal = $find("cal_month");
    //Iterate every month Item and remove click event from it
    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
            }
        }
    }
}

function call(eventElement) {
    var target = eventElement.target;
    switch (target.mode) {
        case "month":
            var cal = $find("cal_month");
            cal._visibleDate = target.date;
            cal.set_selectedDate(target.date);
            cal._switchMonth(target.date);
            cal._blur.post(true);
            cal.raiseDateSelectionChanged();
            break;
    }
}  
  </script>
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="8">
                Panel Bill</td>
        </tr>
            <tr>
            <td></td>
            <td></td>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:CalendarExtender ID="cal_from" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFrom"
                    TargetControlID="txtFrom">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="cal_to" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtTo"
                    TargetControlID="txtTo">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="cal_month" runat="server" Format="MMMM,yyyy" PopupButtonID="txtBill_Month"
                TargetControlID="txtBill_Month"  OnClientHidden="onCalendarHidden" 
                OnClientShown="onCalendarShown" BehaviorID="cal_month"></cc1:CalendarExtender>
                <cc1:CalendarExtender ID="cal_b_date" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtBill_Date"
                 TargetControlID="txtBill_Date"></cc1:CalendarExtender>
                 <cc1:CalendarExtender ID="cal_aut_date" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtAuthorize_Date"
                  TargetControlID="txtAuthorize_Date"></cc1:CalendarExtender>
                  <cc1:FilteredTextBoxExtender ID="flt_dis" runat="server" FilterType="numbers" TargetControlID="txtDiscount"></cc1:FilteredTextBoxExtender>
                  
            </td>
            <td></td>
            <td></td>
            <td colspan="2">
                <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif"
                    OnClick="imgSearch_Click" /><asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack.gif" OnClick="imgSave_Click" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
            <tr>
            <td></td>
            <td>
                </td>
                <td colspan="2">
                    </td>
                <td colspan="2">
                </td>
            <td>
                </td>
            <td></td>
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
            <td >
                </td>
            <td>
                <asp:Label ID="lblBillID" runat="server" Visible="False"></asp:Label></td>
            <td>
                </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="6">
            <asp:Panel ID="pnl_bn" runat="server" Width="99%" GroupingText=" ">
             <table id="tb_bN" border="0" cellpadding="1" cellspacing="1" class="label" width="99%">
                <tr>
                    <td>
                Panel:</td>
                    <td>
                    <asp:DropDownList ID="ddlPanel" runat="server" CssClass="dropdown" Width="99%" AutoPostBack="True" OnSelectedIndexChanged="ddlPanel_SelectedIndexChanged">
                    </asp:DropDownList></td>
                    <td align="right">
                From:</td>
                    <td>
                <asp:TextBox ID="txtFrom" runat="server" CssClass="field" Width="98%"></asp:TextBox></td>
                    <td align="right">
                To:</td>
                    <td>
                <asp:TextBox ID="txtTo" runat="server" CssClass="field" Width="98%"></asp:TextBox></td>
                <td>
                    Discount:
                    <asp:TextBox ID="txtDiscount" runat="server" CssClass="field" MaxLength="3" Width="20%"></asp:TextBox>
                    (%)</td>
                </tr>
                <tr>
                    <td>
                Bill Number:</td>
                    <td>
                <asp:TextBox ID="txtBillNo" runat="server" CssClass="mandatoryField" MaxLength="30"
                    Width="98%"></asp:TextBox></td>
                    <td align="right">
                Billing Month:</td>
                    <td>
                <asp:TextBox ID="txtBill_Month" runat="server" CssClass="field" Width="95%"></asp:TextBox></td>
                    <td align="right">
                        Bill Date:</td>
                    <td>
                <asp:TextBox ID="txtBill_Date" runat="server" CssClass="field" Width="98%"></asp:TextBox></td>
                    <td><asp:CheckBox ID="chkDis_Date" runat="server" Checked="True" Text="Display Date" /></td>
                </tr>
                <tr>
                    <td style="width:10%"></td>
                    <td style="width:25%"></td>
                    <td style="width:9%"></td>
                    <td style="width:10%"></td>
                    <td style="width:6%"></td>
                    <td style="width:10%"></td>
                    <td style="width:30%"></td>
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
                <asp:Panel ID="pnl_title" runat="server" GroupingText="Bill Titles" Width="99%" Font-Bold="true">
                    <table id="tb_ttl" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                        <tr>
                            <td>
                Reference 1:<asp:CheckBox ID="chkRef1" runat="server" Checked="True" Text="Show" /></td>
                            <td>
                <asp:TextBox ID="txtRef_1" runat="server" CssClass="field" MaxLength="30" Width="75%"></asp:TextBox></td>
                            <td>
                Reference 2:<asp:CheckBox ID="chkRef2" runat="server" Checked="True" Text="Show" /></td>
                            <td>
                <asp:TextBox ID="txtRef_2" runat="server" CssClass="field" MaxLength="30" Width="75%"></asp:TextBox></td>
                            <td>
                Service No:</td>
                            <td>
                <asp:TextBox ID="txtServiceNo" runat="server" CssClass="field" MaxLength="30" Width="98%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                Authorization No:</td>
                            <td>
                <asp:TextBox ID="txtAuthorize_No" runat="server" CssClass="field" MaxLength="30"
                    Width="98%"></asp:TextBox></td>
                            <td>
                                Authorization Date:</td>
                            <td>
                <asp:TextBox ID="txtAuthorize_Date" runat="server" CssClass="field"
                    Width="48%"></asp:TextBox></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width:11%"></td>
                            <td style="width:20%"></td>
                            <td style="width:11%"></td>
                            <td style="width:20%"></td>
                            <td style="width:8%"></td>
                            <td style="width:20%"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
            </td>
        </tr>
            <tr>
            <td></td>
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
            <td></td>
        </tr>
            <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
            <tr>
                <td colspan="8">
                <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="False" CssClass="datagrid" Width="99%" DataKeyNames="prid,bookingid,totalamount" ShowFooter="True">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                        <ItemTemplate>
                        <asp:LinkButton ID="gvlbtnExpend" runat="server" BorderStyle="Solid" BorderWidth="1px"
                                    OnClick="gvlbtnExpend_Click" Text="+"></asp:LinkButton>
                            <%#Container.DataItemIndex+1 %>:
                        </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="prno" HeaderText="PR #" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="labid" HeaderText="Visit #" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="patientname" HeaderText="Patient" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Ref 1">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGvRef_1" runat="server" CssClass="field" MaxLength="30" Width="99%" Text='<%#DataBinder.Eval(Container.DataItem,"bill_ref1").ToString() %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ref 2">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGvRef_2" runat="server" CssClass="field" MaxLength="30" Width="99%" Text='<%#DataBinder.Eval(Container.DataItem,"bill_ref2").ToString() %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Service #">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGvServiceNo" runat="server" CssClass="field" MaxLength="30" Width="99%" Text='<%#DataBinder.Eval(Container.DataItem,"bill_serviceno").ToString() %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Authorize #">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGvAuthorizeNo" runat="server" CssClass="field" MaxLength="30" Width="99%" Text='<%#DataBinder.Eval(Container.DataItem,"authorizeno").ToString() %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Authorize Date">
                            <ItemTemplate>
                                <asp:TextBox ID="txtGvAuthroize_Date" runat="server" CssClass="field" MaxLength="30" Width="99%" Text='<%#DataBinder.Eval(Container.DataItem,"authorize_date").ToString() %>'></asp:TextBox>
                                <cc1:CalendarExtender ID="cal_auth_gv" runat="server" TargetControlID="txtGvAuthroize_Date" Format="dd/MM/yyyy"
                                 PopupButtonID="txtGvAuthroize_Date"></cc1:CalendarExtender>
                                 <cc1:MaskedEditExtender ID="flt_aut_gv" runat="server" TargetControlID="txtGvAuthroize_Date" Mask="99/99/9999"></cc1:MaskedEditExtender>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add Bill">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkGvAddBill" runat="server" Checked='<%#DataBinder.Eval(Container.DataItem,"add_bill").ToString()=="Y" %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td colspan="5">
                                                                <asp:GridView ID="gvTestDetail" runat="server" Width="100%" ShowHeader="false" AutoGenerateColumns="False"
                                                                    DataKeyNames="bookingdid,testid" CssClass="datagrid">
                                                                    <RowStyle CssClass="gridItem"></RowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                                :
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="left" />
                                                                            <ItemStyle HorizontalAlign="left" Width="5%" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Test_Name" HeaderText="Test" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" Width="55%" />
                                                                        </asp:BoundField>                                                                     
                                                                     
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="gridheader"></HeaderStyle>
                                                                    <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
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
            <td colspan="5">
                <asp:GridView ID="gvPreious" runat="server" AutoGenerateColumns="False" CssClass="datagrid" DataKeyNames="billid" OnRowCommand="gvPreious_RowCommand" OnRowEditing="gvPreious_RowEditing">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="billno" HeaderText="Bill #">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bill_date" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="totalcharges" HeaderText="Total Charges">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="billing_month" HeaderText="Bill Month">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:ButtonField CommandName="Edit" HeaderText="Update" Text="Update">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="Print" HeaderText="Print" Text="Print">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:ButtonField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
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
                <td style="width:3%"></td>
                <td style="width:9%"></td>
                <td style="width:20%"></td>
                <td style="width:12%"></td>
                <td style="width:12%"></td>
                <td style="width:12%"></td>
                <td style="width:20%"></td>
                <td style="width:3%"></td>
            </tr>
    </table>
</asp:Content>

