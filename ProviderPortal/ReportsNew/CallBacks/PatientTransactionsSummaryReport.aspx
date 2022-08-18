<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientTransactionsSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientTransactionsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
        <div class="Filter SearchCriteria">

            <div class="row">
                <div class="col-lg-3 SelectDateType">
                         <div class="" id="divReportFilterBy">
                             <div id="divPostType" style="padding-bottom: 45px;">
                                 <div class="divBranchName" style="">
                                     <span class="spnBranchName" style="">Date Type:</span>
                                     <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                         <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="">
                                             <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                             <asp:ListItem Value="DOS">Service Date</asp:ListItem>

                                         </asp:DropDownList>
                                     </div>
                                 </div>
                             </div>

                         </div>
                     </div>
                <div class="col-lg-3" style="padding-bottom: 5px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Dates:</span>
                        <div class="BranceInput">
                            <select class="" id="ddlSelectDate" onchange="GetDates(this)" style="">
                                <option value="">Select Date</option>
                                <option value="today">Today</option>
                                <option value="CurrentMonth" selected="selected">Month To Date</option>
                                <option value="LastMonth">Last Month</option>
                                <option value="L6M">Last 6 Months</option>
                                <option value="YTD">Year To Date </option>
                                <option value="LY">Last Year</option>
                                <option value="FB">From Beginning</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 SelectDates" style="padding-bottom: 0px; padding-top: 0px !important;">
                    <label style=""><b style="color: black">From:</b></label>
                    <span>
                        <input type="date" id="DateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                    </span>
                    <label><b style="color: black">To:</b></label>
                    <span>
                        <input type="date" style="" id="DateTo" class="Datetxtbox" placeholder="Date To" />
                    </span>
                </div>
                <div class="col-lg-3" style="margin-top: 6px !important;">
                    <div>
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientTransactionsSummary()" />
                        <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePatientTransactionsSummary()" disabled />
                    </div>
                </div>

            </div>

        </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>

            <asp:Repeater ID="rptPatientTransactionsSummary" runat="server">
                <HeaderTemplate>
                    <div class="GridReports" id="printableArea">
                        <table>
                            <thead>
                                <tr>
                                    <th>
                                        <span class="report-column-title">#</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'PatientId');">
                                        <span class="report-column-title">Patient Id</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                        <span class="report-column-title">Patient Name</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Phone');">
                                        <span class="report-column-title">Phone No.</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'charges');">
                                        <span class="report-column-title">Charges</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Adjustments');">
                                        <span class="report-column-title">Adjustments</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Receipt');">
                                        <span class="report-column-title">Receipt</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'Unapplied');">
                                        <span class="report-column-title">Unapplied</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'InsBalance');">
                                        <span class="report-column-title">Insurance Balance</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'PatBalance');">
                                        <span class="report-column-title">Patient Balance</span><span class="filterIcon asc"></span>
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
                        <td class="linkClass" onclick="PatientTransactionDetail('<%# Eval("PatientId")%>')">
                            <%# Eval("PatientName")%>
                        </td>
                        <td>
                            <%# Eval("Phone")%>
                        </td>
                        <td>
                            <%# Eval("charges")%>
                        </td>
                        <td>
                            <%# Eval("Adjustments")%>
                        </td>
                        <td>
                            <%# Eval("Receipts")%>
                        </td>

                        <td>
                            <%# Eval("Unapplied")%>
                        </td>
                        <td>
                            <%# Eval("InsBalance")%>
                        </td>
                        <td>
                            <%# Eval("PatBalance")%>
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
            <input type="hidden" id="Hidden1" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <div id="divDialogPatientTransactionDetail" style="display: none;"></div>


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
                            DateType: $("#" + SubReportDivName).find("[id$='ddlPostType']").val(),
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
