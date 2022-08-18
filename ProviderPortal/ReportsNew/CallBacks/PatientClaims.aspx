<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientClaims.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientClaims" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
###startReport###
<div class="ReportGrid">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                <span class="report-column-title">Patient Account</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                <span class="report-column-title">Patient Name</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'ClaimId');">
                                                <span class="report-column-title">Claim No</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'DOS');">
                                                <span class="report-column-title">DOS</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PrimaryInsurance');">
                                                <span class="report-column-title">Primary Insurance</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Status');">
                                                <span class="report-column-title">Submission Status</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'InsurancePayment');">
                                                <span class="report-column-title">Insurance Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Adjustment');">
                                                <span class="report-column-title">Adjustment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientPayment');">
                                                <span class="report-column-title">Patient Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'BalanceDue');">
                                                <span class="report-column-title">Balance Due</span><span></span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyReportList">
                                        <asp:Repeater ID="rptReportData" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("ClaimId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DOS")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PrimaryInsurance")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("SubmissionStatus")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("InsurancePayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Adjustment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientPayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("BalanceDue")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>

  <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
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
