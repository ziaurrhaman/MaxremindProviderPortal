<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterAppointmentSummary.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterAppointmentSummary" %>

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
                                                        <%# Eval("AppointmentDate")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Location")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("TotalAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CompletedAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PendingAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("NoShowAppointments")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckedInAppointments")%>
                                                    </td>
                                                </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
    ###EndTotal###
    </div>
    </form>
</body>
</html>
