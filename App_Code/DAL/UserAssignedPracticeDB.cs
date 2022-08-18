using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAssignedPracticeDB
/// </summary>
public class UserAssignedPracticeDB
{
	public UserAssignedPracticeDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(UserAssignedPractices objTasks, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("UserAssignedPracticeId", objTasks.UserAssignedPracticeId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("UserId", objTasks.UserId);
            objDBManager.AddParameter("PracticeId", objTasks.PracticeId);
            objDBManager.AddParameter("CreatedById", objTasks.CreatedById);
            objDBManager.AddParameter("CreatedDate", objTasks.CreatedDate);
            objDBManager.AddParameter("PratciceLocationId", objTasks.PraticeLocation);
            objDBManager.AddParameter("IsActive", objTasks.IsActive);
            objDBManager.AddParameter("Deleted", objTasks.Deleted);
            objDBManager.ExecuteNonQuery("UserAssignedPractices_Add");
            string test = objDBManager.Parameters[0].Value.ToString();

            objTasks.UserAssignedPracticeId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objTasks.UserAssignedPracticeId;
    }

    public int Update(UserAssignedPractices objTasks, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objTasks.UserId);
            objDBManager.AddParameter("PracticeId", objTasks.PracticeId);
            objDBManager.AddParameter("ModifiedById", objTasks.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objTasks.ModifiedDate);
            objDBManager.AddParameter("PratciceLocationId", objTasks.PraticeLocation);

            objDBManager.AddParameter("Deleted", objTasks.Deleted);

            ReturnValue = objDBManager.ExecuteNonQuery("UserAssignedPractices_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
}