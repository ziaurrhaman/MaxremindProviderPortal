<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPTLClaim.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_PTLClaim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        ###Start###
        <asp:Repeater ID="rptPTLAll" runat="server">
            <ItemTemplate>
                <tr style="cursor: pointer;">
                    <td class="text-right">
                        <%# Eval("ROWNUMBER") %>
                    </td>
                    <td class="text-right">
                        <%# Eval("PatientId") %>
                    </td>
                    <td>
                        <%# Eval("PatientName") %>
                    </td>

                    <td>
                        <%# Eval("ClaimId") %>
                    </td>
                    <td>
                        <%# Eval("ServiceDate", "{0:d}") %>
                    </td>
                    <td>
                        <%# Eval("Location") %>
                    </td>
                    <td>
                        <%# Eval("Name") %>
                    </td>
                    <td style="white-space:normal !important;">
                        <%# Eval("CLMPTLReasons")%> , <%# Eval("PAtptlReasons")%>
                    </td>
                    <%--                    <td style="display: none" class="ReportShow">
                        <asp:Label runat="server" ID="QA"></asp:Label>
                    </td>
                    <td style="display: none" class="ReportShow">
                        <asp:Label runat="server" ID="Audit"></asp:Label>
                    </td>
                    <td style="display: none; text-align: center;" class="ReportShow">
                        <asp:Label runat="server" ID="CRM"></asp:Label>
                    </td>
                    <td class="tdQAApproved ReportHide iconAlign" style="text-align: center">

                        <asp:Label runat="server" ID="lblQA"></asp:Label>
                    </td>
                    <td class="tdAuditApproved ReportHide iconAlign" style="text-align: center">
                        <asp:Label runat="server" ID="lblAudit"></asp:Label>

                    </td>
                    <td class="tdcrmApproved ReportHide iconAlign" style="text-align: center">
                        <asp:Label runat="server" ID="lblCRM"></asp:Label>


                    </td>--%>
                    <td style="text-align: center">
                        <%# Eval("CommCount")%>
                    </td>
                    <td>
                        <%# Eval("CommunicationDate")%>
                    </td>
                    <td style="display: none" class="ReportShow"><%# Eval("DOB") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("SSN") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("ClaimPriIns") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("DemoPriIns") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("ClaimPriInsId") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("DemoPriInsId") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("ClaimStatus") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("AttendingPhysician") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("PostDate") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("BillDate") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("CPTCode") %></td>
                    <td style="display: none" class="ReportShow"><%# Eval("DxCodes") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <asp:HiddenField runat="server" ID="hdnDateFrom" />
        <asp:HiddenField runat="server" ID="hdnDateTo" />
        <asp:HiddenField runat="server" ID="hdnDateType" />
        <asp:HiddenField runat="server" ID="hdnLocations" Value="" />
        <asp:HiddenField runat="server" ID="hdnPayers" Value="" />
        ###End###

    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
        ###EndTotal###
        ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
        ###TimeSpanEnd###
    </form>
</body>
</html>
