<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top10Procedures.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_Top10Procedures" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
<%--        <div class="Filter SearchCriteria" style="display: none; height: auto !important;">
            <div class="row">
                <div class="col-lg-6" style="position: relative;">
                    <div id="divReportProcedure">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Procedure :</span>
                            <div class="clsDiagnosis BranceInput" id="divProcedure" style="position: relative;">
                                <table>
                                    <tr>

                                        <td class="leftTd">
                                            <input type="text" id="txtCPTCode" runat="server" class="required" onkeyup="searchCPTs('C', this.value, '', this, event);" onchange="PopulateCPTCode(this, 'txtCPTDescription');" style="float: left; width: 91%;" />
                                            <span class="spnRemove" onclick="emptyCPTVal(this, 1);" style="position: absolute; padding: 5px;">
                                                <img src="../../Images/cancel.png" width="16" height="16" />
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divCPTSearched" style="height: 305px; margin-top: -8px; position: absolute; display: none; background-color: #fff; z-index: 990; border: 1px solid rgb(211, 211, 211); padding-bottom: 31px; overflow-y: auto;">
                                    <div class="Grid" style="width: 99%; height: auto;">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>Code</th>

                                                    <th>
                                                        <div onclick="closeCPTSearched(this)" class="spnclose">
                                                            <img alt="" src="../../Images/close_icon.png" style="border-radius: 100px; float: right; margin-right: 6px;" width="25" height="25" />
                                                        </div>
                                                        Description</th>
                                                </tr>
                                            </thead>
                                            <tbody id="CPTSearchedList">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-lg-3">
                    <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterTop10ProcedureReport()" />
                    <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeTop10ProcedureReport()" disabled />

                </div>
            </div>
        </div>--%>
            <asp:Repeater ID="rptTherapyTask" runat="server">
                <HeaderTemplate>
                    <div class="GridReports" id="printableArea">
                        <table id="">
                            <thead>
                                <tr>
                                    <th id="RowNumber" class="asc">
                                        <span class="report-column-title">#</span><span class="asc"></span>
                                    </th>
                                    <th id="PatientId" class="asc" style="width: 10%; text-align: center">
                                        <span class="report-column-title">Procedure</span><span class="asc"></span>
                                    </th>
                                    <th id="PatientName">
                                        <span class="report-column-title">Description</span> <span></span>
                                    </th>
                                    <th id="BranchName" style="width: 10%; text-align: center;">
                                        <span class="report-column-title">Frequency</span> <span></span>
                                    </th>


                                </tr>
                            </thead>
                            <tbody id="tbodyReportList">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <%# Eval("RowNumber")%>
                        </td>
                        <td style="text-align: center;">
                            <%# Eval("CPTCode")%>
                        </td>
                        <td>
                            <%# Eval("Shortdescription")%>
                        </td>
                        <td style="text-align: center;">
                            <%# Eval("CPTCOUNT")%>
                        </td>


                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table> </div>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="inpHide" runat="server" />
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <script>
                debugger
                var Rows1 = ""; var UserId = 0;
                $('.message').css("display", "none")

                function closeCPTSearched(elem) {
                    debugger
                    $(elem).parentsUntil().find("#divCPTSearched").css("display", "none")
                }
                function RowsChange(PageNumber, sortValue) {

                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    var paging = true;
                    var filename = "Top10Procedures.aspx";
                    Rows1 = $("#ddlPaging").val();
                    //var _selectedReport_Filter = "FilterTopProcedures.aspx";
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
            ###endReport###
        </div>
    </form>
</body>
</html>
