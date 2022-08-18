var _SortBy = '';
var _SortByValue = '';

var _CPTCode = "";
var _arrSelectedColumn;
var UserNameIds = "";
var _divMultipleDropdownCheckboxList;
var _ReportTypeName = "";
/*added By faiza Bilal 3 - 24 - 2022*/
var TimeSpanCPT = "";
var TimeSpanClaimAndSum = "";
var TimeSpanLocWise = "";
var TimeSpanPaySummary = "";
var TimeSpanUnpostedPay = "";
var DateFromCPT = "";
var DateToCPT = "";
var DateFromClaimAndSum = "";
var DateToClaimAndSum = "";
var DateFromLocWise = "";
var DateToLocWise = "";
var DateFromPaySummary = "";
var DateToPaySummary = "";
var DateFromUnpostedPay = "";
var DateToUnpostedPay = "";
var params = "";

/*End added By faiza Bilal 3 - 24 - 2022*/
function SelectedTaskStatusText() {
    var TaskStatus = "";

    if ($(".task-status-report :checkbox").length == $(".task-status-report :checkbox:checked").length) {
        TaskStatus = "All";
    }
    else {
        $("[id$='divReportTaskStatus'] :checkbox").not(":eq(0)").each(function () {
            if ($(this).is(":checked")) {
                TaskStatus += $(this).closest("span").find("label").html().trim() + ",";
            }
        });

        if (TaskStatus.length > 0) {
            TaskStatus = TaskStatus.slice(0, -1);
        }
    }

    return TaskStatus;
}

function hideShowMenu(divMultipleDropdownCheckboxList) {
    _divMultipleDropdownCheckboxList = divMultipleDropdownCheckboxList;
    debugger;
    if (divMultipleDropdownCheckboxList == "divReportUnpaidinsurances") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //rizwan

        // $("#divReportServiceProvider").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }


    else if (divMultipleDropdownCheckboxList == "divServiceProvider") {
        debugger;
        var FirstCheckBoxName = "";
        var FirstProviderId = "";
        var ProviderId = "";
        var count = 0;

        $(".rpt_li").each(function () {
            debugger;
            var CheckBoxName = $(this).find('.checkBoxName').text();
            FirstProviderId = $(this).find(".hdnProviderIds").val();
            if (FirstCheckBoxName == CheckBoxName) {

                $(this).prev().hide();
                ProviderId += FirstProviderId + ",";
                count++;
            }
            else {
                FirstCheckBoxName = CheckBoxName;
                ProviderId = FirstProviderId + ",";
            }
            if (count != 0) {
                $(this).find(".ProviderId").val(ProviderId);
                count = 0;
            }



        });



        if ($("#" + divMultipleDropdownCheckboxList).is(':visible')) {
            $("#" + divMultipleDropdownCheckboxList).hide();
        }
        else {
            $("#" + divMultipleDropdownCheckboxList).show();
        }
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportClaimStatus").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPracticeLocation").hide();
    }


    // $("#" + divMultipleDropdownCheckboxList).slideToggle();// commented out by qaseem

    //Code added by Qaseem till #END.
    //Purpose: To avoid the overlapping of the dropdown list at a time. Resolving bug#: 5164
    else if (divMultipleDropdownCheckboxList == "divReportAgencyBranches") {// when branch name drop down is clicked

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open

        $("#divReportServiceProvider").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }


    else if (divMultipleDropdownCheckboxList == "divReportPatient") {// when branch name drop down is clicked

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open

        $("#divReportServiceProvider").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divReportAdmissionStatus") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divReportMonths").hide();
    }
    /************added by shahid kazmi 4/6/2017 for Admission Status dropdownlist***********/
    else if (divMultipleDropdownCheckboxList == "divReportEmployee") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divReportMonths").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divReportAuthorizationStatus") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }

    else if (divMultipleDropdownCheckboxList == "divInsurance") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divReportInsurance") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }
    /*************end shahid kazmi 4/6/2017******************/
    else if (divMultipleDropdownCheckboxList == "divReportServiceProvider") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
        //$("#divPayerScenario").hide();
        $("#divPracticeLocation").hide();

    } else if (divMultipleDropdownCheckboxList == "divReportPatientDetail") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();

    }
    else if (divMultipleDropdownCheckboxList == "divReportCaseManager") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();

    }
    else if (divMultipleDropdownCheckboxList == "divReportTaskStatus") {

        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divReportMonths").hide();
    }
    /*change added by amin ahmed dated 03/22/2017*/
    else if (divMultipleDropdownCheckboxList == "divReportAgencyInsurance") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportServiceProvider").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divReportMonths") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
    }

    else if (divMultipleDropdownCheckboxList == "divReportPatient") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divPracticeLocation") {
        if ($("#" + divMultipleDropdownCheckboxList).is(':visible')) {
            $("#" + divMultipleDropdownCheckboxList).hide();
        }
        else {
            $("#" + divMultipleDropdownCheckboxList).css("display", "");
        }
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        // Added by Asad Mehmood
        $('#divPlaceOfService').hide();
        $('#divPayerScenario1').hide();
        $('#divCalimStatus').hide();
        $('#divFileStatus').hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        // $("#divPayerScenario").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divPayerScenario") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divBilledAs1").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPracticeLocation").hide();
    }

    else if (divMultipleDropdownCheckboxList == "divCalimStatus") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPracticeLocation").hide();
        //Added By Asad Mehmood
        $('#divPracticeLocation').hide();
        $('#divPlaceOfService').hide();
        $('#divPayerScenario1').hide();
        $('#divFileStatus').hide();
    }
    else if (divMultipleDropdownCheckboxList == "divFileStatus") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPracticeLocation").hide();
        //Added By Asad Mehmood
        $('#divPracticeLocation').hide();
        $('#divPlaceOfService').hide();
        $('#divPayerScenario1').hide();
        $('#divCalimStatus').hide();
    }
    else if (divMultipleDropdownCheckboxList == "divPatientName") {
        $("#" + divMultipleDropdownCheckboxList).show();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPracticeLocation").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divDenailPayerName") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPracticeLocation").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divAdjustmentCode") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPracticeLocation").hide();
    }

    else if (divMultipleDropdownCheckboxList == "divPlaceOfService") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPayerScenario").hide();
        $("#divPracticeLocation").hide();
        //Added by Asad Mehmood
        //$('#divPracticeLocation').hide();
        $('#divPayerScenario1').hide();
        $('#divCalimStatus').hide();
        $('#divFileStatus').hide();
    }


    else if (divMultipleDropdownCheckboxList == "divBilledAs1") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divCalimStatus").hide();
        //$("#divReportServiceProvider").hide();
        $("#divDenailPayerName").hide();
        $("#divPayerScenario").hide();
        $("#divPracticeLocation").hide();
    }

    //#END
}


function putSelectedColumnsInArray(ParentDiv) {
    _arrSelectedColumn = new Array();

    $("[id$='ddlSortBy']").html("");

    $("#" + ParentDiv + " input[type='checkbox']:checked").each(function () {
        _arrSelectedColumn.push($.trim($(this).next().text()));

        $("[id$='ddlSortBy']").append($('<option></option>').val($.trim($(this).next().text())).html($.trim($(this).next().text())));
    });
}

function CancelEditReport(ParentDiv) {

    $("#" + ParentDiv + " input[type='checkbox']").each(function () {
        if ($.inArray($.trim($(this).next().text()), _arrSelectedColumn) != -1) {
            $(this).prop("checked", true);
        }
        else {
            $(this).prop("checked", false);
        }
    });
}


function SetHtml(container, htmlWrapper, inputField) {

    var html = $("#" + container).find("." + htmlWrapper).html();
    html = $.trim(html);
    html = html.replace(/>/g, '&gt;');
    html = html.replace(/</g, '&lt;');
    $("input[id$='" + inputField + "']").attr('value', html);

    return true;
}

function SortReportList(elem, sortBy) {

    _SortBy = sortBy;
    var filterValue = $(elem).attr("class");

    if (filterValue == "asc" || filterValue == "") {
        filterValue = "desc";
        $(elem).find("span:last").removeClass("asc").addClass("desc");
    }
    else {
        filterValue = "asc";
        $(elem).find("span:last").removeClass("desc").addClass("asc");
    }

    $(elem).attr("class", filterValue);

    _SortByValue = filterValue.toUpperCase();
    var sortValue = _SortBy + " " + _SortByValue;
    RowsChange(0, sortValue);
}


function PrintReport(divToPrint) {

    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body></html>";
    var newstr = $("[id$='" + divToPrint + "']").html();

    var popupWin = window.open('', '_blank');
    popupWin.document.write(headstr + newstr + footstr);
    popupWin.print();
    return false;
}
var DateFrom = "";
var DateTo = "";
/*************ADDED BY SHAHID KAZMI 11/17/2017*********/
function OpenPatientFilterDialog(ReportTypeName, ReportType, _ReportFilterCount, TabFilename) {
    _ReportTypeName = ReportTypeName;

    if (ReportTypeName == "PatientBalanceSummaryReport") {

        $("[id='txtDOB']").prop("disabled", false);
    }

    $.post("filter/FilterDialoguePatients.aspx", { ReportTypeName: ReportTypeName }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $(".report-criteria-box .editable-container").html("");

        $("[id$='divDialogReportFilters_Unique']").html(returnHtml)

            .promise()
            .done(function () {
                //Report_InitializeDatesBoxes();

                $("[id$='divDialogReportFilters_Unique']").dialog({
                    title: "Report Criteria",
                    modal: true,
                    width: "720",

                    buttons: {
                        "OK": function () {

                            if ($("#rbReportTimeSpanSpecificDates").prop("checked")) {

                                var flag = false;
                                $(".required").each(function () {
                                    if (!$(this).val()) { flag = true; }
                                });

                                if (flag) {
                                    if ($("[id$='ReportDateFrom']").val() == "") {
                                        $("[id$='ReportDateFrom']").css("border", "1px solid red");
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }
                                    else if ($("[id$='ReportDateTo']").val() == "") {
                                        $("[id$='ReportDateTo']").css("border", "1px solid red");
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }
                                    else if ($("[id$='ReportDateFrom']").val() == "" && $("[id$='ReportDateTo']").val() == "") {
                                        $(".required").css({ "border": "1px solid red" });
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }

                                }
                            }
                            var DateType = "";
                            $('.ddlPostType').each(function () {
                                {
                                    DateType = $("option:selected", this).val();
                                }
                            });
                            if (ReportTypeName == "PatientSummaryReport" && DateType == "PostDate") {
                                if (DateType != "0") {
                                    if ($("[id$='BillDateFrom']").val() == "") {
                                        $("[id$='BillDateFrom']").css("border", "1px solid red");
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }
                                    if ($("[id$='BillDateTo']").val() == "") {
                                        $("[id$='BillDateTo']").css("border", "1px solid red");
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }
                                }
                            }


                            if (ReportTypeName == "PatientBalanceDetailReport" || ReportTypeName == "PatientDetails" || ReportTypeName == "AdjustmentsDetailReport" || ReportTypeName == "AdjustmentsSummaryReport" || ReportTypeName == "ItemizationOfChargesReport" || ReportTypeName == "PD" || ReportTypeName == "ChargesSummaryReport" || ReportTypeName == "ChargesDetailReport") {


                                if ($("#TxtPatientSearch").val() == "" || $("#hdnsearchpatientid").val() == "") {
                                    $("#TxtPatientSearch").css("border", "1px solid red");
                                    showErrorMessageReport("Please select Patient.")
                                    return;
                                }
                            }



                            var CustomDate = "";
                            $('.ddlDate').each(function () {
                                {
                                    CustomDate = $("option:selected", this).val();
                                }
                            });
                            if (ReportTypeName == "PatientBalanceDetailReport") {
                                if (CustomDate == "Custom") {
                                    if ($("[id$='txtDOB']").val() == "") {
                                        $("[id$='txtDOB']").css("border", "1px solid red");
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }
                                }
                            }


                            OkPatientFilter(ReportTypeName, ReportType, _ReportFilterCount, TabFilename);
                            $(this).dialog("close");

                        },
                        "Cancel": function () {
                            $(this).dialog("close");
                        }
                    },
                    close: function () {
                        $(this).dialog("close");
                    }
                });
            });
    });
}
function EnableDisableDates(elem) {
    debugger
    //$(elem).parents(".SearchCriteria").find("#FilterReports").prop("disabled", false);
    var a = $(elem).find("#ddlPostType").val();
    var b = $(elem).find("#ddlPostTypeCustomize").val();
    if (a == "" || a == undefined) {
        $("[id$='ddlPostType']").val(b);
        $("[id$='ddlPostTypeCustomize']").val(b);
    }
    else {
        $("[id$='ddlPostType']").val(a);
        $("[id$='ddlPostTypeCustomize']").val(a);
    }
    var DateType = ""
    var Date = $("#ddlDate option:selected").val()
    $('.ddlPostType').each(function () {
        {
            DateType = $("option:selected", this).val();
        }
    });
    var Actuvity = "";
    $('.ddlActuvity').each(function () {
        {
            Actuvity = $("option:selected", this).val();
        }
    });
    if (DateType != "0") {
        $("[id='BillDateFrom']").prop("disabled", false);
        $("[id$='BillDateTo']").prop("disabled", false);
    }

    var postdate = $("[id=ddlPostType]").val();

    //if (postdate != "") {

    //    $("[id='BillDateFrom']").prop("disabled", false);
    //    $("[id$='BillDateTo']").prop("disabled", false);

    //    $("[id$='txtDOB']").prop("disabled", false);
    //    $("[id$='DateTo']").prop("disabled", false);

    //}

    //else {
    //    $("[id='BillDateFrom']").prop("disabled", true);
    //    $("[id$='BillDateTo']").prop("disabled", true);
    //    $("[id$='txtDOB']").prop("disabled", true);

    //}
    var DOB = $("#txtDOB").val();
    var CustomDate = "";
    $('.ddlDate').each(function () {
        {
            CustomDate = $("option:selected", this).val();
        }
    });
    if (CustomDate == "Custom") {

        $("[id='txtDOB']").prop("disabled", false);
        $("[id$='DateTo']").prop("disabled", false);

    }
    else {

        $("[id='txtDOB']").prop("disabled", true);

    }

    if (Actuvity != "") {


        $("[id$='txtDOB1']").prop("disabled", true);
        $("[id$='txtDOB1']").val(" ");
    }
    if (Actuvity == "0") {
        $("[id='txtDOB1']").prop("disabled", false);
    }
    if (Date == "Today") {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd
        }
        if (mm < 10) {
            mm = '0' + mm
        }

        today = yyyy + '-' + mm + '-' + dd;
        $('#txtDOB').val(today);
        $('#DateTo').val(today);


    }
    else if (Date == "Yesterday") {
        debugger

        $('#DateTo').val(yesterdayDate);

        $('#txtDOB').val(yesterdayDate);
    }

}
function OkPatientFilter(ReportTypeName, ReportType, _ReportFilterCount) {
    debugger
    var PracticeId = $("[id$='hdnPracticeId']").val();
    var PatientIds = "";
    var AdjustmentCode = "";



    $('.ddlPatientList').each(function () {
        {
            PatientIds = $("option:selected", this).val();
        }
    });
    var TimeSpan = $("#divReportTimeSpan :radio:checked").closest("span").attr("class");
    var d = new Date();

    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    var lastMonth = d.getMonth();
    var lastDay = new Date(year, month - 1, 0).getDate();
    var day = d.getDate();
    if (TimeSpan == "Beginning") {
        var DateFrom = '';
        var DateTo = '';
    }
    else if (TimeSpan == "YearToDate") {
        var DateFrom = '01/01/' + year;
        var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
    }
    else if (TimeSpan == "LastMonth") {

        if (month == "1") {
            year = d.getFullYear() - 1;
            lastDay = new Date(year, month - 1, 0).getDate();
            month = d.getMonth() + 1;
            if (lastMonth == "0") {
                lastMonth = "12";
            }
        }

        var DateFrom = (lastMonth < 10 ? '0' : '') + lastMonth + '/' + '01/' + year;
        var DateTo = (lastMonth < 10 ? '0' : '') + lastMonth + '/' + (lastDay < 10 ? '0' : '') + lastDay + '/' + year;




    }
    else if (TimeSpan == "MonthToDate") {
        var DateFrom = (month < 10 ? '0' : '') + month + '/' + '01/' + year;
        var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
    }
    else if (TimeSpan == "SpecificDates") {
        var DateFrom = $("[id$='ReportDateFrom']").val();
        var DateTo = $("[id$='ReportDateTo']").val();
    }
    else if (ReportTypeName == "PDR") {
        var DateFrom = $("[id$='ReportDateFrom']").val();
    }
    var DateType = "";
    var ProviderId = "";
    var PracticeLocationId = "";
    var PayerId = "";

    $('.ddlPostType').each(function () {
        {

            DateType = $("option:selected", this).val();
        }
    });
    if (DateType == "0") {
        DateType = "";
    }
    debugger;
    $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if ($("[id$='chkServiceProviderAll']").is(':checked')) {
        ProviderId = '';
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    debugger
    $("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });//chkPracticeLocationAll
    if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
        PracticeLocationId = '';
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });

    if ($("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }


    //Jump

    $("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if (AdjustmentCode.length > 0) {
        AdjustmentCode = AdjustmentCode.slice(0, -1);
    }
    if ($("[id$='chkAdjustmentCodeAll']").is(':checked')) {
        AdjustmentCode = '';
    }

    var Patientid = "";
    $("[id$='ulMultiPatientName'] .chk-multi-checkboxes").each(function () {

        if ($(this).is(":checked")) {
            Patientid += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if (Patientid.length > 0) {
        Patientid = Patientid.slice(0, -1);

        var myString = Patientid;
        var avoid = "Undifiend";

        PatientIds = myString.replace(avoid, '');
    }



    var Actuvity = "";
    var Gender = "";
    var CustomDate = "";

    $('.ddlActuvity').each(function () {
        {
            Actuvity = $("option:selected", this).val();
        }
    });
    if (Actuvity == "0") {
        Actuvity = "";
    }


    $('.ddlGender').each(function () {
        {
            Gender = $("option:selected", this).val();
        }
    });
    if (Gender == "0") {
        Gender = "";
    }
    var DiagnosisCode = $("#txtIcdCode1").val();
    var ProcedureCode = $("#txtCPTCode").val();

    var DOB = $("#txtDOB").val();
    $('.ddlDate').each(function () {
        {
            CustomDate = $("option:selected", this).val();
        }
    });
    if (CustomDate == "CustomeDate") {

        $("[id='txtDOB']").prop("disabled", false);
    }

    if (CustomDate == "0") {
        CustomDate = "";
    }

    var AssignedTo = "";
    $('.ddlAssignedTo').each(function () {
        {
            AssignedTo = $("option:selected", this).val();
        }
    });
    var AsOf = DOB;





    if (ReportTypeName == "AS") {


        if (DateType != "") {

            if ($("[id$='BillDateFrom']").val() == "") {
                $("[id$='BillDateFrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }

            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "AdjustmentsSummaryReport.aspx?PracticeId=" + PracticeId + "&PatientIds=" + SearchedPatientId + "&ProcedureCode=" + ProcedureCode + "&DateType=" + DateType + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&AdjustmentCode=" + AdjustmentCode + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }
    if (ReportTypeName == "CS") {

        if (DateType != "") {

            if ($("[id$='BillDateFrom']").val() == "") {
                $("[id$='BillDateFrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "ChargesSummaryReport.aspx?PracticeId=" + PracticeId + "&PatientIds=" + SearchedPatientId + "&ProcedureCode=" + ProcedureCode + "&DateType=" + DateType + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }

    //
    if (ReportTypeName == "AdjustmentsSummaryReport") {
        var filename = ReportTypeName + ".aspx";
        if (DateType != "") {

            if ($("[id$='BillDateFrom']").val() == "") {
                $("[id$='BillDateFrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }

            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();

        var prams =
        {
            PatientIds: SearchedPatientId,
            ProcedureCode: ProcedureCode,
            DateType: DateType,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            PayerId: PayerId,
            AdjustmentCode: AdjustmentCode,
            TimeSpan: TimeSpan,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo

        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);

    }
    //
    if (ReportTypeName == "PatientContactList") {

        var filename = ReportTypeName + ".aspx";

        var TimeSpan = "";
        if ($("[id$='txtDOB1']").val() != "") {


            TimeSpan = $("[id$='txtDOB1']").val();
        }
        else {
            if (Actuvity == "") {
                TimeSpan = "All Records";
            }
            else {
                TimeSpan = Actuvity;

            }

        }
        var DOB = $("[id$='txtDOB1']").val();
        var prams =
        {
            Actuvity: Actuvity,
            ProviderId: ProviderId,
            DiagnosisCode: DiagnosisCode,
            ProcedureCode: ProcedureCode,
            Gender: Gender,
            PayerId: PayerId,
            DOB: DOB,
            TimeSpan: TimeSpan
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);

    }




    var AsOf = DOB;




    ///Start****/////
    if (ReportTypeName == "PatientDetails") {

        var filename = ReportTypeName + ".aspx";
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        var prams =
        {
            PatientIds: SearchedPatientId
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);


    }


    if (ReportTypeName == "PatientSummaryReport") {

        var filename = ReportTypeName + ".aspx";
        if (DateType != "") {

            if ($("[id$='BillDateFrom']").val() == "") {
                $("[id$='BillDateFrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }

        var NewTimeSpan = "HasDate";

        if (DateType != "0") {
            NewTimeSpan = "All";;
        }
        var prams =
        {
            DateType: DateType,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            PayerId: PayerId,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo,
            NewTimeSpan: NewTimeSpan
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);


    }

    if (ReportTypeName == "ChargesSummaryReport") {

        var filename = ReportTypeName + ".aspx";
        if (DateType != "") {

            if ($("[id$='BillDateFrom']").val() == "") {
                $("[id$='BillDateFrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDateFrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        var prams =
        {
            PatientIds: SearchedPatientId,
            ProcedureCode: ProcedureCode,
            DateType: DateType,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            PayerId: PayerId,
            TimeSpan: TimeSpan,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo

        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);


    }

    if (ReportTypeName == "PatientBalanceDetailReport") {

        var filename = ReportTypeName + ".aspx";
        if (CustomDate == "Custom") {

            if ($("[id$='txtDOB']").val() == "") {
                $("[id$='txtDOB']").css("border", "1px solid red");
                showErrorMessageReport("Please select date.")
                return;
            }
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        var prams =
        {
            PatientIds: SearchedPatientId,
            ProcedureCode: ProcedureCode,
            CustomDate: CustomDate,
            AsOf: AsOf
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        ////

    }

    if (ReportTypeName == "ChargesDetailReport") {

        var filename = ReportTypeName + ".aspx";
        if (DateType != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        var prams =
        {
            PatientIds: SearchedPatientId,
            ProcedureCode: ProcedureCode,
            DateType: DateType,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            PayerId: PayerId,
            TimeSpan: TimeSpan,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo

        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        ////

    }

    if (ReportTypeName == "SettledChargesSummaryReport") {

        var filename = ReportTypeName + ".aspx";
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientIds = '';
        }
        var prams =
        {
            PatientIds: PatientIds,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            ProcedureCode: ProcedureCode,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);


    }
    if (ReportTypeName == "PatientBalanceSummaryReport") {

        var filename = ReportTypeName + ".aspx";
        if (CustomDate == "Custom") {

            if ($("[id$='txtDOB']").val() == "") {
                $("[id$='txtDOB']").css("border", "1px solid red");
                showErrorMessageReport("Please select date.")
                return;
            }
        }
        var prams =
        {
            AssignedTo: AssignedTo,
            CustomDate: CustomDate,
            AsOf: AsOf,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }


    if (ReportTypeName == "PatientTransactionsSummaryReport") {

        var filename = ReportTypeName + ".aspx";
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "ItemizationOfChargesReport") {

        var filename = ReportTypeName + ".aspx";
        if (CustomDate == "Custom") {

            if ($("[id$='txtDOB']").val() == "") {
                $("[id$='txtDOB']").css("border", "1px solid red");
                showErrorMessageReport("Please select date.")
                return;
            }
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        var prams =
        {
            PatientId: SearchedPatientId,
            ProviderId: ProviderId,
            CustomDate: CustomDate,
            AsOf: AsOf,
            DateType: DateType,
            PayerId: PayerId
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //  //

    }
    if (ReportTypeName == "AdjustmentsDetailReport") {

        var filename = ReportTypeName + ".aspx";

        if (DateType != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }

        var SearchedPatientId = $("#hdnsearchpatientid").val();
        var prams =
        {
            PatientIds: SearchedPatientId,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            ProcedureCode: ProcedureCode,
            DateType: DateType,
            PayerId: PayerId,
            AdjustmentCode: AdjustmentCode,
            TimeSpan: TimeSpan,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        ////

    }





    ///*////////////*////////

}
function OpenPaymentsFilterDialog(ReportTypeName, ReportType, _ReportFilterCount, TabFilename) {
    debugger;
    $.post("filter/FilterDialoguePayments.aspx", { ReportTypeName: ReportTypeName }, function (data) {
        debugger;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $(".report-criteria-box .editable-container").html("");
        $("[id$='divDialogReportFilters_Unique']").html(returnHtml)
            // $("[id$='divDialogReportFilters']").html(returnHtml)
            .promise()
            .done(function () {
                //Report_InitializeDatesBoxes();

                if (ReportTypeName == "TPDAS" || ReportTypeName == "RDC") {
                    $("#Dateslbl").html("");
                    $("#Dateslbl").text("Dates");
                }
                if (ReportTypeName == "ReportMonthlyReconciliation") {


                    $("[id$='ddlMonthlyReconciliationProvider']").prop("disabled", "disabled");

                    $("[id$='ddlMonthlyReconciliationProvider']").css("background", "#f7f6f6");

                    $("[id$='ddlProviderType']").prop("disabled", "disabled");
                    $("[id$='ddlProviderType']").css("background", "#f7f6f6");
                }
                OkPaymentsFilter(ReportTypeName, ReportType, _ReportFilterCount, TabFilename);
                //            });
                //    });
                //}
                $("[id$='divDialogReportFilters_Unique']").dialog({
                    title: "Report Criteria",
                    modal: true,
                    width: "720",
                    height: "auto",
                    buttons: {

                        "OK": function () {
                            debugger
                            $("#ReportFilterId").css("display", "block");
                            $(".report-export, .Reports_Rows_Per_Page, .PageButton").show();
                            var postDate = "";
                            postDate = $("#" + SubReportDivName).find("#ddlPostType").val();
                            if ($("#rbReportTimeSpanSpecificDates").prop("checked")) {

                                var flag = false;
                                $(".required").each(function () {

                                    if (!$(this).val()) { flag = true; }
                                });

                                if (flag) {
                                    if ($("[id$='ReportDateFrom']").val() == "" || $("[id$='ReportDateTo']").val() == "") {
                                        $("[id$='ReportDateFrom']").css("border", "1px solid red");
                                        $("[id$='ReportDateTo']").css("border", "1px solid red");
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }


                                    else if ($("[id$='ReportDateTo']").val() == "") {
                                        $("[id$='ReportDateTo']").css("border", "1px solid red");
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }
                                    else if ($("[id$='ReportDateFrom']").val() == "" && $("[id$='ReportDateTo']").val() == "") {
                                        $(".required").css({ "border": "1px solid red" });
                                        showErrorMessageReport("Please select From and To date.")
                                        return;
                                    }
                                    else {
                                        postDate = "";
                                    }

                                }

                            }

                            if ($(".divTimeSpan").is(":visible")) {
                                $(".radio_li").each(function () {

                                    debugger
                                    var a = $(this).find("input[type='radio']").val();
                                    if ($(this).find("input[type='radio']").is(":checked")) {

                                        postDate = "";
                                    }
                                });
                            }

                            //jump3
                            if (ReportTypeName == "UnpostedPaymentsDetailandSummary") {

                            }
                            if (ReportTypeName == "ProcedurePaymentsSummaryAndDetail") {
                                debugger;
                                var cptcodes = "";
                                $('.spnservicecode').each(function () {
                                    cptcodes = cptcodes + ',' + $(this).text();
                                });
                                cptcodes = cptcodes.substring(1, cptcodes.length);


                                if (_NewInsuranceIds.split(',').length != 0) {


                                    if (cptcodes.split(',').length == 1 && cptcodes != "") {

                                    }
                                    else {
                                        if (cptcodes.split(',').length < 1) {
                                            $("[id$='MultipleInsurancesTxt']").css("border", "1px solid red");
                                            showErrorMessage("Please select atleast one insurance!");
                                            return;
                                        }
                                        //else {
                                        //    $("[id$='txtServiceCode']").css("border", "1px solid red");
                                        //    showErrorMessage("Please select atleast one CPT code!");
                                        //    return;
                                        //}

                                    }
                                }
                            }


                            if (postDate != "") {

                                if ($("[id$='BillDatefrom']").val() == "" || $("[id$='BillDateTo']").val() == "") {
                                    $("[id$='BillDatefrom']").css("border", "1px solid red");
                                    $("[id$='BillDateTo']").css("border", "1px solid red");
                                    showErrorMessageReport("Please select From and To date.")
                                    return;
                                }


                            }

                            if (ReportTypeName == "InsuranceCollectionDetailReport" || ReportTypeName == "InsuranceCollectionSummaryReport" || ReportTypeName == "PatientCollectionSummary" || ReportTypeName == "PatientCollectionDetail") {
                                if ($("[id$='txtAgingDate']").val() == "") {
                                    $("[id$='txtAgingDate']").css("border", "1px solid red");
                                    showErrorMessageReport("Please select From and To date.")
                                    return;
                                }
                            }
                            if (ReportTypeName == "UnpaidInsuranceClaimsReport") {
                                if ($("[id$='BillDatefrom']").val() == "" || $("[id$='BillDateTo']").val() == "") {
                                    $("[id$='BillDatefrom']").css("border", "1px solid red");
                                    $("[id$='BillDateTo']").css("border", "1px solid red");
                                    showErrorMessageReport("Please select From and To date.")
                                    return;
                                }
                            }
                            if (ReportTypeName == "ThirtyPlusDaysAfterSubmission") {
                                var ddlPostType = $("#" + SubReportDivName).find("#ddlPostType").val()
                                if (ddlPostType != "") {
                                    var DOSFrom = $("#BillDatefrom").val();
                                    var DOSTo = $("#BillDateTo ").val();
                                    if (DOSFrom == "" || DOSTo == "") {
                                        $("#BillDatefrom").css("border", "1px solid red");
                                        $("#BillDateTo").css("border", "1px solid red");
                                        return;
                                    }
                                }
                            }
                            if (ReportTypeName == "ContractManagementSummaryReport" || ReportTypeName == "ContractManagementDetailReport") {
                                var ddlPostType = $("#" + SubReportDivName).find("#ddlPostType").val()
                                if (ddlPostType != "") {
                                    var DOSFrom = $("#BillDatefrom").val();
                                    var DOSTo = $("#BillDateTo ").val();
                                    if (DOSFrom == "" || DOSTo == "") {
                                        $("#BillDatefrom").css("border", "1px solid red");
                                        $("#BillDateTo").css("border", "1px solid red");
                                        return;
                                    }
                                }
                            }
                            if (ReportTypeName == "ReadyForSubmissionClaimsDetail") {
                                var ddlDateType = $("#ddlDateType").val()
                                if (ddlDateType == "DOS") {
                                    var DOSFrom = $(".RFSDOSFrom").val();
                                    var DOSTo = $(".RFSDOSTo ").val();
                                    if (DOSFrom == "" || DOSTo == "") {
                                        $(".RFSDOS").css("border", "1px solid red");
                                        $(".RFSPostDate").css("border", "1px solid #c4c4c4");
                                        return;
                                    }
                                }
                                if (ddlDateType == "PostDate") {
                                    var RFSPostDateFrom = $(".RFSPostDateFrom ").val();
                                    var RFSPostDateTo = $(".RFSPostDateTo").val();
                                    if (RFSPostDateFrom == "" || RFSPostDateTo == "") {
                                        $(".RFSPostDate").css("border", "1px solid red");
                                        $(".RFSDOS").css("border", "1px solid #c4c4c4");
                                        return;
                                    }
                                }
                            }
                            debugger;
                            OkPaymentsFilter(ReportTypeName, ReportType, _ReportFilterCount, TabFilename);

                            $(this).dialog("close");

                        },
                        "Cancel": function () {


                            $("[id$='divDialogReportFilters_Unique']").dialog("close");
                        }
                    },
                    close: function () {
                        var ReportName = $(".reportType").text();
                        if (ReportName == "") {
                            $("#ReportFilterId").css("display", "none");
                            $(".report-export, .Reports_Rows_Per_Page, .PageButton").css("display", "none");
                        }
                        $("[id$='divDialogReportFilters_Unique']").dialog("close");
                    }
                });
            });
    });

}

function OkPaymentsFilter(ReportTypeName, ReportType, _ReportFilterCount, TabFilename) {
    debugger;
    $(".InitialMsg").css("display", "none");
    var PracticeId = $("[id$='hdnPracticeId']").val();
    var InsuranceId = "";
    var InsuranceName = "";
    $('.ddlInsuranceList').each(function () {
        {

            InsuranceId = $("option:selected", this).val();
            InsuranceName = $("option:selected", this).text();
        }
    });
    var payerName = "";
    var checkNumber = "";
    var postDate = "";
    var unpaidInsurance = "";
    $('.ddlPayerName').each(function () {
        {
            payerName = $("option:selected", this).val();
        }
    });
    $('.ddlCheckNumber').each(function () {
        {
            checkNumber = $("option:selected", this).val();
        }
    });


    //
    $("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").each(function () {

        if ($(this).is(":checked")) {
            unpaidInsurance += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });

    if ($("[id$='chkUnpaidinsurancesAll']").is(':checked')) {

        unpaidInsurance = '';
    }
    if (unpaidInsurance.length > 0) {
        unpaidInsurance = unpaidInsurance.slice(0, -1);
    }

    //


    postDate = $("#" + SubReportDivName).find("#ddlPostType").val();
    var TimeSpan = "";
    //TimeSpan = $("#divReportTimeSpan :radio:checked").closest("span").attr("class");

    var TimeSpan = $(".radio_li :radio:checked").closest("span").attr("class");

    var d = new Date();

    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    var lastMonth = d.getMonth();
    var lastDay = new Date(year, month - 1, 0).getDate();
    var day = d.getDate();
    if (TimeSpan == "Today") {
        var Td = new Date();
        var month = Td.getMonth() + 1;
        var day = Td.getDate();
        //(('' + day).length < 2 ? '0' : '') + day +
        DateFrom = (('' + month).length < 2 ? '0' : '') + month + '/' + (('' + day).length < 2 ? '0' : '') + day + '/' + Td.getFullYear();

        DateTo = (('' + month).length < 2 ? '0' : '') + month + '/' + (('' + day).length < 2 ? '0' : '') + day + '/' + Td.getFullYear();
    }
    else if (TimeSpan == "Beginning") {
        DateFrom = '';
        DateTo = '';
    }
    else if (TimeSpan == "YearToDate") {

        DateFrom = '01/01/' + year;
        DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
    }
    else if (TimeSpan == "LastMonth") {


        if (month == "1") {
            year = d.getFullYear() - 1;
            lastDay = new Date(year, month - 1, 0).getDate();
            month = d.getMonth() + 1;
            if (lastMonth == "0") {
                lastMonth = "12";
            }
        }
        DateFrom = (lastMonth < 10 ? '0' : '') + lastMonth + '/' + '01/' + year;
        DateTo = (lastMonth < 10 ? '0' : '') + lastMonth + '/' + (lastDay < 10 ? '0' : '') + lastDay + '/' + year;
    }
    else if (TimeSpan == "MonthToDate") {

        DateFrom = (month < 10 ? '0' : '') + month + '/' + '01/' + year;
        DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
    }
    else if (TimeSpan == "SpecificDates" || TimeSpan == null) {
        DateFrom = $("[id$='ReportDateFrom']").val();
        DateTo = $("[id$='ReportDateTo']").val();
    }
    else if (ReportTypeName == "PDR") {
        DateFrom = $("[id$='ReportDateFrom']").val();
    }




    var DiagnosisCode = "";
    DiagnosisCode = $("#txtIcdCode1").val();
    var ProcedureCode = "";
    ProcedureCode = $("#txtCPTCode").val();

    var AgingType = "";
    var AgingDate = "";
    var PracticeLocationId = "";
    var ProviderId = "";
    var PayerId = "";
    var ClaimStatus = "";
    var PatientId = "";
    var DateOfService = "";
    var Balance = "";
    var BillDateFrom = $("[id='BillDatefrom']").val();
    var BillDateTo = $("[id$='BillDateTo']").val();
    var Insurance = "";
    var BilledAs = "";

    var DateType = "";
    $('#ddlAgingType').each(function () {
        {
            AgingType = $("option:selected", this).val();
        }
    });
    AgingDate = $("[id$='txtAgingDate']").val();

    $("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if ($("[id$='chkPracticeLocationAll']").is(':checked')) {

        PracticeLocationId = '';
    }

    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    debugger;/*ifraheem*/
    $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {

            ProviderId += $(this).parent().parent().find("input[type='hidden']").val() + ",";
        }
    });
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }

    if ($("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }

    $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus += $(this).parent().find("input[type='hidden']").val() + ",";
        }

    });

    if (ClaimStatus.length > 0) {
        ClaimStatus = ClaimStatus.slice(0, -1);
    }

    if ($("[id$='chkCalimStatusAll']").is(':checked')) {
        ClaimStatus = '';
    }
    $("[id$='ulMultiPatientName'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PatientId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if (PatientId.length > 0) {
        PatientId = PatientId.slice(0, -1);
    }


    $('.ddlBalance').each(function () {
        {
            Balance = $("option:selected", this).val();
        }
    });
    $('.ddlDateOfService').each(function () {
        {
            DateOfService = $("option:selected", this).val();
        }
    });

    //$("[id$='ulMultiDenailPayerName'] .chk-multi-checkboxes").each(function () {

    //    if ($(this).is(":checked")) {

    //        Insurance += $(this).parent().find("input[type='hidden'] ").val() + ",";
    //    }
    //});
    debugger
    //Insurance = $("[id$='ulMultiDenailPayerName']").siblings('.SplitIds').val() || "";


    //if (Insurance.length > 0 && Insurance!="") {
    //    Insurance = Insurance.slice(0, -1);
    //}
    if ($("[id$='chkDenailPayerNameAll']").is(':checked')) {
        Insurance = '';
    }


    /**************/

    var AdjustmentCode = "";
    $("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes").each(function () {

        if ($(this).is(":checked")) {

            AdjustmentCode += $(this).parent().find("input[type='hidden'] ").val() + ",";
        }
    });

    if (AdjustmentCode.length > 0) {
        AdjustmentCode = AdjustmentCode.slice(0, -1);
    }

    if ($("[id$='chkAdjustmentCodeAll']").is(':checked')) {
        AdjustmentCode = '';
    }
    /***********/


    DateType = $("#" + SubReportDivName).find("#ddlPostType").val();

    var PaymentType = "";
    var PaymentMethod = "";
    $('.ddlPaymentType').each(function () {
        {
            PaymentType = $("option:selected", this).val();
        }
    });
    $('.ddlPaymentMethod').each(function () {
        {
            PaymentMethod = $("option:selected", this).val();
        }
    });

    $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            BilledAs += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if (BilledAs.length > 0) {
        BilledAs = BilledAs.slice(0, -1);
    }
    if ($("[id$='chkBilledAsAll']").is(':checked')) {
        BilledAs = '';
    }

    //New Reports Code Start From Here
    ///Start
    if (ReportTypeName == "PaymentsDetailReport") {

        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, TabFilename);
        //

    }
    if (ReportTypeName == "PatientBalanceDueDetail") {

        var filename = ReportTypeName + ".aspx";
        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, TabFilename);
        //

    }

    if (ReportTypeName == "AppointmentsDetailReport") {

        var filename = ReportTypeName + ".aspx";

        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientId = '';
        }
        var AppointmentStatus = $("[id$='ddlAppointmentStatus']").val();
        var AppointmentReasons = $("[id$='ddlAppointmentReasons']").val();
        var PatId = PatientId;

        var prams =
        {
            ProviderId: ProviderId,
            AppointmentStatus: AppointmentStatus,
            AppointmentReasons: AppointmentReasons,
            PracticeLocationId: PracticeLocationId,
            PatId: PatId,
            DateFrom: DateFrom,
            DateTo: DateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "PatientPayments") {

        var filename = ReportTypeName + ".aspx";
        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var Datefrom = $("[id$='BillDatefrom']").val();
            var Dateto = $("[id$='BillDateTo']").val();
        }
        else {
            var Datefrom = $("[id='BillDatefrom']").val();
            var Dateto = $("[id$='BillDateTo']").val();
        }
        var DateType = postDate;
        var prams =
        {

            DateType: DateType,
            DateFrom: Datefrom,
            DateTo: Dateto

        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //
    }

    if (ReportTypeName == "MissedCopaysReport") {

        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "DailyPayments") {

        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "PaymentByProcedureReport") {

        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }
    if (ReportTypeName == "UnpostedPaymentsDetailandSummary") {


        var filename = ReportTypeName + ".aspx";

        var PayerType = $("#ddlpayertype2").val();
        var checknumber = $("#txtsearchcheck").val();
        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }
        var prams =
        {
            TimeSpan: TimeSpan,
            DateType: postDate,
            PayerType: PayerType,
            CheckNumber: checknumber,
            DateFrom: DateFrom,
            DateTo: DateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);


    }
    if (ReportTypeName == "PaymentsSummaryAndDetail") {
        var Insurance = ""; var Patient = "";

        var filename = ReportTypeName + ".aspx";

        var ProviderIdbYNPI = $.trim($("[id$='ddlPracticeStaffOnNpiNum'] option:selected").text());


        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }

        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            Patient = '';
        }

        var prams =
        {
            TimeSpan: TimeSpan,
            DateType: postDate,
            ProviderIdbYNPI: ProviderIdbYNPI,
            Insurance: Insurance,
            Patient: Patient,
            DateFrom: DateFrom,
            DateTo: DateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename, TabFilename);
        //

    }
    if (ReportTypeName == "ProcedurePaymentsSummaryAndDetail") {
        debugger;
        var filename = ReportTypeName + ".aspx";
        var cptcodes = "";

        $('.spnservicecode').each(function () {
            cptcodes = cptcodes + ',' + $(this).text();
        });
        cptcodes = cptcodes.substring(1, cptcodes.length);

        //alert(_NewInsuranceIds.split(',').length + '-' + cptcodes + _NewInsuranceIds + InsuranceType + '-' + cptcodes.split(',').length);



        //jumpali
        var prams =
        {
            Cptcodes: cptcodes,
            Insurance: _NewInsuranceIds,
            InsuranceType: BilledAs


        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "ContractManagementSummaryReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientId = '';
        }
        if ($("[id$='chkPayerScenarioAll']").is(':checked')) {
            PayerId = '';
        }
        var insuid = $("[id$=ddlInsuranceList]").val();
        //if (postDate != "") {
        //    if ($("[id$='BillDatefrom']").val() == "") {
        //        $("[id$='BillDatefrom']").css("border", "1px solid red");
        //        showErrorMessageReport("Please select From and To date.")
        //        return false;
        //    }
        //    if ($("[id$='BillDateTo']").val() == "") {
        //        $("[id$='BillDateTo']").css("border", "1px solid red");
        //        showErrorMessageReport("Please select From and To date.")
        //        return false;
        //    }
        //    var BillDateFrom = $("[id$='BillDatefrom']").val();
        //    var BillDateTo = $("[id$='BillDateTo']").val();
        //}
        //else {
        var BillDateFrom = $("[id='BillDatefrom']").val();
        var BillDateTo = $("[id$='BillDateTo']").val();
        var prams =
        {
            insuid: insuid,
            ProcedureCode: ProcedureCode,
            DateType: postDate,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            PayerId: PayerId,
            PatientId: PatientId,
            InsuranceName: InsuranceName,
            TimeSpan: TimeSpan,
            DateFrom: BillDateFrom,
            DateTo: BillDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);

        //}
    }



    if (ReportTypeName == "ContractManagementDetailReport") {

        var filename = ReportTypeName + ".aspx";

        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientId = '';
        }
        if ($("[id$='chkPayerScenarioAll']").is(':checked')) {
            PayerId = '';
        }
        var insuid = $("[id$=ddlInsuranceList]").val();
        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return false;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        var prams =
        {
            insuid: insuid,
            ProcedureCode: ProcedureCode,
            DateType: postDate,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            PayerId: PayerId,
            PatientId: PatientId,
            InsuranceName: InsuranceName,
            TimeSpan: TimeSpan,
            DateFrom: BillDateFrom,
            DateTo: BillDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }



    if (ReportTypeName == "PaymentApplicationReport") {

        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            payerName: payerName,
            checkNumber: checkNumber,
            postDate: postDate,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "PaymentApplicationSummaryReport") {

        var filename = ReportTypeName + ".aspx";
        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }
        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "UnappliedAnalysisReport") {

        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);


    }
    if (ReportTypeName == "PayerAnalysis") {

        var filename = ReportTypeName + ".aspx";

        var prams =
        {

            Insurance: _NewInsuranceIds
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }
    debugger
    if (ReportTypeName == "ARAgingSummaryReport") {
        debugger
        var filename = ReportTypeName + ".aspx";



        var ProviderIdbYNPI = $("[id$='ddlPracticeStaffOnNpiNum']").val();
        var AgingType = $("#ddlAgingBy").val();
        var prams =
        {
            AgingType: AgingType,
            Asof: $("#dateasof").val(),
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderIdbYNPI,
            PayerId: _NewInsuranceIds,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "InsuranceCollectionDetailReport") {

        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            AgingType: AgingType,
            AgingDate: AgingDate,
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            PayerId: PayerId,
            ClaimStatus: ClaimStatus
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }
    if (ReportTypeName == "InsuranceCollectionSummaryReport") {

        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            AgingType: AgingType,
            AgingDate: AgingDate,
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            PayerId: PayerId,
            ClaimStatus: ClaimStatus
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }

    if (ReportTypeName == "PatientCollectionSummary") {

        var filename = ReportTypeName + ".aspx";
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientId = '';
        }
        var prams =
        {
            AgingType: AgingType,
            AgingDate: AgingDate,
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            PatientId: PatientId,
            ClaimStatus: ClaimStatus
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }

    if (ReportTypeName == "PatientCollectionDetail") {

        var filename = ReportTypeName + ".aspx";
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientId = '';
        }
        var prams =
        {
            AgingType: AgingType,
            AgingDate: AgingDate,
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            PatientId: PatientId,
            ClaimStatus: ClaimStatus
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }


    if (ReportTypeName == "UnpaidInsuranceClaimsReport") {

        var filename = ReportTypeName + ".aspx";
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkUnpaidinsurancesAll']").is(':checked')) {
            unpaidInsurance = '';
        }
        if (Balance == "") {
            Balance = "0";
        }
        var prams =
        {
            PayerId: unpaidInsurance,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            Balance: Balance,
            DateOfService: DateOfService,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }

    if (ReportTypeName == "ERAEOBListReport") {

        var filename = ReportTypeName + ".aspx";
        if (PaymentType == "0") {
            PaymentType = "";
        }
        if (PaymentMethod == "0") {
            PaymentMethod = "";
        }
        if (InsuranceName == "All") {
            InsuranceName = "";
        }
        var prams =
        {
            InsuranceName: InsuranceName,
            PaymentType: PaymentType,
            PaymentMethod: PaymentMethod,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo

        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }

    if (ReportTypeName == "PatientTransactionsDetail") {

        var filename = ReportTypeName + ".aspx";
        var patientIds = getallSelectedPat();
        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
            //changes added by ali imran 12 feb 2019
            PatientIds: patientIds
            //changes ended by ali imran 12 feb 2019
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }

    if (ReportTypeName == "EncounterSummaryReport") {

        var filename = ReportTypeName + ".aspx";
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }

        if ($("[id$='chkPayerScenarioAll']").is(':checked')) {
            PayerId = '';
        }
        var ddlSubmissionStatus = $("[id$=ddlSubmissionStatus]").val();

        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        var prams =
        {
            DateType: DateType,
            ddlSubmissionStatus: ddlSubmissionStatus,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            PayerId: PayerId,
            TimeSpan: TimeSpan,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }



    if (ReportTypeName == "EncounterDetailReport") {

        var filename = ReportTypeName + ".aspx";
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }

        if ($("[id$='chkPayerScenarioAll']").is(':checked')) {
            PayerId = '';
        }
        var ddlSubmissionStatus = $("[id$=ddlSubmissionStatus]").val();

        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        var prams =
        {
            DateType: DateType,
            ddlSubmissionStatus: ddlSubmissionStatus,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            PayerId: PayerId,
            TimeSpan: TimeSpan,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }


    if (ReportTypeName == "ReportPostClaimSummary") {
        debugger;
        var POSCode = "";

        var Payer = "";
        var CPTCode = $("#txtCPTCode").val();

        var filename = ReportTypeName + ".aspx";

        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }

        $("[id$='ulMultiPlaceOfService'] .chk-multi-checkboxes").each(function () {
            if ($(this).is(":checked")) {
                POSCode += $(this).parent().find("input[type='hidden']").val() + ",";

            }
        });
        if (POSCode.length > 0) {
            POSCode = POSCode.slice(0, -1);
        }
        if ($("[id$='chkPlaceOfServiceAll']").is(':checked')) {
            POSCode = '';
        }

        debugger

        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        debugger
        ReportTypes = $("[id='ddlReportType']").val();


        if ($("[id$='chkCalimStatusAll']").is(':checked')) {

            ClaimStatus = '';
        }
        var SearchFileId = "";

        $('.MultichkFileStatus').each(function () {

            if ($(this).is(":checked")) {

                SearchFileId += $(this).parent().find("#FileId").val() + ",";
            }

        });

        var ProviderIdbYNPI = $("[id$='ddlPracticeStaffOnNpiNum']").val();
        var cptcodes = "";
        $('.spnservicecode').each(function () {
            cptcodes = cptcodes + ',' + $(this).text();
        });
        cptcodes = cptcodes.substring(1, cptcodes.length);
        loc = window.ids;
        if (loc == "") {
            $('.chkDenailPayerName ').each(function () {

                if ($(this).is(":checked")) {

                    Payer += $(this).parent().find("#PatientId").val() + ",";
                }
            });
        }
        else { Payer = loc; }
        var prams =
        {
            Datetype: postDate,
            PracticeLocationId: PracticeLocationId,
            POSCode: POSCode,
            TimeSpan: TimeSpan,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo,
            ClaimStatus: ClaimStatus,
            SearchFileId: SearchFileId,
            ProviderIds: ProviderIdbYNPI,
            CPTCode: cptcodes,
            Payer: Payer,
            ReportTypes: ReportTypes
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);


        Payer = "";

    }



    if (ReportTypeName == "ReportMonthlyReconciliation") {

        var filename = ReportTypeName + ".aspx";

        var LocationId = "";// $("#ddlMonthlyReconciliationLocation").val();
        var Location = "";// $("#ddlMonthlyReconciliationLocation").text();

        $('.ddlMonthlyReconciliationLocation').each(function () {
            {
                LocationId = $("option:selected", this).val();
                Location = $("option:selected", this).text();
            }
        });
        var Year = "";
        var Month = "";
        $('.ddlMonthlyReconciliationYear').each(function () {
            {
                Year = $("option:selected", this).val();
            }
        });
        $('.ddlMonthlyReconciliationMonth').each(function () {
            {
                Month = $("option:selected", this).val();
            }
        });
        if (LocationId == "0" || LocationId == "") {
            $(".ddlMonthlyReconciliationLocation ").css("border", "1px solid red");
            showErrorMessageReport("Please select location.")
            return;
        }
        if (Year == "0" || Year == "") {
            $(".ddlMonthlyReconciliationYear ").css("border", "1px solid red");
            showErrorMessageReport("Please select year.")
            return;
        }
        if (Month == "0" || Month == "") {
            $(".ddlMonthlyReconciliationMonth ").css("border", "1px solid red");
            showErrorMessageReport("Please select month.")
            return;
        }


        var ProviderName = $.trim($("[id$='ddlMonthlyReconciliationProvider'] option:selected").text());

        if (ProviderName == "All") {
            ProviderName = "";
        }
        else if (ProviderName == "No Provider available at this location") {
            return;
        }
        var ProviderType = $("[id$='ddlProviderType'] option:selected").val();

        var prams =
        {
            LocationId: LocationId,
            Location: Location,
            Year: Year,
            ProviderType: ProviderType,
            Month: Month

        };

        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //
    }


    if (ReportTypeName == "RejectedDeniedSummaryAndDetail") {
        debugger
        var filename = ReportTypeName + ".aspx";


        var prams =
        {
            Insurance: _NewInsuranceIds,

            BilledAs: BilledAs,
            RDAging: $("[id$='ddlAging']").val() || ""
        };

        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
        //

    }


    if (ReportTypeName == "ThirtyPlusDaysAfterSubmission") {

        var filename = ReportTypeName + ".aspx";
        $("#DosDateTo").html("");
        $("#DosDateTo").text("Date");


        if (InsuranceName == "All") {
            InsuranceName = "";
        }
        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var DosDateFrom = $("[id$='BillDatefrom']").val();
            var DosDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var DosDateFrom = $("[id='BillDatefrom']").val();
            var DosDateTo = $("[id$='BillDateTo']").val();
        }
        var prams =
        {
            InsuranceName: InsuranceName,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DosDateFrom: DosDateFrom,
            DosDateTo: DosDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }

    if (ReportTypeName == "DenialsDetailReport") {

        var filename = ReportTypeName + ".aspx";
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkDenailPayerNameAll']").is(':checked')) {
            Insurance = '';
        }
        var prams =
        {
            Insurance: Insurance,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            AdjustmentCode: AdjustmentCode
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }

    if (ReportTypeName == "DenialsSummaryReport") {

        var filename = ReportTypeName + ".aspx";
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkDenailPayerNameAll']").is(':checked')) {
            Insurance = '';
        }
        var prams =
        {
            Insurance: Insurance,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
            ProviderId: ProviderId,
            PracticeLocationId: PracticeLocationId,
            AdjustmentCode: AdjustmentCode
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
        //

    }
    if (ReportTypeName == "UserAuditReport") {

        debugger;

        var user = $("#MultipleUserNameTxt").val();
        UserId = UserNameIds;
        if (user == "All") {

            UserId = "";
        }

        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkDenailPayerNameAll']").is(':checked')) {
            Insurance = '';
        }

        var filename = ReportTypeName + ".aspx";
        var UserName = $("[id$='txtUserName']").val();
        debugger;
        var InsuranceType = $("[id$='ddlInsuranceType'] option:selected").val();
        if (InsuranceType == "" && Insurance != "") {
            InsuranceType = "Pri";
        }

        if ($("[id$='chkCalimStatusAll']").is(':checked')) {
            ClaimStatus = '';
        }
        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }
        var prams =
        {
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            Insurance: Insurance,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
            UserId: UserId,
            InsuranceType: InsuranceType,
            ClaimStatus: ClaimStatus
        };
        debugger;
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);

        //

    }
    if (ReportTypeName == "ReadyForSubmissionClaimsDetail") {
        debugger;
        var filename = ReportTypeName + ".aspx";
        var DateFrom = null;
        var DateTo = null;
        var RFSDOSFrom = $(".RFSDOSFrom").val()
        if (RFSDOSFrom != "") {
            DateFrom = RFSDOSFrom;
        }
        var RFSDOSTo = $(".RFSDOSTo").val()
        if (RFSDOSTo != "") {
            DateTo = RFSDOSTo;
        }

        var RFSPostDateFrom = $(".RFSPostDateFrom").val()
        if (RFSPostDateFrom != "") {
            DateFrom = RFSPostDateFrom;
        }
        var RFSPostDateTo = $(".RFSPostDateTo").val()
        if (RFSPostDateTo != "") {
            DateTo = RFSPostDateTo;
        }

        var prams =
        {
            DateFrom: DateFrom,
            DateTo: DateTo,
            DateType: $("#ddlDateType").val(),
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
    }

    if (ReportTypeName == "UserClaimSummaryReport") {



        var user = $("#MultipleUserNameTxt").val();
        UserId = UserNameIds;
        if (user == "All") {

            UserId = "";
        }


        var filename = ReportTypeName + ".aspx";
        var UserName = $("[id$='txtUserName']").val();
        debugger;


        var prams =
        {

            Datetype: postDate,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
            UserId: UserId,

        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);

        //

    }

    if (ReportTypeName == "ClaimSummaryAndDetail") {


        var payernames = "";
        var claimid = "";
        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }

        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }

        if ($("[id$='ddlPayerName']") != "") {
            payernames = $("[id$='ddlPayerName']").val();

        }
        if ($("#ClaimIdTxt") != "") {
            claimid = $("#ClaimIdTxt").val() || 0;


        }
        var filename = ReportTypeName + ".aspx";


        debugger;
        var InsuranceType = $("[id$='ddlInsuranceType'] option:selected").val();

        var prams =
        {
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            payername: payernames,
            claimid: claimid,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);

        //

    }

    //Added by Daniyal_Baig 10Dec2018
    if (ReportTypeName == "DeductableReport") {

        var user = $("#MultipleUserNameTxt").val();
        UserId = UserNameIds;
        if (user == "All") {

            UserId = "";
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkDenailPayerNameAll']").is(':checked')) {
            Insurance = '';
        }

        var value = "";
        $('.multicheckbox').each(function () {

            if ($(this).is(":checked")) {

                value += $(this).val() + ",";

            }
        });

        debugger;
        var ReasonCodeValues = value.substring(0, value.length - 1);

        var filename = ReportTypeName + ".aspx";
        var UserName = $("[id$='txtUserName']").val();

        var InsuranceType = $("[id$='ddlInsuranceType'] option:selected").val();
        if (InsuranceType == "" && Insurance != "") {
            InsuranceType = "Pri";
        }

        if ($("[id$='chkCalimStatusAll']").is(':checked')) {
            ClaimStatus = '';
        }
        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }
        var prams =
        {
            Insurance: Insurance,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
            ReasonCodeValues: ReasonCodeValues,
            InsuranceType: InsuranceType,
            ClaimStatus: ClaimStatus,

        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount);
    }
    //End

    ///*///*///*///*///*///


    //Added by Daniyal_Baig 12March2019
    if (ReportTypeName == "ProcedurePaymentsReport") {

        var user = $("#MultipleUserNameTxt").val();
        UserId = UserNameIds;
        if (user == "All") {

            UserId = "";
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkDenailPayerNameAll']").is(':checked')) {
            Insurance = '';
        }

        var value = "";
        $('.multicheckbox').each(function () {

            if ($(this).is(":checked")) {

                value += $(this).val() + ",";

            }
        });

        debugger;
        var ReportDescription = $("input[name='radioGroup']:checked").val();
        if (ReportDescription == "Summary") {

        }
        var filename = ReportTypeName + ".aspx";
        var UserName = $("[id$='txtUserName']").val();
        var PostType = $("[id$='ddlPostType'] option:selected").val();
        var InsuranceType = $("[id$='ddlInsuranceType'] option:selected").val();
        if (InsuranceType == "" && Insurance != "") {
            InsuranceType = "Pri";
        }

        if ($("[id$='chkCalimStatusAll']").is(':checked')) {
            ClaimStatus = '';
        }
        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }
        var prams =
        {
            ReportDescription: ReportDescription,
            ProcedureCode: ProcedureCode,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
            CPTCode: _CPTCode,
            InsuranceType: InsuranceType,
            Insurance: Insurance,

        };
        OpenReportPage(filename, _isParameters, prams, ReportType, _ReportFilterCount, TabFilename);
    }
    //End

    // Rizwan kharal
    // Start New Reports 29jan2018

    //encounter detail
    if (ReportTypeName == "PED") {

        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }

        if ($("[id$='chkPayerScenarioAll']").is(':checked')) {
            PayerId = '';
        }
        var ddlSubmissionStatus = $("[id$=ddlSubmissionStatus]").val();

        var DateType = $("[id$=ddlPostType]").val();

        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }

        window.location = "EncounterDetailReport.aspx?PracticeId=" + PracticeId + "&DateType=" + postDate + "&ddlSubmissionStatus=" + ddlSubmissionStatus + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;


    }


    // Appointment Detail


    var ClaimPostDate = $("[id$='txtClaimPostDate']").val();
    var POSCode = "";
    $("[id$='ulMultiPlaceOfService'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            POSCode += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if (POSCode.length > 0) {
        POSCode = POSCode.slice(0, -1);
    }


    if (ReportTypeName == "PostC") {


        if (POSCode == "") {
            showErrorMessageReport('Please Select atleast one code.');
            return;
        }

        if (PracticeLocationId == "") {
            showErrorMessageReport('Please Select atleast one location.');
            return;
        }


        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }

        if ($("[id$='chkPlaceOfServiceAll']").is(':checked')) {
            POSCode = '';
        }


        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='BillDatefrom']").val();
            var BillDateTo = $("[id$='BillDateTo']").val();
        }

        if ($("[id$='chkCalimStatusAll']").is(':checked')) {

            ClaimStatus = '';
        }

        window.location = "ReportPostClaims.aspx?Datetype=" + postDate + "&PracticeLocationId=" + PracticeLocationId + "&POSCode=" + POSCode + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo + "&ClaimStatus=" + ClaimStatus;
    }



    //Rizwan kharal
    /***************added by shahid kazmi 4/11/2018****************/

    /****************end shahid kazmi 4/11/2018**************/
    //Start Added By Rizwan kharal 26April2018


    //END Added By Rizwan kharal 26April2018

    //Start Added By Rizwan kharal 27April2018


    //END Added By Rizwan kharal 26April2018

    //Start Added By Rizwan kharal 8May2018
    //PatientPayments
    if (ReportTypeName == "PatPay") {

        if (postDate != "") {
            if ($("[id$='BillDatefrom']").val() == "") {
                $("[id$='BillDatefrom']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            if ($("[id$='BillDateTo']").val() == "") {
                $("[id$='BillDateTo']").css("border", "1px solid red");
                showErrorMessageReport("Please select From and To date.")
                return;
            }
            var DateFrom = $("[id$='BillDatefrom']").val();
            var DateTo = $("[id$='BillDateTo']").val();
        }
        else {
            var DateFrom = $("[id='BillDatefrom']").val();
            var DateTo = $("[id$='BillDateTo']").val();
        }


        window.location = "PatientPayments.aspx?Datetype=" + postDate + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }

    //END Added By Rizwan kharal 8May2018

}




function Report_InitializeDate() {
    $("[id$='txtReportDate']").datepicker({
        changeYear: true,
        changeMonth: true,
        maxDate: 0
    }).mask("99/99/9999");

    $("[id$='txtReportTo']").datepicker({
        setDate: '01/09/2016',
        changeYear: true,
        changeMonth: true,
        maxDate: 0
    }).mask("99/99/9999");
    var currentDate = new Date();
    $("[id$='txtReportDate']").datepicker('setDate', new Date(currentDate.getFullYear(), currentDate.getMonth(), 1));
    $("[id$='txtReportTo']").datepicker('setDate', currentDate);
    $("[id$='txtReportDate']").blur();
}
function Report_InitializeDatesBoxes() {
    $("[id$='txtReportDateFrom']").datepicker({
        changeYear: true,
        changeMonth: true,
        maxDate: new Date(),
        onSelect: function (dateText) {
            var min = new Date(dateText);
            $("[id$='txtReportDateTo']").datepicker('option', 'minDate', min);
        }
    }).mask("99/99/9999");

    $("[id$='txtReportDateTo']").datepicker({
        changeYear: true,
        changeMonth: true,
        maxDate: new Date(),
        onSelect: function (dateText) {
            if (!$('#txtReportDateFrom').val()) {
                $(this).val('');
                showErrorMessageReport('Please Select From date first.');
            }


        }
    }).mask("99/99/9999");
}
function Report_EditReportCriteria(elem) {

    $(elem).closest(".report-criteria-box").find(".readonly-container").hide();
    $(elem).closest(".report-criteria-box").find(".editable-container").show();

    //$(elem).parent().parent().parent(".report-criteria-box").css({ "margin-left": "-11.7%", "width": "27%" , "margin-top": "-0.8%"});
    //$(elem).parent().parent().find(".selectedText").css({ "top": "-3px", "margin-left": "-38%" });
    //$(elem).parent().parent().find("#divReportTimeSpan").css({"width": "73%","margin-top": "1%"});

    //$(elem).parent().parent().find("#divReportTimeSpan").find(".Beginning").css("float", "left");
    //$(elem).parent().parent().find("#divReportTimeSpan").find(".LastMonth").css("float", "left");
    //$(elem).parent().parent().find("#divReportTimeSpan").find(".MonthToDate").css("float", "left");
    //$(elem).parent().parent().find("#divReportTimeSpan").find(".SpecificDates").css("float", "left");
    //$(elem).parent().parent().find("#timeDurationAgencyReportFilterBox").removeAttr("style");
    //$(elem).parent().parent().find("#timeDurationAgencyReportFilterBox").css("width", "110%" );
    //$(elem).parent().parent().find($('ul#ulMultiCheckBoxAgency li:eq(0)')).removeAttr("style");
    //$(elem).parent().parent().find($('ul#ulMultiCheckBoxAgency li:eq(0)')).css({ "float": "left", "width": "100%", "margin-left": "-40%" });
    //$(elem).parent().parent().find($('ul#ulMultiCheckBoxAgency li:eq(1)')).removeAttr("style");
    //$(elem).parent().parent().find($('ul#ulMultiCheckBoxAgency li:eq(1)')).css({ "float": "left", "width": "100%", "margin-left": "-16%" });
}
function SetReportFilterFields() {

    SetEditableFields();
    SetReadonlyFields();

    $(".report-criteria-box .editable-container").hide();
    $(".report-criteria-box .readonly-container").show();

    $(".report-criteria-box").show();
}

function Report_SetEditableTimeSpanFields() {
    debugger;
    var TimeSpan = $("[id$='hdnTimeSpan']").val();
    DateFrom = $("[id$='hdnDateFrom']").val();
    DateTo = $("[id$='hdnDateTo']").val();

    $("[id$='txtReportDateFrom']").val(DateFrom);
    $("[id$='txtReportDateTo']").val(DateTo);

    if (TimeSpan == "Beginning") {
        $("[id$='rbReportTimeSpanFromTheBeginning']").prop("checked", true);
    }
    else if (TimeSpan == "YearToDate") {
        $("[id$='rbReportTimeSpanYearToDate']").prop("checked", true);
    }
    else if (TimeSpan == "MonthToDate") {
        $("[id$='rbReportTimeSpanMonthToDate']").prop("checked", true);
    }
    else if (TimeSpan == "LastMonth") {
        $("[id$='rbReportTimeSpanLastMonth']").prop("checked", true);
    }
    else if (TimeSpan == "SpecificDates") {

        $("[id$='rbReportTimeSpanSpecificDates']").prop("checked", true);
        EnableDates(true);
    }
}
function Report_SetReadonlyTimeSpanFields() {

    var TimeSpan = "";
    var DateFrom = $("[id$='txtReportDateFrom']").val();
    var DateTo = $("[id$='txtReportDateTo']").val();

    var SelectedTimeSpanClass = $("#divReportTimeSpan :radio:checked").closest("span").attr("class");
    var SelectedTimeSpan = "";

    if (SelectedTimeSpanClass == "SpecificDates") {
        SelectedTimeSpan = DateFrom + "-" + DateTo;
    }
    else {
        SelectedTimeSpan = $("#divReportTimeSpan :radio:checked").closest("span").find("label").html().trim();
    }

    $("[id$='lblTimeSpan']").html(SelectedTimeSpan);
}
function Report_GetSelectedMultiCheckBoxDropDownItemsText(CurrentUl,elem) {
    CurrentUl = $("#" + CurrentUl);

    var MultiText = "";

    if (($("#" + SubReportDivName).parentsUntil().find(CurrentUl).find(".chk-multi-checkboxes").length == $("#" + SubReportDivName).find(CurrentUl).parentsUntil().find(".chk-multi-checkboxes:checked").length) || ($("#" + SubReportDivName).parentsUntil().find(CurrentUl).find(".chk-multi-checkboxes").length ==  0)) {
        MultiText = "All";
    }
    else {
        $("#" + SubReportDivName).parentsUntil().find(CurrentUl).find(".chk-multi-checkboxes").each(function () {
            debugger
            if ($(this).is(":checked")) {
                debugger
                MultiText += $(this).parent().find("span").html().trim() + ",";
            }
        });

        if (MultiText.length > 0) {
            MultiText = MultiText.slice(0, -1);
        }
    }

    return MultiText;
}
function Report_ClickMultiCheckBoxAll(elem, ULALL) {
    debugger;
    $("[id$='FilterReports']").prop("disabled", false);
    var CheckBox = $(elem).find(":checkbox");
    var ddl = $(elem).closest(".div-multi-checkboxes-wrapper").attr('id');
    var CurrentUl = $(elem).closest("ul");

    CurrentUl.find(".chk-multi-checkboxes").prop("checked", CheckBox.is(":checked"));

    var MultiText = "";

    if (CheckBox.is(":checked")) {

        MultiText = "All";
        if (ddl == "divServiceProvider") {
            $(elem).closest("#divReportServiceProvider").find(".selectedText").text("");
            $(elem).closest("#divReportServiceProvider").find(".selectedText").text("All Providers");
        }

        if (ddl == "divPracticeLocation") {
            $(elem).closest("#divPracticeLocationId").find(".selectedText").text("");
            $(elem).closest("#divPracticeLocationId").find(".selectedText").text("All Locations");
        }

        if (ddl == "divPlaceOfService") {
            $(elem).closest("#divPlaceOfServiceReport").find(".selectedText").text("");
            $(elem).closest("#divPlaceOfServiceReport").find(".selectedText").text(" All Place Of Services");
        }

        if (ddl == "divPayerScenario") {
            $(elem).closest("#divReportPayerScenario").find(".selectedText").val("");
            $(elem).closest("#divReportPayerScenario").find(".selectedText").text("All Payers");
            //$(elem).closest("#divReportPayerScenario").find(".SplitIds").val("");
            ids = "";


        }
        if (ddl == "divReportUnpaidinsurances") {
            $(elem).closest("#divReportUnpaidinsurances").find(".selectedText").text("");
            $(elem).closest("#divReportUnpaidinsurances").find(".selectedText").text("All Unpaid Insurances");
        }
        if (ddl == "divDenailPayerName") {
            $(elem).closest("#divReportDenailPayerName").find(".selectedText").val("");
            $(elem).closest("#divReportDenailPayerName").find(".selectedText").val("All");
        }

        if (ddl == "divAdjustmentCode") {
            $(elem).closest("#divReportAdjustmentCode").find(".selectedText").text("");
            $(elem).closest("#divReportAdjustmentCode").find(".selectedText").text("All");
        }
        if (ddl == "divCalimStatus") {
            $(elem).closest("#divReportClaimStatus").find(".selectedText").text("");
            $(elem).closest("#divReportClaimStatus").find(".selectedText").text("All Claims");
        }
        if (ddl == "divFileStatus") {
            $(elem).closest("#divFileSearch").find(".selectedText").text("");
            $(elem).closest("#divFileSearch").find(".selectedText").text("All Files");
        }
        if (ddl == "divPatientName") {
            $(elem).closest("#divReportPatientName").find(".selectedText").val("");
            $(elem).closest("#divReportPatientName").find(".selectedText").val("All");
        }
        if (ddl == "divBilledAs1") {
            $(elem).closest("#divReportBilledAs").find(".selectedText").text("");
            $(elem).closest("#divReportBilledAs").find(".selectedText").text("All");
        }
        // Added by Asad Mehmood on 15/09/2020
        if (ddl == "divPayerScenario1") {
            $("#SearchPayertxt1").val("ALL");
            var splitedvalue = "";
            $.each($('#divPayerScenario1 .chkDenailPayerName'), function (index, element) {
                splitedvalue += $(this).parent().find('#PatientId').val() + ",";
            })
            $('#hdnSearchPayertxt1').val(splitedvalue);
        }


    }
    else {
        if (ddl == "divPayerScenario") {
            $(elem).closest("#divReportPayerScenario").find(".selectedText").val("");
            $(elem).closest("#divReportPayerScenario").find(".hdnselectedText").val("");
            $(elem).closest("#divReportPayerScenario").find(".SplitIds").val("");
            ids = "";

        }
        // Added by Asad Mehmood on 15/09/2020
        if (ddl == "divPayerScenario1") {
            $("#SearchPayertxt1").val("ALL");
            $('#hdnSearchPayertxt1').val("");
        }
        debugger
        if (ddl == "divPracticeLocation") {
            if (ULALL == "ClaimSummaryDynamicLocations") {
                if ($("[id$='ClaimSummaryDynamicLocations'] #chkClaimSummaryDynamicLocationsAll").is(":checked")) {
                    $("[id$='ClaimSummaryDynamicLocations'] .chk-multi-checkboxes").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='ClaimSummaryDynamicLocations'] .chk-multi-checkboxes").prop("checked", false)
                }
            }
            if (ULALL == "ClaimSummaryLocations") {
                if ($("[id$='ClaimSummaryLocations'] #chkClaimSummaryLocationsAll").is(":checked")) {
                    $("[id$='ClaimSummaryLocations'] #chkClaimSummaryLocations").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='ClaimSummaryLocations'] #chkClaimSummaryLocations").prop("checked", false)
                }
            }
            if (ULALL == "ChargedSummaryDynamicLocations") {
                if ($("[id$='ChargedSummaryDynamicLocations'] #chkChargedSummaryDynamicLocationsAll").is(":checked")) {
                    $("[id$='ChargedSummaryDynamicLocations'] .chk-multi-checkboxes").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='ChargedSummaryDynamicLocations'] .chk-multi-checkboxes").prop("checked", false)
                }
            }
            if (ULALL == "ChargedSummaryLocations") {
                if ($("[id$='ChargedSummaryLocations'] #chkChargedSummaryLocationsAll").is(":checked")) {
                    $("[id$='ChargedSummaryLocations'] #chkChargedSummaryLocations").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='ChargedSummaryLocations'] #chkChargedSummaryLocations").prop("checked", false)
                }
            }
            if (ULALL == "CPTWiseCollectionDynamicLocations") {
                if ($("[id$='CPTWiseCollectionDynamicLocations'] #chkCPTWiseCollectionDynamicLocationsAll").is(":checked")) {
                    $("[id$='CPTWiseCollectionDynamicLocations'] #chkCPTWiseCollectionDynamicLocations").prop("checked", true)

                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='CPTWiseCollectionDynamicLocations'] #chkCPTWiseCollectionDynamicLocations").prop("checked", false)
                }
            }
            if (ULALL == "CPTWiseCollectionLocations") {
                if ($("[id$='CPTWiseCollectionLocations'] #chkCPTWiseCollectionLocationAll").is(":checked")) {
                    $("[id$='CPTWiseCollectionLocations'] #chkCPTWiseCollectionLocations").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='CPTWiseCollectionLocations'] #chkCPTWiseCollectionLocations").prop("checked", false)
                }
            }
            if (ULALL == "LocationsWiseCollectionLocations") {
                if ($("[id$='LocationsWiseCollectionLocations'] #chkLocationsWiseCollectionLocationAll").is(":checked")) {
                    $("[id$='LocationsWiseCollectionLocations'] #chkLocationsWiseCollectionLocation").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='LocationsWiseCollectionLocations'] #chkLocationsWiseCollectionLocation").prop("checked", false)
                }
            }
            if (ULALL == "CPTWiseCollectionLocations") {
                if ($("[id$='CPTWiseCollectionLocations'] #chkCPTWiseCollectionLocationAll").is(":checked")) {
                    $("[id$='CPTWiseCollectionLocations'] #chkCPTWiseCollectionLocations").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='CPTWiseCollectionLocations'] #chkCPTWiseCollectionLocations").prop("checked", false)
                }
            }
            if (ULALL == "PatientBalanceLocations") {
                if ($("[id$='PatientBalanceLocations'] #chkPatientBalanceLocationAll").is(":checked")) {
                    $("[id$='PatientBalanceLocations'] #chkPatientBalanceLocation").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='PatientBalanceLocations'] #chkPatientBalanceLocation").prop("checked", false)
                }
            }
            if (ULALL == "PatientBalanceDynamicLocations") {
                if ($("[id$='PatientBalanceDynamicLocations'] #DynamicPatientBalanceLocationsChkAll").is(":checked")) {
                    $("[id$='PatientBalanceDynamicLocations'] #PatientBalanceProviderChk").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='PatientBalanceDynamicLocations'] #PatientBalanceProviderChk").prop("checked", false)
                }
            }
            if (ULALL == "ProviderCollectionLocations") {
                if ($("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocationsAll").is(":checked")) {
                    $("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocations").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocations").prop("checked", false)
                }
            }
            if (ULALL == "ProviderCollectionDynamicLocations") {
                if ($("[id$='ProviderCollectionDynamicLocations'] #DynamicProviderCollectionLocationsChkAll").is(":checked")) {
                    $("[id$='ProviderCollectionDynamicLocations'] #ProviderCollectionLocationsChk").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='ProviderCollectionDynamicLocations'] #ProviderCollectionLocationsChk").prop("checked", false)
                }
            }
            if (ULALL == "ARAgingSummaryLocations") {
                if ($("[id$='ARAgingSummaryLocations'] #chkARAgingSummaryLocationsAll").is(":checked")) {
                    $("[id$='ARAgingSummaryLocations'] #chkARAgingSummaryLocations").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='ARAgingSummaryLocations'] #chkARAgingSummaryLocations").prop("checked", false)
                }
            }
            if (ULALL == "ARAgingSummaryDynamicLocations") {
                if ($("[id$='ARAgingSummaryDynamicLocations'] #DynamicARAgingSummaryLocationsChkAll").is(":checked")) {
                    $("[id$='ARAgingSummaryDynamicLocations'] #ARAgingSummaryProviderChk").prop("checked", true)
                    $("[id$='ARAgingSummaryDynamicLocations'] #ARAgingSummaryLocationsChk").prop("checked", true)
                    $('#AllLocations').text("All Locations")
                }
                else {
                    $("[id$='ARAgingSummaryDynamicLocations'] #ARAgingSummaryProviderChk").prop("checked", false)
                }
            }
        }
        if (ddl == "divServiceProvider") {
            if (ULALL == "ClaimSummaryProviders") {
                if ($("[id$='ClaimSummaryProviders'] #chkClaimSummaryProvidersAll").is(":checked")) {
                    $("[id$='chkClaimSummaryProviders']").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='chkClaimSummaryProviders']").prop("checked", false)
                }
            }
            if (ULALL == "ClaimSummaryDynamicProvider") {
                if ($("[id$='ClaimSummaryDynamicProvider'] #DynamicClaimSummaryProviderChkAll").is(":checked")) {
                    $("[id$='DynamicClaimSummaryProviderChk']").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='DynamicClaimSummaryProviderChk']").prop("checked", false)
                }
            }
            if (ULALL == "CPTWiseDynamicProviders") {
                if ($("[id$='CPTWiseCollectionDynamicProvider'] #DynamicCPTWiseDynamicProviderChkAll").is(":checked")) {
                    $("[id$='CPTWiseCollectionDynamicProvider'] #DynamicCPTWiseProviderChk").prop("checked", true)
                    $('#AllProviders').text("All Providers")
                }
                else {
                    $("[id$='CPTWiseCollectionDynamicProvider']  #DynamicCPTWiseProviderChk").prop("checked", false)
                }
            }
            if (ULALL == "CPTWiseCollectionProviders") {
                debugger
                if ($("[id$='CPTWiseCollectionProviders'] #chkCPTWiseCollectionProvidersAll").is(":checked")) {
                    $("[id$='CPTWiseCollectionProviders']  #chkCPTWiseCollectionProviders").prop("checked", true)
                    $('#AllProviders').text("All Providers")
                }
                else {
                    $("[id$='CPTWiseCollectionProviders']  #chkCPTWiseCollectionProviders").prop("checked", false)
                }
            }
            if (ULALL == "LocationsWiseProviders") {
                if ($("[id$='LocationsWiseProviders'] #chkLocationsWiseProvidersAll").is(":checked")) {
                    $("[id$='LocationsWiseProviders']  #chkLocationsWiseProviders").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='LocationsWiseProviders']  #chkLocationsWiseProviders").prop("checked", false)
                }
            }
            if (ULALL == "LocationsWiseDynamicProviders") {
                if ($("[id$='LocationsWiseCollectionDynamicProvider'] #DynamicLocationsWiseDynamicProviderChkAll").is(":checked")) {
                    $("[id$='LocationsWiseCollectionDynamicProvider']  #LocationsWiseDynamicProviderChk").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='LocationsWiseCollectionDynamicProvider']  #LocationsWiseDynamicProviderChk").prop("checked", false)
                }
            }
            if (ULALL == "PatientBalanceProviders") {
                if ($("[id$='PatientBalanceProviders'] #PatientBalanceProviderChkAll").is(":checked")) {
                    $("[id$='PatientBalanceProviders']  #chkPatientBalanceProviders").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='PatientBalanceProviders']  #chkPatientBalanceProviders").prop("checked", false)
                }
            }
            if (ULALL == "PatientBalanceDynamicProviders") {
                if ($("[id$='PatientBalanceDynamicProviders'] #DynamicPatientBalanceProviderChkAll").is(":checked")) {
                    $("[id$='PatientBalanceDynamicProviders']  #PatientBalanceDynamicProviderChk").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='PatientBalanceDynamicProviders']  #PatientBalanceDynamicProviderChk").prop("checked", false)
                }
            }
            if (ULALL == "ProviderCollectionProviders") {
                if ($("[id$='ProviderCollectionProviders'] #ProviderCollectionProviderChkAll").is(":checked")) {
                    $("[id$='ProviderCollectionProviders']  #chkProviderCollectionProviders").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='ProviderCollectionProviders']  #chkProviderCollectionProviders").prop("checked", false)
                }
            }
            if (ULALL == "ProviderCollectionDynamicProviders") {
                if ($("[id$='ProviderCollectionDynamicProviders'] #DynamicProviderCollectionProviderChkAll").is(":checked")) {
                    $("[id$='ProviderCollectionDynamicProviders']  #ProviderCollectionDynamicProviderChk").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='ProviderCollectionDynamicProviders']  #ProviderCollectionDynamicProviderChk").prop("checked", false)
                }
            }
            if (ULALL == "ARAgingSummaryProviders") {
                if ($("[id$='ARAgingSummaryProviders'] #ARAgingSummaryProviderChkAll").is(":checked")) {
                    $("[id$='ARAgingSummaryProviders']  #chkARAgingSummaryProviders").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='ARAgingSummaryProviders']  #chkARAgingSummaryProviders").prop("checked", false)
                }
            }
            if (ULALL == "ARAgingSummaryDynamicProviders") {
                if ($("[id$='ARAgingSummaryDynamicProviders'] #DynamicARAgingSummaryProviderChkAll").is(":checked")) {
                    $("[id$='ARAgingSummaryDynamicProviders']  #ARAgingSummaryDynamicProviderChk").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='ARAgingSummaryDynamicProviders']  #ARAgingSummaryDynamicProviderChk").prop("checked", false)
                }
            }
            if (ULALL == "UnpaidInsuranceDynamicProviders") {
                if ($("[id$='ulMultiServiceProvider'] #chkServiceProviderAll").is(":checked")) {
                    $("[id$='ulMultiServiceProvider']  #chkPracticeLocation").prop("checked", true)
                    $('#AllServiceProvider').text("All Providers")

                }
                else {
                    $("[id$='ulMultiServiceProvider']  #chkPracticeLocation").prop("checked", false)
                }
            }
            if (ULALL == "ChargedSummaryProviders") {
                if ($("[id$='ChargedSummaryProviders'] #chkChargedSummaryProvidersAll").is(":checked")) {
                    $("[id$='chkChargedSummaryProviders']").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='chkChargedSummaryProviders']").prop("checked", false)
                }
            }
            if (ULALL == "ChargedSummaryDynamicProvider") {
                if ($("[id$='ChargedSummaryDynamicProvider'] #DynamicChargedSummaryProviderChkAll").is(":checked")) {
                    $("[id$='DynamicChargedSummaryProviderChk']").prop("checked", true)
                    $('#AllProviders').text("All Providers")

                }
                else {
                    $("[id$='DynamicChargedSummaryProviderChk']").prop("checked", false)
                }
            }
        }
    }
    if (ddl == "divReportUnpaidinsurances") {
        debugger
        if (ULALL == "ulMultiUnpaidinsurances") {
            if ($("[id$='ulMultiUnpaidinsurances'] #chkUnpaidinsurancesAll").is(":checked")) {
                $("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").prop("checked", true)
                $('#AllUnpaidInsurance').text("All Unpaid Insurance")
            }
            else {
                $("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").prop("checked", false)
            }
        }
    }

    $(elem).closest(".dropDownMenu").find(".selectedText").html(MultiText);
    $(elem).closest(".dropDownMenu").find(".selectedText").prop("title", MultiText);
    //$(elem).closest("#divReportServiceProvider").find(".selectedText").text("");
}

function Report(elem) {
    debugger
    var CurrentUl = $(elem).closest("ul");
    var CurrentUlId = $(elem).closest("ul").attr("id");

    if (CurrentUl.find(".chk-multi-checkboxes").length == CurrentUl.find(".chk-multi-checkboxes:checked").length) {
        //CurrentUl.find(".chk-multi-checkboxes-all").prop("checked", true);
    }
    else {
        CurrentUl.find(".chk-multi-checkboxes-all").prop("checked", false);
    }

    var MultiText = Report_GetSelectedMultiCheckBoxDropDownItemsText(CurrentUlId);

    $(elem).closest(".dropDownMenu").find(".selectedText").html(MultiText);
    $(elem).closest(".dropDownMenu").find(".selectedText").prop("title", MultiText);
    $("[id$='txtReportDate']").datepicker({
        changeYear: true,
        changeMonth: true,
        maxDate: 0
    }).mask("99/99/9999");

    $("[id$='txtReportTo']").datepicker({
        setDate: '01/09/2016',
        changeYear: true,
        changeMonth: true,
        maxDate: 0
    }).mask("99/99/9999");
}
function EnableDates(enable, elem) {
    debugger
    //$("[id$='FilterReports']").prop("disabled", false);
    //$(elem).parent().parent().parent().parent().parent().find("#FilterReports").prop("disabled", false);
    if (!enable) {
        $("[id$='ReportDateFrom']").val("");
        $("[id$='ReportDateTo']").val("");
    }

    $("[id$='ReportDateFrom']").prop("disabled", !enable);
    $("[id$='ReportDateTo']").prop("disabled", !enable);
    /*Added By Faiza Bilal 3-21-2022 to get dates on selecting date timespan*/
    var DateFrom = '';
    var DateTo = '';

    var TimeSpan = $(".radio_li :radio:checked").closest("span").attr("class");
    var d = new Date();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    var lastMonth = d.getMonth();
    var lastDay = new Date(year, month - 1, 0).getDate();
    var day = d.getDate();
    if (TimeSpan == "Today") {
        var Td = new Date();
        var month = Td.getMonth() + 1;
        var day = Td.getDate();
        DateFrom = Td.getFullYear() + '-' + (('' + month).length < 2 ? '0' : '') + month + '-' + (('' + day).length < 2 ? '0' : '') + day;
        DateTo = Td.getFullYear() + '-' + (('' + month).length < 2 ? '0' : '') + month + '-' + (('' + day).length < 2 ? '0' : '') + day;
    }
    else if (TimeSpan == "Beginning") {
        DateFrom = '';
        DateTo = '';
    }
    else if (TimeSpan == "YearToDate") {

        DateFrom = year + '-' + '01-01';
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
    }
    else if (TimeSpan == "LastMonth") {
        if (month == "1") {
            year = d.getFullYear() - 1;
            lastDay = new Date(year, month - 1, 0).getDate();
            month = d.getMonth() + 1;
            if (lastMonth == "0") {
                lastMonth = "12";
            }
        }
        DateFrom = year + '-' + (lastMonth < 10 ? '0' : '') + lastMonth + '-01';
        DateTo = year + '-' + (lastMonth < 10 ? '0' : '') + lastMonth + '-' + (lastDay < 10 ? '0' : '') + lastDay;
    }
    else if (TimeSpan == "MonthToDate") {

        DateFrom = year + '-' + (month < 10 ? '0' : '') + month + '-01';
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
    }
    else if (TimeSpan == "SpecificDates" || TimeSpan == null) {
        DateFrom = "";
        DateTo = "";
    }

    //$(".TimeSpan").find("#txtDateFrom").text(DateFrom);
    //$(".TimeSpan").find("#txtDateTo").text(DateTo);
    $("[id$='ReportDateFrom']").val(DateFrom);
    $("[id$='ReportDateTo']").val(DateTo);
    /*End Added By Faiza Bilal 3-21-2022 to get dates on selecting date timespan*/
}

/**********END SHAHID AKZMI 11/17/2017****************/

function ReportAlert(elem, ULID) {
    debugger;
    var ProviderId = ""; var PlaceOfService = ""; var Location = "";
    var UnPaidInsurance = ""; var BilledAs = "";

    var ddl = $(elem).closest(".div-multi-checkboxes-wrapper").attr('id');
    var CustomizeCheck = $(elem).closest(".div-multi-checkboxes-wrapper").attr('class');
    var Customize = CustomizeCheck.split(" ");
    $(elem).parents(".SearchCriteria").find("#FilterReports").prop("disabled", false);
    if (ddl == "divServiceProvider") {
        if (ULID == "CPTWiseDynamicProviders") {

            if ($("[id$='CPTWiseCollectionDynamicProvider'] .chk-multi-checkboxes:checked").length == $("[id$='CPTWiseCollectionDynamicProvider'] .chk-multi-checkboxes").length) {
                $("#DynamicCPTWiseDynamicProviderChkAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='DynamicCPTWiseDynamicProviderChkAll']").prop("checked", false);
                $("[id$='CPTWiseCollectionDynamicProvider'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }

        }
        if (ULID == "CPTWiseCollectionProviders") {

            if ($("[id$='CPTWiseCollectionProviders'] .chk-multi-checkboxes:checked").length == $("[id$='CPTWiseCollectionProviders'] .chk-multi-checkboxes").length) {
                $("#chkCPTWiseCollectionProvidersAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='chkCPTWiseCollectionProvidersAll']").prop("checked", false);
                $("[id$='CPTWiseCollectionProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }

        }
        if (ULID == "ClaimSummaryDynamicProvider") {

            if ($("[id$='ClaimSummaryDynamicProvider'] .chk-multi-checkboxes:checked").length == $("[id$='ClaimSummaryDynamicProvider'] .chk-multi-checkboxes").length) {
                $(elem).parentsUntil(".BranceInput").find("#DynamicClaimSummaryProviderChkAll").prop("checked", true);
                $(elem).parentsUntil(".BranceInput").find(".selectedText").text("All Providers");
                //$('#AllProviders').text("All Providers")
            }
            else {
                $(elem).parentsUntil(".BranceInput").find("#DynamicClaimSummaryProviderChkAll").prop("checked", false);
                $(elem).parentsUntil(".BranceInput").find("[id$='ClaimSummaryDynamicProvider'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }

        }
        if (ULID == "ClaimSummaryProviders") {

            if ($("[id$='ClaimSummaryProviders'] .chk-multi-checkboxes:checked").length == $("[id$='ClaimSummaryProviders'] .chk-multi-checkboxes").length) {
                $("#chkClaimSummaryProvidersAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='chkClaimSummaryProvidersAll']").prop("checked", false);
                $("[id$='ClaimSummaryProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });

            }

        }
        if (ULID == "ChargedSummaryDynamicProvider") {

            if ($("[id$='ChargedSummaryDynamicProvider'] .chk-multi-checkboxes:checked").length == $("[id$='ChargedSummaryDynamicProvider'] .chk-multi-checkboxes").length) {
                $(elem).parentsUntil(".BranceInput").find("#DynamicChargedSummaryProviderChkAll").prop("checked", true);
                $(elem).parentsUntil(".BranceInput").find(".selectedText").text("All Providers");
                //$('#AllProviders').text("All Providers")
            }
            else {
                $(elem).parentsUntil(".BranceInput").find("#DynamicChargedSummaryProviderChkAll").prop("checked", false);
                $(elem).parentsUntil(".BranceInput").find("[id$='ChargedSummaryDynamicProvider'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }

        }
        if (ULID == "ChargedSummaryProviders") {

            if ($("[id$='ChargedSummaryProviders'] .chk-multi-checkboxes:checked").length == $("[id$='ChargedSummaryProviders'] .chk-multi-checkboxes").length) {
                $("#chkChargedSummaryProvidersAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='chkChargedSummaryProvidersAll']").prop("checked", false);
                $("[id$='ChargedSummaryProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });

            }

        }
        if (ULID == "LocationsWiseProviders") {

            if ($("[id$='LocationsWiseProviders'] .chk-multi-checkboxes:checked").length == $("[id$='LocationsWiseProviders'] .chk-multi-checkboxes").length) {
                $("#chkLocationsWiseProvidersAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='chkLocationsWiseProvidersAll']").prop("checked", false);
                $("[id$='LocationsWiseProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }

        }

        if (ULID == "LocationsWiseDynamicProviders") {

            if ($("[id$='LocationsWiseCollectionDynamicProvider'] .chk-multi-checkboxes:checked").length == $("[id$='LocationsWiseCollectionDynamicProvider'] .chk-multi-checkboxes").length) {
                $("#DynamicLocationsWiseDynamicProviderChkAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='DynamicLocationsWiseDynamicProviderChkAll']").prop("checked", false);
                $("[id$='LocationsWiseCollectionDynamicProvider'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }


        }
        if (ULID == "PatientBalanceProviders") {

            if ($("[id$='PatientBalanceProviders'] .chk-multi-checkboxes:checked").length == $("[id$='PatientBalanceProviders'] .chk-multi-checkboxes").length) {
                $("#ProviderCollectionProviderChkAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='PatientBalanceProviderChkAll']").prop("checked", false);
                $("[id$='PatientBalanceProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }
        }
        if (ULID == "PatientBalanceDynamicProviders") {

            if ($("[id$='PatientBalanceDynamicProviders'] .chk-multi-checkboxes:checked").length == $("[id$='PatientBalanceDynamicProviders'] .chk-multi-checkboxes").length) {
                $("#DynamicPatientBalanceProviderChkAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='DynamicPatientBalanceProviderChkAll']").prop("checked", false);
                $("[id$='PatientBalanceDynamicProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });

            }
        }
        if (ULID == "ProviderCollectionProviders") {

            if ($("[id$='ProviderCollectionProviders'] .chk-multi-checkboxes:checked").length == $("[id$='ProviderCollectionProviders'] .chk-multi-checkboxes").length) {
                $("#ProviderCollectionProviderChkAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='ProviderCollectionProviderChkAll']").prop("checked", false);
                $("[id$='ProviderCollectionProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }


        }
        if (ULID == "ProviderCollectionDynamicProviders") {

            if ($("[id$='ProviderCollectionDynamicProviders'] .chk-multi-checkboxes:checked").length == $("[id$='ProviderCollectionDynamicProviders'] .chk-multi-checkboxes").length) {
                $("#DynamicProviderCollectionProviderChkAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='DynamicProviderCollectionProviderChkAll']").prop("checked", false);
                $("[id$='ProviderCollectionDynamicProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });

            }
        }
        if (ULID == "ARAgingSummaryProviders") {

            if ($("[id$='ARAgingSummaryProviders'] .chk-multi-checkboxes:checked").length == $("[id$='ARAgingSummaryProviders'] .chk-multi-checkboxes").length) {
                $("#ARAgingSummaryProviderChkAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='ARAgingSummaryProviderChkAll']").prop("checked", false);
                $("[id$='ARAgingSummaryProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });
            }


        }
        if (ULID == "ARAgingSummaryDynamicProviders") {

            if ($("[id$='ARAgingSummaryDynamicProviders'] .chk-multi-checkboxes:checked").length == $("[id$='ARAgingSummaryDynamicProviders'] .chk-multi-checkboxes").length) {
                $("#DynamicARAgingSummaryProviderChkAll").prop("checked", true);
                $('#AllProviders').text("All Providers")
            }
            else {
                $("[id$='DynamicARAgingSummaryProviderChkAll']").prop("checked", false);
                $("[id$='ARAgingSummaryDynamicProviders'] .chk-multi-checkboxes").each(function () {
                    if ($(this).is(":checked")) {
                        ProviderId += $(this).parent().find("span").html() + ",";
                    }
                });

            }
        }
        debugger
        $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {



                ProviderId += $(this).parent().find("span").html() + ",";
            }
        });
        if (ProviderId.length > 0) {
            debugger
            ProviderId = ProviderId.slice(0, -1);
        }
        if (ProviderId != "") {
            $(elem).closest("#divReportServiceProvider").find(".selectedText").text("");
            var b = $(elem).closest("#divReportServiceProvider").find(".selectedText").val("");
            $(elem).closest("#divReportServiceProvider").find(".selectedText").text(ProviderId);
        }


    }
    else if (ddl == "divPracticeLocation") {
        if (ULID == "ClaimSummaryLocations") {
            $(elem).parentsUntil(".BranceInput").find("[id$='ClaimSummaryLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "ClaimSummaryDynamicLocations") {
            $(elem).parentsUntil(".BranceInput").find("[id$='ClaimSummaryDynamicLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "ChargedSummaryLocations") {
            $(elem).parentsUntil(".BranceInput").find("[id$='ChargedSummaryLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "ChargedSummaryDynamicLocations") {
            $(elem).parentsUntil(".BranceInput").find("[id$='ChargedSummaryDynamicLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "CPTWiseCollectionLocations") {
            $("[id$='CPTWiseCollectionLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "CPTWiseCollectionDynamicLocations") {
            $("[id$='CPTWiseCollectionDynamicLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "LocationsWiseCollectionLocations") {
            $("[id$='LocationsWiseCollectionLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "LocationsWiseDynamicLocations") {
            $("[id$='LocationsWiseDynamicLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "PatientBalanceLocations") {
            $("[id$='PatientBalanceLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });

        }
        if (ULID == "PatientBalanceDynamicLocations") {
            $("[id$='PatientBalanceDynamicLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "ProviderCollectionLocations") {
            $("[id$='ProviderCollectionLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });

        }
        if (ULID == "ProviderCollectionDynamicLocations") {
            $("[id$='ProviderCollectionDynamicLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        if (ULID == "ARAgingSummaryLocations") {
            $("[id$='ARAgingSummaryLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });

        }
        if (ULID == "ARAgingSummaryDynamicLocations") {
            $("[id$='ARAgingSummaryDynamicLocations'] .chk-multi-checkboxes").each(function () {
                if ($(this).is(":checked")) {
                    PlaceOfService += $(this).parent().find("span").html() + ",";
                }
            });
        }
        $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
            debugger
            if ($("#" + SubReportDivName).parentsUntil().find(this).is(":checked")) {
                debugger
                //$('.chk-multi-checkboxes-all').attr('checked', true);
                PlaceOfService += $("#" + SubReportDivName).parentsUntil().find(this).parent().find("span").html() + ",";
            }
        });
        
        if (PlaceOfService.length > 0)
        {
            PlaceOfService = PlaceOfService.slice(0, -1);
        }
        $(elem).closest("#divPracticeLocationId").find(".selectedText").text("");
        var b = $(elem).closest("#divPracticeLocationId").find(".selectedText").val("");

        $(elem).closest("#divPracticeLocationId").find(".selectedText").text(PlaceOfService);
        if (ULID == "ClaimSummaryLocations") {
            if ($(elem).parentsUntil(".BranceInput").find("[id$='ClaimSummaryLocations'] .chk-multi-checkboxes:checked").length == $(elem).parentsUntil(".BranceInput").find("[id$='ClaimSummaryLocations'] .chk-multi-checkboxes").length) {
                $(elem).parentsUntil(".BranceInput").find("#chkClaimSummaryLocationsAll").prop("checked", true);
                $(elem).parentsUntil(".BranceInput").find('#AllLocations').text("All Locations")

            }
            else {
                $(elem).parentsUntil(".BranceInput").find("#chkClaimSummaryLocationsAll").prop("checked", false);

            }
        }
        if (ULID == "ClaimSummaryDynamicLocations") {
            if ($(elem).parentsUntil(".BranceInput").find("[id$='ClaimSummaryDynamicLocations'] .chk-multi-checkboxes:checked").length == $(elem).parentsUntil(".BranceInput").find("[id$='ClaimSummaryDynamicLocations'] .chk-multi-checkboxes").length) {
                $(elem).parentsUntil(".BranceInput").find("#chkClaimSummaryDynamicLocationsAll").prop("checked", true);
                $(elem).parentsUntil(".BranceInput").find('#AllLocations').text("All Locations")

            }
            else {
                $(elem).parentsUntil(".BranceInput").find("#chkClaimSummaryDynamicLocationsAll").prop("checked", false);

            }
        }
        if (ULID == "ChargedSummaryLocations") {
            if ($(elem).parentsUntil(".BranceInput").find("[id$='ChargedSummaryLocations'] .chk-multi-checkboxes:checked").length == $(elem).parentsUntil(".BranceInput").find("[id$='ChargedSummaryLocations'] .chk-multi-checkboxes").length) {
                $(elem).parentsUntil(".BranceInput").find("#chkChargedLocationsAll").prop("checked", true);
                $(elem).parentsUntil(".BranceInput").find('#AllLocations').text("All Locations")

            }
            else {
                $(elem).parentsUntil(".BranceInput").find("#chkChargedLocationsAll").prop("checked", false);

            }
        }
        if (ULID == "ChargedSummaryDynamicLocations") {
            if ($(elem).parentsUntil(".BranceInput").find("[id$='ChargedSummaryDynamicLocations'] .chk-multi-checkboxes:checked").length == $(elem).parentsUntil(".BranceInput").find("[id$='ChargedSummaryDynamicLocations'] .chk-multi-checkboxes").length) {
                $(elem).parentsUntil(".BranceInput").find("#chkChargedSummaryDynamicLocationsAll").prop("checked", true);
                $(elem).parentsUntil(".BranceInput").find('#AllLocations').text("All Locations")

            }
            else {
                $(elem).parentsUntil(".BranceInput").find("#chkChargedSummaryDynamicLocationsAll").prop("checked", false);

            }
        }
        if (ULID == "CPTWiseCollectionDynamicLocations") {
            if ($("[id$='CPTWiseCollectionDynamicLocations'] .chk-multi-checkboxes:checked").length == $("[id$='CPTWiseCollectionDynamicLocations'] .chk-multi-checkboxes").length) {
                $("#chkCPTWiseCollectionDynamicLocationsAll").prop("checked", true);
                $('#AllLocations').text("All Locations")

            }
            else {
                $("#chkCPTWiseCollectionDynamicLocationsAll").prop("checked", false);

            }
        }
        if (ULID == "CPTWiseCollectionLocations") {
            if ($("[id$='CPTWiseCollectionLocations'] .chk-multi-checkboxes:checked").length == $("[id$='CPTWiseCollectionLocations'] .chk-multi-checkboxes").length) {
                $("#chkCPTWiseCollectionLocationAll").prop("checked", true);
                $('#AllLocations').text("All Locations")

            }
            else {
                $("#chkCPTWiseCollectionLocationAll").prop("checked", false);
            }
        }
        if (ULID == "LocationsWiseCollectionLocations") {
            if ($("[id$='LocationsWiseCollectionLocations'] .chk-multi-checkboxes:checked").length == $("[id$='LocationsWiseCollectionLocations'] .chk-multi-checkboxes").length) {
                $("#chkLocationsWiseCollectionLocationAll").prop("checked", true);
                $('#AllLocations').text("All Locations")

            }
            else {
                $("#chkLocationsWiseCollectionLocationAll").prop("checked", false);

            }
        }

        if (ULID == "LocationsWiseDynamicLocations") {
            if ($("[id$='LocationsWiseDynamicLocations'] .chk-multi-checkboxes:checked").length == $("[id$='LocationsWiseDynamicLocations'] .chk-multi-checkboxes").length) {
                $("#chkLocationsWiseDynamicLocationsAll").prop("checked", true);
                $('#AllLocations').text("All Locations")

            }
            else {
                $("#chkLocationsWiseDynamicLocationsAll").prop("checked", false);
            }
        }
        if (ULID == "PatientBalanceLocations") {
            if ($("[id$='PatientBalanceLocations'] .chk-multi-checkboxes:checked").length == $("[id$='PatientBalanceLocations'] .chk-multi-checkboxes").length) {
                $("#chkPatientBalanceLocationAll").prop("checked", true);
                $('#AllLocations').text("All Locations")
            }
            else {
                $("#chkPatientBalanceLocationAll").prop("checked", false);
            }

        }
        if (ULID == "PatientBalanceDynamicLocations") {
            if ($("[id$='PatientBalanceDynamicLocations'] .chk-multi-checkboxes:checked").length == $("[id$='PatientBalanceDynamicLocations'] .chk-multi-checkboxes").length) {
                $("#DynamicPatientBalanceLocationsChkAll").prop("checked", true);
                $('#AllLocations').text("All Locations")
            }
            else {
                $("#DynamicPatientBalanceLocationsChkAll").prop("checked", false);
            }
        }
        if (ULID == "ProviderCollectionLocations") {
            if ($("[id$='ProviderCollectionLocations'] .chk-multi-checkboxes:checked").length == $("[id$='ProviderCollectionLocations'] .chk-multi-checkboxes").length) {
                $("#chkProviderCollectionLocationsAll").prop("checked", true);
                $('#AllLocations').text("All Locations")
            }
            else {
                $("#chkProviderCollectionLocationsAll").prop("checked", false);
            }

        }
        if (ULID == "ProviderCollectionDynamicLocations") {
            if ($("[id$='ProviderCollectionDynamicLocations'] .chk-multi-checkboxes:checked").length == $("[id$='ProviderCollectionDynamicLocations'] .chk-multi-checkboxes").length) {
                $("#DynamicProviderCollectionLocationsChkAll").prop("checked", true);
                $('#AllLocations').text("All Locations")
            }
            else {
                $("#DynamicProviderCollectionLocationsChkAll").prop("checked", false);
            }
        }
        if (ULID == "ARAgingSummaryLocations") {
            if ($("[id$='ARAgingSummaryLocations'] .chk-multi-checkboxes:checked").length == $("[id$='ARAgingSummaryLocations'] .chk-multi-checkboxes").length) {
                $("#chkARAgingSummaryLocationsAll").prop("checked", true);
                $('#AllLocations').text("All Locations")
            }
            else {
                $("#chkARAgingSummaryLocationsAll").prop("checked", false);
            }

        }
        if (ULID == "ARAgingSummaryDynamicLocations") {
            if ($("[id$='ARAgingSummaryDynamicLocations'] .chk-multi-checkboxes:checked").length == $("[id$='ARAgingSummaryDynamicLocations'] .chk-multi-checkboxes").length) {
                $("#DynamicARAgingSummaryLocationsChkAll").prop("checked", true);
                $('#AllLocations').text("All Locations")
            }
            else {
                $("#DynamicARAgingSummaryLocationsChkAll").prop("checked", false);
            }
        }
        debugger
        if (ULID == "ulMultiUnpaidinsurances") {
            if ($("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes:checked").length == $("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").length) {
                $("#chkUnpaidinsurancesAll").prop("checked", true);
                $('#AllUnpaidInsurance').text("All Locations")

            }
            else {
                $("#chkUnpaidinsurancesAll").prop("checked", false);

            }
        }
    }


    else if (ddl == "divPlaceOfService") {
        $("[id$='ulMultiPlaceOfService'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                PlaceOfService += $(this).parent().find("span").html() + ",";
            }
        });
        if (PlaceOfService.length > 0) {

            PlaceOfService = PlaceOfService.slice(0, -1);
        }


        $(elem).closest("#divPlaceOfServiceReport").find(".selectedText").text("");
        var b = $(elem).closest("#divPlaceOfServiceReport").find(".selectedText").val("");

        $(elem).closest("#divPlaceOfServiceReport").find(".selectedText").text(PlaceOfService);

    }

    else if (ddl == "divPayerScenario") {
        var id = "";
        debugger
        $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                PlaceOfService += $(this).parent().find("span").html() + ";";
                InsuranceIds += $.trim($(this).parent().find("#InsuranceId").val() + ",");
            }
        });
        if (PlaceOfService.length > 0) {

            PlaceOfService = PlaceOfService.slice(0, -1);
        }



        if ($("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes:checked").length == $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").length) {
            $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").attr('checked', true);

            $(elem).closest("#divReportPayerScenario").find(".selectedText").text("All Payers");
            $(elem).closest("#divReportPayerScenario").find(".SplitIds").val("");
            $("#SelectInsurances").text("All Payers");

        }
        else {
            $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes-all").attr('checked', false);
            $(elem).closest("#divReportPayerScenario").find(".selectedText").text(PlaceOfService);
            $(elem).closest("#divReportPayerScenario").find(".hdnselectedText").text(PlaceOfService);
            $(elem).closest("#divReportPayerScenario").find(".SplitIds").val(id);
            ids = id;

            $("#SelectInsurances").text(PlaceOfService.substring(0, 35));
        }


    }
    else if (ddl == "divPayerScenarioCustomize") {
        var id = "";
        $("[id$='ulMultiPayerScenario" + Customize[1] + "'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                PlaceOfService += $(this).parent().find("span").html() + ",";
                InsuranceIds += $.trim($(this).parent().find("#InsuranceIdCustomize").val() + ",");
            }
        });
        if (PlaceOfService.length > 0) {

            PlaceOfService = PlaceOfService.slice(0, -1);
        }
        if ($("[id$='ulMultiPayerScenario" + Customize[1] + " '] .chk-multi-checkboxes:checked").length == $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").length) {
            $("[id$='ulMultiPayerScenario" + Customize[1] + "'] .chk-multi-checkboxes-all").attr('checked', true);

            $(elem).closest("#divPayerScenarioCustomize").find(".selectedText").text("All Payers");
            $(elem).closest("#divPayerScenarioCustomize").find(".SplitIds").val("");
            $('#' + Customize[3]).text("All Payers");

        }
        else {
            $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes-all").attr('checked', false);
            $(elem).closest("#divReportPayerScenario").find(".selectedText").text(PlaceOfService);
            $(elem).closest("#divReportPayerScenario").find(".hdnselectedText").text(PlaceOfService);
            $(elem).closest("#divReportPayerScenario").find(".SplitIds").val(id);
            ids = id;
            //$('#' + Customize[3]).text(PlaceOfService.substring(0, 35));
        }


    }
    else if (ddl == "divReportUnpaidinsurances") {
        $("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }
        $(elem).closest("#divReportUnpaidinsurances").find(".selectedText").text("");
        var b = $(elem).closest("#divReportUnpaidinsurances").find(".selectedText").val("");

        $(elem).closest("#divUnpaidinsurances").find(".selectedText").text(UnPaidInsurance);

        if (ULID == "ulMultiUnpaidinsurances") {
            if ($("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes:checked").length == $("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").length) {
                $("#chkUnpaidinsurancesAll").prop("checked", true);
                $('#AllUnpaidInsurance').text("All UnPaid Insurance")

            }
            else {
                $("#chkUnpaidinsurancesAll").prop("checked", false);

            }
        }
    }

    else if (ddl == "divDenailPayerName") {
        var id = "";
        $("[id$='ulMultiDenailPayerName'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
                id += $.trim($(this).parent().find("#PatientId").val() + ",");
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportDenailPayerName").find(".selectedText").text("");
        var b = $(elem).closest("#divReportDenailPayerName").find(".selectedText").val("");

        $(elem).closest("#divReportDenailPayerName").find(".selectedText").val(UnPaidInsurance);
        $(elem).closest("#divReportDenailPayerName").find(".SplitIds").val(id);
    }

    else if (ddl == "divAdjustmentCode") {
        $("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportAdjustmentCode").find(".selectedText").text("");
        var b = $(elem).closest("#divReportAdjustmentCode").find(".selectedText").val("");

        $(elem).closest("#divReportAdjustmentCode").find(".selectedText").text(UnPaidInsurance);

    }
    else if (ddl == "divCalimStatus") {
        $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportClaimStatus").find(".selectedText").text("");
        var b = $(elem).closest("#divReportClaimStatus").find(".selectedText").val("");

        $(elem).closest("#divReportClaimStatus").find(".selectedText").text(UnPaidInsurance);

    }
    else if (ddl == "divFileStatus") {
        var ClaimFiles = "";
        $("[id$='ulMultiFileStatus'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                ClaimFiles += $(this).parent().find(".Filename").text() + ",";
            }
        });
        if (ClaimFiles.length > 0) {

            ClaimFiles = ClaimFiles.slice(0, -1);
        }


        $(elem).closest("#divFileSearch").find(".selectedText").text("");
        var b = $(elem).closest("#divFileSearch").find(".selectedText").val("");

        $(elem).closest("#divFileSearch").find(".selectedText").text(ClaimFiles);

    }
    else if (ddl == "divPatientName") {

        var id = "";

        $("[id$='ulMultiPatientName'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
                id += $.trim($(this).parent().find("#PatientId").val() + ",");
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportPatientName").find(".selectedText").text("");
        var b = $(elem).closest("#divReportPatientName").find(".selectedText").val("");

        $(elem).closest("#divReportPatientName").find(".selectedText").val(UnPaidInsurance);
        $(elem).closest("#divReportPatientName").find(".SplitIds").val(id);

    }


    else if (ddl == "divBilledAs1") {

        debugger
        $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                BilledAs += $(this).parent().find("span").html() + ",";
            }

        });
        if (BilledAs.length > 0) {

            BilledAs = BilledAs.slice(0, -1);
        }
        $(elem).closest("#divReportBilledAs").find(".selectedText").text("");
        var b = $(elem).closest("#divReportBilledAs").find(".selectedText").val("");



        if ($("[id$='ulMultiBilledAs'] .chk-multi-checkboxes:checked").length == $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes").length) {
            $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes-all").attr('checked', true);

            $(elem).closest("#divReportBilledAs").find(".selectedText").text("All");
        }
        else {
            $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes-all").attr('checked', false);
            $(elem).closest("#divReportBilledAs").find(".selectedText").text(BilledAs);

        }


    }
}

function UserNameDDLClick(type) {
    if ($("#Div_MultiUserName").is(":hidden")) {
        $("#Div_MultiUserName").show();
        if (type == "SettingUploadFiles") {
            $("#Div_MultiUserName").css("top", "417px");
            $("#Div_MultiUserName").css("width", "38.7%");
            $("#Div_MultiUserName").css("margin-left", "110px");
        }
    }
    else {
        $("#Div_MultiUserName").hide();
    }
}

function CancelMultiCheckedUserName() {
    debugger;
    $("#Div_MultiUserName").hide();
    $('.MultiCheckBoxUserName').attr('checked', false);
    $('.AllCheckBoxUserName').attr('checked', false);
}
function GetMultiCheckedUserName() {
    var UserNameName = "";

    debugger
    if ($(".AllCheckBoxUserName").is(":checked")) {
        debugger;
        UserNameIds = "";


        $("#Div_MultiUserName").hide();
    }
    else {
        UserNameIds = "";
        $('.MultiCheckBoxUserName').each(function () {

            if ($(this).is(":checked")) {
                debugger;
                UserNameName += $(this).parent().find(".UserNamecheckBoxName").html() + ",";
                UserNameIds += $(this).parent().find(".UserNameId").val() + ",";
            }

        });
        debugger;
        $("#MultipleUserNameTxt").val(UserNameName.substring(0, UserNameName.length - 1));

        $('.MultiCheckBoxUserName').attr('checked', false);
        $("#Div_MultiUserName").hide();
        if (UserNameIds == "") {
            $("#MultipleUserNameTxt").val("All");
        }
    }



}
function ALLCheckBoxUserName() {
    debugger
    if ($(".AllCheckBoxUserName").is(":checked")) {
        $('.MultiCheckBoxUserName').attr('checked', true);
        $("#MultipleUserNameTxt").val("All");
    }
    else {
        $('.MultiCheckBoxUserName').attr('checked', false);
    }
}
function checkAllCheckBoxUserNameISCheked(elem) {
    debugger;
    if ($('.MultiCheckBoxUserName:checked').length == $('.MultiCheckBoxUserName').length) {
        $('.AllCheckBoxUserName').attr('checked', true);
        $("#MultipleUserNameTxt").val("All");
    }
    else {
        $('.AllCheckBoxUserName').attr('checked', false);
    }
}


function filesearchfunction(e) {
    debugger;
    if (window.event)
        code = e.keyCode;
    else code = e.which;


    if (code == 13 || code == 32 || (code >= 97 && code <= 122) || (code >= 65 && code <= 90) || code >= 48 && code <= 57) {
        debugger
        var search = $("[id$='txtFileSearch']").val();


        $.post("../ReportsNew/CallBacks/ClaimFileSearch.aspx", { FileName: search })

            .promise()
            .done(function (data) {
                debugger;
                var start = data.indexOf("###StartSearchFile###") + 21;
                var end = data.indexOf(" ###EndSearchFile###");
                var returnHtml = $.trim(data.substring(start, end));
                $("#FileSearchdiv").html(returnHtml);
                $("#FileSearchdiv").show();
            });
    }
}

function CloseFileSearchDiv() {
    $("#FileSearchdiv").hide();
    if (UserNameIds == "") {
        $("#MultipleUserNameTxt").val("All");
    }
}



$(document).on('click', function (e) {

    /// Asad Mehmood Identification of document click on which dropdown is removed
    if ($(e.target).closest(".reportdropdown").length === 0) {
        if ($(".ddlselect").is(":visible")) {
            $("#" + _divMultipleDropdownCheckboxList).slideToggle();
            //$(".ddlselect").slideToggle();
        }

    }

    var rbChk = $("input[name='radioGroup']:checked").val();
    if (rbChk == "Summary") {
        $("#divDetails").hide();
        $("#divSummary").show();
        $("[id$='ddlInsuranceType']").attr('disabled', 'disabled');
        $("[id$='ddlPostType']").attr('disabled', 'disabled');
        $("#divReportDenailPayerName").find('a').removeAttr("onclick");
    }
    else {
        $("#divSummary").hide();
        $("#divDetails").show();
        $("[id$='ddlInsuranceType']").attr('disabled', false);
        $("[id$='ddlPostType']").attr('disabled', false);
        $("#divReportDenailPayerName").find('a').attr("onclick", "hideShowMenu('divDenailPayerName');");
    }
});
//Added By Syed Sajid Ali date:09/07/2018 Des:Search Multiple File
function selectedFile(elem) {
    debugger;
    $("[id$='FilterReports']").prop("disabled", false);
    var fileName = "";
    debugger;
    fileName += $.trim($(elem).find(".hdnname").html()) + ",";
    var fileName1 = "";
    $('.MultichkFileStatus').each(function () {

        debugger;
        fileName1 = $(this).parent().find(".Filename").html() + ",";
        if (fileName == fileName1) {
            $(this).parent().find(".MultichkFileStatus").prop('checked', true);
        }
    });
    debugger
    var fileName2 = "";
    if ($(".AllCheckBoxUserName").is(":checked")) {
        debugger;
        UserNameIds = "";


        $("#Div_MultiUserName").hide();
    }
    else {
        $('.MultichkFileStatus').each(function () {

            if ($(this).is(":checked")) {
                debugger;
                fileName2 += $(this).parent().find(".Filename").html() + ", ";
            }

        });
        $("#divFileSearch .selectedText").text(fileName2.substring(0, fileName2.length - 1));
        $("#FileSearchdiv").hide();
    }
    $("#txtFileSearch").val("");
}
//End By Syed Sajid Ali

//Added By Daniyal_Baig 13Dec2018
function DefaultChkbox() {
    debugger;
    if ($("#ChkDeductable").is(':checked') || $("#ChkCoInsurance").is(':checked') || $("#ChkCoPayment").is(':checked')) {
        $('#all').prop('checked', false);
    }
}
//End
function ALLCheckBoxStatus() {

    if ($(".AllCheckBoxStatus").is(":checked")) {
        $('.MultiCheckBoxStatus').attr('checked', true);
        $("#MultipleUserNameTxt").val("All");
    }
    else {
        $('.MultiCheckBoxStatus').attr('checked', false);
    }
}
function checkAllCheckBoxUserNameISChekedCPT(elem) {
    debugger;
    if ($('.MultiCheckBoxStatus:checked').length == $('.MultiCheckBoxStatus').length) {
        $('.AllCheckBoxStatus').attr('checked', true);
        $("#MultipleUserNameTxt").val("All");
    }
    else {
        $('.AllCheckBoxStatus').attr('checked', false);
    }
}
function GetMultiCheckedStatusCPT() {

    debugger

    if ($(".AllCheckBoxStatus").is(":checked")) {

        var StatusIds = "";

        $("#Div_MultiStatus").hide();
    }
    else {
        StatusIds = "";
        $('.MultiCheckBoxStatus').each(function () {

            if ($(this).is(":checked")) {
                debugger
                _CPTCode += $(this).parent().find(".StatuscheckBoxName").html() + ",";
                StatusIds += $(this).parent().find(".StatuscheckBoxDescription").html() + ",";
            }

        });

        $("#MultipleStatusTxt").val(_CPTCode);
        $("#MultipleStatusDesc").val(StatusIds);

        $('.MultiCheckBoxStatus').attr('checked', false);
        $("#divCPTSearchedReport").hide();
    }

}
function CancelMultiCheckedStatus() {

    $("#divCPTSearchedReport").hide();
    $('.MultiCheckBoxStatus').attr('checked', false);
    $('.AllCheckBoxStatus').attr('checked', false);
}

function SearchCheck(event, elem, Customize) {
    debugger;
    var a = event.which || event.keyCode;
    var Serviecode = $.trim($(elem).val()) || "";
    if (Serviecode == "") { $(".divChecklist").hide(); return };
    if (a == 13) {
        if (Customize == "Customize") {
            searchCheckCustomize(elem);
        } else {
            searchCheck(elem);

        }
    }


}

function searchCheck(elem) {
    var checknumber = $.trim($(elem).val());
    $.post('filter/FilterUnpostedPaymentsDetailandSummary.aspx', { Action: 'searchCheck', Checknumber: checknumber }, function (data) {
        var start = data.indexOf("###StartsearchCheckNumber###") + 28;
        var end = data.indexOf("###EndsearchCheckNumber###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".divChecklist").html(returnHtml);
        $(".divChecklist").show();
    });
}
function searchCheckCustomize(elem) {
    var checknumber = $.trim($(elem).val());
    $.post('filter/FilterUnpostedPaymentsDetailandSummary.aspx', { Action: 'searchCheckCus', Checknumber: checknumber }, function (data) {
        var start = data.indexOf("###StartsearchCheckNumberCus###") + 31;
        var end = data.indexOf("###EndsearchCheckNumberCus###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".divChecklistCustomize").html(returnHtml);
        $(".divChecklistCustomize").show();
    });
}
function selectchecknumberCustomize(elem) {
    debugger
    var checknumber = $(elem).find('.spnchecknumber').text();
    $("#txtsearchcheckCustomize").val(checknumber);
    $(".divChecklistCustomize").hide();
}
function txtsearchcheckCustomize(elem) {

    var checknumber = $(elem).find('.spnchecknumber').text();
    $("#txtsearchcheckCustomize").val(checknumber);
    $(".divChecklistCustomize").hide();
}

function UnpostedPaymentDetail(payertype, elem) {
    debugger;
    var Title = "";
    var PayerType = payertype;
    var amount = $(elem).closest('tr').find(".tdunpostedpayment").text();
    if (PayerType == "Insurance") {
        PayerType = "Insurance";
        Title = "Insurance Unposted Payments Detail";

        $("[id$='totalcheckAmount']").text(amount);
    }
    else if (PayerType == "Patient") {
        PayerType = "Patient";
        Title = "Patient Unposted Payments Detail";

        $("[id$='totalcheckAmount']").text(amount);
    }
    else { return; }

    $("." + PayerType).each(function () {

        $("." + PayerType).show();
    });

    $("#dialogue_UnpostedPayment").css("display", "block");

    $("#dialogue_UnpostedPayment").dialog({
        width: 1060,
        // height:700,
        modal: true,
        title: Title,
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                $("." + PayerType).hide();
                $(this).dialog("destroy");
                $("#dialogue_UnpostedPayment").hide();

            }
        },
        close: function () {
            $("." + PayerType).hide();
            $(this).dialog("destroy");
            $("#dialogue_UnpostedPayment").hide();

        }
    });
}

function showErrorMessageReport(mesg) {

    $(".divMesgAlert").css({ 'background-color': 'PinK', 'padding': '5px' });
    $(".divMesgAlert").stop().fadeOut();
    if (mesg != "") {
        $(".divMesgAlert").html(mesg).removeClass("success").addClass("warning").fadeIn(2000).fadeOut(2000);
    } else {
        $(".divMesgAlert").html("Error: Please review the form carefully for the errors.").removeClass("success").addClass("warning").fadeIn(2000).fadeOut(10000);
    }
}
function ChangeReportType(elem) {
    //$(elem).parents(".SearchCriteria").find("#FilterReports").prop("disabled", false);
    var ReportType = $("#ddlReportType option:selected").val();
    if (ReportType == "CLMLevel") {
        $("[id$='txtServiceCode']").attr("disabled", "disabled");
    }
    else if (ReportType == "PROLevel") {
        $("[id$='txtServiceCode']").removeAttr("disabled");
    }
}
function ChangeReportTypeCustomize(elem) {
    //$(elem).parents(".SearchCriteria").find("#FilterReports").prop("disabled", false);
    var ReportType = $("#ddlReportTypeCustomize option:selected").val();
    if (ReportType == "CLMLevel") {
        $("[id$='txtServiceCode']").attr("disabled", "disabled");
    }
    else if (ReportType == "PROLevel") {
        $("[id$='txtServiceCode']").removeAttr("disabled");
    }
}
function FilterClaimSummaryAndDetail(Customize) {
    $(".message").hide();
    var DateFrom = '';
    var DateTo = '';
    var StaffNPI = "";
    var PracticeLocationId = "";
    var DateType = "";
    var SelectDate = "";
    var ClaimStatus = "";
    var Insurance = "";
    var MultipleClaims = "";
    var MultipleCPTs = "";
    var BillAs = "";


    var GroupBy = $("#ddlGroupBy").val();
    debugger
    MultipleClaims = $(".SelectedClaims").map(function () {
        return $(this).text();
    }).get().join(',');
    MultipleCPTs = $(".spnservicecode").map(function () {
        return $(this).text();
    }).get().join(',');
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus += $.trim($(this).val() + ",");
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Insurance += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Insurance = "";
        }
    });
    if (GroupBy == "Provider") {
        $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryProviders'] #chkClaimSummaryProviders").each(function () {
            if ($(this).is(":checked")) {
                StaffNPI += $(this).val() + ",";
            }
        });

        if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkClaimSummaryProvidersAll']").is(':checked')) {
            StaffNPI = '';
        }
        $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryDynamicLocations'] #chkClaimSummaryDynamicLocations").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryDynamicLocations'] #chkClaimSummaryDynamicLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
    }
    else {
        $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryLocations'] #chkClaimSummaryLocations").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });

        $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryLocations'] #chkClaimSummaryLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });

        $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryDynamicProvider'] #DynamicClaimSummaryProviderChk").each(function () {
            if ($(this).is(":checked")) {
                StaffNPI += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryDynamicProvider'] #DynamicClaimSummaryProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                StaffNPI = ""
            }
        });
    }
    if (StaffNPI.length > 0) {
        StaffNPI = StaffNPI.slice(0, -1);
    }
    if (Insurance.length > 0) {
        Insurance = Insurance.slice(0, -1);
    }
    if (ClaimStatus.length > 0) {
        ClaimStatus = ClaimStatus.slice(0, -1);
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        BillAs = $("#BillAs").val();

        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();


    } else {
        DateType = $("#" + SubReportDivName).find('[id$="ddlPostType"] option:selected').val();
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }


    $.post('CallBacks/ClaimSummaryAndDetail.aspx', {
        action: "FilterClaimSummary", DateType: DateType,
        ProviderId: StaffNPI, PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo,
        Insurance: Insurance,
        ClaimStatus: ClaimStatus, MultipleClaims: MultipleClaims, MultipleCPTs: MultipleCPTs, BillAs: BillAs
    }, function (data) {
        debugger
        var result = "";
        var start = data.indexOf("###Filter###") + 12;
        var end = data.indexOf("###End###");
        result = $.trim(data.substring(start, end));
        $(".ClaimSummmaryAndDetails").html(result).show();
        $("#ReportDateFrom").attr("disabled", "disabled")
        $("#ReportDateTo").attr("disabled", "disabled")
        if ($(".ClaimSummmaryAndDetails").find("tr").html() == "" || $(".ClaimSummmaryAndDetails").find("tr").html() == undefined) {
            $(".message").html("No Record Found, Please change search criteria").show();
        }
        debugger
        /*Edited By Faiza Bilal 3-24-2022 to get checkboxes checked */
        SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
        $("#" + filename2).empty();

        $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + '</div>');
        var dateArF = DateFrom.split('-');
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = DateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $("#" + SubReportDivName).find('[id$="CustomizeDateFrom"]').val(DateFrom);
        $("#" + SubReportDivName).find('[id$="CustomizeDateTo"]').val(DateTo);
        $("#" + SubReportDivName).find('[id$="DateFrom"]').val(DateFrom);
        $("#" + SubReportDivName).find('[id$="DateTo"]').val(DateTo);
        $("[id$='txtDateFrom']").text(newDateFrom);
        $("[id$='txtDateTo']").text(newDateTo);
        $("#BillAs").val(BillAs);
        $('[id$="ddlPostTypeCustomize"] option:selected').val(DateType);
        $("#" + SubReportDivName).find('[id$="ddlPostType"] option:selected').val(DateType);
        $("#" + SubReportDivName).find("#ddlSelectDateCustomize").val(SelectDate);
        $("#" + SubReportDivName).find("#ddlSelectDate").val(SelectDate);
        //ShowHideMenu();
        //$("[id$='FilterReports']").prop("disabled", true);
        // $(elem).parent().parent().parent().parent().parent().find("#FilterReports").prop("disabled", true);
        $(".TimeSpan").css("display", "block");
    });
    /*Added By faiza Bilal 3-24-2022*/
    TimeSpanClaimAndSum = TimeSpan;
    DateFromClaimAndSum = DateFrom;
    DateToClaimAndSum = DateTo;
    /*End Added By faiza Bilal 3-24-2022*/

}

var PracticeLocationId = "";


/*added by ifraheem mahmood*/

function FilterLocationWiseCollection(Customize) {
    debugger
    $(".message").hide();
    var DateFrom = '';
    var DateTo = '';
    var TimeSpan = "";
    var ProviderId = "";
    var PracticeLocationId = "";
    var DateType = "";
    var Group = $("#ddlGroupBy").val();
    var SelectDate = "";
    var InsuranceID = ""
    var Rows1 = $("#ddlPaging").val();
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });
    if (Group == "Provider") {
        $("#" + SubReportDivName).parentsUntil().find("[id$='LocationsWiseDynamicLocations'] #LocationsWiseDynamicProviderChk").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='LocationsWiseDynamicLocations'] #DynamicLocationsWiseLocationsChkAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });

        $("#" + SubReportDivName).parentsUntil().find("[id$='LocationsWiseProviders'] #chkLocationsWiseProviders").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='LocationsWiseProviders'] #chkLocationsWiseProvidersAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });

    } else {
        $("#" + SubReportDivName).parentsUntil().find("[id$='LocationsWiseCollectionLocations'] #chkLocationsWiseCollectionLocation").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='LocationsWiseCollectionLocations'] #chkLocationsWiseCollectionLocationAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });

        $("#" + SubReportDivName).parentsUntil().find("[id$='LocationsWiseCollectionDynamicProvider'] #LocationsWiseDynamicProviderChk").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='LocationsWiseCollectionDynamicProvider'] #DynamicLocationsWiseDynamicProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });

    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    if (Customize == "Customize") {

        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
    }
    else {
        DateType = $("#" + SubReportDivName).find('[id$="ddlPostType"] option:selected').val();
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }
    params = {
        DateType: DateType,
        ProviderId: ProviderId, PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo, InsuranceID: InsuranceID, Rows: Rows1, PageNumber : 0
    }
    Report_ReloadData("FilterLocationwisecollection.aspx", params, true)

    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);

    $("#ddlSelectDateCustomize").val(SelectDate);
    $("#ddlSelectDate").val(SelectDate);
    //$.post('CallBacks/Locationwisecollection.aspx', {
    //    action: "FilterLocationWiseCollection", DateTypeLocation: DateTypeLocation,
    //    ProviderId: ProviderId, PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo, InsuranceID: InsuranceID
    //}, function (data) {
    //    debugger
    //    var result = "";
    //    var start = data.indexOf("###StartTbody###") + 16;
    //    var end = data.indexOf("###EndTbody###");
    //    result = $.trim(data.substring(start, end));

    //    $(".tbodyLocationWiseCollection").html(result);

    //    if ($(".tbodyLocationWiseCollection").find("tr").html() == "" || $(".tbodyLocationWiseCollection").find("tr").html() == undefined) {
    //        $(".message").html("No Record Found, Please change search criteria").show();
    //    }
    //    //$("#locationwise").remove();
    //    var dateArF = DateFrom.split('-');
    //    var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
    //    var dateArT = DateTo.split('-');
    //    var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
    //    $("[id$='txtDateFrom']").text(newDateFrom);
    //    $("[id$='txtDateTo']").text(newDateTo);
    //    $("#TimeSpan").show();
    //    $("[id$='LocationReportDateFrom']").val(DateFrom);
    //    $("[id$='LocationReportDateTo']").val(DateTo);
    //    $("#ddlSelectDateCustomize").val(SelectDate)
    //    $("#ddlSelectDate").val(SelectDate)

    //});
    ///*Added By faiza Bilal 3-24-2022*/
    //TimeSpanLocWise = TimeSpan;
    //DateFromLocWise = DateFrom;
    //DateToLocWise = DateTo;
    ///*End Added By faiza Bilal 3-24-2022*/

}


function GetPracticeStaffLocation(Value) {
    debugger
    var PracticeLocationId = "";
    $("[id$='" + Value + "'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).val() + ",";
        }
    });
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    $("[id$='" + Value + "'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });

    $.post('CallBacks/DynamicLocationProviderDDL.aspx', { action: "FilterProviders", PracticeLocationId: PracticeLocationId }, function (data) {
        debugger
        var result = "";
        var start = data.indexOf("###Providers###") + 15;
        var end = data.indexOf("###ProvidersEND###");
        result = $.trim(data.substring(start, end));

        $('#AllProviders').text("All Providers")
        if (Value == "ClaimSummaryLocations") {
            $(".ClaimSummaryDynamicProviders").html(result).show();
            $(".ClaimSummaryDynamicProviders  ul").attr("id", "ClaimSummaryDynamicProvider")
            $("[id$='ClaimSummaryDynamicProvider'] .AddDynamicFunctionsAllProviders").attr("id", "DynamicClaimSummaryProviderChkAll")
            $("[id$='ClaimSummaryDynamicProvider'] .AddDynamicFunctionsAllProviders").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ClaimSummaryDynamicProvider')")
            $("[id$='ClaimSummaryDynamicProvider'] .AddDynamicFunctionsProviders").attr("onclick", "ReportAlert(this,'ClaimSummaryDynamicProvider')")
            $("[id$='ClaimSummaryDynamicProvider'] .AddDynamicFunctionsProviders").attr("id", "DynamicClaimSummaryProviderChk")

        }
        if (Value == "ChargedSummaryLocations") {
            $(".ChargedSummaryDynamicProviders").html(result).show();
            $(".ChargedSummaryDynamicProviders  ul").attr("id", "ChargedSummaryDynamicProvider")
            $("[id$='ChargedSummaryDynamicProvider'] .AddDynamicFunctionsAllProviders").attr("id", "DynamicChargedSummaryProviderChkAll")
            $("[id$='ChargedSummaryDynamicProvider'] .AddDynamicFunctionsAllProviders").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ChargedSummaryDynamicProvider')")
            $("[id$='ChargedSummaryDynamicProvider'] .AddDynamicFunctionsProviders").attr("onclick", "ReportAlert(this,'ChargedSummaryDynamicProvider')")
            $("[id$='ChargedSummaryDynamicProvider'] .AddDynamicFunctionsProviders").attr("id", "DynamicChargedSummaryProviderChk")

        }
        if (Value == "CPTWiseCollectionLocations") {
            $(".CPTWiseCollectionDynamicProviders").html(result).show();
            $(".CPTWiseCollectionDynamicProviders  ul").attr("id", "CPTWiseCollectionDynamicProvider")
            $("[id$='CPTWiseCollectionDynamicProvider'] .AddDynamicFunctionsAllProviders").attr("id", "DynamicCPTWiseDynamicProviderChkAll")
            $("[id$='CPTWiseCollectionDynamicProvider'] .AddDynamicFunctionsAllProviders").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'CPTWiseDynamicProviders')")
            $("[id$='CPTWiseCollectionDynamicProvider'] .AddDynamicFunctionsProviders").attr("onclick", "ReportAlert(this,'CPTWiseDynamicProviders')")
            $("[id$='CPTWiseCollectionDynamicProvider'] .AddDynamicFunctionsProviders").attr("id", "DynamicCPTWiseProviderChk")
        }
        if (Value == "LocationsWiseCollectionLocations") {
            $(".LocationsWiseCollectionDynamicProviders").html(result).show();
            $(".LocationsWiseCollectionDynamicProviders  ul").attr("id", "LocationsWiseCollectionDynamicProvider")
            $("[id$='LocationsWiseCollectionDynamicProvider'] .AddDynamicFunctionsAllProviders").attr("id", "DynamicLocationsWiseDynamicProviderChkAll")
            $("[id$='LocationsWiseCollectionDynamicProvider'] .AddDynamicFunctionsAllProviders").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'LocationsWiseDynamicProviders')")
            $("[id$='LocationsWiseCollectionDynamicProvider'] .AddDynamicFunctionsProviders").attr("onclick", "ReportAlert(this,'LocationsWiseDynamicProviders')")
            $("[id$='LocationsWiseCollectionDynamicProvider'] .AddDynamicFunctionsProviders").attr("id", "LocationsWiseDynamicProviderChk")
        }
        if (Value == "PatientBalanceLocations") {
            $(".PatientBalanceDynamicProviders").html(result).show();
            $(".PatientBalanceDynamicProviders  ul").attr("id", "PatientBalanceDynamicProviders")
            $("[id$='PatientBalanceDynamicProviders'] .AddDynamicFunctionsAllProviders").attr("id", "DynamicPatientBalanceProviderChkAll")
            $("[id$='PatientBalanceDynamicProviders'] .AddDynamicFunctionsAllProviders").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'PatientBalanceDynamicProviders')")
            $("[id$='PatientBalanceDynamicProviders'] .AddDynamicFunctionsProviders").attr("onclick", "ReportAlert(this,'PatientBalanceDynamicProviders')")
            $("[id$='PatientBalanceDynamicProviders'] .AddDynamicFunctionsProviders").attr("id", "PatientBalanceDynamicProviderChk")
        }
        if (Value == "ProviderCollectionLocations") {
            $(".ProviderCollectionDynamicProviders").html(result).show();
            $(".ProviderCollectionDynamicProviders  ul").attr("id", "ProviderCollectionDynamicProviders")
            $("[id$='ProviderCollectionDynamicProviders'] .AddDynamicFunctionsAllProviders").attr("id", "DynamicProviderCollectionProviderChkAll")
            $("[id$='ProviderCollectionDynamicProviders'] .AddDynamicFunctionsAllProviders").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ProviderCollectionDynamicProviders')")
            $("[id$='ProviderCollectionDynamicProviders'] .AddDynamicFunctionsProviders").attr("onclick", "ReportAlert(this,'ProviderCollectionDynamicProviders')")
            $("[id$='ProviderCollectionDynamicProviders'] .AddDynamicFunctionsProviders").attr("id", "ProviderCollectionDynamicProviderChk")
        }
        if (Value == "ARAgingSummaryLocations") {
            $(".ARAgingSummaryDynamicProviders").html(result).show();
            $(".ARAgingSummaryDynamicProviders  ul").attr("id", "ARAgingSummaryDynamicProviders")
            $("[id$='ARAgingSummaryDynamicProviders'] .AddDynamicFunctionsAllProviders").attr("id", "DynamicARAgingSummaryProviderChkAll")
            $("[id$='ARAgingSummaryDynamicProviders'] .AddDynamicFunctionsAllProviders").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ARAgingSummaryDynamicProviders')")
            $("[id$='ARAgingSummaryDynamicProviders'] .AddDynamicFunctionsProviders").attr("onclick", "ReportAlert(this,'ARAgingSummaryDynamicProviders')")
            $("[id$='ARAgingSummaryDynamicProviders'] .AddDynamicFunctionsProviders").attr("id", "ARAgingSummaryDynamicProviderChk")
        }

    });
}
function GetLocationNamePracticestaff(Value) {
    debugger
    var NPI = "";

    $("[id$='" + Value + "'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            NPI += $(this).val() + ",";
        }
    });
    $("[id$='" + Value + "'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            NPI = "";
        }
    });
    $.post('CallBacks/DynamicLocationProviderDDL.aspx', { action: "FilterLocations", NPI: NPI }, function (data) {
        debugger
        var result = "";
        var start = data.indexOf("###Locations###") + 15;
        var end = data.indexOf("###LocationsEND###");
        result = $.trim(data.substring(start, end));


        if (Value == "CPTWiseCollectionProviders") {
            $(".CPTWiseCollectionDynamicLocations").html(result).show();
            $(".CPTWiseCollectionDynamicLocations ul").attr("id", "CPTWiseCollectionDynamicLocations")
            $("#CPTWiseCollectionDynamicLocations .AddDynamicFunctionsLocations").attr("id", "chkCPTWiseCollectionDynamicLocations")
            $("#CPTWiseCollectionDynamicLocations .chk-multi-checkboxes-all").attr("id", "chkCPTWiseCollectionDynamicLocationsAll")
            $("#CPTWiseCollectionDynamicLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'CPTWiseCollectionDynamicLocations')")
            $("#CPTWiseCollectionDynamicLocations .AddDynamicFunctionsLocations").attr("onclick", "ReportAlert(this,'CPTWiseCollectionDynamicLocations')")
        }
        if (Value == "ClaimSummaryProviders") {
            $(".ClaimSummaryDynamicLocations ").html(result).show();
            $(".ClaimSummaryDynamicLocations  ul").attr("id", "ClaimSummaryDynamicLocations")
            $("#ClaimSummaryDynamicLocations  .AddDynamicFunctionsLocations").attr("id", "chkClaimSummaryDynamicLocations")
            $("#ClaimSummaryDynamicLocations  .chk-multi-checkboxes-all").attr("id", "chkClaimSummaryDynamicLocationsAll")
            $("#ClaimSummaryDynamicLocations  .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ClaimSummaryDynamicLocations')")
            $("#ClaimSummaryDynamicLocations  .AddDynamicFunctionsLocations").attr("onclick", "ReportAlert(this,'ClaimSummaryDynamicLocations')")
        }
        if (Value == "ChargedSummaryProviders") {
            $(".ChargedSummaryDynamicLocations ").html(result).show();
            $(".ChargedSummaryDynamicLocations  ul").attr("id", "ChargedSummaryDynamicLocations")
            $("#ChargedSummaryDynamicLocations  .AddDynamicFunctionsLocations").attr("id", "chkChargedSummaryDynamicLocations")
            $("#ChargedSummaryDynamicLocations  .chk-multi-checkboxes-all").attr("id", "chkChargedSummaryDynamicLocationsAll")
            $("#ChargedSummaryDynamicLocations  .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ChargedSummaryDynamicLocations')")
            $("#ChargedSummaryDynamicLocations  .AddDynamicFunctionsLocations").attr("onclick", "ReportAlert(this,'ChargedSummaryDynamicLocations')")
        }
        if (Value == "LocationsWiseProviders") {
            $(".LocationsWiseCollectionDynamicLocations ").html(result).show();
            $(".LocationsWiseCollectionDynamicLocations  ul").attr("id", "LocationsWiseDynamicLocations")
            $("#LocationsWiseDynamicLocations  .AddDynamicFunctionsLocations").attr("id", "LocationsWiseDynamicProviderChk")
            $("#LocationsWiseDynamicLocations  .chk-multi-checkboxes-all").attr("id", "chkLocationsWiseDynamicLocationsAll")
            $("#LocationsWiseDynamicLocations  .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'LocationsWiseDynamicLocations')")
            $("#LocationsWiseDynamicLocations  .AddDynamicFunctionsLocations").attr("onclick", "ReportAlert(this,'LocationsWiseDynamicLocations')")
        }
        if (Value == "PatientBalanceProviders") {
            $(".PatientBalanceDynamicLocations ").html(result).show();
            $(".PatientBalanceDynamicLocations  ul").attr("id", "PatientBalanceDynamicLocations")
            $("#PatientBalanceDynamicLocations  .AddDynamicFunctionsLocations").attr("id", "PatientBalanceLocationsChk")
            $("#PatientBalanceDynamicLocations  .chk-multi-checkboxes-all").attr("id", "DynamicPatientBalanceLocationsChkAll")
            $("#PatientBalanceDynamicLocations  .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'PatientBalanceDynamicLocations')")
            $("#PatientBalanceDynamicLocations  .AddDynamicFunctionsLocations").attr("onclick", "ReportAlert(this,'PatientBalanceDynamicLocations')")
        }
        if (Value == "ProviderCollectionProviders") {
            $(".ProviderCollectionDynamicLocations").html(result).show();
            $(".ProviderCollectionDynamicLocations  ul").attr("id", "ProviderCollectionDynamicLocations")
            $("#ProviderCollectionDynamicLocations .AddDynamicFunctionsLocations").attr("id", "ProviderCollectionLocationsChk")
            $("#ProviderCollectionDynamicLocations .chk-multi-checkboxes-all").attr("id", "DynamicProviderCollectionLocationsChkAll")
            $("#ProviderCollectionDynamicLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ProviderCollectionDynamicLocations')")
            $("#ProviderCollectionDynamicLocations .AddDynamicFunctionsLocations").attr("onclick", "ReportAlert(this,'ProviderCollectionDynamicLocations')")

        }
        if (Value == "ARAgingSummaryProviders") {
            $(".ARAgingSummaryDynamicLocations").html(result).show();
            $(".ARAgingSummaryDynamicLocations  ul").attr("id", "ARAgingSummaryDynamicLocations")
            $("#ARAgingSummaryDynamicLocations .AddDynamicFunctionsLocations").attr("id", "ARAgingSummaryLocationsChk")
            $("#ARAgingSummaryDynamicLocations .chk-multi-checkboxes-all").attr("id", "DynamicARAgingSummaryLocationsChkAll")
            $("#ARAgingSummaryDynamicLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ARAgingSummaryDynamicLocations')")
            $("#ARAgingSummaryDynamicLocations .AddDynamicFunctionsLocations").attr("onclick", "ReportAlert(this,'ARAgingSummaryDynamicLocations')")

        }
        $('#AllLocations').text("All locations")
    });
}


function EnableDisableGroup(value, elem) {
    debugger
    var Group = $("#ddlGroupBy option:selected").val();
    var divPracticeLocationId = ""
    var divReportServiceProvider = ""
    $(elem).parents(".SearchCriteria").find("#FilterReports").prop("disabled", false);
    if (Group == "Location") {
        $.post('CallBacks/DynamicLocationProviderDDL.aspx', { action: "LoadDDLLocation" }, function (data) {
            debugger
            var result = "";
            var start = data.indexOf("###StartFilterLocation###") + 25;
            var end = data.indexOf("###EndFilterLocation###");
            result = $.trim(data.substring(start, end));
            if (value == "CPTWiseCollection") {
                $(".CPTWiseCollectionLocations").html(result).show();
                $(".CPTWiseCollectionLocations ul").attr("id", "CPTWiseCollectionLocations")
                $("#CPTWiseCollectionLocations .chk-multi-checkboxes").attr("class", "chk-multi-checkboxes CPTWiseCollectionLocations")
                $("#CPTWiseCollectionLocations .chk-multi-checkboxes").attr("id", "chkCPTWiseCollectionLocations")
                $("#CPTWiseCollectionLocations .chk-multi-checkboxes-all").attr("id", "chkCPTWiseCollectionLocationAll")
                $("#CPTWiseCollectionLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'CPTWiseCollectionLocations'),GetPracticeStaffLocation('CPTWiseCollectionLocations')")
                $("#CPTWiseCollectionLocations .chk-multi-checkboxes").attr("onclick", "ReportAlert(this,'CPTWiseCollectionLocations'),GetPracticeStaffLocation('CPTWiseCollectionLocations')")
                $(".CPTWiseCollectionDynamicProviders   *").prop('checked', false);
                $(".CPTWiseCollectionDynamicProviders   *").prop('disabled', true);
                $(".CPTWiseCollectionLocations   *").prop('checked', false);
                $(".CPTWiseCollectionLocations   *").prop('disabled', false);
            }
            if (value == "ClaimSummary") {
                $(".ClaimSummaryLocations").html(result).show();
                $(".ClaimSummaryLocations ul").attr("id", "ClaimSummaryLocations")
                $("#ClaimSummaryLocations .chk-multi-checkboxes").attr("class", "chk-multi-checkboxes ClaimSummaryLocations")
                $("#ClaimSummaryLocations .chk-multi-checkboxes").attr("id", "chkClaimSummaryLocations")
                $("#ClaimSummaryLocations .chk-multi-checkboxes-all").attr("id", "chkClaimSummaryLocationsAll")
                $("#ClaimSummaryLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ClaimSummaryLocations'),GetPracticeStaffLocation('ClaimSummaryLocations')")
                $("#ClaimSummaryLocations .chk-multi-checkboxes").attr("onclick", "ReportAlert(this,'ClaimSummaryLocations'),GetPracticeStaffLocation('ClaimSummaryLocations')")
                $("#ClaimSummaryProviders *").prop('checked', false);
                $("#ClaimSummaryProviders *").prop('disabled', true);
            }
            if (value == "ChargedSummary") {
                $(".ChargedSummaryLocations").html(result).show();
                $(".ChargedSummaryLocations ul").attr("id", "ChargedSummaryLocations")
                $("#ChargedSummaryLocations .chk-multi-checkboxes").attr("class", "chk-multi-checkboxes ChargedSummaryLocations")
                $("#ChargedSummaryLocations .chk-multi-checkboxes").attr("id", "chkChargedSummaryLocations")
                $("#ChargedSummaryLocations .chk-multi-checkboxes-all").attr("id", "chkClaimSummaryLocationsAll")
                $("#ChargedSummaryLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ChargedSummaryLocations'),GetPracticeStaffLocation('ChargedSummaryLocations')")
                $("#ChargedSummaryLocations .chk-multi-checkboxes").attr("onclick", "ReportAlert(this,'ChargedSummaryLocations'),GetPracticeStaffLocation('ChargedSummaryLocations')")
                $("#ChargedSummaryLocations *").prop('checked', false);
                $("#ChargedSummaryLocations *").prop('disabled', true);
            }
            if (value == "LocationWiseCollection") {
                $(".LocationsWiseCollectionLocations").html(result).show();
                $(".LocationsWiseCollectionLocations ul").attr("id", "LocationsWiseCollectionLocations")
                $("#LocationsWiseCollectionLocations .chk-multi-checkboxes").attr("id", "chkLocationsWiseCollectionLocation")
                $("#LocationsWiseCollectionLocations .chk-multi-checkboxes-all").attr("id", "chkLocationsWiseCollectionLocationAll")
                $("#LocationsWiseCollectionLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'LocationsWiseCollectionLocations'),GetPracticeStaffLocation('LocationsWiseCollectionLocations')")
                $("#LocationsWiseCollectionLocations .chk-multi-checkboxes").attr("onclick", "ReportAlert(this,'LocationsWiseCollectionLocations'),GetPracticeStaffLocation('LocationsWiseCollectionLocations')")
                $("#LocationsWiseProviders *").prop('checked', false);
                $("#LocationsWiseProviders *").prop('disabled', true);
                $(".LocationsWiseCollectionLocations *").prop('checked', false);
                $(".LocationsWiseCollectionLocations *").prop('disabled', false);
            }
            if (value == "PatientBalance") {
                $(".PatientBalanceLocations").html(result).show();
                $(".PatientBalanceLocations ul").attr("id", "PatientBalanceLocations")
                $("#PatientBalanceLocations .chk-multi-checkboxes").attr("id", "chkPatientBalanceLocation")
                $("#PatientBalanceLocations .chk-multi-checkboxes-all").attr("id", "chkPatientBalanceLocationAll")
                $("#PatientBalanceLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'PatientBalanceLocations'),GetPracticeStaffLocation('PatientBalanceDynamicLocations')")
                $("#PatientBalanceLocations .chk-multi-checkboxes").attr("onclick", "ReportAlert(this,'PatientBalanceLocations'),GetPracticeStaffLocation('PatientBalanceDynamicLocations')")
                $("#PatientBalanceProviders *").prop('checked', false);
                $("#PatientBalanceProviders *").prop('disabled', true);
                $(".PatientBalanceLocations *").prop('checked', false);
                $(".PatientBalanceLocations *").prop('disabled', false);
            }
            if (value == "ProviderCollection") {
                $(".ProviderCollectionLocations").html(result).show();
                $(".ProviderCollectionLocations ul").attr("id", "ProviderCollectionLocations")
                $("#ProviderCollectionLocations .chk-multi-checkboxes").attr("id", "chkProviderCollectionLocations")
                $("#ProviderCollectionLocations .chk-multi-checkboxes-all").attr("id", "chkProviderCollectionLocationsAll")
                $("#ProviderCollectionLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ProviderCollectionLocations'),GetPracticeStaffLocation('ProviderCollectionLocations')")
                $("#ProviderCollectionLocations .chk-multi-checkboxes").attr("onclick", "ReportAlert(this,'ProviderCollectionLocations'),GetPracticeStaffLocation('ProviderCollectionLocations')")
                $("#ProviderCollectionProviders *").prop('checked', false);
                $("#ProviderCollectionProviders *").prop('disabled', true);
                $(".ProviderCollectionLocations *").prop('checked', false);
                $(".ProviderCollectionLocations *").prop('disabled', false);
            }
            if (value == "ARAgingSummary") {
                $(".ARAgingSummaryLocations").html(result).show();
                $(".ARAgingSummaryLocations ul").attr("id", "ARAgingSummaryLocations")
                $("#ARAgingSummaryLocations .chk-multi-checkboxes").attr("id", "chkARAgingSummaryLocations")
                $("#ARAgingSummaryLocations .chk-multi-checkboxes-all").attr("id", "chkARAgingSummaryLocationsAll")
                $("#ARAgingSummaryLocations .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ARAgingSummaryLocations'),GetPracticeStaffLocation('ARAgingSummaryLocations')")
                $("#ARAgingSummaryLocations .chk-multi-checkboxes").attr("onclick", "ReportAlert(this,'ARAgingSummaryLocations'),GetPracticeStaffLocation('ARAgingSummaryLocations')")
                $("#ARAgingSummaryProviders *").prop('checked', false);
                $("#ARAgingSummaryProviders *").prop('disabled', true);
                $(".ARAgingSummaryLocations *").prop('checked', false);
                $(".ARAgingSummaryLocations *").prop('disabled', false);
            }
            $("#AllLocations").text("All Locations");
            $("#AllProviders").text("All Providers");

        });
    }
    if (Group == "Provider") {
        $.post('CallBacks/DynamicLocationProviderDDL.aspx', { action: "LoadDDLProvider" }, function (data) {
            debugger
            var result1 = "";
            var start1 = data.indexOf("###StartFilterProvider###") + 25;
            var end1 = data.indexOf("###EndFilterProvider###");
            result1 = $.trim(data.substring(start1, end1));
            //$("#divPracticeLocation *").prop('disabled', true);
            //$("#divReportServiceProvider *").prop('disabled', false);
            //$('.chkPracticeLocation').prop("checked", false)
            //$('#chkServiceProviderAll').prop("checked", false)
            //$("#AllLocations").text("All Locations");
            //$("#AllProviders").text("All Providers");

            if (value == "CPTWiseCollection") {
                $('.CPTWiseCollectionProviders').html(result1).show();
                $(".CPTWiseCollectionProviders ul").attr("id", "CPTWiseCollectionProviders")
                $("#CPTWiseCollectionProviders .StaffNPI").attr("id", "chkCPTWiseCollectionProviders")
                $("#CPTWiseCollectionProviders .chk-multi-checkboxes-all").attr("id", "chkCPTWiseCollectionProvidersAll")
                $("#CPTWiseCollectionProviders .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'CPTWiseCollectionProviders'),GetLocationNamePracticestaff('CPTWiseCollectionProviders')")
                $("#CPTWiseCollectionProviders .StaffNPI").attr("onclick", "ReportAlert(this,'CPTWiseCollectionProviders'),GetLocationNamePracticestaff('CPTWiseCollectionProviders')")
                $(".CPTWiseCollectionProviders   *").prop('checked', false);
                $(".CPTWiseCollectionProviders   *").prop('disabled', false);
                $(".CPTWiseCollectionDynamicLocations   *").prop('checked', false);
                $(".CPTWiseCollectionDynamicLocations   *").prop('disabled', true);
            }
            if (value == "ClaimSummary") {
                $(".ClaimSummaryProviders").html(result1).show();
                $(".ClaimSummaryProviders ul").attr("id", "ClaimSummaryProviders")
                $("#ClaimSummaryProviders .StaffNPI").attr("id", "chkClaimSummaryProviders")
                $("#ClaimSummaryProviders .chk-multi-checkboxes-all").attr("id", "chkClaimSummaryProvidersAll")
                $("#ClaimSummaryProviders .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ClaimSummaryProviders'),GetLocationNamePracticestaff('ClaimSummaryProviders')")
                $("#ClaimSummaryProviders .StaffNPI").attr("onclick", "ReportAlert(this,'ClaimSummaryProviders'),GetLocationNamePracticestaff('ClaimSummaryProviders')")
                $(".ClaimSummaryProviders  *").prop('checked', false);
                $(".ClaimSummaryProviders  *").prop('disabled', false);
                $(".ClaimSummaryDynamicLocations  *").prop('checked', false);
                $(".ClaimSummaryDynamicLocations  *").prop('disabled', true);
            }
            if (value == "ChargedSummary") {
                $(".ChargedSummaryProviders").html(result1).show();
                $(".ChargedSummaryProviders ul").attr("id", "ChargedSummaryProviders")
                $("#ChargedSummaryProviders .StaffNPI").attr("id", "chkChargedSummaryProviders")
                $("#ChargedSummaryProviders .chk-multi-checkboxes-all").attr("id", "chkChargedSummaryProvidersAll")
                $("#ChargedSummaryProviders .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ChargedSummaryProviders'),GetLocationNamePracticestaff('ChargedSummaryProviders')")
                $("#ChargedSummaryProviders .StaffNPI").attr("onclick", "ReportAlert(this,'ChargedSummaryProviders'),GetLocationNamePracticestaff('ChargedSummaryProviders')")
                $(".ChargedSummaryProviders  *").prop('checked', false);
                $(".ChargedSummaryProviders  *").prop('disabled', false);
                $(".ChargedSummaryDynamicLocations  *").prop('checked', false);
                $(".ChargedSummaryDynamicLocations  *").prop('disabled', true);
            }
            if (value == "LocationWiseCollection") {
                $(".LocationsWiseCollectionProviders").html(result1).show();
                $(".LocationsWiseCollectionProviders ul").attr("id", "LocationsWiseProviders")
                $("#LocationsWiseProviders .StaffNPI").attr("id", "chkLocationsWiseProviders")
                $("#LocationsWiseProviders .chk-multi-checkboxes-all").attr("id", "chkLocationsWiseProvidersAll")
                $("#LocationsWiseProviders .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'LocationsWiseProviders'),GetLocationNamePracticestaff('LocationsWiseProviders')")
                $("#LocationsWiseProviders .StaffNPI").attr("onclick", "ReportAlert(this,'LocationsWiseProviders'),GetLocationNamePracticestaff('LocationsWiseProviders')")
                $(".LocationsWiseCollectionLocations  *").prop('disabled', true);
                $(".LocationsWiseCollectionLocations  *").prop('checked', false);
                $(".LocationsWiseCollectionProviders *").prop('checked', false);
                $(".LocationsWiseCollectionProviders *").prop('disabled', false);
            }
            if (value == "PatientBalance") {
                $(".PatientBalanceProviders").html(result1).show();
                $(".PatientBalanceProviders ul").attr("id", "PatientBalanceProviders")
                $("#PatientBalanceProviders .StaffNPI").attr("id", "chkPatientBalanceProviders")
                $("#PatientBalanceProviders .chk-multi-checkboxes-all").attr("id", "PatientBalanceProviderChkAll")
                $("#PatientBalanceProviders .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'PatientBalanceProviders'),GetLocationNamePracticestaff('PatientBalanceProviders')")
                $("#PatientBalanceProviders .StaffNPI").attr("onclick", "ReportAlert(this,'PatientBalanceProviders'),GetLocationNamePracticestaff('PatientBalanceProviders')")
                $(".PatientBalanceLocations  *").prop('disabled', true);
                $(".PatientBalanceLocations  *").prop('checked', false);
                $(".PatientBalanceProviders *").prop('checked', false);
                $(".PatientBalanceProviders *").prop('disabled', false);
            }
            if (value == "ProviderCollection") {
                $(".ProviderCollectionProviders").html(result1).show();
                $(".ProviderCollectionProviders ul").attr("id", "ProviderCollectionProviders")
                $("#ProviderCollectionProviders .StaffNPI").attr("id", "chkProviderCollectionProviders")
                $("#ProviderCollectionProviders .chk-multi-checkboxes-all").attr("id", "ProviderCollectionProviderChkAll")
                $("#ProviderCollectionProviders .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ProviderCollectionProviders'),GetLocationNamePracticestaff('ProviderCollectionProviders')")
                $("#ProviderCollectionProviders .StaffNPI").attr("onclick", "ReportAlert(this,'ProviderCollectionProviders'),GetLocationNamePracticestaff('ProviderCollectionProviders')")
                $(".ProviderCollectionLocations  *").prop('disabled', true);
                $(".ProviderCollectionLocations  *").prop('checked', false);
                $(".ProviderCollectionProviders *").prop('checked', false);
                $(".ProviderCollectionProviders *").prop('disabled', false);
            }
            if (value == "ARAgingSummary") {
                $(".ARAgingSummaryProviders").html(result1).show();
                $(".ARAgingSummaryProviders ul").attr("id", "ARAgingSummaryProviders")
                $("#ARAgingSummaryProviders .StaffNPI").attr("id", "chkARAgingSummaryProviders")
                $("#ARAgingSummaryProviders .chk-multi-checkboxes-all").attr("id", "ARAgingSummaryProviderChkAll")
                $("#ARAgingSummaryProviders .chk-multi-checkboxes-all").attr("onclick", "Report_ClickMultiCheckBoxAll(this,'ARAgingSummaryProviders'),GetLocationNamePracticestaff('ARAgingSummaryProviders')")
                $("#ARAgingSummaryProviders .StaffNPI").attr("onclick", "ReportAlert(this,'ARAgingSummaryProviders'),GetLocationNamePracticestaff('ARAgingSummaryProviders')")
                $(".ARAgingSummaryLocations  *").prop('disabled', true);
                $(".ARAgingSummaryLocations  *").prop('checked', false);
                $(".ARAgingSummaryProviders *").prop('checked', false);
                $(".ARAgingSummaryProviders *").prop('disabled', false);

            }



            $("#AllLocations").text("All Locations");
            $("#AllProviders").text("All Providers");
        });
    }

}
var _CPTProviderNPI = "";
var _PracticeLocationId = "";
var _GroupBy = "";
var _TimeSpan = "";
var _DateFrom = "";
var _DateTo = "";

function FilterCPTWise(Customize) {
    debugger;
    $(".message").hide();
    var DateFrom = '';
    var DateTo = '';
    var ProviderId = "";
    var PracticeLocationId = "";
    var Group = $("#ddlGroupBy option:selected").val();
    var DateTypeCPT = "";
    var SelectDate = "";
    var CPTCode = "";
    var Rows1 = $("#ddlPaging").val();

    var InsuranceID = ""
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });
    CPTCode = $(".spnservicecode").map(function () {
        return $(this).text();
    }).get().join(',');;
    if (Group == "Provider") {

        $("#" + SubReportDivName).parentsUntil().find("[id$='CPTWiseCollectionDynamicLocations'] .chk-multi-checkboxes").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("#CPTWiseCollectionProviders .chk-multi-checkboxes").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("#CPTWiseCollectionProviders #chkCPTWiseCollectionProvidersAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='CPTWiseCollectionDynamicLocations'] #chkCPTWiseCollectionDynamicLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
    }
    else {
        $("#" + SubReportDivName).parentsUntil().find("[id$='CPTWiseCollectionLocations'] .chk-multi-checkboxes").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='CPTWiseCollectionLocations'] #chkCPTWiseCollectionLocationAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='CPTWiseCollectionDynamicProvider'] .chk-multi-checkboxes").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });

        $("#" + SubReportDivName).parentsUntil().find("[id$='CPTWiseCollectionDynamicProvider'] #DynamicCPTWiseDynamicProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });

    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    debugger
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateTypeCPT = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();

    } else {
        DateTypeCPT = $("#" + SubReportDivName).find('[id$="ddlPostType"] option:selected').val();
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }
    params = {
        action: "Filter",
        DateTypeCPT: DateTypeCPT,
        ProviderId: ProviderId,
        PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo, InsuranceID: InsuranceID, CPTCode: CPTCode, Rows: Rows1, PageNumber: 0
    }
    Report_ReloadData("FilterCPTWiseCollection.aspx", params, true)

    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);

    $("#ddlSelectDateCustomize").val(SelectDate);
    $("#ddlSelectDate").val(SelectDate);


    //$.post('../../ProviderPortal/ReportsNew/filter/FilterCPTWiseCollection.aspx', {
    //    action: "Filter", DateTypeCPT: DateTypeCPT, ProviderId: ProviderId,
    //    PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo, InsuranceID: InsuranceID, CPTCode: CPTCode, Rows: Rows1, PageNumber: 0
    //}, function (data) {
    //    debugger
    //    var result = "";
    //    var start = data.indexOf("###FilterCPTWiseCollection###") + 29;
    //    var end = data.indexOf("###EndCPTWiseCollection###");
    //    result = $.trim(data.substring(start, end));
    //    $(".tbodyCPTWiseCollecion").html(result);
    //    if ($(".tbodyCPTWiseCollecion").find("tr").html() == "" || $(".tbodyCPTWiseCollecion").find("tr").html() == undefined) {
    //        $(".message").html("No Record Found, Please change search criteria").show();
    //    }
    //    $('[id$="ddlPostTypeCustomize"] option:selected').val(DateTypeCPT)
    //    $('[id$="ddlPostType"] option:selected').val(DateTypeCPT)

    //    $("#CustomizeDateFrom").val(DateFrom);
    //    $("#CustomizeDateTo").val(DateTo);
    //    $("#DateFrom").val(DateFrom);
    //    $("#DateTo").val(DateTo);
    //    $("#ddlSelectDate").val(SelectDate)
    //    $("#ddlSelectDateCustomize").val(SelectDate)
    //    var start = data.indexOf("###StartTotal###") + 16;
    //    var end = data.indexOf("###EndTotal###");
    //    var returnHtml = $.trim(data.substring(start, end));
    //    $("[id$='hdnTotalRows']").val(returnHtml);
    //    $(".totalRows").html("Total Rows : " + $("[id$='hdnTotalRows']").val());
    //    _CPTProviderNPI = ProviderId;
    //    _PracticeLocationId = PracticeLocationId;
    //    _GroupBy = Group;
    //    _TimeSpan = TimeSpan;
    //    _DateFrom = DateFrom;
    //    _DateTo = DateTo;
    //    var dateArF = DateFrom.split('-');
    //    var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
    //    var dateArT = DateTo.split('-');
    //    var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
    //    $("[id$='txtDateFrom']").text(newDateFrom);
    //    $("[id$='txtDateTo']").text(newDateTo);

    //    $("#ddlSelectDateCustomize").val(SelectDate);
    //    $("#ddlSelectDate").val(SelectDate);
    //    //ShowHideMenu();
    //    //$("[id$='FilterReports']").prop("disabled", true);
    //    //$(elem).parent().parent().parent().parent().parent().find("#FilterReports").prop("disabled", true);
    //    $(".TimeSpan").css("display", "block");
    //});
    ///*Added By faiza Bilal 3-24-2022*/
    //TimeSpanCPT = TimeSpan;
    //DateFromCPT = DateFrom;
    //DateToCPT = DateTo;
    ///*End Added By faiza Bilal 3-24-2022*/
}
var _NewInsuranceIds = "";
var _NewInsuranceName = "";
var InsuranceIds = ""
var _InsuranceName = "";
var InsuranceID = "";
var InsuranceName = "";

function FilterPayerAnalysis(Customize) {
    debugger
    var InsuranceID = "";
    Rows1 = $("#ddlPaging").val();
    var Location = ""
    var ProviderId = ""
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Location += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Location = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";

        }
    });
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateTo = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();

    } else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }

    params = {

        Insurance: InsuranceID,
        Rows: Rows1,
        DateFrom: DateFrom,
        DateTo: DateTo,
        Location: Location,
        ProviderId: ProviderId,
        PageNumber: 0,
        action: "Filter"
    };

    debugger
    Report_ReloadData("FilterPayerAnalysis.aspx", params, true)
    $("#CustomizeDateFrom").val(DateFrom);
    $("#CustomizeDateTo").val(DateTo);
    $("#DateFrom").val(DateFrom);
    $("#DateTo").val(DateTo);
    $("#ddlSelectDate").val(SelectDate)
    $("#ddlSelectDateCustomize").val(SelectDate)



}
function CheckedPayers(elem) {
    debugger;
    if ($(elem).is(":checked")) {

        if (InsuranceID != "") {
            var LastChar = InsuranceID[InsuranceID.length - 1];
            if (LastChar != ",") {
                InsuranceID = InsuranceID + ',';
            }
        }

        _InsuranceName += $(elem).parent().find("#PayersName").text() + ",";
        InsuranceID += $(elem).parent().find("#InsuranceId").val() + ",";

    }
    else if ($(elem).is("checked") == false) {

        if (InsuranceID != "") {
            var LastChar = InsuranceID[InsuranceID.length - 1];
            if (LastChar != ",") {
                InsuranceID = InsuranceID + ',';
            }
        }
        var NewInsuranceIds = InsuranceID.substring(0, InsuranceID.length - 1);
        var array = [];
        array = NewInsuranceIds.split(',');
        var itemtoRemove = $(elem).parent().find("#InsuranceId").val();

        for (var i = 0; i < array.length; i++) {

            var arrayItem = array[i];
            if (arrayItem == itemtoRemove) {

                array.splice($.inArray(itemtoRemove, array), 1);
                InsuranceID = array.join(",");
                debugger
                var inputString = InsuranceID;
                var findme = ",";
                var NewInsuranceIds = "";
                if (inputString != "") {
                    if (inputString.indexOf(findme) > -1) {

                        InsuranceID = InsuranceID;
                    } else {
                        InsuranceID = InsuranceID + ',';
                    }
                }

            }
        }

        var arrayInsNames = [];
        var NewInsuranceName = InsuranceName.substring(0, InsuranceName.length - 1);
        var array = [];
        arrayInsNames = NewInsuranceName.split(',');
        var itemtoRemove = $(elem).parent().find("#PayersName").html();

        for (var i = 0; i < arrayInsNames.length; i++) {

            var arrayItemName = arrayInsNames[i];
            if (arrayItemName == itemtoRemove) {
                debugger
                arrayInsNames.splice($.inArray(itemtoRemove, arrayInsNames), 1);
                _NewInsuranceName = arrayInsNames.join(",");
                var inputString1 = _NewInsuranceName;
                break;
            }
        }

    }

    ReportAlert(elem)

    //$("#SelectInsurances ").val("");
}

function SelectPayersNames(elem) {
    debugger
    if ($(elem).prop("checked") == true) {

        InsuranceName += $(elem).parent().find("#PayersName").text() + ",";
        $("#SelectInsurances").text(InsuranceName.substring(0, 35));
    }
    else {
        debugger
        InsuranceName = InsuranceName.replace($(elem).parent().find("#PayersName").text() + ",", " ");
        $("#SelectInsurances").text(InsuranceName.substring(0, 35));
    }

    if ($('.MultiCheckBox:checked').length == $('.MultiCheckBox').length) {
        $('.AllCheckBox').attr('checked', true);
        $("#MultipleInsurancesTxt").val("All");
    }
    else {
        $('.AllCheckBox').attr('checked', false);
    }
}
function ALLCheckBox() {
    debugger

    if ($(".chk-multi-checkboxes-all").is(":checked")) {
        $('.chk-multi-checkboxes').attr('checked', true);
        $("#MultipleInsurancesTxt").val("All");
        _NewInsuranceName = "";
        $('.chk-multi-checkboxes').each(function () {

            if ($(this).is(":checked")) {

                _NewInsuranceName += $(this).parent().find(".checkBoxName").html() + ",";
                _NewInsuranceIds += $(this).parent().find(".InsuranceId").val() + ",";


            }

        });
        $("#SelectInsurances").text("All Payers");

    }
    else if ($(".chk-multi-checkboxes-all").is(":checked") == false) {

        $('.chk-multi-checkboxes').attr('checked', false);
        $("#SelectInsurances").text("");
        _NewInsuranceName = "";
        _NewInsuranceIds = "";
        InsuranceName = "";
        InsuranceID = ""
    }
}
function CancelMultiCheckedInusrances() {
    debugger
    $("#Div_MultiInsurances").hide();
    $('.MultiCheckBox').attr('checked', false);
    $('.AllCheckBox').attr('checked', false);
    _NewInsuranceIds = "";
    InsuranceIds = "";
    _NewInsuranceName = "";
    //FilterClaims(0, true);

    SearchMultipleImusrance("");
    $('#MultipleInsurancesTxt').val('All');

}
function Report_ClickMultiCheckBox(elem) {
    debugger
    var CurrentUl = $(elem).closest("ul");
    var CurrentUlId = $(elem).closest("ul").attr("id");

    if (CurrentUl.find(".chk-multi-checkboxes").length == CurrentUl.find(".chk-multi-checkboxes:checked").length) {
        CurrentUl.find(".chk-multi-checkboxes-all").prop("checked", true);
        $(elem).parentsUntil(".BranceInput").find(".selectedText").html("All")
    }
    else {
        CurrentUl.find(".chk-multi-checkboxes-all").prop("checked", false);
    }

    //var MultiText = Report_GetSelectedMultiCheckBoxDropDownItemsText(CurrentUlId);
    /*MultiText = MultiText.substring(0, 35);*/
    //$(elem).parentsUntil(".BranceInput").find(".selectedText").html(MultiText);
    //$(elem).parentsUntil(".BranceInput").find(".selectedText").prop("title", MultiText);
}
function FilterArAgingSummary(Customize) {
    debugger
    var Payers = "";
    var ProviderId = "";
    var PracticeLocationId = "";
    var params = "";
    var Aging = ""
    var DateAsOf = "";
    var Group = $("#ddlGroupBy option:selected").val();

    if (Group == "Provider") {

        $("#" + SubReportDivName).parentsUntil().find("[id$='ARAgingSummaryDynamicLocations'] #ARAgingSummaryLocationsChk").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ARAgingSummaryDynamicLocations'] #chkARAgingSummaryDynamicLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ARAgingSummaryProviders'] #chkARAgingSummaryProviders").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ARAgingSummaryProviders'] #ARAgingSummaryProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });


    } else {

        $("#" + SubReportDivName).parentsUntil().find("[id$='ARAgingSummaryLocations'] #chkARAgingSummaryLocations").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("MultiPayerScenarioARAgingSummary #chkARAgingSummaryLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("#ARAgingSummaryDynamicProviders #ARAgingSummaryDynamicProviderChk").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("#ARAgingSummaryDynamicProviders #DynamicARAgingSummaryProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });


    }
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] #chkPayerScenarioARAgingSummary").each(function () {
        if ($(this).is(":checked")) {
            Payers += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] #chkPayerScenarioARAgingSummaryAll").each(function () {
        if ($(this).is(":checked")) {
            Payers = "";
        }
    });
    if (Customize == "Customize") {
        Aging = $("#" + SubReportDivName).parentsUntil().find("#ddlAgingByCustomize").val();
        DateAsOf = $("#" + SubReportDivName).parentsUntil().find("#dateasofCustomize").val();
    } else {
        Aging = $("#" + SubReportDivName).find("#ddlAgingBy").val();
        DateAsOf = $("#" + SubReportDivName).find("#dateasof").val();
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (Payers.length > 0) {
        Payers = Payers.slice(0, -1);
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    params = {
        PayerId: Payers,
        ProviderId: ProviderId,
        PracticeLocationId: PracticeLocationId,
        AgingType: Aging,
        Asof: DateAsOf,
        Action: "Filter"
    };
    $.post("../../ProviderPortal/ReportsNew/filter/FilterARAgingSummaryReport.aspx", params, function (data) {
        debugger

        var start = data.indexOf("###StartFilter###") + 17;
        var end = data.indexOf("###END###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".tBodyARAgingSummary").html(returnHtml);

        $(".divInsuranceDetail").html("")
        if ($(".tBodyARAgingSummary").find("tr").find("#txtTotalOutStanding").html() == "" || $(".tBodyARAgingSummary").find("tr").find("#txtTotalOutStanding").html() == undefined) {
            $(".Pagination_div").css("display", "");
            $(".totalRows").css("display", "none");
            $(".message").html("No Record Found, Please change search criteria").show();
        }
        else {
            $(".message").hide();
        }
        $(".divPayerScenario").css("display", "none")
        $(".divPracticeLocation").css("display", "none")
        $(".divServiceProvider").css("display", "none")
        SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
        SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
        $("#" + filename2).empty();

        $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + '</div>');
        // $(elem).parent().parent().parent().parent().parent().find("#FilterReports").prop("disabled", true);
        //ShowHideMenu();
        //$("[id$='FilterReports']").prop("disabled", true);
        var start = data.indexOf("###TimeSpan###") + 14;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $('[id$="TimeSpan"]').text(returnHtml)

        $("#ddlAgingByCustomize").val(Aging);
        $("#dateasofCustomize").val(DateAsOf);
        $("#ddlAgingBy").val(Aging);
        $("#dateasof").val(DateAsOf);


    });
}
function ShowMenuFilters(DivId, elem) {
    debugger
    if ($(elem).parent().find("." + DivId).is(':visible')) {
        $(elem).parent().find("." + DivId).css("display", "none");
    }
    else {
        $(elem).parent().find("." + DivId).css("display", "");

    }
}
function FilterPaymentsSummaryAndDetails(Customize) {
    debugger
    var params = "";
    var DateFrom = '';
    var DateTo = '';
    var ProviderId = "";
    var PayerType = ""
    var InsuranceID = ""
    var DateType = "";
    var SelectDate = ""
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (Customize == "Customize") {

        SelectDate = $("#" + SubReportDivName).parentsUntil().find("[id$='ddlSelectDateCustomize']").val();
        DateFrom = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateFrom']").val();

        DateTo = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateTo']").val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val()
        PayerType = $("#" + SubReportDivName).parentsUntil().find("#ddlPayerType").val()

    } else {
        DateFrom = $("#" + SubReportDivName).find("[id$='DateFrom']").val();
        DateTo = $("#" + SubReportDivName).find("[id$='DateTo']").val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val()
    }
    params = {
        ProviderIdbYNPI: ProviderId,
        PayerType: PayerType,
        InsuranceID: InsuranceID,
        DateType: DateType,
        DateFrom: DateFrom,
        DateTo: DateTo,
        Action: "Filter"
    };
    $.post("../../ProviderPortal/ReportsNew/filter/PaymentsSummaryReportHandler.aspx", params, function (data) {
        debugger

        var start = data.indexOf("###StartFilter###") + 17;
        var end = data.indexOf("###END###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".tbodyReportList").html(returnHtml);
        if ($(".tbodyReportList").find("tr").html() == "" || $(".tbodyReportList").find("tr").html() == undefined) {
            $(".Pagination_div").css("display", "block");

            $(".message").html("No Record Found, Please change search criteria").show();
        } else {

            $(".message").hide();
        }

        var dateArF = DateFrom.split('-');
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = DateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $("[id$='txtDateFrom']").text(newDateFrom);
        $("[id$='txtDateTo']").text(newDateTo);
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("#ddlPostType").val(DateType);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#ddlPostTypeCustomize").val(DateType);
        $("#ddlPayerType").val(PayerType)
        $("[id$='ddlSelectDateCustomize']").val(SelectDate)
        $("[id$='ddlSelectDate']").val(SelectDate)

    });
    /*Added By faiza Bilal 3-24-2022*/
    TimeSpanPaySummary = TimeSpan;
    DateFromPaySummary = DateFrom;
    DateToPaySummary = DateTo;
    /*End Added By faiza Bilal 3-24-2022*/

}

function FilterUnpostedPaymentsDetailandSummary(Customize) {
    debugger;
    var _NoOfchk = 0;
    var NoOfchk = 0;
    var params = "";
    var DateFrom = '';
    var DateTo = '';
    var ProviderId = "";
    var PayerType = "";
    var DateType = "";
    var CheckNo = "";
    var SelectDate = "";
    var InsuranceID = "";
    Rows1 = $("#ddlPaging").val();
    var Location = ""
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Location += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Location = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";

        }
    });
    if (Customize == "Customize") {
        PayerType = $("#ddlpayertypeCustomize").val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        CheckNo = $("#txtsearchcheckCustomize").val();
        DateFrom = $("#CustomizeDateFrom").val();
        DateTo = $("#CustomizeDateTo").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
    } else {
        PayerType = $("#" + SubReportDivName).find("#ddlpayertype").val();
        DateFrom = $("#" + SubReportDivName).find("#DateFrom").val();
        DateTo = $("#" + SubReportDivName).find("#DateTo").val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();

    }
    debugger
    params = {
        PayerType: PayerType,
        DateType: DateType,
        DateFrom: DateFrom,
        DateTo: DateTo,
        CheckNo: CheckNo,
        Payers: InsuranceID,
        Location: Location,
        Provider: ProviderId,

        action: "Filter"
    };
    $.post("../../ProviderPortal/ReportsNew/filter/FilterUnpostedPaymentsDetailandSummary.aspx", params, function (data) {
        debugger

        var start = data.indexOf("###StartFilterTotal###") + 22;
        var end = data.indexOf("###EndFilterTotal###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".tbodyUnpostedPaymentsDetailsSummary").html(returnHtml);
        var count = false;
        if ($(".tbodyUnpostedPaymentsDetailsSummary").find("tr").find(".NoofChecks").each(function () {
            debugger
            /*Added by Faiza Bilal 3-22-2022 to get NoChecks counts*/
            _NoOfchk = parseInt($.trim($(this).text()));
            NoOfchk += _NoOfchk;
            if (NoOfchk == 0) {
                count = false;
            }
            else {
                count = true;
            }
            /*End Added by Faiza Bilal 3-22-2022 to get NoChecks counts*/
        }));
        if (count == false) {
            $(".Pagination_div").css("display", "")
            $(".totalRows").css("display", "none")
            $(".message").html("No Record Found, Please change search criteria").show();
        }
        else {
            $(".message").hide();
        }
        var start = data.indexOf("###TimeSpanStart###") + 19;
        var end = data.indexOf("###TimeSpanEnd###");
        var returnHtml = $.trim(data.substring(start, end));

        $('[id$="TimeSpan"]').text(returnHtml);
        var start1 = data.indexOf("###StartFilterDetails###") + 25;
        var end1 = data.indexOf("###EndFilterDetails###");
        var returnHtml1 = $.trim(data.substring(start1, end1));
        $(".checkdetailTbody").html(returnHtml1);
        $("#UnpostedReportDateFrom").val(DateFrom);
        $("#UnpostedReportDateTo").val(DateTo);
        $("#txtsearchcheckCustomize").val(CheckNo)
        var dateArF = DateFrom.split('-');
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = DateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $("[id$='txtDateFrom']").text(newDateFrom);
        $("[id$='txtDateTo']").text(newDateTo);
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("#ddlPostTypeCustomize").val(DateType);
        $("#ddlPostType").val(DateType);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#ddlSelectDateCustomize").val(SelectDate);
        $("#ddlSelectDate").val(SelectDate);
    });
    /*Added By faiza Bilal 3-24-2022*/
    TimeSpanUnpostedPay = TimeSpan;
    DateFromUnpostedPay = DateFrom;
    DateToUnpostedPay = DateTo;
    /*End Added By faiza Bilal 3-24-2022*/

}
function FilterRejectedDeniedSummaryAndDetail(Customize) {
    debugger
    var BilledAs = ""
    var Aging = ""
    var Location = ""
    var ProviderId = ""
    var InsuranceID = ""
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });


    var paging = false;
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Location += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Location = "";
        }
    });
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    if (Location.length > 0) {
        Location = Location.slice(0, -1);
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (Customize == "Customize") {
        Aging = $("#ddlAging").val();
        BilledAs = $("#BilledAsCustomize option:selected").val();
    } else {
        BilledAs = $("#BilledAs option:selected").val();

    }
    var params = {
        Insurance: InsuranceID,
        ProviderId: ProviderId,
        Location: Location,
        BilledAs: BilledAs,
        RDAging: Aging,
        Action: "Filter"
    };
    $.post("../../providerportal/ReportsNew/filter/FilterRejectedDeniedSummaryAndDetail.aspx", params, function (data) {
        debugger

        var start = data.indexOf("###StartFilter###") + 17;
        var end = data.indexOf("###EndFilter###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".RejectedDeniedSummary").html(returnHtml);
        if (($(".RejectedDeniedSummary").find("tr").find("#rptSummary_lblGrandTotal").html() == "") || ($(".RejectedDeniedSummary").find("tr").find("#rptSummary_lblGrandTotal").html() == undefined)) {
            $(".Pagination_div").css("display", "")
            $(".totalRows").css("display", "none")
            $(".message").html("No Record Found, Please change search criteria").show();
        }
        else {
            $(".message").hide();
        }
        $("#ddlAging").val(Aging)
        $("#BilledAs").val(BilledAs);
        $("#BilledAsCustomize").val(BilledAs);

    });
}
function FilterProcedurePaymentsSummaryAndDetail(Customize) {
    debugger
    var Rows1 = $("#ddlPaging").val()
    var InsuranceType = ""
    var InsuranceID = ""
    var InsuranceName = ""
    var Location = ""
    var ProviderId = ""

    var paging = false;
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Location += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Location = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";

        }
    });

    if (Customize == "Customize") {

        InsuranceType = $("#" + SubReportDivName).parentsUntil().find("#BilledAsCustomize").val();

        var MultipleCPTs = $(".spnservicecode").map(function () {
            return $(this).text();
        }).get().join(',');


        paging = false;
    }
    else {
        InsuranceType = $("#" + SubReportDivName).find("#BilledAs").val();
    }


    var params = {
        Insurance: InsuranceID,
        InsuranceType: InsuranceType,
        ProviderId: ProviderId,
        Location: Location,
        Cptcodes: MultipleCPTs,
        Rows: Rows1,
        PageNumber: 0,
        Action: "Filter"
    };
    Report_ReloadData("FilterProcedurePaymentsSummaryAndDetail.aspx", params, true);
    $("#BilledAsCustomize").val(InsuranceType)
    $("#BilledAs").val(InsuranceType)

    $(".txt_page_Number").text("1")

    //$.post("../../ProviderPortal/ReportsNew/filter/filterProcedurePaymentsSummaryAndDetail.aspx", params, function (data) {
    //    debugger

    //    var start = data.indexOf("###StartFilter###") + 17;
    //    var end = data.indexOf("###EndFilter###");
    //    var returnHtml = $.trim(data.substring(start, end));
    //    $(".GridReports").html(returnHtml);
    //    if (($("#tbodyReportList").find("tr").html() == "") || ($("#tbodyReportList").find("tr").html() == undefined)) {
    //        $(".message").html("No Record Found, Please change search criteria").show();
    //    }
    //    start = data.indexOf("###StartTotal###") + 16;
    //    end = data.indexOf("###EndTotal###");
    //    returnHtml = $.trim(data.substring(start, end));
    //    debugger


    //    $("[id$='hdnTotalRows']").val(returnHtml);
    //    if (paging == false) {
    //        $(".totalRows").html("Total Rows : " + $("[id$='hdnTotalRows']").val());
    //        GenerateReportPaging($("[id$='hdnTotalRows']").val(), Rows1);

    //    }
    //    else {

    //        var r = Rows1;
    //        $(".totalRows").html("Total Rows : " + $("[id$='hdnTotalRows']").val());
    //        GenerateReportPaging($("[id$='hdnTotalRows']").val(), r);

    //    }
    //    debugger

    //    var CheckedPayersID = [];
    //    CheckedPayersID = InsuranceID.split(",");
    //    //for (var i = 0; i < CheckedPayersID.length; i++) {
    //    //    $("[id$='ulMultiPayerScenarioCustomizeProPayments'] .chk-multi-checkboxes").each(function () {
    //    //        if ($("[id$='ulMultiPayerScenarioCustomizeProPayments']").find('.chk-multi-checkboxes').val() == CheckedPayersID[i]) {
    //    //            debugger
    //    //            $(this).prop("checked", true);
    //    //        }
    //    //        else {
    //    //            debugger
    //    //            $(this).prop("checked", false);

    //    //        }
    //    //    });
    //    //}
    //    $("#SelectProPayments").text(InsuranceName);
    //    $("#SelectInsurances").text(InsuranceName);

    //    $(".txt_page_Number").text("1")

    //});
}
function MultipleClaimGridHereClose(elem, DivID) {
    $(elem).parentsUntil().find("#divAllClaimsDropDownReport").css("display", "none")

}
function closecptdiv(elem) {
    $(elem).parentsUntil().find("#divCPTSearched").css("display", "none")
}
function ServiceCode(event, elem, DivID) {
    debugger
    var a = event.which || event.keyCode;
    var Serviecode = $.trim($("#txtServiceCode").val()) || "";
    //if (Serviecode == "") { $(".divServicecode").hide(); return };
    if (a == 13) {

        searchCPTs('C', elem.value, '', elem, event, DivID);
    }
}
function searchCPTs(searchBy, code, desc, elem, event, DivID) {
    debugger
    _CurrentCPTSearchedElement = $(elem);
    var Code = $.trim($(elem).val());
    //$(elem).val("");
    var array = Code.split('-');
    Code = array[0].trim();
    //if (event.keyCode == 27) {
    //    $("#divCPTSearched").hide();
    //    return false;
    //}
    //if (event.keyCode == 13) {
    $.post("../../ProviderPortal/Controls/CPTCodesSearch.aspx", { Code: Code }, function (data) {
        debugger
        var returnHtml = data;
        var start = data.indexOf("###StartCPTSearch###") + 20;
        var end = data.indexOf("###EndCPTSearch###");
        $("#CPTSearchedList").html(returnHtml.substring(start, end));
        AddNoRecordFoundInGrids("CPTSearchedList");


        $("#divCPTSearched").slideDown("slow");
        $("#divCPTSearched").scrollTop(0);
        addServiceRow(elem);
        searchfromCPT = $(elem).attr('id');
    });
    //}


}
function closePatientSearched(elem) {
    debugger
    $(elem).parentsUntil().find("#SearchPatientList").css("display", "none")
} function closePatientSearchedCustomize(elem) {
    debugger
    $(elem).parentsUntil().find("#SearchPatientListCustomize").css("display", "none")
}
function closeCPTSearched(elem) {
    debugger
    $(elem).parentsUntil().find("#divCPTSearched").css("display", "none")
}
function addServiceRow(elem) {


    if ($(elem).hasClass("txtUnits")) {
        var charges = $(elem).closest("tr").find(".hdnClaimCPTCharges").val();
        var Units = $(elem).val();
        var totalCharge = 0;

        if (Units == parseFloat(Units) && charges == parseFloat(charges)) {
            totalCharge = parseFloat(Units) * parseFloat(charges);
            $(elem).closest("tr").find(".txtCharges").val(totalCharge);
        }
    }

    if (!$(elem).closest("tr").is(".lastServiceRow")) {

        return;

    }

    $("#tbodyClaimServices > tr").removeClass("lastServiceRow");
    var serviceRowHtml = $.trim($("#tbodySampleServiceRow").html());
    $("#tbodyClaimServices").append(serviceRowHtml);
}
function SelectCPT(elem) {
    debugger
    $(elem).parents(".SearchCriteria").find("#FilterReports").prop("disabled", false);
    var cptCode = ''; var cptDesc = '';
    cptCode = $.trim($(elem).closest("tr").find(".cpt-code").html());
    cptDesc = $.trim($(elem).closest("tr").find(".cpt-description").html());
    var a = cptCode + ' - ' + cptDesc;
    _CurrentTextBoxCPT = null;
    $("#txtCPTCode").val(a);
    $("#txtCPTDescription").val(cptDesc);
    $("#divCPTSearched").hide();
    SelectServiceCode(cptCode)

}

function FilterPostClaimSummary(Customize) {
    debugger
    var params = "";
    var ClaimStatus = "";
    var POSCode = "";
    var MultipleFiles = "";
    var InsuranceID = ""
    var DateType = "";
    var ReportType = "";
    var BillDateFrom = "";
    var BillDateTo = "";
    var ProviderIds = "";
    var SelectDate = "";

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPlaceOfService'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            POSCode += $.trim($(this).parent().find("#POSCode").val() + ",");
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPlaceOfService'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            POSCode = "";
        }
    }); 
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus += $(this).val() + ",";
        }
    });
    $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus = "";
        }
    });
    if (ClaimStatus.length > 0) {
        ClaimStatus = ClaimStatus.slice(0, -1);
    }
    var MultipleCPTs = $(".spnservicecode").map(function () {
        return $(this).text();
    }).get().join(',');
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiFileStatus'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            MultipleFiles += $.trim($(this).parent().find("#FileId").val() + ",");
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiFileStatus'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            MultipleFiles = "";
        }
    });
    if (MultipleFiles.length > 0) {
        MultipleFiles = MultipleFiles.slice(0, -1);
    }
    if (POSCode.length > 0) {
        POSCode = POSCode.slice(0, -1);
    }
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    if (Customize == "Customize") {

        DateType = $("#" + SubReportDivName).parentsUntil().find("[id$='ddlPostTypeCustomize']").val();
        ReportType = $("#" + SubReportDivName).parentsUntil().find("#ddlReportTypeCustomize").val();
        BillDateFrom = $("#" + SubReportDivName).parentsUntil().find("#CustomizeDateFrom").val();
        BillDateTo = $("#" + SubReportDivName).parentsUntil().find("#CustomizeDateTo").val();
        ProviderIds = $("#" + SubReportDivName).parentsUntil().find("#ProvidersCustomize").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();

    } else {
        DateType = $("#" + SubReportDivName).find("[id$='ddlPostType']").val();
        ReportType = $("#" + SubReportDivName).find("#ddlReportType").val();
        BillDateFrom = $("#" + SubReportDivName).find("#DateFrom").val();
        BillDateTo = $("#" + SubReportDivName).find("#DateTo").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();

    }

    params = {
        DateType: DateType,
        BillDateFrom: BillDateFrom,
        BillDateTo: BillDateTo,
        ProviderIds: ProviderIds,
        ClaimStatus: ClaimStatus,
        CPTCode: MultipleCPTs,
        POSCode: POSCode,
        Payer: InsuranceID,
        ReportType: ReportType,
        SearchFileId: MultipleFiles,
        Action: "Filter"
    };
    $.post("../../ProviderPortal/ReportsNew/CallBacks/ReportPostClaims.aspx", params, function (data) {
        debugger

        var start = data.indexOf("###StartFilter###") + 17;
        var end = data.indexOf("###END###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".checkdetailTbody").html(returnHtml);
        if (($(".checkdetailTbody").find("tr").html()) == "" || ($(".checkdetailTbody").find("tr").html() == undefined)) {
            $(".Pagination_div").css("display", "")
            $(".totalRows").css("display", "none")
            $(".message").html("No Record Found, Please change search criteria").show();
        }
        else {
            $(".message").hide();
        }
        SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
                SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
                $("#" + filename2).empty();

                $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + '</div>');
        var dateArF = BillDateFrom.split('-');
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = BillDateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $("[id$='txtDateFrom']").text(newDateFrom)
        $("[id$='txtDateTo']").text(newDateTo)
        $("[id$='CustomizeDateFrom']").val(BillDateFrom)
        $("[id$='CustomizeDateTo']").val(BillDateTo)
        $("[id$='DateFrom']").val(BillDateFrom)
        $("[id$='DateTo']").val(BillDateTo)
        $("#ddlPostTypeCustomize").val(DateType)
        $("#ddlReportTypeCustomize").val(ReportType)
        $("#ddlPracticeStaffOnNpiNumCustomize").val(ProviderIds)
        $("#ddlPostType").val(DateType)
        $("#ddlReportType").val(ReportType)

        $("#ddlSelectDateCustomize").val(SelectDate);
        $("#ddlSelectDate").val(SelectDate);

        //ShowHideMenu();
        /* $("[id$='FilterReports']").prop("disabled", true);*/
    });
}
function FilterProviderCollectionReport(Customize) {

    debugger
    var DateFrom = '';
    var DateTo = '';
    var TimeSpan = "";
    var ProviderId = "";
    var PracticeLocationId = "";
    var DateType = "";
    var SelectDate = "";
    var InsuranceID = ""
    var Rows1 = $("#ddlPaging").val();
    var Group = $("#ddlGroupBy").val();
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });
    if (Group == "Provider") {

        $("[id$='ProviderCollectionDynamicLocations'] #ProviderCollectionLocationsChk").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("[id$='ProviderCollectionDynamicLocations'] #chkProviderCollectionDynamicLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("[id$='ProviderCollectionProviders'] #chkProviderCollectionProviders").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("[id$='ProviderCollectionProviders'] #ProviderCollectionProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });

    } else {



         $("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocations").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("#ProviderCollectionDynamicProviders #ProviderCollectionDynamicProviderChk").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#ProviderCollectionDynamicProviders #DynamicProviderCollectionProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });
    }


        //$("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocations").each(function () {
        //    if ($(this).is(":checked")) {
        //        PracticeLocationId += $(this).val() + ",";
        //    }
        //});
        //$("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocationsAll").each(function () {
        //    if ($(this).is(":checked")) {
        //        PracticeLocationId = "";
        //    }
        //});
        //$("#ProviderCollectionDynamicProviders #ProviderCollectionDynamicProviderChk").each(function () {
        //    if ($(this).is(":checked")) {
        //        ProviderId += $(this).val() + ",";
        //    }
        //});
        //$("#ProviderCollectionDynamicProviders #DynamicProviderCollectionProviderChkAll").each(function () {
        //    if ($(this).is(":checked")) {
        //        ProviderId = "";
        //    }
        //});

    //}
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateFrom']").val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateTo']").val();
        DateType = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizePostType"] option:selected').val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();

    } else {
        DateFrom = $("#" + SubReportDivName).find("[id$='DateFrom']").val();
        DateTo = $("#" + SubReportDivName).find("[id$='DateTo']").val();
        DateType = $("#" + SubReportDivName).find('[id$="ddlPostType"] option:selected').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();

    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }


    $.post('CallBacks/ProviderCollectionReport.aspx', {
        action: "FilterReport", DateType: DateType, ProviderId: ProviderId, PracticeLocationId: PracticeLocationId,
        DateFrom: DateFrom, DateTo: DateTo, InsuranceID: InsuranceID, Rows: Rows1, PageNumber: 0
    }, function (data) {
        debugger
        var result = "";
        var start = data.indexOf("###StartFilterReport###") + 23;
        var end = data.indexOf("###EndFilterReport###");
        result = $.trim(data.substring(start, end));

        $(".tbodyProviderCollection").html(result);
        if ($(".tbodyProviderCollection").find("tr").html() == "" || $(".tbodyProviderCollection").find("tr").html() == undefined) {
            $(".message").html("No Record Found, Please change search criteria");
        }
        else {
            $(".message").html("");
        }
        var PagesRows = Rows1;
        SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
        SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
        $("#" + filename2).empty();

        $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + PagesRows + '" id = "' + PagesRows + '"  style="display:none" >' + PagesRows + '</div>');
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#ddlSelectDate").val(SelectDate);
        $("#ddlSelectDateCustomize").val(SelectDate);
        $("#ddlPostType").val(DateType);
        $("#CustomizePostType").val(DateType);
        start = data.indexOf("###StartTotal###") + 16;
        end = data.indexOf("###EndTotal###");
        returnHtml = $.trim(data.substring(start, end));
        $("[id$='hdnTotalRows']").val(returnHtml);
        $(".totalRows").html("Total Rows : " + $("[id$='hdnTotalRows']").val())
        var dateArF = DateFrom.split('-');
        GenerateReportPaging($("[id$='hdnTotalRows']").val(), Rows1);
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = DateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $("[id$='txtDateFrom']").text(newDateFrom);
        $("[id$='txtDateTo']").text(newDateTo);
    });
}

function FilterProviderProductivity(Customize) {

    debugger
    var DateFrom = '';
    var DateTo = '';
    var TimeSpan = "";
    var ProviderId = "";
    var PracticeLocationId = "";
    var DateType = ""
    var DateCriteria = "";
    var SelectDate = "";
    var Payers = "";
    var Group = $("#ddlGroupBy option:selected").val();
    var Rows1 = $("#ddlPaging").val();
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Payers += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Payers = "";
        }
    });
    if (Group == "Provider") {

        $("#" + SubReportDivName).parentsUntil().find("[id$='ProviderCollectionDynamicLocations'] #ProviderCollectionLocationsChk").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ProviderCollectionDynamicLocations'] #chkProviderCollectionDynamicLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ProviderCollectionProviders'] #chkProviderCollectionProviders").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ProviderCollectionProviders'] #ProviderCollectionProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });

    } else {
        debugger
        $("#" + SubReportDivName).parentsUntil().find("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocations").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("#ProviderCollectionDynamicProviders #ProviderCollectionDynamicProviderChk").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("#ProviderCollectionDynamicProviders #DynamicProviderCollectionProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });
        
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (Customize == "Customize") {
        DateFrom = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateFrom']").val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateTo']").val();
        DateType = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizePostType"] option:selected').val();
        DateCriteria = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlSelectDateCustomize"]').val()

        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();

    } else {
        DateFrom = $("#" + SubReportDivName).find("[id$='DateFrom']").val();
        DateTo = $("#" + SubReportDivName).find("[id$='DateTo']").val();
        DateType = $("#" + SubReportDivName).find('[id$="ddlPostType"] option:selected').val();
        DateCriteria = $("#" + SubReportDivName).find('[id$="ddlSelectDate"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }


    var claimid = $('#ClaimIdTxt').text();

    $.post('CallBacks/Providerproductivity.aspx', {
        action: "FilterReport", DateType: DateType, claimid: claimid, ProviderId: ProviderId,
        PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo, Payers: Payers, Rows: Rows1, PageNumber: 0
    }, function (data) {
        debugger
        var result = "";
        var start = data.indexOf("###StartFilterReport###") + 23;
        var end = data.indexOf("###EndFilterReport###");
        result = $.trim(data.substring(start, end));
        //var start = data.indexOf("###TimeSpanStart###") + 19;
        //var end = data.indexOf("###TimeSpanEnd###");
        //var returnHtml = $.trim(data.substring(start, end));
        /*        $('[id$="TimeSpan"]').text(returnHtml)*/
        $(".Providerproductivity").html(result);
        if ($(".Providerproductivity").find("tr").html() == "" || $(".Providerproductivity").find("tr").html() == undefined) {
            $(".message").html("No Record Found, Please change search criteria").show();
        }
        else {
            $(".message").html("");
        }
        var PagesRows = Rows1;
        SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
        SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
        $("#" + filename2).empty();

        $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + PagesRows + '" id = "' + PagesRows + '"  style="display:none" >' + PagesRows + '</div>');
        var dateArF = DateFrom.split('-');
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = DateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $("[id$='txtDateFrom']").text(newDateFrom)
        $("[id$='txtDateTo']").text(newDateTo)
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $('[id$="CustomizePostType"]').val(DateType);
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $('[id$="ddlPostType"]').val(DateType);
        $('[id$="ddlSelectDateCustomize"]').val(DateCriteria);
        $('[id$="ddlSelectDate"]').val(DateCriteria);

        $("#ddlSelectDateCustomize").val(SelectDate);
        $("#ddlSelectDate").val(SelectDate);
        start = data.indexOf("###StartTotal###") + 16;
        end = data.indexOf("###EndTotal###");
        returnHtml = $.trim(data.substring(start, end));
        $("[id$='hdnTotalRows']").val(returnHtml);
        $(".totalRows").html("Total Rows : " + $("[id$='hdnTotalRows']").val())
        /*End Added By faiza Bilal 3-30-2022*/
    });
    /*Added By faiza Bilal 3-24-2022*/
    TimeSpanProvidercol = TimeSpan;
    DateFromProvidercol = DateFrom;
    DateToProvidercol = DateTo;
    /*End Added By faiza Bilal 3-24-2022*/
}

function EnableDisableFilter(elem) {
    debugger
    $(elem).parents(".SearchCriteria").find("#FilterReports").prop("disabled", false);
    var a = $(elem).find("#ddlPostType").val();
    var b = $(elem).find("#ddlPostTypeCustomize").val();
    if (a == "" || a == undefined) {
        $("[id$='ddlPostType']").val(b);
        $("[id$='ddlPostTypeCustomize']").val(b);
    }
    else {
        $("[id$='ddlPostType']").val(a);
        $("[id$='ddlPostTypeCustomize']").val(a);
    }
}
var PatientName = "";
function searchPatient(event, elem) {
    debugger
    PatientName = $("#TxtPatientSearch").val();
    if (PatientName == "" || PatientName == undefined) {
        $("#hdnsearchpatientid").val("");
    }
    var Action = "Patient"
    //if (event.keyCode == 13) {
        $.post("CallBacks/PatientSearchForReports.aspx", { PatientName: PatientName, Action: Action }, function (data) {
            debugger;
            var returnHtml = data;
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf("###End###");
            $(elem).parentsUntil(".SearchCriteria").find("#SearchPatientList").html(returnHtml.substring(start, end))
            $(elem).parentsUntil(".SearchCriteria").find("#SearchPatientList").toggle();

            //$(elem).parents.find("#SearchPatientList").html(returnHtml.substring(start, end));
            //$(elem).parents.("#SearchPatientList").toggle();
        });
    //}
    //if (event.type == "click") {
        //$.post("CallBacks/PatientSearchForReports.aspx", { PatientName: PatientName, Action: Action }, function (data) {
        //    debugger;
        //    var returnHtml = data;
        //    var start = data.indexOf("###Start###") + 11;
        //    var end = data.indexOf("###End###");
        //    $(elem).parentsUntil(".SearchCriteria").find("#SearchPatientList").html(returnHtml.substring(start, end))
        //    $(elem).parentsUntil(".SearchCriteria").find("#SearchPatientList").toggle();
        //    //$("#SearchPatientList").html(returnHtml.substring(start, end));
        //    //$("#SearchPatientList").toggle();
        //});
    //}
}



function searchIcDs(searchBy, code, desc, elm, event) {
    debugger;
    _CurrentTextBoxICD = $(elm);
    if (event.keyCode == 27) {
        $("#divICDsSearched").hide("");
        return false;

    }
    var array = code.split('-');
    code = array[0];
    if (event.keyCode == 13) {
        $.post("CallBacks/ICDSearch.aspx", { Code: $.trim(code), Description: $.trim(desc) }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartICDSearch###") + 22;
            var end = data.indexOf("###EndICDSearch###");
            $("#divICDsSearched").html(returnHtml.substring(start, end));

            var tdClass = $(elm).closest("td").attr('class');

            if (tdClass == "leftTd") {
                //$("#divICDsSearched").css({
                //    left: 7 + "%",
                //    top: $(elm).offset().top - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + $(elm).closest("td").height() + "px"
                //});
            }
            else if (tdClass == "rightTd") {
                var _leftCss;
                if ($(elm).attr("id") == "txtIcdCode2" || $(elm).attr("id") == "txtIcdCode4") {
                    //_leftCss = $(elm).offset().left + "px";
                } else {
                    //_leftCss = $(elm).offset().left - ($("#divICDsSearched").width() - $(elm).closest("td").width()) - 35 + "px";
                }
                $("#divICDsSearched").css({
                    //left: _leftCss,
                    //top: $(elm).offset().top - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + $(elm).closest("td").height() + "px"
                });

            }
            //$("#divICDsSearched").show();

            $("#divICDsSearched").slideDown("slow");
            $("#divICDsSearched").scrollTop(0);
            searchfrom = $(elm).attr('id');
        });

    }



}
function SelectPatientId(elem) {
    debugger
    var Id = $.trim($(elem).find('td:eq(0)').html());
    var Name = $.trim($(elem).find('td:eq(1)').html());
    $(elem).parentsUntil(".SearchCriteria").find("#TxtPatientSearch").val(Name)
    $(elem).parentsUntil(".SearchCriteria").find("#hdnsearchpatientid").val(Id)
    $(elem).parentsUntil(".SearchCriteria").find("#SearchPatientList").hide()

    //$("#TxtPatientSearch").val(Name);
    //$("#hdnsearchpatientid").val(Id);
    //$("#SearchPatientList").hide();
}
//function SelectCustomizePatientId(elem) {
//    debugger
//    var Id = $.trim($(elem).find('td:eq(0)').html());
//    var Name = $.trim($(elem).find('td:eq(1)').html());


//    $("#TxtPatientSearch").val(Name);
//    $("#hdnsearchpatientid").val(Id);
//    $("#SearchPatientList").hide();
//}

function CustomizePatientsReports(ReportName) {
    debugger
    OpenPatientFilterDialog(ReportName, true);
}
function FilterPatientVisitsReport(elem) {
    debugger
    var DateFrom = $("#DateFrom").val();
    var DateTo = $("#DateTo").val();
    var action = "Filter";
    var params = {
        DateFrom: DateFrom,
        DateTo: DateTo,
        action: action
    }
    $.post("../../ProviderPortal/ReportsNew/filter/FilterPatientVisits.aspx", params, function (data) {
        debugger;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        result = (data.substring(start, end));
        $("#reportItem").html(result);
        $('.SelectFilterMessage').css("display", "none")

    });
}
function FilterItemizationOfChargesReport(Customize) {
    debugger
    var params = "";
    var PatientId = "";
    var ProviderId = "";
    var PayersName = "";
    var PayerId = "";
    var Location = "";
    var Name = ""
    var DateType = "";
    var AsOf = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
            PayersName += $.trim($(this).parent().find("#PayersName").html() + ",");
        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PayersName = "";
            PayerId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Location += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Location = "";
        }
    });
    if (PayersName.substring(0, 8) == "SelfPay,") {
        Payers = '1' + Payers.slice(1);
    }
    if (Customize == "Customize") {
        DateType = $("#" + SubReportDivName).parentsUntil().find("#CustomizeDateType").val()
        PatientId = $("#" + SubReportDivName).parentsUntil().find("#hdnsearchpatientidCustomize").val()
        AsOf = $("#" + SubReportDivName).parentsUntil().find("#dateasofCustomize").val()
        Name = $("#" + SubReportDivName).parentsUntil().find("#TxtPatientSearchCustomize").val();
    }
    else {
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val(),
            PatientId = $("#" + SubReportDivName).find("#hdnsearchpatientid").val()
        AsOf = $("#" + SubReportDivName).find("#dateasof").val()
        Name = $("#" + SubReportDivName).find("#TxtPatientSearch").val();

    }

    Action = "Filter"
    params = {
        DateType,
        PatientId,
        AsOf,
        Action,
        ProviderId,
        PayerId,
        Location
    }
    //OpenReportPage("FilterItemizationOfCharges.aspx", _isParameters, params, "FilterItemizationOfCharges", "", "Itemization Of Charges");
    //Report_ReloadData(_selectedReport_Filter, params, false);

    $.post("../../ProviderPortal/ReportsNew/filter/FilterItemizationOfCharges.aspx", params, function (data) {
        debugger;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        result = (data.substring(start, end));
        $("#reportItem").html(result);
        $('.SelectFilterMessage').css("display", "none")
        $("#CustomizeDateType").val(DateType)
        $("#hdnsearchpatientidCustomize").val(PatientId)
        $("#dateasofCustomize").val(AsOf)
        $("#ddlPostType").val(DateType)
        $("#hdnsearchpatientid").val(PatientId)
        $("#dateasof").val(AsOf)
        $("#TxtPatientSearch").val(Name);
        $("#TxtPatientSearchCustomize").val(Name);
        $("#hdnsearchpatientidCustomize").val(PatientId);
        if ($("#tbodyReportList").find("tr").find("td").html() == "" || $("#tbodyReportList").find("tr").find("td").html() == undefined) {
            $(".message").html("No Record Found, Please change search criteria").show();
        }
        else {
            $(".message").html("");
        }
    });
}


function FilterPTLPatientReport(Customize) {
    debugger
    var params = "";
    var PayersName = "";
    var PayerId = "";
    var Location = "";
    var DateFrom = "";
    var DateTo = "";
    var DateType = "";
    var SelectDate = "";
    var Rows = $("#ddlPaging").val();
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";

        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PayerId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Location += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Location = "";
        }
    });
    if (PayersName.substring(0, 2) == "0,") {
        PayerId = '1' + PayerId.slice(1);
    }
    if (Location.length>0) {
        Location = Location.slice(0,-1);
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        
        DateType = $("#" + SubReportDivName).parentsUntil().find("[id$='divddlPostTypeCustomize'] option:selected").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlSelectDateCustomize"]').val()

    } else {

        DateType = $("#" + SubReportDivName).find("#divddlPostType option:selected").val();
            DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find('[id$="ddlSelectDate"]').val();
    }
    Action = "Filter"
    params = {
        Action: Action,
        PayerId: PayerId,
        Location: Location,
        DateFrom: DateFrom,
        DateTo: DateTo,
        DateType: DateType,
        Rows: Rows,
        PageNumber: 0
    }

    //OpenReportPage("FilterItemizationOfCharges.aspx", _isParameters, params, "FilterItemizationOfCharges", "", "Itemization Of Charges");
    //Report_ReloadData(_selectedReport_Filter, params, false);

    Report_ReloadData("FilterPtlDetail.aspx", params, true)
    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#divddlPostType").val(DateType);
    $("#ddlPostType").val(DateType);
    $("#divddlPostTypeCustomize").val(DateType);
    $('[id$="ddlSelectDateCustomize"]').val(SelectDate)
    $('[id$="ddlSelectDate"]').val(SelectDate)
}

function FilterPTLClaimReport(Customize) {
    debugger
    var params = "";
    var PayersName = "";
    var PayerId = "";
    var Location = "";
    var DateFrom = "";
    var DateTo = "";
    var SelectDate = "";
    var DateType = "";

    var Rows = $("#ddlPaging").val();
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";

        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PayersName = "";
            PayerId = "";
        }
    });
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Location += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Location = "";
        }
    });
    if (Location.length > 0) {
        Location = Location.slice(0, -1);
    }
    if (PayerId.substring(0, 2) == "0,") {
        PayerId = '1' + PayerId.slice(1);
    }
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();

    }
    else {
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val(),
            DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }
    params = {
        PayerId: PayerId,
        Location: Location,
        DateFrom: DateFrom,
        DateTo: DateTo,
        DateType: DateType,
        Rows: Rows,
        PageNumber: 0,
        Action: "Filter"
    }
    //OpenReportPage("FilterItemizationOfCharges.aspx", _isParameters, params, "FilterItemizationOfCharges", "", "Itemization Of Charges");
    //Report_ReloadData(_selectedReport_Filter, params, false);

    Report_ReloadData("FilterPtlClaim.aspx", params, true)
    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $("#divddlPostTypeCustomize").val(DateType);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#divddlPostType").val(DateType);
    $("#ddlSelectDateCustomize").val(SelectDate)
    $("#ddlSelectDate").val(SelectDate)
}

function searchPatientCustomize(event, elem) {
    debugger
    PatientName = $("#TxtPatientSearchCustomize").val();
    if (PatientName == "") {
        $("#hdnsearchpatientidCustomize").val("");
        $("#hdnsearchpatientid").val("");
    }
        $.post("CallBacks/PatientSearchForReports.aspx", { PatientName: PatientName }, function (data) {
            debugger;
            var returnHtml = data;
            var start = data.indexOf("###StartCustomizePatient###") + 27;
            var end = data.indexOf("###EndCustomizePatient###");
            $(elem).parentsUntil(".SearchCriteria").find("#SearchPatientListCustomize").html(returnHtml.substring(start, end))
            $(elem).parentsUntil(".SearchCriteria").find("#SearchPatientListCustomize").toggle();
            //$("#SearchPatientListCustomize").html(returnHtml.substring(start, end));
            //$("#SearchPatientListCustomize").toggle();
        });
}

function SelectCustomizePatientId(elem) {
    debugger
    var Id = $.trim($(elem).find('td:eq(0)').html());
    var Name = $.trim($(elem).find('td:eq(1)').html());

    $(elem).parentsUntil(".SearchCriteria").find("#TxtPatientSearchCustomize").val(Name);
    $(elem).parentsUntil(".SearchCriteria").find("#hdnsearchpatientidCustomize").val(Id);
    $(elem).parentsUntil(".SearchCriteria").find("#SearchPatientListCustomize").hide();
}
function EnableDisableDateFields(elem) {
    debugger
    if ($(elem).parent().find("#ddlSelectDate").val() != "" && $(elem).parent().find("#ddlSelectDate").val() != "Custom") {
        $("#DateFrom").val("");
        $("#DateTo").val("")
        $("#" + SubReportDivName).find("#DateFrom").prop('disabled', true);
        $("#" + SubReportDivName).find("#PatientBalanceDateFrom").prop('disabled', true);
        $("#" + SubReportDivName).find("#DateTo").prop('disabled', true);
        $("#" + SubReportDivName).find("#PatientBalanceDateTo").prop('disabled', true);
    } else {
        $("#" + SubReportDivName).find("#DateFrom").prop('disabled', false);
        $("#" + SubReportDivName).find("#PatientBalanceDateFrom").prop('disabled', false);
        $("#" + SubReportDivName).find("#DateTo").prop('disabled', false);
        $("#" + SubReportDivName).find("#PatientBalanceDateTo").prop('disabled', false);

    }
}
function EnableDisableDateFieldsCustomize(elem) {
    debugger
    if ($(elem).parent().find("#ddlSelectDateCustomize").val() != "") {
        $(elem).parentsUntil(".row").find("#CustomizeDateFrom").val("");
        $(elem).parentsUntil(".row").find("#CustomizeDateTo").val("")
        $(elem).parentsUntil(".row").find("#CustomizeDateFrom").prop('disabled', true);
        $(elem).parentsUntil(".row").find("#CustomizeDateTo").prop('disabled', true);
    } else {
        $(elem).parentsUntil(".row").find("#CustomizeDateFrom").prop('disabled', false);
        $(elem).parentsUntil(".row").find("#CustomizeDateTo").prop('disabled', false);
    }
}
function GetDatesCustomize(elem) {
    debugger
    var d = new Date();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    var lastMonth = d.getMonth();
    var lastDay = new Date(year, month - 1, 0).getDate();
    var day = d.getDate();
    EnableDisableDateFieldsCustomize(elem);
    var a = $(elem).parent().find("#ddlSelectDateCustomize").val();
    $("#" + SubReportDivName).find("#ddlSelectDate").val(a);
    $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val(a);

    if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "") {

        DateFrom = $(elem).parentsUntil(".row").find("#CustomizeDateFrom").val("");
        DateTo = $(elem).parentsUntil(".row").find("#CustomizeDateTo").val("");
        DateFrom = "";
        DateTo = "";
        return;

    }
    else if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "SD") {
        DateFrom = $(elem).parentsUntil(".row").find("#CustomizeDateFrom").val("");
        DateTo = $(elem).parentsUntil(".row").find("#CustomizeDateTo").val("");
        DateFrom = "";
        DateTo = "";

        return

    }

    else if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "today") {
        var Td = new Date();
        var month = Td.getMonth() + 1;
        var day = Td.getDate();
        DateFrom = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;

        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("[id$='DateTo']").val(DateTo);


        return
    }
    else if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "LastMonth") {

        if (month == "1") {
            year = d.getFullYear() - 1;
            lastDay = new Date(year, month - 1, 0).getDate();
            month = d.getMonth() + 1;
            if (lastMonth == "0") {
                lastMonth = "12";
            }
        }
        DateFrom = year + '-' + (lastMonth < 10 ? '0' : '') + lastMonth + '-01';
        DateTo = year + '-' + (lastMonth < 10 ? '0' : '') + lastMonth + '-' + (lastDay < 10 ? '0' : '') + lastDay;


        //DateFrom = formatDate(DateFrom);
        //DateTo = formatDate(DateTo);
        $("#CustomizeDateFrom").val(DateFrom);
        $("#DateFrom").val(DateFrom);
        $("#CustomizeDateTo").val(DateTo);
        $("#DateTo").val(DateTo);
    }
    else if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "L6M") {

        var d = new Date();
        var month = d.getMonth() + 1;
        var year = d.getFullYear();

        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        var lastDay = new Date(date.getFullYear(), date.getMonth() - 5, 0);

        DateFrom = (lastDay.getFullYear() + '-' + ((lastDay.getMonth() + 1) < 10 ? '0' : '') + (lastDay.getMonth() + 1) + '-' + (firstDay.getDate() < 10 ? '0' : '') + firstDay.getDate());

        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        var lastDay = new Date(date.getFullYear(), date.getMonth() - 0, 0);

        var days = "";
        if (lastDay.getMonth() + 1 == 1 || lastDay.getMonth() + 1 == 3 || lastDay.getMonth() + 1 == 5 || lastDay.getMonth() + 1 == 7 || lastDay.getMonth() + 1 == 8
            || lastDay.getMonth() + 1 == 10 || lastDay.getMonth() + 1 == 12) {
            days = 30;
        }
        else if (lastDay.getMonth() + 1 == 2) {
            days = 27;
        }
        else if (lastDay.getMonth() + 1 == 4 || lastDay.getMonth() + 1 == 6 || lastDay.getMonth() + 1 == 9 || lastDay.getMonth() + 1 == 11) {
            days = 29;
        }

        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        $("#CustomizeDateFrom").val(DateFrom);
        $("#DateFrom").val(DateFrom);
        $("#CustomizeDateTo").val(DateTo);
        $("#DateTo").val(DateTo);
    }
    else if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "YTD") {
        DateFrom = year + '-' + '01-01';
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        $("#CustomizeDateFrom").val(DateFrom);
        $("#DateFrom").val(DateFrom);
        $("#CustomizeDateTo").val(DateTo);
        $("#DateTo").val(DateTo);

    }
    else if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "CurrentMonth") {
        DateFrom = year + '-' + (month < 10 ? '0' : '') + month + '-01';
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        $("#CustomizeDateFrom").val(DateFrom);
        $("#DateFrom").val(DateFrom);
        $("#CustomizeDateTo").val(DateTo);
        $("#DateTo").val(DateTo);
    }
    else if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "LY") {
        var d = new Date();
        var month = d.getMonth() + 1;
        var year = d.getFullYear() - 1;
        var lastMonth = d.getMonth();
        var last3Month = d.getMonth() - 2;
        var lastDay = new Date(year, month - 1, 0).getDate();

        DateFrom = year + '-01-01';
        DateTo = year + '-12-31';
        $("#CustomizeDateFrom").val(DateFrom);
        $("#DateFrom").val(DateFrom);
        $("#CustomizeDateTo").val(DateTo);
        $("#DateTo").val(DateTo);
    }
    else if ($(elem).parent().find("#ddlSelectDateCustomize").val() == "FB") {
        DateFrom = "1950-01-01";
        var nowDate = new Date();
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        $("#CustomizeDateFrom").val(DateFrom);
        $("#DateFrom").val(DateFrom);
        $("#CustomizeDateTo").val(DateTo);
        $("#DateTo").val(DateTo);
    }
    $("[id$='CustomizeDateFrom']").val(DateFrom);
    $("[id$='DateFrom']").val(DateFrom);
    $("[id$='CustomizeDateTo']").val(DateTo);
    $("[id$='DateTo']").val(DateTo);

}
function GetDates(elem) {
    debugger

    EnableDisableDateFields(elem);
    var d = new Date();
    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    var lastMonth = d.getMonth();
    var lastDay = new Date(year, month - 1, 0).getDate();
    var day = d.getDate();
    var SelectDate = $(elem).parent().find("#ddlSelectDate").val();
    $("#" + SubReportDivName).find("#ddlSelectDate").val(SelectDate);
    $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val(SelectDate);
    if ($(elem).parent().find("#ddlSelectDate").val() == "") {
        DateFrom = $("#DateFrom").val("");
        DateFrom = $("#CustomizeDateFrom").val("");
        DateTo = $("#DateTo").val("");
        DateTo = $("#CustomizeDateTo").val("");
        DateFrom = "";
        DateTo = "";
        return;

    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "SD") {
        DateFrom = $("#DateFrom").val("");
        DateTo = $("#DateTo").val("");
        DateFrom = "";
        DateTo = "";

        return

    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "Custom") {
        DateFrom = $("#" + SubReportDivName).find("#DateFrom").prop("disabled", false);
        DateTo = $("#" + SubReportDivName).find("#DateTo").prop("disabled", false);
        $("#" + SubReportDivName).find("#dateasof").prop("disabled", false);

        return
    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "today") {
        var Td = new Date();
        var month = Td.getMonth() + 1;
        var day = Td.getDate();
        DateFrom = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;

        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='dateasof']").val(DateTo);
        $("[id$='dateasof']").prop('disabled', true);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val(SelectDate);
        $("[id$='ddlSelectDateCustomize']").val(SelectDate);

        return
    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "yesterday") {
        $today = new Date();
        $yesterday = new Date($today);
        $yesterday.setDate($today.getDate() - 1);
        var $dd = $yesterday.getDate();
        var $mm = $yesterday.getMonth() + 1; //January is 0!
        var $yyyy = $yesterday.getFullYear();

        DateFrom = $yyyy + '-' + ($mm < 10 ? '0' : '') + $mm + '-' + ($dd < 10 ? '0' : '') + $dd;
        DateTo = $yyyy + '-' + ($mm < 10 ? '0' : '') + $mm + '-' + ($dd < 10 ? '0' : '') + $dd;
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='dateasof']").val(DateTo);
        $("[id$='dateasof']").prop('disabled', true);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val(SelectDate);
        $("[id$='ddlSelectDateCustomize']").val(SelectDate);
    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "LastMonth") {

        if (month == "1") {
            year = d.getFullYear() - 1;
            lastDay = new Date(year, month - 1, 0).getDate();
            month = d.getMonth() + 1;
            if (lastMonth == "0") {
                lastMonth = "12";
            }
        }
        DateFrom = year + '-' + (lastMonth < 10 ? '0' : '') + lastMonth + '-01';
        DateTo = year + '-' + (lastMonth < 10 ? '0' : '') + lastMonth + '-' + (lastDay < 10 ? '0' : '') + lastDay;


        //DateFrom = formatDate(DateFrom);
        //DateTo = formatDate(DateTo);
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val(SelectDate);
        $("[id$='ddlSelectDateCustomize']").val(SelectDate);
    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "L6M") {

        var d = new Date();
        var month = d.getMonth() + 1;
        var year = d.getFullYear();

        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        var lastDay = new Date(date.getFullYear(), date.getMonth() - 5, 0);

        DateFrom = (lastDay.getFullYear() + '-' + ((lastDay.getMonth() + 1) < 10 ? '0' : '') + (lastDay.getMonth() + 1) + '-' + (firstDay.getDate() < 10 ? '0' : '') + firstDay.getDate());

        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        var lastDay = new Date(date.getFullYear(), date.getMonth() - 0, 0);

        var days = "";
        if (lastDay.getMonth() + 1 == 1 || lastDay.getMonth() + 1 == 3 || lastDay.getMonth() + 1 == 5 || lastDay.getMonth() + 1 == 7 || lastDay.getMonth() + 1 == 8
            || lastDay.getMonth() + 1 == 10 || lastDay.getMonth() + 1 == 12) {
            days = 30;
        }
        else if (lastDay.getMonth() + 1 == 2) {
            days = 27;
        }
        else if (lastDay.getMonth() + 1 == 4 || lastDay.getMonth() + 1 == 6 || lastDay.getMonth() + 1 == 9 || lastDay.getMonth() + 1 == 11) {
            days = 29;
        }

        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val(SelectDate);
        $("[id$='ddlSelectDateCustomize']").val(SelectDate);
    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "YTD") {
        DateFrom = year + '-' + '01-01';
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val(SelectDate);
        $("[id$='ddlSelectDateCustomize']").val(SelectDate);

    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "CurrentMonth") {
        DateFrom = year + '-' + (month < 10 ? '0' : '') + month + '-01';
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val(SelectDate);
        $("[id$='ddlSelectDateCustomize']").val(SelectDate);
    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "LY") {
        var d = new Date();
        var month = d.getMonth() + 1;
        var year = d.getFullYear() - 1;
        var lastMonth = d.getMonth();
        var last3Month = d.getMonth() - 2;
        var lastDay = new Date(year, month - 1, 0).getDate();

        DateFrom = year + '-01-01';
        DateTo = year + '-12-31';
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val(SelectDate);
        $("[id$='ddlSelectDateCustomize']").val(SelectDate);
    }
    else if ($(elem).parent().find("#ddlSelectDate").val() == "FB") {
        DateFrom = "1950-01-01";
        var nowDate = new Date();
        DateTo = year + '-' + (month < 10 ? '0' : '') + month + '-' + (day < 10 ? '0' : '') + day;
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='CustomizeDateTo']").val(DateTo);
    }
    $("[id$='DateFrom']").val(DateFrom);
    $("[id$='CustomizeDateFrom']").val(DateFrom);
    $("[id$='DateTo']").val(DateTo);
    $("[id$='CustomizeDateTo']").val(DateTo);
    $("#" + SubReportDivName).find("[id$='ddlSelectDate']").val(SelectDate);
    $("[id$='ddlSelectDateCustomize']").val(SelectDate);


}

function formatDate(value) {
    return value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
}
function FilterCompanyIndicator(elem) {
    debugger

    var DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
    var DateFrom = $("#" + SubReportDivName).find("#DateFrom").val();
    var DateTo = $("#" + SubReportDivName).find("#DateTo").val();

    params = {
        DateFrom: DateFrom,
        DateTo: DateTo,
        DateType: DateType,


        action: "Filter"
    };
    //Report_ReloadData("FilterCompanyIndicatorReport.aspx", params, true)

    $.post('filter/FilterCompanyIndicatorReport.aspx', params, function (data) {
        debugger
        var start = data.indexOf("###start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".CompanyIndicator").html(returnHtml)

        var start = data.indexOf("###TimeSpanStart###") + 19;
        var end = data.indexOf("###TimeSpanEnd###");
        var returnHtml = $.trim(data.substring(start, end));
        $('[id$="TimeSpan"]').text(returnHtml)
        SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
        SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
        $("#" + filename2).empty();

        $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + "," + '</div>');
    });
}
function FilterPaymentsDetail(elem, Customize) {
    debugger
    Rows1 = $("#ddlPaging").val();
    var DateFrom = '';
    var DateTo = '';
    var InsuranceID = ""
    var InsuranceName=""
    var CheckNo = ""
    var PaymentType = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceName += $(this).val() + ",";
            InsuranceID += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
            InsuranceName = "";
        }
    });
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    if (InsuranceName.length > 0) {
        InsuranceName = InsuranceName.slice(0, -1);
    }
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateFrom']").val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateTo']").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
        CheckNo = $("#" + SubReportDivName).parentsUntil().find("#ddlCheckNumber").val() || "";
        PaymentType = $("#" + SubReportDivName).parentsUntil().find("#ddlPaymentType option:selected").val();

    } else {
        DateFrom = $("#" + SubReportDivName).find("[id$='DateFrom']").val();
        DateTo = $("#" + SubReportDivName).find("[id$='DateTo']").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();

    }
    if (CheckNo == "All") {
        CheckNo = "";
    }

    params = {
        DateFrom: DateFrom,
        DateTo: DateTo,
        Rows: Rows1,
        Paymentid: CheckNo,
        Payers: InsuranceName,
        PaymentType: PaymentType,
        PageNumber: 0,
    };
    Report_ReloadData("FilterPaymentsDetailReport.aspx", params, true);
    $('[id$="dateFromCustomize"]').val(DateFrom);
    $('[id$="dateToCustomize"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#ddlCheckNumber").val(CheckNo);
    $("#ddlPaymentType option:selected").val(PaymentType);
    $("[id$='ddlSelectDate']").val(SelectDate);
    $("[id$='ddlSelectDateCustomize']").val(SelectDate);
}

function FilterPaymentApplicationSumary(Customize) {
    debugger
    var StartDate = "";
    var EndDate = "";
    var DateType = "";
    // Add by iqra 16/30/2022 Resolve Filter bugs//
    var InsuranceID = "";
    var ProviderId = "";
    var PracticeLocationId = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    // End by iqra 16/30/2022 //
    if (Customize == "Customize") {
        StartDate = $("#" + SubReportDivName).parentsUntil().find("#CustomizeDateFrom").val();
        EndDate = $("#" + SubReportDivName).parentsUntil().find("#CustomizeDateTo").val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
    }
    else {
        StartDate = $("#" + SubReportDivName).find("#DateFrom").val();
        EndDate = $("#" + SubReportDivName).find("#DateTo").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
    }
    $.post('filter/FilterPaymentApplicationSummaryReport.aspx', { action: "FilterPaymentApplicationSummary", DateFrom: StartDate, DateTo: EndDate, DateType, InsuranceID, ProviderId, PracticeLocationId}, function (data) {
        debugger
        var start = data.indexOf("###Start###") + 12;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".ReportGrid").html(returnHtml)
        var start = data.indexOf("###TimeSpanStart###") + 19;
        var end = data.indexOf("###TimeSpanEnd###");
        var returnHtml = $.trim(data.substring(start, end));
        $('[id$="TimeSpan"]').text(returnHtml);
        $('[id$="CustomizeDateFrom"]').val(DateFrom);
        $('[id$="CustomizeDateTo"]').val(DateTo);
        $('[id$="DateFrom"]').val(DateFrom);
        $('[id$="DateTo"]').val(DateTo);
	$('[id$="ddlDateType"]').val(DateType);
	$('[id$="ddlDateTypeCustomize"]').val(DateType);
        $("[id$='ddlSelectDate']").val(SelectDate);
        $("[id$='ddlSelectDateCustomize']").val(SelectDate);
    });
}
function GetPayerDropDown(elem) {
    debugger
    var payerName = "";
    var checkNumber = "";
    /*    $("#CustomizePayersName").val("")*/
    /*    $("#ddlPayerName").val("")*/
    //$("#ddlCheckNumber").val("");
    //$("#ddlPostDate").val("");
    $('.ddlPayerName').each(function () {
        {
            payerName = $("option:selected", this).val();
        }
    });
    $('.ddlCheckNumber').each(function () {
        {
            checkNumber = $("option:selected", this).val();
        }
    });
    var params = {
        PayerName: payerName,
        CheckNumber: checkNumber,
        action: "Filter"
    };

    $.post("CallBacks/GetPayerDetailDropdown.aspx", params, function (data) {
        if (elem == "divddlCheckNumber") {
            debugger
            var start = data.indexOf("###StartCheckNumber###") + 22;
            var end = data.indexOf("###EndCheckNumber###");
            var returnHtml = $.trim(data.substring(start, end));

            $("#divddlCheckNumber").html(returnHtml)
            var start = data.indexOf("###StartPostDate###") + 19;
            var end = data.indexOf("###EndPostDate###");
            var returnHtml = $.trim(data.substring(start, end));

            $("#divddlPostDate").html(returnHtml)


        }
        else if (elem == "divddlPostDate") {
            debugger
            var start = data.indexOf("###StartPostDate###") + 19;
            var end = data.indexOf("###EndPostDate###");
            var returnHtml = $.trim(data.substring(start, end));

            $("#divddlPostDate").html(returnHtml)
        }

    });
}
function FilterPaymentApplicationReport(Customize) {
    var PayerName = "";
    var CheckNumber = "";
    var PostDate = "";
    var params = "";
    var PatientId = "";
    var SelectDate = "";
    var Action = "";
    debugger
    Rows1 = $("#ddlPaging").val();
    if (Customize == "Customize") {
        PayerName = $("#" + SubReportDivName).parentsUntil().find("#CustomizePayersName option:selected").val();
        CheckNumber = $("#" + SubReportDivName).parentsUntil().find("#ddlCheckNumber option:selected").val();
        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        PatientId = $("#" + SubReportDivName).parentsUntil().find("#hdnsearchpatientid").val()
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
        Action = "Customize";
    } else {
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();

        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        Action = "Filter";
    }
    params =
    {
        PayerName: PayerName,
        Rows: Rows1,
        PageNumber: 0,
        PayerName: PayerName,
        CheckNumber: CheckNumber,
        DateFrom: DateFrom,
        DateTo: DateTo,
        PatientId: PatientId,
        Action: Action

    };
    Report_ReloadData("FilterPaymentApplicationReport.aspx", params, true)
    debugger
    $("#CustomizePayersName").val(PayerName)
    $("#ddlPayerName").val(PayerName)
    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#ddlSelectDateCustomize").val(SelectDate);
    $("#ddlSelectDate").val(SelectDate);
    $("#ddlCheckNumber").val(CheckNumber);



}
function FilterUnappliedAnalysisReport(Customize) {
    debugger
    Rows1 = $("#ddlPaging").val();
    var PaymentType = "";
    var Insurance = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Insurance += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Insurance = "";
        }
    });
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        PaymentType = $('[id$="ddlPaymentType"] option:selected').val();


    } else {

        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
    }


    var params =
    {
        DateFrom: DateFrom,
        DateTo: DateTo,
        PaymentType: PaymentType,
        Insurance: Insurance
    };
    // Report_ReloadData("FilterUnAppliedAnalysis.aspx", params, true)

    $.post("../../ProviderPortal/ReportsNew/filter/FilterUnAppliedAnalysis.aspx", params, function (data) {
        debugger;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        result = (data.substring(start, end));
        $("#tbodyReportList").html(result);

        var start = data.indexOf("###StartBeginingUnappliedBalance###") + 35;
        var end = data.indexOf("###EndBeginingUnappliedBalance###");
        var returnHtml = $.trim(data.substring(start, end));
        $('[id$="BeginingUnappliedBalance"]').html(returnHtml)

        var start = data.indexOf("###StartChangeUnapliedBallance###") + 33;
        var end = data.indexOf("###EndChangeUnapliedBallance###");
        var returnHtml = $.trim(data.substring(start, end));
        $('[id$="ChangeUnapliedBallance"]').html(returnHtml)


        //var start = data.indexOf("###StartEndingUnappliedBalance###") + 34;
        //var end = data.indexOf("###EndEndingUnappliedBalance###");
        //var returnHtml = $.trim(data.substring(start, end));
        //$('[id$="EndingUnappliedBalance"]').html(returnHtml)
        var start = data.indexOf("###TimeSpanStart###") + 19;
        var end = data.indexOf("###TimeSpanEnd###");
        var returnHtml = $.trim(data.substring(start, end));
        $('[id$="TimeSpan"]').html(returnHtml)
        $('.SelectFilterMessage').css("display", "none")

    });

    // ShowHideMenu();


}
function FilterOverPaidClaimsReport(Customize) {
    debugger
    Rows1 = $("#ddlPaging").val();
    var DateFrom = '';
    var DateTo = '';
    var ProviderId = "";
    var LocationId = "";
    var DateType = "";
    var Insurance = "";
    var ClaimStatus = "";
    var InsuranceType = "";
    var PlaceOfService = '';
    var SelectDate = "";
    debugger
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Insurance += $(this).val() + ",";
            PlaceOfService += $(this).parent().find("span").html() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Insurance = "";
            PlaceOfService = "";
        }
    });
    if (PlaceOfService.length > 0) {
        PlaceOfService = PlaceOfService.slice(0, -1);
    }
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus += $.trim($(this).val() + ",");
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus = "";
        }
    });
    if (ClaimStatus.length > 0) {
        ClaimStatus = ClaimStatus.slice(0, -1);
    }
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            LocationId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            LocationId = ""
        }
    });
    if (LocationId.length > 0) {
        LocationId = LocationId.slice(0, -1);
    }
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (PlaceOfService.substring(0, 8) == "SelfPay,") {
        Insurance = '1' + Insurance.slice(1);
    }
    InsuranceType = $('[id$="ddlInsuranceType"] option:selected').val();

    if (Customize == "Customize") {
        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
    } else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();

    }

    params = {

        Payers: Insurance,
        Datetype: DateType,
        StartDate: DateFrom,
        EndDate: DateTo,
        InsuranceType: InsuranceType,
        ClaimStatus: ClaimStatus,
        Rows: Rows1,
        ProviderId: ProviderId,
        LocationId: LocationId,

        PageNumber: 0,

        action: "Filter"
    };
    Report_ReloadData("FilterOverPaidClaimsReport.aspx", params, true)

    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $('[id$="ddlPostType"]').val(DateType);
    $('[id$="ddlPostTypeCustomize"]').val(DateType);
    $("#" + SubReportDivName).find("#ddlPaging option:selected").val(Rows1);
    $("#ddlSelectDateCustomize").val(SelectDate);
    $("#ddlSelectDate").val(SelectDate);

}
function FilterPatientDetails() {
    debugger
    var PatientName = $("#TxtPatientSearch").val()
    var PatientIds = $("#hdnsearchpatientid").val();
    var params = {
        PatientIds: PatientIds
    }
    Report_ReloadData("FilterPatientDetails.aspx", params, true)

    // OpenReportPage("PatientDetails.aspx", "", Params, "PatientDetails", "", "Patient Detail");
    $('.SelectFilterMessage').css("display", "none")

    $("#TxtPatientSearch").val(PatientName);
}
function FilterPatientSummaryReport(Customize) {
    debugger
    var DiagnosisCode = "";
    var Activity = "";
    var ProviderId = "";
    var ProcedureCode = "";
    var Gender = "";
    var PayerId = "";
    var InsuranceID = "";
    var PatientIds = "";
    var AdjustmentCode = "";
    var DateType = "";

    var SelectDate = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
            PayerId += $(this).val() + ",";
            InsuranceID += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPracticeLocationAll']").is(':checked')) {
        PracticeLocationId = '';
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (AdjustmentCode.length > 0) {
        AdjustmentCode = AdjustmentCode.slice(0, -1);
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkAdjustmentCodeAll']").is(':checked')) {
        AdjustmentCode = '';
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    if (Customize == "Customize") {
        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlSelectDateCustomize"]').val()

    } else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find('[id$="ddlSelectDate"]').val()

    }
    params = {
        ProviderId: ProviderId,
        PracticeLocationId: PracticeLocationId,
        PayerId: PayerId,
        DateType: DateType,
        DateFrom: DateFrom,
        DateTo: DateTo,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,
        action: "Filter"
    };


    Report_ReloadData("FilterPatientSummaryReport.aspx", params, true)
    $('[id$="dateFromCustomize"]').val(DateFrom);
    $('[id$="dateToCustomize"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#ddlPostTypeCustomize").val(DateType);
    $("#ddlSelectDateCustomize").val(SelectDate)
    $("#ddlSelectDate").val(SelectDate)
}
function FilterPatientBalanceSummaryReport(Customize) {
    debugger

    var AssignedTo = "";
    var AsOf = "";
    var DateType = "";

    DateType = $("#ddlSelectDate option:selected").val()
    AssignedTo = $("#ddlAssignedTo option:selected").val()
    AsOf = $("#dateasof").val()

    var params = {

        CustomDate: DateType,
        AssignedTo: AssignedTo,
        AsOf: AsOf,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,
        action: "Filter"
    };


    Report_ReloadData("FilterPatientBalanceSummaryReport.aspx", params, true)
}
function FilterDeductableReport(Customize) {
    debugger
    Rows1 = $("#ddlPaging").val();
    var DateFrom = '';
    var DateTo = '';
    var StaffNPI = "";
    var PracticeLocationId = "";
    var DateType = "";
    var Insurance = "";
    var value = "";
    var ClaimStatus = "";
    var InsuranceType = "";
    var PlaceOfService = '';
    var SelectDate = "";
    debugger
    $('.multicheckbox').each(function () {

        if ($(this).is(":checked")) {

            value += $(this).val() + ",";

        }
    });
    if (value.length > 0) {
        value = value.slice(0, -1);
    }

    $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Insurance += $(this).val() + ",";
            PlaceOfService += $(this).parent().find("span").html() + ",";

        }
    });
    if (Insurance.length > 0) {
        Insurance = Insurance.slice(0, -1);
    }
    $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus += $.trim($(this).val() + ",");
        }
    });
    $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus = "";
        }
    });
    if (ClaimStatus.length > 0) {
        ClaimStatus = ClaimStatus.slice(0, -1);
    }
    if (PlaceOfService.substring(0, 8) == "SelfPay,") {
        Insurance = '1' + Insurance.slice(1);
    }
    if (Customize == "Customize") {
        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        InsuranceType = $('[id$="ddlInsuranceType"] option:selected').val();

        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();

    }
    else {
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }
    params = {

        Insurance: Insurance,
        Datetype: DateType,
        StartDate: DateFrom,
        EndDate: DateTo,
        InsuranceType: InsuranceType,
        ClaimStatus: ClaimStatus,
        ReasonCodeValues: value,
        Rows: Rows1,
        PageNumber: 0,

        action: "Filter"
    };
    Report_ReloadData("FilterDeductableReport.aspx", params, true)
    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $("#ddlPostTypeCustomize").val(DateType);
    $('[id$="ddlInsuranceType"] option:selected').val(InsuranceType);
    $("#ddlPostType").val(DateType);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#ddlSelectDateCustomize").val(SelectDate)
    $("#ddlSelectDate").val(SelectDate)

}
function FilterContractManagementDetailReport(Customize) {
    debugger
    var DiagnosisCode = "";
    var Activity = "";
    var ProviderId = "";
    var ProcedureCode = "";
    var Gender = "";
    var PayerId = "";
    var PatientIds = "";
    var AdjustmentCode = "";
    var DateType = "";
    var ProcedureCode = ""
    var SelectDate = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode = "";
        }
    });
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPracticeLocationAll']").is(':checked')) {
        PracticeLocationId = '';
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (AdjustmentCode.length > 0) {
        AdjustmentCode = AdjustmentCode.slice(0, -1);
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkAdjustmentCodeAll']").is(':checked')) {
        AdjustmentCode = '';
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (Customize == "Customize") {
        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        ProcedureCode = $("#txtCPTCode").val().split('-')[0];
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        PatientIds = $("#hdnsearchpatientid").val()

        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();



    } else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }
    params = {
        PatientId: PatientIds,
        ProviderId: ProviderId,
        PracticeLocationId: PracticeLocationId,
        PayerId: PayerId,
        AdjustmentCode: AdjustmentCode,
        ProcedureCode: ProcedureCode,
        DateType: DateType,
        StartDate: DateFrom,
        EndDate: DateTo,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,
        action: "Filter"
    };
    Report_ReloadData("FilterContractManagementDetailReport.aspx", params, true)
    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $("#txtCPTCode").val(ProcedureCode);
    $("#ddlPostTypeCustomize").val(DateType);
    $("#hdnsearchpatientid").val(PatientIds)
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#ddlPostType").val(DateType);

    $("#ddlSelectDateCustomize").val(SelectDate)
    $("#ddlSelectDate").val(SelectDate)
}

function FilterContractManagementSummaryReport(Customize) {
    debugger
    var DiagnosisCode = "";
    var Activity = "";
    var ProviderId = "";
    var ProcedureCode = "";
    var Gender = "";
    var PayerId = "";
    var PatientIds = "";
    var AdjustmentCode = "";
    var DateType = "";
    var ProcedureCode = "";
    var SelectDate = "";

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode = "";
        }
    });
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPracticeLocationAll']").is(':checked')) {
        PracticeLocationId = '';
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (AdjustmentCode.length > 0) {
        AdjustmentCode = AdjustmentCode.slice(0, -1);
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkAdjustmentCodeAll']").is(':checked')) {
        AdjustmentCode = '';
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    if (Customize == "Customize") {



        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        ProcedureCode = $("#txtCPTCode").val().split('-')[0];
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        PatientIds = $("#hdnsearchpatientid").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();



    } else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }
    params = {
        PatientIds: PatientIds,
        ProviderId: ProviderId,
        PracticeLocationId: PracticeLocationId,
        PayerId: PayerId,
        AdjustmentCode: AdjustmentCode,
        ProcedureCode: ProcedureCode,
        DateType: DateType,
        BillDateFrom: DateFrom,
        BillDateTo: DateTo,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,
        action: "Filter"
    };
    Report_ReloadData("FilterContractManagementSummaryReport.aspx", params, true)
    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $("#txtCPTCode").val(ProcedureCode);
    $("#ddlPostTypeCustomize").val(DateType);
    $("#hdnsearchpatientid").val(PatientIds)
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#ddlPostType").val(DateType);
    $("#ddlSelectDateCustomize").val(SelectDate);
    $("#ddlSelectDate").val(SelectDate);


}



function FilterPatientBalanceDetail(Customize) {
    debugger
    var DateType = "";
    var AsOf = "";
    if (Customize == "Customize") {

    } else {
        DateType = $("#ddlSelectDate option:selected").val()
        AsOf = $("#dateasof").val()
    }
    var params = {

        CustomDate: DateType,
        AsOf: AsOf,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,

        action: "Filter"
    };
    Report_ReloadData("FilterPatientBalanceDetailReport.aspx", params, true)

}
function FilterPatientTransactionsSummary() {
    debugger
    Rows1 = $("#ddlPaging").val();
    var DateFrom = '';
    var DateTo = '';
    var DateType = "";
    DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
    DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
    DateType = $("#" + SubReportDivName).find("#ddlPostType").val();

    params = {
        DateFrom: DateFrom,
        DateTo: DateTo,
        DateType: DateType,
        Rows: Rows1,
        PageNumber: 0,

        action: "Filter"
    };
    Report_ReloadData("FilterPatientTransactionsSummaryReport.aspx", params, true)

}
function FilterPatientTransactionsDetail(Customize) {
    debugger
    Rows1 = $("#ddlPaging").val();
    var DateFrom = '';
    var DateTo = '';
    var DateType = '';
    var PracticeLocationId = '';
    var ProviderId = '';
    var CPTCode = '';
    var SelectDate = "";
    if (Customize == 'Customize') {
        DateFrom = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateFrom']").val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateTo']").val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        CPTCode = $("#" + SubReportDivName).parentsUntil().find("#txtCPTCode").val().split('-')[0];

        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();

    }
    else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }

    debugger
    $("#" + SubReportDivName).parentsUntil().find("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocations").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ProviderCollectionLocations'] #chkProviderCollectionLocationsAll").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    $("#" + SubReportDivName).parentsUntil().find("#ProviderCollectionDynamicProviders #ProviderCollectionDynamicProviderChk").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("#ProviderCollectionDynamicProviders #DynamicProviderCollectionProviderChkAll").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }

    params = {
        DateFrom: DateFrom,
        DateTo: DateTo,
        DateType: DateType,
        PracticeLocationId: PracticeLocationId,
        ProviderId: ProviderId,
        CPTCode: CPTCode,
        Rows: Rows1,
        PageNumber: 0,

        action: "Filter"
    };
    Report_ReloadData("FilterPatientTransactionsDetail.aspx", params, true)
    debugger
    $('[id$="CustomizeDateFrom"]').val(DateFrom);
    $('[id$="CustomizeDateTo"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#ddlSelectDateCustomize").val(SelectDate)
    $("#ddlSelectDate").val(SelectDate)
    $("#ddlPostTypeCustomize").val(DateType)
    $("#ddlPostType").val(DateType)


}
function FilterPatientContactList(Customize) {
    debugger
    Rows1 = $("#ddlPaging").val();
    var DiagnosisCode = "";
    var Activity = "";
    var ProviderId = "";
    var ProcedureCode = "";
    var Gender = "";
    var PayerId = "";
    var PatientId = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = ""
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
            //PayerId += $(this).parent().find("span").html() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PayerId = "";
           
        }
    });
    var DiagnosisCode = $("#" + SubReportDivName).parentsUntil().find("#txtIcdCode1").val();
    var ProcedureCode = $("#" + SubReportDivName).parentsUntil().find("#txtCPTCode").val().split('-')[0];;

    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }

    if (Customize == "Customize") {
        Activity = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlActivityCustomize"]').val();
        Gender = $("#" + SubReportDivName).parentsUntil().find("#ddlGenderCustomize").val();
        PatientId = $("#" + SubReportDivName).parentsUntil().find("#hdnsearchpatientidCustomize").val();
    } else {
        Activity = $("#" + SubReportDivName).find('[id$="ddlActivity"]').val();
        Gender = $("#" + SubReportDivName).find("#ddlGender").val();
        PatientId = $("#" + SubReportDivName).find("#hdnsearchpatientid").val()

    }
    params = {
        DiagnosisCode: DiagnosisCode,
        Activity: Activity,
        ProviderId: ProviderId,
        ProcedureCode: ProcedureCode,
        Gender: Gender,
        PatientId: PatientId,
        PayerId: PayerId,
        Rows: Rows1,
        PageNumber: 0,
        action: "Filter"
    };
    Report_ReloadData("FilterPatientContactList.aspx", params, true)
    $('[id$="ddlActivityCustomize"]').val(Activity);
    $("#ddlGenderCustomize").val(Gender);
    $('[id$="ddlActivity"]').val(Activity);
    $("#ddlGender").val(Gender)

}
function SelectICD(elem) {
    debugger;
    var icdCode = ''; var IcdDesc = '';

    icdCode = $.trim($(elem).closest("tr").find(".hdnCode").html());
    IcdDesc = $.trim($(elem).closest("tr").find(".hdnDescription").html());
    var a = icdCode + " - " + IcdDesc;
    _CurrentTextBoxICD = null;
    $("#txtIcdCode1").val(a);
    $("#txtIcdDesc1").val(IcdDesc);
    $("#divICDsSearched").hide();
}
function FilterAdjustmentsDetailReport(Customize) {
    debugger
    var DiagnosisCode = "";
    var Activity = "";
    var ProviderId = "";
    var ProcedureCode = "";
    var Gender = "";
    var PayerId = "";
    var PatientIds = "";
    var AdjustmentCode = "";
    var DateType = "";
    var SelectDate = "";

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode = "";
        }
    });
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPracticeLocationAll']").is(':checked')) {
        PracticeLocationId = '';
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (AdjustmentCode.length > 0) {
        AdjustmentCode = AdjustmentCode.slice(0, -1);
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkAdjustmentCodeAll']").is(':checked')) {
        AdjustmentCode = '';
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    if (ProviderId.length > 0) {
        ProviderId = ProviderId.slice(0, -1);
    }
    if (Customize == "Customize") {


        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        ProcedureCode = $("#txtCPTCode").val().split('-')[0];
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        PatientIds = $("#hdnsearchpatientid").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();



    } else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }
    params = {
        PatientIds: PatientIds,
        ProviderId: ProviderId,
        PracticeLocationId: PracticeLocationId,
        PayerId: PayerId,
        AdjustmentCode: AdjustmentCode,
        ProcedureCode: ProcedureCode,
        DateType: DateType,
        BillDateFrom: DateFrom,
        BillDateTo: DateTo,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,
        action: "Filter"
    };
    Report_ReloadData("FilterAdjustmentsDetailReport.aspx", params, true);
    $('[id$="dateFromCustomize"]').val(DateFrom);
    $('[id$="dateToCustomize"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#txtCPTCode").val(ProcedureCode);
    $("#ddlPostTypeCustomize").val(DateType);
    $("#hdnsearchpatientid").val(PatientIds);
    $("#ddlSelectDateCustomize").val(SelectDate);
    $("#ddlSelectDate").val(SelectDate);
}
function emptyCPTVal(elm, code) {

    $(elm).parent("td").find("input").val('');
    $(elm).parent("td").prev().find("input").val('');

    $(".DX" + code + "PointerCheckbox :checkbox").prop("checked", false);

    $("#tblItemsTreatmentPlan tbody tr:not(:last) .selectedText").each(function () {
        var SelectedText = $(this).text();
        if (SelectedText.length == 1) {
            SelectedText = SelectedText.replace(code, '');
        }
        else {
            SelectedText = SelectedText + ", ";
            SelectedText = SelectedText.replace(code + ", ", '');
            SelectedText = SelectedText.substring(0, SelectedText.length - 2);
        }

        $(this).text(SelectedText);
        $(this).attr('title', SelectedText);

    });
}
function PopulateCPTDesc(elm, descInputId) {
    var flag = 0;
    $("#divCPTSearched table tbody tr").each(function () {
        var code = $.trim($(this).find("td:eq(0)").html());
        if ($(elm).val() == code) {
            var desc = $.trim($(this).find("td:eq(1)").html());
            $("#" + descInputId).val(desc);
            flag = 1;
            return;
        }
    });

    if (flag == 0) {
        $(elm).val("");
        $("#" + descInputId).val("");
    }
}

function PopulateCPTCode(elm, codeInputId) {
    var flag = 0;

    $("#divCPTSearched table tbody tr").each(function () {
        var desc = $.trim($(this).find("td:eq(1)").html());

        if ($(elm).val().toUpperCase() == desc.toUpperCase()) {
            var code = $.trim($(this).find("td:eq(0)").html());
            $("#" + codeInputId).val(code);
            flag = 1;

            return;
        }
    });

    if (flag == 0) {
        $(elm).val("");
        $("#" + codeInputId).val("");
    }
}
function FilterPatientDemographics(Customize) {

    var PatientId = $.trim($("#txtPatientId").val()) == "" ? 0 : $.trim($("#txtPatientId").val());
    debugger
    var PayerId = "";
    var DateFrom = "";
    var DateTo = "";
    var Gender = "";
    var SelectDate = "";

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
        }
    });
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        Gender = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlGender"]').val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();


    }
    else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }
    params = {
        PatientId: PatientId,
        Gender: Gender,
        PayerId: PayerId,
        DateFrom: DateFrom,
        DateTo: DateTo,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,
        action: "Filter"
    };
    Report_ReloadData("FilterPatientDemographics.aspx", params, true);
    $('[id$="dateFromCustomize"]').val(DateFrom);
    $('[id$="dateToCustomize"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $('[id$="ddlGender"]').val(Gender);
    $("#ddlSelectDateCustomize").val(SelectDate);
    $("#ddlSelectDate").val(SelectDate);

}
function FilterDiagnosisCodeReport() {
    debugger
    var DiagnosisCode = $("#txtIcdCode1").val().split('-')[0];
    params = {
        DiagnosisCode: DiagnosisCode,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0
    };
    Report_ReloadData("FilterTop10DxCodes.aspx", params, true);
}
function FilterCommonlyUsedDxCodesReport() {
    debugger
    var DiagnosisCode = $("#txtIcdCode1").val().split('-')[0];
    params = {
        DiagnosisCode: DiagnosisCode,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0
    };
    Report_ReloadData("FilterMostCommonlyUsedDxCodes.aspx", params, true);
}
function FilterTop10PayersReport() {
    debugger
    var PayerId = "";
    $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
        }
    });
    if ($("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    TopPayers = PayerId;
    params = {
        PayerId: PayerId,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0
    };
    Report_ReloadData("FilterTop10Payer.aspx", params, true);
}
function FilterTop10ProcedureReport() {
    debugger
    var CptCode = $("#txtCPTCode").val().split('-')[0];
    params = {
        CptCode: CptCode,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0
    };
    Report_ReloadData("FilterTop10Procedure.aspx", params, true);
}

function ShowDDLlocations(type) {
    debugger

    searchLocation();
    $("#divMultiStatus").hide();
    if ($(".locationddl").find(".lilocationitem").length > 0) {
        $("#divShowDDLLocation").show();
    }
    else {
        $.post("/ProviderPortal/ReportsNew/filter/FilterPTLDetail.aspx", function (data) {
            debugger
            var returnHtml = data;
            var start = data.indexOf("###StartLocation###") + 19;
            var end = data.indexOf("###EndLocation###");
            $("#divShowDDLLocation").html(returnHtml.substring(start, end));
            if (type == "PTL")
                $("#PTLLocations").show();
            else
                $("#SelfPayLocations").show();
        });

        $("#divShowDDLLocation").show();
    }
}
function FilterAllPtlList(pageNumber, paging) {
    debugger
    var PatientId = $("#txtPatientId").val();
    var PatientName = $("#txtPatientName").val();
    var ClaimId = $("#txtClaimId").val();
    var DOS = $("#txtDOS").val();
    var location = "";
    var Payer = _NewInsuranceIds;
    var PtlReason = $("#txtPtlReason").val();
    var PTLType = $("#txtPTLType").val();
    var QAApproved = $("#QAApproved").val();
    var AuditApproved = $("#AuditApproved").val();
    var CRMApproved = $("#CRMApproved").val();
    var CommunicationCount = $("#txtCommuCount").val();
    var LastCommunicationDate = $("#txtLastCommuDate").val();
    var Rows = $("#ddlPagingPTLAll").val();
    if (Rows == "All") {
        var Rows = $("[id$='hdnPTLAllRows']").val();
    }
    var params = {
        PatientId: PatientId,
        PatientName: PatientName,
        ClaimId: ClaimId,
        DOS: DOS,
        Payer: Payer,
        PtlReason: PtlReason,
        location: location,
        PTLType: PTLType,
        QAApproved: QAApproved,
        AuditApproved: AuditApproved,
        CRMApproved: CRMApproved,
        CommunicationCount: CommunicationCount,
        LastCommunicationDate: LastCommunicationDate,


        Rows: Rows,
        PageNumber: pageNumber,

        action: "PatientFilterAll"
    };
    $.post("/ProviderPortal/ReportsNew/filter/FilterPTLDetail.aspx", params, function (data) {
        debugger
        var start = data.indexOf("###StartPTLFilterAll###") + 23;
        var end = data.indexOf("###EndPTLFilterAll###");
        var returnHtml = $.trim(data.substring(start, end));
        debugger
        $("#tbodyPTLAll").hide();

        $("#tbodyPTLAll").html(returnHtml)
            .promise()
            .done(function () {
                // SetPTLReasons("Patient");
                $("#tbodyPTLAll").show();
            });

        var startRowsCount = data.indexOf("###StartRowsCountPtlAll###") + 26;
        var endRowsCount = data.indexOf("###EndRowsCountPtlAll###");
        $("[id$='hdnPTLAllRows']").val($.trim(data.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnPTLAllRows']").val(), $("#ddlPagingPTLAll").val(), "AllContainer", "FilterAllPtlList");
        }

        if ($("[id$='hdnPTLAllRows']").val() > 0) {
            $("#AllContainer .spanInfo").html("Showing " + $("#tbodyPTLAll tr:first").children().first().html() + " to " + $("#tbodyPTLAll tr:last").children().first().html() + " of " + $("[id$='hdnPTLAllRows']").val() + " entries");
        }
        Page = pageNumber;
    });
}
function FilterDuplicateChecks(Customize) {
    debugger
    Rows1 = $("#ddlPaging").val();
    var DateFrom = '';
    var DateTo = '';
    var InsuranceID = ""
    var CheckNo = ""

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateFrom']").val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find("[id$='CustomizeDateTo']").val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
        CheckNo = $("#ddlCheckNumber").val();


    } else {
        DateFrom = $("#" + SubReportDivName).find("[id$='DateFrom']").val();
        DateTo = $("#" + SubReportDivName).find("[id$='DateTo']").val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();

    }

    params = {
        DateFrom: DateFrom,
        InsuranceID: InsuranceID,
        CheckNo: CheckNo,
        DateTo: DateTo,
        Rows: Rows1,
        PageNumber: 0,
    };
    Report_ReloadData("FilterDuplicateChecks.aspx", params, true)
    $("#ddlSelectDateCustomize").val(SelectDate)
    $("#ddlSelectDate").val(SelectDate)
    $("#DateFrom").val(DateFrom)
    $("#DateTo").val(DateTo)
    $("#CustomizeDateFrom").val(DateFrom)
    $("#CustomizeDateTo").val(DateTo)

}
function FilterAdjustmentsSummaryReport(Customize) {
    debugger
    var DiagnosisCode = "";
    var Activity = "";
    var ProviderId = "";
    var ProcedureCode = "";
    var Gender = "";
    var PayerId = "";
    var PatientIds = "";
    var AdjustmentCode = "";
    var DateType = "";
    var ProcedureCode = ""
    var SelectDate = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PayerId += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            AdjustmentCode = "";
        }
    });
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPracticeLocationAll']").is(':checked')) {
        PracticeLocationId = '';
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (AdjustmentCode.length > 0) {
        AdjustmentCode = AdjustmentCode.slice(0, -1);
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkAdjustmentCodeAll']").is(':checked')) {
        AdjustmentCode = '';
    }
    if ($("#" + SubReportDivName).parentsUntil().find("[id$='chkPayerScenarioAll']").is(':checked')) {
        PayerId = '';
    }
    if (PayerId.length > 0) {
        PayerId = PayerId.slice(0, -1);
    }
    if (Customize == "Customize") {

        SelectDate = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlSelectDateCustomize"]').val()
        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        ProcedureCode = $("#" + SubReportDivName).parentsUntil().find("#txtCPTCode").val().split('-')[0];
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();
        //PatientIds = $("#hdnsearchpatientid").val()


    } else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
        SelectDate = $("#" + SubReportDivName).find('[id$="ddlSelectDate"]').val()
    }
    params = {
        PatientIds: $("#hdnsearchpatientid").val(),
        ProviderId: ProviderId,
        PracticeLocationId: PracticeLocationId,
        PayerId: PayerId,
        AdjustmentCode: AdjustmentCode,
        ProcedureCode: ProcedureCode,
        DateType: DateType,
        BillDateFrom: DateFrom,
        BillDateTo: DateTo,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,
        action: "Filter"
    };
    Report_ReloadData("FilterAdjustmentsSummaryReport.aspx", params, true);
    $('[id$="dateFromCustomize"]').val(DateFrom);
    $('[id$="dateToCustomize"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#txtCPTCode").val(ProcedureCode);
    $("#ddlPostTypeCustomize").val(DateType);
    $('[id$="ddlPostType"]').val(DateType)
    /*    $("#hdnsearchpatientid").val(PatientIds)*/
    $('[id$="ddlSelectDateCustomize"]').val(SelectDate)
    $('[id$="ddlSelectDate"]').val(SelectDate)
}
function FilterClaimsSubmissionReport(Customize) {
    debugger
    var Location = ""
    var DateType = ""

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            Location += $(this).val() + ",";

        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            Location = "";
        }
    });
    if (Location.length > 0) {
        Location = Location.slice(0, -1);
    }
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();



    } else {
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
        DateType = $("#" + SubReportDivName).find("#ddlPostType").val();

    }
    params = {
        Location: Location,
        DateType: DateType,
        DateFrom: DateFrom,
        DateTo: DateTo,
        Rows: $("#ddlPaging").val(),
        PageNumber: 0,

        action: "Filter"
    };
    Report_ReloadData("FilterClaimsSubmissionStatusSummary.aspx", params, true);
    $(".divPracticeLocation").css("display", "none")
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);
    $("#ddlPostTypeCustomize").val(DateType);
    $('[id$="ddlPostType"]').val(DateType)
    $('[id$="ddlSelectDateCustomize"]').val(SelectDate)
    $('[id$="ddlSelectDate"]').val(SelectDate)

}
function FilterChargesSummaryAndDetail(Customize) {
    $(".message").hide();
    var DateFrom = '';
    var DateTo = '';
    var StaffNPI = "";
    var PracticeLocationId = "";
    var DateType = "";
    var SelectDate = "";
    var GroupBy = $("#ddlGroupBy").val();
    var ProcedureCode = "";
    var ClaimStatus = "";
    var MultipleClaims = "";
    var BillAs = "";


    debugger
    MultipleClaims = $(".SelectedClaims").map(function () {
        return $(this).text();
    }).get().join(',');

    $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus += $.trim($(this).val() + ",");
        }
    });
    $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus = "";
        }
    });
    ProcedureCode = $(".spnservicecode").map(function () {
        return $(this).text();
    }).get().join(',');
    if (GroupBy == "Provider") {

        $("[id$='ChargedSummaryProviders'] #chkChargedSummaryProviders").each(function () {
            if ($(this).is(":checked")) {
                StaffNPI += $(this).val() + ",";
            }
        });
        if ($("[id$='chkChargedSummaryProvidersAll']").is(':checked')) {
            StaffNPI = '';
        }
        $("[id$='ChargedSummaryDynamicLocations'] #chkChargedSummaryDynamicLocations").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("[id$='ChargedSummaryDynamicLocations'] #chkChargedSummaryDynamicLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });

    }
    else {

        $("[id$='ChargedSummaryLocations'] #chkChargedSummaryLocations").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });

        $("[id$='ChargedSummaryLocations'] #chkChargedSummaryLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });

        $("[id$='ChargedSummaryDynamicProvider'] #DynamicChargedSummaryProviderChk").each(function () {
            if ($(this).is(":checked")) {
                StaffNPI += $(this).val() + ",";
            }
        });
        $("[id$='ChargedSummaryDynamicProvider'] #DynamicChargedSummaryProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                StaffNPI = ""
            }
        });




    }
    if (StaffNPI.length > 0) {
        StaffNPI = StaffNPI.slice(0, -1);
    }
    if (ClaimStatus.length > 0) {
        ClaimStatus = ClaimStatus.slice(0, -1);
    }
    if (StaffNPI.length > 0) {
        StaffNPI = StaffNPI.slice(0, -1);
    }
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (Customize == "Customize") {

        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateType = $("#" + SubReportDivName).parentsUntil().find("#ddlPostTypeCustomize").val();

        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();
        BillAs = $("#BillAs").val();


    } else {
        DateType = $('[id$="ddlPostType"] option:selected').val();
        DateFrom = $("#" + SubReportDivName).find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
    }



    $.post('../../ProviderPortal/ReportsNew/filter/FilterChargesSummaryAndDetail.aspx', {
        action: "FilterClaimSummary", DateType: DateType, ProviderId: StaffNPI,
        PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo, CPTcode: ProcedureCode, ClaimStatus: ClaimStatus,
        MultipleClaims: MultipleClaims, BillAs: BillAs
    }, function (data) {
        debugger
        var result = "";
        var start = data.indexOf("###Filter###") + 12;
        var end = data.indexOf("###End###");
        result = $.trim(data.substring(start, end));
        $(".ClaimSummmaryAndDetailsCharged").html(result).show();

        if ($(".ClaimSummmaryAndDetailsCharged").find("tr").html() == "" || $(".ClaimSummmaryAndDetailsCharged").find("tr").html() == undefined) {
            $(".message").html("No Record Found, Please change search criteria").show();
        }
        debugger
        /*Edited By Faiza Bilal 3-24-2022 to get checkboxes checked */

        var dateArF = DateFrom.split('-');
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = DateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $('[id$="CustomizeDateFrom"]').val(DateFrom);
        $('[id$="CustomizeDateTo"]').val(DateTo);
        $('[id$="DateFrom"]').val(DateFrom);
        $('[id$="DateTo"]').val(DateTo);
        $("[id$='txtDateFrom']").text(newDateFrom);
        $("[id$='txtDateTo']").text(newDateTo);
        $("#ddlSelectDateCustomize").val(SelectDate)
        $("#ddlSelectDate").val(SelectDate)
        $(".spnservicecode").text(ProcedureCode)
        $("#BillAs").val(BillAs)
        //ShowHideMenu();
        //$("[id$='FilterReports']").prop("disabled", true);
        // $(elem).parent().parent().parent().parent().parent().find("#FilterReports").prop("disabled", true);
        $(".TimeSpan").css("display", "block");
    });
    /*Added By faiza Bilal 3-24-2022*/
    TimeSpanClaimAndSum = TimeSpan;
    DateFromClaimAndSum = DateFrom;
    DateToClaimAndSum = DateTo;
    /*End Added By faiza Bilal 3-24-2022*/

}
function ChargeDetail(level, type) {
    debugger
    /*Edited By faiza Bilal 3-29-2022*/
    var DateFromC = '';
    var DateToC = '';
    var datetype = '';
    var CPT = '';


    DateFromC = $('#hdnStartDate').val();
    DateToC = $('#hdnEndDate').val();
    datetype = $('#hdnDateType').val();
    CPT = $('#hdnCPT').val();
    var claimid = $('#hdnclaimidCharges').val();
    var BillAs = $('#hdnBillAs').val();
    var PracticeLocationId = $('#hdnPracticeLocationIdCharges').val();
    var ProviderId = $('#hdnProviderIdCharges').val();
    var ClaimStatus = $('#hdnClaimStatus').val();

    var prams =
    {
        PracticeLocationId: PracticeLocationId,
        ProviderId: ProviderId,
        claimid: claimid,
        Datetype: datetype,
        DateFrom: DateFromC,
        DateTo: DateToC,
        Level: level,
        Type: type,
        CPTcode: CPT,
        BillAs: BillAs,
        ClaimStatus: ClaimStatus
    };

    start1 = "###StartProcedureDetail###";
    end1 = "###EndProcedureDetail###";
    title = "Procedure Detail";
    if (type == 'P') { title = "Paid CPT Detail"; }
    else if (type == 'U') { title = "UnPaid CPT Detail" }
    else if (type == 'A') { title = "Adjusted CPT Detail"; }



    $.post("../../ProviderPortal/ReportsNew/filter/FilterChargesSummaryAndDetail.aspx", prams, function (data) {
        debugger
        var start = data.indexOf(start1) + 26
        var end = data.indexOf(end1);

        var htmlresult = $.trim(data.substring(start, end));
        $(".dialogueChargesSummary").html(htmlresult);

        $(".dialogueChargesSummary").dialog({
            width: 1060,

            modal: true,
            title: title,
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Close": function () {
                    $(".dialogueChargesSummary").html("");
                    $(this).dialog("destroy");



                }
            },
            close: function () {
                $(".dialogueChargesSummary").html("");

                $(this).dialog("destroy");


            }
        });

        if (type == 'U' && level == 'CLM') {
            $('.thDueAmt').show();

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

        }
        if (type == 'P' && level == 'CLM') {
            $('.thPaidAmt').show();

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
        if (type == 'A' && level == 'CLM') {
            $('.thclmstatus').show();

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");
        }
        if (type == 'U' && level == '') {
            $('.thDueAmt').show();

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
        if (type == 'P' && level == '') {
            $('.thPaidAmt').show();

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
    });
}
var TabCheck = false;
var ReportName = ""
function NavReportOpen(hiddenRows, hiddenpaging, _isParameters, elem, TabCheck, A) {
    debugger
    ReportName = $(elem).closest('.lblReportName').text();
    $('#ddlExportTo').get(0).selectedIndex = 0;


    if (hiddenRows == "0" || hiddenRows == null) {

        hiddenRows = $("#" + _isParameters).find("[id$='hdnTotalRows']").val();
    }
    else {
        hiddenRows = hiddenRows;
    }

    $(".widgetsReportTiles").last().attr("isparameters");
    var data = $("#" + _isParameters).html();
    var scriptstart = data.indexOf("<script>");
    var scriptend = data.indexOf("</script>");
    var scriptmain = data.substring(scriptstart, scriptend);
    data = data.replace(scriptmain, '');
    $("#" + _isParameters).html(data);

    $("#" + _isParameters).append(scriptmain);
    //--- end ali imran 18 july---

    $(".common_Report").hide();

    $('#' + _isParameters).show();
    //$('.widgetsReportTiles').css('background-color', '#ececec');
    //$('.reportType').css('color', '#2b2727');
    //$(elem).closest('.widgetsReportTiles').css('background-color', '#006291');
    //$(elem).closest('.widgetsReportTiles').css('border-color', '#439abf');
    //$(elem).css('color', '#ffffff');

    $(".totalRows").html("Total Rows : " + hiddenRows);
    var ReportFilterFileName = $(elem).closest('.widgetsReportTiles').text();
    _ReportFilterFileName = ReportFilterFileName.substring(0, ReportFilterFileName.length - 1);


    filename = $(elem).closest(".widgetsReportTiles").attr("tabname");
    _selectedReport_Filter = "Filter" + filename;

    _ReportFilterCategory = $(elem).closest(".widgetsReportTiles").attr("CatagoryName");
    _ReportFilterIsParameters = $(elem).closest(".widgetsReportTiles").attr("isParameters");

    var HiddenPageNum = $.trim($("#" + _isParameters).find("#hdnTotalRows").attr("class"));
    HiddenPageNum = HiddenPageNum.split('-')[1];
    if (HiddenPageNum == "" || HiddenPageNum == null) {
        HiddenPageNum = 1;
    }
    else {
        HiddenPageNum = HiddenPageNum;
    }
    $(".txt_page_Number").html("");



    var PagingNum = $.trim($("#" + _isParameters).attr("class"));
    PagingNum = PagingNum.split('-')[1];

    if (PagingNum == "All") {
        hiddenRows = $.trim($("#" + _isParameters).find("#hdnTotalRows").val());
        hiddenpaging = hiddenRows;
    }
    else if (PagingNum == null) {
        hiddenpaging = hiddenpaging;
    }
    else {
        hiddenpaging = hiddenpaging;
    }
    $(".txt_page_Number").val(HiddenPageNum);
    TabContent = $('#' + _isParameters);
    GenerateReportPaging(hiddenRows, hiddenpaging);
    GetFilteredOnChangingTab("", TabContent, DateFrom, DateTo);

    $.trim($(elem).closest('td').find('.lblReportName').attr("onclick", "OpenReportTab('" + hiddenRows + "','" + hiddenpaging + "','" + SubReportDivName + "',this,true,'" + TabFilename + "')"))


    //  Message("Report is already opened");


}
function Alert(mesg) {
    debugger
    $(".divMesg").css("display", "block");
    $(".divMesg").html(mesg).removeClass("success").addClass("warning").fadeIn(2000).fadeOut(5000);
    return true
}
function SetSerachMultipleClaims() {

    var a = event.which || event.keyCode;
    if (a == 13) {
        MultipleClaim();
        debugger;
    }
}
function MultipleClaim() {
    debugger
    var ClaimId = $("#ClaimIdMultipleTxt").val();

    var params = {
        ClaimId: ClaimId,
        action: "LoadAllClaims"
    };
    $.post("../../ProviderPortal/ReportsNew/filter/FilterClaimGrid.aspx", params, function (data) {
        var start = data.indexOf("###StartAllClaims###") + 20;
        var end = data.indexOf("###EndAllClaims###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbodyMultipleClaims").html(returnHtml);
        $("#divAllClaimsDropDownReport").show();
    });
}

function loadClaimForReport(ClaimId) {
    debugger
    var ClaimIds = ClaimId;
    var Claimcount = 0;
    $(".ClaimIdsHere").find(".spanSelectedClaims").each(function () {
        var thisClaim = $.trim($(this).text());

        if (ClaimIds == thisClaim) { Claimcount++; }
    });

    if (Claimcount > 0) { showErrorMessage("Claim already selected!"); }
    else {
        $(".ClaimIdsHere").append("<span class='spanClaims' style='background-color: lightgray; padding: 8px; margin:2px;float:left'><strong class='strongtest'><Span class='SelectedClaims'> " + ClaimIds + "</span><img onclick='removeClaim(this)' style='height:10px;margin-left:5px;' src='../../Images/crossA.png' class='crossA' title='Remove'></strong></span>");
    }

    $("#divAllClaimsDropDownReport").hide();
    $("[id$='ClaimIdMultipleTxt']").val("");
}
function removeClaim(elem) {
    $(elem).closest('.spanClaims').remove();
}
function GetCheckNo() {
    debugger
    var payerName = "";
    var checkNumber = "";
    $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            payerName += $(this).val() + ";";
        }
    });
    $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            payerName = "";
        }
    });

    var params = {
        PayerName: payerName,
        action: "FilterCheckNo"
    };

    $.post("../../ProviderPortal/ReportsNew/filter/FilterDuplicateChecks.aspx", params, function (data) {

        var start = data.indexOf("###StartCheckNumber###") + 22;
        var end = data.indexOf("###EndCheckNumber###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divdllCheckNumber").html(returnHtml)

    });
}
function EnableDisableDateType(elem) {
    debugger
    var a = $("#" + SubReportDivName).find("#divddlPostType option:selected").val();
    var b = $("#" + SubReportDivName).parentsUntil().find("[id$='divddlPostTypeCustomize'] option:selected").val();
    if (a == "" || a == undefined) {
        $(elem).find("#divddlPostType option:selected").val(b);
        $(elem).parentsUntil().find("[id$='divddlPostTypeCustomize'] option:selected").val(b);
    }
    else {
        $(elem).find("#divddlPostType option:selected").val(a);
        $(elem).parentsUntil().find("[id$='divddlPostTypeCustomize'] option:selected").val(a);
    }
}