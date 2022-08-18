<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterContractManagementDetailReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterContractManagementDetailReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
     <asp:Repeater ID="rptContractManagementDetail" runat="server" OnItemDataBound="rptContractManagementDetail_ItemDataBound">
         <ItemTemplate>
             <tr>
                 <td style="text-align: center;">
                     <%# Eval("RowNumber")%>
                 </td>
                 <td>
                     <%# Eval("servicedate")%>
                 </td>
                 <td>
                     <%# Eval("PostDate")%>
                 </td>
                 <td>
                     <%# Eval("PatientId")%>
                 </td>
                 <td>
                     <%# Eval("PatientName")%>
                 </td>
                 <td>
                     <%# Eval("Code")%>
                 </td>
                 <td style="white-space:normal !important">
                     <%# Eval("[Description]")%>
                 </td>
                 <td style="width: 8%;">
                     <%# Eval("Provider")%>
                 </td>
                 <td>
                     <%--<%# Eval("Charges")%>--%>
                     <asp:Label ID="lblCharges" runat="server"></asp:Label>
                 </td>
                 <td>
                     <%--<%# Eval("ActAllowed")%>--%>
                     <asp:Label ID="lblActAllowed" runat="server"></asp:Label>
                 </td>
             </tr>

         </ItemTemplate>


     </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnDateFrom" />
            <asp:HiddenField runat="server" ID="hdnDateTo" />
            <asp:HiddenField runat="server" ID="hdnPatId" />
            <asp:HiddenField runat="server" ID="hdnDateType" />
            <asp:HiddenField runat="server" ID="hdnProviderId" />
            <asp:HiddenField runat="server" ID="hdnPracticeLocationId" />
            <asp:HiddenField runat="server" ID="hdnPayerId" />
            <asp:HiddenField runat="server" ID="hdnProcedureCode" />
            ###End###
    
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###

        ###StartTotalCharges###
        <asp:Literal runat="server" ID="lblTotalCharges"></asp:Literal>
            ###EndTotalCharges###

                ###StartTotalActAllowed###
        <asp:Literal runat="server" ID="lblTotalActAllowed"></asp:Literal>
            ###EndTotalActAllowed###

        ###TimeSpanStart###
             <asp:Literal runat="server" ID="TimeSpan"></asp:Literal>
            ###TimeSpanEnd###
        </div>
    </form>
</body>
</html>
