<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterReportMonthlyReconciliation.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterReportMonthlyReconciliation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       ###Start###
    <asp:Repeater ID="rptMonthlyReconciliation" runat="server" OnItemDataBound="rptMonthlyReconciliation_ItemDataBound">
        <ItemTemplate>
                                  <tr>
                        <td>
                            <%# Eval("RowNumber")%>
                        </td>
                        <td>
                            <%# Eval("Patient")%>
                        </td>
                        <td>
                            <%# Eval("claimId")%>
                        </td>
                        <td>
                            <%# Eval("DOS")%>
                        </td>
                        <td>
                            <asp:Label ID="lblCheckNumber" runat="server">"<%# Eval("CheckNumber")%>"</asp:Label>
                        </td>
                        <td>
                            <%# Eval("CheckIssueDate")%>
                        </td>
                        <td>
                            <%# Eval("PaymentAmount")%>
                        </td>
                        <td>
                            <%# Eval("Payername")%>
                        </td>
                        <td>
                            <%# Eval("UnpaidClaims")%>
                        </td>
                        <td>
                            <%# Eval("Remarks")%>
                        </td>
                        <td>
                            <%# Eval("St")%>
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
