

function PatientDocumentFormReady() {

}

function UploadPatientDocument() {
    ActionDocument = "Upload";
    OpenDocumentForm(0);
}

function ScanPatientDocument(CallFrom) {
    ActionDocument = "Scan";
    OpenDocumentForm(0);
}

function OpenDocumentForm(DocumentId) {
    $.post(_EMRPath + "/PatientDocument/CallBacks/PatientDocumentForm.aspx", { DocumentId: DocumentId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");

        var returnHtml = $.trim(data.substring(start, end));

        $("#divDialogDocumentForm").html(returnHtml)
        .promise()
        .done(function () {
            PatientDocumentFormReadyCommon();

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
                    LoadDocuments();
                    $(this).dialog("destroy");
                }
            });
        });
    });
}

function SavePatientDocument() {
    /*if (!ValidateForm("tblEdit")) {
        showErrorMessage("");
        return false;
    }*/

    var attachmentsLength = $("[id$='divPatientDocumentsFilesInner'] .patient-document-files-wrapper:visible").length;

    if (attachmentsLength == 0) {
        showErrorMessage("Error: Please add some attachment!");
        return;
    }


    var objPatientDocuments = new Object();

    objPatientDocuments.DocumentId = $("[id$='hdnPatientDocumentId']").val();
    objPatientDocuments.DocumentName = $("#txtDocumentName").val();

    objPatientDocuments.PatientId = $("[id$='hdnPatientId']").val();
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

    $.post(_PatientDocumentCallBacksPath + "/PatientDocumentActionHandler.aspx", {
        objPatientDocuments: JSON.stringify(objPatientDocuments),
        listPatientDocumentAttachments: JSON.stringify(listPatientDocumentAttachments),
        PatientId: $("[id$='hdnPatientId']").val(),
        action: "Save"
    },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#PatientDocumentsList").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartPatientDocumentRowsCount###") + 35;
        var endRowsCount = data.indexOf("###EndPatientDocumentRowsCount###");

        $("[id$='hdnTotalDocRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

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
            else
                $("#cbDocumentsAll").prop("checked", false);
        });
    });
}

function EditPatientDocument(elem) {
    debugger;
    var DocumentId = $(elem).closest("tr").find(".hdnDocumentId").val();

    OpenDocumentForm(DocumentId);
}

$(".CheckUncheckDoc").on("change", function () {
    if ($(".CheckUncheckDoc:checked").length == $(".CheckUncheckDoc").length) {
        $("#cbDocumentsAll").prop("checked", true);
    }
    else {
        $("#cbDocumentsAll").prop("checked", false);
    }
});

function checkUncheckAllDocuments(elem) {
    $("#PatientDocumentsList input[class='CheckUncheckDoc']").prop("checked", $(elem).is(":checked"));
}

function HideOldDoc(elem) {
    $(".trOldAttachedFile").hide();
    $("#EditFileUploadRow").show();
    $(".trOldAttachedFile #spnEditAttachmentName").html("");
}

function DeleteUploadedDocRow(elem) {
    $(".EditAttachments").remove();
    $("#EditFileUploadRow").show();
}

function RemoveAttachment(obj) {
    $(obj).closest("tr").remove();
}

function downloadSubmissionFile(filePath, fileName) {
    saveToDisk(filePath, fileName);
}

var DocumentName;
var DocumentPath;

function RemoveDocument() {
    $("#EditFileUploadRow").show();
    $("#EditDocumentName").parent().hide();
}

function FilterPatientDocuments(pageNumber, paging) {
    var PatientId = $.trim($("[id$='hdnPatientId']").val()) == "" ? 0 : $.trim($("[id$='hdnPatientId']").val());
    var Category = $.trim($("#ddlCategory option:selected").text()) == "All" ? "" : $.trim($("#ddlCategory option:selected").text());
    
    var Name = $.trim($("#txtSearchByName").val());
    var Date = $.trim($("[id$='txtSearchByDate']").val());
    var PatientName = $.trim($("[id$='txtSearchByPatient']").val());
    var ProviderName = $.trim($("[id$='txtSearchByProvider']").val());
    
    $.post(_RooTPath + "ProviderPortal/PatientDocument/Callbacks/PatientDocumentFilterHandler.aspx", { PatientId: PatientId, Name: Name, Category: Category, Date: (isDate(Date) ? Date : null), Rows: $("#ddlPagingPatientDocument").val(), PageNumber: pageNumber, SortBy: "DocumentName", PatientName: PatientName, ProviderName: ProviderName }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        
        $("#PatientDocumentsList").html(returnHtml.substring(start, end));
        
        var startRowsCount = data.indexOf("###StartPatientDocumentRowsCount###") + 35;
        var endRowsCount = data.indexOf("###EndPatientDocumentRowsCount###");
        
        $("[id$='hdnTotalDocRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

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

function AssignMeDoc() {
    debugger;
    /***********added by shahid kazmi 2/7/2018*****/
    var providerName = $("[id$='hdnUserName']").val();
    $("#ddlPatientDocumentPracticeUsers option:contains(" + providerName + ")").attr('selected', 'selected');
    
    /*var id = $("[id$='hdnLoggedProvideId']").val();
    
    if (id != 0 && id != null) {
        $("[id$='ddlPatientDocumentPracticeUsers']").val(id)
    }*/
    /***********end shahid kazmi 2/7/2018********/
}

function showDocuments() {
    $(".contents-details-header").html('Documents');
    
    $.post(_SettingsPath + "/CallBacks/PatientDocumentsHandler.aspx", { PatientId: 0 }, function (data) {
        var start = data.indexOf("###StartDocument###") + 19;
        var end = data.indexOf("###EndDocument###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $(".setting-content-wrapper").hide();
        $("#divDocumentsMain").html(returnHtml).show();
        
        if ($("#tbodyDocumentCategory tr").length > 0) {
            $("#tbodyDocumentCategory tr").eq(0).addClass("row-selected");
            _currentDocumentCategoryRow = $("#tbodyDocumentCategory tr").eq(0);
        }
    });
}

function RemoveAttachment(obj) {
    $(obj).closest("tr").remove();
}

function AddNewDialog() {
    $("#divAddNewDcoument").animate({
        height: 'toggle'
    });
}

function formatDate(value) {
    return value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
}

function CancelAddNew() {
    $("#divAddNewDcoument").hide();
    ResetAddNewFields();
}

function ResetAddNewFields() {
    $("#hdnNewPatientId").val("");
    $("#divAddNewDcoument input[type='text']").val("");
    $("#divAddNewDcoument select").val($("#divAddNewProblem select option:first").val());
    $("#txtComments").val("");
    
    $(".attachments").hide();
    $("#hdnDocumentName").val("");
    $("#hdnOriginalName").val("");
}

function ResetEditFields() {
    $("#EditDocumentName").parent().show();
    $(".EditAttachments").hide();
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
        PatientId: _PatientId,
        action: "Delete"
    };
    
    $.post(_PatientDocumentCallBacksPath + "/PatientDocumentActionHandler.aspx", params, function (data) {
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