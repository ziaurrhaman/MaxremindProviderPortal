var _SortBy = '';
var _SortByValue = '';
var pageNumber = '';
var _isParameters = '';
var _selectedReport_Filter = '0';
var _Category = "";
var filename = "";
var filtername = "";
var PageLoadFileName = "";
var Reportsname = "";
var _count = 0;
var _ReportFilterFileName = "";
var _ReportFilterCategory = "";
var _ReportFilterIsParameters = "";
var _Report_div_id = "";
var _ForwardPageNum = "";
var OldPageRows = 0;
var HiddenDateTypeOfReport = "";
var TabFilename = "";
/*added By faiza Bilal 3-24-2022*/
var TimeSpanProvidercol = "";
var DateFromProvidercol = "";
var DateToProvidercol = "";
var TabContent = "";
/*End added By faiza Bilal 3-24-2022*/

$(document).ready(function () {

    $(".txtReportDateFrom").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");
    $(".txtReportDateTo").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");
    if (!checkModuleRights("ReportsView")) {
        $(".DivReportParent").hide();
        $("[id$='divRightsSettings']").html(_msg_ReportsView).show();
        return false;
    }
    $("[id$='txtReportDate']").datepicker({
        changeYear: true,
        changeMonth: true,
        maxDate: 0
    }).mask("99/99/9999");

    $("[id$='txtReportTo']").datepicker({
        setDate: '01/09/2016',
        changeYear: true,
        changeMonth: true,
        maxDate: 0
    }).mask("99/99/9999");
    var currentDate = new Date();
    $("[id$='txtReportDate']").datepicker('setDate', new Date(currentDate.getFullYear(), currentDate.getMonth(), 1));
    $("[id$='txtReportTo']").datepicker('setDate', currentDate);
    $("[id$='txtReportDate']").blur();
    //$("ul#ulMultiPayerScenario li:nth-child(2)").remove();



    $('.txt_page_Number').keydown(function (e) {

        if (e.which == 13) {
            return false;
        }
        else {

        }
    });

    //PageLoadFileName = "Top10Procedures.aspx";
    //loadReport("");

    $("#ddlPaging").change(function () {
        $(".common_Report").each(function () {

            if ($(this).is(':visible')) {
                var openddiv = $(this).attr("id");

                $("#" + openddiv).find("#hdnTotalRows").removeClass("txt-" + _ForwardPageNum);
                $("#" + openddiv).find("#hdnTotalRows").addClass("txt-1");

            }
        });
        $(".txt_page_Number").html("");
        $(".txt_page_Number").val("1");
    });

    $('#txtSearchReport').bind('keydown', function (event) {
        var key = event.which;
        if (key >= 48 && key <= 57) {
            event.preventDefault();
        }
    });
    debugger
    $(".InitialMsg").css("display", "block");
    //InitalMsg.show().html("<div>please select report from report menu</div>");

});

function loadReport(elem) {
    debugger
    ids = "";
    var color = "";
    var tabname = "";
    TabFilename = $(elem).text();

    filename = $.trim($(elem).closest('td').find('.lblReportfileName').text());
    var UserId = $("[id$='hdnUserIdMaster']").val();
    /*Edited by faiza Bilal 2-16-2022 to remove bug of hidden filter icon*/
    //const NoDialogueFilter = ["ReportPostClaims.aspx", "ClaimSummaryAndDetail.aspx", "ProviderCollectionReport.aspx", "CPTWiseCollection.aspx","Locationwisecollection.aspx","PatientBalanceReport.aspx"]
    /*Edited by faiza Bilal 2-16-2022 to remove bug of hidden filter icon*/
    //if (NoDialogueFilter.find(item => item == filename)) {
    //    $(".DialogueFilter").addClass("Hide");
    //    $(".Embeded_Filter").removeClass("Hide");
    //}
    //else {
    //    $(".Embeded_Filter").addClass("Hide");
    //    $(".DialogueFilter").removeClass("Hide");
    //}
    $('#ddlExportTo').get(0).selectedIndex = 0;

    _selectedReport_Filter = $.trim($(elem).closest('td').find('.lblReportFilterName').text());
    _isParameters = $.trim($(elem).closest('td').find('.ReportType').text());
    _Category = $.trim($(elem).closest('tr').attr('class'));

    var ReportSelected = $.trim($(elem).closest('td').find('.lblReportName').text());

    $("#reportdropdown tr").each(function () {

        /*        $(".chkSinglePendeingSubmission").each(function () {*/

        if ($(this).prop("checked") == true) {


        }

        $(elem).closest('td').addClass('td_highlight');
    });
    var Report_Name = $.trim($(elem).closest('td').find('.lblReportName').text());

    _ReportFilterFileName = filename.substring(0, filename.length - 5);
    //$(elem).closest('td').removeClass('td_highlight');
    var a = $(elem).closest('td').addClass('td_highlight');
    $(elem).closest('td').addClass(_ReportFilterFileName)
    debugger
    
    _ReportFilterCategory = _Category;
    _ReportFilterIsParameters = _isParameters;
    $('#Embeded_Filter').css("display", "")
    if (filename == "ClaimSummaryAndDetail.aspx") {
        //$("#DialogueFilter").hide();
        //$("#Embeded_Filter").show();
        $(".InitialMsg").css("display", "none");
    }

    if (_isParameters != "True") {
        $("#ReportFilterId").css("display", "none");
    }

    var SPFileName = filename.split(".");
    var SP_FileName = SPFileName[0];


    var colr = $(".widgetsReportTiles").css("background-color");
    debugger
    $(elem).find('.nametd').addClass('td_highlight');
    $(".widgetsReportTiles").each(function () {
        debugger
        var length = $(".widgetsReportTiles").length;
        tabname = $(this).attr("tabName");
        color = $(this).css("background-color");
        if (tabname == filename && color == ("rgb(0, 98, 145)")) {
            showErrorMessage("Report is already opened");
            $(this).css("border-color", "red");
            _count++;
            return false;
        }
        else {
            _count = 0;
        }


    });

    if (_count == 0) {


        var iffilenameissame = "";
        var countithere = 0;
        debugger
        $(".widgetsReportTiles").each(function () {
            var name = $(this).attr('id');
            if (name == "widgetsReportTiles" + filename && countithere == 0) {
                iffilenameissame = "widgetsReportTiles" + filename;
            }
        });
        debugger

        var a = $(".widgetsReportTiles").length;
        if (a > 4 && iffilenameissame == "") {
            showErrorMessage("Can not open more then 5 reports.close at least 1 report tab");
            // $(".widgetsReportTiles").last().css("background-color", "#02a7f9b8");
            return false;

        }

        //if (_isParameters == "True") {
        //    if (_Category == "Financial" || _Category == "Scheduling" || _Category == "Company") {
        //        var ReportTypeName = filename;
        //        filtername = ReportTypeName.substring(0, ReportTypeName.length - 5);

        //        OpenPaymentsFilterDialog(filtername, _isParameters, "", TabFilename);
        //        return;
        //    }
        //    if (_Category == "Patient") {
        //        var ReportTypeName = filename;
        //        filtername = ReportTypeName.substring(0, ReportTypeName.length - 5);

        //        debugger
        //        OpenPatientFilterDialog(filtername, _isParameters, TabFilename);

        //        return;
        //    }


        //}

        /*Edited by faiza Bilal 2-2-2022 to get report of Patient balance Report*/
        $(".InitialMsg").css("display", "none");
        OpenReportPage(filename, _isParameters, "", SP_FileName, "", TabFilename, Report_Name, elem);
        /*End Edited by faiza Bilal 2-2-2022 to get report of Patient balance Report*/

    }

}
var oldsreportname = "";
var ReportCount = 0;
var SubReportDivName = "";
var hiddenRows = 0;
var hiddenpaging = 0;
var DateFrom = "";
var DateTo = "";
var SelectDate = "";
var SelectDateType = "";
var filename2 = "";
var filename3 = "";
var filename4 = "";
var filename5 = "";
var OpenedReportSelectDateType = "";
var OpenedReportSelectDate = "";
function OpenReportPage(filename, _isParameters, prams, SP_FileName, _ReportFilterCount, TabFilename, Report_Name, elem) {
    debugger
    $(".widgetsReportTiles").each(function () {
        name = $(this).attr('tabname');
        oldsreportname = name;
        if (name == filename) {
            debugger
            oldsreportname = name;

            SubReportDivName = $(this).attr('tabparameters');
            hiddenRows = $("#" + SubReportDivName).find("[id$='hdnTotalRows']").val();
        }

    });
    $('.widgetsReportTiles').css('background-color', '#ececec');
    $('.widgetsReportTiles').css('border-color', '#439abf');
    $('.reportType').css('color', '#2b2727');


    $('#ddlPaging').val($('#select option').eq(0).val());

    if (filename == "") {
        filename = PageLoadFileName;
    }
    else {
        filename = filename;

        $(".widgetsReportTiles").each(function () {
            if ($(this).attr("tabName") == filename) {
                $(this).css("background-color", "#006291");
                $(this).children(".reportType").css('color', 'white');
            }
        });



    }
    filename2 = filename;
    filename3 = filename;
    filename2 = filename2.replace('.aspx', '');
    filename3 = filename3.replace('.as', '');
    var tabReport_Name = $(".openedreportfilename").text();
    debugger
    if (!tabReport_Name.match(filename)) {
        debugger
        var d = new Date();
        var day = d.getDate();
        var month = d.getMonth() + 1;
        var year = d.getFullYear();
        var lastMonth = d.getMonth();
        var lastDay = new Date(year, month - 1, 0).getDate();

        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        var lastDay = new Date(date.getFullYear(), date.getMonth() - 0, 0);

        DateFrom = d.getFullYear() + '-' + ('0' + (d.getMonth() + 1)).slice(-2) + '-01';

        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        var lastDay = new Date(date.getFullYear(), date.getMonth() - 0, 0);

        var days = "";
        if (lastDay.getMonth() + 1 == 1 || lastDay.getMonth() + 1 == 3 || lastDay.getMonth() + 1 == 5 || lastDay.getMonth() + 1 == 7 || lastDay.getMonth() + 1 == 8
            || lastDay.getMonth() + 1 == 10 || lastDay.getMonth() + 1 == 12) {
            days = 30;
        }
        else if (lastDay.getMonth() + 1 == 2) {
            days = 27;
        }
        else if (lastDay.getMonth() + 1 == 4 || lastDay.getMonth() + 1 == 6 || lastDay.getMonth() + 1 == 9 || lastDay.getMonth() + 1 == 11) {
            days = 29;
        }

        DateTo = d.getFullYear() + '-' + ('0' + (d.getMonth() + 1)).slice(-2) + '-' + ('0' + d.getDate()).slice(-2);


        $(".SearchCriteria").show();
        debugger;
        if (filename == "ClaimSummaryAndDetail.aspx" || filename == "PaymentsDetailReport.aspx" ||
            filename == "PTLDetail.aspx" || filename == "PTLClaim.aspx" || filename == "UnpaidInsuranceClaimsReport.aspx" ||
            filename == "PatientBalanceDetailReport.aspx" || filename == "PatientTransactionsSummaryReport.aspx" ||
            filename == "PatientTransactionsDetail.aspx" ||
            filename == "PatientDemographics.aspx" || filename == "UnappliedAnalysisReport.aspx" ||
            filename == "OverPaidClaimsReport.aspx" ||
            filename == "PaymentApplicationSummaryReport.aspx" || filename == "DuplicateChecks.aspx" ||
            filename == "PatientBalanceSummaryReport.aspx" || filename == "ChargesSummaryAndDetail.aspx" ||
            filename == "PayerAnalysis.aspx" || filename == "PaymentApplicationReport.aspx") {
            prams = {
                Datefrom: DateFrom,
                Dateto: DateTo,
            }
        }
        if (filename == "PaymentsSummaryAndDetail.aspx" || filename == "PatientSummaryReport.aspx" ||
            filename == "UnpostedPaymentsDetailandSummary.aspx" || filename == "ContractManagementDetailReport.aspx" ||
            filename == "ContractManagementSummaryReport.aspx" || filename == "CPTWiseCollection.aspx" ||
            filename == "Locationwisecollection.aspx" || filename == "PatientBalanceReport.aspx" ||
            filename == "ProviderCollectionReport.aspx" || filename == "ProviderProductivity.aspx" ||
            filename == "DeductableReport.aspx" ||
            filename == "AdjustmentsSummaryReport.aspx" || filename == "AdjustmentsDetailReport.aspx" ||
            filename == "ClaimsSubmissionStatusSummary.aspx" || filename == "CompanyIndicatorReport.aspx") {
            prams = {
                Datefrom: DateFrom,
                Dateto: DateTo,
                DateType: "PostDate"
            }
        }
        $.post("../../ProviderPortal/ReportsNew/CallBacks/" + filename, prams, function (data) {
            var result = "";
            debugger;
            var start = data.indexOf("###startReport###") + 17;
            var end = data.indexOf("###endReport###");
            result = (data.substring(start, end));
            $(".NewResult").html(result);
            //var newResult = $(".NewResult").find(".Filter").hide();
            //var neww = $(".NewResult").html();
            debugger

            $(".tdassociated").css("display", "none");
            $(".tdnon_associated").css("display", "");



            $("#lblAssociated").css("display", "none");
            $("#lblUn_Associated").css("display", "");

            if (oldsreportname == filename) {
                debugger
                var divname = '#widgetsReportTiles' + oldsreportname;
                $("#" + SubReportDivName).html("");
                $('.common_Report').hide();
                $("#" + SubReportDivName).show();
                $("#" + SubReportDivName).html(result);
                $("[id$='ReportDateFrom']").val(DateFrom);
                $("[id$='ReportDateTo']").val(DateTo);
                $("[id$='DateFrom']").val(DateFrom);
                $("[id$='DateTo']").val(DateTo);
                $('[id$="dateFromCustomize"]').val(DateFrom);
                $('[id$="dateToCustomize"]').val(DateTo);
                $("#DateFrom").val(DateFrom);
                $("#DateTo").val(DateTo);
                $("#dateFromCustomize").val(DateFrom);
                $("#dateToCustomize").val(DateTo);
                $("[id$='CPTReportDateFrom']").val(DateFrom);
                $("[id$='CPTReportDateTo']").val(DateTo);
                $("[id$='LocationReportDateFrom']").val(DateFrom);
                $("[id$='LocationReportDateTo']").val(DateTo);
                $("[id$='dateasof']").val(DateFrom);
                $("[id$='dateasofCustomize']").val(DateFrom);
                //if (filename != "ARAgingSummaryReport.aspx") {
                //    $("[id$='TimeSpan']").text(Time);
                //}
                $("#" + SubReportDivName).find('.chk-multi-checkboxes-all').prop("checked", false);
                $("#" + SubReportDivName).find('.chk-multi-checkboxes').prop("checked", false);
                $(".TimeSpan").css("display", "block");
                _count = 1;
                $(".tdassociated").css("display", "none");
                $(".tdnon_associated").css("display", "");
                $(".SearchCriteria").show();
                //if (filename == "Locationwisecollection.aspx" || filename == "PaymentsSummaryAndDetail.aspx") {
                //    $("[id$='txtDateFrom']").text(('0' + (d.getMonth() + 1)).slice(-2) + '/01/' + d.getFullYear());
                //    $("[id$='txtDateTo']").text(('0' + (d.getMonth() + 1)).slice(-2) + '/' + ('0' + d.getDate()).slice(-2) + '/' + d.getFullYear());
                //}
            }

            else {
                debugger

                //var a = $(".widgetsReportTiles").length + 1;
                var ReportsdivId = "";
                //'id_Sub_Report_Body' + a;
                var countit = 0;
                $(".common_Report").each(function () {
                    /*$(this).find('.Filter').hide();*/
                    if ($(this).html() == "" && countit == "0") {
                        debugger;
                        /* $(this).find('.Filter').hide();*/
                        ReportsdivId = $(this).attr("id");
                        countit = 1;
                    }

                });


                $(".Report_Body").find('.common_Report').each(function () {

                    /* ifraheem mahmood 02/09/2022*/
                    /* $(".Report_Body").find('.Filter').hide();*/

                    if ($(this).is(":visible")) {

                        return;
                    }
                    SubReportDivName = ReportsdivId;


                    if (ReportCount == 0) {


                        $('.common_Report').hide();



                        debugger;
                        $("#" + ReportsdivId).html("");
                        $("#" + ReportsdivId).html(result);
                        var dateArF = DateFrom.split('-');
                        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
                        var dateArT = DateTo.split('-');
                        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
                        var Time = newDateFrom + "-" + newDateTo;
                        $("[id$='txtDateFrom']").text(newDateFrom);
                        $("[id$='txtDateTo']").text(newDateTo);
                        $("[id$='ReportDateFrom']").val(DateFrom);
                        $("[id$='ReportDateTo']").val(DateTo);
                        $("[id$='DateFrom']").val(DateFrom);
                        $('[id$="DateTo"]').val(DateTo)
                        $("#dateFromCustomize").val(DateFrom);
                        $("#dateToCustomize").val(DateTo);
                        $("[id$='BillDateFromCustomize']").val(DateFrom);
                        $("[id$='BillDateToCustomize']").val(DateTo);
                        $("[id$='BillDateFrom']").val(DateFrom);
                        $("[id$='BillDateTo']").val(DateTo);
                        $(".TimeSpan").css("display", "block");
                        //if (filename != "ARAgingSummaryReport.aspx") {
                        //    $("[id$='TimeSpan']").text(Time);
                        //}
                        $("[id$='dateasof']").val(DateTo);
                        $("[id$='dateasofCustomize']").val(DateTo);
                        $("#" + ReportsdivId).find('.chk-multi-checkboxes-all').prop("checked", false);
                        $("#" + ReportsdivId).find('.chk-multi-checkboxes').prop("checked", false);
                        //if ($(".tbodyPatientBalanceReport").find("tr").find(".AlignDate").html() == undefined) {
                        //    $(".message").html("No Record Found, Please change search criteria").show();
                        //}

                        /*ReportsdivId = $("#id_Sub_Report_Body1").find(".Filter").hide();*/
                        $("[id$='DateFrom']").prop("disabled", true);
                        $("[id$='DateTo']").prop("disabled", true);
                        //$("[id$='dateasof']").prop("disabled", true);
                        $("#" + ReportsdivId).show();
                        $(".tdassociated").css("display", "none");
                        $(".tdnon_associated").css("display", "");
                        $(".SearchCriteria").show();
                        hiddenRows = $("#" + SubReportDivName).find("[id$='hdnTotalRows']").val();

                        ReportCount = 1;
                        if (filename == "Locationwisecollection.aspx" || filename == "PaymentsSummaryAndDetail.aspx") {
                            $("[id$='txtDateFrom']").text(('0' + (d.getMonth() + 1)).slice(-2) + '/01/' + d.getFullYear());
                            $("[id$='txtDateTo']").text(('0' + (d.getMonth() + 1)).slice(-2) + '/' + ('0' + d.getDate()).slice(-2) + '/' + d.getFullYear());
                        }
                        //   return false;


                        //}
                        //$("#DateFrom").prop('disabled', true);
                        //$("#DateTo").prop('disabled', true);
                        //$("#CustomizeDateFrom").prop('disabled', true);
                        //$("#CustomizeDateTo").prop('disabled', true);

                    }
                });
            }
            debugger
            //var dateArF = DateFrom.split('-');
            //var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
            //var dateArT = DateTo.split('-');
            //var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
            //var Time = newDateFrom + newDateTo;
            //var Time = newDateFrom + "-" + newDateTo;
            //            $("[id$='TimeSpan']").text(Time);
            debugger
            SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
            SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
            $("#" + SubReportDivName).append('<div class = "' + filename2 + '" id = "' + filename2 + '" style="display:none" ></div>');
            var PagesRows = 10;
            $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
            $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + "," + '</div>');
            $("." + filename2).append('<div class = "typehidden ' + PagesRows + '" id = "' + PagesRows + '"  style="display:none" >' + PagesRows + '</div>');
            if (filename == "ItemizationOfChargesReport.aspx" || filename == "PatientDetails.aspx") {
                $('.SelectFilterMessage').css("display", "")
            } else {
                $('.SelectFilterMessage').css("display", "none")
            }
            if (filename == "DuplicateChecks.aspx") {
                $("ul#ulMultiPayerScenario li:nth-child(2)").remove()
            }

            hiddenpaging = $("#ddlPaging").val();
            $(".totalRows").html("Total Rows : " + hiddenRows);

            GenerateReportPaging(hiddenRows, hiddenpaging);
            if (filename == "ARAgingSummaryReport.aspx" || filename=="ClaimSummaryAndDetail.aspx") {
            $(".Reports_Rows_Per_Page").css("display", "none");
            $(".Pagination_div").css("display", "none");
            $(".message_box").css("display", "none");
            $(".rpt_footer").css("display", "none");
        }
            $(".txt_page_Number").val("1");
            debugger
            //if (filename == "Top10Procedures.aspx" || filename == "Top10Payers.aspx" || filename == "Top10DxCodes.aspx") {
            //    $('.message').css("display", "none")
            //}
            var ReportFile_Name = $(".lblReportfileName").text();
            SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate'] option:selected").html();
            SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").html();
            if (_count == 0) {

                var filtername_1 = filename.substring(0, filename.length - 5)
                $(".ReportTiles").append('<div class="widgetsReportTiles" style="padding-right: 14px !important;"  tabName="' + filename + '" tabParameters="' + SubReportDivName + '"hiddenRows="' + hiddenRows +
                    '"hiddenpaging="' + hiddenpaging + '"CatagoryName="' + _Category + '"isParameters="' + _isParameters +
                    '"style="background-color:#006291;color:black" id="widgetsReportTiles' + filename + '">' +
                    '<span class="reportType" style="color:white" onclick="OpenReportTab(\'' + hiddenRows + '\',\'' + hiddenpaging + '\', \'' + SubReportDivName + '\',this)" >' + TabFilename + '</span>' +
                    '<span class="openedreportfilename"  style="display:none" focus="FocusOnCloseIcon(this)">' + filename + '</span>' +
                    '<span class="reportcloseicon" onclick="HideReportTile(this)" focus="FocusOnCloseIcon(this)">' + "x" + '</span>' + ' </div>');
                //$(".ReportTiles").append('<div class = "typehidden" style="display:none" >' + _isParameters + '</div>')
            }
            debugger
            //var ddl = jQuery("#ddlPaging option:contains('All')").text();
            //if (ddl == "All") {
            //    jQuery("#ddlPaging option:contains('All')").remove();

            //    $('#ddlPaging').append($('<option>', {
            //        value: hiddenRows,
            //        text: 'All'
            //    }));
            //    if (filename == "ReportPostClaims.aspx") {
            //        document.getElementById("ddlPaging").selectedIndex = 5;
            //    }
            //    return;
            //}
            //else {
            //    $('#ddlPaging').append($('<option>', {
            //        value: hiddenRows,
            //        text: 'All'
            //    }));
            //    if (filename == "ReportPostClaims.aspx") {
            //        document.getElementById("ddlPaging").selectedIndex = 5;
            //    }
            //}
        }).done(function () {

            $(".common_Report").each(function () {

                if ($(this).is(':visible')) {
                    var openddiv = $(this).attr("id");

                    HiddenDateTypeOfReport = $("#" + openddiv).find("#hdnDateType").val();
                    $("#hdnDateType").val($("#" + openddiv).find("#hdnDateType").val());
                    $("#hdnDateFrom").val($("#" + openddiv).find("#hdnDateFrom").val());
                    $("#hdnDateTo").val($("#" + openddiv).find("#hdnDateTo").val());
                    $("#hdnPracticeLocationId").val($("#" + openddiv).find("#hdnPracticeLocationId").val());
                    $("#hdnProviderId").val($("#" + openddiv).find("#hdnProviderId").val());
                    $("#hdnStartDate").val($("#" + openddiv).find("#hdnStartDate").val());
                    $("#hdnEndDate").val($("#" + openddiv).find("#hdnEndDate").val());
                    /* Added By Faiza Bilal 3-30-2022*/
                    $("[id$='txtReportDateFrom']").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-11 : +0",
                        maxDate: new Date(),
                    });
                    $("[id$='txtReportDateTo']").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-11 : +0",
                        maxDate: new Date(),
                    });
                    /*End  Added By Faiza Bilal 3-30-2022*/
                }
            });
            _Report_div_id = "";
            ReportCount = 0;
            _count = 0;

            //$("ul#ulMultiPayerScenario li:nth-child(2)").remove();



        });
    }
    else {
        debugger
        $(".common_Report").hide();
        $(".widgetsReportTiles").last().attr("isparameters");
        var data = $("#" + SubReportDivName).html();
        var scriptstart = data.indexOf("<script>");
        var scriptend = data.indexOf("</script>");
        var scriptmain = data.substring(scriptstart, scriptend);
        data = data.replace(scriptmain, '');
        $("#" + SubReportDivName).html(data);
        debugger
        $("#" + SubReportDivName).find('.chk-multi-checkboxes-all').prop("checked", false);
        $("#" + SubReportDivName).find('.chk-multi-checkboxes').prop("checked", false);
        $("#" + SubReportDivName).append(scriptmain);
        $("#" + SubReportDivName).parent().parent().parent().parent().parent().find(".totalRows").text("Total Rows : " + hiddenRows);
        $("#" + SubReportDivName).show();
        GenerateReportPaging(hiddenRows, hiddenpaging);
        var Dt = [];
        var Data = $("#" + filename2).text().split(",");
        debugger
        $("#" + SubReportDivName).find("[id$='SelectDate']").val(Data[0]);
        $("#" + SubReportDivName).find("[id$='ddlPostType']").val(Data[1]);
        $("#" + SubReportDivName).parentsUntil().find("[id$='ddlPaging']").val(Data[2]);
        var timespan1 = $.trim($("#" + SubReportDivName).find("[id$='TimeSpan']").text());
        Dt = timespan1.split('-');
        DateFrom = Dt[0];
        DateTo = Dt[1];
        if (timespan1.includes("Time") == true) {
            DateFrom = $.trim($("#" + SubReportDivName).find("[id$='DateFrom']").text());
            DateTo = $.trim($("#" + SubReportDivName).find("[id$='DateTo']").text());
        }
        var Dt1 = [];
        var Dt2 = [];
        Dt1 = DateFrom.split('/');
        if (DateTo != undefined) {
            Dt2 = DateTo.split('/');
        }
        Dt1 = DateFrom.split('/');
        var DateFrom1 = Dt1[2] + '-' + Dt1[0] + '-' + Dt1[1];
        var DateTo1 = Dt2[2] + '-' + Dt2[0] + '-' + Dt2[1];
        $("#" + SubReportDivName).find("[id$='DateFrom']").val(DateFrom1);
        $("#" + SubReportDivName).find("[id$='DateTo']").val(DateTo1);
        $("#" + SubReportDivName).find("[id$='dateasof']").val(DateFrom1);
        if (((filename == "PatientDetails.aspx" || filename == "FilterPatientDetails.aspx") && $(".patient-info-table").closest("tr").find("td").html() == undefined) || ((filename == "ItemizationOfChargesReport.aspx" || filename == "FilterItemizationOfChargesReport.aspx") && $(".ReportGrid").find(".report-column-title").html()  == undefined)) {
            $(".SelectFilterMessage").show();
        }
        else {
            $(".SelectFilterMessage").hide();
        }
    }
}

//****************//
//Code Added By Rizwan kharal
//******* Start *********//

function FirstPage() {

    var PageNumber = 0;

    $(".txt_page_Number").val("1");

    $(".common_Report").each(function () {

        if ($(this).is(':visible')) {
            var openddiv = $(this).attr("id");

            $("#" + openddiv).find("#hdnTotalRows").removeClass("txt-" + _ForwardPageNum);
            $("#" + openddiv).find("#hdnTotalRows").addClass("txt-1");
            _ForwardPageNum = 1;
            $("#hdnDateType").val($("#" + openddiv).find("#hdnDateType").val());
            $("#hdnDateFrom").val($("#" + openddiv).find("#hdnDateFrom").val());
            $("#hdnDateTo").val($("#" + openddiv).find("#hdnDateTo").val());
            $("#hdnPracticeLocationId").val($("#" + openddiv).find("#hdnPracticeLocationId").val());
            $("#hdnProviderId").val($("#" + openddiv).find("#hdnProviderId").val());
            $("#hdnStartDate").val($("#" + openddiv).find("#hdnStartDate").val());
            $("#hdnEndDate").val($("#" + openddiv).find("#hdnEndDate").val());
        }

    });
    RowsChange(PageNumber);
}

function LastPage() {



    var TotalPages = $("#TotalPages").text();
    var PageNumber = TotalPages - 1;

    $(".txt_page_Number").val(TotalPages);
    $(".common_Report").each(function () {

        if ($(this).is(':visible')) {
            var openddiv = $(this).attr("id");

            $("#" + openddiv).find("#hdnTotalRows").removeClass("txt-" + _ForwardPageNum);
            $("#" + openddiv).find("#hdnTotalRows").addClass("txt-" + TotalPages);

            _ForwardPageNum = TotalPages;
            $("#hdnDateType").val($("#" + openddiv).find("#hdnDateType").val());
            $("#hdnDateFrom").val($("#" + openddiv).find("#hdnDateFrom").val());
            $("#hdnDateTo").val($("#" + openddiv).find("#hdnDateTo").val());
            $("#hdnPracticeLocationId").val($("#" + openddiv).find("#hdnPracticeLocationId").val());
            $("#hdnProviderId").val($("#" + openddiv).find("#hdnProviderId").val());
            $("#hdnStartDate").val($("#" + openddiv).find("#hdnStartDate").val());
            $("#hdnEndDate").val($("#" + openddiv).find("#hdnEndDate").val());
        }

    });
    RowsChange(PageNumber);
}

function NextPage() {

    var PageNumber = parseInt($(".txt_page_Number").val());
    var TotalPages = $("#TotalPages").text();



    if (PageNumber == TotalPages || PageNumber == TotalPages) {

        showErrorMessage("No more Pages");


    }
    else {
        $(".txt_page_Number").val(PageNumber + 1);

        var _isParameters
        $(".common_Report").each(function () {

            if ($(this).is(':visible')) {
                var openddiv = $(this).attr("id");
                _ForwardPageNum = PageNumber + 1;
                $("#" + openddiv).find("#hdnTotalRows").removeClass("txt-" + PageNumber);
                $("#" + openddiv).find("#hdnTotalRows").addClass("txt-" + _ForwardPageNum);

                $("#hdnDateType").val($("#" + openddiv).find("#hdnDateType").val());
                $("#hdnDateFrom").val($("#" + openddiv).find("#hdnDateFrom").val());
                $("#hdnDateTo").val($("#" + openddiv).find("#hdnDateTo").val());
                $("#hdnPracticeLocationId").val($("#" + openddiv).find("#hdnPracticeLocationId").val());
                $("#hdnProviderId").val($("#" + openddiv).find("#hdnProviderId").val());
                $("#hdnStartDate").val($("#" + openddiv).find("#hdnStartDate").val());
                $("#hdnEndDate").val($("#" + openddiv).find("#hdnEndDate").val());
            }

        });


        RowsChange(PageNumber);

    }

}

function PreviousPage() {

    var PreviousPageNumber = parseInt($(".txt_page_Number").val());
    var PageNumber = parseInt($(".txt_page_Number").val());

    PageNumber--;

    var TotalPages = $("#TotalPages").text();


    if (PageNumber < 0 || PageNumber > TotalPages || PreviousPageNumber == 1) {
        showErrorMessage("No more Pages");
        return;

    }
    else {


        $(".txt_page_Number").val(PreviousPageNumber - 1);
        $(".common_Report").each(function () {

            if ($(this).is(':visible')) {
                var openddiv = $(this).attr("id");
                $("#" + openddiv).find("#hdnTotalRows").removeClass("txt-" + _ForwardPageNum);
                var PreviousPage = _ForwardPageNum - 1;
                $("#" + openddiv).find("#hdnTotalRows").addClass("txt-" + PreviousPage);
                _ForwardPageNum = PreviousPage;


                $("#hdnDateType").val($("#" + openddiv).find("#hdnDateType").val());
                $("#hdnDateFrom").val($("#" + openddiv).find("#hdnDateFrom").val());
                $("#hdnDateTo").val($("#" + openddiv).find("#hdnDateTo").val());
                $("#hdnPracticeLocationId").val($("#" + openddiv).find("#hdnPracticeLocationId").val());
                $("#hdnProviderId").val($("#" + openddiv).find("#hdnProviderId").val());
                $("#hdnStartDate").val($("#" + openddiv).find("#hdnStartDate").val());
                $("#hdnEndDate").val($("#" + openddiv).find("#hdnEndDate").val());

            }
        });
        RowsChange(PageNumber - 1);
    }
}

function PageNumOnTxt() {

    var PageNumber = $(".txt_page_Number").val();
    $(".txt_page_Number").val(PageNumber);
    PageNumber--;

    RowsChange(PageNumber);
}
//Added By Rizwan 4May2018
function ExportReport(ReportType) {
    debugger;
    //Changes By Sajid Ali Date 5/18/2018
    var ddlValue = $('#ddlExportTo :selected').text();
    var filter_name = filename;
    var filtername_1 = filter_name.substring(0, filter_name.length - 5)
    var fullDate = new Date()
    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);
    var currentDate = fullDate.getDate() + "/" + twoDigitMonth + "/" + fullDate.getFullYear();
    // var ddldatetype = $("[id=ddlPostType]").val();

    debugger

    $(".common_Report").each(function () {
        debugger
        if ($(this).css("display") != "none") {
            $(".CommonReports2").html($(".common_Report").html());
            $(".Ins_TdAction").remove();
            //if (ddldatetype == "DOS") {
            //    $("[id$='lblAssociated']").remove();
            //}
            //else if (ddldatetype == "PostDate") {

            //    $("[id$='lblUn_Associated']").remove();
            //}
            var htmlToPrint = '' +
                '<style type="text/css">' +
                'table, th, td, .tbodyclass {' +
                'text-align:center;' +
                'border:0.5px solid #000;' +
                'border-collapse:collapse;' +
                'font-size:9.5pt;' +
                'font-family:Arial;' +
                'padding:0px 4px;' +
                '}' +
                'table{' +
                'width:100%;' +
                '}' +
                'table thead{' +
                'background-color:#dddddd;' +
                '}' +
                '.divInsuranceDetail a{' +
                'color:#000000 !important;' +
                'text-decoration:none !important;' +
                '}' +
                '</style>'
            var htmlofdivhere = $(this).find(".GridReports").html();

            if (filtername_1 == "PatientDetails") {
                htmlToPrint = ""
                htmlToPrint = '' +
                    '<style type="text/css">' +
                    'table, th, .tbodyclass {' +
                    'text-align:left;' +
                    'border:none' +
                    'border-collapse:collapse;' +
                    'font-size:9.5pt;' +
                    'font-family:Arial;' +
                    'padding:0px 4px;' +
                    '}' +
                    'td {' +
                    'text-align:left;' +
                    'border-bottom:1px solid #ebebeb;' +
                    'border-left:1px solid #ebebeb;' +
                    'border-collapse:collapse;' +
                    'font-size:9.5pt;' +
                    'font-family:Arial;' +
                    'padding:0px 4px;' +
                    '}' +
                    'td b {' +
                    'font-size:9.5pt;' +
                    'font-weight:500;' +
                    '}' +
                    '.patient-info-table td:nth-child(1){' +
                    'width:160px;' +
                    '}' +
                    '.patient-info-table td:nth-child(3){' +
                    'width:160px;' +
                    '}' +
                    '.patient-info-table td:nth-child(2){' +
                    'width:350px;' +
                    '}' +
                    '.patient-info-table td:nth-child(4){' +
                    'width:350px;' +
                    '}' +
                    '.pReport-heading{' +
                    'width:100%;' +
                    'text-align:center;' +
                    '}' +
                    'table{' +
                    'width:100%;' +
                    'border-collapse:collapse;' +
                    '}' +
                    'table thead{' +
                    'background-color:#dddddd;' +
                    '}' +
                    '</style>';

                htmlofdivhere = ""
                htmlofdivhere = $.trim($(this).find(".PatientDetails").html())
            }
            if (filtername_1 == "ARAgingSummaryReport") {

                htmlofdivhere += $.trim($(this).find(".InsuranceDetails").html());
            }
            htmlToPrint += htmlofdivhere;

            $(".DivForPrintExcel").html(htmlToPrint);
            //$(".DivForPrintExcel").find(".selfpaytextfieldsforrow").remove();
            //$(".DivForPrintExcel").find(".lilocationitem").remove();
            //$(".DivForPrintExcel").find(".ddllocationselfpay").remove();
            //$(".DivForPrintExcel").find(".exportSummary").remove();

            //$(".DivForPrintExcel").find("#SelfPayLocations").remove();
            //$(".DivForPrintExcel").find("#PTLLocations").remove();

            $(".DivForPrintExcel").find(".ReportShow").css("display", "");

            if (ReportType == "Excel") {
                var htmlToPrint = '' +
                    '<style type="text/css">' +
                    'table, th, td, .tbodyclass {' +
                    'Text-align:center;' +
                    'border:1px solid #000;' +
                    'border-collapse:collapse;' +

                    '}' +
                    '</style>';
                let file = new Blob([$('.DivForPrintExcel').html()], { type: "application/vnd.ms-excel" });
                let url = URL.createObjectURL(file);
                let a = $("<a />", {
                    href: url,
                    download: filtername_1 + " _ " + currentDate + ".xls"
                }).appendTo("body").get(0).click(); event.preventDefault();
            }
            if (ReportType == "PDF") {
                newWin = window.open(htmlToPrint);

                newWin.document.write(htmlToPrint);

                $(".InsTdAction").show();
                $(".chkboxPtl").show();
                $(".trSearch").show();
                newWin.print();
                newWin.close();
                event.preventDefault();
            }
            if (ReportType == "Word") {
                let file = new Blob([$('.DivForPrintExcel').html()], { type: "application/vnd.ms-excel" });
                let url = URL.createObjectURL(file);
                let a = $("<a />", {
                    href: url,
                    download: filtername_1 + " _ " + currentDate + ".doc"
                }).appendTo("body").get(0).click();
                event.preventDefault();
            }
            if (ReportType == "Print") {
                $(".DivForPrintExcel").html(htmlToPrint)
                debugger
                var divToPrint = document.getElementById('divClientIvoiceDetailPDF');
                var newWin = window.open('', 'Print-Window');

                newWin.document.open();
                newWin.document.write('<title>' + filtername_1 + '_' + currentDate + '</title>');
                newWin.document.write('<html><body onload="window.print()">' + htmlToPrint + '</body></html>');

                newWin.document.close();

                setTimeout(function () { newWin.close(); }, 10);

                $(".DivForPrintExcel").html("");

            }
            $(".DivForPrintExcel").html("");
        }

    });



}

function hideShowDiv(elem) {
    debugger
    var a = $(elem).closest('tr').next('tr').attr('class');
    $(elem).closest('tbody').find('.' + a).slideToggle();

    var icon = $(elem).closest('tbody').find("i");

    if ($(elem).closest('tr').find("i").hasClass("fas fa-angle-down")) {
        $(elem).closest('tr').find("i").addClass("fa-angle-up").removeClass("fa-angle-down");
    }
    else {

        $(elem).closest('tr').find("i").addClass("fa-angle-down").removeClass("fa-angle-up");
    }


}
function Report_ReloadDataProviderWiseReport(actionPage, params, paging) {
    debugger
    $.post("../../Providerportal/ReportsNew/CallBacks/" + actionPage, params, function (data) {
        var result = "";
        var start = data.indexOf("###StartFilterReport###") + 23;
        var end = data.indexOf("###EndFilterReport###");
        result = $.trim(data.substring(start, end));

        $(".tbodyProviderCollection").html(result);
        if ($(".tbodyProviderCollection").find("tr").html() == "" || $(".tbodyProviderCollection").find("tr").html() == undefined) {
            $(".message").html("No Record Found, Please change search criteria");
        }
        else {
            $(".message").html("");
        }
        debugger
        var PagesRows = Rows1;
        SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
        SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
        $("#" + filename2).empty();

        $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + "," + '</div>');
        $("." + filename2).append('<div class = "typehidden ' + PagesRows + '" id = "' + PagesRows + '"  style="display:none" >' + PagesRows + '</div>');
        $("[id$='DateFrom']").val(DateFrom);
        $("[id$='DateTo']").val(DateTo);
        $("[id$='CustomizeDateFrom']").val(DateFrom);
        $("[id$='CustomizeDateTo']").val(DateTo);
        $("#ddlSelectDate").val(SelectDate);
        $("#ddlSelectDateCustomize").val(SelectDate);
        $("#ddlPostType").val(SelectDateType);
        $("#CustomizePostType").val(SelectDateType);
        start = data.indexOf("###StartTotal###") + 16;
        end = data.indexOf("###EndTotal###");
        returnHtml = $.trim(data.substring(start, end));
        $("[id$='hdnTotalRows']").val(returnHtml);
        $(".totalRows").html("Total Rows : " + $("[id$='hdnTotalRows']").val());
        GenerateReportPaging($("[id$='hdnTotalRows']").val(), Rows1);
        var dateArF = DateFrom.split('-');
        var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
        var dateArT = DateTo.split('-');
        var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
        $("[id$='txtDateFrom']").text(newDateFrom);
        $("[id$='txtDateTo']").text(newDateTo);
    });
}
        

function Report_ReloadData(actionPage, params, paging) {
    debugger
    $.post("../../Providerportal/ReportsNew/filter/" + actionPage, params, function (data) {
        debugger
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));

        debugger
        $(".common_Report").each(function () {
            if ($(this).css("display") != "none") {
                debugger
                var openddiv = $(this).attr("id");
                $("#" + openddiv).removeClass("PagesRows-" + OldPageRows);
                var PagesRows = $("#ddlPaging :selected").text();
                if (PagesRows == "All") {
                    PagesRows = 100000;
                }

                OldPageRows = PagesRows;
                $("#" + openddiv).addClass("PagesRows-" + PagesRows);
                debugger
                SelectDate = $("#" + SubReportDivName).find("[id$='SelectDate']").val();
                SelectDateType = $("#" + SubReportDivName).find("[id$='ddlPostType'] option:selected").val();
                $("#" + filename2).empty();

                $("." + filename2).append('<div class = "typehidden ' + SelectDate + '" id = "' + SelectDate + '" style="display:none" >' + SelectDate + "," + '</div>');
                $("." + filename2).append('<div class = "typehidden ' + SelectDateType + '" id = "' + SelectDateType + '"  style="display:none" >' + SelectDateType + "," + '</div>');
                $("." + filename2).append('<div class = "typehidden ' + PagesRows + '" id = "' + PagesRows + '"  style="display:none" >' + PagesRows + '</div>');

                $("#" + openddiv).find("#tbodyReportList").html(returnHtml)

                    .promise()

                    .done(function () {
                        debugger
                        // SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

                        start = data.indexOf("###StartTotal###") + 16;
                        end = data.indexOf("###EndTotal###");
                        returnHtml = $.trim(data.substring(start, end));
                        debugger
                        var a = returnHtml;
                        if (a == 0) {
                            $(".message").html("No Record Found, Please change search criteria").show();
                        }
                        else {
                            $(".message").html("");
                        }
                        if (a != 0 || a == 0) {


                            $("#" + SubReportDivName).find("[id$='hdnTotalRows']").val(returnHtml);

                            if (paging == true) {

                                var r = PagesRows;
                                $(".totalRows").html("Total Rows : " + $("#" + openddiv).find("[id$='hdnTotalRows']").val());
                                GenerateReportPaging($("#" + openddiv).find("[id$='hdnTotalRows']").val(), r);
                                debugger

                                //var ddl = jQuery("#ddlPaging option:contains('All')").text();
                                //if (ddl == "All") {
                                //    jQuery("#ddlPaging option:contains('All')").remove();

                                //    $('#ddlPaging').append($('<option>', {
                                //        value: returnHtml,
                                //        text: 'All',
                                //    }));
                                //}
                            }
                        }
                        if (PageNumber == 0) {
                            $(".txt_page_Number").val("1");
                        }
                        debugger
                        if (actionPage == "FilterDeductableReport.aspx") {
                            var start = data.indexOf("###HoldStart###") + 15;
                            var end = data.indexOf("###HoldEnd###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#Deductible").html(returnHtml)
                        }
                        if (actionPage == "FilterPatientTransactionsDetail.aspx") {
                            //var start = data.indexOf("###TimeSpanStart###") + 19;
                            //var end = data.indexOf("###TimeSpanEnd###");
                            //var returnHtml = $.trim(data.substring(start, end));
                            //$('[id$="TimeSpan"]').text(returnHtml)
                            var start = data.indexOf("###TotalPayments###") + 19;
                            var end = data.indexOf("###EndPayments###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#TotalPayment").html(returnHtml);
                        }
                        debugger
                        if (actionPage != "FilterPatientContactList.aspx" && actionPage != "FilterItemizationOfCharges.aspx") {
                            var start = data.indexOf("###TimeSpanStart###") + 19;
                            var end = data.indexOf("###TimeSpanEnd###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#" + openddiv).find('[id$="TimeSpan"]').text(returnHtml)

                            //var TimeSpan = $('[id$="TimeSpan"]').text().split("-")
                            //TimeSpan = TimeSpan[1] + '/' + TimeSpan[2] + '/' + TimeSpan[0] + " - " + TimeSpan[4] + '/' + TimeSpan[5] + '/' + TimeSpan[3]
                            //$('[id$="TimeSpan"]').text(TimeSpan)
                        }
                        /*else {*/
                        //     var dateArF = DateFrom.split('-');
                        //var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
                        //var dateArT = DateTo.split('-');
                        //var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
                        //$("[id$='txtDateFrom']").text(newDateFrom);
                        //$("[id$='txtDateTo']").text(newDateTo);
                        //}
                        if (actionPage == "FilterContractManagementDetailReport.aspx") {
                            var start = data.indexOf("###StartTotalCharges###") + 23;
                            var end = data.indexOf("###EndTotalCharges###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $('[id$="TotalCharges"]').text(returnHtml)

                            var start = data.indexOf("###StartTotalActAllowed###") + 26;
                            var end = data.indexOf("###EndTotalActAllowed###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $('[id$="TotalActAllowed"]').text(returnHtml)
                        }
                        debugger
                        if (actionPage == "FilterContractManagementSummaryReport.aspx") {
                            var start = data.indexOf("###StartAllowedAmount###") + 24;
                            var end = data.indexOf("###EndAllowedAmount###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $('[id$="AllowedAmount"]').text(returnHtml)

                            var start = data.indexOf("###StartTotalAVGPayment###") + 26;
                            var end = data.indexOf("###EndTotalAVGPayment###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $('[id$="AVGPayment"]').text(returnHtml)
                        }
                        if (actionPage == "FilterPaymentApplicationReport.aspx") {
                            var start = data.indexOf("###StartCheckNumber###") + 22;
                            var end = data.indexOf("###EndCheckNumber###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#divddlCheckNumber").html(returnHtml)
                            var start = data.indexOf("###StartPostDate###") + 19;
                            var end = data.indexOf("###EndPostDate###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#divddlPostDate").html(returnHtml)
                        }
                        if (actionPage == "FilterPatientSummaryReport.aspx") {
                            var start = data.indexOf("###StartPatientTotal###") + 23;
                            var end = data.indexOf("###EndPatientTotal###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#TotalPatient").html(returnHtml)
                        }
                        if (actionPage == "FilterAdjustmentsSummaryReport.aspx") {
                            var start = data.indexOf("###StartAdjustmentTotal###") + 26;
                            var end = data.indexOf("###EndAdjustmentTotal###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#Total").html(returnHtml)
                            $(".message").css("display", "none")
                        }

                        if (actionPage == "FilterPatientBalanceDetailReport.aspx") {
                            var start = data.indexOf("###StartTotalCharges###") + 23;
                            var end = data.indexOf("###EndTotalCharges###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#TotalCharges").html(returnHtml)

                            var start = data.indexOf("###StartTotalAdjustments###") + 27;
                            var end = data.indexOf("###EndTotalAdjustments###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#TotalAdjustments").html(returnHtml)

                            var start = data.indexOf("###StartInsurancePayments###") + 28;
                            var end = data.indexOf("###EndInsurancePayments###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#InsurancePayments").html(returnHtml)

                            var start = data.indexOf("###StartTotalPatientPayments###") + 31;
                            var end = data.indexOf("###EndTotalPatientPayments###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#TotalPatientPayments").html(returnHtml)

                            var start = data.indexOf("###StartGrandTotalBalance###") + 28;
                            var end = data.indexOf("###EndGrandTotalBalance###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#GrandTotalBalance").html(returnHtml)

                            var start = data.indexOf("###StartPendingIns###") + 21;
                            var end = data.indexOf("###EndPendingIns###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#PendingIns").html(returnHtml)

                            var start = data.indexOf("###StartPatientbalance###") + 25;
                            var end = data.indexOf("###EndPatientbalance###");
                            var returnHtml = $.trim(data.substring(start, end));
                            $("#Patientbalance").html(returnHtml)
                        }

                        //var dateArF = DateFrom.split('-');
                        //var newDateFrom = dateArF[1] + '/' + dateArF[2] + '/' + dateArF[0];
                        //var dateArT = DateTo.split('-');
                        //var newDateTo = dateArT[1] + '/' + dateArT[2] + '/' + dateArT[0];
                        //$("[id$='txtDateFrom']").text(newDateFrom);
                        //$("[id$='txtDateTo']").text(newDateTo);
                        //$(".TimeSpan").css("display", "block");
                        /* var Time = newDateFrom + "-" + newDateTo;*/
                        /*$("[id$='TimeSpan']").text(Time);*/
                        //if (actionPage == "FilterUnAppliedAnalysis.aspx") {
                        //    var start = data.indexOf("###StartBeginingUnappliedBalance###") + 35;
                        //    var end = data.indexOf("###EndBeginingUnappliedBalance###");
                        //    var returnHtml = $.trim(data.substring(start, end));
                        //    $('[id$="BeginingUnappliedBalance"]').text(returnHtml)

                        //    var start = data.indexOf("###StartChangeUnapliedBallance###") + 33;
                        //    var end = data.indexOf("###EndChangeUnapliedBallance###");
                        //    var returnHtml = $.trim(data.substring(start, end));
                        //    $('[id$="ChangeUnapliedBallance"]').text(returnHtml)


                        //    var start = data.indexOf("###StartEndingUnappliedBalance###") + 34;
                        //    var end = data.indexOf("###EndEndingUnappliedBalance###");
                        //    var returnHtml = $.trim(data.substring(start, end));
                        //    $('[id$="EndingUnappliedBalance"]').text(returnHtml)
                        //}
                    });

            }

        });

    });
}

function GenerateReportPaging(TotalRows, PageRows) {
    debugger;

    if (filename == "ReportPostClaims.aspx") {


        PageRows = TotalRows;
    }

    if (TotalRows == "NoRows" || TotalRows == "" || TotalRows == undefined || TotalRows == "undefined" || TotalRows == "0") {
        $(".Pagination_div").css("display", "none");
        $(".Reports_Rows_Per_Page").css("display", "none");
        $("#ReportFilterId").css("display", "block");
        $(".report-export").css("display", "block");
        $(".message").html("No Record Found, Please change search criteria");
    }
    else if (parseInt(TotalRows) == 0) {
        if ((filename == "PatientBalanceReport.aspx") && $(".tbodyPatientBalanceReport").find("tr").find(".AlignDate").html() == undefined) {
            $(".message").html("No Record Found, Please change search criteria");
        }
        else if ((filename == "PayerAnalysis.aspx") && $(".tbodyPayerAnalysis").find("tr").html() == undefined) {
            $(".message").html("No Record Found, Please change search criteria");
        }
        else if ((filename == "ProcedurePaymentsSummaryAndDetail.aspx") && ($("#tbodyReportList").find("tr").html() == undefined)) {
            $(".message").html("No Record Found, Please change search criteria");
        }
        else if ((filename == "ProviderProductivity.aspx") && ($("#tbodyReportList").find("tr").html() == undefined)) {
            $(".message").html("No Record Found, Please change search criteria");
        }
        else if ((filename == "ProviderCollectionReport.aspx") && ($("#tbodyReportList").find("tr").html() == undefined)) {
            $(".message").html("No Record Found, Please change search criteria");
        }
        $(".totalRows").css("display", "none");
        $(".txt_page_Number").html("0");
        $(".lblTotalPages").html("0");
        $(".PageButton").css("display", "none");
        $("#ReportFilterId").css("display", "block");
        $(".report-export").css("display", "block");


    }
    else if (parseInt(TotalRows) < parseInt(PageRows)) {
        var pages = (TotalRows % PageRows) == 0 ? (TotalRows / PageRows) : parseInt((TotalRows / PageRows)) + 1;
        $(".message").html("");
        $(".lblTotalPages").css("display", "block");
        $(".lblTotalPages").html(pages);
        $(".totalRows").css("display", "block");
        $(".PageButton").css("display", "block");
        $(".Reports_Rows_Per_Page").css("display", "block");
        $("#ReportFilterId").css("display", "block");
        $(".report-export").css("display", "block");
        //$(".message").html("No Record Found, Please change search criteria");
    }
    else {
        if (TotalRows == null) {
            $(".message").html("Please open any report!");
            $(".totalRows").css("display", "none");
            $(".txt_page_Number").html("0");
            $(".lblTotalPages").html("0");
            $(".Pagination_div").css("display", "block");
            $(".PageButton").css("display", "none");
            $(".Reports_Rows_Per_Page").css("display", "block");
            $("#ReportFilterId").css("display", "block");
            $(".report-export").css("display", "block");
        }
        else {
            var pages = (TotalRows % PageRows) == 0 ? (TotalRows / PageRows) : parseInt((TotalRows / PageRows)) + 1;
            $(".message").html("");
            $(".lblTotalPages").html(pages);
            $(".totalRows").css("display", "block");
            $(".Pagination_div").css("display", "block");
            $(".PageButton").css("display", "block");
            $(".Reports_Rows_Per_Page").css("display", "block");
            $("#ReportFilterId").css("display", "block");
            $(".report-export").css("display", "block");
        }


    }
    if (filename == 'ItemizationOfChargesReport.aspx' || filename == 'PatientDetails.aspx' || filename == 'ARAgingSummaryReport.aspx' || filename == 'Top10DxCodes.aspx' || filename == 'RejectedDeniedSummaryAndDetail.aspx') {
        $(".message").html("");
    }
    if (filename == "PaymentsSummaryAndDetail.aspx" && ($("#tbodyReportList").find("td").html() != "" || $("#tbodyReportList").find("td").html() != undefined)) {
        $(".message").html("");
    }
    if ((filename == "PatientBalanceReport.aspx") && ($("#tbodyReportList").find("tr").html() != undefined)) {
        $(".message").html("");
    }
    if ((filename == "UnpaidInsuranceClaimsReport.aspx") && ($("#tbodyReportList").find("tr").html() != undefined)) {
        $(".message").html("");
    }
    if ((filename == "ProviderProductivity.aspx" || filename == "ProviderCollectionReport.aspx") && ($("#tbodyReportList").find("tr").html() != undefined)) {
        $(".message").html("");
    }
    ///* Edited  by Faiza Bilal 6-14-2022*/
    if (filename == "PaymentApplicationReport.aspx" || filename == "FilterPaymentApplicationReport.aspx" || filename == "CompanyIndicatorReport.aspx" ||
        filename == "FilterCompanyIndicatorReport.aspx" || filename == "FilterUnpaidInsuranceClaimsReport.aspx" || filename == "UnpaidInsuranceClaimsReport.aspx" ||
        filename == "ItemizationOfChargesReport.aspx" || filename == "FilterItemizationOfChargesReport.aspx" || filename == "ARAgingSummaryReport.aspx" || filename == "FilterARAgingSummaryReport.aspx" ||
        filename == "FilterClaimsDetail.aspx" || filename == "ReportPostClaimSummary.aspx" || filename == "FilterReportPostClaims.aspx" || filename == "PatientDetails.aspx" || filename == "FilterPatientDetails.aspx" ||
        filename == "UnpostedPaymentsDetailandSummary.aspx" || filename == "FilterUnpostedPaymentsDetailandSummary.aspx" || filename == "RejectedDeniedSummaryAndDetail.aspx" ||
        filename == "FilterRejectedDeniedSummaryAndDetail.aspx" || filename == "PaymentsSummaryAndDetail.aspx" || filename == "FilterPaymentsSummaryAndDetail.aspx" ||
        filename == "AdjustmentsSummaryReport.aspx" || filename == "FilterAdjustmentsSummaryReport.aspx" || filename == "PaymentApplicationSummaryReport.aspx" || filename == "FilterPaymentApplicationSummaryReport.aspx" ||
        filename == "Top10DxCodes.aspx" || filename == "Top10Procedures.aspx" || filename == "Top10Payers.aspx" || filename == "ClaimSummaryAndDetail.aspx") {
        $(".Reports_Rows_Per_Page").css("display", "none");
        $(".Pagination_div").css("display", "none");
        $(".message_box").css("display", "none");
        $(".rpt_footer").css("display", "none");
    }
    else {
        $(".Reports_Rows_Per_Page").css("display", "block");
        $(".Pagination_div").css("display", "block");
        $(".message_box").css("display", "block");
        $(".rpt_footer").css("display", "block");
    }
    ///*End Edited  by Faiza Bilal 6-14-2022*/
}

function OpenReportTab(hiddenRows, hiddenpaging, _isParameters, elem) {
    debugger;
    hiddenRows = $("#" + _isParameters).find("[id$='hdnTotalRows']").val();
    $('#ddlExportTo').get(0).selectedIndex = 0;
    var ReportName = $(elem).closest('.widgetsReportTiles').text().slice(0, -1).trimEnd();
    
    if (hiddenRows == "0" || hiddenRows == null) {

        hiddenRows = $("#" + _isParameters).find("[id$='hdnTotalRows']").val();
    }
    else {
        hiddenRows = hiddenRows;
    }
    SubReportDivName = _isParameters;
    //---start ali imran 18 july
    $(".common_Report").each(function () {
        if ($(this).is(':visible')) {
            //var lastOpenDiv = $(this).attr("id");
            //var data = $("#" + lastOpenDiv).html();
            //var scriptstart = data.indexOf("<script");
            //var scriptend = data.indexOf("</script>");
            //var scriptmain = data.substring(scriptstart, scriptend);
            //data = data.replace(scriptmain, '');
            //$("#" + lastOpenDiv).html(data);
            //Alert("Report is already opened");


        }
    });
    //if (Alert() == true) {
    //    return
    //}
    debugger
    $(".widgetsReportTiles").last().attr("isparameters");
    var data = $("#" + _isParameters).html();
    var scriptstart = data.indexOf("<script>");
    var scriptend = data.indexOf("</script>");
    var scriptmain = data.substring(scriptstart, scriptend);
    data = data.replace(scriptmain, '');
    $("#" + _isParameters).html(data);

    $("#" + _isParameters).append(scriptmain);
    //--- end ali imran 18 july---

    $(".common_Report").hide();

    $('#' + _isParameters).show();
    /* Added By Faiza Bilal 3-24-2022*/
    TabContent = $('#' + _isParameters);



    /*Added By Faiza Bilal 3-30-2022*/
    var _TimeSpanProvidercol = TimeSpanProvidercol;
    var _TimeSpanCPT = TimeSpanCPT;
    var _TimeSpanClaimAndSum = TimeSpanClaimAndSum;
    var _TimeSpanLocWise = TimeSpanLocWise;
    var _TimeSpanPaySummary = TimeSpanPaySummary;
    var _TimeSpanUnpostedPay = TimeSpanUnpostedPay;
    //var _TimeSpanPatBal = TimeSpanPatBal;

    //if (_TimeSpanCPT != "" && elem.innerText == "CPT Wise Collection") {
    //    GetFilteredOnChangingTab(_TimeSpanCPT, TabContent, DateFromCPT, DateToCPT);
    //}
    //else if (_TimeSpanClaimAndSum != "" && elem.innerText == "Claim Summary And Detail") {
    //    GetFilteredOnChangingTab(_TimeSpanClaimAndSum, TabContent, DateFromClaimAndSum, DateToClaimAndSum);
    //}
    //else if (_TimeSpanLocWise != "" && elem.innerText == "Location wise collection") {
    //    GetFilteredOnChangingTab(_TimeSpanLocWise, TabContent, DateFromLocWise, DateToLocWise);
    //}
    //else if (_TimeSpanPaySummary != "" && elem.innerText == "Payments Summary And Detail") {
    //    GetFilteredOnChangingTab(_TimeSpanPaySummary, TabContent, DateFromPaySummary, DateToPaySummary);
    //}
    //else if (_TimeSpanUnpostedPay != "" && elem.innerText == "Unposted Payments Detail and Summary") {
    //    GetFilteredOnChangingTab(_TimeSpanUnpostedPay, TabContent, DateFromUnpostedPay, DateToUnpostedPay);
    //}
    ////else if (_TimeSpanPatBal != "" && elem.innerText == "Patient Balance Report") {
    ////    GetFilteredOnChangingTab(_TimeSpanPatBal,TabContent, DateFromPatBal, DateToPatBal);
    ////}
    //else if (_TimeSpanProvidercol != "" && elem.innerText == "Provider Collection Report") {
    //    GetFilteredOnChangingTab(_TimeSpanProvidercol, TabContent, DateFromProvidercol, DateToProvidercol);
    //}
    //else
    filename = $(elem).closest(".widgetsReportTiles").attr("tabname");
    GetFilteredOnChangingTab("", TabContent, DateFrom, DateTo, ReportName, filename);

    /*End Added By Faiza Bilal 3-24-2022*/
    /* $('#' + _isParameters).find("[id$='rbReportTimeSpanMonthToDate']").attr("Checked", true);*/
    debugger;


    $('.widgetsReportTiles').css('background-color', '#ececec');
    $('.reportType').css('color', '#2b2727');
    $(elem).closest('.widgetsReportTiles').css('background-color', '#006291');
    $(elem).closest('.widgetsReportTiles').css('border-color', '#439abf');
    $(elem).css('color', '#ffffff');
    $(".totalRows").html("Total Rows : " + hiddenRows);
    var ReportFilterFileName = $(elem).closest('.widgetsReportTiles').text();
    _ReportFilterFileName = ReportFilterFileName.substring(0, ReportFilterFileName.length - 1);


    filename = $(elem).closest(".widgetsReportTiles").attr("tabname");
    _selectedReport_Filter = "Filter" + filename;

    _ReportFilterCategory = $(elem).closest(".widgetsReportTiles").attr("CatagoryName");
    _ReportFilterIsParameters = $(elem).closest(".widgetsReportTiles").attr("isParameters");

    //if (_ReportFilterIsParameters != "True") {
    //    $("#ReportFilterId").css("display", "none");
    //}
    //else {
    //    $("#ReportFilterId").css("display", "block");
    //}

    var HiddenPageNum = $.trim($("#" + _isParameters).find("#hdnTotalRows").attr("class"));
    HiddenPageNum = HiddenPageNum.split('-')[1];
    if (HiddenPageNum == "" || HiddenPageNum == null) {
        HiddenPageNum = 1;
    }
    else {
        HiddenPageNum = HiddenPageNum;
    }
    $(".txt_page_Number").html("");



    var PagingNum = $.trim($("#" + _isParameters).attr("class"));
    PagingNum = PagingNum.split('-')[1];

    if (PagingNum == "All") {
        hiddenRows = $.trim($("#" + _isParameters).find("#hdnTotalRows").val());
        hiddenpaging = hiddenRows;
    }
    else if (PagingNum == null) {
        hiddenpaging = hiddenpaging;
    }
    else {
        hiddenpaging = hiddenpaging;
    }
    $(".txt_page_Number").val(HiddenPageNum);
    if (filename == "ClaimSummaryAndDetail.aspx") {

    }
    if (ReportName == "Patient Details") {
        if ($("[id$='hdnPatientId']").val() != "") {
            $(".SelectFilterMessage ").css("display", "none");

        }
        $(".message").html("");
        $(".Pagination_div ").css("display", "none");
        $(".Reports_Rows_Per_Page ").css("display", "none");

    }
    if (ReportName != "Patient Details") {

        GenerateReportPaging(hiddenRows, hiddenpaging);
    }

    /*Added By Faiza Bilal 3-30-2022*/

    //var currentDate = new Date();
    //$("[id$='txtReportDate']").datepicker('setDate', new Date(currentDate.getFullYear(), currentDate.getMonth(), 1));
    //$("[id$='txtReportTo']").datepicker('setDate', currentDate);
    //$("[id$='txtReportDate']").blur();
    //$("[id$='ddlPostType']").val("PostDate")

}
/*Added By Faiza Bilal 3-24-2022*/
function GetFilteredOnChangingTab(Time_Span, TabContent, _DateFrom, _DateTo, ReportName, filename) {
    debugger;
    var Date = _DateFrom + "-" + _DateTo;
    var DateTimeSpan = $.trim((TabContent).find("[id$='TimeSpan']").text());
    var SelectDate = (TabContent).find("[id$='SelectDate'] option:selected").val();
    Dt = DateTimeSpan.split('-');
    DateFrom = Dt[0];
    DateTo = Dt[1];
    if (DateTimeSpan.includes("Time") == true) {
        DateFrom = $.trim($("#" + SubReportDivName).find("[id$='DateFrom']").text());
        DateTo = $.trim($("#" + SubReportDivName).find("[id$='DateTo']").text());
    }
    var Dt1 = [];
    var Dt2 = [];
    if (DateTo != undefined) {
        Dt2 = DateTo.split('/');
    }
    Dt1 = DateFrom.split('/');
    var DateFrom1 = Dt1[2] + '-' + Dt1[0] + '-' + Dt1[1];
    var DateTo1 = Dt2[2] + '-' + Dt2[0] + '-' + Dt2[1];
    filename2 = filename;
    filename3 = filename;
    filename2 = filename2.replace('.aspx', '');
    filename3 = filename3.replace('.as', '');
    var Data = $("#" + filename2).text().split(",");
    debugger
    TabContent.find("[id$='SelectDate']").val(Data[0]);
    TabContent.find("[id$='ddlPostType']").val(Data[1]);
    TabContent.parentsUntil().find("[id$='ddlPaging']").val(Data[2]);
    TabContent.find("[id$='DateFrom']").val(DateFrom1);
    TabContent.find("[id$='DateTo']").val(DateTo1);
    TabContent.find("[id$='CustomizeDateFrom']").val(DateFrom1);
    TabContent.find("[id$='CustomizeDateTo']").val(DateTo1);
    TabContent.find("[id$='dateFromCustomize']").val(DateFrom1);
    TabContent.find("[id$='dateToCustomize']").val(DateTo1);
    TabContent.find("[id$='dateasof']").val(DateFrom1);
    TabContent.find("[id$='SelectDateCustomize']").val(Data[0]);

    TabContent.find("[id$='TimeSpan']").val();

    if (((filename == "PatientDetails.aspx" || filename == "FilterPatientDetails.aspx") && $(".patient-info-table").closest("tr").find("td").html() == undefined) || ((filename == "ItemizationOfChargesReport.aspx" || filename == "FilterItemizationOfChargesReport.aspx") && $(".ReportGrid").find(".report-column-title").html() == undefined)) {
        $(".SelectFilterMessage").show();
    }
    else {
        $(".SelectFilterMessage").hide();
    }


}
/*End Added By Faiza Bilal 3-24-2022*/
function HideReportTile(elem) {
    debugger
    var ReportName = $(elem).closest('.widgetsReportTiles').text().slice(0, -1).trimEnd();
    var file_name1 = ""
    filename = $(".widgetsReportTiles").attr("tabname");
    file_name1 = $(elem).closest(".widgetsReportTiles").find(".openedreportfilename").text().split(".aspx");
   
    var OpenedFIleName = ($.trim($(".openedreportfilename").text()));
        OpenedFIleName = OpenedFIleName.split(".aspx");
        for (var a = 0; a < OpenedFIleName.length; a++) {
            if ((file_name1[0]) == (OpenedFIleName[a])) {
                $("#reportdropdown").find("."+file_name1[0]).removeClass('td_highlight');
            }
        }
    $(elem).closest(".widgetsReportTiles").css("display", "none");
    $(elem).closest(".widgetsReportTiles").remove();
    //_count = 0;
    var Currentfilename = $(elem).closest(".widgetsReportTiles").attr("tabParameters");
    var lastfilename = $(".widgetsReportTiles").last().attr("tabParameters");
    //$("#" + Currentfilename).parentsUntil('.nametd').removeClass('td_highlight')
    //---start ali imran 18 july
    var a = $(elem).closest(".widgetsReportTiles").text().slice(0, -1);

    var data = $("#" + Currentfilename).html();
    var scriptstart = data.indexOf("<script>");
    var scriptend = data.indexOf("</script>");
    var scriptmain = data.substring(scriptstart, scriptend);
    data = data.replace(scriptmain, '');
    $("#" + Currentfilename).html(data);

    $("#" + Currentfilename).append(scriptmain);
    //--- end ali imran 18 july---


    $('#' + Currentfilename).html("");

    $('#' + Currentfilename).hide();
    $('#' + lastfilename).show();
    debugger
    $(".widgetsReportTiles").last().css("background-color", "#006291");
    $(".widgetsReportTiles").last().children('.reportType').css('color', 'white');
    // var hiddenRows = $(".widgetsReportTiles").last().attr("hiddenRows");
    // var hiddenpaging = $(".widgetsReportTiles").last().attr("hiddenpaging");
    //$(".totalRows").html("Total Rows : " + hiddenRows);
    //Add by Daniyal_Baig 20June19
    var ReportName = $(".reportType").text();
    $(".undefined").hide();
    
    //End by daniyal

    _Report_div_id = "";
    _selectedReport_Filter = "Filter" + filename;
    _ReportFilterIsParameters = $(".widgetsReportTiles").last().attr("isparameters");
    _ReportFilterCategory = $(".widgetsReportTiles").last().attr("CatagoryName");
    if (filename != undefined) {
        _ReportFilterFileName = filename.substring(0, filename.length - 5);

        if (hiddenRows == "0" || hiddenRows == null) {
            hiddenRows = $("#" + lastfilename).find("#hdnTotalRows").val();
        }
        else {
            hiddenRows = hiddenRows;
        }
        var HiddenPageNum = $.trim($("#" + lastfilename).find("#hdnTotalRows").attr("class"));
        HiddenPageNum = HiddenPageNum.split('-')[1];
        if (HiddenPageNum == "" || HiddenPageNum == null) {
            HiddenPageNum = 1;
        }
        else {
            HiddenPageNum = HiddenPageNum;
        }
        $(".txt_page_Number").html("");



        var PagingNum = $.trim($("#" + lastfilename).attr("class"));
        PagingNum = PagingNum.split('-')[1];

        if (PagingNum == "All") {
            hiddenRows = $.trim($("#" + lastfilename).find("#hdnTotalRows").val());
            hiddenpaging = hiddenRows;
        }
        else if (PagingNum == null) {
            hiddenpaging = hiddenRows;
        }
        else {
            hiddenpaging = hiddenpaging;
        }
        $(".txt_page_Number").val(HiddenPageNum);

        GenerateReportPaging(hiddenRows, hiddenpaging);
        if (ReportName == "") {
            $("#ReportFilterId").css("display", "none");
            $(".report-export").hide();
            $(".Reports_Rows_Per_Page, .PageButton").hide();
            $(".InitialMsg").css("display", "block");
            $('.SelectFilterMessage').css("display", "none");
            $('.totalRows').css("display", "none");
            $('.export-icons').hide();
            $('.message').hide();

        }
    }

}

function openReportFilterDialogue(elem) {
    debugger
    var FilterName = "";
    ids = "";
    $('.common_Report').each(function () {

        if ($(this).is(":visible")) {

            _Report_div_id = $(this).attr('id');
            var openddiv = $(this).attr("id");

            $("#" + openddiv).find("#hdnTotalRows").removeClass("txt-" + _ForwardPageNum);
            var PagesNumbers = $(".txt_page_Number").val();
            $("#" + openddiv).find("#hdnTotalRows").addClass("txt-" + PagesNumbers);

        }
    });


    $('.widgetsReportTiles').each(function () {

        var aa = $(this).attr('tabparameters');
        if (aa == _Report_div_id) {
            FilterName = $(this).attr('tabname');
        }
    });

    _ReportFilterFileName = FilterName.substring(0, FilterName.length - 5);

    var _ReportFilterCount = 1;
    if (_ReportFilterIsParameters == "True") {


        if (_ReportFilterCategory == "Financial" || _Category == "Scheduling" || _ReportFilterCategory == "Company") {

            OpenPaymentsFilterDialog(_ReportFilterFileName, _ReportFilterIsParameters, _ReportFilterCount);
            return;
        }
        if (_Category == "Patient") {
            OpenPatientFilterDialog(_ReportFilterFileName, _ReportFilterIsParameters, _ReportFilterCount);
            return;
        }


    }
    else if (_ReportFilterIsParameters == "False" || _ReportFilterIsParameters == "") {
        /*ifraheem mahmood*/

        if (FilterName == "Locationwisecollection.aspx") {
            HideUnHideFilterLocationWise();

        }
        else {
            hideunhideFilter();
        }
        /*        FilterLocationWiseCollection();*/


    }
    else {

        showErrorMessage("No Filter for this report");
    }

}

function SerachUserOnEnter(elem) {

    var a = event.which || event.keyCode;
    if (a == 13) {

        var search = $("[id$='txtUserName']").val();

        $("[id$='hdnuserid']").val("0");

        UserSearch(search);
    }
}

function CheckifALLClick() {
    var ALL = $("#" + SubReportDivName).parentsUntil().find("#ddlPaging option:selected").val();
    if (ALL == "All") {
        $(".txt_page_Number").val("1");
        $(".txt_page_Number").text("1");
    }
}

function SearchReport() {

    var Search = $("#txtSearchReport").val();
    $.post("../../ProviderPortal/ReportsNew/MainReport.aspx",
        {
            SearchedReport: Search,
            Action: "SearchReports"
        },
        function (data) {

            var start = data.indexOf("###StartSearchReports###") + 25;
            var end = data.indexOf("###EndSearchReport###");
            var result = $.trim(data.substring(start, end));
            $("#divSearchReports").css("display", "block");
            $("#divSearchReports").html(result);
        });
}

function SelectSearchedReport(elem) {
    debugger
    filename = $.trim($(elem).find(".lblReportfileName").html());
    var SelectedSearchedReport = $.trim($(elem).find(".Td_Name").html());
    $("#txtSearchReport").val(SelectedSearchedReport);
    if (filename == "") {
        filename = PageLoadFileName;

    }
    else {
        filename = $.trim($(elem).find(".lblReportfileName").text());;
        var UserId = $("[id$='hdnUserIdMaster']").val();

    }


    _selectedReport_Filter = $.trim($(elem).find('.lblReportFilterName').text());
    _isParameters = $.trim($(elem).find('.ReportType').text());
    _Category = $.trim($(elem).find('.Category').text());

    _ReportFilterFileName = filename.substring(0, filename.length - 5);
    _ReportFilterCategory = _Category;
    _ReportFilterIsParameters = _isParameters;



    if (_isParameters != "True") {
        $("#ReportFilterId").css("display", "none");
    }
    else {
        $("#ReportFilterId").css("display", "block");
    }



    var SPFileName = filename.split(".");
    var SP_FileName = SPFileName[0];

    $(".widgetsReportTiles").each(function () {

        var length = $(".widgetsReportTiles").length;

        var tabname = $(this).attr("tabName");

        if (tabname == filename) {
            showErrorMessage("Report is already opened");
            $(this).css("border-color", "red");
            _count++;
            return false;
        }
        else {
            _count = 0;
        }

    });

    if (_count == 0) {
        var iffilenameissame = "";
        var countithere = 0;
        debugger
        $(".widgetsReportTiles").each(function () {
            var name = $(this).attr('id');
            if (name == "widgetsReportTiles" + filename && countithere == 0) {
                iffilenameissame = "widgetsReportTiles" + filename;
            }
        });
        debugger
        var a = $(".widgetsReportTiles").length;
        if (a > 4 && iffilenameissame == "") {
            showErrorMessage("Can not open more then 5 reports.close at least 1 report tab");
            // $(".widgetsReportTiles").last().css("background-color", "#02a7f9b8");
            return false;

        }

        if (_isParameters == "True") {

            if (_Category == "Financial" || _Category == "Scheduling" || _Category == "Company") {
                var ReportTypeName = filename;
                filtername = ReportTypeName.substring(0, ReportTypeName.length - 5);
                closeSesarchedDiv();
                OpenPaymentsFilterDialog(filtername, _isParameters);

                return;
            }
            if (_Category == "Patient") {
                var ReportTypeName = filename;
                filtername = ReportTypeName.substring(0, ReportTypeName.length - 5);

                closeSesarchedDiv();
                OpenPatientFilterDialog(filtername, _isParameters);
                return;
            }


        }
        else {
            closeSesarchedDiv();
            OpenReportPage(filename, _isParameters, "", SP_FileName);

        }
    }
}
function closeSesarchedDiv() {
    $("#txtSearchReport").val("");
    $("#divSearchReports").css("display", "none");
}

function SetSearchReports() {

    var a = event.which || event.keyCode;
    if (a == 13) {
        SearchReport();
    }
}

function OpenCheckDetails(elem) {
    debugger;
    var Title = "";
    var PayerType = $.trim($(elem).text());

    if (PayerType == "Insurance") {
        PayerType = "Insurance";
        Title = "Insurance Payments Detail";
        var amount = $(".InsurancePayment").text();
        $("[id$='totalcheckAmount']").text(amount);
    }
    else if (PayerType == "Patient") {
        PayerType = "Patient";
        Title = "Patient Payments Detail";
        var amount = $(".PatientPayment").text();
        $("[id$='totalcheckAmount']").text(amount);
    }
    else {
        return;
    }

    $("." + PayerType).each(function () {

        $("." + PayerType).show();
    });

    $("#dialogue").css("display", "block");

    $("#dialogue").dialog({
        width: 1060,
        // height:700,
        modal: true,
        title: Title,
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                $("." + PayerType).hide();
                $(this).dialog("destroy");
                $("#dialogue").hide();

            }
        },
        close: function () {
            $("." + PayerType).hide();
            $(this).dialog("destroy");
            $("#dialogue").hide();

        }
    });
}

//***Added by Daniyal_Baig 17April2019***//
function PrintReoprt(print) {
    var ddlValue = $('#ddlExportTo :selected').text();
    var filter_name = filename;
    var filtername_1 = filter_name.substring(0, filter_name.length - 5)
    var fullDate = new Date()
    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);
    var currentDate = fullDate.getDate() + "/" + twoDigitMonth + "/" + fullDate.getFullYear();
    $(".common_Report").each(function () {
        debugger
        if ($(this).css("display") != "none") {

            if (print == "PDF") {
                var PdfHtml = $(this).find(".GridReports").html();
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

            }
        }
    });
}
var ProviderName = "";
function OpenDialoguePostClaim(elem) {
    debugger
    var name = $.trim($(elem).find(".ProviderName").text());
    ProviderName = name;


    $.post("../../ProviderPortal/ReportsNew/CallBacks/ReportPostClaims.aspx",
        {
            DateType: $("#" + SubReportDivName).find("#ddlPostType").val(),
            PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
            PlaceOfService: $("[id$='hdnPlaceOfService']").val(),
            providers: $("[id$='hdnproviders']").val(),
            payer: $("[id$='hdnpayer']").val(),
            ClaimStatus: $("[id$='hdnClaimStatus']").val(),
            ReportType: $("[id$='hdnReportTypeLevel']").val(),
            POSCode: $("[id$='hdnPOSCode']").val(),
            FileSearchId: $("[id$='hdnFileSearchId']").val(),
            StartDate: $("#" + SubReportDivName).find("[id$='DateFrom']").val(),
            EndDate: $("#" + SubReportDivName).find("[id$='DateTo']").val(),
            name: ProviderName,


        }, function (data) {
            debugger
            var start = data.indexOf("###startReport###") + 17;
            var end = data.indexOf("###endReport###");
            var returnHtml = $.trim(data.substring(start, end));

            $("#divDialogReportFilters").html(returnHtml);
            $("#dialogue").show();
///Modified By Irfan Mahmood 7July2022
            $(".totalRows").html("Total Rows : " + $("[id$='ltrTotalRows']").val());
        
            GenerateReportPaging($("[id$='ltrTotalRows']").val(), $("#ddlPagingPostClaimsDetail").val())
            ///Modified By IQRA 13July2022
            $(".Pagination_div").css("display", "block");
            ///End Modified By IQRA 13July2022
            $(".PostClaimPagination").css("display", "")
                        ///End Modified By Irfan Mahmood 7July2022
            debugger
            $("#divDialogReportFilters").dialog({
                width: 1160,
                modal: true,
                title: "Post Claim Detail " + "(" + name + ")",
                open: function () {
                    $(".ui-widget-overlay").last().css("z-index", "9999");
                    $(".ui-dialog").last().css("z-index", "99999");
                },
                buttons: {
                    "Close": function () {
                        debugger
                        $(".divDialogReportFilters").html("");
                        $(this).dialog("destroy");
                        $("#dialogue").hide();
                        ///Modified By IQRA 13July2022
                        $(".Report_Footer ").hide();

                    ///End Modified By IQRA 13July2022

///Modified By Irfan Mahmood 7July2022

                        $(".PostClaimPagination").css("display", "none");
                        ///End Modified By Irfan Mahmood 7July2022

                    }
                },
                close: function () {
                    debugger
                    $(".divDialogReportFilters").html("");
                    $(this).dialog("destroy");
                    $("#dialogue").hide();
                    ///Modified By IQRA 13July2022
                    $(".Report_Footer ").hide();

                    ///End Modified By IQRA 13July2022

///Modified By Irfan Mahmood 7July2022
                   $(".PostClaimPagination").css("display", "none");

                    ///End Modified By Irfan Mahmood 7July2022

                }
            });


        });

}
///Modified By Irfan Mahmood 7July2022

function FilterDetailPostClaim(Rows, PageNumber) {
    debugger
    $.post("../../ProviderPortal/ReportsNew/filter/FilterReportPostClaims.aspx",
        {
            DateType: $("[id$='hdnDateType']").val(),
            PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
            PlaceOfService: $("[id$='hdnPlaceOfService']").val(),
            providers: $("[id$='hdnproviders']").val(),
            payer: $("[id$='hdnpayer']").val(),
            ClaimStatus: $("[id$='hdnClaimStatus']").val(),
            ReportType: $("[id$='hdnReportTypeLevel']").val(),
            POSCode: $("[id$='hdnPOSCode']").val(),
            FileSearchId: $("[id$='hdnFileSearchId']").val(),
            StartDate: $("[id$='hdnStartDate']").val(),
            EndDate: $("[id$='hdnEndDate']").val(),
            name: ProviderName,
            Rows: Rows,
            PageNumber: PageNumber,


        }, function (data) {
            debugger
            var start = data.indexOf("###startReport###") + 19;
            var end = data.indexOf("###endReport###");
            var returnHtml = $.trim(data.substring(start, end));

            $(".DetailPostClaim").html(returnHtml);
               ///Modified By IQRA 13July2022
           $(".totalRows").html("Total Rows : " + $("[id$='ltrTotalRows']").val());
            GenerateReportPaging($("[id$='ltrTotalRows']").val(), $("#ddlPagingPostClaimsDetail").val())
            if (filename == "ReportPostClaimSummary.aspx") {
                $(".Reports_Rows_Per_Page").css("display", "block");
                $(".Pagination_div").css("display", "block");
                $(".message_box").css("display", "block");
                $(".rpt_footer").css("display", "block");
            }
               ///End Modified By IQRA 13July2022
            
        });
}
///End Modified By Irfan Mahmood 7July2022
function ARSummaryDetails(type) {
    debugger
    if (type == "Insurance") {
        debugger
        ARSummaryInsurance(this);
    }
    else {
        ARPatient();
    }
}

function ARSummaryInsurance(elem) {
    debugger

    $.post("../../ProviderPortal/ReportsNew/ARAgingSummaryReportHandler.aspx",
        {
            AgingType: $(".tBodyARAgingSummary").find("#hdnAgingType").val(),
            PracticeLocationId: $(".tBodyARAgingSummary").find("#hdnPracticeLocationId").val(),
            ProviderId: $(".tBodyARAgingSummary").find("#hdnProviderId").val(),
            PayerId: $(".tBodyARAgingSummary").find("#hdnPayerId").val(),
            Asof: $(".tBodyARAgingSummary").find("#hdnAsof").val(),
            Action: "FirstDetail"

        }, function (data) {
            debugger
            var start = data.indexOf("###SFIPart###") + 15;
            var end = data.indexOf("###EFIPart###");
            var returnHtml = $.trim(data.substring(start, end));
            /* $(".divReportFilters").hide()*/
            $(".divInsuranceDetail").show()

            $(".divInsuranceDetail").html(returnHtml);


        });




}
var NoOfRow;
function ARInsuranceBilledAs(BilledAs, Aging) {
    NoOfRow = 10;
    debugger
    if (BilledAs == "Patient") {
    
        return
    }
    else
    {
        if (BilledAs == "Insurance") {
            BilledAs = "";
        }
    $.post("../../ProviderPortal/ReportsNew/ARAgingSummaryReportHandler.aspx",
        {
            AgingType: $(".tBodyARAgingSummary").find("[id$='hdnAgingType']").val(),
            PracticeLocationId: $(".tBodyARAgingSummary").find("[id$='hdnPracticeLocationId']").val(),
            ProviderId: $(".tBodyARAgingSummary").find("[id$='hdnProviderId']").val(),
            PayerId: $(".tBodyARAgingSummary").find("[id$='hdnPayerId']").val(),
            Asof: $(".tBodyARAgingSummary").find("[id$='hdnAsof']").val(),
            BilledAs: BilledAs,
            Aging: Aging,
            Action: "SecondDetail"

        }, function (data) {
            debugger
            var start = data.indexOf("###S2IPart###") + 15;
            var end = data.indexOf("###E2IPart###");
            var returnHtml = $.trim(data.substring(start, end));
                $(".divDialogReportFilters").html(returnHtml);
                $(".totalRows").html("Total Rows : " + $("[id$='hdnInsRows']").val());

            GenerateReportPaging($("[id$='hdnInsRows']").val(), $("#ddlPaging").val());
            $(".ARAging_pagination").css("display", "");
            $(".Reports_Rows_Per_Page").css("display", "");
            $(".txt_page_Number").val("1")
            $("#divDialogReportFilters").dialog({
                width: 1160,
                modal: true,
                title: BilledAs + " Insurance AR Aging Claims Details",
                open: function () {
                    debugger
                    $(".ui-widget-overlay").last().css("z-index", "9999999");
                    $(".ui-dialog").last().css("z-index", "99999");
                    $(".Pagination_div").css("display", "");
                },
                buttons: {
                    "Close": function () {
                        $(".dialogdiv").hide();
                        $(this).dialog("destroy");
                        $("#dialogue").hide();
                        $(".txt_page_Number").val("1")
                        $(".Report_Footer ").hide();
                        $(".Pagination_div").css("display", "none");
                    }
                },
                close: function () {
                    debugger
                    $(".dialogdiv").hide();
                    $(this).dialog("destroy");
                    $("#dialogue").hide();
                    $(".txt_page_Number").val("1")
                    $(".Report_Footer ").hide();
                    $(".Pagination_div").css("display", "none");

                }
            });
   

    });
    }
}
function FilterARInsuranceBilledAs(BilledAs, Aging, Row, PageNumber) {
    debugger
    $.post("../../ProviderPortal/ReportsNew/filter/FilterARAgingSummaryReport.aspx",
        {
            AgingType: $(".tBodyARAgingSummary").find("[id$='hdnAgingType']").val(),
            PracticeLocationId: $(".tBodyARAgingSummary").find("[id$='hdnPracticeLocationId']").val(),
            ProviderId: $(".tBodyARAgingSummary").find("[id$='hdnProviderId']").val(),
            PayerId: $(".tBodyARAgingSummary").find("[id$='hdnPayerId']").val(),
            Asof: $(".tBodyARAgingSummary").find("[id$='hdnAsof']").val(),
            BilledAs: BilledAs,
            Aging: Aging,
            Row: Row,
            PageNumber: PageNumber,
            Action: "SecondDetail"

        }, function (data) {
            debugger
            var start = data.indexOf("###S2IPart###") + 15;
            var end = data.indexOf("###E2IPart###");
            var returnHtml = $.trim(data.substring(start, end));
            $(".SecondDetail").html(returnHtml);
            $(".totalRows").html("Total Rows : " + $("[id$='hdnInsRows']").val());
            GenerateReportPaging($("[id$='hdnInsRows']").val(), Row);
            $(".ARAging_pagination").css("display", "");
            $(".Pagination_div").css("display", "");
            $(".Reports_Rows_Per_Page").css("display", "");
            if (PageNumber == 0) {
                $('.txt_page_Number').val("1")
            }

    });
}
function FilterARPatient(Row, PageNumber) {

    $.post("../../ProviderPortal/ReportsNew/filter/FilterARAgingSummaryReport.aspx",
        {
            AgingType: $(".tBodyARAgingSummary").find("[id$='hdnAgingType']").val(),
            PracticeLocationId: $(".tBodyARAgingSummary").find("[id$='hdnPracticeLocationId']").val(),
            ProviderId: $(".tBodyARAgingSummary").find("[id$='hdnProviderId']").val(),
            PayerId: $(".tBodyARAgingSummary").find("[id$='hdnPayerId']").val(),
            Asof: $(".tBodyARAgingSummary").find("[id$='hdnAsof']").val(),
            Row,
            PageNumber,
            Action: "PatientDetail"

        }, function (data) {
            debugger
            var start = data.indexOf("###SPPart###") + 14;
            var end = data.indexOf("###EPPart###");
            var returnHtml = $.trim(data.substring(start, end));

            $(".ArPatientDetail").html(returnHtml);

            $(".totalRows").html("Total Rows : " + $("[id$='hdnPatientDetailRows']").val());
            GenerateReportPaging($("[id$='hdnPatientDetailRows']").val(), $("#ddlPagingPatientDetail").val());
            $(".ARAging_pagination").css("display", "");
            $(".Pagination_div").css("display", "");
            $(".Reports_Rows_Per_Page").css("display", "");
            if (PageNumber == 0) {
                $('.txt_page_Number').val("1")
            }

        });

}
function ARPatient() {

    $.post("../../ProviderPortal/ReportsNew/ARAgingSummaryReportHandler.aspx",
        {
            AgingType: $(".tBodyARAgingSummary").find("[id$='hdnAgingType']").val(),
            PracticeLocationId: $(".tBodyARAgingSummary").find("[id$='hdnPracticeLocationId']").val(),
            ProviderId: $(".tBodyARAgingSummary").find("[id$='hdnProviderId']").val(),
            PayerId: $(".tBodyARAgingSummary").find("[id$='hdnPayerId']").val(),
            Asof: $(".tBodyARAgingSummary").find("[id$='hdnAsof']").val(),

            Action: "PatientDetail"

        }, function (data) {
            debugger
            var start = data.indexOf("###SPPart###") + 14;
            var end = data.indexOf("###EPPart###");
            var returnHtml = $.trim(data.substring(start, end));

            $("#divDialogPatint").html(returnHtml);

            $(".totalRows").html("Total Rows : " + $("[id$='hdnPatientDetailRows']").val());
            GenerateReportPaging($("[id$='hdnPatientDetailRows']").val(), $("#ddlPagingPatientDetail").val());
            $(".ARAging_pagination").css("display", "");
            $(".Pagination_div").css("display", "");
            $(".Reports_Rows_Per_Page").css("display", "");
            if (PageNumber == 0) {
                $('.txt_page_Number').val("1")
            }
            $("#divDialogPatint").dialog({
                width: 1160,
                modal: true,
                title: "Patient Details",
                open: function () {
                    $(".ui-widget-overlay").last().css("z-index", "9999999");
                    $(".ui-dialog").last().css("z-index", "99999999");
                },
                buttons: {
                    "Close": function () {
                        $(".dialogdiv").hide();
                        $(this).dialog("destroy");
                        $("#dialogue").hide();
                        $(".Report_Footer ").hide();
                    }
                },
                close: function () {
                    $(".dialogdiv").hide();
                    $(this).dialog("destroy");
                    $("#dialogue").hide();
                    $(".Report_Footer ").hide();
                }
            });


        });
}

function ARPatientDetail(Patient) {
    debugger
    $.post("../../ProviderPortal/ReportsNew/ARAgingSummaryReportHandler.aspx",
        {
            AgingType: $(".tBodyARAgingSummary").find("[id$='hdnAgingType']").val(),
            PracticeLocationId: $(".tBodyARAgingSummary").find("[id$='hdnPracticeLocationId']").val(),
            ProviderId: $(".tBodyARAgingSummary").find("[id$='hdnProviderId']").val(),
            PayerId: $(".tBodyARAgingSummary").find("[id$='hdnPayerId']").val(),
            Asof: $(".tBodyARAgingSummary").find("[id$='hdnAsof']").val(),
            Patient: Patient,
            Action: "PatClaimDetail"

        }, function (data) {
            debugger
            var start = data.indexOf("###S2PPart###") + 15;
            var end = data.indexOf("###E2PPart###");
            var returnHtml = $.trim(data.substring(start, end));
            $("#PatClaimDetailDeiloge").html(returnHtml);


            $("#PatClaimDetailDeiloge").dialog({
                width: 1160,
                modal: true,
                title: Patient + " Patient Claim Details",
                open: function () {
                    $(".ui-widget-overlay").last().css("z-index", "9999999");
                    $(".ui-dialog").last().css("z-index", "99999999");
                },
                buttons: {
                    "Close": function () {
                        $(".dialogdiv").hide();
                        $(this).dialog("destroy");
                        $("#dialogue").hide();

                    }
                },
                close: function () {
                    $(".dialogdiv").hide();
                    $(this).dialog("destroy");
                    $("#dialogue").hide();

                }
            });


        });
}

function PSDetail(PayerType, Provider, ProviderName) {
    debugger
    var Params = '';

    var InsuranceID = ""
    $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID += $(this).val() + ",";
        }
    });
    $("[id$='ulMultiPayerScenario'] .chk-multi-checkboxes-all").each(function () {
        if ($(this).is(":checked")) {
            InsuranceID = "";
        }
    });
    if (InsuranceID.length > 0) {
        InsuranceID = InsuranceID.slice(0, -1);
    }
    Params = {

    };

    $.post("../../ProviderPortal/ReportsNew/filter/PaymentsSummaryReportHandler.aspx",
        {
            DateType: $("[id$='hdnDateType']").val(),
            DateFrom: $("[id$='hdnDateFrom']").val(),
            DateTo: $("[id$='hdnDateTo']").val(),
            PayerType: PayerType,
            Provider: Provider,
            InsuranceID: InsuranceID,
            ProviderName: ProviderName

        }, function (data) {
            debugger
            var start = data.indexOf("###startReport###") + 19;
            var end = data.indexOf("###endReport###");
            var returnHtml = $.trim(data.substring(start, end));

            $("#PatClaimDetailDeiloge").html(returnHtml);
            $("#PatClaimDetailDeiloge").dialog({
                width: 1160,
                modal: true,
                title: PayerType + " Payment Detail",
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

function RemoveLinkClass() {
    debugger
    $("#lblrejcted").removeClass('linkClass');
}
var _counter = 0;
function HideUnHideFilterLocationWise() {
    debugger
    EnableDisableGroup();
    if (_counter == 0) {
        $(".SearchCriteria").show();
        _counter = 1;

    }
    else if (_counter == 1) {
        $(".SearchCriteria").hide();
        _counter = 0;
    }
    //if ($(".SearchCriteria").hasClass("Filter")) {
    //    $(".SearchCriteria").removeClass("Filter");
    //}
    //else {
    //    $(".SearchCriteria").addClass("Filter");
    //}
}
//function EnableDisableGroup() {
//    debugger
//    var Group = $("#ddlGroupBy option:selected").val();


//    if (Group == "Location") {
//        $("#divReportServiceProvider *").prop('disabled', true);
//        $("#divPracticeLocation *").prop('disabled', false);

//    }
//    if (Group == "Provider") {
//        $("#divPracticeLocation *").prop('disabled', true);
//        $("#divReportServiceProvider *").prop('disabled', false);

//    }
//    if (Group == "") {
//        $("#divPracticeLocation *").prop('disabled', false);
//        $("#divReportServiceProvider *").prop('disabled', false);
//    }
//}
function hideunhideFilter(elem) {
    debugger
    //EnableDisableGroup();
    if ($(".SearchCriteria").hasClass("Filter")) {
        $(".SearchCriteria").removeClass("Filter");
        $("#ddlPostType").val('DOS');
    }
    else {
        $(".SearchCriteria").addClass("Filter");
        $("#ddlPostType").val('DOS');
    }

}


function HideMenu(divMultipleDropdown) {
    debugger

    if ($("#" + divMultipleDropdown).is(':visible')) {
        $("#" + divMultipleDropdown).hide();
    }
    else {
        //$(".div-multi-checkboxes-wrapper").hide();
        $("#" + divMultipleDropdown).show();
    }
    return;

}
function ShowHideMenu(elem) {
    debugger

    if ($(".SearchCriteria").is(':visible')) {
        $(".SearchCriteria").hide();
    }
    else {
        $(".SearchCriteria").show();
    }
}
function changedate() {
    debugger
    $("[id$='FilterReports']").prop("disabled", false);
}



