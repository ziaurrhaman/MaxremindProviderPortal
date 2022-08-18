

function showHideCharts(chartToShow, elem) {
    $("#divChartContent > div").hide();
    $("#" + chartToShow).show();

    $("[id$='ulChartMenu'] > li").removeClass("selected");
    $(elem).addClass("selected");

    $(".Date").datepicker({
        changeMonth: true,
        changeYear: true
    }).mask("99/99/9999");
}

function loadReasonForVisit(elem) {
    if ($.trim($("#divRFV").html()).length == 0) {
        $.post("../Chart/ReasonForVisits.aspx", { ChartId: _ChartId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartReasonForVisit###") + 25;
            var end = data.indexOf("###EndReasonForVisit###");
            $("#divRFV").html(returnHtml.substring(start, end));
        });
    }
    showHideCharts("divRFV", elem);
}

function loadReviewOfSystem(elem) {
    if ($.trim($("#divROSContainerWrapper").html()).length == 0) {
        $.post("../Chart/ReviewofSystem.aspx", { ChartId: _ChartId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartROS###") + 14;
            var end = data.indexOf("###EndROS###");
            $("#divROSContainerWrapper").html(returnHtml.substring(start, end));


        });
    }
    showHideCharts("divROSContainerWrapper", elem);
}

function loadPhysicialExam(elem) {
    if ($.trim($("#divPhysicalExamContainerWrapper").html()).length == 0) {
        $.post("../Chart/PhysicalExam.aspx", { ChartId: _ChartId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartPhysicialExam###") + 24;
            var end = data.indexOf("###EndPhysicialExam###");
            $("#divPhysicalExamContainerWrapper").html(returnHtml.substring(start, end));
        });
    }
    showHideCharts("divPhysicalExamContainerWrapper", elem);

}

function loadSocailHistory(elem) {
    if ($.trim($("#divSocialHistoryWrapper").html()).length == 0) {
        $.post("../Chart/SocialHistory.aspx", { ChartId: _ChartId, PatientId: _PatientId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartSocialHistory###") + 24;
            var end = data.indexOf("###EndSocialHistory###");
            $("#divSocialHistoryWrapper").html(returnHtml.substring(start, end));
        });
    }
    showHideCharts("divSocialHistoryWrapper", elem);

}

function loadFamilyHistory(elem) {
    if ($.trim($("#divFamilyHistoryWrapper").html()).length == 0) {
        $.post("../Chart/FamilyHistory.aspx", { ChartId: _ChartId, PatientId: _PatientId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartFamilyHistory###") + 24;
            var end = data.indexOf("###EndFamilyHistory###");
            $("#divFamilyHistoryWrapper").html(returnHtml.substring(start, end));
        });
    }
    showHideCharts("divFamilyHistoryWrapper", elem);
}

function loadImmunization(elem) {
    if ($.trim($("#divImmunizationWrapper").html()).length == 0) {
        $.post("../Chart/Immunizations.aspx", { ChartId: _ChartId, PatientId: _PatientId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartImmunization###") + 23;
            var end = data.indexOf("###EndImmunization###");
            $("#divImmunizationWrapper").html(returnHtml.substring(start, end));
            $("#divChartContent .Time").timeEntry({ show24Hours: true, showSeconds: true, spinnerBigImage: "../Images/spinnerDefault.png" });
        });
    }
    showHideCharts("divImmunizationWrapper", elem);
}

function loadPatientSurgeries(elem) {
    if ($.trim($("#divPastSurgeriesWrapper").html()).length == 0) {
        $.post("../Chart/PastSurgeries.aspx", { ChartId: _ChartId, PatientId: _PatientId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartSurgeries##") + 20;
            var end = data.indexOf("###EndSurgeries###");
            $("#divPastSurgeriesWrapper").html(returnHtml.substring(start, end));
        });
    }
    showHideCharts("divPastSurgeriesWrapper", elem);
}

function loadPatientProblems(elem) {
    if ($.trim($("#divPatientProblemWrapper").html()).length == 0) {
        $.post("../Chart/ProblemList.aspx", { ChartId: _ChartId, PatientId: _PatientId }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartProblems##") + 20;
            var end = data.indexOf("###EndProblems###");
            $("#divPatientProblemWrapper").html(returnHtml.substring(start, end));
        });
    }
    showHideCharts("divPatientProblemWrapper", elem);
}

function loadPatientPrescription(elem) {
    if ($.trim($("#divPatientPrescription").html()).length == 0) {
        $.post("../Chart/PatientPrescription.aspx", { ChartId: _ChartId, PatientId: _PatientId, PatientPrescriptionId:0 }, function (data) {
            var returnHtml = data;
            var start = data.indexOf("###StartPrescription###") + 23;
            var end = data.indexOf("###EndPrescription###");
            $("#divPatientPrescription").html(returnHtml.substring(start, end));
        });
    }
    showHideCharts("divPatientPrescription", elem);
}