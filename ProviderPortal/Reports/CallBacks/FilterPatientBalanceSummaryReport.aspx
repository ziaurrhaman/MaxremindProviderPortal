<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientBalanceSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientBalanceSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
        <asp:Repeater ID="rptPatientBalanceSummary" runat="server">
            <ItemTemplate>
                <tr>
                     <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                    <td>
                        <%# Eval("PatientId")%>
                    </td>
                    <td>
                        <%# Eval("PatientName")%>
                    </td>
                    <td>
                        <%# Eval("charges")%>
                    </td>
                    <td>
                        <%# Eval("adjustments")%>
                    </td>
                    <td>
                        <%# Eval("Insurancepmt")%>
                    </td>
                    <td>
                        <%# Eval("PatientPmt")%>
                    </td>
                    <td>
                        <%# Eval("TotalBalance")%>
                    </td>
                    <td>
                        <%# Eval("PendingIns")%>
                    </td>
                    <td>
                        <%# Eval("Patientbalance")%>
                    </td>
                    <%--<td>
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
