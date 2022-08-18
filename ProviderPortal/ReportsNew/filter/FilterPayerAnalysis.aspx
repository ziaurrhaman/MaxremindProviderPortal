<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPayerAnalysis.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPayerMixSummaryReport" %>

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
                <td class="center">
                    <%# Eval("RowNumber")%>
                </td>
                <td class="AlignString">
                    <%# Eval("PayerName")%>
                </td>
                <td class="center">
                    <asp:Label ID="lblPatient" runat="server"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="lblPtnt" runat="server"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="lblEncounter" runat="server"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="lblEncntrs" runat="server"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="lblProcedure" runat="server"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="lblProc" runat="server"></asp:Label>
                </td>
                <td class="AlignPayment">
                    <asp:Label ID="lblCharges" runat="server"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="lblChrgs" runat="server"></asp:Label>
                </td>
                <td class="AlignPayment">
                    <asp:Label ID="lblReceipt" runat="server"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="lblRcpts" runat="server"></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnInsurance" />
            <asp:HiddenField ID="hdnProviderId" runat="server" />
            <asp:HiddenField ID="hdnLocation" runat="server" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="hdnTotalRows"></asp:Literal>
            ###EndTotal###

        </div>
    </form>
</body>
</html>
