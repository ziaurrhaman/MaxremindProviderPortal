<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientAppointmentReportHandler.aspx.cs"
    Inherits="EMR_Reports_CallBacks_PatientAppointmentReportHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###Start###
        <table style="width: 100%;">
            <thead>
                <tr>
                    <th style="width: 2%;">
                    </th>
                    <th style="width: 5%;">
                        Account Number
                    </th>
                    <th style="width: 13%;">
                        Patient Name
                    </th>
                    <th style="width: 10%;">
                        Appointment Date
                    </th>
                    <th style="width: 7%;">
                        Start Time
                    </th>
                    <th style="width: 7%;">
                        End Time
                    </th>
                    <th style="width: 10%;">
                        Location
                    </th>
                    <th style="width: 10%;">
                        Provider
                    </th>
                    <th style="width: 10%;">
                        Status
                    </th>
                </tr>
            </thead>
            <tbody class="tbodyReports">
                <asp:Repeater ID="rptAppointment" runat="server">
                    <ItemTemplate>
                        <tr id='<%# Eval("AppointmentsId") %>'>
                            <td>
                                <i>
                                    <%# Eval("RowNumber") %></i>
                            </td>
                            <td>
                                <%# Eval("PatientId") %>
                            </td>
                            <td>
                                <%# Eval("PatientName") %>
                            </td>
                            <td>
                                <%# Eval("AppointmentDate", "{0:d}") %>
                            </td>
                            <td>
                                <%# Eval("StartTime") %>
                            </td>
                            <td>
                                <%# Eval("EndTime") %>
                            </td>
                            <td>
                                <%# Eval("PracticeLocation")%>
                            </td>
                            <td>
                                <%# Eval("ResouurceProviderName")%>
                            </td>
                            <td>
                                <%# Eval("StatusName")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id='<%# Eval("AppointmentsId") %>' class="alternatingRow">
                            <td>
                                <i>
                                    <%# Eval("RowNumber") %></i>
                            </td>
                            <td>
                                <%# Eval("PatientId") %>
                            </td>
                            <td>
                                <%# Eval("PatientName") %>
                            </td>
                            <td>
                                <%# Eval("AppointmentDate", "{0:d}") %>
                            </td>
                            <td>
                                <%# Eval("StartTime") %>
                            </td>
                            <td>
                                <%# Eval("EndTime") %>
                            </td>
                            <td>
                                <%# Eval("PracticeLocation")%>
                            </td>
                            <td>
                                <%# Eval("ResouurceProviderName")%>
                            </td>
                            <td>
                                <%# Eval("StatusName")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        ###End### 
        ###StartRowsCount###
        <asp:Literal ID="ltrRowsCount" runat="server"></asp:Literal>
        ###EndRowsCount###
    </div>
    </form>
</body>
</html>
