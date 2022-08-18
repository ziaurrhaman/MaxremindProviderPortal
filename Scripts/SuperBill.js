
var _PatientIdSuperBill = null;
var _AppointmentsIdSupperBill = null;
var _ChartIdSupperBill = null;
var _PhysicianIdSupperBill = 0;


function InitializeSuperBill() {
    $(".date").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");

    var DOS = $.trim($("[id$='txtDateOfService']").val());

    if (DOS == "") {
        $("[id$='txtDateOfService']").val(CurrentSystemDate());
    }
}


function GetParamsSuperBill(CallFrom) {
    var params;
    
    if (CallFrom == "AppointmentCalanderDetail") {
        _PatientIdSuperBill = $("[id$='hdnPatientIdAppointmentDetail']").val();
        _AppointmentsIdSupperBill = $("[id$='hdnAppointmentsIdAppointmentDetail']").val();
        _ChartIdSupperBill = 0;
        _PhysicianIdSupperBill = $.trim($("[id$='hdnAttendingPhysicianAppointmentDetail']").val());
        
        params = {
            PatientId: _PatientIdSuperBill,
            AppointmentsId: _AppointmentsIdSupperBill,
            ChartId: _ChartIdSupperBill,
            action: "LoadForm"
        };
    }
    else if (CallFrom == "PatientChart") {
        _PatientIdSuperBill = _PatientId;
        _AppointmentsIdSupperBill = 0;
        _ChartIdSupperBill = _ChartId;
        _PhysicianIdSupperBill = $.trim($("[id$='ddlSeenByProvider']").val());
        
        params = {
            PatientId: _PatientIdSuperBill,
            AppointmentsId: _AppointmentsIdSupperBill,
            ChartId: _ChartIdSupperBill,
            action: "LoadForm"
        };
    }

    return params;
}

function OpenSuperBill(event, CallFrom) {
    event.stopPropagation();
    
    var params = GetParamsSuperBill(CallFrom);

    if (CallFrom == "PatientChart" && (_ChartIdSupperBill == 0 || _PhysicianIdSupperBill == "")) {
        showErrorMessage("Please save chart information first.");
        return;
    }

    $.post(_ControlPath + "/SuperBill.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("[id$='divContainerOutSideForm']").html(returnHtml)
        .promise()
        .done(function () {
            $(".appointment-details-container").hide();
            InitializeSuperBill();

            $("[id$='divContainerOutSideForm']").dialog({
                modal: true,
                title: "Super Bill",
                width: 1000,
                height: $(window).height() - 20,
                open: function () {
                    $(".ui-datepicker").hide();
                },
                close: function () {
                    $("[id$='divContainerOutSideForm']").dialog("destroy");
                }
            });
        });
    });
}

function CloseSuperBill() {
    $("[id$='divContainerOutSideForm']").dialog("close");
}

function SaveSuperBill() {
    if (!ValidateForm("divSuperBillMainWrapper")) {
        showErrorMessage("");
        return;
    }
    
    var DOS = $.trim($("[id$='txtDateOfService']").val());
    
    if ($(".div-icd-wrapper input:checkbox:checked").length > 8) {
        showErrorMessage("You can select maximum 8 Dignosis ICD");
        return;
    }

    var objClaim = new Object();
    
    objClaim.ClaimId = $("[id$='hdnClaimIdSuperBill']").val();
    
    objClaim.PatientId = _PatientIdSuperBill;
    objClaim.DOS = DOS;
    objClaim.AttendingPhysician = _PhysicianIdSupperBill;
    
    objClaim.DxCode1 = ($(".div-icd-wrapper input:checkbox:checked")[0] == undefined) ? "" : $.trim($($(".div-icd-wrapper input:checkbox:checked")[0]).parent().find("label").html());
    objClaim.DxCode2 = ($(".div-icd-wrapper input:checkbox:checked")[1] == undefined) ? "" : $.trim($($(".div-icd-wrapper input:checkbox:checked")[1]).parent().find("label").html());
    objClaim.DxCode3 = ($(".div-icd-wrapper input:checkbox:checked")[2] == undefined) ? "" : $.trim($($(".div-icd-wrapper input:checkbox:checked")[2]).parent().find("label").html());
    objClaim.DxCode4 = ($(".div-icd-wrapper input:checkbox:checked")[3] == undefined) ? "" : $.trim($($(".div-icd-wrapper input:checkbox:checked")[3]).parent().find("label").html());
    objClaim.DxCode5 = ($(".div-icd-wrapper input:checkbox:checked")[4] == undefined) ? "" : $.trim($($(".div-icd-wrapper input:checkbox:checked")[4]).parent().find("label").html());
    objClaim.DxCode6 = ($(".div-icd-wrapper input:checkbox:checked")[5] == undefined) ? "" : $.trim($($(".div-icd-wrapper input:checkbox:checked")[5]).parent().find("label").html());
    objClaim.DxCode7 = ($(".div-icd-wrapper input:checkbox:checked")[6] == undefined) ? "" : $.trim($($(".div-icd-wrapper input:checkbox:checked")[6]).parent().find("label").html());
    objClaim.DxCode8 = ($(".div-icd-wrapper input:checkbox:checked")[7] == undefined) ? "" : $.trim($($(".div-icd-wrapper input:checkbox:checked")[7]).parent().find("label").html());

    objClaim.IsSuperBill = true;
    objClaim.SuperBillReferenceNo = $.trim($("[id$='lblSuperBillReferenceNo']").html());
    objClaim.SuperBillNotes = $.trim($("[id$='txtSuperBillNotes']").val());

    objClaim.AppointmentsId = _AppointmentsIdSupperBill;
    objClaim.ChartId = _ChartIdSupperBill;
    
    var listClaimCharges = new Array();
    
    $(".div-cpt-wrapper input:checkbox:checked").each(function () {
        var ParentElem = $(this).parent();
        
        var objClaimCharges = new Object();
        
        objClaimCharges.ClaimChargesId = $(ParentElem.find("input[type='hidden']")[0]).val();
        
        objClaimCharges.CPTCode = $.trim(ParentElem.find("label").html());
        objClaimCharges.ServiceDate = DOS;
        objClaimCharges.ServiceUnits = $.trim(ParentElem.find(".txtServiceUnits").val());
        objClaimCharges.Modifier1 = $.trim(ParentElem.find(".txtModifier").val());
        
        objClaimCharges.IsSuperBill = true;
        
        listClaimCharges.push(objClaimCharges);
    });
    
    var params = {
        objClaim: JSON.stringify(objClaim),
        listClaimCharges: JSON.stringify(listClaimCharges),
        action: "Save"
    };

    $.post(_ControlPath + "/SuperBill.aspx", params, function (data) {
        if (objClaim.ClaimId == 0) {
            showSuccessMessage("Record created successfully!");
        }
        else {
            showSuccessMessage("Record updated successfully!");
        }

        $("[id$='divContainerOutSideForm']").dialog("close");
    });
}

function ClickCPTCheckBox(elem) {
    $(".charges-info-container").hide();
    
    var ParentElem = $(elem).parent();
    
    if ($(elem).is(":checked")) {
        ParentElem.find(".charges-info-container").show();
    }
    else {
        ParentElem.find(".txtServiceUnits").val("1");
        ParentElem.find(".txtModifier").val("");
    }
}

function ClickOkChargesInfo(elem) {
    $(elem).closest(".charges-info-container").hide();
}

function PrintSuperBill() {
    var thePopup = window.open('', "_blank");
    var printHtml = $("#divSuperBillPrintWrapper").html();
    
    thePopup.document.writeln('<!DOCTYPE html>');
    thePopup.document.writeln('<html><head><title></title>');
    thePopup.document.writeln('<link rel="stylesheet" type="text/css" href="../StyleSheets/EHRdefaultCSS.css">');
    thePopup.document.writeln('<link rel="stylesheet" type="text/css" href="../../StyleSheets/EHRdefaultCSS.css">');
    
    thePopup.document.writeln('</head><body>');
    thePopup.document.writeln(printHtml);
    thePopup.document.writeln('</body></html>');
    
    if (/loaded|complete/.test(document.readyState)) {
        var PrintDelay = setTimeout(function () {
            thePopup.print();

            clearTimeout(PrintDelay);
        }, 3000);
    }
}