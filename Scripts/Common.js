
var userRightsArray;
var _zipId, _cityId, _stateId;
var _isUserExistError = false;

$(document).on("click", ".divAccrodian h3", function () {
    if ($(this).find("span").hasClass("spaniconUp")) {
        $(".ulWrapper").slideUp("fast");
        $(".divAccrodian").find("span.spaniconDown").removeClass("spaniconDown").addClass("spaniconUp");
        $(this).find("span").removeClass("spaniconUp").addClass("spaniconDown");
        $(".divAccrodian").find("h3.h3Selected").removeClass("h3Selected").addClass("h3unSelected");
        $(this).next().slideDown("fast");
        $(this).removeClass("h3unSelected").addClass("h3Selected");
    }

    $(".ulWrapper-li-Active").removeClass("ulWrapper-li-Active");
});
$(document).on("focusout", "input:text", function () {
    if ($.trim($(this).val()) != "") {
        $(this).removeClass("error");
    }
});
function parseBool(val) {
    if ((typeof val === 'string' && (val.toLowerCase() === 'true' || val.toLowerCase() === 'yes')) || val === 1)
        return true;
    else if ((typeof val === 'string' && (val.toLowerCase() === 'false' || val.toLowerCase() === 'no')) || val === 0)
        return false;

    return null;
}
$(document).on("click", ".accordion h3", function () {
    if ($(this).find("span").hasClass("iconUp")) {
        $(this).find("span").addClass("iconDown").removeClass("iconUp");
        $(this).parent().find("div").eq(0).slideDown("fast");
    }
    else {
        $(this).find("span").addClass("iconUp").removeClass("iconDown");
        $(this).parent().find("div").eq(0).slideUp("fast");
    }
});
$(document).on("click", ".box-header ul li a", function () {
    $(this).parent().siblings().removeClass("active");
    $(this).parent().addClass("active");
});
$(document).on("focus", "input:text , input:radio", function () {
    $("#divError" + $(this).attr("id")).hide();
});
$(document).on("paste", ":input[validate]", function (e) {
    var validateCharacters = e.originalEvent.srcElement.attributes.validate.value;
    $(this).val("");
    var text = e.originalEvent.clipboardData.getData('Text');

    if (validateCharacters == "numeric") {
        var regex = new RegExp("^[0-9]*$");
        if (!regex.test(text)) {
            showErrorMessage("Enter numeric character only");
            return false;
        }
        if (e.originalEvent.srcElement.attributes.allowCharacter != undefined) {
            var allowCharacter = e.originalEvent.srcElement.attributes.allowCharacter.value.split(',');
            if ($.inArray(text.toString(), allowCharacter) == -1) {
                showErrorMessage("Invalid characters entered.");
                return false;
            }
        }
    }
    else if (validateCharacters == "alphabets") {
        var regex = new RegExp("/^[A-z]+$/");
        if (!regex.test(text)) {
            showErrorMessage("Enter alphabets only");
            return false;
        }
    }
    else if (validateCharacters == "alphanumeric") {
        var regex = new RegExp("^[a-zA-Z0-9]*$");
        if (!regex.test(text)) {
            showErrorMessage("Enter alphanumeric only");
            return false;
        }
    }
    else if (validateCharacters == "decimal") {
        var regex = new RegExp("^[0-9.]*$");
        if (!regex.test(text)) {
            showErrorMessage("Enter decimal only");
            return false;
        }
        var characterLimitBeforeDigit = e.originalEvent.srcElement.attributes.characterLimitBeforeDigit == undefined ? 8 : e.originalEvent.srcElement.attributes.characterLimitBeforeDigit.value;
        var characterLimitAfterDigit = e.originalEvent.srcElement.attributes.characterLimitAfterDigit == undefined ? 2 : e.originalEvent.srcElement.attributes.characterLimitAfterDigit.value;
        var decimal_regex = new RegExp("^\\d{1," + characterLimitBeforeDigit + "}(\\.\\d{1," + characterLimitAfterDigit + "})?$");
        if (!decimal_regex.test(text)) {
            showErrorMessage("Enter valid decimal (00.00) only");
            return false;
        }
    }
    else if (validateCharacters == "NumericExpression") {
        var regex = new RegExp("^[0-9-]*$");
        if (!regex.test(text)) {
            showErrorMessage("Enter numeric only");
            return false;
        }
    }


});
$(document).on("keypress", ":input[validate]", function (e) {
    var validateCharacters = e.originalEvent.srcElement.attributes.validate.value;
    var keycode = (e.which) ? e.which : e.keyCode;
    if (validateCharacters == "numeric") {
        if (keycode < 48 || keycode > 57) {
            return false;
        }
        if (e.originalEvent.srcElement.attributes.allowCharacter != undefined) {
            var allowCharacter = e.originalEvent.srcElement.attributes.allowCharacter.value.split(',');
            var currentCharacter = String.fromCharCode(keycode)
            if ($.inArray(currentCharacter.toString(), allowCharacter) == -1) {
                showHideErrorMessage("This character is not allowed.");
                return false;
            }
        }
    }
    else if (validateCharacters == "alphabets") {
        if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
            return false;
        }
    }

    else if (validateCharacters == "alphanumeric") {
        if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
            return false;
        }
    }

    else if (validateCharacters == "decimal") {
        var characterLimitAfterDigit = 2;
        if (e.originalEvent.srcElement.attributes.characterLimitAfterDigit != undefined) {
            characterLimitAfterDigit = e.originalEvent.srcElement.attributes.characterLimitAfterDigit.value;
        }
        if (!ValidateDecimalLimitedDigitBeforeDecimalPoint(e, this, 10, characterLimitAfterDigit)) {
            return false;
        };

    }

    else if (validateCharacters == "NumericExpression") {
        if ((keycode == 8 && keycode == 46) || (keycode >= 48 && keycode <= 57)) {
            return true;
        }
        else {
            var expression = e.originalEvent.srcElement.attributes.expression.value.split(',');
            var isExisit = false;
            for (var b = 0; b < expression.length; b++) {
                if (keycode == expression[b])
                    isExisit = true;
            }
            if (!isExisit)
                return false;
        }
    }
    return true;
});


function getStateCity(zipId, cityId, stateId, callFrom, elem) {
   
    var zipCode;
    if (callFrom == "Table")
        zipCode = $.trim($(zipId).val());
    else
        zipCode = $.trim($("[id$='" + zipId + "']").val());

    if (zipCode != "") {
        $.post(_ResolveUrl + "ProviderPortal/Controls/GetCityStateHandler.aspx", { ZipCode: zipCode },
            function (data) {

                var returnHtml = data;
                var start = data.indexOf("###CityStateStart###") + 20;
                var end = data.indexOf("###CityStateEnd###");
                var cityState = $.trim(returnHtml.substring(start, end));
                var city = $.trim(cityState.split("&&&&&")[0]);
                var state = $.trim(cityState.split("&&&&&")[1]);

                if (city == "" && state == "") {
                    if (callFrom == "Table") {
                        $(elem).closest("tr").find(".city").val("");
                        $(elem).closest("tr").find(".state").val("");
                    } else {
                        $("[id$='" + cityId + "']").val("");
                        $("[id$='" + stateId + "']").val("");
                    }
                    $("#dialogconfirmMaster").html("No City/State found against provided zip code.Please enter valid zip code.");
                    $("#dialogconfirmMaster").dialog({
                        resizable: false,
                        height: 140,
                        width: 530,
                        modal: true,
                        title: 'Error',
                        open: function () {
                            $(".ui-widget-overlay").last().css("z-index", "9999999");
                            $(".ui-dialog").last().css("z-index", "99999999");
                        },
                        buttons: {
                            "Ok": function () {
                                $(this).dialog("close");
                            }
                        },
                        close: function () {
                            $(this).dialog("destroy");
                        }
                    });
                } else {
                    if (callFrom == "Table") {
                        $(elem).closest("tr").find(".city").val(city);
                        $(elem).closest("tr").find(".state").val(state);
                    } else {
                        $("[id$='" + cityId + "']").val(city);
                        $("[id$='" + stateId + "']").val(state);
                    }
                }
            });
    }
    else {
        if (callFrom == "Table") {
            $(elem).closest("tr").find(".city").val("");
            $(elem).closest("tr").find(".state").val("");
        } else {
            $("[id$='" + cityId + "']").val("");
            $("[id$='" + stateId + "']").val("");
        }
    }
}
function getZipCityState(elem, zipId, cityId, stateId, callFrom) {

    
    var zipCode = "", city = "";
    if (callFrom == "Table") {
        if ($(elem).hasClass("zip"))
            zipCode = $.trim($(zipId).val());
        else
            city = $.trim($(cityId).val());

        _zipId = $(elem).closest("tr").find(".zip");
        _cityId = $(elem).closest("tr").find(".city");
        _stateId = $(elem).closest("tr").find(".state");

    }
    else {
        //Changed By Zia(06/08/2017)
        _zipId = $("[id$='" + zipId + "']");
        _cityId = $("[id$='" + cityId + "']");
        _stateId = $("[id$='" + stateId + "']");
        if ($(elem).hasClass("zip")) {
            zipCode = $.trim($("[id$='" + zipId + "']").val());
            //below lines are added by amin ahmed for bug id 5235
            _cityId.val("");
            _stateId.val("");
            //end addition
        }
        else {
            //below lines are added by amin ahmed for bug id 5235
            _zipId.val("");
            _stateId.val("");
            //end addition
            city = $.trim($("[id$='" + cityId + "']").val());
        }
        //End Changed By Zia(06/08/2017)
    }
    if (zipCode != "" || city != "") {
        $.post(_ResolveUrl + "HomeHealth/Controls/GetZipCityState.aspx", { ZipCode: zipCode, City: city },
            function (data) {
                var returnHtml = data;
                var start = data.indexOf("#StartZipCityState#") + 19;
                var end = data.indexOf("#EndZipCityState#");
                $(elem).next().find(".divZipCityResult").html($.trim(returnHtml.substring(start, end)));
                $(elem).next().show();
                if ($(elem).next().find(".divZipCityResult table tr").length == 0) {
                    $(elem).next().find(".divZipCityResult").html("<span style='color: red;font-style: italic;font-weight: bold;'>No Record Found</span>").css({ 'text-align': 'center', 'line-height': '27px' });
                }
            });
    }
    else {
        $(elem).next().hide();
    }
}
function selectZipCityState(zip, city, state) {
   
    $(_zipId).val(zip);
    $(_cityId).val(city);
    $(_stateId).val(state);
    $(".divZipCityResult").hide();
    
}
function ShowConfirmation(message) {
    var def = $.Deferred();

    $("#divMainDialogWrapper").html(message).dialog({
        title: "Confirmation!",
        resizable: false,
        modal: true,
        width: 'auto',
        height: 'auto',
        buttons: {
            "Yes": function () {
                $(this).dialog("close");
                def.resolve();
            },
            "No": function () {
                $(this).dialog("close");
                def.reject();
            }
        }
    });

    return def.promise();
}
function ShowError(elementId, errorMessage) {
    if ($("#divError" + elementId).length < 1) {
        $('.errorToolTip').eq(0).clone().attr("id", "divError" + elementId).insertAfter(".errorToolTip :last")
    }

    $("#divError" + elementId).show();
    $("#divError" + elementId).css("width", $("[id$=" + elementId + "]").width());
    $("#divError" + elementId).css("top", $("[id$=" + elementId + "]").offset().top - $(".errorToolTip").height() - 10);
    //$("#divError" + elementId).css("left", $("[id$=" + elementId + "]").offset().left + parseInt($("[id$=" + elementId + "]").width() / 2) - parseInt($(".errorToolTip").width() - 2) + 10);
    $("#divError" + elementId).css("left", $("[id$=" + elementId + "]").offset().left);
    $("#divError" + elementId + " #tdMessage").html(errorMessage);

}
function ValidateForm(formId) {
    debugger
    var flag = true;
    $("#" + formId).find(".required").removeClass("error");
    
    $("[id$=" + formId + "] .required").each(function () {
        if (($.trim($(this).val()) == "" || $(this).val() == 0) && $(this).attr("disabled") != "disabled") {
           
            if (!$(this).hasClass("error")) {
                $(this).addClass("error");
            }
            
            flag = false;
        }
    });
    
    $("[id$=" + formId + "] .validateEmail").each(function () {
        if ($(this).hasClass("required") || $(this).val().length > 0) {
            if (!validateEmail($(this).val())) {
                ShowError($(this).attr("id"), "Enter valid email address.");
                $(".validateEmail").addClass("error");
                flag = false;
            }
        }
    });
    
    if ($("[id$=" + formId + "]").find("input").hasClass("validatePassword")) {
        var password = $("[id$=" + formId + "] .validatePassword").first().val();
        var confirmPassword = $("[id$=" + formId + "] .validatePassword").last().val();

        if (password != confirmPassword) {
            ShowError($("[id$=" + formId + "] .validatePassword").first().attr("id"), "Password does not match.");
            $(this).addClass("error");
            flag = false;
        }
    }
    
    if ($("[id$=" + formId + "]").find("input").hasClass("IsDate")) {
        $("[id$=" + formId + "] .IsDate").each(function () {
            if ($(this).val() != "" && !isDate($(this).val())) {
                if (!$(this).hasClass("error"))
                    $(this).addClass("error");
                flag = false;
            }
        });
    }
    
    // check the Date of Birth is not future date, if so set Today date
    if ($("[id$=" + formId + "]").find("input").hasClass("DOBdate")) {
        $("[id$=" + formId + "] .DOBdate").each(function () {
            if (new Date($(this).val()) > new Date) {
                var currentDate = new Date;
                $(this).val(currentDate.getMonth() + 1 + "/" + currentDate.getDay() + "/" + currentDate.getFullYear());
                if (!$(this).hasClass("error"))
                    $(this).addClass("error");
                flag = false;
            }
        });
    }
    
    if (flag) {
        $("[id$=" + formId + "] .error").removeClass("error");
    }
    
    return flag;
}
function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}
function ValidateAlphabets(value) {
    var filter = /^[a-zA-Z ]+$/;
    var isValid = filter.test(value);
    if (!isValid) {
        return false;
    }
}
function ValidateAlphaNumeric(value) {
    var filter = /^[a-zA-Z0-9]+$/;
    var isValid = filter.test(value);
    if (!isValid) {
        return false;
    }
}
function ValidateNumber(key) {
    var keycode = (key.which) ? key.which : key.keyCode;
    if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
        return false;
    }
}
function ValidateOnlyNumber(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
function ValidateLimitedNumeric(evt, elem, limit) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    if ($(elem).val().length > (limit - 1))
        return false;
    return true;
}
function ValidateRangeNumeric(evt, elem, startRange, endRange) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    if ($(elem).val() < (startRange) || $(elem).val() > (endRange)) {
        $(elem).val($(elem).val().slice(0, -1));
        return false;
    }

    return true;
}
function validateDecimal(evt, elem) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46 && charCode != 8)
        return false;
    else {
        var len = elem.value.length;
        var index = elem.value.indexOf('.');

        if (index > 0 && charCode == 46) {
            return false;
        }
        if (index > 0) {
            var CharAfterdot = (len + 1) - index;
            if (CharAfterdot > 3) {
                return true;       //return false for restriction of 2 digit after '.'
            }
        }
    }
    return true;
}
function ValidateDecimalLimitedDigitBeforeDecimalPoint(evt, elem, digitsbefore, digitsAfter) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46 && charCode != 8)
        return false;
    else {
        var len = elem.value.length;
        var index = elem.value.indexOf('.');

        if (index > 0 && charCode == 46) {
            return false;
        }

        if (charCode != 46 && charCode != 8) {
            if (index == -1) {
                if (len >= digitsbefore) {
                    return false;
                }
            }
            else if (index > 0) {
                if (elem.selectionStart <= index) {
                    var CharBeforedot = $(elem).val().split('.')[0].length;
                    if (CharBeforedot >= digitsbefore) {
                        return false;
                    }
                }
                else {
                    var CharAfterdot = $(elem).val().split('.')[1].length;
                    if (CharAfterdot >= digitsAfter) {
                        return false;       //return false for restriction of 2 digit after '.'
                    }
                }
            }
        }
    }

    return true;
}
function ValidateCharacters(key) {
    var keycode = (key.which) ? key.which : key.keyCode;
    if (keycode >= 65 && keycode <= 90 || keycode >= 97 && keycode <= 122 || keycode == 32)
        return true;
    else
        return false;
}
function ValidateICDDescription(value) {
    var filter = /^[a-zA-Z0-9 -+]+$/;
    var isValid = filter.test(value);
    if (!isValid) {
        return false;
    }
}
function OnlyBackspaceAndDeleteAllowed(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (!(charCode == 8 || charCode == 46))
        return false;
    return true;
}
function ClearFieldOnBackspaceAndDelete(evt, elem) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (!(charCode == 8 || charCode == 46))
        return false;
    $(elem).val("");
    return true;
}
function isDate(txtDate) {
    var currVal = txtDate;
    if (currVal == '')
        return false;
    //Declare Regex 
    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern); // is format OK?
    if (dtArray == null)
        return false;
    //Checks for mm/dd/yyyy format.
    dtMonth = dtArray[1];
    dtDay = dtArray[3];
    dtYear = dtArray[5];
    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
        return false;
    else if (dtMonth == 2) {
        var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
        if (dtDay > 29 || (dtDay == 29 && !isleap))
            return false;
    }
    return true;
}
function IsFutureDate(dateToCheck) {
    return dateToCheck.toJSON().slice(0, 10) > new Date().toJSON().slice(0, 10);
}
function CurrentDateTime() {
    var sysTime = new Date();

    var Year = sysTime.getFullYear();
    var Month = (sysTime.getMonth() + 1);
    var CurrentDate = sysTime.getDate();

    var Hours = sysTime.getHours();
    var Minutes = sysTime.getMinutes();
    var Seconds = sysTime.getSeconds();
    var Milliseconds = sysTime.getMilliseconds();

    return Year + "-" + Month + "-" + CurrentDate + " " + Hours + ":" + Minutes + ":" + Seconds + "." + Milliseconds;
}
function CurrentSystemDate() {
    var sysTime = new Date();

    var Year = sysTime.getFullYear();
    var Month = (sysTime.getMonth() + 1);
    if (Month < 10) Month = "0" + Month;
    var CurrentDate = sysTime.getDate();
    if (CurrentDate < 10) CurrentDate = "0" + CurrentDate;

    return Month + "/" + CurrentDate + "/" + Year;
}
function WindowHeight() {
    return window.innerHeight - 5;
}
function SetElementDynamicHeight(ElementId, ElementFromTop, ElementToTop, ElementMinusId, CustomMinusAmount) {
    var FromTop = $("[id$='" + ElementFromTop + "']").offset().top;
    var ToTop = 0;

    if (ElementToTop == "") {
        ToTop = WindowHeight();
    }
    else {
        ToTop = $("[id$='" + ElementToTop + "']").offset().top;
    }

    var Minus = $("[id$='" + ElementMinusId + "']").height();

    var DynamicHeight = ToTop - FromTop - Minus - CustomMinusAmount;

    $("[id$='" + ElementId + "']").css({ height: DynamicHeight });
}


$(function () {
    BindLoadingDiv();
    /*********added by shahid kazmi 2/6/2018 for bug 7200*****/
    LoadDocuments();
    /**********end shahid kazi 2/6/2018********/
});
function LoadDocuments() {
   
    var PatientId = $("[id$=hdnPatientId]").val();
    $.post(_EMRPath + "/PatientDocument/PatientDocument.aspx", { PatientId: _PatientId }, function (data) {
        var start = data.indexOf("###StartDocument###") + 19;
        var end = data.indexOf("###EndDocument###");
        var returnHtml = $.trim(data.substring(start, end));

        $("[id$='divDocumentsMain']")
        .html(returnHtml)
        .promise()
        .done(function () {
            $("[id$='divDocumentsMain']").show();
        });
    });
}
function BindLoadingDiv() {
    $(document).ajaxStart(function () {
        $("#divLoading").show();
        $("#divOverlay").show();
        $("#divLoading").css("top", Math.max(0, (($(window).height() - $("#divLoading").outerHeight()) / 2) + $(window).scrollTop()) + "px");
        $("#divLoading").css("left", Math.max(0, (($(window).width() - $("#divLoading").outerWidth()) / 2) + $(window).scrollLeft()) + "px");
    });

    $(document).ajaxComplete(function (event, xhr, settings) {
        $("#divLoading").hide(); $("#divOverlay").hide();
    });
}
function UnBindLoadingDiv() {
    $(document).ajaxStart(function () {
        $("#divLoading").hide(); $("#divOverlay").hide();
    });
}
function RowsChange(callFunc) {
  
        var callfunction = eval(callFunc);
        callfunction(0, true);
}
function GeneratePaging(TotalRows, PageRows, parentdiv, callfunc) {
    
    if (parseInt(TotalRows) == 0) {
        $("#" + parentdiv + " .spanInfo").html("No record found.");
        $("#" + parentdiv + " .spanInfo").css({ "color": "red", "font-size": "14px", "font-weight": "bold", "font-style": "italic" });
        $("#" + parentdiv + " .PageButtons ul").html("");
    }
    else if (parseInt(TotalRows) < parseInt(PageRows)) {
        var pagingHtml = "";
        pagingHtml = "<li><a href='javascript:void(0)' title='First' onclick='FirstPage(\"" + parentdiv + "\");' id='First'><span style='margin:5px;' class='iconFirst' alt='Previous'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Previous' onclick='PreviousPage(\"" + parentdiv + "\");' id='Previous'><span style='margin:5px;' class='iconPrevious' alt='Previous'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Page 1' id='" + parentdiv + "Page0'><b>1</b></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Next' onclick='NextPage(\"" + parentdiv + "\");' id='Next'><span style='margin:5px;' class='iconNext' alt='Next'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Last' onclick='FirstPage(\"" + parentdiv + "\");' id='First'><span style='margin:5px;' class='iconLast' alt='Last'></span></a></li>";
        $("#" + parentdiv + " .PageButtons ul").html(pagingHtml);
        $("#" + parentdiv + " .spanInfo").removeAttr("style");
    }

    else {
        var pagingHtml = "";
        pagingHtml = "<li><a href='javascript:void(0)' title='First' onclick='FirstPage(\"" + parentdiv + "\");' id='First'><span style='margin:5px;' class='iconFirst' alt='Previous'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Previous' onclick='PreviousPage(\"" + parentdiv + "\");' id='Previous'><span style='margin:5px;' class='iconPrevious' alt='Previous'></span></a></li>";

        var pages = (TotalRows % PageRows) == 0 ? (TotalRows / PageRows) : parseInt((TotalRows / PageRows)) + 1;

        for (var i = 0; i < pages; i++) {
            pagingHtml += "<li><a href='javascript:void(0)' title='Page" + (i + 1) + "' onclick='GetRecords(this," + (i) + ",\"" + parentdiv + "\"," + callfunc + ");' id='" + parentdiv + "Page" + (i) + "'><b>" + (i + 1) + "</b></a></li>";
        }

        pagingHtml += "<li><a href='javascript:void(0)' title='Next' onclick='NextPage(\"" + parentdiv + "\");' id='Next'><span style='margin:5px;' class='iconNext' alt='Next'></span></a></li>";
        pagingHtml += "<li><a href='javascript:void(0)' title='Last' onclick='LastPage(\"" + parentdiv + "\");' id='First'><span style='margin:5px;' class='iconLast' alt='Last'></span></a></li>";
        //pagingHtml += '<li class="sep"></li>';
        //pagingHtml += '<li><a href="javascript:void(0)"><img src="../images/arrow-circle.png" width="16" height="16"></a></li>';
        $("#" + parentdiv + " .PageButtons ul").html(pagingHtml);
        $("#" + parentdiv + " .spanInfo").removeAttr("style");
    }

    $("#" + parentdiv + "Page0").parent().addClass("current");
    HideShowPages(parentdiv);
}
function GetRecords(obj, pageNumber, parentdiv, callfunc) {
    if (!$(obj).hasClass("current")) {
        //FilterRecord(pageNumber);
        callfunc(pageNumber, false);
    }
    $("#" + parentdiv + " .PageButtons li.current").removeClass("current");
    $("#" + parentdiv + "Page" + pageNumber).parent().addClass("current");

    HideShowPages(parentdiv);

}
function FirstPage(parentdiv) {
    $("#" + parentdiv + " .PageButtons ul li").first().next().next().find("a").click();
}
function LastPage(parentdiv) {
    $("#" + parentdiv + " .PageButtons ul li").last().prev().prev().find("a").click();
}
function PreviousPage(parentdiv) {
    var PreviousPage = $("#" + parentdiv + " .PageButtons li.current").prev().find("a");
    if (PreviousPage.attr("id") != "Previous") {
        $("#" + parentdiv + " .PageButtons li.current").prev().find("a").click();
    }
}
function NextPage(parentdiv) {
    var NextPage = $("#" + parentdiv + " .PageButtons li.current").next().find("a");
    if (NextPage.attr("id") != "Next") {
        $("#" + parentdiv + " .PageButtons li.current").next().find("a").click();
    }
}
function HideShowPages(parentdiv) {
    if ($("#" + parentdiv + " .PageButtons ul li").length > 9) {
        $("#" + parentdiv + " .PageButtons ul li").hide();
        $("#" + parentdiv + " .PageButtons ul li").first().show();
        $("#" + parentdiv + " .PageButtons ul li").first().next().show();
        $("#" + parentdiv + " .PageButtons ul li").last().show();
        $("#" + parentdiv + " .PageButtons ul li").last().prev().show();

        if (($("#" + parentdiv + " .PageButtons ul li").length - 4) - ($("#" + parentdiv + " .PageButtons li.current").index() - 1) > 2) {
            if ($("#" + parentdiv + " .PageButtons li.current").index() > 3) {
                $("#" + parentdiv + " .PageButtons ul li").slice($("#" + parentdiv + " .PageButtons li.current").index(), ($("#" + parentdiv + " .PageButtons li.current").index() + 3)).show();
                $("#" + parentdiv + " .PageButtons ul li").slice(($("#" + parentdiv + " .PageButtons li.current").index() - 2), $("#" + parentdiv + " .PageButtons li.current").index()).show();
            }
            else if ($("#" + parentdiv + " .PageButtons li.current").index() < 4) {
                $("#" + parentdiv + " .PageButtons ul li").slice(2, 7).show();
            }
        }

        else {
            $("#" + parentdiv + " .PageButtons ul li").slice(($("#" + parentdiv + " .PageButtons ul li").length - 7), ($("#" + parentdiv + " .PageButtons ul li").length - 2)).show();
        }
    }
}
function dialogShowMessage(msg, title) {
    $("#dialogShowMessage").html(msg);

    $("#dialogShowMessage").dialog({
        title: title,
        modal: true,
        open: function () {
            var url = document.URL.split('/');
            var currentDirectory = $.trim(url[url.lastIndexOf("EMR") + 1]);
        },
        buttons: {
            "Ok": function () {
                $(this).dialog("close");
            }
        }
    });
}
function showHideTabs(activeDiv) {
    $(".Tab-Content").css("display", "none");
    $("#" + activeDiv).show();
}
function showHideTab(divTabToShow) {
    $(".inner-tabs > div").hide();
    $("#" + divTabToShow).show();
}
function removejscssfile(filename, filetype) {
    var targetelement = (filetype == "js") ? "script" : (filetype == "css") ? "link" : "none" //determine element type to create nodelist from
    var targetattr = (filetype == "js") ? "src" : (filetype == "css") ? "href" : "none" //determine corresponding attribute to test for
    var allsuspects = document.getElementsByTagName(targetelement)
    for (var i = allsuspects.length; i >= 0; i--) { //search backwards within nodelist for matching elements to remove
        if (allsuspects[i] && allsuspects[i].getAttribute(targetattr) != null && allsuspects[i].getAttribute(targetattr).indexOf(filename) != -1) {
            allsuspects[i].parentNode.removeChild(allsuspects[i]) //remove element by calling parentNode.removeChild()
        }
    }
}
function replacejscssfile(oldfilename, newfilename, filetype) {
    var targetelement = (filetype == "js") ? "script" : (filetype == "css") ? "link" : "none" //determine element type to create nodelist using
    var targetattr = (filetype == "js") ? "src" : (filetype == "css") ? "href" : "none" //determine corresponding attribute to test for
    var allsuspects = document.getElementsByTagName(targetelement)
    for (var i = allsuspects.length; i >= 0; i--) { //search backwards within nodelist for matching elements to remove
        if (allsuspects[i] && allsuspects[i].getAttribute(targetattr) != null && allsuspects[i].getAttribute(targetattr).indexOf(oldfilename) != -1) {
            var newelement = createjscssfile(newfilename, filetype)
            allsuspects[i].parentNode.replaceChild(newelement, allsuspects[i])
        }
    }
}
function allowCharacterGroup(e, CharacterGroup, ExtraCharacter, casesensitives) {

    if (CharacterGroup == "abc") CharacterGroup = "abcdefghijklmnopqrstuvwxyz";
    else if (CharacterGroup == "123") CharacterGroup = "1234567890";
    else if (CharacterGroup == "abc123") CharacterGroup = "abcdefghijklmnopqrstuvwxyz1234567890";

    var validchars = CharacterGroup + ExtraCharacter;

    if (!validchars) return true;
    var key = '', keychar = '', obj = '', i = 0;
    var key = e.which ? e.which : window.event.keyCode;

    if (key == null) return true;
    keychar = String.fromCharCode(key);

    if (!casesensitives) {
        keychar = keychar.toLowerCase(); validchars = validchars.toLowerCase();
    }

    if (validchars.indexOf(keychar) != -1)
        return true;
    if (key == null || key == 0 || key == 8 || key == 9 || key == 13 || key == 27)
        return true;
    return false;
}
function allowCharacters(e, validchars, casesensitives) {

    if (!validchars) return true;
    var key = '', keychar = '', obj = '', i = 0;
    var key = e.which ? e.which : window.event.keyCode;

    if (key == null) return true;
    keychar = String.fromCharCode(key);

    if (!casesensitives) {
        keychar = keychar.toLowerCase(); validchars = validchars.toLowerCase();
    }

    if (validchars.indexOf(keychar) != -1)
        return true;
    if (key == null || key == 0 || key == 8 || key == 9 || key == 13 || key == 27)
        return true;
    return false;
}
function restrictCharacters(e, validchars, casesensitives) {

    if (!validchars) return true;
    var key = '', keychar = '', obj = '', i = 0;
    var key = e.which ? e.which : window.event.keyCode;

    if (key == null) return true;
    keychar = String.fromCharCode(key);

    if (!casesensitives) {
        keychar = keychar.toLowerCase(); validchars = validchars.toLowerCase();
    }

    if (validchars.indexOf(keychar) == -1) {
        return true;
    }
    return false;
}
function saveToDisk(fileURL, fileName) {
    var save = document.createElement('a');
    save.href = fileURL;
    //    save.target = '_blank';
    save.download = fileName || 'unknown';

    //    var event = document.createEvent('Event');
    //    event.initEvent('click', true, true);

    var event = document.createEvent("MouseEvents");
    event.initMouseEvent("click", true, true, window,
          0, 0, 0, 0, 0, false, false, false, false, 0, null);
    save.dispatchEvent(event);

    (window.URL || window.webkitURL).revokeObjectURL(save.href);
}
function getEpisodeSupplies() {
    var EpisodeTaskId = $("[id$='hfEpisodeTaskId']").val();

    $.post("../Supplies/GetEpisodeTaskSupplies.aspx", { EpisodeTaskId: EpisodeTaskId },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartSupplies###") + 19;
        var end = data.indexOf("###EndSupplies###");
        $("#suppliesParent").html(returnHtml.substring(start, end));
    });
}
function showSuccessMessage(message) {
    //$(".contentWrapper").scrollTop(0);
    //$(".divMesg").hide();
    $(".divMesg").stop().fadeOut();
    $(".divMesg").html(message).removeClass("warning").addClass("success").fadeIn(2000).fadeOut(10000);
}
function showErrorMessage(mesg) {
   
    $(".divMesg").css({'background-color':'PinK','padding':'5px'});
    $(".divMesg").stop().fadeOut();
    if (mesg != "") {
        $(".divMesg").html(mesg).removeClass("success").addClass("warning").fadeIn(2000).fadeOut(2000);
    } else {
        $(".divMesg").html("Error: Please review the form carefully for the errors.").removeClass("success").addClass("warning").fadeIn(2000).fadeOut(10000);
    }
}
function MergeCells(tableName, colNum) {

    var tds = new Array();
    var mainList = new Array();
    var subList = new Array();

    tds = $(tableName).column(colNum);

    for (var i = 0; i < tds.length; i++) {

        if (i != tds.length - 1) {
            if ($(tds[i]).html().trim() == $(tds[i + 1]).html().trim()) {

                subList.push(tds[i]);

            }
            else {

                subList.push(tds[i]);
                mainList.push(subList);
                subList = new Array();
            }
        }
        else {

            subList.push(tds[i]);
            mainList.push(subList);
            subList = new Array();

        }
    } // end loop


    for (var i = 0; i < mainList.length; i++) {

        var tempList = mainList[i];
        var value = $(tempList[0]).html().trim();
        var firstTd = tempList[0];

        if (tempList.length > 1) {
            for (var j = 1; j < tempList.length; j++) {
                $(tempList[j]).remove();
            }
            $(firstTd).attr("rowspan", tempList.length.toString());
        }
    }
}
function replaceSingleQoutes(value) {

    var filterTextBox = value.replace(/'/g, "`");
    return filterTextBox;

}
function addSingleQuotes(value) {

    var filterTextBox = value.replace("`", "\'");
    return filterTextBox;

}
function callDialog(msg, title) {
    $("#dialogconfirmMaster").html(msg);
    
    $("#dialogconfirmMaster").dialog({
        title: title,
        modal: true,
        height: 140,
        width: 300,
        buttons: {
            "Ok": function () {
                $("#dialogconfirmMaster").dialog("close");
            }
        },
        close: function () {
            $("#dialogconfirmMaster").dialog("destroy");
            
            if (!$(".ui-dialog").is(":visible")) {
                $(".ui-widget-overlay").hide();
            }
        }
    });
}
function showConfirmDialog(msg, callBack) {
    $("#divDialogConfirmationMaster").html(msg).dialog({
        resizable: false,
        modal: true,
        width: 'auto',
        height: 'auto',
        buttons: {
            "Yes": function () {
                $("#divDialogConfirmationMaster").dialog("close");
                eval(callBack);
            },
            "No": function () {
                $("#divDialogConfirmationMaster").dialog("close");
            }
        },
        close: function () {
            $(this).dialog("destroy");
        }
    });
}
function getQueryString(qString) {
    var queryString = decodeURI(location.search);
    if (queryString.length == 0)
        return;
    queryString = queryString.substr(1);

    var qPair = queryString.split("&");

    for (var i = 0; i < qPair.length; i++) {
        var pair = qPair[i].split("=");
        if (pair[0] == qString)
            return pair[1];
    }
}
function printHtml(divId) {
    var thePopup = window.open('', "_blank");
    var printHtml = $("#" + divId).html();
    thePopup.document.write(printHtml);

    var PrintDelay = setTimeout(function () {
        thePopup.print();

        clearTimeout(PrintDelay);
    }, 3000);
}
function selectPatientRow(PatientId, elem) {
    $("#hdnPatientId").val(PatientId);
    $(elem).siblings().removeClass("trSelected");
    $(elem).addClass("trSelected");
}
function printReport(divId) {
    var currentDirectory = document.URL.split('/').lastIndexOf("PatientEHR");
    var thePopup = window.open('', "_blank");
    var printHtml = $("#" + divId).html();

    thePopup.document.writeln('<!DOCTYPE html>');
    thePopup.document.writeln('<html><head><title></title>');
    if (currentDirectory == -1) {
        thePopup.document.writeln('<link rel="stylesheet" type="text/css" href="../../StyleSheets/Print.css">');
    }
    else {
        thePopup.document.writeln('<link rel="stylesheet" type="text/css" href="../StyleSheets/Print.css">');
    }
    thePopup.document.writeln('</head><body>');
    thePopup.document.writeln(printHtml);
    thePopup.document.writeln('</body></html>');
    thePopup.print();
}
function OpenPatientInfo(event, InfoType, PatientId) {
    event.stopPropagation();
    
    if (PatientId == undefined) {
        PatientId = $("[id$='hdnPatientIdAppointmentDetail']").val();
    }

    if ($.trim(InfoType) == "") {
        return;
    }

    RedirectToPatientInfo(PatientId, InfoType);
}
function RedirectToPatientInfo(PatientId, InfoType) {
    window.open(_EMRPath + "/Patient/Demographics.aspx?PatientId=" + PatientId + "&InfoType=" + $.trim(InfoType), '_blank');
}
function ValidateFormWhenComboContainZeroValue(formId) { //When Combo contains zero value in between.
    var flag = true;
    $("#" + formId).find(".required").removeClass("error");
    $("[id$=" + formId + "] .required").each(function () {
        if (($.trim($(this).val()) == "") && $(this).attr("disabled") != "disabled") {
            if (!$(this).hasClass("error"))
                $(this).addClass("error");
            flag = false;
        }
    });

    $("[id$=" + formId + "] .validateEmail").each(function () {
        if (!validateEmail($(this).val()) && $(this).hasClass("error") == false) {
            ShowError($(this).attr("id"), "Enter valid email address.");
            flag = false;
        }
    });
    if ($("[id$=" + formId + "]").find("input").hasClass("validatePassword")) {

        var password = $("[id$=" + formId + "] .validatePassword").first().val();
        var confirmPassword = $("[id$=" + formId + "] .validatePassword").last().val();
        if (password != confirmPassword) {
            ShowError($("[id$=" + formId + "] .validatePassword").first().attr("id"), "Password does not match.");
            $(this).addClass("error");
            flag = false;
        }
    }
    if ($("[id$=" + formId + "]").find("input").hasClass("IsDate")) {
        $("[id$=" + formId + "] .IsDate").each(function () {
            if (!isDate($(this).val())) {
                if (!$(this).hasClass("error"))
                    $(this).addClass("error");

                flag = false;
            }
        });
    }

    if ($("[id$=" + formId + "]").find("input").hasClass("DOBdate")) {
        $("[id$=" + formId + "] .DOBdate").each(function () {
            if (new Date($(this).val()) > new Date) {
                var currentDate = new Date;
                $(this).val(currentDate.getMonth() + 1 + "/" + currentDate.getDay() + "/" + currentDate.getFullYear());
                if (!$(this).hasClass("error"))
                    $(this).addClass("error");
                flag = false;
            }
        });
    }
    return flag;
}
function checkModuleRights(moduleId) {
  debugger
    return moduleId in userRightsArray;
}
function getModuleRightStatus(moduleStatusId, statusCode) {
 
    if (moduleStatusId in userRightsArray) {
        var rightsSatus = userRightsArray[moduleStatusId];
        var arrObject = rightsSatus.split(',');
        return $.inArray(statusCode + "", arrObject) != -1;
    }
    return false;
}
//function hideRightsSettingDiv() {
//    $("[id$='divRightsSettings']").hide();
//}
function applyDatePickerByClass(className) {
    $("." + className).datepicker({
        minDate: "01/01/1930",
        yearRange: "-80:+5",
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");
}
function applyDatePickerById(inputId) {
    $("[id$='" + inputId + "']").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");
}
function formatPhoneNumber(evt, inputField) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if ((charCode < 48 || (charCode > 57 && charCode < 96)) || (charCode > 105) && charCode != 46 && charCode != 8) {
        $(inputField).val($(inputField).val().substr(0, $(inputField).val().length - 1));
        return false;
    }
    var phoneNo = inputField.value;
    phoneNo = phoneNo.replace(/[^0-9]/g, "");
    if (phoneNo.length >= 5)
        $(inputField).val("(" + phoneNo.substr(0, 3) + ") " + phoneNo.substr(3, 3) + "-" + phoneNo.substr(6, 4));
    else if (phoneNo.length >= 2)
        $(inputField).val("(" + phoneNo.substr(0, 3) + ") " + phoneNo.substr(3, 3));
    else
        $(inputField).val("(" + phoneNo.substr(0, 3));
    return true;
}
function setPhoneNoFormat(inputField) {
    var phoneNo = $("[id$='" + inputField + "']").val();
    $("[id$='" + inputField + "']").val("(" + phoneNo.substr(0, 3) + ") " + phoneNo.substr(3, 3) + "-" + phoneNo.substr(6, 4));
}
function getStateCity(zipId, cityId, stateId, callFrom, elem) {
    var zipCode;
    
    if (callFrom == "Table") {
        zipCode = $.trim($(elem).val());
    }
    else {
        zipCode = $.trim($("[id$='" + zipId + "']").val());
    }
    
    if (zipCode != "") {
        if (zipCode.length > 5) {
            zipCode = zipCode.slice(0, 5);
        }
        
        $.post(_ControlPath + "/GetCityStateHandler.aspx", { ZipCode: zipCode }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###CityStateStart###") + 20;
            var end = data.indexOf("###CityStateEnd###");
            var cityState = $.trim(returnHtml.substring(start, end));
            var city = $.trim(cityState.split("&&&&&")[0]);
            var state = $.trim(cityState.split("&&&&&")[1]);
            
            if (city == "" && state == "") {
                if (callFrom == "Table") {
                    $(elem).closest("tr").find(".city").val("");
                    $(elem).closest("tr").find(".state").val("");
                    $(zipId).val("");
                }
                else {
                    $("[id$='" + cityId + "']").val("");
                    $("[id$='" + stateId + "']").val("");
                    $("[id$='" + zipId + "']").val("");
                }
                
                $("#dialogconfirmMaster").html("No City/State found against provided zip code.Pleae enter valid zip code.");
                
                $("#dialogconfirmMaster").dialog({
                    resizable: false,
                    height: 140,
                    width: 330,
                    modal: true,
                    title: 'Confirmation',
                    buttons: {
                        "Ok": function () {
                            $(this).dialog("close");
                        }
                    },
                    close: function () {
                        $(this).dialog("destroy");
                    }
                });
            } else {
                if (callFrom == "Table") {
                    $(elem).closest("tr").find(".city").val(city);
                    $(elem).closest("tr").find(".state").val(state);
                } else {
                    $("[id$='" + cityId + "']").val(city);
                    $("[id$='" + stateId + "']").val(state);
                }
            }
        });
    }
}
function checkUserExist(userId, userName) {
    $("#divMesg").hide();
    $.post(_ControlPath + "/CheckUserExist.aspx", { UserId: userId, UserName: userName }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("#StartUserExistCheck#") + 21;
        var end = data.indexOf("#EndUserExistCheck#");
        var userCount = $.trim(returnHtml.substring(start, end));
        if (parseInt(userCount) > 0) {
            showErrorMessage("Error: User Name already exist.");
            _isUserExistError = true;
        } else {
            _isUserExistError = false;
        }
    });
}
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.search);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
}
function emailFax(To, divId, subject) {
    var divhtml = $("#" + divId);
    var request = JSON.stringify({ To: To, html: divhtml.html(), subject: subject });
    $.ajax({
        type: "POST",
        url: _EMRPath + "/EmailFax.aspx/Email",
        data: request,
        dataType: 'json',
        contentType: "application/json",
        success: function () {
            dialogShowMessage("Email sent successfully", "Alert");
        },
        error: function () {
            dialogShowMessage("Server is not responding.Please try later", "Alert");
        }
    });
}
function ToFax(divId, FaxNumbers, SendFaxDirectly, PatientId, DocumentName, Receiver) {
    var divhtml = $("#" + divId).html();
    var request = JSON.stringify({ Html: divhtml, FaxNumbers: FaxNumbers, SendFaxDirectly: SendFaxDirectly, PatientId: PatientId, DocumentName: DocumentName, Receiver: Receiver });
    $.ajax({
        type: "POST",
        url: _EMRPath + "/EmailFax.aspx/SendFax",
        data: request,
        dataType: 'json',
        contentType: "application/json",
        success: function () {
            showSuccessMessage("Success: Fax sent.");
        },
        error: function () {
            //showErrorMessage("Error: Agency Email account is not set up. Please contact Technical Support!");
        }
    });
}
function GetQueryString(qString) {
    var queryString = decodeURI(location.search);
    if (queryString.length == 0)
        return;
    queryString = queryString.substr(1);

    var qPair = queryString.split("&");

    for (var i = 0; i < qPair.length; i++) {
        var pair = qPair[i].split("=");
        if (pair[0] == qString)
            return pair[1];
    }
}
function AddNoRecordFoundInGrids(tblTbody) {
    if ($("#" + tblTbody + " tr").not(".trNoRecord").length == 0) {
        var colspan = $("#" + tblTbody).parent().find("thead th").length;
        $("#" + tblTbody).html("<tr style='text-align:center;' class='trNoRecord'><td colspan='" + colspan + "'><span Style='color: red; font-size: 14px; font-weight: bold;font-style: italic;'>No record found.</span></td></tr>");
    }
    else
        $("#" + tblTbody + " tr.trNoRecord").remove();
}
function GetDateByLocationUTC(UTCOffset, DateTimeFormat) {
   
    // create Date object for current location
    var d = new Date();

    // convert to msec
    // add local time zone offset 
    // get UTC time in msec
    var utc = d.getTime() + (d.getTimezoneOffset() * 60000);

    // create new Date object for different city
    // using supplied offset
    var nd = new Date(utc + (3600000 * UTCOffset));
    
    if (DateTimeFormat == "Hours") {
        nd = nd.getHours();
    }
    else if (DateTimeFormat == "Date") {
        var Month = nd.getMonth() + 1;
        if (Month.toString().length == 1) Month = "0" + Month;
        
        var Day = nd.getDate();
        if (Day.toString().length == 1) Day = "0" + Day;
        
        var Year = nd.getFullYear();
        if (Year.toString().length == 1) Year = "0" + Year;
        
        nd = Month + "/" + Day + "/" + Year;
    }
    else if (DateTimeFormat == "DateTime12") {
        nd = nd.toString("MM/dd/yyyy hh:mm:ss");
    }
    else if (DateTimeFormat == "DateTime24") {
        nd = nd.toString("MM/dd/yyyy HH:mm:ss");
    }
    else if (DateTimeFormat == "Time") {
        nd = new Date(nd.getTime());
    }
    else if (DateTimeFormat == "Time24") {
        var Hours = nd.getHours();
        if (Hours.toString().length == 1) Hours = "0" + Hours;
        
        var Minutes = nd.getMinutes();
        if (Minutes.toString().length == 1) Minutes = "0" + Minutes;
        
        nd = Hours + ":" + Minutes;
    }
    
    return nd;
}
function GetPracticeLocationCurrentTimeUTC(PracticeLocationsId, DateTimeFormat) {
  
    /// <summary>Get the current location date and/or time.</summary>
    /// <param name="LocationIdParam" type="Number">Location Id</param>
    /// <param name="DateTimeFormatParam" type="String">DateTime Format</param>
    /// <returns type="String">Current Date Time.</returns>

    var UTCOffset = _arrLocationStateUTC[PracticeLocationsId];

    return GetDateByLocationUTC(UTCOffset, DateTimeFormat);
}

$.fn.row = function (i) {
    return $('tr:nth-child(' + (i + 1) + ') td', this);
}
$.fn.column = function (i) {
    return $('tr td:nth-child(' + (i + 1) + ')', this);
}
