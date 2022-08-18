
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterOverPaidClaimsReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterOverPaidClaims" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
    <asp:Repeater ID="rptReportData" runat="server">
        <ItemTemplate>
            <tr>
                <td style="text-align: center;">
                    <%# Eval("RowNumber")%>
                </td>

                <td style="text-align: center">
                    <%# Eval("ClaimId")%>
                </td>
                <td class="align_center">
                    <%# Eval("PatientId")%>
                </td>
                <td>
                    <%# Eval("Patient")%>
                </td>
                <td class="align_center">
                    <%# Eval("[DOS]")%>
                </td>
                <td class="align_center">
                    <%# Eval("CPTCode")%>
                </td>
                <td style="text-align: right">
                    <%# Eval("Totalcharges")%>
                </td>
                <td style="text-align: right">
                    <%# Eval("AllowedAmount")%>
                </td>
                <td style="text-align: right">
                    <%# Eval("PaidAmount")%>
                </td>
                <td style="text-align: right">
                    <%# Eval("BalanceDue")%>
                </td>
                <td style="text-align: center">
                    <%# Eval("BilledAs")%>
                </td>
                <td>
                    <%# Eval("Payer")%>
                </td>
               <%-- <td>
                    <%# Eval("ClaimStatus")%>
                </td>--%>

            </tr>
        </ItemTemplate>
    </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnInsuranceType" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnClaimStatus" />
            <asp:HiddenField runat="server" ID="hdnPayers" />
            <asp:HiddenField  runat="server" ID="hdnProviderId"/>
            <asp:HiddenField  runat="server" ID="hdnLocationId"/>
            ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
                        ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>

    </form>
</body>
</html>
