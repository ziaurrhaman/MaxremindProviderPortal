using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for LabTestGroupsDB
/// </summary>
public class LabTestGroupsDB
{
	public LabTestGroupsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(LabTestGroups objLabTestGroups, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("LabTestGroupId", objLabTestGroups.LabTestGroupId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("Name", objLabTestGroups.Name, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("PracticeId", objLabTestGroups.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedById", objLabTestGroups.CreatedById);
            objDBManager.AddParameter("CreatedDate", objLabTestGroups.CreatedDate);
            objDBManager.ExecuteNonQuery("LabTestGroups_Add");
            objLabTestGroups.LabTestGroupId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objLabTestGroups.LabTestGroupId;
    }

    public int Update(LabTestGroups objLabTestGroups, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("LabTestGroupId", objLabTestGroups.LabTestGroupId, SqlDbType.Int, 4);
            objDBManager.AddParameter("Name", objLabTestGroups.Name, SqlDbType.VarChar, 100);
            objDBManager.AddParameter("PracticeId", objLabTestGroups.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedById", objLabTestGroups.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objLabTestGroups.ModifiedDate);
            ReturnValue = objDBManager.ExecuteNonQuery("LabTestGroups_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(int LabTestGroupId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("LabTestGroupId", LabTestGroupId, SqlDbType.Int, 4);
            return objDBManager.ExecuteNonQuery("LabTestGroups_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAll(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("LabTestGroups_GetAll");
    }
}