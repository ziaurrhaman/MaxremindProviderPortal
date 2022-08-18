<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PatientDetails.aspx.cs" Inherits="ProviderPortal_Reports_PatientDetails" %>

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
            <span id="spnTitle" style="font-size: 15px;">Patient Details</span>
        </div>--%>
        
        <div class="reportsCriteriabar" style="background:#dfe3e5;height: 36px;">
              <div class="report-criteria-wraper" style="width:50% !important; float:right;">
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPatientFilterDialog('PD');" style="float: right;font-weight: bold; margin-right:3%; margin-top:2%;">
                    <span class="spanedit" style="margin-right: 3px;"></span>Report Criteria</a>
            </div>
        </div>
        <div class="WidgetContent">
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging1">
                    <div class="pagerReport">
                        <div class="PageEntries" style="display:none;">
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
                            <asp:Repeater ID="rptPatientDetailGeneralInfo" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <%--<th>
                                                        <span class="report-column-title">#</span><span class="filterIcon asc"></span>
                                                    </th>--%>
                                                    <th>
                                                        <span class="report-column-title">Patient Id</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Patient Name</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Social Security No.</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Marital Status</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Date Of Birth</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Gender</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Patient Address</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Home Phone</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Work Phone</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Email</span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <tr>
                                       <%-- <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>--%>
                                        <td>
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                            <%# Eval("SSN")%>
                                        </td>
                                        <td>
                                            <%# Eval("MaritalStatus")%>
                                        </td>
                                        <td>
                                            <%# Eval("DateOfBirth")%>
                                        </td>
                                        <td>
                                            <%# Eval("Gender")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientAddress")%>
                                        </td>
                                        <td>
                                            <%# Eval("HomePhone")%>
                                        </td>
                                        <td>
                                            <%# Eval("WorkPhone")%>
                                        </td>
                                        <td>
                                            <%# Eval("Email")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                                <FooterTemplate>
                                    </tbody>
                                    </table>
                            </div>
                                </FooterTemplate>

                            </asp:Repeater>
                             <asp:Repeater ID="rptPatientInsurance" runat="server">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr style="background:gray;">
                                                    <th colspan="12"></th>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">Patient Insurance Id</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Patient Id</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Insurance Id</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Insurance Type</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Insurance Name</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Policy Number</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Effective Date</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Group Number</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Insurance Address</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Phone No.</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Fax</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Relation Ship</span>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbodyReportList">
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <tr>
                                       <%-- <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>--%>
                                        <td>
                                            <%# Eval("PatientInsuranceId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td>
                                            <%# Eval("InsuranceId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PriSecOthType")%>
                                        </td>
                                        <td>
                                            <%# Eval("InsuranceName")%>
                                        </td>
                                        <td>
                                            <%# Eval("PolicyNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("EffectiveDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("GroupNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("InsuranceAddress")%>
                                        </td>
                                        <td>
                                            <%# Eval("phone")%>
                                        </td>
                                        <td>
                                            <%# Eval("Fax")%>
                                        </td>
                                        <td>
                                            <%# Eval("Relationship")%>
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
    <asp:HiddenField ID="hdnPatientId" runat="server" />
    <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
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
                PatientId: $("[id$='hdnPatientId']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterPatientDetails.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    ###EndReport###
</asp:Content>
