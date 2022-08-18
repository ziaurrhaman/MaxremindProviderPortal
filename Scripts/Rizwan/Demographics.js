// 2 Nov 2017 mm


var PrimaryinsuranceType; var title; var Prisecothervalue; var Insurancevalue;


$(document).ready(function () {
    debugger;
    PrimaryinsuranceType = $("[id$=hdnInshuranecType]").val();
    title = $("[id$=lblLastName]").val() + ' ' + $("[id$=lblFirstName]").val();



    $("#liDocuments").click(function (e) {
        // Prevent a page reload when a link is pressed
        debugger;
        e.preventDefault();
        // Call the scroll function
        $("html,body").animate({ scrollTop: ($("#divDocuments").offset().top - $("header").height()) - 10 }, 500);

    });
    $("#liClaims").click(function (e) {

        debugger;

        $("html,body").animate({ scrollTop: ($("#divPatientClaim").offset().top - $("header").height()) - 80 }, 500);
        e.preventDefault();

    });

    $("#liInsurance").click(function (e) {



        $("html,body").animate({ scrollTop: ($("#divInsurances").offset().top - $("header").height()) - 80 }, 500);
        e.preventDefault();
    });

    $("#liDemographics").click(function (e) {

        debugger;


        $("html,body").animate({ scrollTop: ($("#divDemographics").offset().top - $("header").height()) - 80 }, 500);
        e.preventDefault();
    });


});




//***************Start******************//
//Function s for saving the insuranace Start



function InsurancePopUp() {

    debugger;
    InsuranceType = $("[id$=ddInsurance ] option:selected ").val();
    $("#patient").text(title);

    $("#AddInsuranceDiv").css("display", "block");
    $("#cover").css("display", "block");
    $("#cover").css("opacity", "2");
    // $("#Demographics").css("position", "fixed");
    //Showing PatientUpdatehandler Form in callbackdiv
    $("body").css("overflow", "hidden");
    $.post("PatientInsurancehandler/PatientInsuranceHandler.aspx", function (data) {
        $("#callbackDiv").html(data);

    }).done(function () {
        debugger

    });
}

function SaveInsurance() {
    debugger;

    InsuranceType = $("[id$=ddInsurance ] option:selected ").val();
    var insurancename = $("[id$=ddName ] option:selected ").val();
    var Policenum = $("[id$=txtPoliceNo ]").val();
    if (InsuranceType == "Select") {
        $("[id$=UpdateddInsurance]").css("border-color", "red");
        var mesg = "Please Select Insurance Type.";
        showErrorMessage(mesg);
    }

    else if (InsuranceType == "" || insurancename == "" || Policenum == "") {
        var mesg = "Please review the form carefully and provide required information.";
        showErrorMessage(mesg);
    }




    else {
        var patid = $("[id$=Pid]").val();
        if (InsuranceType == PrimaryinsuranceType) {
            var Message = "Patient Had Already Primary Insurance. Do you want to chnage Insurance Type ?";

            showErrorMessage(Message);
        }




        else {
            debugger
            getSaveData();
            //$("#refresh").hide();

            var message = "Patient insurance added successfully";
            showSuccessMessage(message)

        }

    }


}


//function for getting the data form add patient insurance popup
function getSaveData() {
    debugger;



    var Insertdataobj = {

        Patientid: $("[id$=Pid]").val(),
        CreatedDate: $("[id$= CurrentDate]").val(),
        CoPayType: $("select[id$=ddCopay] option:selected").val(),
        CoInsurance: $("[id$=txtCoinsurance]").val(),
        CoInsuranceType: $("select[id$=ddCoinsurance] option:selected").val(),
        Deductable: $("[id$=txtDeductable]").val(),
        DeductableType: $("select[id$=ddDeductable] option:selected").val(),
        Relationship: $("select[id$=ddRelationship] option:selected").val(),
        InsuranceId: $("select[id$='ddName'] option:selected").val(),
        GroupName: $("[id$=txtGroupName]").val(),

        PriSecOthType: $("[id$=ddInsurance ] option:selected ").val(),
        PolicyNumber: $("[id$=txtPoliceNo]").val(),
        GroupNumber: $("[id$=xtGroupNo]").val(),

        EffectiveDate: $("[id$=txtEffectiveDate]").val(),
        TerminationDate: $("[id$=txtTerminationDate]").val(),
        CoPay: $("[id$=txtCopay]").val(),
        SubscriberId : $("[id$='hdnPrimarySubscriberId']").val(),



    };

    $.post("PatientInsurancehandler/PatientInsuranceHandler.aspx", { Insertdataobj: JSON.stringify(Insertdataobj), action: "Insert" }).done(function () {
        $("#refresh").load(location.href + " #refresh");
        $("#AddInsuranceDiv").css("display", "none");
        $("#cover").css("display", "none");
        $("#Demographics").css("position", "relative");
        $("body").css("overflow", "visible");

    });

}



//closing using cancel button
$("body").on("click", "#Addcancel", function () {
    $("#AddInsuranceDiv").hide();
    $("#cover").css("display", "none");
    //  $("#Demographics").css("position", "relative");
    $("body").css("overflow", "visible");
});
//closing using closing  button
$("body").on("click", "#close", function () {


    $("#AddInsuranceDiv").hide();

    $("#cover").css("display", "none");

    //$("#Demographics").css("position", "relative");
    $("body").css("overflow", "visible");
});
// End Functions  for saving the insurance 
//**************End*******************//



//***************Start******************//
//Functions  for Updatede the insurance Start
var insuranceid;
function InsuranceUpdatePopUp(PatientInsuranceId, SubscriberFirstName,SubscriberLastName) {

    debugger;
    insuranceid = PatientInsuranceId;
    $("#cover").css("display", "block");
    $("#cover").css("opacity", "2");
    //$("#Demographics").css("position", "fixed");
    $("body").css("overflow", "hidden");

    var title = $("[id$=lblLastName]").val() + ' ' + $("[id$=lblFirstName]").val();
    $("#Upatient").text(title);
    $("#UpdateInsuranceDiv").css("display", "block");
    
    var Fname = SubscriberFirstName;
    var Lname = SubscriberLastName;

    $.post("PatientInsurancehandler/PatientInsuranceUpdateHandler.aspx", { id: insuranceid, Fname: Fname, Lname: Lname }, function (data) {

        $("[id$='UcallbackDiv']").html(data)


    }).done(function () {
        debugger


        var InsuranceName = $("[id$=InsurancesName]").text();
        if (InsuranceName == "Primary") {

            Insurancevalue = "P";
        }
        else if (InsuranceName == "Secondary") {
            Insurancevalue = "S";
        }
        else {
            Insurancevalue = "O";
        }

    });



}

$("#ddinsubtn").click(function () {
    debugger
    $("#InsurancesName").css("display", "none");
    $("[id$=UpdateddInsurance]").css("display", "block");
    $("#ddinsubtn").hide();




});

var InsuranceType;
$("[id$=UpdateddInsurance]").change(function () {
    debugger;
    //InsuranceType = $(this).val();
    //focusout();
    $("[id$=UpdateddInsurance]").css("border-color", "#c4c4c4");
    //InsuranceType = $("[id$=UpdateddInsurance ] option:selected ").val();
    InsuranceType = $('.clsUpdateddInsurance option:selected').val();
});






function UpdateInsuranceData() {
    debugger
    /********edited by shahid kazmi 2/12/2018**********/
    //PrimaryinsuranceType = $("[id$=hdnInshuranecType]").val();
    // InsuranceType = $("[id$=UpdateddInsurance ] option:selected ").val();
    if ($("[id$='InsurancesName']").text() == "Primary" && InsuranceType != "P") {
        PrimaryinsuranceType = "";
    }
    else {
        PrimaryinsuranceType = $("[id$=hdnInshuranecType]").val();
    }
    /*********end shahid kazmi 2/12/2018*****/
    var insurancename = $("[id$=ddNameU ] option:selected ").val();
    var Policenum = $("[id$=txtPoliceNoU ]").val();



    if (insurancename == "" || Policenum == "") {
        var mesg = "Please review the form carefully and provide required information.";
        showErrorMessage(mesg);
    }

    else if ($("[id$=UpdateddInsurance ]").css("display") != "none") {

        debugger
        if (InsuranceType == "") {
            var mesg = "Please select insurance type.";
            showErrorMessage(mesg);
        }
        else {
            if (InsuranceType != null) {
                debugger

                Prisecothervalue = InsuranceType;

            }
            else {

                Prisecothervalue = Insurancevalue;
            }

            if (InsuranceType == PrimaryinsuranceType) {
                debugger
                var Message = "Patient Had Already Primary Insurance. Do you want to chnage Insurance Type ?";

                showErrorMessage(Message);
            }
            else {

                getUpdatedata();


            }
        }
    }

    else {
        debugger;
        var InsuranceName = $("[id$=InsurancesName]").text();
        if (InsuranceName == "Primary") {

            Prisecothervalue = "P";
        }
        else if (InsuranceName == "Secondary") {
            Prisecothervalue = "S";
        }
        else {
            Prisecothervalue = "O";
        }


        getUpdatedata();

    }
}
/////

//function for getting the data form update patient insurance popup   
function getUpdatedata() {

    debugger;

    var classobjA = {
        // PatientInsuranceId:$("[id$=Insuranceid]").val(),
        PatientInsuranceId: insuranceid,
        Patientid: $("[id$=Pid]").val(),
        ModifiedDate: $("[id$= CurrentDate]").val(),
        CoPayType: $("select[id$=ddCopayU] option:selected").val(),
        CoInsurance: $("[id$=txtCoinsuranceU]").val(),
        CoInsuranceType: $("select[id$=ddCoinsuranceU] option:selected").val(),
        Deductable: $("[id$=txtDeductableU]").val(),
        DeductableType: $("select[id$=ddDeductableU] option:selected").val(),
        Relationship: $("select[id$=ddRelationshipU] option:selected").val(),
        InsuranceId: $("select[id='ddNameU'] option:selected").val(),
        GroupName: $("[id$=txtGroupNameU]").val(),



        PriSecOthType: Prisecothervalue,
        PolicyNumber: $("[id$=txtPoliceNoU]").val(),
        GroupNumber: $("[id$=txtGroupNoU]").val(),

        EffectiveDate: $("[id$=txtEffectiveDateU]").val(),
        TerminationDate: $("[id$=txtTerminationDateU]").val(),
        CoPay: $("[id$=txtCopayU]").val(),
        SubscriberId: $("[id$='hdnPrimarySubscriberId']").val(),



    };

    $.post("PatientInsurancehandler/PatientInsuranceUpdateHandler.aspx", { classobj: JSON.stringify(classobjA), action: "save" })
        .fail(function (xhr, status, error) { alert(error); }).done(function () {
            debugger
            $("#UpdateInsuranceDiv").hide();
            $("#cover").css("display", "none");
            //$("#Demographics").css("position", "relative");
            $("body").css("overflow", "visible");
            $("#refresh").load(location.href + " #refresh");

            //$.post("PatientInsurancehandler/PatientInsuranceTableHandler.aspx", function (data) {

            //    $("#refresh").html(data);
            //});
            var message = "Patient insurance Updated successfully";
            showSuccessMessage(message);


        });



}


$("#Upcancel").click(function () {
    $("#UpdateInsuranceDiv").hide();
    $("#cover").css("display", "none");
    //    $("[id$=UpdateddInsurance]").css("display", "none");
    // $("#Demographics").css("position", "relative");
    $("body").css("overflow", "visible");
});

$("#Uclose").click(function () {

    $("#UpdateInsuranceDiv").hide(); $("[id$=UpdateddInsurance]").css("display", "none");

    $("#cover").css("display", "none");

    $("#Demographics").css("position", "relative");
    $("body").css("overflow", "visible");
});

// End Functions  for saving the insurance 
//**************End*******************//


$("[id$=txtEffectiveDate]").datepicker({

    changeMonth: true,
    changeYear: true
});
$("[id$=txtTerminationDate]").datepicker({
    changeMonth: true,
    changeYear: true
});

$('form,#txtEffectiveDate').attr("autocomplete", "off");
$('form,#txtTerminationDate').attr("autocomplete", "off");

$("[id$=txtEffectiveDateU]").datepicker({

    changeMonth: true,
    changeYear: true
});
$("[id$=txtTerminationDateU]").datepicker({
    changeMonth: true,
    changeYear: true
});

$('form,#txtEffectiveDateU').attr("autocomplete", "off");
$('form,#txtTerminationDateU').attr("autocomplete", "off");









//message on Insurance dropdown change value
$(function () {

    $("[id$=ddInsurance ]").change(function () {

        var selectedText = $(this).find("option:selected").text();

        var selectedValue = $(this).val();
        if (selectedValue != 'P') {
            $(".divMesg").css("display", "none");
        }



    });

});

//Success and Error message
function showSuccessMessage(message) {

    $(".divMesg").css("display", "block");
    $(".divMesg").html(message).removeClass("warning").addClass("success").fadeIn(2000).fadeOut(10000);
}

function showErrorMessage(mesg) {

    $(".divMesg").css("display", "block");
    $(".divMesg").html(mesg).removeClass("success").addClass("warning").fadeIn(2000).fadeOut(10000);
}


function ValidateForm() {
    debugger;


    $("#DemographicsUpdate .required").each(function () {
        if (($.trim($(this).val()) == "" || $(this).val() == 0)) {
            $(this).css("border-color", "red");
        }
        else {
            $(this).css("border-color", "#c4c4c4");
        }
    });

}

function focusout() {
    debugger;
    $("#DemographicsUpdate .required").each(function () {
        if (($.trim($(this).val()) != "" || $(this).val() != 0)) {
            $(this).css("border-color", "#c4c4c4");
        }
    });



}




function ValidateInsurance() {
    debugger;


    $("#InsuranceUpdate .required").each(function () {
        if (($.trim($(this).val()) == "" || $(this).val() == 0)) {
            $(this).css("border-color", "red");
        }
        else {
            $(this).css("border-color", "#c4c4c4");
        }
    });

}

function focusoutInsurance() {
    debugger;
    $("#InsuranceUpdate .required").each(function () {
        if (($.trim($(this).val()) != "" || $(this).val() != 0)) {
            $(this).css("border-color", "#c4c4c4");
        }
    });





}







function FinancialGuarantorSearch() {
    debugger;
    $("#FinancialGuarantorSearch").css("display", "block");
    $("#cover").css("display", "block");
    $("#cover").css("opacity", "2");
    $("body").css("overflow", "hidden");

    $.post("../Patient/CallBacks/FinancialGuarantorSearch.aspx", function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartFinancialGuarantorSearch###") + 35;
        var end = data.indexOf("###EndFinancialGuarantorSearch###");
        $("#FinancialGuarantorSearch").html(returnHtml.substring(start, end));

        GeneratePaging($("[id$='hdnFinancialGuarantorTotalRows']").val(), $("#ddlPagingFinancialGuarantor").val(), "divFinancialGuarantor", "FinancialGuarantorSearchResult");
        if ($("[id$='hdnFinancialGuarantorTotalRows']").val() > 0) {
            $("#divFinancialGuarantor .spanInfo").html("Showing " + $("#financialGuarantorList tr:first").children().first().html() + " to " + $("#financialGuarantorList tr:last").children().first().html() + " of " + $("[id$='hdnFinancialGuarantorTotalRows']").val() + " entries");
        }

        // $("#FinancialGuarantorSearch").dialog({ modal: true, width: '900', title: 'Search Financial Guarantor' });
        $("[id$='txtFinancialGuarantorDOB']").datepicker({
            yearRange: "-110:+0",
            maxDate: new Date(),
            onSelect: function () {
                SubscriberSearchResult(0, true);
            }
        }).mask("99/99/9999");
    });
}


function FinancialGuarantordivclose() {
    debugger;
    $("#FinancialGuarantorSearch").hide();
    $("#cover").css("display", "none");
    $("body").css("overflow", "visible");

}

function FGRelationshipddl() {
    debugger;
    var relationship = $("[id$=ddlRelationship] option:selected").text();
    if (relationship == "Self") {
        var first = $("[id$=lblLastName]").val();
        var last = $("[id$=lblFirstName]").val();

        $("[id$=txtFirstGuarantorName]").val(first);
        $("[id$=txtLastGuarantorName]").val(last);


    }
    else {
        $("#searchGUARANTOR").show();
        $("[id$=txtFirstGuarantorName]").val("");
        $("[id$=txtLastGuarantorName]").val("");


    }



}




