<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="CheckSummary.aspx.cs" Inherits="ProviderPortal_Reports_CheckSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="Widget" style="margin-top: 10px;">
        <div class="ReportHeader">
            <span id="spnTitle" style="font-size: 15px;">Check Summary</span>
        </div>
        <div class="ReportContents">
            <div class="WidgetFilterBox" style="display:none;">

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
                        <div class="report-tools">
                            <table>
                                <tr>
                                    <td>
                                        <div class="report-export-wrapper">
                                            <asp:DropDownList ID="ddlExportTo" runat="server" CssClass="custom-export-drop-down"
                                                OnSelectedIndexChanged="ddlExportTo_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                            </asp:DropDownList>
                                            <a href="javascript:void(0)" class="custom-export-icon">
                                                <img src="../../Images/exportIconLeft.gif" style="border-style: None; height: 16px;
                                                    width: 16px;">
                                                <span style="width: 5px; text-decoration: none;"></span>
                                                <img src="../../Images/exportIconRight.gif" style="border-style: None; height: 6px;
                                                    width: 7px; margin-bottom: 5px;">
                                            </a>
                                        </div>
                                    </td>
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
                            <th style="width: 2%;"></th>
                            <th style="width: 2%;">
                                <asp:CheckBox ID="cbClaimChecksAll" runat="server" onclick="change_ClaimChecksAll(this);" />
                            </th>
                            <th style="width: 10%;">Check No.
                            </th>
                            <th style="width: 10%;">Check Date
                            </th>
                            <th style="width: 10%;">Check Amount
                            </th>
                            <th>Insurance
                            </th>
                            <th style="width: 10%;">Action
                            </th>

                        </tr>
                        <tr class="Search">
                            <th></th>
                            <th></th>
                            <th>
                                <input type="text" onkeyup="FilterClaimChecks(0,true)" validate="numeric" id="txtCheckNumber" />
                            </th>
                            <th>
                                <input type="text" onchange="FilterClaimChecks(0,true)" id="txtCheckDate" />
                            </th>
                            <th>
                                <input type="text" onkeyup="FilterClaimChecks(0,true)" validate="numeric" id="txtCheckAmount" />
                            </th>
                            <th>
                                <input onkeyup="FilterClaimChecks(0,true)" type="text" id="txtInsurance" />
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="claimChecksList">
                        <asp:Repeater ID="rptClaimCheck" runat="server">
                            <ItemTemplate>
                                <tr id="<%# Eval("ERAMasterId") %>" class="DataRow">
                                    <td>
                                        <i>
                                            <%# Eval("RowNumber") %></i>
                                    </td>
                                    <td align="center">
                                        <asp:CheckBox ID="cbClaimChecks" runat="server" CssClass="cbClaimChecks" onclick="change_ClaimCheck();" />
                                    </td>
                                    <td class="tdCheckNumber">
                                        <%# Eval("CheckNumber")%>
                                    </td>
                                    <td class="tdCheckDate">
                                        <%# Eval("CheckDate", "{0:d}")%>
                                    </td>
                                    <td class="tdCheckAmount">
                                        <%# Eval("CheckAmount", "{0:c}")%>
                                    </td>

                                    <td id="<%# Eval("InsuranceId") %>" class="tdInsurance">
                                        <%# Eval("Insurance")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <span class="fa fa-print" title="Print" onclick="PrintCheckInfo(this);"
                                            style="cursor: pointer; font-size: 16px; color: #006a99; margin-left: 7px; display: inline-block;"></span>
                                        <span class="spanview" style="display: none;" title="View" onclick="ViewCheckInfo(this);"></span>
                                        <span class="spanedit" title="Edit" onclick="EditClaimCheck(this);"></span>
                                        <span class="spandelete" title="Delete" onclick="DeleteClaimCheck(this);" style="margin-left: 5px;"></span>

                                        <input type="hidden" class="hdnClaimCheckId" value='<%# Eval("ERAMasterId")%>' />
                                        <input type="hidden" class="hdnInsuranceId" value='<%# Eval("InsuranceId")%>' />
                                        <input type="hidden" class="hdnCheckAmount" value='<%#DataBinder.Eval(Container.DataItem, "CheckAmount","{0:0.00}")%>' />
                                        <input type="hidden" class="hdnPostedAmount" value='<%#DataBinder.Eval(Container.DataItem, "PostedAmount","{0:0.00}")%>' />

                                        <input type="hidden" class="hdnPatientId" value="<%#Eval("PatientId") %>" />
                                        <input type="hidden" class="hdnPatient" value="<%#Eval("Patient") %>" />
                                        <%--<input type="hidden" class="hdnProcedurePaymentsId" value='<%# Eval("ProcedurePaymentsId")%>' />--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr id="<%# Eval("ERAMasterId") %>" class="alternatingRow DataRow">
                                    <td>
                                        <i>
                                            <%# Eval("RowNumber") %></i>
                                    </td>
                                    <td align="center">
                                        <asp:CheckBox ID="cbClaimChecks" runat="server" CssClass="cbClaimChecks" onclick="change_ClaimCheck();" />
                                    </td>
                                    <td class="tdCheckNumber">
                                        <%# Eval("CheckNumber")%>
                                    </td>
                                    <td class="tdCheckDate">
                                        <%# Eval("CheckDate", "{0:d}")%>
                                    </td>
                                    <td class="tdCheckAmount">
                                        <%# Eval("CheckAmount", "{0:c}")%>
                                    </td>
                                    
                                    <td id="<%# Eval("InsuranceId") %>" class="tdInsurance">
                                        <%# Eval("Insurance")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <span class="fa fa-print" title="Print" onclick="PrintCheckInfo(this);"
                                            style="cursor: pointer; font-size: 16px; color: #006a99; margin-left: 7px; display: inline-block; "></span>
                                        <span class="spanview" style="display: none;" title="View" onclick="ViewCheckInfo(this);"></span>
                                        <span class="spanedit" title="Edit" onclick="EditClaimCheck(this);"></span>
                                        <span class="spandelete" title="Delete" onclick="DeleteClaimCheck(this);" style="margin-left: 5px;"></span>

                                        <input type="hidden" class="hdnClaimCheckId" value='<%# Eval("ERAMasterId")%>' />
                                        <input type="hidden" class="hdnInsuranceId" value='<%# Eval("InsuranceId")%>' />
                                        <input type="hidden" class="hdnCheckAmount" value='<%#DataBinder.Eval(Container.DataItem, "CheckAmount","{0:0.00}")%>' />
                                        <input type="hidden" class="hdnPostedAmount" value='<%#DataBinder.Eval(Container.DataItem, "PostedAmount","{0:0.00}")%>' />

                                        <input type="hidden" class="hdnPatientId" value="<%#Eval("PatientId") %>" />
                                        <input type="hidden" class="hdnPatient" value="<%#Eval("Patient") %>" />

                                        <%--<input type="hidden" class="hdnProcedurePaymentsId" value='<%# Eval("ProcedurePaymentsId")%>' />--%>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
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
    <asp:HiddenField runat="server" ID="hdnTotalRowsClaimList" />
    
    <script type="text/javascript">
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

</asp:Content>

