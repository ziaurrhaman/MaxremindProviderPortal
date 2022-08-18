<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRoles.aspx.cs" Inherits="ProviderPortal_UserRights_UserRoles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        

</head>
<body>
    <form id="form1" runat="server">
     <div>
        ###StartRoles###
        
             <div class="widget">
       <div class="widgettitle">
        Users Role
        <span  class="spnButton spnButtonTopRight" title="Add New" onclick="newRoleClick()">Add New <i class="fa fa-user-plus"></i></span>
    </div>
                 
           </div>

        <div id="divRoles">
            <div >
                <div style="width: 40%; float: left">
                    <div class="divTitle">
                        <h1>
                            Define Roles</h1>
                    </div>
                    <div class="divContent">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    Role Title
                                </td>
                                <td>
                                    <input type="text" id="txtRoleTitle" onchange="roleChanged()" disabled="disabled" />
                                </td>
                            </tr>
                            <tr><td colspan="2">
                                  <a href="javascript:void(0)" id="btnsaveRoleRights" class="themeButton" onclick="saveRoleRightsClick();"
                    style="padding-left: 24px; display: none; float: left;"><span class="span-action-sprite span-save-sprite">
                    </span>Save </a><a href="javascript:void(0);" id="btncancellRoleRights" class="themeButton"
                        style="padding-left: 23px; display: none; float: left;" onclick="restRolesForm('Cancel');">
                        <span class="span-action-sprite span-cancel-sprite"></span>Cancel </a>
                                </td></tr>
                        </table>
                    </div>
                    <div class="divTitle">
                        <h1>
                            Roles</h1>
                    </div>
                    <div class="divContent">
                        <table class="Grid" id="tblRoles" cellpadding="0" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>
                                        Role Description
                                    </th>
                                    <th>
                                        Action
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="RolesList">
                                <asp:Repeater ID="rptRoles" runat="server">
                                    <ItemTemplate>
                                        <tr id="tr_<%# Eval("RoleId")%>">
                                            <td style="width: 80%; cursor: pointer;" onclick="getRoleRights(this,'<%# Eval("RoleId")%>','<%# Eval("RoleName")%>','row')">
                                                <%# Eval("RoleName")%>
                                            </td>
                                            <td style="text-align: center;">
                                                <span class="spnedit" title="Edit" onclick="modifyRolesClick(this, '<%# Eval("RoleId")%>','<%# Eval("RoleName")%>')">
                                                </span><span class="spndelete" title="Delete Role" onclick="deleteRole(this, '<%# Eval("RoleId")%>')">
                                                </span>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="alternatingRow" id="tr_<%# Eval("RoleId")%>">
                                            <td style="cursor: pointer;" onclick="getRoleRights(this,'<%# Eval("RoleId")%>','<%# Eval("RoleName")%>','row')">
                                                <%# Eval("RoleName")%>
                                            </td>
                                            <td style="text-align: center;">
                                                <span class="spnedit" title="Edit" onclick="modifyRolesClick(this, '<%# Eval("RoleId")%>','<%# Eval("RoleName")%>')">
                                                </span><span class="spndelete" title="Delete Role" onclick="deleteRole(this, '<%# Eval("RoleId")%>')">
                                                </span>
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div style="width: 59%; float: right">
                    <div class="divTitle">
                        <h1>
                            Roles Rights</h1>
                    </div>
                    <div class="divContent">
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
                                                        <asp:CheckBox ID="CheckBox1" CssClass="masterModule" onclick="moduleMasterChkBoxClick(this)"
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
                                                                            <asp:CheckBox ID="CheckBox2" CssClass="subModuleNameChkBox" onclick="subModuleChkBoxClick(this)"
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
                                                                                                    runat="server" Text='<%# Eval("ModeuleRightName")%>' onclick="moduleRightsChkBoxClick(this);"
                                                                                                    CssClass="moduleRight" />
                                                                                                <asp:Literal runat="server" ID="ltrModuleRightId"></asp:Literal>
                                                                                                <span class="spanRoleModuleRightsId" style="display: none;"></span>
                                                                                            </td>
                                                                                            <td style="border-bottom: solid 1px #ccc">
                                                                                                <asp:PlaceHolder runat="server" ID="placeHolderStatus">
                                                                                                    <div class="dropDownMenu" style="position: relative;  padding: 5px 0px 4px 4px; margin: 3px 5px 3px 5px; z-index:1 !important;" id="dropDownMenuId">
                                                                                                        <a onclick="HideShowMenu(this);">
                                                                                                            <div class="selectedText" style="width: 90%; float: left; height: 26px; overflow: hidden;
                                                                                                                top: 1px; position: absolute;">
                                                                                                            </div>
                                                                                                            <div class="dropDownIcon" style="float: right; margin-right: 2px;">
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
                                                                                                                                        <input type="checkbox" id="<%# Eval("StatusCode") %>" style="margin: 6px;" />
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
                                                                                                                                        <input type="checkbox" id="<%# Eval("StatusCode") %>" style="margin: 6px;" />
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
                </div>
            </div>
        </div>
       <%-- <script src='<%= ResolveUrl("~/EMR/UserRights/Roles.js") %>' type="text/javascript"></script>--%>
         <script src="../UserRights/Roles.js"></script>
        
        ###EndRoles###
    </div>
    </form>
</body>
</html>
