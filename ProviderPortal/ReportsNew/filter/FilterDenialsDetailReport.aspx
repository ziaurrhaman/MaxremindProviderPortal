<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterDenialsDetailReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterDenialsDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
   ###Start###
    <asp:Repeater ID="rptDenialsDetail" runat="server" OnItemDataBound="rptDenialsDetail_ItemDataBound">
        <ItemTemplate>
                <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td style="width:7%;">
                                            <%# Eval("ClaimId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PostDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("DenialReason")%>
                                        </td>
                                        <td>
                                            <%# Eval("DOS")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Procedure]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                            <%# Eval("Location")%>
                                        </td>
                                        <td>
                                            <%# Eval("Insurance")%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDenied" runat="server"></asp:Label>
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
