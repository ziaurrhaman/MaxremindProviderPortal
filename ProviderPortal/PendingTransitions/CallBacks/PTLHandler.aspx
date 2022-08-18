<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PTLHandler.aspx.cs" Inherits="ProviderPortal_PendingTransitions_CallBacks_PTLHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

   
    <form id="form1" runat="server">
    <div>
    ###StartFormPatient###
       
    <div id="divPTLResonsFormPatient">
        <div>
            <h4>Reasons</h4>
            <div> 
                <ul>
                    <asp:Repeater runat="server" ID="rptPTLReasonsPatient">
                        <ItemTemplate>
                            <li>
                                <label>
                                    <input type="checkbox" id='chkPatientPTLReasonsId<%#Eval("PTLReasonsId") %>' class="chkReason" />
                                    <%#Eval("Reason")%>
                                    
                                    <input type="hidden" class="hdnPTLReasonsId" value='<%#Eval("PTLReasonsId") %>' />
                                </label>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <asp:HiddenField runat="server" ID="hdnPTLReasonsPatient" />
        </div>
        <div>
            <h4>Notes:</h4>
            <asp:TextBox runat="server" ID="txtPTLNotesPatient" TextMode="MultiLine" style="width: 98%; height: 100px;"></asp:TextBox>
        </div>
    </div>
    <div class="dialog-action-bar-bottom">
        <input type="button" class="popup-buttons popup-button-red" value="Close" onclick="PTL_CloseForm();" />
        <input type="button" class="popup-buttons popup-button-blue" value="Resolve PTL" onclick="PTL_ResolveStatusPatient();" />
        <input type="button" id="SavePatient" class="popup-buttons popup-button-blue" value="Save" onclick="PTL_Save_Patient();"/>
    </div>
    ###EndFormPatient###
    
    


    ###StartFormClaim###
    <div id="divPTLResonsFormClaim">
        <div>
            <h4>Reasons</h4>
            <div>
                <ul>
                    <asp:Repeater runat="server" ID="rptPTLReasonsClaim">
                        <ItemTemplate>
                            <li>
                                <label>
                                    <input type="checkbox" id='chkClaimPTLReasonsId<%#Eval("PTLReasonsId") %>' class="chkReason" />
                                    <%#Eval("Reason")%>
                                    
                                    <input type="hidden" class="hdnPTLReasonsId" value='<%#Eval("PTLReasonsId") %>' />
                                </label>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <asp:HiddenField runat="server" ID="hdnPTLReasonsClaim" />
        </div>
        <div>
            <h4>Notes:</h4>
            <asp:TextBox runat="server" ID="txtPTLNotesClaim" TextMode="MultiLine" style="width: 98%; height: 100px;"></asp:TextBox>
        </div>
    </div>
    <div class="dialog-action-bar-bottom">
        <input type="button" class="popup-buttons popup-button-red" value="Close" onclick="PTL_CloseForm();" />
        <input type="button" class="popup-buttons popup-button-blue" value="Resolve PTL" onclick="PTL_ResolveStatusClaim();" />
        <input type="button" class="popup-buttons popup-button-blue" value="Save" onclick="PTL_Save_Claim();" />
    </div>
    ###EndFormClaim###

 
        
 <%-- Claim Form After performing the any function on dialog --%>  
        
          <div>
     ###StartPTLClaim###
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
                    <%# Eval("PatientName")%>
                </td>
                <td style="text-align: center;" >
                    <%# Eval("ServiceDate", "{0:d}")%>
                </td>
                <td style="text-align: center;">
                    <%# Eval("BillDate")%>
                </td>
                <td>
                    <asp:Label ID="lblInsuranceName" runat="server"></asp:Label>
                </td>
                <td style="white-space: nowrap;" >
                    <%# Eval("SubmissionStatus")%>
                </td>
                <td class="tdPTLReasons">
                    <span><%# Eval("PTLReasons")%></span>
                    <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
         <asp:HiddenField ID="hdnTotalRowsClaims" runat="server" />
    ###EndPTLClaim###
    ###StartRowsCountClaim###
    <asp:Literal runat="server" ID="ltrlRowsCountClaim"></asp:Literal>
   
    ###EndRowsClaim###
    </div>
        
        <%-- End Claims --%>     

         <%-- Patient Form After performing the any function on dialog --%>  
      <div>
    ###StartPtlPatient###
    <asp:Repeater ID="rptPatients" runat="server">
        <ItemTemplate>
            <tr style="cursor: pointer" class="ptlid"  <%--onclick="PTLPatientDialog(' <%# Eval("PatientId") %>');--%>">
                <td><i><%# Eval("RowNumber") %></i></td>
                <td><%# Eval("PatientId") %></td>
                <td><%# Eval("LastName") %></td>
                <td><%# Eval("FirstName") %></td>
                <td><%# Eval("Gender") %></td>
                <td><%# Eval("DateOfBirth", "{0:d}") %></td>
                <td><%# Eval("Cell") %></td>
                <td><%# Eval("Address") %></td>
              <td class="tdPTLReasons">
                    <span><%# Eval("PTLReasons")%></span>
                    <input type="hidden" class="hdnPTLNotes" value='<%#Eval("PTLNotes") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
           <asp:HiddenField ID="hdnTotalRowsPatients" runat="server" />
    ###EndPTLPatient###
   
    ###StartPatientRowsCount###
    <asp:Literal runat="server" ID="ltrlPatientRowsCount"></asp:Literal>
    ###EndPatientRowsCount###
    </div>   
           <%-- End Patient --%>     
    </div>
    </form>
</body>
</html>
