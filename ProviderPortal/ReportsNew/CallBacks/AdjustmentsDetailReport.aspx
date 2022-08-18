<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdjustmentsDetailReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_AdjustmentsDetailReport" %>

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
                                        <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server">
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
                            <span class="spnBranchName" style="">Bill Dates:</span>
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
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterAdjustmentsDetailReport()" />
                            <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeAdjustmentsDetailReport()" />

                        </div>
                    </div>
                </div>

            </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>

            <asp:Repeater ID="rptAdjustmentsDetail" runat="server">
                <HeaderTemplate>
                    <div class="GridReports">
                        <table class='clsborder Grid'>
                            <thead>
                                <tr>
                                    <th>
                                        <span class="report-column-title">#</span><span></span>
                                    </th>
                                    <%--<th class="asc" onclick="SortReportList(this,'claimid');">
                                                        <span class="report-column-title">Claim Id</span><span></span>
                                                    </th>--%>
                                    <%--    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                        <span class="report-column-title">Claim Charges Id</span><span></span>
                                                    </th>--%>
                                    <th class="asc">
                                        <span class="report-column-title">Post Date</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Service Date</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Procedure</span><span></span>
                                    </th>
                                    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                        <span class="report-column-title">Patient Name</span><span class="filterIcon asc"></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Provider</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Location</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title" style="white-space:normal !important">Reason</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Total Charges</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Adjustments</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Payer</span><span></span>
                                    </th>
                                    <%-- <th class="asc" onclick="SortReportList(this,'Adjustments');">
                                                        <span class="report-column-title">Adjusted Amount</span><span></span>
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
                        <%--  <td>
                                            <%# Eval("claimid")%>
                                        </td>--%>

                        <td>
                            <%# Eval("PostDate")%>
                        </td>
                        <td>
                            <%# Eval("servicedate")%>
                        </td>
                        <td>
                            <%# Eval("[Procedure]")%>
                        </td>
                        <td>
                            <%# Eval("PatientName")%>
                        </td>
                        <td>
                            <%# Eval("Provider")%>
                        </td>
                        <td>
                            <%# Eval("Location")%>
                        </td>
                        <td style="white-space:normal!important">
                            <%# Eval("CodeDescriptions")%>
                        </td>
                        <td>
                            <%# Eval("TotalCharges")%>
                        </td>
                        <td>
                            <%# Eval("Adjustments")%>
                        </td>
                        <td>
                            <%# Eval("Payer")%>
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
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnPatient" />
            <asp:HiddenField runat="server" ID="hdnProviderId" />
            <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
            <asp:HiddenField runat="server" ID="hdnPayerId" />
            <asp:HiddenField runat="server" ID="hdnAdjustmentCode" />
            <asp:HiddenField runat="server" ID="hdnProcedureCode" />
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
                            PatientIds: $("[id$='hdnPatient']").val(),
                            ProviderId: $("[id$='hdnProviderId']").val(),
                            PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                            PayerId: $("[id$='hdnPayerId']").val(),
                            AdjustmentCode: $("[id$='hdnAdjustmentCode']").val(),
                            ProcedureCode: $("[id$='hdnProcedureCode']").val(),
                            DateType: $("#" + SubReportDivName).find("#ddlPostType").val(),
                            BillDateFrom: $("[id$='hdnDateFrom']").val(),
                            BillDateTo: $("[id$='hdnDateTo']").val(),
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
            <div id="CustomizeAdjustmentsDetailReport" style="display: none; padding: 20px;">
                <div class="row">
                    <div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="">Select Date Type</asp:ListItem>
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
                    <div class="col-lg-6 CustomPracticeLocation" style="padding-bottom: 10px;">
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
                    <div class="col-lg-6" style="padding-bottom: 10px;">
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
                    <div class="col-lg-6 CustomReportServiceProvider" style="padding-bottom: 10px;">
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
                    <div id="divReportAdjustmentCode" class="col-lg-6" style="padding-bottom: 10px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Adjustment Code:</span>
                            <div class="BranceInput">
                                <div class="reportdropdown" style="">
                                    <a onclick="ShowMenuFilters('divAdjustmentCode',this);">
                                        <div class="selectedText">
                                            All 
                                        </div>
                                        <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divAdjustmentCode" class="div-multi-checkboxes-wrapper divAdjustmentCode" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                        <div class="ddlselect">
                                            <ul id="ulMultiAdjustmentCode">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                        <input type="checkbox" id="chkAdjustmentCodeAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                        <span>All</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptAdjustmentCode">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label name='<%#Eval("AdjustmentCode") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                <input type="checkbox" class="chkAdjustmentCode chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" style="" value='<%#Eval("AdjustmentCode") %>' />
                                                                <span><%#Eval("CodeDescription") %></span>
                                                                <input type="hidden" value='<%#Eval("AdjustmentCode") %>' class="PatientId" />
                                                            </label>


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
                    <div class="col-lg-6" style="position: relative;">
                        <div id="divPatientSarch" runat="server" style="">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Patient Name:</span>
                                <div class="clsPatientId BranceInput" style="position: relative;">
                                    <input type="text" id="TxtPatientSearch" onkeyup="searchPatient(event,this)" />
                                    <img src="../../Images/arrow_down5.PNG" style="width: 11px; margin-top: 11px; top: 27px; right: 5px; position: absolute;" onclick="searchPatient(event,this)" />
                                    <input type="hidden" id="hdnsearchpatientid" />
                                    <div id="SearchPatientList" class="PatientDetailsRptGrid" style="display: none"></div>
                                    <%--<div id="SearchPatientCustomize" style="display: none"></div>--%>
                                </div>
                            </div>
                        </div>


                        <%--<div id="divPatientSarch" runat="server">
                            <div class="divBranchName">
                                <span class="spnBranchName" style="">Patient Name:</span>
                                <div class="clsPatientId BranceInput" style="position: relative;">
                                    <input type="text" id="TxtPatientSearch" onclick="searchPatient(this)" />
                                    <img src="../../Images/arrow_down5.PNG" style="width: 11px; top: 37px; right: 5px; position: absolute;" onclick="searchPatient(this)" />
                                    <input type="hidden" id="hdnsearchpatientid" />
                                    <div id="SearchPatientList" class="rpt_adjust_patient" style="display: none"></div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                    <div class="col-lg-6" style="position: relative;">
                        <div id="divReportProcedure">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Procedure :</span>
                                <div class="clsDiagnosis BranceInput" id="divProcedure" style="position: relative;">
                                    <table>
                                        <tr>
                                            <%--<td style="width: 140px" class="leftTd">
                                        <input type="text" id="txtCPTCode" class="required" runat="server" onkeyup="searchCPTs('C', this.value, '', this, event);" onchange="PopulateCPTDesc(this, 'txtCPTDescription');" style="width: 86%;" />
                                    </td>--%>
                                            <td class="leftTd">
                                                <input type="text" id="txtCPTCode" runat="server" class="required" onkeyup="searchCPTs('C', this.value, '', this, event);" onchange="PopulateCPTCode(this, 'txtCPTDescription');" style="float: left; width: 91%;" />
                                                <span class="spnRemove" onclick="emptyCPTVal(this, 1);" style="position: absolute;">
                                                    <img src="../../Images/cancel.png" width="30" height="30" />
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="divCPTSearched" style="height: 305px; margin-top: -8px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto;">
                                        <div class="Grid" style="width: 99%; height: auto;">
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>Code</th>

                                                        <th>
                                                            <div onclick="closeCPTSearched(this)" class="spnclose">
                                                                <img alt="" src="../../Images/close_icon.png" style="border-radius: 100px; float: right; margin-right: 6px;" width="25" height="25" />
                                                            </div>
                                                            Description</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="CPTSearchedList">
                                                </tbody>
                                            </table>
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
