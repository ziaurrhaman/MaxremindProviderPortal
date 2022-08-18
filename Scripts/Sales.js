

/*-----------------START--Sales Order Entry-------------------*/

function loadSalesOrdersEntryPage() {
    $.post("SalesOrdersEntry.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#SalesOrderEntry").html($.trim(returnHtml.substring(start, end)));
        readySalesOrderEntryPage();
    });
}

function readySalesOrderEntryPage() {
    $(".datepicker").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "2010:2099"
    });

    $("[id$='rbPatientHome']").change(function () {

    });

    $("#txtItemCode").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "CallBacks/SalesOrderEntryHandler.aspx/FetchItemsListByCode",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                data: "{ 'itemCode':'" + request.term + "', 'SalesTypeId' : '" + $("[id$='ddlPriceList']").val() + "'}",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.ItemCode,
                            value: item.ItemCode,
                            Name: item.Name,
                            ItemsId: item.ItemsId,
                            Rate: item.TaxRate
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
            $("[id$='hdnItemsIdSalesEntry']").val(ui.item.ItemsId);
            $("#txtItemName").val(ui.item.Name);
            $("#lblItemTax").html(ui.item.Rate);

            setItemPrice(ui.item.ItemsId);
        }
    });

    $("#txtItemName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "CallBacks/SalesOrderEntryHandler.aspx/FetchItemsListByName",
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
                            Rate: item.TaxRate
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
            $("[id$='hdnItemsIdSalesEntry']").val(ui.item.ItemsId);
            $("#txtItemCode").val(ui.item.ItemCode);
            $("#lblItemTax").html(ui.item.Rate);

            setItemPrice(ui.item.ItemsId);
        }
    });
}

function setItemPrice(ItemsId) {

    var SalesTypeId = $("[id$='ddlPriceList']").val();

    $.post("CallBacks/ItemsHandler.aspx", { ItemsId: ItemsId, SalesTypeId: SalesTypeId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartPrice###") + 16;
        var end = data.indexOf("###EndPrice###");
        $("[id$='txtItemPriceBefore']").val($.trim(returnHtml.substring(start, end)));

        var startRate = data.indexOf("###StartRate###") + 15;
        var endRate = data.indexOf("###EndRate###");
        var Rate = $.trim(returnHtml.substring(startRate, endRate));

        var startTaxIncluded = data.indexOf("###StartTaxIncluded###") + 22;
        var endTaxIncluded = data.indexOf("###EndTaxIncluded###");
        var isTaxIncluded = $.trim(returnHtml.substring(startTaxIncluded, endTaxIncluded));

        if (isTaxIncluded == "True") {
            $("[id$='thPriceTax']").html("Price after tax");
            $("[id$='lblItemTax']").html("0");
        }
        else {
            $("[id$='thPriceTax']").html("Price before tax");
            $("[id$='lblItemTax']").html(Rate);
        }

        calculateItemTotal($("[id$='txtItemCode']"));
    });
}

function changePriceList() {
    var ItemsId = $("[id$='hdnItemsIdSalesEntry']").val();

    setItemPrice(ItemsId);
}

function OpenPatientSearch() {
    $.post("../ProviderPortal/Controls/PatientSearch.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartPatientSearch###") + 24;
        var end = data.indexOf("###EndPatientSearch###");
        $("#divPopup").html(returnHtml.substring(start, end));

        $("#divPopup").dialog({
            height: 500,
            width: 1050,
            modal: true,
            buttons: {
                Cancel: function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                $("#divPopup").dialog("destroy");
            }
        });
    });
}

function selectPatientRow(PatientId, elem) {
    $(elem).siblings().removeClass("trSelected");
    $(elem).addClass("trSelected");
    ShowDetails(PatientId, $.trim($(elem).closest("tr").find("td:eq(2)").html()), $.trim($(elem).closest("tr").find("td:eq(3)").html()));
    
}

function ShowDetails(patientId, firstName, lastName, gender, maritalstatus, dob, ssn, address, city, state, zip, cell, homephone, workphone, race, ethnicity, patientstatus) {
    $("[id$='txtSalesOrderEntryPatient']").val(lastName + " " + firstName);
    $("[id$='hdnPatientId']").val(patientId);
    $(divPopup).dialog("close");
}

function ClearPatient() {
    $("[id$='txtSalesOrderEntryPatient']").val("");
    $("[id$='hdnPatientId']").val("0");
}


function addSalesItemRow(elem) {

    calculateItemTotal(elem);
    var currentRow = $(elem).closest("tr");

    var itemRow = '<tr class="sales-item-view-row">';
    itemRow += '<td>';
    itemRow += '<label class="item-label-itemCode">' + $("[id$='txtItemCode']").val() + '</label>';
    itemRow += '<input type="hidden" class="item-id-salesEntry" value="' + $("[id$='hdnItemsIdSalesEntry']").val() + '" />';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-ItemName">' + $("[id$='txtItemName']").val() + '</label>';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-Quantity">' + currentRow.find(".txtItemQuantity").val() + '</label>';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-Unit">' + $("[id$='ddlItemUnit']").val() + '</label>';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-StockRemaining"></label>';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-PriceBeforeTax">' + currentRow.find(".txtItemPriceBefore").val() + '</label>';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label id="lblItemTax" class="lblItemTax floatRight">' + currentRow.find(".lblItemTax").html() + '</label>';
    itemRow += '</td>';
    itemRow += '<td>';
    itemRow += '<label class="item-label-Discount">' + currentRow.find(".txtDiscountPercent").val() + '</label>';
    itemRow += '</td>';
    itemRow += '<td align="right">';
    itemRow += '<label class="lblItemTotal floatRight">' + $.trim(currentRow.find(".lblItemTotal").html()) + '</label>';
    itemRow += '</td>';
    itemRow += '<td align="center">';
    itemRow += '<span class="spnedit" title="Edit Item" style="margin: 0 5px 0 0;" onclick="editSalesItemRow(this);"></span>';
    itemRow += '<span class="spndelete" title="Delete Item" onclick="deleteSalesItemRow(this);"></span>';
    itemRow += '</td>';
    itemRow += '</tr>';

    $(elem).closest("tr").before(itemRow);

    updateGrandTotal();

    resetSalesItemRow();

}

function editSalesItemRow(elem) {

    editCancelForAllItems();

    var currentRow = $(elem).closest("tr");

    var quantity = $.trim(currentRow.find(".item-label-Quantity").html());
    _ItemQuantity = quantity;
    var quantityTextBox = '<input type="text" class="rightText txtItemQuantity" onkeypress="return validateDecimal(event, this);" onkeyup="calculateItemTotal(this);" value="' + quantity + '" />';
    currentRow.find(".item-label-Quantity").parent().html(quantityTextBox);

    var priceBefore = $.trim(currentRow.find(".item-label-PriceBeforeTax").html());
    _ItemPriceBefore = priceBefore;
    var priceBeforeTextBox = '<input type="text" class="rightText txtItemPriceBefore" onkeypress="return validateDecimal(event, this);" onkeyup="calculateItemTotal(this);" value="' + priceBefore + '" />';
    currentRow.find(".item-label-PriceBeforeTax").parent().html(priceBeforeTextBox);

    var discountPercent = $.trim(currentRow.find(".item-label-Discount").html());
    _DiscountPercent = discountPercent;
    var discountPercentTextBox = '<input type="text" class="rightText txtDiscountPercent" onkeypress="return validateDecimal(event, this);" onkeyup="calculateItemTotal(this);" value="' + discountPercent + '" />';
    currentRow.find(".item-label-Discount").parent().html(discountPercentTextBox);

    _ItemTotal = $.trim(currentRow.find(".lblItemTotal").html());

    var actionIcons = '<span class="spaneditdone" title="Save Changes" style="margin: 0 5px 0 0;" onclick="editDoneSalesItemRow(this);"></span>';
    actionIcons += '<span class="spaneditcancel" title="Cancel Changes" onclick="editCancelSalesItemRow(this);"></span>';
    currentRow.find(".spanedit").parent().html(actionIcons);

}

function deleteSalesItemRow(elem) {
    var isDelete = confirm("Are you sure to remove item?");
    if (isDelete) {
        $(elem).closest("tr").remove();
        updateGrandTotal();
    }
}

var _ItemQuantity = 0;
var _ItemPriceBefore = 0;
var _DiscountPercent = 0;
var _ItemTotal = 0;

function editDoneSalesItemRow(elem) {
    var currentRow = $(elem).closest("tr");

    var quantity = $.trim(currentRow.find(".txtItemQuantity").val());
    var quantityLabel = '<label class="item-label-Quantity">' + quantity + '</label>';
    currentRow.find(".txtItemQuantity").parent().html(quantityLabel);

    var priceBefore = $.trim(currentRow.find(".txtItemPriceBefore").val());
    var priceBeforeLabel = '<label class="item-label-PriceBeforeTax">' + priceBefore + '</label>';
    currentRow.find(".txtItemPriceBefore").parent().html(priceBeforeLabel);

    var discountPercent = $.trim(currentRow.find(".txtDiscountPercent").val());
    var discountPercentLabel = '<label class="item-label-Discount">' + discountPercent + '</label>';
    currentRow.find(".txtDiscountPercent").parent().html(discountPercentLabel);

    var actionIcons = '<span class="spnedit" title="Edit Item" style="margin: 0 5px 0 0;" onclick="editSalesItemRow(this);"></span>';
    actionIcons += '<span class="spndelete" title="Delete Item" onclick="deleteSalesItemRow(this);"></span>';
    currentRow.find(".spaneditdone").parent().html(actionIcons);

    updateGrandTotal();
}

function editCancelForAllItems() {
    $(".sales-item-view-row .spaneditcancel").each(function () {
        editCancelSalesItemRow(this);
    });
}

function editCancelSalesItemRow(elem) {
    var currentRow = $(elem).closest("tr");

    var quantityLabel = '<label class="item-label-Quantity">' + _ItemQuantity + '</label>';
    currentRow.find(".txtItemQuantity").parent().html(quantityLabel);

    var priceBeforeLabel = '<label class="item-label-PriceBeforeTax">' + _ItemPriceBefore + '</label>';
    currentRow.find(".txtItemPriceBefore").parent().html(priceBeforeLabel);

    var discountPercentLabel = '<label class="item-label-Discount">' + _DiscountPercent + '</label>';
    currentRow.find(".txtDiscountPercent").parent().html(discountPercentLabel);

    currentRow.find(".lblItemTotal").html(_ItemTotal);

    var actionIcons = '<span class="spnedit" title="Edit Item" style="margin: 0 5px 0 0;" onclick="editSalesItemRow(this);"></span>';
    actionIcons += '<span class="spndelete" title="Delete Item" onclick="deleteSalesItemRow(this);"></span>';
    currentRow.find(".spaneditdone").parent().html(actionIcons);

    _ItemQuantity = 0;
    _ItemPriceBefore = 0;
    _DiscountPercent = 0;
    _ItemTotal = 0;
}

function resetSalesItemRow() {
    $("[id$='txtItemCode']").val("");
    $("[id$='txtItemName']").val("");
    $("[id$='txtItemQuantity']").val("1");
    $("[id$='ddlItemUnit']").val("0");
    $("[id$='txtProcedure']").val("");
    $("[id$='txtItemPriceBefore']").val("12.00");
    $("[id$='txtDiscountPercent']").val("0.0");
    $("[id$='lblItemTotal']").html("12.00");
}

function calculateItemTotal(elem) {

    var itemRow = $(elem).closest("tr");

    var quantity = 0;
    if (itemRow.find(".txtItemQuantity").val() != "") {
        quantity = itemRow.find(".txtItemQuantity").val();
    }

    var priceBefore = 0;
    if (itemRow.find(".txtItemPriceBefore").val() != "") {
        priceBefore = itemRow.find(".txtItemPriceBefore").val();
    }

    var discountPercent = 0;
    if (itemRow.find(".txtDiscountPercent").val() != "") {
        discountPercent = itemRow.find(".txtDiscountPercent").val();
    }

    var itemTax = 0;
    if ($.trim(itemRow.find(".lblItemTax").html()) != "") {
        itemTax = $.trim(itemRow.find(".lblItemTax").html());
    }

    var itemAmount = quantity * priceBefore;
    if (!((itemTax * 1) == 0)) {
        itemAmount = itemAmount + (itemAmount * itemTax / 100);
    }

    if (!((discountPercent * 1) == 0)) {
        itemAmount = itemAmount - (itemAmount * discountPercent / 100);
    }

    itemAmount = itemAmount.toFixed(2);

    itemRow.find(".lblItemTotal").html(itemAmount);

}

function updateGrandTotal() {
    var itemTotal = 0.0;
    $(".sales-item-view-row").each(function () {
        itemTotal += parseFloat($.trim($(this).find(".lblItemTotal").html()));
    });

    var ShippingCharge = parseFloat($("[id$='txtShippingCharge']").val());

    //var TotalPrice = itemTotal + ShippingCharge;
    //$("[id$='lblTotalPrice']").html(TotalPrice);

    var amountTotal = itemTotal + ShippingCharge;
    amountTotal = amountTotal.toFixed(2);
    $("[id$='lblDueAmount']").html(amountTotal);
}

function PlaceSalesOrder() {
    var PatientId = $("[id$='hdnPatientId']").val();

    if (!ValidateForm("SalesOrderEntry")) {
        showErrorMessage("Please fill all required fields.", "divContentsDetailsWrapper");
        return false;
    }

    if ($(".sales-item-view-row").length == 0) {
        showErrorMessage("Please add some items to place order!", "divContentsDetailsWrapper");
        return false;
    }

    var objSalesOrders = new Object();
    objSalesOrders.PatientId = PatientId;

    objSalesOrders.OrderDate = $("[id$='txtSalesOrderEntryOrderDate']").val();
    objSalesOrders.DOS = $("[id$='txtSalesOrderEntryDOS']").val();

    objSalesOrders.PaymentSource = $("[id$='ddlPayment']").val();
    //objSalesOrders.PriceListId = $("[id$='ddlPriceList']").val();

    objSalesOrders.TotalPrice = $.trim($("[id$='lblDueAmount']").html());
    objSalesOrders.DueAmount = $.trim($("[id$='lblDueAmount']").html());

    objSalesOrders.DeliverFromLocation = $("[id$='ddlDeliverFromLocation']").val();
    objSalesOrders.RequiredDeliveryDate = $("[id$='txtRequiredDeliveryDate']").val();
    objSalesOrders.DeliverTo = $("[id$='txtOrderDeliverTo']").val();
    objSalesOrders.DeliveryAddress = $("[id$='txtDeliveryAddress']").val();

    if ($("[id$='rbPatientHome']").is(":checked")) {
        objSalesOrders.DeliveryLocationType = "PH";
        objSalesOrders.DeliveryLocationId = PatientId;
    }
    else {
        objSalesOrders.DeliveryLocationType = "FA";
    }

    objSalesOrders.ServiceProviderId = $("[id$='ddlServiceProvider']").val();

    var makeDelivery = $("[id$='cbMakeDelivery']").is(":checked");

    if (!makeDelivery) {
        objSalesOrders.ContactPhoneNumber = $("[id$='txtContactPhoneNumber']").val();
        objSalesOrders.CustomerReference = $("[id$='txtCustomerReference']").val();
        //objSalesOrders.ShippingCompany = $("[id$='ddlShippingCompany']").val();
    }
    objSalesOrders.Comments = $("[id$='txtComments']").val();

    var listSalesOrderItems = new Array();

    $(".sales-item-view-row").each(function () {

        var objSalesOrderItems = new Object();
        objSalesOrderItems.ItemId = $.trim($(this).find(".item-id-salesEntry").val());
        objSalesOrderItems.QuantityOrderd = $.trim($(this).find(".item-label-Quantity").html());

        if (makeDelivery) {
            objSalesOrderItems.QuantityDelivered = $.trim($(this).find(".item-label-Quantity").html());
        }

        objSalesOrderItems.PriceBeforeTax = $.trim($(this).find(".item-label-PriceBeforeTax").html());
        objSalesOrderItems.TaxAmount = calculateItemTaxAmount(this);
        //objSalesOrderItems.TaxTypeId = "";
        objSalesOrderItems.TotalPrice = $.trim($(this).find(".lblItemTotal").html());
        objSalesOrderItems.DueAmount = $.trim($(this).find(".lblItemTotal").html());
        objSalesOrderItems.Discount = calculateItemDiscount(this);

        listSalesOrderItems.push(objSalesOrderItems);
    });

    $.post("CallBacks/SalesOrderEntryHandler.aspx", { objSalesOrders: JSON.stringify(objSalesOrders), listSalesOrderItems: JSON.stringify(listSalesOrderItems), makeDelivery: makeDelivery, action: "SAVE" }, function (data) {
        var returnHtml = data;

        showSuccessMessage("Success: Order has been placed!", "divContentsDetailsWrapper");

        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("[id$='PurchaseOrdersIdPurchaseOrderEntry']").val($.trim(returnHtml.substring(start, end)));
    });

}

function calculateItemTaxAmount(itemRow) {
    var quantity = 0;
    if ($.trim($(itemRow).find(".item-label-Quantity").html()) != "") {
        quantity = $.trim($(itemRow).find(".item-label-Quantity").html());
    }

    var priceBefore = 0;
    if ($.trim($(itemRow).find(".item-label-PriceBeforeTax").html()) != "") {
        priceBefore = $.trim($(itemRow).find(".item-label-PriceBeforeTax").html());
    }

    var discountPercent = 0;
    if ($.trim($(itemRow).find(".item-label-Discount").html()) != "") {
        discountPercent = $.trim($(itemRow).find(".item-label-Discount").html());
    }

    var itemTax = 0;
    if ($.trim($(itemRow).find(".lblItemTax").html()) != "") {
        itemTax = $.trim($(itemRow).find(".lblItemTax").html());
    }

    var itemTaxAmount = quantity * priceBefore;
    if (itemTax != 0) {
        itemTaxAmount = priceBefore * itemTax / 100;
    }

    return itemTaxAmount;
}

function calculateItemDiscount(itemRow) {

    var quantity = 0;
    if ($.trim($(itemRow).find(".item-label-Quantity").html()) != "") {
        quantity = $.trim($(itemRow).find(".item-label-Quantity").html());
    }

    var priceBefore = 0;
    if ($.trim($(itemRow).find(".item-label-PriceBeforeTax").html()) != "") {
        priceBefore = $.trim($(itemRow).find(".item-label-PriceBeforeTax").html());
    }

    var discountPercent = 0;
    if ($.trim($(itemRow).find(".item-label-Discount").html()) != "") {
        discountPercent = $.trim($(itemRow).find(".item-label-Discount").html());
    }

    var itemTax = 0;
    if ($.trim($(itemRow).find(".lblItemTax").html()) != "") {
        itemTax = $.trim($(itemRow).find(".lblItemTax").html());
    }

    var itemAmount = quantity * priceBefore;
    if (!((itemTax * 1) == 0)) {
        itemAmount = itemAmount + (itemAmount * itemTax / 100);
    }

    var itemDiscount = 0;

    if (!((discountPercent * 1) == 0)) {
        itemDiscount = itemAmount * discountPercent / 100;
    }

    return itemDiscount;
}

function makeDelivery(elem) {
    if ($(elem).is(":checked")) {
        $("[id$='txtContactPhoneNumber']").val("");
        $("[id$='txtContactPhoneNumber']").attr("disabled", "disabled");

        $("[id$='txtCustomerReference']").val("");
        $("[id$='txtCustomerReference']").attr("disabled", "disabled");

        $("[id$='ddlShippingCompany']").val("0");
        $("[id$='ddlShippingCompany']").attr("disabled", "disabled");
    }
    else {
        $("[id$='txtContactPhoneNumber']").removeAttr("disabled");
        $("[id$='txtCustomerReference']").removeAttr("disabled");
        $("[id$='ddlShippingCompany']").removeAttr("disabled");
    }
}

/*-----------------END--Sales Order Entry-------------------*/



/*-----------------END--Sales Orders List-------------------*/

function loadSalesOrdersPage() {
    $.post("SalesOrders.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#SalesOrders").html($.trim(returnHtml.substring(start, end)));

        GeneratePaging($("[id$='hdnTotalRowsSalesOrders']").val(), $("#ddlPagingSalesOrders").val(), "GridContainerSalesOrders", "FilterRecordSalesOrders");
        if ($("[id$='hdnTotalRowsSalesOrders']").val() > 0)
            $("#GridContainerSalesOrders .spanInfo").html("Showing " + $("#gridContentsSalesOrders tr:first").children().first().html() + " to " + $("#gridContentsSalesOrders tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSalesOrders']").val() + " entries");
    });
}

function FilterRecordSalesOrders(pageNumber, paging) {

    $.post("CallBacks/SalesOrdersFilterHandler.aspx", { Rows: $("#ddlPagingSalesOrders").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsSalesOrders").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsSalesOrders']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsSalesOrders']").val(), $("#ddlPagingSalesOrders").val(), "GridContainerSalesOrders", "FilterRecordSalesOrders");
        }

        if ($("[id$='hdnTotalRowsSalesOrders']").val() > 0)
            $("#GridContainerSalesOrders .spanInfo").html("Showing " + $("#gridContentsSalesOrders tr:first").children().first().html() + " to " + $("#gridContentsSalesOrders tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSalesOrders']").val() + " entries");
    });
}

function addRecordSalesOrders() {
    loadContentPage("SalesOrderEntry", 0);
}

/*-----------------END--Sales Orders List-------------------*/



/*-----------------START--Sale Types-------------------*/

function loadSaleTypesPage() {
    $.post("SaleTypes.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#SaleTypes").html($.trim(returnHtml.substring(start, end)));

        GeneratePaging($("[id$='hdnTotalRowsSaleTypes']").val(), $("#ddlPagingSaleTypes").val(), "GridContainerSaleTypes", "FilterRecordSaleTypes");
        if ($("[id$='hdnTotalRowsSaleTypes']").val() > 0)
            $("#GridContainerSaleTypes .spanInfo").html("Showing " + $("#gridContentsSaleTypes tr:first").children().first().html() + " to " + $("#gridContentsSaleTypes tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSaleTypes']").val() + " entries");
    });
}


function FilterRecordSaleTypes(pageNumber, paging) {

    $.post("CallBacks/SalesTypesFilterHandler.aspx", { Rows: $("#ddlPagingSaleTypes").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsSaleTypes").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsSaleTypes']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsSaleTypes']").val(), $("#ddlPagingSaleTypes").val(), "GridContainerSaleTypes", "FilterRecordSaleTypes");
        }

        if ($("[id$='hdnTotalRowsSaleTypes']").val() > 0)
            $("#GridContainerSaleTypes .spanInfo").html("Showing " + $("#gridContentsSaleTypes tr:first").children().first().html() + " to " + $("#gridContentsSaleTypes tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSaleTypes']").val() + " entries");
    });
}

function addRecordSaleTypes() {

    resetRecordFormSaleTypes();

    $("#divAddNewRecordSaleTypes").dialog({
        title: "Add New Record",
        width: "auto",
        buttons: {
            "Save": function () {
                saveRecordSaleTypes("SAVE", 0);
            },
            "Cancel": function () {
                $("#divAddNewRecordSaleTypes").dialog("close");
            }
        },
        close: function () {
            $("#divAddNewRecordSaleTypes").dialog("destroy");
        }
    });
}

function editRecordSaleTypes(elem) {

    resetRecordFormSaleTypes();

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    if (recordId == "1") {
        showErrorMessage("Sorry Base type cannot be modified!");
        return false;
    }

    var name = $.trim($(elem).closest("tr").find("td").eq(1).html());
    var CalculationFactor = $.trim($(elem).closest("tr").find("td").eq(2).find("span").html());
    var TaxIncluded = $.trim($(elem).closest("tr").find("td").eq(3).find("span").html());
    var Status = $.trim($(elem).closest("tr").find("td").eq(4).html());

    $("#txtNameSaleTypes").val(name);
    $("[id$='txtFactor']").val(CalculationFactor);

    if (TaxIncluded == "Yes") {
        $("[id$='cbTaxIncluded']").click();
    }
    else {
        $("[id$='cbTaxIncluded']").removeAttr("checked");
    }

    $("[id$='ddlStatusSaleTypes']").val(Status);

    $("#divAddNewRecordSaleTypes").dialog({
        title: "Edit Record",
        width: "auto",
        buttons: {
            "Save": function () {
                saveRecordSaleTypes("UPDATE", recordId);
            },
            "Cancel": function () {
                $("#divAddNewRecordSaleTypes").dialog("close");
            }
        },
        close: function () {
            $("#divAddNewRecordSaleTypes").dialog("destroy");
        }
    });
}

function saveRecordSaleTypes(action, recordId) {

    if (!ValidateForm("divAddNewRecordSaleTypes")) {
        showErrorMessage("Please fill all required fields.", "divAddNewRecordSaleTypes");
        return false;
    }

    var objRecord = new Object();

    if (recordId != 0) {
        objRecord.SalesTypeId = recordId;
    }

    objRecord.SalesTypeName = $("[id$='txtNameSaleTypes']").val();
    objRecord.CalculationFactor = $("[id$='txtFactor']").val();
    objRecord.TaxIncluded = $("[id$='cbTaxIncluded']").is(":checked");
    objRecord.Status = $("[id$='ddlStatusSaleTypes']").val();

    $.post("CallBacks/SalesTypesHandler.aspx", { objRecord: JSON.stringify(objRecord), action: action }, function (data) {
        $("#divAddNewRecordSaleTypes").dialog("close");
        FilterRecordSaleTypes(0, true);

        if (action == "SAVE") {
            showSuccessMessage("Success: Record saved!", "divContentsDetailsWrapper");
        }
        else {
            showSuccessMessage("Success: Record updated!", "divContentsDetailsWrapper");
        }
    });
}

function deleteRecordSaleTypes(elem) {

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    if (recordId == "1") {
        showErrorMessage("Sorry Base type cannot be deleted!");
        return false;
    }

    var isConfirm = confirm("Are you sure to delete the record?");
    if (!isConfirm) {
        return false;
    }

    $.post("CallBacks/SalesTypesHandler.aspx", { recordId: recordId, action: "DELETE" }, function (data) {
        FilterRecordSaleTypes(0, true);
        showSuccessMessage("Success: Tax Type deleted!", "divContentsDetailsWrapper");
    });
}

function resetRecordFormSaleTypes() {
    $("[id$='txtNameSaleTypes']").val("");
    $("[id$='txtFactor']").val("");
    $("[id$='cbTaxIncluded']").removeAttr("checked");
    $("[id$='ddlStatusSaleTypes']").val("0");
}

/*-----------------END--Sale Types-------------------*/
