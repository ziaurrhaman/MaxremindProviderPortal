<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPaymentApplicationReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPaymentApplicationReport" %>

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
            <tr id="checknumber" runat="server">
               
                <td style="font-weight:bold; padding-left: 50px !important;">
                    <%# Eval("CheckNumber")%>
                </td>
                </tr>
            <tr>
                 <%--<td style="text-align: center;">
                    <%# Eval("RowNumber")%>
                </td>--%> <td></td>
                <td style="padding-left: 40px !important; font-weight:bold;">
                     <asp:Label ID="patient_numbers" runat="server"></asp:Label>
                <%--    <%# Eval("Patient")%>--%>
                </td>
                <td>
                    <%# Eval("ClaimId")%>
                </td>
                <td>
                    <%# Eval("servicedate")%>
                </td>
                <td>
                    <%# Eval("ProcCode")%>
                </td>
                <td style="text-align: center;">
                    <%-- <%# Eval("PostDate")%>--%>
                    <asp:Label ID="lblPostDate" runat="server"></asp:Label>
                    <asp:Label ID="lblSubTotal" runat="server" Style="font-weight: bold;"></asp:Label>
                    <asp:Label ID="lblChkGrandTotal" runat="server" Style="font-weight: bold; "></asp:Label>
                    <asp:Label ID="lblGrandTotal" runat="server" Style="font-weight: bold;"></asp:Label>
                </td>
                <td>
                    <%# Eval("OrigCharge")%>
                </td>
                <td>
                    <%# Eval("BalanceForward")%>
                </td>
                <%--<td>
                             <%# Eval("AdjustmentCode")%>
                         </td>--%>
                <td>
                    <%# Eval("Adjustment")%>
                </td>
                <td>
                    <%# Eval("Payment")%>
                </td>
                <td>
                    <%# Eval("Balance")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
          <asp:HiddenField runat="server" ID="hdnPayerName" />
            <asp:HiddenField runat="server" ID="hdnCheckNumber" />
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnCheckNo" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###

                ###StartCheckNumber###
          <asp:DropDownList ID="ddlCheckNumber" CssClass="ddlCheckNumber" runat="server" Style="float: left; width: 97%; margin-top: -0.8%;">
          </asp:DropDownList>
            ###EndCheckNumber###
                 ###StartPostDate###
         <asp:DropDownList ID="ddlPostDate" CssClass="ddlPostDate" runat="server" Style="float: left; width: 97%; margin-top: -0.8%;">
         </asp:DropDownList>
            ###EndPostDate###
              ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
