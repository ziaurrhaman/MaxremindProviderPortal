$(function () {
    $(document).on("click", "#divSearchPatient tr", function () {
        var html = "<tr id='0'><td>" + $(this).find(".hdnPatientId").val() + "</td><td>" + $(this).find(".hdnLastName").val() + ' ' + $(this).find(".hdnFirstName").val() + "</td><td><a style='text-decoration: underline; color: blue; cursor: pointer;' onclick='DeleteSessionPatient(this);'>Delete</a></td></tr>";
        $("#tblSpecificPatients").append(html);
        $("#divSearchPatient").slideUp();

        event.stopPropagation();
    });
});

function ShowTeleHealtSession() {
    $("#divTeleHealthSession").show();
    $("#divTeleHealthSessionBottom").hide();
}

function HideTeleHealthSession() {
    $("#divTeleHealthSession").hide();
    $("#divTeleHealthSessionBottom").show();
}


function AddEditSession(TeleHealthSessionId)
{
    $.post(_ResolveUrl + "ProviderPortal/TeleHealthSession/CallBacks/AddTeleHealthSessionHandler.aspx", { TeleHealthSessionId: TeleHealthSessionId }, function (data) {
        var start = data.indexOf("#StartAddTeleHealthSession#") + 27;
        var end = data.indexOf("#EndAddTeleHealthSession#");

        var returnHtml = $.trim(data.substring(start, end));
        $("#divAddTeleHealthSession").html(returnHtml);
        $("#divAddTeleHealthSession").dialog({
            resizable: false,
            width: 'auto',
            height: '500',            
            title: 'Add Tele Health Session',
            modal: true,
            buttons: {
                Save: function () {
                    SaveTeleHealthSession();
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        });

        $("[id$='txtSessionScheduledTime']").datetimepicker({
            controlType: 'select',
            timeFormat: 'hh:mm tt'
        });

    });
    return false;
}


function SaveTeleHealthSession() {    
    var objTeleHealthSession = new Object();
    objTeleHealthSession.TeleHealthSessionsId = $("[id$='hdnTeleHealthSessionsId']").val();
    objTeleHealthSession.SessionTitle = $("#txtSessionSubject").val();
    objTeleHealthSession.PresenterId = $("#ddlSessionPresenter").val();
    objTeleHealthSession.SechduleTime = $("#txtSessionScheduledTime").val();
    objTeleHealthSession.IsOpenSession = $("#chkOpenSession").is(":checked");

    var objSessionAttendiesList = new Array();

    $("#tblSpecificPatients tr").each(function () {
        var objSessionAttendies = new Object();
        objSessionAttendies.SessionAttendiesId = $(this).attr("id");
        objSessionAttendies.PatientId = $(this).children().eq(0).html();
        objSessionAttendies.IsInvited = true;

        objSessionAttendiesList.push(objSessionAttendies);
    });

    $.post(_ResolveUrl + "ProviderPortal/TeleHealthSession/CallBacks/SaveTeleHealthSessionHandler.aspx", { TeleHealthSessions: JSON.stringify(objTeleHealthSession), SessionAttendiesList: JSON.stringify(objSessionAttendiesList) }, function (data) {
        var start = data.indexOf("#SessionListStart#") + 18;
        var end = data.indexOf("#SessionListEnd#");
        var returnHtml = $.trim(data.substring(start, end));

        $("#tblTeleHealthSession").html(returnHtml);

        $("#divAddTeleHealthSession").dialog("close");
    });
}

function OpenSession() {
    if ($("#chkOpenSession").is(":checked")) {
        $("#chkSpecificSession").prop("checked", false);
        $("#txtSearchPatient").prop("disabled", true).val('');
        $("#tblSpecificPatients").html("");
    }
}

function SpecificSession() {
    if ($("#chkSpecificSession").is(":checked")) {
        $("#chkOpenSession").prop("checked", false);
        $("#txtSearchPatient").prop("disabled", false);
    }
}


function SearchPatient() {
    var LastName = $("#txtSearchPatient").val();
    var FirstName = "";
    var Phone = "";
    
    var params = {
        LastName: LastName,
        FirstName: FirstName,
        Phone: Phone
    };

    $.post(_ControlPath + "/PatientBoxSearch.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#divSearchPatient table tbody").html(returnHtml);
        $("#divSearchPatient").show();
    });
}

function DeleteSessionPatient(obj)
{
    $(obj).closest("tr").remove();
}

function StartSession(sessionid,roomid,presenterid)
{
    window.open(_ResolveUrl + 'EMR/TeleHealthSession/VideoConference.aspx?initiator=true&usertoken=' + roomid + '&PresenterId=' + presenterid + '&SessionId=' + sessionid, '_blank');
}

function JoinSession(sessionid, roomid, patientid)
{
    window.open(_ResolveUrl + 'EMR/TeleHealthSession/VideoConference.aspx?initiator=false&usertoken=' + roomid + '&PatientId=' + patientid + '&SessionId=' + sessionid, '_blank');
}