

$(document).ready(function () {
    Initialize_PTL_Patient();
    Initialize_PTL_Claim();

    SetPTLReasons("Patient");
    SetPTLReasons("Claim");
});

function HideShowPTLDivs(divToShow) {
    $(".ptl-main-divs").hide();
    $("#" + divToShow).show();
}

function SelectUnselectPTLReasons_All(elem) {
    var IsAllChecked = $(elem).is(":checked");
    
    $(elem).closest("ul").find("input[type='checkbox']").not($(elem)).prop("checked", IsAllChecked);
}

function SelectUnselectPTLReasons(elem) {
    var CurrentUL = $(elem).closest("ul");

    var AllLength = CurrentUL.find(".chkReason").length;
    var CheckedLength = CurrentUL.find(".chkReason:checked").length;

    CurrentUL.find(".chkPTLReasonsAll").prop("checked", (AllLength == CheckedLength));
}

function OkMultiCheckDropDownPTLReason(elem, PTLType) {
    if (PTLType == "Patient") {
        FilterPatient(0, true);
    }
    else if (PTLType == "Claim") {
        FilterClaims(0, true);
    }

    HideShowPTLReasonDropDown(elem);
}

function HideShowPTLReasonDropDown(elem) {
    var dropdownDivMainWrapper = $(elem).closest(".dropdownMenuMultiCheckMainWrapper");

    if (dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").is(":visible")) {
        dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").hide();
    }
    else {
        dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").show();
    }
}

function GetPTLReasons(ReasonUl) {
    var strPTLReasons = "";
    
    $("#" + ReasonUl + " .chkReason:checked").each(function () {
        strPTLReasons += $(this).parent().find(".hdnPTLReasonsId").val() + ",";
    });

    if (strPTLReasons.length > 1) {
        strPTLReasons = strPTLReasons.slice(0, -1);
    }

    return strPTLReasons;
}

function SetPTLReasons(PTLType) {
    var PTLReason, strPTLReasons = "", arrPTLReasons;

    $("#tbodyPTL" + PTLType + " .tdPTLReasons").each(function () {
        strPTLReasons = $.trim($(this).find("span").html());

        if (strPTLReasons != "") {
            arrPTLReasons = strPTLReasons.split(',');

            strPTLReasons = "";

            for (var i = 0; i < arrPTLReasons.length; i++) {
                PTLReason = $.trim($("[id$='chk" + PTLType + "PTLReasonsId" + arrPTLReasons[i] + "']").parent().find(".spnReason").html());

                strPTLReasons += PTLReason + ", ";
            }
            
            if (strPTLReasons.length > 1) {
                strPTLReasons = strPTLReasons.slice(0, -2);
            }
        }
        else {
            strPTLReasons = $.trim($(this).find(".hdnPTLNotes").val());
        }

        $(this).html(strPTLReasons);
    });
}

function Click_PTL_Row(elem, PTLType) {
    if (PTLType == "Patient") {
        var PatientId = $(elem).find(".hdnPatientId").val();
        window.location = _PatientPath + "/Demographics.aspx?PatientId=" + PatientId;
    }
    else if (PTLType == "Claim") {
        var ClaimId = $(elem).find(".hdnClaimId").val();
        var PatientId = $(elem).find(".hdnPatientId").val();

        window.location = _ClaimPath + "/BillingManager.aspx?ClaimId=" + ClaimId + "&PatientId=" + PatientId;
    }
}