<%@ Page Title="" Language="C#" MasterPageFile="~/ProviderPortal/BillingMaster.master" AutoEventWireup="true" CodeFile="SettledChargesSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_SettledChargesSummaryReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../StyleSheets/Reports.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../../Scripts/Reports.js" type="text/javascript"></script>
    <link href="../../StyleSheets/ApplicationTheme.css" rel="stylesheet" />
    <link href="../../StyleSheets/EHRdefaultCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    ###StartReport###

    <div class="Widget" style="margin-top: 10px;">
        <%--<div class="WidgetTitle">
            <span id="spnTitle" style="font-size: 15px;">Settled Charges Summary</span>
        </div>--%>
        <div class="reportsCriteriabar" style="background: #dfe3e5; height: 36px;">
            <div class="report-criteria-wraper" style="width: 50% !important; font-weight: bold;">
                <%-- <table>
                    <tr>
                        <td style="font-weight: bold; width: 23%;">
                            Time Span:
                        </td>
                        <td style="width: 50%;">--%>
                <br />
                <span>Time Span:</span>
                <asp:Label runat="server" ID="lblReportTimeSpanFrom"></asp:Label>
              
                <%--</td>
                    </tr>
                </table>--%>
            </div>
            <div class="report-criteria-wraper" style="width: 50% !important; float: right;">
                <a href="javascript:void(0);" class="report-criteria-link" onclick="OpenPatientFilterDialog('SCS');" style="float: right; font-weight: bold; margin-right: 3%; margin-top: -2%;">
                    <span class="spanedit" style="margin-right: 3px;"></span>Report Criteria</a>
            </div>
        </div>
        <div class="WidgetContent">
            <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">

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
                          
                            <table style='width: 60%; font-size: 14px; margin-left: 3%;'>
                                <thead>
                                    <tr>
                                        <th style="text-align: left; border-bottom: 1px solid black;">Transection</th>
                                        <th style="text-align: right; border-bottom: 1px solid black; width:25%">Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Charges</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><span style="margin-left: 20px;">Charges</span></td>
                                        <td style="border-bottom: 1px solid black;text-align: right;">
                                            <asp:Label runat="server" ID="Charges"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><span style="font-weight: bold;">Total Charges</span></td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" ID="TotalCharges"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Adjustments</td>
                                        <td></td>
                                    </tr>

                                    <tr>
                                        <td><span style="margin-left: 20px;">ContractualAdjustments</span></td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" ID="ContractualAdjustments"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td><span style="margin-left: 20px;">Second Adjustment</span></td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" ID="SecondaryAdjustments"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td><span style="margin-left: 20px;">Other Adjustments</span></td>
                                        <td style="border-bottom: 1px solid black;text-align: right;">
                                            <asp:Label runat="server" ID="OtherAdjustments"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td><span style="font-weight: bold;">Total Adjustments</span></td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" ID="TotalAdjustments"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Payments</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><span style="margin-left: 20px;">Patient Payments</span></td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" ID="PatientPayments"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><span style="margin-left: 20px;">Insurance Payments</span></td>
                                        <td style="border-bottom: 1px solid black;text-align: right;">
                                            <asp:Label runat="server" ID="InsurancePayments"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><span style="font-weight: bold;">Total Payments</span></td>
                                        <td style="border-bottom: 1px solid black;text-align: right;">
                                            <asp:Label runat="server" ID="TotalPayments"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><span style="font-weight: bold;">Balance</span></td>
                                        <td style="text-align: right;">
                                            <asp:Label runat="server" ID="TotalBalance"></asp:Label>$0.00</td>
                                    </tr>
                                </tbody>


                            </table>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="divDialogReportFilters" style="display: none;"></div>

    <style>
        #headers {
            padding-left: 35%;
            box-sizing: border-box;
            padding-top: 20px;
            padding-bottom: 35px;
            width: 100%;
        }

        #Transaction {
            border-bottom: 1px solid black;
            width: 100%;
            float: left;
            padding-left: 0px;
            font-size: 16px;
            font-weight: 700;
        }

        #Transaction_Total {
            float: left;
            margin-left: 15px;
            border-bottom: 1px solid black;
            width: 100%;
            text-align: right;
            font-size: 16px;
            font-weight: 700;
        }

        .right-margin {
            margin-left: 14px;
        }

        ul, li {
            margin-bottom: 10px !important;
        }

        .Total {
            font-weight: 700;
        }

        .Total1 {
            font-weight: 700;
            border-Top: 1px solid black;
        }
    </style>

    
    ###EndReport###

</asp:Content>
