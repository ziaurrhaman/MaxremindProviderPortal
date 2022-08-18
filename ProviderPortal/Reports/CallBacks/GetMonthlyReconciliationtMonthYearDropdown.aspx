<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetMonthlyReconciliationtMonthYearDropdown.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_GetMonthlyReconciliationtMonthYearDropdown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     ###StartYear###
          <asp:DropDownList ID="ddlMonthlyReconciliationYear" CssClass="ddlMonthlyReconciliationYear" runat="server" Style="float:right; width: 97%; margin-top: -0.8%; margin-right: 3%;">
          </asp:DropDownList>
        ###EndYear###
         ###StartMonth###
         <asp:DropDownList ID="ddlMonthlyReconciliationMonth" CssClass="ddlMonthlyReconciliationMonth" runat="server" Style="float:right; width: 97%; margin-top: -0.8%; margin-right: 3%;">
         </asp:DropDownList>
        ###EndMonth###
        <%-- Added By Rizwan 30April2018 --%>
            ###Startddl###
         <asp:DropDownList ID="ddlMonthlyReconciliationProvider" CssClass="ddlMonthlyReconciliationProvider" runat="server" Style="float:right; width: 97%; margin-top: -0.8%; margin-right: 3%;" onchange="LoadYearonProvider();">
          
         </asp:DropDownList>
        ###Endddl###

    </div>
    </form>
</body>
</html>
