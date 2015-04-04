<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Report/wfrmPanelRpt.aspx.cs" Inherits="Report_wfrmPanelRpt" Title="Panel Report"%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="ContentID" runat="server">

   <table id="main" cellpadding="1" cellspacing="1" border="0" style="height:100%;width:100%" class="label">
        <tr>
            <td class="screenid" colspan="6" style="height: 15px">
            </td>
        </tr>
        
        <tr style="width:100%">
            <td align="center" class="tdheading" colspan="6">
                Panel Services Statement<asp:ScriptManager ID="ScriptMan" runat="server" >
                </asp:ScriptManager>
                                <cc1:MaskedEditExtender ID="meDiscount" runat="server" TargetControlID= "txtDiscount" MaskType="Number" AutoComplete="false" Mask="999">
                                </cc1:MaskedEditExtender>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDT" MaskType="date" Mask="99/99/9999">
                                </cc1:MaskedEditExtender>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDF" MaskType="date" Mask="99/99/9999">
                                </cc1:MaskedEditExtender>
                                
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDF" PopupButtonID="txtDF" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat ="server" TargetControlID ="txtDT" PopupButtonID ="txtDT" Format ="dd/MM/yyyy">
                                </cc1:CalendarExtender>
            </td>
        </tr>
        
        <tr>
            <td class="screenid" colspan="6">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td style="width:5%"></td>
            <td style="width:10%"></td>
            <td style="width:30%"></td>
            <td style="width:15%"></td>
            <td style="width:30%">
                <asp:ImageButton ID="imgReport" runat="server" ImageUrl="~/images/ReportPack.gif" OnClick="imgReport_Click" /><asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" /><asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" />
            </td>
            <td style="width:5%"></td>
        </tr>
        
        <tr>
            <td class="screenid" colspan="6">
            </td>
        </tr>
       <tr>
           <td>
           </td>
           <td>
           </td>
           <td>
               <asp:RadioButtonList ID="rdbLab" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                   <asp:ListItem Value="A">All</asp:ListItem>
                   <asp:ListItem Value="008">AMC</asp:ListItem>
                   <asp:ListItem Value="006">BCL</asp:ListItem>
               </asp:RadioButtonList></td>
           <td colspan="2">
           </td>
           <td>
           </td>
       </tr>
    
        <tr>
            <td >
            </td>
            <td >
                Report Option:</td>
            <td >
                <asp:RadioButtonList ID="rdbOption" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="B">Detail Statement Of Services</asp:ListItem>
                    <asp:ListItem Value="O">Services Summary</asp:ListItem>
                </asp:RadioButtonList></td>
            <td colspan ="2">
            </td>
            <td >
            </td>
        </tr>
       <tr>
           <td>
           </td>
           <td>
           </td>
           <td align="left">
               <asp:RadioButtonList ID="rdbSelection" runat="server" RepeatDirection="Horizontal"
                   RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rdbSelection_SelectedIndexChanged">
                   <asp:ListItem Value="S">Single Client</asp:ListItem>
                   <asp:ListItem Value="A">All</asp:ListItem>
               </asp:RadioButtonList></td>
           <td colspan="2">
           </td>
           <td>
           </td>
       </tr>
        <tr>
            <td colspan ="6">
                <asp:Panel ID="pnlBilling" runat="server" Width="100%" Height="100%" >
                    <table cellpadding="1" cellspacing="1" border ="0" id="tblBilli0ng" runat="server" style="width:100%;height:100%;" >
                        <tr>
                            <td style="width:5%">
                            </td>
                            <td style="width:10%">
                                Panel:</td>
                            <td style="width:30%">
                                <asp:DropDownList ID="ddlPanel" runat="server" CssClass="dropdown" Width="98%" AutoPostBack="True">
                                </asp:DropDownList></td>
                            <td style="width:15%">
                                Discount:<asp:TextBox ID="txtDiscount" runat="server" MaxLength = "3" Width ="20%">0</asp:TextBox></td>
                            <td style="width:30%">
                                </td>
                            <td style="width:5%">
                            </td>
                        </tr>
                        
                        <tr>
                            <td >
                            </td>    
                            <td >
                                From:</td>
                            <td colspan="2">
                                <asp:textbox id="txtDF" runat="server" CssClass="field" Width="20%"></asp:textbox>
                                To:
                                <asp:textbox id="txtDT" runat="server" CssClass="field" Width="20%"></asp:textbox>
                                &nbsp; &nbsp;
                            </td>
                            <td >
                            </td>
                            <td>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="screenid" colspan="6">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID ="pnlAnalysis" runat="server" Width="100%" Height="100%" Visible ="false" >
                    <table border="0" cellpadding="1" cellspacing="1" class="label" id="tblAnalysis" runat="server" style="width:100%;height:100%;">
                        <tr>
                            <td style="width:5%">
                            </td>
                            <td style="width:15%">
                            </td>
                            <td style="width:30%">
                            </td>
                            <td style="width:15%">
                            </td>
                            <td style="width:30%">
                            </td>
                            <td style="width:5%">
                            </td>
                        </tr>
                        
                        <tr>
                            <td></td>
                            <td>
                                <asp:Label ID="lblPanelAna" runat="server" Text="Panel : ">
                                </asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlAnaPanel" runat="server" CssClass="dropdown" Width="98%" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="screenid" colspan="6" style="height: 15px">
                            </td>
                        </tr>                       
                        
                        <tr>
                            <td style="width:5%">                            
                            </td>
                            <td style="width:15%">                            
                                <asp:Label ID="lblTimeWise" runat="server" Text="Time : ">
                                </asp:Label>
                            </td>
                            <td colspan="3">                            
                                <asp:Panel ID="pnlTimeWise" runat="server" BorderStyle="Solid" BorderWidth="1" Width ="350" Height="23px" HorizontalAlign="Center">
                                    <asp:RadioButton ID="rbDay" runat="server" Text="Day" Checked="true"  GroupName="TimeWise" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="rbDay_CheckedChanged" />
                                    &nbsp;
                                    <asp:RadioButton ID="rbWeek" runat="server" Text="Week" Checked="false" GroupName="TimeWise" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="rbDay_CheckedChanged" />&nbsp;
                                    &nbsp;<asp:RadioButton ID="rbMonth" runat="server" Text="Month" Checked ="false" GroupName="TimeWise" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="rbDay_CheckedChanged"/>
                                    &nbsp;
                                    <asp:RadioButton ID="rbQuarter" runat="server" Text="Quarter" Checked ="false"  GroupName ="TimeWise" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="rbDay_CheckedChanged" />
                                    &nbsp;
                                    <asp:RadioButton ID="rbYear" runat="server" Text="Year" Checked="false" GroupName="TimeWise" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="rbDay_CheckedChanged" />
                                </asp:Panel>
                            </td>
                            <td style="width:5%">                            
                            </td>
                        </tr>
                        <tr>
                            <td class="screenid" colspan="6" style="height:15px">
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblYear" runat="server" Text="Year : " >
                                </asp:Label>
                            </td>
                            <td>
                               <asp:DropDownList ID="ddlYear" runat="server" Width="75px">
                                </asp:DropDownList>
                                &nbsp; &nbsp;<asp:Label ID="lblMonth" runat="server" Text="Month : " >
                                </asp:Label>
                                <asp:DropDownList ID="ddlMonth" runat="server" Width="100px">
                                    <asp:ListItem Value="01">January</asp:ListItem>
                                    <asp:ListItem Value="02">Feburary</asp:ListItem>
                                    <asp:ListItem Value="03">March</asp:ListItem>
                                    <asp:ListItem Value="04">April</asp:ListItem>
                                    <asp:ListItem Value="05">May</asp:ListItem>
                                    <asp:ListItem Value="06">June</asp:ListItem>
                                    <asp:ListItem Value="07">July</asp:ListItem>
                                    <asp:ListItem Value="08">August</asp:ListItem>
                                    <asp:ListItem Value="09">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td class="screenid" colspan="6" style="height:15px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="screenid" colspan="6" style="height: 250px">
            </td>
        </tr>      
    </table>
</asp:Content>