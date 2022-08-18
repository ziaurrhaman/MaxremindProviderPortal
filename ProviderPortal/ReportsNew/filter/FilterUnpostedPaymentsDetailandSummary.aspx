<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterUnpostedPaymentsDetailandSummary.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterUnpostedPaymentsDetailandSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###StartsearchCheckNumber###
        <div class="Grid" style="height: 200px; overflow-y: scroll">
            <table>
                <tr>
                    <th>Check Number
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptERA1">
                    <ItemTemplate>
                        <tr onclick="selectchecknumber(this)" style="cursor: pointer">
                            <td>
                                <span class="spnchecknumber"><%# Eval("checknumber") %></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </table>
        </div>
            ###EndsearchCheckNumber###
                        ###StartsearchCheckNumberCus###
        <div class="Grid" style="height: 200px; overflow-y: scroll">
            <table>
                <tr>
                    <th>Check Number
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptERA1Customize">
                    <ItemTemplate>
                        <tr onclick="selectchecknumberCustomize(this)" style="cursor: pointer">
                            <td>
                                <span class="spnchecknumber"><%# Eval("checknumber") %></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </table>
        </div>
            ###EndsearchCheckNumberCus###

        ###StartFilterTotal###
                        <asp:Repeater runat="server" ID="rptUnpostedPayments">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 20%; padding-left: 10px">
                                        <span style="padding-left: 63px; color: blue; cursor: pointer; text-decoration: underline;" onclick="UnpostedPaymentDetail('<%#Eval("Payertype") %>',this)"><%#Eval("Payertype") %></span>
                                    </td>
                                    <td class="AlignDate NoofChecks">
                                        <%#Eval("NoOfChecks") %>
                                    </td>
                                    <td class="AlignDate tdunpostedpayment" style="padding-left: 45px; text-align: right !important;">$<%#Eval("UnpostedPmt","{0:0,0.00}") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
            ###EndFilterTotal###
        ###StartFilterDetails###
                                 <asp:Repeater runat="server" ID="rptCheckDetail">
                                     <ItemTemplate>
                                         <tr class="<%# Eval("Payertype") %>" style="display: none">
                                             <td class="center"><%# Eval("Row#") %></td>
                                             <td class="AlignDate"><%# Eval("CheckIssueDate") %></td>
                                             <td><%# Eval("CheckNumber") %></td>
                                             <td class="AlignString" style="width: 24%"><%# Eval("PayerName") %></td>
                                             <td class="AlignPayment">$<%# Eval("PaymentAmount","{0:0,0.00}") %></td>

                                             <td class="AlignPayment">$<%# Eval("PaymentPosted","{0:0,0.00}") %></td>
                                             <td class="AlignPayment">$<%# Eval("Unapplied","{0:0,0.00}") %></td>
                                             <td class="AlignDate"><%# Eval("PostDate") %></td>
                                         </tr>
                                     </ItemTemplate>
                                 </asp:Repeater>
            ###EndFilterDetails###
            ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
