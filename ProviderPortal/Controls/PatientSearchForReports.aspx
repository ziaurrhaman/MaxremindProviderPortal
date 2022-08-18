<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientSearchForReports.aspx.cs" Inherits="ProviderPortal_Controls_PatientSearchForReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      Start
    <div class="Grid" style="width: 99%;">
        <table id="PatientSerachtdBody">
            <thead>
                <tr>
                 
                    <th>
                        Patient
                    </th>
                </tr>
            </thead>
            <tbody id="">
                <asp:Repeater ID="rptPatientSearch" runat="server">
                    <ItemTemplate>
                        <tr  style="cursor: pointer;" onclick="SelectPatientId(this)" class="" >
                            <td class="hdnCode" style="display:none">
                                <%# Eval("PatientId")%>
                            </td>
                            <td class="hdnCode">
                                <%# Eval("Patient")%>
                            </td>
                         </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    End
    </form>
</body>
</html>
