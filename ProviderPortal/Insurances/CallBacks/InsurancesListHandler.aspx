<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsurancesListHandler.aspx.cs" Inherits="ProviderPortal_Insurances_CallBacks_InsurancesListHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      ###Start###
    <asp:Repeater ID="rptInsurances" runat="server">
        <ItemTemplate>
             <tr style="cursor: default">
                                <td style="color: #444 ">
                                    <%# Eval("RowNumber") %>
                                </td>
                                <td>
                                    <%# Eval("Name")%>
                                </td>
                                <td>
                                    <%# Eval("InsuranceType")%>
                                </td>
                                
                                <td>
                                    <%# Eval("City")%>
                                </td>
                                <td>
                                    <%# Eval("InsuranceStateName")%>
                                </td>
                                <td>
                                    <%# Eval("Email")%>
                                </td>
                                <td style="white-space: nowrap;" class="txtalign-cntr">
                                    <%# Eval("Phone1")%>
                                </td>
                               <td style="white-space: nowrap;"  class="txtalign-cntr">
                                    <%# Eval("Fax")%>
                                </td>
                                <td class="action" style="white-space:nowrap; text-align: center;display:none;">
                                    <asp:Label ID="lblAction" runat="server"></asp:Label>
                                </td>
                                <td style="display: none;">
                                    <%# Eval("TaxId")%>
                                    |
                                    <%# Eval("InsuranceType")%>
                                    |
                                    <%# Eval("InsuranceCategory")%>
                                    |
                                    <%# Eval("InsuranceCategoryId")%>
                                    |
                                    <%# Eval("Zip")%>
                                    |
                                    <%# Eval("Phone2")%>
                                    |
                                    <%# Eval("Phone3")%>
                                    |
                                    <%# Eval("InsuranceStateCode")%> 
                                    |
                                    <%# Eval("HeadOfficeAddress")%>
                                                                 
                                </td>
                                <td style="display:none;">
                                <asp:Label ID="lblPracticeId" Text='<%# Eval("PracticeId")%>' runat="server"></asp:Label>
                                <asp:Label ID="lblInsuranceId" Text='<%# Eval("InsuranceId")%>' runat="server"></asp:Label>                                
                                </td>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HiddenField runat="server" ID="hdnInsurancesTotalCount" />
    ###End###
    ###StartInsuranceRowsCount###
    <asp:Literal runat="server" ID="ltrlInsuranceRowsCount"></asp:Literal>
    ###EndInsuranceRowsCount###
    </div>
    </form>
</body>
</html>
