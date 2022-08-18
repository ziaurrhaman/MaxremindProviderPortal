<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterChargesDetailReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterChargesDetailReport" %>

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
                        <%# Eval("PostDate")%>
                    </td>
                    <td>
                        <%# Eval("servicedate")%>
                    </td>
                    <td>
                        <%# Eval("PatientId")%>
                    </td>
                    <td style="width: 8%;">
                        <%# Eval("PatientName")%>
                    </td>
                    <td>
                        <%# Eval("Code")%>
                    </td>
                    <td>
                        <%# Eval("[Description]")%>
                    </td>
                    <td>
                        <%# Eval("RendProvider")%>
                    </td>
                    <td style="width: 6%;">
                        <%# Eval("Location")%>
                    </td>
                    <td>
                        <%--<%# Eval("ServiceUnits")%>--%>
                        <asp:Label ID="lblServiceUnits" runat="server"></asp:Label>
                    </td>
                    <td>
                       <%-- <%# Eval("TotalCharges")%>--%>
                       <asp:Label ID="lblTotalCharges" runat="server"></asp:Label>
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
