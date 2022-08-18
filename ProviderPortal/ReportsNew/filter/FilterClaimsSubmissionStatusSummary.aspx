<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterClaimsSubmissionStatusSummary.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterClaimsSubmissionStatusSummary" %>

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
                <td>
                    <%# Eval("Location")%>
                </td>
                <td>
                    <%# Eval("InsuranceName")%>
                </td>

                <td>
                    <%# Eval("Billed")%>
                </td>
                <td>
                    <%# Eval("ReadyForSubmission")%>
                </td>
                <td>
                    <%# Eval("PaidUp")%>
                </td>
                <td>
                    <%# Eval("Denied")%>
                </td>
                <td>
                    <%# Eval("PendingForSumbmission")%>
                </td>
                <td>
                                        <%# Eval("Inprocess")%>
                                    </td>
                <td>
                    <%# Eval("PTL")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>

                        <input type="hidden" id="hdnLocations" runat="server" value=""/>
            <input type="text" runat="server" id="hdnDateFrom" style="display: none" />
            <input type="text" runat="server" id="hdnDateTo" style="display: none" />
            <input type="text" runat="server" id="hdnDateType" style="display: none" />
            <input type="text" runat="server" id="hdnTotalRows" style="display: none" />
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
