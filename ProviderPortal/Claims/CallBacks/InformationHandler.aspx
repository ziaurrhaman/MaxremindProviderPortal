<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InformationHandler.aspx.cs" Inherits="HomeHealth_EpisodeClaims_CallBacks_InformationHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###StartERAClaimPayments###
        <div class="WidgetTitle">
            <span>Claim Payments</span>
        </div>
        <asp:Repeater ID="rptERAClaimPayments" runat="server" OnItemDataBound="rptERAClaimPayments_ItemDataBound">
            <HeaderTemplate>
                <table class="Grid">
                    <tr >
                        <th>
                            
                        </th>
                        <th>
                            Claim Number
                        </th>
                        <th>
                            Patient Name
                        </th>
                        <th>
                            Claim Charges
                        </th>
                        <th>
                            Claim Payments
                        </th>
                        <th>
                            Claim Status
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="ClaimRow" id="<%# Eval("ERAClaimPaymentsId") %>">
                    <td>
                        <input id="chkSelect" type="checkbox" />    
                    </td>
                    <td>
                        <%# Eval("ClaimNumber") %>
                    </td>
                    <td>
                        <%# Eval("PatientFirstName") %>
                        <%# Eval("PatientLastName") %>
                    </td>
                    <td>
                        <%# Eval("ClaimCharges","{0:c}") %>
                    </td>
                    <td>
                        <%# Eval("ClaimPayments","{0:c}") %>
                    </td>
                    <td>
                        <asp:Label ID="lblClaimStatus" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div style="float: right; margin: 10px 0px;">
         <input id="btnViewClaims" onclick="viewClaims()" type="button" value="View Claims" />   
        </div>
        
        ###EndERAClaimPayments###
    </div>
    </form>
</body>
</html>
