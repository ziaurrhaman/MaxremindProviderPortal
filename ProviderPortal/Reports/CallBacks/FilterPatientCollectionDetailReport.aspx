<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientCollectionDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientCollectionDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
             <asp:Repeater ID="rptPatientCollectionDetail" runat="server" OnItemDataBound="rptPatientCollectionDetail_ItemDataBound">
                 <ItemTemplate>
                     <tr>
                         <td style="text-align: center;">
                             <%# Eval("RowNumber")%>
                         </td>
                         <td>
                             <%# Eval("PatientId") %>
                         </td>
                         <td>
                             <%# Eval("LastName") %>
                         </td>
                         <td>
                             <%# Eval("FirstName") %>
                         </td>
                         <td>
                             <%# Eval("[Address]") %>
                         </td>
                         <td>
                             <%# Eval("Mobile") %>
                         </td>
                         <td>
                             <%# Eval("Email") %>
                         </td>
                         <td>
                             <asp:Label ID="lblBalanceOver90" runat="server"></asp:Label>
                         </td>
                         <td>
                             <asp:Label ID="lblTotalBalance" runat="server"></asp:Label>
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
