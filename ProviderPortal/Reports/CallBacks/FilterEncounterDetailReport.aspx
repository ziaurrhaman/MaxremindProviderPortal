<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterEncounterDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterEncounterDetailReport" %>

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
                                            <%# Eval("Patient")%>
                                        </td>
                                          <td>
                                            <%# Eval("DOS")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Rend Provider]")%>
                                        </td>
                                      
                                        <td>
                                            <%# Eval("[Procedure]")%>
                                        </td>
                                        <td>
                                            <%# Eval("[DxCode1]")%>
                                        </td>
                                        <td>
                                            <%# Eval("[DxCode2]")%>
                                        </td>
                                        <td>
                                            <%# Eval("TotalCharges")%>
                                        </td>
                                        <td>
                                            <%# Eval("AdjustedAmount")%>
                                        </td>
                                         <td>
                                            <%# Eval("Receipts")%>
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
