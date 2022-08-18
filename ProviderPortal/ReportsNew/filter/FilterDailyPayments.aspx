<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterDailyPayments.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterDailyPayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###Start###
    <asp:Repeater ID="rptReportData" runat="server" OnItemDataBound="rptReportData_ItemDataBound">
        <ItemTemplate>
                  <tr>
                                                    <td style="text-align: center;">
                                                        <%# Eval("RowNumber")%>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblPaymentSource"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PayerName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentMethod")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("CheckNumber")%>
                                                    </td>   
                                                     <td>
                                                        <%# Eval("CheckIssueDate")%>
                                                    </td>  
                                                     <td>
                                                        <%# Eval("CreatedDate")%>
                                                    </td>   
                                                    <td>
                                                        <%# Eval("PaymentAmount")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PaymentType")%>
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
