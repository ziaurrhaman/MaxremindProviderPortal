
var _SortBy = '';
var _SortByValue = '';


var _arrSelectedColumn;

function GenerateReportPaging(TotalRows, PageRows, parentdiv, callfunc) {
    if (parseInt(TotalRows) == 0) {
        $("#" + parentdiv + " .PageButtonsReports ul").html("");
        $("#pagingReportDiv").next().find(".ReportGrid").after("<div style='text-align: center;color: red;font-size: 14px;font-weight: bold;line-height: 35px;font-style: italic;'>No Record Found.</div>");
    }
    else if (parseInt(TotalRows) < parseInt(PageRows)) {
        var pages = (TotalRows % PageRows) == 0 ? (TotalRows / PageRows) : parseInt((TotalRows / PageRows)) + 1;

        var pagingHtml = "";
        pagingHtml = "<li><a href='javascript:void(0)' title='First' onclick='FirstPage(\"" + parentdiv + "\");' id='First'><span class='iconFirst' alt='Previous'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Previous' onclick='PreviousPage(\"" + parentdiv + "\");' id='Previous'><span class='iconPrevious' alt='Previous'></span></a></li>";
        pagingHtml += "<li><span class='report-page-title'>Page</span><input type='text' id='txtReportPageNumber' onkeyup='JumpToPageNo(event)' class='report-input-page-number' value='1' /><span class='report-page-number'>of " + pages + "</span></li>";
        pagingHtml += "<li class='paging-hidden-buttons'><a href='javascript:void(0)' title='Page 1' id='" + parentdiv + "Page0'><b>1</b></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Next' onclick='NextPage(\"" + parentdiv + "\");' id='Next'><span class='iconNext' alt='Next'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Last' style='margin: 0 0 0 2px !important;' onclick='FirstPage(\"" + parentdiv + "\");' id='First'><span class='iconLast' alt='Last'></span></a></li>";
        $("#" + parentdiv + " .PageButtonsReports ul").html(pagingHtml);
    } else {
        var pages = (TotalRows % PageRows) == 0 ? (TotalRows / PageRows) : parseInt((TotalRows / PageRows)) + 1;

        var pagingHtml = "";
        pagingHtml = "<li><a href='javascript:void(0)' title='First' onclick='FirstPage(\"" + parentdiv + "\");' id='First'><span class='iconFirst' alt='Previous'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Previous' onclick='PreviousPage(\"" + parentdiv + "\");' id='Previous'><span class='iconPrevious' alt='Previous'></span></a></li>";

        pagingHtml += "<li><span class='report-page-title'>Page</span><input type='text' id='txtReportPageNumber' onkeyup='JumpToPageNo(event)' class='report-input-page-number' value='1' /><span class='report-page-number'>of " + pages + "</span></li>";

        for (var i = 0; i < pages; i++) {
            pagingHtml += "<li class='paging-hidden-buttons'><a href='javascript:void(0)' title='Page" + (i + 1) + "' onclick='GetRecords(this," + (i) + ",\"" + parentdiv + "\"," + callfunc + ");' id='" + parentdiv + "Page" + (i) + "'><b>" + (i + 1) + "</b></a></li>";
        }

        pagingHtml += "<li><a href='javascript:void(0)' title='Next' onclick='NextPage(\"" + parentdiv + "\");' id='Next'><span class='iconNext' alt='Next'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Last' style='margin: 0 0 0 2px !important;' onclick='LastPage(\"" + parentdiv + "\", " + pages + ");' id='First'><span class='iconLast' alt='Last'></span></a></li>";

        $("#" + parentdiv + " .PageButtonsReports ul").html(pagingHtml);
    }

    $("#" + parentdiv + "Page0").parent().addClass("current");
    //HideShowPages(parentdiv);
}

function GetRecords(obj, pageNumber, parentdiv, callfunc) {
    if (!$(obj).hasClass("current")) {
        callfunc(pageNumber);
    }
    $("#" + parentdiv + " .PageButtonsReports li.current").removeClass("current");
    $("#" + parentdiv + "Page" + pageNumber).parent().addClass("current");

    //HideShowPages(parentdiv);
}

function FirstPage(parentdiv) {
    $("#txtReportPageNumber").val($("#" + parentdiv + " .PageButtonsReports ul li").first().next().next().next().find("a b").html());
    $("#" + parentdiv + " .PageButtonsReports ul li").first().next().next().next().find("a").click();
}

function LastPage(parentdiv, Page) {
    $("#txtReportPageNumber").val($("#" + parentdiv + " .PageButtonsReports ul li").last().prev().prev().find("a b").html());
    $("#" + parentdiv + " .PageButtonsReports ul li").last().prev().prev().find("a").click();
}


function PreviousPage(parentdiv) {
    $("#txtReportPageNumber").val($("#" + parentdiv + " .PageButtonsReports li.current").prev().find("a b").html());

    var PreviousPage = $("#" + parentdiv + " .PageButtonsReports li.current").prev().find("a");
    if (PreviousPage.attr("id") != "Previous") {
        $("#" + parentdiv + " .PageButtonsReports li.current").prev().find("a").click();
    }
}

function NextPage(parentdiv) {
    debugger;
    $("#txtReportPageNumber").val($("#" + parentdiv + " .PageButtonsReports li.current").next().find("a b").html());

    var NextPage = $("#" + parentdiv + " .PageButtonsReports li.current").next().find("a");
    if (NextPage.attr("id") != "Next") {
        $("#" + parentdiv + " .PageButtonsReports li.current").next().find("a").click();
    }

}



function HideShowPages(parentdiv) {
    if ($("#" + parentdiv + " .PageButtonsReports ul li").length > 9) {
        $("#" + parentdiv + " .PageButtonsReports ul li").hide();
        $("#" + parentdiv + " .PageButtonsReports ul li").first().show();
        $("#" + parentdiv + " .PageButtonsReports ul li").first().next().show();
        $("#" + parentdiv + " .PageButtonsReports ul li").last().show();
        $("#" + parentdiv + " .PageButtonsReports ul li").last().prev().show();

        if (($("#" + parentdiv + " .PageButtonsReports ul li").length - 4) - ($("#" + parentdiv + " .PageButtonsReports li.current").index() - 1) > 2) {
            if ($("#" + parentdiv + " .PageButtonsReports li.current").index() > 3) {
                $("#" + parentdiv + " .PageButtonsReports ul li").slice($("#" + parentdiv + " .PageButtonsReports li.current").index(), ($("#" + parentdiv + " .PageButtonsReports li.current").index() + 3)).show();
                $("#" + parentdiv + " .PageButtonsReports ul li").slice(($("#" + parentdiv + " .PageButtonsReports li.current").index() - 2), $("#" + parentdiv + " .PageButtonsReports li.current").index()).show();
            }
            else if ($("#" + parentdiv + " .PageButtonsReports li.current").index() < 4) {
                $("#" + parentdiv + " .PageButtonsReports ul li").slice(2, 7).show();
            }
        }

        else {
            $("#" + parentdiv + " .PageButtonsReports ul li").slice(($("#" + parentdiv + " .PageButtonsReports ul li").length - 7), ($("#" + parentdiv + " .PageButtonsReports ul li").length - 2)).show();
        }
    }
}

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
    debugger;

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
  else  if (divMultipleDropdownCheckboxList == "divReportAgencyBranches") {// when branch name drop down is clicked
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open

        $("#divReportServiceProvider").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }

   
    else if (divMultipleDropdownCheckboxList == "divReportPatient") {// when branch name drop down is clicked
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open

        $("#divReportServiceProvider").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divReportAdmissionStatus") {
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divReportMonths").hide();
    }
        /************added by shahid kazmi 4/6/2017 for Admission Status dropdownlist***********/
    else if (divMultipleDropdownCheckboxList == "divReportEmployee") {
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportServiceProvider").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divReportMonths").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divReportAuthorizationStatus") {
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }

    else if (divMultipleDropdownCheckboxList == "divInsurance") {
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }
    else if (divMultipleDropdownCheckboxList == "divReportInsurance") {
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
    }
        /*************end shahid kazmi 4/6/2017******************/
    else if (divMultipleDropdownCheckboxList == "divReportServiceProvider") {
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();
        $("#divPayerScenario").hide();
        $("#divPracticeLocation").hide();

    } else if (divMultipleDropdownCheckboxList == "divReportPatientDetail") {
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();

    }
    else if (divMultipleDropdownCheckboxList == "divReportCaseManager") {
        debugger;
        $("#" + divMultipleDropdownCheckboxList).slideToggle();
        //other two shouldn't be open
        $("#divReportAgencyBranches").hide();
        $("#divReportTaskStatus").hide();
        $("#divReportMonths").hide();
        $("#divReportAgencyInsurance").hide();

    }
    else if (divMultipleDropdownCheckboxList == "divReportTaskStatus") {
        debugger;
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
    FilterReportList(0, true);
}

function Report_ReloadData(actionPage, params, paging) {
    $.post(_EMRPath + "/Reports/CallBacks/" + actionPage, params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#tbodyReportList").html(returnHtml)
        .promise()
        .done(function () {
            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            start = data.indexOf("###StartTotal###") + 16;
            end = data.indexOf("###EndTotal###");
            returnHtml = $.trim(data.substring(start, end));

            $("[id$='hdnTotalRows']").val(returnHtml);

            if (paging == true) {
                GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
            }
        });
    });
}

function PrintReport(divToPrint) {
    debugger;
    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body></html>";
    var newstr = $("[id$='" + divToPrint + "']").html();

    var popupWin = window.open('', '_blank');
    popupWin.document.write(headstr + newstr + footstr);
    popupWin.print();
    return false;
}
/*************ADDED BY SHAHID KAZMI 11/17/2017*********/
function OpenPatientFilterDialog(ReportType) {
    debugger;

    if (ReportType == "PBS") {
        debugger
        $("[id='txtDOB']").prop("disabled", false);
    }

    $.post("CallBacks/PatientFilterDialog.aspx", { ReportType: ReportType }, function (data) {
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
                        debugger;
                        window.open("data:application/vnd.ms-excel," + $("[id$='divDialogReportFilterBoxInner']").html());
                        e.preventDefault();
                    },*/

                    "OK": function () {

                        debugger;
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
                        if (ReportType == "PS" && DateType == "PostDate") {
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


                        if (ReportType == "PBD" || ReportType == "PD" || ReportType == "AD" || ReportType == "AS" || ReportType == "IOC" || ReportType == "PD" || ReportType == "CS" || ReportType == "CD")
                        {debugger
                            
                            if ($("#TxtPatientSearch").val() == "")
                            {
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
                        if (ReportType == "PBD") {
                            if (CustomDate == "Custom") {
                                if ($("[id$='txtDOB']").val() == "") {
                                    $("[id$='txtDOB']").css("border", "1px solid red");
                                    showErrorMessage("Please select From and To date.")
                                    return;
                                }
                            }
                        }
                       
                       
                        OkPatientFilter(ReportType);
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
    debugger;
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
        debugger

        $("[id$='txtDOB1']").prop("disabled", true);
        $("[id$='txtDOB1']").val(" ");
    }
    if (Actuvity == "0") {

        debugger;
        $("[id='txtDOB1']").prop("disabled", false);

        
    }

    

}
function OkPatientFilter(ReportType) {

    debugger;
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
    else if (ReportType == "PDR") {
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
        debugger;
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

    if (ReportType == "PS") {
        var NewTimeSpan = "HasDate";
        debugger
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
        if (DateType != "0") {
            NewTimeSpan = "All";;
        }
        window.location = "PatientSummaryReport.aspx?PracticeId=" + PracticeId + "&DateType=" + DateType + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&NewTimeSpan=" + NewTimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }
    if (ReportType == "PD") {

        //var jsonVal = { PatientIds: PatientIds };
        //$.ajax({
        //    type: "POST",
        //    url: "PatientDetails.aspx/GetPatientDetailsResponse",
        //    data: JSON.stringify(jsonVal),
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    success: function (response) {
        //        debugger;
        //        if (response.d == true) {
        //            window.location = "PatientDetails.aspx?PatientIds=" + PatientIds;
        //        }
        //    },
        //    failure: function (response) {
        //        alert(response.d);
        //    }
        //});
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
    if (ReportType == "PBD") {
        debugger;
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
    if (ReportType == "PBS") {
        debugger;
        if (CustomDate == "Custom") {

            if ($("[id$='txtDOB']").val() == "") {
                $("[id$='txtDOB']").css("border", "1px solid red");
                showErrorMessage("Please select date.")
                return;
            }
        }
      
        window.location = "PatientBalanceSummaryReport.aspx?AssignedTo=" + AssignedTo + "&CustomDate=" + CustomDate + "&AsOf=" + AsOf;
    }
    if (ReportType == "PTS") {
        window.location = "PatientTransactionsSummaryReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }

    if (ReportType == "AD") {
        debugger;
        if (DateType != "")
        {
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
    if (ReportType == "AS") {
        debugger;
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
    if (ReportType == "CS") {
        debugger;
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
    if (ReportType == "CD") {
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
    if (ReportType == "PBP") {
        window.location = "PaymentByProcedureReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }


    if (ReportType == "PCL")
    {
        var TimeSpan = "";
        if ($("[id$='txtDOB1']").val() != "") {

            debugger;
        
            TimeSpan = $("[id$='txtDOB1']").val();

           


        }
        else {
            if (Actuvity == "")
            {
                TimeSpan = "All Records";
            }
            else {
                TimeSpan = Actuvity;
            }
          
        }
        var DOB = $("[id$='txtDOB1']").val();
        debugger
        window.location = "PatientContactList.aspx?PracticeId=" + PracticeId + "&Actuvity=" + Actuvity + "&ProviderId=" + ProviderId + "&DiagnosisCode=" + DiagnosisCode + "&ProcedureCode=" + ProcedureCode + "&Gender=" + Gender + "&PayerId=" + PayerId + "&DOB=" + DOB + "&TimeSpan=" + TimeSpan;
    }


    var AsOf = DOB;
    if (ReportType == "IOC") {
        debugger;
       
        if (CustomDate == "Custom") {

            if ($("[id$='txtDOB']").val() == "")
            {
                $("[id$='txtDOB']").css("border", "1px solid red");
                showErrorMessage("Please select date.")
                return;
            }
        }

        //var PatientId = $("[id$=ddlPatientList]").val();
        var SearchedPatientId = $("#hdnsearchpatientid").val();
        window.location = "ItemizationOfChargesReport.aspx?PatientId=" + SearchedPatientId + "&ProviderId=" + ProviderId + "&CustomDate=" + CustomDate + "&AsOf=" + AsOf + "&DateType=" + DateType + "&PayerId=" + PayerId;
    }

    if (ReportType == "SCS") {
        debugger;
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

function OpenPaymentsFilterDialog(ReportType) {
    debugger;
    $.post("CallBacks/PaymentsFilterDialog.aspx", { ReportType: ReportType }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $(".report-criteria-box .editable-container").html("");

        $("[id$='divDialogReportFilters']").html(returnHtml)
        .promise()
        .done(function () {
            //Report_InitializeDatesBoxes();

            $("[id$='divDialogReportFilters']").dialog({
                title: "Report Criteria",
                modal: true,
                width: "720",
                height: "auto",
                buttons: {

                    "OK": function () {

                        debugger;
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
                        if (ReportType == "ARASA" || ReportType == "ICD" || ReportType == "ICS" || ReportType == "PCS" || ReportType == "PCD") {
                            if ($("[id$='txtAgingDate']").val() == "") {
                                $("[id$='txtAgingDate']").css("border", "1px solid red");
                                showErrorMessage("Please select From and To date.")
                                return;
                            }
                        }
                        if (ReportType == "UNC") {
                            if ($("[id$='txtBillDateFrom']").val() == "") {
                                $("[id$='txtBillDateFrom']").css("border", "1px solid red");
                                showErrorMessage("Please select From and To date.")
                                return;
                            }
                            //if ($("[id$='txtBillDateTo']").val() == "") {
                            //    $("[id$='txtBillDateTo']").css("border", "1px solid red");
                            //    showErrorMessage("Please select From and To date.")
                            //    return;
                            //}
                        }
                        OkPaymentsFilter(ReportType);
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
function OkPaymentsFilter(ReportType) {

    debugger;
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
    else if (ReportType == "PDR") {
        var DateFrom = $("[id$='txtReportDateFrom']").val();
    }

    var DiagnosisCode = "";
        DiagnosisCode = $("#txtIcdCode1").val();
        var ProcedureCode = "";
            ProcedureCode = $("#txtCPTCode").val();



    if (ReportType == "PBP") {
        window.location = "PaymentByProcedureReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
    if (ReportType == "PD") {
        window.location = "PaymentsDetailReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
    if (ReportType == "PS") {
        window.location = "PaymentsSummaryReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
    if (ReportType == "PPS") {
        window.location = "ProcedurePaymentsSummaryReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
    
  
    if (ReportType == "MC") {
        window.location = "MissedCopaysReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
    if (ReportType == "PA") {
        window.location = "PaymentApplicationReport.aspx?PracticeId=" + PracticeId + "&payerName=" + payerName + "&checkNumber=" + checkNumber + "&postDate=" + postDate;
    }
    if (ReportType == "PAS") {
        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }
        window.location = "PaymentApplicationSummaryReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
    if (ReportType == "UA") {
        if (TimeSpan == "Beginning") {
            var DateFrom = '01/01/1950';
            var DateTo = (month < 10 ? '0' : '') + month + '/' + (day < 10 ? '0' : '') + day + '/' + year;
        }
        window.location = "UnappliedAnalysisReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
    if (ReportType == "PMS") {
        window.location = "PayerMixSummaryReport.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }

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
    debugger;
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

    if (ReportType == "ARAS") {
        window.location = "ARAgingSummaryReport.aspx?PracticeId=" + PracticeId + "&AgingType=" + AgingType + "&AgingDate=" + AgingDate + "&PracticeLocationId=" + PracticeLocationId + "&ProviderId=" + ProviderId + "&PayerId=" + PayerId;
    }

    if (ReportType == "ICD") {
        window.location = "InsuranceCollectionDetailReport.aspx?PracticeId=" + PracticeId + "&AgingType=" + AgingType + "&AgingDate=" + AgingDate + "&PracticeLocationId=" + PracticeLocationId + "&ProviderId=" + ProviderId + "&PayerId=" + PayerId + "&ClaimStatus=" + ClaimStatus;
    }
    if (ReportType == "ICS") {
        window.location = "InsuranceCollectionSummaryReport.aspx?PracticeId=" + PracticeId + "&AgingType=" + AgingType + "&AgingDate=" + AgingDate + "&PracticeLocationId=" + PracticeLocationId + "&ProviderId=" + ProviderId + "&PayerId=" + PayerId + "&ClaimStatus=" + ClaimStatus;
    }

    if (ReportType == "PCS") {
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientId = '';
        }
        var jsonVal = { PracticeId: PracticeId, AgingType: AgingType, AgingDate: AgingDate, PracticeLocationId: PracticeLocationId, ProviderId: ProviderId, PatientId: PatientId };
        $.ajax({
            type: "POST",
            url: "PatientCollectionSummary.aspx/GetPatientDetailsResponse",
            data: JSON.stringify(jsonVal),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                debugger;
                if (response.d == true) {
                    window.location = "PatientCollectionSummary.aspx?PracticeId=" + PracticeId + "&AgingType=" + AgingType + "&AgingDate=" + AgingDate;
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }

    if (ReportType == "PCD") {
        if ($("[id$='chkPracticeLocationAll']").is(':checked')) {
            PracticeLocationId = '';
        }
        if ($("[id$='chkServiceProviderAll']").is(':checked')) {
            ProviderId = '';
        }
        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientId = '';
        }
      
        
        var jsonVal = { PracticeId: PracticeId, AgingType: AgingType, AgingDate: AgingDate, PracticeLocationId: PracticeLocationId, ProviderId: ProviderId, PatientId: PatientId };
        $.ajax({
            type: "POST",
            url: "PatientCollectionDetail.aspx/GetPatientDetailsResponse",
            data: JSON.stringify(jsonVal),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                debugger;
                if (response.d == true) {
                    window.location = "PatientCollectionDetail.aspx?PracticeId=" + PracticeId + "&AgingType=" + AgingType + "&AgingDate=" + AgingDate;
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }


    if (ReportType == "CMD") {
        debugger;
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
        

        var jsonVal = { PatientId: PatientId };
        $.ajax({
            type: "POST",
            url: "ContractManagementDetailReport.aspx/GetPatientDetailsResponse",
            data: JSON.stringify(jsonVal),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                debugger;
                if (response.d == true) {
                    window.location = "ContractManagementDetailReport.aspx?PracticeId=" + PracticeId + "&ProcedureCode=" + ProcedureCode + "&DateType=" + postDate + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        });
       
    }


    if (ReportType == "CMS") {
        debugger;
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

        var jsonVal = { PatientId: PatientId };
        $.ajax({
            type: "POST",
            url: "ContractManagementSummaryReport.aspx/GetPatientDetailsResponse",
            data: JSON.stringify(jsonVal),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                debugger;
                if (response.d == true) {
                    debugger;
                    window.location = "ContractManagementSummaryReport.aspx?PracticeId=" + PracticeId + "&insuid=" + insuid + "&ProcedureCode=" + ProcedureCode + "&DateType=" + postDate + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo + "&InsuranceName=" + InsuranceName;
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        });

      
    }

   


    if (ReportType == "UNC") {
        debugger;
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
        window.location = "UnpaidInsuranceClaimsReport.aspx?PracticeId=" + PracticeId + "&PayerId=" + unpaidInsurance + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&Balance=" + Balance + "&DateOfService=" + DateOfService + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;
    }
    if (ReportType == "DD") {
        debugger;
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
        if ($("[id$='chkDenailPayerNameAll']").is(':checked')) {
            Insurance = '';
        }
        window.location = "DenialsDetailReport.aspx?PracticeId=" + PracticeId + "&DateType=" + postDate + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&Insurance=" + Insurance + "&AdjustmentCode=" + AdjustmentCode;
    }
    if (ReportType == "DS") {

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
        if ($("[id$='chkDenailPayerNameAll']").is(':checked')) {
            Insurance = '';
        }
        window.location = "DenialsSummaryReport.aspx?PracticeId=" + PracticeId + "&DateType=" + postDate + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&Insurance=" + Insurance + "&AdjustmentCode=" + AdjustmentCode;
    }
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
    if (ReportType == "ERAEOB") {
        if (PaymentType == "0") {
            PaymentType = "";
        }
        if (PaymentMethod == "0") {
            PaymentMethod = "";
        }
        if (InsuranceName == "All") {
            InsuranceName = "";
        }
        window.location = "ERAEOBListReport.aspx?InsuranceName=" + InsuranceName + "&PaymentType=" + PaymentType + "&PaymentMethod=" + PaymentMethod + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
    }
    if (ReportType == "PTD") {

        if ($("[id$='chkPatientNameAll']").is(':checked')) {
            PatientId = '';
        }
        var jsonVal = { PracticeId: PracticeId, PatientId: PatientId, TimeSpan: TimeSpan, DateFrom: DateFrom, DateTo: DateTo };
        $.ajax({
            type: "POST",
            url: "PatientTransactionsDetail.aspx/GetPatientDetailsResponse",
            data: JSON.stringify(jsonVal),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                debugger;
                if (response.d == true) {
                    window.location = "PatientTransactionsDetail.aspx?PracticeId=" + PracticeId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }

    // Rizwan kharal 
    // Start New Reports 29jan2018 

    //encounter detail
    if (ReportType == "PED")
    {
        debugger;
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
        debugger
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
        debugger;
        window.location = "EncounterDetailReport.aspx?PracticeId=" + PracticeId + "&DateType=" + postDate + "&ddlSubmissionStatus=" + ddlSubmissionStatus + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;


    }
     //Encounter Summary

    if (ReportType == "ES") {
        debugger;
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

        window.location = "EncounterSummaryReport.aspx?PracticeId=" + PracticeId + "&DateType=" + DateType + "&ddlSubmissionStatus=" + ddlSubmissionStatus + "&ProviderId=" + ProviderId + "&PracticeLocationId=" + PracticeLocationId + "&PayerId=" + PayerId + "&TimeSpan=" + TimeSpan + "&BillDateFrom=" + BillDateFrom + "&BillDateTo=" + BillDateTo;


    }

    // Appointment Detail

    if (ReportType == "AppD") {
        debugger;
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
                debugger;
                if (response.d == true) {
                    window.location = "AppointmentsDetailReport.aspx?PracticeId=" + PracticeId + "&ProviderId=" + ProviderId + "&AppointmentStatus=" + AppointmentStatus + "&AppointmentReasons=" + AppointmentReasons + "&PracticeLocationId=" + PracticeLocationId + "&TimeSpan=" + TimeSpan + "&DateFrom=" + DateFrom + "&DateTo=" + DateTo;
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        });

    }




    //Rizwan kharal
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
    var DateFrom = $("[id$='hdnDateFrom']").val();
    var DateTo = $("[id$='hdnDateTo']").val();

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
    debugger;
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
    debugger;
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