<%@ Page Title="Reports" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true"
    CodeFile="Report.aspx.cs" Inherits="EMR_Reports_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" />

    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .report-icon-text {
            display: none;
        }

        li {
            cursor: pointer;
            /*padding: 3px 0 0 0;*/
        }

        #accordion li:hover {
            border: solid 1px #DFDCCD;
            display: inline;
        }

        .ui-dialog-buttonpane {
            width: 98% !important;
        }

        .ui-dialog .ui-dialog-titlebar {
            background-color: white !important;
            color: black !important;
            border-bottom: 1px solid #439abf !important;
        }

        .WidgetTitle {
            border-bottom: 1px solid #006291;
            height: 9px;
        }

        .report-tools {
            float: right;
            margin-top: -3.5%;
            margin-left: 41%;
        }

        #divEport {
            width: 14%;
            margin-left: 40%;
        }

        .ReportGrid tr {
            border-left: none !important;
        }

        .ReportGrid th {
            border-left: none !important;
        }

        .ReportGrid td {
            border-left: none !important;
        }

        #tbodyReportList tr:nth-child(odd) {
            background: #EEEEEE;
        }

        #tbodyReportList tr:nth-child(even) {
            background: #FFF !important;
        }

        .ReportGrid table tbody tr {
            background-color: none !important;
        }

        thead tr {
            height: 35px;
        }

        @media (max-width: 900px) {
            .div-reports-content {
                width: 25% !important;
            }
        }


        .div-reports-content {
            width: 20% !important;
            margin-bottom: 10px;
        }

        .selectedText {
            width: 94%;
            /* margin-left: -13%; */
            height: 32px;
            overflow: hidden;
            top: 6px;
            position: absolute;
            white-space: nowrap;
        }

        #txtReportDateFrom, #txtReportDateTo {
            width: 100%;
        }

        .dropDownMenu {
            height: 20px;
            margin-top: -3% !important;
        }

        .WidgetContentReports {
            border-top: 1px solid #eeefef;
            float: left;
        }

        .side-menu-reports {
            padding: 0;
            width: 255px;
        }

        .reports_li {
            background-color: #439abf;
            padding: 10px;
            box-sizing: border-box;
            border-radius: 4px;
            margin-bottom: 10px;
        }

        .reports_li_a {
            font-size: 14px;
            color: #fffefe;
            font-weight: 700;
        }

        .TwentyFive {
            width: 25% !important;
        }

        .divScrollingMenu220 {
            width: 220px !important;
        }

        .GridReports {
            float: left;
            width: 100%;
        }

            .GridReports td {
                padding: 0px,7px;
                border: none;
            }

            .GridReports > table > tbody > tr:nth-child(even) {
                background: #EEEEEE;
            }

            .GridReports > table > thead {
                border-top: 1px solid #EEEEEE;
                border-bottom: 1px solid #EEEEEE;
            }

            .GridReports > table > tbody > tr {
                height: 25px;
            }

        .pagerReport {
            color: Gray;
            position: relative;
            height: 35px;
            line-height: 33px;
            background: -webkit-linear-gradient(top, #DFDCCD 0%,#d1cec2 100%);
        }

        h3 i {
            float: right;
        }

        i {
            border: solid gray;
            border-width: 0 1px 1px 0;
            display: inline-block;
            padding: 3px;
        }

        .right {
            transform: rotate(-45deg);
            -webkit-transform: rotate(-45deg);
        }

        .left {
            transform: rotate(135deg);
            -webkit-transform: rotate(135deg);
        }

        .up {
            transform: rotate(-135deg);
            -webkit-transform: rotate(-135deg);
        }

        .down {
            transform: rotate(45deg);
            -webkit-transform: rotate(45deg);
        }

        .report-page-title {
            margin: -3px 2px 0 7px !important;
        }

        .report-page-number {
            margin: -3px 0 0 2px !important;
        }

        .PageButtonsReports {
            padding-top: 4px !important;
        }

        #divEport {
            color: gray !important;
        }

            #divEport span {
                color: gray !important;
            }

        .report-tools {
            margin-top: -3.9% !important;
        }

            .report-tools table tbody tr {
                background: -webkit-linear-gradient(top, #DFDCCD 0%,#d1cec2 100%);
            }

        #divReportPatientName {
            padding-top: 30px !important;
        }

        #divBillDates {
            padding-top: 25px !important;
        }

        .ui-widget.ui-widget-content {
            z-index: 1000;
        }

        #spnTitle {
            font-size: 15px;
            display: inline-block;
            height: 27px;
            color: black;
            border-top-left-radius: 5px;
            border-top-right-radius: 4px;
            border: 1px solid #439abf;
            border-bottom: none;
            margin-top: -1%;
            border-right: none;
        }

        .WidgetTitle {
            background-color: #eeeff0 !important;
        }

        .clsPP {
            background-color: #eeeff0;
        }

        #spnTitle {
            cursor: pointer;
            margin-left: -0.001%;
        }

        #spnClose {
            display: inline-block;
            border-right: 1px solid #439abf;
            height: 27px !important;
        }

       /*.GridReports table {
            border-spacing: 0;
        }

           .GridReports table tbody,
           .GridReports table thead {
                display: block;
            }

      .GridReports thead tr th {
            height: 30px;
            line-height: 30px;
            width:1%;
            text-align:center;
        }
      .GridReports tbody tr td {
            height: 30px;
            width:1%;
            text-align:center;
        }

       .GridReports table tbody {
            height: 330px;
            overflow-y: auto;
        }
       .ReportGrid table {
            border-spacing: 0;
        }

           .ReportGrid table tbody,
           .ReportGrid table thead {
                display: block;
            }

      .ReportGrid thead tr th {
            height: 30px;
            line-height: 30px;
            width:1%;
            text-align:center;
        }
      .ReportGrid tbody tr td {
            height: 30px;
            width:1%;
            text-align:center;
        }

       .ReportGrid table tbody {
            height: 330px;
            overflow-y: auto;
        }
       .report-column-title{
           margin-left:4%;
       }*/
    </style>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


    <script>
        $(document).ready(function () {
            debugger;
            $("#divHumburger").click(function () {
                debugger;
                $(".div-reports-content").toggleClass("TwentyFive");
                $("#divScrollingMenu").toggleClass("divScrollingMenu220");
            });

        });

        /* $(function () {
              $("#accordion").accordion();
          });*/
        $(function () {
            $("#divPracticeAnalysis1").hide();
            $("#divPatient1").hide();
            $("#divScheduling1").hide();
            $("#divCompany1").hide();
            $("#h3Financial").on("click", function () {
                debugger;
                if ($("#iFinancial").is(".down")) {
                    $("#iFinancial").removeClass("down").addClass("up");
                }
                else if ($("#iFinancial").is(".up")) {
                    $("#iFinancial").removeClass("up").addClass("down");
                }
                $("#divFinancial1").toggle("blind", 1000);
            });

            $("#h3Scheduling").on("click", function () {
                debugger;
                if ($("#iScheduling").is(".down")) {
                    $("#iScheduling").removeClass("down").addClass("up");
                }
                else if ($("#iScheduling").is(".up")) {
                    $("#iScheduling").removeClass("up").addClass("down");
                }
                $("#divScheduling1").toggle("blind", 1000);
            });

            $("#h3PracticeAnalysis").on("click", function () {
                debugger;
                if ($("#iPracticeAnalysis").is(".down")) {
                    $("#iPracticeAnalysis").removeClass("down").addClass("up");
                }
                else if ($("#iPracticeAnalysis").is(".up")) {
                    $("#iPracticeAnalysis").removeClass("up").addClass("down");
                }
                $("#divPracticeAnalysis1").toggle("blind", 1000);
            });

            $("#h3Patient").on("click", function () {
                debugger;
                if ($("#iPatient").is(".down")) {
                    $("#iPatient").removeClass("down").addClass("up");
                }
                else if ($("#iPatient").is(".up")) {
                    $("#iPatient").removeClass("up").addClass("down");
                }
                $("#divPatient1").toggle("blind", 1000);
            });

            $("#h3Company").on("click", function () {
                debugger;
                if ($("#iCompany").is(".down")) {
                    $("#iCompany").removeClass("down").addClass("up");
                }
                else if ($("#iCompany").is(".up")) {
                    $("#iCompany").removeClass("up").addClass("down");
                }
                $("#divCompany1").toggle("blind", 1000);
            });
        });

    </script>

    <script src="../../Scripts/Reports.js"></script>

    <div id="divReprotsLink" runat="server">
        <table>
            <tr>


                <%-- left side --%>


                <td valign="top" style="width: 20%; padding-right: 10px">
                    <div class="Widget side-menu-reports" id="divScrollingMenu" style="box-shadow: none; border: none;">
                        <div class="WidgetContentReports" style="width: 100%; background-color: #eeefef;">
                            <div id="divTitle" style="font-weight: bold; border-bottom: 1px solid #439abf; cursor: pointer; font-size: 16px; height: 30px; margin-top: 3.9%;">Reports</div>
                            <div id="accordion">
                                <h3 style="font-weight: bold; border-bottom: 1px solid #439abf; width: 93%; cursor: pointer;" id="h3Financial">Financial <i class="up" id="iFinancial"></i></h3>
                                <div id="divFinancial1">
                                    <ul>
                                        <li onclick="openDirectReport('PP')"><i class="right"></i>&nbsp; Patient Payments</li>
                                        <li onclick="openDirectReport('DP')"><i class="right"></i>&nbsp; Daily Payments</li>
                                        <li onclick="openDirectReport('CSSS')"><i class="right"></i>&nbsp; Claim Submission Status Summary</li>
                                        <li onclick="openDirectReport('CP')"><i class="right"></i>&nbsp; Claim Payments</li>
                                        <li onclick="OpenPaymentsFilterDialog('PBP')"><i class="right"></i>&nbsp; Payment By Procedure</li>
                                        <li onclick="OpenPaymentsFilterDialog('PD')"><i class="right"></i>&nbsp; Payments Detail</li>
                                        <li onclick="OpenPaymentsFilterDialog('PS')"><i class="right"></i>&nbsp; Payments Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('PPS')"><i class="right"></i>&nbsp; Procedure Payments Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('CMS')"><i class="right"></i>&nbsp; Contract Management Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('CMD')"><i class="right"></i>&nbsp; Contract Management Detail</li>
                                        <li onclick="OpenPaymentsFilterDialog('MC')"><i class="right"></i>&nbsp; Missed Copays</li>
                                        <li onclick="OpenPaymentsFilterDialog('PA')"><i class="right"></i>&nbsp; Payment Appliction</li>
                                        <li onclick="OpenPaymentsFilterDialog('PAS')"><i class="right"></i>&nbsp; Payment Application Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('UA')"><i class="right"></i>&nbsp; Unapplied Analysis</li>
                                        <li onclick="OpenPaymentsFilterDialog('PMS')"><i class="right"></i>&nbsp; Payer Mix Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('ARAS')"><i class="right"></i>&nbsp; A/R Aging Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('ICD')"><i class="right"></i>&nbsp; Insurance Collection Detail</li>
                                        <li onclick="OpenPaymentsFilterDialog('ICS')"><i class="right"></i>&nbsp; Insurance Collection Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('PCS')"><i class="right"></i>&nbsp; Patient Collection Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('PCD')"><i class="right"></i>&nbsp; Patient Collection Detai</li>
                                        <li onclick="OpenPaymentsFilterDialog('UNC')"><i class="right"></i>&nbsp; Unpaid Insurance Claims</li>
                                        <li onclick="OpenPaymentsFilterDialog('DD')"><i class="right"></i>&nbsp; Denials Detail</li>
                                        <li onclick="OpenPaymentsFilterDialog('DS')"><i class="right"></i>&nbsp; Denials Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('ERAEOB')"><i class="right"></i>&nbsp; ERA/EOB List</li>
                                        <li onclick="OpenPaymentsFilterDialog('PTD')"><i class="right"></i>&nbsp; Patient Transactions Detail</li>
                                        <li onclick="OpenPaymentsFilterDialog('PED')"><i class="right"></i>&nbsp; Encounter Detail</li>
                                        <li onclick="OpenPaymentsFilterDialog('ES')"><i class="right"></i>&nbsp; Encounter Summary</li>
                                    </ul>
                                </div>
                                <h3 style="font-weight: bold; border-bottom: 1px solid #439abf; cursor: pointer; width: 93%;" id="h3PracticeAnalysis">Practice Analysis <i class="down" id="iPracticeAnalysis"></i></h3>
                                <div id="divPracticeAnalysis1">
                                    <ul>
                                        <li onclick="openDirectReport('TPro')"><i class="right"></i>&nbsp; Top 10 Procedures</li>
                                        <li onclick="openDirectReport('TPay')"><i class="right"></i>&nbsp; Top 10 Payers</li>
                                        <li onclick="openDirectReport('TDia')"><i class="right"></i>&nbsp; Top 10 Diagnosis</li>
                                    </ul>
                                </div>
                                <h3 style="font-weight: bold; border-bottom: 1px solid #439abf; cursor: pointer; width: 93%;" id="h3Patient">Patient <i class="down" id="iPatient"></i></h3>
                                <div id="divPatient1">
                                    <ul>
                                        <li onclick="openDirectReport('PV')"><i class="right"></i>&nbsp; Patient Visit</li>
                                        <li onclick="openDirectReport('BD')"><i class="right"></i>&nbsp; Balance Due</li>
                                        <li onclick="openDirectReport('MA')"><i class="right"></i>&nbsp; Missing Appointments</li>
                                        <li onclick="openDirectReport('PCl')"><i class="right"></i>&nbsp; Patient Claims</li>
                                        <li onclick="OpenPatientFilterDialog('PCL')"><i class="right"></i>&nbsp; Patient Contact List</li>
                                        <li onclick="OpenPatientFilterDialog('PD')"><i class="right"></i>&nbsp; Patient Details</li>
                                        <li onclick="OpenPatientFilterDialog('PS')"><i class="right"></i>&nbsp; Patient Summary</li>
                                        <li onclick="OpenPatientFilterDialog('PBD')"><i class="right"></i>&nbsp; Patient Balance Detail</li>
                                        <li onclick="OpenPatientFilterDialog('PBS')"><i class="right"></i>&nbsp; Patient Balance Summary</li>
                                        <li onclick="OpenPatientFilterDialog('PTS')"><i class="right"></i>&nbsp; Patient Transactions Summary</li>
                                        <li onclick="OpenPatientFilterDialog('AD')"><i class="right"></i>&nbsp; Adjustments Detail</li>
                                        <li onclick="OpenPatientFilterDialog('AS')"><i class="right"></i>&nbsp; Adjustments Summary</li>
                                        <li onclick="OpenPatientFilterDialog('CS')"><i class="right"></i>&nbsp; Charges Summary</li>
                                        <li onclick="OpenPatientFilterDialog('CD')"><i class="right"></i>&nbsp; Charges Detail</li>
                                        <li onclick="OpenPatientFilterDialog('SCS')"><i class="right"></i>&nbsp; Settled Charges Summary</li>
                                        <li onclick="openDirectReport('SL')"><i class="right"></i>&nbsp; Service Locations</li>
                                        <li onclick="openDirectReport('RP')"><i class="right"></i>&nbsp; Referring Physicians</li>
                                        <li onclick="openDirectReport('Pro')"><i class="right"></i>&nbsp; Providers</li>
                                        <li onclick="OpenPatientFilterDialog('IOC')"><i class="right"></i>&nbsp; Itemization Of Charges</li>
                                    </ul>
                                </div>
                                <h3 style="font-weight: bold; border-bottom: 1px solid #439abf; cursor: pointer; width: 93%;" id="h3Scheduling">Scheduling <i class="down" id="iScheduling"></i></h3>
                                <div id="divScheduling1">
                                    <ul>
                                        <li onclick="openDirectReport('AS')"><i class="right"></i>&nbsp; Appointment Summary</li>
                                        <li onclick="OpenPaymentsFilterDialog('AppD')"><i class="right"></i>&nbsp; Appointments Detail</li>
                                    </ul>
                                </div>
                                <h3 style="font-weight: bold; border-bottom: 1px solid #439abf; cursor: pointer; width: 93%;" id="h3Company">Company <i class="down" id="iCompany"></i></h3>
                                <div id="divCompany1">
                                    <ul>
                                        <li onclick="openDirectReport('CI')"><i class="right"></i>&nbsp; Company Indicator</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <%-- Right Side --%>
                <td valign="top" style="width: 80%" id="tdReportDetail">
                    <div class="WidgetTitle">
                        <span id="spnTitle" class="clsPP" style="font-size: 15px;"><span class="clsPP" onclick="openDirectReport1(this);">Patient Payments</span><span id="spnClose" class="PP">&nbsp;</span></span>
                    </div>
                    <div id="divReport">
                        <div class="Widget" style="padding: 5px 6px 5px 4px; box-sizing: border-box;">
                            <div class="WidgetContentReport">
                                <div class="WidgetReport" style="margin-top: 3px;">
                                    <div id="divReportPaging">
                                        <div class="pagerReport">
                                            <div class="PageEntries">
                                                <span style="float: left; margin-left: 5px; font-weight: bold;">Show&nbsp;</span><span style="float: left;">
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
                                                <asp:Repeater ID="rptReportData" runat="server">
                                                    <HeaderTemplate>
                                                        <div class="GridReports">
                                                            <table>
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            <span class="report-column-title">#</span><span></span>
                                                                        </th>
                                                                        <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                                            <span class="report-column-title">Patient Account</span><span class="filterIcon asc"></span>
                                                                        </th>
                                                                        <th class="asc" onclick="SortReportList(this,'PaymentMethod');">
                                                                            <span class="report-column-title">Payment Method</span><span></span>
                                                                        </th>
                                                                        <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                                            <span class="report-column-title">Payer Name</span><span></span>
                                                                        </th>
                                                                        <th class="asc" onclick="SortReportList(this,'CheckNumber');">
                                                                            <span class="report-column-title">Check/Ref #</span><span></span>
                                                                        </th>
                                                                        <th class="asc" onclick="SortReportList(this,'PaymentDate');">
                                                                            <span class="report-column-title">Payment Date</span><span></span>
                                                                        </th>
                                                                        <th class="asc" onclick="SortReportList(this,'PaidAmount');">
                                                                            <span class="report-column-title">Paid Amount</span><span></span>
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody id="tbodyReportList">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <%# Eval("RowNumber")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("PatientId")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("PaymentMethod")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("PayerName")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("CheckNumber")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("CheckIssueDate")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("PaymentAmount")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody>
                                </table>
                            </div>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <%--  <div class="pager">
                                                    <div class="PageButtons">
                                                        <ul style="float: right; margin-right: 15px;">
                                                        </ul>
                                                    </div>
                                                </div>--%>
                                            </div>

                                        </div>

                                    </div>

                                </div>
                                <%--<div class=""style="background-color:gray;height:25px;width:100%"></div>  --%>
                            </div>
                        </div>

                        <asp:HiddenField ID="hdnReportHtml" runat="server" />
                        <input type="hidden" id="hdnTotalRows" runat="server" value="0" />

                        <script type="text/javascript">
                            $(document).ready(function () {
                                _SortBy = 'PatientId';
                                _SortByValue = 'ASC';

                                SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

                                GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
                            });

                            function FilterReportList(pageNumber, paging) {
                                var params = {
                                    Rows: $("#ddlPagingReport").val(),
                                    PageNumber: pageNumber,
                                    SortBy: _SortBy + " " + _SortByValue,
                                    action: "Filter"
                                };

                                var actionPage = "FilterPatientPayments.aspx";

                                Report_ReloadData(actionPage, params, paging);
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
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divRightsReports" class="divRights" style="display: none">
        <div id="divDialogReportFilters" style="display: none;"></div>
    </div>
</asp:Content>
