

function loadContentPage(page, recordId) {
    
    if ($("[id$='" + page + "']").css("display") != "none") {
        return false;
    }
    
    $(".parent").hide();
    
    $("[id$='SalesOrderEntry']").html("");
    $("[id$='SalesOrders']").html("");
    $("[id$='SaleTypes']").html("");
    $("[id$='PurchaseOrderEntry']").html("");
    $("[id$='PurchaseOrders']").html("");
    $("[id$='SupplierEntry']").html("");
    $("[id$='SupplierList']").html("");
    $("[id$='ItemsEntry']").html("");
    $("[id$='ItemsList']").html("");
    $("[id$='ItemCategories']").html("");
    $("[id$='ItemTaxTypes']").html("");
    
    $("#" + page).show();
    
    if (page == "SalesOrderEntry") {
        $(".contents-details-header").html("Sales Order Entry");
        loadSalesOrdersEntryPage();
    }
    else if (page == "SalesOrders") {
        $(".contents-details-header").html("Sales Orders");
        loadSalesOrdersPage();
    }
    else if (page == "SaleTypes") {
        $(".contents-details-header").html("Sales Types");
        loadSaleTypesPage();
    }
    else if (page == "ItemsEntry") {
        $(".contents-details-header").html("Item");
        loadItemsEntryPage(recordId);
    }
    else if (page == "ItemsList") {
        $(".contents-details-header").html("Item List");
        loadItemsPage();
    }
    else if (page == "ItemCategories") {
        $(".contents-details-header").html("Item Categories");
        loadItemCategoriesPage();
    }
    else if (page == "ItemTaxTypes") {
        $(".contents-details-header").html("Item Tax Types");
        loadItemTaxTypesPage();
    }
    else if (page == "SupplierList") {
        $(".contents-details-header").html("Supplier List");
        loadSupplierListPage();
    }
    else if (page == "SupplierEntry") {
        $(".contents-details-header").html("Supplier");
        loadSupplierEntryPage(recordId);
    }
    else if (page == "PurchaseOrderEntry") {
        $(".contents-details-header").html("Purchase Order Entry");
        loadPurchaseOrderEntryPage(recordId);
    }
    else if (page == "PurchaseOrders") {
        $(".contents-details-header").html("Purchase Orders");
        loadPurchaseOrdersPage();
    }
    else if (page == "SalesOrderDelivery") {
        $(".contents-details-header").html("Sales Order Delivery");
        loadSalesOrderDeliveryPage(recordId);
    }
}