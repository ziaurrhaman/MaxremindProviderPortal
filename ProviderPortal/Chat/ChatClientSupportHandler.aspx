<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChatClientSupportHandler.aspx.cs" Inherits="ProviderPortal_Chat_ChatClientSupportHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             ###StartChat###

                <asp:Repeater runat="server" ID="rpt">
        <ItemTemplate>
            <tr>
                <td><%# Eval("UserId") %></td>
                <td><%# Eval("Message") %></td>
               

            </tr>


        </ItemTemplate>
        
        </asp:Repeater>

            ###EndChat###

        </div>
    </form>
</body>
</html>
