
var PharmacySearchPageNo = "";

$(function () {

    if (UserControls.IsExist(79)) {
        RegisterControl("PlanofCare", "PlaneofCareSave()");
        GetPatientPrescription("All");
        GetPatientConsent();
        EnableDisableExternalDrugHistory();
        FillType();
        GetPatientInformation();
        $("#SpnpofHistory").click(function () { getChartHistory(GetQuerString("pat_acc"), GetQuerString("ChartID"), "GetPlanOfCareHistory", tblMedicationsHistory, "Medications History", "10010147316"); });
        $("#txtStartDate").datepicker({ changeMonth: true, changeYear: true, showOn: "button", maxDate: new Date() });
        $("#txtEndDate").datepicker({ changeMonth: true, changeYear: true, showOn: "button" });
        $("#txtDiscard").datepicker({ changeMonth: true, changeYear: true, showOn: "button", maxDate: new Date() });
        $("#txtRxExpire").datepicker({ changeMonth: true, changeYear: true, showOn: "button" });

    }

    else {
        $("#divMedication").hide();

        $("#divMedicationRights").show();
    }
    if (!UserControls.IsExist(94)) {
        $("#SpnpofHistory").unbind();
        
    }

});

function PlaneofCareSave() {
    alert('Saving Plane of Care');
}

function FillType() {
    var providerSPI = $("select[id$='ddlProvider_POC']").val().split("_")[0];
    if ($.trim(providerSPI) != "")
        $("select[id$='ddlType']").html("<option value='E-PRESCRIPTION'>E-PRESCRIPTION</option><option value='PRESCRIPTION'>PRESCRIPTION</option><option value='NON PRESCRIPTION'>NON PRESCRIPTION</option><option value='SAMPLE'>SAMPLE</option>");
    else
        $("select[id$='ddlType']").html("<option value='PRESCRIPTION'>PRESCRIPTION</option><option value='NON PRESCRIPTION'>NON PRESCRIPTION</option><option value='SAMPLE'>SAMPLE</option>");
}

function GetPatientInformation() {
    var request = "{'patientAccount':'" + GetQuerString("pat_acc") + "'}"
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetPatient",
        data: request,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: FillPatientInformation
    });
}

function FillPatientInformation(data) {
    var data = data.d;
    var index = 0;
    $("input[id$='hdnpatFname']").val(data.ListPatient[index].patFname);
    $("input[id$='hdnpatLname']").val(data.ListPatient[index].patLname);
    $("input[id$='hdnpatGender']").val(data.ListPatient[index].patGender);
    $("input[id$='hdnpatDOB']").val(data.ListPatient[index].patDOB);
    $("input[id$='hdnpatAddress']").val(data.ListPatient[index].patAddress);
    $("input[id$='hdnpatState']").val(data.ListPatient[index].patState);
    $("input[id$='hdnpatCity']").val(data.ListPatient[index].patCity);
    $("input[id$='hdnpatZip']").val(data.ListPatient[index].patZip);
    $("input[id$='hdnpatPhone']").val(formatPhone(data.ListPatient[index].patPhone));
    $("#lblPatName").text($("input[id$='hdnpatLname']").val() + ", " + $("input[id$='hdnpatFname']").val());
    $("#lblPatDob").text($("input[id$='hdnpatDOB']").val());
    $("#lblPatGender").text($("input[id$='hdnpatGender']").val());
    $("#lblPatAddress").text($("input[id$='hdnpatAddress']").val() + ", " + $("input[id$='hdnpatCity']").val() + ", " + $("input[id$='hdnpatState']").val() + " " + $("input[id$='hdnpatZip']").val());
}

//----------------------------------------------Get Patient's Prescriptions---------------------------------------------------

function GetPatientPrescription(value) {

    var patientAccount = GetQuerString("pat_acc");
    var criteria = " ";
    var param = "{'criteria':'" + criteria + "','patientAccount':'" + patientAccount + "','chartId':'" + GetQuerString("ChartID") + "'}";
    
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetPatientPrescription",
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: PopulateTable,
        error: function (ex) { alert(ex.Message.toString()); }
    });

}

function PopulateTable(data) {
    data = data.d;
    var tbl = "<table style='white-space:nowrap; width:auto;' cellpadding='0' cellspacing='0'>";
    tbl += "<tr valign='middle' align='center' class='review-subtitle gre-whitegrey'><th>Print/Fax</th><th>Rx Options</th><th>Medicine</th><th>Modified By</th><th>Rx Status</th><th>Type</th><th>Prescription Date</th><th>Modified Date</th><th>Created By</th><th>Sig</th><th>Active</th><th>Days Supply</th><th>Refills</th><th>Comments</th><th>Diagnose</th><th>Pharmacy</th><th>Pharmacy Instruction</th><th>Start Date</th><th>End Date</th><th>Date Dispensed</th><th>Date Discard</th><th>Date Expire</th><th>Provider</th><th>Is Confidential</th><th>Prescription Reviewed</th><th>Reviewed By</th><th>Reviewed Date</th></tr>";
    //tbl += '<tr style="white-space:nowrap;"><td valign="middle" align="center" class="review-hd-subtitle"><input type="checkbox" name="text2" class="radio-hid" id="Print" onclick="CheckAll(this.id);"></td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle"><input type="checkbox" id="Active" onclick="CheckAll(this.id)"; name="text2" class="radio-hid"></td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle"><input type="checkbox" name="text2" class="radio-hid"></td><td valign="middle" align="center" class="review-hd-subtitle"><input type="checkbox" name="text2" class="radio-hid"></td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td>';

    if (data.length > 0) {
        tbl += '<tr style="white-space:nowrap;"><td valign="middle" align="center" class="review-hd-subtitle"><input type="checkbox" name="text2" class="radio-hid" id="Print" onclick="CheckAll(this.id);"></td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle"></td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle"></td><td valign="middle" align="center" class="review-hd-subtitle"></td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td><td valign="middle" align="center" class="review-hd-subtitle">&nbsp;</td>';
        for (var i = 0; i < data.length; i++) {
            var checked = "";
            if (data[i].active == true)
                checked = "checked='checked'";

            var isConfidential = '';
            if (data[i].isConfidential == true)
                isConfidential = "checked='checked'";

            var prescriptionReviewed = '';
            if (data[i].prescriptionReviewed == true)
                prescriptionReviewed = "checked='checked'";

            var tmp = "\"" + data[i].providerInstruction + "\"";
            var AssignValues = 'showModalValues("FromTabprescription","' + data[i].prescriptionID + '","' + data[i].Medicine + '","' + data[i].pharmacyName + '","' + data[i].pharmacyCode + '","' + data[i].providerCode + '","' + data[i].prescriptionType + '","' + data[i].medicineCode + '","' + data[i].prescriptionDX + '","' + data[i].Diagnose + '","' + data[i].Sig + '","' + data[i].Dispense + '","' + data[i].Total + '","' + data[i].Refills + '","' + data[i].ndcCode + '",' + tmp + ',"' + data[i].isConfidential + '","' + data[i].overrideAdverse + '","' + data[i].overrideReason + '","' + data[i].prescriptionReviewed + '","' + data[i].onHold + '","' + data[i].unitCode + '","' + data[i].active + '","' + data[i].dateDiscard + '","' + data[i].dateExpire + '","' + data[i].startDate + '","' + data[i].endDate + '","' + data[i].drugtodrug + '","' + data[i].drugtodisease + '","' + data[i].drugtoallergy + '","' + data[i].drugtoFood + '","' + data[i].drugtoFood + '","' + data[i].Status + '","' + data[i].substitute + '")';
            var AssignValuesForRenew = 'showModalValues("FromMenu","' + data[i].prescriptionID + '","' + data[i].Medicine + '","' + data[i].pharmacyName + '","' + data[i].pharmacyCode + '","' + data[i].providerCode + '","' + data[i].prescriptionType + '","' + data[i].medicineCode + '","' + data[i].prescriptionDX + '","' + data[i].Diagnose + '","' + data[i].Sig + '","' + data[i].Dispense + '","' + data[i].Total + '","' + data[i].Refills + '","' + data[i].ndcCode + '",' + tmp + ',"' + data[i].isConfidential + '","' + data[i].overrideAdverse + '","' + data[i].overrideReason + '","' + data[i].prescriptionReviewed + '","' + data[i].onHold + '","' + data[i].unitCode + '","' + data[i].active + '","' + data[i].dateDiscard + '","' + data[i].dateExpire + '","' + data[i].startDate + '","' + data[i].endDate + '","' + data[i].drugtodrug + '","' + data[i].drugtodisease + '","' + data[i].drugtoallergy + '","' + data[i].drugtoFood + '","' + data[i].drugtoFood + '","' + data[i].Status + '","' + data[i].substitute + '")';
            if (i % 2 == 0)
                tbl += "<tr style='white-space:nowrap;' class='review-block-right-border " + ColorCode(data[i].Status) + "' id='row" + i + "' ><td class='review-block-right-border review-block-right-pad' align='center' id='Print" + i + "'><input type='checkbox'></td><td align='center' style='white-space:nowrap;' class='review-block-right-border'><img style='border-width: 0px; cursor:pointer;' src='../App_Themes/MTBCWithDashboard/images/EHR/icon/renew.png' onclick='" + AssignValuesForRenew + "' title='Renew Prescription'/>&nbsp;<img style='border-width: 0px; cursor:pointer;' src='../App_Themes/MTBCWithDashboard/images/EHR/icon/delete.png' title='Delete Prescription' onclick='DeletePrescription(" + data[i].prescriptionID + "); return false;' /></td><td style='cursor:pointer;' class='review-block-right-border review-block-right-pad' onclick='" + AssignValues + "'>" + data[i].Medicine + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].modifiedBy + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].Status + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].prescriptionType + "</td><td class='review-block-right-border review-block-right-pad'>" + convertDatetoString(data[i].prescriptionDate, "2") + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].modifiedDate + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].createdBy + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].Sig + "</td><td class='review-block-right-border review-block-right-pad' id='Active" + i + "'><input type='checkbox' onclick='ChkActive_CheckChanged(" + i + ")' " + checked + "></td><td class='review-block-right-border review-block-right-pad'>" + data[i].Dispense + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].Refills + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].StatusComments + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].Diagnose + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].pharmacyName + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].PInstruction + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].startDate + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].endDate + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].dateDispensed + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].dateDiscard + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].dateExpire + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].provider + "</td><td class='review-block-right-border review-block-right-pad' align='center'><input type='checkbox' disabled='disabled' " + isConfidential + "></td><td class='review-block-right-border review-block-right-pad' align='center'><input type='checkbox' disabled='disabled' " + prescriptionReviewed + "></td><td class='review-block-right-border review-block-right-pad'>" + data[i].reviewedBy + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].reviewedDate + "</td><td style='display:none;'> " + data[i].reviewedDate + "</td><td style='display:none;'> " + data[i].Total + "</td><td style='display:none;'> " + data[i].prescriptionID + "</td></tr>";
            else
                tbl += "<tr style='white-space:nowrap;' class='review-block-right-border-altr " + ColorCode(data[i].Status) + "' id='row" + i + "'><td class='review-block-right-border review-block-right-pad' align='center' id='Print" + i + "'><input type='checkbox'></td><td align='center' style='white-space:nowrap;' class='review-block-right-border'><img style='border-width: 0px; cursor:pointer;' src='../App_Themes/MTBCWithDashboard/images/EHR/icon/renew.png' onclick='" + AssignValuesForRenew + "' title='Renew Prescription'/>&nbsp;<img style='border-width: 0px; cursor:pointer;' src='../App_Themes/MTBCWithDashboard/images/EHR/icon/delete.png' title='Delete Prescription' onclick='DeletePrescription(" + data[i].prescriptionID + "); return false;' /></td><td style='cursor:pointer;' class='review-block-right-border review-block-right-pad' onclick='" + AssignValues + "'>" + data[i].Medicine + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].modifiedBy + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].Status + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].prescriptionType + "</td><td class='review-block-right-border review-block-right-pad'>" + convertDatetoString(data[i].prescriptionDate, "2") + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].modifiedDate + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].createdBy + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].Sig + "</td><td class='review-block-right-border review-block-right-pad' id='Active" + i + "'><input type='checkbox' onclick='ChkActive_CheckChanged(" + i + ")' " + checked + "></td><td class='review-block-right-border review-block-right-pad'>" + data[i].Dispense + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].Refills + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].StatusComments + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].Diagnose + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].pharmacyName + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].PInstruction + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].startDate + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].endDate + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].dateDispensed + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].dateDiscard + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].dateExpire + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].provider + "</td><td class='review-block-right-border review-block-right-pad' align='center'><input type='checkbox' disabled='disabled' " + isConfidential + "></td><td class='review-block-right-border review-block-right-pad' align='center'><input type='checkbox' disabled='disabled' " + prescriptionReviewed + "></td><td class='review-block-right-border review-block-right-pad'>" + data[i].reviewedBy + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].reviewedDate + "</td><td style='display:none;'> " + data[i].reviewedDate + "</td><td style='display:none;'> " + data[i].Total + "</td><td style='display:none;'> " + data[i].prescriptionID + "</td></tr>";
        }

    }
    else {
        $("#chkNoMedicine").attr("checked", true);
    }
    $("#tblPOC").html(tbl);
    

    //$("#tblPOC tr input[type='image']").contextMenu({ menu: 'myMenu2', leftButton: true }, function (action, el, pos) { OnContextMenuClick(action, el, pos); });
}

function ColorCode(prescriptionStatus) {
    switch (prescriptionStatus.toLowerCase()) {
        case "pending":
            return 'pending';
        case "success":
            return 'success';
        case "queued":
            return 'queued';
        case "Non E-Prescription":
            return 'Prescription';
    }
}

function CheckAll(checkBox) {
    var decision = $("#" + checkBox).attr("checked");
    if (decision == "checked")
        $("td[id^='" + checkBox + "'] :checkbox").attr("checked", "checked");
    else
        $("td[id^='" + checkBox + "'] :checkbox").removeAttr("checked");
    return false;
}

function RxStatus() {
    var activeStatus = '';
    if ($("#rdoAll").is(':checked'))
        activeStatus = 'All';
    if ($("#rdoCurrent").is(':checked'))
        activeStatus = 'Current';
    if ($("#rdoPast").is(':checked'))
        activeStatus = 'Past';
    var rxstatus = $("#ddlRxStatus").val();
    var rows = null;
    if (rxstatus == 'all')
        rows = $("#tblPOC tr:gt(1)");
    if (rxstatus == 'success')
        rows = $("#tblPOC .success");
    if (rxstatus == 'pending')
        rows = $("#tblPOC .pending");
    if (rxstatus == 'queued')
        rows = $("#tblPOC .queued");

    $("#tblPOC tr:gt(1)").hide();
    if (activeStatus.toLowerCase() == "current") {
        rows.each(function () {
            var RowID = $(this).attr('id').substr(3);
            if ($("#Active" + RowID + " input").is(':checked') == true) {
                $("#Active" + RowID + "").parent().show();
            }
            else {
                $("#Active" + RowID + "").parent().hide();
            }
        });
    }

    if (activeStatus.toLowerCase() == "past") {
        rows.each(function () {
            var RowID = $(this).attr('id').substr(3);
            if ($("#Active" + RowID + " input").is(':checked') == false) {
                $("#Active" + RowID + "").parent().show();
            }
            else {
                $("#Active" + RowID + "").parent().hide();
            }
        });
    }
    if (activeStatus.toLowerCase() == "all") {
        rows.each(function () {
            var RowID = $(this).attr('id').substr(3);
            $("#Active" + RowID + "").parent().show();
        });
    }

}

var value = "all";
function RowsVisibiltyStatus(value) {
    value = value;
    if (value.toLowerCase() == "current") {
        $("#tblPOC tr:gt(1)").each(function () {
            var RowID = $(this).attr('id').substr(3);
            if ($("#Active" + RowID + " input").is(':checked') == true) {

                $("#Active" + RowID + "").parent().show();
            }
            else {
                $("#Active" + RowID + "").parent().hide();
            }
        });
    }

    if (value.toLowerCase() == "past") {
        $("#tblPOC tr:gt(1)").each(function () {
            var RowID = $(this).attr('id').substr(3);
            if ($("#Active" + RowID + " input").is(':checked') == false) {
                $("#Active" + RowID + "").parent().show();
            }
            else {
                $("#Active" + RowID + "").parent().hide();
            }
        });
    }
    if (value.toLowerCase() == "all") {
        $("#tblPOC tr:gt(1)").each(function () {
            var RowID = $(this).attr('id').substr(3);
            $("#Active" + RowID + "").parent().show();
        });
    }

}
function DrugHistoryRowsVisibiltyStatus(value) {
    if (value.toLowerCase() == "current") {
        $("#drughistoryPrescription tr:gt(1)").each(function () {
            var RowID = $(this).attr('id').substr(3);
            if ($(this).find('input').is(':checked') == true) {

                $(this).show();
            }
            else {
                $(this).hide();
            }
        });
    }

    if (value.toLowerCase() == "past") {
        $("#drughistoryPrescription tr:gt(1)").each(function () {
            var RowID = $(this).attr('id').substr(3);
            if ($(this).find('input').is(':checked') == false) {
                $(this).show();
            }
            else {
                $(this).hide();
            }
        });
    }
    if (value.toLowerCase() == "all") {
        $("#drughistoryPrescription tr:gt(1)").each(function () {
            var RowID = $(this).attr('id').substr(3);
            $(this).show();
        });
    }

}

function OpenPrescription(rowId) {
    $("#txtMedicine").val($('#' + rowId + ' :nth-child(2)').html());
    $("select[id$='ddlType']").val($('#' + rowId + ' :nth-child(5)').html());
    $("#hovertxtSig").val($('#' + rowId + ' :nth-child(9)').html());
    $("#hovertxtRefills").val($('#' + rowId + ' :nth-child(12)').html());
    $("#txtPharmacy").val($('#' + rowId + ' :nth-child(15)').html());
    HideShowDiv("", "divNewRx");
}

function showModalValues(valuesAssignedFrom, prescriptionID, Medicine, pharmacyName, pharmacyCode, provCode, prescriptionType, medicineCode, prescriptionDX, Diagnose, Sig, Dispense, Total, Refills
, ndcCode, providerInstruction, isConfidential, overrideAdverse, overrideReason, prescriptionReviewed, onHold, unitCode, active, dateDiscard, dateExpire
, startDate, endDate, drugtodrug, drugtodisease, drugtoallergy, drugtoFood, prescriptionStatus, substitute) {
    //alert(prescriptionID)
    
    //$("input[id$='btnALT']").css("display", "none");
    //$("select[id$='ddlProviders'] option[value='" + provCode + "']").attr("selected", "selected");
    //$("input[type='hidden'][id$='hdnProviderCode']").val(provCode);
    
    if (valuesAssignedFrom == "FromMenu") {
        $("#lblRenewRx").val("Renew");
        $("#lblExistingRx").val("");
        $("#lblNewRx").val("");
    }
    else {
        $("#lblExistingRx").val("ExistingRx");
        $("#lblRenewRx").val("");
        $("#lblNewRx").val("");
    }
    $("#lblPrescriptionID").val(prescriptionID);
    $("#txtMedicine").val(Medicine);
    if ($("#txtMedicine").val() != "") {
        $("#txtMedicine").mouseover(function () {
            $(this).attr("title", $("#txtMedicine").val())
        }).mouseout(function () {
        });
    }
    $("#txtPharmacy").val(pharmacyName);
    if (pharmacyName != "") {
        $("#txtPharmacy").mouseover(function () {
            $(this).attr("title", pharmacyName)
        }).mouseout(function () {
        });
    }
    //$("input[id$='phar_idtxt']").val(pharmacyCode);
    
    $("select[id$='ddlType']").val(prescriptionType);

    //$("input[type='hidden'][id$='hdnSendNewRx']").val("");
    //$("input[id$='txtMedicineCode']").val(medicineCode);
    
    $("#txtDiagnosisCode").val(prescriptionDX);
    $("#txtDiagnosisDescription").val(Diagnose);
    if (Diagnose != "") {
        $("#txtDiagnosisDescription").mouseover(function () {
            $(this).attr("title", Diagnose)
        }).mouseout(function () {
        });
    }
    $("#hovertxtSig").val(Sig);

    if (Dispense != "" && Dispense != "undefined")
        $("#hovertxtDaysSupply").val(Dispense);

    if (Refills != "" && Refills != "undefined")
        $("#hovertxtRefills").val(Dispense);

    $("#txtQuantity").val(Total);

    //$("input[id$='txtMedicineNDC']").val(ndcCode);
    $("#txtProviderComments").val(providerInstruction);
    

    if (isConfidential != "")
        $("#chkConfedential").is(':checked', isConfidential == "false" ? false : true);
    if (overrideAdverse != "")
        $("#chkOverriderAdverse").is(':checked', isConfidential == "false" ? false : true);
    $("#txtOverrideReason").val(overrideReason);
    if (prescriptionReviewed != "")
        $("#chkPrescriptionReviewed").is(':checked', isConfidential == "false" ? false : true);
    
    if (onHold != "")
        $("input[type='checkbox'][id$='chkHold']").attr('checked', onHold == "false" ? false : true);

    $("select[id$='ddlMeasurement']").val(unitCode.toUpperCase());
    
    if (active != "")
        $("#chkPrescriptionActive").is(':checked', isConfidential == "false" ? false : true);

//    $("input[id$='txtDiscard']").val(dateDiscard);
//    $("input[id$='txtExpire']").val(dateExpire);
//    $("input[id$='txtStartDate']").val(startDate);
//    $("input[id$='txtEndDate']").val(endDate);
//    $("textarea[id$='txtDrugToDrug']").val(drugtodrug);
//    $("textarea[id$='txtDrugToDisease']").val(drugtodisease);
//    $("textarea[id$='txtDrugToAllergy']").val(drugtoallergy);
//    $("textarea[id$='txtDrugToFood']").val(drugtoFood).css("color", "Green");
//    $("select[id$='cboStatus'] option[value='" + prescriptionStatus + "']").attr('selected', 'selected');
//    if (substitute != "")
//        $("input[type='checkbox'][id$='chkSubstitution']").attr('checked', substitute == "false" ? false : true);
//    $("input[type='hidden'][id$='hdnSendNewRx']").val("");

//    $("span[id$='LblMedicineFormularyStatus']").text("");
//    $("div[id$='lblCopayAndCovSrv']").html("");
//    if (valuesAssignedFrom == "FromMenu") {
//        $("input[type='hidden'][id$='hdnRenewRX']").val("Renew");
//        $("input[type='hidden'][id$='hdnExistingRx']").val("");

//    }
//    else {
//        AssignSig();
//        $("input[type='hidden'][id$='hdnExistingRx']").val("ExistingRx");
//        $("input[type='hidden'][id$='hdnRenewRX']").val("");
//        $("input[id$='cptcodetxt']").val("");
//        $("input[id$='txtAddedMedicine']").val("");
//        $("input[id$='cptdesctxt']").val("");
//        hidePopDownDivs();
//        ShowHideDivs('SingleDiv', 'divNewRx', '');
//    }
//    tooltips();
//    showBtn('cboType');
//    DisableBtnEDH();
//    var defaultText = "Type Criteria and Press Enter";
//    $("input[id$='txtAddedMedicine']").val(defaultText);
//    $("input[id$='txtAddedMedicine']").addClass("waterMark");

    HideShowDiv("", "divNewRx");
    $("[id^='hover']").each(function () {
        $(this).width($(this).siblings().width() - 17);
    });
}

//----------------------------------------------Get Patient's Consent---------------------------------------------------
function GetPatientConsent() {
    var patientAccount = GetQuerString("pat_acc");
    var param = "{'patientAccount':'" + patientAccount + "'}";

    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetPatientConsent",
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: CheckExternalDrugHistory,
        error: function (ex) { alert(ex.Message.toString()); }
    });
}

function PatientConsentCheckChange() {
    var chkConsent = $("#chkPatientConsent").is(":checked");
    var patientAccount = GetQuerString("pat_acc");
    var chartID = "101078610144587";

    var request = "{'patientAccount':'" + patientAccount + "','chkConsent':'" + chkConsent + "','chartID':'" + chartID + "'}";
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/CheckPatientConsent",
        data: request,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: EnableDisableExternalDrugHistory
    });
}



function CheckExternalDrugHistory(data) {
    data = data.d;
    if (data) {
        $("#chkPatientConsent").attr("checked", "checked");
        $("#btnExternalDrugHistory").attr("disabled", false);
        $("#btnExternalDrugHistory").bind("click", LoadExternalDrugHistoryControl);
    }
}

//----------------------------------------------Dose Calculator---------------------------------------------------

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

function ConvertWeighttoKg() {
    if (parseFloat($("#txtWeight").val())) {
        var result = (parseFloat($("#txtWeight").val() / 2.2)).toFixed(2);
        $("#txtWeightKg").val(result);
    }
    else {
        $("#txtWeightKg']").val("");
    }
}
function ConvertWeighttoLb() {
    if (parseFloat($("#txtWeightKg").val())) {
        var result = (parseFloat($("#txtWeightKg").val() * 2.2)).toFixed(1);
        $("#txtWeight").val(result);
    }
    else {
        $("#txtWeight").val("");
    }
}




//----------------------------------------------Search Diagnosis---------------------------------------------------

function SearchDiagnosisEnter(e) {
    if (e.keyCode == 13) {
        SearchDiagnosis();
        return false;
    }
    return false;
}

function SearchDiagnosis() {
    var code = $("#txtSearchCode").val();
    var description = $("#txtSearchDescription").val();
    if (code == '' && description == '') {
        alert('Enter Value to Search');
        $("#divDiagnosisSearch").hide();
        return false;
    }
    var criteria = "";
    if ($("#diagnosisMyList input").is(':checked') == true)
        criteria = 'a';
    else if ($("#diagnosisAll input").is(':checked') == true)
        criteria = 'm';

    var param = "{'diagnosisCode':'" + code + "','diagnosisDescription':'" + description + "','criteria':'" + criteria + "'}";

    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/SearchDiagnosis",
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: PopulateDiagnosis,
        error: function (ex) { alert(ex.Message.toString()); }
    });
}

function PopulateDiagnosis(data) {
    $("#divDiagnosisSearch").html('');
    data = data.d;
    var tbl = "<table style='white-space:nowrap; width:100%; font-size:11px;' cellpadding='0' cellspacing='0'>";
    tbl += "<tr valign='middle' class='review-subtitle gre-whitegrey' ><th style='background: -moz-linear-gradient(center top , #FFFFFF, #EAEAEA) repeat scroll 0 0 transparent;' width='5%'></th><th width='20%' class='review-block-right-border'> Code </th><th width='75%' class='review-block-right-border'> Description </th></tr>";
    if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
            var obsoleteOpt = data[i].DIAG_DESCRIPTION.indexOf("(RED)");
            var obsoleteOpt2 = data[i].DIAG_DESCRIPTION.indexOf("(Red)");
            if ((obsoleteOpt >= 0) || (obsoleteOpt2 >= 0))  //RECORD FOUND
                tbl += "<tr style='white-space:nowrap;cursor:pointer; color:red;' onmouseover='ChangeColor(this);' onmouseout='RemoveColor(this);' onclick='FillDiagnosis(this.id);' class='review-block-right-border' id='diagnosisrow" + i + "'><td class='review-block-right-border' style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA;' ></td><td class='review-block-right-border review-block-right-pad' style='border-bottom: 1px solid #CDCDCD;' align='left'>" + data[i].DIAG_CODE + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;'>" + data[i].DIAG_DESCRIPTION + "</td></tr>";
            else
                tbl += "<tr style='white-space:nowrap;cursor:pointer;' onmouseover='ChangeColor(this);' onmouseout='RemoveColor(this);' onclick='FillDiagnosis(this.id);' class='review-block-right-border' id='diagnosisrow" + i + "'><td class='review-block-right-border' style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA;' ></td><td class='review-block-right-border review-block-right-pad' style='border-bottom: 1px solid #CDCDCD;' align='left'>" + data[i].DIAG_CODE + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;'>" + data[i].DIAG_DESCRIPTION + "</td></tr>";
        }
    }
    else {
        tbl += "<tr class='review-block-right-border' id='diagnosisrow" + i + "'><td class='review-block-right-border' style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA; color:red;' align='center' colspan='3' >No Record Found</td></tr>";
    }
    tbl += "</table>";
    $("#divDiagnosisSearch").html(tbl);
    $("#divDiagnosisSearch").show();
}

function ChangeColor(row) {
    var id = row.id;
    $('#' + id + ' :first').css({ 'background': 'url("/App_Themes/MTBCWithDashboard/images/EHR/icon/grid_arrow.png") no-repeat #EAEAEA -4px 5px', 'margin-top': '5px' });
    $(row).css('background-color', '#DAE6FF');
}
function RemoveColor(row) {
    var id = row.id;
    $('#' + id + ' :first').css('background-image', '');
    $(row).css('background-color', '#FFFFFF');
}

function FillDiagnosis(row) {
    if ($('#' + row + ' :nth-child(3)').css('color').toLowerCase() != 'rgb(255, 0, 0)') {
        $("#txtDiagnosisCode").val($('#' + row + ' :nth-child(2)').html());
        $("#txtDiagnosisDescription").val($('#' + row + ' :nth-child(3)').html());
        $("#divDiagnosisSearch").html('');
        $("#divDiagnosisSearch").hide();
        $("#txtSearchCode").val('');
        $("#txtSearchDescription").val('');
    }
    else
        alert('Diagnosis is obsolete');
}


//----------------------------------------------Search Medicine---------------------------------------------------

function SearchMedicineEnter(e) {
    
    if (e.keyCode == 13) {
        SearchMedicine();
        return false;
    }
    return false;
}

function SearchMedicine() {
    
    var medicineName = $("#txtSearchMedicine").val();
    if (medicineName == '') {
        $("#divSearchMedicine").hide();
        alert('Enter Vlaue to Search')
        return false;
    }

    var criteria = $("#medicineMyList").is(':checked');

    if (criteria == true) {
        var providerCode = $("select[id$='ddlProvider_POC']").val().split("_")[1];
        var param = "{'medicineName':'" + medicineName + "','providerCode':'" + providerCode + "'}";

        $.ajax({
            type: "POST",
            url: "Prescription/PlanofCareMethod.aspx/SearchMedicine",
            data: param,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: PopulateMedicine,
            error: function (ex) { alert(ex.Message.toString()); }
        });
    }
    else {
        if (($("[id$='hdnFormularyListID']").val() == "") || $("[id$='ddlType']").val().toUpperCase() != 'E-PRESCRIPTION' && $("[id$='hdnFormularyListID']").val() != "") {
            var MissingNCPDPID = false;
            if ($("select[id$='ddlType']").val().toLowerCase().trim() == "e-prescription")
                MissingNCPDPID = true;

            var param = "{'medName':'" + medicineName + "','MissingNCPDPID':'" + MissingNCPDPID + "'}";

            $.ajax({
                type: "POST",
                url: "Prescription/PlanofCareMethod.aspx/GetAllMedicines",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: PopulateAllMedicine,
                error: function (ex) { alert(ex.Message.toString()); }
            });
        }
        else if (medicineName != "" && $("select[id$='ddlType']").text().toUpperCase() == 'E-PRESCRIPTION' && $("[id$='hdnFormularyListID']").val() != "") {
            var payerid = $("[id$='hdnPayerId']").val();
            var formularyID = $("[id$='hdnFormularyListID']").val();
            var coverageid = $("[id$='hdnCoverageId']").val();
            var spi = $("[id$='lblProviderSPI']").val();
            var providerCode = $("select[id$='ddlProvider_POC']").val();

            var dataformularyParams = "{'medName':'" + medicineName + "','Payerid':'" + payerid + "','sFormulary_ID':'" + formularyID + "','sCoverage_ID':'" + coverageid + "','providerCode':'" + providerCode + "','spi':'" + spi + "'}";
            $.ajax({
                type: "POST",
                url: "RxPatient_Prescription.aspx/GetFormulary",
                data: dataformularyParams,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: retrieveFormulary,
                error: OnretrieveFormularyError
            });

        }
    }
}
function PopulateAllMedicine(data) {
    $("#btnAddMedicine").attr("disabled","disabled");
    //$("#divSearchMedicine").html('');
    data = data.d.ListMedicine;
    var tbl = "<table style='white-space:nowrap; width:100%; font-size:11px;' cellpadding='0' cellspacing='0'>";
    tbl += "<tr valign='middle' class='review-subtitle gre-whitegrey' ><th style='background: -moz-linear-gradient(center top , #FFFFFF, #EAEAEA) repeat scroll 0 0 transparent;' width='5%'></th><th width='30%' class='review-block-right-border'> Medicine </th><th width='45%' class='review-block-right-border'> Generic Description </th><th width='10%' class='review-block-right-border'> Generic </th><th width='10%' class='review-block-right-border'> OTC </th><th style='display:none;'></th><th style='display:none;'></th></tr>";
    if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].medNDC_Code == "" && $("[id$='ddlType']").val().toLowerCase().trim() == "e-prescription") {

            }
            else if (data[i].medNDC_Code == "" && $("[id$='ddlType']").val().toLowerCase().trim() != "e-prescription") {
                tbl += "<tr style='white-space:nowrap;cursor:pointer;' onmouseover='ChangeColor(this);' onmouseout='RemoveColor(this);' class='review-block-right-border' id='medicinerow" + i + "'><td class='review-block-right-border'   style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA;' ></td><td onclick='FillAllMedicine($(this).parent()); return false;' class='review-block-right-border review-block-right-pad' style='border-bottom: 1px solid #CDCDCD; color:red;' align='left'>" + data[i].medName + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;' onclick='GetGenericDescriptionMedicine(this); return false;'>" + data[i].medDescription + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;' >" + data[i].medGeneric + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;'>" + data[i].medOTC + "</td><td style='display:none;'>" + data[i].medNDC_Code + "</td><td style='display:none;'>" + data[i].medCode + "</td></tr>";
            }
            else {
                tbl += "<tr style='white-space:nowrap;cursor:pointer;' onmouseover='ChangeColor(this);' onmouseout='RemoveColor(this);'  class='review-block-right-border' id='medicinerow" + i + "'><td  class='review-block-right-border' style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA;' ></td><td onclick='FillAllMedicine($(this).parent());  return false;' class='review-block-right-border review-block-right-pad' style='border-bottom: 1px solid #CDCDCD;' align='left'>" + data[i].medName + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;' onclick='GetGenericDescriptionMedicine(this); return false;'>" + data[i].medDescription + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;' >" + data[i].medGeneric + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;'>" + data[i].medOTC + "</td><td style='display:none;'>" + data[i].medNDC_Code + "</td><td style='display:none;'>" + data[i].medCode + "</td></tr>";
            }
        }
    }
    else {
        tbl += "<tr class='review-block-right-border' id='medicinerow" + i + "'><td class='review-block-right-border' style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA; color:red;' align='center' colspan='6' >No Record Found</td></tr>";
        $("#btnAddMedicine").removeAttr("disabled");
    }
    tbl += "</table>";
    $("#divSearchMedicine").html(tbl);
    $("#divSearchMedicine").show();
}

function GetGenericDescriptionMedicine(column) {
    
    var MissingNCPDPID = false;
    if ($("select[id$='ddlType']").val().toLowerCase().trim() == "e-prescription")
        MissingNCPDPID = true;

    var param = "{'medName':'" + $(column).html() + "','MissingNCPDPID':'" + MissingNCPDPID + "'}";

    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetAllMedicines",
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: PopulateAllMedicine,
        error: function (ex) { alert(ex.Message.toString()); }
    });
}

function FillAllMedicine(row) {
    debugger;
    row = row.attr('id');
    var title = $('#' + row + ' :nth-child(2)').html();
    $("#txtMedicine").mouseover(function () {
        $(this).attr("title", title)
    }).mouseout(function () {
    });
    $("#txtMedicine").val($('#' + row + ' :nth-child(2)').html());
    $("#lblMedicineNdc").val($('#' + row + ' :nth-child(6)').html());
    $("#lblMedicineCode").val($('#' + row + ' :nth-child(7)').html());

    $("#divSearchMedicine").html('');
    $("#divSearchMedicine").hide();
    $("#txtSearchMedicine").val('');

    GetPatientContradictions();

    GetMedicineControlSubstance();
    return false;
}

function PopulateMedicine(data) {
    $("#divSearchMedicine").html('');
    data = data.d;
    var tbl = "<table style='white-space:nowrap; width:100%; font-size:11px;' cellpadding='0' cellspacing='0'>";
    tbl += "<tr valign='middle' class='review-subtitle gre-whitegrey' ><th style='background: -moz-linear-gradient(center top , #FFFFFF, #EAEAEA) repeat scroll 0 0 transparent;' width='3%'></th><th width='30%' class='review-block-right-border'> Medicine </th><th width='15%' class='review-block-right-border'> Sig </th><th width='20%' class='review-block-right-border'> Dispense </th><th width='20%' class='review-block-right-border'> Quantity </th><th width='10%' class='review-block-right-border'> Refill </th><th style='display:none;'></th><th style='display:none;'></th></tr>";
    if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
            tbl += "<tr style='white-space:nowrap;cursor:pointer;' onmouseover='ChangeColor(this);' onmouseout='RemoveColor(this);' onclick='FillMedicine(this.id);' class='review-block-right-border' id='medicinerow" + i + "'><td class='review-block-right-border' style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA;' ></td><td class='review-block-right-border review-block-right-pad' style='border-bottom: 1px solid #CDCDCD;' align='left'>" + data[i].Medicine_Trade + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;'>" + data[i].Sig + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;'>" + data[i].Dispense + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;'>" + data[i].Total + "</td><td class='review-block-right-border review-block-right-pad' align='left' style='border-bottom: 1px solid #CDCDCD;'>" + data[i].Refill + "</td><td style='display:none;'>" + data[i].NDC_Code + "</td><td style='display:none;'>" + data[i].Medicine_Code + "</td></tr>";
        }
    }
    else {
        tbl += "<tr class='review-block-right-border' id='medicinerow" + i + "'><td class='review-block-right-border' style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA; color:red;' align='center' colspan='6' >No Record Found</td></tr>";
    }
    tbl += "</table>";
    $("#divSearchMedicine").html(tbl);
    $("#divSearchMedicine").show();
}

function FillMedicine(row) {
    var title = $('#' + row + ' :nth-child(2)').html();
    $("#txtMedicine").mouseover(function () {
        $(this).attr("title", title)
    }).mouseout(function () {
    });
    $("#txtMedicine").val($('#' + row + ' :nth-child(2)').html());
    $("#hovertxtSig").val($('#' + row + ' :nth-child(3)').html());
    $('#hovertxtRefills').val($('#' + row + ' :nth-child(6)').html());
//    $('#ddlRefills').
//         append($("<option></option>").
//         attr({ "value": $('#' + row + ' :nth-child(4)').html(), "selected": "selected" }).
//         text($('#' + row + ' :nth-child(4)').html()));

    $('#txtQuantity').val($('#' + row + ' :nth-child(5)').html());
    $('#hovertxtDaysSupply').val($('#' + row + ' :nth-child(4)').html());

//    $('#ddlDyasSupply').
//         append($("<option></option>").
//         attr({ "value": $('#' + row + ' :nth-child(6)').html(), "selected": "selected" }).
//         text($('#' + row + ' :nth-child(6)').html()));

    $("#lblMedicineNdc").val($('#' + row + ' :nth-child(7)').html());

    $("#lblMedicineCode").val($('#' + row + ' :nth-child(8)').html());

    $("#divSearchMedicine").html('');
    $("#divSearchMedicine").hide();
    $("#txtSearchMedicine").val('');

    GetPatientContradictions();
    GetMeasurementUnit();
    GetMedicineControlSubstance();
    return false;
}

function GetMedicineControlSubstance() {
    if ($("#txtMedicine").val().trim() != '') {
        var request = "{'ndcCode':'" + $("#lblMedicineNdc").val() +"'}";
        $.ajax({
            type: "POST",
            url: "Prescription/PlanofCareMethod.aspx/IsControlSusbtance",
            data: request,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: checkControlSubstance

        });
        return (true);
    }
}

function checkControlSubstance(val) {
    var isSubstance = "";
    isSubstance = val.d;
    if (isSubstance.length > 0) {
        switch (isSubstance) {
            case "True":
                $("#lblControlSubstance").val("False");
                break;
            case "False":
                $("#lblControlSubstance").val("True");
                break;
        }
    }
}

function GetMeasurementUnit() {
    var medicineName = $("#txtMedicine").val().trim();
    var medIndex = medicineName.lastIndexOf(' ');
    var tag = medicineName.substring(medIndex).trim();

    var param="{'TAG':'" + tag + "'}"

    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetMeasurementUnit",
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: retrieveTagValue
    });
}

function retrieveTagValue(strTag) {
    var tagValue;
    if (strTag.hasOwnProperty("d")) {
        tagValue = strTag.d;
    }
    else
        tagValue = strTag;

    if (tagValue.length > 0) {
        $("select[id$='ddlMeasurement']").val(tagValue);
    }
}

function AddMedicine() {
    if (confirm("This is not a scheduled medication (II-V). Are you sure you want to continue with this prescription?")) {
        alert('Drug-Drug contraindication is not be available for non-Coded medicine.');
        $("#txtMedicine").val("");
        $("#txtMedicine").val($("#txtSearchMedicine").val());
        if ($("#txtMedicine").val() != "") {
            $("#txtMedicine").mouseover(function () {
                $(this).attr("title", $("#txtMedicine").val())
            }).mouseout(function () {
            });
        }
        $("#lblMedicineNdc").val('');
        $("#lblMedicineCode").val('');
        $("#divSearchMedicine").css("display", "none");
        

        return false;
    }
}

//----------------------------------------------Get Patient Contradictions---------------------------------------------------
function GetPatientContradictions() {

    var patientAccount = GetQuerString("pat_acc");
    var BackNDC = $("#txtMedicineNDC").val();
    var diagnosisCode = $("#txtDiagnosisCode").val();
    var medicineName = $("#txtMedicine").val();
    var med_NDCs = "";

//    $("#tblPOC  tr:gt(1)").each(function () {
//        var RowID = $(this).attr('id').substr(3);
//        if ($("#ndcCode" + RowID + "").text().trim() != "" && $("#active" + RowID + "").is(":checked") == true)
//            med_NDCs += "\"" + $("#ndcCode" + RowID + "").text() + "\",";
//    });
    
    var NDC_Codes = med_NDCs;
    var medicineNDC = $("#lblMedicineNdc").val();
    var param = "{'patientAccount':'" + patientAccount + "','BackNDC':'" + medicineNDC + "','DiagCode':'" + diagnosisCode + "','medNDC':'" + medicineNDC + "','NDC_Code':'" + NDC_Codes + "','medName':'" + medicineName + "'}"
    
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetContraindications",
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: PopulateContradictions,
        error: function (ex) { alert(ex.Message.toString()); }
    });
}


function PopulateContradictions(data) {
    var data = data.d;

}


//----------------------------------------------Load Patient Pharmacy---------------------------------------------------
function NewRx() {
    ClearRxForm();
    if ($("#divFormulary").hasClass('opened')) {
    }
    else {
        $("#divFormulary").addClass('opened');
        ctrlPath = "~/WEBEHR/Controls/EligibilityAndFormularyInfo.ascx";
        divID = "divFormulary";
        //loadControl('Charts.aspx/GetControlHtml', ctrlPath, divID);
        LoadControlFormulary('Charts.aspx/GetControlHtmlFormulary', ctrlPath, divID, $("[id$=ddlProvider_POC]").val(), GetQuerString("pat_acc"));
    }

    HideShowDiv("", "divFormulary");

}


function LoadControlFormulary(serviceURL, controlLocation, divID,providerCode, patientAccount) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: serviceURL,
        data: "{'controlLocation':'" + controlLocation + "','providerCode':'" + providerCode + "','patientAccount':'" + patientAccount + "'}",
        success: function (msg) { $('#' + divID).html(msg.d); },
        error: function () {
            alert("error Occured in load Control!");
        }
    });
}
function ClearRxForm() {
    ClearMedicine();
    ClearDiagnose();
    $("#hovertxtSig").val('');
    $("#txtQuantity").val('');
    $("#hovertxtDaysSupply").val('');
    $("#hovertxtRefills").val('');
    $("select[id$='ddlMeasurement']").val('');
    $("#ddlPrescriptionStatus").val('');
    $("#txtStartDate").val('');
    $("#txtEndDate").val('');
    $("#txtDrugtoDrug").val('');
    $("#txtDrugtoDisease").val('');
    $("#txtDrugtoAllergy").val('');
    $("#txtDrugtoFood").val('');
    $("#txtCoverageCopay").val('');
    $("#txtProviderComments").val('');
    $("#chkPrescriptionActive").attr("checked", false);
    $("#chkConfedential").attr("checked", false);
    $("#chkPrescriptionReviewed").attr("checked", false);
    $("#chkSubstitution").attr("checked", false);
    $("#chkOverriderAdverse").attr("checked", false);
}

function ShowDivNewRx(args) {
    //$("input[id$='BtnremoveAsync']").focus();
    if (args == 'SELECT')
        ShowFormularyStatus();
//    var defaultText = "Type Criteria and Press Enter";
//    $("#txtSearchMedicine").val(defaultText);

    var type = $("select[id$='ddlType']").val();
    var IsPrescriptionFromSureScript = false;

    if (type.toLowerCase == "e-prescritpion") {
        IsPrescriptionFromSureScript = true;
    }

    $("#lblNewRx").val("NewRx");
    $("#lblRenewRx").val("");
    $("#lblExistingRx").val("");

    var patientAccount = GetQuerString("pat_acc");

    var param = "{'patientAccount':'" + patientAccount + "','IsPrescriptionFromSureScript':'" + IsPrescriptionFromSureScript + "'}";
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetPatientPharmacy",
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: PopulatePatientPharmacy,
        error: function (ex) { alert(ex.Message.toString()); }
    });
}

function PopulatePatientPharmacy(data) {
    debugger;
    responsePharmacy = data.d;
    if (responsePharmacy.length > 0) {
        {
            var nameadd = responsePharmacy[0] + " [" + responsePharmacy[3] + " " + responsePharmacy[4] + "]";
            if (nameadd != "") {
                $("#txtPharmacy").mouseover(function () {
                    $(this).attr("title", nameadd)
                }).mouseout(function () {
                });
            }
            $("#txtPharmacy").val(nameadd);
            $("#lblPharmacyId").val(responsePharmacy[1]);
            $("#lblncpdpid").val(responsePharmacy[2]);
//            $("input[id$='hdnPharCity']").val(responsePharmacy[4]);
//            $("input[id$='hdnPharState']").val(responsePharmacy[5]);
//            $("input[id$='hdnPharZip']").val(responsePharmacy[6]);
//            $("input[id$='hdnPharFax']").val(responsePharmacy[7]);
//            $("input[id$='hdnPharPhone']").val(responsePharmacy[8]);
//            $("span[id$='LblPharmacyName']").text(responsePharmacy[0]);
//            $("input[id$='hdnPharAddress']").val(responsePharmacy[3]);



            $("span[id$='LblPharmacyZipCity']").text(responsePharmacy[4] + ', ' + responsePharmacy[5] + ' ' + responsePharmacy[6]);

            var phone = formatPhone(responsePharmacy[8]);
            if (phone != false)
                $("span[id$='LblPharmacyPhone']").text(phone);
            $("span[id$='LblPharmacyPhone']").text(phone);
            $("span[id$='LblPharmacyName']").text(responsePharmacy[0]);


            $("span[id$='LblPharmacyAddress']").text(responsePharmacy[3]);
        }
    }
    else {
//        $("#txtPharmacy").val('');
//        $("#lblPharmacyId").val('');
//        $("#lblncpdpid").val('');
//        $("input[id$='hdnPharCity']").val('');
//        $("input[id$='hdnPharState']").val('');
//        $("input[id$='hdnPharZip']").val('');
//        $("input[id$='hdnPharFax']").val('');
//        $("input[id$='hdnPharPhone']").val('');
//        $("span[id$='LblPharmacyName']").text('');
        //        $("input[id$='hdnPharAddress']").val('');
        $("span[id$='LblPharmacyZipCity']").text('');

        $("span[id$='LblPharmacyPhone']").text('');
        $("span[id$='LblPharmacyName']").text('');


        $("span[id$='LblPharmacyAddress']").text('');
    }
    HideShowDiv("divFormulary", "divNewRx");
    $("[id^='hover']").each(function () {
        $(this).width($(this).siblings().width() - 17);
    });
}

//----------------------------------------------Load Pharmacies---------------------------------------------------

function PharSearchbtn_Click(CallFrom) {
    HideShowDiv("divNewRx", "divSearchPharmacy");
    if (CallFrom == "AdvanceSearch")
        PharmacySearchPageNo = 1; //Reset PageNumber
    UnbindPharmacySearchPager();
    //validateControltxt('ctl00_MTBCDynamicWebContentsPlaceHolder_txtPharname','AlphaNumeric');
    var pharName = $("#txtPharmacyName").val().trim();
    pharName = pharName.replace(/'/g, "`").replace(/\\/g, "\\\\");
    //var pracCode = $("input[type='hidden'][id$='hdnPracCode']").val();
    //var practiceState = '<%=Profile.PracState%>';
    //var userName = $("input[type='hidden'][id$='hdnProfileUsername']").val();
    var patAccount = GetQuerString("pat_acc");

    var txtPharmacyAddress = $("#txtPharmacyAddress").val().trim();
    var txtPharmacyCity = $("#txtPharmacyCity").val().trim();
    var txtPharmacyState = $("#ddlPharmacyState").val().trim();
    var txtPharmacyZIP = $("#txtPharmacyZip").val().trim();
    var txtPharmacyPhone = $("#txtPharmacyPhone").val().trim();
    var txtPharmacyFax = $("#txtPharmacyFax").val().trim();

    txtPharmacyAddress = txtPharmacyAddress.replace(/'/g, "`").replace(/\\/g, "\\\\");
    txtPharmacyCity = txtPharmacyCity.replace(/'/g, "`").replace(/\\/g, "\\\\");
    txtPharmacyZIP = txtPharmacyZIP.replace(/'/g, "`").replace(/\\/g, "\\\\");
    txtPharmacyPhone = txtPharmacyPhone.replace(/'/g, "`").replace(/\\/, "\\\\");
    txtPharmacyFax = txtPharmacyFax.replace(/'/g, "`").replace(/\\/, "\\\\");

    var PatientFavorites = false;
    var Mylist = false;
    var filterExp = "";
    
    if ($("#rdoPharmacyAll").is(":checked") == true) {
        if (pharName != "") {
            filterExp = "pharmacy_name like \"" + pharName + "%\"";
        }
        else {
            filterExp = "";
        }
    }

    else if ($("#rdoPharmacyMyState").is(":checked") == true) {
        if (pharName != "") {
            filterExp = "pharmacy_name like \"" + pharName + "%\" and pharmacy_State =\"practiceState\"";
        }
        else {
            filterExp = "pharmacy_State =\"practiceState\"";
        }
    }
//    else if ($("#rdoPharmacyMyList").is(":checked") == true) {
//        if (pharName != "") {
//            filterExp = "pharmacy_name like \"" + pharName + "%\" and patient_account =\"" + patAccount + "\"";
//        }
//        else {
//            filterExp = "patient_account =\"" + patAccount + "\"";
//        }
//        PatientFavorites = true;
//        $("input[type='hidden'][id$='hdnPharmacyRdvalue']").val("rdbPatientFavorite");
//    }

    else {
        if (pharName != "") {
            filterExp = "pharmacy_name like \"" + pharName + "%\" and pml.practice_code=\"pracCode\"";
        }
        else {
            filterExp = "pml.practice_code =\"pracCode\"";
        }
        Mylist = true;
    }
    PharmacySearchPageSize = $("#ddlPharmacyPage").val();
    if (PharmacySearchPageNo == "")
        PharmacySearchPageNo = 1;
    var request = "{'MissingNCPDPID':false,'FilterQuery':'" + filterExp + "','PatientFavorites':'" + PatientFavorites + "','byAddress':'" + txtPharmacyAddress + "','byCity':'" + txtPharmacyCity + "','byState':'" + txtPharmacyState + "','byZip':'" + txtPharmacyZIP + "','byPhone':'" + txtPharmacyPhone + "','byFax':'" + txtPharmacyFax + "','MyList':'" + Mylist + "','pageNumber':" + PharmacySearchPageNo + ",'pageSize':'" + PharmacySearchPageSize + "','sortDirection':1,'sortBy':'1'}";
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/LoadPharmacies",
        data: request,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: GeneratePharmaciesTable
    });

}


function GeneratePharmaciesTable(data) {
    tabPharmacies = data.d;
    var isFaxPharmacy = "";
    var lastRecord = tabPharmacies.length;

    var table = "<table id='filtertable' class='gridtable' style='font-size:11px;font-color:blue;background-color:white;white-space:nowrap; width:100%;'  border-bottom='1' cellpadding='2'>";
    table += "<tr><th style='background: -moz-linear-gradient(center top , #FFFFFF, #EAEAEA) repeat scroll 0 0 transparent;' width='3%'></th>";
    table += "<th>Pharmacy</th>";
    table += "<th>Address</th>";
    table += "<th>City</th>";
    table += "<th>State</th>";
    table += "<th>ZIP</th>";
    table += "<th>Fax Number</th>";
    table += "<th>Phone Number</th>";
    table += "<th style='display:none;'>Pharmacy Code</th>";
    table += "<th style='display:none;'>NCPDPD ID</th>";
    table += "<th>Fax Pharmacy</th>";
    table += "</tr>";
    var Srno = 1;
    if (lastRecord > 0) {
        $("#divPagerSearchPharmacy").show();
        MaxPharmacyPageNo = tabPharmacies[0].TotalPages;
        $("span[id$=lblTotalPages]").text(MaxPharmacyPageNo);
        $('#txtCurrentPage').val(PharmacySearchPageNo);
        var fName = 'filterPharmacyTable("filterbyName")';
        var fAddress = 'filterPharmacyTable("filterbyAddress")';
        var fCity = 'filterPharmacyTable("filterbyCity")';
        var fState = 'filterPharmacyTable("filterbyState")';
        var fZip = 'filterPharmacyTable("filterbyZip")';
        var fFax = 'filterPharmacyTable("filterbyFax")';
        var fPhone = 'filterPharmacyTable("filterbyPhone")';
        var fPartnerAcc = 'filterPharmacyTable("filterbyPartnerAcc")';

        //         
        table += "<tr  ><td style='border-bottom: 1px solid #CDCDCD;  background: -moz-linear-gradient(center top , #EEEEEE, #EEEEEE) repeat scroll 0 0 transparent;' align='center'></td>";
        table += "<td align='left'><input type='text' id='filterbyName' class='textbox' autocomplete='off'  onkeyup='" + fName + "' /></td>";
        table += "<td align='left' ><input type='text' id='filterbyAddress' class='textbox' autocomplete='off'  onkeyup='" + fAddress + "'  /></td>";
        table += "<td align='left' ><input type='text' id='filterbyCity' class='textbox' autocomplete='off'  onkeyup='" + fCity + "' /></td>";
        table += "<td align='left' ><input type='text' id='filterbyState' class='textbox' autocomplete='off' onkeyup='" + fState + "' /></td>";
        table += "<td align='left' ><input type='text' id='filterbyZip' class='textbox' autocomplete='off' onkeyup='" + fZip + "' /></td>";
        table += "<td align='left'><input type='text' id='filterbyFax' class='textbox' autocomplete='off' onkeyup='" + fFax + "' /></td>";
        table += "<td align='left'><input type='text' id='filterbyPhone' class='textbox' autocomplete='off' onkeyup='" + fPhone + "' /></td>";
        table += "<td align='left' style='display:none;' ></td>";
        table += "<td align='left' style='display:none;' ></td>";
        table += "<td align='left'><input type='text' id='filterbyPartnerAcc' class='textbox' autocomplete='off' onkeyup='" + fPartnerAcc + "' /></td>";
        //   table+="</tr></table></td>
        table += "</tr>";
        table += "<tr >";
        table += "<td colspan='10'  style='border:0'>";
        //table += "<table id='filtertable' class='hor-minimalist-c' style=' white-space:nowrap; '  border-bottom='1' cellpadding='2'>";
        for (index = 0; index <= lastRecord - 1; index++) {
            var pharName = tabPharmacies[index].pharmacyName;
            var pharNameLen = tabPharmacies[index].pharmacyName.length;
            if (pharNameLen > 25) {
                var max = 18;
                var description = pharName.substring(0, max - 3);
                pharName = description + '...';
            }
            var pharAddress = tabPharmacies[index].pharmacyAddress;
            var pharAddressLen = tabPharmacies[index].pharmacyAddress.length;
            if (pharAddressLen > 22) {
                var max = 22;
                var description = pharAddress.substring(0, max - 3);
                pharAddress = description + '...';
            }
            var pharCity = tabPharmacies[index].pharmacyCity;
            var pharCityLen = tabPharmacies[index].pharmacyCity.length;
            if (pharCityLen > 16) {
                var max = 16;
                var description = pharCity.substring(0, max - 3);
                pharCity = description + '...';
            }
            var ToolTip1 = 'BindToolTipPharmacy("' + '<b>Name:</b>' + tabPharmacies[index].pharmacyName + '")';
            var ToolTip2 = 'BindToolTipPharmacy("' + '<b>Address:</b>' + tabPharmacies[index].pharmacyAddress + '")';
            var HighlightRow = 'HighlightPharmacyRows("' + index + '")';
            var AssignPharValues = 'populatePharmacy("' + tabPharmacies[index].pharmacyName + '","' + tabPharmacies[index].pharmacyAddress + '","' + tabPharmacies[index].pharmacyCode + '","' + tabPharmacies[index].NCPDP_ID + '","' + tabPharmacies[index].pharmacyCity + '","' + tabPharmacies[index].pharmacyState + '","' + tabPharmacies[index].pharmacyZip + '","' + tabPharmacies[index].pharmacyFax + '","' + tabPharmacies[index].pharmacyPhone + '","' + tabPharmacies[index].partnerAccount + '")';

            //table += "<tr ondblclick='" + AssignPharValues + "' onclick='" + HighlightRow + "' id=tabPharrow" + index + ">";
            //table += "<tr onclick='" + AssignPharValues + "' id=tabPharrow" + index + ">";
            table += "<tr style='white-space:nowrap;cursor:pointer;' onmouseover='ChangeColor(this);' onmouseout='RemoveColor(this);'  onclick='" + AssignPharValues + "' id=tabPharrow" + index + " class='review-block-right-border'>";
            table += "<td  style='padding:5px; border-bottom: 1px solid #CDCDCD;  background: -moz-linear-gradient(center top , #EEEEEE, #EEEEEE) repeat scroll 0 0 transparent;'></td>";
            table += "<td align='left' style='padding:5px;'  width='18%' ><a href='javascript:void(0)' id='SelectName" + index + "' title='" + tabPharmacies[index].pharmacyName + "' >" + toTitleCaseUserInformation(pharName) + "</a></td>";
            table += "<td align='left' style='padding:5px;' width='22%'  ><span id='SelectAdd" + index + "' title='" + tabPharmacies[index].pharmacyAddress + "'>" + toTitleCaseUserInformation(pharAddress) + "</span></td>";
            table += "<td align='left' style='padding:5px;' width='14%' ><span id='SelectCity" + index + "' title='" + tabPharmacies[index].pharmacyCity + "'>" + toTitleCaseUserInformation(pharCity) + "</span></td>";
            table += "<td align='left' style='padding:5px;' width='5%' ><span id='SelectState" + index + "' title='" + tabPharmacies[index].pharmacyState + "'>" + tabPharmacies[index].pharmacyState + "</span></td>";
            table += "<td align='left' style='padding:5px;' width='8%' ><span id='SelectZip" + index + "' title='" + tabPharmacies[index].pharmacyZip + "'>" + tabPharmacies[index].pharmacyZip + "</span></td>";
            table += "<td align='left' style='padding:5px;' width='12%' ><span id='Selectfax" + index + "' title='" + tabPharmacies[index].pharmacyFax + "'>" + tabPharmacies[index].pharmacyFax + "</span></td>";
            table += "<td align='left' style='padding:5px;'  width='12%'><span id='Selectphone" + index + "' title='" + tabPharmacies[index].pharmacyPhone + "'>" + tabPharmacies[index].pharmacyPhone + "</span></td>";
            table += "<td align='left'  style='display:none; padding:5px;'  ><a href='javascript:void(0)' id='SelectCode" + index + "'>" + tabPharmacies[index].pharmacyCode + "</></td>";
            table += "<td align='left'  style='display:none; padding:5px;' ><a href='javascript:void(0)' id='SelectNcpdpid" + index + "'>" + tabPharmacies[index].NCPDP_ID + "</a></td>";


            var partnerAccount = (tabPharmacies[index].partnerAccount == null || tabPharmacies[index].partnerAccount.toLowerCase() == "null") ? "" : tabPharmacies[index].partnerAccount.trim();
            if (partnerAccount.toUpperCase() == "FAX")
                isFaxPharmacy = "Yes";
            else
                isFaxPharmacy = "No"
            table += "<td align='center'  width='10%' ><span id='SelectPartnerAcc" + index + "' title='" + isFaxPharmacy + "'>" + isFaxPharmacy + "</span></td>";
            table += "</tr>";
            Srno++;
        }
    }
    else {
        $("#divPagerSearchPharmacy").hide();
        table += "<tr  id=tabPharrow" + Srno + ">";
        table += "<td align='center' style='color:Maroon'  colspan='9'>No Record Found.</td>";
        table += "</tr>";
    }
    table += "</table></td></tr>";
    table += "</tr>";
    table += "</table>";

    $("#divPharmacies").html(table);

    EnableDisablePharmacyPager();

}

function toTitleCaseUserInformation(str) {
    return str.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
}

function NextPagePharmacySearch(option) {

    if (option == "first") {
        PharmacySearchPageNo = 1;
        PharSearchbtn_Click();
    }

    else if (option == "previous") {
        tempPage = PharmacySearchPageNo - 1;

        if (tempPage < 1) {
            alert("Minimum page reached");
            return;
        }
        else {
            PharmacySearchPageNo = PharmacySearchPageNo - 1;
            PharSearchbtn_Click();
        }
    }
    else if (option == "next") {
        tempPage = PharmacySearchPageNo + 1;
        if (tempPage > MaxPharmacyPageNo) {
            alert("Maximum page reached");
            return;
        }
        else {
            PharmacySearchPageNo = PharmacySearchPageNo + 1;
            PharSearchbtn_Click();
        }
    }
    else if (option == "last") {
        if (PharmacySearchPageNo == MaxPharmacyPageNo)
            return false;
        PharmacySearchPageNo = MaxPharmacyPageNo;
        PharSearchbtn_Click();
    }
}

function filterPharmacyTable(args) {
    var selSelection = $("#" + args + "").val().toUpperCase();
    if (!selSelection) $("#filtertable tr:gt(2)").show();
    else {
        $("#filtertable tr:gt(2)").show().filter(function (index) {
            switch (args) {
                case "filterbyName":
                    return $("td:eq(1)", this).text().indexOf(selSelection) == -1;
                    break;
                case "filterbyAddress":
                    return $("td:eq(2)", this).text().indexOf(selSelection) == -1;
                    break;
                case "filterbyCity":
                    return $("td:eq(3)", this).text().indexOf(selSelection) == -1;
                    break;
                case "filterbyState":
                    return $("td:eq(4)", this).text().indexOf(selSelection) == -1;
                    break;
                case "filterbyZip":
                    return $("td:eq(5)", this).html().indexOf(selSelection) == -1;
                    break;
                case "filterbyFax":
                    return $("td:eq(6)", this).html().indexOf(selSelection) == -1;
                    break;
                case "filterbyPhone":
                    return $("td:eq(7)", this).html().indexOf(selSelection) == -1;
                    break;
                case "filterbyPartnerAcc":
                    return $("td:eq(10)", this).html().indexOf(selSelection) == -1;
                    break;
            }
        }).hide();
    }
}

function PageNumber() {
    PharmacySearchPageNo = 1;
    PharSearchbtn_Click();
}

function EnableDisablePharmacyPager() {
    if (PharmacySearchPageNo == 1 && MaxPharmacyPageNo > 1) {
        $("#btnPharmacyFirstE").attr("src", "../../App_Themes/MTBCWithDashboard/images/i_first_d.gif").css("cursor", "auto");
        $("#btnPharmacyPreviousE").attr("src", "../../App_Themes/MTBCWithDashboard/images/i_previous_d.gif").css("cursor", "auto");
        $("#btnPharmacyNextE").bind("click", function () { NextPagePharmacySearch('next') }).attr("src", "../../App_Themes/MTBCWithDashboard/images/i_next_e.gif").css("cursor", "pointer");
        $("#btnPharmacyLastE").bind("click", function () { NextPagePharmacySearch('last') }).attr("src", "../../App_Themes/MTBCWithDashboard/images/i_last_e.gif").css("cursor", "pointer");
    }
    if (PharmacySearchPageNo == MaxPharmacyPageNo) {
        $("#btnPharmacyNextE").attr("src", "../../App_Themes/MTBCWithDashboard/images/i_next_d.gif").css("cursor", "auto");
        $("#btnPharmacyLastE").attr("src", "../../App_Themes/MTBCWithDashboard/images/i_last_d.gif").css("cursor", "auto");
        $("#btnPharmacyFirstE").bind("click", function () { NextPagePharmacySearch('first') }).attr("src", "../../App_Themes/MTBCWithDashboard/images/i_first_e.gif").css("cursor", "pointer");
        $("#btnPharmacyPreviousE").bind("click", function () { NextPagePharmacySearch('previous') }).attr("src", "../../App_Themes/MTBCWithDashboard/images/i_previous_e.gif").css("cursor", "pointer");
    }

    if (PharmacySearchPageNo > 1 && PharmacySearchPageNo < MaxPharmacyPageNo) {
        $("#btnPharmacyFirstE").bind("click", function () { NextPagePharmacySearch('first') }).attr("src", "../../App_Themes/MTBCWithDashboard/images/i_first_e.gif").css("cursor", "pointer");
        $("#btnPharmacyPreviousE").bind("click", function () { NextPagePharmacySearch('previous') }).attr("src", "../../App_Themes/MTBCWithDashboard/images/i_previous_e.gif").css("cursor", "pointer");
        $("#btnPharmacyNextE").bind("click", function () { NextPagePharmacySearch('next') }).attr("src", "../../App_Themes/MTBCWithDashboard/images/i_next_e.gif").css("cursor", "pointer");
        $("#btnPharmacyLastE").bind("click", function () { NextPagePharmacySearch('last') }).attr("src", "../../App_Themes/MTBCWithDashboard/images/i_last_e.gif").css("cursor", "pointer");
    }
    if (PharmacySearchPageNo == 1 && MaxPharmacyPageNo == 1) {
        UnbindPharmacySearchPager();
        $("#btnPharmacyFirstE").attr("src", "../../App_Themes/MTBCWithDashboard/images/i_first_d.gif").css("cursor", "auto");
        $("#btnPharmacyPreviousE").attr("src", "../../App_Themes/MTBCWithDashboard/images/i_previous_d.gif").css("cursor", "auto");
        $("#btnPharmacyNextE").attr("src", "../../App_Themes/MTBCWithDashboard/images/i_next_d.gif").css("cursor", "auto");
        $("#btnPharmacyLastE").attr("src", "../../App_Themes/MTBCWithDashboard/images/i_last_d.gif").css("cursor", "auto");
    }
}

function UnbindPharmacySearchPager() {

    $("#btnPharmacyFirstE").unbind("click");
    $("#btnPharmacyPreviousE").unbind("click");
    $("#btnPharmacyNextE").unbind("click");
    $("#btnPharmacyLastE").unbind("click");
}


function populatePharmacy(pharmacyName, pharmacyAddress, pharmacyCode, NCPDP_ID, pharmacyCity, pharmacyState, pharmacyZip, pharmacyFax, pharmacyPhone, pharmacyPartnerAcc) {
    

    var nameadd = pharmacyName + " [" + pharmacyAddress + " " + pharmacyCity + "]";
    if (nameadd != "") {
        $("#txtPharmacy").mouseover(function () {
            $(this).attr("title", nameadd)
        }).mouseout(function () {
        });
    }
    $("#txtPharmacy").val(nameadd);

    $("#lblPharmacyId").val(pharmacyCode);
    $("#lblncpdpid").val(NCPDP_ID);


    $("span[id$='LblPharmacyZipCity']").text(pharmacyCity + ', ' + pharmacyState + ' ' + pharmacyZip);

    var phone = formatPhone(pharmacyPhone);
    if (phone != false)
        $("span[id$='LblPharmacyPhone']").text(phone);
    $("span[id$='LblPharmacyPhone']").text(phone);
    $("span[id$='LblPharmacyName']").text(pharmacyName);
    

    $("span[id$='LblPharmacyAddress']").text(pharmacyAddress);
    
    HideShowDiv("divSearchPharmacy", "divNewRx");
    return false;
}   

//----------------------------------------------Dose Recommendation---------------------------------------------------

function DoseRecommendation() {
    if ($("#txtMedicine").val() == '') {
        alert('Select Medicine');
        return false;
    }
    var medicineNDC = $("#lblMedicineNdc").val();
    var param = "{'medicineNDC':'" + medicineNDC + "'}";

    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetDoseRecommendations",
        data: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: PopulateDoseRecommendation,
        error: function (ex) { alert(ex.Message.toString()); }
    });
}

function PopulateDoseRecommendation(data) {
    data = data.d;
    var tbl = "<tr valign='middle' align='center' class='review-subtitle gre-whitegrey'><th>Dose Type</th><th>Low</th><th>High</th><th>Max Single Dose</th><th>Low Frequency</th><th>High Frequency</th></tr>";
    if (data.length == 0) {
        tbl += "<tr><td class='review-block-right-border' style='border-bottom: 1px solid #CDCDCD; background-color:#EAEAEA; color:red;' align='center' colspan='6' >No Record Found</td></tr>";
    }
    for (var i = 0; i < data.length; i++) {
        if (i % 2 == 0)
            tbl += "<tr style='white-space:nowrap;' class='review-block-right-border'><td class='review-block-right-border review-block-right-pad'>" + data[i].Dose_type + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].low + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].high + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].max_single_dose + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].low_frequency_day + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].high_frequency_day + "</td></tr>";
        else
            tbl += "<tr style='white-space:nowrap;' class='review-block-right-border-altr'><td class='review-block-right-border review-block-right-pad'>" + data[i].Dose_type + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].low + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].high + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].max_single_dose + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].low_frequency_day + "</td><td class='review-block-right-border review-block-right-pad'>" + data[i].high_frequency_day + "</td></tr>";
    }
    $("#tblDoseRecommendations").html(tbl);

    HideShowDiv("divNewRx", "divDoseRecommendation");

}


function HideShowDiv(divToHide, divToShow) {
    if (divToShow != '') {
        $("#" + divToShow).jqm({ overlay: 50, modal: true, trigger: false });
        $("#" + divToShow).jqmShow();
        
        var left = (window.innerWidth / 2) - ($("#" + divToShow).width() / 2);
        
        //var top1  = (window.innerHeight / 2) - ($("#" + divToShow).height() / 2);
        //$("#" + divToShow).css("top", top1);
        
        $("#" + divToShow).css("left", left);
    }
    if (divToHide != '') {
        $("#" + divToHide).jqmHide();
    }
}

//----------------------------------------------Load External Drug History---------------------------------------------------

function LoadExternalDrugHistoryControl() {

    if ($("#btnExternalDrugHistory").hasClass('opened')) {
    }
    else {
        $("#btnExternalDrugHistory").addClass('opened');
        ctrlPath = "~/WEBEHR/Controls/ExternalDrugHistory.ascx";
        divID = "divExternalDrugHistory";
        LoadControlFormulary('Charts.aspx/GetControlHtmlFormulary', ctrlPath, divID, $("[id$=ddlProvider_POC]").val(), GetQuerString("pat_acc"));
    }

    HideShowDiv("divNewRx", "divExternalDrugHistory");
}

function EnableDisableExternalDrugHistory() {
    if ($("#chkPatientConsent").is(':checked') == true) {
        $("#btnExternalDrugHistory").css("diabled", false);
        $("#btnExternalDrugHistory").bind("click", LoadExternalDrugHistoryControl);
    }
    else {
        $("#btnExternalDrugHistory").css("diabled", "disabled");
        $("#btnExternalDrugHistory").unbind("click");
    }
}

//----------------------------------------------Medicine Formulary Status---------------------------------------------------

function ShowFormularyStatus() {
    if ($("input[id$='txtMedicineCode']").val() !== "" && $("input[id$='txtMedicineCode']").val().trim().length > 0
    && $("select[id$='ddlType']").val().toUpperCase() == "E-PRESCRIPTION") {
        var dataParams = "{'_SelectedProvSPI':'" + $("input[type='hidden'][id$='hdnCmbSPIValue']").val() + "','selectedProviderCode':'" + $("select[id$='ddlProvider_POC']").val() + "','lblMedicineCode':'" + $("input[id$='txtMedicineCode']").val() + "','sPayer_ID':'" + $("input[type='hidden'][id$='hdnPayerId']").val() + "','sFormulary_ID':'" + $("input[type='hidden'][id$='hdnFormularyListID']").val() + "','sCoverage_ID':'" + $("input[type='hidden'][id$='hdnCoverageId']").val() + "'}";
        $.ajax({
            type: "POST",
            url: "RxPatient_Prescription.aspx/ShowFormularyStatus",
            data: dataParams,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (Response) {
                var responseStatus;
                if (Response.hasOwnProperty("d")) {
                    responseStatus = Response.d;
                }
                else
                    responseStatus = Response;

                if (responseStatus.length > 0) {
                    $("#divNewRx :span[id$='LblMedicineFormularyStatus']").text(responseStatus.trim());
                    //$(":#divNewRx :span[id$='LblMedicineFormularyStatus']").css("display","block")
                }
                else {
                    $("#divNewRx :span[id$='LblMedicineFormularyStatus']").text("");
                    //$(":#divNewRx :span[id$='LblMedicineFormularyStatus']").css("display","none")
                }
            }

        });

    }
}

//----------------------------------------------Send Prescription---------------------------------------------------

function SendPrescription() {
    var patAccount = GetQuerString("pat_acc");
    var PrescriptionID = $("#lblPrescriptionID").val();

    var cboProvidersVal = $("select[id$='ddlProvider_POC']").val().split("_")[1];  //
    var pharmacyCode = $("#lblPharmacyId").val();
    var cboPharmacyText = $("#txtPharmacy").val(); 

    var txtMedicineCode = $("#lblMedicineCode").val(); 
    var txtMedicineName = $("#txtMedicine").val();
    var txtMedicineNDC = $("#lblMedicineNdc").val();
    var txtSIGDisplay = $("#hovertxtSig").val();
    var txtDispenseDisplay = $('#hovertxtDaysSupply').val();
    var txtQuantity = $("#txtQuantity").val();
    var txtDisplayRefills = $("#hovertxtRefills").val();
    var cboUnits = $("[id$='ddlMeasurement']").val();
    var cboType = $("select[id$='ddlType']").val();
    
    var txtDiagnoseCode = $("#txtDiagnosisCode").val();

    var txtStartDate = $("input[id$='txtStartDate']").val();
    var txtEndDate = $("input[id$='txtEndDate']").val();
    
    var txtDrugToDrug = $("#txtDrugtoDrug").val();
    var txtDrugToDisease = $("#txtDrugtoDisease").val();
    var txtDrugToAllergy = $("#txtDrugtoAllergy").val();
    var txtDrugToFood = $("#txtDrugtoFood").val();

    var chkOverriderAdverse = $("#chkOverriderAdverse").is(":checked");
    var txtOverrideReason = $("#txtOverrideReason").val();
    
    var chkIsConfidential = $("#chkConfedential").is(":checked");
    var chkActive = $("#chkPrescriptionActive").is(":checked");
    var chkPrescriptionReviewed = $("#chkPrescriptionReviewed").is(":checked");
    var chkSubstitution = $("#chkSubstitution").is(":checked");

    var fomularyListID = $("[id$='hdnFormularyListID']").val();
    var CopayId = $("[id$='hdnCopayid']").val();
    var AlternativeID = $("[id$='hdnAlternativeid']").val();
    var CoverageId = $("[id$='hdnCoverageId']").val();
    var Payername = $("[id$='hdnPayername']").val();
    var healthPlanId = $("[id$='hdnHealthPlanID']").val();
    var PayerID = $("[id$='hdnPayerId']").val();
    var GroupID = $("[id$='hdnGroupId']").val();
    var pharmacyType = $("[id$='hdnPharmacyType']").val();
    var CardHolderID = $("[id$='hdnCardHolderID']").val();
    var CardHolderName = $("[id$='hdnCardHolderName']").val();
    var MailorderIndicator = $("[id$='HiddenbinLocationNumber']").val();
    var binLocationNumber = $("[id$='HiddenbinLocationNumber']").val(); 
    var PIC = $("[id$='HiddenPIC']").val();
    var providerCode = $("select[id$='ddlProvider_POC']").val().split("_")[1];

    var txtProviderInstruction = $("#txtProviderComments").val();

    var hdnSendNewRx = $("#lblNewRx").val();
    var hdnRenewRX = $("#lblRenewRx").val();

    //-----------------------------------------------------------------

    var txtPatientInstruction = ''; //$("textarea[id$='txtPatientInstruction']").val();

    var txtDiscard = ""; //$("input[id$='txtDiscard']").val();
    var txtExpire = "";//  $("input[id$='txtExpire']").val();
    var formularyStatus = $("input[id$='txtFAFSV']").val();
    var generic = ''; //$("input[id$='txtFAgeneric']").val();
    var txtPharmacyInstruction = ''; //$("textarea[id$='txtPharmacyInstruction']").val();
    var chkHold = false ; //$("input[type='checkbox'][id$='chkHold']").attr("checked");
    var cboStatus = $("select[id$='ddlPrescriptionStatus']").val().trim();

    var RxNorm = $("input[id$='hdnRxNorm']").val();
    
    txtProviderInstruction = txtProviderInstruction.replace(/'/g, "`").replace(/\\/g, "\\\\");
    txtMedicineName = txtMedicineName.replace(/'/g, "`").replace(/\\/g, "\\\\");
    txtSIGDisplay = txtSIGDisplay.replace(/'/g, "`").replace(/\\/g, "\\\\");
    txtQuantity = txtQuantity.replace(/'/g, "`").replace(/\\/g, "\\\\");
    txtSIGDisplay = txtSIGDisplay.replace(/'/g, "`").replace(/\\/g, "\\\\");
    txtOverrideReason = txtOverrideReason.replace(/'/g, "`").replace(/\\/g, "\\\\");

    var datatParams = "{'PrescriptionID':'" + PrescriptionID + "','patAccount':'" + patAccount + "','cboProvidersVal':'" + cboProvidersVal + "','pharmacyCode':'" + pharmacyCode + "','cboPharmacyText':'" + cboPharmacyText + "','txtMedicineCode':'" + txtMedicineCode + "','txtMedicineName':'" + txtMedicineName + "','txtSIGDisplay':'" + txtSIGDisplay + "','txtDispenseDisplay':'" + txtDispenseDisplay + "','txtQuantity':'" + txtQuantity + "','txtDisplayRefills':'" + txtDisplayRefills + "','txtPatientInstruction':'" + txtPatientInstruction + "','chkActive':'" + chkActive + "','txtDiscard':'" + txtDiscard + "','txtExpire':'" + txtExpire + "','cboType':'" + cboType + "','chkOverriderAdverse':'" + chkOverriderAdverse + "','txtOverrideReason':'" + txtOverrideReason + "','txtPharmacyInstruction':'" + txtPharmacyInstruction + "','chkIsConfidential':'" + chkIsConfidential + "','chkHold':'" + chkHold + "','chkPrescriptionReviewed':'" + chkPrescriptionReviewed + "','txtDiagnoseCode':'" + txtDiagnoseCode + "','cboUnits':'" + cboUnits + "','txtProviderInstruction':'" + txtProviderInstruction + "','txtStartDate':'" + txtStartDate + "','txtEndDate':'" + txtEndDate + "','txtDrugToDrug':'" + txtDrugToDrug + "','txtDrugToDisease':'" + txtDrugToDisease + "','txtDrugToAllergy':'" + txtDrugToAllergy + "','txtDrugToFood':'" + txtDrugToFood + "','cboStatus':'" + cboStatus + "','chkSubstitution':'" + chkSubstitution + "','hdnSendNewRx':'" + hdnSendNewRx + "','txtMedicineNDC':'" + txtMedicineNDC + "','fomularyListID':'" + fomularyListID + "','CopayId':'" + CopayId + "','AlternativeID':'" + AlternativeID + "','CoverageId':'" + CoverageId + "','Payername':'" + Payername + "','healthPlanId':'" + healthPlanId + "','PayerID':'" + PayerID + "','GroupID':'" + GroupID + "','pharmacyType':'" + pharmacyType + "','RenewRx':'" + hdnRenewRX + "','providerCode':'" + providerCode + "','formularyStatus':'" + formularyStatus + "','generic':'" + generic + "','CardHolderID':'" + CardHolderID + "','CardHolderName':'" + CardHolderName + "','MailorderIndicator':'" + MailorderIndicator + "','binLocationNumber':'" + binLocationNumber + "','PIC':'" + PIC + "','RxNorm':'" + RxNorm + "','chartId':'" + GetQuerString("ChartID") + "'}";
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/SaveRecord",
        data: datatParams,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: PrescriptionStatus,
        error: function () { alert('Error') }
    });
}


function PrescriptionStatus(sResponse) {
    var messageStr = "";
    if (sResponse.hasOwnProperty("d")) {
        messageStr = sResponse.d;
    }
    else
        messageStr = sResponse;

    if (messageStr.length > 0) {
        //$("span[id$='lblResult']").text(messageStr);
        HideShowDiv("divPrescriptionSummary", "");
        GetPatientPrescription();
    }
    else {
        HideShowDiv("divNewRx", "");
        GetPatientPrescription();
        if ($("select[id$='ddlType']").text().toLowerCase() == "e-prescription")
            alert("Prescription saved successfully but can't send electronically. If you want to send electronically save new prescription");
        HideShowDiv("divPrescriptionSummary", "");
        GetPatientPrescription();
    }
    $("#lblPrescriptionID").val("");
    //  $("input[id$='hdnRxNorm']").val(); //RxNorm
    $("#lblRenewRx").val(""); //clear renew Field
    $("#lblNewRx").val(""); //clear NewRX Field
    $("#lblExistingRx").val("");
}

//----------------------------------------------Check Validation---------------------------------------------------

function CheckValidation() {
    debugger;
    if ($("#lblExistingRx").val() == "ExistingRx") {
        if ($("#txtMedicine").val().trim() == "") {
            alert("Enter Medicine.");
            $("#txtSearchMedicine").focus();
            return false;
        }
        SendPrescription();
    }
    else {
        if ($("#txtMedicine").val().trim() == "") {
            alert("Enter Medicine.");
            $("#txtSearchMedicine").focus();
            return false;
        }

        if ($("select[id$='ddlType']").val() == true) {
            if ($("input[id$='txtMedicineSubstance']").val() == "True") {
                alert("This medication is a controlled substance. It cannot be prescribed electronically.")
                return false;
            }
        }


        if ($("#txtPharmacy").val().trim() == "") {
            alert('Enter Pharmacy.');
            return false;

        }
        if ($("#txtPharmacy").val().trim() != "") {
            if ($("#lblncpdpid").val() == "") {
                alert('Pharmacy NCPDPID missing.');
                return false;
            }
        }

        if ($("#hovertxtSig").val() == "") {
            alert('Select Sig.');
            $("#hovertxtSig").focus();
            return false;

        }

        if ($("#txtQuantity").val().trim() == "") {
            alert('Enter Quantity.');
            $("#txtQuantity").focus();
            return false;

        }

        if ($("#hovertxtDaysSupply").val() == "0" || $("#hovertxtDaysSupply").val() == "") {
            alert("Days Supply must be greater than zero.");
            $("select[id$='ddlDyasSupply']").focus();
            return false;
        }

        if ($("select[id$='ddlMeasurement']").val() == "") {
            alert('Select Unit.');
            $("select[id$='ddlMeasurement']").focus();
            return false;
        }

        if ($("#txtDrugtoDrug").val() != "" && $("input[type='checkbox'][id$='chkOverriderAdverse']").is(':checked') == false) {
            alert('To continue with this medication, click the override warning box.');
            $("input[type='checkbox'][id$='chkOverriderAdverse']").focus();
            return false;
        }

        if ($("#txtDrugtoDisease").val() != "" && $("input[type='checkbox'][id$='chkOverriderAdverse']").is(':checked') == false) {
            alert('To continue with this medication, click the override warning box.');
            $("input[type='checkbox'][id$='chkOverriderAdverse']").focus();
            return false;
        }

        if ($("#txtDrugtoAllergy").val() != "" && $("input[type='checkbox'][id$='chkOverriderAdverse']").is(':checked') == false) {
            alert('To continue with this medication, click the override warning box.');
            $("input[type='checkbox'][id$='chkOverriderAdverse']").focus();
            return false;
        }

        if ($("select[id$='ddlMeasurement']").val() == "Not Specified") {
            if (!confirm("Measurement Unit is Not Specified.\n Press Cancel to Modify or OK to continue")) {
                $("select[id$='Measurement']").focus();
                return false;
            }
        }

        CheckPatientFields();
    }
}


//function CheckPatientFields() {
//    var request = "{'patientAccount':'" + GetQuerString("pa") + "'}"
//    $.ajax({
//        type: "POST",
//        url: "Prescription/PlanofCareMethod.aspx/GetPatient",
//        data: request,
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: retrievePatient
//    });
//}


function CheckPatientFields() {

    var index = 0;
    var patFname = $("input[id$='hdnpatFname']").val();
    var patLname = $("input[id$='hdnpatLname']").val();
    var patDOB = $("input[id$='hdnpatDOB']").val();
    var patGender = $("input[id$='hdnpatGender']").val();
    var patAddress = $("input[id$='hdnpatAddress']").val();
    var patCity = $("input[id$='hdnpatCity']").val();
    var patState = $("input[id$='hdnpatState']").val();
    var patZip = $("input[id$='hdnpatZip']").val();
    var patPhone = $("input[id$='hdnpatPhone']").val();
    if (patFname == "") {
        alert('Patient First name missing.');
        return false;
    }

    if (patLname == "") {
        alert('Patient last name missing.');
        return false;
    }
    if (patDOB == "") {
        alert('Patient date of birth  missing.');
        return false;
    }
    if (patDOB != "" && patLname != "" && patFname != "") {
        var strPatientLbl = "";
        if (patGender != "")
            strPatientLbl = patFname + ' ' + patLname + ', ' + GetQuerString("pat_acc") + ', ' + patGender + ', ' + patDOB;
        else
            strPatientLbl = patFname + ' ' + patLname + ', ' + GetQuerString("pat_acc") + ', ' + patDOB;
        
        $("span[id$='LblPatientNameAccount']").text(strPatientLbl.replace(/'/g, "`").replace(/\\/g, "\\\\"));
        $("span[id$='LblPatientAddress']").text(patAddress);
        
        var strCityState = "";
        var strComa = "";
        if (patCity != "")
            strComa = ", ";
        strCityState += patCity;
        if (patState != "")
            strCityState += strComa + patState;
        strComa = ", ";
        if (patZip != "")
            strCityState += " " + patZip;
        $("span[id$='LblPatZip']").text(strCityState);

        var phone = formatPhone(patPhone);
        if (phone != false)
            $("span[id$='LblPatientPhone']").text(phone);
        
        CheckProviderFields();
    }
}

function CheckProviderFields() {
    var request = "{'providerCode':'" + $("select[id$='ddlProvider_POC']").val().split("_")[1] + "'}";
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetProviders",
        data: request,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: retrieveProviders
    });
}
function retrieveProviders(data) {
    data = data.d;
    var index = 0;
    if (data.ListProviders[index].provLname == "") {
        alert('Provider last name missing.');
        return false;
    }
    if (data.ListProviders[index].provFname == "") {
        alert('Provider first name missing.');
        return false;
    }
    if (data.ListProviders[index].provAddress == "") {
        alert('Provider address missing.');
        return false;
    }
    if (data.ListProviders[index].provCity == "") {
        alert('Provider city  missing.');
        return false;
    }
    if (data.ListProviders[index].provState == "") {
        alert('Provider State  missing.');
        return false;
    }
    if (data.ListProviders[index].provZip == "") {
        alert('Provider Zip Code missing.');
        return false;
    }
    if (data.ListProviders[index].provPhone == "") {
        alert('Provider Phone No  missing.');
        return false;
    }
    if (data.ListProviders[index].provSPI == "") {
        alert('Provider SPI missing.');
        return false;
    }

    if (data.ListProviders[index].provLname != "" && data.ListProviders[index].provFname != "" && data.ListProviders[index].provAddress != ""
        && data.ListProviders[index].provCity != "" && data.ListProviders[index].provState != "" && data.ListProviders[index].provZip != ""
        && data.ListProviders[index].provPhone != "" && data.ListProviders[index].provSPI != "") {
        if (data.ListProviders[index].provTitle != "")
            $("span[id$='LblPrescriber']").text(data.ListProviders[index].provFname + ' ' + data.ListProviders[index].provLname + ', ' + data.ListProviders[index].provTitle);
        else
            $("span[id$='LblPrescriber']").text(data.ListProviders[index].provFname + ' ' + data.ListProviders[index].provLname);
        $("span[id$='lblSpi']").text('SPI: ' + data.ListProviders[index].provSPI);
        $("span[id$='LblPracAddress']").text(data.ListProviders[index].provAddress);
        var strCityState = "";
        var strComa = "";
        if (data.ListProviders[index].provCity != "")
            strComa = ", ";
        strCityState += data.ListProviders[index].provCity;
        if (data.ListProviders[index].provState != "")
            strCityState += strComa + data.ListProviders[index].provState;
        strComa = ", ";
        if (data.ListProviders[index].provZip != "")
            strCityState += " " + data.ListProviders[index].provZip;
        if ($("span[id$='LblZipCityState']").text() == "Default Practice Location")
            $("span[id$='LblZipCityState']").text(strCityState);
        var phone = formatPhone(data.ListProviders[index].provPhone);
        if (phone != "" || phone != null)
            $("span[id$='LblPrescPhone']").text(phone);
        CheckPharmacyFields();
    }
}
function CheckPharmacyFields() {
    
//    //$("span[id$='LblPharmacyName']").text($("input[id$='hdnPharName']").val() + ",");
//    $("span[id$='LblPharmacyAddress']").text($("input[id$='hdnPharAddress']").val());
//    $("span[id$='LblPharmacyZipCity']").text($("input[id$='hdnPharCity']").val() + ', ' + $("input[id$='hdnPharState']").val() + ' ' + $("input[id$='hdnPharZip']").val());
    $("span[id$='LblPharmacyNCPDPID']").text($("#lblncpdpid").val());
//    var phone = formatPhone($("input[id$='hdnPharPhone']").val());
//    if (phone != false)
//        $("span[id$='LblPharmacyPhone']").text(phone);


    var thedate = new Date();
    var theyear = thedate.getFullYear();
    var themonth = thedate.getMonth() + 1;
    if (themonth < 10)
        themonth = "0" + themonth;
    var theday = thedate.getDate();
    if (theday < 10)
        theday = "0" + theday;
    today = themonth + '/' + theday + '/' + theyear;

    $("span[id$='LblToDate']").text(today);
    $("span[id$='lblPracticeNameSummary']").text($("span[id$='lblPracticeName']").text().toUpperCase());
    $("span[id$='LblDrugName']").text($("#txtMedicine").val().trim());
    var strSig = $("#hovertxtSig").val();


    $("span[id$='LblSIG']").html(strSig.replace(/'/g, "`"));


    $("span[id$='LblQuantity']").text($("#txtQuantity").val().trim());
    $("span[id$='LblDispense']").text($("#hovertxtDaysSupply").val());
    $("span[id$='LblRefill']").text($("#hovertxtRefills").val());
    $("span[id$='LblDigCode']").text($("#txtDiagnosisCode").val());
    $("span[id$='LblDiagnosis']").text($("#txtDiagnosisDescription").val());
    if ($("#chkSubstitution").is(':checked') == true)
        $("span[id$='LblSubstitution']").text('No');
    else
        $("span[id$='LblSubstitution']").text('Yes');
    $("span[id$='lblmunit']").text($("select[id$='ddlMeasurement']").val());
    var notes = $("#txtProviderComments").val();

    $("span[id$='LblNotes']").html(notes);

    

    HideShowDiv("divNewRx", "divPrescriptionSummary");


}


function formatPhone(phoneNo) {
    if (phoneNo == "" || phoneNo == null)
        return false;
    var FormattedPhone = '(' + phoneNo.substring(0, 3) + ') ' + phoneNo.substring(6, 3) + '-' + phoneNo.substring(6);
    return FormattedPhone;
}

function HideDivs() {
    $("#divSearchMedicine").html('');
    $("#divSearchMedicine").hide();
    $("#divDiagnosisSearch").html('');
    $("#divDiagnosisSearch").hide();
}

//----------------------------------------------Print Medication--------------------------------------------------
function PrintMedication() {
    var request = "{'providerCode':'" + $("#ctl00_Charts1_ddlProvider").val() + "'}";
    $.ajax({
        type: "POST",
        url: "Prescription/PlanofCareMethod.aspx/GetProviders",
        data: request,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: PrintTable
    });
}

function PrintTable(response) {
    var response = response.d;
    var providerName = response.ListProviders[0].provFname + " " + response.ListProviders[0].provLname + ", " + response.ListProviders[0].provTitle;
    var spi = response.ListProviders[0].provSPI;
    var address = response.ListProviders[0].provAddress;
    var cityState = response.ListProviders[0].provCity + ", " + response.ListProviders[0].provState;
    var tbl = "<table style='width:900px; border-collapse:collapse;'><tr>";
    tbl += "<td style='width:65%;border-bottom:1px solid black;'>";
    tbl += "<table>";
    tbl += "<tr><td><b>" + $("[id$='lblPracticeName']").text() + "</b></td></tr>";
    tbl += "<tr><td><b>" + providerName + "</b></td></tr>";
    tbl += "<tr><td><b>SPI: </b>" + spi + "</td></tr>";
    tbl += "<tr><td>" + address + "</td></tr>";
    tbl += "<tr><td>" + cityState + "</td></tr>";
    tbl += "</table>";
    tbl += "</td>";
    tbl += "<td style='width:35%;border-bottom:1px solid black;' >";
    tbl += "<table><tr><td><b>" + $("input[id$='hdnpatLname']").val() + ", " + $("input[id$='hdnpatFname']").val() + "</b></td></tr><tr><td>" + $("input[id$='hdnpatGender']").val() + " <b>DOB: </b>" + $("input[id$='hdnpatDOB']").val() + "</td></tr><tr><td>" + $("input[id$='hdnpatAddress']").val() + "</td></tr><tr><td>" + $("input[id$='hdnpatCity']").val() + ", " + $("input[id$='hdnpatState']").val() + "</td></tr><tr><td><b>PH: </b>" + $("input[id$='hdnpatPhone']").val() + "<b> Acct: </b>" + GetQuerString("pat_acc") + "</td></tr></table>";
    tbl += "</td>";
    tbl += "</tr>";
    tbl += "<tr><td colspan='2'>&nbsp;</td></tr>";
    tbl += "<tr><td colspan='2'>";
    tbl += "<table style='border-collapse:collapse; width:900px;'>";
    tbl += "<tr><td style='border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>Sr.No</td><td style='border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>DRUG</td><td style='border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>SIG</td><td style='border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>QUANTITY</td><td style='border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>REFILL</td><td style='border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>PHARMACY</td><td style='border:1px solid Black;'>PHARMACY ADDRESS</td><td style='border:1px solid Black;'>Referring Physician</td></tr>";

    var medicationtoPrint = $("td[id^='Print'] :checked");
    if (medicationtoPrint.length == 0) {
        alert('Please select atleast one medication');
        return false;
    }
    else {
        for (var i = 0; i < medicationtoPrint.length; i++) {
            tbl += "<tr>";
            tbl += "<td style='padding-left:5px; border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>" + (parseInt(i) + 1) + "</td>";
            tbl += "<td style='padding-left:5px; border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>" + medicationtoPrint.eq(i).parent().siblings().eq(1).html() + "</td>";
            tbl += "<td style='padding-left:5px; border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>" + medicationtoPrint.eq(i).parent().siblings().eq(8).html() + "</td>";
            tbl += "<td style='padding-left:5px; border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>" + medicationtoPrint.eq(i).parent().siblings().eq(27).html() + "</td>";
            tbl += "<td style='padding-left:5px; border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>" + medicationtoPrint.eq(i).parent().siblings().eq(11).html() + "</td>";
            var pharmacy = medicationtoPrint.eq(i).parent().siblings().eq(14).html().split("[");
            tbl += "<td style='padding-left:5px; border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>" + pharmacy[0] + "</td>";
            tbl += "<td style='padding-left:5px; border-bottom:1px solid Black;border-top:1px solid Black;border-left:1px solid Black;'>" + pharmacy[1].replace("]", "") + "</td>";
            tbl += "<td style='padding-left:5px; border:1px solid Black;'>" + medicationtoPrint.eq(i).parent().siblings().eq(21).html() + "</td></tr>";
        }
    }

    tbl += "</table>";
    tbl += "</td></tr>";
    tbl += "</table>";


    var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
    disp_setting += "scrollbars=yes,width=850, height=800, left=100, top=25";

    var docprint = window.open("", "", disp_setting);
    docprint.document.open();
    docprint.document.write('<html><head><title>Printing Prescriptions</title>');
    docprint.document.write('</head><body onLoad="self.print();"><center>');
    docprint.document.write(tbl);
    docprint.document.write('</center></body></html>');

    docprint.document.close();
    docprint.focus();
}

//----------------------------------------------PLAN OF CARE  Histroy--------------------------------------------------
function tblMedicationsHistory(response) {

    var data = response.d;
    var tbl = "";
    var isflagnorecrd = false;
    tbl += "<table id='tblHistory'  class='gridtable'><tbody><tr><th>&nbsp;</th><th>Modified Date</th><th>Modified By</th><th>Prescription Date</th><th>Medicine</th><th>Sig</th><th>Diagnose Code</th><th>Diagnose Description</th><th>Days Supply</th><th>Refill</th><th>Patient Instruction</th><th>Provider</th><th>Active</th><th>Pharmacy Instruction</th><th>Prescription Type</th><th>Pharmacy</th><th>RX Status</th><th>Comments</th><th>Override Adverse</th><th>Override Reason</th><th>Is Confidential</th><th>Created By</th><th>Date Dispensed</th><th>Date Discard</th><th>Date Expire</th><th>Complete</th><th>Reviewed</th><th>Review By</th><th>Review Date</th><th>Event Date</th><th>Event Time</th><th>Event Type</th></tr>";
    $("#divChartHistory").html('');
    if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {

            tbl += "<tr>";
            tbl += "<td></td>";
            tbl += "<td>" + convertDatetoString(data[i].MODIFIED_DATE, 2) + "</td>";
            tbl += "<td>" + data[i].MODIFIED_BY + "</td>";
            tbl += "<td>" + convertDatetoString(data[i].PRESCRIPTION_DATE,2) + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].MEDICINE_TRADE + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].SIG + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].DIAGNOSE + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].DIAG_DESCRIPTION + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].DISPENSE + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].REFILL + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].ADVICE + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].PROVIDER_NAME + "</td>";
            if (data[i].ACTIVE == true) {
                tbl += "<td align='center'><input type='checkbox' checked='checked' disabled='disabled'/></td>";
            }
            else {
                tbl += "<td align='center'><input type='checkbox' disabled='disabled'/></td>";
            }
            tbl += "<td style='white-space:nowrap;'>" + data[i].NOTES_PHARMACY + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].PRESCRIPTION_TYPE + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].PHARMACY_DESCRIPTION + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].STATUS + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].PROVIDER_INSTRUCTION + "</td>";
            if (data[i].OVERRIDE_ADVERSE == true) {
                tbl += "<td align='center'><input type='checkbox' checked='checked' disabled='disabled'/></td>";
            }
            else {
                tbl += "<td align='center'><input type='checkbox' disabled='disabled'/></td>";
            }
            tbl += "<td style='white-space:nowrap;'>" + data[i].OVERRIDE_REASON + "</td>";

            if (data[i]. IS_CONFIDENTIAL == true) {
                tbl += "<td align='center'><input type='checkbox' checked='checked' disabled='disabled'/></td>";
            }
            else {
                tbl += "<td align='center'><input type='checkbox' disabled='disabled'/></td>";
            }
            tbl += "<td style='white-space:nowrap;'>" + data[i].CREATED_BY + "</td>";
            tbl += "<td style='white-space:nowrap;'>" +convertDatetoString( data[i].DATE_DISPENSED,2) + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + convertDatetoString(data[i].DATE_DISCARD,2) + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + convertDatetoString(data[i].DATE_EXPIRE, 2) + "</td>";
            if (data[i].COMPLETE == true) {
                tbl += "<td align='center'><input type='checkbox' checked='checked' disabled='disabled'/></td>";
            }
            else {
                tbl += "<td align='center'><input type='checkbox' disabled='disabled'/></td>";
            }
            if (data[i].PRESCRIPTION_REVIEWED == true) {
                tbl += "<td align='center'><input type='checkbox' checked='checked' disabled='disabled'/></td>";
            }
            else {
                tbl += "<td align='center'><input type='checkbox' disabled='disabled'/></td>";
            }
            tbl += "<td style='white-space:nowrap;'>" + data[i].PRESCRIPTION_REVIEW_BY + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + convertDatetoString(data[i].PRESCRIPTION_REVIEW_DATE, 2) + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].EVENT + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].EVENT_TIME + "</td>";
            tbl += "<td style='white-space:nowrap;'>" + data[i].EVENT_TYPE + "</td>";
            tbl += "</tr>";
        }
        tbl += "</tbody></table>";
    }
    else {
        isflagnorecrd = true;
    }
    $("#divChartHistory").append(tbl);
    if (isflagnorecrd) {
        var colspan = $("#tblHistory th").length;
        $("#tblHistory tbody").append("<tr><td colspan=" + colspan + " class='noRecordfound'>No Record Found.</td></tr>");
    }
    if (data.length > 0)
    GenerateSrNumberWithWhiteRow('tblHistory', '1', '1');
    $("#divmodePop_ShowChartHistory").jqm({ overlay: 50, modal: true, trigger: false });
    $("#divmodePop_ShowChartHistory").jqmShow();
}

//----------------------------------------------Set Prescription Inactive--------------------------------------------------

function ChkActive_CheckChanged(rowID) {
   
    var prescriptionID = $("#tblPOC tr#row" + rowID + " td:nth-child(30)").html();
    if (prescriptionID != "") {
        var CheckBoxStatus = $("#tblPOC tr#row" + rowID + " td:nth-child(11) input:checkbox").is(":checked");
        if (CheckBoxStatus == true) {
            if (confirm('Do you want to activate this medication?')) {
                $.ajax({
                    type: "POST",
                    url: "Prescription/PlanofCareMethod.aspx/UpdateActiveBit",
                    data: "{'setActive':'" + CheckBoxStatus + "','strPrescriptionID':'" + prescriptionID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: GetPatientPrescription
                });
            }
            else {
                $("#tblPOC tr#row" + rowID + " td:nth-child(11) input:checkbox").attr("checked", false);
                return false;
            }
        }
        else {
            if (confirm('Do you want to deactivate this medication?')) {
                $.ajax({
                    type: "POST",
                    url: "Prescription/PlanofCareMethod.aspx/UpdateActiveBit",
                    data: "{'setActive':'" + CheckBoxStatus + "','strPrescriptionID':'" + prescriptionID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: GetPatientPrescription
                });
            }
            else {
                $("#tblPOC tr#row" + rowID + " td:nth-child(11) input:checkbox").attr("checked", true);
                return false;
            }

        }

    }

}


//----------------------------------------------Clear Firelds------------------------------------------------------------

function ClearDoseCalculator() {
    $("#txtDose").val('');
    $("#ddlMeasurement").val('');
    $("#txtWeight").val('');
    $("#txtWeightKg").val('');
    $("#txtResult").val('');
}

function ClearAdvanceSearch() {
    $("#txtPharmacyName").val('');
    $("#txtPharmacyCity").val('');
    $("#ddlPharmacyState").val('');
    $("#txtPharmacyZip").val('');
    $("#txtPharmacyPhone").val('');
    $("#txtPharmacyFax").val('');
    $("#txtPharmacyAddress").val('');
}

function ClearDiagnose() {
    $("#txtDiagnosisCode").val('');
    $("#txtDiagnosisDescription").val('');
}

function ClearMedicine() {
    $("#txtMedicine").val('');
}

function ClearPharmacy() {
    $("#txtPharmacy").val('');
}


function ShowAdvanceSig() {
    $("#trAdvanceSig").slideToggle();
}


//----------------------------------------------Advance Sig Builder-----------------------------------------------------

function SetSig() {
    var sigValue = $("select[id$='ddlVerb']").val() + ' ';
    sigValue += $("#txtFactor").val() + ' ';
    sigValue += $("select[id$='ddlForm']").val() + ' ';
    sigValue += $("select[id$='ddlRoute']").val() + ' ';
    sigValue += $("select[id$='ddlFrequency']").val() + ' ';
    sigValue += $("select[id$='ddlMod']").val();
    $("select[id$='ddlSig']").append($("<option></option>").attr({ "value": sigValue, "selected": "selected" }).text(sigValue));
    $("#hovertxtSig").val(sigValue);
}


//----------------------------------------------------------------------------------------------------------------------



function DeletePrescription(prescriptionID) {
    //var prescriptionID = $("#tblPOC tr#row" + rowId + " td:nth-child(30)").html();
    var patientAccount = GetQuerString("pat_acc");
    if (confirm("Are you sure you want to delete the selected record?")) {
        if (prescriptionID != "") {
            $.ajax({
                type: "POST",
                url: "Prescription/PlanofCareMethod.aspx/DeletePrescription",
                data: "{'patientAccount':'" + patientAccount + "','prescriptionId':'" + prescriptionID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: GetPatientPrescription
            });
        }
    }
}

//----------------------------------------------------------------------------------------------------------------------

function DrugHistory() {
    
    var table = "<table style='white-space:nowrap;' width='100%' cellspacing='0' cellpadding='0' border='0' class='review-block-right-panel' id='drughistoryPrescription'>";
    table += '<tr ><td colspan="9" valign="top" align="left"><div width="100%" class="review-blue-block-normal"><div class="review-blue-block-normal"><label><input type="radio" onclick="DrugHistoryRowsVisibiltyStatus(this.value)" checked="checked" name="radiobutton" value="All">All</label><label><input type="radio" onclick="DrugHistoryRowsVisibiltyStatus(this.value)" name="radiobutton" value="Current">Current</label><label><input type="radio" onclick="DrugHistoryRowsVisibiltyStatus(this.value)" name="radiobutton" value="Past">Past</label></tr>';
    table += "<tr valign='middle' align='center' class='review-subtitle gre-whitegrey'><th>Prescriptiion Date</th><th>Physician</th><th>Medicine</th><th>Sig</th><th>Qty</th><th>Refills</th><th>Pharmacy</th><th style='display:none;'>Active</th</tr>";
    $("#tblPOC tr:gt(1)").each(function () {
        table += "<tr id='" + $(this).attr('id') + "' style='line-height:20px;'><td class='review-block-right-border review-block-right-pad'>" + $(this).children().eq(6).html() + "</td><td class='review-block-right-border review-block-right-pad'>" + $(this).children().eq(22).html() + "</td><td class='review-block-right-border review-block-right-pad'>" + $(this).children().eq(2).html() + "</td><td class='review-block-right-border review-block-right-pad'>" + $(this).children().eq(9).html() + "</td><td class='review-block-right-border review-block-right-pad'>" + $(this).children().eq(28).html() + "</td><td class='review-block-right-border review-block-right-pad'>" + $(this).children().eq(12).html() + "</td><td class='review-block-right-border review-block-right-pad'>" + $(this).children().eq(15).html() + "</td><td class='review-block-right-border review-block-right-pad' style='display:none;'>" + $(this).children().eq(10).html() + "</td></tr>";
    });
    table += "</table>";

    $("#divPrescriptionHistory").html(table);
    var ctrlPath = "~/WEBEHR/Controls/ExternalDrugHistory.ascx";
    var divID = "DrugHistory";
    var chartID = GetQuerString("ChartID");
    var patAct = GetQuerString("pat_acc");
    var chartDate = GetQuerString("ChartDate");

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "Charts.aspx/GetControlHtmlParam",
        data: "{'controlLocation':'" + ctrlPath + "','chartID':'" + chartID + "','patAct':'" + patAct + "','chartDate':'" + chartDate + "'}",
        success: function (msg) {
            $('#' + divID).html(msg.d); 
            $("#DrugHistory").find("h2").remove();
            $("#DrugHistory").find(".ft").remove();
        },
        error: function () {
            alert("error Occured in load Control!");
        }
    });

    HideShowDiv("", "divDrugHistory");
}

//----------------------------------------------------------------------------------------------------------------------
function HideAdvanceOption() {
    $("#ShowAdvance").show()
    $("#DrugWarnings").show()
    $("#AdvanceOption").hide()
}
function ShowAdvanceOption() {
    $("#ShowAdvance").hide()
    $("#DrugWarnings").hide()
    $("#AdvanceOption").show()
}

//function AddSig(value) {
//    if ($.trim(value) != '') {
//        //if ($("select[id$='ddlSig']").text().indexOf(value) == -1)
//        $("select[id$='ddlSig']").append($('<option></option>').attr({ 'value': value, 'selected': 'selected' }).text(value));
//    }
//}

//---------------------------------------------------- Drug Education ------------------------------------------------------

function GetDrugEducation() {
    debugger;
    //HideShowDiv("divNewRx", "divDrugEducation");
    if ($("#txtMedicine").val().trim() != '') {
        $("#divFrame").html("<iframe id='DrugEducationFrame' src='Prescription/DrugEducation.aspx?ndcCode=" + $("#lblMedicineNdc").val() + "&medName=" + $("#txtMedicine").val().trim() + "' style='width:100%; height:100%;'></iframe>");
        // ($("#DrugEducationFrame").contents().find('#lblRecordFound').text() != '') {
        //alert('No Record Found');
        //HideShowDiv("divDrugEducation", "divNewRx");
        //}
        //else
            HideShowDiv("divNewRx", "divDrugEducation");
    }
    else
        alert('Enter Medicine');
}


//-------------------------------------------------------