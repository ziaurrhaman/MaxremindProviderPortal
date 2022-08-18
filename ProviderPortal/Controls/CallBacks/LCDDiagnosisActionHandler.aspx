<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCDDiagnosisActionHandler.aspx.cs" Inherits="ProviderPortal_Controls_CallBacks_LCDDiagnosisActionHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    ###StartLcdPolicies###
    <asp:Repeater runat="server" ID="rptLcds">
        <ItemTemplate>
            <li onclick="LCD_ClickLCD_DX(this);">
                <%#Eval("title")%>
                
                <input type="hidden" class="hdnLcdId" value='<%#Eval("lcd_id")%>' />
            </li>
        </ItemTemplate>
    </asp:Repeater>
    ###EndLcdPolicies###



    ###StartLcdTopDescription###
    <asp:Literal runat="server" ID="ltrTopDescription"></asp:Literal>
    ###EndLcdTopDescription###

    ###StartLcdTitle###
    <asp:Literal runat="server" ID="ltrLcdTitle"></asp:Literal>
    ###EndLcdTitle###

    ###StartLcdDates###
    <asp:Literal runat="server" ID="ltrLcdDates"></asp:Literal>
    ###EndLcdDates###

    ###StartPolicyDescription###
    <asp:Literal runat="server" ID="ltrPolicyDescription"></asp:Literal>
    ###EndPolicyDescription###

    ###StartProcedureSupported###
    <asp:Repeater runat="server" ID="rptProcedureSupported">
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("ProcedureSupported")%>
                </td>
                <td>
                    <%#Eval("Charges")%>
                </td>
                <td>
                    <%#Eval("paragraph")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    ###EndProcedureSupported###
    </div>
    </form>
</body>
</html>
