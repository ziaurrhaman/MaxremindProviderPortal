<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewPatientInsuranceSearchHandler.aspx.cs" Inherits="ProviderPortal_Controls_CallBacks_NewPatientInsuranceSearchHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###SearchInsuranceResult###
            <asp:Repeater ID="rptInsuranceSearch" runat="server">
                <ItemTemplate>
                    <tr style="cursor: pointer" onclick="GetInsuranceNameNewPatient(this)">
                        <td>
                            <i>
                                <%# Eval("RowNumber") %></i>
                        </td>
                        <td id='<%# Eval("ID") %>' class="insuranceName">
                            <%# Eval("Name") %>
                        </td>
                        <td>
                            <%# Eval("City") %>
                        </td>
                        <td>
                            <%# Eval("State") %>
                        </td>
                        <td>
                            <%# Eval("Zip") %>
                        </td>
                        <td>
                            <%# Eval("Email") %>
                        </td>
                        <td>
                            <%# Eval("Phone") %>
                        </td>
                        <td>
                            <%# Eval("Fax") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="cursor: pointer" class="alternatingRow" onclick="GetInsuranceNameNewPatient(this)">
                        <td>
                            <i>
                                <%# Eval("RowNumber") %></i>
                        </td>
                        <td id='<%# Eval("ID") %>' class="insuranceName">
                            <%# Eval("Name") %>
                        </td>
                        <td>
                            <%# Eval("City") %>
                        </td>
                        <td>
                            <%# Eval("State") %>
                        </td>
                        <td>
                            <%# Eval("Zip") %>
                        </td>
                        <td>
                            <%# Eval("Email") %>
                        </td>
                        <td>
                            <%# Eval("Phone") %>
                        </td>
                        <td>
                            <%# Eval("Fax") %>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
        ###EndInsuranceResult###
    
        ###StartInsuranceRowsCount###
            <asp:Literal runat="server" ID="ltrlInsuranceRowsCount"></asp:Literal>
        ###EndInsuranceRowsCount###
    </div>
    </form>
</body>
</html>
