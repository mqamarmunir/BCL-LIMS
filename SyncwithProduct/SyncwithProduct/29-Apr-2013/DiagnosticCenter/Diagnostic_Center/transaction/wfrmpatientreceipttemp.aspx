<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmpatientreceipttemp.aspx.cs" MasterPageFile="~/CahierMasterPage.master" Inherits="transaction_wfrmpatientreceipttemp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <script language='javascript'>
        function adjustbalance(_id) {
            var paid = document.getElementById(_id);
            var discountedamount = document.getElementById('lblDiscountedAmount');
            var balanceamount = document.getElementById('lblBalance');
            //alert(discountedamount.innerHTML);
            //alert(paid.value);
            if (!isNaN(parseInt(paid.value))) {
                if (parseInt(discountedamount.innerHTML) - parseInt(paid.value) < 0) {
                    alert('Amount Greater than Discount amount could not be recieved');
                    balanceamount.innerHTML = discountedamount.innerHTML;
                    paid.value = "0";
                    return;
                }
                else {
                    balanceamount.innerHTML = parseInt(discountedamount.innerHTML) - parseInt(paid.value);
                }
            }
            else if (paid.value.length > 0 && isNaN(parseInt(paid.value))) {
                alert('Please enter valid number');
            }
            else {
                balanceamount.innerHTML = discountedamount.innerHTML;
                //paid.value = "0";
                return;
            }

        
        }
    </script>

    <script language="javascript" type="text/javascript">
        window.history.forward();
</script> 
    
    <div style="text-align:center" runat="server" id="div1">
    <table width="40%" border="1">
    <tr>
    <td width="100%">
        <table width="100%">
        <tr>
            <td>Total Amount:</td>
            <td>
            <asp:Label ID="lbltotamount" runat="server"></asp:Label>
            </td>
            <td></td>
            
        </tr>
        <tr>
            <td>Discounted Amount:</td>
            <td>
            <asp:Label ID="lblDiscountedAmount" ClientIDMode="Static" runat="server"></asp:Label>
            </td>
            <td></td>
            
        </tr>
        <tr>
            <td>Amount Paid:</td>
            <td>
            <asp:TextBox ID="txtpaidamount" runat="server" style="text-align:center" onkeyup="javascript:adjustbalance(this.id);"></asp:TextBox>
            </td>
            <td></td>
            
        </tr>
        <tr>
            <td>Balance:</td>
            <td>
            <asp:Label ID="lblBalance" ClientIDMode="Static" runat="server"></asp:Label>
            </td>
            <td></td>
            
        </tr>
        <tr>
        <td></td>
        <td align="right">
        <asp:Button ID="btngenerateReceipt" runat="server" Text="Save" 
                onclick="btngenerateReceipt_Click" /></td>
        <td>
        
        </td>
        
        </tr>
        </table>
    </td>
    </tr>
    </table>
    
    </div>
    <div id="div2" visible="false" style="text-align:center" runat="server">
    <asp:Label ID="lblRequestCancelled" runat="server" Text="The Discount Request has been cancelled by Administrator. Please continue with normal booking procedure." Font-Bold="true" Font-Size="Medium"></asp:Label>
    </div>
 <div id="div3" visible="false" style="text-align:left" runat="server">
    <asp:LinkButton ID="lnkgobacktopatreg" runat="server" 
         Text="Go to Patient Registration" onclick="lnkgobacktopatreg_Click"></asp:LinkButton>
    </div>
</asp:Content>
