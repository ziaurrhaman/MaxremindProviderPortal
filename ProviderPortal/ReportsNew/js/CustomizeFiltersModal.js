function CustomizeItemizationOfChargesReport() {
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeItemizationOfChargesReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Itemization Of Charges Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {
                FilterItemizationOfChargesReport('Customize')
                $("#CustomizeItemizationOfChargesReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeProviderCollectionReport() {
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeProviderCollectionReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Provider Collection Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {
                FilterProviderCollectionReport('Customize')
                $("#CustomizeProviderCollectionReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeProviderProductivity() {
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeProviderProductivity").dialog({
        width: 800,

        modal: true,
        title: "Customize Provider Productivity",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {
                FilterProviderProductivity('Customize')
                $("#CustomizeProviderProductivity").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeProcedurePaymentsSummaryAndDetail() {
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeProcedurePaymentsSummaryAndDetail").dialog({
        width: 800,

        modal: true,
        title: "Customize Procedure Payments Summary And Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {
                FilterProcedurePaymentsSummaryAndDetail('Customize')
                $("#CustomizeProcedurePaymentsSummaryAndDetail").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeARAgingReport() {
    debugger
    // OpenPaymentsFilterDialog(ReportName, true, "", TabFilename);

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeARAgingFilter").dialog({
        width: 800,

        modal: true,
        title: "Customize AR Aging Filter",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterArAgingSummary('Customize')
                $("#CustomizeARAgingFilter").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePostClaimSummary() {
    debugger
    // OpenPaymentsFilterDialog(ReportName, true, "", TabFilename);

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePostClaimSummary").dialog({
        width: 800,

        modal: true,
        title: "Customize Post Claim Summary",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPostClaimSummary('Customize')
                $("#CustomizePostClaimSummary").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePaymentApplicationReport() {
    debugger
    // OpenPaymentsFilterDialog(ReportName, true, "", TabFilename);

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePaymentApplicationReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Payment Application Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPaymentApplicationReport('Customize')
                $("#CustomizePaymentApplicationReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePatientBalanceReport() {
    debugger

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePatientBalanceReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Patient Balance Summary And Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                GetPatBalFilter('Customize')
                $("#CustomizePatientBalanceReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeLocationwisecollection() {
    debugger

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeLocationwisecollection").dialog({
        width: 800,

        modal: true,
        title: "Customize Location Wise Collection",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterLocationWiseCollection('Customize')
                $("#CustomizeLocationwisecollection").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeCPTWiseCollection() {
    debugger

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeCPTWiseCollection").dialog({
        width: 800,

        modal: true,
        title: "Customize CPT Wise Collection",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterCPTWise('Customize')
                $("#CustomizeCPTWiseCollection").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeClaimSummaryAndDetail() {
    debugger

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeClaimSummaryAndDetail").dialog({
        width: 1000,

        modal: true,
        title: "Customize Claim Summary And Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterClaimSummaryAndDetail('Customize')
                $("#CustomizeClaimSummaryAndDetail").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeChargesSummaryAndDetail() {
    debugger

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeChargesSummaryAndDetail").dialog({
        width: 1000,

        modal: true,
        title: "Customize Charges Summary And Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterChargesSummaryAndDetail('Customize')
                $("#CustomizeChargesSummaryAndDetail").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeRejectedDeniedSummaryAndDetail() {
    debugger

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeRejectedDeniedSummaryAndDetail").dialog({
        width: 800,

        modal: true,
        title: "Customize Rejected Denied Summary And Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterRejectedDeniedSummaryAndDetail('Customize')
                $("#CustomizeRejectedDeniedSummaryAndDetail").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeUnpostedPaymentsDetailandSummary() {
    debugger

    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeUnpostedPaymentsDetailandSummary").dialog({
        width: 800,

        modal: true,
        title: "Customize Unposted Payments Detail and Summary",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterUnpostedPaymentsDetailandSummary('Customize')
                $("#CustomizeUnpostedPaymentsDetailandSummary").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeUnPaidInsurance() {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeUnpaidInsuranceFilter").dialog({
        width: 800,

        modal: true,
        title: "Customize Unpaid Insurance Filter",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterUnPaidInsurance('Customize')
                $("#CustomizeUnpaidInsuranceFilter").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePaymentsDetail(elem) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePaymentDetailFilter").dialog({
        width: 800,

        modal: true,
        title: "Customize Payments Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPaymentsDetail(this, 'Customize')
                $("#CustomizePaymentDetailFilter").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePatientContactList(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeContactListFilter").dialog({
        width: 800,

        modal: true,
        title: "Customize Patient Contact List",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPatientContactList('Customize')
                $("#CustomizeContactListFilter").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePatientBalanceDetailReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePatientBalanceDetailReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Patient Balance Detail Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPatientBalanceDetail(this, 'Customize')
                $("#CustomizePatientBalanceDetailReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeDeductableReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeDeductableReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Patient Responsibility Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterDeductableReport('Customize')
                $("#CustomizeDeductableReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}

function CustomizeAdjustmentsDetailReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeAdjustmentsDetailReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Adjustment Summary And Detail Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterAdjustmentsDetailReport('Customize')
                $("#CustomizeAdjustmentsDetailReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeContractManagementDetailReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeContractManagementDetailReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Contract Management Detail Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterContractManagementDetailReport('Customize')
                $("#CustomizeContractManagementDetailReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}

function CustomizeContractManagementSummaryReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeContractManagementSummaryReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Contract Management Summary Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterContractManagementSummaryReport('Customize')
                $("#CustomizeContractManagementSummaryReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function PaymentsSummaryAndDetail(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#PaymentsSummaryAndDetail").dialog({
        width: 800,

        modal: true, 
        title: "Customize Payments Summary And Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPaymentsSummaryAndDetail('Customize')
                $("#PaymentsSummaryAndDetail").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeUnAppliedAnalysis(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeUnAppliedAnalysis").dialog({
        width: 800,

        modal: true,
        title: "Customize UnApplied Analysis Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterUnappliedAnalysisReport('Customize')
                $("#CustomizeUnAppliedAnalysis").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePatientDemographics(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePatientDemographics").dialog({
        width: 800,

        modal: true,
        title: "Customize Patient Demographics",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPatientDemographics('Customize')
                $("#CustomizePatientDemographics").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}

function CustomizeOverPaidClaimsReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeOverPaidClaimsReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Over Paid Claims",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterOverPaidClaimsReport('Customize')
                $("#CustomizeOverPaidClaimsReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}


function CustomizePTLClaimReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePtlClaimReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Ptl Claims",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPTLClaimReport('Customize')
                $("#CustomizePtlClaimReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}

function CustomizePatientTransactionsDetail(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePatientTransactionsDetail").dialog({
        width: 800,

        modal: true,
        title: "Customize Patient Transactions Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPatientTransactionsDetail('Customize')
                $("#CustomizePatientTransactionsDetail").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}

function CustomizePTLPatientReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePtlPatientReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Ptl Patient",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPTLPatientReport('Customize')
                $("#CustomizePtlPatientReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}

function CustomizePatientSummaryReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePatientSummaryReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Patient Payer Summary",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPatientSummaryReport('Customize')
                $("#CustomizePatientSummaryReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeAdjustmentsSummaryReport(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeAdjustmentsSummaryReport").dialog({
        width: 800,

        modal: true,
        title: "Customize Adjustments Summary Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterAdjustmentsSummaryReport('Customize')
                $("#CustomizeAdjustmentsSummaryReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePaymentsSummaryAndDetail(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePaymentsSummaryAndDetail").dialog({
        width: 800,

        modal: true,
        title: "Customize Payments Summary And Detail",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPaymentsSummaryAndDetails('Customize')
                $("#CustomizePaymentsSummaryAndDetail").dialog("destroy");
                $(this).dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
            $(this).dialog("destroy");
        }
    });
}
function CustomizeDuplicateChecks(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeDuplicateChecks").dialog({
        width: 800,

        modal: true,
        title: "Customize Duplicate Checks",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterDuplicateChecks('Customize')
                $("#CustomizeDuplicateChecks").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePaymentApplicationSumary(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePaymentApplicationSumary").dialog({
        width: 800,

        modal: true,
        title: "Customize Payment Application Summary",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPaymentApplicationSumary('Customize')
                $("#CustomizePaymentApplicationSumary").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizePayerAnalysis(Customize) {
    debugger
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizePayerAnalysis").dialog({
        width: 800,

        modal: true,
        title: "Customize Payer Analysis",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {

                FilterPayerAnalysis('Customize')
                $("#CustomizePayerAnalysis").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function CustomizeClaimsSubmissionReport() {
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeClaimsSubmissionReport").dialog({
        width: 800,

        modal: true,
        title: "Customize ClaimsSubmission Report",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {
                FilterClaimsSubmissionReport('Customize')
                $("#CustomizeClaimsSubmissionReport").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}
function ClosingDiv() {
    debugger
    $(".divPayerScenario").css("display", "none")
    $(".divPracticeLocation").css("display", "none")
    $(".divServiceProvider").css("display", "none")
    $(".divPlaceOfService").css("display", "none")
    $(".divFileStatus").css("display", "none")


}
function CustomizeClaimsSubmissionReport()
{
    $.ui.dialog.prototype._focusTabbable = function () { };
    $("#CustomizeClaimsSubmissionStatusSummary").dialog({
        width: 800,

        modal: true,
        title: "Customize Claims Submission Status Summary",
        open: function () {
            $(".ui-widget-overlay").last().css("z-index", "9999999");
            $(".ui-dialog").last().css("z-index", "99999999");
        },
        buttons: {
            "Close": function () {
                debugger
                $(this).dialog("destroy");
                ClosingDiv()

            },
            "OK": function () {
                FilterClaimsSubmissionReport('Customize')
                $("#CustomizeClaimsSubmissionStatusSummary").dialog("destroy");
                ClosingDiv()

            }
        },
        close: function () {
            debugger
            ClosingDiv()
        }
    });
}