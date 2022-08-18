//Created by Khayyam Adeel desc:Control DashboardRPM.aspx

//these Function are defined in Claim.js but can not be reused because Post request get a differnt directory Path, 
//So it is defined again here 

var SORTBY = '';
var _insuranceddlId = "";
var dateFrom = '';
var dateTo = '';
$(document).ready(function () {
    //READ-ME.txt
    //Multiple If Condition are used :desc => Reports page k lia bhoat c jago sy data redirect kia ja ra ha,
    //For example:
    //if we click on Reports data or report should show , but if we click on claim in Deshboard , then it should also display claim data
    //in reports
    //same for CPTCode and Patient;
    //Custom css and show.hide is used to tackle situation of click event;

    //$(".btnAllReportsRPM").click(function () {
    //        this.css("background-color", "#006291");
    //    });
    $("#div-DashBoard").css("background-color", "#EEEFEF");
    $("#_dashboardRPM").addClass("active");

    $("[id$='txtDateOfBirth']").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        yearRange: "-110:+0",
        onSelect: function (date, obj) {
            RowsChange('FilterPatientRPM');
        }
    }).mask("99/99/9999");

    $("[id$='txtDateOfService'] , [id$='txtBillDate']").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        yearRange: "-110:+0",
        onSelect: function (date, obj) {
            RowsChange('FilterClaimsRPM');
        }
    }).mask("99/99/9999");
});

function getData(link, CPTCode, Criteria) {

    if (link == "DashBoard" && Criteria == '' && CPTCode == '') {
        debugger;
      
        $("#dashboard").show();
        $("#ClaimRPM").hide();
        $("#PatientRPM").hide();
        $("#divReports").hide();
        $("#Reports").hide();
        $("#AllReportsRPM").hide();
        $("#div-DashBoard").css("background-color", "#EEEFEF");
        //remove css
        $("#div-Claim").css("background-color", "#FFFFFF");
        $("#div-Pat").css("background-color", "#FFFFFF");
        $("#div-Reports").css("background-color", "#FFFFFF");
    }
    if (link == "Reports" && Criteria == '' && CPTCode == '') {
        debugger;
        $("#dashboard").hide();
        $("#ClaimRPM").hide();
        $("#PatientRPM").hide();
        $("#btnClaimReportsRPM").addClass("ActiveBtn");
        $("#Reports").hide();
        $("#AllReportsRPM").show();
        $("#divAllReportsRPM").show();
        $("#div-Reports").css("background-color", "#EEEFEF");
        //remove css
        $("#div-Claim").css("background-color", "#FFFFFF");
        $("#div-Pat").css("background-color", "#FFFFFF");
        $("#div-DashBoard").css("background-color", "#FFFFFF");
        debugger
        $.post("../ProviderPortal/PatientClaimCPT_wiseRecord.aspx", {
            CPTCode: '',
            Criteria: 'Claim'

        }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartClaim_wiseRecord###") + 37;
            var end = data.indexOf("###EndClaim_wiseRecord###");
            $("#Reports").html(returnHtml.substring(start, end));

        }).done(function () {
            $("#Reports").show();
            $("#ReportsRPM").hide();
            $("#divReports").hide();
            $("#dashboard").hide();
            $("#ClaimRPM").hide();
            $("#PatientRPM").hide();
            $("#div-Reports").css("background-color", "#EEEFEF");

            //remove css
            $("#div-Claim").css("background-color", "#FFFFFF");
            $("#div-Pat").css("background-color", "#FFFFFF");
            $("#div-DashBoard").css("background-color", "#FFFFFF");
            $("#btnPatietReportsRPM").removeClass("ActiveBtn");
           //$("#btnClaimReportsRPM").removeClass("ActiveBtn");
            $("#btnProcedureReportsRPM").removeClass("ActiveBtn");
        });
        
    }
    if (link == "Claim" && Criteria == '' && CPTCode == '') {
        dateFrom = "";
        $("#ddlPagingClaims").val("10");
        dateTo = "";
        FilterClaimsRPM(0, true);
        debugger;
        $("#dashboard").hide();
        $("#ClaimRPM").show();
        $("#PatientRPM").hide();
        $("#ReportsRPM").hide();
        $("#Reports").hide();
        $("#AllReportsRPM").hide();
        
       
        $("#div-Claim").css("background-color", "#EEEFEF");
        //Remove css
        $("#div-Pat").css("background-color", "#FFFFFF")
        $("#div-Reports").css("background-color", "#FFFFFF")
        $("#div-DashBoard").css("background-color", "#FFFFFF")

        GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaimsRPM");

        if ($("[id$='hdnClaimsCount']").val() > 0) {
            $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
        }
    }
    if (link == "Claim" && Criteria == 'DateFilter' && CPTCode == '') {
        dateFrom = $("[id$='txtReportDateFrom']").val();
        dateTo = $("[id$='txtReportDateTo']").val();
        FilterClaimsRPM(0, true);
        debugger;
        $("#dashboard").hide();
        $("#ClaimRPM").show();
        $("#PatientRPM").hide();
        $("#ReportsRPM").hide();
        $("#Reports").hide();
        $("#AllReportsRPM").hide();


        $("#div-Claim").css("background-color", "#EEEFEF");
        //Remove css
        $("#div-Pat").css("background-color", "#FFFFFF")
        $("#div-Reports").css("background-color", "#FFFFFF")
        $("#div-DashBoard").css("background-color", "#FFFFFF")

        GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaimsRPM");

        if ($("[id$='hdnClaimsCount']").val() > 0) {
            $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
        }
    }
    if (link == "Pat" && Criteria == '' && CPTCode == '') {
        debugger;
        dateFrom = "";
        dateTo = "";
        $("#ddlPagingPatient").val("10");
        FilterPatientRPM(0, true);
        $("#dashboard").hide();
        $("#ClaimRPM").hide();
        $("#divReports").hide();
        $("#ReportsRPM").hide();
        $("#Reports").hide();
        $("#AllReportsRPM").hide();
        
        $("#PatientRPM").show();
        $("#div-Pat").css("background-color", "#EEEFEF");
        //remove css
        $("#div-Reports").css("background-color", "#FFFFFF")
        $("#div-DashBoard").css("background-color", "#FFFFFF")
        $("#div-Claim").css("background-color", "#FFFFFF")

        GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatientRPM");
        if ($("[id$='hdnTotalRows']").val() > 0)
            $("#PatientContainer .spanInfo").html("Showing " + $("#patientList tr:first").children().first().html() + " to " + $("#patientList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
    }
    if (link == "Pat" && Criteria == 'DateFilter' && CPTCode == '') {
        debugger;
        dateFrom = $("[id$='txtReportDateFrom']").val();
        dateTo = $("[id$='txtReportDateTo']").val();
        FilterPatientRPM(0, true);

        $(".hidetd").hide();
        $("#dashboard").hide();
        $("#ClaimRPM").hide();
        $("#divReports").hide();
        $("#ReportsRPM").hide();
        $("#Reports").hide();
        $("#AllReportsRPM").hide();

        $("#PatientRPM").show();
        $("#div-Pat").css("background-color", "#EEEFEF");
        //remove css
        $("#div-Reports").css("background-color", "#FFFFFF")
        $("#div-DashBoard").css("background-color", "#FFFFFF")
        $("#div-Claim").css("background-color", "#FFFFFF")

        GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatientRPM");
        if ($("[id$='hdnTotalRows']").val() > 0)
            $("#PatientContainer .spanInfo").html("Showing " + $("#patientList tr:first").children().first().html() + " to " + $("#patientList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
    }
    if (link == "Reports" && Criteria == '' && CPTCode != '') {
        debugger;
        $("#dashboard").hide();
        $("#ClaimRPM").hide();
        $("#PatientRPM").hide();
        $("#Reports").hide();
        $("#AllReportsRPM").hide();

        var CPTCode = CPTCode;
        var Criteria = "CPTCode";
        $.post("../ProviderPortal/PatientClaimCPT_wiseRecord.aspx", {
            CPTCode: CPTCode,
            Criteria: Criteria

        }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartPatientClaimCPT_wiseRecord###") + 37;
            var end = data.indexOf("###EndPatientClaimCPT_wiseRecord###");
            $("#RPMDashBoard_ClaimAndPatientDetailWise").html(returnHtml.substring(start, end));

        })

        $("#RPMDashBoard_ClaimAndPatientDetailWise").show();
        $("#ReportsRPM").show();
    }
    if (link == "Reports" && Criteria == 'Patient' && CPTCode=='') {
        debugger;
        var CPTCode = CPTCode;
        var Criteria = Criteria;
        $.post("../ProviderPortal/PatientClaimCPT_wiseRecord.aspx", {
            CPTCode: CPTCode,
            Criteria: Criteria
        }, function (data) {
            debugger
            var returnHtml = data;
            var start = data.indexOf("###StartPatient_wiseRecord###") + 37;
            var end = data.indexOf("###EndPatient_wiseRecord###");
                $("#RPMDashBoard_ClaimAndPatientDetailWise").html(returnHtml.substring(start, end));     

        }).done(function () {
            
            $("#ReportsRPM").show();
            $("#divReports").show();
            $("#dashboard").hide();
            $("#ClaimRPM").hide();
            $("#PatientRPM").hide();
            $("#div-Reports").css("background-color", "#EEEFEF");
            //remove css
            $("#div-Claim").css("background-color", "#FFFFFF");
            $("#div-Pat").css("background-color", "#FFFFFF");
            $("#div-DashBoard").css("background-color", "#FFFFFF");
        });
       

    }
    if (link == "Reports" && Criteria == 'Claim' && CPTCode == '') {
        debugger;
        var CPTCode = CPTCode;
        var Criteria = Criteria;
        $.post("../ProviderPortal/PatientClaimCPT_wiseRecord.aspx", {
            CPTCode: CPTCode,
            Criteria: Criteria

        }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartClaim_wiseRecord###") + 37;
            var end = data.indexOf("###EndClaim_wiseRecord###");
            $("#RPMDashBoard_ClaimAndPatientDetailWise").html(returnHtml.substring(start, end));

        }).done(function () {
            $("#ReportsRPM").show();
            $("#divReports").show();
            $("#dashboard").hide();
            $("#ClaimRPM").hide();
            $("#PatientRPM").hide();
            $("#div-Reports").css("background-color", "#EEEFEF");
            //remove css
            $("#div-Claim").css("background-color", "#FFFFFF");
            $("#div-Pat").css("background-color", "#FFFFFF");
            $("#div-DashBoard").css("background-color", "#FFFFFF");
        });
    }
    if (link == "Reports" && Criteria == 'CPTCode' && CPTCode != '') {
        debugger;
        var CPTCode = CPTCode;
        var Criteria = Criteria;
        
        $.post("../ProviderPortal/PatientClaimCPT_wiseRecord.aspx", {
            CPTCode: CPTCode,
            Criteria: Criteria,
            DateFrom : $("[id$='txtReportDateFrom']").val(),
            DateTo : $("[id$='txtReportDateTo']").val()

        }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartCPT_wiseRecord###") + 25;
            var end = data.indexOf("###EndCPT_wiseRecord###");
            $("#RPMDashBoard_ClaimAndPatientDetailWise").html(returnHtml.substring(start, end));

        }).done(function () {
            $("#ReportsRPM").show();
            $("#divReports").show();
            $("#dashboard").hide();
            $("#ClaimRPM").hide();
            $("#PatientRPM").hide();
            $("#div-Reports").css("background-color", "#EEEFEF");
            //remove css
            $("#div-Claim").css("background-color", "#FFFFFF");
            $("#div-Pat").css("background-color", "#FFFFFF");
            $("#div-DashBoard").css("background-color", "#FFFFFF");
        });
    }
}
function OpenAllPatientReports(elem) {
    if (!$(elem).hasClass("ActiveBtn")) {
        debugger
        $(elem).addClass("ActiveBtn");
        $("#btnClaimReportsRPM").removeClass("ActiveBtn");
        $("#btnProcedureReportsRPM").removeClass("ActiveBtn");
    }
    
    debugger
    $.post("../ProviderPortal/PatientClaimCPT_wiseRecord.aspx", {
        CPTCode: '',
        Criteria: 'Patient'

    }, function (data) {
        debugger
        var returnHtml = data;
            var start = data.indexOf("###StartPatient_wiseRecord###") + 37;
            var end = data.indexOf("###EndPatient_wiseRecord###");
            $("#Reports").html(returnHtml.substring(start, end));

    }).done(function () {
        $("#Reports").show();
        $("#ReportsRPM").hide();
        $("#divReports").hide();
        $("#dashboard").hide();
        $("#ClaimRPM").hide();
        $("#PatientRPM").hide();
        $("#div-Reports").css("background-color", "#EEEFEF");
        $("#div-Reports").css("Margin-top", "25px");
        //remove css
        $("#div-Claim").css("background-color", "#FFFFFF");
        $("#div-Pat").css("background-color", "#FFFFFF");
        $("#div-DashBoard").css("background-color", "#FFFFFF");
    });

}
function OpenAllClaimReports(elem) {
    
    if (!$(elem).hasClass("ActiveBtn")) {
        debugger
        $(elem).addClass("ActiveBtn");
        $("#btnPatietReportsRPM").removeClass("ActiveBtn");
        $("#btnProcedureReportsRPM").removeClass("ActiveBtn");
    } 
    debugger
    $.post("../ProviderPortal/PatientClaimCPT_wiseRecord.aspx", {
        CPTCode: '',
        Criteria: 'Claim'

    }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartClaim_wiseRecord###") + 37;
        var end = data.indexOf("###EndClaim_wiseRecord###");
            $("#Reports").html(returnHtml.substring(start, end));

    }).done(function () {
        $("#Reports").show();
        $("#ReportsRPM").hide();
        $("#divReports").hide();
        $("#dashboard").hide();
        $("#ClaimRPM").hide();
        $("#PatientRPM").hide();
        $("#div-Reports").css("background-color", "#EEEFEF");
        
        //remove css
        $("#div-Claim").css("background-color", "#FFFFFF");
        $("#div-Pat").css("background-color", "#FFFFFF");
        $("#div-DashBoard").css("background-color", "#FFFFFF");
    });
}
function OpenAllCPTReports(elem) {
    if (!$(elem).hasClass("ActiveBtn")) {
        debugger
        $(elem).addClass("ActiveBtn");
        $("#btnClaimReportsRPM").removeClass("ActiveBtn");
        $("#btnPatietReportsRPM").removeClass("ActiveBtn");
    } 
    debugger;
    var CPTCode = '';
    var Criteria = 'CPTCode';
    $.post("../ProviderPortal/PatientClaimCPT_wiseRecord.aspx", {
        CPTCode: CPTCode,
        Criteria: Criteria

    }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartCPT_wiseRecord###") + 25;
        var end = data.indexOf("###EndCPT_wiseRecord###");
            $("#Reports").html(returnHtml.substring(start, end));

    }).done(function () {
        $("#Reports").show();
        $("#ReportsRPM").hide();
        $("#divReports").hide();
        $("#dashboard").hide();
        $("#ClaimRPM").hide();
        $("#PatientRPM").hide();
        $("#div-Reports").css("background-color", "#EEEFEF");
        //remove css
        $("#div-Claim").css("background-color", "#FFFFFF");
        $("#div-Pat").css("background-color", "#FFFFFF");
        $("#div-DashBoard").css("background-color", "#FFFFFF");
    });
}
function FilterClaimsRPM(pageNumber, paging, Locationids) {
    debugger;
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
    //var InsuranceId = _insuranceddlId;
    //$.trim($("[id$='ddlInsurance']").val());
    var SubmissionStatusId = $.trim($("[id$='ddlSubmissionStatus']").val());
    var Location = $.trim($("[id$='txtLocation']").val());
    /*********added by shahid kazmi 1/22/2018**********/
    var AmountPaid = $.trim($("[id$='txtPaidAmount']").val());
    var AmountDue = $.trim($("[id$='txtAmountDue']").val());
    var Charges = $.trim($("[id$='txtCharges']").val());
    
    /*********end shahid kazmi 1/22/2018**************/
    debugger;
    $("[Id$='allCheckbox1']").prop("checked", false);

    var isRPM = true;


    $.post("./Claims/CallBacks/BillingManagerHandler.aspx", {
        ClaimId: ClaimId,
        PatientId: PatientId,
        PatientName: PatientName,
        DateOfService: DateOfService,
        BillDate: BillDate,
        InsuranceId: InsuranceId,
        Location: Location,
        SubmissionStatusId: SubmissionStatusId,
        //IsPTL: IsPTL,
        //PTLReasons: PTLReasons,
        Rows: $("#ddlPagingClaims").val(),
        PageNumber: pageNumber,
        isRPM: isRPM,
        AmountPaid: AmountPaid,
        AmountDue: AmountDue,
        SortBy: SORTBY,
        dateFrom: dateFrom,
        dateTo: dateTo,
        charges: Charges
    },
        function (data) {
            debugger;
            var returnHtml = data;
            var start = data.indexOf("###StartBillingHandler###") + 25;
            var end = data.indexOf("###EndBillingHandler###");
            $("#ClaimsList").html(returnHtml.substring(start, end));

            debugger;
            if (paging == true) {
                GeneratePaging($("[id$='hdnClaimsCount']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaimsRPM");     
            }
            if ($("[id$='hdnClaimsCount']").val() > 0) {
                $("#divClaims .spanInfo").html("Showing " + $("#ClaimsList tr:first").children().first().html() + " to " + $("#ClaimsList tr:last").children().first().html() + " of " + $("[id$='hdnClaimsCount']").val() + " entries");
            }
        });
}

function FilterPatientRPM(pageNumber = "0", paging) {
    debugger;

    if (SORTBY == null || SORTBY == undefined || SORTBY == '') SORTBY = 'Account Number DESC';

    var PatientId = $.trim($("#txtPatientId").val()) == "" ? 0 : $.trim($("#txtPatientId").val());

    var LastName = $.trim($("#txtLastName").val());
    var FirstName = $.trim($("#txtFirstName").val());
    var Gender = $.trim($("#ddlGender").val());
    var DOB = $.trim($("[id$='txtDateOfBirth']").val());
    var Phone = $.trim($("#txtPhone").val());
    var Address = $.trim($("#txtAddress").val());
    var PatientCondition = $.trim($("[id$='ddlPatientCondition']").val());
    var PriInsurance = $.trim($("#txtPriInsurance").val());
   

    var isRPM = true;
    //if ($("#rdoAllPatient").is(":checked") || $("[id$='spnPatientSection']").is(':visible') == false) {
    //    isRPM = false;
    //}
    //else {
    //    isRPM = true;
    //}
    debugger;
    $.post(_ResolveUrl + "../../ProviderPortal/Patient/CallBacks/PatientFilterHandler.aspx", { PriInsurance: PriInsurance, PatientId: PatientId, FirstName: FirstName, LastName: LastName, Gender: Gender, Phone: Phone, Address: Address, isRPM: isRPM, PatientCondition: PatientCondition, DOB: (isDate(DOB)) ? DOB : "", DateFrom:dateFrom, dateTo: dateTo, Rows: $("#ddlPagingPatient").val(), PageNumber: pageNumber, SortBy: SORTBY}, function (data) {
        debugger
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#patientList").html(returnHtml.substring(start, end));
        $(".hidetd").css("display", "none");
        debugger;
        var startRowsCount = data.indexOf("###StartPatientRowsCount###") + 30;
        var endRowsCount = data.indexOf("###EndPatientRowsCount###");
        $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatientRPM");
        }

        if ($("[id$='hdnTotalRows']").val() > 0)
            $("#PatientContainer .spanInfo").html("Showing " + $("#patientList tr:first").children().first().html() + " to " + $("#patientList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
    });
}
function setDateNull() {
    dateFrom = "";
    dateTo = "";
    FilterClaimsRPM(0, true);
    FilterPatientRPM(0, true);

}
function SetSearchClaims(event) {
    debugger;

    var a = event.which || event.keyCode;
    if (a == 13) {
        event.preventDefault();
        if ($("#FilterIcon").hasClass("active")) {
            FilterClaimsRPM(0, true);
            $("#FilterIcon").css("color", "#065172");
            $("#FilterIcon1").css("color", "#065172");
        }
        
    }
    else {
        $("#FilterIcon").addClass("active");
        $("#FilterIcon").css("color", "red");
        $("#FilterIcon1").css("color", "red");
    }

}
function SetSearchPatients(event) {
    debugger;
    var a = event.which || event.keyCode; 
    
    if (a == 13) {
        if ($("#FilterIcon").hasClass("active")) {
            FilterPatientRPM(0, true);
            $("#FilterIcon").css("color", "#065172");
            $("#FilterIcon1").css("color", "#065172");
        }

    }
    else {
        $("#FilterIcon").addClass("active");
        $("#FilterIcon").css("color", "red");
        $("#FilterIcon1").css("color", "red");
    }

}
function patientIdKeyPress(evt) {
    _IsPatientIdValidated = true;
    var isValidate = ValidateOnlyNumber(evt);
    if (!isValidate) {
        _IsPatientIdValidated = false;
    }

    return _IsPatientIdValidated;
}
var _IsPatientIdValidated = true;
function claimIdKeyPress(evt) {
    _IsPatientIdValidated = true;
    var isValidate = ValidateOnlyNumber(evt);
    if (!isValidate) {
        _IsPatientIdValidated = false;
    }

    return _IsPatientIdValidated;
}
function LoadInsuranceList() {
    $.post(_EMRPath + "/Claims/CallBacks/BillingManagerHandler.aspx", { action: "InsuranceList" }, function (data) {
        var start = data.indexOf("###StartInsu###") + 17;
        var end = data.indexOf("###EndInsu###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#LoadInsuranceListDiv").html(returnHtml);
        $("#LoadInsuranceListDiv").show();


    });
}
function selectinsurance(elem) {
    debugger
    var InsuranceName = $(elem).find(".InsuranceName").html();


    $(elem).parents('#LoadInsuranceListDiv').hide();



    if (InsuranceName == "All") {
        _insuranceddlId = "";
        $(".lbltexthere").text("");
    }
    else if ((InsuranceName == "Self Pay")) {
        _insuranceddlId = "1";
        $(".lbltexthere").text(InsuranceName);
    }
    else if ((InsuranceName == "Insurance Required")) {
        _insuranceddlId = "3";
        $(".lbltexthere").text(InsuranceName);
    }
    else {
        _insuranceddlId = $(elem).find(".InsuranceId").html();
        $(".lbltexthere").text(InsuranceName);
    }

    FilterClaimsRPM(0, true);
}

//
function ClaimOpenForView(Claimid, PatientId, status) {
    debugger;
    var params = {
        ClaimId: Claimid,
        PatientId: PatientId,
        Status: status
    };
    $.post("./Claims/CallBacks/OpenClaimForm.aspx", params, function (data) {
        debugger;
        var start = data.indexOf("###StartAllClaims###") + 20;
        var end = data.indexOf("###EndAllClaims###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#OpenClaimForm").html(returnHtml);

        $("#OpenClaimForm").dialog({
            width: 1000,
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
                //$(".Grid").css("width", "85%");
               // $("#OpenClaimForm").css("width", "85%");
            }
        });
    });

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
function openCMSPrintPreview() {
    debugger;
    var isCMSBlank = $("[id$='rbPrintBlankCMS']").is(":checked");

    var url = _EMRPath + "/Claims/ClaimFormView.aspx?ClaimId=" + _ClaimId + "&PatientId=" + _PatientId + "&isCMSBlank=" + isCMSBlank;
    var win = window.open(url, '_blank');
    win.focus();

    _IsPrintFromList = false;
    $("#divDialogPrintCMSForm").dialog("close");
}
function sortedbyAscDescCLaimRPM(elem, type) {
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
    FilterClaimsRPM(0, true);
}
function sortedbyAscDescPatientRPM(elem, type) {
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
    FilterPatientRPM(0, true);
}
function ViewDetails(PatientId) {
    window.location = "Demographics.aspx?PatientId=" + PatientId;
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
function ExportReportForSummary(fileNameFromFile, elem, divid) {
    //Changes By Sajid Ali Date 5/18/2018



    debugger;
    var printdd = $(elem).attr('id');



    var divId = '#' + divid;


    $(divId).find('.center').css("position", "unset");

    var ddlValue = $('#' + printdd).val();
    var filter_name = "";
    if (fileNameFromFile != "") {
        filter_name = fileNameFromFile;
    }
    else {
        filter_name = filename;
    }




    var filtername_1 = filter_name.substring(0, filter_name.length - 5)
    var fullDate = new Date()
    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);
    var currentDate = fullDate.getDate() + "/" + twoDigitMonth + "/" + fullDate.getFullYear();



    if (ddlValue == "Excel") {
        debugger;
        $(".Ins_TdAction").remove();
        let file = new Blob([$(".PrintableReports").html()], { type: "application/vnd.ms-excel" });
        let url = URL.createObjectURL(file);
        let a = $("<a />", {
            href: url,
            download: filtername_1 + " _ " + currentDate + ".xls"
        }).appendTo("body").get(0).click();
        $('#tblInsurancePortal thead th:last-child').after('<th class="asc InsTdAction Ins_TdAction"><span class="report-column-title">Action</span><span></span></th>');
        event.preventDefault();
    }
    //Changes By Sajid Ali Date 5/18/2018
    else if (ddlValue == "PDF") {
        $(".InsTdAction").hide();
        var PdfHtml = $(".PrintableReports").html();
        var htmlToPrint = '' +
            '<style type="text/css">' +
            'table, th, table td {' +
            'Text-align:center;' +
            'border:1px solid #000;' +
            'border-collapse: collapse;' +
            'padding;3.5em;' +
            'position;3.5em;' +
            '}' +
            '</style>';
        htmlToPrint += "<span  class='btnprint' id='btnprint' onclick='PrintReport()'>Print</span></br>"+PdfHtml;
        //var doc = window.jspdf.jsPDF;
        //var specialElementHandlers = {
        //    '.PrintableReports': function (element, renderer) {
        //        return true;
        //    }
        //};
        //doc.fromHTML(PdfHtml, 15, 15, {
        //    'width': 170,
        //    'elementHandlers': specialElementHandlers
        //});

        //// Save the PDF
        //doc.save('sample-document.pdf');

        newWin = window.open("");
        newWin.document.write(htmlToPrint);
        
        newWin.focus();
        //window.print()
        //newWin.close();

    }
    //Changes By Sajid Ali Date 5/18/2018
    else if (ddlValue == "Word") {
        $(".InsTdAction").hide();
        let file = new Blob([$(".PrintableReports").html()], { type: "application/vnd.document" });
        let url = URL.createObjectURL(file);
        let a = $("<a />", {
            href: url,
            download: filtername_1 + " _ " + currentDate + ".doc"
        }).appendTo("body").get(0).click();
        $(".InsTdAction").show();
        event.preventDefault();
    }
    //Changes By Sajid Ali Date 5/18/2018




    $(".PrintableReports").find('.center').css("position", "relative");

}
function ViewDetails(PatientId) {
    window.location = "Patient/Demographics.aspx?PatientId=" + PatientId;
}