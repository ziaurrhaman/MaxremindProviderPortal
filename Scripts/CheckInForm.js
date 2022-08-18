
$(document).on("mouseenter", ".div-insurance-cards-inner", function () {
    $(this).find(".hover-action-div").show();
});

$(document).on("mouseleave", ".div-insurance-cards-inner", function () {
    $(this).find(".hover-action-div").hide();
});

var _PracticeLocationsIdCheckInForm = 0;
var AppointmentIdCheckInForm, CheckInRoomIdCheckInForm, StatusIdCheckInForm, elemCheckInForm, appStatusCheckInForm, isExpireTimeCheckInForm, PatientIdCheckInForm;

function OpenCheckInForm(AppointmentId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime, PatientId) {
    debugger;
    AppointmentIdCheckInForm = AppointmentId;
    CheckInRoomIdCheckInForm = CheckInRoomId;
    StatusIdCheckInForm = StatusId;
    elemCheckInForm = elem;
    appStatusCheckInForm = appStatus;
    isExpireTimeCheckInForm = isExpireTime;
    PatientIdCheckInForm = PatientId;

    _PatientId = PatientId;
    
    _PracticeLocationsIdCheckInForm = $("[id$='ddLocationMain']").val();

    var params = {
        PatientId: PatientId,
        PracticeLocationsId: _PracticeLocationsIdCheckInForm,
        action: "LoadCheckInForm"
    };

    $.post("../../ProviderPortal/Controls/CheckedInPatientForm.aspx", params, function (data) {
        debugger
        var start = data.indexOf("###StartForm###") + 15;
        var end = data.indexOf("###EndForm###");
        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='divDialogCheckInForm']").html(returnHtml)
        .promise()
        .done(function () {
            debugger;
            DoneCheckInFormOpen();
        });
    });
}

function DoneCheckInFormOpen() {
    debugger;
    var CurrentTimeOfLocation = GetPracticeLocationCurrentTimeUTC(_PracticeLocationsIdCheckInForm, "Time24");
    
    $("[id$='divDialogCheckInForm'] input[name='txtCheckInTimeCheckInForm']").val(CurrentTimeOfLocation);

   // onPageLoadCheckInForm();
    
    $("[id$='divCheckInFormInner']").css("height", ((WindowHeight() - 100) + "px"));
    
    $("[id$='divDialogCheckInForm']").dialog({
        title: "Check In Form",
        modal: true,
        width: "auto",
        height: 350,
        close: function () {
            $("[id$='divDialogCheckInForm']").dialog("destroy");
        }
    });
}

function ShowHideTabsCheckInForm(elem, InsuranceType) {
    $(elem).siblings().removeClass("active");
    $(elem).addClass("active");
    
    $(".patient-insurances-forms").hide();
    
    if (InsuranceType == "P") {
        $("[id$='divPatientPrimaryInsuranceCheckInForm']").show();
    }
    else {
        $("[id$='divPatientSecondaryInsuranceCheckInForm']").show();
    }
}

function ShowHideInsuranceCardFrontBack(elem, FrontBack) {
    var CurrentCardsWrapper = $(elem).closest(".insurance-cards-main-wrapper");
    
    CurrentCardsWrapper.find(".insurance-cards").hide();
    
    if (FrontBack == "F") {
        CurrentCardsWrapper.find(".insurance-cards-front").show();
    }
    else if (FrontBack == "B") {
        CurrentCardsWrapper.find(".insurance-cards-back").show();
    }
}

function SetScannedFile(HTTPPostResponseString) {
    var filePath = _PracticeDocumentsPath + "/" + _PracticeId + "/" + "Patients/Documents/" + HTTPPostResponseString;
    
    var CurrentVisibleCardWrapper = $(".insurance-cards:visible");
    
    CurrentVisibleCardWrapper.find(".hdnInsuranceCardFilePath").val(filePath);
    
    CurrentVisibleCardWrapper.find(".image-insurance-cards").attr("src", filePath);
    CurrentVisibleCardWrapper.find(".div-insurance-cards-inner").show();
}

function DeleteInsuranceCard(elem) {

}

function DownloadInsuranceCard(elem) {

}

function SaveCheckInForm() {
    var objCheckedInPatients = new Object();
    
    objCheckedInPatients.RoomId = $("[id$='ddlPracticeRoomsCheckInForm']").val();
    
    objCheckedInPatients.ArrivalTime = $.trim($("[id$='txtCheckInTimeCheckInForm']").val());
    objCheckedInPatients.CheckInTime = $.trim($("[id$='txtCheckInTimeCheckInForm']").val());


    var objPatientInsurancePrimary = new Object();

    objPatientInsurancePrimary.PatientInsuranceId = $.trim($("[id$='hdnPatientPrimaryInsuranceIdCheckInForm']").val());
    if (objPatientInsurancePrimary.PatientInsuranceId == "") objPatientInsurancePrimary.PatientInsuranceId = 0;
    
    objPatientInsurancePrimary.InsuranceCardFrontFilePath = $("[id$='hdnPrimaryInsuranceCardFrontFilePath']").val();
    objPatientInsurancePrimary.InsuranceCardBackFilePath = $("[id$='hdnPrimaryInsuranceCardBackFilePath']").val();


    var objPatientInsuranceSecondary = new Object();

    objPatientInsuranceSecondary.PatientInsuranceId = $.trim($("[id$='hdnPatientSecondaryInsuranceIdCheckInForm']").val());
    if (objPatientInsuranceSecondary.PatientInsuranceId == "") objPatientInsuranceSecondary.PatientInsuranceId = 0;

    objPatientInsuranceSecondary.InsuranceCardFrontFilePath = $("[id$='hdnSecondaryInsuranceCardFrontFilePath']").val();
    objPatientInsuranceSecondary.InsuranceCardBackFilePath = $("[id$='hdnSecondaryInsuranceCardBackFilePath']").val();

    var params = {
        objCheckedInPatients: JSON.stringify(objCheckedInPatients),
        objPatientInsurancePrimary: JSON.stringify(objPatientInsurancePrimary),
        objPatientInsuranceSecondary: JSON.stringify(objPatientInsuranceSecondary),
        action: "SaveForm"
    };
    
    CheckInRoomIdCheckInForm = $("[id$='ddlPracticeRoomsCheckInForm']").val();

    AppointmentUpdateStatus(
        AppointmentIdCheckInForm,
        CheckInRoomIdCheckInForm,
        StatusIdCheckInForm,
        elemCheckInForm,
        appStatusCheckInForm,
        isExpireTimeCheckInForm,
        PatientIdCheckInForm,
        objCheckedInPatients,
        objPatientInsurancePrimary,
        objPatientInsuranceSecondary
    );

    CloseCheckInForm();
}

function CloseCheckInForm() {
    $("[id$='divDialogCheckInForm']").dialog("close");
}

function EditPatientInsuraceCheckInForm(elem, InsuranceType) {
    debugger;
    _InsuranceTypeMaster = InsuranceType;
    _InsuranceFormCallFrom = "CheckInForm";

    var PatientInsuranceId;

    if (InsuranceType == "P") {
        PatientInsuranceId = $("[id$='hdnPatientPrimaryInsuranceIdCheckInForm']").val();
    }
    else {
        PatientInsuranceId = $("[id$='hdnPatientSecondaryInsuranceIdCheckInForm']").val();
    }
    
    var params = {
        PatientId: _PatientId,
        PatientInsuranceId: PatientInsuranceId,
        action: "LoadPatientInsurance"
    };
    debugger
    PatientInsurance_OpenForm(params);
}

function SetInsuranceOnCheckInForm(objPatientInsurance, data) {
    var start = data.indexOf("###StartPatientInsuranceId###") + 29;
    var end = data.indexOf("###EndPatientInsuranceId###");
    var PatientInsuranceId = $.trim(data.substring(start, end));
    
    var InsuranceName = $("[id$='txtPatientInsuranceWalkout']").val();
    
    if (_InsuranceTypeMaster == "P") {
        $("[id$='lblPrimaryInsuranceNameCheckInForm']").html(InsuranceName);
        $("[id$='lblPrimaryInsurancePolicyNumberCheckInForm']").html(objPatientInsurance.PolicyNumber);
        $("[id$='lblPrimaryInsuranceGroupNumberCheckInForm']").html(objPatientInsurance.GroupNumber);
        $("[id$='lblPrimaryInsuranceGroupNameCheckInForm']").html(objPatientInsurance.GroupName);

        $("[id$='lblPrimaryInsuranceCopayCheckInForm']").html(objPatientInsurance.CoPay);
        $("[id$='lblPrimaryInsuranceCopayTypeCheckInForm']").html(objPatientInsurance.CoPayType);
        $("[id$='lblPrimaryInsuranceCoinsuranceCheckInForm']").html(objPatientInsurance.CoInsurance);
        $("[id$='lblPrimaryInsuranceCoinsuranceTypeCheckInForm']").html(objPatientInsurance.CoInsuranceType);
        $("[id$='lblPrimaryInsuranceDeductableCheckInForm']").html(objPatientInsurance.Deductable);
        $("[id$='lblPrimaryInsuranceDeductableTypeCheckInForm']").html(objPatientInsurance.DeductableType);

        $("[id$='lblPrimaryInsuranceRelationshipCheckInForm']").html(objPatientInsurance.Relationship);

        var SubsriberLastName = $.trim($("[id$='txtSubscriberLastNameWalkout']").val());
        var SubsriberFirstName = $.trim($("[id$='txtSubscriberFirstNameWalkout']").val());

        $("[id$='lblPrimaryInsuranceSubscriberLastNameCheckInForm']").html(SubsriberLastName);
        $("[id$='lblPrimaryInsuranceSubscriberFirstNameCheckInForm']").html(SubsriberFirstName);
    }
    else if (_InsuranceTypeMaster == "S") {
        $("[id$='lblSecondaryInsuranceNameCheckInForm']").html(InsuranceName);
        $("[id$='lblSecondaryInsurancePolicyNumberCheckInForm']").html(objPatientInsurance.PolicyNumber);
        $("[id$='lblSecondaryInsuranceGroupNumberCheckInForm']").html(objPatientInsurance.GroupNumber);
        $("[id$='lblSecondaryInsuranceGroupNameCheckInForm']").html(objPatientInsurance.GroupName);

        $("[id$='lblSecondaryInsuranceCopayCheckInForm']").html(objPatientInsurance.CoPay);
        $("[id$='lblSecondaryInsuranceCopayTypeCheckInForm']").html(objPatientInsurance.CoPayType);
        $("[id$='lblSecondaryInsuranceCoinsuranceCheckInForm']").html(objPatientInsurance.CoInsurance);
        $("[id$='lblSecondaryInsuranceCoinsuranceTypeCheckInForm']").html(objPatientInsurance.CoInsuranceType);
        $("[id$='lblSecondaryInsuranceDeductableCheckInForm']").html(objPatientInsurance.Deductable);
        $("[id$='lblSecondaryInsuranceDeductableTypeCheckInForm']").html(objPatientInsurance.DeductableType);

        $("[id$='lblSecondaryInsuranceRelationshipCheckInForm']").html(objPatientInsurance.Relationship);

        var SubsriberLastName = $.trim($("[id$='txtSubscriberLastNameWalkout']").val());
        var SubsriberFirstName = $.trim($("[id$='txtSubscriberFirstNameWalkout']").val());

        $("[id$='lblSecondaryInsuranceSubscriberLastNameCheckInForm']").html(SubsriberLastName);
        $("[id$='lblSecondaryInsuranceSubscriberFirstNameCheckInForm']").html(SubsriberFirstName);
    }
}

