<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterTop10Payer.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterTop10Payer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
    <asp:Repeater ID="rptReport" runat="server">
        <ItemTemplate>
            <tr>
                <td style="text-align: center;">
                    <%# Eval("RowNumber")%>
                </td>
                <td style="text-align: left;">
                    <%# Eval("insurancename")%>
                </td>
                <%--<td style="text-align: center;">
                    <%# Eval("TotalPatients")%>
                </td>--%>
                <td style="text-align: center;">
                    <%# Eval("TotalClaims")%>
                </td>


            </tr>
        </ItemTemplate>
    </asp:Repeater>
            ###End###
            ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRow"></asp:Literal>
            ###EndTotal###
        </div>
    </form>
</body>
</html>
