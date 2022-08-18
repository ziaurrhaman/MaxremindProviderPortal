<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientClaims.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterPatientClaims" %>

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
                                                        <%# Eval("PatientName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("ClaimId")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DOS")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PrimaryInsurance")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("SubmissionStatus")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("InsurancePayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Adjustment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PatientPayment")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("BalanceDue")%>
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
