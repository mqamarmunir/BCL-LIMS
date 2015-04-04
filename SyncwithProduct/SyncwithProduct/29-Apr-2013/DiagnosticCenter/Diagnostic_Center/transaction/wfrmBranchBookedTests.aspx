<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmBranchBookedTests.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager> 
<div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Booked Test</div>

<table id="tblbody" class="label" cellpadding="1" cellspacing="1" width="100%">
<%--<tr>
<td colspan="7" align="center"> <font size="4"><strong>BOOKED TESTS</strong></font></td>

</tr>--%>
<tr>
<td colspan="8" align="right"> 
                <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif" OnClick="imgSearch_Click" /><asp:ImageButton
                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /> </td>
</tr>
<tr>
<td align="right">From Date:</td>
<td class="style1"><asp:TextBox ID="txtfrom" runat="server" CssClass="txtareaStyle"></asp:TextBox></td>
    <td class="style2">To Date: </td>
<td><asp:TextBox ID="txtTO" CssClass="txtareaStyle" runat="server"></asp:TextBox>

<cc1:MaskedEditExtender ID="msk_fr" runat="Server" Mask="99/99/9999" MaskType="date" TargetControlID="txtfrom"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="msk_to" runat="Server" Mask="99/99/9999" MaskType="date" TargetControlID="txtTO"></cc1:MaskedEditExtender>
                <cc1:CalendarExtender ID="cal_fr" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtfromDate" TargetControlID="txtfrom"></cc1:CalendarExtender>
                <cc1:CalendarExtender ID="cal_to" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtToDate" TargetControlID="txtTO"></cc1:CalendarExtender>

</td>
<td><asp:Label ID="lblchech" runat="server"></asp:Label></td>
<td><asp:HiddenField ID="hdrun" runat="server" /></td>
<td></td>
<td></td>
</tr>
<tr>
<td colspan="8">
<fieldset>
<legend>Pending Tests</legend>
<table id="tblpending" runat="server" width="100%" class="label">
<tr>
<td>
<asp:GridView ID="gvpending" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="listing" Visible="false">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="Row" />
<AlternatingRowStyle CssClass="AltRow" />
<Columns>
<asp:TemplateField HeaderText="S#">
<HeaderStyle HorizontalAlign="Center" Width="3%" />
<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>

</asp:TemplateField>
<asp:BoundField HeaderText="Destination Branch" DataField="DestinationBranch_Name" />
<asp:BoundField HeaderText="Lab ID" DataField="labID" />
<asp:BoundField HeaderText="Patient Name" DataField="PName"/>
<asp:BoundField HeaderText="Test" DataField="Test_Name"/>
<asp:BoundField HeaderText="Booked On" DataField="EnteredOn"/>
<asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate"/>
<asp:BoundField HeaderText="Origin" DataField="Booking_Branch" />
<asp:CommandField ShowSelectButton="True" SelectText="Send" Visible="false">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
</Columns>
</asp:GridView>
</td>


</tr>
<tr>
<td colspan="8">
<asp:GridView ID="gvBranches" runat="server" AutoGenerateColumns="False" DataKeyNames="DestinationBranchID" 
 OnRowDataBound="gvBranches_RowDatabound" CssClass="listing">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="Row" />
<AlternatingRowStyle CssClass="AltRow" />
<Columns>
<asp:BoundField DataField="DestinationBranch_Name" HeaderText="Destination" />
<asp:TemplateField>
<ItemTemplate>
<tr>
<td colspan="8">
<table id="tblbranches" class="listing" width="99%">
<tr>
<td align="left">
        <div id="dvabc" style="display:inline">
        
             <asp:GridView ID="gvtests" Width="100%" runat="server" AutoGenerateColumns="False" 
                    CssClass="listing" DataKeyNames="TestID,prid">
            <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" /> 
            <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AltRow" />
            <Columns>
            <asp:TemplateField HeaderText="S#">
            <HeaderStyle HorizontalAlign="Center" Width="5%" />
            <ItemTemplate>
            <%#Container.DataItemIndex+1 %>
            </ItemTemplate>

                <ItemStyle HorizontalAlign="Center" />

            </asp:TemplateField>

            <asp:BoundField HeaderText="Lab ID" DataField="labID" />
            <asp:BoundField HeaderText="Patient Name" DataField="PName"/>
            <asp:BoundField HeaderText="Test" DataField="Test_Name"/>
            <asp:BoundField HeaderText="Booked On" DataField="EnteredOn"/>
            <asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate"/>
            <asp:BoundField HeaderText="Origin" DataField="Booking_Branch" />
            <asp:CommandField ShowSelectButton="True" SelectText="Send" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:CommandField>
                <asp:TemplateField HeaderText="Select">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                <asp:CheckBox ID="gvChkSelect" runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
            <table id="tblCourier" runat="server" class="listing">
            <tr>
            <td width="10%"></td>
            <td width="30%"></td>
            <td style="width: 4%"></td>
            <td width="30%"></td>
            <td width="20%"></td>
            </tr>
            <tr>
            <td align="center"></td>
            <td><asp:DropDownList ID="ddlCourierServices" runat="server" Width="100%" Visible="false" CssClass="mandatorySelect"></asp:DropDownList></td>
            <td align="center"></td>
            <td><asp:TextBox ID="txtreciept" runat="server" CssClass="mandatoryField" Visible="false" Width="100%"></asp:TextBox></td>
            <td></td>
           
            </tr>
            <tr>
            <td></td>
            <td></td>
            <td style="width: 4%"></td>
            <td align="right"><asp:Button ID="btnSend" Text="Send" runat="server" CssClass="btn" OnClick="btnSend_Click" /></td>
            <td></td>
            </tr>
            </table>
        </div>
</td>
</tr>

</table>
</td>
</tr>
</ItemTemplate>

</asp:TemplateField>
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
<legend>Courier Reciepts:</legend>
<table id="tblcourierinfo" runat="server" class="label" width="99%">
<tr>
<td colspan="7">
<asp:GridView ID="gvCourierinfo" AutoGenerateColumns="false" runat="server" CssClass="listing"
 OnRowCommand="gvCourierinfo_RowCommand" Width="100%" OnRowDataBound="gvCourierinfo_RowDatabound">
<RowStyle CssClass="Row" />
<AlternatingRowStyle CssClass="AltRow" />
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<Columns>
<asp:TemplateField HeaderText="S#">
<HeaderStyle HorizontalAlign="Center" Width="5%" />
<ItemStyle HorizontalAlign="Center" />
<ItemTemplate>
<%#(Container.DataItemIndex)+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="batchNumber" HeaderText="Batch No" />
<asp:BoundField DataField="Destination" HeaderText="Destination" />
<asp:TemplateField HeaderText="Courier Service">
<ItemTemplate>
<asp:DropDownList ID="ddlCourierServices" runat="server" CssClass="mandatorySelect" Width="99%"></asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reciept Number">
<ItemTemplate>
<asp:TextBox ID="gvtxtreciept" runat="server" CssClass="mandatoryField" Width="99%"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowSelectButton="true" SelectText="Save" />
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
<td colspan="8">
<fieldset>
<legend>Tests Sent--- 
<asp:Label ID="lblnotrec" Text="Not Recieved" BackColor="BurlyWood" runat="server"></asp:Label>
<asp:Label ID="lblRecieved" Text="Recieved" BackColor="Green" Visible="false" runat="server"></asp:Label>
--
<asp:Label ID="Label1" Text="Work List" ForeColor="White" BackColor="#006600" Visible="true" runat="server"></asp:Label>

--
<asp:Label ID="lblResultEntry" Text="ResultEntry" BackColor="AntiqueWhite" runat="server"></asp:Label>
--
<asp:Label ID="lblResVeri" Text="Result Verification" BackColor="Aqua" runat="server"></asp:Label>
--
<asp:Label ID="lblResultDispatch" Text="Result Dispatch" BackColor="Aquamarine" runat="server"></asp:Label>
--
<asp:Label ID="lblDeliverd" Text="Deliverd" BackColor="BlueViolet" runat="server"></asp:Label>
</legend>

<table id="tblsent" runat="server" class="label" width="100%">
<tr>
<td colspan="8">

<asp:GridView ID="gvSent" runat="server" AutoGenerateColumns="false" CssClass="listing"  Width="100%"
 DataKeyNames="batchid,TestStatus,ProcessID" OnRowDataBound="gvSent_RowDataBound" Visible="true">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="Row" />
<AlternatingRowStyle CssClass="AltRow" />
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
<asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate"/>
<asp:BoundField HeaderText="Destination" DataField="Destination_Branch" />

                     
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
<td></td>
<td class="style1"></td>
<td class="style2"></td>
<td></td>
<td>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Visible="false" Text="Button" />
    </td>
<td></td>
<td></td>
</tr>
<tr>
<td width="15%"></td>
<td class="style1"></td>
<td class="style2"></td>
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
            width: 19%;
        }
        .style2
        {
            width: 5%;
        }
    </style>
</asp:Content>


