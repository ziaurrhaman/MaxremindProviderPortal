using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserJdDB
/// </summary>
public class UserJdDB
{
	public UserJdDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(UserJd objTasks, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("UserJdId", objTasks.UserJdId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("UserId", objTasks.UserId);
            objDBManager.AddParameter("PracticeId", objTasks.PracticeId);
            objDBManager.AddParameter("TaskId", objTasks.TaskId);
            objDBManager.AddParameter("CreatedById", objTasks.CreatedById);
            objDBManager.AddParameter("CreatedDate", objTasks.CreatedDate);
            objDBManager.AddParameter("Deleted", objTasks.Deleted);
            objDBManager.ExecuteNonQuery("UserJd_Add");
            string test = objDBManager.Parameters[0].Value.ToString();

            objTasks.UserJdId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objTasks.UserJdId;
    }
    public int Update(UserJd objTasks, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("UserId", objTasks.UserId);
            objDBManager.AddParameter("UserJdId", objTasks.UserJdId);
            objDBManager.AddParameter("PracticeId", objTasks.PracticeId);
            objDBManager.AddParameter("TaskId", objTasks.TaskId);
            objDBManager.AddParameter("ModifiedById", objTasks.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objTasks.ModifiedDate);
            objDBManager.AddParameter("Deleted", objTasks.Deleted);

            ReturnValue = objDBManager.ExecuteNonQuery("UserJd_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
}