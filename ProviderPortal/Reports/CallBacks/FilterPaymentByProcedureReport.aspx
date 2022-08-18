<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPaymentByProcedureReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPaymentByProcedureReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
            <asp:Repeater ID="rptPaymentByProcedure" runat="server" OnItemDataBound="rptPaymentByProcedure_ItemDataBound">

                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <%# Eval("RowNumber")%>
                        </td>
                        <td>
                            <%# Eval("Code")%>
                        </td>
                        <td>
                            <%# Eval("[Description]")%>
                        </td>
                        <td>
                            <%--<%# Eval("AvgPaymentByPrimary")%>--%>
                            <asp:Label ID="lblAvgPaymentByPrimary" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%-- <%# Eval("AvgPaymentBySecondary")%>--%>
                            <asp:Label ID="lblAvgPaymentBySecondary" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%-- <%# Eval("AvgPaymentByPatient")%>--%>
                            <asp:Label ID="lblAvgPaymentByPatient" runat="server"></asp:Label>
                        </td>
                        <td>
                            <%--<%# Eval("AvgTotalPayment")%>--%>
                            <asp:Label ID="lblAvgTotalPayment" runat="server"></asp:Label>
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
