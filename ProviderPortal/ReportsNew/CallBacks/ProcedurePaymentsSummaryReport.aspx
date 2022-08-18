<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcedurePaymentsSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ProcedurePaymentsSummaryReport" %>

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
                                  <asp:Repeater ID="rptProcedurePaymentsSummary" runat="server">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Code');">
                                                        <span class="report-column-title">Post Code</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Description'); " style="width:30%">
                                                        <span class="report-column-title">Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Qty');">
                                                        <span class="report-column-title">Quantity</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AVGCharges');">
                                                        <span class="report-column-title">Avg Charges</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'TotalCharges');">
                                                        <span class="report-column-title">Total Charges</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AVGInsurancePmt');">
                                                        <span class="report-column-title">Avg Insurance Payment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AVGPatientpmt');">
                                                        <span class="report-column-title">Avg Patient Payment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AVGAdjustments');">
                                                        <span class="report-column-title">Avg Adjustments</span><span></span>
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
                                            <%# Eval("Code")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Description]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Qty")%>
                                        </td>
                                        <td>
                                            <%# Eval("AVGCharges")%>
                                        </td>
                                        <td>
                                            <%# Eval("TotalCharges")%>
                                        </td>
                                        <td>
                                            <%# Eval("AVGInsurancePmt")%>
                                        </td>
                                        <td>
                                            <%# Eval("AVGPatientpmt")%>
                                        </td>
                                        <td>
                                            <%# Eval("AVGAdjustments")%>
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
