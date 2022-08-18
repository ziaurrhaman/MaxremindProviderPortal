

function toggleWaitingRoom() {
    if ($("#waiting-patient-list").hasClass("invisible-patient-list")) {
        $("#waiting-patient-list").removeClass("invisible-patient-list").addClass("visible-patient-list");
    }
    else {
        $("#waiting-patient-list").removeClass("visible-patient-list").addClass("invisible-patient-list");
    }
}