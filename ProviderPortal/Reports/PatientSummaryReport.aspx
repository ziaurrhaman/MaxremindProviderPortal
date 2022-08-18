<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PatientSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_PatientSummaryReport" %>

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
            <span id="spnTitle" style="font-size: 15px;">Patient Summary</span>
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
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPatientFilterDialog('PS');" style="float: right;font-weight: bold; margin-right:3%; margin-top:-2%;">
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
                        <div id="divReportListing" runat="server">
                            <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th class="asc" onclick="SortReportList(this,'Payer');">
                                                        <span class="report-column-title">Payer</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'TotalPatient');">
                                                        <span class="report-column-title">TotalPatient</span><span></span>
                                                    </th>
                                                </tr>
                                            </thead>
                            <asp:Repeater ID="rptPatientSummary" runat="server" OnItemDataBound="rptPatientSummary_ItemDataBound">
                                <HeaderTemplate>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("Payer")%>
                                        </td>
                                        <td>
                                            <%# Eval("TotalPatient")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                </FooterTemplate>
                            </asp:Repeater>
                                    <tfoot>
                                        <tr>
                                            <td style="border-top:1px solid #C4C4C4; font-weight:bold;">Total <asp:Label ID="lblPracticeName" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4; font-weight:bold;"><asp:Label ID="lblTotal" runat="server"></asp:Label></td>
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
    </div>
    
    <div id="divDialogReportFilters" style="display: none;"></div>
    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <asp:HiddenField ID="hdnPracticeId" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
     <asp:HiddenField runat="server" ID="hdnProvider" />
    <asp:HiddenField runat="server" ID="hdnLocation" />
    <asp:HiddenField runat="server" ID="hdnPayer" />

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
                ProviderId: $("[id$='hdnProvider']").val(),
                PayerId: $("[id$='hdnPayer']").val(),
                LocationId: $("[id$='hdnLocation']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterPatientSummaryReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>

