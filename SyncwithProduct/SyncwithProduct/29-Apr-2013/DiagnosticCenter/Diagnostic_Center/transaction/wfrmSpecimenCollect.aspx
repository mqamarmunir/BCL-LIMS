<%@ Page Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true"
    CodeFile="~/transaction/wfrmSpecimenCollect.aspx.cs" Inherits="specimen" Title="Specimen Collection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
<!--
        function blinkElement(elementId) {
            var elementRef = document.getElementById(elementId);
            var blinkCounter = parseInt(elementRef.blinkCounter);
            if (isNaN(blinkCounter) == true)
                blinkCounter = 0;

            if ((blinkCounter % 2) == 0) {

                elementRef.style.visibility = 'visible';
            }
            else {
                elementRef.style.visibility = 'hidden';
            }

            if (blinkCounter < 1) {
                blinkCounter++;
            }
            else {
                blinkCounter--
            }

            elementRef.blinkCounter = blinkCounter;
            window.setTimeout('blinkElement(\"' + elementId + '\")', 700);
        }

        function blinkGridViewRows() {
            var gridRef = document.getElementById('<%= gvSpecimen.ClientID %>');

            for (var i = 0; i < gridRef.childNodes.length; i++) {
                var bodyRef = gridRef.childNodes(i);

                for (var j = 0; j < bodyRef.childNodes.length; j++) {
                    var trRef = bodyRef.childNodes(j);

                    if (trRef.blinkingRow == 'Y') {
                        blinkElement(trRef.id);
                    }
                }
            }
        }


        Sys.Application.add_load(blinkGridViewRows);


        //window.onload = blinkGridViewRows;
// -->
    </script>
    <div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Specimen Collection</div>

    <table id="" cellpadding="1" cellspacing="1" border="0" width="100%" class="listing">
        <tr>
            <td align="center" class="tdheading" colspan="5">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
               
           
            <td>
                <asp:LinkButton ID="lbtnPatientTrack" Visible="false" runat="server" OnClick="lbtnPatientTrack_Click">Patient Investigation Tracking</asp:LinkButton>
            </td>
           
          
        </tr>
        <tr>
           
            <td colspan="7">
                <%-- <asp:UpdatePanel id="up_pnl_sel" runat="Server" UpdateMode="Conditional"><ContentTemplate>--%>
                <asp:Panel ID="pnl_sel" runat="server" Font-Bold="True" __designer:wfdid="w19" Width="98%"
                    GroupingText="Pending For Specimen">
                    <table id="tb_select" class="listing" cellspacing="1" cellpadding="1" width="100%"
                        border="0">
                        <tbody>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblNoRecord" runat="server" ForeColor="DarkBlue" __designer:wfdid="w20"></asp:Label>
                                </td>
                                <td colspan="2" align="right">
                                    <asp:ImageButton ID="imgRefresh" OnClick="imgRefresh_Click" runat="server" __designer:wfdid="w24"
                                        ImageUrl="~/images/SavePack_2.gif"></asp:ImageButton>
                                    <asp:ImageButton ID="imgCLose" OnClick="imgCLose_Click" runat="server" __designer:wfdid="w25"
                                        ImageUrl="~/images/ClosePack.gif"></asp:ImageButton>
                                </td>
                            </tr>
                            <tr>
                            <td colspan="2" align="left">
                                    <asp:Button ID="btnIndoorRpt" Visible="false" OnClick="btnIndoorRpt_Click" runat="server" __designer:wfdid="w21"
                                        CssClass="btn" Text="Indoor Report"></asp:Button>
                                    <asp:Button ID="btnToday" OnClick="btnToday_Click" runat="server" __designer:wfdid="w22"
                                        CssClass="btn" Text="Today"></asp:Button>
                                    <asp:Button ID="btnlastDays" OnClick="btnlastDays_Click" runat="server" __designer:wfdid="w23"
                                        CssClass="btn" Text="Last 2 Days"></asp:Button>
                                </td>
                               
                               <br />
                            </tr>
                            <tr>
                                <td>
                                    Department:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepart" runat="server" __designer:wfdid="w26" Width="99%" CssClass="dropdown"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlDepart_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    Sub-Department:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubdept" runat="server" __designer:wfdid="w27" Width="98%" CssClass="dropdown"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlSubdept_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Test Group:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTestGroup" runat="server" __designer:wfdid="w28" Width="99%" CssClass="dropdown"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlTestGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    Type:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server" __designer:wfdid="w29" CssClass="dropdown">
                                        <asp:ListItem Value="A">All</asp:ListItem>
                                        <asp:ListItem Value="O">OutDoor</asp:ListItem>
                                        <asp:ListItem Value="I">Indoor</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp; From:<asp:TextBox ID="txtFrom" runat="server" __designer:wfdid="w30" Width="22%" CssClass="txtareaStyle"></asp:TextBox>&nbsp; To:<asp:TextBox ID="txtTo" runat="server" __designer:wfdid="w31"
                                            Width="22%" CssClass="txtareaStyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="center" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <cc1:calendarextender id="cal_frm" runat="server" __designer:wfdid="w32" popupbuttonid="txtFrom"
                                        format="dd/MM/yyyy" targetcontrolid="txtFrom"></cc1:calendarextender>
                                    <cc1:calendarextender id="cal_to" runat="server" __designer:wfdid="w33" popupbuttonid="txtTo"
                                        format="dd/MM/yyyy" targetcontrolid="txtTo"></cc1:calendarextender>
                                    <cc1:maskededitextender id="msk_Frmcal" runat="server" __designer:wfdid="w34" targetcontrolid="txtFrom"
                                        mask="99/99/9999" masktype="date"></cc1:maskededitextender>
                                    <cc1:maskededitextender id="msk_Tocal" runat="server" __designer:wfdid="w35" targetcontrolid="txtTo"
                                        mask="99/99/9999" masktype="date"></cc1:maskededitextender>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%">
                                </td>
                                <td width="35%">
                                </td>
                                <td width="13%">
                                </td>
                                <td width="42%">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
                <%--</ContentTemplate>
           </asp:UpdatePanel>     --%>
            </td>
            
        </tr>
        <tr>
            
            <td colspan="8">
                <%--  <asp:UpdatePanel id="up_gr_sp" runat="server" UpdateMode="Conditional" ><ContentTemplate>--%>
                <asp:GridView ID="gvSpecimen" runat="server" __designer:wfdid="w24" CssClass="listing"
                    OnRowDataBound="gvSpecimen_RowDataBound" Width="99%" OnRowCommand="gvSpecimen_RowCommand"
                    DataKeyNames="prno,panel,authorizeno,repeatcomment,priority" AutoGenerateColumns="False">
                    <RowStyle CssClass="Row"></RowStyle>
                    <AlternatingRowStyle CssClass="AltRow" />
                    <Columns>
                        <asp:TemplateField HeaderText="S#">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>:
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="labid" HeaderText="Lab ID">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="patientname" HeaderText="Patient">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="gender" HeaderText="Gender">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="age" HeaderText="Age">
                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="type" HeaderText="Type">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="referenceno" HeaderText="Reference No">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="bookedon" HeaderText="Booked On">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="adm_info" HeaderText="Adm Info">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="origin" HeaderText="Origin">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
                <%--</ContentTemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlDepart" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlSubdept" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlTestGroup" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgRefresh" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                       </asp:UpdatePanel>    --%>
            
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
        </tr>
        <tr>
            
            <td colspan="7">
                <%--  <asp:UpdatePanel id="up_info" runat="server" UpdateMode="Conditional"><ContentTemplate>--%>
                <asp:Panel ID="pnl_info" runat="Server" Font-Bold="true" GroupingText="Patient Information"
                    Width="98%" style="display:none;"  >
                    <table id="tb_info" class="listing" cellspacing="1" cellpadding="1" width="100%"
                        border="0">
                        <tbody>
                            <tr>
                                <td colspan="5">
                                    <asp:Label ID="lblError" runat="server" __designer:wfdid="w2">
                                    </asp:Label>
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="imgPnl_CLose" OnClick="imgPnl_CLose_Click" runat="server" __designer:wfdid="w3"
                                        ImageUrl="~/images/ClosePack.gif"></asp:ImageButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    PR No:
                                </td>
                                <td>
                                    <asp:Label ID="lblPRno" runat="server" ForeColor="DarkBlue" __designer:wfdid="w4"></asp:Label>
                                </td>
                                <td>
                                    Lab ID:
                                </td>
                                <td>
                                    <asp:Label ID="lblLabID" runat="server" ForeColor="DarkBlue" __designer:wfdid="w5"></asp:Label>
                                </td>
                                <td>
                                    Patient Name:
                                </td>
                                <td>
                                    <asp:Label ID="lblPatient" runat="server" ForeColor="DarkBlue" __designer:wfdid="w6"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gender:
                                </td>
                                <td>
                                    <asp:Label ID="lblGender" runat="server" ForeColor="DarkBlue" __designer:wfdid="w7">
                                    </asp:Label>
                                </td>
                                <td>
                                    Age:
                                </td>
                                <td>
                                    <asp:Label ID="lblAge" runat="server" ForeColor="DarkBlue" __designer:wfdid="w8"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPan_Head" runat="server" __designer:wfdid="w9"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPanel" runat="server" ForeColor="DarkBlue" __designer:wfdid="w10"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCmt_HEad" runat="server" __designer:wfdid="w11"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:Label ID="lblComment" runat="server" ForeColor="DarkBlue" __designer:wfdid="w12"></asp:Label>
                                </td>
                               <%-- <td align="right">
                                    <asp:LinkButton ID="lbtnCollectAll" OnClick="lbtnCollectAll_Click" runat="server"
                                        __designer:wfdid="w13">Collect All</asp:LinkButton>
                                </td>--%>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                                <td align="right">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    &nbsp;<asp:Label ID="lblExternal" runat="server" Visible=false Font-Bold="False" ForeColor="Black"
                                        __designer:wfdid="w14" Text="*External" BackColor="Tomato" BorderStyle="Inset"
                                        BorderWidth="2px"></asp:Label>
                                    <asp:Label ID="lblBCL" runat="server" Font-Bold="False" Visible="false"  ForeColor="White" __designer:wfdid="w14"
                                        Text="BCL" BackColor="Blue" BorderStyle="Inset" BorderWidth="2px"></asp:Label>
                                    <asp:Label ID="lblAMC" runat="server" Font-Bold="False" Visible="false" ForeColor="Black" __designer:wfdid="w14"
                                        Text="AMC" BackColor="White" BorderStyle="Inset" BorderWidth="2px"></asp:Label>
                                    <asp:Button ID="btnSingle" OnClick="btnSingle_Click" runat="server" Width="116px"
                                        __designer:wfdid="w15" Text="Single Specimen" CssClass="btn"></asp:Button>&nbsp;
                                    <asp:Button ID="btnMultiple" OnClick="btnMultiple_Click" runat="server" Width="122px"
                                        __designer:wfdid="w16" Text="Multiple Specimen" CssClass="btn"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <asp:GridView ID="gvCollect" runat="server" Width="100%" CssClass="listing" AutoGenerateColumns="False"
                                        DataKeyNames="testid,bookingid,bookingdid,sub_type,subdepartmentid,qty,scontainerid,unit, specimen_code"
                                        OnRowCommand="gvCollect_RowCommand" OnRowDataBound="gvCollect_RowDataBound" OnRowEditing="gvCollect_RowEditing"
                                        OnRowDeleting="gvCollect_RowDeleting">
                                        <RowStyle CssClass="Row"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSpec" runat="server" __designer:wfdid="w4"></asp:CheckBox>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="S#">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>:
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="subdept" HeaderText="Department">
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="testname" HeaderText="Investigation">
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="specimenqty" HeaderText="Specimen / Qty">
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Spec_Nature">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlNature" runat="server" Width="98%" OnSelectedIndexChanged="ddlNature_SelectedIndexChanged"
                                                        __designer:wfdid="w7">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left" Width="14%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Spec_No">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtSpecNo" runat="server" Width="98%" CssClass="field" __designer:wfdid="w3"
                                                        Enabled="False"></asp:TextBox>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Add Notes">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnAddNotes" OnClick="lbtnAddNotes_Click" runat="server" __designer:wfdid="w5">Add Notes</asp:LinkButton>
                                                    <asp:TextBox ID="txtNotes" runat="server" Width="99%" CssClass="field" __designer:wfdid="w6"
                                                        MaxLength="255"></asp:TextBox>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Left" Width="17%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:CommandField DeleteImageUrl="~/images/Delete.gif" DeleteText="Del" ShowDeleteButton="True">
                                                <ItemStyle Width="5%"></ItemStyle>
                                            </asp:CommandField>
                                            <asp:ButtonField CommandName="Collect" Text="Collect"></asp:ButtonField>
                                           
                                            
                                            <asp:ButtonField CommandName="Comment" ImageUrl="~/images/comment_add.png" ButtonType="Image">
                                            </asp:ButtonField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="AltRow"></AlternatingRowStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:LinkButton ID="lbtntest" runat="server" __designer:wfdid="w18"></asp:LinkButton>
                                    <cc1:modalpopupextender id="mde_intcmt" runat="server" __designer:wfdid="w19" targetcontrolid="lbtntest"
                                        y="100" x="300" popupcontrolid="pnlInt_cmmnt" dropshadow="true"
                                        cancelcontrolid="imgCmt_Close">
               </cc1:modalpopupextender>
                                    <asp:Panel ID="pnlInt_cmmnt" runat="server" Width="500px" CssClass="mPopup" ScrollBars="Vertical" BackColor="AliceBlue"
                                        Height="420px">
                                        <table id="tb_cpy" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <strong>Internal Comment</strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lblTest_intCmt" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblInt_testID" runat="server" Visible="False"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" colspan="3">
                                                        <asp:Label ID="lblInt_BookingID" runat="server" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblInt_Index" runat="server" Visible="False"></asp:Label>
                                                        <asp:ImageButton ID="imgcmt_save" OnClick="imgcmt_save_Click" runat="server" ImageUrl="~/images/SavePack_2.gif">
                                                        </asp:ImageButton><asp:ImageButton ID="imgCmt_Close" OnClick="imgCmt_Close_Click"
                                                            runat="server" ImageUrl="~/images/ClosePack.gif"></asp:ImageButton>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        <asp:Panel ID="pnlW2" runat="server" Font-Bold="True" Width="30%" Height="22px" ToolTip="Click here to add comment">
                                                            <asp:Image ID="imgW" runat="server" ImageUrl="~/images/expandw.jpg"></asp:Image>&nbsp;
                                                            Add comment</asp:Panel>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblerrormsg" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:UpdatePanel ID="up_ur" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Panel ID="pnl_ad_Cmt" runat="server" Width="99%">
                                                                    <table id="tb_ad" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                                                                        <tr>
                                                                            <td>
                                                                                Stage:<cc1:collapsiblepanelextender id="cpeWaiting" runat="server" autocollapse="false"
                                                                                    collapsecontrolid="pnlW2" collapsedimage="../images/expandw.jpg" collapsedtext="Show details..."
                                                                                    expandcontrolid="pnlW2" expandedimage="../images/collapsew.jpg" expandedtext="Hide Details..."
                                                                                    imagecontrolid="imgW" suppresspostback="true" targetcontrolid="pnl_ad_Cmt">
                </cc1:collapsiblepanelextender>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlFor_Process" runat="server" CssClass="dropdown" Width="98%">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td valign="top">
                                                                                Comment:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtInt_Comnt" runat="server" CssClass="field" Height="87px" MaxLength="500"
                                                                                    TextMode="MultiLine" Width="98%"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 20%">
                                                                            </td>
                                                                            <td style="width: 80%">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:GridView ID="gvIntComment" runat="server" CssClass="listing" AutoGenerateColumns="False">
                                                            <RowStyle CssClass="Row" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S#">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex+1 %>
                                                                        :
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="description" HeaderText="Comment">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="55%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="enteredby" HeaderText="Entered By">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="enteredon" HeaderText="Entered On">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <AlternatingRowStyle CssClass="AltRow" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%">
                                                    </td>
                                                    <td width="25%">
                                                    </td>
                                                    <td width="25%">
                                                    </td>
                                                    <td width="25%">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="screenid" colspan="6">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="10%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="17%">
                                </td>
                                <td width="13%">
                                </td>
                                <td width="33%">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
                <%--</ContentTemplate>
                    <Triggers>
<asp:AsyncPostBackTrigger ControlID="gvSpecimen" EventName="RowCommand"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="imgcmt_save" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
                </asp:UpdatePanel>--%>
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
        </tr>
        <tr>
            <td width="5%">
            </td>
            <td width="15%">
            </td>
            <td width="30%">
            </td>
            <td width="15%">
            </td>
            <td width="30%">
            </td>
            <td width="5%">
            </td>
        </tr>
    </table>
</asp:Content>
