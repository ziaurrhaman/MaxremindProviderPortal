<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientSummaryHandler.aspx.cs" Inherits="HomeHealth_Patient_CallBacks_PatientSummaryHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartPatientSummary###
    <div class="PatientSummary">
        <div class="PatientImage">
            <img runat="server" id="imgPatientProfilePicture" />
        </div>
        <div class="PersonalInfo">
            <table border="0" cellpadding="0" cellspacing="0" style="font-size:14px;">
                <tr><td style="height:20px; font-weight:bold; padding-top:15px;"><asp:Label ID="lblPatientName" runat="server"></asp:Label></td></tr>
                <tr><td style="height:20px;"><asp:Label ID="lblDateOfBirth" runat="server"></asp:Label></td></tr>
                <tr><td style="height:20px;"><asp:Label ID="lblGender" runat="server"></asp:Label>, <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label></td></tr>
                <tr><td style="height:20px;">1234567890, 1234567890</td></tr>
                <tr><td style="height:20px;"><asp:Label ID="lblAddress" runat="server"></asp:Label></td></tr>
                <tr><td style="height:20px;"><b>Reason for Visit:</b> <asp:Label ID="lblReasonForVisit" runat="server"></asp:Label></td></tr>
            </table>
        </div>
    </div>
    ###EndPatientSummary###
    </form>
</body>
</html>
