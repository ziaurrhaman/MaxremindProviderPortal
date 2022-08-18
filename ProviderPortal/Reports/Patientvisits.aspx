<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="Patientvisits.aspx.cs" Inherits="ProviderPortal_Reports_Patientvisits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />

 <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   ###StartReport###
    <div class="Widget" style="margin-top: 10px;">
        <%--<div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Patient Visits</span>
        </div>--%>
        <div class="WidgetContent">
            <div class="WidgetFilterBox">
                <table>
                    <tr>
                        <td style="width: 70px;">
                            Location:
                        </td>
                        <td style="width: 230px;">
                            <asp:DropDownList runat="server" ID="ddlPracticeLocations" AppendDataBoundItems="true" onchange="ChangePracticeLocations(this);" style="width: 200px;">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 105px;">
                            Service Provider:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlServiceProviders" AppendDataBoundItems="true" onchange="FilterReportList(0, true);" style="width: 200px;">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                            </asp:DropDownList>
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
                                            <img src="../../Images/ReportRefresh.gif" /></a>
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
                                            <th class="asc" onclick="SortReportList(this,'DOS');">
                                                <span class="report-column-title">DOS</span><span class="filterIcon asc"></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientId');">
                                                <span class="report-column-title">Patient ID</span> <span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'PatientName');">
                                                <span class="report-column-title">Patient Name</span> <span></span>
                                            </th>                                                    
                                            <th class="asc" onclick="SortReportList(this,'ClaimId');">
                                                <span class="report-column-title">Claim ID</span> <span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'TotalCharges');">
                                                <span class="report-column-title">Total Charges</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Payment');">
                                                <span class="report-column-title">Payment</span><span></span>
                                            </th>
                                            <th class="asc" onclick="SortReportList(this,'Adjustment');">
                                                <span class="report-column-title">Adjustment</span><span></span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyReportList">
                                        <asp:Repeater ID="rptReportData" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("AppointmentDate")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PATIENTID")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("ClaimId")%>
                                                    </td>
                                                     <td>
                                                        <%# Eval("ClaimTotal")%>
                                                    </td>   
                                                    <td>
                                                        <%# Eval("AmountPaid")%>
                                                    </td> 
                                                    <td>
                                                        <%# Eval("Adjustment")%>
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
    <asp:Literal runat="server" ID="ltrProvidersByLocation"></asp:Literal>
    
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
            debugger;
            GenerateReportPaging($("[id$='hdnTotalRows']").val(), $("#ddlPagingReport").val(), "divReportPaging", "FilterReportList");
        });

        function FilterReportList(pageNumber, paging) {
            var params = {
                PracticeLocationsId: $("[id$='ddlPracticeLocations']").val(),
                ServiceProviderId: $("[id$='ddlServiceProviders']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterPatientVisits.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

        function ChangePracticeLocations(elem) {
            var PracticeLocationsId = $(elem).val();

            var arrProvidersByLocation;

            if (PracticeLocationsId == 0) {
                arrProvidersByLocation = _arrPracticeStaffByLocation;
            }
            else {
                arrProvidersByLocation = $.grep(_arrPracticeStaffByLocation, function (v, i) {
                    return (v.PracticeLocationsId == PracticeLocationsId);
                });
            }

            var ProvidersHtml = "";

            if (arrProvidersByLocation.length == 0) {
                ProvidersHtml += '<option value="0"></option>';
            }
            else {
                ProvidersHtml += '<option value="0">All</option>';
            }

            for (var i = 0; i < arrProvidersByLocation.length; i++) {
                ProvidersHtml += '<option value="' + arrProvidersByLocation[i].ServiceProviderId + '">' + arrProvidersByLocation[i].Name + '</option>';
            }

            $("[id$='ddlServiceProviders']").html(ProvidersHtml)
            .promise()
            .done(function () {
                FilterReportList(0, true);
            });
        }
    </script>
    ###EndReport###
</asp:Content>

