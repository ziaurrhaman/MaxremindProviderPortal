<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimFilterHandler.aspx.cs"
    EnableSessionState="false" EnableViewState="false" Inherits="BillingManager_Claim_CallBacks_ClaimFilterHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###StartClaimFilterHandler###
        <asp:Repeater ID="rptClaims" runat="server" OnItemDataBound="rptClaims_ItemDataBound" >
            <ItemTemplate>
                <tr>
                    <td onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <i><%# Eval("ROWNUMBER")%></i>
                    </td>
                    <td>
                        <span onclick="loadCreateClaimForm(this);"><%# Eval("ClaimId")%></span>
                        <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                        <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                        <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                        <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                    </td>
                    <td onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <%# Eval("PatientId")%>
                    </td>
                    <td onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <%# Eval("PatientName")%>
                    </td>
                    <td style="text-align: center;cursor:pointer;" onclick="loadCreateClaimForm(this);" >
                        <%# Eval("ServiceDate", "{0:d}")%>
                    </td>
                    <td style="text-align: center;" onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <%# Eval("BillDate")%>
                    </td>
                    <td onclick="loadCreateClaimForm(this);" style="cursor:pointer;">
                        <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                    </td>
                    <td style="white-space: nowrap;cursor:pointer;" onclick="loadCreateClaimForm(this);" >
                        <%# Eval("SubmissionStatus")%>
                    </td>
                    <td align="center">
                        <asp:Label runat="server" ID="lblPTLReason"></asp:Label>
                    </td>
                    <td style="text-align: center;">
                        <asp:CheckBox runat="server" ID="chkPTL" Enabled="false" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hdnClaimsCount" runat="server" />
        ###EndClaimFilterHandler###
    </div>
    </form>
</body>
</html>
