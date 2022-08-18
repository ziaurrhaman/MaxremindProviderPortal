using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Data;

public partial class ProviderPortal_UserRights_CallBacks_UserRightsHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserRightsDB objUserRightsDb = new UserRightsDB();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var userRoles = serializer.Deserialize<List<UserRoles>>(Request.Form["UserRoles"]);
        var userRights = serializer.Deserialize<List<UserRights>>(Request.Form["UserRights"]);
        UserRolesDB objUserRolesDb = new UserRolesDB();
        foreach (var userRole in userRoles)
        {
            userRole.ModifiedById = int.Parse(Profile.UserId.ToString());
            userRole.ModifiedDate = DateTime.Now;
            if (userRole.UserRoleId == 0 && !(userRole.Deleted))
                objUserRolesDb.Add(userRole);
            else if (userRole.UserRoleId != 0)
                objUserRolesDb.Update(userRole);
        }

        foreach (var userRightse in userRights)
        {
            userRightse.ModifiedById = int.Parse(Profile.UserId.ToString());
            userRightse.ModifiedDate = DateTime.Now;
            if (userRightse.UserRightsId == 0)
                objUserRightsDb.Add(userRightse);
            else
                objUserRightsDb.Update(userRightse);
        }
    }

    [WebMethod]
    public static UsrRightsList GetUserRights(string userId)
    {
        UserRightsDB objUserRightsDb = new UserRightsDB();
        UsrRightsList objuserRights = new UsrRightsList();
        List<UsrRights> usrRightsList = new List<UsrRights>();
        var listRights = new RoleModuleRights();

        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
        long PracticeId = long.Parse(objProfileCommon.GetPropertyValue("PracticeId").ToString());

        DataSet dsRights = objUserRightsDb.GetUserRightsAndRoles(PracticeId, Convert.ToInt64(userId));
        usrRightsList = dsRights.Tables[0].AsEnumerable().Select(row => new UsrRights
        {
            ModuleRightId = row.Field<Int32>("ModuleRightId"),
            UserRightsId = row.Field<string>("UserRightsId"),
            Status = row.Field<string>("Status").Trim(),
            Selected = row.Field<string>("RigthSelected")
        }).ToList();

        List<UsrRights> usrRolesList = new List<UsrRights>();
        usrRolesList = dsRights.Tables[1].AsEnumerable().Select(row => new UsrRights
        {
            RoleId = row.Field<Int64>("RoleId"),
            UserRoleId = row.Field<Int64>("UserRoleId"),
            Selected = row.Field<string>("RoleSelected")
        }).ToList();

        objuserRights.usrRightsList = usrRightsList;
        objuserRights.roleList = usrRolesList;
        return objuserRights;
    }

    [WebMethod]
    public static UsrRightsList GetRoleRights(string roleId, string userId)
    {
        RoleModuleRightsDB objRoleModuleRightsDb = new RoleModuleRightsDB();
        List<UsrRights> usrRightsList = new List<UsrRights>();
        UsrRightsList objuserRights = new UsrRightsList();

        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
        long PracticeId = long.Parse(objProfileCommon.GetPropertyValue("PracticeId").ToString());
        DataTable dtRights = objRoleModuleRightsDb.GetRoleRightsForUser(roleId.TrimEnd(','), Convert.ToInt64(userId),
                                                                        PracticeId);
        usrRightsList = dtRights.AsEnumerable().Select(row => new UsrRights
        {
            ModuleRightId = row.Field<Int32>("ModuleRightId"),
            UserRightsId = row.Field<string>("UserRightsId"),
            Status = row.Field<string>("Status").Trim(),
            Selected = "True"
        }).ToList();
        objuserRights.usrRightsList = usrRightsList;
        return objuserRights;
    }
}
public class UsrRightsList
{
    public List<UsrRights> usrRightsList { get; set; }
    public List<UsrRights> roleList { get; set; }
}
public class UsrRights
{
    public Int64 ModuleRightId { get; set; }
    public Int64 RoleId { get; set; }
    public string UserRightsId { get; set; }
    public Int64 UserRoleId { get; set; }
    public string Selected { get; set; }
    public string Status { get; set; }
}