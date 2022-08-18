<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MostCommonlyUsedDxCodes.aspx.cs" Inherits="ProviderPortal_ReportsNew_CallBacks_MostCommonlyUsedDxCodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###startReport###
            <div class="Filter SearchCriteria">
                <div class="row">
                    <div id="divReportDiagnosis" class="col-lg-6">

                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Diagnosis :</span>
                            <div class="clsDiagnosis BranceInput" id="divDiagnosis" style="position: relative;">
                                <table>
                                    <tr>
                                        <%--<td style="width: 140px" class="leftTd">
                                                <input type="text" id="txtIcdCode1" class="required" runat="server" onkeyup="searchIcDs('C', this.value, '', this, event);" onchange="PopulateICD9Desc(this, 'txtIcdDesc1');" style="width: 85%;" />
                                            </td>--%>
                                        <td class="leftTd">
                                            <input type="text" id="txtIcdCode1" runat="server" class="upperCase" onkeyup="searchIcDs('C',this.value, '' , this, event);" onchange="PopulateICD9Code(this, 'txtIcdCode1');" style="width: 100%; float: left;" />
                                            <span class="spnRemove" onclick="emptyICDVal(this, 1);"></span>
                                        </td>
                                    </tr>
                                </table>

                                <div id="divICDsSearched" style="width: 100%; margin-top: -7px; height: 305px; position: absolute; display: none; background-color: #fff; z-index: 999; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto;">
                                    <div class="Grid" style="width: 100%; height: auto;">
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
                            </div>
                        </div>

                    </div>

                    <div class="col-lg-3">

                        <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterCommonlyUsedDxCodesReport()" />
                        <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeCommonlyUsedDxCodesReport()" disabled />


                    </div>
                </div>
            </div>
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
                        <asp:Repeater ID="rptMostCommonlyUsedDxCodes" runat="server">
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

                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    var paging = true;
                    var filename = "MostCommonlyUsedDxCodes.aspx";
                    var DiagnosisCode = $("#txtIcdCode1").val().split('-')[0];
                    Rows1 = $("#ddlPaging").val();

                    var _selectedReport_Filter = "FilterMostCommonlyUsedDxCodes.aspx";
                    if (_selectedReport_Filter != "") {
                        params = {
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            DiagnosisCode: DiagnosisCode,
                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, paging);
                    }
                }
            </script>
        </div>
        ###endReport###

    </form>
</body>
</html>
