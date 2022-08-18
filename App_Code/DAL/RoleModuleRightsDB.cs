using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RoleModuleRightsDB
/// </summary>
public class RoleModuleRightsDB
{
	public RoleModuleRightsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long Add(RoleModuleRights objRoleModuleRights)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("RoleModuleRightsId", objRoleModuleRights.RoleModuleRightsId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDbManager.AddParameter("RoleId", objRoleModuleRights.RoleId);
            objDbManager.AddParameter("ModuleRightId", objRoleModuleRights.ModuleRightId);
            objDbManager.AddParameter("Status", objRoleModuleRights.Status);
            objDbManager.AddParameter("ModifiedDate", objRoleModuleRights.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objRoleModuleRights.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_AddRoleModuleRights");

            objRoleModuleRights.RoleModuleRightsId = Convert.ToInt64(objDbManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objRoleModuleRights.RoleModuleRightsId;
    }

    public void Update(RoleModuleRights objRoleModuleRights)
    {
        DBManager objDbManager = new DBManager();
        try
        {

            objDbManager.AddParameter("RoleModuleRightsId", objRoleModuleRights.RoleModuleRightsId, SqlDbType.Int, 4);
            objDbManager.AddParameter("RoleId", objRoleModuleRights.RoleId);
            objDbManager.AddParameter("ModuleRightId", objRoleModuleRights.ModuleRightId);
            objDbManager.AddParameter("Status", objRoleModuleRights.Status);
            objDbManager.AddParameter("ModifiedDate", objRoleModuleRights.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objRoleModuleRights.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_UpdateRoleModuleRights");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateRoleModuleRightsForNewLocation(RoleModuleRights objRoleModuleRights)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("RoleId", objRoleModuleRights.RoleId);
            objDbManager.AddParameter("ModuleRightId", objRoleModuleRights.ModuleRightId);
            objDbManager.AddParameter("Status", objRoleModuleRights.Status);
            objDbManager.AddParameter("ModifiedDate", objRoleModuleRights.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objRoleModuleRights.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_UpdateRoleModuleRightsForNewLocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpdateAdminRoleRightsForNewLocation(RoleModuleRights objRoleModuleRights, string ModuleRightId)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("ModuleRightId", ModuleRightId);
            objDbManager.AddParameter("NewStatus", objRoleModuleRights.Status);
            objDbManager.AddParameter("ModifiedDate", objRoleModuleRights.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objRoleModuleRights.ModifiedById);

            objDbManager.ExecuteNonQuery("UserRights_UpdateAdminRoleRightsForNewLocation");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRoleRights(Int64 roleId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("RoleId", roleId);
        return objDbManager.ExecuteDataTable("UserRights_GetRoleRights");
    }

    public DataTable GetRoleRightsForUser(string roleId, Int64 userId, long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("RoleId", roleId);
        objDbManager.AddParameter("UserId", userId);
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("UserRights_GetRoleRightsForUser");
    }

    public void DeleteRoleModuleRights(string roleModuleRightsId, int userId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("RoleModuleRightsId", roleModuleRightsId);
        objDbManager.AddParameter("ModifiedById", userId);
        objDbManager.AddParameter("ModifiedDate", DateTime.Now);
        objDbManager.ExecuteNonQuery("Roles_DeleteRoleModuleRights");
    }
}