<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterLocationwisecollection.aspx.cs" Inherits="FilterLocationwisecollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
           
                     <asp:Repeater ID="rptReportDataTbody" runat="server">
                         <ItemTemplate>
                             <tr>
                                 <td class="center"><%# Eval("RowNumber")%></td>
                                 <td class="AlignDate">
                                     <%--<%# Eval("Name")%>--%>
                                     <%# Convert.ToString(Eval("Name"))==""?"0":Eval("Name")%>
                                 </td>
                                 <td class="AlignDate">
                                     <%-- <%# Eval("CLaimCount")%>--%>
                                     <%# Convert.ToString(Eval("CLaimCount"))==""?"0":Eval("CLaimCount")%>
                                 </td>
                                 <td class="AlignPayment">$<%#(Convert.ToString(Eval ("TotalCharges"))==""?"0.00":(Eval("TotalCharges","{0:F2}")))%>
                                 </td>
                                 <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("BalanceDue"))==""?"0.00":(Eval("BalanceDue","{0:F2}")))%>
                                 </td>
                                 <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("Inprocess"))==""?"0.00":(Eval("Inprocess","{0:F2}")))%>
                                 </td>
                                 <td class=" AlignPayment">$<%#(Convert.ToString(Eval ("Payments"))==""?"0.00":(Eval("Payments","{0:F2}")))%>
                                 </td>


                             </tr>
                         </ItemTemplate>

                     </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnLocation" />
            <asp:HiddenField runat="server" ID="hdnPayers" />
            <asp:HiddenField runat="server" ID="hdnProvider" />
            
            ###End###
             ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
             
            ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
