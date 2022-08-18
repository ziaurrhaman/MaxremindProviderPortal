<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientBalanceSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientBalanceSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
                       <div class="Filter SearchCriteria" style="display: none; height: auto !important;">

                           <div class="row">

                               <div class="col-lg-3">
                                   <div id="divAssignedTo">
                                       <div class="divBranchName" style="">
                                           <span class="spnBranchName " style="">Assigned To:</span>
                                           <div class="clsPostDate BranceInput" id="divddlAssignedTo">
                                               <asp:DropDownList ID="ddlAssignedTo" CssClass="ddlAssignedTo" runat="server" Style="">
                                                   <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                                                   <asp:ListItem Value="Patient">Patient</asp:ListItem>
                                               </asp:DropDownList>
                                           </div>
                                       </div>

                                   </div>
                               </div>
                               <div class="col-lg-3">
                                   <div id="divDate">

                                       <div class="divBranchName" style="">
                                           <span class="spnBranchName" style="">Date:</span>
                                           <div class="clsPostDate BranceInput" id="divddlDate" onchange="GetDates(this);">
                                               <asp:DropDownList ID="ddlSelectDate" CssClass="ddlDate" runat="server" Style="">
                                                   <asp:ListItem Value="today" Selected="True">Today</asp:ListItem>
                                                   <asp:ListItem Value="yesterday">Yesterday</asp:ListItem>
                                                   <asp:ListItem Value="Custom">Custom</asp:ListItem>
                                               </asp:DropDownList>
                                           </div>
                                       </div>

                                   </div>
                               </div>
                               <div class="col-lg-3">
                                   <div id="divAgingDate">
                                       <div class="divBranchName" style="">
                                           <span class="spnBranchName" id="spnAsOf">As Of:</span>
                                           <div class="clsPostDate BranceInput">
                                               <input type="date" id="dateasof" disabled="disabled"  style="width: 100%" />

                                           </div>
                                       </div>
                                   </div>
                               </div>
                               <div class="col-lg-3" style="margin-top: 0 !important;">
                                   <div>
                                       <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientBalanceSummaryReport()" />
                                       <input class="btn primary" type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePatientBalanceSummaryReport()" disabled="disabled"/>
                                   </div>
                               </div>

                           </div>

                       </div>

            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>

            <asp:Repeater ID="rptPatientBalanceSummary" runat="server">
                <HeaderTemplate>
                    <div class="ReportGridPrint GridReports">
                        <table class="Grid">
                            <thead>
                                <tr>
                                    <th>
                                        <span class="report-column-title">SNo.</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'PatientId');">
                                        <span class="report-column-title">Patient Id</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient Name');">
                                        <span class="report-column-title">Patient Name</span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Charges');">
                                        <span class="report-column-title">Charges</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Adjustments');">
                                        <span class="report-column-title">Adjustments</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Insurance Payments');">
                                        <span class="report-column-title">Insurance Payment</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient Payments');">
                                        <span class="report-column-title">Patient Payment</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Total Balance');">
                                        <span class="report-column-title">Total Balance</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Pending Insurance');">
                                        <span class="report-column-title">Pending Insurance</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Patient Balance');">
                                        <span class="report-column-title">Patient Balance</span><span></span>
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
                            <%# Eval("PatientId")%>
                        </td>
                        <td>
                            <%# Eval("PatientName")%>
                        </td>
                        <td>
                            <%# Eval("charges")%>
                        </td>
                        <td>
                            <%# Eval("adjustments")%>
                        </td>
                        <td>
                            <%# Eval("Insurancepmt")%>
                        </td>
                        <td>
                            <%# Eval("PatientPmt")%>
                        </td>
                        <td>
                            <%# Eval("TotalBalance")%>
                        </td>
                        <td>
                            <%# Eval("PendingIns")%>
                        </td>
                        <td>
                            <%# Eval("Patientbalance")%>
                        </td>
                        <%--<td>
                                            <%# Eval("ProcedurePaymentsid")%>
                                        </td>--%>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </tbody>
                                   <%-- <tfooter>
                                        <tr style="display:none;">
                                            <td style="border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-top:1px solid #C4C4C4;font-weight:bold; float:right; width:100%;">Grand Total</td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalCharges" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalAdjustments" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalInsurancePayments" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalPatientPayments" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalBalance" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblPendingInsurance" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblPatientBalance" runat="server"></asp:Label></td>
                                        </tr>
                                    </tfooter>--%>
                                    </table>
                            </div>
                </FooterTemplate>

            </asp:Repeater>


            <asp:HiddenField ID="hdnPatientId" runat="server" />
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <div id="divDialogReportFilters" style="display: none;"></div>
            <asp:HiddenField ID="hdnAssignedTo" runat="server" />
            <asp:HiddenField ID="hdnDOB" runat="server" />
            <asp:HiddenField ID="hdnCustomDate" runat="server" />


            <script type="text/javascript">
                debugger;
                //var today = new Date();
                //var dd = today.getDate();
                //var mm = today.getMonth() + 1;
                //var yyyy = today.getFullYear();
                //if (dd < 10) {
                //    dd = '0' + dd
                //}
                //if (mm < 10) {
                //    mm = '0' + mm
                //}

                //today = yyyy + '-' + mm + '-' + dd;
                ////document.getElementById("Text6").setAttribute("max", today);
                ////document.getElementById("DOB").setAttribute("max", today);
                //$('#txtDOB').val(today);
                var Rows1 = "";
                function RowsChange(PageNumber, sortValue) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        params = {
                            AssignedTo: $("[id$='hdnAssignedTo']").val(),
                            AsOf: $("[id$='hdnDOB']").val(),
                            CustomDate: $("[id$='hdnCustomDate']").val(),
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

            <div id="CustomizePatientBalanceSummaryReport" style="display: none">
            </div>

            ###endReport###
        </div>
    </form>
</body>
</html>
