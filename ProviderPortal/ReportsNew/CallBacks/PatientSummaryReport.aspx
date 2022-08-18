<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientSummaryReport" %>

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
                   <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientSummaryReport()" />
                   <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePatientSummaryReport()" />

               </div>
           </div>
       </div>

   </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <div class="GridReports" id="printableArea">
                <table>
                    <thead>
                        <tr style="text-align: left">
                            <th class="asc" onclick="SortReportList(this,'Payer');">
                                <span class="report-column-title">Payer</span><span class="filterIcon asc"></span>
                            </th>
                            <th class="asc" onclick="SortReportList(this,'TotalPatient');">
                                <span class="report-column-title">TotalPatient</span><span></span>
                            </th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="rptPatientSummary" runat="server">
                        <HeaderTemplate>
                            <tbody id="tbodyReportList">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="text-align: left">
                                <td>
                                    <%# Eval("Payer")%>
                                </td>
                                <td>
                                    <%# Eval("TotalPatient")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        </FooterTemplate>
                    </asp:Repeater>
                    <tfoot>
                        <tr class="">
                            <td style="border-top: 1px solid #C4C4C4; font-weight: bold;">Total
                                <asp:Label ID="lblPracticeName" runat="server"></asp:Label></td>
                            <td style="border-top: 1px solid #C4C4C4; font-weight: bold;" id="TotalPatient">
                                <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <input type="hidden" id="hdnDateType" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnProvider" />
            <asp:HiddenField runat="server" ID="hdnLocation" />
            <asp:HiddenField runat="server" ID="hdnPayer" />
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
                            DateType: $("#" + SubReportDivName).find("#ddlPostType").val(),
                            ProviderId: $("[id$='hdnProvider']").val(),
                            PayerId: $("[id$='hdnPayer']").val(),
                            PracticeLocationId: $("[id$='hdnLocation']").val(),
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
            <div id="CustomizePatientSummaryReport" style="display: none; padding: 20px;">
                <div class="row">
                    <div class="col-lg-3 SelectDateType">
                        <div class="" id="divReportFilterBy">
                            <div id="divPostType" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
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



                </div>
            </div>

            ###endReport###

        </div>
    </form>
</body>
</html>
