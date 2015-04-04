<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true"
    CodeFile="wfrmPatientSearch.aspx.cs" Inherits="transaction_wfrmPatientSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
        }

        document.onkeypress = stopRKey; 

</script>

    <script language="javascript" type="text/javascript">
        //        function pageLoad() {
        //            ShowPopup();
        //            setTimeout(HidePopup, 2000);
        //        }

        function HideLabel() {
            document.getElementById('<%= tb2.ClientID %>').style.display = "none";
            document.getElementById('<%= tb1.ClientID %>').style.visibility = "visible";
            document.getElementById('<%= tb3.ClientID %>').style.visibility = "visible";
            document.getElementById('<%= pnlDetails.ClientID %>').style.visibility = "visible";

        } 
        setTimeout("HideLabel();", 3000);
    

        function callMe() {

            // var divGet = document.getElementById("tbback").style.display = "none";
            // document.getElementById("ModalPopupExtender1").hide();

            var mypanel = $('#<%=pnlDetails.ClientID%>');
            mypanel.toggle();
        }


        function ShowPopup() {
            $find('modalpopup').show();
            //$get('Button1').click();
        }

        function HidePopup() {
            // alert("ThankYou");
            document.getElementById("ModalPopupExtender1").hide();
            document.getElementById("tbback").click();
        }

        function HideMe() {

            document.getElementById('<%= Gvonload.ClientID %>').style.display = "none";

        }
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
        $(document).ready(function () {
            $("#<%=txtItemName.ClientID%>").keyup(function (event) {
                var str = $("#<%=txtItemName.ClientID%>").val();
                // alert(str);
                searchSuggest(event, str);
            });

        });
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
        function searchSuggest(e, str) {

            var key = window.event ? e.keyCode : e.which;


            if (key == 40 || key == 38) {

                scrolldiv(key);

            }
            else {

                if (searchReq.readyState == 4 || searchReq.readyState == 0) {
                    strOriginal = str

                    searchReq.open("GET", 'newGoogle.aspx?search=' + str, true);

                    searchReq.onreadystatechange = handleSearchSuggest;
                    searchReq.send(null);
                }

            }

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
            document.getElementById("<%=txtItemName.ClientID%>").value = div_value.innerHTML.replace("amp;", "");
        }

        function scrollOver(div_value) {

            div_value.className = 'suggest_link_over';

            document.getElementById("<%=txtItemName.ClientID%>").value = div_value.innerHTML.replace("amp;", "");

        }

        //Mouse out function
        function suggestOut(div_value) {
            div_value.className = 'suggest_link';

        }
        //Amman Function
        $(document).ready(function () {
            var txtItem = document.getElementById("<%= txtItemName.ClientID %>");
            $('#<%=txtItemName.ClientID%>').blur(function ()
            { $("#search_suggest").hide() });
            $('#<%=txtItemName.ClientID%>').focus(function ()
            { $("#search_suggest").show() });
        });


        //Click function
        function setSearch(value) {
            var ss = document.getElementById('search_suggest');
            document.getElementById("<%=txtItemName.ClientID %>").value = value;
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
                        document.getElementById("<%=txtItemName.ClientID %>").value = strOriginal;
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
                        document.getElementById("<%=txtItemName.ClientID %>").value = strOriginal;

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="tboxhead" style="text-align: center; width: 100%; padding-top: 10px;">
        Patient Status</div>
    <table width="100%">
        <tr>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="ValidationSummary"
                    ValidationGroup="save" ForeColor="Red" />
            </td>
            <asp:HiddenField ID="hdfield" runat="server" />
            <asp:HiddenField ID="hdmail" runat="server" />
        </tr>
        <tr id="tbback">
            <td colspan="2">
                <div style="float: left; position: fixed; z-index: 99999; width: 500px; margin: -120px 0 0 200px;">
                    <asp:Panel ID="pnlDetails" runat="server" Width="100%" Style="display: block;visibility:hidden;">
                        <div style="width: 120%; -webkit-border-radius: 20px; -webkit-border-top-right-radius: 3px;
                            -webkit-border-bottom-left-radius: 3px; -moz-border-radius: 20px; -moz-border-radius-topright: 3px;
                            -moz-border-radius-bottomleft: 3px; border-radius: 20px; border-top-right-radius: 3px;
                            border-bottom-left-radius: 1px; -webkit-box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75);
                            -moz-box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75); box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75);
                            overflow: auto; height: 300px; -webkit-box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75);
                            -moz-box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75); box-shadow: 7px 7px 5px rgba(50, 50, 50, 0.75);
                            min-height: 100px; padding: 10px 10px 10px 10px; margin: auto; background-color: #62B1D0;">
                            <table width="100%" id="tbback1">
                                <div style="float: right;">
                                    <input type="button" onclick="callMe();" class="GetMe" value="" />
                                    <%--    <asp:ImageButton ID="ImageButton11" OnClientClick="callMe()" runat="server"  ImageUrl="~/img/Delete.gif"    />
                                    --%>
                                    <%--</a>--%>
                                    <div style="clear: both;">
                                    </div>
                                </div>
                                <div style="text-align: center; font-family: Garamond, serif; line-height: 1em; color: #fff9d6;
                                    font-weight: bold; font-size: 24px; text-shadow: 0px 0px 0 rgb(231,231,231),0px 0px 0 rgb(216,216,216),1px 1px 0 rgb(202,202,202),1px 1px 0 rgb(187,187,187),2px 2px 0 rgb(173,173,173),2px 2px 0 rgb(158,158,158), 3px 3px 0 rgb(144,144,144),3px 3px 3px rgba(0,0,0,0.6),3px 3px 0px rgba(0,0,0,0.5),0px 0px 3px rgba(0,0,0,.2);">
                                    Tracking Status
                                </div>
                                <tr>
                                    <td colspan="3" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Patient Name:
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lblPatientName" runat="server" Font-Bold="true" ForeColor="white"></asp:Label>
                                    </td>
                                    <td width="1%">
                                        DOB:
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lblDOB" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                    </td>
                                    <td width="5%">
                                        CellNo:
                                    </td>
                                    <td width="10%">
                                        <asp:Label ID="lblCellNo" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Lab Id
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLabid" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                    </td>
                                    <td>
                                        PR_No:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblprno" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" align="center">
                                        <asp:GridView ID="gvTestDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                            GridLines="Horizontal" CellPadding="0" CssClass="listing" OnSelectedIndexChanged="gvTestDetails_SelectedIndexChanged">
                                            <RowStyle CssClass="Row" BackColor="#F3EFE0" Font-Size="10px" />
                                            <AlternatingRowStyle HorizontalAlign="Left" CssClass="AltRow" BackColor="#F5F5F5"
                                                Font-Size="10px" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Test Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" Text='<%# Eval("Test_Name")%>' runat="server" class="label"
                                                            Font-Bold="true" Font-Names="Arial" ItemStyle-Width="35%" Font-Size="10px"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="left" />
                                                    <ItemStyle HorizontalAlign="left" Width="25%" />
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Process Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" Text='<%# Eval("process")%>' runat="server" class="label"
                                                        Font-Bold="False" Font-Names="Arial" Font-Size="8pt"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="left" />
                                                <ItemStyle HorizontalAlign="left" Width="25%" />
                                            </asp:TemplateField>--%>
                                                <asp:BoundField DataField="EnteredBy" HeaderText="Tracking Status" SortExpression="EnteredBy" />
                                                <%--   <asp:BoundField DataField="Enteredon"  HeaderText="Process By" SortExpression="Enteredon" />--%>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                    </asp:Panel>
                </div>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="true"
        TargetControlID="btnShowPopup" PopupControlID="pnlDetails" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <%--<div style="text-align:center">
    <asp:RadioButton ID="rbtnPanel" runat="server"  GroupName="gp" Text="Panels:"  AutoPostBack="true"
        oncheckedchanged="rbtnPanel_CheckedChanged" ForeColor="#375B91" />
    <asp:RadioButton ID="rbtnCash"
        runat="server" oncheckedchanged="rbtnCash_CheckedChanged"  AutoPostBack="true" Text="Cash:" ForeColor="#375B91"/>
                         </div>--%>
    <div style="width:100%">
    <div style="float:left; padding-left:7px;">
    <table><tr> 
     <td >
              <asp:RadioButton ID="rdOutDoor" AutoPostBack="true" runat="server" Text="Outdoor" 
                    oncheckedchanged="rdOutDoor_CheckedChanged" ForeColor="Brown" Checked="true" />
            </td>
            <td>
                <asp:RadioButton ID="rdIndoor" AutoPostBack="true" ForeColor="Brown" runat="server" Text="Indoor" 
                    oncheckedchanged="rdIndoor_CheckedChanged" />
            </td></tr></table>
   </div>
       <div style="float:right;">
       
        <asp:ImageButton ID="imgClear" runat="server" ImageUrl="~/images/ClearPack.gif" OnClick="imgClear_Click"
            Visible="true" TabIndex="8" />
        <asp:ImageButton ID="ImageButton1" OnClientClick="HideMe()" runat="server" ImageUrl="~/images/Search.gif"
            OnClick="btnSearch_Click" Visible="true" TabIndex="1" />
        <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click"
            TabIndex="10" />
</div>

<div style="clear:both;"></div>
    </div>
    <table>
        <tr>
            <td width="5%" align="right">
                Cell #:
            </td>
            <td width="10%">
                <asp:TextBox ID="txtCellNo" CssClass="txtareaStyle" runat="server" TabIndex="11"></asp:TextBox>
            </td>
            <td width="5%" align="right">
                Lab ID:
            </td>
            <td width="10%">
                <asp:TextBox ID="txtLabelId" CssClass="txtareaStyle" runat="server" TabIndex="2"></asp:TextBox>
                <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPatientName"
                                                 Font-Bold="True" Font-Size="8pt" CssClass="error" ForeColor="Red" ErrorMessage="Error! Please,Select Patient Name To Proceed"
                                                ValidationGroup="save">*</asp:RequiredFieldValidator>--%>
            </td>
            <td width="10%" align="right">
                Patient Name:
            </td>
            <td width="18%">
                <asp:TextBox ID="txtItemName" CssClass="txtareaStyle" autoComplete="off" Width="97%"
                    runat="server" TabIndex="3"></asp:TextBox>
                <div id="search_suggest" style="z-index: 500 !important; display: none; width: 18%;
                    margin-left: 0.5em; border-color: #A6C9E2; margin-top: -2px;">
                </div>
            </td>
            
           
            <td>
                <a href="javascript:switchover1();" style="color: #3333FF">Advance Search</a>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function switchover1() {
            var div = document.getElementById('Main');
            if (div.style.display == "none")
            { div.style.display = "inline"; }
            else
            { div.style.display = "none"; }
        }
    </script>
  
   <table id="tb2" width="100%" runat="server">
        <tr>
            <td align="center">
                <asp:Image ID="Img_bar" Width="300" style="z-index:999999; position:absolute; margin:auto; margin-left:-60px;" Height="160" runat="server" ImageUrl="~/img/wait.gif" />
                   <div style="position: fixed; top: 0px; bottom: 0px; left: 0px; right: 0px; overflow: hidden; padding: 0; margin: 0; background-color: #F0F0F0; filter: alpha(opacity=60); opacity: 0.6; z-index: 100000;"></div>
            </td>
        </tr>
    </table>


    <fieldset id="Main" style="display: none; font-size: 9px;">
        <legend style="color: Blue;">Search By</legend>
        <table width="100%">
            <tr>
                <td width="5%">
                    From Date:
                </td>
                <td width="10%">
                    <asp:TextBox ID="tbfromdate" CssClass="txtareaStyle" Width="95%" TabIndex="4" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbfromdate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                    <cc1:MaskedEditExtender TargetControlID="tbfromdate" ID="MaskedEditExtender2" runat="server"
                        Mask="99/99/9999" MaskType="Date">
                    </cc1:MaskedEditExtender>
                    <%--<cc1:MaskedEditExtender TargetControlID="tbfromdate" ID="MaskedEditExtender2" 
                runat="server" Mask="9999/99/99" MaskType="Date"></cc1:MaskedEditExtender>--%>
                </td>
                <td width="5%">
                    To Date:
                </td>
                <td width="10%">
                    <asp:TextBox ID="tbtodate" runat="server" CssClass="txtareaStyle" Width="95%" TabIndex="5"></asp:TextBox>
                    <cc1:CalendarExtender ID="CE2" runat="server" TargetControlID="tbtodate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                    <cc1:MaskedEditExtender TargetControlID="tbtodate" ID="MaskedEditExtender1" runat="server"
                        Mask="99/99/9999" MaskType="Date">
                    </cc1:MaskedEditExtender>
                </td>
                <td width="5%">
                    PR_NO:
                </td>
                <td width="10%">
                    <asp:TextBox ID="txtPrNo" runat="server" CssClass="txtareaStyle" TabIndex="6"></asp:TextBox>
                </td>
                <td width="3%">
                    <asp:Label ID="lblPanel" runat="server" Width="40" Text="Panel:"></asp:Label>
                </td>
                <td width="10%">
                    <asp:DropDownList ID="ddlPanel" Font-Size="10px" runat="server" TabIndex="7" Width="100%">
                    </asp:DropDownList>
                    <%--                <asp:Button ID="btnSearch" runat="server" Text="Search"  ValidationGroup="save" Width="20%" TabIndex="3" CssClass="button" OnClick="btnSearch_Click" />--%>
                </td>
                <td width="3%">
                    <asp:Label ID="lblBranch" runat="server" Text="Branch:"></asp:Label>
                </td>
                <td width="10%">
                    <asp:DropDownList ID="ddlBranch" Font-Size="10px" runat="server" TabIndex="7" Width="100%">
                    </asp:DropDownList>
                    <%--                <asp:Button ID="btnSearch" runat="server" Text="Search"  ValidationGroup="save" Width="20%" TabIndex="3" CssClass="button" OnClick="btnSearch_Click" />--%>
                </td>
                <cc1:MaskedEditExtender ID="mas_labid" runat="server" AutoComplete="false" ClearMaskOnLostFocus="false"
                    Mask="99-999-99999999" TargetControlID="txtLabelId">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditExtender ID="mas_prno" runat="server" AutoComplete="false" ClearMaskOnLostFocus="false"
                    Mask="999-99-99999999" TargetControlID="txtPrNo">
                </cc1:MaskedEditExtender>
            </tr>
        </table>
    </fieldset>
    <fieldset id="Fieldset1" style="display: block; font-size: 10px;">
        <legend style="color: Blue;">Note</legend><span class="style2">Specimen Collection</span>=
        SCOL , <span class="style2">Worklist</span>= WLIST ,<span class="style2">Result Entry</span>
        =RENT ,<span class="style2">Result Verification</span>= VERF ,<span class="style2">
            Result Ready</span> = RDY ,<span class="style2"> Refund/Discount</span>=REF
        , <span class="style2">Archived</span> = ARV
    </fieldset>
    <div style="height: 500px;">

    


       <table id="tb1" style="visibility:hidden;" runat="server" width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="Gvonload" runat="server" AutoGenerateColumns="False" Width="100%"
                                DataKeyNames="prid,prno,labid,ProcessID,BranchID,Panel,payment_mode,balance" AllowSorting="True" CssClass="listing"
                                OnSorting="Gvonload_Sorting" OnRowCommand="Gvonload_RowCommand" OnRowDataBound="Gvonload_RowDataBound"
                                AllowPaging="true" PageSize="30" OnPageIndexChanging="Gvonload_PageIndexChanging">
                                <RowStyle CssClass="Row" HorizontalAlign="Left" />
                                <Columns>
                                    <%-- <asp:TemplateField HeaderText="S.No" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center"/>
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="PrNo" SortExpression="PrNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprno" Text='<%# Eval("PrNo")%>' runat="server" class="label" Font-Bold="False"
                                                Font-Names="Arial" Font-Size="8pt"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Visit no" SortExpression="labid">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_labid" Text='<%# Eval("labid")%>' runat="server" class="label"
                                                Font-Bold="False" Font-Names="Arial"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="11%" />
                                    </asp:TemplateField>--%>
                                      <asp:TemplateField HeaderText="Visit No" SortExpression="labid">
                                        <ItemTemplate>
                                            <script type="text/javascript">
                                                function switchover12(obj) {
                                                    var div = document.getElementById(obj);
                                                    if (div.style.display == "none")
                                                    { div.style.display = "inline"; }
                                                    else
                                                    { div.style.display = "none"; }
                                                }

                                       
                                            </script>
                                            <a onmouseover="javascript:switchover12('div<%# Eval("prid") %>');" onmouseout="javascript:switchover12('div<%# Eval("labid") %>');">
                                                <asp:Label ID="lbl_labid" Text='<%# Eval("labid") %>' runat="server"></asp:Label></a><div
                                                    id="div<%# Eval("labid") %>" style="display: none;">
                                                    <fieldset style="background-color: WHITE; border-style: ridge; padding: 0;">
                                                        <table style="background-color: WHITE; padding: 0; font-size: 8px;" width="80px">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbl12" Font-Bold="true" runat="server" Font-Size="10px" ForeColor="Blue" Text='<%# Eval("adm_ref") %>'></asp:Label></td>
                                                                </tr></table></fieldset> </div></ItemTemplate><ItemStyle  />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Hyper_Receipt" runat="server">
                                                <asp:Image ID="Img_printReceipt" Width="14px" ToolTip="Print Receipt" Visible="true"
                                                    ImageUrl="headerfooter/report1.png" runat="server" />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient Name" SortExpression="Patient_Name">
                                        <ItemTemplate>
                                            <script type="text/javascript">
                                                function switchover(obj) {
                                                    var div = document.getElementById(obj);
                                                    if (div.style.display == "none")
                                                    { div.style.display = "block"; }
                                                    else
                                                    { div.style.display = "none"; }
                                                }

                                       
                                            </script>
                                         <%-- <a onmouseover="javascript:switchover('div<%# Eval("labid") %>');" onmouseout="javascript:switchover('div<%# Eval("Patient_Name") %>');">
                                         --%>       <asp:Label ID="lbl_action" Text='<%# Eval("Patient_Name") %>' runat="server"></asp:Label>
                                         <%--  </a>--%>
                                            <div id="div<%# Eval("Patient_Name") %>" style="display: block;">
                                                <fieldset style=" border:0; padding: 0;">
                                                    <table style="padding: 0; font-size: 8px; border-collapse:collapse;" width="80px">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbl" runat="server" Font-Size="7px" ForeColor="Black" Text='<%# Eval("cellno") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Font-Size="7px" Width="100%" ForeColor="Black"
                                                                    Text='<%# Eval("Panel") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:BoundField ItemStyle-Width="18%" DataField="Patient_Name" HeaderText="Patient Name"
                                SortExpression="Patient_Name" />--%>
                                    <%--  <asp:BoundField DataField="age" HeaderText="DOB"
                       <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" /> 
                            SortExpression="dob" />--%>
                                    <asp:BoundField DataField="Test_Name" HeaderText="Test Name" SortExpression="Test_Name"
                                        ItemStyle-Width="20%">
                                        <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <!-- Get Single Report of Test -->
                                            <asp:HyperLink ID="Hyper_Pay" runat="server">
                                                <asp:Image ID="Img_print" Width="14px" ToolTip="Individual test report" Visible="true"
                                                    ImageUrl="headerfooter/pdf.png" runat="server" />
                                            </asp:HyperLink>
                                            <asp:Image ID="Img_cprint" Width="14px" ToolTip="Report is not ready yet" Visible="false"
                                                ImageUrl="headerfooter/cpdf.png" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                        <ItemTemplate >
                                            <asp:Label ID="lblstatus" Text='<%# Eval("Status")%>' runat="server" ForeColor="Green"
                                                class="label" Font-Bold="False" Font-Names="Arial" Font-Size="8pt"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbranch" Text='<%# Eval("Branches")%>' runat="server" class="label"
                                                Font-Bold="False" Font-Names="Arial" Font-Size="8px"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="StatusDate" HeaderText="Booked" SortExpression="StatusDate"
                                        ItemStyle-Width="8%">
                                        <ItemStyle Width="8%" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="balance" HeaderText="Balance" ItemStyle-Width="6%" />--%>
                                    <asp:TemplateField HeaderText="Balance" SortExpression="Balance">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Hyp_Balance" runat="server">
                                                <asp:Label ID="Img_Balance" runat="server" Text='<%# Eval("balance") %>' />
                                            </asp:HyperLink><asp:Label ID="Img_Balance2" Visible="false" runat="server" Text='<%# Eval("balance") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" />
                                    </asp:TemplateField>
                                    <asp:ButtonField ItemStyle-Width="2%" ButtonType="Image" ControlStyle-Width="16px"
                                        ControlStyle-Height="16px" runat="server" CommandName="detail" ImageUrl="~/img/view.png">
                                        <ControlStyle Height="16px" Width="16px" />
                                        <ItemStyle Width="2%" />
                                    </asp:ButtonField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--    <asp:ImageButton ID="ViewTrack" ControlStyle-Width="16px" ControlStyle-Height="16px" runat="server"  CommandName="detail" ImageUrl="~/img/view.png"
                                        />
                                            --%>
                                            <asp:HyperLink ID="Hyper_email" runat="server">
                                                <asp:Image ID="Img_Email" Width="16px" ToolTip="Email Report to patient" Visible="true" ImageUrl="~/img/notification/mail.png"
                                                    runat="server" />
                                                    </asp:HyperLink><asp:HyperLink ID="HyperLink1" runat="server">
                                                <asp:Image ID="cImg_Email" Width="16px" ToolTip="Email cannot sent Report is not Ready" Visible="false" ImageUrl="~/img/notification/index.jpg"
                                                    runat="server" />
                                            </asp:HyperLink><!-- All Test Get--><asp:HyperLink ID="Hyper_PayAll" runat="server">
                                                <asp:Image ID="Img_printAll" ToolTip="Report is ready print all test" Visible="true"
                                                    ImageUrl="../images/PrintAll.gif" runat="server" />
                                            </asp:HyperLink><asp:Image ID="Img_cprintAll" ToolTip="Report is not ready yet" Visible="false"
                                                ImageUrl="headerfooter/cpdf.png" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="8%" />
                                    </asp:TemplateField>
                                    <%-- <asp:ButtonField ItemStyle-Width="3%" ControlStyle-Width="16px" ControlStyle-Height="16px" ButtonType="Image" CommandName="print" ImageUrl="~/transaction/headerfooter/pdf.png"
                                        HeaderText="Print" />--%>
                                </Columns>
                                <AlternatingRowStyle HorizontalAlign="Left" CssClass="AltRow" />
                                <EditRowStyle HorizontalAlign="Left" BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="blue" />
                                <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Left" CssClass="Row" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
        </table>

        
             
<%--
             <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Image runat="server" Width="" Height="" ImageUrl="../images/please_wait.gif" ID="Img_Load" />
                                        </td>
                                    </tr>
                                </table>
                            </ProgressTemplate>
                 </asp:UpdateProgress>
              --%>   
                
           
        <%--<asp:UpdatePanel ID="up_war" runat="server">
            <ContentTemplate>--%>
                <table width="100%" id="tb3" style="visibility:hidden;" runat="server">
                    <tr>
                        <td>
                            <asp:GridView ID="gvPatients" runat="server" AutoGenerateColumns="False" Width="100%"
                                GridLines="Horizontal" CellPadding="0" DataKeyNames="prid,prno,labid,ProcessID,BranchID,Panel,payment_mode,balance"
                                AllowSorting="true" CssClass="listing" OnSorting="gvPatients_Sorting" OnRowCommand="gvPatients_RowCommand"
                                OnRowDataBound="gvPatients_RowDataBound" AllowPaging="true" PageSize="30" OnRowDeleting="gvPatients_RowDeleting"
                                OnPageIndexChanging="gvPatients_PageIndexChanging">
                                <RowStyle CssClass="Row" HorizontalAlign="Left" />
                                <AlternatingRowStyle HorizontalAlign="Left" CssClass="AltRow" />
                                <Columns>
                                    <%-- <asp:TemplateField HeaderText="S.No" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center"/>
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="PrNo" SortExpression="PrNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprno" Text='<%# Eval("PrNo")%>' runat="server" class="label" Font-Bold="False"
                                                Font-Names="Arial" Font-Size="8pt"></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="12%" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Visit no" SortExpression="labid">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_labid" Text='<%# Eval("labid")%>' runat="server" class="label"
                                                Font-Bold="False" Font-Names="Arial"></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="11%" />
                                    </asp:TemplateField>--%>
                                       <asp:TemplateField HeaderText="Visit No" SortExpression="labid">
                                        <ItemTemplate>
                                            <script type="text/javascript">
                                                function switchover12(obj) {
                                                    var div = document.getElementById(obj);
                                                    if (div.style.display == "none")
                                                    { div.style.display = "inline"; }
                                                    else
                                                    { div.style.display = "none"; }
                                                }

                                       
                                            </script>
                                            <a onmouseover="javascript:switchover12('div<%# Eval("PrID") %>');" onmouseout="javascript:switchover12('div<%# Eval("labid") %>');">
                                                <asp:Label ID="lbl_labid" Text='<%# Eval("labid") %>' runat="server"></asp:Label></a><div
                                                    id="div<%# Eval("labid") %>" style="display: none;">
                                                    <fieldset style="background-color: WHITE; border-style: ridge; padding: 0;">
                                                        <table style="background-color: WHITE; padding: 0; font-size: 8px;" width="80px">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbl12" Font-Bold="true" runat="server" Font-Size="10px" ForeColor="Blue" Text='<%# Eval("adm_ref ") %>'></asp:Label></td></tr></table></fieldset> </div></ItemTemplate><ItemStyle ForeColor="Red" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Hyper_Receipt" runat="server">
                                                <asp:Image ID="Img_printReceipt" Width="14px" ToolTip="Print Receipt" Visible="true"
                                                    ImageUrl="headerfooter/report1.png" runat="server" />
                                            </asp:HyperLink></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patient Name" SortExpression="Patient_Name">
                                        <ItemTemplate>
                                            <script type="text/javascript">
                                                function switchover(obj) {
                                                    var div = document.getElementById(obj);
                                                    if (div.style.display == "none")
                                                    { div.style.display = "inline"; }
                                                    else
                                                    { div.style.display = "none"; }
                                                }

                                       
                                            </script>
<%--                                            <a onmouseover="javascript:switchover('div<%# Eval("labid") %>');" onmouseout="javascript:switchover('div<%# Eval("Patient_Name") %>');">
--%>                                                <asp:Label ID="lbl_action" Text='<%# Eval("Patient_Name") %>' runat="server"></asp:Label>
                                               <%-- </a>--%>
                                                <div id="div<%# Eval("Patient_Name") %>" style="display: block;">
                                                    <fieldset style="padding: 0; border:0">
                                                        <table style="padding: 0; border-collapse:collapse; font-size: 8px;" width="80px">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbl" runat="server" Font-Size="10px" ForeColor="Black" Text='<%# Eval("cellno") %>'></asp:Label></td></tr><tr>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Font-Size="10px" ForeColor="Black" Text='<%# Eval("Panel") %>'></asp:Label></td></tr></table></fieldset> </div></ItemTemplate><ItemStyle ForeColor="Red" />
                                    </asp:TemplateField>
                                    <%--  <asp:BoundField ItemStyle-Width="18%" DataField="Patient_Name" HeaderText="Patient Name"
                                SortExpression="Patient_Name" />--%>
                                    <%--  <asp:BoundField DataField="age" HeaderText="DOB"
                       <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" /> 
                            SortExpression="dob" />--%>
                                    <asp:BoundField DataField="Test_Name" HeaderText="Test Name" SortExpression="Test_Name"
                                        ItemStyle-Width="20%" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <!-- Get Single Report of Test -->
                                            <asp:HyperLink ID="Hyper_Pay" runat="server">
                                                <asp:Image ID="Img_print" Width="14px" ToolTip="Individual test report" Visible="true"
                                                    ImageUrl="headerfooter/pdf.png" runat="server" />
                                            </asp:HyperLink><asp:Image ID="Img_cprint" Width="14px" ToolTip="Report is not ready yet"
                                                Visible="false" ImageUrl="headerfooter/cpdf.png" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" HorizontalAlign="Left"  />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status"   SortExpression="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" Text='<%# Eval("Status")%>' runat="server" ForeColor="Green"
                                                class="label" Font-Bold="False" Font-Names="Arial" Font-Size="8pt"></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbranch" Text='<%# Eval("Branches")%>' runat="server" class="label"
                                                Font-Bold="False" Font-Names="Arial" Font-Size="8px"></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="StatusDate" HeaderText="Booked" SortExpression="StatusDate"
                                        ItemStyle-Width="8%" />
                                    <%--<asp:BoundField DataField="balance" HeaderText="Balance" ItemStyle-Width="6%" />--%>
                                    <asp:TemplateField HeaderText="Balance" SortExpression="balance">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Hyp_Balance" runat="server">
                                                <asp:Label ID="Img_Balance" runat="server" Text='<%# Eval("balance") %>' />
                                            </asp:HyperLink><asp:Label ID="Img_Balance2" Visible="false" runat="server" Text='<%# Eval("balance") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" />
                                    </asp:TemplateField>
                                    <asp:ButtonField ItemStyle-Width="2%" ButtonType="Image" ControlStyle-Width="16px"
                                        ControlStyle-Height="16px" runat="server" CommandName="detail2" ImageUrl="~/img/view.png" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--    <asp:ImageButton ID="ViewTrack" ControlStyle-Width="16px" ControlStyle-Height="16px" runat="server"  CommandName="detail" ImageUrl="~/img/view.png"
                                        />
                                            --%>
                                            <asp:HyperLink ID="Hyper_email" runat="server">
                                                <asp:Image ID="Img_Email" Width="16px" ToolTip="Sent Email" Visible="true" ImageUrl="~/img/notification/mail.png"
                                                    runat="server" />
                                            </asp:HyperLink><!-- All Test Get--><asp:HyperLink ID="HyperLink1" runat="server">
                                                <asp:Image ID="cImg_Email" Width="16px" ToolTip="Email cannot sent Report is not Ready" Visible="false" ImageUrl="~/img/notification/index.jpg"
                                                    runat="server" />
                                            </asp:HyperLink><asp:HyperLink ID="Hyper_PayAll" runat="server">
                                                <asp:Image ID="Img_printAll" ToolTip="Report is ready print all test" Visible="true"
                                                    ImageUrl="../images/PrintAll.gif" runat="server" />
                                            </asp:HyperLink><asp:Image ID="Img_cprintAll" ToolTip="Report is not ready yet" Visible="false"
                                                ImageUrl="headerfooter/cpdf.png" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="8%" />
                                    </asp:TemplateField>
                                    <%-- <asp:ButtonField ItemStyle-Width="3%" ControlStyle-Width="16px" ControlStyle-Height="16px" ButtonType="Image" CommandName="print" ImageUrl="~/transaction/headerfooter/pdf.png"
                                        HeaderText="Print" />--%>
                                </Columns>
                                <EditRowStyle HorizontalAlign="Left" BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Left" CssClass="Row" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
         <%--   </ContentTemplate>
                    <Triggers>
                     
                        <asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click" />
                    </Triggers>
        </asp:UpdatePanel>--%>
    </div>
</asp:Content>
