<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientBalanceSheetHandler.aspx.cs"
    Inherits="EMR_Patient_CallBacks_PatientBalanceSheetHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###StartBalanceSheet###
        <div class="Grid" id="divBalanceSheet">
            <table>
                <thead>
                    <tr>
                        <th>
                            DOS
                        </th>
                        <th>
                            Amount Due
                        </th>
                        <th>
                            Payment
                        </th>
                    </tr>
                </thead>
                <tbody id="tbdyBalanceSheet">
                    <asp:Repeater ID="rptBalanceSheet" runat="server">
                        <ItemTemplate>
                            <tr style="cursor: default">
                                <td>
                                    <%# Eval("DOS")%>
                                </td>
                                <td>
                                    <asp:Label ID="lblAmountDue" runat="server" Text='<%# String.Format("{0:0.00}", Eval("RemainingBalance"))%>'></asp:Label>
                                </td>
                                <td>
                                    <span onclick="paymentClick(this,'<%# Eval("DOS")%>','<%# Eval("PatientId")%>')"
                                        style="color: Blue; cursor: pointer;">Payment</span>
                                    <div class="divHidenFields" style="display: none;">
                                        <input type="hidden" class="CashRegisterId" value='<%# Eval("CashRegisterId")%>' />
                                        <input type="hidden" class="PreviousBalance" value='<%#string.Format("{0:n2}", Eval("PreviousBalance"))%>' />
                                        <input type="hidden" class="PreviousBalancePayment" value='<%#string.Format("{0:n2}", Eval("PreviousBalancePayment"))%>' />
                                        <input type="hidden" class="VisitCharges" value='<%#string.Format("{0:n2}", Eval("VisitCharges"))%>' />
                                        <input type="hidden" class="VisitPayment" value='<%#string.Format("{0:n2}", Eval("VisitPayment"))%>' />
                                        <input type="hidden" class="OtherCharges" value='<%#string.Format("{0:n2}", Eval("OtherCharges"))%>' />
                                        <input type="hidden" class="OtherPayment" value='<%#string.Format("{0:n2}", Eval("OtherPayment"))%>' />
                                        <input type="hidden" class="CoPayDue" value='<%#string.Format("{0:n2}", Eval("CoPayDue"))%>' />
                                        <input type="hidden" class="rightOffAmount" value='<%#string.Format("{0:n2}", Eval("WriteOffAmount"))%>' />
                                        <input type="hidden" class="CoPayment" value='<%#string.Format("{0:n2}", Eval("CoPayment"))%>' />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        ###EndBalanceSheet### #StartCashRegisterDetails#
        <div id="divPaymentDetails">
            <div style="margin: 20px; width: 71%; float: left;">
                <span style="font-weight: bold;">Total Amount Due</span><span id="spnTotalAmountDue" style="margin-left: 10px;"></span>
                <span style="font-weight: bold; margin-left: 10px;">Total Amount Paid</span><span id="spnTotalPaid" style="margin-left: 10px;"></span>
                <span style="font-weight: bold; margin-left: 10px;">Write Off Amount</span> <span id="spnWriteOffAmount" style="margin-left: 10px;"></span>
                <span style="font-weight: bold;margin-left: 10px;">Remaining Balance</span> <span id="spnRemainingBalance" style="margin-left: 10px;">
                </span>
            </div>
            <div style="float: left; margin: 0 0 10px; width: 24%; text-align: right;">
                <input type="button" value="Pay" onclick="savePayment()" />
                <input type="button" value="Cancel" onclick="cancelPaymentDetails()" />
            </div>
            <div style="width:100%; float:left">
                <fieldset style="border: solid 1px #ddd; border-radius: 3px;">
                    <legend style="color: royalblue; font-weight: bold;">Cash Register Payments</legend>
                    <table class="tblCashRegister" style="line-height: 21px;">
                        <tr>
                            <td colspan="8" style="text-align: center; font-weight: bold; background-color: lightgray;">
                                Previous Balance
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 12%;">
                                Total Amount:
                            </td>
                            <td style="width: 15%;">
                                <span id="spnPreviousBalance" style="font-weight: bold;">0.00</span>
                            </td>
                            <td style="width: 12%;">
                                Amount Paid:
                            </td>
                            <td style="width: 15%;">
                                <span id="spnPreviousPaid" style="font-weight: bold;">0.00</span>
                            </td>
                            <td style="width: 12%;">
                                Amount Due:
                            </td>
                            <td style="width: 15%;">
                                <span id="spnPreviousBalanceDue" style="font-weight: bold;">0.00</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" style="text-align: center; font-weight: bold; background-color: lightgray;">
                                Visit Charges
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total Amount:
                            </td>
                            <td>
                                <span id="spnVisitCharges" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Amount Paid:
                            </td>
                            <td>
                                <span id="spnVisitChargesPaid" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Amount Due:
                            </td>
                            <td>
                                <span id="spnVisitChargesDue" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Pay:
                            </td>
                            <td>
                                <input type="text" id="txtVisitChargesPay" onkeyup="cashRegisterPaymentAdded('txtVisitChargesPay','spnVisitChargesDue')"
                                    style="width: 95%;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" style="text-align: center; font-weight: bold; background-color: lightgray;">
                                Co Pay
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total Amount:
                            </td>
                            <td>
                                <span id="spnCoPay" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Amount Paid:
                            </td>
                            <td>
                                <span id="spnCoPayPaid" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Amount Due:
                            </td>
                            <td>
                                <span id="spnCoPayDue" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Pay:
                            </td>
                            <td>
                                <input type="text" id="txtCoPayPay" onkeyup="cashRegisterPaymentAdded('txtCoPayPay','spnCoPayDue')"
                                    style="width: 95%;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" style="text-align: center; font-weight: bold; background-color: lightgray;">
                                Other Charges
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total Amount:
                            </td>
                            <td>
                                <span id="spnOtherCharges" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Amount Paid:
                            </td>
                            <td>
                                <span id="spnOtherChargesPaid" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Amount Due:
                            </td>
                            <td>
                                <span id="spnOtherChargesDue" style="font-weight: bold;">0.00</span>
                            </td>
                            <td>
                                Pay:
                            </td>
                            <td>
                                <input type="text" id="txtOtherChargesPay" onkeyup="cashRegisterPaymentAdded('txtOtherChargesPay','spnOtherChargesDue')"
                                    style="width: 95%;" />
                            </td>
                        </tr>
                        <tr style="background-color: lightgray; font-weight: bold;">
                            <td>
                                Total
                            </td>
                            <td>
                                <span id="spnTotalAmountCashRegister">0.00</span>
                            </td>
                            <td>
                            </td>
                            <td>
                                <span id="spnTotalPaidCashRegister">0.00</span>
                            </td>
                            <td>
                            </td>
                            <td>
                                <span id="spnTotalRemainingCashRegister">0.00</span>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset style="border: solid 1px #ddd; border-radius: 3px; margin-top: 20px;">
                    <legend style="color: royalblue; font-weight: bold;">Claims Payments</legend>
                    <div class="Grid">
                        <table>
                            <thead>
                                <tr>
                                    <th style="width: 10%;">
                                        Claim Id
                                    </th>
                                    <th style="width: 16%;">
                                        Total Charges
                                    </th>
                                    <th style="width: 16%;">
                                        Insurance Paid
                                    </th>
                                    <th style="width: 16%;">
                                        Patient Paid
                                    </th>
                                    <th style="width: 16%;">
                                        Amount Due
                                    </th>
                                    <th>
                                        Pay
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="tbodyClaimsList">
                                <asp:Repeater ID="rptClaims" runat="server" OnItemDataBound="rptClaims_ItemDataBound">
                                    <ItemTemplate>
                                        <tr style="cursor: default" class="trClaimPayment">
                                            <td>
                                                <%# Eval("ClaimId")%>
                                            </td>
                                            <td>
                                                <%#string.Format("{0:n2}", Eval("ClaimTotalCharges"))%>
                                            </td>
                                            <td>
                                                <%#string.Format("{0:n2}", Eval("ClaimPaidAmount"))%>
                                            </td>
                                            <td class="patientPaidAmmount">
                                                <%#string.Format("{0:n2}", Eval("PatientPaidAmmount"))%>
                                            </td>
                                            <td class="amountDue">
                                                <asp:Literal ID="ltrAmountDue" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <input type="text" class="amountPay" onkeyup="claimPaymentAdded(this)" />
                                                <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr id="trFooter" style="font-weight: bold; border-top: solid 1px #999; background: #f5f5f5;
                                            display: none;">
                                            <td>
                                                Total
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTotalCharges" runat="server" Text="0.00"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInsurancePaid" runat="server" Text="0.00"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPatientPaid" runat="server" Text="0.00"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAmountDue" runat="server" Text="0.00"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr id="trNoRecord" style="display: none;">
                                            <td colspan="6" style="text-align: center;">
                                                <asp:Label Text="No Record Found" ID="lblNoRecord" runat="server" Style="color: red;
                                                    font-size: 13px; font-weight: bold; font-style: italic;"></asp:Label>
                                            </td>
                                        </tr>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </fieldset>
            
                <input type="hidden" id="hdnClaimTotalDue" runat="server" />
                <input type="hidden" id="hdnClaimTotalPaid" runat="server" />
                <input type="hidden" id="hdnPatientTotalPaid" runat="server" />
            </div>
        </div>
        #EndCashRegisterDetails#
    </div>
    </form>
</body>
</html>
