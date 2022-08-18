

$(document).ready(function () {
    
    $("#txtDateImmunizations").datepicker({
        changeYear: true,
        changeMonth: true
    });
    
    $("#txtExpirationDate").datepicker({
        changeYear: true,
        changeMonth: true
    });
    
    $("#txtDateImmunizationsEdit").datepicker({
        changeYear: true,
        changeMonth: true
    });
    
    $("#txtExpirationDateEdit").datepicker({
        changeYear: true,
        changeMonth: true
    });
    
    $("[id$='txtTimeImmunizations']").timeEntry({ show24Hours: true, showSeconds: true, spinnerBigImage: "Images/spinnerDefault.png" });
    $("[id$='txtTimeImmunizationsEdit']").timeEntry({ show24Hours: true, showSeconds: true });
    
    
    GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPaging").val(), "PatientImmunizationsContainer", "FilterRecord");
    if ($("[id$='hdnTotalRows']").val() > 0)
        $("#spnInfo").html("Showing " + $("#gridContents tr:first").children().first().html() + " to " + $("#gridContents tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
});

function FilterRecord(pageNumber, paging) {
    
    $.post("CallBacks/PatientImmunizationsHandler.aspx", { Rows: $("#ddlPaging").val(), PageNumber: pageNumber, SortBy: "", action: "SELECT" },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContents").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPaging").val(), "PatientImmunizationsContainer", "FilterRecord");
        }

        if ($("[id$='hdnTotalRows']").val() > 0)
            $("#spnInfo").html("Showing " + $("#gridContents tr:first").children().first().html() + " to " + $("#gridContents tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
    });
}



function AddNewImmunizationsClick() {
    resetImmunizationForm();
    $("#divAddNewImmunizations").animate({height: "toggle"});
}

function CancelImmunizationsClick() {
    $("#divAddNewImmunizations").animate({ height: "toggle" });
}

function resetImmunizationForm() {
    $("[id$='ddlImmunizations']").val("");
    $("[id$='cbCompleted']").attr("checked", false);
    $("[id$='txtDateImmunizations']").val("");
    $("[id$='txtTimeImmunizations']").val("");
    $("[id$='ddlRoute']").val(0);
    $("[id$='ddlSite']").val(0);
    $("[id$='txtDose']").val("");
    $("[id$='txtLotNo']").val("");
    $("[id$='ddlUnit']").val(0);
    $("[id$='txtComments']").val("");
    $("[id$='ddlManufacturer']").val(0);
    $("[id$='cbNotPerformed']").attr("checked", false);
    $("[id$='ddlReason']").val(0);
    $("[id$='txtAdverseReaction']").val("");
    $("[id$='txtExpirationDate']").val("");
}

function SaveImmunizationsClick() {
    var objPatientImmunization = new Object();
    
    objPatientImmunization.ImmunizationName = $("[id$='ddlImmunizations']").val();
    objPatientImmunization.IsCompleted = $("[id$='cbCompleted']").is(":checked");
    objPatientImmunization.ImmunizationDate = $("[id$='txtDateImmunizations']").val();
    objPatientImmunization.ImmunizationTime = $("[id$='txtTimeImmunizations']").val();
    objPatientImmunization.Routs = $("[id$='ddlRoute']").val();
    objPatientImmunization.Site = $("[id$='ddlSite']").val();
    objPatientImmunization.ImmunizationDose = $("[id$='txtDose']").val();
    objPatientImmunization.LotNumber = $("[id$='txtLotNo']").val();
    objPatientImmunization.ImmunizationUnits = $("[id$='ddlUnit']").val();
    objPatientImmunization.Comments = $("[id$='txtComments']").val();
    objPatientImmunization.Manufacturer = $("[id$='ddlManufacturer']").val();
    
    objPatientImmunization.NotPerformed = $("[id$='cbNotPerformed']").is(":checked");
    objPatientImmunization.NotPerformedReason = $("[id$='ddlReason']").val();
    
    objPatientImmunization.AdversReaction = $("[id$='txtAdverseReaction']").val();
    objPatientImmunization.ExpirationDate = $("[id$='txtExpirationDate']").val();
    
    var action = "ADD";
    
    var PatientId = $("[id$='PatientId']").val();
    
    if (PatientId != "") {
        objPatientImmunization.PatientId = PatientId;
    }
    
    var isValidate = validatePatientImmunizationForm(objPatientImmunization);
    
    if (isValidate) {
        $.post("CallBacks/PatientImmunizationsHandler.aspx", { objPatientImmunization: JSON.stringify(objPatientImmunization), action: action, Rows: 10, PageNumber: 0, SortBy: "" }, function (data) {
            var returnHtml = data;

            resetPatientImmunizationGrid(data, true);
            $("#divAddNewImmunizations").animate({ height: "toggle" });
            alert("Success: Patient Immunizations Saved.");
        });
    }
    else {
        alert("Please enter immunizations date");
    }
}

function validatePatientImmunizationForm(objPatientImmunization) {
    
    if (!objPatientImmunization.ImmunizationDate) {
        return false;
    }
    return true;
}

function resetPatientImmunizationGrid(data, paging) {
    var returnHtml = data;
    var start = data.indexOf("###Start###") + 11;
    var end = data.indexOf("###End###");
    $("#gridContents").html(returnHtml.substring(start, end));

    var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
    var endRowsCount = data.indexOf("###EndRowsCount###");
    $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

    if (paging == true) {
        GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPaging").val(), "PatientImmunizationsContainer", "FilterRecord");
    }

    if ($("[id$='hdnTotalRows']").val() > 0)
        $("#spnInfo").html("Showing " + $("#gridContents tr:first").children().first().html() + " to " + $("#gridContents tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
}

function actionPatientImmunization(elem, action) {
    
    var PatientImmunizationId = $(elem).closest("td").find(".PatientImmunizationId").val();
    
    if (action == "EDIT") {
        
        $("[id$='ddlImmunizationsEdit']").val($.trim($(elem).closest("tr").find(".immunization-name").html()));
        
        var isComplete = $.trim($(elem).closest("tr").find(".immunization-iscompleted").html());
        if (isComplete == "true") {
            $("[id$='cbCompletedEdit']").attr("checked", true);
        }
        else {
            $("[id$='cbCompletedEdit']").attr("checked", false);
        }
        
        $("[id$='txtDateImmunizationsEdit']").val($.trim($(elem).closest("tr").find(".immunization-date").html()));
        $("[id$='txtTimeImmunizationsEdit']").val($.trim($(elem).closest("tr").find(".immunization-time").html()));
        $("[id$='ddlRouteEdit']").val($.trim($(elem).closest("tr").find(".immunization-routs").html()));
        $("[id$='ddlSiteEdit']").val($.trim($(elem).closest("tr").find(".immunization-site").html()));
        $("[id$='txtDoseEdit']").val($.trim($(elem).closest("tr").find(".immunization-dose").html()));
        $("[id$='txtLotNoEdit']").val($.trim($(elem).closest("tr").find(".immunization-lotnumber").html()));
        $("[id$='ddlUnitEdit']").val($.trim($(elem).closest("tr").find(".immunization-units").html()));
        $("[id$='txtCommentsEdit']").val($.trim($(elem).closest("tr").find(".immunization-comments").html()));
        $("[id$='ddlManufacturerEdit']").val($.trim($(elem).closest("tr").find(".immunization-manufacturer").html()));
        
        var isPerformed = $.trim($(elem).closest("tr").find(".immunization-notperformed").html());
        if (isPerformed == "true") {
            $("[id$='cbNotPerformedEdit']").attr("checked", true);
        }
        else {
            $("[id$='cbNotPerformedEdit']").attr("checked", false);
        }

        $("[id$='ddlReasonEdit']").val($.trim($(elem).closest("tr").find(".immunization-notperformedreason").html()));

        $("[id$='txtAdverseReactionEdit']").val($.trim($(elem).closest("tr").find(".immunization-adversereaction").html()));
        $("[id$='txtExpirationDateEdit']").val($.trim($(elem).closest("tr").find(".immunization-expirationdate").html()));


        $("#divPatientImmunizationsDialog").dialog({
            title: "",
            modal: true,
            width: 1000,
            buttons: {
                "Save": function () {
                    var objPatientImmunization = new Object();

                    objPatientImmunization.ImmunizationName = $("[id$='ddlImmunizationsEdit']").val();
                    objPatientImmunization.IsCompleted = $("[id$='cbCompletedEdit']").is(":checked");
                    objPatientImmunization.ImmunizationDate = $("[id$='txtDateImmunizationsEdit']").val();
                    objPatientImmunization.ImmunizationTime = $("[id$='txtTimeImmunizationsEdit']").val();
                    objPatientImmunization.Routs = $("[id$='ddlRouteEdit']").val();
                    objPatientImmunization.Site = $("[id$='ddlSiteEdit']").val();
                    objPatientImmunization.ImmunizationDose = $("[id$='txtDoseEdit']").val();
                    objPatientImmunization.LotNumber = $("[id$='txtLotNoEdit']").val();
                    objPatientImmunization.ImmunizationUnits = $("[id$='ddlUnitEdit']").val();
                    objPatientImmunization.Comments = $("[id$='txtCommentsEdit']").val();
                    objPatientImmunization.Manufacturer = $("[id$='ddlManufacturerEdit']").val();

                    objPatientImmunization.NotPerformed = $("[id$='cbNotPerformedEdit']").is(":checked");
                    objPatientImmunization.NotPerformedReason = $("[id$='ddlReasonEdit']").val();

                    objPatientImmunization.AdversReaction = $("[id$='txtAdverseReactionEdit']").val();
                    objPatientImmunization.ExpirationDate = $("[id$='txtExpirationDateEdit']").val();


                    objPatientImmunization.PatientImmunizationId = PatientImmunizationId;

                    var PatientId = $("[id$='PatientId']").val();

                    if (PatientId != "") {
                        objPatientImmunization.PatientId = PatientId;
                    }

                    var isValidate = validatePatientImmunizationForm(objPatientImmunization);

                    if (isValidate) {
                        $.post("CallBacks/PatientImmunizationsHandler.aspx", { objPatientImmunization: JSON.stringify(objPatientImmunization), action: action, Rows: 10, PageNumber: 0, SortBy: "" }, function (data) {
                            var returnHtml = data;
                            resetPatientImmunizationGrid(data, true);
                            $("#divPatientImmunizationsDialog").dialog("close");
                            alert("Success: Patient Immunizations Updated.");
                        });
                    }
                    else {
                        alert("Please enter immunizations date");
                    }
                },
                "Cancel": function () {
                    $("#divPatientImmunizationsDialog").dialog("close");
                }
            },
            close: function () {
                $("#divPatientImmunizationsDialog").dialog("destroy");
            }
        });
    }
    else if (action == "DELETE") {
        if (confirm("Are you sure to delete patient immunization?")) {
            $.post("CallBacks/PatientImmunizationsHandler.aspx", { PatientImmunizationId: PatientImmunizationId, action: action, Rows: 10, PageNumber: 0, SortBy: "" }, function (data) {
                var returnHtml = data;
                resetPatientImmunizationGrid(data, true);
                alert("Success: Patient Immunizations Deleted.");
            });
        }
    }
}