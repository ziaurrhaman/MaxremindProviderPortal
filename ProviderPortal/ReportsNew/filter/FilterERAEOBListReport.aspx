<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterERAEOBListReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterERAEOBListReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###Start###
    <asp:Repeater ID="rptReportData" runat="server" OnItemDataBound="rptReportData_ItemDataBound">
        <ItemTemplate>
                <tr>
                        <td>
                            <%# Eval("RowNumber")%>
                        </td>
                        <td>
                            <%# Eval("PaymentType")%>
                        </td>
                        <td>
                            <%# Eval("PayerName")%>
                        </td>
                        <td>
                            <%# Eval("PaymentMethodCode")%>
                        </td>
                        <td>
                            <%# Eval("CheckNumber")%>
                        </td>
                        <td>
                            <%# Eval("CheckIssueDate")%>
                        </td>
                        <td>
                            <asp:Label ID="lblPaymentAmount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPaymentPosted" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUnapplied" runat="server"></asp:Label>
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
