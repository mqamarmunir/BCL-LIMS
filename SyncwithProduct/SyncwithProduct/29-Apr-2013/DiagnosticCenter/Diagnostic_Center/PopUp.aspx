<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/PopUp.aspx.cs" Inherits="PopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pop Up</title>
    <link href="LIMS.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="position:absolute; z-index:200px">
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td >
                <asp:Label ID="lblAlert" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
        </tr>
         <tr>
            <td>
                one</td>
        </tr>
         <tr>
            <td>
                Two</td>
        </tr>
         <tr>
            <td>
                Three</td>
        </tr>
         <tr>
            <td></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
