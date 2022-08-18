//Created By Agha Sibtain, Dated:04/10/2019

var defualtdate = "";

$(document).ready(function () {
    debugger
    $("#Patients").addClass("active");
    var elem = $("#tbodyMailToInvoice").find('tr:first');

    var datevale = $.trim($("#tbodyMailToInvoice").find('tr:first').children("td:eq(1)").children('.hdndate').val());
    
   ShowDetails(datevale, elem);
});

function ShowDetails(date,elem) {
    debugger
   $(".nametd").removeClass("trhighlight1");
    $(elem).find('.nametd').addClass("trhighlight1");
    var date = date;
    defualtdate = date;
    $("#tbodyInvoiceFileContents").html("");

    var Patientinvoicesearch = $("#Patientinvoicetxt").val();
    $.post("CallBacks/MailToInvoicesHandler.aspx", { date: date, action: 'ViewFileName', Patientinvoicesearch: Patientinvoicesearch }, function (data) {
        
        var start = data.indexOf("###StartMailToInvoices###") + 25;
        var end = data.indexOf("###EndMailToInvoices###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbodyDetailInvoice").html(returnHtml);
    })
}


var FileContents = "";
function ViewFileContents(elem) {

    
    $(".nametd").removeClass("trhighlight2");
    $(elem).find('.nametd').addClass("trhighlight2");

    debugger
     FileContents = $(elem).find("#tdFileContents").html();
    
    $("#tbodyInvoiceFileContents").html(FileContents);
 
}
function PrintInvoices() {
    debugger;
   var content_vlue = $("#tbodyInvoiceFileContents").html();
       
   if ($("#tbodyInvoiceFileContents").html() == "")
   {
       showErrorMessage("Please Select Invoice First");
       return;
   }

    //var content_vlue = $(".PatientInvoice").html();
    var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
    disp_setting += "scrollbars=yes,width=650, height=620, left=100, top=25";
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


function Filterbatch() {
    debugger

    var WeeklyInvoicetxt = $("#WeeklyInvoicetxt").val() || "";
    $.post("CallBacks/MailToInvoicesHandler.aspx", { action: 'BatchFilter', WeeklyInvoicetxt: WeeklyInvoicetxt }, function (data) {
        debugger
        var start = data.indexOf("###SMailBatch###") + 18;
        var end = data.indexOf("###EMailBatch###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbodyMailToInvoice").html(returnHtml);
    })
}


function ShowDetailsFilter() {
    debugger

    $("#tbodyInvoiceFileContents").html("");
    
    var Patientinvoicesearch = $("#Patientinvoicetxt").val();

    $.post("CallBacks/MailToInvoicesHandler.aspx", { date: defualtdate, action: 'ViewFileName', Patientinvoicesearch: Patientinvoicesearch }, function (data) {

        var start = data.indexOf("###StartMailToInvoices###") + 25;
        var end = data.indexOf("###EndMailToInvoices###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#tbodyDetailInvoice").html(returnHtml);
    })
}
function setSearch(elem,search) {

    var a = event.which || event.keyCode;
    if (a == 13) {

        if (search == "Patientinvoice") {
            ShowDetailsFilter();
        }
        else {
            Filterbatch();
        }
    }
}