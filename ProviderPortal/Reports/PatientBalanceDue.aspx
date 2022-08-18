<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PatientBalanceDue.aspx.cs" Inherits="ProviderPortal_Reports_PatientBalanceDue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   ###StartReport###
    
    <div class="Widget" style="margin-top: 10px;">
        <%--<div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Patient Balance Due</span>
        </div>--%>
        <div class="WidgetContent">
            <div class="WidgetFilterBox">
                <table>
                    <tr>
                        <td style="width: 70px;">
                            Patient ID:
                        </td>
                        <td style="width: 135px;">
                            <input type="text" id="txtPatientIdFilter" style="width: 100px;" />
                        </td>
                        <td style="width: 105px;">
                            Patient Name:
                        </td>
                        <td style="width: 150px;">
                            <input type="text" id="txtPatientNameFilter" style="width: 115px;" />
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
                                            <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                <span class="report-column-title">Patient ID</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                <span class="report-column-title">Patient Name</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'TotalVisits');">
                                                <span class="report-column-title">Total Visits</span><span></span>
                                            </th> 
                                            <th class="asc" onclick="SortReportList(this,'TotalClaims');">
                                                <span class="report-column-title">Total Claims</span><span></span>
                                            </th>                                                    
                                             <th class="asc" onclick="SortReportList(this,'Charges');">
                                                <span class="report-column-title">Charges</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'InsurancePayment');">
                                                <span class="report-column-title">Insurance Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Adjustment');">
                                                <span class="report-column-title">Adjustment/Write off</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientPayment');">
                                                <span class="report-column-title">Patient Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'BalanceDue');">
                                                <span class="report-column-title">Balance Due</span><span></span>
                                            </th>
                                            <th style="display:none">
                                                <span class="report-column-title">View Detail</span><span></span>
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
                                                        <%# Eval("PatientId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("TotalVisits")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("TotalClaims")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Charges")%>
                                                    </td>
                                                     <td>
                                                        <%# Eval("InsurancePayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Adjustment")%>
                                                    </td>
                                                     <td>
                                                        <%# Eval("PatientPayment")%>
                                                    </td>
                                                    <td style="display:none">
                                                        <%# Eval("BalanceDue")%>
                                                    </td>
                                                    <td class="action">
                                                        <div>
                                                            <span title="View" class="spneye" onclick="Report_ViewBalanceDueDetail(this);"></span>
                                                        </div>

                                                        <input type="hidden" class="hdnPatientId" value='<%#Eval("PatientId") %>' />
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
    <input type="hidden" id="hdnTotalRows" runat="server" value="0"/>

    <div id="divDialogReportDetail" style="display:none;"></div>
    
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
            _SortByValue = 'DESC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            var PatientId = $.trim($("[id$='txtPatientIdFilter']").val());
            var PatientName = $.trim($("[id$='txtPatientNameFilter']").val());

            if (PatientId == "") PatientId = 0;

            var params = {
                PatientId: PatientId,
                PatientName: PatientName,
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterPatientBalanceDue.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

        function Click_FilterButton() {
            FilterReportList(0, true);
        }

        function Report_ViewBalanceDueDetail(elem) {
            _PatientId = $(elem).closest("tr").find(".hdnPatientId").val();

            Report_LoadBalanceDueDetailData();
        }

        function Report_LoadBalanceDueDetailData() {
            var params = {
                PatientId: _PatientId,
                action: "LoadDetail"
            };

            $.post(_EMRPath + "/Reports/CallBacks/PatientBalanceDueDetail.aspx", params, function (data) {
                var start = data.indexOf("###Start###") + 11;
                var end = data.indexOf("###End###");
                var returnHtml = $.trim(data.substring(start, end));

                $("#divDialogReportDetail").html(returnHtml)
                .promise()
                .done(function () {
                    $("#divDialogReportDetail").dialog({
                        title: "Balance Due Detail",
                        modal: true,
                        width: 1000,
                        height: 500,
                        close: function () {
                            $("#divDialogReportDetail").dialog("destroy");
                        }
                    });
                });
            });
        }

    </script>
    ###EndReport###
</asp:Content>


