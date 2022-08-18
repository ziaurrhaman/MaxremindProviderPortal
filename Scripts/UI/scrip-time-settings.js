

var tdApplyToIsFirstSelectedDay = true;

$(document).ready(function () {
    
    $(".tblSub .timepicker").timepicker();
    $(".timepickerStartClose").timepicker();
    
    $("#btnSaveTimings").click(function () {
        
        var settingType = $("#hfPanelId").val();

        if (settingType == "normalTimeSettingWrapper") {
            
            var daysSelected = $("#trApplyTo").find(':checked').length;
            if (daysSelected == 0) {
                alert("Please select some day to apply settings!");
            }
            else if (daysSelected > 1) {
                $("#dialog-confirm-save-time-setting-apply-to-multiple-days").dialog("open");
            }
            else {

                SaveTimings();
            }
            
        }
        else if (settingType == "detailTimeSettingWrapper") {
            saveDetailTimings();
        }
    });
    
    $("#ddlProviders").change(function () {
        
        callBackTimings();
        
    });
    
    
    
    $("#dialog-confirm-save-time-setting-apply-to-multiple-days").dialog({
        resizable: false,
        autoOpen: false,
        height: 170,
        modal: true,
        buttons: {
            "Yes": function () {
                $(this).dialog("close");
                SaveTimings();
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
    
});

function callBackTimings() {
    
    if ($("#hfPanelId").val() == "detailTimeSettingWrapper") {
        
        var providerId = $('#ddlProviders').val();
        var action = "Detail";
        
        $.post("CallBacks/ProviderTimingsHandler.aspx", { providerId: providerId, action: action },
            function (data) {
                var returnHtml = data;
                var startIndex = data.indexOf("###ResultDetailSettingsStart###") + 31;
                var lastIndex = data.indexOf("###ResultDetailSettingsEnd###");
                
                var returnValue = returnHtml.substring(startIndex, lastIndex);
                $("#detailTimeSettingWrapper").html(returnValue);
                $(".timepickerStartClose").timepicker();
                $(".timepickerBreak").timepicker();
                //$("#detailResult").tabs();
                
            }
        );
        
    }
    else if ($("#hfPanelId").val() == "normalTimeSettingWrapper") {
        
        var providerId = $('#ddlProviders').val();
        var action = "Normal";

        $.post("CallBacks/ProviderTimingsHandler.aspx", { providerId: providerId, NameOfDay: 'All', action: action },
            function (data) {
                var returnHtml = data;
                var startIndex = data.indexOf("###ResultStart###") + 17;
                var lastIndex = data.indexOf("###ResultEnd###");

                var returnValue = returnHtml.substring(startIndex, lastIndex);
                returnValue = returnValue.replace("###ResultUpToBreaksEnd###", "");
                $("#normalTimeSettingWrapper").html(returnValue);
                $(".timepickerStartClose").timepicker();
                $(".timepickerBreak").timepicker();

            }
        );
        
    }
    
}


function toggleSettings(hideLink, showLink, hidePanel, showPanel){
    
    $("." + hideLink).css("display", "none");
    $("." + showLink).css("display", "block");
    
    $("#hfPanelId").val(showPanel);
    callBackTimings();
    
    $("#" + hidePanel).css("display", "none");
    $("#" + showPanel).css("display", "block");
    
}


function changeDayOnLoad(tdApplyToDay) {
    
    if (tdApplyToIsFirstSelectedDay) {
        
        $(".tdApplyTo").each(function () {
            $(this).removeClass("tdApplyToSelected");
        });
        
        $("." + tdApplyToDay).addClass("tdApplyToSelected");
        
        tdApplyToIsFirstSelectedDay = false;
    }
    
}

function changeDay(tdApplyToDay) {

    $(".tdApplyTo").each(function () {
        $(this).css("background", "url('../../Images/bgGridHeader.png') repeat scroll 0 0 transparent");
    });

    //$("." + tdApplyToDay).addClass("tdApplyToSelected");
    $("." + tdApplyToDay).css("background", "url('../../Images/bgHeaderSelected.png') repeat scroll 0 0 transparent");

    var NameOfDay = $("." + tdApplyToDay).children("span").html();

    FilterLocationTimeSettingByDay(NameOfDay);
    
}

function FilterLocationTimeSettingByDay(NameOfDay) {

    var providerId = $("#ddlProviders").val();

    var action = "Normal";

    $.post("CallBacks/ProviderTimingsHandler.aspx", { providerId: providerId, NameOfDay: NameOfDay, action: action },
            function (data) {
                
                var returnHtml = data;
                var startIndex = data.indexOf("###ResultStart###") + 17;
                var lastIndex = data.indexOf("###ResultUpToBreaksEnd###");
                
                var returnValue = returnHtml.substring(startIndex, lastIndex);

                $("#normalTimeSettingsUpToBreaks").html(returnValue);
                $(".timepickerStartClose").timepicker();

            }
        );
    
}

function addBreakRow(startTime, endTime, breakType) {
    
    var $SampleBreakRow = $("#tblBreakSample tr.trBreakTime").clone();
    
    $SampleBreakRow.find("input[name='breakStartTime']").val(startTime);
    $SampleBreakRow.find("input[name='breakEndTime']").val(endTime);
    if (breakType != '') {
        $SampleBreakRow.find("select").val(breakType);
    }
    
    $("#trAddButton").before($SampleBreakRow);
    
    $SampleBreakRow.find(".timepicker").timepicker();
    
}

function addBreakRowToSpecificDay(startTime, endTime, breakType, addButtonID) {
    
    var $SampleBreakRow = $("#tblBreakSample tr.trBreakTime").clone();
    
    $SampleBreakRow.find("input[name='breakStartTime']").val(startTime);
    $SampleBreakRow.find("input[name='breakEndTime']").val(endTime);
    if (breakType != '') {
        $SampleBreakRow.find("select").val(breakType);
    }
    
    $("#" + addButtonID).before($SampleBreakRow);
    
    $SampleBreakRow.find(".timepicker").timepicker();
    
}

function romoveBreakRow(elem) {
    $(elem).closest("tr").remove();
}


function switchContent(contentId, link) {
    
    $(".Tab-Content").each(function () {
        $(this).css("display", "none");
    });
    
    $("#" + contentId).css("display", "");
    
    $(".box-header ul li a").parent().siblings().removeClass("active");
    $(link).parent().addClass("active");
    
}