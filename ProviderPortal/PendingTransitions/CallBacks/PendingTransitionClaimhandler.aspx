<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingTransitionClaimhandler.aspx.cs" Inherits="ProviderPortal_PendingTransitions_CallBacks_PendingTransitionClaimhandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


        <script type="text/javascript" src="../../Scripts/Rizwan/PendingTransition.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###StartPTLFilterClaim### 
    <asp:Repeater ID="rptClaims" runat="server"> <%--OnItemDataBound="rptClaims_ItemDataBound"--%>
        <ItemTemplate>
          <tr <%--onclick="PTLClaimDialog(' <%# Eval("ClaimId") %>');"--%> style="cursor: pointer;">
                <td>
                    <i><%# Eval("ROWNUMBER")%></i>
                </td>
                <td>
                    <span><%# Eval("ClaimId")%></span>
                    <input type="hidden" class="hdnClaimId" value='<%# Eval("ClaimId")%>' />
                    <input type="hidden" class="hdnPatientId" value='<%# Eval("PatientId")%>' />
                    <input type="hidden" class="hdnServiceDate" value='<%# Eval("ServiceDate")%>' />
                    <input type="hidden" class="hdnSubmissionStatusId" value='<%# Eval("SubmissionStatusId")%>' />
                </td>
                <td>
                    <%# Eval("PatientId")%>
                </td>
                <td>
                    <%# Eval("Name")%>
                </td>
                <td style="text-align: center;" >
                    <%# Eval("ServiceDate", "{0:d}")%>
                </td>
                <td style="text-align: center;">
                    <%# Eval("BillDate")%>
                </td>
                <td>
                 
                     <%# Eval("InsName")%>
                </td>
                <td style="white-space: nowrap;" >
                    <%# Eval("SubmissionStatus")%>
                </td>
                <td class="tdPTLReasons">
                    <span><%# Eval("Reason")%></span>
                   <%-- <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />--%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="hdnTotalRowsClaims" runat="server" />
    ###EndPTLFilterClaim###
    ###StartRowsCountClaim###
    <asp:Literal runat="server" ID="ltrlRowsCountClaim"></asp:Literal>
  
    ###EndRowsCountClaim###
    </div>
    </form>
</body>
</html>
