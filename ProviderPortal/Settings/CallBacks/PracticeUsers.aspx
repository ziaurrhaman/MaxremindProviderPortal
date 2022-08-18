<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PracticeUsers.aspx.cs" Inherits="ProviderPortal_Settings_CallBacks_PracticeUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    ###StartUsers###
       <div class="widget">
       <div class="widgettitle">
        My Users
        <span class="spnButton spnButtonTopRight" title="Add New User" onclick="SaveUpdateUser();">Add New <i class="fa fa-user-plus"></i></span>
    </div>
           </div>
           <div id="divUsers">
        
        
        <div class="Grid">
            <table>
                <thead>
                    <tr>
                        <th style="width: 2%;">#</th>
                        <th>
                            Full Name
                        </th>
                       <%-- <th>
                            First Name
                        </th>
                        <th>
                            Middle Name
                        </th>--%>
                        <th>
                            User Name
                        </th>
                        <%--<th>
                            Location
                        </th>--%>
                        <th>
                            Email
                        </th>
                      <th>
                            Phone
                        </th>
                        <th>
                            Status
                        </th>
                        <th>
                            Action
                        </th>
                    </tr>
                </thead>
                <tbody id="UsersList" class="UsersList">
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
                                    </div>
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
                                    </div>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                    <asp:HiddenField runat="server" ID="hdnUsersTotalCount" />
                </tbody>
            </table>
            <div class="message" style="width:100%;">
                <span class="iconInfo" style="margin: 7px;"></span><span class="spanInfo"></span>
            </div>
            <div class="pager">
                <div class="PageEntries">
                    <span style="float: left; margin-left: 5px;">Show&nbsp;</span><span style="float: left;">
                        <select id="ddlPagingUsers" style="margin-top: 5px;" onchange="RowsChange('FilterUsers');">
                            <option value="10">10</option>
                            <option value="25">25</option>
                            <option value="50">50</option>
                            <option value="75">75</option>
                            <option value="100">100</option>
                        </select>
                    </span><span style="float: left;">&nbsp;entries</span>
                </div>
                <div class="PageButtons">
                    <ul style="float: right; margin-right: 15px;"></ul>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtPhone").mask("(99) 9999-9999");
            GeneratePaging($("[id$='hdnUsersTotalCount']").val(), $("#ddlPagingUsers").val(), "divUsers", "FilterUsers");
            if ($("[id$='hdnUsersTotalCount']").val() > 0) {
                $("#divUsers .spanInfo").html("Showing " + $(".UsersList tr:first").children().first().html() + " to " + $(".UsersList tr:last").children().first().html() + " of " + $("[id$='hdnUsersTotalCount']").val() + " entries");
            }

            new AjaxUpload('#UserImgFile', {
                action: _EMRPath + "/Attachments.ashx",
                dataType: 'json',
                contentType: "application/json; charset=uft-8",
                data: {
                    Directory: "Users"
                },
                onSubmit: function (file, ext, fileSize) {
                    if ((ext && /^(exe|dll|bat)$/.test(ext))) {
                        showErrorMessage('Error: invalid file extension');
                        return false;
                    }
                    if (fileSize > 5) {
                        showErrorMessage("This file exceeds the 5MB attachment limit.");
                        return false;
                    }
                },
                onComplete: function (file, response) {
                    var responseHtml = $(response);
                    var r = responseHtml.html();
                    var res = $.parseJSON(r);
                    $("[id$='hdnImageUser']").val(res.path);
                    $("img[id$='UserImg']").attr("src", _ResolveUrl + "PracticeDocuments/" + $.trim($("[id$='hdnPracticeId']").val()) + "/Users/" + res.path);
                }
            });
            PopulateUsers();
        });

    </script>
    <input type="hidden" id="hdnImageUser" runat="server"/>

    ###EndUsers###
    </div>
    <div>
    ###startAddUser###
           
                    
                        <table style="width: 100%;" id="tblUsers" cellpadding="5" cellspacing="10">
                            <tr>
                                <td colspan="5">
                                    <div class="header" style="width:123%;">
                                        General Information</div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    First Name:<span class="spnError"> *</span>
                                </td>
                                <td>
                                    <input type="text" id="txtUserFName" class="required" maxlength="20" onkeypress="return allowCharacters(event,'abcdefghijklmnopqrstuvwxyz ')" runat="server"/>
                                </td>
                                 <td style="white-space:nowrap;">
                                    Middle Name:
                                </td>
                                <td>
                                    <input type="text" id="txtUserMName" maxlength="20" onkeypress="return allowCharacters(event,'abcdefghijklmnopqrstuvwxyz ')"  runat="server"/>
                                </td>
                                 <td>
                                    Last Name:<span class="spnError"> *</span>
                                </td>
                                <td>
                                    <input type="text" id="txtUserLName" autocomplete="off" maxlength="20" class="required" onkeypress="return allowCharacters(event,'abcdefghijklmnopqrstuvwxyz ')" runat="server"/>
                                </td>
                               
                            </tr>

                              <tr>
                                <td>
                                    User Name:<span class="spnError"> *</span>
                                </td>
                                <td>
                                    <input type="text" id="txtUserName" autocomplete="off" onblur="validateUser()" maxlength="20" class="required" runat="server" onkeyup="GetAlreadyExixtUser()"/>
                                </td>
                                 <td>
                                    Password:<span class="spnError"> *</span>
                                </td>
                                <td>
                                    <input type="password" id="txtPassword" autocomplete="new-password" maxlength="20" class="required" runat="server"/>
                                </td>
                                <td style="white-space:nowrap;">
                                    Confirm Password:<span class="spnError"> *</span>
                                </td>
                                <td>
                                    <input type="password" id="txtConfirmPassword"  maxlength="20" class="required"/>
                                </td>   
                            </tr>
                            <tr>
                               
                                <td>
                                    Phone:
                                </td>
                                <td>
                                    <input type="text" id="txtPhone" class="phone" maxlength="13" runat="server"/>
                                </td>
                                 <td>
                                    Email:
                                </td>
                                <td>
                                    <input type="text" id="txtEmail" maxlength="100" class="" runat="server"/>
                                </td>
                            </tr>
                          
                            
                            <tr>
                                <td style="width: 20%;">
                                    Roles:<span class="spnError"> *</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUsersRoles" class="required" runat="server" Style="width: 54%;">
                                    </asp:DropDownList>
                                </td>
                            
                                <td>
                                    Active:
                                </td>
                                <td>
                                    

                                    <asp:CheckBox ID="chkUserStauts" runat="server" />
                                </td>
                            </tr>
                        </table>
                   
                    <%--<td style="width: 48%;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2" style="padding-top: 10px;">
                                    <div class="PersonPhoto">
                                        <asp:Image ID="UserImg" runat="server" />
                                        <div class="ChangePhotoWrapper">
                                            <input type="file" value="Upload" id="UserImgFile" size="1" style="z-index: 5; opacity: 0;
                                                cursor: pointer;" />
                                            <div id="btnUpload" class="ChangePhoto">
                                                <span>Change Photo</span>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>--%>
              
            <input type="hidden" id="hdnProviderIdInUser" value="0" />
            <input type="hidden" id="hdnPassord" value="0"  runat="server"/>
        <%--<div style="float: right; padding-bottom: 5px;">
            <input type="button" value="Save" onclick="saveUser();" />
            <input type="button" value="Cancel" onclick="cancelSaveUser();" />
        </div>--%>
      <div class="UAExist"  style="display:none"></div> 
    ###EndAddUser###
    </div>
    <div>
        <div style="display:none">
         ###SUserAExist###
             <asp:HiddenField runat="server" ID="hdnAlreadyExistUser" />
         ###EUserAExist###
        </div>
    </div>
    </form>
</body>
</html>
