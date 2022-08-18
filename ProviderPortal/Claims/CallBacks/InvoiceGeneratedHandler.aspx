<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvoiceGeneratedHandler.aspx.cs" Inherits="ProviderPortal_Claims_CallBacks_InvoiceGeneratedHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function hideShowMenu(divMultipleDropdownCheckboxList) {
            debugger;
            if (divMultipleDropdownCheckboxList == "divItems") {
                debugger;
                $("#" + divMultipleDropdownCheckboxList).slideToggle();
                $("#divReportServiceProvider").hide();
                $("#divReportTaskStatus").hide();
                $("#divReportMonths").hide();
                $("#divReportAgencyInsurance").hide();
            }
            else if (divMultipleDropdownCheckboxList == "divReportPatient") {
                debugger;
                $("#" + divMultipleDropdownCheckboxList).slideToggle();
                $("#divReportServiceProvider").hide();
                $("#divReportTaskStatus").hide();
                $("#divReportMonths").hide();
                $("#divReportAgencyInsurance").hide();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
           
     <asp:Repeater ID="rptClientInvoices" runat="server">
         <ItemTemplate>
             <tr class="DataRow" onclick="GetClientInvoiceDetail(this);">
                 <td>
                     <input type="hidden" class="hdnClientinvoiceId" value='<%# Eval("ClientinvoiceId")%>' />
                     <%--<input type="hidden" class="hdnCheckNumber" value='<%# Eval("CheckNumber")%>' />--%>
                     <i>
                         <%# Eval("RowNumber") %></i>
                 </td>
                 <td id="<%# Eval("InvoiceNumber") %>">
                     <%# Eval("InvoiceNumber") %>
                 </td>
                 <td>
                     <%# Eval("StatementFrom", "{0:d}") %> - <%# Eval("StatementTo", "{0:d}") %>
                 </td>
                 <td>
                     <%# Eval("InvoiceDueDate", "{0:d}") %>
                 </td>
                 <td>
                     <%# Eval("BillDate", "{0:d}") %>
                 </td>
                 <td>
                     <%# Eval("TotalCharges","{0:c}") %>
                 </td>
                 <td>Unpaid
                 </td>

                <%-- <td>
                     <img src="../../Images/MasterCard.png" style="width: 20%;" />
                     <img src="../../Images/Visa.png" style="width: 20%;" />
                     <img src="../../Images/AmericanExpress.png" style="width: 20%;" />
                     <img src="../../Images/Discover.png" style="width: 20%;" />
                 </td>--%>
             </tr>
         </ItemTemplate>
     </asp:Repeater>
            ###End###
    
     ###StartERARowsCount###
    <asp:Literal runat="server" ID="ltrlERARowsCount"></asp:Literal>
            ###EndERARowsCount###
        </div>
    </form>
</body>
</html>
