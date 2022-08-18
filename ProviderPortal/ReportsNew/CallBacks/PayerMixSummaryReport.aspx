<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayerMixSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PayerMixSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       ###startReport###
        <div class="TimeSpan">
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="TimeSpan"></asp:Label>
        </div>
               
        
          <asp:Repeater ID="rptPayerMixSummary" runat="server" OnItemDataBound="rptPayerMixSummary_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Payer</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Patients</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Patients(%)</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Encounters</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Encounters(%)</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Procedures</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Procedures(%)</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Charges</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Charges(%)</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Receipts</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Receipts(%)</span><span></span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("PayerName")%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPatient" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPtnt" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEncounter" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEncntrs" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProcedure" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProc" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblChrgs" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblReceipt" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRcpts" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                   
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>
         

        <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />

        <script>
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();
                var DateFrom = $("[id$='hdnDateFrom']").val();
                var DateTo = $("[id$='hdnDateTo']").val();
                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {
                        DateFrom: DateFrom,
                        DateTo: DateTo,
                        Rows: Rows1,
                        PageNumber: pageNumber,
                        SortBy: sortValue,
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
