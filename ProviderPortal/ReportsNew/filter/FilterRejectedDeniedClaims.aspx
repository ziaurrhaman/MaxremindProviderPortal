<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterRejectedDeniedClaims.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterRejectedDeniedClaims" %>

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
                                        <td class="center">
                                            <%# Eval("RowNumber")%>
                                        </td>
                                        <td class="AlignString">
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td class="AlignString">
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td class="AlignString"> 
                                            <%# Eval("Claimid")%>
                                        </td>
                                        <td class="AlignDate">
                                            <%# Eval("DOS","{0:d}")%>  
                                        </td>
                                         
                                        <td class="AlignDate">
                                            <%# Eval("[CPTCode]")%>
                                        </td>

                                        
                                        <td class="AlignPayment">
                                            <%# Eval("Charges")%>
                                        </td>
                                          <td class="AlignDate">
                                            <%# Eval("[BilledAs]")%>
                                        </td>
                                        

                                        <td class="AlignString">
                                            <%# Eval("Payer")%>
                                        </td>
                                        <td class="AlignString">
                                            <%# Eval("CheckNumber")%>
                                         
                                        </td>
                                        <td class="AlignString"> 
                                            <%# Eval("PaymentType")%>
                                       
                                        </td>
                                           <td class="AlignString">
                                            <%# Eval("SubmissionStatus")%>  
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
