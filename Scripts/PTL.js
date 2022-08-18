

/*Start PTL Common Section*/

function PTL_GetActionParamsByPTLType(PTLType) {
    if (PTLType == "Patient") {
        return {
            PTLType: PTLType,
            PatientId: _PatientId,
            action: "LoadForm"
        };
    }
    else if (PTLType == "Claim") {
        return {
            PTLType: PTLType,
            ClaimId: _ClaimId,
            action: "LoadForm"
        };
    }
}

function PTL_SetForm(PTLType) {
    var strPatientPTLReasons = $.trim($("[id$='hdnPTLReasons" + PTLType + "']").val());
    
    var arrPatientPTLReasons = strPatientPTLReasons.split(',');
    
    for (var i = 0; i < arrPatientPTLReasons.length; i++) {
        $("[id$='chk" + PTLType + "PTLReasonsId" + arrPatientPTLReasons[i] + "']").prop("checked", true);
    }
}

function PTL_CloseForm() {
    $("#divContainerOutSideForm").dialog("close");
}

function PTL_ResolveStatus(IsDialog, PTLType) {
    var params;
    
    if (PTLType == "Patient") {
        params = {
            PTLType: PTLType,
            PatientId: _PatientId,
            action: "ResolveStatus"
        };
    }
    else if (PTLType == "Claim") {
        params = {
            PTLType: PTLType,
            ClaimId: _ClaimId,
            action: "ResolveStatus"
        };
    }
    
    $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
        showSuccessMessage(_msg_Updated);
        
        $("[id$='chkIsPTL']").prop("checked", false);
        
        if (IsDialog) {
            PTL_CloseForm();
        }
    });
}

function PTL_Save_Done(PTLType) {
    showSuccessMessage(_msg_Updated);
    PTL_CloseForm();
    
    $("[id$='chkIsPTL']").prop("checked", true);
}

/*End PTL Common Section*/


/*Start PTL Patient Section*/
function PTL_Click_CheckBox_Patient(elem, PTLType) {
    if ($(elem).is(":checked")) {
        var params = PTL_GetActionParamsByPTLType(PTLType);
        
        $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
            if (PTLType == "Patient") {
                PTL_OpenForm_Patient(data);
            }
        });
    }
    else {
        var Message = "Do you want to set PTL status as resolved?";
        
        ShowConfirmation(Message).done(function () {
            PTL_ResolveStatus(false, PTLType);
        }).fail(function () {
            $(elem).prop("checked", true);
        });
    }
}

function PTL_Click_Patient(elem, PTLType) {
    var params = PTL_GetActionParamsByPTLType(PTLType);
    
    $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
        if (PTLType == "Patient") {
            PTL_OpenForm_Patient(data);
        }
    });
}

function PTL_OpenForm_Patient(data) {
    var start = data.indexOf("###StartFormPatient###") + 22;
    var end = data.indexOf("###EndFormPatient###");
    var returnHtml = $.trim(data.substring(start, end));
    
    $("#divContainerOutSideForm").html(returnHtml)
    .promise()
    .done(function () {
        PTL_SetForm("Patient");
        
        $("#divContainerOutSideForm").dialog({
            madal: true,
            title: "PTL Reasons",
            width: 400,
            close: function () {
                $(this).dialog("destroy");
            }
        });
    });
}

function PTL_Save_Patient() {
    var strPTLReasons = "";
    
    $("#divPTLResonsFormPatient .chkReason:checked").each(function () {
        strPTLReasons += $(this).parent().find(".hdnPTLReasonsId").val() + ",";
    });
    
    if (strPTLReasons.length > 1) {
        strPTLReasons = strPTLReasons.slice(0, -1);
    }
    
    var objPatient = new Object();
    
    objPatient.PatientId = _PatientId;
    
    objPatient.IsPTL = true;
    objPatient.PTLReasons = strPTLReasons;
    objPatient.PTLNotes = $.trim($("[id$='txtPTLNotesPatient']").val());
    
    var params = {
        objPatient: JSON.stringify(objPatient),
        action: "SavePTLPatient"
    };
    
    $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
        PTL_Save_Done("Patient");
    });
}
/*End PTL Patient Section*/




/*Start PTL Claim Section*/
function PTL_Click_CheckBox_Claim(elem, PTLType) {
    if ($(elem).is(":checked")) {
        var params = PTL_GetActionParamsByPTLType(PTLType);

        $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
            PTL_OpenForm_Claim(data);
        });
    }
    else {
        var Message = "Do you want to set PT status as resolved?";

        ShowConfirmation(Message).done(function () {
            PTL_ResolveStatus(false, "Claim");
        }).fail(function () {
            $(elem).prop("checked", true);
        });
    }
}

function PTL_Click_Claim(elem, PTLType) {
    if (_ClaimId == 0) {
        return;
    }
    
    var params = PTL_GetActionParamsByPTLType(PTLType);
    
    $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
        PTL_OpenForm_Claim(data);
    });
}

function PTL_OpenForm_Claim(data) {
    var start = data.indexOf("###StartFormClaim###") + 20;
    var end = data.indexOf("###EndFormClaim###");
    var returnHtml = $.trim(data.substring(start, end));
    
    $("#divContainerOutSideForm").html(returnHtml)
    .promise()
    .done(function () {
        PTL_SetForm("Claim");
        
        $("#divContainerOutSideForm").dialog({
            madal: true,
            title: "PTL Reasons",
            width: 400,
            close: function () {
                $(this).dialog("destroy");
            }
        });
    });
}

function PTL_Save_Claim() {
    var strPTLReasons = "";
    
    $("#divPTLResonsFormClaim .chkReason:checked").each(function () {
        strPTLReasons += $(this).parent().find(".hdnPTLReasonsId").val() + ",";
    });
    
    if (strPTLReasons.length > 1) {
        strPTLReasons = strPTLReasons.slice(0, -1);
    }
    
    var objClaim = new Object();
    
    objClaim.ClaimId = _ClaimId;
    
    objClaim.IsPTL = true;
    objClaim.PTLReasons = strPTLReasons;
    objClaim.PTLNotes = $.trim($("[id$='txtPTLNotesClaim']").val());
    
    var params = {
        objClaim: JSON.stringify(objClaim),
        action: "SavePTLClaim"
    };
    
    $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
        PTL_Save_Done("Claim");
    });
}
/*End PTL Claim Section*/