<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientBalanceDetailReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPatientBalanceDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
    <asp:Repeater ID="rptPatientBalanceDetail" runat="server" OnItemDataBound="rptPatientBalanceDetail_ItemDataBound">
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
                <td style="white-space:normal !important;">
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
    </asp:Repeater>
            <asp:HiddenField ID="hdnPatientId" runat="server" />
            <asp:HiddenField ID="hdnProcedureCode" runat="server" />
            <asp:HiddenField ID="hdnDOB" runat="server" />
            <asp:HiddenField ID="hdnCustomDate" runat="server" />
            ###End###
                
            ###StartTotalCharges###
            <asp:Literal ID="lblTotalCharges" runat="server"></asp:Literal>
            ###EndTotalCharges###

            ###StartTotalAdjustments###
            <asp:Literal ID="lblTotalAdjustments" runat="server"></asp:Literal>
            ###EndTotalAdjustments###

            ###StartInsurancePayments###
            <asp:Literal ID="lblTotalInsurancePayments" runat="server"></asp:Literal>
            ###EndInsurancePayments###

            ###StartTotalPatientPayments###
            <asp:Literal ID="lblTotalPatientPayments" runat="server"></asp:Literal>
            ###EndTotalPatientPayments###

            ###StartGrandTotalBalance###
            <asp:Literal ID="lblGrandTotalBalance" runat="server"></asp:Literal>
            ###EndGrandTotalBalance###

            ###StartPendingIns###
            <asp:Literal ID="lblPendingIns" runat="server"></asp:Literal>
            ###EndPendingIns###


            ###StartPatientbalance###
            <asp:Literal ID="lblPatientbalance" runat="server"></asp:Literal>
            ###EndPatientbalance###

            ###StartTotal###
            <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
            
            
            ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###

        </div>
    </form>
</body>
</html>
