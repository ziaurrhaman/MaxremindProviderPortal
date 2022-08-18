<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPaymentsSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPaymentsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
               <asp:Repeater ID="rptPaymentsSummary" runat="server" OnItemDataBound="rptPaymentsSummary_ItemDataBound">
                   <ItemTemplate>
                       <tr>
                           <td>
                               <%# Eval("Payertype")%>
                           </td>
                           <td>
                               <%--<%# Eval("[Amount]")%>--%>
                               <asp:Label ID="lblAmount" runat="server"></asp:Label>
                           </td>
                           <td>
                               <%-- <%# Eval("Unapplied")%>--%>
                               <asp:Label ID="lblUnapplied" runat="server"></asp:Label>
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
