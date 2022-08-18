using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ImmunizationsDB
/// </summary>
public class ImmunizationsDB
{
	public ImmunizationsDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(Immunizations objImmunizations, SqlTransaction objSqlTransaction = null)
    {

        DBManager objDBManager = new DBManager(objSqlTransaction);


        try
        {
            objDBManager.AddParameter("ImmunizationId", objImmunizations.ImmunizationId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objImmunizations.PracticeId);
            objDBManager.AddParameter("ImmunizationName", objImmunizations.ImmunizationName, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("CvxCode", objImmunizations.CvxCode);
            objDBManager.AddParameter("LongName", objImmunizations.LongName);
            objDBManager.AddParameter("CreatedDate", objImmunizations.CreatedDate);
            objDBManager.AddParameter("CreatedById", objImmunizations.CreatedById);

            objDBManager.ExecuteNonQuery("Immunizations_Add");

            objImmunizations.ImmunizationId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return objImmunizations.ImmunizationId;
    }

    public int Update(Immunizations objImmunizations, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        
        try
        {
            objDBManager.AddParameter("ImmunizationId", objImmunizations.ImmunizationId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("PracticeId", objImmunizations.PracticeId);
            objDBManager.AddParameter("ImmunizationName", objImmunizations.ImmunizationName, SqlDbType.VarChar, 250);
            objDBManager.AddParameter("CvxCode", objImmunizations.CvxCode);
            objDBManager.AddParameter("LongName", objImmunizations.LongName);
            objDBManager.AddParameter("ModifiedDate", objImmunizations.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objImmunizations.ModifiedById);
            
            ReturnValue = objDBManager.ExecuteNonQuery("Immunizations_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(Immunizations objImmunizations, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ImmunizationId", objImmunizations.ImmunizationId);
            objDBManager.AddParameter("ModifiedDate", objImmunizations.ModifiedDate);
            objDBManager.AddParameter("ModifiedById", objImmunizations.ModifiedById);
            
            return objDBManager.ExecuteNonQuery("Immunizations_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetAllAsDataTable(SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            return objDBManager.ExecuteDataTable("Immunizations_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}