<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnpaidInsuranceClaimsReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_UnpaidInsuranceClaimsReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script src="../js/MainReport.js"></script>
        <script src="../js/SummaryReports.js"></script>
        <script src="../js/FilterReports.js"></script>
        <script src="../js/CustomizeFiltersModal.js"></script>
        <div>
            ###startReport###  
             <div class="Filter SearchCriteria" style="display: none; height: auto !important;">

                 <div class="row">

<%--                     <div class="col-lg-2 SelectDateType">
                     <div class="" id="divReportFilterBy">
                         <div id="divPostType" style="padding-bottom: 45px;">
                             <div class="divBranchName" style="">
                                 <span class="spnBranchName" style="">Date Type:</span>
                                 <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                     <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="">
                                         <asp:ListItem Value="BillDate" Selected="True">Bill Date</asp:ListItem>
                                         <asp:ListItem Value="PostDate" >Post Date</asp:ListItem>
                                         <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                         

                                     </asp:DropDownList>
                                 </div>
                             </div>
                         </div>

                     </div>
                 </div>--%>
                     <div class="col-lg-3">
                         <div class="divBranchName" style="">
                             <span class="spnBranchName" style="">Date:</span>
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
                     <div class="col-lg-5 SelectDates2" style="padding-top: 0px">
                         <table>
                             <tr>
                                 <td>
                                     <label><b style="color: black">Bill Date:</b></label></td>
                                 <td>
                                     <label style=""><b style="color: black">From:</b></label></td>
                                 <td>
                                     <input type="date" id="DateFrom" class="Datetxtbox" style="" placeholder="Date From" /></td>
                                 <td>
                                     <label><b style="color: black">To:</b></label></td>
                                 <td>
                                     <input type="date" style="" id="DateTo" class="Datetxtbox" placeholder="Date To" /></td>
                             </tr>
                         </table>
                     </div>
                     <div class="col-lg-3">
                         <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterUnPaidInsurance(this)" />

                         <input class='btn primary' type="button" title="Customize" value="Customize" id="CustomizeReports" onclick="CustomizeUnPaidInsurance(this)" />
                     </div>
                 </div>

             </div>
            <div class="TimeSpan">
                <span style="font-weight: 600">Time Span:</span>
                <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            </div>
            <asp:Repeater ID="rptUnpaidInsuranceClaims" runat="server" OnItemDataBound="rptUnpaidInsuranceClaims_ItemDataBound">
                <HeaderTemplate>
                    <div class="GridReports rpt_Unpaid_Insurance" id="printableArea">
                        <table>
                            <thead>
                                <tr>
                                      <%--Edited By Faiza Bilal 6-14-2022 to change layout of grid--%>
                                   <%-- <th>
                                        <span class="report-column-title">#</span><span></span>
                                    </th>--%>
                                      <%--End Edited By Faiza Bilal 6-14-2022 to change layout of grid--%>
                                    <th class="asc">
                                        <span class="report-column-title">Patient</span><span class="asc"></span>
                                    </th>
                                    <th>
                                        <span class="report-column-title">Insurance</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Encounter</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Billing Date</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Service Date</span><span></span>
                                    </th>
                                    <th class="asc" style="white-space:normal !important;">
                                        <span class="report-column-title">Procedures</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Diag1</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Diag2</span><span></span>
                                    </th>
                                    <th class="asc">
                                        <span class="report-column-title">Charges</span><span></span>
                                    </th>

                                </tr>
                            </thead>
                            <tbody id="tbodyReportList" class="UnPaidInsuranceClaims">
                </HeaderTemplate>
                <ItemTemplate>
  <%--Edited By Faiza Bilal 6-14-2022 to change layout of grid--%>
            <tr id="trMain" runat="server">
               
                <td id="trpatient" runat="server" style="border: none;background-color:white">
                             <asp:Label ID="LblPatient" runat="server"></asp:Label>
                </td>
                <%-- //End Edited By Faiza Bilal 6-14-2022 to change layout of grid--%>
                        <td>
                            <%# Eval("Insurance")%>
                        </td>
                        <td>
                            <%# Eval("Encounter")%>
                        </td>
                        <td>
                            <%# Eval("BillDate")%>
                        </td>
                        <td>
                            <%# Eval("ServiceDate")%>
                        </td>
                        <td style="white-space:normal !important;">
                            <%--<%# Eval("[Procedures]")%>--%>
                            <asp:Label ID="lblProcedures" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%# Eval("Diag1")%>
                        </td>
                        <td>
                            <%# Eval("Diag2")%>
                        </td>
                        <td>
                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
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
            <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
            <asp:HiddenField runat="server" ID="hdnProviderId" />
            <asp:HiddenField runat="server" ID="hdnPayerId" />
            <asp:HiddenField runat="server" ID="hdnBalance" />
            <asp:HiddenField runat="server" ID="hdnDateOfService" />
            <asp:HiddenField runat="server" ID="hdnBillDateFrom" />
            <asp:HiddenField runat="server" ID="hdnBillDateTo" />


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
                            PayerId: $("[id$='hdnPayerId']").val(),
                            ProviderId: $("[id$='hdnProviderId']").val(),
                            PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                            Balance: $("[id$='hdnBalance']").val(),
                            DateOfService: $("[id$='hdnDateOfService']").val(),
                            BillDateFrom: $("[id$='hdnBillDateFrom']").val(),
                            BillDateTo: $("[id$='hdnBillDateTo']").val(),
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
            <div style="display: none; padding: 20px;" id="CustomizeUnpaidInsuranceFilter">
                <div class="row">
                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divAgingBy" style="padding-bottom: 0px !important; width: 100% !important; float: left !important;">

                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Date Of Service Age:</span>
                                <div class="clsPostDate BranceInput" id="DivddlAgingBy">
                                    <select name="ddlDateOfService" id="ddlDateOfService" class="ddlDateOfService" style="margin-top: -6px; box-shadow: none; border-color: lightgray">
                                        <option value="">All</option>
                                        <option value="0-30">0-30</option>
                                        <option value="31-60">31-60</option>
                                        <option value="61-90">60-90</option>
                                        <option value="90+">90+</option>

                                    </select>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6" style="padding-bottom: 5px;">
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
                     <div class="col-lg-6" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">From:</span>
                            <div class="BranceInput">
                                <input type="date" id="CustomizeDateFrom" style="height: 29px; width: 100%" onchange="EnableDisableFilter(this)" />
                            </div>
                        </div>
                    </div>
                     <div class="col-lg-6" style="padding-bottom: 5px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">To:</span>
                            <div class="BranceInput">
                                <input type="date" id="CustomizeDateTo" style="height: 29px; width: 100%" onchange="EnableDisableFilter(this)" />
                            </div>
                        </div>
                    </div>
                
                    <div class="col-lg-6" id="divUnpaidinsurances" runat="server" style="padding-bottom: 10px;">
                        <div class="divBranchName">
                            <span class="spnBranchName" style="margin-top: 5px;">Unpaid Insurances :</span>
                            <div class="BranceInput">
                                <div class="reportdropdown" style="margin-top: 7px;">
                                    <a onclick="ShowMenuFilters('divReportUnpaidinsurances', this)">
                                        <div class="selectedText" id="AllUnpaidInsurance">
                                            All Unpaid Insurances
                                        </div>
                                        <div class="dropDownIcon" style="width: 7.5%; float: right; margin-right: -4%;">
                                            <%--<img src="../../Images/dropdown.gif" style="width:40%;"/>--%>
                                            <img src="../../Images/arrow_down5.PNG" style="width: 22%; margin-top: 7px; margin-left: 10px;" />
                                        </div>
                                    </a>
                                    <div id="divReportUnpaidinsurances" class="div-multi-checkboxes-wrapper divReportUnpaidinsurances" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                        <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                            <ul id="ulMultiUnpaidinsurances">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this, 'ulMultiUnpaidinsurances');" style="float: left;">
                                                        <input type="checkbox" id="chkUnpaidinsurancesAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                        <span>All Unpaid Insurances</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptunpaidinsurances">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label name='<%#Eval("InsuranceId") %>' onclick="Report_ClickMultiCheckBox(this, 'ulMultiUnpaidinsurances');" style="float: left;">
                                                                <input type="checkbox" class="chkunpaidinsurance chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this, 'ulMultiUnpaidinsurances')" value='<%#Eval("InsuranceId") %>' />
                                                                <span><%#Eval("insurance") %></span>
                                                                <input type="hidden" value='<%#Eval("InsuranceId") %>' id="" />
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
                    <div class="col-lg-6" id="divPracticeLocationId" style="padding-bottom: 10px;">
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
                                        <div class="ddlselect ClaimSummaryDynamicLocations ClaimSummaryLocations">
                                            <ul id="ClaimSummaryLocations">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" style="float: left;">
                                                        <input type="checkbox" id="chkClaimSummaryLocationsAll" class="chk-multi-checkboxes-all" checked="checked" onclick="Report_ClickMultiCheckBoxAll(this,'ClaimSummaryLocations')" />
                                                        <span>All</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptClaimSummaryLocation">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label style="float: left;" onclick="Report_ClickMultiCheckBox(this);">
                                                                <input type="checkbox" class="chk-multi-checkboxes ClaimSummaryLocations" checked="checked" id="chkClaimSummaryLocations" onclick="ReportAlert(this,'ClaimSummaryLocations')" value='<%#Eval("PracticeLocationsId") %>' />
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
                    <div class="col-lg-6">
                        <div id="divReportServiceProvider" runat="server" style="padding-bottom: 45px;">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Provider :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divServiceProvider', this);">
                                            <div class="selectedText" id="AllProviders">
                                                All Providers
                               
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; position: absolute; right: 0; top: 4px;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect ProviderCollectionDynamicProviders ProviderCollectionProviders">
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
