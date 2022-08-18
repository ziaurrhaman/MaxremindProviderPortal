//Added By Rizwan 4May2018
/*Added By Faiza Bilal 2-2-2022 to get detail of Patient Balance Report*/

/*Added by Faiza bilal 3-24-2022*/
var TimeSpanPatBal = "";
var DateFromPatBal = "";
var DateToPatBal = "";
var type = "";
var level = "";
/*End Added by Faiza bilal 3-24-2022*/
var Params = "";
function GetPatBalReport(patientId) {
    debugger;
    var PatId = patientId;
    if (PatId == "") {
        PatId = 0;
    }

    var DateFrom = $("#" + SubReportDivName).find("[id$='PatientBalanceDateFrom']").val();
    var DateTo = $("#" + SubReportDivName).find("[id$='PatientBalanceDateTo']").val();
    var PracticeLocationId = $("#" + SubReportDivName).parentsUntil().find("[id$='hdnPracticeLocationId']").val();
    var ProviderId = $("#" + SubReportDivName).parentsUntil().find("[id$='hdnProviderId']").val();
    var DateType = $("#" + SubReportDivName).find("#ddlPostType").val();
    Params = {
        DateType: DateType, ProviderId: ProviderId, PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo, PatId

    }
    var title = "Patient Balance Summary";
    $.post("../../ProviderPortal/ReportsNew/filter/FilterPatientBalanceReport.aspx", Params, function (data) {
        var start = data.indexOf("###StartPatDet###") + 17;
        var end = data.indexOf("###EndPatDet###");
        var htmlresult = $.trim(data.substring(start, end));
        $("#dialoguePatientBal").html(htmlresult);

        $("#dialoguePatientBal").dialog({
            width: 1060,

            modal: true,
            title: title,
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Close": function () {

                    $("#dialoguePatientBal").html("");
                    $(this).dialog("destroy");
                }
            },
            close: function () {
                $("#dialoguePatientBal").html("");
                $(this).dialog("destroy");

            }
        });

    });
}
function GetPatBalFilter(Customize) {
    debugger
    var DateFrom = '';
    var DateTo = '';
    $(".message").hide();
    var Group = $("#ddlGroupBy option:selected").val();
    var PracticeLocationId = "";
    var ProviderId = "";
    var DateType = ""
    var DateCriteria = ""
    var Rows = ""
    var PageNumber = ""
    if (Group == "Provider") {

        $("#" + SubReportDivName).parentsUntil().find("[id$='PatientBalanceLocations'] #PatientBalanceLocationsChk").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='PatientBalanceLocations'] #chkPatientBalanceDynamicLocationsAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='PatientBalanceProviders'] #chkPatientBalanceProviders").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='PatientBalanceProviders'] #PatientBalanceProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });
    } else {

        $("#" + SubReportDivName).parentsUntil().find("[id$='PatientBalanceLocations'] #chkPatientBalanceLocation").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("[id$='PatientBalanceLocations'] #chkPatientBalanceLocationAll").each(function () {
            if ($(this).is(":checked")) {
                PracticeLocationId = "";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("#PatientBalanceDynamicProviders #PatientBalanceDynamicProviderChk").each(function () {
            if ($(this).is(":checked")) {
                ProviderId += $(this).val() + ",";
            }
        });
        $("#" + SubReportDivName).parentsUntil().find("#PatientBalanceDynamicProviders #DynamicPatientBalanceProviderChkAll").each(function () {
            if ($(this).is(":checked")) {
                ProviderId = "";
            }
        });
        if (ProviderId.length > 0) {
            ProviderId = ProviderId.slice(0, -1);
        }


        if (PracticeLocationId.length > 0) {
            PracticeLocationId = PracticeLocationId.slice(0, -1);
        }


    }
    if (Customize == "Customize") {
        DateCriteria = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlSelectDateCustomize"]').val()
        DateType = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlPostTypeCustomize"] option:selected').val();
        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="DateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="DateTo"]').val();
    } else {
        DateType = $("#" + SubReportDivName).find('[id$="ddlPostType"] option:selected').val();
        DateFrom = $("#" + SubReportDivName).find('[id$="PatientBalanceDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).find('[id$="PatientBalanceDateTo"]').val();
        DateCriteria = $("#" + SubReportDivName).find('[id$="ddlSelectDate"]').val()

    }

    $.post('../../ProviderPortal/ReportsNew/filter/FilterPatientBalanceReport.aspx', { action: "Filter", Rows: $("#ddlPaging").val(), PageNumber:0, DateType: DateType, ProviderId: ProviderId, PracticeLocationId: PracticeLocationId, DateFrom: DateFrom, DateTo: DateTo }, function (data) {
        debugger
        var result1 = "";
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        result1 = $.trim(data.substring(start, end));
        $(".tbodyPatientBalanceReport").html(result1);
        if ($(".tbodyPatientBalanceReport").find("tr").find(".AlignDate").html() == "" || $(".tbodyPatientBalanceReport").find("tr").find(".AlignDate").html() == undefined) {
            $(".message").show();
        }
        start = data.indexOf("###StartTotal###") + 16;
        end = data.indexOf("###EndTotal###");
        var returnHtml = $.trim(data.substring(start, end));
        $("[id$='hdnTotalRows']").val(returnHtml);
        $(".totalRows").html("Total Rows : " + $("[id$='hdnTotalRows']").val())
        Rows1 = $("#ddlPaging").val();
        GenerateReportPaging($("[id$='hdnTotalRows']").val(), Rows1);
        SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
        SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
        $("#" + filename2).empty();
        var PagesRows = Rows;
        $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + PagesRows + '" id = "' + PagesRows + '"  style="display:none" >' + PagesRows + '</div>');
        $("#TimeSpan").hide();
        debugger
        $('[id$="dateFromCustomize"]').val(DateFrom);
        $('[id$="dateToCustomize"]').val(DateTo);
        $('[id$="DateFrom"]').val(DateFrom);
        $('[id$="DateTo"]').val(DateTo);
        $('[id$="ddlSelectDateCustomize"]').val(SelectDate);
        $('[id$="ddlSelectDate"]').val(SelectDate);
        $('[id$="ddlPostType"]').val(DateType);
        $('[id$="ddlPostTypeCustomize"]').val(DateType);

        var dateArF = DateFrom.split('-');
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = DateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $("[id$='txtDateFrom']").text(newDateFrom);
        $("[id$='txtDateTo']").text(newDateTo);
        // ShowHideMenu();
        //$("[id$='FilterReports']").prop("disabled", true);
        //  $(Customize).parent().parent().parent().parent().parent().find("#FilterReports").prop("disabled", true);
        $(".TimeSpan").css("display", "block");
        //start = data.indexOf("###StartTotal###") + 16;
        //end = data.indexOf("###EndTotal###");
        //var returnHtml = $.trim(data.substring(start, end));
        //$("[id$='hdnTotalRows']").val(returnHtml);
        //$(".totalRows").html("Total Rows : " + $("[id$='hdnTotalRows']").val())
    });
    /*Added By faiza Bilal 3-24-2022*/
    TimeSpanPatBal = TimeSpan;
    DateFromPatBal = DateFrom;
    DateToPatBal = DateTo;
    /*End Added By faiza Bilal 3-24-2022*/
    /*OpenReportPage('PatientBalanceReport.aspx', 'False', prams, 'PatientBalanceReport', "", 'Patient Balance Report');*/
}

/*End Added By Faiza Bilal 2-2-2022 to get detail of Patient Balance Report*/
function ExportReportForSummary(fileNameFromFile, elem, divid) {
    //Changes By Sajid Ali Date 5/18/2018



    debugger;
    var printdd = $(elem).attr('id');



    var divId = '#' + divid;


    $(divId).find('.center').css("position", "unset");

    var ddlValue = $('#' + printdd).val();
    if (ddlValue == 'Select') {
        ddlValue = elem.value;
          //ddlValue = $("[id$='ddlRDC'] option:selected").text();
        }
    var filter_name = "";
    if (fileNameFromFile != "") {
        filter_name = fileNameFromFile;
    }
    else {
        filter_name = filename;
    }




    var filtername_1 = filter_name
    var fullDate = new Date()
    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);
    var currentDate = fullDate.getDate() + "/" + twoDigitMonth + "/" + fullDate.getFullYear();



    if (ddlValue == "Excel") {
        debugger;
        var htmlToPrint = '' +
            '<style type="text/css">' +
            'table, th, td, .tbodyclass {' +
            'Text-align:center;' +
            'border:1px solid #000;' +
            'border-collapse:collapse;' +

            '}' +
            '</style>';
        var htmlofdivhere = $(divId).html();
        htmlToPrint += htmlofdivhere;

        $(".DivForPrintExcel").html(htmlToPrint);
        $(".Ins_TdAction").remove();
        let file = new Blob([$('.DivForPrintExcel').html()], { type: "application/vnd.ms-excel" });
        let url = URL.createObjectURL(file);
        let a = $("<a />", {
            href: url,
            download: filtername_1 + " _ " + currentDate + ".xls"
        }).appendTo("body").get(0).click();
        $('#tblInsurancePortal thead th:last-child').after('<th class="asc InsTdAction Ins_TdAction"><span class="report-column-title">Action</span><span></span></th>');
        event.preventDefault();
        $(".DivForPrintExcel").html("");

    }
    //Changes By Sajid Ali Date 5/18/2018
    else if (ddlValue == "PDF") {
        $(".InsTdAction").hide();
        var PdfHtml = $(divId).html();
        var htmlToPrint = '' +
            '<style type="text/css">' +
            'table, th, table td {' +
            'Text-align:center;' +
            'border:1px solid #000;' +
            'border-collapse: collapse;' +
            'font-family:Arial;' +
            'padding:7px 4px;' +
            'font-size: 12px;' +
            'page-break-after:always;' +
            'overflow-wrap:break-word;' +
            '}' +
            '</style>';
        htmlToPrint += PdfHtml;//printContents.outerHTML;
        newWin = window.open("");
        newWin.document.write(htmlToPrint);
        $(".InsTdAction").show();
        newWin.print();
        newWin.close();

    }
    //Changes By Sajid Ali Date 5/18/2018
    else if (ddlValue == "Word") {
        $(".InsTdAction").hide();
        let file = new Blob([$(divId).html()], { type: "application/vnd.document" });
        let url = URL.createObjectURL(file);
        let a = $("<a />", {
            href: url,
            download: filtername_1 + " _ " + currentDate + ".doc"
        }).appendTo("body").get(0).click();
        $(".InsTdAction").show();
        event.preventDefault();
    }
    //Changes By Sajid Ali Date 5/18/2018




    $(divId).find('.center').css("position", "relative");
    var myDDL= '#' + printdd;
    $(myDDL).val($(myDDL," option:first").val());
}


function PrintReoprt(divid) {


    var divId = '#' + divid;
    $(divId).find('.center').css("position", "unset");
    $(".InsTdAction").hide();
    var PdfHtml = $(divId).html();
    var htmlToPrint = '' +
        '<style type="text/css">' +
        'table, th, td {' +
        'Text-align:center;' +
        'border:1px solid #000;' +
        'border-collapse: collapse;' +
        'padding;3.5em;' +
        '}' +
        '</style>';
    htmlToPrint += PdfHtml;
    newWin = window.open("");
    newWin.document.write(htmlToPrint);
    $(".InsTdAction").show();
    newWin.print();
    newWin.close();

    $(divId).find('.center').css("position", "relative");
}

function RejDenSummary(payer, status) {
    debugger;
    if (payer == "") {
        payer = $("[id$='hdnPayer']").val();
    }

    var aging = $("[id$='hdnAging']").val();
    var BilledAs = $("[id$='hdnBilledAs']").val();
    var Location = $("[id$='hdnLocation']").val();
    var ProviderId = $("[id$='hdnProviderId']").val();

    $.post("../../providerportal/ReportsNew/filter/FilterRejectedDeniedSummaryAndDetail.aspx", { payer: payer, status: status, aging: aging, BilledAs: BilledAs, ProviderId: ProviderId, Location: Location
    }, function (data) {
        debugger
        var start = data.indexOf("###Start###") + 19;
        var end = data.indexOf("###End###");
        var htmlresult = $.trim(data.substring(start, end));

        $(".dialogue").html(htmlresult);

        $(".dialogue").dialog({
            width: 1060,

            modal: true,
            title: "Detail",
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Close": function () {

                    $(this).dialog("destroy");
                    $("#dialogue").hide();


                }
            },
            close: function () {

                $(this).dialog("destroy");
                $("#dialogue").hide();

            }
        });

    });
}

function claimDetail(Level, Type, PageNumber, NRows) {
    debugger
    /*Edited By faiza Bilal 3-29-2022*/
    var DateFromC = '';
    var DateToC = '';
    var datetype = '';
    type = Type;
    level = Level;
    if ($('#hdnFilterStartDate').val() == undefined) {
        DateFromC = DateFrom;
        DateToC = DateTo;
        datetype = $('#hdnDateType').val() || $('#hdnDateType').val('PostDate');
    }
    else {
        DateFromC = $('#hdnFilterStartDate').val();
        DateToC = $('#hdnFilterEndDate').val();
        datetype = $('#hdnFilterDateType').val();
    }
    if (PageNumber == "" || PageNumber == undefined) {
        PageNumber = 0;
    }
    if (NRows == "" || NRows == undefined) {
        NRows = 10;
    }

    var PracticeLocationId = $('#hdnPracticeLocationId').val();
    var ProviderId = $('#hdnProviderId').val();
    var claimid = $('#hdnclaimid').val();
    var BillAs = $('#hdnBillAs').val();
    var MultipleCPTs = $('#hdnCPTS').val();
    var ClaimStatus = $('#hdnClaimStatus').val();
    var PayerScenario = $("#hdnpayerid").val();

    var prams =
    {
        PracticeLocationId: PracticeLocationId,
        ProviderId: ProviderId,
        claimid: claimid,
        Datetype: datetype,
        DateFrom: DateFromC,
        DateTo: DateToC,
        Level: level,
        Type: type,
        MultipleCPTs: MultipleCPTs,
        BillAs: BillAs,
        Payerid: PayerScenario,
        ClaimStatus: ClaimStatus,
        Rows: NRows,
        PageNumber: PageNumber
    };
    debugger;
    /*End Edited By faiza Bilal 3-29-2022*/
    var start1 = "";
    var end1 = "";
    var title = "";
    if (level == "CLM") {
        start1 = "###StartCLMDetail###";
        end1 = "###EndCLMDetail###";
        title = "Claim Detail";
        if (type == 'P') { title = "Paid Claim Detail"; }
        else if (type == 'U') { title = "UnPaid Claim Detail"; }
        else if (type == 'A') { title = "Adjusted Claim Detail"; }
    }
    else {
        start1 = "###StartProcedureDetail###";
        end1 = "###EndProcedureDetail###";
        title = "Procedure Detail";
        if (type == 'P') { title = "Paid CPT Detail"; }
        else if (type == 'U') { title = "UnPaid CPT Detail" }
        else if (type == 'A') { title = "Adjusted CPT Detail"; }
    }


    $.post("../../ProviderPortal/ReportsNew/filter/FilterClaimSummaryAndDetail.aspx", prams, function (data) {
        debugger
        var start = data.indexOf(start1) + 26
        var end = data.indexOf(end1);

        var htmlresult = $.trim(data.substring(start, end));
        /*Edited by Faiza Bilal 3-30-2022 to overcome divs overlay issue*/
        $(".dialogueClaim").html(htmlresult);
        if (level == "") {
            $(".totalRows").html("Total Rows : " + $("[id$='hdnInsRowsCPT']").val());
            GenerateReportPaging($("[id$='hdnInsRowsCPT']").val(), NRows);
        }
        else {
            $(".totalRows").html("Total Rows : " + $("[id$='hdnInsRowsClaimSummary']").val());
            GenerateReportPaging($("[id$='hdnInsRowsClaimSummary']").val(), NRows);
        }
        debugger
        $(".Reports_Rows_Per_Page").css("display", "");
        $(".Pagination_div").css("display", "");
        $(".message_box").css("display", "");
        $(".ClaimSummaryPagination").css("display", "");
        $(".txt_page_Number").val("1")
        $(".dialogueClaim").dialog({
            width: 1060,

            modal: true,
            title: title,
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999");
            },
            buttons: {
                "Close": function () {
                    /*Added b faiza Bilal 2-16-2022 to remove bug of overlapping dialogue div in  ClaimAndSummary report*/
                    $(".dialogueClaim").html("");
                    $(this).dialog("destroy");
                    $("#dialogue").hide();
                    $(".Report_Footer ").hide();


                }
            },
            close: function () {
                $(".dialogueClaim").html("");
                /*Added b faiza Bilal 2-16-2022 to remove bug of overlapping dialogue div in  ClaimAndSummary report*/
                $(this).dialog("destroy");
                $("#dialogue").hide();
                $(".Report_Footer ").hide();
                /*End Edited by Faiza Bilal 3-30-2022 to overcome divs overlay issue*/
            }
        });

        if (type == 'U' && level == 'CLM') {
            $('.thDueAmt').show();

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

        }
        if (type == 'P' && level == 'CLM') {
            $('.thPaidAmt').show();

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
        if (type == 'A' && level == 'CLM') {
            $('.thclmstatus').show();

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");
        }
        if (type == 'U' && level == '') {
            $('.thDueAmt').show();

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
        if (type == 'P' && level == '') {
            $('.thPaidAmt').show();

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
    });
}


function loadServiceCode(event, elem) {

    var a = event.which || event.keyCode;
    var Serviecode = $.trim($("#txtServiceCode").val()) || "";
    if (Serviecode == "") { $(".divServicecode").hide(); return };
    if (a == 13) {

        searchCPTs('C', elem.value, '', elem, event);
    }


}


function SelectServiceCode(code) {
    var servicecode = code;
    var servicecodecount = 0;
    $(".divselectedServiceCode").find(".spnservicecode").each(function () {
        var thisservicecode = $.trim($(this).text());

        if (servicecode == thisservicecode) { servicecodecount++; }
    });

    if (servicecodecount > 0) { showErrorMessage("Service Code already selected!"); }
    else {
        $(".divselectedServiceCode").append("<span class='spanservice' style='background-color: lightgray; padding: 8px; margin: 1px;'><strong class='strongtest'><Span class='spnservicecode'> " + servicecode + "</span><img onclick='removeServiceCode(this)' style='height:10px;margin-left:10px;' src='../../Images/crossA.png' class='crossA' title='Remove'></strong></span>");
    }

    $(".divServicecode").hide();
    $("[id$='txtServiceCode']").val("");
}

function removeServiceCode(elem) {
    $(elem).closest('.spanservice').remove();
}

function InsuranceDetail(elem) {

    debugger;
    //var cpts = $('#hdnCPTs').val();
    var cpts = $.trim($(elem).closest("tr").find(".tdCPT").text());
    var insuranceIds = $('#hdnInsuranceIds').val();
    var insuranceType = $('#hdnInsurancetype').val();
    var selectedInsurance = $.trim($(elem).find('.hdnInsuranceid').val());

    var prams =
    {
        CPTS: cpts,
        InsuranceIds: insuranceIds,
        InsuranceType: insuranceType,
        SelectInsurance: selectedInsurance,
        ProviderId: $("[id$='hdnProviderId']").val(),
        Location: $("[id$='hdnLocation']").val(),
    };

    $.post("../../ProviderPortal/ReportsNew/filter/filterProcedurePaymentsSummaryAndDetail.aspx", prams, function (data) {
        debugger

        var start = data.indexOf("###StartFilter###") + 17
        var end = data.indexOf("###EndFilter###");

        var htmlresult = $.trim(data.substring(start, end));

        $(".DetaildialogueBox").html(htmlresult);

        $(".DetaildialogueBox").dialog({
            width: 1060,

            modal: true,
            title: "Procedure Payment Detail",
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Close": function () {

                    $(this).dialog("destroy");
                    $("#dialogue").hide();


                }
            },
            close: function () {

                $(this).dialog("destroy");
                $("#dialogue").hide();

            }
        });

    });
}

function CPTDetail(elem) {
    debugger
    var cpts = $('#hdnCPTs').val();
    var insuranceIds = $('#hdnInsuranceIds').val();
    var insuranceType = $('#hdnInsurancetype').val();
    var selectedCpt = $.trim($(elem).text());

    var prams =
    {
        ProviderId: $("[id$='hdnProviderId']").val(),
        Location: $("[id$='hdnLocation']").val(),
        CPTS: cpts,
        InsuranceIds: insuranceIds,
        InsuranceType: insuranceType,
        SelectCPT: selectedCpt
    };

    $.post("../../Providerportal/ReportsNew/filter/filterProcedurePaymentsSummaryAndDetail.aspx", prams, function (data) {


        var start = data.indexOf("###StartFilter###") + 17
        var end = data.indexOf("###EndFilter###");

        var htmlresult = $.trim(data.substring(start, end));

        $(".dialogue").html(htmlresult);

        $(".dialogue").dialog({
            width: 1060,

            modal: true,
            title: "Procedure Payment Detail",
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Close": function () {

                    $(this).dialog("destroy");
                    $("#dialogue").hide();


                }
            },
            close: function () {

                $(this).dialog("destroy");
                $("#dialogue").hide();

            }
        });

    });

}

function FilterUnPaidInsurance(Customize) {
    debugger
    //var Rows = $("#ddlPaging").val();
    var Payers = "";
    var unpaidInsurance = "";
    var PracticeLocationId = "";
    var StaffNPI = "";
    var DateOfService = "";
    var SelectDate = "";
    var DateType = "";
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").each(function () {

        if ($(this).is(":checked")) {
            unpaidInsurance += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes-all").each(function () {

        if ($(this).is(":checked")) {
            unpaidInsurance = "";
        }
    });
    if (unpaidInsurance.length > 0) {
        unpaidInsurance = unpaidInsurance.slice(0, -1);
    }
    $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryLocations'] #chkClaimSummaryLocations").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId += $(this).val() + ",";
        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ClaimSummaryLocations'] #chkClaimSummaryLocationsAll").each(function () {
        if ($(this).is(":checked")) {
            PracticeLocationId = "";
        }
    });

    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            StaffNPI += $(this).val() + ",";
        }
    });
    $("#" + SubReportDivName).parentsUntil().find("[id$='ulMultiServiceProvider'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            StaffNPI = ""
        }
    });

    if (StaffNPI.length > 0) {
        StaffNPI = StaffNPI.slice(0, -1);
    }

    if (PracticeLocationId.length > 0) {
        PracticeLocationId = PracticeLocationId.slice(0, -1);
    }
    if (Customize == "Customize") {


        DateFrom = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateFrom"]').val();
        DateTo = $("#" + SubReportDivName).parentsUntil().find('[id$="CustomizeDateTo"]').val();
        DateOfService = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlDateOfService"] option:selected').val();
        DateType = $("#" + SubReportDivName).parentsUntil().find('[id$="ddlPostTypeCustomize"] option:selected').val();
        SelectDate = $("#" + SubReportDivName).parentsUntil().find("#ddlSelectDateCustomize").val();


    } else {
        DateOfService = $("#" + SubReportDivName).find('[id$="ddlDateOfService"] option:selected').val();
        DateFrom = $("#" + SubReportDivName).find("#DateFrom").val();
        DateTo = $("#" + SubReportDivName).find('[id$="DateTo"]').val();
        SelectDate = $("#" + SubReportDivName).find("#ddlSelectDate").val();
        DateType = $("#" + SubReportDivName).find('[id$="ddlPostType"] option:selected').val();
    }
    var params = {
        BillDateFrom: DateFrom,
        BillDateTo: DateTo, DateType: DateType, DateOfService: DateOfService, PayerId: unpaidInsurance, PracticeLocationId: PracticeLocationId, ProviderId: StaffNPI, PageNumber: 0
    }

    Report_ReloadData("FilterUnpaidInsuranceClaimsReport.aspx", params, true)
    debugger
    $('[id$="dateFromCustomize"]').val(DateFrom);
    $('[id$="dateToCustomize"]').val(DateTo);
    $('[id$="DateFrom"]').val(DateFrom);
    $('[id$="DateTo"]').val(DateTo);

    $("#ddlSelectDateCustomize").val(SelectDate);
    $("#ddlSelectDate").val(SelectDate);
    $("#ddlPostTypeCustomize").val(DateType);
    $("#ddlPostType").val(DateType);
    var dateArF = DateFrom.split('-');
    var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
    var dateArT = DateTo.split('-');
    var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
    $("[id$='ReportDateFrom']").val(DateFrom);
    $("[id$='ReportDateTo']").val(DateTo);
    $("[id$='txtDateFrom']").text(newDateFrom);
    $("[id$='txtDateTo']").text(newDateTo);





    //start = data.indexOf("###StartTotal###") + 16;
    //end = data.indexOf("###EndTotal###");
    //var a = $.trim(data.substring(start, end));
    //returnHtml = "Total Rows : " + a;
    //if (a == 0) {
    //    $(".message").html("No Record Found, Please change search criteria").show();
    //}
    //else {
    //    $(".message").html("");
    //}
    //$('[id$="txtDateFrom"]').val(DateFrom);
    //$('[id$="txtDateTo"]').val(DateTo);
    //$('[id$="dateFromCustomize"]').val(DateFrom);
    //$('[id$="dateToCustomize"]').val(DateTo);
    //$('[id$="DateFrom"]').val(DateFrom);
    //$('[id$="DateTo"]').val(DateTo);
    //$(".totalRows").html(returnHtml);
    //var start = data.indexOf("###TimeSpanStart###") + 19;
    //var end = data.indexOf("###TimeSpanEnd###");
    //var returnHtml = $.trim(data.substring(start, end));
    //$('[id$="TimeSpan"]').text(returnHtml)

}
function FilterPatientDetail(elem) {
    debugger
    var StartDate = $("#DateFrom").val();
    var EndDate = $("#DateTo").val();
    var Rows = $("#ddlPaging").val();
    var Payers = "";
    var unpaidInsurance = "";
    var PracticeLocationId = "";
    var StaffNPI = "";
    var DateOfService = $("#ddlDateOfService option:selected").val();
    var GroupBy = $("#ddlGroupBy").val();
    $("[id$='ulMultiPayerScenario'] #chkPayerScenarioPaymentsDetail").each(function () {
        if ($(this).is(":checked")) {
            Payers += $(this).tex() + ",";

        }
    });
    $("[id$='ulMultiPayerScenario'] #chkPayerScenarioPaymentsDetailAll").each(function () {
        if ($(this).is(":checked")) {
            Payers = "";
        }
    });
    $("[id$='ulMultiUnpaidinsurances'] .chk-multi-checkboxes").each(function () {

        if ($(this).is(":checked")) {
            unpaidInsurance += $(this).parent().find("input[type='hidden']").val() + ",";
        }
    });

    if ($("[id$='chkUnpaidinsurancesAll']").is(':checked')) {

        unpaidInsurance = '';
    }
    if (unpaidInsurance.length > 0) {
        unpaidInsurance = unpaidInsurance.slice(0, -1);
    }


    $.post('filter/FilterPatientBalanceDetailReport.aspx', { action: "FilterPaymentApplicationSummary", DateFrom: DateFrom, DateTo: DateTo, Rows: Rows, unpaidInsurance: unpaidInsurance, PracticeLocationId: PracticeLocationId, StaffNPI: StaffNPI }, function (data) {
        debugger
        var start = data.indexOf("###Start###") + 12;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbodyReportList").html(returnHtml)
            .promise()
            .done(function () {

            });
        start = data.indexOf("###StartTotal###") + 16;
        end = data.indexOf("###EndTotal###");
        returnHtml = "Total Rows : " + $.trim(data.substring(start, end));


        $(".totalRows").html(returnHtml);
    });
}
function ProvidersClaimDetail() {
    debugger

}
function PatientTransactionDetail(PatientId) {
    debugger
    var DateFrom = $("[id$='DateFrom']").val();
    var DateTo = $("[id$='DateTo']").val();
    var DateType = $("#ddlPostType").val();

    Params = {
        DateFrom: DateFrom, DateTo: DateTo, PatientId: PatientId

    }
    var title = "Patient Transaction Detail";
    $.post("CallBacks/PatientTransactionsSummaryDetail.aspx", Params, function (data) {
        var start = data.indexOf("###TransactionsSummaryDetail###") + 31;
        var end = data.indexOf("###EndTransactionsSummaryDetail###");
        var htmlresult = $.trim(data.substring(start, end));
        $("#divDialogPatientTransactionDetail").html(htmlresult);

        $("#divDialogPatientTransactionDetail").dialog({
            width: 1060,

            modal: true,
            title: title,
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Close": function () {

                    $("#divDialogPatientTransactionDetail").html("");
                    $(this).dialog("destroy");
                }
            },
            close: function () {
                $("#divDialogPatientTransactionDetail").html("");
                $(this).dialog("destroy");

            }
        });

    });
}
function ProviderWiseDetail(Provider) {
    debugger
    if (Provider == "") {
        Provider = $("[id$='hdnProvider']").val();
    }

    var DateFrom = $("[id$='hdnDateFrom']").val();
    var DateTo = $("[id$='hdnDateTo']").val();
    var DateType = $("[id$='hdnDateType']").val();
    var Location = $("[id$='hdnLocation']").val();
    var Payer = $("[id$='hdnPayer']").val();

    $.post("../../providerportal/ReportsNew/filter/FilterProviderCollectionReport.aspx", {
        Provider: Provider, DateFrom: DateFrom, DateTo: DateTo, DateType: DateType, Location: Location, Payer: Payer, action: "FilterDetail"
    }, function (data) {
        debugger
        var start = data.indexOf("###startReport###") + 17;
        var end = data.indexOf("###endReport###");
        var htmlresult = $.trim(data.substring(start, end));

        $(".ProviderWiseDetail").html(htmlresult);

        $(".ProviderWiseDetail").dialog({
            width: 1060,

            modal: true,
            title: "Detail",
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Close": function () {

                    $(this).dialog("destroy");
                    $("#dialogue").hide();


                }
            },
            close: function () {

                $(this).dialog("destroy");
                $("#dialogue").hide();

            }
        });

    });
}
function claimDetailFilters(PageNumber, NRows, level, Type) {
    debugger
    /*Edited By faiza Bilal 3-29-2022*/
    var DateFromC = '';
    var DateToC = '';
    var datetype = '';
    type = Type;
    if ($('#hdnFilterStartDate').val() == undefined) {
        DateFromC = DateFrom;
        DateToC = DateTo;
        datetype = $('#hdnDateType').val() || $('#hdnDateType').val('PostDate');
    }
    else {
        DateFromC = $('#hdnFilterStartDate').val();
        DateToC = $('#hdnFilterEndDate').val();
        datetype = $('#hdnFilterDateType').val();
    }
    if (PageNumber == "" || PageNumber == undefined) {
        PageNumber = 0;
    }
    if (NRows == "" || NRows == undefined) {
        NRows = 10;
    }

    var PracticeLocationId = $('#hdnPracticeLocationId').val();
    var ProviderId = $('#hdnProviderId').val();
    var claimid = $('#hdnclaimid').val();
    var BillAs = $('#hdnBillAs').val();
    var MultipleCPTs = $('#hdnCPTS').val();
    var ClaimStatus = $('#hdnClaimStatus').val();
    var PayerScenario = $("#hdnpayerid").val();

    var prams =
    {
        PracticeLocationId: PracticeLocationId,
        ProviderId: ProviderId,
        claimid: claimid,
        Datetype: datetype,
        DateFrom: DateFromC,
        DateTo: DateToC,
        Level: level,
        Type: type,
        MultipleCPTs: MultipleCPTs,
        BillAs: BillAs,
        Payerid: PayerScenario,
        ClaimStatus: ClaimStatus,
        Rows: NRows,
        PageNumber: PageNumber
    };
    debugger;
    /*End Edited By faiza Bilal 3-29-2022*/
    var start1 = "";
    var end1 = "";
    var title = "";
    if (level == "CLMFilter") {
        start1 = " ###StartCLMDetailAfterpagenation###";
        end1 = " ###ENDCLMDetailAfterpagenation###";
        title = "Claim Detail";
        if (type == 'P') { title = "Paid Claim Detail"; }
        else if (type == 'U') { title = "UnPaid Claim Detail"; }
        else if (type == 'A') { title = "Adjusted Claim Detail"; }
    }
    else {
        start1 = "###StartPRODetailAfterpagenation###";
        end1 = "###ENDPRODetailAfterpagenation###";
        title = "Procedure Detail";
        if (type == 'P') { title = "Paid CPT Detail"; }
        else if (type == 'U') { title = "UnPaid CPT Detail" }
        else if (type == 'A') { title = "Adjusted CPT Detail"; }
    }


    $.post("../../ProviderPortal/ReportsNew/filter/FilterClaimSummaryAndDetail.aspx", prams, function (data) {
        debugger
        var start = data.indexOf(start1) + 35
        var end = data.indexOf(end1);

        var htmlresult = $.trim(data.substring(start, end));
        /*Edited by Faiza Bilal 3-30-2022 to overcome divs overlay issue*/
       
        if (level == "ProcedureFilter") {
            $("#tbodyChargedProcedure").html(htmlresult);
            $(".totalRows").html("Total Rows : " + $("[id$='hdnInsRowsCPT']").val());
            //$("#ddlClaimSummaryDetailCPT").val(NRows);
            GenerateReportPaging($("[id$='hdnInsRowsCPT']").val(), NRows);
          
            if (PageNumber == 0) {
                $('.txt_page_Number').val("1")
            }
        }
        else {
            $("#tbodyChargedClm").html(htmlresult);
            $(".totalRows").html("Total Rows : " + $("[id$='hdnInsRowsClaimSummary']").val());
            GenerateReportPaging($("[id$='hdnInsRowsClaimSummary']").val(), NRows);
            if (PageNumber == 0) {
                $('.txt_page_Number').val("1")
            }
        }
        $(".Reports_Rows_Per_Page").css("display", "");
        $(".Pagination_div").css("display", "");
        $(".message_box").css("display", "");
        $(".ClaimSummaryPagination").css("display", "");
        if (type == 'U' && level == 'CLM') {
            $('.thDueAmt').show();

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

        }
        if (type == 'P' && level == 'CLM') {
            $('.thPaidAmt').show();

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
        if (type == 'A' && level == 'CLM') {
            $('.thclmstatus').show();

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");
        }
        if (type == 'U' && level == '') {
            $('.thDueAmt').show();

            $('.thPaidAmt').html("");
            $(".thPaidAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
        if (type == 'P' && level == '') {
            $('.thPaidAmt').show();

            $('.thDueAmt').html("");
            $(".thDueAmt").css("display", "none");

            $('.thclmstatus').html("");
            $(".thclmstatus").css("display", "none");
        }
    });
}