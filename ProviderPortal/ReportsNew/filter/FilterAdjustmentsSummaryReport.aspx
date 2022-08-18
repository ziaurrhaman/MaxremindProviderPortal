<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterAdjustmentsSummaryReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterAdjustmentsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
            <asp:Repeater ID="rptAdjustmentsSummary" runat="server" OnItemDataBound="rptAdjustmentsSummary_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                                <%# Eval("Provider")%>
                            </td>
                            <td>
                                <%# Eval("CoAdjustment")%>
                            </td>
                            <td>
                                <%# Eval("PrAdjustment")%>
                            </td>
                            <td>
                                <%# Eval("PayerAdjustment")%>
                            </td>
                        <td>
                            <%-- <%# Eval("Total")%>--%>
                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnTimeSpan" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnPatient" />
            <asp:HiddenField runat="server" ID="hdnProviderId" />
            <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
            <asp:HiddenField runat="server" ID="hdnPayerId" />
            <asp:HiddenField runat="server" ID="hdnAdjustmentCode" />
            <asp:HiddenField runat="server" ID="hdnProcedureCode" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            ###End###
            
            ###StartTotal###
            <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###

            ###StartAdjustmentTotal###
            <asp:Literal runat="server" ID="lblTotal"></asp:Literal>
            ###EndAdjustmentTotal###

            ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
