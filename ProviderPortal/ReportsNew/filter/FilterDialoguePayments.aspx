<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterDialoguePayments.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterDialogue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
        <style type="text/css">
            .SpecificDates {
                display: block;
                line-height: 14px;
            }

            .divDialogReportFilterBoxInnerHeader {
                text-align: center;
            }

            a

            .divReportName {
                color: black;
                font-weight: bold;
                line-height: 24px;
                margin-bottom: 10px;
            }

            .spnBranchName {
                float: left;
                font-weight: bold;
                width: 20%;
                padding-top: 5px;
            }

            .BranceInput {
                width: 80%;
                float: left;
            }

            .reportdropdown {
                padding: 5px 0px 4px 4px;
                width: 74.6%;
                float: right;
                position: absolute;
                background-color: #FFFFFF;
                border: 1px solid #ccc;
                -moz-border-radius: 3px;
                -webkit-border-radius: 3px;
                color: #000000;
                text-align: left;
                min-width: 175px;
                height: 20px;
            }

            .spnTimeSpan {
                font-weight: bold;
            }

            /*.divTimeSpan {
                background-color: #DCDCDC;
            }*/

            .divTable {
                width: 100%;
                /*height: 120px;*/
                border-color: #ccc;
                border-radius: 4px;
                box-sizing: border-box;
            }

            .divTableRow {
                display: table-row;
            }

            .divTableHeading {
                background-color: #EEE;
                display: table-header-group;
            }


            .divTableHeading {
                background-color: #EEE;
                display: table-header-group;
                font-weight: bold;
            }

            .divTableFoot {
                background-color: #EEE;
                display: table-footer-group;
                font-weight: bold;
            }

            .divTableBody {
                display: table-row-group;
            }

            .ui-dialog .ui-dialog-buttonpane {
                /*background-color: #696969 !important;*/
                background: #f5f5f5 !important;
            }

            #myNewImage {
                margin-top: -5%;
                width: 16px;
                height: 16px;
                margin-left: -1.4%;
                background-color: #696969;
                border-radius: 5px 0px 0px 0px;
                border-bottom-style: solid;
            }

            .selectedText {
                width: 92%;
                height: 32px;
                overflow: hidden;
                top: 6px;
                position: absolute;
                white-space: nowrap;
                margin-left: 2%;
            }

            #txtReportDateFrom, #txtReportDateTo {
                width: 100%;
            }

            .radio_li {
                padding-bottom: 5px;
            }

            .row {
                width: 100%;
            }

            .col40 {
                width: 40%;
                float: left;
                padding-left: 10px;
                padding-right: 10px;
                box-sizing: border-box;
            }

            .col60 {
                width: 60%;
                float: left;
                padding-left: 10px;
                padding-right: 10px;
                box-sizing: border-box;
            }

            .divBranchName {
                width: 100%;
            }

            .ddlselect {
                float: left;
                max-height: 170px;
                overflow-y: auto;
                margin-bottom: -2px;
            }

            .DateRangeMessage {
                position: absolute;
                text-align: center;
                margin: -42px 5px 0px 200px;
                background: #f8d7da;
                padding: 5px 0px 5px 0;
                border-color: #f5c6cb;
                border-radius: 5px;
                float: right;
                width: 50%;
                color: red;
                font-weight: bold;
                font-style: italic;
            }

            .maindivofddl {
                float: left;
                width: 100%;
                margin-top: 32px;
                background: white;
                position: relative;
                z-index: 999;
                border: 1px solid #ccc;
                padding: 0px 2px;
            }

            #Div_MultiStatus {
                float: left;
                max-height: 225px;
                width: 13%;
                top: 126px;
                background: #fdfdfd;
                position: absolute;
                z-index: 999;
                border: 1px solid #ccc;
                margin-left: 83.5%;
                padding: 0px 5px;
            }

            #ulMultiInsurances, #ulMultiStatus {
                overflow-y: scroll;
                max-height: 173px;
                padding: 5px 0px;
            }

            #Div_MultiInsurances {
                float: left;
                max-height: 225px;
                width: 75%;
                top: 3px;
                background: #fdfdfd;
                position: absolute;
                z-index: 9999;
                border: 1px solid #ccc;
                margin-left: 26%;
                padding: 0px 5px;
                width: 97%;
            }
        </style>
            <script type="text/javascript">


                function Provider_multifunction() {
                    debugger;

                }
                //Added by Syed Sajid Ali Des:Check Validation for Dates Date:04-11-2019
                function CheckDates() {
                    debugger;
                    var from = new Date(Date.parse($(".RFSDOSFrom ").attr("value")));
                    var to = new Date(Date.parse($(".RFSDOSTo ").attr("value")));
                    if (from > to) {
                        $(".RFSDOSTo ").val("");
                        $(".DateRangeMessage").show();
                        return;
                    }
                    var Pfrom = new Date(Date.parse($(".RFSPostDateFrom").attr("value")));
                    var Pto = new Date(Date.parse($(".RFSPostDateTo").attr("value")));
                    if (Pfrom > Pto) {
                        $(".RFSPostDateTo").val("");
                        $(".DateRangeMessage").show();
                        return;
                    }
                    var Rfrom = new Date(Date.parse($("#txtReportDateFrom").attr("value")));
                    var Rto = new Date(Date.parse($("#txtReportDateTo").attr("value")));
                    if (Rfrom > Rto) {
                        $("#txtReportDateTo").val("");
                        $(".DateRangeMessage").show();
                        return;
                    }
                    var Bfrom = new Date(Date.parse($("#txtBillDateFrom").attr("value")));
                    var Bto = new Date(Date.parse($("#txtBillDateTo").attr("value")));
                    if (Bfrom > Bto) {
                        $("#txtBillDateTo").val("");
                        $(".DateRangeMessage").show();
                        return;
                    }
                    $(".DateRangeMessage").hide();
                }
                //end by Syed Sajid Ali 
                $(function () {
                    $("#txtReportDateTo").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-5 : +0",
                        maxDate: new Date(),
                        onSelect: function () {
                            CheckDates();
                        },
                    });
                    $("#txtDueDateFrom").datepicker();
                    $("#txtReportDateFrom").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-5 : +0",
                        maxDate: new Date(),
                        onSelect: function () {
                            CheckDates();
                        },
                    });
                    $(".RFSDOS").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-5 : +0",
                        maxDate: new Date(),
                        onSelect: function () {
                            CheckDates();
                        },

                    }).mask("99/99/9999");

                    $(".RFSPostDate").datepicker({
                        focus: false,
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-5 : +0",
                        maxDate: new Date(),
                        onSelect: function () {
                            CheckDates();
                        },
                    }).mask("99/99/9999");
                    $("#txtAgingDate").datepicker({
                        changeMonth: true,
                        changeYear: true,
                    });
                    $("#txtBillDateFrom").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-5 : +0",
                        maxDate: new Date(),
                        onSelect: function () {
                            CheckDates();
                        },
                    });
                    $("#txtdateasof").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-5 : +0",
                        maxDate: new Date(),
                        //onSelect: function () {
                        //    CheckDates();
                        //},
                    }).mask("99/99/9999");


                    $("#txtBillDateTo").datepicker({
                        changeMonth: true,
                        changeYear: true,
                        yearRange: "-5 : +0",
                        maxDate: new Date(),
                        onSelect: function () {
                            CheckDates();
                        },
                    });

                    //Satrt Added by Rizwan kharal 26April2018

                    $("#txtDosDateFrom").datepicker({
                        changeMonth: true,
                        changeYear: true,
                    });
                    $("#txtDosDateTo").datepicker({
                        changeMonth: true,
                        changeYear: true,
                    });

                    //End Added by Rizwan kharal 26April2018


                    $("#txtClaimPostDate").datepicker({
                        changeMonth: true,
                        changeYear: true,
                    });
                    $("#ddlMonthlyReconciliationYear").prop("disabled", true);
                    $("#ddlMonthlyReconciliationYear").css("background", "#f5f5f5");
                    $("#ddlMonthlyReconciliationMonth").prop("disabled", true);
                    $("#ddlMonthlyReconciliationMonth").css("background", "#f5f5f5");
                });
                function GetPayerDropDown(elem) {

                    var payerName = "";
                    var checkNumber = "";
                    $('.ddlPayerName').each(function () {
                        {
                            payerName = $("option:selected", this).val();
                        }
                    });
                    $('.ddlCheckNumber').each(function () {
                        {
                            checkNumber = $("option:selected", this).val();
                        }
                    });
                    var params = {
                        PayerName: payerName,
                        CheckNumber: checkNumber,
                        action: "Filter"
                    };

                    var actionPage = "GetPayerDetailDropdown.aspx";
                    $.post(_EMRPath + "/Reports/CallBacks/" + actionPage, params, function (data) {
                        if (elem == "divddlCheckNumber") {
                            var start = data.indexOf("###StartCheckNumber###") + 22;
                            var end = data.indexOf("###EndCheckNumber###");
                            var returnHtml = $.trim(data.substring(start, end));

                            $("#divddlCheckNumber").html(returnHtml)
                        }
                        else if (elem == "divddlPostDate") {
                            var start = data.indexOf("###StartPostDate###") + 19;
                            var end = data.indexOf("###EndPostDate###");
                            var returnHtml = $.trim(data.substring(start, end));

                            $("#divddlPostDate").html(returnHtml)
                        }
                        /*.promise()
                        .done(function () {
                            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');
    
                            start = data.indexOf("###StartTotal###") + 16;
                            end = data.indexOf("###EndTotal###");
                            returnHtml = $.trim(data.substring(start, end));
    
                            $("[id$='hdnTotalRows']").val(returnHtml);
    
                            if (paging == true) {
                                GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
                            }
                        });*/
                    });
                }
                function GetServiceProviderDropDown() {

                    var PracticeLocationId = "";
                    $("[id$='ulMultiPracticeLocation'] .chk-multi-checkboxes").each(function () {
                        if ($(this).is(":checked")) {
                            PracticeLocationId += $(this).parent().find("input[type='hidden']").val() + ",";
                        }
                    });
                    if (PracticeLocationId.length > 0) {
                        PracticeLocationId = PracticeLocationId.slice(0, -1);
                    }
                    var params = {
                        PracticeLocationId: PracticeLocationId,
                        action: "Filter"
                    };

                    var actionPage = "GetServiceProviderDropdown.aspx";
                    $.post(_EMRPath + "/Reports/CallBacks/" + actionPage, params, function (data) {
                        var start = data.indexOf("###StartServiceProvider###") + 26;
                        var end = data.indexOf("###EndServiceProvider###");
                        var returnHtml = $.trim(data.substring(start, end));

                        $("#divServiceProvider").html(returnHtml)
                    });
                }


                //Procedure Code
                var searchfrom, _CurrentTextBoxICD = null;

                function searchIcDs(searchBy, code, desc, elm, event) {

                    _CurrentTextBoxICD = $(elm);
                    if (event.keyCode == 27) {
                        $("#divICDsSearched").hide("");
                        return false;
                    }

                    $.post("../../Providerportal/Controls/ICDSearch.aspx", { Code: $.trim(code), Description: $.trim(desc) }, function (data) {
                        var returnHtml = data;
                        var start = data.indexOf("###StartICDSearch###") + 22;
                        var end = data.indexOf("###EndICDSearch###");
                        $("#divICDsSearched").html(returnHtml.substring(start, end));

                        var tdClass = $(elm).closest("td").attr('class');

                        if (tdClass == "leftTd") {
                            //$("#divICDsSearched").css({
                            //    left: 7 + "%",
                            //    top: $(elm).offset().top - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + $(elm).closest("td").height() + "px"
                            //});
                        }
                        else if (tdClass == "rightTd") {
                            var _leftCss;
                            if ($(elm).attr("id") == "txtIcdCode2" || $(elm).attr("id") == "txtIcdCode4") {
                                //_leftCss = $(elm).offset().left + "px";
                            } else {
                                //_leftCss = $(elm).offset().left - ($("#divICDsSearched").width() - $(elm).closest("td").width()) - 35 + "px";
                            }
                            $("#divICDsSearched").css({
                                //left: _leftCss,
                                //top: $(elm).offset().top - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + $(elm).closest("td").height() + "px"
                            });

                        }
                        //$("#divICDsSearched").show();

                        $("#divICDsSearched").slideDown("slow");
                        $("#divICDsSearched").scrollTop(0);
                        searchfrom = $(elm).attr('id');
                    });
                }
                function emptyICDVal(elm, code) {

                    $(elm).parent("td").find("input").val('');
                    $(elm).parent("td").prev().find("input").val('');

                    $(".DX" + code + "PointerCheckbox :checkbox").prop("checked", false);

                    $("#tblItemsTreatmentPlan tbody tr:not(:last) .selectedText").each(function () {
                        var SelectedText = $(this).text();
                        if (SelectedText.length == 1) {
                            SelectedText = SelectedText.replace(code, '');
                        }
                        else {
                            SelectedText = SelectedText + ", ";
                            SelectedText = SelectedText.replace(code + ", ", '');
                            SelectedText = SelectedText.substring(0, SelectedText.length - 2);
                        }

                        $(this).text(SelectedText);
                        $(this).attr('title', SelectedText);

                    });
                }

                function PopulateICD9Desc(elm, descInputId) {
                    var flag = 0;
                    $("#divICDsSearched table tbody tr").each(function () {
                        var code = $.trim($(this).find("td:eq(0)").html());
                        if ($(elm).val() == code) {
                            var desc = $.trim($(this).find("td:eq(1)").html());
                            $("#" + descInputId).val(desc);
                            flag = 1;
                            return;
                        }
                    });

                    if (flag == 0) {
                        $(elm).val("");
                        $("#" + descInputId).val("");
                    }
                }

                function PopulateICD9Code(elm, codeInputId) {
                    var flag = 0;

                    $("#divICDsSearched table tbody tr").each(function () {
                        var desc = $.trim($(this).find("td:eq(1)").html());

                        if ($(elm).val().toUpperCase() == desc.toUpperCase()) {
                            var code = $.trim($(this).find("td:eq(0)").html());
                            $("#" + codeInputId).val(code);
                            flag = 1;

                            return;
                        }
                    });

                    if (flag == 0) {
                        $(elm).val("");
                        $("#" + codeInputId).val("");
                    }
                }

                function LCD_OpenForm(elem, Type, CallFrom) {
                    var PagePath = "";

                    if (Type == "DX") {
                        PagePath = "../../providerportal/Controls/LCDDiagnosis.aspx";

                        if (CallFrom == "PatientChart") {
                            _DXCode = $(elem).closest("tr").find(".DiagCode").val();
                        }
                        else if (CallFrom == "ClaimForm") {
                            _DXCode = $.trim($(elem).closest("td").prev().find("input:text").val());
                        }
                    }
                    else if (Type == "Procedure") {
                        PagePath = "../../providerportal/Controls/LCDProcedure.aspx";

                        if (CallFrom == "PatientChart") {
                            _HCPCSCode = $(elem).closest("tr").find(".hdnCPTCode").val();
                        }
                        else if (CallFrom == "ClaimForm") {
                            _HCPCSCode = $(elem).closest("tr").find(".hdnCPTCode").val();
                        }

                        if (_HCPCSCode == "") {
                            return;
                        }
                    }

                    var params = {
                        DXCode: _DXCode,
                        HCPCSCode: _HCPCSCode,
                        action: "LoadLCDForm"
                    };

                    $.post(PagePath, params, function (data) {
                        if (!LCD_CheckCount(data)) {
                            return;
                        }

                        var start = data.indexOf("###StartForm###") + 15;
                        var end = data.indexOf("###EndForm###");
                        var returnHtml = $.trim(data.substring(start, end));

                        $("[id$='divDialogLCD']").html(returnHtml)
                            .promise()
                            .done(function () {
                                LCD_OpenForm_Done();
                            });
                    });
                }
                function SelectICD(elem) {

                    var icdCode = ''; var IcdDesc = '';

                    icdCode = $.trim($(elem).closest("tr").find(".hdnCode").html());
                    IcdDesc = $.trim($(elem).closest("tr").find(".hdnDescription").html());
                    _CurrentTextBoxICD = null;
                    $("#txtIcdCode1").val(icdCode);
                    $("#txtIcdDesc1").val(IcdDesc);
                    $("#divICDsSearched").hide();
                }

                function addServiceRow(elem) {


                    if ($(elem).hasClass("txtUnits")) {
                        var charges = $(elem).closest("tr").find(".hdnClaimCPTCharges").val();
                        var Units = $(elem).val();
                        var totalCharge = 0;

                        if (Units == parseFloat(Units) && charges == parseFloat(charges)) {
                            totalCharge = parseFloat(Units) * parseFloat(charges);
                            $(elem).closest("tr").find(".txtCharges").val(totalCharge);
                        }
                    }

                    if (!$(elem).closest("tr").is(".lastServiceRow")) {

                        return;

                    }

                    $("#tbodyClaimServices > tr").removeClass("lastServiceRow");
                    var serviceRowHtml = $.trim($("#tbodySampleServiceRow").html());
                    $("#tbodyClaimServices").append(serviceRowHtml);
                }
                /************************CPT*********************/
                var searchfromCPT, _CurrentTextBoxCPT = null;
                function emptyCPTVal(elm, code) {

                    $(elm).parent("td").find("input").val('');
                    $(elm).parent("td").prev().find("input").val('');

                    $(".DX" + code + "PointerCheckbox :checkbox").prop("checked", false);

                    $("#tblItemsTreatmentPlan tbody tr:not(:last) .selectedText").each(function () {
                        var SelectedText = $(this).text();
                        if (SelectedText.length == 1) {
                            SelectedText = SelectedText.replace(code, '');
                        }
                        else {
                            SelectedText = SelectedText + ", ";
                            SelectedText = SelectedText.replace(code + ", ", '');
                            SelectedText = SelectedText.substring(0, SelectedText.length - 2);
                        }

                        $(this).text(SelectedText);
                        $(this).attr('title', SelectedText);

                    });
                }
                function PopulateCPTDesc(elm, descInputId) {
                    debugger;
                    var flag = 0;
                    $("#divCPTSearched table tbody tr").each(function () {
                        var code = $.trim($(this).find("td:eq(0)").html());
                        if ($(elm).val() == code) {
                            var desc = $.trim($(this).find("td:eq(1)").html());
                            $("#" + descInputId).val(desc);
                            flag = 1;
                            return;
                        }
                    });

                    if (flag == 0) {
                        $(elm).val("");
                        $("#" + descInputId).val("");
                    }
                }

                function PopulateCPTCode(elm, codeInputId) {
                    var flag = 0;

                    $("#divCPTSearched table tbody tr").each(function () {
                        var desc = $.trim($(this).find("td:eq(1)").html());

                        if ($(elm).val().toUpperCase() == desc.toUpperCase()) {
                            var code = $.trim($(this).find("td:eq(0)").html());
                            $("#" + codeInputId).val(code);
                            flag = 1;

                            return;
                        }
                    });

                    if (flag == 0) {
                        $(elm).val("");
                        $("#" + codeInputId).val("");
                    }
                }
                function searchCPTs(searchBy, code, desc, elem, event) {

                    _CurrentCPTSearchedElement = $(elem);
                    var Code = $.trim($(elem).val());
                    //$(elem).val("");

                    if (event.keyCode == 27) {
                        $("#divCPTSearched").hide();
                        return false;
                    }

                    $.post("../../ProviderPortal/Controls/CPTCodesSearch.aspx", { Code: Code }, function (data) {
                        var returnHtml = data;
                        var start = data.indexOf("###StartCPTSearch###") + 20;
                        var end = data.indexOf("###EndCPTSearch###");
                        $("#CPTSearchedList").html(returnHtml.substring(start, end));
                        AddNoRecordFoundInGrids("CPTSearchedList");
                        //$("#divCPTSearched").css({
                        //    left: $(elem).offset().left,
                        //    top: $(elem).offset().top - $(".contentWrapper").offset().top + $(".contentWrapper").scrollTop() + $(elem).closest("td").height() + "px"
                        //});

                        $("#divCPTSearched").slideDown("slow");
                        $("#divCPTSearched").scrollTop(0);
                        addServiceRow(elem);
                        searchfromCPT = $(elem).attr('id');
                    });
                    //$("#divICDsSearched").show();
                }

                function searchProcedureCode(searchBy, code, desc, elem, event) {

                    _CurrentCPTSearchedElement = $(elem);
                    var Code = $.trim($(elem).val());
                    //$(elem).val("");

                    if (event.keyCode == 27) {
                        $("#divCPTSearchedReport").hide();
                        return false;
                    }

                    $.post("../../ProviderPortal/Controls/CPTCodesSearch.aspx", { Code: Code }, function (data) {
                        var returnHtml = data;
                        var start = data.indexOf("###StartCPTSearchReport###") + 26;
                        var end = data.indexOf("###EndCPTSearchReport###");
                        $("#CPTSearchedListReport").html(returnHtml.substring(start, end));

                        $("#divCPTSearchedReport").slideDown("slow");
                        $("#divCPTSearchedReport").scrollTop(0);
                        addServiceRow(elem);
                        searchfromCPT = $(elem).attr('id');
                    });
                }
                function SelectCPT(elem) {

                    var cptCode = ''; var cptDesc = '';
                    cptCode = $.trim($(elem).closest("tr").find(".cpt-code").html());
                    cptDesc = $.trim($(elem).closest("tr").find(".cpt-description").html());
                    _CurrentTextBoxCPT = null;
                    $("#txtCPTCode").val(cptCode);
                    $("#txtCPTDescription").val(cptDesc);
                    $("#divCPTSearched").hide();
                    SelectServiceCode(cptCode)

                }
                function AddNoRecordFoundInGrids(tblTbody) {
                    if ($("#" + tblTbody + " tr").not(".trNoRecord").length == 0) {
                        var colspan = $("#" + tblTbody).parent().find("thead th").length;
                        $("#" + tblTbody).html("<tr style='text-align:center;' class='trNoRecord'><td colspan='" + colspan + "'><span Style='color: red; font-size: 14px; font-weight: bold;font-style: italic;'>No record found.</span></td></tr>");
                    }
                    else
                        $("#" + tblTbody + " tr.trNoRecord").remove();
                }



                var MRLocationId = "";
                //Shahid kamzi Sb
                function GetMonthlyReconciliationtMonthYearDropDown(elem) {

                    debugger;
                    var MRYear = "";
                    $('.ddlMonthlyReconciliationLocation').each(function () {
                        {
                            MRLocationId = $("option:selected", this).val();
                        }
                    });
                    $('.ddlMonthlyReconciliationYear').each(function () {
                        {
                            MRYear = $("option:selected", this).val();
                        }
                    });
                    if (MRLocationId != "") {
                        $("#ddlMonthlyReconciliationYear").prop("disabled", false);
                        $("#ddlMonthlyReconciliationYear").css("background", "white");

                        $("[id$='ddlMonthlyReconciliationProvider']").prop("disabled", false);
                        $("[id$='ddlMonthlyReconciliationProvider']").css("background", "white");
                        $("[id$='ddlProviderType']").prop("disabled", false);
                        $("[id$='ddlProviderType']").css("background", "white");
                    }
                    if (MRYear != "") {

                        $("#ddlMonthlyReconciliationMonth").prop("disabled", false);
                        $("#ddlMonthlyReconciliationMonth").css("background", "white");
                    }
                    var ProviderType = $("[id$='ddlProviderType'] option:selected").text();
                    var ProviderName = $.trim($("[id$='ddlMonthlyReconciliationProvider'] option:selected").text());
                    if (ProviderName == "All" || ProviderName == "No Provider available at this location") {
                        ProviderName = "";
                    }
                    var params = {
                        MRLocationId: MRLocationId,
                        ProviderType: ProviderType,
                        ProviderName: ProviderName,
                        MRYear: MRYear,
                        action: "Filter"
                    };

                    var actionPage = "GetMonthlyReconciliationtMonthYearDropdown.aspx";
                    $.post(_EMRPath + "/Reports/CallBacks/" + actionPage, params, function (data) {
                        if (elem == "divddlMonthlyReconciliationYear") {
                            var start = data.indexOf("###StartYear###") + 15;
                            var end = data.indexOf("###EndYear###");
                            var returnHtml = $.trim(data.substring(start, end));

                            $("#divddlMonthlyReconciliationYear").html(returnHtml)
                        }
                        else if (elem == "divddlMonthlyReconciliationMonth") {
                            var start = data.indexOf("###StartMonth###") + 16;
                            var end = data.indexOf("###EndMonth###");
                            var returnHtml = $.trim(data.substring(start, end));

                            $("#divddlMonthlyReconciliationMonth").html(returnHtml)
                        }


                    });
                }
                /////Rizwan kharal 2May2018
                function ProviderOnLocation() {
                    var actionPage = "GetMonthlyReconciliationtMonthYearDropdown.aspx";
                    var ProviderType = $("[id$='ddlProviderType'] option:selected").text();
                    var ProviderName = $.trim($("[id$='ddlMonthlyReconciliationProvider'] option:selected").text());

                    if (ProviderName == "All" || ProviderName == "No Provider available at this location") {
                        ProviderName = "";
                    }

                    var MRYear = "0";
                    var params = {
                        MRLocationId: MRLocationId,
                        ProviderType: ProviderType,
                        action: "ProviderOnLocation",
                        ProviderName: ProviderName,
                        MRYear: MRYear
                    };
                    $.post(_EMRPath + "/Reports/CallBacks/" + actionPage, params, function (data) {

                        //Added By Rizwan kharal 30April2018
                        $("[id$='ddlMonthlyReconciliationProvider']").css("display", "none");
                        var start = data.indexOf("###Startddl###") + 15;
                        var end = data.indexOf("###Endddl###");
                        var returnHtml = $.trim(data.substring(start, end));
                        $("[id$='MonthlyReconciliationProvider']").html(returnHtml);

                        var startyear = data.indexOf("###StartYear###") + 15;
                        var endyear = data.indexOf("###EndYear###");
                        var returnHtmlyear = $.trim(data.substring(startyear, endyear));

                        $("#divddlMonthlyReconciliationYear").html(returnHtmlyear);



                    });
                }
                /////Rizwan kharal 3May2018
                function LoadYearonProvider() {
                    var actionPage = "GetMonthlyReconciliationtMonthYearDropdown.aspx";
                    var ProviderType = $("[id$='ddlProviderType'] option:selected").text();
                    var ProviderName = $.trim($("[id$='ddlMonthlyReconciliationProvider'] option:selected").text());

                    if (ProviderName == "All" || ProviderName == "No Provider available at this location") {
                        ProviderName = "";
                    }

                    var MRYear = "0";
                    var params = {
                        MRLocationId: MRLocationId,
                        ProviderType: ProviderType,
                        action: "LoadYearonProvider",
                        ProviderName: ProviderName,
                        MRYear: MRYear
                    };
                    $.post(_EMRPath + "/Reports/CallBacks/" + actionPage, params, function (data) {

                        //Added By Rizwan kharal 30April2018
                        $("[id$='ddlMonthlyReconciliationProvider']").css("display", "none");
                        var start = data.indexOf("###Startddl###") + 15;
                        var end = data.indexOf("###Endddl###");
                        var returnHtml = $.trim(data.substring(start, end));
                        $("[id$='MonthlyReconciliationProvider']").html(returnHtml);

                        var startyear = data.indexOf("###StartYear###") + 15;
                        var endyear = data.indexOf("###EndYear###");
                        var returnHtmlyear = $.trim(data.substring(startyear, endyear));

                        $("#divddlMonthlyReconciliationYear").html(returnHtmlyear);
                    });
                }
                function Enable_DisableDates() {
                    debugger;
                    var ddlDateType = $("#ddlDateType").val();
                    if (ddlDateType == "DOS") {
                        $(".RFSDOS").prop('disabled', false);
                        $(".RFSPostDate").prop('disabled', true);
                        $(".RFSPostDate").val("");
                    }
                    else if (ddlDateType == "PostDate") {
                        $(".RFSPostDate").prop('disabled', false);
                        $(".RFSDOS").prop('disabled', true);
                        $(".RFSDOS").val("");
                    }
                    else if (ddlDateType == "") {
                        $(".RFSPostDate").prop('disabled', true);
                        $(".RFSDOS").prop('disabled', true);
                        $(".RFSDOSFrom ").val("");
                        $(".RFSDOSTo").val("");
                        $(".RFSPostDateFrom").val("");
                        $(".RFSPostDateTo").val("");
                        $(".DateRangeMessage").hide();
                    }
                }

                function ValidateNumber(evt) {

                    debugger
                    var charCode = (evt.which) ? evt.which : evt.keyCode;
                    var code = evt.keyCode || evt.which;
                    if ((charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) && (charCode != 45)) {
                        return false;
                    }
                    else {
                        return true;
                    }
                }


                function SelectPayerTypedll() {
                    debugger;
                    var PayerType = $("#ddlPayerType").val();
                    if (PayerType == "Insurance") {
                        $("[id$='divPayerDropDownSearch']").show();
                        $("[id$='divReportPatientName']").hide();
                    }
                    else if (PayerType == "Patient") {
                        $("[id$='divReportPatientName']").show();
                        $("[id$='divPayerDropDownSearch']").hide();
                    }
                    else {
                        $("[id$='divReportPatientName']").hide();
                        $("[id$='divPayerDropDownSearch']").hide();
                    }
                    $(".SearchTextBoxForRpt").val("");
                }

                //ali imran
                $('#MultipleInsurancesTxt').click(function () {

                    if ($("#Div_MultiInsurances").is(":hidden")) {
                        $("#Div_MultiStatus").hide();
                        $("#Div_MultiInsurances").show();
                        var lastChar = _NewInsuranceIds[_NewInsuranceIds.length - 1];
                        var NewInsuranceid = "";
                        if (lastChar == ',') {
                            NewInsuranceid = _NewInsuranceIds.substring(0, _NewInsuranceIds.length - 1);
                        }
                        else {
                            NewInsuranceid = _NewInsuranceIds;
                        }
                        if (NewInsuranceid != "") {

                            var array = [];
                            array = NewInsuranceid.split(',');
                            for (var i = 0; i < array.length; i++) {
                                var arrayvalue = array[i];
                                $('.MultiCheckBox').each(function () {

                                    var checkboxValue = $(this).parent().find(".InsuranceId").val();

                                    if (arrayvalue == checkboxValue) {

                                        $(this).attr("checked", true);

                                    }

                                });
                            }
                        }

                    }
                    else {
                        $("#Div_MultiInsurances").hide();
                    }


                    $("#ulMultiInsurances").animate({ scrollTop: 0 }, "fast");

                });



                function SearchInsuranceOnEnter(event) {

                    var a = event.which || event.keyCode;
                    if (a == 13) {
                        var SearchMultiInsurances = $("#searchMultiInsurances").val() || "";
                        SearchMultipleImusrance(SearchMultiInsurances);

                    }

                }
                function SearchMultipleImusrance(SearchMultiInsurances) {
                    var reportrelated = _selectedReport_Filter;
                    var action = "SearchMultiInsuranceFromInsurance";
                    console.log(_selectedReport_Filter);
                    if (reportrelated == 'FilterPaymentsSummaryAndDetail.aspx') {
                        action = "SearchMultiInsuranceFromERA";
                    }
                    $.post("../Claims/Callbacks/BillingManagerHandler.aspx", { SearchMultiInsurances: SearchMultiInsurances, Action: action }, function (data) {

                        var start = data.indexOf("###StartulMultiReports###") + 26;
                        var end = data.indexOf("###EndulMultiReports###");
                        var returnHtml = data.substring(start, end);

                        $("#FilterulMultiInsurances").html(returnHtml);


                        $("#searchMultiInsurances").val(SearchMultiInsurances);

                        if (SearchMultiInsurances != "") {


                            $("#AllChkli").hide();
                        }
                        else {
                            $("#AllChkli").css("display", "block");
                        }
                        if (_NewInsuranceIds != "") {

                            var NewInsuranceIds = _NewInsuranceIds.substring(0, _NewInsuranceIds.length - 1);

                            var array = [];

                            array = NewInsuranceIds.split(',');

                            for (var i = 0; i < array.length; i++) {


                                $('.MultiCheckBox').each(function () {
                                    var checkboxValue = $(this).parent().find(".InsuranceId").val();
                                    var arrayvalue = array[i];
                                    if (arrayvalue == checkboxValue) {

                                        $(this).attr("checked", true);

                                    }

                                });


                            }
                            //Added By Asad Mehmood 14/09/2020
                            let totalchecks = $('.MultiCheckBox').length;
                            let checked = $('.MultiCheckBox:checked').length;
                            if (SearchMultiInsurances == "" && (totalchecks == checked)) {
                                $('.AllCheckBox').prop('checked', true);
                            }


                        }

                    });
                }

                var _NewInsuranceIds = "";
                var _NewInsuranceName = "";
                function GetMultiCheckedInusrances() {
                    var InsuranceName = "";

                    InsuranceIds = _NewInsuranceIds;
                    InsuranceName = _NewInsuranceName;


                    if ($(".AllCheckBox").is(":checked")) {

                        if ($(".AllCheckBox").is(":visible")) {

                            $("#MultipleInsurancesTxt").val('All');
                            _NewInsuranceIds = ""; _NewInsuranceName = "";
                        }
                        else {

                            $("#MultipleInsurancesTxt").val(InsuranceName);
                        }
                    }
                    else {

                        $("#MultipleInsurancesTxt").val(InsuranceName);
                    }

                    if (InsuranceIds == "") {
                        $("#MultipleInsurancesTxt").val('All');
                    }
                    //FilterClaims(0, true);
                    //Commented by Asad Mehmood 11/09/2020
                    //$('.MultiCheckBox').attr('checked', false);
                    $("#Div_MultiInsurances").hide();

                }
                function checkAllCheckBoxISCheked(elem) {


                    if ($(elem).is(":checked")) {



                        if (_NewInsuranceIds != "") {
                            var LastChar = _NewInsuranceIds[_NewInsuranceIds.length - 1];
                            if (LastChar != ",") {
                                _NewInsuranceIds = _NewInsuranceIds + ',';
                            }
                        }


                        _NewInsuranceName += $(elem).parent().find(".checkBoxName").html() + ",";
                        _NewInsuranceIds += $(elem).parent().find(".InsuranceId").val() + ",";
                    }
                    else if ($(elem).is("checked") == false) {

                        if (_NewInsuranceIds != "") {
                            var LastChar = _NewInsuranceIds[_NewInsuranceIds.length - 1];
                            if (LastChar != ",") {
                                _NewInsuranceIds = _NewInsuranceIds + ',';
                            }
                        }
                        var NewInsuranceIds = _NewInsuranceIds.substring(0, _NewInsuranceIds.length - 1);
                        var array = [];
                        array = NewInsuranceIds.split(',');
                        var itemtoRemove = $(elem).parent().find(".InsuranceId").val();
                        for (var i = 0; i < array.length; i++) {

                            var arrayItem = array[i];
                            if (arrayItem == itemtoRemove) {

                                array.splice($.inArray(itemtoRemove, array), 1);
                                _NewInsuranceIds = array.join(",");

                                var inputString = _NewInsuranceIds;
                                var findme = ",";
                                var NewInsuranceIds = "";
                                if (inputString != "") {
                                    if (inputString.indexOf(findme) > -1) {

                                        _NewInsuranceIds = _NewInsuranceIds;
                                    } else {
                                        _NewInsuranceIds = _NewInsuranceIds + ',';
                                    }
                                }

                            }
                        }

                        var arrayInsNames = [];
                        if (_NewInsuranceName != "") {
                            var LastChar = _NewInsuranceName[_NewInsuranceName.length - 1];
                            if (LastChar != ",") {
                                _NewInsuranceName = _NewInsuranceName + ',';
                            }
                        }
                        var NewInsuranceName = _NewInsuranceName.substring(0, _NewInsuranceName.length - 1);
                        var array = [];
                        arrayInsNames = NewInsuranceName.split(',');
                        var itemtoRemove = $(elem).parent().find(".checkBoxName").html();
                        for (var i = 0; i < arrayInsNames.length; i++) {

                            var arrayItemName = arrayInsNames[i];
                            if (arrayItemName == itemtoRemove) {

                                arrayInsNames.splice($.inArray(itemtoRemove, arrayInsNames), 1);
                                _NewInsuranceName = arrayInsNames.join(",");
                                var inputString1 = _NewInsuranceName;
                                var findme = ",";
                                var NewInsuranceName = "";
                                if (inputString1 != "") {
                                    if (inputString1.indexOf(findme) > -1) {
                                        _NewInsuranceName = _NewInsuranceName;
                                    } else {
                                        _NewInsuranceName = _NewInsuranceName + ',';
                                    }
                                }
                                break;
                            }
                        }
                    }

                    if ($('.MultiCheckBox:checked').length == $('.MultiCheckBox').length) {
                        $('.AllCheckBox').attr('checked', true);
                        $("#MultipleInsurancesTxt").val("All");
                    }
                    else {
                        $('.AllCheckBox').attr('checked', false);
                    }
                }
                function ALLCheckBox() {

                    if ($(".AllCheckBox").is(":checked")) {
                        $('.MultiCheckBox').attr('checked', true);
                        $("#MultipleInsurancesTxt").val("All");
                        _NewInsuranceName = "";
                        $('.MultiCheckBox').each(function () {

                            if ($(this).is(":checked")) {

                                _NewInsuranceName += $(this).parent().find(".checkBoxName").html() + ",";
                                _NewInsuranceIds += $(this).parent().find(".InsuranceId").val() + ",";


                            }

                        });

                    }
                    else if ($(".AllCheckBox").is(":checked") == false) {

                        $('.MultiCheckBox').attr('checked', false);
                        _NewInsuranceName = "";
                        _NewInsuranceIds = "";
                    }
                }
                function CancelMultiCheckedInusrances() {

                    $("#Div_MultiInsurances").hide();
                    $('.MultiCheckBox').attr('checked', false);
                    $('.AllCheckBox').attr('checked', false);
                    _NewInsuranceIds = "";
                    InsuranceIds = "";
                    _NewInsuranceName = "";
                    //FilterClaims(0, true);

                    SearchMultipleImusrance("");
                    $('#MultipleInsurancesTxt').val('All');

                }

                $(document).mouseup(function (e) {
                    var CPTgrid = $("#divCPTSearched");

                    if (!CPTgrid.is(e.target) && CPTgrid.has(e.target).length === 0) {
                        CPTgrid.hide();
                    }
                });
            </script>
            <div class="DateRangeMessage" style="display: none">To Date cannot be less than From Date !</div>

            <div id="divDialogReportFilterBoxInner" style="">
                <div class="divDialogReportFilterBoxInnerHeader">
                    <div id="messageReportsAlert" style="background-color: none; border: none; margin-left: 17%; margin-top: 2%;">
                        <div class="divMesgAlert" style="float: right; margin-top: -48px !important; margin-right: 30%; display: none; z-index: 99999999 !important"></div>
                    </div>
                    <div class="divReportName" id="divPaymentByProcedure" runat="server" style="display: none;">
                        Payment By Procedure
                    </div>
                    <div class="divReportName" id="divPaymentsDetail" runat="server" style="display: none;">
                        Payments Detail
                    </div>
                    <div class="divReportName" id="divPaymentsSummary" runat="server" style="display: none;">
                        Payments Summary And Detail
                    </div>
                    <div class="divReportName" id="divUnpostedPaymentsDetailandSummary" runat="server" style="display: none;">
                        Unposted Payments Summary And Detail 
                    </div>
                    <div class="divReportName" id="divProcedurePaymentsSummary" runat="server" style="display: none;">
                        Procedure Payments Summary And Detail
                    </div>
                    <div class="divReportName" id="divContractManagementSummary" runat="server" style="display: none;">
                        Contract Management Summary
                    </div>
                    <div class="divReportName" id="divContractManagementDetail" runat="server" style="display: none;">
                        Contract Management Detail
                    </div>
                    <div class="divReportName" id="divMissedCopays" runat="server" style="display: none;">
                        Missed Copays
                    </div>
                    <div class="divReportName" id="divPaymentApplication" runat="server" style="display: none;">
                        Payment Application
                    </div>
                    <div class="divReportName" id="divPaymentApplicationSummary" runat="server" style="display: none;">
                        Payment Application Summary
                    </div>
                    <div class="divReportName" id="divUnappliedAnalysis" runat="server" style="display: none;">
                        Unapplied Analysis
                    </div>
                    <div class="divReportName" id="divPayerMixSummary" runat="server" style="display: none;">
                        Payer Analysis
                    </div>
                    <div class="divReportName" id="divARAgingSummary" runat="server" style="display: none;">
                        A/R Aging Summary
                    </div>
                    <div class="divReportName" id="divInsuranceCollectionDetail" runat="server" style="display: none;">
                        Insurance Collection Detail
                    </div>
                    <div class="divReportName" id="divInsuranceCollectionSummary" runat="server" style="display: none;">
                        Insurance Collection Summary
                    </div>
                    <div class="divReportName" id="divPatientCollectionSummary" runat="server" style="display: none;">
                        Patient Collection Summary
                    </div>
                    <div class="divReportName" id="divPatientCollectionDetail" runat="server" style="display: none;">
                        Patient Collection Detail
                    </div>
                    <div class="divReportName" id="divUnpaidInsuranceCliams" runat="server" style="display: none;">
                        Unpaid Insurance Claims
                    </div>
                    <div class="divReportName" id="divDenialsDetail" runat="server" style="display: none;">
                        Denials Detail
                    </div>
                    <div class="divReportName" id="divDenialsSummary" runat="server" style="display: none;">
                        Denials Summary
                    </div>
                    <div class="divReportName" id="divERAEOBList" runat="server" style="display: none;">
                        ERA/EOB List
                    </div>
                    <div class="divReportName" id="divPatientTransactionsDetail" runat="server" style="display: none;">
                        Patient Transactions Detail
                    </div>
                    <div class="divReportName" id="divEncounterDetail" runat="server" style="display: none;">
                        Encounter Detail
                    </div>
                    <div class="divReportName" id="divEncounterSummary" runat="server" style="display: none;">
                        Encounter Summary
                    </div>
                    <div class="divReportName" id="divAppointmentDetail" runat="server" style="display: none;">
                        Appointments Detail
                    </div>
                    <div class="divReportName" id="divPostClaim" runat="server" style="display: none;">
                        Post Claims <%--<input type="checkbox" style="width: 0.1%;"/>--%>
                    </div>
                    <div class="divReportName" id="divMonthlyReconciliation" runat="server" style="display: none;">
                        Monthly Reconciliation
                    </div>
                    <%-- Start Rizwan kharal 26April2018 --%>
                    <div class="divReportName" id="divRejectedDenaidClaims" runat="server" style="display: none;">
                        Rejected Denied Summary And Detail
                    </div>
                    <%-- End Rizwan kharal 26April2018 --%>

                    <%-- Start Rizwan kharal 27April2018 --%>
                    <div class="divReportName" id="divThirtyPlusDaysAfterSubmission" runat="server" style="display: none;">
                        Thirty Plus Days Aging

                    </div>
                    <%-- End Rizwan kharal 27April2018 --%>

                    <%-- Start Rizwan kharal 8May2018 --%>
                    <div class="divReportName" id="divPatientPayments" runat="server" style="display: none;">
                        Patient Payments

                    </div>
                    <%-- End Rizwan kharal 8May2018 --%>

                    <%-- Start Rizwan kharal 28June2018 --%>
                    <div class="divReportName" id="divClaimsCreatedByUser" runat="server" style="display: none;">
                        User Audit Report

                    </div>
                    <%-- End Rizwan kharal 28June2018 --%>

                    <%-- Start Rizwan kharal 28June2018 --%>
                    <div class="divReportName" id="divUserClaimSummary" runat="server" style="display: none;">
                        User Claim Summary

                    </div>
                    <%-- End Rizwan kharal 28June2018 --%>

                    <%-- Start Rizwan kharal 7August2018 --%>
                    <div class="divReportName" id="divClaimDetails" runat="server" style="display: none;">
                        Claims Summary & Detail

                    </div>
                    <%-- End Rizwan kharal 7August2018 --%>
                    <!-- Added by Daniyal_Baig 10Dec2018 -->
                    <div class="divReportName" id="divDeductableReport" runat="server" style="display: none;">
                        Deductable Report
                    </div>
                    <!-- End by Daniyal_Baig -->

                    <!-- Added by Rizwan kharal 7March2019 -->
                    <div class="divReportName" id="divProcedurePaymentsReportName" runat="server" style="display: none;">
                        Procedure Payments
                    </div>
                    <!-- End by Rizwan Kharal -->

                </div>

                <%--Added by Daniyal_Baig 12March2019--%>
                <div id="divProcedurePayment_rb" runat="server" style="display: none; padding-bottom: 35px;">
                    <span class="spnBranchName" style="">Report type:</span>
                    <div class="BranceInput" id="div3" runat="server">
                        <input type="radio" name="radioGroup" class="rbCPTProcedure" value="Summary" />Summary 
                               <input type="radio" name="radioGroup" class="rbCPTProcedure" value="Detail" />
                        Detail                                                            
                    </div>
                </div>
                <div id="divCPTReport" runat="server" style="display: none; padding-bottom: 45px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">CPT:</span>
                        <div class="clsDiagnosis BranceInput" id="divProcedurePayemnts" style="">
                            <table>
                                <tr>
                                    <td></td>
                                    <td style="width: 140px" class="leftTd">
                                        <input type="text" id="MultipleStatusTxt" class="required" runat="server" onkeyup="searchProcedureCode('C', this.value, '', this, event);" onchange="PopulateCPTDesc(this, 'txtCPTDescription');" style="width: 86%;" />
                                    </td>
                                    <td class="leftTd">
                                        <input type="text" id="MultipleStatusDesc" runat="server" class="upperCase" onkeyup="searchProcedureCode('D', this.value, '', this, event);" onchange="PopulateCPTCode(this, 'txtCPTCode');" style="width: 85%; float: left;" />
                                        <span class="spnRemove" onclick="emptyCPTVal(this, 1);"></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

                <div id="divCPTSearchedReport" style="width: 72%; left: 20%; height: 305px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto; margin-top: 4% !important">
                    <div>
                        <div class="Grid" style="width: 99%; height: auto;">
                            <table>
                                <thead>
                                    <tr>
                                        <th style="width: 70px">
                                            <input type="checkbox" class="AllCheckBoxStatus" checked="checked" onclick="ALLCheckBoxStatus()" />
                                            Code
                                        </th>
                                        <th>Description</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody id="CPTSearchedListReport">
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <input type="button" value="ok" onclick="GetMultiCheckedStatusCPT()" style="margin-top: 5px; margin-bottom: 6px; float: left; margin-left: 32px;" />
                    <input type="button" value="Cancel" onclick="CancelMultiCheckedStatus()" style="margin-top: 5px; margin-bottom: 6px; float: left;" />
                </div>

                <div id="divCheckNumber" runat="server" style="display: none; padding-bottom: 45px;">

                    <div class="divBranchName">
                        <span class="spnBranchName" style="">Check Number:</span>
                        <div class="clsCheckNumber BranceInput" id="divddlCheckNumber" onchange="GetPayerDropDown('divddlPostDate');">
                            <asp:DropDownList ID="ddlCheckNumber" CssClass="ddlCheckNumber" runat="server" Style="">
                                <asp:ListItem Value="0">All</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
                <div id="divPostDate" runat="server" style="display: none; padding-bottom: 45px;">


                    <div class="divBranchName">
                        <span class="spnBranchName" style="">Post Date:</span>
                        <div class="clsPostDate BranceInput" id="divddlPostDate">
                            <asp:DropDownList ID="ddlPostDate" CssClass="ddlPostDate" runat="server" Style="">
                                <asp:ListItem Value="0">All</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>


                <div id="divAgingType" runat="server" style="display: none; padding-bottom: 45px;">

                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Aging Type:</span>
                        <div class="clsPostDate BranceInput" id="divddlAgingType">
                            <asp:DropDownList ID="ddlAgingType" CssClass="ddlAgingType" runat="server" Style="">
                                <asp:ListItem Value="DOS">Date Of Service</asp:ListItem>
                                <asp:ListItem Value="BillDate">Billed Date</asp:ListItem>
                                <asp:ListItem Value="EncounterDate">Encounter Post Date</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>


                <div id="divAgingBy" runat="server" style="display: none; padding-bottom: 45px;">

                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Aging By:</span>
                        <div class="clsPostDate BranceInput" id="DivddlAgingBy">
                            <select class="ddl" id="ddlAgingBy">
                                <option value="EncounterPostDate">Procedure Post Date </option>
                                <option value="FirstBillDate">First Bill Date</option>
                                <option value="LASTBillDate">Last Bill Date</option>
                                <option value="DOS">DOS</option>

                            </select>
                        </div>

                    </div>
                </div>

                <div id="divAgingDate" runat="server" style="display: none; padding-bottom: 45px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Aging Date:</span>
                        <div class="clsPostDate BranceInput">
                            <asp:TextBox ID="txtAgingDate" runat="server" CssClass="required" Style="" placeholder="Please Select Date"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <%--post date--%>
                <div id="divClaimPostDate" runat="server" style="display: none; padding-bottom: 45px;">
                    <div class="divBranchName">
                        <span class="spnBranchName" style="">Post Date:</span>
                        <div class="clsPostDate BranceInput">
                            <asp:TextBox ID="txtClaimPostDate" runat="server" CssClass="required" Style="width: 93.5%"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%--end post date--%>







                <div id="divPostType" runat="server" style="display: none; padding-bottom: 45px">

                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Date Type:</span>
                        <div class="clsPostDate BranceInput" id="divddlPostType">
                            <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="" onchange="EnableDisableDates()">
                                <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                <asp:ListItem Value="PaymentDate" Enabled="false">Payment Date</asp:ListItem>
                                <asp:ListItem Value="PostDate">Post Date</asp:ListItem>
                                <asp:ListItem Value="SubmissionDate" Enabled="false">Submission Date</asp:ListItem>
                                <asp:ListItem Value="BillDate" Enabled="false">Bill Date</asp:ListItem>
                                <asp:ListItem Value="CheckDate" Enabled="false">Check Date</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>

                <div id="divPayerType" runat="server" style="display: none; padding-bottom: 45px">

                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Payer Type:</span>
                        <div class="clsPostDate BranceInput" id="divddlPayerType">
                            <asp:DropDownList ID="ddlPayerType" CssClass="ddlPostType" runat="server" Style="" onchange="SelectPayerTypedll()">
                                <asp:ListItem Value="">Select Payer Type</asp:ListItem>
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                                <asp:ListItem Value="Patient">Patient</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>

                </div>

                <div id="divPayerType2" runat="server" style="display: none; padding-bottom: 45px">

                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Payer Type:</span>
                        <div class="clsPostDate BranceInput" id="divddlPayerType2">
                            <asp:DropDownList ID="ddlpayertype2" CssClass="ddlPostType" runat="server" Style="">
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="Insurance">Insurance</asp:ListItem>
                                <asp:ListItem Value="Patient">Patient</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>

                <%--jump--%>
                <div id="divCheckNumberSearch" runat="server" style="display: none; padding-bottom: 45px">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Check Number:</span>
                        <div class="clsPostDate BranceInput">
                            <input type="text" id="txtsearchcheck" placeholder="Search Check Number" onkeyup="SearchCheck(event,this)" />
                        </div>
                    </div>

                    <div class="divChecklist" style="display: none; width: 32%; position: absolute;  margin-top: 60px"></div>
                </div>

                <div id="divInsuranceType" runat="server" style="display: none; padding-bottom: 45px">

                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Insurance Type:</span>
                        <div class="clsPostDate BranceInput" id="divddlInsuranceType">
                            <asp:DropDownList ID="ddlInsuranceType" CssClass="" runat="server" Style="">
                                <asp:ListItem Value="">Select Insurance Type</asp:ListItem>
                                <asp:ListItem Value="Pri">Primary Insurance</asp:ListItem>
                                <asp:ListItem Value="Sec">Secondary Insurance</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
                <div id="divSubmissionStatus" runat="server" style="display: none; padding-bottom: 45px">

                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Status:</span>
                        <div class="clsPostDate BranceInput" id="">
                            <asp:DropDownList ID="ddlSubmissionStatus" CssClass="ddlPostType" runat="server" Style="">
                                <asp:ListItem Value="">Select Submission Status</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>

                <div id="divPracticeLocationId" runat="server" style="display: none; padding-bottom: 45px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Location:</span>
                        <div class="BranceInput">
                            <div class="reportdropdown" style="">
                                <a onclick="hideShowMenu('divPracticeLocation');">
                                    <div class="selectedText">
                                        All Locations
                                    </div>
                                    <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </a>
                                <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                    <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                        <ul id="ulMultiPracticeLocation" onchange="GetServiceProviderDropDown();">
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                    <input type="checkbox" id="chkPracticeLocationAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                    <span>All</span>
                                                    <input type="hidden" value="0" />
                                                </label>
                                            </li>
                                            <asp:Repeater runat="server" ID="rptLocation">
                                                <ItemTemplate>
                                                    <li style="float: left; width: 100%;">
                                                        <label name='<%#Eval("PracticeLocationsId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                            <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this); GetMonthlyReconciliationtMonthYearDropDown(this);" />
                                                            <span><%#Eval("Name") %></span>
                                                            <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' id="PatientId" />
                                                        </label>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>

                                </div>
                            </div>

                        </div>

                    </div>
                </div>

                <div id="divPlaceOfServiceReport" runat="server" style="display: none; padding-bottom: 45px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Place Of Service:</span>

                        <div class="BranceInput">
                            <div class="reportdropdown" style="">
                                <a onclick="hideShowMenu('divPlaceOfService');">
                                    <div class="selectedText">
                                        All Place Of Services
                                    </div>
                                    <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </a>
                                <div id="divPlaceOfService" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                    <div style="float: left; max-height: 170px; overflow-y: auto; overflow-x: hidden; width: 100%; margin-top: 1%; background: white; border: 1px solid #ccc; z-index: 100; position: relative">
                                        <ul id="ulMultiPlaceOfService">
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                    <input type="checkbox" id="chkPlaceOfServiceAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                    <span>All</span>
                                                    <input type="hidden" value="0" />
                                                </label>
                                            </li>
                                            <asp:Repeater runat="server" ID="rptPlaceOfService">
                                                <ItemTemplate>
                                                    <li style="float: left; width: 100%;">
                                                        <label name='<%#Eval("POSCode") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                            <input type="checkbox" class="chkPlaceOfService chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                            <span><%#Eval("PlaceOfService") %></span>
                                                            <input type="hidden" value='<%#Eval("POSCode") %>' id="PatientId" />
                                                        </label>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>


                <div id="divReportServiceProvider" runat="server" style="padding-bottom: 45px; display: none">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Provider :</span>
                        <div class="BranceInput">
                            <div class="reportdropdown" style="">
                                <a onclick="hideShowMenu('divServiceProvider');">
                                    <div class="selectedText">
                                        All Providers
                                    </div>
                                    <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" onclick="Provider_multifunction" />
                                    </div>
                                </a>
                                <div id="divServiceProvider" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                    <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                        <%-- Changed By Asad Mehmood 11/09/2020 --%>
                                        <ul id="ulMultiServiceProvider">
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                    <input type="checkbox" style="margin-top: 3px;" id="chkServiceProviderAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                    <span>All Providers</span>
                                                    <input type="hidden" value="0" />
                                                </label>
                                            </li>
                                            <asp:Repeater runat="server" ID="rptProviders">
                                                <ItemTemplate>

                                                    <li style="float: left; width: 100%; padding-left: 10px; box-sizing: border-box;" class="rpt_li">
                                                        <label name='<%#Eval("PracticeStaffId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left; width: 100%;" class="li_label">
                                                            <div style="display: flex; align-items: start; width: 100%;">
                                                                <input type="checkbox" class="chkProviders chk-multi-checkboxes" style="margin-top: 0px;" checked="checked" onclick="ReportAlert(this)" />
                                                                <div style="display: flex; align-items: baseline; width: 85%;"><span style="word-break: break-word;" class="checkBoxName"><%#Eval("Providers") %></span></div>
                                                            </div>

                                                            <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="ProviderId" />

                                                            <input type="hidden" value='<%#Eval("PracticeStaffId") %>' class="hdnProviderIds" />
                                                        </label>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div id="divPracticeStaffOnNpiNum" runat="server" style="padding-bottom: 45px; display: none">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Providers :</span>
                        <div class="clsPatientId BranceInput">
                            <asp:DropDownList ID="ddlPracticeStaffOnNpiNum" CssClass="ddlPatientList" runat="server" Style="">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div id="divPatientDetailDialog" runat="server" style="padding-bottom: 45px; display: none">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Patient:</span>
                        <div class="clsPatientId BranceInput">
                            <asp:DropDownList ID="ddlPatientList" CssClass="ddlPatientList" runat="server" Style="">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>


                <%-- Start Added By Rizwan kharal 26April2018 --%>
                <div id="divProviderddl" runat="server" style="padding-bottom: 45px; display: none">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Providers:</span>
                        <div class="clsPatientId BranceInput">
                            <asp:DropDownList ID="ddlProviders" CssClass="ddlProviderList" runat="server" Style="">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <%--END --%>
                <div id="divReportProcedure" runat="server" style="display: none; padding-bottom: 45px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">CPT:</span>
                        <div class="clsDiagnosis BranceInput" id="divProcedure" style="">
                            <table>
                                <tr>
                                    <td style="width: 140px" class="leftTd">
                                        <input type="text" id="txtCPTCode" class="required" runat="server" onkeyup="searchCPTs('C', this.value, '', this, event);" onchange="PopulateCPTDesc(this, 'txtCPTDescription');" style="width: 86%;" />
                                    </td>
                                    <td class="leftTd">
                                        <input type="text" id="txtCPTDescription" runat="server" class="upperCase" onkeyup="searchCPTs('D', this.value, '', this, event);" onchange="PopulateCPTCode(this, 'txtCPTCode');" style="width: 85%; float: left;" />
                                        <span class="spnRemove" onclick="emptyCPTVal(this, 1);"></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <%--start changes added by ali  imran 22 may 2019--%>

                <div id="divPayerDropDownSearch" runat="server" style="padding-bottom: 15px; display: none;">
                    <div class="divBranchName" style="margin-top: 10px">
                        <span class="spnBranchName" style="">Insurance:</span>
                        <input type="text" id="MultipleInsurancesTxt" readonly="readonly" value="All" style="cursor: pointer; padding: 5px; box-sizing: border-box; width: 80%; height: 27px; margin-right: 0;" />
                        <div class="dropDownIcon insurance-select">
                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                        </div>
                        <div class="BranceInput">
                            <div class="reportdropdownNew" style="">
                                <div style="display: none" id="Div_MultiInsurances">
                                    <div id="FilterulMultiInsurances">
                                        <ul id="ulMultiInsurances">

                                            <li style="border-bottom: 1px solid #d5cfcf; margin-bottom: 3px">
                                                <input type="text" id="searchMultiInsurances" placeholder="Search Insurance" onkeyup="SearchInsuranceOnEnter(event)" />

                                            </li>

                                            <li style="border-bottom: 1px solid #d5cfcf">
                                                <label>
                                                    <input type="checkbox" class="AllCheckBox" onclick="ALLCheckBox()" style="margin-left: 3px;" />
                                                    <span style="padding-left: 4px;">ALL</span>
                                                </label>
                                            </li>
                                            <asp:Repeater runat="server" ID="rptInsurances">
                                                <ItemTemplate>

                                                    <li style="float: left; width: 100%; border-bottom: 1px solid #d5cfcf;" runat="server" id="InsList">
                                                        <label name='<%#Eval("name") %>' style="float: left; width: 100%">
                                                            <span style="float: left;">
                                                                <input type="checkbox" class="MultiCheckBox" onclick="checkAllCheckBoxISCheked(this)" /></span>
                                                            <span class="checkBoxName"><%#Eval("name") %></span>
                                                            <input type="hidden" value='<%#Eval("insuranceId") %>' class="InsuranceId" />


                                                        </label>
                                                    </li>

                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </ul>
                                    </div>
                                    <div style="float: right;">
                                        <input type="button" value="ok" onclick="GetMultiCheckedInusrances()" style="margin-top: 5px; margin-bottom: 6px; float: left; margin-left: 45px; padding:3px 6px;" />
                                        <input type="button" value="Cancel" onclick="CancelMultiCheckedInusrances()" style="margin-top: 5px; margin-bottom: 6px; float: left; padding:3px 6px;" />
                                    </div>

                                </div>

                            </div>
                        </div>

                    </div>
                </div>

                <%--end   changes added by ali  imran 22 may 2019--%>

                <%-- Jump --%>
                <div id="divReportPayerScenario" runat="server" style="padding-bottom: 45px; display: none;">
                    <div class="divBranchName">
                        <span class="spnBranchName" style="">Insurance:</span>
                        <div class="BranceInput">
                            <div class="reportdropdownNew" style="">

                                <div>

                                    <input type="text" id="SearchPayertxt" class="selectedText SearchTextBoxForRpt" readonly="true" />
                                    <input type="hidden" id="hdnSearchPayertxt" class="hdnselectedText SearchTextBoxForRpt" />
                                    <div class="dropDownIconNewSearch" onclick="SearchReportddlRecord('divPayerScenario',this);">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </div>




                                <div id="divPayerScenario" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div id="divReportUnpaidinsurances" runat="server" style="padding-bottom: 45px; display: none;">
                    <div class="divBranchName">
                        <span class="spnBranchName" style="">Unpaid Insurances :</span>
                        <div class="BranceInput">
                            <div class="reportdropdown" style="">
                                <a onclick="hideShowMenu('divUnpaidinsurances');">
                                    <div class="selectedText">
                                        All Unpaid Insurances
                                    </div>
                                    <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </a>
                                <div id="divUnpaidinsurances" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                    <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                        <ul id="ulMultiUnpaidinsurances">
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                    <input type="checkbox" id="chkUnpaidinsurancesAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                    <span>All Unpaid Insurances</span>
                                                    <input type="hidden" value="0" />
                                                </label>
                                            </li>
                                            <asp:Repeater runat="server" ID="rptunpaidinsurances">
                                                <ItemTemplate>
                                                    <li style="float: left; width: 100%;">
                                                        <label name='<%#Eval("InsuranceId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                            <input type="checkbox" class="chkunpaidinsurance chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                            <span><%#Eval("insurance") %></span>
                                                            <input type="hidden" value='<%#Eval("InsuranceId") %>' id="" />
                                                        </label>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <%-- Jump --%>
                <div id="divReportDenailPayerName" runat="server" style="display: none; padding-bottom: 45px">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Insurance :</span>
                        <div class="BranceInput">
                            <div class="reportdropdownNew" style="">

                                <div>

                                    <input type="text" id="SearchInsurancetxt" class="selectedText SearchTextBoxForRpt" placeholder="Search Record" onkeyup="SetSearch(event,'divDenailPayerName',this)" />

                                    <div class="dropDownIconNewSearch" onclick="SearchReportddlRecord('divDenailPayerName',this);">
                                        <img src="../../Images/SmallSearch.gif" style="width: 40%;" />
                                    </div>
                                </div>

                                <div id="divDenailPayerName" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>



                <div id="divReportPayerScenario1" runat="server" style="padding-bottom: 45px; display: none;">
                    <div class="divBranchName">
                        <span class="spnBranchName" style="">Payer:</span>
                        <div class="BranceInput">
                            <div class="reportdropdownNew" style="">

                                <div onclick="SearchReportddlRecord('divPayerScenario1',this);">

                                    <input type="text" id="SearchPayertxt1" value="ALL" class="selectedText SearchTextBoxForRpt" readonly="true" style="width: 100%;" />
                                    <input type="hidden" value="" id="hdnSearchPayertxt1" class="hdnselectedText SearchTextBoxForRpt" />
                                    <input type="hidden" value="" id="hdhTotalPayers" class="" />
                                    <div class="dropDownIconNewSearch" onclick="SearchReportddlRecord('divPayerScenario1',this);" style="width: 10.5%; position: absolute; left: 93%; top: 6px; }">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </div>




                                <div id="divPayerScenario1" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div id="divReportClaimStatus" runat="server" style="display: none; padding-bottom: 45px;" class="none-d">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName claim-status-label">Claim Status :</span>
                        <div class="BranceInput claim-status-input">
                            <div class="reportdropdown" style="">
                                <a onclick="hideShowMenu('divCalimStatus');">
                                    <div class="selectedText">
                                        All Claims
                                    </div>
                                    <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </a>
                                <div id="divCalimStatus" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                    <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                        <ul id="ulMultiCalimStatus">
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                    <input type="checkbox" id="chkCalimStatusAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                    <span>All Claims</span>
                                                    <input type="hidden" value="0" />
                                                </label>
                                            </li>
                                            <asp:Repeater runat="server" ID="rptCalimStatus">
                                                <ItemTemplate>
                                                    <li style="float: left; width: 100%;">
                                                        <label name='<%#Eval("SubmissionStatusId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                            <input type="checkbox" class="chkCalimStatus chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                            <span><%#Eval("SubmissionStatus") %></span>
                                                            <input type="hidden" value='<%#Eval("SubmissionStatusId") %>' id="PatientId" />
                                                        </label>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>


                <div id="divReportReportType" runat="server" style="display: none; padding-bottom: 45px">

                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="float: left; margin-left: 0%;">Report Type :</span>
                        <div class="clsPostDate BranceInput" id="divddlReportType">
                            <asp:DropDownList ID="ddlReportType" CssClass="ddlReportType" runat="server" onchange="ChangeReportType()">
                                <asp:ListItem Value="PROLevel">CPT Wise</asp:ListItem>
                                <asp:ListItem Value="CLMLevel">Claim Wise</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>

                </div>

                <div id="divReportBilledAs" runat="server" style="display: none; padding-bottom: 45px;">
                    <div class="divBranchName" style="">
                        <span class="spnBranchName" style="">Insurance Type:</span>
                        <div class="BranceInput">
                            <div class="reportdropdown" style="">
                                <div onclick="ddlHideShow('divBilledAs1',this);">
                                    <div class="selectedText">
                                        All
                                    </div>
                                    <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                        <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                    </div>
                                </div>

                                <div id="divBilledAs1" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 10px; left: 0; width: 99%;">
                                    <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                        <ul id="ulMultiBilledAs">
                                            <li style="float: left; width: 100%;">
                                                <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                    <input type="checkbox" id="chkBilledAsAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                    <span>All</span>
                                                    <input type="hidden" value="0" />
                                                </label>
                                            </li>

                                            <li style="float: left; width: 100%;">
                                                <label name='Primary' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                    <input type="checkbox" class="chkCalimStatus chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                    <span>Primary</span>
                                                    <input type="hidden" value='Pri' class="PatientId" />
                                                </label>
                                            </li>

                                            <li style="float: left; width: 100%;">
                                                <label name='Secondary' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                    <input type="checkbox" class="chkCalimStatus chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                    <span>Secondary</span>
                                                    <input type="hidden" value='Sec' class="PatientId" />
                                                </label>
                                            </li>
                                            <%-- <li style="float: left; width: 100%;">
                                                    <label name='Other' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkCalimStatus chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" />
                                                        <span>Other</span>
                                                        <input type="hidden" value='Oth' class="PatientId"/>
                                                    </label>
                                                </li>--%>
                                        </ul>
                                    </div>

                                </div>
                            </div>

                        </div>

                    </div>
                </div>

            </div>

            <div id="divAging" runat="server" style="display: none; padding-bottom: 45px;">

                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Aging:</span>
                    <div class="clsPostDate BranceInput" id="divAgingIn" style="padding-bottom: 10px;">
                        <asp:DropDownList ID="ddlAging" CssClass="ddlAgingType" runat="server">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="0-30">0-30</asp:ListItem>
                            <asp:ListItem Value="31-60">31-60</asp:ListItem>
                            <asp:ListItem Value="61-90">61-90</asp:ListItem>
                            <asp:ListItem Value="90+">90+</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

            </div>

            <div id="divCPT" runat="server" style="display: none; padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">CPT:</span>
                    <div class="clsDiagnosis BranceInput" style="">

                        <input type="text" id="txtServiceCode" placeholder="Search CPT" class="required" runat="server" onkeyup="loadServiceCode(event, this)" style="width: 100%;" />
                        <div class="divselectedServiceCode" style="margin-top: 10px" />
                    </div>

                </div>

                <div id="divCPTSearched" style="width: 72%; /*left: 21%;*/ max-height: 250px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto; margin-top: 8%; margin-bottom: 10px;">
                    <div class="Grid" style="width: 99%; height: auto;">
                        <table>
                            <thead>
                                <tr>
                                    <th>Code</th>
                                    <th>Description</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="CPTSearchedList">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <%-- strat Added By Rizwan kharal FileSearch 17July2018 --%>
            <div id="divFileSearch" runat="server" style="display: none; padding-bottom: 45px;" class="none-d">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Files :</span>
                    <div class="BranceInput">
                        <div class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divFileStatus');">
                                <div class="selectedText">
                                    All Files
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                </div>
                            </a>
                            <div id="divFileStatus" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                    <ul id="ulMultiFileStatus">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                <input type="checkbox" id="chkFileStatusAll" class="chk-multi-checkboxes-all" />
                                                <span>All Files</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="RptFile">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("UploadFilesId") %>' onclick="Report_ClickMultiCheckBox(this);" style="width: 100%;">
                                                        <span style="float: left;">
                                                            <input type="checkbox" class="MultichkFileStatus chk-multi-checkboxes" onclick="ReportAlert(this)" />
                                                        </span>
                                                        <span style="float: left; width: 93%;" class="Filename"><%#Eval("FileName") %></span>
                                                        <input type="hidden" value='<%#Eval("UploadFilesId") %>' id="FileId" />
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>

                            </div>
                        </div>



                        <div class="clsPatientId " id="FileSearch" style="">
                            <asp:TextBox runat="server" ID="txtFileSearch" placeholder="Serach Files..." CssClass="required" Style="height: 30px" onkeyup="filesearchfunction(event)"></asp:TextBox>
                            <input type="hidden" runat="server" id="hdnFileSearchId" />

                        </div>
                    </div>

                </div>
                <div id="FileSearchdiv" style="display: none" class="Grid">
                </div>
            </div>
            <%-- END Added By Rizwan kharal FileSearch 17July2018 --%>
            <div id="divReportPatientName" runat="server" style="display: none; padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Patient:</span>
                    <div class="BranceInput">
                        <div class="reportdropdownNew" style="">
                            <div>

                                <input type="text" id="SearchPatienttxt" class="selectedText SearchTextBoxForRpt" placeholder="Search Record" onkeyup="SetSearch(event,'divPatientName',this)" />

                                <div class="dropDownIconNewSearch" onclick="SearchReportddlRecord('divPatientName',this);">
                                    <img src="../../Images/SmallSearch.gif" style="width: 40%;" />
                                </div>
                            </div>
                            <div id="divPatientName" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div id="divInsuranceDetailDialog" runat="server" style="display: none; padding-bottom: 45px;">
                <%--                 <br />
                     <br />
                 <hr  id="hrPatientDetail" runat="server"/>--%>
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Insurances :</span>
                    <div class="clsPatientId BranceInput">
                        <asp:DropDownList ID="ddlInsuranceList" CssClass="ddlInsuranceList" runat="server" Style="">
                            <asp:ListItem Value="">All</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="divBalance" runat="server" style="display: none; padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Balance:</span>
                    <div class="clsBalance BranceInput">
                        <asp:DropDownList ID="ddlBalance" CssClass="ddlBalance" runat="server" Style="">
                            <asp:ListItem Value="">All</asp:ListItem>
                            <asp:ListItem Value="10">$10</asp:ListItem>
                            <asp:ListItem Value="15">$15</asp:ListItem>
                            <asp:ListItem Value="20">$20</asp:ListItem>
                            <asp:ListItem Value="50">$50</asp:ListItem>
                            <asp:ListItem Value="100">$100</asp:ListItem>
                            <asp:ListItem Value="500">$500</asp:ListItem>
                            <asp:ListItem Value="100">$1000</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="divDateOfService" runat="server" style="display: none; padding-bottom: 45px">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Date Of Service Age:</span>
                    <div class="clsDateOfService BranceInput">
                        <asp:DropDownList ID="ddlDateOfService" CssClass="ddlDateOfService" runat="server" Style="">
                            <asp:ListItem Value="">All</asp:ListItem>
                            <asp:ListItem Value="0-15">0-15 Days</asp:ListItem>
                            <asp:ListItem Value="16-30">16-30 Days</asp:ListItem>
                            <asp:ListItem Value="31-45">31-45 Days</asp:ListItem>
                            <asp:ListItem Value="46-60">46-60 Days</asp:ListItem>
                            <asp:ListItem Value="100">100 Days</asp:ListItem>
                            <asp:ListItem Value="61-90">61-90 Days</asp:ListItem>
                            <asp:ListItem Value="91+">91+ Days</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="divPayersName" runat="server" style="display: none; padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Insurance:</span>
                    <div class="clsPayerName BranceInput" onchange="GetPayerDropDown('divddlCheckNumber');">
                        <asp:DropDownList ID="ddlPayerName" CssClass="ddlPayerName" runat="server" Style="">
                        </asp:DropDownList>
                    </div>
                </div>

            </div>
            <div id="divBillDates" runat="server" style="display: none; padding-bottom: 45px">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="" id="Dateslbl">Bill Dates:<span style="color: red; display: none">*</span></span>
                    <div class="BranceInput">
                        <div style="width: 100%">
                            <div id="From" style="width: 48%; float: left">
                                <%--<span style="width: 20%; float: left">From:</span>--%>
                                <span>
                                    <asp:TextBox runat="server" ID="txtBillDateFrom" CssClass="required" placeholder="From:" Enabled="false" autocomplete="off"></asp:TextBox></span>
                            </div>
                            <div id="to" style="width: 48%; float: right">
                                <%--<span style="width: 20%; float: left">To:</span>--%>
                                <span>
                                    <asp:TextBox runat="server" ID="txtBillDateTo" CssClass="required" placeholder="To:" Enabled="false" autocomplete="off"></asp:TextBox></span>
                            </div>
                        </div>


                    </div>
                </div>
            </div>





            <div id="divClaimId" runat="server" style="display: none; padding-bottom: 45px">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Claim Id :</span>
                    <div class="BranceInput">
                        <%--   <asp:TextBox ID="ClaimIdTxt" runat="server" placeholder="Enter Claim Id" onke></asp:TextBox>--%>
                        <input type="text" id="ClaimIdTxt" placeholder="Enter Claim Id" onkeypress="return ValidateNumber(event)" maxlength="10" />
                    </div>

                </div>
            </div>




            <div id="divReportAdjustmentCode" runat="server" style="display: none; padding-bottom: 45px">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="float: left; margin-left: 0%;">Adjustment Code:</span>
                    <div class="BranceInput">
                        <div class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divAdjustmentCode');">
                                <div class="selectedText">
                                    All 
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                </div>
                            </a>
                            <div id="divAdjustmentCode" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                <div class="ddlselect maindivofddl" style="margin-top: 7px !important">
                                    <ul id="ulMultiAdjustmentCode">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                <input type="checkbox" id="chkAdjustmentCodeAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptAdjustmentCode">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("AdjustmentCode") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                        <input type="checkbox" class="chkAdjustmentCode chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" style="" />
                                                        <span><%#Eval("CodeDescription") %></span>
                                                        <input type="hidden" value='<%#Eval("AdjustmentCode") %>' id="PatientId" />
                                                    </label>


                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div id="divReportPaymentType" runat="server" style="display: none; padding-bottom: 45px">

                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Payment Type:</span>
                    <div class="clsPostDate BranceInput" id="divddlPaymentType">
                        <asp:DropDownList ID="ddlPaymentType" CssClass="ddlPaymentType" runat="server" Style="">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="ERA">ERA</asp:ListItem>
                            <asp:ListItem Value="EOB">EOB</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

            </div>
            <div id="divPaymentMethod" runat="server" style="display: none; padding-bottom: 45px">

                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Payment Method:</span>
                    <div class="clsPostDate BranceInput" id="divddlPaymentMethod">
                        <asp:DropDownList ID="dllPaymentMethod" CssClass="ddlPaymentMethod" runat="server" Style="">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="ACH">Automated Clearing House</asp:ListItem>
                            <asp:ListItem Value="BOP">Financial Institution Option</asp:ListItem>
                            <asp:ListItem Value="CHK">Check</asp:ListItem>
                            <asp:ListItem Value="FWT">Federal Reserve Funds</asp:ListItem>
                            <asp:ListItem Value="NON">Non-Payment Data</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

            </div>

            <div id="divAppointmentStatus" runat="server" style="padding-bottom: 45px; display: none">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="float: left; margin-left: 0%;">Status:</span>
                    <div class="clsPatientId BranceInput">
                        <asp:DropDownList ID="ddlAppointmentStatus" CssClass="ddlAppointmentStatus" runat="server" Style="">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div id="divAppointmentReasons" runat="server" style="padding-bottom: 45px; display: none">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="float: left; margin-left: 0%;">Reasons:</span>
                    <div class="clsPatientId BranceInput">
                        <asp:DropDownList ID="ddlAppointmentReasons" CssClass="ddlAppointmentReasons" runat="server" Style="">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div id="divMonthlyReconciliationLocation" runat="server" style="display: none; padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Location :</span>
                    <div class="clsPatientId BranceInput" id="divddlMonthlyReconciliationLocation" onchange="GetMonthlyReconciliationtMonthYearDropDown('divddlMonthlyReconciliationYear');ProviderOnLocation();">
                        <asp:DropDownList ID="ddlMonthlyReconciliationLocation" CssClass="ddlMonthlyReconciliationLocation" runat="server" Style="">
                            <asp:ListItem Value="">Please Select Location</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>


            <%-- Start Added By Rizwan kharal 30April2018 --%>

            <div id="divProviderType" runat="server" style="padding-bottom: 45px; display: none">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="float: left; margin-left: 0%;">Provider Type</span>
                    <div class="clsPatientId BranceInput" id="">
                        <asp:DropDownList ID="ddlProviderType" CssClass="ddlProviderList" runat="server" Style="" onchange="ProviderOnLocation();">
                            <%-- <asp:ListItem Value="">All</asp:ListItem>--%>
                            <asp:ListItem Value="Attending">Attending Physician</asp:ListItem>
                            <asp:ListItem Value="OthProvider">Other Service Provider</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
            </div>


            <div id="divMRRProvider" runat="server" style="padding-bottom: 45px; display: none">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="float: left; margin-left: 0%;">Providers:</span>
                    <div class="clsPatientId BranceInput" id="MonthlyReconciliationProvider">
                        <asp:DropDownList ID="ddlMonthlyReconciliationProvider" CssClass="ddlProviderList" runat="server" Style="" onchange="LoadYearonProvider();">
                        </asp:DropDownList>

                    </div>
                </div>
            </div>

            <%--END --%>



            <div id="divMonthlyReconciliationtYear" runat="server" style="display: none; padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Year :</span>
                    <div class="clsPatientId BranceInput" id="divddlMonthlyReconciliationYear" onchange="GetMonthlyReconciliationtMonthYearDropDown('divddlMonthlyReconciliationMonth');">
                        <asp:DropDownList ID="ddlMonthlyReconciliationYear" CssClass="ddlMonthlyReconciliationYear" runat="server" Style="">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="divMonthlyReconciliationtMonth" runat="server" style="display: none; padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">Month :</span>
                    <div class="clsPatientId BranceInput" id="divddlMonthlyReconciliationMonth">
                        <asp:DropDownList ID="ddlMonthlyReconciliationMonth" CssClass="ddlMonthlyReconciliationMonth" runat="server" Style="">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>



            <%-- <hr id="hrEndPatientDetail" runat="server"/>--%>

            <div id="divUserSearch" runat="server" style="display: none; padding-bottom: 45px;">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="">User Name:</span>
                    <div class="clsPatientId BranceInput" id="SearchUser">
                        <input type="text" id="MultipleUserNameTxt" readonly="readonly" value="All" style="cursor: pointer; padding: 5px; box-sizing: border-box; width: 97%; height: 27px;" onclick="UserNameDDLClick();" />
                        <span style="position: absolute; margin-left: -16px; margin-top: 7px; width: 5px;" onclick="UserNameDDLClick();"><i class="fas fa-caret-down" style="font-size: 13px; cursor: pointer" id="Statuscaret-down"></i></span>

                        <%-- Added By Rizwan kharal 9july2018 --%>
                        <%-- MultiUserName --%>

                        <div style="display: none" id="Div_MultiUserName" runat="server">
                            <div>
                                <ul id="ulMultiUserName">
                                    <li style="border-bottom: 1px solid #d5cfcf"><span style="margin-left: 1px; width: 8%;">
                                        <input type="checkbox" style="width: 8%" class="AllCheckBoxUserName" onclick="ALLCheckBoxUserName()" /></span>
                                        <span style="margin-left: 34px;">ALL</span>

                                    </li>
                                    <asp:Repeater runat="server" ID="rptMultiUserName">
                                        <ItemTemplate>

                                            <li style="float: left; width: 100%; border-bottom: 1px solid #d5cfcf" runat="server" id="liUserName">
                                                <label name='<%#Eval("userName") %>' style="float: left; width: 100%">
                                                    <input type="checkbox" class="MultiCheckBoxUserName" style="float: left; width: 8%" onclick="checkAllCheckBoxUserNameISCheked(this)" />
                                                    <span class="UserNamecheckBoxName" style="float: right; width: 83%"><%#Eval("userName") %></span>
                                                    <input type="hidden" value='<%#Eval("UserId") %>' class="UserNameId" />


                                                </label>
                                            </li>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <div style="float: right; margin-right: 5px">
                                <input type="button" value="ok" onclick="GetMultiCheckedUserName()" style="margin-top: 5px; margin-bottom: 6px; float: left; margin-right: 5px; min-width: 75px !important; background: #2c8aca; border-bottom: #2c8aca; color: white;" />
                                <input type="button" value="Cancel" onclick="CancelMultiCheckedUserName()" style="margin-top: 5px; margin-bottom: 6px; float: left; margin-right: 5px; min-width: 75px !important; background: #2c8aca; border-bottom: #2c8aca; color: white;" />
                            </div>
                        </div>


                        <input type="hidden" runat="server" id="hdnuserid" />
                    </div>
                </div>
            </div>







            <div id="divAsof" runat="server" style="padding-bottom: 45px; display: none">
                <div class="divBranchName" style="">
                    <span class="spnBranchName" style="float: left; margin-left: 0%;">As of:</span>
                    <div class="clsPatientId BranceInput">
                        <input type="text" id="txtdateasof" />
                    </div>
                </div>
            </div>


            <div class="divTimeSpan" id="divTimeSpan" runat="server" style="display: none;">

                <fieldset class="divTable" id="divReportTimeSpan">
                    <legend><span class="spnTimeSpan" id="AgencyReportFilterBox_tdlblTimeSpam">Time Span:</span></legend>

                    <div class="row" id="divRowRdo" runat="server">
                        <div class="col40" id="divCellBeginning" style="width: 40%" runat="server">
                            <ul style="margin-top: 8px;">
                                <li class="radio_li">
                                    <asp:RadioButton runat="server" ID="rbReportToday" Text="Today" Checked="true" CssClass="Today" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                <li class="radio_li">
                                    <asp:RadioButton runat="server" ID="rbReportTimeSpanLastMonth" Text="Last Month" CssClass="LastMonth" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                <li class="radio_li">
                                    <asp:RadioButton runat="server" ID="rbReportTimeSpanMonthToDate" Text="Month to Date" CssClass="MonthToDate" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                <li class="radio_li">
                                    <asp:RadioButton runat="server" ID="rbReportTimeSpanYearToDate" Text="Year to Date" CssClass="YearToDate" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                <%-- 
                                       <li class="radio_li" style="display:none"> <asp:RadioButton runat="server" ID="rbReportTimeSpanFromTheBeginning" Text="From the Beginning" CssClass="Beginning" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                --%>
                            </ul>
                        </div>
                        <div class="col60">
                            <asp:RadioButton runat="server" ID="rbReportTimeSpanSpecificDates" Text="Select Date" CssClass="SpecificDates" GroupName="rbReportTimeSpan" onclick="EnableDates(true);" Style="font-weight: bold;" />
                            <br />
                            <div class="">
                                <table id="timeDurationAgencyReportFilterBox" style="width: 325px; table-layout: auto; margin-top: -2%;">
                                    <tr>
                                        <td style="width: 45px; text-align: right;">
                                            <span>From:</span>
                                        </td>
                                        <td style="width: 120px;">
                                            <asp:TextBox runat="server" ID="txtReportDateFrom" CssClass="required" Enabled="false" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td style="width: 40px; text-align: right;" id="spnTo" runat="server">
                                            <span>To:</span>
                                        </td>
                                        <td style="width: 120px;" id="tdDateTo" runat="server">
                                            <asp:TextBox runat="server" ID="txtReportDateTo" CssClass="required" Enabled="false" autocomplete="off"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                </fieldset>
            </div>
            <%--Added by Daniyal_Baig 13Dev2018--%>
            <div class="divPatient" id="divPatient" runat="server" style="display: none;">
                <fieldset class="divTable" id="divPR">
                    <legend><span class="spnTimeSpan" id="AgencyReportFilterBox_tdlblPR">PR:</span></legend>
                    <div class="row" id="div2" runat="server">
                        <div id="divchk" runat="server">
                            <input type="checkbox" class="multicheckbox" name="chk" id="all" value="" checked="checked" onclick="DefaultChkbox()" />All                                                                          
                                     <input type="checkbox" class="multicheckbox" name="chk" id="ChkDeductable" value="1" onclick="DefaultChkbox()" />Deductable                                      
                                     <input type="checkbox" class="multicheckbox" name="chk" id="ChkCoInsurance" value="2" onclick="DefaultChkbox()" />Co Insurane                                      
                                     <input type="checkbox" class="multicheckbox" name="chk" id="ChkCoPayment" value="3" onclick="DefaultChkbox()" />Co Payment                                                                                                                                              
                        </div>
                    </div>
                </fieldset>
            </div>
            <%--End--%>


            <hr id="hrHideForEmployee" runat="server" style="display: none !important" />
            <br id="brHideForEmployee" runat="server" style="display: none !important" />

            <%--changes added by ali imran 12 feb 2019--%>
            <div class="divPatFilter" id="divPatFilter" runat="server" style="display: none;">

                <fieldset class="divTable" id="divReportPatFitler">
                    <legend><span class="spnTimeSpan" id="">Pat Filter:</span></legend>

                    <input type="text" id="txtpatientFilter" style="width: 30%" onkeyup="SearchPatient()" />
                    <div
                        style="display: none; position: absolute; width: 50%; max-height: 106px; overflow-y: scroll; overflow-x: hidden; margin-top: 3px;"
                        id="divpatfilterlist">
                    </div>

                </fieldset>
                <div class="divselectedpatient" style="margin: 10px;">
                </div>
            </div>

            <%--changes ended by ali imran 12 feb 2019--%>
        </div>
        <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel" Visible="false" />
        </div>

         <div id="divSearchUser" style="display: none" class="Grid">

             <div id="usersearchlist"></div>
         </div>


        <div class="RFSCDetails" id="RFSCDetails" style="display: none" runat="server">
            <table>
                <tr>
                    <td>Date Type:</td>
                    <td>
                        <select name="ddlPostType" id="ddlDateType" class="ddlPostType" onchange="Enable_DisableDates()" style="width: 96.6%;">
                            <option selected="selected" value="">Select Date Type</option>
                            <option value="DOS">Service Date</option>
                            <option value="PostDate">Post Date</option>

                        </select>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>DOS:</td>
                    <td>
                        <span style="width: 10%; float: left">From:</span><span style="width: 39%; float: left"><input type="text" class="RFSDOS RFSDOSFrom" disabled="disabled" /></span>
                        <span style="width: 10%; float: left">To:</span><span style="width: 39%; float: left"><input type="text" class="RFSDOS RFSDOSTo" disabled="disabled" /></span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Post Date:</td>
                    <td>
                        <span style="width: 10%; float: left">From:</span><span style="width: 39%; float: left"><input type="text" class="RFSPostDate RFSPostDateFrom" disabled="disabled" /></span>
                        <span style="width: 10%; float: left">To:</span><span style="width: 39%; float: left"><input type="text" class="RFSPostDate RFSPostDateTo" disabled="disabled" /></span>
                    </td>
                </tr>
            </table>
        </div>








        <script type="text/javascript">
            $(".RFSDOS").blur();
            $(document).ready(function () {
                $(".RFSDOS").blur();
            });
            $(document).ready(function () {

            });
        </script>



        ###End###

        ###startGetingPatient###
          <div class="Grid">
              <table class="tblPatient">
                  <tr>
                      <th>PatientId</th>
                      <th>Name</th>
                  </tr>
                  <asp:Repeater ID="rptPatientlist" runat="server">
                      <ItemTemplate>
                          <tr onclick="SelectPatient(this)">
                              <td class="tdpatientid"><%# Eval("PatientId") %></td>
                              <td class="tdpatientName"><%# Eval("PatientName") %></td>
                          </tr>
                      </ItemTemplate>
                  </asp:Repeater>
              </table>
          </div>
        ###endGetingPatient###
    
    </form>
</body>
</html>
