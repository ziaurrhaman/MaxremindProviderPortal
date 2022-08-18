
$(document).ready(function () {
    if (!checkModuleRights("InsuranceEnrollment")) { $(".tdaction").hide(); }
    GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingenrollment").val(), "divEnrolllment", "FilterInsuranceEnrollment");
    if ($("[id$='hdnTotalRows']").val() > 0) {
        $("#divEnrolllment .spanInfo").html("Showing " + $("#tbInsuranceEnrollment tr:first").children().first().html() + " to " + $("#tbInsuranceEnrollment tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
    }



});

function AddUpdateNewInsuranceEnrollment(params) {
    $.post(_EMRPath + "/InsuranceEnrollment/CallBacks/AddUpdateEnrollmentHandler.aspx", { Action: 'AddUpdateForm' },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###startAddupdateEnrollment###") + 30;
        var end = data.indexOf("###endAddupdateEnrollment###");
        $(".divAddUpdateEnrollmentDiv").html(returnHtml.substring(start, end));
        openDialogueAddUpdateEnrollment(params);
    });
}

function openDialogueAddUpdateEnrollment(params) {

    $(".divAddUpdateEnrollmentDiv").dialog({
        resizable: false,
        title: "Add/Update",
        height: 300,
        width: 900,
        modal: true,
        buttons: {
            'Add/Update': function () {
                var result = CheckRequriedFields();
                if (result == 0) {
                    GetEnrollmentInformation();
                    $(this).dialog("destroy");
                }

            },
            Cancel: function () {
                $(this).dialog("destroy");
            }

        },
        open: function () { if (params != 'New') FillInsuranceEnrollmentUpdateForm(params); }
    });
}

function SerachInsuranceDropDownList(elem) {

    var a = event.which || event.keyCode;
    if (elem == undefined) {
        elem = $(".txtInsurance");
    }
    debugger;
    var InsuranceName = $.trim($(elem).val()) || "";
    if (InsuranceName == "") { $(".divInsuranceserach").hide(); return };
    if (a == 13 || a == 1) {

        $.post(_EMRPath + "/InsuranceEnrollment/CallBacks/AddUpdateEnrollmentHandler.aspx", { Action: "SearchInsurance", insuranceName: InsuranceName }, function (data) {

            var start = data.indexOf(" ###startSearchInsurance###") + 29;
            var end = data.indexOf(" ###endSearchInsurance###");
            var result = data.substring(start, end);
            $(".divInsuranceserach").html(result);

            var len = $(".divInsuranceserach").find(".tdInsuranceSearch").find('tr').length;
            if (len == 0) {
                $("divInsuranceserach").html("<span  style='background-color:white;color:red;padding:10px'>no record find!<span>");
            }

            $(".divInsuranceserach").show();


        });

    }

}

function selectInsurance(elem) {
    var insuranceid = $.trim($(elem).find(".spninsuranceId").text());
    var insuranceName = $.trim($(elem).find(".tdname").text());

    $("#hdnInsuranceId").val(insuranceid);
    $(".txtInsurance").val(insuranceName);
    $(".divInsuranceserach").hide();
}

function GetEnrollmentInformation() {

    var insuranceId = $("#hdnInsuranceId").val();
    var Claimstatus = $("#ddlClaimES").val();
    var Erasstatus = $("#ddlEraES").val();
    var Eligibilitystatus = $("#ddlEligibilityES").val();
    var insuranceEnrollmentId = $(".hdnInsuranceEnrollmentId").val() || 0;
    var notes = $.trim($("#taNotes").val());
    var InsuranceEnrollments = new Object();
    InsuranceEnrollments.InsuranceEnrollmentId = insuranceEnrollmentId;
    InsuranceEnrollments.InsuranceId = insuranceId;
    InsuranceEnrollments.ClaimStatusId = Claimstatus;
    InsuranceEnrollments.ERAStatusId = Erasstatus;
    InsuranceEnrollments.EligibilityStatusId = Eligibilitystatus
    InsuranceEnrollments.Notes = notes;
    SendAddUpdateEnrollmentInsuranceInfo(InsuranceEnrollments);
    return InsuranceEnrollments;

}

function SendAddUpdateEnrollmentInsuranceInfo(objInsuranceEnrollments) {
    var insuranceEnrollments = objInsuranceEnrollments;
    $.post(_EMRPath + "/InsuranceEnrollment/CallBacks/AddUpdateEnrollmentHandler.aspx", { Action: "Add/Update", InsuranceEnrollments: JSON.stringify(insuranceEnrollments) }, function (data) {

        FilterInsuranceEnrollment(0, true);
    });
}

function FilterInsuranceEnrollment(Pagenumber, paging) {

    var payerid = $(".txtpayerid").val();
    var insurancename = $(".txtinsurancename").val();
    //var claims = $(".txtclaims").val();
    //var eligibiliity = $(".txtEligibililty").val();
    //var eras = $(".txtEras").val();
    var rows = $("#ddlPagingenrollment").val();
    var parms = {
        rows: rows,
        page: Pagenumber,
        payerid: payerid,
        insurancename: insurancename,
        //claims: claims,
        //eligibiliity: eligibiliity,
        //eras: eras,
        Action: 'Reload'
    }

    $.post(_EMRPath + "/InsuranceEnrollment/CallBacks/InsuranceEnrollmentHandler.aspx", parms, function (data) {

        var start = data.indexOf("###startInsuranceEnrollmentGird###") + 35;
        var end = data.indexOf("###EndInsuranceEnrollmentGird###");
        var result = data.substring(start, end);
        $(".tbInsuranceEnrollment").html(result);

        start = data.indexOf("###StarttotalRows###") + 20;
        end = data.indexOf("###EndtotalRows###");
        result = data.substring(start, end);

        $(".divtotalrows").html(result);
        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingenrollment").val(), "divEnrolllment", "FilterInsuranceEnrollment");
        }
        if ($("[id$='hdnTotalRows']").val() > 0) {
            $("#divEnrolllment .spanInfo").html("Showing " + $("#tbInsuranceEnrollment tr:first").children().first().html() + " to " + $("#tbInsuranceEnrollment tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        }


    });

}

function SetSearchIE(event) {

    var a = event.which || event.keyCode;
    if (a == 13) {
        if ($("#FilterIcon").hasClass("active")) {
            FilterInsuranceEnrollment(0, true);
        }
    }
    else {
        $("#FilterIcon").addClass("active");
    }

}

function btnDeleteClick(elem) {
    var InsuranceEnrollmentId = $.trim($(elem).closest('tr').find(".spnInsuranceEnrollmentId").text());
    var Params = {
        InsuranceEnrollmentId: InsuranceEnrollmentId,
        Message: "Are you sure to remove this Enrollment Insurance !",
        CallFrom: 'DeleteEnrollment'
    }
    showConfirmationMessage(Params);

}

function showConfirmationMessage(Params) {
    $(".divMessage").html("<span>" + Params.Message + "</span>");
    $(".divMessage").dialog({
        resizable: false,
        title: "Confirmation!",
        height: 100,
        width: 400,
        modal: true,
        buttons: {
            Yes: function () {
                if (Params.CallFrom == "DeleteEnrollment") { DeleteEnrollment(Params.InsuranceEnrollmentId); }
                $(this).dialog("destroy");
            },
            No: function () {
                $(this).dialog("destroy");
            }

        },
    });
}

function DeleteEnrollment(InsuranceEnrollmentId) {

    $.post(_EMRPath + "/InsuranceEnrollment/CallBacks/AddUpdateEnrollmentHandler.aspx", { Action: 'delete', InsuranceEnrollmentId: InsuranceEnrollmentId }, function () {
        FilterInsuranceEnrollment(0, true);
    });
}

function btnEditClick(elem) {
    var InsuranceEnrollmentId = $.trim($(elem).closest('tr').find('.spnInsuranceEnrollmentId').text());
    var InsuranceId = $.trim($(elem).closest('tr').find('.spnInsuranceId').text());
    var InsuranceName = $.trim($(elem).closest('tr').find('.tdInsuranceName').text());
    var ClaimStatusId = $.trim($(elem).closest('tr').find('.spnClaimStatusId').text());
    var EligibbilityStatusId = $.trim($(elem).closest('tr').find('.spnEligibilityStatusId').text());
    var ERAsStatusId = $.trim($(elem).closest('tr').find('.spnERAStatusId').text());
    var Notes = $.trim($(elem).closest('tr').find('.spnnotes').text()) || "";
    debugger;
    var params = {
        InsuranceEnrollmentId: InsuranceEnrollmentId
        , InsuranceId: InsuranceId
        , InsuranceName: InsuranceName
        , ClaimStatusId: ClaimStatusId
        , EligibbilityStatusId: EligibbilityStatusId
        , ERAsStatusId: ERAsStatusId
        , Notes: Notes
    };
    AddUpdateNewInsuranceEnrollment(params);


}

function FillInsuranceEnrollmentUpdateForm(Params) {
    $(".divAddUpdateForm").find(".hdnInsuranceEnrollmentId").val(Params.InsuranceEnrollmentId);
    $(".divAddUpdateForm").find("#hdnInsuranceId").val(Params.InsuranceId);
    $(".divAddUpdateForm").find(".txtInsurance").val(Params.InsuranceName);
    $(".divAddUpdateForm").find("#ddlClaimES").val(Params.ClaimStatusId);
    $(".divAddUpdateForm").find("#ddlEligibilityES").val(Params.EligibbilityStatusId);
    $(".divAddUpdateForm").find("#ddlEraES").val(Params.ERAsStatusId);
    $(".divAddUpdateForm").find("#taNotes").val(Params.Notes);
}

function CheckRequriedFields() {
    var fieldcount = 0;
    $(".divAddUpdateForm").find(".required:visible").each(function () {
        var val = $(this).val() || "";

        if (val == "") {
            fieldcount++;
            $(this).css("border", "1px solid red");

        }
        else {
            $(this).css("border", "1px solid #c4c4c4");
        }
        var IsInsurance = $("#hdnInsuranceId").val() || 0;
        if (IsInsurance == 0) {
            fieldcount++;
            $(".txtInsurance").css("border", "1px solid red");
        }
    });

    return fieldcount;
}

function ShowInsuranceEnrollment() {
        debugger;
        if (!checkModuleRights("EDIERAUser")) {
            $("[id$='divRightsSettings']").html("You don't have rights to View EDI ERA User").show();
            $("#divUsers").hide();
            $("#UserRolesDiv").hide();
            $("#divTicketing").hide();
            $("#divUsersMain").hide();
            $("#divInsuranceCredentialingWrapperId").hide();
            return false;
    }
    $("#title").html('EDI/ERA User');
    $("#divRightsSettings").hide();
    $.post("/ProviderPortal/InsuranceEnrollment/InsuranceEnrollment.aspx", function (data) {
        debugger
        var start = data.indexOf("###StartInsuEnrollment###") + 27;
        var end = data.indexOf("###EndInsuEnrollment###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divInsuranceEnrollment").html(returnHtml);
        $("#divUsers").hide();
        $("#UserRolesDiv").hide();
        $("#divTicketing").hide();
        $("#divUsersMain").hide();
        $("#divInsuranceCredentialingWrapperId").hide();
        $("#divInsuranceEnrollment").css("display", "block");
    });
}