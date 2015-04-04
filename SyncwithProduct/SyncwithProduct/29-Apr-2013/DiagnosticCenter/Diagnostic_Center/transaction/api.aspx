<%@ Page Language="C#" AutoEventWireup="true" CodeFile="api.aspx.cs" Inherits="api" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
    <head>
        <title>Message Sending Example</title>
        <style type="text/css">
            .style1
            {
                color: #0066FF;
                font-weight: bold;
            }
        </style>
    </head>

<body>
    <form  id="form1" runat="server">
        <table align="center">
            <tr>
                <td colspan="2" align="center">
                    <span class="style1">Compose a message</span>
                   
                </td>
            </tr>
            <tr>
            <td>
            Persons:
            </td>
            <td> <asp:DropDownList ID="ddlpersons" runat="server"  AutoPostBack="true" 
                    ToolTip="Select Person Name" TabIndex="1"
                     Visible="False" >
                  
                </asp:DropDownList>
                </td>
        
            </tr>
            <tr>
                <td>
                    Recipient: 
                </td>
                <td>
                    <asp:TextBox ID="txtrecipient"  ToolTip="Enter Recipient Number" TabIndex="2"  runat="server"></asp:TextBox>
                  <%--  <input type="text" name="recipient" value="<%response.write(Request.form("recipient"))%>" size="40">--%>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Message text: 
                </td>
                <td>
                    <asp:TextBox ID="txtmessagetext"  ToolTip="Enter Message" TextMode="MultiLine"  TabIndex="3" runat="server"></asp:TextBox>
                 <%--   <textarea name="messagetext" rows="3" cols="40"><%response.write(Request.form("messagetext"))%></textarea>--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnButton" runat="server" Text="submit" 
                        onclick="btnButton_Click" />
                   
                </td>
            </tr>
            </table>
    </form>
    
</body>
</html>
