<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmSearchReport.aspx.cs" Inherits="transaction_wfrmSearchReport" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
        a:hover .siz{
                width: 800px;
                height: 80px;
        }
        

        .siz {
                border: 0px;
                width:100px;
                height:20px;
        }
        
        a:hover .sizf{
                width: 700px;
                height: 30px;
        }
        

        .sizf {
                border: 0px;
                width:80px;
                height:20px;
        }
    .style1
    {
        width: 100%;
    }
</style>

 <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>--%>
    
    <fieldset style="border-radius:10px;">
    <br />
    <legend>Search Patient Investigations</legend>
                           
<table>
        <tr>
            <td>
                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Patient Registration #:"></asp:Label>
&nbsp;&nbsp;
                </td>
            <td>
                <asp:TextBox ID="TxBx_Prno" CssClass="input_text" runat="server"></asp:TextBox>
               <%--<asp:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="TxBx_Prno" ClearMaskOnLostFocus="false" MaskType="Number" ErrorTooltipEnabled="true" Enabled="true" Mask="999-99-99999999" runat="server">
                </asp:MaskedEditExtender>--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lb_labid" runat="server" Text="Lab Identification #:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxBx_labid" CssClass="input_text" runat="server"></asp:TextBox>
                <%--<asp:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="TxBx_labid" ClearMaskOnLostFocus="false" MaskType="Number" ErrorTooltipEnabled="true" Enabled="true" Mask="99-999-99999999" runat="server">
                </asp:MaskedEditExtender>--%>
            </td>
        </tr>
<%--        <tr>
            <td>
                Receipt Letter Headers:&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddl_header" Width="300px" runat="server" 
                    CssClass="input_text"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Receipt Letter Footer:&nbsp;&nbsp;&nbsp;&nbsp; 
                </td>
            <td>
                <asp:DropDownList ID="ddl_footer" runat="server" Width="300px" CssClass="input_text"></asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td align="right" colspan="2">
                <asp:ImageButton ID="Btn_Paid" runat="server" Height="30px" 
                    ImageUrl="~/images/payment.jpeg" onclick="Btn_Paid_Click" ToolTip="Paid Cash" 
                    Width="30px" />
                <asp:ImageButton ID="Btn_Print" runat="server" Height="30px" 
                    ImageUrl="~/images/pdf.gif" onclick="Btn_Print_Click" ToolTip="Print Receipt" 
                    Width="30px" />
                <asp:ImageButton ID="Btn_Search" runat="server" ImageUrl="~/images/search.jpg" 
                    onclick="Btn_Search_Click" Visible="False" />
            </td>
        </tr>
    </table>
    <br />



    </fieldset>
    
    <fieldset>
    <legend>Print Receipt Preview</legend>
        Header View : <br /><a href="#"><img alt="image" id="headerImg" class="siz" runat="server"  /></a>
        <br /><br />
        Footer View :<br /> <a href="#"><img alt="image" id="footerImg" class="sizf" runat="server"  /></a>
    </fieldset>

</asp:Content>

