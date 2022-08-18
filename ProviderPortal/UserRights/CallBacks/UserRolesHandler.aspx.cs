using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Data;

public partial class ProviderPortal_UserRights_CallBacks_UserRolesHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["Action"];
        RolesDB objRolesDb = new RolesDB();
        if (action.Equals("Save"))
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var roleRights = serializer.Deserialize<List<RoleModuleRights>>(Request.Form["RoleRights"]);
            Int64 roleId = Convert.ToInt64(Request.Form["RoleId"]);
            if (bool.Parse(Request.Form["RoleChanged"]))
            {
                Roles objRoles = new Roles
                {
                    RoleId = Convert.ToInt64(Request.Form["RoleId"]),
                    RoleName = Request.Form["RoleTitle"],
                    PracticeId = int.Parse(Profile.PracticeId.ToString()),
                    ModifiedById = int.Parse(Profile.UserId.ToString()),
                    ModifiedDate = DateTime.Now
                };
                if (roleId == 0)
                    roleId = objRolesDb.Add(objRoles);

                else
                    objRolesDb.Update(objRoles);

                rptRoles.DataSource = objRolesDb.GetRoles(int.Parse(Profile.PracticeId.ToString()));
                rptRoles.DataBind();
            }
            ltrRoleId.Text = roleId.ToString();
            RoleModuleRightsDB objRoleModuleRightsDb = new RoleModuleRightsDB();
            objRoleModuleRightsDb.DeleteRoleModuleRights(Request.Form["RoleRightsToDelete"], int.Parse(Profile.UserId.ToString()));
            foreach (var roleModuleRightse in roleRights)
            {
                roleModuleRightse.RoleId = roleId;
                roleModuleRightse.ModifiedById = int.Parse(Profile.UserId.ToString());
                roleModuleRightse.ModifiedDate = DateTime.Now;
                if (roleModuleRightse.RoleModuleRightsId == 0)
                    objRoleModuleRightsDb.Add(roleModuleRightse);
                else
                    objRoleModuleRightsDb.Update(roleModuleRightse);
            }
        }
        else
        {
            objRolesDb.DeleteRole(int.Parse(Profile.PracticeId.ToString()), Convert.ToInt64(Request.Form["RoleId"]));
        }
    }
    [WebMethod]
    public static List<RoleModuleRights> GetRoleRights(string roleId)
    {
        RoleModuleRightsDB objRoleModuleRightsDb = new RoleModuleRightsDB();
        DataTable dtRights = objRoleModuleRightsDb.GetRoleRights(Convert.ToInt64(roleId));
        return dtRights.AsEnumerable().Select(row => new RoleModuleRights
        {
            ModuleRightId = row.Field<Int32>("ModuleRightId"),
            RoleModuleRightsId = row.Field<Int64>("RoleModuleRightsId"),
            Status = row.Field<string>("Status").Trim()

        }).ToList();
    }
}