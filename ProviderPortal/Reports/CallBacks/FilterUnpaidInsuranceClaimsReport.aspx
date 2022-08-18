<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterUnpaidInsuranceClaimsReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterUnpaidInsuranceClaimsReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            ###Start###
            <asp:Repeater ID="rptUnpaidInsuranceClaims" runat="server" OnItemDataBound="rptUnpaidInsuranceClaims_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                       
                                        <td>
                                            <%# Eval("insurance")%>
                                        </td>
                                         <td>
                                            <%# Eval("Patient")%>
                                        </td>
                                        <td>
                                            <%# Eval("Encounter")%>
                                        </td>
                                        <td>
                                            <%# Eval("BillDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("ServiceDate")%>
                                        </td>
                                        <td>
                                            <%--<%# Eval("[Procedures]")%>--%>
                                            <asp:Label ID="lblProcedures" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <%# Eval("Diga1")%>
                                        </td>
                                        <td>
                                            <%# Eval("Diga1")%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                     <%--   <td>
                                            <asp:Label ID="lblAdjust" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblReceipts" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                        </td>--%>
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
