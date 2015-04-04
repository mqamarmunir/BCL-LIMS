<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true"
    CodeFile="wfrmNewInvestigaionBooking.aspx.cs" Inherits="transaction_wfrmNewInvestigaionBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 8%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">
        function switchdepartmentgroup(_sender) {
           // alert(_sender);
            if (_sender != "lnksubdep") {
                var uare = document.getElementById('fssubdepartments');
                //alert(uare);
                uare.style.display = "none";
                //alert(uare.style.display);
                var iam = document.getElementById('fsgroups');
                iam.style.display = "block";
            }
            else {
                var uare = document.getElementById('fssubdepartments');
                //alert(uare);
                uare.style.display = "block";
                //alert(uare.style.display);
                var iam = document.getElementById('fsgroups');
                iam.style.display = "none";
            }
           // uare.style.display = 'block';
        }
        function GetValue() {

            var label = document.getElementById("<%=lblcharges.ClientID%>");
            var totalamount = document.getElementById("<%=hdTotalamount.ClientID%>");
            var textbox = document.getElementById("<%=txtDiscount.ClientID%>");
            var salesdisc = document.getElementById("<%=hdsalesdiscount.ClientID%>");
            // alert(salesdisc.value.toString());
            var z;
            var total;
            if (parseInt(textbox.value) > parseInt(salesdisc.value)) {
                alert('Only ' + salesdisc.value + '% discount is allowed on these tests.');
                textbox.value = "";
                // alert('Please enter discount percentage less than or equal to 100');               
            }
            else if (textbox.value != "") {
                z = (parseInt(textbox.value) * parseInt(totalamount.value)) / (100);
                total = parseInt(totalamount.value) - z;
                //alert(total);
                label.innerHTML = Math.round(total);
                //document.getElementById("<%=txtCash.ClientID%>").value = Math.round(total/10)*10;
            }
            else {
                document.getElementById("<%=txtCash.ClientID%>").innerText = label.innerText;
                label.innerHTML = totalamount.value;
            }
        }


        function filtertext(term, _id, cellNr) {
            // alert("I am called");
            var suche = term.value.toLowerCase();
            // var x = document.getElementById(_id);
            //  alert(x);
            var table = document.getElementById(_id);
            //alert(_id);
            var ele;
            for (var r = 0; r < table.rows.length; r++) {
                ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
                if (ele.toLowerCase().indexOf(suche) >= 0)
                    table.rows[r].style.display = '';
                else table.rows[r].style.display = 'none';

                //      alert(table.rows[1].cells[1].innerHTML.toString());
            }
        }

        function switchover1() {
            var div = document.getElementById('Main2');
            if (div.style.display == "none")
            { div.style.display = "inline"; }
            else
            { div.style.display = "none"; }
        }

    </script>
     <script type="text/javascript" language="JavaScript">
<!-- Copyright 2006,2007 Bontrager Connection, LLC
// http://www.willmaster.com/
// Version: July 28, 2007
var cX = 0; var cY = 0; var rX = 0; var rY = 0;
function UpdateCursorPosition(e){ cX = e.pageX; cY = e.pageY;}
function UpdateCursorPositionDocAll(e){ cX = event.clientX; cY = event.clientY;}
if(document.all) { document.onmousemove = UpdateCursorPositionDocAll; }
else { document.onmousemove = UpdateCursorPosition; }
function AssignPosition(d) {
if(self.pageYOffset) {
	rX = self.pageXOffset;
	rY = self.pageYOffset;
	}
else if(document.documentElement && document.documentElement.scrollTop) {
	rX = document.documentElement.scrollLeft;
	rY = document.documentElement.scrollTop;
	}
else if(document.body) {
	rX = document.body.scrollLeft;
	rY = document.body.scrollTop;
	}
if(document.all) {
	cX += rX; 
	cY += rY;
	}
d.style.left = (cX+10) + "px";
d.style.top = (cY+10) + "px";
}
function HideContent(d) {
if(d.length < 1) { return; }
document.getElementById(d).style.display = "none";
}
function ShowContent(d) {
if(d.length < 1) { return; }
var dd = document.getElementById(d);
AssignPosition(dd);
dd.style.display = "block";
}
function ReverseContentDisplay(d) {
if(d.length < 1) { return; }
var dd = document.getElementById(d);
AssignPosition(dd);
if(dd.style.display == "none") { dd.style.display = "block"; }
else { dd.style.display = "none"; }
}
//-->
</script>
 <style type="text/css" media="screen">
        .suggest_link
        {
            background-color: #FFFFFF;
            padding: 2px 6px 2px 6px;
        }
        .suggest_link_over
        {
            background-color: #e0f0ff;
            color: Black;
            padding: 2px 6px 2px 6px;
            cursor: pointer;
        }
        #search_suggest
        {
            position: absolute;
            background-color: #FFFFFF;
            text-align: left;
            border: 1px solid #000000;
        }
        .style1
        {
            width: 4%;
        }
        .style2
        {
            color: #3366CC;
        }
        
        .GetMe
        {
            background: url(../img/Delete.gif); /* Old browsers */
        }
    </style>
    <script language="javascript" type="text/javascript">
//        $(document).ready(function () {
//           // alert('i am called');
//            $("#<%=txtSearch_test.ClientID%>").keyup(function (event) {
//                var str = $("#<%=txtSearch_test.ClientID%>").val();
                // alert(str);
            //    searchSuggest(event, str);
            

      
        var maxDivId, currentDivId, strOriginal;
        //Our XmlHttpRequest object to get the auto suggestvar 
        searchReq = getXmlHttpRequestObject();
        function getXmlHttpRequestObject() {

            if (window.XMLHttpRequest) {

                return new XMLHttpRequest();
            }
            else if (window.ActiveXObject) {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
            else {
                alert(" !\nIt's about time to upgrade Your Browser, don't you think?");
            }
        }

        //Called from keyup on the search textbox.//Starts the AJAX request.
        function searchSuggest(e, strid) {
           // alert('i am called');
            var key = window.event ? e.keyCode : e.which;
           // alert(document.getElementById(str).value);
            var str = document.getElementById(strid).value;
            
            //alert(str);
            if (key == 40 || key == 38) {

                scrolldiv(key);

            }
            else {

                if (searchReq.readyState == 4 || searchReq.readyState == 0) {
                    strOriginal = str

                    searchReq.open("GET", 'newGoogle_testlist.aspx?search=' + str, true);

                    searchReq.onreadystatechange = handleSearchSuggest;
                    searchReq.send(null);
                }

            }
            ///add code here
            document.getElementById('search_suggest').style.display = 'block';
        }

        //Called when the AJAX response is returned.
        function handleSearchSuggest() {

            if (searchReq.readyState == 4) {

                var ss = document.getElementById('search_suggest');

                ss.innerHTML = '';
                var str = searchReq.responseText.split("~");

                if (str.length > 1) {

                    for (i = 0; i < str.length - 1; i++) {
                        //Build our element string.  This is cleaner using the DOM, but			
                        //IE doesn't support dynamically added attributes.

                        maxDivId = i;
                        currentDivId = -1;
                        var suggest = '<div ';
                        suggest += 'id=div' + i;
                        suggest += '  '
                        suggest += 'onmouseover="javascript:suggestOver(this);" ';
                        suggest += 'onmouseout="javascript:suggestOut(this);" ';
                        suggest += 'onclick="javascript:setSearch(this.innerHTML);" ';
                        suggest += 'class="suggest_link">' + str[i] + '</div>';
                        ss.innerHTML += suggest;
                        ss.style.visibility = 'visible';
                    }
                }
                else {
                    ss.style.visibility = 'hidden';
                }
            }

        }

        //Mouse over function
        function suggestOver(div_value) {
            div_value.className = 'suggest_link_over';
            document.getElementById("<%=txtSearch_test.ClientID%>").value = div_value.innerHTML.replace("amp;", "");
        }

        function scrollOver(div_value) {

            div_value.className = 'suggest_link_over';

            document.getElementById("<%=txtSearch_test.ClientID%>").value = div_value.innerHTML.replace("amp;", "");

        }

        //Mouse out function
        function suggestOut(div_value) {
            div_value.className = 'suggest_link';

        }
        //Amman Function
//        $(document).ready(function () {
//            var txtItem = document.getElementById("<%= txtSearch_test.ClientID %>");
//            $('#<%=txtSearch_test.ClientID%>').blur(function ()
//            { $("#search_suggest").hide() });
//            $('#<%=txtSearch_test.ClientID%>').focus(function ()
//            { $("#search_suggest").show() });
//        });


        //Click function
        function setSearch(value) {
            var ss = document.getElementById('search_suggest');
            document.getElementById("<%=txtSearch_test.ClientID %>").value = value;
            ss.innerHTML = '';
            ss.style.visibility = 'hidden';
        }

        function scrolldiv(key) {
            var tempID;
            if (key == 40) {

                if (currentDivId == -1) {
                    tempID = 'div' + 0;
                    var a = document.getElementById(tempID);
                    scrollOver(a);
                    currentDivId = 0;

                }
                else {

                    if (currentDivId == maxDivId) {
                        tempID = 'div' + maxDivId;
                        var a = document.getElementById(tempID);
                        currentDivId = -1;
                        suggestOut(a)
                        document.getElementById("<%=txtSearch_test.ClientID %>").value = strOriginal;
                    }
                    else {
                        tempID = currentDivId + 1;
                        setScroll(currentDivId, tempID)
                    }

                }
            }
            else if (key == 38) {
                if (currentDivId == -1) {
                    tempID = maxDivId;
                    setScroll(maxDivId, maxDivId)

                }
                else {
                    if (currentDivId == 0) {
                        tempID = 'div' + currentDivId;
                        var a = document.getElementById(tempID);
                        currentDivId = -1;
                        suggestOut(a)
                        document.getElementById("<%=txtSearch_test.ClientID %>").value = strOriginal;

                    }
                    else {
                        tempID = currentDivId - 1;
                        setScroll(currentDivId, tempID)

                    }

                }

            }
        }
        function setScroll(Old, New) {
            var tempDivId;
            currentDivId = New;

            tempDivId = 'div' + Old;
            var a = document.getElementById(tempDivId);
            suggestOut(a)

            tempDivId = 'div' + currentDivId;
            var b = document.getElementById(tempDivId);
            scrollOver(b);

        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <table width="100%" style="position:absolute;z-index: 100001;">
                                    <tr>
                                        <td align="center">


                                            <asp:Image runat="server" Width="" Height="" ImageUrl="../images/mywait.gif" ID="Img_Load" />
                                        </td>
                                    </tr>
                                </table>

                                <div style="position: fixed; top: 0px; bottom: 0px; left: 0px; right: 0px; overflow: hidden; padding: 0; margin: 0; background-color: #F0F0F0; filter: alpha(opacity=60); opacity: 0.6; z-index: 100000;"></div>
                         </ProgressTemplate>
                 </asp:UpdateProgress>
    <div class="tboxhead" style="text-align: center; width: 100%; padding-top: 10px;">
        <img src="../images/adding.png" alt="Booking Image" />Investigation Booking</div>
    <table style="color: #06C;">
        <%--<tr>
        <td>
            <img src="../images/adding.png" alt="Booking Image" /></td>
        <td><strong> Investigation Booking </strong>
         
         </td>
    </tr>--%>
    </table>
    <asp:UpdatePanel ID="updteeeee" runat="server">
        <ContentTemplate>
            <div id="divbeforebooking" runat="server">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="up_Er" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdsalesdiscount" Value="101" runat="server" />
                                    <asp:HiddenField ID="hddocumentpath" runat="server" />
                                    <asp:HiddenField ID="hdTotalamount" runat="server" />
                                    <br />
                                    <asp:ImageButton ID="imgSave_Admin" runat="server" ImageUrl="~/images/buttons/save.png"
                                OnClick="imgSave_Admin_Click" AccessKey="s" ToolTip="Forward to Admin Panel" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lbtnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="lbtnAddALL" EventName="Click"></asp:AsyncPostBackTrigger>
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td align="right">
                        
                            <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/buttons/save.png"
                                OnClick="imgSave_Click" AccessKey="s" ToolTip="Click or Press Alt+s to save test booking" />
                            <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/buttons/clear.png"
                                OnClick="imgClear_Click" AccessKey="x" ToolTip="Click or Press Alt+x to clear this screen" />
                            <asp:ImageButton ID="imgCLose" runat="server" ImageUrl="~/images/buttons/close.png"
                                OnClick="imgCLose_Click" AccessKey="c" ToolTip="Click or Press Alt+c to close this screen" />
                        </td>
                    </tr>
                </table>


                
                <table width="100%">
                    <tr>
                        <td style="width: 40%">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <fieldset>
                                       
        



                                        <asp:Panel ID="pnlPatientInfo" runat="server" Width="99%">
                                                <table id="tb_patientInfo" style="height: 150px;" border="0" cellpadding="1" cellspacing="1"
                                                    width="100%" class="label">
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
                        <td style="width: 60%">
                            <fieldset>
                                <table class="label" width="100%" style="height: 150px;">
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
                                            <td>
                                                Specimen:
                                            </td>
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
                                            <asp:DropDownList ID="ddlPatientType" runat="server" Width="60%" CssClass="dropdown"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlPatientType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <asp:UpdatePanel ID="up_cash" runat="Server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 32%">
                                                                Payment:
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdbMode" runat="server" RepeatLayout="flow" RepeatDirection="Horizontal"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="rdbMode_SelectedIndexChanged">
                                                                    <asp:ListItem Value="C">Cash</asp:ListItem>
                                                                    <asp:ListItem Value="R">Credit Card</asp:ListItem>
                                                                    <asp:ListItem Value="D">Debit Card</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                &nbsp;
                                                               
                                                        
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan="2">
                                                        <table width="99%" id="tblCardInfo" visible="false" runat="server">
                                                         <tr>
                                                        <td colspan="2">
                                                        <asp:RadioButton ID="rdocc_Visa" runat="server" Checked="true" Text="Visa" GroupName="CardType" />
                                                        <asp:RadioButton ID="rdocc_Master" runat="server" Checked="false" Text="Master" GroupName="CardType" />
                                                        </td>
                                                        
                                                        <td>
                                                        Bank Name:
                                                        </td>
                                                        <td>
                                                        <asp:TextBox ID="txtBankName" runat="server" CssClass="field"></asp:TextBox>
                                                        </td>
                                                        </tr>
                                                         <tr>
                                                        <td>Card No.:</td>
                                                        <td>
                                                        <asp:TextBox ID="txtCarNumber" runat="server" CssClass="field"></asp:TextBox>
                                                        </td>
                                                        <td>Expiry Date:</td>
                                                        <td>
                                                        <asp:TextBox ID="txtCardExpiry" runat="server" CssClass="field"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="calextdob" runat="server" TargetControlID="txtCardExpiry" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                                        <cc1:MaskedEditExtender id="msk_DOB" runat="Server" TargetControlID="txtCardExpiry" Mask="99/99/9999" ClearMaskOnLostFocus="false" AutoComplete="false"></cc1:MaskedEditExtender> 
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                        <td width="25%">
                                                        <asp:Label ID="lblReferenceNo" runat="server" Text="Receipt No:"></asp:Label>
                                                               
                                                        </td>
                                                        <td width="25%">
                                                         <asp:TextBox ID="txtReferenceNo" runat="server"  CssClass="mandatoryField"
                                                                    MaxLength="30"></asp:TextBox>
                                                        </td>
                                                        <td width="25%"></td>
                                                        <td width="25%"></td>
                                                        </tr>
                                                        </table>
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                        <td>Total Charges:
                                                            <asp:Label ID="lblcharges" runat="server" Font-Bold="True" ForeColor="Indigo"></asp:Label>
                                                            </td>
                                                        <td>Discount:<asp:TextBox ID="txtDiscount" runat="server" CssClass="field" 
                                                                MaxLength="3" ToolTip="Please enter discount in percentage" Width="7%"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="txtDiscount0_FilteredTextBoxExtender" 
                                                                runat="server" FilterType="numbers" TargetControlID="txtDiscount">
                                                            </cc1:FilteredTextBoxExtender>
                                                            (%)<asp:LinkButton ID="lnkapplydisc" runat="server" OnClick="lnkapplydisc_Click" 
                                                                Text="Apply"></asp:LinkButton>
                                                            &nbsp;
                                                            <asp:Label ID="lblCash" runat="server"></asp:Label>
                                                            :<asp:TextBox ID="txtCash" runat="server" BackColor="#FFE0C0" 
                                                                CssClass="mandatoryField" Width="13%"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="flt_cash" runat="server" FilterType="Numbers" 
                                                                TargetControlID="txtCash">
                                                            </cc1:FilteredTextBoxExtender>
                                                            <asp:CheckBox ID="chkOnCASH" runat="server" AutoPostBack="True" 
                                                                OnCheckedChanged="chkOnCASH_CheckedChanged" Text="On Cash" />
                                                            </td>
                                                        </tr>
                                                        <tr style="display:none">
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <%--onkeyup="GetValue()"--%>
                                                                </td>
                                                        </tr>
                                                        <tr style="display:none">
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr style="display:none">
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
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
                            <a href="javascript:switchover1();" style="color: #3333FF; float:right;">Other Details</a>
                            </fieldset>
                            
                        </td>
                    </tr>
                </table>
                <table id="Main2" width="100%" style="display:none;">
                    <tr>
                        <td>
                            Anti-Biotics history(if Any):
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtantihistory" runat="server" CssClass="field" Width="99%" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            Doctor's prescription Document:
                        </td>
                        <td width="20%">
                            <cc1:AsyncFileUpload ID="upldprescription" runat="server" Width="0px" UploaderStyle="Traditional"  OnUploadedComplete="upldprescription_UploadedComplete" />
                            <%-- <asp:FileUpload  ID="" runat="server" />--%>
                        </td>
                        <td width="15%">
                        </td>
                        <td width="20%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="10%">
                        </td>
                        <td width="10%">
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
                        
                        <td id="Td1" colspan="2" align="left" visible="true">
                            <asp:Panel ID="pnlsearchtest" DefaultButton="imgSearch_test" runat="server">
                            Search Test:
                        
                            <asp:TextBox ID="txtSearch_test" ClientIDMode="Static" onkeyup="searchSuggest(event,this.id)" runat="server" CssClass="field" Width="50%" ToolTip="Please enter test name"></asp:TextBox>&nbsp;<asp:ImageButton
                                ID="imgSearch_test" runat="server" ImageUrl="~/images/btn_Blank.GIF" OnClick="imgSearch_test_Click" />
                            <%--<cc1:TextBoxWatermarkExtender ID="wt_sear_te" runat="server" TargetControlID="txtSearch_test"
                                WatermarkCssClass="waterlabel" WatermarkText="Please enter test name">
                            </cc1:TextBoxWatermarkExtender>--%>
                            <div id="search_suggest" style="z-index: 500 !important; display: none; width: 18%;
                    margin-left: 0.5em; border-color: #A6C9E2; margin-top: -2px;">
                        
                                               </asp:Panel>
                        </td>
                        <td colspan="4">
                        <asp:Panel ID="pnlsearchspeedkey" runat="server" DefaultButton="imgSpdKey">
                            Speed Key:<asp:TextBox ID="txtSpeed" runat="server"  CssClass="field" Width="20%"
                                ToolTip="Please enter speed key to search test"></asp:TextBox>
                            <asp:ImageButton ID="imgSpdKey" runat="server" ImageUrl="~/images/btn_Blank.GIF"
                                OnClick="imgSpdKey_Click" />
                                
                            &nbsp;
                            <asp:LinkButton ID="lbtnAdd" Visible="true" runat="server" OnClick="lbtnAdd_Click">Add Selected</asp:LinkButton>
                            &nbsp;
                           
                            <asp:LinkButton ID="lbtnAddALL" runat="server" OnClick="lbtnAddALL_Click">Add All</asp:LinkButton>
                            &nbsp; <a href="javascript:switchover();">
                                <asp:Label ID="Lbl_open" runat="server" Visible="false" Text="Internal Comment >>"></asp:Label></asp:Panel>
                            </a>

                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBranch" runat="server" Width="98%" CssClass="dropdown" Visible="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display:none">
                    <td width="20%"></td>
                    <td class="10%"></td>
                    <td width="20%"></td>
                    <td width="10%"></td>
                    <td width="10%"></td>
                    <td width="10%"></td>
                    <td width="10%"></td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td valign="top" width="30%">
                            <asp:Panel ID="pnl_dept" Width="99%" Height="100px" Visible="false" runat="server" ScrollBars="auto"
                                BorderColor="Tan" BorderStyle="Solid" BorderWidth="1px">
                                <table id="tb_dept" width="100%" cellpadding="1" cellspacing="1" border="0" class="label">
                                
                                 
                            
                                
                                    <tr style="background-color: #DDDDDD;">
                                        <td>
                                            <img alt="" src="../images/bulletr.png" unselectable="on" align="middle" />
                                        </td>
                                        <td visible="false">
                                            Department
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="False" Visible="false" CssClass="datagrid"
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
                          
                            <asp:UpdatePanel ID="up_su" runat="Server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnl_Sub" runat="server" BorderStyle="Solid" BorderColor="Tan" Width="99%"
                                        BorderWidth="1px" Height="345px" ScrollBars="Auto">
                                        <table id="tb_sub" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                            <tbody>
                                                <tr style="background-color: #DDDDDD;">
                                                    <td>
                                                        <img alt="Bullet" src="../images/bulleto.png" align="middle" unselectable="on" />
                                                    </td>
                                                    <!--************************SubDepartment********************************-->
                                                    <td>
                                                        <a href="#" id="lnksubdep" onclick="javaScript:switchdepartmentgroup(this.id);">SubDepartments</a>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                         <a href="#" id="lnkgroupspackages" onclick="javaScript:switchdepartmentgroup(this.id);">Groups/Packages</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                    <fieldset id="fssubdepartments">
                                                    <legend>Sub Departments</legend>
                                                    
                                                        <asp:GridView  ID="gvSubdept" runat="server" Width="99%" CssClass="datagrid" ShowHeader="False"
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
                                                        </fieldset>
                                                        <fieldset id="fsgroups" style="display:none;">
                                                        <legend>
                                                        Groups and Packages
                                                        </legend>
                                                        <asp:GridView ID="gvGroup" runat="server" Width="100%" AutoGenerateColumns="False"
                                                CssClass="datagrid" DataKeyNames="groupid" ShowHeader="False" OnRowDataBound="gvGroup_RowDataBound">
                                                <RowStyle CssClass="gridItem" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <HeaderStyle HorizontalAlign="Right" Width="2%" />
                                                        <ItemStyle Width="2%" />
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>:
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
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
                                                        </fieldset>
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
                            <asp:Panel ID="pnl_Group" runat="server" Height="110px" Visible="false" ScrollBars="Auto" BorderColor="Tan"
                                BorderStyle="Solid" BorderWidth="1px">
                                <table id="tb_group" cellpadding="1" cellspacing="1" class="label" border="0" width="100%">
                                    <tr style="background-color: #DDDDDD;">
                                        <td style="width: 10%">
                                            <img src="../images/bulletg.png" alt="Middle" />
                                        </td>
                                        <td align="left">
                                            Group
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td valign="top" width="40%">
                            <asp:UpdatePanel ID="up_List" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="pnl_testList" runat="server" BorderStyle="Solid" BorderColor="Tan"
                                        Width="99%" BorderWidth="1px" Height="345px">
                                        <table id="tb_testlist" class="label" cellspacing="1" cellpadding="1" width="100%"
                                            border="0">
                                            <tbody>
                                                <tr style="background-color: #DDDDDD;">
                                                    <td>
                                                        <img alt="" src="../images/bulletr.png" align="middle" unselectable="on" />
                                                    </td>
                                                    <td>
                                                        Test List &nbsp;&nbsp;
                                                        <input type="text" class="field" onkeyup="filtertext(this,'<%=gvTestList.ClientID %>',1)"
                                                            style="width: 40%" />
                                                        <asp:TextBox ID="txtList_search" runat="server" Width="0%" CssClass="field" onkeyup="javascript:filtertext(this,'<%=gvTestList.ClientID %>',1)"
                                                            Visible="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="overflow-y: auto; vertical-align: top; width: 38%; position: absolute;
                                                            height: 300px">
                                                            <asp:GridView ID="gvTestList" runat="server" Width="99%" EnableViewState="true" CssClass="datagrid" ShowHeader="False"
                                                                DataKeyNames="testid,classificationid,priority,maxtime,charges,brtestcharges,External,DestinationBranch,TATtype,TATvalue,FranchiseDiscount,BranchCost,dplan,time1,time2,time3,time4,dispatchtime1,dispatchtime2,dispatchtime3,dispatchtime4,Dplan_InternalTests,TestInformation,SpecialTest,groupid,brPercentagediscount"
                                                                AutoGenerateColumns="False" OnRowDataBound="gvTestList_RowDataBound" OnRowCommand="gvTestList_RowCommand">
                                                                <RowStyle CssClass="gridItem"></RowStyle>
                                                                <Columns>
                                                                    <asp:BoundField DataField="speedkey" HeaderText="SPD Key">
                                                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:ButtonField DataTextField="testname" HeaderText="Name" CommandName="AddTest">
                                                                     <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                                        </asp:ButtonField>
                                                                   <%-- <asp:BoundField DataField="testname" HeaderText="Test">
                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                                    </asp:BoundField>--%>
                                                                    <asp:BoundField DataField="brtestcharges" HeaderText="charges">
                                                                        <%--charges--%>
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
                                        Width="100%" BorderWidth="1px" Height="345px">
                                        <table id="tb_pick" class="label" cellspacing="1" cellpadding="1" width="100%" border="0">
                                            <tbody>
                                                <tr style="background-color: #DDDDDD;">
                                                    <td>
                                                        <img src="../images/bulletr.png" alt="" />
                                                    </td>
                                                    <td>
                                                        Patient Test&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:LinkButton ID="lbtnRemoveALL" OnClick="lbtnRemoveALL_Click" runat="server">Remove All</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="overflow-y: auto; vertical-align: top; width: 29%; position: absolute;
                                                            height: 300px">
                                                            <asp:GridView ID="gvTestPick" runat="server" Width="99%" EnableViewState="true" CssClass="datagrid" ShowHeader="False"
                                                                DataKeyNames="testid,classificationid,priority,comment,for_process,charges,DestinationBranchID,FranchiseDiscount,TestInformation,SpecialTest,groupid,BranchPercentageDiscount"
                                                                AutoGenerateColumns="False" OnRowCommand="gvTestPick_RowCommand" OnRowDeleting="gvTestPick_RowDeleting"
                                                                OnRowDataBound="gvTestPick_RowDataBound">
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
                                                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="charges" HeaderText="Charges">
                                                                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="deliveredon" HeaderText="Delivered On">
                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                    <asp:TextBox ID="gvtxtdisc" Enabled="false" runat="server" Width="30%" ></asp:TextBox>
                                                                    <asp:TextBox ID="gvtxtdiscamount" Text='<%# DataBinder.Eval(Container.DataItem,"charges") %>' Enabled="false" runat="server" Width="55%" ></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:CommandField DeleteText="&lt;img src='../images/Delete.gif' border='0' /&gt;"
                                                                        ShowDeleteButton="True">
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:CommandField>
                                                                    <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                    
                                                                    <asp:LinkButton ID="testinstruction"  runat="server" Visible="false" Enabled="false" Text="MSG<span>" CssClass="tip" OnClientClick="return false;"><%--umair<span>sdfsdfsdfsdfsdfd</span>--%></asp:LinkButton>
                                                                    <%--<a id="testinstruction" runat="server" href="#" onclick="return false" title="harana mushkil he nahin namumkin hai">Umair Rajput </a>--%>

                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                   <%-- <asp:CommandField SelectText="&lt;img src='../images/comment_add.png' border='0' /&gt;"
                                                                        ShowSelectButton="True" HeaderText="a">
                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:CommandField>--%>
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
                            <asp:Label ID="lblsalesdisc" runat="server"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
                <script type="text/javascript">
                    function switchover() {
                        var div = document.getElementById('Main');
                        if (div.style.display == "none")
                        { div.style.display = "inline"; }
                        else
                        { div.style.display = "none"; }
                    }
                </script>
                <br />
                <br />
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
                           <%-- <asp:UpdatePanel ID="up_prg" runat="server">
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
                            </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updteee" runat="server">
        <ContentTemplate>
            <div id="divafeterbooking" runat="server" visible="false">
                <table id="tblafterbooking" class="label" width="99%">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbGotopatientRegistration" Font-Size="Small" runat="server" Text="< Go Back To Patient Registration Page"
                                OnClick="lbGotopatientRegistration_Click"></asp:LinkButton>
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
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
</asp:Content>
