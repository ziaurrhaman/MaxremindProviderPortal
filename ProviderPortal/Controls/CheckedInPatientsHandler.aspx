<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckedInPatientsHandler.aspx.cs" Inherits="ProviderPortal_Controls_CheckedInPatientsHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
    ###Start###
    <asp:Repeater runat="server" ID="rptCheckedInPatients" OnItemDataBound="rptCheckedInPatients_ItemDataBound">
        <ItemTemplate>
            <tr id='<%# Eval("AppointmentsId")%>' class="tr-checkedin-Patients-main">
                <td>
                    <%# Eval("PatientName")%>

                    <input type="hidden" class="hdnCheckedInPatientsId" value='<%# Eval("CheckedInPatientsId")%>' />
                    <input type="hidden" class="hdnPracticeLocationsId" value='<%# Eval("PracticeLocationsId")%>' />
                    <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />

                    <div class="patient-info-icon-Master">
                        <span onclick="ShowHidePatientInfoDropDownMaster(this, event);" class="ui-icon ui-icon-info"></span>
                        <div onmouseleave="$(this).hide();" class="custom-dropdown-list-Master" style="display: none;">
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href="javascript:void(0);" onclick="ClickCheckedInPatientInfo(this, 'Demographics');">Demographics</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="javascript:void(0);" onclick="ClickCheckedInPatientInfo(this, 'LatestChart');">Recent Chart</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="javascript:void(0);" onclick="ClickCheckedInPatientInfo(this, 'Documents');">Documents</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="javascript:void(0);" onclick="ClickCheckedInPatientInfo(this, 'BalanceSheet');">Balance Sheet</a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </td>
                <td style="text-align:right;" class="tdArrivalTime">
                    <%# Eval("ArrivalTime")%>
                </td>
                <td>
                    <span class="span-checkinroom-Main"><%# Eval("RoomName")%></span>
                    <input class="hdnAppointmentsId-CheckInRoom" type="hidden" value='<%# Eval("AppointmentsId")%>'/>
                        <div class="practice-rooms-master">
                            <span onclick="ShowHidePracticeRoomsDropDownMaster(this, event);" class="ui-icon ui-icon-info"></span>
                            <div onmouseleave="$(this).hide();" class="custom-dropdown-list-Master div-Practice-Room-Master" style="display: none;">
                            <table>
                                <tbody>
                                    <asp:Repeater ID="rptPracticeRoomsMaster" runat="server">
                                        <ItemTemplate>
                                            <tr id='<%# Eval("RoomId")%>' onclick="updateCheckInRoomMaster(this)">
                                                <td>
                                                    <a class="linkRoomName"><%# Eval("Name")%></a>
                                                    <input type="hidden" class="hdnRoomId" value='<%# Eval("RoomId")%>'/>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </td>
                <td style="text-align:right;" class="tdCheckInTime">
                    <%# Eval("CheckInTime")%>
                </td>
                <td style="text-align:right;" class="tdTimeInRoom">
                    <span class="spnTimeInRoom"></span> (H:MM)
                </td>
                <td style="text-align:right;">
                    <span class="spnTimeInOffice"></span> (H:MM)
                </td>
                <td>
                    <span onclick="Walkout_LoadWalkoutForm(this);" style="cursor:pointer; color:blue; text-decoration:underline;">Walkout</span>
                    
                    <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                    <input type="hidden" class="hdnAppointmentsId" value='<%# Eval("AppointmentsId")%>' />
                    <input type="hidden" class="hdnAppointmentDate" value='<%# Eval("AppointmentDate")%>' />
                    <input type="hidden" class="hdnCheckedInPatientsId" value='<%# Eval("CheckedInPatientsId")%>' />
                    <input type="hidden" class="hdnRoomIdCheckedInPatientList" value='<%# Eval("RoomId")%>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <tr class="trNoRecord" style="display:none;">
        <td colspan="6">
            <div class="no-record-div" style="height:260px">No Checked In Patients!</div>
        </td>
    </tr>
    ###End###
    </div>
    </form>
</body>
</html>
