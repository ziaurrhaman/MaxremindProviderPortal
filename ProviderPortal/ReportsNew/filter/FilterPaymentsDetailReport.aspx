<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPaymentsDetailReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPaymentsDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
          <asp:Repeater ID="rptReportData" runat="server">
              <ItemTemplate>
                  <tr>
                      <td style="text-align: center;">
                          <%# Eval("RowNumber")%>
                      </td>
                      <td>
                          <%# Eval("PaymentId")%>
                      </td>
                      <td>
                          <%# Eval("PostDate")%>
                      </td>
                      <td>
                          <%# Eval("PayerName")%>
                      </td>
                      <td>
                          <%# Eval("PaymentType")%>
                      </td>
                      <td>
                          <%# Eval("[Amount]")%>
                      </td>
                      <td>
                          <%# Eval("Unapplied")%>
                      </td>
                  </tr>
              </ItemTemplate>
          </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnInsuranceID" />
            <asp:HiddenField runat="server" ID="hdnCheckNo" />
            <asp:HiddenField runat="server" ID="hdnPaymentType" />

            <asp:HiddenField runat="server" ID="hdnDateTo" />
            ###End###
         ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
        ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
                            ###StartCheckNumber###
          <asp:DropDownList ID="ddlCheckNumber" CssClass="ddlCheckNumber" runat="server" Style="float: left; width: 97%; margin-top: -0.8%;">
          </asp:DropDownList>
            ###EndCheckNumber###
        </div>
    </form>
</body>
</html>
