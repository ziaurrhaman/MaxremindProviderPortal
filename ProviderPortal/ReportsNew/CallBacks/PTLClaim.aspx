<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PTLClaim.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_PTLClaim" %>

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
                                                     <asp:ListItem Value="">Select Date Type</asp:ListItem>
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
                    <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPTLClaimReport()" />
                    <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePTLClaimReport()" />

                </div>
            </div>
        </div>
    </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <div class="ReportGridPrint GridReports">

                <table class="fixTable width_100 b_bottom">
                    <thead>
                        <tr>
                            <th style="width: 2%;">#</th>
                            <th>Patient ID</th>
                            <th>Patient Name</th>
                            <th>Claim ID </th>
                            <th>DOS</th>
                            <th>Location</th>
                            <th>Payer</th>
                            <th style="white-space:normal !important;">PTL Reason</th>
<%--                            <th>QA Approved</th>
                            <th>Audit Approved</th>
                            <th>CRM</th>--%>
                            <th>Comm Count</th>
                            <th>Last Com Date</th>
                            <th style="display: none" class="ReportShow">DOB
                            </th>
                            <th style="display: none" class="ReportShow">SSN
                            </th>
                            <th style="display: none" class="ReportShow">ClaimPriIns
                            </th>
                            <th style="display: none" class="ReportShow">DemoPriIns
                            </th>
                            <th style="display: none" class="ReportShow">ClaimPriInsId
                            </th>
                            <th style="display: none" class="ReportShow">DemoPriInsId
                            </th>
                            <th style="display: none" class="ReportShow">Claim Status
                            </th>
                            <th style="display: none" class="ReportShow">Claim Physician
                            </th>
                            <th style="display: none" class="ReportShow">PostDate
                            </th>
                            <th style="display: none" class="ReportShow">BillDate
                            </th>
                            <th style="display: none" class="ReportShow">CPTCode
                            </th>
                            <th style="display: none" class="ReportShow">DxCodes
                            </th>
                        </tr>

                    </thead>
                    <tbody id="tbodyReportList">
                        <asp:Repeater ID="rptPTLAll" runat="server">
                            <ItemTemplate>
                                <tr style="cursor: pointer;">
                                    <td class="text-right">
                                        <%# Eval("ROWNUMBER") %>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("PatientId") %>
                                    </td>
                                    <td>
                                        <%# Eval("PatientName") %>
                                    </td>

                                    <td>
                                        <%# Eval("ClaimId") %>
                                    </td>
                                    <td>
                                        <%# Eval("ServiceDate", "{0:d}") %>
                                    </td>
                                    <td>
                                        <%# Eval("Location") %>
                                    </td>
                                    <td>
                                        <%# Eval("Name") %>
                                    </td>
                                    <td style="white-space:normal !important;">
                                        <%# Eval("CLMPTLReasons")%> , <%# Eval("PAtptlReasons")%>
                                    </td>
<%--                                    <td style="display: none" class="ReportShow">
                                        <asp:Label runat="server" ID="QA"></asp:Label>
                                    </td>
                                    <td style="display: none" class="ReportShow">
                                        <asp:Label runat="server" ID="Audit"></asp:Label>
                                    </td>
                                    <td style="display: none; text-align: center;" class="ReportShow">
                                        <asp:Label runat="server" ID="CRM"></asp:Label>
                                    </td>
                                    <td class="tdQAApproved ReportHide iconAlign" style="text-align: center">

                                        <asp:Label runat="server" ID="lblQA"></asp:Label>
                                    </td>
                                    <td class="tdAuditApproved ReportHide iconAlign" style="text-align: center">
                                        <asp:Label runat="server" ID="lblAudit"></asp:Label>

                                    </td>
                                    <td class="tdcrmApproved ReportHide iconAlign" style="text-align: center">
                                        <asp:Label runat="server" ID="lblCRM"></asp:Label>


                                    </td>--%>
                                    <td style="text-align: center">
                                        <%# Eval("CommCount")%>
                                    </td>
                                    <td>
                                        <%# Eval("CommunicationDate")%>
                                    </td>
                                    <td style="display: none" class="ReportShow"><%# Eval("DOB") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("SSN") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("ClaimPriIns") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("DemoPriIns") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("ClaimPriInsId") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("DemoPriInsId") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("ClaimStatus") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("AttendingPhysician") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("PostDate") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("BillDate") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("CPTCode") %></td>
                                    <td style="display: none" class="ReportShow"><%# Eval("DxCodes") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>

                </table>
                <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
                <asp:HiddenField runat="server" ID="hdnDateFrom" />
                <asp:HiddenField runat="server" ID="hdnDateTo" />
                <asp:HiddenField runat="server" ID="hdnDateType" />
                 <asp:HiddenField runat="server" ID="hdnLocations"  Value=""/>
                <asp:HiddenField runat="server" ID="hdnPayers"  Value=""/>
            </div>



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
                            DateType: $("[id$='hdnDateType']").val(),
                            Rows: Rows1,
                            PayerId: $("[id$='hdnPayers']").val(),
                            Location: $("[id$='hdnLocations']").val(),
                            PageNumber: pageNumber,
                            SortBy: sortValue,
                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }


                }

            </script>

        </div>

        <div id="CustomizePtlClaimReport" style="display: none; padding: 20px;">
            <div class="row">
                <div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostTypeCustomize" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">
                                            <asp:ListItem Value="">Select Date Type</asp:ListItem>
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

                <div class="col-lg-6">
                    <div id="divReportPayerScenario" style="padding-bottom: 45px">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Payer Scenario :</span>
                            <div class="BranceInput">
                                <div class="reportdropdown" style="">
                                    <a onclick="hideShowMenu('divPayerScenario');">
                                        <div class="selectedText">
                                            All Payer Scenario
                                        </div>
                                        <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divPayerScenario" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
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
                <div class="col-lg-6 CustomPracticeLocation" style="padding-bottom: 10px;">
                    <div id="divPracticeLocationId">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Location:</span>
                            <div class="BranceInput">
                                <div class="reportdropdown" style="">
                                    <a onclick="hideShowMenu('divPracticeLocation');">
                                        <div class="selectedText">
                                            All Locations
                                        </div>
                                        <div class="dropDownIcon" style="width: 8.5%; position: absolute; top: 3px; right: 0;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                        <div class="ddlselect">
                                            <ul id="ulMultiPracticeLocation" onchange="GetServiceProviderDropDown();">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                        <input type="checkbox" id="chkPracticeLocationAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                        <span>All</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptLocationPtlClaim">
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
    </form>
</body>
</html>

