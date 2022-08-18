<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPaymentsDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPaymentsDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
                <asp:Repeater ID="rptPaymentsDetail" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <%# Eval("RowNumber")%>
                            </td>
                            <td>
                                <%# Eval("PaymentId")%>
                            </td>
                            <td>
                                <%# Eval("PostDate")%>
                            </td>
                            <td>
                                <%# Eval("PayerName")%>
                            </td>
                            <td>
                                <%# Eval("PayeeName")%>
                            </td>
                            <td>
                                <%# Eval("[Amount]")%>
                            </td>
                            <td>
                                <%# Eval("Unapplied")%>
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
