<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterEncounterSummaryReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterEncounterSummaryReport" %>

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
                                        <td style="width:7%;">
                                            <%# Eval("Encounters")%>
                                        </td>                                      
                                        <td>
                                            <%# Eval("[Rend Provider]")%>
                                        </td>
                                      
                                        <td>
                                            <%# Eval("[Procedures]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Charges")%>
                                        </td>
                                        <td>
                                            <%# Eval("Adjustments")%>
                                        </td>
                                         <td>
                                            <%# Eval("Receipts")%>
                                        </td>
                                        <td>
                                            <%# Eval("TotalBalance")%>
                                        </td>
                                       <%-- <td>
                                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDenied" runat="server"></asp:Label>
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
