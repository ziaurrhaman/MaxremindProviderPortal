<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientBalanceDetailsReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientBalanceDetailsReport" %>

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
        </asp:Repeater>
            ###End###
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
    
        </div>
    </form>
</body>
</html>
