<%@ Page Title="Claims Submission Status Summary" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true"
    CodeFile="ClaimsSubmissionStatusSummary.aspx.cs" Inherits="EMR_Reports_ClaimsSubmissionStatusSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    ###StartReport###
    <div class="Widget" style="margin-top: 10px;">
<%--        <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Claim Submission Status Summary<span onclick="CloseReport('CSSS')">&times;</span></span>
        </div>--%>
        <div class="WidgetContent">
            <div class="WidgetFilterBox">
                <table>
                    <tr>
                        <td style="width: 70px;">Location:
                        </td>
                        <td style="width: 230px;">
                            <asp:DropDownList runat="server" ID="ddlPracticeLocations" AppendDataBoundItems="true" Style="width: 200px;">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <input type="button" value="Filter" onclick="Click_FilterButton();" />
                        </td>
                    </tr>
                </table>
            </div>
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
                            <asp:Repeater ID="rptReportData" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'InsuranceName');">
                                                        <span class="report-column-title">Insurance Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Location');">
                                                        <span class="report-column-title">Location</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Billed');">
                                                        <span class="report-column-title">Billed</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ReadyForSubmission');">
                                                        <span class="report-column-title">Ready for Submission</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PaidUp');">
                                                        <span class="report-column-title">Paid Up</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Denied');">
                                                        <span class="report-column-title">Denied</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PendingForSubmission');">
                                                        <span class="report-column-title">Pending for Submission</span><span></span>
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
                                            <%# Eval("InsuranceName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Location")%>
                                        </td>
                                        <td>
                                            <%# Eval("Billed")%>
                                        </td>
                                        <td>
                                            <%# Eval("ReadyForSubmission")%>
                                        </td>
                                        <td>
                                            <%# Eval("PaidUp")%>
                                        </td>
                                        <td>
                                            <%# Eval("Denied")%>
                                        </td>
                                        <td>
                                            <%# Eval("PendingForSumbmission")%>
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

    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
   </div>
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
            _SortBy = 'InsuranceName';
            _SortByValue = 'ASC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            var PracticeLocationsId = $.trim($("[id$='ddlPracticeLocations']").val());

            var params = {
                PracticeLocationsId: PracticeLocationsId,
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterClaimsSubmissionStatusSummary.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

        function Click_FilterButton() {
            FilterReportList(0, true);
        }
    </script>
    ###EndReport###
</asp:Content>
