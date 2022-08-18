<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterInsuranceCollectionDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterInsuranceCollectionDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
              <asp:Repeater ID="rptInsuranceCollectionDetail" runat="server" OnItemDataBound="rptInsuranceCollectionDetail_ItemDataBound">
                  <ItemTemplate>
                      <tr id="trClaimStatus" runat="server" style="display: none;">
                          <th id="thClaimStatus" runat="server" colspan="11">
                              <asp:Label ID="lblClaimStatus" runat="server"></asp:Label>
                          </th>
                      </tr>
                      <tr id="trPeriod" runat="server" style="display: none;">
                          <th id="thPeriod" runat="server" colspan="11">
                              <asp:Label ID="lblPeriod" runat="server"></asp:Label>
                          </th>
                      </tr>
                      <tr>
                          <td style="text-align: center;">
                              <%# Eval("RowNumber")%>
                          </td>
                          <td>
                              <%# Eval("ClaimId")%>
                          </td>
                          <td>
                              <%# Eval("PostDate")%>
                          </td>
                          <td>
                              <%# Eval("ServiceDate")%>
                          </td>
                          <td>
                              <%# Eval("[Procedure]")%>
                          </td>
                          <td>
                              <%# Eval("Patient")%>
                          </td>
                          <td>
                              <%-- <%# Eval("BilledTo")%>--%>
                              <asp:Label ID="lblBilledTo" runat="server"></asp:Label>
                              <asp:Label ID="lblTotalBilledTo" runat="server"></asp:Label>
                              <asp:Label ID="lblSubBilledTo" runat="server"></asp:Label>
                              <asp:Label ID="lblGrandBilledTo" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblAdcharges" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblPayment" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblARBalance" runat="server"></asp:Label>
                          </td>
                          <td>
                              <%# Eval("Age")%>
                          </td>
                      </tr>
                      <tr id="trLastClaimStatus" runat="server" style="display: none;">
                          <th id="thLastClaimStatus" runat="server" colspan="11">
                              <asp:Label ID="lblLastClaimStatus" runat="server"></asp:Label>
                          </th>
                      </tr>
                      <tr id="trLastPeriod" runat="server" style="display: none;">
                          <th id="thLastPeriod" runat="server" colspan="11">
                              <asp:Label ID="lblLastPeriod" runat="server"></asp:Label>
                          </th>
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
