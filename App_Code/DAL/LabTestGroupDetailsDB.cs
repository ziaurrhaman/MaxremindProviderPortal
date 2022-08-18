using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for LabTestGroupDetailsDB
/// </summary>
public class LabTestGroupDetailsDB
{
	public LabTestGroupDetailsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public long Add(LabTestGroupDetails objLabTestGroupDetails, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("LabTestGroupDetailId", objLabTestGroupDetails.LabTestGroupDetailId, SqlDbType.Int, 4, ParameterDirection.Output);
            objDBManager.AddParameter("LabTestGroupId", objLabTestGroupDetails.LabTestGroupId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objLabTestGroupDetails.PracticeId);
            objDBManager.AddParameter("HcpcsCode", objLabTestGroupDetails.HcpcsCode);
            objDBManager.AddParameter("LabTestId", objLabTestGroupDetails.LabTestId);
            objDBManager.AddParameter("CreatedById", objLabTestGroupDetails.CreatedById);
            objDBManager.AddParameter("CreatedDate", objLabTestGroupDetails.CreatedDate);
            objDBManager.ExecuteNonQuery("LabTestGroupDetails_Add");
            objLabTestGroupDetails.LabTestGroupDetailId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objLabTestGroupDetails.LabTestGroupDetailId;
    }

    public int Update(LabTestGroupDetails objLabTestGroupDetails, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("LabTestGroupDetailId", objLabTestGroupDetails.LabTestGroupDetailId, SqlDbType.Int, 4);
            objDBManager.AddParameter("LabTestGroupId", objLabTestGroupDetails.LabTestGroupId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PracticeId", objLabTestGroupDetails.PracticeId);
            objDBManager.AddParameter("HcpcsCode", objLabTestGroupDetails.HcpcsCode);
            objDBManager.AddParameter("LabTestId", objLabTestGroupDetails.LabTestId);
            objDBManager.AddParameter("ModifiedById", objLabTestGroupDetails.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objLabTestGroupDetails.ModifiedDate);
            objDBManager.AddParameter("Deleted", objLabTestGroupDetails.Deleted);
            ReturnValue = objDBManager.ExecuteNonQuery("LabTestGroupDetails_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public int Delete(int LabTestGroupDetailId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("LabTestGroupDetailId", LabTestGroupDetailId, SqlDbType.Int, 4);
            return objDBManager.ExecuteNonQuery("LabTestGroupDetails_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAll(long PracticeId, long LabTestGroupId, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("LabTestGroupId", LabTestGroupId);
        return objDBManager.ExecuteDataTable("LabTestGroupDetails_GetAll");
    }
}