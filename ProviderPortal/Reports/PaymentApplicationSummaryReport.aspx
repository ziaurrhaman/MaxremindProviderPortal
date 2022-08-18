<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PaymentApplicationSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_PaymentApplicationSummaryReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    ###StartReport###
    <div class="Widget" style="margin-top: 10px;">
       <%-- <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Payment Application Summary</span>
        </div>--%>
        <div class="reportsCriteriabar" style="background:#dfe3e5;height: 36px;">
            <div class="report-criteria-wraper" style="width:50% !important;font-weight: bold;">
                 <%-- <table>
                    <tr>
                        <td style="font-weight: bold; width: 23%;">
                            Time Span:
                        </td>
                        <td style="width: 50%;">--%>
                <br />
                            <span>Time Span:</span>
                            <asp:Label runat="server" ID="lblReportTimeSpanFrom"></asp:Label>
                            <span id="separateSpan" runat="server" style="display:none;"> - </span>
                            <asp:Label runat="server" ID="lblReportTimeSpanTo"></asp:Label>
                            <%--</td>
                    </tr>
                </table>--%>
            </div>
              <div class="report-criteria-wraper" style="width:50% !important; float:right;">
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPaymentsFilterDialog('PAS');" style="float: right;font-weight: bold; margin-right:3%; margin-top:-2%;">
                    <span class="spanedit" style="margin-right: 3px;"></span>Report Criteria</a>
            </div>
        </div>
        <div class="WidgetContent">
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">
                        <div class="PageEntries" style="display:none;">
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
                            
                            <asp:Repeater ID="rptPaymentApplicationSummary" runat="server" OnItemDataBound="rptPaymentApplicationSummary_ItemDataBound">
                               
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th colspan="3" style="background:#d1cec2; font-weight:bold;">Payment Method</th>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">Rendering Provider</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Payment Method</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Total</span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("RenderingProvider")%>
                                        </td>
                                        <td>
                                            <%--<%# Eval("PaymentMethod")%>--%>
                                            <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label>
                                            <asp:Label ID="lblSubTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                                            <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                                        </td>
                                        <td>
                                            <%--$<%# Eval("Total")%>--%>
                                            <asp:Label ID="lblTotalSummary" runat="server" Style="font-weight:bold;"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:Repeater ID="rptPaymentApplicationSummary1" runat="server" OnItemDataBound="rptPaymentApplicationSummary1_ItemDataBound">
                               
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th colspan="2" style="background:#d1cec2; font-weight:bold;border-top:1px solid #CCC"">Unapplied Analysis</th>
                                                </tr>
                                                <tr>
                                                    <th style="border-top:1px solid #CCC">
                                                        <span class="report-column-title">Unapplied Analysis</span>
                                                    </th>
                                                    <%--<th>
                                                        <span class="report-column-title">Payment Method</span>
                                                    </th>--%>
                                                    <th style="border-top:1px solid #CCC">
                                                        <span class="report-column-title">Total</span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="font-weight:bold;">
                                            <%# Eval("UnAppliedAnalysis")%>,
                                        </td>
                                     <%--   <td>
                                            <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label>
                                            <asp:Label ID="lblSubTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                                            <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                                        </td>--%>
                                        <td>
                                            <%--$<%# Eval("Total")%>--%>
                                            <asp:Label ID="lblTotalUnappliedAnalysis" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                </table>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:Repeater ID="rptPaymentApplicationSummary2" runat="server" OnItemDataBound="rptPaymentApplicationSummary2_ItemDataBound">
                               
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th colspan="2" style="background:#d1cec2; font-weight:bold;border-top:1px solid #CCC"">All Rendering Providers</th>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">Payment Method</span>
                                                    </th>
                                                    <th style="border-top:1px solid #CCC">
                                                        <span class="report-column-title">Total</span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPaymentMethod3" runat="server"></asp:Label>
                                            <%--<asp:Label ID="lblSubTotal" runat="server" Style="font-weight:bold;"></asp:Label>--%>
                                            <asp:Label ID="lblGrandTotal3" runat="server" Style="font-weight:bold;"></asp:Label>
                                        </td>
                                        <td>
                                           <%-- $<%# Eval("Total")%></td>--%>
                                            <asp:Label ID="lblTotalAllRenderingProviders" runat="server" Style="font-weight:bold;"></asp:Label>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
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
    </div>
    
    <div id="divDialogReportFilters" style="display: none;"></div>
    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <asp:HiddenField ID="hdnPracticeId" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />

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
            _SortBy = 'PatientId';
            _SortByValue = 'ASC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            var params = {
                DateFrom: $("[id$='hdnDateFrom']").val(),
                DateTo: $("[id$='hdnDateTo']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterPaymentApplicationSummaryReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>
