<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingSubmissionHandler.aspx.cs" Inherits="EMR_Claims_CallBacks_PendingSubmissionHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        #TotalRowsStart#
            <asp:Literal runat="server" ID="ltrlTotalRows"></asp:Literal>
        #TotalRowsEnd#

        #PendingSubmissionStart#
        <asp:Repeater runat="server" ID="rptPendingSubmissions">
            <ItemTemplate>
                <tr id="<%#Eval("InsuranceId") %>">
                    <td>
                        <%# Eval("RowNumber") %>
                    </td>
                    <td>
                        <input type="checkbox" />
                    </td>
                    <td>
                        <%# Eval("Name") %>
                    </td>
                    <td>
                        <%# Eval("PayerId837") %>
                    </td>
                    <td>
                        <%# Eval("TotalPendingClaims") %>
                    </td>
                    <td>
                        <%# Eval("C07") %>
                    </td>
                    <td>
                        <%# Eval("C815") %>
                    </td>
                    <td>
                        <%# Eval("C1621") %>
                    </td>
                    <td>
                        <%# Eval("C22") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        #PendingSubmissionEnd#
    
        </div>
    </form>
</body>
</html>
