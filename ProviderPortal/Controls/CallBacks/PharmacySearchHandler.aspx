<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PharmacySearchHandler.aspx.cs" Inherits="ProviderPortal_Controls_CallBacks_PharmacySearchHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ###StartPharmacyFilter###
    <asp:Repeater ID="rptPharmacy" runat="server">
        <ItemTemplate>
            <tr id='<%# Eval("NCPDP") %>' style="cursor: pointer" ondblclick="SelectPharmacy(this)">
                <td>
                    <i>
                        <%# Eval("RowNumber") %></i>
                </td>
                <td id="Name">
                    <%# Eval("StoreName") %>
                </td>
                <td id="Address">
                    <%# Eval("Address") %>
                </td>
                <td id="City">
                    <%# Eval("City") %>
                </td>
                <td id="State">
                    <%# Eval("StateName") %>
                </td>
                <td id="Zip">
                    <%# Eval("Zip") %>
                </td>
                <td id="Phone">
                    <%# Eval("Phone") %>
                </td>
                <td id="Fax">
                    <%# Eval("Fax") %>
                </td>
                <td style="display:none">
                    <input class="Email" value='<%# Eval("Email") %>' type="hidden" />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr id='<%# Eval("NCPDP") %>' style="cursor: pointer" class="alternatingRow" ondblclick="SelectPharmacy(this)">
                <td>
                    <i>
                        <%# Eval("RowNumber") %></i>
                </td>
                <td id="Name">
                    <%# Eval("StoreName") %>
                </td>
                <td id="Address">
                    <%# Eval("Address") %>
                </td>
                <td id="City">
                    <%# Eval("City") %>
                </td>
                <td id="State">
                    <%# Eval("StateName") %>
                </td>
                <td id="Zip">
                    <%# Eval("Zip") %>
                </td>
                <td id="Phone">
                    <%# Eval("Phone") %>
                </td>
                <td id="Fax">
                    <%# Eval("Fax") %>
                </td>
                <td style="display:none">
                    <input class="Email" value='<%# Eval("Email") %>' type="hidden" />
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
    ###EndPharmacyFilter###
      ###StartPharmacyRowsCount###
    <asp:Literal runat="server" ID="ltrPharmacyRowsCount"></asp:Literal>
    ###EndPharmacyRowsCount###
    </form>
</body>
</html>