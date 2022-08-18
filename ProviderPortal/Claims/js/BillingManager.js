$(document).ready(function () {
    //$(".lbltexthere").text("All");
});
function LoadInsuranceList()
{
    $.post(_EMRPath + "/Claims/CallBacks/BillingManagerHandler.aspx", { action:"InsuranceList" }, function (data) {
        var start = data.indexOf("###StartInsu###") + 17;
        var end = data.indexOf("###EndInsu###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#LoadInsuranceListDiv").html(returnHtml);
        $("#LoadInsuranceListDiv").show();

       
    });
}
//Added by Syed Sajid Ali Date:01/19/2021
function LoadLocationList() {
        $("#divLoadLocationList").show();
        $("#LoadLocationListDiv").show();
        //CheckedselectedLocationChkbox();
}
//end by Syed Sajid Ali
function selectinsurance(elem)
{   //debugger
    var InsuranceName = $(elem).find(".InsuranceName").html();
   
    
    $(elem).parents('#LoadInsuranceListDiv').hide();

   

    if (InsuranceName == "All")
    {
        _insuranceddlId = "";
        $(".lbltexthere").text("");
    }
    else if((InsuranceName == "Self Pay"))
    {
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
   
    FilterClaims(0, true);
}
function closeddl() {
    $("#LoadInsuranceListDiv").hide();
}
//Added by Syed Sajid Ali Date:01/19/2021
function closeddlLocation() {
    //debugger;
    var Locationids = "";
    $("#LoadLocationListDiv").hide();
    $(".lbltextherePL").text("");
    $(".hdnLocationName").val("");
    $(".hdnLocationsId").val("");
    $('.ChkBox').prop('checked', false);
    $('#chkBoxALL').prop('checked', false);
    FilterClaims(0, true, Locationids);    
}
function SearchLocation() {
    $("#divShowDDLAttending").hide();
    var Locationids = '';
    var LocationNames = '';
    var count = 0;
    $(".tbodyLocationList > tr").each(function () {
        //debugger;
        if ($(this).find('#chkBox').is(":checked")) {
            Locationids += $(this).find('.hdnPracticeLocationsId').val() + ",";
            LocationNames += $.trim($(this).find('.hdnName').val()) + ",";
            count++;
        }
    });
    if (LocationNames == "") {
        //$(".lbltextherePL").text("All");
        $(".hdnLocationName").val("All");
    } else {
        var stringlength = LocationNames.length
        if (stringlength > 30) {
            var Result = LocationNames.substr(0, 30);
            $(".lbltextherePL").text(Result + '...............');
            $('.lbltextherePL').attr('title', LocationNames);  
        }
        else { $(".lbltextherePL").text(LocationNames); }
        $(".hdnLocationName").val(LocationNames);
        $(".hdnLocationsId").val(Locationids); 
        $("[id$='hdnLocationIds']").val(Locationids);
    }
    $("#LoadLocationListDiv").hide();
    //$('.hdnattendingids').val(attendingids);
    FilterClaims(0, true, Locationids);
}
function CheckedselectedLocationChkbox() {
    var i = 0;
    $(".tbodyLocationList > tr").each(function () {
        var locationid = $.trim($(".hdnLocationsId").val());
        var splitlocationid = locationid.split(',');
        var PracticeLocationsId = $.trim($(this).find('.hdnPracticeLocationsId').val())
        for (j = 0; j <= splitlocationid.length; j++){
            if (PracticeLocationsId == splitlocationid[j]) {
                $(this).find('#chkBox').prop('checked', true);
            }
         }       
        i++;
        var locationName = $.trim($(".hdnLocationName").val());
        var stringlength = locationName.length
        if (stringlength > 30) {
            var Result = locationName.substr(0, 30);
            $(".lbltextherePL").text(Result + '...............');
            $('.lbltextherePL').attr('title', locationName);
        }
        else { $(".lbltextherePL").text(locationName); }
    });
    var TotalRows = $('.tbodyLocationList tr').length;
    var numberOfChecked = $('input:checkbox:checked').length;
    if (TotalRows == numberOfChecked) {
        $('#chkBoxALL').attr('checked', 'checked');
    } else { $('#chkBoxALL').removeAttr('checked');}
}
function Check_AllCheckBoxs() {
    var $allCheckbox = $('.allCheckboxPL :checkbox');
    var $checkboxes = $('.singleCheckboxPL :checkbox');
    $allCheckbox.change(function () {
        if ($allCheckbox.is(':checked')) {
            $checkboxes.attr('checked', 'checked');
            $(".lbltextherePL").text("All");
        }
        else {
            $checkboxes.removeAttr('checked');
            $(".lbltextherePL").text("");
        }
    });
    $checkboxes.change(function () {
        if ($checkboxes.not(':checked').length) {
            $allCheckbox.removeAttr('checked');
            $(".lbltextherePL").text("");
        }
        else {
            $allCheckbox.attr('checked', 'checked');        
        }
    });
}
//end by Syed Sajid Ali

/// Modified By Irfan Mahmood 9/August/2022 : Add Provider Filter

function SelectProviderName(elem) {
    debugger
    var ProviderId = "";

    $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            ProviderId += $(this).parent().find("span").html() + ",";
        }
    });
    if (ProviderId.length > 0) {
        debugger
        ProviderId = ProviderId.slice(0, -1);
    }
    if (ProviderId != "") {
        $(elem).closest("#divReportServiceProvider").find(".selectedText").text("");
        var b = $(elem).closest("#divReportServiceProvider").find(".selectedText").val("");
        $(elem).closest("#divReportServiceProvider").find(".selectedText").text(ProviderId.substring(0, 35));
    }
}
function Report_ClickMultiCheckBox(elem) {
    debugger
    var CurrentUl = $(elem).closest("ul");
    var CurrentUlId = $(elem).closest("ul").attr("id");

    if (CurrentUl.find(".chk-multi-checkboxes").length == CurrentUl.find(".chk-multi-checkboxes:checked").length) {
        CurrentUl.find(".chk-multi-checkboxes-all").prop("checked", true);
        $(elem).parentsUntil(".BranceInput").find(".selectedText").html("All Provider")
    }
    else {
        CurrentUl.find(".chk-multi-checkboxes-all").prop("checked", false);
    }

}
function Report_ClickMultiCheckBoxAll(elem) {
    debugger
    var CheckBox = $(elem).find(":checkbox");
    var CurrentUl = $(elem).closest("ul");
    CurrentUl.find(".chk-multi-checkboxes").prop("checked", CheckBox.is(":checked"))

    $(elem).closest("#divReportServiceProvider").find(".selectedText").text("");
    $(elem).closest("#divReportServiceProvider").find(".selectedText").text("All Providers")

}
function CancelProviders(elem) {
    debugger
    $("#chkServiceProviderAll").prop("checked", true)
    $(".chkPracticeLocation ").prop("checked", true)
    $(elem).closest("#divReportServiceProvider").find(".selectedText").text("All Providers")
    $(".divServiceProvider").css("display", "none")

    FilterClaims(0, true)
}
function CloseProviderDiv() {
    $(".divServiceProvider").css("display", "none")
}
/// Modified By Irfan Mahmood 9/August/2022 : Add Provider Filter
