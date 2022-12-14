<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentsSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PaymentsSummaryReport" %>

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
           <asp:Repeater ID="rptPaymentsSummary" runat="server" OnItemDataBound="rptPaymentsSummary_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">Payer Type</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Amount</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Unapplied</span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("Payertype")%>
                                        </td>
                                        <td>
                                            <%--<%# Eval("[Amount]")%>--%>
                                            <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("Unapplied")%>--%>
                                            <asp:Label ID="lblUnapplied" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                       <tfooter>
                                        <tr class="BtmToatlTr">
                                            <td style="border-left:none; border-top:1px solid #C4C4C4;font-weight:bold; float:right; width:98%;"><asp:Label ID="lblGrandTotal" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalAmount" runat="server" Style="font-weight:bold"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalUnapplied" runat="server" Style="font-weight:bold"></asp:Label></td>
                                            </tr>
                                        </tfooter>
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
