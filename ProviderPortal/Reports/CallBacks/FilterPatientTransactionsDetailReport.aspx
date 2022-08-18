<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientTransactionsDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientTransactionsDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            ###Start###
             <asp:Repeater ID="rptPatientTransactionsDetail" runat="server" OnItemDataBound="rptPatientTransactionsDetail_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                           <%# Eval("Patient") %>
                                        </td>
                                        <td>
                                            <%# Eval("PostDate") %>
                                        </td>
                                        <td>
                                            <%# Eval("ClaimId") %>
                                        </td>
                                        <td>
                                            <%# Eval("ProcedureCode") %>
                                        </td>
                                        <td>
                                            <%# Eval("DOS") %>
                                        </td>
                                        <td>
                                            <%# Eval("Provider") %>
                                        </td>
                                        <td>
                                            <%# Eval("Location") %>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPayment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                </asp:Repeater>
            ###End###
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
    
    </div>
    </form>
</body>
</html>
