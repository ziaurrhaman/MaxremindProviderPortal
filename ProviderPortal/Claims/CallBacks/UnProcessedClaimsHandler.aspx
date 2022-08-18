<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnProcessedClaimsHandler.aspx.cs" EnableSessionState="false" EnableViewState="false" Inherits="HomeHealth_EpisodeClaims_CallBacks_UnProcessedClaimsHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartUnProcessedClaimsHandler###
        <asp:Repeater ID="rptUnProcessedClaims" runat="server" OnItemDataBound="rptUnProcessedClaims_ItemDataBound">
                            <ItemTemplate>
                                <tr style="cursor: pointer">
                                    <td>
                                        <%# Eval("RowNumber") %>
                                    </td>
                                    <td>
                                        <input type="checkbox" />
                                    </td>
                                    <td>
                                        <%# Eval("PatientName")%>
                                    </td>                                  
                                    <td>
                                        <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                                    </td>                                                                     
                                    <td style="text-align: center;">
                                        <%# Eval("ClaimId")%>
                                    </td>
                                    <td>
                                        <%# Eval("TotalCharges")%>
                                    </td>
                                    <td style="display: none;">
                                        
                                            <span id="spnInsuranceId" runat="server">
                                                <%# Eval("InsuranceId")%></span>
                                                 <span id="spnPatientId" runat="server">
                                                    <%# Eval("PatientId")%></span> 
                                                    
                                                        <span id="spnClaimId" runat="server">
                                                            <%# Eval("ClaimId")%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
        <asp:HiddenField runat="server" ID="hdnUnProcessedClaimsCount" />        
        <asp:HiddenField runat="server" ID="hdnMsg" />        
        ###EndUnProcessedClaimsHandler###        
    </form>
</body>
</html>
