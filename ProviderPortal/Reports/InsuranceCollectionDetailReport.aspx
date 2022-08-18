<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="InsuranceCollectionDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_InsuranceCollectionDetailReport" %>

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
       <%-- <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Insurance Collection Detail</span>
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
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPaymentsFilterDialog('ICD');" style="float: right; font-weight: bold; margin-right: 3%; margin-top: 2%;">
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
                            <asp:Repeater ID="rptInsuranceCollectionDetail" runat="server" OnItemDataBound="rptInsuranceCollectionDetail_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Claim Id</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Post Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Service Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Procedure</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Patient</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Billed To</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Adjusted charges</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Payments</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">A/R Balance</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'ClaimStatus');">
                                                        <span class="report-column-title">Age</span><span></span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="trClaimStatus" runat="server" style="display:none;">
                                        <th id="thClaimStatus" runat="server" colspan="11">
                                            <asp:Label ID="lblClaimStatus" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr id="trPeriod" runat="server" style="display:none;">
                                        <th id="thPeriod" runat="server" colspan="11">
                                            <asp:Label ID="lblPeriod" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("ClaimId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PostDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("ServiceDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Procedure]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Patient")%>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("BilledTo")%>--%>
                                            <asp:Label ID="lblBilledTo" runat="server"></asp:Label>
                                            <asp:Label ID="lblTotalBilledTo" runat="server"></asp:Label>
                                            <asp:Label ID="lblSubBilledTo" runat="server"></asp:Label>
                                            <asp:Label ID="lblGrandBilledTo" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAdcharges" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPayment" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblARBalance" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <%# Eval("Age")%>
                                        </td>
                                    </tr>
                                    
                                    <tr id="trLastClaimStatus" runat="server" style="display:none;">
                                        <th id="thLastClaimStatus" runat="server" colspan="11">
                                            <asp:Label ID="lblLastClaimStatus" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr id="trLastPeriod" runat="server" style="display:none;">
                                        <th id="thLastPeriod" runat="server" colspan="11">
                                            <asp:Label ID="lblLastPeriod" runat="server"></asp:Label>
                                        </th>
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
    <asp:HiddenField runat="server" ID="hdnClaimStatus" />

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
            _SortBy = 'ClaimStatus';
            _SortByValue = 'ASC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            debugger;
            var params = {
                AgingDate: $("[id$='hdnAgingDate']").val(),
                AgingType: $("[id$='hdnAgingType']").val(),
                PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                ProviderId: $("[id$='hdnProviderId']").val(),
                PayerId: $("[id$='hdnPayerId']").val(),
                ClaimStatus: $("[id$='hdnClaimStatus']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterInsuranceCollectionDetailReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>

