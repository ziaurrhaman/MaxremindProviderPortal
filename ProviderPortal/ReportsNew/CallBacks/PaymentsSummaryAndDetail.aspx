<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentsSummaryAndDetail.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PaymentsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
        <style>
            .InsuranceAmount, .PatientAmount {
                cursor: pointer !important;
                color: blue !important;
                text-decoration: underline;
            }
        </style>
            <script type="text/javascript">
                $("ul#ulMultiPayerScenario li:nth-child(2)").remove()
                //$("#txtReportDateFrom").datepicker({
                //    changeMonth: true,
                //    changeYear: true,
                //    yearRange: "-11 : +0",
                //    maxDate: new Date(),
                //    onSelect: function () {

                //    },
                //});

                //$("#txtReportDateTo").datepicker({
                //    changeMonth: true,
                //    changeYear: true,
                //    yearRange: "-11 : +0",
                //    maxDate: new Date(),
                //    onSelect: function () {

                //    },
                //});

                //$("#ddlPostType").val("PostDate");

                //$("[id$='txtReportDateFrom']").val(DateFrom);
                //$("[id$='txtReportDateTo']").val(DateTo);

            </script>
            <div class="Filter SearchCriteria" style="display: none; padding-bottom: 18px;">
                <div class="row">
                    <div class="col-lg-2">
                        <div id="divPostType">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Date Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableFilter(this)" style="width: 65% !important;">
                                    <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server">
                                        <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                        <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                        <asp:ListItem Value="CheckDate">Check Date</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>

                    </div>
                    <%--                    <div class="col-lg-2">
                        <div id="divPracticeStaffOnNpiNum" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Providers :</span>
                                <div class="clsPatientId BranceInput" onchange="EnableDisableFilter(this)" style="width: 65% !important;">
                                    <asp:DropDownList ID="ddlPracticeStaffOnNpiNum" CssClass="ddlPatientList" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>--%>

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
                    <div class="col-lg-3" style="margin-top: 9px !important;">

                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPaymentsSummaryAndDetails()" />
                        <input class="btn primary" type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePaymentsSummaryAndDetail()" />
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
                <table style="width: 100%">
                    <thead>
                        <tr style="border: 1px solid; background-color: #c9e6f3; line-height: 1.5;">
                            <th style="font-weight: 600; text-align: center; width: 20%">
                                <span class="report-column-title">Provider</span>
                            </th>

                            <th style="font-weight: 600; text-align: center; width: 20%">
                                <span class="report-column-title">Insurance</span>
                            </th>

                            <th style="font-weight: 600; text-align: center; width: 20%">
                                <span class="report-column-title">Patient</span>
                            </th>
                            <th style="font-weight: 600; text-align: center; width: 20%">
                                <span class="report-column-title">Total</span>
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tbodyReportList" class="tbodyReportList">
                        <asp:Repeater runat="server" ID="rptPaymentsSummary">
                            <ItemTemplate>
                                <tr style="border-bottom: 1px solid #cccccc;">
                                    <td style="text-align: center; width: 20%; border-right: 1px solid #ccc; border-left: 1px solid #ccc">
                                        <%# Eval("Provider") %>
                                    </td>
                                    <td class="InsuranceAmount" style="text-align: right; width: 20%; border-right: 1px solid #ccc; border-left: 1px solid #ccc" onclick="PSDetail('Insurance','<%# Eval("StaffNPI") %>','<%# Eval("Provider") %>')">
                                        <%# Eval("Insurance","{0:c}") %>
                                    </td>
                                    <td class="InsuranceAmount" style="text-align: right; width: 20%; border-right: 1px solid #ccc; border-left: 1px solid #ccc" onclick="PSDetail('Patient','<%# Eval("StaffNPI") %>','<%# Eval("Provider") %>')">
                                        <%# Eval("Patient","{0:c}") %>
                                    </td>
                                    <td style="text-align: right; width: 20%; border-right: 1px solid #ccc; border-left: 1px solid #ccc">
                                        <%# Eval("Total","{0:c}") %>
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
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <div id="PatClaimDetailDeiloge"></div>
            <div id="CustomizePaymentsSummaryAndDetail" style="display: none; padding: 20px;">
                <div class="row">
                    <div class="col-lg-6">
                        <div id="divPostType">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Date Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableFilter(this)" style="width: 100% !important;">
                                    <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server">
                                        <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                        <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                        <asp:ListItem Value="CheckDate">Check Date</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>

                    </div>
                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divInsuranceType">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="float: left; margin-left: 0%;">Payer Type:</span>
                                <div class="clsPostDate BranceInput" id="divddlInsuranceType">
                                    <asp:DropDownList ID="ddlPayerType" CssClass="" runat="server" Style="">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                                        <asp:ListItem Value="Patient">Patient</asp:ListItem>
                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-6" style="padding-bottom: 5px;">
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

                    <div class="col-lg-6">
                        <div id="divReportPayerScenario" style="padding-bottom: 45px">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Payers :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPayerScenario',this);">
                                            <div class="selectedText">
                                                All  
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
                                                            <span>All Payer</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptPayerScenario">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkPayerScenario chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("Name") %>' />
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
                                                                <label onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                    <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("StaffNPI") %>' />
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
                </div>
            </div>
            ###endReport###




        </div>
    </form>
</body>
</html>
