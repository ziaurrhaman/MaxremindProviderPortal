var _ClaimId = 0;
var _ClaimTypeId = 0;
var _ClaimType = "All";
var _SelectedPointertd;
var _CreateClaimFlag = false;
var _ClaimSubmissionFlag = false;
var _NeedToGetSubmissionFiles = false;
var _NeedToGetSubmissionLog = false;
var _CallFrom = "";
var _PracticeId = 0;
var _insuranceddlId = "";
$(document).ready(function () {
    $("[id$='txtDateOfService'] , [id$='txtBillDate']").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "-5 : +5",
        maxDate: new Date(),
        onSelect: function () {
            RowsChange('FilterClaims');
        }
    }).mask("99/99/9999");

    GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");

    if ($("[id$='hdnClaimsCount']").val() > 0) {
        $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
    }

    _PracticeId = $("[id$='hdnPracticeIdMaster']").val();



    var ClaimId = $.trim(getParameterByName("ClaimId"));

    if (ClaimId != "") {
        _ClaimId = ClaimId;
        _PatientId = $.trim(getParameterByName("PatientId"));
        OpenClaimForm();
    }
});

$(document).on("click", "body", function () {
    $(".divDrugSearchList").hide();
});

//Added by Syed Sajid Ali Date:11-21-2019 Des:For Sorting
var SORTBY = "";
function sortedbyAscDesc(elem, type) {
    debugger
    SORTBY = $(".ClaimSearch option:selected").val();
    $("[id$='sortBy']").val(SORTBY);

    $(".imgGreenUp").hide();
    $(".imgGreenDown").hide();
    $(".imgGrayDown").show();

    $(elem).find("img").toggle();

    var chkImg = $(elem).find("img").attr("class");
    if (chkImg == "imgGrayDown SortBy") {
        $(".imgGreenUp").hide();
    }
    if (chkImg == "imgGreenDown") {
        $(".imgGreenDown").hide();
    }
    if (chkImg == "imgGrayDown") {
        $(".imgGreenDown").hide();
    }
    if (chkImg == "imgGreenDown SortBy") {
        $(".imgGreenUp").hide();
    }

    $(elem).find("img").toggleClass('SortBy');
    var sortBy = $(elem).find("img").hasClass('SortBy');
    if (sortBy) {
        SORTBY = $.trim(type) + ' ASC';
    }
    else {
        SORTBY = $.trim(type) + ' DESC';
    }
    $("[id$='sortBy']").val(SORTBY);
        FilterClaims(0,true);
}
//End by Syed Sajid Ali

function FilterClaims(pageNumber, paging, Locationids) {
    debugger;
    var ProviderId = "";
if (Locationids == undefined) {
    Locationids = $.trim($(".hdnLocationsId").val());
}
if (Locationids == "") {
   Locationids = null;
}
if (SORTBY == null || SORTBY == undefined || SORTBY == '') SORTBY = 'Claim No DESC';
    $("[id$='divRightsSettings']").hide();
    var ClaimId = $.trim($("[id$='txtClaimNo']").val());
    var PatientId = $.trim($("[id$='txtPatientAccount']").val());
    var PatientName = $.trim($("[id$='txtPatientName']").val());
    var DateOfService = $.trim($("[id$='txtDateOfService']").val());
    var BillDate = $.trim($("[id$='txtBillDate']").val());
    var InsuranceId = _insuranceddlId;
        //$.trim($("[id$='ddlInsurance']").val());
    var SubmissionStatusId = $.trim($("[id$='ddlSubmissionStatus']").val());
    var Location = $.trim($("[id$='txtLocation']").val());
    /*********added by shahid kazmi 1/22/2018**********/
    var AmountPaid = $.trim($("[id$='txtPaidAmount']").val());
    var AmountDue = $.trim($("[id$='txtAmountDue']").val());
    var Charges = $.trim($("[id$='txtCharges']").val());
/*********end shahid kazmi 1/22/2018**************/
/*********Added by Khayyam Adeel 10/12/2021**************/
    debugger;
    $("[Id$='allCheckbox1']").prop("checked", false);
    
    var isRPM = false;

    if ($("#rdoAllCliams").is(":checked") || $("[id$='spnClaimSection']").is(':visible')==false) {
        isRPM = false;
    }
    else {
        isRPM = true;
    }
    $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).val() + ",";
        }
    });
    $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            ProviderId = "";
        }
    });
    if (ProviderId.length > 0) {
        debugger
        ProviderId = ProviderId.slice(0, -1);
    }
    $.post("../Claims/CallBacks/BillingManagerHandler.aspx", {
        ClaimId: ClaimId,
        PatientId: PatientId,
        PatientName: PatientName,
        DateOfService: DateOfService,
        BillDate: BillDate,
        InsuranceId: InsuranceId,
        SubmissionStatusId: SubmissionStatusId,
        Location: Location,
        AmountPaid: AmountPaid,
        AmountDue: AmountDue,
        Rows: $("#ddlPagingClaims").val(),
        PageNumber: pageNumber,
        SORTBY: SORTBY,
        Locationids: Locationids,
        isRPM: isRPM,
        charges: Charges,
        ProviderId: ProviderId,
    },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartBillingHandler###") + 25;
        var end = data.indexOf("###EndBillingHandler###");
        $("#ClaimsList").html(returnHtml.substring(start, end));
        debugger;
        if (paging == true) {
            GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");
            //Added By Asad Mehmood 11/09/2020
            $('[id$="allCheckbox1"]').prop("checked", false);
        }
        if ($("[id$='hdnClaimsCount']").val() > 0) {
            $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
        }
        $(".divServiceProvider").css("display", "none")
        $('[id$="hdnProviderId"]').val(ProviderId);

        
    });
}
function ShowMenuFilters(DivId, elem) {
    debugger
    if ($(elem).parent().find("." + DivId).is(':visible')) {
        $(elem).parent().find("." + DivId).css("display", "none");
    }
    else {
        $(elem).parent().find("." + DivId).css("display", "");

    }
}

function callFilterFunction() {
    callFrom = $("#spnTitle").html();
    if (callFrom == "Claims") {
        RowsChange('FilterClaims');
    } else {
        RowsChange('filterPatients');
    }
}

//************************************  Create Claim****************************/
function CreateClaim_Click(elem) {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("ClaimsCreate")) {
        $("[id$='divRightsSettings']").html(_msg_ClaimsCreate).show();
        return false;
    }

    _ClaimId = 0;
    _PatientId = 0;

    OpenClaimForm();

    $(".button-image").removeClass("selected");
    $(".selected-icons").removeClass("button-selected");
    $("#btnCreateClaimMain .button-image").addClass("selected");
    $("#btnCreateClaimMain .selected-icons").addClass("button-selected");
}

function loadCreateClaimForm(elem) {
    $("[id$='divRightsSettings']").hide();
    _ClaimId = 0;
    _PatientId = 0;

    if (elem != "") {
        if (!checkModuleRights("ClaimsView")) {
            $("[id$='divRightsSettings']").html(_msg_ClaimsView).show();
            return false;
        }

        _ClaimId = $(elem).closest("tr").find(".hdnClaimId").val();
        _PatientId = $(elem).closest("tr").find(".hdnPatientId").val();
    }

    OpenClaimForm();
}

function OpenClaimForm() {
    $.post(_EMRPath + "/Claims/CallBacks/CreateClaimForm.aspx", { ClaimId: _ClaimId, PatientId: _PatientId }, function (data) {
        var start = data.indexOf("###StartClaim###") + 16;
        var end = data.indexOf("###EndClaim###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#divCreatClaimContent .WidgetMainContent").html(returnHtml)
        .promise()
        .done(function () {
            if (_ClaimId == 0) {
                $("[id$='spanHeadingClaimForm']").html("Create Claim");
                $("[id$='chkIsPTL']").prop("disabled", true);

                $("[id$='spanClaimNumberClaimForm']").html("");
                $(".span-claim-heading").hide();
            }
            else {
                $("[id$='spanHeadingClaimForm']").html("");
                $("[id$='chkIsPTL']").prop("disabled", false);

                $("[id$='spanClaimNumberClaimForm']").html(_ClaimId);
                $(".span-claim-heading").show();
            }

            $(".billing-manager-main-divs").hide();
            $("#divCreatClaimContent").show();

            var imagePath = $("[id$='hfImageFileNamePatient']").val();

            if (imagePath == "") {
                $("#imgPatientPhoto").attr("src", _RooTPath + "Images/maleIcon.png");
            }
            else {
                $("[id$='imgPatientPhoto']").attr("src", _PracticeDocumentsPath + "/" + imagePath);
            }

            if ($.trim($("[id$='lblGenderPatient']").html()) == "Female,") {
                $(".tdFemale").show();
            }
            else {
                $(".tdFemale").hide();
            }
        });
    });
}

function SaveClaim() {
    var _priStatus = $.trim($("[id$='ddlPrimaryStatus']").val()) == "" ? 0 : $.trim($("[id$='ddlPrimaryStatus']").val());
    var _secStatus = $.trim($("[id$='ddlSecondaryStatus']").val()) == "" ? 0 : $.trim($("[id$='ddlSecondaryStatus']").val());
    var _othStatus = $.trim($("[id$='ddlOtherStatus']").val()) == "" ? 0 : $.trim($("[id$='ddlOtherStatus']").val());

    if (_ClaimId == 0) {
        if (!checkModuleRights("ClaimsCreate")) {
            $("[id$='divRightsSettings']").html(_msg_ClaimsCreate).show();
            return false;
        }
    } else {
        if (checkModuleRights("ClaimsEdit")) {
            if (_priStatus != 0) {
                if (!getModuleRightStatus("ClaimsEditStatus", _priStatus)) {
                    $("[id$='divRightsSettings']").html(_msg_ClaimsEditStatus).show();
                    return false;
                }
            }
        } else {
            $("[id$='divRightsSettings']").html(_msg_ClaimsEdit).show();
            return false;
        }
    }

    if (_PatientId == "" || _PatientId == 0) {
        showErrorMessage("Error: Please add patient");
        return false;
    }

    if (!ValidateFormWhenComboContainZeroValue("divSaveClaim")) {
        showErrorMessage("");
        return false;
    }

    if ($("#tbodyClaimServices > tr").length < 2) {
        showErrorMessage("Error: Please enter some service(s) for claim.");
        return false;
    }

    var objClaim = new Object();

    objClaim.ClaimId = _ClaimId;
    objClaim.PatientId = _PatientId;
    objClaim.DOS = $.trim($("[id$='ddlDos']").val());
    objClaim.POS = $.trim($("[id$='ddlPOS']").val());
    objClaim.PracticeLocationsId = $.trim($("[id$='ddlLocation']").val()) == "" ? 0 : $.trim($("[id$='ddlLocation']").val());
    objClaim.AttendingPhysician = $.trim($("[id$='ddlAttendingPhy']").val()) == "" ? 0 : $.trim($("[id$='ddlAttendingPhy']").val());
    objClaim.BillingPhysicianId = $.trim($("[id$='ddlBillingPhy']").val()) == "" ? 0 : $.trim($("[id$='ddlBillingPhy']").val());
    objClaim.ReferringPhysicianId = $.trim($("[id$='ddlReferringPhy']").val()) == "" ? 0 : $.trim($("[id$='ddlReferringPhy']").val());
    objClaim.PANumber = $.trim($("[id$='txtPANo']").val());
    objClaim.ReferralNumber = $.trim($("[id$='txtReferralNo']").val());

    if ($.trim($("[id$='ddlPrimaryInsurance']").val()) != "") {
        objClaim.InsuranceId = $.trim($("[id$='ddlPrimaryInsurance']").val());
    }

    if ($.trim($("[id$='ddlSecondaryInsurance']").val()) != "") {
        objClaim.SecInsuranceId = $.trim($("[id$='ddlSecondaryInsurance']").val());
    }

    if ($.trim($("[id$='ddlOtherInsurance']").val()) != "") {
        objClaim.OthInsuranceId = $.trim($("[id$='ddlOtherInsurance']").val());
    }

    objClaim.PriSubmissionStatusId = _priStatus;
    objClaim.SecSubmissionStatusId = _secStatus;
    objClaim.OthSubmissionStatusId = _othStatus;

    objClaim.DxCode1 = $.trim($("[id$='txtIcdCode1']").val());
    objClaim.DxCode2 = $.trim($("[id$='txtIcdCode2']").val());
    objClaim.DxCode3 = $.trim($("[id$='txtIcdCode3']").val());
    objClaim.DxCode4 = $.trim($("[id$='txtIcdCode4']").val());
    objClaim.DxCode5 = $.trim($("[id$='txtIcdCode5']").val());
    objClaim.DxCode6 = $.trim($("[id$='txtIcdCode6']").val());
    objClaim.DxCode7 = $.trim($("[id$='txtIcdCode7']").val());
    objClaim.DxCode8 = $.trim($("[id$='txtIcdCode8']").val());

    objClaim.AdmissionDate = $.trim($("[id$='txtAdmissionDate']").val());
    objClaim.DischargeDate = $.trim($("[id$='txtDischargeDate']").val());
    objClaim.OnSetOfCurrentIllness = $.trim($("[id$='txtCurrentIllness']").val());
    objClaim.XRayDate = $.trim($("[id$='txtXryDate']").val());
    objClaim.AcuteManifestation = $.trim($("[id$='txtAdmissionDate']").val());
    objClaim.AccidentDate = $.trim($("[id$='txtDateOfAccident']").val());
    objClaim.LMPDate = $.trim($("[id$='txtLMP']").val());
    objClaim.InitialTreatmentDate = $.trim($("[id$='txtInitialTreatmentDate']").val());
    objClaim.LastSeenDate = $.trim($("[id$='txtLastSeenDate']").val());
    objClaim.PatientPaidAmmount = $.trim($("[id$='txtPatientPaidAmmount']").val()) == "" ? 0 : $.trim($("[id$='txtPatientPaidAmmount']").val());
    objClaim.ServiceAuthorizationException = $.trim($("[id$='txtServiceAuthorizationException']").val());
    objClaim.MammographyCertificationNumber = $.trim($("[id$='txtMammographyCertificationNumber']").val());
    objClaim.CLIANumber = $.trim($("[id$='txtCLIANumber']").val());
    objClaim.ICNDCN = $.trim($("[id$='txtICNDCN']").val());
    objClaim.AmbulancePickUpLocationAddress = $.trim($("[id$='txtAmbulancePickUpLocationAddress']").val());
    objClaim.AmbulancePickUpLocationCity = $.trim($("[id$='txtAmbulancePickUpLocationCity']").val());
    objClaim.AmbulancePickUpLocationState = $.trim($("[id$='ddlAmbulancePickUpLocationState']").val());
    objClaim.AmbulancePickUpLocationZip = $.trim($("[id$='txtAmbulancePickUpLocationZip']").val());
    objClaim.AmbulanceDropLocationAddress = $.trim($("[id$='txtAmbulanceDropLocationAddress']").val());
    objClaim.AmbulanceDropLocationCity = $.trim($("[id$='txtAmbulanceDropLocationCity']").val());
    objClaim.AmbulanceDropLocationState = $.trim($("[id$='ddlAmbulanceDropLocationState']").val());
    objClaim.AmbulanceDropLocationZip = $.trim($("[id$='txtAmbulanceDropLocationZip']").val());
    objClaim.TransportationReasonCode = $.trim($("[id$='ddlTransportationReasonCode']").val());
    objClaim.PatientWeight = $.trim($("[id$='txtPatientWeight']").val());
    objClaim.PatientWeightUnit = $.trim($("[id$='ddlPatientWeightUnit']").val());
    objClaim.PatientCondition = $.trim($("[id$='ddlPatientCondition']").val());
    objClaim.EpsdtCode = $.trim($("[id$='ddlEpsdtCode']").val());
    objClaim.RenderingPhysicianId = $.trim($("[id$='ddlRenderingPhysician']").val()) == "" ? 0 : $.trim($("[id$='ddlRenderingPhysician']").val());
    objClaim.SupervisingPhysicianId = $.trim($("[id$='ddlSupervisingPhysician']").val()) == "" ? 0 : $.trim($("[id$='ddlSupervisingPhysician']").val());
    objClaim.ServiceFacilityLocationName = $.trim($("[id$='txtServiceFacilityLocationName']").val());
    objClaim.ServiceFacilityNPI = $.trim($("[id$='txtServiceFacilityNPI']").val());
    objClaim.ServiceFacilityAddress = $.trim($("[id$='txtServiceFacilityAddress']").val());
    objClaim.ServiceFacilityCity = $.trim($("[id$='txtServiceFacilityCity']").val());
    objClaim.ServiceFacilityState = $.trim($("[id$='ddlServiceFacilityState']").val());
    objClaim.ServiceFacilityZip = $.trim($("[id$='txtServiceFacilityZip']").val());
    objClaim.AccidentAuto = $("[id$='chkAutoAccident']").is(":checked");
    objClaim.AccidentOther = $("[id$='chkOtherAccident']").is(":checked");
    objClaim.Employment = $("[id$='chkEmployment']").is(":checked");
    objClaim.AccidentState = $.trim($("[id$='ddlAutoAccidentState']").val());

    var ClaimTotal = parseFloat(0);
    var CPTCharges = parseFloat(0);

    var listClaimCharges = new Array();

    $("#tbodyClaimServices > tr").not(":last").each(function () {
        var objClaimCharges = new Object();

        objClaimCharges.ClaimChargesId = $.trim($(this).find(".hdnClaimChargesId").val());
        objClaimCharges.ClaimId = _ClaimId;
        objClaimCharges.ServiceDate = $.trim($("[id$='ddlDos']").val());

        objClaimCharges.IncludeInSubmission = $(this).find(".cbIncludeInSubmission input:checkbox").is(":checked");

        objClaimCharges.CPTCode = $.trim($(this).find(".hdnProceduresCode").val());
        objClaimCharges.Drug = $.trim($(this).find(".hdnDrug").val());
        objClaimCharges.UnitCode = $.trim($(this).find(".ddlUnitCode").val());

        if ($(this).find(".div-drop-down input:checkbox:checked:eq(0)").length > 0) {
            objClaimCharges.DXPointer1 = $.trim($(this).find(".div-drop-down input:checkbox:checked:eq(0)").parent().attr("class")[0]);
        }
        else {
            objClaimCharges.DXPointer1 = 0;
        }

        if ($(this).find(".div-drop-down input:checkbox:checked:eq(1)").length > 0) {
            objClaimCharges.DXPointer2 = $.trim($(this).find(".div-drop-down input:checkbox:checked:eq(1)").parent().attr("class")[0]);
        }
        else {
            objClaimCharges.DXPointer2 = 0;
        }

        if ($(this).find(".div-drop-down input:checkbox:checked:eq(2)").length > 0) {
            objClaimCharges.DXPointer3 = $.trim($(this).find(".div-drop-down input:checkbox:checked:eq(2)").parent().attr("class")[0]);
        }
        else {
            objClaimCharges.DXPointer3 = 0;
        }

        if ($(this).find(".div-drop-down input:checkbox:checked:eq(3)").length > 0) {
            objClaimCharges.DXPointer4 = $.trim($(this).find(".div-drop-down input:checkbox:checked:eq(3)").parent().attr("class")[0]);
        }
        else {
            objClaimCharges.DXPointer4 = 0;
        }

        if ($(this).find(".div-drop-down input:checkbox:checked:eq(4)").length > 0) {
            objClaimCharges.DXPointer5 = $.trim($(this).find(".div-drop-down input:checkbox:checked:eq(4)").parent().attr("class")[0]);
        }
        else {
            objClaimCharges.DXPointer5 = 0;
        }

        if ($(this).find(".div-drop-down input:checkbox:checked:eq(5)").length > 0) {
            objClaimCharges.DXPointer6 = $.trim($(this).find(".div-drop-down input:checkbox:checked:eq(5)").parent().attr("class")[0]);
        }
        else {
            objClaimCharges.DXPointer6 = 0;
        }

        if ($(this).find(".div-drop-down input:checkbox:checked:eq(6)").length > 0) {
            objClaimCharges.DXPointer7 = $.trim($(this).find(".div-drop-down input:checkbox:checked:eq(6)").parent().attr("class")[0]);
        }
        else {
            objClaimCharges.DXPointer7 = 0;
        }

        if ($(this).find(".div-drop-down input:checkbox:checked:eq(7)").length > 0) {
            objClaimCharges.DXPointer8 = $.trim($(this).find(".div-drop-down input:checkbox:checked:eq(7)").parent().attr("class")[0]);
        }
        else {
            objClaimCharges.DXPointer8 = 0;
        }

        objClaimCharges.ServiceUnits = $.trim($(this).find(".txtUnits").val());

        if (objClaimCharges.ServiceUnits == "") objClaimCharges.ServiceUnits = 0;

        objClaimCharges.Modifier1 = $.trim($(this).find(".txtModifier1").val());
        objClaimCharges.Modifier2 = $.trim($(this).find(".txtModifier2").val());
        objClaimCharges.Modifier3 = $.trim($(this).find(".txtModifier3").val());
        objClaimCharges.Modifier4 = $.trim($(this).find(".txtModifier4").val());

        CPTCharges = $.trim($(this).find(".txtCharges").val());
        if (CPTCharges == "") CPTCharges = 0;
        CPTCharges = parseFloat(CPTCharges);

        objClaimCharges.TotalCharges = CPTCharges;

        objClaimCharges.BillingStatus = $.trim($(this).find(".ddlBillingStatus").val());

        listClaimCharges.push(objClaimCharges);

        ClaimTotal = ClaimTotal + CPTCharges;
        ClaimTotal = parseFloat(ClaimTotal);
    });

    objClaim.ClaimTotal = ClaimTotal;
    //objClaim.AmountDue = ClaimTotal;

    $.post(_EMRPath + "/Claims/CallBacks/SaveClaimHandler.aspx", { objClaim: JSON.stringify(objClaim), listClaimCharges: JSON.stringify(listClaimCharges), action: "SaveClaim" }, function (data) {
        if (_ClaimId == 0) {
            showSuccessMessage("Claim created successfully!");

            var start = data.indexOf("###StartClaimId###") + 18;
            var end = data.indexOf("###EndClaimId###");
            _ClaimId = $.trim(data.substring(start, end));

            $("[id$='chkIsPTL']").prop("disabled", false);
        }
        else {
            showSuccessMessage("Claim updated successfully!");
        }

        SetClaimServices(data);
        //FilterClaims(0, true);
        SetClaimGridData(data);

        //$(".billing-manager-main-divs").hide();
        //$("[id$='divClaimAll']").show();
    });
}

function SetClaimServices(data) {
    var start = data.indexOf("###StartClaimServices###") + 24;
    var end = data.indexOf("###EndClaimServices###");
    var returnHtml = $.trim(data.substring(start, end));

    $("#tbodyClaimServices").html(returnHtml);
}

function SetClaimGridData(data) {
    var start = data.indexOf("###StartBillingHandler###") + 25;
    var end = data.indexOf("###EndBillingHandler###");
    var returnHtml = $.trim(data.substring(start, end));

    $("#ClaimsList").html(returnHtml)
    .promise()
    .done(function () {
        GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");

        if ($("[id$='hdnClaimsCount']").val() > 0) {
            $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
        }
    });

}

function openPatiantSearch() {
    $.post(_ControlPath + "/PatientSearch.aspx", {}, function (data) {
        var start = data.indexOf("###StartPatientSearch###") + 24;
        var end = data.indexOf("###EndPatientSearch###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#divPopupPatient").html(returnHtml).dialog({
            title: "Patient Search",
            height: 500,
            width: 900,
            modal: true,
            buttons: {
                Select: function () {
                    selectPatientForClaim();
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                $(this).dialog("destroy");
            }
        });
    });
}

function selectPatientForClaim() {
    if ($(".trSelected").length == 0) {
        showErrorMessage("Please select some patient.");
        return;
    }

    _PatientId = $.trim($(".trSelected td:eq(1)").html());

    var patiantName = $.trim($(".trSelected td:eq(3)").html()) + " " + $.trim($(".trSelected td:eq(2)").html());

    var PatientDOB = $.trim($(".trSelected td:eq(5)").html());
    var PatientGender = $.trim($(".trSelected td:eq(4)").html());
    var MaritalStatusPatient = $.trim($(".trSelected").find(".hdnMaritalStatus").val());
    var CellPatient = $.trim($(".trSelected td:eq(6)").html());
    var HomePhonePatient = $.trim($(".trSelected").find(".hdnHomePhone").val());
    var WorkPhonePatient = $.trim($(".trSelected").find(".hdnWorkPhone").val());
    var AddressPatient = $.trim($(".trSelected").find(".patientAddress").html());
    var _patientImagePath = $.trim($(".trSelected").find(".hdnImageFileName").val());
    var PatientCity = $.trim($(".trSelected").find(".patientCity").html());
    var PatientState = $.trim($(".trSelected").find(".patientState").html());
    var PatientZip = $.trim($(".trSelected").find(".patientZip").html());

    $("[id$='lblPatientId']").html("Account No: " + _PatientId);
    $("[id$='lblNamePatient']").html(patiantName);
    $("[id$='lblDOBPatient']").html(PatientDOB);
    $("[id$='lblGenderPatient']").html(PatientGender);
    $("[id$='lblMaritalStatusPatient']").html(", " + MaritalStatusPatient);
    $("[id$='lblCellPatient']").html(CellPatient);
    $("[id$='lblHomePhonePatient']").html(", " + HomePhonePatient);
    $("[id$='lblWorkPhonePatient']").html(", " + WorkPhonePatient);
    $("[id$='lblAddressPatient']").html(AddressPatient + ", " + PatientCity + ", " + PatientState + ", " + PatientZip);

    if (_patientImagePath != "") {
        $("[id$='imgPatientPhoto']").attr("src", _PracticeDocumentsPath + "/" + _PracticeId + "/Patients/" + _PatientId + "/" + _patientImagePath);
    }
    else {
        if (PatientGender == "Male") {
            $("[id$='imgPatientPhoto']").attr("src", _RooTPath + "Images/maleIcon.png");
        }
        else if (PatientGender == "Female") {
            $("[id$='imgPatientPhoto']").attr("src", _RooTPath + "Images/FemaleIcon.png");
        }
    }

    if (PatientGender == "Female") {
        $(".tdFemale").show();
    }
    else {
        $(".tdFemale").hide();
    }

    $("#imgPhone").attr("src", _RooTPath + "Images/phone.png");

    $("#divPopupPatient").dialog("close");
    $("[id$='divPatientInfo']").show();

    $.post("CallBacks/PatientInsurenceHandler.aspx", { PatientId: _PatientId }, function (data) {
        var startInsurence = data.indexOf("###StartPrimaryInsurances###") + 28;
        var endInsurence = data.indexOf("###EndPrimaryInsurances###");
        $("[id$='ddlPrimaryInsurance']").replaceWith($.trim(data.substring(startInsurence, endInsurence)));

        startInsurence = data.indexOf("###StartSecondaryInsurances###") + 30;
        endInsurence = data.indexOf("###EndSecondaryInsurances###");
        $("[id$='ddlSecondaryInsurance']").replaceWith($.trim(data.substring(startInsurence, endInsurence)));

        startInsurence = data.indexOf("###StartOtherInsurances###") + 26;
        endInsurence = data.indexOf("###EndOtherInsurances###");
        $("[id$='ddlOtherInsurance']").replaceWith($.trim(data.substring(startInsurence, endInsurence)));

        startInsurence = data.indexOf("###StartPatientAppintmentsDate###") + 33;
        endInsurence = data.indexOf("###EndPatientAppintmentsDate###");
        $("[id$='ddlDos']").parent("td").html($.trim(data.substring(startInsurence, endInsurence)));
    });
}

function filterPatients(pageNumber, paging) {
    $.post(_EMRPath + "/Claims/CallBacks/CreateClaimPatientsListHandler.aspx", { PracticeLocationsId: $("[id$='ddlLocation']").val(), InsuranceId: $("[id$='ddlInsurance']").val(), Rows: $("#ddlPagingCreateClaim").val(), PageNumber: pageNumber, ClaimType: _ClaimType, Action: "Filter" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartCreateClaimHandler###") + 29;
        var end = data.indexOf("###EndCreateClaimHandler###");
        $("#divCreatClaimContent .WidgetMainContent").html(returnHtml.substring(start, end));
        $(".billing-manager-main-divs").hide();
        $("#divClaimsSubmissionContent").show();

        if (paging == true) {
            GeneratePaging($("[id$='hdnEpisodeCount']").val(), $("#ddlPagingCreateClaim").val(), "divPatients", "filterPatients");
        }
        if ($("[id$='hdnEpisodeCount']").val() > 0) {
            $("#divPatients .spanInfo").html("Showing " + $("#PatientsList tr:first").children().first().html() + " to " + $("#PatientsList tr:last").children().first().html() + " of " + $("[id$='hdnEpisodeCount']").val() + " entries");
        }
    });
}

function HideShowMenuPointer(elm) {
    $(elm).next().slideToggle();
}

function ResetPointers(elm) {
    $(elm).parent().parent().slideToggle();
}

function PopulatePointers(elm) {
    var _Pointers = "";
    $(elm).parent().parent().find("input:checkbox:checked").each(function () {
        _Pointers += $.trim($(this).next().html()).slice(-1) + ", ";
    });

    if (_Pointers.length > 0) {
        _Pointers = _Pointers.substring(0, _Pointers.length - 2);
    }

    $(elm).parent().parent().prev().find(".selectedText").html(_Pointers).attr("title", _Pointers);

    $(elm).parent().parent().slideToggle();
}

function PopulatePointersOnLoad() {
    $("#tblItemsTreatmentPlan > tbody > tr:not(:last)").each(function () {
        var _Pointers = "";
        $(this).find(".dropdownMenuMultipleCheckBox input:checkbox:checked").each(function () {
            _Pointers += $.trim($(this).next().html()).slice(-1) + ", ";
        });

        _Pointers = _Pointers.substring(0, _Pointers.length - 2);
        if (_Pointers.length > 0) {
            $(this).find(".selectedText").text(_Pointers);
        }
    });
}

function DxPointer1Check(event, elem) {
    event.stopPropagation();

    ifPointerLengthIs4(elem);

    if ($.trim($("[id$='txtIcdCode1']").val()) == "") {
        return false;
    }
}

function DxPointer2Check(event, elem) {
    event.stopPropagation();

    ifPointerLengthIs4(elem);

    if ($.trim($("[id$='txtIcdCode2']").val()) == "") {
        return false;
    }
}

function DxPointer3Check(event, elem) {
    event.stopPropagation();

    ifPointerLengthIs4(elem);

    if ($.trim($("[id$='txtIcdCode3']").val()) == "") {
        return false;
    }
}

function DxPointer4Check(event, elem) {
    event.stopPropagation();

    ifPointerLengthIs4(elem);

    if ($.trim($("[id$='txtIcdCode4']").val()) == "") {
        return false;
    }
}

function DxPointer5Check(event, elem) {
    event.stopPropagation();

    ifPointerLengthIs4(elem);

    if ($.trim($("[id$='txtIcdCode5']").val()) == "") {
        return false;
    }
}

function DxPointer6Check(event, elem) {
    event.stopPropagation();

    ifPointerLengthIs4(elem);

    if ($.trim($("[id$='txtIcdCode6']").val()) == "") {
        return false;
    }
}

function DxPointer7Check(event, elem) {
    event.stopPropagation();

    ifPointerLengthIs4(elem);

    if ($.trim($("[id$='txtIcdCode7']").val()) == "") {
        return false;
    }
}

function DxPointer8Check(event, elem) {
    event.stopPropagation();

    ifPointerLengthIs4(elem);

    if ($.trim($("[id$='txtIcdCode8']").val()) == "") {
        return false;
    }
}

function ifPointerLengthIs4(elem) {
    var dropdownMenuMultipleCheckBox = $(elem).closest(".dropdownMenuMultipleCheckBox");

    var checkedPointersLength = dropdownMenuMultipleCheckBox.find("input:checkbox:checked").length;

    if (checkedPointersLength == 5) {
        $(elem).prop("checked", false);
        return false;
    }

    return true;
}

function DxPointerCheck() {
    if ($.trim($("[id$='txtIcdCode1']").val()) == "") {
        //return false;
        $(".DX1PointerCheckbox :checkbox").prop("checked", false);
    }
    if ($.trim($("[id$='txtIcdCode2']").val()) == "") {
        $(".DX2PointerCheckbox :checkbox").prop("checked", false);
    }
    if ($.trim($("[id$='txtIcdCode3']").val()) == "") {
        $(".DX3PointerCheckbox :checkbox").prop("checked", false);
    }
    if ($.trim($("[id$='txtIcdCode4']").val()) == "") {
        $(".DX4PointerCheckbox :checkbox").prop("checked", false);
    }
}

function changeClaimStatus(elem) {
    var lengthReadyForSubmission = $(".claim-status-combo option:selected[value='102']").length;
    var lengthRebill = $(".claim-status-combo option:selected[value='103']").length;

    if ((lengthReadyForSubmission > 1 || lengthRebill > 1) || (lengthReadyForSubmission == 1 && lengthRebill == 1)) {
        $(elem).val(0);
        showErrorMessage("Sorry! you cannot have this status for more than one insurances!");
    }
}

function changeLocationClaim(elem) {
    var PracticeLocationsId = $(elem).val();

    var providers = $.grep(_arrProvidersByLocation, function (v, i) {
        return (v.PracticeLocationsId == PracticeLocationsId);
    });

    var providerHtml = '<option value=""></option>';

    for (var i = 0; i < providers.length; i++) {
        providerHtml += '<option value="' + providers[i].ServiceProviderId + '">' + providers[i].Name + '</option>';
    }

    $("[id$='ddlAttendingPhy']").html(providerHtml);
    $("[id$='ddlBillingPhy']").html(providerHtml);
    $("[id$='ddlReferringPhy']").html(providerHtml);
    $("[id$='ddlRenderingPhysician']").html(providerHtml);
    $("[id$='ddlSupervisingPhysician']").html(providerHtml);
}

var searchfrom, _CurrentTextBoxICD = null;

function searchIcDs(searchBy, code, desc, elm, event) {
    _CurrentTextBoxICD = $(elm);
    if (event.keyCode == 27) {
        $("#divICDsSearched").hide();
        return false;
    }

    $.post(_ControlPath + "/ICDSearch.aspx", { Code: $.trim(code), Description: $.trim(desc) }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartICDSearch###") + 20;
        var end = data.indexOf("###EndICDSearch###");
        $("#divICDsSearched").html(returnHtml.substring(start, end));

        var tdClass = $(elm).closest("td").attr('class');

        if (tdClass == "leftTd") {
            $("#divICDsSearched").css({
                left: 7 + "%",
                top: $(elm).offset().top - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + $(elm).closest("td").height() + "px"
            });
        }
        else if (tdClass == "rightTd") {
            var _leftCss;
            if ($(elm).attr("id") == "txtIcdCode2" || $(elm).attr("id") == "txtIcdCode4") {
                _leftCss = $(elm).offset().left + "px";
            } else {
                _leftCss = $(elm).offset().left - ($("#divICDsSearched").width() - $(elm).closest("td").width()) - 35 + "px";
            }
            $("#divICDsSearched").css({
                left: _leftCss,
                top: $(elm).offset().top - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + $(elm).closest("td").height() + "px"
            });

        }
        $("#divICDsSearched").show();
        searchfrom = $(elm).attr('id');
    });
}

function SelectICD(elem) {

    var icdCode = $.trim($(elem).closest("tr").find(".hdnCode").html());
    var IcdDesc = $.trim($(elem).closest("tr").find(".hdnDescription").html());

    _CurrentTextBoxICD = null;
    $("#divICDsSearched").hide();
    if (searchfrom.substring(6, 10) == "Desc") {
        $("#" + searchfrom).val(IcdDesc);
        $("#" + searchfrom).parent("td").prev().find("input").val(icdCode);
    }
    else if (searchfrom.substring(6, 10) == "Code") {
        $("#" + searchfrom).val(icdCode);
        $("#" + searchfrom).parent("td").next().find("input").val(IcdDesc);
    }
}

$(document).on("click", "body", function (event) {
    var currentBox = $(event.target);
    if (_CurrentTextBoxICD != null) {
        if (currentBox == _CurrentTextBoxICD || currentBox == _CurrentCPTSearchedElement) {
            return;
        }
    }

    $("#divICDsSearched").hide();
    $("#divCPTSearched").hide();
    $(".divMedicineSearched").hide();
});

$(document).on("keyup", "body", function (e) {
    if (e.keyCode == 27) {
        $("#divICDsSearched").hide();
        $("#divCPTSearched").hide();
        $(".divMedicineSearched").hide();
    }
});

function emptyICDVal(elm, code) {

    $(elm).parent("td").find("input").val('');
    $(elm).parent("td").prev().find("input").val('');

    $(".DX" + code + "PointerCheckbox :checkbox").prop("checked", false);

    $("#tblItemsTreatmentPlan tbody tr:not(:last) .selectedText").each(function () {
        var SelectedText = $(this).text();
        if (SelectedText.length == 1) {
            SelectedText = SelectedText.replace(code, '');
        }
        else {
            SelectedText = SelectedText + ", ";
            SelectedText = SelectedText.replace(code + ", ", '');
            SelectedText = SelectedText.substring(0, SelectedText.length - 2);
        }

        $(this).text(SelectedText);
        $(this).attr('title', SelectedText);

    });
}

function PopulateICD9Desc(elm, descInputId) {
    var flag = 0;
    $("#divICDsSearched table tbody tr").each(function () {
        var code = $.trim($(this).find("td:eq(0)").html());
        if ($(elm).val() == code) {
            var desc = $.trim($(this).find("td:eq(1)").html());
            $("#" + descInputId).val(desc);
            flag = 1;
            return;
        }
    });

    if (flag == 0) {
        $(elm).val("");
        $("#" + descInputId).val("");
    }
}

function PopulateICD9Code(elm, codeInputId) {
    var flag = 0;

    $("#divICDsSearched table tbody tr").each(function () {
        var desc = $.trim($(this).find("td:eq(1)").html());

        if ($(elm).val().toUpperCase() == desc.toUpperCase()) {
            var code = $.trim($(this).find("td:eq(0)").html());
            $("#" + codeInputId).val(code);
            flag = 1;

            return;
        }
    });

    if (flag == 0) {
        $(elm).val("");
        $("#" + descInputId).val("");
    }
}

var _CurrentCPTSearchedElement;

function searchCPTs(elem, event) {
    _CurrentCPTSearchedElement = $(elem);
    var Code = $.trim($(elem).val());
    //$(elem).val("");

    if (event.keyCode == 27) {
        $("#divICDsSearched").hide();
        return false;
    }
 
    $.post(_EMRPath + "/Controls/CPTCodesSearch.aspx", { Code: Code }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartCPTSearch###") + 20;
        var end = data.indexOf("###EndCPTSearch###");
        $("#CPTSearchedList").html(returnHtml.substring(start, end));
        AddNoRecordFoundInGrids("CPTSearchedList");
        $("#divCPTSearched").css({
            left: $(elem).offset().left,
            top: $(elem).offset().top - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + $(elem).closest("td").height() + "px"
        });

        $("#divCPTSearched").slideDown("slow");
        $("#divCPTSearched").scrollTop(0);

        addServiceRow(elem);
    });
}

function SelectCPT(elem) {
    var code = $.trim($(elem).find(".cpt-code").html());
    var description = $.trim($(elem).find(".cpt-description").html());
    var dos = $("select[name$='ddlDos']").val();

    _CurrentCPTSearchedElement.val(code + " - " + description);

    SetCPTFieldsInServiceRowOnCPTCodeSelect(_CurrentCPTSearchedElement, code);

    /*
    _CurrentCPTSearchedElement.parent().find(".hdnProceduresCode").val(code);
    _CurrentCPTSearchedElement.closest("tr").find(".hdnCPTCode").val(code);
    _CurrentCPTSearchedElement.closest("tr").find(".txtUnits").val("1");
    _CurrentCPTSearchedElement.closest("tr").find(".cbIncludeInSubmission").find("input").attr("checked", true);
    */

    $.post(_EMRPath + "/Claims/CallBacks/GetServiceCharges.aspx", { code: code, dos: dos }, function (data) {
        var htmData = data;
        var start = data.indexOf("###StartClaimsSubmission###") + 27;
        var end = data.indexOf("###EndClaimsSubmission###");
        var htmDom = htmData.substring(start, end);
        $("div[id$='ServiceCharges']").html(htmDom);

        _CurrentCPTSearchedElement.closest("tr").find(".txtCharges").val($("div[id$='ServiceCharges']").find("#hdnParCharges").val());
        _CurrentCPTSearchedElement.closest("tr").find(".hdnClaimCPTCharges").val($("div[id$='ServiceCharges']").find("#hdnParCharges").val());
    });

    $("#divCPTSearched").slideUp("slow");
}

function SetCPTFieldsInServiceRowOnCPTCodeSelect($elem, CPTcode) {
    var CurrentServiceRow = $elem.closest("tr");

    CurrentServiceRow.find(".hdnProceduresCode").val(CPTcode);
    CurrentServiceRow.find(".hdnCPTCode").val(CPTcode);

    CurrentServiceRow.find(".txtUnits").val("1");
    CurrentServiceRow.find(".cbIncludeInSubmission").find("input").attr("checked", true);
}

var _CurrentDrugSearchedElement;

function SearchDrugs(elem) {
    _CurrentDrugSearchedElement = $(elem);

    var SearchValue = $.trim($(elem).val());

    if (SearchValue == "") {
        $(elem).closest("tr").find(".divDrugSearchList").hide();

        return;
    }

    var params = {
        SearchValue: SearchValue,
        action: "Filter"
    };

    $.post(_ControlPath + "/FilterDrugs.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $(elem).closest("tr").find(".tbodyClaimDrugs").html(returnHtml);
        $(elem).closest("tr").find(".divDrugSearchList").show();

        addServiceRow(elem);
    });
}

function SelectDrugs(elem) {
    var DrugCode = $.trim($(elem).find(".spnDrugCode").html());
    var DrugName = $.trim($(elem).find(".spnDrugName").html());
    var DrugNDC = $.trim($(elem).find(".spnNDC").html());
    var DrugCharges = $.trim($(elem).find(".hdnNDCCharges").val());

    var CPTcode = $.trim($(elem).find(".hdnCPTcodeDrugSearched").val());
    var CPTdescription = $.trim($(elem).find(".hdnCPTdescriptionDrugSearched").val());

    _CurrentDrugSearchedElement.val(DrugName);

    var CurrentServiceRow = _CurrentDrugSearchedElement.closest("tr");

    CurrentServiceRow.find(".txtProcedures").val(CPTcode + " - " + CPTdescription);

    CurrentServiceRow.find(".hdnDrug").val(DrugNDC);
    CurrentServiceRow.find(".txtCharges").val(DrugCharges);

    SetCPTFieldsInServiceRowOnCPTCodeSelect(_CurrentDrugSearchedElement, CPTcode);

    $(".divDrugSearchList").hide();
}

function deleteServiceRow(elem) {
    var chargesId = $.trim($(elem).closest("tr").find(".hdnClaimChargesId").val());

    if (chargesId == 0) {
        return;
    }

    ShowConfirmation("Are you sure to delete the service?").done(function () {
        if (!$(elem).closest("tr").hasClass("lastServiceRow")) {
            $.post(_EMRPath + "/Claims/CallBacks/SaveClaimHandler.aspx", { chargesId: chargesId, action: "DeleteCharges" }, function (data) {
                $(elem).closest("tr").not(".lastServiceRow").remove();
                showSuccessMessage(_msg_Deleted);
            });
        }
    });
}

function addServiceRow(elem) {
    if ($(elem).hasClass("txtUnits")) {
        var charges = $(elem).closest("tr").find(".hdnClaimCPTCharges").val();
        var Units = $(elem).val();
        var totalCharge = 0;

        if (Units == parseFloat(Units) && charges == parseFloat(charges)) {
            totalCharge = parseFloat(Units) * parseFloat(charges);
            $(elem).closest("tr").find(".txtCharges").val(totalCharge);
        }
    }

    if (!$(elem).closest("tr").is(".lastServiceRow")) {
        return;
    }

    $("#tbodyClaimServices > tr").removeClass("lastServiceRow");
    var serviceRowHtml = $.trim($("#tbodySampleServiceRow").html());
    $("#tbodyClaimServices").append(serviceRowHtml);
}

function backSaveClaim() {
    $(".billing-manager-main-divs").hide();
    $("[id$='divClaimAll']").show();
}

function showPointerPop(txtobj) {
    var table = "";
    var pointer = 0;
    var code = "";
    table += '<tr onclick="PointerSelected(\'' + pointer + '\');">';
    table += "<td align='center'>0</td>";
    table += "<td>x</td></tr>";

    for (var i = 0; i <= 3; i++) {
        pointer++;
        code = $("#divdiagnoseCode table tr:eq(" + i + ")").find("td:eq(1) input").val();
        if (code != "") {
            table += "<tr onclick='PointerSelected(" + pointer + ");'>";
            table += "<td align='center'>" + pointer + "</td>";
            table += "<td>" + code + "</td></tr>";
        }
    }
    for (var i = 0; i <= 3; i++) {
        pointer++;
        code = $("#divdiagnoseCode table tr:eq(" + i + ")").find("td:eq(4) input").val();
        if (code != "") {
            table += "<tr onclick='PointerSelected(" + pointer + ");'>";
            table += "<td align='center'>" + pointer + "</td>";
            table += "<td>" + code + "</td></tr>";
        }
    }

    $("#tBodyPointer").html(table);
    _SelectedPointertd = txtobj;

    $("#divPointers").dialog({
        height: 200,
        width: 220,
        modal: true,
        buttons: {
            "Close": function () {
                $(this).dialog("close");
            }
        }
    });
}

function PointerSelected(pointer) {
    if (pointer == "0")
        $(_SelectedPointertd).val("");
    else
        $(_SelectedPointertd).val(pointer);


    _CreateClaimFlag = true;
    $("#divPointers").dialog("close");
    $(_SelectedPointertd).parent().parent().find("span.changeFlag").html("1");
}

function changeFlagProcedure(obj, id) {
    if (id == "M")
        $(obj).parent().parent().parent().parent().find("span.changeFlag").html("1");
    else
        $(obj).parent().parent().find("span.changeFlag").html("1");

    _CreateClaimFlag = true;
}

//***************************************Claim Submission**************************************//

function bntclaimSubmission_Click() {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("UnProcessedClaimsView")) {
        $("[id$='divRightsSettings']").html(_msg_UnProcessedClaimsView).show();
        return false;
    }
    if (_CreateClaimFlag) {
        $("#dialogconfirmMaster").html("Do you want leave these changes?");
        $("#dialogconfirmMaster").dialog({
            resizable: false,
            height: 140,
            width: 300,
            modal: true,
            title: 'Confirmation',
            buttons: {
                "Yes": function () {
                    $(this).dialog("close");
                    _CreateClaimFlag = false;
                    claimSubmission();
                },
                "No": function () {
                    $(this).dialog("close");
                }
            }
        });
    } else {
        claimSubmission();
    }
}

function claimSubmission() {

    $(".button-image").removeClass("selected");
    $(".selected-icons").removeClass("button-selected");

    $("#btnClaimSubmissionMain .button-image").addClass("selected");
    $("#btnClaimSubmissionMain .selected-icons").addClass("button-selected");

    $.post("../Claims/CallBacks/ClaimSubmission.aspx", function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartClaimsSubmission###") + 27;
        var end = data.indexOf("###EndClaimsSubmission###");
        $("#divClaimsSubmissionContent .WidgetMainContent").html(returnHtml.substring(start, end));

        $(".billing-manager-main-divs").hide();
        $("#divClaimsSubmissionContent").show();

        GeneratePaging($("[id$='hdnUnProcessedClaimsCount']").val(), $("#ddlPagingUnprocessedClaims").val(), "divUnProcessedClaimsParent", "FilterUnProcessedClaims");

        if ($("[id$='hdnUnProcessedClaimsCount']").val() > 0) {
            $("#divUnProcessedClaimsParent .spanInfo").html("Showing " + $("#UnProcessedClaimsList tr:first").children().first().html() + " to " + $("#UnProcessedClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnUnProcessedClaimsCount']").val() + " entries");
        }
        $("#UnProcessedClaimsList input").change(function () {
            _ClaimSubmissionFlag = true;
        });

        $("#btnClaimSubmission").hide();
        $("#divSubmissionStatusCodesFilter").hide();

        GeneratePaging($("[id$='hdnPendingSubmissionCount']").val(), $("#ddlPendignSubmissions").val(), "divPendingSubmission", "FilterPendingSubmissions");
        if ($("[id$='hdnPendingSubmissionCount']").val() > 0) {
            $("#divPendingSubmission .spanInfo").html("Showing " + $("#PendingSubmissionsList tr:first").children().first().html() + " to " + $("#PendingSubmissionsList tr:last").children().first().html() + " of " + $("[id$='hdnPendingSubmissionCount']").val() + " entries");
        }

    });
    _CreateClaimFlag = false;
    $("#divUnProcessedClaimsParent").show();
}

function FilterUnProcessedClaims(pageNumber, paging) {
    $.post("../Claims/CallBacks/UnProcessedClaimsHandler.aspx", { Rows: $("#ddlPagingUnprocessedClaims").val(), PageNumber: pageNumber, Action: "Filter", PatientName: $("#txtUCPatientName").val(), InsuranceName: $("#txtUCInsuranceName").val(), ClaimNumber: $("#txtUCClaimNumber").val() }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartUnProcessedClaimsHandler###") + 35;
        var end = data.indexOf("###EndUnProcessedClaimsHandler###");
        $("#UnProcessedClaimsList").html(returnHtml.substring(start, end));
        if (paging == true) {
            GeneratePaging($("[id$='hdnUnProcessedClaimsCount']").val(), $("#ddlPagingUnprocessedClaims").val(), "divUnProcessedClaimsParent", "FilterUnProcessedClaims");
        }
        if ($("[id$='hdnUnProcessedClaimsCount']").val() > 0) {
            $("#divUnProcessedClaimsParent .spanInfo").html("Showing " + $("#UnProcessedClaimsList tr:first").children().first().html() + " to " + $("#UnProcessedClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnUnProcessedClaimsCount']").val() + " entries");
        }
        $("#UnProcessedClaimsList input").change(function () {
            _ClaimSubmissionFlag = true;
        });
    });
}


function FilterPendingSubmissions(pageNumber, paging) {
    $.post("../Claims/CallBacks/PendingSubmissionHandler.aspx", { Rows: $("#ddlPagingUnprocessedClaims").val(), PageNumber: pageNumber, Action: "Filter" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("#PendingSubmissionStart#") + 24;
        var end = data.indexOf("#PendingSubmissionEnd#");
        $("#PendingSubmissionsList").html(returnHtml.substring(start, end));

        if (paging == true) {
            GeneratePaging($("[id$='hdnPendingSubmissionCount']").val(), $("#ddlPendignSubmissions").val(), "divPendingSubmission", "FilterPendingSubmissions");
        }
        if ($("[id$='hdnPendingSubmissionCount']").val() > 0) {
            $("#divPendingSubmission .spanInfo").html("Showing " + $("#PendingSubmissionsList tr:first").children().first().html() + " to " + $("#PendingSubmissionsList tr:last").children().first().html() + " of " + $("[id$='hdnPendingSubmissionCount']").val() + " entries");
        }
    });
}

function GeneratePendingSubmissionsFile() {
    var insuranceids = "";
    $("#PendingSubmissionsList tr").each(function () {
        if ($(this).find("input").is(":checked"))
            insuranceids += $(this).attr("id") + ",";
    });
    if (insuranceids == "")
        showErrorMessage("Error: Select atleast one record.");
    else {
        alert(insuranceids);
        debugger;
        $.post("../Claims/CallBacks/PendingSubmissionHandler.aspx", { Rows: $("#ddlPagingUnprocessedClaims").val(), PageNumber: "0", Action: "Generate File", insuranceids: insuranceids }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("#PendingSubmissionStart#") + 24;
            var end = data.indexOf("#PendingSubmissionEnd#");
            $("#PendingSubmissionsList").html(returnHtml.substring(start, end));

            //if (paging == true) {
            GeneratePaging($("[id$='hdnPendingSubmissionCount']").val(), $("#ddlPendignSubmissions").val(), "divPendingSubmission", "FilterPendingSubmissions");
            //}
            if ($("[id$='hdnPendingSubmissionCount']").val() > 0) {
                $("#divPendingSubmission .spanInfo").html("Showing " + $("#PendingSubmissionsList tr:first").children().first().html() + " to " + $("#PendingSubmissionsList tr:last").children().first().html() + " of " + $("[id$='hdnPendingSubmissionCount']").val() + " entries");
            }
        });
    }
}

function generateSubmissionFile() {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("GenerateSubmissionFile")) {
        $("[id$='divRightsSettings']").html(_msg_GenerateSubmissionFile).show();
        return false;
    }

    var submissionList = new Array();
    var claims = "";

    $("#UnProcessedClaimsList tr").find("input:checked").each(function () {
        var claimSubmission = new Object();
        claimSubmission.ClaimsSubmissionId = 0;
        claimSubmission.PatientAccount = $.trim($(this).parent().parent().find("span[id^='rptUnProcessedClaims_spnPatientId_']").html());
        claimSubmission.PracticeLocationsId = $.trim($(this).parent().parent().find("span[id^='rptUnProcessedClaims_spnPracticeLocationsId_']").html());
        claimSubmission.EpisodeId = $.trim($(this).parent().parent().find("span[id^='rptUnProcessedClaims_spnEpisodeId_']").html());
        claimSubmission.ClaimNo = $.trim($(this).parent().parent().find("span[id^='rptUnProcessedClaims_spnClaimId_']").html());
        claimSubmission.InsuranceId = $.trim($(this).parent().parent().find("span[id^='rptUnProcessedClaims_spnInsuranceId_']").html());

        submissionList.push(claimSubmission);
        claims += $.trim($(this).parent().parent().find("span[id^='rptUnProcessedClaims_spnClaimId_']").html()) + ",";
    });

    if (submissionList.length == 0) {
        dialogShowMessage("Please select at least 1 claim to Generete Submission File!", "Required");
        return false;
    } else {
        $.post("../Claims/CallBacks/UnProcessedClaimsHandler.aspx", { SubmissionList: JSON.stringify(submissionList), claims: claims, Rows: $("#ddlPagingUnprocessedClaims").val(), PageNumber: 0, Action: "Generate File" }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartUnProcessedClaimsHandler###") + 35;
            var end = data.indexOf("###EndUnProcessedClaimsHandler###");
            $("#UnProcessedClaimsList").html(returnHtml.substring(start, end));
            GeneratePaging($("[id$='hdnUnProcessedClaimsCount']").val(), $("#ddlPagingUnprocessedClaims").val(), "divUnProcessedClaimsParent", "FilterUnProcessedClaims");
            if ($("[id$='hdnUnProcessedClaimsCount']").val() > 0) {
                $("#divUnProcessedClaimsParent .spanInfo").html("Showing " + $("#UnProcessedClaimsList tr:first").children().first().html() + " to " + $("#UnProcessedClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnUnProcessedClaimsCount']").val() + " entries");
            }
            $("#UnProcessedClaimsList input").change(function () {
                _ClaimSubmissionFlag = true;
            });
            if ($("#divUnProcessedClaimsParent").find("input[id$='hdnMsg']").val().indexOf('Error') == -1) {
                showSuccessMessage("Success: Submission Files Genereated Successfully", "divBillingMangagerParent");
            } else {
                showErrorMessage("Error: Some Error occurred! ", "divBillingMangagerParent");
            }
        });
    }
    _ClaimSubmissionFlag = false;
    _NeedToGetSubmissionFiles = true;
    _NeedToGetSubmissionLog = true;
}

function getSubmissionFiles(fileId, action) {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("SubmissionFilesView")) {
        $("[id$='divRightsSettings']").html(_msg_SubmissionFilesView).show();
        return false;
    }
    if ($.trim($("#SubmissionFilesList").html()).length == 0 || action == 'Download' || _NeedToGetSubmissionFiles) {
        $.post("../Claims/CallBacks/SubmissionFilesHandler.aspx", { FileId: fileId, Rows: 10, PageNumber: 0, Action: action, FileName: $("#txtSFFileName").val(), CreatedDate: $("#txtSFGenerationDate").val() }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartSubmissionFilesHandler###") + 33;
            var end = data.indexOf("###EndSubmissionFilesHandler###");
            $("#SubmissionFilesList").html(returnHtml.substring(start, end));
            GeneratePaging($("[id$='hdnSubmissionFilesCount']").val(), $("#ddlPagingSubmissionFiles").val(), "divSubmissionFilesParent", "FilterSubmissionFiles");
            if ($("[id$='hdnSubmissionFilesCount']").val() > 0) {
                $("#divSubmissionFilesParent .spanInfo").html("Showing " + $("#SubmissionFilesList tr:first").children().first().html() + " to " + $("#SubmissionFilesList tr:last").children().first().html() + " of " + $("[id$='hdnSubmissionFilesCount']").val() + " entries");
            }
            $("#divUnProcessedClaimsParent").hide();
            $("#divSubmissionFilesParent").show();
            $("#divSubmissionLogParent").hide();
            _NeedToGetSubmissionFiles = false;
        });
    } else {
        $("#divUnProcessedClaimsParent").hide();
        $("#divSubmissionFilesParent").show();
        $("#divSubmissionLogParent").hide();
    }
}
function FilterSubmissionFiles(pageNumber, paging) {
    $.post("../Claims/CallBacks/SubmissionFilesHandler.aspx", { Rows: $("#ddlPagingSubmissionFiles").val(), PageNumber: pageNumber, Action: "Filter", FileName: $("#txtSFFileName").val(), CreatedDate: $("#txtSFGenerationDate").val() }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartSubmissionFilesHandler###") + 33;
        var end = data.indexOf("###EndSubmissionFilesHandler###");
        $("#SubmissionFilesList").html(returnHtml.substring(start, end));
        if (paging == true) {
            GeneratePaging($("[id$='hdnSubmissionFilesCount']").val(), $("#ddlPagingSubmissionFiles").val(), "divSubmissionFilesParent", "FilterSubmissionFiles");
        }
        if ($("[id$='hdnSubmissionFilesCount']").val() > 0) {
            $("#divSubmissionFilesParent .spanInfo").html("Showing " + $("#SubmissionFilesList tr:first").children().first().html() + " to " + $("#SubmissionFilesList tr:last").children().first().html() + " of " + $("[id$='hdnSubmissionFilesCount']").val() + " entries");
        }
    });
}
function downloadSubmissionFile(filePath, fileName, fileId) {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("SubmissionFilesDownload")) {
        $("[id$='divRightsSettings']").html(_msg_SubmissionFilesDownload).show();
        return false;
    }
    getSubmissionFiles(fileId, "Download");
    saveToDisk(filePath, fileName);
}

function getSubmissionLog() {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("SubmissionLogView")) {
        $("[id$='divRightsSettings']").html(_msg_SubmissionLogView).show();
        return false;
    }
    if ($.trim($("#SubmissionLogList").html()).length == 0 || _NeedToGetSubmissionLog) {
        $.post("../Claims/CallBacks/SubmissionLogHandler.aspx", {
            Rows: 10, PageNumber: 0, PatientName: $("#txtSLPatientName").val(), InsuranceName: $("#txtSLInsurance").val(), FileName: $("#txtSLFileName").val(),
            ClaimId: $("#txtSLClaimId").val(), SubmissionDate: $("#txtSLSubmissionDate").val(), SubmissionResults: $("#txtSLSubmissionResults").val()
        }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartSubmissionLogHandler###") + 31;
            var end = data.indexOf("###EndSubmissionLogHandler###");
            $("#SubmissionLogList").html(returnHtml.substring(start, end));
            GeneratePaging($("[id$='hdnSubmissionLogCount']").val(), $("#ddlPagingSubmissionLog").val(), "divSubmissionLogParent", "FilterSubmissionLog");
            if ($("[id$='hdnUnProcessedClaimsCount']").val() > 0) {
                $("#divSubmissionLogParent .spanInfo").html("Showing " + $("#SubmissionLogList tr:first").children().first().html() + " to " + $("#SubmissionLogList tr:last").children().first().html() + " of " + $("[id$='hdnSubmissionLogCount']").val() + " entries");
            }
            $("#divUnProcessedClaimsParent").hide();
            $("#divSubmissionFilesParent").hide();
            $("#divSubmissionLogParent").show();
            _NeedToGetSubmissionLog = false;
        });
    } else {
        $("#divUnProcessedClaimsParent").hide();
        $("#divSubmissionFilesParent").hide();
        $("#divSubmissionLogParent").show();
    }

}
function FilterSubmissionLog(pageNumber, paging) {
    $.post("../Claims/CallBacks/SubmissionLogHandler.aspx", {
        Rows: $("#ddlPagingSubmissionLog").val(), PageNumber: pageNumber,
        PatientName: $("#txtSLPatientName").val(), InsuranceName: $("#txtSLInsurance").val(), FileName: $("#txtSLFileName").val(),
        ClaimId: $("#txtSLClaimId").val(), SubmissionDate: $("#txtSLSubmissionDate").val(), SubmissionResults: $("#txtSLSubmissionResults").val()
    },
                function (data) {
                    var returnHtml = data;
                    var start = data.indexOf("###StartSubmissionLogHandler###") + 31;
                    var end = data.indexOf("###EndSubmissionLogHandler###");
                    $("#SubmissionLogList").html(returnHtml.substring(start, end));
                    if (paging == true) {
                        GeneratePaging($("[id$='hdnSubmissionLogCount']").val(), $("#ddlPagingSubmissionLog").val(), "divSubmissionLogParent", "FilterSubmissionLog");
                    }
                    if ($("[id$='hdnSubmissionLogCount']").val() > 0) {
                        $("#divSubmissionLogParent .spanInfo").html("Showing " + $("#SubmissionLogList tr:first").children().first().html() + " to " + $("#SubmissionLogList tr:last").children().first().html() + " of " + $("[id$='hdnSubmissionLogCount']").val() + " entries");
                    }
                });
}
function showHideClaimSubmissionTabs(contentId, id) {
    $(".Tab-Content").each(function () {
        $(this).css("display", "none");
    });
    if (id == "1") {
        $("#divPendingSubmission").show();
    }
    if (id == "2") {
        $("#divUnProcessedClaimsParent").show();
    }
    else if (id == "3")
        getSubmissionLog();
    else if (id == "4")
        getSubmissionFiles("", "");

}



function bntPostPayment_Click() {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("ClaimPaymentView")) {
        $("[id$='divRightsSettings']").html(_msg_ClaimPaymentView).show();
        return false;
    }
    window.location = "AllClaims.aspx";
}

function printClaim(elem) {

    debugger;
    $("[id$='divRightsSettings']").hide();

    var currentClaimRow = $(elem).closest("tr");
    _ClaimId = currentClaimRow.find(".hdnClaimId").val();
    _PatientId = currentClaimRow.find(".hdnPatientId").val();
    var SubmissionStatusId = currentClaimRow.find(".hdnSubmissionStatusId").val();

    if (_ClaimId == 0) {
        return;
    }
    _IsPrintFromList = true;
    openPrintingOptionCMSForm();
}

function openPrintingOptionCMSForm() {
    $("#divDialogPrintCMSForm").dialog({
        title: 'Printing option',
        modal: true,
        close: function () {
            $(this).dialog("destroy");
        }
    });
}

function closeCMSDialog() {
    debugger;
    if (!_IsPrintFromList) {
        window.location = _EMRPath + "/Claims/BillingManager.aspx";
    }
    else {
        $("#divDialogPrintCMSForm").dialog("close");
        _IsPrintFromList = false;
    }
}

function openCMSPrintPreview() {
    debugger;
    var isCMSBlank = $("[id$='rbPrintBlankCMS']").is(":checked");

    var url = _EMRPath + "/Claims/ClaimFormView.aspx?ClaimId=" + _ClaimId + "&PatientId=" + _PatientId + "&isCMSBlank=" + isCMSBlank;
    var win = window.open(url, '_blank');
    win.focus();

    _IsPrintFromList = false;
    $("#divDialogPrintCMSForm").dialog("close");
}

function showHideAdvanceOption() {
    if ($(".chkAdvance").is(":checked")) {
        $(".divAdvanceOption").show();
    }
    else {
        $(".divAdvanceOption").hide();
    }
}

var _elem;
function searchMedicine(elem) {
    _elem = elem;
    var medicine = $.trim($(elem).val());
    if (medicine == "") {
        $(elem).closest("tr").find(".divMedicineSearched").hide();
    } else {
        $.post(_ControlPath + "/FilterMedicineHandler.aspx", { Medicine: medicine }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartFilterMedicine###") + 25;
            var end = data.indexOf("###EndFilterMedicine###");
            $(elem).closest("tr").find(".tbodyMedicineSearch").html(returnHtml.substring(start, end));
            $(elem).closest("tr").find(".divMedicineSearched").show();
        });
    }
}

function selectMedicine(medicineId, medicineName, dose, rout, formulationCode) {
    $(".divMedicineSearched").hide();
    $(_elem).closest("tr").find(".hdnDrug").val(medicineId);
    $(_elem).val(medicineName);
}

function uncheckOtherAccident() {
    if ($("[id$='chkEmployment']").is(":checked") || $("[id$='chkAutoAccident']").is(":checked")) {
        $("[id$='chkOtherAccident']").prop("checked", false);
    }
    if ($("[id$='chkAutoAccident']").is(":checked")) {
        $("[id$='ddlAutoAccidentState']").removeAttr("disabled");
    }
    else {
        $("[id$='ddlAutoAccidentState']").attr("disabled", true);
    }
}
function checkOtherAccident() {
    if ($("[id$='chkOtherAccident']").is(":checked")) {
        $("[id$='chkEmployment'], [id$='chkAutoAccident']").prop("checked", false);
    }
    uncheckOtherAccident();
}

//Process EDI Files

function btnProcessEDIFile_Click() {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("ClaimPaymentView")) {
        $("[id$='divRightsSettings']").html(_msg_ClaimPaymentView).show();
        return;
    }

    window.location = _EMRPath + "/EDI/ProcessEDIFiles.aspx";
}


function ShowPatientAllClaims() {
    if (_PatientId == 0) return;

    var params = {
        PatientId: _PatientId,
        action: "LoadPatientClaims"
    };

    $.post(_ClaimPath + "/CallBacks/PatientClaims.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='tbodyPatientAllClaimsDropDown']").html(returnHtml)
        .promise()
        .done(function () {
            $("[id$='divPatientAllClaimsDropDown']").show();
        });
    });
}

function SearchClaimsFromClaimForm(elem) {
    var ClaimId = $.trim($(elem).val());

    if (ClaimId == "") {
        $("[id$='divAllClaimsDropDown']").hide();
        return;
    }

    var params = {
        ClaimId: $.trim($(elem).val()),
        action: "LoadAllClaims"
    };

    $.post(_ClaimPath + "/CallBacks/PatientClaims.aspx", params, function (data) {
        var start = data.indexOf("###StartAllClaims###") + 20;
        var end = data.indexOf("###EndAllClaims###");
        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='tbodyAllClaimsDropDown']").html(returnHtml)
        .promise()
        .done(function () {
            $("[id$='divAllClaimsDropDown']").show();
        });
    });
}
//Rizwan kharal 3April2018
function ClaimOpenForView(Claimid,PatientId,status) {
    debugger;
    var params = {
        ClaimId: Claimid,
        PatientId: PatientId,
        Status:status
    };
    $.post("../Claims/CallBacks/OpenClaimForm.aspx", params, function (data) {
        debugger;
        var start = data.indexOf("###StartAllClaims###") + 20;
        var end = data.indexOf("###EndAllClaims###");
       var returnHtml = $.trim(data.substring(start, end));
       $("#OpenClaimForm").html(returnHtml);

       $("#OpenClaimForm").dialog({
           width: 1060,
          // height:auto,
           modal: true,
           title: "Claim Details",
           open: function () {
               $(".ui-widget-overlay").last().css("z-index", "9999999");
               $(".ui-dialog").last().css("z-index", "99999999");
           },
           close: function () {
               $(this).dialog("destroy");
               $("#OpenClaimForm").hide();
           }
       });
   });
  
}
// start added by Arslan satti on 04/20/2022
function FilterSortingNotes(elem, type) {
    debugger
    $(".imgGreenUp").hide();
    $(".imgGreenDown").hide();
    $(".imgGrayDown").show();

    $(elem).find("img").toggle();

    var chkImg = $(elem).find("img").attr("class");
    if (chkImg == "imgGrayDown SortBy") {
        $(".imgGreenUp").hide();
    }
    if (chkImg == "imgGreenDown") {
        $(".imgGreenDown").hide();
    }
    if (chkImg == "imgGrayDown") {
        $(".imgGreenDown").hide();
    }
    if (chkImg == "imgGreenDown SortBy") {
        $(".imgGreenUp").hide();
    }
    $(elem).find("img").toggleClass('SortBy');
    var sortBy = $(elem).find("img").hasClass('SortBy');
    if (sortBy) {
        SORTBY = $.trim(type) + ' DESC';
    }
    else {
        SORTBY = $.trim(type) + ' ASC';
    }
    $("[id$='sortBy']").val(SORTBY);
    var ClaimId = $("#lblClaimId").text();
    
    $.post("../Claims/CallBacks/OpenClaimForm.aspx", { ClaimId: ClaimId, SORTBY: SORTBY, Action: "FilterClaimNotes" }, function (data) {
        debugger;
        var start = data.indexOf("###StartClaimNotes###") + 21;
        var end = data.indexOf("###EndClaimNotes###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbodyClaimNotes").html(returnHtml);
        var rowCount = $("#tbodyClaimNotes").html();
        if (rowCount == 0) {
            $("#tbodyClaimNotes").append("<tr><td colspan='5' class='ClaimNotesMessage'>No Record Found!</td></tr>");
        }
    });

}
// end added by Arslan satti on 04/20/2022