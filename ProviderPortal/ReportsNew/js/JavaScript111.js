
var _SortBy = '';
var _SortByValue = '';


var _arrSelectedColumn;



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


    if (divMultipleDropdownCheckboxList == "divUnpaidinsurances") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //rizwan

        // $("#divReportServiceProvider").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
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
        $("#divPayerScenario").hide();
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
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPayerScenario").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divPayerScenario") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPracticeLocation").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divServiceProvider") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        //$("#divReportClaimStatus").hide();
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
    }
    else if (divMultipleDropdownCheckboxList == "divPatientName") {
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
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
    debugger;
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
function OpenPatientFilterDialog(ReportTypeName) {


    if (ReportTypeName == "PBS") {

        $("[id='txtDOB']").prop("disabled", false);
    }

    $.post("CallBacks/PatientFilterDialog.aspx", { ReportTypeName: ReportTypeName }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $(".report-criteria-box .editable-container").html("");

        $("[id$='divDialogReportFilters']").html(returnHtml)
        .promise()
        .done(function () {
            //Report_InitializeDatesBoxes();

            $("[id$='divDialogReportFilters']").dialog({
                /* open: function(event, ui) {
                     $(".ui-dialog-titlebar").append("<img src='/Images/MaxRemind-White-01.png' id='myNewImage' />");
                 },*/
                title: "Report Criteria",
                modal: true,
                width: "720",
                height: "auto",
                buttons: {
                    /*"Export To Excel": function () {
                        
                        window.open("data:application/vnd.ms-excel," + $("[id$='divDialogReportFilterBoxInner']").html());
                        e.preventDefault();
                    },*/

                    "OK": function () {


                        if ($("#rbReportTimeSpanSpecificDates").prop("checked")) {

                            var flag = false;
                            $(".required").each(function () {
                                if (!$(this).val()) { flag = true; }
                            });

                            if (flag) {
                                if ($("[id$='txtReportDateFrom']").val() == "") {
                                    $("[id$='txtReportDateFrom']").css("border", "1px solid red");
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }
                                else if ($("[id$='txtReportDateTo']").val() == "") {
                                    $("[id$='txtReportDateTo']").css("border", "1px solid red");
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }
                                else if ($("[id$='txtReportDateFrom']").val() == "" && $("[id$='txtReportDateTo']").val() == "") {
                                    $(".required").css({ "border": "1px solid red" });
                                    showErrorMessage("Please select From and To date.")
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
                        if (ReportTypeName == "PS" && DateType == "PostDate") {
                            if (DateType != "0") {
                                if ($("[id$='txtBillDateFrom']").val() == "") {
                                    $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }
                                if ($("[id$='txtBillDateTo']").val() == "") {
                                    $("[id$='txtBillDateTo']").css("border", "1px solid red");
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }
                            }
                        }


                        if (ReportTypeName == "PBD" || ReportTypeName == "PatientDetails" || ReportTypeName == "AD" || ReportTypeName == "AS" || ReportTypeName == "IOC" || ReportTypeName == "PD" || ReportTypeName == "CS" || ReportTypeName == "CD") {


                            if ($("#TxtPatientSearch").val() == "") {
                                $("#TxtPatientSearch").css("border", "1px solid red");
                                showErrorMessage("Please select Patient.")
                                return;
                            }
                        }



                        var CustomDate = "";
                        $('.ddlDate').each(function () {
                            {
                                CustomDate = $("option:selected", this).val();
                            }
                        });
                        if (ReportTypeName == "PBD") {
                            if (CustomDate == "Custom") {
                                if ($("[id$='txtDOB']").val() == "") {
                                    $("[id$='txtDOB']").css("border", "1px solid red");
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }
                            }
                        }


                        OkPatientFilter(ReportTypeName);
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        });
    });
}
function EnableDisableDates() {

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
        $("[id='txtBillDateFrom']").prop("disabled", false);
        $("[id$='txtBillDateTo']").prop("disabled", false);
    }

    var postdate = $("[id=ddlPostType]").val();

    if (postdate != "") {

        $("[id='txtBillDateFrom']").prop("disabled", false);
        $("[id$='txtBillDateTo']").prop("disabled", false);

        $("[id$='txtDOB']").prop("disabled", false);
    }

    else {
        $("[id='txtBillDateFrom']").prop("disabled", true);
        $("[id$='txtBillDateTo']").prop("disabled", true);
        $("[id$='txtDOB']").prop("disabled", true);
    }
    var DOB = $("#txtDOB").val();
    var CustomDate = "";
    $('.ddlDate').each(function () {
        {
            CustomDate = $("option:selected", this).val();
        }
    });
    if (CustomDate == "Custom") {

        $("[id='txtDOB']").prop("disabled", false);
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


}
function OkPatientFilter(ReportTypeName) {


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
        var DateFrom = $("[id$='txtReportDateFrom']").val();
        var DateTo = $("[id$='txtReportDateTo']").val();
    }
    else if (ReportTypeName == "PDR") {
        var DateFrom = $("[id$='txtReportDateFrom']").val();
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

    if (ReportTypeName == "PS") {

        if (DateType != "") {

            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }

        var NewTimeSpan = "HasDate";

        if (DateType != "0") {
            NewTimeSpan = "All";;
        }
        window.location = "PatientSummaryReport.aspx?PracticeId=" + PracticeId + "&DateType=" + DateType + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&NewTimeSpan=" + NewTimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }
    if (ReportTypeName == "PD") {

        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "PatientDetails.aspx?PatientIds=" + SearchedPatientId;

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
    if (ReportTypeName == "PBD") {

        if (CustomDate == "Custom") {

            if ($("[id$='txtDOB']").val() == "") {
                $("[id$='txtDOB']").css("border", "1px solid red");
                showErrorMessage("Please select date.")
                return;
            }
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "PatientBalanceDetailReport.aspx?PatientIds=" + SearchedPatientId + "&ProcedureCode=" + ProcedureCode + "&CustomDate=" + CustomDate + "&AsOf=" + AsOf;
    }
    if (ReportTypeName == "PBS") {

        if (CustomDate == "Custom") {

            if ($("[id$='txtDOB']").val() == "") {
                $("[id$='txtDOB']").css("border", "1px solid red");
                showErrorMessage("Please select date.")
                return;
            }
        }
        window.location = "PatientBalanceSummaryReport.aspx?AssignedTo=" + AssignedTo + "&CustomDate=" + CustomDate + "&AsOf=" + AsOf;
    }
    if (ReportTypeName == "PTS") {
        window.location = "PatientTransactionsSummaryReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }

    if (ReportTypeName == "AD") {

        if (DateType != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }

        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "AdjustmentsDetailReport.aspx?PracticeId=" + PracticeId + "&PatientIds=" + SearchedPatientId + "&ProcedureCode=" + ProcedureCode + "&DateType=" + DateType + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&AdjustmentCode=" + AdjustmentCode + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }
    if (ReportTypeName == "AS") {

        if (DateType != "") {

            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }

            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "AdjustmentsSummaryReport.aspx?PracticeId=" + PracticeId + "&PatientIds=" + SearchedPatientId + "&ProcedureCode=" + ProcedureCode + "&DateType=" + DateType + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&AdjustmentCode=" + AdjustmentCode + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }
    if (ReportTypeName == "CS") {

        if (DateType != "") {

            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "ChargesSummaryReport.aspx?PracticeId=" + PracticeId + "&PatientIds=" + SearchedPatientId + "&ProcedureCode=" + ProcedureCode + "&DateType=" + DateType + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }
    if (ReportTypeName == "CD") {
        if (DateType != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "ChargesDetailReport.aspx?PracticeId=" + PracticeId + "&PatientIds=" + SearchedPatientId + "&ProcedureCode=" + ProcedureCode + "&DateType=" + DateType + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }



    if (ReportTypeName == "PCL") {
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


        window.location = "PatientContactList.aspx?PracticeId=" + PracticeId + "&Actuvity=" + Actuvity + "&ProviderId=" + ProviderId + "&DiagnosisCode=" + DiagnosisCode + "&ProcedureCode=" + ProcedureCode + "&Gender=" + Gender + "&PayerId=" + PayerId + "&DOB=" + DOB + "&TimeSpan=" + TimeSpan;
    }


    var AsOf = DOB;
    if (ReportTypeName == "IOC") {


        if (CustomDate == "Custom") {

            if ($("[id$='txtDOB']").val() == "") {
                $("[id$='txtDOB']").css("border", "1px solid red");
                showErrorMessage("Please select date.")
                return;
            }
        }

        //var PatientId = $("[id$=ddlPatientList]").val();
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "ItemizationOfChargesReport.aspx?PatientId=" + SearchedPatientId + "&ProviderId=" + ProviderId + "&CustomDate=" + CustomDate + "&AsOf=" + AsOf + "&DateType=" + DateType + "&PayerId=" + PayerId;
    }

    if (ReportTypeName == "SCS") {

        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientIds = '';
        }
        window.location = "SettledChargesSummaryReport.aspx?PatientIds=" + PatientIds + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&ProcedureCode=" + ProcedureCode + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
}

function OpenPaymentsFilterDialog(ReportTypeName, ReportType) {
    debugger;
    $.post("filter/FilterDialoguePayments.aspx", { ReportTypeName: ReportTypeName }, function (data) {
        debugger;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $(".report-criteria-box .editable-container").html("");

        $("[id$='divDialogReportFilters']").html(returnHtml)
        .promise()
        .done(function () {
            //Report_InitializeDatesBoxes();
            debugger;
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

            $("[id$='divDialogReportFilters']").dialog({
                title: "Report Criteria",
                modal: true,
                width: "720",
                height: "auto",
                buttons: {

                    "OK": function () {


                        if ($("#rbReportTimeSpanSpecificDates").prop("checked")) {

                            var flag = false;
                            $(".required").each(function () {
                                if (!$(this).val()) { flag = true; }
                            });

                            if (flag) {
                                if ($("[id$='txtReportDateFrom']").val() == "") {
                                    $("[id$='txtReportDateFrom']").css("border", "1px solid red");
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }
                                else if ($("[id$='txtReportDateTo']").val() == "") {
                                    $("[id$='txtReportDateTo']").css("border", "1px solid red");
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }
                                else if ($("[id$='txtReportDateFrom']").val() == "" && $("[id$='txtReportDateTo']").val() == "") {
                                    $(".required").css({ "border": "1px solid red" });
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }

                            }
                        }
                        if (ReportTypeName == "ARAgingSummaryReport" || ReportTypeName == "InsuranceCollectionDetailReport" || ReportTypeName == "InsuranceCollectionSummaryReport" || ReportTypeName == "PatientCollectionSummary" || ReportTypeName == "PatientCollectionDetail") {
                            if ($("[id$='txtAgingDate']").val() == "") {
                                $("[id$='txtAgingDate']").css("border", "1px solid red");
                                showErrorMessage("Please select From and To date.")
                                return;
                            }
                        }
                        if (ReportTypeName == "UnpaidInsuranceClaimsReport") {
                            if ($("[id$='txtBillDateFrom']").val() == "") {
                                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                                showErrorMessage("Please select From and To date.")
                                return;
                            }



                        }
                        debugger;
                        OkPaymentsFilter(ReportTypeName, ReportType);
                        // $("[id$='divDialogReportFilters']").dialog("destroy");
                        //$(this).dialog("destroy");
                        //$(this).dialog("close"); 
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        });
    });
}
function OkPaymentsFilter(ReportTypeName, ReportType) {


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


    postDate = $("#ddlPostType").val();
    var TimeSpan = "";
    //TimeSpan = $("#divReportTimeSpan :radio:checked").closest("span").attr("class");
    debugger;
    var TimeSpan = $(".radio_li :radio:checked").closest("span").attr("class");

    var d = new Date();

    var month = d.getMonth() + 1;
    var year = d.getFullYear();
    var lastMonth = d.getMonth();
    var lastDay = new Date(year, month - 1, 0).getDate();
    var day = d.getDate();
    if (TimeSpan == "Beginning") {
        DateFrom = '';
        DateTo = '';
    }
    else if (TimeSpan == "YearToDate") {
        debugger;
        DateFrom = '01/01/' + year;
        DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
    }
    else if (TimeSpan == "LastMonth") {
        debugger;

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
        debugger;
        DateFrom = (month < 10 ? '0' : '') + month + '/' + '01/' + year;
        DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
    }
    else if (TimeSpan == "SpecificDates" || TimeSpan == null) {
        DateFrom = $("[id$='txtReportDateFrom']").val();
        DateTo = $("[id$='txtReportDateTo']").val();
    }
    else if (ReportTypeName == "PDR") {
        DateFrom = $("[id$='txtReportDateFrom']").val();
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
    var BillDateFrom = $("[id='txtBillDateFrom']").val();
    var BillDateTo = $("[id$='txtBillDateTo']").val();
    var Insurance = "";

    var DateType = "";
    $('.ddlAgingType').each(function () {
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
    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).parent().find("input[type='hidden']").val() + ",";
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
    $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ClaimStatus += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });
    if (ClaimStatus.length > 0) {
        ClaimStatus = ClaimStatus.slice(0, -1);
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

    $("[id$='ulMultiDenailPayerName'] .chk-multi-checkboxes").each(function () {

        if ($(this).is(":checked")) {

            Insurance += $(this).parent().find("input[type='hidden'] ").val() + ",";
        }
    });
    if (Insurance.length > 0) {
        Insurance = Insurance.slice(0, -1);
    }
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


    DateType = $("#ddlPostType").val();

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
    //New Reports Code Start From Here 
    ///Start
    if (ReportTypeName == "PaymentsDetailReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }
    if (ReportTypeName == "PatientBalanceDueDetail") {
        debugger;
        var filename = ReportTypeName + ".aspx";
        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "AppointmentsDetailReport") {
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "PatientPayments") {
        debugger;
        var filename = ReportTypeName + ".aspx";
        if (postDate != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var Datefrom = $("[id$='txtBillDateFrom']").val();
            var Dateto = $("[id$='txtBillDateTo']").val();
        }
        else {
            var Datefrom = $("[id='txtBillDateFrom']").val();
            var Dateto = $("[id$='txtBillDateTo']").val();
        }
        var DateType = postDate;
        var prams =
       {

           DateType: DateType,
           DateFrom: Datefrom,
           DateTo: Dateto

       };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");
    }

    if (ReportTypeName == "MissedCopaysReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "DailyPayments") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "PaymentByProcedureReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "PaymentsSummaryReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }
    if (ReportTypeName == "ProcedurePaymentsSummaryReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

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
        if (postDate != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return false;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return false;
            }
            var BillDateFrom = $("[id$='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
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
            OpenReportPage(filename, _isParameters, prams, ReportType);
            $("[id$='divDialogReportFilters']").dialog("destroy");

        }



    }



    if (ReportTypeName == "ContractManagementDetailReport") {
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
        if (postDate != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return false;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }



    if (ReportTypeName == "PaymentApplicationReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            payerName: payerName,
            checkNumber: checkNumber,
            postDate: postDate,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "PaymentApplicationSummaryReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "UnappliedAnalysisReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }
    if (ReportTypeName == "PayerMixSummaryReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "ARAgingSummaryReport") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            AgingType: AgingType,
            AgingDate: AgingDate,
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            PayerId: PayerId
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "InsuranceCollectionDetailReport") {
        debugger;
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }
    if (ReportTypeName == "InsuranceCollectionSummaryReport") {
        debugger;
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "PatientCollectionSummary") {
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
        var prams =
        {
            AgingType: AgingType,
            AgingDate: AgingDate,
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            PatientId: PatientId,
            ClaimStatus: ClaimStatus
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "PatientCollectionDetail") {
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
        var prams =
        {
            AgingType: AgingType,
            AgingDate: AgingDate,
            PracticeLocationId: PracticeLocationId,
            ProviderId: ProviderId,
            PatientId: PatientId,
            ClaimStatus: ClaimStatus
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }


    if (ReportTypeName == "UnpaidInsuranceClaimsReport") {
        debugger;
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "ERAEOBListReport") {
        debugger;
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "PatientTransactionsDetail") {
        debugger;
        var filename = ReportTypeName + ".aspx";

        var prams =
        {
            TimeSpan: TimeSpan,
            DateFrom: DateFrom,
            DateTo: DateTo,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "EncounterSummaryReport") {
        debugger;
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
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }



    if (ReportTypeName == "EncounterDetailReport") {
        debugger;
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
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }


    if (ReportTypeName == "ReportPostClaims") {
        debugger;
        var filename = ReportTypeName + ".aspx";
        if (POSCode == "") {
            showErrorMessage('Please Select atleast one code.');
            return;
        }

        if (PracticeLocationId == "") {
            showErrorMessage('Please Select atleast one location.');
            return;
        }


        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }

        if ($("[id$='chkPlaceOfServiceAll']").is(':checked')) {
            POSCode = '';
        }


        if (postDate != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }

        if ($("[id$='chkCalimStatusAll']").is(':checked')) {

            ClaimStatus = '';
        }
        var prams =
        {
            Datetype: postDate,
            PracticeLocationId: PracticeLocationId,
            POSCode: POSCode,
            TimeSpan: TimeSpan,
            BillDateFrom: BillDateFrom,
            BillDateTo: BillDateTo,
            ClaimStatus: ClaimStatus,
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");
    }



    if (ReportTypeName == "ReportMonthlyReconciliation") {
        debugger;
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
            showErrorMessage("Please select location.")
            return;
        }
        if (Year == "0" || Year == "") {
            $(".ddlMonthlyReconciliationYear ").css("border", "1px solid red");
            showErrorMessage("Please select year.")
            return;
        }
        if (Month == "0" || Month == "") {
            $(".ddlMonthlyReconciliationMonth ").css("border", "1px solid red");
            showErrorMessage("Please select month.")
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");
    }


    if (ReportTypeName == "RejectedDeniedClaims") {
        debugger;
        var filename = ReportTypeName + ".aspx";
        $("#DosDateTo").html("");
        $("#DosDateTo").text("Date");


        if (InsuranceName == "All") {
            InsuranceName = "";
        }
        if (postDate != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var DosDateFrom = $("[id$='txtBillDateFrom']").val();
            var DosDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var DosDateFrom = $("[id='txtBillDateFrom']").val();
            var DosDateTo = $("[id$='txtBillDateTo']").val();
        }
        var prams =
        {
            InsuranceName: InsuranceName,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DosDateFrom: DosDateFrom,
            DosDateTo: DosDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }


    if (ReportTypeName == "ThirtyPlusDaysAfterSubmission") {
        debugger;
        var filename = ReportTypeName + ".aspx";
        $("#DosDateTo").html("");
        $("#DosDateTo").text("Date");


        if (InsuranceName == "All") {
            InsuranceName = "";
        }
        if (postDate != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var DosDateFrom = $("[id$='txtBillDateFrom']").val();
            var DosDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var DosDateFrom = $("[id='txtBillDateFrom']").val();
            var DosDateTo = $("[id$='txtBillDateTo']").val();
        }
        var prams =
        {
            InsuranceName: InsuranceName,
            Datetype: postDate,
            TimeSpan: TimeSpan,
            DosDateFrom: DosDateFrom,
            DosDateTo: DosDateTo
        };
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "DenialsDetailReport") {
        debugger;
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }

    if (ReportTypeName == "DenialsSummaryReport") {
        debugger;
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
        OpenReportPage(filename, _isParameters, prams, ReportType);
        $("[id$='divDialogReportFilters']").dialog("destroy");

    }






    ///*///*///*///*///*///







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
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }

        window.location = "EncounterDetailReport.aspx?PracticeId=" + PracticeId + "&DateType=" + postDate + "&ddlSubmissionStatus=" + ddlSubmissionStatus + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;


    }


    // Appointment Detail

    if (ReportTypeName == "AppD") {

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

        var jsonVal = { PatientId: PatientId };
        $.ajax({
            type: "POST",
            url: "AppointmentsDetailReport.aspx/GetPatientDetailsResponse",
            data: JSON.stringify(jsonVal),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                if (response.d == true) {
                    window.location = "AppointmentsDetailReport.aspx?PracticeId=" + PracticeId + "&ProviderId=" + ProviderId + "&AppointmentStatus=" + AppointmentStatus + "&AppointmentReasons=" + AppointmentReasons + "&PracticeLocationId=" + PracticeLocationId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        });

    }

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
            showErrorMessage('Please Select atleast one code.');
            return;
        }

        if (PracticeLocationId == "") {
            showErrorMessage('Please Select atleast one location.');
            return;
        }


        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }

        if ($("[id$='chkPlaceOfServiceAll']").is(':checked')) {
            POSCode = '';
        }


        if (postDate != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var BillDateFrom = $("[id$='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var BillDateFrom = $("[id='txtBillDateFrom']").val();
            var BillDateTo = $("[id$='txtBillDateTo']").val();
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
        debugger;
        if (postDate != "") {
            if ($("[id$='txtBillDateFrom']").val() == "") {
                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            if ($("[id$='txtBillDateTo']").val() == "") {
                $("[id$='txtBillDateTo']").css("border", "1px solid red");
                showErrorMessage("Please select From and To date.")
                return;
            }
            var DateFrom = $("[id$='txtBillDateFrom']").val();
            var DateTo = $("[id$='txtBillDateTo']").val();
        }
        else {
            var DateFrom = $("[id='txtBillDateFrom']").val();
            var DateTo = $("[id$='txtBillDateTo']").val();
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
                showErrorMessage('Please Select From date first.');
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
        SelectedTimeSpan = DateFrom + " - " + DateTo;
    }
    else {
        SelectedTimeSpan = $("#divReportTimeSpan :radio:checked").closest("span").find("label").html().trim();
    }

    $("[id$='lblTimeSpan']").html(SelectedTimeSpan);
}
function Report_GetSelectedMultiCheckBoxDropDownItemsText(CurrentUl) {
    CurrentUl = $("#" + CurrentUl);

    var MultiText = "";

    if (CurrentUl.find(".chk-multi-checkboxes").length == CurrentUl.find(".chk-multi-checkboxes:checked").length) {
        MultiText = "All";
    }
    else {
        CurrentUl.find(".chk-multi-checkboxes").each(function () {
            if ($(this).is(":checked")) {
                MultiText += $(this).parent().find("span").html().trim() + ",";
            }
        });

        if (MultiText.length > 0) {
            MultiText = MultiText.slice(0, -1);
        }
    }

    return MultiText;
}
function Report_ClickMultiCheckBoxAll(elem) {

    var CheckBox = $(elem).find(":checkbox");

    var CurrentUl = $(elem).closest("ul");

    CurrentUl.find(".chk-multi-checkboxes").prop("checked", CheckBox.is(":checked"));

    var MultiText = "";

    if (CheckBox.is(":checked")) {
        MultiText = "All";
    }

    $(elem).closest(".dropDownMenu").find(".selectedText").html(MultiText);
    $(elem).closest(".dropDownMenu").find(".selectedText").prop("title", MultiText);
}
function Report_ClickMultiCheckBox(elem) {

    var CurrentUl = $(elem).closest("ul");
    var CurrentUlId = $(elem).closest("ul").attr("id");

    if (CurrentUl.find(".chk-multi-checkboxes").length == CurrentUl.find(".chk-multi-checkboxes:checked").length) {
        CurrentUl.find(".chk-multi-checkboxes-all").prop("checked", true);
    }
    else {
        CurrentUl.find(".chk-multi-checkboxes-all").prop("checked", false);
    }

    var MultiText = Report_GetSelectedMultiCheckBoxDropDownItemsText(CurrentUlId);

    $(elem).closest(".dropDownMenu").find(".selectedText").html(MultiText);
    $(elem).closest(".dropDownMenu").find(".selectedText").prop("title", MultiText);
}
function EnableDates(enable) {
    if (!enable) {
        $("[id$='txtReportDateFrom']").val("");
        $("[id$='txtReportDateTo']").val("");

    }

    $("[id$='txtReportDateFrom']").prop("disabled", !enable);
    $("[id$='txtReportDateTo']").prop("disabled", !enable);
}
/**********END SHAHID AKZMI 11/17/2017****************/