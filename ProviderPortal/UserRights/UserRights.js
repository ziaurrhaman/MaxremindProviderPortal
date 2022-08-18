var _UserId = 0;
var _RoleChanged = false;

$(document).ready(function () {    
    $("#tblUserRoles input").change(function () {
        _RoleChanged = true;
    });
    var i = 99;
    $(".dropDownMenu").each(function () {
        $(this).css({ "z-index": i });
        i--;
    });

 
 

});
$(document).on("click", "body", function (event) {
    if ($(event.target).hasClass("dropDownIcon"))
        return true;
    if ($(event.target).hasClass("selectedText")) {
        if ($.trim($(event.target).html()) != "") {
            $(event.target).closest("tr").find(".moduleRight >input").prop("checked", true);
        } else {
            $(event.target).closest("tr").find(".moduleRight >input").prop("checked", false);
        }

        return true;
    }

    if ($(event.target).parent().is("label.checkBoxStatus")) {
        var objAll = $(event.target).closest("li").find("input");
        if ($(objAll).attr("id") == "All") {
            if ($(objAll).is(":checked")) {
                $(event.target).closest("td").find(".divRightsStauts input").prop("checked", true);
            } else {
                $(event.target).closest("td").find(".divRightsStauts input").prop("checked", false);
            }
        } else {

            if ($(objAll).closest("td").find(".divRightsStauts input:checkbox:not(':first')").filter(":checked").length == $(objAll).closest("td").find(".divRightsStauts input:checkbox:not(':first')").length)
                $($(objAll).closest("td").find(".divRightsStauts input")[0]).prop("checked", true);
            else
                $($(objAll).closest("td").find(".divRightsStauts input")[0]).prop("checked", false);
        }
        $(event.target).closest("tr").removeClass("OldRight").addClass("NewRight");
        $(event.target).closest("ul").parent().parent().parent().removeClass("error");
        getRightsStatus($(event.target));
        return true;
    }

    $(".selectedText").each(function () {
        if ($.trim($(this).html()) != "") {
            $(this).closest("tr").find(".moduleRight >input").prop("checked", true);
        } else {
            $(this).closest("tr").find(".moduleRight >input").prop("checked", false);
        }
    })

    if ($(event.target).parent().is("li"))
        return true;
    else {
        $(".divRightsStauts").hide();
    }

});

function getRightsStatus(elem) {
    var statusCode = "";
    $(elem).closest("td").find(".divRightsStauts input:checkbox:checked").each(function () {
        if ($.trim($(this).next().html()) != "All")
        statusCode += $.trim($(this).next().html()) + " ,";
    });
    if ($(elem).closest("td").find(".divRightsStauts input:checkbox:not(':first')").filter(":checked").length == $(elem).closest("td").find(".divRightsStauts input:checkbox:not(':first')").length) {
        $(elem).closest("td").find(".selectedText").text("All");
    } else if (statusCode.length > 0)
        $(elem).closest("td").find(".selectedText").text(statusCode.length > 30 ? (statusCode.substring(0, 30) + "...") : statusCode);
    else
        $(elem).closest("td").find(".selectedText").text("");

    $(elem).closest("td").find(".selectedText").attr("title", statusCode);
}

function HideShowMenu(elem) {
    if ($(".divRightsStauts:visible").length > 0)
        $(".divRightsStauts").hide();
    else {
        $(elem).closest("td").find(".divRightsStauts").slideToggle();
    }
}
function getUserRights(elem, userId, callFrom) {
    debugger;
    if (callFrom == "row" || callFrom == "Save") {
        _UserId = userId;
        resetRightsForm('GetRights');
    } 
    
    $.ajax({
        url:"../UserRights/CallBacks/UserRightsHandler.aspx/GetUserRights",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: "{ 'userId':'" + userId + "'}",
        success: function(data) {
            showUserRightsSuccess(data, true);
        }
    });
    
    if (callFrom == "row" || callFrom == "Edit") {
        $("#UsersList tr").removeClass("trSelected");
        $(elem).closest("tr").addClass("trSelected");
    }
}

function showUserRightsSuccess(data, needRole) {
    var rights = data.d;
    var rightsList = rights.usrRightsList;

    for (var x = 0; x < rightsList.length; x++) {
        var rightTr = $("#tblRights tr.tr_" + rightsList[x].ModuleRightId);        
        $(rightTr).find("span.spanUserRightsId").html(rightsList[x].UserRightsId);
        $(rightTr).addClass("OldRight");
        if (rightsList[x].Selected == "True")
            $(rightTr).find(".moduleRight >input").prop("checked", true);
        else
            $(rightTr).find(".moduleRight >input").prop("checked", false);
        var currentElemCss = $.trim($(rightTr).find("span.spanModuleRightId").attr("class").split(' ')[0]);
        if ($(rightTr).closest("table").find(".moduleRight >input").length == $(rightTr).closest("table").find(".moduleRight >input:checked").length) {
            $(rightTr).closest("table").closest("tr").prev().find(".subModuleNameChkBox >input").prop("checked", true);    
        }
        
        var currentSubModules = $("#tblModulesWrapper").find("span." + $.trim(currentElemCss)).prev();
        if ($(currentSubModules).find("input:checked").length == $(currentSubModules).find("input").length) {
            $("#tblModulesWrapper").find("span." + $.trim(currentElemCss) + "_Parent").prev().find("input").prop("checked", true);
        }
        
        if (rightsList[x].Status != "")
        bindRightsStatus(rightTr, rightsList[x].Status);
    }    
    if (needRole) {        
        var rolesList = rights.roleList;
        for (var b = 0; b < rolesList.length; b++) {
            $("#tblUserRoles  tr.role_" + rolesList[b].RoleId).find("span.userRoleId").html(rolesList[b].UserRoleId);
            if (rolesList[b].Selected == "True")
                $("#tblUserRoles  tr.role_" + rolesList[b].RoleId).find("input").prop("checked", true);
            else
                $("#tblUserRoles  tr.role_" + rolesList[b].RoleId).find("input").prop("checked", false);
        }
    }
    if ($(".masterModule :checked").length == $(".masterModule").length)
        $("#chkAllRoles").prop("checked", true);
}
function bindRightsStatus(rightTr, status) {
    var assignedStatusArray = status.toString().split(",");
    var assignedStatusNameArray = new Array();
    $(rightTr).find(".divRightsStauts input:checkbox").each(function () {
        var elem = $(this);
        $.grep(assignedStatusArray, function (v) {
            if (v == $(elem).attr("id")) {
                $(elem).prop("checked", true);
                assignedStatusNameArray.push($.trim($(elem).next().html()));
            }
        });
    });
    if ($(rightTr).find(".divRightsStauts input:checkbox:not(':first')").filter(":checked").length == $(rightTr).find(".divRightsStauts input:checkbox:not(':first')").length) {
        $($(rightTr).find(".divRightsStauts input")[0]).prop("checked", true);
        $(rightTr).find(".selectedText").html("All");
    } else {
        $($(rightTr).find(".divRightsStauts input")[0]).prop("checked", false);
        if (assignedStatusNameArray.toString().length < 30)
            $(rightTr).find(".selectedText").html(assignedStatusNameArray.toString());
        else
            $(rightTr).find(".selectedText").html(assignedStatusNameArray.toString().substr(0, 30) + "...");
    }
    $(rightTr).find(".selectedText").attr('title', assignedStatusNameArray.toString());
}

function saveUserRightsClick() {
    debugger;
    $("#divMesg").hide();
    $("#divUserRights *").removeClass("error");

    if ($(".tblModulesMaster .moduleRight>input:checked").length == 0) {
        dialogShowMessage("Please select at least 1 rights", "Required");
        return;
    } else {
        debugger;
        var userRolesArray = new Array();
        if (_RoleChanged) {
            $("#tblUserRoles tr").each(function() {
                var userRoles = new Object();
                userRoles.UserRoleId = $.trim($(this).find(".userRoleId").html());
                userRoles.RoleId = $.trim($(this).find(".roleId").html());
                userRoles.UserId = _UserId;
                if (!$(this).find("input[type='checkbox']").is(":checked")) {
                    userRoles.Deleted = true;
                }
                userRolesArray.push(userRoles);
            });
        }
        var isError = false;
        var userRightsArray = new Array();
        $("#tblRights tr.NewRight").each(function () {
            var userRights = new Object();
            userRights.UserRightsId = $.trim($(this).find("span.spanUserRightsId").html());
            userRights.ModuleRightId = $.trim($(this).find("span.spanModuleRightId").html());
            userRights.UserId = _UserId;
            var status = "";
            if ($(this).find(".dropDownMenu").html() != undefined) {
                $(this).find("div.divRightsStauts input:checkbox:checked").each(function () {
                    var statusCode = $(this).attr("id");
                    if (statusCode != "All")
                        status += statusCode + ",";
                });
                if (status == "" && $(this).find(".moduleRight >input").is(":checked")) {
                    isError = true;
                    $(this).find("div.dropDownMenu").addClass("error");
                    showErrorMessage("");
                    return;
                }
                userRights.Status = status.substr(0, status.length - 1);
            }
            userRightsArray.push(userRights);
            if ($(this).find(".moduleRight >input").is(":checked")) {
                userRights.IsIncluded = true;
            } else {
                userRights.IsIncluded = false;
            }
        });
        
        if (!isError) {
            debugger;
            $.post("../UserRights/CallBacks/UserRightsHandler.aspx", { UserId: _UserId, UserRoles: JSON.stringify(userRolesArray), UserRights: JSON.stringify(userRightsArray) }).done(function(data) {
                debugger;
                getUserRights("", _UserId, 'Save');
                var _msg_Updated = "Record Update Successfully";
                showSuccessMessage(_msg_Updated);
            }).fail(function() {
                showErrorMessage("Error: Some error occurred. Unable to save user rights.");
            });
        }
    }
}

function getRolesRights() {
    debugger;
    var rolsId = "";
    $("#tblModulesWrapper input").prop("checked", false);
    $("#tblUserRoles tr").each(function () {
        if ($(this).find("input[type='checkbox']").is(":checked")) {
            rolsId += $.trim($(this).find(".roleId").html()) + ",";
        }
    });    
    $.ajax({
        url:"../UserRights/CallBacks/UserRightsHandler.aspx/GetRoleRights",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: "{ 'roleId':'" + rolsId + "','userId':'" + _UserId + "'}",
        success: function (data) {
            showUserRightsSuccess(data, false);
        }
    });
}

function getRolesRightsSuccess(data) {
    var rights = data.d;
    for (var x = 0; x < rights.length; x++) {
        var rightTr = $("#tblRights tr.tr_" + rights[x].ModuleRightId);
        $(rightTr).find("input").prop("checked", true);
        if ($(rightTr).closest("table").find("tr input[type=checkbox]:checked").length == $(rightTr).closest("table").find("tr input[type=checkbox]").length)
            $(rightTr).closest("table").closest("tr").find(".rightsCheckModuleName input").prop("checked", true);
    }

}
function modifyUserRightsClick(elem, userId) {
    debugger;
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("UserRightEdit")) {
        debugger;
        _UserId = userId;
        if ($(elem).closest("tr").hasClass("trSelected")) {
           // $("#tblUserRoles *").prop("disabled", false);
            $("#tblModulesWrapper *").prop("disabled", false);
            $(".dropDownMenu").prop("disabled", false);
            $("#btncancell").show();
            $("#btnsaveRights").show();
        }

        else {
            resetRightsForm("Edit");
            getUserRights($(elem).closest("tr"), userId, "Edit");
            //$("#tblUserRoles *").prop("disabled", false);
            $("#tblModulesWrapper *").prop("disabled", false);
            $(".dropDownMenu").prop("disabled", false);
            $("#btncancell").show();
            $("#btnsaveRights").show();
        }
    } else {
        $("[id$='divRightsSettings']").html(_msg_UserRightEdit).show();
    }
}

function resetRightsForm(callFrom) {
    $("#btncancell").hide();
    $("#btnsaveRights").hide();
    $("#divMesg").hide();
    
    $("#tblUserRoles *").prop("disabled", true);
    $("#tblModulesWrapper *").prop("disabled", true);
    $("#divUserRights input").prop("checked", false);
    $("div.dropDownMenu .selectedText").text('');
    $(".dropDownMenu").prop("disabled", true);
    $("#divContentsDetails *").removeClass("error");
    $("#tblUserRoles span.userRoleId").html("0");
    $("span.spanUserRightsId").html('0');
    $("#tblRights tr").removeClass("NewRight").removeClass("OldRight");
    $("[id$='divRightsSettings']").hide();
    if (callFrom == "Cancel")
        getUserRights("", _UserId,"Cancel");
}
function checkAllRightsClick() {
   debugger
    if ($("#chkAllRoles").is(":checked")) {
        $(".tblModulesMaster input").prop("checked", true);
        $("[id*=tblRights] tr").addClass("NewRight");
        //$(".tblModulesMaster tr.OldRight").addClass("NewRight");
        $("div.selectedText").html("All");

        //Assidned view check box is false
        $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);
        $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);

    } else {
        $(".tblModulesMaster input").prop("checked", false);
        $("[id*=tblRights] tr").addClass("NewRight");
        //$(".tblModulesMaster tr.OldRight").addClass("NewRight"); 
        $("div.selectedText").html("");

        //Assidned view check box is false
        $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);//Claim
        $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);//Payments
    }
}

function moduleMasterChkBoxClick(chkbox) {
    debugger
    var currentElemCss = $.trim($(chkbox).parent().next().attr("class").split(' ')[0]);
    var activeRights;
    if ($(chkbox).is(":checked")) {
        activeRights = $("#tblModulesWrapper").find("span." + $.trim(currentElemCss.split('_')[0])).prev().find("input:checkbox:not(:checked)");
        $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", true);
        $(activeRights).closest("tr").find("div.selectedText").html("All");
        if ($(".masterModule :checked").length == $(".masterModule").length)
            $("#chkAllRoles").prop("checked", true);
        //Assidned view check box is false
        $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);//Claim
        $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);//Payments

    }
    else {
        activeRights = $("#tblModulesWrapper").find("span." + $.trim(currentElemCss.split('_')[0])).prev().find("input:checked");
        $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", false);
        $(activeRights).closest("tr").find("div.selectedText").html("");
        $("#chkAllRoles").prop("checked", false);

        //Assidned view check box is false
        $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);//Claim
        $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);//Payments
    }
}
function subModuleChkBoxClick(chkbox) {
    debugger;
    var currentElemCss = $.trim($(chkbox).parent().next().attr("class").split(' ')[0]);
    var currentModuleName = $(chkbox).next().html();
    var activeRights;

    if ($(chkbox).is(":checked")) {
        activeRights = $(chkbox).closest("tr").next().find("span.moduleRight input:not(:checked)");
        $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", true);
        $(activeRights).closest("tr").find("div.selectedText").html("All");
        //addded by rizwan 12 dec 2017
        if (currentModuleName == "Claims")
        {
            $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);
        }
        if (currentModuleName == "Payments") {
            $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);//Payments
        }
        ////**////

        if (currentElemCss == "Settings" && currentModuleName == "Practice Locations") {
            if (!$("span.Practice_View").prev().find("input").is(":checked")) {
                $("span.Practice_View").prev().find("input").prop("checked", true);
                $("span.Practice_View").closest("tr").addClass("NewRight");
            }
        } else if (currentElemCss == "Patient" && (currentModuleName == "Patient Insurance" || currentModuleName == "Medication" || currentModuleName == "Allergy")) {
            if (!$("span.Patient_View").prev().find("input").is(":checked")) {
                $("span.Patient_View").prev().find("input").prop("checked", true);
                $("span.Patient_View").closest("tr").addClass("NewRight");
            }
        } else if (currentElemCss == "Billing") {
            if (!$("span.Claims_View").prev().find("input").is(":checked")) {
                $("span.Claims_View").prev().find("input").prop("checked", true);
                $("span.Claims_View").closest("tr").addClass("NewRight");
            }
            if (currentModuleName.indexOf("Submission") > 0) {
                if (!$("span.ClaimSubmission_View").prev().find("input").is(":checked")) {
                    $("span.ClaimSubmission_View").prev().find("input").prop("checked", true);
                    $("span.ClaimSubmission_View").closest("tr").addClass("NewRight");
                }
            } else if (currentModuleName.indexOf("Process") > 0 || currentModuleName.indexOf("EOB") > 0 || currentModuleName.indexOf("PayRoll") > 0) {
                if (!$("span.ClaimPayment_View").prev().find("input").is(":checked")) {
                    $("span.ClaimPayment_View").prev().find("input").prop("checked", true);
                    $("span.ClaimPayment_View").closest("tr").addClass("NewRight");
                }
            }
        }
        
        if ($("#tblModulesWrapper").find("span." + currentElemCss).prev().find("input:checked").length == $("#tblModulesWrapper").find("span." + currentElemCss).prev().find("input").length)
            $("#tblModulesWrapper").find("span." + $.trim(currentElemCss) + "_Parent").prev().find("input").prop("checked", true);

        if ($(".masterModule :checked").length == $(".masterModule").length)
            $("#chkAllRoles").prop("checked", true);

    } else {
        activeRights = $(chkbox).closest("tr").next().find("span.moduleRight input:checked");
        $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", false);
        $(activeRights).closest("tr").find("div.selectedText").html("");

        $("#tblModulesWrapper").find("span." + $.trim(currentElemCss) + "_Parent").prev().find("input").prop("checked", false);
        $("#chkAllRoles").prop("checked", false);
        currentModuleName = $(chkbox).next().html();
        if (currentElemCss == "Settings" && currentModuleName == "Practice") {
            activeRights = $("span.PracticeLocations").closest("tr").next().find("input:checked");
            $(activeRights).prop("checked", false);
            $(activeRights).closest("tr").addClass("NewRight");
            $("span.PracticeLocations").prev().find("input").prop("checked", false);
        }
        else if (currentModuleName == "Patient") {
            activeRights = $("span.Patient").prev().find("input:checked");
            $(activeRights).prop("checked", false);
            $(activeRights).closest("tr").addClass("NewRight");
        } else if (currentElemCss == "Billing" && currentModuleName == "Claims") {
            activeRights = $("span.Billing").prev().find("input:checked");
            $(activeRights).prop("checked", false);
            $(activeRights).closest("tr").addClass("NewRight");
        }
        
    }
}
function moduleRightsChkBoxClick(chkbox) {
    debugger;
    var currentElemCss = $.trim($(chkbox).parent().next().attr("class").split(' ')[0]);
    var currentModuleName = $.trim($(chkbox).closest("table").closest("tr").prev().find("label").html());
    var currentSubModules;
    var activeRights;
    if ($(chkbox).is(":checked")) {
        $(chkbox).closest("tr").addClass("NewRight");
        $(chkbox).closest("tr").find("div.selectedText").html("All");
        $(chkbox).closest("tr").find("div.dropDownMenu input").prop("checked", true);

        if (!$(chkbox).closest("table").find("span[name='View'] input").is(":checked")) {
            activeRights = $(chkbox).closest("table").find("span[name='View']");
            $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", true);
            $(activeRights).closest("tr").find("div.selectedText").html("All");

        }
        if ($(chkbox).closest("table").find(".moduleRight >input").length == $(chkbox).closest("table").find(".moduleRight >input:checked").length)
            $(chkbox).closest("table").closest("tr").prev().find(".subModuleNameChkBox >input").prop("checked", true);

        if (currentElemCss == "Settings" && currentModuleName == "Practice Locations") {
            if (!$("span.Practice_View").closest("tr").find("input").is(":checked")) {
                $("span.Practice_View").closest("tr").find("input").prop("checked", true);
                $("span.Practice_View").closest("tr").addClass("NewRight");
            }

        } else if (currentElemCss == "Patient" && (currentModuleName == "Patient Insurance" || currentModuleName == "Medication" || currentModuleName == "Allergy")) {
            if (!$("span.Patient_View").closest("tr").find("input").is(":checked")) {
                $("span.Patient_View").closest("tr").find("input").prop("checked", true);
                $("span.Patient_View").closest("tr").addClass("NewRight");
            }
        } else if (currentElemCss == "Billing") {
            if (!$("span.Claims_View").closest("tr").find("input").is(":checked")) {
                activeRights = $("span.Claims_View").closest("tr");
                $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", true);
                $(activeRights).closest("tr").find("div.selectedText").html("All");

            }
            if (currentModuleName.indexOf("Submission") > 0) {
                if (!$("span.ClaimSubmission_View").closest("tr").find("input").is(":checked")) {
                    activeRights = $("span.ClaimSubmission_View").closest("tr");
                    $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", true);
                    $(activeRights).closest("tr").find("div.selectedText").html("All");
                }
            } else if (currentModuleName.indexOf("Process") > 0 || currentModuleName.indexOf("EOB") > 0 || currentModuleName.indexOf("PayRoll") > 0) {
                if (!$("span.ClaimPayment_View").closest("tr").find("input").is(":checked")) {
                    activeRights = $("span.ClaimPayment_View").closest("tr");
                    $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", true);
                    $(activeRights).closest("tr").find("div.selectedText").html("All");
                }
            }

        } 

        currentSubModules = $("#tblModulesWrapper").find("span." + $.trim(currentElemCss)).prev();
        if ($(currentSubModules).find("input:checked").length == $(currentSubModules).find("input").length) {
            $("#tblModulesWrapper").find("span." + $.trim(currentElemCss) + "_Parent").prev().find("input").prop("checked", true);
        }

        if ($(".masterModule :checked").length == $(".masterModule").length)
            $("#chkAllRoles").prop("checked", true);

    } else {
        $("#chkAllRoles").prop("checked", false);
        $(chkbox).closest("tr").addClass("NewRight").find("input").prop("checked", false);
        $(chkbox).closest("tr").find("div.selectedText").html("");

        if ($(chkbox).next().html().toLowerCase() == "view") {
            activeRights = $(chkbox).closest("table").find("input:checked");
            $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", false);
            $(activeRights).closest("tr").find("div.selectedText").html("");
        }
        $("#tblModulesWrapper").find("span." + $.trim(currentElemCss.split('_')[0]) + "_Parent").prev().find("input").prop("checked", false);
        $(chkbox).closest("table").closest("tr").prev().find("span.subModuleNameChkBox >input").prop("checked", false);
        currentSubModules = $.trim($(chkbox).closest("table").closest("tr").prev().find("label").html());
        var selectedrightsLenght = $(chkbox).closest("table").closest("tr").find("span.moduleRight input:checked").length;
        if (currentSubModules == "Practice" && selectedrightsLenght == 0) {
            activeRights = $("span.PracticeLocations").closest("tr").next().find("input:checked");
            $(activeRights).prop("checked", false);
            $(activeRights).closest("tr").addClass("NewRight");
            $("span.PracticeLocations").prev().find("input").prop("checked", false);
        } else if (currentSubModules == "Patient" && selectedrightsLenght == 0) {
            activeRights = $("span.Patient").prev().find("input:checked");
            $(activeRights).prop("checked", false);
            $(activeRights).closest("tr").addClass("NewRight");
        } else if (currentSubModules == "Claims" && selectedrightsLenght == 0) {
            activeRights = $("span.Billing").prev().find("input:checked");
            $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", false);
            $(activeRights).closest("tr").find("div.selectedText").html("All");

        }
    }
}

function showHideAllModules(elem) {
    $(".tblModulesMaster").toggle();
    if ($(elem).hasClass("hideIcon"))
        $(elem).removeClass("hideIcon").addClass("showIcon");
    else
        $(elem).removeClass("showIcon").addClass("hideIcon");
}
function showHideSubModules(elem) {
    $(elem).closest("tr").next().find("table").toggle();
    if ($(elem).hasClass("hideIcon"))
        $(elem).removeClass("hideIcon").addClass("showIcon");
    else
        $(elem).removeClass("showIcon").addClass("hideIcon");
}
function showHideModuleRights(elem) {
    $(elem).closest("tr").next().find("table").toggle();
    if ($(elem).hasClass("hideIcon"))
        $(elem).removeClass("hideIcon").addClass("showIcon");
    else
        $(elem).removeClass("showIcon").addClass("hideIcon");
}

//addded by rizwan 12 dec 2017
//Toggle checkboxes all view and assigned view
$('#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3').on('click', function () {
    debugger


    $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_0").removeProp('checked');


    $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_0").change(
      function () {
          $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").removeProp('checked');
      });

});
$('#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_0').on('click', function () {
    debugger


    $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").removeProp('checked');

    $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").change(
        function () {
            $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_0").removeProp('checked');
        });

});

$('#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3').on('click', function () {
    debugger


    $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_0").removeProp('checked');


    $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_0").change(
      function () {
          $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").removeProp('checked');
      });

});
$('#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_0').on('click', function () {
    debugger


    $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").removeProp('checked');

    $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").change(
        function () {
            $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_0").removeProp('checked');
        });

});
