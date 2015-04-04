<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmGazzetedHolidays.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Parameter_wfrmGazzetedHolidays" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>   
<asp:HiddenField ID="hdholidayid" runat="server" />

<table id="tblbody" class="label" width="99%">
<tr style="font-size: 12pt">
                    <td align="center" colspan="7">
                        <font size="4"><strong>Gazzeted Holidays</strong></font></td>
                </tr>
<tr>
<td colspan="3">
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="Small" Text=""></asp:Label>
</td>
<td colspan="4" align="right">
 <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" />
                                        <asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" />
                                        <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" />

</td>
</tr>
<tr>
<td></td>
<td>
<asp:RadioButton ID="rdoPermanent" GroupName="rdoType" runat="server" Text="Permanent" Checked="true" AutoPostBack="true" OnCheckedChanged="rdoPermanent_CheckedChanged" />
<asp:RadioButton ID="rdoSeasonal" GroupName="rdoType" runat="server" Text="Seasonal" AutoPostBack="true" OnCheckedChanged="rdoSeasonal_CheckedChanged" />
</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td align="right">Date:
<asp:Label ID="lblFrom" runat="server" Text="(From)" Visible="false"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtdateFrom" runat="server" CssClass="mandatoryField" Width="50%"></asp:TextBox>
    <cc1:MaskedEditExtender ID="msk_fr" runat="Server" Mask="99/99/9999" MaskType="date" ClearMaskOnLostFocus="false" TargetControlID="txtdateFrom"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="msk_to" runat="Server" Mask="99/99/9999" ClearMaskOnLostFocus="false" MaskType="date" TargetControlID="txtToDate"></cc1:MaskedEditExtender>
                <cc1:CalendarExtender ID="cal_fr" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtfromDate" TargetControlID="txtdateFrom"></cc1:CalendarExtender>
                <cc1:CalendarExtender ID="cal_to" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></cc1:CalendarExtender>
</td>
<td align="right">
<asp:Label ID="lblTo" runat="server" Text="To" Visible="false"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtToDate" runat="server" CssClass="mandatoryField" Width="50%" Visible="false"></asp:TextBox>
</td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td align="right">
    Description:
</td>
<td colspan="3">
    <asp:TextBox ID="txtDescription" runat="server" Width="99%" TextMode="MultiLine" CssClass="field"></asp:TextBox>
</td>

<td>
<asp:CheckBox ID="chkActive" Text="Active" Checked="true" runat="server" />
</td>
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
</tr>
<tr>
<td colspan="7">
<cc1:TabContainer ID="tabContainer1" runat="server" Width="99%" ActiveTabIndex="0">
<cc1:TabPanel ID="tabgridview" runat="server" Width="99%" HeaderText="Grid View">
<ContentTemplate>
<asp:GridView ID="gvholidays" runat="server" CssClass="datagrid" Width="99%" AutoGenerateColumns="false"
    OnRowCommand="gvholidays_RowCommand" DataKeyNames="holidayid">
    <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
    <RowStyle CssClass="gridItem" />
    <AlternatingRowStyle CssClass="gridAlternate" />
    <Columns>
    <asp:TemplateField HeaderText="S#">
    <HeaderStyle HorizontalAlign="Center" Width="5%"/>
    <ItemStyle HorizontalAlign="Center" Width="5%" />
        <ItemTemplate>
        <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="Description" HeaderText="Description" />
    <asp:BoundField DataField="date_From" HeaderText="From" />
    <asp:BoundField DataField="date_to" HeaderText="To" />
    <asp:BoundField DataField="DiscountType" HeaderText="DiscountType" />
    <asp:TemplateField HeaderText="Active">
    <HeaderStyle HorizontalAlign="Center" Width="5%" />
    <ItemStyle HorizontalAlign="Center" Width="5%" />
        <ItemTemplate>
            <asp:CheckBox ID="gvchkActive" runat="server" Enabled="false"  Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y" %>' />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:CommandField ShowSelectButton="true" SelectText="Edit" />
    </Columns>
    </asp:GridView>
    </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="tabCalender" HeaderText="Calender View" runat="server" Width="99%">
    <ContentTemplate>
    <asp:Calendar ID="calholidays" Width="99%" DayNameFormat="Shortest" runat="server" 
        BackColor="White" BorderColor="#999999" CellPadding="4" Font-Names="Verdana" 
        Font-Size="8pt" ForeColor="Black" Height="180px" 
        onvisiblemonthchanged="calholidays_monthChanged" 
            ondayrender="calholidays_DayRender">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="Gray" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
<TodayDayStyle BorderColor="Black" BorderWidth="1px" BackColor="#CCCCCC" 
            ForeColor="Black"></TodayDayStyle>

<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
    </asp:Calendar>
    </ContentTemplate>
    </cc1:TabPanel>

</cc1:TabContainer>
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
</tr>
<tr>
<td colspan="7">
    
    </td>

</tr>


<tr>
<td width="15%"></td>
<td width="20%"></td>
<td width="15%"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>
</table>
</asp:Content>
