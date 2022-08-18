<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPayerMixSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPayerMixSummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###Start###
    <asp:Repeater ID="rptReportData" runat="server" OnItemDataBound="rptReportData_ItemDataBound">
        <ItemTemplate>
                 <tr>
                          <td style="text-align: center;">
                              <%# Eval("RowNumber")%>
                          </td>
                          <td>
                              <%# Eval("PayerName")%>
                          </td>
                          <td>
                              <asp:Label ID="lblPatient" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblPtnt" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblEncounter" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblEncntrs" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblProcedure" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblProc" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblCharges" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblChrgs" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblReceipt" runat="server"></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblRcpts" runat="server"></asp:Label>
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
