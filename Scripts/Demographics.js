function openAddInsuranceDialogue() {

    clearfields();
    $("#Add-or-EditInsuranceDiv").dialog({

        resizable: false,
        title: 'Insurance',
        width: '85%',
        modal: true,
        buttons: {
            "Save/Update": function () {
                if ($("[id$='txtPrimaryPolicyNo']").val() == "") { showErrorMessage("enter policy number"); return; }
                if ($("[id$='ddlInsuranceType']").val() == "T") {
                    if ($("[id$='txtPrimaryTerminationDate']").val() == "") {
                        //showErrorMessage("Termination Date is required for Terminated Insurance Type");
                        $("[id$='txtPrimaryTerminationDate']").css("border-color", "RED");
                        return;
                    }

                }
                $("[id$='txtPrimaryTerminationDate']").css("border-color", "#c4c4c4");
                if (getInsuranceData(this) == 0) { }
                else { $(this).dialog("destroy"); }
            },
            "Cancel": function () { $(this).dialog("destroy"); clearfields(); }
        }
    });
}

function getInsuranceData(elem) {
    var isPrimaryTrue = checkPrimaryInsurance();
    if (isPrimaryTrue == "true") {
        $("#PrimaryInsuranceAlreadyPresent").dialog({
            resizable: false,
            title: 'Insurance',
            width: '40%',
            modal: true,
            buttons: {
                "OK": function () { $(this).dialog("destroy"); },

            }
        });
        return 0;
    }
    var InsuranceType = $("[id$='ddlInsuranceType']").find(":selected").val();


    var Insurance = new Object();


    //................................
    Insurance.PatientInsuranceId = $("[id$='hdnPrimaryInsuranceId']").val() == "" ? 0 : $("[id$='hdnPrimaryInsuranceId']").val();
    Insurance.PatientId = _PatientId;

    //generel

    Insurance.InsuranceId = $("[id$='hdnInsuranceId']").val();
    Insurance.PolicyNumber = $("[id$='txtPrimaryPolicyNo']").val();
    Insurance.GroupNumber = $("[id$='txtPrimaryGroupNo']").val();
    Insurance.GroupName = $("[id$='txtPrimaryGroupName']").val();
    Insurance.EffectiveDate = $("[id$='txtPrimaryEffectiveDate']").val();
    Insurance.TerminationDate = $("[id$='txtPrimaryTerminationDate']").val();
    //...

    //financila information
    Insurance.CoPay = $("[id$='txtPrimaryCopay']").val();
    Insurance.CoPayType = $("[id$='ddlPrimaryCoPayType']").find(":selected").val();
    Insurance.CoInsurance = $("[id$='txtPrimaryCoInsurance']").val();
    Insurance.CoInsuranceType = $("[id$='ddlPrimaryCoInsuranceType']").find(":selected").val();
    Insurance.Deductable = $.trim($("[id$='txtPrimaryDeductable']").val()) == "" ? 0 : $.trim($("[id$='txtPrimaryDeductable']").val());
    Insurance.DeductableType = $("[id$='ddlPrimaryDeductableType']").find(":selected").val();
    //......

    //Insurance Type
    Insurance.PriSecOthType = $("[id$='ddlInsuranceType']").find(":selected").val();
    //......

    //Subscriber....
    Insurance.Relationship = $("[id$='ddlPrimaryRelationship']").find(":selected").val();
    Insurance.SubscriberId = $("[id$='hdnPrimarySubscriberId']").val();

    if (Insurance.PatientInsuranceId == 0) {
        //Insurance.CreatedById
        //Insurance.CreatedDate
    }
    else {
        //Insurance.ModifiedById
        //     Insurance.ModifiedDate = Date.now();
    }
    debugger;
    $.post("CallBacks/AddEditPatientInsurance.aspx", { Insurance: JSON.stringify(Insurance), Action: "Add/Edit" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        returnHtml = $.trim(data.substring(start, end));

        $("[id$='insuranceTbody']").html(returnHtml);
    }).promise().done(
    function () { typeshow(); }
    );
}

function loadInsurances() {
    debugger;
    $.post("CallBacks/AddEditPatientInsurance.aspx", { Action: "loadInsurance", Patientid: _PatientId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        returnHtml = $.trim(data.substring(start, end));

        $("[id$='insuranceTbody']").html(returnHtml);
    }).promise().done(
    function () { typeshow(); }
    );

}

function typeshow() {
    // alert($("[id$='insuranceTbody']").children('tr').length);
    $("[id$='insuranceTbody']").children('tr').each(function () {
        var t = $.trim($(this).find('td').eq(1).html());

        if (t == 'P') { $(this).find('td').eq(2).html("Primary") }
        else if (t == 'O') { $(this).find('td').eq(2).html("Other") }
        else if (t == 'S') { $(this).find('td').eq(2).html("Secoundary") }
        else if (t == 'T') { $(this).find('td').eq(2).html("Terminated") }
        else { $(this).find('td').eq(2).html("None") }
    });

}

function CheckForPolicyNumber() {
    var PrimaryInsuranceId = $.trim($("[id$='hdnPrimaryInsuranceId']").val());
    var SecondaryInsuranceId = $.trim($("[id$='hdnSecondaryInsuranceId']").val());
    var OtherInsuranceId = $.trim($("[id$='hdnOtherInsuranceId']").val());

    var PrimaryPolicyNo = $.trim($("[id$='txtPrimaryPolicyNo']").val());
    var SecondaryPolicyNo = $.trim($("[id$='txtSecondaryPolicyNo']").val());
    var OtherPolicyNo = $.trim($("[id$='txtOtherPolicyNo']").val());

    if (PrimaryInsuranceId == SecondaryInsuranceId && PrimaryInsuranceId != "0" && SecondaryInsuranceId != "0") {
        if (PrimaryPolicyNo == SecondaryPolicyNo) {
            showErrorMessage("Policy No. of Primary Insurance and Secondary Insurance are same. When two insurances are same, you cannot enter same policy number.");
            return false;
        }
    }
    else if (PrimaryInsuranceId == OtherInsuranceId && PrimaryInsuranceId != "0" && OtherInsuranceId != "0") {
        if (PrimaryPolicyNo == OtherPolicyNo) {
            showErrorMessage("Policy No. of Primary Insurance and Other Insurance are same. When two insurances are same, you cannot enter same policy number.");
            return false;
        }
    }
    else if (SecondaryInsuranceId == OtherInsuranceId && SecondaryInsuranceId != "0" && OtherInsuranceId != "0") {
        if (SecondaryPolicyNo == OtherPolicyNo) {
            showErrorMessage("Policy No. of Secondary Insurance and Other Insurance are same. When two insurances are same, you cannot enter same policy number.");
            return false;
        }
    }

    return true;
}

var _PatientId = 0
$(document).ready(function () {

    _PatientId = getQuerystring("PatientId");
    if (_PatientId == 0) { openEditPatientForm(); }
    else {
        LoadPatientInformation("ViewForm")
    }
    //loadInsurances();
    $(".date").datepicker({
        changeMonth: true,
        changeYear: true,
        //maxDate: new Date()
    }).mask("99/99/9999");

    if ($(".trpatientpayments").find('tr').length == 0) {
        $(".trpatientpayments").html("<span style='color:red'> No patient payment received</span>")
    }

    var value = $("[id$='lblBalanceDue']").text();
    if (value != "N/A" && value != "$0.00") { $("[id$='lblBalanceDue']").addClass("classtextblue"); }


});

$("#chkIsfile ").attr("checked", "checked");
$(document).on("change", "#chkIsfile", function () {
    if ($("#chkIsfile").prop('checked') == true) {
        $("#txtFilename").prop("disabled", false);
    }
    else { $("#txtFilename").prop("disabled", true); }

});

$(document).on("keyup", "#txtFilename", function (e) {
    if (window.event)
        code = e.keyCode;
    else code = e.which;
    if (code == 13 || code == 32 || (code >= 97 && code <= 122) || (code >= 65 && code <= 90) || code >= 48 && code <= 57) {

        var search = $("[id$='txtFilename']").val();

        fileSearch(search);
    }
    if ($("[id$='txtFilename']").val() == "") { $("[id$='#divSearchFile']").hide(); }
});

//  #region start: Financila Grantor related methods start form here

function AddFinancialGuarantor() {
    $("[id$='divRightsSettings']").hide();
    $.post(_ControlPath + "/CallBacks/AddFinancialGuarantorHandler.aspx", function (data) {
        var returnHtml = data;
        var start = data.indexOf("###AddFinancialGuarantorStart###") + 32;
        var end = data.indexOf("###AddFinancialGuarantorEnd###");
        $("#divFinancialGuarantorAdd").html(returnHtml.substring(start, end));
        $("#divFinancialGuarantorAdd").dialog({
            height: 'auto',
            width: 750,
            title: 'Add Financial Guarantor',
            modal: true
        });
        $("#txtAddFinancialGuarantorSSN").mask("999-99-9999")
        $(".phone").mask("(999) 999-9999")
        $("#txtAddFinancialGuarantorDOB").datepicker({
            changeMonth: true,
            changeYear: true,
            maxDate: new Date(),
            yearRange: "-110:+0"
        }).mask("99/99/9999");
    });
}

function cancelFinancialGuarantorDialog() {
    $("#divFinancialGuarantorAdd").dialog("close");
}

function FinancialGuarantorSearchResult(pageNumber, paging) {
    $("[id$='divRightsSettings']").hide();
    $.post(_ControlPath + "/CallBacks/FilterFinancialGuarantorHandler.aspx", {
        firstName: $("[id$='txtFinancialGuarantorFirstName']").val(),
        lastName: $("[id$='txtFinancialGuarantorLastName']").val(), GuarantorGender: $("[id$='ddlFinancialGuarantorGender']").val(), GuarantorDOB: $("[id$='txtFinancialGuarantorDOB']").val(),
        GuarantorAddress: $("[id$='txtFinancialGuarantorAddress']").val(), pageNumber: pageNumber, rows: $("[id$='ddlPagingFinancialGuarantor']").val()
    },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###FinancialGuarantorListStart###") + 33;
        var end = data.indexOf("###FinancialGuarantorListEnd###");
        $("#financialGuarantorList").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###FinancialGuarantorListCountStart###") + 38;
        var endRowsCount = data.indexOf("###FinancialGuarantorListCountEnd###");
        $("[id$='hdnFinancialGuarantorTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnFinancialGuarantorTotalRows']").val(), $("#ddlPagingFinancialGuarantor").val(), "divFinancialGuarantor", "FilterFinancialGuarantor");
        }

        if ($("[id$='hdnFinancialGuarantorTotalRows']").val() > 0) {
            $("#divFinancialGuarantor .spanInfo").html("Showing " + $("#financialGuarantorList tr:first").children().first().html() + " to " + $("#financialGuarantorList tr:last").children().first().html() + " of " + $("[id$='hdnFinancialGuarantorTotalRows']").val() + " entries");
        }
    });
}

function FinancialGuarantorChange() {
    var selectedVal = $("[id$='ddlRelationship']").val();
    $("#hdnFinancialGuarantorIdEdit").val("");
    if (selectedVal != 'Self' && selectedVal != "0") {
        $("#GS").show();
        $(".Guarantor").val("");
    }
    else {
        $("#GS").hide();
        if (selectedVal == 'Self') {
            $("[id$='txtGuarantorFirstName']").val($("[id$='hdnPatientFirstName']").val());
            $("[id$='txtGuarantorLastName']").val($("[id$='hdnPatientLastName']").val());
        }
        else {
            $("[id$='txtGuarantorFirstName']").val("");
            $("[id$='txtGuarantorLastName']").val("");
        }
    }
}

function PopulateFinancialGuarantorDetails(elem) {
    var FirstName = $.trim($(elem).find("td").eq(2).html());
    var LastName = $.trim($(elem).find("td").eq(1).html());
    var FinancialGuarantorId = $.trim($(elem).attr("id"));
    $("[id$='txtGuarantorFirstName']").val(FirstName);
    $("[id$='txtGuarantorLastName']").val(LastName);

    $("[id$='hdnFinancialGuarantorIdEdit']").val(FinancialGuarantorId);
    $("#FinancialGuarantorSearch").dialog("destroy");
}

function getQuerystring(variable) {

    var query = location.search.substring(1)
    var subQuery = query.split("&");
    for (var i = 0; i < subQuery.length; i++) {
        var pair = subQuery[i].split("=");
        if (pair[0] == variable) { return pair[1]; }
    }
}

function openEditPatientForm() {
    debugger;
    $("#updatebtn").show();
    $("#cancelbtn").show();
    $("#editbtn").hide();

    LoadPatientInformation("EditForm");


}

function cancelEditPatientForm() {

    $("#updatebtn").hide();
    $("#cancelbtn").hide();
    $("#editbtn").show();
    LoadPatientInformation("ViewForm")
}

function saveEditPatientForm() {
    AddEditPatient();

}

function AddEditPatient() {
    debugger;
    $("[id$='divRightsSettings']").hide();

    if (!checkModuleRights("PatientEdit")) {
        $("[id$='divRightsSettings']").html(_msg_PatientEdit).show();
        return false;
    }
    if ($("[id$='txtPatientUserName']").val() != "") {
        $("[id$='txtPatientPassword'],[id$='txtPatientConfirmPassword']").addClass("required");

    }
    else {
        $("[id$='txtPatientPassword'],[id$='txtPatientConfirmPassword']").removeClass("required");
    }

    if (!ValidateForm("tblPatientDemographics")) {
        showErrorMessage("");
        return false;
    }

    if ($("[id$='ddlRelationship'] option:selected").index() != 0 && $("[id$='ddlRelationship'] option:selected").index() != 1) {
        if ($("[id$='hdnFinancialGuarantorIdEdit']").val() == "0" || $("[id$='hdnFinancialGuarantorIdEdit']").val() == "") {
            showErrorMessage("Please select Financial Guarantor!");
            return false;
        }
    }

    if ($("[id$='txtPatientPassword']").val() != $("[id$='txtPatientConfirmPassword']").val()) {
        showErrorMessage("Patient password and confirm password are not match!");
        $("[id$='txtPatientPassword'],[id$='txtPatientConfirmPassword']").addClass("error");
        return false;
    }
    var count = 0;
    if ($.trim($("[id$='txtLastName']").val()) == "") { $("[id$='txtLastName']").css("border", "1px solid red"); count = 1; }
    else { $("[id$='txtLastName']").css("border", ""); }
    if ($.trim($("[id$='txtFirstName']").val()) == "") { $("[id$='txtFirstName']").css("border", "1px solid red"); count = 1; }
    else { $("[id$='txtFirstName']").css("border", ""); }
    if ($.trim($("[id$='txtDOB']").val()) == "") { $("[id$='txtDOB']").css("border", "1px solid red"); count = 1; }
    else { $("[id$='txtDOB']").css("border", ""); }

    if ($.trim($("[id$='txtAddress']").val()) == "") { $("[id$='txtAddress']").css("border", "1px solid red"); count = 1; }
    else { $("[id$='txtAddress']").css("border", ""); }
    if ($.trim($("[id$='txtZip']").val()) == "") { $("[id$='txtZip']").css("border", "1px solid red"); count = 1; }
    else { $("[id$='txtZip']").css("border", ""); }

    if (count == 1) { return; ("Please Fill Required Fields!"); }


    var Patient = new Object();

    Patient.PatientId = _PatientId;

    Patient.FirstName = $.trim($("[id$='txtFirstName']").val());
    Patient.MiddleName = $.trim($("[id$='txtMiddleName']").val());
    Patient.LastName = $.trim($("[id$='txtLastName']").val());
    Patient.DateOfBirth = $.trim($("[id$='txtDOB']").val());
    Patient.TimeOfBirth = $.trim($("[id$='txtTimeOfBirth']").val());
    Patient.SSN = $.trim($("[id$='txtSSN']").val());

    debugger;

    Patient.Gender = $("[id$='ddlGender']").val();
    Patient.MaritalStatus = $("[id$='ddlMaritalStatus']").val();
    Patient.RaceId = $("[id$='ddlRace']").val();
    Patient.EthnicityId = $("[id$='ddlEthnicity']").val();
    Patient.PreferredLanguageId = $("[id$='ddlPreferredLanguage']").val();
    Patient.Address = $.trim($("[id$='txtAddress']").val());
    Patient.AddressType = $("[id$='ddlAddressType']").val();
    Patient.City = $.trim($("[id$='txtCity']").val());
    Patient.State = $("[id$='ddlState']").val();
    Patient.Zip = $.trim($("[id$='txtZip']").val());
    Patient.HomePhone = $.trim($("[id$='txtHomePhone']").val());
    Patient.Cell = $.trim($("[id$='txtCell']").val());
    Patient.WorkPhone = $.trim($("[id$='txtWorkPhone']").val());
    Patient.Ext = $.trim($("[id$='txtExt']").val());
    Patient.Email = $.trim($("[id$='txtEmail']").val());
    Patient.CCP = $("[id$='ddlCCP']").val();

    Patient.FinancialGuarantorId = $.trim($("[id$='hdnFinancialGuarantorIdEdit']").val());

    if (Patient.FinancialGuarantorId != "0") {
        Patient.GuarantorRelationship = $("[id$='ddlRelationship']").val();
    }
    else {
        $("[id$='ddlRelationship']").val(0);
    }

    Patient.EmergencyContactName = $.trim($("[id$='txtEmergencyContactName']").val());

    if (Patient.EmergencyContactName != "") {
        Patient.Relationship = $("[id$='ddlEmergencyRelationship']").val();
    }
    else {
        $("[id$='ddlEmergencyRelationship']").val(0);
    }

    Patient.Phone = $.trim($("[id$='txtEmergencyContact']").val());
    Patient.DisabilityDate = $.trim($("[id$='txtDisabilityDate']").val());
    Patient.DeathDate = $.trim($("[id$='txtDeathDate']").val());
    Patient.CauseOfDeath = $.trim($("[id$='txtCauseOfDeath']").val());
    Patient.NCPDP = $("#hdnNCPDP").val();
    Patient.UserName = $("[id$='txtPatientUserName']").val();
    Patient.Password = $("[id$='txtPatientPassword']").val();
    Patient.ActiveWebAccount = $("[id$='cbIsActiveWebAccount']").is(":checked");

    Patient.UploadedFilesID = $("[id$='hdnUploadedFilesID']").val();

    Patient.CommunicationBarriers = $("[id$='ddlCommunicationBarriers']").val();
    debugger;
    $.post(_PatientPath + "/CallBacks/PatientHandler.aspx", { Patient: JSON.stringify(Patient) }, function (data) {
        var start = data.indexOf("###StartPatientId###") + 20;
        var end = data.indexOf("###EndPatientId###");
        var returnHtml = $.trim(data.substring(start, end));

        if (returnHtml == "PatientExists") {
            showErrorMessage("Patient with given name already exists. Please provide different name.");
            return;
        }

        _PatientId = returnHtml;

        LoadPatientInformation("ViewForm");

        $("[id$='lblName']").html(Patient.LastName + ', ' + Patient.FirstName);
        $("[id$='lblCell']").html(Patient.Cell);
        $("[id$='lblHomePhone']").html(', ' + Patient.HomePhone);
        $("[id$='lblWorkPhone']").html(', ' + Patient.WorkPhone);
        $("[id$='lblAddress']").html(Patient.Address);
        $("[id$='lblCity']").html(', ' + Patient.City);
        $("[id$='lblState']").html(', ' + Patient.State);
        $("[id$='lblZip']").html(', ' + Patient.Zip);
        $("[id$='lblMaritalStatus']").html(', ' + Patient.MaritalStatus);
        $("[id$='lblGender']").html(Patient.Gender);
        $("[id$='lblDOB']").html(Patient.DateOfBirth);

        var PatientId = $("[id$='hdnPatientId']").val();

        if (PatientId == 0) {
            window.location = "Demographics.aspx?PatientId=" + _PatientId + "&IsNew=Yes";
        }
        else {
            $("[id$='hdnPatientId']").val(_PatientId);
            showSuccessMessage(_msg_Updated);
            $("#updatebtn").hide();
            $("#cancelbtn").hide();
            $("#editbtn").show();
        }
    }).fail(function () {
        showErrorMessage("Error: Some error occurred. Unable to save.");
    });
}

function GetSearchBox() {
    debugger;
    $.post(_ControlPath + "/CallBacks/PharmacySearch.aspx", {},
    function (data) {
        debugger;
        //$("#PharmacySearch").html("");
       // var returnHtml = data;
        var start = data.indexOf("###StartPharmacySearch###") + 25;
        var end = data.indexOf("###EndPharmacySearch###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#PharmacySearch").html(returnHtml);
        $("#PharmacySearch").dialog({
            title: 'Select Pharmacy',
            modal: true,
            width: 750,
            height: '50%'
        });
    });
}


function RemovePharmacy() {
    debugger;
    //$("[id$=lblPharmacyName']").val("");
    $("[id$='txtPharmacyName']").val("");
}

function SelectPharmacy(elem) {
    debugger;
    var NCPDP = $(elem).attr('id');
    var Name = $.trim($(elem).find("#Name").html());
    var Address = $.trim($(elem).find("#Address").html());
    var City = $.trim($(elem).find("#City").html());
    var State = $.trim($(elem).find("#State").html());
    var Zip = $.trim($(elem).find("#Zip").html());
    $("[id$='txtPharmacyName']").val(Name + "[" + Address + "," + City + "," + State + "," + Zip + "]");
    $("[id$='txtPharmacyInfo']").css("display", "block");
    $("[id$='RemovePharmacy']").css("display", "block");
    $("[id$='AddPharmacy']").css("display", "none");
    // $("[id$='hdnNCPDP']").val(NCPDP);
    $("[id$='hdnNCPDP']").val($(elem).attr('id'));
    $("[id$='hdnPharmacyId']").val(NCPDP);
    $("#PharmacySearch").dialog("close");
}

function LoadPatientInformation(callfor) {
    $.post(_PatientPath + "/CallBacks/DemographicsEditandViewHandler.aspx", { PatientId: _PatientId }, function (data) {
        if (callfor == "EditForm") {
            debugger;
            var startEdit = data.indexOf(" ###startEditDemographics###") + 28;
            var endEdit = data.indexOf("###endEditDemographics###");
            var returnHtmlEdit = $.trim(data.substring(startEdit, endEdit));
            $("[id$='EditViewDemographics']").html(returnHtmlEdit).show();
            InitializeDatePickers();
        }
        if (callfor == "ViewForm") {
            var startView = data.indexOf(" ###startViewDemographics###") + 28;
            var endView = data.indexOf("###endViewDemographics###");
            var returnHtmlView = $.trim(data.substring(startView, endView));
            $("[id$='EditViewDemographics']").html(returnHtmlView).show();

            var startView = data.indexOf("  ###startDemographicsClaims###") + 32;
            var endView = data.indexOf("###endDemographicsClaims###");
            var returnHtmlView = $.trim(data.substring(startView, endView));
            $("[id$='claimtbody']").html(returnHtmlView).show();
        }

        $("[id$='txtPatientPassword']").val($("[id$='hdnPassword']").val());
        $("[id$='txtPatientConfirmPassword']").val($("[id$='hdnPassword']").val());
        isPatientGeneralInfoLoaded = true;


    });
}

function InitializeDatePickers() {

    $(".date").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date(1999, 10 - 1, 25)
    }).mask("99/99/9999");

    $(".DOBdate").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        yearRange: "-110:+0"
    }).mask("99/99/9999");
    $(".time").timeEntry();
}

function setRequiredValidation(elem, requiredElem) {
    if ($(elem).val() != "" && $(elem).val() != "0")
        $("[id$='" + requiredElem + "']").addClass("required");
    else
        $("[id$='" + requiredElem + "']").removeClass("required error");
}

function SubscriberChange(elem) {
    debugger;
    var CurrentTable = $(elem).closest("table");
    var Relationship = $("[id$='ddRelationship']").val();

    /*if (Relationship == 'Self') {
        CurrentTable.find(".iconSearchSmall").hide();

        var LastName = $("[id$='hdnPatientLastName']").val();
        var FirstName = $("[id$='hdnPatientFirstName']").val();
        
        CurrentTable.find(".txtSubscriberLastName").val(LastName);
        CurrentTable.find(".txtSubscriberFirstName").val(FirstName);

        CurrentTable.find(".hdnSubscriberId").val(0);
    }
    else {
        CurrentTable.find(".iconSearchSmall").show();

        CurrentTable.find(".txtSubscriberLastName").val("");
        CurrentTable.find(".txtSubscriberFirstName").val("");
    }*/
    if (Relationship == 'Self') {
        var fName = $("[id$=lblFirstName]").val();
        $("[id$='txtFirstName']").val(fName);
        var lName = $("[id$=lblLastName]").val();
        $("[id$='txtLastName']").val(lName);
        $(".iconSearchSmall").css("display","none");
    }
    else {
        CurrentTable.find(".iconSearchSmall").show();

        $("[id$='txtFirstName']").val("");
        $("[id$='txtLastName']").val("");
    }
}

function ClickSubscriberIcon(elem, InsuranceType) {
    _InsuranceTypeMaster = InsuranceType;

    LoadSubscriberDialog(elem);
}

function deleteInsuranceDialogue(elem) {

    $("#delConfirmationdiv").dialog({
        resizable: false,
        title: 'Confirmation!',
        width: '35%',
        modal: true,
        buttons: {
            "yes": function () { deleteInsurance(elem); showSuccessMessage("Information Deleted"); $(this).dialog("destroy"); },
            "NO": function () { $(this).dialog("destroy"); }
        }
    });
}

function deleteInsurance(patient_insuranceID) {
    debugger;
    $.post("CallBacks/AddEditPatientInsurance.aspx", { Action: "Delete", PatientInsuranceId: patient_insuranceID }, function (data) {
        loadInsurances();
    });

}

function clearfields() {


    $("[id$='hdnPrimaryInsuranceId']").val("");


    $("[id$='txtPrimaryInsurance']").val("");
    $("[id$='txtPrimaryDeductable']").val("");
    $("[id$='txtPrimarySubscriberFirstName']").val("");
    $("[id$='txtPrimarySubscriberLastName']").val("");
    //generel
    $("[id$='hdnInsuranceId']").val("");
    $("[id$='txtPrimaryPolicyNo']").val("");
    $("[id$='txtPrimaryGroupNo']").val("");
    $("[id$='txtPrimaryGroupName']").val("");
    $("[id$='txtPrimaryEffectiveDate']").val("");
    $("[id$='txtPrimaryTerminationDate']").val("");
    //...

    //financila information
    $("[id$='txtPrimaryCopay']").val("");
    $("[id$='ddlPrimaryCoPayType']").val("");
    $("[id$='txtPrimaryCoInsurance']").val("");
    $("[id$='ddlPrimaryCoInsuranceType']").val("");
    $("[id$='txtPrimaryDeductable']").val("");
    $("[id$='ddlPrimaryDeductableType']").val("");
    //......

    //Insurance Type

    //......

    //Subscriber....
    $("[id$='ddlPrimaryRelationship']").val("");
    $("[id$='hdnPrimarySubscriberId']").val("");

}

$(document).ready(function () {

    $("[id$='ddlInsuranceType']").change(function () {

        $.trim($(this).find("td").eq(1).html(""));

        var slectedtype = $("[id$='ddlInsuranceType']").val();
        if (slectedtype == "T") {
            $("#terminationSpan").show();
        }
        else {
            $("#terminationSpan").hide();
        }


    });
});



function checkPrimaryInsurance() {
    //primary insurance add only once 
    debugger;
    var count = 0;
    var pid = 0;

    $("#insuranceTbody >tr").each(function () {

        if ($.trim($(this).find("td").eq(1).html()) == 'P') {
            //  alert($.trim($(this).find("td").eq(1).html()));
            count++;

            pid = $.trim($(this).find("td").eq(0).html());
        }


    });
    if (count == 1) {
        var InsuranceType = $("[id$='ddlInsuranceType']").val();
        //alert(InsuranceType+"2")
        if (InsuranceType == 'P') {
            count++;

        }
    }
    if (count > 1 & $("[id$='hdnPrimaryInsuranceId']").val() != pid) { debugger; return "true"; }

}
function LoadPatientAppointments() {
    $.post(_PatientPath + "/CallBacks/PatientAppointments.aspx", { action: "AllAppointments", Filter: "", PatientId: _PatientId, Rows: '10', PageNumber: '0', SortBy: '' }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");

        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='divAppointmentsMain']").html(returnHtml).show();
        var startRowsCount = data.indexOf("###StartAppointmentRowsCount###") + 31;
        var endRowsCount = data.indexOf("###EndAppointmentRowsCount###");
        $("[id$='hdnTotalRows']").val($.trim(data.substring(startRowsCount, endRowsCount)));

        GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPaging").val(), "divAppointmentsMain", "FilterRecord");
        if ($("[id$='hdnTotalRows']").val() > 0) {
            $("#spnInfo").html("Showing " + $("#gridContentsAppointment tr:first").children().first().html() + " to " + $("#gridContentsAppointment tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        }
        else {
            addNoRecordFoundMessage('divAppointments');
        }
    });
}
function LoadDocuments() {

    $.post(_EMRPath + "/PatientDocument/PatientDocument.aspx", { PatientId: _PatientId }, function (data) {
        var start = data.indexOf("###StartDocument###") + 19;
        var end = data.indexOf("###EndDocument###");
        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='divDocumentsMain']")
        .html(returnHtml)
        .promise()
        .done(function () {
            $("[id$='divDocumentsMain']").show();
        });
    });
}
function addNoRecordFoundMessage(divId) {
    var html = "<span style='color: red; font-size: 14px; font-weight: bold; font-style: italic;'>No Record Found</span>";
    $("#" + divId + " .message").find("#spnInfo").html(html);
}
function FilterRecord(pageNumber, paging) {
    $.post(_PatientPath + "/CallBacks/PatientAppointments.aspx", { action: "AllAppointments", Filter: "Filter", PatientId: _PatientId, Rows: $("#ddlPaging").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartFilterAppointments###") + 29;
        var end = data.indexOf("###EndFilterAppointments###");
        $("#gridContentsAppointment").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartAppointmentRowsCount###") + 31;
        var endRowsCount = data.indexOf("###EndAppointmentRowsCount###");
        $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPaging").val(), "divAppointmentsMain", "FilterRecord");
        }

        if ($("[id$='hdnTotalRows']").val() > 0) {
            //alert($("#gridContentsAppointment tr:first").children().first().text());
            $("#spnInfo").html("Showing " + $("#gridContentsAppointment tr:first").children().first().html() + " to " + $("#gridContentsAppointment tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        }
        // checkAll();
    });
}
function PrintDemographicsView() {
    window.location = _ReportsPath + "/PatientInformationView.aspx?PatientId=" + getParameterByName("PatientId");
}
function viewAppointment(AppointmentsId) {
    $.post(_PatientPath + "/CallBacks/PatientAppointments.aspx", { action: "ViewAppointments", AppointmentsId: AppointmentsId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartViewAppointments###") + 27;
        var end = data.indexOf("###EndViewAppointments###");
        $("#divDialog").html(returnHtml.substring(start, end));

        $("#divDialog").dialog({
            title: "Patient Appointment",
            modal: true,
            resizable: false,
            width: "auto",
            close: function () {
                $("#divDialog").dialog("destroy");
            },
            buttons: {
                "OK": function () {
                    $("#divDialog").dialog("close");
                }
            }
        });
    });
}
function CreatePatientNewClaim() {
    window.location = "../../EMR/Claims/BillingManager.aspx?PatientId=" + _PatientId + "&callFrom=callFromPatient";
}
function click_CreateAppointment() {
    changeLocationAppointments($("[id$='ddAppLocation']"));

    $("[id$='divRightsSettings']").hide();

    if (!checkModuleRights("AppointmentsAdd")) {
        $("[id$='divRightsSettings']").html(_msg_AppointmentsAdd).show();
        return false;
    }

    $("#divAppointmentContainer input, #divAppointmentContainer select, #divNotes textarea").val("");
    $("#divNotes").hide();
    $("#txtDialogPatiantName").val($.trim($("[id$='lblNamePatient']").html()));

    $(".txtAppointmentDate").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date(),
        yearRange: "0:+2"

    }).mask("99/99/9999");


    $("#divAppointmentContainer").dialog({
        title: "New Appointment",
        modal: true,
        close: function () {
            $(this).dialog("close");
        }
    }).show();
}
function changeLocationAppointments(elem) {
    debugger;
    var PracticeLocationsId = $(elem).val();
    var providers = $.grep(_arrProvidersByLocation, function (v, i) {
        if (PracticeLocationsId != 0) {
            return (v.PracticeLocationsId == PracticeLocationsId);
        }
        else {
            return _arrProvidersByLocation;
        }
    });

    var providerHtml = '';

    for (var i = 0; i < providers.length; i++) {
        providerHtml += '<option value="' + providers[i].ServiceProviderId + '">' + providers[i].PhysicianName + '</option>';
    }

    $("[id$='ddlProviders']").html(providerHtml);
    GetProviderAppointmentTypes($("[id$='ddlProviders']").val());
}

$(document).ready(function () {
    //alert(_PatientId)
    if (_PatientId == 0) {
        $("#cancelbtn").hide();
        $("#printbtn").hide();
        $("#divPatientInfoGen").hide();
    }
    else {
        $("#divPatientInfoGen").show();
        $("#printbtn").show();
    }


    $(".phone").mask("(999) 999-9999")

    $("[id$='hdnPatientId']").val(_PatientId);
    //loadPatientsAllClaims();
    LoadPatientAppointments();
    //InitializePatientImageUpload();


    LoadDocuments();

    var AmountToScrollAppointments = 0;


    $("#Demographicstab").click(function (e) {

        if (_PatientId == 0) { showErrorMessage("Please save patient's general information first!"); return; }
        e.preventDefault();
        $(".contentWrapper").animate({ scrollTop: AmountToScrollAppointments }, 500);

    });
    $("#Insurancetab").click(function (e) {
        if (_PatientId == 0) { showErrorMessage("Please save patient's general information first!"); return; }
        e.preventDefault();
        $(".contentWrapper").animate({ scrollTop: 550 }, 500);
    });
    $("#Claimtab").click(function (e) {
        if (_PatientId == 0) { showErrorMessage("Please save patient's general information first!"); return; }
        e.preventDefault();
        $(".contentWrapper").animate({ scrollTop: 650 }, 500);
    });
    $("#ApointmentsTab").click(function (e) {
        if (_PatientId == 0) { showErrorMessage("Please save patient's general information first!"); return; }
        e.preventDefault();
        $(".contentWrapper").animate({ scrollTop: 850 }, 500);
    });

    $("#DocumentTab").click(function (e) {
        if (_PatientId == 0) { showErrorMessage("Please save patient's general information first!"); return; }
        e.preventDefault();
        $(".contentWrapper").animate({ scrollTop: 950 }, 500);
    });
    $("#facesheetTab").click(function (e) {
        if (_PatientId == 0) { showErrorMessage("Please save patient's general information first!"); return; }
        e.preventDefault();
        $(".contentWrapper").animate({ scrollTop: 1550 }, 500);
    });

    $(document).click(function () {
        $("#divPatientDropDown").hide();
    });
});


function InitializePatientImageUpload() {
    new AjaxUpload('#fuPatient', {
        action: _PatientPath + "/ImageHandler.ashx",
        dataType: 'json',
        contentType: "application/json; charset=uft-8",
        data: {
            PatientId: _PatientId
        },
        onSubmit: function (file, ext, fileSize) {
            if (_PatientId == 0) {
                showErrorMessage("Please save patient's general information first!");
                return false;
            }

            if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                showErrorMessage("Error: invalid file extension");
                return false;
            }

            if (fileSize > 25) {
                showErrorMessage("This file exceeds the 5MB attachment limit.");
                return false;
            }
        },
        onComplete: function (file, response) {
            var responseHTML = $.trim($(response).html());
            var res = $.parseJSON(responseHTML);

            var imagePath = _PracticeDocumentsPath + "/" + _PracticeId + "/Patients/" + _PatientId + "/" + res.fileName;
            debugger;
            $("[id$='UserImage']").attr("src", imagePath);
        }
    });
}

function changeLocationChart(elem) {
    var PracticeLocationsId = $(elem).val();
    var _arrPracticeStaffByLocation = "";
    var approvedproviders = $.grep(_arrPracticeStaffByLocation, function (v, i) {
        return (v.PracticeLocationsId == PracticeLocationsId && (v.StaffType == "Physician"));
    });

    var approvedproviderHtml = '<option value=""></option>';

    for (var i = 0; i < approvedproviders.length; i++) {
        approvedproviderHtml += '<option value="' + approvedproviders[i].ServiceProviderId + '">' + approvedproviders[i].Name + '</option>';
    }

    $("[id$='ddlApprovedByProvider']").html(approvedproviderHtml);


    var SeenProviders = $.grep(_arrPracticeStaffByLocation, function (v, i) {
        return (v.PracticeLocationsId == PracticeLocationsId && (v.StaffType == "Physician" || v.StaffType == "Associate Doctor"));
    });

    var providerHtml = '<option value=""></option>';

    for (var i = 0; i < SeenProviders.length; i++) {
        providerHtml += '<option value="' + SeenProviders[i].ServiceProviderId + '">' + SeenProviders[i].Name + '</option>';
    }

    $("[id$='ddlSeenByProvider']").html(providerHtml);
}

function SearchPatient(elem) {
    var patientID = $.trim($(elem).val());


    if (patientID == "") {
        $("[id$='divPatientDropDown']").hide();

        return;
    }
    if (!$.isNumeric(patientID)) { return; }
    var params = {
        patientID: $.trim($(elem).val()),
        action: "PatientSearch"
    };

    $.post(_PatientPath + "/CallBacks/DemographicsEditandViewHandler.aspx", params, function (data) {
        var start = data.indexOf("###startPatientSearch###") + 20;
        var end = data.indexOf("###endPatientSearch###");
        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='tbodyPatientDropDown']").html(returnHtml)

        .promise()
        .done(function () {
            $("[id$='divPatientDropDown']").show();

        });
    });
}

function clickPatient(elem) {
    _PatientId = $.trim($(elem).find("td").eq(0).text());

    window.location = "Demographics.aspx?PatientId=" + _PatientId
    $("[id$='divPatientDropDown']").hide();
}
function getHippaPrivacyForm() {
    $.post(_ControlPath + "/HippaPrivacyAuthorizationForm.aspx", { PatientId: _PatientId, location: 0 }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divPatientForms").html($.trim(data.substring(start, end)));
        $("#divPatientForms").dialog({
            title: "HIPAA Privacy Authorization Form",
            width: 850,
            modal: true,
            close: function () {
                $(this).dialog("destroy");
            }
        })
    });
}
function getHippaReleaseForm() {
    $.post(_ControlPath + "/HIPAAMedicalInformationReleaseForm.aspx", { PatientId: _PatientId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divPatientForms").html($.trim(data.substring(start, end)));
        $("#divPatientForms").dialog({
            title: "Medical Information Release Form",
            width: 850,
            modal: true,
            close: function () {
                $(this).dialog("destroy");
            }
        })
    });
}

function getHippaConsentForm() {
    $.post(_ControlPath + "/PatientHipaaConsentForm.aspx", { PatientId: _PatientId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divPatientForms").html($.trim(data.substring(start, end)));
        $("#divPatientForms").dialog({
            title: "PATIENT HIPAA CONSENT FORM",
            width: 850,
            modal: true,
            close: function () {
                $(this).dialog("destroy");
            }
        })
    });
}

function getCheckDetail(elem) {
    var patid=$("[id$='hdnPatientId']").val();
    var checknumber = $.trim($(elem).find('.tdchecknumber').text());
    var nextrow = $(elem).closest('tr').next().attr('class');
    var pr = $("[id$='lblpr']").text();
    if (pr == "N/A") {
        var html = " <tr class='trdetaillevel2'><td colspan='5'><span onclick='removedetaillevel2(this)' style='font-weight:bold;color:red;float:right;font-size:15px;cursor:pointer'>x</span><div style='margin: 5px 20px 20px 20px;'>" + "<span style='margin-left:50px;font-weight:bold;color:teal'>N/A</span>" + "<div></td></tr>";
        
        $(elem).after(html);
        return;
    }
    
    if ('trdetaillevel2' == nextrow)
    { return;}
    $.post("../Patient/callbacks/DemographicsEditandViewHandler.aspx", { action: "getLevel2Detail", PatientId: patid, Checknumber: checknumber }, function (data) {
        var start = data.indexOf("###startPatientPaymentDetail###")+31;
        var end = data.indexOf("###endPatientPaymentDetail###");
        var result = data.substring(start, end);

        var html = " <tr class='trdetaillevel2'><td colspan='5'><span onclick='removedetaillevel2(this)' style='font-weight:bold;color:red;float:right;font-size:15px;cursor:pointer'>x</span><div style='margin: 5px 20px 20px 20px;'>" + result + "<div></td></tr>";
        $(elem).after(html);
    });
    
}

function removedetaillevel2(elem) {

    $(elem).closest('tr').remove();
}

function OpenBalanceReport()
{

    var value = $("[id$='lblBalanceDue']").text();
    if (value == "N/A" || value == "$0.00") { return }

    var PatientId = $("[id$='hdnPatientId']").val();

    $.post("../Patient/callbacks/DemographicsEditandViewHandler.aspx", { action: "GetBalanceGrid", PatientId: PatientId }, function (data) {
        var start = data.indexOf("###SRBG###") + 12;
        var end = data.indexOf("###ERBG###");
        var result = data.substring(start, end);

        $(".RBGDialogue").html(result);

        $(".RBGDialogue").dialog({

            resizable: false,
            title: 'Remaining Balance Detail',
            width: '85%',
            modal: true,
            buttons: {
            
                "Cancel": function () { $(this).dialog("destroy"); clearfields(); }
            }
        });
    });
   
   
}
