<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterCompanyIndicatorReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterCompanyIndicatorReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###start###
        <tr style="border-bottom: 1px solid #ccc">
            <%--<td>
                <asp:Label ID="Practice" runat="server"></asp:Label>
            </td>--%>
            <td class="text-center">
                <asp:Label ID="Procedures" runat="server"></asp:Label>
            </td>
            <td class="text-right">
                <asp:Label ID="lblCharges" runat="server"></asp:Label>
            </td>
            <td class="text-right">
                <asp:Label ID="lblAdjustments" runat="server"></asp:Label>
            </td>
            <td class="text-right">
                <asp:Label ID="lblPayments" runat="server"></asp:Label>
            </td>
            <td class="text-right">
                <asp:Label ID="lblBalanceDue" runat="server"></asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td>
                <b>Total</b>
            </td>
            <td>
                <asp:Label ID="Procedures1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCharges1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAdjustments1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPayments1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblBalanceDue1" runat="server"></asp:Label>
            </td>
        </tr>--%>

        ###End###
            ###StartTotal###
      <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>

        ###EndTotal###
        
              ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
        ###TimeSpanEnd###
    </form>
</body>
</html>
