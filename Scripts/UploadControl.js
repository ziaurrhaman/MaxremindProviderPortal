

var settingControlImageUpload = {
    imageContainer: "",   //Setter (jQuery object)
    imageFileName: "",    //Setter (jQuery object)

    fileName: "",         //Getter
    filePath: ""          //Getter
};


function controlImageUpload(obj) {

    new AjaxUpload('#' + obj.instance, {
        action: _ControlPath + "/ImageControlHandler.ashx",
        dataType: 'json',
        contentType: "application/json; charset=uft-8",
        data: {
            UploadDir: obj.uploadDir,
            patientId: obj.patientId
        },
        onSubmit: function (file, ext, fileSize) {
            if (!(ext && /^(jpg|png|jpeg|gif|bmp)$/.test(ext))) {
                callDialog("Sorry! the file is invalid.", "Invalid File");
                return false;
            }
            if (fileSize > 25) {
                callDialog("This file exceeds the 5MB attachment limit.", "Attachment Limit");
                return false;
            }
        },
        onComplete: function (file, response) {
            var responseHTML = $(response);
            var response = $.parseJSON(responseHTML.html());
            settingControlImageUpload.imageContainer.attr("src", _PracticeDocumentsPath + "/" + response.path);
            settingControlImageUpload.imageFileName.val(response.fileName);

            settingControlImageUpload.fileName = response.fileName;
            settingControlImageUpload.filePath = response.path;
            obj.onComplete.call();
        }
    });
}


function controlUpload(obj) {

    new AjaxUpload('#' + obj.instance, {
        action: _ControlPath + "/ImageUploadControlHandler.ashx",
        dataType: 'json',
        contentType: "application/json; charset=uft-8",
        data: {
            ClientType: obj.clientType
        },
        onSubmit: function (file, ext, fileSize) {
            if (!(ext && /^(jpg|png|jpeg|gif|bmp)$/.test(ext))) {
                callDialog("Sorry! the file is invalid.", "Invalid File");
                return false;
            }
            if (fileSize > 25) {
                callDialog("This file exceeds the 5MB attachment limit.", "Attachment Limit");
                return false;
            }
        },
        onComplete: function (file, response) {
            var responseHTML = $(response);
            var response = $.parseJSON(responseHTML.html());
            settingControlImageUpload.imageContainer.attr("src", _PracticeDocumentsPath + "/" + $("[id$='hdnPracticeIdMaster']").val() + "/" + obj.clientType + "/" + response.fileName);
            settingControlImageUpload.imageFileName.val(response.fileName);
        }
    });
}
