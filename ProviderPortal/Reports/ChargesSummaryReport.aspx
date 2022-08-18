﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="ChargesSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_ChargesSummaryReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  ###StartReport###
     <style type="text/css">
         .filterIcon {
            background-image: url('../../Images/filter-Icon.png');
            background-repeat: no-repeat;
            height: 6px;
            width: 11px;
            cursor: pointer;
            float: left;
            margin-left: 2px;
        }

        .asc {
            background-position: 0 0;
            margin-top: 7px;
        }

        .desc {
            background-position: 0 -5px;
            margin-top: 7px;
        }
    </style>
    <div class="Widget" style="margin-top: 10px;">
       <%-- <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Charges Summary</span>
        </div>--%>
        <div class="reportsCriteriabar" style="background:#dfe3e5;height: 36px;">
            <div class="report-criteria-wraper" style="width:50% !important;font-weight: bold;">
                <br />
                            <span>Time Span:</span>
                            <asp:Label runat="server" ID="lblReportTimeSpanFrom"></asp:Label>
                            <span id="separateSpan" runat="server" style="display:none;"> - </span>
                            <asp:Label runat="server" ID="lblReportTimeSpanTo"></asp:Label>
            </div>
              <div class="report-criteria-wraper" style="width:50% !important; float:right;">
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPatientFilterDialog('CS');" style="float: right;font-weight: bold; margin-right:3%; margin-top:-2%;">
                    <span class="spanedit" style="margin-right: 3px;"></span>Report Criteria</a>
            </div>
        </div>
        <div class="WidgetContent">
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">
                        <div class="PageEntries">
                            <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
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
                        <div id="divReportListing">

                            <asp:Repeater ID="rptChargesSummary" runat="server" OnItemDataBound="rptChargesSummary_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Procedures</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Procedure Amount</span>
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
                                            <%# Eval("Code")%>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("Total")%>--%>
                                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="2" style="border-top:1px solid #C4C4C4; font-weight:bold; text-align:center;"><asp:Label ID="lblTotalLabel" runat="server"></asp:Label> <asp:Label ID="lblPracticeName" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4; font-weight:bold;"><asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                                        </tr>
                                    </tfoot>
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

    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
       <asp:HiddenField runat="server" ID="hdnPatId" />
    <div id="divDialogReportFilters" style="display: none;"></div>

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
                PatientId: $("[id$='hdnPatId']").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterChargesSummaryReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>

