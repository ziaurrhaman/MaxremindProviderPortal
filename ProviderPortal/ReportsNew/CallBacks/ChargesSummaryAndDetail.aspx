<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargesSummaryAndDetail.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_ChargesSummaryAndDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###startReport###
            <script src="../js/MainReport.js"></script>
        <script src="../js/FilterReports.js" type="text/javascript"></script>
        <script src="../js/SummaryReports.js" type="text/javascript"></script>
        <style>
            .Filter {
                display: none
            }

            .divReportName {
                color: black;
                font-weight: bold;
                line-height: 24px;
                margin-bottom: 10px;
            }

            .spnBranchName {
                float: left;
                font-weight: bold;
                width: 20%;
                padding-top: 5px;
            }

            .BranceInput {
                width: 80%;
                float: left;
            }

            .reportdropdown {
                padding: 5px 0px 4px 4px;
                width: 74.6%;
                float: right;
                position: absolute;
                background-color: #FFFFFF;
                border: 1px solid #ccc;
                -moz-border-radius: 3px;
                -webkit-border-radius: 3px;
                color: #000000;
                text-align: left;
                min-width: 175px;
                height: 20px;
                z-index: 1000;
            }

            .selectedText {
                width: 92%;
                height: 32px;
                overflow: hidden;
                top: 6px;
                position: absolute;
                white-space: nowrap;
                margin-left: 2%;
            }

            .divBranchName {
                width: 100%;
            }

            .ddlselect {
                float: left;
                max-height: 170px;
                overflow-y: auto;
                margin-bottom: -2px;
                border: 1px solid #c4c4c4;
                background: white;
                margin-top: 6px;
            }

            .SearchCriteria {
                height: 155px;
            }

            /*     .FilterButton {
                margin-top: 15px;
                float: right
            }*/
        </style>
        <script src="../js/MainReport.js"></script>
        <script src="../js/SummaryReports.js"></script>
        <%-- <div class="TimeSpan" >
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="TimeSpan"></asp:Label>
              &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                 <span style="font-weight:600">Total Claims:</span>
                <asp:Label runat="server" ID="lblTotalClaims"></asp:Label>
            </div>--%>
        <script type="text/javascript">
            $(document).ready(function () {
                $('.Reports_Rows_Per_Page').hide();
                $('.message').hide();

                //$("#divReportServiceProvider *").prop('disabled', true);
                //$("#divPracticeLocation *").prop('disabled', false);
                //$('.chkPracticeLocation').prop("checked", false)
                //$('#chkServiceProviderAll').prop("checked", false)
                //$('#chkPracticeLocationAll').prop("checked", false)
                //$("[id$='rbReportTimeSpanMonthToDate']").prop("checked", true)
                /*Commented by Faiza Bilal 3-24-2022*/
                /* $("#TimeSpan").hide();*/
                /*End Commented by Faiza Bilal 3-24-2022*/
                //var d = new Date();
                //var month = d.getMonth() + 1;
                //var year = d.getFullYear();
                //var lastMonth = d.getMonth();
                //var lastDay = new Date(year, month - 1, 0).getDate();
                //var day = d.getDate();
                //var DateFrom = (month < 10 ? '0' : '') + month + '/' + '01/' + year;
                //var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
                //$("[id$='txtReportDateFrom']").val(DateFrom);
                //$("[id$='txtReportDateTo']").val(DateTo);

            });
            $("#txtReportDateFrom").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-11 : +0",
                maxDate: new Date(),
            });

            $("#txtReportDateTo").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-11 : +0",
                maxDate: new Date(),
            });

        </script>
        <div class="Filter SearchCriteria" id="FilterChargesSummaryAndDetail">

            <div class="row">
                <div class="col-lg-3 SelectDateType">
                    <div class="" id="divReportFilterBy">
                        <div id="divPostType" runat="server" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Date Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                    <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="">
                                        <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                        <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                        <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                        <asp:ListItem Value="SubmissionDate">Submission Date</asp:ListItem>

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
                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterChargesSummaryAndDetail()" />
                        <input class='btn primary' type="button" title="Customize" value="CustomizeReport" id="CustomizeReport" onclick="CustomizeChargesSummaryAndDetail()" />


                    </div>
                </div>

            </div>
        </div>
        <div style="text-align: center" class="TimeSpan" id="TimeSpan">
            <span style="font-weight: 600">Time Span:</span>
            <asp:Label runat="server" ID="txtDateFrom"></asp:Label>
            - 
        <asp:Label runat="server" ID="txtDateTo"></asp:Label>
        </div>

        <div class="GridReports" id="printableArea">

            <table>
                <thead>
                    <tr>
                        <th class="center" style="width: 6%">
                            <span class="report-column-title">Charged CPT</span>
                        </th>
                        <th class=" center" style="width: 6%">
                            <span class="report-column-title">Paid CPT</span>
                        </th>
                        <th class="center" style="width: 7%">
                            <span class="report-column-title">Unpaid CPT</span>
                        </th>
                    </tr>
                </thead>
                <tbody id="tbodyReportList" class="ClaimSummmaryAndDetailsCharged">
                    <asp:Repeater ID="rptReportData" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="AlignDate linkClass" onclick="ChargeDetail('', '')">
                                    <%# Convert.ToString(Eval("chargedproc"))==""?"0":Eval("chargedproc")%>
                                </td>
                                <td class="AlignDate linkClass" onclick="ChargeDetail('', 'P')">
                                    <%# Convert.ToString(Eval("paidproc"))==""?"0":Eval("paidproc")%>
                                </td>
                                <td class="AlignDate linkClass" onclick="ChargeDetail('', 'U')">
                                    <%# Convert.ToString(Eval("unpaidproc"))==""?"0":Eval("unpaidproc")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
        <input type="hidden" id="hdnDateType" runat="server" value="" />
        <input type="hidden" id="hdnStartDate" runat="server" value="" />
        <input type="hidden" id="hdnEndDate" runat="server" value="" />
        <input type="hidden" id="hdnpayername" runat="server" value="" />
        <div class="dialogueChargesSummary" style="display: none"></div>


        <div id="CustomizeChargesSummaryAndDetail" style="display: none; padding: 20px;"
            class="CustomizeFilter">

            <div id="divReportFilterBy">
                <div class="row">
                    <div class="col-lg-4">
                        <div id="div1" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Date Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                    <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
                                        <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                        <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                        <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                        <asp:ListItem Value="SubmissionDate">Submission Date</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div id="div1" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">BillAs:</span>
                                <div class="clsPostDate BranceInput" id="divddlBillAs">
                                    <asp:DropDownList ID="BillAs" CssClass="ddlPostType" runat="server" Style="">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="Primary">Primary</asp:ListItem>
                                        <asp:ListItem Value="Secondary">Secondary</asp:ListItem>
                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                        <asp:ListItem Value="Patient">Patient</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Dates:</span>
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
                    <div class="col-lg-4" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">From:</span>

                            <input type="date" id="CustomizeDateFrom" class="Datetxtbox CustomizeDate" style="width: 100%" placeholder="Date From" />

                        </div>
                    </div>
                    <div class="col-lg-4" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">To:</span>
                            <input type="date" style="width: 100%" id="CustomizeDateTo" class="Datetxtbox CustomizeDate" placeholder="Date To" />
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="divBranchName DivBrName">
                            <span class="spnBranchName" style="">Filter By:</span>
                            <div class="clsPostDate BranceInput" id="divddlGroupBy" onchange="EnableDisableGroup('ChargedSummary', this);">
                                <asp:DropDownList ID="ddlGroupBy" CssClass="ddlGroupBy" runat="server" Style="">

                                    <asp:ListItem Value="Location">Location</asp:ListItem>
                                    <asp:ListItem Value="Provider">Provider</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div id="divPracticeLocationId" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Location:</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPracticeLocation', this);">
                                            <div class="selectedText" id="AllLocations">
                                                All Locations
                               
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-top: 0%;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect ChargedSummaryDynamicLocations ChargedSummaryLocations">
                                                <ul id="ChargedSummaryLocations">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" style="float: left;">
                                                            <input type="checkbox" id="chkChargedSummaryLocationsAll" class="chk-multi-checkboxes-all" onclick="Report_ClickMultiCheckBoxAll(this,'ChargedSummaryLocations'),GetPracticeStaffLocation('ChargedSummaryLocations')" />
                                                            <span>All</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptClaimSummaryLocation">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label style="float: left;">
                                                                    <input type="checkbox" class="chk-multi-checkboxes  ChargedSummaryProviders" id="chkChargedSummaryLocations" onclick="ReportAlert(this,'ChargedSummaryLocations'),GetPracticeStaffLocation('ChargedSummaryLocations')" value='<%#Eval("PracticeLocationsId") %>' />
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
                    <div class="col-lg-4">
                        <div id="divReportServiceProvider" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Provider :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divServiceProvider', this);">
                                            <div class="selectedText" id="AllProviders">
                                                All Providers
                               
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-top: 0%;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect ChargedSummaryDynamicProviders ChargedSummaryProviders">


                                                <ul id="ClaimSummaryDynamicProvider">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes dynamicStaff" onclick="Report_ClickMultiCheckBoxAll(this);GetLocationNamePracticestaff()" style="float: left;">
                                                            <input type="checkbox" id="chkARAgingDynamicProvidersAll" class="chk-multi-checkboxes-all" disabled="disabled" />
                                                            <span>All Providers</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptProviders">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label style="float: left;">
                                                                    <input type="checkbox" value='<%#Eval("StaffNPI") %>' class="StaffNPI chk-multi-checkboxes" disabled="disabled" />
                                                                    <span><%#Eval("StaffName") %></span>
                                                                    <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="PracticeStaffId" />

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
                    <div class="col-lg-4">
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
                    <div class="col-lg-4">
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
                    <div class="col-lg-4">
                        <div id="divCPT" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">CPT:</span>
                                <div class="clsDiagnosis BranceInput" style="position: relative;">

                                    <input type="text" id="txtServiceCode" placeholder="Search CPT" class="required" runat="server" onkeyup="ServiceCode(event, this)" />

                                    <div class="divselectedServiceCode">

                                        <div id="divCPTSearched" style="width: 100%; max-height: 250px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto; margin-top: 0%; margin-bottom: 10px;">
                                            <div class="Grid" style="width: 99%; height: auto;">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th>Code</th>
                                                            <th>Description</th>
                                                            <th><span onclick="closecptdiv(this)">
                                                                <img src="../../Images/close_icon.png" width="25" height="25" /></span></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="CPTSearchedList"></tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="divBranchName ClaimStatus SelfPayHide" id="ClaimIds">
                            <label class="spnBranchName" style="">Claim Ids :</label>
                            <div class="BranceInput">
                                <input type="text" id="ClaimIdMultipleTxt" placeholder="Enter Claim Id" onkeypress="return ValidateNumber(event)" onkeyup="SetSerachMultipleClaims(event)" maxlength="10" />

                                <div class="MultipleClaimGridHere">
                                    <div id="divAllClaimsDropDownReport" style="display: none; position: absolute; max-height: 250px; overflow-y: auto; background: #fff; border: 1px solid lightgray; z-index: 1;">
                                        <div class="Grid">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>Claim ID
                                                        </th>
                                                        <th>Patient
                                                        </th>

                                                        <th>DOS
                                                        </th>
                                                        <th>Status
                                                            <span style="float: right; margin-right: 17px; margin-top: -6px; cursor: pointer;"
                                                                onclick="MultipleClaimGridHereClose(this)">
                                                                <img id="closediv" src="../../../Images/close_icon.png" style="height: 15px; width: 15px; position: absolute" />

                                                            </span>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="tbodyMultipleClaims"></tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="ClaimIdsHere"></div>
                            </div>

                        </div>
                    </div>


                </div>
            </div>
        </div>

        ###endReport###


    
    </form>
</body>
</html>
