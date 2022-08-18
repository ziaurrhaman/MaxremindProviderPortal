

//******************************Start Appointment Reasons********************************//

function showReasonSettings() {
    $(".contents-details-header").html('Appointment Reasons');
    $(".setting-content-wrapper").hide();
    $("#divAppointmentReasonMain").show();

    if (!checkModuleRights("AppointmentReasonsView")) {
        //showErrorMessage(_msg_AppointmentReasonsView);
        //return false;
    }

    if ($.trim($("#divAppointmentReasonMain").html()).length == 0) {
        $.post(_SettingsPath + "/CallBacks/AppointmentReasonsHandler.aspx", {}, function (data) {
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf(" ###End###");

            $("#divAppointmentReasonMain").html(data.substring(start, end));

            generateAppointmentReasonsPagging();
        });
    }
}

function generateAppointmentReasonsPagging() {
    GeneratePaging($("[id$='hdnAppointmentReasonsTotalRows']").val(), $("#ddlPagingAppointmentReasons").val(), "gridAppointmentReasons", "FilterAppointmentReasons");

    if ($("[id$='hdnAppointmentReasonsTotalRows']").val() > 0) {
        $("#gridAppointmentReasons .spanInfo").html("Showing " + $("#gridContentsAppointmentReasons tr:first").children().first().html() + " to " + $("#gridContentsAppointmentReasons tr:last").children().first().html() + " of " + $("[id$='hdnAppointmentReasonsTotalRows']").val() + " entries");
    }
}

function FilterAppointmentReasons(pageNumber, paging) {
    $.post(_SettingsPath + "/CallBacks/AppointmentReasonsFilterHandler.aspx", { Rows: $("#ddlPagingAppointmentReasons").val(), PageNumber: pageNumber }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsAppointmentReasons").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnAppointmentReasonsTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            generateAppointmentReasonsPagging();
        }

        if ($("[id$='hdnAppointmentReasonsTotalRows']").val() > 0)
            $("#gridAppointmentReasons .spanInfo").html("Showing " + $("#gridContentsAppointmentReasons tr:first").children().first().html() + " to " + $("#gridContentsAppointmentReasons tr:last").children().first().html() + " of " + $("[id$='hdnAppointmentReasonsTotalRows']").val() + " entries");
    });
}

var colorHexa = "";
var colorRGB;
function AddNewAppointmentReason() {
    if (!checkModuleRights("AppointmentReasonsAdd")) {
        //showErrorMessage(_msg_AppointmentReasonsAdd);
        //return false;
    }

    $("[id$='txtAppointmentReasonDescription']").css("color", "#000000");
    colorHexa = "#000000";
    colorRGB = hexToRgb(colorHexa);
    ColorPicker("divReasonColorPicker", "txtAppointmentReasonDescription");

    $("#divDialogAddAppointmentReasons").dialog({
        title: "Add New Reason",
        width: "auto",
        modal: true,
        buttons: {
            "Save": function () {
                if (!ValidateForm("divDialogAddAppointmentReasons")) {
                    showErrorMessage("");
                    return;
                }
                if (colorHexa == "transparent") {
                    showErrorMessage("Please select a color!");
                    return;
                }
                if (colorRGB.r > 230 && colorRGB.g > 230 && colorRGB.b > 230) {
                    showErrorMessage("Please select a more visible color!");
                    return;
                }

                var objReasons = new Object();
                objReasons.Description = $("#txtAppointmentReasonDescription").val();
                objReasons.BackColor = colorHexa;
                $.post(_SettingsPath + "/CallBacks/AppointmentReasonsActionHandler.aspx", { objReasons: JSON.stringify(objReasons), action: "ADD" }, function () {
                    FilterAppointmentReasons(0, true);
                    showSuccessMessage(_msg_Created);
                });
                $(this).dialog("close");
                $(this).find('span.jPicker').remove();
            },
            "Cancel": function () {
                $(this).dialog("close");
                $(this).find('span.jPicker').remove();
            }
        },
        close: function () {
            $("#txtAppointmentReasonDescription").val("");
            $(this).dialog("destroy");
            $(this).find('span.jPicker').remove();
        }
    });
}

function ColorPicker(PickerDiv) {
    $('#' + PickerDiv).jPicker(
        {
            window:
		    {
		        expandable: true,
		        position:
                { x: 'screenCenter', y: 'center' }
		    },
            color:
            {
                alphaSupport: false,
                active: new $.jPicker.Color({ ahex: '#000000' })
            }
        },

	    function (color, context) {
	        colorRGB = color.val('all');
	        if (colorRGB == null || colorRGB == "") {
	            $("#divDefaultColorConfirmation").dialog({
	                title: "Default Color Confirmation!",
	                width: "auto",
	                modal: true,
	                buttons: {
	                    "Yes": function () {
	                        colorHexa = "#68a1e5";
	                        $.jPicker.List[0].color.active.val('ahex', "68a1e5");
	                        colorRGB = color.val('all');
	                        $(this).dialog("close");
	                        return;
	                    },
	                    "No": function () {
	                        $(this).dialog("close");
	                    }
	                },
	                close: function () {
	                    $(this).dialog("destroy");
	                }
	            });
	        }
	        colorHexa = colorRGB && '#' + colorRGB.hex || 'transparent';
	        colorRGB = color.val('all');
	    }
    );
}

function rgb2hex(rgb) {
    rgb = rgb.match(/^rgb\((\d+),\s*(\d+),\s*(\d+)\)$/);
    return "#" +
  ("0" + parseInt(rgb[1], 10).toString(16)).slice(-2) +
  ("0" + parseInt(rgb[2], 10).toString(16)).slice(-2) +
  ("0" + parseInt(rgb[3], 10).toString(16)).slice(-2);
}

function hexToRgb(hex) {
    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}

function editAppointmentReason(elem, ReasonId) {
    if (!checkModuleRights("AppointmentReasonsEdit")) {
        //showErrorMessage(_msg_AppointmentReasonsEdit);
        //return false;
    }

    var description = $.trim($(elem).closest("tr").find("td:eq(1)").html());
    $("#txtAppointmentReasonDescription").val(description);
    colorHexa = $(elem).closest("tr").find(".ReasonBackColor").val() == "" ? "#000000" : $(elem).closest("tr").find(".ReasonBackColor").val();
    colorRGB = hexToRgb(colorHexa);
    ColorPicker("divReasonColorPicker");
    $.jPicker.List[0].color.active.val('ahex', colorHexa.replace("#", ""));

    $("#divDialogAddAppointmentReasons").dialog({
        title: "Update Reason",
        width: "auto",
        modal: true,
        buttons: {
            "Save": function () {
                if (!ValidateForm("divDialogAddAppointmentReasons")) {
                    showErrorMessage("");
                    return;
                }
                if (colorHexa == "transparent") {
                    showErrorMessage("Please select a color!");
                    return;
                }

                if (colorRGB.r > 230 && colorRGB.g > 230 && colorRGB.b > 230) {
                    showErrorMessage("Please select a more visible color!");
                    return;
                }

                var objReasons = new Object();
                objReasons.ReasonId = ReasonId;
                objReasons.Description = $("#txtAppointmentReasonDescription").val();
                objReasons.BackColor = colorHexa;

                $.post(_SettingsPath + "/CallBacks/AppointmentReasonsActionHandler.aspx", { objReasons: JSON.stringify(objReasons), action: "UPDATE" }, function () {
                    FilterAppointmentReasons(0, true);
                    showSuccessMessage(_msg_Updated);
                });

                $(this).dialog("close");
                $(this).find('span.jPicker').remove();
            },
            "Cancel": function () {
                $(this).dialog("close");
                $(this).find('span.jPicker').remove();
            }
        },
        close: function () {
            $("#txtAppointmentReasonDescription").val("");
            $(this).dialog("destroy");
            $(this).find('span.jPicker').remove();
        }
    });
}

function deleteAppointmentReason(elem, ReasonId) {
    if (!checkModuleRights("AppointmentReasonsDelete")) {
        //showErrorMessage(_msg_AppointmentReasonsDelete);
        //return false;
    }

    $("#divDialogDeleteAppointmentReasons").dialog({
        title: "Delete Confirmation!",
        width: "auto",
        modal: true,
        buttons: {
            "Yes": function () {
                $.post(_SettingsPath + "/CallBacks/AppointmentReasonsActionHandler.aspx", { ReasonId: ReasonId, action: "DELETE" }, function () {
                    FilterAppointmentReasons(0, true);
                    showSuccessMessage(_msg_Deleted);
                });
                $(this).dialog("close");
            },
            "No": function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            $(this).dialog("destroy");
        }
    });
}

//******************************End Appointment Reasons********************************//