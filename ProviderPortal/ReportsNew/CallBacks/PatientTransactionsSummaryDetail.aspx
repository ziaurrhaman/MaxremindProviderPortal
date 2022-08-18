<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientTransactionsSummaryDetail.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_PatientTransactionsSummaryDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###TransactionsSummaryDetail###

            <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
            <script>
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                });
            </script>

            <div class="dialogdiv">

                <div class="exportSummary">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                    <span style="float: left; padding-top: 2px; margin-left: 7px">
                        <select id="ddlPS" class="custom-export-drop-down" onchange="ExportReportForSummary('Patient Transactions Summary Detail',this,'printableAreaPS');">
                            <option></option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>
                    </span>


                    <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaPS')">
                        <img src="../../Images/PrintView1.png" alt="img" /></span>

                </div>

                <div class="Grid" style="height: 400px; overflow-y: scroll; overflow-x: scroll;">
                    <div class="GridReportsSummary" id="printableAreaPS">
                        <table class="fixTable">
                            <thead>
                                <tr>
                                    <th>
                                        <span class="report-column-title">#</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Patient Name</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Post Date</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Claim Id</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Procedure Code</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Date Of Service</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Provider</span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Service Location</span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Charges</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Adjustments</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                        <span class="report-column-title">Balance Due</span><span></span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Payment</span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList">

                                <asp:Repeater ID="rptPatientTransactionsDetail" runat="server" OnItemDataBound="rptPatientTransactionsDetail_ItemDataBound">
                                    <ItemTemplate>
                                        <tr class="cpa-trfont">
                                            <td style="text-align: center;">
                                                <%# Eval("RowNumber")%>
                                            </td>
                                            <td>
                                                <%# Eval("Patient") %>
                                            </td>
                                            <td>
                                                <%# Eval("PostDate") %>
                                            </td>
                                            <td>
                                                <%# Eval("ClaimId") %>
                                            </td>
                                            <td>
                                                <%# Eval("ProcedureCode") %>
                                            </td>
                                            <td>
                                                <%# Eval("DOS") %>
                                            </td>
                                            <td>
                                                <%# Eval("Provider") %>
                                            </td>
                                            <td>
                                                <%# Eval("Location") %>
                                            </td>
                                            <td>
                    <%# Eval("Charges","{0:0.00}") %>
                </td>
                <td>
                    <%# Eval("Adjustments","{0:0.00}") %>
                </td>
                <td>
                    <%# Eval("BalanceDue","{0:0.00}") %>
                </td>
                                            <td>
                                                <asp:Label ID="lblPayment" runat="server"></asp:Label>
                                            </td>
                                        </tr>


                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr style="text-align: center">
                                    <td colspan="10">
                                        <div class="divtotalpayment">
                                            <div style="text-align: center; margin: 10px">
                                                <span style="color: teal; font-weight: bold;">Total Payment:</span><span style="font-weight: bold;">
                                                    <asp:Label runat="server" ID="lbltotalPayment" CssClass="" /></span>
                                            </div>
                                        </div>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            ###EndTransactionsSummaryDetail###
        </div>
    </form>
</body>
</html>
