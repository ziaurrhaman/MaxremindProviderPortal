<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="ProviderPortal_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/CustomTheme.css" rel="stylesheet" />

    <script type="text/javascript">

        var _ProfileSection = "";

        $(function () {
            initializeImageUploadProfile("fuUserProfile", "imgUserProfile");
            initializeSignatureImageUpload("fuDigitalSignature", "imgDigitalSignature");

            $(".phone").mask("(999) 999-9999");

            $(".license-date").datepicker({
                minDate: "01/01/1990",
                maxDate: new Date(),
                changeMonth: true,
                yearRange: "1990:2050",
                changeYear: true
            }).mask("99/99/9999");

            $(".license-date-expiry").datepicker({
                minDate: "01/01/1990",
                changeMonth: true,
                yearRange: "1990:2050",
                changeYear: true
            }).mask("99/99/9999");
        });

        function initializeImageUploadProfile(instance, imageContainer) {
            debugger
            new AjaxUpload('#' + instance, {
                action: "../../ProviderPortal/Controls/ChangeUserProfileImage.ashx",
                dataType: 'json',
                contentType: "application/json; charset=uft-8",
                data: {
                    UserId: $("[id$='hdnUserIdMaster']").val(),
                    User: $("[id$='hdnUser']").val(),
                    AgencyId: $("[id$='hdnMasterAgecyId']").val()
                },
                onSubmit: function (file, ext, fileSize) {
                    debugger;
                    if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                         
                         showErrorMessage("Sorry! the file is invalid.", "Invalid File");
                        return false;
                    }
                    if (fileSize > 25) {
                        showErrorMessage("This file exceeds the 5MB attachment limit.", "Attachment Limit");
                        return false;
                    }
                },
                onComplete: function (file, response) {
                    debugger;
                    var serverResponse = $.parseJSON($(response).html());
                    var userImagePath = _AgencyDocumentsPath + "/" + $("[id$='hdnUserIdMaster']").val() + "/Users/" + serverResponse.fileName;
                    $("[id$='" + imageContainer + "']").attr("src", userImagePath);
                    $("[id$='imgProfileImageOnWelcome']").attr("src", userImagePath);
                    $("[id$='imgProfielPicture']").attr("src", userImagePath);
                }
            });
        }

        function initializeSignatureImageUpload(instance, imageContainer) {
            new AjaxUpload('#' + instance, {
                action:  "/UserProfile/DigitalSignature.ashx",
                dataType: 'json',
                contentType: "application/json; charset=uft-8",
                data: {
                    UserId: $("[id$='hdnUserIdMaster']").val(),
                  
                },
                onSubmit: function (file, ext, fileSize) {
                    if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                        callDialog("Sorry! the file is invalid.", "Invalid File");
                        return false;
                    }
                    if (fileSize > 25) {
                        callDialog("This file exceeds the 5MB attachment limit.", "Attachment Limit");
                        return false;
                    }
                },
                onComplete: function (file, response) {
                    var serverResponse = $.parseJSON($(response).html());
                    var userImagePath = _AgencyDocumentsPath + "/" + $("[id$='hdnMasterAgecyId']").val() + "/Users/DigitalSignature/" + serverResponse.fileName;
                    $("[id$='" + imageContainer + "']").attr("src", userImagePath);
                }
            });
        }

        function initializeProfessionalLicenseUpload() {
            $("#tblQualifications tr").each(function (i) {
                callAjaxUpload($(this).find(".certificates-attachment"));

                var IssueDateId = $(this).find("input.issueDate").attr("id");
                $("#" + IssueDateId).datepicker({
                    minDate: "01/01/1990",
                    maxDate: new Date(),
                    changeMonth: true,
                    yearRange: "1990:2050",
                    changeYear: true
                }).mask("99/99/9999");


                var ExpiryDateId = $(this).find("input.ExpDate").attr("id");
                $("#" + ExpiryDateId).datepicker({
                    minDate: "01/01/1990",
                    changeMonth: true,
                    yearRange: "1990:2050",
                    changeYear: true
                }).mask("99/99/9999");
            });
        }


        function click_EditProfilePersonalInformation() {

            var title = $.trim($("[id$='lblProfileTitle']").html());
            var lastName = $.trim($("[id$='lblProfileLastName']").html());
            var firstName = $.trim($("[id$='lblProfileFirstName']").html());
            var Gender = $.trim($("[id$='lblProfileGender']").html());

            $("[id$='ddlProfileTitle']").val(title);
            $("[id$='txtProfileLastName']").val(lastName);
            $("[id$='txtProfileFirstName']").val(firstName);

            if (Gender == "Male") {
                $("[id$='ddlProfileGender']").val("M");
            }
            else if (Gender == "Female") {
                $("[id$='ddlProfileGender']").val("F");
            }


            /////   Update Personal Info firstname last Name
            $("#divDialogProfilePersonalInformation").dialog({
                title: "Personal Information",
                modal: true,
                width: "400",
                buttons: {
                    "Save": function () {
                        updateProfilePersonalInformation();
                        $(this).dialog("close");
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }

        function updateProfilePersonalInformation() {
            debugger;
            var objUserProfile = new Object();

          
            objUserProfile.LastName = $.trim($("[id$='txtProfileLastName']").val());
            objUserProfile.FirstName = $.trim($("[id$='txtProfileFirstName']").val());
         

            $.post("../../ProviderPortal/UserProfile.aspx", { objUserProfile: JSON.stringify(objUserProfile), Section: "Personal" }, function (data) {

                debugger;
            
                $("[id$='lblProfileLastName']").html(objUserProfile.LastName);
                $("[id$='lblProfileFirstName']").html(objUserProfile.FirstName);

               

                $("[id$='lblUsername']").html(objUserProfile.LastName + ", " + objUserProfile.FirstName);
                $("[id$='lblUserNameMain']").html(objUserProfile.LastName + ", " + objUserProfile.FirstName);

                showSuccessMessage("Profile updated successfully!");
            });
        }

        function click_EditProfileGeneralInformation() {

            var NPI = $.trim($("[id$='lblProfileNPI']").html());
            var UPIN = $.trim($("[id$='lblProfileUPIN']").html());
            var LicenseNo = $.trim($("[id$='lblProfileLicenseNo']").html());

            $("[id$='txtProfileUPIN']").val(UPIN);
            $("[id$='txtProfileNPI']").val(NPI);
            $("[id$='txtProfileProviderNo']").val(LicenseNo);

            $("#divDialogProfileGeneralInformation").dialog({
                title: "Genral Information",
                modal: true,
                width: "400",
                buttons: {
                    "Save": function () {
                        updateProfileGeneralInformation();
                        $(this).dialog("close");
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }

        function updateProfileGeneralInformation() {
            var objUserProfile = new Object();

            objUserProfile.UserId = $.trim($("[id$='hdnUserIdMaster']").val());
            objUserProfile.ServiceProviderId = $.trim($("[id$='hdnServiceProviderId']").val());

            objUserProfile.NPI = $.trim($("[id$='txtProfileNPI']").val());
            objUserProfile.UPIN = $.trim($("[id$='txtProfileUPIN']").val());
            objUserProfile.LicenseNo = $.trim($("[id$='txtProfileProviderNo']").val());

            $.post("/UserProfile/ProfileEditHandler.aspx", { objUserProfile: JSON.stringify(objUserProfile), Section: "General" }, function (data) {

                $("[id$='lblProfileNPI']").html(objUserProfile.NPI);
                $("[id$='lblProfileUPIN']").html(objUserProfile.UPIN);
                $("[id$='lblProfileLicenseNo']").html(objUserProfile.LicenseNo);

                showSuccessMessage("Profile updated successfully!");
            });
        }

        function click_EditProfileContactInformation() {

            var PhoneNumber = $.trim($("[id$='lblProfilePhoneNumber']").html());
            var OtherPhone = $.trim($("[id$='lblProfileOtherPhone']").html());
            var Fax = $.trim($("[id$='lblProfileFax']").html());
            var EmailAddress = $.trim($("[id$='lblProfileEmailAddress']").html());

            $("[id$='txtProfilePhoneNumber']").val(PhoneNumber);
            $("[id$='txtProfileOtherPhone']").val(OtherPhone);
            $("[id$='txtProfileFax']").val(Fax);
            $("[id$='txtProfileEmailAddress']").val(EmailAddress);

            $("#divDialogProfileContactInformation").dialog({
                title: "Contact Information",
                modal: true,
                width: "400",
                buttons: {
                    "Save": function () {
                        if (!ValidateForm("divDialogProfileContactInformation")) {
                            showErrorMessage("");
                            return;
                        }
                        updateProfileContactInformation();
                        $(this).dialog("close");
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }

        function updateProfileContactInformation() {
            var objUserProfile = new Object();

        

            objUserProfile.PhoneNumber = $.trim($("[id$='txtProfilePhoneNumber']").val());
          
            objUserProfile.EmailAddress = $.trim($("[id$='txtProfileEmailAddress']").val());

            $.post("../../ProviderPortal/UserProfile.aspx", { objUserProfile: JSON.stringify(objUserProfile), Section: "Contact" }, function (data) {

                $("[id$='lblProfilePhoneNumber']").html(objUserProfile.PhoneNumber);
              
                $("[id$='lblProfileEmailAddress']").html(objUserProfile.EmailAddress);

                showSuccessMessage("Profile updated successfully!");
            });
        }

        function click_EditProfileAddressInformation() {

            var StreetAddress = $.trim($("[id$='lblProfileStreetAddress']").html());
            var Zip = $.trim($("[id$='lblProfileZip']").html());
            var City = $.trim($("[id$='lblProfileCity']").html());
            var State = $.trim($("[id$='lblProfileState']").html());

            $("[id$='txtProfileStreetAddress']").val(StreetAddress);
            $("[id$='txtProfileZip']").val(Zip);
            $("[id$='txtProfileCity']").val(City);
            $("[id$='ddlProfileState']").val(State);


            $("#divDialogProfileAddressInformation").dialog({
                title: "Address Information",
                modal: true,
                width: "400",
                buttons: {
                    "Save": function () {
                        updateProfileAddressInformation();
                        $(this).dialog("close");
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }

        function updateProfileAddressInformation() {
            var objUserProfile = new Object();

            objUserProfile.UserId = $.trim($("[id$='hdnUserIdMaster']").val());
            objUserProfile.ServiceProviderId = $.trim($("[id$='hdnServiceProviderId']").val());

            objUserProfile.StreetAddress = $.trim($("[id$='txtProfileStreetAddress']").val());
            objUserProfile.Zip = $.trim($("[id$='txtProfileZip']").val());
            objUserProfile.City = $.trim($("[id$='txtProfileCity']").val());
            objUserProfile.State = $.trim($("[id$='ddlProfileState']").val());

            $.post("/UserProfile/ProfileEditHandler.aspx", { objUserProfile: JSON.stringify(objUserProfile), Section: "Address" }, function (data) {

                $("[id$='lblProfileStreetAddress']").html(objUserProfile.StreetAddress);
                $("[id$='lblProfileZip']").html(objUserProfile.Zip);
                $("[id$='lblProfileCity']").html(objUserProfile.City);
                $("[id$='lblProfileState']").html(objUserProfile.State);

                showSuccessMessage("Profile updated successfully!");
            });
        }

        function click_EditProfileDrivingLicenseInformation() {

            var DrivingLicenseNo = $.trim($("[id$='lblProfileDrivingLicenseNo']").html());
            var LicenseState = $.trim($("[id$='lblProfileDrivingLicenseState']").html());
            var LicenseIssuDate = $.trim($("[id$='lblProfileDrivingLicenseIssueDate']").html());
            var LicenseExpiryDate = $.trim($("[id$='lblProfileDrivingLicenseExpirationDate']").html());

            $("[id$='txtProfileDrivingLicenseNo']").val(DrivingLicenseNo);
            $("[id$='ddlDrivingLicenseState']").val(LicenseState);
            $("[id$='txtProfileDrivingLicenseIssueDate']").val(LicenseIssuDate);
            $("[id$='txtProfileDrivingLicenseIssueExpirationDate']").val(LicenseExpiryDate);

            $("#divDialogProfileDrivingLicenseInformation").dialog({
                title: "Driving License Information",
                modal: true,
                width: "400",
                buttons: {
                    "Save": function () {
                        updateProfileDrivingLicenseInformation();
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }

        function updateProfileDrivingLicenseInformation() {

            if (!ValidateForm("divDialogProfileDrivingLicenseInformation")) {
                showErrorMessage("");
                return;
            }

            var objUserProfile = new Object();

            objUserProfile.UserId = $.trim($("[id$='hdnUserIdMaster']").val());
            objUserProfile.ServiceProviderId = $.trim($("[id$='hdnServiceProviderId']").val());

            objUserProfile.DrivingLicenseNo = $.trim($("[id$='txtProfileDrivingLicenseNo']").val());
            objUserProfile.LicenseState = $.trim($("[id$='ddlDrivingLicenseState']").val());
            objUserProfile.LicenseIssuDate = $.trim($("[id$='txtProfileDrivingLicenseIssueDate']").val());
            objUserProfile.LicenseExpiryDate = $.trim($("[id$='txtProfileDrivingLicenseIssueExpirationDate']").val());

            var IssuDate = new Date(objUserProfile.LicenseIssuDate);
            var ExpiryDate = new Date(objUserProfile.LicenseExpiryDate);

            if (IssuDate > ExpiryDate) {
                showErrorMessage("Issue Date cannot be greater than Expiry Date!");
                return;
            }

            $.post(h + "/UserProfile/ProfileEditHandler.aspx", { objUserProfile: JSON.stringify(objUserProfile), Section: "Driving" }, function (data) {

                $("[id$='lblProfileDrivingLicenseNo']").html(objUserProfile.DrivingLicenseNo);
                $("[id$='lblProfileDrivingLicenseState']").html(objUserProfile.LicenseState);
                $("[id$='lblProfileDrivingLicenseIssueDate']").html(objUserProfile.LicenseIssuDate);
                $("[id$='lblProfileDrivingLicenseExpirationDate']").html(objUserProfile.LicenseExpiryDate);

                showSuccessMessage("Profile updated successfully!");
                $("#divDialogProfileDrivingLicenseInformation").dialog("close");
            });
        }

        function click_EditProfileProfessionalLicenseInformation() {

            $.post(h + "/Controls/ProfessionalLicenseHandler.aspx", {}, function (data) {
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");

                var response = $.trim(data.substring(start, end));

                $("#divDialogProfileProfessionalLicenseInformation").html(response);

                initializeProfessionalLicenseUpload();

                $("#divDialogProfileProfessionalLicenseInformation").dialog({
                    title: "Professional License Information",
                    modal: true,
                    width: "800",
                    buttons: {
                        "Save": function () {
                            updateProfileProfessionalLicenseInformation();
                        },
                        "Cancel": function () {
                            $(this).dialog("close");
                        }
                    },
                    close: function () {
                        $(this).dialog("destroy");
                    }
                });
            });
        }

        function updateProfileProfessionalLicenseInformation() {
            var isErrorQualification = false;

            var qualificationRowsLength = $("#tblQualifications tr").length;

            if (qualificationRowsLength == 0) {
                showErrorMessage("Please add atleast one record to save.");
                return;
            }

            var qualificationArr = new Array();
            $("#tblQualifications tr").each(function () {
                if ($(this).find("input.hdnFlagCertificate").val() == "1") {
                    var qualification = new Object();
                    qualification.ServiceProviderQualificationId = $.trim($(this).find("input.hdnqualificationid").first().val());
                    qualification.ServiceProviderId = $.trim($("[id$='hdnServiceProviderId']").val());
                    qualification.QualificationId = $(this).find("select").val();
                    var issueDate = $.trim($(this).find("input.issueDate").val());
                    var expiryDate = $.trim($(this).find("input.ExpDate").val());

                    if (issueDate == "") {
                        isErrorQualification = true;
                        $(this).find("input.issueDate").addClass("error");
                        showErrorMessage("Error: Please enter Issue Date.");
                        return false;
                    }

                    if (expiryDate == "") {
                        isErrorQualification = true;
                        $(this).find("input.ExpDate").addClass("error");
                        showErrorMessage("Error: Please enter Expiration Date.");
                        return false;
                    }

                    if (Date.parse(issueDate) > Date.parse(expiryDate)) {
                        isErrorQualification = true;
                        $(this).find("input.issueDate").addClass("error");
                        $(this).find("input.ExpDate").addClass("error");
                        showErrorMessage("Error: Date Expiry can not be earlier than Issue Date.");
                        return false;
                    }

                    var filename = $.trim($(this).find("input.hdnImgPath").val());
                    qualification.IssueDate = issueDate;
                    qualification.ExpiryDate = expiryDate;
                    qualification.Attachment = filename;
                    qualificationArr.push(qualification);
                }
            });

            if (!isErrorQualification) {

                var ServiceProviderId = $.trim($("[id$='hdnServiceProviderId']").val());

                $.post(h + "/UserProfile/ProfileEditHandler.aspx", { QualificationList: JSON.stringify(qualificationArr), ServiceProviderId: ServiceProviderId, Section: "ProfessionalLicense" }, function (data) {
                    showSuccessMessage("Profile updated successfully!");

                    $("#divDialogProfileProfessionalLicenseInformation").dialog("close");

                    var start = data.indexOf("###StartProfessionalLicense###") + 30;
                    var end = data.indexOf("###EndProfessionalLicense###");
                    var response = $.trim(data.substring(start, end));

                    $("#tbodyProfessionalLicense").html(response);
                });
            }
        }

        function click_EditProfileWebAccount() {
            debugger;
            $("[id$='txtOldPassword']").val("");
            $("[id$='txtProfileNewPassword']").val("");
            $("[id$='txtProfileRepeatNewPassword']").val("")

            $("#divDialogProfileWebAccount").dialog({
                title: "Change Password",
                modal: true,
                width: "400",
                buttons: {
                    "Save": function () {
                        updateProfileWebAccount();
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }


        var res = $("[id$=hdnpassword]").val();
        function updateProfileWebAccount() {
            debugger
            if (!ValidateForm("divDialogProfileWebAccount")) {
                showErrorMessage("");
                return false;
            }

            if ($("[id$='txtProfileNewPassword']").val().length < 4) {
                showErrorMessage("Error: Password must contain at least eight characters!");
                return false;
            }


            //re = /[0-9]/;
            //if (!re.test($("[id$='txtProfileNewPassword']").val())) {
            //    showErrorMessage("Error: password must contain at least one number (0-9)!");
            //    return false;
            //}

            //re = /[a-z]/;
            //if (!re.test($("[id$='txtProfileNewPassword']").val())) {
            //    showErrorMessage("Error: password must contain at least one lowercase letter (a-z)!");
            //    return false;
            //}

            //re = /[A-Z]/;
            //if (!re.test($("[id$='txtProfileNewPassword']").val())) {
            //    showErrorMessage("Error: password must contain at least one uppercase letter (A-Z)!");
            //    return false;
            //}

            var ProfileOldPassword = $.trim($("[id$='txtOldPassword']").val());
            var ProfileNewPassword = $.trim($("[id$='txtProfileNewPassword']").val());
            var ProfileReNewPassword = $.trim($("[id$='txtProfileRepeatNewPassword']").val());

            if (ProfileNewPassword != ProfileReNewPassword) {
                showErrorMessage("Password does not match!");
                return false;
            }

            var objUserProfile = new Object();
            objUserProfile.UserId = $.trim($("[id$='hdnUser']").val());
            objUserProfile.Password = ProfileNewPassword;
            objUserProfile.OldPassword = ProfileOldPassword;
           

            $.post("../../ProviderPortal/UserProfileHandler.aspx", { objUserProfile: JSON.stringify(objUserProfile), Section: "WebAccount" }, function (data) {
                debugger;
             // var response = $("[id$='hdnpassword']").val();
              var returnHtml = data;
              var start = data.indexOf("###StartPassword###") + 21;
              var end = data.indexOf("###EndPassword###");
              var response = $.trim(returnHtml.substring(start, end));
              //alert(res);
              if (response == "InValid") {
                  showErrorMessage("Sorry the Password you entered is not valid!");
              }
              else if (response == "Updated") {
                  showSuccessMessage("Profile updated successfully!");
                  $("#divDialogProfileWebAccount").dialog("close");
              }
           
            });
        }

        function click_CreateProfileDigitalSignature(isNew) {

            if ($("#divDigitalSignatureForm").is(":visible")) {
                hideShowDigitalSignature();
                return;
            }

            $("[id$='txtProfilePINCode']").val("");

            $("#divDialogDigitalPin").dialog({
                title: "Digital Signature PIN",
                modal: true,
                width: "300",
                buttons: {
                    "Ok": function () {
                        profileDigitalPIN(isNew);
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }

        function profileDigitalPIN(isNew) {

            if (!ValidateForm("divDialogDigitalPin")) {
                showErrorMessage("");
                return false;
            }

            var digitalPIN = $.trim($("[id$='txtProfilePINCode']").val());
            if (digitalPIN.length < 4) {
                showErrorMessage("Please enter 4 digits.");
                return false;
            }

            var Section = "DigitalPIN_Verify";

            if (isNew) {
                Section = "DigitalPIN_Create";
            }

            var objUserProfile = new Object();
            objUserProfile.UserId = $.trim($("[id$='hdnUserIdMaster']").val());
            objUserProfile.PINCode = $.trim($("[id$='txtProfilePINCode']").val());

            $.post("/UserProfile/ProfileEditHandler.aspx", { objUserProfile: JSON.stringify(objUserProfile), Section: Section }, function (data) {

                if (isNew) {
                    showSuccessMessage("Profile updated successfully!");

                    if (!$("#divDigitalSignatureForm").is(":visible")) {
                        hideShowDigitalSignature();
                        $("[id$='lblCreateDigitalSignature']").remove();
                        $("[id$='lblViewDigitalSignature']").show();
                    }

                    $("#divDialogDigitalPin").dialog("close");
                }
                else {
                    var returnHtml = data;
                    var start = data.indexOf("###StartPIN###") + 14;
                    var end = data.indexOf("###EndPIN###");
                    var response = $.trim(returnHtml.substring(start, end));

                    if (response == "Valid") {
                        $("#divDialogDigitalPin").dialog("close");

                        $("[id$='divMesg']").hide();

                        if (!$("#divDigitalSignatureForm").is(":visible")) {
                            hideShowDigitalSignature();
                        }
                    }
                    else if (response == "InValid") {
                        showErrorMessage("Sorry the PIN number you entered is not valid!");
                    }
                }
            });
        }

        function hideShowDigitalSignature() {
            $("#divDigitalSignatureForm").slideToggle();
        }

        function click_ChangeProfileDigitalPIN() {

            $("[id$='txtProfileOldPIN']").val("");
            $("[id$='txtProfileNewPIN']").val("");
            $("[id$='txtProfileReNewPIN']").val("");

            $("#divDialogChangeDigitalPin").dialog({
                title: "Change PIN",
                modal: true,
                width: "400",
                buttons: {
                    "Ok": function () {
                        changeDigitalPIN();
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        }

        function changeDigitalPIN() {

            if (!ValidateForm("divDialogChangeDigitalPin")) {
                showErrorMessage("");
                return false;
            }

            var ProfileOldPIN = $.trim($("[id$='txtProfileOldPIN']").val());
            var ProfileNewPIN = $.trim($("[id$='txtProfileNewPIN']").val());
            var ProfileReNewPIN = $.trim($("[id$='txtProfileReNewPIN']").val());

            if (ProfileNewPIN != ProfileReNewPIN) {
                showErrorMessage("PIN does not match!");
                return false;
            }

            var objUserProfile = new Object();
            objUserProfile.UserId = $.trim($("[id$='hdnUserIdMaster']").val());
            objUserProfile.PINCode = ProfileNewPIN;
            objUserProfile.OldPINCode = ProfileOldPIN;

            $.post("/UserProfile/ProfileEditHandler.aspx", { objUserProfile: JSON.stringify(objUserProfile), Section: "DigitalPIN_Update" }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###StartPIN###") + 14;
                var end = data.indexOf("###EndPIN###");
                var response = $.trim(returnHtml.substring(start, end));

                if (response == "InValid") {
                    showErrorMessage("Sorry the PIN number you entered is not valid!");
                }
                else if (response == "Updated") {
                    showSuccessMessage("Profile updated successfully!");
                    $("#divDialogChangeDigitalPin").dialog("close");
                }
            });
        }

        function editQualification(obj) {
            $(obj).closest("tr").find("[id*='divUploadAttachment']").show();
            $(obj).closest("tr").find("[id*='divViewAttachment']").hide();
            $(obj).closest("tr").find("select").removeAttr("disabled");
            $(obj).closest("tr").find("input.issueDate").removeAttr("disabled");
            $(obj).closest("tr").find("input.ExpDate").removeAttr("disabled");
        }

        function removeQualification(obj, qualificationid) {

            $("#dialogconfirmMaster").html("Do you want to delete this License/Certificate?");
            $("#dialogconfirmMaster").dialog({
                resizable: false,
                height: 140,
                width: 300,
                modal: true,
                title: 'Confirmation',
                buttons: {
                    "Yes": function () {
                        if (qualificationid == 0) {
                            $(obj).closest("tr").remove();
                            $("#dialogconfirmMaster").dialog("close");
                        } else {
                            $.post("/Settings/CallBacks/ServiceProviderHandler.aspx", { action: 'Delete Qualification', ServiceProviderQualificationId: qualificationid }, function () {
                                $("#dialogconfirmMaster").dialog("close");
                                $(obj).closest("tr").remove();
                                showSuccessMessage("Success: License/Certificate deleted.");
                                $("#dialogconfirmMaster").dialog("close");
                            });
                        }
                    },
                    "No": function () {
                        $(this).dialog("close");
                    }
                }
            });
        }

        function addQualification() {
            var sampleQualificationRow = $("#tblQualificationSample tr").clone();
            $("#tblQualifications").append(sampleQualificationRow);

            var IssueDateId = "txtIssueDate" + $("#tblQualifications tr").length;
            $("#tblQualifications").find("tr:last").find("input.issueDate").attr("id", IssueDateId);

            $("#" + IssueDateId).datepicker({
                minDate: "01/01/1990",
                maxDate: new Date(),
                changeMonth: true,
                yearRange: "1990:2050",
                changeYear: true
            }).mask("99/99/9999");

            var ExpiryDateId = "txtExpiryDate" + $("#tblQualifications tr").length;
            $("#tblQualifications").find("tr:last").find("input.ExpDate").attr("id", ExpiryDateId);

            $("#" + ExpiryDateId).datepicker({
                minDate: "01/01/1990",
                changeMonth: true,
                yearRange: "1990:2050",
                changeYear: true
            }).mask("99/99/9999");

            callAjaxUpload($("#tblQualifications").find("tr:last").find(".certificates-attachment"));
        }

        function downloadAttachment(filePath, fileName) {
            saveToDisk(filePath, fileName);
        }

        function callAjaxUpload(id) {
            new AjaxUpload(id, {
                action: _ResolveUrl + "HomeHealth/Attachments.ashx",
                dataType: 'json',
                contentType: "application/json; charset=uft-8",
                data: {
                    Directory: "Certificates"
                },
                onSubmit: function (file, ext, fileSize) {
                    if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                        showErrorMessage('Error: invalid file extension');
                        return false;
                    }
                    if (fileSize > 5) {
                        showErrorMessage("This file exceeds the 5MB attachment limit.");
                        return false;
                    }
                },
                onComplete: function (file, response) {
                    var responseHtml = $(response);
                    var r = responseHtml.html();
                    var res = $.parseJSON(r);
                    $(id).closest("tr").find("input.hdnImgPath").val(res.path);
                    $(id).closest("tr").find("input.hdnFlagCertificate").val("1");
                    $(id).closest("tr").find(".uploadedIcon").html("").attr({ title: res.path, onclick: "downloadAttachment('" + $("[id$='hdnCertificatePath']").val() + "/" + res.path + "','" + res.path + "')" }).addClass("iconAttachment").css("margin-right", "43px");
                }
            });
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdnServiceProviderId" runat="server" />
    <asp:HiddenField ID="hdnCertificatePath" runat="server" />

    <div class="contents-box-wrapper">
        <h1 class="contents-box-header">User Profile
        </h1>
        <div class="contents-box-details">
            <div class="profile-sub-box" style="width: 96%;">
                <div class="profile-sub-contents">
                    <div class="profile-image-box">
                        <asp:Image ID="imgUserProfile" Width="125px" Height="130px" runat="server" />
                        <div class="change-photo-wrapper" style="width: 122px; height: 22px;">Change photo</div>
                        <input type="file" value="Upload" id="fuUserProfile" size="1" style="z-index: 5; width: 124px; opacity: 0; position: absolute; cursor: pointer; top: 77%;" />
                    </div>
                    <div class="profile-person-box">
                        <table>
                            <tr>
                                <td>
                                   
                                      <asp:Label runat="server" ID="lblProfileLastName" CssClass="profile-sub-label"></asp:Label>
                                    <asp:Label runat="server" ID="lblProfileFirstName" CssClass="profile-sub-label"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" id="trProfileGender">
                                <td>
                                    <asp:Label runat="server" ID="lblProfileGender" CssClass="profile-sub-label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="profile-edit-link" onclick="click_EditProfilePersonalInformation();">Edit</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="profile-sub-box" runat="server" id="divGeneralInformation" style="display:none">
                <h4>General Information</h4>
                <div class="profile-sub-contents">
                    <table>
                        <tr>
                            <td>
                                <span class="profile-sub-label">NPI:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileNPI" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="label-td">
                                <span class="profile-sub-label">UPIN:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileUPIN" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="profile-sub-label">License No.</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileLicenseNo" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span class="profile-edit-link" onclick="click_EditProfileGeneralInformation();">Edit</span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="profile-sub-box" runat="server" id="divContactInformation">
                <h4>Contact Information</h4>
                <div class="profile-sub-contents">
                    <table>
                        <tr>
                            <td class="label-td">
                                <span class="profile-sub-label">Cell No.</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfilePhoneNumber" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="trProfileOtherPhone" style="display:none">
                            <td>
                                <span class="profile-sub-label">Other Phone No.</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileOtherPhone" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="trProfileFaxNo" style="display:none">
                            <td>
                                <span class="profile-sub-label">Fax No.</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileFax" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="profile-sub-label">Email:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileEmailAddress" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span class="profile-edit-link" onclick="click_EditProfileContactInformation();">Edit</span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="profile-sub-box" runat="server" id="divAddressInformation" style="display:none">
                <h4>Address Information</h4>
                <div class="profile-sub-contents">
                    <table>
                        <tr>
                            <td class="label-td">
                                <span class="profile-sub-label">Street Address:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileStreetAddress" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="profile-sub-label">Zip Code:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileZip" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="profile-sub-label">City:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileCity" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="profile-sub-label">State:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileState" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span class="profile-edit-link" onclick="click_EditProfileAddressInformation();">Edit</span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="profile-sub-box">
                <h4>Web Account</h4>
                <div class="profile-sub-contents">
                    <table>
                        <tr>
                            <td colspan="2">
                                <span class="profile-edit-link" onclick="click_EditProfileWebAccount();">Change Password</span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="profile-sub-box" runat="server" id="divDrivingLisenseInformation" style="display:none">
                <h4>Driving License Information</h4>
                <div class="profile-sub-contents">
                    <table>
                        <tr>
                            <td class="label-td">
                                <span class="profile-sub-label">License No.</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileDrivingLicenseNo" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="profile-sub-label">State:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileDrivingLicenseState" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="profile-sub-label">Issue Date:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileDrivingLicenseIssueDate" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="profile-sub-label">Expiration Date:</span>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblProfileDrivingLicenseExpirationDate" CssClass="profile-sub-text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span class="profile-edit-link" onclick="click_EditProfileDrivingLicenseInformation();">Edit</span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="profile-sub-box" runat="server" id="divProfessionalLisenseInformation" style="display:none">
                <h4>Professional License Information</h4>
                <div class="profile-sub-contents profile-simple-grid">
                    <table>
                        <thead>
                            <tr>
                                <th>
                                    <span>License Type</span>
                                </th>
                                <th>
                                    <span>Issue Date</span>
                                </th>
                                <th>
                                    <span>Expiration</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody id="tbodyProfessionalLicense">
                            <asp:Repeater runat="server" ID="rptProfessionalLicense">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <span class="profile-sub-text"><%#Eval("LicenseName")%></span>
                                        </td>
                                        <td>
                                            <span class="profile-sub-text"><%#Eval("IssueDate")%></span>
                                        </td>
                                        <td>
                                            <span class="profile-sub-text"><%#Eval("ExpiryDate")%></span>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr>
                                <td colspan="3">
                                    <span class="profile-edit-link" onclick="click_EditProfileProfessionalLicenseInformation();">Edit</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="profile-sub-box" runat="server" id="divDigitalSignature" style="display:none">
                <h4>Digital Signature
                    <asp:Label runat="server" ID="lblViewDigitalSignature" CssClass="spanview" Style="float: right; display: none;" onclick="click_CreateProfileDigitalSignature(false);"></asp:Label>
                </h4>
                <div class="profile-sub-contents">
                    <div>
                        <asp:Label runat="server" ID="lblCreateDigitalSignature" CssClass="profile-edit-link" onclick="click_CreateProfileDigitalSignature(true);" Text="Create"></asp:Label>
                    </div>
                    <div id="divDigitalSignatureForm" class="profile-slide-down-wrapper">
                        <table>
                            <tr>
                                <td class="label-td">
                                    <span class="profile-edit-link" onclick="click_ChangeProfileDigitalPIN();">Change PIN No.</span>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Label7" CssClass="profile-sub-text" Text="xxxxx" onclick="click_ChangeProfileDigitalPIN();" Style="cursor: pointer;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div class="profile-image-box" style="width: 100%;">
                                        <asp:Image ID="imgDigitalSignature" Style="width: 100%; height: 100px; border: 1px solid lightgray;" runat="server" />
                                        <div class="change-photo-wrapper" style="width: 100%; height: 22px; padding: 1px 0;">Change signature</div>
                                        <input type="file" value="Upload" id="fuDigitalSignature" size="1" style="z-index: 5; width: 100%; opacity: 0; position: absolute; cursor: pointer; top: 77%;" />
                                    </div>
                                    <div class="div-text-center disable-color">
                                        Signature File
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="divDialogProfilePersonalInformation" style="display: none; margin-top:5px;">
        <table>
            <tr runat="server" id="trProfileTitleDialog" style="display: none;">
                <td>
                    <span class="profile-sub-label">Title:</span>
                </td>
                <td>
                    <select id="ddlProfileTitle">
                        <option value="Mr.">Mr.</option>
                        <option value="Mrs.">Mrs.</option>
                        <option value="Miss.">Miss.</option>
                        <option value="Ms.">Ms.</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">Last Name:</span>
                </td>
                <td>
                    <input type="text" id="txtProfileLastName" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">First Name:</span>
                </td>
                <td>
                    <input type="text" id="txtProfileFirstName" />
                </td>
            </tr>
            <tr runat="server" id="trProfileGenderDialog" style="display: none;">
                <td>
                    <span class="profile-sub-label">Gender:</span>
                </td>
                <td>
                    <select id="ddlProfileGender">
                        <option value="M">Male</option>
                        <option value="F">Female</option>
                    </select>
                </td>
            </tr>
        </table>
    </div>

    <div id="divDialogProfileGeneralInformation" style="display: none;">
        <table>
            <tr>
                <td>
                    <span class="profile-sub-label">NPI:</span>
                </td>
                <td>
                    <input type="text" id="txtProfileNPI" validate="numeric" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">UPIN:</span>
                </td>
                <td>
                    <input type="text" id="txtProfileUPIN" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">License No.</span>
                </td>
                <td>
                    <input type="text" id="txtProfileProviderNo" />
                </td>
            </tr>
        </table>
    </div>

    <div id="divDialogProfileContactInformation" style="display: none; margin-top:5px">
        <table>
            <tr>
                <td>
                    <span class="profile-sub-label">Cell No.</span>
                </td>
                <td>
                    <input type="text" id="txtProfilePhoneNumber" class="phone" />
                </td>
            </tr>
            <tr runat="server" id="trProfileOtherPhoneDialog" style="display:none">
                <td>
                    <span class="profile-sub-label">Other Phone No.</span>
                </td>
                <td>
                    <input type="text" id="txtProfileOtherPhone" class="phone" />
                </td>
            </tr>
            <tr runat="server" id="trProfileFaxNoDialog" style="display:none">
                <td>
                    <span class="profile-sub-label">Fax No:</span>
                </td>
                <td>
                    <input type="text" id="txtProfileFax" class="phone" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">Email:</span>
                </td>
                <td>
                    <input type="text" id="txtProfileEmailAddress" class="validateEmail" />
                </td>
            </tr>
        </table>
    </div>

    <div id="divDialogProfileAddressInformation" style="display: none;">
        <table>
            <tr>
                <td>
                    <span class="profile-sub-label">Street Address:</span>
                </td>
                <td>
                    <input type="text" id="txtProfileStreetAddress" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">Zip Code:</span>
                </td>
                <td style="position: relative;">
                    <input type="text" id="txtProfileZip" maxlength="10" validate="numeric" onkeyup="getZipCityState(this,'txtProfileZip','txtProfileCity','ddlProfileState');" />
                    <div class="inline-search-wrapper" style="top: 35px; width: 230px;">
                        <div class="divZipCityResult" style="width: 99%;">
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">City:</span>
                </td>
                <td style="position: relative;">
                    <input type="text" id="txtProfileCity" onkeyup="getZipCityState(this,'txtProfileZip','txtProfileCity','ddlProfileState');" />
                    <div class="inline-search-wrapper" style="top: 35px; width: 230px;">
                        <div class="divZipCityResult" style="width: 99%;">
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">State:</span>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlProfileState" Enabled="false"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>

    <div id="divDialogProfileDrivingLicenseInformation" style="display: none;">
        <table>
            <tr>
                <td>
                    <span class="profile-sub-label">License No.</span><span class="spnError">*</span>
                </td>
                <td>
                    <input type="text" id="txtProfileDrivingLicenseNo" class="required" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">State:</span><span class="spnError">*</span>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlDrivingLicenseState" class="required"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">Issue Date:</span><span class="spnError">*</span>
                </td>
                <td>
                    <input type="text" id="txtProfileDrivingLicenseIssueDate" class="license-date required" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">Expiration Date:</span><span class="spnError">*</span>
                </td>
                <td>
                    <input type="text" id="txtProfileDrivingLicenseIssueExpirationDate" class="license-date-expiry required" />
                </td>
            </tr>
        </table>
    </div>

    <div id="divDialogProfileProfessionalLicenseInformation" style="display: none;"></div>

    <table id="tblQualificationSample" style="display: none;">
        <tr>
            <td style="width: 15%;">License/Certificate
            </td>
            <td style="width: 24%;">
                <asp:DropDownList ID="ddlQualification" Style="width: 95%;" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 8%; white-space: nowrap;">Issue Date
            </td>
            <td style="width: 12%;">
                <input id="Text3" class="date issueDate" style="width: 90%;" runat="server" type="text" />
            </td>
            <td style="width: 8%; text-align: center;">Expiration
            </td>
            <td style="width: 12%;">
                <input id="Text4" class="date ExpDate" style="width: 90%;" runat="server" type="text" />
            </td>
            <td style="color: blue; text-align: center; width: 170px;">
                <div style="width: 118px; margin: 0 auto;">
                    <div class="certificates-attachment" style="cursor: pointer;">
                        <span class="uploadedIcon">Upload Attachment</span>
                    </div>
                    <input type="hidden" class="hdnImgPath" />
                    <input type="hidden" value="1" class="hdnFlagCertificate" />
                    <input type="hidden" value="0" class="hdnqualificationid" />
                </div>
            </td>
            <td>
                <span class="spandelete" onclick="removeQualification(this,0)"></span>
            </td>
        </tr>
    </table>

    <div id="divDialogProfileWebAccount" style="display: none;">
        <table>
            <tr>
                <td style="width: 140px;">
                    <span class="profile-sub-label">Old Password:</span><span class="spnError">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password" CssClass="required"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 140px;">
                    <span class="profile-sub-label">New Password:</span><span class="spnError">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtProfileNewPassword" TextMode="Password" CssClass="required"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">Repeat New Password:</span><span class="spnError">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtProfileRepeatNewPassword" TextMode="Password" CssClass="required"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right" style="padding-right: 10px;">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtProfileRepeatNewPassword" ControlToCompare="txtProfileNewPassword" ErrorMessage="Password not match!" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
        </table>

        <div style="line-height: 20px;">
            Password Rules
            <br />
            -Must Start with an alphabet<br />
            -Should be minimum 8 digit in length<br />
            - One Upper Case and One Special character and one number
        </div>
    </div>

    <div id="divDialogDigitalPin" style="display: none;">
        <table>
            <tr>
                <td>
                    <span class="profile-sub-label">Enter PIN No.</span><span class="spnError">*</span>
                </td>
                <td>
                    <input type="password" id="txtProfilePINCode" class="required" maxlength="4" />
                </td>
            </tr>
        </table>
    </div>

    <div id="divDialogChangeDigitalPin" style="display: none;">
        <table>
            <tr>
                <td>
                    <span class="profile-sub-label">Enter Old PIN No.</span><span class="spnError">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtProfileOldPIN" CssClass="required" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">Enter New PIN No.</span><span class="spnError">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtProfileNewPIN" CssClass="required" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="profile-sub-label">Re Enter New PIN No.</span><span class="spnError">*</span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtProfileReNewPIN" CssClass="required" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnUserIdMaster" runat="server" />
          <asp:HiddenField ID="hdnUser" runat="server" />
         <asp:HiddenField ID="hdnpassword" runat="server" />
   
    </div>
    
   
</asp:Content>
