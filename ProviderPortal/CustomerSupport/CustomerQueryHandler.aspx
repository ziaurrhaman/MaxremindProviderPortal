<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerQueryHandler.aspx.cs" Inherits="ProviderPortal_CustomerSupport_CustomerQueryHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
       ###SHGrid###
        
           <asp:Repeater runat="server" ID="rpt_MainGrid" OnItemDataBound="rpt_MainGrid_ItemDataBound">
                                      <ItemTemplate>
                                           <tr class="searchTR">
                                             <td><%# Eval("RowNumber") %></td>
                                               <td class="text-center"><%# Eval("CustomerSupportQuryId") %></td>
                                             <td class="text-center"><%# Eval("Subject") %></td>
                                               <td class="text-center" title="">
                                                  <asp:Label runat="server" ID="Descriptions"></asp:Label>
                                             </td>
                                               
                                               <td class="text-center"><%# Eval("RequestDate","{0:d}") %></td>
                                             <td class="text-center"><%# Eval("StatusName") %></td>
                                             
                                               
                                             <%--<td class="text-center" title="<%# Eval("Response") %>">
                                                    <asp:Label runat="server" ID="lblAnswer"></asp:Label>
                                             </td>--%>
                                             
<%--                                               <td><%# Eval("ModifiedDate","{0:d}") %></td>--%>
                                            
                                              <td class="text-center removespace">
<%--              <span onclick="ViewQueryData(this,' <%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer" title="View Ticket"><span><img src="../../Images/view1.png"/></span></span>&nbsp;--%>
               <span onclick="GenerateTicket(' <%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer" title="Update Ticket"><span><i class="far fa-edit"></i></span></span>
               <span onclick="DeleteThisTicket('<%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer;"><i class="far fa-trash-alt"></i></span>
                                              </td>
                                         </tr>
                                     </ItemTemplate>
                                 </asp:Repeater>
      ###EHGrid###

            <%-- SUPPORT PAGE GRID --%>
            ###SPGrid###
             <asp:Repeater runat="server" ID="rpt_SPGrid" OnItemDataBound="rpt_SPGrid_ItemDataBound">
                                      <ItemTemplate>
                                           <tr class="searchTR">
                                             <td><%# Eval("RowNumber") %></td>
                                               <td class="text-center"><%# Eval("CustomerSupportQuryId") %></td>
                                             <td class="text-center"><%# Eval("Subject") %></td>
                                               <td class="text-center" title="">
                                                  <asp:Label runat="server" ID="Descriptions"></asp:Label>
                                             </td>
                                               
                                               <td class="text-center"><%# Eval("RequestDate","{0:d}") %></td>
                                             <td class="text-center"><asp:Label Text="" runat="server" ID="lblStatusId" /></td>
                                             
                                               
                                             <%--<td class="text-center" title="<%# Eval("Response") %>">
                                                    <asp:Label runat="server" ID="lblAnswer"></asp:Label>
                                             </td>--%>
                                             
<%--                                               <td><%# Eval("ModifiedDate","{0:d}") %></td>--%>
                                            
                                              <td class="text-center removespace">
<%--              <span onclick="ViewQueryData(this,' <%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer" title="View Ticket"><span><img src="../../Images/view1.png"/></span></span>&nbsp;--%>
               <span onclick="GenerateTicket(' <%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer" title="Update Ticket"><span><i class="far fa-edit"></i></span></span>
               <span onclick="DeleteThisTicket('<%# Eval("CustomerSupportQuryId") %>')" style="cursor:pointer;"><i class="far fa-trash-alt"></i></span>
                                              </td>
                                         </tr>
                                     </ItemTemplate>
                                 </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnTotalTicketsCount"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdnTotalTicketsClose"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdnTotalTicketsOpen"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdnTotalTicketsInProcess"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hdnTotalTicketsProviderReview"></asp:HiddenField>
            ###EPGrid###

     </div>
    </form>
</body>
</html>
