<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientCollectionSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientCollectionSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
             <asp:Repeater ID="rptPatientCollectionSummary" runat="server" OnItemDataBound="rptPatientCollectionSummary_ItemDataBound">
                 <ItemTemplate>
                     <tr>
                         <td>
                             <asp:Label ID="lblCollectionCategory" runat="server"></asp:Label>
                         </td>
                         <td>
                             <%# Eval("NoOfPatients") %>
                         </td>
                         <td>
                             <asp:Label ID="lblUnbilled" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lblCurrent" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lbl3160" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lbl6190" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lbl91120" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lbl120" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lblTotalBal" runat="server"></asp:Label>
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
