<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientBalanceDetailReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientBalanceDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script src="../js/MainReport.js"></script>
        <script src="../js/SummaryReports.js"></script>
        <script src="../js/FilterReports.js"></script>
        <script src="../js/CustomizeFiltersModal.js"></script>
        <div>
            ###startReport###
        <div class="Filter SearchCriteria" style="height: auto !important;">
            <div class="row">
                <div class="col-lg-3" style="padding-bottom: 0px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Dates:</span>
                        <div class="BranceInput" style="">
                            <select class="" id="ddlSelectDate" onchange="GetDates(this)" style="">
                                <option value="today" selected="selected">Today</option>
                                <option value="yesterday">Yesterday</option>
                                <option value="Custom">Custom</option>

                            </select>

                        </div>
                    </div>
                </div>
                <div class="col-lg-3 SelectDates" style="padding-bottom: 0px; padding-top: 0 !important;">
                    <span class="spnBranchName" style="">As of:</span>

                    <div class="BranceInput" style="">
                        <input type="date" id="dateasof" class="Datetxtbox" style="width: 100%;" placeholder="Date To" />

                    </div>
                </div>
                <div class="col-lg-3">
                    <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientBalanceDetail()" />

                    <input class='btn primary' type="button" title="Customize" value="Customize" id="CustomizeReports" onclick="CustomizePatientBalanceDetailReport()" disabled="disabled" />


                </div>
            </div>
        </div>

            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <div class="GridReports" id="printableArea">
                <table>
                    <thead>
                        <tr>
                            <th>
                                <span class="report-column-title">#</span><span></span>
                            </th>

                            <th class="asc">
                                <span class="report-column-title">Service Date</span><span class="asc"></span>
                            </th>
                            <th class="asc">
                                <span class="report-column-title">Code</span><span></span>
                            </th>
                            <th class="asc" style="white-space:normal !important;">
                                <span class="report-column-title">Procedure</span><span></span>
                            </th>
                            <th class="asc">
                                <span class="report-column-title">Charges</span><span></span>
                            </th>
                            <th class="asc">
                                <span class="report-column-title">Adjustments</span><span></span>
                            </th>
                            <th class="asc">
                                <span class="report-column-title">Insurance Payment</span><span></span>
                            </th>
                            <th class="asc">
                                <span class="report-column-title">Patient Payment</span><span></span>
                            </th>
                            <th class="asc">
                                <span class="report-column-title">Total Balance</span><span></span>
                            </th>
                            <th class="asc">
                                <span class="report-column-title">Pending Insurance</span><span></span>
                            </th>
                            <th class="asc">
                                <span class="report-column-title">Patient Balance</span><span></span>
                            </th>
                        </tr>

                    </thead>
                    <asp:Repeater ID="rptPatientBalanceDetail" runat="server" OnItemDataBound="rptPatientBalanceDetail_ItemDataBound">
                        <HeaderTemplate>
                            <tbody id="tbodyReportList">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center;">
                                    <%# Eval("RowNumber")%>
                                </td>


                                <td>
                                    <%# Eval("servicedate")%>
                                </td>
                                <td>
                                    <%# Eval("code")%>
                                </td>
                                <td style="white-space:normal !important;">
                                    <%# Eval("[procedure]")%>
                                </td>
                                <td>
                                    <%--<%# Eval("charges")%>--%>
                                    <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%-- <%# Eval("adjustments")%>--%>
                                    <asp:Label ID="lbladjustments" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%-- <%# Eval("Insurancepmt")%>--%>
                                    <asp:Label ID="lblInsurancepmt" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%--<%# Eval("PatientPmt")%>--%>
                                    <asp:Label ID="lblPatientPmt" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%-- <%# Eval("TotalBalance")%>--%>
                                    <asp:Label ID="lblTotalBalance" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%--<%# Eval("PendingIns")%>--%>
                                    <asp:Label ID="lblPendingIns" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%--<%# Eval("Patientbalance")%>--%>
                                    <asp:Label ID="lblPatientbalance" runat="server"></asp:Label>
                                </td>
                                <%--  <td>
                                            <%# Eval("ProcedurePaymentsid")%>
                                        </td>--%>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        </FooterTemplate>
                    </asp:Repeater>
                    <tfoot>
                        <td style="border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-top: 1px solid #C4C4C4; font-weight: bold; float: right; width: 98%;">Grand Total</td>
                        <td style="border-top: 1px solid #C4C4C4;" id="TotalCharges">
                            <asp:Label ID="lblTotalCharges" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;" id="TotalAdjustments">
                            <asp:Label ID="lblTotalAdjustments" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;" id="TotalInsurancePayments">
                            <asp:Label ID="lblTotalInsurancePayments" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;" id="TotalPatientPayments">
                            <asp:Label ID="lblTotalPatientPayments" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;" id="GrandTotalBalance">
                            <asp:Label ID="lblGrandTotalBalance" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;" id="PendingIns">
                            <asp:Label ID="lblPendingIns" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;" id="Patientbalance">
                            <asp:Label ID="lblPatientbalance" runat="server"></asp:Label></td>
                    </tfoot>
                </table>

            </div>


            <asp:HiddenField ID="hdnPatientId" runat="server" />
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <div id="divDialogReportFilters" style="display: none;"></div>
            <asp:HiddenField ID="hdnProcedureCode" runat="server" />
            <asp:HiddenField ID="hdnDOB" runat="server" />
            <asp:HiddenField ID="hdnCustomDate" runat="server" />


            <script type="text/javascript">
                debugger;
                var Rows1 = "";
                function RowsChange(PageNumber, sortValue) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        params = {
                            PatientId: $("[id$='hdnPatientId']").val(),
                            ProcedureCode: $("[id$='hdnProcedureCode']").val(),
                            DOB: $("[id$='hdnDOB']").val(),
                            CustomDate: $("[id$='hdnCustomDate']").val(),
                            AsOf: $("[id$='dateasof']").val(),
                         
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
