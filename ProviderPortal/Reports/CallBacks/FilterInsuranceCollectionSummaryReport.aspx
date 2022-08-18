<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterInsuranceCollectionSummaryReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterInsuranceCollectionSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
              <asp:Repeater ID="rptInsuranceCollectionSummary" runat="server" OnItemDataBound="rptInsuranceCollectionSummary_ItemDataBound">
                  <ItemTemplate>
                      <tr id="trClaimStatus" runat="server" style="display: none;">
                          <th id="thClaimStatus" runat="server" colspan="8">
                              <%--<asp:Label ID="lblClaimStatus" runat="server"></asp:Label>--%>
                          </th>
                      </tr>
                      <tr>
                          <td style="text-align: center;">
                              <%# Eval("RowNumber")%>
                          </td>
                          <td>
                              <asp:Label ID="lblClaimStatus" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblPeriod" runat="server"></asp:Label>
                              <asp:Label ID="lblTotalPeriod" runat="server"></asp:Label>
                              <asp:Label ID="lblGranTotalPeriod" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblEncounters" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblProcedures" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblValue" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblARBalance" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblPercentageOfAR" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblAge" runat="server"></asp:Label>
                          </td>
                      </tr>
                      <tr id="trLastClaimStatus" runat="server" style="display: none;">
                          <th id="thLastClaimStatus" runat="server" colspan="8">
                              <asp:Label ID="lblLastClaimStatus" runat="server"></asp:Label>
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
