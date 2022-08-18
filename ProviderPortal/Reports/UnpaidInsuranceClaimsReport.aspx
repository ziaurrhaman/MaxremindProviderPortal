<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="UnpaidInsuranceClaimsReport.aspx.cs" Inherits="ProviderPortal_Reports_UnpaidInsuranceClaimsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    ###StartReport###
    <style type="text/css">
        .dropDownMenu {
            margin-top: -3% !important;
            height: 20px;
        }
    </style>
    <div class="Widget" style="margin-top: 10px;">
        <%--<div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Unpaid Insurance Claims</span>
        </div>--%>
        <div class="reportsCriteriabar" style="background: #dfe3e5; height: 36px;">
            <div class="report-criteria-wraper" style="width: 50% !important; font-weight: bold; display: none;">
                <%-- <table>
                    <tr>
                        <td style="font-weight: bold; width: 23%;">
                            Time Span:
                        </td>
                        <td style="width: 50%;">--%>
                <br />
                <span>Time Span:</span>
                <asp:Label runat="server" ID="lblReportTimeSpanFrom"></asp:Label>
                <span id="separateSpan" runat="server" style="display: none;">- </span>
                <asp:Label runat="server" ID="lblReportTimeSpanTo"></asp:Label>
                <%--</td>
                    </tr>
                </table>--%>
            </div>
            <div class="report-criteria-wraper" style="width: 50% !important; float: right;">
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPaymentsFilterDialog('UNC');" style="float: right; font-weight: bold; margin-right: 3%; margin-top: 2%;">
                    <span class="spanedit" style="margin-right: 3px;"></span>Report Criteria</a>
            </div>
        </div>
        <div class="WidgetContent">
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">
                        <div class="PageEntries">
                            <span style="float: left; margin-left: 5px; font-weight:bold;">Show&nbsp;</span><span style="float: left;">
                                <select id="ddlPagingReport" style="margin-top: 5px;" onchange="RowsChange('FilterReportList');">
                                    <option value="10">10</option>
                                    <option value="25">25</option>
                                    <option value="50">50</option>
                                    <option value="75">75</option>
                                    <option value="100">100</option>
                                </select>
                            </span><span style="float: left;">&nbsp;entries</span>
                        </div>
                        <div class="PageButtonsReports">
                            <ul style="float: right; margin-right: 15px;">
                            </ul>
                        </div>
                        <div id="divEport">
                            <div style="float: left; font-weight: bold;">Export To </div>
                            <div class="report-export-wrapper" style="float: right; width: 58%; margin-top: 3%;">
                                <asp:DropDownList ID="ddlExportTo" runat="server" OnSelectedIndexChanged="ddlExportTo_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                    <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                    <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="report-tools">
                            <table>
                                <tr>
                                    <td>
                                        <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="PrintReport('divReportListing');">
                                            <img src="../../Images/print.png" />
                                        </a>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" class="report-tool-icon" onclick="FilterReportList(0,true);">
                                            <img src="../../Images/ReportRefresh.gif" />
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="WidgetReportContent">
                    <div style="width: 100%; float: left;">
                        <div id="divReportListing" runat="server">
                            <asp:Repeater ID="rptUnpaidInsuranceClaims" runat="server" OnItemDataBound="rptUnpaidInsuranceClaims_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                     <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Insurance</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Patient</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Encounter</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Billing Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Service Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Procedures</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Diga1</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Diga2</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Charges</span><span></span>
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
                                          <td>
                                            <%# Eval("insurance")%>
                                        </td>
                                        <td>
                                            <%# Eval("Patient")%>
                                        </td>
                                        <td>
                                            <%# Eval("Encounter")%>
                                        </td>
                                        <td>
                                            <%# Eval("BillDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("ServiceDate")%>
                                        </td>
                                        <td>
                                            <%--<%# Eval("[Procedures]")%>--%>
                                            <asp:Label ID="lblProcedures" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <%# Eval("Diga1")%>
                                        </td>
                                        <td>
                                            <%# Eval("Diga1")%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                    <%--    <td>
                                            <asp:Label ID="lblAdjust" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblReceipts" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                        </td>--%>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</div>--%>

    <div id="divDialogReportFilters" style="display: none;"></div>
    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <asp:HiddenField ID="hdnPracticeId" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
    <asp:HiddenField runat="server" ID="hdnProviderId" />
    <asp:HiddenField runat="server" ID="hdnPayerId" />
    <asp:HiddenField runat="server" ID="hdnBalance" />
    <asp:HiddenField runat="server" ID="hdnDateOfService" />
    <asp:HiddenField runat="server" ID="hdnBillDateFrom" />
    <asp:HiddenField runat="server" ID="hdnBillDateTo" />

    <script type="text/javascript">
        function JumpToPageNo(event) {
            debugger;
            var a = event.which || event.keyCode;
            if (a == 13) {
                location.reload();
            }
            var pageNumber = $("[id$='txtReportPageNumber']").val();
            pageNumber--;
            FilterReportList(pageNumber);
        }
        $(document).ready(function () {
            _SortBy = 'Patient';
            _SortByValue = 'ASC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            debugger;
            var params = {
                PayerId: $("[id$='hdnPayerId']").val(),
                ProviderId: $("[id$='hdnProviderId']").val(),
                PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                Balance: $("[id$='hdnBalance']").val(),
                DateOfService: $("[id$='hdnDateOfService']").val(),
                BillDateFrom: $("[id$='hdnBillDateFrom']").val(),
                BillDateTo: $("[id$='hdnBillDateTo']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterUnpaidInsuranceClaimsReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>
