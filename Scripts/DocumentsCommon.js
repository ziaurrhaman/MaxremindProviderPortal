

var ActionDocument = "";

var arrFileTypes = ["jpg", "jpeg", "png", "gif", "bmp", "webp"];

function forDocumentReady() {
    var date = new Date();
    date.setYear(date.getFullYear() + 1);
    
    $("[id$='txtSearchByDate']").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        yearRange: "-110:+0",
        onSelect: function (date, obj) {
            FilterPatientDocuments(0, true);
        }
    }).mask("99/99/9999");
    
    date.setYear(date.getFullYear() + 1);
    $("[id$='txtPatientDocumentDate']").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");
    
    var request = null;
    
    $(".Date").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");
    
    GeneratePaging($("[id$='hdnTotalDocRows']").val(), $("#ddlPagingPatientDocument").val(), "divPatientDocumentContainer", "FilterPatientDocuments");
    
    if ($("[id$='hdnTotalDocRows']").val() > 0) {
        $("#divPatientDocumentContainer .spanInfo").html("Showing " + $("#PatientDocumentsList tr:first").children().first().html() + " to " + $("#PatientDocumentsList tr:last").children().first().html() + " of " + $("[id$='hdnTotalDocRows']").val() + " entries");
    }
}

function PatientDocumentFormReadyCommon() {
    if (ActionDocument == "Upload") {
        $(".scan-link").hide();
        $("[id$='linkUploadFiles']").show();
    }
    else if (ActionDocument == "Scan") {
        $("[id$='linkUploadFiles']").hide();
        $(".scan-link").show();
        onPageLoad();
    }

    $(".Date").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");

    new AjaxUpload('#linkUploadFiles', {
        action: _PatientDocumentPath + '/PatientDocumentHandler.ashx',
        dataType: 'json',
        contentType: "application/json; charset=uft-8",
        data: {
            PatientId: (($("[id$='hdnPatientId']").val() == undefined) ? $("#hdnPatientIdDoc").val() : $("[id$='hdnPatientId']").val())
        },
        onSubmit: function (file, ext, fileSize) {
            if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                callDialog("Sorry! the file is invalid.", "Invalid File");
                return false;
            }

            if (fileSize > 25) {
                callDialog("This file exceeds the 5MB attachment limit.", "Attachment Limit");
                return false;
            }
        },
        onComplete: function (file, response) {
            var responseHTML = $.parseJSON($(response).html());

            AppendUploadedFile(responseHTML.fileName, responseHTML.path, file);
        }
    });
}

$(document).on("mouseenter", ".patient-document-files-wrapper", function () {
    
    // $(this).find(".hover-action-div").show(); 
    $(this).find(".hover-action-div").hide();
});

$(document).on("mouseleave", ".patient-document-files-wrapper", function () {
    $(this).find(".hover-action-div").hide();
});

function DownloadPatientDocumentFile(elem) {
    var filePath = $(elem).closest(".patient-document-files-wrapper").find(".hdnDocumentPath").val();
    var fileName = $(elem).closest(".patient-document-files-wrapper").find(".hdnOriginalFileName").val();
    saveToDisk(filePath, fileName);
}

function DownloadPatientDocumentFileAll(elem) {
    var DocumentId = $(elem).closest("tr").find(".hdnDocumentId").val();
    
    $.post(_EMRPath + "/PatientDocument/CallBacks/PatientDocumentAttachmentsPaths.aspx", { DocumentId: DocumentId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        
        $("#divPatientAttachmentsMainWrapper").html(data.substring(start, end));
        
        setTimeout(function () {
            $("#divPatientAttachmentsMainWrapper .patient-attachments-wrapper").each(function () {
                var filePath = $(this).find(".hdnDocumentPath").val();
                var fileName = $(this).find(".hdnOriginalFileName").val();
                
                setTimeout(function () {
                    saveToDisk(filePath, fileName);
                }, 1000);
            });
        }, 1000);
    });
}

function GetFileLink(file, path) {
    var fileLink = "";
    
    var fileType = file.split(".")[1];
    fileType = fileType.toLocaleLowerCase();
    
    if ($.inArray(fileType, arrFileTypes) < 0) {
        if (fileType == "pdf") {
            fileLink = '' +
            '<embed src="' + path + '" width="600" height="500" alt="pdf">' +
            '<div class="hover-action-div">' +
                '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
                '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>' +
            '</div>';
        }
        else {
            fileLink = '' +
            '<a href="' + path + '" style="float: left; color: #00F; margin: 0 5px 0 0;" target="_blank">' + file + '</a>' +
            '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
            '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>';
        }
    }
    else {
        fileLink = '' +
        '<img src="' + path + '" />' +
        '<div class="hover-action-div">' +
            '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
            '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>' +
        '</div>';
    }
    
    return fileLink;
}

function AppendUploadedFile(fileName, path, file) {
    var documentFile = '' +
    '<div class="patient-document-files-wrapper">' +
        GetFileLink(file, _PracticeDocumentsPath + "/" + path) +
        '<input type="hidden" class="hdnDocumentId" value="0" />' +
        '<input type="hidden" class="hdnDocumentPath" value="' + _PracticeDocumentsPath + "/" + path + '" />' +
        '<input type="hidden" class="hdnOriginalFileName" value="' + file + '" />' +
        '<input type="hidden" class="hdnDeleted" value="false" />' +
    '</div>';
    
    $("[id$='divPatientDocumentsFilesInner']").append(documentFile);
}

function ShowHideScanProgressMessage(show) {
    return;
    if (show) {
        var imgProgress = '<img class="imgProgress" src="' + _ImagesPath + '/progress.gif" />';

        $("#divPatientDocumentsFilesInner").append(imgProgress);
    }
    else {
        $("#divPatientDocumentsFilesInner .imgProgress").remove();
    }
}

function DeleteAttachment(elem) {
    $(elem).closest(".patient-document-files-wrapper").hide();
    $(elem).closest(".patient-document-files-wrapper").find(".hdnDeleted").val("true");
}

function DeleteMultipleDocuments() {
    var allDocumentsCheckedCheckBoxes = $("#PatientDocumentsList input[class='CheckUncheckDoc']:checked").length;

    if (allDocumentsCheckedCheckBoxes == 0) {
        showErrorMessage("Please select some documents to delete!");
        return false;
    }

    $("#divMainDialogWrapper").attr("title", "Notification");

    ShowConfirmation("Do you realy want to delete the document(s)?").done(function () {
        var listDocumentId = new Array();
        var documentId;
        var postURL = "";
        var ClickFrom = ($("#txtPatientNameDoc").length == 0 ? "PatientDocument" : "SettingDocument");

        $("#PatientDocumentsList input[class='CheckUncheckDoc']:checked").each(function () {
            documentId = $(this).parent().find(".DocumentId").val();
            listDocumentId.push(documentId);
        });

        if (ClickFrom = "PatientDocument") {
            postURL = "../PatientDocument/CallBacks/AddEditPatientDocumentHandler.aspx";
        }
        else {
            postURL = "CallBacks/AddEditDocumentHandler.aspx";
        }

        $.post(postURL, {
            PatientId: $("[id$='hdnPatientId']").val(),
            Edit: false,
            Delete: true,
            ClickFrom: ClickFrom,
            listDocumentId: JSON.stringify(listDocumentId)
        }, function (data) {
            showSuccessMessage("Success: Document(s) deleted.");
            var returnHtml = data;
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf("###End###");
            $("#PatientDocumentsList").html(returnHtml.substring(start, end));
            var startRowsCount = data.indexOf("###StartPatientDocumentRowsCount###") + 35;
            var endRowsCount = data.indexOf("###EndPatientDocumentRowsCount###");
            $("[id$='hdnTotalDocRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
            GeneratePaging($("[id$='hdnTotalDocRows']").val(), $("#ddlPagingPatientDocument").val(), "divPatientDocumentContainer", "FilterPatientDocuments");

            if ($("[id$='hdnTotalDocRows']").val() > 0)
                $("#divPatientDocumentContainer .spanInfo").html("Showing " + $("#PatientDocumentsList tr:first").children().first().html() + " to " + $("#PatientDocumentsList tr:last").children().first().html() + " of " + $("[id$='hdnTotalDocRows']").val() + " entries");

            $("#divMainDialogWrapper").attr("title", "");
        });
    });
}

function PracticeDocumentEmail() {
    var allDocumentsCheckedCheckBoxes = $("#PatientDocumentsList input[class='CheckUncheckDoc']:checked").length;
    if (allDocumentsCheckedCheckBoxes == 0) {
        showErrorMessage("Please select some documents to email!");
        return false;
    }

    $("#PatientDocumentsList .CheckUncheckDoc:checked").each(function () {
        var fileUrl = $.trim($(this).closest('tr').find("#spnDocumentPath").html());
        var UploadedName = fileUrl.substring(36);
        var FileName = $.trim($(this).closest('tr').find("#spnDocument").html()); ;

        $("<tr class='attachments'><td><span class='attachment-icon-messages'></span></td><td><span id='" + UploadedName + "' class='attachment-name-messages'>" + FileName + "</span><div id='divProgressBar'><img src='../../Images/delete.png' class='attachment-remove' onclick='RemoveAttachment(this);'></div></td></tr>").insertBefore(".tr-upload-file-messages");
        $(".tr-upload-file-messages").hide();

        ComposeNewMessage();
    });

}

function SendMessage(isDraft) {
    if (!validateMessagesContacts()) {
        return false;
    }

    if ($(".attachment-name-messages").length == 0) {
        showErrorMessage("No document is attached to email!");
        return false;
    }

    var emailTo = "";
    $("#divToUsers > div").each(function () {
        emailTo += $(this).attr("id") + ",";
    });

    var emailCC = "";
    $("#divCcUsers > div").each(function () {
        emailCC += $(this).attr("id") + ",";
    });

    var subject = $("#txtSubject").val();
    var priority = $("#ddPriority").val();
    var attachmentList = new Array();

    $(".attachment-name-messages").each(function () {
        var objAttachment = new Object();
        objAttachment.FileName = $.trim($(this).html());
        objAttachment.FilePath = $(this).attr("id");
        attachmentList.push(objAttachment);
    });

    var body = tinyMCE.get('elm1').getContent();

    body = encodeURI(body);
    
    var MessageType = "InternalExternal";
    var CopyAttachments = true;
    
    $.post("../Messages/CallBacks/MessagesHandler.aspx", { emailTo: emailTo, emailCC: emailCC, subject: subject, priority: priority, body: body, attachmentList: JSON.stringify(attachmentList), action: "Add", isDraft: isDraft, MessageType: MessageType, CopyAttachments: CopyAttachments }, function (data) {
        
        $("#divComposeMessage").dialog("close");
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var result = returnHtml.substring(start, end);
        
        showSuccessMessage(result);
    });
}

function ResetDivEditFields() {
    $("#hdnEditDocument").val("");
    $("#EditDocumentName").parent().show();
    $(".EditAttachments").remove();
    $("#EditFileUploadRow").show();
    
    $("#txtDocumentName").val("");
    $("#txtPatientDocumentDate").val("");
    $("#txtPatientNameDoc").val("");
    $("#txtPatientDocumentComments").val("");
}

function ViewPatientDocument(elem) {
    debugger;
    var DocumentId = $(elem).closest("tr").find(".hdnDocumentId").val();
    
    $.post(_EMRPath + "/PatientDocument/CallBacks/PatientDocumentAttachmentsPaths.aspx", { DocumentId: DocumentId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        debugger;
        $("#divFilePaths").html(returnHtml)
        .promise()
        .done(function () {
            SetAndViewDocuments();
        });
    });
}

function SetAndViewDocuments() {
    debugger;
    var fileLink;
    var DocumentHtml = "";

    $("#divDialogDocumentsViewer").html("");

    $("#divFilePaths .patient-attachments-wrapper").each(function () {
        var fileName = $(this).find(".hdnOriginalFileName").val();
        var filePath = $(this).find(".hdnDocumentPath").val();
        
        DocumentHtml = '<div class="patient-document-files-wrapper">' +
                            GetFileLink(fileName, filePath) +
                            '<input type="hidden" class="hdnDocumentId" value="0" />' +
                            '<input type="hidden" class="hdnDocumentPath" value="' + filePath + '" />' +
                            '<input type="hidden" class="hdnOriginalFileName" value="' + fileName + '" />' +
                            '<input type="hidden" class="hdnDeleted" value="false" />' +
                        '</div>';

        //fileLink = GetFileLink(fileName, filePath);

        $("#divDialogDocumentsViewer").append(DocumentHtml);
        $(".hover-action-div").hide();
    });
    $("#divDialogDocumentsViewer").dialog({
        title: "Patient Documents",
        modal: true,
        width: 1000,
        minHeight: ($(window).height() - 5),
        position: { my: "top", at: "top", of: window }
    });
}