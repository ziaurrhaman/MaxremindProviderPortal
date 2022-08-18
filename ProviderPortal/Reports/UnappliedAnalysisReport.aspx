<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="UnappliedAnalysisReport.aspx.cs" Inherits="ProviderPortal_Reports_UnappliedAnalysisReport" %>


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
        <%--<div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Unapplied Analysis</span>
        </div>--%>
        <div class="reportsCriteriabar" style="background: #dfe3e5; height: 36px;">
            <div class="report-criteria-wraper" style="width: 50% !important; font-weight: bold;">
                <br />
                <span>Time Span:</span>
                <asp:Label runat="server" ID="lblReportTimeSpanFrom"></asp:Label>
                <span id="separateSpan" runat="server" style="display: none;">- </span>
                <asp:Label runat="server" ID="lblReportTimeSpanTo"></asp:Label>
            </div>
            <div class="report-criteria-wraper" style="width: 50% !important; float: right;">
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPaymentsFilterDialog('UA');" style="float: right; font-weight: bold; margin-right: 3%; margin-top: -2%;">
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
                            
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                   <%-- <th>
                                                        <span class="report-column-title">#</span>
                                                    </th>--%>
                                                    <th>
                                                        <span class="report-column-title">Transaction</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Post Date</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Payment Id</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Type</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Payer</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Service Date</span>
                                                    </th>
                                                    <%--<th>
                                                        <span class="report-column-title">Redering Provider</span>
                                                    </th>--%>
                                                    <th>
                                                        <span class="report-column-title">Claim Id</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Patient Name</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Amount</span
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Unapplied Balance</span>
                                                    </th>
                                                </tr>
                                    <tr>
                                        <th colspan="9"><sapn style="float:right;">Begining Unapplied Balance</sapn></th>
                                         <th><sapn style="float:left;"><asp:Label ID="lblBeginingUnappliedBalance" runat="server"></asp:Label></sapn>
                                         </th>
                                       </tr>
                                            </thead>
                            <asp:Repeater ID="rptUnappliedAnalysis" runat="server" OnItemDataBound="rptUnappliedAnalysis_ItemDataBound">
                                <HeaderTemplate>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                       <%-- <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>--%>
                                        <td>
                                            <%# Eval("[Transaction]")%>
                                        </td>
                                        <td>
                                            <%# Eval("PostDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("PmtId")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Type]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Payer")%>
                                        </td>
                                        <td>
                                            <%# Eval("ServiceDate")%>
                                        </td>
                                        <td>
                                            <%--<%# Eval("ClaimId")%>--%>
                                            <asp:Label ID="lblClaimId" runat="server" Style="font-weight:bold;"></asp:Label>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("Amt")%>--%>
                                            <asp:Label ID="lblAmt" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("UnappliedBalance")%>--%>
                                            <asp:Label ID="lblUnappliedBalance" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    
                                  
                                    </tbody>
                                   
                                </FooterTemplate>
                            </asp:Repeater>
                                            <tfoot>
                                                  <tr>
                                        <td colspan="9" style="border-top:1px solid #CCC; border-right:1px solid #CCC;"><sapn style="float:right;">Change in Unaplied Ballance</sapn></td>
                                        <td style="border-top:1px solid #CCC;"><asp:Label ID="lblChangeInUnapliedBallance" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="9" style="font-weight:bold; border-top:1px solid #CCC; border-right:1px solid #CCC;"><sapn style="float:right;">Ending Unapplied Balance</sapn></td>
                                        <td style="border-top:1px solid #CCC;"><asp:Label ID="lblEndingUnappliedBalance" runat="server"></asp:Label></td>
                                    </tr>
                                            </tfoot>
                                </table>
                            </div>
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
    <asp:HiddenField runat="server" ID="hdnPayerName" />
    <asp:HiddenField runat="server" ID="hdnCheckNumber" />
    <asp:HiddenField runat="server" ID="hdnPostDate" />
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
                PayerName: $("[id$='hdnPayerName']").val(),
                CheckNumber: $("[id$='hdnCheckNumber']").val(),
                PostDate: $("[id$='hdnPostDate']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterUnappliedAnalysisReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>
