<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
        <asp:Repeater ID="rptPatientSummary" runat="server">
            <ItemTemplate>
         <tr>
             <td>
                 <%# Eval("Payer")%>
             </td>
             <td>
                 <%# Eval("TotalPatient")%>
             </td>
         </tr>
            </ItemTemplate>

        </asp:Repeater>
            ###End###
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
    <asp:HiddenField ID="hdntotal" runat="server" />
            ###EndTotal###
        </div>
    </form>
</body>
</html>
