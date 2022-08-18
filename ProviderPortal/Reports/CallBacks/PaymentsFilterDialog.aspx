<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentsFilterDialog.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_PaymentsFilterDialog" %>

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

            .divReportName {
                color: black;
                font-weight: bold;
                line-height:24px;
                margin-bottom:10px;
            }

            .spnBranchName {
               float: left;
                font-weight: bold;
               
                width: 20%;
               padding-top: 5px;
            }
            .BranceInput{
                width:100%;
                float:right;
                margin-top:0%;
                margin-bottom:1%;
            }
            .reportdropdown
            {
                padding: 5px 0px 4px 4px;
                width: 92.6%;
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
                border-color:#ccc;
                border-radius:4px;
                box-sizing:border-box;

            }

            .divTableRow {
                display: table-row;
            }

            .divTableHeading {
                background-color: #EEE;
                display: table-header-group;
            }

            /*.divTableCell, .divTableHead {
                /*border: 1px solid #999999;
                border-right-style: none;
                border-left-style: none;
                border-bottom-style: none;*/
               
                /*padding: 3px 10px;*/
            /*}*/

            /*.divRightBorder {
                border-right-style: solid;
            }*/

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
            /*.ui-dialog-title{
                margin-left:15%;
                margin-top:1%;
            }*/
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
            .radio_li
            {
                padding-bottom:5px;
            }
            .row{
                width:100%;
            }
            .col40{
                width:40%;
                float:left;
                padding-left:10px;
                padding-right:10px;
                box-sizing:border-box;
            }
            .col60{
                width:60%;
                float:left;
                padding-left:10px;
                padding-right:10px;
                box-sizing:border-box;
            }
            .divBranchName{
                width:100%;
            }
            .ddlselect
            {
                float: left;
                max-height: 170px;
                overflow-y: auto;
                width: 100%;
                margin-top: 3px;
                background: white;
                position: relative;
                z-index: 999;
                border: 1px solid #ccc;
                margin-left: -5px;
                padding: 0px 5px;
            }
            #divReportServiceProvider{
                padding-top: 33px;
            }
            #divReportProcedure{
                padding-top: 17px;
            }
            #divInsuranceDetailDialog{
                padding-top: 30px;
            }
            .ui-datepicker-trigger{
                margin-left:-8%;
            }
        </style>
        <script type="text/javascript">
            $(function () {
                $("#txtReportDateTo").datepicker({
                    changeMonth: true,
                    changeYear: true,
                });
                $("#txtDueDateFrom").datepicker();
                $("#txtReportDateFrom").datepicker({

                    changeMonth: true,
                    changeYear: true,
                });
                $("#txtAgingDate").datepicker({
                    changeMonth: true,
                    changeYear: true,
                });
                $("#txtBillDateFrom").datepicker({
                    changeMonth: true,
                    changeYear: true,
                });

                $("#txtBillDateTo").datepicker({
                    changeMonth: true,
                    changeYear: true,
                });
            });
            function GetPayerDropDown(elem) {
                debugger;
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
                debugger;
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
                debugger;
                _CurrentTextBoxICD = $(elm);
                if (event.keyCode == 27) {
                    $("#divICDsSearched").hide("");
                    return false;
                }

                $.post("../../ProviderPortal/Controls/ICDSearch.aspx", { Code: $.trim(code), Description: $.trim(desc) }, function (data) {
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
                    PagePath = "../../ProviderPortal/Controls/LCDDiagnosis.aspx";

                    if (CallFrom == "PatientChart") {
                        _DXCode = $(elem).closest("tr").find(".DiagCode").val();
                    }
                    else if (CallFrom == "ClaimForm") {
                        _DXCode = $.trim($(elem).closest("td").prev().find("input:text").val());
                    }
                }
                else if (Type == "Procedure") {
                    PagePath = "../../ProviderPortal/Controls/LCDProcedure.aspx";

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
                debugger;
                var icdCode = ''; var IcdDesc = '';

                icdCode = $.trim($(elem).closest("tr").find(".hdnCode").html());
                IcdDesc = $.trim($(elem).closest("tr").find(".hdnDescription").html());
                _CurrentTextBoxICD = null;
                $("#txtIcdCode1").val(icdCode);
                $("#txtIcdDesc1").val(IcdDesc);
                $("#divICDsSearched").hide();
            }

            function addServiceRow(elem) {
                debugger;

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
                debugger;
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
            function SelectCPT(elem) {
                debugger;
                var cptCode = ''; var cptDesc = '';
                cptCode = $.trim($(elem).closest("tr").find(".cpt-code").html());
                cptDesc = $.trim($(elem).closest("tr").find(".cpt-description").html());
                _CurrentTextBoxCPT = null;
                $("#txtCPTCode").val(cptCode);
                $("#txtCPTDescription").val(cptDesc);
                $("#divCPTSearched").hide();

            }
            function AddNoRecordFoundInGrids(tblTbody) {
                if ($("#" + tblTbody + " tr").not(".trNoRecord").length == 0) {
                    var colspan = $("#" + tblTbody).parent().find("thead th").length;
                    $("#" + tblTbody).html("<tr style='text-align:center;' class='trNoRecord'><td colspan='" + colspan + "'><span Style='color: red; font-size: 14px; font-weight: bold;font-style: italic;'>No record found.</span></td></tr>");
                }
                else
                    $("#" + tblTbody + " tr.trNoRecord").remove();
            }



        </script>

        <div id="divDialogReportFilterBoxInner" style="">
            <div class="divDialogReportFilterBoxInnerHeader">
            </div>
            
                <div id="divPayersName" runat="server" style="display:none; padding-bottom:45px;">
                          <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Payer Name:</span>
                    <div class="clsPayerName BranceInput"   onchange="GetPayerDropDown('divddlCheckNumber');">
                            <asp:DropDownList ID="ddlPayerName" CssClass="ddlPayerName" runat="server" Style="">
                                </asp:DropDownList>
                        </div>
                    </div>
               
                </div>
                <div id="divCheckNumber" runat="server" style="display:none; padding-bottom:45px;">
                  
                 <div class="divBranchName">
                       <span class="spnBranchName" style="">Check Number:</span>
                    <div class="clsCheckNumber BranceInput" id="divddlCheckNumber" onchange="GetPayerDropDown('divddlPostDate');">
                            <asp:DropDownList ID="ddlCheckNumber" CssClass="ddlCheckNumber" runat="server" Style="">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                
                </div>
                <div id="divPostDate" runat="server" style="display:none; padding-bottom:45px;">
                   
                    
                 <div class="divBranchName">
                       <span class="spnBranchName" style="">Post Date:</span>
                    <div class="clsPostDate BranceInput" id="divddlPostDate">
                            <asp:DropDownList ID="ddlPostDate" CssClass="ddlPostDate" runat="server" Style="">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                </div>
              
            
                <div id="divAgingType" runat="server" style="display:none;padding-bottom:45px;">
                  
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
            <div id="divAgingDate" runat="server" style="display:none; padding-bottom:45px;">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Aging Date:</span>
                    <div class="clsPostDate BranceInput">
                          <asp:TextBox ID="txtAgingDate" runat="server" CssClass="required" Style="" placeholder="Please Select Date"></asp:TextBox>
                        </div>
                    </div>
                </div>
              <div id="divPostType" runat="server" style="display:none; padding-bottom:45px">
                  
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="float:left; margin-left:0%; width:100%;">Date Type:</span>
                    <div class="clsPostDate BranceInput" id="divddlPostType">
                            <asp:DropDownList ID="ddlPostType" CssClass="ddlPostType" runat="server" Style="" onchange="EnableDisableDates()"> 
                              <asp:ListItem Value="">Select Date Type</asp:ListItem>
                                 <asp:ListItem Value="DOS">Service Date</asp:ListItem>
                                <asp:ListItem Value="PostDate">Posting Date</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                    
                </div> 


                   <div id="divSubmissionStatus" runat="server" style="display:none; padding-bottom:45px">
                  
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="float:left; margin-left:0%;">Status:</span>
                    <div class="clsPostDate BranceInput" id="">
                            <asp:DropDownList ID="ddlSubmissionStatus" CssClass="ddlPostType" runat="server" Style="">
                              <asp:ListItem Value="">Select Submission Status</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                    
                </div> 

                <div id="divPracticeLocationId" runat="server" style="display:none;padding-bottom:35px;">
                    <div class="divBranchName" style="">
                     <span class="spnBranchName" style="float:left; margin-left:0%;">Location:</span>
                        <div class="BranceInput">    
                            <div  class=" reportdropdown" style="">
                            <a onclick="hideShowMenu('divPracticeLocation');">
                                <div class="selectedText">
                                    All Locations
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;"/>
                                </div>
                            </a>
                            <div id="divPracticeLocation" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                               <div class="ddlselect">
                                    <ul id="ulMultiPracticeLocation" onchange="GetServiceProviderDropDown();">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkPracticeLocationAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptLocation">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("PracticeLocationsId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" />
                                                        <span><%#Eval("Name") %></span>
                                                        <input type="hidden" value='<%#Eval("PracticeLocationsId") %>' id="PatientId"/>
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

                       


                <div id="divReportServiceProvider" runat="server" style="padding-bottom:40px; display:none">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Provider :</span>
                     <div class="BranceInput">
                           <div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divServiceProvider');">
                                <div class="selectedText">
                                    All Providers
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;"/></div>
                            </a>
                         <div id="divServiceProvider" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                  <div class="ddlselect">
                                      <ul id="ulMultiServiceProvider">
                                          <li style="float: left; width: 100%;">
                                              <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                  <input type="checkbox" id="chkServiceProviderAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                  <span>All Providers</span>
                                                  <input type="hidden" value="0" />
                                              </label>
                                          </li>
                                          <asp:Repeater runat="server" ID="rptProviders">
                                              <ItemTemplate>
                                                  <li style="float: left; width: 100%;">
                                                      <label name='<%#Eval("PracticeStaffId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                          <input type="checkbox" class="chkPracticeLocation chk-multi-checkboxes" checked="checked" />
                                                          <span><%#Eval("Providers") %></span>
                                                          <input type="hidden" value='<%#Eval("PracticeStaffId") %>' id="PatientId" />
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
                   <div id="divPatientDetailDialog" runat="server" style="padding-bottom:25px; display:none">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="float:left; margin-left:0%;">Patient Name:</span>
                    <div class="clsPatientId BranceInput">
                            <asp:DropDownList ID="ddlPatientList" CssClass="ddlPatientList" runat="server" Style="">
                                
                                </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div id="divReportProcedure" runat="server" style="display:none; padding-bottom:30px;">
                    <div class="divBranchName" style ="">
                       <span class="spnBranchName" style="">Procedure :</span>
                    <div class="clsDiagnosis BranceInput" id="divProcedure" style="">
                        <table>
                       <tr>
                        <td style="width:140px" class="leftTd">
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

              <div id="divCPTSearched"  style="width:72%; left:20%; height: 305px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto;">
                        <div class="Grid" style="width: 99%; height: auto;">
                           <table>
                               <thead>
                                   <tr>
                                       <th>Code</th>
                                        <th>Description</th>
                                   </tr>
                                </thead>
                                <tbody id="CPTSearchedList">
                                </tbody>
                           </table>
                         </div>
                     </div>


                <div id="divReportPayerScenario" runat="server" style="padding-bottom:45px; padding-top:15px; display:none;">
                 <div class="divBranchName">
                       <span class="spnBranchName" style="">Payer Scenario :</span>
                     <div class="BranceInput"><div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divPayerScenario');">
                                <div class="selectedText">
                                    All Payer Scenario
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;"/></div>
                            </a>
                            <div id="divPayerScenario" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                               <div class="ddlselect">
                                    <ul id="ulMultiPayerScenario">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkPayerScenarioAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All Payer Scenario</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptPayerScenario">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("InsuranceId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkPayerScenario chk-multi-checkboxes" checked="checked" />
                                                        <span><%#Eval("Payers") %></span>
                                                        <input type="hidden" value='<%#Eval("InsuranceId") %>' id="PatientId"/>
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                
                            </div>
                </div></div>
                      
                    </div>
                </div>

                       <div id="divReportUnpaidinsurances" runat="server" style="padding-bottom:45px;display:none; padding-top:15px;">
                 <div class="divBranchName">
                       <span class="spnBranchName" style="">Unpaid Insurances :</span>
                     <div class="BranceInput"><div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divUnpaidinsurances');">
                                <div class="selectedText">
                                   All Unpaid Insurances
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;"/></div>
                            </a>
                            <div id="divUnpaidinsurances" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">                            
                                        <div class="ddlselect">
                                    <ul id="ulMultiUnpaidinsurances">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkUnpaidinsurancesAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All Unpaid Insurances</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptunpaidinsurances">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("InsuranceId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkunpaidinsurance chk-multi-checkboxes" checked="checked" />
                                                        <span><%#Eval("insurance") %></span>
                                                        <input type="hidden" value='<%#Eval("InsuranceId") %>' id=""/>
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                
                            </div>
                </div></div>
                      
                    </div>
                </div>

       
            
                  <div id="divReportClaimStatus" runat="server" style="display:none; padding-bottom:45px; padding-top:15px;">
                <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Claim Status :</span>
                    <div class="BranceInput"> 
                        <div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divCalimStatus');">
                                <div class="selectedText">
                                    All Claims
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;"/></div>
                            </a>
                            <div id="divCalimStatus" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                               <div class="ddlselect">
                                    <ul id="ulMultiCalimStatus">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkCalimStatusAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All Calims</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptCalimStatus">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("SubmissionStatusId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkCalimStatus chk-multi-checkboxes" checked="checked" />
                                                        <span><%#Eval("SubmissionStatus") %></span>
                                                        <input type="hidden" value='<%#Eval("SubmissionStatusId") %>' id="PatientId"/>
                                                    </label>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                
                            </div>
                </div></div>
                     
                    </div>
                </div>
            
             <div id="divReportPatientName" runat="server" style="display:none; padding-bottom:30px;">
                <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Patient Name:</span>
                    <div class="BranceInput">
                           <div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divPatientName');">
                                <div class="selectedText">
                                    All Patients
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;"/></div>
                            </a>
                            <div id="divPatientName" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                               <div class="ddlselect">
                                    <ul id="ulMultiPatientName">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkPatientNameAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All Patients</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptPatientName">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("PatientId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkPatientName chk-multi-checkboxes" checked="checked" />
                                                        <span><%#Eval("PatientName") %></span>
                                                        <input type="hidden" value='<%#Eval("PatientId") %>' id="PatientId"/>
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
              <div id="divInsuranceDetailDialog" runat="server" style="display:none; padding-bottom:30px;">
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
              <div id="divBalance" runat="server" style="display:none; padding-bottom:45px;">
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
              <div id="divDateOfService" runat="server" style="display:none;padding-bottom:45px; padding-top:15px;">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Date Of Service Age:</span>
                    <div class="clsDateOfService BranceInput" >
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
            <div id="divBillDates" runat="server" style="display:none; padding-bottom:30px">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Bill Dates:<span style="color:red;">*</span></span>
                     <br />
                     <br />
                     <hr />
                     <div class="BranceInput">
                         <div style="width:100%">
                            <div id="From" style="width:50%;float:left;">
                             <span style="width:100%;float:left; margin-left:25%;">From:</span>
                             <span style="width:100%;float:right"><asp:TextBox runat="server" ID="txtBillDateFrom" CssClass="required" style="margin-left:25%;width:200px !important" Enabled="false"></asp:TextBox></span>
                         </div>
                         <div id="to" style="width:50%;float:right;">
                               <span style="width:100%;float:left">To:</span>
                             <span style="width:100%;float:right">   <asp:TextBox runat="server" ID="txtBillDateTo" CssClass="required" style="width:200px !important" Enabled="false"></asp:TextBox></span>
                         </div>
                         </div>
                        
                    
                                    </div>
                     </div>
            </div>
            
             <div id="divReportDenailPayerName" runat="server" style="display:none; padding-bottom:45px; padding-top:15px;">
                <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Insurance :</span>
                    <div class="BranceInput">
                            <div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divDenailPayerName');">
                                <div class="selectedText">
                                    All Insurances
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;"/></div>
                            </a>
                            <div id="divDenailPayerName" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                               <div class="ddlselect">
                                    <ul id="ulMultiDenailPayerName">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkDenailPayerNameAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All Insurances</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptDenailPayerName">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("Name") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkDenailPayerName chk-multi-checkboxes" checked="checked" />
                                                        <span><%#Eval("Name") %></span>
                                                        <input type="hidden" value='<%#Eval("InsuranceId") %>' id="PatientId"/>
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
             <div id="divReportAdjustmentCode" runat="server" style="display:none;padding-bottom:45px; padding-top:15px;">
                <div class="divBranchName" style="">
                       <span class="spnBranchName" style="float:left; margin-left:0%;">Adjustment Code:</span>
                    <div class="BranceInput">
                               <div  class="reportdropdown" style="">
                            <a onclick="hideShowMenu('divAdjustmentCode');">
                                <div class="selectedText">
                                    All 
                                </div>
                                <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                    <img src="../../Images/dropdown.gif" style="width:40%;"/></div>
                            </a>
                            <div id="divAdjustmentCode" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                               <div class="ddlselect">
                                    <ul id="ulMultiAdjustmentCode">
                                        <li style="float: left; width: 100%;">
                                            <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float:left;">
                                                <input type="checkbox" id="chkAdjustmentCodeAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                <span>All</span>
                                                <input type="hidden" value="0" />
                                            </label>
                                        </li>
                                        <asp:Repeater runat="server" ID="rptAdjustmentCode">
                                            <ItemTemplate>
                                                <li style="float: left; width: 100%;">
                                                    <label name='<%#Eval("AdjustmentCode") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left;">
                                                        <input type="checkbox" class="chkAdjustmentCode chk-multi-checkboxes" checked="checked"  style=""/>
                                                        <span><%#Eval("CodeDescription") %></span>
                                                        <input type="hidden" value='<%#Eval("AdjustmentCode") %>' id="PatientId"/>
                                                    </label>
                                                     <%--<label name='<%#Eval("AdjustmentCode") %>' onclick="Report_ClickMultiCheckBox(this);" style="float:left; width:100%">
                                                        <div class="inputCheckBox" style="width:5%;float:left"> <input type="checkbox" class="chkAdjustmentCode chk-multi-checkboxes" checked="checked" style=""/></div>
                                                        <div class="descriptions"style="width:95%;float:right">   
                                                             <span style=""><%#Eval("CodeDescription") %></span>
                                                        <input type="hidden" value='<%#Eval("AdjustmentCode") %>' id="AdjustmentId"/></div>--%>
                                                       
                                                     
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
               <div id="divReportPaymentType" runat="server" style="display:none;padding-bottom:45px">
                  
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Payment Type:</span>
                    <div class="clsPostDate BranceInput" id="divddlPaymentType">
                            <asp:DropDownList ID="ddlPaymentType" CssClass="ddlPaymentType" runat="server" Style="" >
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="ERA">ERA</asp:ListItem>
                                <asp:ListItem Value="EOB">EOB</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                    
                </div> 
              <div id="divPaymentMethod" runat="server" style="display:none;padding-bottom:45px">
                  
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="">Payment Method:</span>
                    <div class="clsPostDate BranceInput"  id="divddlPaymentMethod">
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
           
               <div id="divAppointmentStatus" runat="server" style="padding-bottom:45px; display:none">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="float:left; margin-left:0%;">Status:</span>
                    <div class="clsPatientId BranceInput">
                            <asp:DropDownList ID="ddlAppointmentStatus" CssClass="ddlAppointmentStatus" runat="server" Style="">
                                
                                </asp:DropDownList>
                        </div>
                    </div>
                </div>

              <div id="divAppointmentReasons" runat="server" style="padding-bottom:45px; display:none">
                 <div class="divBranchName" style="">
                       <span class="spnBranchName" style="float:left; margin-left:0%;">Reasons:</span>
                    <div class="clsPatientId BranceInput">
                            <asp:DropDownList ID="ddlAppointmentReasons" CssClass="ddlAppointmentReasons" runat="server" Style="">
                                
                                </asp:DropDownList>
                        </div>
                    </div>
                </div>


           <%-- <hr id="hrEndPatientDetail" runat="server"/>--%>
            <div class="divTimeSpan" id="divTimeSpan" runat="server" style="display:none; padding-top:15px;">
              
                <fieldset class="divTable" id="divReportTimeSpan">
                    <legend>  <span class="spnTimeSpan" id="AgencyReportFilterBox_tdlblTimeSpam">Time Span:</span></legend>
                
                           <div class="row" id="divRowRdo" runat="server" >
                                <div class="col40" id="divCellBeginning" style="width:40%" runat="server">
                                    <ul style="margin-top:8px;">
                                    <li class="radio_li"> <asp:RadioButton runat="server" ID="rbReportTimeSpanFromTheBeginning" Text="From the Beginning" Checked="true" CssClass="Beginning" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    <li  class="radio_li"> <asp:RadioButton runat="server" ID="rbReportTimeSpanLastMonth" Text="Last Month" CssClass="LastMonth" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    <li  class="radio_li">  <asp:RadioButton runat="server" ID="rbReportTimeSpanMonthToDate" Text="Month to Date" CssClass="MonthToDate" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    <li  class="radio_li"> <asp:RadioButton runat="server" ID="rbReportTimeSpanYearToDate" Text="Year to Date" CssClass="YearToDate" GroupName="rbReportTimeSpan" onclick="EnableDates(false);" /></li>
                                    </ul>
                                       
                                       
                                        
                                      
                                       
                                </div>
                                <div class="col60">
                                        <asp:RadioButton runat="server" ID="rbReportTimeSpanSpecificDates" Text="Select Date" CssClass="SpecificDates" GroupName="rbReportTimeSpan" onclick="EnableDates(true);"  Style="font-weight:bold;"/>
                                    <br />
                                        <div class="">
                                            <table id="timeDurationAgencyReportFilterBox" style="width: 325px; table-layout: auto; margin-top: -2%;">
                                                <tr>
                                                    <td style="width: 45px; text-align: right;">
                                                        <span>From:</span>
                                                    </td>
                                                    <td style="width: 120px;">
                                                        <asp:TextBox runat="server" ID="txtReportDateFrom" CssClass="required" Enabled="false"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 40px; text-align: right;" id="spnTo" runat="server">
                                                        <span">To:</span>
                                                    </td>
                                                    <td style="width: 120px;" id="tdDateTo" runat="server">
                                                        <asp:TextBox runat="server" ID="txtReportDateTo" CssClass="required" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                        </table>
                                    </div>
                                </div>
                           </div>
                 
                </fieldset>
            </div>
           
            <hr id="hrHideForEmployee" runat="server"  style="display:none !important"/>
            <br  id="brHideForEmployee" runat="server" style="display:none !important"/>
        </div>
           <%-- <div class="ui-dialog-buttonpane" style="background-color:white !important; display:none">--%>
            <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel"  Visible="false"/>
            </div>
        ###End###
    </div>
    </form>
</body>
</html>