<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentsSummaryReportHandler.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_PaymentsSummaryReportHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
              <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
    
            <script>
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                });
            </script>
        <div id="dialogue">

            <div class="exportSummary">
                <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                <span style="float: left; padding-top: 2px; margin-left: 7px">
                    <select id="ddlPS" class="custom-export-drop-down" onchange="ExportReportForSummary('Payments Summary & Detail',this,'printableAreaPS');">
                        <option></option>
                        <option value="Excel">Excel</option>
                        <option value="PDF">PDF</option>
                        <option value="Word">Word</option>
                    </select>
                </span>


                <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaPS')">
                    <img src="../../Images/PrintView1.png" alt="img" /></span>

            </div>



            <div class="Grid" style="height: 400px; overflow-y: auto;">

                <div class="GridReports" id="printableAreaPS" style="width: 100% !important;">
                    <div class="TimeSpan">
                        <span style="font-weight: 600">Provider:</span>
                        <asp:Label runat="server" ID="Providerlbl" Style="margin-right: 30px;"></asp:Label>
                        <span style="font-weight: 600">Time Span:</span>
                        <asp:Label runat="server" ID="TimeSpan1"></asp:Label>
                    </div>

                    <table class="fixTable">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Claim Id</th>
                                <th>Patient Id</th>
                                <th>Patient</th>
                                <th>DOS</th>
                                <th>Paid Amount</th>
                                <th>Check No.</th>
                                <th>Chk Issue Date</th>
                                <th>Payer Name</th>
                                <th>Post Date</th>
                            </tr>
                        </thead>
                        <tbody class="checkdetailTbody">
                            <asp:Repeater runat="server" ID="rptPS">
                                <ItemTemplate>
                                    <tr>

                                        <td class="center"><%# Eval("Row#") %></td>
                                        <td class="center"><%# Eval("ClaimId") %></td>
                                        <td class="center"><%# Eval("PatientId") %></td>
                                        <td class="left"><%# Eval("Patient") %></td>
                                        <td class="center"><%# Eval("DOS","{0:d}") %></td>
                                        <td class="right" style="text-align: right;"><%# Eval("PaidAmount","{0:c}") %></td>
                                        <td class="left"><%# Eval("CheckNumber") %></td>
                                        <td class="center"><%# Eval("CheckIssueDate","{0:d}") %></td>
                                        <td class="left"><%# Eval("PayerName") %></td>
                                        <td class="center"><%# Eval("PostDate","{0:d}") %></td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
            </div>
        </div>
            ###endReport###

        ###StartFilter###
                                <asp:Repeater runat="server" ID="rptPaymentsSummary">
                                    <ItemTemplate>
                                        <tr style="border-bottom: 1px solid #cccccc;">
                                            <td style="text-align: center; width: 20%; border-right: 1px solid #ccc; border-left: 1px solid #ccc">
                                                <%# Eval("Provider") %>
                                            </td>
                                            <td class="InsuranceAmount" style="text-align: right; width: 20%; border-right: 1px solid #ccc; border-left: 1px solid #ccc" onclick="PSDetail('Insurance','<%# Eval("StaffNPI") %>','<%# Eval("Provider") %>')">
                                                <%# Eval("Insurance","{0:c}") %>
                                            </td>
                                            <td class="InsuranceAmount" style="text-align: right; width: 20%; border-right: 1px solid #ccc; border-left: 1px solid #ccc" onclick="PSDetail('Patient','<%# Eval("StaffNPI") %>','<%# Eval("Provider") %>')">
                                                <%# Eval("Patient","{0:c}") %>
                                            </td>
                                            <td style="text-align: right; width: 20%; border-right: 1px solid #ccc; border-left: 1px solid #ccc">
                                                <%# Eval("Total","{0:c}") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
            <input type="hidden" id="hdnTotalRows" runat="server" value="0" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />


            ###END###
        </div>
    </form>
</body>
</html>
