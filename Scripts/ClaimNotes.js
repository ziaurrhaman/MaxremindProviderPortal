

var _ClaimNotesId = 0;

function ClaimNotes_LoadNotes() {
    var params = {
        ClaimId: _ClaimId,
        action: "LoadNotes"
    };
    
    $.post(_ControlPath + "/ClaimNotes.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#divClaimNotesMain").html(returnHtml)
        .promise()
        .done(function () {
            ClaimNotes_SetNotesRecords(data);
            $("[id$='divClaimNotesMain']").show();
        });
    });
}

function ClaimNotes_SetNotesRecords(data) {
    var start = data.indexOf("###StartRecords###") + 18;
    var end = data.indexOf("###EndRecords###");
    var returnHtml = $.trim(data.substring(start, end));
    
    $("#tbodyClaimNotes").html(returnHtml);
}

function ClaimNotes_OpenForm() {
    $("#divDialogClaimNotesForm").dialog({
        title: "Add/Edit Claim Notes",
        modal: true,
        width: "500",
        close: function () {
            ClaimNotes_CloseForm();
        }
    });
}

function ClaimNotes_CloseForm() {
    ClaimNotes_ResetForm();
    $("#divDialogClaimNotesForm").dialog("destroy");
}

function ClaimNotes_ResetForm() {
    _ClaimNotesId = 0;

    $("[id$='ddlClaimNoteCategories']").val(0);
    $("[id$='txtClaimNotes']").val("");
}

function ClaimNotes_SaveForm() {
    var objClaimNotes = new Object();
    
    objClaimNotes.ClaimNotesId = _ClaimNotesId;
    
    objClaimNotes.ClaimId = _ClaimId;
    objClaimNotes.PatientId = _PatientId;
    
    objClaimNotes.ClaimNoteCategoriesId = $("[id$='ddlClaimNoteCategories']").val();
    objClaimNotes.Notes = $.trim($("[id$='txtClaimNotes']").val());
    
    var params = {
        ClaimId: _ClaimId,
        objClaimNotes: JSON.stringify(objClaimNotes),
        action: "SaveNotes"
    };
    
    $.post(_ControlPath + "/ClaimNotes.aspx", params, function (data) {
        if (objClaimNotes.ClaimNotesId == 0) {
            showSuccessMessage(_msg_Created);
        }
        else {
            showSuccessMessage(_msg_Updated);
        }
        
        ClaimNotes_SetNotesRecords(data);
        ClaimNotes_CloseForm();
    });
}

function ClaimNotes_Edit(elem) {
    var CurrentRow = $(elem).closest("tr");
    
    _ClaimNotesId = CurrentRow.find(".hdnClaimNotesId").val();
    
    var ClaimNoteCategoriesId = CurrentRow.find(".hdnClaimNoteCategoriesId").val();
    var Notes = $.trim(CurrentRow.find(".spnNotes").html());
    
    $("[id$='ddlClaimNoteCategories']").val(ClaimNoteCategoriesId);
    $("[id$='txtClaimNotes']").val(Notes);
    
    ClaimNotes_OpenForm();
}

function ClaimNotes_Delete(elem) {
    ShowConfirmation(_msg_Deleted_Confirmation).done(function () {
        ClaimNotes_ConfirmDelete(elem);
    });
}

function ClaimNotes_ConfirmDelete(elem) {
    var CurrentRow = $(elem).closest("tr");
    
    _ClaimNotesId = CurrentRow.find(".hdnClaimNotesId").val();
    
    var params = {
        ClaimNotesId: _ClaimNotesId,
        action: "DeleteNotes"
    };
    
    $.post(_ControlPath + "/ClaimNotes.aspx", params, function (data) {
        CurrentRow.remove();
        
        showSuccessMessage(_msg_Deleted);
    });
}