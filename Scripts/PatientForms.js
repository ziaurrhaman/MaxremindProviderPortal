

function PatientForms_ClickFormLink(FormName, FormType, PageName) {
    $.post(_EMRPath + "/PatientForms/" + FormType + "/" + PageName + ".aspx", { PatientId: _PatientId }, function (data) {
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#divPatientFormContents").html(returnHtml)
        .promise()
        .done(function () {
            $("#divDialogPatientForms").dialog({
                title: FormName,
                width: 880,
                modal: true,
                position: { my: "center", at: "center top", of: window },
                close: function () {
                    $(this).dialog("destroy");
                }
            });
        });
    });
}

function PatientForms_Print() {
    printHtml("divPatientFormsInner");
}