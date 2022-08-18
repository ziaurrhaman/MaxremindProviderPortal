var _InsuranceCredentialingID = ""; var _InsuranceId = ""; var _Name = ""; var _TaxId = "";
var _ProviderId = ""; var _Source = "";
var _TargetDate = ""; var _GroupId = 0;
var _Remarks = ""; var _NPI = 0; var _ProviderPTAN = "";
var _Status = ""; var _Notes = ""; var _DocumentId = 0;
var _FileDocumentAttachmentsId = 0; var _SSN = "";


//Check form type add or edit form 
function AddEditInsuranceCredentialing(Type) {
    debugger;

    $.post("/ProviderPortal/InsuranceCredentialing/CallBacks/InsuranceCredentialingHandler.aspx", function (data) {
        debugger
        var Start = data.indexOf("###StartInsuranceCredentialing###") + 35;
        var End = data.indexOf("###EndInsuranceCredentialing###");
        var returnHtml = $.trim(data.substring(Start, End));
        $("#divAddEditInsurCred").css("display", "block");
        $("#divAddEditInsurCred").html(returnHtml);

        if (Type == "Edit") {

            $("#txtInsurance").val(_InsuranceCredentialingID);
            $("#inusranceid").val(_InsuranceId);
            $("#txtInsurance").val(_Name);
            $("[id$='ddlProciders']").val(_ProviderId);
            $("#ddlSource").val(_Source);
            $("#lblNpi").text(_NPI);
            $("#lblTax").text(_TaxId);
            $("#targetDate").val(_TargetDate);
            $("#txtGroupid").val(_GroupId);
            $("#txtNote").val(_Notes);
            $("#InsuCredentialId").val(_InsuranceCredentialingID);
            $("#ddlStatus").val(_Status);
            $("#txtRemarks").val(_Remarks);
            $("#txtProvider").val(_ProviderPTAN);
            $("#txtSSN").val(_SSN);
            debugger
            ViewDocument();

        }
        else if (Type == "Add") {
            OpenInsuranceDocumentForm();
        }

        $("#divAddEditInsurCred").dialog({
            width: 1150,
            modal: true,
            title: "Add/Edit Insurance Enrollment",
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {

                "Add/Edit": function () {

                    AddEditInsuCredential(Type);

                },
                "Close": function () {
                    $(this).dialog("destroy");
                    $("#divAddEditInsurCred").hide();

                }
            },
            close: function () {
                $(this).dialog("destroy");
                $("#divAddEditInsurCred").hide();

            }
        });
    });
}


function SetSearch(elem) {

    var a = event.which || event.keyCode;
    if (a == 13) {
        debugger;
        InsuranceFilter(elem);
    }
}

function InsuranceFilter() {
    debugger;
    var InsuranceName = $("[id$='txtInsurance']").val() || "";

    $.post("/ProviderPortal/InsuranceCredentialing/CallBacks/InsuranceCredentialingFilter.aspx", { InsuranceName: InsuranceName, Action: "InsuranceSearch" }, function (data) {
        debugger
        var Start = data.indexOf("###StartInsuFilter###") + 23;
        var End = data.indexOf("###EndInsuFilter###");
        var returnHtml = $.trim(data.substring(Start, End));

        $("#insuFilterDiv").html(returnHtml);
        $("#insuFilterDiv").show();
    });
}

function SelectInsuName(name, InsuId) {
    $("#txtInsurance").val(name);
    $("#inusranceid").val(InsuId);
    $("#insuFilterDiv").hide();
    $("#txtInsurance").css("border-color", "#c4c4c4");
}
//Send parameters to db
function AddEditInsuCredential(Type) {
    debugger
    var InsuCredentialId = $("#InsuCredentialId").val() || 0;

    var InsuranceId = $("#inusranceid").val();
    //var GroupCode = $("#TxtGrouPCode").val();
    var ddlProvider = $("[id$='ddlProciders'] option:selected").val();
    var source = $("#ddlSource option:selected").val();
    var npi = $("#lblNpi").text() || 0;
    var tax = $("#lblTax").text() || 0;
    var targetDate = $("#targetDate").val();
    var GroupId = $("#txtGroupid").val();
    var ProviderPTAN = $("#txtProvider").val();
    var SSN = $("#txtSSN").val();
    var remarks = $("#txtRemarks").val();
    //var GroupCodeDesc = $("#TxtGrouPCodeDesc").val();
    //var individualCode = $("#TxtIndividualCode").val();
    //var individualCodeDesc = $("#TxtIndividualCodeDesc").val();
    //var individualCode1 = $("#TxtIndividualCode1").val();
    //var individualCodeDesc1 = $("#TxtIndividualCodeDesc1").val();
    var Status = $("#ddlStatus").val();
    var Notes = $("#txtNote").val();
    var count = 0;
    $('.required1').each(function () {

        var check = $(this).val();
        if (check == "") {

            $(this).css("border-color", "red");
            count++;

        }
        else {
            $(this).css("border-color", "#c4c4c4");
        }
    });

    var startdate = $("#txtDocumentDate").val();
    //if (Date.parse(startdate) > Date.parse(targetDate)) {
    //$("<div></div>").html("Effective date must be greater then Start date.").dialog({
    //    width: 300,
    //    modal: true,
    //    title: "Information!",
    //    open: function () {
    //        $(".ui-widget-overlay").last().css("z-index", "9999999");
    //        $(".ui-dialog").last().css("z-index", "99999999");
    //    },
    //    buttons: {
    //        "Ok": function () {
    //            $(this).dialog("destroy");
    //        }
    //    },
    //    close: function () {
    //        $(this).dialog("destroy");

    //    }
    //});
    //return
    //}
    //Document Add

    var DocumentName = $("#txtDocumentName").val() || "";
    var DocumentUploadedName = $(".patient-document-files-wrapper").find(".hdnDocumentPath").val() || "";


    var listPatientDocumentAttachments = new Array();

    $("#divPatientDocumentsFilesInner .patient-document-files-wrapper").each(function () {
        var objPatientDocumentAttachments = new Object();

        objPatientDocumentAttachments.PatientDocumentAttachmentsId = $(this).find(".PracticeDocumentsId").val() || "";
        objPatientDocumentAttachments.DocumentPath = $(this).find(".hdnDocumentPath").val() || "";
        objPatientDocumentAttachments.OriginalFileName = $(this).find(".hdnOriginalFileName").val() || "";
        objPatientDocumentAttachments.Deleted = $(this).find(".hdnDeleted").val() || "";


        listPatientDocumentAttachments.push(objPatientDocumentAttachments);
    });


    if (InsuranceId == "") {
        count++;
        $("#txtInsurance").css("border-color", "red");
        $("#txtInsurance").val("");
        showErrorMessage("Please select Insuracne");
        return;
    }
    if (count > 0) {
        return;
    }


    else {
        $.post("/ProviderPortal/InsuranceCredentialing/CallBacks/InsuranceCredentialingFilter.aspx",
            {

                InsuCredentialId: InsuCredentialId,
                InsuranceId: InsuranceId,
                ddlProvider: ddlProvider,
                Source: source,
                NPI: npi,
                TAX: tax,
                Status: Status,
                Notes: Notes,
                TargetDate: targetDate,
                GroupId: GroupId,
                ProviderPTAN: ProviderPTAN,
                SSN: SSN,
                Remarks: remarks,
                Action: Type,
                DocumentName: DocumentName,
                DocumentUploadedName: DocumentUploadedName,
                DocumentId: _DocumentId || 0,
                FileDocumentAttachmentsId: _FileDocumentAttachmentsId || 0,
                listPatientDocumentAttachments: JSON.stringify(listPatientDocumentAttachments),

            }, function (data) {
                debugger
                var Start = data.indexOf("###StartInsuCredGrid###") + 28;
                var End = data.indexOf("###EndInsuCredGrid###");
                var returnHtml = $.trim(data.substring(Start, End));

                $("#tbodyGrid").html(returnHtml);



                GeneratePaging($("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val(), $("#ddlInsuranceCredentialingGrid").val(), "divContainer", "FilterInsuranceCredentialingGrid");

                if ($("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val() > 0) {

                    $("#divContainer .spanInfo").html("Showing " + $("#tbodyGrid tr:first").children().first().html() + " to "
                       + $("#tbodyGrid tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val() + " entries");
                }
                if (Type == "Add") {
                    showSuccessMessage("Insurance Credential Added Successfully!")
                }
                else if (Type == "Edit") {
                    showSuccessMessage("Insurance Credential Updated Successfully!")
                }
                $("#divAddEditInsurCred").dialog("close");



            });

    }
}


//Get parameters from clicked row and send it to AddEditInsuCredential(type=edit) for edit record and fil the form textboxes
function EditInsuCred(InsuranceCredentialingID, Name, InsuranceId, elem, Status, DocumentId) {
    debugger;

    var InsProviderId = $(elem).find(".hdnProviderId").val();
    var InsSource = $(elem).find(".hdnSource").val();
    var InsTargetDate = $(elem).find(".hdnTargetDate").val();
    var InsRemarks = $(elem).find(".hdnRemarks").val();
    var InsNPI = $(elem).find(".hdnNPI").val();
    var InsTaxId = $(elem).find(".hdnTaxId").val();
    var InsNotes = $(elem).find(".hdnInsEnNotes").val();
    var InsGroupId = $(elem).find(".hdnGroupId").val();
    var InsProviderPTAN = $(elem).find(".hdnProviderPTAN").val();
    var InsSSN = $(elem).find(".hdnSSN").val();
    _InsuranceCredentialingID = InsuranceCredentialingID;
    _InsuranceId = InsuranceId;
    _Name = $.trim(Name);
    //_GroupCode = $.trim(GroupCode);
    _ProviderId = $.trim(InsProviderId);
    _GroupId = $.trim(InsGroupId);
    _Source = $.trim(InsSource);
    _TargetDate = $.trim(InsTargetDate);
    _Remarks = $.trim(InsRemarks);
    _Status = Status;
    _NPI = $.trim(InsNPI);
    _TaxId = $.trim(InsTaxId);
    _ProviderPTAN = $.trim(InsProviderPTAN);
    _SSN = $.trim(InsSSN);
    _DocumentId = DocumentId;
    _FileDocumentAttachmentsId = DocumentId;
    AddEditInsuranceCredentialing("Edit");

    ClearFilterTextbox();

}
function DeleteInsuCred(InsuranceCredentialingID) {

    $("#divAddEditInsurCred").html("<span style='color:red;margin:5px'>Do you want to delete this record ?</span>").dialog({
        width: 350,

        modal: true,
        title: "Confirmation!",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {

            "Ok": function () {

                $.post("/ProviderPortal/InsuranceCredentialing/CallBacks/InsuranceCredentialingFilter.aspx",
                       {

                           InsuCredentialId: InsuranceCredentialingID,

                           Action: "Delete"

                       }, function (data) {
                           debugger
                           var Start = data.indexOf("###StartInsuCredGrid###") + 28;
                           var End = data.indexOf("###EndInsuCredGrid###");
                           var returnHtml = $.trim(data.substring(Start, End));

                           $("#tbodyGrid").html(returnHtml);

                           $("#divAddEditInsurCred").dialog("close");


                           GeneratePaging($("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val(), $("#ddlInsuranceCredentialingGrid").val(), "divContainer", "FilterInsuranceCredentialingGrid");


                           if ($("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val() > 0) {

                               $("#divContainer .spanInfo").html("Showing " + $("#tbodyGrid tr:first").children().first().html() + " to "
                                  + $("#tbodyGrid tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val() + " entries");
                           }

                           showSuccessMessage("Insurance Credential Deleted Successfully!")
                           ClearFilterTextbox();
                       });

            },
            "Cancel": function () {
                $(this).dialog("destroy");
                $("#divAddEditInsurCred").hide();
            }
        },
        close: function () {
            $(this).dialog("destroy");
            $("#divAddEditInsurCred").hide();
        }
    });



}

function InsuranceCredentialingSetSearch(event) {
    debugger
    var a = event.which || event.keyCode;
    if (a == 13) {

        FilterInsuranceCredentialingGrid(0, true);
        $("#FilterIconbtn").css("color", "#065172");

    }
    else {

        $("#FilterIconbtn").css("color", "red");



    }
}

var individualCode1 = "";
var individualCodeDesc2 = "";
function FilterInsuranceCredentialingGrid(pagenumber, page) {
    debugger

    $.post("/ProviderPortal/InsuranceCredentialing/CallBacks/InsuranceCredentialingFilter.aspx",
                       {

                           InsuranceName: $("#txtInsuranceNameSearch").val(),
                           Source: $("#ddlSourceSearch").val(),
                           NIP: $("#txtNipIdSearch").val(),
                           TaxId: $("#txtTaxIdSearch").val(),
                           Provider: $("#txtProviderSearch").val(),
                           EffectiveDate: $("#txtEffectiveDate").val(),
                           StartDate: $("#txtStartDate").val(),
                           Notes: $("#txtNotesSearch").val(),
                           GroupId: $("#txtGroupId").val(),
                           ProviderPTAN: $("#txtProviderPTAN").val(),
                           Status: $("#ddlStatusSearch").val(),
                           PageNumber: pagenumber,
                           Rows: $("#ddlInsuranceCredentialingGrid").val(),
                           Remarks: $("#txtRemarksSearch").val(),
                           Action: "FilterGrid"

                       }, function (data) {
                           debugger
                           var Start = data.indexOf("###StartInsuCredGrid###") + 28;
                           var End = data.indexOf("###EndInsuCredGrid###");
                           var returnHtml = $.trim(data.substring(Start, End));

                           $("#tbodyGrid").html(returnHtml);
                           if (page == true) {
                               GeneratePaging($("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val(), $("#ddlInsuranceCredentialingGrid").val(), "divContainer", "FilterInsuranceCredentialingGrid");
                           }

                           if ($("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val() > 0) {

                               $("#divContainer .spanInfo").html("Showing " + $("#tbodyGrid tr:first").children().first().html() + " to "
                                  + $("#tbodyGrid tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsInsuranceCredentialingGrid']").val() + " entries");
                           }


                       });
}

function CloseInsuranceFilterdiv() {
    $("#insuFilterDiv").hide();
    $("#txtInsurance").val("");
}

function ClearFilterTextbox() {
    $("#txtInsuranceNameSearch").val("");
    $("#txtGroupCodeSearch").val("");
    $("#txtGroupCodeDescSearch").val("");
    $("#txtIndividualCodeSearch").val("");
    $("#txtIndividualCodeDescSearch").val("");
    $("#ddlStatusSearch").val("");

    $("#ddlInsuranceCredentialingGrid").val();
    $("#txtNotesSearch").val("");
}

function getNpiTaxId() {
    debugger
    var Source = $("#ddlSource option:selected").val();
    var ProviderId = $("[id$='ddlProciders'] option:selected").val();
    if (Source == "" || ProviderId == 0) {
        $("<div></div>").html("Select Provider first.").dialog({
            width: 300,
            modal: true,
            title: "Information!",
            open: function () {
                $(".ui-widget-overlay").last().css("z-index", "9999999");
                $(".ui-dialog").last().css("z-index", "99999999");
            },
            buttons: {
                "Ok": function () {
                    $(this).dialog("destroy");
                }
            },
            close: function () {
                $(this).dialog("destroy");

            }
        });
    }
    else {
         
        $.post("/ProviderPortal/InsuranceCredentialing/CallBacks/InsuranceCredentialingFilter.aspx", { Source: Source, ProviderId: ProviderId, Action: "loadNpiTax" }, function (data) {
            debugger
            var Start = data.indexOf("###StartNpiTax###") + 20;
            var End = data.indexOf("###EndNpiTax###");
            var returnHtml = $.trim(data.substring(Start, End));
            $("#divNpiTax").html(returnHtml);

            var npi = $("[id$='NPITXT']").val();
            var tax = $("[id$='TAXTXT']").val();
            $("[id$='lblNpi']").html(npi);
            $("[id$='lblTax']").html(tax);

            //alert($("#divNpiTax").html());
            //$("#txtNpi").val(npi);
            //$("#txtTax").val(tax);

        }).done(function () {


        });
    }
}

function viewSSN(elem) {
    debugger
    if ($(elem).closest("td").find(".Password").is(":Password")) {
        debugger
        $(elem).closest("td").find(".Password").removeAttr("type");
        $(elem).closest("td").find(".Password").attr('type', 'text');
    }
    else if ($(elem).closest("td").find(".Password").is(":text")) {

        $(elem).closest("td").find(".Password").removeAttr("type");
        $(elem).closest("td").find(".Password").attr('type', 'password');
    }
}

function ShowInsuranceCredentialing() {
    debugger;
    if (!checkModuleRights("InsuranceCredentialling")) {
        $("[id$='divRightsSettings']").html("You don't have rights to View Insurance Credentialing").show();
        $("#divUsers").hide();
        $("#UserRolesDiv").hide();
        $("#divTicketing").hide();
        $("#divUsersMain").hide();
        $("#divInsuranceEnrollment").hide();
        return false;
    }
    $("#title").html('Insurance Credentialing');
    $(".Tab-Content").hide();
    $("#divRightsSettings").hide();
    $.post("/ProviderPortal/InsuranceCredentialing/InsuranceCredentialing.aspx", function (data) {
        var start = data.indexOf("###StartInsuCredential###") + 27;
        var end = data.indexOf("###EndInsuCredential###");
        var returnHtml = $.trim(data.substring(start, end));
        $("#divInsuranceCredentialingWrapperId").html(returnHtml);
        $("#divUsers").hide();
        $("#UserRolesDiv").hide();
        $("#divTicketing").hide();
        $("#divUsersMain").hide();
        $("#divInsuranceEnrollment").hide();
        $("#divInsuranceCredentialingWrapperId").css("display", "block");
    });
}