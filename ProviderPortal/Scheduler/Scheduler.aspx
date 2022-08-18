<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Scheduler.aspx.cs" Inherits="ProviderPortal_Scheduler_Scheduler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!--Start Calander Stuff, dont remove these files, even jquery files.-->


    <link href="../../StyleSheets/jquery.weekcalendar.css" rel="stylesheet" />
    <link href="../../StyleSheets/default.css" rel="stylesheet" />
    <link href="../../StyleSheets/gcalendar.css" rel="stylesheet" />
    <link href="../../StyleSheets/adminCalander.css" rel="stylesheet" type="text/css" />
    <link href="../../StyleSheets/hint.css" rel="stylesheet" />
    <link href="../../StyleSheets/slide.css" rel="stylesheet" />
    <%--<script src='<%= ResolveUrl("~/Scripts/jquery-1.8.2.js") %>' type="text/javascript"></script>--%>
    <script src="../../Scripts/UI/JqueryUI.js" type="text/javascript"></script>
    <script src="../../Scripts/date.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.weekcalendar.js"></script>
    <script src="../../Scripts/admin-calendar.js" type="text/javascript"></script>
    <!--End Calander Stuff, dont remove these files, even jquery files.-->
    
    <!--Start Upload Stuff.-->
    <link href="../../StyleSheets/customFileUpload.css" rel="stylesheet" type="text/css" />
    <%--<script src="../Scripts/ajaxupload.js" type="text/javascript"></script>--%>
    <!--End Upload Stuff.-->
    
    <!--Start Patient Stuff.-->
    <link href="../../StyleSheets/PatientsStyle.css" rel="stylesheet" type="text/css" />
    <!--End Patient Stuff.-->
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
    <link href="../../StyleSheets/Master.css" rel="stylesheet" />
    <script src='<%= ResolveUrl("~/Scripts/jquery.maskedinput.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Scripts/Eligibility.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Scripts/SuperBill.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Scripts/CheckInForm.js") %>' type="text/javascript"></script>

    <script src='<%= ResolveUrl("~/Scripts/dynamsoft.webtwain.initiate2.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Scripts/dynamsoft.webtwain.initiate.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Scripts/dynamsoft.webtwain.config.js") %>' type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {

            if (!checkModuleRights("Scheduler")) {

                $("[id$='divRightsSettings']").html("You don't have rights to View Scheduler").show();
                $("#ContentMaindiv").hide();
                return false;
            }

            HomeInitialization();
            $("#_Scheduler").addClass("active");
            $(".down_arrow").addClass("scheduler_down_arrow_setting");
        });
        
        function HomeInitialization() {
            debugger;
            $("[id$='txtAppointmentDateMain']").datepicker({
                showOn: "button",
                buttonImage: "../../Images/calendar.gif",
                //dateFormat: "yyyy-mm-dd",
                changeYear: true,
                yearRange: "-10:+2",
                changeMonth: true,
                onSelect: function () {
                    var dateObject = $(this).datepicker('getDate');
                    $("#calendar").weekCalendar("gotoDate", dateObject);
                    $("#calendar").weekCalendar('refresh');
                }
            });

            $("[id$='txtAppointmentDateMain']").val(CurrentSystemDate());

            $("[id$='lnkSchedular']").css("font-weight", "bold");
            $(".span-schedular-sprite").removeClass("span-home-sprite-disabled").addClass("span-home-sprite-Active");
            $(".span-dashboard-sprite").removeClass("span-home-sprite-Active").addClass("span-home-sprite-disabled");
            $(".span-appointments-sprite").removeClass("span-home-sprite-Active").addClass("span-home-sprite-disabled");
            $(".span-reports-sprite").removeClass("span-home-sprite-Active").addClass("span-home-sprite-disabled");

            var AppointmentLeftMainHeight = $(document).height() - $("#calendar").offset().top - 90;
            $("[id$='divAppointmentLeftMainContents']").css("height", AppointmentLeftMainHeight);
        }

        function resetPatiantAddForm() {
            $("#divWarning").css("display", "none");

            $(".patiant-add-wrapper input[type='text']").each(function () {
                $(this).val("");
                if ($(this).hasClass("emptyInput")) {
                    $(this).removeClass("emptyInput")
                }
            });
        }


        function viewPatientRequests(patientid) {
            window.open(_EMRPath + "/Patient/Demographics.aspx?PatientId=" + patientid + "&InfoType=RefillRequests", '_blank');
        }

        function closeRefillRequests() {
            $("[id$='divRefillRequests']").hide();
        }

        function SetPatientInformation(objPatient) {
            $("[id$='hdnPatientId']").val(objPatient.PatientId);
            _PatientId = objPatient.PatientId;

            if (_PatientId == 0) {
                return;
            }

            var PatientWrapper = $("[id$='divAppointmentPatient']");

            var PatientName = objPatient.LastName + " " + objPatient.FirstName;

            var DateOfBirth = "";

            if (objPatient.DateOfBirth != "") {
                DateOfBirth = objPatient.DateOfBirth + ", ";
            }

            var GenderMaritalStatus = objPatient.Gender + ", " + objPatient.MaritalStatus;

            /*Start Phone Number*/
            var Phone = "", Cell = "", HomePhone = "", WorkPhone = "";

            if (objPatient.Cell != "") {
                Cell = objPatient.Cell + ", ";
            }

            if (objPatient.HomePhone != "") {
                HomePhone = objPatient.HomePhone + ", ";
            }

            if (objPatient.WorkPhone != "") {
                WorkPhone = objPatient.WorkPhone;
            }

            Phone = $.trim(Cell.toString() + HomePhone.toString() + WorkPhone.toString());
            /*End Phone Number*/


            /*Start Address*/
            var PatientAddress = "", City = "", State = "", Zip = "", Address = "";

            if (objPatient.Address != "") {
                Address = objPatient.Address + ", ";
            }

            if (objPatient.City != "") {
                City = objPatient.City + ", ";
            }

            if (objPatient.State != "") {
                State = objPatient.State + ", ";
            }

            if (objPatient.Zip != "") {
                Zip = objPatient.Zip;
            }


            PatientAddress = $.trim(Address.toString() + City.toString() + State.toString() + Zip.toString());
            /*End Address*/

            if (objPatient.ImagePath.indexOf("Patients") == -1) {
          //      objPatient.ImagePath = _PracticeDocumentsPath + "/" + _PracticeId + "/Patients/" + objPatient.PatientId + "/" + objPatient.ImagePath;
            }

            PatientWrapper.find(".imgPatientPhoto").attr("src", objPatient.ImagePath);

            PatientWrapper.find(".spnAccountNo").html(objPatient.PatientId);
            PatientWrapper.find(".spnPatientName").html(PatientName);
            PatientWrapper.find(".spnPatientDOB").html(DateOfBirth);
            PatientWrapper.find(".spnPatientGenderMaritalStatus").html(GenderMaritalStatus);
            PatientWrapper.find(".spnPatientPhone").html(Phone);
            PatientWrapper.find(".spnPatientAddress").html(PatientAddress);
        }

        function ResetPatientInformation() {
            $("[id$='hdnPatientId']").val(0);

            var PatientWrapper = $("[id$='divAppointmentPatient']");

            PatientWrapper.find(".imgPatientPhoto").attr("src", "");
            PatientWrapper.find(".spnAccountNo").html("");
            PatientWrapper.find(".spnPatientName").html("");
            PatientWrapper.find(".spnPatientDOB").html("");
            PatientWrapper.find(".spnPatientGenderMaritalStatus").html("");
            PatientWrapper.find(".spnPatientPhone").html("");
            PatientWrapper.find(".spnPatientAddress").html("");
        }

    </script>
    
    <script type="text/javascript">
        var _objPatientForAppointmentEvent = null;

        function doneAddNewPatient(data, objPatient) {
            var start = data.indexOf("###StartPatientId###") + 20;
            var end = data.indexOf("###EndPatientId###");
            var returnHtml = $.trim(data.substring(start, end));

            if (returnHtml == "PatientExists") {
                showErrorMessage("Patient with given name already exists. Please provide different name.");
                return;
            }

            $("[id$='hdnPatientId']").val(returnHtml);

            var PatientName = objPatient.LastName + " " + objPatient.FirstName;

            try {
                _objPatientForAppointmentEvent = new Object();
                _objPatientForAppointmentEvent.PatientId = $("[id$='hdnPatientId']").val();

                _objPatientForAppointmentEvent.LastName = objPatient.LastName;
                _objPatientForAppointmentEvent.FirstName = objPatient.FirstName;
                _objPatientForAppointmentEvent.DateOfBirth = objPatient.DateOfBirth;
                _objPatientForAppointmentEvent.Gender = objPatient.Gender;
                _objPatientForAppointmentEvent.MaritalStatus = "";
                _objPatientForAppointmentEvent.Cell = objPatient.Cell;
                _objPatientForAppointmentEvent.HomePhone = "";
                _objPatientForAppointmentEvent.WorkPhone = "";
                _objPatientForAppointmentEvent.City = objPatient.City;
                _objPatientForAppointmentEvent.State = objPatient.State;
                _objPatientForAppointmentEvent.Zip = objPatient.Zip;
                _objPatientForAppointmentEvent.Address = objPatient.Address;
                _objPatientForAppointmentEvent.ImagePath = "";

                SetPatientInformation(_objPatientForAppointmentEvent);
            } catch (ex) {
            }

            ClosePatientPopUp();
        }

        function FilterPatientAppointmentBox() {
            debugger
            var AppointmentContainer = $("[id$='divAppointmentContainer']");

            var LastName = $.trim(AppointmentContainer.find("input[name='txtLastName']").val());
            var FirstName = $.trim(AppointmentContainer.find("input[name='txtFirstName']").val());
            var Phone = $.trim(AppointmentContainer.find("input[name='txtPhone']").val());

            if (LastName == "" && FirstName == "" && Phone == "") {
                $("#divPatientSearchResults").hide();
                return;
            }

            var params = {
                LastName: LastName,
                FirstName: FirstName,
                Phone: Phone
            };

            $.post("../../ProviderPortal/Controls/PatientBoxSearch.aspx", params, function (data) {
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                var returnHtml = $.trim(data.substring(start, end));

                $("#tbodyPatientSearchResults").html(returnHtml).promise().done(function () {
                    //ShowHideDentalServiceSearchResults(true);
                    $("#divPatientSearchResults").show();
                });
            });
        }

        function ClickPatientBoxSearchRow(elem, event) {
            debugger;
            var CurrentRow = $(elem).closest("tr");
            var DeathDate = $.trim(CurrentRow.find(".hdnPatientDeathDate").val());

            $("[id$='divAppointmentContainer'] input[type='text']").val("");

            if (DeathDate != "" && isDate(DeathDate)) {
                showErrorMessage("Sorry! the patient is not alive. you cannot create appointment.");
                return false;
            }
            $("#divPatientSearchResults").css("display", "none");
            _objPatientForAppointmentEvent = new Object();

            _objPatientForAppointmentEvent.PatientId = CurrentRow.find(".hdnPatientId").val();

            _objPatientForAppointmentEvent.LastName = $.trim(CurrentRow.find(".hdnLastName").val());
            _objPatientForAppointmentEvent.FirstName = $.trim(CurrentRow.find(".hdnFirstName").val());
            _objPatientForAppointmentEvent.DateOfBirth = $.trim(CurrentRow.find(".hdnDateOfBirth").val());
            _objPatientForAppointmentEvent.Gender = $.trim(CurrentRow.find(".hdnGender").val());
            _objPatientForAppointmentEvent.MaritalStatus = $.trim(CurrentRow.find(".hdnMaritalStatus").val());
            _objPatientForAppointmentEvent.Cell = $.trim(CurrentRow.find(".hdnCell").val());
            _objPatientForAppointmentEvent.HomePhone = $.trim(CurrentRow.find(".hdnHomePhone").val());
            _objPatientForAppointmentEvent.WorkPhone = $.trim(CurrentRow.find(".hdnWorkPhone").val());
            _objPatientForAppointmentEvent.City = $.trim(CurrentRow.find(".hdnCity").val());
            _objPatientForAppointmentEvent.State = $.trim(CurrentRow.find(".hdnState").val());
            _objPatientForAppointmentEvent.Zip = $.trim(CurrentRow.find(".hdnZip").val());
            _objPatientForAppointmentEvent.Address = $.trim(CurrentRow.find(".hdnAddress").val());
            _objPatientForAppointmentEvent.ImagePath = $.trim(CurrentRow.find(".hdnImagePath").val());

            SetPatientInformation(_objPatientForAppointmentEvent);
        }

        function UpdateCalEventLocally(calEvent) {
            debugger;
            if (_objPatientForAppointmentEvent == null) {
                return calEvent;
            }

            calEvent.PatientId = _objPatientForAppointmentEvent.PatientId;

            calEvent.LastName = _objPatientForAppointmentEvent.LastName;
            calEvent.FirstName = _objPatientForAppointmentEvent.FirstName;
            calEvent.DateOfBirth = _objPatientForAppointmentEvent.DateOfBirth;
            calEvent.Gender = _objPatientForAppointmentEvent.Gender;
            calEvent.MaritalStatus = _objPatientForAppointmentEvent.MaritalStatus;
            calEvent.Cell = _objPatientForAppointmentEvent.Cell;
            calEvent.HomePhone = _objPatientForAppointmentEvent.HomePhone;
            calEvent.WorkPhone = _objPatientForAppointmentEvent.WorkPhone;
            calEvent.City = _objPatientForAppointmentEvent.City;
            calEvent.State = _objPatientForAppointmentEvent.State;
            calEvent.Zip = _objPatientForAppointmentEvent.Zip;
            calEvent.Address = _objPatientForAppointmentEvent.Address;
            calEvent.ImagePath = _objPatientForAppointmentEvent.ImagePath;

            return calEvent;
        }

        function SetAppointmentFormBeforeOpen(calEvent) {
            debugger;
            _objPatientForAppointmentEvent = null;
            resetForm($dialogContent);

            if (calEvent.PatientId == 0 || calEvent.PatientId == "" || calEvent.PatientId == undefined) {
                SetBookingReferenceNo(calEvent);
                EnableDisableAppointmentFilterFields(false);

                SetAppointmentForm(calEvent);
            }
            else {
                SetPatientInformation(calEvent);
                EnableDisableAppointmentFilterFields(true);
            }

            SetCalEventRecurrenceSection(calEvent);
        }

        function SetReferenceNo(ReferenceNo) {
            ReferenceNo = $.trim(ReferenceNo);

            $("[id$='spnReferenceNoAppointmentForm']").html(ReferenceNo);
        }
    </script>
    
    <script type="text/javascript">
        function UpdateAppointmentAndCheckedInPatientListOnWalkout(AppointmentsId) {
            var CurrentRowCheckedInPatient = $("#tblCheckedInPatients :hidden[value='" + AppointmentsId + "']").closest(".tr-checkedin-Patients-main");
            var CurrentAppointmentBox = $("#calendar .wc-cal-event .hdnEventId[value='" + AppointmentsId + "']").closest(".wc-cal-event");

            var CheckInRoomId = 0;
            var StatusId = 5;
            var elem = CurrentAppointmentBox.find(".custom-dropdown-list tbody")[0];
            var appStatus = "Completed";
            var isExpireTime = false;
            var PatientId = _PatientId;

            AppointmentUpdateStatus(AppointmentsId, CheckInRoomId, StatusId, elem, appStatus, isExpireTime, PatientId);
        }
    </script>
    
    <script type="text/javascript">
        function SetAppointmentLegends() {
            debugger
            $("[id$='ulAppointmentStatusLegend']").html("");
            $("[id$='ulAppointmentReasonLegend']").html("");

            var allEvents = $calendar.weekCalendar("serializeEvents");

            $("[id$='spnTotalAppointments']").html("(" + allEvents.length + ")");

            for (var i = 0; i < allEvents.length; i++) {
                var CurrentAppointmentStatusColor = allEvents[i].status_back_color;
                var CurrentAppointmentStatus = allEvents[i].status;

                AppendAppointmentStatusLegendRow(CurrentAppointmentStatusColor, CurrentAppointmentStatus);

                var CurrentAppointmentReasonColor = allEvents[i].reason_back_color;
                var ReasonId = allEvents[i].reasonId;
                var CurrentAppointmentReason = $.trim($("[id$='ddReason'] option[value='" + ReasonId + "']").html());

                if (CurrentAppointmentReason != "") {
                    AppendAppointmentReasonLegendRow(CurrentAppointmentReasonColor, CurrentAppointmentReason);
                }
            }
        }

        function AppendAppointmentStatusLegendRow(CurrentAppointmentStatusColor, CurrentAppointmentStatus) {
            var CurrentAppointmentStatusClass = CurrentAppointmentStatus.replace(/\s/g, "");

            if ($("[id$='ulAppointmentStatusLegend']").find("li." + CurrentAppointmentStatusClass).length > 0) {
                var Count = $.trim($("[id$='ulAppointmentStatusLegend']").find("li." + CurrentAppointmentStatusClass + " .span-count").html());
                Count = Count.replace("(", "").replace(")", "");
                Count++;
                $("[id$='ulAppointmentStatusLegend']").find("li." + CurrentAppointmentStatusClass + " .span-count").html("(" + Count + ")")

                return;
            }

            var li = '' +
                '<li class="' + CurrentAppointmentStatusClass + '">' +
                    '<span class="span-color-box" style="background-color: ' + CurrentAppointmentStatusColor + '"></span>' +
                    '<span class="span-color-desc">' + CurrentAppointmentStatus + '</span>' +
                    '<span class="span-count notification-text" style="margin: 0;">(1)</span>' +
                '</li>';

            $("[id$='ulAppointmentStatusLegend']").append(li);
        }

        function AppendAppointmentReasonLegendRow(CurrentAppointmentReasonColor, CurrentAppointmentReason) {
            var CurrentAppointmentReasonClass = CurrentAppointmentReason.replace(/\s/g, "");

            if ($("[id$='ulAppointmentReasonLegend']").find("li." + CurrentAppointmentReasonClass).length > 0) {
                var Count = $.trim($("[id$='ulAppointmentReasonLegend']").find("li." + CurrentAppointmentReasonClass + " .span-count").html());
                Count = Count.replace("(", "").replace(")", "");
                Count++;
                $("[id$='ulAppointmentReasonLegend']").find("li." + CurrentAppointmentReasonClass + " .span-count").html("(" + Count + ")")

                return;
            }

            var li = '' +
                '<li class="' + CurrentAppointmentReasonClass + '">' +
                    '<span class="span-color-box" style="background-color: ' + CurrentAppointmentReasonColor + '"></span>' +
                    '<span class="span-color-desc">' + CurrentAppointmentReason + '</span>' +
                    '<span class="span-count notification-text" style="margin: 0;">(1)</span>' +
                '</li>';

            $("[id$='ulAppointmentReasonLegend']").append(li);
        }

        function HideShowMultiCheckDropDown(elem) {
            var dropdownDivMainWrapper = $(elem).closest(".dropdownMenuMultiCheckMainWrapper");

            if (dropdownDivMainWrapper.find(".divMultiCheckInsideDropdown").length == 0) {
                return;
            }

            dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").slideToggle();
        }

        function OkMultiCheckDropDown(elem) {
            debugger;
            var dropdownDivMainWrapper = $(elem).closest(".dropdownMenuMultiCheckMainWrapper");
            dropdownDivMainWrapper.find(".dropdownMenuMultiCheck").slideToggle();

            RefreshAppointmentCalendar();
        }

        function SetSelectedServiceProviders() {
            var ServiceProviders = "";
            _PracticeStaffIds = "";
            _arrUsers = new Array();

            $(".cbServiceProviders:checked").each(function () {
                var ServiceProvider = $.trim($(this).parent().find(".spnServiceProviders").html());
                ServiceProviders += ServiceProvider + ", ";
                _arrUsers.push(ServiceProvider);

                var StaffId = $.trim($(this).parent().find(".hdnPracticeStaffId").val());
                _PracticeStaffIds += StaffId + ",";
            });

            if (ServiceProviders.length > 2) {
                ServiceProviders = ServiceProviders.substring(0, ServiceProviders.length - 2);
                _PracticeStaffIds = _PracticeStaffIds.substring(0, _PracticeStaffIds.length - 1);
            }

            $("[id$='lblServiceProviders']").html(ServiceProviders).attr("title", ServiceProviders);
        }

    </script>
    
    <style type="text/css">
        #calendar
        {
            -webkit-touch-callout: none;
            -webkit-user-select: none;
            -khtml-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
        .patient-select
        {
            padding: 4px !important;
        }
        
        .datepickerContainer button
        {
            background: none !important;
            border: none !important;
            padding: 0 0 0 4px !important;
        }
        #divPatientSearchResults tr
        {
            cursor:pointer;
        }
        .ui-dialog
        {
            top: 110px !important;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%--<QL:QuickLaunchBar ID="QuickLaunchBar1" runat="server" />--%>
    <div class="page-content">
        <div id="divTabWrapper">
            <div style="float: left;" id="divSchedular">
                <table>
                    <tr>
                        <td style="width: 20%; vertical-align: top;background-color: #F2F2F2;" >
                            <div class="Widget" id="divAppointmentLeftMain" style="box-shadow: 0 0;">
                                <div class="fixed-link-title" style="font-weight: bold;">
                                    Appointment Filter
                                    <span id="spnTotalAppointments" class="notification-text" style="margin: 0;"></span>
                                
                                </div>
                                <div class="WidgetContent" id="divAppointmentLeftMainContents" style="padding: 10px 6%;
                                    width: 88%; overflow-y: auto;">
                                    <div id="calendar_selection" class="ui-corner-all">
                                        <div class="calendar-selection-inner">
                                            <h3>
                                                Select Location:
                                            </h3>
                                            <asp:DropDownList ID="ddLocationMain" runat="server" CssClass="SelectAppointment"
                                                onchange="locationChanged();">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="calendar-selection-inner">
                                            <h3>
                                                Select Provider:
                                            </h3>
                                            <div class="dropdownMenuMultiCheckMainWrapper" style="position: relative;">
                                                <select></select>
                                                <div onclick="HideShowMultiCheckDropDown(this);" style="position: absolute; left: 0; top: 0; height: 25px; width: 100%;">
                                                    <span id="lblServiceProviders" class="custom-drop-down-label"></span>
                                                </div>
                                                <div id="divServiceProvidersDropDown" class="dropdownMenuMultiCheck" style="top: 25px;
                                                    width: 100%;">
                                                    <div class="div-drop-down">
                                                        <asp:Repeater runat="server" ID="rptServiceProviders">
                                                            <ItemTemplate>
                                                                <div class="divMultiCheckInsideDropdown">
                                                                    <label>
                                                                        <input type="checkbox" class="cbServiceProviders" checked="checked" />
                                                                        <span class="spnServiceProviders">
                                                                            <%#Eval("Name")%>
                                                                        </span>
                                                                        <input type="hidden" class="hdnPracticeStaffId" value='<%#Eval("PracticeStaffId") %>' />
                                                                    </label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                    <div class="divBottom">
                                                        <input type="button" onclick="OkMultiCheckDropDown(this);" value="OK" style="font-size: 10px; min-width: 65px;" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="calendar-selection-inner">
                                            <h3>
                                                Select Date:
                                            </h3>
                                            <div class="datepickerContainer">
                                                <input type="text" disabled="disabled" id="txtAppointmentDateMain" style="width: 82%;" />
                                                <%--<div id="txtAppointmentDateMain" style="font-size: 90%;"></div>--%>
                                            </div>
                                        </div>
                                        <div class="calendar-selection-inner refresh" id="AppointmentStatusLegend" >
                                            <h3>
                                                Appointment Status Legend:
                                            </h3>
                                            <div class="appointment-legend-div">
                                                <ul id="ulAppointmentStatusLegend" class="ul-legends"></ul>
                                            </div>
                                        </div>
                                        <div class="calendar-selection-inner refresh" id="AppointmentReasonLegend">
                                            <h3>
                                                Appointment Reason Legend:
                                            </h3>
                                            <div class="appointment-legend-div">
                                                <ul id="ulAppointmentReasonLegend" class="ul-legends"></ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                       
                         <td style="vertical-align: top; width:80%;">
                             <%-- jump --%>
                            <div id="calendar"></div>
                            <div id="divWindowBottom"></div>
                        </td>
                    </tr>
                </table>
                <div id="divAppointmentContainer">
                    <div style="width: 700px;">
                        <div class="widget-sections appointment-upper">
                            <table>
                                <tr>
                                    <td>
                                        <input type="checkbox" id="chkBookAppointment" name="chkBookAppointment" onchange="ClickBookingReferenceNo(this);" />
                                    </td>
                                    <td>
                                        Book Time Slot:
                                    </td>
                                    <td colspan="2">
                                        <input type="text" id="txtBookingReferenceNo" name="txtBookingReferenceNo" placeholder="Booking Reference #" onkeyup="SetReferenceNo(this.value);" disabled="disabled" />
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        Search Patient:
                                    </td>
                                    <td style="position:relative;">
                                        <input type="text" name="txtLastName" placeholder="Last Name" onkeyup="FilterPatientAppointmentBox();" />
                                          <div id="divPatientSearchResults" class="divSearchResults" style="width:540px; box-shadow: 0 0 5px;">
                                            <table class="Grid">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 180px;">
                                                            Last Name
                                                        </th>
                                                        <th style="width: 176px;">
                                                            First Name
                                                        </th>
                                                        <th>
                                                            Phone #
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="tbodyPatientSearchResults"></tbody>
                                            </table>
                                        </div>
                                      
                                    </td>
                                    <td>
                                        <input type="text" name="txtFirstName" placeholder="First Name" onkeyup="FilterPatientAppointmentBox();" />
                                    </td>
                                    <td>
                                        <input type="text" name="txtPhone" placeholder="Phone #" onkeyup="FilterPatientAppointmentBox();" />
                                    </td>
                                    <td style="display:none">
                                        <span class="pt-search ui-icon ui-icon-search" onclick="openPatiantSearch();" style="display:none;"></span>
                                        <span class="pt-add ui-icon ui-icon-plus" onclick="NewPatientPopUp();"></span>
                                    </td>
                                </tr>
                            </table>
                            
                        </div>
                        <div class="widget-sections appointment-lower">
                            <table>
                                <tr>
                                    <td valign="top" style="width: 50%;">
                                        <div class="float-left-100">
                                            <div id="divAppointmentBookingReferenceNo" style="display:none;">
                                                <span>Reference No.</span>
                                                <span id="spnReferenceNoAppointmentForm"></span>
                                            </div>
                                            <div id="divAppointmentPatient">
                                                <div class="patient-info-wrapper">
                                                    <div class="patient-photo-wrapper">
                                                        <img alt="" class="imgPatientPhoto" />
                                                    </div>
                                                    <div class="patient-information">
                                                        <ul>
                                                            <li>
                                                                <span class="gray Bold">Account No:</span>
                                                                <span class="spnAccountNo"></span>
                                                            </li>
                                                            <li>
                                                                <span class="spnPatientName Bold"></span>
                                                            </li>
                                                            <li>
                                                                <span class="spnPatientDOB"></span>
                                                                <span class="spnPatientGenderMaritalStatus"></span>
                                                            </li>
                                                            <li>
                                                                <span class="spnPatientPhone"></span>
                                                            </li>
                                                            <li>
                                                                <span class="spnPatientAddress"></span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="float-left-100">
                                            <table>
                                                <tr>
                                                    <td>
                                                        Appointment Reason:<span class="spnError">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddReason" runat="server" onchange="reasonChange(this);" CssClass="SelectAppointment required"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="padding: 10px 0 0;">
                                                        Notes:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <textarea cols="20" rows="5" id="taNotes" style="width: 96%; height: 76px;"></textarea>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td>
                                                    Start Time:
                                                </td>
                                                <td>
                                                    <select name="start" class="SelectAppointment" id="startTime">
                                                        <option value="">Select Start Time</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    End Time:
                                                </td>
                                                <td>
                                                    <select name="end" class="SelectAppointment" id="endTime">
                                                        <option value="">Select End Time</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Status:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddAppStatus" runat="server" CssClass="SelectAppointment"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Provider:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddDialogAppProvider" runat="server" CssClass="SelectAppointment" Enabled="false"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div class="float-left-100" style="margin: 10px 0 5px;">
                                                        <label>
                                                            <input type="checkbox" id="chkIsRecurrence" onclick="ClickRecurrenceAppointment(this);" style="float: left;" />
                                                            <span style="float: left; margin: 3px 0 0 0;">Recurrence Appointment</span>
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div class="float-left-100 appointment-repeat" style="margin: 0 0 5px;">
                                                        <table border="1">
                                                            <tbody id="tbodyRecurrenceDays">
                                                                <tr>
                                                                    <td>
                                                                        Mon
                                                                    </td>
                                                                    <td>
                                                                        Tue
                                                                    </td>
                                                                    <td>
                                                                        Wed
                                                                    </td>
                                                                    <td>
                                                                        Thu
                                                                    </td>
                                                                    <td>
                                                                        Fri
                                                                    </td>
                                                                    <td>
                                                                        Sat
                                                                    </td>
                                                                    <td>
                                                                        Sun
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <input type="checkbox" id="chkReapetMonday" disabled="disabled" />
                                                                        <input type="hidden" id="hdnReapetMonday" value="Monday" />
                                                                    </td>
                                                                    <td>
                                                                        <input type="checkbox" id="chkReapetTuesday" disabled="disabled" />
                                                                        <input type="hidden" id="hdnReapetTuesday" value="Tuesday" />
                                                                    </td>
                                                                    <td>
                                                                        <input type="checkbox" id="chkReapetWednesday" disabled="disabled" />
                                                                        <input type="hidden" id="hdnReapetWednesday" value="Wednesday" />
                                                                    </td>
                                                                    <td>
                                                                        <input type="checkbox" id="chkReapetThursday" disabled="disabled" />
                                                                        <input type="hidden" id="hdnReapetThursday" value="Thursday" />
                                                                    </td>
                                                                    <td>
                                                                        <input type="checkbox" id="chkReapetFriday" disabled="disabled" />
                                                                        <input type="hidden" id="hdnReapetFriday" value="Friday" />
                                                                    </td>
                                                                    <td>
                                                                        <input type="checkbox" id="chkReapetSaturday" disabled="disabled" />
                                                                        <input type="hidden" id="hdnReapetSaturday" value="Saturday" />
                                                                    </td>
                                                                    <td>
                                                                        <input type="checkbox" id="chkReapetSunday" disabled="disabled" />
                                                                        <input type="hidden" id="hdnReapetSunday" value="Sunday" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <span style="float:left; margin: 7px 10px 0 0;">For:</span>
                                                    <select id="ddlRecurrenceFrequency" disabled="disabled" style="width: 50px; margin: 0 8px 0 0;">
                                                        <option value="1">1</option>
                                                        <option value="2">2</option>
                                                        <option value="3">3</option>
                                                        <option value="4">4</option>
                                                        <option value="5">5</option>
                                                        <option value="6">6</option>
                                                        <option value="7">7</option>
                                                        <option value="8">8</option>
                                                        <option value="9">9</option>
                                                        <option value="10">10</option>
                                                    </select>
                                                    
                                                    <select id="ddlRecurrenceUnit" disabled="disabled" style="width: 80px;">
                                                        <option value="Week">Week</option>
                                                        <option value="Month">Month</option>
                                                    </select>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Div of patient which is showing in bottom left --%>
    <div id="divRefillRequests" style="position: fixed; display:none; width: 400px; max-height: 200px; bottom: 0px; right: 20px; line-height: 20px; margin-bottom: 5px; z-index: 1000; background-color: #AADEFF;">
        <div> 
            <div style="height: 20px; margin: 5px; color: #000; font-weight: bold; border-radius: 2px;padding-left: 5px; background-color: #f5f5f5;">
                <span style="float: left">Patient Refill Requests</span> <span class="spandelete" onclick="closeRefillRequests();" style="float: right; padding-left: 0px; padding-right: -5px;"></span>
            </div>
            <div class="Grid" style="width: 97%; margin-left: 5px; max-height: 150px; background-color: #fff;overflow-y: auto; margin-bottom: 5px;">
                <table>
                    <thead>
                        <tr>
                            <th>
                                Patient Id
                            </th>
                            <th>
                                Patient
                            </th>
                            <th>
                                Total Requests
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptRefillRequests" runat="server">
                            <ItemTemplate>
                                <tr onclick="viewPatientRequests(<%# Eval("PatientId")%>)" style="cursor:pointer">
                                    <td><%# Eval("PatientId")%></td>
                                    <td><%# Eval("Patient")%></td>
                                    <td><%# Eval("RequestsCount")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div id="divDialogMedicalHistory" style="display: none; overflow-y: auto !important; padding: 0;"></div>
    <div id="divPopupPatient" title="Patient Search" style="display:none;"></div>

    <div id="divContextMenuAppointments" class="context-menu" style="width: 130px; top: 476px;
        left: 490px; display: none;">
        <ul>
            <li onclick="CreatAppointmentFromMenu(this);">
                <a href="javascript:void(0);" id="linkCreateAppointment">Create Appointment</a>
            </li>
            <li onclick="CopyAppointment(this);"><a href="javascript:void(0);" id="linkCopyAppointment"
                class="disable-context-menu-item">Copy</a></li>
            <li onclick="PasteAppointment(this);"><a href="javascript:void(0);" id="linkPasteAppointment"
                class="disable-context-menu-item">Paste</a></li>
        </ul>
    </div>
    <div id="divDialogPracticeRoomsMaster" style="display: none;">
        <table>
            <tr>
                <td style="width: 90px;">
                    Select Room:<span class="spnError">*</span>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlPracticeRooms" CssClass="required"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div id="divAppointmentDetailMain" class="appointment-details-div" style="display: none;">
        <div id="divAppointmentDetailInner"></div>
        <div id="divAppointmentDetailProcessing">
            <img />
        </div>
    </div>

    <div id="divCustomLoading" class="custom-loading-1" style="display:none;">Loading...</div>
    <div id="divPatientBalanceSheet" title="Patient Balance Sheet" style="display:none;"></div>
    
    <div id="divDialogBookingReferenceNo" style="display: none;">
        <div class="float-left-100">
            <table>
                <tr>
                    <td>
                        Reference No.
                    </td>
                    <td>
                        
                    </td>
                </tr>
            </table>
        </div>
        <div class="dialog-action-bar-bottom">
            <input type="button" value="Cancel" onclick="CloseBookingReferenceNoDialog();" />
            <input type="button" value="Ok" onclick="OkBookingReferenceNo();" />
        </div>
    </div>

    <input type="hidden" id="hdnPatientId" value="0" />

    <div id="NewPatientPopUp"></div>

    <div id="dialog-confirm-app-delete" title="Delete appointment?" style="display: none;">
        <p>
            Please mention the reason for appointment deletion.(Optional)
            <br />
            (Upto 200 characters.)
        </p>
        <textarea id="txtAppointmentDeletionReason" maxlength="200" style="width: 98%; height: 75px;
            overflow-y: auto;"></textarea>
    </div>
</asp:Content>
