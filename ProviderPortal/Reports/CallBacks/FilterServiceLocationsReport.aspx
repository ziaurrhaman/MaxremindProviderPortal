<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterServiceLocationsReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterServiceLocationsReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
                 <asp:Repeater ID="rptServiceLocations" runat="server">
                     <ItemTemplate>
                         <tr>
                             <td style="text-align: center;">
                                 <%# Eval("RowNumber")%>
                             </td>
                             <td>
                                 <%# Eval("Name")%>
                             </td>
                             <td>
                                 <%# Eval("BillingName")%>
                             </td>
                             <td>
                                 <%# Eval("PlaceOfService")%>
                             </td>
                             <td>
                                 <%# Eval("Address")%>
                             </td>
                             <td>
                                 <%# Eval("City")%>
                             </td>
                             <td>
                                 <%# Eval("StateCode")%>
                             </td>
                             <td>
                                 <%# Eval("Zip")%>
                             </td>
                             <td>
                                 <%# Eval("Phone")%>
                             </td>
                             <td>
                                 <%# Eval("FaxNo")%>
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
