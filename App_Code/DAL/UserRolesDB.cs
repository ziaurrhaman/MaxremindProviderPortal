using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserRolesDB
/// </summary>
public class UserRolesDB
{
	public UserRolesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(UserRoles objUserRoles)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("UserRoleId", objUserRoles.UserRoleId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDbManager.AddParameter("UserId", objUserRoles.UserId);
            objDbManager.AddParameter("RoleId", objUserRoles.RoleId);
            objDbManager.AddParameter("ModifiedDate", objUserRoles.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objUserRoles.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_AddUserRoles");
            objUserRoles.UserRoleId = Convert.ToInt64(objDbManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objUserRoles.UserRoleId;

    }

    public void Update(UserRoles objUserRoles)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("UserRoleId", objUserRoles.UserRoleId);
            objDbManager.AddParameter("UserId", objUserRoles.UserId);
            objDbManager.AddParameter("RoleId", objUserRoles.RoleId);
            objDbManager.AddParameter("ModifiedDate", objUserRoles.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objUserRoles.ModifiedById);
            objDbManager.AddParameter("Deleted", objUserRoles.Deleted);
            objDbManager.ExecuteNonQuery("UserRights_UpdateUserRoles");
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
}