<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Parameter/Attribute.aspx.cs" Inherits="Attribute_m" Title="Attribute Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript">
    function filter(txtid, _tableid) {
        //alert('I am called');
        var hidden_variables = document.getElementById("hdVariableNames");
        var hidden_locations = document.getElementById("hdlocations");
        var hidden_vartypes = document.getElementById("hdVariableTypes");
        var term = document.getElementById(txtid);
        var suche = term.value;
        var suchestring = suche.toString();
        var mystring = suchestring.replace(/[^a-zA-Z ]/g, " ");
        var countspaces = 0;
        var loopvar = 0;
        var indices = new Array();
        var variables = new Array();
        var patientvariables = new Array("age", "height", "weight", "bloodgroup", "gender");
        var formula_variable = new Array("sin", "cos", "tan", "log", "pow");
        var attribute_variables = new Array();
        var attributevalues_indices = 0;
        var _table = document.getElementById(_tableid);
        for (var a = 1; a < _table.rows.length; a++) {
            attribute_variables[attributevalues_indices] = _table.rows[a].cells[2].innerHTML.toString().toUpperCase();
            attributevalues_indices++;
        }
         // alert(attribute_variables.toString());


        for (var i = 0; i < mystring.length; i++) {
            if (mystring[i] == " ") {
                countspaces++;
            }
            else {
                variables[loopvar] = mystring[i];
                indices[loopvar] = i;
                loopvar++;
            }
        }
        var loopvariable = 0;
        var vars = new Array();
        var locations = new Array();
        locations[0] = indices[0];
        vars[0] = variables[0].toString();

        for (var k = 1; k < indices.length; k++) {
            if (indices[k] - indices[k - 1] == 1) {
                //                    variables[loopvariable] += variables[k];
                vars[loopvariable] = vars[loopvariable] + variables[k];
                locations[loopvariable] = locations[loopvariable] + ":" + indices[k];
                //alert(variables[k - 1]);
            }
            else {
                loopvariable++;
                vars[loopvariable] = variables[k];
                locations[loopvariable] = indices[k];
            }
        }

        //  alert(locations.toString());



        var comparecount = 0;
        var comparecount_attr = 0;
        var comparecount_function = 0;
        var count_validvariables = 0;
        var var_types = new Array();

        for (var tocheck = 0; tocheck < vars.length; tocheck++) {
            comparecount = 0;
            comparecount_attr = 0;
            comparecount_function = 0;
            for (var tcomparewith = 0; tcomparewith < patientvariables.length; tcomparewith++) {
                if (vars[tocheck].toString() == patientvariables[tcomparewith].toString()) {
                    comparecount++;
                    count_validvariables++;
                    var_types[tocheck] = "P";
                    //break;
                }
            }

            for (var tocompareattr = 0; tocompareattr < attribute_variables.length; tocompareattr++) {
                if (vars[tocheck].toString() == attribute_variables[tocompareattr].toString()) {
                    comparecount_attr++;
                    count_validvariables++;
                    // vars[tocheck] = vars[tocheck].toUpperCase();
                    var_types[tocheck] = "A";
                }
            }
            for (var tocompareattribute = 0; tocompareattribute < formula_variable.length; tocompareattribute++) {
                if (vars[tocheck].toString() == formula_variable[tocompareattribute].toString()) {
                    comparecount_function++;
                    count_validvariables++;
                    var_types[tocheck] = "F";
                }
            }

            if (comparecount == 0 && comparecount_attr == 0 && comparecount_function == 0) {
                alert("'" + vars[tocheck].toString() + "' is not a valid variable, Please enter correct formula");
            }
        }
        // alert(var_types.toString());
        if (count_validvariables == vars.length) {

            hidden_variables.value = vars.toString();
            hidden_locations.value = locations.toString();
            hidden_vartypes.value = var_types.toString();

            ////alert("Variables: " + hidden_variables.value.toString() + " Types: " + hidden_vartypes.value.toString());
            ////            alert("Indices: " + hidden_locations.value.toString());
            ////            alert("Types: " + hidden_vartypes.value.toString());
            alert("All Formula Variables are correct");
            for (var chkgender = 0; chkgender < vars.length; chkgender++) {
                if (vars[chkgender] == "gender") {
                    document.getElementById("txtMlValue").disabled = false;
                    document.getElementById("txtFmlValue").disabled = false;
                    break;
                }
                else {
                    document.getElementById("txtMlValue").disabled = true;
                    document.getElementById("txtFmlValue").disabled = true;

                }
            }
        }
    }
    //alert(count_validvariables);
    // alert(vars[1].toString());

    //            var tempstr = mystring.split(" ");
    //            alert(tempstr);
    //            alert(tempstr.split(","));
    //            alert(variables.toString());
    //            alert(indices.toString());

    //            for (var j = 0; j < countspaces; j++) {
    ////                variables[j] = mystring.split(" ");
    ////                alert(variables[j]);
    //               // variables[j] = mystring.substr(indices, mystring.indexOf(" ",indices));
    //                //indices = mystring.indexOf(" ", indices+1);
    //                //alert(variables[j]);
    ////                alert(j);
    ////                alert(j + 1);
    ////                alert(mystring.indexOf(" ",j));
    ////                alert(mystring.indexOf(" ",j+1));
    //            }



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        

</script>
  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>  
                               <%-- <asp:UpdatePanel ID="updtepage" runat="server">
                                <ContentTemplate>--%>
                                <asp:HiddenField ID="hdVariableNames" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="hdlocations" runat="server" ClientIDMode="Static" />
                               <asp:HiddenField ID="hdVariableTypes" runat="server" ClientIDMode="Static" />
   <table id="Table1" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">                              
                <tr>
                    <td align="center" colspan="8" class="tdheading">
                       Attributes Information</td>
                </tr>
                <tr>
                    <td colspan="8">
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
                    <td align="">
                        </td>
                    <td colspan="2">
                                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:LinkButton ID="lbtnCpyAtt" runat="server" ForeColor="Blue" OnClick="lbtnCpyAtt_Click">Copy Attribute</asp:LinkButton></td>
                    <td></td>
                    <td></td> 
                    <td></td>                  
                    <td></td>
                    <td></td>                    
                </tr>
       
        <tr>
            <td>
            </td>
            <td colspan="7"><%--<asp:UpdatePanel id="up_at" runat="server"><ContentTemplate>--%>
<TABLE id="tb_at" class="label" cellSpacing=1 cellPadding=1 width="100%" border=0><TBODY><TR><TD align=left colSpan=3><asp:Label id="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></TD><TD align=center colSpan=2><asp:Button id="lbtnSaveNext" onclick="lbtnSaveNext_Click" runat="server" Font-Bold="True" ForeColor="Navy" Text="Save & Next" BackColor="SkyBlue"></asp:Button></TD><TD><asp:ImageButton accessKey="s" id="lbtnSave" tabIndex=14 onclick="lbtnSave_Click" runat="server" ImageUrl="~/images/SavePack_2.gif" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)"></asp:ImageButton><asp:ImageButton accessKey="x" id="lbtnClearAll" tabIndex=15 onclick="lbtnClearAll_Click" runat="server" ImageUrl="~/images/ClearPack.gif" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)"></asp:ImageButton><asp:ImageButton accessKey="c" id="btnClose" tabIndex=16 onclick="btnClose_Click" runat="server" ImageUrl="~/images/ClosePack.gif" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)"></asp:ImageButton></TD></TR><TR><TD class="screenid" colSpan=6>&nbsp;</TD></TR><TR><TD>Sub Department:</TD><TD class="mandatoryField"><asp:DropDownList id="ddlSubDepartment" tabIndex=1 runat="server" ToolTip="Select Sub Department the Attribute" AutoPostBack="True" OnSelectedIndexChanged="ddlSubDepartment_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList></TD><TD align=right>Test:&nbsp; </TD><TD class="mandatoryField" colSpan=2><asp:DropDownList id="ddlTest" tabIndex=2 runat="server" ToolTip="Select Test for the Attribute" AutoPostBack="True" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged" Width="100%">
                            </asp:DropDownList></TD><TD><asp:CheckBox id="chkActive" tabIndex=3 runat="server" Text="Active" ToolTip="Check for remain Activethroughout the application" Checked="True"></asp:CheckBox> <asp:CheckBox id="chkInterfaced" tabIndex=4 runat="server" Text="Interfaced" ToolTip="Check for remain Activethroughout the application" Checked="True"></asp:CheckBox> <asp:CheckBox id="chkDrived" runat="server" Text="Derived" AutoPostBack="true" OnCheckedChanged="chkDerived_CheckedChanged"></asp:CheckBox> </TD></TR><TR><TD>Attribute:</TD><TD colSpan=2><asp:TextBox id="txtAttribute_Name" tabIndex=5 runat="server" ToolTip="Enter Attribute Name/Title" Width="97%" MaxLength="100" CssClass="mandatoryField"></asp:TextBox></TD><TD>Acronym:<asp:TextBox id="txtAcronym" tabIndex=6 runat="server" ToolTip="Please Enter Acronym for the Attribute" Width="52%" MaxLength="10" CssClass="field"></asp:TextBox></TD><TD align=right>D-Order:&nbsp; </TD><TD><asp:TextBox id="txtDOrder" tabIndex=7 runat="server" ToolTip="Enter Display Order for the Attribute" Width="39%" MaxLength="15" CssClass="field"></asp:TextBox> <asp:Label id="lblParentID" runat="server" Visible="False"></asp:Label>&nbsp;<asp:CheckBox id="chkHeading" runat="server" Text="Heading"></asp:CheckBox> <asp:CheckBox id="chkPrint" runat="server" Text="Print" Checked="True" __designer:wfdid="w12"></asp:CheckBox></TD></TR><TR><TD>D A Formula:</TD><TD><asp:TextBox id="txtD_A_Formula" tabIndex=8 runat="server" ToolTip="Enter Formula for the Derived Attribute" Width="99%" MaxLength="50" CssClass="field"></asp:TextBox></TD><TD align=right>Attribute Type:&nbsp; </TD><TD><asp:DropDownList id="ddlAttributeType" tabIndex=9 runat="server" ToolTip="Select Attribute Type" AutoPostBack="True" OnSelectedIndexChanged="ddlAttributeType_SelectedIndexChanged" Width="100%">                            
                            <asp:ListItem Value="N">Number</asp:ListItem>
                            <asp:ListItem Value="T">Text</asp:ListItem>
                        </asp:DropDownList></TD><TD align=right>Lines:&nbsp; </TD><TD><asp:TextBox id="txtLines" tabIndex=10 runat="server" ToolTip="Enter No. of Lines for the Text Box Input on Transaction Screens" Width="39%" MaxLength="15" CssClass="field"></asp:TextBox></TD></TR><TR><TD vAlign=top>Da Formula Desc:</TD><TD><asp:TextBox id="txtD_A_Formula_Desc" tabIndex=11 runat="server" ToolTip="Enter Description and Reference of Formula for Verification on Transaction and Reference for the Formula" Width="98%" MaxLength="1024" CssClass="field" Height="55px" TextMode="MultiLine"></asp:TextBox></TD><TD vAlign=top align=right>Default Value:&nbsp; </TD><TD><asp:TextBox id="txtDefaultValue" tabIndex=12 runat="server" ToolTip="Enter Default Value" Width="98%" MaxLength="1024" CssClass="field" Height="55px" TextMode="MultiLine"></asp:TextBox></TD><TD vAlign=top align=right>Description:&nbsp; </TD><TD><asp:TextBox id="txtDescription" tabIndex=13 runat="server" ToolTip="Enter Description for the Attribute" Width="58%" MaxLength="250" CssClass="field" Height="55px" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD width="13%"></TD><TD width="20%"></TD><TD width="13%"></TD><TD width="17%"></TD><TD width="10%"></TD><TD width="27%"></TD></TR></TBODY></TABLE>
<%--</ContentTemplate>
               </asp:UpdatePanel> --%>
            </td>
            
        </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="4">
                       <%-- <asp:UpdatePanel id="pnl_att_sel" runat="server"><contenttemplate>--%>
<DIV style="LEFT: 90px; POSITION: absolute; TOP: 90px"><asp:Panel id="pnlSel_Attrib" runat="server" BorderColor="#004000" BorderStyle="Double" Height="320px" BackColor="#C0FFFF" Width="99%" ScrollBars="Vertical">
    <table id="tb_cpy" width="100%" cellpadding="1" cellspacing="1" border="0" class="label">
        <tr>
            <td align="center" colspan="4">
                <strong>Select Attribute</strong></td>
        </tr>
        <tr>
            <td align="right">
                Search:&nbsp;
            </td>
            <td>
    <asp:TextBox ID="txtCpySearch" runat="server" CssClass="field"></asp:TextBox></td>
            <td align="right" colspan="2"><asp:ImageButton ID="imgcpySearch" runat="server"
        ImageUrl="~/images/Search_OT.gif" OnClick="imgcpySearch_Click" /><asp:ImageButton id="imgCpyClose" onclick="imgCpyClose_Click" runat="server" ImageUrl="~/images/ClosePack.gif"></asp:ImageButton>&nbsp;</td>
        </tr>
         <tr>
            <td colspan="4"><asp:GridView id="gvsl_attrib" runat="server" Width="100%" CssClass="datagrid" AutoGenerateColumns="False" DataKeyNames="attributeid"><Columns>
    <asp:BoundField DataField="test_name" HeaderText="Test">
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle HorizontalAlign="Left" Width="60%" />
    </asp:BoundField>
<asp:TemplateField HeaderText="Attribute"><ItemTemplate>
    &nbsp;<asp:LinkButton ID="lbtnSL_Attrib" Text='<%#DataBinder.Eval(Container.DataItem,"att_Name") %>' runat="server" OnClick="lbtnSL_Attrib_Click"></asp:LinkButton>
                                    
</ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle HorizontalAlign="Left" Width="40%" />
</asp:TemplateField>
</Columns>

<RowStyle CssClass="gridItem"></RowStyle>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView></td>
        </tr>
        <tr>
            <td width="25%"></td>
            <td width="25%"></td>
            <td width="25%"></td>
            <td width="25%"></td>
        </tr>
    </table>
</asp:Panel> </DIV>
                        save<%--<asp:UpdatePanel ID="updteFormula" runat="server">
                        <ContentTemplate>--%><div id="divFormula" style="background-color: #CCFFCC">
                                <table id="tblderivedfield" visible="false" class="label"  width="100%" runat="server" 
                                    cellspacing="0" style="background-color: #CCFFCC">
                                <tr>
                                <td>
                                <asp:Label ID="lblFormula" Font-Size="X-Small" Text="Formula" runat="server"></asp:Label>
                                </td>
                                <td colspan="2">
                                 <asp:TextBox ID="txtFormula" Width="100%" runat="server" 
                                        CssClass="mandatoryField"  
                                        onchange="javascript:filter('txtFormula','gvAttribute');" ClientIDMode="Static" BackColor="#CCFFFF"></asp:TextBox>
                                </td>
                              
                                </tr>
                                <tr>
                                <td width="20%">
                                    Gender(Values)</td>
                                <td width="40%">
                                    Male:
                                    <asp:TextBox ID="txtMlValue" runat="server" CssClass="mandatoryField" 
                                        BackColor="#CCFFFF" ClientIDMode="Static" Enabled="false"></asp:TextBox></td>
                                <td width="40%">
                                Female:
                                <asp:TextBox ID="txtFmlValue" runat="server" ClientIDMode="Static" CssClass="mandatoryField" 
                                        BackColor="#CCFFFF" Enabled="false"></asp:TextBox>
                                </td>
                                
                                </tr>
                                <tr>
                                
                           
                                <td>
                                Description
                                </td>
                                <td colspan="2">
                      <asp:TextBox ID="txtformulaedesc" runat="server" CssClass="field" TextMode="MultiLine" BackColor="#CCFFFF" Width="100%"></asp:TextBox>
                                </td>
                                     </tr>
                                <tr>
                                <td colspan="3" align="justify">
                                    <strong>Guide Lines for Formula Writing</strong></td>
                                    </tr>
                                    <tr>
                                    <td colspan="3">
                                    <ol>
                                    <li>
                                        Use Attribute Acronyms for Attribute Variables.</li>
                                    <li>
                                        Supported Mathematical Functions and there syntax is as given below:
                                        <ol>
                                        <li>
                                            pow(base,power) For power.</li>
                                            <li>
                                            log(x) for log.
                                            </li>
                                            <li>
                                            sin(x),cos(x),tan(x) for trignometric functions.
                                            </li>
                                            <li>
                                            
                                                +,-,*,/ for simple mathematical operations.</li>
                                        </ol>
                                        </li>
                                        <li>
                                        Use (age,weight,height and gender) for patient Variables.
                                        </li>
                                        <li>
                                        Attribute Vaiables(Acronyms) must be in upper case(letters) and all other variables and fuctions should be in lower case.
                                        </li>
                                        <li>
                                            Acronyms should be purely alphabetical i-e characters except Alphabets[a-z,A-Z] 
                                            are not allowed.   
                                        </li>
                                    <li>
                                        Note:The system will Prompt for wrong variable entry. But It willl not check the 
                                        validity of the formula. So be careful while writing the Formulas.</li>
                                        <li>
                                            All variables and formula functions are case sensitive.
                                        </li>
                                       
                                   
                                    </ol>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td></td>
                                    </tr>
                                </table>
                        </div>
                         <%--</ContentTemplate>
                         <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="chkDrived" EventName="CheckedChanged" />
                         <asp:AsyncPostBackTrigger ControlID="gvAttribute" EventName="RowCommand" />
                         </Triggers>
                        </asp:UpdatePanel>--%>
                       
                       </td>
                    <td>
                    </td>
                    <td rowspan="1">
                    </td>
                    <td>
                    </td>
                </tr>
       <tr>
           <td>
           </td>
           <td>
           </td>
           <td rowspan="1">
           </td>
           <td>
           </td>
           <td rowspan="1">
           </td>
           <td>
           </td>
           <td rowspan="1">
               <asp:LinkButton ID="btnUpdateDOrder" runat="server" ForeColor="Blue" OnClick="btnUpdateDOrder_Click"
                   Text="Update Dorder"></asp:LinkButton></td>
           <td>
           </td>
       </tr>
                <tr>
                    <td class="screenid" colspan="8">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="screenid" colspan="8">
                    </td>
                </tr>
            
                <tr>
                    <td>
                    </td>
                    <td align="center" colspan="7">
                        <%--<asp:UpdatePanel id="up_gd" runat="server"><ContentTemplate>--%>
<asp:GridView id="gvAttribute" ClientIDMode="Static" runat="server" ToolTip="View Attributes Info" 
                                Width="90%" CssClass="datagrid" 
DataKeyNames="AttributeId,testid" AutoGenerateColumns="False" 
AllowSorting="True" OnPageIndexChanging="gvAttribute_PageIndexChanging" 
OnRowEditing="gvAttribute_RowEditing" OnSorting="gvAttribute_Sorting"  OnRowCommand="gvAttribute_RowCommand">
<RowStyle CssClass="gridItem"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="S#"><ItemTemplate>
<%# Container.DataItemIndex+1 %>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="Attribute_Name" HeaderText="Name" ReadOnly="True" SortExpression="Attribute_Name">
<HeaderStyle HorizontalAlign="Left" ForeColor="Blue"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Acronym" HeaderText="Acronym" SortExpression="Acronym">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SubDeptName" HeaderText="SubDepartment" SortExpression="SubDeptName">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Test_Name" HeaderText="Test Name" SortExpression="Test_Name">
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Active"><ItemTemplate>
                                        <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
                                            Enabled="False" />
                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Heading"><ItemTemplate>
                                        <asp:CheckBox ID="chkgvHeading" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Heading").ToString() == "Y") %>' Enabled="False" />
                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Print"><ItemTemplate>
<asp:CheckBox id="chkGVPrint" runat="server" Enabled="False" __designer:wfdid="w13" Checked='<%# DataBinder.Eval(Container.DataItem,"Print").ToString()=="Y" %>'></asp:CheckBox>
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dorder"><ItemTemplate>
                                        <asp:TextBox ID="gvtxtDorder" Text='<%# (DataBinder.Eval(Container.DataItem, "DOrder").ToString()) %>' Width="98%" MaxLength=4 runat="server" CssClass="field"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="flt_gvdorder" runat="Server" FilterType="Numbers" TargetControlID="gvtxtDorder"></cc1:FilteredTextBoxExtender>
                                    
</ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:CommandField ShowEditButton="True" Visible="false">
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:CommandField>
<asp:CommandField ShowSelectButton="true" Visible="true" SelectText="Select" />
</Columns>

<PagerStyle HorizontalAlign="Left"></PagerStyle>

<SelectedRowStyle CssClass="gridSelectedItem"></SelectedRowStyle>

<HeaderStyle CssClass="gridheader"></HeaderStyle>

<AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
</asp:GridView> 
<%--</ContentTemplate>
                            <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlSubDepartment" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="ddlTest" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                     </asp:UpdatePanel>     --%>        
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="8">
                        <asp:Label ID="lblstatus" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblAttributeId" runat="server" Visible="False" ></asp:Label>
                        <asp:Label ID="lblSubDepartmentId" runat="server" Visible="False"></asp:Label></td>
                </tr>  
                <tr>
                    <td width="3%"></td>
                    <td width="13%"></td>
                    <td width="20%"></td>
                    <td width="12%"></td>
                    <td width="20%"></td>
                    <td width="10%"></td>
                    <td width="20%"></td>
                    <td width="2%"></td>
                </tr>             
            </table>
             <%--</ContentTemplate>
             <Triggers>
             <asp:AsyncPostBackTrigger ControlID="gvAttribute" EventName="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger ControlID="ddlTest" EventName="SelectedindexChanged" />
           <asp:AsyncPostBackTrigger ControlID="gvAttribute" EventName="RowCommand" />
             </Triggers>
                                </asp:UpdatePanel>--%>
   
</asp:Content>




