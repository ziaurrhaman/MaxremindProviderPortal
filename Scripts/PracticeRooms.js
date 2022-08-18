


/************************************** Start Practice Rooms ***********************************/
function showPracticeRooms() {
    $(".contents-details-header").html('Practice Rooms');
    $(".setting-content-wrapper").hide();
    $("#divPracticeRoomsMain").show();

    if (!checkModuleRights("PracticeRoomView")) {
        showErrorMessage(_msg_PracticeRoomsView);
        return false;
    }

    if ($.trim($("#divPracticeRoomsMain").html()).length == 0) {
        $.post(_SettingsPath + "/CallBacks/PracticeRoomsHandler.aspx", {}, function (data) {
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf("###End###");
            $("#divPracticeRoomsMain").html(data.substring(start, end));
            GeneratePracticeRoomsPagging();
            $("#gridPracticeRooms").show();
        });
    }
}

function AddNewPracticeRoom() {
    if (!checkModuleRights("PracticeRoomAdd")) {
        showErrorMessage(_msg_PracticeRoomsAdd);
        return false;
    }
    
    if ($.trim($("#divDialogNewPracticeRoom").html()).length == 0) {
        $.post(_SettingsPath + "/CallBacks/AddNewRoomDialogHandler.aspx", {}, function (data) {
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf("###End###");
            var returnHtml = $.trim(data.substring(start, end));
            
            $("#divDialogNewPracticeRoom").html(returnHtml).promise().done(function () {
                $("#divDialogNewPracticeRoom").dialog({
                    title: "Add New Practice Room",
                    modal: true,
                    width: "400",
                    height: "auto",
                    close: function () {
                        $(this).dialog("destroy");
                    }
                }); 
            });
        });
    }
    else {
        ResetPracticeRoomForm();
        
        $("#divDialogNewPracticeRoom").dialog({
            title: "Add New Practice Room",
            modal: true,
            width: "400",
            height: "auto",
            close: function () {
                $(this).dialog("destroy");
            }
        });
    }
}

var _roomNumber = "";

function EditPracticeRoom(elem, roomId) {
    if (!checkModuleRights("PracticeRoomEdit")) {
        showErrorMessage(_msg_PracticeRoomsEdit);
        return false;
    }
    
    _roomNumber = "";
    
    var CurrentRow = $(elem).closest("tr");
    
    _roomNumber = $.trim(CurrentRow.find(".spnRoomNo").html());
    var roomName = $.trim(CurrentRow.find(".spnRoomName").html());
    var roomTypeId = $.trim(CurrentRow.find(".hdnRoomTypeId").val());
    var practiceLocationId = $.trim(CurrentRow.find(".hdnPracticeLocationsId").val());
    
    $.post(_SettingsPath + "/CallBacks/AddNewRoomDialogHandler.aspx", {}, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#divDialogNewPracticeRoom").html(returnHtml).promise().done(function () {
            $("#divDialogNewPracticeRoom .hdnRoomId").val(roomId);
            $("#divDialogNewPracticeRoom .txtRoomName").val(roomName);
            $("#divDialogNewPracticeRoom .txtRoomNo").val(_roomNumber);
            $("#divDialogNewPracticeRoom .ddlRoomType").val(roomTypeId);
            $("#divDialogNewPracticeRoom .ddlPracticeLocation").val(practiceLocationId);
            
            $("#divDialogNewPracticeRoom").dialog({
                title: "Update Practice Room",
                modal: true,
                width: "400",
                height: "auto",
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        });
    });
}

function SavePracticeRoom() {
    if ($("#divDialogNewPracticeRoom .hdnRoomId").val() == 0) {
        if (!checkModuleRights("PracticeRoomAdd")) {
            showErrorMessage(_msg_PracticeRoomsAdd);
            return false;
        }
    }
    else {
        if (!checkModuleRights("PracticeRoomEdit")) {
            showErrorMessage(_msg_PracticeRoomsEdit);
            return false;
        }
    }
    
    if (!ValidateForm("tblAddNewPracticeRoom")) {
        showErrorMessage("");
        return false;
    }
    
    var objRoom = new Object();
    objRoom.RoomId = $.trim($("#divDialogNewPracticeRoom .hdnRoomId").val());
    objRoom.Name = $.trim($("#divDialogNewPracticeRoom .txtRoomName").val());
    objRoom.RoomNo = $.trim($("#divDialogNewPracticeRoom .txtRoomNo").val());
    objRoom.RoomTypeId = $.trim($("#divDialogNewPracticeRoom .ddlRoomType").val());
    objRoom.PracticeLocationsId = $.trim($("#divDialogNewPracticeRoom .ddlPracticeLocation").val());
    
 
    var isNameChanged = false;
    if (objRoom.RoomNo != _roomNumber) isNameChanged = true;
    
    var params = {
        Room: JSON.stringify(objRoom),
        isNameChanged: isNameChanged,
        action: "AddEdit"
    };
    
    $.post(_SettingsPath + "/CallBacks/AddEditPracticeRoomHandler.aspx", params, function (data) {
        var startCheckExist = data.indexOf("###StartAlreadyExist###") + 23;
        var endCheckExist = data.indexOf("###EndAlreadyExist###");
        var returnCheckExist = $.trim(data.substring(startCheckExist, endCheckExist));
        
        if (returnCheckExist == "Success") {
            var startAddNew = data.indexOf("###Start###") + 11;
            var endAddNew = data.indexOf("###End###");
            $("#gridContentsPracticeRooms").html(data.substring(startAddNew, endAddNew));
            
            if ($.trim($(".hdnRoomId").val()) == "0") {
                showSuccessMessage(_msg_Created);
            }
            else {
                showSuccessMessage(_msg_Updated);
            }
            
            var start = data.indexOf("###StartTotalRows###") + 20;
            var end = data.indexOf("###EndTotalRows###");
            var returnHtml = $.trim(data.substring(start, end));
            
            $("[id$='hdnPracticeRoomsTotalRows']").val(returnHtml);
            
            GeneratePracticeRoomsPagging();
            CloseDialogPracticeRoom();
        }
        else if (returnCheckExist == "Exist") {
            $("[id$='txtRoomNo']").addClass("error");
            showErrorMessage(_msg_RoomNoAlreadyExist);
        }
    });
}

function CloseDialogPracticeRoom() {
    $("#divDialogNewPracticeRoom").dialog("close");
}

function ResetPracticeRoomForm() {
    $("#divDialogNewPracticeRoom input[type='text']").val("");
    $("#divDialogNewPracticeRoom select").prop('selectedIndex', 0);
    $("#divDialogNewPracticeRoom .hdnRoomId").val(0);
}

function GeneratePracticeRoomsPagging() {
    GeneratePaging($("[id$='hdnPracticeRoomsTotalRows']").val(), 
    $("#ddlPagingPracticeRooms").val(), "gridPracticeRooms", "FilterPracticeRooms");
    
    if ($("[id$='hdnPracticeRoomsTotalRows']").val() > 0) {
        $("#gridPracticeRooms .spanInfo").html("Showing " + $("#gridContentsPracticeRooms tr:first").children().first().html() + " to " + $("#gridContentsPracticeRooms tr:last").children().first().html() + " of " + $("[id$='hdnPracticeRoomsTotalRows']").val() + " entries");
    }
    else {
        addNoRecordFoundMessage();
    }
}

function FilterPracticeRooms(pageNumber, paging) {
    if (!checkModuleRights("PracticeRoomView")) {
        showErrorMessage(_msg_PracticeRoomsView);
        return false;
    }
    
    var params = {
        RoomNo: $.trim($("#txtRoomNofilter").val()),
        RoomName: $.trim($("#txtRoomNamefilter").val()),
        RoomTypeId: $.trim($("[id$='ddlRoomTypeFilter']").val()),
        PracticeLocationsId: $.trim($("[id$='ddlPracticeLocationFilter']").val()),
        Rows: $("#ddlPagingPracticeRooms").val(),
        PageNumber: pageNumber,
        SortBy: ""
    };
    
    $.post(_SettingsPath + "/CallBacks/PracticeRoomFilterHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartTotalRows###") + 20;
        var end = data.indexOf("###EndTotalRows###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("[id$='hdnPracticeRoomsTotalRows']").val(returnHtml);
        
        start = data.indexOf("###Start###") + 11;
        end = data.indexOf("###End###");
        returnHtml = $.trim(data.substring(start, end));
        
        $("#gridContentsPracticeRooms").html(returnHtml).promise().done(function () {
            GeneratePracticeRoomsPagging();
        });
    });
}

var _currentRoomId;

function DeletePracticeRoom(roomId) {
    if (!checkModuleRights("PracticeRoomDelete")) {
        showErrorMessage(_msg_PracticeRoomsDelete);
        return false;
    }
    
    _currentRoomId = roomId;
    showConfirmDialog(_msg_Deleted_Confirmation, "practiceRoomdelete();");
}

function practiceRoomdelete() {
    if (!checkModuleRights("PracticeRoomDelete")) {
        showErrorMessage(_msg_PracticeRoomsDelete);
        return false;
    }

    $.post(_SettingsPath + "/CallBacks/AddEditPracticeRoomHandler.aspx", { RoomId: _currentRoomId, action: "Delete" }, function (data) {
        var startAddNew = data.indexOf("###Start###") + 11;
        var endAddNew = data.indexOf("###End###");
        $("#gridContentsPracticeRooms").html(data.substring(startAddNew, endAddNew));
        
        var start = data.indexOf("###StartTotalRows###") + 20;
        var end = data.indexOf("###EndTotalRows###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("[id$='hdnPracticeRoomsTotalRows']").val(returnHtml);
        
        GeneratePracticeRoomsPagging();
        showSuccessMessage((_msg_Deleted));
    });
}

function addNoRecordFoundMessage() {
    var html = "<span style='color: red; font-size: 14px; font-weight: bold; font-style: italic;'>No Record Found</span>";
    $("#gridPracticeRooms div.message").find(".spanInfo").html(html);

}
/************************************** END Practice Rooms ***********************************/