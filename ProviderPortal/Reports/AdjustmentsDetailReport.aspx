<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="AdjustmentsDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_AdjustmentsDetailReport" %>

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
    <script type="text/javascript">
        function PrintReport1(divToPrint) {
            debugger;
            $(".clsborder").attr("border", "1");
            $(".clsborder").css("border-collapse", "collapse");
            var headstr = "<html><head><title></title></head><body>";
            var footstr = "</body></html>";
            var newstr = $("[id$='" + divToPrint + "']").html();
            var popupWin = window.open('', '_blank');
            popupWin.document.write(headstr + newstr + footstr);
            popupWin.print();
            $(".clsborder").attr("border", "0");
            return false;
        }
    </script>
    <div class="Widget" style="margin-top: 10px;">
        <%--<div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Adjustments Detail</span>
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
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPatientFilterDialog('AD');" style="float: right;font-weight: bold; margin-right:3%; margin-top:-2%;">
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
                                        <a href="javascript:void(0)" class="report-print-icon report-tool-icon" onclick="PrintReport1('divReportListing');">
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

                            <asp:Repeater ID="rptAdjustmentsDetail" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table class='clsborder'>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                    <%--<th class="asc" onclick="SortReportList(this,'claimid');">
                                                        <span class="report-column-title">Claim Id</span><span></span>
                                                    </th>--%>
                                                <%--    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                        <span class="report-column-title">Claim Charges Id</span><span></span>
                                                    </th>--%>
                                                    <th class="asc" onclick="SortReportList(this,'PostDate');">
                                                        <span class="report-column-title">Post Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'servicedate');">
                                                        <span class="report-column-title">Service Date</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'CPTCode');">
                                                        <span class="report-column-title">Procedure</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                        <span class="report-column-title">Patient Name</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Provider');">
                                                        <span class="report-column-title">Provider</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Location');">
                                                        <span class="report-column-title">Location</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Reason');">
                                                        <span class="report-column-title">Reason</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'charges');">
                                                        <span class="report-column-title">Total Charges</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Adjustments');">
                                                        <span class="report-column-title">Adjustments</span><span></span>
                                                    </th>
                                                   <%-- <th class="asc" onclick="SortReportList(this,'Adjustments');">
                                                        <span class="report-column-title">Adjusted Amount</span><span></span>
                                                    </th>--%>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                      <%--  <td>
                                            <%# Eval("claimid")%>
                                        </td>--%>
                                   
                                        <td>
                                            <%# Eval("PostDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("servicedate")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Procedure]")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                            <%# Eval("Location")%>
                                        </td>
                                        <td>
                                            <%# Eval("CodeDescriptions")%>
                                        </td>
                                        <td>
                                            <%# Eval("TotalCharges")%>
                                        </td>
                                        <td>
                                            <%# Eval("Adjustments")%>
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
     <asp:HiddenField runat="server" ID="hdnDateType" />
      <asp:HiddenField runat="server" ID="hdnPatient" />
          <asp:HiddenField runat="server" ID="hdnProviderId" />
          <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
          <asp:HiddenField runat="server" ID="hdnPayerId" />
          <asp:HiddenField runat="server" ID="hdnAdjustmentCode" />
          <asp:HiddenField runat="server" ID="hdnProcedureCode" />
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
            _SortBy = 'PostDate';
            _SortByValue = 'DESC';

            SetHtml('divReportListing', 'ReportGrid', 'hdnReportHtml');

            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            var params = {
                DateFrom: $("[id$='hdnDateFrom']").val(),
                DateTo: $("[id$='hdnDateTo']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                PatientIds: $("[id$='hdnPatient']").val(),
                ProviderId: $("[id$='hdnProviderId']").val(),
                PracticeLocationId: $("[id$='hdnPracticeLocationId']").val(),
                PayerId: $("[id$='hdnPayerId']").val(),
                AdjustmentCode: $("[id$='hdnAdjustmentCode']").val(),
                ProcedureCode: $("[id$='hdnProcedureCode']").val(),
                DateType: $("[id$='hdnDateType']").val(),
                BillDateFrom: $("[id$='hdnDateFrom']").val(),
                BillDateTo: $("[id$='hdnDateTo']").val(),
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterAdjustmentsDetailReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>
