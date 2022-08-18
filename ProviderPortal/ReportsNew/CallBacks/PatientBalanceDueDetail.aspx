<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientBalanceDueDetail.aspx.cs" Inherits="EMR_ReportsNew_CallBacks_PatientBalanceDueDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
    ###Start###
    <div style="padding: 5px 0 15px; float: left; width: 100%;">
        <div style="margin: 10px 0 25px;">
            <table>
                <tbody>
                    <tr>
                        <td style="width: 110px;">
                            <span class="bold">Patient Account:</span>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblPatientAccountReport"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="bold">Patient:</span>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblPatientNameReport"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="bold">Address:</span>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblPatientAddressReport"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="bold">Contact:</span>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblPatientContactReport"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="Grid-Simple" style="max-height: 400px; overflow-y: auto;">
            <table>
                <thead>
                    <tr>
                        <th>
                            DOS
                        </th>
                        <th>
                            Service
                        </th>
                        <th>
                            Charges
                        </th>
                        <th>
                            Payment
                        </th>
                        <th>
                            Adjustment
                        </th>
                        <th>
                            Patient Paid
                        </th>
                        <th>
                            Balance Due
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rptClaimCharges">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <span class="spnDOS"><%#Eval("DOS")%></span>
                                </td>
                                <td>
                                    <span class="spnService"><%#Eval("Service")%></span>
                                </td>
                                <td>
                                    <span class="spnTotalCharges"><%#Eval("TotalCharges")%></span>
                                </td>
                                <td>
                                    <span class="spnPaidAmount"><%#Eval("PaidAmount")%></span>
                                </td>
                                <td>
                                    <span class="spnAdjustedAmount"><%#Eval("AdjustedAmount")%></span>
                                </td>
                                <td>
                                    <span class="spnPatPaidAmount"><%#Eval("PatPaidAmount")%></span>
                                </td>
                                <td>
                                    <span class="spnBalanceDue"><%#Eval("BalanceDue")%></span>

                                    <input type="hidden" class="hdnClaimId" value='<%#Eval("ClaimId") %>' />
                                    <input type="hidden" class="hdnClaimChargesId" value='<%#Eval("ClaimChargesId") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    ###End###
    </div>
    </form>
</body>
</html>
