<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top10Payers.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_Top10Payers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
       <%-- <div class="Filter SearchCriteria" style="display: none; height: auto !important;">
            <div class="row">
                <div class="col-lg-4">
                    <div id="divReportPayerScenario" style="">
                        <div class="divBranchName" style="">
                            <span class="spnBranchName" style="">Payer Scenario :</span>
                            <div class="BranceInput">
                                <div class="reportdropdown" style="">
                                    <a onclick="hideShowMenu('divPayerScenario');">
                                        <div class="selectedText">
                                            All Payer Scenario
                                        </div>
                                        <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                            <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                        </div>
                                    </a>
                                    <div id="divPayerScenario" class="div-multi-checkboxes-wrapper" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
                                        <div class="ddlselect">
                                            <ul id="ulMultiPayerScenario">
                                                <li style="float: left; width: 100%;">
                                                    <label class="lbl-multi-checkboxes" onclick="Report_ClickMultiCheckBoxAll(this);" style="float: left;">
                                                        <input type="checkbox" id="chkPayerScenarioAll" class="chk-multi-checkboxes-all" checked="checked" />
                                                        <span>All Payer Scenario</span>
                                                        <input type="hidden" value="0" />
                                                    </label>
                                                </li>
                                                <asp:Repeater runat="server" ID="rptPayerScenario">
                                                    <ItemTemplate>
                                                        <li style="float: left; width: 100%;">
                                                            <label name='<%#Eval("InsuranceId") %>' onclick="Report_ClickMultiCheckBox(this);" style="float: left;">
                                                                <input type="checkbox" class="chkPayerScenario chk-multi-checkboxes" checked="checked" onclick="ReportAlert(this)" value='<%#Eval("InsuranceId") %>' />
                                                                <span><%#Eval("Name") %></span>
                                                                <input type="hidden" value='<%#Eval("InsuranceId") %>' id="InsuranceId" />
                                                            </label>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterTop10PayersReport()" />
                    <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizeTop10PayersReport()" disabled />

                </div>

            </div>
        </div>--%>
            <asp:Repeater ID="rptTherapyTask1" runat="server">
                <HeaderTemplate>
                    <div class="GridReports" id="printableArea">
                        <table>
                            <thead>
                                <tr>
                                    <th id="RowNumber" class="asc" >
                                        <span class="report-column-title">#</span><span class="asc"></span>
                                    </th>
                                    <th id="PatientId" class="asc">
                                        <span class="report-column-title">Payer Name</span><span class="asc"></span>
                                    </th>
                                    <%--<th id="PatientName" style="width: 10%;" >
                                        <span class="report-column-title">Total Patients</span> <span></span>
                                    </th>--%>
                                    <th id="BranchName" style="width: 10%; text-align: center;">
                                        <span class="report-column-title">Total Claims</span> <span></span>
                                    </th>


                                </tr>
                            </thead>
                            <tbody id="tbodyReportList" style="text-align: center">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <%# Eval("RowNumber")%>
                        </td>
                        <td>
                            <%# Eval("insurancename")%>
                        </td>
                        <%--<td style="text-align: center;">
                            <%# Eval("TotalPatients")%>
                        </td>--%>
                        <td style="text-align: center;">
                            <%# Eval("TotalClaims")%>
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
                $("ul#ulMultiPayerScenario li:nth-child(2)").remove();
                  //if (filename == "Top10Procedures.aspx" || filename == "Top10Payers.aspx" || filename == "Top10DxCodes.aspx") {
          $('.message').css("display", "none")
        //}
                var Rows1 = "";
                var sort = "";
                var TopPayers = "";
                function RowsChange(PageNumber, sort) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();
                    var Insurance = _NewInsuranceIds;

                    if (_selectedReport_Filter != "") {
                        params = {

                            PayerId: TopPayers,
                            Rows: Rows1,
                            PageNumber: pageNumber,

                            action: "Filter"
                        };

                        debugger
                        Report_ReloadData(_selectedReport_Filter, params, true);
                    }
                }
            </script>
            ###endReport###
        </div>


    </form>
</body>
</html>
