<%@ Page Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Eligibility.aspx.cs" Inherits="ProviderPortal_Eligibility_Eligibility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../Scripts/Eligibility.js"></script>
    <style type="text/css">
        .clsPayerInformation, .clsInsureSubscriberUnformation, .clsDateOfService {
            float: left;
            margin-left: 2%;
            width: 96%;
            background-color: white;
        }

        .clsContent {
            background-color: white;
            width: 95%;
            margin: 0 auto;
        }

        .divTable {
            display: table;
            width: 100%;
        }

        .divTableRow {
            display: table-row;
        }

        .divTableHeading {
            background-color: #EEE;
            display: table-header-group;
        }

        .divTableCell, .divTableHead {
            /*border: 1px solid #999999;*/
            display: table-cell;
            padding: 3px 10px;
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

        .spnRequired {
            color: red;
        }

        .clsLabel {
            width: 13%;
        }

        .clsInputName {
            width: 20%;
        }

        .warning {
            background: url("../../Images/warning.png") no-repeat scroll 10px center #FFD1D1;
            border: 1px solid #F8ACAC;
            border-radius: 5px;
            -moz-border-radius: 5px;
            -o-border-radius: 5px;
            -webkit-border-radius: 5px;
            color: #a94442;
            font-size: 12px;
            margin-bottom: 15px;
            padding: 10px 10px 10px 33px;
        }

        .divclass {
            background: #f00;
            width: 100%;
        }

        #divid {
            background: #f00;
            width: 100%;
        }
    </style>

    <script type="text/javascript">

        // Start Added By Rizwan kharal 10May2018

        $(document).ready(function () {

            if (!checkModuleRights("Eligibility")) {

                $("[id$='divRightsSettings']").html("You don't have rights to View Eligibility").show();
                $("#ContentMaindiv").hide();
                return false;
            }

            $("#_Eligibility").addClass("active");

        });
        // End Added By Rizwan kharal 10May2018
        $(function () {
            $(".txtDates").datepicker({
                changeMonth: true,
                changeYear: true,
            });
            $("#txtDateOfBirth").datepicker({
                maxDate: '0',
                changeMonth: true,
                changeYear: true,
            });

            $("#txtFromDate").attr("disabled", "disabled");
            $("#txtToDate").attr("disabled", "disabled");
        });
        function GetPatients() {
            debugger;
            $.post(_ResolveUrl + "ProviderPortal/Eligibility/CallBacks/GetPatients.aspx", {
            }).done(function (data) {
                debugger;
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#divPatients").html(returnHtml.substring(start, end));

                $("#divPatients").dialog({
                    title: "Patients",
                    width: 1100,
                    modal: true,
                    //position: { my: 'top', at: 'top+1000' },
                    open: function (event, ui) {
                        //$(".ui-widget-header").css("width", "96.8%");
                        //$(".ui-dialog-buttonpane").css("width", "96.8%");
                    },
                    buttons: {
                        "Close": function () {
                            $(this).dialog("close");
                        }
                    }
                });

            }).fail(function () {
                showErrorMessage("Error:.");
            });
        }
        function GetPatientRow(PatientId, LastName, FirstName, Gender, DOB, PolicyNumber, InsuranceId) {
            debugger;
            $("[id$='hdnPatientId']").val(PatientId);
            $("#txtSubscriberID").val(PolicyNumber);
            $("#txtLastName").val(LastName);
            $("#txtFirstName").val(FirstName);
            $(".clsddlGender").val(Gender);
            $("#txtDateOfBirth").val(DOB);
            $("#divPatients").dialog("close");
            $(".ddlEligibilityPayerName > [value=" + InsuranceId + "]").attr("selected", "true");
            $('.ddlEligibilityPayerName').val(InsuranceId);
        }
        function ClearForm() {
            $("[id$='hdnPatientId']").val("");
            $("#txtLastName").val("");
            $("#txtFirstName").val("");
            $(".clsddlGender").val("");
            $("#txtDateOfBirth").val("");
            $("#txtSubscriberID").val("");
            $("#txtFromDate").val("");
            $("#txtToDate").val("");
            $('.ddlEligibilityPayerName').removeAttr('selected');

            $("[id$='ddlPayerName']").css("border", "1px solid #c4c4c4");
            $("#txtLastName").css("border", "1px solid #c4c4c4");
            $("#txtFirstName").css("border", "1px solid #c4c4c4");
            $("#txtDateOfBirth").css("border", "1px solid #c4c4c4");
            $("#txtSubscriberID").css("border", "1px solid #c4c4c4");


        }
        function EnableDiableDate() {
            if ($('#rdoCustomEligibiltyDates').prop('checked') == true) {
                $("#txtFromDate").removeAttr("disabled", "disabled");
                $("#txtToDate").removeAttr("disabled", "disabled");
            }
            else {
                $("#txtFromDate").attr("disabled", "disabled");
                $("#txtToDate").attr("disabled", "disabled");
            }

        }
        function checkEligibility() {

            var flag = false;
            $(".required").each(function () {
                if (!$(this).val()) { flag = true; }
            });

            if (flag) {
                if ($('.ddlEligibilityPayerName').find(":selected").val() == "0") {
                    $("[id$='ddlPayerName']").css("border", "1px solid red");
                    showErrorMessage("Please select payer name!.")
                    return;
                }
                else {
                    $("[id$='ddlPayerName']").css("border", "1px solid #c4c4c4");

                }
                if ($("#txtLastName").val() == "") {
                    $("#txtLastName").css("border", "1px solid red");
                    showErrorMessage("Mandatory fields * cannot be empty!")
                    return;
                }
                else {
                    $("#txtLastName").css("border", "1px solid #c4c4c4");

                }

                if ($("#txtFirstName").val() == "") {
                    $("#txtFirstName").css("border", "1px solid red");
                    showErrorMessage("Mandatory fields * cannot be empty!")
                    return;
                }

                else {
                    $("#txtFirstName").css("border", "1px solid #c4c4c4");

                }
                if ($("#txtDateOfBirth").val() == "") {
                    $("#txtDateOfBirth").css("border", "1px solid red");
                    showErrorMessage("Mandatory fields * cannot be empty!")
                    return;
                }
                else {
                    $("#txtDateOfBirth").css("border", "1px solid #c4c4c4");

                }
                debugger
                if ($("#txtSubscriberID").val() == "") {
                    $("#txtSubscriberID").css("border", "1px solid red");
                    showErrorMessage("Mandatory fields * cannot be empty!")
                    return;
                }

                else {

                    $("#txtSubscriberID").css("border", "1px solid #c4c4c4");

                }

            }
            else {
                $(".required").css("border", "1px solid #c4c4c4");
            }



            if ($("#rdoCustomEligibiltyDates").is(":checked")) {


                if ($("#txtFromDate").val() == "") {
                    $("#txtFromDate").css("border", "1px solid red");
                    showErrorMessage("Please select from date")
                    return;
                }

                else {
                    $("#txtFromDate").css("border", "1px solid #c4c4c4");

                }
                if ($("#txtToDate").val() == "") {
                    $("#txtToDate").css("border", "1px solid red");
                    showErrorMessage("Please select to date")
                    return;
                }

                else {
                    $("#txtToDate").css("border", "1px solid #c4c4c4");

                }


                var startDate = new Date($('#txtFromDate').val());
                var endDate = new Date($('#txtToDate').val());

                if (endDate < startDate) {
                    showErrorMessage("Date from can not greater then  to date.")
                    return;
                }



            }


            CheckPatientEligibility('Eligibility');
        }
        var _IsPatientIdValidated = true;
        function patientIdKeyPress(evt) {
            _IsPatientIdValidated = true;
            var isValidate = ValidateOnlyNumber(evt);
            if (!isValidate) {
                _IsPatientIdValidated = false;
            }

            return _IsPatientIdValidated;
        }
        function FilterPatient(pageNumber, paging) {
            debugger;
            var PatientId = $.trim($("#txtPatientIdP").val()) == "" ? 0 : $.trim($("#txtPatientIdP").val());
            var LastName = $.trim($("#txtLastNameP").val());
            var FirstName = $.trim($("#txtFirstNameP").val());
            var Gender = $.trim($("#ddlGenderP").val());
            var DOB = $.trim($("[id$='txtDateOfBirthP']").val());
            var Payer = $.trim($("[id$='txtPriPayer']").val());
            $.post(_ResolveUrl + "ProviderPortal/Eligibility/CallBacks/GetPatientsHandler.aspx", { Payer: Payer, PatientId: PatientId, FirstName: FirstName, LastName: LastName, Gender: Gender, DOB: (isDate(DOB) ? DOB : ""), Rows: $("#ddlPagingPatient").val(), PageNumber: pageNumber, SortBy: "FirstName" }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                $("#patientList").html(returnHtml.substring(start, end));
                debugger;
                var startRowsCount = data.indexOf("###StartPatientRowsCount###") + 30;
                var endRowsCount = data.indexOf("###EndPatientRowsCount###");
                $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
                if (paging == true) {
                    GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
                }
                if ($("[id$='hdnTotalRows']").val() > 0)
                    $("#PatientContainer .spanInfo").html("Showing " + $("#patientList tr:first").children().first().html() + " to " + $("#patientList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
            });
        }

        //Added By Rizwan kharal 3August2018
        function FilterPatientOnEnter(event) {
            debugger;
            var a = event.which || event.keyCode;
            if (a == 13) {

                FilterPatient(0, true);

            }
            else {
                return
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdnPatientId" runat="server" />
    <div class="">
        <div class="widget">
            <div class="widgettitle">Verify Eligibility</div>
            <div class="widgetcontent" style="padding-bottom: 20px;">
                <div class="clsSubContent" style="width: 100%; float: left; background-color: white;">
                    <div class="clsPayerInformation">
                        <h3 style="border-bottom: 1px solid black; width: 100%;">Payer Information
                        </h3>
                        <div id="divPayerName">
                            <div class="row mb-3">
                                <label for="ddlPayerName" class="col-sm-5 col-md-4 col-lg-2">Payer Name :</label>
                                <div class="col-sm-6 col-md-5 col-lg-3">
                                    <asp:DropDownList ID="ddlPayerName" CssClass="ddlEligibilityPayerName" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clsInsureSubscriberUnformation">
                        <h3 style="border-bottom: 1px solid black; width: 100%; float: left;">Insured /Subscriber Information
                        </h3>
                        <div class="clsInsuredSubscriderInfoFields">

                            <div class="row mb-3">
                                <div class="col-lg-2">
                                    <label for="txtLastName">LastName<span class="spnRequired">*</span> :</label>
                                </div>
                                <div class="col-lg-4">
                                  

                                    <div class="input-group">
  <input type="text" id="txtLastName" class="form-control required" aria-label="LastName" aria-describedby="basic-addon2" />
  <span class="input-group-text" id="basic-addon2"><span id="btnSelectPatient" onclick="GetPatients();">Select Patient</span>  </span>
</div>



                                </div>
                                <div class="col-lg-2">
                                    <label for="txtFirstName">First Name<span class="spnRequired">*</span> :</label>
                                </div>
                                <div class="col-lg-4">
                                    <input type="text" id="txtFirstName" class="required" />
                                </div>
                            </div>

                            <div class="row mb-3">
                                <div class="col-lg-2">
                                    <label for="txtNameSuffix">Name Suffix :</label>
                                </div>
                                <div class="col-lg-4">
                                    <input type="text" id="txtNameSuffix" style="" />
                                </div>
                                <div class="col-lg-2">
                                    <label for="ddlGender">Gender :</label>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddlGender" CssClass="clsddlGender" runat="server" Style="">
                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row mb-3">
                                <div class="col-lg-2">
                                    <label for="txtDateOfBirth">Date Of Birth(MMDDYYYY)<span class="spnRequired">*</span> :</label>
                                </div>
                                <div class="col-lg-4">
                                    <input type="text" id="txtDateOfBirth" style="" class="required" />
                                </div>
                                <div class="col-lg-2">
                                    <label for="txtSubscriberID">Subscriber ID (HICN)<span class="spnRequired">*</span> :</label>
                                </div>
                                <div class="col-lg-4">
                                    <input type="text" id="txtSubscriberID" style="" class="required" />
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="clsDateOfService">
                        <h3 style="border-bottom: 1px solid black; width: 100%;">Date(s) Of Service
                        </h3>
                        <div class="clsDateOfServiceFields">


                            <div class="row mb-3">

                                <div class="col-lg-3">
                                    <div class="form-check">
                                        <input class="form-check-input" type="radio" id="rdoCurrentEligibilityInfo" name="rdoEligibility" checked="checked" />

                                        <label class="form-check-label" for="rdoCurrentEligibilityInfo">
                                            Current Eligibility Information
                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-check">
                                        <input class="form-check-input" type="radio" id="rdoCustomEligibiltyDates" name="rdoEligibility" onclick="EnableDiableDate();" />

                                        <label class="form-check-label" for="rdoCustomEligibiltyDates">
                                            Custom Eligibilty Dates
                                        </label>
                                    </div>
                                </div>

                            </div>



                            <div class="row mb-3">
                                <div class="col-lg-2">
                                    <label for="txtFromDate" class="col-form-label">From Date(MMDDYYYY) :</label>
                                </div>
                                <div class="col-lg-4">
                                    <input type="text" id="txtFromDate" class="txtDates" />
                                </div>
                                <div class="col-lg-2">
                                    <label for="txtToDate" class="col-form-label">To Date(MMDDYYYY) :</label>
                                </div>
                                <div class="col-lg-4">
                                    <input type="text" id="txtToDate" class="txtDates" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-12 text-center">
                                    <input type="button" id="btnCheckEligibility" onclick="checkEligibility();" value="Check Eligibility" />
                                    <input type="button" id="btnClearForm" onclick="ClearForm();" value="Clear Form" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnErrorMessage" runat="server" Value="1" />
    <div id="divPatients" style="display: none;">
    </div>
</asp:Content>
