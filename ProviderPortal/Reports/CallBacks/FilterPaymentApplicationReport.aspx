<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPaymentApplicationReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPaymentApplicationReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server"> 
        <div>
            ###Start###
             <asp:Repeater ID="rptPaymentApplication" runat="server" OnItemDataBound="rptPaymentApplication_ItemDataBound">
                 <ItemTemplate>
                     <tr>
                         <td style="text-align: center;">
                             <%# Eval("RowNumber")%>
                         </td>
                         <td>
                             <%# Eval("CheckNumber")%>
                         </td>
                         <td>
                             <%# Eval("Patient")%>
                         </td>
                         <td>
                             <%# Eval("ClaimId")%>
                         </td>
                         <td>
                             <%# Eval("servicedate")%>
                         </td>
                         <td>
                             <%# Eval("ProcCode")%>
                         </td>
                         <td>
                             <%-- <%# Eval("PostDate")%>--%>
                             <asp:Label ID="lblPostDate" runat="server"></asp:Label>
                             <asp:Label ID="lblSubTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                             <asp:Label ID="lblChkGrandTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                             <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight:bold;"></asp:Label>
                         </td>
                         <td>
                             <%# Eval("OrigCharge")%>
                         </td>
                         <td>
                             <%# Eval("BalanceForward")%>
                         </td>
                        <%-- <td>
                             <%# Eval("AdjustmentCode")%>
                         </td>--%>
                         <td>
                             <%# Eval("Adjustment")%>
                         </td>
                         <td>
                             <%# Eval("Payment")%>
                         </td>
                         <td>
                             <%# Eval("Balance")%>
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
