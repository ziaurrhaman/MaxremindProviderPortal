﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterTop10Procedure.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterTop10Procedure" %>

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
                <td style="text-align: center;">
                    <%# Eval("CPTCode")%>
                </td>
                <td>
                    <%# Eval("Shortdescription")%>
                </td>
                <td style="text-align: center;">
                    <%# Eval("CPTCOUNT")%>
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
