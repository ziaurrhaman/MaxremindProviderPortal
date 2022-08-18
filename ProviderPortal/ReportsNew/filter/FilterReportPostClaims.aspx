<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterReportPostClaims.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterReportPostClaims" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###startReport###
    <asp:Repeater runat="server" ID="rptpostlciam" OnItemDataBound="rptpostlciam_ItemDataBound">
        <ItemTemplate>
            <tr style="width: 140% !important">
                <td style="padding: 5px;">
                    <%# Eval("RowNumber")%>
                </td>
                <td>
                    <%# Eval("ClaimId")%>
                </td>
                <td>
                    <%# Eval("AccountNo")%>
                </td>
                <td>
                    <%# Eval("PatientName")%>
                </td>
                <td>
                    <%# Eval("DateOfBirth")%>
                </td>
                <td class="DOS">
                    <%# Eval("DOS")%>
                </td>

                <td style="text-align: right">
                    <%# Eval("Charges", "{0:c}")%>
                </td>
                <td style="text-align: right">
                    <%# Eval("Payments", "{0:c}")%>
                </td>
                <td style="text-align: right">
                    <%# Eval("AmountDue", "{0:c}")%>
                </td>
                <td>
                    <%# Eval("PrimarySubmissionStatus")%>
                </td>
                <td>
                    <%# Eval("FileName")%>
                </td>
                <td>
                    <%# Eval("Insurance")%>
                </td>
                <td>
                    <%# Eval("PolicyNumber")%>
                </td>
                <td>
                    <%# Eval("PlaceOfService")%>
                </td>
                <td>
                    <%# Eval("PostDate")%>
                </td>
                <td><%# Eval("SubmissionDate","{0:d}")%></td>
                <td>
                    <%# Eval("Location")%>
                </td>

                <td><%# Eval("ClaimStatus")%></td>

                <td class="proCode">
                    <asp:Label ID="lblProcedureCode" runat="server">"<%# Eval("ProcedureCode")%>"</asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
            ###endReport###
    


        </div>
    </form>
</body>
</html>
