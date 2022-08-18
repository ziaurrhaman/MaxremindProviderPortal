<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostClaimHandler.aspx.cs" Inherits="ProviderPortal_SeprateReports_PostClaimReport_CallBacks_PostClaimHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startPostClaim###
              <div class="Grid">
        <table>
            <thead>
                <tr>
                    <th>
                        th1
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptPostClaim" runat="server">
                    <ItemTemplate>
            <tr>
                <td>
                   
                </td>
            </tr>
                        </ItemTemplate>
                </asp:Repeater>

           </tbody>
        </table>
    </div>
            ###endPostClaim###
        </div>
    </form>
</body>
</html>
