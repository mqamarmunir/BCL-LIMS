﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmCashierEmail.aspx.cs" Inherits="transaction_wfrmCashierEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h2>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/emailAttach.png"  />
        Send Email
    </h2>
    <hr />
<center>
    <table id="tb1" visible="false" runat="server">
    <tr><td>
    <br />
    <h2 style="color:Red; font-style:italic;">Sending Email Please Wait...</h2>
    <br />
    <asp:Image ID="Img_bar" runat="server" ImageUrl="~/images/bar.gif" />
    </td></tr>
    </table>
    
    <table id="tb2" runat="server" visible="false">
    <tr>
    <td>
    <br />
    <h2 style="color:Blue;">Email Sent Successfully...Go Back >>  </h2><a href="CasePartiesInvoice.aspx">Click Here</a>
    <br />
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/sms.jpg" Width="180px" Height="180px" />
    </td>
    </tr>
    </table>
</center>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                ControlToValidate="TxBx_To" runat="server" 
                ErrorMessage="*To: You entered invalid Email ID <br />" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                ControlToValidate="TxBx_Cc" runat="server" 
                ErrorMessage="*CC: You entered invalid Email ID" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

            <asp:RequiredFieldValidator ControlToValidate="TxBx_Subject" ID="RequiredFieldValidator1" runat="server" ErrorMessage="<br />*Subject: You Can't Leave empty field"></asp:RequiredFieldValidator>
  <center>
             <table  width="auto" id="tb3" cellpadding="2"  runat="server" cellspacing="3" style="background-color: #EEEEEE; font-size: 11px; border: 1px inset blue;">

                                          <tr>
                                          <td colspan="2">
                                              <asp:Label ID="Lbl_Email" runat="server" Font-Bold="True" ForeColor="#33CC33"></asp:Label>
                                          </td>
                                          </tr>
                                          
                                          <tr>
                                          <td>
                                          To:
                                          </td>
                                          <td>
                                              <asp:TextBox CssClass="input_text" ID="TxBx_To" runat="server" Width="550px"></asp:TextBox>
                                          </td>
                                          </tr>
                                          
                                          <tr>
                                          <td>
                                          Cc: 
                                          </td>
                                          <td>
                                               <asp:TextBox CssClass="input_text" ID="TxBx_Cc" runat="server" Width="550px"></asp:TextBox>
                                          </td>
                                          </tr>

                                          <tr>
                                          <td>
                                          Subject:
                                          </td>
                                          <td>
                                               <asp:TextBox CssClass="input_text" ID="TxBx_Subject" runat="server" 
                                                   Width="550px"></asp:TextBox>
                                          </td>
                                          </tr>
                                          
                                          <%--<tr>
                                          <td colspan="2" style="font-size:xx-small;">
                                               Attachment: 
                                               <asp:Label ID="Attach_file" ForeColor="Blue" runat="server" Text="Attach_file"></asp:Label>
                                          </td>
                                          </tr>--%>
                                          
                                          <tr>
                                          <td>
                                              &nbsp;</td>
                                          <td>
                                               Attached File: <asp:HyperLink ID="Hyp_Email" runat="server" 
                                                   NavigateUrl="#">PDF File</asp:HyperLink>
                                          </td>
                                          </tr>
                                          
                                          <tr>
                                          <td colspan="2">
                                                <asp:TextBox CssClass="input_text" TextMode="MultiLine" Rows="8" Width="600px" ID="TxBx_Message" 
                                                    runat="server"></asp:TextBox>
                                          </td>
                                          </tr>

                                          <tr>
                                          <td colspan="2" align="right">
                                             <asp:ImageButton ID="Btn_ok" ImageUrl="headerfooter/email.jpg" runat="server" 
                                                  Height="25px" onclick="Btn_ok_Click" />
                                          </td>
                                          </tr>
                      </table>

</center>
</asp:Content>

