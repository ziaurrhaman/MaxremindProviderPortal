<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterAdjustmentsDetailReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterAdjustmentsDetailReport" %>

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
                <%--  <td>
                                            <%# Eval("claimid")%>
                                        </td>
                                        <td>
                                            <%# Eval("ClaimChargesId")%>
                                        </td>--%>
                <td>
                    <%# Eval("PostDate")%>
                </td>
                <td>
                    <%# Eval("servicedate")%>
                </td>
                <td>
                    <%# Eval("[Procedure]")%>
                </td>
                <td>
                    <%# Eval("PatientName")%>
                </td>
                <td>
                    <%# Eval("Provider")%>
                </td>
                <td>
                    <%# Eval("Location")%>
                </td>
                <td>
                    <%# Eval("CodeDescriptions")%>
                </td>
                <td>
                    <%# Eval("TotalCharges")%>
                </td>
                <td>
                    <%# Eval("Adjustments")%>
                </td>
                <td>
                    <%# Eval("Payer")%>
                </td>
                <%-- <td>
                                            <%# Eval("AdjustedAmount")%>
                                        </td>--%>
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
            ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###

        </div>
    </form>
</body>
</html>
