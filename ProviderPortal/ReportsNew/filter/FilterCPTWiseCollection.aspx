<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterCPTWiseCollection.aspx.cs" Inherits="ProviderPortal_ReportsNew_filter_FilterCPTWiseCollection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
        
                                    <asp:Repeater ID="Filtered" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="center"><%# Eval("RowNumber")%></td>
                                                <td class="center">
                                                    <%--<%# Eval("CPTCode")%>--%>
                                                    <%# Convert.ToString(Eval("CPTCode"))==""?"0":Eval("CPTCode")%>
                                                </td>
                                                <td class="center"><%#(Convert.ToString(Eval ("PatientCount")))==""?"0":(Eval("PatientCount"))%></td>
                                                <td class="center"><%#Convert.ToString(Eval("ClaimCount"))==""?"0":Eval("ClaimCount")%></td>
                                                <td class="AlignPayment"><%#(Convert.ToString(Eval ("Totalcharges"))==""?"$0.00":(Eval("Totalcharges","{0:c}")))%></td>
                                                <td class="AlignPayment"><%#(Convert.ToString(Eval ("BalanceDue")))==""?"$0.00":(Eval("BalanceDue","{0:c}"))%></td>
                                                <td class="AlignPayment"><%#(Convert.ToString(Eval ("Inprocess"))==""?"$0.00":(Eval("Inprocess","{0:c}")))%></td>  
                                                <td class="AlignPayment"><%#(Convert.ToString(Eval ("Payments"))==""?"$0.00":(Eval("Payments","{0:c}")))%></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                
            <input type="hidden" id="hdnPracticeLocationId" runat="server" />
            <input type="hidden" id="hdnclaimid" runat="server" />
            <input type="hidden" id="hdnProviderId" runat="server" />
            <input type="hidden" id="hdnCPTCode" runat="server" />
                    <asp:HiddenField ID="hdnPayer" runat="server" />
                    <asp:HiddenField ID="hdnDateFrom" runat="server" />
                    <asp:HiddenField ID="hdnDateTo" runat="server" />
                    <asp:HiddenField ID="hdnDateType" runat="server" />
            ###End###
            <script type="text/javascript">

            </script>
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
