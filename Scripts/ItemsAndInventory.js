



/*-----------------START--Items Entry-------------------*/

function loadItemsEntryPage(recordId) {
    $.post("ItemsEntry.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#ItemsEntry").html($.trim(returnHtml.substring(start, end)));
        readyItemsEntryPage();
    });
}

function readyItemsEntryPage() {
    new AjaxUpload('#btnUpload', {
        action: 'CallBacks/ImageHandler.ashx',
        dataType: 'json',
        contentType: "application/json; charset=uft-8",
        onSubmit: function (file, ext) {
            if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                showErrorMessage('Error: invalid file extension');
                return false;
            }

            $("[id$='imgRecordImage']").css("opacity", "0.14");
            $(".image-upload-processing").css("display", "");
        },
        onComplete: function (file, response) {
            var res = $.parseJSON($(response).html());
            $("[id$='imgRecordImage']").attr("src", res.path);
            $("[id$='hfImageFileNameItemEntry']").val(res.fileName);
            $("[id$='hfImagePathItemEntry']").val(res.path);

            $("[id$='imgRecordImage']").css("opacity", "");
            $(".image-upload-processing").css("display", "none");
        }
    });
}

function clearImage() {
    $("[id$='imgRecordImage']").attr("src", "../../Images/noimage.jpg");
    $("[id$='hfImageFileNameItemEntry']").val("");
    $("[id$='hfImagePathItemEntry']").val("");
}

function saveGeneralInfoItemsEntry() {

    if (!ValidateForm("divItemsEntry")) {
        showErrorMessage("", "divContentsDetailsWrapper");
        return false;
    }

    var recordId = $("[id$='hdnRecordIdItemsEntry']").val();
    var action = "SAVE";

    var objItems = new Object();
    if (recordId != 0) {
        objItems.ItemsId = recordId;
        action = "UPDATE";
    }

    objItems.ItemCode = $("[id$='txtItemCodeItemEntry']").val();
    objItems.Name = $("[id$='txtItemNameItemEntry']").val();
    objItems.Description = $("[id$='txtItemDescriptionItemEntry']").val();
    objItems.ItemCategoryId = $("[id$='ddlItemCategoryItemEntry']").val();
    objItems.TaxTypeId = $("[id$='ddlItemTaxTypeItemEntry']").val();
    objItems.ItemType = $("[id$='ddlItemTypeItemEntry']").val();
    objItems.UnitsOfMeasures = $("[id$='ddlItemUintsOfMeasureItemEntry']").val();
    objItems.EditableDescription = $("[id$='cbEditableDescriptionItemEntry']").is(":checked");
    objItems.ExcludeFromSale = $("[id$='cbExcludeFromoSaleItemEntry']").is(":checked");

    objItems.StandardCost = $("[id$='txtStandardCostItemEntry']").val();

    objItems.DimentionId = $("[id$='ddlItemDimentionsItemEntry']").val();
    objItems.SalesAccountId = $("[id$='ddlSalesAccountItemEntry']").val();
    objItems.InventoryAccountId = $("[id$='ddlInventoryAccountItemEntry']").val();
    objItems.COGSAccountId = $("[id$='ddlCOGSAccountItemEntry']").val();
    objItems.InventoryAdjustmentsAccountId = $("[id$='ddlInventoryAdjustmentsAccountItemEntry']").val();
    objItems.ImagePath = $("[id$='hfImagePathItemEntry']").val();
    objItems.Status = $("[id$='ddlItemStatusItemEntry']").val();

    $.post("CallBacks/ItemEntryHandler.aspx", { objItems: JSON.stringify(objItems), action: action }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");

        var recordId = $.trim(returnHtml.substring(start, end));
        if (recordId != "") {
            $("[id$='hdnRecordIdItemsEntry']").val(recordId);
        }

        if (action == "SAVE") {
            showSuccessMessage("Success: Record saved!", "divContentsDetailsWrapper");
            $("#divItemsEntry").css("display", "none");
            $(".redirect-menu").css("display", "");
        }
        else {
            showSuccessMessage("Success: Record updated!", "divContentsDetailsWrapper");
        }
    });
}

function enterPriceInformation() {
    $("[id$='linkSalesPricing']").click();

    $("#divItemsEntry").css("display", "");
    $(".redirect-menu").css("display", "none");
}

function showTab(activeDiv, event) {

    var recordId = $("[id$='hdnRecordIdItemsEntry']").val();
    if (activeDiv == "divSalesPricingView" || activeDiv == "divPurchasePricingView") {
        if (recordId != 0) {
            showHideTabs(activeDiv);
            if (activeDiv == "divSalesPricingView") {
                $.post("ItemSalesPricing.aspx", { recordId: recordId }, function (data) {
                    var returnHtml = data;
                    var start = data.indexOf("###Start###") + 11;
                    var end = data.indexOf("###End###");

                    $("#divSalesPricingView").html($.trim(returnHtml.substring(start, end)));

                    GeneratePaging($("[id$='hdnTotalRowsSalesPrice']").val(), $("#ddlPagingSalesPrice").val(), "GridContainerSalesPrice", "FilterRecordSalesPrice");
                    if ($("[id$='hdnTotalRowsSalesPrice']").val() > 0)
                        $("#GridContainerSalesPrice .spanInfo").html("Showing " + $("#gridContentsSalesPrice tr:first").children().first().html() + " to " + $("#gridContentsSalesPrice tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSalesPrice']").val() + " entries");
                });
            }
            else if (activeDiv == "divPurchasePricingView") {
                $.post("ItemPurchasePricing.aspx", { recordId: recordId }, function (data) {
                    var returnHtml = data;
                    var start = data.indexOf("###Start###") + 11;
                    var end = data.indexOf("###End###");

                    $("#divPurchasePricingView").html($.trim(returnHtml.substring(start, end)));

                    GeneratePaging($("[id$='hdnTotalRowsPurchasePrice']").val(), $("#ddlPagingSalesPrice").val(), "GridContainerPurchasePrice", "FilterRecordPurchasePrice");
                    if ($("[id$='hdnTotalRowsPurchasePrice']").val() > 0)
                        $("#messagePurchasePrice .spanInfo").html("Showing " + $("#gridContentsPurchasePrice tr:first").children().first().html() + " to " + $("#gridContentsPurchasePrice tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsPurchasePrice']").val() + " entries");
                });
            }
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


function FilterRecordSalesPrice(pageNumber, paging) {

    var recordId = $("[id$='hdnRecordIdItemsEntry']").val();

    $.post("CallBacks/ItemSalesPriceFilterHandler.aspx", { Rows: $("#ddlPagingSalesPrice").val(), PageNumber: pageNumber, SortBy: "", recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsSalesPrice").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsSalesPrice']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsSalesPrice']").val(), $("#ddlPagingSalesPrice").val(), "GridContainerSalesPrice", "FilterRecordSalesPrice");
        }

        if ($("[id$='hdnTotalRowsSalesPrice']").val() > 0)
            $("#GridContainerSalesPrice .spanInfo").html("Showing " + $("#gridContentsSalesPrice tr:first").children().first().html() + " to " + $("#gridContentsSalesPrice tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsSalesPrice']").val() + " entries");
    });
}

function addSalesPriceRecord() {

    var recordId = 0;

    $.post("CallBacks/ItemSalesPriceForm.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divForm").html(returnHtml.substring(start, end));

        $("#divForm").dialog({
            title: "Add New Record",
            width: "auto",
            buttons: {
                "Save": function () {
                    saveSalesPriceRecord("SAVE", 0, "");
                },
                "Cancel": function () {
                    $("#divForm").dialog("close");
                }
            },
            close: function () {
                $("#divForm").dialog("destroy");
            }
        });
    });

}

function editSalesPriceRecord(elem) {

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    var salesTypeAlreadyHave = $.trim($(elem).closest("tr").find("td").eq(2).html());

    $.post("CallBacks/ItemSalesPriceForm.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divForm").html(returnHtml.substring(start, end));

        $("#divForm").dialog({
            title: "Edit Record",
            width: "auto",
            buttons: {
                "Save": function () {
                    saveSalesPriceRecord("UPDATE", recordId, salesTypeAlreadyHave);
                },
                "Cancel": function () {
                    $("#divForm").dialog("close");
                }
            },
            close: function () {
                $("#divForm").dialog("destroy");
            }
        });
    });
}

function saveSalesPriceRecord(action, recordId, salesTypeAlreadyHave) {

    if (!ValidateForm("divForm")) {
        showErrorMessage("Please fill all required fields.", "divForm");
        return false;
    }

    var selectedSalesType = $("[id$='ddlSalesType'] :selected").text();
    if (validateSalesPriceIfExists(selectedSalesType, salesTypeAlreadyHave)) {
        showErrorMessage("Sales price with selected sales type has already been added.\nPlease select another type.");
        return false;
    }

    var objRecord = new Object();

    if (recordId != 0) {
        objRecord.ItemSalesPriceId = recordId;
    }

    objRecord.ItemsId = $("[id$='hdnRecordIdItemsEntry']").val();

    objRecord.CurrencyId = $("[id$='ddlSalesCurrency']").val();
    objRecord.SalesTypeId = $("[id$='ddlSalesType']").val();
    objRecord.ItemPrice = $("[id$='txtSalesPrice']").val();

    $.post("CallBacks/ItemSalesPriceHandler.aspx", { objRecord: JSON.stringify(objRecord), action: action }, function (data) {
        $("#divForm").dialog("close");
        FilterRecordSalesPrice(0, true);

        if (action == "SAVE") {
            showSuccessMessage("Success: Record saved!", "divContentsDetailsWrapper");
        }
        else {
            showSuccessMessage("Success: Record updated!", "divContentsDetailsWrapper");
        }
    });
}

function deleteSalesPriceRecord(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (!isConfirm) {
        return;
    }

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/ItemSalesPriceHandler.aspx", { recordId: recordId, action: "DELETE" }, function (data) {
        FilterRecordSalesPrice(0, true);
        showSuccessMessage("Success: Record deleted!", "divContentsDetailsWrapper");
    });
}

function validateSalesPriceIfExists(selectedSalesType, salesTypeAlreadyHave) {
    var salesType = "";
    var ifExist = false;

    $("[id$='gridContentsSalesPrice'] tr").each(function () {
        salesType = $.trim($(this).find("td").eq(2).html());

        if (salesType != salesTypeAlreadyHave) {
            if (salesType == selectedSalesType) {
                ifExist = true;
            }
        }
    });

    return ifExist;
}


function FilterRecordPurchasePrice(pageNumber, paging) {

    var recordId = $("[id$='hdnRecordIdItemsEntry']").val();

    $.post("CallBacks/ItemPurchasePriceFilterHandler.aspx", { Rows: $("#ddlPagingPurchasePrice").val(), PageNumber: pageNumber, SortBy: "", recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsPurchasePrice").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsPurchasePrice']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsPurchasePrice']").val(), $("#ddlPagingPurchasePrice").val(), "GridContainerPurchasePrice", "FilterRecordPurchasePrice");
        }

        if ($("[id$='hdnTotalRowsPurchasePrice']").val() > 0)
            $("#GridContainerPurchasePrice .spanInfo").html("Showing " + $("#gridContentsPurchasePrice tr:first").children().first().html() + " to " + $("#gridContentsPurchasePrice tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsPurchasePrice']").val() + " entries");
    });
}

function addPurchasePriceRecord() {

    var recordId = 0;

    $.post("CallBacks/ItemPurchasePriceForm.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divForm").html(returnHtml.substring(start, end));

        $("#divForm").dialog({
            title: "Add New Record",
            width: "auto",
            buttons: {
                "Save": function () {
                    savePurchasePriceRecord("SAVE", 0);
                },
                "Cancel": function () {
                    $("#divForm").dialog("close");
                }
            },
            close: function () {
                $("#divForm").dialog("destroy");
            }
        });
    });
}

function editPurchasePriceRecord(elem) {

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/ItemPurchasePriceForm.aspx", { recordId: recordId }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#divForm").html(returnHtml.substring(start, end));

        $("#divForm").dialog({
            title: "Edit Record",
            width: "auto",
            buttons: {
                "Save": function () {
                    savePurchasePriceRecord("UPDATE", recordId);
                },
                "Cancel": function () {
                    $("#divForm").dialog("close");
                }
            },
            close: function () {
                $("#divForm").dialog("destroy");
            }
        });
    });
}

function savePurchasePriceRecord(action, recordId) {

    if (!ValidateForm("divForm")) {
        showErrorMessage("Please fill all required fields.", "divForm");
        return false;
    }

    var objRecord = new Object();

    if (recordId != 0) {
        objRecord.ItemPurchasePriceId = recordId;
    }

    objRecord.ItemsId = $("[id$='hdnRecordIdItemsEntry']").val();

    objRecord.SuppliersId = $("[id$='ddlPurchaseSupplier']").val();
    objRecord.PurchasePrice = $("[id$='txtPurchasePrice']").val();
    objRecord.SuppliersUnitOfMeasure = $("[id$='txtSuppliersUnitOfMeasure']").val();
    objRecord.ConversionFactor = $("[id$='txtPurchaseConversionFactor']").val();
    objRecord.SupplierCode = $("[id$='txtSupplierCode']").val();

    $.post("CallBacks/ItemPurchasePriceHandler.aspx", { objRecord: JSON.stringify(objRecord), action: action }, function (data) {
        $("#divForm").dialog("close");
        FilterRecordPurchasePrice(0, true);

        if (action == "SAVE") {
            showSuccessMessage("Success: Record saved!", "divContentsDetailsWrapper");
        }
        else {
            showSuccessMessage("Success: Record updated!", "divContentsDetailsWrapper");
        }
    });
}

function deletePurchasePriceRecord(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (!isConfirm) {
        return;
    }

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/ItemPurchasePriceHandler.aspx", { recordId: recordId, action: "DELETE" }, function (data) {
        FilterRecordPurchasePrice(0, true);
        showSuccessMessage("Success: Record deleted!", "divContentsDetailsWrapper");
    });
}

/*-----------------END--Items Entry-------------------*/



/*-----------------START--Items List-------------------*/

function loadItemsPage() {
    $.post("Items.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#ItemsList").html($.trim(returnHtml.substring(start, end)));

        GeneratePaging($("[id$='hdnTotalRowsItems']").val(), $("#ddlPagingItems").val(), "GridContainerItems", "FilterRecordItems");
        if ($("[id$='hdnTotalRowsItems']").val() > 0)
            $("#GridContainerItems .spanInfo").html("Showing " + $("#gridContentsItems tr:first").children().first().html() + " to " + $("#gridContentsItems tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsItems']").val() + " entries");
    });
}

function FilterRecordItems(pageNumber, paging) {

    $.post("CallBacks/ItemsFilterHandler.aspx", { Rows: $("#ddlPagingItems").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsItems").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsItems']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsItems']").val(), $("#ddlPagingItems").val(), "GridContainerItems", "FilterRecordItems");
        }

        if ($("[id$='hdnTotalRowsItems']").val() > 0)
            $("#GridContainerItems .spanInfo").html("Showing " + $("#gridContentsItems tr:first").children().first().html() + " to " + $("#gridContentsItems tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsItems']").val() + " entries");
    });
}

function deleteRecordItems(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (!isConfirm) {
        return;
    }

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/ItemEntryHandler.aspx", { recordId: recordId, action: "DELETE" }, function (data) {
        FilterRecordItems(0, true);
        showSuccessMessage("Success: Record deleted!", "divContentsDetailsWrapper");
    });
}

function addRecordItems() {
    loadContentPage("ItemsEntry", 0);
}

function editRecordItems(elem) {
    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());
    loadContentPage("ItemsEntry", recordId);
}

function editPricesItems(elem) {
    var recordId = $.trim($(elem).closest("tr").find(".hdnRecordId").val());
    //loadContentPage("ItemsEntry", recordId);
}


/*-----------------END--Items List-------------------*/



/*-----------------START--Item Categories-------------------*/

function loadItemCategoriesPage() {
    $.post("ItemCategories.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#ItemCategories").html($.trim(returnHtml.substring(start, end)));

        GeneratePaging($("[id$='hdnTotalRowsItemCategories']").val(), $("#ddlPagingItemCategories").val(), "GridContainerItemCategories", "FilterRecordItemCategories");
        if ($("[id$='hdnTotalRowsItemCategories']").val() > 0)
            $("#GridContainerItemCategories .spanInfo").html("Showing " + $("#gridContentsItemCategories tr:first").children().first().html() + " to " + $("#gridContentsItemCategories tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsItemCategories']").val() + " entries");
    });
}


function FilterRecordItemCategories(pageNumber, paging) {

    $.post("CallBacks/ItemCategoriesFilterHandler.aspx", { Rows: $("#ddlPagingItemCategories").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsItemCategories").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartPatientRowsCount###") + 30;
        var endRowsCount = data.indexOf("###EndPatientRowsCount###");
        $("[id$='hdnTotalRowsItemCategories']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsItemCategories']").val(), $("#ddlPagingItemCategories").val(), "GridContainerItemCategories", "FilterRecordItemCategories");
        }

        if ($("[id$='hdnTotalRowsItemCategories']").val() > 0)
            $("#GridContainerItemCategories .spanInfo").html("Showing " + $("#gridContentsItemCategories tr:first").children().first().html() + " to " + $("#gridContentsItemCategories tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsItemCategories']").val() + " entries");
    });
}

function addRecordItemCategories() {

    resetRecordFormItemCategories();

    $("#divAddNewRecordItemCategories").dialog({
        title: "Add New Record",
        width: "auto",
        buttons: {
            "Save": function () {
                saveRecordItemCategories("SAVE", 0);
            },
            "Cancel": function () {
                $("#divAddNewRecordItemCategories").dialog("close");
            }
        },
        close: function () {
            $("#divAddNewRecordItemCategories").dialog("destroy");
        }
    });
}

function editRecordItemCategories(elem) {

    resetRecordFormItemCategories();

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    var name = $.trim($(elem).closest("tr").find("td").eq(1).html());
    var itemTaxTypeId = $.trim($(elem).parent().find(".hdnTaxTypeId").val());
    var units = $.trim($(elem).closest("tr").find("td").eq(3).html());
    var itemType = $.trim($(elem).closest("tr").find("td").eq(4).html());

    var saleAccId = $.trim($(elem).parent().find(".hdnSaleAccId").val());
    var inventoryAccId = $.trim($(elem).parent().find(".hdnInventoryAccId").val());
    var COGSAccId = $.trim($(elem).parent().find(".hdnCOGSAccId").val());
    var inventoryAdjustmentsAccId = $.trim($(elem).parent().find(".hdnInventoryAdjustmentsAccId").val());
    var itemAssemblyAccId = $.trim($(elem).parent().find(".hdnItemAssemblyAccId").val());

    var exclude = $.trim($(elem).parent().find(".hdnExcludeFromSale").val());
    var dimention = $.trim($(elem).parent().find(".hdnDimensionId").val());
    var status = $(elem).parent().find(".hdnStatus").val();

    $("[id$='txtNameItemCategories']").val(name);
    $("[id$='ddlItemTaxTypeItemCategories']").val(itemTaxTypeId);
    $("[id$='ddlItemTypeItemCategories']").val(itemType);
    $("[id$='ddlItemUintsOfMeasureItemCategories']").val(units);

    if (exclude == "True") {
        $("[id$='cbExcludeFromSaleItemCategories']").attr("checked", true);
    }

    $("[id$='ddlSalesAccountItemCategories']").val(saleAccId);
    $("[id$='ddlInventoryAccountItemCategories']").val(inventoryAccId);
    $("[id$='ddlCOGSAccountItemCategories']").val(COGSAccId);
    $("[id$='ddlInventoryAdjustmentsAccountItemCategories']").val(inventoryAdjustmentsAccId);
    $("[id$='ddlItemAssemblyCoastsAccountItemCategories']").val(itemAssemblyAccId);

    $("[id$='ddlItemDimentionsItemCategories']").val(dimention);
    $("[id$='ddlStatusItemCategories']").val(status);

    $("#divAddNewRecordItemCategories").dialog({
        title: "Edit Record",
        width: "auto",
        buttons: {
            "Save": function () {
                saveRecordItemCategories("UPDATE", recordId);
            },
            "Cancel": function () {
                $("#divAddNewRecordItemCategories").dialog("close");
            }
        },
        close: function () {
            $("#divAddNewRecordItemCategories").dialog("destroy");
        }
    });
}

function saveRecordItemCategories(action, recordId) {

    if (!ValidateForm("divAddNewRecordItemCategories")) {
        showErrorMessage("Please fill all required fields.", "divAddNewRecordItemCategories");
        return false;
    }

    var objItemCategories = new Object();

    if (recordId != 0) {
        objItemCategories.ItemCategoriesId = recordId;
    }

    objItemCategories.Name = $("[id$='txtNameItemCategories']").val();
    objItemCategories.ItemTaxTypesId = $("[id$='ddlItemTaxTypeItemCategories']").val();
    objItemCategories.ItemType = $("[id$='ddlItemTypeItemCategories']").val();
    objItemCategories.UnitsOfMeasures = $("[id$='ddlItemUintsOfMeasureItemCategories']").val();
    objItemCategories.ExcludeFromSale = $("[id$='cbExcludeFromSaleItemCategories']").is(":checked");
    objItemCategories.DimentionId = $("[id$='ddlItemDimentionsItemCategories']").val();
    objItemCategories.SalesAccountId = $("[id$='ddlSalesAccountItemCategories']").val();
    objItemCategories.InventoryAccountId = $("[id$='ddlInventoryAccountItemCategories']").val();
    objItemCategories.COGSAccountId = $("[id$='ddlCOGSAccountItemCategories']").val();
    objItemCategories.InventoryAdjustmentsAccountId = $("[id$='ddlInventoryAdjustmentsAccountItemCategories']").val();
    objItemCategories.ItemAssemblyCostsAccountId = $("[id$='ddlItemAssemblyCoastsAccountItemCategories']").val();

    objItemCategories.Status = $("[id$='ddlStatusItemCategories']").val();

    $.post("CallBacks/ItemCategoriesHandler.aspx", { objItemCategories: JSON.stringify(objItemCategories), action: action }, function (data) {
        $("#divAddNewRecordItemCategories").dialog("close");
        FilterRecordItemCategories(0, true);

        if (action == "SAVE") {
            showSuccessMessage("Success: Record saved!", "divContentsDetailsWrapper");
        }
        else {
            showSuccessMessage("Success: Record updated!", "divContentsDetailsWrapper");
        }
    });
}

function deleteRecordItemCategories(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (!isConfirm) {
        return;
    }

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/ItemCategoriesHandler.aspx", { recordId: recordId, action: "DELETE" }, function (data) {
        FilterRecordItemCategories(0, true);
        showSuccessMessage("Success: Record deleted!", "divContentsDetailsWrapper");
    });
}

function resetRecordFormItemCategories() {
    $("[id$='txtNameItemCategories']").val("");
    $("[id$='ddlItemTaxTypeItemCategories']").val(0);
    $("[id$='ddlItemTypeItemCategories']").val(0);
    $("[id$='ddlItemUintsOfMeasureItemCategories']").val(0);
    $("[id$='cbExcludeFromSaleItemCategories']").removeAttr("checked");
    $("[id$='ddlSalesAccountItemCategories']").val(0);
    $("[id$='ddlInventoryAccountItemCategories']").val(0);
    $("[id$='ddlCOGSAccountItemCategories']").val(0);
    $("[id$='ddlInventoryAdjustmentsAccountItemCategories']").val(0);
    $("[id$='ddlItemAssemblyCoastsAccountItemCategories']").val(0);
    $("[id$='ddlItemDimentionsItemCategories']").val(0);
    $("[id$='ddlStatusItemCategories']").val(0);
}

/*-----------------END--Item Categories-------------------*/



/*-----------------START--Item Tax Types-------------------*/

function loadItemTaxTypesPage() {
    $.post("ItemTaxTypes.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#ItemTaxTypes").html($.trim(returnHtml.substring(start, end)));

        GeneratePaging($("[id$='hdnTotalRowsItemTaxTypes']").val(), $("#ddlPagingItemTaxTypes").val(), "GridContainerItemTaxTypes", "FilterRecordItemTaxTypes");
        if ($("[id$='hdnTotalRowsItemTaxTypes']").val() > 0)
            $("#GridContainerItemTaxTypes .spanInfo").html("Showing " + $("#gridContentsItemTaxTypes tr:first").children().first().html() + " to " + $("#gridContentsItemTaxTypes tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsItemTaxTypes']").val() + " entries");
    });
}


function FilterRecordItemTaxTypes(pageNumber, paging) {

    $.post("CallBacks/ItemTaxTypesFilterHandler.aspx", { Rows: $("#ddlPagingItemTaxTypes").val(), PageNumber: pageNumber, SortBy: "" }, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###Start###") + 11;
        var end = data.indexOf("###End###");
        $("#gridContentsItemTaxTypes").html(returnHtml.substring(start, end));

        var startRowsCount = data.indexOf("###StartRowsCount###") + 20;
        var endRowsCount = data.indexOf("###EndRowsCount###");
        $("[id$='hdnTotalRowsItemTaxTypes']").val($.trim(returnHtml.substring(startRowsCount, endRowsCount)));

        if (paging == true) {
            GeneratePaging($("[id$='hdnTotalRowsItemTaxTypes']").val(), $("#ddlPagingItemTaxTypes").val(), "GridContainerItemTaxTypes", "FilterRecordItemTaxTypes");
        }

        if ($("[id$='hdnTotalRowsItemTaxTypes']").val() > 0)
            $("#GridContainerItemTaxTypes .spanInfo").html("Showing " + $("#gridContentsItemTaxTypes tr:first").children().first().html() + " to " + $("#gridContentsItemTaxTypes tr:last").children().first().html() + " of " + $("[id$='hdnTotalRowsItemTaxTypes']").val() + " entries");
    });
}

function addRecordItemTaxTypes() {

    resetRecordFormItemTaxTypes();

    $("#divAddNewRecordItemTaxTypes").dialog({
        title: "Add New Record",
        width: "auto",
        buttons: {
            "Save": function () {
                saveRecordItemTaxTypes("SAVE", 0);
            },
            "Cancel": function () {
                $("#divAddNewRecordItemTaxTypes").dialog("close");
            }
        },
        close: function () {
            $("#divAddNewRecordItemTaxTypes").dialog("destroy");
        }
    });
}

function editRecordItemTaxTypes(elem) {

    resetRecordFormItemTaxTypes();

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    var name = $.trim($(elem).closest("tr").find("td").eq(1).html());
    var rate = $.trim($(elem).closest("tr").find("td").eq(2).html());
    var taxExempt = $.trim($(elem).closest("tr").find("td").eq(3).find("span").html());
    var status = $(elem).closest("tr").find("td").eq(4).find("input").is(":checked");

    $("#txtNameItemTaxTypes").val(name);
    $("#txtTaxRateItemTaxTypes").val(rate);

    if (taxExempt == "Yes") {
        $("#ddlIsFullyExemptItemTaxTypes").val("True");
    }
    else {
        $("#ddlIsFullyExemptItemTaxTypes").val("False");
    }

    if (status) {
        $("#ddlStatusItemTaxTypes").val("Inactive");
    }
    else {
        $("#ddlStatusItemTaxTypes").val("Active");
    }

    $("#divAddNewRecordItemTaxTypes").dialog({
        title: "Edit Record",
        width: "auto",
        buttons: {
            "Save": function () {
                saveRecordItemTaxTypes("UPDATE", recordId);
            },
            "Cancel": function () {
                $("#divAddNewRecordItemTaxTypes").dialog("close");
            }
        },
        close: function () {
            $("#divAddNewRecordItemTaxTypes").dialog("destroy");
        }
    });
}

function saveRecordItemTaxTypes(action, recordId) {

    if (!ValidateForm("divAddNewRecordItemTaxTypes")) {
        showErrorMessage("Please fill all required fields.", "divAddNewRecordItemTaxTypes");
        return false;
    }

    var objItemTaxTypes = new Object();

    if (recordId != 0) {
        objItemTaxTypes.ItemTaxTypesId = recordId;
    }

    objItemTaxTypes.Name = $("[id$='txtNameItemTaxTypes']").val();
    objItemTaxTypes.Rate = $("[id$='txtTaxRateItemTaxTypes']").val();
    objItemTaxTypes.IsFullyTaxExempt = $("[id$='ddlIsFullyExemptItemTaxTypes']").val();
    objItemTaxTypes.Status = $("[id$='ddlStatusItemTaxTypes']").val();

    $.post("CallBacks/ItemTaxTypesHandler.aspx", { objItemTaxTypes: JSON.stringify(objItemTaxTypes), action: action }, function (data) {
        $("#divAddNewRecordItemTaxTypes").dialog("close");
        FilterRecordItemTaxTypes(0, true);

        if (action == "SAVE") {
            showSuccessMessage("Success: Record saved!", "divContentsDetailsWrapper");
        }
        else {
            showSuccessMessage("Success: Record updated!", "divContentsDetailsWrapper");
        }
    });
}

function deleteRecordItemTaxTypes(elem) {
    var isConfirm = confirm("Are you sure to delete the record?");
    if (!isConfirm) {
        return;
    }

    var recordId = $.trim($(elem).parent().find(".hdnRecordId").val());

    $.post("CallBacks/ItemTaxTypesHandler.aspx", { recordId: recordId, action: "DELETE" }, function (data) {
        FilterRecordItemTaxTypes(0, true);
        showSuccessMessage("Success: Record deleted!", "divContentsDetailsWrapper");
    });
}

function resetRecordFormItemTaxTypes() {
    $("[id$='txtNameItemTaxTypes']").val("");
    $("[id$='txtTaxRateItemTaxTypes']").val("");
    $("[id$='ddlIsFullyExemptItemTaxTypes']").val("0");
    $("[id$='ddlStatusItemTaxTypes']").val("0");
}

/*-----------------END--Item Tax Types-------------------*/