using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for StatusesDB
/// </summary>
public class StatusesDB
{
	public StatusesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Add(Statuses objStatuses, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);


        try
        {
            objDBManager.AddParameter("StatusId", objStatuses.StatusId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("StatusName", objStatuses.StatusName);
            objDBManager.AddParameter("StatusBackColor", objStatuses.StatusBackColor);

            objDBManager.ExecuteNonQuery("Statuses_Add");

            objStatuses.StatusId = int.Parse(objDBManager.Parameters[0].Value.ToString());

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return objStatuses.StatusId;

    }

    public int Update(Statuses objStatuses, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {

            objDBManager.AddParameter("StatusId", objStatuses.StatusId);

            objDBManager.AddParameter("StatusName", objStatuses.StatusName);
            objDBManager.AddParameter("StatusBackColor", objStatuses.StatusBackColor);

            ReturnValue = objDBManager.ExecuteNonQuery("Statuses_Update");


        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ReturnValue;

    }

    public int Delete(int StatusId, SqlTransaction objSqlTransaction = null)
    {
        
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("StatusId", StatusId);
            return objDBManager.ExecuteNonQuery("Statuses_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    public DataTable GetAll(SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            return objDBManager.ExecuteDataTable("Statuses_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public SqlDataReader GetAllAsDataReader(SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            return objDBManager.ExecuteReader("Statuses_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}