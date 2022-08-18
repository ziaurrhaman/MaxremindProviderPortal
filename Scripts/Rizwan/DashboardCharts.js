/// <reference path="../../ProviderPortal/Claim/CallBacks/FilterCriteriaCharts.aspx" />
$(document).ready(function () {
    $("[id$='txtDOS']").datepicker({
        changeMonth: true,
        changeYear: true,
       
    }).mask("99/99/9999"); 

    $("[id$='txtPostDate']").datepicker({
        changeMonth: true,
        changeYear: true,

    }).mask("99/99/9999");
    

   
});



var DateCriteria; var stratDate; var endDate; var ColumnValue; var EndDate;
var Datetype; var Provider=""; var Status; var Location="";
var PageNumber = $("[id$='txtReportPageNumber']").val(); var Paging = true;
var DateTypeF;

function setrowid(){

    debugger;
    document.getElementById("ddlPagingClaimChecks").selectedIndex = "0";
    DateCriteria = "Last90Days";
    stratDate = "";
    endDate = "";
    Location = "All";
    Provider = "All";
    DateTypeF = "Dos";
}
   



function CLAIMSUBMISSIONSTATUSPIECHARTDetail(status) {
    debugger
  
    Status = status;
   // var DateCriteria; var stratDate; var EndDate;
    var datetype;
  
    
    if ($("[id$=chkMonthToDate]").is(":checked")) {
        debugger
        DateCriteria = "MonthToDate";
    }
    else if ($("[id$=chkLastMonth]").is(":checked")) {
        DateCriteria = "LastMonth";
    }
    else if ($("[id$=chkYearToDate]").is(":checked")) {
        DateCriteria = "YearToDate";
    }
    else if ($("[id$=chkSelectDate]").is(":checked")) {
        DateCriteria = "Select";
        stratDate = $("[id$=txtFromDate]").val();
        endDate = $("[id$=txtToDate]").val();
    }
    else {
        DateCriteria = "Last90Days";
    }

    if ($("[id$='PostRb']").is(":checked")) {
        datetype = "Post"
    }
    else if (($("[id$='DOSRb']").is(":checked"))) {
        datetype = "Dos";
    }
     Location = $("[id$='ddlLocation']").val();
     Provider = $("[id$='ddlBillingProvider']").val();
   

     DateTypeF = datetype;
 


    $.post(_ResolveUrl + "ProviderPortal/Claim/ClaimSubmissionStatus.aspx", {

        DateCriteria: DateCriteria,
        stratDate: stratDate,
        EndDate: endDate,
        Datetype: datetype,
        Location: Location,
        Provider: Provider,
        SubmissionStatus: status
    },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartERAClaims###") + 20;
        var end = data.indexOf("###EndERAClaims###");
        $("#DivChartsDetailsReport").html(returnHtml.substring(start, end));
        $("#DivChartsDetailsReport").dialog({
            width: 960,
            modal: true,
            title: "Claim Submission Chart Report",
            open: function () {
                //$(".ui-widget-overlay").last().css("z-index", "9999999");
                //$(".ui-dialog").last().css("z-index", "99999999");
                $("body").css("overflow", "hidden");
            },
            close:function(){
                $("body").css("overflow", "visible");
            },
            buttons: {
                Print: function () {
                    debugger

                    $("body").css("overflow", "visible");
                    var printdata = $("#Print").html();
                    $("#PrintAll").html(printdata);
                    $(this).dialog("destroy");
                    $("#DivChartsDetailsReport").hide();

                    var divToPrint = document.getElementById('PrintAll');

                    var newWin = window.open('', 'Print-Window');

                    newWin.document.open();

                    newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

                    newWin.document.close();

                    setTimeout(function () { newWin.close(); }, 10);
                  


                   

                },
                Close: function () {
                    debugger;
                    $("body").css("overflow", "visible");
                    $(this).dialog("destroy");
                    $("#DivChartsDetailsReport").hide();
                    if (datetype == "Dos")
                    {
                        $("[id$='DOSRb']").attr("checked", true);
                    }
                    else {
                        $("[id$='PostRb']").attr("checked", true);
                    }
                   
                }
            }
        });

    });
}




function ClaimSubmissionStatusAgingCHARTDetail(status,columnvalue) {
    debugger
    Status = status; ColumnValue = columnvalue;
   // var DateCriteria; var stratDate; var EndDate;
    var datetype;
    if ($("[id$=chkMonthToDate]").is(":checked")) {
        debugger
        DateCriteria = "MonthToDate";
    }
    else if ($("[id$=chkLastMonth]").is(":checked")) {
        DateCriteria = "LastMonth";
    }
    else if ($("[id$=chkYearToDate]").is(":checked")) {
        DateCriteria = "YearToDate";
    }
    else if ($("[id$=chkSelectDate]").is(":checked")) {
        DateCriteria = "Select";
        stratDate = $("[id$=txtFromDate]").val();
        endDate = $("[id$=txtToDate]").val();
    }
    else {
        DateCriteria = "Last90Days";
    }

    if ($("[id$='PostRb']").is(":checked")) {
        datetype = "Post"
    }
    else if (($("[id$='DOSRb']").is(":checked"))) {
        datetype = "Dos";
    }
    DateTypeF = datetype;
    var Location = $("[id$='ddlLocation']").val();
    var Provider = $("[id$='ddlBillingProvider']").val();




    $.post(_ResolveUrl + "ProviderPortal/Claim/ClaimSubmissionStatusAging.aspx", {

        DateCriteria: DateCriteria,
        stratDate: stratDate,
        EndDate: endDate,
        Datetype: datetype,
        Location: Location,
        Provider: Provider,
        SubmissionStatus: status,
        Aging:columnvalue
    },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartERAClaims###") + 20;
        var end = data.indexOf("###EndERAClaims###");
        $("#DivChartsDetailsReport").html(returnHtml.substring(start, end)); 
        $("#DivChartsDetailsReport").dialog({
            width: 960,
            modal: true,
            title: "Claim Submission Status Chart Report",
            open: function () {
                //$(".ui-widget-overlay").last().css("z-index", "9999999");
                //$(".ui-dialog").last().css("z-index", "99999999");
                $("body").css("overflow", "hidden");
            },
            close: function () {
                $("body").css("overflow", "visible");
            },
            buttons: {
                Print: function () {
                    debugger
                    $("body").css("overflow", "visible");
                    var printdata = $("#Print").html();
                    $("#PrintAll").html(printdata);

                    $(this).dialog("destroy");
                    $("#DivChartsDetailsReport").hide();
                  


                    var divToPrint = document.getElementById('PrintAll');

                    var newWin = window.open('', 'Print-Window');

                    newWin.document.open();

                    newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

                    newWin.document.close();

                    setTimeout(function () { newWin.close(); }, 10);



                  

                },
                Close: function () {
                    $("body").css("overflow", "visible");
                    $(this).dialog("destroy");
                    $("#DivChartsDetailsReport").hide();
                    if (datetype == "Dos") {
                        $("[id$='DOSRb']").attr("checked", true);
                    }
                    else {
                        $("[id$='PostRb']").attr("checked", true);
                    }
                    //  $("#ClaimSubmissionStatusReport").css("display", "none");
                }
            }
        });

    });
}


function PayerCLAIMDistributionPIECHARTDetail(status) {
    debugger
    Status = status;
    var datetype;

    if ($("[id$=chkMonthToDate]").is(":checked")) {
        debugger
        DateCriteria = "MonthToDate";
    }
    else if ($("[id$=chkLastMonth]").is(":checked")) {
        DateCriteria = "LastMonth";
    }
    else if ($("[id$=chkYearToDate]").is(":checked")) {
        DateCriteria = "YearToDate";
    }
    else if ($("[id$=chkSelectDate]").is(":checked")) {
        DateCriteria = "Select";
        stratDate = $("[id$=txtFromDate]").val();
        endDate = $("[id$=txtToDate]").val();
    }
    else {
        DateCriteria = "Last90Days";
    }

    if ($("[id$='PostRb']").is(":checked")) {
        datetype = "Post"
    }
    else if (($("[id$='DOSRb']").is(":checked"))) {
        datetype = "Dos";
    }
    DateTypeF = datetype;
    var Location = $("[id$='ddlLocation']").val();
    var Provider = $("[id$='ddlBillingProvider']").val();




    $.post(_ResolveUrl + "ProviderPortal/Claim/PayerCalimDistribution.aspx", {

        DateCriteria: DateCriteria,
        stratDate: stratDate,
        EndDate: endDate,
        Datetype: datetype,
        Location: Location,
        Provider: Provider,
        PayerName: status
    },
    function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartERAClaims###") + 20;
        var end = data.indexOf("###EndERAClaims###");
        $("#DivChartsDetailsReport").html(returnHtml.substring(start, end));
        $("#DivChartsDetailsReport").dialog({
            width: 960,
            modal: true,
            title: "Payer Claim Distribution Chart Report",
            open: function () {
                //$(".ui-widget-overlay").last().css("z-index", "9999999");
                //$(".ui-dialog").last().css("z-index", "99999999");
                $("body").css("overflow", "hidden");
            },
            close: function () {
                $("body").css("overflow", "visible");
            },
            buttons: {
                Print: function () {
                    debugger


                    $("body").css("overflow", "visible");
                    var printdata = $("#Print").html();
                    $("#PrintAll").html(printdata);

                    $(this).dialog("destroy");
                    $("#DivChartsDetailsReport").hide();

                    var divToPrint = document.getElementById('PrintAll');

                    var newWin = window.open('', 'Print-Window');

                    newWin.document.open();

                    newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

                    newWin.document.close();

                    setTimeout(function () { newWin.close(); }, 10);


                    // printHtml("PrintAll");





                },
                Close: function () {
                    $("body").css("overflow", "visible");
                    $(this).dialog("destroy");
                    $("#DivChartsDetailsReport").hide();
                    if (datetype == "Dos") {
                        $("[id$='DOSRb']").attr("checked", true);
                    }
                    else {
                        $("[id$='PostRb']").attr("checked", true);
                    }
                    //  $("#ClaimSubmissionStatusReport").css("display", "none");
                }
            }
        });

    });
}


function FilterClaimSubmission(pageNumber, paging) {
    debugger;
    var PracticeId = $("[id$=hdnPracticeId]").val();
    var Location1 = $("[id$='ddlLocation']").val();

    if (Location == "") {
        debugger
        Location = Location1;
    }
    else {
        Location1 = Location;
    }

    var Provider1 = $("[id$='ddlBillingProvider']").val();
    if (Provider == "") {
        Provider = Provider1;
    }
    else {
        Provider1 = Provider;
    }
   var SubmissionStatus = Status;
   var Rows = $("#ddlPagingClaimChecks").val();

   var Criteria = DateCriteria

   var Datetype = DateTypeF;
   
   var StartDate = stratDate;
   var EndDate = endDate;

    $.post(_ResolveUrl + "ProviderPortal/Claim/CallBacks/ClaimSubmissionStatusHandler.aspx",
        {
       PracticeId:PracticeId,
       Rows: Rows, pageNumber: pageNumber,
       Location: Location1,
       Provider: Provider1, SubmissionStatus: SubmissionStatus,
       DateCriteria: Criteria, Datetype: Datetype, stratDate: StartDate,
       EndDate: EndDate
        },
    function (data) {
        // SetClaimChecksGrid(data, pageNumber, paging);
        var returnHtml = data;
        var start = data.indexOf("###StartClaimChecks###") + 22;
        var end = data.indexOf("###EndClaimChecks###");
        $("#claimChecksList").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartClaimChecksTotalRow###") + 30;
        var endRowsCount = data.indexOf("###EndClaimChecksTotalRow###");
        $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
        if (paging == true) {
          
            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingClaimChecks").val(), "divReportPaging", "FilterClaimSubmission");
        }

      


      


    });
}

function FilterPayerClaimDistribution(pageNumber, paging) {
    debugger;

   
    var PracticeId = $("[id$=hdnPracticeId]").val();
    var PayerName = Status;
    var Rows = $("#ddlPagingClaimChecks").val()

    var Location1 = $("[id$='ddlLocation']").val();

    if (Location == "") {
        debugger
        Location = Location1;
    }
    else {
        Location1 = Location;
    }

    var Provider1 = $("[id$='ddlBillingProvider']").val();
    if (Provider == "") {
        Provider = Provider1;
    }
    else {
        Provider1 = Provider;
    }
   // var SubmissionStatus = Status;
    var Rows = $("#ddlPagingClaimChecks").val();
    var Criteria = DateCriteria;
    var DateType = DateTypeF;
    var StartDate = stratDate;
    var EndDate = endDate;


    $.post(_ResolveUrl + "ProviderPortal/Claim/CallBacks/PayerClaimDistributionHandler.aspx",
        {
            PracticeId: PracticeId,
            Rows: Rows,
            pageNumber: pageNumber,
            Location: Location1, 
            Provider: Provider1,
            PayerName: PayerName,
            DateCriteria: Criteria, Datetype: DateType, stratDate: StartDate,
            EndDate: EndDate
           
         
        },
    function (data) {
        debugger;
        // SetClaimChecksGrid(data, pageNumber, paging);
        var returnHtml = data;
        var start = data.indexOf("###StartClaimChecks###") + 22;
        var end = data.indexOf("###EndClaimChecks###");
        $("#claimChecksList").html(returnHtml.substring(start, end));


        start = data.indexOf("###StartClaimChecksTotalRow###") + 30;
        end = data.indexOf("###EndClaimChecksTotalRow###");
        returnHtml = $.trim(data.substring(start, end));

        $("[id$='hdnTotalRows']").val(returnHtml);

        if (paging == true) {
            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingClaimChecks").val(), "divReportPaging", "FilterPayerClaimDistribution");
        }

        
      
    });
}

function FilterClaimSubmissionAging(pageNumber, paging) {
    debugger;

    var Location1 = $("[id$='ddlLocation']").val();
  
    if (Location == "") {
      debugger
        Location = Location1;
    }
    else{
        Location1 = Location;
    }

    var Provider1 = $("[id$='ddlBillingProvider']").val();
    if (Provider == "") {
        Provider = Provider1;
    }
    else
    {
        Provider1 = Provider;
    }
    var PracticeId = $("[id$=hdnPracticeId]").val();
   
    var SubmissionStatus = $("[id$='hdnStatusFiled']").val();
    var Rows = $("#ddlPagingClaimChecks").val();
    var Aging = ColumnValue;
    var Criteria = DateCriteria
    var DateType = DateTypeF;
    var StartDate = stratDate;
    var EndDate = endDate;





    $.post(_ResolveUrl + "ProviderPortal/Claim/CallBacks/ClaimSubmissionStatusAgingHandler.aspx",
        {
            PracticeId: PracticeId, Rows: Rows, pageNumber: pageNumber,
            Location: Location1, 
            Provider: Provider1,
            SubmissionStatus: SubmissionStatus, Aging: Aging,
            DateCriteria: Criteria, Datetype: DateType, stratDate: StartDate,
            EndDate: EndDate
        },
    function (data) {
        // SetClaimChecksGrid(data, pageNumber, paging);
        debugger;
        var returnHtml = data;
        var start = data.indexOf("###StartClaimChecks###") + 22;
        var end = data.indexOf("###EndClaimChecks###");
        $("#claimChecksList").html(returnHtml.substring(start, end));


        start = data.indexOf("###StartClaimChecksTotalRow###") + 30;
        end = data.indexOf("###EndClaimChecksTotalRow###");
        returnHtml = $.trim(data.substring(start, end));

        $("[id$='hdnTotalRows']").val(returnHtml);

        if (paging == true) {
            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingClaimChecks").val(), "divReportPaging", "FilterClaimSubmissionAging");
        }

      
    });
}












function FilterCriteriaCharts(Report)
{

    debugger;
   
    
   // $("#DivChartsDetailsReport").attr("disabled",true);
    
    //$("#DivChartsDetailsReport").dialog("disable")
    //    .closest(".ui-dialog")
    //    .find(":input")
    //    .prop("disabled", true);

   // $("#DivChartsDetailsReport").addClass("disable");
  //  $("#DivChartsDetailsReport").css("pointer-events", "none");
   
    $.post(_ResolveUrl + "ProviderPortal/Claim/CallBacks/FilterCriteriaChart.aspx", function (data) {
        debugger;
        var returnHtml = data;
        var start = data.indexOf("###StartERAClaims###") + 20;
        var end = data.indexOf("###EndERAClaims###");
        $("#FilterCriteria").html(returnHtml.substring(start, end));
        $("#FilterCriteria").dialog({
            width: 390,
            autoOpen:true,
            modal: true,
            title: "Filter Criteria",
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
               
            },
            buttons: {
                Filter: function () {
                   
                    if ($("[id$=chkMonthToDate1]").is(":checked")) {
                        debugger
                        DateCriteria = "MonthToDate";
                    }
                    else if ($("[id$=chkLastMonth1]").is(":checked")) {
                        DateCriteria = "LastMonth";
                    }
                    else if ($("[id$=chkYearToDate1]").is(":checked")) {
                        DateCriteria = "YearToDate";
                    }
                    else if ($("[id$=chkSelectDate1]").is(":checked")) {
                        DateCriteria = "Select";
                        stratDate = $("[id$=txtFromDate1]").val();
                        endDate = $("[id$=txtToDate1]").val();
                    }
                    else {
                        DateCriteria = "Last90Days";
                    }

                    if ($("[id$='PostRb1']").is(":checked")) {
                        Datetype = "Post"
                    }
                    else if (($("[id$='DOSRb1']").is(":checked"))) {
                        Datetype = "Dos";
                    }
                    DateTypeF = Datetype;
                    Location = $("[id$='ddlLocation2']").val();
                    Provider = $("[id$='ddlBillingProvider2']").val();
                    debugger
                    var PageNo = "";
                    //var Page = PageNumber - 1;

                    //if (Page == -1) {
                    //    PageNo = 0;
                    //}
                    //else {
                    //    PageNo = Page;
                    //}
                    if (Report == "SC")
                    {

                        FilterClaimSubmission(PageNo, Paging)
                    }

                    else if (Report == "SCA") {
                       
                        FilterClaimSubmissionAging(PageNo, Paging)
                    }
                    else if (Report == "PCD") {
                        FilterPayerClaimDistribution(PageNo, Paging)
                    }
                    
                    $(this).dialog("destroy");
                    $(this).hide();
                 //   $(this).css("display", "none");
                  

                },
                Close: function () {
                    $(this).dialog("destroy");
                    $(this).hide();
                  //  $(this).css("display", "none");
                }
            }
        });

    });
}

function PrintReports()
{
    debugger;
    var printdata = $("#Print").html();
   

    $("#PrintAll").html(printdata);
    $("#PrintAll").hide();
    var divToPrint = document.getElementById('PrintAll');

    var newWin = window.open('', 'Print-Window');

    newWin.document.open();

    newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

    newWin.document.close();

    setTimeout(function () { newWin.close(); }, 10);

}


////
