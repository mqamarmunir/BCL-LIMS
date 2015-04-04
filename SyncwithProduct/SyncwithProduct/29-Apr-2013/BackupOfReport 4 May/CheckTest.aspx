<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckTest.aspx.cs" Inherits="transaction_CheckTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br /> <br /> <br /> <br />
<table width="100%">
    <tr>
        <td align="center">
              <asp:Image runat="server" ID="Image_Print" Visible="false" 
            ImageUrl="~/img/Printer.png" Height="100px" Width="100px" />
            <br />
            <asp:Label ID="PrintOn" Font-Size="14px" ForeColor="DarkGreen" Text="" runat="server"></asp:Label>
      
        </td>
    </tr>
</table>    
  
    </div>
    </form>
</body>
</html>
