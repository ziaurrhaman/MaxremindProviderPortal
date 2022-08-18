<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterMissedCopaysReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterMissedCopaysReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ###Start###
              <asp:Repeater ID="rptMissedCopays" runat="server">
                  <ItemTemplate>
                      <tr>
                          <td style="text-align: center;">
                              <%# Eval("RowNumber")%>
                          </td>
                          <td>
                              <%# Eval("EncounterId")%>
                          </td>
                          <td>
                              <%# Eval("ServiceDate")%>
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
                              <%# Eval("PrimaryInsurance")%>
                          </td>
                          <td>
                              <%# Eval("Copay")%>
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
