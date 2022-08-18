<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterAppointmentsDetailReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterAppointmentsDetailReport" %>

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
                                            <%# Eval("StartandEndTime")%>
                                        </td>
                                        <td>
                                            <%# Eval("AppointmentDate","{0:d}")%>
                                        </td>
                                        <td>
                                            <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                            <%# Eval("Patient")%>
                                        </td>
                                        <td>
                                            <%# Eval("DateOfBirth","{0:d}")%>
                                        </td>
                                        <td>
                                            <%# Eval("Phone")%>
                                        </td>
                                        <td>
                                            <%# Eval("HomePhone")%>
                                        </td>
                                         <td>
                                            <%# Eval("Name")%>
                                        </td>
                                         <td>
                                            <%# Eval("[Description]")%>
                                        </td>
                                       
                                        <td>
                                            <%# Eval("StatusName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Copay")%>
                                        </td>
                                        <td>
                                              <%# Eval("[Patient-Bal]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Notes")%>
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
