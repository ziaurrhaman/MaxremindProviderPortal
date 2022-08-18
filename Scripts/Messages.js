$(document).on("click", "#divMessageDetail .info", function () {
    $(this).next().slideToggle();
    if ($(this).find(".iconDown").length > 0) {
        $(this).find(".iconDown").addClass("iconUp").removeClass("iconDown");
    }
    else {
        $(this).find(".iconUp").addClass("iconDown").removeClass("iconUp");
    }
});


function ComposeNewMessage() {
    $("#divComposeMessage").attr("title", "New Message");
    ComposeMessage();
}


function CreateEditor(content) {

    tinyMCE.init({
        //mode: "textareas",
        mode: "none",
        theme: "advanced",
        theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,bullist,numlist,|,justifyleft,justifycenter,justifyright,justifyfull,formatselect,fontselect,fontsizeselect,|,forecolor,backcolor",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: false
    });

    tinyMCE.execCommand('mceAddControl', false, 'elm1');
}

function RemoveTinyMCE() {
    if (tinyMCE.getInstanceById('elm1')) {
        tinyMCE.execCommand('mceFocus', false, 'elm1');
        tinyMCE.execCommand('mceRemoveControl', false, 'elm1');
    }
}


function ShowUserList() {
    $("#divUserSelection").slideToggle();
    $("#divCcUserSelection").hide();
}

function ShowCcUsers() {
    $("#divCcUserSelection").slideToggle();
    $("#divUserSelection").hide();
}

function PopulateMsgUsers() {
    $("#divToUsers").html("");
    $("#divUserSelection :checkbox:checked").each(function () {
        $("#divToUsers").append('<div class="tag" id="' + $(this).closest("label").attr("id") + '"><span>' + $(this).siblings().html() + '</span><a href="#" title="Removing tag" onclick="RemoveTag(this);">&nbsp;x</a></div>');
    });
    $("#divUserSelection").slideToggle();
}

function PopulateCcUsers() {
    $("#divCcUsers").html("");
    $("#divCcUserSelection :checkbox:checked").each(function () {
        $("#divCcUsers").append('<div class="tag" id="' + $(this).closest("label").attr("id") + '"><span>' + $(this).siblings().html() + '</span><a href="#" title="Removing tag" onclick="RemoveTag(this);">&nbsp;x</a></div>');
    });
    $("#divCcUserSelection").slideToggle();
}

function RemoveTag(obj) {
    $(obj).parent().remove();
    //$("#divUserSelection").find("#" + $(obj).parent().attr("id")).find(":checkbox").removeAttr("checked");
}

function ComposeMessage() {
    $("#divComposeMessage").dialog({
        modal: true,
        width: '650',
        open: function () {
            attachmentSizeArray = [];
            CreateEditor();
        },
        close: function () {
            RemoveTinyMCE();
            ResetComposeDialog();
            $(this).dialog('destroy');
        },
        buttons: {
            Send: function () {
                SendMessage(false);
            },
            'Save As Draft': function () {
                if (!validateMessagesContacts()) {
                    return false;
                    SendMessage(false);
                }
                SendMessage(true);
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        }
    });

}

function ResetComposeDialog() {
    $("#divToUsers").html('');
    $("#divCcUsers").html('');
    $("#txtExternalEmail").val('');
    $("#txtExternalCC").val('');
    $("#txtSubject").val('');
    $("#ddPriority").val('N');
    $(".attachments").remove();
    $("#elm1").val('');
    $("#divUserSelection").hide();
    $("#divCcUserSelection").hide();
}

function RemoveAttachment(obj) {
    $(obj).closest("tr").remove();
}

var request = null;

function initializeMessageFileUpload() {
    request = new AjaxUpload('#btnUploadMessageAttachments', {
        action: 'CallBacks/AttachmentUploadHandler.ashx',
        dataType: 'json',
        contentType: "application/json; charset=uft-8",
        onSubmit: function (file, ext, fileSize) {

            if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                showErrorMessage('Error: invalid file extension');
                return false;
            }

            if (fileSize > 5) {
                showErrorMessage("This file exceeds the 5MB attachment limit.");
                return false;
            }

            var attachmentRow = '<tr class="attachments">';
            attachmentRow += '<td>';
            attachmentRow += '<span class="attachment-icon-messages"></span>';
            attachmentRow += '</td>';
            attachmentRow += '<td>';
            attachmentRow += '<span id="spnAttachmentName" class="attachment-name-messages">' + file + '</span>';
            attachmentRow += '<div id="divProgressBar"><img src="../../Images/progressbar.gif" /> <span onclick="request.abort();">Cancel</span></div>';
            attachmentRow += '</td>';
            attachmentRow += '</tr>';

            $(".tr-upload-file-messages").before(attachmentRow);

        },
        onComplete: function (file, response) {
            var responseHTML = $(response);
            var r = responseHTML.html();
            var res = $.parseJSON(r);

            $(".tr-upload-file-messages").prev().find("#divProgressBar").html('<img src="../../Images/delete.png" class="attachment-remove" onclick="RemoveAttachment(this);"/>');
            $("#spnAttachmentName").attr("id", res.path);
            $("#attach-link-messages").html("Attach another file");
            $("#btnUploadMessageAttachments").css("width", "106px");

        }
    });
}

function ResetUsers() {
    $("#divUserSelection input:checkbox").prop('checked', false);
    $("#divUserSelection").slideToggle();
}

function ResetCcUsers() {
    $("#divCcUserSelection input:checkbox").prop('checked', false);
    $("#divCcUserSelection").slideToggle();
}

function validateMessagesContacts() {
    if ($("#divToUsers > div").length == 0) {
        showErrorMessage("Please add some contacts to email!");
        return false;
    }
    return true;
}


function ReplyAll() {
    $("#btnTo").removeAttr("disabled");
    $("#btnCc").removeAttr("disabled");

    var subject = $("#lblSubject").html().replace("FW: ", "");
    $("#divToUsers").html($("#divMessageToUsers").html());
    $("#divToUsers a").css("display", "");
    $("#divCcUsers").html($("#divMessageCcUsers").html())
    $("#divCcUsers a").css("display", "");
    $("#txtSubject").val(subject.indexOf("RE: ") > -1 ? subject : "RE: " + subject);
    var html = "<br/><br/><hr/>";
    html += "<p><b>From: </b>";
    html += $("#divMessageFromUser").find("span").html() + "</p>";
    html += "<p><b>To:</b>";
    $("#divMessageToUsers div").each(function () {
        html += $(this).find("span").html() + "; ";
    });
    html += "</p>";
    html += "<p><b>Sent: </b>" + $("#lblSentDate").html() + "</p>"; ;
    html += "<p><b>Subject: </b>" + $("#lblSubject").html() + "</p>";
    html += $("#divBody").html();
    $("#elm1").val(html);

    $("#divComposeMessage").attr("title", subject.indexOf("RE: ") > -1 ? subject : "RE: " + subject);
    ComposeMessage();

}

function Reply() {
    $("#btnTo").removeAttr("disabled");
    $("#btnCc").removeAttr("disabled");

    var subject = $("#lblSubject").html().replace("FW: ", "");
    $("#divToUsers").html($("#divMessageFromUser").html());
    $("#divToUsers a").css("display", "");

    $("#txtSubject").val(subject.indexOf("RE: ") > -1 ? subject : "RE: " + subject);
    var html = "<br/><br/><hr/>";
    html += "<p><b>From: </b>";
    html += $("#divMessageFromUser").find("span").html() + "</p>";

    html += "<p><b>To:</b>";
    $("#divMessageToUsers div").each(function () {
        html += $(this).find("span").html() + "; ";
    });
    html += "</p>";

    html += "<p><b>Sent: </b>" + $("#lblSentDate").html() + "</p>";
    html += "<p><b>Subject: </b>" + $("#lblSubject").html() + "</p>";
    html += $("#divBody").html();
    $("#elm1").val(html);

    $("#divComposeMessage").attr("title", subject.indexOf("RE: ") > -1 ? subject : "RE: " + subject);
    ComposeMessage();
}

function Forward() {
    $("#btnTo").removeAttr("disabled");
    $("#btnCc").removeAttr("disabled");

    var subject = $("#lblSubject").html().replace("RE: ", "");
    $("#txtSubject").val(subject.indexOf("FW: ") > -1 ? subject : "FW: " + subject);
    var html = "<br/><br/>----- Forwarded Message -----";
    html += "<p><b>From: </b>";
    html += $("#divMessageFromUser").find("span").html() + "</p>";
    html += "<p><b>To:</b>";
    $("#divMessageToUsers div").each(function () {
        html += $(this).find("span").html() + "; ";
    });

    html += "</p>";
    html += "<p><b>Sent: </b>" + $("#lblSentDate").html() + "</p>";
    html += "<p><b>Subject: </b>" + $("#lblSubject").html() + "</p>"; ;
    html += $("#divBody").html();
    $("#elm1").val(html);

    $(".attachmentWrapper").each(function () {
        $("<tr class='attachments'><td><span class='attachment-icon-messages'></span></td><td><span id='" + $(this).attr("attachmentpath") + "' class='attachment-name-messages'>" + $(this).attr("attachmentname") + "</span><div id='divProgressBar'><img src='../../Images/delete.png' class='attachment-remove' onclick='RemoveAttachment(this);'></div></td></tr>").insertBefore(".tr-upload-file-messages");
    });

    $("#divComposeMessage").attr("title", subject.indexOf("FW: ") > -1 ? subject : "FW: " + subject);
    ComposeMessage();
}


function SendMessage(isDraft) {

    if (!isDraft) {
        if (!validateMessagesContacts()) {
            return false;
        }
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
    var ExternalTo = $("#txtExternalEmail").val();
    var ExternalCC = $("#txtExternalCC").val();
    var priority = $("#ddPriority").val();
    var attachmentList = new Array();

    $(".attachment-name-messages").each(function () {
        var objAttachment = new Object();
        objAttachment.FileName = $(this).html();
        objAttachment.FilePath = $(this).attr("id");
        attachmentList.push(objAttachment);
    });

    var body = tinyMCE.get('elm1').getContent();

    body = encodeURI(body);
    var emailMessage = $('<div/>').html(tinyMCE.activeEditor.getContent()).text();

    var MessageType = "InternalExternal";



    $.post(_ResolveUrl + "ProviderPortal/Messages/CallBacks/MessagesHandler.aspx", { emailTo: emailTo, emailCC: emailCC, subject: subject, ExternalTo: ExternalTo, ExternalCC: ExternalCC, priority: priority, body: body, attachmentList: JSON.stringify(attachmentList), action: "Add", isDraft: isDraft, MessageType: MessageType, emailMessage: emailMessage },
            function (data) {

                $("#divComposeMessage").dialog("close");
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                var result = returnHtml.substring(start, end);
                if (!isDraft) {
                    showSuccessMessage("Message Sent Successfully");
                    ReloadMessages();
                }
                else {
                    showSuccessMessage("Message Saved Successfully");
                }

                start = data.indexOf("###StartUnreadCount###") + 22;
                end = data.indexOf("###EndUnreadCount###");
                $(".lblUnreadMessageCount, [id$='lblUnreadMessageCount']").html($.trim(returnHtml.substring(start, end)));
            });
}


function DeleteMessage() {
    if ($("#messageList input:checkbox:checked, #sentMessagesList  input:checkbox:checked").length > 0 || $("#divMessageDetail").is(":visible")) {
        var messagesId = "";
        if ($("#divMessageDetail").is(":visible")) {
            messagesId = $("#hidnMsgId").val();
        }
        else {
            $("#messageList input:checkbox:checked, #sentMessagesList  input:checkbox:checked").each(function () {
                messagesId += ($(this).attr("id")) + ";";
            });
        }
        $("#confirm_delete").dialog({

            modal: true,
            width: '350px',
            buttons: {
                Yes: function () {
                    var action = "Delete";
                    var deleteFromaction = ($(".nav-list li.selected a").text());
                    $.post(_ResolveUrl + "ProviderPortal/Messages/CallBacks/MessagesHandler.aspx", { MessagesId: messagesId, action: action, DeleteFromaction: deleteFromaction }, function (data) {
                        $("#confirm_delete").dialog("close");
                        if ($("#divMessageDetail").is(":visible")) {
                            showSuccessMessage("Success: Message deleted.");
                            BackToInbox();
                            ReloadMessages();
                        } else {
                            $("#tblMessageList thead input:checkbox, #tblSentMessageList thead input:checkbox").prop("checked", false);
                            $("#messageList input:checkbox:checked, #sentMessagesList  input:checkbox:checked").each(function () {
                                $(this).closest("tr").remove();
                            });
                            showSuccessMessage("Success: Messages deleted.");
                            var returnHtml = data;
                            var start = data.indexOf("###StartUnreadCount###") + 22;
                            var end = data.indexOf("###EndUnreadCount###");
                            $(".lblUnreadMessageCount, [id$='lblUnreadMessageCount']").html($.trim(returnHtml.substring(start, end)));
                        }

                    });
                },
                "No": function () {
                    $("#confirm_delete").dialog("close");
                }
            }
        });
    }
    else {
        dialogShowMessage("Select atleast one message to delete.", "Error");
    }
}