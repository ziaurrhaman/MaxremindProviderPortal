<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientBalanceReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_PatientBalanceReport" %>

<!DOCTYPE html>
<%--Added by Faiza Bilal 2-2-2022--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###

            <style>
                .Filter {
                    display: none
                }


                #notificationFooter {
                    background-color: #afafaf;
                    text-align: center;
                    font-weight: bold;
                    padding: 0px;
                    font-size: 12px;
                    width: 73%;
                    border-top: 1px solid #dddddd;
                    position: sticky;
                    bottom: 0px;
                    height: 30px;
                }
            </style>
            <script src="../js/MainReport.js"></script>
            <script src="../js/SummaryReports.js"></script>
            <script src="../../../Scripts/tableHeadFixer.js"></script>
            <div class="Filter SearchCriteria">
                <div class="" id="divReportFilterBy">

                    <div class="row">
                        <div class="col-lg-3">
                            <div id="divPostType" runat="server" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="">

                                            <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                            <asp:ListItem Value="PostDate" Selected="True">Post Date</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3" style="padding-bottom: 0px;">
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
                        <div class="col-lg-3 SelectDates" style="padding-bottom: 0px; padding-top: 0 !important;">
                            <label style=""><b style="color: black">From:</b></label>
                            <span>
                                <input type="date" id="PatientBalanceDateFrom" class="Datetxtbox" style="" placeholder="Date From" />

                            </span>
                            <label><b style="color: black">To:</b></label>
                            <span>
                                <input type="date" style="" id="PatientBalanceDateTo" class="Datetxtbox" placeholder="Date To" />
                            </span>
                        </div>
                        <div class="col-lg-3" style="margin-top: 0 !important;">
                            <div>
                                <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="GetPatBalFilter(this)" />
                                <input class='btn primary' type="button" title="Customize Filter" value="Customize Report" id="CustomieReport" onclick="CustomizePatientBalanceReport()" />



                            </div>
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

                <table class="fixTable rpt_PatientBalance">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th class="center" style="width: 12%">
                                <span class="report-column-title">Patient Account</span>
                            </th>
                            <th class="center" style="width: 7%">
                                <span class="report-column-title">Patient Last Name</span>
                            </th>
                            <th class="center" style="width: 11%">
                                <span class="report-column-title">Patient First Name</span>
                            </th>
                            <th class="center" style="width: 6%">
                                <span class="report-column-title">DOB</span>
                            </th>
                            <th class="center" style="width: 6%">
                                <span class="report-column-title">Last DOS</span>
                            </th>
                            <th class="center" style="width: 6%">
                                <span class="report-column-title">Balance</span>
                            </th>

                            <th class="center" style="width: 7%">
                                <span class="report-column-title">Count</span>
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tbodyReportList" class="tbodyPatientBalanceReport">
                        <asp:Repeater runat="server" ID="rptPatBal">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.ItemIndex +1 %></td>
                                    <td class="AlignDate">
                                        <%#Eval ("Patient Id")%>
                                    </td>
                                    <td class="AlignDate ">
                                        <%#Eval ("Patient Last Name")%>
                                    </td>
                                    <td class="AlignDate">
                                        <%#Eval ("Patient First Name")%>
                                    </td>
                                    <td class="AlignDate">
                                        <%#Eval ("DOB")%>
                                    </td>
                                    <td class="AlignDate">
                                        <%#Eval ("LastDOS")%>
                                    </td>
                                    <td class="AlignPayment">
                                        <%#Eval ("Balance", "{0:C}")%>
                                    </td>
                                    <td class="AlignDate linkClass" onclick="GetPatBalReport('<%#Eval("Patient Id") %>')">
                                        <%#Eval ("TotalCount")%>
                                    </td>

                                </tr>
                            </ItemTemplate>

                            <FooterTemplate>

                                <tfooter>
                                    <tr class="BtmToatlTr" id="notificationFooter">

                                        <td></td>
                                        <td style="border-left: none; border-top: 1px solid #C4C4C4; font-weight: bold; width: 10%">
                                            <asp:Label ID="lblGrand" runat="server" Style="font-weight: bold; color: #000 !important;">Grand Total</asp:Label></td>
                                        <td style="border-top: 1px solid #C4C4C4; width: 10%">
                                            <asp:Label ID="Label1" runat="server" Style="font-weight: bold"></asp:Label></td>
                                        <td style="border-top: 1px solid #C4C4C4; width: 10%" class="linkClass">
                                            <asp:Label ID="lbl1" runat="server" Style="font-weight: bold"></asp:Label></td>
                                        <td style="border-top: 1px solid #C4C4C4; width: 20%" class="linkClass">
                                            <asp:Label ID="lbl2" runat="server" Style="font-weight: bold"></asp:Label></td>
                                        <td style="border-top: 1px solid #C4C4C4; width: 20%" class="linkClass">
                                            <asp:Label ID="lbl3" runat="server" Style="font-weight: bold"></asp:Label></td>
                                        <td style="border-top: 1px solid #C4C4C4; width: 20%" class="linkClass">
                                            <asp:Label ID="Label2" runat="server" Style="font-weight: bold"></asp:Label></td>
                                        <td style="border-top: 1px solid #C4C4C4; border-left: none; width: 20%;" class="linkClass AlignPayment" onclick="GetPatBalReport('')">
                                            <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight: bold; color: blue !important;"></asp:Label></td>
                                    </tr>


                                </tfooter>
                                </table> 
                            </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <input type="hidden" id="hdnDateType" runat="server" value="" />
            <input type="hidden" id="hdnStartDate" runat="server" value="" />
            <input type="hidden" id="hdnEndDate" runat="server" value="" />
            <input type="hidden" id="hdnPracticeLocationId" runat="server" value="" />
            <input type="hidden" id="hdnProviderId" runat="server" value="" />

            <div id="dialoguePatientBal"></div>
            <asp:Literal runat="server" ID="ltrProvidersByLocation"></asp:Literal>
            <script type="text/javascript">
                //$(document).ready(function () {
                //    $('.Reports_Rows_Per_Page').hide();
                //    $(".fixTable").tableHeadFixer();
                //    $("#txtReportDateFrom").datepicker({
                //        changeMonth: true,
                //        changeYear: true,
                //        yearRange: "-11 : +0",
                //        maxDate: new Date(),
                //    });

                //    $("#txtReportDateTo").datepicker({
                //        changeMonth: true,
                //        changeYear: true,
                //        yearRange: "-11 : +0",
                //        maxDate: new Date(),
                //    });

                //});
                var Rows1 = "";
                function RowsChange(PageNumber, sortValue) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        params = {
                            DateFrom: $("[id$='hdnStartDate']").val(),
                            DateTo: $("[id$='hdnEndDate']").val(),
                            DateType: $("[id$='hdnDateType']").val(),
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            LocationId: $("[id$='hdnLocationId']").val(),
                            ProviderId: $("[id$='hdnProviderId']").val(),
                            action: "Filter",
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }


                }
            </script>
            <div style="display: none; padding: 20px;" id="CustomizePatientBalanceReport">

                <div class="row">
                    <div class="col-lg-3">
                        <div class="" id="divReportFilterBy">
                            <div id="div1" runat="server" style="padding-bottom: 45px;">
                                <div class="divBranchName" style="">
                                    <span class="spnBranchName" style="">Date Type:</span>
                                    <div class="clsPostDate BranceInput" id="divddlPostType" onchange="EnableDisableDates(this);">
                                        <asp:DropDownList ID="ddlPostTypeCustomize" CssClass="ddlPostType" runat="server" Style="">

                                            <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                            <asp:ListItem Value="PostDate" Selected="True">Posting Date</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-3" style="padding-bottom: 0px;">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Dates:</span>
                            <div class="BranceInput" style="">
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
                    <div class="col-lg-6 SelectDates" style="padding-bottom: 0px; padding-top: 23px !important;">
                        <label style=""><b style="color: black">From:</b></label>
                        <span>
                            <input type="date" id="CustomizeDateFrom" class="Datetxtbox CustomizeDate" style="" placeholder="Date From" />

                        </span>
                        <label><b style="color: black">To:</b></label>
                        <span>
                            <input type="date" style="" id="CustomizeDateTo" class="Datetxtbox CustomizeDate" placeholder="Date To" />
                        </span>
                    </div>

                    <div class="col-lg-4">
                        <div class="divBranchName DivBrName">
                            <span class="spnBranchName" style="">Filter By:</span>
                            <div class="clsPostDate BranceInput" id="divddlGroupBy" onchange="EnableDisableGroup('PatientBalance', this);">
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
                                    <div class="reportdropdown" style="z-index: 1000">
                                        <a onclick="ShowMenuFilters('divPracticeLocation', this);">
                                            <div class="selectedText" id="AllLocations">
                                                All Locations
                               
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-top: 0%;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper divPracticeLocation" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect PatientBalanceDynamicLocations PatientBalanceLocations">
                                                <ul id="PatientBalanceLocations">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this,'PatientBalanceLocations'),GetPracticeStaffLocation('PatientBalanceLocations')" style="float: left;">
                                                            <input type="checkbox" id="chkPatientBalanceLocationAll" class="chk-multi-checkboxes-all" />
                                                            <span>All</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>
                                                    <asp:Repeater runat="server" ID="rptLocation">
                                                        <ItemTemplate>
                                                            <li style="float: left; width: 100%;">
                                                                <label style="float: left;">
                                                                    <input type="checkbox" id="chkPatientBalanceLocation" class="chk-multi-checkboxes" onclick="ReportAlert(this,'PatientBalanceLocations'),GetPracticeStaffLocation('PatientBalanceLocations')" value='<%#Eval("PracticeLocationsId") %>' />
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
                                    <div class="reportdropdown" style="z-index: 1000">
                                        <a onclick="ShowMenuFilters('divServiceProvider', this);">
                                            <div class="selectedText" id="AllProviders">
                                                All Providers
                               
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-top: 0%;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divServiceProvider" class="div-multi-checkboxes-wrapper divServiceProvider" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                            <div class="ddlselect PatientBalanceDynamicProviders PatientBalanceProviders">
                                                <ul id="PatientBalanceDynamicProviders">
                                                    <li style="float: left; width: 100%;">
                                                        <label class="lbl-multi-checkboxes dynamicStaff" onclick="Report_ClickMultiCheckBoxAll(this);GetLocationNamePracticestaff()" style="float: left;">
                                                            <input type="checkbox" id="chkServiceProviderAll" class="chk-multi-checkboxes-all" disabled="disabled" />
                                                            <span>All Providers</span>
                                                            <input type="hidden" value="0" />
                                                        </label>
                                                    </li>

                                                    <asp:Repeater runat="server" ID="DynamicProviders">
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

                </div>

            </div>
            ###endReport###

        </div>
    </form>
</body>
</html>
<%--Added by Faiza Bilal 2-2-2022--%>