<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientTransactionsSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPatientTransactionsSummaryReport" %>

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
                    <%# Eval("PatientId")%>
                </td>
                <td class="linkClass" onclick="PatientTransactionDetail('<%# Eval("PatientId")%>')">
                    <%# Eval("PatientName")%>
                </td>
                <td>
                    <%# Eval("Phone")%>
                </td>
                <td>
                    <%# Eval("charges","{0:0.00}")%>
                </td>
                <td>
                    <%# Eval("Adjustments")%>
                </td>
                <td>
                    <%# Eval("Receipts","{0:0.00}")%>
                </td>
                <%--<td>
                        <%# Eval("Refunds")%>
                    </td>--%>
                <td>
                    <%# Eval("Unapplied")%>
                </td>
                <td>
                    <%# Eval("InsBalance")%>
                </td>
                <td>
                    <%# Eval("PatBalance")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
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
