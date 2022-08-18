<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCQuickLaunchBar.ascx.cs" Inherits="HomeHealth_Controls_UCQuickLaunchBar" %>



<div class="quicklaunch ucquicklaunch">
    <asp:HyperLink ID="lnkReports" CssClass="btnAppointmentMain" runat="server" NavigateUrl="~/EMR/Reports/Report.aspx">
        <span class="button-left"></span>
        <span class="button-center">
            <span class="button-image sprite-home icon-appointment"></span>
            <span class="button-text">Reports</span>
            <span class="selected-icons"></span>
        </span>
        <span class="button-right"></span>
    </asp:HyperLink>
    <asp:HyperLink ID="lnkAppointment" CssClass="btnAppointmentMain" runat="server" NavigateUrl="~/EMR/Appointments/Appointments.aspx">
        <span class="button-left"></span>
        <span class="button-center">
            <span class="button-image sprite-home icon-appointment"></span>
            <span class="button-text">Appointments</span>
            <span class="selected-icons"></span>
        </span>
        <span class="button-right"></span>
    </asp:HyperLink>
    <asp:HyperLink ID="lnkDashboard" CssClass="btnDashboardMain" runat="server" NavigateUrl="~/EMR/Dashboards.aspx">
        <span class="button-left"></span>
        <span class="button-center">
            <span class="button-image sprite-home icon-dashboard"></span>
            <span class="button-text">Dashboard</span>
            <span class="selected-icons"></span>
        </span>
        <span class="button-right"></span>
    </asp:HyperLink>
    <asp:HyperLink ID="lnkSchedular" CssClass="btnSchedularMain" runat="server" NavigateUrl="~/EMR/Home.aspx">
        <span class="button-left"></span>
        <span class="button-center">
            <span class="button-image sprite-home icon-schedular"></span>
            <span class="button-text">Scheduler</span>
            <span class="selected-icons"></span>
        </span>
        <span class="button-right"></span>
    </asp:HyperLink>
    <asp:HyperLink ID="lnkPTL" CssClass="btnSchedularMain" runat="server" NavigateUrl="~/EMR/PTL.aspx">
        <span class="button-left"></span>
        <span class="button-center">
            <span class="button-image sprite-home icon-schedular"></span>
            <span class="button-text">
                PTL
            </span>
            <asp:Label runat="server" ID="lblPTLCount" CssClass="notification-text"></asp:Label>
            <span class="selected-icons"></span>
        </span>
        <span class="button-right"></span>
    </asp:HyperLink>
</div>