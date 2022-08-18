<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ERAFilterHandler.aspx.cs" EnableViewState="false" Inherits="HomeHealth_EpisodeClaims_CallBacks_ERAFilterHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###Start###
        <asp:Repeater ID="rptERA" runat="server" OnItemDataBound="rptERA_ItemDataBound">
            <ItemTemplate>
                <tr id="<%# Eval("ERAMasterId") %>" class="DataRow">
                    <td>
                        <i>
                            <%# Eval("RowNumber") %></i>
                    </td>
                    <td id="<%# Eval("PaymentType") %>">
                        <%# Eval("PaymentType") %>
                    </td>
                    <td id="<%# Eval("PayerIdentifier") %>">
                        <%# Eval("PayerName") %>
                    </td>
                    <td>
                        <asp:Label ID="lblPaymentMethod" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <%# Eval("CheckNumber") %>
                    </td>
                    <td>
                        <%# Eval("CheckIssueDate", "{0:d}") %>
                    </td>
                    <td>
                        <%# Eval("PaymentAmount") %>
                    </td>
                    <td>
                        <%# Eval("PaymentPosted") %>
                    </td>
                    <td id="<%# Eval("Status") %>">
                        <%# Eval("Status") %>
                    </td>
                    <td>
                        <img src="../../Images/payment.png" style="cursor: pointer" onclick="showERAClaimPayments(<%# Eval("ERAMasterId") %>,this)" />
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
