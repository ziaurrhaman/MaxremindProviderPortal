<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterDenialsSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterDenialsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
            <asp:Repeater ID="rptDenialsSummary" runat="server" OnItemDataBound="rptDenialsSummary_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("RowNumber")%>
                        </td>
                        <td>
                            <%# Eval("DenialReason")%>
                        </td>
                        <td>
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            ###End###
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
    
    
        </div>
    </form>
</body>
</html>
