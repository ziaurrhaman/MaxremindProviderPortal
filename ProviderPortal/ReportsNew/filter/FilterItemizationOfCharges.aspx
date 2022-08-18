<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterItemizationOfCharges.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterItemizationOfCharges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
               ###Start###
          <%--<div class="TimeSpan">
              <span style="font-weight: 600">Time Span:</span>
              <asp:Label runat="server" ID="TimeSpan"></asp:Label>
          </div>--%>
        <div id="divReportListing">

            <asp:Repeater ID="rptItemizationOfCharges" runat="server" OnItemDataBound="rptItemizationOfCharges_ItemDataBound">
                <HeaderTemplate>
                    <div class="ReportGrid GridReports">
                        <table>
                            <thead>
                                <tr>
                                    <th>
                                        <span class="report-column-title">#</span><span></span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Visit #</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Patient</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Provider</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">DOS</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Post Date</span>
                                    </th>

                                    <th>
                                        <span class="report-column-title">Codes</span>
                                    </th>
                                    <th style="width: 30%">
                                        <span class="report-column-title">Procedure Description</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Charges</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Adjustments</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Payments</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Balance</span>
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
                            <%# Eval("[Visit #]")%>
                        </td>
                        <td>
                            <%# Eval("Patient")%>
                        </td>
                        <td style="text-align: center;">
                            <%# Eval("Provider")%>
                        </td>
                        <td>
                            <%# Eval("DOS","{0:d}")%>
                        </td>
                        <td>
                            <%# Eval("[PostDate]","{0:d}")%>
                        </td>
                        <td>
                            <%# Eval("CPTcode")%>
                        </td>
                        <td>
                            <%# Eval("Shortdescription")%>
                        </td>

                        <td>
                            <%-- <%# Eval("Charges")%>--%>
                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%--  <%# Eval("Adjustments")%>--%>
                            <asp:Label ID="lblAdjustments" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%--  <%# Eval("[Payment]")%>--%>
                            <asp:Label ID="lblPayment" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%--     <%# Eval("Balance")%>--%>
                            <asp:Label ID="lblBalance" runat="server"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>

                    <tr id="main">
                        <td style="border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-right: none; border-top: 1px solid #C4C4C4;"></td>
                        <td style="border-left: none; border-top: 1px solid #C4C4C4; font-weight: bold; text-align: right; width: 100%;">
                            <asp:Label ID="lblGranAverage" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;">
                            <asp:Label ID="lblTotalCharges" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;">
                            <asp:Label ID="lblTotalAdjustments" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;">
                            <asp:Label ID="lblTotalPayments" runat="server"></asp:Label></td>
                        <td style="border-top: 1px solid #C4C4C4;">
                            <asp:Label ID="lblTotalBalance" runat="server"></asp:Label></td>
                    </tr>
                    </tbody>
                                        </tfooter>
                                </table>
                            </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
        <asp:HiddenField runat="server" ID="hdnTimeSpan" />
        <asp:HiddenField runat="server" ID="hdnDateFrom" />
        <asp:HiddenField runat="server" ID="hdnDateTo" />
        <asp:HiddenField runat="server" ID="hdnPatId" />
        <asp:HiddenField runat="server" ID="hdnDateType" />
        <asp:HiddenField runat="server" ID="hdnProviderId" />
        <asp:HiddenField runat="server" ID="hdnAsOf" />
        <div id="divDialogReportFilters" style="display: none;"></div>


        <script type="text/javascript">
            debugger;
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                $('.SelectFilterMessage').css("display", "none")
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
        ###End###
        </div>
    </form>
</body>
</html>
