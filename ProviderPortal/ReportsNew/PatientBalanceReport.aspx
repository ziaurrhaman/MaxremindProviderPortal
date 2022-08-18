<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="PatientBalanceReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_PatientBalanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="style/MainReportStyle.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="ContentMaindiv">



        <div>

            <div class="div_leftReportList">
                <span id="ReportsTag">REPORTS</span>
                <table>
                    <thead>
                    </thead>
                    <tbody id="reportdropdown">


                        <tr>
                            <td id="ContentPlaceHolder1_rptReportMenu_Categorytd_0" style="border-bottom: 1px solid #439abf; padding: 5px 0px 5px 0px; box-sizing: border-box; width: 90%; float: left; margin-left: 13px;">
                                <span id="ContentPlaceHolder1_rptReportMenu_lblCategory_0" class="ReportsCategoryHeader" onclick="hideShowDiv(this)">Financial</span>
                                <span style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class="fas fa-angle-down"></i></span>

                            </td>



                        </tr>

                        <tr id="ContentPlaceHolder1_rptReportMenu_trsubRow_0" class="Financial" style="width: 100%;">
                            <td class="nametd">

                                <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">&gt;</span>
                                <span id="ContentPlaceHolder1_rptReportMenu_lblname_0" class="lblReportName" onclick="loadReport(this)" style="cursor: pointer; border: none !important">AR Aging Summary</span>
                                <span><span id="ContentPlaceHolder1_rptReportMenu_lblbeta_0" class="lblReportName" style="color: red !important; margin-top: 2px; cursor: none !important">(Beta)</span></span>
                                <div style="display: none">
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportfileName_0" class="lblReportfileName">ARAgingSummaryReport.aspx</span>
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportFilterName_0" class="lblReportFilterName"></span>
                                </div>
                                <span id="ContentPlaceHolder1_rptReportMenu_hdnReportType_0" class="ReportType" style="display: none">True</span>

                            </td>
                        </tr>




                        <tr>
                            <td id="ContentPlaceHolder1_rptReportMenu_Categorytd_1" style="display: none">
                                <span id="ContentPlaceHolder1_rptReportMenu_lblCategory_1" class="ReportsCategoryHeader" onclick="hideShowDiv(this)"></span>
                                <span style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class="fas fa-angle-down"></i></span>

                            </td>



                        </tr>

                        <tr id="ContentPlaceHolder1_rptReportMenu_trsubRow_1" class="Financial" style="width: 100%;">
                            <td class="nametd">

                                <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">&gt;</span>
                                <span id="ContentPlaceHolder1_rptReportMenu_lblname_1" class="lblReportName" onclick="loadReport(this)" style="cursor: pointer; border: none !important">Claim Summary And Detail</span>
                                <span><span id="ContentPlaceHolder1_rptReportMenu_lblbeta_1" class="lblReportName" style="color: red !important; margin-top: 2px; cursor: none !important"></span></span>
                                <div style="display: none">
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportfileName_1" class="lblReportfileName">ClaimSummaryAndDetail.aspx</span>
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportFilterName_1" class="lblReportFilterName">FilterClaimsDetail.aspx</span>
                                </div>
                                <span id="ContentPlaceHolder1_rptReportMenu_hdnReportType_1" class="ReportType" style="display: none">True</span>

                            </td>
                        </tr>




                        <tr>
                            <td id="ContentPlaceHolder1_rptReportMenu_Categorytd_2" style="display: none">
                                <span id="ContentPlaceHolder1_rptReportMenu_lblCategory_2" class="ReportsCategoryHeader" onclick="hideShowDiv(this)"></span>
                                <span style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class="fas fa-angle-down"></i></span>

                            </td>



                        </tr>

                        <tr id="ContentPlaceHolder1_rptReportMenu_trsubRow_2" class="Financial" style="width: 100%;">
                            <td class="nametd">

                                <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">&gt;</span>
                                <span id="ContentPlaceHolder1_rptReportMenu_lblname_2" class="lblReportName" onclick="loadReport(this)" style="cursor: pointer; border: none !important">Payer Analysis</span>
                                <span><span id="ContentPlaceHolder1_rptReportMenu_lblbeta_2" class="lblReportName" style="color: red !important; margin-top: 2px; cursor: none !important"></span></span>
                                <div style="display: none">
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportfileName_2" class="lblReportfileName">PayerAnalysis.aspx</span>
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportFilterName_2" class="lblReportFilterName">FilterPayerAnalysis.aspx</span>
                                </div>
                                <span id="ContentPlaceHolder1_rptReportMenu_hdnReportType_2" class="ReportType" style="display: none">True</span>

                            </td>
                        </tr>




                        <tr>
                            <td id="ContentPlaceHolder1_rptReportMenu_Categorytd_3" style="display: none">
                                <span id="ContentPlaceHolder1_rptReportMenu_lblCategory_3" class="ReportsCategoryHeader" onclick="hideShowDiv(this)"></span>
                                <span style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class="fas fa-angle-down"></i></span>

                            </td>



                        </tr>

                        <tr id="ContentPlaceHolder1_rptReportMenu_trsubRow_3" class="Financial" style="width: 100%;">
                            <td class="nametd">

                                <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">&gt;</span>
                                <span id="ContentPlaceHolder1_rptReportMenu_lblname_3" class="lblReportName" onclick="loadReport(this)" style="cursor: pointer; border: none !important">Payments Summary And Detail</span>
                                <span><span id="ContentPlaceHolder1_rptReportMenu_lblbeta_3" class="lblReportName" style="color: red !important; margin-top: 2px; cursor: none !important"></span></span>
                                <div style="display: none">
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportfileName_3" class="lblReportfileName">PaymentsSummaryAndDetail.aspx</span>
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportFilterName_3" class="lblReportFilterName">FilterPaymentsSummaryAndDetail.aspx</span>
                                </div>
                                <span id="ContentPlaceHolder1_rptReportMenu_hdnReportType_3" class="ReportType" style="display: none">True</span>

                            </td>
                        </tr>




                        <tr>
                            <td id="ContentPlaceHolder1_rptReportMenu_Categorytd_4" style="display: none">
                                <span id="ContentPlaceHolder1_rptReportMenu_lblCategory_4" class="ReportsCategoryHeader" onclick="hideShowDiv(this)"></span>
                                <span style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class="fas fa-angle-down"></i></span>

                            </td>



                        </tr>

                        <tr id="ContentPlaceHolder1_rptReportMenu_trsubRow_4" class="Financial" style="width: 100%;">
                            <td class="nametd">

                                <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">&gt;</span>
                                <span id="ContentPlaceHolder1_rptReportMenu_lblname_4" class="lblReportName" onclick="loadReport(this)" style="cursor: pointer; border: none !important">Post Claims Summary</span>
                                <span><span id="ContentPlaceHolder1_rptReportMenu_lblbeta_4" class="lblReportName" style="color: red !important; margin-top: 2px; cursor: none !important"></span></span>
                                <div style="display: none">
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportfileName_4" class="lblReportfileName">ReportPostClaimSummary.aspx</span>
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportFilterName_4" class="lblReportFilterName">FilterReportPostClaims.aspx</span>
                                </div>
                                <span id="ContentPlaceHolder1_rptReportMenu_hdnReportType_4" class="ReportType" style="display: none">True</span>

                            </td>
                        </tr>




                        <tr>
                            <td id="ContentPlaceHolder1_rptReportMenu_Categorytd_5" style="display: none">
                                <span id="ContentPlaceHolder1_rptReportMenu_lblCategory_5" class="ReportsCategoryHeader" onclick="hideShowDiv(this)"></span>
                                <span style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class="fas fa-angle-down"></i></span>

                            </td>



                        </tr>

                        <tr id="ContentPlaceHolder1_rptReportMenu_trsubRow_5" class="Financial" style="width: 100%;">
                            <td class="nametd">

                                <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">&gt;</span>
                                <span id="ContentPlaceHolder1_rptReportMenu_lblname_5" class="lblReportName" onclick="loadReport(this)" style="cursor: pointer; border: none !important">Procedure Payments Summary and Detail </span>
                                <span><span id="ContentPlaceHolder1_rptReportMenu_lblbeta_5" class="lblReportName" style="color: red !important; margin-top: 2px; cursor: none !important"></span></span>
                                <div style="display: none">
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportfileName_5" class="lblReportfileName">ProcedurePaymentsSummaryAndDetail.aspx</span>
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportFilterName_5" class="lblReportFilterName">FilterProcedurePaymentsSummaryAndDetail.aspx</span>
                                </div>
                                <span id="ContentPlaceHolder1_rptReportMenu_hdnReportType_5" class="ReportType" style="display: none">True</span>

                            </td>
                        </tr>




                        <tr>
                            <td id="ContentPlaceHolder1_rptReportMenu_Categorytd_6" style="display: none">
                                <span id="ContentPlaceHolder1_rptReportMenu_lblCategory_6" class="ReportsCategoryHeader" onclick="hideShowDiv(this)"></span>
                                <span style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class="fas fa-angle-down"></i></span>

                            </td>



                        </tr>

                        <tr id="ContentPlaceHolder1_rptReportMenu_trsubRow_6" class="Financial" style="width: 100%;">
                            <td class="nametd">

                                <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">&gt;</span>
                                <span id="ContentPlaceHolder1_rptReportMenu_lblname_6" class="lblReportName" onclick="loadReport(this)" style="cursor: pointer; border: none !important">Rejected Denied Summary And Detail</span>
                                <span><span id="ContentPlaceHolder1_rptReportMenu_lblbeta_6" class="lblReportName" style="color: red !important; margin-top: 2px; cursor: none !important"></span></span>
                                <div style="display: none">
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportfileName_6" class="lblReportfileName">RejectedDeniedSummaryAndDetail.aspx</span>
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportFilterName_6" class="lblReportFilterName">FilterRejectedDeniedSummaryAndDetail.aspx</span>
                                </div>
                                <span id="ContentPlaceHolder1_rptReportMenu_hdnReportType_6" class="ReportType" style="display: none">True</span>

                            </td>
                        </tr>




                        <tr>
                            <td id="ContentPlaceHolder1_rptReportMenu_Categorytd_7" style="display: none">
                                <span id="ContentPlaceHolder1_rptReportMenu_lblCategory_7" class="ReportsCategoryHeader" onclick="hideShowDiv(this)"></span>
                                <span style="cursor: pointer; color: #000; padding: 3px 0 0 22px; float: right" onclick="hideShowDiv(this)"><i class="fas fa-angle-down"></i></span>

                            </td>



                        </tr>

                        <tr id="ContentPlaceHolder1_rptReportMenu_trsubRow_7" class="Financial" style="width: 100%;">
                            <td class="nametd">

                                <span style="padding-right: 5px; float: left; color: #439abf; font-size: 10px;">&gt;</span>
                                <span id="ContentPlaceHolder1_rptReportMenu_lblname_7" class="lblReportName" onclick="loadReport(this)" style="cursor: pointer; border: none !important">Unposted Payments Detail and Summary</span>
                                <span><span id="ContentPlaceHolder1_rptReportMenu_lblbeta_7" class="lblReportName" style="color: red !important; margin-top: 2px; cursor: none !important"></span></span>
                                <div style="display: none">
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportfileName_7" class="lblReportfileName">UnpostedPaymentsDetailandSummary.aspx</span>
                                    <span id="ContentPlaceHolder1_rptReportMenu_lblReportFilterName_7" class="lblReportFilterName">FilterUnpostedPaymentsDetailandSummary.aspx</span>
                                </div>
                                <span id="ContentPlaceHolder1_rptReportMenu_hdnReportType_7" class="ReportType" style="display: none">True</span>

                            </td>
                        </tr>



                    </tbody>
                </table>
            </div>

            <div class="ReportTiles">

                <div class="widgetsReportTiles" style="padding-right: 14px !important;" tabname="ARAgingSummaryReport.aspx" tabparameters="id_Sub_Report_Body1" hiddenrows="NoRows" hiddenpaging="10" catagoryname="Financial" isparameters="True" id="widgetsReportTilesARAgingSummaryReport.aspx"><span class="reportType" style="color: white" onclick="OpenReportTab('NoRows','10', 'id_Sub_Report_Body1',this)">AR Aging Summary</span><span class="reportcloseicon" onclick="HideReportTile(this)" focus="FocusOnCloseIcon(this)">x</span></div>
            </div>
            <div class="div_RightReportShow">

                <div id="Maindiv">
                    <div class="Report_Header">


                        <div class="report-export" style="display: block;">
                            <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                            <span style="float: left; padding-top: 2px; margin-left: 7px">
                                <select id="ddlExportTo" class="custom-export-drop-down" onchange="ExportReport();">
                                    <option></option>
                                    <option value="Excel">Excel</option>
                                    <option value="PDF">PDF</option>
                                    <option value="Word">Word</option>
                                </select>
                            </span>
                        </div>
                        <div class="inlineFilter">
                            <div class="control-group">
                                <label class="control-label">Date Type</label>
                                <div class="controls">
                                    <input type="text" id="" placeholder="Date Type" />
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Insurance</label>
                                <div class="controls">
                                    <select>
                                        <option>Select Insurance</option>
                                    </select>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">Location</label>
                                <div class="controls">
                                    <select>
                                        <option>Select Location</option>
                                    </select>
                                </div>
                            </div>
                            <div class="control-group">

                                <div class="controls">
                                    <input type="button" value="Filter" />
                                </div>
                            </div>
                        </div>

                    </div>



                    <div class="Report_Body">
                        <div class="Sub_Report_Body1 common_Report" id="id_Sub_Report_Body1" style="display: block;">



                            <div class="divInsuranceDetail" style="">
                                <script src="/Scripts/tableHeadFixer.js"></script>
                                <script>
                                    $(document).ready(function () {

                                        $(".fixTable").tableHeadFixer();
                                    });
                                </script>
                                <style>
                                    .HyperlinkClass {
                                        text-decoration: underline;
                                        color: blue;
                                        cursor: pointer;
                                    }
                                </style>



                                <div class="GridReports" id="printableArea" style="overflow: auto;">

                                    <table class="fixTable">
                                        <thead>
                                            <tr>
                                                <th style="text-align: center !important; background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Patient Account</span>
                                                </th>

                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Patient Last Name</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Patient First Name</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Last DOS</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Balance</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Reason</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claims Count</span>
                                                </th>
                                                
                                                

                                            </tr>
                                        </thead>
                                        <tbody id="tbodyReportList">


                                            <tr class="cpa-trfont">
                                                <td style="text-align: center;">22655</td>
                                                <td style="text-align: center;">HOWARD</td>
                                                <td style="text-align: center;">Lotte</td>
                                                <td style="text-align: center;">02/25/2020</td>
                                                <td style="text-align: right;">$123.97</td>
                                                <td style="text-align: center;">Coinsurance</td>
                                                <td style="text-align: center;">12</td>
                                            </tr>




                                        </tbody>
                                    </table>
                                </div>






                                <div class="GridReports PatientBalReport" id="printableArea" style="overflow: auto; display:none;">

                                    <table class="fixTable">
                                        <thead>
                                            <tr>
                                                <th style="text-align: center !important; background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Patient Acct</span>
                                                </th>

                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Last Name	</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">First Name</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">DOb</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Phone Number</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Address</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claim Pri Insurance</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claim Pri Insurance ID</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claim Pri Insurance ID</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claim Sec Insurance ID</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claim ID	</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">DOS</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Location</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claim Physician	</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Billed As	</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claim Status	</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">claim Charges	</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Total Allowed	</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Insurance Paid</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Patient Paid</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Total Paid</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">WriteOffAdjustment</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Total Adjustments	</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Balance Due</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Claim Post Date</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">First Submission Date</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Last Submission Date</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Pri Status</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Sec Status</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Pat Status</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Remarks</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">Current</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">31-60</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">61-90</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title">91-120</span>
                                                </th>
                                                <th style="background-color: rgb(79, 175, 216); position: relative; top: 0px;">
                                                    <span class="report-column-title"><120</span>
                                                </th>

                                            </tr>
                                        </thead>
                                        <tbody id="tbodyReportList">


                                            <tr class="cpa-trfont">
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                 <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                                <td style="text-align: center;">12</td>
                                            </tr>




                                        </tbody>
                                    </table>
                                </div>










                            </div>
                        </div>





                    </div>
                    <div class="Report_Footer">
                        <div class="Pagination_div" style="display: none;">
                            <label class="totalRows" style="float: left; display: none;">Total Rows : NoRows</label>
                            <label class="message" style="display: none;">No Record Found!</label>
                            <div class="PageButton" style="display: none;">
                                <input class="Report_Footer_child btn_report" type="button" value="Last" onclick="LastPage()">
                                <span class="Report_Footer_child" id="Next" style="width: 32px !important; height: 22px; padding-left: 7px; box-sizing: border-box; padding-top: 4px;" onclick="NextPage()"><i id="filtersubmitright" class="fas fa-angle-double-right"></i></span>

                                <label class="lblTotalPages" id="TotalPages">0</label>
                                <label style="float: right; margin-left: 10px; margin-top: 4px;">of</label>
                                <input class="txt_page_Number" style="width: 25px; height: 13px" type="text" value="1" onkeyup="PageNumOnTxt()">
                                <span class="Report_Footer_child" style="border-radius: 5px 0 0 5px; width: 32px !important; height: 22px; padding-left: 8px; box-sizing: border-box; padding-top: 4px;" onclick="PreviousPage()"><i id="filtersubmitleft" class="fas fa-angle-double-left"></i></span>


                                <input class="Report_Footer_child btn_report" type="button" onclick="FirstPage()" value="First">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>





    </div>
</asp:Content>
