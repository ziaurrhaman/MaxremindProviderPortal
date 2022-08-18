


var _AppointmentDate_PatientPayment;
var _AppointmentId_PatientPayment;
var _ERAMasterId_PatientPayment;

var _PatientPayment_Container = "divClaimPaymentMain";
var _CurrentAdjustmentTD_PatientPayment;
var _OkAdjustmentsDone = false;

$(function () {
    PatientPayment_InitializeForm();
});

$(document).on("click", "body", function () {
    $(".divDropDownReasonCodeSearch").hide();
});

function PatientPayment_InitializeForm() {
    $(".date").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");

    $(".date-era-filter").datepicker({
        changeMonth: true,
        changeYear: true,
        onSelect: function (date, obj) {
            PatientPayment_FilterERA(0, true);
        }
    }).mask("99/99/9999");
    
    $("input[name='txtPaymentDateNewPayment']").val(CurrentSystemDate());

    PatientPayment_ERA_GeneratePagging(true);
}


function PatientPayment_ClickAddNewPayment() {
    $("[id$='divPatientPaymentView']").hide();
    $("[id$='divPatientPaymentAddPayment']").show();
}

/*Start Payment Section*/

function PatientPayment_ResetERAForm() {
    _ERAMasterId_PatientPayment = 0;
    
    var $divAddPayment = $("[id$='" + _PatientPayment_Container + "'] div[name='divAddPayment']");
    
    $divAddPayment.find("input:text").val("");
    $divAddPayment.find("input[name='txtPaymentDateNewPayment']").val(CurrentSystemDate());
    $divAddPayment.find(".ddlPayerPatientPayment").val("");
    $divAddPayment.find("[name='ddlPaymentMethod']").val("");
}

function PatientPayment_SaveAndAllocate(isAllocate) {
    var $form = $("[id$='" + _PatientPayment_Container + "'] div[name='divAddPayment']");
    
    var PaymentType = "EOB";
    
    var objERAMaster = new Object();
    
    objERAMaster.PatientId = _PatientId;
    
    var PayerId = $form.find("[name='ddlPayerPatientPayment']").val();
    
    if (PayerId == 0) {
        PayerId = _PatientId;
        PaymentType = "PAT";
    }
    
    objERAMaster.PaymentMethodCode = $form.find("[name='ddlPaymentMethod']").val();
    objERAMaster.CheckIssueDate = $.trim($form.find("[name='txtPaymentDateNewPayment']").val());
    objERAMaster.CheckNumber = $.trim($form.find("[name='txtReferenceNumber']").val());
    objERAMaster.PaymentAmount = $.trim($form.find("[name='txtPaidAmount']").val());
    
    objERAMaster.PaymentType = PaymentType;
    //objERAMaster.PayerID837 = PayerId;
    
    var params = {
        objERAMaster: JSON.stringify(objERAMaster),
        PayerId: PayerId,
        PaymentType: PaymentType,
        Rows: 10,
        PageNumber: 0,
        SortBy: "",
        action: "SaveERA"
    };
    
    $.extend(params, PatientPayment_ERA_GetParams());
    
    $.post(_ControlPath + "/PatientPaymentActionHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartIfCheckExists###") + 24;
        var end = data.indexOf("###EndIfCheckExists###");
        var IfCheckExists = $.trim(data.substring(start, end));

        if (IfCheckExists == "true") {
            showErrorMessage("The payment against the check number you entered is already saved. Please enter different check number.");
            return;
        }

        PatientPayment_DoneERAMasterSave(data, isAllocate);
    });
}

function PatientPayment_DoneERAMasterSave(data, isAllocate) {
    var start = data.indexOf("###StartERAMasterId###") + 22;
    var end = data.indexOf("###EndERAMasterId###");
    var returnHtml = $.trim(data.substring(start, end));
    
    _ERAMasterId_PatientPayment = returnHtml;
    
    PatientPayment_ERA_SetData(data, true);
    
    if (isAllocate) {
        var $divAddPayment = $("[id$='" + _PatientPayment_Container + "'] div[name='divAddPayment']");
        
        var PaymentAmountToAllocate = $.trim($divAddPayment.find("input[name='txtPaidAmount']").val());
        
        PatientPayment_DistributeAmountToThisAllocate(PaymentAmountToAllocate);
    }
    
    PatientPayment_SetERAPaymentDetailForm();
    PatientPayment_HideShowNewPaymentForm();
}

function PatientPayment_SetERAPaymentDetailForm() {
    var $divAddPayment = $("[id$='" + _PatientPayment_Container + "'] div[name='divAddPayment']");

    var objERA = new Object();

    objERA.ReferenceNo = $.trim($divAddPayment.find("[name='txtReferenceNumber']").val());
    objERA.PayerName = $.trim($divAddPayment.find(".ddlPayerPatientPayment option:selected").html());
    objERA.PaymentMethod = $.trim($divAddPayment.find("select[name='ddlPaymentMethod']").val());
    objERA.PaymentDate = $.trim($divAddPayment.find("[name='txtPaymentDateNewPayment']").val());
    objERA.AllocatedAmount = "0.00";
    objERA.LeftToAllocate = $.trim($divAddPayment.find("[name='txtPaidAmount']").val());

    PatientPayment_SetDataOnERAViewForm(objERA);
}

function PatientPayment_SetDataOnERAViewForm(objERA) {
    var $divPaymentDetail = $("[id$='" + _PatientPayment_Container + "'] div[name='divPaymentDetail']");

    $divPaymentDetail.find("[name='spnReferenceNo']").html(objERA.ReferenceNo);
    $divPaymentDetail.find("[name='spnPayerPatientPayment']").html(objERA.PayerName);
    $divPaymentDetail.find("[name='spnPaymentMethod']").html(objERA.PaymentMethod);
    $divPaymentDetail.find("[name='spnPaymentDate']").html(objERA.PaymentDate);
    $divPaymentDetail.find("[name='spnPaymentAllocated']").html(objERA.AllocatedAmount);
    $divPaymentDetail.find("[name='spnPaymentLeftToAllocate']").html(objERA.LeftToAllocate);
}

function PatientPayment_DistributeAmountToThisAllocate(PaymentAmountToAllocate) {
    PaymentAmountToAllocate = parseFloat(PaymentAmountToAllocate);
    
    var BalanceDue;
    
    var $ServiceBody = $("[id$='" + _PatientPayment_Container + "'] [name='tbodyPatientServices']");

    $ServiceBody.find("tr").each(function () {
        if (PaymentAmountToAllocate != 0) {
            BalanceDue = $.trim($(this).find(".hdnBalanceDue").val());
            if (BalanceDue == "") BalanceDue = 0;
            BalanceDue = parseFloat(BalanceDue);

            if (BalanceDue < PaymentAmountToAllocate) {
                if (BalanceDue >= 0) {
                    $(this).find(".txtPaidAmountThisAllocation").val(BalanceDue.toFixed(2));
                }
                else {
                    $(this).find(".txtPaidAmountThisAllocation").val("0.00");
                }

                PaymentAmountToAllocate = PaymentAmountToAllocate - BalanceDue;

                if (PaymentAmountToAllocate < 0) {
                    PaymentAmountToAllocate = 0;
                }
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

function PatientPayment_SavePaymentAllocation(isPrint) {
    if (isPrint) {
        if (!SetERAInformationOnPrintPage()) {
            return;
        }
        
        SetPatientServicesInformationOnPrintPage();
    }
    
    var $form = $("[id$='" + _PatientPayment_Container + "'] [name='divAddPayment']");
    
    var CheckDate = $.trim($form.find("input[name='txtPaymentDateNewPayment']").val());
    var CheckNumber = $.trim($form.find("input[name='txtReferenceNumber']").val());
    var PaymentMethod = $form.find("input[name='ddlPaymentMethod']").val();
    
    var listProcedurePayments = new Array();
    
    var $ServiceBody = $("[id$='" + _PatientPayment_Container + "'] [name='tbodyPatientServices']");
    
    $ServiceBody.find("> tr").each(function () {
        /*Start Procedure Payments*/
        var objProcedurePayments = new Object();
        
        objProcedurePayments.ClaimId = $.trim($(this).find(".hdnClaimId").val());
        objProcedurePayments.ClaimNumber = $.trim($(this).find(".hdnClaimId").val());
        objProcedurePayments.ClaimChargesId = $.trim($(this).find(".hdnClaimChargesId").val());
        objProcedurePayments.ERAMasterId = _ERAMasterId_PatientPayment;
        
        objProcedurePayments.CheckDate = CheckDate;
        objProcedurePayments.CheckNumber = CheckNumber;
        
        objProcedurePayments.AllowedAmount = $.trim($(this).find(".txtAllowedAmount").val());
        objProcedurePayments.PaidAmount = $.trim($(this).find(".txtPaidAmountThisAllocation").val());

        if (objProcedurePayments.PaidAmount == "") objProcedurePayments.PaidAmount = 0;
        if (objProcedurePayments.AllowedAmount == "") objProcedurePayments.AllowedAmount = 0;
        
        objProcedurePayments.PaymentMethod = PaymentMethod;
        objProcedurePayments.PaymentSource = $.trim($(this).find(".ddlPaymentSourceServicesPayment").val());
        
        objProcedurePayments.ChargedProcedure = $.trim($(this).find(".hdnCPTCode").val());
        objProcedurePayments.PaidProcedure = $.trim($(this).find(".hdnCPTCode").val());
        
        //objProcedurePayments.AdjustedAmount = $.trim($(this).find(".txtWriteoff").val()); // Dont remove this line as this 'AdjustedAmount' is being mapped with 'AdjustedAmount' in ProcedureAdjustments object on server.
        //if (objProcedurePayments.AdjustedAmount == "") objProcedurePayments.AdjustedAmount = 0;
        
        objProcedurePayments.PaidUnits = $.trim($(this).find(".hdnServiceUnits").val());
        
        /*Start Procedure Adjustments*/
        var listProcedureAdjustments = new Array();
        
        $(this).find(".tbodyProcedureAdjustments > tr").each(function () {
            var objProcedureAdjustments = new Object();

            objProcedureAdjustments.ProcedureAdjustmentId = $(this).find(".hdnProcedureAdjustmentId").val();

            objProcedureAdjustments.GroupCode = $.trim($(this).find(".ddlReasonCodeGroup").val());
            objProcedureAdjustments.ReasonCode = $.trim($(this).find(".hdnAdjustmentCode").val());
            objProcedureAdjustments.AdjustedAmount = $.trim($(this).find(".txtAdjustmentAmount").val());

            listProcedureAdjustments.push(objProcedureAdjustments);
        });

        /*End Procedure Adjustments*/

        objProcedurePayments.listProcedureAdjustments = listProcedureAdjustments;
        listProcedurePayments.push(objProcedurePayments);

        /*End Procedure Payments*/
    });
    
    var params = {
        listProcedurePayments: JSON.stringify(listProcedurePayments),
        Rows: 10,
        PageNumber: 0,
        SortBy: "",
        action: "SavePaymentAllocation"
    };
    
    $.extend(params, PatientPayment_ERA_GetParams());
    
    $.post(_ControlPath + "/PatientPaymentActionHandler.aspx", params, function (data) {
        showSuccessMessage(_msg_Updated);
        
        PatientPayment_ERA_SetData(data, true);
        PatientPayment_SetPaymentHistoryGrid(data);
        
        PatientPayment_ResetServicesGrid();
        
        if (isPrint) {
            PrintPatientLongReceipt();
        }
    });
}

function PatientPayment_SetPaymentHistoryGrid(data) {
    var start = data.indexOf("###StartPaymentHistory###") + 25;
    var end = data.indexOf("###EndPaymentHistory###");
    var returnHtml = $.trim(data.substring(start, end));

    var $tbodyPaymentHistory = $("[id$='" + _PatientPayment_Container + "'] [name='tbodyPaymentHistory']");
    $tbodyPaymentHistory.html(returnHtml);
}

function PatientPayment_ResetServicesGrid() {
    var $ServiceBody = $("[id$='" + _PatientPayment_Container + "'] [name='tbodyPatientServices']");

    $ServiceBody.find(".txtAllowedAmount").val("");
    $ServiceBody.find(".txtPaidAmountThisAllocation").val("");
    $ServiceBody.find(".tbodyProcedureAdjustments").html("");
}

function PatientPayment_DonePayment() {
    var params = {
        ClaimId: _ClaimId,
        action: "DonePatientPayment"
    };

    $.post(_ControlPath + "/PatientPaymentActionHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartClaimSummaryView###") + 27;
        var end = data.indexOf("###EndClaimSummaryView###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#divClaimSummaryClaimForm").html(returnHtml);

        start = data.indexOf("###StartPaymentSummaryView###") + 29;
        end = data.indexOf("###EndPaymentSummaryView###");
        returnHtml = $.trim(data.substring(start, end));

        $("#tbodyPaymentSummaryClaimForm").html(returnHtml);

        start = data.indexOf("###StartPaymentDetailView###") + 28;
        end = data.indexOf("###EndPaymentDetailView###");
        returnHtml = $.trim(data.substring(start, end));

        $("#tbodyPaymentDetailClaimForm").html(returnHtml);

        $("[id$='divPatientPaymentAddPayment']").hide();
        $("[id$='divPatientPaymentView']").show();
    });
}

function PatientPayment_CalculateDueAmount(elem) {
    var CurrentRow = $(elem).closest("tr");
    var BalanceDue = CurrentRow.find(".hdnBalanceDue").val();

    var PaidAmount = $.trim(CurrentRow.find(".hdnPaidAmount").val());
    var AdjustedAmount = $.trim(CurrentRow.find(".hdnAdjustedAmount").val());

    var PaidAmountThisAllocation = $.trim(CurrentRow.find(".txtPaidAmountThisAllocation").val());
    
    var Writeoff = $.trim(CurrentRow.find(".spnAdjustedAmount").html());

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

function PatientPayment_HideShowNewPaymentForm(ifShow) {
    var $divAddPayment = $("[id$='" + _PatientPayment_Container + "'] [name='divAddPayment']");
    var $divPaymentDetail = $("[id$='" + _PatientPayment_Container + "'] [name='divPaymentDetail']");
    
    if (ifShow) {
        PatientPayment_ResetERAForm();
        
        $divPaymentDetail.hide();
        $divAddPayment.show();
    }
    else {
        $divAddPayment.hide();
        $divPaymentDetail.show();
    }
}

function PatientPayment_ClickAllocate(elem) {
    var CurrentRow = $(elem).closest("tr");

    _ERAMasterId_PatientPayment = CurrentRow.find(".hdnERAMasterId").val();

    var objERA = new Object();

    objERA.ReferenceNo = $.trim(CurrentRow.find(".spnCheckNumber").html());
    objERA.PayerName = $.trim(CurrentRow.find(".spnPayerName").html());
    objERA.PaymentMethod = $.trim(CurrentRow.find(".hdnPaymentMethodCode").val());
    objERA.PaymentDate = $.trim(CurrentRow.find(".spnCheckIssueDate").html());
    objERA.AllocatedAmount = $.trim(CurrentRow.find(".hdnPaymentPosted").val());
    objERA.LeftToAllocate = $.trim(CurrentRow.find(".spnLeftToAllocate").html());

    PatientPayment_SetDataOnERAViewForm(objERA);

    PatientPayment_HideShowNewPaymentForm(false);

    PatientPayment_DistributeAmountToThisAllocate(objERA.LeftToAllocate);
}

function PatientPayment_ERA_GetParams() {
    var $divEFTTopFilterClaimForm = $("[id$='" + _PatientPayment_Container + "'] [name='divEFTTopFilterClaimForm']");
    var $divGridERAList = $("[id$='" + _PatientPayment_Container + "'] [name='divGridERAList']");
    
    var PaymentDate = $.trim($divGridERAList.find("[name='txtDateFilterERA']").val());

    if (PaymentDate == "__/__/____") PaymentDate = "";

    var PatientId = 0;
    if ($divEFTTopFilterClaimForm.find("[name='chkPaymentPatient']").is(":checked")) {
        PatientId = _PatientId;
    }

    return {
        ClaimId: _ClaimId,
        PatientId: PatientId,
        
        PaymentDate: PaymentDate,
        CheckNumber: $.trim($divGridERAList.find("[name='txtReferenceNoFilterERA']").val()),
        PayerName: $.trim($divGridERAList.find("[name='txtPayerNameFilterERA']").val()),
        PaymentAmount: $.trim($divGridERAList.find("[name='txtTotalAmountFilterERA']").val()),
        PaymentPosted: $.trim($divGridERAList.find("[name='txtPaymentPostedFilterERA']").val()),
        
        IsPrimary: $divEFTTopFilterClaimForm.find("[name='chkPaymentPrimary']").is(":checked"),
        IsSecondary: $divEFTTopFilterClaimForm.find("[name='chkPaymentSecondary']").is(":checked"),
        IsOther: $divEFTTopFilterClaimForm.find("[name='chkPaymentOther']").is(":checked"),
        IsLeftToAllocatedGreaterThanZero: $divEFTTopFilterClaimForm.find("[name='chkUnsettledTransactions']").is(":checked")
    };
}

function PatientPayment_FilterERA(pageNumber, pagging) {
    var params = {
        Rows: 10,
        PageNumber: pageNumber,
        SortBy: "",
        action: "FilterERA"
    };

    $.extend(params, PatientPayment_ERA_GetParams());

    $.post(_ControlPath + "/PatientPaymentActionHandler.aspx", params, function (data) {
        PatientPayment_ERA_SetData(data, pagging);
    });
}

function PatientPayment_ERA_SetData(data, pagging) {
    var start = data.indexOf("###StartPatientPayments###") + 26;
    var end = data.indexOf("###EndPatientPayments###");
    var returnHtml = $.trim(data.substring(start, end));

    var $tbodyERAList = $("[id$='" + _PatientPayment_Container + "'] [name='tbodyERAList']");

    $tbodyERAList.html(returnHtml);
    
    start = data.indexOf("###StartTotalRows###") + 20;
    end = data.indexOf("###EndTotalRows###");
    returnHtml = $.trim(data.substring(start, end));
    
    $("[id$='hdnPatientPaymentsCount']").val(returnHtml);
    
    PatientPayment_ERA_GeneratePagging(pagging);
}

function PatientPayment_ERA_GeneratePagging(pagging) {
    if (pagging) {
        GeneratePaging($("[id$='hdnPatientPaymentsCount']").val(), 10, "divGridERAList", "PatientPayment_FilterERA");
    }
    
    var $tbodyERAList = $("[id$='" + _PatientPayment_Container + "'] [name='tbodyERAList']");

    if ($("[id$='hdnPatientPaymentsCount']").val() > 0) {
        $("#divGridERAList .spanInfo").html("Showing " + $tbodyERAList.find("tr:first").children().first().html() + " to " + $tbodyERAList.find("tr:last").children().first().html() + " of " + $("[id$='hdnPatientPaymentsCount']").val() + " entries");
    }
}

function PatientPayment_ClickAddEditAdjustment(elem, CallFrom) {
    _CurrentAdjustmentTD_PatientPayment = $(elem).closest("td");
    
    if (CallFrom == "PatientServices") {
        PatientPayment_OpenProcedureAdjustmentsDialog(elem);
    }
    else if (CallFrom == "PaymentHistory") {
        if ($.trim($(elem).closest("tr").find(".tbodyProcedureAdjustments").html()).length == 0) {
            var params = {
                ProcedurePaymentsId: $(elem).closest("tr").find(".hdnProcedurePaymentsId").val(),
                action: "LoadProcedureAdjustments"
            };
            
            $.post(_ControlPath + "/ProcedureAdjustmentsByProcedurePayment.aspx", params, function (data) {
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                var returnHtml = $.trim(data.substring(start, end));
                
                $(elem).closest("tr").find(".tbodyProcedureAdjustments")
                    .html(returnHtml)
                    .promise()
                    .done(function () {
                        PatientPayment_OpenProcedureAdjustmentsDialog(elem);
                    });
            });
        }
        else {
            PatientPayment_OpenProcedureAdjustmentsDialog(elem);
        }
    }
}

function PatientPayment_OpenProcedureAdjustmentsDialog(elem) {
    _OkAdjustmentsDone = false;

    $(elem).closest("tr").find(".divDialogProcedureAdjustments").dialog({
        title: "Add/Edit Adjustments",
        modal: true,
        width: "750",
        close: function () {
            if (!_OkAdjustmentsDone) {
                debugger;
                var $CurrentTbodyProcedureAdjustments = $(this).find(".tbodyProcedureAdjustments");
                
                PatientPayment_ResetProcedureAdjustments($CurrentTbodyProcedureAdjustments);
            }

            $(this).dialog("destroy");
        }
    });
}

function PatientPayment_Click_OkAddProcedureAdjustments(elem) {
    _OkAdjustmentsDone = true;

    var AdjustmentAmount = 0.0, AdjustmentAmountTotal = 0.0;
    
    $(elem).closest(".divDialogProcedureAdjustments").find(".tbodyProcedureAdjustments > tr").each(function () {
        AdjustmentAmount = $.trim($(this).find(".txtAdjustmentAmount").val());
        if (AdjustmentAmount == "") AdjustmentAmount = 0.0;
        
        AdjustmentAmountTotal = parseFloat(AdjustmentAmountTotal) + parseFloat(AdjustmentAmount);
    });

    _CurrentAdjustmentTD_PatientPayment.find(".spnAdjustedAmount").html(AdjustmentAmountTotal);
    $(elem).closest(".divDialogProcedureAdjustments").dialog("close");
}

function PatientPayment_Click_CancelAddProcedureAdjustments(elem) {
    $(elem).closest(".divDialogProcedureAdjustments").dialog("close");
}

function PatientPayment_ResetProcedureAdjustments($CurrentTbodyProcedureAdjustments) {
    var ProcedureAdjustmentId = 0;
    
    $CurrentTbodyProcedureAdjustments.find("> tr").each(function () {
        ProcedureAdjustmentId = $(this).find(".hdnProcedureAdjustmentId").val();
        
        if (ProcedureAdjustmentId == 0) {
            $(this).remove();
        }
    });
}

function PatientPayment_Click_CancelAddProcedureAdjustments123(elem) {
    $(elem).closest(".divDialogProcedureAdjustments").dialog("close");
    
    var ProcedureAdjustmentId = 0;
    var ReasonCodeGroup = "";
    var ReasonCode = "";
    var AdjustmentAmount = "";
    
    $(elem).closest(".divDialogProcedureAdjustments").find(".tbodyProcedureAdjustments > tr").each(function () {
        ProcedureAdjustmentId = $(this).find(".hdnProcedureAdjustmentId").val();
        
        if (ProcedureAdjustmentId == 0) {
            $(this).remove();
        }
        else {
            ReasonCodeGroup = $(this).find(".hdnReasonCodeGroup").val();
            ReasonCode = $(this).find(".hdnReasonCode").val();
            AdjustmentAmount = $(this).find(".hdnAdjustmentAmount").val();
            
            $(this).find(".ddlReasonCodeGroup").val(ReasonCodeGroup);
            $(this).find(".ddlReasonCode").val(ReasonCode);
            $(this).find(".txtAdjustmentAmount").val(AdjustmentAmount);
        }
    });
}

function PatientPayment_AddNewAdjustmentRow(elem) {
    var NewRow = $.trim($("#tbodySampleNewAdjustmentRowThisAllocation").html());
    
    $(elem).closest(".divDialogProcedureAdjustments").find(".tbodyProcedureAdjustments").append(NewRow);
    $(elem).closest(".divDialogProcedureAdjustments").find(".grid-table-wrapper").scrollTop(200000);
}

function PatientPayment_DeleteAdjustmentRow(elem) {
    var currentRow = $(elem).closest("tr");
    
    currentRow.remove();
}

function PatientPayment_FilterReasonCodes(elem) {
    var SearchKey = $.trim($(elem).val());

    var params = {
        SearchKey: SearchKey,
        action: "FilterAdjustmentCode"
    };

    $.post(_ControlPath + "/PatientPaymentActionHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartAdjustmentCodes###") + 26;
        var end = data.indexOf("###EndAdjustmentCodes###");
        var returnHtml = $.trim(data.substring(start, end));

        $(elem).closest("td").find(".tbodyReasonCodesFilter").html(returnHtml);

        if (returnHtml.length == 0) {
            $(elem).closest("td").find(".divDropDownReasonCodeSearch").hide();
        }
        else {
            $(elem).closest("td").find(".divDropDownReasonCodeSearch").show();
        }
    });
}

function PatientPayment_SelectReasonCode(elem, event) {
    event.stopPropagation();
    
    var $CurrentRow = $(elem);
    
    var ReasonCode = $.trim($CurrentRow.find(".spnReasonCodeSearch").html());
    var AdjustmentCode = $.trim($CurrentRow.find(".hdnAdjustmentCodeSearch").val());
    
    $(elem).closest(".divDropDownReasonCodeSearch").parent().find(".txtReasonCode").val(ReasonCode);
    $(elem).closest(".divDropDownReasonCodeSearch").parent().find(".txtReasonCode").attr("title", ReasonCode);
    
    $(elem).closest(".divDropDownReasonCodeSearch").parent().find(".hdnAdjustmentCode").val(AdjustmentCode);
    
    $(elem).closest("td").find(".divDropDownReasonCodeSearch").hide();
}


function PatientPayment_EditPaymentHistory(elem) {
    var CurrentRow = $(elem).closest("tr");

    var PaymentSource = $.trim(CurrentRow.find(".spnPaymentSource").html());
    var AllowedAmount = $.trim(CurrentRow.find(".spnAllowedAmount").html());
    var PaidAmount = $.trim(CurrentRow.find(".spnPaidAmount").html());
    var AdjustedAmount = $.trim(CurrentRow.find(".spnAdjustedAmountView").html());

    PaymentSource = CurrentRow.find(".ddlPaymentSource option").filter(function () { return this.text == PaymentSource }).val();
    
    CurrentRow.find(".ddlPaymentSource").val(PaymentSource);
    CurrentRow.find(".txtAllowedAmount").val(AllowedAmount);
    CurrentRow.find(".txtPaidAmount").val(PaidAmount);
    CurrentRow.find(".spnAdjustedAmount").html(AdjustedAmount);

    PatientPayment_HideShowHistoryEditIcons(true, CurrentRow);
}

function PatientPayment_HideShowHistoryEditIcons(IsEdit, CurrentRow) {
    if (IsEdit) {
        CurrentRow.find(".divEditDelete").hide();
        CurrentRow.find(".divSaveCancel").show();

        CurrentRow.find(".spnPaymentSource").hide();
        CurrentRow.find(".ddlPaymentSource").show();

        CurrentRow.find(".spnAllowedAmount").hide();
        CurrentRow.find(".txtAllowedAmount").show();
        
        CurrentRow.find(".spnPaidAmount").hide();
        CurrentRow.find(".txtPaidAmount").show();
        
        CurrentRow.find(".spnAdjustedAmountView").hide();
        CurrentRow.find(".blue-link-spnAdjustedAmount").show();
    }
    else {
        CurrentRow.find(".divSaveCancel").hide();
        CurrentRow.find(".divEditDelete").show();
        
        CurrentRow.find(".ddlPaymentSource").hide();
        CurrentRow.find(".spnPaymentSource").show();
        
        CurrentRow.find(".txtAllowedAmount").hide();
        CurrentRow.find(".spnAllowedAmount").show();
        
        CurrentRow.find(".txtPaidAmount").hide();
        CurrentRow.find(".spnPaidAmount").show();
        
        CurrentRow.find(".blue-link-spnAdjustedAmount").hide();
        CurrentRow.find(".spnAdjustedAmountView").show();
    }
}

function PatientPayment_EditCancelPaymentHistory(elem) {
    var CurrentRow = $(elem).closest("tr");
    PatientPayment_HideShowHistoryEditIcons(false, CurrentRow);
    
    var $CurrentTbodyProcedureAdjustments = $(elem).closest("tr").find(".tbodyProcedureAdjustments");
    PatientPayment_ResetProcedureAdjustments($CurrentTbodyProcedureAdjustments);
}

function PatientPayment_SavePaymentHistory(elem) {
    var CurrentProcedurePaymentRow = $(elem).closest("tr");
    
    var objProcedurePayments = new Object();
    
    objProcedurePayments.ProcedurePaymentsId = CurrentProcedurePaymentRow.find(".hdnProcedurePaymentsId").val();
    
    objProcedurePayments.PaymentSource = $.trim(CurrentProcedurePaymentRow.find(".ddlPaymentSource").val());
    objProcedurePayments.AllowedAmount = $.trim(CurrentProcedurePaymentRow.find(".txtAllowedAmount").val());
    objProcedurePayments.PaidAmount = $.trim(CurrentProcedurePaymentRow.find(".txtPaidAmount").val());
    
    if (objProcedurePayments.AllowedAmount == "") objProcedurePayments.AllowedAmount = 0;
    if (objProcedurePayments.PaidAmount == "") objProcedurePayments.PaidAmount = 0;

    objProcedurePayments.ERAMasterId = $.trim(CurrentProcedurePaymentRow.find(".hdnERAMasterId").val());
    objProcedurePayments.ClaimId = $.trim(CurrentProcedurePaymentRow.find(".hdnClaimId").val());
    objProcedurePayments.ChargedProcedure = $.trim(CurrentProcedurePaymentRow.find(".hdnChargedProcedure").val());
    
    /*Start Procedure Adjustments*/
    var listProcedureAdjustments = new Array();
    
    CurrentProcedurePaymentRow.find(".tbodyProcedureAdjustments > tr").each(function () {
        var objProcedureAdjustments = new Object();
        
        objProcedureAdjustments.ProcedureAdjustmentId = $(this).find(".hdnProcedureAdjustmentId").val();
        objProcedureAdjustments.ProcedurePaymentsId = objProcedurePayments.ProcedurePaymentsId;
        
        objProcedureAdjustments.GroupCode = $.trim($(this).find(".ddlReasonCodeGroup").val());
        objProcedureAdjustments.ReasonCode = $.trim($(this).find(".hdnAdjustmentCode").val());
        objProcedureAdjustments.AdjustedAmount = $.trim($(this).find(".txtAdjustmentAmount").val());

        if (objProcedureAdjustments.AdjustedAmount == "") objProcedureAdjustments.AdjustedAmount = 0;

        objProcedureAdjustments.Deleted = !($(this).is(":visible"));
        
        listProcedureAdjustments.push(objProcedureAdjustments);
    });
    /*End Procedure Adjustments*/
    
    var params = {
        ProcedurePaymentsId: CurrentProcedurePaymentRow.find(".hdnProcedurePaymentsId").val(),
        objProcedurePayments: JSON.stringify(objProcedurePayments),
        listProcedureAdjustments: JSON.stringify(listProcedureAdjustments),
        action: "UpdateProcedurePaymentHistory"
    };

    $.post(_ControlPath + "/ProcedureAdjustmentsByProcedurePayment.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        CurrentProcedurePaymentRow.find(".tbodyProcedureAdjustments")
        .html(returnHtml)
        .promise()
        .done(function () {
            PatientPayment_DoneUpdateProcedurePaymentHistory(CurrentProcedurePaymentRow);
        });
    });
}

function PatientPayment_DoneUpdateProcedurePaymentHistory(CurrentRow) {
    var PaymentSource = $.trim(CurrentRow.find(".ddlPaymentSource option:selected").html());
    var AllowedAmount = $.trim(CurrentRow.find(".txtAllowedAmount").val());
    var PaidAmount = $.trim(CurrentRow.find(".txtPaidAmount").val());
    var AdjustedAmount = $.trim(CurrentRow.find(".spnAdjustedAmount").html());

    CurrentRow.find(".spnPaymentSource").html(PaymentSource);
    CurrentRow.find(".spnAllowedAmount").html(AllowedAmount);
    CurrentRow.find(".spnPaidAmount").html(PaidAmount);
    CurrentRow.find(".spnAdjustedAmountView").html(AdjustedAmount);
    
    PatientPayment_HideShowHistoryEditIcons(false, CurrentRow);
}