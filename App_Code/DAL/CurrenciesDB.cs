using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CurrenciesDB
/// </summary>
public class CurrenciesDB
{
	public CurrenciesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Add(Currencies objCurrencies, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("CurrencyId", objCurrencies.CurrencyId, SqlDbType.Int, 4, ParameterDirection.Output);

            objDBManager.AddParameter("PracticeId", objCurrencies.PracticeId);
            objDBManager.AddParameter("CurrencyName", objCurrencies.CurrencyName);
            objDBManager.AddParameter("CreatedById", objCurrencies.CreatedById);
            objDBManager.AddParameter("CreatedDate", objCurrencies.CreatedDate);
            
            objDBManager.ExecuteNonQuery("Currencies_Add");
            objCurrencies.CurrencyId = int.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objCurrencies.CurrencyId;
    }
    
    public int Update(Currencies objCurrencies, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("CurrencyId", objCurrencies.CurrencyId, SqlDbType.Int, 4);

            objDBManager.AddParameter("PracticeId", objCurrencies.PracticeId);
            objDBManager.AddParameter("CurrencyName", objCurrencies.CurrencyName);
            objDBManager.AddParameter("ModifiedById", objCurrencies.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCurrencies.ModifiedDate);

            ReturnValue = objDBManager.ExecuteNonQuery("Currencies_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ReturnValue;
    }
    
    public int Delete(Currencies objCurrencies, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("CurrencyId", objCurrencies.CurrencyId);
            objDBManager.AddParameter("ModifiedById", objCurrencies.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objCurrencies.ModifiedDate);
            
            return objDBManager.ExecuteNonQuery("Currencies_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(int CurrencyId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("CurrencyId", CurrencyId);
            
            return objDBManager.ExecuteDataTable("Currencies_GetByID");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataSet GetAllFilterByPracticeId(long PracticeId, int Rows, int PageNumber, string SortBy, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            objDBManager.AddParameter("Rows", Rows);
            objDBManager.AddParameter("PageNumber", PageNumber);
            objDBManager.AddParameter("SortBy", SortBy);
            
            return objDBManager.ExecuteDataSet("Currencies_GetAllFilter");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetAllByPracticeId(long PracticeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("PracticeId", PracticeId);
            
            return objDBManager.ExecuteDataTable("Currencies_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}