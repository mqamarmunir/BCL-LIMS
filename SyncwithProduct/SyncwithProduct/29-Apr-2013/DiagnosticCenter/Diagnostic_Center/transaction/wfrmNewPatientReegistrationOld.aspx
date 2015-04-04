<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmNewPatientReegistrationOld.aspx.cs" Inherits="transaction_wfrmNewPatientReegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <script language="javascript" type="text/javascript">

<!--

     function changeParameter() {

         if (document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle").selectedIndex == 1) {
             document.getElementById('ctl00_ContentPlaceHolder1_ddlMarital').selectedIndex = 1;
             document.getElementById('ctl00_ContentPlaceHolder1_rdbMale').checked = true;

         }
         else if (document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle").selectedIndex == 4) {
             document.getElementById('ctl00_ContentPlaceHolder1_ddlMarital').selectedIndex = 1;
             document.getElementById('ctl00_ContentPlaceHolder1_rdbMale').checked = true;

         }
         else if (document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle").selectedIndex == 5) {
             document.getElementById('ctl00_ContentPlaceHolder1_ddlMarital').selectedIndex = 1;
             document.getElementById('ctl00_ContentPlaceHolder1_rdbMale').checked = true;

         }

         else if (document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle").selectedIndex == 2) {
             document.getElementById('ctl00_ContentPlaceHolder1_ddlMarital').selectedIndex = 1;
             document.getElementById('ctl00_ContentPlaceHolder1_rdbFemle').checked = true;
         }

         else if (document.getElementById("ctl00_ContentPlaceHolder1_ddlTitle").selectedIndex == 3) {
             document.getElementById('ctl00_ContentPlaceHolder1_ddlMarital').selectedIndex = 2;
             document.getElementById('ctl00_ContentPlaceHolder1_rdbFemle').checked = true;
         }

         else {
             document.getElementById('ctl00_ContentPlaceHolder1_ddlMarital').selectedIndex = 0;
             document.getElementById('ctl00_ContentPlaceHolder1_rdbFemle').checked = false;
             document.getElementById('ctl00_ContentPlaceHolder1_rdbMale').checked = false;
         }


     }

//-->

</script>
   <ContentTemplate>
 <div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Patient Registration &amp; Investigation Booking</div>
    <table id="main" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
        <tr>
            <td align="left" class="tdheading" colspan="8">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <%--Patient Registration &amp; Investigation Booking--%></td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
            <asp:UpdatePanel ID="up_err" runat="server">
                <ContentTemplate>
<asp:Label id="lblError" runat="server" __designer:wfdid="w1"></asp:Label> 
</ContentTemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="lbtnSaveDependent" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
            </asp:UpdatePanel>
                </td>
            <td colspan="3" align="right">
                <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif"
                    OnClick="imgSearch_Click" AccessKey="r" ToolTip="Click or Press Alt+r to Detail Search" /><asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/SavePack.gif" OnClick="imgSave_Click" AccessKey="s" ToolTip="Click or Press Alt+s to save test booking" TabIndex="14" /><asp:ImageButton
                    ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click" AccessKey="x" ToolTip="Click or Press Alt+x to clear this screen" TabIndex="15" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" AccessKey="c" ToolTip="Click or Press Alt+c to close this screen" TabIndex="16" /></td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td align="right" colspan="4">
                &nbsp; &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtnPatientTrack" runat="server" OnClick="lbtnPatientTrack_Click" Font-Size="10px" Visible="false">Patient Investigation Tracking</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="8">
           <asp:UpdatePanel id="up_empInfo" runat="server"><ContentTemplate>
<asp:Panel id="pnl_panelInfo" runat="server" Font-Bold="True" Width="99%" GroupingText="Employee Info">
<TABLE id="tb_PanelInfo" class="listing" cellSpacing=1 cellPadding=1 width="100%" border=0>
<TBODY><TR><TD>PR #:</TD>
<TD>
<asp:Label id="lblPR_Parent_Panel" runat="server" ForeColor="darkblue" Text=""></asp:Label>
</TD>
<TD>Name:</TD>
<TD><asp:Label id="lblParent_Panel" runat="server" ForeColor="darkblue" Text=""></asp:Label></TD>
<TD>Service #:</TD>
<TD><asp:Label id="lblServ_Panel" runat="server" ForeColor="darkblue" Text=""></asp:Label> 
<asp:Label id="lblMarit_Panel" runat="server" Visible="False"></asp:Label></TD>
<TD>Panel:</TD><TD><asp:Label id="lblCmp_panel" runat="server" ForeColor="DarkBlue"></asp:Label></TD></TR><TR>
    <TD width="5%" class="style1"></TD><TD width="15%" class="style1"></TD>
    <TD width="5%" class="style1"></TD><TD width="20%" class="style1"></TD>
    <TD width="8%" class="style1"></TD><TD width="20%" class="style1"></TD>
    <TD width="5%" class="style1"></TD><TD width="22%" class="style1"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
               <triggers>
<asp:AsyncPostBackTrigger ControlID="gvDependent" EventName="RowCommand"></asp:AsyncPostBackTrigger>
</triggers>
           </asp:UpdatePanel>        
            </td>
        </tr>
        <tr>
            <td colspan="8">
            
             <asp:UpdatePanel ID = "up_pateintInfo" runat="server">
                <ContentTemplate>
<asp:Panel id="pnlPatient" runat="server" Font-Bold="True" Width="99%" GroupingText="Patient Info">
<TABLE id="tb_patient" class="label" cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TBODY><TR><TD>PR No:</TD><TD>
        <asp:TextBox id="txtPRnO" runat="server" ToolTip="Please enter PR #" Width="65%" CssClass="txtareaStyle"></asp:TextBox> 
        <asp:ImageButton id="imgPRno" onclick="imgPRno_Click" runat="server" ImageUrl="~/images/btn_Blank.GIF"></asp:ImageButton>
        </TD><TD></TD>
        <TD align=left colSpan=3>
        <asp:RadioButton id="rdbCash" runat="server" Font-Bold="True" ForeColor="Teal" __designer:wfdid="w31" Text="Cash" OnCheckedChanged="rdbCash_CheckedChanged" AutoPostBack="True" GroupName="CHK"></asp:RadioButton> 
        <asp:RadioButton id="rdbPanel" runat="server" Font-Bold="True" ForeColor="Teal" __designer:wfdid="w32" Text="Panel" OnCheckedChanged="rdbPanel_CheckedChanged" AutoPostBack="True" GroupName="CHK"></asp:RadioButton>
        <asp:RadioButton id="rdbPnl_Cash" runat="server" Font-Bold="True" ForeColor="Teal" __designer:wfdid="w33" Text="Panel-Cash" OnCheckedChanged="rdbPnl_Cash_CheckedChanged" AutoPostBack="True" GroupName="CHK"></asp:RadioButton>
        <asp:Label id="lblRela_hd" runat="server" __designer:wfdid="w34" Text="Relation:"></asp:Label>&nbsp;
        </TD><TD>
        <asp:DropDownList id="ddlRelation" runat="server" Width="100%" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlRelation_SelectedIndexChanged">
        <asp:ListItem Value="-1">Select</asp:ListItem>
<asp:ListItem>Self</asp:ListItem>
<asp:ListItem>H/O</asp:ListItem>
<asp:ListItem>W/O</asp:ListItem>
<asp:ListItem>S/O</asp:ListItem>
<asp:ListItem>D/O</asp:ListItem>
<asp:ListItem>F/O</asp:ListItem>
<asp:ListItem>M/O</asp:ListItem>
</asp:DropDownList>
 <asp:Label id="lblName_Panel" runat="server" ForeColor="DarkBlue"></asp:Label>
 </TD><TD>&nbsp;</TD></TR>
 <TR><TD colSpan=8>
 <asp:Panel id="pnlPanel" runat="server" Width="99%">
 <TABLE id="tb_panel" class="label" cellSpacing=0 cellPadding=0 width="100%" border=0>
 <TBODY><TR>
 <TD>Panel Company:</TD>
 <TD>
 <asp:DropDownList id="ddlPanel" runat="server" ToolTip="Please select panel company" Width="100%" CssClass="dropdownMan" AutoPostBack="false" OnSelectedIndexChanged="ddlPanel_SelectedIndexChanged">
                                                </asp:DropDownList></TD>
                                                <TD align=center>Employee No:</TD>
        <TD><asp:TextBox id="txtSErviceNO" runat="server" ToolTip="Please enter patient service number" Width="85%" CssClass="mandatoryField" MaxLength="10"></asp:TextBox>
        </TD>
        <TD align=left>Referecnce:</TD><TD>
        <asp:TextBox ID="txtReferenceNo" runat="server" __designer:wfdid="w1" 
            CssClass="txtareaStyle" MaxLength="25" Width="90%"></asp:TextBox>
    </TD></TR><TR><TD width="10%">
        <asp:CheckBox ID="chbOnCash0" runat="server" __designer:wfdid="w1" 
            Text="Panel-Cash" Visible="False" />
        </TD><TD width="33%">
            <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdown" 
                Visible="false" Width="100%">
            </asp:DropDownList>
        </TD><TD width="10%">
            <asp:ImageButton ID="imgService0" runat="server" 
                ImageUrl="~/images/btn_Blank.GIF" onclick="imgService_Click" Visible="False" />
        </TD><TD width="20%"></TD><TD width="10%"></TD><TD width="16%"></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD>Salutation:</TD><TD><asp:DropDownList id="ddlTitle" tabIndex=1 runat="server" ToolTip="Please select Salutation" Width="40%" CssClass="dropdown" onchange="changeParameter();"><asp:ListItem Value="-1">Select</asp:ListItem>
<asp:ListItem Value="Mr">Mr</asp:ListItem>
<asp:ListItem Value="Ms">Miss</asp:ListItem>
<asp:ListItem Value="Mrs">Mrs</asp:ListItem>
<asp:ListItem>Baby</asp:ListItem>
<asp:ListItem>Master</asp:ListItem>
</asp:DropDownList>&nbsp; 
<asp:CheckBox id="chkTitleENB" runat="server" __designer:wfdid="w1" Text="Skip Title" OnCheckedChanged="chkTitleENB_CheckedChanged" AutoPostBack="True" Checked="True"></asp:CheckBox>
</TD><TD align=right>Name:&nbsp; </TD>
<TD colSpan=3><asp:TextBox id="txtName" tabIndex=2 onkeyup="this.value=TitleCase(this);" runat="server" ToolTip="Please enter patient name" Width="97%" CssClass="txtareaMandatory" MaxLength="95"></asp:TextBox>
</TD><TD>Gender:</TD><TD>
<asp:RadioButton id="rdbMale" tabIndex=3 runat="server" Text="Male" GroupName="Gender"></asp:RadioButton> 
<asp:RadioButton id="rdbFemle" tabIndex=4 runat="server" Text="Female" GroupName="Gender"></asp:RadioButton></TD>
</TR><TR>
<TD>DOB:</TD><TD>
<asp:TextBox id="txtDOB" tabIndex=5 runat="server" ToolTip="Enter date of birth here or age in next box" Width="40%" CssClass="txtareaMandatory"></asp:TextBox>
</TD>
<TD align=right>Age:&nbsp; </TD>
<TD><asp:TextBox id="txtAge" tabIndex=6 runat="server" ToolTip="Enter age in years " Width="30%" CssClass="mandatoryField" MaxLength="3"></asp:TextBox>
 <asp:DropDownList id="ddlAge_Opt" runat="server" Width="60%" __designer:wfdid="w1">
 <asp:ListItem Value="Y">Year(s)</asp:ListItem>
<asp:ListItem Value="M">Month(s)</asp:ListItem>
<asp:ListItem Value="D">Day(s)</asp:ListItem>
</asp:DropDownList></TD>

<TD align=right>Cell No:&nbsp; </TD><TD><asp:TextBox id="txtCellNo" tabIndex=7 runat="server" ToolTip="Please enter patient cell number" Width="94%" CssClass="txtareaStyle" MaxLength="20"></asp:TextBox></TD><TD>Marital Status:</TD><TD><asp:DropDownList id="ddlMarital" tabIndex=8 runat="server" ToolTip="Please select Patient Marital Status" Width="60%" CssClass="dropdownMan">
                                    <asp:ListItem Value="-1">Select</asp:ListItem>
                                    <asp:ListItem Value="S">Single</asp:ListItem>
                                    <asp:ListItem Value="M">Married</asp:ListItem>
                                </asp:DropDownList></TD></TR><TR><TD>Phone No:</TD><TD><asp:TextBox id="txtHPHone" tabIndex=9 runat="server" ToolTip="Please enter patient phone number" Width="97%" CssClass="txtareaStyle" MaxLength="20"></asp:TextBox></TD><TD align=right>Fax:&nbsp; </TD><TD><asp:TextBox id="txtFax" tabIndex=10 runat="server" ToolTip="Please enter patient fax number" Width="95%" CssClass="txtareaStyle" MaxLength="20"></asp:TextBox></TD><TD align=right>CNIC:&nbsp; </TD><TD><asp:TextBox id="txtCNIC" tabIndex=11 runat="server" ToolTip="Please enter patient CNIC" CssClass="txtareaStyle"></asp:TextBox></TD><TD>
        &nbsp;</TD><TD>&nbsp;</TD></TR><TR><TD>Email:</TD><TD><asp:TextBox id="txtEmail" tabIndex=12 runat="server" ToolTip="Please enter patient email address" Width="95%" CssClass="txtareaStyle"></asp:TextBox></TD><TD align=right>Address:</TD><TD colSpan=3><asp:TextBox id="txtAddress" tabIndex=13 runat="server" ToolTip="Please enter patient address" Width="85%" CssClass="txtareaStyle" Height="39px" TextMode="MultiLine"></asp:TextBox></TD><TD>Remarks: &nbsp; <asp:LinkButton id="lbtnAdd_Rmk" onclick="lbtnAdd_Rmk_Click" runat="server" __designer:wfdid="w1">Add</asp:LinkButton></TD><TD><asp:TextBox id="txtRemark" runat="server" Width="78%" CssClass="txtareaStyle" __designer:wfdid="w2" TextMode="MultiLine"></asp:TextBox><asp:ImageButton id="imgOpn_Rmk" onclick="imgOpn_Rmk_Click" runat="server" ImageUrl="~/images/expandw.jpg" __designer:wfdid="w3"></asp:ImageButton></TD></TR><TR><TD></TD><TD></TD><TD align=right></TD><TD colSpan=3></TD><TD></TD><TD><asp:ListBox id="lbTemplate" runat="server" Visible="False" Width="97%" __designer:wfdid="w4" AutoPostBack="True" OnSelectedIndexChanged="lbTemplate_SelectedIndexChanged">
																</asp:ListBox></TD></TR><TR><TD></TD><TD><asp:Label id="lblID" runat="server" Visible="False"></asp:Label></TD><TD></TD><TD><asp:Label id="lblStatus" runat="server" Visible="False"></asp:Label></TD><TD></TD><TD><asp:Label id="lblPR_Panel" runat="server" Visible="False"></asp:Label> <asp:Label id="lblF_parent" runat="server" Visible="false" Text=""></asp:Label></TD><TD></TD><TD>&nbsp;<asp:LinkButton id="lbtnSaveDependent" onclick="lbtnSaveDependent_Click" runat="server">Save & Add Dependent</asp:LinkButton></TD></TR><TR><TD></TD><TD colSpan=5><asp:GridView id="gvDependent" runat="server" OnRowCommand="gvDependent_RowCommand" DataKeyNames="prid,f_parent,title,name,cnic,address,panelid,serviceno,fax,panelrelation,panelpatient,cellno,hphone,gender,dob,email,maritalstatus" AutoGenerateColumns="False" CssClass="datagrid">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="S.No"><ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>:
                                                               
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="prno" HeaderText="PR No">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dependent" HeaderText="Dependent">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="relation" HeaderText="Relation">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowSelectButton="True">
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:CommandField>
</Columns>

<SelectedRowStyle CssClass="gridSelectedItem"></SelectedRowStyle>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> </TD><TD></TD><TD></TD></TR><TR><TD colSpan=4><cc1:FilteredTextBoxExtender id="flt_name" runat="server" TargetControlID="txtName" ValidChars="  /" FilterType="Custom,UppercaseLetters,Numbers,LowercaseLetters" ></cc1:FilteredTextBoxExtender> <cc1:FilteredTextBoxExtender id="flt_Age" runat="server" TargetControlID="txtAge" FilterType="Numbers"></cc1:FilteredTextBoxExtender> <cc1:MaskedEditExtender id="msk_prno" runat="server" TargetControlID="txtPRnO" Mask="999-99-99999999" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender> <cc1:MaskedEditExtender id="msk_DOB" runat="Server" TargetControlID="txtDOB" Mask="99/99/9999" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender> <cc1:MaskedEditExtender id="msk_nic" runat="Server" TargetControlID="txtCNIC" Mask="99999-9999999-9" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender> <cc1:TextBoxWatermarkExtender id="wt_ser" watermarkText="ABC-091202" runat="Server" TargetControlID="txtSErviceno" WatermarkCssClass="waterlabel">
                                  </cc1:TextBoxWatermarkExtender> </TD><TD colSpan=4><cc1:TextBoxWatermarkExtender id="wt_pr" watermarkText="001-09-90900786" runat="Server" TargetControlID="txtPRnO" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_Name" watermarkText="Please enter patient name over here" runat="Server" TargetControlID="txtName" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_DOC" watermarkText="01/01/1900" runat="Server" TargetControlID="txtDOB" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_age" watermarkText="26" runat="Server" TargetControlID="txtAge" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_cel" watermarkText="3331234567" runat="Server" TargetControlID="txtCellNo" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_Hphone" watermarkText="21362616" runat="Server" TargetControlID="txtHPHone" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_fax" watermarkText="2136666166" runat="Server" TargetControlID="txtFax" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_CNIC" watermarkText="37405-0011101-1" runat="Server" TargetControlID="txtCNIC" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_email" watermarkText="info@treesvalley.com" runat="Server" TargetControlID="txtEmail" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_address" watermarkText="House # 123,st#4........" runat="Server" TargetControlID="txtAddress" WatermarkCssClass="waterlabel"></cc1:TextBoxWatermarkExtender> </TD></TR><TR><TD width="10%"></TD><TD width="20%"></TD><TD width="5%"></TD><TD width="12%"></TD><TD width="6%"></TD><TD width="18%"></TD><TD width="9%"></TD><TD width="20%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="4">
                &nbsp;</td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="8"><asp:UpdatePanel id="up_auth" runat="server"><ContentTemplate>
<asp:Panel id="pnlGen" runat="server" Font-Bold="True" Width="99%" GroupingText="Referral Info" Height="50px" __designer:errorcontrol="'Enter here if not available in previous list' could not be set on property 'WatermarkText'."><TABLE id="tb_gen" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0>
        <TBODY><TR><TD>
    Referring Doctor:</TD><TD class="mandatoryField"><asp:DropDownList id="ddlDoctor" runat="server" ToolTip="Select referring doctor from list" Width="100%" CssClass="dropdown">
                                </asp:DropDownList></TD><TD><asp:TextBox id="txtReferredBy" runat="server" ToolTip="Enter here if not available in previous list " Width="97%" CssClass="mandatoryField" MaxLength="50"></asp:TextBox></TD><TD align=right>Delivery Mode:</TD><TD class="mandatoryField"><asp:DropDownList id="ddlDeliveryMode" runat="server" ToolTip="Please select report delivery mode" Width="99%" CssClass="dropdown">
                                    <asp:ListItem Value="S">Self Collection</asp:ListItem>
                                    <asp:ListItem Value="E">By Email</asp:ListItem>
                                </asp:DropDownList></TD><TD align=right>Authorization No:</TD><TD><asp:TextBox id="txtAuthorize" runat="server" ToolTip="Please enter authorization number" Width="96%" CssClass="mandatoryField" MaxLength="30"></asp:TextBox> </TD></TR><TR><TD></TD><TD><cc1:TextBoxWatermarkExtender id="wt_ref" watermarkText="Enter here if not available in previous list" runat="Server" WatermarkCssClass="waterlabel" TargetControlID="txtReferredBy"></cc1:TextBoxWatermarkExtender> <cc1:TextBoxWatermarkExtender id="wt_auth" watermarkText="AT-09-099987" runat="Server" WatermarkCssClass="waterlabel" TargetControlID="txtAuthorize"></cc1:TextBoxWatermarkExtender> </TD><TD></TD><TD align=right></TD><TD></TD><TD align=right></TD><TD></TD></TR><TR><TD width="11%"></TD><TD width="18%"></TD><TD width="20%"></TD><TD width="10%"></TD><TD width="14%"></TD><TD width="11%"></TD><TD width="16%"></TD></TR></TBODY></TABLE></asp:Panel> 
</ContentTemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="rdbCash" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="rdbPanel" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td style="width: 180px"></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td class="screenid" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:GridView ID="gvPatient" runat="server" CssClass="listing" AutoGenerateColumns="False" Width="99%" DataKeyNames="prid,title,name,cnic,address,panelid,serviceno,fax,relation,panelpatient,f_parent,email,dob" OnRowCommand="gvPatient_RowCommand">
                    <RowStyle CssClass="Row"/>
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>:
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="prno" HeaderText="PR No">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="patientname" HeaderText="Name">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="18%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="gender" HeaderText="Gender">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dob_age" HeaderText="DOB">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="maritalstatus" HeaderText="Marital Status">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="12%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cellno" HeaderText="Cell No">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hphone" HeaderText="Phone No">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="panelname" HeaderText="Company">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="3%" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle CssClass="gridheader" />
                    <AlternatingRowStyle CssClass="gridAlternate" />
                    <SelectedRowStyle CssClass="gridSelectedItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td style="width: 180px"></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td width="5%"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td style="width: 180px"></td>
            <td width="10%"></td>
            <td width="20%"></td>
            <td width="5%"></td>
        </tr>
    </table>
      </ContentTemplate>
         
</asp:Content>

