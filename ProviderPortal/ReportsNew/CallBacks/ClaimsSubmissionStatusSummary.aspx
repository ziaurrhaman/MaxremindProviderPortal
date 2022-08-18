<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimsSubmissionStatusSummary.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_ClaimsSubmissionStatusSummary" %>

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

            <div class="AppointmentSummaryfilter">
                <div class="row">
                       <div class="col-lg-2">
                        <div id="divPostType" class="unpostedfilter">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Date Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableFilter(this)">
                                    <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server">
                                        
                                        <asp:ListItem Value="PostDate" >Post Date</asp:ListItem>
                                        <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <%--<div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                            <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>--%>
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
                    <div class="col-lg-3">
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterClaimsSubmissionReport()" />
                        <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeClaimsSubmissionReport()" />



                    </div>



                </div>

                <div class="TimeSpan" style="margin-top:17px">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>



            </div>
        </div>
            <div class="GridReports" id="printableArea">
                <table>
                    <thead>
                        <tr>
                            <th>
                                <span class="report-column-title">#</span><span class=" asc"></span>
                            </th>
                            <th class="asc" onclick="SortReportList(this,'Location');">
                                <span class="report-column-title">Location</span><span class="filterIcon asc"></span>
                            </th>
                            <th class="asc" onclick="SortReportList(this,'InsuranceName');">
                                <span class="report-column-title">Insurance Name</span><span class="filterIcon asc"></span>
                            </th>

                            <th class="asc" onclick="SortReportList(this,'Billed');">
                                <span class="report-column-title">Billed</span>
                            </th>
                            <th class="asc" onclick="SortReportList(this,'ReadyForSubmission');">
                                <span class="report-column-title">Ready for Submission</span>
                            </th>
                            <th class="asc" onclick="SortReportList(this,'PaidUp');">
                                <span class="report-column-title">Paid Up</span><span></span>
                            </th>
                            <th class="asc" onclick="SortReportList(this,'Denied');">
                                <span class="report-column-title">Denied</span><span></span>
                            </th>
                            <th class="asc" onclick="SortReportList(this,'PendingForSubmission');">
                                <span class="report-column-title">Pending for Submission</span>
                            </th>
                            <th class="asc" onclick="SortReportList(this,'InProcess');">
                                <span class="report-column-title">In Process</span>
                            </th>
                            <th>
                                <span class="report-column-title">PTL</span><span></span>
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
                                        <%# Eval("Location")%>
                                    </td>
                                    <td>
                                        <%# Eval("InsuranceName")%>
                                    </td>

                                    <td>
                                        <%# Eval("Billed")%>
                                    </td>
                                    <td>
                                        <%# Eval("ReadyForSubmission")%>
                                    </td>
                                    <td>
                                        <%# Eval("PaidUp")%>
                                    </td>
                                    <td>
                                        <%# Eval("Denied")%>
                                    </td>
                                    <td>
                                        <%# Eval("PendingForSumbmission")%>
                                    </td>
                                    <td>
                                        <%# Eval("Inprocess")%>
                                    </td>
                                    <td>
                                        <%# Eval("PTL")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <input type="hidden" id="hdnTotalRows" runat="server" />
            <input type="hidden" id="hdnLocations" runat="server" value=""/>
            <input type="text" runat="server" id="hdnDateFrom" style="display: none" />
            <input type="text" runat="server" id="hdnDateTo" style="display: none" />
            <input type="text" runat="server" id="hdnDateType" style="display: none" />
            <script type="text/javascript">
                var Rows1 = "";
                function RowsChange(PageNumber, sortValue) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();
                    //var Location = $("[id$='ddlPracticeLocations']").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        params = {
                            Location: $("[id$='hdnLocations']").val(),
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            DateFrom: $("[id$='hdnDateFrom']").val(),
                            DateTo: $("[id$='hdnDateTo']").val(),
                            DateType: $("#" + SubReportDivName).find("[id$='ddlPostType']").val(),
                            SortBy: sortValue,
                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }
                }
                $("#filterbtn").click(function () {
                    RowsChange(0);
                });
            </script>

            <div id="CustomizeClaimsSubmissionStatusSummary" style="display: none; padding: 20px;">
                <div class="row">
                    <div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="PostDate">Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-3" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Bill Dates:</span>
                            <div class="BranceInput">
                                <select class="" id="ddlSelectDateCustomize" onchange="GetDatesCustomize(this)" style="">
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
                    <div class="col-lg-6 SelectDates" style="padding-bottom: 0px; padding-top: 20px !important;">
                        <label style=""><b style="color: black">From:</b></label>
                        <span>
                            <input type="date" id="CustomizeDateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox" placeholder="Date To" />
                        </span>
                    </div>
                    <div class="col-lg-3 CustomPracticeLocation">
                        <div id="divPracticeLocationId">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Location:</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPracticeLocation',this);">
                                            <div class="selectedText">
                                                All Locations
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; position: absolute; top: 3px; right: 0;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect">
                                                <ul id="ulMultiPracticeLocation">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                            <input type="checkbox" id="chkPracticeLocationAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                            <span>All</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptLocation">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label name='<%#Eval("PracticeLocationsId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("PracticeLocationsId") %>' />
                                                                    <span><%#Eval("Name") %></span>
                                                                    <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' class="PracticeLocationsId" />
                                                                </label>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    </div>
                </div>


            ###endReport###
        </div>
    </form>
</body>
</html>
