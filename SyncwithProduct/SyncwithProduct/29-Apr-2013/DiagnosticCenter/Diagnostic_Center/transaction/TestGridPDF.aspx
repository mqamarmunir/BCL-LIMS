<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="TestGridPDF.aspx.cs" Inherits="transaction_TestGridPDF" %>

<html>
<head>
<title></title>
<style type="text/css">

</style>
</head>
<body>
<form runat="server" id="form1">
    
   
            
  
  <table width="100%" style="border:1px solid #000; page-break-after: avoid; page-break-before: always;">
	<tr>
		<td valign="top" height="100">
            First HEADER, this should be only once per document. (Document number: ##docnumber##)
		</td>
	</tr>
</table>

<table height="100%" width="100%" style="border:1px solid #000; page-break-before: avoid; page-break-after: always">
    <thead style="page-break-inside: avoid;">
        <tr>
		    <td valign="top" style="border:1px solid #000;">
                List HEADER, this should be on every top of the list. (Document number: ##docnumber##)
            </td>
        </tr>
    <thead>
    <tbody>
		##prod## --> here you insert the rows dynamic
          <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" 
                onrowdatabound="GridView1_RowDataBound">
     <Columns>
         <asp:TemplateField>
             <ItemTemplate>
                 <asp:Label runat="server" ID="test_name" Text='<%# Eval("test_name") %>'></asp:Label>
             </ItemTemplate>
         </asp:TemplateField>
     </Columns>
    </asp:GridView>
    </tbody>
	<tr>
		<td valign="top" style="border:1px solid #000;">
		    <!-- Lista -->
			The document footer, this should be only at the end of the document not on every page as a page footer. (Document number: ##docnumber##)
			<!-- L -->
		</td>
	</tr>
</table>

   <%-- <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />--%>
   </form>
    </body>





    </html>