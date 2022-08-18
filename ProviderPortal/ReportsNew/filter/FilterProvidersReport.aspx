<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterProvidersReport.aspx.cs" Inherits="EMR_ReportsNew_filter_FilterProvidersReport" %>

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
                              <%# Eval("LastName")%>
                          </td>
                          <td>
                              <%# Eval("FirstName")%>
                          </td>
                          <td>
                              <%# Eval("Degree")%>
                          </td>
                          <td>
                              <%# Eval("Speciality")%>
                          </td>
                          <td>
                              <%# Eval("[Address]")%>
                          </td>
                          <td>
                              <%# Eval("PhoneNumber")%>
                          </td>
                          <td>
                              <%# Eval("Email")%>
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
