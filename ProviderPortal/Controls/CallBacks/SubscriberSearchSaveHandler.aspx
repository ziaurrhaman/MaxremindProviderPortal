<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubscriberSearchSaveHandler.aspx.cs" Inherits="ProviderPortal_Controls_CallBacks_SubscriberSearchSaveHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###SubscriberListStart###
    <asp:Repeater ID="rptSubscriber" runat="server">
        <ItemTemplate>
            <tr onclick="PopulateSubscriberDetails(this);">
                <td>
                    <%# Eval("RowNumber") %>
                </td>
                <td>
                    <%# Eval("LastName") %>
                </td>
                <td>
                    <%# Eval("FirstName") %>
                </td>
                <td>
                    <%# Eval("Gender") %>
                </td>
                <td>
                    <%# Eval("DateOfBirth", "{0:d}") %>
                </td>
                <td>
                    <%# Eval("Address") %>,
                    <%# Eval("City") %>
                    <%# Eval("State") %>,
                    <%# Eval("Zip") %>
                        
                    <input type="hidden" class="hdnSubscriberId" value='<%# Eval("SubscriberId") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###SubscriberListEnd### 
    ###SubscriberListCountStart###
    <asp:Literal runat="server" ID="hdnSubscriberListCount" />
    ###SubscriberListCountEnd###
    </form>
</body>
</html>