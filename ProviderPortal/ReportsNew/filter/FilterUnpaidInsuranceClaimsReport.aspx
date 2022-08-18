<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterUnpaidInsuranceClaimsReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterUnpaidInsuranceClaimsReport" %>

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
             <%--Edited By Faiza Bilal 6-14-2022 to change layout of grid--%>
            <tr id="trMain" runat="server">
               
                <td id="trpatient" runat="server" style="border: none;background-color:white">
                             <asp:Label ID="LblPatient" runat="server"></asp:Label>
                </td>
                <%-- //End Edited By Faiza Bilal 6-14-2022 to change layout of grid--%>
                <td>
                    <%# Eval("Insurance")%>
                </td>
                <td>
                    <%# Eval("Encounter")%>
                </td>
                <td>
                    <%# Eval("BillDate")%>
                </td>
                <td>
                    <%# Eval("ServiceDate")%>
                </td>
                <td>
                    <%--<%# Eval("[Procedures]")%>--%>
                    <asp:Label ID="lblProcedures" runat="server"></asp:Label>
                </td>
                <td>
                    <%# Eval("Diag1")%>
                </td>
                <td>
                    <%# Eval("Diag2")%>
                </td>
                <td>
                    <asp:Label ID="lblCharges" runat="server"></asp:Label>
                </td>

            </tr>
        </ItemTemplate>
    </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
            <asp:HiddenField runat="server" ID="hdnProviderId" />
            <asp:HiddenField runat="server" ID="hdnPayerId" />
            <asp:HiddenField runat="server" ID="hdnBalance" />
            <asp:HiddenField runat="server" ID="hdnDateOfService" />
            <asp:HiddenField runat="server" ID="hdnBillDateFrom" />
            <asp:HiddenField runat="server" ID="hdnBillDateTo" />
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
