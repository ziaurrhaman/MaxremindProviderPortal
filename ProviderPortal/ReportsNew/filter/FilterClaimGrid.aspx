<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterClaimGrid.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterClaimGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartAllClaims###
    <asp:Repeater ID="rptClaims" runat="server">
        <ItemTemplate>
            <tr onclick="loadClaimForReport('<%# Eval("ClaimId")%>')">
                <td style="text-align: center; cursor: pointer; color: #000;">
                    <%# Eval("ClaimId")%>
                </td>
                <td style="text-align: center; cursor: pointer; color: #000;">
                    <%# Eval("PatientId")%>
                </td>

                <td style="text-align: center; cursor: pointer; color: #000;">
                    <%# Eval("ServiceDate")%>
                </td>
                <td style="text-align: center; cursor: pointer; color: #000;">
                    <%# Eval("SubmissionStatus")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
            ###EndAllClaims###
        </div>
    </form>
</body>
</html>
