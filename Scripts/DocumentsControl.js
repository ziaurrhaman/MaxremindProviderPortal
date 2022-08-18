


var _DocumentPatientName = "";

function PatientDocumentFormReady() {
    $("[id$='trPatientDocumentPatientInfo']").show();
}

function FilterPatientDocuments(pageNumber, paging) {
    var PatientId = $.trim($("[id$='hdnPatientId']").val()) == "" ? 0 : $.trim($("[id$='hdnPatientId']").val());
    var Category = $.trim($("#ddlCategory option:selected").text()) == "All" ? "" : $.trim($("#ddlCategory option:selected").text());
    var Name = $.trim($("#txtSearchByName").val());
    var Date = $.trim($("[id$='txtSearchByDate']").val());
    var PatientName = $.trim($("[id$='txtSearchByPatient']").val());
    var ProviderName = $.trim($("[id$='txtSearchByProvider']").val());

    var params = {
        PatientId: PatientId,
        Name: Name,
        Category: Category,
        Date: (isDate(Date) ? Date : null),
        Rows: $("#ddlPagingPatientDocument").val(),
        PageNumber: pageNumber,
        SortBy: "DocumentName",
        PatientName: PatientName,
        ProviderName: ProviderName,
        action: "Filter"
    };
    
    $.post(_SettingsPath + "/Callbacks/DocumentsActionHandler.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#PatientDocumentsList").html(returnHtml);

        start = data.indexOf("###StartPatientDocumentRowsCount###") + 35;
        end = data.indexOf("###EndPatientDocumentRowsCount###");
        returnHtml = $.trim(data.substring(start, end));
        
        $("[id$='hdnTotalDocRows']").val(returnHtml);

        if (paging) {
            GeneratePaging($("[id$='hdnTotalDocRows']").val(), $("#ddlPagingPatientDocument").val(), "divPatientDocumentContainer", "FilterPatientDocuments");
        }

        if ($("[id$='hdnTotalDocRows']").val() > 0) {
            $("#divPatientDocumentContainer .spanInfo").html("Showing " + $("#PatientDocumentsList tr:first").children().first().html() + " to " + $("#PatientDocumentsList tr:last").children().first().html() + " of " + $("[id$='hdnTotalDocRows']").val() + " entries");
        }
    
        $(".CheckUncheckDoc").on("change", function () {
            if ($(".CheckUncheckDoc:checked").length == $(".CheckUncheckDoc").length) {
                $("#cbDocumentsAll").prop("checked", true);
            }
            else {
                $("#cbDocumentsAll").prop("checked", false);
            }
        });
    });
}

function UploadPatientDocument() {
    ActionDocument = "Upload";
    OpenDocumentForm(0);
    $("[id$='hdnPatientIdDoc']").val(0);
}

function ScanPatientDocument(CallFrom) {
    ActionDocument = "Scan";
    OpenDocumentForm(0);
    $("[id$='hdnPatientIdDoc']").val(0);
}

function OpenDocumentForm(DocumentId) {
    
    $.post(_EMRPath + "/PatientDocument/CallBacks/PatientDocumentForm.aspx", { DocumentId: DocumentId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#divDialogDocumentForm").html(returnHtml)
        .promise()
        .done(function () {
            PatientDocumentFormReady();
            PatientDocumentFormReadyCommon();

            if (DocumentId != 0) {
                $("[id$='txtPatientNameDoc']").val(_DocumentPatientName);
            }
            
            $("#divDialogDocumentForm").dialog({
                resizable: false,
                title: 'Add Document',
                width: 800,
                //height: (window.innerHeight - 10),
                modal: true,
                buttons: {
                    "Save": function () {
                        SavePatientDocument();
                    },
                    "Cancel": function () {
                        $(this).dialog("close");
                    }
                },
                beforeClose: function () {
                    ResetDivEditFields();
                },
                close: function () {
                    showDocuments();
                    $(this).dialog("destroy");
                }
            });
        });
    });
}

function SavePatientDocument() {
    if (!ValidateForm("tblEdit")) {
        showErrorMessage("");
        return false;
    }
    
    var attachmentsLength = $("[id$='divPatientDocumentsFilesInner'] .patient-document-files-wrapper:visible").length;
    
    if (attachmentsLength == 0) {
        showErrorMessage("Error: Please add some attachment!");
        return;
    }
    
    var objPatientDocuments = new Object();
    
    objPatientDocuments.DocumentId = $("[id$='hdnPatientDocumentId']").val();
    objPatientDocuments.DocumentName = $("#txtDocumentName").val();

    objPatientDocuments.PatientId = $("[id$='hdnPatientIdDoc']").val();
    objPatientDocuments.CategoryId = $("#ddlPatientDocumentType").val();
    objPatientDocuments.Status = $("#ddlEditDocumentStatus").val();
    objPatientDocuments.DocumentDate = $("#txtPatientDocumentDate").val();
    objPatientDocuments.IsConfedential = $("[id$='chkPatientDocumentIsConfedential']").is(":checked");
    objPatientDocuments.AssignedTo = $.trim($("#ddlPatientDocumentPracticeUsers").val());
    
    if (objPatientDocuments.AssignedTo == "") objPatientDocuments.AssignedTo = 0;
    
    objPatientDocuments.Signed = true;
    objPatientDocuments.SignedById = "1";

    //Sign Date is currently used as DocumentEditDate, it should be changed when sign document task is completed 

    objPatientDocuments.SignDate = $("#txtPatientDocumentDate").val();
    objPatientDocuments.Comments = $("#txtPatientDocumentComments").val();

    var listPatientDocumentAttachments = new Array();

    $("#divPatientDocumentsFilesInner .patient-document-files-wrapper").each(function () {
        var objPatientDocumentAttachments = new Object();

        objPatientDocumentAttachments.PatientDocumentAttachmentsId = $(this).find(".hdnPatientDocumentAttachmentsId").val();
        objPatientDocumentAttachments.DocumentPath = $(this).find(".hdnDocumentPath").val();
        objPatientDocumentAttachments.OriginalFileName = $(this).find(".hdnOriginalFileName").val();
        objPatientDocumentAttachments.Deleted = $(this).find(".hdnDeleted").val();

        listPatientDocumentAttachments.push(objPatientDocumentAttachments);
    });
    
    var params = {
        objPatientDocuments: JSON.stringify(objPatientDocuments),
        listPatientDocumentAttachments: JSON.stringify(listPatientDocumentAttachments),
        PatientId: 0,
        action: "Save"
    };
    
    $.post(_SettingsPath + "/Callbacks/DocumentsActionHandler.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#PatientDocumentsList").html(returnHtml);
        
        start = data.indexOf("###StartPatientDocumentRowsCount###") + 35;
        end = data.indexOf("###EndPatientDocumentRowsCount###");
        returnHtml = $.trim(data.substring(start, end));
        
        $("[id$='hdnTotalDocRows']").val(returnHtml);
        
        GeneratePaging($("[id$='hdnTotalDocRows']").val(), $("#ddlPagingPatientDocument").val(), "divPatientDocumentContainer", "FilterPatientDocuments");
        
        if ($("[id$='hdnTotalDocRows']").val() > 0) {
            $("#divPatientDocumentContainer .spanInfo").html("Showing " + $("#PatientDocumentsList tr:first").children().first().html() + " to " + $("#PatientDocumentsList tr:last").children().first().html() + " of " + $("[id$='hdnTotalDocRows']").val() + " entries");
        }
        
        $("#divDialogDocumentForm").dialog("close");
        
        if (objPatientDocuments.DocumentId == 0) {
            showSuccessMessage(_msg_Created);
        }
        else {
            showSuccessMessage(_msg_Updated);
        }
        
        $(".CheckUncheckDoc").on("change", function () {
            if ($(".CheckUncheckDoc:checked").length == $(".CheckUncheckDoc").length) {
                $("#cbDocumentsAll").prop("checked", true);
            }
            else {
                $("#cbDocumentsAll").prop("checked", false);
            }
        });
    });
}

function EditPatientDocument(elem) {
    var DocumentCurrentRow = $(elem).closest("tr");
    var DocumentId = DocumentCurrentRow.find(".hdnDocumentId").val();

    _DocumentPatientName = $.trim(DocumentCurrentRow.find(".EditPatientName").html());
    
    OpenDocumentForm(DocumentId);
    
    var PatientId = DocumentCurrentRow.find(".hdnPatientId").val();

    $("[id$='hdnPatientIdDoc']").val(PatientId);
}

function SearchPatientForPatientDocument() {
    $.post(_ControlPath + "/PatientSearch.aspx", {}, function (data) {
        var start = data.indexOf("###StartPatientSearch###") + 24;
        var end = data.indexOf("###EndPatientSearch###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#divDialogPatientSearchSettingsPatientDocuments").html(returnHtml).dialog({
            title: "Patient Search",
            height: 500,
            width: 900,
            modal: true,
            buttons: {
                Select: function () {
                    selectPatientForPatientDocumentInSettings();
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                $(this).dialog("destroy");
            }
        });
    });
}

function RemovePatientForPatientDocument() {
    $("[id$='txtPatientNameDoc']").val("");
    $("[id$='hdnPatientIdDoc']").val(0);
}

function selectPatientForPatientDocumentInSettings(elem) {
    var CurrentPatientRow = $(".trSelected");

    var PatientId = CurrentPatientRow.find(".hdnPatientId").val();
    var PatiantName = CurrentPatientRow.find(".hdnLastName").val() + " " + CurrentPatientRow.find(".hdnFirstName").val();
    
    $("[id$='txtPatientNameDoc']").val(PatiantName);
    $("[id$='hdnPatientIdDoc']").val(PatientId);
    debugger;
    $("#divDialogPatientSearchSettingsPatientDocuments").dialog("close");
}

function DeletePatientDocument(elem) {
    var message = "Are you sure to delete the record?";
    
    $("[id$='divMainDialogWrapper']").html(message);
    
    $("[id$='divMainDialogWrapper']").dialog({
        title: "Confirmation",
        modal: true,
        buttons: {
            "Yes": function () {
                ConfirmDeletePatientDocument(elem);
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            $(this).dialog("destroy");
        }
    });
}

function ConfirmDeletePatientDocument(elem) {
    var DocumentId = $(elem).closest("tr").find(".hdnDocumentId").val();
    
    var params = {
        DocumentId: DocumentId,
        PatientId: 0,
        action: "Delete"
    };

    $.post(_SettingsPath + "/Callbacks/DocumentsActionHandler.aspx", params, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#PatientDocumentsList").html(returnHtml);
        
        start = data.indexOf("###StartPatientDocumentRowsCount###") + 35;
        end = data.indexOf("###EndPatientDocumentRowsCount###");
        returnHtml = $.trim(data.substring(start, end));
        
        $("[id$='hdnTotalDocRows']").val(returnHtml);
        
        GeneratePaging($("[id$='hdnTotalDocRows']").val(), $("#ddlPagingPatientDocument").val(), "divPatientDocumentContainer", "FilterPatientDocuments");
        
        if ($("[id$='hdnTotalDocRows']").val() > 0) {
            $("#divPatientDocumentContainer .spanInfo").html("Showing " + $("#PatientDocumentsList tr:first").children().first().html() + " to " + $("#PatientDocumentsList tr:last").children().first().html() + " of " + $("[id$='hdnTotalDocRows']").val() + " entries");
        }
        
        $("[id$='divMainDialogWrapper']").dialog("close");
        
        showSuccessMessage(_msg_Deleted);

        $(".CheckUncheckDoc").on("change", function () {
            if ($(".CheckUncheckDoc:checked").length == $(".CheckUncheckDoc").length) {
                $("#cbDocumentsAll").prop("checked", true);
            }
            else {
                $("#cbDocumentsAll").prop("checked", false);
            }
        });
    });
}

function AssignPatientToDocument(elem) {
    var DocumentCurrentRow = $(elem).closest("tr");
    var DocumentId = DocumentCurrentRow.find(".hdnDocumentId").val();
    
    $.post(_ControlPath + "/PatientSearch.aspx", {}, function (data) {
        var start = data.indexOf("###StartPatientSearch###") + 24;
        var end = data.indexOf("###EndPatientSearch###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#divDialogPatientSearchSettingsPatientDocuments").html(returnHtml).dialog({
            resizable: false,
            title:'Search Patient',
            height: 500,
            width: 900,
            modal: true,
            buttons: {
                Select: function () {
                    var SelectedPatientRow = $(".trSelected");
                    
                    var PatientId = SelectedPatientRow.find(".hdnPatientId").val();
                    var LastName = SelectedPatientRow.find(".hdnLastName").val();
                    var FirstName = SelectedPatientRow.find(".hdnFirstName").val();
                    
                    $.post("../PatientDocument/CallBacks/AddEditPatientDocumentHandler.aspx", { AssignDocument: true, PatientId: PatientId, DocumentId: DocumentId }, function (data) {
                        DocumentCurrentRow.find(".hdnPatientId").val(PatientId);
                        DocumentCurrentRow.find(".hdnPatientName").val(LastName + " " + FirstName);
                        DocumentCurrentRow.find(".EditPatientName").html(LastName + " " + FirstName);
                    });
                    
                    $(this).dialog("close");
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                $(this).dialog("destroy");
            }
        });
    });
}