using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionAttendiesDB
/// </summary>
public class SessionAttendiesDB
{
	public SessionAttendiesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public long Add(SessionAttendies objSessionAttendies)
    {

        DBManager objDBManager = new DBManager();


        try
        {
            objDBManager.AddParameter("SessionAttendiesId", objSessionAttendies.SessionAttendiesId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("TeleHealthSessionsId", objSessionAttendies.TeleHealthSessionsId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PatientId", objSessionAttendies.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("IsInvited", objSessionAttendies.IsInvited, SqlDbType.Bit, 1);
            objDBManager.AddParameter("JoinTime", objSessionAttendies.JoinTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("LeaveTime", objSessionAttendies.LeaveTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ClientIP", objSessionAttendies.ClientIP, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("CreatedById", objSessionAttendies.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedDate", objSessionAttendies.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objSessionAttendies.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("SessionAttendies_Add");

            objSessionAttendies.SessionAttendiesId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objSessionAttendies.SessionAttendiesId;

    }

    public int Update(SessionAttendies objSessionAttendies)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("SessionAttendiesId", objSessionAttendies.SessionAttendiesId, SqlDbType.Int, 4);

            objDBManager.AddParameter("TeleHealthSessionsId", objSessionAttendies.TeleHealthSessionsId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("PatientId", objSessionAttendies.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("IsInvited", objSessionAttendies.IsInvited, SqlDbType.Bit, 1);
            objDBManager.AddParameter("JoinTime", objSessionAttendies.JoinTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("LeaveTime", objSessionAttendies.LeaveTime, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("ClientIP", objSessionAttendies.ClientIP, SqlDbType.VarChar, 25);
            objDBManager.AddParameter("ModifiedById", objSessionAttendies.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedDate", objSessionAttendies.ModifiedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("Deleted", objSessionAttendies.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("SessionAttendies_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public void Delete(int SessionAttendiesId)
    {
        try
        {
            DBManager objDBManager = new DBManager();
            objDBManager.AddParameter("SessionAttendiesId", SessionAttendiesId, SqlDbType.Int, 4);
            objDBManager.ExecuteNonQuery("SessionAttendies_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}