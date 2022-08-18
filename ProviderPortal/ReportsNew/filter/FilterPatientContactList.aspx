<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientContactList.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPatientContactList" %>

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
                    <%# Eval("PatientId")%>
                </td>
                <%--<td>
                    <%# Eval("LastName")%>
                </td>--%>
                <td>
                    <%# Eval("PatientName")%>
                </td>
                <td>
                    <%# Eval("[Address]")%>
                </td>
                <td>
                    <%# Eval("HomePhone")%>
                </td>
                <td>
                    <%# Eval("Mobile")%>
                </td>
                <td>
                    <%# Eval("Email")%> 
                </td>
                  <td>
                    <%# Eval("Provider")%> 
                </td>
            </tr>   
        </ItemTemplate>
    </asp:Repeater>
                <asp:HiddenField runat="server" ID="hdnDiagnosisCode" />
        <asp:HiddenField runat="server" ID="hdnActuvity" />
        <asp:HiddenField runat="server" ID="hdnProviderId" />
        <asp:HiddenField runat="server" ID="hdnPayerId" />
        <asp:HiddenField runat="server" ID="hdnGender" />
        <asp:HiddenField runat="server" ID="hdnDOB" />
        <asp:HiddenField runat="server" ID="hdnTimeSpan" />
        <asp:HiddenField runat="server" ID="hdnProcedureCode" />
    ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
    ###EndTotal###

    </div>
    </form>
</body>
</html>
