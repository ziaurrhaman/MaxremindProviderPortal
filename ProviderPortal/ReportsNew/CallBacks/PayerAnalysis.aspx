<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayerAnalysis.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PayerMixSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .ddlselect.analysisddlselect {
            float: left;
            max-height: 170px;
            overflow-y: auto;
            margin-bottom: -2px;
            border: 1px solid #c4c4c4;
            background: white;
            margin-top: 0;
            padding: 7px;
            position: relative;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
               <style type="text/css">
                   .ddlselect.analysisddlselect {
                       float: left;
                       max-height: 170px;
                       overflow-y: auto;
                       margin-bottom: -2px;
                       border: 1px solid #c4c4c4;
                       background: white;
                       margin-top: 0;
                       padding: 7px;
                       position: relative;
                       top: 0;
                   }
               </style>
            <div class="Filter SearchCriteria" style="display: none; height: auto !important;">
                <div class="row">
                    <div class="col-lg-6" style="padding-bottom: 10px;">
                        <div id="divReportPayerScenario">
                            <div class="divBranchName" style="">
                                <span class="spnBranchName" style="">Payer Scenario :</span>
                                <div class="BranceInput">
                                    <div class="reportdropdown" style="">
                                        <a onclick="ShowMenuFilters('divPayerScenario',this);">
                                            <div class="selectedText">
                                                All Payer Scenario
                                            </div>
                                            <div class="dropDownIcon" style="width: 8.5%; float: right; margin-right: -4%;">
                                                <img src="../../Images/dropdown.gif" style="width: 40%;" />
                                            </div>
                                        </a>
                                        <div id="divPayerScenario" class="div-multi-checkboxes-wrapper divPayerScenario" style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 99%;">
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

                    <div class="col-lg-3" style="margin-top: 6px !important;">
                        <div>
                            <input class='btn primary' type="button" title="Filter" value="Filter" id="FilterReports" onclick="FilterPayerAnalysis()" />
                            <input class='btn primary' type="button" title="Customize" value="Customize Report" id="CustomizeReports" onclick="CustomizePayerAnalysis()" disabled/>

                        </div>
                    </div>

                </div>

            </div>
            <asp:Repeater ID="rptPayerMixSummary" runat="server" OnItemDataBound="rptPayerMixSummary_ItemDataBound">
                <HeaderTemplate>
                    <div class="GridReports" id="printableArea">
                        <table>
                            <thead>
                                <tr>
                                    <th>
                                        <span class="report-column-title">#</span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');" style="width: 30%">
                                        <span class="report-column-title">Payer</span><span class=""></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');">
                                        <span class="report-column-title">Patients</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');">
                                        <span class="report-column-title">%</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');">
                                        <span class="report-column-title">Claims</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');">
                                        <span class="report-column-title">%</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');">
                                        <span class="report-column-title">CPT</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');">
                                        <span class="report-column-title">%</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');">
                                        <span class="report-column-title">Charges</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');" style="width: 8%">
                                        <span class="report-column-title">%</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');">
                                        <span class="report-column-title">Payments</span><span></span>
                                    </th>
                                    <th class="asc center" onclick="SortReportList(this,'PayerName');" style="width: 8%">
                                        <span class="report-column-title">%</span><span></span>
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyReportList" class="tbodyPayerAnalysis">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="center">
                            <%# Eval("RowNumber")%>
                        </td>
                        <td class="AlignString">
                            <%# Eval("PayerName")%>
                        </td>
                        <td class="center">
                            <asp:Label ID="lblPatient" runat="server"></asp:Label>
                        </td>
                        <td class="center">
                            <asp:Label ID="lblPtnt" runat="server"></asp:Label>
                        </td>
                        <td class="center">
                            <asp:Label ID="lblEncounter" runat="server"></asp:Label>
                        </td>
                        <td class="center">
                            <asp:Label ID="lblEncntrs" runat="server"></asp:Label>
                        </td>
                        <td class="center">
                            <asp:Label ID="lblProcedure" runat="server"></asp:Label>
                        </td>
                        <td class="center">
                            <asp:Label ID="lblProc" runat="server"></asp:Label>
                        </td>
                        <td class="AlignPayment">
                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                        </td>
                        <td class="center">
                            <asp:Label ID="lblChrgs" runat="server"></asp:Label>
                        </td>
                        <td class="AlignPayment">
                            <asp:Label ID="lblReceipt" runat="server"></asp:Label>
                        </td>
                        <td class="center">
                            <asp:Label ID="lblRcpts" runat="server"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                                   
                                </table>
                            </div>
                </FooterTemplate>
            </asp:Repeater>


            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <script>


                var Rows1 = "";
                var sort = "";
                function RowsChange(PageNumber, sort) {
                    debugger;
                    var params;
                    pageNumber = PageNumber;
                    Rows1 = $("#ddlPaging").val();
                    var Insurance = _NewInsuranceIds;
                    if (_selectedReport_Filter != "") {
                        params = {

                            Insurance: $("[id$='hdnInsurance']").val(),
                            Rows: Rows1,
                            PageNumber: pageNumber,
                            DateFrom: $("[id$='hdnDateFrom']").val(),
                            DateTo: $("[id$='hdnDateTo']").val(),
                            Rows: Rows1,
                            PageNumber: PageNumber,
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
