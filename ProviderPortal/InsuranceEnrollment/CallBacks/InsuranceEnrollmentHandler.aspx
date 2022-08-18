<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsuranceEnrollmentHandler.aspx.cs" Inherits="ProviderPortal_InsuranceEnrollment_CallBacks_InsuranceEnrollmentHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###startInsuranceEnrollmentGird###
          <asp:Repeater runat="server" ID="rptInsuranceEnrollment" OnItemDataBound="rptInsuranceEnrollment_ItemDataBound">
                   <ItemTemplate>
                    <tr>
                        <td><%#Eval("RowNumber")%></td>
                        <td><%#Eval("PayerId")%></td>
                        <td class="tdInsuranceName"><%#Eval("InsuranceName")%></td>
                         <td title="<%#Eval("notes") %>"><span runat="server" id="spnclaimstatus" class="spnstatus"><%#Eval("ClaimStatus")%></span></td>
                        <td title="<%#Eval("notes") %>"><span runat="server" id="spnEligibilitystatus" class="spnstatus"><%#Eval("EligibilityStatus")%></span></td>
                        <td title="<%#Eval("notes") %>"><span runat="server" id="spnErastatus" class="spnstatus"><%#Eval("ERAStatus")%></span></td>
                        <%--<td>
                            <img src="../../Images/edit.png" style="cursor: pointer"  title="Edit" onclick="btnEditClick(this)"   alt="" />
                            <img src="../../Images/delete.png" style="cursor:pointer;" title="Delete" onclick="btnDeleteClick(this)" alt="" />
                        </td>--%>
                           <div style="display:none">
                             <span class="spnInsuranceEnrollmentId"> <%#Eval("InsuranceEnrollmentId")%></span>
                              <span class="spnInsuranceId"> <%#Eval("InsuranceId")%></span>
                               <span class="spnClaimStatusId"> <%#Eval("ClaimStatusId")%></span>
                               <span class="spnEligibilityStatusId"> <%#Eval("EligibilityStatusId")%></span>
                               <span class="spnERAStatusId"> <%#Eval("ERAStatusId")%></span>
                               <span class="spnnotes"> <%#Eval("notes")%></span>
                              
                           </div>        
                    </tr>
                       </ItemTemplate> 
                </asp:Repeater>
        ###EndInsuranceEnrollmentGird###
        ###StarttotalRows###
        <asp:HiddenField runat="server" ID="hdnTotalRows" />
        ###EndtotalRows###

    </div>
    </form>
</body>
</html>
