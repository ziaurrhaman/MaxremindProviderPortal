<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterContractManagementSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterContractManagementSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
              <asp:Repeater ID="rptContractManagementSummary" runat="server" OnItemDataBound="rptContractManagementSummary_ItemDataBound">
                  <ItemTemplate>
                      <tr>
                          <td style="text-align: center;">
                              <%# Eval("RowNumber")%>
                          </td>
                          <%-- <td>
                                            <%# Eval("InsuranceId")%>
                                        </td>--%>
                          <td>
                              <%# Eval("[Procedure]")%>
                          </td>
                          <td>
                              <%--<%# Eval("AllowedAmount")%>--%>
                              <asp:Label ID="lblAllowedAmount" runat="server"></asp:Label>
                          </td>
                          <td>
                              <%--<%# Eval("AVGPayment")%>--%>
                              <asp:Label ID="lblAVGPayment" runat="server"></asp:Label>
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
