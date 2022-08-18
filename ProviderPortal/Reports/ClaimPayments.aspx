<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="ClaimPayments.aspx.cs" Inherits="ProviderPortal_Reports_ClaimPayments" %>

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
            <span id="spnTitle" style="font-size: 15px;">Claim Payments</span>
        </div>--%>
        <div class="WidgetContent">
            <div class="WidgetFilterBox" style="display: none;">
                <table>
                    <tr>
                        <td style="width: 70px;">Location:
                        </td>
                        <td style="width: 230px;"></td>
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
                            <asp:Repeater ID="rptReportData" OnItemDataBound="rptReportData_ItemDataBound" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'DOS');">
                                                        <span class="report-column-title">DOS</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimsId');">
                                                        <span class="report-column-title">Claim ID</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                        <span class="report-column-title">Patient Name</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PrimaryInsurance');">
                                                        <span class="report-column-title">Primary Insurance</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'SecondaryInsurance');">
                                                        <span class="report-column-title">Secondary Insurance</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PrimaryPayment');">
                                                        <span class="report-column-title">Primary Payment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'SecondaryPayment');">
                                                        <span class="report-column-title">Secondary Payment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Adjustment');">
                                                        <span class="report-column-title">Adjustment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientPayment');">
                                                        <span class="report-column-title">Patient Payment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'BalanceDue');">
                                                        <span class="report-column-title">Balance Due</span><span></span>
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
                                            <%# Eval("DOS")%>
                                        </td>
                                        <td>
                                            <%# Eval("ClaimId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                            <%# Eval("PrimaryInsurance")%>
                                        </td>
                                        <td>
                                            <%# Eval("SecondaryInsurance")%>
                                        </td>
                                        <td>
                                            <%# Eval("PrimaryPayment")%>
                                        </td>
                                        <td>
                                            <%# Eval("SecondaryPayment")%>
                                        </td>
                                        <td>
                                            <%# Eval("Adjustment")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientPayment")%>
                                        </td>
                                        <td>
                                            <%# Eval("BalanceDue")%>
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

    <asp:HiddenField ID="hdnReportHtml" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />

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
            _SortBy = 'DOS';
            _SortByValue = 'ASC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            var params = {
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterClaimPayments.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

        function Click_FilterButton() {
            FilterReportList(0, true);
        }

    </script>
    ###EndReport###
</asp:Content>

