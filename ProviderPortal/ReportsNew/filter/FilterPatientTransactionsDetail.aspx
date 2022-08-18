<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientTransactionsDetail.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPatientTransactionsDetail" %>

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
                <td style="text-align: center;">
                    <%# Eval("RowNumber")%>
                </td>
                <td>
                    <%# Eval("Patient") %>
                </td>
                <td>
                    <%# Eval("PostDate") %>
                </td>
                <td>
                    <%# Eval("ClaimId") %>
                </td>
                <td>
                    <%# Eval("ProcedureCode") %>
                </td>
                <td>
                    <%# Eval("DOS") %>
                </td>
                <td>
                    <%# Eval("Provider") %>
                </td>
                <td>
                    <%# Eval("Location") %>
                </td>
                <td>
                    <%# Eval("Charges","{0:0.00}") %>
                </td>
                <td>
                    <%# Eval("Adjustments","{0:0.00}") %>
                </td>
                <td>
                    <%# Eval("BalanceDue","{0:0.00}") %>
                </td>

                <td>
                    <asp:Label ID="lblPayment" runat="server"></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
                        <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnPatientId" />
            <asp:HiddenField runat="server" ID="hdnLocation" />
            <asp:HiddenField runat="server" ID="hdnProvider" />
            <asp:HiddenField runat="server" ID="hdnProcedure" />
            ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###

            ###TotalPayments###

                        <div style="text-align: center; margin: 10px"><span style="color: teal; font-weight: bold;">Total Payment:</span><span style="font-weight: bold;">
                            <asp:Label runat="server" ID="lbltotalPayment" CssClass="" /></span></div>

            ###EndPayments###
           
    
                                

        </div>
        ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
                                ###TimeSpanEnd###
    </form>
</body>
</html>
