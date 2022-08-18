$(document).ready(function () {


    SetPTLReasons("Patient");
    SetPTLReasons("Claim");
     claimrows = $("[id$= hdnTotalRowsClaim]").val();
    //alert(claimrows);
   
});

var col;
var PTID;  // Patient id
var CID;   // Claim Id
var claimrows;
//Patient PendingTransitions Start

function PTLPatientDialog(PatientId) {
    debugger;
    PTID = PatientId;

    $.post("../PendingTransitions/CallBacks/PTLHandler.aspx", { Patientid: PTID ,action:"PatientPart" }, function (data) {
           
            var returnHTml = data;
            var start = data.indexOf("###StartFormPatient###") + 22;
            var end = data.indexOf("###EndFormPatient###");
            var returnHtml = $.trim(data.substring(start, end));
     
            $("#leftbar").html(returnHTml.substring(start, end));
            PTL_SetForm("Patient");
            $("#leftbar").dialog({
                madal: true,
                title: "PTL Reasons",
                width: 400,
                close: function () {
                    $(this).dialog("destroy");
                    $("#leftbar").hide();
                    $("#cover").css("display", "none");
                    $("#divClaims").css("position", "relative");
                    $(".CheckReasons_RemoveingChk").prop("checked", false);
                }
            });
        }).done(function () {

            $("#cover").css("display", "block");
            $("#cover").css("opacity", "1");
            $("#divClaims").css("position", "fixed");
        });



    


}
function PTL_Save_Patient() {
    debugger;
   
    var strPTLReasons = "";

    $("#divPTLResonsFormPatient .chkReason:checked").each(function () {
        strPTLReasons += $(this).parent().find(".hdnPTLReasonsId").val() + ",";
    });

    if (strPTLReasons.length > 1) {
        strPTLReasons = strPTLReasons.slice(0, -1);
    }

    var objPatient = new Object();

    objPatient.PatientId = PTID;

    objPatient.IsPTL = true;
    objPatient.PTLReasons = strPTLReasons;
    objPatient.PTLNotes = $.trim($("[id$='txtPTLNotesPatient']").val());

    var params = {
        objPatient: JSON.stringify(objPatient),
        action: "SavePTLPatient"
    };

    $.post("../PendingTransitions/CallBacks/PTLHandler.aspx", params, function (data)
    {
       
       $("#leftbar").dialog("close");
       $("#leftbar").hide();
       
       $("#cover").css("display", "none");
       $("#divClaims").css("position", "relative");
       LoadPatientAFterDialogFunction();
 
      
        $("#divMesg").css("display", "block");
        $("#divMesg").fadeOut(2500);
    });
    $(".CheckReasons_RemoveingChk").prop("checked", false);
    
}
function PTL_ResolveStatusPatient()
{
  
    $.post("../PendingTransitions/CallBacks/PTLHandler.aspx", { Patientid: PTID, action: "ResolveStatusPatient" }, function (data) {

        $("#leftbar").dialog("close");
        $("#leftbar").hide();
 
        LoadPatientAFterDialogFunction();
        $(".CheckReasons_RemoveingChk").prop("checked", false);
      
        $("#divMesg").css("display", "block");
        $("#divMesg").fadeOut(2500);
        $("#cover").css("display", "none");
        $("#divClaims").css("position", "relative");
    });

} 

function FilterPatient(pageNumber, paging) {
   debugger;
    var PatientId = $.trim($("#txtPatientId").val()) == "" ? 0 : $.trim($("#txtPatientId").val());

    var LastName = $.trim($("#txtLastName").val());
    var FirstName = $.trim($("#txtFirstName").val());
    var Gender = $.trim($("#ddlGender").val());
    var DOB = $.trim($("[id$='txtDateOfBirth']").val());
    var Phone = $.trim($("#txtPhone").val());
    var Address = $.trim($("#txtAddress").val());
    var PtlReasons = GetPTLReasons("ulPTLReasonFilterListPatient");


    $.post(_ResolveUrl + "../../ProviderPortal/PendingTransitions/CallBacks/PendingTransitionPatienthandler.aspx", { PatientId: PatientId, FirstName: FirstName, LastName: LastName, Gender: Gender, Phone: Phone, Address: Address, PtlReasons: PtlReasons, DOB: (isDate(DOB) ? DOB : ""), Rows: $("#ddlPagingPatient").val(), PageNumber: pageNumber, SortBy: "FirstName" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        //$("#tbodyPTLPatient").html(returnHtml.substring(start, end));

        var returnHtml = $.trim(data.substring(start, end));

        $("#tbodyPTLPatient").hide();

        $("#tbodyPTLPatient").html(returnHtml)
        .promise()
        .done(function () {

            SetPTLReasons("Patient");
            $("#tbodyPTLPatient").show();
        });

      

      
    }).done(function () {

        debugger;
      
       
        if (paging == true) {
         
            GeneratePaging($("[id$='hdnTotalRowsPatients']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
        }
     

        if ($("[id$='hdnTotalRowsPatients']").val() > 0)
            $("#PatientContainer .spanInfo").html("Showing " + $("#tbodyPTLPatient tr:first").children().first().html() + " to " + $("#tbodyPTLPatient tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsPatients']").val() + " entries");
    });
}


function LoadPatientAFterDialogFunction() {
    debugger;
    $.post(_ResolveUrl + "../../ProviderPortal/PendingTransitions/CallBacks/PTLHandler.aspx", function (data) {
        debugger;
        var returnHtml = data;
        var start = data.indexOf("###StartPtlPatient###") + 21;
        var end = data.indexOf("###EndPTLPatient###");
        //$("#tbodyPTLPatient").html(returnHtml.substring(start, end));

        var returnHtml = $.trim(data.substring(start, end));

        $("#tbodyPTLPatient").hide();

        $("#tbodyPTLPatient").html(returnHtml)
        .promise()
        .done(function () {
            SetPTLReasons("Patient");
            $("#tbodyPTLPatient").show();
        });

     
    }).done(function () {
      
        

           
            //GeneratePaging($("[id$='hdnTotalRowsPatients']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
        

        if ($("[id$='hdnTotalRowsPatients']").val() > 0)
            $("#PatientContainer .spanInfo").html("Showing " + $("#tbodyPTLPatient tr:first").children().first().html() + " to " + $("#tbodyPTLPatient tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsPatients']").val() + " entries");
    });
}
//End Patient PendingTransitions 
        



//Claim PendingTransitions Start


function PTLClaimDialog(ClaimId) {
    debugger;
    CID = ClaimId;

    $.post("../PendingTransitions/CallBacks/PTLHandler.aspx", { ClaimId: CID, action:"ClaimPart" }, function (data) {

        var returnHTml = data;
        var start = data.indexOf("###StartFormClaim###") + 22;
        var end = data.indexOf("###EndFormClaim###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#leftbar").html(returnHTml.substring(start, end));
        PTL_SetForm("Claim");
        $("#leftbar").dialog({
            madal: true,
            title: "PTL Reasons",
            width: 400,
            close: function () {
                $(this).dialog("destroy");
                $("#leftbar").hide();
                $("#cover").css("display", "none");
              $("#divClaims").css("position", "relative");
                $(".CheckReasons_RemoveingChk").prop("checked", false);
            }
        });
    }).done(function () {

        $("#cover").css("display", "block");
        $("#cover").css("opacity", "1");
        $("#divClaims").css("position", "fixed");
    });

}
function PTL_Save_Claim() {
    debugger;

    var strPTLReasons = "";

    $("#divPTLResonsFormClaim .chkReason:checked").each(function () {
        strPTLReasons += $(this).parent().find(".hdnPTLReasonsId").val() + ",";
    });

    if (strPTLReasons.length > 1) {
        strPTLReasons = strPTLReasons.slice(0, -1);
    }

    var objClaim = new Object();

    objClaim.ClaimId = CID;

    objClaim.IsPTL = true;
    objClaim.PTLReasons = strPTLReasons;
    objClaim.PTLNotes = $.trim($("[id$='txtPTLNotesClaim']").val());

    var params = {
        objclaim: JSON.stringify(objClaim),
        action: "SavePTLClaim"
    };

    $.post("../PendingTransitions/CallBacks/PTLHandler.aspx", params, function (data) {

        $("#leftbar").dialog("close");
        $("#leftbar").hide();
        ///  $("#divClaims").load(location.href + " #divClaims");
           LoadClaimsAFterDialogFunction();
        $("#divMesg").css("display", "block");
        $("#divMesg").fadeOut(2500);

        $("#cover").css("display", "none");

        $("#divClaims").css("position", "relative");
    });
    $(".CheckReasons_RemoveingChk").prop("checked", false);
}
function FilterClaims(pageNumber, paging) {

    debugger;
    var ClaimId = $.trim($("[id$='txtClaimNoFilterClaim']").val());
    var PatientId = $.trim($("[id$='txtPatientAccountFilterClaim']").val());
    var PatientName = $.trim($("[id$='txtPatientNameFilterClaim']").val());
    var DateOfService = $.trim($("[id$='txtDateOfServiceFilterClaim']").val());
    var BillDate = $.trim($("[id$='txtBillDateFilterClaim']").val());
    var InsuranceId = $.trim($("[id$='ddlInsuranceFilterClaim']").val());
    var SubmissionStatusId = $.trim($("[id$='ddlSubmissionStatusFilterClaim']").val());
    var PTLReasons = GetPTLReasons("ulPTLReasonFilterListClaim");
    var IsPTL = true;
    var params = {
        ClaimId: ClaimId,
        PatientId: PatientId,
        PatientName: PatientName,
        DateOfService: DateOfService,
        BillDate: BillDate,
        InsuranceId: InsuranceId,
        SubmissionStatusId: SubmissionStatusId,
        IsPTL: IsPTL,
        PTLReason: PTLReasons,

        Rows: $("#ddlPagingClaims").val(),
        PageNumber: pageNumber
    };

    $.post(_ResolveUrl + "../../ProviderPortal/PendingTransitions/CallBacks/PendingTransitionClaimhandler.aspx", params, function (data) {
        var returnHtml = data;
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

       
    }).done(function () {
        debugger;
        var a = $("[id$=hdnTotalRowsClaims]").val();
    
        if (paging==true){
        GeneratePaging($("[id$='hdnTotalRowsClaims']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");
        }

        if ($("[id$='hdnTotalRowsClaims']").val() > 0) {
            $("#divClaims .spanInfo").html("Showing " + $("#tbodyPTLClaim tr:first").children().first().html() + " to " + $("#tbodyPTLClaim tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsClaims']").val() + " entries");
        }
       
    });
}

function LoadClaimsAFterDialogFunction()
{
    debugger
    
    $.post(_ResolveUrl + "../../ProviderPortal/PendingTransitions/CallBacks/PTLHandler.aspx", function (data) {
      
        var returnHtml = data;
        var start = data.indexOf("###StartPTLClaim###") + 25;
        var end = data.indexOf("###EndPTLClaim###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#tbodyPTLClaim").hide();

        $("#tbodyPTLClaim").html(returnHtml)
        .promise()
        .done(function () {
            SetPTLReasons("Claim");
            $("#tbodyPTLClaim").show();
        });
        
    }).done(function () {
        debugger;
      
            //GeneratePaging($("[id$='hdnTotalRowsClaims']").val(), $("#ddlPagingClaims").val(), "divClaims", "FilterClaims");
        
   


        if ($("[id$='hdnTotalRowsClaims']").val() > 0) {
            $("#divClaims .spanInfo").html("Showing " + $("#tbodyPTLClaim tr:first").children().first().html() + " to " + $("#tbodyPTLClaim tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsClaims']").val() + " entries");
        }

    });
   
}
function PTL_ResolveStatusClaim() {

    $.post("../PendingTransitions/CallBacks/PTLHandler.aspx", { ClaimId: CID, action: "ResolveStatusClaim" }, function (data) {

        $("#leftbar").dialog("close");
        $("#leftbar").hide();
        //$("#PatientContainer").load(location.href + " #PatientContainer");
        LoadClaimsAFterDialogFunction();
        $("#divMesg").css("display", "block");
        $("#divMesg").fadeOut(2500);
    });
    $(".CheckReasons_RemoveingChk").prop("checked", false);
}
//Claim PendingTransitions End



// Common Function //

function PTL_SetForm(PTLType) {
    debugger;
    var strPatientPTLReasons = $.trim($("[id$='hdnPTLReasons" + PTLType + "']").val());

    var arrPatientPTLReasons = strPatientPTLReasons.split(',');

    for (var i = 0; i < arrPatientPTLReasons.length; i++) {
        $("[id$='chk" + PTLType + "PTLReasonsId" + arrPatientPTLReasons[i] + "']").prop("checked", true);
    }
}
function PTL_CloseForm() {
    $("#leftbar").hide();
    $("#leftbar").dialog("destroy");
    $("#leftbar").hide();
    $(".CheckReasons_RemoveingChk").prop("checked", false);
    $("#cover").css("display", "none");
    $("#divClaims").css("position", "relative");
   
}

function HideShowPTLDivs(divToShow) {
    $(".ptl-main-divs").hide();
    $("#" + divToShow).show();
}

function SelectUnselectPTLReasons_All(elem) {
    var IsAllChecked = $(elem).is(":checked");

    $(elem).closest("ul").find("input[type='checkbox']").not($(elem)).prop("checked", IsAllChecked);
}

function SelectUnselectPTLReasons(elem) {
    var CurrentUL = $(elem).closest("ul");

    var AllLength = CurrentUL.find(".chkReason").length;
    var CheckedLength = CurrentUL.find(".chkReason:checked").length;

    CurrentUL.find(".chkPTLReasonsAll").prop("checked", (AllLength == CheckedLength));
}

function OkMultiCheckDropDownPTLReason(elem, PTLType) {
    debugger;
    if (PTLType == "Patient") {
        FilterPatient(0, true);
    }
    else if (PTLType == "Claim") {
        FilterClaims(0, true);
    }

    HideShowPTLReasonDropDown(elem);
}

function HideShowPTLReasonDropDown(elem) {
    var dropdownDivMainWrapper = $(elem).closest(".dropdownMenuMultiCheckMainWrapper");

    if (dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").is(":visible")) {
        dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").hide();
    }
    else {
        dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").show();
    }
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

function SetPTLReasons(PTLType) {
    debugger;
    var PTLReason, strPTLReasons = "", arrPTLReasons;

    $("#tbodyPTL" + PTLType + " .tdPTLReasons").each(function () {
        strPTLReasons = $.trim($(this).find("span").html());

        if (strPTLReasons != "")
        {
            arrPTLReasons = strPTLReasons.split(',');

            strPTLReasons = "";

            for (var i = 0; i < arrPTLReasons.length; i++) {
                PTLReason = $.trim($("[id$='chk" + PTLType + "PTLReasonsId" + arrPTLReasons[i] + "']").parent().find(".spnReason").html());

                strPTLReasons += PTLReason + ", ";
            }

            if (strPTLReasons.length > 1) {
                strPTLReasons = strPTLReasons.slice(0, -2);
            }
        }
        else {
            strPTLReasons = $.trim($(this).find(".hdnPTLNotes").val());
        }

        $(this).html(strPTLReasons);
    });
}



