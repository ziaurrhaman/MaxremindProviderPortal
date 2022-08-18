<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterARAgingSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterARAgingSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
              <asp:Repeater ID="rptARAgingSummary" runat="server" OnItemDataBound="rptARAgingSummary_ItemDataBound">

                  <ItemTemplate>
                      <tr>
                          <td style="text-align: center;" id="tdPayer" runat="server">
                              <asp:Label ID="lblPayer" runat="server"></asp:Label>
                              <asp:Label ID="lblPecentage" runat="server"></asp:Label>
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
