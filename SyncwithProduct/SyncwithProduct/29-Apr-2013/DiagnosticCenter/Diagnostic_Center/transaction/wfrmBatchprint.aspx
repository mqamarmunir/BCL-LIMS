<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="wfrmBatchprint.aspx.cs" Inherits="transaction_wfrmBatchprint" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <img src="../css/header.png" />
    <link href="../css/head-bhg.css" rel="stylesheet"
        type="text/css" />
<link href="../css/MyStyle.css" rel="stylesheet" type="text/css" />
    <%--<link href="../css/head-bhg.css" rel="stylesheet" type="text/css" />--%>
    <title>Batch Information</title>
</head>
<body class="label">

<form id="form1" runat="server">
    <div>
 
    <h3 style="margin-left:360px">Batch information</h3>
<fieldset>
<legend>Batch Info</legend>
    
<table id="tblbatchinfo" runat="server" class="label" width="99%">
<tr>
<td align="left">BatchNo:</td>
<td><asp:Label ID="lblBatchNo" ForeColor="Black" runat="server"></asp:Label></td>
<td>Courier Reciept:</td>
<td>__________________</td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td align="left">Dispath Date:</td>
<td><asp:Label ID="lblDispatchDate" ForeColor="Black" runat="server"></asp:Label></td>
<td>Batch Destination:</td>
<td><asp:Label ID="lblBatchDest" ForeColor="Black" runat="server"></asp:Label></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td width="15%" align="left">Specimen Count:</td>
<td width="20%"><asp:Label ID="lblSpecimenCount" ForeColor="Black" runat="server"></asp:Label></td>
<td width="15%"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
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
<fieldset>
<legend>Test Info</legend>
<table id="tbltests" runat="server" width="99%" class="label">
<tr>
<td colspan="7">
<asp:GridView ID="gvTests" runat="server" Width="99%" CssClass="datagrid" AutoGenerateColumns="false">
<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
<RowStyle CssClass="gridItem" />
<AlternatingRowStyle CssClass="gridAlternate" />
<Columns>
<asp:TemplateField HeaderText="S#">
<HeaderStyle Width="5%" HorizontalAlign="Center" />
<ItemStyle Width="5%" HorizontalAlign="Center" />

<ItemTemplate>
<%#Container.DataItemIndex+1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField HeaderText="lab ID" DataField="labid" />
<asp:BoundField HeaderText="Test Name" DataField="TName" />

<asp:BoundField HeaderText="Patient Name" DataField="PName" />


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
<table id="tblsender" runat="server" class="label" width="99%">
<tr>
<td></td>
<td></td>
<td></td>
<td></td>
<td>Sender:</td>
<td></td>
<td></td>

</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td></td>
<td colspan="3"><asp:Label ID="lblsender" ForeColor="Black" runat="server"></asp:Label></td>


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
</div>
    </form>
</body>
</html>
