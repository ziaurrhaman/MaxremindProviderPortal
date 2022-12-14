<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterPatientVisits.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterPatientVisits" %>

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
                    <%# Eval("AppointmentDate")%>
                </td>
                <td>
                    <%# Eval("PATIENTID")%>
                </td>
                <td>
                    <%# Eval("PatientName")%>
                </td>
                <td>
                    <%# Eval("ClaimId")%>
                </td>
                    <td>
                    <%# Eval("ClaimTotal")%>
                </td>   
                <td>
                    <%# Eval("AmountPaid")%>
                </td> 
                <td>
                    <%# Eval("Adjustment")%>
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
