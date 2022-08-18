<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DenialsSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_DenialsSummaryReport" %>

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

          <asp:Repeater ID="rptDenialsSummary" runat="server" OnItemDataBound="rptDenialsSummary_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="ReportGrid"> 
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'DenialReason');">
                                                        <span class="report-column-title">Denial Reason</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'DenialReason');">
                                                        <span class="report-column-title">Total</span><span></span>
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
                                            <%# Eval("DenialReason")%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>

   <asp:HiddenField ID="hdnPracticeId" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
    <asp:HiddenField runat="server" ID="hdnProviderId" />
    <asp:HiddenField runat="server" ID="hdnDateType" />
    <asp:HiddenField runat="server" ID="hdnInsurance" />
    <asp:HiddenField runat="server" ID="hdnAdjustmentCode" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
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
                        DateType: $("[id$='hdnDateType']").val(),
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
                        ProviderId: $("[id$='hdnProviderId']").val(),
                        PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                        Insurance: $("[id$='hdnInsurance']").val(),
                        AdjustmentCode: $("[id$='hdnAdjustmentCode']").val(),
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
