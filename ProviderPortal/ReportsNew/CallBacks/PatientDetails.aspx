<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientDetails.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
            <style>
                .patient-rpt-outer table tr:nth-child(odd) {
                    background: none !important;
                }

                #tbodyReportList tr:nth-child(odd) {
                    background: none !important;
                }
            </style>
            <div class="Filter SearchCriteria" style="display: none; height: auto !important;">
                <div class="row">
                    <div class="col-lg-4">
                        <div id="divPatientSarch" runat="server" style="">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Patient Name:</span>
                                <div class="clsPatientId BranceInput" style="position: relative;">
                                    <input type="text" id="TxtPatientSearch" onkeyup="searchPatient(event,this)" />
                                   <%-- <img src="../../Images/arrow_down5.PNG" style="width: 11px; margin-top: 11px; margin-left: -15px; position: absolute;" onclick="searchPatient(event,this)" />--%>
                                    <input type="hidden" id="hdnsearchpatientid" />
                                    <div id="SearchPatientList" class="PatientDetailsRptGrid" style="display: none"></div>
                                    <%--<div id="SearchPatientCustomize" style="display: none"></div>--%>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-lg-3" style="margin-top: 0 !important;">
                        <div>
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPatientDetails()" />
                            <input class="btn primary" type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePatientDetails('PatientDetails')" disabled />
                        </div>
                    </div>

                </div>

            </div>
            <div id="tbodyReportList">
            </div>

            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <div id="divDialogReportFilters" style="display: none;"></div>



            <script type="text/javascript">
                debugger;
                //$('.SelectFilterMessage').css("display", "")
                var Rows1 = "";
                function RowsChange(PageNumber, sortValue) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();

                    var paging = true;

                    if (_selectedReport_Filter != "") {
                        params = {
                            PatientId: $("[id$='hdnPatientId']").val(),
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            SortBy: sortValue,
                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }
                }

            </script>


            ###endReport###
        </div>
    </form>
</body>
</html>
