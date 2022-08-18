var value = ""; var txt = ""; var SplitStringPram = "false"; var checkValue = false; var ids = ""; var FirstSelectedId = "";
function SearchReportddlRecord(ddlName, elem)
{
    debugger;
    var SearchValue = $(elem).closest(".reportdropdownNew").find(".SearchTextBoxForRpt").val();
    if (ids == 0 || ids=="")
    {
        ids = $(elem).closest(".reportdropdownNew").find(".SplitIds").val() || 0;
    }
   
    $(".div-multi-checkboxes-wrapper").hide();
    
    if (ids != 0)
    {
        var array = [];
        array = ids.split(',');

        var arr =array.length;

        if (arr > 1)
        {
            SplitStringPram = "true";
        }

     
    }

    if (ddlName == "divPatientName")
    {
        SearchPatientddl(SearchValue, SplitStringPram);
    }
    else if (ddlName == "divDenailPayerName")
    {
        SearchInsuranceddl(SearchValue, SplitStringPram);
    }
    else if (ddlName == "divPayerScenario1")
    {
        debugger;
        var SearchValue = $(elem).closest(".reportdropdownNew").find(".SearchRecord").val();
        SearchPayerFromClaimddl(SearchValue, SplitStringPram, elem);
        //Added By Asad Mehmood
        $('#divPracticeLocation').hide();
        $('#divPlaceOfService').hide();
        $('#divCalimStatus').hide();
        $('#divFileStatus').hide();
      
       
    }

   
}



function SearchPatientddl(SearchValue, SplitStringPram) {
    $.post("../../ProviderPortal/ReportsNew/filter/FilterDialoguePaymentsHandler.aspx", { SearchValue: SearchValue, Action: "PatientFromERA", SplitStringPram: SplitStringPram }, function (data) {
        debugger
        var start = data.indexOf("###StartPatSearch###") + 22;
        var end = data.indexOf("###EndPatSearch###");
        var htmlresult = $.trim(data.substring(start, end));
        $("#divPatientName").html(htmlresult);
        $("#divPatientName").show();
        //$(".dropDownIconNewSearch").hide();
    });
}

function SearchInsuranceddl(SearchValue, SplitStringPram) {
    $.post("../../ProviderPortal/ReportsNew/filter/FilterDialoguePaymentsHandler.aspx", { SearchValue: SearchValue, Action: "InsuranceFromERA", SplitStringPram: SplitStringPram }, function (data) {
        debugger
        var start = data.indexOf("###StartInsSearch###") + 22;
        var end = data.indexOf("###EndInsSearch###");
        var htmlresult = $.trim(data.substring(start, end));
        $("#divDenailPayerName").html(htmlresult);
        $("#divDenailPayerName").show();
        //$(".dropDownIconNewSearch").hide();
    });
}


function SearchPayerFromClaimddl(SearchValue, SplitStringPram,elem)
{
    debugger;
    $.post("../ReportsNew/FilterDialoguePaymentsHandler.aspx", { SearchValue: "", Action: "PayerFromClaim", SplitStringPram: SplitStringPram }, function (data) {
        var start = data.indexOf("###StartInsSearch###") + 22;
        var end = data.indexOf("###EndInsSearch###");
        var htmlresult = $.trim(data.substring(start, end));
        $("#divPayerScenario1").html(htmlresult);
        $('#hdhTotalPayers').val($('.chkDenailPayerName').length);
        var splited = $("#hdnSearchPayertxt1").val().split(',');
        $('#chkDenailPayerNameAll').prop('checked', false);
        $.each($('.chkDenailPayerName'), function (index, element) {
            let val = $(this).closest('label').find('#PatientId').val().trim()
            if (splited.find((ele) => { return val == ele; }) != undefined) {
                $(this).prop('checked', true);
            } else {
                $(this).prop('checked', false);
            }
        })
        let splitedchecked = $("#hdnSearchPayertxt1").val().split(',');
        let totalchecked = splitedchecked.slice(0, splitedchecked.length - 1);
        debugger;
        if (totalchecked.length == parseInt($('#hdhTotalPayers').val()) /*|| totalchecked.length == 0 || $('#hdnSearchPayertxt1').val()==""*/) {
            $('#SearchPayertxt1').val("ALL");
            $('.chkDenailPayerName').prop('checked', true);
            $('#chkDenailPayerNameAll').prop('checked', true);
        } else if ($('#hdnSearchPayertxt1').val() == "") {
            $('#SearchPayertxt1').val("ALL");
            $('.chkDenailPayerName').prop('checked', false);
            $('#chkDenailPayerNameAll').prop('checked', false);
        }
        $("#divPayerScenario1").show();
    if (ids != 0) {
            GetSelectedChkBoxChecked(elem, ids);
        }
    });
}


function Okfunc(elem)
{
        debugger;
        value = $(elem).closest(".reportdropdownNew").find(".SearchTextBoxForRpt").val();  
        debugger;
        var rownum = $(elem).closest(".okclosebtnforrpt").parent().find('.chk-multi-checkboxes').length;
        var checkedrownum = $(elem).closest(".okclosebtnforrpt").parent().find('.chk-multi-checkboxes:checked').length;
    var val = $("#SearchPayertxt1").val();
    var totalrows = parseInt($('#hdhTotalPayers').val());
    if ((totalrows == checkedrownum || (totalrows - checkedrownum) == totalrows))
        {
        $("#SearchPayertxt1").val("ALL");
        //$('#hdnSearchPayertxt1').val("");
        }
        else
        {
            debugger;
        var insuvalue = "";
        var hdninsValue = "";
            let boxes = $(elem).closest(".okclosebtnforrpt").parent().find('.chk-multi-checkboxes:checked');
        $.each($(boxes), function (index, ele) {
            insuvalue += $(this).parent().find('.ddltextname').text() + ',';
            hdninsValue += $(this).parent().find('#PatientId').val() + ','
        })
        let prev = $(".SearchTextBoxForRpt").val();
        let previd = $('#hdnSearchPayertxt1').val();
        if (insuvalue.trim() != "" && prev.indexOf(insuvalue.slice(0, insuvalue.length - 1)) == -1) {
            if (prev == "ALL") { prev = "";}
            $('.SearchTextBoxForRpt').val(prev + insuvalue);
        }
        if (hdninsValue.trim() != "" && previd.indexOf(hdninsValue.slice(0, hdninsValue.length - 1)) == -1) {
            $('#hdnSearchPayertxt1').val(hdninsValue);
        }
        if (hdninsValue == "") {
            if (totalrows == checkedrownum) {
                $('#hdnSearchPayertxt1').val("");
                $(elem).closest(".okclosebtnforrpt").parent().find('.chk-multi-checkboxes-all').attr("checked", true);
            }
        } else {
            $(elem).closest(".okclosebtnforrpt").parent().find('.chk-multi-checkboxes-all').attr("checked", false);
        }
        }
  
    //$(elem).closest(".div-multi-checkboxes-wrapper").hide();

    $("#divPayerScenario1").hide();

    $(".dropDownIconNewSearch").show();
    txt = "";
   
}

function Closefunc(elem)
{
    debugger;
  //$(elem).closest(".div-multi-checkboxes-wrapper").hide();
  $("#divPayerScenario1").hide();
    $(elem).closest(".div-multi-checkboxes-wrapper").find(".chk-multi-checkboxes-all").attr("checked", "true");
    $(".SearchTextBoxForRpt").val("ALL");
    $('#hdnSearchPayertxt1').val("")
  //$(elem).closest(".reportdropdownNew").find(".SearchTextBoxForRpt").val("");
  
  $(".dropDownIconNewSearch").show();
  ids = 0; FirstSelectedId = 0;
}

function SetSearch(event, ddlName, elem)
{
    debugger;
    var ids = $(elem).closest(".reportdropdownNew").find(".SplitIds").val() || 0;
    

    var evnt = event.which || event.keyCode;
    if (evnt == 13)
    {
        
        if (ddlName == "divPayerScenario") {
            FilterReportddlRecord(elem);
        } 
    }
}

function ddlHideShow(ddlName,elem)
{
    debugger;
    if ($("#" + ddlName).is(":visible"))
    {
        $("#" + ddlName).hide();
    }
    else {
        $("#" + ddlName).show();
    }

    var txtall = $.trim( $(elem).closest(".reportdropdown").find(".selectedText").text());
    if (txtall == "All")
    {
            $(elem).closest(".reportdropdown").parent().find('.chk-multi-checkboxes-all').attr('checked', true);
            $(elem).closest(".reportdropdown").find(".SearchTextBoxForRpt").val("All");
          
        }
    }




function FilterReportddlRecord(elem)
{
    var SearchValue = $(elem).closest(".reportdropdownNew").find(".SearchRecord").val();
    
    //if (FirstSelectedId.length > 0) {
    //    FirstSelectedId = FirstSelectedId.slice(0, -1);
    //}
    //$.post("../ReportsNew/FilterDialoguePaymentsHandler.aspx", { SearchValue: SearchValue, Action: "PayerFromClaim" }, function (data) {
    //    debugger
    //    var start = data.indexOf("###StartInsSearch###") + 22;
    //    var end = data.indexOf("###EndInsSearch###");

    //    var htmlresult = $('<output>').append($.parseHTML($.trim(data.substring(start, end))));
    //    $("#ulMultiDenailPayerNameID").html($("#ulMultiDenailPayerNameID", htmlresult).html());
    //    if ($("#hdnSearchPayertxt1").val() == "" || $("#hdnSearchPayertxt1").val() == "ALL") {
    //        $('.chkDenailPayerName').prop('checked', true);
    //        $('#chkDenailPayerNameAll').prop('checked', true);
    //    } else {
    //        var splited = $("#hdnSearchPayertxt1").val().split(',');
    //        $('#chkDenailPayerNameAll').prop('checked', false);
    //        $.each($('.chkDenailPayerName'), function (index, element) {
    //            let val = $(this).closest('label').find('#PatientId').val().trim()
    //            if (splited.find((ele) => { return val == ele; }) != undefined) {
    //                $(this).prop('checked', true);
    //            } else {
    //                $(this).prop('checked', false);
    //            }
    //        })
    //    }
    //    $("#ulMultiDenailPayerNameID").show();
    //    //$(".dropDownIconNewSearch").hide();
    //});
    if (SearchValue == "") {
        $('.chkDenailPayerName').closest("li").show();
        return;
    }
    $.each($('.chkDenailPayerName'), function (index, element) {
        debugger;
        if ($(this).parent().find('.ddltextname').text().toLowerCase().indexOf(SearchValue.toLowerCase()) == -1) {
            $(this).closest("li").hide();
        }
    })
}


function GetSelectedChkBoxChecked(elem, ids)
{
   
   var txtall= $(elem).closest(".reportdropdownNew").find(".SearchTextBoxForRpt").val();

  
    var array = [];
    array = ids.split(',');
    var splitid="";
   
        $(elem).closest(".reportdropdownNew").parent().find('.chk-multi-checkboxes').each(function () {
        
            for (var i = 0; i <= array.length; i++)
            {

                splitid = array[i];

                var chkid = $(this).siblings('.ddltextname').next().val();

                if (splitid == chkid) {
                    $(this).attr("checked", true);
                    array.splice(i, 1);
                }
                else {
                    $(this).attr("checked", false);
                }
                
                return;
            }
           

        });
        debugger;
        var a = $(elem).closest(".reportdropdownNew").parent().find('.chk-multi-checkboxes' + ':checked').length;
       
        var b=$(elem).closest(".reportdropdownNew").parent().find('.chk-multi-checkboxes').length
        if ( a== b)
        {
            $(this).attr("checked", true);
            $(elem).closest(".reportdropdownNew").parent().find('.chk-multi-checkboxes-all').attr('checked', true);
            $(elem).closest(".reportdropdownNew").find(".SearchTextBoxForRpt").val("All");
        }

    
}


function ReportFilterAlert(elem) {
    debugger;
    var ProviderId = ""; var PlaceOfService = ""; var Location = "";
    var UnPaidInsurance = ""; var BilledAs = "";
    FirstSelectedId = ids;
    var ddl = $(elem).closest(".div-multi-checkboxes-wrapper").attr('id');

    if (ddl == "divServiceProvider") {
        $("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
            debugger
            if ($(this).is(":checked")) {

                ProviderId += $(this).parent().find("span").html() + ",";
            }
        });
        if (ProviderId.length > 0) {
            
            ProviderId = ProviderId.slice(0, -1);
        }

     
        $(elem).closest("#divReportServiceProvider").find(".selectedText").text("");
        var b = $(elem).closest("#divReportServiceProvider").find(".selectedText").val("");

        $(elem).closest("#divReportServiceProvider").find(".selectedText").text(ProviderId);
    }

    else if (ddl == "divPracticeLocation") {
        $("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                PlaceOfService += $(this).parent().find("span").html() + ",";
            }
        });
        if (PlaceOfService.length > 0) {

            PlaceOfService = PlaceOfService.slice(0, -1);
        }


        $(elem).closest("#divPracticeLocationId").find(".selectedText").text("");
        var b = $(elem).closest("#divPracticeLocationId").find(".selectedText").val("");

        $(elem).closest("#divPracticeLocationId").find(".selectedText").text(PlaceOfService);

    }


    else if (ddl == "divPlaceOfService") {
        $("[id$='ulMultiPlaceOfService'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                PlaceOfService += $(this).parent().find("span").html() + ",";
            }
        });
        if (PlaceOfService.length > 0) {

            PlaceOfService = PlaceOfService.slice(0, -1);
        }


        $(elem).closest("#divPlaceOfServiceReport").find(".selectedText").text("");
        var b = $(elem).closest("#divPlaceOfServiceReport").find(".selectedText").val("");

        $(elem).closest("#divPlaceOfServiceReport").find(".selectedText").text(PlaceOfService);

    }

    else if (ddl == "divPayerScenario") {
        var id = "";
        var value = $(elem).closest("#divReportPayerScenario").find(".hdnselectedText").val();
       
        

        debugger
        $("[id$='ulMultiDenailPayerName'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked"))
            {
                debugger
                PlaceOfService += $(this).parent().find("span").html() + ",";
                id += $.trim($(this).parent().find("#PatientId").val() + ",");

              
                if (FirstSelectedId != "")
                {
                    debugger
                    var array = [];
                    var n="";
                    if (FirstSelectedId != "")
                    {
                        array = FirstSelectedId.split(',');
                        id = id.slice(0, -1);
                         n = array.includes(id);
                       
                    }

                    if (n == true) {
                        FirstSelectedId = FirstSelectedId;
                    }
                    else {
                        FirstSelectedId = FirstSelectedId + id;
                    }
                    
                }
                 else {

                    
                     

                    FirstSelectedId = id;
                }
                if (value != "" && value != "All") {
                    value = value + "," + PlaceOfService;
                }

                else
                {
                    value = PlaceOfService;
                }

            }
            else {
                debugger
                PlaceOfService += $(this).parent().find("span").html() + ",";
                id += $.trim($(this).parent().find("#PatientId").val() + ",");
                var iid = "";
                var array = [];
                if (FirstSelectedId != "") {
                    array = FirstSelectedId.split(',');
                    iid = id.slice(0, -1);
                    var n = array.includes(iid);
                    
                }
                if (n == true)
                {
                    var index = array.indexOf(iid);
                    if (index !== -1) array.splice(index, 1);
                }
                FirstSelectedId = array;
                FirstSelectedId = FirstSelectedId + ',';
                }
        });
        if (PlaceOfService.length > 0)
        {

            PlaceOfService = PlaceOfService.slice(0, -1);
        }

    

        $(elem).closest("#divReportPayerScenario").find(".SplitIds").val(FirstSelectedId);
        ids = FirstSelectedId;
        $(elem).closest("#divReportPayerScenario").find(".selectedText").val(value);
        debugger
        if ($(elem).closest("#divReportPayerScenario").find(".hdnselectedText").val() == "")
        {
            $(elem).closest("#divReportPayerScenario").find(".hdnselectedText").val(value);
        }

    }

    else if (ddl == "divUnpaidinsurances") {
        $("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportUnpaidinsurances").find(".selectedText").text("");
        var b = $(elem).closest("#divReportUnpaidinsurances").find(".selectedText").val("");

        $(elem).closest("#divReportUnpaidinsurances").find(".selectedText").text(UnPaidInsurance);

    }

    else if (ddl == "divDenailPayerName") {
        var id = "";
        $("[id$='ulMultiDenailPayerName'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
                id += $.trim($(this).parent().find("#PatientId").val() + ",");
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportDenailPayerName").find(".selectedText").text("");
        var b = $(elem).closest("#divReportDenailPayerName").find(".selectedText").val("");

        $(elem).closest("#divReportDenailPayerName").find(".selectedText").val(UnPaidInsurance);
        $(elem).closest("#divReportDenailPayerName").find(".SplitIds").val(id);
    }

    else if (ddl == "divAdjustmentCode") {
        $("[id$='ulMultiAdjustmentCode'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportAdjustmentCode").find(".selectedText").text("");
        var b = $(elem).closest("#divReportAdjustmentCode").find(".selectedText").val("");

        $(elem).closest("#divReportAdjustmentCode").find(".selectedText").text(UnPaidInsurance);

    }
    else if (ddl == "divCalimStatus") {
        $("[id$='ulMultiCalimStatus'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportClaimStatus").find(".selectedText").text("");
        var b = $(elem).closest("#divReportClaimStatus").find(".selectedText").val("");

        $(elem).closest("#divReportClaimStatus").find(".selectedText").text(UnPaidInsurance);

    }
    else if (ddl == "divFileStatus") {
        var ClaimFiles = "";
        $("[id$='ulMultiFileStatus'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                ClaimFiles += $(this).parent().find("span").html() + ",";
            }
        });
        if (ClaimFiles.length > 0) {

            ClaimFiles = ClaimFiles.slice(0, -1);
        }


        $(elem).closest("#divFileSearch").find(".selectedText").text("");
        var b = $(elem).closest("#divFileSearch").find(".selectedText").val("");

        $(elem).closest("#divFileSearch").find(".selectedText").text(ClaimFiles);

    }
    else if (ddl == "divPatientName") {

        var id = "";

        $("[id$='ulMultiPatientName'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                UnPaidInsurance += $(this).parent().find("span").html() + ",";
                id += $.trim($(this).parent().find("#PatientId").val() + ",");
            }
        });
        if (UnPaidInsurance.length > 0) {

            UnPaidInsurance = UnPaidInsurance.slice(0, -1);
        }


        $(elem).closest("#divReportPatientName").find(".selectedText").text("");
        var b = $(elem).closest("#divReportPatientName").find(".selectedText").val("");

        $(elem).closest("#divReportPatientName").find(".selectedText").val(UnPaidInsurance);
        $(elem).closest("#divReportPatientName").find(".SplitIds").val(id);

    }


    else if (ddl == "divBilledAs1") {

        $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes").each(function () {

            if ($(this).is(":checked")) {

                BilledAs += $(this).parent().find("span").html() + ",";
            }

        });
        if (BilledAs.length > 0) {

            BilledAs = BilledAs.slice(0, -1);
        }
        $(elem).closest("#divReportBilledAs").find(".selectedText").text("");
        var b = $(elem).closest("#divReportBilledAs").find(".selectedText").val("");



        if ($("[id$='ulMultiBilledAs'] .chk-multi-checkboxes:checked").length == $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes").length) {
            $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes-all").attr('checked', true);

            $(elem).closest("#divReportBilledAs").find(".selectedText").text("All");
        }
        else {
            $("[id$='ulMultiBilledAs'] .chk-multi-checkboxes-all").attr('checked', false);
            $(elem).closest("#divReportBilledAs").find(".selectedText").text(BilledAs);

        }


    }

}