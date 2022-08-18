$(document).ready(function () {
    debugger;
    var dateOfBirthMin = new Date();
    dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);
    $("[id$='txtDateOfBirth']").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        yearRange: "-110:+0",
        onSelect: function (date, obj) {
            FilterPatient(0, true);
        }
    }).mask("99/99/9999");

    //GeneratePaging($("[id$='hdnPendingSubmissionCount']").val(), $("#ddlPatientInvoices").val(), "divPendingInvoices", "FilterInvoice_RBR");
    //if ($("[id$='hdnPendingSubmissionCount']").val() > 0)
    //    $("#divPendingInvoices .spanInfo").html("Showing " + $("#PatientInvoicesList tr:first").children().first().html() + " to " + $("#PatientInvoicesList tr:last").children().first().html() + " of " + $("[id$='hdnPendingSubmissionCount']").val() + " entries");
    FilterInvoice_RBR(0, true);
    $('#CkBox').prop('checked', true)
});

function SetSearch(event,type) {
    debugger;
    var a = event.which || event.keyCode;
    if (a == 13 && type=="") {
            FilterInvoice(0, true);
    }
    else if (a == 13 && type == "RBR") {
        FilterInvoice_RBR(0, true);
    }

}
function FilterInvoice(pageNumber, paging) {
    debugger;
    var PayerId = $.trim($("#txtpayer_ID").val()) == "" ? "" : $.trim($("#txtpayer_ID").val());

    var PatientName = $.trim($("#txtpatient_Name").val());
    var lastInvoiceSubmitted = $.trim($("#txtlast_Invoice").val());
    var totalPendingAmount = $.trim($("#txttotalPending_Amount").val());

    $("#ddlPatientInvoices1").attr("style", "");
    $("#ddlPatientInvoices").hide();
    $("#header_2").show();
    $("#header_1").hide();

    $.post(_ResolveUrl + "../../ProviderPortal/PatientInvoice/CallBacks/PatientInvoicesHandler.aspx", { PayerId: PayerId, PatientName: PatientName, lastInvoiceSubmitted: lastInvoiceSubmitted, totalPendingAmount: totalPendingAmount, Rows: $("#ddlPatientInvoices1").val(), PageNumber: pageNumber, action: "UnBilled" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#PatientInvoicesList").html(returnHtml.substring(start, end));
        debugger;

        if (paging == true) {
            GeneratePaging($("[id$='hdnPatientInvoicesCount']").val(), $("#ddlPatientInvoices1").val(), "divPendingInvoices", "FilterInvoice");
            //Added by Asad Mehmood
            $('#thChk_Header').attr('checked', false);
        }

        if ($("[id$='hdnPatientInvoicesCount']").val() > 0)
            $("#divPendingInvoices .spanInfo").html("Showing " + $("#PatientInvoicesList tr:first").children().first().html() + " to " + $("#PatientInvoicesList tr:last").children().first().html() + " of " + $("[id$='hdnPatientInvoicesCount']").val() + " entries");

        if ($('#CkBox1').is(':Checked') == false && $('#_CkBox').is(':Checked') == false && $('#_CkBox1').is(':Checked') == false) {

            $("#CkBox").attr("Checked", true);
            FilterInvoice_RBR(0, true);
        }
    });
}

function FilterInvoice_RBR(pageNumber, paging, elem) {
    debugger;
    var type = $('#chkdiv').find('#CkBox').val();
    var type1 = $('#chkdiv').find('#CkBox1').val();
    if (type1 == "RBRR") {
        type = '';

    }

   
 

    var PayerId = $.trim($("#txtpayerID").val()) == "" ? "" : $.trim($("#txtpayerID").val());

    var PatientName = $.trim($("#txtpatientName").val());
    var lastInvoiceSubmitted = $.trim($("#txtlastInvoice").val());
    var totalPendingAmount = $.trim($("#txttotalPendingAmount").val());
    $("#ddlPatientInvoices1").hide();
    $("#ddlPatientInvoices").show();
    $("#header_2").hide();
    $("#header_1").show();

    $.post(_ResolveUrl + "../../ProviderPortal/PatientInvoice/CallBacks/PatientInvoicesHandler.aspx", { PayerId: PayerId, PatientName: PatientName, lastInvoiceSubmitted: lastInvoiceSubmitted, totalPendingAmount: totalPendingAmount, Rows: $("#ddlPatientInvoices").val(), PageNumber: pageNumber, SortBy: "FirstName", action: "Billed" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#PatientInvoicesList").html(returnHtml.substring(start, end));
        debugger;

        if (paging == true) {
            GeneratePaging($("[id$='hdnPatientInvoicesCount']").val(), $("#ddlPatientInvoices").val(), "divPendingInvoices", "FilterInvoice_RBR");
            //Added by Asad Mehmood
            $('#thChkHeader').attr('checked', false);
        }

        if ($("[id$='hdnPatientInvoicesCount']").val() > 0)
            $("#divPendingInvoices .spanInfo").html("Showing " + $("#PatientInvoicesList tr:first").children().first().html() + " to " + $("#PatientInvoicesList tr:last").children().first().html() + " of " + $("[id$='hdnPatientInvoicesCount']").val() + " entries");

        if ($('#CkBox').is(':Checked') == false && $('#_CkBox').is(':Checked') == false && $('#_CkBox1').is(':Checked') == false) {
          
            $("#CkBox1").attr("Checked", true);
            FilterInvoice(0, true);
        }

    });

   

}

function CheckAllChk() {
    if ($("#thChkHeader").is(":checked")) { $('.singleCheckbox').prop('checked', true); }
    else { $('.singleCheckbox').prop('checked', false); }
}

function Check_AllChk() {
    if ($("#thChk_Header").is(":checked")) { $('.singleCheckbox').prop('checked', true); }
    else { $('.singleCheckbox').prop('checked', false); }
}

function generateInvoiceFile(elem) {
    debugger
    var counter = 0;
    $("#PatientInvoicesList").find('.trPatientInvoice').each(function () {
        debugger
        if(counter == 0){
        if ($(this).find('td').eq(1).children().is(":checked")) {
            var a = $.trim($(this).closest('tr').find(".PendingAmount").html());
            if (a.charAt(0) == "(") {
                $("<div></div>").html("<span style='top:5px'>You can't generate invoice due to negative balance !</span>").dialog({
                    resizable: false,
                    top: 30,
                    width: 330,
                    modal: true,
                    title: 'Information!',
                    buttons: {

                        "Ok": function () {
                            $(this).dialog("close");

                        }
                    }
                });
                counter++;
            }
            //return false
           // $("#divPopupPatientInvoice").dialog("close");

          }
        }        
    });
    if (counter == 1) {
        return false
    } 
    //if ($(".singleCheckbox").is(":checked")) {
    //    debugger
    //    var a = $.trim($(".PendingAmount").html());
    //    if (a.charAt(0) == "(") {            
    //        $("<div></div>").html("<span style='top:5px'>You can't generate invoice due to negative balance !</span>").dialog({
    //            resizable: false,
    //            top: 30,
    //            width: 330,
    //            modal: true,
    //            title: 'Information!',
    //            buttons: {

    //                "Ok": function () {
    //                    $(this).dialog("close");
                        
    //                }
    //            }
    //        });
    //        return
    //    }
    //    $("#divPopupPatientInvoice").dialog("close");

    //}
    debugger;
    $("[id$='divRightsSettings']").hide();
    if (!checkModuleRights("PatientInvocie")) {
        showErrorMessage(_msg_GenerateSubmissionFile)
        return false;
    }

    var InvoiceList = new Array();
    var patients = "";
    var patientId = "";
    var patientInvoice = "";
    var pName = "";

 
    $.when($("[id$='PatientInvoicesList'] tr").find("input:checked").each(function () {
     
        var invoice = new Object();
        patients += $.trim($(this).closest("tr").attr("id")) + ",";
        pName += $.trim($(this).closest("tr").find("td").eq(3).html()) + " : ";
        patientId = $.trim($(this).closest("tr").attr("id"));

        //invoice = $.when(getInvoice(patientId)).then(fillData);

        invoice.patientId = patientId;

        invoicedata = getInvoice(patientId);
        patientInvoice += invoicedata;
        invoicedata = invoicedata.replace(/\r?\n|\r/g, " ");
        invoicedata = invoicedata.replace(/</gm, "&gt;");
        invoicedata = invoicedata.replace(/>/gm, "&lt;");
        //invoicedata = JSON.stringify(invoicedata);

        invoice.data = invoicedata;
        debugger;
        InvoiceList.push(invoice);


    })).then(

          showInvoices(patientInvoice, patients, InvoiceList, pName)

   );


    if (patients.length == 0) {
        $("#divInvoiceDLG").dialog("close");
        dialogShowMessage("Please select at least 1 Patient to Generete invoice File!", "Required");
        return false;
    }

}

function getInvoice(patientid) {
    var inv = "";
    var inv2 = "";
    //var returnHtml = "";
    debugger;
    var type1 = "";
    if ($("#CkBox").is(":checked") || $("#_CkBox").is(":checked")) {
        //Type = "Billed";
        type1 = "Billed";
    }
    else if ($("#CkBox1").is(":checked") || $("#_CkBox1").is(":checked")) {
        //Type = "UnBilled";
        type1 = "UnBilled";
    }
   // else{type="Test"}
    var request = "{PatientId: " + patientid + "}";
    $.ajax({
        type: "POST",
        url: "../../ProviderPortal/PatientInvoice/CallBacks/PatientInvoicePrintForm.aspx?patientid=" + patientid + "&Type1=" + type1,
        async: false,
        data: { request: request, Type11: "ali" },
        contentType: "application/json; charset=utf-8",

         success: function (data1) {
            returnHtml = data1;
            var start = data1.indexOf("####PatientInvoiceStart####") + 27;
            var end = data1.indexOf("####PatientInvoiceEnd####");
            inv = returnHtml.substring(start, end);          
         },
        error: function (xhr, ajaxOptions, thrownError) {
         //   alert(thrownError);
        } 
   });
    return inv;
}

function showInvoices(patientInvoice, patients, InvoiceList, pName) {
    debugger;
    $("#divInvoiceDLG").html(patientInvoice)

    // ;
    $("#divInvoiceDLG").dialog({
        resizable: false,
        top:10,
        width: 760,
        modal: true,
        title: 'Confirmation',
        buttons: {
            //"Save Invoices": function () {

            //    /*************added by shahid kazmi 3/19/2018***************/
            //    $(".thChk").prop("checked", false)
            //    /**************end shahid kazmi 3/19/2018***************/
            //    SaveInvoices(patients, InvoiceList, patientInvoice, pName);

            //    $(this).dialog("close");
            //    FilterInvoiceFiles(0, true);
            //    FilterPendingInvoices(0, true)
            //    showSuccessMessage("File is save sucessfully! ");
            //}
            "Print Invoices": function () {
                $(this).dialog("close");
                PrintInvoices(patientInvoice);
            },
            "Cancel": function () {
                $(this).dialog("destroy");
                $(".PatientInvoice").css("display", "none");
                $(".pageBreak").css("display", "none");
            }
        }
    })
}

function PrintInvoices(content_vlue) {
    debugger;
    var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
    disp_setting += "scrollbars=yes,width=650, height=600, left=100, top=25";
    debugger;
    var docprint = window.open("", "", disp_setting);
    docprint.document.open();
    docprint.document.write('<html><head><title></title>' +
       '<link href="../../../StyleSheets/PatientInvoice.css" rel="stylesheet" />');
    docprint.document.write('</head><body onLoad="self.print();self.close();">');
    docprint.document.write(content_vlue);
    docprint.document.write('</body></html>');
    docprint.document.close();
    docprint.focus();
}

function chkSingleCheckBox() {
    $(".thChk").prop("checked", false)
}

function showPatInvoices() {
    debugger;
    $("#divInvoice_DLG").dialog({
        resizable: false,
        top:10,
        width: 760,
        modal: true,
        title: 'Confirmation',
        buttons: {
            "Ok": function () {
                debugger;
                if ($("#_CkBox").is(":checked"))
                {
                    OpenPatientInvoice_RBR(0, true);
                    $(this).dialog("close");
                }
               else if ($("#_CkBox1").is(":checked"))
                {
                    OpenPatientInvoice(0, true);
                    $(this).dialog("close");
                }
                else { showErrorMessage("Please Select a CheckBox!"); }
            },
            "Cancel": function () { $(this).dialog("destroy"); }
        }
    })
}

function OpenPatientInvoice_RBR(pageNumber, paging) {
    debugger;
    var PatientId = $("[id$='hdnPatientId']").val();

    $("#ddlPatientInvoices1").attr("style", "");
    $("#ddlPatientInvoices").hide();
    $("#header_2").show();
    $("#header_1").hide();

    $.post(_ResolveUrl + "../../ProviderPortal/PatientInvoice/CallBacks/GetInvoiceForSinglePatient.aspx", { Rows: $("#ddlPatientInvoices1").val(), PageNumber: pageNumber, PatientId: PatientId, action: "Billed" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        //$("#PatientInvoicesList").html(returnHtml.substring(start, end));
        debugger;
        var returnHtml_1 =returnHtml.substring(start, end);
        $("#divPopupPatientInvoice").html(returnHtml_1).dialog({
            resizable: false,
            title: "Patient Invoice Details",
            height: 500,
            width: 900,
            modal: true,
            buttons: {
                Close: function () {
                    $(this).dialog("destroy");
                }
            },
            close: function () {
                $(this).dialog("destroy");
            }


        });

        if (paging == true) {
            GeneratePaging($("[id$='hdnPatientInvoicesCount']").val(), $("#ddlPatientInvoices").val(), "divPendingInvoices", "FilterSinglePatientDetail_RBR");
        }

        if ($("[id$='hdnPatientInvoicesCount']").val() > 0)
            $("#divPendingInvoices .spanInfo").html("Showing " + $("#PatientInvoicesList tr:first").children().first().html() + " to " + $("#PatientInvoicesList tr:last").children().first().html() + " of " + $("[id$='hdnPatientInvoicesCount']").val() + " entries");
    });
}

function FilterSinglePatientDetail_RBR(pageNumber, paging) {
    debugger;
    var PatientId = $("[id$='hdnPatientId']").val();
    var PayerId = $("[id$='hdnPatientId']").val();
    var PatientName = $.trim($("#txtpatient_Name").val());
    var lastInvoiceSubmitted = $.trim($("#txtlast_Invoice").val());
    var totalPendingAmount = $.trim($("#txttotalPending_Amount").val());

    $("#ddlPatientInvoices1").attr("style", "");
    $("#ddlPatientInvoices").hide();
    $("#header_2").show();
    $("#header_1").hide();

    $.post(_ResolveUrl + "../../ProviderPortal/PatientInvoice/CallBacks/GetInvoiceForSinglePatiendHandler.aspx", { PayerId: PayerId, PatientName: PatientName, lastInvoiceSubmitted: lastInvoiceSubmitted, totalPendingAmount: totalPendingAmount, Rows: $("#ddlPatientInvoices1").val(), PageNumber: pageNumber, PatientId: PatientId, action: "Billed" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#PatientInvoicesList").html(returnHtml.substring(start, end));
        debugger;
        if (paging == true) {
            GeneratePaging($("[id$='hdnPatientInvoicesCount']").val(), $("#ddlPatientInvoices").val(), "divPendingInvoices", "FilterInvoice_RBR");
        }

        if ($("[id$='hdnPatientInvoicesCount']").val() > 0)
            $("#divPendingInvoices .spanInfo").html("Showing " + $("#PatientInvoicesList tr:first").children().first().html() + " to " + $("#PatientInvoicesList tr:last").children().first().html() + " of " + $("[id$='hdnPatientInvoicesCount']").val() + " entries");
    });
}

function OpenPatientInvoice(pageNumber, paging) {
    debugger;
    var PatientId = $("[id$='hdnPatientId']").val();
    var PayerId = $.trim($("#txtpayer_ID").val()) == "" ? "" : $.trim($("#txtpayer_ID").val());
    var PatientName = $.trim($("#txtpatient_Name").val());
    var lastInvoiceSubmitted = $.trim($("#txtlast_Invoice").val());
    var totalPendingAmount = $.trim($("#txttotalPending_Amount").val());

    $("#ddlPatientInvoices1").attr("style", "");
    $("#ddlPatientInvoices").hide();
    $("#header_1").show();
    $("#header_2").hide();

    $.post(_ResolveUrl + "../../ProviderPortal/PatientInvoice/CallBacks/GetInvoiceForSinglePatient.aspx", { PayerId: PayerId, PatientName: PatientName, lastInvoiceSubmitted: lastInvoiceSubmitted, totalPendingAmount: totalPendingAmount, Rows: $("#ddlPatientInvoices1").val(), PageNumber: pageNumber, PatientId: PatientId, action: "UnBilled" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        //$("#PatientInvoicesList").html(returnHtml.substring(start, end));
        debugger;
        var returnHtml_1 = returnHtml.substring(start, end);
        $("#divPopupPatientInvoice").html(returnHtml_1).dialog({
            resizable: false,
            title: "Patient Invoice Details",
            height: 500,
            width: 900,
            modal: true,
            buttons: {
                Close: function () {
                    $(this).dialog("destroy");
                }
            },
            close: function () {
                $(this).dialog("destroy");
            }


        });

        if (paging == true) {
            GeneratePaging($("[id$='hdnPatientInvoicesCount']").val(), $("#ddlPatientInvoices").val(), "divPendingInvoices", "FilterInvoice");
        }

        if ($("[id$='hdnPatientInvoicesCount']").val() > 0)
            $("#divPendingInvoices .spanInfo").html("Showing " + $("#PatientInvoicesList tr:first").children().first().html() + " to " + $("#PatientInvoicesList tr:last").children().first().html() + " of " + $("[id$='hdnPatientInvoicesCount']").val() + " entries");
    });
}
