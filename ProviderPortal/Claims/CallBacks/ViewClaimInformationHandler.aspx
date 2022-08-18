<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewClaimInformationHandler.aspx.cs" Inherits="HomeHealth_EpisodeClaims_CallBacks_ViewClaimInformationHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###Start###
    <div style="margin-top: 20px; float: left; width: 100%">
        <asp:Repeater ID="rptERAClaimPayments" runat="server" OnItemDataBound="rptERAClaimPayments_ItemDataBound">
            <HeaderTemplate>
                <div class="Widget">
                    <table class="Grid">
                        <tr>
                            <th colspan="5">
                                Claim Payments
                            </th>
                            <th colspan="7">
                                Procedure Payments
                            </th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <th>
                    </th>
                    <th>
                        ClaimNumber
                    </th>
                    <th>
                        Claim Charges
                    </th>
                    <th>
                        Claim Payments
                    </th>
                    <th>
                        Claim Adjustments
                    </th>
                    <th style="width: 150px;">
                        Service Date
                    </th>
                    <th style="width: 91px;">
                        Procedure
                    </th>
                    <th style="width: 108px;">
                        Control Number
                    </th>
                    <th style="width: 63px;">
                        Charges
                    </th>
                    <th style="width: 100px">
                        Allowed Amount
                    </th>
                    <th style="width: 90px;">
                        Payments
                    </th>
                    <th>
                        Adjustments
                    </th>
                </tr>
                <tr>
                    <td>
                        <input type="checkbox" id="<%# Eval("ClaimNumber") %>" />
                    </td>
                    <td>
                        <%# Eval("ClaimNumber") %>
                    </td>
                    <td>
                        <%# Eval("ClaimCharges","{0:c}") %>
                    </td>
                    <td>
                        <%# Eval("ClaimPayments","{0:c}") %>
                    </td>
                    <td>
                        <%# Eval("TotalAdjustments","{0:c}") %>
                    </td>
                    <td colspan="7" style="vertical-align: top; padding: 0 0">
                        <asp:Repeater ID="rptProcedurePayments" runat="server">
                            <HeaderTemplate>
                                <table cellspacing="0">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 141px">
                                        <%# Eval("ServiceStartDate","{0:d}") %>
                                        -
                                        <%# Eval("ServiceEndDate","{0:d}") %>
                                    </td>
                                    <td style="width: 83px">
                                        <%# Eval("ProcedureCode") %>
                                    </td>
                                    <td style="width: 100px">
                                        <%# Eval("LineItemControlNumber") %>
                                    </td>
                                    <td style="width: 55px">
                                        <%# Eval("ChargedAmount","{0:c}") %>
                                    </td>
                                    <td style="width: 92px;">
                                        <%# Eval("ServiceAllowedAmount","{0:c}") %>
                                    </td>
                                    <td style="width: 82px;">
                                        <%# Eval("PaidAmount","{0:c}") %>
                                    </td>
                                    <td>
                                        <%# Eval("TotalAdjustments","{0:c}") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table> </div>
                <input type="button" value="Post" onclick="PostPayment(this)" style="margin: 10px 0;
                    float: right" />
            </FooterTemplate>
        </asp:Repeater>
    </div>
    ###End###
    </form>
</body>
</html>
