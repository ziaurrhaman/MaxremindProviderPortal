<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="ARAgingSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_ARAgingSummaryReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 ###StartReport###
    <style type="text/css">
        .dropDownMenu{
            margin-top:-3% !important;
            height:20px;
        }
    </style>
    <div class="Widget" style="margin-top: 10px;">
        <%--<div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">A/R Aging Summary</span>
        </div>--%>
        <div class="reportsCriteriabar" style="background:#dfe3e5;height: 36px;">
            <div class="report-criteria-wraper" style="width:50% !important;font-weight: bold; display:none;">
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
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPaymentsFilterDialog('ARAS');" style="float: right;font-weight: bold; margin-right:3%; margin-top:2%;">
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
                            <asp:Repeater ID="rptARAgingSummary" runat="server" OnItemDataBound="rptARAgingSummary_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">Type</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Unbilled Charges</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Current</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">31-60</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">61-90</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">91-120</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">120+</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Total Outstainding</span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;" id="tdPayer" runat="server">
                                            <asp:Label ID="lblPayer" runat="server"></asp:Label>
                                            <asp:Label ID="lblPecentage" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUnbilled" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCurrent" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl3160" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl6190" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl91120" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl120" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalBal" runat="server"></asp:Label>
                                        </td>
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
    <asp:HiddenField runat="server" ID="hdnAgingDate" />
    <asp:HiddenField runat="server" ID="hdnAgingType" />
    <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
    <asp:HiddenField runat="server" ID="hdnProviderId" />
    <asp:HiddenField runat="server" ID="hdnPayerId" />

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
                AgingDate: $("[id$='hdnAgingDate']").val(),
                AgingType: $("[id$='hdnAgingType']").val(),
                PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                ProviderId: $("[id$='hdnProviderId']").val(),
                PayerId: $("[id$='hdnPayerId']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterARAgingSummaryReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>