<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRolesHandler.aspx.cs" Inherits="ProviderPortal_UserRights_CallBacks_UserRolesHandler" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
        ###StartRolesHandler###
         <%--   <h3> Role handler</h3>--%>
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
        ###EndRolesHandler### 
        
        ###StartRoleId###
        <asp:Literal runat="server" ID="ltrRoleId"></asp:Literal>
        ###EndRoleId###
    </div>
    </form>
</body>
</html>
