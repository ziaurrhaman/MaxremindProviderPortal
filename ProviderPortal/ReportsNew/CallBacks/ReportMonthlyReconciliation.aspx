<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportMonthlyReconciliation.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ReportMonthlyReconciliation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###startReport###
        <div class="TimeSpan" >
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="TimeSpan"></asp:Label>

              <span>Location</span>
            <asp:Label runat="server" ID="LblLocation"></asp:Label>

            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                 <span>Total Claims:</span>
            <asp:Label runat="server" ID="lblTotalClaims"></asp:Label>

                 &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                 <span>Total Patients:</span>
                <asp:Label runat="server" ID="lblTotalPatients"></asp:Label>
            </div>


        <asp:Repeater ID="rptMonthlyReconciliation" runat="server" OnItemDataBound="rptMonthlyReconciliation_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Patient</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimId');">
                                                        <span class="report-column-title">Claim Id</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'DOS');">
                                                        <span class="report-column-title">DOS</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'CheckNumber');">
                                                        <span class="report-column-title">Check Number</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'CheckIssueDate');">
                                                        <span class="report-column-title">Check Issue Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PaymentAmount');">
                                                        <span class="report-column-title">Payment Amount</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Payer Name</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'UnpaidClaims');">
                                                        <span class="report-column-title">Unpaid Claims</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Remarks');">
                                                        <span class="report-column-title">Remarks</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'St');">
                                                        <span class="report-column-title">Status</span><span></span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("Patient")%>
                                        </td>
                                        <td>
                                            <%# Eval("claimId")%>
                                        </td>
                                        <td>
                                            <%# Eval("DOS")%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCheckNumber" runat="server">"<%# Eval("CheckNumber")%>"</asp:Label>
                                        </td>
                                        <td>
                                            <%# Eval("CheckIssueDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("PaymentAmount")%>
                                        </td>
                                        <td>
                                            <%# Eval("Payername")%>
                                        </td>
                                        <td>
                                            <%# Eval("UnpaidClaims")%>
                                        </td>
                                        <td>
                                            <%# Eval("Remarks")%>
                                        </td>
                                        <td>
                                            <%# Eval("St")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                              </tbody>
                                        </tfooter>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>

   <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnLocationId" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
     <asp:HiddenField runat="server" ID="hdnProvider" />
    <asp:HiddenField runat="server" ID="hdnProviderType" />
    <div id="divDialogReportFilters" style="display: none;"></div>


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
                        LocationId: $("[id$='hdnLocationId']").val(),
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
                        Rows: $("#ddlPagingReport").val(),
                        Provider: $("[id$='hdnProvider']").val(),
                        ProviderType: $("[id$='hdnProviderType']").val(),
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
