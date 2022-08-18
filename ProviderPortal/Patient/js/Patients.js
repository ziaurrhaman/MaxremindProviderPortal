var _PracticeId;
var _isCheckExists = 0;
var ERAMasterId;
var arrFileTypes = ["jpg", "jpeg", "png", "gif", "bmp", "webp"];
var _fileName = "";
var _Path = "";
var _CheckForDialogueClose = false;
var _BalnceSheetHtml = '';
var _Counter = 0;
//Added by Khayyam adeel Desc: Patient javascript handler


$(document).ready(function () {
    $("[id$='PaymentDate']").datepicker({
        changeMonth: true,
        changeYear: true,
    }).mask("99/99/9999");

    new AjaxUpload('#linkUploadFiles',
        {
            action: '../PatientDocument/PatientDocumentHandler.ashx',
            dataType: 'json',
            contentType: "application/json; charset=uft-8",
            data: {
                PatientId: $("#DialogPatientId").val(),
                Action: "UploadFiles_Add"
            },
            onSubmit: function (file, ext, fileSize) {
                if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                    callDialog("Sorry! the file is invalid.", "Invalid File");
                    return false;
                }
                var uploadedFile = $.trim($("#divPatientDocumentsFilesInner").html());
                $("#divPatientDocumentsFilesInner").html("");
                if (fileSize > 2000.63556480407715) {
                    callDialog("This file exceeds the 2GB attachment limit.", "Attachment Limit");
                    return false;
                }
            },
            onComplete: function (file, response) {
                debugger;
                var responseHTML = $.parseJSON($(response).html());
                $("#divEditUploadFileForm").find(".hdnDocumentPath").val(_PracticeDocumentsPath + "/" + responseHTML.path);
                $("#divEditUploadFileForm").find(".hdnOriginalFileName").val(file);
                $("#FileId").val(responseHTML.FileId);
                AppendUploadedFile1(responseHTML.fileName, responseHTML.path, file);

            }
        });
    ////


});
function DeleteAttachment1(elem) {

    $(elem).closest(".patient-document-files-wrapper").hide();
    $(elem).closest(".patient-document-files-wrapper").find(".hdnDeleted").val("true");

    _Path = "";
    $(elem).closest(".patient-document-files-wrapper").find(".hdnDocumentPath").val("");
    $(elem).closest(".patient-document-files-wrapper").find(".hdnOriginalFileName").val("");
    $(elem).closest(".patient-document-files-wrapper").html("");

}
function DownloadPatientDocumentFile(elem) {
    debugger;
    var filePath = $(elem).closest(".patient-document-files-wrapper").find(".hdnDocumentPath").val();
    var fileName = $(elem).closest(".patient-document-files-wrapper").find(".hdnOriginalFileName").val();
    saveToDisk(filePath, fileName);
}
function AppendUploadedFile1(fileName, path, file) {
    //style="overflow-y: scroll;max-height: 230px;"
    if ($(".hdnDocumentPath").val() == undefined || $(".hdnDocumentPath").val() == "") {
        var documentFile = '' +
            '<div class="patient-document-files-wrapper" >' +
            GetFileLink1(file, _PracticeDocumentsPath + "/" + path) +
            '<input type="hidden" class="hdnDocumentId" value="0" />' +
            '<input type="hidden" class="hdnDocumentPath" value="' + _PracticeDocumentsPath + "/" + path + '" />' +
            '<input type="hidden" class="hdnOriginalFileName" value="' + file + '" />' +
            '<input type="hidden" class="hdnDeleted" value="false" />' +
            '</div>';

        $(".Right_FileAssignment").append(documentFile);
        _filename = file;
        _Path = _PracticeDocumentsPath + "/" + path;
    } else { showErrorMessage("File is already uploaded.Please delete first for Upload new file !") }

}
function GetFileLink1(file, path) {
    var fileLink = "";
    UploadedFileAutoFill(file, path);
    var fileType = $.trim(file.substring(file.length - 3, file.length));
    fileType = fileType.toLocaleLowerCase();

    if ($.inArray(fileType, arrFileTypes) < 0) {
        if (fileType == "pdf") {
            fileLink = '' +
                '<embed src="' + path + '" width="200" height="200" alt="pdf">' +
                '<div class="hover-action-div">' +
                '<span class="spndelete" onclick="DeleteAttachment1(this)" style="margin-left: 4px;" title="Delete"></span>' +
                '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>' +
                '</div>';
        }
        else {
            fileLink = '' +
                '<a href="' + path + '" style="float: left; color: #00F; margin: 0 5px 0 0;" target="_blank">' + file + '</a>' +
                '<span class="spndelete" onclick="DeleteAttachment1(this)" style="margin-left: 4px;" title="Delete"></span>' +
                '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>';
        }
    }
    else {
        fileLink = '' +
            '<img style="width:100%" src="' + path + '" />' +
            '<div class="hover-action-div">' +
            '<span class="spndelete" onclick="DeleteAttachment1(this)" style="margin-left: 4px;" title="Delete"></span>' +
            '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>' +
            '</div>';
    }

    return fileLink;
}
function UploadedFileAutoFill(file, path) {
    debugger;

    var fullDate = new Date();
    var twoDigitMonth = fullDate.getMonth() + 1;
    if (twoDigitMonth.length == 1) { twoDigitMonth = "0" + twoDigitMonth; }
    var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
    var currentDate = twoDigitMonth + "/" + twoDigitDate + "/" + fullDate.getFullYear();
    debugger;
    //if ($("#txtIntDate").val() == "") { $("#txtIntDate").val(currentDate); }


    if (typeof (file) != "undefined") {
        debugger;
        var filenamereverse = file.substring(0, file.lastIndexOf('.'));
        $("#txtDocName").val(file);
        $("#txtDocumentName").val(file);
        //$("#txtDocName").val(file);
        //Change By Syed Sajid Ali Date 7/11/2018
        var fileformate = $.trim(file.substring(file.length - 3, file.length));


        fileformate = fileformate.toUpperCase();
        if ($("#ddlReceivedBy").val() != 0) { }
        else { $("#ddlReceivedBy").prop('selectedIndex', 4); }


    }
    debugger
    if (fileformate == "PDF")
        $("#FileFormate").val(2);
    if (fileformate == "TXT")
        $("#FileFormate").val(5);
    if (fileformate == "ZIP")
        $("#FileFormate").val(1);
    if (fileformate == "JPG")
        $("#FileFormate").val(6);
    if (fileformate == "PEG")
        $("#FileFormate").val(6);
    if (fileformate == "PNG")
        $("#FileFormate").val(6);
    if (fileformate == "GIF")
        $("#FileFormate").val(6);
    if (fileformate == "OCX")
        $("#FileFormate").val(3);
    if (fileformate == "LSX")
        $("#FileFormate").val(4);
    if (fileformate == "CSV")
        $("#FileFormate").val(8);
    if (fileformate == "XLS")
        $("#FileFormate").val(4);
    currentDate = "";
}
//End 

function SelectDate(date) {
    debugger;
    $("[id$='CheckDate']").val(date);
}
function ddlEOBPaymentMethod_Change(elem) {
    debugger;
    var a = $(elem).find("option:selected").val();
    if ($("#ddlEOBPaymentMethod option:selected").val() != "Check") {
        debugger
        $(".ChkNO").css("display", "none");
        $(".SrNo").css("display", "");
        $("#txtSrNo").val($("#DialogPatientId").val() + formatDate(new Date().toLocaleDateString()));

    }
    else {
        $(".ChkNO").css("display", "");
        $(".SrNo").css("display", "none");
    }
}

function SaveEOB(isAllocate, Action) {
    debugger
    var filelist = $("[id$='FileId']").val();
    var CheckDate = $("[id$='CheckDate']").val();
    if (filelist == "") {
        $(function () {
            $("<div></div>").html("<span>Please attach the file. </span>").dialog({
                resizable: false,
                title: "Information!",
                maxheight: 180,
                width: 400,
                modal: true,
                buttons: {
                    "Ok": function () {
                        $(this).dialog("destroy");
                    }

                },

            });


        });
        filelist = "";
    }
    else if ($("#ddlEOBPaymentMethod option:selected").val() == "Check" && $("[id$='txtEOBRefNo']").val() == "") {
       
      
        $("<div></div>").html("<span>Please Select CheckNo. </span>").dialog({
            resizable: false,
            title: "Information!",
            maxheight: 180,
            width: 400,
            modal: true,
            buttons: {
                "Ok": function () {
                    $(this).dialog("destroy");
                }

            },

        });

    }
    else if ($("#ddlEOBPaymentMethod option:selected").val() != "Check" && $("#txtSrNo").val() == "") {
       
      
        $("<div></div>").html("<span>Please Select SrNo. </span>").dialog({
            resizable: false,
            title: "Information!",
            maxheight: 180,
            width: 400,
            modal: true,
            buttons: {
                "Ok": function () {
                    $(this).dialog("destroy");
                }

            },

        });

    }

    else if ($('#PaymentDate').val() == "") {
       
        $("<div></div>").html("<span>Please Select PaymentDate. </span>").dialog({
            resizable: false,
            title: "Information!",
            maxheight: 180,
            width: 400,
            modal: true,
            buttons: {
                "Ok": function () {
                    $(this).dialog("destroy");
                }

            },

        });
    }
    else if ($('#txtEOBAmount').val() == "") {
        
        $("<div></div>").html("<span>Please Select Payment Amount. </span>").dialog({
            resizable: false,
            title: "Information!",
            maxheight: 180,
            width: 400,
            modal: true,
            buttons: {
                "Ok": function () {
                    $(this).dialog("destroy");
                }

            },

        });
    }

    else {

        if (Action == 'Save') {
            _isCheckExists = 0;
            filelist = "";
        }

            
        var PayerName = "";

        //Added by Khayyam Adeel desc: File Added in FileDocumnetAttachement in DB
        //File is added in UploadFiles , AttachFiles and FileDocumentAttachement in DB.
        //Patient id added in EOBPatient in DB , 
        var listUploadFiles = new Array();
        var listPatientIds = new Array();
        var objInsUploadFiles = new Object()
        objInsUploadFiles.uploadFileId = $('[id$="FileId"]').val() || 0;
        objInsUploadFiles.ERAAttachfileId = 0;
        
        listUploadFiles.push(objInsUploadFiles);
        //---end-----

        //----Patient Added in EOBPatient---
        var listPatientIds = new Array();
            debugger;
            var objPatientsIds = new Object()
        objPatientsIds.PatientId = $("#DialogPatientId").val();
            objPatientsIds.EOBPatientId = 0;
            if (objPatientsIds.EOBPatientId == "") {
                objPatientsIds.EOBPatientId = 0;
        }
        objPatientsIds.PaymentReason = $("[id$='PaymentFor'] option:selected").val();
        listPatientIds.push(objPatientsIds);

        //----End--------------------------

        var EOB = new Object();
        EOB.ERAMasterId = $("[id$='hdnERAMasterId']").val() || 0;
        var ERA_MasterId = EOB.ERAMasterId;
        EOB.CheckIssueDate = $("#CheckDate").val();

        if ($("#ddlEOBPaymentMethod option:selected").val() != "Check") {
            EOB.CheckNumber = $("#txtSrNo").val();

        }
        else {
            var CheckNumber = $("[id$='txtEOBRefNo']").val();
            EOB.CheckNumber = CheckNumber;
        }
        
        EOB.PaymentMethodCode = $("[id$='ddlEOBPaymentMethod']").val();
        EOB.PaymentAmount = $("[id$='txtEOBAmount']").val();


        //EOB.PatientId = $("[id$='hdnPatientId']").val();
        EOB.PatientId = $("#DialogPatientId").val();
    
        var PaymentType = "PAT";
        debugger;
        if (EOB.PatientId != "" && EOB.PatientId != null) {
            EOB.PayerName = $("#DialogPatientName").val();
            EOB.PaymentType = "PAT";
        }
        else {
            EOB.PayerName = $("[id$='ddlEOBInsurance'] option:selected").text();
            EOB.PayerIdentifier = $("[id$='ddlEOBInsurance']").val();
            EOB.PaymentType = "EOB";
        }
        var uploadFileId = $('[id$="FileId"]').val() || 0;
        var PaymentFor = $("[id$='PaymentFor'] option:selected").val();
        EOB.PaymentFor = PaymentFor;
        var PaymentReason = $("[id$='PaymentReason']").val();
        EOB.Notes = PaymentReason;
        $.post("../Claims/CallBacks/AddNewEOBHandler.aspx", { Payerid: EOB.PatientId, NewEOB: JSON.stringify(EOB), Notes: EOB.Notes, listUploadFiles: JSON.stringify(listUploadFiles), UploadFileId: uploadFileId, listPatientIds: JSON.stringify(listPatientIds), _isCheckExists: _isCheckExists },
            function (data) {
                debugger;
                var startChkExist = data.indexOf("###StartIfCheckExists###") + 24;
                var endChkExist = data.indexOf("###EndIfCheckExists###");
                var IfCheckExists = $.trim(data.substring(startChkExist, endChkExist));
                if (_isCheckExists == 0 && IfCheckExists == "true" && ERA_MasterId == 0) {
                    CheckPaymentDetails(isAllocate, EOB.CheckNumber, PaymentType);

                }
                else {
                    debugger;
                    var returnHtml = data;
                    var start = data.indexOf("###StartResult###") + 17;
                    var end = data.indexOf("###EndResult###");
                    if (parseInt(returnHtml.substring(start, end)) > 0) {
                        ShowDialog();
                        _CheckForDialogueClose = true;
                        ERAMasterId = parseInt(returnHtml.substring(start, end));
                    }
                }
            }).promise()
            .done(function () {
                debugger;
                if (_CheckForDialogueClose == true) {
                    $('#postpayment').dialog("close");
                    ResetForm();
                }
                else {
                    _CheckForDialogueClose = false;
                }
            });
    }

    filelist = "";


}
function formatDate(input) {
    debugger
    var datePart = input.match(/\d+/g),
        year = datePart[2].substring(2), // get only two digits
        month = datePart[0], day = datePart[1];

    return month + day + year;
}

function CloseFileSearchDiv() {
    debugger
    $(".search_div").hide();
    if (UserNameIds == "") {
        $("#MultipleUserNameTxt").val("All");
    }
    $("[id$='txtFilename']").val("");
}
function fileSearch(serachValue) {
    debugger;
    _PracticeId = $("[id$='hdnPracticeId']").val();

    $.post("../ReportsNew/CallBacks/ClaimFileSearch.aspx", { FileName: serachValue, PracticeId: _PracticeId })
        .promise()
        .done(function (data) {
            debugger
            $("#FileNameSearchedList").html();
            var start = data.indexOf("###StartSearchFile###") + 21;
            var end = data.indexOf(" ###EndSearchFile###");
            var returnHtml = $.trim(data.substring(start, end));

            $("[id$='FileNameSearchedList']").parent(".Grid").animate({ scrollTop: 0 }, "fast");
            $("[id$='FileNameSearchedList']").html(returnHtml);
            $("[id$='divSearchFile']").show();
            $("#IcdsSearchedList tr:first").addClass("row_selected");
            var currentRow = $(".row_selected").get(0);
            $("[id$='txtFilename'] [id$='txtFilename_EOB']").keyup(function (e) {
                debugger
                if (window.event)
                    code = e.keyCode;
                else code = e.which;
                if (code == 40) {
                    $(currentRow).prev().removeClass("row_selected");
                    $(currentRow).next().addClass("row_selected");
                    $(currentRow).removeClass("row_selected");
                    currentRow = $(currentRow).next();
                }
                if (code == 38) {
                    $(currentRow).next().removeClass("row_selected");
                    $(currentRow).prev().addClass("row_selected");
                    $(currentRow).removeClass("row_selected");
                    currentRow = $(currentRow).prev();
                }
                if (code == 13) {
                    var name = ''; var id = '';
                    name = $.trim($(currentRow).find(".hdnname").html());
                    id = $.trim($(currentRow).find(".hdnid").html());
                    $("[id$='hdnUploadedFilesID']").val(id);
                    $("#txtFilename [id$='txtFilename_EOB']").val(name);

                    $("#divSearchFile").hide();
                }

            });

        });
}
function selectedFile(elem) {
    debugger
    var name = ''; var id = '';
    name = $.trim($(elem).closest("tr").find(".hdnname").html());
    id = $.trim($(elem).closest("tr").find(".hdnid").html());
    $("[id$='hdnUploadedFilesID']").val(id);
    $("[id$='txtFilename']").val(name);
    $("[id$='divSearchFile']").hide();
}
function ShowDialog() {
    $("#divReport").dialog({
        width: 350,
        resizable: false,
        height: 140,
        modal: true,
        title: 'Success',
        buttons: {

            "Done": function () {
                $(this).dialog("close");
            }
        }
    });
}
function ResetForm() {
    $("#txtEOBDate").val("");
    $("[id$='PaymentDate']").val("");
    $("[id$='txtFilename']").val("");
    $("[id$='txtEOBRefNo']").val("");
    $("[id$='txtEOBAmount']").val("");
    $("[id$='CheckDate']").val("");
    $("[id$='OtherPayment']").val("");
    $(".Right_FileAssignment").html("");
    $("#txtEOBRefNo").val("");
    $("#txtEOBAmount").val("");
    $("#PaymentReason").val("");
    $("#ddlEOBPaymentMethod").val($("#ddlEOBPaymentMethod option:first").val());
}
function CheckPaymentDetails(isAllocate, CheckNumber, PaymentType) {
    $.post("../Claims/CallBacks/CheckPaymentDetails.aspx", { CheckNumber: CheckNumber, PaymentType: PaymentType }, function (data) {
        var start = data.indexOf("###Start###") + 20;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divPopupChkPaymentDetails").html(returnHtml).dialog({
            resizable: false,
            title: "Confirmation",
            height: 300,
            width: 800,
            modal: true,
            buttons: {
                Yes: function () {
                    _isCheckExists = 1;
                    SaveEOB(isAllocate, "");
                    $(this).dialog("destroy");
                },
                NO: function () {
                    $(this).dialog("destroy");
                }
            },
            close: function () {
                $(this).dialog("destroy");
            }
        });
        $("#divPopupChkPaymentDetails").show();
    });

}

function UploadFileFormReadyCommon() {
    debugger
    new AjaxUpload('#linkUploadFiles',
        {
            action: '../EMR/PatientDocument/PatientDocumentHandlerTest.ashx',
            dataType: 'json',
            contentType: "application/json; charset=uft-8",
            data: {
                PatientId: $("uploadFileID").val()
            },
            onSubmit: function (file, ext, fileSize) {
                if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                    callDialog("Sorry! the file is invalid.", "Invalid File");
                    return false;
                }
                var uploadedFile = $.trim($("#divPatientDocumentsFilesInner").html());
                $("#divPatientDocumentsFilesInner").html("");
                if (fileSize > 2000.63556480407715) {
                    callDialog("This file exceeds the 2GB attachment limit.", "Attachment Limit");
                    return false;
                }
            },
            onComplete: function (file, response) {
                var responseHTML = $.parseJSON($(response).html());
                $("#divEditUploadFileForm").find(".hdnDocumentPath").val(_PracticeDocumentsPath + "/" + responseHTML.path);
                $("#divEditUploadFileForm").find(".hdnOriginalFileName").val(file);

               // AppendUploadedFile1(responseHTML.fileName, responseHTML.path, file);
            }
        });
}
//ADded by Khayyam Adeel desc: Balance sheet in Patient
function ViewPaymentDetails(elem) {
    debugger
    //var a = $("[id$=ContentPlaceHolder1_lblBalanceDue]").html();
    //var b = $("[id$=ContentPlaceHolder1_lblpaid]").html();
    //var c = $("[id$=ContentPlaceHolder1_lblpr]").html();
    //var e = $("[id$=ContentPlaceHolder1_lblName]").html();
    var patid = $.trim($(elem).closest("tr").find(".PatId").html()); // $("[id$=ContentPlaceHolder1_hdnPatId]").val();
    var PatName = $.trim($(elem).closest("tr").find(".hdnFullName").html()); 
    $(".balance-info").find("#dialogue_BalanceAmount").html($.trim($(elem).closest("tr").parent().find("td").eq(11).html()) || "$0.00");
    $(".balance-info").find("#dialogue_Paid").html($.trim($(elem).closest("tr").parent().find("td").eq(10).html()));
    $(".balance-info").find("#dialogue_PR").html($.trim($(elem).closest("tr").parent().find("td").eq(9).html()));
    $(".patient-info").find("#AccountNo").html(patid);
    $(".patient-info").find("#FullName").html(PatName);
    var a = $.trim($(elem).closest("tr").find(".hdnCheckNos1 > input").val());

   
    //a = "1001,1002,1003,1004";
    var oldArray = a.split(',');
    var arr = oldArray.filter(function (v) { return v !== '' });
   //added by Khayya Adeel desc:A real bad approch, Multple Post request to meet design requirement
    $.each(arr, function (i, val) {
        $.post("../Patient/callbacks/DemographicsEditandViewHandler.aspx", { action: "getLevel2Detail", PatientId: patid, Checknumber: val }, function (data) {
            debugger
            $("#divLoading").show();
            $("#divOverlay").show();
            var start = data.indexOf("###StartPatientPaymentDeatils_Dialogue###") + 41;
            var end = data.indexOf("###EndPatientPaymentDeatils_Dialogue###");
            var result = data.substring(start, end);

            var startLeftDiv = data.indexOf("###StartRightRptDialogue###") + 55;
            var EndLeftDiv = data.indexOf("###EndRightRptDialogue###");
            var res = data.substring(startLeftDiv, EndLeftDiv);
            $(".tbodyIndividualChecks").html(res);

            
            _BalnceSheetHtml += result;

        }).done(function () {
            
            _Counter++;
            if (_Counter == arr.length) {
                debugger;
                loadDialog();
                $("#divLoading").hide();
                $("#divOverlay").hide();
            }
        });

    });
    


}
function loadDialog() {
    debugger
    var a = $("#lvl2Grid").html();
    $("#lvl2Grid").html("");
    $("#lvl2Grid").html(_BalnceSheetHtml);

    $("#dialogueBody").dialog({
        resizable: false,
        dialogClass: 'BlanceSheet-ui-widget',
        title: 'Balance Sheet',
        width: '1200',
        modal: true,
        buttons: {
            "OK": function () {
                $(this).dialog("close");
                _Counter = 0;
                _BalnceSheetHtml = "";
            },
            "Print": function () {
                debugger

                $(".printableView").html($("#dialogueBody").html());
                
                $(".printableView .bsheet-left").remove();
                //$(".printableView").printThis({
                //    debug: true,               // show the iframe for debugging
                //    importCSS: true,            // import parent page css
                //    importStyle: true,         // import style tags
                //    printContainer: true,       // print outer container/$.selector
                //    loadCSS: "../StyleSheets/BillingManagerTheme.css",         // path to additional css file - use an array [] for multiple
                //    pageTitle: "",              // add title to print page
                //    removeInline: true,        // remove inline styles from print elements
                //    removeInlineSelector: "*",  // custom selectors to filter inline styles. removeInline must be true
                //    printDelay: 10,            // variable print delay
                //    header: null,               // prefix to html
                //    footer: null,               // postfix to html
                //    base: false,                // preserve the BASE tag or accept a string for the URL
                //    formValues: true,           // preserve input/form values
                //    canvas: false,              // copy canvas content
                //    doctypeString: '...',       // enter a different doctype for older markup
                //    removeScripts: false,       // remove script tags from print content
                //    copyTagClasses: true,      // copy classes from the html & body tag
                //    beforePrintEvent: null,     // function for printEvent in iframe
                //    beforePrint: null,          // function called before iframe is filled
                //    afterPrint: null            // function called before iframe is removed
                //});
                
                var contents = $(".printableView").html();
                        var frame1 = $('<iframe />');
                        frame1[0].name = "frame1";
                        frame1.css({ "position": "absolute", "top": "-1000000px" });
                        $("body").append(frame1);
                        var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
                        frameDoc.document.open();
                        //Create a new HTML document.
                        frameDoc.document.write('<html><head><title>Balance Sheet</title>');
                        frameDoc.document.write('</head><body>');
                        //Append the external CSS file.
                        frameDoc.document.write('<link href="../../StyleSheets/BillingManagerTheme.css" rel="stylesheet" type="text/css" />');
                        //Append the DIV contents.
                        frameDoc.document.write(contents);
                        frameDoc.document.write('</body></html>');
                        frameDoc.document.close();
                        setTimeout(function () {
                            window.frames["frame1"].focus();
                            window.frames["frame1"].print();
                            frame1.remove();
                        }, 500);
                _Counter = 0;
                _BalnceSheetHtml = "";
            },
            Cancel: function () {
                $(this).dialog("close");
                _Counter = 0;
                _BalnceSheetHtml = "";
            }

        }
    });
    _Counter = 0;

}
