<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterDeductableReport.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterDeductableReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
   <asp:Repeater ID="rptDeductableReport" runat="server" OnItemDataBound="rptDeductableReport_ItemDataBound1">
       <ItemTemplate>
           <tr>
               <td style="text-align: center;">
                   <%# Eval("RowNumber")%>
               </td>
               <%-- <td>
                                                        <%# Eval("ClaimChargesId")%>
                                                    </td>--%>
               <td class="align_center">
                   <%# Eval("CptCode")%>
               </td>
               <td class="align_centre">
                   <%# Eval("ClaimId")%>
               </td>
               <td class="align_center">
                   <%# Eval("PatientId")%>
               </td>
               <td class="align_center">
                   <%# Eval("DOS")%>
               </td>
               <%--<td>
                                                        <%# Eval("CreatedDate")%>
                                                    </td>--%>
               <td title="<%# Eval("PrimaryInsurance")%>">
                   <asp:Label runat="server" ID="lblPriIns"></asp:Label>
               </td>
               <td>
                   <%# Eval("PriSubmissionStatus")%>
               </td>
               <td title="<%# Eval("SecondaryInsurance")%>">
                   <asp:Label runat="server" ID="lblsecins"></asp:Label>
               </td>
               <td>
                   <%# Eval("SecSubmissionStatus")%>
               </td>
               <td class="align_right">
                   <%# Eval("TotalCharges")%>
               </td>
               <td class="align_right">
                   <%# Eval("PaidAmount")%>
               </td>
               <td class="align_right">
                   <%# Eval("BalanceDue")%>
               </td>

               <td>
                   <%# Eval("CodeDescription").ToString().Substring(0,11)%>
               </td>
               <td class="align_right">
                   <%# Eval("AdjustedAmount")%>
               </td>

           </tr>
       </ItemTemplate>
   </asp:Repeater>

            <input type="hidden" id="hdnDateType" runat="server" value="0" />
            <input type="hidden" id="hdnStartDate" runat="server" value="0" />
            <input type="hidden" id="hdnEndDate" runat="server" value="0" />
            <input type="hidden" id="hdnPracticeLocationId" runat="server" />
            <input type="hidden" id="hdnProviderId" runat="server" />
            <input type="hidden" id="hdnInsuranceId" runat="server" />
            <input type="hidden" id="hdnInsuranceType" runat="server" />
            <input type="hidden" id="hdnPriClaimStatus" runat="server" />
            <input type="hidden" id="hdnSecClaimStatus" runat="server" />
            <input type="hidden" id="hdnReasonCode" runat="server" value="0" />

            ###End###

    ###StartTotal###
      <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>

            ###EndTotal###
            

            ###HoldStart###

    <tr style="width: 100%; background-color: #aadeff; font-weight: bold; font-size: smaller">

        <td>Deductible:  
                                    <asp:Label runat="server" ID="lblDeductible" Style="color: grey"></asp:Label></td>

        <td>Co Insurance:
                                    <asp:Label runat="server" ID="lblCoInsurance" Style="color: grey"></asp:Label></td>

        <td>Co Payment:
                                    <asp:Label runat="server" ID="lblCoPayment" Style="color: grey"></asp:Label></td>

        <td>Total PR:
                                    <asp:Label runat="server" ID="lblTotalPR" Style="color: grey"></asp:Label></td>

    </tr>


            ###HoldEnd###


             ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
