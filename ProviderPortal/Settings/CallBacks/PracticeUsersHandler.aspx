<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PracticeUsersHandler.aspx.cs" Inherits="ProviderPortal_Settings_CallBacks_PracticeUsersHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         
      <div id="">
   ###Start###
                 <asp:Repeater ID="rptUsers" runat="server">
                        <ItemTemplate>
                            <tr style="cursor: default">
                                <td>
                                    <%# Eval("ROWNUMBER") %>
                                </td>
                                <td class="userLastName">
                                    <%# Eval("FullName")%>
                                </td>
                               <%-- <td class="userFirstName">
                                    <%# Eval("FirstName")%>
                                </td>
                                <td class="userMiddleName">
                                    <%# Eval("MiddleName")%>
                                </td>--%>
                                <td class="userName">
                                    <%# Eval("UserName")%>
                                </td>
                                <%--<td class="userLocation">
                                    <%# Eval("LocationName")%>
                                </td>--%>
                                <td class="userEmail">
                                    <%# Eval("EmailAddress")%>
                                </td>
                                <td class="userPhone txtalign-cntr">
                                    <%# Eval("PhoneNumber")%>
                                </td>
                                <td class="userStatus <%# Eval("UserStatus")%>">
                                    <%# Eval("UserStatus")%>
                                </td>
                                <td>
                                    <div class="d-flex-center">
                                    <span class="spnedit" title="Edit" onclick="SaveUpdateUser(this,<%# Eval("UserId")%>,'Update');"></span>
                                    <span class="spndelete" title="Delete" onclick="DeletePractieUser(this,<%# Eval("UserId")%>,'Delete');" style="margin-left: 5px;"></span>
                                    <span class="spnInActive" title="In Active" onclick="DeletePractieUser(this,<%# Eval("UserId")%>,'Inactive');" style="margin-left: 5px;font-size:16px;cursor:pointer;"><i class="fa fa-power-off"></i></span>
                                    <%--<input type="hidden" class="hdnPracticeLocationsId" value='<%# Eval("PracticeLocationsId")%>' />--%>
                                    <%--<input type="hidden" class="hdnServiceProviderId" value='<%# Eval("ServiceProviderId")%>' />--%>
                                    <input type="hidden" class="hdnUserId" value='<%# Eval("UserId")%>' />
                                    <input type="hidden" class="hdnUserRoleId" value='<%# Eval("UserRoleId")%>' />
                                    <input type="hidden" class="hdnPassword" value='<%# Eval("Password")%>' />
                                    <div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="cursor: default" class="alternatingRow">
                                <td>
                                    <%# Eval("ROWNUMBER") %>
                                </td>
                               <%-- <td class="userLastName">
                                    <%# Eval("LastName")%>
                                </td>
                                <td class="userFirstName">
                                    <%# Eval("FirstName")%>
                                </td>--%>
                                <td class="userMiddleName">
                                    <%# Eval("FullName")%>
                                </td>
                                <td class="userName">
                                    <%# Eval("UserName")%>
                                </td>
                               <%-- <td class="userLocation">
                                    <%# Eval("LocationName")%>
                                </td>--%>
                                <td class="userEmail">
                                    <%# Eval("EmailAddress")%>
                                </td>
                                <td class="userPhone txtalign-cntr">
                                    <%# Eval("PhoneNumber")%>
                                </td>
                                <td class="userStatus <%# Eval("UserStatus")%>">
                                    <%# Eval("UserStatus")%>
                                </td>
                                <td>
                                    <div class="d-flex-center">
                                    <span class="spnedit" title="Edit" onclick="SaveUpdateUser(this,<%# Eval("UserId")%>,'Update');"></span>
                                    <span class="spndelete" title="Delete" onclick="DeletePractieUser(this,<%# Eval("UserId")%>,'Delete');" style="margin-left: 5px;"></span>
                                    <span class="spnInActive" title="In Active" onclick="DeletePractieUser(this,<%# Eval("UserId")%>,'Inactive');" style="margin-left: 5px;font-size:16px;cursor:pointer;"><i class="fa fa-power-off"></i></span>
                                   <%-- <input type="hidden" class="hdnPracticeLocationsId" value='<%# Eval("PracticeLocationsId")%>' />
                                    <input type="hidden" class="hdnServiceProviderId" value='<%# Eval("ServiceProviderId")%>' />--%>
                                    <input type="hidden" class="hdnUserId" value='<%# Eval("UserId")%>' />
                                   <input type="hidden" class="hdnUserRoleId" value='<%# Eval("UserRoleId")%>' />
                                    <input type="hidden" class="hdnPassword" value='<%# Eval("Password")%>' />
                                    <div>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
            <asp:HiddenField runat="server" ID="hdnUsersTotalCount" />
    ###End###
    ###StartPatientRowsCount###
    <asp:Literal runat="server" ID="ltrlRowsCount"></asp:Literal>
    ###EndPatientRowsCount###
    </div>
    </form>
</body>
</html>
