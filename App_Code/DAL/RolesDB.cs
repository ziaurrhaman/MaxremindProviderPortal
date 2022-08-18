using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RolesDB
/// </summary>
public class RolesDB
{
	public RolesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(Roles objRoles)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("RoleId", objRoles.RoleId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDbManager.AddParameter("RoleName", objRoles.RoleName);
            objDbManager.AddParameter("DefaultScreenId", objRoles.DefaultScreenId);
            objDbManager.AddParameter("PracticeId", objRoles.PracticeId);
            objDbManager.AddParameter("ModifiedDate", objRoles.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objRoles.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_AddRoles_ProviderPortal");
            objRoles.RoleId = Convert.ToInt64(objDbManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objRoles.RoleId;

    }

    public void Update(Roles objRoles)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("RoleId", objRoles.RoleId, SqlDbType.Int, 4);
            objDbManager.AddParameter("RoleName", objRoles.RoleName);
            objDbManager.AddParameter("DefaultScreenId", objRoles.DefaultScreenId);
            objDbManager.AddParameter("ModifiedDate", objRoles.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objRoles.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_UpdateRoles");
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    public DataTable GetRoles(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("Roles_GetRoles_ProviderPortal");
    }
    public void DeleteRole(long PracticeId, Int64 roleId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("RoleId", roleId);
        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.ExecuteNonQuery("Roles_DeleteRole");
    }
    public DataSet GetRolesAndModules(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataSet("Roles_GetRolesAndModules_CreatedByProvider");
    }
}