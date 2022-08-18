<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterItemizationOfCharges.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterItemizationOfCharges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
            ###Start###
        <asp:Repeater ID="rptItemizationOfCharges" runat="server" OnItemDataBound="rptItemizationOfCharges_ItemDataBound" >
               <ItemTemplate>
                             <tr>
                                        <td style="text-align: center;">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td>
                                            <%# Eval("[Visit #]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Patient")%>
                                        </td>
                                   <td style="text-align: center;">
                                            <%# Eval("Provider")%>
                                        </td>
                                        <td>
                                            <%# Eval("DOS","{0:d}")%>
                                        </td>
                                        <td>
                                            <%# Eval("[PostDate]","{0:d}")%>
                                        </td>
                                                <td>
                                            <%# Eval("CPTcode")%>
                                        </td>
                                        <td>
                                            <%# Eval("CPTdescription")%>
                                        </td>
                                       
                                        <td>
                                           <%-- <%# Eval("Charges")%>--%>
                                          <asp:Label ID="lblCharges" runat="server"></asp:Label>
                                        </td>
                                          <td>
                                          <%--  <%# Eval("Adjustments")%>--%>
                                           <asp:Label ID="lblAdjustments" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                          <%--  <%# Eval("[Payment]")%>--%>
                                              <asp:Label ID="lblPayment" runat="server"></asp:Label>
                                        </td>
                                         <td>
                                       <%--     <%# Eval("Balance")%>--%>
                                         <asp:Label ID="lblBalance" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                         
                                        <tr runat="server">
                                            <td style="border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-right:none; border-top:1px solid #C4C4C4;"></td>
                                            <td style="border-left:none; border-top:1px solid #C4C4C4;font-weight:bold; float:right; width:100%;"><asp:Label ID="lblGranAverage" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalCharges" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalAdjustments" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalPayments" runat="server"></asp:Label></td>
                                            <td style="border-top:1px solid #C4C4C4;"><asp:Label ID="lblTotalBalance" runat="server"></asp:Label></td>
                                            </tr>
                                  
                               
                          
                                </FooterTemplate>
        </asp:Repeater>
            ###End###
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
        </div>
    </form>
</body>
</html>
