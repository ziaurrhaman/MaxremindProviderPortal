<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterThirtyPlusDaysAfterSubmission.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterThirtyPlusDaysAfterSubmission" %>

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
                                            <%# Eval("PatientId")%>
                                        </td>
                                        <td>
                                            <%# Eval("PatientName")%>
                                        </td>
                                        <td>
                                            <%# Eval("Claimid")%>
                                        </td>
                                        <td>
                                            <%# Eval("DateOfService","{0:d}")%>  
                                        </td>
                                         
                                        <td>
                                            <%# Eval("[Procedure]")%>
                                        </td>
                                        <td>
                                            <%# Eval("Charges")%>
                                        </td>
                                        <td style="">
                                            <%# Eval("Insurance")%>
                                        </td>

                                        <td>
                                            <%# Eval("Aging")%>
                                          <%--  <asp:Label ID="lblCharges" runat="server"></asp:Label>--%>
                                        </td>
                                       <td>
                                            <%# Eval("PostDate","{0:d}")%>  
                                        </td>
                                   <td>
                                            <%# Eval("Submissiondate","{0:d}")%>  
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
