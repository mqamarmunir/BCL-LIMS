<%@ Reference  VirtualPath="~/MasterPage.master"  %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="loginmohsin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Lims Parameters</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<LINK href="images/format.css" type=text/css rel=stylesheet>
<script language="javascript" type="text/javascript">
    function fullscreen(){
     window.moveTo(0,0); 
window.resizeTo(screen.availWidth,screen.availHeight); 
       } 
</script>
</head>
<BODY BGCOLOR=#FFFFFF LEFTMARGIN=0 TOPMARGIN=0 MARGINWIDTH=0 MARGINHEIGHT=0 onload="fullscreen()">
    <form id="form1" runat="server">
        <div>
        <!-- ImageReady Slices (gadgets.psd) -->
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="label" >

  <tr>
    <td><div align="center">
      <TABLE WIDTH=1004 BORDER=0 CELLPADDING=0 CELLSPACING=0>
  <TR> 
    <TD width="1004" colspan="5" valign="top"><TABLE WIDTH=1004 BORDER=0 CELLPADDING=0 CELLSPACING=0>
        <TR valign="top"> 
          <TD width="230"> <IMG SRC="images/image_01.jpg" WIDTH=230 HEIGHT=7 ALT=""></TD>
          <TD colspan="5"><IMG SRC="images/image_02.jpg" WIDTH=773 HEIGHT=7 ALT=""></TD>
        </TR>
        <TR valign="top"> 
          <TD><IMG SRC="images/header_06.jpg" WIDTH=220 HEIGHT=48 ALT=""></TD>
          <TD width="10"> </TD>
          <TD width="18"> </TD>
          <TD width="128"> <IMG SRC="images/image_10.jpg" WIDTH=128 HEIGHT=48 ALT=""></TD>
          <TD width="308"> <IMG SRC="images/image_11.jpg" WIDTH=308 HEIGHT=48 ALT=""></TD>
          <TD width="310"> <IMG SRC="images/image_12.jpg" WIDTH=310 HEIGHT=48 ALT=""></TD>
        </TR>
        <TR valign="top"> 
          <TD><IMG SRC="images/header_11.jpg" WIDTH=220 HEIGHT=20 ALT=""></TD>
          <TD></TD>
          <TD> <IMG SRC="images/image_15.jpg" WIDTH=18 HEIGHT=20 ALT=""></TD>
          <TD colspan="3" bgcolor="#919EC9">&nbsp;</TD>
        </TR>
        <TR valign="top"> 
          <TD height="170"> <IMG SRC="images/image_19.jpg" WIDTH=230 HEIGHT=170 ALT=""></TD>
          <TD> <IMG SRC="images/image_20.jpg"></TD>
          <TD> <img src="images/image_21.jpg" width="18" height="170"></TD>
          <TD> <img src="images/image_22.jpg" width="128" height="170"></TD>
          <TD> <img src="images/image_23.jpg" width="308" height="170"></TD>
          <TD><img src="images/image_24.jpg" width="310" height="170"></TD>
        </TR>
      </TABLE></TD>
  </TR>
  <TR valign="top"> 
    <TD height="86" colspan="5" bgcolor="#f4f6ff"> 
      <TABLE WIDTH=932 BORDER=0 CELLPADDING=0 CELLSPACING=0>
        <TR valign="top"> 
          <TD width="42" valign="top" bgcolor="#F4F6FF"> <div align="center"><img src="images/whatis_haisam.jpg" width="42" height="38"></div></TD>
          <TD width="390" bgcolor="#F4F6FF"><table width="100%" border="0" cellspacing="2" cellpadding="2">
              <tr>
                <td valign="top"><IMG SRC="images/images_site_05.jpg" WIDTH=322 HEIGHT=18 ALT=""></td>
              </tr>
              <tr>
                <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr valign="top"> 
                      <td width="10%" height="15"><img src="images/logo1.jpg" width="60" height="15"></td>
                      <td width="90%" valign="bottom"><font size="1" face="Verdana, Arial, Helvetica, sans-serif">is 
                        an enterprise hospital management product line</font></td>
                    </tr>
                    <tr valign="top"> 
                      <td height="36" colspan="2"><font size="1" face="Verdana, Arial, Helvetica, sans-serif">of 
                        Trees. Haisam empowers hospitals to manage information 
                        internally and with remote stakeholders to bring them 
                        under Haisam Information sharing domain. </font></td>
                    </tr>
                  </table></td>
              </tr>
            </table></TD>
          <TD width="48" valign="top" bgcolor="#F4F6FF"><div align="left"><img src="images/pic1.JPG" width="43" height="43"> 
            </div></TD>
          <TD width="333" bgcolor="#F4F6FF"><table width="100%" border="0" cellspacing="2" cellpadding="2">
              <tr> 
                <td><font size="2" face="Verdana, Arial, Helvetica, sans-serif"><strong><font color="#D30000" size="1"><IMG SRC="images/images_site_02.jpg" WIDTH=302 HEIGHT=18 ALT=""></font></strong></font></td>
              </tr>
              <tr> 
                <td valign="top"><div align="left"><font size="1" face="Verdana, Arial, Helvetica, sans-serif">IS 
                    an internet service for any size laboratories to connect to 
                    patients, hospitals and collection centers via a standard 
                    internet based application of Trees. It offer the LABS to 
                    deliver electronically and interact to stakeholders using 
                    state of art of art technology</font></div></td>
              </tr>
            </table>
            <font size="2" face="Verdana, Arial, Helvetica, sans-serif"><strong></strong></font> 
          </TD>
          <TD width="191" colspan="2" valign="middle" bgcolor="#F4F6FF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
              <td>
              <font size="2" face="Tahoma, Verdana, Garamond, sans-serif">Branch</font>
              </td>
              <td colspan="2">
              <asp:TextBox ID="txtBranch" runat="server" CssClass="field" Visible="false" Width="90%"></asp:TextBox>
              <asp:DropDownList ID="ddlBranch" Width="100%" runat="server" CssClass="mandatorySelect"></asp:DropDownList>
              </td>
              
              </tr>
              <tr> 
                <td width="30%"><font size="2" face="Tahoma, Verdana, Garamond, sans-serif">&nbsp;User 
                  ID&nbsp;</font></td>
                <td width="40%" align="left">
                    <asp:TextBox ID="txtName" runat="server" CssClass="field" Width="90%" TabIndex="1"></asp:TextBox></td>
                <td width="30%" rowspan="2"><div align="center"><asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/images/login.gif" OnClick="btnLogin_Click" TabIndex="3" />&nbsp;</div></td>
              </tr>
              <tr> 
                <td><font size="2">&nbsp;<font face="Tahoma, Verdana, Garamond, sans-serif">Password&nbsp;</font></font></td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="field" Width="90%" TextMode="Password" TabIndex="2"></asp:TextBox></td>
              </tr>
              <tr> 
                <td colspan="3" class="usermsginorange">
                    <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="100%" Font-Size="Small"></asp:Label>
                    &nbsp;<font size="2" color="#FF0000">&nbsp; 
                  </font> </td>
              </tr>

            </table></TD>
        </TR>
        <TR> 
          <TD colspan="7"><IMG SRC="images/images_site_23.jpg" WIDTH=1004 HEIGHT=8 ALT=""></TD>
        </TR>
      </TABLE></TD>
  </TR>
  <TR valign="top"> 
    <TD height="241" colspan="5"><TABLE WIDTH=1004 BORDER=0 CELLPADDING=0 CELLSPACING=0>
        <TR> 
          <TD colspan="2" valign="top"><table width="100%" height="173" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="80%" valign="top">&nbsp;</td>
                <td width="20%" valign="top" bgcolor="#f4f4ff"><table width="100%" border="0" cellspacing="4" cellpadding="4">
                    <tr> 
                      <td height="52" valign="top"><font size="2" face="Verdana, Arial, Helvetica, sans-serif"><strong><font color="#003399">Haisam</font></strong> 
                        Hospital Management Product Line. </font></td>
                    </tr>
                    <tr> 
                      <td valign="top"><div align="right"><font size="1" face="Verdana, Arial, Helvetica, sans-serif"> 
                          </font></div></td>
                    </tr>
                    <tr> 
                      <td valign="top"><font size="2" face="Verdana, Arial, Helvetica, sans-serif"><strong><font color="#003399">Trees 
                        Technologies</font></strong><br />
                        Legal and HealthCare Automation Consultants</font></td>
                    </tr>
                    <tr> 
                      <td height="36" valign="top"> <div align="right"><font color="#003399" size="1" face="Verdana, Arial, Helvetica, sans-serif">www.treesvalley.com<br>
                          GetToTrees@treesvalley.com</font></div></td>
                    </tr>
                  </table></td>
              </tr>
            </table> </TD>
        </TR>
        <TR> 
          <TD height="19" colspan="2" valign="top"> <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr> 
                <td height="24" bgcolor="#F4F6FF">&nbsp;</td>
              </tr>
            </table></TD>
        </TR>
      </TABLE></TD>
  </TR>
</TABLE>
    </div></td>
  </tr>
</table>
<!-- End ImageReady Slices -->

		
    </form>
    <script language=javascript>
			if("<%=focusElement%>" != ""){
				document.all("<%=focusElement%>").focus();
			}
		</script> 
</body>
</html>
