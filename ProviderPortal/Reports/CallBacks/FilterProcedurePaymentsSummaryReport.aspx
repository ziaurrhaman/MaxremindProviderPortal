<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterProcedurePaymentsSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterProcedurePaymentsSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
               <asp:Repeater ID="rptProcedurePaymentsSummary" runat="server">
                   <ItemTemplate>
                       <tr>
                           <td style="text-align: center;">
                               <%# Eval("RowNumber")%>
                           </td>
                           <td>
                               <%# Eval("Code")%>
                           </td>
                           <td>
                               <%# Eval("[Description]")%>
                           </td>
                           <td>
                               <%# Eval("Qty")%>
                           </td>
                           <td>
                               <%# Eval("AVGCharges")%>
                           </td>
                           <td>
                               <%# Eval("TotalCharges")%>
                           </td>
                           <td>
                               <%# Eval("AVGInsurancePmt")%>
                           </td>
                           <td>
                               <%# Eval("AVGPatientpmt")%>
                           </td>
                           <td>
                               <%# Eval("AVGAdjustments")%>
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
