using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionRequestsDB
/// </summary>
public class SessionRequestsDB
{
	public SessionRequestsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public void Add(SessionRequests objSessionRequests)
    {

        DBManager objDBManager = new DBManager();

        try
        {
            objDBManager.AddParameter("SessionRequestId", objSessionRequests.SessionRequestId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("SessionId", objSessionRequests.SessionId, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("UserId", objSessionRequests.UserId, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PatientId", objSessionRequests.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("FirstName", objSessionRequests.FirstName, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("LastName", objSessionRequests.LastName, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Gender", objSessionRequests.Gender, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("DOB", objSessionRequests.DOB, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("MaritalStatus", objSessionRequests.MaritalStatus, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("ImagePath", objSessionRequests.ImagePath, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("Accepted", objSessionRequests.Accepted, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Rejected", objSessionRequests.Rejected, SqlDbType.Bit, 1);
            objDBManager.AddParameter("CreatedDate", objSessionRequests.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("CreatedById", objSessionRequests.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Deleted", objSessionRequests.Deleted, SqlDbType.Bit, 1);

            objDBManager.ExecuteNonQuery("SessionRequests_Add");

            //objSessionRequests.SessionRequestId = long.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        //return objSessionRequests.SessionRequestId;

    }

    public int Update(SessionRequests objSessionRequests)
    {

        DBManager objDBManager = new DBManager();
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("SessionRequestId", objSessionRequests.SessionRequestId, SqlDbType.Int, 4);

            objDBManager.AddParameter("SessionId", objSessionRequests.SessionId, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("UserId", objSessionRequests.UserId, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("PatientId", objSessionRequests.PatientId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("FirstName", objSessionRequests.FirstName, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("LastName", objSessionRequests.LastName, SqlDbType.VarChar, 50);
            objDBManager.AddParameter("Gender", objSessionRequests.Gender, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("DOB", objSessionRequests.DOB, SqlDbType.DateTime, 3);
            objDBManager.AddParameter("MaritalStatus", objSessionRequests.MaritalStatus, SqlDbType.VarChar, 20);
            objDBManager.AddParameter("ImagePath", objSessionRequests.ImagePath, SqlDbType.VarChar, 500);
            objDBManager.AddParameter("Accepted", objSessionRequests.Accepted, SqlDbType.Bit, 1);
            objDBManager.AddParameter("Rejected", objSessionRequests.Rejected, SqlDbType.Bit, 1);
            objDBManager.AddParameter("CreatedDate", objSessionRequests.CreatedDate, SqlDbType.DateTime, 8);
            objDBManager.AddParameter("CreatedById", objSessionRequests.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Deleted", objSessionRequests.Deleted, SqlDbType.Bit, 1);

            ReturnValue = objDBManager.ExecuteNonQuery("SessionRequests_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }


    public DataTable GetRequest(string SessionId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("SessionId", SessionId);
        return objDBManager.ExecuteDataTable("SessionRequests_GetBySessionId");
    }

    public void UpdateRequest(string UserId, bool Accepted, bool Rejected)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserId", UserId);
        objDBManager.AddParameter("Accepted", Accepted);
        objDBManager.AddParameter("Rejected", Rejected);
        objDBManager.ExecuteNonQuery("SessionRequests_UpdateRequest");
    }


    public DataTable GetByUserId(string UserId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("UserId", UserId);
        return objDBManager.ExecuteDataTable("SessionRequests_GetByUserId");
    }
}