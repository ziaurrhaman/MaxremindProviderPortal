<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterChargesSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterChargesSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
 ###Start###
    <asp:Repeater ID="rptReportData" runat="server"   OnItemDataBound="rptChargesSummary_ItemDataBound">
        <ItemTemplate>
   <tr>
               <td style="text-align: center;">
                   <%# Eval("RowNumber")%>
               </td>
               <td>
                   <%# Eval("Code")%>
               </td>
               <td>
                   <%--<%# Eval("Total")%>--%>
                   <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
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
