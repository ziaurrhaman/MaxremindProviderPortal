
var _IconSubscriber;

function LoadSubscriberDialog(elem) {
    _IconSubscriber = $(elem);
    
    $.post(_ControlPath + "/SubscriberSearch.aspx", { PriSecOthType: _InsuranceTypeMaster }, function (data) {
        var start = data.indexOf(" ###StartSubscriberSearch###") + 28;
        var end = data.indexOf(" ###EndSubscriberSearch###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#SubscriberSearch").html(returnHtml)
        .promise()
        .done(function () {
            GeneratePaging($("[id$='hdnSubscriberTotalRows']").val(), $("#ddlPagingSubscriber").val(), "divSubscriber", "SubscriberSearchResult");
            
            if ($("[id$='hdnSubscriberTotalRows']").val() > 0) {
                $("#divSubscriber .spanInfo").html("Showing " + $("#subscriberList tr:first").children().first().html() + " to " + $("#subscriberList tr:last").children().first().html() + " of " + $("[id$='hdnSubscriberTotalRows']").val() + " entries");
            }
            
            $("#SubscriberSearch").dialog({ modal: true, width: '900', title: 'Search Subscriber' });
            
            $("[id$='txtSubscriberDOB']").datepicker({
                yearRange: "-110:+0",
                maxDate: new Date(),
                onSelect: function () {
                    SubscriberSearchResult(0, true);
                }
            }).mask("99/99/9999");
        });
    });
}

function SubscriberSearchResult(pageNumber, paging) {
    var params = {
        lastName: $("[id$='txtSubscriberLastName']").val(),
        firstName: $("[id$='txtSubscriberFirstName']").val(),
        subscriberGender: $("[id$='ddlSubscriberGender']").val(),
        subscriberDOB: $("[id$='txtSubscriberDOB']").val(),
        subscriberAddress: $("[id$='txtSubscriberAddress']").val(),
        pageNumber: pageNumber,
        rows: $("[id$='ddlPagingSubscriber']").val()
    };
    
    $.post(_ControlPath + "/CallBacks/FilterSubscriberHandler.aspx", params, function (data) {
        var start = data.indexOf("###SubscriberListStart###") + 25;
        var end = data.indexOf("###SubscriberListEnd###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#subscriberList").html(returnHtml)
        .promise()
        .done(function () { 
            
        });
        
        var startRowsCount = data.indexOf("###SubscriberListCountStart###") + 30;
        var endRowsCount = data.indexOf("###SubscriberListCountEnd###");
        returnHtml = $.trim(data.substring(startRowsCount, endRowsCount));
        
        $("[id$='hdnSubscriberTotalRows']").val(returnHtml);
        
        if (paging == true) {
            GeneratePaging($("[id$='hdnSubscriberTotalRows']").val(), $("#ddlPagingSubscriber").val(), "divSubscriber", "FilterSubscriber");
        }
        
        if ($("[id$='hdnSubscriberTotalRows']").val() > 0) {
            $("#divSubscriber .spanInfo").html("Showing " + $("#subscriberList tr:first").children().first().html() + " to " + $("#subscriberList tr:last").children().first().html() + " of " + $("[id$='hdnSubscriberTotalRows']").val() + " entries");
        }
    });
}

function CloseSubscriberSearchDialog() {
    $("#SubscriberSearch").dialog("close");
}

function AddSubscriber() {
    $.post(_ControlPath + "/CallBacks/AddSubscriberHandler.aspx", function (data) {
        var start = data.indexOf("###AddSubscriberStart###") + 24;
        var end = data.indexOf("###AddSubscriberEnd###");
        var returnHtml = $.trim(data.substring(start, end));
        
        $("#divSubscriberAdd").html(returnHtml)
        .promise()
        .done(function () {
            $("#divSubscriberAdd").dialog({
                title: 'Add Subscriber',
                modal: true,
                height: 'auto',
                width: 750
            });
            
            $("#txtAddSubscriberSSN").mask("999-99-9999");
            
            $(".phone").mask("(999) 999-9999");
            
            $("#txtAddSubscriberDOB").datepicker({
                changeMonth: true,
                changeYear: true,
                maxDate: new Date(),
                yearRange: "-110:+0"
            }).mask("99/99/9999");
        });
    });
}

function CloseSubscriberAddDialog() {
    $("#divSubscriberAdd").dialog("close");
}


function SaveSubscriber() {
    debugger;
    /*if (!ValidateFormSubscriber("tblAddSubscriber")) {
        $(this).css("border-color", "red");
        showErrorMessage("");
        return false;
    }*/
    if ($("#txtAddSubscriberFirstName").val() == "")
    {
        $("#txtAddSubscriberFirstName").css("border-color", "red");
        showErrorMessage("");
        return false;
    }
    else if ($("#txtAddSubscriberLastName").val() == "") {
        $("#txtAddSubscriberLastName").css("border-color", "red");
            showErrorMessage("");
            return false;
    }
    else if ($("#txtAddSubscriberDOB").val() == "") {
        $("#txtAddSubscriberDOB").css("border-color", "red");
        showErrorMessage("");
        return false;
    }
    else if ($("#txtAddSubscriberAddress").val() == "") {
        $("#txtAddSubscriberAddress").css("border-color", "red");
        showErrorMessage("");
        return false;
    }
    else if ($("#txtAddSubscriberCity").val() == "") {
        $("#txtAddSubscriberCity").css("border-color", "red");
        showErrorMessage("");
        return false;
    }
    else {
        var objSubscriber = new Object();

        objSubscriber.SubscriberId = $("[id$='hdnSubscriberId']").val();

        objSubscriber.FirstName = $("[id$='txtAddSubscriberFirstName']").val();
        objSubscriber.MiddleName = $("[id$='txtAddSubscriberMiddleName']").val();
        objSubscriber.LastName = $("[id$='txtAddSubscriberLastName']").val();
        objSubscriber.DateOfBirth = $("[id$='txtAddSubscriberDOB']").val();
        objSubscriber.SSN = $("[id$='txtAddSubscriberSSN']").val();
        objSubscriber.Gender = $("[id$='ddlAddSubscriberGender']").val();
        objSubscriber.MaritalStatus = $("[id$='ddlAddSubscriberMaritalStatus']").val();
        objSubscriber.Address = $("[id$='txtAddSubscriberAddress']").val();
        objSubscriber.Zip = $("[id$='txtAddSubscriberdZip']").val();
        objSubscriber.City = $("[id$='txtAddSubscriberCity']").val();
        objSubscriber.State = $("[id$='ddlAddSubscriberState']").val();
        objSubscriber.HomePhone = $("[id$='txtAddSubscriberHomePhone']").val();
        objSubscriber.Cell = $("[id$='txtAddSubscriberCell']").val();
        objSubscriber.WorkPhone = $("[id$='txtAddSubscriberWorkPhone']").val();
        objSubscriber.Ext = $("[id$='txtAddSubscriberExt']").val();
        objSubscriber.Email = $("[id$='txtAddSubscriberEmail']").val();

        var pageNumber = $(".PageButtons li.current a").html() != undefined ? (parseInt($(".PageButtons li.current a").html().replace("<b>", "").replace("</b>", "") - 1)) : 0;

        var params = {
            objSubscriber: JSON.stringify(objSubscriber),
            lastName: $("[id$='txtSubscriberLastName']").val(),
            firstName: $("[id$='txtSubscriberFirstName']").val(),
            subscriberGender: $("[id$='ddlSubscriberGender']").val(),
            subscriberDOB: $("[id$='txtSubscriberDOB']").val(),
            subscriberAddress: $("[id$='txtSubscriberAddress']").val(),
            pageNumber: pageNumber,
            rows: $("[id$='ddlPagingSubscriber']").val()
        };

        $.post(_ControlPath + "/CallBacks/SubscriberSearchSaveHandler.aspx", params, function (data) {
            showSuccessMessage(_msg_Created);

            var start = data.indexOf("###SubscriberListStart###") + 25;
            var end = data.indexOf("###SubscriberListEnd###");
            var returnHtml = $.trim(data.substring(start, end));

            $("#subscriberList").html(returnHtml);

            var startRowsCount = data.indexOf("###SubscriberListCountStart###") + 30;
            var endRowsCount = data.indexOf("###SubscriberListCountEnd###");
            returnHtml = $.trim(data.substring(startRowsCount, endRowsCount))

            $("[id$='hdnSubscriberTotalRows']").val(returnHtml);

            GeneratePaging($("[id$='hdnSubscriberTotalRows']").val(), $("#ddlPagingSubscriber").val(), "divSubscriber", "SubscriberSearchResult");

            if ($("[id$='hdnSubscriberTotalRows']").val() > 0) {
                $("#divSubscriber .spanInfo").html("Showing " + $("#subscriberList tr:first").children().first().html() + " to " + $("#subscriberList tr:last").children().first().html() + " of " + $("[id$='hdnSubscriberTotalRows']").val() + " entries");
            }

            CloseSubscriberAddDialog();
        });
    }
}

function PopulateSubscriberDetails(elem) {
    debugger;
    var CurrentRow = $(elem).closest("tr");
    
    var SubscriberId = CurrentRow.find(".hdnSubscriberId").val();
    
    var LastName = $.trim(CurrentRow.find("td").eq(1).html());
    var FirstName = $.trim(CurrentRow.find("td").eq(2).html());
    
    _IconSubscriber.closest("table").find(".hdnSubscriberId").val(SubscriberId);
    _IconSubscriber.closest("table").find(".txtSubscriberLastName").val(LastName);
    _IconSubscriber.closest("table").find(".txtSubscriberFirstName").val(FirstName);
    
    CloseSubscriberSearchDialog();
}