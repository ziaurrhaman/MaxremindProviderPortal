<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="ServiceLocationsReport.aspx.cs" Inherits="ProviderPortal_Reports_ServiceLocationsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />
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
      <%--  <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Service Locations</span>
        </div>--%>
        <div class="reportsCriteriabar" style="background: #dfe3e5; height: 36px;">
            <div class="report-criteria-wraper" style="width: 50% !important; font-weight: bold;">
                <br />
                <span>Time Span:</span>
                <asp:Label runat="server" ID="lblReportTimeSpanFrom"></asp:Label>
                <span id="separateSpan" runat="server" style="display: none;">- </span>
                <asp:Label runat="server" ID="lblReportTimeSpanTo"></asp:Label>
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

                            <asp:Repeater ID="rptServiceLocations" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                     <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Name');">
                                                        <span class="report-column-title">Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'BillingName');">
                                                        <span class="report-column-title">Billing Name</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PlaceOfService');">
                                                        <span class="report-column-title">Place Of Service</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Address');">
                                                        <span class="report-column-title">Address</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'City');">
                                                        <span class="report-column-title">City</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'StateCode');">
                                                        <span class="report-column-title">State</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Zip');">
                                                        <span class="report-column-title">Zip</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Phone');">
                                                        <span class="report-column-title">Phone</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'FaxNo');">
                                                        <span class="report-column-title">Fax</span><span></span>
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
                                            <%# Eval("Name")%>
                                        </td>
                                        <td>
                                            <%# Eval("BillingName")%>
                                        </td>
                                        <td>
                                            <%# Eval("PlaceOfService")%>
                                        </td>
                                        <td>
                                            <%# Eval("Address")%>
                                        </td>
                                        <td>
                                            <%# Eval("City")%>
                                        </td>
                                        <td>
                                            <%# Eval("StateCode")%>
                                        </td>
                                        <td>
                                            <%# Eval("Zip")%>
                                        </td>
                                        <td>
                                            <%# Eval("Phone")%>
                                        </td>
                                        <td>
                                            <%# Eval("FaxNo")%>
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
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
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
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterServiceLocationsReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>

