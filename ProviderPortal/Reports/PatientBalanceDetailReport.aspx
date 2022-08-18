<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PatientBalanceDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_PatientBalanceDetailReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 ###StartReport###
   <div class="Widget" style="margin-top: 10px;">
       <%-- <div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Patient Balance Details</span>
        </div>--%>
        
        <div class="reportsCriteriabar" style="background:#dfe3e5;height: 36px;">
              <div class="report-criteria-wraper" style="width:50% !important; float:right;">
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPatientFilterDialog('PBD');" style="float: right;font-weight: bold; margin-right:3%; margin-top:2%;">
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
                            <asp:Repeater ID="rptPatientBalanceDetail" runat="server" OnItemDataBound="rptPatientBalanceDetail_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="ReportGrid">
                                        <table>
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <span class="report-column-title">#</span><span></span>
                                                    </th>
                                                   <%-- <th>
                                                        <span class="report-column-title">Patient Id</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Patient Name</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Patient Address</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Claim Id</span>
                                                    </th>
                                                    <th>
                                                        <span class="report-column-title">Claim Charges Id</span>
                                                    </th>--%>
                                                    <th class="asc" onclick="SortReportList(this,'servicedate');">
                                                        <span class="report-column-title">Service Date</span><span class="filterIcon asc"></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'code');">
                                                        <span class="report-column-title">Code</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'code');">
                                                        <span class="report-column-title">Procedure</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'charges');">
                                                        <span class="report-column-title">Charges</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'adjustments');">
                                                        <span class="report-column-title">Adjustments</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Insurancepmt');">
                                                        <span class="report-column-title">Insurance Payment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PatientPmt');">
                                                        <span class="report-column-title">Patient Payment</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'TotalBalance');">
                                                        <span class="report-column-title">Total Balance</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'PendingIns');">
                                                        <span class="report-column-title">Pending Insurance</span><span></span>
                                                    </th>
                                                    <th class="asc" onclick="SortReportList(this,'Patientbalance');">
                                                        <span class="report-column-title">Patient Balance</span><span></span>
                                                    </th>
                                                   <%-- <th>
                                                        <span class="report-column-title">Procedure Payments Id</span>
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
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientAddress")%>
                                        </td>
                                        <td>
                                            <%# Eval("claimid")%>
                                        </td>
                                        <td>
                                            <%# Eval("ClaimChargesId")%>
                                        </td>--%>
                                        <td>
                                            <%# Eval("servicedate")%>
                                        </td>
                                        <td>
                                            <%# Eval("code")%>
                                        </td>
                                        <td>
                                            <%# Eval("[procedure]")%>
                                        </td>
                                        <td>
                                            <%--<%# Eval("charges")%>--%>
                                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("adjustments")%>--%>
                                            <asp:Label ID="lbladjustments" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("Insurancepmt")%>--%>
                                            <asp:Label ID="lblInsurancepmt" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <%--<%# Eval("PatientPmt")%>--%>
                                            <asp:Label ID="lblPatientPmt" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                           <%-- <%# Eval("TotalBalance")%>--%>
                                            <asp:Label ID="lblTotalBalance" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <%--<%# Eval("PendingIns")%>--%>
                                            <asp:Label ID="lblPendingIns" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <%--<%# Eval("Patientbalance")%>--%>
                                            <asp:Label ID="lblPatientbalance" runat="server"></asp:Label>
                                        </td>
                                      <%--  <td>
                                            <%# Eval("ProcedurePaymentsid")%>
                                        </td>--%>
                                    </tr>
                                </ItemTemplate>

                                    <FooterTemplate>
                                    </tbody>
                                    <tfooter>
                                        <tr>
                                            <td style="border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-top:1px solid #C4C4C4;font-weight:bold; float:right; width:98%;">Grand Total <%--<asp:Label ID="lblPracticeName" runat="server"></asp:Label>--%></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalCharges" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalAdjustments" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalInsurancePayments" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalPatientPayments" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblGrandTotalBalance" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblPendingIns" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblPatientbalance" runat="server"></asp:Label></td>
                                        </tr>
                                    </tfooter>
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
    <asp:HiddenField ID="hdnProcedureCode" runat="server" />
    <asp:HiddenField ID="hdnDOB" runat="server" />
    <asp:HiddenField ID="hdnCustomDate" runat="server" />

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
                ProcedureCode: $("[id$='hdnProcedureCode']").val(),
                DOB: $("[id$='hdnDOB']").val(),
                CustomDate: $("[id$='hdnCustomDate']").val(),
                Rows: $("#ddlPagingReport").val(),
                PageNumber: pageNumber,
                SortBy: _SortBy + " " + _SortByValue,
                action: "Filter"
            };

            var actionPage = "FilterPatientBalanceDetailsReport.aspx";

            Report_ReloadData(actionPage, params, paging);
        }

    </script>
    
    ###EndReport###

</asp:Content>

