<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientClaims.aspx.cs" Inherits="EMR_Claims_CallBacks_PatientClaims" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###Start###
    <asp:Repeater ID="rptClaims" runat="server">
        <ItemTemplate>
            <tr>
                <td style="text-align: center; cursor:pointer; color: #000;" onclick="loadCreateClaimForm(this);">
                    <%# Eval("ClaimId")%>
                    
                    <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                    <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                    <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                    <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                </td>
                <td style="text-align: center; cursor:pointer; color: #000;" onclick="loadCreateClaimForm(this);">
                    <%# Eval("ServiceDate")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###End###

    ###StartAllClaims###
    <asp:Repeater ID="rptAllClaims" runat="server">
        <ItemTemplate>
            <tr>
                <td style="text-align: center; cursor:pointer; color: #000;" onclick="loadCreateClaimForm(this);">
                    <%# Eval("ClaimId")%>
                    
                    <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                    <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                    <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                    <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###EndAllClaims###
    </div>
    </form>
</body>
</html>
