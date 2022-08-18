<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPatientSummaryReport" %>

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
                <td style="text-align: left">
                    <%# Eval("Payer")%>
                </td>
                <td>
                    <%# Eval("TotalPatient")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
                        <input type="hidden" id="hdnDateType" runat="server"  />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnProvider" />
            <asp:HiddenField runat="server" ID="hdnLocation" />
            <asp:HiddenField runat="server" ID="hdnPayer" />
            ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
            ###StartPatientTotal###
    <asp:Literal runat="server" ID="lblTotal"></asp:Literal>
            ###EndPatientTotal###


         ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
