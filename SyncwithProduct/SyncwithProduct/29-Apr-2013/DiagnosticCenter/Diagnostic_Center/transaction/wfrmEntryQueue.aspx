<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="~/transaction/wfrmEntryQueue.aspx.cs" Inherits="entryqueue" Title="Result Entry Queue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function Calculate(Min, Max, txt) {
            var MinPer = parseFloat(Min) - (parseFloat(Min) * 3);
            var MaxPer = (parseFloat(Max) * 3);

            if (isNaN(parseFloat(txt.value))) {
                //alert("Please Enter number ");
                return;
            }
            else if (parseFloat(txt.value) > MaxPer || parseFloat(txt.value) < MinPer) {
                alert("Please check out of range value");
            }
        }		
		
    </script>
    <table id="" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="center" class="tdheading" colspan="6">
                Result Entry<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="up_pat" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlPatient" runat="server" Width="99%">
                            <table style="border-right: teal thin solid; border-top: teal thin solid; border-left: teal thin solid;
                                border-bottom: teal thin solid" id="tb_pat" class="label" cellspacing="1" cellpadding="1"
                                width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblError" runat="server"></asp:Label>
                                        </td>
                                        <td valign="top" colspan="2">
                                            <asp:Button ID="btnSaveNext" OnClick="btnSaveNext_Click" runat="server" Font-Bold="True"
                                                ForeColor="Navy" Width="85px" BackColor="SkyBlue" Text="Save & Next"></asp:Button>&nbsp;
                                            <asp:Button ID="btnSavePrint" OnClick="btnSavePrint_Click" Visible="false" runat="server" Font-Bold="True"
                                                ForeColor="Navy" Width="85px" BackColor="SkyBlue" Text="Save & Print"></asp:Button>
                                            <asp:ImageButton ID="imgSave" OnClick="imgSave_Click" runat="server" ImageUrl="~/images/SavePack_2.gif">
                                            </asp:ImageButton>
                                            <asp:ImageButton ID="imgClose_pnl" OnClick="imgClose_pnl_Click" runat="server" ImageUrl="~/images/ClosePack.gif">
                                            </asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            PR #:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPRno" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                        <td>
                                            Patient:
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblPatient" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Lab ID:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLabID" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                        <td>
                                            Despatch Time:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDespatchTime" runat="server" ForeColor="DarkBlue"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lbtnOrderByLabID" OnClick="lbtnOrderByLabID_Click" runat="server">Order By LabID</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lbtnOtherTest" OnClick="lbtnOtherTest_Click" runat="server">Other Test</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnViewHistory" OnClick="lbtnViewHistory_Click" runat="server">Patient History</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblTest" runat="server" Font-Bold="True" ForeColor="DarkBlue" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;
                                            <asp:Label ID="lblSelMode" runat="server" Font-Bold="True" ForeColor="Navy" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                            <asp:Label ID="lblBookingID" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                            <asp:Label ID="lblTestID" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPRID" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <div style="left: 550px; position: absolute; top: 20px; background-color: #ccccff">
                                                <asp:ImageButton ID="ibtnCloseOtherTest" OnClick="ibtnCloseOtherTest_Click" runat="server"
                                                    Visible="False" ImageUrl="~/images/Cancel.png" ToolTip="Click to close this screen">
                                                </asp:ImageButton>
                                                <asp:Panel ID="pnlOtherTest" runat="server" Visible="false" Width="500px" BorderStyle="Solid"
                                                    BorderWidth="1" ScrollBars="Auto" Height="200px">
                                                    <asp:GridView ID="gvAllTestDetail" runat="server" Visible="False" Width="100%" CssClass="datagrid"
                                                        OnRowCommand="gvAllTestDetail_RowCommand" AutoGenerateColumns="False" DataKeyNames="bookingid,Bookingdid,testid,processid"
                                                        OnRowDataBound="gvAllTestDetail_RowDataBound" EnableTheming="True">
                                                        <RowStyle CssClass="gridItem"></RowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="test_name" HeaderText="Test">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="name" HeaderText="Status">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="origin" HeaderText="Origin">
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:CommandField SelectText="View" ShowSelectButton="True">
                                                                <ItemStyle Width="10%"></ItemStyle>
                                                            </asp:CommandField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="gridheader"></HeaderStyle>
                                                        <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </div>
                                            <asp:LinkButton ID="lbtntest" runat="server" __designer:wfdid="w28"></asp:LinkButton><cc1:ModalPopupExtender
                                                ID="mde_intcmt" runat="server" __designer:wfdid="w29" Y="100" X="300" PopupControlID="pnlInt_cmmnt"
                                                DropShadow="true" BackgroundCssClass="TransparentGrayBackground" CancelControlID="imgCmt_Close"
                                                TargetControlID="lbtntest">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="pnlInt_cmmnt" runat="server" Width="500px" ScrollBars="Vertical" Height="420px"
                                                __designer:wfdid="w1" CssClass="mPopup">
                                                <table id="tb_cpy" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <strong>Internal Comment</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="4">
                                                                <asp:Label ID="lblTest_intCmt" runat="server" Font-Bold="True" __designer:wfdid="w2"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblInt_testID" runat="server" Visible="False" __designer:wfdid="w3"></asp:Label>&nbsp;
                                                            </td>
                                                            <td align="right" colspan="3">
                                                                <asp:Label ID="lblInt_BookingID" runat="server" Visible="False" __designer:wfdid="w4"></asp:Label>
                                                                <asp:Label ID="lblInt_Index" runat="server" Visible="False" __designer:wfdid="w5"></asp:Label>
                                                                <asp:ImageButton ID="imgcmt_save" OnClick="imgcmt_save_Click" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                                                    __designer:wfdid="w6"></asp:ImageButton><asp:ImageButton ID="imgCmt_Close" runat="server"
                                                                        ImageUrl="~/images/ClosePack.gif" __designer:wfdid="w7"></asp:ImageButton>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="4">
                                                                <asp:Panel ID="pnlW2" runat="server" Font-Bold="True" Width="30%" ToolTip="Click here to add comment"
                                                                    Height="22px" __designer:wfdid="w8">
                                                                    <asp:Image ID="imgW" runat="server" ImageUrl="~/images/expandw.jpg" __designer:wfdid="w9">
                                                                    </asp:Image>&nbsp; Add comment</asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:UpdatePanel ID="up_ur" runat="server" __designer:wfdid="w10">
                                                                    <ContentTemplate>
                                                                        <asp:Panel ID="pnl_ad_Cmt" runat="server" Width="99%" __designer:wfdid="w11">
                                                                            <table id="tb_ad" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Stage:<cc1:CollapsiblePanelExtender ID="cpeWaiting" runat="server" __designer:wfdid="w12"
                                                                                                TargetControlID="pnl_ad_Cmt" SuppressPostBack="true" ImageControlID="imgW" ExpandedText="Hide Details..."
                                                                                                ExpandedImage="../images/collapsew.jpg" ExpandControlID="pnlW2" CollapsedText="Show details..."
                                                                                                CollapsedImage="../images/expandw.jpg" CollapseControlID="pnlW2" AutoCollapse="false">
                                                                                            </cc1:CollapsiblePanelExtender>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlFor_Process" runat="server" Width="98%" __designer:wfdid="w13"
                                                                                                CssClass="dropdown">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            Comment:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtInt_Comnt" runat="server" Width="98%" Height="87px" __designer:wfdid="w14"
                                                                                                CssClass="field" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 20%">
                                                                                        </td>
                                                                                        <td style="width: 80%">
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="gvIntComment" runat="server" __designer:wfdid="w15" CssClass="datagrid"
                                                                    AutoGenerateColumns="False">
                                                                    <RowStyle CssClass="gridItem" />
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
                                                                    <HeaderStyle CssClass="gridheader" />
                                                                    <AlternatingRowStyle CssClass="gridAlternate" />
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
                                        <td width="10%">
                                        </td>
                                        <td width="18%">
                                        </td>
                                        <td width="15%">
                                        </td>
                                        <td width="23%">
                                        </td>
                                        <td width="10%">
                                        </td>
                                        <td width="23%">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style="border-right: teal thin solid; border-top: teal thin solid; border-left: teal thin solid;
                                border-bottom: teal thin solid" id="tb_attrib" class="label" cellspacing="1"
                                cellpadding="1" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td colspan="6">
                                            <asp:GridView ID="gvMain" runat="server" CssClass="datagrid" OnRowCommand="gvMain_RowCommand"
                                                AutoGenerateColumns="False" DataKeyNames="bookingid,Bookingdid,testid,ProcedureID,clinicaluse,automatedtext"
                                                OnRowDataBound="gvMain_RowDataBound">
                                                <RowStyle CssClass="gridItem"></RowStyle>
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <img id="image_" height="16" src="../images/expand.gif" width="16" runat="server">
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="5%"></HeaderStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Test_Name" HeaderText="Test">
                                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" Font-Bold="True" Font-Size="Medium"
                                                            Font-Underline="False" Width="50%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Font-Bold="True" Font-Italic="False" Font-Underline="True">
                                                        </ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnInterpretation" runat="server" Text="Interpretation">	
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="lbtnClinicalUse" runat="server" Text=" Clinical Information">
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="lbtnAdd_Attrib" OnClick="lbtnAdd_Attrib_Click" runat="server"
                                                                Text="Add Attribute">	
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="45%"></HeaderStyle>
                                                    </asp:TemplateField>
                                                    <asp:CommandField SelectText="&lt;img src='../images/comment_add.png' border='0' /&gt;"
                                                        ShowSelectButton="True"></asp:CommandField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:GridView ID="gvAttribute" runat="server" Width="100%" OnRowDataBound="gvAttribute_RowDataBound"
                                                                        AutoGenerateColumns="False" DataKeyNames="attributeid,testid,rangeid,attribute_type,min_value,max_value,TotalText,Heading,a_dorder,attribute_name"
                                                                        CssClass="datagrid">
                                                                        <RowStyle CssClass="gridItem"></RowStyle>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Print">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkRPrint" runat="server" Text=" " Enabled="True" Checked='<%# (DataBinder.Eval(Container.DataItem, "print").ToString() == "Y") %>'>
                                                                                    </asp:CheckBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Attribute_name" HeaderText="Attribute" ReadOnly="True"
                                                                                SortExpression="Attribute">
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Result">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtResult" runat="server" Width="96%" Class="field" ToolTip="Please enter attribute result"
                                                                                        Text='<%# DataBinder.Eval(Container.DataItem,"defaulttemplate").ToString() %>'
                                                                                        Rows='<%# int.Parse(DataBinder.Eval(Container.DataItem, "LinesNo").ToString()) %>'
                                                                                        TextMode='<%# GetTextmode((string)DataBinder.Eval(Container.DataItem, "LinesNo")) %>'>
                                                                                    </asp:TextBox><br />
                                                                                    <asp:ListBox ID="lbTemplate" runat="server" Visible="False" Width="97%" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="lbTemplate_SelectedIndexChanged"></asp:ListBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgAtt_Temp" Visible='<%# (DataBinder.Eval(Container.DataItem, "Template").ToString() == "Y") %>'
                                                                                        runat="server" ImageUrl="~/images/btn_Blank.GIF" OnClick="imgAtt_Temp_Click" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="5%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="ranges" HeaderText="Ranges">
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="aunit" HeaderText="Unit">
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="11%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="gridheader"></HeaderStyle>
                                                                        <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:Panel ID="pnlMicro" runat="server" Width="100%" BorderWidth="1" BorderStyle="Solid">
                                                                        <table style="width: 100%" id="tblMicro" class="label" cellspacing="1" cellpadding="1"
                                                                            border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td colspan="6">
                                                                                        <strong>Senstivity : </strong>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 7%">
                                                                                        Organism:
                                                                                    </td>
                                                                                    <td style="width: 26%">
                                                                                        <asp:DropDownList ID="ddlOrganism" runat="server" Width="95%" OnSelectedIndexChanged="ddlOrganism_SelectedIndexChanged"
                                                                                            AutoPostBack="True">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 7%">
                                                                                    </td>
                                                                                    <td style="width: 26%">
                                                                                    </td>
                                                                                    <td style="width: 7%">
                                                                                    </td>
                                                                                    <td style="width: 27%">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:GridView ID="gvMicro" runat="server" Width="99%" CssClass="datagrid" DataKeyNames="DrugID"
                                                                                            AutoGenerateColumns="False">
                                                                                            <RowStyle CssClass="gridItem" />
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="Drug" HeaderText="Drug">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="60%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Button ID="btnMicroI" Font-Bold="true" Text="I" runat="server" BackColor="skyblue"
                                                                                                            Width="25%" OnClick="btnRes_Click" />
                                                                                                        <asp:Button ID="btnMicroS" Font-Bold="true" Text="S" runat="server" BackColor="skyblue"
                                                                                                            Width="25%" OnClick="btnRes_Click" />
                                                                                                        <asp:Button ID="btnMicroR" Font-Bold="true" Text="R" runat="server" BackColor="skyblue"
                                                                                                            Width="25%" OnClick="btnRes_Click" />
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <HeaderStyle CssClass="gridheader" />
                                                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                    <td colspan="4" align="left" valign="top">
                                                                                        <asp:GridView ID="gvSelectedMicro" runat="server" Width="80%" CssClass="datagrid"
                                                                                            DataKeyNames="OrganismID,DrugID" AutoGenerateColumns="False" OnRowCommand="gvSelectedMicro_RowCommand">
                                                                                            <RowStyle CssClass="gridItem" />
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="SNo" HeaderText="S#">
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Organism" HeaderText="Organism">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Drug" HeaderText="Drug">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="Senstivity" HeaderText="Senstivty">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                                </asp:BoundField>
                                                                                                <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
                                                                                            </Columns>
                                                                                            <HeaderStyle CssClass="gridheader" />
                                                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Comment:
                                                                </td>
                                                                <td colspan="5" rowspan="2">
                                                                    <asp:TextBox ID="txtComment" runat="server" Width="94%" CssClass="field" TextMode="MultiLine"
                                                                        ToolTip="Please enter result comment">
                                                                    </asp:TextBox>
                                                                    <asp:ImageButton ID="img_Add_Cmt" OnClick="img_Add_Cmt_Click" runat="server" ImageUrl="~/images/btn_Blank.GIF">
                                                                    </asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Opinion:
                                                                </td>
                                                                <td colspan="5" rowspan="2">
                                                                    <asp:TextBox ID="txtOpinion" runat="server" Width="94%" CssClass="field" TextMode="MultiLine"
                                                                        ToolTip="Please enter result opinion">
                                                                    </asp:TextBox>
                                                                    <asp:ImageButton ID="img_add_Opn" OnClick="img_add_Opn_Click" runat="server" ImageUrl="~/images/btn_Blank.GIF">
                                                                    </asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Forward:
                                                                </td>
                                                                <td colspan="5" rowspan="1">
                                                                    <asp:DropDownList ID="ddlForward" runat="server" Width="20%" CssClass="dropdown">
                                                                        <%--DataSource='<%# Fill_Forward(DataBinder.Eval(Container.DataItem, "ProcedureID").ToString()) %>' DataTextField="name" DataValueField="ProcessID" SelectedIndex='<%# GetForwardIndex(DataBinder.Eval(Container.DataItem, "ProcedureID").ToString()) %>'--%>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="right">
                                                                    <asp:Button ID="btnTestSavePrint" runat="server" OnClick="btnTestSavePrint_Click"
                                                                        Font-Bold="True" ForeColor="Navy" Width="85px" Visible="false" Text="Save & Print" BackColor="SkyBlue">
                                                                    </asp:Button>
                                                                    <asp:ImageButton ID="imgSaveTest" OnClick="imgSaveTest_Click" runat="server" ImageUrl="~/images/SavePack_2.gif">
                                                                    </asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 10%">
                                                                </td>
                                                                <td style="width: 23%">
                                                                </td>
                                                                <td style="width: 10%">
                                                                </td>
                                                                <td style="width: 23%">
                                                                </td>
                                                                <td style="width: 10%">
                                                                </td>
                                                                <td style="width: 24%">
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvQueue" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="gvTest_Template" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="up_tem" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlComent" runat="server">
                            <table id="tb_tem" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgTem_Close" runat="server" ImageUrl="~/images/ClosePack.gif"
                                            OnClick="imgTem_Close_Click"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="gvTest_Template" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                            OnRowCommand="gvTest_Template_RowCommand">
                                            <RowStyle CssClass="gridItem" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S#">
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>:
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="template">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" Width="90%" />
                                                </asp:BoundField>
                                                <asp:CommandField SelectText="Add" ShowSelectButton="True" />
                                            </Columns>
                                            <HeaderStyle CssClass="gridheader" />
                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="90%">
                                    </td>
                                    <td width="10%">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:AsyncPostBackTrigger ControlID="img_Add_Cmt" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="img_add_Opn" EventName="Click"></asp:AsyncPostBackTrigger>--%>
                    </Triggers>
                </asp:UpdatePanel>
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
                &nbsp;
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
            <td colspan="4">
                <asp:UpdatePanel ID="up_pnl_sel" runat="Server">
                    <ContentTemplate>
                        <asp:Panel ID="pnl_sel" runat="server" Font-Bold="True" Width="98%">
                            <table id="tb_select" class="label" cellspacing="1" cellpadding="1" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <asp:LinkButton ID="lbtnPatientTrack" OnClick="lbtnPatientTrack_Click" runat="server">Patient Investigation Tracking</asp:LinkButton>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnToday" OnClick="btnToday_Click" runat="server" BackColor="SkyBlue"
                                                Text="Today" BorderColor="#FFC0C0"></asp:Button>
                                            <asp:Button ID="btnlastDays" OnClick="btnlastDays_Click" runat="server" BackColor="SkyBlue"
                                                Text="Last 2 Days" BorderColor="#FFC0C0"></asp:Button>
                                            <asp:ImageButton ID="imgRefresh" OnClick="imgRefresh_Click" runat="server" ImageUrl="~/images/Refresh.gif">
                                            </asp:ImageButton><asp:ImageButton ID="imgCLose" OnClick="imgCLose_Click" runat="server"
                                                ImageUrl="~/images/ClosePack.gif"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Department:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubdept" runat="server" Width="98%" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlSubdept_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            Group:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTestGroup" runat="server" Width="99%" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlTestGroup_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Type:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlType" runat="server">
                                                <asp:ListItem Value="A">All</asp:ListItem>
                                                <asp:ListItem Value="O">OutDoor</asp:ListItem>
                                                <asp:ListItem Value="I">Indoor</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            From:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFrom" runat="server" Width="22%" CssClass="field"></asp:TextBox>&nbsp;
                                            To:<asp:TextBox ID="txtTo" runat="server" Width="22%" CssClass="field"></asp:TextBox>
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
                                            <cc1:CalendarExtender ID="cal_frm" runat="server" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                                PopupButtonID="txtFrom">
                                            </cc1:CalendarExtender>
                                            <cc1:CalendarExtender ID="cal_to" runat="server" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                                PopupButtonID="txtTo">
                                            </cc1:CalendarExtender>
                                            <cc1:MaskedEditExtender ID="msk_Frmcal" runat="server" TargetControlID="txtFrom"
                                                MaskType="date" Mask="99/99/9999">
                                            </cc1:MaskedEditExtender>
                                            <cc1:MaskedEditExtender ID="msk_Tocal" runat="server" TargetControlID="txtTo" MaskType="date"
                                                Mask="99/99/9999">
                                            </cc1:MaskedEditExtender>
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
                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:AsyncPostBackTrigger ControlID="imgClose_pnl" EventName="Click"></asp:AsyncPostBackTrigger>--%>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="4">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="up_gr_sp" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblLess" runat="server" ForeColor="Black" __designer:dtid="281474976710699"
                            BackColor="#66CC99" BorderWidth="1px" __designer:wfdid="w25"></asp:Label>&nbsp;<asp:Label
                                ID="lblGreater" runat="server" ForeColor="Indigo" __designer:dtid="281474976710700"
                                BackColor="WhiteSmoke" BorderWidth="1px" __designer:wfdid="w26"></asp:Label>&nbsp;<asp:Label
                                    ID="lblOverdue" runat="server" ForeColor="WhiteSmoke" __designer:dtid="281474976710701"
                                    BackColor="#CC3366" BorderWidth="1px" __designer:wfdid="w27"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblMode" runat="server" Font-Bold="True" ForeColor="Navy" __designer:dtid="562949953421618"
                            Text="Mode : Despatch Time" __designer:wfdid="w28"></asp:Label><br />
                        <asp:GridView ID="gvQueue" runat="server" Width="100%" __designer:wfdid="w29" CssClass="datagrid"
                            OnRowCommand="gvQueue_RowCommand" AutoGenerateColumns="False" DataKeyNames="prno,panel,authorizeno,testid,acronym,totalyear,bookingid,prid,clinicaluse,automatedtext,gender,priority"
                            OnRowDataBound="gvQueue_RowDataBound" OnSorting="gvQueue_Sorting" AllowSorting="True">
                            <RowStyle CssClass="gridItem"></RowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>:
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lab ID">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnGvLabID" runat="server" __designer:wfdid="w15" OnClick="lbtnGvLabID_Click"
                                            Text='<%# DataBinder.Eval(Container.DataItem,"labid").ToString() %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Patient">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnGvPatient" runat="server" OnClick="lbtnGvPatient_Click" Text='<%# DataBinder.Eval(Container.DataItem,"patientname").ToString() %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="testname" HeaderText="Test" SortExpression="testname">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="deliverytime" HeaderText="Despatch Time" SortExpression="deliverytime">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="referenceno" HeaderText="Reference No" SortExpression="referenceno">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="bookedon" HeaderText="Booked On" SortExpression="bookedon">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <ItemStyle Width="5%"></ItemStyle>
                                </asp:CommandField>
                                <asp:BoundField DataField="adm_info" HeaderText="Adm Info">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="origin" HeaderText="Origin">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass="gridheader"></HeaderStyle>
                            <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSubdept" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="ddlTestGroup" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="imgRefresh" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="imgClose_pnl" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
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
            <td colspan="4">
                &nbsp;
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
