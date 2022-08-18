<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OverPaidClaimsReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_OverPaidClaims" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
            <div class="Filter SearchCriteria" style="display: none;">
                <div class="row">
                    <div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="BillDate" Selected="True">Bill Date</asp:ListItem>
                                            <asp:ListItem Value="PostDate">Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">Service Date</asp:ListItem>


                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Dates:</span>
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
                    <div class="col-lg-3 SelectDates" style="padding-bottom: 0px; padding-top: 0 !important;">
                        <label style=""><b style="color: black">From:</b></label>
                        <span>
                            <input type="date" id="DateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            <input type="date" style="" id="DateTo" class="Datetxtbox" placeholder="Date To" />
                        </span>
                    </div>
                    <div class="col-lg-3" style="margin-top: 0 !important;">
                        <div>
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterOverPaidClaimsReport()" />
                            <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeOverPaidClaimsReport()" />

                        </div>
                    </div>




                </div>
            </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <script>
                $(document).ready(function () {
                    $(".fixTable").tableHeadFixer();
                });
            </script>
            <script src="../../AdminPanel/js/tableHeadFixer.js" type="text/javascript"></script>
            <asp:Repeater ID="rptOverPaidClaimReport" runat="server">
                <HeaderTemplate>
                    <div class="Grid GridReports" id="printableArea">
                        <div class="department_table scroll" style="overflow: auto;">
                            <table class='clsborder fixTable' style="width: 100%; text-align: center !important; border-color: #afdbec;">
                                <thead style="border: 1PX SOLID WHITE; color: black">
                                    <tr style="background-color: #aadeff">
                                        <th>
                                            <span class="report-column-title">#</span><span></span>
                                        </th>

                                        <th class="asc" onclick="SortReportList(this,'ClaimId');">
                                            <span class="report-column-title">Claim Id</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'PatientId');">
                                            <span class="report-column-title">Patient Id</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'Patient');">
                                            <span class="report-column-title">Patient</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'DOS');">
                                            <span class="report-column-title">DOS</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'CPTCode');">
                                            <span class="report-column-title">CPT</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'Totalcharges');">
                                            <span class="report-column-title">Total Charges</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'PaidAmt');">
                                            <span class="report-column-title">Allowed Amt</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'Location');">
                                            <span class="report-column-title">Paid Amt</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'BalanceDue');">
                                            <span class="report-column-title">Balance Due</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'BilledAs');">
                                            <span class="report-column-title">Billed As</span><span class="filterIcon asc"></span>
                                        </th>
                                        <th class="asc" onclick="SortReportList(this,'Payer');">
                                            <span class="report-column-title">Payer</span><span class="filterIcon asc"></span>
                                        </th>
                                        <%--<th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                            <span class="report-column-title">Claim Status</span<span class="filterIcon asc"></span>
                                        </th>--%>
                                    </tr>
                                </thead>
                                <tbody id="tbodyReportList">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <%# Eval("RowNumber")%>
                        </td>

                        <td style="text-align: center">
                            <%# Eval("ClaimId")%>
                        </td>
                        <td class="align_center">
                            <%# Eval("PatientId")%>
                        </td>
                        <td>
                            <%# Eval("Patient")%>
                        </td>
                        <td class="align_center">
                            <%# Eval("[DOS]")%>
                        </td>
                        <td class="align_center">
                            <%# Eval("CPTCode")%>
                        </td>
                        <td style="text-align: right">
                            <%# Eval("Totalcharges")%>
                        </td>
                        <td style="text-align: right">
                            <%# Eval("AllowedAmount")%>
                        </td>
                        <td style="text-align: right">
                            <%# Eval("PaidAmount")%>
                        </td>
                        <td style="text-align: right">
                            <%# Eval("BalanceDue")%>
                        </td>
                        <td style="text-align: center">
                            <%# Eval("BilledAs")%>
                        </td>
                        <td>
                            <%# Eval("Payer")%>
                        </td>
                        <%--<td>
                            <%# Eval("ClaimStatus")%>
                        </td>--%>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                                </table>
                                    </div>
                            </div>
                </FooterTemplate>
            </asp:Repeater>

            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <div id="divDialogReportFilters" style="display: none;"></div>
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnClaimStatus" />
            <asp:HiddenField runat="server" ID="hdnPayers" />
            <asp:HiddenField runat="server" ID="hdnInsuranceType" />

            <script type="text/javascript">
                debugger;
                var Rows1 = "";
                function RowsChange(PageNumber, sortValue) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;
                    //EccounterSummary
                    if (_selectedReport_Filter != "") {
                        params = {
                            StartDate: $("[id$='hdnDateFrom']").val(),
                            EndDate: $("[id$='hdnDateTo']").val(),
                            DateType: $("#" + SubReportDivName).find("#ddlPostType").val(),
                            Payers: $("[id$='hdnPayers']").val(),
                            InsuranceType: $("[id$='hdnInsuranceType']").val(),
                            ClaimStatus: $("[id$='hdnClaimStatus']").val(),
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            SortBy: sortValue,
                            ProviderId: $("[id$='hdnProviderId']").val(),
                            LocationId: $("[id$='hdnLocationId']").val(),
                            action: "Filter"
                        };
                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }


                }

            </script>

            <div id="CustomizeOverPaidClaimsReport" style="display: none; padding: 20px;">
                <div class="row">
                    <div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostTypeCustomize" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                            <asp:ListItem Value="BillDate" Selected="True">Bill Date</asp:ListItem>
                                            <asp:ListItem Value="PostDate">Post Date</asp:ListItem>
                                            <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                            <%--<asp:ListItem Value="SubmissionDate">Submission Date</asp:ListItem>--%>
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
                    <div class="col-lg-6 SelectDates" style="padding-bottom: 0px; padding-top: 19px !important;">
                        <label style=""><b style="color: black">From:</b></label>
                        <span>
                            <input type="date" id="CustomizeDateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox" placeholder="Date To" />
                        </span>
                    </div>


                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divInsuranceType">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Bill As:</span>
                                <div class="clsPostDate BranceInput" id="divddlInsuranceType">
                                    <asp:DropDownList ID="ddlInsuranceType" CssClass="" runat="server" Style="">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="Primary">Primary</asp:ListItem>
                                        <asp:ListItem Value="Secondary">Secondary</asp:ListItem>
                                        <asp:ListItem Value="Patient">Patient</asp:ListItem>


                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div id="divReportClaimStatus" style="padding-bottom: 45px;" class="none-d">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName claim-status-label">Claim Status :</span>
                                <div class="BranceInput claim-status-input">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divCalimStatus',this);">
                                            <div class="selectedText">
                                                All Claims
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divCalimStatus" class="div-multi-checkboxes-wrapper divCalimStatus" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                                <ul id="ulMultiCalimStatus">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                            <input type="checkbox" id="chkCalimStatusAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                            <span>All Claims</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptCalimStatus">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkCalimStatus chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("SubmissionStatusId") %>' />
                                                                    <span><%#Eval("SubmissionStatus") %></span>
                                                                    <input type="hidden" value='<%#Eval("SubmissionStatusId") %>' id="SubmissionStatusId" />
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
                    <div class="col-lg-6">
                        <div id="divReportPayerScenario" style="padding-bottom: 45px">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Payer Scenario :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPayerScenario',this);">
                                            <div class="selectedText">
                                                All Payer Scenario
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divPayerScenario" class="div-multi-checkboxes-wrapper divPayerScenario" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect">
                                                <ul id="ulMultiPayerScenario">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                            <input type="checkbox" id="chkPayerScenarioAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                            <span>All Payer Scenario</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptPayerScenario">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label name='<%#Eval("InsuranceId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkPayerScenario chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("InsuranceId") %>' />
                                                                    <span><%#Eval("Name") %></span>
                                                                    <input type="hidden" value='<%#Eval("InsuranceId") %>' id="InsuranceId" />
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
                    <div class="col-lg-6 CustomPracticeLocation">
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
                                                                <label value='<%#Eval("PracticeLocationsId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
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
                    <div class="col-lg-6 CustomReportServiceProvider">
                        <div id="divReportServiceProvider">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Provider :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divServiceProvider',this);">
                                            <div class="selectedText">
                                                All Providers
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; position: absolute; top: 3px; right: 0;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect">
                                                <ul id="ulMultiServiceProvider">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                            <input type="checkbox" id="chkServiceProviderAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                            <span>All Providers</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptProviders">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label name='<%#Eval("PracticeStaffId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("PracticeStaffId") %>' />
                                                                    <span><%#Eval("StaffName") %></span>
                                                                    <input type="hidden" value='<%#Eval("StaffNPI") %>' class="PracticeStaffId" />
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
