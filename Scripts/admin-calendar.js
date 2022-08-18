
/// <reference path="Common.js" />

/*Start Right Click Global Variables*/
var _calEventRightClick, _$eventRightClick, _FreeBusyManagerRightClick, _calendarRightClick, _selfRightClick, _optionsRightClick, _$weekDayRightClick, _eventRightClick, _createdFromSingleClickRightClick;
var _calEventCopyPaste, _targetCoypaste;
/*End Right Click Global Variables*/

var $calendar, $dialogContent, $endTimeField, $endTimeOptions, $timestampsOfOptions, _appointmentId;

var _IsEventDragging = false;
var _arrLocationStateUTC;
var AppointmentIdCopied = 0;
var _PracticeLocationDateUTC;
var _PracticeLocationCurrentTimeUTC;
var $TragetPaste;
var _PracticeStaffIds = "";
var _arrUsers = new Array();

$(document).on("keyup", "body", function (e) {
    if (e.keyCode == 27) {
        $(".custom-dropdown-list").hide();
        
        if ($(".status-dropdown-icon").hasClass("ui-icon-circle-triangle-s")) {
            $(".status-dropdown-icon").removeClass("ui-icon-circle-triangle-s").addClass("ui-icon-circle-triangle-e");
        }
    }
});

function onmouseLeaveStatusDDL() {
    $(".custom-dropdown-list").hide();
    
    if ($(".status-dropdown-icon").hasClass("ui-icon-circle-triangle-s")) {
        $(".status-dropdown-icon").removeClass("ui-icon-circle-triangle-s").addClass("ui-icon-circle-triangle-e");
    }
}

$(document).bind("contextmenu", function (event) {
    if ($(event.target).attr("id") == "divContextMenuAppointments") {
        return false;
    }
});

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
//rizwan
function SetPracticeLocationDateTimeUTC() {
    debugger;
    var PracticeLocationsId = $("[id$='ddLocationMain']").val();
    var UTCOffset = _arrLocationStateUTC[PracticeLocationsId];
   // var UTCOffset = PracticeLocationsId;
    _PracticeLocationDateUTC = GetDateByLocationUTC(UTCOffset, "Date");
    
    _PracticeLocationCurrentTimeUTC = GetDateByLocationUTC(UTCOffset, "Time");
}

function LoadAppointmentCalendar() {
    debugger;
    SetPracticeLocationDateTimeUTC();
    SetSelectedServiceProviders();
    loadCalendar();
}

function RefreshAppointmentCalendar() {
    debugger
    SetPracticeLocationDateTimeUTC();
    SetSelectedServiceProviders();
    ReloadCalendar();
}

function ReloadCalendar() {
    $calendar.weekCalendar('refresh');
}

function locationChanged() {
    debugger;
    var PracticeLocationId = $("[id$='ddLocationMain']").val();
    
    $.post("../../ProviderPortal/Controls/ProvidersByLocation.aspx", { PracticeLocationId: PracticeLocationId }, function (data) {
        var start = data.indexOf("###StartProviderDropdown###") + 27;
        var end = data.indexOf("###EndProviderDropdown###");
        var ProviderDropdown = $.trim(data.substring(start, end));
        
        $("[id$='ddDialogAppProvider']").html(ProviderDropdown)
        .promise()
        .done(function () {
            if ($("[id$='ddDialogAppProvider'] option").length > 0) {
                $("[id$='ddDialogAppProvider']").val(0);
            }
        });
        
        start = data.indexOf("###StartProvidersList###") + 24;
        end = data.indexOf("###EndProvidersList###");
        var ProvidersList = $.trim(data.substring(start, end));
        
        $("[id$='divServiceProvidersDropDown'] .div-drop-down")
        .html(ProvidersList)
        .promise()
        .done(function () {
            RefreshAppointmentCalendar();
        });
        
        start = data.indexOf("###StartPracticeRooms###") + 24;
        end = data.indexOf("###EndPracticeRooms###");
        var PracticeRooms = $.trim(data.substring(start, end));
        
        $("[id$='ddlPracticeRooms']").replaceWith(PracticeRooms);
    });

    return true;
}
//rizwan
function loadCalendar() {
    debugger;
    $calendar.weekCalendar({
        date: _PracticeLocationDateUTC,
        displayOddEven: true,
        timeslotsPerHour: 4,
        timeslotHeight: 32,
        allowCalEventOverlap: true,
        allowEventDelete: true,
        overlapEventsSeparate: true,
        displayFreeBusys: true,
        firstDayOfWeek: 1,
        defaultFreeBusy: { free: false },
        businessHours: { start: 0, end: 24, limitDisplay: false },
        daysToShow: 1,
        //hourLine: true,
        //defaultEventLength: 2,
        //switchDisplay: { '1 day': 1, '3 next days': 3, 'work week': 5, 'full week': 7 },
        switchDisplay: { '1 day': 1, 'full week': 7 },
        title: function (daysToShow) {
            return daysToShow == 1 ? '%date%' : '%start% - %end%';
        },
        height: function ($calendar) {
            return $(document).height() - $("#calendar").offset().top - 25;
        },
        users: [],
        eventRender: function (calEvent, $event) {
            if (calEvent.end.getTime() < new Date().getTime()) {
                $event.css("backgroundColor", "#aaa");

                $event.find(".wc-time").css({
                    "backgroundColor": calEvent.status_back_color,
                    "border": "1px solid #888"
                });

                $event.css({
                    "backgroundColor": calEvent.reason_back_color,
                    "border": "1px solid #888"
                });
            }
            else {
                $event.find(".wc-time").css({
                    "backgroundColor": calEvent.status_back_color,
                    "border": "1px solid #888"
                });

                $event.css({
                    "backgroundColor": calEvent.reason_back_color,
                    "border": "1px solid #888"
                });
            }
        },
        draggable: function (calEvent, $event) {
            return true;
        },
        resizable: function (calEvent, $event) {
            return false;
        },
        eventDrop: EventDropped,
        eventResize: function (calEvent, $event) { },
        eventMouseover: function (calEvent, $event) { },
        eventMouseout: function (calEvent, $event) { },
        noEvents: function () { },
        eventNew: EventNew,
        eventClick: EventExisting,
        eventDelete: EventDelete,
        data: EventData
    });
}

function GetUsersLength() {
    return $(".cbServiceProviders:checked").length;
}

function EventDropped(newCalEvent, calEvent, $calEvent) {
    debugger;
    var objAppointmentEvent = calEvent;
    
    //if (!confirm("Are you sure to update appointment?")) {
    //    debugger
    //    $calendar.weekCalendar("removeEvent", newCalEvent.id);
    //    $calendar.weekCalendar("updateEvent", objAppointmentEvent);
    //    return false;
    //}
    
    //var NewUserId = newCalEvent.userId;
    //var NewServiceProviderId = $($("[id$='divServiceProvidersDropDown'] .hdnPracticeStaffId")[NewUserId]).val();
    //newCalEvent.providerId = NewServiceProviderId;
    
    //SaveAppointmentOnServer(newCalEvent);
    
    //return true;


    var notificationMessage = "Are you sure to update appointment?";

    $("#divDialogConfirmationMaster").html(notificationMessage).dialog({
        title: "Notification",
        resizable: false,
        modal: true,
        width: 'auto',
        height: 'auto',
        buttons: {
            "Yes": function () {
                var NewUserId = newCalEvent.userId;
                var NewServiceProviderId = $($("[id$='divServiceProvidersDropDown'] .hdnPracticeStaffId")[NewUserId]).val();
                newCalEvent.providerId = NewServiceProviderId;

                SaveAppointmentOnServer(newCalEvent);

              
                $("#divDialogConfirmationMaster").dialog("close");
                return true;
            },
            "No": function () {
               
                debugger
                $calendar.weekCalendar("removeEvent", newCalEvent.id);
                $calendar.weekCalendar("updateEvent", objAppointmentEvent);
                $("#divDialogConfirmationMaster").dialog("close");
                return false;
            
            }
        },
        close: function () {
            //if (!isEventCreate) {
                $calendar.weekCalendar("removeUnsavedEvents");
            //}

            $(this).dialog("destroy");
        }
    });





}

function EventNew(calEvent, $event, FreeBusyManager, calendar) {
    debugger;
    if (!checkModuleRights("AppointmentsAdd")) {
        showErrorMessage(_msg_AppointmentsAdd);
        $calendar.weekCalendar('removeEvent', calEvent.id);
        return false;
    }
    
    if ($("[id$='ddDialogAppProvider'] option").length == 0) {
        dialogShowMessage("Sorry! seems to have no provider at this location.", "Notification");
        $calendar.weekCalendar('removeEvent', calEvent.id);
        return false;
    }

    $("[id$='divAppointmentContainer'] #iconsDiv").show();
    
    if (window.event.which == 3) {
        _calEventRightClick = calEvent;
        _$eventRightClick = $event;
        _FreeBusyManagerRightClick = FreeBusyManager;
        _calendarRightClick = calendar;
        
        return false;
    }

    calEvent.id = 0;
    var isEventCreate = false;
    var isFree = true;
    
    if (calEvent.end.getTime() < _PracticeLocationCurrentTimeUTC) {
        isFree = false;
    }
    
    $.each(FreeBusyManager.getFreeBusys(calEvent.start, calEvent.end), function (i, e) {
        if (this.getStart().getTime() != calEvent.end.getTime() && this.getEnd().getTime() != calEvent.start.getTime() && !this.getOption('free')) {
            isFree = false;
        }
    });
    
    if (!isFree) {
        var notificationMessage = "You are about to create appointment in Expire/Break time!<br />Are you sure you really want to?";
        
        $("#divDialogConfirmationMaster").html(notificationMessage).dialog({
            title: "Notification",
            resizable: false,
            modal: true,
            width: 'auto',
            height: 'auto',
            buttons: {
                "Yes": function () {
                    isEventCreate = true;
                    $("#divDialogConfirmationMaster").dialog("close");
                    debugger;
                    CreateEvent(calEvent);
                },
                "No": function () {
                    $("#divDialogConfirmationMaster").dialog("close");
                    $calendar.weekCalendar('removeEvent', calEvent.id);
                }
            },
            close: function () {
                debugger
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

var _isEventCreateButtonClick = false;

function CreateEvent(calEvent) {
    debugger;
    SetAppointmentFormBeforeOpen(calEvent);
    
    $dialogContent.dialog({
        modal: true,
        title: "New Appointment",
        draggable: true,
        width: "auto",
        buttons: {
            Create: function () {
                //_isEventCreateButtonClick = true;
                SaveAppointment(calEvent);
            },
            Cancel: function () {
                $dialogContent.dialog("close");

                $calendar.weekCalendar('removeEvent', calEvent.id);
            }
        },
        close: function () {
            $("[id$='ddAppStatus']").val("");
            
            if (!_isEventCreateButtonClick) {
                $calendar.weekCalendar("removeUnsavedEvents");
            }
            
            $dialogContent.dialog("destroy");
        }
    }).show();
}

//jump
function EventExisting(calEvent, $event, FreeBusyManager, calendar, event) {
    debugger;
    if (_IsEventDragging) {
        _IsEventDragging = false;
        return;
    }
    
    if (!checkModuleRights("AppointmentsEdit")) {
        showErrorMessage(_msg_AppointmentsEdit);
        return;
    }
    
    if ($("[id$='ddDialogAppProvider'] option").length == 0) {
        dialogShowMessage("Sorry! seems to have no provider at this location.", "Notification");
        return false;
    }
    
    if ((window.event.which == 3)) {
        var self = this;
        _calEventRightClick = calEvent;
        _calendarRightClick = calendar;
        _selfRightClick = self;
        _optionsRightClick = options;
        _$weekDayRightClick = $weekDay;
        _eventRightClick = event;
        _createdFromSingleClickRightClick = createdFromSingleClick;

        return false;
    }

    SetAppointmentFormBeforeOpen(calEvent);
    
    $("[id$='hdnPatientId']").val(calEvent.PatientId);
    $dialogContent.find(".spnPatientName").html(calEvent.PatientName);
    $("[id$='ddDialogAppProvider']").val(calEvent.providerId);
    $("[id$='ddReason']").val(calEvent.reasonId);
    
    var startField = $dialogContent.find("select[name='start']").val(calEvent.start);
     var endField = $dialogContent.find("select[name='end']").val(calEvent.end);
    //var endField=""
    var AppointmentCurrentStatusId = calEvent.statusId;

    $("[id$='ddAppStatus']").val(AppointmentCurrentStatusId);
    
    $("#taNotes").val(calEvent.Notes);
    
    if ($("[id$='ddReason'] :selected").text() == "Other") {
        //$("#divNotes").css("display", "");
    }

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

                var isFreeSlot = true;

                var allEvents = $calendar.weekCalendar("serializeEvents");

                for (var i = 0; i < allEvents.length; i++) {
                    if ((calEvent.id != allEvents[i].id) && (calEvent.userId == allEvents[i].userId)) {
                        if (startTime.getTime() == allEvents[i].start.getTime() || ((startTime.getTime() > allEvents[i].start.getTime()) && (startTime.getTime() < allEvents[i].end.getTime()))) {
                            isFreeSlot = false;
                        }
                    }
                }

                calEvent.OldStatusId = calEvent.statusId;
                calEvent.statusId = $("[id$='ddAppStatus'] :selected").val();

                if (calEvent.statusId == 5 && IsFutureDate(calEvent.start)) {
                    dialogShowMessage("<p>Future appointment may not be updated with status 'Completed'.</p>", "Information");
                    return false;
                }

                //$dialogContent.dialog("close");
                debugger;
                SaveAppointment(calEvent);
            },
            Cancel: function () {
                $dialogContent.dialog("close");
            }
        }
    }).show();
    
    debugger;
   
    $dialogContent.find(".date_holder").text($calendar.weekCalendar("formatDate", calEvent.start));
    setupStartAndEndTimeFields(startField, endField, calEvent, $calendar.weekCalendar("getTimeslotTimes", calEvent.start));
  //  setupStartAndEndTimeFields(startField, endtimee, calEvent, $calendar.weekCalendar("getTimeslotTimes", calEvent.end));
    $(window).resize().resize(); //fixes a bug in modal overlay size ??
}

function SetBookingReferenceNo(calEvent) {
    if (calEvent.PatientId == "" || calEvent.PatientId == 0) {
        ShowHidePatientReferenceOptions(false);
        $("[id$='spnReferenceNoAppointmentForm']").html(calEvent.BookingReferenceNo);
        EnableDisableAppointmentFilterFields(true);
    }
}

function EventData(start, end, callback) {
    debugger;
    if (!checkModuleRights("Scheduler")) {
        //showErrorMessage(_msg_AppointmentsView);
        return;
    }
    
    $("[id$='txtAppointmentDateMain']").datepicker('setDate', start);
    
    if (_PracticeStaffIds != "") {
        debugger
        //If there are some service providers available at selected location then load appointments.
        var loc_id = $("[id$='ddLocationMain']").val();
        var dateObject = $("[id$='txtAppointmentDateMain']").datepicker('getDate');

        var app_date = start.toString("yyyy-MM-dd");
        var day = start.getDay();

        var UsersLength = GetUsersLength();
        
        $.ajax({
            type: "POST",
            url: "../../ProviderPortal/adminCalendar.asmx/LoadAppointments",
            data: '{app_date: "' + app_date + '", loc_id: "' + loc_id + '", prov_id: "' + _PracticeStaffIds + '", day: "' + day + '", UsersLength: "' + UsersLength + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result, status) {
                SuccessAppointmentLoad(result, status, callback);
            },
            error: function (request, status, error) {
                debugger;
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
        SetAppointmentLegends();
    }
}

function SuccessAppointmentLoad(result, status, callback) {
    debugger;
    result = result.d;
    
    var events = JSON.parse(result.events);
    var freebusys = JSON.parse(result.freebusys);
    var businessHours = result.businessHours[0];
    var startTime = businessHours.Bussiness_start_Time;
    var endTime = businessHours.Bussiness_end_Time;
    var isOffDay = JSON.parse(result.isOffDay);
    
    var source;

    if (isOffDay) {
        source = {
            options: {
                users: _arrUsers
            },
            //events: {}
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
    debugger
    var PracticeLocationsId = $("[id$='ddLocationMain']").val();
   var UTCOffset = _arrLocationStateUTC[PracticeLocationsId];
  //  var UTCOffset = PracticeLocationsId;
    var CurrentHour = GetDateByLocationUTC(UTCOffset, "Hours");

    //$(".wc-scrollable-grid").scrollTop((CurrentHour * 127.5));

    var CurrentAppointmentSlotStartingRowNumber = (CurrentHour * 4) - 1;
    var CurrentAppointmentSlotEndingRowNumber = CurrentAppointmentSlotStartingRowNumber + 4;

    $($(".wc-time-slot")[CurrentAppointmentSlotStartingRowNumber]).css("border-color", "red");
    $($(".wc-time-slot")[CurrentAppointmentSlotEndingRowNumber]).css("border-color", "red");

    //$(".wc-scrollable-grid").scrollTop(0);
    SetAppointmentLegends();
}

function SaveAppointment(calEvent) {
    debugger;
    if ($("[id$='divAppointmentPatient']").is(":visible")) {
        if ($("[id$='hdnPatientId']").val() == 0) {
            showErrorMessage("Please select a patient or create new one.");
            return false;
        }
    }
    else if ($("[id$='divAppointmentBookingReferenceNo']").is(":visible")) {
        var ReferenceNo = $.trim($("[id$='spnReferenceNoAppointmentForm']").html());
        
        if (ReferenceNo == "") {
            showErrorMessage("Please enter Reference No.");
            return false;
        }
    }
    
    if (!ValidateForm("divAppointmentContainer")) {
        showErrorMessage("");
        return;
    }
    
    calEvent = SetEventObject(calEvent);
    
    if ($("#divAppointmentBookingReferenceNo").is(":visible")) {
        calEvent.PatientName = "Reserved";
    }

    if (calEvent.id == 0) {
        _isEventCreateButtonClick = true;
    }

    SaveAppointmentOnServer(calEvent);
    $dialogContent.dialog("close");
}

function SaveAppointmentOnServer(calEvent) {
    debugger;
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

    var PracticeLocationsIdCheckedInPatientList = $("[id$='ddlPracticeLocationsCheckedInPatients']").val();

    var params = {
        objAdminAppointmentData: JSON.stringify(calEvent),
        AppointmentsId: calEvent.id,
        PracticeLocationsId: PracticeLocationsId,
        AppointmentDate: AppointmentDate,
        PracticeLocationsIdCheckedInPatientList: PracticeLocationsIdCheckedInPatientList,
        action: "Save"
    };

    $.post("../../ProviderPortal/Scheduler/CallBacks/AppointmentsActionHandler.aspx", params, function (dataAppointment) {
        var isNewAppointment = (calEvent.id == 0);
        debugger;
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
            debugger;
            showSuccessMessage(_msg_Created);
        }
        else {
            showSuccessMessage(_msg_Updated);
        }
        
        calEvent = UpdateCalEventLocally(calEvent);

        ReloadCalendar();
        //$calendar.weekCalendar("updateEvent", calEvent);

        if (calEvent.statusId == 4 && calEvent.OldStatusId != 4) {
            OpenCheckInForm(calEvent.id, 0, calEvent.statusId, "", calEvent.status, "", calEvent.PatientId);
        }
        else {
            SetAppointmentLegends();
            $("#tblCheckedInPatients #" + calEvent.id + "").remove();
        }
    });
}

function EventDelete(calEvent, element, dayFreeBusyManager, calendar, clickEvent) {
    if (!checkModuleRights("AppointmentsDelete")) {
        showErrorMessage(_msg_AppointmentsDelete);
        return false;
    }
    
    $("[id$='txtAppointmentDeletionReason']").val("");
    
    $("#dialog-confirm-app-delete").dialog({
        resizable: false,
        height: 'auto',
        width: 'auto',
        modal: true,
        buttons: {
            Delete: function () {
                debugger;
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
    debugger
    var PracticeLocationsIdCheckedInPatientList = $("[id$='ddlPracticeLocationsCheckedInPatients']").val();
    var DeleteReason = $("#txtAppointmentDeletionReason").val();
    
    $.post("../../ProviderPortal/Scheduler/CallBacks/AppointmentsActionHandler.aspx", { AppointmentsId: AppointmentsId, DeleteReason: DeleteReason, PracticeLocationsIdCheckedInPatientList: PracticeLocationsIdCheckedInPatientList, action: "Delete" }, function (dataAppointment) {
        $calendar.weekCalendar('removeEvent', AppointmentsId);
        debugger
        showSuccessMessage(_msg_Deleted);
       
        SetAppointmentLegends();
        ReloadCheckedInPatientList();
    });
}

function SetAppointmentForm(calEvent) {
    debugger;
    calEvent.PatientName = "";
    calEvent.PatientId = "";
    calEvent.providerId = GetCalEventProviderId(calEvent);

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

    $dialogContent.find("[id$='spnPatientName']").html(calEvent.PatientName);
    $dialogContent.find("select[name='status']").val(calEvent.statusId);

    $("[id$='ddDialogAppProvider']").val(calEvent.providerId);

    $("[id$='spnReferenceNoAppointmentForm']").html(calEvent.BookingReferenceNo);

    SetCalEventRecurrenceSection(calEvent);
}

function resetForm($dialogContent) {
    $("[id$='hdnPatientId']").val(0);
    $("[id$='ddReason']").val(0);
    $dialogContent.find("input:text").val("");
    $dialogContent.find("textarea").val("");
    
    ResetPatientInformation();
    
    ShowHidePatientReferenceOptions(true);
}

function SetEventObject(calEvent) {
    var startTime = new Date($dialogContent.find("select[name='start']").val());
    var endTime = new Date($dialogContent.find("select[name='end']").val());
    
    calEvent.PatientId = $.trim($("[id$='hdnPatientId']").val());
    calEvent.PatientName = $.trim($dialogContent.find(".spnPatientName").html());
    calEvent.start = startTime;
    calEvent.end = endTime;
    calEvent.title = "";
    calEvent.titleId = "";
    calEvent.providerId = $.trim($dialogContent.find("[id$='ddDialogAppProvider']").val());
    calEvent.reasonId = $.trim($dialogContent.find("[id$='ddReason']").val());
    calEvent.statusId = $.trim($dialogContent.find("[id$='ddAppStatus']").val());
    calEvent.status = $.trim($dialogContent.find("[id$='ddAppStatus'] :selected").text());
    calEvent.Notes = $.trim($dialogContent.find("#taNotes").val());
    calEvent.BookingReferenceNo = $.trim($("[id$='spnReferenceNoAppointmentForm']").html());
    
    
    var RecurrenceDays = "";

    $("#tbodyRecurrenceDays input:checkbox:checked").each(function () {
        
        RecurrenceDays += $(this).parent().find("input:hidden").val() + ", ";
    });

    if (RecurrenceDays.length > 0) {
        RecurrenceDays = RecurrenceDays.slice(0, -2);
    }
    
    calEvent.IsRecurrence = $("[id$='chkIsRecurrence']").is(":checked");
    calEvent.RecurrenceDays = RecurrenceDays;
    calEvent.RecurrenceFrequency = $.trim($("[id$='ddlRecurrenceFrequency']").val());
    calEvent.RecurrenceUnit = $.trim($("[id$='ddlRecurrenceUnit']").val());
    
    return calEvent;
}


function GetCalEventProviderId(calEvent) {
    var CurrentUser = calEvent.userId;
    var ProviderCheckBox = $($(".cbServiceProviders:checked")[CurrentUser]);
    return $.trim(ProviderCheckBox.parent().find(".hdnPracticeStaffId").val());
}

/*
* Sets up the start and end time fields in the calendar event
* form for editing based on the calendar event being edited
*/
function setupStartAndEndTimeFields($startTimeField, $endTimeField, calEvent, timeslotTimes) {
    debugger;
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

var AppointmentId_Status, appointmentStatusId_Status, elem_Status, isExpireTime_Status, ifUpdateStatus_Status = false, _CurrentEvent;

function updateAppointmentStatus(AppointmentId, StatusId, event, elem, isExpireTime, isFutureEvent, PatientId) {
    debugger;
    event.stopPropagation();
    AppointmentStatusChanged(elem);
    
    if (!checkModuleRights("AppointmentsEdit")) {
        showErrorMessage(_msg_AppointmentsEdit);
        return false;
    }
    
    var appStatus = $.trim($(elem).find("span").html());
    var appCurrentStatus = $.trim($(elem).closest("table").parent().parent().find(".status-label").html());
    
    if (appStatus == appCurrentStatus) {
        return false;
    }
    
    var CheckInRoomId = 0;
    StatusId = $.trim(StatusId);
    
    if ((StatusId == "5" || StatusId == "6") && isFutureEvent) {
        var msg = "<p>Future appointment may not be updated with status 'Completed' or 'No Show'.</p>";
        var title = "Information";
        dialogShowMessage(msg, title);
        return false;
    }

    if (StatusId == "4") {
        OpenCheckInForm(AppointmentId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime, PatientId);
    }
    else {
        AppointmentUpdateStatus(AppointmentId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime, PatientId);
    }
}

function AppointmentUpdateStatus(AppointmentsId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime, PatientId, objCheckedInPatients, objPatientInsurancePrimary, objPatientInsuranceSecondary) {
    debugger;
    var PracticeLocationsId = $("[id$='ddLocationMain']").val();
    var PracticeLocationsIdCheckedInPatientList = $("[id$='ddlPracticeLocationsCheckedInPatients']").val();
    
    var ServiceProviderId = 0;
    //var LocalTime = GetPracticeLocationCurrentTimeUTC(PracticeLocationsId, "Time").toString("yyyy-MM-dd hh:mm:ss");

    var LocalTime = GetPracticeLocationCurrentTimeUTC(PracticeLocationsId, "DateTime24");
    //var LoacalTime = DateTime24;
    var params = {
        AppointmentsId: AppointmentsId,
        CheckInRoomId: CheckInRoomId,
        StatusId: StatusId,
        PracticeLocationsId: PracticeLocationsId,
        PracticeLocationsIdCheckedInPatientList: PracticeLocationsIdCheckedInPatientList,
        ServiceProviderId: ServiceProviderId,
        PatientId: PatientId,
        LocalTime: LocalTime,
        objCheckedInPatients: JSON.stringify(objCheckedInPatients),
        objPatientInsurancePrimary: JSON.stringify(objPatientInsurancePrimary),
        objPatientInsuranceSecondary: JSON.stringify(objPatientInsuranceSecondary),
        action: "UpdateStatus"
    };
    
    $.post("../../ProviderPortal/Scheduler/CallBacks/AppointmentsActionHandler.aspx", params, function (dataCheckIn) {
        var startCheckIn = dataCheckIn.indexOf("###StartCheckedInPatients###") + 28;
        var endCheckIn = dataCheckIn.indexOf("###EndCheckedInPatients###");
        var returnHtmlCheckIn = $.trim(dataCheckIn.substring(startCheckIn, endCheckIn));
        
        SetDataCheckedInPatientList(returnHtmlCheckIn);
        
        if (elem != "") {
            var startStatusColor = dataCheckIn.indexOf("###StartStatusColor###") + 22;
            var endStatusColor = dataCheckIn.indexOf("###EndStatusColor###");
            var StatusColor = $.trim(dataCheckIn.substring(startStatusColor, endStatusColor));
            
            $(elem).closest("div").parent().parent().parent().parent().find(".wc-time").css("background-color", StatusColor);
            
            $(elem).closest("table").parent().parent().find(".status-label").html(appStatus);
            $(elem).closest("table").parent().parent().find(".hdnStatusId").val(StatusId);
            $(elem).closest("table").parent().parent().find(".hdnCheckInRoomId").val(CheckInRoomId);
            
            var allEvents = $calendar.weekCalendar("serializeEvents");
            var CurrentCallEvent = $.grep(allEvents, function (v, i) {
                return (v.id == AppointmentsId);
            });
            
            CurrentCallEvent[0].statusId = StatusId;
            CurrentCallEvent[0].status = appStatus;
            CurrentCallEvent[0].status_back_color = StatusColor;
            
            $calendar.weekCalendar("updateEvent", CurrentCallEvent[0]);
        }
        
        showSuccessMessage(_msg_Updated);
        //RefreshAppointmentCalendar();
        SetAppointmentLegends();
    });
}

function AppointmentStatusChanged(elem) {
    $(elem).closest(".custom-dropdown-list").animate({ height: 'toggle' });
    $(".status-dropdown-icon").removeClass("status-dropdown-icon-open").addClass("status-dropdown-icon-close");
}

function ShowHideAppointmentEventCustomDropDown(elem, event, changeIcon) {
    event.stopPropagation();
    
    if ($(elem).parent().find(".custom-dropdown-list").is(":visible")) {
        $(".custom-dropdown-list").hide();
    }
    else {
        $(".custom-dropdown-list").hide();
        var ListParentTopPosition = $(elem).parent().offset().top;
        var ListHeight = $(elem).parent().find(".custom-dropdown-list").height();
        var ListHeightWithPosition = parseInt(ListParentTopPosition) + parseInt(ListHeight);
        
        var WindowBottomPositionTop = parseInt($("[id$='divWindowBottom']").offset().top);
        
        if (ListHeightWithPosition < (WindowBottomPositionTop - 30)) {
            $(elem).parent().find(".custom-dropdown-list").removeClass("custom-dropdown-list-bottom-to-top").addClass("custom-dropdown-list-top-to-bottom");
        }
        else {
            $(elem).parent().find(".custom-dropdown-list").removeClass("custom-dropdown-list-top-to-bottom").addClass("custom-dropdown-list-bottom-to-top");
        }
        
        $(elem).parent().find(".custom-dropdown-list").show();
    }
    
    if (changeIcon) {
        var statusIcon = $(elem).find(".status-dropdown-icon");
        ChangeStatusIcon(statusIcon);
    }
}

function ChangeStatusIcon(elem) {
    if ($(elem).hasClass("status-dropdown-icon-open")) {
        $(elem).removeClass("status-dropdown-icon-open").addClass("status-dropdown-icon-close");
    }
    else if ($(elem).hasClass("status-dropdown-icon-close")) {
        $(elem).removeClass("status-dropdown-icon-close").addClass("status-dropdown-icon-open");
    }
}

function OpenMedicalHistory(event, elem, PatientId, appointmentId) {
    debugger
    _PatientId = PatientId;
    event.stopPropagation();
    _appointmentId = appointmentId;

    $.post(_EMRPath + "/Controls/MedicalHistory.aspx", { PatientId: PatientId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");

        var returnHtml = $.trim(data.substring(start, end));
        $("#divDialogMedicalHistory").html(returnHtml);
        SetMedicalHistoryYesLabels("#divDialogMedicalHistory");

        $("#divDialogMedicalHistory").dialog({
            title: "Medical History",
            width: "90%",
            height: $(window).height() - 20,
            modal: true,
            buttons: {
                "Save": function () {
                    SaveMedicalHistory(true);
                },
                "Apply": function () {
                    SaveMedicalHistory(false);
                },
                "Close": function () {
                    $("#divDialogMedicalHistory").dialog("close");
                }
            },
            close: function () {
                $("#divDialogMedicalHistory").dialog("destroy");
            }
        });
    });
}

function OpenTreatmentPlan(event, elem, PatientId) {
    debugger;
    event.stopPropagation();

    if (!checkModuleRights("PatientTreatmentPlanView")) {
        showErrorMessage("You don't have rights to View Patient Treatment Plan");
        return;
    }

    _PatientId = PatientId;
    _isTreatmentPlanDialogCallFromDentalChart = false;

    $.post(_EMRPath + "/Chart/CallBacks/TreatmentPlanDialogHandler.aspx", { PatientId: PatientId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divDialogTreatmentPlan").html(returnHtml);

        start = data.indexOf("###StartPrintTreatmentPlan###") + 29;
        end = data.indexOf("###EndPrintTreatmentPlan###");
        returnHtml = $.trim(data.substring(start, end));
        $("#divDialogPrintTreatmentPlan").html(returnHtml);

        var patientImagePath;

        if ($("[id$='hfImageFileNamePatient']").val() == "") {
            if ($.trim($("[id$='lblGenderPatient']").html()) == "Male,") {
                patientImagePath = _RooTPath + "Images/maleIcon.png";
            }
            else if ($.trim($("[id$='lblGenderPatient']").html()) == "Female,") {
                patientImagePath = _RooTPath + "Images/FemaleIcon.png";
            }
        }
        else {
            patientImagePath = _PracticeDocumentsPath + "/" + $("[id$='hfImageFileNamePatient']").val();
        }

        $("[id$='PatientImage']").attr("src", patientImagePath);
        $("[id$='Phone']").attr("src", _RooTPath + "Images/phone.png");

        $("#tblItemsTreatmentPlan tbody").append($("#tblSampleItemsTreatmentPlan tr").clone());

        $("#divDialogTreatmentPlan").dialog({
            title: "Treatment Plan",
            width: "1000",
            height: WindowHeight(),
            modal: true,
            open: function () {
                LoadTreatmentPlanDentalServices();
                SetElementDynamicHeight("divGridItemsTreatmentPlan", "divGridItemsTreatmentPlan", "", "divTreatmentPlanServicesTotals", 15);
            },
            close: function () {
                $("#divDialogTreatmentPlan").html("");
                $("#divDialogPrintTreatmentPlan").html("");
                $(this).dialog("destroy");
            }
        });
    });
}

function initializeUpload() {
    new AjaxUpload('#fPatient', {
        action: _ImageHandlerPath,
        dataType: 'json',
        contentType: "application/json; charset=uft-8",
        data: {
            PatientId: $("[id$='hdnPatientIdTreatment']").val(),
            PracticeId: $("[id$='hdnPracticeIdPatient']").val()
        },
        onSubmit: function (file, ext, fileSize) {
            if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                showErrorMessage("Error: Invalid file type!");
                return false;
            }

            if (fileSize > 25) {
                showErrorMessage("Error: This file exceeds the 5MB attachment limit.");
                return false;
            }
        },
        onComplete: function (file, response) {
            var responseHTML = $(response);
            var r = responseHTML.html();
            var res = $.parseJSON(r);
            $("[id$='PatientImage']").attr("src", "../PracticeDocuments/" + $("[id$='hdnPracticeIdPatient']").val() + "/Patients/" + $("[id$='hdnPatientIdTreatment']").val() + "/" + res.fileName);
            $("[id$='hdnPhotoFileTempPathPatient']").val("~/PracticeDocuments/" + $("[id$='hdnPracticeIdPatient']").val() + "/Patients/" + $("[id$='hdnPatientIdTreatment']").val() + "/" + res.fileName);
            $("[id$='hfImageFileNamePatient']").val(res.fileName);
        }
    });
}

var _PatientName;

function UpdateAppointmentTime(AppointmentsId, EndTime) {
    if (!checkModuleRights("AppointmentsEdit")) {
        showErrorMessage(_msg_AppointmentsEdit);
        return false;
    }

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

function SaveMedicalHistory(isDialogClose) {
    var objMedicalHistory = new Object();
    
    objMedicalHistory.MedicalHistoryId = $("[id$='hdnMedicalHistoryId']").val();
    objMedicalHistory.PatientId = _PatientId;
    objMedicalHistory.AppointmentId = _appointmentId;
    objMedicalHistory.BranchId = "1";

    objMedicalHistory.PhysicianCare = $("input:radio[name='PhysicianCare']:checked").val();
    objMedicalHistory.PhysicianCareReason = $("[id$='txtUnderPhysicianCareNote']").val();
    objMedicalHistory.MajorOperation = $("input:radio[name='MajorOperation']:checked").val();
    objMedicalHistory.MajorOperationReason = $("[id$='txtEverHospitalizedNote']").val();
    objMedicalHistory.HeadNeckInjury = $("input:radio[name='HeadNeckInjury']:checked").val();
    objMedicalHistory.HeadNeckInjuryReason = $("[id$='txtEverHeadNeckNote']").val();
    objMedicalHistory.TakingDrugs = $("input:radio[name='TakingDrugs']:checked").val();
    objMedicalHistory.TakingDrugsReason = $("[id$='txtTakingAnyMedicationsNote']").val();
    objMedicalHistory.TakingRedux = $("input:radio[name='TakingRedux']:checked").val();
    objMedicalHistory.TakingBisphosphonate = $("input:radio[name='TakingBisphosphonate']:checked").val();
    objMedicalHistory.SpecialDiet = $("input:radio[name='SpecialDiet']:checked").val();
    objMedicalHistory.TobaccoUse = $("input:radio[name='TobaccoUse']:checked").val();

    objMedicalHistory.ControlledSubstances = $("input:radio[name='ControlledSubstances']:checked").val();
    objMedicalHistory.Pregnant = $("[id$='chkPregnant']").is(":checked");
    objMedicalHistory.Nursing = $("[id$='chkNursing']").is(":checked");
    objMedicalHistory.OralContraceptives = $("[id$='chkOralContraceptives']").is(":checked");
    objMedicalHistory.Aspirin = $("[id$='chkAspirin']").is(":checked");
    objMedicalHistory.Penicillin = $("[id$='chkPenicillin']").is(":checked");
    objMedicalHistory.Codeine = $("[id$='chkCodeine']").is(":checked");
    objMedicalHistory.LocalAnesthetics = $("[id$='chkAnesthetics']").is(":checked");
    objMedicalHistory.Acrylic = $("[id$='chAcrylic']").is(":checked");

    objMedicalHistory.Metal = $("[id$='chkMetal']").is(":checked");
    objMedicalHistory.Latex = $("[id$='chkLatex']").is(":checked");
    objMedicalHistory.SulfaDrugs = $("[id$='chkSulfaDrugs']").is(":checked");
    objMedicalHistory.AllergicOther = $("[id$='txtAreYouAllergicToOtherNote']").val();
    objMedicalHistory.Aids = $("input:radio[name='Aids']:checked").val();
    objMedicalHistory.AlzheimerDisease = $("input:radio[name='Alzheimer']:checked").val();
    objMedicalHistory.Anaphylaxis = $("input:radio[name='Anaphylaxis']:checked").val();
    objMedicalHistory.Anemia = $("input:radio[name='Anemia']:checked").val();
    objMedicalHistory.Angina = $("input:radio[name='Angina']:checked").val();
    objMedicalHistory.Arthritis = $("input:radio[name='Arthritis']:checked").val();
    objMedicalHistory.ArtificialHeartValue = $("input:radio[name='ArtificialHeartValve']:checked").val();
    objMedicalHistory.ArtificialJoint = $("input:radio[name='ArtificialJoint']:checked").val();
    objMedicalHistory.Asthma = $("input:radio[name='Asthma']:checked").val();
    objMedicalHistory.BloodDisease = $("input:radio[name='BloodDisease']:checked").val();
    objMedicalHistory.BloodTransfusion = $("input:radio[name='BloodTransfusion']:checked").val();
    objMedicalHistory.BreathingProblem = $("input:radio[name='BreathingProblem']:checked").val();
    objMedicalHistory.BruiseEasily = $("input:radio[name='BruiseEasily']:checked").val();
    objMedicalHistory.Cancer = $("input:radio[name='Cancer']:checked").val();
    objMedicalHistory.ChemoTherapy = $("input:radio[name='Chemotherapy']:checked").val();
    objMedicalHistory.ChestPains = $("input:radio[name='ChestPains']:checked").val();
    objMedicalHistory.ColdSores = $("input:radio[name='ColdSores']:checked").val();

    objMedicalHistory.CongenitalHeartDisorder = $("input:radio[name='CongenitalHeartDisorder']:checked").val();
    objMedicalHistory.Convulsions = $("input:radio[name='Convulsions']:checked").val();
    objMedicalHistory.YellowJaundice = $("input:radio[name='YellowJaundice']:checked").val();
    objMedicalHistory.CortisoneMedicine = $("input:radio[name='CortisoneMedicine']:checked").val();
    objMedicalHistory.Diabetes = $("input:radio[name='Diabetes']:checked").val();
    objMedicalHistory.DrugAddiction = $("input:radio[name='DrugAddiction']:checked").val();
    objMedicalHistory.EasilyWinded = $("input:radio[name='EasilyWinded']:checked").val();
    objMedicalHistory.Emphysema = $("input:radio[name='Emphysema']:checked").val();
    objMedicalHistory.Epilepsy = $("input:radio[name='Epilepsy']:checked").val();
    objMedicalHistory.ExcessiveBleeding = $("input:radio[name='ExcessiveBleeding']:checked").val();
    objMedicalHistory.ExcessiveThirst = $("input:radio[name='ExcessiveThirst']:checked").val();
    objMedicalHistory.FaintingSpells = $("input:radio[name='FaintingSpells']:checked").val();
    objMedicalHistory.FrequentCough = $("input:radio[name='FrequentCough']:checked").val();
    objMedicalHistory.FrequentDiarrhea = $("input:radio[name='FrequentDiarrhea']:checked").val();
    objMedicalHistory.FrequentHeadaches = $("input:radio[name='FrequentHeadaches']:checked").val();
    objMedicalHistory.GenitalHerpes = $("input:radio[name='GenitalHerpes']:checked").val();
    objMedicalHistory.Glaucoma = $("input:radio[name='Glaucoma']:checked").val();
    objMedicalHistory.HayFever = $("input:radio[name='HayFever']:checked").val();
    objMedicalHistory.HeartAttack = $("input:radio[name='HeartAttack']:checked").val();
    objMedicalHistory.HeartMurmur = $("input:radio[name='HeartMurmur']:checked").val();
    objMedicalHistory.HeartPaceMaker = $("input:radio[name='HeartPacemaker']:checked").val();

    objMedicalHistory.HeartTrouble = $("input:radio[name='HeartTrouble']:checked").val();
    objMedicalHistory.Hemophilia = $("input:radio[name='Hemophilia']:checked").val();
    objMedicalHistory.HepatitisA = $("input:radio[name='HepatitisA']:checked").val();
    objMedicalHistory.HepatitisBC = $("input:radio[name='HepatitisBC']:checked").val();
    objMedicalHistory.Herpes = $("input:radio[name='Herpes']:checked").val();
    objMedicalHistory.HighBloodPressure = $("input:radio[name='HighBloodPressure']:checked").val();
    objMedicalHistory.HighCholesterol = $("input:radio[name='HighCholesterol']:checked").val();
    objMedicalHistory.Hives = $("input:radio[name='Hives']:checked").val();
    objMedicalHistory.Hypoglycemia = $("input:radio[name='Hypoglycemia']:checked").val();
    objMedicalHistory.IrregularHeartBeat = $("input:radio[name='IrregularHeartbeat']:checked").val();
    objMedicalHistory.KidneyProblems = $("input:radio[name='KidneyProblems']:checked").val();
    objMedicalHistory.Leukimia = $("input:radio[name='Leukemia']:checked").val();
    objMedicalHistory.LiverDisease = $("input:radio[name='LiverDisease']:checked").val();
    objMedicalHistory.LowBloodPressure = $("input:radio[name='LowBloodPressure']:checked").val();
    objMedicalHistory.LungDisease = $("input:radio[name='LungDisease']:checked").val();

    objMedicalHistory.MitralValueProlapse = $("input:radio[name='MitralValveProlapse']:checked").val();
    objMedicalHistory.Osteoprosis = $("input:radio[name='Osteoporosis']:checked").val();
    objMedicalHistory.JawJointPain = $("input:radio[name='JawJointPain']:checked").val();
    objMedicalHistory.ParathyroidDisease = $("input:radio[name='ParathyroidDisease']:checked").val();
    objMedicalHistory.PsychiatricCare = $("input:radio[name='PsychiatricCare']:checked").val();
    objMedicalHistory.RadiationTreatment = $("input:radio[name='RadiationTreatments']:checked").val();
    objMedicalHistory.RecentWeightLoss = $("input:radio[name='WeightLoss']:checked").val();
    objMedicalHistory.RenalDialysis = $("input:radio[name='RenalDialysis']:checked").val();
    objMedicalHistory.RheumaticFever = $("input:radio[name='RheumaticFever']:checked").val();

    objMedicalHistory.Rheumatism = $("input:radio[name='Rheumatism']:checked").val();
    objMedicalHistory.ScarletFever = $("input:radio[name='ScarletFever']:checked").val();
    objMedicalHistory.Shingless = $("input:radio[name='Shingles']:checked").val();
    objMedicalHistory.SickleCellDisease = $("input:radio[name='SickleCellDisease']:checked").val();

    objMedicalHistory.SinusTrouble = $("input:radio[name='SinusTrouble']:checked").val();
    objMedicalHistory.SpinaBifida = $("input:radio[name='SpinaBifida']:checked").val();
    objMedicalHistory.StomachDisease = $("input:radio[name='Stomach']:checked").val();
    objMedicalHistory.Stroke = $("input:radio[name='Stroke']:checked").val();
    objMedicalHistory.SwellingOfLimbs = $("input:radio[name='SwellingofLimbs']:checked").val();
    objMedicalHistory.ThyroidDisease = $("input:radio[name='ThyroidDisease']:checked").val();
    objMedicalHistory.Tonsilitis = $("input:radio[name='Tonsillitis']:checked").val();
    objMedicalHistory.Tuberculosis = $("input:radio[name='Tuberculosis']:checked").val();
    objMedicalHistory.Tumors = $("input:radio[name='Tumors']:checked").val();
    objMedicalHistory.Ulcers = $("input:radio[name='Ulcers']:checked").val();
    objMedicalHistory.VenerealDisease = $("input:radio[name='VenerealDisease']:checked").val();
    objMedicalHistory.SeriousIllness = $("input:radio[name='seriousillness']:checked").val();
    objMedicalHistory.SeriousIllnessDetail = $("[id$='txtSeriousIllness']").val();
    
    $.post("Controls/CallBacks/MedicalHistoryHandler.aspx", { MedicalHistory: JSON.stringify(objMedicalHistory) }, function (data) {
        var start = data.indexOf("###StartMedicalHistoryId###") + 27;
        var end = data.indexOf("###EndMedicalHistoryId###");
        
        if ($("[id$='hdnMedicalHistoryId']").val() == "0") {
            $("[id$='hdnMedicalHistoryId']").val(data.substring(start, end));
            showSuccessMessage(_msg_Created);
        }
        else {
            showSuccessMessage(_msg_Updated);
        }
    });
    
    if (isDialogClose == true) {
        $("#divDialogMedicalHistory").dialog("close");
    }
}

function OpenPatientChart(event, AppointmentsId, PatientId) {
    
    if (_IsEventDragging) {
        _IsEventDragging = false;
        return;
    }

    if (!checkModuleRights("PatientClinicalExamsView")) {
        showErrorMessage(_msg_PatientClinicalExamsView);
        return false;
    }
    
    event.stopPropagation();
    window.location = _EMRPath + "/Patient/Demographics.aspx?PatientId=" + PatientId + "&InfoType=Charts";
}


function ClickOpenBalanceSheet() {
    var PatientId = $("[id$='hdnPatientIdAppointmentDetail']").val();
    OpenBalanceSheet(PatientId);
}

function OpenBalanceSheet(PatientId) {
    event.stopPropagation();
    
    $.post(_ClaimsPath + "/CallBacks/PatientBlanceSheetHandler.aspx", { PatientId: PatientId }, function (data) {
        var start = data.indexOf("###StartPatientBalanceSheet###") + 30;
        var end = data.indexOf("###EndPatientBalanceSheet###");
        
        $("#divPatientBalanceSheet").html(data.substring(start, end)).dialog({
            width: "1000",
            height: WindowHeight(),
            modal: true,
            buttons: {
                "Print": function () {
                    printHtml("divPatientBalanceSheet");
                },
                "Close": function () {
                    $("#divPatientBalanceSheet").dialog("close");
                }
            },
            close: function () {
                $("#divPatientBalanceSheet").dialog("destroy");
            }
        });
    });
}


/*Start BookingReferenceNo Functions*/
function ClickBookingReferenceNo(elem) {
    //return;
    var isElemChecked = $(elem).is(":checked");
    
    ShowHidePatientReferenceOptions(!isElemChecked);
    
    EnableDisableAppointmentFilterFields(isElemChecked);
    
    //EnableDisableRecurrenceSection(isElemChecked);
    
    return true;
}

function EnableDisableAppointmentFilterFields(IfReference) {
    var AppointmentContainer = $("[id$='divAppointmentContainer']");

    if (IfReference) {
        $("[id$='txtBookingReferenceNo']").prop("disabled", false);
        
        AppointmentContainer.find("input[name='txtLastName']").val("");
        AppointmentContainer.find("input[name='txtFirstName']").val("");
        AppointmentContainer.find("input[name='txtPhone']").val("");
        AppointmentContainer.find("input[name='txtLastName']").prop("disabled", true);
        AppointmentContainer.find("input[name='txtFirstName']").prop("disabled", true);
        AppointmentContainer.find("input[name='txtPhone']").prop("disabled", true);
    }
    else {
        $("[id$='txtBookingReferenceNo']").val("");
        $("[id$='txtBookingReferenceNo']").prop("disabled", true);

        AppointmentContainer.find("input[name='txtLastName']").prop("disabled", false);
        AppointmentContainer.find("input[name='txtFirstName']").prop("disabled", false);
        AppointmentContainer.find("input[name='txtPhone']").prop("disabled", false);
    }
}

function OpenBookingReferenceNoDialog() {
    $("#divDialogBookingReferenceNo").dialog({
        title: "Reference No.",
        width: "400",
        modal: true,
        close: function () {
            $("#divDialogBookingReferenceNo").dialog("destroy");
        }
    });
}

function OkBookingReferenceNo() {
    CloseBookingReferenceNoDialog();
}

function CloseBookingReferenceNoDialog() {
    $("#divDialogBookingReferenceNo").dialog("close");
}

function ShowHidePatientReferenceOptions(ShowPatient) {
    debugger;

    if (ShowPatient) {
        $("[id$='divAppointmentBookingReferenceNo']").hide();
        $("[id$='divAppointmentPatient']").show();
        
        $("[id$='spnReferenceNoAppointmentForm']").html("");
        
        $("[id$='chkBookAppointment']").prop("checked", false);
    }
    else {
        $("[id$='divAppointmentPatient']").hide();
        $("[id$='divAppointmentBookingReferenceNo']").show();
        
        ResetPatientInformation();
        
        $("[id$='chkBookAppointment']").prop("checked", true);
        $("[id$='txtBookingReferenceNo']").prop("disabled", false);

    }
}
/*End BookingReferenceNo Functions*/


/*Start Recurrence*/
function ClickRecurrenceAppointment(elem) {
    EnableDisableRecurrenceSection(false);
}

function EnableDisableRecurrenceSection(DisableIsRecurrence) {
    $("#chkIsRecurrence").prop("disabled", DisableIsRecurrence);
    
    if (DisableIsRecurrence) {
        $("#chkIsRecurrence").prop("checked", false);
    }
    
    var TrueFalse = !$("#chkIsRecurrence").is(":checked");
    
    $("#tbodyRecurrenceDays input:checkbox").prop("disabled", TrueFalse);
    $("#ddlRecurrenceFrequency").prop("disabled", TrueFalse);
    $("#ddlRecurrenceUnit").prop("disabled", TrueFalse);
    
    $("#tbodyRecurrenceDays input:checkbox").prop("checked", false);
    $("#ddlRecurrenceFrequency").val(1);
    $("#ddlRecurrenceUnit").val("ddlRecurrenceUnit");
}

function SetCalEventRecurrenceSection(calEvent) {
    debugger
    
    $("#chkIsRecurrence").prop("checked", false);
    EnableDisableRecurrenceSection(false);
    
    if (!calEvent.IsRecurrence) {
        return;
    }
    
    $("#chkIsRecurrence").prop("checked", true);
    EnableDisableRecurrenceSection(false);
    
    var arrRecurrenceDays = calEvent.RecurrenceDays.split(",");
    var RecurrenceDay;
    
    for (var i = 0; i < arrRecurrenceDays.length; i++) {
        RecurrenceDay = $.trim(arrRecurrenceDays[i]);
        $("#chkReapet" + RecurrenceDay).prop("checked", true);
    }
    
    $("#ddlRecurrenceFrequency").val(calEvent.RecurrenceFrequency);
    $("#ddlRecurrenceUnit").val(calEvent.RecurrenceUnit);
}
/*End Recurrence*/



/*Start Right Click Events*/
function AppointmentRightClick(event) {
    //
    debugger;
    var $target = $(event.target);
    $TragetPaste = $target;
    AppointmentIdCopied = $($target).find(".hdnEventId").val();

    if ($target.closest(".ui-dialog").length >= 1) {
        return;
    }

    if ($target.closest("#calendar").length != 1) {
        return;
    }

    /*
    if (!($target.is(".wc-cal-event") || $(".wc-cal-event").has($target).length > 0)) {
    $("[id$='divContextMenuAppointments']").find("#linkPasteAppointment, #linkCreateAppointment").removeClass("disable-context-menu-item");
    $("[id$='divContextMenuAppointments']").find("#linkCopyAppointment").addClass("disable-context-menu-item");
    }
    else {
    $("[id$='divContextMenuAppointments']").find("#linkCopyAppointment").removeClass("disable-context-menu-item");
    $("[id$='divContextMenuAppointments']").find("#linkPasteAppointment, #linkCreateAppointment").addClass("disable-context-menu-item");
    }
    */

    $("[id$='divContextMenuAppointments']").css({
        top: event.pageY - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + "px",
        left: event.pageX + 'px'
    }).show();

    //return false;
}

function CreatAppointmentFromMenu() {
    $("[id$='divContextMenuAppointments']").hide();
    
    var freeBusyManager = _selfRightClick.getFreeBusyManagerForEvent(_calEventRightClick);
    _$eventRightClick = _selfRightClick._renderEvent(_calEventRightClick, _$weekDayRightClick);
    
    if (!_optionsRightClick.allowCalEventOverlap) {
        _selfRightClick._adjustForEventCollisions(_$weekDayRightClick, _$eventRightClick, _calEventRightClick, _calEventRightClick);
        _selfRightClick._positionEvent(_$weekDayRightClick, _$eventRightClick);
    }
    else {
        _selfRightClick._adjustOverlappingEvents(_$weekDayRightClick);
    }
    
    var proceed = _selfRightClick._trigger('beforeEventNew', _eventRightClick, {
        'calEvent': _calEventRightClick,
        'createdFromSingleClick': _createdFromSingleClickRightClick,
        'calendar': _selfRightClick.element
    });
    
    if (proceed) {
        _optionsRightClick.eventNew(_calEventRightClick, _$eventRightClick, freeBusyManager, _selfRightClick.element, _eventRightClick);
    }
    else {
        $(_$eventRightClick).remove();
    }
}

var _EventOptions, _EventSelf;


function CopyAppointment(elem) {
    var AppointmentsId = _targetCoypaste.find(".hdnEventId").val();
    
    var allEvents = $calendar.weekCalendar("serializeEvents");
    
    _calEventCopyPaste = $.grep(allEvents, function (v, i) {
        return (v.id == AppointmentsId);
    });
    
    if (_calEventCopyPaste.length > 0) {
        _calEventCopyPaste = _calEventCopyPaste[0];
    }
    
    ReloadCalendar();
}

function PasteAppointment(elem) {
    _calEventCopyPaste.id = 0;
    
    _calEventCopyPaste.userId = _calEventRightClick.userId;
    _calEventCopyPaste.providerId = $($("#divServiceProvidersDropDown .divMultiCheckInsideDropdown")[_calEventCopyPaste.userId]).find(".hdnPracticeStaffId").val();
    
    _calEventCopyPaste.start = _calEventRightClick.start;
    _calEventCopyPaste.end = _calEventRightClick.end;
    
    SaveAppointmentOnServer(_calEventCopyPaste);
}

function SetCalEventCopyPaste($target) {
    debugger;
    if ($target.parents(".wc-cal-event").length > 0 || $target.hasClass("wc-cal-event")) {
        if ($target.parents(".wc-cal-event").length > 0) {
            _targetCoypaste = $target.parents(".wc-cal-event");
        }
        else {
            _targetCoypaste = $target;
        }
        
        EnableDisableCopyPasteLinks(false);
    }
    else {
        EnableDisableCopyPasteLinks(true);
    }
}

function EnableDisableCopyPasteLinks(IsNewEvent) {
    if (IsNewEvent) {
        $("#linkCopyAppointment").addClass("disable-context-menu-item");
        $("#linkPasteAppointment").removeClass("disable-context-menu-item");
    }
    else {
        $("#linkCopyAppointment").removeClass("disable-context-menu-item");
        $("#linkPasteAppointment").addClass("disable-context-menu-item");
    }
}
/*End Right Click Events*/


/*Start Eligibility*/
var CurrentAppointmentEligibilityWrapper;

function ClickCheckPatientEligibility(elem, event) {
    event.stopPropagation();
    
    CurrentAppointmentEligibilityWrapper = $(elem);
    
    _PatientId = $(elem).find(".hdnPatientId").val();
    CheckPatientEligibility("Schedular");
}

function EligibilityResponseDone(data) {
    var start = data.indexOf("###StartEligibilityResponseStatus###") + 36;
    var end = data.indexOf("###EndEligibilityResponseStatus###");
    var EligibilityStatus = $.trim(data.substring(start, end));
    
    var objEligibilityStatus = ConvertPatientEligibilityStatus(EligibilityStatus);

    CurrentAppointmentEligibilityWrapper.find(".spnPatientEligibilityIcon")
    .removeAttr("class")
    .addClass("spnPatientEligibilityIcon appointment-bottom-icon " + objEligibilityStatus.Css);
    
    CurrentAppointmentEligibilityWrapper.find(".spnPatientEligibility").html(objEligibilityStatus.EligibilityStatus);
}
/*End Eligibility*/

function OnScrollAppointmentCalendar() {
    $('#divGlobalAbsoluteContainer').hide();
}

function AppointmentViewQuickDetail(elem, event, PatientId) {
    debugger;
    event.stopPropagation();

    if (PatientId == 0) {
        return;
    }

    var DetailWrapper = $("[id$='divGlobalAbsoluteContainer']"); // $(elem).parent().parent().find(".patint-info-list");

    if (DetailWrapper.is(":visible")) {
        DetailWrapper.hide();
        return;
    }

    DetailWrapper.addClass("appointment-details-container");

    var TopBottom, LeftRight;

    var ElemHeight = $(elem).height();
    var ElemWidth = $(elem).width();
    var ContainerHeight = DetailWrapper.height();
    var ContainerWidth = DetailWrapper.width();

    var ElementTopPosition = $(elem).offset().top;
    var ElementLeftPosition = $(elem).offset().left;

    var ContainerHeightWithPosition = parseInt(ElementTopPosition) + parseInt(ContainerHeight);
    var ContainerWidthWithPosition = parseInt(ElementLeftPosition) + parseInt(ContainerWidth);

    var WindowBottomPositionTop = parseInt($("[id$='divWindowBottom']").offset().top);

    if (ContainerHeightWithPosition < (WindowBottomPositionTop - 30)) {
        TopBottom = ElementTopPosition + ElemHeight;
    }
    else {
        TopBottom = ElementTopPosition - ElemHeight - 4 - ContainerHeight;
    }

    if (($(window).width() - ElementLeftPosition) < ContainerWidth) {
        LeftRight = ElementLeftPosition - ContainerWidth - 4;
    }
    else {
        LeftRight = ElementLeftPosition;
    }

    var AppointmentsId = $(elem).parent().parent().find(".hdnEventId").val();
    UnBindLoadingDiv();

    DetailWrapper.html('<div id="divCustomLoading" class="custom-loading-1">Loading...</div>');
    DetailWrapper.css({
        top: TopBottom,
        left: LeftRight
    }).show();
    debugger;
    $.post("../../ProviderPortal/Scheduler/CallBacks/AppointmentDetailsHandler.aspx", { AppointmentsId: AppointmentsId }, function (data) {
        debugger;
        var start = data.indexOf(" ####StartAppointmentDetails####") + 32;
        var end = data.indexOf("####EndAppointmentDetails####");
        var returnHtml = $.trim(data.substring(start, end));
        
        BindLoadingDiv();

        DetailWrapper.html(returnHtml).promise().done(function () {});
    });
}