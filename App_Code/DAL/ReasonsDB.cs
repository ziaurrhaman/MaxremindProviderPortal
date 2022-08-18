using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ReasonsDB
/// </summary>
public class ReasonsDB
{
    public ReasonsDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public int Add(Reasons objReasons, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);

        try
        {
            objDBManager.AddParameter("ReasonId", objReasons.ReasonId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objReasons.PracticeId);
            objDBManager.AddParameter("Description", objReasons.Description);
            objDBManager.AddParameter("BackColor", objReasons.BackColor);
            objDBManager.AddParameter("CreatedById", objReasons.CreatedById);
            objDBManager.AddParameter("CreatedDate", objReasons.CreatedDate);

            objDBManager.ExecuteNonQuery("Reasons_Add");

            objReasons.ReasonId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objReasons.ReasonId;

    }
    
    public int Update(Reasons objReasons, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;

        try
        {
            objDBManager.AddParameter("ReasonId", objReasons.ReasonId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objReasons.PracticeId);
            objDBManager.AddParameter("Description", objReasons.Description);
            objDBManager.AddParameter("BackColor", objReasons.BackColor);
            objDBManager.AddParameter("ModifiedById", objReasons.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objReasons.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("Reasons_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ReturnValue;

    }
    
    public int Delete(Reasons objReasons, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ReasonId", objReasons.ReasonId);
            objDBManager.AddParameter("ModifiedById", objReasons.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objReasons.ModifiedDate);
            return objDBManager.ExecuteNonQuery("Reasons_Delete");
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
            return objDBManager.ExecuteDataTable("Reasons_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    
    public DataTable GetById(int ReasonId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ReasonId", ReasonId);
            return objDBManager.ExecuteDataTable("Reasons_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    
    public DataSet GetAllFilter(long PracticeId, int Rows, int PageNumber, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);

            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);

            return objDBManager.ExecuteDataSet("Reasons_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}