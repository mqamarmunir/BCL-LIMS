<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmupcomingTests.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager> 
<script language="javascript">
    function getconfirmation() {

        return confirm('Pressing Ok button will move the speciem to Recieved que. Are you sure you want to do that? Caution:Process is Irreversible.');
        }
    function filtertext(term, _id, cellNr) {
         //alert("I am called");
        var suche = term.value.toLowerCase();
        // var x = document.getElementById(_id);
         // alert(suche);
        var table = document.getElementById(_id);
        //alert(_id);
        var ele;
        for (var r = 0; r < table.rows.length; r++) {
            ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
            if (ele.toLowerCase().indexOf(suche) >= 0)
                table.rows[r].style.display = '';
            else table.rows[r].style.display = 'none';

            //      alert(table.rows[1].cells[1].innerHTML.toString());
        }
    }
    function chkallchanged(cb) {
        if (cb.checked == true) {
           // alert(cb.id.substring(0, 31) + '02' + '_gvchkupcoming');
            var table = document.getElementById(cb.id.substring(0, 27));
            //alert(table);
            for (var i = 2; i <= table.rows.length; i++) {
                // document.getElementById('gvchkupcoming').checked = true;
                if (parseInt(i) < 10) {
                   // alert(cb.id.substring(0, 31) + '0' + i.toString() + '_gvchkupcoming');
                    document.getElementById(cb.id.substring(0, 31) + '0' + i.toString() + '_gvchkupcoming').checked = true;
                }
                else {
                    document.getElementById(cb.id.substring(0, 31)  + i.toString() + '_gvchkupcoming').checked = true;
                }
            }


        }
        else {
            var table = document.getElementById(cb.id.substring(0, 27));
            for (var i = 2; i <= table.rows.length; i++) {
                if (parseInt(i) < 10) {
                    // alert(cb.id.substring(0, 31) + '0' + i.toString() + '_gvchkupcoming');
                    document.getElementById(cb.id.substring(0, 31) + '0' + i.toString() + '_gvchkupcoming').checked = false;
                }
                else {
                    document.getElementById(cb.id.substring(0, 31) + i.toString() + '_gvchkupcoming').checked = false;
                }

            }

        }
    }
</script>

<div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Test Arrivals</div>

<table id="tblbody" class="label" cellpadding="1" cellspacing="1" width="100%">
<%--<tr>
<td colspan="7" align="center"> <font size="4"><strong>Test Arrivals</strong></font></td>

</tr>--%>
<tr>
<td colspan="8" align="right"> 
                <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif" OnClick="imgSearch_Click" /><asp:ImageButton
                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /> </td>
</tr>
<tr>
<td width="15%" >From Date:</td>
<td ><asp:TextBox ID="txtfrom" CssClass="txtareaStyle" runat="server"></asp:TextBox></td>
    <td width="15%" >To Date:</td>
<td><asp:TextBox ID="txtTO" CssClass="txtareaStyle" runat="server"></asp:TextBox>

<cc1:MaskedEditExtender ID="msk_fr" runat="Server" Mask="99/99/9999" MaskType="date" TargetControlID="txtfrom"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="msk_to" runat="Server" Mask="99/99/9999" MaskType="date" TargetControlID="txtTO"></cc1:MaskedEditExtender>
                <cc1:CalendarExtender ID="cal_fr" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtfromDate" TargetControlID="txtfrom"></cc1:CalendarExtender>
                <cc1:CalendarExtender ID="cal_to" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtToDate" TargetControlID="txtTO"></cc1:CalendarExtender>

</td>
<td colspan="3"><asp:Label ForeColor="#0000ff" ID="lblchech" runat="server"></asp:Label></td>

</tr>
<tr>
<td colspan="8">
<fieldset>
<legend>UpComing Tests</legend>
<table id="tblpending" runat="server" width="99%">
<tr>
<td width="15%">
<input type="text" class="field" onkeyup="filtertext(this,'<%=gvpending.ClientID %>',1)"
                                                            style="width: 100%" />
</td>
<td width="15%"></td>
<td width="15%"></td>
<td width="15%"></td>
<td width="15%"></td>
<td width="15%"></td>
</tr>
<tr>
<td colspan="6">
<asp:LinkButton ID="lnkRecieveSelected" runat="server" Text="Recieve Selected" 
        onclick="lnkRecieveSelected_Click" OnClientClick="return getconfirmation();"></asp:LinkButton>
</td>
</tr>
<tr>
<td colspan="6">
<asp:GridView ID="gvpending" runat="server" AutoGenerateColumns="false" CssClass="listing" 
 DataKeyNames="batchid,TestID" OnRowCommand="gvpending_RowCommand" OnRowDataBound="gvpending_RowDataBound" Visible="true">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="Row" />
<AlternatingRowStyle CssClass="AltRow" />
<Columns>
<asp:TemplateField>
<HeaderStyle HorizontalAlign="Left" Width="3%" />
<ItemStyle HorizontalAlign="Left" Width="3%" />
<HeaderTemplate>
<asp:CheckBox ID="gvchkupcomingheader" runat="server"  onclick="javascript:chkallchanged(this);" />
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox ID="gvchkupcoming" runat="server" Checked="false" />
</ItemTemplate>

</asp:TemplateField>
<asp:BoundField HeaderText="Batch No." DataField="Batch_no" ItemStyle-Width="8%" />
<asp:BoundField HeaderText="Lab ID" DataField="labID" ItemStyle-Width="10%" />
<asp:BoundField HeaderText="Patient Name" DataField="PName"/>
<asp:BoundField HeaderText="Test" DataField="Test_Name"/>
<asp:BoundField HeaderText="Booked On" DataField="EnteredOn"/>
<asp:BoundField HeaderText="Dispath Date" DataField="DispatchTime" />
<asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate"/>
<asp:BoundField HeaderText="Origin" DataField="Booking_Branch" />
<asp:BoundField HeaderText="Courier Service" DataField="ServiceName" ItemStyle-Width="10%"/>
<asp:CommandField ShowSelectButton="True" SelectText="Recieved" Visible="true">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
</Columns>
</asp:GridView>
</td>
</tr>
</table>
</fieldset>
</td>

</tr>
<tr>
<td colspan="8">
<fieldset>
<legend>Recieved:</legend>
<table id="tblrecieved" class="listing" runat="server" width="100%">
<tr>
<td width="15%">
<input type="text" class="field" onkeyup="filtertext(this,'<%=gvRecieved.ClientID %>',1)"
                                                            style="width: 100%" />
</td>
<td width="15%"></td>
<td width="15%"></td>
<td width="15%"></td>
<td width="15%"></td>
<td width="15%"></td>
</tr>
<tr>
<td colspan="7">
<asp:GridView ID="gvRecieved" runat="server" AutoGenerateColumns="false" CssClass="listing" 
 DataKeyNames="batchid,TestID" Visible="true">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="Row" />
<AlternatingRowStyle CssClass="AltRow" />
<Columns>
<asp:TemplateField HeaderText="S#">
<HeaderStyle HorizontalAlign="Left" Width="3%" />
<ItemStyle HorizontalAlign="Left" Width="3%" />
<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField HeaderText="Batch No." DataField="Batch_no" ItemStyle-Width="8%" />
<asp:BoundField HeaderText="Lab ID" DataField="labID" ItemStyle-Width="10%"/>
<asp:BoundField HeaderText="Patient Name" DataField="PName"/>
<asp:BoundField HeaderText="Test" DataField="Test_Name"/>
<asp:BoundField HeaderText="Booked On" DataField="EnteredOn"/>
<asp:BoundField HeaderText="Dispath Date" DataField="DispatchTime" />
<asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate"/>
<asp:BoundField HeaderText="Origin" DataField="Booking_Branch" />
</Columns>
</asp:GridView>
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
</fieldset>
</td>

</tr>
<tr>
<td colspan="7">
<fieldset style="visibility:hidden">
<legend>Required Forwarding</legend>
<table id="tblForwarding" width="99%" class="label">
<tr>
<td colspan="7">
<asp:GridView ID="gvForwarding" runat="server" AutoGenerateColumns="false" CssClass="datagrid" 
 DataKeyNames="batchid,TestID" Visible="true">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="gridItem" />
<AlternatingRowStyle CssClass="gridAlternate" />
<Columns>
<asp:TemplateField HeaderText="S#">
<HeaderStyle HorizontalAlign="Center" Width="5%" />
<ItemStyle HorizontalAlign="Center" Width="5%" />
<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>

</asp:TemplateField>
<asp:BoundField HeaderText="Batch Number" DataField="Batch_no" />
<asp:BoundField HeaderText="Lab ID" DataField="labID" />
<asp:BoundField HeaderText="Patient Name" DataField="PName"/>
<asp:BoundField HeaderText="Test" DataField="Test_Name"/>
<asp:BoundField HeaderText="Booked On" DataField="EnteredOn"/>
<asp:BoundField HeaderText="Dispath Date" DataField="DispatchTime" />
<asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate"/>
<asp:BoundField HeaderText="Origin" DataField="Booking_Branch" />


</Columns>
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
</tr>
 </table>
</fieldset>

</tr>

<tr>
<td colspan="7">
<fieldset style="visibility:hidden">
<legend>Send Outs:</legend>
<table id="tblsendouts" width="99%" class="label">
<tr>
<td colspan="7">
<asp:GridView ID="gvSendOuts" runat="server" AutoGenerateColumns="false" CssClass="datagrid" 
 DataKeyNames="batchid,TestID" Visible="true">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="gridItem" />
<AlternatingRowStyle CssClass="gridAlternate" />
<Columns>
<asp:TemplateField HeaderText="S#">
<HeaderStyle HorizontalAlign="Center" Width="5%" />
<ItemStyle HorizontalAlign="Center" Width="5%" />
<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>

</asp:TemplateField>
<asp:BoundField HeaderText="Batch Number" DataField="Batch_no" />
<asp:BoundField HeaderText="Lab ID" DataField="labID" />
<asp:BoundField HeaderText="Patient Name" DataField="PName"/>
<asp:BoundField HeaderText="Test" DataField="Test_Name"/>
<asp:BoundField HeaderText="Booked On" DataField="EnteredOn"/>
<asp:BoundField HeaderText="Dispath Date" DataField="DispatchTime" />
<asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate"/>
<asp:BoundField HeaderText="Origin" DataField="Booking_Branch" />


</Columns>
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
</tr>
</table>
</fieldset>
</td>

</tr>



<tr>
<td></td>
<td class="style2"></td>
<td class="style1"></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td width="15%"></td>
<td class="style2"></td>
<td class="style1"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>
</table>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 4%;
        }
        .style2
        {
            width: 15%;
        }
    </style>
</asp:Content>


