<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRights.aspx.cs" Inherits="ProviderPortal_UserRights_UserRights" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        ###StartUserRights
        <div id="divUserRights">
            <div  class="action-button-wrapper">
                <a href="javascript:void(0)" id="btnsaveRights" class="themeButton" onclick="saveUserRightsClick();"
                    style="padding-left: 24px; display: none; float: left;"><span class="span-action-sprite span-save-sprite">
                    </span>Save </a><a href="javascript:void(0);" id="btncancell" class="themeButton"
                        style="padding-left: 23px; display: none; float: left;" onclick="resetRightsForm('Cancel');">
                        <span class="span-action-sprite span-cancel-sprite"></span>Cancel </a>
            </div>
            <div>
                <div style="float: left; width: 45%; margin-left: -10px;padding-right: 10px;">
                    <div class="divTitle">
                        <h1>
                            User Information</h1>
                    </div>
                    <div class="divContent">
                        <div class="Grid">
                        <table class="table" id="tblUsers" cellpadding="0" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>
                                        User Name
                                    </th>
                                    <th>
                                        First Name
                                    </th>
                                    <th>
                                        Last Name
                                    </th>
                                    <th>
                                        Edit
                                    </th>
                                    <th style="display: none;">
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="UsersList">
                                <asp:Repeater ID="rptUsers" runat="server">
                                    <ItemTemplate>
                                        <tr style="cursor: pointer">
                                            <td onclick="getUserRights(this,'<%# Eval("UserId")%>','row')">
                                                <%# Eval("UserName")%>
                                            </td>
                                            <td onclick="getUserRights(this,'<%# Eval("UserId")%>','row')">
                                                <%# Eval("FirstName")%>
                                            </td>
                                            <td onclick="getUserRights(this,'<%# Eval("UserId")%>','row')">
                                                <%# Eval("LastName")%>
                                            </td>
                                            <td style="text-align: center; cursor: default;">
                                                <span class="spanedit" title="Edit" onclick="modifyUserRightsClick(this, '<%# Eval("UserId")%>')">
                                                </span>
                                            </td>
                                            <td style="display: none">
                                                <span class="spanPassword">
                                                    <%# Eval("Password")%></span> <span class="spanActive">
                                                        <%# Eval("IsActive")%></span>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="alternatingRow" style="cursor: pointer">
                                            <td onclick="getUserRights(this,'<%# Eval("UserId")%>','row')">
                                                <%# Eval("UserName")%>
                                            </td>
                                            <td onclick="getUserRights(this,'<%# Eval("UserId")%>','row')">
                                                <%# Eval("FirstName")%>
                                            </td>
                                            <td onclick="getUserRights(this,'<%# Eval("UserId")%>','row')">
                                                <%# Eval("LastName")%>
                                            </td>
                                            <td style="text-align: center; cursor: default;">
                                                <span class="spanedit" title="Edit" onclick="modifyUserRightsClick(this, '<%# Eval("UserId")%>')">
                                                </span>
                                            </td>
                                            <td style="display: none">
                                                <span class="spanPassword">
                                                    <%# Eval("Password")%></span> <span class="spanActive">
                                                        <%# Eval("IsActive")%></span>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    </div>
                </div>
                <div style="float: left; width: 55%">
                    <div style="width: 100%; float: left;">
                        <div>
                            <div class="divTitle">
                                <h1>
                                    Roles</h1>
                            </div>
                            <div class="divContent">
                                <table id="tblUserRoles">
                                    <asp:Repeater ID="rptUserRoles" runat="server">
                                        <ItemTemplate>
                                            <tr class='role_<%# Eval("RoleId")%>'>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" onchange="getRolesRights()" Enabled="False"
                                                        Text='<%# Eval("RoleName")%>' />
                                                    <span class="roleId" style="display: none">
                                                        <%# Eval("RoleId")%></span> <span class="userRoleId" style="display: none">0</span>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%; float: left; margin-top: 5px;">
                        <div class="divTitle" style="width: 99.6%;">
                            <h1>
                                View/Edit User Rights</h1>
                        </div>
                        <div class="divContent" style="width: 97.5%;">
                            <table id="tblModulesWrapper" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <span class="hideIcon" onclick="showHideAllModules(this)" style="margin-top: 4.5px;">
                                        </span>
                                        <input type="checkbox" id="chkAllRoles" disabled="disabled" onclick="checkAllRightsClick()"
                                            value="All" />
                                        <label for="chkAllRoles">
                                            All</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="tblModulesMaster">
                                            <asp:Repeater ID="rptModulesMaster" runat="server" OnItemDataBound="rptModulesMaster_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="white-space: nowrap; vertical-align: top; padding: 5px 0 5px 20px; border-bottom: solid 1px #ccc;">
                                                            <span class="hideIcon" onclick="showHideSubModules(this)" style="margin-top: 4.5px;">
                                                            </span>
                                                            <asp:CheckBox ID="CheckBox2" CssClass="masterModule" onclick="moduleMasterChkBoxClick(this)"
                                                                Enabled="False" runat="server" Text='<%# Eval("ModuleName")%>' />
                                                            <span class="<%# Eval("ModuleName")%>_Parent"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-left: 20px;">
                                                            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                                <asp:Repeater ID="rptModules" runat="server" OnItemDataBound="rptModules_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td style="white-space: nowrap; vertical-align: top; padding: 5px 0 5px 20px; border-bottom: solid 1px #ccc;">
                                                                                <span class="hideIcon" onclick="showHideModuleRights(this)" style="margin-top: 4.5px;">
                                                                                </span>
                                                                                <asp:CheckBox ID="CheckBox3" CssClass="subModuleNameChkBox" onclick="subModuleChkBoxClick(this)"
                                                                                    Enabled="False" runat="server" Text='<%# Eval("ModuleName")%>' />
                                                                                <asp:Literal runat="server" ID="ltrSubModule"></asp:Literal>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding-left: 50px;">
                                                                                <table cellpadding="0" cellspacing="0" id="tblRights">
                                                                                    <asp:Repeater ID="rptModuleRights" runat="server" OnItemDataBound="rptModuleRights_ItemDataBound">
                                                                                        <ItemTemplate>
                                                                                            <tr class='tr_<%# Eval("ModuleRightId")%> OldRight'>
                                                                                                <td style="border-bottom: solid 1px #ccc; width: 50%; padding: 5px 0">
                                                                                                    <asp:CheckBox ID="chkModuleRights" name='<%# Eval("ModeuleRightName")%>' Enabled="False"
                                                                                                        runat="server" Text='<%# Eval("ModeuleRightName")%>' onclick="moduleRightsChkBoxClick(this)"
                                                                                                        CssClass="moduleRight" />
                                                                                                    <asp:Literal runat="server" ID="ltrModuleRightId"></asp:Literal>
                                                                                                    <span class="spanUserRightsId" style="display: none;"></span>
                                                                                                </td>
                                                                                                <td style="border-bottom: solid 1px #ccc">
                                                                                                    <asp:PlaceHolder runat="server" ID="placeHolderStatus">
                                                                                                        <div class="dropDownMenu" style="position: relative; padding: 5px 0px 4px 4px; margin: 3px 5px 3px 5px;">
                                                                                                            <a onclick="HideShowMenu(this);">
                                                                                                                <div class="selectedText" style="width: 90%; float: left; height: 26px; overflow: hidden;
                                                                                                                    top: 1px; position: absolute;">
                                                                                                                </div>
                                                                                                                <div class="dropDownIcon" style="float: right; margin-right: 5px;">
                                                                                                                </div>
                                                                                                            </a>
                                                                                                            <div style="display: none; max-height: 215px; padding: 0; top: 27px; left: 0; width: 241px;"
                                                                                                                class="divRightsStauts">
                                                                                                                <div style="float: left; max-height: 170px; overflow: auto; width: 100%;">
                                                                                                                    <ul>
                                                                                                                        <asp:Repeater ID="rptRightsStatus" runat="server">
                                                                                                                            <ItemTemplate>
                                                                                                                                <li style="float: left; width: 100%;">
                                                                                                                                    <div>
                                                                                                                                        <label class="checkBoxStatus">
                                                                                                                                            <input type="checkbox" id="<%# Eval("StatusCode") %>" style="margin: 6px;"/>
                                                                                                                                            <span>
                                                                                                                                                <%# Eval("StatusDesc")%></span>
                                                                                                                                        </label>
                                                                                                                                    </div>
                                                                                                                                </li>
                                                                                                                            </ItemTemplate>
                                                                                                                            <AlternatingItemTemplate>
                                                                                                                                <li style="background-color: #F7F7F7; float: left; width: 100%;">
                                                                                                                                    <div>
                                                                                                                                        <label class="checkBoxStatus">
                                                                                                                                            <input type="checkbox" id="<%# Eval("StatusCode") %>" style="margin: 6px;"/>
                                                                                                                                            <span>
                                                                                                                                                <%# Eval("StatusDesc")%></span>
                                                                                                                                        </label>
                                                                                                                                    </div>
                                                                                                                                </li>
                                                                                                                            </AlternatingItemTemplate>
                                                                                                                        </asp:Repeater>
                                                                                                                    </ul>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </asp:PlaceHolder>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="margin-bottom: 20px;">
                            &nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
         <input type="hidden" id="hdnUserId" runat="server" />
         <script src="../UserRights/UserRights.js"></script>
         <script type="text/javascript">
             $(document).ready(function () {
                 debugger;
                 console.clear();
             });
        </script>
        ###EndUserRights
    </div>
    </form>
</body>
</html>
