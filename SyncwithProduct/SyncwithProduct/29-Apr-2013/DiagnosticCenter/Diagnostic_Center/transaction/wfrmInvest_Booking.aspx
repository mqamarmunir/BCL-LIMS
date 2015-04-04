<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="~/transaction/wfrmInvest_Booking.aspx.cs" Inherits="invest_reg"  Title="Investigation Booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <script language="javascript" type="text/javascript">
    function GetValue() {

             var label = document.getElementById("<%=lblcharges.ClientID%>");
             var textbox = document.getElementById("<%=txtDiscount.ClientID%>");
             var salesdisc = document.getElementById("<%=hdsalesdiscount.ClientID%>");
            // alert(salesdisc.value.toString());
             var z;
             var total;
             if (parseInt(textbox.value) > parseInt(salesdisc.value)) {
                 alert('Only ' +salesdisc.value + '% discount is allowed on these tests.');
                 textbox.value = "";
               // alert('Please enter discount percentage less than or equal to 100');               
             }
                else if(textbox.value!="")
                 {      
              z = (parseInt(textbox.value) * parseInt(label.innerText)) / (100);
              total =  parseInt(label.innerText) - z;
              document.getElementById("<%=txtCash.ClientID%>").innerText= Math.round(total);              
              }
              else
                document.getElementById("<%=txtCash.ClientID%>").innerText= label.innerText;
          }
 function filtertext(term, _id, cellNr) {
           // alert("I am called");
        var suche = term.value.toLowerCase();
       // var x = document.getElementById(_id);
      //  alert(x);
        var table = document.getElementById(_id);
       //alert(_id);
        var ele;
        for (var r = 1; r < table.rows.length; r++) {
            ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
            if (ele.toLowerCase().indexOf(suche) >= 0)
                table.rows[r].style.display = '';
            else table.rows[r].style.display = 'none';

            //      alert(table.rows[1].cells[1].innerHTML.toString());
        }
    }

    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="color:#06C;">
        <tr>
            <td>
                <img src="../images/adding.png" alt="Booking Image" /></td>
                <td><strong> Investigation Booking </strong>
            </td>
        </tr>
    </table>
    
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="up_Er" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdsalesdiscount" Value="101" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAddALL" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td align="right">
                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/buttons/save.png" OnClick="imgSave_Click"
                    AccessKey="s" ToolTip="Click or Press Alt+s to save test booking" />
                <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/buttons/clear.png" OnClick="imgClear_Click"
                    AccessKey="x" ToolTip="Click or Press Alt+x to clear this screen" />
                <asp:ImageButton ID="imgCLose" runat="server" ImageUrl="~/images/buttons/close.png" OnClick="imgCLose_Click"
                    AccessKey="c" ToolTip="Click or Press Alt+c to close this screen" />
            </td>
        </tr>
    </table>
    
    <table width="100%" >
        <tr>
            <td style="width:40%"> 
                <table width="100%">
        <tr>
            <td>
            <fieldset>
                <asp:Panel  ID="pnlPatientInfo" runat="server" Width="99%">
                    <table id="tb_patientInfo"  style="height:150px;" border="0" cellpadding="1" cellspacing="1" width="100%"
                        class="label">
                        <tr>
                            <td align="left" style="width: 100px">
                                PR No:
                            </td>
                            <td>
                                <asp:Label ID="lblPRno" runat="server" Font-Bold="True" ForeColor="DarkBlue"></asp:Label>
                            </td>
                         </tr>
                         <tr>   
                            <td align="left">
                                Patient:
                            </td>
                            <td>
                                <asp:Label ID="lblPatient" runat="server" ForeColor="DarkBlue"></asp:Label>
                            </td>
                          </tr>
                         <tr>   
                            <td>
                                Age:
                            </td>
                            <td>
                                <asp:Label ID="lblAge" runat="server" ForeColor="DarkBlue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                           <td>
                                Gender:
                            </td>
                            <td>
                                <asp:Label ID="lblGender" runat="server" ForeColor="DarkBlue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Marital Status:
                            </td>
                            <td>
                                <asp:Label ID="lblMarital" runat="server" ForeColor="DarkBlue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPanelHead" runat="server" Text="Panel:"></asp:Label>
                            </td>
                            <td colspan="7">
                                <asp:Label ID="lblPanel" runat="server" ForeColor="DarkBlue"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblClassHead" runat="server" Visible="False">Class:</asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblClass" runat="server" ForeColor="DarkBlue" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                    
                </asp:Panel>
            </fieldset>
            </td>
        </tr>
    </table>
            </td>
            
            <td style="width:60%">
            <fieldset>
         <table class="label" width="100%" style="height:150px;">
        <tr>
            <td valign="middle">
                Test Priority:
            </td>
            <td valign="top">
                <asp:RadioButtonList ID="rdbPriority" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="N">Normal</asp:ListItem>
                    <asp:ListItem Value="U">Urgent</asp:ListItem>
                </asp:RadioButtonList>
               
            </td>
            <tr>
            <td>Specimen:</td>
            <td>
            <asp:RadioButtonList ID="rdbSpecimen" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="I" Selected="True">Internal</asp:ListItem>
                    <asp:ListItem Value="E">External</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            </tr>
        </tr>    
        <tr>
            <td valign="top">
                Type:
            </td>
            <td>
                <asp:DropDownList ID="ddlPatientType" runat="server" Width="60%"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlPatientType_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr> 
        <tr>   
            
            <td align="left" colspan="2">
                <asp:UpdatePanel ID="up_cash" runat="Server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <cc1:FilteredTextBoxExtender ID="flt_cash" runat="server" TargetControlID="txtCash"
                            FilterType="Numbers">
                        </cc1:FilteredTextBoxExtender>
                        <cc1:FilteredTextBoxExtender ID="flt_dis" runat="server" TargetControlID="txtDiscount"
                            FilterType="numbers">
                        </cc1:FilteredTextBoxExtender>
                        <table width="100%">
                            <tr>
                                <td style="width:36%">Payment:</td>
                                <td><asp:RadioButtonList ID="rdbMode" runat="server" RepeatLayout="flow" RepeatDirection="Horizontal"
                            BackColor="#FFE0C0" AutoPostBack="True" OnSelectedIndexChanged="rdbMode_SelectedIndexChanged">
                            <asp:ListItem Value="C">Cash</asp:ListItem>
                            <asp:ListItem Value="R">Credit Card</asp:ListItem>
                            <asp:ListItem Value="D">Debit Card</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;
                        <asp:Label ID="lblReferenceNo" runat="server" Text="Reference No:"></asp:Label>
                        <asp:TextBox ID="txtReferenceNo" runat="server" Width="10%" CssClass="mandatoryField"
                            MaxLength="30"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                                <td>Discount:</td>
                                <td>  
                                    <asp:TextBox ID="txtDiscount" onkeyup="GetValue()" runat="server" ToolTip="Please enter discount in percentage"
                                        Width="7%" CssClass="field" MaxLength="3"></asp:TextBox>
                                    (%)<asp:Label ID="lblCash" runat="server" BackColor="#FFE0C0"></asp:Label>
                                    <asp:TextBox ID="txtCash" runat="server" Width="8%" CssClass="mandatoryField" BackColor="#FFE0C0"></asp:TextBox>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>Total Charges:</td>
                                <td>
                                <asp:Label ID="lblcharges" runat="server" Font-Bold="True" ForeColor="Indigo"></asp:Label>
                        <asp:CheckBox ID="chkOnCASH" runat="server" Text="On Cash" OnCheckedChanged="chkOnCASH_CheckedChanged"
                            AutoPostBack="True"></asp:CheckBox>
                                </td>
                            </tr>
                        </table>
                            
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAddALL" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnRemoveALL" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="gvTestPick" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
                &nbsp; &nbsp;
            </td>
            
        </tr>
    </table>
            </fieldset>
            </td>
        </tr>
    </table>
    
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="up_war" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnl_ward" runat="server" Width="100%" BorderStyle="Solid" BorderWidth="2px">
                            <table id="tb_ward" border="0" cellpadding="1" cellspacing="1" class="label" width="100%">
                                <tr>
                                    <td align="left">
                                        Ward:
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlWard" runat="server" Width="99%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Bed:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBed" runat="server" CssClass="field" MaxLength="25" Width="99%"></asp:TextBox>
                                    </td>
                                    <td>
                                        Ref Adm No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAdm_Reference" runat="server" CssClass="field" MaxLength="50"
                                            Width="79%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 8%">
                                    </td>
                                    <td style="width: 30%">
                                    </td>
                                    <td style="width: 15%">
                                    </td>
                                    <td style="width: 47%">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPatientType" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
    <table width="100%">
        <tr>
            <td>
            </td>
            <td id="Td1" align="right" runat="server" visible="false">
                Search Test:
            </td>
            <td id="Td2" visible="false" runat="server" valign="top">
                <asp:TextBox ID="txtSearch_test" runat="server" CssClass="field" Width="80%" ToolTip="Please enter test name"></asp:TextBox>&nbsp;<asp:ImageButton
                    ID="imgSearch_test" runat="server" ImageUrl="~/images/btn_Blank.GIF" OnClick="imgSearch_test_Click" />
                <cc1:TextBoxWatermarkExtender ID="wt_sear_te" runat="server" TargetControlID="txtSearch_test"
                    WatermarkCssClass="waterlabel" WatermarkText="Please enter test name">
                </cc1:TextBoxWatermarkExtender>
            </td>
            <td colspan="2" align="left">
                Speed Key:<asp:TextBox ID="txtSpeed" runat="server" CssClass="field" Width="20%"
                    ToolTip="Please enter speed key to search test"></asp:TextBox>
                <asp:ImageButton ID="imgSpdKey" runat="server" ImageUrl="~/images/btn_Blank.GIF"
                    OnClick="imgSpdKey_Click" />
                &nbsp;
                <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">Add Selected</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lbtnAddALL" runat="server" OnClick="lbtnAddALL_Click">Add All</asp:LinkButton>
                &nbsp;
                <a href="javascript:switchover();">
                <asp:Label ID="Lbl_open" runat="server" Text="Internal Comment >>"></asp:Label>
                </a>
            </td>
            <td align="right">
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlBranch" runat="server" Width="98%" CssClass="dropdown" Visible="False">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
   
    <table width="100%">
        <tr>
            <td valign="top" width="30%">
                    <asp:Panel ID="pnl_dept" Width="99%" Height="100px" runat="server" ScrollBars="auto"
                    BorderColor="Tan" BorderStyle="Solid" BorderWidth="1px">
                    <table id="tb_dept" width="100%" cellpadding="1" cellspacing="1" border="0" class="label">
                        <tr style="background-color:#DDDDDD;">
                            <td>
                                <img alt="" src="../images/bulletr.png" unselectable="on" align="middle" />
                            </td>
                            <td>
                                Department
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                    DataKeyNames="departmentid" ShowHeader="False" Width="99%">
                                    <RowStyle CssClass="gridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>:
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="95%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDepart" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>'
                                                    OnClick="lbtnDepart_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gridheader" />
                                    <AlternatingRowStyle CssClass="gridAlternate" />
                                    <SelectedRowStyle CssClass="gridSelectedItem" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td width="10%">
                            </td>
                            <td width="90%">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                    <asp:UpdatePanel ID="up_su" runat="Server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnl_Sub" runat="server" BorderStyle="Solid" BorderColor="Tan" Width="99%"
                            BorderWidth="1px" Height="100px" ScrollBars="Auto">
                            <table id="tb_sub" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                <tbody>
                                    <tr style="background-color:#DDDDDD;">
                                        <td>
                                            <img alt="Bullet" src="../images/bulleto.png" align="middle" unselectable="on" />
                                        </td>
                                        <!--************************Department********************************-->
                                        <td>
                                            Sub-Department
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="gvSubdept" runat="server" Width="99%" CssClass="datagrid" ShowHeader="False"
                                                DataKeyNames="subdepartmentid,departmentid" AutoGenerateColumns="False">
                                                <RowStyle CssClass="gridItem" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>:
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnSubDept" Text='<%#DataBinder.Eval(Container.DataItem,"name") %>'
                                                                runat="server" OnClick="lbtnSubDept_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" Width="95%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="gridheader" />
                                                <AlternatingRowStyle CssClass="gridAlternate" />
                                                <SelectedRowStyle CssClass="gridSelectedItem" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                        </td>
                                        <td width="90%">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvDepartment" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
                <br />
                    <asp:Panel ID="pnl_Group" runat="server" Height="110px" ScrollBars="Auto" 
                    BorderColor="Tan" BorderStyle="Solid" BorderWidth="1px">
                    <table id="tb_group" cellpadding="1" cellspacing="1" class="label" border="0">
                        <tr style="background-color:#DDDDDD;">
                            <td style="width:10%">
                                <img src="../images/bulletg.png" alt="Middle" />
                            </td>
                            <td align="left" >
                                Group
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                    DataKeyNames="groupid" ShowHeader="False"  OnRowDataBound="gvGroup_RowDataBound">
                                    <RowStyle CssClass="gridItem" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>:
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right"  />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnGroup" Text='<%#DataBinder.Eval(Container.DataItem,"groupname") %>'
                                                    runat="server" OnClick="lbtnGroup_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gridheader" />
                                    <AlternatingRowStyle CssClass="gridAlternate" />
                                    <SelectedRowStyle CssClass="gridSelectedItem" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td  valign="top" width="40%">
                <asp:UpdatePanel ID="up_List" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnl_testList" runat="server" BorderStyle="Solid" BorderColor="Tan"
                            Width="99%" BorderWidth="1px" Height="345px">
                            <table id="tb_testlist" class="label" cellspacing="1" cellpadding="1" width="100%"
                                border="0">
                                <tbody>
                                    <tr style="background-color:#DDDDDD;">
                                        <td>
                                            <img alt="" src="../images/bulletr.png" align="middle" unselectable="on" />
                                        </td>
                                        <td>
                                            Test List &nbsp;&nbsp;
                                            <input type="text" class="field" onkeyup="filtertext(this,'<%=gvTestList.ClientID %>',1)" style="width:40%"/>
                                            <asp:TextBox ID="txtList_search" runat="server" Width="0%" CssClass="field"
                                                onkeyup="javascript:filtertext(this,'<%=gvTestList.ClientID %>',1)" Visible="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="overflow-y: auto; vertical-align: top; width: 36%; position: absolute;
                                                height: 300px">
                                                <asp:GridView ID="gvTestList" runat="server" Width="99%" CssClass="datagrid" ShowHeader="False"
                                                    DataKeyNames="testid,classificationid,priority,maxtime,charges,brtestcharges,External,DestinationBranch,TATtype,TATvalue,FranchiseDiscount,BranchCost" AutoGenerateColumns="False"
                                                     OnRowDataBound="gvTestList_RowDataBound">
                                                    <RowStyle CssClass="gridItem"></RowStyle>
                                                    <Columns>
                                                        <asp:BoundField DataField="speedkey" HeaderText="SPD Key">
                                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="testname" HeaderText="Test">
                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="brtestcharges" HeaderText="charges">     <%--charges--%>
                                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <SelectedRowStyle CssClass="gridSelectedItem"></SelectedRowStyle>
                                                    <HeaderStyle CssClass="gridheader"></HeaderStyle>
                                                    <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                        </td>
                                        <td width="90%">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvSubdept" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="gvGroup" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="imgSearch_test" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="imgSpdKey" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAddALL" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td valign="top" width="30%">
                <asp:UpdatePanel ID="up_ser" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnl_testPick" runat="server" BorderStyle="Solid" BorderColor="Tan"
                            Width="96%" BorderWidth="1px" Height="345px">
                            <table id="tb_pick" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                <tbody>
                                    <tr style="background-color:#DDDDDD;">
                                        <td>
                                            <img src="../images/bulletr.png"  alt="" />
                                        </td>
                                        <td>
                                            Patient Test&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lbtnRemoveALL" OnClick="lbtnRemoveALL_Click" runat="server">Remove All</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="overflow-y: auto; vertical-align: top; width: 30%; position: absolute;
                                                height: 270px">
                                                <asp:GridView ID="gvTestPick" runat="server" Width="99%" CssClass="datagrid" ShowHeader="False"
                                                    DataKeyNames="testid,classificationid,priority,comment,for_process,charges,DestinationBranchID,FranchiseDiscount" AutoGenerateColumns="False"
                                                    OnRowCommand="gvTestPick_RowCommand" OnRowDeleting="gvTestPick_RowDeleting" OnRowDataBound="gvTestPick_RowDataBound">
                                                    <RowStyle CssClass="gridItem"></RowStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>:
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="testname" HeaderText="Test">
                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="charges" HeaderText="Charges">
                                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="deliveredon" HeaderText="Delivered On">
                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:CommandField DeleteText="&lt;img src='../images/Delete.gif' border='0' /&gt;"
                                                            ShowDeleteButton="True">
                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:CommandField>
                                                        <asp:CommandField SelectText="&lt;img src='../images/comment_add.png' border='0' /&gt;"
                                                            ShowSelectButton="True" HeaderText="a">
                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:CommandField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="gridheader"></HeaderStyle>
                                                    <AlternatingRowStyle CssClass="gridAlternate"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                       
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                        </td>
                                        <td width="90%">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAddALL" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
                    <asp:Label ID="lblsalesdisc" runat="server"></asp:Label> <br />
            </td>
        </tr>
    </table>


 
                            <script type="text/javascript">
                                function switchover()
                                {
                                    var div = document.getElementById('Main'); 
                                    if (div.style.display == "none") 
                                        { div.style.display = "inline"; } 
                                    else 
                                        { div.style.display = "none"; }
                                }
                            </script>

                            
<br /><br />
 <table width="100%" id="Main" style="display: none;">
        <tr>
        
           <td align="left">
                <asp:UpdatePanel ID="up_int" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbtntest" runat="server"></asp:LinkButton>
                        <cc1:ModalPopupExtender ID="mde_intcmt" runat="server" TargetControlID="lbtntest"
                            Y="200" X="600" PopupControlID="pnlInt_cmmnt" DropShadow="true" BackgroundCssClass="TransparentGrayBackground"
                            CancelControlID="imgCmt_Close">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlInt_cmmnt" runat="server" Width="350px" Height="220px" CssClass="mPopup">
                            <table id="tb_cpy" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <strong>Internal Comment</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="4">
                                            <asp:Label ID="lblTest_intCmt" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td align="right" colspan="3">
                                            <asp:Label ID="lblInt_Index" runat="server" Visible="False"></asp:Label>
                                            <asp:ImageButton ID="imgcmt_save" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                                OnClick="imgcmt_save_Click"></asp:ImageButton><asp:ImageButton ID="imgCmt_Close"
                                                    OnClick="imgCmt_Close_Click" runat="server" ImageUrl="~/images/ClosePack.gif">
                                            </asp:ImageButton>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Stage:
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlFor_Process" runat="server" Width="98%" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Comment:
                                        </td>
                                        <td align="left" colspan="3" rowspan="5" valign="top">
                                            <asp:TextBox ID="txtInt_Comnt" runat="server" Width="98%" CssClass="field" MaxLength="500"
                                                TextMode="MultiLine" Height="87px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        &nbsp;&nbsp;&nbsp;
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvTestPick" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        
            <td>
                <asp:UpdatePanel ID="up_prg" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                            <ProgressTemplate>
                                <div class="UpdateProgress">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="../images/loading.gif"></asp:Image>
                                    ........Loading! Please Wait
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="imgSearch_test" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="imgSpdKey" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="txtList_search" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="gvDepartment" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="gvSubdept" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="gvGroup" EventName="RowCommand"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnAddALL" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="lbtnRemoveALL" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="imgSave" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="imgClear" EventName="Click"></asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="imgCLose" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
         
        </tr>
    </table>
<br /><br />

     
</asp:Content>

