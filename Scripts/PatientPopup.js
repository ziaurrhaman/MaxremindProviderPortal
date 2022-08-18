


/*****Start Patient Popup*****/
function NewPatientPopUp() {
    debugger;
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("PatientCreate")) {
        $("[id$='divRightsSettings']").html(_msg_PatientCreate).show();
        return false;
    }

    if ($("[id$='chkBookAppointment']").is(":checked")) {
        return;
    }

    $.post("../../ProviderPortal/Patient/AddNewPatientPopUp.aspx", function (data) {
        var returnHtml = data;
        var start = data.indexOf("###NewPatientPopUp###") + 21;
        var end = data.indexOf("###EndPatientPopUp###");
        $("#NewPatientPopUp").html(returnHtml.substring(start, end));
        $("#txtSSNNewPatientPopUp").mask("999-99-9999");
        $(".DOBdate").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "1913:" + new Date,
            maxDate: new Date
        }).mask("99/99/9999");
        $("#txtCell").mask("(999) 999-9999");

        $("#NewPatientPopUp").dialog({
            resizable: false,
            height: 'auto',
            width: '700px',
            title: 'New Patient',
            modal: true,
            close: function () {
                $("#NewPatientPopUp").dialog("destroy");
            }
        });
    });
}

function CreateNewPatientPopUp() {
    debugger
    if (!ValidateForm("tblPatientPopup")) {
        showErrorMessage("");
        return false;
    }
    
    var InsuranceId = $("[id$='hdnNewPatientPrimaryInsuranceId']").val();
    var PolicyNumber = $.trim($("#txtNewPatientPrimaryPolicyNo").val());
    
    if (InsuranceId != "0") {
        if (PolicyNumber == "") {
            showErrorMessage("Please enter the policy number.");
            return false;
        }
    }
    else {
        if (PolicyNumber != "") {
            showErrorMessage("Please Select Insurance.");
            return false;
        }
    }
    
    var objPatient = new Object();
    
    objPatient.FirstName = $.trim($("#txtPatientPopUpFirstName").val());
    objPatient.LastName = $.trim($("#txtPatientPopUpLastName").val());
    objPatient.DateOfBirth = $.trim($("#txtPatientPopUpDOB").val());
    objPatient.Gender = $("#ddlPatientPopUpGender").val();
    objPatient.Cell = $("#txtCell").val();
    objPatient.City = $.trim($("[id$='txtCityNewPatientPopUp']").val());
    objPatient.State = $.trim($("[id$='ddlStatesNewPatientPopUp']").val());
    objPatient.Zip = $.trim($("[id$='txtZipNewPatientPopUp']").val());
    objPatient.Address = $.trim($("#txtAddressNewPatientPopUp").val());
    
    objPatient.SSN = $.trim($("#txtSSNNewPatientPopUp").val());
    objPatient.IsActive = true;
    var objPatientInsurance = new Object();
    
    objPatientInsurance.InsuranceId = InsuranceId;
    objPatientInsurance.PolicyNumber = PolicyNumber;

    
    $.post("../../ProviderPortal/Patient/CallBacks/PatientHandler.aspx", { Patient: JSON.stringify(objPatient), objPatientInsurance: JSON.stringify(objPatientInsurance) }, function (data) {
        debugger;
        doneAddNewPatient(data, objPatient);
    }).fail(function () {
        showErrorMessage("Error: Some Error occurred. Unable to Create.");
    });
}

function ClosePatientPopUp() {
    $("#NewPatientPopUp").dialog("close");
}

function ShowNewPatientInsuranceSearch(elem) {
    debugger;
    $.post("../../Providerportal/Controls/NewPatientInuranceSearch.aspx", {}, function (data) {
        debugger;
        var returnHtml = data;
        var start = data.indexOf("###StartInsuranceSearch###") + 26;
        var end = data.indexOf("###EndInsuranceSearch###");

        $("#InsuranceSearchBox").html(returnHtml.substring(start, end));
        $("#InsuranceSearchBox").dialog({ width: '900', modal: true, title: 'Search Insurance' });

        GeneratePaging($("[id$='hdnTotalRowsINS']").val(), $("#ddlPagingInsurance").val(), "InsuranceSearchBox", "FilterInsurance");
        if ($("[id$='hdnTotalRowsINS']").val() > 0)
            $("#InsuranceSearchBox .spanInfo").html("Showing " + $("#ShowInsuranceResult tr:first").children().first().html() + " to " + $("#ShowInsuranceResult tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsINS']").val() + " entries");
    });
}

function GetInsuranceNameNewPatient(elem) {

    var Name = $.trim($(elem).find(".insuranceName").html());
    var InsuranceId = $(elem).find(".insuranceName").attr('id');

    $("[id$='hdnNewPatientPrimaryInsuranceId']").val(InsuranceId);
    $("[id$='txtNewPatientPrimaryInsurance']").val(Name);
    $("[id$='txtNewPatientPrimaryPolicyNo']").val("");

    $("#InsuranceSearchBox").dialog("close");
}

function RemovePatientInsurance() {
    $("[id$='hdnPrimaryInsuranceId']").val("0");
    $('#txtNewPatientPrimaryInsurance').val("");
    $("[id$='txtNewPatientPrimaryPolicyNo']").val("");
}

function ShowNewInsuranceDialog() {
    $.post(_ControlPath + "/AddEditInsurance.aspx", function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartNewInsurance###") + 23;
        var end = data.indexOf("###EndNewInsurance###");

        $("#NewInsurance").html(returnHtml.substring(start, end));
        $("#NewInsurance").dialog({ width: 1000, height: 'auto', modal: true, title: 'Add New Insurance' });
        $(".phone").mask("(999) 999-9999");
        $(".txtInsuranceTaxId").mask("999-99-9999");
    });
}
/*****End Patient Popup*****/