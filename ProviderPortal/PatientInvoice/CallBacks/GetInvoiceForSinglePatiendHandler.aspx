<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetInvoiceForSinglePatiendHandler.aspx.cs" Inherits="ProviderPortal_PatientInvoice_CallBacks_GetInvoiceForSinglePatiendHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ###Start###
         <asp:HiddenField runat="server" ID="hdnPatientInvoicesCount" />
                        <asp:Repeater runat="server" ID="rptPatientInvoices">
                            <ItemTemplate>
                                <tr id="<%#Eval("PatientId") %>">
                                    <td>
                                        <%# Eval("RowNumber") %>
                                    </td>
                                    <td>
                                        <input type="checkbox" class="singleCheckbox" onclick="chkSingleCheckBox();"/>
                                    </td>
                                    <td>
                                        <%# Eval("PatientId") %>
                                    </td>
                                    <td>                                        
                                        <%# Eval("PatientName") %>
                                    </td>
                                    <td>                                        
                                       
                                    </td>
                                    <td>
                                        <%# Eval("TotalPendingAmount","{0:c}") %>
                                    </td>
                                    <%--<td>
                                        <%# Eval("C07") %>
                                    </td>
                                    <td>
                                        <%# Eval("C815") %>
                                    </td>
                                    <td>
                                        <%# Eval("C1621") %>
                                    </td>
                                    <td>
                                        <%# Eval("C22") %>
                                    </td>--%>
                                </tr>
                            </ItemTemplate>
                    </asp:Repeater>
        ###End###
    </div>
    </form>
</body>
</html>
