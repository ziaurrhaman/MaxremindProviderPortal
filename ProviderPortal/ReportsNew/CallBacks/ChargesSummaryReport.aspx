<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargesSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ChargesSummaryReport" %>

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

         <asp:Repeater ID="rptChargesSummary" runat="server" OnItemDataBound="rptChargesSummary_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Procedures</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Procedure Amount</span>
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
                                           <%-- <%# Eval("Total")%>--%>
                                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="2" style="border-top:1px solid #C4C4C4; font-weight:bold; text-align:center;"><asp:Label ID="lblTotalLabel" runat="server"></asp:Label> <asp:Label ID="lblPracticeName" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4; font-weight:bold;"><asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>

  <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
           <asp:HiddenField runat="server" ID="hdnPatId" />
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
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
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
