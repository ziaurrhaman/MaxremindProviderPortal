var patid = 0; var _CustomerSupportQuryId = 0;
var TitleofDialogue = ""; var _message = "";
let ticketfeedback = false;
var messagesaveupdate = "";
$(document).ready(function () {
    debugger;

    $("#ddlticket").css("display","block")

    //if (!checkModuleRights("CustomerSupport")) {

    //    $("[id$='divRightsSettings']").html("You don't have rights to View Customer Support").show();
    //    $("#ContentMaindiv").hide();
    //    return false;
    //}
    $("#tktnumber").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode

        if (!(keyCode >= 48 && keyCode <= 57)) {
            
            return false;
        }
    });

    $('.container').addClass('Support-container').removeClass('container')
    $("#_CustomerSupport").addClass("active");

    $("[id$='TxtGenerateDate'],[id$='LastActivityDate']").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        yearRange: "-110:+0",
        onSelect: function (date, obj) {
            //FilterPatient(0, true);
        }
    }).mask("99/99/9999");

    $("#txtDateForm,#txtDateTo,#txtDOS").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        yearRange: "-110:+0",
    }).mask("99/99/9999");


   debugger
    var TotalRows = $("[id$='hdnTotalRows']").val();

   
    GeneratePaging(TotalRows, $("#ddlPagingTickets").val(), "paggingdiv", "FilterGenTickets");
    
    if (TotalRows > 0) {
        $("#paggingdiv .spanInfo").html("Showing " + $("#TbodySupport tr:first").children().first().html() + " to " + $("#TbodySupport tr:last").children().first().html() + " of " + TotalRows + " entries");
    }

    //$('#txtTicketNo').on("keypress", function (e) {
    //    debugger;
    
    //    var keycode = (e.which) ? e.which : e.keyCode;
       
    //        if (keycode < 48 || keycode > 57) {
    //            return false;
    //        }
    //});


});

//function GenerateTicketDialog() {
//    debugger;
//    $("#divgenerateTicket").dialog({
//        title: "Generate Ticket",
//        height: "auto",
//        width: 600,
//        modal: true,
//        buttons: {
//            Save: function () {
                
//                if ($("[id$='ddlTyp']").val() == "") {
//                    $("[id$='ddlTyp']").css("border", "1px solid red");
//                    return;
//                } else if ($("[id$='ddlTRTo']").val() == "") {
//                    $("[id$='ddlTRTo']").css("border", "1px solid red");
//                    return;
//                }
//                else if ($("[id$='ddlCS']").val() == "") {
//                    $("[id$='ddlCS']").css("border", "1px solid red");
//                    return;
//                }

//                AddNewTickets();

//                  $(this).dialog("close");
//            },
//            Cancel: function () {
//                $(this).dialog("close");
//            }
//        },
//        close: function () {
//            $(this).dialog("destroy");
//        }
//    });
//}

//function SelectTRT() {
//    debugger;
//    var ddlTRTo = $("[id$='ddlTRTo']").val();
//    if (ddlTRTo=="Patient") {
//        $(".PatientData").show();
//        $(".ClaimData").hide();
//        $(".InsuranceData").hide();
//    }
//    else if (ddlTRTo == "Claim") { $(".PatientData").hide(); $(".ClaimData").show(); $(".InsuranceData").hide(); }
//    else if (ddlTRTo == "Insurance") { $(".PatientData").hide(); $(".ClaimData").hide(); $(".InsuranceData").show(); }
//    else if (ddlTRTo == "Eligibility") { $(".PatientData").hide(); $(".ClaimData").hide(); $(".InsuranceData").hide(); }
//    else if (ddlTRTo == "") { $(".PatientData").hide(); $(".ClaimData").hide(); $(".InsuranceData").hide(); }
//}


function AddNewTickets() {
    debugger;
    let error = false;
    debugger

    if (!ValidateFormCustomerSupport("FormMaindiv"))
    {
      return false;
    }
    debugger
    
    var TicketId = _ID;
    if (_ID == "" || _ID == null) {
        TicketId = "0";
    if ($("[id$='subject1']").val() == null || $("[id$='subject1']").val() == "") {
        $("[id$='subject1']").attr('style', 'border: 1px solid red !important');
        error = true;
    } else {
        $("[id$='subject1']").css("border", "1px solid rgb(169, 169, 169");
    }
    if ($("[id$='description1']").val() == null || $("[id$='description1']").val() == "") {
        $("[id$='description1']").attr('style', 'border: 1px solid red !important');
        error = true;
    } else {
        $("[id$='description1']").css("border", "1px solid rgb(169, 169, 169");
    }
    if (error) return;
    }
    var obj = new Object();
    obj.ProviderStatusId = $("[id$='ddlstatus'] option:selected").val();
    obj.AllTickets = $("[id$='ddlallticket'] option:selected").val();
    obj.Subject = $("[id$='subject1']").val();
    obj.Descriptions = $("[id$='description1']").val() || "";
    obj.Response = $("[id$='response']").val() || 0;
    Filename = $("[id$='filename']").val();
    Filepath = $("[id$='filepath']").val();

    //var attachmentList = new Array();
    //$(".attachments").each(function () {
        
    //    debugger
    //    var objAttachment = new Object();
    //    objAttachment.CSAttachmentsId = $(this).find('.TicketAttachmentId').val() || 0;
    //    objAttachment.FileName = $.trim($(this).find('.attachment-name').html());
    //    objAttachment.AttachmentPath = $(this).find('.attachment-name').attr("id");
    //    attachmentList.push(objAttachment);
    //});
    //debugger
    //if (attachmentList == "") {

    //    showErrorMessage("Error: Please Add atleast 1 attachment");
     
    //    return;
    //}

    if (TicketId == 0)
    {
        messagesaveupdate = "Ticket Saved Successfully!";
    }
    else {
        messagesaveupdate = "Ticket Updated Successfully!";
    }
    var statudId1 = $("[id$='ddlstatus'] option:selected").val();
    if (statudId1 == 8 && ticketfeedback==false) {
        $('#feedback').modal('show');

        return;
    }
    $.post("../CustomerSupport/CallBacks/GenerateTicketHandler.aspx",
        { TicketData: JSON.stringify(obj), action: "SaveTicketsData", TicketId: TicketId, Filename:Filename,FilePath:Filepath },
        function (data) {
            debugger
            showSuccessMessage(messagesaveupdate);
      //  FilterGenTickets(0, true);
       // clearform();
        closediv();
        _ID = "";
        });

   
   
   
}
function SaveFeedback() {
    debugger;
    var Id = _ID;
    var CustomerFeedBack = $("[id$='comment']").val();
    var Rating = $("[id$='starrating']").val();
    $.post("../CustomerSupport/CallBacks/GenerateTicketHandler.aspx",
        { Id: Id, CustomerFeedBack: CustomerFeedBack, Rating: Rating, action: "SaveFeedback"},
        function (data) {
            debugger
            showSuccessMessage("FeedBack Submitted Succesfully");
            //closediv();
            $('#feedback').modal('hide');
            
        });
    ticketfeedback = true;
}
function closefeedbackModal() {
    debugger;
    ticketfeedback = true;
    $("#feedback").on('hidden.bs.modal', function () {
        $(this).data('bs.modal', null);
    });
    
}

function SetSearch(event) {
    debugger;
    var a = event.which || event.keyCode;
    if (a == 13) {
        if ($("#FilterIcon").hasClass("active")) {
            FilterGenTickets(0, true);
            $("#FilterIcon").css("color", "#065172");
        }
    }
    else {
        $("#FilterIcon").addClass("active");
        $("#FilterIcon").css("color", "red");
    }

}
function FilterGenTickets(pageNumber, paging)
{
    debugger
    
    var searchticket = $("[id$='tktnumber']").val() == "" ? 0 : $("[id$='tktnumber']").val();
    var subject = $.trim($("#txtsubject").val());
    var description = $.trim($("#txtdescription").val());
    var Tkdate = $.trim($("#tktdate").val());
    var StatusId = $.trim($("[id$='ddlstatussearch']").val());
    var Response = $.trim($("[id$='txtresponse']").val());
    
    var params = {
      
        Rows: $("#ddlPagingTickets").val(),
        PageNumber: pageNumber,
        action: "Filter",
        TicketNo: searchticket,
        Subject: subject,
        Description: description,
        Tkdate: Tkdate,
        StatusId: StatusId,
        Response:Response
        
    };

    $.post("../CustomerSupport/CallBacks/GenerateTicketHandler.aspx",params,function (data) {
        debugger
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 13
        var end = data.indexOf("###End###");
        var result = $.trim(returnHtml.substring(start, end));
        $("#TbodySupport").html(result);

        ////var startRowsCount = data.indexOf("###StartPatientRowsCount###") + 30;
        ////var endRowsCount = data.indexOf("###EndPatientRowsCount###");
        ////$("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

            var TotalRows = $("[id$='hdnrows']").val();
        
            if (paging == true) {
                GeneratePaging(TotalRows, $("#ddlPagingTickets").val(), "paggingdiv", "FilterGenTickets");
            }
            if (TotalRows > 0) {

                $("#paggingdiv .spanInfo").html("Showing " + $("#TbodySupport tr:first").children().first().html() + " to " + $("#TbodySupport tr:last").children().first().html() + " of " + TotalRows + " entries");
            }

        });
}


//function UpdateTickets(elem)
//{
//    debugger;
//    var TicketId = $(elem).closest('tr').find("td:eq(0)").text();
//    var Description = $(elem).closest('tr').find("td:eq(1)").text();
//    var TicketType = $(elem).closest('tr').find("td:eq(2)").text();
//    var Status = $(elem).closest('tr').find("td:eq(3)").text();
//    var dos = $(elem).closest('tr').find("td:eq(4)").text();
//    var Priority = $(elem).closest('tr').find("td:eq(5)").text();
//    var TicketReleatedTo = $(elem).closest('tr').find("td:eq(7)").text();
//    var PatName = $(elem).closest('tr').find("td:eq(8)").text();
//    patid = $(elem).closest('tr').find("td:eq(9)").text();
  
// //   GenerateTicketDialog();
//    $("[id$='ddlTyp']").val(TicketType);
//    $("[id$='ddlTRTo']").val(TicketReleatedTo);
//    $("[id$='ddlpri']").val(Priority);
//    $("#txtFormNotesNote").val(Description);
//    $("#txtDOS").val(dos);
//    $("[id$='lblTitleNo']").text(TicketId);
//    $("#txtPatientId").val(PatName);
   
//    $("#btnSaveticket").val("Update");

//    debugger
//viewAttchedFileWhileUpdateTicket(TicketId);
    
//}

//var arrFileTypes = ["jpg", "jpeg", "png", "gif", "bmp", "webp"];
//function viewAttchedFileWhileUpdateTicket(TicketId)
//{
//    debugger
//    $.post("../CustomerSupport/CallBacks/GenerateTicketHandler.aspx", { action: "viewAttchFiles", TicketId: TicketId }, function (data) {
//        debugger

//        var start = data.indexOf("###StartAtt###") + 18
//        var end = data.indexOf("###EndAtt###");
//        var returnHtml = $.trim(data.substring(start, end));
//        $("#attachmentdivsidetbody").html(returnHtml);

//        if (checkUploadFileLit() == 4 || checkUploadFileLit() > 4) {

//            $("#btnUploadMessageAttachments").hide();
//        }
//        else {
//            $("#btnUploadMessageAttachments").show();
//        }
//    });
//}
//function SetPendingViewDocuments21(id, Name, path) {
//    debugger;
//    var fileLink;
//    var DocumentHtml = "";

//    $("#divDialogDocuments_Viewer").html("");


//    var fileName = Name;
//    var filePath = path;

//    DocumentHtml = '<div class="patient-document-files-wrapper">' +
//                        GetFileLink(fileName, filePath) +
//                        '<input type="hidden" class="hdnDocumentId" value="0" />' +
//                        '<input type="hidden" class="hdnDocumentPath" value="' + filePath + '" />' +
//                        '<input type="hidden" class="hdnOriginalFileName" value="' + fileName + '" />' +
//                        '<input type="hidden" class="hdnDeleted" value="false" />' +
//                    '</div>';

//    //fileLink = GetFileLink(fileName, filePath);

//    $("#divDialogDocuments_Viewer").append(DocumentHtml);
//    //$(".spndelete").css("display", "none");


//    $("#divDialogDocuments_Viewer").dialog({
//        title: "View Documents",
//        modal: true,
//        width: $(window).width() - 50,
//        //minHeight: ($(window).height() + 50),
//        position: { my: "top", at: "top", of: window }
//    });
//}
//function GetFileLink(file, path) {

//    debugger;
//    var fileLink = "";
//    UploadedFileAutoFill(file, path);

//    var fileType = $.trim(file.substring(file.length - 3, file.length));
//    if (file != "" || path != "") {
//        fileType = fileType.toLocaleLowerCase();
//    }
//    if ($.inArray(fileType, arrFileTypes) < 0) {
//        if (fileType == "pdf") {
//            fileLink = '' +
//            '<embed src="' + path + '" width="600" height="500" alt="pdf">' +
//            '<div class="hover-action-div">' +
//                '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
//                '<span class="spndownload" onclick="DownloadUploadedFileDialouge(this)" style="margin-left: 4px;" title="Download"></span>' +
//            '</div>';
//        }
//        else {
//            fileLink = '' +
//            '<a href="' + path + '" style="float: left; color: #00F; margin: 0 5px 0 0;" target="_blank">' + file + '</a>' +
//            '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
//            '<span class="spndownload" onclick="DownloadUploadedFileDialouge(this)" style="margin-left: 4px;" title="Download"></span>';
//        }
//    }
//    else {
//        fileLink = '' +
//        '<img style="width:100%" src="' + path + '" />' +
//        '<div class="hover-action-div">' +
//            '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
//            '<span class="spndownload" onclick="DownloadUploadedFileDialouge(this)" style="margin-left: 4px;" title="Download"></span>' +
//        '</div>';
//    }

//    return fileLink;
//}
//function UploadedFileAutoFill(file, path) {
//    debugger;

//    var fullDate = new Date();
//    var twoDigitMonth = fullDate.getMonth() + 1;
//    if (twoDigitMonth.length == 1)
//    { twoDigitMonth = "0" + twoDigitMonth; }
//    var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
//    var currentDate = twoDigitMonth + "/" + twoDigitDate + "/" + fullDate.getFullYear();
//    debugger;
//    //if ($("#txtIntDate").val() == "") { $("#txtIntDate").val(currentDate); }


//    if (typeof (file) != "undefined") {
//        debugger;
//        var filenamereverse = file.substring(0, file.lastIndexOf('.'));

//        $("#txtDocName").val(filenamereverse);
//        $("#txtDocumentName").val(filenamereverse);
//        //$("#txtDocName").val(file);
//        //Change By Syed Sajid Ali Date 7/11/2018
//        var fileformate = $.trim(file.substring(file.length - 3, file.length));


//        fileformate = fileformate.toUpperCase();
//        if ($("#ddlReceivedBy").val() != 0) { }
//        else { $("#ddlReceivedBy").prop('selectedIndex', 4); }


//    }
//    debugger
//    if (fileformate == "PDF")
//        $("#ddlFileFormate").prop('selectedIndex', 2);
//    if (fileformate == "TXT")
//        $("#ddlFileFormate").prop('selectedIndex', 5);
//    if (fileformate == "ZIP")
//        $("#ddlFileFormate").prop('selectedIndex', 1);
//    if (fileformate == "JPG")
//        $("#ddlFileFormate").prop('selectedIndex', 6);
//    if (fileformate == "PEG")
//        $("#ddlFileFormate").prop('selectedIndex', 6);
//    if (fileformate == "PNG")
//        $("#ddlFileFormate").prop('selectedIndex', 6);
//    if (fileformate == "GIF")
//        $("#ddlFileFormate").prop('selectedIndex', 6);
//    if (fileformate == "OCX")
//        $("#ddlFileFormate").prop('selectedIndex', 3);
//    if (fileformate == "LSX")
//        $("#ddlFileFormate").prop('selectedIndex', 4);
//    currentDate = "";
//}


//function uploadfilenew()
//{
//    checkUploadFileLit();
    
   
//    new AjaxUpload('#btnUploadMessageAttachments', {
//        action: '../Settings/Ticketing/CallBacks/AttachmentUploadHandler.ashx',
//        dataType: 'json',
//        contentType: "application/json; charset=uft-8",
       
//        onSubmit: function (file, ext, fileSize) {

//            if ((ext && /^(exe|dll|bat)$/.test(ext))) {
//                showErrorMessage('Error: invalid file extension');
//                return false;
//            }

//            if (fileSize > 10) {
//                showErrorMessage("This file exceeds the 10MB attachment limit.");
//                return false;
//            }

//            var attachmentRow = '<tr class="attachments">';

//            attachmentRow += '<td>';
//            attachmentRow += '<span class="TicketAttachmentId"></span>';
//            attachmentRow += '<span id="spnAttachmentName" class="attachment-name" style="float:left">' + file + '</span>';
//            attachmentRow += '<div id="divProgressBar" style="float:left"><img src="../../Images/progressbar.gif"/> <span onclick="request.abort();">Cancel</span></div>';
//            attachmentRow += '</td>';
//            attachmentRow += '</tr>';

//            $(".tr-upload-file-messages").before(attachmentRow);
//        },
//        onComplete: function (file, response) {
//            debugger

//            var responseHTML = $(response);
//            var r = responseHTML.html();
//            var res = $.parseJSON(r);

//            $(".tr-upload-file-messages").prev().find("#divProgressBar").html('<img src="../../Images/-delete.png" class="attachment-remove" onclick="RemoveAttachmentConfirmation(this);"/>');

//            $("#spnAttachmentName").attr("id", _ResolveUrl + "PracticeDocuments/" + "TicketingDocuments/" + res.path);

//            showSuccessMessage("File Attached Successfully!");
//            $("#attach-link").html("Attach another file");
//            $("#btnUploadMessageAttachments").css("width", "106px");
//            if (checkUploadFileLit() == 4 || checkUploadFileLit() > 4) {
               
//                $("#btnUploadMessageAttachments").hide();
//            }
//        },
        
//    });
//}

//function checkUploadFileLit() {
//    var attachmentlength = $(".attachmentdivside").find(".attachments").length;
//    return attachmentlength;
//}

//function clearform() {
//    $("[id$='ddlTyp']").val("");
//    $("[id$='ddlTRTo']").val("");
//    $("[id$='ddlpri']").val("");
//    $("#txtFormNotesNote").val("");
//    $("#txtDOS").val("");
//    $("[id$='lblTitleNo']").text("");
//    $("#txtPatientId").val("");
//    $(".attachments").remove();
//    $("#btnUploadMessageAttachments").show();

//    $('.required').each(function () {

//        $(this).css("border-color", "#c4c4c4");

//    })
//    $("#btnSaveticket").val("Save");
//}

//function filerPatient()
//{
//    debugger
//    var SearchValue = $("#txtPatientId").val()||"";
//    $.post("../CustomerSupport/CallBacks/GenerateTicketHandler.aspx", { action: "SearchPatient", SearchValue: SearchValue }, function (data) {
//        debugger

//        var start = data.indexOf("###StartPat###") + 18
//        var end = data.indexOf("###EndPat###");
//        var returnHtml = $.trim(data.substring(start, end));
//        $("#searchpatientdiv").html(returnHtml);
//        $(".divpatientsearch").show();

//    });
//}

//function setSearchePatient(elem) {
//    debugger
//    var a = event.which || event.keyCode;
//    if (a == 13) {
//        debugger
//        filerPatient();
//    }
//}
//function selectPatientName(Name,id)
//{
//    var selectedvalue = Name;
//     patid = id;
//     $("#txtPatientId").val(selectedvalue);
//     $(".divpatientsearch").hide();
//}
//function closeiconxbuttonFunc()
//{
//    $("#txtPatientId").val("");
//    $(".divpatientsearch").hide();
//    patid = 0;
//}
//function RemoveAttachmentConfirmation(elem) {
//    debugger;


//    $.post("../CustomerSupport/CallBacks/GenerateTicketHandler.aspx", { action: "conformation" }, function (data) {
//        debugger;
//        var start = data.indexOf("###StartConformationDialog###") + 30;
//        var end = data.indexOf("###EndConformationDialog###");
//        var returnHtml = $.trim(data.substring(start, end));
//        $("#Conformationdialog").html(returnHtml);
//        $("#Conformationdialog").dialog({
//            width: 300,
//            height: 130,
//            modal: true,
//            title: "Confirmation!",


//            open: function () {
//                $(".ui-widget-overlay").last().css("z-index", "9999999");
//                $(".ui-dialog").last().css("z-index", "9999999");
//            },
//            buttons: {

//                "Yes": function () {

//                    $(this).dialog("destroy");
//                    debugger;
//                    RemoveAttachment(elem);
//                    $("#Conformationdialog").hide();

//                },
//                "No": function () {
//                    $(this).dialog("destroy");
//                    $("#Conformationdialog").hide();
//                }
//            },
//            close: function () {
//                $(this).dialog("destroy");
//                $("#Conformationdialog").hide();
//            }
//        });
//    }).done(function () {

//        $("#messageTciket").css("display", "none");

//    });
//}
//function RemoveAttachment(elem) {
//    debugger;
   
//    var TicketAttachmentId = $(elem).closest("tr").find('.TicketAttachmentId').val() || 0;
//    $(elem).closest("tr").remove();

//    if (TicketAttachmentId != 0)
//    {
//        DeleteAttachmentFromDB(TicketAttachmentId);
//    }


//   if (checkUploadFileLit() < 4) {

//        $("#btnUploadMessageAttachments").show();
//    }
//   showSuccessMessage("Attachment deleted Successfully!");
//}
//function DeleteAttachmentFromDB(TicketAttachmentId)
//{
//    $.post("../CustomerSupport/CallBacks/GenerateTicketHandler.aspx", { action: "DeleteAttachmentFromDB", TicketAttachmentId: TicketAttachmentId }, function (data) { });
//}

////function DeleteTicket(TicketId) {
////    var message = "";
////    message = "Do you want to Delete this Ticket?"
////    $('<div></div>').appendTo('body')
////           .html('<div><h5></h5>' + message + '</div>')
////           .dialog({
////               modal: true, title: 'Confirmation!', zIndex: 10000, autoOpen: true,
////               width: '300px', resizable: false,
////               buttons: {
////                   Yes: function () {
////                       $(this).dialog("close");
////                       DeleteThisTicket(TicketId);
////                       FilterGenTickets(0, true)
////                   },
////                   No: function () {
////                       $(this).dialog("close");
////                   }
////               },
////               close: function (event, ui) {
////                   $(this).remove();
////               }
////           });
////}

function DeleteThisTicket(_ID)
{
    debugger;
    let a = _ID;
    $.post("../CustomerSupport/CallBacks/GenerateTicketHandler.aspx", { action: "DeleteTicketFromDB", TicketId: _ID }, function (data) {

        showSuccessMessage("Ticket Deleted Successfully");
        FilterGenTickets(0, true);
        closediv();
    });
}

function ValidateFormCustomerSupport(formId) {
    debugger
    var flag = true;
   $("#" + formId).find('.required').each(function () {
       
        if (($.trim($(this).val()) == "" || $(this).val() == 0)) {
            debugger
            $(this).css("border-color", "red");
            flag = false;
        }
        else {
            $(this).css("border-color", "#c4c4c4");
           
        }
   });

   return flag;
}
function setSearcheFilter(elem)
{
    var a = event.which || event.keyCode;
    if (a == 13) {
        debugger
        FilterGenTickets(0, true);
    }
}


function AddQuery() {
   
    if (!ValidateForm('GenticketDialogue')) {

        showErrorMessage("Fill out the form carefully");
        return;
    }
    debugger
   
    var datefrom = $("[id$='Date1']").val() || "";
    var dateto = $("[id$='Date2']").val() || "";
    var objAddQuery = new Object();
    objAddQuery.CustomerSupportQuryId = _CustomerSupportQuryId;
    objAddQuery.StatusId = 0;
    objAddQuery.CustomerSupportModuleTypeId = $("[id$='txtCustomerSupportModuleTypeId']").val();
    objAddQuery.QueryQuestion = $("[id$='txtQueryQuestion']").val();
    objAddQuery.QueryAnswer = $("[id$='txtQueryAnswer']").val();


   
    $.post("../CustomerSupport/CustomerQueryHandler.aspx", { objAddQuery: JSON.stringify(objAddQuery), Action: "SaveQuery", 
        QueryId: _CustomerSupportQuryId, datefrom: datefrom, dateto: dateto
    }, function (data) {
        if (_CustomerSupportQuryId == 0) {
            showSuccessMessage("Ticket saved successfully!");
        }
        else {
            showSuccessMessage("Ticket Update successfully!");
        }
             $("#maindiv1").show();
             $("#embeddiv").hide();
             $("#embdiv").hide();
             $("#GenticketDialogue").hide();



            Filter();
            CancelQuery();

    });
}
function ViewQueryData(elem, Id) {
    debugger;

   
    _CustomerSupportQuryId = Id;



    ViewTicket(elem, Id);


}
function CancelQuery()
{
    debugger
    $("[id$='txtCustomerSupportModuleTypeId']").val(0);
    $(".statusSpan").html("");
    $(".statusSpan").html("Open");
    $("#txtQueryQuestion").val("");
    $("#txtQueryAnswer").val("");
    _CustomerSupportQuryId = 0;

    $("[id$='txtCustomerSupportModuleTypeId']").removeClass('error');
    $("#txtQueryQuestion").removeClass('error');

}
function RefreshTabs() {
   debugger
    var datefrom = $("[id$='Date1']").val()||"";
    var dateto = $("[id$='Date2']").val() || "";

    if (datefrom == "" && dateto == "") {
        $("[id$='Date1']").closest(".textbox").css("border-color", "red");
        $("[id$='Date2']").closest(".textbox").css("border-color", "red");
        showErrorMessage("Please select Date From and Date To");
        return;
    }
       else if (datefrom == "") {
        showErrorMessage("Please select Date From ");
        $("[id$='Date1']").closest(".textbox").css("border-color","red");

        return;
    }
    else if (dateto == "") {
        showErrorMessage("Please select Date To");
        $("[id$='Date2']").closest(".textbox").css("border-color", "red");
        return;
    }
  

    else {
      
        $("[id$='Date1']").closest(".textbox").css("border-color", "#25a5fe");
        $("[id$='Date2']").closest(".textbox").css("border-color", "#25a5fe");
    }
    if (new Date(dateto) < new Date(datefrom)) {
        showErrorMessage("Date To should be greater than Date From");
        return;
    }

    $.post("../CustomerSupport/CustomerQueryHandler.aspx", { Action: "RefreshTabs", DateFrom: datefrom, DateTo: dateto }, function (data) {
        debugger
        var start = data.indexOf("###SPGrid###") + 14
        var end = data.indexOf("###EPGrid###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#TbodySupport").html(returnHtml);

        var Toatl = $("[id$='hdnTotalTicketsCount']").val();
        var opent = $("[id$='hdnTotalTicketsOpen']").val();
        var closet = $("[id$='hdnTotalTicketsClose']").val();
        var InProcess = $("[id$='hdnTotalTicketsUnderReview']").val();
        var ProviderReview = $("[id$='hdnTotalTicketsUnderReview']").val();

        
        $("[id$='TotalTicketsCount']").text(Toatl);
        $("[id$='TotalTicketsOpen']").text(opent);
        $("[id$='TotalTicketsClose']").text(closet);
        $("[id$='TotalTicketsInProcess']").text(InProcess);
        $("[id$='TotalTicketsProviderreview']").text(ProviderReview);

        document.getElementById("chart1").innerHTML = '&nbsp;';
        document.getElementById("chart1").innerHTML = ' <canvas id="pie-chart1"></canvas>   ';
        var ctx1 = document.getElementById("pie-chart1").getContext("2d");

        new Chart(ctx1, {
            type: 'pie',

            data: {
                responsive: false,

                labels: ["Opne", "Close","InProcess", "Provider Review"],
                datasets: [{
                    label: "Population (millions)",
                    backgroundColor: ['#006291', '#ff8200', 'red','green'],
                    data: [opent, closet, InProcess, ProviderReview]
                }]
            },
            options: {
                legend: {
                    display: false
                },


            },

        });

    });
}
function Filter() {
    debugger
    var datefrom = $("[id$='Date1']").val() || "";
    var dateto = $("[id$='Date2']").val() || "";

    
    $.post("../CustomerSupport/CustomerQueryHandler.aspx", { Action: "RefreshTabs", DateFrom: datefrom, DateTo: dateto }, function (data) {
        debugger
        var start = data.indexOf("###SPGrid###") + 14
        var end = data.indexOf("###EPGrid###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#TbodySupport").html(returnHtml);

        var Toatl = $("[id$='hdnTotalTicketsCount']").val();
        var opent = $("[id$='hdnTotalTicketsOpen']").val();
        var closet = $("[id$='hdnTotalTicketsem']").val();
        var UnderReviewt = $("[id$='hdnTotalTicketsUnderReview']").val();


        $("[id$='TotalTicketsCount']").text(Toatl);
        $("[id$='TotalTicketsOpen']").text(opent);
        $("[id$='TotalTicketsClose']").text(closet);
        $("[id$='TotalTicketsUnderReview']").text(UnderReviewt);

        document.getElementById("chart1").innerHTML = '&nbsp;';
        document.getElementById("chart1").innerHTML = ' <canvas id="pie-chart1"></canvas>   ';
        var ctx1 = document.getElementById("pie-chart1").getContext("2d");

        new Chart(ctx1, {
            type: 'pie',

            data: {
                responsive: false,

                labels: ["Opne", "Close", "Under Review"],
                datasets: [{
                    label: "Population (millions)",
                    backgroundColor: ['#006291', '#ff8200', 'red'],
                    data: [opent, closet, UnderReviewt]
                }]
            },
            options: {
                legend: {
                    display: false
                },


            },

        });

    });
}
debugger
function closeEmbedOpenmainPage()
{
   
    window.location.href = "../../ProviderPortal/CustomerSupport/Support.aspx";
}

var _ID = "";
function GenerateTicket(Id) {

    debugger;
    $(".maindiv").html("");
    $(".maindiv").hide();
   if (Id == null) {
    
   } else {
       var QueryId = Id.trim();
       _ID = QueryId;
   }
   
    $.post(_EMRPath + "/CustomerSupport/CallBacks/CustomerSupportProviderView.aspx", { QueryId: QueryId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartModel###") + 16;
            var end = data.indexOf("###EndModel###");
            $(".hidediv").html(returnHtml.substring(start, end));
       $(".hidediv").css("display", "block");
       if (Id == null) {
           $("[id$='ddlallticket']").prop("disabled", "disabled");

       } else {
           $(".hide").hide();
           initChat(Id);
       }
       attachupload();
       
        });
}
//sar
function ddlAllTicket() {
   
    var Id = $("[id$='ddlallticket']").val();
    
    GenerateTicket(Id);
                                         
}

function ViewTicket(elem, Id) {
    debugger
    $("#maindiv1").hide();
    


    $.post(_EMRPath + "/CustomerSupport/GenerateTicketForm.aspx", function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartModel###") + 16;
        var end = data.indexOf("###EndModel###");
        $("#embeddiv").html(returnHtml.substring(start, end));
        $("#GenticketDialogue").show();
        $("#embeddiv").show();
        $("#embeddiv").css("width","65%")
        $(".anotherclass").hide();
        $("#embdiv").show();


        if (Id == null) {

        }
        else {
            var value = $.trim($(elem).closest("tr").find('td').eq(1).text()) || 0;
           
            $(".statusSpan").html("");
            $(".statusSpan").text($.trim($(elem).closest("tr").find('td').eq(2).text())).attr('disabled', 'disabled').css("cursor", "not-allowed");
            $("[id$='txtCustomerSupportModuleTypeId']").attr('disabled', 'disabled').css("cursor", "not-allowed");
            $("[id$='txtCustomerSupportModuleTypeId']").find("option:contains(" + value + ")").attr('selected', 'selected');
            debugger;
            

            $("#txtQueryQuestion").val($.trim($(elem).closest("tr").find('td').eq(3).attr('title'))).attr('disabled', 'disabled').css("cursor", "not-allowed");
          
            $("#txtQueryAnswer").val($.trim($(elem).closest("tr").find('td').eq(4).attr('title'))).attr('disabled', 'disabled').css("cursor", "not-allowed");

            $("#RefreshDates3").prop("disabled", true).css("cursor", "not-allowed");
        }
        $("#ticket").text("View Ticket");
    });








}

function closediv(){

  //  href="/ProviderPortal/CustomerSupport/Support.aspx";

    window.location.href = "../../ProviderPortal/CustomerSupport/Support.aspx";

    $(".hidediv").hide();
    $(".maindiv").show();
   

   // $(".maindiv").html("");
   // $(".maindiv").hide();
}
function Email() {

    $("#maindiv1").hide();
    

    $.post(_EMRPath + "/CustomerSupport/SendMessage.aspx", function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartModel###") + 16;
        var end = data.indexOf("###EndModel###");
        $("#embeddiv").html(returnHtml.substring(start, end));
       
        $("#embeddiv").show();


    });
}
function TotalTicket() {
    debugger
    var datefrom = $("[id$='Date1']").val() || "";
    var dateto = $("[id$='Date2']").val() || "";
    $("[id$='Label1']").text("TotalTicket");
    

    $.post("../CustomerSupport/CustomerQueryHandler.aspx", { Action: "AllTicket", DateFrom: datefrom, DateTo: dateto }, function (data) {
        debugger
        var start = data.indexOf("###SPGrid###") + 14
        var end = data.indexOf("###EPGrid###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#TbodySupport").html(returnHtml);
        $('[id$="ddlstatussearch"]').val("");
        FilterGenTickets(0, true);

    })
}
function CloseTicket() {
    debugger
    //var datefrom = $("[id$='Date1']").val() || "";
    //var dateto = $("[id$='Date2']").val() || "";
    var TicketType = 2;
    $("[id$='Label1']").text("CloseTicket");
    

    $.post("../CustomerSupport/CustomerQueryHandler.aspx", { Action: "CloseTicket", TicketType: TicketType }, function (data) {
        debugger
        var start = data.indexOf("###SPGrid###") + 14
        var end = data.indexOf("###EPGrid###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#TbodySupport").html(returnHtml);
        $('[id$="ddlstatussearch"]').val("8");
        FilterGenTickets(0, true);
    })
}
function OpenTicket() {
    debugger
    var datefrom = $("[id$='Date1']").val() || "";
    var dateto = $("[id$='Date2']").val() || "";
    var TicketType = 1;
    $("[id$='Label1']").text("OpenTicket");


    $.post("../CustomerSupport/CustomerQueryHandler.aspx", { Action: "OpenTicket", DateFrom: datefrom, DateTo: dateto, TicketType: TicketType }, function (data) {
        debugger
        var start = data.indexOf("###SPGrid###") + 14
        var end = data.indexOf("###EPGrid###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#TbodySupport").html(returnHtml);
        $('[id$="ddlstatussearch"]').val("1");
        FilterGenTickets(0, true);
    })
}
function InProcess() {
    debugger
    var datefrom = $("[id$='Date1']").val() || "";
    var dateto = $("[id$='Date2']").val() || "";
    var TicketType = 6;
    $("[id$='Label1']").text("UnderreviewTicket");


    $.post("../CustomerSupport/CustomerQueryHandler.aspx", { Action: "InProcess", DateFrom: datefrom, DateTo: dateto, TicketType: TicketType }, function (data) {
        debugger
        var start = data.indexOf("###SPGrid###") + 14
        var end = data.indexOf("###EPGrid###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#TbodySupport").html(returnHtml);
        $('[id$="ddlstatussearch"]').val("2");
        FilterGenTickets(0, true);
    })
}
function ProviderReview() {
    debugger
    var datefrom = $("[id$='Date1']").val() || "";
    var dateto = $("[id$='Date2']").val() || "";
    var TicketType = 8;
    $("[id$='Label1']").text("UnderreviewTicket");


    $.post("../CustomerSupport/CustomerQueryHandler.aspx", { Action: "ProviderReview", DateFrom: datefrom, DateTo: dateto, TicketType: TicketType }, function (data) {
        debugger
        var start = data.indexOf("###SPGrid###") + 14
        var end = data.indexOf("###EPGrid###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#TbodySupport").html(returnHtml);
        $('[id$="ddlstatussearch"]').val("6");
        FilterGenTickets(0, true);
    })
}

// file attachment

function attachupload() {
    $("#fileuploader").on('change', function () {
        debugger;
        let formdata = new FormData();
        let filehandler = $(this).get(0);

        let files = filehandler.files;
        for (let i = 0 ; i < files.length; i++) {
            let ext = files[0].name.split('.');
            ext = ext[ext.length-1];
            let validFormat = ['pdf', 'png', 'jpg', 'txt', 'doc', 'docx', 'xls'];
            if (validFormat.filter((e) => ext == e).length <= 0) {
                filehandler.value = null;
               showErrorMessageCustome('Invalid file format');

            return false;
              }
            if (files[0].size > 2000.63556480407715) {
                filehandler.value = null;
                showErrorMessageCustome("This file exceeds the 2GB attachment limit.", "Attachment Limit");
              return false;
                }
            formdata.append(files[i].name,files[i]);
        }
        if (files.length > 0) {
            let http = new XMLHttpRequest();
            http.open('post', 'CallBacks/FileHandler.ashx', true);
            http.onload = function (e) {
                if (http.status == 200 && http.readyState == 4) {
                    let resp = JSON.parse(http.response);
                    $('#filename').val(resp.fileName);
                    $('#filepath').val(resp.path);
                }
            }
            http.send(formdata);
        }
    })
}


//function attachupload() {
//    new AjaxUpload('#fileuploader', {
//        action: 'CallBacks/FileHandler.ashx',
//        dataType: 'text/plain',
//        contentType: "application/json; charset=uft-8",
//        onSubmit: function (file, ext, fileSize) {
//            debugger;
//            let validFormat = ['pdf', 'png', 'jpg', 'txt', 'doc', 'docx', 'xls'];
//            if (validFormat.filter((e) => ext == e).length <= 0) {
//                showErrorMessageCustome('Invalid file format');
//                return false;
//            }
//            if (fileSize > 2000.63556480407715) {
//                showErrorMessageCustome("This file exceeds the 2GB attachment limit.", "Attachment Limit");
//                return false;
//            }
//        },
//        onComplete: function (file, response) {
//            debugger;
//            var responseHTML = $.parseJSON($(response).html());
//            $('#filename').val(responseHTML.fileName);
//            $('#filepath').val(responseHTML.path);
//            //AppendUploadedFile(responseHTML.fileName, responseHTML.path, file);
//        }
//    })
//}