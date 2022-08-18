<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FilterContractManagementDetailReport.aspx.cs" Inherits="ProviderPortal_Reports_CallBacks_FilterContractManagementDetailReport" %>

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
                          <td>
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
            ###End###
    ###StartTotal###
    <asp:Literal runat="server" ID="ltrTotalRows"></asp:Literal>
            ###EndTotal###
    
        </div>
    </form>
</body>
</html>
