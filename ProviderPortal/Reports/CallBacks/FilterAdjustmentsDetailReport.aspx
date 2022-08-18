<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterAdjustmentsDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterAdjustmentsDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            ###Start###
                            <asp:Repeater ID="rptAdjustmentsDetail" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                      <%--  <td>
                                            <%# Eval("claimid")%>
                                        </td>
                                        <td>
                                            <%# Eval("ClaimChargesId")%>
                                        </td>--%>
                                        <td>
                                            <%# Eval("PostDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("servicedate")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Procedure]")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                            <%# Eval("Location")%>
                                        </td>
                                        <td>
                                            <%# Eval("CodeDescriptions")%>
                                        </td>
                                        <td>
                                            <%# Eval("TotalCharges")%>
                                        </td>
                                        <td>
                                            <%# Eval("Adjustments")%>
                                        </td>
                                       <%-- <td>
                                            <%# Eval("AdjustedAmount")%>
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
