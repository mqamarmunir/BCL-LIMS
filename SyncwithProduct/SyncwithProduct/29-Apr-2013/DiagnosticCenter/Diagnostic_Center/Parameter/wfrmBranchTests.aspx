﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBranchTests.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function removeall() {
            if (confirm('Are you sure you want to rmove all these Records????? Please be Cautious Process is irreversible.'))
                return true;
            else
                return false;
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

    function applypercent(myval, _myid) {
        if (parseFloat(myval.value) > 0 && parseFloat(myval.value) <= 100 && parseFloat(myval.value) != NaN) {
            var myid = _myid.toString();
            var row_num_call = myid.substr(45, 3);
            row_num_call = row_num_call.replace('_', '');
            // alert(row_num_call);
            var x = parseInt(row_num_call);
            //  alert(x);
            var gv = document.getElementById('ctl00_ContentPlaceHolder1_gvSelectedTests'); //_ctl'+row_num_call+'_gvTxtPrice');
            var price = gv.rows[x - 1].cells[5].innerHTML.toString();
            var txtoffprice = document.getElementById('ctl00_ContentPlaceHolder1_gvSelectedTests_ctl' + row_num_call + '_gvTxtPrice');

            txtoffprice.value = Math.round((parseFloat(price) - (parseFloat(price) * parseFloat(myval.value) / 100)) / 10) * 10;

        }
        else {
            alert('Enter valid number between 0 and 100');
        }   //alert(myval.value);
    }

    function chkFranDiscount(frval, discvalueid) {
        var _id = document.getElementById('ctl00_ContentPlaceHolder1_txtpercentper');
        // alert(parseFloat(frval.value));
        if (parseFloat(_id.value) != NaN && parseFloat(_id.value) != '' && parseFloat(_id.value) < 100) {
            if (parseFloat(frval.value) < parseFloat(_id.value) && parseFloat(frval.value) != NaN && parseFloat(frval.value) >= 0) {

                //return false;
            }
            else {
                alert('Enter VALID percentage between 0 and'+parseFloat(_id.value)+'(discount percentage value).');
                frval.value = 0;
            }
        }
        else {
            alert('Enter valid Discount Percentage');
            frval.value = 0;
            _id.value = 0;
        }
    }

    function chkFrandiscountgrid(myval, _myid) {
        if (parseFloat(myval.value) > 0 && parseFloat(myval.value) <= 100 && parseFloat(myval.value) != NaN) {
            var myid = _myid.toString();
            var row_num_call = myid.substr(45, 3);
            row_num_call = row_num_call.replace('_', '');
            // alert(row_num_call);
            var x = parseInt(row_num_call);
            var txtpercentdisc = document.getElementById('ctl00_ContentPlaceHolder1_gvSelectedTests_ctl' + row_num_call + '_gvpercentage');

            /*Commented this portion on client request. In this portion I was ensuring the franchise allowed discount is less than Branch Discount given*/
//            if (parseFloat(myval.value) < parseFloat(txtpercentdisc.value) && parseFloat(myval.value) != NaN && parseFloat(myval.value) > 0) {

//                //return false;
//            }
//            else {
//                alert('Enter VALID percentage between 0 and' + parseFloat(txtpercentdisc.value) + '(discount percentage value).');
//                myval.value = 0;
//            }

        }
        else {
            alert('Enter valid number');
            myval.value = 0;
        }
    }
     </script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager> 

<table id="tblbody" class="label" cellpadding="1" cellspacing="1" width="100%">
<tr>
<td colspan="7" align="center"> <font size="4"><strong>Branch Test Configuration</strong></font>
<asp:HiddenField ID="hdBranchTestID" runat="server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
           <DIV class="UpdateProgress"><asp:Image id="Image1" runat="server" ImageUrl="../images/loading.gif" __designer:wfdid="w6"></asp:Image> ........Loading! Please Wait </DIV>
        </ProgressTemplate>
    </asp:UpdateProgress>
</td>

</tr>

<tr>
<td colspan="7" align="right">
 <asp:ImageButton ID="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif"
                                        TabIndex="12" ToolTip="Click or Press ALT+s  to Save Record (Alt+S)" AccessKey="s" OnClick="lbtnSave_Click" />
 <asp:ImageButton ID="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif"
                                        TabIndex="13" ToolTip="Click or Press ALT+X  to Clear Screen (Alt+C)" AccessKey="x" OnClick="lbtnClearAll_Click" />
<asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                                        TabIndex="14" ToolTip="Click or Press ALT+c  to Close Screen (Alt+X)" AccessKey="c" OnClick="btnClose_Click" />

</td>

</tr>
<tr>
<td colspan="7"><asp:UpdatePanel ID="updteerror" runat="server">
<ContentTemplate><asp:Label ID="lblErrMsg" ForeColor="Red" runat="server" Font-Size="X-Small"></asp:Label>

</ContentTemplate>
</asp:UpdatePanel></td>

</tr>
<tr>
<td align="right">Branch:</td>
<td>
<asp:DropDownList ID="ddlBranch" runat="server" CssClass="dropdown" 
        Width="99%" AutoPostBack="True" 
        onselectedindexchanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>
</td>
<td align="right">Sub-Department:</td>
<td><asp:DropDownList ID="ddlSubDepartment" runat="server" CssClass="dropdown" 
        Width="99%" AutoPostBack="true" 
        onselectedindexchanged="ddlSubDepartment_SelectedIndexChanged"></asp:DropDownList></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td  align="right">&nbsp;</td>
<td><asp:TextBox ID="txtPercent" runat="server" CssClass="mandatoryField" Visible="false" Width="20%"></asp:TextBox> 
<asp:CheckBox ID="chkExternal" runat="server" AutoPostBack="true" OnCheckedChanged="chkExternal_CheckedChanged" Text="External" />
</td>

<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td colspan="4">
<asp:UpdatePanel ID="updteExternal" runat="server">
<ContentTemplate>

            <table id="tblExternal" visible="false" style="background-color:Aqua" width="100%" runat="server" class="label" >
            <tr>
            <td width="25%" align="right">Branch(Forward):</td>
            <td width="25%"><asp:DropDownList ID="ddlforward" runat="server" CssClass="mandatorySelect" AutoPostBack="true" OnSelectedIndexChanged="ddlForward_SelectedIndexChanged" Width="100%"></asp:DropDownList></td>
            <td width="25%" align="right">TAT(Turn Around Time):</td>
            <td width="25%">
            <asp:TextBox ID="txtTat" CssClass="mandatoryField" runat="server" Width="30%"></asp:TextBox>
            &nbsp;<asp:DropDownList ID="ddlTat" runat="server" CssClass="mandatorySelect" Width="60%">
                <asp:ListItem Value="-1">Select</asp:ListItem>
                <asp:ListItem Value="D">Day(s)</asp:ListItem>
                <asp:ListItem Value="H">Hour(s)</asp:ListItem>
                <asp:ListItem Value="W">Week(s)</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="chkExternal" EventName="CheckedChanged" />
            </Triggers>
</asp:UpdatePanel>
</td>
<td></td>
<td></td>
<td></td>
</tr>

<tr>
<td colspan="2">
  <asp:UpdatePanel ID="updtegrid" runat="server">
        <ContentTemplate>
<div id="divAllTests" runat="server" visible="false">
        <fieldset>
        <legend>Investigations</legend>
        
        <table id="tblAllTests" width="99%" class="label" runat="server">
        <tr>
        <td width="100%">Filter:
           <input type="text" class="field" id="Filtertest" onkeyup="filtertext(this,'<%=gvAllTests.ClientID %>',1)" />&nbsp;<asp:LinkButton ID="lnkAddSelected" runat="server" Text="Add Selected" OnClick="lnkAddSelected_Click"></asp:LinkButton>
            &nbsp;<asp:LinkButton ID="lnkAddAll" runat="server" Text="Add All" OnClick="lnkAddAll_Click"></asp:LinkButton>
            
            
            </td>
        </tr>
          <tr>
        <td width="100%">
      
        
        <asp:Panel ID="pnlTests" runat="server" Height="300" ScrollBars="Auto">
        <asp:GridView ID="gvAllTests"  runat="server" Width="99%" AutoGenerateColumns="false"
        DataKeyNames="TestID" CssClass="datagrid" OnRowDataBound="gvAllTests_RowDataBound">
        <HeaderStyle CssClass="gridheader" HorizontalAlign="left" />
        <RowStyle CssClass="gridItem" />
        <AlternatingRowStyle CssClass="gridAlternate" />
        <Columns>
        <asp:TemplateField HeaderText="S#">
        <HeaderStyle Width="10%" HorizontalAlign="Center" />
        <ItemStyle Width="10%" HorizontalAlign="Center" />
        <ItemTemplate>
        <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="Test_Name" HeaderText="Test Name">
        <HeaderStyle Width="80%" />
        </asp:BoundField>
        <asp:BoundField DataField="Charges" HeaderText="Charges" />
        
        <asp:TemplateField> 
        <HeaderStyle Width="10%" />
       <ItemStyle HorizontalAlign="Center" />
        <ItemTemplate>
        <asp:CheckBox ID="gvchkTest" runat="server" />
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </asp:Panel>
       

        </td>
        </tr>
        
        </table>
        </fieldset>
         </div>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlSubDepartment" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlforward" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</td>
<td colspan="5">
<asp:UpdatePanel ID="updteSelected" runat="server">
<ContentTemplate>

<div id="divselected" runat="server" visible="false">
<fieldset>
        <legend>Allocated Investigations</legend>
        
        <table id="Table1" width="99%" class="label" runat="server">
        <tr>
        <td>
        <asp:DropDownList ID="ddlSubDepartmentper" Width="150px" runat="server" CssClass="dropdown" ></asp:DropDownList>
            Branch Discount:<asp:TextBox ID="txtpercentper" Width="50px" runat="server"  ToolTip="Percentage" CssClass="mandatoryField"></asp:TextBox>
            %&nbsp; Max. Sales Discount:
        <asp:TextBox ID="txtFranper" runat="server" CssClass="mandatoryField" onchange="javascript:chkFranDiscount(this,'<%=txtpercentper.ClientID %>')" Width="50px"></asp:TextBox>%
        <asp:LinkButton ID="lnkProcess" runat="server" Text="Process" 
                onclick="lnkProcess_Click"></asp:LinkButton>
        </td>
        </tr>

        <tr>
        <td width="100%">
          
            <asp:LinkButton ID="lnkRemoveAll" runat="server" Text="Remove All" OnClientClick="javascript:return removeall();" OnClick="lnkRemoveAll_Click"></asp:LinkButton>
            
            
            &nbsp; <asp:LinkButton ID="lnkRemoveSelected" runat="server" Visible="false" Text="Remove Selected" 
                OnClick="lnkRemoveSelected_Click"></asp:LinkButton>
            
            
            </td>
        </tr>
        <tr>
        <td colspan="7">
        Filter:
           <input type="text" class="field" id="fltrselected" onkeyup="filtertext(this,'<%=gvSelectedTests.ClientID %>',2)" />
           <asp:Label ID="lblBranchType" runat="server" BackColor="Silver" Font-Bold="true" Font-Size="Medium">
           </asp:Label>
        </td>
        </tr>
          <tr>
        <td width="100%">
        <asp:Panel ID="pnlselected" runat="server" Height="300" ScrollBars="Vertical">
        <asp:GridView ID="gvSelectedTests" runat="server" Width="99%" AutoGenerateColumns="False"
        
                DataKeyNames="TestID,DestinationBranchID,TATtype,TATvalue,SubDepartmentID,Percentage" 
                CssClass="datagrid" OnRowDeleting="gvSelectedTests_RowDeletingClick">
        <HeaderStyle CssClass="gridheader" HorizontalAlign="left" />
        <RowStyle CssClass="gridItem" />
        <AlternatingRowStyle CssClass="gridAlternate" />
        <Columns>
        <asp:TemplateField HeaderText="S#">
        <HeaderStyle Width="5%" HorizontalAlign="Center" />
        <ItemStyle Width="5%" HorizontalAlign="Center" />
        <ItemTemplate>
        <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField DataField="SubDepartment" HeaderText="SubDepartment" />
        <asp:BoundField DataField="TestName" HeaderText="Test Name">
        
        <HeaderStyle Width="30%" />
       
        </asp:BoundField>
       
        <asp:TemplateField HeaderText="Ext"> 
        <HeaderStyle Width="5%" />
        <ItemStyle HorizontalAlign="Center" />
       
        <ItemTemplate>
        <asp:CheckBox ID="gvchkExternal" Enabled="false" Checked='<%# (DataBinder.Eval(Container.DataItem, "External").ToString() == "Y") %>' runat="server" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Branch" DataField="Branch">
        <HeaderStyle Width="25%" />
        </asp:BoundField>
        <asp:BoundField DataField="VendorPrice" HeaderText="Standard Price">
        <HeaderStyle Width="10%" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Org Share">
        <HeaderStyle Width="10%" />
        <ItemStyle Width="10%" />
        <ItemTemplate>
        <asp:TextBox ID="gvTxtPrice" Text='<%#DataBinder.Eval(Container.DataItem,"Price") %>' Width="98%" CssClass="field" runat="server"></asp:TextBox><%-- Text='<%#DataBinder.Eval(Container.DataItem,"Price") %>'--%>
        </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Branch Discount(%)">
        <HeaderStyle Width="5%" />
        <ItemStyle Width="5%" />
        <ItemTemplate>
        <asp:TextBox ID="gvpercentage" Text='<%#DataBinder.Eval(Container.DataItem,"Percentage") %>' onchange="javascript:applypercent(this,this.id)" Width="98%" CssClass="field" runat="server"></asp:TextBox><%-- Text='<%#DataBinder.Eval(Container.DataItem,"Price") %>'--%>
        
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Max Sales Discount(%)">
        <HeaderStyle Width="5%" />
        <ItemStyle Width="5%" />
        <ItemTemplate>
        <asp:TextBox ID="gvtxtfrandisc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FranchiseDiscount") %>' onchange="javascript:chkFrandiscountgrid(this,this.id)" CssClass="mandatoryField" Width="99%"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/images/Delete.gif">
        <HeaderStyle Width="5%" />
        </asp:CommandField>
        <asp:TemplateField Visible="false">
        <HeaderStyle Width="0%" />
        <ItemTemplate>
        <asp:HiddenField ID="hdpercentage" Value='<%#DataBinder.Eval(Container.DataItem,"Percentage") %>' runat="server" Visible="false" />
        
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </asp:Panel>
        </td>
        </tr>
        
        </table>
        </fieldset>
        </div>

</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="lnkAddSelected" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="lnkAddAll" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="lnkRemoveAll" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
</Triggers>
    </asp:UpdatePanel>
</td>
</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
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
</tr>
<tr>
<td width="15%"></td>
<td width="20%"></td>
<td width="15%"></td>
<td width="20%"></td>
<td width="10%"></td>
<td width="10%"></td>
<td width="10%"></td>
</tr>
</table>
</asp:Content>

