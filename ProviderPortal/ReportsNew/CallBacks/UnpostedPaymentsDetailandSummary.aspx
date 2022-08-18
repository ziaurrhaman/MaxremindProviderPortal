<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnpostedPaymentsDetailandSummary.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_UnpostedPaymentsDetailandSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
            <script src="../../../Scripts/tableHeadFixer.js"></script>
            <div class="Filter SearchCriteria" style="display: none; height: auto !important;">
                <div class="row">
                    <div class="col-lg-2">
                        <div id="divPostType" class="unpostedfilter">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Date Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableFilter(this)">
                                    <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server">
                                        <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                        <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                        <asp:ListItem Value="CheckDate">Check Date</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-2 p-0">
                        <div id="divPayerType2" class="unpostedfilter">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Payer Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPayerType2" onchange="EnableDisableFilter(this)">
                                    <asp:DropDownList ID="ddlpayertype" CssClass="ddlPostType" runat="server">
                                        <asp:ListItem Value="">All</asp:ListItem>
                                        <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                                        <asp:ListItem Value="Patient">Patient</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-2" style="padding-bottom: 0px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Dates:</span>
                            <div class="BranceInput" style="">
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
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterUnpostedPaymentsDetailandSummary()" / style="padding:4px 6px !important;min-width: 60px !important;">
                            <input class='btn primary' type="button" title="CustomizeReport" value="Customize Report" id="CustomizeReport" onclick="CustomizeUnpostedPaymentsDetailandSummary()" / style="padding:4px 6px !important;">


                        </div>
                    </div>
                </div>







            </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <div class="GridReports" id="printableArea">
                
                <table style="width: 100%;" class="fixtable">
                    <thead>
                        <tr>
                            <th>Payer Type</th>
                            <th>No. of Checks</th>
                            <th class="">Unposted Payment</th>
                        </tr>
                    </thead>
                    <tbody id="tbodyReportList" class="tbodyUnpostedPaymentsDetailsSummary">
                        <asp:Repeater runat="server" ID="rptUnpostedPayments">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 20%; padding-left: 10px">
                                        <span style="padding-left: 63px; color: blue; cursor: pointer; text-decoration: underline;" onclick="UnpostedPaymentDetail('<%#Eval("Payertype") %>',this)"><%#Eval("Payertype") %></span>
                                    </td>
                                    <td class="AlignDate NoofChecks">
                                        <%#Eval("NoOfChecks") %>
                                    </td>
                                    <td class="AlignDate tdunpostedpayment" style="padding-left: 45px; text-align: right !important;">$<%#Eval("UnpostedPmt","{0:0,0.00}") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <%-- Start Check Details --%>
            <div id="dialogue_UnpostedPayment" style="display: none">

                <div class="exportSummary">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                    <span style="float: left; padding-top: 2px; margin-left: 7px">
                        <select id="ddlPS" class="custom-export-drop-down" onchange="ExportReportForSummary('Payments Summary & Detail',this,'printableAreaPS');">
                            <option></option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>
                    </span>


                    <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaPS')">
                        <img src="../../Images/PrintView1.png" alt="img" /></span>

                </div>

                <div style="float: right; margin: 5px; font-size: 14px">
                    <span style="float: left">Total UnPosted Payment:
                    </span>
                    <span style="float: right; margin: 0px 10px; font-weight: 600">
                        <asp:Label runat="server" ID="totalcheckAmount"></asp:Label>

                    </span>
                </div>

                <div class="Grid" style="height: 400px; overflow-y: auto">
                    <div class="GridReportsSummary" id="printableAreaPS">
                        <table id="fixTable">
                            <thead>
                                <tr>
                                    <th class="center">#</th>
                                    <th class="center">Check Date</th>
                                    <th class="center">Check No.</th>
                                    <th class="center">Payer</th>
                                    <th class="center">Received Pmt</th>

                                    <th class="center">Posted Pmt</th>
                                    <th class="center">UnPosted Pmt</th>
                                    <th class="center">Post Date</th>

                                </tr>

                            </thead>
                            <tbody class="checkdetailTbody">
                                <asp:Repeater runat="server" ID="rptCheckDetail">
                                    <ItemTemplate>
                                        <tr class="<%# Eval("Payertype") %>" style="display: none">
                                            <td class="center"><%# Eval("Row#") %></td>
                                            <td class="AlignDate"><%# Eval("CheckIssueDate") %></td>
                                            <td><%# Eval("CheckNumber") %></td>
                                            <td class="AlignString" style="width: 24%"><%# Eval("PayerName") %></td>
                                            <td class="AlignPayment">$<%# Eval("PaymentAmount","{0:0,0.00}") %></td>

                                            <td class="AlignPayment">$<%# Eval("PaymentPosted","{0:0,0.00}") %></td>
                                            <td class="AlignPayment">$<%# Eval("Unapplied","{0:0,0.00}") %></td>
                                            <td class="AlignDate"><%# Eval("PostDate") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <%-- End Check Details --%>

            <script>
                $(document).ready(function () {
                    debugger;
                    $(".message").hide();
                    $('.Reports_Rows_Per_Page').hide();
                    $("#ddlPostType").val("PostDate");
                    /*Commented bY Faiza Bilal 3-25-2022*/
                    /* $('#rbReportTimeSpanMonthToDate').prop("checked", true)*/
                    /*End Commented bY Faiza Bilal 3-25-2022*/
                    var d = new Date();

                    var month = d.getMonth() + 1;
                    var year = d.getFullYear();
                    var lastMonth = d.getMonth();
                    var lastDay = new Date(year, month - 1, 0).getDate();
                    var day = d.getDate();
                    var DateFrom = (month < 10 ? '0' : '') + month + '/' + '01/' + year;
                    var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
                    $("#ReportDateFrom").val(DateFrom)
                    $("#ReportDateTo").val(DateTo)

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

            <div id="CustomizeUnpostedPaymentsDetailandSummary" style="display: none; padding: 20px;">


                <div class="row">
                    <div class="col-lg-4">
                        <div id="divPostTypeCustomize" class="unpostedfilter">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Date Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPostTypeCustomize" onchange="EnableDisableFilter(this)">
                                    <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server">
                                        <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                        <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                        <asp:ListItem Value="CheckDate">Check Date</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div id="divPayerType2" class="unpostedfilter">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Payer Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPayerType2" onchange="EnableDisableFilter(this)">
                                    <asp:DropDownList ID="ddlpayertypeCustomize" CssClass="ddlPostType" runat="server">
                                        <asp:ListItem Value="">All</asp:ListItem>
                                        <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                                        <asp:ListItem Value="Patient">Patient</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div id="divCheckNumberSearch" class="unpostedfilter">
                            <div class="divBranchName" style="z-index: 1000">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Check Number:</span>
                                <div class="clsPostDate BranceInput">
                                    <input type="text" id="txtsearchcheckCustomize" placeholder="Search Check Number" onkeyup="SearchCheck(event,this,'Customize')" />
                                </div>
                            </div>

                            <div class="divChecklistCustomize" style="display: none; width: 24%; position: absolute; margin-top: 0px; right: 4.5%;"></div>
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
                    <div class="col-lg-8 SelectDates" style="padding-bottom: 5px;">
                        <label style=""><b style="color: black">From:</b></label>
                        <span>
                            <input type="date" id="CustomizeDateFrom" class="Datetxtbox CustomizeDate" style="" placeholder="Date From" />

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox CustomizeDate" placeholder="Date To" />
                        </span>
                    </div>
                    <div class="col-lg-4 CustomPracticeLocation" style="padding-bottom: 10px;">
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
                                                <ul id="ulMultiPracticeLocation" onchange="GetServiceProviderDropDown();">
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
                    <div class="col-lg-4" style="padding-bottom: 10px;">
                        <div id="divReportPayerScenario">
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
                    <div class="col-lg-4 CustomReportServiceProvider" style="padding-bottom: 10px;">
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
