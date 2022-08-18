<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientPayments.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPatientPayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###Start###
    <asp:Repeater ID="rptReportData" runat="server">
        <ItemTemplate>
                       <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentMethod")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PayerName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckNumber")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckIssueDate")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentAmount")%>
                                                    </td>
                                                     <td>
                                                        <%# Eval("PostDate")%>
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
