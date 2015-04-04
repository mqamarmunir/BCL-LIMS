<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrestPage.aspx.cs" Inherits="TrestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
    <div style="margin:auto; background-color:Red;">
            <cc1:ComboBox ID="cmbReferredBy" runat="server" DropDownStyle="DropDownList" AutoPostBack="false" AutoCompleteMode="SuggestAppend"  ItemInsertLocation="Append"
></cc1:ComboBox>     </div>    
    </div>
    </form>
</body>
</html>
