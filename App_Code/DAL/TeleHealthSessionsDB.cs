using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TeleHealthSessionsDB
/// </summary>
public class TeleHealthSessionsDB
{
    public TeleHealthSessionsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public long Add(TeleHealthSessions objTeleHealthSessions)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("TeleHealthSessionsId", objTeleHealthSessions.TeleHealthSessionsId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objTeleHealthSessions.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PresenterId", objTeleHealthSessions.PresenterId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("SessionTitle", objTeleHealthSessions.SessionTitle, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("SechduleTime", objTeleHealthSessions.SechduleTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("StartTime", objTeleHealthSessions.StartTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("EndTime", objTeleHealthSessions.EndTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("SessionStatus", objTeleHealthSessions.SessionStatus, SqlDbType.VarChar, 1);
            objDBManager.AddParameter("RoomID", objTeleHealthSessions.RoomID, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("IsOpenSession", objTeleHealthSessions.IsOpenSession, SqlDbType.Bit, 1);
            objDBManager.AddParameter("IsRecorded", objTeleHealthSessions.IsRecorded, SqlDbType.Bit, 1);
            objDBManager.AddParameter("RecordingPath", objTeleHealthSessions.RecordingPath, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("Isbillable", objTeleHealthSessions.Isbillable, SqlDbType.Bit, 1);
            objDBManager.AddParameter("CreatedById", objTeleHealthSessions.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objTeleHealthSessions.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objTeleHealthSessions.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("TeleHealthSessions_Add");

            objTeleHealthSessions.TeleHealthSessionsId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objTeleHealthSessions.TeleHealthSessionsId;

    }

    public int Update(TeleHealthSessions objTeleHealthSessions)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("TeleHealthSessionsId", objTeleHealthSessions.TeleHealthSessionsId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objTeleHealthSessions.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PresenterId", objTeleHealthSessions.PresenterId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("SessionTitle", objTeleHealthSessions.SessionTitle, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("SechduleTime", objTeleHealthSessions.SechduleTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("StartTime", objTeleHealthSessions.StartTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("EndTime", objTeleHealthSessions.EndTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("SessionStatus", objTeleHealthSessions.SessionStatus, SqlDbType.VarChar, 1);
            objDBManager.AddParameter("RoomID", objTeleHealthSessions.RoomID, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("IsOpenSession", objTeleHealthSessions.IsOpenSession, SqlDbType.Bit, 1);
            objDBManager.AddParameter("IsRecorded", objTeleHealthSessions.IsRecorded, SqlDbType.Bit, 1);
            objDBManager.AddParameter("RecordingPath", objTeleHealthSessions.RecordingPath, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("Isbillable", objTeleHealthSessions.Isbillable, SqlDbType.Bit, 1);
            objDBManager.AddParameter("ModifiedById", objTeleHealthSessions.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objTeleHealthSessions.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objTeleHealthSessions.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("TeleHealthSessions_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public void Delete(long TeleHealthSessionsId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("TeleHealthSessionsId", TeleHealthSessionsId);
            objDBManager.ExecuteNonQuery("TeleHealthSessions_Delete");
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
        return objDBManager.ExecuteDataTable("TeleHealthSessions_GetByPracticeId");
    }

    public DataTable GetByPatientId(long PracticeId, long PatientId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("PatientId", PatientId);
        return objDBManager.ExecuteDataTable("TeleHealthSessions_GetByPatientId");
    }


    public DataTable GetById(long TeleHealthSessionId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("TeleHealthSessionId", TeleHealthSessionId);
        return objDBManager.ExecuteDataTable("TeleHealthSessions_GetById");
    }

    public void UpdateStartTime(long TeleHealthSessionId, DateTime StartTime)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("TeleHealthSessionId", TeleHealthSessionId);
        objDBManager.AddParameter("StartTime", StartTime);

        objDBManager.ExecuteNonQuery("TeleHealthSessions_UpdateStartTime");
    }
}