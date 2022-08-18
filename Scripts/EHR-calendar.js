/// <reference path="Common.js" />

var $calendar, id, $dialogContent, $endTimeField, $endTimeOptions, $timestampsOfOptions, _appointmentId;
var _isddlchange = false;
var isEventCreate = false;

var _IsEventDragging = false;

var AppointmentIdCopied = 0;
var _PracticeLocationDateUTC;
var _PracticeLocationCurrentTimeUTC;
var _arrUsers = new Array();

$(document).ready(function () {
    $dialogContent = $("#divAppointmentContainer");
    $calendar = $('#calendar');
    id = 10;
    $endTimeField = $("select[name='end']");
    $endTimeOptions = $endTimeField.find("option");
    $timestampsOfOptions = { start: [], end: [] };
    
    LoadAppointmentCalendar();
    
    //reduces the end time options to be only after the start time options.
    $("select[name='start']").change(function () {
        var startTime = $timestampsOfOptions.start[$(this).find(":selected").text()];
        var currentEndTime = $endTimeField.find("option:selected").val();
        $endTimeField.html(
            $endTimeOptions.filter(function () {
                return startTime < $timestampsOfOptions.end[$(this).text()];
            })
            );

        var endTimeSelected = false;
        $endTimeField.find("option").each(function () {
            if ($(this).val() === currentEndTime) {
                $(this).attr("selected", "selected");
                endTimeSelected = true;
                return false;
            }
        });
        
        if (!endTimeSelected) {
            //automatically select an end date 2 slots away.
            $endTimeField.find("option:eq(1)").attr("selected", "selected");
        }
    });
});

function SetPracticeLocationDateTimeUTC() {
    var PracticeLocationsId = $("[id$='ddLocationMain']").val();
    var UTCOffset = _arrLocationStateUTC[PracticeLocationsId];
    _PracticeLocationDateUTC = GetDateByLocationUTC(UTCOffset, "Date");
    
    _PracticeLocationCurrentTimeUTC = GetDateByLocationUTC(UTCOffset, "Time");
}

function LoadAppointmentCalendar() {
    SetPracticeLocationDateTimeUTC();
    loadCalendar();
}

function RefreshAppointmentCalendar() {
    SetPracticeLocationDateTimeUTC();
    ReloadCalendar();
}

function ReloadCalendar() {
    $calendar.weekCalendar('refresh');
}

function locationChanged() {
    var PracticeLocationId = $("[id$='ddLocationMain']").val();
    
    $.post(_ControlPath + "/ProvidersByLocation.aspx", { PracticeLocationId: PracticeLocationId }, function (data) {
        var start = data.indexOf("###StartProviderDropdown###") + 27;
        var end = data.indexOf("###EndProviderDropdown###");
        var ProviderDropdown = $.trim(data.substring(start, end));
        
        $("[id$='ddAppProvider']").html(ProviderDropdown)
        .promise()
        .done(function () {
            if ($("[id$='ddAppProvider'] option").length > 0) {
                $("[id$='ddAppProvider']").val(0);
            }
        });
        
        $("[id$='ddDialogAppProvider']").html(ProviderDropdown)
        .promise()
        .done(function () {
            if ($("[id$='ddDialogAppProvider'] option").length > 0) {
                $("[id$='ddDialogAppProvider']").val(0);
            }
        });
        
        RefreshAppointmentCalendar();
    });
    
    return true;
}

function providerChanged() {
    $calendar.weekCalendar('refresh');
    var _locationId = $("[id$='ddLocationMain']").val();
    var _providerId = $("[id$='ddAppProvider']").val();
    $("[id$='lnkAppointments']").attr("href", _PatientEHRPath + "/CreateAppointment.aspx?LocationId=" + _locationId + "&ProviderId=" + _providerId);
    _isddlchange = true;
    return false;
}

function loadCalendar() {
    $calendar.weekCalendar({
        displayOddEven: true,
        timeslotsPerHour: 4,
        timeslotHeight: 32,
        allowCalEventOverlap: true,
        allowEventUpdate: false,
        allowEventDelete: true,
        overlapEventsSeparate: true,
        displayFreeBusys: true,
        firstDayOfWeek: 1,
        defaultFreeBusy: { free: false },
        businessHours: { start: 0, end: 24, limitDisplay: false },
        daysToShow: 1,
        //defaultEventLength: 2,
        //switchDisplay: { '1 day': 1, '3 next days': 3, 'work week': 5, 'full week': 7 },
        title: function (daysToShow) {
            return daysToShow == 1 ? '%date%' : '%start% - %end%';
        },
        height: function ($calendar) {
            return $(document).height() - $("#calendar").offset().top - 20;
        },
        users: [],
        eventRender: function (calEvent, $event) {
            if (calEvent.end.getTime() < new Date().getTime()) {
                $event.css("backgroundColor", "#aaa");
                $event.find(".wc-time").css({
                    "backgroundColor": "#999",
                    "border": "1px solid #888"
                });
            }
            else {
                //$event.css("backgroundColor", calEvent.status_back_color);
                $event.find(".wc-time").css({
                    "backgroundColor": calEvent.status_back_color,
                    "border": "1px solid #888"
                });
            }
        },
        draggable: function (calEvent, $event) {
            return false;
        },
        resizable: function (calEvent, $event) {
            return false;
        },
        eventDrop: function (calEvent, $event) {},
        eventResize: function (calEvent, $event) {},
        eventMouseover: function (calEvent, $event) {},
        eventMouseout: function (calEvent, $event) {},
        noEvents: function () { },
        eventNew: EventNew,
        eventClick: EventExisting,
        eventDelete: EventDelete,
        data: EventData
    });
}

function EventNew(calEvent, $event, FreeBusyManager, calendar) {
    if ($("[id$='ddAppProvider'] option").length == 0) {
        callDialog("Sorry! seems to have no provider at this location.", "Notification");
        $(calendar).weekCalendar('removeEvent', calEvent.id);
        return false;
    }

    calEvent.id = 0;
    isEventCreate = false;
    var isFree = true;
    var isPastTime = false;
    
    if (calEvent.end.getTime() < _PracticeLocationCurrentTimeUTC.getTime()) {
        isPastTime = true;
    }

    $.each(FreeBusyManager.getFreeBusys(calEvent.start, calEvent.end), function (i, e) {
        isFree = this.getOption('free');
    });

    if (!isFree || isPastTime) {
        var notificationMessage = "Requested slot is busy/unavailable!";

        $("#divDialogConfirmationMaster").html(notificationMessage).dialog({
            title: "Notification",
            resizable: false,
            modal: true,
            width: 'auto',
            height: 'auto',
            buttons: {
                "Ok": function () {
                    $("#divDialogConfirmationMaster").dialog("close");
                    $(calendar).weekCalendar('removeEvent', calEvent.id);
                }
            },
            close: function () {
                if (!isEventCreate) {
                    $calendar.weekCalendar("removeUnsavedEvents");
                }

                $(this).dialog("destroy");
            }
        });

        return false;
    }

    CreateEvent(calEvent);
}

function CreateEvent(calEvent) {
    var isEventCreate = false;

    SetAppointmentFormBeforeOpen(calEvent);

    $dialogContent.dialog({
        modal: true,
        title: "New Appointment",
        draggable: true,
        width: "auto",
        buttons: {
            Create: function () {
                isEventCreate = true;
                SaveAppointment(calEvent);
            },
            Cancel: function () {
                $dialogContent.dialog("close");
            }
        },
        close: function () {
            if (!isEventCreate) {
                $calendar.weekCalendar("removeUnsavedEvents");
            }

            $("[id$='ddAppStatus']").val("");

            if (!isEventCreate) {
                $calendar.weekCalendar("removeUnsavedEvents");
            }

            $dialogContent.dialog("destroy");
        }
    }).show();
}


function EventExisting(calEvent, $event, FreeBusyManager, calendar, event) {
    SetAppointmentFormBeforeOpen(calEvent);
    
    $("[id$='ddDialogAppProvider']").val(calEvent.providerId);
    $("[id$='ddReason']").val(calEvent.reasonId);
    
    var startField = $dialogContent.find("select[name='start']").val(calEvent.start);
    var endField = $dialogContent.find("select[name='end']").val(calEvent.end);
    var AppointmentCurrentStatusId = calEvent.statusId;
    
    $("[id$='ddAppStatus']").val(AppointmentCurrentStatusId);
    
    $("#taNotes").val(calEvent.Notes);
    
    $dialogContent.dialog({
        modal: true,
        title: "Edit Appointment",
        draggable: true,
        width: "auto",
        close: function () {
            $dialogContent.dialog("destroy");
            $dialogContent.hide();
            $('#calendar').weekCalendar("removeUnsavedEvents");
        },
        buttons: {
            Update: function () {
                var startTime = new Date(startField.val());
                var Time1 = (startTime.getMonth() + 1) + "/" + startTime.getDate() + "/" + startTime.getFullYear() + " " + startTime.getHours() + ':' + startTime.getMinutes() + ':' + startTime.getSeconds();

                var endTime = new Date(endField.val());
                var Time2 = (endTime.getMonth() + 1) + "/" + endTime.getDate() + "/" + endTime.getFullYear() + " " + endTime.getHours() + ':' + endTime.getMinutes() + ':' + endTime.getSeconds();

                var isFree = true;

                var allEvents = $calendar.weekCalendar("serializeEvents");

                for (var i = 0; i < allEvents.length; i++) {
                    if ((calEvent.id != allEvents[i].id) && (calEvent.userId == allEvents[i].userId)) {
                        if (startTime.getTime() == allEvents[i].start.getTime() || ((startTime.getTime() > allEvents[i].start.getTime()) && (startTime.getTime() < allEvents[i].end.getTime()))) {
                            isFree = false;
                        }
                    }
                }
                
                if (!isFree) {
                    var notificationMessage = "Requested slot is busy/unavailable!";

                    $("#divDialogConfirmationMaster").html(notificationMessage).dialog({
                        title: "Notification",
                        resizable: false,
                        modal: true,
                        width: 'auto',
                        height: 'auto',
                        buttons: {
                            "Ok": function () {
                                $(calendar).weekCalendar('removeEvent', calEvent.id);
                                $("#divDialogConfirmationMaster").dialog("close");
                            }
                        },
                        close: function () {
                            $calendar.weekCalendar("removeUnsavedEvents");
                            $("#divDialogConfirmationMaster").dialog("destroy");
                        }
                    });

                    return false;
                }

                SaveAppointment(calEvent);
            },
            Cancel: function () {
                $dialogContent.dialog("close");
            }
        }
    }).show();
    
    $dialogContent.find(".date_holder").text($calendar.weekCalendar("formatDate", calEvent.start));
    setupStartAndEndTimeFields(startField, endField, calEvent, $calendar.weekCalendar("getTimeslotTimes", calEvent.start));
    $(window).resize().resize(); //fixes a bug in modal overlay size ??
}

function EventDelete(calEvent, element, dayFreeBusyManager, calendar, clickEvent) {
    $("[id$='txtAppointmentDeletionReason']").val("");

    $("#dialog-confirm-app-delete").dialog({
        resizable: false,
        height: 'auto',
        width: 'auto',
        modal: true,
        buttons: {
            Delete: function () {
                ConfirmDeleteAppointment(calEvent.id);
                $(this).dialog("close");
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        open: function () {
            $("#dialog-confirm-app-delete").prev().find(".ui-icon").remove();
        },
        Cancel: function () {
            $(this).dialog("close");
        },
        close: function () {
            $(this).dialog("destroy");
        }
    }).show();
}

function ConfirmDeleteAppointment(AppointmentsId) {
    var DeleteReason = $.trim($("#txtAppointmentDeletionReason").val());
    
    var params = {
        AppointmentsId: AppointmentsId,
        DeleteReason: DeleteReason,
        action: "Delete"
    };
    
    $.post(_PatientEHRPath + "/Appointments/CallBacks/AppointmentsActionHandler.aspx", params, function () {
        $calendar.weekCalendar('removeEvent', AppointmentsId);
        showSuccessMessage(_msg_Deleted);
    });
}

function SaveAppointment(calEvent) {
    if (!ValidateForm("divAppointmentContainer")) {
        showErrorMessage("");
        return;
    }
    
    calEvent = SetEventObject(calEvent);
    
    SaveAppointmentOnServer(calEvent);
    $dialogContent.dialog("close");
}

function SaveAppointmentOnServer(calEvent) {
    var startTime = new Date(calEvent.start);
    var Time1 = (startTime.getMonth() + 1) + "/" + startTime.getDate() + "/" + startTime.getFullYear() + " " + startTime.getHours() + ':' + startTime.getMinutes() + ':' + startTime.getSeconds();
    
    var endTime = new Date(calEvent.end);
    var Time2 = (endTime.getMonth() + 1) + "/" + endTime.getDate() + "/" + endTime.getFullYear() + " " + endTime.getHours() + ':' + endTime.getMinutes() + ':' + endTime.getSeconds();
    
    calEvent.start = Time1;
    calEvent.end = Time2;
    
    var PracticeLocationsId = $("[id$='ddLocationMain']").val();
    var dateObject = $("[id$='txtAppointmentDateMain']").datepicker('getDate');
    //var AppointmentDate = $.datepicker.formatDate("yy-mm-dd", dateObject);
    
    var AppointmentDate = new Date(calEvent.start).toString("MM/dd/yyyy");
    
    var params = {
        objAdminAppointmentData: JSON.stringify(calEvent),
        AppointmentsId: calEvent.id,
        PracticeLocationsId: PracticeLocationsId,
        AppointmentDate: AppointmentDate,
        action: "Save"
    };

    $.post(_PatientEHRPath + "/Appointments/CallBacks/AppointmentsActionHandler.aspx", params, function (dataAppointment) {
        var isNewAppointment = (calEvent.id == 0);

        /*****Appointment Id*****/
        var start = dataAppointment.indexOf("###StartAppointmentsId###") + 25;
        var end = dataAppointment.indexOf("###EndAppointmentsId###");
        var returnHtmlAppointment = $.trim(dataAppointment.substring(start, end));
        calEvent.id = returnHtmlAppointment;

        /*****Status Back Color*****/
        start = dataAppointment.indexOf("###StartStatusBackColor###") + 26;
        end = dataAppointment.indexOf("###EndStatusBackColor###");
        returnHtmlAppointment = $.trim(dataAppointment.substring(start, end));
        calEvent.status_back_color = returnHtmlAppointment;

        /*****Reason Back Color*****/
        start = dataAppointment.indexOf("###StartReasonBackColor###") + 26;
        end = dataAppointment.indexOf("###EndReasonBackColor###");
        returnHtmlAppointment = $.trim(dataAppointment.substring(start, end));
        calEvent.reason_back_color = returnHtmlAppointment;

        if (isNewAppointment) {
            $calendar.weekCalendar("removeUnsavedEvents");
            showSuccessMessage(_msg_Created);
        }
        else {
            showSuccessMessage(_msg_Updated);
        }

        //$calendar.weekCalendar("updateEvent", calEvent);
        ReloadCalendar();
    });
}

function EventData(start, end, callback) {
    $("#Mydatepicker").datepicker('setDate', start);

    if ($("[id$='ddAppProvider'] option").length != 0) {  //If there are some service providers available at selected location then load appointments.
        var params = {
            app_date: start.toString("yyyy-MM-dd"),
            loc_id: $("[id$='ddLocationMain']").val(),
            prov_id: $.trim($("[id$='ddAppProvider']").val()),
            day: start.getDay(),
            UsersLength: 1,
            PatientId: $("[id$='hdnPatientId']").val()
        };

        $.ajax({
            type: "POST",
            url: "patientCalendar.asmx/LoadAppointments",
            data: JSON.stringify(params),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result, status) {
                SuccessAppointmentLoad(result, status, callback);
            },
            error: function (request, status, error) {
                showErrorMessage(request.statusText);
            }
        });
    }
    else {
        var source;

        source = {
            options: {
                users: _arrUsers
            },
            events: {}
        };

        callback(source);
    }
}

function SuccessAppointmentLoad(result, status, callback) {
    result = result.d;
    
    var events = JSON.parse(result.events);
    var freebusys = JSON.parse(result.freebusys);
    var businessHours = result.businessHours[0];
    var startTime = businessHours.Bussiness_start_Time;
    var endTime = businessHours.Bussiness_end_Time;
    var isOffDay = JSON.parse(result.isOffDay);
    
    _arrUsers.length = 0;
    var ServiceProvider = $.trim($("[id$='ddAppProvider'] option:selected").html());
    _arrUsers.push(ServiceProvider);
    
    $(".wc-user-header").html(ServiceProvider);
    
    var source;
    
    if (isOffDay) {
        source = {
            options: {
                users: _arrUsers
            },
            events: events
        };
    }
    else {
        source = {
            options: {
                users: _arrUsers
            },
            events: events,
            freebusys: freebusys
        };
    }
    
    callback(source);
}

function SetAppointmentForm(calEvent) {
    if (calEvent.id == 0) {
        $("#taNotes").val("");
        //$("#divNotes").css("display", "none");
    }

    if ($("[id$='ddDialogAppProvider'] option").length == 0) {
        $dialogContent.find("[id$='ddDialogAppProvider']").addClass("error");
        showErrorMessage("It looks like there is no service provider available at this locaion!");
        return false;
    }

    var startField = $dialogContent.find("select[name='start']").val(calEvent.start);
    var endField = $dialogContent.find("select[name='end']").val(calEvent.end);

    $dialogContent.find(".date_holder").text($calendar.weekCalendar("formatDate", calEvent.start));
    setupStartAndEndTimeFields(startField, endField, calEvent, $calendar.weekCalendar("getTimeslotTimes", calEvent.start));
    
    $dialogContent.find("select[name='status']").val(calEvent.statusId);
}

function resetForm($dialogContent) {
    $("#ddDialogAppProvider").val($("[id$='ddAppProvider']").val());
    $("[id$='ddReason']").val(0);
    $dialogContent.find("input:text").not("[id$='txtDialogPatiantName']").val("");
    $dialogContent.find("textarea").val("");
    $("#divNotes").css("display", "none");
}

function SetEventObject(calEvent) {
    var startTime = new Date($dialogContent.find("select[name='start']").val());
    var endTime = new Date($dialogContent.find("select[name='end']").val());
    
    calEvent.PatientId = $.trim($("[id$='hdnPatientId']").val());
    calEvent.PatientName = $.trim($dialogContent.find("input[name='patiantName']").val());
    calEvent.start = startTime;
    calEvent.end = endTime;
    calEvent.title = "";
    calEvent.titleId = "";
    calEvent.providerId = $.trim($dialogContent.find("[id$='ddDialogAppProvider']").val());
    calEvent.reasonId = $.trim($dialogContent.find("[id$='ddReason']").val());
    calEvent.statusId = $.trim($dialogContent.find("[id$='ddAppStatus']").val());
    calEvent.status = $.trim($dialogContent.find("[id$='ddAppStatus'] :selected").text());
    calEvent.Notes = $.trim($dialogContent.find("#taNotes").val());
    
    return calEvent;
}

/*
* Sets up the start and end time fields in the calendar event
* form for editing based on the calendar event being edited
*/
function setupStartAndEndTimeFields($startTimeField, $endTimeField, calEvent, timeslotTimes) {

    $startTimeField.empty();
    $endTimeField.empty();

    for (var i = 0; i < timeslotTimes.length; i++) {
        var startTime = timeslotTimes[i].start;
        var endTime = timeslotTimes[i].end;
        var startSelected = "";
        if (startTime.getTime() === calEvent.start.getTime()) {
            startSelected = "selected=\"selected\"";
        }
        var endSelected = "";
        if (endTime.getTime() === calEvent.end.getTime()) {
            endSelected = "selected=\"selected\"";
        }
        $startTimeField.append("<option value=\"" + startTime + "\" " + startSelected + ">" + timeslotTimes[i].startFormatted + "</option>");
        $endTimeField.append("<option value=\"" + endTime + "\" " + endSelected + ">" + timeslotTimes[i].endFormatted + "</option>");

        $timestampsOfOptions.start[timeslotTimes[i].startFormatted] = startTime.getTime();
        $timestampsOfOptions.end[timeslotTimes[i].endFormatted] = endTime.getTime();

    }
    $endTimeOptions = $endTimeField.find("option");
    $startTimeField.trigger("change");
}

function reasonChange() {
    return;
    if ($("[id$='ddReason'] :selected").text() == "Other") {
        $("#taNotes").val("").addClass("required");
        $("#divNotes").show("slide", { direction: "up" }, 1000);
    }
    else if ($("divNotes").css("display") != "none") {
        $("#taNotes").removeClass("required");
        $("#taNotes").removeClass("error");
        $("#divNotes").hide("slide", { direction: "up" }, 1000);
    }
}

function AppointmentStatusChanged(elem) {
    $(elem).closest(".custom-dropdown-list").animate({ height: 'toggle' });
    $(".status-dropdown-icon").removeClass("status-dropdown-icon-open").addClass("status-dropdown-icon-close");
}

function ShowHideAppointmentStatusDropDown(elem, event) {
    event.stopPropagation();
    $(elem).parent().find(".custom-dropdown-list").animate({ height: 'toggle' });

    var statusIcon = $(elem).find(".status-dropdown-icon");
    ChangeStatusIcon(statusIcon);
}

function ChangeStatusIcon(elem) {
    if ($(elem).hasClass("status-dropdown-icon-open")) {
        $(elem).removeClass("status-dropdown-icon-open").addClass("status-dropdown-icon-close");
    }
    else if ($(elem).hasClass("status-dropdown-icon-close")) {
        $(elem).removeClass("status-dropdown-icon-close").addClass("status-dropdown-icon-open");
    }
}

function ShowHidePatientInfoDropDown(elem, event) {
    event.stopPropagation();
    $(elem).parent().find(".custom-dropdown-list").animate({ height: 'toggle' });
}



var _PatientName;

function removePatientFromCheckedInList(AppointmentId) {
    $("#tblCheckedInPatients").find("#" + AppointmentId).remove();
}

function UpdateAppointmentTime(AppointmentsId, EndTime) {
    
    $.ajax({
        type: "POST",
        url: "adminCalendar.asmx/UpdateAppointmentTime",
        data: JSON.stringify({ AppointmentsId: AppointmentsId, EndTime: EndTime }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {
            data = data.d;
            showSuccessMessage(_msg_Updated);
        },
        error: function (request, status, error) {
            showErrorMessage(request.statusText);
        }
    });
}


var _calEvent;

function updateAppointmentStatus(AppointmentId, StatusId, event, elem, isExpireTime, isFutureEvent, patientId) {
    event.stopPropagation();

    var appStatus = $.trim($(elem).find("span").html());
    var appCurrentStatus = $.trim($(elem).closest("table").parent().parent().find(".status-label").html());

    if (appStatus == appCurrentStatus) {
        AppointmentStatusChanged(elem);
        return false;
    }

    var CheckInRoomId = 0;

    if ($.trim(StatusId) == "4") {
        GetCheckinRoomsDialog(AppointmentId, elem, isExpireTime);
    }
    else {

        if ($.trim(StatusId) == "5") {
            if (isFutureEvent) {
                callDialog("<p>Future appointment may not be updated with status 'Completed'.</p>", "Information");
                AppointmentStatusChanged(elem);
                return false;
            }

            AppointmentUpdateStatus(AppointmentId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime);
        }
        else {
            AppointmentUpdateStatus(AppointmentId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime);
        }
    }
}

function AppointmentUpdateStatus(AppointmentsId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime) {

    //var PracticeLocationsId = $("[id$='ddLocationMain']").val();
    //var ServiceProviderId = $("[id$='ddAppProvider']").val();

    var PracticeLocationsId = 0;
    var ServiceProviderId = 0;

    $.post(_EMRPath + "/Appointments/CallBacks/AppointmentUpdateStatus.aspx", { AppointmentsId: AppointmentsId, CheckInRoomId: CheckInRoomId, StatusId: StatusId, PracticeLocationsId: PracticeLocationsId, ServiceProviderId: ServiceProviderId }, function (dataCheckIn) {

        var startCheckIn = dataCheckIn.indexOf("###Start###") + 11;
        var endCheckIn = dataCheckIn.indexOf("###End###");
        var returnHtmlCheckIn = $.trim(dataCheckIn.substring(startCheckIn, endCheckIn));

        $("#tblCheckedInPatients").html(returnHtmlCheckIn);

        if ($("#tblCheckedInPatients tr.tr-checkedin-Patients-main").not(".trNoRecord").length > 0) {
            window.setInterval(function () {
                SetWaitingTime();
            }, 30000);
        }
        else {
            $(".trNoRecord").show();
        }
        if (elem != "") {

            var startStatusColor = dataCheckIn.indexOf("###StartStatusColor###") + 22;
            var endStatusColor = dataCheckIn.indexOf("###EndStatusColor###");
            var StatusColor = $.trim(dataCheckIn.substring(startStatusColor, endStatusColor));

            if (!isExpireTime) {
                $(elem).closest("div").parent().parent().parent().parent().find(".wc-time").css("background-color", StatusColor);
            }

            $(elem).closest("table").parent().parent().find(".status-label").html(appStatus);
            $(elem).closest("table").parent().parent().find(".hdnStatusId").val(StatusId);
            $(elem).closest("table").parent().parent().find(".hdnCheckInRoomId").val(CheckInRoomId);
            AppointmentStatusChanged(elem);
        }

        showSuccessMessage(_msg_Updated);
    });
}

function GetCheckinRoomsDialog(AppointmentId, elem, isExpireTime) {

    var _locationId = $("[id$='ddLocationMain'] :selected").val();
    $.post(_ControlPath + "/CashRegister.aspx", { AppointmentId: AppointmentId, LocationId: _locationId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###CashRegisterStart###") + 23;
        var end = data.indexOf("###CashRegisterEnd###");
        $("#divCashRegister").html(returnHtml.substring(start, end));
        $("#divCashRegister").dialog({
            width: 850,
            modal: true,
            buttons: {
                'Save and Print': function () {
                    SaveCashRegister(true, elem, isExpireTime);
                    $(this).dialog("close");
                },
                'Save': function () {
                    SaveCashRegister(false, elem, isExpireTime);
                    $(this).dialog("close");
                },
                'Check Eligibility': function () {

                    CheckPatientEligibility($("#hdnCashRegisterPatientId").val(), $.trim($("[id$='lblAppointmentDate']").html()));
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        });
    });

    //    $.post(_ControlPath + "/CheckinRoomsHandler.aspx", { LocationId: _locationId }, function (data) {

    //        var start = data.indexOf("###StartCheckInroom###") + 22;
    //        var end = data.indexOf("###EndCheckInroom###");

    //        var returnHtml = $.trim(data.substring(start, end));

    //        $("#divDialogPracticeRooms").html(returnHtml);

    //        $("#divDialogPracticeRooms").dialog({
    //            title: "CheckedIn Rooms",
    //            width: 850,
    //            modal: true,
    //            buttons: {
    //                'Select': function () {
    //                    if ($("#gridContentsPracticeRooms .trSelected").length == 0) {
    //                        showErrorMessage("Please select a room!");
    //                        return false;
    //                    }
    //                    
    //                    CheckInRoomId = $.trim($("#gridContentsPracticeRooms .trSelected").attr("id"));
    //                    _calEvent.CheckInRoomId = CheckInRoomId;
    //                    
    //                    AppointmentUpdateStatus(AppointmentId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime);
    //                    
    //                    $(this).dialog("close");
    //                    return false;
    //                },
    //                Cancel: function () {
    //                    $(this).dialog("close");
    //                }
    //            },
    //            close: function () {
    //                $(this).dialog("destroy");
    //            }
    //        });
    //    });
}



function OpenPatientChart(event, AppointmentsId, PatientId) {
    event.stopPropagation();
    window.location = _EMRPath + "/Patient/Demographics.aspx?PatientId=" + PatientId + "&AppointmentsId=" + AppointmentsId + "&InfoType=LatestChart";
}

function PrintAppointmentReminder(patientId, appId) {
    event.stopPropagation();
    window.location = _ReportsPath + "/AppointmentReminder.aspx?PatientId=" + patientId + "&AppointmentsId=" + appId;
}
function GetProviderAppointmentTypes() {
    $.post(_ControlPath + "/GetProviderAppointmentTypesHandler.aspx", { providerId: $("[id$='ddDialogAppProvider']").val() }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $(".divprovidertype").html($.trim(data.substring(start, end)));
    });
}

//function changeAppointmentStatus(elem) {
//    var StatusId = $(elem).val();
//    
//    if (StatusId == "4") {

//        var LocationId = $("[id$='ddLocationMain'] :selected").val();
//        $.post(_ControlPath + "/CashRegister.aspx", { AppointmentId: _appointmentId, LocationId: LocationId }, function (data) {
//            var returnHtml = data;
//            var start = data.indexOf("###CashRegisterStart###") + 23;
//            var end = data.indexOf("###CashRegisterEnd###");
//            $("#divCashRegister").html(returnHtml.substring(start, end));
//            $("#divCashRegister").dialog({
//                width: 850,
//                modal: true,
//                buttons: {
//                    'Save and Print': function () {
//                        SaveCashRegister(true, elem, false);
//                    },
//                    'Save': function () {
//                        SaveCashRegister(false, elem, false);
//                    },
//                    Cancel: function () {
//                        $(this).dialog("close");
//                    }
//                }
//            });
//        });
//        
////        $.post(_ControlPath + "/CheckinRoomsHandler.aspx", { LocationId: LocationId }, function (data) {
////            
////            var startCheckInroom = data.indexOf("###StartCheckInroom###") + 22;
////            var endCheckInroom = data.indexOf("###EndCheckInroom###");

////            var returnHtmlCheckInroom = $.trim(data.substring(startCheckInroom, endCheckInroom));

////            $("#divDialogPracticeRooms").html(returnHtmlCheckInroom);

////            $("#divDialogPracticeRooms").dialog({
////                title: "CheckedIn Rooms",
////                width: 850,
////                modal: true,
////                buttons: {
////                    'Select': function () {
////                        if ($("#gridContentsPracticeRooms .trSelected").length == 0) {
////                            showErrorMessage("Please select a room!");
////                            return false;
////                        }

////                        var CheckInRoomId = $.trim($("#gridContentsPracticeRooms .trSelected").attr("id"));

////                        $("[id$='hdnCheckInRoomId']").val(CheckInRoomId);

////                        $(this).dialog("close");
////                    },
////                    Cancel: function () {
////                        $(this).dialog("close");
////                    }
////                },
////                close: function () {
////                    $(this).dialog("destroy");
////                }
////            });
////        });
//    }
//    else {
//        $("[id$='hdnCheckInRoomId']").val(0);
//    }
//}

function GetLatestCheckedInPatientList() {

    //var PracticeLocationsId = $("[id$='ddLocationMain']").val();
    //var ServiceProviderId = $("[id$='ddAppProvider']").val();

    var PracticeLocationsId = 0;
    var ServiceProviderId = 0;

    $.post(_EMRPath + "/Appointments/CheckedInPatientHandler.aspx", { PracticeLocationsId: PracticeLocationsId, ServiceProviderId: ServiceProviderId }, function (dataCheckIn) {

        var startCheckIn = dataCheckIn.indexOf("###Start###") + 11;
        var endCheckIn = dataCheckIn.indexOf("###End###");
        var returnHtmlCheckIn = $.trim(dataCheckIn.substring(startCheckIn, endCheckIn));

        $("#tblCheckedInPatients").html(returnHtmlCheckIn);

        if ($("#tblCheckedInPatients tr.tr-checkedin-Patients-main").not(".trNoRecord").length > 0) {
            window.setInterval(function () {
                SetWaitingTime();
            }, 30000);
        }
        else {
            $(".trNoRecord").show();
        }
    });
}

function SaveCashRegister(isPrint, elem, isExpireTime) {
    var patientId = $("[id$='hdnCashRegisterPatientId']").val();
    var CashRegister = new Object();
    CashRegister.CashRegisterId = $.trim($("[id$='hdnCashRegisterId']").val());
    CashRegister.PatientId = patientId;
    CashRegister.AppointmentId = $("[id$='hdnAppointmentId']").val();

    CashRegister.PreviousBalance = $("[id$='txtPreviousBalance']").val() == "" ? 0 : $("[id$='txtPreviousBalance']").val();
    CashRegister.PreviousBalancePayment = $("[id$='txtPaidAmount1']").val() == "" ? 0 : $("[id$='txtPaidAmount1']").val();
    CashRegister.PreviousBalancePaymentMethod = $("[id$='ddlPaymentMethod1']").val();
    CashRegister.PreviousBalanceRefNumber = $("[id$='txtReference1']").val();
    CashRegister.PreviousBalanceNotes = $("[id$='txtNotes1']").val();

    CashRegister.CoPayDue = $("[id$='lblCopayDue']").text() == "" ? 0 : $("[id$='lblCopayDue']").text();
    CashRegister.CoPayment = $("[id$='txtPaidAmount2']").val() == "" ? 0 : $("[id$='txtPaidAmount2']").val();
    CashRegister.CoPaymentMethod = $("[id$='ddlPaymentMethod2']").val();
    CashRegister.CoPaymentRefNumber = $("[id$='txtReference2']").val();
    CashRegister.CoPaymentNotes = $("[id$='txtNotes2']").val();

    CashRegister.VisitCharges = $("[id$='txtVisitCharges']").val() == "" ? 0 : $("[id$='txtVisitCharges']").val();
    CashRegister.VisitPayment = $("[id$='txtPaidAmount3']").val() == "" ? 0 : $("[id$='txtPaidAmount3']").val();
    CashRegister.VisitPaymentMethod = $("[id$='ddlPaymentMethod3']").val();
    CashRegister.VisitRefNumber = $("[id$='txtReference3']").val();
    CashRegister.VisitNotes = $("[id$='txtNotes3']").val();

    CashRegister.OtherCharges = $("[id$='txtOtherCharges']").val() == "" ? 0 : $("[id$='txtOtherCharges']").val();
    CashRegister.OtherPayment = $("[id$='txtPaidAmount4']").val() == "" ? 0 : $("[id$='txtPaidAmount4']").val();
    CashRegister.OtherPaymentMethod = $("[id$='ddlPaymentMethod4']").val();
    CashRegister.OtherRefNumber = $("[id$='txtReference4']").val();
    CashRegister.OtherNotes = $("[id$='txtNotes4']").val();

    CashRegister.TotalPayments = $("#lblTotalPayment").text();
    CashRegister.TotalCharges = $("#lblTotalCharges").text();
    CashRegister.WriteOffAmount = $("[id$='txtWriteOffAmount']").val() == "" ? 0 : $("[id$='txtWriteOffAmount']").val();

    $.post(_ControlPath + "/CallBacks/CashRegisterSave.aspx", { CashRegister: JSON.stringify(CashRegister), Print: isPrint, RoomId: $("#ddlCheckInRoom").val(), StatusId: 4 }, function (data) {
        var startCheckInPatient = data.indexOf("###Start###") + 11;
        var endCheckInPatient = data.indexOf("###End###");
        $("#tblCheckedInPatients").html(data.substring(startCheckInPatient, endCheckInPatient));
        SetWaitingTime();
        if ($("#tblCheckedInPatients tr.tr-checkedin-Patients-main").not(".trNoRecord").length > 0) {
            window.setInterval(function () {
                SetWaitingTime();
            }, 30000);
        }
        else {
            $(".trNoRecord").show();
        }
        if (elem != "") {

            var startStatusColor = data.indexOf("###StartStatusColor###") + 22;
            var endStatusColor = data.indexOf("###EndStatusColor###");
            var StatusColor = $.trim(data.substring(startStatusColor, endStatusColor));

            if (!isExpireTime) {
                $(elem).closest("div").parent().parent().parent().parent().find(".wc-time").css("background-color", StatusColor);
            }
            $(elem).closest("table").parent().parent().find(".status-label").html('Checked-In');
            $(elem).closest("table").parent().parent().find(".hdnStatusId").val('4');
            $(elem).closest("table").parent().parent().find(".hdnCheckInRoomId").val($("#ddlCheckInRoom").val());
            AppointmentStatusChanged(elem);
        }

        $("#divCashRegister").dialog("close")
        showSuccessMessage(_msg_Updated);
        if (isPrint) {
            window.location = _ReportsPath + "/CashReceipt.aspx?PatientId=" + patientId + "&AppointmentsId=" + CashRegister.AppointmentId;
        }

    });
}

function CalculateTotalCharges() {

    var previousBalance = $("[id$='txtPreviousBalance']").val() == "" ? 0 : $("[id$='txtPreviousBalance']").val();
    var copayDue = $("[id$='lblCopayDue']").text() == "" ? 0 : $("[id$='lblCopayDue']").text();
    var visitCharges = $("[id$='txtVisitCharges']").val() == "" ? 0 : $("[id$='txtVisitCharges']").val();
    var otherCharges = $("[id$='txtOtherCharges']").val() == "" ? 0 : $("[id$='txtOtherCharges']").val();
    var advancePayment = $.trim($("[id$='lblAdvancePayment']").html()) == "" ? 0 : $.trim($("[id$='lblAdvancePayment']").html());

    $("[id$='lblTotalCharges']").text(parseInt(previousBalance) + parseInt(copayDue) + parseInt(visitCharges) + parseInt(otherCharges));

    var totalPayment = parseInt($("#lblTotalPayment").text() == "" ? 0 : $("[id$='lblTotalPayment']").text());
    var totalCharges = parseInt($("#lblTotalCharges").text() == "" ? 0 : $("[id$='lblTotalCharges']").text());

    $("[id$='lblBalanceDue']").text((totalCharges - totalPayment) - advancePayment);

}

function CalculateTotalPayments() {

    var previousBalancePaid = $("[id$='txtPaidAmount1']").val() == "" ? 0 : $("[id$='txtPaidAmount1']").val();
    var copayDuePaid = $("[id$='txtPaidAmount2']").val() == "" ? 0 : $("[id$='txtPaidAmount2']").val();
    var visitChargesPaid = $("[id$='txtPaidAmount3']").val() == "" ? 0 : $("[id$='txtPaidAmount3']").val();
    var otherChargesPaid = $("[id$='txtPaidAmount4']").val() == "" ? 0 : $("[id$='txtPaidAmount4']").val();
    var writeOffAmount = $("[id$='txtWriteOffAmount']").val() == "" ? 0 : $("[id$='txtWriteOffAmount']").val();
    var advancePayment = $.trim($("[id$='lblAdvancePayment']").html()) == "" ? 0 : $.trim($("[id$='lblAdvancePayment']").html());

    $("[id$='lblTotalPayment']").text(parseInt(previousBalancePaid) + parseInt(copayDuePaid) + parseInt(visitChargesPaid) + parseInt(otherChargesPaid));

    var totalPayment = parseInt($("#lblTotalPayment").text() == "" ? 0 : $("[id$='lblTotalPayment']").text());
    var totalCharges = parseInt($("#lblTotalCharges").text() == "" ? 0 : $("[id$='lblTotalCharges']").text());

    $("[id$='lblBalanceDue']").text((totalCharges - (totalPayment + +parseInt(writeOffAmount))) - advancePayment);

}

function getHippaForm() {
    var PatientId = $("[id$='hdnCashRegisterPatientId']").val();
    $.post(_ControlPath + "/HippaPrivacyAuthorizationForm.aspx", { PatientId: PatientId, location: $("[id$='ddLocationMain']").val() }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divHIPAAAuthorizationForm").html($.trim(data.substring(start, end)));
        $("#divHIPAAAuthorizationForm").dialog({
            width: 850,
            modal: true,
            close: function () {
                $(this).dialog("destroy");
            }
        })
    });
}
function CheckPatientEligibility(PatientId, EligibilityStartDate) {
    if ($("[id$='hdnEpisodeId']").val() == "0") {
        showErrorMessage("Please provide episode general information first.");
        return false;
    }

    var PatientId = PatientId;
    var IsFromPersonal = false;
    var EligibilityStartDate = EligibilityStartDate;
    var FirstName = "";
    var LastName = "";
    var DateOfBirth = "";
    var PolicyNumber = "";
    var InsuranceId = "0";
    var EpisodeId = $("[id$='hdnEpisodeId']").val();

    $.post(_ControlPath + "/CheckPatientEligibility.aspx", { PatientId: PatientId, DateOfBirth: DateOfBirth, EligibilityStartDate: EligibilityStartDate,
        IsFromPersonal: IsFromPersonal, FirstName: FirstName, LastName: LastName, InsuranceId: InsuranceId, PolicyNumber: PolicyNumber,
        IsHome: true
    },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###EligibilityResponseStart###") + 30;
        var end = data.indexOf("###EligibilityResponseEnd###");
        $("#EligibilityResponse").html(returnHtml.substring(start, end));

        var startEligibility = data.indexOf("###EpisodeEligibilityStart###") + 29;
        var endEligibility = data.indexOf("###EpisodeEligibilityEnd###");
        $("[id$='divEligibilityDetail'] .widget-content").html(returnHtml.substring(startEligibility, endEligibility));

        $("[id$='divEligibilityDetail']").show();

        $("#EligibilityResponse").dialog({
            width: 950,
            height: 'auto',
            modal: true,
            title: 'Eligibility Response',
            buttons: {
                "Ok": function () {
                    $(this).dialog("close");
                }
            }
        });
    });
}