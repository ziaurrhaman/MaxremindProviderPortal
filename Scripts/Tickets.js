// Start File Added By Rizwan kharal 13April2018
//All Changes By Syed Sajid Ali Date:10-11-2018


function JumpToPageNo(event) {
    debugger;
    var a = event.which || event.keyCode;
    if (a == 13) {
        location.reload();
    }
    var pageNumber = $("[id$='txtReportPageNumber']").val();
    pageNumber--;
    FilterReportList(pageNumber);
}



function OpenTicketingForm()
{
    debugger;
    $("#title").html("");
    $("#title").text("Ticketing");
    $("#divRightsSettings").hide();
    $(".contents-details-header").html('Ticketing');
    $("#divUsersMain").hide();
    $("#divInsuranceCredentialingWrapperId").hide();
    $("#divInsuranceEnrollment").hide();
    $("#divTicketing").show();
    $("#divTicketing").html("");
    $("[id$='UserRolesDiv']").hide();
    $.post("../Settings/Ticketing/Tickets.aspx", function (data) {
        debugger;
        var start = data.indexOf("###StartTicketForm###") + 30
        var end = data.indexOf("###EndTicketForm###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divTicketing").html(returnHtml);
      
    });
}

function OpenSaveTicketsForm()
{

    debugger;
    $.post("../Settings/Ticketing/Callbacks/TicketsHandler.aspx",{action:"OpenSaveForm"}, function (data) {
      
        var start = data.indexOf("###Start###") + 15;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divAddTickets").html(returnHtml);
        $("#divAddTickets").dialog({
            width: 700,
            //height: 700,
            modal: true,
            title: "Add Tickets",


            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "9999999");
            },
            buttons: {
                "Save": function () {
                    debugger
                    SaveTicketsData();
                 
                },
                "Cancel": function () {
                    $(this).dialog("destroy");
                    $("#divTicketsHandler").hide();
                }
            },
            close: function () {
                $(this).dialog("destroy");
                $("#divTicketsHandler").hide();
            }
        });
    });
}

function SaveTicketsData()
{
    debugger
    var title = $("[id$='TxtTitle']").val();
    var category = $("[id$='txtCategory'] option:selected").text();
    var priority = $("[id$='txtPriority'] option:selected").text();
    var status = $("[id$='txtStatus'] option:selected ").text();
    var description = $("[id$='TxtDescription']").val();


    if (title == "")
    {
        $("[id$='TxtTitle']").css("border-color", "red");
        showErrorMessage("Error: Please review the form carefully for the errors.");
        return;
    }

    var attachmentList = new Array();
    $(".attachment-name").each(function () {
        debugger
        var objAttachment = new Object();
        objAttachment.FileName = $.trim($(this).html());
        objAttachment.AttachmentPath = $(this).attr("id");
        attachmentList.push(objAttachment);
    });

    if (attachmentList == "") {
       
        showErrorMessage("Error: Please Add atleast 1 attachment");
        return;
    }
    var objTicketing = new Object();
    objTicketing.Title = title;
    objTicketing.Category = category;
    objTicketing.Priority = priority;
    objTicketing.Status = status;
    objTicketing.Description = description;
    $.post("../Settings/Ticketing/CallBacks/TicketsHandler.aspx", { TicketData: JSON.stringify(objTicketing), attachmentList: JSON.stringify(attachmentList), action: "SaveTicketsData", PageNumber: "0" ,Rows:"10"}, function (data) {

        debugger
        var start = data.indexOf("###StartHandler###") + 30
        var end = data.indexOf("###EndHandler###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbody").html(returnHtml);
        
        GeneratePaging($("[id$='hdnTicketsTotalRows']").val(), $("#ddlPagingTickets").val(), "divTicketing", "FilterReportList");
        if ($("[id$='hdnTicketsTotalRows']").val() > 0) {
            $("#divTicketing .spanInfo").html("Showing " + $(".TicketBody tr:first").children().first().html() + " to " + $(".TicketBody tr:last").children().first().html() + " of " + $("[id$='hdnTicketsTotalRows']").val() + " entries");
        }

    }).done(function () {
        showSuccessMessage("Record Saved successfully");
        $("[id$='divAddTickets']").dialog("destroy");
        $("#divTicketsHandler").hide();
    });
}

function FilterReportList(pageNumber, paging) {
    debugger;
    var params = {
        TicketId: $.trim($("[id$='txtTicketId']").val()),
        Category: $("[id$='txtCategory']").val(),
        ReportedOn: $("[id$='TxtReportedOn']").val(),
        Piriority: $("[id$='txtPiriority']").val(),
        Status: $("[id$='txtStatus']").val(),
        Title: $("[id$='TxtTitleSearch']").val(),
        Description: $("[id$='TxtDescriptionSearch']").val(),
        ReportedBy: $("[id$='TxtReportedBy']").val(),

        Rows: $("#ddlPagingTickets").val(),
        PageNumber: pageNumber,
        //SortBy: _SortBy + " " + _SortByValue,
        SortBy: "TicketId desc",

        action: "Filter"
    };

    var actionPage = "TicketsHandler.aspx";

    FilterTicketData(actionPage, params, paging);
}

function FilterTicketData(actionPage, params, paging) {
    debugger;
    $.post("../Settings/Ticketing/CallBacks/" + actionPage, params, function (data) {
        debugger;
        var start = data.indexOf("###StartHandler###") + 30
        var end = data.indexOf("###EndHandler###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbody").html(returnHtml)
        .promise()
        .done(function () {
            debugger;
            if (paging == true) {
                GeneratePaging($("[id$='hdnTicketsTotalRows']").val(), $("#ddlPagingTickets").val(), "divTicketing", "FilterReportList");
            }          
            if ($("[id$='hdnTicketsTotalRows']").val() > 0) {
                $("#divTicketing .spanInfo").html("Showing " + $(".TicketBody tr:first").children().first().html() + " to " + $(".TicketBody tr:last").children().first().html() + " of " + $("[id$='hdnTicketsTotalRows']").val() + " entries");
            }
        });
    });
}

function TicketDetails(TicketId) {
    debugger;

    $.post("../Settings/Ticketing/CallBacks/TicketsHandler.aspx", { action: "Ticketsdetail", TicketId: TicketId }, function (data) {
      
        var start = data.indexOf("###Start###") + 15;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divAddTickets").html(returnHtml);
        $("#divAddTickets").dialog({
            width: 600,
            //height: 700,
            modal: true,
            title: "Ticket Details",


            open: function () {
                //$(".ui-widget-overlay").last().css("z-index", "9999999");
                //$(".ui-dialog").last().css("z-index", "9999999");
            },
            buttons: {
                "Edit": function () {

                    
                    $("[id$='txtCategory']").css("display", "block");
                    $("[id$='txtPriority']").css("display", "block");
                    $("[id$='txtStatus']").css("display", "block");
                    UpdateDialog(TicketId);
                },
                "Delete": function () {
                    debugger;
                    DeleteConfirmation(TicketId, 'divAddTickets');
                    $("[id$='txtCategory']").css("display", "block");
                    $("[id$='txtPriority']").css("display", "block");
                    $("[id$='txtStatus']").css("display", "block");
                },
                "Cancel": function () {
                  $(this).dialog("destroy");
                  $("#divAddTickets").hide();
                  $("[id$='txtCategory']").css("display", "block");
                  $("[id$='txtPriority']").css("display", "block");
                  $("[id$='txtStatus']").css("display", "block");
                }
            },
            close: function () {
                $(this).dialog("destroy");
                $("#divAddTickets").hide();
            }
        });
    }).done(function () {
        $("[id$='TxtTitle']").css("display", "none");
        $("[id$='txtCategory']").css("display", "none");
        $("[id$='txtPriority']").css("display", "none");
        $("[id$='txtStatus']").css("display", "none");
        $("[id$='TxtDescription']").css("display", "none");
        $("#uploadAttachFile").css("display", "none");
          
        $("[id$='lblTitle']").css("display", "block");
        $("[id$='lblCategory']").css("display", "block");
        $("[id$='lblPriority']").css("display", "block");
        $("[id$='lblStatus']").css("display", "block");
        $("[id$='lblDescription']").css("display", "block");

        $(".attachment-remove").css("display", "none");

    });
}

function DeleteConfirmation(TicketId, divAddTickets) {
    debugger;
    
  
    $.post("../Settings/Ticketing/CallBacks/TicketsHandler.aspx", { action: "conformation" }, function (data) {
        debugger;
        var start = data.indexOf("###StartConformationDialog###") + 30;
        var end = data.indexOf("###EndConformationDialog###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#Conformationdialog").html(returnHtml);
        $("#Conformationdialog").dialog({
            width: 300,
            height: 130,
            modal: true,
            title: "Confirmation!",


            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                
                "Yes": function () {
                    $("[id$='divAddTickets']").dialog("destroy");
                    $(this).dialog("destroy");
                    DeleteTicket(TicketId);
                    $("#Conformationdialog").hide();
                    $("#divTicketsHandler").hide();
                },
                "No": function () {
                    $(this).dialog("destroy");
                    $("#Conformationdialog").hide();
                    $("[id$='txtCategory']").css("display", "none");
                    $("[id$='txtPriority']").css("display", "none");
                    $("[id$='txtStatus']").css("display", "none");
                }
            },
            close: function () {
                $(this).dialog("destroy");
                $("#Conformationdialog").hide();
                $("[id$='txtCategory']").css("display", "none");
                $("[id$='txtPriority']").css("display", "none");
                $("[id$='txtStatus']").css("display", "none");
            }
        });
    }).done(function () {
        $("#messageAttachment").css("display", "none");
    });
}


function DeleteTicket(TicketId)
{
   
    var PageNumber = $("#divTicketing .current b").val();
    PageNumber--;
    var Rows = $("#ddlPagingTickets").val();
    $.post("../Settings/Ticketing/CallBacks/TicketsHandler.aspx", {
        TicketId: TicketId,
        action: "DeleteTicket",
        PageNumber: PageNumber,
        Rows: Rows
    }, function (data) {

        debugger
        var start = data.indexOf("###StartHandler###") + 30
        var end = data.indexOf("###EndHandler###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbody").html(returnHtml);

        GeneratePaging($("[id$='hdnTicketsTotalRows']").val(), $("#ddlPagingTickets").val(), "divTicketing", "FilterReportList");
        if ($("[id$='hdnTicketsTotalRows']").val() > 0) {
            $("#divTicketing .spanInfo").html("Showing " + $(".TicketBody tr:first").children().first().html() + " to " + $(".TicketBody tr:last").children().first().html() + " of " + $("[id$='hdnTicketsTotalRows']").val() + " entries");
        }

    }).done(function () {
        showSuccessMessage("Ticket Deleted successfully");
       
      

    });
}

function UpdateDialog(TicketId)
{
    debugger;
    $.post("../Settings/Ticketing/Callbacks/TicketsHandler.aspx", { action: "UpdateTicketDialog", TicketId: TicketId }, function (data) {

        var start = data.indexOf("###Start###") + 15;
        var end = data.indexOf("###End###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divAddTickets").html(returnHtml);
        $("#divAddTickets").dialog({
            width: 700,
            //height: 700,
            modal: true,
            title: "Update Tickets",


            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Update": function () {
                    debugger
                    UpdateTicket(TicketId);
                  
                },
                "Cancel": function () {
                    $(this).dialog("destroy");
                    $("#divTicketsHandler").hide();
                }
            },
            close: function () {
                $(this).dialog("destroy");
                $("#divTicketsHandler").hide();
            }
        });
    });
}

function UpdateTicket(TicketId)
{
    debugger
    var title = $("[id$='TxtTitle']").val();
    var repeaterTr = $.trim($("#rpt_tr").html());
    var category = $("[id$='txtCategory'] option:selected").text();
    var priority = $("[id$='txtPriority'] option:selected").text();
    var status = $("[id$='txtStatus'] option:selected ").text();
    var description = $("[id$='TxtDescription']").val();

    if (title == "") {
        $("[id$='TxtTitle']").css("border-color", "red");
        showErrorMessage("Error: Please review the form carefully for the errors.");
        return;
    }


    var attachmentList = new Array();
    $(".attachment-name").each(function () {
        var objAttachment = new Object();
        objAttachment.FileName = $.trim($(this).html());
        objAttachment.AttachmentPath = $(this).attr("id");
        attachmentList.push(objAttachment);
    });

   
    if (attachmentList == "" && repeaterTr=="") {
       showErrorMessage("Error: Please Add atleast 1 attachment");
        return;
    }

    var objTicketing = new Object();
    objTicketing.Title = title;
    objTicketing.Category = category;
    objTicketing.Priority = priority;
    objTicketing.Status = status;
    objTicketing.Description = description;

    var PageNumber = $("#divTicketing .current b").html();
    PageNumber--;
    var Rows = $("#ddlPagingTickets").val();
    $.post("../Settings/Ticketing/CallBacks/TicketsHandler.aspx", { TicketData: JSON.stringify(objTicketing), attachmentList: JSON.stringify(attachmentList), action: "UpdateTicket", TicketId: TicketId, PageNumber: PageNumber,Rows:Rows }, function (data) {

     
        var start = data.indexOf("###StartHandler###") + 30
        var end = data.indexOf("###EndHandler###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbody").html(returnHtml);

        GeneratePaging($("[id$='hdnTicketsTotalRows']").val(), $("#ddlPagingTickets").val(), "divTicketing", "FilterReportList");
        if ($("[id$='hdnTicketsTotalRows']").val() > 0) {
            $("#divTicketing .spanInfo").html("Showing " + $(".TicketBody tr:first").children().first().html() + " to " + $(".TicketBody tr:last").children().first().html() + " of " + $("[id$='hdnTicketsTotalRows']").val() + " entries");
        }

    }).done(function () {
        showSuccessMessage("Record Updated successfully");
        $("[id$='divAddTickets']").dialog("destroy");
        $("#divTicketsHandler").hide();
     
    });
}

function RemoveAttachmentConfirmation(elem) {
    debugger;


    $.post("../Settings/Ticketing/CallBacks/TicketsHandler.aspx", { action: "conformation" }, function (data) {
        debugger;
        var start = data.indexOf("###StartConformationDialog###") + 30;
        var end = data.indexOf("###EndConformationDialog###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#Conformationdialog").html(returnHtml);
        $("#Conformationdialog").dialog({
            width: 300,
            height: 130,
            modal: true,
            title: "Confirmation!",


            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "9999999");
            },
            buttons: {

                "Yes": function () {
                    
                    $(this).dialog("destroy");
                    debugger;
                    RemoveAttachment(elem);
                    $("#Conformationdialog").hide();
                
                },
                "No": function () {
                    $(this).dialog("destroy");
                    $("#Conformationdialog").hide();
                }
            },
            close: function () {
                $(this).dialog("destroy");
                $("#Conformationdialog").hide();
            }
        });
    }).done(function () {
       
        $("#messageTciket").css("display", "none");
       
    });
}
function RemoveAttachment(elem) {
    debugger;
    var AttachmentId = $("#divTicketing .current b").val();

   if (AttachmentId == "" || AttachmentId==null)
   {
       $(elem).closest("tr").remove();
       showSuccessMessage("Success: Attachment deleted.");
       return;
   }

   else {
       var PageNumber = $("[id$='txtReportPageNumber']").val();
       PageNumber--;
       var Rows = $("#ddlPagingTickets").val();
       $.post("../Settings/Ticketing/CallBacks/TicketsHandler.aspx", { AttachmentId: AttachmentId, action: "RemoveAttachment", PageNumber: PageNumber,Rows:Rows }, function (data) {

           debugger
           var start = data.indexOf("###StartHandler###") + 30
           var end = data.indexOf("###EndHandler###");
           var returnHtml = $.trim(data.substring(start, end));
           $("#tbody").html(returnHtml);

           GeneratePaging($("[id$='hdnTicketsTotalRows']").val(), $("#ddlPagingTickets").val(), "divTicketing", "FilterReportList");
           if ($("[id$='hdnTicketsTotalRows']").val() > 0) {
               $("#divTicketing .spanInfo").html("Showing " + $(".TicketBody tr:first").children().first().html() + " to " + $(".TicketBody tr:last").children().first().html() + " of " + $("[id$='hdnTicketsTotalRows']").val() + " entries");
           }

       }).done(function () {
           showSuccessMessage("Success: Attachment deleted.");
           $(elem).closest("td").remove();
       });
   }
  
}
$(function () {
    $("[id$='TxtReportedOn']").datepicker({
        changeMonth: true,
        changeYear: true,
    });
});

function SetSearch(event) {
    debugger;
    var a = event.which || event.keyCode;

    if (a == 13)
    {
        // if ($("#FilterIcon").hasClass("active")) {
        debugger;
        FilterReportList(0, true);
        //}
    }
    else {
        $("#FilterIcon").addClass("active");
    }

}
function showSuccessMessage(message) {
    $(".divMesg").stop().fadeOut();
    $(".divMesg").html(message).removeClass("warning").addClass("success").fadeIn(2000).fadeOut(10000);
}

function showErrorMessage(mesg) {
    $(".divMesg").stop().fadeOut();
    if (mesg != "") {
        $(".divMesg").html(mesg).removeClass("success").addClass("warning").fadeIn(2000).fadeOut(10000);
    } else {
        $(".divMesg").html("Error: Please review the form carefully for the errors.").removeClass("success").addClass("warning").fadeIn(2000).fadeOut(10000);
    }
}
function SetPendingViewDocuments21(id, Name, path) {
    debugger;
    var fileLink;
    var DocumentHtml = "";

    $("#divDialogDocuments_Viewer").html("");


    var fileName = Name;
    var filePath = path;

    DocumentHtml = '<div class="patient-document-files-wrapper">' +
                        GetFileLink(fileName, filePath) +
                        '<input type="hidden" class="hdnDocumentId" value="0" />' +
                        '<input type="hidden" class="hdnDocumentPath" value="' + filePath + '" />' +
                        '<input type="hidden" class="hdnOriginalFileName" value="' + fileName + '" />' +
                        '<input type="hidden" class="hdnDeleted" value="false" />' +
                    '</div>';

    //fileLink = GetFileLink(fileName, filePath);
  
    

    $("#divDialogDocuments_Viewer").append(DocumentHtml);
    //$(".spndelete").css("display", "none");


    $("#divDialogDocuments_Viewer").dialog({
        title: "View Documents",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "9999999");
        },
        modal: true,

        width: $(window).width() - 50,
        //minHeight: ($(window).height() + 50),
        position: { my: "top", at: "top", of: window }
    });
}
var arrFileTypes = ["jpg", "jpeg", "png", "gif", "bmp", "webp"];
function GetFileLink(file, path) {

    debugger;
    var fileLink = "";
    UploadedFileAutoFill(file, path);

    var fileType = $.trim(file.substring(file.length - 3, file.length));
    if (file != "" || path != "") {
        fileType = fileType.toLocaleLowerCase();
    }
    if ($.inArray(fileType, arrFileTypes) < 0) {
        if (fileType == "pdf") {
            fileLink = '' +
            '<embed src="' + path + '" width="600" height="500" alt="pdf">' +
            '<div class="hover-action-div">' +
                '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
                '<span class="spndownload" onclick="DownloadUploadedFileDialouge(this)" style="margin-left: 4px;" title="Download"></span>' +
            '</div>';
        }
        else {
            fileLink = '' +
            '<a href="' + path + '" style="float: left; color: #00F; margin: 0 5px 0 0;" target="_blank">' + file + '</a>' +
            '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
            '<span class="spndownload" onclick="DownloadUploadedFileDialouge(this)" style="margin-left: 4px;" title="Download"></span>';
        }
    }
    else {
        fileLink = '' +
        '<img style="width:100%" src="' + path + '" />' +
        '<div class="hover-action-div">' +
            '<span class="spndelete" onclick="DeleteAttachment(this)" style="margin-left: 4px;" title="Delete"></span>' +
            '<span class="spndownload" onclick="DownloadUploadedFileDialouge(this)" style="margin-left: 4px;" title="Download"></span>' +
        '</div>';
    }

    return fileLink;
}
function UploadedFileAutoFill(file, path) {
    debugger;

    var fullDate = new Date();
    var twoDigitMonth = fullDate.getMonth() + 1;
    if (twoDigitMonth.length == 1)
    { twoDigitMonth = "0" + twoDigitMonth; }
    var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
    var currentDate = twoDigitMonth + "/" + twoDigitDate + "/" + fullDate.getFullYear();
    debugger;
    //if ($("#txtIntDate").val() == "") { $("#txtIntDate").val(currentDate); }


    if (typeof (file) != "undefined") {
        debugger;
        var filenamereverse = file.substring(0, file.lastIndexOf('.'));

        $("#txtDocName").val(filenamereverse);
        $("#txtDocumentName").val(filenamereverse);
        //$("#txtDocName").val(file);
        //Change By Syed Sajid Ali Date 7/11/2018
        var fileformate = $.trim(file.substring(file.length - 3, file.length));


        fileformate = fileformate.toUpperCase();
        if ($("#ddlReceivedBy").val() != 0) { }
        else { $("#ddlReceivedBy").prop('selectedIndex', 4); }


    }
    debugger
    if (fileformate == "PDF")
        $("#ddlFileFormate").prop('selectedIndex', 2);
    if (fileformate == "TXT")
        $("#ddlFileFormate").prop('selectedIndex', 5);
    if (fileformate == "ZIP")
        $("#ddlFileFormate").prop('selectedIndex', 1);
    if (fileformate == "JPG")
        $("#ddlFileFormate").prop('selectedIndex', 6);
    if (fileformate == "PEG")
        $("#ddlFileFormate").prop('selectedIndex', 6);
    if (fileformate == "PNG")
        $("#ddlFileFormate").prop('selectedIndex', 6);
    if (fileformate == "GIF")
        $("#ddlFileFormate").prop('selectedIndex', 6);
    if (fileformate == "OCX")
        $("#ddlFileFormate").prop('selectedIndex', 3);
    if (fileformate == "LSX")
        $("#ddlFileFormate").prop('selectedIndex', 4);
    currentDate = "";
}
function DownloadUploadedFile(elem) {
    debugger;

    var filePath = $(elem).closest("tr").find(".hdnDocumentPath").val();
    var fileName = $(elem).closest("tr").find(".hdnOriginalFileName").val();
    if (filePath != "") {
        saveToDisk(filePath, fileName);
    }
    else { showErrorMessage("No attachment uploaded"); }
}
function DeleteAttachment(elem) {
    debugger;

    $(elem).closest(".patient-document-files-wrapper").hide();
    $(elem).closest(".patient-document-files-wrapper").find(".hdnDeleted").val("true");


    //$(elem).find(".hdnPatientDocumentAttachmentsId").val();
    // $(elem).find(".hdnDocumentPath").val("");
    // $(elem).find(".hdnOriginalFileName").val("");// $("#orignalfilname").val();//

    //Added By Rizwan kharal 2August2018
    $("#divEditUploadFileForm").find(".hdnDocumentPath").val("");
    $("#divEditUploadFileForm").find(".hdnOriginalFileName").val("");
    $("#divPatientDocumentsFilesInner").html("");





}
//Changes End By Syed Sajid Ali Date:10-11-2018
//End File Added By Rizwan kharal 

