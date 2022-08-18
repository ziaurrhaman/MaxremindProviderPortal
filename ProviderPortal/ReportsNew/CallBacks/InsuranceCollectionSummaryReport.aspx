<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsuranceCollectionSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_InsuranceCollectionSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###startReport###

         <asp:Repeater ID="rptInsuranceCollectionSummary" runat="server" OnItemDataBound="rptInsuranceCollectionSummary_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Claim Status</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Period</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Encounters</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Procedures</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Value</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">A/R</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">% Of A/R</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Age</span><span></span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="trClaimStatus" runat="server" style="display:none;">
                                        <th id="thClaimStatus" runat="server" colspan="8">
                                            <%--<asp:Label ID="lblClaimStatus" runat="server"></asp:Label>--%>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblClaimStatus" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPeriod" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalPeriod" runat="server"></asp:Label>
                                            <asp:Label ID="lblGranTotalPeriod" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEncounters" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProcedures" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblValue" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblARBalance" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPercentageOfAR" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAge" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trLastClaimStatus" runat="server" style="display:none;">
                                        <th id="thLastClaimStatus" runat="server" colspan="8">
                                            <asp:Label ID="lblLastClaimStatus" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>



         <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnAgingDate" />
    <asp:HiddenField runat="server" ID="hdnAgingType" />
    <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
    <asp:HiddenField runat="server" ID="hdnProviderId" />
    <asp:HiddenField runat="server" ID="hdnPayerId" />
    <asp:HiddenField runat="server" ID="hdnClaimStatus" />

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
                        AgingDate: $("[id$='hdnAgingDate']").val(),
                        AgingType: $("[id$='hdnAgingType']").val(),
                        PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                        ProviderId: $("[id$='hdnProviderId']").val(),
                        PayerId: $("[id$='hdnPayerId']").val(),
                        ClaimStatus: $("[id$='hdnClaimStatus']").val(),
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
