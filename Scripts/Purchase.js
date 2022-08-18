



/*-----------------START--Supplier Entry-------------------*/

function loadSupplierEntryPage(recordId) {
    $.post("SupplierEntry.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#SupplierEntry").html($.trim(returnHtml.substring(start, end)));
    });
}

function saveGeneralInfoSupplierEntry() {

    if (!ValidateForm("divGeneralViewSupplierEntry")) {
        showErrorMessage("Error: Please fill all required fields.", "divContentsDetailsWrapper");
        return false;
    }

    var recordId = $("[id$='hdnRecordIdSupplierEntry']").val();
    var action = "SAVE";

    var objRecord = new Object();
    if (recordId != 0) {
        objRecord.SuppliersId = recordId;
        action = "UPDATE";
    }

    objRecord.SupplierName = $("[id$='txtNameSupplierEntry']").val();
    objRecord.GSTNo = $("[id$='txtGSTNoSupplierEntry']").val();
    objRecord.Website = $("[id$='txtWebsiteSupplierEntry']").val();
    objRecord.CurrencyId = $("[id$='ddlCurrencySupplierEntry']").val();
    objRecord.OurCustomerNo = $("[id$='txtOurCustomerNoSupplierEntry']").val();
    objRecord.PhoneNumber = $("[id$='txtPhoneSupplierEntry']").val();
    objRecord.SecondaryPhone = $("[id$='txtSecondaryPhoneSupplierEntry']").val();

    objRecord.BankAccount = $("[id$='txtBankAccountSupplierEntry']").val();
    objRecord.BankName = $("[id$='txtBankNameSupplierEntry']").val();
    objRecord.CreditLimit = $("[id$='txtCreditLimitSupplierEntry']").val();
    objRecord.PaymentTerms = $("[id$='ddlPaymentTermsSupplierEntry']").val();
    objRecord.PricesTaxIncluded = $("[id$='cbPriceContainTaxSupplierEntry']").is(":checked");

    objRecord.MailingAddress = $("[id$='txtMailingAddressSupplierEntry']").val();
    objRecord.PhysicalAddress = $("[id$='txtPhysicalAddressSupplierEntry']").val();
    objRecord.City = $("[id$='txtCitySupplierEntry']").val();
    objRecord.StateCode = $("[id$='ddlStateSupplierEntry']").val();
    objRecord.Zip = $("[id$='txtZipSupplierEntry']").val();

    objRecord.Notes = $("[id$='txtNotesSupplierEntry']").val();
    objRecord.Status = $("[id$='ddlStatusSupplierEntry']").val();

    $.post("CallBacks/SupplierHandler.aspx", { objRecord: JSON.stringify(objRecord), action: action }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");

        var recordId = $.trim(returnHtml.substring(start, end));
        if (recordId != "") {
            $("[id$='hdnRecordIdSupplierEntry']").val(recordId);
        }

        if (action == "SAVE") {
            showSuccessMessage("Success: Record saved!", "divContentsDetailsWrapper");
            $("#divAddEditRecordSupplierEntry").css("display", "none");
            $("#divRedirectMenuSupplierEntry").css("display", "");
        }
        else {
            showSuccessMessage("Success: Record updated!", "divContentsDetailsWrapper");
        }
    });
}

function redirectSupplierEntry(redirectTo) {
    if (redirectTo == "contacts") {
        $("[id$='linkTabSupplierContacts']").click();
        $("#divAddEditRecordSupplierEntry").css("display", "");
        $("#divGeneralViewSupplierEntry").css("display", "none");
        $("#divRedirectMenuSupplierEntry").css("display", "none");
    }
}

function showTabSupplierEntry(activeDiv, event) {

    var recordId = $("[id$='hdnRecordIdSupplierEntry']").val();
    if (activeDiv == "divContactsViewSupplierEntryContacts") {
        if (recordId != 0) {
            showHideTabs(activeDiv);
            $.post("SuppliersContacts.aspx", { SuppliersId: recordId }, function (data) {
                var returnHtml = data;
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");

                $("#divContactsViewSupplierEntryContacts").html($.trim(returnHtml.substring(start, end)));

                GeneratePaging($("[id$='hdnTotalRowsSupplierEntryContacts']").val(), $("#ddlPagingSupplierEntryContacts").val(), "GridContainerSupplierEntryContacts", "FilterRecordSupplierEntryContacts");
                if ($("[id$='hdnTotalRowsSupplierEntryContacts']").val() > 0)
                    $("#GridContainerSupplierEntryContacts .spanInfo").html("Showing " + $("#gridContentsSupplierEntryContacts tr:first").children().first().html() + " to " + $("#gridContentsSupplierEntryContacts tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSupplierEntryContacts']").val() + " entries");
            });
        }
        else {
            showErrorMessage("Please save supplier first.");
            event.stopPropagation();
        }
    }
    else {
        showHideTabs(activeDiv);
    }
}

function FilterRecordSupplierEntryContacts(pageNumber, paging) {

    var SuppliersId = $("[id$='hdnSuppliersId']").val();

    $.post("CallBacks/SupplierContactsFilterHandler.aspx", { Rows: $("#ddlPagingSupplierEntryContacts").val(), PageNumber: pageNumber, SortBy: "", SuppliersId: SuppliersId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsSupplierEntryContacts").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsSupplierEntryContacts']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsSupplierEntryContacts']").val(), $("#ddlPagingSupplierEntryContacts").val(), "GridContainerSupplierEntryContacts", "FilterRecordSupplierEntryContacts");
        }

        if ($("[id$='hdnTotalRowsSupplierEntryContacts']").val() > 0)
            $("#GridContainerSupplierEntryContacts .spanInfo").html("Showing " + $("#gridContentsSupplierEntryContacts tr:first").children().first().html() + " to " + $("#gridContentsSupplierEntryContacts tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSupplierEntryContacts']").val() + " entries");
    });
}

function addRecordSupplierEntryContacts() {

    var recordId = 0;

    $.post("CallBacks/SupplierContactsForm.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divAddNewRecordSupplierEntryContacts").html(returnHtml.substring(start, end));

        $("#divAddNewRecordSupplierEntryContacts").dialog({
            title: "Add New Record",
            width: "auto",
            buttons: {
                "Save": function () {
                    saveRecordSupplierEntryContacts("SAVE", 0);
                },
                "Cancel": function () {
                    $("#divAddNewRecordSupplierEntryContacts").dialog("close");
                }
            },
            close: function () {
                $("#divAddNewRecordSupplierEntryContacts").dialog("destroy");
            }
        });
    });
}

function editRecordSupplierEntryContacts(elem) {

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/SupplierContactsForm.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divAddNewRecordSupplierEntryContacts").html(returnHtml.substring(start, end));

        $("#divAddNewRecordSupplierEntryContacts").dialog({
            title: "Edit Record",
            width: "auto",
            buttons: {
                "Save": function () {
                    saveRecordSupplierEntryContacts("UPDATE", recordId);
                },
                "Cancel": function () {
                    $("#divAddNewRecordSupplierEntryContacts").dialog("close");
                }
            },
            close: function () {
                $("#divAddNewRecordSupplierEntryContacts").dialog("destroy");
            }
        });
    });
}

function saveRecordSupplierEntryContacts(action, recordId) {

    if (!ValidateForm("divAddNewRecordSupplierEntryContacts")) {
        showErrorMessage("Please fill all required fields.", "formSupplierEntryContact");
        return false;
    }

    var email = $("[id$='txtEmailSupplierEntryContacts']").val();
    if (!validateEmail(email)) {
        showErrorMessage("Please enter valid email.", "formSupplierEntryContact");
        return false;
    }

    var objRecord = new Object();

    if (recordId != 0) {
        objRecord.SuppliersContactsId = recordId;
    }

    objRecord.SuppliersId = $("[id$='hdnSuppliersId']").val();

    objRecord.FirstName = $("[id$='txtFirstNameSupplierEntryContacts']").val();
    objRecord.LastName = $("[id$='txtLastNameSupplierEntryContacts']").val();
    objRecord.Reference = $("[id$='txtReferenceSupplierEntryContacts']").val();
    objRecord.ContactActiveFor = $("[id$='txtContactActiveForSupplierEntryContacts']").val();
    objRecord.ContactPhone = $("[id$='txtPhoneSupplierEntryContacts']").val();
    objRecord.ContactSecondaryPhone = $("[id$='txtSecondaryPhoneSupplierEntryContacts']").val();
    objRecord.FaxNumber = $("[id$='txtFaxSupplierEntryContacts']").val();
    objRecord.Email = $("[id$='txtEmailSupplierEntryContacts']").val();

    objRecord.Address = $("[id$='txtAddressSupplierEntryContacts']").val();
    objRecord.DocumentLanguage = $("[id$='ddlDocumentLanguageSupplierEntryContacts']").val();
    objRecord.ContactNotes = $("[id$='txtNotesSupplierEntryContacts']").val();

    $.post("CallBacks/SupplierContactsHandler.aspx", { objRecord: JSON.stringify(objRecord), action: action }, function (data) {
        $("#divAddNewRecordSupplierEntryContacts").dialog("close");
        FilterRecordSupplierEntryContacts(0, true);

        if (action == "SAVE") {
            showSuccessMessage("Success: Record saved!", "divContentsDetailsWrapper");
        }
        else {
            showSuccessMessage("Success: Record updated!", "divContentsDetailsWrapper");
        }
    });
}

function deleteRecordSupplierEntryContacts(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (!isConfirm) {
        return;
    }

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/SupplierContactsHandler.aspx", { recordId: recordId, action: "DELETE" }, function (data) {
        FilterRecordSupplierEntryContacts(0, true);
        showSuccessMessage("Success: Record deleted!", "divContentsDetailsWrapper");
    });
}

/*-----------------END--Supplier Entry-------------------*/



/*-----------------START--Supplier List-------------------*/

function loadSupplierListPage() {
    $.post("Suppliers.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#SupplierList").html($.trim(returnHtml.substring(start, end)));

        GeneratePaging($("[id$='hdnTotalRowsSupplierList']").val(), $("#ddlPagingSupplierList").val(), "GridContainerSupplierList", "FilterRecordSupplierList");
        if ($("[id$='hdnTotalRowsSupplierList']").val() > 0)
            $("#GridContainerSupplierList .spanInfo").html("Showing " + $("#gridContentsSupplierList tr:first").children().first().html() + " to " + $("#gridContentsSupplierList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSupplierList']").val() + " entries");
    });
}

function FilterRecordSupplierList(pageNumber, paging) {

    $.post("CallBacks/SuppliersFilterHandler.aspx", { Rows: $("#ddlPagingSupplierList").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsSupplierList").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsSupplierList']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsSupplierList']").val(), $("#ddlPagingSupplierList").val(), "GridContainerSupplierList", "FilterRecordSupplierList");
        }

        if ($("[id$='hdnTotalRowsSupplierList']").val() > 0)
            $("#GridContainerSupplierList .spanInfo").html("Showing " + $("#gridContentsSupplierList tr:first").children().first().html() + " to " + $("#gridContentsSupplierList tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSupplierList']").val() + " entries");
    });
}

function deleteRecordSupplierList(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (!isConfirm) {
        return;
    }

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/SupplierHandler.aspx", { recordId: recordId, action: "DELETE" }, function (data) {
        FilterRecordSupplierList(0, true);
        showSuccessMessage("Success: Record deleted!", "divContentsDetailsWrapper");
    });
}

function editRecordSupplierList(elem) {
    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());
    loadContentPage('SupplierEntry', recordId);
}

/*-----------------END--Supplier List-------------------*/




/*-----------------START--Purchase Order Entry-------------------*/

function loadPurchaseOrderEntryPage(recordId) {
    $.post("PurchaseOrderEntry.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#PurchaseOrderEntry").html($.trim(returnHtml.substring(start, end)));
        readyPurchaseOrderEntryPage();
    });
}

function readyPurchaseOrderEntryPage() {
    $(".datepicker").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "2010:2099"
    });


    $("#txtItemCodePurchaseEntry").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "CallBacks/PurchaseOrderEntryHandler.aspx/FetchItemsListByCode",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                data: "{ 'itemCode':'" + request.term + "'}",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.ItemCode,
                            value: item.ItemCode,
                            Name: item.Name,
                            ItemsId: item.ItemsId,
                            Price: item.PurchasePrice
                        }
                    }));
                }
            });
        },
        minLength: 1,
        open: function () {
            $('.ui-autocomplete').css('width', '150px');
        },
        select: function (event, ui) {
            $("[id$='hdnItemsIdPurchaseEntry']").val(ui.item.ItemsId);
            $("[id$='txtItemNamePurchaseEntry']").val(ui.item.Name);
            $("[id$='txtItemPriceBeforePurchaseEntry']").val(ui.item.Price);

            calculateItemTotalPurchaseEntry($("[id$='txtItemCodePurchaseEntry']"));
        }
    });

    $("#txtItemNamePurchaseEntry").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "CallBacks/PurchaseOrderEntryHandler.aspx/FetchItemsListByName",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                data: "{ 'ItemName':'" + request.term + "'}",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.Name,
                            value: item.Name,
                            ItemCode: item.ItemCode,
                            ItemsId: item.ItemsId,
                            Price: item.PurchasePrice
                        }
                    }));
                }
            });
        },
        minLength: 1,
        open: function () {
            $('.ui-autocomplete').css('width', '150px');
        },
        select: function (event, ui) {
            $("[id$='hdnItemsIdPurchaseEntry']").val(ui.item.ItemsId);
            $("#txtItemCodePurchaseEntry").val(ui.item.ItemCode);
            $("[id$='txtItemPriceBeforePurchaseEntry']").val(ui.item.Price);

            calculateItemTotalPurchaseEntry($("[id$='txtItemCodePurchaseEntry']"));
        }
    });
}

function addPurchaseItemRow(elem) {

    calculateItemTotalPurchaseEntry(elem);
    var currentRow = $(elem).closest("tr");

    var itemRow = '<tr class="purchase-item-view-row">';
    itemRow += '<td>';
    itemRow += '<label class="item-label-itemCode-purchaseEntry">' + $("[id$='txtItemCodePurchaseEntry']").val() + '</label>';
    itemRow += '<input type="hidden" class="item-id-purchaseEntry" value="' + $("[id$='hdnItemsIdPurchaseEntry']").val() + '" />';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-itemName-purchaseEntry">' + $("[id$='txtItemNamePurchaseEntry']").val() + '</label>';
    itemRow += '</td>';
    itemRow += '<td align="right">';
    itemRow += '<label class="item-label-quantity-purchaseEntry">' + currentRow.find(".txtItemQuantityPurchaseEntry").val() + '</label>';
    itemRow += '</td>';
    itemRow += '<td align="center">';
    itemRow += '<label class="item-label-unit-purchaseEntry">' + $("[id$='ddlItemUnitPurchaseEntry']").val() + '</label>';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-stockRemaining-purchaseEntry">' + $.trim($("[id$='lblInstockPurchaseEntry']").html()) + '</label>';
    itemRow += '</td>';
    itemRow += '<td align="right">';
    itemRow += '<label class="item-label-received-purchaseEntry">' + $.trim($("[id$='lblReceivedPurchaseEntry']").html()) + '</label>';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-requiredDeliveryDate-purchaseEntry">' + $.trim($("[id$='txtRequiredDeliveryDate']").val()) + '</label>';
    itemRow += '</td>';
    itemRow += '<td align="right">';
    itemRow += '<label class="item-label-priceBeforeTax-purchaseEntry">' + $.trim($("[id$='txtItemPriceBeforePurchaseEntry']").val()) + '</label>';
    itemRow += '</td>';
    itemRow += '<td align="right">';
    itemRow += '<label class="lblItemTotalPurchaseEntry floatRight">' + $.trim($("[id$='lblItemTotalPurchaseEntry']").html()) + '</label>';
    itemRow += '</td>';
    itemRow += '<td align="center">';
    itemRow += '<span class="spanedit" title="Edit Item" style="margin: 0 5px 0 0;" onclick="editPurchaseItemRow(this);"></span>';
    itemRow += '<span class="spandelete" title="Delete Item" onclick="deletePurchaseItemRow(this);"></span>';
    itemRow += '</td>';
    itemRow += '</tr>';

    $(elem).closest("tr").before(itemRow);

    updateGrandTotalPurchaseEntry();

    resetPurchaseItemRow();

}

function editPurchaseItemRow(elem) {

    editCancelForAllItems();

    var currentRow = $(elem).closest("tr");

    var quantity = $.trim(currentRow.find(".item-label-quantity-purchaseEntry").html());
    _ItemQuantityPurchaseEntry = quantity;
    var quantityTextBox = '<input type="text" class="rightText txtItemQuantityPurchaseEntry" onkeypress="return validateDecimal(event, this);" onkeyup="calculateItemTotalPurchaseEntry(this);" value="' + quantity + '" />';
    currentRow.find(".item-label-quantity-purchaseEntry").parent().html(quantityTextBox);

    var priceBefore = $.trim(currentRow.find(".item-label-priceBeforeTax-purchaseEntry").html());
    _ItemPriceBeforePurchaseEntry = priceBefore;
    var priceBeforeTextBox = '<input type="text" class="rightText txtItemPriceBeforePurchaseEntry" onkeypress="return validateDecimal(event, this);" onkeyup="calculateItemTotalPurchaseEntry(this);" value="' + priceBefore + '" />';
    currentRow.find(".item-label-priceBeforeTax-purchaseEntry").parent().html(priceBeforeTextBox);

    _requiredDeliveryDate = $.trim(currentRow.find(".item-label-requiredDeliveryDate-purchaseEntry").html());
    var requiredDeliveryDateTextBox = '<input type="text" class="txtRequiredDeliveryDate" value="' + _requiredDeliveryDate + '" />';
    currentRow.find(".item-label-requiredDeliveryDate-purchaseEntry").parent().html(requiredDeliveryDateTextBox);
    currentRow.find(".txtRequiredDeliveryDate").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "2010:2099"
    });

    _ItemTotalPurchaseEntry = $.trim(currentRow.find(".lblItemTotalPurchaseEntry").html());

    var actionIcons = '<span class="spaneditdone" title="Save Changes" style="margin: 0 5px 0 0;" onclick="editDonePurchaseItemRow(this);"></span>';
    actionIcons += '<span class="spaneditcancel" title="Cancel Changes" onclick="editCancelPurchaseItemRow(this);"></span>';
    currentRow.find(".spanedit").parent().html(actionIcons);
}

function deletePurchaseItemRow(elem) {
    var isDelete = confirm("Are you sure to remove item?");
    if (isDelete) {
        $(elem).closest("tr").remove();
        updateGrandTotalPurchaseEntry();
    }
}

var _ItemQuantityPurchaseEntry = 0;
var _ItemPriceBeforePurchaseEntry = 0;
var _requiredDeliveryDate = "";
var _ItemTotalPurchaseEntry = 0;

function editDonePurchaseItemRow(elem) {
    var currentRow = $(elem).closest("tr");

    var quantity = $.trim(currentRow.find(".txtItemQuantityPurchaseEntry").val());
    var quantityLabel = '<label class="item-label-quantity-purchaseEntry">' + quantity + '</label>';
    currentRow.find(".txtItemQuantityPurchaseEntry").parent().html(quantityLabel);

    var priceBefore = $.trim(currentRow.find(".txtItemPriceBeforePurchaseEntry").val());
    var priceBeforeLabel = '<label class="item-label-priceBeforeTax-purchaseEntry">' + priceBefore + '</label>';
    currentRow.find(".txtItemPriceBeforePurchaseEntry").parent().html(priceBeforeLabel);

    var requiredDeliveryDateLabel = '<label class="item-label-requiredDeliveryDate-purchaseEntry">' + $.trim(currentRow.find(".txtRequiredDeliveryDate").val()) + '</label>';
    currentRow.find(".txtRequiredDeliveryDate").parent().html(requiredDeliveryDateLabel);

    var actionIcons = '<span class="spanedit" title="Edit Item" style="margin: 0 5px 0 0;" onclick="editPurchaseItemRow(this);"></span>';
    actionIcons += '<span class="spandelete" title="Delete Item" onclick="deletePurchaseItemRow(this);"></span>';
    currentRow.find(".spaneditdone").parent().html(actionIcons);

    updateGrandTotalPurchaseEntry();

    _ItemQuantityPurchaseEntry = 0;
    _ItemPriceBeforePurchaseEntry = 0;
    _requiredDeliveryDate = "";
    _ItemTotalPurchaseEntry = 0;
}

function editCancelForAllItems() {
    $(".purchase-item-view-row .spaneditcancel").each(function () {
        editCancelPurchaseItemRow(this);
    });
}

function editCancelPurchaseItemRow(elem) {
    var currentRow = $(elem).closest("tr");

    var quantityLabel = '<label class="item-label-quantity-purchaseEntry">' + _ItemQuantityPurchaseEntry + '</label>';
    currentRow.find(".txtItemQuantityPurchaseEntry").parent().html(quantityLabel);

    var priceBeforeLabel = '<label class="item-label-priceBeforeTax-purchaseEntry">' + _ItemPriceBeforePurchaseEntry + '</label>';
    currentRow.find(".txtItemPriceBeforePurchaseEntry").parent().html(priceBeforeLabel);

    var requiredDeliveryDateLabel = '<label class="item-label-requiredDeliveryDate-purchaseEntry">' + _requiredDeliveryDate + '</label>';
    currentRow.find(".txtRequiredDeliveryDate").parent().html(requiredDeliveryDateLabel);

    currentRow.find(".lblItemTotalPurchaseEntry").html(_ItemTotalPurchaseEntry);

    var actionIcons = '<span class="spanedit" title="Edit Item" style="margin: 0 5px 0 0;" onclick="editPurchaseItemRow(this);"></span>';
    actionIcons += '<span class="spandelete" title="Delete Item" onclick="deletePurchaseItemRow(this);"></span>';
    currentRow.find(".spaneditdone").parent().html(actionIcons);

    _ItemQuantityPurchaseEntry = 0;
    _ItemPriceBeforePurchaseEntry = 0;
    _requiredDeliveryDate = "";
    _ItemTotalPurchaseEntry = 0;
}

function resetPurchaseItemRow() {
    $("[id$='txtItemCodePurchaseEntry']").val("");
    $("[id$='txtItemNamePurchaseEntry']").val("");
    $("[id$='txtItemQuantityPurchaseEntry']").val("1");
    $("[id$='ddlItemUnitPurchaseEntry']").val("0");
    $("[id$='lblInstockPurchaseEntry']").html("");
    $("[id$='lblReceivedPurchaseEntry']").html("0");
    $("[id$='txtRequiredDeliveryDate']").val("");
    $("[id$='txtItemPriceBeforePurchaseEntry']").val("00.00");
    $("[id$='lblItemTotalPurchaseEntry']").html("00.00");
}

function calculateItemTotalPurchaseEntry(elem) {

    var itemRow = $(elem).closest("tr");

    var quantity = 0;
    if (itemRow.find(".txtItemQuantityPurchaseEntry").val() != "") {
        quantity = itemRow.find(".txtItemQuantityPurchaseEntry").val();
    }

    var priceBefore = 0;
    if (itemRow.find(".txtItemPriceBeforePurchaseEntry").val() != "") {
        priceBefore = itemRow.find(".txtItemPriceBeforePurchaseEntry").val();
    }

    var itemAmount = quantity * priceBefore;

    itemRow.find(".lblItemTotalPurchaseEntry").html(itemAmount);

}

function updateGrandTotalPurchaseEntry() {
    var itemTotal = 0.0;
    $(".purchase-item-view-row").each(function () {
        itemTotal += parseFloat($.trim($(this).find(".lblItemTotalPurchaseEntry").html()));
    });

    $("[id$='lblSubTotal']").html(itemTotal);
    $("[id$='lblDueAmountPurchaseEntry']").html(itemTotal);
}

function PlacePurchaseOrder() {

    if (!ValidateForm("PurchaseOrderEntry")) {
        showErrorMessage("Please fill all required fields.", "divContentsDetailsWrapper");
        return false;
    }

    if ($(".purchase-item-view-row").length == 0) {
        showErrorMessage("Please add some items to place order!", "divContentsDetailsWrapper");
        return false;
    }

    var PurchaseOrdersId = $("[id$='PurchaseOrdersIdPurchaseOrderEntry']").val();

    var objPurchaseOrders = new Object();

    objPurchaseOrders.PurchaseOrdersId = PurchaseOrdersId;
    objPurchaseOrders.SuppliersId = $("[id$='ddlSuppliersPurchaseOrderEntry']").val();
    objPurchaseOrders.PurchaseReference = $("[id$='txtReferencePurchaseOrderEntry']").val();

    objPurchaseOrders.OrderDate = $("[id$='txtPurchaseOrderEntryOrderDate']").val();
    objPurchaseOrders.SupplierReference = $("[id$='txtSuppliersReferencePurchaseOrderEntry']").val();
    objPurchaseOrders.ReceiverLocationId = $.trim($("[id$='ddlReceiveIntoLocationPurchaseOrderEntry']").val());

    objPurchaseOrders.PurchaseDeliverTo = $.trim($("[id$='txtDeliverToPurchaseOrderEntry']").val());

    objPurchaseOrders.Memo = $("[id$='txtMemoPurchaseOrderEntry']").val();
    objPurchaseOrders.TotalPrice = $.trim($("[id$='lblDueAmountPurchaseEntry']").html());

    var listPurchaseOrderItems = new Array();

    $(".purchase-item-view-row").each(function () {

        var objPurchaseOrderItems = new Object();
        objPurchaseOrderItems.ItemId = $.trim($(this).find(".item-id-purchaseEntry").val());
        objPurchaseOrderItems.QuantityOrderd = $.trim($(this).find(".item-label-quantity-purchaseEntry").html());
        objPurchaseOrderItems.QuantityReceived = $.trim($(this).find(".item-label-received-purchaseEntry").html());
        objPurchaseOrderItems.RequiredDeliveryDate = $.trim($(this).find(".item-label-requiredDeliveryDate-purchaseEntry").html());
        objPurchaseOrderItems.QuantityInvoiced = 0;
        objPurchaseOrderItems.PriceBeforeTax = $.trim($(this).find(".item-label-priceBeforeTax-purchaseEntry").html());
        objPurchaseOrderItems.TotalPrice = $.trim($(this).find(".lblItemTotalPurchaseEntry").html());
        
        objPurchaseOrderItems.SubTotal = $.trim($("[id$='lblSubTotal']").html());
        objPurchaseOrderItems.DueAmount = $.trim($("[id$='lblDueAmountPurchaseEntry']").html());
        
        listPurchaseOrderItems.push(objPurchaseOrderItems);
    });
    
    var action = "SAVE";
    
    if (PurchaseOrdersId != "0") {
        action = "UPDATE";
    }
    
    $.post("CallBacks/PurchaseOrderEntryHandler.aspx", { objPurchaseOrders: JSON.stringify(objPurchaseOrders), listPurchaseOrderItems: JSON.stringify(listPurchaseOrderItems), action: action }, function (data) {
        var returnHtml = data;
        if (PurchaseOrdersId != "0") {
            showSuccessMessage("Success: Order has been updated!", "divContentsDetailsWrapper");
        }
        else {
            var start = data.indexOf("###Start###") + 11;
            var end = data.indexOf("###End###");
            $("[id$='PurchaseOrdersIdPurchaseOrderEntry']").val($.trim(returnHtml.substring(start, end)));
            showSuccessMessage("Success: Order has been placed!", "divContentsDetailsWrapper");
        }
    });

}


/*-----------------END--Purchase Order Entry-------------------*/




/*-----------------END--Purchase Orders List-------------------*/

function loadPurchaseOrdersPage() {
    $.post("PurchaseOrders.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#PurchaseOrders").html($.trim(returnHtml.substring(start, end)));

        GeneratePaging($("[id$='hdnTotalRowsPurchaseOrders']").val(), $("#ddlPagingPurchaseOrders").val(), "GridContainerPurchaseOrders", "FilterRecordPurchaseOrders");
        if ($("[id$='hdnTotalRowsPurchaseOrders']").val() > 0)
            $("#GridContainerPurchaseOrders .spanInfo").html("Showing " + $("#gridContentsPurchaseOrders tr:first").children().first().html() + " to " + $("#gridContentsPurchaseOrders tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsPurchaseOrders']").val() + " entries");
    });
}

function FilterRecordPurchaseOrders(pageNumber, paging) {

    $.post("CallBacks/PurchaseOrdersFilterHandler.aspx", { Rows: $("#ddlPagingPurchaseOrders").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsPurchaseOrders").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsPurchaseOrders']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsPurchaseOrders']").val(), $("#ddlPagingPurchaseOrders").val(), "GridContainerPurchaseOrders", "FilterRecordPurchaseOrders");
        }

        if ($("[id$='hdnTotalRowsPurchaseOrders']").val() > 0)
            $("#GridContainerPurchaseOrders .spanInfo").html("Showing " + $("#gridContentsPurchaseOrders tr:first").children().first().html() + " to " + $("#gridContentsPurchaseOrders tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsPurchaseOrders']").val() + " entries");
    });
}

function addRecordPurchaseOrders() {
    loadContentPage("PurchaseOrderEntry", 0);
}

function editPurchaseOrder(elem) {
    var recordId = $.trim($(elem).closest("tr").find("td").eq(1).html());
    loadContentPage('PurchaseOrderEntry', recordId);
}

/*-----------------END--Purchase Orders List-------------------*/