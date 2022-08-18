<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterUnAppliedAnalysis.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterUnAppliedAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
            <asp:Repeater ID="rptUnappliedAnalysis" runat="server" OnItemDataBound="rptUnappliedAnalysis_ItemDataBound">
                
                <ItemTemplate>
                    <tr>
                    <td>
                        <%# Eval("[Transaction]")%>
                    </td>
                    <td>
                        <%# Eval("PostDate")%>
                    </td>
                    <td>
                        <%# Eval("PmtId")%>
                    </td>
                    <td>
                        <%# Eval("[Type]")%>
                    </td>
                    <td>
                        <%# Eval("Payer")%>
                    </td>
                    <td>
                        <%# Eval("ServiceDate")%>
                    </td>
                    <td>
                        <asp:Label ID="lblClaimId" runat="server" Style="font-weight: bold;"></asp:Label>
                    </td>
                    <td>
                        <%# Eval("PatientName")%>
                    </td>
                    <td>
                        <asp:Label ID="lblAmt" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUnappliedBalance" runat="server"></asp:Label>
                    </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="9" style="border-top: 1px solid #CCC; border-right: 1px solid #CCC;">
                            <sapn style="float: right;">Change in Unaplied Ballance</sapn></td>
                        <td style="border-top: 1px solid #CCC;" id="ChangeInUnapliedBallance">
                            <asp:Label ID="lblChangeInUnapliedBallance" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="9" style="font-weight: bold; border-top: 1px solid #CCC; border-right: 1px solid #CCC;">
                            <sapn style="float: right;">Ending Unapplied Ballance</sapn></td>
                        <td style="border-top: 1px solid #CCC;" id="EndingUnappliedBalance">
                            <asp:Label ID="lblEndingUnappliedBalance" runat="server"></asp:Label></td>
                    </tr>
                </FooterTemplate>
            </asp:Repeater>
            
             <input type="hidden" id="hdnPaymentType" runat="server" value="0" />
             <input type="hidden" id="hdnDateFrom" runat="server" value="0" />
             <input type="hidden" id="hdnDateTo" runat="server" value="0" />
             <input type="hidden" id="hdnInsuranceId" runat="server" value="0" />

            ###End###

                ###StartTotal###
      <asp:Label runat="server" ID="ltrTotalRows"></asp:Label>

            ###EndTotal###

            ###StartBeginingUnappliedBalance###
        <asp:Label runat="server" ID="lblBeginingUnappliedBalance"></asp:Label>
            ###EndBeginingUnappliedBalance###
            ###StartChangeUnapliedBallance###
        <asp:Label runat="server" ID="lblChangeInUnapliedBallance"></asp:Label>
            ###EndChangeUnapliedBallance###

                ###StartEndingUnappliedBalance###
        <asp:Label runat="server" ID="lblEndingUnappliedBalance"></asp:Label>
            ###EndEndingUnappliedBalance###
                         ###TimeSpanStart###
             <asp:Label runat="server" ID="TimeSpan"></asp:Label>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
