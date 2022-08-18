<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterProcedurePaymentsSummaryAndDetail.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterProcedurePaymentsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartFilter###
         <div class="exportSummary">
             <span style="float: left; margin-left: 5px; padding-top: 7px; box-sizing: border-box;">Export To: &nbsp;</span>

             <span style="float: left; padding-top: 2px; margin-left: 7px">
                 <select id="ddlRDC" class="custom-export-drop-down" onchange="ExportReportForSummary('ProcedurePaymentSummary',this,'printableAreaRDC');">
                     <option></option>
                     <option value="Excel">Excel</option>
                     <option value="PDF">PDF</option>
                     <option value="Word">Word</option>
                 </select>
             </span>


             <span style="margin-left: 10px; cursor: pointer; margin-top: 5px; position: absolute;" onclick="PrintReoprt('printableAreaRDC')">
                 <img src="../../Images/PrintView1.png" alt="img" /></span>

         </div>
            <div class="Grid" id="printableAreaRDC" style="overflow-y: scroll; height: 430px;">
                <table>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Claim Id</th>
                            <th>Patient</th>
                            <th>DOS</th>
                            <th>CPT</th>
                            <th>Charges</th>
                            <th>Allowed Amt</th>
                            <th>Paid Amt</th>
                            <th>Insurance</th>
                            <th>Pmt Source</th>
                            <th>Status</th>


                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptReportData" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="AlignDate">
                                        <%# Eval("RowNumber ")%>
                                    </td>
                                    <td class="AlignDate">
                                        <%# Eval("ClaimId")%>
                                    </td>
                                    <td class="AlignString">
                                        <%# Eval("Patient")%>
                                    </td>
                                    <td class="AlignDate">
                                        <%# Eval("DOS")%>
                                    </td>
                                    <td class="AlignDate">
                                        <%# Eval("CPT")%>
                                    </td>
                                    <td class="AlignPayment">
                                        <%# Eval("Charges","{0:0.00}")%>
                                    </td>
                                    <td class="AlignPayment">
                                        <%# Eval("AllowedAmt","{0:0.00}")%>
                                    </td>
                                    <td class="AlignPayment">
                                        <%# Eval("PaidAmt","{0:0.00}")%>
                                    </td>
                                    <td class="AlignString">
                                        <%# Eval("Insurance")%>
                                    </td>
                                    <td class="AlignString">
                                        <%# Eval("PmtSource")%>
                                    </td>
                                    <td class="AlignString">
                                        <%# Eval("SubmissionStatus")%>
                                    </td>
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            ###EndFilter###

            ###Start###
                        <asp:Repeater ID="rptProcedurePaymentsSummary" runat="server">

                            <ItemTemplate>
                                <tr>
                                    <td class="AlignDate">
                                        <%# Eval("RowNumber")%>
                                    </td>
                                    <td class='AlignString tdInsurance '>
                                        <%# Eval("Insurance")%>
                                        <input type="hidden" class="hdnInsuranceid" value=" <%# Eval("InsId")%>"></hidden
                                        <input type="hidden" class="hdnCPT" value=" <%# Eval("CPT")%>"></hidden

                                    </td>
                                    <td class="AlignDate tdCPT">
                                        <%# Eval("CPT")%>
                                    </td>
                                    <td class="AlignPayment">$<%# Eval("TotalPmt","{0:0.00}")%>
                                    </td>
                                    <td class="AlignPayment">$<%# Eval("AVgPmt","{0:0.00}")%>
                                    </td>
                                    <td class="AlignDate">
                                        <%# Eval("Frequency")%>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

            <asp:HiddenField runat="server" ID="hdnCPTs" />
            <asp:HiddenField runat="server" ID="hdnInsuranceIds" />
            <asp:HiddenField runat="server" ID="hdnInsurancetype" />
            <asp:HiddenField runat="server" ID="hdnLocation" />
            <asp:HiddenField runat="server" ID="hdnProviderId" />
            <script type="text/javascript">
                debugger
                var cpts = $('#hdnCPTs').val();
                var insuranecs = $('#hdnInsuranceIds').val();;
                $('.tdInsurance').addClass('linkClass');
                $('.tdInsurance').attr('onclick', 'InsuranceDetail(this)');
                //if (cpts.split(',').length > 1) {
                //    $('.tdCPT').addClass('linkClass');
                //    $('.tdCPT').attr('onclick', 'CPTDetail(this)');

                //}
                //else {
                //    if (cpts.split(',').length == 1 && insuranecs.split(',').length == 2) {
                //        $('.tdCPT').addClass('linkClass');
                //        $('.tdCPT').attr('onclick', 'CPTDetail(this)');
                //    }
                //    else {
                //        $('.tdInsurance').addClass('linkClass');
                //        $('.tdInsurance').attr('onclick', 'InsuranceDetail(this)');
                //    }
                //}


            </script>

            ###End###
            ###StartTotal###
            <asp:Literal runat="server" ID="hdnTotalRows"></asp:Literal>
            ###EndTotal###

        </div>
    </form>
</body>
</html>
