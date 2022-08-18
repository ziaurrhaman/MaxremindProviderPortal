

function Initialize_PTL_Patient() {
    var dateOfBirthMin = new Date();
    dateOfBirthMin.setYear(dateOfBirthMin.getFullYear() + 1);

    $("[id$='txtDateOfBirthFilterPatient']").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        yearRange: "-110:+0",
        onSelect: function (date, obj) {
            FilterPatient(0, true);
        }
    }).mask("99/99/9999");
    
    GeneratePaging($("[id$='hdnTotalRowsPatient']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
    
    if ($("[id$='hdnTotalRowsPatient']").val() > 0) {
        $("#PatientContainer .spanInfo").html("Showing " + $("#tbodyPTLPatient tr:first").children().first().html() + " to " + $("#tbodyPTLPatient tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsPatient']").val() + " entries");
    }
}

function FilterPatient(pageNumber, paging) {
    var PatientId = $.trim($("#txtPatientIdFilterPatient").val()) == "" ? 0 : $.trim($("#txtPatientIdFilterPatient").val());

    var LastName = $.trim($("#txtLastNameFilterPatient").val());
    var FirstName = $.trim($("#txtFirstNameFilterPatient").val());
    var Gender = $.trim($("#ddlGenderFilterPatient").val());
    var DOB = $.trim($("[id$='txtDateOfBirthFilterPatient']").val());
    var Phone = $.trim($("#txtPhoneFilterPatient").val());
    var Address = $.trim($("#txtAddressFilterPatient").val());
    var PatientCondition = $.trim($("[id$='ddlPatientCondition']").val());
    var IsPTL = true;
    var PTLReasons = GetPTLReasons("ulPTLReasonFilterListPatient");

    var params = {
        PatientId: PatientId,
        LastName: LastName,
        FirstName: FirstName,
        Gender: Gender,
        Phone: Phone,
        Address: Address,
        PatientCondition: PatientCondition,
        DOB: (isDate(DOB) ? DOB : ""),
        IsPTL: IsPTL,
        PTLReasons: PTLReasons,
        Rows: $("#ddlPagingPatient").val(),
        PageNumber: pageNumber,
        SortBy: "FirstName",
        action: "PatientFilter"
    };

    $.post(_ControlPath + "/PTLHandler.aspx", params, function (data) {
        var start = data.indexOf("###StartPTLFilterPatient###") + 27;
        var end = data.indexOf("###EndPTLFilterPatient###");
        var returnHtml = $.trim(data.substring(start, end));

        $("#tbodyPTLPatient").hide();

        $("#tbodyPTLPatient").html(returnHtml)
        .promise()
        .done(function () {
            SetPTLReasons("Patient");
            $("#tbodyPTLPatient").show();
        });

        var startRowsCount = data.indexOf("###StartRowsCountPatient###") + 30;
        var endRowsCount = data.indexOf("###EndRowsCountPatient###");
        $("[id$='hdnTotalRowsPatient']").val($.trim(data.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsPatient']").val(), $("#ddlPagingPatient").val(), "PatientContainer", "FilterPatient");
        }

        if ($("[id$='hdnTotalRowsPatient']").val() > 0) {
            $("#PatientContainer .spanInfo").html("Showing " + $("#tbodyPTLPatient tr:first").children().first().html() + " to " + $("#tbodyPTLPatient tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsPatient']").val() + " entries");
        }
    });
}