var _PatientId;
var _EligibilityPath = '<%=ResolveUrl("~/EMR/Eligibility")%>';
var isRowCount = 0;
$(document).ready(function () {

    _PatientId = $("[id$='hdnPatientId']").val();

});

function SendEligibilityRequest(params, CallFrom) {
    debugger;
    var rowCount = $('#TblInsurance>tbody >tr').length;
    if (rowCount == 0) {
        showErrorMessage("Please Add Insurance for this patient ");
        return;
    }
    else {
        $.post("/ProviderPortal/Eligibility/CheckPatientEligibility.aspx", params, function (data) {
            debugger;
            var hdnRowCount = $("[id$='hdnRowCount']").val();
            EligibilityResponse(data, CallFrom);
        });
    }
}

function EligibilityResponse(data, CallFrom) {
    debugger
    var start = data.indexOf("###StartEligibilityAjaxResponse###") + 34;
    var end = data.indexOf("###EndEligibilityAjaxResponse###");
    var returnHtml = $.trim(data.substring(start, end));

    if (returnHtml == "PatientInformationNotFound") {
        
        showErrorMessage("Patient Information Is Not Found!");
        return;
    }
    if (returnHtml == "InsuranceTableIsEmptyD270") {
        showErrorMessage("Insurance information is not available for this patient ");
        return;
    }
    start = data.indexOf("###EligibilityResponseStart###") + 30;
    end = data.indexOf("###EligibilityResponseEnd###");
    returnHtml = $.trim(data.substring(start, end));
    $("#EligibilityResponse").html(returnHtml);
   var hdnRowCount = $("[id$='hdnRowCount']").val();

   if (hdnRowCount > 0) {
        var startEligibility = data.indexOf("###EpisodeEligibilityStart###") + 29;
        var endEligibility = data.indexOf("###EpisodeEligibilityEnd###");
        returnHtml = $.trim(data.substring(startEligibility, endEligibility));
        $("[id$='divEligibilityDetail']").html(returnHtml);
        $("[id$='divEligibilityDetail']").show();
        $("#EligibilityResponse").dialog({
            width: 950,
            height: 'auto',
            modal: true,
            title: 'Eligibility Response',
            buttons: {
                "Ok": function () {
                    $(this).dialog("close");
                }
            }
        });
    } else { showErrorMessage("payer is not providing real time eligibility !"); }

    if (CallFrom == "Schedular") {
        EligibilityResponseDone(data);
    }
}

function CheckPatientInsurance() {

}

function CheckPatientEligibility_RowCount(CallFrom, elem, PolicyNumber) {
    isRowCount = 1;
    elem = $("[id$='ddlInsurance']").val();
    PolicyNumber = $("[id$='" + elem + "']").val();
    var DOS = $("[id$='txtEligibilityDOS']").val();
    CheckPatientEligibility(CallFrom, elem, PolicyNumber,DOS)
    $("#PopUpPatientInsuranceDetail").dialog("destroy");
}

function CheckPatientEligibility(CallFrom, elem, PolicyNumber,DOS) {
    debugger;
    if (elem == undefined) {
        isRowCount = 0;
    }
    var params;

    if (CallFrom == "Demographics") {
        var PolicyNumber = PolicyNumber;
        var rowCount = $('#TblInsurance>tbody >tr').length;
        if (rowCount > 0 && isRowCount == 0) {
            $.post("/ProviderPortal/Eligibility/CallBacks/PatientInsuranceDetail.aspx", { PatientId: _PatientId }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                var returnHtml_1 = returnHtml.substring(start, end);
                $("#PopUpPatientInsuranceDetail").html(returnHtml_1).dialog({
                    resizable: false,
                    title: "Patient Insurance Details",
                    height: 300,
                    width: 700,
                    modal: true,
                    buttons: {
                        'Check Eligibility': function () { CheckPatientEligibility_RowCount('Demographics') },
                        Close: function () {
                            $(this).dialog("destroy");
                        }
                    },
                    close: function () {
                        $(this).dialog("destroy");
                    }
                });
            });
            return;
        }
        else {
            params = {
                PatientId: _PatientId,
                IsFromPersonal: true,
                date: new Date(),
                EligibilityStartDate: DOS,
                LastName: $("[id$='lblLastName']").val(),
                FirstName: $("[id$='lblFirstName']").val(),
                DateOfBirth: $("[id$='lblDOB']").val(),
                InsuranceId: elem,
                PolicyNumber: PolicyNumber,
                IsHome: true
            };
        }
        if (elem == undefined) {
            params = {
                PatientId: _PatientId,
                IsFromPersonal: false,
                date: new Date(),
                EligibilityStartDate: CurrentSystemDate(),
                LastName: "",
                FirstName: "",
                DateOfBirth: "",
                InsuranceId: $("[id$='hdnInsuranceId']").val(),
                PolicyNumber: "",
                IsHome: true
            };
        }
    }
    else if (CallFrom == "NewPatientPopUp") {
        params = {
            PatientId: 0,
            IsFromPersonal: true,
            date: new Date(),
            EligibilityStartDate: CurrentSystemDate(),
            LastName: $.trim($("[id$='tblPatientPopup'] [name='LastName']").val()),
            FirstName: $.trim($("[id$='tblPatientPopup'] [name='FirstName']").val()),
            DateOfBirth: $.trim($("[id$='tblPatientPopup'] [name='DOB']").val()),
            InsuranceId: $.trim($("[id$='tblPatientPopup'] [name='InsuranceId']").val()),
            PolicyNumber: $.trim($("[id$='tblPatientPopup'] [name='PolicyNo']").val()),
            IsHome: true
        };
    }
    else if (CallFrom == "Schedular") {
        params = {
            PatientId: _PatientId,
            IsFromPersonal: false,
            date: new Date(),
            EligibilityStartDate: CurrentSystemDate(),
            LastName: "",
            FirstName: "",
            DateOfBirth: "",
            InsuranceId: "0",
            PolicyNumber: "",
            IsHome: true
        };
    }
    else if (CallFrom == "Walkout") {
        params = {
            PatientId: _PatientId,
            IsFromPersonal: false,
            date: new Date(),
            EligibilityStartDate: CurrentSystemDate(),
            LastName: "",
            FirstName: "",
            DateOfBirth: "",
            InsuranceId: "0",
            PolicyNumber: "",
            IsHome: true
        };
    }
    
    else if (CallFrom == "Eligibility") {
        debugger;
        var StartDate = "";
        var EndDate = "";
        if ($('#rdoCustomEligibiltyDates').prop('checked') == true) {
            StartDate = $("#txtFromDate").val();
            EndDate = $("#txtToDate").val();
        }
        else {
            StartDate = CurrentSystemDate();
            EndDate = "";
        }
        if ($("[id$='hdnPatientId']").val() != "") {
            params = {
                PatientId: $("[id$='hdnPatientId']").val(),
                IsFromPersonal: false,
                date: new Date(),
                EligibilityStartDate: StartDate,
                EligibilityEndDate: EndDate,
                LastName: $("#txtFirstName").val(),
                FirstName: $("#txtFirstName").val(),
                DateOfBirth: $("#txtDateOfBirth").val(),
                InsuranceId: $('.ddlEligibilityPayerName').find(":selected").val(),
                PolicyNumber: $("#txtSubscriberID").val(),
                PayerName: $('.ddlEligibilityPayerName').find(":selected").text(),
                PayerId: $("[id$='hdnPayerId']").val(),
                IsHome: true
            };
        }
        else {
            params = {
                PatientId: 0,
                IsFromPersonal: true,
                date: new Date(),
                EligibilityStartDate: CurrentSystemDate(),
                LastName: $("#txtFirstName").val(),
                FirstName: $("#txtFirstName").val(),
                DateOfBirth: $("#txtDateOfBirth").val(),
                InsuranceId: $('.ddlEligibilityPayerName').find(":selected").val(),
                PolicyNumber: $("#txtSubscriberID").val(),
                IsHome: true
            };
        }
    }
    var EM = $("[id$='hdnErrorMessage']").val();
    if (EM != "1") {
        SendEligibilityRequest(params, CallFrom);
    }
    else {
        $.post("/ProviderPortal/Eligibility/CheckPatientEligibility.aspx", params, function (data) {
            debugger;
            var hdnRowCount = $("[id$='hdnRowCount']").val();
            EligibilityResponse(data, CallFrom);
        });
    }
    
}

function ClickCheckEligibilityNewPatientPopUp() {
    if (!ValidateForm("tblPatientPopup")) {
        showErrorMessage("");
        return false;
    }

    var DateOfBirth = $.trim($("[id$='tblPatientPopup'] [name='DOB']").val());
    var InsuranceId = $.trim($("[id$='tblPatientPopup'] [name='InsuranceId']").val());
    var PolicyNumber = $.trim($("[id$='tblPatientPopup'] [name='PolicyNo']").val());

    if (DateOfBirth == "" || InsuranceId == "" || PolicyNumber == "") {
        showErrorMessage("Date of birth, Primary Insurance and Policy No. are required for Eligibility Check.");
        return false;
    }

    CheckPatientEligibility("NewPatientPopUp");
}

function ConvertPatientEligibilityStatus(EligibilityStatus) {
    EligibilityStatus = $.trim(EligibilityStatus);

    var objEligibilityStatus = new Object();

    if (EligibilityStatus == "A") {
        objEligibilityStatus.EligibilityStatus = "Active";
        objEligibilityStatus.Css = "eligibility-icon-active";
    }
    else if (EligibilityStatus == "I") {
        objEligibilityStatus.EligibilityStatus = "In Active";
        objEligibilityStatus.Css = "eligibility-icon-inactive";
    }
    else if (EligibilityStatus == "R") {
        objEligibilityStatus.EligibilityStatus = "Rejected";
        objEligibilityStatus.Css = "eligibility-icon-rejected";
    }
    else {
        objEligibilityStatus.EligibilityStatus = "Check Eligibility";
        objEligibilityStatus.Css = "eligibility-icon-check";
    }

    return objEligibilityStatus;
}




