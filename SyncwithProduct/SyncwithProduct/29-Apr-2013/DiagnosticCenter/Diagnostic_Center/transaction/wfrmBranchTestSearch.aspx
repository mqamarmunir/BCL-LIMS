<%@ Page Title="" Language="C#" MasterPageFile="~/CahierMasterPage.master" AutoEventWireup="true" CodeFile="wfrmBranchTestSearch.aspx.cs" Inherits="transaction_wfrmBranchTestSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>


<style type="text/css" media="screen">	
	   .suggest_link 
	   {
	   background-color: #FFFFFF;
	   padding: 2px 6px 2px 6px;
	   }	
	   .suggest_link_over
	   {
	   background-color:#e0f0ff;
	   color:Black;
	   padding: 2px 6px 2px 6px;
	   cursor:pointer;	
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
        width: 5%;
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

                    searchReq.open("GET", 'GoogleSearch.aspx?search=' + str, true);

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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="tboxhead" style="text-align:center; width:100%; padding-top:10px;">Investigation Rate</div>

    <table width="100%">
 <tr> <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="ValidationSummary"
                        ValidationGroup="save" ForeColor="Red" />
                </td>
               
            </tr>
            <tr> <td colspan="2" align="right">
                
     <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/img/search.png" ToolTip="Search " Visible="false"
                    OnClick="btnSearch_Click" CausesValidation="true"   ValidationGroup="save" TabIndex="4" Height="17px" Width="17px"/>
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/images/Search.gif"  Visible="true" TabIndex="5" onclick="ImageButton1_Click" 
                   />
                <asp:ImageButton ID="imgClear" runat="server" 
                    ImageUrl="~/images/ClearPack.gif"  Visible="true" TabIndex="5" 
                    onclick="imgClear_Click" /><asp:ImageButton
                        ID="imgClose" runat="server" ImageUrl="~/images/ClosePack.gif"  
                    TabIndex="6" onclick="imgClose_Click" /></td></tr>
                    </table>
                    <fieldset>
                    <table>
 <tr>
           <%-- <td width="10%" >
                Branch Name:</td>
            <td width="20%" >
                <asp:DropDownList ID="ddlBranch" runat="server"  AutoPostBack="true" CssClass="txtareaStyle"
                    onselectedindexchanged="ddlBranch_SelectedIndexChanged">
                </asp:DropDownList>
            
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlBranch"
                                                 Font-Bold="True" Font-Size="8pt" InitialValue="-1" CssClass="error" ForeColor="Red" ErrorMessage="Error! Please,Select Branch To Proceed"
                                                ValidationGroup="save">*</asp:RequiredFieldValidator>
             
            </td>--%>
            <td class="style1" >
                Investigantion :</td>
            <td  width="20%">

  <asp:TextBox ID="txtItemName" Width="67%" runat="server" autocomplete="off" CssClass="txtareaStyle" ></asp:TextBox>
    <div id="search_suggest" style="width:31%; margin-left:0.5em;  border-color:#A6C9E2; margin-top:-2px;"></div>

               <%-- <asp:TextBox ID="txttest" runat="server" CssClass="txtareaStyle" Width="90%" TabIndex="2"></asp:TextBox>--%>
            
                                                 
                                               
            </td>
              </tr>
              <tr> 
          <td class="style1" >
                Sub Department:</td>
            <td width="20%" >
                <asp:DropDownList ID="ddlsubDept" CssClass="txtareaStyle" runat="server">
                </asp:DropDownList>
            
                 
             
            </td>
          
         

              
        <td width="20%" >
              <%-- <asp:Button ID="btnSearch" runat="server" Text="Search"  ValidationGroup="save" Width="20%" TabIndex="3" CssClass="button" OnClick="btnSearch_Click" />--%>
            </td>
          
            
            </tr>
            <tr>  
           <td class="style1" >
                Test Group:</td>
            <td width="20%" >
                <asp:DropDownList ID="ddltestgroup" CssClass="txtareaStyle" runat="server">
                </asp:DropDownList>
            
             
            </td>
            
           
            </tr>
          
            </table>
            </fieldset>
              <table width="100%"><tr>
              <td>
              <asp:GridView id="gvTest"  runat="server" Width="95%" 
ToolTip="View Test Information"  DataKeyNames="TestId" CssClass="listing" AutoGenerateColumns="False" AllowSorting="True" 
                      onsorting="gvTest_Sorting"  >
   <RowStyle CssClass="Row" />
                         <AlternatingRowStyle HorizontalAlign="Left"   CssClass="AltRow"/>
                            <Columns>
                                <asp:TemplateField HeaderText="S#"><ItemStyle HorizontalAlign="Center" Width="5%" /><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                <asp:BoundField DataField="subname" HeaderText="Sub-Dept" ReadOnly="True" SortExpression="subname">
                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Test_Name" HeaderText="Test Name" ReadOnly="True" SortExpression="NAME">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle HorizontalAlign="Left" ForeColor="Blue" />
                                </asp:BoundField>
                                <asp:BoundField DataField="defaultmethod" HeaderText="Method" Visible="false">
                                    <ControlStyle Width="30%" />
                                    <ItemStyle Width="20%" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GroupName" HeaderText="Group" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Specimen_Name" HeaderText="Specimen">
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="charges" HeaderText="Charges">
                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="charityrate" HeaderText="Charity">
                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                               <%-- <asp:BoundField DataField="dorder" HeaderText="Dorder">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                </asp:BoundField>--%>
                                <asp:TemplateField HeaderText="Active">
                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkgvActive" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                    <ControlStyle Width="10%" />
                                </asp:TemplateField>
                               <%-- <asp:CommandField ShowEditButton="True" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <ControlStyle Width="10%" />
                                </asp:CommandField>
                                <asp:CommandField ShowSelectButton="true" SelectText="Edit" />--%>
                            </Columns>
                            <AlternatingRowStyle HorizontalAlign="Left" BackColor="White" />
                <EditRowStyle HorizontalAlign="Left" BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" Font-Bold="True" 
                    ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Left" BackColor="#D1EED6" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView></td></tr>
            </table>
</asp:Content>

