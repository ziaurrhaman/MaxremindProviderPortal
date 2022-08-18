<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterSettledChargesSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterSettledChargesSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="WidgetReport" style="margin-top: 10px;">
                <div id="divReportPaging">
                    <div class="pagerReport">

                        <div class="PageButtonsReports">
                            <ul style="float: right; margin-right: 15px;">
                            </ul>
                        </div>
                        <div class="report-tools">
                            <table>
                                <tr>
                                    <td>
                                        <div class="report-export-wrapper">
                                            <%--   --%>
                                            <asp:DropDownList ID="ddlExportTo" runat="server" CssClass="custom-export-drop-down"
                                               AutoPostBack="True">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="Excel" Text="Excel"></asp:ListItem>
                                                <asp:ListItem Value="PDF" Text="PDF"></asp:ListItem>
                                                <asp:ListItem Value="Word" Text="Word"></asp:ListItem>
                                            </asp:DropDownList>
                                            <a href="javascript:void(0)" class="custom-export-icon">
                                                <img src="../../Images/exportIconLeft.gif" style="border-style: None; height: 16px; width: 16px;">
                                                <span style="width: 5px; text-decoration: none;"></span>
                                                <img src="../../Images/exportIconRight.gif" style="border-style: None; height: 6px; width: 7px; margin-bottom: 5px;">
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
    </form>
</body>
</html>
