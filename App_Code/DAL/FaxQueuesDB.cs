using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FaxQueuesDB
/// </summary>
public class FaxQueuesDB
{
	public FaxQueuesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public long Add(FaxQueues objFaxQueues)
    {
        DBManager objDBManager = new DBManager();

        try
        {
            objDBManager.AddParameter("FaxQueueId", objFaxQueues.FaxQueueId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objFaxQueues.PracticeId, SqlDbType.Int, 4);
            objDBManager.AddParameter("PatientId", objFaxQueues.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("SenderId", objFaxQueues.SenderId, SqlDbType.Int, 4);
            objDBManager.AddParameter("Receiver", objFaxQueues.Receiver, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("FaxNumber", objFaxQueues.FaxNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("DocumentName", objFaxQueues.DocumentName, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("FaxContents", objFaxQueues.FaxContents);
            objDBManager.AddParameter("CreatedById", objFaxQueues.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objFaxQueues.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objFaxQueues.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("FaxQueues_Add");

            objFaxQueues.FaxQueueId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objFaxQueues.FaxQueueId;
    }

    public int Update(FaxQueues objFaxQueues)
    {
        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("FaxQueueId", objFaxQueues.FaxQueueId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objFaxQueues.PracticeId, SqlDbType.Int, 4);
            objDBManager.AddParameter("PatientId", objFaxQueues.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("SenderId", objFaxQueues.SenderId, SqlDbType.Int, 4);
            objDBManager.AddParameter("Receiver", objFaxQueues.Receiver, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("FaxNumber", objFaxQueues.FaxNumber, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("DocumentName", objFaxQueues.DocumentName, SqlDbType.VarChar, 150);
            objDBManager.AddParameter("FaxContents", objFaxQueues.FaxContents);
            objDBManager.AddParameter("ModifiedById", objFaxQueues.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objFaxQueues.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objFaxQueues.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("FaxQueues_Update");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    

    public void Delete(int FaxQueueId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("FaxQueueId", FaxQueueId);
            objDBManager.ExecuteNonQuery("FaxQueues_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetByPracticeId(long PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("FaxQueues_GetByPracticeId");
    }

    public DataTable GetById(long FaxQueueId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("FaxQueueId", FaxQueueId);
        return objDBManager.ExecuteDataTable("FaxQueues_GetById");
    }

    public void UpdateSent(long FaxQueueId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("FaxQueueId", FaxQueueId);
        objDBManager.ExecuteNonQuery("FaxQueues_UpdateSent");
    }
}