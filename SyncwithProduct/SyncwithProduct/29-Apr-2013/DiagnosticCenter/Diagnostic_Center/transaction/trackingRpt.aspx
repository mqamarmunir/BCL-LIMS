<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trackingRpt.aspx.cs" Inherits="transaction_trackingRpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
    function close_window() {
  if (confirm("Close Window?")) {
    close();
  }
}
</script>


    <style type="text/css">
     .GetMe
        {
            background: url(../img/Delete.gif); /* Old browsers */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

                    <div style="float: left; position: fixed; width: 580px; margin: 100px 0 0 150px;">
                    <asp:Panel ID="pnlDetails" runat="server" Width="100%" >
                        <div style="width: 120%; -webkit-border-radius: 20px; -webkit-border-top-right-radius: 3px;
                            -webkit-border-bottom-left-radius: 3px; -moz-border-radius: 20px; -moz-border-radius-topright: 3px;
                            -moz-border-radius-bottomleft: 3px; border-radius: 20px; border-top-right-radius: 3px;
                            border-bottom-left-radius: 1px; -webkit-box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75);
                            -moz-box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75); box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75);
                            overflow: auto; height: 400px; -webkit-box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75);
                            -moz-box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75); box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75);
                            min-height: 100px; padding: 10px 10px 10px 10px; margin: auto; background-color: #62B1D0;">
                            <table width="100%" id="tbback1">
                                <div style="float: right; width:100%;">
                                    
                                       <input style="float: right;" type="button" onclick="close_window();return false;" class="GetMe" value="" />
                                        <%--    <asp:ImageButton ID="ImageButton11" OnClientClick="callMe()" runat="server"  ImageUrl="~/img/Delete.gif"    />
                                    --%><%--</a>--%>
                                        <div style="clear: both;">
                                        </div>
                                </div>
                                <div style="text-align: center; font-family: Garamond, serif; line-height: 1em; color: #fff9d6;
                                    font-weight: bold; font-size: 24px; text-shadow: 0px 0px 0 rgb(231,231,231),0px 0px 0 rgb(216,216,216),1px 1px 0 rgb(202,202,202),1px 1px 0 rgb(187,187,187),2px 2px 0 rgb(173,173,173),2px 2px 0 rgb(158,158,158), 3px 3px 0 rgb(144,144,144),3px 3px 3px rgba(0,0,0,0.6),3px 3px 0px rgba(0,0,0,0.5),0px 0px 3px rgba(0,0,0,.2);">
                                    Tracking Status
                                </div>
                                <tr style="font-size:12px;">
                                    <td class="style1" width="12%">
                                        Patient Name:
                                    </td>
                                    <td width="35%">
                                        <asp:Label ID="lblPatientName" runat="server" Font-Bold="true" ForeColor="white"></asp:Label>
                                    </td>
                                    <td width="8%">
                                        DOB:
                                    </td>
                                    <td width="12%">
                                        <asp:Label ID="lblDOB" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                    </td>
                                    <td width="5%">
                                        CellNo:
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lblCellNo" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                    </td>
                                </tr>


                                <tr style="font-size:12px;">
                                    <td>
                                        Lab Id
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLabid" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                    </td>
                                    <td>
                                        PR_No:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblprno" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:GridView ID="gvTestDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                            GridLines="Horizontal" CellPadding="0" CssClass="listing">
                                            <RowStyle CssClass="Row" BackColor="#F3EFE0" Font-Size="10px" />
                                            <AlternatingRowStyle HorizontalAlign="Left" CssClass="AltRow" BackColor="#F5F5F5"
                                                Font-Size="10px" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Test Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" Text='<%# Eval("Test_Name")%>' runat="server" class="label"
                                                            Font-Bold="true" Font-Names="Arial" ItemStyle-Width="35%" Font-Size="10px"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" />
                                                    <ItemStyle HorizontalAlign="left" Width="25%" />
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Process Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" Text='<%# Eval("process")%>' runat="server" class="label"
                                                        Font-Bold="False" Font-Names="Arial" Font-Size="8pt"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="left" />
                                                <ItemStyle HorizontalAlign="left" Width="25%" />
                                            </asp:TemplateField>--%>
                                                <%--<asp:BoundField DataField="EnteredBy" HeaderText="Tracking Status" SortExpression="EnteredBy" />
--%>
                                                <asp:TemplateField HeaderText="Tracking Status" SortExpression="EnteredBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lb_statustrack" runat="server" Text='<%# Eval("EnteredBy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--   <asp:BoundField DataField="Enteredon"  HeaderText="Process By" SortExpression="Enteredon" />--%>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                </div>
                    </asp:Panel>
                
                </div>

    </form>
</body>
</html>
