

function ShowHideAdvancedSig() {
    $("#divAdvancedSigWrapper").animate({ height: 'toggle' });
}

function SavePatientPrescription() {
    var objPatientPrescription = new Object();
    
    objPatientPrescription.PhysicianId = $("[id$='ddlProvider_POC']").val();
    objPatientPrescription.PrescriptionType = $("[id$='ddlType']").val();
    objPatientPrescription.PharmacyId = $("[id$='hdnPharmacyId']").val();
    objPatientPrescription.MedicineTrade = $("[id$='txtSearchMedicine']").val();
    objPatientPrescription.Sig = $("[id$='hovertxtSig']").val();
    objPatientPrescription.Refill = $("[id$='hovertxtRefills']").val();
    objPatientPrescription.Status_Comments = $("[id$='txtProviderComments']").val();
    objPatientPrescription.Active = $("[id$='chkPrescriptionActive']").is(":checked");
    objPatientPrescription.IsConfidential = $("[id$='chkConfedential']").is(":checked");
    objPatientPrescription.PrescriptionReviewed = $("[id$='chkPrescriptionReviewed']").is(":checked");
    objPatientPrescription.Substitute = $("[id$='chkSubstitution']").is(":checked");

    objPatientPrescription.OverrideAdverse = $("[id$='chkOverriderAdverse']").is(":checked");
    objPatientPrescription.OverrideReason = $("[id$='txtOverrideReason']").val();
    
    
    var action = "ADD";
    var PatientPrescriptionId = $("[id$='hdnPatientPrescriptionId']").val();
    var PatientId = $("[id$='PatientId']").val();
    
    if (PatientPrescriptionId != "") {
        objPatientPrescription.PatientPrescriptionId = PatientPrescriptionId;
        action = "UPDATE";
    }
    
    if (PatientId != "") {
        objPatientPrescription.PatientId = PatientId;
    }
    
    var isValidate = validatePatientPrescriptionForm(objPatientPrescription);
    
    if (isValidate) {
        $.post("CallBacks/PatientPrescriptionHandler.aspx", { objPatientPrescription: JSON.stringify(objPatientPrescription), action: action }, function (data) {
            var returnHtml = data;
            alert("Success: Patient Prescription Saved.");
        });
    }
}

function validatePatientPrescriptionForm(objPatientPrescription) {
    return true;
}


function openDoseCalculator() {
    $("#divDoseCalculator").dialog({
        title: "Weight Base Dose Calculator",
        modal: true,
        width: 520,
        buttons: {
            "Calculate": function () {
                CalculateDose();
            },
            "Clear": function () {
                ClearDoseCalculator();
            },
            "Close": function () {
                $("#divDoseCalculator").dialog("close");
            }
        },
        close: function () {
            $("#divDoseCalculator").dialog("destroy");
        }
    });
}

function CalculateDose() {
    if ($("#txtDose").val() == "") {
        alert("Enter Dose.");
        $("#txtDose']").focus();
        return false;
    }
    if (!parseFloat($("#txtDose").val())) {
        alert("Enter valid Dose.");
        $("input[id$='txtDose']").focus();
        return false;
    }
    if ($("#txtWeight").val() == "") {
        alert("Enter the Patient Weight.");
        $("#txtWeight").focus();
        return false;
    }
    if (!parseFloat($("#txtWeight").val())) {
        alert("Enter valid Patient Weight.");
        $("#txtWeight").focus();
        return false;
    }
    var strUnit = $("#ddlMeasurement").val();
    if (strUnit != "")
        strUnit += " /Day";
    $("#txtResult").val((parseFloat($("#txtWeightKg").val()) * $("#txtDose").val()).toFixed(2) + ' ' + strUnit);
    return false;
}

function ClearDoseCalculator() {
    $("#txtDose").val('');
    $("#ddlMeasurement").val('');
    $("#txtWeight").val('');
    $("#txtWeightKg").val('');
    $("#txtResult").val('');
}