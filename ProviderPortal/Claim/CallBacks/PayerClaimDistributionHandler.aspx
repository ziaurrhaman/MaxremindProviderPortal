<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayerClaimDistributionHandler.aspx.cs" Inherits="ProviderPortal_Claim_CallBacks_PayerCalimDistributionHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###StartClaimChecks###
    <asp:Repeater ID="rptClaimSS" runat="server" >

                  <ItemTemplate>
                                <tr>
                                     
                                    <td class="">
                                        <%# Eval("RowNumber")%>
                                    </td>
                                    <td class="">
                                        <%# Eval("ClaimId")%>
                                    </td>
                                     <td class="">
                                        <%# Eval("Patient")%>
                                    </td>
                                    <td class="tdCheckDate">
                                        <%# Eval("DOS", "{0:d}")%>
                                    </td>
                                        <td class="tdCheckDate">
                                        <%# Eval("PostDate", "{0:d}")%>
                                    </td>
                                       <td class="tdCheckAmount">
                                        <%# Eval("Location")%>
                                    </td>
                                    <td class="tdCheckAmount">
                                        <%# Eval("BillingPhysician")%>
                                    </td>
                                    <td class="tdCheckAmount">
                                        <%# Eval("Name")%>
                                    </td>
                               
                                  
                                </tr>
                            </ItemTemplate>
   
    </asp:Repeater>
            ###EndClaimChecks###
    ###StartClaimChecksTotalRow###
    <asp:Literal ID="ltrTotalRow" runat="server"></asp:Literal>
        
            ###EndClaimChecksTotalRow###
    
    </div>
    </form>
</body>
</html>
