<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/Personnel.aspx.cs" Inherits="Personnel" Title="Personnel Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>                                  
  <!--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate> -->
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDOB" Mask="99/99/9999" MaskType="Date"/>                           
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID = "txtNICNo" Mask="99999\-9999999\-9" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="False" />
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtContractExpiry" Mask="99/99/9999" MaskType="Date"  />
           <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtJoiningDate" Mask="99/99/9999" MaskType="Date" />
                                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtRetiringDate" Mask="99/99/9999" MaskType="Date" />
                                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtNICValidUpto" Mask="99/99/9999" MaskType="Date" />
                                <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtPassportValidUpto" Mask="99/99/9999" MaskType="Date" />
           <TABLE class="label" id="Table1"
				cellSpacing="1" cellPadding="1" width="100%" border="0" >								
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG> Personnel Registration</STRONG></font></TD>
				</TR>           
            <tr>
                <td align="right" colspan="7">
                    <asp:ImageButton id="lbtnSave" runat="server" ImageUrl="~/images/SavePack.gif" OnClick="lbtnSave_Click" TabIndex="43" ToolTip="Click to Save Record"></asp:ImageButton><asp:ImageButton id="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="lbtnClearAll_Click" TabIndex="44" ToolTip="Click to Clear Screen"></asp:ImageButton><asp:imagebutton id="btnClose" tabIndex="45" runat="server" ImageUrl="~/images/ClosePack.gif" ToolTip="Click to Close Screen" OnClick="btnClose_Click"></asp:imagebutton></td>
            </tr>				
				<TR>
					<TD colSpan="7"><asp:label id="lblErrMsg" runat="server" ForeColor="Red" Font-Bold="True" Width="100%" TabIndex="100"></asp:label></TD>
				</TR>                
                <tr>
                    <td colspan="3">
                        <strong><span style="font-size: 10pt; text-decoration: underline">&nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; Personal Information:</span></strong>
                     </td>
                    <td ></td>
                    <td> </td>
                    <td></td>
                    <td> </td>
                </tr>
                <tr>
                    <td></td>
                    <td>Name:&nbsp;</td>
                    <td colspan="4">
                    <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="mandatorySelect" TabIndex="1" Width="10%" ToolTip="Pleas select salutation">
                                        <asp:ListItem Value="-1">Select</asp:ListItem>
                                        <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                                        <asp:ListItem Value="Miss.">Miss.</asp:ListItem>
                                        <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
                                        <asp:ListItem>Dr.</asp:ListItem>
                                        <asp:ListItem>Prof.</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtFName" runat="server" CssClass="mandatoryField" MaxLength="30"
                                            TabIndex="2" ToolTip="Enter First Name" Width="28%" BorderStyle="Solid"></asp:TextBox>
                                            <asp:TextBox ID="txtMName" runat="server" MaxLength="30" TabIndex="3"
                                            ToolTip="Enter Middle Name" Width="28%" CssClass="field"></asp:TextBox>
                                      <asp:TextBox ID="txtLName" runat="server" MaxLength="30" TabIndex="4"
                                            ToolTip="Enter Last Name" Width="28%" CssClass="field"></asp:TextBox>                               
                        </td>
                        <td> </td>
                    </tr>                    
                          <tr>
                          <td> </td>
                                    <td class="label">Acronym:</TD>
					                <td>
						                <asp:textbox id="txtAcronym" tabIndex="5" runat="server" Width="112px" ToolTip="Enter Acronym" MaxLength="10" CssClass="mandatoryField" BorderStyle="Solid"></asp:textbox></TD>
					                <td class="label">
                                        <asp:checkbox id="chkActive" tabIndex="6" runat="server" ToolTip="Check for remain Activethroughout the application"
							            Checked="True" Text="Active"></asp:checkbox>
                                        &nbsp;<asp:CheckBox ID="chkCrossLab" runat="server" Text="Coss Lab" /></td>
					                <td style="TEXT-ALIGN: left;" align="right" colspan="2">
                                        &nbsp;<asp:CheckBox ID="chkcros_Dept" runat="server" Text="Cross Dept. View" /></td>
						            <td> </td>
						        </tr>
						        <tr>
						        <td> </td>
						            <td class="label">
                                        Father Name:</td>
                                    <td style ="text-align: left">
                                        <asp:TextBox ID="txtFHName" runat="server" MaxLength="30" TabIndex="7"
                                        ToolTip="Enter Father Name" Width="232px" CssClass="field"></asp:TextBox></td>
                                    <td align="right" style=" text-align: left" colspan="2"></td>
                                    <td align="right" style=" text-align: left"></td>
                                    <td> </td>
						        </tr>
						        <tr>
						        <td> </td>
						            <td class="label">Date of Birth:</td>
						            <td class="label">
						                <asp:TextBox ID="txtDOB" runat="server" CssClass="field" MaxLength="10"
                                        Rows="3" TabIndex="8" ToolTip="Enter Date of Birth" Width="112px" ></asp:TextBox>                                        
                                        (dd/mm/yyyy)
                                    </td>
						            <td class="label">Gender:</td>
						            <td colspan="2">
						               <asp:DropDownList ID="ddlSex" runat="server" CssClass="mandatorySelect" TabIndex="9" ToolTip="Please select gender">
                                                <asp:ListItem Value="-1">Select</asp:ListItem>
                                                <asp:ListItem Value="M">Male</asp:ListItem>
                                                <asp:ListItem Value="F">Female</asp:ListItem>
                                            </asp:DropDownList>
						            </td>
						            <td> </td>
						        </tr>
						         <tr>
						         <td> </td>
                                    <td class="label">NIC No.:</td>
                                    <td><asp:TextBox ID="txtNICNo" runat="server" MaxLength="15" TabIndex="10"
                                    ToolTip="Enter NIC #" Width="161px" CssClass="field"></asp:TextBox>                                     
                                    </td>
                                    <td class="label">NIC Valid Upto</td>
                                    <td colspan="2">                          
                                        <asp:TextBox ID="txtNICValidUpto" runat="server" MaxLength="10"
                                        Rows="3" TabIndex="11" ToolTip="Enter NIC Valid Upto Date" Width="112px" onkeyup = "formatDate(this)" CssClass="field"></asp:TextBox>
                                        (dd/mm/yyyy)</td>
                                    <td> </td>
                                </tr>
                                <tr>
                                <td> </td>
                                    <td class="label">Passport:</td>
                                    <td><asp:TextBox ID="txtPassport" runat="server" MaxLength="20" TabIndex="12"
                                    ToolTip="Enter Passport NO" Width="161px" CssClass="field"></asp:TextBox>
                                    </td>
                                    <td class="label">Passport ValidUpto</td>
                                    <td colspan="2"><asp:TextBox ID="txtPassportValidUpto" runat="server" MaxLength="10" Rows="3"
                                    TabIndex="13" ToolTip="Enter Passport Valid Upto Date" Width="112px" onkeyup = "formatDate(this)" CssClass="field"></asp:TextBox>
                                        (dd/mm/yyyy)</td>
                                    <td> </td>
                                </tr>  
                                <tr>
                                <td> </td>
                                    <td class="label">Marital Status:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="mandatorySelect"
                                            TabIndex="14" ToolTip="Please select Maritail Status">
                                            <asp:ListItem Value="-1">Select</asp:ListItem>
                                            <asp:ListItem Value="S">Single</asp:ListItem>
                                            <asp:ListItem Value="M">Married</asp:ListItem>
                                            </asp:DropDownList>
                                    </td>
                                <td class="label">Blood Group:</td>
                                <td colspan="2">
                               <asp:DropDownList ID="ddlBloodGroup" runat="server" TabIndex="15" ToolTip="Please select blood group">
                                    <asp:ListItem Value="-1">Select</asp:ListItem>
                                    <asp:ListItem Value="A+">A+</asp:ListItem>
                                    <asp:ListItem Value="A-">A-</asp:ListItem>
                                    <asp:ListItem Value="B+">B+</asp:ListItem>
                                    <asp:ListItem Value="B-">B-</asp:ListItem>
                                    <asp:ListItem Value="O+">O+</asp:ListItem>
                                    <asp:ListItem Value="O-">O-</asp:ListItem>
                                    <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                    <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td> </td>
                                </tr>                                                                                                                   
                        <tr>
                            <td colspan="3">
                                <strong><span style="font-size: 10pt; text-decoration: underline">&nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp;&nbsp; Professional Information:</span></strong></td>
                            <td style="width: 144px" width="144">
                            </td>
                            <td align="right" width="13%">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                        <td style="height: 30px; width: 29px;">
                        </td>
                        <td width="15%" style="height: 30px">
                            Organization:</td>
                        <td rowspan="">
                                <asp:DropDownList ID="ddlOrganization" runat="server" Enabled="false" TabIndex="16" Width="100%" CssClass="mandatorySelect" ToolTip="Please select Organization" >
                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 144px; height: 30px;" width="144" align="right">
                            Department:</td>
                            <td colspan="2" class="mandatoryfield">
                            <asp:DropDownList ID="ddlDepartment" runat="server" TabIndex="17" Width="100%" CssClass="mandatorySelect" ToolTip="Please select Department" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                        </td>
                        </tr>
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td width="15%">
                                Designation:</td>
                            <td class="mandatoryfield">
                                <asp:DropDownList ID="ddlDesignation" runat="server" TabIndex="18" Width="100%" CssClass="mandatorySelect" ToolTip="Please select Designation" AutoPostBack="True" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 144px; text-align: right;" width="144">
                                Sub Department:</td>
                            <td colspan="2" class="mandatoryfield">
                                <asp:DropDownList ID="ddlSubDepartment" runat="server" TabIndex="19" Width="100%" CssClass="mandatorySelect" ToolTip="Please select Sub-Department" AutoPostBack="True" OnSelectedIndexChanged="ddlSubDepartment_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td>
                                Service No:</td>
                            <td style="width: 262px">
                                <asp:TextBox ID="txtServiceNo" runat="server" MaxLength="20"
                                    Rows="3" TabIndex="20" ToolTip="Enter service number" Width="43%" CssClass="field"></asp:TextBox></td>
                            <td style="width: 144px; text-align: right">
                                Employee Code:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtReferenceCode" runat="server" MaxLength="15" TabIndex="21" Width="100%" CssClass="field" ToolTip="Please enter employee code"></asp:TextBox></td>
                            <td style="width: 17px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td>
                                Joining Date:</td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtJoiningDate" runat="server" MaxLength="10"
                                    Rows="3" TabIndex="22" ToolTip="Enter Date of Joining" Width="112px" CssClass="field"></asp:TextBox>
                            (dd/mm/yyyy)</td>                                   
                            <td style="width: 144px; text-align: right">
                                Leaving Date:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtRetiringDate" runat="server" MaxLength="10"
                                    Rows="3" TabIndex="23" ToolTip="Enter Retiring Date" Width="112px" CssClass="field"></asp:TextBox>&nbsp;
                            (dd/mm/yyyy)</td>
                            <td>
                            </td>
                        </tr>         
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td>
                                Education:</td>
                            <td colspan="4">
                                <asp:TextBox ID="txtEducation" runat="server" MaxLength="255" Rows="2"
                                    TabIndex="24" ToolTip="Enter Education" Width="100%" CssClass="field"></asp:TextBox></td>
                            <td>
                            </td>
                        </tr>                      
                        <tr>
                            <td></td>
                            <td >Nature:</td>
                            <td> 
                            <asp:RadioButton ID="rdPermanent" runat="server" Checked="True" GroupName="rdNature"
                                                Text="Permanent" TabIndex="25" />
                                &nbsp; &nbsp;
                                                <asp:RadioButton ID="rdContract" runat="server" GroupName="rdNature" Text="Contract" TabIndex="26" />                                                                                                   
                            </td>
                            <td style="text-align: right; ">
                    Salary:</td>
                            <td align="right" style="text-align: left" colspan="2">
                    <asp:TextBox ID="txtSalary" runat="server" CssClass="field" MaxLength="6" Width="40%" ToolTip="Please enter salary" TabIndex="27"></asp:TextBox></td>
                            <td>
                            </td>
                        </tr>
                             <tr>
                            <td></td>
                            <td >
                                            Contract Expiry:</td>
                            <td> 
                                    
                                            <asp:TextBox ID="txtContractExpiry" runat="server" CssClass="field" MaxLength="10"
                                                Rows="3" TabIndex="28" ToolTip="Enter contract expiry date" Width="112px" ></asp:TextBox>&nbsp;
                                                   
                                   (dd/mm/yyyy)
                            </td>
                            <td style="text-align: right; ">
                    </td>
                            <td align="right" style="text-align: left" colspan="2">
                    </td>
                            <td>
                            </td>
                        </tr>                
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td align="right" colspan="4" style="text-align: left">
                                <strong><span style="font-size: 10pt; text-decoration: underline">Contact Information:</span></strong></td>
                            <td dir="ltr" style="width: 158px">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                Contact No.:</td>
                            <td align="right" colspan="4" style="text-align: left">
                                <table id="Table3" border="0" cellpadding="0" cellspacing="0" style="width: 68%" class="label">
                                    <tr>
                                        <td>
                                            <font size="2">Home</font>
                                            <asp:TextBox ID="txtHPhone1" runat="server" MaxLength="15" TabIndex="29"
                                                ToolTip="Enter Home Contact No" Width="112px" CssClass="field"></asp:TextBox>&nbsp;</td>
                                        <td>
                                            <font size="2"></font>Home2<br />
                                            <asp:TextBox ID="txtHPhone2" runat="server" MaxLength="15" TabIndex="30"
                                                ToolTip="Enter Home2 Contact No" Width="112px" CssClass="field"></asp:TextBox>&nbsp;</td>
                                        <td>
                                            <font size="2"></font>Office1<br />
                                            <asp:TextBox ID="txtOPhone1" runat="server" MaxLength="15" TabIndex="31"
                                                ToolTip="Please enter office2 number" Width="112px" CssClass="field"></asp:TextBox>&nbsp;</td>
                                   <td>
                                       <span style="font-size: 9pt">Office2<br />
                                           <asp:TextBox ID="txtOPhone2" runat="server" CssClass="field"
                                           Width="112px" ToolTip="Please enter office2 number" MaxLength="15" TabIndex="32"></asp:TextBox>&nbsp;</span>
                                           </td>  
                                           <td>
                                       <span style="font-size: 9pt">Cell<br />
                                           <asp:TextBox ID="txtCPhone" runat="server" CssClass="field"
                                           Width="112px" ToolTip="Please enter cell number" MaxLength="15" TabIndex="33"></asp:TextBox>&nbsp;</span>
                                           </td>   
                                           <td>
                                       <span style="font-size: 9pt">Fax<br />
                                           <asp:TextBox ID="txtFaxNo" runat="server" CssClass="field"
                                           Width="112px" ToolTip="Please enter fax number" MaxLength="15" TabIndex="34"></asp:TextBox>&nbsp;</span>
                                           </td>                                                                                
                                    </tr>
                                </table>
                            </td>                            
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 12px; width: 29px;">
                            </td>
                            <td style="height: 12px">
                                Email Address:</td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Rows="3"
                                    TabIndex="35" ToolTip="Enter Email Address" Width="98%" CssClass="field"></asp:TextBox></td>
                            <td style="text-align: right">
                                </td>
                            <td colspan="2">
                                </td>
                            <td>
                            </td>
                        </tr>        
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td>
                                Current Address:</td>
                            <td>
                                <asp:TextBox ID="txtCurrentAddress" runat="server" MaxLength="250" Rows="2"
                                    TabIndex="36" TextMode="MultiLine" ToolTip="Enter Current Address" Width="98%" CssClass="field"></asp:TextBox></td>
                            <td style="text-align: right">
                                Permanent Address:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPermanentddress" runat="server" MaxLength="250" Rows="2"
                                    TabIndex="37" TextMode="MultiLine" ToolTip="Enter Permanent Address" Width="98%" CssClass="field"></asp:TextBox></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td colspan="2">
                                <strong><span style="font-size: 10pt; text-decoration: underline">Login Information:</span></strong></td>
                            <td style="width: 144px; text-align: right">
                                Old Password:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCurPas" runat="server" Width="50%" TextMode="Password" ToolTip="Enter Old Password" MaxLength="15" CssClass="field" TabIndex="42"></asp:TextBox>
                                <asp:CheckBox ID="chkCHange" runat="server"
                                    Text="Change Password" AutoPostBack="True" OnCheckedChanged="chkCHange_CheckedChanged" TabIndex="41" /></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 26px; width: 29px;">
                            </td>
                            <td style="height: 26px">
                                Login ID:</td>
                            <td style="width: 262px; height: 26px;">
                                <asp:TextBox ID="txtLoginID" runat="server" CssClass="field" MaxLength="15"
                                    TabIndex="38" ToolTip="Enter Login ID" Width="112px"></asp:TextBox>
                                   
                                    </td>
                            <td style="width: 144px; text-align: right; height: 26px;">
                                Password:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="field" MaxLength="15"
                                    TabIndex="39" TextMode="Password" ToolTip="Enter Password" Width="50%"></asp:TextBox>&nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td>
                            </td>
                            <td style="width: 262px">
                                <asp:Label ID="lblpass" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblCnfPas" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblcount" runat="Server" Visible="False"></asp:Label>
                                </td>
                            <td style="width: 144px; text-align: right">
                                Confirm Password</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="field" MaxLength="15"
                                    TabIndex="40" TextMode="Password" ToolTip="Enter Confirm Password" Width="50%"></asp:TextBox></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 29px">
                            </td>
                            <td>
                                <asp:Label ID="lblPersonId" runat="server" Visible="False"></asp:Label></td>
                            <td style="width: 262px">
                                <asp:Label ID="lblstatus" runat="server" Visible="False"></asp:Label></td>
                            <td style="width: 144px; text-align: right">
                            </td>
                            <td colspan="2">
                            </td>
                            <td>
                            </td>
                        </tr>
				<TR>
					<TD colSpan="7"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7">
                        <asp:GridView ID="gvPersonnel" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CssClass="datagrid" DataKeyNames="PersonId"                            
                            TabIndex="80" ToolTip="View Personnel Information" Width="98%" 
                            OnPageIndexChanging="gvPersonnel_PageIndexChanging" 
                            OnRowEditing="gvPersonnel_RowEditing" OnSorting="gvPersonnel_Sorting" OnRowCommand="gvPersonnel_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PersonName" HeaderText="Person Name" ReadOnly="True" SortExpression="PersonName">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle ForeColor="Blue" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Acronym" HeaderText="Acronym">
                                    <ControlStyle Width="30%" />
                                    <ItemStyle Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeptName" HeaderText="Department">
                                    <ItemStyle HorizontalAlign="Left" Width="40%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Active">
                                    <ControlStyle Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    <ControlStyle Width="10%" />
                                </asp:CommandField>
                                <asp:CommandField ShowSelectButton="true" SelectText="Edit" />
                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <SelectedRowStyle CssClass="gridSelectedItem" />
                            <PagerStyle HorizontalAlign="Left" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                        </asp:GridView>
                    </TD>
				</TR>
				<TR>
					<TD colSpan="7">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="7"></TD>
				</TR>
			</TABLE>
     <!--       </ContentTemplate>
                        </asp:UpdatePanel>   -->     
</asp:Content>





