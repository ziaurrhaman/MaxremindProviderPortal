<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetZipCityState.aspx.cs" Inherits="ProviderPortal_Controls_GetZipCityState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
    #StartZipCityState#
    <div class="Grid">
        <table border="0" cellpadding="0" cellspacing="0">
            <asp:Repeater runat="server" ID="rptZipCityState">
                <ItemTemplate>
                    <tr style="cursor: pointer;" onclick="selectZipCityState('<%# Eval("ZipCode")%>','<%# Eval("City")%>','<%# Eval("State")%>');">
                        <td style="text-align:left;">
                            <%# Eval("ZipCode")%>
                            -
                            <%# Eval("City")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="cursor: pointer;" onclick="selectZipCityState('<%# Eval("ZipCode")%>','<%# Eval("City")%>','<%# Eval("State")%>');">
                        <td style="text-align:left;">
                        <%# Eval("ZipCode")%>
                        -
                        <%# Eval("City")%>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    #EndZipCityState#
    </form>
</body>
</html>
<script>

   

</script>