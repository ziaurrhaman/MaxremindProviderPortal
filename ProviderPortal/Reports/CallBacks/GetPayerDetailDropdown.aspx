<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetPayerDetailDropdown.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_GetPayerDetailDropdown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
        ###StartCheckNumber###
          <asp:DropDownList ID="ddlCheckNumber" CssClass="ddlCheckNumber" runat="server" Style="float:left; width: 97%; margin-top: -0.8%;">
                                </asp:DropDownList>
        ###EndCheckNumber###
         ###StartPostDate###
         <asp:DropDownList ID="ddlPostDate" CssClass="ddlPostDate" runat="server" Style="float:left; width: 97%; margin-top: -0.8%;">
                                </asp:DropDownList>
        ###EndPostDate###
    
    </div>
    </form>
</body>
</html>
