<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppointmentDetailsHandler.aspx.cs" Inherits="ProviderPortal_Appointments_CallBacks_AppointmentDetailsHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ####StartAppointmentDetails####
        <asp:HiddenField runat="server" ID="hdnAppointmentsIdAppointmentDetail" />
        <asp:HiddenField runat="server" ID="hdnPracticeLocationsIdAppointmentDetail" />
        <asp:HiddenField runat="server" ID="hdnAttendingPhysicianAppointmentDetail" Value="0" />

        <asp:HiddenField runat="server" ID="hdnPatientIdAppointmentDetail" />
        <asp:HiddenField runat="server" ID="hdnAppointmentDateAppointmentDetail" />

        <table style="width: 98%; margin: 0 auto;">
            <tr style="height: 90px;">
                <td>
                    <asp:Image ID="imgUserImage" ImageUrl="" Width="80px" Height="80px" runat="server" />

                    <div style="float:right; width: 100px;">
                        <ul class="ul-patient-info-detail">
                            <li>
                                <span onclick="OpenPatientInfo(event, 'Demographics');">Demographics</span>
                            </li>
                            <li style="display:none">
                                <span onclick="OpenPatientInfo(event, 'LatestChart');">Recent Chart</span>
                            </li>
                            <li style="display:none"> 
                                <span onclick="OpenPatientInfo(event, 'Documents');">Documents</span>
                            </li>
                            <li style="display:none">
                                <span onclick="OpenPatientInfo(event, 'BalanceSheet');">Balance Sheet</span>
                            </li>
                            <li style="display:none">
                                <span onclick="OpenSuperBill(event, 'AppointmentCalanderDetail');">Super Bill</span>
                            </li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold; color: black; text-align: center; line-height: 19px;">
                    Appointment Detail
                </td>
            </tr>
            <tr style="border-top: 1px solid; padding-top: 2px; display: block;">
                <td>
                    Patient:
                    <asp:Label ID="lblPatientName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Age:
                    <asp:Label ID="lblAge" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Appointment Time:
                    <asp:Label ID="lblAppointmentTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Home Phone:
                    <asp:Label ID="lblHomePhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Work Phone:
                    <asp:Label ID="lblWorkPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Appointment Date:
                    <asp:Label ID="lblAppointmentDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Appointment Status:
                    <asp:Label ID="lblAppointmentStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="border-bottom: 1px solid; padding-bottom: 4px; display: block;">
                <td>
                    Provider:
                    <asp:Label ID="lblProvider" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        ####EndAppointmentDetails####
    </div>
    </form>
</body>
</html>
