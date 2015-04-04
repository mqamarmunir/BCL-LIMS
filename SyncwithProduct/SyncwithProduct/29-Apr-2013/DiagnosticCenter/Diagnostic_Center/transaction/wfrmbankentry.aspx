<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmbankentry.aspx.cs" Inherits="transaction_wfrmbankentry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 19px;
        }
        .style2
        {
            height: 19px;
            width: 794px;
        }
        .style3
        {
            width: 223px;
        }
        .style4
        {
            height: 19px;
            width: 223px;
        }
    </style>
    <script type="text/javascript">
        function UserAddConfirmation() {
            return confirm("Are you sure you want to Save this Information?");
        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
           <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
    
<div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Bank 
    Deposit</div>
<table id="tblbody" class="label" cellpadding="1" cellspacing="1" width="100%">
<%--<tr>
<td colspan="7" align="center"> <font size="4"><strong>BOOKED TESTS</strong></font></td>

</tr>--%>
<tr>
<td colspan="8" align="right"> 
                <asp:ImageButton ID="imgSave" runat="server" AccessKey="s" 
                    ImageUrl="~/images/SavePack.gif" OnClientClick="javascript:if ( ! UserAddConfirmation()) return false;"  OnClick="imgSave_Click" TabIndex="14"    
                    ToolTip="Click or Press Alt+s to save test booking" ValidationGroup="g" />
                <asp:ImageButton
                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" 
                    OnClick="imgClose_Click" CausesValidation="False" /> </td>
</tr>
<tr>
<td align="right">&nbsp;</td>
<td class="style1">&nbsp;</td>
    <td class="style2">
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td></td>
<td></td>
</tr>
<tr>
<td colspan="8">
<fieldset>
<legend>InformaTION</legend>
<table id="tblpending" runat="server" width="100%" class="label">
<tr>
<td class="style4">
    Location:</td>


<td class="style1">
    <asp:TextBox ID="txtlocation" runat="server" 
         Width="200px" ValidationGroup="g"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
        ControlToValidate="txtlocation" runat="server" 
        ErrorMessage="*" ValidationGroup="g"></asp:RequiredFieldValidator>
</td>


</tr>
<tr>
<td class="style3">
    Cashier:</td>
<td>
    <asp:TextBox ID="txtcashier" runat="server" Width="200px" ValidationGroup="g"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
        ControlToValidate="txtcashier" runat="server" 
        ErrorMessage="*" ValidationGroup="g"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="style3">
    Date:</td>
<td>
    <asp:TextBox ID="txtdate" runat="server" Width="200px" ValidationGroup="g"></asp:TextBox>
    <cc1:CalendarExtender ID="calextdob" runat="server" Format="dd/MM/yyyy" 
        TargetControlID="txtdate">
    </cc1:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
        ControlToValidate="txtdate" runat="server" 
        ErrorMessage="*" ValidationGroup="g"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="style3">
    Cash as per Cash Report:</td>
<td>
    <asp:TextBox ID="txtramt" runat="server" Width="200px" ValidationGroup="g"></asp:TextBox>
     <cc1:FilteredTextBoxExtender TargetControlID="txtramt" FilterInterval="0" 
        FilterMode="ValidChars"
        FilterType="Numbers" 
        ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789">
    </cc1:FilteredTextBoxExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
        
        ControlToValidate="txtramt" runat="server" 
        ErrorMessage="*" ValidationGroup="g"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="style3">
    Cash Submitted in Bank:</td>
<td>
    <asp:TextBox ID="txtbank" runat="server" Width="200px" ValidationGroup="g"></asp:TextBox>
       <cc1:FilteredTextBoxExtender TargetControlID="txtbank" FilterInterval="0" 
        FilterMode="ValidChars" FilterType="Numbers" 
        ID="ft2" runat="server" ValidChars="0123456789"> </cc1:FilteredTextBoxExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
        ControlToValidate="txtbank" runat="server" 
        ErrorMessage="*" ValidationGroup="g"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="style3">
    Report #:</td>
<td>
    <asp:TextBox ID="txtreportno" runat="server" Width="200px" ValidationGroup="g"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
        ControlToValidate="txtreportno" runat="server" 
        ErrorMessage="*" ValidationGroup="g"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="style3">
    Comments:</td>
<td>
    <asp:TextBox ID="txtcomments" runat="server" Height="96px" TextMode="MultiLine" 
        Width="346px" ValidationGroup="g"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
        ControlToValidate="txtcomments" runat="server" 
        ErrorMessage="*" ValidationGroup="g"></asp:RequiredFieldValidator>
</td>
</tr>
</table>
</fieldset>
</td>

</tr>
<tr>
<td colspan="8">
&nbsp;</td>
</tr>
<tr>
<td colspan="8">
&nbsp;</td>

</tr>



<tr>
<td></td>
<td class="style1"></td>
<td class="style2"></td>
<td></td>
<td>
    &nbsp;</td>
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

    </table>

</asp:Content>

