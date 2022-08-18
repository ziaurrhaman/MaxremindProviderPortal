<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="AppointmentsDetailReport.aspx.cs" Inherits="ProviderPortal_PendingTransitions_AppointmentsDetailReport" %>
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
            <span id="spnTitle" style="font-size: 15px;">Appointments Detail</span>
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
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPaymentsFilterDialog('AppD');" style="float: right;font-weight: bold; margin-right:3%; margin-top:-2%;">
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
                               <asp:Repeater ID="rptAppointmentDetail" runat="server">
                                   <HeaderTemplate>
                            <div class="ReportGrid">
                               
                                <table>
                                   <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                
                                                    <th class="asc" onclick="SortReportList(this,'Start/End');">
                                                        <span class="report-column-title">Start/End</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'AppointmentDate');">
                                                        <span class="report-column-title">Appointment Date</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Provider');">
                                                        <span class="report-column-title">Provider</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patient');">
                                                        <span class="report-column-title">Patient </span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'DateOfBirth');">
                                                        <span class="report-column-title">DateOfBirth</span><span class="filterIcon asc"></span>
                                                    </th>
                                                     <th class="asc" onclick="SortReportList(this,'Phone');">
                                                        <span class="report-column-title">Phone</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'HomePhone');">
                                                        <span class="report-column-title">HomePhone</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'location');">
                                                        <span class="report-column-title">location</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Description');">
                                                        <span class="report-column-title">Description</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Status');">
                                                        <span class="report-column-title">Status</span><span></span>
                                                    </th>

                                                     <th class="asc" onclick="SortReportList(this,'Status');">
                                                        <span class="report-column-title">Copay</span><span></span>
                                                    </th>

                                                      <th class="asc" onclick="SortReportList(this,'Status');">
                                                        <span class="report-column-title">P.Bal</span><span></span>
                                                    </th>

                                                    <th class="asc" onclick="SortReportList(this,'Notes');">
                                                        <span class="report-column-title">Notes</span><span></span>
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
                                            <%# Eval("StartandEndTime")%>
                                        </td>
                                        <td>
                                            <%# Eval("AppointmentDate","{0:d}")%>
                                        </td>
                                        <td>
                                            <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                            <%# Eval("Patient")%>
                                        </td>
                                        <td>
                                            <%# Eval("DateOfBirth","{0:d}")%>
                                        </td>
                                        <td>
                                            <%# Eval("Phone")%>
                                        </td>
                                        <td>
                                            <%# Eval("HomePhone")%>
                                        </td>
                                         <td>
                                            <%# Eval("Name")%>
                                        </td>
                                         <td>
                                            <%# Eval("[Description]")%>
                                        </td>
                                       
                                        <td>
                                            <%# Eval("StatusName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Copay")%>
                                        </td>
                                        <td>
                                              <%# Eval("[Patient-Bal]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Notes")%>
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
          <asp:HiddenField runat="server" ID="hdnStatus" />
          <asp:HiddenField runat="server" ID="hdnReasons" />
         

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
                Status: $("[id$='hdnStatus']").val(),
                Reasons: $("[id$='hdnReasons']").val(),
             
          
                BillDateFrom: $("[id$='hdnDateFrom']").val(),
                BillDateTo: $("[id$='hdnDateTo']").val(),
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterAppointmentsDetailReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>

