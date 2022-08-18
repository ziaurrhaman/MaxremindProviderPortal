<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientTransactionsSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientTransactionsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
        <asp:Repeater ID="rptPatientTransactionsSummary" runat="server">
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
                        <%# Eval("Phone")%>
                    </td>
                    <td>
                        <%# Eval("charges")%>
                    </td>
                    <td>
                        <%# Eval("Adjustments")%>
                    </td>
                    <td>
                        <%# Eval("Receipts")%>
                    </td>
                    <%--<td>
                        <%# Eval("Refunds")%>
                    </td>--%>
                    <td>
                        <%# Eval("Unapplied")%>
                    </td>
                    <td>
                        <%# Eval("InsBalance")%>
                    </td>
                    <td>
                        <%# Eval("PatBalance")%>
                    </td>
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
