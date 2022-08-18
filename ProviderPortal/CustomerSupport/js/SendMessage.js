$(document).ready(function () {
    $("#txtPhoneNumber").mask("(999) 999-9999");
    UploadFileFormReadyCommon();
    $('#txtPhoneNumber').keypress(function (e) {
        var regex = new RegExp("^[0-9+]+$");
        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (regex.test(str)) {
            return true;
        }
        return false;
    });
    $('#txtUserName').keypress(function (e) {
        var regex = new RegExp("^[A-Za-z ]+$");
        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (regex.test(str)) {
            return true;
        }
        return false;
    });
   
});

function SendMessage() {
    debugger;
    var fileName = "";
    var attachmentList = new Array();
    $(".SendMessageList tr").each(function () {
        fileName +=$(this).find('.hdnPath').val() + ",";
    });
    var objSendMessage = new Object();
    objSendMessage.tbname = $("#txtUserName").val();
    objSendMessage.tbemail = $("#txtEmail").val();
    objSendMessage.tbphone = $("#txtPhoneNumber").val();
    objSendMessage.tbsubject = $("#txtSubject").val();
    objSendMessage.tbMesage = $("#txtMessage").val();
    var grecaptcharesponse = $("#g-recaptcha-response").val();
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (regex.test(objSendMessage.tbemail)) {
        $("#txtEmail").css("border","solid 1px #c4c4c4");
    } else {
        $("#txtEmail").css("border", "1px solid red");
        showErrorMessage("Please enter a valid email!");
        return;
    }
    if (objSendMessage.tbphone == "" || objSendMessage.tbsubject=="") {
        $("#txtPhoneNumber").css("border", "1px solid red");
        $("#txtSubject").css("border", "1px solid red");
        return;
    } else {
        $("#txtPhoneNumber").css("border", "solid 1px #c4c4c4");
        $("#txtSubject").css("border", "solid 1px #c4c4c4");
    }
    $.post("../CustomerSupport/SendMessage.aspx",
       { objSendMessage: JSON.stringify(objSendMessage),grecaptcharesponse:grecaptcharesponse,fileName:fileName, action: "SendMessage" },
       function (data) {
           debugger
           var start = data.indexOf("###Start###") + 13
           var end = data.indexOf("###End###");
           var returnHtml = $.trim(data.substring(start, end));
           if (returnHtml != "") {
               $(".divErrorShowMessage").show();
               $(".alert-danger").show();
               setTimeout(function () {
                   $(".alert-danger").fadeOut(1500);
               }, 3000);
           }
           else{
               $(".divSendMessage").hide();
               $(".divShowMessage").show();
               $(".alert - success").show();
           }
       });
}
function UploadFileFormReadyCommon() {
    debugger;

    new AjaxUpload('#linkUploadFiles', {

        action: '/ProviderPortal/CustomerSupport/js/FileAttachments.ashx',
        dataType: 'json',
        contentType: "application/json; charset=uft-8",
        data: {
            ClaimAppealId: 1
        },
        onSubmit: function (file, ext, fileSize) {
            if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                callDialog("Sorry! the file is invalid.", "Invalid File");
                return false;
            }

        },
        onComplete: function (file, response) {

            var responseHTML = $.parseJSON($(response).html());


            $(".SendMessageList").append(
                '<tr><td><span class="spnfileName float-left clr-primary">' + file + '</span><span onclick="RemoveAttchment(this)" class="fa fa-trash DeleteColor" float-left ml-10x cursorPointer" title"delete"></span>' +
                '<input type="hidden" value="' + responseHTML.path +
                '"class="hdnPath"/><input type="hidden" value="' + responseHTML.fileName +
                '" class="hdnfile" /></td></tr>'
            );
            //$(".iconAttachment").hide();
        }
    });
}
function RemoveAttchment(elem) {
    $(elem).closest('tr').remove();
    showSuccessMessage("Attachment Remove successfully!");
}