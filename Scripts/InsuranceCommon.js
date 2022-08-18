
var _InsuranceTypeMaster;
var _IconInsurance;
var _InsuranceFormCallFrom;

function LoadInsuranceDialog(elem) {
    debugger;
    _IconInsurance = $(elem);
    
    $.post("../../ProviderPortal/Controls/InsuranceSearch.aspx", {}, function (data) {
        var start = data.indexOf("###StartInsuranceSearch###") + 26;
        var end = data.indexOf("###EndInsuranceSearch###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#InsuranceSearchBox").html(returnHtml)
        .promise()
        .done(function () {
            $("#InsuranceSearchBox").dialog({
                modal: true,
                title: 'Search Insurance',
                width: '900'
            });
        });
        
        GeneratePaging($("[id$='hdnTotalRowsINS']").val(), $("#ddlPagingInsurance").val(), "InsuranceSearchBox", "FilterInsurance");
        
        if ($("[id$='hdnTotalRowsINS']").val() > 0) {
            $("#InsuranceSearchBox .spanInfo").html("Showing " + $("#ShowInsuranceResult tr:first").children().first().html() + " to " + $("#ShowInsuranceResult tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsINS']").val() + " entries");
        }
    });
}

function GetInsuranceName(elem) {
    var InsuranceId = $(elem).closest("tr").find(".insuranceName").attr('id');
    var InsuranceName = $.trim($(elem).closest("tr").find(".insuranceName").html());
    
    _IconInsurance.parent().find(".hdnInsuranceId").val(InsuranceId);
    _IconInsurance.parent().find(".txtInsuranceName").val(InsuranceName);
    
    $("#InsuranceSearchBox").dialog("close");
}

function PatientInsurance_OpenForm(params) {
    debugger;
    $.post("../../ProviderPortal/Controls/PatientInsurance.aspx", params, function (data) {
        var start = data.indexOf("###StartForm###") + 15;
        var end = data.indexOf("###EndForm###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#divDialogPatientInsurance").html(returnHtml)
        .promise()
        .done(function () {
            debugger;
            PatientInsurance_OpenForm_Done();
        });
    });
}

function PatientInsurance_OpenForm_Done() {
    debugger
    $("#divDialogPatientInsurance .date").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");
    
    $("#divDialogPatientInsurance").dialog({
        modal: true,
        title: "Patient Insurance",
        width: "auto",
        close: function () {
            $(this).dialog("destroy");
        }
    });
}