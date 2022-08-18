<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientDemographics.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterPatientDemographics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
    <asp:Repeater ID="rptPatients" runat="server">
                           <ItemTemplate>
                               <tr style="cursor: pointer">

                                   <td class="ReportHide"><i><%# Eval("RowNumber") %></i></td>
                                     <td style="display: none" class="Report"><%# Eval("Practice") %>
                                   </td>
                                   <td class="ReportHide"><%# Eval("PatientId") %></td>

                                   <td class="ReportHide">
                                       <%# Eval("LastName") %>
                                   </td>
                                   <td class="ReportHide">
                                       <%# Eval("FirstName") %>
                                   </td>
                                   <td class="ReportHide">
                                       <%# Eval("DateOfBirth", "{0:d}") %>
                                   </td>

                                   <td class="ReportHide">
                                       <%# Eval("SSN") %></td>
                                   <td class="ReportHide">
                                       <%# Eval("Gender") %>
                                   </td>

                                   <td class="ReportHide">
                                       <%# Eval("Cell") %>
                                   </td>
                                   <td class="ReportHide">
                                       <%# Eval("Name") %>
                                   </td>
                                   <td class="ReportHide">
                                       <%# Eval("PolicyNumber") %>
                                   </td>
                                   <td class="ReportHide">
                                       <%# Eval("Address") %>
                                   </td>
                                   <td class="ReportHide">
                                       <%# Eval("City") %>
                                   </td>
                                   <td class="ReportHide">
                                       <%# Eval("State") %>
                                   </td>
                                   <td class="ReportHide">
                                       <%# Eval("Zip") %>
                                   </td> 
                                   <td style="display: none" class="Report"><%# Eval("Cell") %>
                                   </td>
                                   <td style="display: none" class="Report"><%# Eval("IsActive") %>
                                   </td>
                                   <td style="display: none" class="Report"><%# Eval("EmergencyContactName") %>
                                   </td>
                                   <td style="display: none" class="Report"><%# Eval("PolicyNumber") %></td>
                                   <td style="display: none" class="Report"><%# Eval("PriTerminationDate") %></td>
                                   <td style="display: none" class="Report"><%# Eval("PriTerminate") %></td>
                                   <td style="display: none" class="Report"><%# Eval("SecPayer") %></td>
                                   <td style="display: none" class="Report"><%# Eval("SecPollicyNo") %></td>
                                   <td style="display: none" class="Report"><%# Eval("SecTerminationDate") %></td>
                                   <td style="display: none" class="Report"><%# Eval("SecTerminate") %></td>
                               </tr>
                           </ItemTemplate>
                       </asp:Repeater>
                <input type="hidden" id="hdnStartDate" runat="server" />
                <input type="hidden" id="hdnEndDate" runat="server" />
                <input type="hidden" id="hdnInsuranceId" runat="server" />
                <input type="hidden" id="hdnGender" runat="server" />
            ###End###

    ###StartTotal###
    <asp:Literal runat="server" ID="hdnTotalRows"></asp:Literal>
            ###EndTotal###

            
             ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
