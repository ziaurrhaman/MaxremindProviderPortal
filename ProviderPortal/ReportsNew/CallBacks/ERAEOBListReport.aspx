<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ERAEOBListReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ERAEOBListReport" %>

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
           <asp:Repeater ID="rptERAEOBList" runat="server" OnItemDataBound="rptERAEOBList_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="GridReports" id="printableArea" >
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PaymentType');">
                                                        <span class="report-column-title">Payment Type</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                        <span class="report-column-title">Insurance</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PaymentMethodCode');">
                                                        <span class="report-column-title">Payment Method</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'CheckNumber');">
                                                        <span class="report-column-title">Check Number</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'CheckIssueDate');">
                                                        <span class="report-column-title">Payment Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PaymentAmount');">
                                                        <span class="report-column-title">Check Amount</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PaymentPosted');">
                                                        <span class="report-column-title">Payment Posted</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PaymentAmount');">
                                                        <span class="report-column-title">Un-applied Amount</span><span></span>
                                                    </th>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td >
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("PaymentType")%>
                                        </td>
                                        <td>
                                            <%# Eval("PayerName")%>
                                        </td>
                                        <td>
                                            <%# Eval("PaymentMethodCode")%>
                                        </td>
                                        <td>
                                            <%# Eval("CheckNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("CheckIssueDate")%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaymentAmount" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaymentPosted" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUnapplied" runat="server"></asp:Label>
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
     <asp:HiddenField runat="server" ID="hdnInsurance" />
    <asp:HiddenField runat="server" ID="hdnPaymentType" />
    <asp:HiddenField runat="server" ID="hdnPaymentMethod" />
    <div id="divDialogReportFilters" style="display: none;"></div>


        <script type="text/javascript">
            debugger;
            var Rows1 = "";
            function RowsChange(PageNumber,sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();

                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {
                        Insurance: $("[id$='hdnInsurance']").val(),
                        PaymentType: $("[id$='hdnPaymentType']").val(),
                        PaymentMethod: $("[id$='hdnPaymentMethod']").val(),
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
                        Rows: Rows1,
                        PageNumber: pageNumber,
                        SortBy: sortValue,
                        action: "Filter"
                }

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
