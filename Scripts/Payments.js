

var _SortByColumn = ""; _SortByValue = "";
var _DateType = "";
var _DateFrom = "";
var _DateTo = "";
var _ddldate = "";
var _ddlinsurance = "";
var _ddlProvider = "";
var arrFileTypes = ["jpg", "jpeg", "png", "gif", "bmp", "webp"];

        $(document).ready(function () {
      
            var dateOfBirthMin = new Date();
            dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);
            
            $("[id$='txtCheckDate']").datepicker({     
                changeMonth: true,
                changeYear: true,
                minDate: "01/01/1990",
                maxDate: new Date(),
                onSelect: function () {
                    FilterClaimChecks(0, true);
                }
            }).mask("99/99/9999");



            $("[id$='txtPostDate']").datepicker({
                changeMonth: true,
                changeYear: true,
                minDate: "01/01/1990",
                maxDate: new Date(),
                onSelect: function () {
                    FilterClaimChecks(0, true);
                }
            }).mask("99/99/9999");

            $("[id$='txtCheckDateAddCheck']").datepicker({
                changeMonth: true,
                changeYear: true,
                minDate: "01/01/1990",
                maxDate: new Date(),
            }).mask("99/99/9999");

            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingClaimChecks").val(), "divClaimCheckParent", "FilterClaimChecks");
            if ($("[id$='hdnTotalRows']").val() > 0) {
                $("#divClaimCheckParent .spanInfo").html("Showing " + $("#claimChecksList tr:first").children().first().html() + " to " + $("#claimChecksList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
            }

            //Claim list paging.
            GeneratePaging($("[id$='hdnTotalRowsClaimList']").val(), $("#ddlPagingClaimList").val(), "divClaimListParent", "FilterClaimList");
            if ($("[id$='hdnTotalRowsClaimList']").val() > 0) {
                $("#divClaimListParent .spanInfo").html("Showing " + $("#claimInfoList tr:first").children().first().html() + " to " + $("#claimInfoList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsClaimList']").val() + " entries");
            }

            if (GetQueryString("ClaimId") != undefined) {
                $("#divClaimsStatusCombo").find("#ulClaimsStatus input").prop("checked", true)
                $("#divClaimsStatusCombo").find(".selectedText").html("All");
                // $("#claimInfoList tr:first .postPayemtIcon").click();
            }


            $("#txtCheckAmount , #txtPostedAmount").keypress(function (e) {
                debugger
             
                if (window.event)

                    code = e.keyCode;
                else code = e.which;

                if ((code >= 48 && code <= 57) || code == 46 || code == 13) {
                    FilterPaymentsOnEnter(e);
                    return true;
                }

                else
                    return false;
            });

        });

      

        function FilterSorting(elem, SortByColumn) {
            SetSortBy(elem, SortByColumn);
            FilterClaimChecks(0, true);
        }

    
        function FilterResult(Filter)
        {
          
            if ($("[id$='PostRb']").is(":checked")) {
                _DateType = "Post";
            }
            else if (($("[id$='DOSRb']").is(":checked"))) {
                _DateType = "DOS";
            }
            //end
            if ($("[id$='ddldate']").val()=="MonthToDate") {
                _ddldate = "MonthToDate";
            }
            else if ($("[id$='ddldate']").val()=="LastMonth") {
                _ddldate = "LastMonth";
            }
            else if ($("[id$='ddldate']").val()=="YearToDate") {
                _ddldate = "YearToDate";
            }
            else if ($("[id$='ddldate']").val() == "last3month") {
                _ddldate = "Last3Month";
            }
            else if ($("[id$='ddldate']").val() == "selectdate")
            {
                _ddldate = "selectdate";
                 _DateFrom = $("[id$='txtFromDate']").val();
                 _DateTo = $("[id$='txtToDate']").val();

                if (_DateFrom == "" && _DateTo == "") {
                    $("[id$='txtFromDate']").css("border-color", "red");
                    $("[id$='txtToDate']").css("border-color", "red");
                   
                    return;
                }
                if (_DateFrom == "" && _DateTo != "") {
                    $("[id$='txtFromDate']").css("border-color", "red");
                    $("[id$='txtToDate']").css("border-color", "#c4c4c4");

                    return;
                }

                if (_DateFrom != "" && _DateTo == "") {
                    $("[id$='txtToDate']").css("border-color", "red");
                    $("[id$='txtFromDate']").css("border-color", "#c4c4c4");

                    return;
                }
                else {
                    $("[id$='txtFromDate']").css("border-color", "#c4c4c4");
                    $("[id$='txtToDate']").css("border-color", "#c4c4c4");

                }
            }

            _ddlinsurance = $("[id$='ddlinsurance'] option:selected").text();
            _ddlProvider = $("[id$='ddlBillingProvider']").val();
            debugger;
            
            var startDate = new Date(_DateFrom).toString("dd-mm-yyyy");;
            var endDate = new Date(_DateTo).toString("dd-mm-yyyy");;

            if (new Date(_DateFrom) > new Date(_DateTo)) {

                $("[id$='txtFromDate']").css("border-color", "red");
                $("[id$='txtToDate']").css("border-color", "red");

                showErrorMessage("Date From can not be greater than date to");
                return;
            }
            if (Filter != "Filter") {
                FilterClaimChecks(0, true);

            }
        }
       
        
        var PageNumber;
  function FilterClaimChecks(pageNumber, paging) {
      debugger;
      FilterResult('Filter')
      PageNumber = pageNumber;
    var CheckNo = $.trim($("[id$='txtCheckNumber']").val());
    var CheckDate = $.trim($("[id$='txtCheckDate']").val());
    var PostDate = $.trim($("[id$='txtPostDate']").val());
    var CheckAmount = $.trim($("[id$='txtCheckAmount']").val());
    var PostedAmount = $.trim($("[id$='txtPostedAmount']").val());
    var Insurance = $.trim($("[id$='txtInsurance']").val());

    if (_ddlinsurance != "")
    {
        Insurance = $.trim(_ddlinsurance);
    }

    var ERA = $("[id$='chkERA']").is(":checked");
    var EOB = $("[id$='chkEOB']").is(":checked");
    var Unsettled = $("[id$='chkUnsettled']").is(":checked");
  
    var sortBy = _SortByColumn + " " + _SortByValue;
    var verified = $("#ddlVerified").val();


    $.post(_ResolveUrl + "ProviderPortal/Payment/CallBacks/PaymentFilterHandler.aspx", {
        ERA: ERA, EOB: EOB, Unsettled: Unsettled, CheckNo: CheckNo, CheckDate: CheckDate,
        PostDate: PostDate, CheckAmount: CheckAmount, PostedAmount: PostedAmount, Insurance: Insurance, Rows: $("#ddlPagingClaimChecks").val(),
        pageNumber: pageNumber, SortBy: sortBy, verified: verified, action: "FilterGrid",
        _DateType: _DateType, _DateFrom: _DateFrom, _DateTo: _DateTo, _ddldate: _ddldate,_ddlProvider:_ddlProvider

    }, function (data) {
       // SetClaimChecksGrid(data, pageNumber, paging);
       var returnHtml = data;
       var start = data.indexOf("###StartClaimChecks###") + 22;
       var end = data.indexOf("###EndClaimChecks###");
       $("#claimChecksList").html(returnHtml.substring(start, end));

       var startRowsCount = data.indexOf("###StartClaimChecksTotalRow###") + 30;
       var endRowsCount = data.indexOf("###EndClaimChecksTotalRow###");
       $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

  
       var chkamount = $("[id$='hdnchkamount']").val();
       var postamount = $("[id$='hdnpostamount']").val();

      

       $("[id$='lblchkamount']").text(chkamount);
       $("[id$='lblPostamount']").text(postamount);

      if (paging == true) {
           GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingClaimChecks").val(), "divClaimCheckParent", "FilterClaimChecks");
       }

       if ($("[id$='hdnTotalRows']").val() > 0) {
           $("#divClaimCheckParent .spanInfo").html("Showing " + $("#claimChecksList tr:first").children().first().html() + " to " + $("#claimChecksList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
       }
    });
}

  function SetSortBy(elem, SortByColumn) {
            debugger;
            _SortByColumn = SortByColumn;
            _SortByValue = $.trim($(elem).attr("class").split(" ")[0]);

            $(elem).siblings().find(".icon").attr("class", "icon");

            if (_SortByValue == "asc" || _SortByValue == "") {
                _SortByValue = "desc";
                $(elem).find(".icon").removeClass("asc").addClass("desc").addClass("filterIcon");

            }
            else {
                _SortByValue = "asc";
                $(elem).find(".icon").removeClass("desc").addClass("asc").addClass("filterIcon");

            }

            $(elem).removeAttr("class");
            $(elem).addClass(_SortByValue).addClass("sortable-header");
        }

//Rizwan kharal  End
  function PrintCheckInfo(elem) {
      debugger;
    var CurrentRow = $(elem).closest("tr");
    var claimCheckId = $.trim(CurrentRow.find(".hdnClaimCheckId").val());
      var PaymentType = $.trim(CurrentRow.find(".hdnPaymentType").val());
      var _filename = '';
      var _filepath = '';
      var Action = "";
      if (PaymentType != "ERA") {
          debugger;
          //$(".divmesg").html("payment type is not era").removeclass("success").addclass("warning").fadein(2000).fadeout(10000);
          // return;
          Action = "EOBDetail"
      }
      else if(PaymentType == "ERA") {
          Action = "ERADetail";
      }
  

      $.post(_ResolveUrl + "ProviderPortal/Payment/CallBacks/ERAClaimsPrintHandler.aspx", { action: Action, ClaimCheckId: claimCheckId }, function (data) {
          var returnHtml = data;
          if (Action == "ERADetail") {
              var start = data.indexOf("###StartERAClaims###") + 20;
              var end = data.indexOf("###EndERAClaims###");
              $("#divERAClaimsPrint").html(returnHtml.substring(start, end));

              $("#divERAClaimsPrint").dialog({
                  width: 960,
                  modal: true,
                  title: "ERA Claims Print",
                  open: function () {
                      $(".ui-widget-overlay").last().css("z-index", "9999999");
                      $(".ui-dialog").last().css("z-index", "99999999");
                  },
                  buttons: {
                      Print: function () {
                          printHtml("divERAClaimsCheckDetailPrint");
                          $(this).dialog("destroy");
                          $("#divERAClaimsCheckDetailPrint").hide();
                          $("#divERAClaimsPrint").hide();
                          $("#divERAClaimsPrint").css("display", "none");
                      },
                      Close: function () {
                          $(this).dialog("destroy");
                          $("#divERAClaimsCheckDetailPrint").hide();
                          $("#divERAClaimsPrint").hide();
                          $("#divERAClaimsPrint").css("display", "none");
                      }
                  }



              });
          }
          else if (Action == "EOBDetail" && PaymentType == 'PAT') {
              debugger
              var start = data.indexOf("###StartEOBDetails###") + 21;
              var end = data.indexOf("###EndEOBDetails###");
              $("#divERAClaimsPrint").html(returnHtml.substring(start, end));
              _filename = $("#hdnFileName").val();
              _filepath = $("#hdnFileLocation").val();
              ViewFile("EmbedImage", _filepath, _filename);
              //$("#viewer").attr('src', "C:\Users\Khayyam.adeel\Documents\GitHub\WebEMR\PracticeDocuments"+'"\"' +_filepath);
              //$("#iframe").css('display', '');



              $("#divERAClaimsPrint").dialog({
                  width: 960,
                  modal: true,
                  title: "EOB Claims Print",
                  open: function () {
                      $(".ui-widget-overlay").last().css("z-index", "9999999");
                      $(".ui-dialog").last().css("z-index", "99999999");
                  },
                  buttons: {
                      Print: function () {
                          printHtml("divERAClaimsCheckDetailPrint");
                          $(this).dialog("destroy");
                          $("#divERAClaimsCheckDetailPrint").hide();
                          $("#divERAClaimsPrint").hide();
                          $("#divERAClaimsPrint").css("display", "none");
                      },
                      Close: function () {
                          $(this).dialog("destroy");
                          $("#divERAClaimsCheckDetailPrint").hide();
                          $("#divERAClaimsPrint").hide();
                          $("#divERAClaimsPrint").css("display", "none");
                      }
                  }
              });
          }
          if (Action == "EOBDetail" && PaymentType == 'EOB') {
              var start = data.indexOf("###StartEOBDetails###") + 21;
              var end = data.indexOf("###EndEOBDetails###");
              $("#divERAClaimsPrint").html(returnHtml.substring(start, end));
              $("#divERAClaimsPrint").hide();
              _filename = $("#hdnFileName").val();
              _filepath = $("#hdnFileLocation").val();
                  ViewFile("DirectImage", _filepath, _filename);
              }

          
          
    })
}
function ViewFile(elem, path, file) {
    debugger;
    //var file = $(elem).closest('tr').find('#hdnFileName').val();
    //var path = $(elem).closest('tr').find('#hdnFileLocation').val();
    var documentFile = '' +
        '<div class="patient-document-files-wrapper">' +
        GetFileLink1(file, path) +
        '<input type="hidden" class="hdnDocumentId" value="0" />' +
        '<input type="hidden" class="hdnDocumentPath" value="' + path + '" />' +
        '<input type="hidden" class="hdnOriginalFileName" value="' + file + '" />' +
        '<input type="hidden" class="hdnDeleted" value="false" />' +
        '</div>';
    if (elem == "EmbedImage") {
        $("#Right").html('');
        $("#Right").append(documentFile);

    }
    else if (elem == "DirectImage") {
        ShowImage(documentFile);
    }
    
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
        var fileformate = $.trim(path.substring(path.length - 3, path.length));


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
function ShowImage(documentFile) {
    debugger;
    $("#divShowImage").html("");
    $("#divShowImage").append(documentFile);
    $("#divShowImage").dialog({
        resizable: false,
        title: "Confirmation",
        width: 800,
        modal: true,
        open: function () {
            $(".ui-dialog-content").addClass('MinMaxheight');
        },
        buttons: {
            Close: function () {
                $(this).dialog('close');
            }
        },
    });
    
    $(".spndelete").hide();
    //$(".spndownload").hide();
}
function GetFileLink1(file, path) {
    var fileLink = "";
    UploadedFileAutoFill(file, path);
    var fileType = $.trim(path.substring(path.length - 3, path.length));
    fileType = fileType.toLocaleLowerCase();

    if ($.inArray(fileType, arrFileTypes) < 0) {
        if (fileType == "pdf") {
            fileLink = '' +
                '<embed src="' + path + '" width="400" height="400" alt="pdf">' +
                '<div class="hover-action-div">' +
                //'<span class="spndelete" onclick="DeleteAttachment1(this)" style="margin-left: 4px;" title="Delete"></span>' +
                '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>' +
                '</div>';
        }
        else {
            fileLink = '' +
                '<a href="' + path + '" style="float: left; color: #00F; margin: 0 5px 0 0;" target="_blank">' + file + '</a>' +
                //'<span class="spndelete" onclick="DeleteAttachment1(this)" style="margin-left: 4px;" title="Delete"></span>' +
                '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>';
        }
    }
    else {
        fileLink = '' +
            '<img style="width:100%" src="' + path + '" />' +
            '<div class="hover-action-div">' +
            //'<span class="spndelete" onclick="DeleteAttachment1(this)" style="margin-left: 4px;" title="Delete"></span>' +
            '<span class="spndownload" onclick="DownloadPatientDocumentFile(this)" style="margin-left: 4px;" title="Download"></span>' +
            '</div>';
    }

    return fileLink;
}

//Rizwan kharal  Start
// 14 Nov 2017
// verification of check is received are not

function VerifyUpdateTrue(pageNumber, paging)
{
    debugger;
    var sortBy = _SortByColumn + " " + _SortByValue;
    var ERA = $("[id$='chkERA']").is(":checked");
    var EOB = $("[id$='chkEOB']").is(":checked");
    var Unsettled = $("[id$='chkUnsettled']").is(":checked");
    $.post(_ResolveUrl + "ProviderPortal/Payment/CallBacks/PaymentFilterHandler.aspx", { ERAs: ERA, EOBs: EOB, Unsettleds: Unsettled, action: "true", MasterId: MasterId, Rowss: $("#ddlPagingClaimChecks").val(), pageNumbers: pageNumber, SortBys: sortBy }, function (data) {

        var returnHtml = data;
        var start = data.indexOf("###StartClaimChecks###") + 22;
        var end = data.indexOf("###EndClaimChecks###");
        $("#claimChecksList").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartClaimChecksTotalRow###") + 30;
        var endRowsCount = data.indexOf("###EndClaimChecksTotalRow###");
        $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingClaimChecks").val(), "divClaimCheckParent", "FilterClaimChecks");
        }

        if ($("[id$='hdnTotalRows']").val() > 0) {
            $("#divClaimCheckParent .spanInfo").html("Showing " + $("#claimChecksList tr:first").children().first().html() + " to " + $("#claimChecksList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        }
        $.trim($("[id$='txtCheckNumber']").val(""));
        $.trim($("[id$='txtCheckDate']").val(""));
        $.trim($("[id$='txtPostDate']").val(""));
        $.trim($("[id$='txtCheckAmount']").val(""));
        $.trim($("[id$='txtPostedAmount']").val(""));
        $.trim($("[id$='txtInsurance']").val(""));
        $("#ddlVerified").val("")

    }).done(function () {

        $(".divMesgVreified").css("display", "none");
    });

}
function VerifyUpdatefalse(pageNumber, paging) {
    debugger;
    var sortBy = _SortByColumn + " " + _SortByValue;
    var ERA = $("[id$='chkERA']").is(":checked");
    var EOB = $("[id$='chkEOB']").is(":checked");
    var Unsettled = $("[id$='chkUnsettled']").is(":checked");
    $.post(_ResolveUrl + "ProviderPortal/Payment/CallBacks/PaymentFilterHandler.aspx", { ERAs: ERA, EOBs: EOB, Unsettleds: Unsettled, action: "false", MasterId: MasterId, Rowss: $("#ddlPagingClaimChecks").val(), pageNumbers: pageNumber, SortBys: sortBy }, function (data) {

        var returnHtml = data;
        var start = data.indexOf("###StartClaimChecks###") + 22;
        var end = data.indexOf("###EndClaimChecks###");
        $("#claimChecksList").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartClaimChecksTotalRow###") + 30;
        var endRowsCount = data.indexOf("###EndClaimChecksTotalRow###");
        $("[id$='hdnTotalRows']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));
        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingClaimChecks").val(), "divClaimCheckParent", "FilterClaimChecks");
        }

        if ($("[id$='hdnTotalRows']").val() > 0) {
            $("#divClaimCheckParent .spanInfo").html("Showing " + $("#claimChecksList tr:first").children().first().html() + " to " + $("#claimChecksList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRows']").val() + " entries");
        }
        $.trim($("[id$='txtCheckNumber']").val(""));
        $.trim($("[id$='txtCheckDate']").val(""));
        $.trim($("[id$='txtPostDate']").val(""));
        $.trim($("[id$='txtCheckAmount']").val(""));
        $.trim($("[id$='txtPostedAmount']").val(""));
        $.trim($("[id$='txtInsurance']").val(""));
        $("#ddlVerified").val("")
    }).done(function () {

        $(".divMesgVreified").css("display", "none");
    });






}
function DownloadPatientDocumentFile(elem) {
    debugger
    var filePath = $(elem).closest(".patient-document-files-wrapper").find(".hdnDocumentPath").val();
    var fileName = $(elem).closest(".patient-document-files-wrapper").find(".hdnOriginalFileName").val();
    saveToDisk(filePath, fileName);
}

var MasterId;
var Pagenumber;
function CheckVerifyPopup(ERAMasterId)
{
    MasterId = ERAMasterId;
    debugger;
    $.post(_ResolveUrl + "ProviderPortal/Controls/MessagePopUp.aspx", {}, function (data) {
        debugger
        var returnHtml = data;
        var start = data.indexOf("###StartChequeVerification###") + 35;
        var end = data.indexOf("###EndChequeVerification###");
        $("#MessagePopUp").html(returnHtml.substring(start, end));
       

        $("#MessagePopUp").dialog({
            width: 310,
            modal: true,
            title: "Cheque Verification",
            position: 'center',

            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");

            },
            buttons: {
                Yes: function () {
                    debugger
                    VerifyUpdateTrue(PageNumber, true);
                    $(this).dialog("destroy");
                    $("#MessagePopUp").hide();
                },
                No: function () {
                    debugger
                    VerifyUpdatefalse(PageNumber, true);
                    $(this).dialog("destroy");
                    $("#MessagePopUp").hide();
                }
            }
        });
    }).done(function () {
     
       
    });


}

//Added By Rizwan kharal 3August2018

function FilterPaymentsOnEnter(event) {
    debugger;
    var a = event.which || event.keyCode;
    if (a == 13) {
        
            FilterClaimChecks(0, true);
        
    }
    else {
      return
    }

}

function showErrorMessage(mesg) {
    debugger
    $(".divMesg").css("display", "block");
    $(".divMesg").html(mesg).removeClass("success").addClass("warning").fadeIn(2000).fadeOut(5000);
}
function ExportReportPayments(fileNameFromFile, elem, divid) {
   
    debugger;
    var printdd = $(elem).attr('id');


   

    var divId1 = '#' + divid;
    var data = $(divId1).html();
    $("#ForPrintDiv").html(data);
    $("#ForPrintDiv").find("#Maintr").hide();
    $("#ForPrintDiv").find("#printtr").show();
    $("#ForPrintDiv").find(".Search").html("");
    $("#ForPrintDiv").find(".Search").hide();
    $("#ForPrintDiv").find(".hidetdclass").html("");
    $("#ForPrintDiv").find(".hidetdclass").hide();
  
    
    
    var result = $("#ForPrintDiv").html();

    var divId = '#' + divid;

    
    $(divId).find('.center').css("position", "unset");

    var ddlValue = $('#' + printdd).val();
    var filter_name = "";
    if (fileNameFromFile != "") {
        filter_name = fileNameFromFile;
    }
    else {
        filter_name = filename;
    }

  
    var filtername_1 = filter_name.substring(0, filter_name.length - 5)
    var fullDate = new Date()
    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);
    var currentDate = fullDate.getDate() + "/" + twoDigitMonth + "/" + fullDate.getFullYear();



    if (ddlValue == "Excel") {
        debugger;
        $(".Ins_TdAction").remove();
        let file = new Blob([$("#ForPrintDiv").html()], { type: "application/vnd.ms-excel" });
        let url = URL.createObjectURL(file);
        let a = $("<a />", {
            href: url,
            download: filtername_1 + " _ " + currentDate + ".xls"
        }).appendTo("body").get(0).click();
        $('#tblInsurancePortal thead th:last-child').after('<th class="asc InsTdAction Ins_TdAction"><span class="report-column-title">Action</span><span></span></th>');
        event.preventDefault();
    }
      
    else if (ddlValue == "PDF") {
        $(".InsTdAction").hide();
        var PdfHtml = $("#ForPrintDiv").html();
        var htmlToPrint = '' +
       '<style type="text/css">' +
       'table, th, table td {' +
       'Text-align:center;' +
       'border:1px solid #000;' +
        'border-collapse: collapse;' +
       'padding;3.5em;' +
       'position;3.5em;' +
       '}' +
       '</style>';
        htmlToPrint += PdfHtml;
        newWin = window.open("");
        newWin.document.write(htmlToPrint);
        $(".InsTdAction").show();
        newWin.print();
        newWin.close();

    }
       
    else if (ddlValue == "Word") {
        $(".InsTdAction").hide();
        let file = new Blob([$("#ForPrintDiv").html()], { type: "application/vnd.document" });
        let url = URL.createObjectURL(file);
        let a = $("<a />", {
            href: url,
            download: filtername_1 + " _ " + currentDate + ".doc"
        }).appendTo("body").get(0).click();
        $(".InsTdAction").show();
        event.preventDefault();
    }

    $("#ForPrintDiv").html("");
    $("#ForPrintDiv").hide();
}