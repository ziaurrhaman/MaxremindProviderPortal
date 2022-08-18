<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterMostCommonlyUsedDxCodes.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterMostCommonlyUsedDxCodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
    <asp:Repeater ID="rptReport" runat="server">
        <ItemTemplate>
            <tr>
                <td style="text-align: center;">
                    <%# Eval("RowNumber")%>
                </td>
                <td style="text-align: left;">
                    <%# Eval("DiagnosisCode")%>
                </td>
                <td style="text-align: left;">
                    <%# Eval("OfficialName")%>
                </td>
                <td style="text-align: center;">
                    <%# Eval("NoOfTimesUsed")%>
                </td>


            </tr>
        </ItemTemplate>
    </asp:Repeater>
            ###End###
            ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRow"></asp:Literal>
            ###EndTotal###
        </div>
    </form>
</body>
</html>
