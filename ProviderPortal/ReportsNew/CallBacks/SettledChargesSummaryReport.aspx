<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SettledChargesSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_SettledChargesSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
 
          ###startReport###
        <div class="TimeSpan">
            <span style="font-weight:600">Time Span:</span> <asp:Label runat="server" Id="TimeSpan"></asp:Label>
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

  <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
    <asp:HiddenField runat="server" ID="hdnTimeSpan" />
    <asp:HiddenField runat="server" ID="hdnDateFrom" />
    <asp:HiddenField runat="server" ID="hdnDateTo" />
    <div id="divDialogReportFilters" style="display: none;"></div>


        <script type="text/javascript">
            debugger;
            var Rows1 = "";
            function RowsChange(PageNumber, sortValue) {
                debugger;
                var params;
                pageNumber = PageNumber;
                Rows1 = $("#ddlPaging").val();

                var paging = true;

                if (_selectedReport_Filter != "") {
                    params = {
                        DateFrom: $("[id$='hdnDateFrom']").val(),
                        DateTo: $("[id$='hdnDateTo']").val(),
                        Rows: Rows1,
                        PageNumber: pageNumber,
                        SortBy: sortValue,
                        action: "Filter"
                    };

                    debugger
                    Report_ReloadData(_selectedReport_Filter, params, paging);
                }


            }

        </script>


         ###endReport###


    </form>
</body>
</html>
