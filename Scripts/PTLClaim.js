


function Initialize_PTL_Claim() {
    $("[id$='txtDateOfServiceFilterClaim'], [id$='txtBillDateFilterClaim']").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "1950:2050",
        onSelect: function () {
            RowsChange('FilterClaims');
        }
    }).mask("99/99/9999");
    
    GeneratePaging($("[id$='hdnTotalRowsClaim']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");
    
    if ($("[id$='hdnTotalRowsClaim']").val() > 0) {
        $("#divClaims .spanInfo").html("Showing " + $("#tbodyPTLClaim tr:first").children().first().html() + " to " + $("#tbodyPTLClaim tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsClaim']").val() + " entries");
    }
}

function FilterClaims(pageNumber, paging) {
    var ClaimId = $.trim($("[id$='txtClaimNoFilterClaim']").val());
    var PatientId = $.trim($("[id$='txtPatientAccountFilterClaim']").val());
    var PatientName = $.trim($("[id$='txtPatientNameFilterClaim']").val());
    var DateOfService = $.trim($("[id$='txtDateOfServiceFilterClaim']").val());
    var BillDate = $.trim($("[id$='txtBillDateFilterClaim']").val());
    var InsuranceId = $.trim($("[id$='ddlInsuranceFilterClaim']").val());
    var SubmissionStatusId = $.trim($("[id$='ddlSubmissionStatusFilterClaim']").val());
    var IsPTL = true;
    var PTLReasons = GetPTLReasons("ulPTLReasonFilterListClaim");
    
    var params = {
        ClaimId: ClaimId,
        PatientId: PatientId,
        PatientName: PatientName,
        DateOfService: DateOfService,
        BillDate: BillDate,
        InsuranceId: InsuranceId,
        SubmissionStatusId: SubmissionStatusId,
        IsPTL: IsPTL,
        PTLReasons: PTLReasons,
        Rows: $("#ddlPagingClaims").val(),
        PageNumber: pageNumber,
        action: "ClaimFilter"
    };
    
    $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartPTLFilterClaim###") + 25;
        var end = data.indexOf("###EndPTLFilterClaim###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#tbodyPTLClaim").hide();
        
        $("#tbodyPTLClaim").html(returnHtml)
        .promise()
        .done(function () {
            SetPTLReasons("Claim");
            $("#tbodyPTLClaim").show();
        });
        
        var startRowsCount = data.indexOf("###StartRowsCountClaim###") + 25;
        var endRowsCount = data.indexOf("###EndRowsCountClaim###");
        $("[id$='hdnTotalRowsClaim']").val($.trim(data.substring(startRowsCount, endRowsCount)));
        
        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsClaim']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");
        }
        
        if ($("[id$='hdnTotalRowsClaim']").val() > 0) {
            $("#divClaims .spanInfo").html("Showing " + $("#tbodyPTLClaim tr:first").children().first().html() + " to " + $("#tbodyPTLClaim tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsClaim']").val() + " entries");
        }
    });
}


function GetPTLReasons(ReasonUl) {
    var strPTLReasons = "";

    $("#" + ReasonUl + " .chkReason:checked").each(function () {
        strPTLReasons += $(this).parent().find(".hdnPTLReasonsId").val() + ",";
    });

    if (strPTLReasons.length > 1) {
        strPTLReasons = strPTLReasons.slice(0, -1);
    }

    return strPTLReasons;
}