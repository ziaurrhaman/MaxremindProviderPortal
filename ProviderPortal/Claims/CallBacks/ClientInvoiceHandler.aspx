<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientInvoiceHandler.aspx.cs" Inherits="ProviderPortal_Claims_CallBacks_ClientInvoiceHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
        <asp:Repeater ID="rptGeneratedClientInvoices" runat="server">
            <ItemTemplate>
                <tr class="DataRow">
                    <td>
                        <i>
                            <%# Eval("RowNumber") %></i>
                    </td>

                    <%--<td class="singleCheckbox">
                                    <input type="checkbox" title='<%# Eval("CheckAmount") %>' name='<%# Eval("PaymentDate", "{0:d}") %>' class="clsContainer" value='<%# Eval("ERAMasterId") %>' />
                                </td>--%>
                    <td id="<%# Eval("PaymentType") %>">
                        <%# Eval("PaymentType") %>
                    </td>
                    <td id="<%# Eval("Insurance") %>">
                        <%# Eval("Insurance") %>
                    </td>
                    <td>
                        <%# Eval("PaymentMethodCode") %>
                    </td>
                    <td>
                        <span style="cursor: pointer; color: blue; border-bottom: 1px solid blue;" onclick="PrintCheckInvoiceInfo(this);"><%# Eval("CheckNumber") %></span>
                        <input type="hidden" class="hdnClaimCheckId" value='<%# Eval("ERAMasterId")%>' />
                    </td>
                    <td>
                        <%# Eval("PaymentDate", "{0:d}") %>
                        <%--<input type="hidden" class="hdnMaxDate" value='<%# Eval("MINDatefrom") %>' />
                                    <input type="hidden" class="hdnMinDate" value='<%# Eval("MaxDateTo") %>' />--%>
                    </td>
                    <td>
                        <%# Eval("CheckAmount","{0:c}") %>
                        <%-- <input type="hidden" class="hdnPaymentAmount" value='<%# Eval("CheckAmount") %>' />
                                    <input type="hidden" class="hdnTotalPayment" value='<%# Eval("TotalPayment") %>' />--%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
            ###End###
     ###StartERARowsCount###
    <asp:Literal runat="server" ID="ltrlERARowsCount"></asp:Literal>
            ###EndERARowsCount###
        </div>
    </form>
</body>
</html>
