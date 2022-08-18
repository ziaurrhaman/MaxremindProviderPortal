<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterChargesSummaryAndDetail.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterChargesSummaryAndDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Filter###
        <asp:Repeater ID="rptFilter" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="AlignDate linkClass" onclick="ChargeDetail('', '')">
                        <%# Convert.ToString(Eval("chargedproc"))==""?"0":Eval("chargedproc")%>
                    </td>
                    <td class="AlignDate linkClass" onclick="ChargeDetail('', 'P')">
                        <%# Convert.ToString(Eval("paidproc"))==""?"0":Eval("paidproc")%>
                    </td>
                    <td class="AlignDate linkClass" onclick="ChargeDetail('', 'U')">
                        <%# Convert.ToString(Eval("unpaidproc"))==""?"0":Eval("unpaidproc")%>
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
            <input type="hidden" id="hdnPracticeLocationIdCharges" runat="server" />
            <input type="hidden" id="hdnclaimidCharges" runat="server" />
            <input type="hidden" id="hdnProviderIdCharges" runat="server" />
            <input type="hidden" id="hdnCPT" runat="server" />
            <input type="hidden" runat="server" value="" id="hdnBillAs" />
            <input type="hidden" id="hdnDateType" runat="server" value="" />
            <input type="hidden" id="hdnStartDate" runat="server" value="" />
            <input type="hidden" id="hdnEndDate" runat="server" value="" />
            <input type="hidden" runat="server" value="" id="hdnClaimStatus" />

            ###End###
            ###StartProcedureDetail###
        <script src='<%= ResolveUrl("~/Scripts/tableHeadFixer.js") %>'></script>
            <script>
                $(document).ready(function () {

                    $(".fixTable").tableHeadFixer();
                });
            </script>
            <div class="parent">
                <%--  <div style="text-align:center"> <span style="background-color: #aadeff;padding: 5px;">Procedure Detail</span></div>--%>
                <div class="exportSummary">
                    <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

                    <span style="float: left; padding-top: 2px; margin-left: 7px">
                        <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('Procedure Detail',this,'printableAreaRDC');">
                            <option></option>
                            <option value="Excel">Excel</option>
                            <option value="PDF">PDF</option>
                            <option value="Word">Word</option>
                        </select>
                    </span>


                    <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaRDC')">
                        <img src="../../Images/PrintView1.png" alt="img" /></span>

                </div>

                <div class="Grid GridReports" id="printableAreaRDC" style="height: 400px; overflow-y: auto; width: 100% !important; padding-top: 0 !important;">

                    <table class="fixTable">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">Patient Name</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">Patient DOB</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">Claim Pri Insurance</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">Claim DOS</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">Location </span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">Claim Physician</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">CPT Code</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">CPT Charges</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">CPT Allowed</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">CPT Insurance Paid</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">Patient Paid</span>
                                </th>
                                <th class="center" style="width: 5%">
                                    <span class="report-column-title">CPT Total Paid</span>
                                </th>


                            </tr>
                        </thead>
                        <tbody id="tbodyChargedProcedure">
                            <asp:Repeater ID="rptReportData" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1 %></td>
                                        <td class="AlignString">
                                            <%# Eval("Patient Name")%>
                                        </td>
                                        <td class="AlignString">
                                            <%# Eval("Patient DOB")%>
                                        </td>

                                        <td class="AlignDate">
                                            <%# Eval("Claim Pri Insurance")%>
                                        </td>
                                        <td class="AlignDate">
                                            <%# Eval("Claim DOS")%>
                                        </td>
                                        <td class="AlignString">
                                            <%# Eval("Service Location")%>
                                        </td>

                                        <td class="AlignString">
                                            <%# Eval("Claim Physician")%>
                                        </td>
                                        <td class="AlignString">
                                            <%# Eval("CPT Code")%>
                                        </td>
                                        <td class="AlignPayment">$<%# Eval("CPT Charges","{0:0.00}")%>
                                        </td>
                                        <td class="AlignPayment">$<%# Eval("CPT Allowed", "{0:0.00}")%>
                                        </td>
                                        <td class="AlignPayment">$<%# Eval("CPT Insurance Paid", "{0:0.00}")%>
                                        </td>
                                        <td class="AlignPayment ">$<%# Eval("Patient Paid", "{0:0.00}")%>
                                        </td>
                                        <td class="AlignPayment ">$<%# Eval("CPT Total Paid", "{0:0.00}") %>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

            </div>
            <script>
                $(document).ready(function () { $("#fixTable").tableHeadFixer(); });
            </script>
            ###EndProcedureDetail###


        </div>
    </form>
</body>
</html>
