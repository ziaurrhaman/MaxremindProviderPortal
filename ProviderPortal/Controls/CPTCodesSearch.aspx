<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CPTCodesSearch.aspx.cs" Inherits="ProviderPortal_Controls_ICD9CodesSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartCPTSearch###
    <asp:Repeater ID="rptCPTCode" runat="server">
        <ItemTemplate>
            <tr style="cursor: pointer" onclick="SelectCPT(this);">
                <td class="cpt-code">
                    <%# Eval("CPTCode")%>
                </td>
                <td class="cpt-description">
                    <%# Eval("CPTdescription")%>
                </td>
                <td class="cpt-AverageFee">
                    <%# Eval("AverageFee") %>
                </td>
                <td style="display: none;">
                    <input class="LabTestId" value='<%# Eval("LabTestId") %>' type="hidden" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###EndCPTSearch###
    </form>
</body>
</html>
