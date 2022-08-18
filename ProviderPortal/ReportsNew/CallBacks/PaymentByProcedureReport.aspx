<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentByProcedureReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PaymentByProcedureReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
              ###startReport###
        <div class="TimeSpan">
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="TimeSpan"></asp:Label>
        </div>
                

               <asp:Repeater ID="rptPaymentByProcedure" runat="server" OnItemDataBound="rptPaymentByProcedure_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Code');">
                                                        <span class="report-column-title">Code</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Description');" style="width:35%">
                                                        <span class="report-column-title">Description</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AvgPaymentByPrimary');">
                                                        <span class="report-column-title">Avg Payment By Primary</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AvgPaymentBySecondary');">
                                                        <span class="report-column-title">Avg Payment By Secondary</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AvgPaymentByPatient');">
                                                        <span class="report-column-title">Avg Payment By Patient</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AvgTotalPayment');">
                                                        <span class="report-column-title">Avg Total Payment</span><span></span>
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
                                            <%--<%# Eval("AvgPaymentByPrimary")%>--%>
                                            <asp:Label ID="lblAvgPaymentByPrimary" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("AvgPaymentBySecondary")%>--%>
                                            <asp:Label ID="lblAvgPaymentBySecondary" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("AvgPaymentByPatient")%>--%>
                                            <asp:Label ID="lblAvgPaymentByPatient" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <%--<%# Eval("AvgTotalPayment")%>--%>
                                            <asp:Label ID="lblAvgTotalPayment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                </ItemTemplate>
                                <FooterTemplate>
                                              </tbody>
                                    <tfooter>
                                        <tr class="BtmToatlTr">
                                            <td style="border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-top:1px solid #C4C4C4;font-weight:bold; float:right; width:98%;" id="tdTotal" runat="server">
                                                <asp:Label ID="lblTotalLabel" runat="server">Average Evaluatin and Management</asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotaAvgPaymentByPrimary" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalAvgPaymentBySecondary" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalAvgPaymentByPatient" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalAvgTotalPayment" runat="server"></asp:Label></td>
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
                var DateFrom=$("[id$='hdnDateFrom']").val();
                var DateTo = $("[id$='hdnDateTo']").val();
                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {
                        DateFrom: DateFrom,
                        DateTo:DateTo,
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
    </form>
</body>
</html>
