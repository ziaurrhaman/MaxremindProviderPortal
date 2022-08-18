
$(document).ready(function () {
    loadFilter();
    $("#txtlocation").focusin(function () { $('#divPracticeLocation').show(); });
   
});



    

function loadFilter() {
    $(".PostClaimFilter").dialog({
        title: "Filter",
        height: 500,
        width: 600,
        modal: true,
        buttons: {
            Select: function () {

            },
            Cancel: function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            $(this).dialog("destroy");
        }
    });

}


function hideCustomeddl(elem) {
    $(elem).closest('td').find('.customddl').hide();
}
