$(function () {
    debugger
   
    // Proxy created on the fly
    var cus = $.connection.chatHub;

    // Declare a function on the job hub so the server can invoke it
    cus.client.displayCustomer = function () {
        getData();
    };

    // Start the connection
    $.connection.hub.start().done(function () { getData();})
    
});

function getData() {
    debugger
    $.post("../../ProviderPortal/Chat/ChatClientSupportHandler.aspx", {action:"chatfunction"} ,function (data) {
        debugger
        var start = data.indexOf("###StartChat###") + 15
        var end = data.indexOf("###EndChat###");
        var returnHtml = $.trim(data.substring(start, end));
        $(".Tbodyclass").html(returnHtml);

    });
}