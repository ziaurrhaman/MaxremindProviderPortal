var _RoleId = 0;
var _RoleChanged = false;
var _msg_Updated = "Roles Updated Successfully";
var _msg_Created = "Roles Added Successfully";
var _msg_Deleted = "Role Deleted Successfully ";
$(document).ready(function () {
    var i = 99;
    $(".dropDownMenu").each(function () {
        $(this).css({ "z-index": i });
        i--;
    });
});
$(document).on("click", "body", function (event) {
    if ($(event.target).hasClass("dropDownIcon")) {
        return true;
    }

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

            if ($(objAll).closest("td").find(".divRightsStauts input:checkbox:not(':first')").filter(":checked").length == $(objAll).closest("td").find(".divRightsStauts input:checkbox:not(':first')").length) {
                $($(objAll).closest("td").find(".divRightsStauts input")[0]).prop("checked", true);
            }
            else {
                $($(objAll).closest("td").find(".divRightsStauts input")[0]).prop("checked", false);
            }
        }
        $(event.target).closest("tr").addClass("NewRight");
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
    $(elem).closest("td").find(".divRightsStauts input:checkbox:checked").each(function() {
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
function getRoleRights(elem, roleId, roleName, callFrom) {
    
    if (callFrom == "row" || callFrom == "Save") {
        _RoleId = roleId;
        restRolesForm();
    } 
    $.ajax({
        url:"../UserRights/CallBacks/UserRolesHandler.aspx/GetRoleRights",
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: "{ 'roleId':'" + roleId + "'}",
        success: getRoleRightsSuccess
    });
    
    if (callFrom == "row" || callFrom == "Edit") {
        $("#RolesList tr").removeClass("trSelected");
        $(elem).closest("tr").addClass("trSelected");
        $("#txtRoleTitle").val(roleName);
    }
}

function getRoleRightsSuccess(data) {
    var rights = data.d;
    for (var x = 0; x < rights.length; x++) {
        debugger;
        var rightTr = $("#tblRights tr.tr_" + rights[x].ModuleRightId);
        $(rightTr).find(".moduleRight >input").prop("checked", true);
        $(rightTr).find("span.spanRoleModuleRightsId").html(rights[x].RoleModuleRightsId);
        $(rightTr).addClass("OldRight");
        if ($(rightTr).find("span.spanModuleRightId").attr('class') == undefined) {
            continue;
        }
        var currentElemCss = $.trim($(rightTr).find("span.spanModuleRightId").attr("class").split(' ')[0]);
        if ($(rightTr).closest("table").find(".moduleRight >input").length == $(rightTr).closest("table").find(".moduleRight >input:checked").length) {
            $(rightTr).closest("table").closest("tr").prev().find(".subModuleNameChkBox >input").prop("checked", true);
        } 

        var currentSubModules = $("#tblModulesWrapper").find("span." + $.trim(currentElemCss)).prev();
        if ($(currentSubModules).find("input:checked").length == $(currentSubModules).find("input").length) {
            $("#tblModulesWrapper").find("span." + $.trim(currentElemCss) + "_Parent").prev().find("input").prop("checked", true);
        }

        if ($.trim(rights[x].Status) !="")
        bindRightsStatus(rightTr,rights[x].Status);
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
        $(rightTr).find(".selectedText").text("All");
    } else {
        $($(rightTr).find(".divRightsStauts input")[0]).prop("checked", false);
        if (assignedStatusNameArray.toString().length < 30)
            $(rightTr).find(".selectedText").text(assignedStatusNameArray.toString());
        else
            $(rightTr).find(".selectedText").text(assignedStatusNameArray.toString().substr(0, 30) + "...");
    }
    $(rightTr).find(".selectedText").attr('title', assignedStatusNameArray.toString());
}

function saveRoleRightsClick() {
    debugger;
    var roleRightsList = new Array();
    var roleRightsToDelete = "";
    $("#divMesg").hide();
    $("#divRoles *").removeClass("error");    
    if ($.trim($("#txtRoleTitle").val()) == "") {
        $("#txtRoleTitle").addClass("error");
        showErrorMessage("Error: Please enter Role Title.");
        return false;
    }
    if ($(".tblModulesMaster .moduleRight>input:checked").length == 0) {
        showErrorMessage("Error: Please select at least 1 rights.");        
        return false;
    } else {
        var isError = false;
        $("#tblRights tr.NewRight").each(function () {            
            var roleRights = new Object();
            if ($(this).find(".moduleRight >input").is(":checked")) {                
                roleRights.RoleModuleRightsId = $.trim($(this).find("span.spanRoleModuleRightsId").html()) == "" ? 0 : $.trim($(this).find("span.spanRoleModuleRightsId").html());
                roleRights.ModuleRightId = $.trim($(this).find("span.spanModuleRightId").html());
                var status = "";
                if ($(this).find(".dropDownMenu").html() != undefined) {
                    $(this).find("div.divRightsStauts input:checkbox:checked").each(function () {                        
                        var statusCode = $(this).attr("id");
                        if (statusCode != "All")
                            status += statusCode + ",";
                    });
                    if (status == "") {
                        isError = true;
                        $(this).find("div.dropDownMenu").addClass("error");
                        //showErrorMessage("");
                        //return false;
                    }
                    roleRights.Status = status.substr(0, status.length - 1);
                }
                roleRightsList.push(roleRights);
            } else {
                if ($.trim($(this).find("span.spanRoleModuleRightsId").html()) != "")
                    roleRightsToDelete += $.trim($(this).find("span.spanRoleModuleRightsId").html()) + ",";
            }
        });
        if (!isError) {
            
            $.post("../UserRights/CallBacks/UserRolesHandler.aspx", {
           
                RoleId: _RoleId,
                RoleChanged: _RoleChanged,
                RoleTitle: $.trim($("#txtRoleTitle").val()),
                RoleRights: JSON.stringify(roleRightsList),
                RoleRightsToDelete: roleRightsToDelete,
                Action: 'Save'
            }).done(function (data) {
                if (_RoleId == 0) {

                    showSuccessMessage(_msg_Created);
                }
                else {
                    showSuccessMessage(_msg_Updated);
                }
                //                $("#tblModulesWrapper *").prop("disabled", true);
                //                $("#btncancellRoleRights").hide();
                //                $("#btnsaveRoleRights").hide();
                //                $("#btnNewRole").removeAttr("disabled");
                //                $("#txtRoleTitle").attr("disabled", "disabled");
                //                $(".dropDownMenu").prop("disabled", true);
                var returnHtml = data;
                var start = "", end = "";
                start = data.indexOf("###StartRoleId###") + 17;
                end = data.indexOf("###EndRoleId###");
                _RoleId = $.trim(returnHtml.substring(start, end));
                getRoleRights("", _RoleId, "", "Save");

                if (_RoleChanged) {
                    start = data.indexOf("###StartRolesHandler###") + 23;
                    end = data.indexOf("###EndRolesHandler###");
                    $("#RolesList").html(returnHtml.substring(start, end));
                }
                //                $("#btnNewRole").show();
                //                $("#btnModifyRoles").show();
//                $("#RolesList").find("[id$='tr_1']").find("span.spndelete").remove();
//                $("#RolesList").find("[id$='tr_1']").find("span.spnedit").remove();

                restRolesForm("Save");
                $("#RolesList").find("tr[id$='tr_" + _RoleId + "']").addClass("trSelected");

            }).fail(function () {
                showErrorMessage("Error: Some error occurred. Unable to save role rights.");
            });
        } else {
            showErrorMessage("");
        }
    }
}

function deleteRole(elem, roleId) {
    
  
    $(".dropDownMenu").css("z-index", "999");
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("UserRoleDelete")) {
        $("#dialogShowMessage").html("Do you want to delete this Role?");
        $("#dialogShowMessage").dialog({
            resizable: false,
            height: 140,
            width: 300,
            modal: true,
            title: 'Confirmation',
            buttons: {
                "Yes": function () {
                    
                    $.post("../UserRights/CallBacks/UserRolesHandler.aspx", { RoleId: roleId, Action: 'Delete' },
                    function () {
                        if ($(elem).closest("tr").hasClass("trSelected")) {
                            restRolesForm("Delete");
                        }
                        $(elem).closest("tr").remove();
                        if ($("#RolesList tr").length == 0) {
                            $("#RolesList").html("<tr><td colspan='2' style='text-align:center;border-right:none'><span style='color: red;font-size: 14px;font-weight: bold;font-style: italic;'>No record found.<span></td></tr>");
                        }
                    });

                    $("#dialogShowMessage").dialog("close");
                    showSuccessMessage(_msg_Deleted);
                },
                "No": function () {
                    $("#dialogShowMessage").dialog("close");
                }
            }
        });
    } else {
        $("[id$='divRightsSettings']").html(_msg_UserRoleDelete).show();
    }
}


function newRoleClick() {
    
    $("[id$='divRightsSettings']").hide();
   
        $("#tblModulesWrapper *").prop("disabled", false);
        $("#btncancellRoleRights").show();
        $("#btnsaveRoleRights").show();
        $("#tblModulesWrapper input").prop("checked", false);
        $("#RolesList tr").removeClass("trSelected");
        $("#btnNewRole").hide();
        $("#txtRoleTitle").removeAttr("disabled");
        $("#txtRoleTitle").val("");
        $("span.spanRoleModuleRightsId").html('');
        $("div.dropDownMenu .selectedText").text('');
        $("#tblRights tr").removeClass("NewRight");
        _RoleId = 0;
   
}
function modifyRolesClick(elem, roleId, roleName) {
    
    $("[id$='divRightsSettings']").hide();
    if (checkModuleRights("UserRoleEdit")) {
        _RoleId = roleId;
        if ($(elem).closest("tr").hasClass("trSelected")) {
            $("#tblModulesWrapper *").prop("disabled", false);
            $("#btncancellRoleRights").show();
            $("#btnsaveRoleRights").show();
            $("#txtRoleTitle").removeAttr("disabled");
            $("#btnNewRole").hide();
            $(".dropDownMenu").prop("disabled", false);
        } else {
            restRolesForm("Edit");
            getRoleRights($(elem).closest("td"), roleId, roleName, "Edit");
            $("#tblModulesWrapper *").prop("disabled", false);
            $("#btncancellRoleRights").show();
            $("#btnsaveRoleRights").show();
            $("#txtRoleTitle").removeAttr("disabled");
            $("#btnNewRole").hide();
            $(".dropDownMenu").prop("disabled", false);
        }
    } else {
        $("[id$='divRightsSettings']").html(_msg_UserRoleEdit).show();
    }
}

function restRolesForm(callFrom) {
    $("#tblModulesWrapper input").prop("checked", false);
    $("#tblModulesWrapper *").prop("disabled", true);
    $("#btncancellRoleRights").hide();
    $("#btnsaveRoleRights").hide();
    $("#txtRoleTitle").attr("disabled", "disabled");
    $("#btnNewRole").show();
    $("#divMesg").hide();
    $("#divContentsDetails *").removeClass("error");
    $("#tblRights tr").removeClass("NewRight");
    $(".dropDownMenu").prop("disabled", true);
    $("span.spanRoleModuleRightsId").html('');
    $("div.dropDownMenu .selectedText").text('');
    $("[id$='divRightsSettings']").hide();
    if (callFrom == "Cancel" && _RoleId != 0)
        getRoleRights("", _RoleId, "", "Cancel");
}

function roleChanged() {
    _RoleChanged = true;
}

function checkAllRightsClick() {
    if ($("#chkAllRoles").is(":checked")) {
        $(".tblModulesMaster input").prop("checked", true);
        $(".tblModulesMaster tr.OldRight").addClass("NewRight");
        $("div.selectedText").html("All");
        //addded by rizwan 12 dec 2017
        //Assidned view check box is false
        $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);
        $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);
    } else {
        $(".tblModulesMaster input").prop("checked", false);
        $(".tblModulesMaster tr.OldRight").addClass("NewRight");
        $("div.selectedText").html("");
        //addded by rizwan 12 dec 2017
        //Assidned view check box is false
        $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);
        $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);
    }
}


function moduleMasterChkBoxClick(chkbox) {
    
    var currentElemCss = $.trim($(chkbox).parent().next().attr("class").split(' ')[0]);
    var activeRights;
    if ($(chkbox).is(":checked")) {
        activeRights = $("#tblModulesWrapper").find("span." + $.trim(currentElemCss.split('_')[0])).prev().find("input:checkbox:not(:checked)");
        $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", true);
        $(activeRights).closest("tr").find("div.selectedText").html("All");
        if ($(".masterModule :checked").length == $(".masterModule").length)
            $("#chkAllRoles").prop("checked", true);
        //addded by rizwan 12 dec 2017
        //Assidned view check box is false
        $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);//Claim
        $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);//Payments
    }
    else {
        activeRights = $("#tblModulesWrapper").find("span." + $.trim(currentElemCss.split('_')[0])).prev().find("input:checked");
        $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", false);
        $(activeRights).closest("tr").find("div.selectedText").html("");
        $("#chkAllRoles").prop("checked", false);
        //addded by rizwan 12 dec 2017
        //Assidned view check box is false
        $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);//Claim
        $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);//Payments
    }
}
function subModuleChkBoxClick(chkbox) {
    
    var currentElemCss = $.trim($(chkbox).parent().next().attr("class").split(' ')[0]);
    var currentModuleName = $(chkbox).next().html();
    var activeRights;
   

    if ($(chkbox).is(":checked")) {
        activeRights = $(chkbox).closest("tr").next().find("span.moduleRight input:not(:checked)");
        $(activeRights).closest("tr").addClass("NewRight").find("input").prop("checked", true);
        $(activeRights).closest("tr").find("div.selectedText").html("All");


        //addded by rizwan 12 dec 2017

        if (currentModuleName == "Claims") {
            $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").prop("checked", false);//Claims
        }
        if (currentModuleName == "Payments") {
            $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").prop("checked", false);//Payments
        }

        //**//


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
    
    
           
    $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_0").removeProp('checked');


    $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_0").change(
      function () {
          $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").removeProp('checked');
      });

});
$('#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_0').on('click', function () {
    


    $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").removeProp('checked');

    $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_3").change(
        function () {
            $("#rptModulesMaster_rptModules_2_rptModuleRights_0_chkModuleRights_0").removeProp('checked');
        });

});

$('#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3').on('click', function () {
    


    $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_0").removeProp('checked');


    $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_0").change(
      function () {
          $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").removeProp('checked');
      });

});
$('#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_0').on('click', function () {
    


    $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").removeProp('checked');

    $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_3").change(
        function () {
            $("#rptModulesMaster_rptModules_2_rptModuleRights_8_chkModuleRights_0").removeProp('checked');
        });

});