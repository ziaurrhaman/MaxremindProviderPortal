using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SalesTypesDB
/// </summary>
public class SalesTypesDB
{
	public SalesTypesDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public long Add(SalesTypes objSalesTypes, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        try
        {
            objDBManager.AddParameter("SalesTypeId", objSalesTypes.SalesTypeId, SqlDbType.Int, 4, ParameterDirection.Output);
            
            objDBManager.AddParameter("PracticeId", objSalesTypes.PracticeId);
            objDBManager.AddParameter("SalesTypeName", objSalesTypes.SalesTypeName);
            objDBManager.AddParameter("CalculationFactor", objSalesTypes.CalculationFactor);
            objDBManager.AddParameter("TaxIncluded", objSalesTypes.TaxIncluded);
            objDBManager.AddParameter("Status", objSalesTypes.Status);
            objDBManager.AddParameter("CreatedById", objSalesTypes.CreatedById);
            objDBManager.AddParameter("CreatedDate", objSalesTypes.CreatedDate);
            
            objDBManager.ExecuteNonQuery("SalesTypes_Add");
            objSalesTypes.SalesTypeId = long.Parse(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return objSalesTypes.SalesTypeId;
    }
    
    public int Update(SalesTypes objSalesTypes, SqlTransaction objSqlTransaction = null)
    {
        DBManager objDBManager = new DBManager(objSqlTransaction);
        int ReturnValue = 0;
        try
        {
            objDBManager.AddParameter("SalesTypeId", objSalesTypes.SalesTypeId, SqlDbType.Int, 4);
            
            objDBManager.AddParameter("PracticeId", objSalesTypes.PracticeId);
            objDBManager.AddParameter("SalesTypeName", objSalesTypes.SalesTypeName);
            objDBManager.AddParameter("CalculationFactor", objSalesTypes.CalculationFactor);
            objDBManager.AddParameter("TaxIncluded", objSalesTypes.TaxIncluded);
            objDBManager.AddParameter("Status", objSalesTypes.Status);
            objDBManager.AddParameter("ModifiedById", objSalesTypes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSalesTypes.ModifiedDate);
            
            ReturnValue = objDBManager.ExecuteNonQuery("SalesTypes_Update");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        return ReturnValue;
    }
    
    public int Delete(SalesTypes objSalesTypes, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("SalesTypeId", objSalesTypes.SalesTypeId);
            objDBManager.AddParameter("ModifiedById", objSalesTypes.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objSalesTypes.ModifiedDate);
            return objDBManager.ExecuteNonQuery("SalesTypes_Delete");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetByID(int SalesTypeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("SalesTypeId", SalesTypeId);
            
            return objDBManager.ExecuteDataTable("SalesTypes_GetByID");
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
            
            return objDBManager.ExecuteDataSet("SalesTypes_GetAllFilter");
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
            
            return objDBManager.ExecuteDataTable("SalesTypes_GetAll");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetInfo(long ItemsId, long SalesTypeId, SqlTransaction objSqlTransaction = null)
    {
        try
        {
            DBManager objDBManager = new DBManager(objSqlTransaction);
            objDBManager.AddParameter("ItemsId", ItemsId);
            objDBManager.AddParameter("SalesTypeId", SalesTypeId);
            
            return objDBManager.ExecuteDataTable("SalesTypes_GetInfo");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
}