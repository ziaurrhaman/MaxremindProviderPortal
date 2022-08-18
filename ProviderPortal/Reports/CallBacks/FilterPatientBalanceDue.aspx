<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientBalanceDue.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientBalanceDue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                    <%# Eval("TotalVisits")%>
                </td>
                <td>
                    <%# Eval("TotalClaims")%>
                </td>
                <td>
                    <%# Eval("Charges")%>
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
                <td style="display:none">
                    <%# Eval("BalanceDue")%>
                </td>
                <td class="action">
                    <div>
                        <span title="View" class="spneye" onclick="Report_ViewBalanceDueDetail(this);"></span>
                    </div>

                    <input type="hidden" class="hdnPatientId" value='<%#Eval("PatientId") %>' />
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
