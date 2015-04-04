<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/transaction/wfrmExternal_Track.aspx.cs" Inherits="external_track" Title="External Test Track" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="tb_main" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">
        <tr>
            <td colspan="8" class="tdheading" align="center">
            External Test Track
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td align="right">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblError" runat="server"></asp:Label></td>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td></td>
            <td align="right">
                <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif" OnClick="imgSearch_Click" /><asp:ImageButton
                    ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td align="right">
                Lab:</td>
            <td>
                &nbsp;<asp:RadioButtonList ID="rdbLab" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="All">All</asp:ListItem>
                    <asp:ListItem Value="AMC">AMC</asp:ListItem>
                    <asp:ListItem>BCL</asp:ListItem>
                </asp:RadioButtonList></td>
            <td align="center">
                From Date:</td>
            <td colspan="2">
                <asp:TextBox ID="txtfromDate" runat="server" CssClass="field" Width="25%"></asp:TextBox>
                &nbsp;&nbsp; To Date:
                <asp:TextBox ID="txtToDate" runat="server" CssClass="field" Width="25%"></asp:TextBox></td>
            <td>
                <cc1:MaskedEditExtender ID="msk_fr" runat="Server" Mask="99/99/9999" MaskType="date" TargetControlID="txtfromDate"></cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="msk_to" runat="Server" Mask="99/99/9999" MaskType="date" TargetControlID="txtToDate"></cc1:MaskedEditExtender>
                <cc1:CalendarExtender ID="cal_fr" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtfromDate" TargetControlID="txtfromDate"></cc1:CalendarExtender>
                <cc1:CalendarExtender ID="cal_to" runat="Server" Format="dd/MM/yyyy" PopupButtonID="txtToDate" TargetControlID="txtToDate"></cc1:CalendarExtender>
            </td>
            <td></td>
        </tr>
        <tr>
            <td align="right">
                <img src="../images/bullet.gif" /></td>
            <td>
                <span style="text-decoration: underline"><strong>Pending Test</strong></span></td>
            <td>
                <asp:Label ID="lblPend_Count" runat="server" Visible="False"></asp:Label></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="6"><asp:UpdatePanel id="up_pend" runat="server"><ContentTemplate>
                <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="False" CssClass="datagrid" OnRowCommand="gvPending_RowCommand" DataKeyNames="original_org,testid,external_org">
                    <RowStyle CssClass="gridItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#"><ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                            :
                        </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="labid" HeaderText="Lab ID">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="patientname" HeaderText="Patient">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="18%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="test_name" HeaderText="Test">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="location" HeaderText="Location">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="13%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bookon" HeaderText="Booked On">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="deliverytime" HeaderText="Delivery Time">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="origin" HeaderText="Origin">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" SelectText="Send">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
               </ContentTemplate>
               <triggers>
                    <asp:AsyncPostBackTrigger ControlID="imgCmt_Close" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                    
               </triggers>
              </asp:UpdatePanel>  
            </td>
            <td></td>
        </tr>
        <tr>
            <td align="right">
                <img src="../images/bullet.gif" /></td>
            <td>
                <strong><span style="text-decoration: underline">Processed Test</span></strong></td>
            <td colspan="4">
                <asp:Label ID="lblOver" runat="server" Text="Over Due" BackColor="#cc3366" ForeColor="whitesmoke"></asp:Label>
                <asp:Label ID="lblWorklist" runat="server" Text="Work List" BackColor="CadetBlue" ForeColor="white"></asp:Label>
                <asp:Label ID="lblResultEntry" runat="server" Text="Result Entry" BackColor="Thistle" ForeColor="black"></asp:Label>
                <asp:Label ID="lblResultVerify" runat="server" Text="Result Verification" BackColor="violet" ForeColor ="black"></asp:Label>
                <asp:Label ID="lblDispatch" runat="server" Text="Dispatch" BackColor="CornflowerBlue" ForeColor="white"></asp:Label>
                <asp:Label ID="lblDelivered" runat="server" Text="Delivered" BackColor="LightSeaGreen" ForeColor="white"></asp:Label></td>
            <td>
                <asp:Label ID="lblProce_Count" runat="server" Visible="False"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="6"><asp:UpdatePanel id="up_process" runat="server"><ContentTemplate>
<asp:GridView id="gvProcessed" runat="server" CssClass="datagrid" DataKeyNames="testid,send_date,send_time,original_org,outid,orgid,rec_date,rec_time,processid" OnRowCommand="gvProcessed_RowCommand" AutoGenerateColumns="False" OnRowDataBound="gvProcessed_RowDataBound">
                <RowStyle CssClass="gridItem" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                            :
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="3%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="labid" HeaderText="Lab ID">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="11%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="patientname" HeaderText="Patient">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="14%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test_name" HeaderText="Test">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="location" HeaderText="Location">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="14%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="deliverytime" HeaderText="Reporting Time">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sendon" HeaderText="Dispatch On">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="11%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="receive_time" HeaderText="Est. Receiving">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="process" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="origin" HeaderText="Origin">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Edit">
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle CssClass="gridheader" />
                <AlternatingRowStyle CssClass="gridAlternate" />
            </asp:GridView> 
</ContentTemplate>
               <triggers>
<asp:AsyncPostBackTrigger ControlID="imgCmt_Close" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
              </asp:UpdatePanel> 
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td colspan="4"><asp:UpdatePanel id="up_md" runat="server"><ContentTemplate>
                <asp:LinkButton ID="lbtntest" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="mde_intcmt" runat="server" BackgroundCssClass="TransparentGrayBackground"
                    CancelControlID="imgCmt_Close" DropShadow="true" PopupControlID="pnlInt_cmmnt"
                    TargetControlID="lbtntest" X="300" Y="100">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlInt_cmmnt" runat="server" CssClass="mPopup" Height="230px" ScrollBars="Vertical"
                    Width="640px">
                    <table id="tb_cpy" border="0" cellpadding="1" cellspacing="1" class="label" width="95%">
                        <tr>
                            <td align="center" colspan="4">
                            <asp:Label id ="lblOutID" runat="server" text="" visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="lblHead" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4">
                                <asp:Label ID="lblErr_Pnl" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOriginal_org" runat="server" Visible="False"></asp:Label></td>
                            <td colspan="2">
                                <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label><asp:Label ID="lbLabID" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lbltestID" runat="server" Visible="False"></asp:Label></td>
                            <td align="right">
                                <asp:ImageButton ID="imgcmt_save" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                    OnClick="imgcmt_save_Click" /><asp:ImageButton ID="imgCmt_Close" runat="server" ImageUrl="~/images/ClosePack.gif"
                                        OnClick="imgCmt_Close_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                Visit #:</td>
                            <td>
                                <asp:Label ID="lblVisitNo" runat="server" Text="" forecolor="DarkBlue"></asp:Label></td>
                            <td>
                                Patient:</td>
                            <td>
                                <asp:Label ID="lblPatient" runat="server" Text="" forecolor="DarkBlue"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Test:</td>
                            <td>
                                <asp:Label ID="lblTestName" runat="server" Text="" forecolor="DarkBlue"></asp:Label></td>
                            <td>
                                Reporting Time:</td>
                            <td>
                                <asp:Label ID="lblReportingTime" runat="server" Text="" forecolor="DarkBlue"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4" class="screenid">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Organization:</td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlOrg_Pnl" runat="server" Width="99%">
                                </asp:DropDownList></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                Send Time:</td>
                            <td>
                                <asp:TextBox ID="txtSend_Date" runat="server" CssClass="field" Width="40%"></asp:TextBox>
                                <asp:TextBox ID="txtSend_Time" runat="server" CssClass="field" Width="20%"></asp:TextBox>
                                (24 hr)</td>
                            <td>
                                Rec Time:</td>
                            <td>
                                <asp:TextBox ID="txtRec_Date" runat="server" CssClass="field" Width="43%"></asp:TextBox>
                                <asp:TextBox ID="txtRec_Time" runat="server" CssClass="field" Width="20%"></asp:TextBox>
                                (24 hr)</td>
                        </tr>
                        <tr>
                            <td>
                                Comment:</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtComment" runat="server" CssClass="field" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <cc1:CalendarExtender ID="cal_send" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtSend_Date"
                                 TargetControlID="txtSend_Date"></cc1:CalendarExtender>
                            </td>
                            <cc1:CalendarExtender ID="cal_Rec" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtRec_Date"
                                 TargetControlID="txtRec_Date"></cc1:CalendarExtender>
                            <td>
                            <cc1:MaskedEditExtender ID="msk_send" runat="Server" Mask="99/99/9999" MaskType="date" TargetControlID="txtSend_Date">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditExtender ID="msk_rec" runat="Server" Mask="99/99/9999" MaskType="date" TargetControlID="txtRec_Date">
                            </cc1:MaskedEditExtender>
                            </td>
                            <td>
                            <cc1:MaskedEditExtender ID="msk_send_time" runat="Server" Mask="99:99" MaskType="time" TargetControlID="txtSend_Time">
                            </cc1:MaskedEditExtender>
                            <cc1:MaskedEditExtender ID="msk_rec_time" runat="Server" Mask="99:99" MaskType="time" TargetControlID="txtRec_Time">
                            </cc1:MaskedEditExtender>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:18%">
                            </td>
                            <td style="width:34%">
                            </td>
                            <td style="width:18%">
                            </td>
                            <td style="width:30%">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
               </ContentTemplate>
               <triggers>
                    <asp:AsyncPostBackTrigger ControlID="gvPending" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                    
               </triggers>
              </asp:UpdatePanel>  
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
           <td style="width:5%"></td>
           <td style="width:10%"></td>
           <td style="width:20%"></td>
           <td style="width:10%"></td>
           <td style="width:20%"></td>
           <td style="width:10%"></td>
           <td style="width:20%"></td>
           <td style="width:5%"></td>
        </tr>
    </table>
</asp:Content>

