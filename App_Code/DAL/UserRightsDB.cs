using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserRightsDB
/// </summary>
public class UserRightsDB
{
	public UserRightsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 Add(UserRights objUserRights)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("UserRightsId", objUserRights.UserRightsId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDbManager.AddParameter("UserId", objUserRights.UserId);
            objDbManager.AddParameter("ModuleRightId", objUserRights.ModuleRightId);
            objDbManager.AddParameter("IsIncluded", objUserRights.IsIncluded);
            objDbManager.AddParameter("Status", objUserRights.Status);
            objDbManager.AddParameter("ModifiedDate", objUserRights.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objUserRights.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_AddUserRights");
            objUserRights.UserRightsId = Convert.ToInt64(objDbManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objUserRights.UserRightsId;
    }

    public void Update(UserRights objUserRights)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("UserRightsId", objUserRights.UserRightsId);
            objDbManager.AddParameter("UserId", objUserRights.UserId);
            objDbManager.AddParameter("ModuleRightId", objUserRights.ModuleRightId);
            objDbManager.AddParameter("IsIncluded", objUserRights.IsIncluded);
            objDbManager.AddParameter("Status", objUserRights.Status);
            objDbManager.AddParameter("ModifiedDate", objUserRights.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objUserRights.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_UpdateUserRights");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpdateUserNewRight(UserRights objUserRights)
    {
        DBManager objDbManager = new DBManager();
        try
        {
            objDbManager.AddParameter("UserId", objUserRights.UserId);
            objDbManager.AddParameter("ModuleRightId", objUserRights.ModuleRightId);
            objDbManager.AddParameter("Status", objUserRights.Status);
            objDbManager.AddParameter("ModifiedDate", objUserRights.ModifiedDate);
            objDbManager.AddParameter("ModifiedById", objUserRights.ModifiedById);
            objDbManager.ExecuteNonQuery("UserRights_UpdateUserNewRight");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetUsersAndModules(long PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataSet("UserRights_GetUsersAndModules_ProviderPortal");
    }
    public DataSet GetUserRightsAndRoles(long PracticeId, Int64 userId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        objDbManager.AddParameter("UserId", userId);
        return objDbManager.ExecuteDataSet("UserRights_GetUserRightsAndRoles_ProviderPortal");
    }
    public DataTable GetUsersRights(Int64 userId, string userType)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("UserId", userId);
        objDbManager.AddParameter("UserType", userType);
        return objDbManager.ExecuteDataTable("UserRights_GetUsersRights");
    }
    public void DeleteUserRights(string moduleRightId, Int64 userId, int modifiedById)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("ModuleRightId", moduleRightId);
        objDbManager.AddParameter("UserId", userId);
        objDbManager.AddParameter("ModifiedById", modifiedById);
        objDbManager.AddParameter("ModifiedDate", DateTime.Now);
        objDbManager.ExecuteNonQuery("UserRights_DeleteUserRights");
    }
}