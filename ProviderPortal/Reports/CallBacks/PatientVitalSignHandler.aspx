<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientVitalSignHandler.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_PatientVitalSignHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartPulse###
    <asp:HiddenField runat="server" ID="hdnTotalRowsPulse" />
    <asp:Repeater ID="rptPulse" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <i><%# Eval("ROWNUMBER")%></i>
                </td>
                <td>
                    <%# Eval("VisitDate")%>
                </td>
                <td>
                    <%# Eval("TimeIn")%>
                </td>
                <td>
                    <%# Eval("HeartRate")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###EndPulse###
    ###StartTemperature###
    <asp:HiddenField runat="server" ID="hdnTotalRowsTemperature" />
    <asp:Repeater ID="rptTemperature" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <i><%# Eval("ROWNUMBER")%></i>
                </td>
                <td>
                    <%# Eval("VisitDate")%>
                </td>
                <td>
                    <%# Eval("TimeIn")%>
                </td>
                <td>
                    <%# Eval("Temperature")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###EndTemperature###
    ###StartBloodPressure###
    <asp:HiddenField runat="server" ID="hdnTotalRowsBloodPressure" />
    <asp:Repeater ID="rptBloodPressure" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <i><%# Eval("ROWNUMBER")%></i>
                </td>
                <td>
                    <%# Eval("VisitDate")%>
                </td>
                <td>
                    <%# Eval("TimeIn")%>
                </td>
                <td>
                    <%# Eval("BP1Systolic")%>
                    /
                    <%# Eval("BP1Diastolic")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###EndBloodPressure###
    ###StartRespiratory###
    <asp:HiddenField runat="server" ID="hdnTotalRowsRespiratory" />
    <asp:Repeater ID="rptRespiratory" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <i><%# Eval("ROWNUMBER")%></i>
                </td>
                <td>
                    <%# Eval("VisitDate")%>
                </td>
                <td>
                    <%# Eval("TimeIn")%>
                </td>
                <td>
                    <%# Eval("RespirationRate")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###EndRespiratory###
    ###StartWeight###
    <asp:HiddenField runat="server" ID="hdnTotalRowsWeight" />
    <asp:Repeater ID="rptWeight" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <i><%# Eval("ROWNUMBER")%></i>
                </td>
                <td>
                    <%# Eval("VisitDate")%>
                </td>
                <td>
                    <%# Eval("TimeIn")%>
                </td>
                <td>
                    <%# Eval("Weight")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###EndWeight###
    </div>
    </form>
</body>
</html>
