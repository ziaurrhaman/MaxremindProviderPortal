<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="DailyPayments.aspx.cs" Inherits="ProviderPortal_Reports_DailyPayments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  ###StartReport###
    <asp:HiddenField runat="server" ID="hdnPracticeLocationsIdReport" Value="0" />
    
    <div class="Widget" style="margin-top: 10px;">
       <%-- <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Daily Payments<span onclick="CloseReport('DP')">&times;</span></span>
        </div>--%>
        <div class="WidgetContent">
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">
                        <div style="float:left; width: 170px; margin-left: 10px;">
                            <span style="float:left; margin: 0 10px 0 0;">Date:</span>
                            <input type="text" id="txtPaymentDateFilter" onchange="FilterReportList(0, true);" class="date" style="float: left; width: 105px; margin: 6px 0 0 0;" />
                        </div>
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
                            <div class="ReportGrid">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>
                                                <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaymentSource');">
                                                <span class="report-column-title">Payment Source</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PayerName');">
                                                <span class="report-column-title">Payer Name</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaymentMethod');">
                                                <span class="report-column-title">Payment Method</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'CheckNumber');">
                                                <span class="report-column-title">Check/Ref #</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaymentDate');">
                                                <span class="report-column-title">Payment Date</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PaidAmount');">
                                                <span class="report-column-title">Paid Amount</span><span></span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyReportList">
                                        <asp:Repeater ID="rptReportData" runat="server" OnItemDataBound="rptReportData_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblPaymentSource"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PayerName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentMethod")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckNumber")%>
                                                    </td>   
                                                     <td>
                                                        <%# Eval("CheckIssueDate")%>
                                                    </td>   
                                                    <td>
                                                        <%# Eval("PaymentAmount")%>
                                                    </td>                                      
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0"/>
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
            /*$(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                onSelect: function (date, obj) {
                    FilterReportList(0, true);
                }
            }).mask("99/99/9999");*/

            var PracticeLocationsId = $("[id$='hdnPracticeLocationsIdReport']").val();
            if (PracticeLocationsId == 0) PracticeLocationsId = 1;
            var CurrentLocationDate = GetPracticeLocationCurrentTimeUTC(PracticeLocationsId, "Date");

            $("#txtPaymentDateFilter").val(CurrentLocationDate);

            _SortBy = 'PaymentMethod';
            _SortByValue = 'ASC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            var params = {
                PaymentDate: $.trim($("#txtPaymentDateFilter").val()),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterDailyPayments.aspx";

            Report_ReloadData(actionPage, params, paging);
        }
    </script>
    ###EndReport###
</asp:Content>

