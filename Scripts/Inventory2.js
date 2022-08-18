
function loadSalesOrderDeliveryPage() {
    $.post("SalesOrderDelivery.aspx", {}, function (data) {
        var returnHtml = data;
        var start = data.indexOf("###StartSalesOrderDelivery###") + 29;
        var end = data.indexOf("###EndSalesOrderDelivery###");
        $("#SalesOrderDelivery").html($.trim(returnHtml.substring(start, end)));
        readySalesOrderEntryPage();
    });
}
