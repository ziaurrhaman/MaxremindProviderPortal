

$(function () {
    $("[id$='txtStaffDOBNew']").datepicker({
        minDate: "01/01/1930",
        maxDate: new Date(),
        changeMonth: true,
        yearRange: "1930:" + new Date,
        changeYear: true
    }).mask("99/99/9999");
    
    $(".phone").mask("(999) 999-9999");
    
    generateStaffPagging();
});

//******************************Start Practice and Locations Section********************************//

function generateStaffPagging() {
    GeneratePaging($("[id$='hdnStaffTotalRows']").val(), $("#ddlPagingStaff").val(), "gridStaff", "FilterStaff");
    
    if ($("[id$='hdnStaffTotalRows']").val() > 0) {
        $("#gridStaff .spanInfo").html("Showing " + $("#gridContentsStaff tr:first").children().first().html() + " to " + $("#gridContentsStaff tr:last").children().first().html() + " of " + $("[id$='hdnStaffTotalRows']").val() + " entries");
    }
}

function FilterStaff(pageNumber, paging) {
    $.post(_SettingsPath + "/CallBacks/StaffFilterHandler.aspx", { Rows: $("#ddlPagingStaff").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsStaff").html(returnHtml.substring(start, end));
        
        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        
        $("[id$='hdnStaffTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
        
        if (paging == true) {
            generateStaffPagging();
        }
        else {
            if ($("[id$='hdnStaffTotalRows']").val() > 0) {
                $("#gridStaff .spanInfo").html("Showing " + $("#gridContentsStaff tr:first").children().first().html() + " to " + $("#gridContentsStaff tr:last").children().first().html() + " of " + $("[id$='hdnStaffTotalRows']").val() + " entries");
            }
        }
    });
}

function showPracticeDetails() {
    $(".contents-details-header").html('Practice Information');
    $(".setting-content-wrapper").hide();

    $("#linkPracticeInformationMain").click();

    $("#divPracticeMain").show();

    _LocationId = 0;

    if (!checkModuleRights("PracticeView")) {
        showErrorMessage(_msg_PracticeView);
    }
    
    $("[id$='divPracticeInformation']").show();
}

function showHidePracticeTabs(contentId) {
    $(".Tab-Content").hide();
    $("#" + contentId).show();

    if (contentId == "divPracticeInformationView") {
        if (!checkModuleRights("PracticeView")) {
            //showErrorMessage(_msg_PracticeView);
            //return;
        }

        $("[id$='divPracticeInformation']").show();
    }
    else if (contentId == "divStaffInformation") {
        if (!checkModuleRights("PracticeStaffView")) {
            //showErrorMessage(_msg_PracticeStaffView);
            //return;
        }

        $("#gridStaff").show();
    }
}

function savePracticeInformation() {
    if (!ValidateForm("tblPractice")) {
        showErrorMessage("");
        return;
    }

    var objPractices = new Object();
    objPractices.PracticeName = $.trim($("[id$='txtPracticeName']").val());
    objPractices.UPIN = $.trim($("[id$='txtUPIN']").val());
    objPractices.NPI = $.trim($("[id$='txtNPI']").val());
    objPractices.TaxID = $.trim($("[id$='txtTaxID']").val());
    objPractices.TaxonomyCode = $.trim($("[id$='txtTaxanomyCode']").val());
    objPractices.ContractType = $.trim($("[id$='txtContractType']").val());

    objPractices.Address = $.trim($("[id$='txtPracticeAddress']").val());
    objPractices.City = $.trim($("[id$='txtCity']").val());
    objPractices.State = $.trim($("[id$='ddlState']").val());
    objPractices.Zip = $.trim($("[id$='txtZipCode']").val());
    objPractices.ContactPersonName = $.trim($("[id$='txtContactPersonName']").val());
    objPractices.ContactPersonPhone = $.trim($("[id$='txtContactPhoneNumber']").val());
    objPractices.PracticeExt = $.trim($("[id$='txtPracticeExt']").val());

    $.post(_SettingsPath + "/CallBacks/SettingsHandler.aspx", { objPractices: JSON.stringify(objPractices), action: 'UpdatePractice' }, function (data) {
        loadPracticeInformationDetailsView();
        showSuccessMessage(_msg_Updated);
    });
}

function loadPracticeInformationDetailsView() {
    if (!checkModuleRights("PracticeView")) {
        showErrorMessage(_msg_PracticeView);
        return false;
    }

    $("[id$='lblPracticeName']").text($.trim($("[id$='txtPracticeName']").val()));
    $("[id$='lblUPIN']").text($.trim($("[id$='txtUPIN']").val()));
    $("[id$='lblNPI']").text($.trim($("[id$='txtNPI']").val()));
    $("[id$='lblTaxId']").text($.trim($("[id$='txtTaxID']").val()));
    $("[id$='lblTaxonomyCode']").text($.trim($("[id$='txtTaxanomyCode']").val()));
    $("[id$='lblContractType']").text($.trim($("[id$='txtContractType']").val()));

    $("[id$='lblPracticeAddress']").text($.trim($("[id$='txtPracticeAddress']").val()));
    $("[id$='lblCity']").text($.trim($("[id$='txtCity']").val()));
    $("[id$='lblState']").text($("[id$='ddlState'] option:selected").text());
    $("[id$='hdnStateCode']").val($("[id$='ddlState'] option:selected").val());
    $("[id$='lblZipCode']").text($.trim($("[id$='txtZipCode']").val()));
    $("[id$='lblContactPersonName']").text($.trim($("[id$='txtContactPersonName']").val()));
    $("[id$='lblContactPhoneNumber']").text($.trim($("[id$='txtContactPhoneNumber']").val()));
    $("[id$='lblPracticeExt']").text($.trim($("[id$='txtPracticeExt']").val()));

    $("#divPracticeInformationEdit").hide();
    $("#divPracticeInformationView").show();
}

function loadPracticeInformationEditView() {
    if (!checkModuleRights("PracticeEdit")) {
        showErrorMessage(_msg_PracticeEdit);
        return false;
    }

    $("[id$='txtPracticeName']").val($.trim($("[id$='lblPracticeName']").html()));
    $("[id$='txtUPIN']").val($.trim($("[id$='lblUPIN']").text()));
    $("[id$='txtNPI']").val($.trim($("[id$='lblNPI']").text()));
    $("[id$='txtTaxID']").val($.trim($("[id$='lblTaxId']").text()));
    $("[id$='txtTaxanomyCode']").val($.trim($("[id$='lblTaxonomyCode']").text()));
    $("[id$='txtContractType']").val($.trim($("[id$='lblContractType']").text()));

    $("[id$='txtPracticeAddress']").val($.trim($("[id$='lblPracticeAddress']").text()));
    $("[id$='txtCity']").val($.trim($("[id$='lblCity']").text()));
    $("[id$='ddlState']").val($("[id$='hdnStateCode']").val());
    $("[id$='txtZipCode']").val($.trim($("[id$='lblZipCode']").text()));
    $("[id$='txtContactPersonName']").val($.trim($("[id$='lblContactPersonName']").text()));
    $("[id$='txtContactPhoneNumber']").val($.trim($("[id$='lblContactPhoneNumber']").text()));
    $("[id$='txtPracticeExt']").val($.trim($("[id$='lblPracticeExt']").text()));

    $("#divPracticeInformationView").hide();
    $("#divPracticeInformationEdit").show();
}

function cancelSavePracticeInformation() {
    $("#divPracticeInformationView").show();
    $("#divPracticeInformationEdit").hide();

}


/*Start Staff functions*/
var _PracticeStaffId;

function AddNewStaff() {
    if (!checkModuleRights("PracticeStaffAdd")) {
        //showErrorMessage(_msg_PracticeStaffAdd);
        //return false;
    }

    $("#divStaffInformationAdd input:text, #divStaffInformationAdd textarea, #divStaffInformationAdd input:password").val("");
    $("#divStaffInformationAdd select").val(0);
    $("[id$='imgStaffPhotoNew']").attr("src", _RooTPath + "Images/maleIcon.png");
    $("[id$='hdnStaffFileNameNew']").val("");

    initializeImageUpload("fuStaffNew", "imgStaffPhotoNew", "hdnStaffFileNameNew");

    $(".Tab-Content").hide();
    $("#divStaffInformationAdd").show();
}

function saveStaffInformation(NEW, formId, flgSaveClose) {
    if (NEW != "") {
        if (!checkModuleRights("PracticeStaffAdd")) {
            //showErrorMessage(_msg_PracticeStaffAdd);
            //return false;
        }
    }
    else {
        if (!checkModuleRights("PracticeStaffEdit")) {
            //showErrorMessage(_msg_PracticeStaffEdit);
            //return false;
        }
    }
    
    if (!ValidateForm(formId)) {
        showErrorMessage("");
        return;
    }
    
    var CurrentDate = new Date();
    var SelectedDate = new Date($.trim($("[id$='txtStaffDOB" + NEW + "']").val()));
    
    if (SelectedDate > CurrentDate) {
        showErrorMessage("Error: Date must not be future date!");
        return;
    }
    
    var objPracticeStaff = new Object();
    
    if (NEW == "") {
        objPracticeStaff.PracticeStaffId = _PracticeStaffId;
    }
    else {
        flgSaveClose = 1;
    }
    
    objPracticeStaff.PracticeId = $.trim($("[id$='hdnPracticeId']").val());
    objPracticeStaff.PracticeLocationsId = $.trim($("[id$='ddlStaffPracticeLocation" + NEW + "']").val());
    
    if (NEW == "") {
        if (!getModuleRightStatus("PracticeStaffEditLocations", $.trim($("[id$='ddlStaffPracticeLocation" + NEW + "']").val()))) {
            //showErrorMessage(_msg_PracticeStaffEditLocation);
            //return false;
        }
    }
    else {
        if (!getModuleRightStatus("PracticeStaffAddLocations", $.trim($("[id$='ddlStaffPracticeLocation" + NEW + "']").val()))) {
            //showErrorMessage(_msg_PracticeStaffAddLocation);
            //return false;
        }
    }
    
    objPracticeStaff.StaffLastName = $.trim($("[id$='txtStaffLastName" + NEW + "']").val());
    objPracticeStaff.StaffFirstName = $.trim($("[id$='txtStaffFirstName" + NEW + "']").val());
    objPracticeStaff.StaffMiddleName = $.trim($("[id$='txtStaffMiddleName" + NEW + "']").val());
    objPracticeStaff.StaffTitle = $.trim($("[id$='txtStaffTitle" + NEW + "']").val());
    //  objPracticeStaff.StaffDateOfBirth = $.trim($("[id$='txtStaffDOB" + NEW + "']").val());
    objPracticeStaff.StaffDateOfBirth = SelectedDate;
    objPracticeStaff.StaffGender = $.trim($("[id$='ddlStaffGender" + NEW + "']").val());

    objPracticeStaff.StaffPhoto = $.trim($("[id$='hdnStaffFileName" + NEW + "']").val());
    objPracticeStaff.StaffUPIN = $.trim($("[id$='txtStaffUPIN" + NEW + "']").val());
    objPracticeStaff.StaffNPI = $.trim($("[id$='txtStaffNPI" + NEW + "']").val());
    objPracticeStaff.StaffTaxID = $.trim($("[id$='txtStaffTaxID" + NEW + "']").val());
    objPracticeStaff.StaffTaxonomyId = $.trim($("[id$='txtStaffTaxonomyCode" + NEW + "']").val());
    objPracticeStaff.StaffType = $.trim($("[id$='ddlStaffType" + NEW + "']").val());

    objPracticeStaff.StaffAddress = $.trim($("[id$='txtStaffAddress" + NEW + "']").val());
    objPracticeStaff.StaffCity = $.trim($("[id$='txtStaffCity" + NEW + "']").val());
    objPracticeStaff.StaffState = $("[id$='ddlStaffStates" + NEW + "']").val();
    objPracticeStaff.StaffZip = $.trim($("[id$='txtStaffZipCode" + NEW + "']").val());

    objPracticeStaff.StaffCellPhone = $.trim($("[id$='txtStaffCellPhone" + NEW + "']").val());
    objPracticeStaff.StaffHomePhone = $.trim($("[id$='txtStaffHomePhone" + NEW + "']").val());
    objPracticeStaff.StaffFax = $.trim($("[id$='txtStaffFax" + NEW + "']").val());
    objPracticeStaff.StaffEmailAddress = $.trim($("[id$='txtStaffEmailAddress" + NEW + "']").val());

    var action = NEW == "" ? "UpdateStaff" : "AddStaff";
    var objPracticeUsers = new Object();

    if ($("[id$='chkCreateWebAccount']").is(":checked")) {
        if (action == "AddStaff") {
            if ($.trim($("[id$='txtStaffUserName" + NEW + "']").val()) == "" || $.trim($("[id$='txtStaffPassword" + NEW + "']").val()) == "" || $.trim($("[id$='txtStaffConfirmPassword" + NEW + "']").val()) == "") {
                showErrorMessage("Error: You must enter User Name , Password & Confirm Password for Web Account.");
                return false;
            }
            if ($.trim($("[id$='txtStaffPassword" + NEW + "']").val()) != $.trim($("[id$='txtStaffConfirmPassword" + NEW + "']").val())) {
                showErrorMessage("Error: Password & Confirm Password does not match.");
                return false;
            }
        }

        objPracticeUsers.UserId = $("[id$='hdnUserId']").val();
        objPracticeUsers.UserName = $.trim($("[id$='txtStaffUserName" + NEW + "']").val());
        objPracticeUsers.Password = $.trim($("[id$='txtStaffPassword" + NEW + "']").val());
        objPracticeUsers.IsActive = $("[id$='cbIsActiveWebAccount']").is(":checked");
    }

    $.post(_SettingsPath + "/CallBacks/SettingsHandler.aspx", { objPracticeStaff: JSON.stringify(objPracticeStaff), objPracticeUsers: JSON.stringify(objPracticeUsers), LocationId: '0', action: action }, function (data) {
        if (NEW != "") {
            showSuccessMessage(_msg_Created);
            //_PracticeStaffId = 0;
        }
        else {
            showSuccessMessage(_msg_Updated);
        }

        var start = data.indexOf("###StartPracticeUserId###") + 25;
        var end = data.indexOf("###EndPracticeUserId###");
        $("[id$='hdnUserId']").val($.trim(data.substring(start, end)));
        
        if (flgSaveClose == 1) {
            loadStaffInformationGridView(data);
            $(".Tab-Content").hide();
            $("#divStaffInformation").show();
        }
    });
}

function cancelSaveStaffInformation() {
    $(".Tab-Content").hide();
    $("#divStaffInformation").show();
}

function loadStaffInformationGridView(data) {
    var returnHtml = data;
    var start = data.indexOf("###StartStaffGrid###") + 20;
    var end = data.indexOf("###EndStaffGrid###");
    $("#gridContentsStaff").html(returnHtml.substring(start, end));

    var startRowsCount = data.indexOf("###StartRowsCountStaff###") + 25;
    var endRowsCount = data.indexOf("###EndRowsCountStaff###");
    $("[id$='hdnStaffTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
    
    generateStaffPagging();
}

function loadStaffInformationDetailView(PracticeStaffId) {
    if (!checkModuleRights("PracticeStaffView")) {
        //showErrorMessage(_msg_PracticeStaffView);
        //return;
    }

    _PracticeStaffId = PracticeStaffId;
    $("[id$='divLocationStaffView']").html(""); //Empty the location staff view div's html (some elements may conflict)
    $.post(_SettingsPath + "/CallBacks/StaffViewHandler.aspx", { PracticeStaffId: PracticeStaffId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartStaffView###") + 20;
        var end = data.indexOf("###EndStaffView###");

        $(".Tab-Content").hide();
        $("#divStaffInformationView").html(returnHtml.substring(start, end)).show();

        $("[id$='btnOkStaffView']").attr("onclick", "cancelSaveStaffInformation();");
        $("[id$='btnEdit']").attr("onclick", "loadStaffInformationEditView(" + _PracticeStaffId + ");");

        if ($("[id$='hdnStaffFileNameView']").val() != "") {
            $("[id$='imgStaffPhotoView']").attr("src", _PracticeDocumentsPath + "/" + $("[id$='hdnPracticeIdMaster']").val() + "/Staff/" + $("[id$='hdnStaffFileNameView']").val());
        }
    });
}

function loadStaffInformationEditView(PracticeStaffId) {

    if (!checkModuleRights("PracticeStaffEdit")) {
        //showErrorMessage(_msg_PracticeStaffEdit);
        //return;
    }

    _PracticeStaffId = PracticeStaffId;
    $("[id$='divLocationStaffEdit']").html(""); //Empty the location staff edit div's html (some elements may conflict)
    $.post(_SettingsPath + "/CallBacks/StaffEditHandler.aspx", { PracticeStaffId: PracticeStaffId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartStaffEdit###") + 20;
        var end = data.indexOf("###EndStaffEdit###");

        $(".Tab-Content").hide();
        $("#divStaffInformationEdit").html(returnHtml.substring(start, end)).show();

        $("[id$='btnCancelStaffEdit']").attr("onclick", "cancelSaveStaffInformation();");
        $("[id$='btnSaveStaffInformation']").attr("onclick", "saveStaffInformation('', 'divStaffInformationEdit', '1');");

        initilizeDOB("txtStaffDOB");

        if ($("[id$='hdnStaffFileName']").val() != "") {
            $("[id$='imgStaffPhoto']").attr("src", _PracticeDocumentsPath + "/" + $("[id$='hdnPracticeIdMaster']").val() + "/Staff/" + $("[id$='hdnStaffFileName']").val());
        }
        initializeImageUpload("fuStaff", "imgStaffPhoto", "hdnStaffFileName");
        if ($("[id$='chkCreateWebAccount']").is(":checked")) {
            $("[id$='chkCreateWebAccount']").closest("table").find(".create-web-account-wrapper").show();
            $("[id$='chkCreateWebAccount']").closest("table").find(".create-web-account-wrapper input").not(":hidden").addClass("required");
            $("[id$='txtStaffPassword']").val($("[id$='hdnPasswordUser']").val());
            $("[id$='txtStaffConfirmPassword']").val($("[id$='hdnPasswordUser']").val());
        }
        else {
            $("[id$='chkCreateWebAccount']").closest("table").find(".create-web-account-wrapper").hide();
            $("[id$='chkCreateWebAccount']").closest("table").find(".create-web-account-wrapper input").not(":hidden").removeClass("required").removeClass("error");

        }
    });
}

function initializeImageUpload(instance, imageContainer, imageFileName) {
    settingControlImageUpload.imageContainer = $("[id$='" + imageContainer + "']");
    settingControlImageUpload.imageFileName = $("[id$='" + imageFileName + "']");

    controlUpload({
        instance: instance,
        clientType: "Staff",
        onComplete: function () { }
    });
}

function deleteStaff(elem, PracticeStaffId) {
    if (!checkModuleRights("PracticeStaffDelete")) {
        //showErrorMessage(_msg_PracticeStaffDelete);
        //return;
    }

    $("#dialogconfirmMaster").html(_msg_Deleted_Confirmation).dialog({
        resizable: false,
        height: 140,
        width: 300,
        modal: true,
        title: 'Confirmation',
        buttons: {
            "Yes": function () {
                $(this).dialog("close");
                $.post(_SettingsPath + "/CallBacks/SettingsHandler.aspx", { PracticeStaffId: PracticeStaffId, LocationId: '0', action: 'DeleteStaff' }, function (data) {
                    loadStaffInformationGridView(data);
                    showSuccessMessage(_msg_Deleted)
                });
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}
/*End Staff functions*/

/*Start Practice Location functions*/
function showLocationInfo(elem, LocationId) {
    $(".contents-details-header").html('Practice Locations');
    $(".setting-content-wrapper").hide();
    $(".ulWrapper-li-Active").removeClass("ulWrapper-li-Active");
    $(elem).addClass("ulWrapper-li-Active");
    
    if (!checkModuleRights("PracticeLocationsView")) {
        //showErrorMessage(_msg_PracticeLocationsView);
        //return;
    }
    
    if (!getModuleRightStatus("PracticeLocationsViewLocations", LocationId)) {
        //showErrorMessage(_msg_PracticeLocationsViewLocation);
        //return false;
    }
    
    _LocationId = LocationId;
    
    $.post(_SettingsPath + "/CallBacks/PracticeLocations.aspx", { LocationId: _LocationId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartPracticeLocation###") + 27;
        var end = data.indexOf("###EndPracticeLocation###");
        
        var returnHtml = $.trim(returnHtml.substring(start, end));
        
        $("#divPracticeLocationMain").html(returnHtml).show();
        $("#divPracticeLocationInfo").show();
        
        if (!getModuleRightStatus("PracticeStaffViewLocations", LocationId)) {
            //$("#divLocationStaffList").html("");
        }
        
        initilizeDOB("txtLocationStaffDOBNew");
        initializeImageUpload("fuStaffPracticeLocationNEW", "imgStaffPhotoPracticeLocationNEW", "hdnStaffFileNamePracticeLocationNEW");
        
        generateLocationStaffPagging();
    });
}

function generateLocationStaffPagging() {
    GeneratePaging($("[id$='hdnLocationStaffTotalRows']").val(), $("#ddlPagingLocationStaff").val(), "gridLocationStaff", "FilterLocationStaff");
    
    if ($("[id$='hdnLocationStaffTotalRows']").val() > 0) {
        $("#gridLocationStaff .spanInfo").html("Showing " + $("#gridContentsLocationStaff tr:first").children().first().html() + " to " + $("#gridContentsLocationStaff tr:last").children().first().html() + " of " + $("[id$='hdnLocationStaffTotalRows']").val() + " entries");
    }
}

function FilterLocationStaff(pageNumber, paging) {
    if (!getModuleRightStatus("PracticeStaffViewLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeStaffViewLocation);
        //return false;
    }
    
    $.post(_SettingsPath + "/CallBacks/LocationStaffFilterHandler.aspx", { LocationId: _LocationId, Rows: $("#ddlPagingLocationStaff").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsLocationStaff").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnLocationStaffTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            generateLocationStaffPagging();
        }
        else {
            if ($("[id$='hdnLocationStaffTotalRows']").val() > 0) {
                $("#gridLocationStaff .spanInfo").html("Showing " + $("#gridContentsLocationStaff tr:first").children().first().html() + " to " + $("#gridContentsLocationStaff tr:last").children().first().html() + " of " + $("[id$='hdnLocationStaffTotalRows']").val() + " entries");
            }
        }
    });
}

function showHideLocationTabs(contentId) {
    $("#divLocationTabsWrapper .Tab-Content").hide();

    if (contentId == "divLocationInformation") {
        if (!checkModuleRights("PracticeLocationsView")) {
            //showErrorMessage(_msg_PracticeLocationsView);
            //return;
        }

        if (!getModuleRightStatus("PracticeLocationsViewLocations", _LocationId)) {
            //showErrorMessage(_msg_PracticeLocationsViewLocation);
            //return false;
        }

        $("#divPracticeLocationInfo").show();
    }
    else if (contentId == "divLocationStaff") {
        if (!checkModuleRights("PracticeStaffView")) {
            //showErrorMessage(_msg_PracticeStaffView);
            //return;
        }

        if (!getModuleRightStatus("PracticeStaffViewLocations", _LocationId)) {
            //showErrorMessage(_msg_PracticeStaffViewLocation);
            //return false;
        }

        $("#gridLocationStaff").show();
    }
    else if (contentId == "divPracticeLocationDepartments") {
        ShowDepartments(_LocationId);
    }

    $("#" + contentId).show();
}

function AddNewLocation() {
    if (!checkModuleRights("PracticeLocationsAdd")) {
        //showErrorMessage(_msg_PracticeLocationsAdd);
        //return;
    }
    
    _LocationId = 0;
    $(".contents-details-header").html('Practice Locations');
    $(".setting-content-wrapper").hide();
    $.post(_SettingsPath + "/CallBacks/PracticeLocations.aspx", { LocationId: _LocationId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartPracticeLocation###") + 27;
        var end = data.indexOf("###EndPracticeLocation###");
        $("#divPracticeLocationMain").html(returnHtml.substring(start, end)).show();

        $("#divLocationDetailsView").hide();
        $("#divLocationEditView").show();
        $("#btnCancelSaveLocation").hide();
        $("#btnshowPracticeInfo").show();
    });
}

function EditLocation() {
    if (!checkModuleRights("PracticeLocationsEdit")) {
        //showErrorMessage(_msg_PracticeLocationsEdit);
        //return;
    }

    if (!getModuleRightStatus("PracticeLocationsEditLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeLocationsEditLocation);
        //return false;
    }

    $("#divLocationDetailsView").hide();
    $("#divLocationEditView").show();

    loadLocationEditData();
}

function canceSaveLocation() {
    $("#divLocationDetailsView").show();
    $("#divLocationEditView").hide();

}

function saveLocation() {
    if (!ValidateForm("tblLocation")) {
        showErrorMessage("");
        return;
    }
    
    var objPracticeLocation = new Object();
    objPracticeLocation.PracticeLocationsId = _LocationId;
    objPracticeLocation.Name = $.trim($("[id$='txtLocationName']").val());

    objPracticeLocation.Address = $.trim($("[id$='txtLocationAdd']").val());
    objPracticeLocation.City = $.trim($("[id$='txtLocationCity']").val());
    objPracticeLocation.StateCode = $("[id$='ddlLocationStates']").val();
    objPracticeLocation.Zip = $.trim($("[id$='txtLocationZip']").val());

    objPracticeLocation.PrimaryContact = $.trim($("[id$='txtLocationPriContact']").val());
    objPracticeLocation.SecondaryContact = $.trim($("[id$='txtLocationSecContact']").val());
    objPracticeLocation.OtherContact = $.trim($("[id$='txtLocationOthContact']").val());
    objPracticeLocation.FaxNo = $.trim($("[id$='txtLocationFax']").val());
    objPracticeLocation.EmailAddress = $.trim($("[id$='txtLocationEmail']").val());
    objPracticeLocation.ContactPerson = $.trim($("[id$='txtLocationcontactPerson']").val());

    $.post(_SettingsPath + "/CallBacks/SettingsHandler.aspx", { LocationData: JSON.stringify(objPracticeLocation), action: 'AddLocation' }, function (data) {
        if (_LocationId == 0) {
            var returnHtml = data;
            var start = data.indexOf("###StartPracticeLocationId###") + 29;
            var end = data.indexOf("###EndPracticeLocationId###");
            _LocationId = $.trim(returnHtml.substring(start, end));

            var liLocationHtml = '<li id="location_' + _LocationId + '" onclick="showLocationInfo(this,' + _LocationId + ');">' +
                '<label style="cursor: pointer;" id="lblLocationName" runat="server" title="">' +
                    $.trim($("[id$='txtLocationName']").val()) +
                '</label>' +
            '</li>';

            $("#ulLocations").append(liLocationHtml);
            userRightsArray["PracticeLocationsViewLocations"] = userRightsArray["PracticeLocationsViewLocations"] + "," + _LocationId;
            userRightsArray["PracticeLocationsEditLocations"] = userRightsArray["PracticeLocationsEditLocations"] + "," + _LocationId;
            userRightsArray["PracticeLocationsDeleteLocations"] = userRightsArray["PracticeLocationsDeleteLocations"] + "," + _LocationId;
            userRightsArray["PracticeStaffViewLocations"] = userRightsArray["PracticeStaffViewLocations"] + "," + _LocationId;
            userRightsArray["PracticeStaffAddLocations"] = userRightsArray["PracticeStaffAddLocations"] + "," + _LocationId;
            userRightsArray["PracticeStaffEditLocations"] = userRightsArray["PracticeStaffEditLocations"] + "," + _LocationId;
            userRightsArray["PracticeStaffDeleteLocations"] = userRightsArray["PracticeStaffDeleteLocations"] + "," + _LocationId;

            showLocationInfo($("#location_" + _LocationId), _LocationId);
            showSuccessMessage(_msg_Created);
        }
        else {
            $(".ulWrapper-li-Active label").html(objPracticeLocation.Name);
            showSuccessMessage(_msg_Updated);
            loadLocationViewData();
        }
    });
}

function loadLocationEditData() {
    $("[id$='txtLocationName']").val($("[id$='lblLocationName']").html());
    $("[id$='txtLocationAdd']").val($("[id$='lblLocationAdd']").html());
    $("[id$='txtLocationCity']").val($("[id$='lblLocationCity']").html());
    $("[id$='ddlLocationStates']").val($("[id$='lblLocationStateCode']").html());
    $("[id$='txtLocationZip']").val($("[id$='lblLocationZip']").html());
    $("[id$='txtLocationPriContact']").val($("[id$='lblLocationPriContact']").html());
    $("[id$='txtLocationSecContact']").val($("[id$='lblLocationSecContact']").html());
    $("[id$='txtLocationOthContact']").val($("[id$='lblLocationOthContact']").html());
    $("[id$='txtLocationFax']").val($("[id$='lblLocationFax']").html());
    $("[id$='txtLocationEmail']").val($("[id$='lblLocationEmail']").html());
    $("[id$='txtLocationcontactPerson']").val($("[id$='lblLocationContactPerson']").html());
}

function loadLocationViewData() {
    $("[id$='lblLocationName']").text($("[id$='txtLocationName']").val());
    $("[id$='lblLocationAdd']").text($("[id$='txtLocationAdd']").val());
    $("[id$='lblLocationCity']").text($("[id$='txtLocationCity']").val());
    $("[id$='lblLocationStateName']").text($("[id$='ddlLocationStates'] option:selected").text());
    $("[id$='lblLocationStateCode']").text($("[id$='ddlLocationStates']").val());
    $("[id$='lblLocationZip']").text($("[id$='txtLocationZip']").val());
    $("[id$='lblLocationPriContact']").text($("[id$='txtLocationPriContact']").val());
    $("[id$='lblLocationSecContact']").text($("[id$='txtLocationSecContact']").val());
    $("[id$='lblLocationOthContact']").text($("[id$='txtLocationOthContact']").val());
    $("[id$='lblLocationFax']").text($("[id$='txtLocationFax']").val());
    $("[id$='lblLocationEmail']").text($("[id$='txtLocationEmail']").val());
    $("[id$='lblLocationContactPerson']").text($("[id$='txtLocationcontactPerson']").val());

    $("#divLocationDetailsView").show();
    $("#divLocationEditView").hide();
}

function deleteLocation() {
    if (!checkModuleRights("PracticeLocationsDelete")) {
        //showErrorMessage(_msg_PracticeLocationsDelete);
        //return false;
    }

    if (!getModuleRightStatus("PracticeLocationsDeleteLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeLocationsDeleteLocation);
        //return false;
    }

    $("#dialogconfirmMaster").html(_msg_Deleted_Confirmation).dialog({
        resizable: false,
        height: 140,
        width: 300,
        modal: true,
        title: 'Confirmation',
        buttons: {
            "Yes": function () {
                $(this).dialog("close");
                $.post(_SettingsPath + "/CallBacks/SettingsHandler.aspx", { LocationId: _LocationId, action: 'DeleteLocation' }, function (data) {
                    $("#location_" + _LocationId).remove();

                    if ($("#ulLocations li").length > 0) {
                        $("#ulLocations li:first").click();
                    }
                    else {
                        $("#h3PracticeDetails").click();
                    }

                    showSuccessMessage(_msg_Deleted);
                });
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}
/*End Practice Location functions*/

/*Start Location staff functions*/
function AddNewLocationStaff() {
    if (!checkModuleRights("PracticeStaffAdd")) {
        //showErrorMessage(_msg_PracticeStaffAdd);
        //return false;
    }
    
    if (!getModuleRightStatus("PracticeStaffAddLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeStaffAddLocation);
        //return false;
    }
    
    $("#divAddLocationStaff input:text, #divAddLocationStaff input:password, #divAddLocationStaff textarea ").val("");
    $("#divAddLocationStaff select").val(0);
    $("[id$='imgStaffPhotoNew']").attr("src", _RooTPath + "Images/maleIcon.png");
    $("[id$='hdnStaffFileNameNew']").val("");
    $(".tab-inner-contents").hide();
    $("#divLocationStaffAdd").show();
}

function saveLocationStaffInformation(NEW, formId, flgSaveClose) {
    if (!ValidateForm(formId)) {
        showErrorMessage("");
        return;
    }

    var CurrentDate = new Date();
    var SelectedDate = new Date($.trim($("[id$='txtLocationStaffDOB" + NEW + "']").val()));

    if (SelectedDate > CurrentDate) {
        showErrorMessage("Error: Date must not be future date!");
        return;
    }

    var objPracticeStaff = new Object();

    if (NEW == "") {
        objPracticeStaff.PracticeStaffId = _PracticeStaffId;
    }

    else {
        flgSaveClose = 1;
    }
    
    objPracticeStaff.PracticeId = $.trim($("[id$='hdnPracticeId']").val());
    objPracticeStaff.PracticeLocationsId = _LocationId;
    
    if (NEW == "" && !getModuleRightStatus("PracticeStaffEditLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeStaffEditLocation);
        //return false;
    }
    else if (!getModuleRightStatus("PracticeStaffAddLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeStaffAddLocation);
        //return false;
    }

    objPracticeStaff.StaffLastName = $.trim($("[id$='txtLocationStaffLastName" + NEW + "']").val());
    objPracticeStaff.StaffFirstName = $.trim($("[id$='txtLocationStaffFirstName" + NEW + "']").val());
    objPracticeStaff.StaffMiddleName = $.trim($("[id$='txtLocationStaffMiddleName" + NEW + "']").val());
    objPracticeStaff.StaffTitle = $.trim($("[id$='txtLocationStaffTitle" + NEW + "']").val());

    objPracticeStaff.StaffDateOfBirth = SelectedDate;
    objPracticeStaff.StaffGender = $.trim($("[id$='ddlLocationStaffGender" + NEW + "']").val());

    objPracticeStaff.StaffPhoto = $.trim($("[id$='hdnStaffFileNamePracticeLocation" + NEW + "']").val());
    objPracticeStaff.StaffUPIN = $.trim($("[id$='txtLocationStaffUPIN" + NEW + "']").val());
    objPracticeStaff.StaffNPI = $.trim($("[id$='txtLocationStaffNPI" + NEW + "']").val());
    objPracticeStaff.StaffTaxID = $.trim($("[id$='txtLocationStaffTaxID" + NEW + "']").val());
    objPracticeStaff.StaffTaxonomyId = $.trim($("[id$='txtLocationStaffTaxonomyCode" + NEW + "']").val());
    objPracticeStaff.StaffType = $.trim($("[id$='ddlLocationStaffType" + NEW + "']").val());

    objPracticeStaff.StaffAddress = $.trim($("[id$='txtLocationStaffAddress" + NEW + "']").val());
    objPracticeStaff.StaffCity = $.trim($("[id$='txtLocationStaffCity" + NEW + "']").val());
    objPracticeStaff.StaffState = $("[id$='ddlLocationStaffStates" + NEW + "']").val();
    objPracticeStaff.StaffZip = $.trim($("[id$='txtLocationStaffZipCode" + NEW + "']").val());

    objPracticeStaff.StaffCellPhone = $.trim($("[id$='txtLocationStaffCellPhone" + NEW + "']").val());
    objPracticeStaff.StaffHomePhone = $.trim($("[id$='txtLocationStaffHomePhone" + NEW + "']").val());
    objPracticeStaff.StaffFax = $.trim($("[id$='txtLocationStaffFax" + NEW + "']").val());
    objPracticeStaff.StaffEmailAddress = $.trim($("[id$='txtLocationStaffEmailAddress" + NEW + "']").val());

    var action = NEW == "" ? "UpdateStaff" : "AddStaff";

    var objPracticeUsers = new Object();

    if ($("[id$='chkLocationCreateWebAccount']").is(":checked")) {
        if (action == "AddStaff") {
            if ($.trim($("[id$='txtLocationStaffUserName']").val()) == "" || $.trim($("[id$='txtLocationStaffPassword']").val()) == "" || $.trim($("[id$='txtLocationStaffConfirmPassword']").val()) == "") {
                //showErrorMessage("Error: You must enter User Name , Password & Confirm Password for Web Account.");
                //return false;
            }

            if ($.trim($("[id$='txtLocationStaffPassword']").val()) != $.trim($("[id$='txtLocationStaffConfirmPassword']").val())) {
                //showErrorMessage("Error: Password & Confirm Password does not match.");
                //return false;
            }
        }
        
        objPracticeUsers.UserId = $("[id$='hdnUserId1']").val();
        objPracticeUsers.UserName = $.trim($("[id$='txtLocationStaffUserName']").val());
        objPracticeUsers.Password = $.trim($("[id$='txtLocationStaffPassword']").val());
        objPracticeUsers.IsActive = $("[id$='cbLocationIsActiveWebAccount']").is(":checked");
    }
    
    $.post(_SettingsPath + "/CallBacks/SettingsHandler.aspx", { objPracticeStaff: JSON.stringify(objPracticeStaff), objPracticeUsers: JSON.stringify(objPracticeUsers), LocationId: _LocationId, action: action }, function (data) {
        if (NEW != "") {
            showSuccessMessage(_msg_Created);
        }
        else {
            showSuccessMessage(_msg_Updated);
        }
        
        var start = data.indexOf("###StartPracticeUserId###") + 25;
        var end = data.indexOf("###EndPracticeUserId###");
        $("[id$='hdnUserId1']").val($.trim(data.substring(start, end)));
        
        if (flgSaveClose == 1) {
            loadLocationStaffInformationGridView(data);
            
            $(".tab-inner-contents").hide();
            $("#divLocationStaffList").show();
        }
    });
}

function showHideWebAccountInfo(obj) {
    debugger;
    if ($(obj).is(":checked")) {
        $(obj).closest("table").find(".create-web-account-wrapper").show();
        
        $(obj).closest("table").find(".create-web-account-wrapper input").val("");
        $(obj).closest("table").find(".create-web-account-wrapper input[type='text']").addClass("required");
        $(obj).closest("table").find(".create-web-account-wrapper input[type='password']").addClass("required");
    }
    else {
        $(obj).closest("table").find(".create-web-account-wrapper").hide();
        $(obj).closest("table").find(".create-web-account-wrapper input").removeClass("required");
        $(obj).closest("table").find(".create-web-account-wrapper input").removeClass("error");
    }
}

function cancelSaveLocationStaffInformation() {
    $(".tab-inner-contents").hide();
    $("#divLocationStaffList").show();
}

function loadLocationStaffInformationGridView(data) {
    if (!getModuleRightStatus("PracticeStaffViewLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeStaffViewLocation);
        //return false;
    }

    var returnHtml = data;
    var start = data.indexOf("###StartLocationStaffGrid###") + 28;
    var end = data.indexOf("###EndLocationStaffGrid###");
    $("#gridContentsLocationStaff").html(returnHtml.substring(start, end));

    var startRowsCount = data.indexOf("###StartRowsCountStaff###") + 25;
    var endRowsCount = data.indexOf("###EndRowsCountStaff###");
    $("[id$='hdnLocationStaffTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

    generateLocationStaffPagging();
}

function loadLocationStaffInformationDetailView(PracticeStaffId) {
    if (!checkModuleRights("PracticeStaffView")) {
        //showErrorMessage(_msg_PracticeStaffView);
        //return;
    }

    if (!getModuleRightStatus("PracticeStaffViewLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeStaffViewLocation);
        //return false;
    }

    _PracticeStaffId = PracticeStaffId;
    $("[id$='divStaffInformationView']").html(""); //Empty the practice staff view div's html (some elements may conflict)

    $.post(_SettingsPath + "/CallBacks/StaffViewHandler.aspx", { PracticeStaffId: _PracticeStaffId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartStaffView###") + 20;
        var end = data.indexOf("###EndStaffView###");

        $(".tab-inner-contents").hide();
        $("#divLocationStaffView").html(returnHtml.substring(start, end)).show();

        $("[id$='btnOkStaffView']").attr("onclick", "cancelSaveLocationStaffInformation();");
        $("[id$='btnEdit']").attr("onclick", "loadLocationStaffInformationEditView(" + _PracticeStaffId + ");");

        if ($("[id$='hdnStaffFileNameView']").val() != "") {
            $("[id$='imgStaffPhotoView']").attr("src", _PracticeDocumentsPath + "/" + $("[id$='hdnPracticeIdMaster']").val() + "/Staff/" + $("[id$='hdnStaffFileNameView']").val());
        }
    });
}

function loadLocationStaffInformationEditView(PracticeStaffId) {
    if (!checkModuleRights("PracticeStaffEdit")) {
        //showErrorMessage(_msg_PracticeStaffEdit);
        //return;
    }
    
    if (!getModuleRightStatus("PracticeStaffEditLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeStaffEditLocation);
        //return false;
    }
    
    _PracticeStaffId = PracticeStaffId;

    $("[id$='divStaffInformationEdit']").html(""); //Empty the practice staff edit div's html (some elements may conflict)

    $.post(_SettingsPath + "/CallBacks/LocationStaffEditHandler.aspx", { PracticeStaffId: PracticeStaffId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartStaffEdit###") + 20;
        var end = data.indexOf("###EndStaffEdit###");

        $(".tab-inner-contents").hide();
        $("#divLocationStaffEdit").html(returnHtml.substring(start, end)).show();

        initilizeDOB("txtLocationStaffDOB");

        if ($("[id$='hdnStaffFileNamePracticeLocation']").val() != "") {
            $("[id$='imgStaffPhotoPracticeLocation']").attr("src", _PracticeDocumentsPath + "/" + $("[id$='hdnPracticeIdMaster']").val() + "/Staff/" + $("[id$='hdnStaffFileNamePracticeLocation']").val());
        }
        initializeImageUpload("fuStaffPracticeLocation", "imgStaffPhotoPracticeLocation", "hdnStaffFileNamePracticeLocation");
        if ($("[id$='chkLocationCreateWebAccount']").is(":checked")) {
            $("[id$='chkLocationCreateWebAccount']").closest("table").find(".create-web-account-wrapper").show();
            $("[id$='chkLocationCreateWebAccount']").closest("table").find(".create-web-account-wrapper input").not(":hidden").addClass("required");
            $("[id$='txtLocationStaffPassword']").val($("[id$='hdnLocationPasswordUser']").val());
            $("[id$='txtLocationStaffConfirmPassword']").val($("[id$='hdnLocationPasswordUser']").val());
        }
        else {
            $("[id$='chkLocationCreateWebAccount']").closest("table").find(".create-web-account-wrapper").hide();
            $("[id$='chkLocationCreateWebAccount']").closest("table").find(".create-web-account-wrapper input").not(":hidden").removeClass("required").removeClass("error");

        }
    });
}

function deleteLocationStaff(elem, PracticeStaffId) {
    if (!checkModuleRights("PracticeStaffDelete")) {
        //showErrorMessage(_msg_PracticeStaffDelete);
        //return;
    }

    if (!getModuleRightStatus("PracticeStaffDeleteLocations", _LocationId)) {
        //showErrorMessage(_msg_PracticeStaffDeleteLocation);
        //return false;
    }

    $("#dialogconfirmMaster").html(_msg_Deleted_Confirmation).dialog({
        resizable: false,
        height: 140,
        width: 300,
        modal: true,
        title: 'Confirmation',
        buttons: {
            "Yes": function () {
                $(this).dialog("close");
                $.post(_SettingsPath + "/CallBacks/SettingsHandler.aspx", { PracticeStaffId: PracticeStaffId, LocationId: _LocationId, action: 'DeleteStaff' }, function (data) {
                    loadLocationStaffInformationGridView(data);
                    showSuccessMessage(_msg_Deleted);
                });
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}


function initilizeDOB(elementId) {
    $("[id$='" + elementId + "']").datepicker({
        minDate: "01/01/1930",
        maxDate: new Date(),
        changeMonth: true,
        yearRange: "1930:" + new Date,
        changeYear: true
    }).mask("99/99/9999");
}
/*End Location staff functions*/


/*Start Practice Departments*/
function ShowPracticeDepartments() {
    ShowDepartments(0);
}

function ShowDepartments(PracticeLocationsId) {
    $(".Tab-Content").hide();

    $(".divDepartmentsListWrapper").html("");

    var PracticeId = $("[id$='hdnPracticeIdMaster']").val();

    var params = {
        PracticeId: PracticeId,
        PracticeLocationsId: PracticeLocationsId,
        action: "LoadList"
    };

    var divParentDepartmentId = "divPracticeDepartments";

    if (PracticeLocationsId != 0) {
        divParentDepartmentId = "divPracticeLocationDepartments";
    }

    $.post(_SettingsPath + "/CallBacks/DepartmentsListHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartList###") + 15;
        var end = data.indexOf("###EndList###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#" + divParentDepartmentId + " .divDepartmentsListWrapper").html(returnHtml)
        .promise()
        .done(function () {
            SetGridPagerDepartments(true);
        });
    });
}

function ActionDepartments(params) {
    var PracticeId = $("[id$='hdnPracticeIdMaster']").val();

    $.extend(params,
        {
            PracticeId: PracticeId,
            PracticeLocationsId: _LocationId
        }
    );

    $.post(_SettingsPath + "/CallBacks/DepartmentsActionHandler.aspx", params, function (data) {
        if (params.action == "Save") {
            if (JSON.parse(params.objDepartments).DepartmentsId == 0) {
                showSuccessMessage(_msg_Created);
            }
            else {
                showSuccessMessage(_msg_Updated);
            }

            LoadGridDepartments(data, params.paging);
        }
        else if (params.action == "Delete") {
            showSuccessMessage(_msg_Deleted);
            LoadGridDepartments(data, params.paging);
        }
        else if (params.action == "LoadForm") {
            LoadFormDepartments(data);
        }
        else if (params.action == "Filter") {
            LoadGridDepartments(data, params.paging);
        }
    });
}

function LoadFormDepartments(data) {
    var start = data.indexOf("###StartForm###") + 15;
    var end = data.indexOf("###EndForm###");
    var returnHtml = $.trim(data.substring(start, end));

    var divParentDepartmentId = "divPracticeDepartments";

    if (_LocationId != 0) {
        divParentDepartmentId = "divPracticeLocationDepartments";
    }

    $("#" + divParentDepartmentId + " .divDepartmentsFormWrapper").html(returnHtml)
    .promise()
    .done(function () {
        $("#" + divParentDepartmentId + " .divDepartmentsListWrapper").hide();
        $("#" + divParentDepartmentId + " .divDepartmentsFormWrapper").show();
    });
}

function LoadGridDepartments(data, paging) {
    var start = data.indexOf("###StartTotalRows###") + 20;
    var end = data.indexOf("###EndTotalRows###");
    var TotalRows = $.trim(data.substring(start, end));

    $("[id$='hdnDepartmentsTotalRows']").val(TotalRows);

    start = data.indexOf("###StartList###") + 15;
    end = data.indexOf("###EndList###");

    $("[id$='gridContentsDepartments']").html($.trim(data.substring(start, end)))
    .promise()
    .done(function () {
        SetGridPagerDepartments(paging);
    });
}

function SetGridPagerDepartments(paging) {
    var divParentDepartmentId = "divPracticeDepartments";

    if (_LocationId != 0) {
        divParentDepartmentId = "divPracticeLocationDepartments";
    }

    $("#" + divParentDepartmentId + " .divDepartmentsFormWrapper").hide();
    $("#" + divParentDepartmentId).show();
    $("#" + divParentDepartmentId + " .divDepartmentsListWrapper").show();

    if (paging) {
        GeneratePaging($("[id$='hdnDepartmentsTotalRows']").val(), $("#ddlPagingDepartments").val(), "divDepartmentsList", "FilterDepartments");
    }

    if ($("[id$='hdnDepartmentsTotalRows']").val() > 0) {
        $("#divDepartmentsList .spanInfo").html("Showing " + $("#gridContentsDepartments tr:first").children().first().html() + " to " + $("#gridContentsDepartments tr:last").children().first().html() + " of " + $("[id$='hdnDepartmentsTotalRows']").val() + " entries");
    }
}

function FilterDepartments(PageNumber, paging) {
    var params = {
        Rows: $("[id$='ddlPagingDepartments']").val(),
        PageNumber: PageNumber,
        SortBy: "",
        action: "Filter",
        paging: paging
    };

    ActionDepartments(params);
}

function AddNewDepartments() {
    OpenDepartmentsForm(0);
}

function EditDepartments(elem) {
    var DepartmentsId = $(elem).closest("tr").find(".hdnDepartmentsId").val();
    OpenDepartmentsForm(DepartmentsId);
}

function DeleteDepartments(elem) {
    ShowConfirmation(_msg_Deleted_Confirmation).done(function () {
        ConfirmDeleteDepartments(elem);
    });
}

function ConfirmDeleteDepartments(elem) {
    var DepartmentsId = $(elem).closest("tr").find(".hdnDepartmentsId").val();

    var params = {
        DepartmentsId: DepartmentsId,
        Rows: 10,
        PageNumber: 0,
        SortBy: "",
        action: "Delete",
        paging: true
    };

    ActionDepartments(params);
}

function OpenDepartmentsForm(DepartmentsId) {
    $("[id$='hdnDepartmentsId']").val(DepartmentsId);

    var params = {
        DepartmentsId: DepartmentsId,
        action: "LoadForm"
    };

    ActionDepartments(params);
}

function CancelDepartments() {
    $(".divDepartmentsFormWrapper").hide();
    $(".divDepartmentsListWrapper").show();
}

function SaveDepartments() {
    if (!ValidateForm("divDepartmentsForm")) {
        showErrorMessage("");
        return false;
    }

    var PracticeId = $("[id$='hdnPracticeIdMaster']").val();

    var objDepartments = new Object();

    objDepartments.DepartmentsId = $("[id$='hdnDepartmentsId']").val();
    objDepartments.PracticeId = PracticeId;
    objDepartments.PracticeLocationsId = _LocationId;
    objDepartments.DepartmentName = $("[id$='txtDepartmentName']").val();

    var params = {
        objDepartments: JSON.stringify(objDepartments),
        Rows: 10,
        PageNumber: 0,
        SortBy: "",
        action: "Save",
        paging: true
    };

    ActionDepartments(params);
}
/*End Practice Departments*/


//******************************End Practice and Locations Section********************************//
