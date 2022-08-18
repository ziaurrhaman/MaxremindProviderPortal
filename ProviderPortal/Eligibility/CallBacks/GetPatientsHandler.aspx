<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetPatientsHandler.aspx.cs" Inherits="ProviderPortal_Eligibility_CallBacks_GetPatientsHandler" %>

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
                        <tr style="cursor: pointer" onclick="GetPatientRow('<%# Eval("PatientId") %>','<%# Eval("LastName") %>','<%# Eval("FirstName") %>','<%# Eval("Gender") %>','<%# Eval("DateOfBirth", "{0:d}") %>','<%# Eval("PolicyNumber") %>','<%# Eval("InsuranceId") %>')">
                           <td>
                                <i><%# Eval("RowNumber") %></i>
                            </td>
                            <td>
                                <%# Eval("PatientId") %>
                            </td>
                            <td>
                                <%# Eval("LastName") %>
                            </td>
                            <td>
                                <%# Eval("FirstName") %>
                            </td>
                            <td>
                                <%# Eval("Gender") %>
                            </td>
                            <td>
                                <%# Eval("DateOfBirth", "{0:d}") %>
                            </td>
                           <td>
                                <%# Eval("name") %>
                            </td>
                           
                           
                        </tr>
                    </ItemTemplate>
            </asp:Repeater>
            ###End###
            ###StartPatientRowsCount###
            <asp:Literal runat="server" ID="ltrlPatientRowsCount"></asp:Literal>
            ###EndPatientRowsCount###
        </div>
    </form>
</body>
</html>
