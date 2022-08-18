<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="AppointmentSummary.aspx.cs" Inherits="ProviderPortal_Reports_AppointmentSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     ###StartReport###
    <div class="Widget" style="margin-top: 10px;">
       <%-- <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Appointment Summary</span>
        </div>--%>
        <div class="WidgetContent">
            <div class="WidgetFilterBox">
                <table>
                    <tr>
                        <td style="width: 70px;">
                            Location:
                        </td>
                        <td style="width: 230px;">
                            <asp:DropDownList runat="server" ID="ddlPracticeLocations" AppendDataBoundItems="true" style="width: 200px;">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 75px;">
                            Date From:
                        </td>
                        <td style="width: 150px;">
                            <input type="text" id="txtDateFromFilter" style="width: 115px;" />
                        </td>
                        <td style="width: 65px;">
                            Date To:
                        </td>
                        <td style="width: 150px;">
                            <input type="text" id="txtDateToFilter" style="width: 115px;" />
                        </td>
                        <td>
                            <input type="button" value="Filter" onclick="Click_FilterButton();" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">
                        <div class="PageEntries">
                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                <select id="ddlPagingReport" style="margin-top: 5px;" onchange="RowsChange('FilterReportList');">
                                    <option value="10">10</option>
                                    <option value="25">25</option>
                                    <option value="50">50</option>
                                    <option value="75">75</option>
                                    <option value="100">100</option>
                                </select>
                            </span><span style="float: left;">&nbsp;entries</span>
                        </div>
                        <div class="PageButtonsReports">
                            <ul style="float: right; margin-right: 15px;">
                            </ul>
                        </div>
                        <div id="divEport">
                            <div style="float: left; font-weight: bold;">Export To </div>
                            <div class="report-export-wrapper" style="float: right; width: 58%; margin-top: 3%;">
                                <asp:DropDownList ID="ddlExportTo" runat="server" OnSelectedIndexChanged="ddlExportTo_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                    <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                    <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="report-tools">
                            <table>
                                <tr>
                                   
                                    <td>
                                        <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="PrintReport('divReportListing');">
                                            <img src="../../Images/print.png" />
                                        </a>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" class="report-tool-icon" onclick="FilterReportList(0,true);">
                                            <img src="../../Images/ReportRefresh.gif" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </div>                        
                    </div>
                </div>
                <div class="WidgetReportContent">
                    <div style="width: 100%; float: left;">
                        <div id="divReportListing">
                            <div class="ReportGrid">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'AppointmentDate');">
                                                <span class="report-column-title">Appointment Date</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Location');">
                                                <span class="report-column-title">Location</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'TotalAppointments');">
                                                <span class="report-column-title">Total Appointments</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'Completed');">
                                                <span class="report-column-title">Completed</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Pending');">
                                                <span class="report-column-title">Pending</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'No-Show');">
                                                <span class="report-column-title">No-Show</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Checked-In');">
                                                <span class="report-column-title">Checked-In</span><span></span>
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
                                                        <%# Eval("AppointmentDate")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Location")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("TotalAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CompletedAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PendingAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("NoShowAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckedInAppointments")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0"/>
    
    <script type="text/javascript">
        $(document).ready(function () {
            _SortBy = 'PatientId';
            _SortByValue = 'ASC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");

            $("#txtDateFromFilter").datepicker({
                //defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                onClose: function (selectedDate) {
                    $("#txtDateToFilter").datepicker("option", "minDate", selectedDate);
                }
            }).mask("99/99/9999");

            $("#txtDateToFilter").datepicker({
                //defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                onClose: function (selectedDate) {
                    //$("#txtDateFromFilter").datepicker("option", "maxDate", selectedDate);
                }
            }).mask("99/99/9999");
        });

        function FilterReportList(pageNumber, paging) {
            var PracticeLocationsId = $.trim($("[id$='ddlPracticeLocations']").val());
            var DateFrom = $.trim($("[id$='txtDateFromFilter']").val());
            var DateTo = $.trim($("[id$='txtDateToFilter']").val());

            if ((DateFrom != "" && DateTo == "") || (DateFrom == "" && DateTo != "")) {
                showErrorMessage("Please enter both 'Date From' and 'Date To'");
                return;
            }

            var params = {
                PracticeLocationsId: PracticeLocationsId,
                DateFrom: DateFrom,
                DateTo: DateTo,
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterAppointmentSummary.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

        function Click_FilterButton() {
            FilterReportList(0, true);
        }
        function JumpToPageNo(event) {
            debugger;
            var a = event.which || event.keyCode;
            if (a == 13) {
                location.reload();
            }
            var pageNumber = $("[id$='txtReportPageNumber']").val();
            pageNumber--;
            FilterReportList(pageNumber);
        }
    </script>
    ###EndReport###
</asp:Content>


