


function initializeCheckedInDiv() {
    if ($("#tblCheckedInPatients tr.tr-checkedin-Patients-main").not(".trNoRecord").length > 0) {
        SetWaitingTime();
        
        window.setInterval(function () {
            SetWaitingTime();
        }, 30000);
    }
    else {
        $(".trNoRecord").show();
    }
}

function SetWaitingTime() {
    $("#tblCheckedInPatients tr.tr-checkedin-Patients-main").not(".trNoRecord").each(function () {
        var PracticeLocationsId = $(this).find(".hdnPracticeLocationsId").val();
        
        var TimeInOffice = getWaitingTime($.trim($(this).find(".tdArrivalTime").html()), PracticeLocationsId);
        $(this).find(".spnTimeInOffice").html(TimeInOffice);
        
        var TimeInRoom = getWaitingTime($.trim($(this).find(".tdCheckInTime").html()), PracticeLocationsId);
        $(this).find(".spnTimeInRoom").html(TimeInRoom);
    });
}

function getWaitingTime(checkedInTime, PracticeLocationsId) {
    var currentTime = GetPracticeLocationCurrentTimeUTC(PracticeLocationsId, "Time24");
    
    var s = checkedInTime.split(':');
    var e = currentTime.split(':');
    
    var min = e[1] - s[1];
    var hour_carry = 0;
    
    if (min < 0) {
        min += 60;
        hour_carry += 1;
    }
    
    hour = e[0] - s[0] - hour_carry;
    diff = hour + ":" + min;
    
    return diff;
}

function showCheckedInPatients() {
    $("#divCheckedInPatientSlide").slideUp().show();
    $("#divCheckedInPatientBottom").hide();
}

function HideCheckedInPatients() {
    $("#divCheckedInPatientSlide").slideDown().hide();
    $("#divCheckedInPatientBottom").show();
}

function ClickCheckedInPatientInfo(elem, InfoType) {
    var PatientId = $(elem).closest(".tr-checkedin-Patients-main").find(".hdnPatientId").val();
    RedirectToPatientInfo(PatientId, InfoType);
}

function ShowHidePatientInfoDropDownMaster(elem, event) {
    event.stopPropagation();
    
    $(".custom-dropdown-list-Master").hide();
    $(elem).parent().find(".custom-dropdown-list-Master").show();
}

function ShowHidePracticeRoomsDropDownMaster(elem, event) {
    event.stopPropagation();
    
    $(".div-Practice-Room-Master").hide();
    $(elem).parent().find(".div-Practice-Room-Master").show();
}

function updateCheckInRoomMaster(elem) {
    var CurrentRow = $(elem).closest("tr");
    var CheckInRoomId = CurrentRow.find(".hdnRoomId").val();
    
    var oldRoom = $.trim($(elem).closest("table").parent().parent().parent().find(".span-checkinroom-Main").html());
    var currentRoom = $.trim(CurrentRow.find(".linkRoomName").html());
    
    if (oldRoom == currentRoom) {
        return false;
    }
    
    var CheckedInPatientsId = $.trim($(elem).closest(".tr-checkedin-Patients-main").find(".hdnCheckedInPatientsId").val());
    var AppointmentsId = $.trim($(elem).closest("table").parent().parent().parent().find(".hdnAppointmentsId-CheckInRoom").val());
    var TimeInRoom = $.trim($(elem).closest(".tr-checkedin-Patients-main").find(".spnTimeInRoom").html());
    
    var PracticeLocationsId = $.trim($(elem).closest(".tr-checkedin-Patients-main").find(".hdnPracticeLocationsId").val());
    var PracticeLocationsIdCheckedInPatientList = $("[id$='ddlPracticeLocationsCheckedInPatients']").val();
    
    var LocalTime = GetPracticeLocationCurrentTimeUTC(PracticeLocationsId, "Time24");
    
    var params = {
        AppointmentsId: AppointmentsId,
        PracticeLocationsId: PracticeLocationsId,
        PracticeLocationsIdCheckedInPatientList: PracticeLocationsIdCheckedInPatientList,
        CheckInRoomId: CheckInRoomId,
        LocalTime: LocalTime,
        CheckedInPatientsId: CheckedInPatientsId,
        TimeInRoom: TimeInRoom,
        action: "ChangeCheckInRoom"
    };
    
    $.post(_EMRPath + "/Appointments/CallBacks/AppointmentsActionHandler.aspx", params, function (dataCheckIn) {
        $(elem).closest("table").parent().parent().parent().find(".span-checkinroom-Main").html(currentRoom);
        
        var startCheckIn = dataCheckIn.indexOf("###StartCheckedInPatients###") + 28;
        var endCheckIn = dataCheckIn.indexOf("###EndCheckedInPatients###");
        var returnHtmlCheckIn = $.trim(dataCheckIn.substring(startCheckIn, endCheckIn));
        
        SetDataCheckedInPatientList(returnHtmlCheckIn);
        showSuccessMessage(_msg_Updated);
    });
}

function SetDataCheckedInPatientList(returnHtml) {
    $("#tblCheckedInPatients").html(returnHtml).promise().done(function () {
        $("#tblCheckedInPatients").find("a").each(function () {
            var current = $(this).attr("href");

            if (current != undefined && current != '' && current.indexOf("_PatientPath") !== -1) {
                $(this).attr("href", current.replace("_PatientPath", _PatientPath));
            }
        });

        initializeCheckedInDiv();
    });
}

function ReloadCheckedInPatientList() {
    debugger
    var PracticeLocationsId = $("[id$='ddlPracticeLocationsCheckedInPatients']").val();
    
    $.post("../../ProviderPortal/Controls/CheckedInPatientsHandler.aspx", { PracticeLocationsId: PracticeLocationsId, action: "LoadCheckedInPatientList" }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='tblCheckedInPatients']").html(returnHtml);
    });
}