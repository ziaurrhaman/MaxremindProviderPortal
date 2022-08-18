<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientAppointments.aspx.cs"
    Inherits="ProviderPortal_Patient_CallBacks_PatientAppointments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###Start###
    <div id="divAppointments">
        <div class="Grid">
            <table>
                <thead>
                    <tr>
                        <th>
                        </th>
                        <th>
                            Appointment Date
                        </th>
                        <th>
                            Start Time
                        </th>
                        <th>
                            End Time
                        </th>
                        <th>
                            Provider Name
                        </th>
                        <th>
                            Appointment Reason
                        </th>
                        <th>
                            Location
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Action
                        </th>
                    </tr>
                </thead>
                <tbody id="gridContents">
                    <asp:Repeater runat="server" ID="rptAppointments">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <i>
                                        <%#Eval("RowNumber")%></i>
                                </td>
                                <td>
                                    <%#Eval("AppointmentDate")%>
                                </td>
                                <td>
                                    <%#Eval("StartTime")%>
                                </td>
                                <td>
                                    <%#Eval("EndTime")%>
                                </td>
                                <td>
                                    <%#Eval("ServiceProviderName")%>
                                </td>
                                <td>
                                    <%#Eval("AppointmentReason")%>
                                </td>
                                <td>
                                    <%#Eval("LocationName")%>
                                </td>
                                <td>
                                    <%#Eval("StatusName")%><span class='task-status <%#Eval("StatusName")%>'></span>
                                </td>
                                <td style="width: 20%;">
                                    <span class="action" style="cursor:pointer"><span onclick="viewAppointment('<%#Eval("AppointmentsId")%>');">[View]</span> </span>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="alternatingRow">
                                <td>
                                    <i>
                                        <%#Eval("RowNumber")%></i>
                                </td>
                                <td>
                                    <%#Eval("AppointmentDate")%>
                                </td>
                                <td>
                                    <%#Eval("StartTime")%>
                                </td>
                                <td>
                                    <%#Eval("EndTime")%>
                                </td>
                                <td>
                                    <%#Eval("ServiceProviderName")%>
                                </td>
                                <td>
                                    <%#Eval("AppointmentReason")%>
                                </td>
                                <td>
                                    <%#Eval("LocationName")%>
                                </td>
                                <td>
                                    <%#Eval("StatusName")%><span class='task-status <%#Eval("StatusName")%>'></span>
                                </td>
                                <td style="width: 20%;">
                                    <span class="action" style="cursor:pointer"><span onclick="viewAppointment('<%#Eval("AppointmentsId")%>');">[View]</span> </span>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="message">
                <span class="iconInfo" style="margin: 7px;"></span><span id="spnInfo"></span>
            </div>
            <div class="pager">
                <div class="PageEntries">
                    <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                        <select id="ddlPaging" style="margin-top: 5px;" onchange="RowsChange('FilterRecord');">
                            <option value="10">10</option>
                            <option value="25">25</option>
                            <option value="50">50</option>
                            <option value="75">75</option>
                            <option value="100">100</option>
                        </select>
                    </span><span style="float: left;">&nbsp;entries</span>
                </div>
                <div class="PageButtons">
                    <ul style="float: right; margin-right: 15px;">
                    </ul>
                </div>
            </div>
        </div>
    </div>
    ###End### 
    
    ###StartFilterAppointments###
    <div>
        <asp:Repeater runat="server" ID="rptFilterAppointments">
            <ItemTemplate>
                <tr>
                    <td>
                        <i>
                            <%#Eval("RowNumber")%></i>
                    </td>
                    <td>
                        <%#Eval("AppointmentDate")%>
                    </td>
                    <td>
                        <%#Eval("StartTime")%>
                    </td>
                    <td>
                        <%#Eval("EndTime")%>
                    </td>
                    <td>
                        <%#Eval("ServiceProviderName")%>
                    </td>
                    <td>
                        <%#Eval("AppointmentReason")%>
                    </td>
                    <td>
                        <%#Eval("LocationName")%>
                    </td>
                    <td>
                        <%#Eval("StatusName")%><span class='task-status <%#Eval("StatusName")%>'></span>
                    </td>
                    <td style="width: 20%;">
                        <span class="action" style="cursor:pointer"><span onclick="viewAppointment('<%#Eval("AppointmentsId")%>');">[View]</span> </span>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternatingRow">
                    <td>
                        <i>
                            <%#Eval("RowNumber")%></i>
                    </td>
                    <td>
                        <%#Eval("AppointmentDate")%>
                    </td>
                    <td>
                        <%#Eval("StartTime")%>
                    </td>
                    <td>
                        <%#Eval("EndTime")%>
                    </td>
                    <td>
                        <%#Eval("ServiceProviderName")%>
                    </td>
                    <td>
                        <%#Eval("AppointmentReason")%>
                    </td>
                    <td>
                        <%#Eval("LocationName")%>
                    </td>
                    <td>
                        <%#Eval("StatusName")%><span class='task-status <%#Eval("StatusName")%>'></span>
                    </td>
                    <td style="width: 20%;">
                        <span class="action" style="cursor:pointer"><span onclick="viewAppointment('<%#Eval("AppointmentsId")%>');">[View]</span> </span>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </div>
    ###EndFilterAppointments###
    
    ###StartAppointmentRowsCount###
    <asp:Literal runat="server" ID="ltrlTotalRows"></asp:Literal>
    ###EndAppointmentRowsCount###
    
    ###StartViewAppointments###
    <style type="text/css">
        .div-dialog-contents
        {
            padding: 20px;
        }
    </style>
    <div class="div-dialog-contents">
        <table>
            <tr>
                <td>
                    Appointment Date:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblAppointmentDate"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Start Time:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblStartTime"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    End Time:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblEndTime"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Provider Name:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblProviderName"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Appointment Reason:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblReason"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="trNotes" style="display: none;">
                <td>
                    Notes:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAppointmentReasonNotes" TextMode="MultiLine" Rows="5" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Location:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblLocation"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Status:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblStatus"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    ###EndViewAppointments###
    </form>
</body>
</html>
