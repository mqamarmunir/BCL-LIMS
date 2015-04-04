<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="smsPage.aspx.cs" Inherits="smsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link rel="stylesheet" type="text/css" href="Styles/style.css" />
    <style type="text/css">
        .btnn
        {
            color: #FFFFFF;
            background-color: #0066FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">SMS</div>
<div class="boxbase">
  
<asp:TextBox runat="server" id="txtmessagetext" class="txtarea"></asp:TextBox><br /><br />
To: <asp:TextBox runat="server" id="txtrecipient" Width="80%" 
        CssClass="txtareaStyle"></asp:TextBox>



<table width="100%">
                <ul id="btnn">
                
                <tr>
                <td align="center" style="width:30%">
                
    <li class="btnn">
               
      <a href="#" class="btnn"> 
        1
     </a>   
          
    </li>
                </td>
                <td>
    <li class="btnn">
                <a href="#" class="btnn"> 
        2
     </a>       
    </li>
                </td>
                <td>
    <li class="btnn">
                <a href="#" class="btnn">
      3
     </a>       
    </li>
                </td>
                </tr>
                   <tr>
                <td>
                
    <li class="btnn">
                <a href="#" class="btnn">
      4
     </a>       
    </li>
                </td>
                <td>
    <li class="btnn">
                <a href="#" class="btnn"> 
        5
     </a>       
    </li>
                </td>
                <td>
    <li class="btnn">
                <a href="#" class="btnn">
      6
     </a>       
    </li>
                </td>
                </tr>
                  <tr>
                <td>
                
    <li class="btnn">
                <a href="#" class="btnn">
      7
     </a>       
    </li>
                </td>
                <td>
    <li class="btnn">
                <a href="#" class="btnn"> 
        8
     </a>       
    </li>
                </td>
                <td>
    <li class="btnn">
                <a href="#" class="btnn">
      9
     </a>       
    </li>
                </td>
                </tr>
                <tr>
                <td>
                      
                      <li class="btnn"><a href="#" class="btnn">0
     </a></li>
                    </td><td colspan="2">
                    <li class="btnn"><%--<a href="#" class="btnEnter">
                        Send</a>--%>
                        <asp:LinkButton ID="SendBTn" CssClass="btnEnter" runat="server" 
                            onclick="SendBTn_Click" >Send</asp:LinkButton>
                        </li>
                        </td>
                     </ul>
                     </table>
                
                 

    </div>
  
</asp:Content>

