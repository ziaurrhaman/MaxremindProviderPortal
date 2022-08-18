<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PatientVitalSign.aspx.cs" Inherits="ProviderPortal_Reports_PatientVitalSign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });

        $(function () {
            $(".datepicker").datepicker({
                changeMonth: true,
                changeYear: true
            }).mask("99/99/9999");

            $(document).on("click", "body", function (event) {
                if (event.target.nodeName != "INPUT") {
                    $("#divAutoSearchPatient").slideUp();
                }
            });

            $(document).on("keyup", "body", function (event) {
                if (event.which == 27 || event.which == 9) {
                    $("#divAutoSearchPatient").slideUp();
                }
            });

            $(".report-list-container").find("#patVitalSignReport").addClass("report-active");
        });

        function createVitalSignReport() {
            if ($("[id$='hdnPatientId']").val() == "" || $("[id$='hdnPatientId']").val() == "0") {
                showErrorMessage("Please select patient first");
                return false;
            }
            $("#divMesg").hide();
            $("#linkShowHideVitalList").html("Show vital list");
            if (!ValidateForm("divVitalReportMain")) {
                showErrorMessage("");
                return false;
            }
            var PatientId = $("[id$='hdnPatientId']").val();
            var DateFrom = $("[id$='txtDateFrom']").val();
            var DateTo = $("[id$='txtDateTo']").val();

            if (Date.parse(DateTo) < Date.parse(DateFrom)) {
                showErrorMessage("Date To can not be earlier than Date From");
                return false;
            }

            if ($("#divVitalsList .cbGraphs:checked").length == 0 && $("#divVitalsList .cbTable:checked").length == 0) {
                showErrorMessage("Please select atleast one vital sign to create report.");
                return false;
            }

            var objReportPatientVitalSignGraphTable = new Object();
            objReportPatientVitalSignGraphTable.PulseGraph = $("[id$='cbPulseGraph']").is(":checked");
            objReportPatientVitalSignGraphTable.PulseTable = $("[id$='cbPulseTable']").is(":checked");

            objReportPatientVitalSignGraphTable.TemperatureGraph = $("[id$='cbTemperatureGraph']").is(":checked");
            objReportPatientVitalSignGraphTable.TemperatureTable = $("[id$='cbTemperatureTable']").is(":checked");

            objReportPatientVitalSignGraphTable.BloodPressureGraph = $("[id$='cbBloodPressureGraph']").is(":checked");
            objReportPatientVitalSignGraphTable.BloodPressureTable = $("[id$='cbBloodPressureTable']").is(":checked");

            objReportPatientVitalSignGraphTable.RespiratoryGraph = $("[id$='cbRespiratoryGraph']").is(":checked");
            objReportPatientVitalSignGraphTable.RespiratoryTable = $("[id$='cbRespiratoryTable']").is(":checked");

            objReportPatientVitalSignGraphTable.WeightGraph = $("[id$='cbWeightGraph']").is(":checked");
            objReportPatientVitalSignGraphTable.WeightTable = $("[id$='cbWeightTable']").is(":checked");

            $.ajax({
                type: "POST",
                url: "../DashboardDataService.asmx/GetVitalReportDataGraph",
                data: JSON.stringify({
                    PatientId: PatientId,
                    DateFrom: DateFrom,
                    DateTo: DateTo
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result, status) {

                    result = result.d;

                    var listReportVital = JSON.parse(result);

                    $.post(_EMRPath + "/Reports/CallBacks/PatientVitalSignHandler.aspx", { PatientId: PatientId, DateFrom: DateFrom, DateTo: DateTo, objReportPatientVitalSignGraphTable: JSON.stringify(objReportPatientVitalSignGraphTable) }, function (data) {
                        var returnHtml = data;

                        var StartPulse = data.indexOf("###StartPulse###") + 16;
                        var EndPulse = data.indexOf("###EndPulse###");
                        $("#vitalPulseList").html(returnHtml.substring(StartPulse, EndPulse));

                        var StartTemperature = data.indexOf("###StartTemperature###") + 22;
                        var EndTemperature = data.indexOf("###EndTemperature###");
                        $("#vitalTemperatureList").html(returnHtml.substring(StartTemperature, EndTemperature));

                        var StartBloodPressure = data.indexOf("###StartBloodPressure###") + 24;
                        var EndBloodPressure = data.indexOf("###EndBloodPressure###");
                        $("#vitalBloodPressureList").html(returnHtml.substring(StartBloodPressure, EndBloodPressure));

                        var StartRespiratory = data.indexOf("###StartRespiratory###") + 22;
                        var EndRespiratory = data.indexOf("###EndRespiratory###");
                        $("#vitalRespiratoryList").html(returnHtml.substring(StartRespiratory, EndRespiratory));

                        var StartWeight = data.indexOf("###StartWeight###") + 17;
                        var EndWeight = data.indexOf("###EndWeight###");
                        $("#vitalWeightList").html(returnHtml.substring(StartWeight, EndWeight));

                        SetHtml('divPulseContainer', 'ReportGrid', 'hdnInputPulse');
                        SetHtml('divTemperatureContainer', 'ReportGrid', 'hdnInputTemperature');
                        SetHtml('divBloodPressureContainer', 'ReportGrid', 'hdnInputBloodPressure');
                        SetHtml('divRespiratoryContainer', 'ReportGrid', 'hdnInputRespiratory');
                        SetHtml('divWeightContainer', 'ReportGrid', 'hdnInputWeight');

                        showHideVitalList(false);
                        var ReportVitalPulseArray = new Array();
                        ReportVitalPulseArray.push(['Date', '']);

                        var ReportVitalTemperatureArray = new Array();
                        ReportVitalTemperatureArray.push(['Date', '']);

                        var ReportVitalBloodPressureArray = new Array();
                        ReportVitalBloodPressureArray.push(['Date', '']);

                        var ReportVitalRespiratoryArray = new Array();
                        ReportVitalRespiratoryArray.push(['Date', '']);

                        var ReportVitalWeightArray = new Array();
                        ReportVitalWeightArray.push(['Date', '']);

                        for (var i = 0; i < listReportVital.length; i++) {
                            ReportVitalPulseArray.push([listReportVital[i].Date, parseFloat(listReportVital[i].HeartRate)]);

                            ReportVitalTemperatureArray.push([listReportVital[i].Date, parseFloat(listReportVital[i].Temperature)]);

                            ReportVitalBloodPressureArray.push([listReportVital[i].Date, parseFloat(listReportVital[i].BP1Systolic)]);

                            ReportVitalRespiratoryArray.push([listReportVital[i].Date, parseFloat(listReportVital[i].RespirationRate)]);

                            ReportVitalWeightArray.push([listReportVital[i].Date, parseFloat(listReportVital[i].Weight)]);
                        }

                        if (!objReportPatientVitalSignGraphTable.PulseTable && !objReportPatientVitalSignGraphTable.PulseGraph) {
                            $("#divPulseContainer").hide();
                        }
                        else {
                            $("#divPulseContainer").show();
                            if (objReportPatientVitalSignGraphTable.PulseGraph) {
                                if (ReportVitalPulseArray.length > 1) {
                                    drawChartPulse(ReportVitalPulseArray);
                                }
                                $("#divGraphPulse").show();
                            }
                            else {
                                $("#divGraphPulse").hide();
                            }

                            if (objReportPatientVitalSignGraphTable.PulseTable) {
                                GenerateReportPaging($("[id$='hdnTotalRowsPulse']").val(), $("#ddlPagingReportPulse").val(), "pagingPulseReportDiv", "FilterReportPulse");
                                $("#divTablePulse").show();
                            }
                            else {
                                $("#divTablePulse").hide();
                            }
                        }

                        if (!objReportPatientVitalSignGraphTable.TemperatureTable && !objReportPatientVitalSignGraphTable.TemperatureGraph) {
                            $("#divTemperatureContainer").hide();
                        }
                        else {
                            $("#divTemperatureContainer").show();

                            if (objReportPatientVitalSignGraphTable.TemperatureGraph) {
                                if (ReportVitalTemperatureArray.length > 1) {
                                    drawChartTemperature(ReportVitalTemperatureArray);
                                }
                                $("#divGraphTemperature").show();
                            }
                            else {
                                $("#divGraphTemperature").hide();
                            }

                            if (objReportPatientVitalSignGraphTable.TemperatureTable) {
                                GenerateReportPaging($("[id$='hdnTotalRowsTemperature']").val(), $("#ddlPagingTemperature").val(), "pagingTemperatureReportDiv", "FilterReportTemperature");
                                $("#divTableTemperature").show();
                            }
                            else {
                                $("#divTableTemperature").hide();
                            }
                        }

                        if (!objReportPatientVitalSignGraphTable.BloodPressureTable && !objReportPatientVitalSignGraphTable.BloodPressureGraph) {
                            $("#divBloodPressureContainer").hide();
                        }
                        else {
                            $("#divBloodPressureContainer").show();

                            if (objReportPatientVitalSignGraphTable.BloodPressureGraph) {
                                if (ReportVitalBloodPressureArray.length > 1) {
                                    drawChartBloodPressure(ReportVitalBloodPressureArray);
                                }
                                $("#divGraphBloodPressure").show();
                            }
                            else {
                                $("#divGraphBloodPressure").hide();
                            }

                            if (objReportPatientVitalSignGraphTable.BloodPressureTable) {
                                GenerateReportPaging($("[id$='hdnTotalRowsBloodPressure']").val(), $("#ddlPagingBloodPressure").val(), "pagingBloodPressureReportDiv", "FilterReportBloodPressure");
                                $("#divTableBloodPressure").show();
                            }
                            else {
                                $("#divTableBloodPressure").hide();
                            }
                        }

                        if (!objReportPatientVitalSignGraphTable.RespiratoryTable && !objReportPatientVitalSignGraphTable.RespiratoryGraph) {
                            $("#divRespiratoryContainer").hide();
                        }
                        else {
                            $("#divRespiratoryContainer").show();

                            if (objReportPatientVitalSignGraphTable.RespiratoryGraph) {
                                if (ReportVitalRespiratoryArray.length > 1) {
                                    drawChartRespiratory(ReportVitalRespiratoryArray);
                                }

                                $("#divGraphRespiratory").show();
                            }
                            else {
                                $("#divGraphRespiratory").hide();
                            }

                            if (objReportPatientVitalSignGraphTable.RespiratoryTable) {
                                GenerateReportPaging($("[id$='hdnTotalRowsRespiratory']").val(), $("#ddlPagingRespiratory").val(), "pagingRespiratoryReportDiv", "FilterReportRespiratory");
                                $("#divTableRespiratory").show();
                            }
                            else {
                                $("#divTableRespiratory").hide();
                            }
                        }

                        if (!objReportPatientVitalSignGraphTable.WeightTable && !objReportPatientVitalSignGraphTable.WeightGraph) {
                            $("#divWeightContainer").hide();
                        }
                        else {
                            $("#divWeightContainer").show();
                            if (objReportPatientVitalSignGraphTable.WeightGraph) {
                                if (ReportVitalWeightArray.length > 1) {
                                    drawChartWeight(ReportVitalWeightArray);
                                }
                                $("#divGraphWeight").show();
                            }
                            else {
                                $("#divGraphWeight").hide();
                            }

                            if (objReportPatientVitalSignGraphTable.WeightTable) {
                                GenerateReportPaging($("[id$='hdnTotalRowsWeight']").val(), $("#ddlPagingWeight").val(), "pagingWeightReportDiv", "FilterReportWeight");
                                $("#divTableWeight").show();
                            }
                            else {
                                $("#divTableWeight").hide();
                            }
                        }
                    });
                }
            });
        }

        function drawChartPulse(list) {
            var data = google.visualization.arrayToDataTable(list);
            var options = {
                title: "",
                legend: { position: 'none' },
                pointSize: 1,
                'vAxis': { 'title': 'Pluse Rate' },
                'hAxis': { 'title': 'Date' }
            };
            var chart = new google.visualization.LineChart(document.getElementById('divGraphPulse'));
            chart.draw(data, options);
        }

        function drawChartTemperature(list) {
            var data = google.visualization.arrayToDataTable(list);
            var options = {
                title: "",
                legend: { position: 'none' },
                pointSize: 6,
                'vAxis': { 'title': 'Temperature' },
                'hAxis': { 'title': 'Date' }
            };
            var chart = new google.visualization.LineChart(document.getElementById('divGraphTemperature'));
            chart.draw(data, options);
        }

        function drawChartBloodPressure(list) {
            var data = google.visualization.arrayToDataTable(list);
            var options = {
                title: "",
                legend: { position: 'none' },
                pointSize: 6,
                'vAxis': { 'title': 'Blood Pressure' },
                'hAxis': { 'title': 'Date' }
            };
            var chart = new google.visualization.LineChart(document.getElementById('divGraphBloodPressure'));
            chart.draw(data, options);
        }

        function drawChartRespiratory(list) {
            var data = google.visualization.arrayToDataTable(list);
            var options = {
                title: "",
                legend: { position: 'none' },
                pointSize: 6,
                'vAxis': { 'title': 'Respiration' },
                'hAxis': { 'title': 'Date' }
            };
            var chart = new google.visualization.LineChart(document.getElementById('divGraphRespiratory'));
            chart.draw(data, options);
        }

        function drawChartWeight(list) {
            var data = google.visualization.arrayToDataTable(list);
            var options = {
                title: "",
                legend: { position: 'none' },
                pointSize: 6,
                'vAxis': { 'title': 'Weight (kg)' },
                'hAxis': { 'title': 'Date' }
            };
            var chart = new google.visualization.LineChart(document.getElementById('divGraphWeight'));
            chart.draw(data, options);
        }


        function printReport(divToPrint) {
            var headstr = "<html><head><title></title></head><body>";
            var footstr = "</body></html>";
            var newstr = $("[id$='" + divToPrint + "']").html();
            var popupWin = window.open('', '_blank');
            popupWin.document.write(headstr + newstr + footstr);
            popupWin.print();
            return false;
        }

        function FilterReportPulse(pageNumber, paging) {
            var PatientId = $("[id$='hdnPatientId']").val();
            var DateFrom = $("[id$='txtDateFrom']").val();
            var DateTo = $("[id$='txtDateTo']").val();
            var SortBy = "";

            $.post(_EMRPath + "/Reports/CallBacks/FilterPatientVitalSignPulse.aspx", { PatientId: PatientId, DateFrom: DateFrom, DateTo: DateTo, Rows: $("#ddlPagingReportPulse").val(), PageNumber: pageNumber, SortBy: SortBy },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#vitalPulseList").html(returnHtml.substring(start, end));
                SetHtml('divPulseContainer', 'ReportGrid', 'hdnInputPulse');
                if (paging == true) {
                    GenerateReportPaging($("[id$='hdnTotalRowsPulse']").val(), $("#ddlPagingReportPulse").val(), "pagingPulseReportDiv", "FilterReportPulse");
                }
            });
        }

        function FilterReportTemperature(pageNumber, paging) {
            var PatientId = $("[id$='hdnPatientId']").val();
            var DateFrom = $("[id$='txtDateFrom']").val();
            var DateTo = $("[id$='txtDateTo']").val();
            var SortBy = "";

            $.post(_EMRPath + "/Reports/CallBacks/FilterPatientVitalSignTemperature.aspx", { PatientId: PatientId, DateFrom: DateFrom, DateTo: DateTo, Rows: $("#ddlPagingTemperature").val(), PageNumber: pageNumber, SortBy: SortBy },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#vitalTemperatureList").html(returnHtml.substring(start, end));
                SetHtml('divTemperatureContainer', 'ReportGrid', 'hdnInputTemperature');

                if (paging == true) {
                    GenerateReportPaging($("[id$='hdnTotalRowsTemperature']").val(), $("#ddlPagingTemperature").val(), "pagingTemperatureReportDiv", "FilterReportTemperature");
                }

            });
        }

        function FilterReportBloodPressure(pageNumber, paging) {
            var PatientId = $("[id$='hdnPatientId']").val();
            var DateFrom = $("[id$='txtDateFrom']").val();
            var DateTo = $("[id$='txtDateTo']").val();
            var SortBy = "";

            $.post(_EMRPath + "/Reports/CallBacks/FilterPatientVitalSignBloodPressure.aspx", { PatientId: PatientId, DateFrom: DateFrom, DateTo: DateTo, Rows: $("#ddlPagingBloodPressure").val(), PageNumber: pageNumber, SortBy: SortBy },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#vitalBloodPressureList").html(returnHtml.substring(start, end));

                SetHtml('divBloodPressureContainer', 'ReportGrid', 'hdnInputBloodPressure');

                if (paging == true) {
                    GenerateReportPaging($("[id$='hdnTotalRowsBloodPressure']").val(), $("#ddlPagingBloodPressure").val(), "pagingBloodPressureReportDiv", "FilterReportBloodPressure");
                }

            });
        }

        function FilterReportRespiratory(pageNumber, paging) {
            var PatientId = $("[id$='hdnPatientId']").val();
            var DateFrom = $("[id$='txtDateFrom']").val();
            var DateTo = $("[id$='txtDateTo']").val();
            var SortBy = "";

            $.post(_EMRPath + "/Reports/CallBacks/FilterPatientVitalSignRespiratory.aspx", { PatientId: PatientId, DateFrom: DateFrom, DateTo: DateTo, Rows: $("#ddlPagingRespiratory").val(), PageNumber: pageNumber, SortBy: SortBy },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#vitalRespiratoryList").html(returnHtml.substring(start, end));
                SetHtml('divRespiratoryContainer', 'ReportGrid', 'hdnInputRespiratory');

                if (paging == true) {
                    GenerateReportPaging($("[id$='hdnTotalRowsRespiratory']").val(), $("#ddlPagingRespiratory").val(), "pagingRespiratoryReportDiv", "FilterReportRespiratory");
                }

            });
        }

        function FilterReportWeight(pageNumber, paging) {
            var PatientId = $("[id$='hdnPatientId']").val();
            var DateFrom = $("[id$='txtDateFrom']").val();
            var DateTo = $("[id$='txtDateTo']").val();
            var SortBy = "";

            $.post(_EMRPath + "/Reports/CallBacks/FilterPatientVitalSignWeight.aspx", { PatientId: PatientId, DateFrom: DateFrom, DateTo: DateTo, Rows: $("#ddlPagingWeight").val(), PageNumber: pageNumber, SortBy: SortBy },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#vitalWeightList").html(returnHtml.substring(start, end));
                SetHtml('divWeightContainer', 'ReportGrid', 'hdnInputWeight');

                if (paging == true) {
                    GenerateReportPaging($("[id$='hdnTotalRowsWeight']").val(), $("#ddlPagingWeight").val(), "pagingWeightReportDiv", "FilterReportWeight");
                }

            });
        }

        function showHideVitalList(direct) {
            if (direct) {
                if ($("#divVitalsList").css("display") == "none") {
                    $("#linkShowHideVitalList").html("Hide vital list");
                }
                else {
                    $("#linkShowHideVitalList").html("Show vital list");
                }
                $("#divVitalsList").slideToggle();
            }
            else {
                if ($("#divVitalsList").css("display") != "none") {
                    $("#divVitalsList").slideToggle();
                }
            }
        }

        function searchPatients(elem, event) {
            var PatientName = $(elem).val();

            if (PatientName == "") {
                $("#divAutoSearchPatient").slideUp();
            }

            if ((event.which > 47 && event.which < 58) || (event.which > 64 && event.which < 91) || (event.which == 16) || (event.which == 8) || (event.which == 46)) {
                if (PatientName != "") {
                    $.post("../../ProviderPortal/Reports/CallBacks/PatientAutoComplete.aspx", { PatientName: PatientName }, function (data) {
                        var start = data.indexOf("###Start###") + 11;
                        var end = data.indexOf("###End###");
                        var returnHtml = $.trim(data.substring(start, end));
                        $("#divAutoSearchPatient").html(returnHtml);

                        $("#divAutoSearchPatient li").eq(0).addClass("focusedli");

                        $("#divAutoSearchPatient").slideDown();
                    });
                }
            }
            else if (event.which == 40) { //Key Down Case
                var selectedLi = $("#divAutoSearchPatient li.focusedli");
                if (!selectedLi.is($("#divAutoSearchPatient li").last())) {
                    selectedLi.removeClass("focusedli");
                    selectedLi.next().addClass("focusedli");
                }
            }
            else if (event.which == 38) { //Key Up Case
                var selectedLi = $("#divAutoSearchPatient li.focusedli");
                if (!selectedLi.is($("#divAutoSearchPatient li").first())) {
                    selectedLi.removeClass("focusedli");
                    selectedLi.prev().addClass("focusedli");
                }
            }
            else if (event.which == 13) { //Enter Case
                var selectedLi = $("#divAutoSearchPatient li.focusedli");
                $(elem).val($.trim(selectedLi.find("span").html()));

                var PatientId = selectedLi.find(".hdnPatientId").val();
                $("[id$='hdnPatientId']").val(PatientId);

                $("#divAutoSearchPatient").slideUp();
            }
        }

        function selectPatient(elem) {
            $("[id$='txtPatient']").val($.trim($(elem).find("span").html()));

            var PatientId = $(elem).find(".hdnPatientId").val();
            $("[id$='hdnPatientId']").val(PatientId);
            $("#divAutoSearchPatient").slideUp();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <div id="divVitalReportMain">
        <asp:HiddenField ID="hdnInputPulse" runat="server" />
        <asp:HiddenField ID="hdnInputTemperature" runat="server" />
        <asp:HiddenField ID="hdnInputBloodPressure" runat="server" />
        <asp:HiddenField ID="hdnInputRespiratory" runat="server" />
        <asp:HiddenField ID="hdnInputWeight" runat="server" />
        <asp:HiddenField ID="hdnPracticeId" runat="server" />
        <asp:HiddenField runat="server" ID="hdnTotalRows" />
        
        <div class="Widget" style="margin-top: 10px;">
            <div class="WidgetTitle">
                <span id="spnTitle" style="font-size: 15px;">Patient Vital Sign Report</span>            
            </div>
            <div class="WidgetContent">
                <fieldset>
                    <legend>Search Criteria</legend>
                    <table>
                        <tr>
                            <td style="width: 60px;">
                                Patient:<span class="spnError">*</span>
                            </td>
                            <td style="position: relative; width: 25%;">
                                <input type="text" autocomplete="off" id="txtPatient" onkeyup="searchPatients(this, event);" class="required" style="width: 84%;" />
                                <div id="divAutoSearchPatient" class="auto-complete-div" style="display:none;"></div>
                                <input type="hidden" id="hdnPatientId" />
                            </td>                                          
                            <td  style="width: 50px;">
                                From:
                            </td>
                            <td style="width: 130px;" >
                                <input type="text" id="txtDateFrom" class="datepicker required" style="width: 80%;" />
                            </td>
                           <td  style="width: 50px;">
                                To:
                            </td>
                            <td style="width: 130px;">
                                <input type="text" id="txtDateTo" class="datepicker required"  style="width: 80%;" />
                            </td>
                            <td style="text-align: left;">
                                <input type="button" style="margin-left: 20px;" value="Get Report" onclick="createVitalSignReport();" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <div style="float:left; width: 99%; margin: 15px 0 5px 15px;">
                    <a href="javascript:void(0);" id="linkShowHideVitalList" onclick="showHideVitalList(true);" style="color:Blue;">Hide vital list</a>
                </div>
                <div class="Grid" id="divVitalsList">
                    <table>
                        <thead>
                            <tr>
                                <th style="width: 84%; text-align: left; padding: 0 0 0 2%;">
                                    Vital Sign
                                </th>
                                <th style="width: 7%;">
                                    Graph
                                </th>
                                <th style="width: 7%;">
                                    Table
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    Pulse
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbPulseGraph" class="cbGraphs" />
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbPulseTable" class="cbTable" />
                                </td>
                            </tr>
                            <tr class="alternatingRow">
                                <td>
                                    Temperature
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbTemperatureGraph" class="cbGraphs" />
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbTemperatureTable" class="cbTable" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Blood Pressure
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbBloodPressureGraph" class="cbGraphs" />
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbBloodPressureTable" class="cbTable" />
                                </td>
                            </tr>
                            <tr class="alternatingRow">
                                <td>
                                    Respiratory
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbRespiratoryGraph" class="cbGraphs" />
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbRespiratoryTable" class="cbTable" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Weight
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbWeightGraph" class="cbGraphs" />
                                </td>
                                <td style="text-align: center;">
                                    <input type="checkbox" id="cbWeightTable" class="cbTable" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div>&nbsp;</div>
                
                <div id="divVitalSignReportContainer">
                    <div id="divPulseContainer" class="vital-report-sub" style="display:none;">
                        <h3 id="hPulse" class="h-container">Pulse</h3>
                        <div id="divGraphPulse" class="graph-container"></div>
                        <div id="divTablePulse" class="table-container">
                            <div class="WidgetReport">
                                <div>
                                    <div id="pagingPulseReportDiv">
                                        <div class="pagerReport">
                                            <div class="PageEntries">
                                                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                                    <select id="ddlPagingReportPulse" style="margin-top: 5px;" onchange="RowsChange('FilterReportPulse');">
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
                                            <div class="report-tools">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div class="report-export-wrapper">
                                                                <asp:DropDownList ID="ddlPulseExportTo" runat="server" 
                                                                    CssClass="custom-export-drop-down" 
                                                                    onselectedindexchanged="ddlPulseExportTo_SelectedIndexChanged" AutoPostBack="True">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                                    <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                                    <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <a href="javascript:void(0)" class="custom-export-icon">
                                                                    <img src="../../Images/exportIconLeft.gif" style="border-style:None;height:16px;width:16px;">
                                                                    <span style="width:5px;text-decoration:none;"> </span>
                                                                    <img src="../../Images/exportIconRight.gif" style="border-style:None;height:6px;width:7px;margin-bottom:5px;">
                                                                </a>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="printReport('ReportContainerPulse');"><img src="../../Images/print.png" /></a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-tool-icon" onclick="FilterReportPulse(0,true);"><img src="../../Images/ReportRefresh.gif" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--<div class="report-edit-wrapper" onclick="ReportEdit();">
                                                <span class="spanedit">Edit</span>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="WidgetReportContent">
                                    <div style="width: 100%; float:left;">
                                        <div id="ReportContainerPulse">
                                            <div class="ReportGrid">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>
                                                                Date
                                                            </th>
                                                            <th>
                                                                Time In
                                                            </th>
                                                            <th>
                                                                Pulse
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="vitalPulseList">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divTemperatureContainer" class="vital-report-sub" style="display:none;">
                        <h3 id="hTemperature" class="h-container">Temperature</h3>
                        <div id="divGraphTemperature" class="graph-container"></div>
                        <div id="divTableTemperature" class="table-container">
                            <div class="WidgetReport">
                                <div>
                                    <div id="pagingTemperatureReportDiv">
                                        <div class="pagerReport">
                                            <div class="PageEntries">
                                                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                                    <select id="ddlPagingTemperature" style="margin-top: 5px;" onchange="RowsChange('FilterReportTemperature');">
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
                                            <div class="report-tools">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div class="report-export-wrapper">
                                                                <asp:DropDownList ID="ddlTemperatureExportTo" runat="server" 
                                                                    CssClass="custom-export-drop-down"  AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlTemperatureExportTo_SelectedIndexChanged">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                                    <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                                    <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <a href="javascript:void(0)" class="custom-export-icon">
                                                                    <img src="../../Images/exportIconLeft.gif" style="border-style:None;height:16px;width:16px;">
                                                                    <span style="width:5px;text-decoration:none;"> </span>
                                                                    <img src="../../Images/exportIconRight.gif" style="border-style:None;height:6px;width:7px;margin-bottom:5px;">
                                                                </a>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="printReport('ReportContainerTemperature');"><img src="../../Images/print.png" /></a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-tool-icon" onclick="FilterReportTemperature(0,true);"><img src="../../Images/ReportRefresh.gif" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--<div class="report-edit-wrapper" onclick="ReportEdit();">
                                                <span class="spanedit">Edit</span>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="WidgetReportContent">
                                    <div style="width: 100%; float:left;">
                                        <div id="ReportContainerTemperature">
                                            <div class="ReportGrid">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>
                                                                Date
                                                            </th>
                                                            <th>
                                                                Time In
                                                            </th>
                                                            <th>
                                                                Temperature (C<sup>o</sup>)
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="vitalTemperatureList">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divBloodPressureContainer" class="vital-report-sub" style="display:none;">
                        <h3 id="hBloodPressure" class="h-container">Blood Pressure</h3>
                        <div id="divGraphBloodPressure" class="graph-container"></div>
                        <div id="divTableBloodPressure" class="table-container">
                            <div class="WidgetReport">
                                <div>
                                    <div id="pagingBloodPressureReportDiv">
                                        <div class="pagerReport">
                                            <div class="PageEntries">
                                                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                                    <select id="ddlPagingBloodPressure" style="margin-top: 5px;" onchange="RowsChange('FilterReportBloodPressure');">
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
                                            <div class="report-tools">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div class="report-export-wrapper">
                                                                <asp:DropDownList ID="ddlBloodPressureExportTo" runat="server" 
                                                                    CssClass="custom-export-drop-down" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlBloodPressureExportTo_SelectedIndexChanged1">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                                    <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                                    <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <a href="javascript:void(0)" class="custom-export-icon">
                                                                    <img src="../../Images/exportIconLeft.gif" style="border-style:None;height:16px;width:16px;">
                                                                    <span style="width:5px;text-decoration:none;"> </span>
                                                                    <img src="../../Images/exportIconRight.gif" style="border-style:None;height:6px;width:7px;margin-bottom:5px;">
                                                                </a>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="printReport('ReportContainerBloodPressure');"><img src="../../Images/print.png" /></a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-tool-icon" onclick="FilterReportBloodPressure(0,true);"><img src="../../Images/ReportRefresh.gif" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--<div class="report-edit-wrapper" onclick="ReportEdit();">
                                                <span class="spanedit">Edit</span>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="WidgetReportContent">
                                    <div style="width: 100%; float:left;">
                                        <div id="ReportContainerBloodPressure">
                                            <div class="ReportGrid">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>
                                                                Date
                                                            </th>
                                                            <th>
                                                                Time In
                                                            </th>
                                                            <th>
                                                                Blood Pressure
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="vitalBloodPressureList">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divRespiratoryContainer" class="vital-report-sub" style="display:none;">
                        <h3 id="hRespiratory" class="h-container">Respiratory</h3>
                        <div id="divGraphRespiratory" class="graph-container"></div>
                        <div id="divTableRespiratory" class="table-container">
                            <div class="WidgetReport">
                                <div>
                                    <div id="pagingRespiratoryReportDiv">
                                        <div class="pagerReport">
                                            <div class="PageEntries">
                                                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                                    <select id="ddlPagingRespiratory" style="margin-top: 5px;" onchange="RowsChange('FilterReportRespiratory');">
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
                                            <div class="report-tools">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div class="report-export-wrapper">
                                                                <asp:DropDownList ID="ddlRespiratoryExportTo" runat="server" 
                                                                    CssClass="custom-export-drop-down" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlRespiratoryExportTo_SelectedIndexChanged1">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                                    <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                                    <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <a href="javascript:void(0)" class="custom-export-icon">
                                                                    <img src="../../Images/exportIconLeft.gif" style="border-style:None;height:16px;width:16px;">
                                                                    <span style="width:5px;text-decoration:none;"> </span>
                                                                    <img src="../../Images/exportIconRight.gif" style="border-style:None;height:6px;width:7px;margin-bottom:5px;">
                                                                </a>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="printReport('ReportContainerRespiratory');"><img src="../../Images/print.png" /></a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-tool-icon" onclick="FilterReportRespiratory(0,true);"><img src="../../Images/ReportRefresh.gif" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--<div class="report-edit-wrapper" onclick="ReportEdit();">
                                                <span class="spanedit">Edit</span>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="WidgetReportContent">
                                    <div style="width: 100%; float:left;">
                                        <div id="ReportContainerRespiratory">
                                            <div class="ReportGrid">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>
                                                                Date
                                                            </th>
                                                            <th>
                                                                Time In
                                                            </th>
                                                            <th>
                                                                Respiratory
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="vitalRespiratoryList">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divWeightContainer" class="vital-report-sub" style="display:none;">
                        <h3 id="hWeight" class="h-container">Weight</h3>
                        <div id="divGraphWeight" class="graph-container"></div>
                        <div id="divTableWeight" class="table-container">
                            <div class="WidgetReport">
                                <div>
                                    <div id="pagingWeightReportDiv">
                                        <div class="pagerReport">
                                            <div class="PageEntries">
                                                <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                                                    <select id="ddlPagingWeight" style="margin-top: 5px;" onchange="RowsChange('FilterReportWeight');">
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
                                            <div class="report-tools">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div class="report-export-wrapper">
                                                                <asp:DropDownList ID="ddlWeightExportTo" runat="server" 
                                                                    CssClass="custom-export-drop-down" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlWeightExportTo_SelectedIndexChanged1">
                                                                    <asp:ListItem></asp:ListItem>
                                                                    <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                                    <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                                    <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <a href="javascript:void(0)" class="custom-export-icon">
                                                                    <img src="../../Images/exportIconLeft.gif" style="border-style:None;height:16px;width:16px;">
                                                                    <span style="width:5px;text-decoration:none;"> </span>
                                                                    <img src="../../Images/exportIconRight.gif" style="border-style:None;height:6px;width:7px;margin-bottom:5px;">
                                                                </a>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="printReport('ReportContainerWeight');"><img src="../../Images/print.png" /></a>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0)" class="report-tool-icon" onclick="FilterReportWeight(0,true);"><img src="../../Images/ReportRefresh.gif" /></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <%--<div class="report-edit-wrapper" onclick="ReportEdit();">
                                                <span class="spanedit">Edit</span>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="WidgetReportContent">
                                    <div style="width: 100%; float:left;">
                                        <div id="ReportContainerWeight">
                                            <div class="ReportGrid">
                                                <table>
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>
                                                                Date
                                                            </th>
                                                            <th>
                                                                Time In
                                                            </th>
                                                            <th>
                                                                Weight (kg)
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="vitalWeightList">
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
                <div>&nbsp;</div>
            </div>
        </div>
    </div>
</asp:Content>


