
var _AppointmentDateWalkout;
var _AppointmentIdWalkout;
var _ERAMasterId;

function Walkout_InitializeForm() {
    $(".date").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");

    $(".date-patient-payment").datepicker({
        changeMonth: true,
        changeYear: true,
        onSelect: function (date, obj) {
            FilterPatientPayments(0, true);
        }
    }).mask("99/99/9999");

    $("[id$='divAddPaymentWalkout'] input[name='txtPaymentDate']").val(CurrentSystemDate());

    HideCheckedInPatients();
    
    var patientImagePath = _PracticeDocumentsPath + "/" + $("[id$='hdnImageFileNamePatient']").val();
    
    $("[id$='imgPatientPhoto']").attr("src", patientImagePath);
    $("[id$='imgPhone']").attr("src", _PhoneIconPath);

    GeneratePatientPaymentsPagging(true);

    Walkout_CalculateGrandTotals();
}

function Walkout_LoadWalkoutForm(elem) {
    var ParentElem = $(elem).parent();
    _PatientId = ParentElem.find(".hdnPatientId").val();

    _AppointmentDateWalkout = ParentElem.find(".hdnAppointmentDate").val().trim();
    _AppointmentIdWalkout = ParentElem.find(".hdnAppointmentsId").val();
    
    var params = {
        PatientId: _PatientId,
        AppointmentsId: _AppointmentIdWalkout,
        CheckedInPatientsId: ParentElem.find(".hdnCheckedInPatientsId").val(),
        AppointmentDate: _AppointmentDateWalkout
    };

    $.post(_ControlPath + "/PatientWalkoutHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartPatientWalkout###") + 25;
        var end = data.indexOf("###EndPatientWalkout###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#divPatientWalkOut").html(returnHtml)
        .promise()
        .done(function () {
            $("#divPatientWalkOut").dialog({
                modal: true,
                title: 'Patient Walkout',
                width: 1100,
                height: WindowHeight() - 15,
                open: function () {
                    Walkout_InitializeForm();
                },
                beforeClose: function () {
                    return Walkout_CloseWalkoutForm();
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        });
    });
}

function Walkout_CloseWalkoutForm() {
    var msg = "Would you like to mark the appointment as 'Completed'?";
    
    if (confirm(msg)) {
        var CurrentURL = document.URL;
        
        if (document.URL.search("Home.aspx") > 0) {
            UpdateAppointmentAndCheckedInPatientListOnWalkout(_AppointmentIdWalkout);
        }
        else {
            var params = {
                AppointmentsId: _AppointmentIdWalkout,
                PracticeLocationsIdCheckedInPatientList: $("[id$='ddlPracticeLocationsCheckedInPatients']").val(),
                action: "UpdateStatusAfterWalkout"
            };
            
            $.post(_EMRPath + "/Appointments/CallBacks/AppointmentsActionHandler.aspx", params, function (dataCheckIn) {
                var startCheckIn = dataCheckIn.indexOf("###StartCheckedInPatients###") + 28;
                var endCheckIn = dataCheckIn.indexOf("###EndCheckedInPatients###");
                var returnHtmlCheckIn = $.trim(dataCheckIn.substring(startCheckIn, endCheckIn));

                SetDataCheckedInPatientList(returnHtmlCheckIn);

                showSuccessMessage(_msg_Updated);
            });
        }
    }
    
    return true;
}


/*Start Payment Section*/

function Walkout_ResetPaymentForm() {
    $("#divAddPaymentWalkout input:text").val("");
    $("[id$='divAddPaymentWalkout'] input[name='txtPaymentDate']").val(CurrentSystemDate());
}

function Walkout_SaveAndAllocate(isAllocate) {
    var $form = $("[id$='divAddPaymentWalkout']");
    
    var objERAMaster = new Object();
    
    objERAMaster.PatientId = _PatientId;
    objERAMaster.CheckIssueDate = $.trim($form.find("[name='txtPaymentDate']").val());
    objERAMaster.CheckNumber = $.trim($form.find("[name='txtReferenceNumber']").val());
    objERAMaster.PaymentAmount = $.trim($form.find("[name='txtPaidAmount']").val());
    objERAMaster.PaymentMethodCode = $form.find("[name='ddlPaymentMethod']").val();
    objERAMaster.PaymentType = "PAT";
    
    var params = {
        objERAMaster: JSON.stringify(objERAMaster),
        Rows: 10,
        PageNumber: 0,
        SortBy: "",
        action: "SaveAndAllocate"
    };

    $.extend(params, GetParamsPatientPaymentsFilter());
    
    $.post(_ControlPath + "/PatientWalkoutActionHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartIfCheckExists###") + 24;
        var end = data.indexOf("###EndIfCheckExists###");
        var IfCheckExists = $.trim(data.substring(start, end));
        
        if (IfCheckExists == "true") {
            showErrorMessage("The payment against the check number you entered is already saved. Please enter different check number.");
            return;
        }

        Walkout_DoneERAMasterSave(data, isAllocate);
    });
}

function Walkout_DoneERAMasterSave(data, isAllocate) {
    var start = data.indexOf("###StartERAMasterId###") + 22;
    var end = data.indexOf("###EndERAMasterId###");
    var returnHtml = $.trim(data.substring(start, end));

    _ERAMasterId = returnHtml;

    SetPatientPaymentsData(data, true);

    if (isAllocate) {
        var $form = $("[id$='divAddPaymentWalkout']");
        var PaymentAmountToAllocate = $.trim($form.find("input[name='txtPaidAmount']").val());
        
        Walkout_DistributeAmountToThisAllocate(PaymentAmountToAllocate);
    }
}

function Walkout_DistributeAmountToThisAllocate(PaymentAmountToAllocate) {
    PaymentAmountToAllocate = parseFloat(PaymentAmountToAllocate);
    
    var BalanceDue;

    $("[id$='tbodyPatientServicesWalkout'] tr").each(function () {
        if (PaymentAmountToAllocate != 0) {
            BalanceDue = $(this).find(".hdnBalanceDue").val();
            BalanceDue = parseFloat(BalanceDue);

            if (BalanceDue < PaymentAmountToAllocate) {
                $(this).find(".txtPaidAmountThisAllocation").val(BalanceDue.toFixed(2));

                PaymentAmountToAllocate = PaymentAmountToAllocate - BalanceDue;
            }
            else {
                $(this).find(".txtPaidAmountThisAllocation").val(PaymentAmountToAllocate.toFixed(2));
                PaymentAmountToAllocate = 0;
            }
        }
        else {
            $(this).find(".txtPaidAmountThisAllocation").val("0.00");
        }
    });
}

function Walkout_SavePaymentAllocation(isPrint) {
    if (isPrint) {
        if (!SetERAInformationOnPrintPage()) {
            return;
        }
        
        SetPatientServicesInformationOnPrintPage();
    }

    var $form = $("[id$='divAddPaymentWalkout']");
    
    var CheckDate = $.trim($form.find("input[name='txtPaymentDate']").val());
    var CheckNumber = $.trim($form.find("input[name='txtReferenceNumber']").val());
    var PaymentMethod = $form.find("input[name='ddlPaymentMethod']").val();
    var PaymentSource = "PAT";
    var ERAMasterId = $.trim($("[id$='hdnERAMasterId']").val());
    
    var listProcedurePayments = new Array();
    var listClaimCharges = new Array();
    
    $("[id$='tbodyPatientServicesWalkout'] tr").each(function () {
        /*Start Procedure Payments*/
        var objProcedurePayments = new Object();
        
        objProcedurePayments.ClaimId = $.trim($(this).find(".hdnClaimId").val());
        objProcedurePayments.ClaimNumber = $.trim($(this).find(".hdnClaimId").val());
        objProcedurePayments.ClaimChargesId = $.trim($(this).find(".hdnClaimChargesId").val());
        objProcedurePayments.ERAMasterId = _ERAMasterId;
        
        objProcedurePayments.CheckDate = CheckDate;
        objProcedurePayments.CheckNumber = CheckNumber;
        objProcedurePayments.PaidAmount = $.trim($(this).find(".txtPaidAmountThisAllocation").val());
        
        if (objProcedurePayments.PaidAmount == "") objProcedurePayments.PaidAmount = 0;
        
        objProcedurePayments.PaymentMethod = PaymentMethod;
        objProcedurePayments.PaymentSource = PaymentSource;
        objProcedurePayments.ChargedProcedure = $.trim($(this).find(".hdnCPTCode").val());
        objProcedurePayments.PaidProcedure = $.trim($(this).find(".hdnCPTCode").val());
        objProcedurePayments.AdjustedAmount = $.trim($(this).find(".txtWriteoff").val()); // Dont remove this line as this 'AdjustedAmount' is being mapped with 'AdjustedAmount' in ProcedureAdjustments object on server.
        
        if (objProcedurePayments.AdjustedAmount == "") objProcedurePayments.AdjustedAmount = 0;
        
        objProcedurePayments.PaidUnits = $.trim($(this).find(".hdnServiceUnits").val());
        
        listProcedurePayments.push(objProcedurePayments);
        /*End Procedure Payments*/

        /*Start Claim Charges*/
        listClaimCharges.push(Walkout_ClaimChargesObject($(this)));
        /*End Claim Charges*/
    });
    
    var params = {
        listProcedurePayments: JSON.stringify(listProcedurePayments),
        listClaimCharges: JSON.stringify(listClaimCharges),
        Rows: 10,
        PageNumber: 0,
        SortBy: "",
        action: "SavePaymentAllocation"
    };
    
    $.extend(params, GetParamsPatientPaymentsFilter());
    $.extend(params, GetParamsPatientServicesFilter());

    Walkout_CalculateGrandTotals();
    
    $.post(_ControlPath + "/PatientWalkoutActionHandler.aspx", params, function (data) {
        showSuccessMessage(_msg_Updated);
        
        SetPatientPaymentsData(data, true);
        Walkout_SetPatientServicesGrid(data);
        
        if (isPrint) {
            PrintPatientLongReceipt();
        }
    });
}

function Walkout_CalculateGrandTotals() {
    var TotalPaidThisVisit = 0, PaidThisVisit = 0;
    var TotalWriteOffThisVisit = 0, WriteOffThisVisit = 0;
    var TotalBalance = 0;


    $("[id$='tbodyPatientServicesWalkout'] tr").each(function () {
        PaidThisVisit = $.trim($(this).find(".txtPaidAmountThisAllocation").val());
        if (PaidThisVisit == "") PaidThisVisit = 0;

        TotalPaidThisVisit = parseFloat(TotalPaidThisVisit) + parseFloat(PaidThisVisit);


        WriteOffThisVisit = $.trim($(this).find(".txtWriteoff").val());
        if (WriteOffThisVisit == "") WriteOffThisVisit = 0;

        TotalWriteOffThisVisit = parseFloat(TotalWriteOffThisVisit) + parseFloat(WriteOffThisVisit);
    });
    
    $("[id$='lblTotalPaidThisVisit']").html(TotalPaidThisVisit);
    $("[id$='lblTotalWriteOffThisVisit']").html(WriteOffThisVisit);


    var BalanceDue = $.trim($("[id$='lblBalanceDueOnThisVisit']").html());
    var BalanceDuePrevious = $.trim($("[id$='lblPreviousBalanceDue']").html());
    var PaidOnThisVisit = $.trim($("[id$='lblTotalPaidThisVisit']").html());
    var WriteOffOnThisVisit = $.trim($("[id$='lblTotalWriteOffThisVisit']").html());

    if (BalanceDue == "") BalanceDue = 0;
    if (BalanceDuePrevious == "") BalanceDuePrevious = 0;
    if (PaidOnThisVisit == "") PaidOnThisVisit = 0;
    if (WriteOffOnThisVisit == "") WriteOffOnThisVisit = 0;

    TotalBalance = (parseFloat(BalanceDue) + parseFloat(BalanceDuePrevious)) - (parseFloat(PaidOnThisVisit) + parseFloat(WriteOffOnThisVisit));
    $("[id$='lblTotalBalance']").html(TotalBalance);
}

function GetParamsPatientServicesFilter() {
    var DOS = "";

    if ($("[id$='rdoVisit']").is(":checked")) {
        DOS = _AppointmentDateWalkout;
    }

    return {
        PatientId: _PatientId,
        DOS: DOS,
        IsAmountDueGreaterThanZero: $("[id$='cbAmmountDue']").is(":checked"),
        IsServicesBilledToPatient: $("[id$='rdoServicesBilledToPatient']").is(":checked")
    };
}

function Walkout_FilterPatientServicesGrid() {
    var params = {
        action: "FilterPatientServices"
    };

    $.extend(params, GetParamsPatientServicesFilter());
    
    $.post(_ControlPath + "/PatientWalkoutActionHandler.aspx", params, function (data) {
        Walkout_SetPatientServicesGrid(data);
    });
}

function Walkout_SetPatientServicesGrid(data) {
    var start = data.indexOf("###StartPatientServices###") + 26;
    var end = data.indexOf("###EndPatientServices###");
    var returnHtml = $.trim(data.substring(start, end));
    
    $("#tbodyPatientServicesWalkout").html(returnHtml);
}

function Walkout_ClaimChargesObject(CurrentRow) {
    var PaidAmountThisAllocation = $.trim(CurrentRow.find(".txtPaidAmountThisAllocation").val());
    if (PaidAmountThisAllocation == "") PaidAmountThisAllocation = 0;
    PaidAmountThisAllocation = parseFloat(PaidAmountThisAllocation);
    
    var PaidAmount = $.trim(CurrentRow.find(".spnPaidAmount").html());
    if (PaidAmount == "") PaidAmount = 0;
    PaidAmount = parseFloat(PaidAmount) + PaidAmountThisAllocation;
    
    var PatPaidAmount = $.trim(CurrentRow.find(".hdnPatPaidAmount").html());
    if (PatPaidAmount == "") PatPaidAmount = 0;
    PatPaidAmount = parseFloat(PatPaidAmount) + PaidAmountThisAllocation;
    
    
    var objClaimCharges = new Object();
    
    objClaimCharges.ClaimChargesId = $.trim(CurrentRow.find(".hdnClaimChargesId").val());
    
    objClaimCharges.BalanceDue = $.trim(CurrentRow.find(".spnBalanceDue").html());
    if (objClaimCharges.BalanceDue == "") objClaimCharges.BalanceDue = 0;
    
    objClaimCharges.WriteOffAmount = $.trim(CurrentRow.find(".txtWriteoff").val());
    if (objClaimCharges.WriteOffAmount == "") objClaimCharges.WriteOffAmount = 0;
    
    objClaimCharges.PaidAmount = PaidAmount.toFixed(2);
    if (objClaimCharges.PaidAmount == "") objClaimCharges.PaidAmount = 0;
    
    objClaimCharges.PatPaidAmount = PatPaidAmount.toFixed(2);
    if (objClaimCharges.PatPaidAmount == "") objClaimCharges.PatPaidAmount = 0;
    
    return objClaimCharges;
}

function Walkout_CalculateDueAmount(elem) {
    var CurrentRow = $(elem).closest("tr");
    var BalanceDue = CurrentRow.find(".hdnBalanceDue").val();

    var PaidAmount = $.trim(CurrentRow.find(".hdnPaidAmount").val());
    var AdjustedAmount = $.trim(CurrentRow.find(".hdnAdjustedAmount").val());

    var PaidAmountThisAllocation = $.trim(CurrentRow.find(".txtPaidAmountThisAllocation").val());
    
    var Writeoff = $.trim(CurrentRow.find(".txtWriteoff").val());

    if (BalanceDue == "") BalanceDue = 0;
    if (PaidAmount == "") PaidAmount = 0;
    if (AdjustedAmount == "") AdjustedAmount = 0;

    if (PaidAmountThisAllocation == "") PaidAmountThisAllocation = 0;
    if (Writeoff == "") Writeoff = 0;
    
    BalanceDue = parseFloat(BalanceDue);
    PaidAmount = parseFloat(PaidAmount);
    AdjustedAmount = parseFloat(AdjustedAmount);

    PaidAmountThisAllocation = parseFloat(PaidAmountThisAllocation);
    Writeoff = parseFloat(Writeoff);
    
    BalanceDue = BalanceDue - (PaidAmountThisAllocation + Writeoff);
    CurrentRow.find(".spnBalanceDue").html(BalanceDue.toFixed(2));
    
    PaidAmount = PaidAmount + PaidAmountThisAllocation;
    CurrentRow.find(".spnPaidAmount").html(PaidAmount.toFixed(2));
    
    AdjustedAmount = AdjustedAmount + Writeoff;
    CurrentRow.find(".spnAdjustedAmount").html(AdjustedAmount.toFixed(2));
}
/*End Payment Section*/

function Walkout_CheckEligibility() {
    CheckPatientEligibility("Walkout");
}

function Walkout_EditPatientInsurace(elem, InsuranceType) {
    _InsuranceTypeMaster = InsuranceType;
    _InsuranceFormCallFrom = "Walkout";

    var params = {
        PatientId: _PatientId,
        PatientInsuranceId: $(elem).parent().find(".hdnPatientInsuranceId").val(),
        action: "LoadPatientInsurance"
    };

    PatientInsurance_OpenForm(params);
}

function Walkout_SavePatientInsurace() {
    var objPatientInsurance = new Object();
    
    objPatientInsurance.PatientInsuranceId = $("[id$='hdnPatientInsuranceIdWalkoutEdit']").val();
    
    objPatientInsurance.PatientId = _PatientId;
    objPatientInsurance.InsuranceId = $("[id$='hdnInsuranceIdWalkoutEdit']").val();
    
    objPatientInsurance.PriSecOthType = _InsuranceTypeMaster;
    objPatientInsurance.PolicyNumber = $("[id$='txtPolicyNoWalkout']").val();
    objPatientInsurance.GroupNumber = $("[id$='txtGroupNoWalkout']").val();
    objPatientInsurance.GroupName = $("[id$='txtGroupNameWalkout']").val();
    
    objPatientInsurance.EffectiveDate = $("[id$='txtEffectiveDateWalkout']").val();
    objPatientInsurance.TerminationDate = $("[id$='txtTerminationDateWalkout']").val();

    objPatientInsurance.CoPay = $("[id$='txtCopayWalkout']").val();
    objPatientInsurance.CoPayType = $("[id$='ddlCoPayTypeWalkout']").val();
    objPatientInsurance.CoInsurance = $("[id$='txtCoInsuranceWalkout']").val();
    objPatientInsurance.CoInsuranceType = $("[id$='ddlCoInsuranceTypeWalkout']").val();
    objPatientInsurance.Deductable = $("[id$='txtDeductableWalkout']").val();
    objPatientInsurance.DeductableType = $("[id$='ddlDeductableTypeWalkout']").val();

    objPatientInsurance.Relationship = $("[id$='ddlRelationshipWalkout']").val();
    objPatientInsurance.SubscriberId = $("[id$='hdnSubscriberIdWalkoutEdit']").val();
    
    var params = {
        objPatientInsurance: JSON.stringify(objPatientInsurance),
        action: "Save"
    };

    $.post("../../ProviderPortal/Controls/PatientInsurance.aspx", params, function (data) {
        showSuccessMessage(_msg_Updated);

        if (_InsuranceFormCallFrom == "CheckInForm") {
            SetInsuranceOnCheckInForm(objPatientInsurance, data);
        }
        else {
            Walkout_SetInsuranceOnWalkoutForm(objPatientInsurance, data);
        }

        Walkout_ClosePatientInsuraceForm();
    });
}

function Walkout_SetInsuranceOnWalkoutForm(objPatientInsurance, data) {
    var start = data.indexOf("###StartPatientInsuranceId###") + 29;
    var end = data.indexOf("###EndPatientInsuranceId###");
    var PatientInsuranceId = $.trim(data.substring(start, end));
    
    var InsuranceName = $("[id$='txtPatientInsuranceWalkout']").val();
    
    if (_InsuranceTypeMaster == "P") {
        $("[id$='lblPatientPrimaryInsurance']").html(InsuranceName);
        $("[id$='lblPatientPrimaryInsurancePolicyNumber']").html(objPatientInsurance.PolicyNumber);
        
        $("[id$='hdnPatientInsuranceIdPrimary']").val(PatientInsuranceId);
    }
    else if (_InsuranceTypeMaster == "S") {
        $("[id$='lblPatientSecondaryInsurance']").html(InsuranceName);
        $("[id$='lblPatientSecondaryInsurancePolicyNumber']").html(objPatientInsurance.PolicyNumber);
        
        $("[id$='hdnPatientInsuranceIdSecondary']").val(PatientInsuranceId);
    }
}

function Walkout_ClosePatientInsuraceForm() {
    $("#divDialogPatientInsurance").dialog("close");
}

function Walkout_SubscriberChange(elem) {
    var Relationship = $("[id$='ddlRelationshipWalkout']").val();
    
    if (Relationship == 'Self') {
        $(elem).closest("table").find(".iconSearchSmall").hide();
        
        var LastName = $("[id$='hdnPatientLastNameWalkout']").val();
        var FirstName = $("[id$='hdnPatientFirstNameWalkout']").val();
        
        $("[id$='txtSubscriberLastNameWalkout']").val(LastName);
        $("[id$='txtSubscriberFirstNameWalkout']").val(FirstName);
        
        $("[id$='hdnSubscriberIdWalkoutEdit']").val(0);
    }
    else {
        $(elem).closest("table").find(".iconSearchSmall").show();
        
        $("[id$='txtSubscriberLastNameWalkout']").val("");
        $("[id$='txtSubscriberFirstNameWalkout']").val("");
    }
}

function Walkout_HideShowNewPaymentForm(ifShow) {
    if (ifShow) {
        _ERAMasterId = 0;
        
        $("#divPaymentDetailWalkout").hide();
        $("#divAddPaymentWalkout").show();
    }
    else {
        $("#divAddPaymentWalkout").hide();
        $("#divPaymentDetailWalkout").show();
    }
}

function Walkout_ClickAllocate(elem) {
    var CurrentRow = $(elem).closest("tr");

    _ERAMasterId = CurrentRow.find(".hdnERAMasterId").val();

    var PaymentMethodCode = $.trim(CurrentRow.find(".spnPaymentMethodCode").html());
    var CheckIssueDate = $.trim(CurrentRow.find(".spnCheckIssueDate").html());

    var CheckNumber = $.trim(CurrentRow.find(".spnCheckNumber").html());
    var PaymentAmount = $.trim(CurrentRow.find(".spnPaymentAmount").html());
    var Allocated = $.trim(CurrentRow.find(".hdnPaymentPosted").val());
    var LeftToAllocate = $.trim(CurrentRow.find(".spnLeftToAllocate").html());

    $("[id$='spnPaymentMethodWalkout']").html(PaymentMethodCode);
    $("[id$='spnPaymentDateWalkout']").html(CheckIssueDate);
    $("[id$='spnPaymentCheckReferenceNoWalkout']").html(CheckNumber);
    $("[id$='spnPaymentPaidAmountWalkout']").html(PaymentAmount);
    $("[id$='spnPaymentAllocatedWalkout']").html(Allocated);
    $("[id$='spnPaymentLeftToAllocateWalkout']").html(LeftToAllocate);

    Walkout_HideShowNewPaymentForm(false);

    Walkout_DistributeAmountToThisAllocate(LeftToAllocate);
}

function GetParamsPatientPaymentsFilter() {
    var PaymentDate = $.trim($("[id$='txtDateFilterERA']").val());

    if (PaymentDate == "__/__/____") PaymentDate = "";

    return {
        PatientId: _PatientId,
        PaymentDate: PaymentDate,
        PaymentMethodCode: $.trim($("[id$='txtPaymentMethodFilterERA']").val()),
        CheckNumber: $.trim($("[id$='txtReferenceNoFilterERA']").val()),
        PaymentAmount: $.trim($("[id$='txtTotalAmountFilterERA']").val()),
        IsLeftToAllocatedGreaterThanZero: $.trim($("[id$='chkUnsettledTransactions']").is(":checked"))
    };
}

function FilterPatientPayments(pageNumber, pagging) {
    var params = {
        Rows: 10,
        PageNumber: pageNumber,
        SortBy: "",
        action: "FilterPatientPayments"
    };
    
    $.extend(params, GetParamsPatientPaymentsFilter());
    
    $.post(_ControlPath + "/PatientWalkoutActionHandler.aspx", params, function (data) {
        SetPatientPaymentsData(data, pagging);
    });
}

function SetPatientPaymentsData(data, pagging) {
    var start = data.indexOf("###StartPatientPayments###") + 26;
    var end = data.indexOf("###EndPatientPayments###");
    var returnHtml = $.trim(data.substring(start, end));
    
    $("[id$='tbodyPatientPayments']").html(returnHtml);
    
    start = data.indexOf("###StartTotalRows###") + 20;
    end = data.indexOf("###EndTotalRows###");
    returnHtml = $.trim(data.substring(start, end));
    
    $("[id$='hdnPatientPaymentsCount']").val(returnHtml);

    GeneratePatientPaymentsPagging(pagging);
}

function GeneratePatientPaymentsPagging(pagging) {
    if (pagging) {
        GeneratePaging($("[id$='hdnPatientPaymentsCount']").val(), 10, "divPatientPaymentsGrid", "FilterPatientPayments");
    }

    if ($("[id$='hdnPatientPaymentsCount']").val() > 0) {
        $("#divPatientPaymentsGrid .spanInfo").html("Showing " + $("#tbodyPatientPayments tr:first").children().first().html() + " to " + $("#tbodyPatientPayments tr:last").children().first().html() + " of " + $("[id$='hdnPatientPaymentsCount']").val() + " entries");
    }
}

function printERA(elem) {
    if (!SetERAInformationOnPrintPage()) {
        return;
    }
    
    $("#divPrintPatientServicesWrapper").hide();
    PrintPatientShortReceipt("divPrintInner");
    
    /*
    $("#divDialogPrintShortReceipt").dialog({
        modal: true,
        title: 'Patient Payment Statement',
        width: "auto",
        height: "auto",
        close: function () {
            $(this).dialog("destroy");
        }
    });
    */
}

function PrintPatientLongReceipt() {
    $("#divPrintPatientServicesWrapper").show();
    
    PrintPatientShortReceipt("divPrintInner");
}

function CancelPatientShortReceipt() {
    $("#divDialogPrintShortReceipt").dialog("close");
}

function SetERAInformationOnPrintPage() {
    if ($("#tbodyPatientPayments .chkPatientPayments:checked").length == 0) {
        showErrorMessage("Please select some payment.");
        return false;
    }
    
    var SelectedPayment = $("#tbodyPatientPayments .chkPatientPayments:checked").closest("tr");
    
    var ReceiptNo = SelectedPayment.find(".hdnERAMasterId").val();
    var CheckIssueDate = $.trim(SelectedPayment.find(".spnCheckIssueDate").html());
    var PaymentAmount = SelectedPayment.find(".spnPaymentAmount").html();
    var PaymentMethodCode = SelectedPayment.find(".spnPaymentMethodCode").html();
    var CheckNumber = SelectedPayment.find(".spnCheckNumber").html();

    $("#spnReceiptNoPrint").html(ReceiptNo);
    $("#spnPaymentDatePrint").html(CheckIssueDate);
    $("#spnPaidAmountPrint").html(PaymentAmount);

    $("#spnPaymentMethodPrint").html(PaymentMethodCode);
    $("#spnCheckReferenceNoPrint").html(CheckNumber);

    return true;
}

function SetPatientServicesInformationOnPrintPage() {
    var RowsPatientServicesForPrint = "";

    var Charges = 0, TotalCharges = 0;
    var PaidAmount = 0, TotalPaidAmount = 0;
    var Adjustment = 0, TotalAdjustment = 0;
    var ThisAllocation = 0, TotalAllocation = 0;
    var BalanceDue = 0, TotalBalanceDue = 0;

    $("#tbodyPatientServicesWalkout tr").each(function () {
        Charges = $.trim($(this).find(".spnTotalCharges").html());
        if (Charges == "") Charges = 0;
        TotalCharges = parseFloat(TotalCharges) + parseFloat(Charges);

        PaidAmount = $.trim($(this).find(".spnPaidAmount").html());
        if (PaidAmount == "") PaidAmount = 0;
        TotalPaidAmount = parseFloat(TotalPaidAmount) + parseFloat(PaidAmount);

        Adjustment = $.trim($(this).find(".spnAdjustedAmount").html());
        if (Adjustment == "") Adjustment = 0;
        TotalAdjustment = parseFloat(TotalAdjustment) + parseFloat(Adjustment);

        ThisAllocation = $.trim($(this).find(".txtPaidAmountThisAllocation").val());
        if (ThisAllocation == "") ThisAllocation = 0;
        TotalAllocation = parseFloat(TotalAllocation) + parseFloat(ThisAllocation);

        BalanceDue = $.trim($(this).find(".spnBalanceDue").html());
        if (BalanceDue == "") BalanceDue = 0;
        TotalBalanceDue = parseFloat(TotalBalanceDue) + parseFloat(BalanceDue);

        RowsPatientServicesForPrint += '<tr>' +
                '<td>' +
                    $.trim($(this).find(".spnDOS").html()) +
                '</td>' +
                '<td>' +
                    $.trim($(this).find(".spnService").html()) +
                '</td>' +
                '<td>' +
                    Charges +
                '</td>' +
                '<td>' +
                    PaidAmount +
                '</td>' +
                '<td>' +
                    Adjustment +
                '</td>' +
                '<td>' +
                    ThisAllocation +
                '</td>' +
                '<td>' +
                    BalanceDue +
                '</td>' +
            '</tr>';
    });
    
    $("#tbodyPrintPatientServices").prepend(RowsPatientServicesForPrint);
    
    $("#spnPrintTotalCharges").html(TotalCharges.toFixed(2));
    $("#spnPrintTotalPaidAmount").html(TotalPaidAmount.toFixed(2));
    $("#spnPrintTotalAdjustment").html(TotalAdjustment.toFixed(2));
    $("#spnPrintTotalAllocation").html(TotalAllocation.toFixed(2));
    $("#spnPrintTotalBalanceDue").html(TotalBalanceDue.toFixed(2));
}

function PrintPatientShortReceipt(divId) {
    var thePopup = window.open('', "_blank");
    var printHtml = $("#" + divId).html();
    
    thePopup.document.writeln('<!DOCTYPE html>');
    thePopup.document.writeln('<html><head><title></title>');
    thePopup.document.writeln('<link rel="stylesheet" type="text/css" href="../StyleSheets/PrintTheme1.css">');
    thePopup.document.writeln('<link rel="stylesheet" type="text/css" href="../StyleSheets/EHRdefaultCSS.css">');
    thePopup.document.writeln('<link rel="stylesheet" type="text/css" href="../../StyleSheets/PrintTheme1.css">');
    thePopup.document.writeln('<link rel="stylesheet" type="text/css" href="../../StyleSheets/EHRdefaultCSS.css">');
    
    thePopup.document.writeln('</head><body>');
    thePopup.document.writeln('<div class="print-page-theme-1">');
    thePopup.document.writeln(printHtml);
    thePopup.document.writeln('</div>');
    thePopup.document.writeln('</body></html>');

    if (/loaded|complete/.test(document.readyState)) {
        var PrintDelay = setTimeout(function () {
            thePopup.print();

            clearTimeout(PrintDelay);
        }, 3000);
    }
    
}

function Walkout_ClickPaymentsCheckbox(elem) {
    var IsChecked = $(elem).is(":checked");
    
    $(elem).closest("tbody").find(".chkPatientPayments").prop("checked", false);
    
    $(elem).prop("checked", IsChecked);
}