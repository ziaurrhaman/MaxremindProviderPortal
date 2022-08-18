<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentFilterHandler.aspx.cs" Inherits="BillingManager_Payment_CallBacks_PaymentFilterHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div>
            ###StartClaimChecks###
    <asp:Repeater ID="rptClaimCheck" runat="server" OnItemDataBound="rptClaimCheck_ItemDataBound">

        <ItemTemplate>
            <tr id="<%# Eval("ERAMasterId") %>" class="DataRow">
                <td>
                    <i>
                        <%# Eval("RowNumber") %></i>
                </td>
               <%-- <td align="center">
                    <asp:CheckBox ID="cbClaimChecks" runat="server" CssClass="cbClaimChecks" onclick="change_ClaimCheck();" />
                </td>--%>
                <td class="tdCheckNumber">
                    <%# Eval("CheckNumber")%>
                </td>
             <td class="tdCheckDate DateCenter">
                                        <%# Eval("CheckDate", "{0:d}")%>
                                    </td>
                                       <td class="tdCheckAmount AmtRight">
                                        <%# Eval("CheckAmount", "{0:c}")%>
                                    </td>
                                     <td class="tdCheckDate DateCenter">
                                        <%# Eval("CreatedDate", "{0:d}")%>
                                    </td>
                                     <td class="tdCheckDate AmtRight">
                                        <%# Eval("PostedAmount", "{0:c}")%>
                                    </td>

                <td id="<%# Eval("InsuranceId") %>" class="tdInsurance">
                    <%# Eval("Insurance")%>
                </td>
                 <td style="text-align:center; cursor:pointer" class="hidetdclass" onclick=" CheckVerifyPopup( <%# Eval("ERAMasterId") %>);"  id="tdVerify" >
                                  
                <asp:Label ID="lblVerify" runat="server" Style="" >.</asp:Label>
                                 
               </td>
                <td style="text-align: center;" class="hidetdclass">
                    <span class="fa fa-print" title="Print" onclick="PrintCheckInfo(this);"
                        style="cursor: pointer;font-size: 16px; color: #006a99; margin-left: 7px; display: inline-block;"></span>
                    <span class="spanview" style="display:none;" title="View"></span>
                    <span class="spanedit" title="Edit" onclick="EditClaimCheck(this);"></span>
                    <span class="spandelete" title="Delete" onclick="DeleteClaimCheck(this);" style="margin-left: 5px;"></span>
                    <input type="hidden" class="hdnClaimCheckId" value='<%# Eval("ERAMasterId")%>' />
                    <input type="hidden" class="hdnInsuranceId" value='<%# Eval("InsuranceId")%>' />
                    <input type="hidden" class="hdnCheckAmount" value='<%#DataBinder.Eval(Container.DataItem, "CheckAmount","{0:0.00}")%>' />
                    <input type="hidden" class="hdnPostedAmount" value='<%#DataBinder.Eval(Container.DataItem, "PostedAmount","{0:0.00}")%>' />

                    <input type="hidden" class="hdnPatientId" value="<%#Eval("PatientId") %>" />
                    <input type="hidden" class="hdnPatient" value="<%#Eval("Patient") %>" />
                        <%-- Added by Rizwan kharal 3August2018 --%>
                     <input type="hidden" class="hdnPaymentType" value='<%#Eval("PaymentType") %>' />
                </td>
            </tr>
        </ItemTemplate>
   
    </asp:Repeater>
    <asp:HiddenField runat="server" ID="hdnchkamount" />
    <asp:HiddenField runat="server" ID="hdnpostamount" />
            ###EndClaimChecks###
    ###StartClaimChecksTotalRow###
    <asp:Literal ID="ltrTotalRow" runat="server"></asp:Literal>
            ###EndClaimChecksTotalRow###
    
    ###StartTotalPaymentsAgainstThisCheck###
    <asp:Literal runat="server" ID="ltrTotalPaymentsAgainstThisCheck" Text="0"></asp:Literal>
            ###EndTotalPaymentsAgainstThisCheck###
        </div>
    </form>
</body>
</html>
