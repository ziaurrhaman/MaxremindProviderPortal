<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterContractManagementSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterContractManagementSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
    <asp:Repeater ID="rptContractManagementSummary" runat="server" OnItemDataBound="rptReportData_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td style="text-align: center;">
                    <%# Eval("RowNumber")%>
                </td>
                <%-- <td>
                                            <%# Eval("InsuranceId")%>
                                        </td>--%>
                <td style="white-space:normal !important">
                    <%# Eval("[Procedure]")%>
                </td>
                <td>
                    <%--<%# Eval("AllowedAmount")%>--%>
                    <asp:Label ID="lblAllowedAmount" runat="server"></asp:Label>
                </td>
                <td>
                    <%--<%# Eval("AVGPayment")%>--%>
                    <asp:Label ID="lblAVGPayment" runat="server"></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>




            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnInsuranceId" />
            <asp:HiddenField runat="server" ID="hdnPatId" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnProviderId" />
            <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
            <asp:HiddenField runat="server" ID="hdnProcedureCode" />
            ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
                ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###

        ###StartAllowedAmount###
        <asp:Literal runat="server" ID="lblTotalAllowedAmount"></asp:Literal>
            ###EndAllowedAmount###

                ###StartTotalAVGPayment###
        <asp:Literal runat="server" ID="lblTotalAVGPayment"></asp:Literal>
            ###EndTotalAVGPayment###
        </div>
    </form>
</body>
</html>
