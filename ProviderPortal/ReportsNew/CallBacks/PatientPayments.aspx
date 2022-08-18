<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientPayments.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientPayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         ###startReport###
             <div class="GridReports" id="printableArea">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                <span class="report-column-title">Patient Account</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaymentMethod');">
                                                <span class="report-column-title">Payment Method</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                <span class="report-column-title">Payer Name</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'CheckNumber');">
                                                <span class="report-column-title">Check/Ref #</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaymentDate');">
                                                <span class="report-column-title">Payment Date</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaidAmount');">
                                                <span class="report-column-title">Paid Amount</span><span></span>
                                            </th>
                                               <th class="asc" onclick="SortReportList(this,'PostDate');">
                                                <span class="report-column-title">Post Date</span><span></span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyReportList">
                                        <asp:Repeater ID="rptReportData" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentMethod")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PayerName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckIssueDate")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentAmount")%>
                                                    </td>
                                                     <td>
                                                        <%# Eval("PostDate")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>


    <input type="hidden" id="hdnTotalRows" runat="server" value="0"/>
    <asp:HiddenField runat="server" ID="hdnDateType" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />




        
        <script type="text/javascript">
            var Rows1 = "";
            function RowsChange(PageNumber) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();
                var DateFrom = $("[id$='hdnDateFrom']").val();
                var DateTo = $("[id$='hdnDateTo']").val();
                var DateType = $("[id$='hdnDateType']").val();
                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {
                        DateFrom: DateFrom,
                        DateTo: DateTo,
                        DateType: DateType,
                        Rows: Rows1,
                        PageNumber: pageNumber,
                        //SortBy: _SortBy + " " + _SortByValue,
                        action: "Filter"
                    };

                    debugger
                    Report_ReloadData(_selectedReport_Filter, params, paging);
                }
            }
        </script>




         ###endReport###
    </div>
    </form>
</body>
</html>
