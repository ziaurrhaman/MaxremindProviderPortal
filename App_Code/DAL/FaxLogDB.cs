using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FaxLogDB
/// </summary>
public class FaxLogDB
{
	public FaxLogDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public long Add(FaxLog objFaxLog)
    {
        DBManager objDBManager = new DBManager();
        
        try
        {
            objDBManager.AddParameter("FaxLogId", objFaxLog.FaxLogId, SqlDbType.BigInt, 8, ParameterDirection.Output);

            objDBManager.AddParameter("Receiver", objFaxLog.Receiver, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ReceiverNumber", objFaxLog.ReceiverNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("DocumentName", objFaxLog.DocumentName, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("AuthorizedBy", objFaxLog.AuthorizedBy, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("CreatedById", objFaxLog.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objFaxLog.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objFaxLog.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("FaxLog_Add");

            objFaxLog.FaxLogId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objFaxLog.FaxLogId;

    }

    public int Update(FaxLog objFaxLog)
    {
        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("FaxLogId", objFaxLog.FaxLogId, SqlDbType.Int, 4);

            objDBManager.AddParameter("Receiver", objFaxLog.Receiver, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ReceiverNumber", objFaxLog.ReceiverNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("DocumentName", objFaxLog.DocumentName, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("AuthorizedBy", objFaxLog.AuthorizedBy, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("ModifiedById", objFaxLog.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objFaxLog.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objFaxLog.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("FaxLog_Update");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }

    public void Delete(int FaxLogId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("FaxLogId", FaxLogId);
            objDBManager.ExecuteNonQuery("FaxLog_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}