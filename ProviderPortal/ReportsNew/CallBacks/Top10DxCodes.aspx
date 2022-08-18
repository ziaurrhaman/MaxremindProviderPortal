<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top10DxCodes.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_Top10DxCodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
            <%--<div class="Filter SearchCriteria">
                <div class="row">
                    <div id="divReportDiagnosis" class="col-lg-6">

                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Diagnosis :</span>
                            <div class="clsDiagnosis BranceInput" id="divDiagnosis" style="">
                                <table>
                                    <tr>
                
                                        <td class="leftTd">
                                            <input type="text" id="txtIcdCode1" runat="server" class="upperCase" onkeyup="searchIcDs('C',this.value, '' , this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode1');" style="width: 100%; float: left;" />
                                            <span class="spnRemove" onclick="emptyICDVal(this, 1);"></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>

                    </div>
                    <div id="divICDsSearched" style="width: 27%;display:none; margin-top: 33px; margin-left: 150px;height: 274px; position: absolute; background-color: rgb(255, 255, 255); z-index: 999; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto;">
                        <div class="Grid" style="width: 103%; height: auto;">
                            <table>
                                <thead>
                                    <tr>
                                        <th>Code</th>
                                        <th>Description</th>
                                    </tr>
                                </thead>
                                <tbody id="IcdsSearchedList">
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="col-lg-3" style="margin-top: 2px !important;">
                        <div>
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterDiagnosisCodeReport()" />
                            <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeDiagnosisCodeReport()" disabled />

                        </div>
                    </div>
                </div>
            </div>--%>
            <div>
                <div class="GridReports" id="printableArea">

                    <table>
                        <thead>
                            <tr>
                                <th id="RowNumber" class="asc">
                                    <span class="report-column-title">#</span><span class=""></span>
                                </th>

                                <th id="PatientId" class="asc" style="width: 10%; text-align: center">
                                    <span class="report-column-title">Diagnosis Codes</span> <span></span>
                                </th>
                                <th id="PatientName">
                                    <span class="report-column-title">Description</span> <span></span>
                                </th>
                                <th id="BranchName" style="width: 10%; text-align: center;">
                                    <span class="report-column-title">Frequency</span><span class=""></span>
                                </th>

                            </tr>
                        </thead>
                        <tbody id="tbodyReportList" class="MostCommonlyUsedDxCodes">
                            <asp:Repeater ID="rptTop10DxCodes" runat="server">
                                <ItemTemplate>


                                    <tr>
                                        <td class="align_center">
                                            <%# Eval("RowNumber")%>

                                            <td class="align_center">
                                                <%# Eval("DiagnosisCode")%>
                                            </td>
                                            <td class="align_left">
                                                <%# Eval("OfficialName")%>
                                            </td>
                                        </td>
                                        <td class="align_center">
                                            <%# Eval("NoOfTimesUsed")%>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />

                </div>
                <script>
                    var Rows1 = ""; var UserId = 0;
                    function RowsChange(PageNumber, sortValue) {
                        $('.message').css("display", "none")

                        debugger;
                        var params;
                        pageNumber = PageNumber;
                        var paging = true;
                        var filename = "MostCommonlyUsedDxCodes.aspx";
                        Rows1 = $("#ddlPaging").val();
                        var _selectedReport_Filter = "FilterMostCommonlyUsedDxCodes.aspx";
                        if (_selectedReport_Filter != "") {
                            params = {
                                Rows: Rows1,
                                PageNumber: pageNumber,
                                action: "Filter"
                            };

                            debugger
                            Report_ReloadData(_selectedReport_Filter, params, paging);
                        }
                    }
                </script>
            </div>
            ###endReport###
        </div>
    </form>
</body>
</html>
