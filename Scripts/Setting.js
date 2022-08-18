/// <reference path="../ProviderPortal/UserRights/UserRoles.aspx" />
/// <reference path="../ProviderPortal/UserRights/UserRoles.aspx" />
/// <reference path="../ProviderPortal/UserRights/UserRoles.aspx" />


var _LocationId = 0;

var _msg_UserRightView = "You Dont have Right to View Data";
var _msg_PracticeUserView = "You don't have rights to View Practice User";


/******************************************Service Provider************************/
var _ServiceProviderId = 0;
var _imgPath = "";
var _IsImageChange = false;
var _IsTimingChanged = false;
var _InsuranceId = 0;
var _InsuranceEditCallFrom = "";
var _SettingsPath = "/ProviderPortal/Settings";

function showServiceProviders() {
    $("#divRightsSettings").hide();
    $(".setting-content-wrapper").hide();
    $("#divMesg").hide();
    
    $(".contents-details-header").html("Service Providers");
    if (!checkModuleRights("ServiceProvidersView")) {
        $("[id$='divRightsSettings']").html(_msg_ServiceProviderView).show();
        return false;
    }
    
    LoadProviders();
}

function LoadProviders() {
    if ($.trim($("#divServiceProviderMain").html()).length == 0) {
        $.post(_SettingsPath + "/CallBacks/ServiceProviders.aspx", {}, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartServiceProvider###") + 26;
            var end = data.indexOf(" ###EndServiceProvider###");
            $("#divServiceProviderMain").html(returnHtml.substring(start, end)).show();
        });
    }
    else {
        $("#divServiceProviderMain").show();
    }
}

function viewserviceProviders(trId, serviceProviderId) {
    _ServiceProviderId = serviceProviderId;
    
    $.post(_SettingsPath + "/CallBacks/ServiceProviderDetails.aspx", { PhysicianId: _ServiceProviderId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartServiceProviderDetails###") + 33;
        var end = data.indexOf("###EndServiceProviderDetails###");
        $("#divServiceProviderDetailsParent").html(returnHtml.substring(start, end));

        $("#divPoviders").hide();
        $("#divServiceProviderDetailsParent").show();
    });
}

function backProvider_Click() {
    $("#divServiceProviderDetailsParent").hide();
    $("#divPoviders").show();
    $("#divMesg").hide();
}

var minDate = $("[id$='hdnCurrentDate']").val();

function ShowHideProviderTabs(tab) {
    if (tab == 'Appointments') {
        $('#divProviderTimings').hide();
        $('#divAppointments').show();
    }
    else if (tab == 'ProviderTimings') {
        $('#divAppointments').hide();
        $('#divProviderTimings').show();
    }
}

function editServiceProviderDetails_Click() {
    if (checkModuleRights("ServiceProvidersEdit")) {
        AddNewServiceProvider_Click("EditFromDetails");
    } else {
        $("[id$='divRightsSettings']").html(_msg_ServiceProviderEdit).show();
    }
}

function editServiceProviderDetailsGrid(serviceProviderId) {
    if (checkModuleRights("ServiceProvidersEdit")) {
        _ServiceProviderId = serviceProviderId;
        AddNewServiceProvider_Click("EditFromGrid");
    }
    else {
        $("[id$='divRightsSettings']").html(_msg_ServiceProviderEdit).show();
        return false;
    }
}

function AddNewServiceProvider_Click(callFrom) {

    if (callFrom == "New") {
        if (!checkModuleRights("ServiceProvidersAdd")) {
            $("[id$='divRightsSettings']").html(_msg_ServiceProviderAdd).show();
            return false;
        }
        _ServiceProviderId = 0;
    }
    else {
        if (!checkModuleRights("ServiceProvidersEdit")) {
            $("[id$='divRightsSettings']").html(_msg_ServiceProviderEdit).show();
            return false;
        }
    }

    $.post(_SettingsPath + "/CallBacks/AddEditServiceProvider.aspx", { ServiceProviderId: _ServiceProviderId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartAddEditProvider###") + 26;
        var end = data.indexOf("###EndAddEditProvider###");
        $("#divServiceProviderAddEdit").html(returnHtml.substring(start, end));
        $("#divPoviders").hide();
        $("#divServiceProviderDetailsParent").hide();
        $("#divServiceProviderAddEdit").show();

        if (callFrom == "New" || callFrom == "EditFromGrid") {
            $("#btnCancelProvider").show();
            $("#btnBackProvider").hide();
        }
        else if (callFrom == "EditFromDetails") {
            $("#btnCancelProvider").hide();
            $("#btnBackProvider").show();
        }

        if (callFrom != "New") {
            $("[id$='chkProviderStatus']").removeAttr("disabled");
            //$("[id$='spanUserStatus']").show();
            $("[id$='txtProviderPassword']").val($("[id$='hdnPasswordUser']").val());
            $("[id$='txtProviderConfirmPassword']").val($("[id$='hdnPasswordUser']").val());
        }
    });
}

function backProvider_click() {
    $("#divPoviders").hide();
    $("#divServiceProviderAddEdit").hide();
    $("#divServiceProviderDetailsParent").show();
    $("#divMesg").hide();
}



function loadPhysicainInfo() {
    if (!checkModuleRights("ServiceProvidersView")) {
        $("[id$='divRightsSettings']").html(_msg_ServiceProviderView).show();
        return false;
    }
    $("[id$='lblPhysicianName']").text($("[id$='txtFirstName']").val() + '' + $("[id$='txtLastName']").val());
    $("[id$='lblPhysicianUpin']").text($("[id$='txtUPN']").val());
    $("[id$='lblPhysicianNpi']").text($("[id$='txtNPI']").val());
    $("[id$='lblPhysicianLicenseNo']").text($("[id$='txtLicenseNo']").val());
    $("[id$='lblPhysicianLicenseExpiry']").text($("[id$='txtExpiration']").val());
    $("[id$='lblPhysicianCommunityCareNo']").text($("[id$='txtCommunityCareNo']").val());
    $("[id$='lblPhysicianAddress']").text($("[id$='txtStreetAddress']").val());
    $("[id$='lblPhysicianZipCode']").text($("[id$='txtZip']").val());
    $("[id$='lblPhysicianCity']").text($("[id$='txtCity']").val());
    $("[id$='lblPhysicianState']").text($("[id$='ddlState']").val());
    $("[id$='lblPhysicianPhone']").text($("[id$='txtCell']").val());
    $("[id$='lblPhysicianFax']").text($("[id$='txtFaxNo']").val());
    $("[id$='lblPhysicianContactEmail']").text($("[id$='txtEmail']").val());
}

function isValidEmailAddress(emailAddress) {
    var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    return pattern.test(emailAddress);
}



function DeleteServiceProvider(trId, serviceProviderId) {
    if (!checkModuleRights("ServiceProvidersDelete")) {
        $("[id$='divRightsSettings']").html(_msg_ServiceProviderDelete).show();
        return false;
    }
    $("#dialogconfirmMaster").html("Do you want to delete this provider?");
    $("#dialogconfirmMaster").dialog({
        resizable: false,
        height: 140,
        width: 300,
        modal: true,
        title: 'Confirmation',
        buttons: {
            "Yes": function () {
                $(this).dialog("close");
                $.post(_SettingsPath + "/CallBacks/ServiceProviderHandler.aspx", { ServiceProviderId: serviceProviderId, action: 'Delete Provider' },
                        function () {
                            $(trId).closest("tr").remove();
                            showSuccessMessage("Success: Provider deleted.");
                        });

            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}
function showTitle(id) {
    $(id).attr("title", $(id).text());
}
/******************************************End Service Provider************************/


//******************************************Start Users Sections******************************************/
var _userId = 0;





function PopulateUsers(data) {
    var startIndex = data.indexOf("###StartUsers###") + 16;
    var lastIndex = data.indexOf("###EndUsers###");
    var returnValue = $.trim(data.substring(startIndex, lastIndex));

    $("#divUserAddEdit").hide();
    $("#UsersList").html(returnValue);
    $("#divUsers").show();
    $("#divUsersMain").show();

    GeneratePaging($("[id$='hdnUsersTotalCount']").val(), $("#ddlPagingUsers").val(), "divUsers", "FilterUsers");
    if ($("[id$='hdnUsersTotalCount']").val() > 0) {
        $("#divUsers .spanInfo").html("Showing " + $("#UsersList tr:first").children().first().html() + " to " + $("#UsersList tr:last").children().first().html() + " of " + $("[id$='hdnUsersTotalCount']").val() + " entries");
    }
}



function AddNewUser_Click() {
    if (!checkModuleRights("PracticeUsersAdd")) {
        $("[id$='divRightsSettings']").html(_msg_PracticeUserAdd).show();
        return;
    }

    $(".contents-details-header").html("Practice User");

    $("#divUsers").hide();
    $("#divUserAddEdit").show();
    $("#tblUsers input").val('');
    $("#tblUsers select").val('0');
    $("#chkUserStauts").attr("disabled", "disabled");
    $("[id$='UserImg']").attr("src", _ImagesPath + "/maleIcon.png");
    _userId = 0;
}
function editUser_click(rowId, userId) {
    if (!checkModuleRights("PracticeUsersEdit")) {
        $("[id$='divRightsSettings']").html(_msg_PracticeUserEdit).show();
        return;
    }

    var closestTr = $(rowId).closest("tr");

    _userId = userId;
    $("#txtUserFName").val($.trim(closestTr.find(".userFirstName").html()));
    $("#txtUserMName").val($.trim(closestTr.find(".userMiddleName").html()));
    $("#txtUserLName").val($.trim(closestTr.find(".userLastName").html()));
    $("#txtUserName").val($.trim(closestTr.find(".userName").html()));

    var Password = closestTr.find(".hdnPassword").val();
    $("[id$='txtPassword']").val(Password);
    $("[id$='txtConfirmPassword']").val(Password);

    $("#txtEmail").val($.trim(closestTr.find(".userEmail").html()));
    $("#txtPhone").val($.trim(closestTr.find(".userPhone").html()));

    var PracticeLocationsId = closestTr.find(".hdnPracticeLocationsId").val();
    var ServiceProviderId = closestTr.find(".hdnServiceProviderId").val();

    $("[id$='ddlPracticeLocationsUsers']").val(PracticeLocationsId);
    $("#hdnProviderIdInUser").val(ServiceProviderId);

    var userStatus = $.trim(closestTr.find(".userStatus").html());

    if (userStatus == "Active") {
        $("#chkUserStauts").prop("checked", true);
    }
    else {
        $("#chkUserStauts").prop("checked", false);
    }

    var imgPath = closestTr.find(".hdnPicturePath").val();

    $("[id$='UserImg']").attr("src", _PracticeDocumentsPath + "/" + $("[id$='hdnPracticeId']").val() + "/Users/" + imgPath);
    $("[id$='hdnImageUser']").val(imgPath);

    $("#divUsers").hide();
    $("#divUserAddEdit").show();
}

function cancelSaveUser() {
    $("#divUserAddEdit").hide();
    $(".divMesg").hide();
    $("#divContentsDetails *").removeClass("error");
    $("#divUsers").show();
}

function validateUser() {
    //checkUserExist(_userId, $.trim($("#txtUserName").val()));
}

function deleteUser_click(trId, userId) {
    if (!checkModuleRights("PracticeUsersDelete")) {
        $("[id$='divRightsSettings']").html(_msg_PracticeUserDelete).show();
        return;
    }

    $("#dialogconfirmMaster").html("Do you want to delete this user?");
    $("#dialogconfirmMaster").dialog({
        resizable: false,
        height: 140,
        width: 300,
        modal: true,
        title: 'Confirmation',
        buttons: {
            "Yes": function () {
                $(this).dialog("close");

                $.post(_SettingsPath + "/CallBacks/SettingsHandler.aspx", { UserId: userId, action: 'Delete User' }, function (data) {
                    PopulateUsers(data);
                    showSuccessMessage("Record deleted successfully!");
                });
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}

//******************************************End Users Sections******************************************/



//*****************************Start Practice Timings****************************//
function showProviderTimings() {
    $(".contents-details-header").html('Provider Timings');
    $(".setting-content-wrapper").hide();
    $("#divProviderTimingsMain").show();
    $("[id$='divRightsSettings']").hide();

    if (!checkModuleRights("ProviderTimingsView")) {
        $("[id$='divRightsSettings']").html("You don't have rights to View Practice Staff Timings").show();
        return false;
    }
    
    $('#ddlSelectProvider').removeClass("required error");
    $("#tblPracticeTimeSetting tbody tr select").removeClass("error");
    
    if ($.trim($("#divProviderTimingsMain").html()).length == 0) {
        $.post('CallBacks/ProviderTimingsHandler.aspx', {}, function (data) {
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf("####End####");
            $("#divProviderTimingsMain").html(data.substring(start, end));
            
            $("#divPracticeStaffTimings").show();
            
            InitTimingsDatePicker();
        });
    }
}

function ShowHideTabs(tab) {
    $(".divTabs").hide();
    if (tab == "TransferAppointment") {
        $("#divSchedule").hide();
        $("#cbAppointmentStatus input").prop("checked", false);
    }
    else {
        $("#divSchedule").show();
        $("#divTransferAppointment").hide();
    }
    $("#div" + tab).show();

}

function selectChange(obj) {
    if (obj.selectedIndex == 0) {
        $(obj).parent().closest("tr").find("select").prop('selectedIndex', 0);
        $(obj).parent().closest("tr").find("select").removeClass("error");
    }
    else if (obj.selectedIndex == 1) {
        $(obj).parent().closest("tr").find("select").prop('selectedIndex', 1);
        $(obj).parent().closest("tr").find("td:eq(4) select").prop('selectedIndex', 0);
        $(obj).parent().closest("tr").find("select").removeClass("error");
    }
    else {
        var tdClass = $(obj).parent().attr("class");
        if (tdClass == "tdBasic") {
            var currentIndex = obj.selectedIndex
            $(obj).closest("tr").find("td:eq(2)").find("select").prop('selectedIndex', currentIndex + 32);
            $(obj).closest("tr").find("td:eq(3)").find("select").prop('selectedIndex', currentIndex + 12);
            $(obj).closest("tr").find("td:eq(4)").find("select").prop('selectedIndex', 2);
        }
    }
}
function ddlChange(obj) {
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("ProviderTimingsView")) {
        var resourceProviderId = $("#ddlSelectProvider").val();
        $.post('CallBacks/ProviderTimingsDetailsHandler.aspx', { resourceProviderId: resourceProviderId }, function (data) {
            var start = data.indexOf("####Start####") + 13;
            var end = data.indexOf("####END####");
            $("#divPracticeTimeSettings").html(data.substring(start, end));

            var startProviderTypeTime = data.indexOf("###StartProviderTypeTime###") + 27;
            var endProviderTypeTime = data.indexOf("###EndProviderTypeTime###");
            $("#listTypeTimings").html($.trim(data.substring(startProviderTypeTime, endProviderTypeTime)));

            var startProviderType = data.indexOf("###StartProviderTypes###") + 24;
            var endProviderType = data.indexOf("###EndProviderTypes###");
            $("#listProviderTypes").html($.trim(data.substring(startProviderType, endProviderType)));

            InitTimingsDatePicker();
        });
    } else {
        $("[id$='divRightsSettings']").html(_msg_ProviderTimingsView).show();
    }
}

function InitTimingsDatePicker() {
    $("[id$='txtTimeFrom']").datepicker({
        changeMonth: true,
        changeYear: true,
        onClose: function (selectedDate) {
            $("[id$='txtTimeThrough']").datepicker("option", "minDate", selectedDate);
        }
    }).mask("99/99/9999");

    $("[id$='txtTimeThrough']").datepicker({
        changeMonth: true,
        changeYear: true,
        onClose: function (selectedDate) {
            //$("#txtDateFromFilter").datepicker("option", "maxDate", selectedDate);
        }
    }).mask("99/99/9999");
}

function AddSchedule() {
    $("[id$='divRightsSettings']").hide();
    
    if (!checkModuleRights("ProviderTimingsEdit")) {
        $("[id$='divRightsSettings']").html(_msg_ProviderTimingsEdit).show();
        return;
    }
    
    var flagError = 0;
    var arrPracticeTimings = new Array();
    
    if (!ValidateForm("tblproviderTimings")) {
        showErrorMessage("");
        flagError = 1;
        return false;
    }
    
    $("#tblPracticeTimeSetting tbody tr").each(function () {
        var CurrentRow = $(this);

        var objPracticeTimings = new Object();

        objPracticeTimings.NameOfDay = $.trim(CurrentRow.find("td:eq(0)").text());
        objPracticeTimings.DayNumber = $.trim(CurrentRow.attr("id"));
        objPracticeTimings.ResourceId = $.trim($('#ddlSelectProvider').val());
        objPracticeTimings.TimingStartDate = $.trim($("[id$='txtTimeFrom']").val());
        objPracticeTimings.TimingExpireDate = $.trim($("[id$='txtTimeThrough']").val());

        if (CurrentRow.find("td:eq(1) select option:selected").index() != 0 && CurrentRow.find("td:eq(1) select option:selected").index() != 1) {

            if (CurrentRow.find("td:eq(2) select option:selected").index() == 0 || CurrentRow.find("td:eq(2) select option:selected").index() == 1) {
                CurrentRow.find("td:eq(2) select").addClass("error");
            }
            else {
                if (CurrentRow.find("td:eq(1) select option:selected").index() != 0 && CurrentRow.find("td:eq(2) select option:selected").index() != 0 && CurrentRow.find("td:eq(1) select option:selected").index() != 1 && CurrentRow.find("td:eq(2) select option:selected").index() != 1) {
                    if ($.trim(CurrentRow.find("td:eq(1) select").val()) >= $.trim(CurrentRow.find("td:eq(2) select").val())) {
                        flagError = 1;
                        CurrentRow.find("td:eq(1) select").addClass("error");
                        CurrentRow.find("td:eq(2) select").addClass("error");
                    }
                    else {
                        CurrentRow.find("td:eq(1) select").removeClass("error");
                        CurrentRow.find("td:eq(2) select").removeClass("error");
                    }
                }
            }
        }

        if (CurrentRow.find("td:eq(2) select option:selected").index() != 0 && CurrentRow.find("td:eq(2) select option:selected").index() != 1) {
            if (CurrentRow.find("td:eq(1) select option:selected").index() == 0 || CurrentRow.find("td:eq(1) select option:selected").index() == 1) {
                flagError = 1;
                CurrentRow.find("td:eq(1) select").addClass("error");
            }
            else {
                CurrentRow.find("td:eq(1) select").removeClass("error");
            }
        }

        if (CurrentRow.find("td:eq(1) select option:selected").index() != 0 || CurrentRow.find("td:eq(2) select option:selected").index() != 0) {
            if (CurrentRow.find("td:eq(1) select option:selected").index() != 1 || CurrentRow.find("td:eq(2) select option:selected").index() != 1) {
                if (CurrentRow.find("td:eq(3) select option:selected").index() != 0) {
                    if (CurrentRow.find("td:eq(3) select option:selected").index() != 1) {
                        
                        if ($.trim(CurrentRow.find("td:eq(3) select").val()) < $.trim(CurrentRow.find("td:eq(1) select").val()) || $.trim(CurrentRow.find("td:eq(3) select").val()) >= $.trim(CurrentRow.find("td:eq(2) select").val())) {
                            flagError = 1;
                            CurrentRow.find("td:eq(3) select").addClass("error");
                        }
                        else {
                            CurrentRow.find("td:eq(3) select").removeClass("error");
                        }

                        if (CurrentRow.find("td:eq(4) select option:selected").index() == 0) {
                            flagError = 1;
                            CurrentRow.find("td:eq(4) select").addClass("error");
                        }
                        else if (flagError == 0) {
                            if (addMinutes($.trim(CurrentRow.find("td:eq(3) select").val()) + ':00', $.trim(CurrentRow.find("td:eq(4) select").val())) >= $.trim(CurrentRow.find("td:eq(2) select").val())) {
                                flagError = 1;
                                CurrentRow.find("td:eq(3) select").addClass("error");
                                CurrentRow.find("td:eq(4) select").addClass("error");
                            }
                            else {

                                CurrentRow.find("td:eq(3) select").removeClass("error");
                                CurrentRow.find("td:eq(4) select").removeClass("error");
                            }
                        }
                    }
                }
            }
            else {
                if (CurrentRow.find("td:eq(4) select option:selected").index() != 0) {
                    flagError = 1;
                    CurrentRow.find("td:eq(4) select").addClass("error");
                }
                else {
                    CurrentRow.find("td:eq(4) select").removeClass("error");
                }
            }
        }

        objPracticeTimings.BreakTypeId = $.trim(CurrentRow.find("td:eq(5) select").val());
        objPracticeTimings.TimeFrom = $.trim(CurrentRow.find("td:eq(1) select").val());
        objPracticeTimings.TimeTo = $.trim(CurrentRow.find("td:eq(2) select").val());
        objPracticeTimings.BreakStart = $.trim(CurrentRow.find("td:eq(3) select").val());
        objPracticeTimings.BreakEnd = addMinutes($.trim(CurrentRow.find("td:eq(3) select").val()) + ':00', $.trim(CurrentRow.find("td:eq(4) select").val()));
        objPracticeTimings.TimeSettingsId = $.trim(CurrentRow.find('input[type=hidden]').val());
        
        arrPracticeTimings.push(objPracticeTimings);
    });
    
    if ($("#listProviderTypes input:checkbox:checked").length == 0) {
        showErrorMessage("Please select atleast 1 Default Appointment Type for this provider");
        return false;
    }
    
    var arrProviderAppointmentTypes = new Array();
    
    $("#listProviderTypes").find("input:checkbox:checked").each(function () {
        var objProviderAppointmentTypes = new Object();
        objProviderAppointmentTypes.AppointmentTypeId = $(this).parent().parent().attr("id");
        objProviderAppointmentTypes.DefaultTime = $(this).parent().parent().find(".hdnDefaultTime").val();
        arrProviderAppointmentTypes.push(objProviderAppointmentTypes);
    });
    
    var arrProviderTypeTimings = new Array();
    
    $("#listTypeTimings tr").each(function () {
        var objProviderTypesTimings = new Object();
        
        objProviderTypesTimings.AppointmentTypeId = $(this).find(".hdnTypeID").val();
        objProviderTypesTimings.DefaultTime = $(this).find(".ddlDefaultTime").val();
        arrProviderTypeTimings.push(objProviderTypesTimings);
    });
    
    if (flagError == 0) {
        $.post(_SettingsPath + "/CallBacks/ProviderTimingsDetailsHandler.aspx", { arrPracticeTimings: JSON.stringify(arrPracticeTimings), resourceProviderId: $("#ddlSelectProvider").val(), arrProviderAppointmentTypes: JSON.stringify(arrProviderAppointmentTypes), arrProviderTypeTimings: JSON.stringify(arrProviderTypeTimings) }, function (data) {
            var start = data.indexOf("####Start####") + 13;
            var end = data.indexOf("####END####");
            $("#divPracticeTimeSettings").html(data.substring(start, end))
            .promise()
            .done(function () {
                InitTimingsDatePicker();
            });
            
            var startProviderTypeTime = data.indexOf("###StartProviderTypeTime###") + 27;
            var endProviderTypeTime = data.indexOf("###EndProviderTypeTime###");
            $("#listTypeTimings").html($.trim(data.substring(startProviderTypeTime, endProviderTypeTime)));
            
            var startProviderType = data.indexOf("###StartProviderTypes###") + 24;
            var endProviderType = data.indexOf("###EndProviderTypes###");
            $("#listProviderTypes").html($.trim(data.substring(startProviderType, endProviderType)));
            
            showSuccessMessage(_msg_Updated);
        });
    }
    else {
        showErrorMessage("");
    }
}

function addMinutes(time, minsToAdd) {
    function D(J) { return (J < 10 ? '0' : '') + J; };
    var piece = time.split(':');
    var mins = piece[0] * 60 + +piece[1] + +minsToAdd;
    return D(mins % (24 * 60) / 60 | 0) + ':' + D(mins % 60);
}
function changeLocationsSchedule(elem) {
    var PracticeLocationsId = $(elem).val();
    var Provider = $.grep(_arrProvidersByLocation, function (v, i) {
        return (v.PracticeLocationsId == PracticeLocationsId);
    });
    var providerHtml = '<option value=""></option>';
    for (var i = 0; i < Provider.length; i++) {
        providerHtml += '<option value="' + Provider[i].ServiceProviderId + '">' + Provider[i].Name + '</option>';
    }
    $("[id$='ddlProviderTo']").html(providerHtml);
    $("[id$='ddlProviderFrom']").html(providerHtml);
}

function changeLocations(elem) {
    var PracticeLocationsId = $(elem).val();
    var Provider = $.grep(_arrProvidersByLocation, function (v, i) {
        return (v.PracticeLocationsId == PracticeLocationsId);
    });
    var providerHtml = "";
    for (var i = 0; i < Provider.length; i++) {
        providerHtml += '<option value="' + Provider[i].ServiceProviderId + '">' + Provider[i].Name + '</option>';
    }
    $("[id$='ddlSelectProvider']").html(providerHtml);
    ddlChange($("[id$='ddlSelectProvider']"));
}

function TransferAppointments() {
    if (!ValidateForm("tblTransferAppointments")) {
        showErrorMessage("");
        return false;
    }
    
    var ProviderFrom = $("[id$='ddlProviderFrom']").val();
    var ProviderTo = $("[id$='ddlProviderTo']").val();
    
    if (ProviderFrom == ProviderTo) {
        showErrorMessage("Please select different Providers!");
        return false;
    }
    
    var StatusIds = "";
    
    $("#cbAppointmentStatus input:checked").each(function () {
        StatusIds += $(this).val() + ";"
    });
    
    if (StatusIds == "") {
        showErrorMessage("Please select atleast one status!");
        return false;
    }
    
    StatusIds = StatusIds.slice(0, -1);
    
    $.post(_SettingsPath + "/CallBacks/AppointmentsTransferHandler.aspx", { ProviderFrom: ProviderFrom, ProviderTo: ProviderTo, StatusIds: StatusIds }, function (data) {
    }).done(function () {
        showSuccessMessage(_msg_Updated);
    });
}


//*****************************End Practice Timings******************************//

//************************Insurances*********************************//
function showInsurances() {

    $(".contents-details-header").html('Insurances');
    $(".setting-content-wrapper").hide();
    $("#divPracticeInsurancesMain").show();
    $("#divInsurances").siblings().hide();
    $("#divPracticeInsurancesMain").html("");
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("InsuranceView")) {
        $("[id$='divRightsSettings']").html(_msg_InsuranceView).show();
        return false;
    }
    if ($.trim($("#divPracticeInsurancesMain").html()).length == 0) {
        $.post('CallBacks/Insurances.aspx', {}, function (data) {
            var start = data.indexOf("###StartInsurance###") + 20;
            var end = data.indexOf("###EndInsurance###");
            $("#divPracticeInsurancesMain").html(data.substring(start, end));

            $("[id$='divRightsSettings']").hide();
            if (checkModuleRights("InsuranceView")) {
                $("#divInsuranceGrid").show();
                GeneratePaging($("[id$='hdnInsurancesTotalCount']").val(), $("#ddlPagingInsurance").val(), "divInsurances", "FilterInsurance");
                if ($("[id$='hdnInsurancesTotalCount']").val() > 0) {
                    $("#divInsurances .spanInfo").html("Showing " + $("#InsuranceList tr:first").children().first().html() + " to " + $("#InsuranceList tr:last").children().first().html() + " of " + $("[id$='hdnInsurancesTotalCount']").val() + " entries");
                }

            } else {
                $("[id$='divRightsSettings']").html(_msg_InsuranceView).show();
            }
            $(".phone").mask("(999) 999-9999");
        });
    }
}

function FilterInsurance(pageNumber, paging) {
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("InsuranceView")) {
        $("#divInsuranceGrid").show();
        $.post("../../Providerportal/CallBacks/InsuranceFilterHandler.aspx", { Rows: $("#ddlPagingInsurance").val(), PageNumber: pageNumber, SortBy: "Name", action: 'Filter Insurance' },

                 function (data) {
                     var returnHtml = data;
                     var start = data.indexOf("###StartInsuranceFilter###") + 26;
                     var end = data.indexOf("###EndInsuranceFilter###");
                     $("#InsuranceList").html(returnHtml.substring(start, end));
                     if (paging == true) {
                         GeneratePaging($("[id$='hdnInsurancesTotalCount']").val(), $("#ddlPagingInsurance").val(), "divInsurances", "FilterInsurance");
                     }
                     if ($("[id$='hdnInsurancesTotalCount']").val() > 0) {
                         $("#divInsurances .spanInfo").html("Showing " + $("#InsuranceList tr:first").children().first().html() + " to " + $("#InsuranceList tr:last").children().first().html() + " of " + $("[id$='hdnInsurancesTotalCount']").val() + " entries");
                     }
                 });
    } else {
        $("[id$='divRightsSettings']").html(_msg_InsuranceView).show();
    }
}
function AddNewInsurance() {
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("InsuranceAdd")) {
        _InsuranceId = 0;
        $("#divInsurances").hide();
        $("#divInsuranceDetailView").hide();
        $("#tblInsurance").find("input, textarea, select").val('');
        $("#divInsuranceAddEdit").show();
        _InsuranceEditCallFrom = "Grid";
    } else {
        $("[id$='divRightsSettings']").html(_msg_InsuranceAdd).show();
    }
}

function cancelSaveInsurance() {
    if (_InsuranceEditCallFrom == "Grid") {
        $("#divInsuranceAddEdit").hide();
        $("#divInsurances").show();
    }
    else {
        $("#divInsuranceAddEdit").hide();
        $("#divInsuranceDetailView").show();
    }
    
    $("#divMesg").hide();
    $("#divContentsDetails *").removeClass("error");
    $("[id$='divRightsSettings']").hide();
}

function saveInsurance() {
    $("[id$='divRightsSettings']").hide();
    
    if (_InsuranceId == 0) {
        if (!checkModuleRights("InsuranceAdd")) {
            $("[id$='divRightsSettings']").html(_msg_InsuranceAdd).show();
            return false;
        }
    }
    else {
        if (!checkModuleRights("InsuranceEdit")) {
            $("[id$='divRightsSettings']").html(_msg_InsuranceEdit).show();
            return false;
        }
    }
    
    if (!ValidateForm("tblInsurance")) {
        showErrorMessage("");
        return false;
    }
    
    if ($.trim($("#txtInsuranceEmail").val()) != "") {
        if (!validateEmail($.trim($("[id$='txtInsuranceEmail']").val()))) {
            $("[id$='txtEmail']").addClass("error");
            showErrorMessage("Error: Enter valid email address.");
            $("[id$='txtInsuranceEmail']").addClass("error");
            return false;
        }
    }

    $("[id$='txtInsuranceEmail']").removeClass("error");

    saveInsuranceDb();
    //checkInsuranceExist();
}

function checkInsuranceExist() {
    var insuranceName = $.trim($("#txtInsuranceName").val());
    var insuranceAdd = $.trim($("#txtInsuranceAddress").val());
    var taxId = $.trim($("#txtInsuranceTaxId").val());
    
    if ((insuranceName != "" && insuranceAdd != "") || taxId != "") {
        $.post(_SettingsPath + "/CallBacks/InsuranceFilterHandler.aspx", { InsuranceId: _InsuranceId, InsuranceName: insuranceName, InsuranceAdd: insuranceAdd, TaxId: taxId, action: 'Check Insurance' }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartInsuranceCheck###") + 25;
            var end = data.indexOf("###EndInsuranceCheck###");
            $("#settingTempDiv").html(returnHtml.substring(start, end));
            var msg = $("#settingTempDiv").find("[id$='hdnChkInsurance']").val();
            
            if (msg != "") {
                showErrorMessage(msg);
                return false;
            }
            else {
                saveInsuranceDb();
                $("#settingTempDiv").val('');
            }
        });
    }
}

function saveInsuranceDb() {
    var insurance = new Object();

    insurance.InsuranceId = _InsuranceId;
    insurance.Name = $.trim($("[id$='txtInsuranceName']").val());
    insurance.TaxId = $.trim($("[id$='txtInsuranceTaxId']").val());
    insurance.InsuranceType = $.trim($("[id$='ddlInsuranceType'] option:selected").text());
    insurance.InsuranceCategoryId = $.trim($("[id$='ddlInsuranceCategory']").val());
    insurance.InsuranceCategory = $.trim($("[id$='ddlInsuranceCategory'] option:selected").text());
    insurance.HeadOfficeAddress = $.trim($("[id$='txtInsuranceAddress']").val());
    insurance.City = $.trim($("[id$='txtInsuranceCity']").val());
    insurance.State = $.trim($("[id$='ddlInsuranceStates']").val());
    insurance.Zip = $.trim($("[id$='txtInsuranceZip']").val());
    insurance.Phone1 = $.trim($("[id$='txtInsurancePhone1']").val());
    insurance.Phone2 = $.trim($("[id$='txtInsurancePhone2']").val());
    insurance.Phone3 = $.trim($("[id$='txtInsurancePhone3']").val());
    insurance.Fax = $.trim($("[id$='txtInsuranceFax']").val());
    insurance.Email = $.trim($("[id$='txtInsuranceEmail']").val());

    $.post(_SettingsPath + "/CallBacks/InsuranceFilterHandler.aspx", { Insurance: JSON.stringify(insurance), action: 'Save Insurance' }, function () {

        if (_InsuranceId == 0) {
            showSuccessMessage(_msg_Created);
        }
        else {
            showSuccessMessage(_msg_Updated);
        }
        showInsurances();
    });
}

function insuranceEdit_Click() {
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("InsuranceEdit")) {
        _InsuranceEditCallFrom = "View";
        $("#divInsurances").hide();
        $("#divInsuranceDetailView").hide();
        $("#divInsuranceAddEdit").show();
    } else {
        $("[id$='divRightsSettings']").html(_msg_InsuranceEdit).show();
    }
}
function insuranceBack_Click() {
    $("#divInsurances").show();
    $("#divInsuranceDetailView").hide();
    $("[id$='divRightsSettings']").hide();
}
function ViewInsuranceGrid_Click(rowId, IsPracticeInsurance, insuranceId) {
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("InsuranceView")) {
        _InsuranceId = insuranceId;
        GetInsuranceData(rowId, insuranceId);
        if (IsPracticeInsurance == "N") {
            $("[id$='btnEditInsurance']").hide();
        }
        else {
            $("[id$='btnEditInsurance']").show();
        }
        $("#divInsurances").hide();
        $("#divInsuranceDetailView").show();
    } else {
        $("[id$='divRightsSettings']").html(_msg_InsuranceView).show();
    }
}
function GetInsuranceData(rowId, insuranceId) {
    /************************* Adding View Data***************************//////                 
    $("#lblInsuranceName").text($.trim($(rowId).closest("tr").find("td:eq(1)").html()));
    $("#lblInsuranceTaxId").text($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[0]));
    $("#lblInsuranceTypeName").text($.trim($(rowId).closest("tr").find("td:eq(2)").html()));
    $("#lblInsuranceCategoryName").text($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[2]));
    $("#lblInsuranceAddress").text($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[8]));
    $("#lblInsuranceCity").text($.trim($(rowId).closest("tr").find("td:eq(3)").html()));
    $("#lblInsuranceStateName").text($.trim($(rowId).closest("tr").find("td:eq(4)").html()));
    $("#lblInsuranceZip").text($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[4]));
    $("#lblInsurancePhone1").text($.trim($(rowId).closest("tr").find("td:eq(6)").html()));
    $("#lblInsurancePhone2").text($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[5]));
    $("#lblInsurancePhone3").text($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[6]));
    $("#lblInsuranceFax").text($.trim($(rowId).closest("tr").find("td:eq(7)").html()));
    $("#lblInsuranceEmail").text($.trim($(rowId).closest("tr").find("td:eq(5)").html()));

    /************************* Adding Edit View Data***************************//////
    $("#txtInsuranceName").val($.trim($(rowId).closest("tr").find("td:eq(1)").html()));
    $("#txtInsuranceTaxId").val($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[0]));
    $("[id$='ddlInsuranceType']").val($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[1]));
    $("[id$='ddlInsuranceCategory']").val($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[3]));

    $("#txtInsuranceAddress").val($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[8]));
    $("#txtInsuranceCity   ").val($.trim($(rowId).closest("tr").find("td:eq(3)").html()));
    $("[id$='ddlInsuranceStates']").val($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[7]));
    $("#txtInsuranceZip").val($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[4]));
    $("#txtInsurancePhone1").val($.trim($(rowId).closest("tr").find("td:eq(6)").html()));
    $("#txtInsurancePhone2").val($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[5]));
    $("#txtInsurancePhone3").val($.trim($(rowId).closest("tr").find("td:eq(9)").html().split('|')[6]));
    $("#txtInsuranceFax").val($.trim($(rowId).closest("tr").find("td:eq(7)").html()));
    $("#txtInsuranceEmail").val($.trim($(rowId).closest("tr").find("td:eq(5)").html()));

}
function editInsuranceGrid_Click(rowId, insuranceId) {
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("InsuranceEdit")) {
        _InsuranceId = insuranceId;
        GetInsuranceData(rowId, insuranceId);
        _InsuranceEditCallFrom = "Grid";
        $("#divInsurances").hide();
        $("#divInsuranceDetailView").hide();
        $("#divInsuranceAddEdit").show();

    } else {
        $("[id$='divRightsSettings']").html(_msg_InsuranceEdit).show();
    }
}
function deleteInsuranceGrid_Click(trId, insuranceId) {
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("InsuranceDelete")) {
        $("#dialogconfirmMaster").html(_msg_Deleted_Confirmation);
        $("#dialogconfirmMaster").dialog({
            resizable: false,
            height: 140,
            width: 300,
            modal: true,
            title: 'Confirmation',
            buttons: {
                "Yes": function () {
                    $(this).dialog("close");
                    $.post(_SettingsPath + "/CallBacks/InsuranceFilterHandler.aspx", { InsuranceId: insuranceId, action: 'Delete Insurance' },
                        function (data) {
                            var returnHtml = data;
                            var start = data.indexOf("###StartInsuranceFilter###") + 26;
                            var end = data.indexOf("###EndInsuranceFilter###");
                            $("#InsuranceList").html(returnHtml.substring(start, end));
                            GeneratePaging($("[id$='hdnInsurancesTotalCount']").val(), $("#ddlPagingInsurance").val(), "divInsurances", "FilterInsurance");

                            if ($("[id$='hdnInsurancesTotalCount']").val() > 0) {
                                $("#divInsurances .spanInfo").html("Showing " + $("#InsuranceList tr:first").children().first().html() + " to " + $("#InsuranceList tr:last").children().first().html() + " of " + $("[id$='hdnInsurancesTotalCount']").val() + " entries");
                            }
                            showSuccessMessage(_msg_Deleted);
                        });
                },
                "No": function () {
                    $(this).dialog("close");
                }
            }
        });
    } else {
        $("[id$='divRightsSettings']").html(_msg_InsuranceDelete).show();
    }
}


//************************END Insurances*********************************//

/****************************************** Start Review of system ************************************/

var _newROSTemplate = 0, _newROSCategory = 0, _newROSItem = 0, _currentTemplate = null, _currentCategory = null, _currentItem = null;


function ShowReviewOfSystem() {
    $(".Setting-detail-header").html('Review of System');

    $("#divSettingDetails .parent").hide();
    $("#divReviewOfSystem").show();

    if ($("#divReviewOfSystem").html().length == 0) {
        $.post(_SettingsPath + "/CallBacks/ReviewOfSystem.aspx", function (data) {
            var returnHtml = data;
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf("###End###");
            $("#divReviewOfSystem").html(returnHtml.substring(start, end));

            setTemplateRadio();
        });
    }
}

function setTemplateRadio() {
    if ($("#tblTemplates tr").length > 0) {
        $("#tblTemplates").find("input[type='radio']").attr("name", "Templates");
        //$("#tblTemplates").find("input[type='radio']:checked").closest("tr").find(".td-first-ros span").click();
    }
}


function validateTemplate() {
    if ($("#" + _currentTemplate).find("input[type='text']").length > 0) {
        var templateName = $.trim($("#" + _currentTemplate).find("input[type='text']").val());
        if (templateName == "") {
            alert("Exam name cannot be empty!");
            return false;
        }
    }
    return true;
}

function validateTemplateCategory() {

    if (_currentCategory == null || _currentCategory == "undefined") {
        //alert("Please enter category first!");
        //return false;
    }

    if ($("#" + _currentCategory).find("input[type='text']").length > 0) {
        var categoryName = $.trim($("#" + _currentCategory).find("input[type='text']").val());
        if (categoryName == "") {
            alert("Category name cannot be empty!");
            return false;
        }
    }
    return true;
}

function validateCategoryItem() {

    if ($("." + _currentCategory).find("input[type='text']").length > 0) {
        var itemName = $.trim($("." + _currentCategory).find("input[type='text']").val());
        if (itemName == "") {
            alert("Item name cannot be empty!");
            return false;
        }
    }
    return true;
}

function addNewTemplate() {
    if (!editTemplateDone($("#tblTemplates").find(".spaneditdone"))) {
        return false;
    }
    _newROSTemplate++;
    var newRowId = "new_" + _newROSTemplate;
    var templateRow = '<tr class="tr-new-template" id="' + newRowId + '">';
    templateRow += '<td class="td-first-ros">';
    templateRow += '<input type="text" class="ros-new-template" />';
    templateRow += '</td>';
    templateRow += '<td align="center">';
    templateRow += '<input type="radio" checked="checked" name="Templates" onclick="templateRadioButton(this);" />';
    templateRow += '</td>';
    templateRow += '<td align="center">';
    templateRow += '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editTemplateDone(this);"></span>';
    templateRow += '<span class="spandelete" title="Delete Record" onclick="deleteTemplate(this);"></span>';
    templateRow += '<input type="hidden" class="hdnROSTemplateId" value="0" />';
    templateRow += '</td>';
    templateRow += '</tr>';
    $("#tblTemplates").append(templateRow);

    _currentTemplate = newRowId;
    showTemplateCategoryWrapper();
    return true;
}

function editTemplateDone(elem) {

    if (!validateTemplateCategory()) {
        return false;
    }

    //    var categoryName = $("#" + _currentCategory).find(".td-first-ros").find("input[type='text']").val();
    //    if (categoryName == "") {
    //        alert("Category name cannot be empty!");
    //        return false;
    //    }


    if (!validateCategoryItem()) {
        return false;
    }

    var templateRow = $(elem).closest("tr");
    var templateName = "";
    if (templateRow.find(".td-first-ros").find("input[type='text']").length > 0) {
        templateName = templateRow.find(".td-first-ros").find("input[type='text']").val();
        if (templateName == "") {
            alert("Template name cannot be empty!");
            return false;
        }
    }
    var templateDisabled = '<span class="ros-name" onclick="templateClick(this);">' + templateName + '</span>';
    templateRow.find(".td-first-ros").html(templateDisabled);
    var editIcon = '<span class="spanedit" title="Edit Record" style="margin: 0 5px 0 0;" onclick="editTemplate(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentTemplate = templateRow.attr("id");
    return true;
}

function editTemplate(elem) {

    if (!editTemplateDone($("#tblTemplates").find(".spaneditdone"))) {
        return false;
    }

    var templateRow = $(elem).closest("tr");
    var templateName = $.trim(templateRow.find(".td-first-ros").find(".ros-name").html());
    var templateInput = '<input type="text" value="' + templateName + '" />';
    templateRow.find(".td-first-ros").html(templateInput);
    var editIcon = '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editTemplateDone(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentTemplate = templateRow.attr("id");
    $("#" + _currentTemplate).find("input[type='radio']").click();
    showTemplateCategoryWrapper();
    return true;
}

function deleteTemplate(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (isConfirm) {

        var RecordId = $(elem).parent().find(".hdnROSTemplateId").val();
        var action = "DELETE";
        var Flag = "Template";
        $.post(_SettingsPath + "/CallBacks/ReviewOfSystemHandler.aspx", { RecordId: RecordId, action: action, Flag: Flag }, function (data) {
            _currentTemplate = $(elem).closest("tr").attr("id");
            $("." + _currentTemplate).remove();
            $(elem).closest("tr").remove();
            _currentTemplate = null;

            alert("Record Deleted!");
        });
    }
}

function templateClick(elem) {

    if (!editTemplateDone($("#tblTemplates").find(".spaneditdone"))) {
        return false;
    }

    var templateRow = $(elem).closest("tr");
    _currentTemplate = templateRow.attr("id");
    $("#" + _currentTemplate).find("input[type='radio']").click();
    showTemplateCategoryWrapper();
}

function templateRadioButton(elem) {
}


function showTemplateCategoryWrapper() {
    if ($("div." + _currentTemplate).length == 0) {
        var divTemplate = '<div class="' + _currentTemplate + '"><table></table></div>';
        $("#categories-wrapper").append(divTemplate);
    }

    $("#categories-wrapper div").hide();
    $("div." + _currentTemplate).show();


    $("#items-wrapper div").hide();
    if ($("div." + _currentTemplate + " table tr").length > 0) {
        _currentCategory = $("div." + _currentTemplate + " table tr").eq(0).attr("id");

        if ($("div." + _currentCategory).length == 0) {
            var divCategory = '<div class="' + _currentCategory + '"><table></table></div>';
            $("#items-wrapper").append(divCategory);
        }

        $("div." + _currentCategory).show();
    }

    //    if (!(_currentTemplate == undefined || _currentTemplate == null)) {
    //        if ($("div." + _currentTemplate).length == 0) {
    //            var TemplateId = $("#" + _currentTemplate).find(".hdnROSTemplateId").val();
    //            $.post(_SettingsPath + "/CallBacks/ReviewOfSystemTemplateCategoriesLoadHandler.aspx", { TemplateId: TemplateId }, function (data) {
    //                var returnHtml = data;
    //                var startCategory = data.indexOf("###StartCategory###") + 19;
    //                var endCategory = data.indexOf("###EndCategory###");
    //                var divOrgan = '<div class="' + _currentTemplate + '">' + returnHtml.substring(startCategory, endCategory) + '</div>';
    //                $("#examDescription-wrapper").append(divOrgan);
    //                
    //                var startDetailsValues = data.indexOf("###StartDetailsValues###") + 24;
    //                var endDetailsValues = data.indexOf("###EndDetailsValues###");
    //                
    //                $("#organDetailsValues-wrapper > div").hide();
    //                if ($("div." + _currentOrgan + " ul li").length > 0) {
    //                    _currentOrganDescription = $("div." + _currentOrgan + " ul li").eq(0).attr("id");
    //                    var divOrganDescription = '<div class="' + _currentOrganDescription + '">' + returnHtml.substring(startDetailsValues, endDetailsValues) + '</div>';
    //                    $("#organDetailsValues-wrapper").append(divOrganDescription);
    //                    
    //                    $("div." + _currentOrganDescription).show();
    //                }
    //                else {
    //                    _currentOrganDescription = null;
    //                }
    //                
    //                $("#examDescription-wrapper > div").hide();
    //                $("div." + _currentOrgan).show();
    //                
    //            });
    //        }
    //        else {
    //            $("#examDescription-wrapper > div").hide();
    //            $("div." + _currentOrgan).show();

    //            $("#organDetailsValues-wrapper > div").hide();

    //            if ($("div." + _currentOrgan + " ul li").length > 0) {
    //                _currentOrganDescription = $("div." + _currentOrgan + " ul li").eq(0).attr("id");
    //                $("div." + _currentOrganDescription).show();
    //            }
    //        }
    //    }
}


/*** Start Categories ***/

function addNewCategory() {
    if (!editCategoryDone($("div." + _currentTemplate + " table").find(".spaneditdone"))) {
        return false;
    }

    _newROSCategory++;
    var newRowId = "newCategory_" + _newROSCategory;
    var templateRow = '<tr class="tr-new-category" id="' + newRowId + '">';
    templateRow += '<td class="td-first-ros">';
    templateRow += '<input type="text" class="ros-new-category" />';
    templateRow += '</td>';
    templateRow += '<td align="center">';
    templateRow += '<input type="checkbox" checked="checked" />';
    templateRow += '</td>';
    templateRow += '<td align="center">';
    templateRow += '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editCategoryDone(this);"></span>';
    templateRow += '<span class="spandelete" title="Delete Record" onclick="deleteCategory(this);"></span>';
    templateRow += '<input type="hidden" class="hdnROSCategoryId" value="0" />';
    templateRow += '</td>';
    templateRow += '</tr>';
    $("div." + _currentTemplate + " table").append(templateRow);

    _currentCategory = newRowId;
    showCategoryItemsWrapper();
    return true;
}

function editCategoryDone(elem) {

    if (!validateTemplate()) {
        return false;
    }

    if (!validateCategoryItem()) {
        return false;
    }

    //    var templateName = $("#" + _currentTemplate).find(".td-first-ros").find("input[type='text']").val();
    //    if (templateName == "") {
    //        alert("Template name cannot be empty!");
    //        return false;
    //    }

    var categoryRow = $(elem).closest("tr");
    var categoryName = categoryRow.find(".td-first-ros").find("input[type='text']").val();
    if (categoryName == "") {
        alert("Category name cannot be empty!");
        return false;
    }

    var categoryDisabled = '<span class="ros-name" onclick="categoryClick(this);">' + categoryName + '</span>';
    categoryRow.find(".td-first-ros").html(categoryDisabled);
    var editIcon = '<span class="spanedit" title="Edit Record" style="margin: 0 5px 0 0;" onclick="editCategory(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentCategory = categoryRow.attr("id");
    return true;
}

function editCategory(elem) {

    if (!editCategoryDone($("div." + _currentTemplate + " table").find(".spaneditdone"))) {
        return false;
    }

    var templateRow = $(elem).closest("tr");
    var templateName = $.trim(templateRow.find(".td-first-ros").find(".ros-name").html());
    var templateInput = '<input type="text" value="' + templateName + '" />';
    templateRow.find(".td-first-ros").html(templateInput);
    var editIcon = '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editCategoryDone(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentCategory = templateRow.attr("id");
    showCategoryItemsWrapper();
    return true;
}

function deleteCategory(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (isConfirm) {

        var RecordId = $(elem).parent().find(".hdnROSCategoryId").val();
        var action = "DELETE";
        var Flag = "Item";
        $.post(_SettingsPath + "/CallBacks/ReviewOfSystemHandler.aspx", { RecordId: RecordId, action: action, Flag: Flag }, function (data) {

            _currentCategory = $(elem).closest("tr").attr("id");
            $("." + _currentCategory).remove();
            $(elem).closest("tr").remove();
            _currentCategory = null;
            alert("Record Deleted!");
        });
    }
}

function categoryClick(elem) {

    if (!editCategoryDone($("div." + _currentTemplate + " table").find(".spaneditdone"))) {
        return false;
    }
    var templateRow = $(elem).closest("tr");
    _currentCategory = templateRow.attr("id");
    showCategoryItemsWrapper();
}

function showCategoryItemsWrapper() {
    if ($("div." + _currentCategory).length == 0) {
        var divCategory = '<div class="' + _currentCategory + '"><table></table></div>';
        $("#items-wrapper").append(divCategory);
    }

    $("#items-wrapper div").hide();
    $("div." + _currentCategory).show();
}

/*** End Categories ***/

/*** Start Items ***/

function addNewItem() {
    if (!editItemDone($("div." + _currentCategory + " table").find(".spaneditdone"))) {
        return false;
    }

    _newROSItem++;
    var newRowId = "newItem_" + _newROSItem;
    var templateRow = '<tr class="tr-new-Item" id="' + newRowId + '">';
    templateRow += '<td class="td-first-ros">';
    templateRow += '<input type="text" class="ros-new-Item" />';
    templateRow += '</td>';
    templateRow += '<td align="center">';
    templateRow += '<input type="checkbox" checked="checked" />';
    templateRow += '</td>';
    templateRow += '<td align="center">';
    templateRow += '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editItemDone(this);"></span>';
    templateRow += '<span class="spandelete" title="Delete Record" onclick="deleteItem(this);"></span>';
    templateRow += '<input type="hidden" class="hdnROSItemId" value="0" />';
    templateRow += '</td>';
    templateRow += '</tr>';
    $("div." + _currentCategory + " table").append(templateRow);

    _currentItem = newRowId;
    return true;
}

function editItemDone(elem) {

    if (!validateTemplate()) {
        return false;
    }

    if (!validateTemplateCategory()) {
        return false;
    }

    //    var categoryName = $("#" + _currentCategory).find(".td-first-ros").find("input[type='text']").val();
    //    if (categoryName == "") {
    //        alert("Category name cannot be empty!");
    //        return false;
    //    }

    var itemRow = $(elem).closest("tr");
    var itemName = "";

    if (itemRow.find(".td-first-ros").find("input[type='text']").length > 0) {
        itemName = itemRow.find(".td-first-ros").find("input[type='text']").val();
        if (itemName == "") {
            alert("Item name cannot be empty!");
            return false;
        }
    }

    var itemDisabled = '<span class="ros-name" onclick="itemClick(this);">' + itemName + '</span>';
    itemRow.find(".td-first-ros").html(itemDisabled);
    var editIcon = '<span class="spanedit" title="Edit Record" style="margin: 0 5px 0 0;" onclick="editItem(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentItem = itemRow.attr("id");
    return true;
}

function editItem(elem) {

    if (!editItemDone($("div." + _currentCategory + " table").find(".spaneditdone"))) {
        return false;
    }

    var itemRow = $(elem).closest("tr");
    var itemName = $.trim(itemRow.find(".td-first-ros").find(".ros-name").html());
    var itemInput = '<input type="text" value="' + itemName + '" />';
    itemRow.find(".td-first-ros").html(itemInput);
    var editIcon = '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editItemDone(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentItem = itemRow.attr("id");
    return true;
}

function deleteItem(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (isConfirm) {

        var RecordId = $(elem).parent().find(".hdnROSItemId").val();
        var action = "DELETE";
        var Flag = "Item";
        $.post(_SettingsPath + "/CallBacks/ReviewOfSystemHandler.aspx", { RecordId: RecordId, action: action, Flag: Flag }, function (data) {
            $(elem).closest("tr").remove();
            _currentItem = null;
            alert("Record Deleted!");
        });

    }
}

/*** End Items ***/



function saveROS() {

    var listROSTemplates = new Array();

    $("#tblTemplates tr").each(function () {
        var objROSTemplates = new Object();

        objROSTemplates.ROSTemplatesId = $(this).find(".hdnROSTemplateId").val();

        if ($(this).find(".td-first-ros").find("span").length > 0) {
            objROSTemplates.TemplateName = $.trim($(this).find(".td-first-ros").find("span").html());
        }
        else {
            objROSTemplates.TemplateName = $.trim($(this).find(".td-first-ros").find("input").val());
        }

        objROSTemplates.IsActive = $(this).find("input[type='radio']").is(":checked");
        objROSTemplates.ServiceProviderId = $("[id$='ddProviders']").val();

        var currentTemplate = $(this).attr("id");
        var listROSCategories = new Array();
        $("#categories-wrapper ." + currentTemplate + " table tr").each(function () {
            var objROSCategories = new Object();

            objROSCategories.ROSCategoryId = $(this).find(".hdnROSCategoryId").val();

            if ($(this).find(".td-first-ros").find("span").length > 0) {
                objROSCategories.CategoryName = $.trim($(this).find(".td-first-ros").find("span").html());
            }
            else {
                objROSCategories.CategoryName = $.trim($(this).find(".td-first-ros").find("input").val());
            }

            var currentCategory = $(this).attr("id");
            var listROSCategoryItems = new Array();

            $("#items-wrapper ." + currentCategory + " table tr").each(function () {
                var objROSCategoryItems = new Object();

                objROSCategoryItems.ROSCategoryItemId = $(this).find(".hdnROSItemId").val();

                if ($(this).find(".td-first-ros").find("span").length > 0) {
                    objROSCategoryItems.ItemName = $.trim($(this).find(".td-first-ros").find("span").html());
                }
                else {
                    objROSCategoryItems.ItemName = $.trim($(this).find(".td-first-ros").find("input").val());
                }

                listROSCategoryItems.push(objROSCategoryItems);
            });

            objROSCategories.listROSCategoryItems = listROSCategoryItems;
            listROSCategories.push(objROSCategories);
        });

        objROSTemplates.listROSCategories = listROSCategories;
        listROSTemplates.push(objROSTemplates);

    });

    var action = "SAVE";

    $.post(_SettingsPath + "/CallBacks/ReviewOfSystemHandler.aspx", { listROSTemplates: JSON.stringify(listROSTemplates), action: action }, function (data) {

    });
}

function serviceProviderChange(elem) {
    var ProviderId = $(elem).val();
    $.post(_SettingsPath + "/CallBacks/ReviewOfSystemLoadHandler.aspx", { ProviderId: ProviderId }, function (data) {
        var returnHtml = data;

        var startIndexTemplates = data.indexOf("###StartTemplates###") + 20;
        var lastIndexTemplates = data.indexOf("###EndTemplates###");
        var templateHtml = returnHtml.substring(startIndexTemplates, lastIndexTemplates);
        $("#templates-wrapper").html(templateHtml);

        var startIndexCategory = data.indexOf("###StartCategories###") + 21;
        var lastIndexCategory = data.indexOf("###EndCategories###");
        var categoryHtml = returnHtml.substring(startIndexCategory, lastIndexCategory);
        $("#categories-wrapper").html(categoryHtml);

        var startIndexItems = data.indexOf("###StartItems###") + 16;
        var lastIndexItems = data.indexOf("###EndItems###");
        var itemsHtml = returnHtml.substring(startIndexItems, lastIndexItems);
        $("#items-wrapper").html(itemsHtml);
    });
}


/****************************************** End Review of system ************************************/





/****************************************** Start Physical Exam ************************************/

var _newOrgan = 0, _newOrganDescription = 0, _newOrganDetailValue = 0, _currentOrgan = null, _currentOrganDescription = null, _currentDescriptionValue = null;

function ShowPhysicalExam() {
    $(".Setting-detail-header").html('Physical Exam');

    $("#divSettingDetails .parent").hide();
    $("#divPhysicalExamWrapper").show();


    if ($("#divPhysicalExamWrapper").html().length == 0) {
        $.post(_SettingsPath + "/CallBacks/PhysicalExam.aspx", function (data) {
            var returnHtml = data;
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf("###End###");
            $("#divPhysicalExamWrapper").html(returnHtml.substring(start, end));

            setCurrentRecord();
            //            $("#PhysicialExamList li span.name").eq(0).click();
            //            var currentOrgan = $("#PhysicialExamList li").eq(0).attr("id");
            //            $("." + currentOrgan + " ul li").eq(0).find("span.name").click();
        });
    }
}

function filterPhysicalExam() {
    var OrganTemplatesId = $("[id$='ddlOrganTemplates']").val();
    $.post(_SettingsPath + "/CallBacks/PhysicalExamFilterHandler.aspx", { OrganTemplatesId: OrganTemplatesId }, function (data) {
        var returnHtml = data;
        var StartOrgan = data.indexOf("###StartOrgan###") + 16;
        var EndOrgan = data.indexOf("###EndOrgan###");
        $("#PhysicialExamList").html(returnHtml.substring(StartOrgan, EndOrgan));

        var StartOrganDetail = data.indexOf("###StartOrganDetail###") + 22;
        var EndOrganDetail = data.indexOf("###EndOrganDetail###");
        $("#examDescription-wrapper").html(returnHtml.substring(StartOrganDetail, EndOrganDetail));

        var StartOrganDetailValue = data.indexOf("###StartOrganDetailValue###") + 27;
        var EndOrganDetailValue = data.indexOf("###EndOrganDetailValue###");
        $("#organDetailsValues-wrapper").html(returnHtml.substring(StartOrganDetailValue, EndOrganDetailValue));

        setCurrentRecord();
    });
}

function setCurrentRecord() {
    if ($("#PhysicialExamList li").length > 0) {
        $("#PhysicialExamList li").eq(0).addClass("record-selected-row");
        _currentOrgan = $("#PhysicialExamList li").eq(0).attr("id");
    }

    if ($("." + _currentOrgan + " ul li").length > 0) {
        $("." + _currentOrgan + " ul li").eq(0).addClass("record-selected-row");
        _currentOrganDescription = $("." + _currentOrgan + " ul li").eq(0).attr("id");
    }
}

function validateOrgan() {
    if ($("#" + _currentOrgan).find("input[type='text']").length > 0) {
        var currentOrganName = $.trim($("#" + _currentOrgan).find("input[type='text']").val());
        if (currentOrganName == "") {
            alert("Exam name cannot be empty!");
            return false;
        }
    }
    return true;
}

function validateExamDescription() {

    if (_currentOrganDescription == null || _currentOrganDescription == "undefined") {
        alert("Please enter exam description first!");
        return false;
    }

    if ($("#" + _currentOrganDescription).find("input[type='text']").length > 0) {
        var organDescriptionName = $.trim($("#" + _currentOrganDescription).find("input[type='text']").val());
        if (organDescriptionName == "") {
            alert("Exam description name cannot be empty!");
            return false;
        }
    }
    return true;
}

function validateExamValue() {
    var currentValue = $("#" + _currentOrganDescription).attr("id");
    if ($("." + currentValue).find("input[type='text']").length > 0) {
        var organDescriptionValueName = $.trim($("." + currentValue).find("input[type='text']").val());
        if (organDescriptionValueName == "") {
            alert("Value cannot be empty!");
            return false;
        }
    }
    return true;
}

function addNewExamName() {

    if (!editOrganDone($("#PhysicialExamList").find(".spaneditdone"))) {
        return false;
    }
    _newOrgan++;
    var newOrganId = "newOrgan_" + _newOrgan;

    var newLiClass = "even";
    var lastLiClass = $("[id$='PhysicialExamList'] li").last().attr("class");
    if (lastLiClass == "even") {
        newLiClass = "odd";
    }

    var organHtml = '<li class="' + newLiClass + '" id="' + newOrganId + '">';
    organHtml += '<input type="text" class="organ-text-box"/>';
    organHtml += '<div class="action-div">';
    organHtml += '<span class="spaneditdone" title="Edit Done" style="margin: 0 5px 0 0;" onclick="editOrganDone(this);"></span>';
    organHtml += '<span class="spandelete" title="Delete Record" onclick="deleteOrgan(this);"></span>';
    organHtml += '<input type="hidden" class="hdnOrganId" value="0" />';
    organHtml += '<input type="hidden" class="hdnOrganCode" value="" />';
    organHtml += '</div>';
    organHtml += '</li>';

    $("[id$='PhysicialExamList']").append(organHtml);

    _currentOrgan = newOrganId;
    showOrganDescriptionWrapper();
    return true;
}

function editOrganDone(elem) {

    if (!(_currentOrganDescription == null || _currentOrganDescription == "undefined")) {
        if (!validateExamDescription()) {
            return false;
        }
        //        if ($("#" + _currentOrganDescription).find("input[type='text']").length > 0) {
        //            var organDescriptionName = $.trim($("#" + _currentOrganDescription).find("input[type='text']").val());
        //            if (organDescriptionName == "") {
        //                alert("Exam description name cannot be empty!");
        //                return false;
        //            }
        //        }


        if (!validateExamValue()) {
            return false;
        }

    }

    var organNameLi = $(elem).closest("li");
    organNameLi.siblings().removeClass("record-selected-row");
    organNameLi.addClass("record-selected-row");

    if (organNameLi.find("input[type='text']").length > 0) {
        var organName = $.trim(organNameLi.find("input[type='text']").val());
        if (organName == "") {
            alert("Exam name cannot be empty!");
            return false;
        }

        var organSpan = '<span class="name" onclick="organClick(this);">' + organName + '</span>';
        organNameLi.find(".organ-text-box").replaceWith(organSpan);

        var editIcon = '<span class="spanedit" title="Edit Record" style="margin: 0 5px 0 0;" onclick="editOrgan(this);"></span>';
        $(elem).replaceWith(editIcon);
    }

    _currentOrgan = organNameLi.attr("id");
    return true;
}

function editOrgan(elem) {

    if (!editOrganDone($("#PhysicialExamList").find(".spaneditdone"))) {
        return false;
    }

    var organNameLi = $(elem).closest("li");
    organNameLi.siblings().removeClass("record-selected-row");
    organNameLi.addClass("record-selected-row");
    var organName = $.trim(organNameLi.find("span.name").html());
    var organInput = '<input type="text" value="' + organName + '" class="organ-text-box" />';
    organNameLi.find("span.name").replaceWith(organInput);
    var editIcon = '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editOrganDone(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentOrgan = organNameLi.attr("id");
    showOrganDescriptionWrapper();
    return true;
}

function deleteOrgan(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (isConfirm) {

        var RecordId = $(elem).parent().find(".hdnOrganId").val();
        var OrganCode = $(elem).parent().find(".hdnOrganCode").val();
        var action = "DELETE";
        var Flag = "Organ";
        $.post(_SettingsPath + "/CallBacks/PhysicalExamHandler.aspx", { RecordId: RecordId, OrganCode: OrganCode, action: action, Flag: Flag }, function (data) {
            _currentOrgan = $(elem).closest("li").attr("id");
            $("div." + _currentOrgan).remove();

            $("div." + _currentOrgan).find("ul").find("li").each(function () {
                var organDescription = $(this).attr("id");
                $("div." + organDescription).remove();
            });

            $(elem).closest("li").remove();
            _currentOrgan = null;

            alert("Record Deleted!");
        });
    }
}

function showOrganDescriptionWrapper() {
    if (_currentOrgan != undefined) {
        var OrganCode = $("#" + _currentOrgan).find(".hdnOrganCode").val();

        if ($("div." + _currentOrgan).length == 0) {
            $.post(_SettingsPath + "/CallBacks/PhysicalExamOrgansDetailsLoadHandler.aspx", { OrganCode: OrganCode }, function (data) {
                var returnHtml = data;
                var startDetails = data.indexOf("###StartDetails###") + 18;
                var endDetails = data.indexOf("###EndDetails###");
                var divOrgan = '<div class="' + _currentOrgan + '">' + returnHtml.substring(startDetails, endDetails) + '</div>';
                $("#examDescription-wrapper").append(divOrgan);

                var startDetailsValues = data.indexOf("###StartDetailsValues###") + 24;
                var endDetailsValues = data.indexOf("###EndDetailsValues###");

                $("#organDetailsValues-wrapper > div").hide();
                if ($("div." + _currentOrgan + " ul li").length > 0) {
                    _currentOrganDescription = $("div." + _currentOrgan + " ul li").eq(0).attr("id");
                    var divOrganDescription = '<div class="' + _currentOrganDescription + '">' + returnHtml.substring(startDetailsValues, endDetailsValues) + '</div>';
                    $("#organDetailsValues-wrapper").append(divOrganDescription);

                    $("div." + _currentOrganDescription).show();
                }
                else {
                    _currentOrganDescription = null;
                }

                $("#examDescription-wrapper > div").hide();
                $("div." + _currentOrgan).show();

            });
        }
    }

}

function organClick(elem) {

    if (!editOrganDone($("#PhysicialExamList").find(".spaneditdone"))) {
        return false;
    }

    var organNameLi = $(elem).closest("li");
    organNameLi.siblings().removeClass("record-selected-row");
    organNameLi.addClass("record-selected-row");
    _currentOrgan = organNameLi.attr("id");
    showOrganDescriptionWrapper();
    return true;
}

/*** Start ExamDescription ***/

function addNewExamDescription() {
    if (!editExamDescriptionDone($("div." + _currentOrgan + " ul").find(".spaneditdone"))) {
        return false;
    }

    _newOrganDescription++;
    var newRowId = "newOrganDescription_" + _newOrganDescription;

    var newLiClass = "even";
    var lastLiClass = $("[id$='examDescription-wrapper'] div").last().find("ul").find("li").last().attr("class");
    if (lastLiClass == "even") {
        newLiClass = "odd";
    }

    var organDescriptionHtml = '<li class="' + newLiClass + '" id="' + newRowId + '">';
    organDescriptionHtml += '<input type="text" class="organ-text-box"/>';
    organDescriptionHtml += '<div class="action-div">';
    organDescriptionHtml += '<span class="spaneditdone" title="Edit Done" style="margin: 0 5px 0 0;" onclick="editExamDescriptionDone(this);"></span>';
    organDescriptionHtml += '<span class="spandelete" title="Delete Record" onclick="deleteExamDescription(this);"></span>';
    organDescriptionHtml += '<input type="hidden" class="hdnOrgansDetailsId" value="0" />';
    organDescriptionHtml += '<input type="hidden" class="hdnOrganCode" value="" />';
    organDescriptionHtml += '</div>';
    organDescriptionHtml += '</li>';

    $("div." + _currentOrgan + " ul").append(organDescriptionHtml);

    _currentOrganDescription = newRowId;
    showExamDescriptionValueWrapper();
    return true;
}

function editExamDescriptionDone(elem) {

    if (!validateOrgan()) {
        return false;
    }

    if (!validateExamValue()) {
        return false;
    }

    //    if ($("#" + _currentOrgan).find("input[type='text']").length > 0) {
    //        var currentOrganName = $.trim($("#" + _currentOrgan).find("input[type='text']").val());
    //        if (currentOrganName == "") {
    //            alert("Exam name cannot be empty!");
    //            return false;
    //        }
    //    }

    var organDescriptionNameLi = $(elem).closest("li");

    organDescriptionNameLi.siblings().removeClass("record-selected-row");
    organDescriptionNameLi.addClass("record-selected-row");

    var organDescriptionName = "";

    if (organDescriptionNameLi.find("input[type='text']").length > 0) {
        organDescriptionName = $.trim(organDescriptionNameLi.find("input[type='text']").val());
        if (organDescriptionName == "") {
            alert("Exam description name cannot be empty!");
            return false;
        }
    }

    var organDescriptionSpan = '<span class="name" onclick="examDescriptionClick(this);">' + organDescriptionName + '</span>';

    organDescriptionNameLi.find(".organ-text-box").replaceWith(organDescriptionSpan);

    var editIcon = '<span class="spanedit" title="Edit Record" style="margin: 0 5px 0 0;" onclick="editExamDescription(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentOrganDescription = organDescriptionNameLi.attr("id");
    return true;
}

function editExamDescription(elem) {

    if (!editExamDescriptionDone($("div." + _currentOrgan + " ul").find(".spaneditdone"))) {
        return false;
    }

    var organDescriptionNameLi = $(elem).closest("li");

    organDescriptionNameLi.siblings().removeClass("record-selected-row");
    organDescriptionNameLi.addClass("record-selected-row");

    var organDescriptionName = $.trim(organDescriptionNameLi.find(".name").html());
    var organDescriptionInput = '<input type="text" class="organ-text-box" value="' + organDescriptionName + '" />';
    organDescriptionNameLi.find("span.name").replaceWith(organDescriptionInput);
    var editIcon = '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editExamDescriptionDone(this);"></span>';
    $(elem).replaceWith(editIcon);

    _currentOrganDescription = organDescriptionNameLi.attr("id");
    showExamDescriptionValueWrapper();
    return true;

}

function deleteExamDescription(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (isConfirm) {

        var RecordId = $(elem).parent().find(".hdnOrgansDetailsId").val();
        var action = "DELETE";
        var Flag = "OrganDescription";
        $.post(_SettingsPath + "/CallBacks/PhysicalExamHandler.aspx", { RecordId: RecordId, action: action, Flag: Flag }, function (data) {

            _currentOrganDescription = $(elem).closest("li").attr("id");
            $("div." + _currentOrganDescription).remove();
            $(elem).closest("li").remove();
            _currentOrganDescription = null;
            alert("Record Deleted!");
        });
    }

}

function examDescriptionClick(elem) {

    if (!editExamDescriptionDone($("div." + _currentOrgan + " ul").find(".spaneditdone"))) {
        return false;
    }
    var organDescriptionNameLi = $(elem).closest("li");
    organDescriptionNameLi.siblings().removeClass("record-selected-row");
    organDescriptionNameLi.addClass("record-selected-row");
    _currentOrganDescription = organDescriptionNameLi.attr("id");
    showExamDescriptionValueWrapper();
    return true;
}

function showExamDescriptionValueWrapper() {
    var OrgansDetailsId = $("#" + _currentOrganDescription).find(".hdnOrgansDetailsId").val();
    $.post(_SettingsPath + "/CallBacks/PhysicalExamDetailsValuesLoadHandler.aspx", { OrgansDetailsId: OrgansDetailsId }, function (data) {
        var returnHtml = data;

        var startDetailsValues = data.indexOf("###StartDetailsValues###") + 24;
        var endDetailsValues = data.indexOf("###EndDetailsValues###");
        var divOrganDescription = '<div class="' + _currentOrganDescription + '">' + returnHtml.substring(startDetailsValues, endDetailsValues) + '</div>';
        $("#organDetailsValues-wrapper").append(divOrganDescription);

        $("#organDetailsValues-wrapper > div").hide();
        $("div." + _currentOrganDescription).show();
    });
}

/*** End ExamDescription ***/


/*** Start ExamDescriptionValue ***/

function addNewExamDescriptionValue() {

    if (!editExamDescriptionValueDone($("div." + _currentOrganDescription + " ul").find(".spaneditdone"))) {
        return false;
    }

    var newLiClass = "even";
    var lastLiClass = $("[id$='organDetailsValues-wrapper'] > div").last().find("ul").find("li").last().attr("class");
    if (lastLiClass == "even") {
        newLiClass = "odd";
    }

    var organDescriptionValueHtml = '<li class="' + newLiClass + '">';
    organDescriptionValueHtml += '<input type="text" class="organ-text-box"/>';
    organDescriptionValueHtml += '<div class="action-div">';
    organDescriptionValueHtml += '<span class="spaneditdone" title="Edit Done" style="margin: 0 5px 0 0;" onclick="editExamDescriptionValueDone(this);"></span>';
    organDescriptionValueHtml += '<span class="spandelete" title="Delete Record" onclick="deleteExamDescriptionValue(this);"></span>';
    organDescriptionValueHtml += '<input type="hidden" class="hdnOrganValueId" value="0" />';
    organDescriptionValueHtml += '<input type="hidden" class="hdnOrgansDetailsId" value="0" />';
    organDescriptionValueHtml += '</div>';
    organDescriptionValueHtml += '</li>';

    $("div." + _currentOrganDescription + " ul").append(organDescriptionValueHtml);
    return true;
}

function editExamDescriptionValueDone(elem) {

    if (!validateOrgan()) {
        return false;
    }

    //    if ($("#" + _currentOrgan).find("input[type='text']").length > 0) {
    //        var currentOrganName = $.trim($("#" + _currentOrgan).find("input[type='text']").val());
    //        if (currentOrganName == "") {
    //            alert("Exam name cannot be empty!");
    //            return false;
    //        }
    //    }


    if (!validateExamDescription()) {
        return false;
    }

    //    if ($("#" + _currentOrganDescription).find("input[type='text']").length > 0) {
    //        var currentOrganDescriptionName = $.trim($("#" + _currentOrganDescription).find("input[type='text']").val());
    //        if (currentOrganDescriptionName == "") {
    //            alert("Exam description name cannot be empty!");
    //            return false;
    //        }
    //    }

    var organDescriptionValueName = "";

    var organDescriptionValueNameLi = $(elem).closest("li");
    if (organDescriptionValueNameLi.find("input[type='text']").length > 0) {
        organDescriptionValueName = $.trim(organDescriptionValueNameLi.find("input[type='text']").val());
        if (organDescriptionValueName == "") {
            alert("Value cannot be empty!");
            return false;
        }
    }

    var organDescriptionValueSpan = '<span class="name">' + organDescriptionValueName + '</span>';

    organDescriptionValueNameLi.find(".organ-text-box").replaceWith(organDescriptionValueSpan);

    var editIcon = '<span class="spanedit" title="Edit Record" style="margin: 0 5px 0 0;" onclick="editExamDescriptionValue(this);"></span>';
    $(elem).replaceWith(editIcon);

    return true;
}

function editExamDescriptionValue(elem) {

    if (!editExamDescriptionValueDone($("div." + _currentOrganDescription + " ul").find(".spaneditdone"))) {
        return false;
    }

    var organDescriptionValueNameLi = $(elem).closest("li");
    var organDescriptionValueName = $.trim(organDescriptionValueNameLi.find(".name").html());
    var organDescriptionValueInput = '<input type="text" class="organ-text-box" value="' + organDescriptionValueName + '" />';
    organDescriptionValueNameLi.find("span.name").replaceWith(organDescriptionValueInput);
    var editIcon = '<span class="spaneditdone" title="Ok" style="margin: 0 5px 0 0;" onclick="editExamDescriptionValueDone(this);"></span>';
    $(elem).replaceWith(editIcon);

    return true;
}

function deleteExamDescriptionValue(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (isConfirm) {

        var RecordId = $(elem).parent().find(".hdnOrganValueId").val();
        var action = "DELETE";
        var Flag = "OrganValue";
        $.post(_SettingsPath + "/CallBacks/PhysicalExamHandler.aspx", { RecordId: RecordId, action: action, Flag: Flag }, function (data) {
            $(elem).closest("li").remove();
            alert("Record Deleted!");
        });

    }
}

/*** End ExamDescriptionValue ***/


function savePhysicalExam() {

    var listOrgan = new Array();

    $("#PhysicialExamList li").each(function () {
        var objOrgan = new Object();

        objOrgan.OrganId = $(this).find(".hdnOrganId").val();

        if ($(this).find("span.name").length > 0) {
            objOrgan.OrganName = $.trim($(this).find("span.name").html());
        }
        else {
            objOrgan.OrganName = $.trim($(this).find("input[type='text']").val());
        }

        if (objOrgan.OrganName.length > 2) {
            var organCode = objOrgan.OrganName.substring(0, 3);
        }
        else {
            organCode = objOrgan.OrganName;
        }

        objOrgan.OrganCode = organCode;

        var currentOrgan = $(this).attr("id");
        var listOrgansDetails = new Array();
        $("#examDescription-wrapper ." + currentOrgan + " ul li").each(function () {
            var objOrgansDetails = new Object();

            objOrgansDetails.OrgansDetailsId = $(this).find(".hdnOrgansDetailsId").val();
            objOrgansDetails.OrganCode = objOrgan.OrganCode;

            if ($(this).find("span.name").length > 0) {
                objOrgansDetails.OrganDetailDescription = $.trim($(this).find("span.name").html());
            }
            else {
                objOrgansDetails.OrganDetailDescription = $.trim($(this).find("input[type='text']").val());
            }

            var currentOrgansDetails = $(this).attr("id");
            var listOrganDetailsValues = new Array();

            $("#organDetailsValues-wrapper ." + currentOrgansDetails + " ul li").each(function () {
                var objOrganDetailsValues = new Object();

                objOrganDetailsValues.OrganValueId = $(this).find(".hdnOrganValueId").val();
                objOrganDetailsValues.OrgansDetailsId = objOrgansDetails.OrgansDetailsId;

                if ($(this).find("span.name").length > 0) {
                    objOrganDetailsValues.Value = $.trim($(this).find("span.name").html());
                }
                else {
                    objOrganDetailsValues.Value = $.trim($(this).find("input[type='text']").val());
                }

                listOrganDetailsValues.push(objOrganDetailsValues);
            });

            objOrgansDetails.listOrganDetailsValues = listOrganDetailsValues;
            listOrgansDetails.push(objOrgansDetails);
        });

        objOrgan.listOrgansDetails = listOrgansDetails;
        listOrgan.push(objOrgan);

    });

    var action = "SAVE";

    $.post(_SettingsPath + "/CallBacks/PhysicalExamHandler.aspx", { listOrgan: JSON.stringify(listOrgan), action: action }, function (data) {
        alert("Success: Physical Exam settings saved!");
    });
}



/****************************************** End Physical Exam ************************************/





//**///**************Rizwan kharal *************************/////////////
// 24 Nov 2017
function showPractiseUsers() {
    debugger;
    $("#divRightsSettings").hide();
    $(".setting-content-wrapper").hide();
    $(".divMesg").hide();
    $("#divTicketing").hide();
    $("#divInsuranceEnrollment").hide();
    $("#divInsuranceCredentialingWrapperId").hide();
    $(".contents-details-header").html("Practice Users");
    if (!checkModuleRights("PracticeUsersView")) {
        $("[id$='divRightsSettings']").html(_msg_PracticeUserView).show();
        return;
    }
    $.post("../Settings/CallBacks/PracticeUsers.aspx", function (data) {
        var startIndex = data.indexOf("###StartUsers###") + 16;
        var lastIndex = data.indexOf("###EndUsers###");
        var returnValue = $.trim(data.substring(startIndex, lastIndex));
        $("#divUsersMain").html(returnValue).show();
        
        GeneratePaging($("[id$='hdnUsersTotalCount']").val(), $("#ddlPagingUsers").val(), "divUsers", "FilterUsers");
        if ($("[id$='hdnUsersTotalCount']").val() > 0) {
            $("#divUsers .spanInfo").html("Showing " + $(".UsersList tr:first").children().first().html() + " to " + $(".UsersList tr:last").children().first().html() + " of " + $("[id$='hdnUsersTotalCount']").val() + " entries");
        }

        $(".phone").mask("(999) 999-9999");
    }).done(function () {
        $("#title").text("Practice Users");

        $("#UserRolesDiv").hide();
   });
}
function OpenUserRoles() {
    $(".divMesg").hide();
    $("#divTicketing").hide();
    $("#divUsersMain").hide();
    $("#divInsuranceCredentialingWrapperId").hide();
    $("#divInsuranceEnrollment").hide();
    debugger; 
    if (checkModuleRights("UserRoleView")) {
        $.post("../UserRights/UserRoles.aspx",
            function (data) {
                debugger;
                var returnHtml = data;
                var start = data.indexOf("###StartRoles###") + 16;
                var end = data.indexOf("###EndRoles###");
                $("#UserRolesDiv").html(returnHtml.substring(start, end));
                if ($("#RolesList tr").length == 0) {
                    $("#RolesList").html("<tr><td colspan='2' style='text-align:center;border-right:none'><span style='color: red;font-size: 14px;font-weight: bold;font-style: italic;'>No record found.<span></td></tr>");
                }
                $(".dropDownMenu input").attr("disabled", "disabled");
                //            $("#RolesList").find("[id$='tr_1']").find("span.spndelete").remove();
                //            $("#RolesList").find("[id$='tr_1']").find("span.spnedit").remove();

            }
        ).done(function () {
            $("#divUsersMain").hide();
            $("#UserRolesDiv").show();
            $("#divTicketing").hide();
            $("#title").text("Users Roles");
        });
    }
    else {
        $("[id$='divRightsSettings']").html("You don't have rights to View Users Roles").show();
    }
}
function OpenUserRights() {
    debugger;
    $("#divUsersMain").hide(); 
    $("#divTicketing").hide();
    $(".setting-content-wrapper").hide();
    $("#divRightsSettings").hide();
    $("#divInsuranceCredentialingWrapperId").hide();
    $("#divInsuranceEnrollment").hide();
    $(".contents-details-header").html('User Rights');
    $("#divPracticeRoleAndRights").show();
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("UserRightView")) {
        debugger;
        $.post("../UserRights/UserRights.aspx",
           
        function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartUserRights") + 18;
            var end = data.indexOf("###EndUserRights");
            $("#UserRolesDiv").html(returnHtml.substring(start, end));
            $(".dropDownMenu input").attr("disabled", "disabled");
        }
    ).done(function () {
        $("#divUsersMain").hide();
        $("#UserRolesDiv").show();
        $("#title").text("Users Rights");
        $("#divTicketing").hide();
    });
    } else {
        $("[id$='divRightsSettings']").html(_msg_UserRightView).show();
    }




    //    $.post("../UserRights/UserRights.aspx",
    //    function (data) {
    //        debugger;
    //        var returnHtml = data;
    //        var start = data.indexOf("###StartUserRights") + 18;
    //        var end = data.indexOf("###EndUserRights");
    //        $("#UserRolesDiv").html(returnHtml.substring(start, end));
    //        $(".dropDownMenu input").attr("disabled", "disabled");
    //    }
    //);
   
}

function FilterUsers(pageNumber, paging) {
    debugger;
    $.post("../Settings/CallBacks/PracticeUsersHandler.aspx", { Rows: $("#ddlPagingUsers").val(), PageNumber: pageNumber, SortBy: "Name", action: 'FilterUsers' }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 20;
        var end = data.indexOf("###End###");
        $(".UsersList").html(returnHtml.substring(start, end));
        debugger;
        if (paging == true) {
            GeneratePaging($("[id$='hdnUsersTotalCount']").val(), $("#ddlPagingUsers").val(), "divUsers", "FilterUsers");
        }
        if ($("[id$='hdnUsersTotalCount']").val() > 0) {
            $("#divUsers .spanInfo").html("Showing " + $(".UsersList tr:first").children().first().html() + " to " + $(".UsersList tr:last").children().first().html() + " of " + $("[id$='hdnUsersTotalCount']").val() + " entries");
        }
    

    });
}

//************************* End ******************************************

/************************************** Start Appointment Types ***********************************/

function showAppointmentTypes() {
    $(".contents-details-header").html('Appointment Types');
    $(".setting-content-wrapper").hide();
    $("#divAppointmentTypesMain").show();
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("AppointmentTypesView")) {
        $("[id$='divRightsSettings']").html(_msg_AppointmentTypesView).show();
        return false;
    }
    if ($.trim($("#divAppointmentTypesMain").html()).length == 0) {
        $.post('CallBacks/AppointmentTypesHandler.aspx', {}, function (data) {
            var start = data.indexOf("###StartAppointmentType###") + 26;
            var end = data.indexOf("###EndAppointmentType###");
            $("#divAppointmentTypesMain").html(data.substring(start, end));
            generateAppointmentTypesPagging();
            $("[id$='divRightsSettings']").hide();
            if (checkModuleRights("AppointmentTypesView")) {
                $("#gridAppointmentTypes").show();
            } else {
                $("[id$='divRightsSettings']").html(_msg_AppointmentTypesView).show();
            }
        });
    }

}

function generateAppointmentTypesPagging() {
    GeneratePaging($("[id$='hdnAppointmentTypesTotalRows']").val(), $("#ddlPagingAppointmentTypes").val(), "gridAppointmentTypes", "FilterAppointmentTypes");
    if ($("[id$='hdnAppointmentTypesTotalRows']").val() > 0)
        $("#gridAppointmentTypes .spanInfo").html("Showing " + $("#gridContentsAppointmentTypes tr:first").children().first().html() + " to " + $("#gridContentsAppointmentTypes tr:last").children().first().html() + " of " + $("[id$='hdnAppointmentTypesTotalRows']").val() + " entries");
}

function FilterAppointmentTypes(pageNumber, paging) {
    $("[id$='divRightsSettings']").hide();
    var type = $.trim($("#txtAppointmentTypeFilter").val());
    var defaultTime = $("[id$='ddlDefaultTimeFilter']").val();
    $.post(_SettingsPath + "/CallBacks/AppointmentTypesFilterHandler.aspx", { type: type, defaultTime: defaultTime, Rows: $("#ddlPagingAppointmentTypes").val(), PageNumber: pageNumber }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsAppointmentTypes").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnAppointmentTypesTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            generateAppointmentTypesPagging();
        }

        if ($("[id$='hdnAppointmentTypesTotalRows']").val() > 0)
            $("#gridAppointmentTypes .spanInfo").html("Showing " + $("#gridContentsAppointmentTypes tr:first").children().first().html() + " to " + $("#gridContentsAppointmentTypes tr:last").children().first().html() + " of " + $("[id$='hdnAppointmentTypesTotalRows']").val() + " entries");
    });
}

function AddNewAppointmentType() {
    $("[id$='hdnAppointmentTypeId']").val("0");
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("AppointmentTypesAdd")) {
        $("#divDialogAddAppointmentType").dialog({
            title: "Add New Type",
            width: "500",
            modal: true,
            close: function () {
                $("#txtAppointmentReasonDescription").val("");
                $("[id$='ddlDefaultTime']").prop("selectedIndex", 2);
                $(this).dialog("destroy");
            }
        });
    } else {
        $("[id$='divRightsSettings']").html(_msg_AppointmentTypesAdd).show();
    }
}

function saveAppointmentType() {
    if (!ValidateForm("divDialogAddAppointmentType")) {
        showErrorMessage("");
        return;
    }
    var objAppointmentTypes = new Object();
    var appointmentTypeId = $("[id$='hdnAppointmentTypeId']").val();
    objAppointmentTypes.AppointmentTypeId = appointmentTypeId;
    objAppointmentTypes.AppointmentType = $("#txtAppointmentType").val();
    objAppointmentTypes.DefaultTime = $("[id$='ddlDefaultTime']").val();
    var action = appointmentTypeId != "0" ? "Update" : "Add";
    $.post(_SettingsPath + "/CallBacks/AppointmentTypesActionHandler.aspx", { objAppointmentTypes: JSON.stringify(objAppointmentTypes), action: action }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsAppointmentTypes").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnAppointmentTypesTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        generateAppointmentTypesPagging();
        if (appointmentTypeId == "0")
            showSuccessMessage(_msg_Created);
        else
            showSuccessMessage(_msg_Updated);
        cancelSaveAppointmentType();
    });
}
function editAppointmentType(elem, appointmentTypeId) {
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("AppointmentTypesEdit")) {
        var AppointmentType = $.trim($(elem).closest("tr").find("td:eq(1)").html());
        var DefaultTime = $.trim($(elem).closest("tr").find(".hdnDefaultTime").val());
        $("#txtAppointmentType").val(AppointmentType);
        $("[id$='hdnAppointmentTypeId']").val(appointmentTypeId);
        $("[id$='ddlDefaultTime']").val(DefaultTime);
        $("#divDialogAddAppointmentType").dialog({
            title: "Update Type",
            width: "500",
            modal: true,
            close: function () {
                $("#txtAppointmentReasonDescription").val("");
                $("[id$='ddlDefaultTime']").prop("selectedIndex", 2);
                $(this).dialog("destroy");
            }
        });
    } else {
        $("[id$='divRightsSettings']").html(_msg_AppointmentTypesEdit).show();
    }
}

function cancelSaveAppointmentType() {
    $("#txtAppointmentType").val("");
    $("[id$='ddlDefaultTime']").prop("selectedIndex", 2);
    $("#divDialogAddAppointmentType").dialog("close");
}

function deleteAppointmentType(appointmentTypeId) {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("AppointmentTypesDelete")) {
        $("[id$='divRightsSettings']").html(_msg_AppointmentTypesDelete).show();
        return false;
    }
    showConfirmDialog(_msg_Deleted_Confirmation, "deleteAppointment(" + appointmentTypeId + ");");
}

function deleteAppointment(appointmentTypeId) {
    $.post(_SettingsPath + "/CallBacks/AppointmentTypesActionHandler.aspx", { AppointmentTypeId: appointmentTypeId, action: "Delete" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsAppointmentTypes").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnAppointmentTypesTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
        generateAppointmentTypesPagging();
        showSuccessMessage(_msg_Deleted);
    });
}


/************************************** End Appointment Types ***********************************/


/************************Start Documents***************************/
function showDocuments() {
    if (!checkModuleRights("PatientDocumentsView")) {
        $("[id$='divRightsSettings']").html(_msg_PatientDocumentsView).show();
        return;
    }

    $.post(_SettingsPath + "/CallBacks/Documents.aspx", { PatientId: 0 }, function (data) {
        var start = data.indexOf("###StartDocument###") + 19;
        var end = data.indexOf("###EndDocument###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#divDocumentsMain").html(returnHtml)
        .promise()
        .done(function () {
            $(".setting-content-wrapper").hide();
            $(".contents-details-header").html('Documents');
            
            $("#divDocumentsMain").show();

            if ($("#tbodyDocumentCategory tr").length > 0) {
                $("#tbodyDocumentCategory tr").eq(0).addClass("row-selected");
                _currentDocumentCategoryRow = $("#tbodyDocumentCategory tr").eq(0);
            }
        });
    });
}
/************************End Documents*****************************/


/************************Start Templates*****************************/

function showTemplates() {
    $(".contents-details-header").html('Chart Templates');
    $(".setting-content-wrapper").hide();
    $("#divTemplatesMain").show();
    $("[id$='divRightsSettings']").hide();

    if (!checkModuleRights("ChartTemplatesView")) {
        $("[id$='divRightsSettings']").html(_msg_ChartTemplatesView).show();
        return false;
    }

    if ($.trim($("#divTemplatesMain").html()).length == 0) {
        $.post('CallBacks/ChartTemplatesHandler.aspx', {}, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartChartTemplates###") + 25;
            var end = data.indexOf("###EndChartTemplates###");
            $("#divTemplatesMain").html(data.substring(start, end));
            $("#divAllTemplates").show();
            generateChartsTemplatesPagging();
        });
    }
}
function AddNewTemplate() {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("ChartTemplatesAdd")) {
        $("[id$='divRightsSettings']").html(_msg_ChartTemplatesAdd).show();
        return false;
    }
    $("#divAddEditChartTemplate :text, #divAddEditChartTemplate textarea").val("");
    $("#divAddEditChartTemplate select").prop("selectedIndex", 0);
    $("[id$='hdnChartTemplateId']").val("0");
    $(".cbTemplateShared input").prop("checked", false);
    $("#divAddEditChartTemplate").dialog({
        title: "Add Template",
        width: "700",
        modal: true,
        close: function () {
            $(this).dialog("destroy");
        }
    });
}



function EditTemplate(templateId, elem) {
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("ChartTemplatesEdit")) {
        $("[id$='divRightsSettings']").html(_msg_ChartTemplatesEdit).show();
        return false;
    }
    var templateName = $.trim($(elem).closest("tr").find(".TemplateName").html());
    var templatetype = $.trim($(elem).closest("tr").find(".TemplateType").html());
    var templatetext = $.trim($(elem).closest("tr").find(".TemplateText").val());
    var shared = $.trim($(elem).closest("tr").find(".cbTemplateShared").val());
    $("[id$='ddlTemplateType']  option").each(function () {
        if ($(this).val() == templatetype) {
            $(this).prop("selected", true);
            return;
        }
    })
    $("#txtTemplateName").val(templateName);
    $("#txtTemplateText").val(templatetext);
    $("[id$='hdnChartTemplateId']").val(templateId);
    shared = shared == "True" ? true : false;
    $(".cbTemplateShared input").prop("checked", shared);
    $("#divAddEditChartTemplate").dialog({
        title: "Add Template",
        width: "700",
        modal: true,
        close: function () {
            $(this).dialog("destroy");
        }
    });
}

function saveTemplate() {
    if (!ValidateForm("tblAddEdit")) {
        showErrorMessage("");
        return;
    }
    var objChartTemplate = new Object();
    var ChartTemplateId = $("[id$='hdnChartTemplateId']").val();
    objChartTemplate.ChartTemplateId = ChartTemplateId;
    objChartTemplate.TemplateName = $("#txtTemplateName").val();
    objChartTemplate.TemplateType = $("[id$='ddlTemplateType']").val();
    objChartTemplate.TemplateText = $("#txtTemplateText").val();
    objChartTemplate.Shared = $(".cbTemplateShared input").is(":checked");
    $.post(_SettingsPath + "/CallBacks/ChartsTemplatesFilterHandler.aspx", { objChartTemplate: JSON.stringify(objChartTemplate), action: "AddEdit" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#listChartsTemplates").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTemplatesTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
        generateChartsTemplatesPagging();

        if (ChartTemplateId == "0")
            showSuccessMessage(_msg_Created);
        else
            showSuccessMessage(_msg_Updated);
        cancelsaveTemplate();
    });
}

function cancelsaveTemplate() {
    $("#divAddEditChartTemplate :text, #divAddEditChartTemplate textarea").val("");
    $("#divAddEditChartTemplate select").prop("selectedIndex", 0);
    $("[id$='hdnChartTemplateId']").val("0");
    $(".cbTemplateShared input").prop("checked", false);
    $("#divAddEditChartTemplate").dialog("close");
}

function DeleteTemplate(templateId) {
    if (!checkModuleRights("ChartTemplatesDelete")) {
        $("[id$='divRightsSettings']").html(_msg_ChartTemplatesDelete).show();
        return false;
    }
    showConfirmDialog(_msg_Deleted_Confirmation, "funDeleteTemplate(" + templateId + ");");
}

function funDeleteTemplate(templateId) {
    $.post(_SettingsPath + "/CallBacks/ChartsTemplatesFilterHandler.aspx", { ChartTemplateId: templateId, action: "Delete" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#listChartsTemplates").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTemplatesTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
        generateChartsTemplatesPagging();
        showSuccessMessage(_msg_Deleted);
    });
}

function generateChartsTemplatesPagging() {
    GeneratePaging($("[id$='hdnTemplatesTotalRows']").val(), $("#ddlPagingChartsTemplates").val(), "gridChartsTemplates", "FilterChartsTemplates");
    if ($("[id$='hdnTemplatesTotalRows']").val() > 0)
        $("#gridChartsTemplates .spanInfo").html("Showing " + $("#listChartsTemplates tr:first").children().first().html() + " to " + $("#listChartsTemplates tr:last").children().first().html() + " of " + $("[id$='hdnTemplatesTotalRows']").val() + " entries");
}

function FilterChartsTemplates(pageNumber, paging) {
    $("[id$='divRightsSettings']").hide();
    var templateName = $.trim($("#txtTemplateNameFilter").val());
    var templateText = $.trim($("#txtTemplateTextFilter").val());
    var type = $("[id$='ddlTemplateTypeFilter']").val();
    $.post(_SettingsPath + "/CallBacks/ChartsTemplatesFilterHandler.aspx", { templateName: templateName, templateText: templateText, type: type, Rows: $("#ddlPagingChartsTemplates").val(), PageNumber: pageNumber, action: "filter" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#listChartsTemplates").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTemplatesTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            generateChartsTemplatesPagging();
        }

        if ($("[id$='hdnTemplatesTotalRows']").val() > 0)
            $("#gridChartsTemplates .spanInfo").html("Showing " + $("#listChartsTemplates tr:first").children().first().html() + " to " + $("#listChartsTemplates tr:last").children().first().html() + " of " + $("[id$='hdnTemplatesTotalRows']").val() + " entries");
    });
}
/************************End Templates*****************************/


/************************Start Lab Order Types*****************************/

function showLabOrderGroups() {
    $(".contents-details-header").html('Lab Order Groups');
    $(".setting-content-wrapper").hide();
    $("#divLabOrderMain").show();
    $("[id$='divRightsSettings']").hide();
    //    if (!checkModuleRights("ChartTemplatesView")) {
    //        $("[id$='divRightsSettings']").html(_msg_ChartTemplatesView).show();
    //        return false;
    //    }
    if ($.trim($("#divTemplatesMain").html()).length == 0) {
        $.post('CallBacks/LabOrderTypesHandler.aspx', function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartLabOrder###") + 19;
            var end = data.indexOf("###EndLabOrder###");
            $("#divLabOrderMain").html(data.substring(start, end));
            $("#divAllLabOrderGroups").show();
        });
    }
}

var _flagChangeLabOrder = false;

function AddNewLabOrderGroup() {
    $("#divAddEditGroup").dialog({
        title: "Add Lab Test Group",
        width: "600",
        modal: true,
        close: function () {
            ResetLabGroupForm();
            $(this).dialog("destroy");
        }
    });
}

function ResetLabGroupForm() {
    $("#txtLabTestGroupName").val("");
    $("#hdnLabTestGroupId").val("0");
}

function cancelsaveLabGroup() {
    $("#txtLabTestGroupName").removeClass("error");
    $("#divAddEditGroup").dialog("close");
}

function saveLabGroup() {
    if ($.trim($("#txtLabTestGroupName").val()) == "") {
        $("#txtLabTestGroupName").addClass("error");
        showErrorMessage("Please provider lab test group name!");
        return false;
    }
    var objLabGroups = new Object();
    objLabGroups.Name = $("#txtLabTestGroupName").val();
    objLabGroups.LabTestGroupId = $("#hdnLabTestGroupId").val();
    $.post(_SettingsPath + "/CallBacks/LabOrderTypesActionHandler.aspx", { objLabGroups: JSON.stringify(objLabGroups), action: "AddEdit" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#listLabOrderGroup").html(returnHtml.substring(start, end));
        $("#divAddEditGroup").dialog("close");
        showSuccessMessage(_msg_Updated);
    });
}

function editLabTestGroup(groupname, groupId) {
    $("#txtLabTestGroupName").val(groupname);
    $("#hdnLabTestGroupId").val(groupId);
    $("#divAddEditGroup").dialog({
        title: "Edit Lab Test Group",
        width: "600",
        modal: true,
        close: function () {
            $(this).dialog("destroy");
        }
    });
}

function deleteLabTestGroup(groupId) {
    $.post(_SettingsPath + "/CallBacks/LabOrderTypesActionHandler.aspx", { LabTestGroupId: groupId, action: "Delete" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#listLabOrderGroup").html(returnHtml.substring(start, end));
        showSuccessMessage(_msg_Deleted);
    });
}

function getLabTestGroupDetails(groupId, elem) {
    $("#listLabOrderGroup tr").removeClass("trSelected");
    $(elem).addClass("trSelected");
    $.post(_SettingsPath + "/CallBacks/LabOrderGroupDetailsHandler.aspx", { groupid: groupId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#listGroupOrderDetails").html(returnHtml.substring(start, end));
    });
}

function searchCPTs(searchBy) {
    if (searchBy == "C")
        $("#txtCPTDescSearch").val('');
    else
        $("#txtCPTCodeSearch").val('');

    if ($.trim($("#txtCPTCodeSearch").val()) == "" && $.trim($("#txtCPTDescSearch").val()) == "") {
        $("#divCPTsSearched").hide();
        return false;
    }
    $.post(_SettingsPath + "/CallBacks/CPTCodeSearch.aspx", { Code: $.trim($("#txtCPTCodeSearch").val()), Description: $.trim($("#txtCPTDescSearch").val()) }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartCPTSearch###") + 20;
        var end = data.indexOf("###EndCPTSearch###");
        $("#divCPTsSearched").html(returnHtml.substring(start, end));
        $("#divCPTsSearched").show();
    });
}

function SelectCPT(elem) {
    _flagChangeLabOrder = true;
    var groupid = $("#listLabOrderGroup tr.trSelected").find(".LabTestGroupId").val();
    var groupName = $("#listLabOrderGroup tr.trSelected").find(".Name").val();
    if (groupid != null) {
        var cptCount = 0;
        var cptCode = $.trim($(elem).find(".cpt-code").html());
        var cptDesc = $.trim($(elem).find(".cpt-description").html());
        var CPTID = $.trim($(elem).find(".CPTID").val());
        $("#listGroupOrderDetails tr").each(function () {
            if (CPTID != 0 && $.trim($(this).find(".LabTestId").val()) == $.trim(CPTID)) {
                cptCount++;
                return false;
            }
        });
        if (cptCount == 0) {
            addTest($.trim(cptCode), $.trim(cptDesc), groupid, groupName, $.trim(CPTID));
        }
        $("#divCPTsSearched").hide();
        $("#txtCPTDescSearch").val("");
        $("#txtCPTCodeSearch").val("");
    }
    else {
        showErrorMessage("Please select a group!")
        return false;
    }
    if (_flagChangeLabOrder) {
        $("#btnSaveLabGrop").show();
    }
    else {
        $("#btnSaveLabGrop").hide();
    }
}
function addTest(code, description, groupId, groupName, labTestId) {
    _flagChangeLabOrder = true;
    var cptCount = 0;
    $("#listGroupOrderDetails tr").each(function () {
        if (labTestId != 0 && $.trim($(this).find(".LabTestId").val()) == $.trim(labTestId)) {
            cptCount++;
            return false;
        }
    });
    if (cptCount == 0) {
        var tblSummaryRow = "";
        tblSummaryRow += "<tr>";
        tblSummaryRow += "<td>" + groupName + "</td>";
        tblSummaryRow += "<td class='cptCode' style='text-align:center;'>" + code + "</td>";
        tblSummaryRow += "<td>" + description + "</td>";
        tblSummaryRow += "<td style='text-align: center;'><span class='spndelete' onclick='deleteLabTestDetails(this)'></span></td>";
        tblSummaryRow += "<td style='display: none;'><input class='LabTestGroupDetailId' value='0' type='hidden' />";
        tblSummaryRow += "<input class='LabTestGroupId' value='" + groupId + "' type='hidden' />";
        tblSummaryRow += "<input class='HcpcsCode' value='" + code + "' type='hidden' />";
        tblSummaryRow += "<input class='LabTestId' value='" + labTestId + "' type='hidden' />";
        tblSummaryRow += "<input class='Deleted' value='false' type='hidden' />";
        tblSummaryRow += "</td></tr>";
        $("#listGroupOrderDetails").append(tblSummaryRow);
    }
    if (_flagChangeLabOrder) {
        $("#btnSaveLabGrop").show();
    }
    else {
        $("#btnSaveLabGrop").hide();
    }
}

function deleteLabTestDetails(elem) {
    _flagChangeLabOrder = true;
    var LabTestGroupDetailId = $(elem).closest('tr').find(".LabTestGroupDetailId").val();
    if (LabTestGroupDetailId == "0") {
        $(elem).closest('tr').remove();
    } else {
        $(elem).closest('tr').find(".Deleted").val("true");
        $(elem).closest('tr').hide();
    }

    if (_flagChangeLabOrder) {
        $("#btnSaveLabGrop").show();
    } else {
        $("#btnSaveLabGrop").hide();
    }
}

function saveLabTestGroupDetails() {
    var arrGroupOrderDetails = new Array();
    if ($("#listGroupOrderDetails tr").length > 0) {
        $("#listGroupOrderDetails tr").each(function () {
            var objGroupOrderDetails = new Object();
            objGroupOrderDetails.LabTestGroupDetailId = $(this).find(".LabTestGroupDetailId").val();
            objGroupOrderDetails.HcpcsCode = $(this).find(".HcpcsCode").val();
            objGroupOrderDetails.LabTestId = $(this).find(".LabTestId").val();
            objGroupOrderDetails.Deleted = $(this).find(".Deleted").val();
            arrGroupOrderDetails.push(objGroupOrderDetails);
        });
    }

    var groupid = $("#listLabOrderGroup tr.trSelected").find(".LabTestGroupId").val();
    $.post(_SettingsPath + "/CallBacks/LabOrderGroupDetailsHandler.aspx", { arrGroupOrderDetails: JSON.stringify(arrGroupOrderDetails), groupid: groupid, action: "AddEdit" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#listGroupOrderDetails").html(returnHtml.substring(start, end));
        showSuccessMessage(_msg_Updated);
    });
    _flagChangeLabOrder = false;
    $("#btnSaveLabGrop").hide();

}

/************************End Lab Order Types*****************************/

function ShowConfirmation(message) {
    var def = $.Deferred();

    $("#divDialogConfirmationMaster").html(message).dialog({
        modal: true,
        width: 'auto',
        height: 'auto',
        buttons: {
            "Yes": function () {
                $("#divDialogConfirmationMaster").dialog("close");
                def.resolve();
            },
            "No": function () {
                $("#divDialogConfirmationMaster").dialog("close");
                def.reject();
            }
        }
    });
    return def.promise();
}


/*** End Right side functions ***/
/* End Practice Documents */


//Changes By Syed Sajid Ali Date:10-09-2019
function SaveUpdateUser(elem, UserId, Action) {
    debugger;
    var title = "";
    var UserRoleId = "";
    if (Action == "Update") { title = "Update User"; UserRoleId = $(elem).closest("tr").find(".hdnUserRoleId").val(); }
    else { title = "Add User", UserId = 0; UserRoleId = 0; }
    var HandlerAddress = "../Settings/CallBacks/PracticeUsers.aspx";
    $.post(HandlerAddress, { action: Action, UserId: UserId, UserRoleId: UserRoleId }, function (data) {
        debugger
        var returnHtml = data;
        var start = data.indexOf("###startAddUser###") + 18;
        var end = data.indexOf("###EndAddUser###");
        $(".divUserAddEdit").html(returnHtml.substring(start, end));


        $(".divUserAddEdit").dialog({
            title: title,
            modal: true,
            resizable: false,
            width: "1000px",
            close: function () {
                $(".divUserAddEdit").dialog("destroy");
            },
            buttons: {
                "Update/Save": function () {
                    debugger;
                    if (!ValidateForm("tblUsers")) {
                        showErrorMessage("");
                        return false;
                    }
                    var hdnAlreadyExistUser = $("#hdnAlreadyExistUser").val()
                    if (hdnAlreadyExistUser != "" && hdnAlreadyExistUser != null && Action!="Update") {
                        showErrorMessage("Error: User Name already exist.");
                        $("#txtUserName").addClass("error");
                        return false;
                    }

                    if ($.trim($("#txtPassword").val()) != $.trim($("#txtConfirmPassword").val())) {
                        showErrorMessage("Error: Password and Confirm Password does not match.");
                        $("#txtConfirmPassword").addClass("error");
                        return false;
                    }
                    if ($.trim($("[id$='txtEmail']").val())!="")
                    if (!validateEmail($.trim($("[id$='txtEmail']").val()))) {
                        $("[id$='txtEmail']").addClass("error");
                        showErrorMessage("Error: Enter valid email address.");
                        return false;
                    }
                    saveUser(UserId, UserRoleId);
                    $(".divUserAddEdit").dialog("destroy");
                },
                "Cancel": function () {
                    $(".divUserAddEdit").dialog("destroy");
                }
            }
        });
        $(".phone").mask("(999) 999-9999");
        var Pass = $("#hdnPassord").val();
        if (Pass == "0" || Pass == "") { $("#txtPassword").val(); $("#txtConfirmPassword").val(); }
        else {
            $("#txtPassword").val(Pass);
            $("#txtConfirmPassword").val(Pass);
        }
    });

}

function saveUser(UserId, UserRoleId) {
   
    $(".divMesg").hide();
    var objPracticeUsers = new Object();
    objPracticeUsers.UserId = _userId;
    objPracticeUsers.FirstName = $.trim($("#txtUserFName").val());
    objPracticeUsers.MiddleName = $.trim($("#txtUserMName").val());
    objPracticeUsers.LastName = $.trim($("#txtUserLName").val());
    objPracticeUsers.PracticeLocationsId = $("[id$='ddlPracticeLocationsUsers']").val();
    objPracticeUsers.IsActive = $("#chkUserStauts").is(":checked");
    objPracticeUsers.ProfilePicturePath = $.trim($("[id$='hdnImageUser']").val());

    objPracticeUsers.UserName = $.trim($("#txtUserName").val());
    objPracticeUsers.Password = $.trim($("#txtPassword").val());

    objPracticeUsers.EmailAddress = $.trim($("#txtEmail").val());
    objPracticeUsers.PhoneNumber = $.trim($("#txtPhone").val());

    objPracticeUsers.ServiceProviderId = $("#hdnProviderIdInUser").val();
    var Password=  $("#txtPassword").val();
    var Rows = $("#ddlPagingUsers").val();
    var PageNumber = 0;
    var RoleId = $("[id$='ddlUsersRoles']").val();
  
    $.post("../Settings/CallBacks/PracticeUsersHandler.aspx", {
        User: JSON.stringify(objPracticeUsers),
        Rows: Rows, PageNumber: PageNumber, UserId: UserId, UserRoleId: RoleId, Password: Password, action: 'Save User'
    }, function (data) {
        if (UserId == 0) {
            showSuccessMessage("Record saved successfully!");
        }
        else {
            showSuccessMessage("Record updated successfully!");
        }

        var startIndex = data.indexOf("###Start###") + 11;
        var lastIndex = data.indexOf("###End###");
        var returnValue = $.trim(data.substring(startIndex, lastIndex));
        $("#UsersList").html(returnValue);
        GeneratePaging($("[id$='hdnUsersTotalCount']").val(), $("#ddlPagingUsers").val(), "divUsers", "FilterUsers");
        if ($("[id$='hdnUsersTotalCount']").val() > 0) {
            $("#divUsers .spanInfo").html("Showing " + $("#UsersList tr:first").children().first().html() + " to " + $("#UsersList tr:last").children().first().html() + " of " + $("[id$='hdnUsersTotalCount']").val() + " entries");
        }
    });
}

function GetAlreadyExixtUser() {
    var UName = $("#txtUserName").val();
    $.post("../Settings/CallBacks/PracticeUsers.aspx",
        {
            UName: UName, action: "CheckAlreadyExistUser"
        },
            function (data) {
                debugger;
                var start = data.indexOf("###SUserAExist###") + 17;
                var end = data.indexOf("###EUserAExist###");
                var returnHtml = $.trim(data.substring(start, end));
                $(".UAExist").html(returnHtml)
      });
}

function DeletePractieUser(elem, UserId, action) {
    var message = "";
    if (action == "Delete") { message = "Do you want to Delete this user?" } else { message = "Do you want to Inactive this user?" }
    $('<div></div>').appendTo('body')
           .html('<div><h5></h5>' + message + '</div>')
           .dialog({
               modal: true, title: 'Confirmation!', zIndex: 10000, autoOpen: true,
               width: '300px', resizable: false,
               buttons: {
                   Yes: function () {
                       $(this).dialog("close");
                       DeleteAssignPracticeUser(elem, UserId, action)
                   },
                   No: function () {
                       $(this).dialog("close");
                   }
               },
               close: function (event, ui) {
                   $(this).remove();
         }
   });
}

function DeleteAssignPracticeUser(elem,UserId, type) {
    debugger;
    var HandlerAddress = "../Settings/CallBacks/PracticeUsersHandler.aspx";
    var Rows = $("#ddlPagingUsers").val();
    var PageNumber = 0;
    $.post(HandlerAddress, { action: "DeleteAssignPracticeofUser", UserId: UserId, Rows: Rows, PageNumber: PageNumber, type: type },
        function (data) {
        if (type == "Delete") { showSuccessMessage("User Deleted successfully!"); }
        else { showSuccessMessage("User Inactive successfully!"); }

        var startIndex = data.indexOf("###Start###") + 11;
        var lastIndex = data.indexOf("###End###");
        var returnValue = $.trim(data.substring(startIndex, lastIndex));
        $("#UsersList").html(returnValue);
        GeneratePaging($("[id$='hdnUsersTotalCount']").val(), $("#ddlPagingUsers").val(), "divUsers", "FilterUsers");
        if ($("[id$='hdnUsersTotalCount']").val() > 0) {
            $("#divUsers .spanInfo").html("Showing " + $("#UsersList tr:first").children().first().html() + " to " + $("#UsersList tr:last").children().first().html() + " of " + $("[id$='hdnUsersTotalCount']").val() + " entries");
        }
    });
}

//Changes End:By Syed Sajid Ali Date:10-09-2019